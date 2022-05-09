using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rz5
{
    public partial class frmChooseCreditCharge : Form
    {
        public String SelectedChoice = "";

        public frmChooseCreditCharge()
        {
            InitializeComponent();
        }
        //Buttons
        private void cmd6_Click(object sender, EventArgs e)
        {
            SelectedChoice = "6";
            Close();
        }
        private void cmd3_Click(object sender, EventArgs e)
        {
            SelectedChoice = "3";
            Close();
        }
        private void cmdWaive_Click(object sender, EventArgs e)
        {
            SelectedChoice = "";
            Close();
        }
    }
}