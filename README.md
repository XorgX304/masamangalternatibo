<!-- READ ME v1.6.2 -->
# masamangAlternatibo - Flash Drive Payload Generator Tool
<table><tr><td>
    <img src="graphics\icon_ss.png"/>
</td><td>
    <font size="5px"><b>masamangAlternatibo</b> </font>(<font color="red">0.12.0-alpha</font>)</font>
    <br>mA Payload (<font color="red">0.9.0-alpha</font>)
</td></tr></table>
<a href="https://github.com/tragenalpha/masamangalternatibo/releases">Releases</a>

---

<img src="graphics\ss1.png"/>
<i>masamangAlternatibo (Alpha) UI (Screenshot is updated per UI change.)</i>

## Overview
<i>For specific information about the parts of the UI, Tool tips are implented so you can just hover them.</i>

<b>Description</b><br>
mA (masamangAlternatibo) is a tool for generating and delivering payloads through flash drives or any form of physical file transfering medium. This tool is mostly aimed at social engineering by disguising and imitating a "Spoofed" file's appearance, in which a payload can be binded to. mA Payloads are made from generating and compiling <a href="https://www.autoitscript.com/">AutoIt</a> Scripts.

<b> Payloads Modes</b><br>
- File Payload [F] - A file payload that gets executed.
- DLL Payload [D] - A DLL file payload that gets executed by utilizing rundll32.exe.
- Shell Code Payload [S] - A Shell command that is executed.


<br><b>File Name Spoofing</b>
- Overflow - Places an excessive amount of invincible characters between the fake file extension and the real one to push the real extension name off the file name limit
- RtLO (Right to Left Override) - Utilizes the special RtLO character to reverse the fake file extension and the real one


<br><b>Features and Key Functions</b>
- Automatically extract the Spoofed File's icon.
- A Write Mode that allows you to do adjustments to the script before building the payload.
- An option to drop and execute the payload in the target's drive to circumvent AV's Flash drive execution block and scan.
- A Miniature Notepad for pre-build script editing and shell command coding.
- Simplicity.
- Alternate way of dumping. <i>(Only for console applications)</i>
- Payload Auto Dispose when copied off the flash drive / carrier.

<br><b>Update Log:</b>
- finished version check
- finished payload syntax checking
- read me v1.6.2
- fixed documentation
- added pre-compile check for existing payload
- argument supply for dll check
- removed array handler for the script parser
- fixed shell command being blank when changing modes
- reworked minipad

<br><b>To do:</b>
- Implement <a href="https://github.com/tragenalpha/tricksofthetrade">TotT</a>'s Payload Encryption.
- Workround sand boxes
- Pre-compress payload executable
- Find a better way of extracting associated icons
- Find a better way of obtaining driver serials
- [✔] Implement Script Checking and Validation (Au3Check.exe)
- [✔] Create option to bind mA's Payload to only trigger in a specific flash drive/carrier. (Drive Serial Check)
- [✔] Update Checks
- [✔] Update Template Version
- Save Modified Script in memory incase of re-editing
- Detect and adapt quotations

## Author
<p>Developed by: TRAGENALPHA <img src="graphics\flare002.png" style="margin-bottom:-1%;"/> | <a href="https://tragenalpha.github.io">Site</a> | <a href="https://twitter.com/tragenalpha">@tragenalpha</a> | tragenalpha@protonmail.com</p>

## Credits, Built with, etc...

- <a href="https://www.codeproject.com/Articles/16178/IconLib-Icons-Unfolded-MultiIcon-and-Windows-Vista">Icon Library</a> - Castor Tiu
- <a href="https://www.autoitscript.com/">AutoIt</a> - Jonathan Bennett and the AutoIt Team
- <a href="https://github.com/paomedia/small-n-flat">Small n Flat Icon Pack</a> - paomedia
- <a href="https://upx.github.io">UPX</a> - Markus Oberhumer, Laszlo Molnar, John Reiser

## Software Dependency

- Microsoft .NET Framework 4.x

## License

Project is licensed under the <a href="https://www.dbad-license.org"><i>dbad</i></a> Public License

## Documentation

Most of the code contains comments and remarks specifying about it's purpose and gives you information specified for it.

<!--<pre><font color="#57A64A"><i>-->
```c
/*
 * Function Name - Function Description
 * -------------------------------------
 * function (
 *      parameters description (value type)
 * )
 * -------------------------------------
 * Remarks
 * Returns: return value
 */

 or

 /*
  * Code, Variable, Snippet, etc... - Description
  * ----------------------------------------------
  * Remarks
  */
```

<!--</i></font></pre>-->

## Setting Up

1. Compile a new Get Serial Drive Component by running the batch script "compile_gds.cmd" in the "getDriveSerial\" Folder.
2. Run the batch script "_setupEnvironment.cmd", This will copy the required files to your "bin\Debug" folder. This files are already excluded in the .gitignore file.

## Deployment

Run the batch script "_generateRelease.cmd", This will copy all the files that are used to a new "Release\" folder.


## Payload Script Template (Updating, Usage, etc...)

- Stable updates on the Payload template are committed to Pastebin.

- You can edit the Payload template in "maPayloadScript\payloadTemplate.au3" and update mA's current template by running the batch script "_updatePayloadTemplate.cmd"