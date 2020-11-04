timeout 2
set appPath=C:\CacheTech\SyncEngine
set repopath=""
for /F "tokens=1,2,3,4,5 delims=| " %%a in (%appPath%\userprofile.txt) do (
    set repopath=%%b
   set usertoken=%%c
   set repoUrl=%%d
   set repoName=%%e
)
timeout 2
cd C:\
%repopath:~0,2%
cd %repopath%
git clone %repoUrl%
cd %repopath%\%repoName%
git status >>"%appPath%\sync_log.log"
set exitcode=%errorlevel%
if %exitcode% neq 0 (
echo "%date% %time% -- %exitcode% clone failure" >>"%appPath%\sync_log.log"
exit
)
echo "%date% %time% git clone successful" >>"%appPath%\sync_log.log"
:WAITLOOP
if exist %repopath%\%repoName%\settings.txt (
    goto NOTRUNNING
)
goto RUNNING
:RUNNING
timeout 10
goto WAITLOOP
:NOTRUNNING
for /F "tokens=*" %%i in (%repopath%\%repoName%\settings.txt) do (
   set taskfrq=%%i
)
timeout 2
SCHTASKS /CREATE /SC MINUTE /MO %taskfrq% /TN "MyTasks\SyncEngine" /TR "%apppath%\SyncEngine.Alert.exe" /ST 01:00
echo %date% %time%_Success >"%apppath%\sync_status.txt"
echo "%date% %time%| Task Created for %taskfrq% mins" >>"%apppath%\sync_log.log"
exit