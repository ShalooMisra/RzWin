using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class ViewHeaderPurchase : ViewHeader
    {
        protected ordhed_purchase CurrentPO
        {
            get
            {
                return (ordhed_purchase)CurrentOrder;
            }
        }

        protected company CurrentCompany
        {
            get
            {
                return company.GetById(RzWin.Context, CurrentPO.base_company_uid);

            }

        }


        //KT Invoke Rz Timer for use to delay vendor credit by .5 seconds (500ms)
        private static Timer timer2 = new Timer();


        //Constructors
        public ViewHeaderPurchase()
        {
            InitializeComponent();
        }


        //Protected Override Functions
        public override void CompleteLoad()
        {
            cStub.Caption = "Vendor";
            base.CompleteLoad();
            //CheckIsOpenYetAllLinesShipped();
            //KT Refactored from RzSensible            
            //CheckPermissions();
            CompleteLoad_Charges();
            //End Refactor
            TabOrder();
            CheckCanceledTab();
            LoadCanceled();
            CheckPermissions();

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
                List<orddet> l = CurrentPO.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    if (Tools.Strings.StrExt(track))
                        track += ",";
                    track += ln.tracking_purchase.Replace("\r\n", ",");
                    ListViewItem xLst = lvShipVia.Items.Add(ln.linecode_purchase.ToString());
                    xLst.SubItems.Add(ln.shipvia_purchase);
                    xLst = lvAccount.Items.Add(ln.linecode_purchase.ToString());
                    xLst.SubItems.Add(ln.shippingaccount_purchase);
                }
            }
            catch { }
            lvShipVia.ResumeLayout();
            lvAccount.ResumeLayout();
            ctl_trackingnumber.SetValue(track);
        }

        //KT Refactored from RzSensible
        public override void CompleteSave()
        {
            base.CompleteSave();
            CompleteLoad_Charges();

            SetFirstCustomer();
        }

        private void SetFirstCustomer()
        {
            if (CurrentPO.DetailsList(RzWin.Context) == null)
                return;
            if (CurrentPO.DetailsList(RzWin.Context).Count() <= 0)
                return;

            string firstCustomer = "";
            orddet_line l = (orddet_line)CurrentPO.DetailsList(RzWin.Context)[0];
            if (l != null)
                firstCustomer = l.customer_name ?? "";
            if (CurrentPO.first_customer != firstCustomer)
            {
                CurrentPO.first_customer = firstCustomer;
                CurrentPO.Update(RzWin.Context);
            }


        }


        //KT End Refactor


        protected override void SetShipVia()
        {
            IsLoading = true;
            try
            {
                CurrentPO.shipvia = ctl_shipvia.GetValue_String();
                CurrentPO.Update(RzWin.Context);
                List<orddet> l = CurrentPO.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    ln.shipvia_purchase = ctl_shipvia.GetValue_String();
                    ln.Update(RzWin.Context);
                }
                CompleteLoad_Shipping();
                CompleteLoad_ShipAccounts();
            }
            catch { }
            IsLoading = false;
        }
        protected override void SetShipAccounts()
        {
            IsLoading = true;
            try
            {
                CurrentPO.shippingaccount = ctl_shippingaccount.GetValue().ToString();
                //object test = ctl_shippingaccount.GetValue();
                CurrentPO.Update(RzWin.Context);
                List<orddet> l = CurrentPO.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    ln.shippingaccount_purchase = CurrentPO.shippingaccount;
                    ln.Update(RzWin.Context);
                }
            }
            catch (Exception ex)
            {
                RzWin.Context.Leader.Error(ex.Message);
            }
            CompleteLoad_Shipping();
            CompleteLoad_ShipAccounts();
            IsLoading = false;
        }
        protected override void CompleteLoad_Totals()
        {
            lblSubTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblCreditAmount.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            if (CurrentPO == null)
                return;
            CurrentPO.CalculateAllAmounts(RzWin.Context);
            lblSubTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentPO.sub_total);
            lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentPO.Expenses);
            //KT Payment Amount
            //KT 9-26-2016 - Credit amount is already getting calculated.  This is throwing off amoutn paid when a companycredit is present.
            //lblPaid.Text = RzWin.Context.TheSys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentPO.AmountPaid(RzWin.Context) + CurrentPO.credit_amount);
            lblPaid.Text = RzWin.Context.TheSys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentPO.AmountPaid(RzWin.Context));
            //KT Credit Amount
            lblCreditAmount.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentPO.creditamount);
            lblTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentPO.ordertotal);
        }
        protected override void CompleteLoad_Status()
        {
            base.CompleteLoad_Status();

            if (CurrentPO.is_consign)
            {
                bool currentClosureStatus = CurrentPO.isclosed;
                bool newClosureStatus = CheckFullyPaidConsignmentPO();
                if (newClosureStatus != currentClosureStatus)
                {
                    CurrentPO.isclosed = newClosureStatus;
                    CurrentPO.Update(RzWin.Context);
                }
                return;
            }




            //Load any Missing Properties
            CurrentOrder.LoadMissingProperties(RzWin.Context);


            int putAwayableCount = CurrentPO.DetailsListPutAwayable(RzWin.Context).Count;

            if (putAwayableCount > 0)
            {
                gbAction1.Visible = true;
                cmdAction1.ImageKey = "PutAway.png";
                lblLineStatus1.Text = Tools.Strings.PluralizePhrase("Line", putAwayableCount);
            }
            else
            {
                gbAction1.Visible = false;

            }

        }



        private bool CheckFullyPaidConsignmentPO()
        {
            double paidAmount = SensibleDAL.ConsignmentData.GetPOPaidAmount(CurrentPO.unique_id);
            if (paidAmount >= CurrentPO.ordertotal)
                return true;
            return false;
        }

        protected override void Action1()
        {
            base.Action1();
            CurrentPO.PutAway(RzWin.Context);
            if (RzWin.Context.xSys.Recall)
                RzWin.Context.xSys.RecallActionLog(CurrentPO, "Purchase Order Put Away", RzWin.Context.xUser);
            ////KE Refactored from RzSensible
            ////Update the Vendor's Last Purchase Date
            Rz5.company c = CurrentPO.CompanyVar.RefGet(RzWin.Context);
            if (c != null)
            {
                c.last_purchase_date = DateTime.Now;
                c.Update(RzWin.Context);
            }
            RzWin.Context.TheLeader.Tell("Done");
            //End Refactor
        }


        private void AddTrackingNumbers()
        {
            string tracking = RzWin.Context.TheLeader.AskForString("Add Tracking Numbers", CurrentPO.trackingnumber, true);
            if (!Tools.Strings.StrExt(tracking))
                return;
            CurrentPO.trackingnumber = tracking;
            CurrentPO.Update(RzWin.Context);
            foreach (orddet_line l in CurrentPO.DetailsList(RzWin.Context))
            {
                l.tracking_purchase = tracking;
                l.Update(RzWin.Context);
            }
            CompleteLoad_Shipping();
        }
        private void lnkTracking_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddTrackingNumbers();
        }

        private void CheckCanceledTab()
        {
            try
            {
                //Int64 i = RzWin.Context.SelectScalarInt64("select count(*) from orddet_line_canceled where the_orddet_uid in (select unique_id from " + ordhed.MakeOrddetName(CurrentOrder.OrderType) + " where base_ordhed_uid = '" + CurrentOrder.unique_id + "')");
                //Int64 i = CurrentOrder.PictureCount(RzWin.Context);   
                Int64 i = RzWin.Context.SelectScalarInt64("select count(*) from orddet_line_canceled where orderid_purchase ='" + CurrentOrder.unique_id + "'");
                tabCanceled.Text = "Canceled(" + i.ToString() + ")"; //Emulate this to get a count of canceled lines
            }
            catch
            {

            }
        }
        //KT - Fill lvCanceled
        private void LoadCanceled()
        {
            try
            {
                ListArgs a = new ListArgs(RzWin.Context);
                a.AddAllow = false;
                a.TheCaption = "Canceled Lines";
                a.TheClass = "orddet_line";
                a.TheLimit = 200;
                a.TheOrder = "linecode_sales asc";
                a.TheTable = "orddet_line_canceled";
                a.TheTemplate = "orddet_line_canceled_sales";
                a.TheWhere = "orderid_purchase = '" + CurrentOrder.unique_id + "'";
                lvCanceled.ShowData(a);
            }
            catch { }
        }
        //KT - show canceled line when double-clicking
        private void ShowCanceledLine(orddet_line l)
        {
            try
            {
                if (l == null)
                    return;
                Rz5.ShowArgsOrder args = new Rz5.ShowArgsOrder(RzWin.Context, l, Rz5.Enums.OrderType.Sales);
                args.ClassId = "orddet_line";
                nView vi = (nView)RzWin.Context.TheLeader.ViewCreate(RzWin.Context, args);
                if (vi == null)
                    return;
                vi.Init(l);
                vi.CompleteLoad();
                vi.DisableControls();
                RzWin.Form.TabShow(vi, l.ToString(), l.unique_id);
            }
            catch { }
        }
        //KT - The below is apparently the double-click handler so show the line data when double-clicking a canceled line
        private void lvCanceled_AboutToThrow(Core.Context x, Core.ShowArgs args) // not sure what this does, doesn't seems ot be involved in loading the cancelled lines
        {
            ShowCanceledLine((orddet_line)lvCanceled.GetSelectedObject());
        }

        //KT - This makes sure attachments is the last tab on the right
        private void TabOrder()
        {
            tsDetails.TabPages.Remove(tabAttachments);
            tsDetails.TabPages.Add(tabAttachments);

        }
        //This resizes the canceled listview
        protected override void DoResize()
        {
            try
            {
                base.DoResize();
                //lvCanceled.Left = 0;
                //lvCanceled.Width = tabLines.ClientRectangle.Width;
                //lvCanceled.Top = (tabLines.ClientRectangle.Height - lvCanceled.Height) - 1;
                lvCanceled.Left = 0;
                lvCanceled.Width = tabLines.ClientRectangle.Width;
                lvCanceled.Top = 0;
                lvCanceled.Height = tabLines.ClientRectangle.Height;
                //lvCanceled.Height = 30;
                details.Top = 0;
                details.Left = 0;
                details.Width = tabLines.ClientRectangle.Width;
                details.Height = tabLines.ClientRectangle.Height;
                //details.Height = (lvCanceled.Top - details.Top) - 2;
            }
            catch { }
        }


        private void lvVendorCredits_AboutToAdd(object sender, Core.AddArgs args)
        {
            if (!RzWin.Leader.AskYesNo("Are you Adding a new Vendor Credit?  (Click NO if you are applying credit to the order)"))
            {
                RzWin.Context.TheLeaderRz.ChooseCompanyCredit(RzWin.Context, CurrentCompany, CurrentPO);
                CompleteLoad_Totals();
            }
            else
            {
                args.Handled = true;
                AddVendorCredits();
                CompleteLoad_Totals();
            }

        }

        private void lvVendorCredits_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            //args.Handled = true;
            //ShowVendorCredits();
        }


        //private void ShowVendorCredits()
        //{
        //    try
        //    {
        //        Rz5.companycredit c = (Rz5.companycredit)nListVendorCredits.GetSelectedObject();
        //        frmCompanyCredit f = new frmCompanyCredit();
        //        f.CompleteLoad(RzWin.Context, c);
        //        f.ShowDialog();
        //    }
        //    catch { }
        //}


        private void AddVendorCredits()
        {
            try
            {
                //companycredit c = ((ordhed_purchase)CurrentOrder).CompanyCreditVar.RefAddNew(RzWin.Context);
                companycredit c = new companycredit();
                //Rz5.companycredit c = Rz5.companycredit.New(RzWin.Context);
                c.base_ordhed_uid = CurrentOrder.unique_id;
                c.base_company_uid = CurrentOrder.base_company_uid;
                c.ordernumber = CurrentOrder.ordernumber;
                c.companyname = CurrentOrder.companyname;
                c.purchase_order_uid = CurrentOrder.unique_id;
                c.Update(RzWin.Context);
                frmCompanyCredit f = new frmCompanyCredit();
                f.CompleteLoad(RzWin.Context, c, CurrentOrder);
                f.ShowDialog();


            }
            catch (Exception ex)
            {

                RzWin.Leader.Error(ex);

            }
        }

        private void CheckPermissions()
        {
            //if (!RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, NewMethod.Permissions.ThePermits.AddOtherChargeCredit, RzWin.Context.xUser))
            cmdAddCharge.Enabled = RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).ManageDeductions, RzWin.Context.xUser);
            ctl_terms.Enabled = RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanSetVendorTerms, RzWin.Context.xUser);
            ctl_post_to_portal.Enabled = RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanPostToPortal, RzWin.Context.xUser);
            ctl_post_to_portal.Visible = RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanPostToPortal, RzWin.Context.xUser);
        }

        ////KT Refactored from RzSensible
        protected override void ChangeHandler(String strClass, bool adds)
        {
            try
            {
                switch (strClass.ToLower().Trim())
                {
                    case "checkpayment":
                        CompleteLoad_Totals();
                        CompleteLoad_Charges();
                        break;
                    default:
                        base.ChangeHandler(strClass, adds);
                        break;
                }
            }
            catch { }
        }

        //private void AddCharge()
        //{
        //    profit_deduction p = ((ordhed_purchase)CurrentOrder).DeductionsVar.RefAddNew(RzWin.Context);
        //    ShowCharge(p);
        //    CompleteLoad_Charges();
        //    CurrentOrder.Update(RzWin.Context);
        //}
        private void CompleteLoad_Charges()
        {
            LoadChargeLV();
            //LoadCompanyCreditsLabel();
            //CompleteLoad_Totals();
            LoadChargeLabel();
            //LoadCompanyCreditsLabel();
        }

        //KT Company Credits
        private void CompleteLoad_Credits()
        {
            //LoadChargeLV();
            LoadCompanyCreditsLabel();
            //CompleteLoad_Totals();
            //LoadChargeLabel();
        }


        private void LoadChargeLV()
        {
            lvCharges.Items.Clear();
            lvCharges.SuspendLayout();

            try
            {
                foreach (profit_deduction p in ((ordhed_purchase)CurrentOrder).DeductionsVar.RefsList(RzWin.Context))
                {
                    string key = "";
                    if (p.include_on_po)
                        key = "on_po";
                    ListViewItem xLst = lvCharges.Items.Add(p.name, key);
                    xLst.SubItems.Add(Tools.Number.MoneyFormat_2_6(p.amount));
                    xLst.Tag = p;
                }
            }
            catch { }
            lvCharges.ResumeLayout();
        }
        private void LoadChargeLabel()
        {
            lblCharges.Text = RzWin.Context.TheSys.CurrencySymbol + " 0.00";
            lblTotal.Text = RzWin.Context.TheSys.CurrencySymbol + " 0.00";
            if (CurrentPO == null)
                return;
            double ded = 0;
            double add = 0;
            foreach (profit_deduction p in ((ordhed_purchase)CurrentPO).DeductionsVar.RefsList(RzWin.Context))
            {
                //ded += p.amount;
                //if (!p.include_on_po)
                //    add += p.amount; 
                if (p.include_on_po)
                    ded += p.amount;
            }
            lblCharges.Text = RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(ded);
            lblTotal.Text = RzWin.Context.TheSys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentPO.ordertotal);// + ded);
                                                                                                                       //lblTotal.Text = RzWin.Context.TheSys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentPO.ordertotal + add);
        }

        private void LoadCompanyCreditsLabel()
        {
            lblCreditAmount.Text = RzWin.Context.TheSys.CurrencySymbol + " 0.00";
            lblTotal.Text = RzWin.Context.TheSys.CurrencySymbol + " 0.00";
            if (CurrentPO == null)
                return;
            double credit = 0;
            //double add = 0;
            foreach (companycredit c in ((ordhed_purchase)CurrentPO).CompanyCreditVar.RefsList(RzWin.Context))
            {
                //ded += p.amount;
                //if (!p.include_on_po)
                //    add += p.amount;
                if (c.is_applied == "1")
                {
                    if (c.purchase_order_uid == CurrentOrder.unique_id)
                        credit += c.creditamount;
                }

            }
            lblCreditAmount.Text = RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(credit);
            lblTotal.Text = RzWin.Context.TheSys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentPO.ordertotal);// + ded);
                                                                                                                       //lblTotal.Text = RzWin.Context.TheSys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentPO.ordertotal + add);

        }
        //private void ShowSelectedCharge()
        //{
        //    ListViewItem xLst = lvCharges.SelectedItems[0];

        //    if (xLst == null)
        //        return;
        //    ShowCharge((profit_deduction)xLst.Tag);
        //    CompleteLoad_Charges();
        //}
        private void ShowCharge(profit_deduction p)
        {
            //frmDeduction f = new frmDeduction();
            //if (!f.CompleteLoad(RzWin.Context, p))
            //    return;
            //f.ShowDialog();
        }

        //Show Company Credits form
        private void ShowCredit(companycredit c)
        {
            //frmDeduction f = new frmDeduction();
            //if (!f.CompleteLoad(RzWin.Context, p))
            //    return;
            //f.ShowDialog();
            try
            {
                frmCompanyCredit cf = new frmCompanyCredit();
                //if (!c.CompleteLoad(RzWin.Context, p))
                //    return;
                cf.ShowDialog();


                //Rz5.companycredit c = (Rz5.companycredit)nListVendorCredits.GetSelectedObject();
                //frmCompanyCredit f = new frmCompanyCredit();
                //f.CompleteLoad(RzWin.Context, c);
                //f.ShowDialog();
            }
            catch { }
        }

        private void RemoveCharge()
        {
            ListViewItem xLst = lvCharges.SelectedItems[0];
            if (xLst == null)
                return;
            profit_deduction p = (profit_deduction)xLst.Tag;
            if (p == null)
                return;
            ((ordhed_purchase)CurrentOrder).DeductionsVar.RefsRemove(RzWin.Context, p, true);
            foreach (orddet_line l in CurrentOrder.DetailsList(RzWin.Context))
            {
                List<Rz5.profit_deduction> d = l.DeductionsVar.RefsList(RzWin.Context);
                if (!d.Contains(p))
                    continue;
                l.DeductionsVar.RefsRemove(RzWin.Context, p);
            }
            CompleteLoad_Charges();
        }
        //Buttons
        private void cmdAddCharge_Click(object sender, EventArgs e)
        {
            //AddCharge();
        }
        //Control Events
        private void details_AboutToAction(object sender, Core.ActArgs args)
        {
            if (Tools.Strings.StrCmp(args.ActionName, "cancel"))
            {
                args.Handled = true;
                orddet_line line = (orddet_line)details.GetSelectedObject();
                if (line == null)
                    return;
                OrderLineCancelArgs a = new OrderLineCancelArgs(line);
                a.TypesToCancel.Add(Rz5.Enums.OrderType.Sales);
                a.TypesToCancel.Add(Rz5.Enums.OrderType.Purchase);
                a.Comment = "Cancelled on Purchase Order " + CurrentOrder.ordernumber;
                line.Cancel(RzWin.Context, a);
            }
        }
        private void lvCharges_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        //Menus
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCharge();
        }

        private bool CanManageDeductions()
        {
            bool allowed = RzWin.Context.xSys.ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanApplyAVL, RzWin.Context.xUser);
            if (allowed)
                return true;
            else
                return false;

        }


        //end Refactor
    }
}
