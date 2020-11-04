echo "WE ARE GOING TO BEGIN SYNC PROCESS IN 30 SECS. PLEASE SAVE ALL YOUR CHANGES."
timeout 30
set uname=Azure devops
set repopath=""
set appPath=C:\CacheTech\SyncEngine
set usertoken=""
for /F "tokens=1,2,3,4,5 delims=| " %%a in (%appPath%\userprofile.txt) do (
   set uname=%%a
   set repopath=%%b
   set usertoken=%%c
   set repoUrl=%%d
   set repoName=%%e
)
c:
cd %repopath%\%repoName%
git pull
git add .
git commit -m "sync from %uname%"
git push %repoUrl% -f
git pull
timeout 2
git status >"%appPath%\git_status.txt"
for /F "tokens=*" %%a in (%appPath%\git_status.txt) do (
(echo(%%a)|find /i "branch is ahead" >nul && (
  git push %repoUrl% -f
)
)
timeout 2
git status >>"%appPath%\sync_log.log"
set exitcode=%errorlevel%
if %exitcode% neq 0 (
echo %date% %time%_Failure >"%appPath%\sync_status.txt"
echo %date% %time%| %exitcode% >>"%appPath%\sync_log.log"
exit
)
timeout 2
echo %date% %time%_Success >"%appPath%\sync_status.txt"
echo %date% %time%|App-Push changes done.. >>"%appPath%\sync_log.log"
exit