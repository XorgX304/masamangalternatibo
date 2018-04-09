using System.Windows.Forms;

namespace masamangalternatibo {
    public partial class minipad : Form {
        public minipad() {
            InitializeComponent();
        }

        public bool _modifyscript = false;
        public string _newscript = "";

        private void btnCompileScript_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            _modifyscript = true;
            _newscript = mprtb.Text;
            this.Close();
        }
    }
}
