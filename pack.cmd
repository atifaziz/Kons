@echo off
setlocal
pushd "%~dp0"
call :main %*
popd
goto :EOF

:main
setlocal
set VERSION_SUFFIX=VersionSuffix=
set COMMIT_UNIX_TIME=
(for /f %%i in ('git log -1 "--format=%%ct"') do set COMMIT_UNIX_TIME=%%i) || goto :pack
if not defined COMMIT_UNIX_TIME echo Unable to determine the time of commit. Git not installed? & exit /b 1
call :dtjs %COMMIT_UNIX_TIME% > "%temp%\dt.js"
for /f %%i in ('cscript //nologo "%temp%\dt.js"') do set COMMIT_TIME=%%i
set VERSION_SUFFIX=%VERSION_SUFFIX%-alpha-%COMMIT_TIME:~0,8%T%COMMIT_TIME:~-4%
:pack
call build ^
  && (if not exist dist mkdir dist) ^
  && NuGet pack Kons.nuspec -Symbol -Properties "%VERSION_SUFFIX%" -OutputDirectory dist
goto :EOF

:dtjs
echo Number.prototype.ra = function(w) { return (w + this.valueOf()).slice(-w.length); }
echo var dt = new Date(0); dt.setUTCSeconds(%1);
echo var y  = dt.getUTCFullYear() ,
echo     mo = dt.getUTCMonth() + 1,
echo     d  = dt.getUTCDate()     ,
echo     h  = dt.getUTCHours()    ,
echo     mi = dt.getUTCMinutes()  ;
echo WScript.Echo(y + mo.ra('00') + d.ra('00') + h.ra('00') + mi.ra('00'));
goto :EOF
