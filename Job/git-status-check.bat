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
cd C:\
%repopath:~0,2%
timeout 2
cd %repopath%\%repoName%
"C:\PROGRAM FILES\git\bin\sh.exe" "C:\CacheTech\SyncEngine\git-sync.sh" check