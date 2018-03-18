using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace masamangalternatibo {
    public partial class about : Form {
        public about() { InitializeComponent(); }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (MessageBox.Show("Open link: https://www.imagemagick.org/script/license.php", "Open link?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Process.Start("https://creativecommons.org/licenses/by-sa/3.0/");
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.codeproject.com/Articles/16178/IconLib-Icons-Unfolded-MultiIcon-and-Windows-Vista");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/tragenalpha/masamangalternatibo");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.dbad-license.org/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://tragenalpha.github.io");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.autoitscript.com/autoit3/docs/license.htm");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.autoitscript.com/autoit3/docs/license.htm");
        }

        private void about_Load(object sender, EventArgs e) {

        }
    }
}
