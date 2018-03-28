<!-- READ ME v1.2 -->
# <span style="color:white;">masamangAlternatibo</span>
<table><tr><td>
    <img src="graphics\icon_ss.png"/>
</td>
<td>
    <font size="5px"><b>masamangAlternatibo</b> </font>(<font color="red">alpha</font>)</font>
    <br><font style="margin-left:5%;margin-top:-5%;">Flash Drive Payload Generator Tool</font>
</td></tr></table>


---

<img src="graphics\ss1.png"/>
<i>masamangAlternatibo (Alpha) UI</i>

## Overview
<i>For specific information about the parts of the UI, Tool tips are implented so you can just hover them.</i>

<b>Description</b><br>
mA (masamangAlternatibo) is a tool for generating and delivering payloads through flash drives or any form of physical file transfering medium. This tool is mostly aimed at social engineering by disguising and imitating a "Spoofed" file's appearance, in which a payload can be binded to. mA Payloads are made from generating and compiling <a href="https://www.autoitscript.com/">AutoIt</a> Scripts.

<b> Payloads Modes</b><br>
<li>File Payload [F] - A file payload that gets executed</li>
<li>DLL Payload [D] - A DLL file payload that gets executed by utilizing rundll32.exe</li>
<li>Shell Code Payload [S] - A Shell command that is executed.</li>

<br><b>File Name Spoofing</b>
<li>Overflow - Places an excessive amount of invincible unicode characters between the fake file extension and the real one to push the real extension name off the file name</li>
<li>RtLO (Right to Left Override) - Utilizes the special RtLO character to reverse the fake file extension and the real one</li>

<br><b>Features and Key Functions</b>
<li>Automatically extract the Spoofed File's icon.</li>
<li>A Write Mode that allows you to do adjustments to the script before building the payload.</li>
<li>An option to drop and execute the payload in the target's drive to circumvent AV's Flash drive execution block and scan.</li>
<li>A Miniature Notepad for pre-build script editing and shell command coding.</li>
<li>Simplicity.</li>
<li>Alternate way of dumping. <i>(Only for console applications)</i></li>
<li>Payload Auto Dispose when copied off the carrier.</li>

<br><b> Todo: </b>
<li>Implement <a href="https://github.com/tragenalpha/tricksofthetrade">TotT</a>'s Payload Encryption</li>
<li>Use a flash drive management library</li>
<li>Create option to bind mA's Payload to only trigger in a specific flash drive/carrier</li>
<li>Implement Flash drive malware circumvention to avoid directory/file errors</li>

## Author
<p>Developed by: TRAGENALPHA <img src="graphics\flare002.png" style="margin-bottom:-1%;"/> | <a href="https://tragenalpha.github.io">Site</a> | <a href="https://twitter.com/tragenalpha">@tragenalpha</a> | tragenalpha@protonmail.com</p>

## Credits, Built with, etc...

<ul>
    <li><a href="https://www.codeproject.com/Articles/16178/IconLib-Icons-Unfolded-MultiIcon-and-Windows-Vista">Icon Library</a> - Castor Tiu</li>
    <li><a href="https://www.autoitscript.com/">AutoIt Script Compiler</a> - Jonathan Bennett and the AutoIt Team</li>
    <li><a href="https://github.com/paomedia/small-n-flat">Small n Flat Icon Pack</a> - paomedia</li>
    <li><a href="https://upx.github.io">UPX</a> - Markus Oberhumer, Laszlo Molnar, John Reiser</li>
</ul>

## Software Dependency

<ul>
    <li>Microsoft .NET Framework 4.x</li>
</ul>

## License

Project is licensed under the <a href="https://www.dbad-license.org"><i>dbad</i></a> Public License

## Documentation

Most of the code contains comments and remarks specifying about it's purpose and gives you information specified for it.

<pre><font color="#57A64A"><i>
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
</i></font></pre>

## Setting Up

Run the batch script "_setupEnvironment.cmd", This will copy the required files to your "bin\Debug" folder. This files are already excluded in the .gitignore file.

## Deployment

Run the batch script "_generateRelease.cmd", This will copy all the files that are used to a new "Release\" folder

## Payload Script Template (Updating, Usage, etc...)

You can edit the Payload template in "maPayloadScript\payloadTemplate.au3" and update mA's current template by running the batch script "_updatePayloadTemplate.cmd"