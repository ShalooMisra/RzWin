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
    public partial class ViewHeaderVendRMA : ViewHeader
    {
        ordhed_vendrma CurrentVendRMA
        {
            get
            {
                return (ordhed_vendrma)CurrentOrder;
            }
        }

        //Constructors
        public ViewHeaderVendRMA()
        {
            InitializeComponent();
        }
        //Protected Override Functions
        public override void CompleteLoad()
        {
            base.CompleteLoad();
            ctl_terms.Enabled = (RzWin.Context.CheckPermit(NewMethod.Permissions.ThePermits.CanSetVendorTerms));
            CompleteLoad_RMAData();
            cStub.Caption = "Vendor";
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
                List<orddet> l = CurrentVendRMA.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    if (Tools.Strings.StrExt(track))
                        track += ",";
                    track += ln.tracking_vendrma.Replace("\r\n", ",");
                    ListViewItem xLst = lvShipVia.Items.Add(ln.linecode_vendrma.ToString());
                    xLst.SubItems.Add(ln.shipvia_vendrma);
                    xLst = lvAccount.Items.Add(ln.linecode_vendrma.ToString());
                    xLst.SubItems.Add(ln.shippingaccount_vendrma);
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
                CurrentVendRMA.shipvia = ctl_shipvia.GetValue_String();
                CurrentVendRMA.Update(RzWin.Context);
                List<orddet> l = CurrentVendRMA.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    ln.shipvia_vendrma = ctl_shipvia.GetValue_String();
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
                CurrentVendRMA.shippingaccount = ctl_shippingaccount.GetValue_String();
                CurrentVendRMA.Update(RzWin.Context);
                List<orddet> l = CurrentVendRMA.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    ln.shippingaccount_vendrma = ctl_shippingaccount.GetValue_String();
                    ln.Update(RzWin.Context);
                }
            }
            catch { }
            CompleteLoad_Shipping();
            IsLoading = false;
        }

        protected override void CompleteLoad_Status()
        {
            base.CompleteLoad_Status();

            int shippableCount = CurrentVendRMA.DetailsListShippable(RzWin.Context).Count;
            if (shippableCount > 0)
            {
                gbAction1.Visible = true;
                cmdAction1.Enabled = true;
                //if (RzWin.Context.xUser.IsDeveloper())
                //{
                // cmdAction1.ImageKey = "Ship-2018-v3.png";
                cmdAction1.ImageKey = "Ship.png";
                //}
                //else
                //cmdAction1.ImageKey = "Ship";
                lblLineStatus1.Text = Tools.Strings.PluralizePhrase("Line", shippableCount);
            }
            else
            {
                gbAction1.Visible = false;
            }
        }

        protected override void CompleteLoad_Totals()
        {

            //KT
            double charges = 0;
            charges = RzWin.Context.Sys.TheProfitLogic.GetOrderCharges(RzWin.Context, CurrentOrder.unique_id);
            lblSubTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            if (CurrentVendRMA == null)
                return;
            CurrentVendRMA.CalculateAllAmounts(RzWin.Context);
            lblSubTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentVendRMA.sub_total);
            //lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentVendRMA.Expenses);
            lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(charges);
            lblTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentVendRMA.ordertotal);
            //KT - added a paid (refund) amount to the Vendor RMA view
            lblPaid.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentVendRMA.AmountPaid(RzWin.Context));



        }
        protected override void Action1()
        {
            base.Action1();
            CurrentVendRMA.Ship(RzWin.Context);
            if (RzWin.Context.xSys.Recall)
                RzWin.Context.xSys.RecallActionLog(CurrentVendRMA, "Vendor RMA Shipped", RzWin.Context.xUser);
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
            if (CurrentOrder.LinkedRMAGet(RzWin.Context) == null)
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
            }
            else
            {
                ordrma linkedRMA = CurrentOrder.LinkedRMAGet(RzWin.Context);

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
        }
        public void CompleteSave_RMAData()
        {
            ordrma linkedRMA = CurrentVendRMA.LinkedRMAGet(RzWin.Context);

            if (linkedRMA == null)
            {
                linkedRMA = ordrma.New(RzWin.Context);
                CurrentVendRMA.LinkedRMASet(linkedRMA);
                if (CurrentVendRMA.OrderType == Rz5.Enums.OrderType.RMA)
                    linkedRMA.rma_ordhed_uid = CurrentVendRMA.unique_id;
                else
                    linkedRMA.vendrma_ordhed_uid = CurrentVendRMA.unique_id;
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
    }
}
