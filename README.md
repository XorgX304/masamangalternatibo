# <span style="color:white;">masamangAlternatibo</span>
<center><table style="border: none;"><tr><td>
    <img src="graphics\icon_ss.png"/>
</td>
<td>
    <span style="margin: 0;"><p style="font-size: 28px;"><b>masamangAlternatibo</b> (<span style="color:red;">alpha</span>)</p></span>
    <p style="margin-left:5%;margin-top:-5%;">Flash Drive Payload Generator Tool</p>
</td></tr></table><p style="font-size: 8px;">Read Me v1.0</p></center>

---

## Overview

## Author
<p>Developed by: TRAGENALPHA <img src="graphics\flare002.png" style="margin-bottom:-1%;"/>|<a href="https://tragenalpha.github.io">Site</a>|<a href="https://twitter.com/tragenalpha">@tragenalpha</a>|tragenalpha@protonmail.com</p>

## Credits, Built with, etc...
<ul>
    <li><a href="https://www.codeproject.com/Articles/16178/IconLib-Icons-Unfolded-MultiIcon-and-Windows-Vista">Icon Library</a> - Castor Tiu</li>
    <li><a href="https://www.autoitscript.com/">AutoIt Script Compiler</a> - Jonathan Bennett and the AutoIt Team</li>
    <li><a href="https://github.com/paomedia/small-n-flat">Small n Flat Icon Pack</a> - paomedia</li>
    <li><a href="https://upx.github.io">UPX</a> - Markus Oberhumer, Laszlo Molnar, John Reiser</li>
</ul>

## Software Requirements
<ul>
    <li>Microsoft .NET Framework 4.x</li>
</ul>

## License
Project is licensed under the <a href="https://www.dbad-license.org"><i>dbad</i></a> Public License

## Documentation
Most of the code contains comments and remarks specifying about its purpose and gives you information specified for it

<pre><i style="color: #57A64A;">
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
</i></pre>

## Setting Up
Run the batch script "_setupEnvironment.cmd", This will copy the required files to your "bin\Debug" folder. This files are already excluded in the .gitignore file.

## Deployment
Run the batch script "_generateRelease.cmd", This will copy all the files that are used to a new "Release\" folder

## Payload Script Template (Updating, Usage, etc...)
You can edit the Payload template in "maPayloadScript\payloadTemplate.au3" and update mA's current template by running the batch script "_updatePayloadTemplate.cmd"