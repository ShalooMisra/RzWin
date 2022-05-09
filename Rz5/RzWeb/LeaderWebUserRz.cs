using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;

using Core;
using Core.Display;
using CoreWeb;
using NewMethod;
using Rz5;
using RzWeb;
using Tools.Database;
using System.Data;
using NewMethod.Enums;
using RzWeb.Screens;
using Rz5.Reports;
using System.IO;

namespace Rz5.Web
{
    public class LeaderWebUserRz : LeaderWebUser, Rz5.ILeaderRz
    {
        public LeaderWebUserRz(System.Web.SessionState.HttpSessionState session, ViewHandle viewHandle, AsyncScreenHandle screenHandle)
            : base(session, viewHandle, screenHandle)
        {
        }
        //public void MonthlyPaymentsShow(ContextRz x) { }
        public void BFContactEmailScannerShow(ContextRz context) { }
        public void NCContactEmailScannerShow(ContextRz context) { }
        public void QCShow(ContextRz x, pack p, orddet_line l, string order_number, qualitycontrol q) { }
        public void ReceivePO(ContextRz context, List<orddet_line> lines) { }
        public void ReceiveRMA(ContextRz context, List<orddet_line> lines) { }
        public void ShipVRMA(ContextRz context, List<orddet_line> lines) { }
        public void ReceiveService(ContextRz context, List<orddet_line> lines) { }
        public void ShipService(ContextRz context, List<orddet_line> lines) { }
        public void ShipInvoice(ContextRz context, List<orddet_line> lines) { }
        public void SearchForCompany(ContextRz context, company cm, IGenericNotify notify) { throw new NotImplementedException(); }
        public account ShowQBAccountImportAssist(string acnt, string ref_num, double amnt, DateTime date) { throw new NotImplementedException(); }
        public void PostOrdersShow(ContextRz context)
        {
            ScreenShowNewWindow(context, new RzWeb.PostOrders(context));
        }
        public void JournalEntryShow(ContextRz context) 
        {
            ScreenShowNewWindow(context, new RzWeb.JournalEntry(context));
        }
        public void ReceivePaymentsShow(ContextRz context, company customer) 
        {
            ScreenShow(context, new RzWeb.ProcessPayments(context, PaymentType.Customer, customer));
        }
        public void PayBillsShow(ContextRz context, company vendor) 
        {
            ScreenShow(context, new RzWeb.ProcessPayments(context, PaymentType.Vendor, vendor));
        }
        public void ShowAccountingReport(ContextRz context, AccountingReport r) 
        {
            ScreenShow(context, new ViewAccountingReport(context, r));
        }
        public void DepositsShow(ContextRz context)
        {
            ScreenShow(context, new RzWeb.Deposits(context));
        }
        public void CheckRegisterShow(ContextRz context, account a) 
        {
            ScreenShow(context, new CheckRegister(context, a));
        }
        public void ReconcileShow(ContextRz context) 
        {
            LeaderWebUser lwu = (LeaderWebUser)context.Leader;
            DialogResultReconcileArgs result = (DialogResultReconcileArgs)lwu.ShowModalDialog(new ReconcileArgsGet(context));
            if (!result.Success)
                return;
            ScreenShowNewWindow(context, new ReconcileAccount(context, result.Args));
        }
        public void EditBudgetShow(ContextRz context)
        {
            budget b = null;
            string id = context.SelectScalarString("select top 1 unique_id from budget");
            LeaderWebUser lwu = (LeaderWebUser)context.Leader;
            if (!Tools.Strings.StrExt(id))
            {
                DialogResultBudgetArgs result = (DialogResultBudgetArgs)lwu.ShowModalDialog(new BudgetArgsGet(context));
                if (!result.Success)
                    return;
                b = result.Budget;
            }
            else
                b = budget.GetById(context, id);
            if (b == null)
                return;
            ScreenShowNewWindow(context, new BudgetEditor(context, b));
        }
        public account AskForNewAccount(ContextRz context, string parent_id)
        {
            LeaderWebUser lwu = (LeaderWebUser)context.Leader;
            DialogResultNewAccountArgs result = (DialogResultNewAccountArgs)lwu.ShowModalDialog(new NewAccountArgsGet(context, parent_id));
            if (!result.Success)
                return null;
            return result.Account;
        }
        public string GetAccountReportLink(string account_id, string text, AccountingReportAction a)
        {
            if (!Tools.Strings.StrExt(account_id))
                return text;
            account_id = account_id.Replace("notanid_", "").Trim();
            return "<a style=\"text-decoration: none; color: black;\" href=\"#\" onclick=\"Action('" + a.ScreenId + "', '" + a.SpotId + "', 'view_account_report', '" + account_id + "');\">" + text + "</a>";
        }
        public void ShowPrintCheck(ContextRz context, List<payment_out> l, account a = null) 
        {
            LeaderWebUser lwu = (LeaderWebUser)context.Leader;
            DialogResultPrintChecksArgs result = (DialogResultPrintChecksArgs)lwu.ShowModalDialog(new PrintChecksArgsGet(context));
            if (!result.Success)
                return;
            //print the checks?
        }

        public RzHook HookCreate(ContextRz context)
        {
            return new RzHook(context);
        }

        public void ReconcileBankShow(ContextRz context) { throw new NotImplementedException(); }
        public void ReconcileCCShow(ContextRz context) { throw new NotImplementedException(); }

        public void MergeChoose(ContextRz context, OrderLinkArgs args) { throw new NotImplementedException(); }
        public void PrintBarcodeLabel(ContextRz context, orddet_line line, string strLabel = "outgoing_line_item") { }
        public void ConsolidateCompanies(ContextRz context, ArrayList companies) { }        
        public bool IsWeb()
        {
            return true;
        }
        public bool CheckLineStatusForTotals(ContextRz x, orddet_line l)
        {
            return l.Status != Rz5.Enums.OrderLineStatus.Void;
        }
        public DateTime ChooseDate(DateTime def, string cap) 
        {
            return AskForDate(cap, def);
        }
        public bool ChooseCompany(ContextRz x, ref company comp, ref companycontact cont) { throw new NotImplementedException(); }
        public company ChooseCompany(ContextRz context)
        {
            return AskForCompany(context, "");
        }
        public company ChooseCompany(ContextRz context, String companyname, String companyemailaddress, String contactname, String companyphone, String companyfax, bool inhibitshow) { throw new NotImplementedException(); }
        public company AskForCompany(ContextRz context, String name)
        {
            String id = "";
            if( Tools.Strings.StrExt(name) )
                id = company.TranslateNameToID(context, name);
            return AskForCompany(context, "Choose", id);
        }
        public DateTime AskPostpone(ContextRz x, DateTime date)
        {
            return x.TheLeader.AskForDate("Postpone To:", date);
        }
        public Rz5.company AskForCompany(ContextRz x, String prompt, String default_companyid)
        {
            if (TheViewHandle == null)
                return null;
            WebThreadHandleAskCompany h = new WebThreadHandleAskCompany(x, prompt, default_companyid, x.CustomerId);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            Flow();
            h.TheEvent.WaitOne();
            Rz5.company c = null;
            if (h.New)
                c = NewCompany(x, h.Result);
            else
            {
                if (Tools.Strings.StrExt(h.Result))
                    c = Rz5.company.GetById(x, h.Result);
                else
                {
                    if (Tools.Strings.StrExt(h.NonResult))
                    {
                        if (x.TheLeader.AskYesNo("Would you like to add company " + h.NonResult + " to the system?"))
                            c = NewCompany(x, h.NonResult);
                    }
                }
            }
            return c;
        }
        public Rz5.companycontact AskForContact(ContextRz x, String prompt, String default_contactid, String company_id)
        {
            if (TheViewHandle == null)
                return null;
            WebThreadHandleAskContact h = new WebThreadHandleAskContact(x, prompt, default_contactid, company_id);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            Flow();
            h.TheEvent.WaitOne();
            Rz5.companycontact c = null;
            if (h.New)
                c = NewContact(x, h.Result);
            else
                c = Rz5.companycontact.GetById(x, h.Result);
            return c;
        }
        private Rz5.company NewCompany(ContextRz x, String comp_name)
        {
            Rz5.company c = null; 
            if (!Tools.Strings.StrExt(comp_name))
                comp_name = x.TheLeader.AskForString("Please enter new company name:");
            if (!Tools.Strings.StrExt(comp_name))
            {
                x.TheLeaderRz.Tell("The new company name cannot be blank.");
                return c;
            }
            string d_name = company.DistillCompanyName(comp_name);
            c = company.GetByDistilledName(x, d_name);
            if (c != null)
            {
                x.TheLeaderRz.Tell("This company already appears to exists.");
                return c;
            }
            c = company.New(x);
            c.companyname = comp_name;
            c.base_mc_user_uid = x.xUserRz.unique_id;
            c.agentname = x.xUserRz.name;
            c.Insert(x);
            return c;
        }
        private Rz5.companycontact NewContact(ContextRz x, String comp_id)
        {
            Rz5.companycontact cc = null; 
            Rz5.company c = Rz5.company.GetById(x, comp_id);
            if (c == null)
            {
                x.Leader.Tell("The company could not be found, a contact cannot be added.");
                return cc;
            }
            string cont_name = x.Leader.AskForString("Please enter new contact name:");
            if (!Tools.Strings.StrExt(cont_name))
                return cc;
            if (ContactExists(x, c, cont_name))
            {
                x.TheLeader.Tell("This contact already exists.");
                return null;
            }
            cc = c.AddContact(x);
            cc.contactname = cont_name;
            cc.Update(x);
            return cc;
        }
        private bool ContactExists(ContextRz x, Rz5.company c, String cont_name)
        {
            string id = x.SelectScalarString("select unique_id from companycontact where contactname = '" + x.Filter(cont_name) + "' and base_company_uid = '" + c.unique_id + "'");
            return Tools.Strings.StrExt(id);
        }
        public Rz5.partrecord AskForInventoryItem(ContextRz x, String prompt, String default_partnumber, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            if (TheViewHandle == null)
                return null;
            WebThreadHandleAskInventory h = new WebThreadHandleAskInventory(x, prompt, default_partnumber, x.CustomerId, screenHandle, viewHandle, session, page);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            Flow(); 
            h.TheEvent.WaitOne();
            if (h.Search)
                return AskForInventoryItem(x, prompt, h.PartNumber, screenHandle, viewHandle, session, page);
            string id = "";
            string[] str = Tools.Strings.Split(h.Result, "|");
            if (str.Length > 0)
                id = Tools.Strings.ParseDelimit(str[0], "_dot_", 2).Trim();
            if (!Tools.Strings.StrExt(id))
                return null;
            return Rz5.partrecord.GetById(x, id);
        }
        public Rz5.orddet_rfq AskForVendorBid(ContextRz x, String prompt, String default_partnumber, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            if (TheViewHandle == null)
                return null;
            WebThreadHandleAskBid h = new WebThreadHandleAskBid(x, prompt, default_partnumber, x.CustomerId, screenHandle, viewHandle, session, page);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            Flow();
            h.TheEvent.WaitOne();
            if (h.Search)
                return AskForVendorBid(x, prompt, h.PartNumber, screenHandle, viewHandle, session, page);
            string id = "";
            string[] str = Tools.Strings.Split(h.Result, "|");
            if (str.Length > 0)
                id = Tools.Strings.ParseDelimit(str[0], "_dot_", 2).Trim();
            if (!Tools.Strings.StrExt(id))
                return null;
            return Rz5.orddet_rfq.GetById(x, id);
        }
        public virtual bool IsApprovedMenuItem(ContextRz x, string item)
        {
            switch (item.ToLower().Trim())
            {
                case "parts":
                case "home":
                //case "email":
                //case "ar/ap":                
                case "people":
                case "orders":
                case "import":
                case "reports":
                case "panel":
                case "accounts":
                    return true;
                case "tools":
                    return x.xUserRz.IsDeveloper();
                default:
                    return false;
            }
        }
        public void ShowTransmitOrders(ContextRz context, List<ordhed> a, Enums.TransmitType ty) 
        {
            foreach (ordhed o in a)
            {
                ScreenShow(context, new RzWeb.OrderTransmit((ContextRz)context, o));
            }
        }
        public void CacheCompanies() {
            //nothing to do here
        }
        public virtual void PartSearchShow(ContextRz x, Core.ActArgs args)
        {
            ScreenShow(x, new PartSearch((ContextRz)x));
        }
        public virtual void PeopleSearchShow(ContextRz x, Core.ActArgs args)
        {
            ScreenShow(x, new PeopleSearch((ContextRz)x));
            //PeopleSearch b = new PeopleSearch((ContextRz)x);
            //AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, b));
            //b.SessionId = Session.SessionID;
            //ViewHandleRedirect(b.Uid);
        }
        public virtual void PartSearchShow(ContextRz x, String partToSearch)
        {
            ScreenShow(x, new PartSearch((ContextRz)x));
        }
        public bool ContactReminderShow(ContextRz x)
        {
            Response.Redirect(ContactReminderUrl(x));
            return true;
        }
        public company CompanyNewShow(ContextRz x)
        {
            string name = x.TheLeaderRz.AskForString("Enter the name of the company to add:");
            if (!Tools.Strings.StrExt(name))
            {
                //x.TheLeaderRz.Tell("The new company name cannot be blank.");
                return null;
            }
            string d_name = company.DistillCompanyName(name);
            company c = company.GetByDistilledName(x, d_name);
            if (c != null)
            {
                x.TheLeaderRz.Tell("This company already appears to exists. Please choose a different name.");
                return CompanyNewShow(x);
            }
            c = company.New(x);
            c.companyname = name;
            c.base_mc_user_uid = x.xUserRz.unique_id;
            c.agentname = x.xUserRz.name;
            c.Insert(x);
            x.Show(new ShowArgs(x, c));
            return c;
        }
        public virtual bool HomeScreenShow(ContextRz x)
        {
            ScreenShow(x, new HomeScreen((ContextRz)x));
            //HomeScreen b = new HomeScreen((ContextRz)x);
            //AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, b));
            //b.SessionId = Session.SessionID;
            //ViewHandleRedirect(b.Uid);
            return true;
        }
        public bool OrderBatchShow(ContextRz x)
        {
            Response.Redirect("~/Views/ViewOrderBatch.aspx");
            return true;
        }
        public virtual void OrderSearchShow(ContextRz x, ActArgs args)
        {
            ScreenShow(x, new OrderSearch((ContextRz)x));
        }
        public void OrderSearchShow(ContextRz x, Rz5.Enums.OrderType typeToSearch, String partToSearch)
        {
            ScreenShow(x, new OrderSearch((ContextRz)x));
        }
        public void ShippingScreenShow(ContextRz x, ActArgs args)
        {
            ScreenShow(x, new ShippingScreen((ContextRz)x));
            //ShippingScreen b = new ShippingScreen((ContextRz)x);
            //AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, b));
            //b.SessionId = Session.SessionID;
            //ViewHandleRedirect(b.Uid);
        }
        public void EmailBlasterShow(ContextRz context)
        {
            ScreenShow(context, new EmailBlasterScreen((ContextRz)context));
            //EmailBlasterScreen b = new EmailBlasterScreen((ContextRz)context);
            //AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(context, b));
            //b.SessionId = Session.SessionID;
            //ViewHandleRedirect(b.Uid);
        }
        public bool OrderLinksShow(ContextRz x, string order_uid)
        {
            ordhed o = ordhed.GetById(x, order_uid);
            if (o == null)
                return false;
            ScreenShow(x, new OrderLinks((ContextRz)x, o));
            return true;
        }
        public bool ShowWebIPApproval(ContextRz x)
        {
            Response.Redirect("~/Screens/ApprovedIPs.aspx");
            return true;
        }
        public bool PaymentsShow(ContextRz x, string order_uid)
        {
            Response.Redirect(PaymentsUrl(x) + "?id=" + order_uid);
            return true;
        }
        //public bool ViewLogsShow(ContextRz x, nObject o)
        //{
        //    Response.Redirect(LogsUrl(x) + "?id=" + o.unique_id + "&classname=" + o.ClassId);
        //    return true;
        //}
        //public n_log AddLogShow(ContextRz x, nObject o)
        //{
        //    n_log l = new n_log(x.xSys);
        //    l.the_n_user_uid = x.xUser.unique_id;
        //    l.user_name = x.xUser.name;
        //    l.machine_name = Environment.MachineName;
        //    l.object_class = o.ClassName;
        //    l.object_id = o.unique_id;
        //    l.manually_entered = true;
        //    l.ISave();
        //    Response.Redirect(AddLogUrl(x) + "?id=" + l.unique_id);
        //    return l;
        //}
        public bool ViewChangeHistory(ContextRz x, nObject o)
        {
            if (x == null)
                return false;
            if (o == null)
                return false;
            Response.Redirect(ChangeHistoryUrl(x) + "?id=" + o.unique_id + "&classname=" + o.ClassId);
            return true;
        }
        public override Screen ScreenCreate(Context x, ShowArgs args)
        {
            ContextRz xrz = (ContextRz)x;

            IItem i = args.TheItems.FirstGet(x);
            if (i is Rz5.ordhed_invoice)
                return new RzWeb.Invoice(xrz, (Rz5.ordhed_invoice)i);
            if (i is Rz5.ordhed_quote)
                return new RzWeb.FormalQuote(xrz, (Rz5.ordhed_quote)i);
            if (i is Rz5.ordhed_rfq)
                return new RzWeb.RFQ(xrz, (Rz5.ordhed_rfq)i);
            if (i is Rz5.ordhed_sales)
                return new RzWeb.Sales(xrz, (Rz5.ordhed_sales)i);
            if (i is Rz5.ordhed_purchase)
            {
                if (((Rz5.ordhed_purchase)i).is_bill)
                    return new RzWeb.Bill(xrz, (Rz5.ordhed_purchase)i);
                else
                    return new RzWeb.Purchase(xrz, (Rz5.ordhed_purchase)i);
            }
            if (i is Rz5.ordhed_rma)
                return new RzWeb.RMA(xrz, (Rz5.ordhed_rma)i);
            if (i is Rz5.ordhed_vendrma)
                return new RzWeb.VendRMA(xrz, (Rz5.ordhed_vendrma)i);
            if (i is Rz5.ordhed_service)
                return new RzWeb.Service(xrz, (Rz5.ordhed_service)i);
            if (i is Rz5.orddet_quote)
                return new RzWeb.FormalQuoteLine(xrz, (Rz5.orddet_quote)i);
            if (i is Rz5.orddet_rfq)
                return new RzWeb.RFQLine(xrz, (Rz5.orddet_rfq)i);
            if (i is Rz5.orddet_line)
            {
                if (args is ShowArgsOrder)
                {
                    ShowArgsOrder sao = (ShowArgsOrder)args;
                    switch (sao.TheOrderType)
                    {
                        case Rz5.Enums.OrderType.Invoice:
                            return new RzWeb.InvoiceLine(xrz, (Rz5.orddet_line)i);
                        case Rz5.Enums.OrderType.Sales:
                            return new RzWeb.SalesLine(xrz, (Rz5.orddet_line)i);
                        case Rz5.Enums.OrderType.RMA:
                            return new RzWeb.RMALine(xrz, (Rz5.orddet_line)i);
                        case Rz5.Enums.OrderType.VendRMA:
                            return new RzWeb.VendRMALine(xrz, (Rz5.orddet_line)i);
                        case Rz5.Enums.OrderType.Purchase:
                            return new RzWeb.PurchaseLine(xrz, (Rz5.orddet_line)i);
                        case Rz5.Enums.OrderType.Service:
                            return new RzWeb.ServiceLine(xrz, (Rz5.orddet_line)i);
                    }
                }
            }
            if (i is Rz5.dealheader)
                return new RzWeb.OrderBatch(xrz, (Rz5.dealheader)i);
            if (i is Rz5.company)
                return new RzWeb.Company(xrz, (Rz5.company)i);
            if (i is Rz5.companycontact)
                return new RzWeb.CompanyContact(xrz, (Rz5.companycontact)i);
            if (i is Rz5.contactnote)
                return new RzWeb.ContactNote(xrz, (Rz5.contactnote)i);
            if (i is Rz5.calllog)
                return new RzWeb.CallLog(xrz, (Rz5.calllog)i);
            if (i is Rz5.shippingaccount)
                return new RzWeb.ShippingAccount(xrz, (Rz5.shippingaccount)i);
            if (i is Rz5.companyaddress)
                return new RzWeb.CompanyAddress(xrz, (Rz5.companyaddress)i);
            if (i is Rz5.partrecord)
                return new RzWeb.PartRecord(xrz, (Rz5.partrecord)i);
            if (i is NewMethod.n_choices)
                return new RzWeb.Choices(xrz, (NewMethod.n_choices)i);
            if (i is NewMethod.n_choice)
                return new RzWeb.Choice(xrz, (NewMethod.n_choice)i);
            if (i is Rz5.n_user)
                return new RzWeb.User(xrz, (Rz5.n_user)i);
            if (i is Rz5.account)
                return new RzWeb.Account(xrz, (Rz5.account)i);
            if (i is Rz5.part_master)
                return new RzWeb.PartMaster(xrz, (Rz5.part_master)i);

            return base.ScreenCreate(x, args);
        }
        public void UserAccountsShow(ContextRz x)
        {
        }
        public virtual void ReportsShow(ContextRz x)
        {
            ScreenShow(x, new ReportsScreen(x));
        }
        public void UserPanelShow(ContextRz x)
        {
            ScreenShow(x, new Panel(x));
        }
        public void ImportShow(ContextRz context)
        {
            ScreenShowNewWindow(context, new ImportScreenParts((ContextRz)context));
        }
        public void PaymentScreenShow(ContextRz context)
        {
            ScreenShow(context, new PaymentScreen((ContextRz)context));
            //PaymentScreen b = new PaymentScreen((ContextRz)context);
            //AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(context, b));
            //b.SessionId = Session.SessionID;
            //ViewHandleRedirect(b.Uid);
        }
        public void SandboxShow(ContextRz context)
        {
            ScreenShow(context, new SandboxScreen((ContextRz)context));
            //SandboxScreen b = new SandboxScreen((ContextRz)context);
            //AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(context, b));
            //b.SessionId = Session.SessionID;
            //ViewHandleRedirect(b.Uid);
        }
        public bool UserManagerShow(ContextRz x)
        {
            Response.Redirect(UserManagerUrl(x));
            return true;
        }
        public bool AddNewChoiceList(ContextRz x)
        {
            //String s = x.TheLeader.AskForString("What is the name of this new choice list?");
            //if (!Tools.Strings.StrExt(s))
            //    return false;
            //n_choices c = x.xSys.GetChoicesByName(s);
            //if (c != null)
            //{
            //    x.TheLeader.Tell("The choice list named '" + c.name + "' already exists.");
            //    return false;
            //}
            n_choices c = n_choices.New(x);
            c.Insert(x);
            x.xSys.CacheChoices(x);
            Response.Redirect(NewChoiceListUrl(x) + "?id=" + c.unique_id);
            return true;
        }
        public String NewChoiceListUrl(ContextRz x)
        {
            return "~/Views/ViewChoices.aspx";
        }
        public bool AllChoicesShow(ContextRz x)
        {
            //Response.Redirect(AllChoicesUrl(x));
            return true;
        }
        public String AllChoicesUrl(ContextRz x)
        {
            return "~/Views/ViewAllChoices.aspx";
        }
        public bool CompanyInfoShow(ContextRz x)
        {
            //Response.Redirect(CompanyInfoUrl(x));
            return true;
        }
        public String CompanyInfoUrl(ContextRz x)
        {
            return "~/Views/ViewCompanyInfo.aspx";
        }
        public String PartSearchUrl(ContextRz x)
        {
            return "~/Screens/Parts.aspx";
        }
        public String PeopleSearchUrl(ContextRz x)
        {
            return "~/Screens/People.aspx";
        }
        public String PeopleAltSearchUrl(ContextRz x)
        {
            return "~/Screens/People_AltSearch.aspx";
        }
        public String ContactReminderUrl(ContextRz x)
        {
            return "~/People_AltReqs.aspx";
        }
        public String CompanyNewUrl(ContextRz x)
        {
            return "~/CompanyAdd.aspx";
        }
        public String HomeScreenUrl(ContextRz x)
        {
            return "~/Screens/Home.aspx";
        }
        //public String ProfitReportUrl(ContextRz x)
        //{
        //    return "~/Screens/ProfitReport.aspx";
        //}
        public String OrderSearchUrl(ContextRz x)
        {
            return "~/Screens/OrderSearch.aspx";
        }
        public String OrderSearchAltSearchUrl(ContextRz x)
        {
            return "~/Screens/OrderSearch_AltSearch.aspx";
        }
        public String UserPanelUrl(ContextRz x)
        {
            return "~/Screens/UserPanel.aspx";
        }
        public String OrderLinksUrl(ContextRz x)
        {
            return "~/Views/ViewOrderLinks.aspx";
        }
        public String PaymentsUrl(ContextRz x)
        {
            return "~/Views/ViewPayments.aspx";
        }
        public String AddLogUrl(ContextRz x)
        {
            return "~/Views/ViewAddLog.aspx";
        }
        public String ChangeHistoryUrl(ContextRz x)
        {
            return "~/Views/ViewChangeHistory.aspx";
        }
        public String LogsUrl(ContextRz x)
        {
            return "~/Views/ViewLogEntries.aspx";
        }
        public String UserManagerUrl(ContextRz x)
        {
            return "~/Screens/UserManager.aspx";
        }
        public bool ReqSourcingManagerShow(ContextRz x)
        {
            //Response.Redirect("~/ReqSourceSelection.aspx");
            return true;
        }
        public bool ReqQuotingManagerShow(ContextRz x)
        {
            //Response.Redirect("~/ReqQuoteSelection.aspx");
            return true;
        }
        public string GetReceiveQuantityString_QC(ContextRz q, partrecord p, ordhed o, orddet d, long qDefault)
        {
            //string qty = q.TheLeader.AskForString("Please enter the amount to be received:", (d.quantityordered - d.quantityfilled).ToString(), false);
            //if (!Tools.Strings.StrExt(qty))
            //    qty = "0";
            //if (!Tools.Number.IsNumeric(qty))
            //    qty = "0";
            //return qty;
            return "0";
        }
        public bool AssignAgentShow(ContextRz x, ArrayList comps)
        {
            //try
            //{
            //    string s = "";
            //    foreach (company c in comps)
            //    {
            //        if (Tools.Strings.StrExt(s))
            //            s += "|";
            //        s += c.unique_id;
            //    }
            //    Response.Redirect("~/Screens/AssignCompany.aspx?comps=" + s);
            //    return true;
            //}
            //catch { }
            return false;
        }
        public bool SetCompanyType(ContextRz x, ArrayList comps)
        {
            //try
            //{
            //    string s = "";
            //    foreach (company c in comps)
            //    {
            //        if (Tools.Strings.StrExt(s))
            //            s += "|";
            //        s += c.unique_id;
            //    }
            //    Response.Redirect("~/Screens/SetCompanyType.aspx?comps=" + s);
            //    return true;
            //}
            //catch { }
            return false;
        }
        public bool SetCompanyGroup(ContextNM x, ArrayList cs, bool undo, String strClass, String strGroup)
        {
            //try
            //{
            //    string ids = "";
            //    foreach (company c in cs)
            //    {
            //        if (c == null)
            //            continue;
            //        if (Tools.Strings.StrExt(ids))
            //            ids += "|";
            //        ids += c.unique_id;
            //    }
            //    Response.Redirect("~/Screens/SetCompanyGroup.aspx?comps=" + ids + "&undo=" + (undo ? "t" : "f") + "&class=" + strClass + "&group=" + strGroup);
            //    return true;
            //}
            //catch { }
            return false;
        }
        public bool CheckLogin() { return false; }
        public void CloseLogin() { }
        public void PopLogin(ContextRz context) { }
        public LoginInfo LoginInfoAskOnThread(ContextRz context, bool closeOnAccept) { return null; }
        public void PostQBShow(ContextRz context, Rz5.Enums.OrderType type) { }
        public void DatabaseManagerShow(ContextRz x) { }
        public void QuickBooksSettingsShow(ContextRz x) { }
        public void UpdateCheck(ContextRz x) { }
        public void LiveSupportRequest(ContextRz context) { }
        public void RestoreOrder(ContextRz context) { }
        public void RestoreOrderLine(ContextRz context) { }
        public void RestoreCompany(ContextRz context) { }
        public void RestoreContact(ContextRz context) { }
        public void PhoneMonitorShow(ContextRz context) { }
        public void GridShow(Context x, Grid g, String caption) { }
        public void DutyMonitorShow(ContextRz context) { }
        public void ToolsShow(ContextRz context) { }
        public void ToolsSqlShow(ContextRz context) { }
        public void ToolsTextShow(ContextRz context) { }
        public void UserApply(ContextRz context) { }
        public void ChatWithSomeone(ContextRz context) { }
        public void InspectionReportShow(ContextRz x, qualitycontrol report) { }
        public void DataTableSizesManage(ContextRz context) { }
        public void DataTableDevelop(ContextRz context) { }
        public void DataFieldsDevelop(ContextRz context) { }
        public void DataSourcesList(ContextRz context) { }
        public void TestOptionsShow(ContextRz context) { }
        public void CreditCardNumbersShow(ContextRz context) { }
        public void OrderLinksWorkBenchShow(ContextRz x, ActArgs args) { }
        public void ChatHistoryShow(ContextRz context) { }
        public void PhoneReportShow(ContextRz context) { }
        public void CloseTabsByID(ContextRz x, ArrayList ids) { throw new NotImplementedException(); }
        public void CloseTabsByID(ContextRz x, String id) { throw new NotImplementedException(); }
        public OrderLinkArgs OrderLinkChoose(ContextRz x, OrderLinkArgs args, String prompt, String order_number, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {            
            if (TheViewHandle == null)
                return args;
            WebThreadHandleAskPurchaseOrderLink h = new WebThreadHandleAskPurchaseOrderLink(x, prompt, order_number, screenHandle, viewHandle, session, page);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            //TheViewHandle.Flow();
            Flow();
            h.TheEvent.WaitOne();
            if (h.Search)
                return OrderLinkChoose(x, args, prompt, h.OrderNumber, screenHandle, viewHandle, session, page);
            OrderLinkArgs a = new OrderLinkArgs(args.TheOrder);
            a.TheLinkType = args.TheLinkType;                      
            string[] str = Tools.Strings.Split(h.Result, "|");
            foreach (string s in str)
            {
                string id = Tools.Strings.ParseDelimit(str[0], "_dot_", 2).Trim();
                if (!Tools.Strings.StrExt(id))
                    continue;
                orddet_line o = orddet_line.GetById(x, id);
                if (o != null)
                    a.Lines.Add(new OrderLinkLine(o, o.quantity));
            }                      
            return a;
        }
        public void OrderLinkChoose(ContextRz x, OrderLinkArgs args) { }
        public void QBCreateTerms(ContextRz x, String terms) { }
        public String QBCreateCompany(ContextRz x, Rz5.Enums.CompanySelectionType type, company v, String address1, String address2) { return ""; }
        public DateTime AskPostpone(DateTime date) { throw new NotImplementedException(); }
        //Private Functions
        private void SetObjectColor(ContextRz x, ItemTag item)
        {
            //if (x == null)
            //    return;
            //string color = "0";
            //if (Tools.Strings.StrExt(item.ItemTarget))
            //    color = item.ItemTarget;
            //if (item == null)
            //    return;
            //string class_id = item.ClassId;
            //if (Tools.Strings.StrCmp(class_id, "ordhed"))
            //{
            //    string type = x.xSys.xData.GetScalar_String("select ordertype from ordhed where unique_id = '" + item.Uid + "'").ToLower();
            //    if (Tools.Strings.StrExt(type))
            //        class_id += "_" + type;
            //}
            //x.xSys.xData.Execute("update " + class_id + " set grid_color = " + color + " where unique_id = '" + item.Uid + "'", false, true);
            //if ((Tools.Strings.StrCmp(class_id, "req") || Tools.Strings.StrCmp(class_id, "reqbatch")) && Rz3App.xLogic.IsArrowtronics)
            //{
            //    int c = 0;
            //    try { c = Convert.ToInt32(color); }
            //    catch { }
            //    IItem i = item.FirstGet(x);
            //    if (i is Rz3.req)
            //    {
            //        Rz3.req r = (Rz3.req)i;
            //        ((Rz3.CustomerSpecific.Arrowtronic.QuoteLogic)((Rz3.n_sys_Rz3)x.xSys).TheQuoteLogic).SendQuoteColorChangeUserNote((Rz3.ContextRz)x, r, c);
            //        return;
            //    }
            //    if (i is Rz3.reqbatch)
            //    {
            //        Rz3.reqbatch rb = (Rz3.reqbatch)i;
            //        ((Rz3.CustomerSpecific.Arrowtronic.QuoteLogic)((Rz3.n_sys_Rz3)x.xSys).TheQuoteLogic).SendQuoteColorChangeUserNote((Rz3.ContextRz)x, rb, c);
            //        return;
            //    }
            //}
        }
        //was override
        public bool SendEmailSilent(Context x, string toAddress, string htmlBody, string subjectLine, ArrayList ccAddresses, ref string errMessage)
        {
            return false;
            //Tools.nEmailMessage m = new Tools.nEmailMessage();
            //m.ToAddress = toAddress;
            //m.Subject = subjectLine;
            //m.HTMLBody = htmlBody;
            //foreach (String cc in ccAddresses)
            //{
            //    m.AddExtraRecipient(cc);
            //}
            //Rz5.n_user u = (Rz5.n_user)((ContextNM)x).xUser;
            //m.FromName = u.name;
            //m.FromAddress = u.email_address;
            //if (Tools.Misc.IsDevelopmentMachine())
            //{
            //    m.ServerName = "smtpout.secureserver.net";
            //    m.ServerPort = 80;
            //    m.FromAddress = "notify@recognin.com";
            //    m.FromName = "RzTest";
            //    m.ServerUserName = "notify@recognin.com";
            //    m.ServerPassword = "N0tify";
            //}
            //else
            //{
            //    m.ServerName = u.smtp_server;
            //    m.ServerUserName = u.smtp_user;
            //    m.ServerPassword = u.smtp_password;
            //    m.ServerPort = u.smtp_port;
            //    n_set TheSet = (n_set)u.xSys.QtO("n_set", "select * from n_set where setting_key = '" + u.unique_id + "' and name = 'email_use_ssl'");
            //    //if(TheSet!=null)
            //    //    m.UseSSL = Tools.Strings.StrCmp(TheSet.setting_value, "true");
            //    m.AddExtraRecipient(u.email_address);
            //}
            //return m.Send(ref errMessage);
        }

        public void UpdateDetailFromPack(ContextRz x, Rz5.orddet_line l, pack p)
        {

        }
        public string GetOrddetFieldsExtra(ContextRz x, string strFields)
        {
            return strFields;
        }

        public DataConversionType AskConversionType(ref String def, String instructions, FieldType fieldType) {

            if (AskYesNo("Do you want to continue and ignore any rows that can't be imported?"))
                return DataConversionType.DeleteRow;
            else
                return DataConversionType.Cancel;        
        }
        public String ChooseOneChoice(ContextNM x, String strName) { throw new NotImplementedException(); }
        public String ChooseOneChoice(ContextNM x, String strName, String strCaption) { throw new NotImplementedException(); }
        public String ChooseMultipleChoices(ContextNM x, String strName, String strCaption, String defaultSelections) { throw new NotImplementedException(); }
        public bool AskForAdminRights() { throw new NotImplementedException(); }
        public List<ColumnAction> AskForColumnActions(DataTable original) { throw new NotImplementedException(); }
        public NewMethod.n_user AskForUser(ArrayList choices, bool allowAdd) { throw new NotImplementedException(); }
        public NewMethod.n_user AskForUser() { throw new NotImplementedException(); }
        //public void RestoreCompany(ContextRz context) { throw new NotImplementedException(); }
        //public void RestoreContact(ContextRz context) { throw new NotImplementedException(); }
        public void ReportShowResponse(ContextRz context, HttpResponse response, Core.Report r)
        {
            ReportScreen s = new ReportScreen(context, r, false);
            ScreenShow(context, response, s);
        }
        public void ReportShow(ContextRz context, Core.Report r, bool autoCalculate)
        {
            ReportScreen s = new ReportScreen(context, r, autoCalculate);
            //ScreenShowNewWindow(context, s);           
            ScreenShow(context, s);
        }        
        public void ReportShow(ContextRz context, Core.Report r, ReportArgs args)
        {
            ReportScreen s = new ReportScreen(context, r, false);
            r.Calculate(context, args);
            //ScreenShowNewWindow(context, s);
            ScreenShow(context, s);
        }
        public emailtemplate AskForEmailTemplate(nObject xObject) { throw new NotImplementedException(); }
        //public void CacheCompanies() { throw new NotImplementedException(); }
        public void StockEvaluatorReport(dealheader d) { throw new NotImplementedException(); }
        public void ShowDealItem(ContextRz context, dealheader deal, orddet detail) 
        {
            context.Show(new ShowArgs(context, deal));
        }
        public void ImportFromQB(ContextRz context) { throw new NotImplementedException(); }
        public void ScanBrokerForumBids(ContextRz context) { throw new NotImplementedException(); }
        public void ScanBrokerForumRFQs(ContextRz context) { throw new NotImplementedException(); }
        public void ShowHelp(ContextRz context) { throw new NotImplementedException(); }
        public MakeOrderArgs AskForMakeOrderArgs(Enums.OrderType orderType) { throw new NotImplementedException(); }        
        public DepotConnection ChooseDepotConnection() { throw new NotImplementedException(); }
        //public void ShowTransmitOrders(ContextRz context, List<ordhed> a, Enums.TransmitType ty) { throw new NotImplementedException(); }
        public void ShowPartCrossReference(Context x, PartCrossReferenceSearchOptions options) { throw new NotImplementedException(); }
        public void AskForLineCancelArgs(ContextRz context, OrderLineCancelArgs args)
        {
            if (TheViewHandle == null)
            {
                args.OperationCanceled = true;
                return;
            }
            WebThreadHandleAskCancelArgs h = new WebThreadHandleAskCancelArgs(context, "Choose Orders To Cancel From", args);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            //TheViewHandle.Flow();
            Flow();
            h.TheEvent.WaitOne();
            if (!Tools.Strings.StrExt(h.Result))
            {
                args.OperationCanceled = true;
                return;
            }
            string[] str = Tools.Strings.Split(h.Result, "|");
            foreach (string s in str)
            {
                string id = Tools.Strings.ParseDelimit(s, "_dot_", 1).Trim();
                string c = Tools.Strings.ParseDelimit(s, "_dot_", 2).Trim();
                if (Tools.Strings.StrCmp(c, "undefined"))
                    continue;
                if (!Tools.Strings.StrExt(id))
                    continue;
                ordhed o = ordhed.GetById(context, id);
                if (o == null)
                    continue;
                args.TypesToCancel.Add(o.OrderType);
            }
            if (args.TypesToCancel.Count <= 0)
            {
                args.OperationCanceled = true;
                return;
            }
        }
        //LoginInfo LoginInfoAskOnThread(ContextRz context, bool closeOnAccept);
        //public void PopLogin(ContextRz context) { throw new NotImplementedException(); }        
        public void ImportContacts(ContextRz x, ActArgs args) { throw new NotImplementedException(); }
        public partrecord StockChoose(ContextRz context, String part) { throw new NotImplementedException(); }
        public void MultiSearchShow(ContextRz x, String partToSearch) { throw new NotImplementedException(); }
        public void ExportInventory(ContextRz x) 
        {
            ScreenShowNewWindow(x, new ExportInventory(x));
        }
        public RMASelectionResult ChooseVendorRMA(RMASelectionArgs args)
        {
            RMASelectionResult r = new RMASelectionResult();
            r.NewVRMA = true;
            r.Quantity = args.Quantity;
            return r;
        }
        public RMASelectionResult RMASelectionGet(ContextRz context, RMASelectionArgs args)
        {
            RMASelectionResult r = new RMASelectionResult();
            r.NewRMA = true;
            r.Quantity = args.Quantity;
            return r;
        }
        public string NewCompanyNameGet(ContextRz context, string strName) { throw new NotImplementedException(); }
        public List<SalesLineGroup> ChooseOrderLines(ContextRz context, Rz5.ordhed_sales sale, List<SalesLineGroup> sections, Rz5.Enums.OrderType t, List<ordhed> existing, ref bool cancel) { throw new NotImplementedException(); }
        public ArrayList ChooseFromArray(ContextRz context, ArrayList choices, String caption) 
        {            
            LeaderWebUser lwu = (LeaderWebUser)context.Leader;
            if (choices == null || choices.Count <= 0)
                return null;
            DialogResultChooseFromArrayArgs result = (DialogResultChooseFromArrayArgs)lwu.ShowModalDialog(new ChooseFromArray(context,choices, caption));
            if (!result.Success)
                return null;
            return result.List;
        }
        public bool SendOutlookMessage(string ToAddress, string BodyText, string SubjectString, bool boolTextOnly, bool boolUserEdit, string CCString, string strAttachFile, bool boolForceSilent, ArrayList colCC, string strBCC, string strReplyAddress, string strOtherAttachment, string strSignature, bool bDeliverNow, ref string error) { throw new NotImplementedException(); }
        public String AskForSalesOrderIdToAdd() { throw new NotImplementedException(); }
        public void AskForOrder(ref String type, ref String order) { throw new NotImplementedException(); }
        public String ChooseGroup(n_user u) { throw new NotImplementedException(); }
        public virtual void ManageImportsShow(ContextRz context)
        {
            ScreenShowNewWindow(context, new ManagePartImports(context));
        }
        public virtual void ImportCompanies(ContextRz x, ActArgs args)
        {
            ScreenShowNewWindow(x, new ImportScreenCompany(x));
        }
        public void AddPanelOptions(ContextRz x, PanelLogic l, ActHandle h)
        {
            ContextRz xrz = (ContextRz)x;
            if( !xrz.GetSettingBoolean("rzweb_demonstration_info_cleared") )
                h.SubActs.Add(new ActHandle(new Act("Clear Demonstration Data", new ActHandler(ClearDemonstrationData))));
        }
        public void ClearDemonstrationData(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            if (!xrz.Leader.AreYouSure("Clear the demonstration data from the system (this will not affect information you have imported or manually entered)"))
                return;
            xrz.Sys.ProofLogic.ClearDemonstrationInfo(xrz);
            xrz.Leader.Tell("Complete; the demonstration information was cleared");
        }
        public bool DemoInfoCleared(ContextRz x)
        {
            return x.GetSettingBoolean("rzweb_demonstration_info_cleared");
        }       
        public void AddCompanyOptions(ContextRz x, CompanyLogic l, ActHandle h)
        {
            h.SubActs.Add(new ActHandle(new Act("OEM Emails", new ActHandler(OEMEmailsShow))));
        }
        private void OEMEmailsShow(Context context, ActArgs args)
        {
            ScreenShowNewWindow(context, new RzWeb.ExportOEMEmails((ContextRz)context));
        }
        public void PrintDetailEdit(printdetail detail)
        {
            if (TheViewHandle == null)
                throw new Exception("No view is available");

            //add a handle to a static list
            WebThreadHandlePrintDetail h = new WebThreadHandlePrintDetail(this, detail);
            WebThreads.Add(h.Uid, h);

            TheViewHandle.ScriptsToRun.Add(h.Script);
            //TheViewHandle.Flow();
            Flow();
            h.TheEvent.WaitOne();  //may want a long timeout here, in case the browser's x is clicked, etc.

            h.Apply();
        }
        public void TemplateEdit(ContextRz context, n_template template)
        {
            if (TheViewHandle == null)
                throw new Exception("No view is available");

            //add a handle to a static list
            WebThreadHandleTemplate h = new WebThreadHandleTemplate(context, template);
            WebThreads.Add(h.Uid, h);

            TheViewHandle.ScriptsToRun.Add(h.Script);
            //TheViewHandle.Flow();
            Flow();
            h.TheEvent.WaitOne();  //may want a long timeout here, in case the browser's x is clicked, etc.

            h.Apply(context);
        }
        public virtual RzMenuSpot MenuCreate(ContextRz context, RzScreen screen)
        {
            return new RzMenuSpot(context);
        }
        public List<ActHandle> FilterActsForWeb(Context x, List<ActHandle> h, nObject o)
        {
            ActionFilter a = new ActionFilter();
            return a.FilterActsForWeb(x, h, o);
        }
        public virtual ReportTargetHtmlWeb GetReportTargetHtmlWeb(Spot actionSpot)
        {
            return new ReportTargetHtmlWeb(actionSpot);
        }
        public nObject ChooseObjectFromCollection(ContextRz x, ArrayList objects)
        {
            return null;
        }

        public void AccountsShow(ContextRz context)
        {
            ScreenShowNewWindow(context, new RzWeb.ChartOfAccounts((ContextRz)context));
        }

        public void CurrenciesShow(ContextRz context)
        {
            ScreenShowNewWindow(context, new RzWeb.Currencies((ContextRz)context));
        }
    }
    public class WebThreadHandlePrintDetail : WebThreadHandle
    {
        public printdetail Detail;
        public WebThreadHandlePrintDetail(LeaderWebUser leader, printdetail detail)
            : base(leader)
        {
            Detail = detail;
        }
        public void Apply()
        {
            String result = "";
            try
            {
                result = Tools.Data.NullFilterString(TheRequest["result"]);
            }
            catch { }

            if (Tools.Strings.StrCmp(result, "cancel"))
                return;

            Detail.textstring = Tools.Data.NullFilterString(TheRequest["detailText"]);
            Detail.fontname = Tools.Data.NullFilterString(TheRequest["fontName"]);
            try
            {
                Detail.fontsize = Int32.Parse(Tools.Data.NullFilterString(TheRequest["fontSize"]));
            }
            catch { }
        }
        public override string Caption
        {
            get
            {
                return "";
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            String id = "x" + Tools.Strings.GetNewID();

            sb.AppendLine("<form id=\"uploadForm\" method=\"post\" enctype=\"multipart/form-data\" action=\"Action.aspx\" target=\"iframe-post-form\">");
            sb.AppendLine("<input type=\"hidden\" name=\"askId\" value=\"" + Uid + "\"/>");
            sb.Append("<textarea style=\"width: 450px; height: 200px\" name=\"detailText\" id=\"" + id + "\">" + HttpUtility.HtmlEncode(Detail.textstring) + "</textarea>");

            sb.Append("<select name=\"fontName\">");
            AppendFont(sb, "Times New Roman");
            AppendFont(sb, "Arial");
            AppendFont(sb, "Calibri");                
            sb.Append("</select>");

            sb.Append("<select name=\"fontSize\">");
            AppendSize(sb, 8);
            AppendSize(sb, 10);
            AppendSize(sb, 12);
            AppendSize(sb, 14);
            AppendSize(sb, 16);
            AppendSize(sb, 18);
            AppendSize(sb, 20);
            AppendSize(sb, 22);
            AppendSize(sb, 24);
            sb.Append("</select>");

            sb.Append("<br><br><input id=\"cancel_" + Uid + "\" type=\"button\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: 'cancel'}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"ok_" + Uid + "\" type=\"button\" value=\"OK\" onclick=\"$('#uploadForm').submit(); AskDialogClose();\">");
            sb.AppendLine("</form>");
            
            sb.Append("<script type=\"text/javascript\">");
            sb.AppendLine("$('#dialog_div').dialog({ height: 370, width: 490 }); ");
            sb.Append("buttonize('ok_" + Uid + "', 'greencheck.png'); buttonize('cancel_" + Uid + "', 'redxmid.png'); $('#" + id + "').focus().select(); iframePostForm('uploadForm');</script>");

            return sb.ToString();
        }
        void AppendFont(StringBuilder sb, String font)
        {
            String selected = "";
            if (Tools.Strings.StrCmp(font, Detail.fontname))
                selected = " selected";
            sb.Append("<option" + selected + ">" + HttpUtility.HtmlEncode(font) + "</option>");
        }
        void AppendSize(StringBuilder sb, int size)
        {
            String selected = "";
            if (size == Detail.fontsize)
                selected = " selected";
            sb.Append("<option" + selected + ">" + size.ToString() + "</option>");
        }
    }
    public class WebThreadHandleTemplate : WebThreadHandle
    {
        public n_template Template;

        public WebThreadHandleTemplate(ContextRz x, n_template template)
            : base((LeaderWebUser)x.Leader)
        {
            Template = template;
            if( Template.AllColumns == null )
                Template.GatherColumns(x);
        }
        public void Apply(ContextRz x)
        {
            String result = "";
            try
            {
                result = Tools.Data.NullFilterString(TheRequest["result"]);
            }
            catch { }

            if (Tools.Strings.StrCmp(result, "cancel"))
                return;

            Dictionary <String, n_column> columns = new Dictionary<string,n_column>();
            List<String> originalFields = new List<string>();
            foreach(DictionaryEntry d in Template.AllColumns)
            {                
                n_column c = (n_column)d.Value;
                
                if(!columns.ContainsKey(c.field_name.ToLower()))
                    columns.Add(c.field_name.ToLower(), c);

                if(!originalFields.Contains(c.field_name.ToLower()))
                    originalFields.Add(c.field_name.ToLower());
            }

            foreach (String k in TheRequest.Form.AllKeys)
            {
                if (k.StartsWith("fieldcolumn_"))
                {
                    String field = k.Substring(12);
                    n_column c = null;
                    if (columns.ContainsKey(field))
                        c = columns[field];
                    else
                        c = Template.AddColumnByField(x, field);

                    c.column_caption = TheRequest["caption_" + field];

                    int scalewidth = Int32.Parse(TheRequest["width_" + field]);
                    scalewidth = Tools.Number.CalcPercent(TemplateDesignerWidth, scalewidth);
                    c.column_width = scalewidth;
                    c.column_order = Int32.Parse(TheRequest["order_" + field]);
                    c.Update(x);

                    if(originalFields.Contains(c.field_name.ToLower()))
                        originalFields.Remove(c.field_name.ToLower());
                }
            }

            //remove anything left over
            foreach(n_column c in Template.ColumnsList(x))
            {
                if(originalFields.Contains(c.field_name.ToLower()))
                    c.Delete(x);
            }

            Template.ReabsorbColumns(x);

            //Detail.textstring = Tools.Data.NullFilterString(TheRequest["detailText"]);
            //Detail.fontname = Tools.Data.NullFilterString(TheRequest["fontName"]);
            //try
            //{
            //    Detail.fontsize = Int32.Parse(Tools.Data.NullFilterString(TheRequest["fontSize"]));
            //}
            //catch { }
        }
        public override string Caption
        {
            get
            {
                return "";
            }
        }
        public override string Render(Context x)
        {
            ContextRz xrz = (ContextRz)x;            
            StringBuilder sb = new StringBuilder();
            String id = "x" + Tools.Strings.GetNewID();
            CoreClassHandle h = xrz.Sys.CoreClassGet(Template.class_name);
            sb.AppendLine("<form id=\"uploadForm\" method=\"post\" enctype=\"multipart/form-data\" action=\"Action.aspx\" target=\"iframe-post-form\">");
            sb.AppendLine("<input type=\"hidden\" name=\"askId\" value=\"" + Uid + "\"/>");
            sb.AppendLine("<img style=\"float: left;\" src=\"Graphics/EditMid.png\"/><div style=\"float: left\"><font size=\"larger\">Column Editor: " + HttpUtility.HtmlEncode(h.TheAttribute.Caption) + "</font></div>");
            sb.AppendLine("<img src=\"Graphics/Ruler.png\"><br/>");
            sb.AppendLine("<div id=\"columnDiv\" style=\"width: " + (TemplateDesignerWidth + 100).ToString() + "px; height: 150px; background-color: #e7e7e7\"></div>");
            sb.AppendLine("<table border=\"0\"><tr><td>");
            sb.AppendLine("<div style=\"overflow: scroll; height: 210px; width: 400px;\">");
            //PropFilter p = new PropFilter();
            //List<CoreVarValAttribute> lst = p.FilterPropsForWeb(x, , Template.class_name);
            foreach (CoreVarValAttribute attr in h.VarValsGetSortedAlpha())
            {
                sb.AppendLine("<div class=\"ui-corner-all rz-property-line\" style=\"margin: 2px; border: thin solid #CCCCCC; font-size: x-small; cursor: pointer\" onclick=\"AddColumn('" + attr.Name + "', '" + attr.Caption.Replace("'", "") + "');\">" + HttpUtility.HtmlEncode(attr.Caption).Replace(" ", "&nbsp;") + "</div>");
            }
            sb.AppendLine("</div></td><td valign=\"top\">");
            sb.AppendLine("<div>Search<br />");
            sb.AppendLine("<input id=\"propertySearch\" type=\"text\" onkeydown=\"PropertySearch();\" size=\"25\">");
            sb.AppendLine("</div>");
            sb.Append("<br><br><center><input id=\"cancel_" + Uid + "\" type=\"button\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: 'cancel'}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"ok_" + Uid + "\" type=\"button\" value=\"OK\" onclick=\" AddColumnOrders(); $('#uploadForm').submit(); AskDialogClose();\"></center>");
            sb.AppendLine("</td></tr></table>");            
            sb.AppendLine("</form>");
            sb.AppendLine("<script type=\"text/javascript\">");
            foreach (n_column c in Template.ColumnsList(xrz))
            {
                int width = Convert.ToInt32(TemplateDesignerWidth * (Convert.ToDouble(c.column_width) / 100));
                if( width == 0 )
                    width = 20;
                sb.AppendLine("AddColumnWithWidth('" + c.field_name + "', '" + c.column_caption.Replace("'", "") + "', " + width.ToString() + ");");
            }
            sb.AppendLine("$('#columnDiv').sortable();");
            sb.AppendLine("$('#dialog_div').dialog({ height: 470, width: 750 }); ");
            //sb.AppendLine("alert('dialog open');");
            sb.AppendLine("buttonize('ok_" + Uid + "', 'greencheck.png'); buttonize('cancel_" + Uid + "', 'redxmid.png'); $('#" + id + "').focus().select(); iframePostForm('uploadForm');");
            sb.Append(LeaderWebUser.DialogSetup);
            sb.AppendLine("</script>");
            return sb.ToString();
        }
        static int TemplateDesignerWidth = 600;
    }
    public class ActionFilter
    {
        public virtual List<ActHandle> FilterActsForWeb(Context x, List<ActHandle> h, nObject o)
        {
            List<ActHandle> act = new List<ActHandle>();
            try
            {
                if (o is ordhed_quote)
                    act = FilterOrdHedOld(x, h);
                else if (o is ordhed_rfq)
                    act = FilterOrdHedOld(x, h);
                else if (o is ordhed)
                    act = FilterOrdHed(x, h);
                else if (o is orddet_line)
                    act = FilterOrdDetLine(x, h);
                else if (o is orddet_quote)
                    act = FilterOrdDetQuote(x, h);
                else if (o is orddet_rfq)
                    act = FilterOrdDetRFQ(x, h);
                else if (o is company)
                    act = FilterCompany(x, h);
                else if (o is companycontact)
                    act = FilterCompanyContact(x, h);
                else if (o is partrecord)
                    return new List<ActHandle>();//act = FilterPartRecord(h);
                else if (o is companyaddress)
                    return new List<ActHandle>();
                else if (o is shippingaccount)
                    return new List<ActHandle>();
                else if (o is contactnote)
                    return new List<ActHandle>();
                else if (o is calllog)
                    return new List<ActHandle>();
                else if (o is n_choices)
                    return new List<ActHandle>();
                else if (o is n_choice)
                    return new List<ActHandle>();
                else if (o is n_user)
                    return new List<ActHandle>();
                else if (o is exporttemplate)
                    return new List<ActHandle>();
                else if (o is account)
                    return new List<ActHandle>();
                else if (o is journal)
                    return new List<ActHandle>();
                else if (o is deposit)
                    return new List<ActHandle>();
                else if (o is payment_out)
                    return new List<ActHandle>();
                else if (o is payment_in)
                    return new List<ActHandle>();
                else
                    return h;
            }
            catch
            {
                return h;
            }
            return act;
        }
        protected virtual List<ActHandle> FilterOrdHed(Context x, List<ActHandle> h)
        {
            List<ActHandle> act = new List<ActHandle>();
            foreach (ActHandle a in h)
            {
                if (a is ActHandleSeparator)
                {
                    act.Add(a);
                    continue;
                }
                switch (a.Name.ToLower().Trim())
                {
                    case "unvoid":
                    case "icon":
                    case "color":
                    case "clip":
                    case "email":
                    case "payments":
                    case "new payment":
                    case "line report":
                    case "quickbooks":
                    case "customer to qb":
                    case "make link":
                    case "paste line info":
                    case "company to qb":
                    case "import lines":
                    case "sales order":
                    case "charge customer":
                    case "reorder":
                        break;
                    case "delete":
                        if (((ContextRz)x).xUserRz.IsDeveloper() || ((ContextRz)x).xUserRz.super_user)
                            act.Add(a);
                        break;
                    default:
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                }
            }
            return act;
        }
        protected virtual List<ActHandle> FilterOrdHedOld(Context x, List<ActHandle> h)
        {
            List<ActHandle> act = new List<ActHandle>();
            foreach (ActHandle a in h)
            {
                if (a is ActHandleSeparator)
                {
                    act.Add(a);
                    continue;
                }
                switch (a.Name.ToLower().Trim())
                {
                    case "icon":
                    case "void":
                    case "color":
                    case "clip":
                    case "email":
                    case "payments":
                    case "new payment":
                    case "line report":
                    case "quickbooks":
                    case "customer to qb":
                    case "make link":
                    case "paste line info":
                    case "company to qb":
                    case "import lines":
                    case "sales order":
                    case "charge customer":
                    case "reorder":
                        break;
                    case "delete":
                        if (((ContextRz)x).xUserRz.IsDeveloper() || ((ContextRz)x).xUserRz.super_user)
                            act.Add(a);
                        break;
                    default:
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                }
            }
            return act;
        }
        protected virtual List<ActHandle> FilterOrdDetLine(Context x, List<ActHandle> h)
        {
            List<ActHandle> act = new List<ActHandle>();
            foreach (ActHandle a in h)
            {
                if (a is ActHandleSeparator)
                {
                    act.Add(a);
                    continue;
                }
                switch (a.Name.ToLower().Trim())
                {
                    case "icon":
                    case "color":
                    case "clip":
                    case "split":
                    case "merge":
                    case "duplicatesales":
                    case "receive po":
                    case "receive rma":
                    case "ship invoice":
                    case "ship vendor rma":
                    case "receive service order":
                    case "ship service order":
                        break;
                    case "delete":
                        if (((ContextRz)x).xUserRz.IsDeveloper() || ((ContextRz)x).xUserRz.super_user)
                            act.Add(a);
                        break;
                    default:
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                }
            }            
            return act;
        }
        protected virtual List<ActHandle> FilterOrdDetQuote(Context x, List<ActHandle> h)
        {
            List<ActHandle> act = new List<ActHandle>();
            foreach (ActHandle a in h)
            {
                if (a is ActHandleSeparator)
                {
                    act.Add(a);
                    continue;
                }
                switch (a.Name.ToLower().Trim())
                {
                    case "icon":
                    case "color":
                    case "clip":
                    case "select":
                    case "receive bid":
                    case "email vendor group":
                    case "hot part":
                    case "duplicate":
                    case "copy line info":
                    case "pictures":
                    case "send for service":
                        break;
                    case "delete":
                        if (((ContextRz)x).xUserRz.IsDeveloper() || ((ContextRz)x).xUserRz.super_user)
                            act.Add(a);
                        break;
                    default:
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                }
            } 
            return act;
        }
        protected virtual List<ActHandle> FilterOrdDetRFQ(Context x, List<ActHandle> h)
        {
            List<ActHandle> act = new List<ActHandle>();
            foreach (ActHandle a in h)
            {
                if (a is ActHandleSeparator)
                {
                    act.Add(a);
                    continue;
                }
                switch (a.Name.ToLower().Trim())
                {
                    case "icon":
                    case "color":
                    case "clip":
                    case "select":
                    case "give quote":
                    case "hot part":
                    case "duplicate":
                    case "copy line info":
                    case "pictures":
                        break;
                    case "delete":
                        if (((ContextRz)x).xUserRz.IsDeveloper() || ((ContextRz)x).xUserRz.super_user)
                            act.Add(a);
                        break;
                    default:
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                }
            }            
            return act;
        }
        protected virtual List<ActHandle> FilterCompany(Context x, List<ActHandle> h)
        {
            List<ActHandle> act = new List<ActHandle>();
            foreach (ActHandle a in h)
            {
                if (a is ActHandleSeparator)
                {
                    act.Add(a);
                    continue;
                }
                switch (a.Name.ToLower().Trim())
                {
                    case "icon":
                    case "color":
                    case "clip":
                    case "assign":
                    case "set company type":
                    case "group":
                    case "un-group":
                    case "view web page":
                    case "send e-mail":
                    case "new excess":
                    case "new purchasing batch":
                    case "scan/view documents":
                    case "add as qb customer":
                    case "add as qb vendor":
                    case "line card":                    
                        break;
                    case "delete":
                        if (((ContextRz)x).xUserRz.IsDeveloper() || ((ContextRz)x).xUserRz.super_user)
                            act.Add(a);
                        break;
                    default:
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                }
            } 
            return act;
        }
        protected virtual List<ActHandle> FilterCompanyContact(Context x, List<ActHandle> h)
        {
            List<ActHandle> act = new List<ActHandle>();
            foreach (ActHandle a in h)
            {
                if (a is ActHandleSeparator)
                    continue;
                switch (a.Name.ToLower().Trim())
                {
                    case "icon":
                    case "clip":
                    case "set as primary contact":
                    case "send e-mail":
                    case "assign":
                    case "assign - bad record":
                    case "group":
                    case "un-group":
                    case "mark as dist":
                    case "mark as oem":
                    case "release":
                    case "link to company":
                    case "view domain":
                    case "mailing addresses":
                    case "hot part":
                    case "find duplicates":
                    case "order batch":
                    case "new purchasing batch":
                        break;
                    case "delete":
                        if (((ContextRz)x).xUserRz.IsDeveloper() || ((ContextRz)x).xUserRz.super_user)
                            act.Add(a);
                        break;
                    default:
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                }
            }
            act.Add(new ActHandle("New Quote"));
            act.Add(new ActHandle("New Bid"));
            return act;
        }
        protected virtual List<ActHandle> FilterPartRecord(Context x, List<ActHandle> h)
        {
            List<ActHandle> act = new List<ActHandle>();
            foreach (ActHandle a in h)
            {
                if (a is ActHandleSeparator)
                    continue;
                switch (a.Name.ToLower().Trim())
                {
                    case "icon":
                    case "clip":
                    case "scan c of c":
                    case "email vendor":
                    case "print label":
                    case "split":
                    case "set stock":
                    case "set buy":
                        break;
                    case "delete":
                        if (((ContextRz)x).xUserRz.IsDeveloper() || ((ContextRz)x).xUserRz.super_user)
                            act.Add(a);
                        break;
                    default:
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                }
            }
            return act;
        }
    }
    public class PropFilter
    {
        public virtual List<CoreVarValAttribute> FilterPropsForWeb(Context x, List<CoreVarValAttribute> h, string class_name)
        {
            List<CoreVarValAttribute> props = new List<CoreVarValAttribute>();
            try
            {
                switch (class_name.ToLower().Trim())
                {
                    case "company":
                        props = FilterCompany(x, h);
                        break;
                    case "calllog":
                        props = FilterCallLog(x, h);
                        break;
                    case "companyaddress":
                        props = FilterCompanyAddress(x, h);
                        break;
                    case "companycontact":
                        props = FilterCompanyContact(x, h);
                        break;
                    case "contactnote":
                        props = FilterContactNote(x, h);
                        break;
                    case "ordhed_quote":
                        props = FilterOrdHedQuote(x, h);
                        break;
                    case "ordhed_invoice":
                        props = FilterOrdHedInvoice(x, h);
                        break;
                    case "orddet_line":
                        props = FilterOrdDetLine(x, h);
                        break;
                    case "orddet_quote":
                        props = FilterOrdDetQuote(x, h);
                        break;
                    case "partrecord":
                        props = FilterPartRecord(x, h);
                        break;
                    case "ordhed_purchase":
                        props = FilterOrdHedPurchase(x, h);
                        break;
                    case "ordhed_rfq":
                        props = FilterOrdHedRFQ(x, h);
                        break;
                    case "ordhed_rma":
                        props = FilterOrdHedRMA(x, h);
                        break;
                    case "ordhed_sales":
                        props = FilterOrdHedSales(x, h);
                        break;
                    case "ordhed_service":
                        props = FilterOrdHedService(x, h);
                        break;
                    case "shippingaccount":
                        props = FilterShippingAccount(x, h);
                        break;
                    case "n_user":
                        props = FilterUser(x, h);
                        break;
                    case "ordhed_vendrma":
                        props = FilterOrdHedVendRMA(x, h);
                        break;
                    case "dealheader":
                        props = FilterDealHeader(x, h);
                        break;
                    case "ordhed":
                        props = FilterOrdHed(x, h);
                        break;
                    default:
                        return h;
                }
            }
            catch
            {
                return h;
            }
            return props;
        }
        protected virtual List<CoreVarValAttribute> FilterCompany(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "companyname":
                    case "agentname":
                    case "primaryphone":
                    case "primaryphoneextension":
                    case "primaryfax":
                    case "primaryemailaddress":
                    case "source":
                    case "companytype":
                    case "specialty":
                    case "notetext":
                    case "primarycontact":
                    case "description":
                    case "creditcardnumber":
                    case "creditcardtype":
                    case "nameoncard":
                    case "bank_wire_info":
                    case "security_code":
                    case "expiration_month":
                    case "expiration_year":
                    case "cardbillingaddr":
                    case "cardbillingzip":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterCallLog(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "callresult":
                    case "responsetype":
                    case "callnotes":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterCompanyAddress(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "defaultshipping":
                    case "description":
                    case "line1":
                    case "line2":
                    case "line3":
                    case "adrcity":
                    case "adrstate":
                    case "adrzip":
                    case "adrcountry":
                    case "defaultbilling":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterCompanyContact(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "contactnotes":
                    case "contactname":
                    case "companyname":
                    case "primaryphone":
                    case "primaryphoneextension":
                    case "alternatephone":
                    case "primaryfax":
                    case "alternatefax":
                    case "primaryemailaddress":
                    case "primarywebaddress":
                    case "jobtype":
                    case "contacttype":
                    case "contactgender":
                    case "maritalstatus":
                    case "interests":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterContactNote(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "companyname":
                    case "contactname":
                    case "notedate":
                    case "notetext":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterOrdHedQuote(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "ordertype":
                    case "ordernumber":
                    case "sub_total":
                    case "shippingamount":
                    case "ordertotal":
                    case "orderdate":
                    case "agentname":
                    case "primaryphone":
                    case "primaryfax":
                    case "primaryemailaddress":
                    case "internalcomment":
                    case "printcomment":
                    case "companyname":
                    case "contactname":
                    case "terms":
                    case "shipvia":
                    case "billingaddress":
                    case "shippingaddress":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterOrdDetQuote(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "fullpartnumber":
                    case "target_quantity":
                    case "target_price":
                    case "unitcost":
                    case "quantityordered":
                    case "unitprice":
                    case "manufacturer":
                    case "datecode":
                    case "condition":
                    case "packaging":
                    case "category":
                    case "description":
                    case "alternatepart":
                    case "internalpartnumber":
                    case "rohs_info":
                    case "internalcomment":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterOrdHedInvoice(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "ordertype":
                    case "ordernumber":
                    case "sub_total":
                    case "shippingamount":
                    case "ordertotal":
                    case "orderdate":
                    case "agentname":
                    case "primaryphone":
                    case "primaryfax":
                    case "primaryemailaddress":
                    case "internalcomment":
                    case "printcomment":
                    case "companyname":
                    case "contactname":
                    case "orderreference":
                    case "terms":
                    case "shipvia":
                    case "billingaddress":
                    case "shippingaddress":
                    case "trackingnumber":
                    case "shippingaccount":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterOrdDetLine(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "ordernumber_invoice":
                    case "status":
                    case "fullpartnumber":
                    case "quantity":
                    case "quantity_packed":
                    case "unit_price":
                    case "manufacturer":
                    case "datecode":
                    case "condition":
                    case "packaging":
                    case "category":
                    case "description":
                    case "alternatepart":
                    case "internal_customer":
                    case "ship_date_actual":
                    case "rohs_info":
                    case "shipvia_invoice":
                    case "shippingaccount_invoice":
                    case "tracking_invoice":
                    case "internalcomment":
                    case "ordernumber_purchase":
                    case "unit_cost":
                    case "quantity_unpacked":
                    case "datecode_purchase":
                    case "internal_vendor":
                    case "shipvia_purchase":
                    case "shippingaccount_purchase":
                    case "tracking_purchase":
                    case "receive_date_due":
                    case "receive_date_actual":
                    case "ordernumber_rma":
                    case "quantity_unpacked_rma":
                    case "unit_price_rma":
                    case "shipvia_rma":
                    case "shippingaccount_rma":
                    case "tracking_rma":
                    case "receive_date_rma_due":
                    case "receive_date_rma_actual":
                    case "ordernumber_sales":
                    case "ship_date_due":
                    case "lotnumber":
                    case "vendor_name":
                    case "vendor_contact_name":
                    case "stocktype":
                    case "ordernumber_service":
                    case "shipvia_service_out":
                    case "shippingaccount_service_out":
                    case "tracking_service_out":
                    case "ordernumber_vendrma":
                    case "quantity_packed_vendrma":
                    case "unit_price_vendrma":
                    case "shipvia_vendrma":
                    case "shippingaccount_vendrma":
                    case "tracking_vendrma":
                    case "ship_date_vendrma_due":
                    case "ship_date_vendrma_actual":
                    case "total_cost":
                    case "total_price":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterPartRecord(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "stocktype":
                    case "fullpartnumber":
                    case "alternatepart":
                    case "quantity":
                    case "price":
                    case "cost":
                    case "quantityallocated":
                    case "importid":
                    case "manufacturer":
                    case "datecode":
                    case "partsperpack":
                    case "condition":
                    case "packaging":
                    case "location":
                    case "boxnum":
                    case "description":
                    case "companyname":
                    case "companycontactname":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterOrdHedPurchase(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "ordertype":
                    case "ordernumber":
                    case "sub_total":
                    case "shippingamount":
                    case "ordertotal":
                    case "orderdate":
                    case "agentname":
                    case "primaryphone":
                    case "primaryfax":
                    case "primaryemailaddress":
                    case "internalcomment":
                    case "printcomment":
                    case "companyname":
                    case "contactname":
                    case "soreference":
                    case "terms":
                    case "shipvia":
                    case "billingaddress":
                    case "shippingaddress":
                    case "trackingnumber":
                    case "shippingaccount":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterOrdHedRFQ(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "ordertype":
                    case "ordernumber":
                    case "sub_total":
                    case "shippingamount":
                    case "ordertotal":
                    case "orderdate":
                    case "agentname":
                    case "primaryphone":
                    case "primaryfax":
                    case "primaryemailaddress":
                    case "internalcomment":
                    case "printcomment":
                    case "companyname":
                    case "contactname":
                    case "terms":
                    case "dockdate":
                    case "billingaddress":
                    case "shippingaddress":
                    case "shippingaccount":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterOrdHedRMA(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "ordertype":
                    case "ordernumber":
                    case "sub_total":
                    case "shippingamount":
                    case "ordertotal":
                    case "orderdate":
                    case "agentname":
                    case "primaryphone":
                    case "primaryfax":
                    case "primaryemailaddress":
                    case "internalcomment":
                    case "printcomment":
                    case "companyname":
                    case "contactname":
                    case "orderreference":
                    case "terms":
                    case "shipvia":
                    case "billingaddress":
                    case "shippingaddress":
                    case "trackingnumber":
                    case "shippingaccount":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterOrdHedSales(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "ordertype":
                    case "ordernumber":
                    case "sub_total":
                    case "shippingamount":
                    case "ordertotal":
                    case "orderdate":
                    case "agentname":
                    case "primaryphone":
                    case "primaryfax":
                    case "primaryemailaddress":
                    case "internalcomment":
                    case "printcomment":
                    case "companyname":
                    case "contactname":
                    case "orderreference":
                    case "terms":
                    case "shipvia":
                    case "billingaddress":
                    case "shippingaddress":
                    case "trackingnumber":
                    case "shippingaccount":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterOrdHedService(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "ordertype":
                    case "ordernumber":
                    case "sub_total":
                    case "shippingamount":
                    case "ordertotal":
                    case "orderdate":
                    case "agentname":
                    case "primaryphone":
                    case "primaryfax":
                    case "primaryemailaddress":
                    case "internalcomment":
                    case "printcomment":
                    case "companyname":
                    case "contactname":
                    case "terms":
                    case "shipvia":
                    case "billingaddress":
                    case "shippingaddress":
                    case "trackingnumber":
                    case "shippingaccount":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterShippingAccount(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "description":
                    case "accountnumber":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterUser(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "name":
                    case "phone":
                    case "phone_ext":
                    case "fax_number":
                    case "email_address":
                    case "cell_number":
                    case "login_name":
                    case "login_password":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterOrdHedVendRMA(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "ordertype":
                    case "ordernumber":
                    case "sub_total":
                    case "shippingamount":
                    case "ordertotal":
                    case "orderdate":
                    case "agentname":
                    case "primaryphone":
                    case "primaryfax":
                    case "primaryemailaddress":
                    case "internalcomment":
                    case "printcomment":
                    case "companyname":
                    case "contactname":
                    case "orderreference":
                    case "terms":
                    case "shipvia":
                    case "billingaddress":
                    case "shippingaddress":
                    case "trackingnumber":
                    case "shippingaccount":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterDealHeader(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "customer_name":
                    case "contact_name":
                    case "dealheader_name":
                    case "agentname":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
        protected virtual List<CoreVarValAttribute> FilterOrdHed(Context x, List<CoreVarValAttribute> h)
        {
            List<CoreVarValAttribute> act = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in h)
            {
                switch (a.Name.ToLower().Trim())
                {
                    case "date_created":
                    case "ordertype":
                    case "ordernumber":
                    case "sub_total":
                    case "shippingamount":
                    case "ordertotal":
                    case "orderdate":
                    case "agentname":
                    case "primaryphone":
                    case "primaryfax":
                    case "primaryemailaddress":
                    case "internalcomment":
                    case "printcomment":
                    case "companyname":
                    case "contactname":
                    case "terms":
                    case "shipvia":
                    case "billingaddress":
                    case "shippingaddress":
                    case "orderreference":
                    case "trackingnumber":
                    case "shippingaccount":
                    case "soreference":
                    case "dockdate":
                        if (!act.Contains(a))
                            act.Add(a);
                        break;
                    default:
                        break;
                }
            }
            return act;
        }
    }
}
