@echo off

:Build
set MSBuild="%ProgramFiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe"
if not exist %MSBuild% @set MSBuild="%ProgramFiles%\MSBuild\14.0\Bin\MSBuild.exe"
if not exist %MSBuild% @set MSBuild="%ProgramFiles(x86)%\MSBuild\12.0\Bin\MSBuild.exe"
if not exist %MSBuild% @set MSBuild="%ProgramFiles%\MSBuild\12.0\Bin\MSBuild.exe"

%MSBuild%  /m /nr:false /p:Platform="Any CPU" /p:Desktop=true /v:M /fl src\AttributeRouting.sln

if %ERRORLEVEL% neq 0 goto BuildFail
goto BuildSuccess

:BuildFail
echo.
echo *** BUILD FAILED ***
goto End

:BuildSuccess
echo.
echo **** BUILD SUCCESSFUL ***
goto end

:End
popd
endlocal

@PAUSE
