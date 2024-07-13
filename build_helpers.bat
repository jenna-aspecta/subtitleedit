@ECHO OFF
SETLOCAL
PUSHD %~dp0
SET "ConfigurationName=%~2"

ECHO %cd%

IF /I "%~1" == "lang" GOTO UpdateLanguageFiles
IF /I "%~1" == "rev"  GOTO UpdateAssemblyInfo

:END
POPD
ENDLOCAL
EXIT /B

:UpdateLanguageFiles
SET "ToolPath=src\UpdateLanguageFiles\bin\%ConfigurationName%\UpdateLanguageFiles.exe"
IF NOT EXIST "%ToolPath%" (
  ECHO Compile Subtitle Edit first!
  GOTO END
)

"%ToolPath%" "LanguageBaseEnglish.xml" "src\ui\Logic\LanguageDeserializer.cs"

IF %ERRORLEVEL% NEQ 0 (
  ECHO ERROR: Something went wrong when generating the language files...
)
GOTO END


:UpdateAssemblyInfo
SET "ToolPath=src\UpdateAssemblyInfo\bin\%ConfigurationName%\UpdateAssemblyInfo.exe"
IF NOT EXIST "%ToolPath%" (
  ECHO Compile Subtitle Edit first!
  GOTO END
)

"%ToolPath%" "src\ui\Properties\AssemblyInfo.cs.template" "src\libse\Properties\AssemblyInfo.cs.template"

IF %ERRORLEVEL% NEQ 0 (
  ECHO ERROR: Something went wrong when generating the revision number...
)
GOTO END