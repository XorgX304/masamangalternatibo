#NoTrayIcon
If $Cmdline[0] = 1 Then
    ConsoleWrite(DriveGetSerial($Cmdline[1]))
Else
    ConsoleWrite("error")
EndIf
Exit(0)