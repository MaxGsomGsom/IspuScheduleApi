@echo off
set MSBUILDEXE=%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe
set TARGET=rebuild

if "%1" == "" (
	set FLAVOR=debug
) else (
	set FLAVOR=%1
)

%MSBUILDEXE% /t:%TARGET% /p:configuration=%FLAVOR% /maxcpucount /v:n /clp:NoItemAndPropertyList IspuScheduleApi.sln 
pause