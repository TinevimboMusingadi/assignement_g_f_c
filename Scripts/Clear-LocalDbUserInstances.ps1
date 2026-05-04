# Deletes your per-user LocalDB instance files (fixes stuck/corrupt MSSQLLocalDB data).
# Close Visual Studio and Assignment.exe first.
#
# Run in NON-ADMIN PowerShell (your normal user).

$ErrorActionPreference = 'Stop'

function Test-Administrator {
    $p = [Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()
    return $p.IsInRole([Security.Principal.WindowsBuiltinRole]::Administrator)
}

if (Test-Administrator) {
    Write-Host 'Use a NORMAL PowerShell (not Administrator) so we clear YOUR user profile files.' -ForegroundColor Yellow
    exit 1
}

$root = Join-Path $env:LOCALAPPDATA 'Microsoft\Microsoft SQL Server Local DB'
$instances = Join-Path $root 'Instances'

Write-Host ("Looking for:`n  {0}" -f $instances)

if (-not (Test-Path -LiteralPath $instances)) {
    Write-Host 'Nothing to delete (folder missing).' -ForegroundColor Green
    exit 0
}

Write-Host 'Removing Instances folder ...' -ForegroundColor Yellow
Remove-Item -LiteralPath $instances -Recurse -Force
Write-Host 'Done. Run: .\Initialize-LocalDB-ForCurrentUser.ps1' -ForegroundColor Green
