using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RzInterfaceWin
{
    public partial class frmBudgetPercent : Form
    {
        //Public Variables
        public bool Canceled = false;
        public double Percent = 0;
        public bool Decrease = false;

        public frmBudgetPercent()
        {
            InitializeComponent();
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Canceled = true;
            Close();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            Percent = ctl_percent.GetValue_Double();
            Decrease = optDecrease.Checked;
            Close();
        }
    }
}
