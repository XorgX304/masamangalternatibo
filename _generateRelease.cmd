@echo off

echo Creating Release Directory...
md Release

echo Copying Files...
copy masamangalternatibo\bin\Debug\IconLib.dll, Release\IconLib.dll
copy Aut2Exe\compiler.exe, Release\compiler.exe
copy upx\upx.exe, Release\upx.exe
copy Aut2Exe\License.txt, Release\_AutoIt_License.txt
copy masamangalternatibo\bin\Debug\masamangalternatibo.exe, Release\mA.exe
copy license.txt, Release\_mA_license.txt
copy maPayloadScript\payloadTemplate.au3, Release\payloadTemplate.txt
pause