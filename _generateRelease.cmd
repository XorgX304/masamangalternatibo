::TODO: AUTO ZIP : https://stackoverflow.com/questions/20485419/batch-file-script-to-zip-files
@echo off
set /p ver=Version:
set rldr="Release_"%ver%
echo Creating Release (%rldr%) Directory...
md %rldr%

echo Copying Files...
copy masamangalternatibo\bin\Debug\IconLib.dll, %rldr%\IconLib.dll
copy upx\upx.exe, %rldr%\upx.exe
copy Aut2Exe\compiler.exe, %rldr%\compiler.exe
copy Aut2Exe\License.txt, %rldr%\_AutoIt_License.txt
copy Aut2Exe\Au3Check.dat, %rldr%\Au3Check.dat
copy Aut2Exe\Au3Check.exe, %rldr%\Au3Check.exe
copy masamangalternatibo\bin\Debug\masamangalternatibo.exe, %rldr%\mA.exe
copy LICENSE, %rldr%\_mA_license.txt
copy maPayloadScript\payloadTemplate.au3, %rldr%\payloadTemplate.txt
copy getDriveSerial\getDriveSerial.exe, %rldr%\getDriveSerial.exe
pause