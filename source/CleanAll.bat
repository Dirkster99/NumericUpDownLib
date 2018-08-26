@ECHO OFF
pushd "%~dp0"
ECHO.
ECHO.
ECHO.
ECHO This script deletes all temporary build files in their
ECHO corresponding BIN and OBJ Folder contained in the following projects
ECHO.
ECHO TestThemes
ECHO TestGenerics
ECHO NumericUpDownLib
ECHO Demo\UpDownDemoLib
ECHO Demo\MLibTest\Components\ServiceLocator
ECHO Demo\MLibTest\Components\Settings\Settings
ECHO Demo\MLibTest\Components\Settings\SettingsModel
ECHO.
REM Ask the user if hes really sure to continue beyond this point XXXXXXXX
set /p choice=Are you sure to continue (Y/N)?
if not '%choice%'=='Y' Goto EndOfBatch
REM Script does not continue unless user types 'Y' in upper case letter
ECHO.
ECHO XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
ECHO.
ECHO XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
ECHO.
ECHO Deleting BIN and OBJ Folders in NumericUpDownLib
ECHO.
RMDIR /S /Q .\NumericUpDownLib\bin
RMDIR /S /Q .\NumericUpDownLib\obj
ECHO.
ECHO Deleting BIN and OBJ Folders in TestThemes
ECHO.
RMDIR /S /Q .\TestThemes\bin
RMDIR /S /Q .\TestThemes\obj
ECHO.
ECHO Deleting BIN and OBJ Folders in TestGenerics
ECHO.
RMDIR /S /Q .\TestGenerics\bin
RMDIR /S /Q .\TestGenerics\obj
ECHO.

ECHO.
ECHO Deleting BIN and OBJ Folders in UpDownDemoLib
ECHO.
RMDIR /S /Q .\.vs
RMDIR /S /Q .\Demo\UpDownDemoLib\bin
RMDIR /S /Q .\Demo\UpDownDemoLib\obj

ECHO.
ECHO Deleting BIN and OBJ Folders in Demo\MLibTest\Components\ServiceLocator
ECHO.
RMDIR /S /Q .\.vs
RMDIR /S /Q .\Demo\MLibTest\Components\ServiceLocator\bin
RMDIR /S /Q .\Demo\MLibTest\Components\ServiceLocator\obj

ECHO.
ECHO Deleting BIN and OBJ Folders in Demo\MLibTest\Components\Settings\Settings
ECHO.
RMDIR /S /Q .\.vs
RMDIR /S /Q .\Demo\MLibTest\Components\Settings\Settings\bin
RMDIR /S /Q .\Demo\MLibTest\Components\Settings\Settings\obj

ECHO.
ECHO Deleting BIN and OBJ Folders in Demo\MLibTest\Components\Settings\SettingsModel
ECHO.
RMDIR /S /Q .\.vs
RMDIR /S /Q .\Demo\MLibTest\Components\Settings\SettingsModel\bin
RMDIR /S /Q .\Demo\MLibTest\Components\Settings\SettingsModel\obj

PAUSE

:EndOfBatch
