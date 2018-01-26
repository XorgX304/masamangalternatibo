using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace masamangalternatibo {
    public partial class about : Form {
        public about() { InitializeComponent(); }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (MessageBox.Show("Open link: https://www.imagemagick.org/script/license.php", "Open link?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Process.Start("https://www.imagemagick.org/script/license.php");
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.imagemagick.org/");
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
    }
}
