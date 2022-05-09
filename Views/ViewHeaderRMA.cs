using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rz5
{
    public partial class ViewHeaderRMA : ViewHeader
    {
        ordhed_rma CurrentRMA
        {
            get
            {
                return (ordhed_rma)CurrentOrder;
            }
        }

        //Constructors
        public ViewHeaderRMA()
        {
            InitializeComponent();
        }
        //Protected Override Functions
        public override void CompleteLoad()
        {
            base.CompleteLoad();
            CompleteLoad_RMAData();
        }
        public override void CompleteSave()
        {
            CompleteSave_RMAData();
            base.CompleteSave();
        }
        protected override void CompleteLoad_Shipping()
        {
            base.CompleteLoad_Shipping();
            string track = "";
            lvShipVia.Items.Clear();
            lvAccount.Items.Clear();
            lvShipVia.SuspendLayout();
            lvAccount.SuspendLayout();
            try
            {
                List<orddet> l = CurrentRMA.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    if (Tools.Strings.StrExt(track))
                        track += ",";
                    track += ln.tracking_rma.Replace("\r\n", ",");
                    ListViewItem xLst = lvShipVia.Items.Add(ln.linecode_rma.ToString());
                    xLst.SubItems.Add(ln.shipvia_rma);
                    xLst = lvAccount.Items.Add(ln.linecode_rma.ToString());
                    xLst.SubItems.Add(ln.shippingaccount_rma);
                }
            }
            catch { }
            lvShipVia.ResumeLayout();
            lvAccount.ResumeLayout();
            ctl_trackingnumber.SetValue(track);
        }
        protected override void SetShipVia()
        {
            IsLoading = true;
            try
            {
                CurrentRMA.shipvia = ctl_shipvia.GetValue_String();
                CurrentRMA.Update(RzWin.Context);
                List<orddet> l = CurrentRMA.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    ln.shipvia_rma = ctl_shipvia.GetValue_String();
                    ln.Update(RzWin.Context);
                }
                CompleteLoad_Shipping();
            }
            catch { }
            IsLoading = false;
        }
        protected override void SetShipAccounts()
        {
            IsLoading = true;
            try
            {
                CurrentRMA.shippingaccount = ctl_shippingaccount.GetValue_String();
                CurrentRMA.Update(RzWin.Context);
                List<orddet> l = CurrentRMA.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    ln.shippingaccount_rma = ctl_shippingaccount.GetValue_String();
                    ln.Update(RzWin.Context);
                }
            }
            catch { }
            CompleteLoad_Shipping();
            IsLoading = false;
        }
        protected override void CompleteLoad_Totals()
        {
            lblSubTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            if (CurrentRMA == null)
                return;
            CurrentRMA.CalculateAllAmounts(RzWin.Context);
            lblSubTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentRMA.sub_total);
            lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentRMA.Expenses);
            lblTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentRMA.ordertotal);
        }

        protected override void CompleteLoad_Status()
        {



            base.CompleteLoad_Status();

            int putAwayableCount = CurrentRMA.DetailsListPutAwayable(RzWin.Context).Count;

            if (putAwayableCount > 0)
            {
                gbAction1.Visible = true;
                cmdAction1.Enabled = true;
                gbReport.Visible = false;
                //if (RzWin.Context.xUser.IsDeveloper())
                //{
                cmdAction1.ImageKey = "PutAway.png";
                //}
                //else
                //    cmdAction1.ImageKey = "PutAway";
                lblLineStatus1.Text = Tools.Strings.PluralizePhrase("Line", putAwayableCount);
            }
            else
            {
                gbAction1.Visible = false;
                gbReport.Visible = true;
            }
        }

        public void CompleteLoad_RMAData()
        {
            optShip.Checked = false;
            optWarehouse.Checked = false;
            optNoReturn.Checked = false;
            optReturn.Checked = false;
            optKeep.Checked = false;
            optDiscard.Checked = false;
            ordhed xVendRMA = null;

            ordrma linkedRMA = CurrentOrder.LinkedRMAGet(RzWin.Context);

            if (linkedRMA == null)
            {
                String[] ary = Tools.Strings.Split(CurrentOrder.rma_data, "\r\n");
                cboWhy.SetValue(ary[0]);
                if (ary.Length > 1)
                    cboReimburse.SetValue(ary[1]);
                if (ary.Length > 2)
                {
                    switch (ary[2].Trim().ToLower().Replace(" ", ""))
                    {
                        case "ship":
                            optShip.Checked = true;
                            break;
                        case "warehouse":
                            optWarehouse.Checked = true;
                            break;
                        case "noreturn":
                            optNoReturn.Checked = true;
                            break;
                    }
                }
                if (ary.Length > 3)
                {
                    switch (ary[3].Trim().ToLower().Replace(" ", ""))
                    {
                        case "return":
                            optReturn.Checked = true;
                            break;
                        case "keep":
                            optKeep.Checked = true;
                            break;
                        case "discard":
                            optDiscard.Checked = true;
                            break;
                        case "noreturn":
                            optDiscard.Checked = true;
                            break;
                    }
                }
                xVendRMA = CurrentOrder.GetLinkedVendorRMA(RzWin.Context);
                if (xVendRMA == null)
                {
                    cmdVendorRMA.Text = "Create A Vendor RMA";
                    cmdVendorRMA.Tag = "";
                }
                else
                {
                    cmdVendorRMA.Text = "Edit Vendor RMA " + xVendRMA.ordernumber;
                    cmdVendorRMA.Tag = xVendRMA.KeyID;
                }
            }
            else
            {
                cboWhy.SetValue(linkedRMA.return_reason);
                cboReimburse.SetValue(linkedRMA.customer_reimbursed);
                switch (linkedRMA.current_status.ToLower().Trim().Replace(" ", ""))
                {
                    case "ship":
                        optShip.Checked = true;
                        break;
                    case "warehouse":
                        optWarehouse.Checked = true;
                        break;
                    case "noreturn":
                        optNoReturn.Checked = true;
                        break;
                }
                switch (linkedRMA.planned_status.ToLower().Trim().Replace(" ", ""))
                {
                    case "return":
                        optReturn.Checked = true;
                        break;
                    case "keep":
                        optKeep.Checked = true;
                        break;
                    case "discard":
                        optDiscard.Checked = true;
                        break;
                    case "no return":
                        optDiscard.Checked = true;
                        break;
                }
                if (linkedRMA.customer_refund)
                    optYesCustomer.Checked = true;
                else
                    optNoCustomer.Checked = true;
                cboVendReimburse.SetValue(linkedRMA.vendor_reimbursed);
                if (linkedRMA.vendor_refund)
                    optYesVendor.Checked = true;
                else
                    optNoVendor.Checked = true;
            }
            if (xVendRMA != null)
                xVendRMA = CurrentOrder.GetLinkedVendorRMA(RzWin.Context);
            if (xVendRMA == null)
            {
                cmdVendorRMA.Text = "Create A Vendor RMA";
                cmdVendorRMA.Tag = "";
            }
            else
            {
                cmdVendorRMA.Text = "Edit Vendor RMA " + xVendRMA.ordernumber;
                cmdVendorRMA.Tag = xVendRMA.KeyID;
            }
        }
        public void CompleteSave_RMAData()
        {
            ordrma linkedRMA = CurrentRMA.LinkedRMAGet(RzWin.Context);

            if (linkedRMA == null)
            {
                linkedRMA = ordrma.New(RzWin.Context);
                CurrentRMA.LinkedRMASet(linkedRMA);
                if (CurrentRMA.OrderType == Rz5.Enums.OrderType.RMA)
                    linkedRMA.rma_ordhed_uid = CurrentRMA.unique_id;
                else
                    linkedRMA.vendrma_ordhed_uid = CurrentRMA.unique_id;
                linkedRMA.Insert(RzWin.Context);
            }
            linkedRMA.return_reason = (String)cboWhy.GetValue();
            linkedRMA.customer_reimbursed = (String)cboReimburse.GetValue();
            if (optShip.Checked)
                linkedRMA.current_status = "ship";
            else if (optWarehouse.Checked)
                linkedRMA.current_status = "warehouse";
            else if (optNoReturn.Checked)
                linkedRMA.current_status = "noreturn";
            else
                linkedRMA.current_status = "";
            if (optReturn.Checked)
                linkedRMA.planned_status = "return";
            else if (optKeep.Checked)
                linkedRMA.planned_status = "keep";
            else if (optDiscard.Checked)
                linkedRMA.planned_status = "discard";
            else
                linkedRMA.planned_status = "";
            linkedRMA.customer_refund = optYesCustomer.Checked;
            linkedRMA.vendor_reimbursed = (String)cboVendReimburse.GetValue();
            linkedRMA.vendor_refund = optYesVendor.Checked;
            linkedRMA.Update(RzWin.Context);
        }
        protected override void Action1()
        {
            base.Action1();
            CurrentRMA.PutAway(RzWin.Context);
            if (RzWin.Context.xSys.Recall)
                RzWin.Context.xSys.RecallActionLog(CurrentRMA, "RMA Put Away", RzWin.Context.xUser);
        }
        //Buttons
        private void cmdVendorRMA_Click(object sender, EventArgs e)
        {
            CompleteSave();
            CurrentRMA.Update(RzWin.Context);
            String strActualRMA = "";
            String strCleanRMA = "";
            switch (cmdVendorRMA.Tag.ToString())
            {
                case "":
                    if (!RzWin.Context.TheLeader.AskYesNo("Do you want to create a new Vendor RMA?"))
                        return;
                    strActualRMA = CurrentRMA.rma_data;
                    cboReimburse.Text = "";
                    CompleteSave_RMAData();
                    strCleanRMA = CurrentRMA.rma_data;
                    CurrentRMA.rma_data = strActualRMA;
                    CompleteLoad_RMAData();
                    ordhed xVendRMA = CurrentRMA.MakeLinkedVendorRMA(RzWin.Context, this.ParentForm);
                    if (xVendRMA == null)
                        return;
                    //xVendRMA.rma_data = strCleanRMA;
                    //xVendRMA.Update(RzWin.Context);
                    //ordrma linkedRMA = CurrentRMA.LinkedRMAGet(RzWin.Context);
                    //if (linkedRMA != null)
                    //{
                    //    linkedRMA.vendrma_ordhed_uid = xVendRMA.unique_id;
                    //    linkedRMA.Update(RzWin.Context);
                    //}
                    //List<orddet> colVRMA = xVendRMA.DetailsList(RzWin.Context);
                    //foreach (orddet k in CurrentRMA.DetailsList(RzWin.Context))
                    //{
                    //    foreach (orddet l in colVRMA)
                    //    {
                    //        orddet xDetail = k;
                    //        orddet yDetail = l;
                    //        if (Tools.Strings.StrCmp(xDetail.fullpartnumber, yDetail.fullpartnumber))
                    //        {
                    //            if (optReturn.Checked)
                    //                yDetail.quantity = xDetail.quantity;
                    //            else
                    //                yDetail.quantity = 0;
                    //            yDetail.Update(RzWin.Context);
                    //        }
                    //    }
                    //}
                    RzWin.Context.Show(xVendRMA);
                    break;
                default:
                    RzWin.Context.Sys.ThrowByKey(RzWin.Context, cmdVendorRMA.Tag.ToString());
                    break;
            }
        }
    }
}
