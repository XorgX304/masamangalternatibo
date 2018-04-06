@echo off
echo Compiling...
set au3="C:\Program Files (x86)\AutoIt3\Aut2Exe\"
set out=%cd%
cd %au3%
Aut2exe.exe /in "%out%\getDriveSerial.au3" /pack /comp 4 /console
echo Finished!
pause