using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using NewMethod;

namespace Rz5
{
    public partial class ViewHeaderInvoice : ViewHeader
    {
        protected ordhed_invoice CurrentInvoice
        {
            get
            {
                return (ordhed_invoice)CurrentOrder;
            }
        }

        //Constructors
        public ViewHeaderInvoice()
        {
            InitializeComponent();
        }
        //Protected Override Functions
        public override void Init(Item item)
        {
            base.Init(item);
        }

        public override void CompleteLoad()
        {
            base.CompleteLoad();
            //ctl_credit_caption.LoadList(true);
            //LoadOtherChargeCredit();


            CheckCommissionPermissions();
            ctl_commission_percent.SetValue(((Rz5.ordhed_invoice)CurrentInvoice).commission_percent);
            ctl_override_stock_commission.Checked = CurrentInvoice.override_stock_commission;
            //KT 8-26-2015
            //CompleteLoad_Deductions();
            CheckPermissions();
        }
        public override void CompleteSave()
        {
            base.CompleteSave();
            //SaveOtherChargeCredit();
            //KT Refactored from RzSensible 8-26-2015
            CompleteSave_Commission();

            CurrentInvoice.Update(RzWin.Context);
            UpdateLineIdentifcation();


        }

        private void CompleteSave_Commission()
        {



            double d = (double)ctl_commission_percent.GetValue();
            if (d == 0)//user may not have had commission set when this was created.
            {
                //Easy enough to handle on a case by case basis, no need to overcomplicate
            }

            if (d > 1)//this was typed as a whole number, let's auto-convert to a percentage
            {
                d = d / 100;
                ctl_commission_percent.SetValue(d);
            }


            CurrentInvoice.commission_percent = d;
            ctl_commission_percent.Enabled = false;
            ctl_override_stock_commission.Enabled = CurrentInvoice.override_stock_commission;
        }

        private void UpdateLineIdentifcation()
        {
            //Necessary because we chang einvoice number to match qb, AND LINES need to know that
            ordhed_invoice i = (ordhed_invoice)CurrentOrder;
            string invoiceNumber = i.ordernumber;
            string invoiceID = i.unique_id;
            foreach (orddet_line l in i.DetailsList(RzWin.Context))
            {
                bool needsUpdate = false;
                if (l.orderid_invoice != invoiceID || l.ordernumber_invoice != invoiceNumber)
                    needsUpdate = true;
                if (needsUpdate)
                {
                    l.orderid_invoice = invoiceID;
                    l.ordernumber_invoice = invoiceNumber;
                    l.Update(RzWin.Context);
                }


            }
        }

        //Protected Override Functions
        protected override void ChangeHandler(String strClass, bool adds)
        {
            try
            {
                switch (strClass.ToLower().Trim())
                {
                    //KT Refactored from RzSensible 8-26-2015
                    case "checkpayment":
                        CompleteLoad_Totals();
                        break;
                    default:
                        base.ChangeHandler(strClass, adds);
                        break;
                }
            }
            catch { }
        }

        //KT 8-26-15 Refactor from Sensible
        protected override void CompleteLoad_Company(Rz5.company c)
        {
            base.CompleteLoad_Company(c);
            lblFinancials.Visible = false;

            if (!((CompanyLogic)((SysRz5)RzWin.Context.xSys).TheCompanyLogic).IsCompanyFinancialsVerified(c, CurrentOrder))
            {
                lblFinancials.Visible = true;
                lblFinancials.BringToFront();
            }
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
                List<orddet> l = CurrentInvoice.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    if (Tools.Strings.StrExt(track))
                        track += ",";
                    track += ln.tracking_invoice.Replace("\r\n", ",");
                    ListViewItem xLst = lvShipVia.Items.Add(ln.linecode_invoice.ToString());
                    xLst.SubItems.Add(ln.shipvia_invoice);
                    xLst = lvAccount.Items.Add(ln.linecode_invoice.ToString());
                    xLst.SubItems.Add(ln.shippingaccount_invoice);
                }
            }
            catch { }
            lvShipVia.ResumeLayout();
            lvAccount.ResumeLayout();
            if (Tools.Strings.StrExt(track))
                ctl_trackingnumber.SetValue(track);
        }

        protected void CheckCommissionPermissions()
        {
            if (((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanEditCommissionPercentInvoice, RzWin.Context.xUser))
            {
                btn_edit_commission_percent.Visible = true;
                ctl_override_stock_commission.Visible = true;
            }
            else
            {
                btn_edit_commission_percent.Visible = false;
                ctl_override_stock_commission.Visible = false;
            }
        }

        //KT 8-26
        public double deductions;
        protected void CompleteLoad_Deductions()
        {
            deductions = 0;
            try
            {
                List<orddet> l = CurrentInvoice.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    if (ln.Name == "Customer Credit")
                        deductions += ln.total_deduction;
                }
            }
            catch { }

        }




        protected override void SetShipVia()
        {
            IsLoading = true;
            try
            {
                CurrentInvoice.shipvia = ctl_shipvia.GetValue_String();
                CurrentInvoice.Update(RzWin.Context);
                List<orddet> l = CurrentInvoice.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    ln.shipvia_invoice = ctl_shipvia.GetValue_String();
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
                CurrentInvoice.shippingaccount = ctl_shippingaccount.GetValue_String();
                CurrentInvoice.Update(RzWin.Context);
                List<orddet> l = CurrentInvoice.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    ln.shippingaccount_invoice = ctl_shippingaccount.GetValue_String();
                    ln.Update(RzWin.Context);
                }
            }
            catch { }
            CompleteLoad_Shipping();
            IsLoading = false;
        }
        protected override void CompleteLoad_Totals()
        {
            lblInvoiceTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblPayoutTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblCreditsAmnt.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblCompanyCredits.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblSubTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            if (CurrentInvoice == null)
                return;
            CurrentInvoice.CalculateAllAmounts(RzWin.Context);
            lblInvoiceTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentInvoice.sub_total);
            //lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentInvoice.Expenses);
            lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(RzWin.Context.Sys.TheProfitLogic.GetOrderCharges(RzWin.Context, CurrentInvoice.unique_id));
            //KT Get deductions label amount
            //CompleteLoad_Deductions();
            lblCreditsAmnt.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(RzWin.Context.Sys.TheProfitLogic.GetOrderCredits(RzWin.Context, new List<string>() { CurrentInvoice.unique_id }) + (RzWin.Context.Sys.TheProfitLogic.GetRefundPayments(RzWin.Context, CurrentInvoice.unique_id) * -1));
            lblOutstandingAmnt.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentInvoice.outstandingamount);
            //lblOutstandingAmnt.Text = RzWin.Context.Sys.CurrencySymbol + CurrentInvoice.outstandingamount;
            double companyCredits = RzWin.Context.Sys.TheProfitLogic.GetAssignedCompanyCredits(RzWin.Context, new List<string>() { CurrentInvoice.unique_id });
            lblCompanyCredits.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(companyCredits);
            //KT Refactor from Sensible 8-26
            //base.CompleteLoad_Totals();
            //lblCharges.Text = "$ " + Tools.Number.MoneyFormat(CurrentInvoice.Expenses + RzWin.Context.Sys.TheOrderLogic.GetCreditAmount(RzWin.Context, CurrentInvoice));
            //lblPayoutTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentInvoice.ordertotal);
            lblSubTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentInvoice.ordertotal);
            lblPaid.Text = RzWin.Context.TheSys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentInvoice.AmountPaid(RzWin.Context));
            lblNetProfitAmnt.Text = RzWin.Context.TheSys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentInvoice.net_profit);

        }
        protected override void CompleteLoad_Status()
        {
            base.CompleteLoad_Status();
            List<string> missingProps = new List<string>();
            bool isVerified = CurrentInvoice.CheckVerify(RzWin.Context, missingProps);
            PossibleArgs possibleArgs = new PossibleArgs();
            int shippableCount = CurrentInvoice.DetailsListShippable(RzWin.Context, possibleArgs).Count;
            if (shippableCount > 0 && isVerified)
            {
                cmdAction1.ImageKey = "Ship.png";
                gbAction1.Visible = true;
                cmdAction1.Enabled = true;
                lblLineStatus1.Text = Tools.Strings.PluralizePhrase("Line", shippableCount);
            }
            else
            {

                gbAction1.Visible = false;
            }

            //If PossibleArgs returned a log, show this in the gbReport
            if (!string.IsNullOrEmpty(possibleArgs.Log.ToString()))
            {
                gbReport.Visible = true;
                gbReport.Text = "Needed to Ship:";
                string reportText = possibleArgs.Log.ToString();
                rtReport.Text = reportText;
                
            }
            else
                gbReport.Visible = false;

        }
        protected override void Action1()
        {
            base.Action1();
            CurrentInvoice.Ship(RzWin.Context);
            if (RzWin.Context.xSys.Recall)
                RzWin.Context.xSys.RecallActionLog(CurrentInvoice, "Invoice Shipped", RzWin.Context.xUser);
        }
        protected override void DetailAdd()
        {
            base.DetailAdd();

        }
        //Private Functions


        private void UpdateOrderCommission()
        {
            n_user u = CurrentInvoice.AgentVar.RefGet(RzWin.Context);
            if (u == null)
                return;
            ctl_commission_percent.SetValue(u.commission_percent * 100);
            (CurrentInvoice).commission_percent = u.commission_percent;
            CurrentInvoice.Update(RzWin.Context);
        }


        //Refactor form RzSensible 8-26-14




        private void agent_DataChanged(Tools.GenericEvent e)
        {
            UpdateOrderCommission();
        }

        private void cmdAddCreditCharge_Click(object sender, EventArgs e)
        {
            //KT This is from the old Credits / Charges module
            //AddCreditCharges2();
        }
        //private void AddCreditCharges2()
        //{
        //    try
        //    {
        //        Rz5.ordhit h = Rz5.ordhit.New(RzWin.Context);
        //        h.the_ordhed_uid = CurrentOrder.unique_id;
        //        h.ordhit_name = ctl_credit_caption.GetValue_String();
        //        if (optCharge.Checked)
        //        {
        //            h.deduct_profit = true;
        //            h.hit_amount = ctl_credit_amount.GetValue_Double();
        //            //h.is_credit = false;
        //        }
        //        else
        //        {
        //            h.deduct_profit = false;
        //            //h.is_credit = true;
        //            h.hit_amount = ctl_credit_amount.GetValue_Double() * -1;
        //        }
        //        h.Insert(RzWin.Context);
        //        optCharge.Checked = false;
        //        optCredit.Checked = false;
        //        ctl_credit_caption.SetValue("");
        //        ctl_credit_amount.SetValue(0);
        //        CompleteSave();
        //    }
        //    catch { }
        //}
        //End Refactor of Private Functions

        //private void LoadOtherChargeCredit()
        //{
        //    if (!RzWin.Context.CheckPermit(NewMethod.Permissions.ThePermits.AddOtherChargeCredit))
        //        pChargeCredit.Enabled = false;
        //    else
        //        pChargeCredit.Enabled = true;
        //    if (CurrentInvoice == null)
        //        return;
        //    if (CurrentInvoice.credit_amount == 0)
        //        return;
        //    if (CurrentInvoice.credit_amount < 0)
        //    {
        //        optCredit.Checked = true;
        //        ctl_credit_amount.SetValue((CurrentInvoice.credit_amount * -1));
        //    }
        //    else
        //        optCharge.Checked = true;
        //}
        //private void SaveOtherChargeCredit()
        //{
        //    if (CurrentInvoice == null)
        //        return;
        //    if (ctl_credit_amount.GetValue_Double() == 0)
        //        return;
        //    if (optCharge.Checked)
        //        return;
        //    CurrentInvoice.credit_amount = (ctl_credit_amount.GetValue_Double() * -1);
        //    CurrentInvoice.Update(RzWin.Context);
        //    CompleteLoad_Totals();
        //}

        private void CheckPermissions()
        {
            ctl_terms.Enabled = (RzWin.Context.CheckPermit(NewMethod.Permissions.ThePermits.CanSetCustomerTerms));
        }

        //private void lvCreditCharges_AboutToThrow_1(Context x, ShowArgs args)
        //{
        //    ShowCreditCharges();
        //}


        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void btn_edit_commission_percent_Click(object sender, EventArgs e)
        {
            if (((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanEditCommissionPercentInvoice, RzWin.Context.xUser))
            {
                ctl_commission_percent.Enabled = !ctl_commission_percent.Enabled;
                ctl_override_stock_commission.Enabled = ctl_commission_percent.Enabled;

            }
        }

        private void ctl_override_stock_commission_CheckedChanged(object sender, EventArgs e)
        {
            CurrentInvoice.override_stock_commission = ctl_override_stock_commission.Checked;
            // CurrentOrder.Update(RzWin.Context);
        }

        private void gbTotals_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblCharges_Click(object sender, EventArgs e)
        {

        }

        private void lblSubTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
