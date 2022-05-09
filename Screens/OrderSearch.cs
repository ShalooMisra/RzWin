using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using Core;
using NewMethod;

namespace Rz5
{
    public partial class OrderSearch : UserControl
    {
        //Public Variables
        public OrderSearchViewBy ViewBy = new OrderSearchViewBy();
        private OrderSearchViewBy TheView;

        //KT Refactored from Rz5
        private string HTML = "";

        //Protected Variables
        protected DateTime LastLoad = DateTime.Now.Subtract(TimeSpan.FromDays(1));

        //Constructors
        public OrderSearch()
        {
            InitializeComponent();
            //KT Refactored from Rz5
            throb.BackColor = Color.White;
        }
        public virtual void CompleteLoad()
        {
            //tsOrders.TabPages.Remove(tabSearch);
            SetTemplates();
            DoResize();
            TypeCheck();
            //KT Refactored from RzSensible 6-29-15
            //ddlInvoiceStatus.LoadList("InvoicePaidStatus");
            ReportCriteriaDateRange r = new ReportCriteriaDateRange("Order Date");
            //r.DefaultOption = "This Month";
            r.DefaultOption = "Any Date";
            dtRange.Init(r);

            //If this user doesn't have permission to show all orders, set them as selected agent.
            if (!RzWin.Context.CheckPermit(Permissions.ThePermits.OpenAllOrders))
            {
                ctl_Agent.SetUserName(RzWin.Context.xUser.Name);
                ctl_Agent.Enabled = false;
            }
                
        }
        public virtual void DoResize()
        {
            try
            {
                wb.Left = 0;
                wb.Width = this.ClientRectangle.Width;
                wb.Top = this.ClientRectangle.Height - wb.Height;

                pOptions.Top = 0;
                pOptions.Left = 0;
                //pOptions.Height = this.ClientRectangle.Height;
                pOptions.Height = this.ClientRectangle.Height - (this.ClientRectangle.Height - wb.Top);
                tsOrders.Top = 0;
                tsOrders.Left = pOptions.Right;
                tsOrders.Width = this.Width - tsOrders.Left;
                //tsOrders.Height = this.Height;
                tsOrders.Height = pOptions.Height;
                tabHeight = tsOptions.Height;
                //tsOptions.Height = pOptions.ClientRectangle.Height - tsOptions.Top;
                tsOptions.Height = (pOptions.Height - tsOptions.Top) - 2;
                tsOptions.Left = 0;
                tsOptions.Width = pOptions.ClientRectangle.Width;

                throb.Left = wb.Left;
                throb.Top = wb.Top;
                throb.BringToFront();

                ctl_PoConfirmed.Top = ctl_Agent.Bottom - 5;
                ddlInvoiceStatus.Top = ctl_Agent.Bottom - 5;
                ctl_opportunity_stage.Top = ctl_Agent.Bottom - 5;



                //KT Original Resize Block
                //pOptions.Top = 0;
                //pOptions.Left = 0;
                //pOptions.Height = this.ClientRectangle.Height;
                //tsOrders.Top = 0;
                //tsOrders.Left = pOptions.Right;
                //tsOrders.Width = this.Width - tsOrders.Left;
                //tsOrders.Height = this.Height;

                //tabHeight = tsOptions.Height;
                //tsOptions.Height = pOptions.ClientRectangle.Height - tsOptions.Top;
                //tsOptions.Left = 0;
                //tsOptions.Width = pOptions.ClientRectangle.Width;
            }
            catch { }
        }
        protected void LastViewClear()
        {
            ViewBy.bRFQs = false;
            ViewBy.bFormalQuotes = false;
            ViewBy.bSalesOrders = false;
            ViewBy.bPurchases = false;
            ViewBy.bInvoices = false;
            ViewBy.bRMAs = false;
            ViewBy.bVendorRMAs = false;
            ViewBy.bService = false;
        }
        protected bool ordersLoaded = false;
        public virtual void LoadOrders(String tab)
        {
            if (LastLoad.Subtract(DateTime.Now).TotalMinutes >= 5)
            {
                LastViewClear();
            }

            wb.Clear();
            wb.ReloadWB();

            LastLoad = DateTime.Now;
            ordersLoaded = true;

            try
            {
                OrderSearchParameters p = TabParameters;
                //p.CurrentDetailTable = CurrentDetailTable;
                p.DetailType = ViewBy.CurrentOrderType;
                p.CurrentOrderClass = CurrentOrderClass;
                p.CurrentOrderTable = CurrentOrderTable;
                p.CurrentOrderType = ViewBy.CurrentOrderType;
                p.IncludeVoid = false;
                p.UnlimitedResults = false;
                p.RowLimit = 200;
                p.Agent = GetAgent();
                p.SelectedAgent = GetSelectedAgent();
                p.limit_by_user = !RzWin.User.SuperUser && !RzWin.User.CheckPermit(RzWin.Context, new Permissions().OpenAllOrders);
                switch (tab)
                {
                    case "RFQs":
                    case "Bids":
                        ViewBy.CurrentOrderType = Enums.OrderType.RFQ;
                        p.CurrentOrderType = ViewBy.CurrentOrderType;
                        p.CurrentOrderTable = "ordhed_rfq";
                        p.StartDate = GetDate("start");
                        p.EndDate = GetDate("end");
                        ViewBy.TheArgs = RzWin.Context.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet((ContextRz)RzWin.Form.TheContextNM, p);
                        //if (ViewBy.bRFQs)
                        //    break;
                        ViewBy.bRFQs = true;
                        lvRFQs.ShowData(ViewBy.TheArgs);
                        GetHTMLShowResults(ViewBy);
                        break;
                    case "Formal Quotes":
                        ViewBy.CurrentOrderType = Enums.OrderType.Quote;
                        p.CurrentOrderType = ViewBy.CurrentOrderType;
                        p.CurrentOrderTable = "ordhed_quote";
                        p.StartDate = GetDate("start");
                        p.EndDate = GetDate("end");
                        ViewBy.TheArgs = RzWin.Context.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet((ContextRz)RzWin.Form.TheContextNM, p);
                        //if (ViewBy.bFormalQuotes)
                        //    break;
                        ViewBy.bFormalQuotes = true;
                        lvFormalQuotes.ShowData(ViewBy.TheArgs);
                        GetHTMLShowResults(ViewBy);
                        break;
                    case "Sales Order":
                    case "Sales Orders":
                        ViewBy.CurrentOrderType = Enums.OrderType.Sales;
                        p.CurrentOrderType = ViewBy.CurrentOrderType;
                        p.CurrentOrderTable = "ordhed_sales";
                        p.StartDate = GetDate("start");
                        p.EndDate = GetDate("end");
                        ViewBy.TheArgs = RzWin.Context.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet((ContextRz)RzWin.Form.TheContextNM, p);
                        //if (ViewBy.bSalesOrders)
                        //    break;
                        ViewBy.bSalesOrders = true;
                        lvSalesOrders.ShowData(ViewBy.TheArgs);
                        GetHTMLShowResults(ViewBy);
                        break;
                    case "POs":
                        ViewBy.CurrentOrderType = Enums.OrderType.Purchase;
                        p.CurrentOrderType = ViewBy.CurrentOrderType;
                        p.CurrentOrderTable = "ordhed_purchase";
                        p.StartDate = GetDate("start");
                        p.EndDate = GetDate("end");
                        ViewBy.TheArgs = RzWin.Context.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet((ContextRz)RzWin.Form.TheContextNM, p);
                        //if (ViewBy.bPurchases)
                        //    break;
                        ViewBy.bPurchases = true;
                        lvPurchases.ShowData(ViewBy.TheArgs);
                        GetHTMLShowResults(ViewBy);
                        break;
                    case "Invoices":
                        ViewBy.CurrentOrderType = Enums.OrderType.Invoice;
                        p.CurrentOrderType = ViewBy.CurrentOrderType;
                        p.CurrentOrderTable = "ordhed_invoice";
                        p.StartDate = GetDate("start");
                        p.EndDate = GetDate("end");
                        ViewBy.TheArgs = RzWin.Context.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet((ContextRz)RzWin.Form.TheContextNM, p);
                        //if (ViewBy.bInvoices)
                        //    break;
                        ViewBy.bInvoices = true;
                        lvInvoices.ShowData(ViewBy.TheArgs);
                        GetHTMLShowResults(ViewBy);
                        break;
                    case "RMAs":
                        ViewBy.CurrentOrderType = Enums.OrderType.RMA;
                        p.CurrentOrderType = ViewBy.CurrentOrderType;
                        p.CurrentOrderTable = "ordhed_rma";
                        p.StartDate = GetDate("start");
                        p.EndDate = GetDate("end");
                        ViewBy.TheArgs = RzWin.Context.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet((ContextRz)RzWin.Form.TheContextNM, p);
                        //if (ViewBy.bRMAs)
                        //    break;
                        ViewBy.bRMAs = true;
                        lvRMAs.ShowData(ViewBy.TheArgs);
                        GetHTMLShowResults(ViewBy);
                        break;
                    case "Vendor RMAs":
                        ViewBy.CurrentOrderType = Enums.OrderType.VendRMA;
                        p.CurrentOrderType = ViewBy.CurrentOrderType;
                        p.CurrentOrderTable = "ordhed_vendrma";
                        p.StartDate = GetDate("start");
                        p.EndDate = GetDate("end");
                        ViewBy.TheArgs = RzWin.Context.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet((ContextRz)RzWin.Form.TheContextNM, p);
                        //if (ViewBy.bVendorRMAs)
                        //    break;
                        ViewBy.bVendorRMAs = true;
                        lvVendorRMAs.ShowData(ViewBy.TheArgs);
                        GetHTMLShowResults(ViewBy);
                        break;
                    case "Service":
                        ViewBy.CurrentOrderType = Enums.OrderType.Service;
                        p.CurrentOrderType = ViewBy.CurrentOrderType;
                        p.CurrentOrderTable = "ordhed_service";
                        p.StartDate = GetDate("start");
                        p.EndDate = GetDate("end");
                        ViewBy.TheArgs = RzWin.Context.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet((ContextRz)RzWin.Form.TheContextNM, p);
                        //if (ViewBy.bService)
                        //    break;
                        ViewBy.bService = true;
                        lvService.ShowData(ViewBy.TheArgs);
                        GetHTMLShowResults(ViewBy);
                        break;
                    case "Search":
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                RzWin.Context.Error(ex.Message);
            }
        }
        public virtual nSQL GetSQL_Order(Boolean bSuppliedLimit, Int32 limit, bool limit_by_user)
        {
            OrderSearchParameters p = SearchParametersCreate();
            //p.CurrentDetailTable = CurrentDetailTable;
            p.DetailType = ViewBy.CurrentOrderType;
            p.CurrentOrderClass = CurrentOrderClass;
            p.CurrentOrderTable = CurrentOrderTable;
            p.CurrentOrderType = ViewBy.CurrentOrderType;
            p.RowLimit = limit;
            p.bSuppliedLimit = bSuppliedLimit;
            p.limit_by_user = limit_by_user;
            ListArgs a = RzWin.Context.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet((ContextRz)RzWin.Form.TheContextNM, p);
            return a.SQL;
        }
        public virtual ListArgs RunSearch()
        {
            ViewBy.CurrentOrderType = GetOrderType();
            ListArgs args = GetListArgs();
            nSQL s = args.SQL;
            switch (ViewBy.CurrentOrderType)
            {
                case Enums.OrderType.Any:
                    lvSearch.ShowTemplate("order_search_results", "ordhed", RzWin.User.TemplateEditor);
                    break;
                case Enums.OrderType.Quote:
                    lvSearch.ShowTemplate("ORDERSEARCH-QUOTE", ordhed.MakeOrdhedName(Enums.OrderType.Quote), RzWin.User.TemplateEditor);
                    break;
                case Enums.OrderType.Sales:
                    lvSearch.ShowTemplate("ORDERSEARCH-SALES", ordhed.MakeOrdhedName(Enums.OrderType.Sales), RzWin.User.TemplateEditor);
                    break;
                case Enums.OrderType.Purchase:
                    lvSearch.ShowTemplate("ORDERSEARCH-PURCHASE", ordhed.MakeOrdhedName(Enums.OrderType.Purchase), RzWin.User.TemplateEditor);
                    break;
                case Enums.OrderType.Invoice:
                    lvSearch.ShowTemplate("ORDERSEARCH-INVOICE", ordhed.MakeOrdhedName(Enums.OrderType.Invoice), RzWin.User.TemplateEditor);
                    break;
                case Enums.OrderType.RMA:
                    lvSearch.ShowTemplate("ORDERSEARCH-RMA", ordhed.MakeOrdhedName(Enums.OrderType.RMA), RzWin.User.TemplateEditor);
                    break;
                case Enums.OrderType.VendRMA:
                    lvSearch.ShowTemplate("ORDERSEARCH-VENDRMA", ordhed.MakeOrdhedName(Enums.OrderType.VendRMA), RzWin.User.TemplateEditor);
                    break;
                case Enums.OrderType.RFQ:
                    lvSearch.ShowTemplate("ORDERSEARCH-RFQ", ordhed.MakeOrdhedName(Enums.OrderType.RFQ), RzWin.User.TemplateEditor);
                    break;
                case Enums.OrderType.Service:
                    lvSearch.ShowTemplate("ORDERSEARCH-SERVICE", ordhed.MakeOrdhedName(Enums.OrderType.Service), RzWin.User.TemplateEditor);
                    break;
            }
            ShowSearchResults(s);

            ViewBy.TheArgs = args;
            wb.Clear();
            wb.ReloadWB();
            GetHTMLShowResults(ViewBy);

            return args;
        }
        public virtual ListArgs GetListArgs()
        {
            OrderSearchParameters pars = GetOrderSearchParameters();
            ContextRz x = (ContextRz)RzWin.Form.TheContextNM;
            return RzWin.Context.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet(x, pars);
        }
        public virtual OrderSearchParameters GetOrderSearchParameters()
        {
            OrderSearchParameters p = CurrentParameters;
            //p.CurrentDetailTable = CurrentDetailTable;
            p.DetailType = ViewBy.CurrentOrderType;
            p.CurrentOrderClass = CurrentOrderClass;
            p.CurrentOrderTable = CurrentOrderTable;
            p.CurrentOrderType = ViewBy.CurrentOrderType;
            p.UnlimitedResults = lvSearch.UnlimitedResults;
            return p;
        }
        public void CompleteDispose()
        {
            try
            {
                this.tsOrders.SelectedIndexChanged -= new System.EventHandler(this.TS_SelectedIndexChanged);
                this.Resize -= new System.EventHandler(this.OrderSearch_Resize);

                this.ctl_Agent.ChangeUser -= new NewMethod.ChangeUserHandler(this.ctl_Agent_ChangeUser);
                this.ctl_OrderDateStart.DataChanged -= new NewMethod.ChangeHandler(this.ctl_OrderDateStart_DataChanged);
                this.cmdClear.Click -= new System.EventHandler(this.cmdClear_Click);
                this.cmdSearch.Click -= new System.EventHandler(this.cmdSearch_Click);
            }
            catch { }
        }
        public void DoSearch(String where, String order)
        {
            if (!Tools.Strings.StrExt(where))
                return;
            if (!tsOrders.TabPages.Contains(tabSearch))
            {
                tsOrders.TabPages.Insert(0, tabSearch);
            }
            tsOrders.SelectedTab = tabSearch;
            if (CurrentOrderClass != CurrentOrderTable)
                lvSearch.AlternateTableName = CurrentOrderTable;
            lvSearch.ShowData(CurrentOrderClass, where, order);
        }
        public String CurrentOrderClass
        {
            get
            {
                if (GetOrderType() != Enums.OrderType.Any)
                    return ordhed.MakeOrdhedName(GetOrderType());
                else
                    return "ordhed";
            }
        }
        public String CurrentOrderTable
        {
            get
            {
                if (ViewBy.CurrentOrderType != Enums.OrderType.Any)
                    return ordhed.MakeOrdhedName(ViewBy.CurrentOrderType);
                else
                    return "ordhed";
            }
        }
        public String CurrentDetailTable
        {
            get
            {
                if (ViewBy.CurrentOrderType != Enums.OrderType.Any)
                    return ordhed.MakeOrddetName(ViewBy.CurrentOrderType);
                String s = GetOrderType().ToString();
                if (Tools.Strings.StrExt(s))
                    return ordhed.MakeOrddetName(s);
                else
                    return "orddet";
            }
        }
        //Private Functions

        private void GetHTMLShowResults(Rz5.OrderSearchViewBy v)
        {
            TheView = v;
            if (bgw.IsBusy)
                return;
            throb.Visible = true;
            throb.ShowThrobber();
            //throb.BringToFront();
            bgw.RunWorkerAsync();
        }


        private void SetTemplates()
        {
            lvSearch.ShowTemplate("order_search_results", "ordhed", RzWin.User.TemplateEditor);
            //lvClip.ShowTemplate("search_order_a", "ordhed", Rz3App.xUser.TemplateEditor);
            //if (Rz3App.xLogic.UseDistributedOrders)
            //{
            //}
            //else
            //{
            lvFormalQuotes.ShowTemplate("ORDERSEARCH-QUOTE", ordhed.MakeOrdhedName(Enums.OrderType.Quote), RzWin.User.TemplateEditor);
            lvSalesOrders.ShowTemplate("ORDERSEARCH-SALES", ordhed.MakeOrdhedName(Enums.OrderType.Sales), RzWin.User.TemplateEditor);
            lvPurchases.ShowTemplate("ORDERSEARCH-PURCHASE", ordhed.MakeOrdhedName(Enums.OrderType.Purchase), RzWin.User.TemplateEditor);
            lvInvoices.ShowTemplate("ORDERSEARCH-INVOICE", ordhed.MakeOrdhedName(Enums.OrderType.Invoice), RzWin.User.TemplateEditor);
            lvRMAs.ShowTemplate("ORDERSEARCH-RMA", ordhed.MakeOrdhedName(Enums.OrderType.RMA), RzWin.User.TemplateEditor);
            lvVendorRMAs.ShowTemplate("ORDERSEARCH-VENDRMA", ordhed.MakeOrdhedName(Enums.OrderType.VendRMA), RzWin.User.TemplateEditor);
            lvRFQs.ShowTemplate("ORDERSEARCH-RFQ", ordhed.MakeOrdhedName(Enums.OrderType.RFQ), RzWin.User.TemplateEditor);
            lvService.ShowTemplate("ORDERSEARCH-SERVICE", ordhed.MakeOrdhedName(Enums.OrderType.Service), RzWin.User.TemplateEditor);
            //lvNonInvoiced.ShowTemplate("ORDERSEARCH-SALES", ordhed.MakeOrdhedName(Enums.OrderType.Sales), Rz3App.xUser.TemplateEditor);
            //lvNonShipped.ShowTemplate("ORDERSEARCH-INVOICE", ordhed.MakeOrdhedName(Enums.OrderType.Invoice), Rz3App.xUser.TemplateEditor);
            //lvNonReceived.ShowTemplate("ORDERSEARCH-PURCHASE", ordhed.MakeOrdhedName(Enums.OrderType.Purchase), Rz3App.xUser.TemplateEditor);
            //}
        }
        private nSQL GetSQL_Order()
        {
            return GetSQL_Order(false, 0, false);
        }
        private void ShowSearchResults(nSQL n)
        {
            if (!tsOrders.TabPages.Contains(tabSearch))
            {
                tsOrders.TabPages.Insert(0, tabSearch);
            }
            tsOrders.SelectedTab = tabSearch;
            lvSearch.ShowData(n);
        }
        private String GetNonWhere(String ordtype)
        {
            String where = "";
            Enums.OrderType type = Enums.OrderType.Any;
            switch (ordtype.ToLower().Trim())
            {
                case "sales":
                    type = Enums.OrderType.Sales;
                    where = " isnull(isvoid, 0) = 0 and unique_id not in (select orderid1 from ordlnk where ordertype1 = 'sales' and ordertype2 = 'invoice')";
                    return where;
                case "invoice":
                    type = Enums.OrderType.Invoice;
                    break;
                case "purchase":
                    type = Enums.OrderType.Purchase;
                    break;
            }
            where = "unique_id in (select base_ordhed_uid from " + ordhed.MakeOrddetName(type) + " where isnull(" + ordhed.MakeOrddetName(type) + ".quantityfilled,0) <=0 and isnull(" + ordhed.MakeOrddetName(type) + ".quantityordered,0) > 0 and ordertype = '" + ordtype + "')";
            return where;
        }
        //Control Events
        private void OrderSearch_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void TS_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoResize();
            LoadOrders(tsOrders.SelectedTab.Text);
        }
        private void SearchOptions_SearchClick()
        {
            RunSearch();
        }
        public virtual OrderSearchParameters CurrentParameters
        {
            get
            {
                OrderSearchParameters ret = SearchParametersCreate();
                ret.Agent = GetAgent();
                ret.SelectedAgent = GetSelectedAgent();
                ret.CompanyName = GetCompanyName();
                ret.CompanyType = GetCompanyType();
                ret.StartDate = GetDate("start");
                ret.EndDate = GetDate("end");
                ret.ContactName = GetContactName();
                ret.OrderNumber = GetOrderNumber();
                ret.HubspotDealID = GetHubspotDealID();
                ret.OrderStatus = GetOrderStatus();
                ret.OrderTotal = GetOrderTotal();
                ret.OrderTotalType = GetOrderTotalType();
                ret.OrderType = GetOrderType();
                ret.PartNumber = GetPartNumber();
                ret.PhoneFaxEmail = GetPhoneFaxEmail();
                ret.RowLimit = GetRowLimit();
                ret.Terms = GetTerms();
                ret.TrackingNumber = GetTrackingNumber();
                ret.UnderPaid = GetUnderPaid();
                ret.OpenQuotes = OpenQuotes;
                ret.ConsignmentOnly = GetConsignmentOnly();
                ret.IncludeVoid = GetIncludeVoid();
                //KT
                ret.InvoiceStatus = GetInvoicePaidStatus();
                ret.oppportinity_stage = GetOpportunityStage();
                ret.OnlyConfirmedPOs = CheckConfirmedPOs();


                return ret;
            }
        }



        protected virtual bool GetIncludeVoid()
        {
            return optVoid.Checked;

        }

        protected virtual string GetInvoicePaidStatus()
        {
            //return "";
            return ddlInvoiceStatus.GetValue_String();
        }

        protected virtual string GetOpportunityStage()
        {
            //return "";
            return ctl_opportunity_stage.GetValue_String();
        }

        private string CheckConfirmedPOs()
        {
            return ctl_PoConfirmed.GetValue_String();
        }



        public virtual OrderSearchParameters TabParameters
        {
            get
            {
                OrderSearchParameters ret = SearchParametersCreate();
                ret.RowLimit = 200;
                return ret;
            }
        }
        protected virtual OrderSearchParameters SearchParametersCreate()
        {
            return new OrderSearchParameters();
        }
        protected virtual void Init()
        {
            ClearControl();
            LoadCompanySpecificPlugin(RzWin.Context.xSys);

            InitAgents();

            PartEnabledSet();
        }
        protected virtual void InitAgents()
        {
            ctl_Agent.AlternateChoices = RzWin.Logic.SalesPeople;
        }
        protected virtual void LoadCompanySpecificPlugin(SysNewMethod SystemInformation)
        {
            //
        }
        protected int tabHeight = 0;
        //Public Functions
        public virtual DateTime GetDate(String type)
        {
            //if (!Tools.Strings.StrExt(type))
            //    return Tools.Dates.NullDate;
            //switch (type.ToLower())
            //{
            //    case "start":
            //        return ctl_OrderDateStart.GetValue_Date();
            //    case "end":
            //        return ctl_OrderDateEnd.GetValue_Date();
            //    default:
            //        return Tools.Dates.NullDate;
            //}


            //KT Refactored from Rz 6-29-15 -  This is a complete replacement for the above, which is using an old control that was overridded i n RzSensible
            //You can still see the old controls in design view behind the new date picker.
            if (!Tools.Strings.StrExt(type))
                return Tools.Dates.NullDate;
            switch (type.ToLower())
            {
                case "start":
                    return dtRange.TheRange.TheRange.StartDate;
                case "end":
                    return dtRange.TheRange.TheRange.EndDate;
                default:
                    return Tools.Dates.NullDate;
            }
        }
        public virtual String GetOrderStatus()
        {
            String s = "";
            if (optClosed.Checked)
                return "closed";
            if (optOpen.Checked)
                return "open";
            return s;
        }
        public virtual n_user GetAgent()
        {
            string agentName = RzWin.Context.xUser.Name;
            string selectedAgentName = ctl_Agent.GetUserName();
            if (!string.IsNullOrEmpty(selectedAgentName))
                agentName = selectedAgentName;

            return (n_user)RzWin.Context.QtO("n_user", "select * from n_user where name = '" + agentName + "'");
            //return ctl_Agent.GetUserName();
        }
        public virtual n_user GetSelectedAgent()
        {
            
            string selectedAgentName = ctl_Agent.GetUserName().Trim();
            if (!string.IsNullOrEmpty(selectedAgentName))
                return (n_user)RzWin.Context.QtO("n_user", "select * from n_user where name = '" + selectedAgentName + "'");
            return null;
            //return ctl_Agent.GetUserName();
        }
        public virtual String GetPhoneFaxEmail()
        {
            return ctl_PhoneFaxEmail.GetValue_String().Trim();
        }
        public virtual String GetPartNumber()
        {
            return ctl_PartInternalNumber.GetValue_String().Trim();
        }
        public virtual String GetCompanyName()
        {
            return ctl_CompanyName.GetValue_String().Trim();
        }
        public virtual String GetContactName()
        {
            return ctl_ContactName.GetValue_String().Trim();
        }
        public virtual String GetCompanyType()
        {
            return ctl_CompanyType.GetValue_String().Trim();
        }
        public virtual String GetOrderNumber()
        {
            return ctl_OrderNumber.GetValue_String().Trim();
        }
        public virtual String GetHubspotDealID()
        {
            //return ctl_OrderNumber.GetValue_String();
            return "";
        }
        public virtual String GetTrackingNumber()
        {
            return ctl_Tracking.GetValue_String().Trim();
        }
        public virtual Enums.OrderType GetOrderType()
        {
            try
            {
                if (optAllTypes.Checked)
                    return Enums.OrderType.Any;

                if (optRFQ.Checked)
                    return Enums.OrderType.RFQ;

                if (optQuote.Checked)
                    return Enums.OrderType.Quote;

                if (optSales.Checked)
                    return Enums.OrderType.Sales;

                if (optPurchase.Checked)
                    return Enums.OrderType.Purchase;

                if (optInvoice.Checked)
                    return Enums.OrderType.Invoice;

                if (optRMA.Checked)
                    return Enums.OrderType.RMA;

                if (optVendorRMA.Checked)
                    return Enums.OrderType.VendRMA;

                if (optService.Checked)
                    return Enums.OrderType.Service;

                return Enums.OrderType.Any;
            }
            catch (Exception)
            { return Enums.OrderType.Any; }
        }
        public Int32 GetRowLimit()
        {
            if (chkUnlimited.Checked)
                return -1;
            return 200;
        }
        public virtual String GetTerms()
        {
            return "";
        }
        public virtual nDouble GetOrderTotal()
        {
            return 0;
        }
        public virtual String GetOrderTotalType()
        {
            return "";
        }
        public Boolean GetUnderPaid()
        {
            return chkUnderpaid.Checked;
        }
        public virtual Boolean GetConsignmentOnly()
        {
            //return false;  // chkConsignment.Checked;
            return chkConsignOnly.Checked;
        }

        //Private Functions
        protected virtual void ClearControl()
        {
            ctl_Agent.SetUserName("");
            //   if (Rz3App.xLogic.IsVoxx && !Rz3App.xUser.SuperUser)
            //      ctl_Agent.SetUserName(Rz3App.xUser.name);
            ctl_CompanyName.SetValue("");
            ctl_CompanyType.SetValue("");
            ctl_ContactName.SetValue("");
            ctl_OrderDateEnd.SetValue("");
            ctl_OrderDateStart.SetValue("");
            ctl_OrderNumber.SetValue("");
            ctl_PartInternalNumber.SetValue("");
            ctl_PhoneFaxEmail.SetValue("");
            ctl_Tracking.SetValue("");
            optAllTypes.Checked = true;
            optAll.Checked = true;
            //chkConsignment.Checked = false;
            ddlInvoiceStatus.SetValue("All");
            ctl_opportunity_stage.SetValue("Open");
            ctl_PoConfirmed.SetValue("All");
        }
        //Protected Functions
        protected override bool ProcessKeyPreview(ref Message m)
        {
            switch (m.WParam.ToInt32())
            {
                case 10:
                case 13:
                    RunSearch();
                    break;
            }

            return base.ProcessKeyPreview(ref m);
        }
        //Buttons
        private void cmdClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RunSearch();
        }
        //Control Events
        private void ctl_Agent_ChangeUser(GenericEvent e)
        {
            ChangeUser();
        }
        protected virtual void ChangeUser()
        {
            ArrayList a = RzWin.Logic.SalesPeople;

            NewMethod.n_user u = NewMethod.n_user.Choose(RzWin.Context, a, RzWin.User.SuperUser);
            if (u == null)
            {
                ctl_Agent.SetUserName("");
                return;
            }
            ctl_Agent.SetUserName(u.name);
        }
        private void ctl_OrderDateStart_DataChanged(GenericEvent e)
        {
            ctl_OrderDateEnd.Visible = Tools.Dates.DateExists(ctl_OrderDateStart.GetValue_Date());
        }
        public bool OpenQuotes
        {
            get
            {
                return chkOpenQuotes.Checked;
            }
        }
        private void optType_CheckedChanged(object sender, EventArgs e)
        {
            TypeCheck();
        }
        protected virtual void TypeCheck()
        {
            if (optQuote.Checked)
            {
                PositionExtraSearchControls(Enums.OrderType.Quote);
                chkOpenQuotes.Visible = true;
                ctl_opportunity_stage.Visible = true;
                ctl_opportunity_stage.LoadList("opportunity_stage_search_list");
                ctl_opportunity_stage.SetValue("All");
            }
            else
            {
                chkOpenQuotes.Checked = false;
                chkOpenQuotes.Visible = false;
                ctl_opportunity_stage.Visible = false;
            }

            if (optPurchase.Checked)
            {
                ctl_PoConfirmed.Visible = true;
                ctl_PoConfirmed.Caption = "PO Confirmed Status";
                ctl_PoConfirmed.LoadList("showConfirmedPOs");
                ctl_PoConfirmed.SetValue("All");
            }
            else
            {
                ctl_PoConfirmed.Visible = false;
            }



            //KT Refactored from RzSensible 6-29-15
            if (optAllTypes.Checked)
            {
                chkConsignOnly.Visible = false;
                chkConsignOnly.Checked = false;
            }
            else if (optInvoice.Checked)
            {
                PositionExtraSearchControls(Enums.OrderType.Invoice);
                ddlInvoiceStatus.Visible = true;
                ddlInvoiceStatus.Caption = "Invoice Payment Status";
                ddlInvoiceStatus.LoadList("InvoicePaidStatus");
                ddlInvoiceStatus.SetValue("All");
            }
            else if (optSales.Checked)
            {
                ddlInvoiceStatus.Visible = true;
                ddlInvoiceStatus.Caption = "Invoice Status";
                ddlInvoiceStatus.LoadList("SalesInvoiceStatus");
                ddlInvoiceStatus.SetValue("All");

            }
            else
            {
                chkConsignOnly.Visible = true;
                ddlInvoiceStatus.Visible = false;
            }
            //KT ENd TypeCheck refactor.



            PartEnabledSet();
        }
        void PartEnabledSet()
        {
            if (optAllTypes.Checked)
            {
                ctl_PartInternalNumber.Enabled = false;
                ctl_PartInternalNumber.SetValue("");
            }
            else
                ctl_PartInternalNumber.Enabled = true;
        }
        public void Search(OrderSearchShowArgs args)
        {
            if (args.TypeToSearch == Enums.OrderType.Any)
                return;

            switch (args.TypeToSearch)
            {
                case Enums.OrderType.Purchase:
                    optPurchase.Checked = true;
                    break;
            }

            ctl_PartInternalNumber.SetValue(args.PartToSearch);
            RunSearch();
        }
        public void SearchInvoices(String companyName)
        {
            ClearControl();
            ctl_CompanyName.SetValue(companyName);
            optInvoice.Checked = true;
            RunSearch();
        }

        protected void PositionExtraSearchControls(Enums.OrderType type)
        {
            switch (type)
            {
                case Enums.OrderType.Quote:
                    {
                        ctl_opportunity_stage.Location = new Point(ctl_opportunity_stage.Location.X, bar_lower.Location.Y + 5);
                        break;
                    }
                case Enums.OrderType.Invoice:
                    {
                        ddlInvoiceStatus.Location = new Point(ddlInvoiceStatus.Location.X, bar_lower.Location.Y + 5);
                        break;
                    }
            }
        }


        //Background Workers
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {

            HTML = RzWin.Context.TheLogicRz.GetOrderSearchTotalsHTML(RzWin.Context, TheView);
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
            throb.Visible = false;
            //throb.SendToBack();
            if (Tools.Strings.StrExt(HTML))
                wb.Add(HTML);
        }

        private void ctl_ContactName_Load(object sender, EventArgs e)
        {

        }

        private void ctl_PhoneFaxEmail_Load(object sender, EventArgs e)
        {

        }

        private void ctl_CompanyType_Load(object sender, EventArgs e)
        {

        }

        private void ctl_Agent_Load(object sender, EventArgs e)
        {

        }

        private void chkUnderpaid_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkConsignOnly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lvSalesOrders_AboutToThrow(Context x, ShowArgs args)
        {
          
        }
    }
}