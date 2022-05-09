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
    public partial class CompanyStub_PlusInfo : CompanyStub_PlusContact
    {
        public CompanyStub_PlusInfo()
        {
            InitializeComponent();
        }

        public void SetCompany(String strCompanyName, String strCompanyID, String strContactName, String strContactID, String strInfo)
        {
            base.SetCompany(strCompanyName, strCompanyID, strContactName, strContactID);
            lblInfo.Text = strInfo; 
        }
    }
}

