
Global $drive = StringLeft(@ScriptDir, 3)
Global $dscheck = false
Global $driveserial = "0000000000"

If $drive = "C:\" or ($dscheck = true and (($driveserial = DriveGetSerial($drive)) = False)) Then
    InputBox("", "DISPOSE")
Else
    InputBox("", "ITS OK")
EndIf