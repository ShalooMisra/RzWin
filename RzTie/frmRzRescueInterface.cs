using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tie;

namespace Rz5
{
    public partial class frmRzRescueInterface : Form
    {
        //Constructors
        public frmRzRescueInterface()
        {
            InitializeComponent();
        }
        //Private Functions
        private void RunBackUp()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "XML Files (*.xml)|*.xml";
            f.ShowDialog();
            if (!Tools.Strings.StrExt(f.FileName))
                return;
            VaultManager v = new VaultManager(f.FileName);
            v.Start();
            v.Do();
        }
        //Buttons
        private void cmdBackUp_Click(object sender, EventArgs e)
        {
            RunBackUp();
        }
    }
}
