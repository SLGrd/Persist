using System;
using System.Windows.Forms;
using static Code.Glb;
using static Code.Utils;

namespace mdiPersist
{
    public partial class FrmEx1 : Form
    {
        public FrmEx1()
        {
            InitializeComponent();
        }
 
        private void FrmEx1_Load(object sender, EventArgs e)
        {
            GetFormPosition(this);
            GetControlValue(U.UserName, this, txtBox, "Text");
        }

        private void FrmEx1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveControlValue(U.UserName, this, txtBox, "Text");
            SaveFormPosition(this);
        }
    }
}
