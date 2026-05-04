# Starts the SQL Server Express database engine (default instance SQLEXPRESS -> service MSSQL`$SQLEXPRESS).
# SQL Browser is OPTIONAL for connections to .\SQLEXPRESS on the same machine (shared memory).
#
# Run in PowerShell as ADMINISTRATOR.

$ErrorActionPreference = 'Continue'

function Test-Administrator {
    $p = [Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()
    return $p.IsInRole([Security.Principal.WindowsBuiltinRole]::Administrator)
}

if (-not (Test-Administrator)) {
    Write-Host 'Run PowerShell as Administrator.' -ForegroundColor Red
    exit 1
}

$engine = 'MSSQL$SQLEXPRESS'
$s = Get-Service -Name $engine -ErrorAction SilentlyContinue
if (-not $s) {
    Write-Host "Service '$engine' not found. Install SQL Server Express with instance name SQLEXPRESS." -ForegroundColor Red
    exit 1
}

if ($s.Status -eq 'Running') {
    Write-Host "$engine is already Running." -ForegroundColor Green
}
else {
    try {
        Set-Service -Name $engine -StartupType Automatic -ErrorAction Stop
        Start-Service -Name $engine -ErrorAction Stop
        Write-Host "$engine started." -ForegroundColor Green
    }
    catch {
        Write-Host "FAILED to start $engine : $($_.Exception.Message)" -ForegroundColor Red
        Write-Host ''
        Write-Host 'Run diagnostics (paste in any PowerShell):' -ForegroundColor Yellow
        Write-Host ('  cd "{0}"' -f (Split-Path $PSScriptRoot -Parent))
        Write-Host '  .\Scripts\Diagnose-SqlExpress.ps1'
        Write-Host ''
        Write-Host 'Common causes: unfinished SQL Server 2025 install, corrupted master DB, NT Service permissions, antivirus, disk sector quirks. Repair/Uninstall conflicting SQL versions in Apps, then reinstall Express 2022.' -ForegroundColor DarkYellow
        exit 1
    }
}

$browser = Get-Service -Name 'SQLBrowser' -ErrorAction SilentlyContinue
if ($browser -and $browser.Status -ne 'Running') {
    try {
        if ($browser.StartType -eq 'Disabled') {
            Write-Host 'SQL Browser is Disabled (normal). Skipping Browser - not needed for local .\SQLEXPRESS.' -ForegroundColor DarkGray
        }
        else {
            Set-Service -Name 'SQLBrowser' -StartupType Manual -ErrorAction SilentlyContinue
            Start-Service -Name 'SQLBrowser' -ErrorAction Stop
            Write-Host 'SQLBrowser started (optional).' -ForegroundColor DarkGray
        }
    }
    catch {
        Write-Host 'SQL Browser did not start (usually OK for same-PC SQLEXPRESS):' $($_.Exception.Message) -ForegroundColor DarkYellow
    }
}

Write-Host ''
Write-Host 'Status:' -ForegroundColor Cyan
Get-Service -Name 'MSSQL$SQLEXPRESS' -ErrorAction SilentlyContinue | Format-Table Name, Status -AutoSize
