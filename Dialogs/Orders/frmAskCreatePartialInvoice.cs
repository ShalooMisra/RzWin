using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RzInterfaceWin.Dialogs
{
    public partial class frmAskCreatePartial : Form
    {
        //Public Variables
        public bool Create = false;

        //Constructors
        public frmAskCreatePartial()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static bool AskCreatePartial()
        {
            frmAskCreatePartial f = new frmAskCreatePartial();
            f.ShowDialog();
            return f.Create;
        }
        //Buttons
        private void cmdNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cmdYes_Click(object sender, EventArgs e)
        {
            Create = true;
            Close();
        }
    }
}
