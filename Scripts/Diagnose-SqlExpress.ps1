# Shows SQL Express service state, recent Application log hints, and last lines of ERRORLOG.
# Run when MSSQL`$SQLEXPRESS refuses to start.
#
# PowerShell (Administrator optional).

Write-Host '=== SQL Express / MSSQL* services ===' -ForegroundColor Cyan
Get-Service MSSQL* -ErrorAction SilentlyContinue | Sort-Object Name | Format-Table Name, Status, StartType -AutoSize

Write-Host '=== Recent Application log (SQL-related, newest first) ===' -ForegroundColor Cyan
try {
    Get-WinEvent -LogName Application -MaxEvents 400 -ErrorAction Stop |
        Where-Object {
            $_.ProviderName -match 'SQL|Mssql' -or $_.Message -match 'SQL Server|SQL\b|MSSQL|SQLExpress'
        } |
        Select-Object -First 20 TimeCreated, ProviderName, Id,
        @{ n = 'Message'; e = { $_.Message -replace "`r`n", ' | ' | ForEach-Object { $_.Substring(0, [Math]::Min(220, $_.Length)) } } } |
        Format-Table -Wrap -AutoSize
}
catch {
    Write-Host ("Could not read Application log: {0}" -f $_.Exception.Message) -ForegroundColor Yellow
}

Write-Host '=== ERRORLOG tails under Program Files Microsoft SQL Server ===' -ForegroundColor Cyan
$sqlRoot = Join-Path ${env:ProgramFiles} 'Microsoft SQL Server'
if (-not (Test-Path $sqlRoot)) {
    Write-Host "Not found: $sqlRoot"
    exit 0
}

$logs = Get-ChildItem -Path $sqlRoot -Directory -Filter 'MSSQL*.SQLEXPRESS' -ErrorAction SilentlyContinue |
    ForEach-Object {
        Join-Path $_.FullName 'MSSQL\Log\ERRORLOG'
    } |
    Where-Object { Test-Path -LiteralPath $_ }

if (-not $logs) {
    Write-Host 'No MSSQL*.SQLEXPRESS\...\ERRORLOG found. Instance folder name may differ (e.g. custom name).' -ForegroundColor Yellow
}

foreach ($logPath in $logs) {
    Write-Host "--- $logPath ---" -ForegroundColor Yellow
    Get-Content -LiteralPath $logPath -Tail 40 -ErrorAction SilentlyContinue
    Write-Host ''
}

Write-Host 'If ERRORLOG mentions sector size / misaligned reads, see:' -ForegroundColor DarkGray
Write-Host 'https://learn.microsoft.com/troubleshoot/sql/database-engine/database-file-operations/troubleshooting-operating-system-disk-sector-size-misreported' -ForegroundColor DarkGray
