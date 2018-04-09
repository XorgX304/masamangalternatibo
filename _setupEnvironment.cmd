@echo off
set dbgdir="masamangalternatibo\bin\Debug"
echo Copying Files to %dbgdir%
copy IconLib\IconLib.dll, %dbgdir%\IconLib.dll
copy Aut2Exe\compiler.exe, %dbgdir%\compiler.exe
copy Aut2Exe\Au3Check.dat, %dbgdir%\Au3Check.dat
copy Aut2Exe\Au3Check.exe, %dbgdir%\Au3Check.exe
copy upx\upx.exe, %dbgdir%\upx.exe
copy maPayloadScript\payloadTemplate.au3, %dbgdir%\payloadTemplate.txt
copy getDriveSerial\getDriveSerial.exe, %dbgdir%\getDriveSerial.exe
pause