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
    public partial class frmQBAccountImportAssist : Form
    {
        //Public Variables
        public account TheAccount;

        //Contructors
        public frmQBAccountImportAssist()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(string acnt, string ref_num, double amnt, DateTime date)
        {
            txtAcnt.SetValue(acnt);
            txtRef.SetValue(ref_num);
            txtAmnt.SetValue(amnt);
            dtDate.SetValue(date);
            LoadAccounts();
        }
        //Private Functions
        private void LoadAccounts()
        {
            string build = "";
            RzWin.Context.TheSysRz.TheAccountLogic.InitAccounts(RzWin.Context);
            foreach (account a in RzWin.Context.TheSysRz.TheAccountLogic.GetAccounts(RzWin.Context, new AccountCriteria(AccountRetrieval.All)))
            {
                if (Tools.Strings.StrExt(build))
                    build += "|";
                build += account.GetAccountFullNameWithBullet(a);
            }            
            cboAcnt.SimpleList = build;
        }
        private void GetSelectedAccount()
        {
            TheAccount = null;
            string anct = cboAcnt.GetValue_String();
            if (!Tools.Strings.StrExt(anct))
                return;
            TheAccount = account.GetByFullName(RzWin.Context, account.GetAccountFullNameStripBullet(anct));
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            TheAccount = null;
            Close();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            GetSelectedAccount();
            Close();
        }
    }
}
