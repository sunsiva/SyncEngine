set repopath=""
set appPath=C:\CacheTech\SyncEngine
for /F "tokens=1,2,3,4,5 delims=| " %%a in (%appPath%\userprofile.txt) do (
   set repopath=%%b
)
set back=%cd%
for /d %%i in (%repopath%\*) do (
    cd "%%i"
    "C:\Program Files\git\bin\sh.exe" "C:\CacheTech\SyncEngine\git-sync.sh"
    timeout 10
    cd
)