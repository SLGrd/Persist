using System;
using System.Windows.Forms;
using static Code.Glb;
using static Code.Utils;

namespace mdiPersist
{
    public partial class FrmEx3 : Form
    {
        public FrmEx3()
        {
            InitializeComponent();
        }

        private void FrmEx3_Load(object sender, EventArgs e)
        {
            GetFormPosition(this);
            GetControlValue(U.UserName, this, txtBox, "Text");
        }

        private void FrmEx3_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveControlValue(U.UserName, this, txtBox, "Text");
            SaveFormPosition(this);
        }
    }
}