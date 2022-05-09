using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class frmNewContact : Form
    {
        public company CurrentCompany;
        public String SelectedName = "";

        public frmNewContact()
        {
            InitializeComponent();
        }

        public void CompleteLoad(String strCompanyID)
        {
            company c = company.GetById(RzWin.Context, strCompanyID);
            CompleteLoad(c);
        }

        public void CompleteLoad(company c)
        {
            if (c == null)
            {
                RzWin.Context.Error("No company was sent.");
                return;
            }
            CurrentCompany = c;
            lblCompanyName.Text = CurrentCompany.companyname;
            lblContact.Text = "Contact: " + CurrentCompany.primarycontact;
            lblPhone.Text = "Phone: " + CurrentCompany.primaryphone;
            lblFax.Text = "Fax: " + CurrentCompany.primaryfax;
            lblEmail.Text = "Email: " + CurrentCompany.primaryemailaddress;

            lstContacts.ShowTemplate("company_new_contact", "companycontact");
            lstContacts.ShowData("companycontact", "base_company_uid = '" + c.unique_id + "'", "contactname", SysNewMethod.ListLimitDefault);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedName = "";
            this.Hide();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (Tools.Strings.StrExt(txtNewContact.Text))
            {
                SelectedName = txtNewContact.Text;
                this.Hide();
            }
            else
            {
                RzWin.Context.Error("Please enter a contact name.");
            }
        }
    }
}