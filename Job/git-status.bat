set apppath=C:\CacheTech\SyncEngine
set repopath=""
for /F "tokens=1,2,3,4,5 delims=| " %%a in (%apppath%\userprofile.txt) do (
   set repopath=%%b
   set repoName=%%e
)
cd %repopath%\%repoName%
git pull
timeout 1
git status >%apppath%\git_status.txt