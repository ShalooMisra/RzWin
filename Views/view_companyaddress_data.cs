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
    public partial class view_companyaddress_data : UserControl
    {
        public company CurrentCompany;
        public companyaddress CurrentAddress;

        public view_companyaddress_data()
        {
            InitializeComponent();
        }

        public void CompleteLoad(company c, companyaddress a)
        {
            CurrentCompany = c;
            CurrentAddress = a;
            NMWin.LoadFormValues(this, a);
        }

        public void UpdateAddressData()
        {
            if (CurrentAddress == null)
                return;

            //String s = (String)ctl_line1.GetValue();
            //if (Tools.Strings.HasString(s, "(required)"))
            //{
            //    if (!RzWin.Leader.AreYouSure("Save this as an address for " + CurrentCompany.companyname))
            //        return;

            //}

            NMWin.GrabFormValues(this, CurrentAddress);
            CurrentAddress.Update(RzWin.Context);
            RzWin.Leader.Comment("Address saved.");
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (CurrentAddress == null)
                return;

            //String s = (String)ctl_line1.GetValue();
            //if( Tools.Strings.HasString(s, "(required)" ))
            //{
            //    if( !RzWin.Leader.AreYouSure("Save this as an address for " + CurrentCompany.companyname) )
            //        return;

            //}
            UpdateAddressData();
            //NMWin.GrabFormValues(this, CurrentAddress);
            //CurrentAddress.Update(RzWin.Context);
            //RzWin.Leader.Comment("Address saved.");
        }

        private void cmdChoose_Click(object sender, EventArgs e)
        {
            if (CurrentCompany == null)
                return;

            companyaddress a = (companyaddress)frmChooseObject.ChooseFromSQL("companyaddress", "base_company_uid = '" + CurrentCompany.unique_id + "'", "description");
            if (a == null)
                return;

            CompleteLoad(CurrentCompany, a);
        }
    }
}
