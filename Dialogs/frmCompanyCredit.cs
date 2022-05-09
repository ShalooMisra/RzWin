using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Rz5;

namespace Rz5
{
    public partial class frmCompanyCredit : Form
    {
        //Private Variables
        private ContextNM TheContext;
        private companycredit TheCredit;
        private ordhed TheOrder;
        private string TheCreditType;



        //Constructors
        public frmCompanyCredit()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(ContextNM x, companycredit c, ordhed o)
        {
            TheContext = x;
            TheCredit = c;
            TheOrder = o;
            TheCreditType = c.GetCreditType(o);
            if (TheCreditType == null)
                throw new Exception("Could not determine company credit 'Type', please notify IT.");
            ctl_credit_name.LoadList("CompanyCredits");
            LoadCredit();
        }




        //Private Functions
        private void LoadCredit()
        {
            if (TheCredit == null)
                return;
            ctl_credit_name.SetValue(TheCredit.description);
            ctl_credit_amount.SetValue(TheCredit.creditamount);
            ctl_internal_comment.SetValue(TheCredit.internalcomment);

        }
        private void Add()
        {
            if (TheCreditType == null)
                return;

            if (TheCredit == null)
                TheCredit = new companycredit();
            TheCredit.credit_type = TheCreditType;
            TheCredit.description = ctl_credit_name.GetValue_String();
            TheCredit.creditamount = ctl_credit_amount.GetValue_Double();
            TheCredit.internalcomment = ctl_internal_comment.GetValue_String();
            TheCredit.credit_type = TheCreditType;
            if (!Tools.Strings.StrExt(TheCredit.unique_id))
                TheCredit.Insert(RzWin.Context);
            else
                TheCredit.Update(RzWin.Context);
            TheOrder.Update(RzWin.Context);

        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Add();
            Close();
        }             
    }
}
