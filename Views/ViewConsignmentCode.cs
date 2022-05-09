using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;




namespace Rz5.Views
{
    public partial class ViewConsignmentCode : ViewPlusMenu
    {
        consignment_code TheCode
        {
            get
            {
                return (consignment_code)GetCurrentObject();
            }
        }

        public ViewConsignmentCode()
        {
            InitializeComponent();
        }

        public override void CompleteLoad()
        {
            base.CompleteLoad();
            //if (Rz3App.xLogic.IsPhoenix)
            //{
            //    ctl_code_name.Caption = "Lot Number";
            //    ctl_payout_percent.Caption = "Percent Paid To The Vendor";
            //    ctl_keep_percent.Caption = "Phoenix Percent";
            //}
            KeepShow();
            vendor.SetCompany(TheCode.vendor_name, TheCode.vendor_uid, TheCode.vendor_contact_name, TheCode.vendor_contact_uid);
            ctl_consignment_bogey.SetValue(TheCode.consignment_bogey);
        }

        public override void CompleteSave()
        {
            TheCode.vendor_uid = vendor.GetCompanyID();
            TheCode.vendor_name = vendor.GetCompanyName();
            TheCode.vendor_contact_uid = vendor.GetContactID();
            TheCode.vendor_contact_name = vendor.GetContactName();
            TheCode.consignment_bogey = Convert.ToDouble(ctl_consignment_bogey.GetValue().ToString());
            base.CompleteSave();
        }

        void KeepShow()
        {
            TheCode.payout_percent = ctl_payout_percent.GetValue_Integer();
            TheCode.KeepCalc();
            ctl_keep_percent.SetValue(TheCode.keep_percent);
        }

        private void ctl_payout_percent_DataChanged(Tools.GenericEvent e)
        {
            KeepShow();
        }
    }
}
