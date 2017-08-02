@ECHO OFF
pushd "%~dp0"
ECHO.
ECHO.
ECHO.
ECHO This script deletes all temporary build files in their
ECHO corresponding BIN and OBJ Folder contained in the following projects
ECHO.
ECHO NumericUpDowmControlDemo
ECHO NumericUpDownLib
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
ECHO Deleting BIN and OBJ Folders in NumericUpDowmControlDemo
ECHO.
RMDIR /S /Q .\.vs
RMDIR /S /Q .\NumericUpDowmControlDemo\bin
RMDIR /S /Q .\NumericUpDowmControlDemo\obj
ECHO.
ECHO Deleting BIN and OBJ Folders in NumericUpDownLib
ECHO.
RMDIR /S /Q .\NumericUpDownLib\bin
RMDIR /S /Q .\NumericUpDownLib\obj
ECHO.

PAUSE

:EndOfBatch
