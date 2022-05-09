using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using NewMethod;

namespace Rz5
{
    public partial class CompanyContactList : UserControl
    {
        public CompanyContactList()
        {
            InitializeComponent();
        }

        private void CompanyContactList_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            try
            {
                companies.Left = 0;
                companies.Top = 0;
                companies.Width = this.ClientRectangle.Width;

                contacts.Left = 0;
                contacts.Width = this.ClientRectangle.Width;
            }
            catch (Exception)
            { }
        }

        public CompanyList GetCompanyList()
        {
            return companies;
        }

        public ContactList GetContactList()
        {
            return contacts;
        }

        private void companies_CompanyClicked(object sender, CompanyEventArgs args)
        {
            contacts.LoadCompanyID(args.strID);
        }

        public void Clear()
        {
            companies.Clear();
            contacts.Clear();
        }
    }
}
