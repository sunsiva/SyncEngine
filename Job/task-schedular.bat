set taskfrq=15
set apppath=C:\CacheTech\SyncEngine
for /F "tokens=*" %%i in (%apppath%\settings.txt) do (
   set taskfrq=%%i
)
timeout 2
SCHTASKS /CREATE /SC MINUTE /MO %taskfrq% /TN "MyTasks\SyncEngine" /TR "%apppath%\SyncEngine.Alert.exe" /ST 01:00
echo %date% %time%_Success >"%apppath%\sync_status.txt"
echo "%date% %time%| Task Created for %taskfrq% mins" >>"%apppath%\sync_log.log"