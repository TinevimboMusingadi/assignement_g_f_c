# Installs SQL Server Express LocalDB (MSI) silently so Question C can use (localdb)\MSSQLLocalDB.
# Run in Windows PowerShell or PowerShell 7: **Right-click → Run as administrator**
#   cd <project>\Scripts
#   .\Install-SqlServerLocalDB.ps1

$ErrorActionPreference = 'Stop'

$MsiUrl = 'https://download.microsoft.com/download/3/8/d/38de7036-2433-4207-8eae-06e247e17b25/SqlLocalDB.msi'
$MsiPath = Join-Path $env:TEMP 'SqlLocalDB.msi'

function Test-Administrator {
    $p = [Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()
    return $p.IsInRole([Security.Principal.WindowsBuiltinRole]::Administrator)
}

if (-not (Test-Administrator)) {
    Write-Host 'This installer must run elevated. Open PowerShell as Administrator and run this script again.' -ForegroundColor Red
    exit 1
}

Write-Host 'Downloading SQL Server Express LocalDB (official Microsoft MSI)...' -ForegroundColor Cyan
Invoke-WebRequest -Uri $MsiUrl -OutFile $MsiPath -UseBasicParsing

Write-Host 'Installing silently (may take one to two minutes)...' -ForegroundColor Cyan
$log = Join-Path $env:TEMP 'SqlLocalDB-Install.log'
$argsList = @(
    '/i', "`"$MsiPath`"",
    'IACCEPTSQLLOCALDBLICENSETERMS=YES',
    '/qn',
    '/norestart',
    '/L*v',
    "`"$log`""
)
$proc = Start-Process -FilePath 'msiexec.exe' -ArgumentList $argsList -Wait -PassThru
if ($proc.ExitCode -ne 0 -and $proc.ExitCode -ne 3010) {
    Write-Host ("msiexec exit code: {0}. See log: {1}" -f $proc.ExitCode, $log) -ForegroundColor Red
    exit $proc.ExitCode
}

function Resolve-SqlLocalDb {
    $candidates = @(
        Join-Path ${env:ProgramFiles} 'Microsoft SQL Server\170\Tools\Binn\SqlLocalDB.exe'
        Join-Path ${env:ProgramFiles} 'Microsoft SQL Server\160\Tools\Binn\SqlLocalDB.exe'
        Join-Path ${env:ProgramFiles} 'Microsoft SQL Server\150\Tools\Binn\SqlLocalDB.exe'
        'SqlLocalDB.exe'
    )
    foreach ($p in $candidates) {
        if ($p -eq 'SqlLocalDB.exe') {
            $cmd = Get-Command SqlLocalDB.exe -ErrorAction SilentlyContinue
            if ($cmd) { return $cmd.Source }
            continue
        }
        if (Test-Path $p) { return $p }
    }
    return $null
}

Write-Host 'MSI install finished.' -ForegroundColor Green
Write-Host ''
Write-Host 'NEXT STEP (required): LocalDB automatic instances belong to YOUR USER, not Administrator.' -ForegroundColor Yellow
Write-Host ' Close this Administrator window.' -ForegroundColor Yellow
Write-Host ' Open PowerShell normally (Win+X, then Terminal/PowerShell, NOT Admin), then:' -ForegroundColor Yellow
Write-Host ('  cd "{0}"' -f (Split-Path $PSScriptRoot -Parent)) -ForegroundColor White
Write-Host ('  .\Scripts\Initialize-LocalDB-ForCurrentUser.ps1') -ForegroundColor White
Write-Host ''
Write-Host 'That script starts MSSQLLocalDB (or deletes/recreates it if needed).' -ForegroundColor Cyan

$db = Resolve-SqlLocalDb
if (-not $db) {
    Write-Host 'Warning: SqlLocalDB.exe was not found under Program Files yet. Restart the PC and run Initialize-LocalDB-ForCurrentUser.ps1.' -ForegroundColor Yellow
}
else {
    Write-Host "(SqlLocalDB is at: $db - do not run it from this elevated session)" -ForegroundColor DarkGray
}

Write-Host ''
Write-Host 'Then: run Visual Studio as your usual user, Question C, Setup DB, Refresh Data.' -ForegroundColor Cyan
