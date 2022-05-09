using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Core;
using NewMethod;
using Tools;
using RzInterfaceWin.Dialogs;

namespace Rz5
{
    public partial class ViewHeaderSales : ViewHeader
    {
        //Protected Variables
        protected ordhed_sales CurrentSalesOrder
        {
            get
            {
                return (ordhed_sales)CurrentOrder;
            }
        }

        private List<ordhed_purchase> Purchases;

        private List<ordhed_invoice> Invoices;

        //Constructors
        public ViewHeaderSales()
        {
            InitializeComponent();
            //HeaderSet("GreenBar.gif");
        }
        //Public Override Functions
        public override void Init(Item item)
        {
            base.Init(item);
            //RzWin.Context.xSys.RegisterNotifyClass(this, "ordhed_sales");
            CurrentSalesOrder.DetailsListCompleteReady(RzWin.Context);

        }
        protected override void InitUn()
        {
            base.InitUn();
            try
            {
                //NewMethod.RzWin.Context.xSys.UnRegisterNotifyClass(this);
            }
            catch { }
        }


        public override void CompleteLoad()
        {
            base.CompleteLoad();
            ctl_credit_caption.LoadList(true);

            SetBuyerValues();
            //LoadOtherChargeCredit();
            CheckManagerOverride();
            CheckPermissions();
            //KT Refactored from RzSensible 10-7-2015
            LoadCanceled();
            //LoadCreditCharges();
            LoadPOPayments();
            LoadDeductions();
            LoadValidation();
            TabOrder();
        }

        private void LoadValidation()
        {
            //vm.CompleteLoad(CurrentSalesOrder);
            //llValidationStage.Text = CurrentSalesOrder.validation_stage;
            bool isHold = validation_tracking.CheckIsHoldStage(RzWin.Context, CurrentSalesOrder.validation_stage);
             string symbol = "✔";
            if (isHold)
                symbol = "⚠";
            if (isHold)
            {
                btnValidation.ForeColor = System.Drawing.Color.Red;
                btnValidation.Text = symbol +" " + CurrentSalesOrder.validation_stage + " "+symbol;

            }
            else
            {
                btnValidation.ForeColor = System.Drawing.Color.Green;
                btnValidation.Text = symbol + " " + CurrentSalesOrder.validation_stage + " " + symbol;
            }


        }


        private void btnValidation_Click(object sender, EventArgs e)
        {
            try
            {
                frmValidationManagement vm = new frmValidationManagement();
                vm.StartPosition = FormStartPosition.CenterScreen;
                vm.CompleteLoad(CurrentSalesOrder);
                vm.ShowDialog();



            }
            catch (Exception ex)
            {
                RzWin.Context.Error(ex.Message);
            }
        }


        private void lblValidationStage_Click(object sender, EventArgs e)
        {
           
        }



        private void SetBuyerValues()
        {
            buyer.CurrentObject = CurrentOrder;
            buyer.CurrentIDField = "orderbuyerid";
            buyer.CurrentNameField = "buyername";
            //KT Ensure there is always a buyer name and ID to support Overbuys, etc.
            if (!Tools.Strings.StrExt(CurrentOrder.buyername))
            {
                buyer.SetUserInfo(CurrentOrder.base_mc_user_uid, CurrentOrder.agentname);
                CurrentOrder.Update(RzWin.Context, false);
            }
            else
                buyer.SetUserName();

        }




        public override void CompleteSave()
        {
            string duplicatePoSales = "";
            if (DuplicateCustomerPOExists(RzWin.Context, out duplicatePoSales))
            {
                RzWin.Leader.Error("This customer PO is already associated with the following Sales Orders: " + duplicatePoSales);
                return;
            }
            SaveOtherChargeCredit();
            SetBuyerValues();
            ContextRz x = RzWin.Context;
            validation_tracking vt = validation_tracking.GetMostRecentByOrderID(RzWin.Context, CurrentSalesOrder);//x.TheSysRz.TheOrderLogic.TrackValidation(x, CurrentSalesOrder);
            //Saving Delay
            base.CompleteSave();
        }
        private bool DuplicateCustomerPOExists(ContextRz context, out string soNumbers)
        {
            soNumbers = "";
            if (CurrentOrder.orderreference.Trim().ToLower() == "ncnr")
                return false;
            //Get a list of orders that have the same customer po
            string currentCustomerPO = ctl_orderreference.GetValue_String().Trim();

            if (string.IsNullOrEmpty(currentCustomerPO))
                return false;
            if (CurrentCompany == null)
                return false;
            ArrayList soList = context.QtC("ordhed_sales", "select * from ordhed_sales where base_company_uid = '" + CurrentCompany.unique_id + "'  and unique_id != '" + CurrentSalesOrder.unique_id + "' and orderreference = '" + currentCustomerPO + "'");
            if (soList.Count > 0)
            {
                List<string> soNumberList = new List<string>();
                foreach (ordhed_sales s in soList)
                    soNumberList.Add(s.ordernumber);

                if (soNumberList.Count > 0)
                {
                    soNumbers = string.Join(",", soNumberList);
                    return true;
                }
                return false;
            }

            return false;

        }

        //Protected Override Functions
        protected override void ChangeHandler(String strClass, bool adds)
        {
            try
            {
                switch (strClass.ToLower().Trim())
                {
                    //case "ordhed_sales":
                    //    CompleteLoad_Totals();
                    //    break;
                    default:
                        base.ChangeHandler(strClass, adds);
                        break;
                }
            }
            catch { }
        }

        //KT Refactored from RzSensible 10-7-2015
        protected override void CompleteLoad_Company(Rz5.company c)
        {
            lblFinancials.Visible = false;
            base.CompleteLoad_Company(c);
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
                List<orddet> l = CurrentSalesOrder.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;

                    if (Tools.Strings.StrExt(track))
                        track += ",";
                    track += ln.tracking_invoice.Replace("\r\n", ",");
                    ListViewItem xLst = lvShipVia.Items.Add(ln.linecode_sales.ToString());
                    xLst.SubItems.Add(ln.shipvia_invoice);
                    xLst = lvAccount.Items.Add(ln.linecode_sales.ToString());
                    xLst.SubItems.Add(ln.shippingaccount_invoice);
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
                CurrentSalesOrder.shipvia = ctl_shipvia.GetValue_String();
                CurrentSalesOrder.Update(RzWin.Context);
                List<orddet> l = CurrentSalesOrder.DetailsList(RzWin.Context);
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
                CurrentSalesOrder.shippingaccount = ctl_shippingaccount.GetValue_String();
                CurrentSalesOrder.Update(RzWin.Context);
                List<orddet> l = CurrentSalesOrder.DetailsList(RzWin.Context);
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


            //lblTestTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Purchases.Count.ToString();            
            lblTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblCost.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblGrossProfit.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";


            if (CurrentSalesOrder == null)
                return;

            //KT Invoke the new cost calculation

            //This takes a long time
            CurrentSalesOrder.CalculateAllAmounts(RzWin.Context);




            lblTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentSalesOrder.sub_total);   //.ordertotal
            //KT PO Balance Cost
            lblCost.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat((CurrentSalesOrder.costamount + CurrentSalesOrder.total_po_deductions) - CurrentSalesOrder.po_payment);
            //KT Total Line Cost
            lblLineCost.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentSalesOrder.total_line_cost);
            lblGrossProfit.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentSalesOrder.profitamount);
            lblAllSubtractions.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentSalesOrder.total_profit_subtractions);
            lblCurProfit.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentSalesOrder.current_net_profit);
            lblNetProfit.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentSalesOrder.net_profit);
            lblMargin.Text = RzWin.Context.Sys.TheOrderLogic.GetMarginNetPercent(CurrentSalesOrder.sub_total - CurrentSalesOrder.total_line_cost, CurrentSalesOrder.sub_total);
            lblPerc.Text = RzWin.Context.Sys.TheOrderLogic.GetMarginNetPercent(CurrentSalesOrder.profitamount, CurrentSalesOrder.total_line_cost);
            lblNetPerc.Text = RzWin.Context.Sys.TheOrderLogic.GetMarginNetPercent(CurrentSalesOrder.net_profit, CurrentSalesOrder.total_line_cost + CurrentSalesOrder.total_profit_subtractions);
            lblPO_PaymentsAmnt.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentSalesOrder.po_payment);
            lblCreditsAmnt.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentSalesOrder.total_Credits);
            lblChargesAmnt.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentSalesOrder.total_Charges);
            lblAllSubtractions.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentSalesOrder.total_profit_subtractions + CurrentSalesOrder.total_Credits);
        }


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


        protected override void CompleteLoad_Status()
        {

            base.CompleteLoad_Status();
            CurrentSalesOrder.LoadMissingProperties(RzWin.Context);
            LoadCompletionReport();
            bool so_verify = CurrentSalesOrder.MissingPropertiesList.Count == 0;//Missing Logics
            int ready = CurrentSalesOrder.DetailsListCompleteReady(RzWin.Context, true).Count;//Lines that Area ready to cmomplete.
            CheckLineBGColor();

            //if Header is not Complete, we still need to be able to cut PO's for other complete lines.
            //if (CurrentSalesOrder.validation_stage.ToLower().Contains("hold"))
            //    return;

            if (CurrentSalesOrder.MissingPropertiesList.Count > 0)//Check count of Missing Properties
                return;
            if (ready > 0)//Had to remove so_verify, was blocking good lines with any other line had missing properties, 
            {
                gbAction1.Visible = true;
                cmdAction1.ImageKey = "SalesOrderActiveNew.png";
                lblLineStatus1.Text = Tools.Strings.PluralizePhrase("Hold Line", ready);

            }
            int invoice_able = CurrentSalesOrder.DetailsListInvoiceable(RzWin.Context).Count;
            if (invoice_able > 0 && so_verify)
            {
                gbAction2.Visible = true;
                cmdAction2.ImageKey = "StartShipment.png";
                lblLineStatus2.Text = Tools.Strings.PluralizePhrase("Open Line", invoice_able);
            }




        }
        protected override void Action1()
        {
            ContextRz xx = (ContextRz)RzWin.Context.Clone();
            String cid = xx.TheDelta.StartChangeCache();
            SalesOrderCompleteResult soCompleteResult = CurrentSalesOrder.CompleteSalesOrder(xx);
            xx.TheDelta.EndChangeCache(RzWin.Context, cid);
            if (xx.xSys.Recall)
                xx.xSys.RecallActionLog(CurrentSalesOrder, "Sales Order Complete", xx.xUser);
        }
        protected override void Action2()
        {
            //Invoicing the Sale
            Invoices = CurrentSalesOrder.CreateInvoice(RzWin.Context);

        }



        protected override void Action1Complete()
        {
            base.Action1Complete();
            CompleteLoad();
        }
        protected override void Action2Complete()
        {
            base.Action2Complete();
            //if invoices == null then it won't evaluate Invoices.Count because of the ||, right?
            if (Invoices == null || Invoices.Count == 0)
            {
                CompleteLoad();
                return;
            }
            foreach (ordhed_invoice i in Invoices)
            {
                RzWin.Context.Show(i);
            }
            SendCloseRequest();
        }


        //KT 9-1-2015 - Credits & Charges tab
        protected void LoadCreditsCharges()
        {
            //KT Set Tab Title Data / Text
            ArrayList RelatedInvoices = CurrentOrder.GetRelatedInvoices(RzWin.Context);
            if (RelatedInvoices.Count > 0)
            {


                List<string> RelatedInvoiceIDs = new List<string>();
                foreach (ordhed_invoice i in RelatedInvoices)
                {
                    RelatedInvoiceIDs.Add(i.unique_id);
                }

                Int64 totalHits = RzWin.Context.SelectScalarInt64("select count(*) from ordhit where the_ordhed_uid IN (" + Tools.Data.GetIn(RelatedInvoiceIDs) + ")");
                double SumHits = RzWin.Context.SelectScalarDouble("select SUM(hit_amount) from ordhit where the_ordhed_uid IN (" + Tools.Data.GetIn(RelatedInvoiceIDs) + ")");
                tabCreditsCharges.Text = "Credits.Charges(" + totalHits.ToString() + ")" + " - Total: " + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(SumHits);

                //Load Charges ListView
                ListArgs a = new ListArgs(RzWin.Context);
                a.AddAllow = false;
                //a.AddCaption = "Add Payment";
                a.TheClass = "ordhit";
                a.TheLimit = 200;
                a.TheOrder = "date_created desc";
                //a.TheTable = "checkpayment";
                a.TheTemplate = "invoices_by_order";
                //a.TheTemplate = "related_ordhits";
                //a.TheInnerJoin = "ordhed ON checkpayment.base_ordhed_uid = ordhed.unique_id";
                a.TheWhere = "the_ordhed_uid IN (" + Tools.Data.GetIn(RelatedInvoiceIDs) + ")";
                nListCreditsCharges.ShowData(a);
            }
            else
                tsDetails.TabPages.Remove(tabCreditsCharges);


        }




        //Private Functions
        private void ClearBGColor()
        {
            foreach (ListViewItem xLst in details.GetListViewControl().Items)
            {
                xLst.BackColor = Color.White;
            }
        }
        private void CheckLineBGColor()
        {
            ClearBGColor();
            List<orddet_line> lines = CurrentSalesOrder.DetailsListCompleteReady(RzWin.Context, true);
            if (lines.Count <= 0)
                return;
            ArrayList a = new ArrayList();
            foreach (orddet_line l in lines)
            {
                if (l.Status == Enums.OrderLineStatus.Hold)
                    a.Add(l.unique_id);
            }
            foreach (ListViewItem xLst in details.GetListViewControl().Items)
            {
                string id = xLst.Tag.ToString();
                if (a.Contains(id))
                    xLst.BackColor = Color.LightGreen;
            }
        }
        private void LoadOtherChargeCredit()
        {


            if (CurrentSalesOrder == null)
                return;
            if (CurrentSalesOrder.credit_amount == 0)
                return;
            if (CurrentSalesOrder.credit_amount < 0)
            {
                optCredit.Checked = true;
                ctl_credit_amount.SetValue((CurrentSalesOrder.credit_amount * -1));
            }
            else
                optCharge.Checked = true;
        }
        private void SaveOtherChargeCredit()
        {
            if (CurrentSalesOrder == null)
                return;
            if (ctl_credit_amount.GetValue_Double() == 0)
                return;
            if (optCharge.Checked)
                return;
            CurrentSalesOrder.credit_amount = (ctl_credit_amount.GetValue_Double() * -1);
            CurrentSalesOrder.Update(RzWin.Context);
            CompleteLoad_Totals();
        }

        private void CheckPermissions()
        {

            if (!RzWin.Context.CheckPermit(NewMethod.Permissions.ThePermits.AddOtherChargeCredit))
                gbChargeCredit.Enabled = false;
            else
                gbChargeCredit.Enabled = true;

            ctl_terms.Enabled = (RzWin.Context.CheckPermit(NewMethod.Permissions.ThePermits.CanSetCustomerTerms));
            chkTermsOverride.Enabled = (RzWin.Context.CheckPermit(NewMethod.Permissions.ThePermits.CanOverridePaymentTerms));

            if (RzWin.Context.xUser.IsDeveloper())
            {
                lblCurProfitText.Visible = true;
                lblCurProfit.Visible = true;
            }

        }
        private void CheckManagerOverride()
        {
            chkTermsOverride.zz_CheckValue = CurrentSalesOrder.is_TermsOverride;
            if (ctl_terms.GetValue().ToString() == "TBD")
                chkTermsOverride.Visible = true;
        }

        private void ctl_terms_SelectionChanged(Tools.GenericEvent e)
        {
            CheckManagerOverride();
        }


        private void ctl_TermsOverride_CheckChanged(object sender)
        {
            CurrentSalesOrder.is_TermsOverride = chkTermsOverride.zz_CheckValue;
            CurrentSalesOrder.Update(RzWin.Context);
        }



        //Refactored from Rz5 10-7-2015
        private void LoadCreditCharges()
        {
            ListArgs args = new ListArgs(RzWin.Context);
            args.TheClass = "ordhit";
            args.TheLimit = 200;
            args.AddCaption = "Add Credit/Charge";
            args.TheOrder = "date_created desc";
            args.TheTable = "ordhit";
            args.TheTemplate = "ordhit";
            args.TheWhere = "the_ordhed_uid = '" + CurrentOrder.unique_id + "'";
            if (!RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, NewMethod.Permissions.ThePermits.AddOtherChargeCredit, RzWin.Context.xUser))
                args.AddAllow = false;
            else
                args.AddAllow = true;
            //lvCreditCharges.ShowData(args);
        }
        private void LoadCanceled()
        {



            try
            {
                Int64 i = RzWin.Context.SelectScalarInt64("select count(*) from orddet_line_canceled where orderid_sales ='" + CurrentOrder.unique_id + "'");
                tabCanceled.Text = "Canceled(" + i.ToString() + ")";


                ListArgs a = new ListArgs(RzWin.Context);
                a.AddAllow = false;
                a.TheCaption = "Canceled Lines";
                a.TheClass = "orddet_line";
                a.TheLimit = 200;
                a.TheOrder = "linecode_sales asc";
                a.TheTable = "orddet_line_canceled";
                a.TheTemplate = "orddet_line_canceled_sales";
                a.TheWhere = "orderid_sales = '" + CurrentOrder.unique_id + "'";
                lvCanceled.ShowData(a);
            }
            catch { }
        }
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

        private void AddCreditCharges()
        {
            try
            {
                Rz5.ordhit h = Rz5.ordhit.New(RzWin.Context);
                h.the_ordhed_uid = CurrentOrder.unique_id;
                //h.deduct_profit = true;
                frmCreditCharge c = new frmCreditCharge();
                c.CompleteLoad(RzWin.Context, h);
                c.ShowDialog();
            }
            catch { }
        }

        //Control Events
        //Refactored from Rz5 10-7-2015
        private void lvCanceled_AboutToThrow(Core.Context x, Core.ShowArgs args) // not sure what this does, doesn't seems ot be involved in loading the cancelled lines
        {

        }

        //private void CheckCanceledTab()
        //{
        //    Int64 i = RzWin.Context.SelectScalarInt64("select count(*) from orddet_line_canceled where orderid_sales ='" + CurrentOrder.unique_id + "'");
        //        tabCanceled.Text = "Canceled(" + i.ToString() + ")";           
        //}

        public void LoadPOPayments()
        {
            List<ordhed_purchase> poList = new List<ordhed_purchase>();
            List<checkpayment> paymentList = new List<checkpayment>();
            foreach (ordhed_purchase p in CurrentOrder.GetRelatedPurchases(RzWin.Context))
            {
                poList.Add(p);
            }
            if (poList.Count > 0) //KT - If stock sale, there will be no PO's, which will break the SQL
            {

                foreach (ordhed_purchase p in poList)
                {
                    ArrayList ap = p.GetRelatedPayments(RzWin.Context);
                    foreach (checkpayment pp in ap)
                        paymentList.Add(pp);
                }

                int count = 0;
                double total = 0;

                if (paymentList.Count > 0)
                {
                    ItemsInstance pmtLiveItems = new ItemsInstance();
                    foreach (checkpayment p in paymentList)
                        pmtLiveItems.Add(RzWin.Context, p);

                    count = paymentList.Count;
                    total = paymentList.Sum(s => s.transamount);
                    tabPOPayments.Text = "PO Payments(" + count.ToString() + ")" + " - Total: " + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(total);
                    //if (Tools.Misc.IsDevelopmentMachine())
                    //    RzWin.Context.TheLeader.Error("Developer: LV refreshed from DB, need to reorg with VarRefs (not sure how yet)- Joel");
                    ListArgs a = new ListArgs(RzWin.Context);
                    a.AddAllow = false;
                    //a.AddCaption = "Add Payment";
                    a.TheClass = "checkpayment";
                    a.TheLimit = 200;
                    a.TheOrder = "transdate desc";
                    //a.TheTable = "checkpayment";
                    a.TheTemplate = "payments_by_order";
                    a.LiveItems = pmtLiveItems;
                    //a.TheInnerJoin = "ordhed ON checkpayment.base_ordhed_uid = ordhed.unique_id";
                    //a.TheWhere = "base_ordhed_uid IN (" + Tools.Data.GetIn(paymentList.Select(s => s.base_ordhed_uid).ToList()) + ")";

                    nListPayments.ShowData(a);
                }
                else
                {
                    tsDetails.TabPages.Remove(tabPOPayments);
                }

            }
            else
            {
                tsDetails.TabPages.Remove(tabPOPayments);
            }


        }

        public void LoadDeductions()
        {
            List<profit_deduction> allDeductions = RzWin.Context.TheSysRz.TheProfitLogic.GetDeductionsForOrder(RzWin.Context, CurrentSalesOrder);

            Int64 dedCount = allDeductions.Count();
            double dedTotal = allDeductions.Where(w => !w.is_payroll_deduction).Sum(s => s.amount);
            tabDeductions.Text = "Deductions(" + dedCount.ToString() + ")" + " - Total: " + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(dedTotal);


            ItemsInstance dedLiveItems = new ItemsInstance();
            foreach (profit_deduction p in allDeductions)
                dedLiveItems.Add(RzWin.Context, p);

            ListArgs a = new ListArgs(RzWin.Context);
            a.AddAllow = false;
            a.TheClass = "profit_deduction";
            a.TheLimit = 200;
            a.TheOrder = "date_created desc";
            a.TheTemplate = "deductions_by_order";
            a.LiveItems = dedLiveItems;
            //a.TheWhere = "the_orddet_line_uid IN (select unique_id from orddet_line where orderid_sales ='" + CurrentOrder.unique_id + "') OR (sales_order_uid = '" + CurrentOrder.unique_id + "' AND LEN(isnull(the_orddet_line_uid, 0)) = 0)";
            //a.TheWhere = "the_orddet_line_uid IN (select unique_id from orddet_line where orderid_sales ='" + CurrentOrder.unique_id + "' AND linecode_sales > 0) OR sales_order_uid = '" + CurrentOrder.unique_id + "'";
            nListDeductions.ShowData(a);


        }



        //public void LoadDeductions()
        //{
        //    if (((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).ManageDeductions, RzWin.Context.xUser))
        //        nListDeductions.AllowActions = true;
        //    //Get a list of deductions for the order
        //    ArrayList dedArrList = RzWin.Context.QtC("profit_deduction", "select * from profit_deduction where the_orddet_line_uid IN(select unique_id from orddet_line where orderid_sales = '" + CurrentOrder.unique_id + "' AND linecode_sales > 0)");
        //    List<profit_deduction> dedList = new List<profit_deduction>();//For Linq
        //    foreach (profit_deduction d in dedArrList)
        //        dedList.Add(d);


        //    List<string> deductionIDs = dedList.Select(s => s.unique_id).ToList();
        //    ArrayList dedCanceled = RzWin.Context.TheSysRz.TheProfitLogic.GetCanceledDeductions(RzWin.Context, CurrentSalesOrder);
        //    if (dedCanceled != null)
        //        foreach (profit_deduction p in dedCanceled)
        //        {
        //            string cancelledDeductionID = p.unique_id;
        //            if (!deductionIDs.Contains(cancelledDeductionID))
        //                dedList.Add(p);
        //        }
        //    // Identify any costs against canceled lines.
        //    ArrayList canceledLines = RzWin.Context.TheSysRz.TheProfitLogic.GetCanceledLinesSales(RzWin.Context, CurrentSalesOrder.unique_id);
        //    //double canceledServiceCosts = CurrentSalesOrder.GetCanceledSeviceCosts(RzWin.Context, canceledLines);
        //    double canceledGcatCostss = CurrentSalesOrder.GetCanceledGcatCosts(RzWin.Context, canceledLines);

        //    foreach (orddet_line l in canceledLines)
        //    {

        //        if(l.service_cost > 0)
        //        {
        //            profit_deduction pd = new profit_deduction();
        //            pd.unique_id = l.unique_id; //We are setting this uid to the lines ID fro 2 reasons.  1) nList requires items to have a uid, these wouldn't have one. 2) I'll use this id to remove service cost from the proper canceled line.
        //            pd.name = "<canceled> " + l.fullpartnumber;
        //            pd.amount = l.service_cost;
        //            pd.date_created = l.date_created;
        //            pd.description = "service line";
        //            dedList.Add(pd);

        //        }
        //        if (l.fullpartnumber.ToLower().Contains("gcat"))
        //        {
        //            profit_deduction pd = new profit_deduction();
        //            //pd.unique_id = Guid.NewGuid().ToString();
        //            pd.unique_id = l.unique_id; //We are setting this uid to the lines ID fro 2 reasons.  1) nList requires items to have a uid, these wouldn't have one. 2) I'll use this id to remove service cost from the proper canceled line.
        //            pd.name = "<canceled> " + l.fullpartnumber;
        //            pd.amount = l.total_cost;
        //            pd.date_created = l.date_created;
        //            pd.description = "gcat line";
        //            dedList.Add(pd);
        //        }

        //    }

        //    //List<profit_deduction> serviceDeductions = RzWin.Context.TheSysRz.TheProfitLogic.GetAllServiceDeductions(RzWin.Context, CurrentSalesOrder).Cast<profit_deduction>().ToList();
        //    //if (serviceDeductions != null)
        //    //    dedList.AddRange(serviceDeductions);

        //    //List<service_line> listServiceDeductions = RzWin.Context.QtC("service_line", "select * from service_line where the_orddet_line_uid IN(select unique_id from orddet_line where orderid_sales = '" + CurrentOrder.unique_id + "' AND linecode_sales > 0)").Cast<service_line>().ToList();

        //    //List<service_line> listServiceDeductionsCenceled = RzWin.Context.QtC("service_line", "select * from service_line where the_orddet_line_uid IN(select unique_id from orddet_line_canceled where orderid_sales = '" + CurrentOrder.unique_id + "' AND linecode_sales > 0)").Cast<service_line>().ToList();

        //    //List<service_line> allServiceLines = listServiceDeductions.Union(listServiceDeductionsCenceled).ToList();
        //    //foreach (service_line sl in allServiceLines)
        //    //{
        //    //    profit_deduction p = new profit_deduction();
        //    //    p.name = sl.service_name;
        //    //    p.amount = sl.total_cost;
        //    //    dedList.Add(p);

        //    //}


        //    Int64 dedCount = dedList.Count();
        //    double dedTotal = dedList.Where(w => !w.is_payroll_deduction).Sum(s => s.amount);
        //    tabDeductions.Text = "Deductions(" + dedCount.ToString() + ")" + " - Total: " + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(dedTotal);


        //    ItemsInstance dedLiveItems = new ItemsInstance();
        //    foreach (profit_deduction p in dedList)
        //        dedLiveItems.Add(RzWin.Context, p);

        //    ListArgs a = new ListArgs(RzWin.Context);
        //    a.AddAllow = false;
        //    a.TheClass = "profit_deduction";
        //    a.TheLimit = 200;
        //    a.TheOrder = "date_created desc";
        //    a.TheTemplate = "deductions_by_order";
        //    a.LiveItems = dedLiveItems;
        //    //a.TheWhere = "the_orddet_line_uid IN (select unique_id from orddet_line where orderid_sales ='" + CurrentOrder.unique_id + "') OR (sales_order_uid = '" + CurrentOrder.unique_id + "' AND LEN(isnull(the_orddet_line_uid, 0)) = 0)";
        //    //a.TheWhere = "the_orddet_line_uid IN (select unique_id from orddet_line where orderid_sales ='" + CurrentOrder.unique_id + "' AND linecode_sales > 0) OR sales_order_uid = '" + CurrentOrder.unique_id + "'";
        //    nListDeductions.ShowData(a);





        //}



        private void TabOrder()
        {
            tsDetails.TabPages.Remove(tabAttachments);
            tsDetails.TabPages.Add(tabAttachments);
            tsDetails.TabPages.Remove(tabOther);

        }


        private void ShowDeduction()
        {
            profit_deduction d = (profit_deduction)nListDeductions.GetSelectedObject();
            if (d == null)
                return;
            frmDeduction f = new frmDeduction();
            orddet_line l = (orddet_line)RzWin.Context.QtO("orddet_line", "select * from orddet_line where unique_id = '" + d.the_orddet_line_uid + "'");
            if (l == null)//canceled
            {
                l = (orddet_line)RzWin.Context.QtO("orddet_line", ("select * from orddet_line_canceled where orderid_sales ='" + CurrentOrder.unique_id + "'"));
            }
            if (l == null)
                return;
            string Source = this.nListDeductions.Name;
            f.CompleteLoad(RzWin.Context, d, l, CurrentSalesOrder, Source);
            f.ShowDialog();
        }


        private void nListDeductions_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            profit_deduction p = (profit_deduction)nListDeductions.GetSelectedObject();
            //Grab the line, we use is in 2 cases below
            orddet_line l = (orddet_line)RzWin.Context.QtO("orddet_line", "select * from orddet_line where unique_id = '" + p.unique_id + "'");
            if (p.description == "service line")
            {
                if (p.name.Contains("<canceled<"))
                {

                    if (x.Leader.AskYesNo("This is a service cost which belongs to a canceled line.  Should this cost be removed from deductions?"))
                        RemoveCanceledServiceDeduction((ContextRz)x, p.unique_id);
                }
                else
                {
                    //Open the Service Order

                    ordhed_service svc = (ordhed_service)RzWin.Context.QtO("ordhed_service", "select * from ordhed_service where unique_id = '" + l.orderid_service + "'");
                    RzWin.Context.Show(svc);
                }

            }
            else if (p.description == "gcat line")
            {
                RzWin.Leader.Tell("This deduction is from the GCAT line " + l.fullpartnumber + " : Line " + l.linecode_sales + ".  It is derived from the unit_cost of that line.");
            }
            else
                ShowManageDeductionForm(x);
        }

        private void ShowManageDeductionForm(Core.Context x)
        {
            profit_deduction p = profit_deduction.GetById(RzWin.Context, nListDeductions.GetSelectedID());

            orddet_line l = orddet_line.GetById(RzWin.Context, p.the_orddet_line_uid);
            if (l != null)
                RzWin.Context.Show(new ShowArgsOrder(RzWin.Context, l, Enums.OrderType.Sales, "tabDeductions"));
            else//canceled
            {
                l = (orddet_line)RzWin.Context.QtO("orddet_line", ("select * from orddet_line_canceled where orderid_sales ='" + CurrentOrder.unique_id + "'"));
                if (l != null)
                    ShowDeduction();
                CompleteLoad();
            }
        }

        private void RemoveCanceledServiceDeduction(ContextRz x, string canceledLineID)
        {
            orddet_line canceledLine = (orddet_line)x.QtO("orddet_line", "select * from orddet_line_canceled where unique_id ='" + canceledLineID + "' ");
            if (canceledLine == null)
                throw new Exception("Could not find canceled service related to canceled line id: " + canceledLineID);
            canceledLine.service_cost = 0;
            canceledLine.Update(x);


        }

        private void nListDeductions_AboutToDelete(object sender, Core.ActArgs args)
        {

        }

        private void nListDeductions_AboutToAction(object sender, Core.ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                case "open":
                    {
                        ShowManageDeductionForm(RzWin.Context);
                        break;
                    }
                case "delete":
                    {

                        profit_deduction p = (profit_deduction)nListDeductions.GetSelectedObject();
                        if (p.description == "service line")
                        {
                            RzWin.Context.Leader.Tell("To Delete this service line deduction, please remove the service line from the service order.");
                            break;
                        }
                        else if (p.description == "gcat line")
                        {
                            RzWin.Context.Leader.Tell("To Delete this GCAT line deduction, please remove the GCAT line from the order, or reduce it's unit cost to 0.");
                            break;
                        }
                        RzWin.Context.Leader.Tell("If you want to edit or delete this Deduction, please double-click it and make your changes from the form that pops up.");
                        break;
                    }


            }

        }

        private void nListDeductions_FinishedAction(object sender, Core.ActArgs args)
        {


        }

        private void nListDeductions_FinishedFill(object sender)
        {

        }

        private void nListPayments_AboutToThrow(Context x, ShowArgs args)
        {

        }

        private void ShowPayment()
        {
            checkpayment p = (checkpayment)nListPayments.GetSelectedObject();

            if (p == null)
                return;
            view_checkpayment v = new view_checkpayment();
            v.CompleteLoad();
            v.Show();
        }

        private void nListPayments_FinishedAction(object sender, ActArgs args)
        {
            //Does this fire after updating PO?  Probably not.
        }

        private void btnRecalc_Click(object sender, EventArgs e)
        {
            CurrentSalesOrder.CalculateAllAmounts(RzWin.Context);
        }



        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        





        //private void btnFixComplete_Click(object sender, EventArgs e)
        //{

        //    LoadMissingProperties(true);
        //    ////List of required header props
        //    //List<string> requiredHeaderProps = new List<string>();

        //    ////List of required Detail Props
        //    //List<string> messages = new List<string>();
        //    //List<string> requiredDetailProps = new List<string>();

        //    //foreach (orddet_line l in CurrentSalesOrder.DetailsList(RzWin.Context))
        //    //{
        //    //    string message = "";

        //    //    bool b = l.Completeable(RzWin.Context, ref message, ref requiredDetailProps, false);
        //    //    //if (!b)
        //    //    //    if (!string.IsNullOrEmpty(fieldName))
        //    //    //        if (!requiredDetailProps.Contains(fieldName))
        //    //    //            requiredDetailProps.Add(fieldName);
        //    //}
        //    //if (requiredDetailProps.Count() > 0)
        //    //    //Pass them into     
        //    //    RzWin.Context.TheSysRz.TheOrderLogic.GetMissingProperties(RzWin.Context, requiredHeaderProps, requiredDetailProps, CurrentSalesOrder);
        //    //else
        //    //    RzWin.Leader.Tell("All fixable details have been entered.  Any Remaining issues must be corrected manually.");
        //}
    }
}
