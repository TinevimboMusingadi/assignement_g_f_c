# Re-downloads Microsoft's SqlLocalDB.msi and reinstalls LocalDB files (repair-style).
# Use when Initialize-LocalDB-ForCurrentUser.ps1 keeps reporting:
#   "SQL Server process failed to start"
#
# Run ONLY in PowerShell as ADMINISTRATOR. Reboot recommended after success.
# Then run .\Initialize-LocalDB-ForCurrentUser.ps1 in NON-admin PowerShell.

$ErrorActionPreference = 'Stop'

function Test-Administrator {
    $p = [Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()
    return $p.IsInRole([Security.Principal.WindowsBuiltinRole]::Administrator)
}

if (-not (Test-Administrator)) {
    Write-Host 'Right-click PowerShell -> Run as administrator, then run this script.' -ForegroundColor Red
    exit 1
}

$MsiUrl = 'https://download.microsoft.com/download/3/8/d/38de7036-2433-4207-8eae-06e247e17b25/SqlLocalDB.msi'
$MsiPath = Join-Path $env:TEMP 'SqlLocalDB-repair.msi'

Write-Host 'Downloading SqlLocalDB.msi ...' -ForegroundColor Cyan
Invoke-WebRequest -Uri $MsiUrl -OutFile $MsiPath -UseBasicParsing

Write-Host 'Reinstalling LocalDB silently (repair mode). Wait 1-3 minutes ...' -ForegroundColor Cyan
$log = Join-Path $env:TEMP 'SqlLocalDB-repair-install.log'
# REINSTALLMODE=vomus = reinstall from package; REINSTALL=ALL patches all installed features on that product.
$arg = @(
    '/i', "`"$MsiPath`"",
    'IACCEPTSQLLOCALDBLICENSETERMS=YES',
    'REINSTALL=ALL',
    'REINSTALLMODE=vomus',
    '/qn',
    '/norestart',
    '/L*v',
    "`"$log`""
)
$proc = Start-Process -FilePath 'msiexec.exe' -ArgumentList $arg -Wait -PassThru
if ($proc.ExitCode -ne 0 -and $proc.ExitCode -ne 3010) {
    Write-Host ("msiexec exited {0}. Full log: {1}" -f $proc.ExitCode, $log) -ForegroundColor Red
    exit $proc.ExitCode
}

Write-Host 'Repair finished OK.' -ForegroundColor Green
Write-Host 'Next: reboot (recommended). Then NON-admin PowerShell:' -ForegroundColor Yellow
Write-Host ('  cd "{0}"' -f (Split-Path $PSScriptRoot -Parent))
Write-Host '  .\Scripts\Clear-LocalDbUserInstances.ps1'
Write-Host '  .\Scripts\Initialize-LocalDB-ForCurrentUser.ps1'
