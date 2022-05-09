using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;
using NewMethod;

namespace RzInterfaceWin
{
    public partial class frmEditBudgetAccount : Form
    {
        //Private Variables
        budget_account Account;

        //Constructors
        public frmEditBudgetAccount()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init(budget_account a)
        {
            Account = a;
            lblAccount.Text = account.GetAccountFullNameWithBullet(Account);
            NMWin.LoadFormValues(this, Account);
        }
        //Private Functions
        private void Save()
        {
            NMWin.GrabFormValues(this, Account);
            Account.Update(RzWin.Context);
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }
    }
}
