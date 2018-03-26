@echo off
echo Updating payload template...
del masamangalternatibo\bin\Debug\payloadTemplate.txt
copy maPayloadScript\payloadTemplate.au3, masamangalternatibo\bin\Debug\payloadTemplate.txt
echo Done!
pause