# Starts or recreates the MSSQLLocalDB automatic instance for your Windows user.
#
# IMPORTANT: Run this WITHOUT "Run as Administrator" (same account you use for Visual Studio).
# LocalDB automatic instances are per-user; Admin sessions often fail with:
#   "Cannot create an automatic instance"
#
#   cd <project>\Scripts
#   .\Initialize-LocalDB-ForCurrentUser.ps1

$ErrorActionPreference = 'Stop'

function Test-Administrator {
    $p = [Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()
    return $p.IsInRole([Security.Principal.WindowsBuiltinRole]::Administrator)
}

if (Test-Administrator) {
    Write-Host 'Run this script from a normal PowerShell window (not Administrator).' -ForegroundColor Yellow
    Write-Host 'LocalDB automatic instances do not start correctly from elevated shells.' -ForegroundColor Yellow
    exit 1
}

function Resolve-SqlLocalDb {
    $candidates = @(
        Join-Path ${env:ProgramFiles} 'Microsoft SQL Server\170\Tools\Binn\SqlLocalDB.exe'
        Join-Path ${env:ProgramFiles} 'Microsoft SQL Server\160\Tools\Binn\SqlLocalDB.exe'
        Join-Path ${env:ProgramFiles} 'Microsoft SQL Server\150\Tools\Binn\SqlLocalDB.exe'
        'SqlLocalDB.exe'
    )
    foreach ($candidate in $candidates) {
        if ($candidate -eq 'SqlLocalDB.exe') {
            $cmd = Get-Command SqlLocalDB.exe -ErrorAction SilentlyContinue
            if ($cmd) { return $cmd.Source }
            continue
        }
        if (Test-Path $candidate) { return $candidate }
    }
    return $null
}

function Invoke-SqlLocalDb {
    param(
        [Parameter(Mandatory)][string]$ExePath,
        [Parameter(Mandatory)][string[]]$Arguments
    )
    # SqlLocalDB prints failures to stderr; stderr as ErrorRecord + $ErrorActionPreference Stop aborts the script.
    $stdoutFile = Join-Path ([System.IO.Path]::GetTempPath()) ([System.IO.Path]::GetRandomFileName())
    $stderrFile = Join-Path ([System.IO.Path]::GetTempPath()) ([System.IO.Path]::GetRandomFileName())
    try {
        $p = Start-Process -FilePath $ExePath `
            -ArgumentList $Arguments `
            -Wait -PassThru `
            -NoNewWindow `
            -RedirectStandardOutput $stdoutFile `
            -RedirectStandardError $stderrFile
        $outParts = @()
        if (Test-Path $stdoutFile) { $outParts += Get-Content $stdoutFile -Raw -ErrorAction SilentlyContinue }
        if (Test-Path $stderrFile) { $outParts += Get-Content $stderrFile -Raw -ErrorAction SilentlyContinue }
        $text = (($outParts | Where-Object { $_ }) -join "`n").TrimEnd()
        return [PSCustomObject]@{ ExitCode = $p.ExitCode; Text = $text }
    }
    finally {
        Remove-Item $stdoutFile -ErrorAction SilentlyContinue
        Remove-Item $stderrFile -ErrorAction SilentlyContinue
    }
}

function Test-BadOutput([PSCustomObject]$result) {
    $t = $result.Text
    return (
        ($result.ExitCode -ne 0) -or
        ($t -match '(?i)failed|error|cannot create')
    )
}

$localDbExe = Resolve-SqlLocalDb
if (-not $localDbExe) {
    Write-Host 'SqlLocalDB.exe was not found. Install LocalDB first: Install-SqlServerLocalDB.ps1 (as Administrator).' -ForegroundColor Red
    exit 1
}

Write-Host "Using SqlLocalDB: $localDbExe" -ForegroundColor Cyan

$startResult = Invoke-SqlLocalDb -ExePath $localDbExe -Arguments @('start', 'MSSQLLocalDB')
Write-Host '--- start MSSQLLocalDB ---' -ForegroundColor DarkGray
Write-Host $startResult.Text
if ($startResult.ExitCode -ne 0) { Write-Host "(exit code $($startResult.ExitCode))" -ForegroundColor DarkYellow }

if (-not (Test-BadOutput $startResult)) {
    Write-Host 'MSSQLLocalDB is ready. Open Question C: Setup DB, then Refresh Data.' -ForegroundColor Green
    exit 0
}

Write-Host ''
Write-Host 'Start failed - recreating the automatic instance (delete + create + start)...' -ForegroundColor Yellow

$del = Invoke-SqlLocalDb -ExePath $localDbExe -Arguments @('delete', 'MSSQLLocalDB')
Write-Host '--- delete MSSQLLocalDB ---' -ForegroundColor DarkGray
Write-Host $del.Text

$create = Invoke-SqlLocalDb -ExePath $localDbExe -Arguments @('create', 'MSSQLLocalDB')
Write-Host '--- create MSSQLLocalDB ---' -ForegroundColor DarkGray
Write-Host $create.Text

$start2 = Invoke-SqlLocalDb -ExePath $localDbExe -Arguments @('start', 'MSSQLLocalDB')
Write-Host '--- start MSSQLLocalDB (retry) ---' -ForegroundColor DarkGray
Write-Host $start2.Text
if ($start2.ExitCode -ne 0) { Write-Host "(exit code $($start2.ExitCode))" -ForegroundColor DarkYellow }

if (-not (Test-BadOutput $start2)) {
    Write-Host 'MSSQLLocalDB recreated and started successfully.' -ForegroundColor Green
    exit 0
}

Write-Host ''
Write-Host 'Still failing. You ARE doing it right if this ran in NON-ADMIN PowerShell.' -ForegroundColor Yellow
Write-Host 'The SqlLocalDB engine binary is starting then crashing (machine state), not wrong script usage.' -ForegroundColor Yellow
Write-Host ''
Write-Host 'Next checks (ASCII only for older consoles):' -ForegroundColor Red
Write-Host '  1. Event Viewer -> Windows Logs -> Application. Filter: SQLLOCALDB / SQL Server. Read the FIRST error.' -ForegroundColor White
Write-Host '  2. Settings -> Apps -> remove broken "SQL Server 202x Express" or duplicate SQL installs, reboot.' -ForegroundColor White
Write-Host '  3. Apps -> repair "Microsoft SQL Server ... Local DB" component, OR re-run Install-SqlServerLocalDB.ps1 as Admin.' -ForegroundColor White
Write-Host '  4. Optional cleanup (close VS first): delete folder if it exists:'
Write-Host ('     "{0}"' -f (Join-Path $env:LOCALAPPDATA 'Microsoft\Microsoft SQL Server Local DB\Instances'))
Write-Host '     then run this Initialize script again (non-admin).'
Write-Host '  5. Temporarily disable antivirus; reboot; retry.'
Write-Host '  6. Disk sector size issues:'
Write-Host '     https://learn.microsoft.com/troubleshoot/sql/database-engine/database-file-operations/troubleshooting-operating-system-disk-sector-size-misreported'
exit 1
