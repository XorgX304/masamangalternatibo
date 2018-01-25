#define isdbg //NOTE: DO NOT FORGET TO UNDEFINE (comment out) THIS ON RELEASE.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace masamangalternatibo {

    public partial class Form1 : Form {
        public Form1() { InitializeComponent(); }

        string version = "1.0";
        bool payloadMode = true; // true = File payload // false = Shell Code payload
        bool componentImageMagick = false;
        string lastPayloadContainer;

        private void Form1_Load(object sender, EventArgs e) {
            lblVersion.Text = "v" + version;
            loadDrives();
            checkComponents();
            dbgmsg("mA Ready! // Hover an item for more information!");
        }

        

        private string trimext(string flname) {
            string[] aa = flname.Split('.');
            string tmp = "";
            for (int x = 0; x <= aa.Count() - 2; x++) {
                tmp += "." + aa[x];
            }
            return tmp;
        }

        private void checkComponents() {
            #region [Component: Image Magick]
            dbgmsg("Checking for Image Magick...");
            if (!(File.Exists("convert.exe"))) {
                if (MessageBox.Show("This component allows a feature that automatically extracts icons to bitmap then converts it to an acceptable quality icon. This is due to GDI+ unable to directly save an extracted icon with atleast redeeming quality.\n\nPressing No will make mA use the default executable icon; Alternatively you can add a custom icon.\n\nThis will download the file in the background.\n\nDL From: https://github.com/tragenalpha/masamangalternatibo/raw/master/ImageMagick/convert.exe", "Download component \"ImageMagick\" (13.8mb)", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    dbgmsg("Downloading file...");
                    using (WebClient wc = new WebClient()) {
                        wc.DownloadFile("https://github.com/tragenalpha/masamangalternatibo/raw/master/ImageMagick/convert.exe", "convert.exe");
                    }
                    dbgmsg("Download complete!");
                    componentImageMagick = true;
                    MessageBox.Show("Download Complete!", "Download component \"ImageMagick\" (13.8mb)");
                }
                else {
                    componentImageMagick = false;
                    dbgmsg("No Image magick!");
                }
            }
            else {
                dbgmsg("Image Magick Found!");
                componentImageMagick = true;
            }
            dbgmsg("bool componentImageMagick value=" + componentImageMagick.ToString());
            dbgmsg("Component check finished!");
            #endregion
        }

        private void dbgmsg(string a) {
            lblDbg.Text = a;
            dbgRtb.Text = a + "\n" + dbgRtb.Text;
        }

        //ghetto title bar management
        private void titlebar_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                this.Location = new Point((MousePosition.X - (titlebar.Size.Width / 2)), (MousePosition.Y - (titlebar.Size.Height / 2)));
            }
        }
        private void label4_MouseMove(object sender, MouseEventArgs e) { titlebar_MouseMove(null, e); }
        private void label1_MouseMove(object sender, MouseEventArgs e) { titlebar_MouseMove(null, e); }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void loadDrives() {
            dbgmsg("Detecting drives...");
            drpDrives.Items.Clear();
            for (int i = 65; i <= 90; i++) {
                if (Directory.Exists(((char)i).ToString() + ":\\")) {
                    drpDrives.Items.Add(((char)i).ToString() + ":\\");
                }
            }
            drpDrives.SelectedIndex = 0;
            dbgmsg("Finished!");
        }

        private void btnSwitchMode_Click(object sender, EventArgs e) {
            string tmpStore;
            if (payloadMode) {
                payloadMode = false;
                btnSwitchMode.Text = "S";
                btnBrowsePayload.Enabled = false;
                tbPayload.ReadOnly = false;
                lblPayload.Text = "Shell Code:";
                tmpStore = lastPayloadContainer;
                lastPayloadContainer = tbPayload.Text;
                tbPayload.Text = tmpStore;
                pnlFileOptGroup.Enabled = false;
            }
            else {
                payloadMode = true;
                btnSwitchMode.Text = "P";
                btnBrowsePayload.Enabled = true;
                tbPayload.ReadOnly = true;
                lblPayload.Text = "Payload File:";
                tmpStore = lastPayloadContainer;
                lastPayloadContainer = tbPayload.Text;
                tbPayload.Text = tmpStore;
                pnlFileOptGroup.Enabled = true;
            }
        }

        private void btnRefreshDrives_Click(object sender, EventArgs e) {
            loadDrives();
        }

        private void imgCharacter_Click(object sender, EventArgs e) {
            #if isdbg
                //General Debug section for code testing.
                dbgmsg("rorf!");
            #endif
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
        }

        private void ofdSpoof_FileOk(object sender, CancelEventArgs e) {
            tbSpoof.Text = ofdSpoof.SafeFileName;
            dbgmsg("Extracting associated icon to bitmap...");
            Image extractedicon = Icon.ExtractAssociatedIcon(ofdSpoof.FileName).ToBitmap();
            dbgmsg("Saving as $tmp.bmp...");
            extractedicon.Save("$tmp.bmp");
            imgFileIcon.Image = extractedicon;
        }
    }
}
