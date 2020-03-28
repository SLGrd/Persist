using System;
using System.Drawing;
using System.Windows.Forms;
using mdiPersist.Properties;
using static Code.Utils;
using static Code.Glb;

namespace mdiPersist
{
    public partial class MdiMain : Form
    {
        MenuStrip mainMnuStrip;

        public MdiMain()
        {
            InitializeComponent();
            //  Muda background de MDI
            MdiClient chld = null;
            foreach (Control ctrl in this.Controls)
            {
                try {
                    chld = (MdiClient)ctrl;
                    chld.BackColor = System.Drawing.Color.AliceBlue;
                } catch { }
            }

            //  Inicializa Barra de ferramentas
            ToolStripConfig();
            //  Separator
            Label Separator = new Label() { Dock = DockStyle.Top, Height = 1, BackColor = Color.White }; this.Controls.Add(Separator);
            //  Incializa Menu
            MenuStripConfig();
            // Set ser name and password
            U.UserName = "Sylvio";
            U.Password = "abc";
        }

        private void MdiMain_Load(object sender, EventArgs e) { }

        private void ToolStripConfig()
        {
            // Create a new ToolStrip control.
            ToolStrip tlsAction = new ToolStrip
            {
                Margin = new Padding(0, 5, 0, 1),
                Dock = DockStyle.Top,
                GripMargin = new Padding(5, 8, 8, 3),
                BackColor = Color.Silver
            };
            this.Controls.Add(tlsAction);  // Add the ToolStrip control to the Form Controls collection.

            tlsAction.Items.Clear();

            ToolStripButton tstNewRecord = new ToolStripButton()
            {
                Image = Resources.newRecord32,
                BackColor = Color.Silver,
                ToolTipText = "Form1 - Função A"
            };
            tstNewRecord.Click += (object sender, EventArgs e) =>     // Funcao aionada pelo CLICK no button  
            {
                if (!FormIsLoaded(typeof(FrmEx1)))
                {
                    Form FrmEx1 = new FrmEx1() { MdiParent = this };
                    FrmEx1.Show();
                }
            };
            tlsAction.Items.Add(tstNewRecord);

            ToolStripButton tstRefresh = new ToolStripButton
            {
                Image = Resources.undo32,
                ToolTipText = "Form2 - Função B"
            };
            tstRefresh.Click += (object sender, EventArgs e) =>     // Funcao aionada pelo CLICK no button  
            {
                if (!FormIsLoaded(typeof(FrmEx2)))
                {
                    Form FrmEx2 = new FrmEx2() { MdiParent = this };
                    FrmEx2.Show();
                }
            };
            tlsAction.Items.Add(tstRefresh);

            tlsAction.Items.Add(new ToolStripSeparator { AutoSize = false, Width = 6 });

            ToolStripButton tstDelete = new ToolStripButton
            {
                Image = Resources.delete32,
                ToolTipText = "Form3 - Função C"
            };
            tstDelete.Click += (object sender, EventArgs e) =>     // Funcao aionada pelo CLICK no button  
            {
                if (!FormIsLoaded(typeof(FrmEx3)))
                {
                    Form FrmEx3 = new FrmEx3() { MdiParent = this };
                    FrmEx3.Show();
                }
            };
            tlsAction.Items.Add(tstDelete);

            tlsAction.Items.Add(new ToolStripSeparator { AutoSize = false, Height = 32, Width = 12 });

            ToolStripLabel tslSearch = new ToolStripLabel
            {
                Font = new Font("Arial", 11),
                ForeColor = Color.Navy,
                Text = "Search"
            };
            tlsAction.Items.Add(tslSearch);

            tlsAction.Items.Add(new ToolStripSeparator { AutoSize = false, Width = 12 });

            ToolStripMenuItem tstDropMnuItemOptionA = new ToolStripMenuItem     //* opcao A 
            {
                Checked = true,
                Text = "Barra de Menu"
            };
            tstDropMnuItemOptionA.Click += (object sender, EventArgs e) =>
            {
                mainMnuStrip.Visible = !mainMnuStrip.Visible;
                tstDropMnuItemOptionA.Checked = !tstDropMnuItemOptionA.Checked;
            };

            ToolStripMenuItem tstDropMnuItemOptionB = new ToolStripMenuItem     //* opcao B
            {
                Image = Resources.delete32,
                Text = "OptionDrop B"
            };
            //tstDropMnuItemOptionB.Click += TstDropMnuItemOption_Click;            //  Define qual a funcao que vai tratar o evento CLICK

            ToolStripDropDownButton tstDropBtn = new ToolStripDropDownButton        //* Instancia o Drop Down Button
            {
                Image = Resources.newRecord32,
                ForeColor = Color.Navy,
                Text = "Drop"
            };
            //tstDropBtn.Click += TstDropBtn_Click;
            tstDropBtn.DropDownItems.Add(tstDropMnuItemOptionA);                    //* Add to DropDownItems collection
            tstDropBtn.DropDownItems.Add(tstDropMnuItemOptionB);                    //* Add to DropDownItems collection
            tlsAction.Items.Add(tstDropBtn);                                        //* Add DDB to ToolStrip  


            ToolStripMenuItem tstSplitMnuItemOptionA = new ToolStripMenuItem
            {
                Image = Resources.check32,
                Text = "Cascade Forms"
            };
            tstSplitMnuItemOptionA.Click += (object sender, EventArgs e) =>
            {
                this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
            };

            ToolStripMenuItem tstSplitMnuItemOptionB = new ToolStripMenuItem
            {
                Image = Resources.undo32,
                Text = "Tile Vertical"
            };
            tstSplitMnuItemOptionB.Click += (object sender, EventArgs e) =>
            {
                this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
            };

            ToolStripMenuItem tstSplitMnuItemOptionC = new ToolStripMenuItem
            {
                Image = Resources.newRecord32,
                Text = "Tile Horizontal"
            };
            tstSplitMnuItemOptionC.Click += (object sender, EventArgs e) =>
            {
                this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
            };

            ToolStripMenuItem tstSplitMnuItemOptionD = new ToolStripMenuItem
            {
                Image = Resources.search32,
                Text = "Arrange Icons"
            };
            tstSplitMnuItemOptionD.Click += (object sender, EventArgs e) =>
            {
                this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
            };

            ToolStripSplitButton tstSplitBtn = new ToolStripSplitButton
            {
                Image = Resources.newRecord32,
                ForeColor = Color.Navy,
                Text = "Split"
            };
            //tstSplitBtn.Click += TstSplitBtn_Click;

            tstSplitBtn.DropDownItems.Add(tstSplitMnuItemOptionA);
            tstSplitBtn.DropDownItems.Add(tstSplitMnuItemOptionB);
            tstSplitBtn.DropDownItems.Add(tstSplitMnuItemOptionC);
            tstSplitBtn.DropDownItems.Add(tstSplitMnuItemOptionD);
            tlsAction.Items.Add(tstSplitBtn);

            // -------------------------------- Split Button ( SpltBt) - Final  ------------------------------------------------------
        }

        private void MenuStripConfig()
        {
            //  Instantiates menu strip
            mainMnuStrip = new MenuStrip()
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                GripStyle = ToolStripGripStyle.Visible,
                GripMargin = new Padding(2, 1, 1, 3),
                Height = 30,
                LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow,
                Font = new Font("Tahoma", 12),
                Margin = new Padding(0, 0, 5, 0),
                ForeColor = Color.Navy,
                BackColor = Color.Silver
            };

            this.Controls.Add(mainMnuStrip);

            //  Barra superior Grupo 1 - FIL

            ToolStripMenuItem mainItmFil = new ToolStripMenuItem()
            {
                Text = "Files   ",
                DisplayStyle = ToolStripItemDisplayStyle.Text
            };
            mainMnuStrip.Items.Add(mainItmFil);

            ToolStripSeparator subFilSp0 = new ToolStripSeparator()
            {
                ForeColor = Color.Navy,
                Margin = new Padding(0, 12, 0, 2) // Margins sentido do relogio : esquerda , topo, direita e fundo
            };

            ToolStripMenuItem subFilForm1 = new ToolStripMenuItem()
            {
                Text = "Form Exemplo 1"
            };
            subFilForm1.Click += (object sender, EventArgs e) =>     // Funcao aionada pelo CLICK no button  
            {
                if (!FormIsLoaded(typeof(FrmEx1)))
                {
                    Form FrmEx1 = new FrmEx1() { MdiParent = this };
                    FrmEx1.Show();
                }
            };

            ToolStripMenuItem subFilForm2 = new ToolStripMenuItem()
            {
                Text = "Form Exemplo 2"
            };
            subFilForm2.Click += (object sender, EventArgs e) =>     // Funcao aionada pelo CLICK no button  
            {
                if (!FormIsLoaded(typeof(FrmEx2)))
                {
                    Form FrmEx2 = new FrmEx2() { MdiParent = this };
                    FrmEx2.Show();
                }
            };

            ToolStripMenuItem subFilForm3 = new ToolStripMenuItem()
            {
                Text = "Form Exemplo 3"
            };
            subFilForm3.Click += (object sender, EventArgs e) =>     // Funcao aionada pelo CLICK no button  
            {
                if (!FormIsLoaded(typeof(FrmEx3)))
                {
                    Form FrmEx3 = new FrmEx3() { MdiParent = this };
                    FrmEx3.Show();
                }
            };

            ToolStripSeparator subFilSp1 = new ToolStripSeparator()
            {
                Height = 3,
                ForeColor = Color.Navy,
                Margin = new Padding(0, 2, 0, 8)
            };

            ToolStripMenuItem subFilExit = new ToolStripMenuItem()
            {
                Text = "Exit"
            };
            subFilExit.Click += (object sender, EventArgs e) =>     // Funcao aionada pelo CLICK no button  
            {
                Application.Exit();
            };

            //  Adiciona os sub itens de menu ao parent item
            mainItmFil.DropDownItems.Add(subFilSp0);
            mainItmFil.DropDownItems.Add(subFilForm1);
            mainItmFil.DropDownItems.Add(subFilForm2);
            mainItmFil.DropDownItems.Add(subFilForm3);
            mainItmFil.DropDownItems.Add(subFilForm3);
            mainItmFil.DropDownItems.Add(subFilSp1);
            mainItmFil.DropDownItems.Add(subFilExit);

            //  Barra Superior Grupo 2 - WIN

            ToolStripMenuItem mainItmWin = new ToolStripMenuItem()
            {
                Text = "Windows",
            };
            mainMnuStrip.Items.Add(mainItmWin);

            ToolStripSeparator subWinSp0 = new ToolStripSeparator()
            {
                ForeColor = Color.Navy,
                Margin = new Padding(0, 12, 0, 2) // Margins sentido do relogio : esquerda , topo, direita e fundo
            };

            ToolStripMenuItem subWinForm1 = new ToolStripMenuItem()
            {
                Text = "New Window",
            };
            subWinForm1.Click += (object sender, EventArgs e) =>
            {
                if (!FormIsLoaded(typeof(FrmEx1)))
                {
                    Form FrmEx1 = new FrmEx1() { MdiParent = this };
                    FrmEx1.Show();
                }
            };

            ToolStripComboBox subWinCombo = new ToolStripComboBox()
            {
                Text = "Selecione o Form",
                Font = new Font(Font.FontFamily, Font.Size + 2)
            };
            subWinCombo.Items.AddRange(new string[] { "Form1", "Form2", "Form3" });
            subWinCombo.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                ToolStripComboBox c = (ToolStripComboBox)sender;

                switch (subWinCombo.Text)
                {
                    case "Form1":
                        if (!FormIsLoaded(typeof(FrmEx1)))
                        {
                            Form FrmEx1 = new FrmEx1() { MdiParent = this };
                            FrmEx1.Show();
                        };
                        break;
                    case "Form2":
                        if (!FormIsLoaded(typeof(FrmEx2)))
                        {
                            Form FrmEx2 = new FrmEx2() { MdiParent = this };
                            FrmEx2.Show();
                        };
                        break;
                    case "Form3":
                        if (!FormIsLoaded(typeof(FrmEx3)))
                        {
                            Form FrmEx3 = new FrmEx3() { MdiParent = this };
                            FrmEx3.Show();
                        };
                        break;
                }
                subWinCombo.DroppedDown = false;
                mainItmWin.DropDown.Close();
            };

            mainItmWin.DropDownItems.Add(subWinForm1);
            mainItmWin.DropDownItems.Add(subWinCombo);
        }

        private bool FormIsLoaded(Type f)   // O MDI Form esta carregado ?
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == f)
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return true;
                }
            }
            return false;
        }

        private void MDIMain_Load(object sender, EventArgs e) { }
    }
}