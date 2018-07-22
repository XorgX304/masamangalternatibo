using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace masamangalternatibo {
    public partial class about : Form {
        public about() { InitializeComponent(); }

        private void about_MouseMove(object sender, EventArgs e) {
            if (MouseButtons == MouseButtons.Left) {
                this.Location = new Point(MousePosition.X - 383, MousePosition.Y - 15);
            }
        }

        private void label1_MouseMove(object sender, EventArgs e) {
            about_MouseMove(null, e);
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/tragenalpha/masamangalternatibo");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.gnu.org/licenses/gpl-3.0.en.html");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://tragenalpha.github.io");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/paomedia/small-n-flat");
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/paomedia/small-n-flat/blob/master/LICENSE");
        }

        private void linkLabel6_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.autoitscript.com/autoit3/docs/license.htm");
        }

        private void linkLabel7_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.autoitscript.com/autoit3/docs/license.htm");
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://creativecommons.org/licenses/by-sa/3.0/");
        }

        private void linkLabel5_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.codeproject.com/Articles/16178/IconLib-Icons-Unfolded-MultiIcon-and-Windows-Vista");
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://upx.github.io");
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/upx/upx/blob/master/LICENSE");
        }
    }
}
