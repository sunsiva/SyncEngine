$testchoco = powershell choco -v
if(-not($testchoco)){
"powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"

}
if(test-path "C:\ProgramData\chocolatey\choco.exe"){

}

set exitcode=%errorlevel%
if %exitcode% neq 0 (
echo "%exitcode% -- %date%_%time%" >>"pre_install_%date%.log" 2>&1
exit
)

echo "Installed successful -- %date%_%time%" >>"pre_install_%date%.log" 2>&1
exit