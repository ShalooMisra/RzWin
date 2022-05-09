using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Rz5;
using RzInterfaceWin.Dialogs;

namespace RzSensible
{
    public partial class view_orddet_sensible : Rz5.view_orddet 
    {
        //Constructors
        public view_orddet_sensible()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void CompleteLoad()
        {
            ctl_rohs_info.LoadList(true);
            base.CompleteLoad();
        }
        public override void DoVisible()
        {
            switch (CurrentDetail.OrderType)
            {
                case Rz5.Enums.OrderType.Quote:
                case Rz5.Enums.OrderType.Sales:
                case Rz5.Enums.OrderType.Invoice:
                case Rz5.Enums.OrderType.VendRMA:
                    if (Tools.Strings.StrExt(CurrentDetail.vendor_company_uid))
                        lnkBidFromBatch.Visible = false;
                    else
                        lnkBidFromBatch.Visible = true;
                    break;
            }
            base.DoVisible();
        }
        //Private Functions
        private void LinkBidFromBatch()
        {
            frmLinkBidToSalesDet l = new frmLinkBidToSalesDet();
            if (!l.CompleteLoad(CurrentDetail.base_dealdetail_uid))
            {
                RzWin.Context.TheLeader.Tell("This line does not appear to be attached to any order batch. Please manually select your supplier.");
                return;
            }
            l.ShowDialog();
            Rz5.orddet_rfq r = l.TheRFQ;
            if (r == null)
                return;
            //CurrentDetail.original_vendor_name = "";
            CurrentDetail.vendor_company_uid = r.base_company_uid;
            CurrentDetail.vendorcontactid = r.base_companycontact_uid;
            CurrentDetail.vendorcontactname = r.contactname;
            CurrentDetail.vendorid = r.base_company_uid;
            CurrentDetail.vendorname = r.companyname;
            CurrentDetail.unitcost = r.unitprice;
            CurrentDetail.Update(RzWin.Context);
            CompleteLoad();
        }
        //Control Events
        private void lnkBidFromBatch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkBidFromBatch();
        }
    }
}
