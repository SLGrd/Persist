using System;
using System.Windows.Forms;
using static Code.Glb;
using static Code.Utils;

namespace mdiPersist
{
    public partial class FrmEx2 : Form
    {
        public FrmEx2()
        {
            InitializeComponent();
        }

        private void FrmEx2_Load(object sender, EventArgs e)
        {
            GetFormPosition(this);
            GetControlValue(U.UserName, this, txtBox, "Text");
        }

        private void FrmEx2_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveControlValue(U.UserName, this, txtBox, "Text");
            SaveFormPosition(this);
        }
    }
}
