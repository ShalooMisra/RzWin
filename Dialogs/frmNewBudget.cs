using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;

namespace RzInterfaceWin
{
    public partial class frmNewBudget : Form
    {
        //Public Variables
        public bool Canceled = false;
        public budget Budget;

        //Constructors
        public frmNewBudget()
        {
            InitializeComponent();
            udYear.Value = DateTime.Now.Year + 1;
        }
        //Private Functions
        private void Finish()
        {
            NewBudgetArgs Args = new NewBudgetArgs();            
            Args.Year = Convert.ToInt32(udYear.Value);
            Args.Name = "RZ" + Args.Year.ToString();
            Args.FromScratch = optScratch.Checked;
            Budget = budget.CreateNewBudget(RzWin.Context, Args);
            if (Budget == null)
                Canceled = true;
            Close();
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Canceled = true;
            Close();
        }
        private void cmdFinish_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}
