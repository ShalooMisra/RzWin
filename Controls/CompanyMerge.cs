using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class CompanyMerge : UserControl
    {
        public delegate void AcceptHandler(Object source, company c);

        public event AcceptHandler Accept;

        public company CurrentCompany;
        public CompanyMerge()
        {
            InitializeComponent();
        }

        public void CompleteLoad(company c)
        {
            try
            {
                CurrentCompany = c;
                gb.Text = c.companyname;

                NMWin.LoadFormValues(this, CurrentCompany);
            }
            catch (Exception)
            { }
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            RzWin.Context.Show(CurrentCompany);
        }

        private void cmdIgnore_Click(object sender, EventArgs e)
        {
            CurrentCompany = null;
            this.Visible = false;
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            if (Accept != null)
                Accept(this, CurrentCompany);
        }

        public void CompleteSave()
        {
            NMWin.GrabFormValues(this, CurrentCompany);
            CurrentCompany.Update(RzWin.Context);
        }
    }
}
