﻿#define isdbg //NOTE: DO NOT FORGET TO UNDEFINE (comment out) THIS ON RELEASE.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Drawing.IconLib;
using System.Threading;
//using System.Runtime.InteropServices;

namespace masamangalternatibo {

    public partial class Form1 : Form {
        public Form1() { InitializeComponent(); }

        string version = "0.0.0a";
        int payloadMode = 0; // 0 = File payload // 1 = Shell Code payload // 2 = Load DLL to rundll32
        string[] payloadData = new string[5]; // Stores the data from the textbox so the user can switch modes without losing the last settings
        string[] payloadFile = new string[2]; // Stores the data of ofdPayload.FileName incase the user switches modes // 0 = File Payload // 1 = DLL Payload
        bool[] excomp = { false, false }; // Acts as a switch if the external components exist or not // 0 = Icon Library // 1 = UPX
        int overflowCount = 20;
        string apth = Application.StartupPath;

        private void Form1_Load(object sender, EventArgs e) {
            lblVersion.Text = "v" + version;
            dbgmsg("Starting from: " + apth);
            loadDrives();
            checkComponents();
            #if !(isdbg)
                dbgmsg("Setting up...");
                tbPayload.ReadOnly = true;
                tbSpoof.ReadOnly = true;
                using (about _form = new about()) {
                    dbgmsg("Showing about form...");
                    _form.ShowDialog();
                }
            #endif
            dbgmsg("mA Ready! // Hover an item for more information!");
            #if isdbg
            dbgmsg("mA is running in debugging mode!");
            #endif
        }

        #region [Console Commands]
        private void btnConsole_Click(object sender, EventArgs e) {
            string[] con = tbConsole.Text.Split(' ');
            switch ((con[0]).ToLower()) {

                case "showpayloadfile":
                    dbgmsg("payloadFile[0]=" + payloadFile[0]);
                    dbgmsg("payloadFile[1]=" + payloadFile[1]);
                    break;

                case "owo":
                    dbgmsg("OwO ~ what's this?");
                    break;

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

                default:
                    dbgmsg("Bad command! Available commands:\nsetdrive [driveletter]\nsetoverflowcount [integer]\nsetimagelocation [filepath]\nshowpayloadfile\noverflowdebugmsg\ncls\nexit\n");
                    break;
            }
            tbConsole.Text = "";
        }
        #endregion

        //Extract Icon Function - used to extract icons by utilizing the IconLib Library
        private void extractIcon(bool fromButton = false, string iconfile = "") {
            //fromButton supresses error if it wasn't the users' intention to extract an icon
            if (excomp[0] && iconfile != "") {
                dbgmsg("Extracting associated icon to bitmap...");
                (Icon.ExtractAssociatedIcon(iconfile).ToBitmap()).Save(apth + "\\_bmptmp.bmp");
                MultiIcon conico = new MultiIcon();
                conico.Add("iconinstance").CreateFrom(apth + "\\_bmptmp.bmp", IconOutputFormat.WinXP);
                conico.SelectedIndex = 0;
                conico.Save(apth + "\\$tmp.ico", MultiIconFormat.ICO);
                imgFileIcon.ImageLocation = "$tmp.ico";
                File.Delete(apth + "\\_bmptmp.bmp");
                dbgmsg("Temporary bitmap file deleted.");
            }
            else {
                if (fromButton) {
                    MessageBox.Show("No spoof file imported or Icon Library functions can't be utilized", "Error");
                }
                else {
                    dbgmsg("Error from un-intended extraction suppressed!");
                }
            }
        }

        //Trim Extension Function - Removes the file extension from a string
        private string trimext(string flname) {
            string[] aa = flname.Split('.');
            string tmp = "";
            for (int x = 0; x <= aa.Count() - 2; x++) {
                tmp += "." + aa[x];
            }
            return tmp;
        }

        //TODO: rework file checking. use recursion and arrays to check the files instead of separate ones
        //Check Component Function - Checks the required external components of mA
        #region Check Components
        private void checkComponents() {
            // TODO: Get proper host
            string dl1 = ""; //Link for the Compiler
            string dl2 = ""; //Link for the Library
            string dl3 = ""; //Link for the Compressor

            //Check for the Compiler
            dbgmsg("Checking for compiler...");
            if (!(File.Exists("compiler.exe"))) {
                if (MessageBox.Show("An important component of mA is missing!\n\nThe AutoIt compiler (compiler.exe) was not found, you cannot use mA with out the compiler as it needs to compile scripts to standalone executables.\n\nPressing Yes will download the compiler from this link\n" + dl1 + "\n\nThis will be downloaded in the background.", "Script compiler missing! // Download component \"compiler.exe\" (1.32mb)", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    dbgmsg("Downloading file...");
                    using (WebClient _wc = new WebClient()) {
                        _wc.DownloadFile(dl1, "compiler.exe");
                    }
                    dbgmsg("Download complete!");
                    MessageBox.Show("Download complete!", "Download component \"compiler.exe\" (1.32mb)");
                }
                else {
                    dbgmsg("Application cannot function without compiler... Exiting!");
                    using (about _form = new about()) { _form.Close(); }
                    Application.Exit();
                    return;
                }
            }
            else {
                dbgmsg("compiler.exe found.");
            }

            //Check for the Icon Library
            dbgmsg("Checking for IconLib...");
            if (!(File.Exists("IconLib.dll"))) {
                if (MessageBox.Show("An important component of mA is missing!\n\nThe IconLib (IconLib.dll) Library was not found, some functions that are used by this application relies on this library file such as handling Icon conversion.\n\nPressing Yes will download the Library from this link\n" + dl2 + "\n\nThis will be downloaded in the background.", "Library missing! // Download component \"IconLib.dll\" (56.5kb)", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    dbgmsg("Downloading file...");
                    using (WebClient _wc = new WebClient()) {
                        _wc.DownloadFile(dl2, "IconLib.dll");
                    }
                    dbgmsg("Download complete!");
                    MessageBox.Show("Download complete!", "Download component \"IconLib.dll\" (56.5kb)");
                    excomp[0] = true;
                }
                else {
                    excomp[0] = false;
                    dbgmsg("WARNING: IconLib.dll is missing, some functions won't work without it.");
                    return;
                }
            }
            else {
                excomp[0] = true;
                dbgmsg("IconLib.dll found.");
            }

            //Check for the Compressor
            dbgmsg("Checking for UPX...");
            if (!(File.Exists("upx.exe"))) {
                if (MessageBox.Show("An optional component of mA is missing!\n\nThe UPX Compressor (upx.exe) was not found, This component is used to compress executable files to lessen their file size and is also utilized by the compiler.\n\nPressing Yes will download the component from this link\n" + dl3 + "\n\nThis will be downloaded in the background.", "Compressor missing! // Download component \"upx.exe\" (356kb)", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    dbgmsg("Downloading file...");
                    using (WebClient _wc = new WebClient()) {
                        _wc.DownloadFile(dl2, "upx.exe");
                    }
                    dbgmsg("Download complete!");
                    MessageBox.Show("Download complete!", "Download component \"upx.exe\" (356kb)");
                    excomp[1] = true;
                }
                else {
                    excomp[1] = false;
                    dbgmsg("WARNING: upx.exe is missing, some functions won't work without it.");
                    return;
                }
            }
            else {
                excomp[1] = true;
                dbgmsg("upx.exe found.");
            }

        }
        #endregion

        //ghetto title bar management
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

        //Debug Message Function - Function to be utilized to output messages in the debug console prepend form
        private void dbgmsg(string a) {
            dbgRtb.Text = a + "\n" + dbgRtb.Text;

            if (a.Length >= 70) { //To prevent the debug label on overflowing beyond the tool strip container
                lblDbg.Text = a.Remove(70, a.Length - 70) + "...";
            }
            else {
                lblDbg.Text = a;
            }
        }

        private void loadDrives() {
            dbgmsg("Detecting drives...");
            drpDrives.Items.Clear();
            for (int i = 65; i <= 90; i++) {
                if (Directory.Exists(((char)i).ToString() + ":\\") && i != 67) {
                    drpDrives.Items.Add(((char)i).ToString() + ":\\");
                }
            }
            if (drpDrives.Items.Count != 0) { drpDrives.SelectedIndex = 0; }
            dbgmsg("Finished!");
        }

        private void btnSwitchMode_Click(object sender, EventArgs e) {
            payloadData[payloadMode] = tbPayload.Text; //Save the current payloadData to be displayed later
            payloadMode++;
            if (payloadMode == 3) { payloadMode = 0; }
            switch (payloadMode) {
                case 0: //Payload File Mode
                    ofdPayload.FileName = payloadFile[payloadMode];
                    btnSwitchMode.Text = "F";
                    btnBrowsePayload.Enabled = true;
                    tbPayload.ReadOnly = true;
                    lblPayload.Text = "Payload File:";
                    pnlFileOptGroup.Enabled = true;
                    ofdPayload.Filter = "All Files (*.*)|*.*";
                    break;

                case 1: //Inject Library Mode
                    ofdPayload.FileName = payloadFile[payloadMode];
                    btnSwitchMode.Text = "D";
                    btnBrowsePayload.Enabled = true;
                    tbPayload.ReadOnly = true;
                    lblPayload.Text = "DLL File:";
                    pnlFileOptGroup.Enabled = false;
                    ofdPayload.Filter = "DLL Files (*.dll)|*.dll";
                    break;

                case 2: //Shell Code Mode
                    btnSwitchMode.Text = "S";
                    btnBrowsePayload.Enabled = false;
                    tbPayload.ReadOnly = false;
                    lblPayload.Text = "Shell Code:";
                    pnlFileOptGroup.Enabled = false;
                    break;
            }
            tbPayload.Text = payloadData[payloadMode]; //Display the data of the currently selected payloadMode
        }

        private void btnRefreshDrives_Click(object sender, EventArgs e) {
            loadDrives();
        }

        private void btnSelf_Click(object sender, EventArgs e) {
            Process.Start("https://tragenalpha.github.io");
        }

        private void btnGitSauce_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/tragenalpha/masamangalternatibo");
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
                chkStreamConsole.Enabled = false;
                btnCommand.Enabled = false;
            }
        }

        private void btnClearImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            dbgmsg("Clearing image box...");
            imgFileIcon.Image = null;
        }

        private void btnBrowseImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ofdIcon.ShowDialog();
        }

        private void ofdIcon_FileOk(object sender, CancelEventArgs e) {
            dbgmsg("Copying as temporary file...");
            File.Copy(ofdIcon.FileName, "$tmp.ico");
            dbgmsg("Loading image...");
            imgFileIcon.ImageLocation = "$tmp.ico";
            dbgmsg("Imported:" + ofdIcon.FileName);
        }

        private void btnExtract_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            extractIcon(true, ofdSpoof.FileName);
        }

        private void btnMiniPad_Click(object sender, EventArgs e) {
            minipad _minipad = new minipad();
            _minipad.Show();
        }
    }
}
