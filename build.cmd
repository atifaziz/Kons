@echo off
pushd "%~dp0"
call :main
popd
goto :EOF

:main
setlocal
set DOTNETEXE=
for %%f in (dotnet.exe) do set DOTNETEXE=%%~dpnx$PATH:f
if not defined DOTNETEXE set DOTNETEXE=%ProgramFiles%\dotnet
if not exist "%DOTNETEXE%" (
    echo Microsoft Build Tools 2015 does not appear to be installed on this
    echo machine, which is required to build the solution. You can install
    echo it from the URL below and then try building again:
    echo https://www.microsoft.com/en-us/download/detailscd .aspx?id=48159
    exit /b 1
)
"%DOTNETEXE%" restore && call :build Debug && call :build Release
goto :EOF

:build
"%DOTNETEXE%" build -c %1
goto :EOF
