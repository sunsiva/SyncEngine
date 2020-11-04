set taskfrq=15
set apppath=C:\CacheTech\SyncEngine
set repopath=""
for /F "tokens=1,2,3,4,5 delims=| " %%a in (%apppath%\userprofile.txt) do (
   set repopath=%%b
   set repoName=%%e
)
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
echo "%date% %time%| Task Created for %taskfrq% mins" >>"sync_log.log"