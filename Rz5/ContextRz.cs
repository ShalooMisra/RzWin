using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core;
using NewMethod;
using Tools.Database;
using System.IO;
using Rz5.Enums;

namespace Rz5
{
    public class ContextRz : ContextNM
    {
        public RzHook xHook;

        public ILeaderRz TheLeaderRz
        {
            get
            {
                return (ILeaderRz)TheLeader;
            }
        }
        public RzLogic TheLogicRz
        {
            get
            {
                return (RzLogic)TheLogic;
            }
        }

        new public SysRz5 Sys
        {
            get
            {
                return (SysRz5)TheSys;
            }
        }

        public SysRz5 TheSysRz
        {
            get
            {
                return (SysRz5)TheSys;
            }
        }

        public n_user xUserRz
        {
            get
            {
                return (n_user)xUser;
            }
        }

        new public RzLogic Logic
        {
            get
            {
                return (RzLogic)TheLogic;
            }
        }

        new public ILeaderRz Leader
        {
            get
            {
                return TheLeaderRz;
            }
        }

        public AccountLogic Accounts
        {
            get
            {
                return Sys.TheAccountLogic;
            }
        }

        public ContextRz()
        {

        }
        public ContextRz(Leader l) : base(l)
        {

        }

        public String CustomerId = "";  //this is for the web so that different customer contexts can be referenced by id

        public override void Apply(Context x)
        {
            base.Apply(x);
            ((ContextRz)x).CustomerId = CustomerId;
        }

        public override Context Create()
        {
            return new ContextRz();
        }
        public List<AppSection> AppSections
        {
            get
            {
                List<AppSection> ret = new List<AppSection>();
                ret.Add(new AppSection("Parts", "Part Search", "Search all inventory (stock/consigned/excess) and related information to these parts (quotes/sales/purchases)."));
                ret.Add(new AppSection("People", "People Search", "Search for companies or contacts using search filters for better results."));
                ret.Add(new AppSection("Home", "Home Screen", "View user order batch information req/quotes/calls/etc."));
                ret.Add(new AppSection("Orders", "Order Search", "Search for orders or line items using search filters for better results."));
                //ret.Add(new AppSection("OrderBatch", "Order Batch", "Gather customer requirements, vendor bids, and convert into a Sales Order via the Order Batch."));
                if (Sys.Logic.UseAlternateReqScreens)
                {
                    ret.Add(new AppSection("ReqSourcing", "Req Sourcing", "Source customer requirements"));
                    ret.Add(new AppSection("ReqQuoting", "Req Quoting", "Quote quote sourced customer requirements"));
                }
                ret.Add(new AppSection("Panel", "User Panel", "Edit system settings and users/teams."));
                return ret;
            }
        }

        private string GetAccurateClassId(String classId, String uid, String alternateTable)
        {
            if (!Tools.Strings.StrExt(alternateTable))
            {
                if (classId == "ordhed")
                {
                    String strType = Data.SelectScalarString("select ordertype from ordhed where unique_id = '" + uid + "'");
                    if (Tools.Strings.StrExt(strType))
                        return "ordhed_" + strType.ToLower();
                }
                else if (classId == "orddet")
                {
                    String strType = Data.SelectScalarString("select ordertype from orddet where unique_id = '" + uid + "'");
                    if (Tools.Strings.StrExt(strType))
                        return "orddet_" + strType.ToLower();
                }
            }
            return classId;
        }
        public override Item GetById(String classId, String uid)
        {
            if (!Tools.Strings.StrExt(uid))
                return null;

            classId = GetAccurateClassId(classId, uid, "");
            return base.GetById(classId, uid);
        }
        public override Item GetById(String classId, String uid, String alternateTable)
        {
            if (Tools.Strings.StrCmp(alternateTable, classId))
                alternateTable = "";
            classId = GetAccurateClassId(classId, uid, alternateTable);
            return base.GetById(classId, uid, alternateTable);
        }
        public override Item GetById(String classId, String uid, String alternateTable, DataConnection alternateData)
        {
            if (Tools.Strings.StrCmp(alternateTable, classId))
                alternateTable = "";
            classId = GetAccurateClassId(classId, uid, alternateTable);
            return base.GetById(classId, uid, alternateTable, alternateData);
        }

        //public override void StructureCheck(Context x)
        //{
        //    base.StructureCheck();

        //    if (!Tools.Strings.StrCmp(context.Logic.PictureData((ContextRz)x).TheKey.DatabaseName, x.TheData.TheKeySql.DatabaseName))
        //    {
        //        CoreClassHandle pics = TheSys.CoreClassGet("partpicture");
        //        DataSql.StructureCheckClass(this, TheData, context.Logic.PictureData((ContextRz)x), pics, "partpicture", new List<Field>());
        //        //MakeClassDataStructure(pics, , false, "partpicture");
        //    }
        //}

        new public DataConnectionSqlServer Connection
        {
            get
            {
                return (DataConnectionSqlServer)Data.Connection;
            }
        }

        public override string ProgramCaption
        {
            get
            {
                return "Rz";
            }
        }

        public String DateCodeCaption
        {
            get
            {
                if (Tools.Strings.HasString(Data.DatabaseName, "tekmedical"))
                    return "Release";
                else
                    return "Date Code";
            }
        }
    }

    public class AppSection
    {
        public String Name;
        public String Caption;
        public String Description;
        public AppSection(String name, String caption, String descr)
        {
            Name = name;
            Caption = caption;
            Description = descr;
        }
    }
    //Begin ILeaderRz
    public interface ILeaderRz : NewMethod.ILeaderNM
    {
        List<ActHandle> FilterActsForWeb(Context x, List<ActHandle> h, nObject o);
        bool IsWeb();
        //bool CheckLineStatusForTotals(ContextRz x, orddet_line l);
        //void MonthlyPaymentsShow(ContextRz x);
        void UpdateDetailFromPack(ContextRz x, orddet_line l, pack p);
        string GetOrddetFieldsExtra(ContextRz x, string strFields);
        account ShowQBAccountImportAssist(string acnt, string ref_num, double amnt, DateTime date);
        nObject ChooseObjectFromCollection(ContextRz x, ArrayList objects);
        DateTime ChooseDate(DateTime def, string cap);
        void ShowPrintCheck(ContextRz x, List<payment_out> l, account a = null);
        void ShowAccountingReport(ContextRz context, AccountingReport r);
        void ExportInventory(ContextRz x);
        void PartSearchShow(ContextRz x, ActArgs args);
        void PartSearchShow(ContextRz x, String partToSearch);
        void MultiSearchShow(ContextRz x, String partToSearch);
        void OEMProductsShow(ContextRz x);

        void PeopleSearchShow(ContextRz x, ActArgs args);
        void OrderSearchShow(ContextRz x, ActArgs args);
        void OrderSearchShow(ContextRz x, Enums.OrderType typeToSearch, String partToSearch);
        void ShippingScreenShow(ContextRz x, ActArgs args);

        bool AllChoicesShow(ContextRz x);
        bool AddNewChoiceList(ContextRz x);
        void CloseTabsByID(ContextRz x, ArrayList ids);
        void CloseTabsByID(ContextRz x, String id);
        bool ContactReminderShow(ContextRz x);
        bool HomeScreenShow(ContextRz x);
        partrecord StockChoose(ContextRz context, String part);
        void ImportCompanies(ContextRz x, ActArgs args);
        void ImportContacts(ContextRz x, ActArgs args);
        company ChooseCompany(ContextRz context);
        company ChooseCompany(ContextRz context, String companyname, String companyemailaddress, String contactname, String companyphone, String companyfax, bool inhibitshow);
        bool ChooseCompany(ContextRz x, ref company comp, ref companycontact cont);
        List<SalesLineGroup> ChooseOrderLines(ContextRz context, Rz5.ordhed_sales sale, List<SalesLineGroup> sections, Rz5.Enums.OrderType t, List<ordhed> existing, ref bool cancel);
        String QBCreateCompany(ContextRz x, Enums.CompanySelectionType type, company v, String address1, String address2);
        bool ShowAddQBCompany(company c, ref string strCompanyName, Enums.CompanySelectionType t, String strAddress1, String strAddress2);
        void QBCreateTerms(ContextRz x, String terms);
        string NewCompanyNameGet(ContextRz context, string strName);
        //the leader shouldn't create and show info like this; its in OrderLogic now
        //bool OrderBatchShow(ContextRz x);
        RMASelectionResult RMASelectionGet(ContextRz context, RMASelectionArgs args);
        bool OrderLinksShow(ContextRz x, string order_uid);
        bool PaymentsShow(ContextRz x, string order_uid);
        bool AssignAgentShow(ContextRz x, ArrayList companies);
        bool SetCompanyType(ContextRz x, ArrayList companies);
        bool SetCompanyGroup(ContextNM x, ArrayList cs, bool undo, String strClass, String strGroup);
        //bool ViewLogsShow(ContextRz x, nObject o);
        bool ViewChangeHistory(ContextRz x, nObject o);
        string ChooseManufacturer(ContextRz x, string partNumber, bool addMfgToChoiceList);
        void UserPanelShow(ContextRz x);
        bool UserManagerShow(ContextRz x);
        bool CompanyInfoShow(ContextRz x);
        company CompanyNewShow(ContextRz x);
        bool ReqSourcingManagerShow(ContextRz x);
        bool ReqQuotingManagerShow(ContextRz x);
        string GetReceiveQuantityString_QC(ContextRz q, partrecord p, ordhed o, orddet d, long qDefault);
        RzHook HookCreate(ContextRz context);
        LoginInfo LoginInfoAskOnThread(ContextRz context, bool closeOnAccept, LoginInfo xLoginInfo = null);
        void PopLogin(ContextRz context);
        bool CheckLogin();
        void CloseLogin();
        void UpdateCheck(ContextRz x);
        void LiveSupportRequest(ContextRz context);
        void DatabaseManagerShow(ContextRz x);
        void QuickBooksSettingsShow(ContextRz x);
        void EmailBlasterShow(ContextRz context);
        void PostQBShow(ContextRz context, Enums.OrderType type);
        void ImportShow(ContextRz context);
        void PaymentScreenShow(ContextRz context);
        void PhoneMonitorShow(ContextRz context);
        void DutyMonitorShow(ContextRz context);
        void ToolsShow(ContextRz context);
        void ToolsSqlShow(ContextRz context);
        void ToolsTextShow(ContextRz context);
        void UserApply(ContextRz context);
        void ChatWithSomeone(ContextRz context);
        void SandboxShow(ContextRz context);
        void InspectionReportShow(ContextRz x, qualitycontrol report);


        void DataTableSizesManage(ContextRz context);
        void DataTableDevelop(ContextRz context);
        void DataFieldsDevelop(ContextRz context);
        void DataSourcesList(ContextRz context);
        void TestOptionsShow(ContextRz context);
        void CreditCardNumbersShow(ContextRz context);
        void OrderLinksWorkBenchShow(ContextRz x, ActArgs args);
        void OrderLinkChoose(ContextRz x, OrderLinkArgs args);

        //Panel
        void RestoreCompany(ContextRz context);
        void RestoreContact(ContextRz context);
        void ReportShow(ContextRz context, Core.Report r, bool autoCalculate);
        void ReportShow(ContextRz context, Core.Report r, ReportArgs args);
        void CheckRegisterShow(ContextRz context, account a);
        void BFContactEmailScannerShow(ContextRz context);
        void NCContactEmailScannerShow(ContextRz context);
        emailtemplate AskForEmailTemplate(nObject xObject);
        void CacheCompanies();
        void StockEvaluatorReport(dealheader d);
        void ShowDealItem(ContextRz context, dealheader deal, orddet detail);
        void ImportFromQB(ContextRz context);

        void ScanBrokerForumBids(ContextRz context);
        void ScanBrokerForumRFQs(ContextRz context);
        void ShowHelp(ContextRz context);
        MakeOrderArgs AskForMakeOrderArgs(Enums.OrderType orderType);
        company AskForCompany(ContextRz context, String name);
        DepotConnection ChooseDepotConnection();
        RMASelectionResult ChooseVendorRMA(RMASelectionArgs args);
        void ShowTransmitOrders(ContextRz context, List<ordhed> a, Enums.TransmitType ty);
        void ShowPartCrossReference(Context x, PartCrossReferenceSearchOptions options);
        void AskForLineCancelArgs(ContextRz context, OrderLineCancelArgs args);
        ArrayList ChooseFromArray(ContextRz context, ArrayList choices, String caption);
        //bool SendOutlookMessage(string ToAddress, string BodyText, string SubjectString, bool boolTextOnly, bool boolUserEdit, string CCString, string strAttachFile, bool boolForceSilent, ArrayList colCC, string strBCC, string strReplyAddress, string strOtherAttachment, string strSignature, bool bDeliverNow, ref string error);
        String AskForSalesOrderIdToAdd();
        void AskForOrder(ref String type, ref String order);
        String ChooseGroup(n_user u);
        void ManageImportsShow(ContextRz context);

        void QCShow(ContextRz x, pack p, orddet_line l, string order_number, qualitycontrol q);
        void ReceivePO(ContextRz context, List<orddet_line> lines);
        void ReceiveRMA(ContextRz context, List<orddet_line> lines);
        void ShipVRMA(ContextRz context, List<orddet_line> lines);
        void ReceiveService(ContextRz context, List<orddet_line> lines);
        void ShipService(ContextRz context, List<orddet_line> lines);
        void ShipInvoice(ContextRz context, List<orddet_line> lines);

        void AddPanelOptions(ContextRz x, PanelLogic l, ActHandle h);
        void AddCompanyOptions(ContextRz x, CompanyLogic l, ActHandle h);
        void ReportsShow(ContextRz x);
        void UserAccountsShow(ContextRz x);
        DateTime AskPostpone(ContextRz x, DateTime date);
        void PhoneReportShow(ContextRz x);
        void ChatHistoryShow(ContextRz context);
        void ConsolidateCompanies(ContextRz context, ArrayList companies);
        void ConsolidateContacts(ContextRz context, ArrayList contacts);
        void PrintBarcodeLabel(ContextRz context, orddet_line line, string strLabel = "outgoing_line_item");
        void MergeChoose(ContextRz context, OrderLinkArgs args);
        void SearchForCompany(ContextRz context, company cm, NewMethod.ListArgs.IGenericNotify notify);
        void AccountsShow(ContextRz context);
        void CurrenciesShow(ContextRz context);
        void JournalEntryShow(ContextRz context);
        void PostOrdersShow(ContextRz context);
        void ReceivePaymentsShow(ContextRz context, company customer);
        void PayBillsShow(ContextRz context, company vendor);
        void DepositsShow(ContextRz context);
        void ReconcileBankShow(ContextRz context);
        void ReconcileCCShow(ContextRz context);
        void EditBudgetShow(ContextRz context);
        account AskForNewAccount(ContextRz context, string parent_id);
        string GetAccountReportLink(string account_id, string text, AccountingReportAction a);

        //KT - Companycredits        
        List<companycredit> ChooseCompanyCredit(ContextRz context, company company, ordhed ordhed);
        void ShowBinSwapper(Context x, ActArgs a);

        //KT Refactored from LeaderWinUserRzSensible
        void ApplyServiceCharge(ContextRz context, ordhed_service service, ref ordhed_sales sale, ref ordhed_invoice invoice);
        void InspectionReportShowLegacy(Rz5.ContextRz x, Rz5.qualitycontrol report);
        void ShowUserInfoChanges();

        //KT Refactored from ILeaderSensible.cs
        String ChooseIndustrySection(ContextRz context);
        ArrayList EnterLabelLines(orddet_line line);

        String VerifyCompanyName(String name);

        //KT 4-5-2016 - Moving the Choose FQ / SO out of OrderTree and into an interface so I can use in other places:
        ordhed ChooseFQSO(ContextRz x, string company_id, string t);

        void ValidationFormShow(ContextRz x, validation_form v);

        void GetDockDateChecker(ContextRz x, orddet_line l);
        void ShowOrderTestOptions(ContextRz x, ordhed o);
        void ManageHubspot(ContextRz x, object o);
        void RzPublishShow(ContextRz x);
        //bool CompanyHasTermsConditions(ContextRz context, company currentCompany);
        bool ConfirmCustomerTermsConditions(ContextRz context, company currentCompany);
        void ResolveTBDVendor(ContextRz x, orddet_line l);
    }

    public class LeaderServiceRz : Leader, ILeaderRz
    {
        public LeaderServiceRz()
            : base()
        {

        }
        public List<ActHandle> FilterActsForWeb(Context x, List<ActHandle> h, nObject o) { return null; }
        public bool IsWeb()
        {
            return false;
        }
        //public void ChatScreenMakeExist(RzHook hook, ChatSession s, bool initRe)
        //{

        //}
        public void UpdateDetailFromPack(ContextRz x, orddet_line l, pack p)
        {

        }
        public string GetOrddetFieldsExtra(ContextRz x, string strFields)
        {
            return strFields;
        }
        //public bool CheckLineStatusForTotals(ContextRz x, orddet_line l)
        //{
        //    return l.Status != Rz4.Enums.OrderLineStatus.Void && !l.was_rma;
        //}
        public account ShowQBAccountImportAssist(string acnt, string ref_num, double amnt, DateTime date) { throw new NotImplementedException(); }
        public void ShowPrintCheck(ContextRz x, List<payment_out> l, account a = null) { throw new NotImplementedException(); }
        public account AskForNewAccount(ContextRz context, string parent_id) { throw new NotImplementedException(); }
        public void ShowAccountingReport(ContextRz context, AccountingReport r) { throw new NotImplementedException(); }
        public void ReconcileBankShow(ContextRz context) { throw new NotImplementedException(); }
        public void ReconcileCCShow(ContextRz context) { throw new NotImplementedException(); }
        public string GetAccountReportLink(string account_id, string text, AccountingReportAction a) { throw new NotImplementedException(); }
        public nObject ChooseObjectFromCollection(ContextRz x, ArrayList objects) { return null; }
        public void CheckRegisterShow(ContextRz context, account a) { }
        public void CloseTabsByID(ContextRz x, ArrayList ids) { }
        public void CloseTabsByID(ContextRz x, String id) { }
        public void MonthlyPaymentsShow(ContextRz x) { }
        public void BFContactEmailScannerShow(ContextRz context) { }
        public void NCContactEmailScannerShow(ContextRz context) { }
        public void ReceivePO(ContextRz context, List<orddet_line> lines) { }
        public void ReceiveRMA(ContextRz context, List<orddet_line> lines) { }
        public void ShipVRMA(ContextRz context, List<orddet_line> lines) { }
        public void ReceiveService(ContextRz context, List<orddet_line> lines) { }
        public void ShipService(ContextRz context, List<orddet_line> lines) { }
        public void ShipInvoice(ContextRz context, List<orddet_line> lines) { }
        public void QCShow(ContextRz x, pack p, orddet_line l, string order_number, qualitycontrol q) { }
        public DateTime ChooseDate(DateTime def, string cap) { return def; }
        public void ExportInventory(ContextRz x) { }
        public NewMethod.n_user AskForUser(ArrayList choices, bool allowAdd) { return null; }
        public NewMethod.n_user AskForUser() { return null; }
        public RMASelectionResult RMASelectionGet(ContextRz context, RMASelectionArgs args) { return null; }
        public List<ColumnAction> AskForColumnActions(System.Data.DataTable original) { return null; }
        public bool AskForAdminRights() { return false; }
        public String ChooseMultipleChoices(ContextNM x, String strName, String strCaption, String defaultChoicesFullBarSeparated) { return ""; }
        public String ChooseOneChoice(ContextNM x, String strName) { return ""; }
        public String ChooseOneChoice(ContextNM x, String strName, String strCaption) { return ""; }
        public String ChooseOneChoice(ContextNM x, List<string> theList, String strCaption) { return ""; }
        public company ChooseCompany(ContextRz context) { return null; }
        public company ChooseCompany(ContextRz context, String companyname, String companyemailaddress, String contactname, String companyphone, String companyfax, bool inhibitshow) { throw new Exception(); }
        public bool ChooseCompany(ContextRz x, ref company comp, ref companycontact cont) { return false; }
        public List<SalesLineGroup> ChooseOrderLines(ContextRz context, Rz5.ordhed_sales sale, List<SalesLineGroup> sections, Rz5.Enums.OrderType t, List<ordhed> existing, ref bool cancel) { return null; }
        public NewMethod.Enums.DataConversionType AskConversionType(ref String def, String instructions, FieldType fieldType) { return NewMethod.Enums.DataConversionType.Cancel; }
        public DepotConnection ChooseDepotConnection() { return null; }
        public company AskForCompany(ContextRz context, String name) { throw new NotImplementedException(); }
        public partrecord StockChoose(ContextRz context, String part) { throw new NotImplementedException(); }
        public MakeOrderArgs AskForMakeOrderArgs(Enums.OrderType orderType) { throw new NotImplementedException(); }
        public void ImportCompanies(ContextRz x, ActArgs args) { }
        public void ImportContacts(ContextRz x, ActArgs args) { }
        public void ShowHelp(ContextRz context) { }
        public void ImportFromQB(ContextRz context) { }
        public void ScanBrokerForumBids(ContextRz context) { }
        public void ScanBrokerForumRFQs(ContextRz context) { }
        public void ShowDealItem(ContextRz context, dealheader deal, orddet detail) { }
        public void StockEvaluatorReport(dealheader d) { }
        public void CacheCompanies() { }
        public emailtemplate AskForEmailTemplate(nObject xObject) { return null; }
        public void PopLogin(ContextRz context) { }
        public virtual void ArchivedBOMImportShow(ContextRz x, ActArgs args) { }

        public void PartSearchShow(ContextRz x, ActArgs args) { }
        public void PeopleSearchShow(ContextRz x, ActArgs args) { }
        public void OrderSearchShow(ContextRz x, ActArgs args) { }
        public void ShippingScreenShow(ContextRz x, ActArgs args) { }
        public void MultiSearchShow(ContextRz x, String partNumber) { }
        public void OEMProductsShow(ContextRz x) { }

        public string NewCompanyNameGet(ContextRz x, String compName) { return ""; }
        public bool ContactReminderShow(ContextRz x) { return false; }
        public bool HomeScreenShow(ContextRz x) { return false; }
        public void ProfitReportShow(ContextRz x) { throw new NotImplementedException(); }
        public bool OrderBatchShow(ContextRz x) { return false; }
        public bool OrderLinksShow(ContextRz x, string order_uid) { return false; }
        public bool PaymentsShow(ContextRz x, string order_uid) { return false; }
        public bool ViewLogsShow(ContextRz x, nObject o) { return false; }
        public bool ViewChangeHistory(ContextRz x, nObject o) { return false; }
        public string ChooseManufacturer(ContextRz x, string partNumber, bool allowManualEntry) { return ""; }
        public void UserPanelShow(ContextRz x) { throw new NotImplementedException(); }
        public bool UserManagerShow(ContextRz x) { return false; }
        public company CompanyNewShow(ContextRz x) { return null; }
        public bool ReqSourcingManagerShow(ContextRz x) { return false; }
        public bool ReqQuotingManagerShow(ContextRz x) { return false; }
        public string GetReceiveQuantityString_QC(ContextRz q, partrecord p, ordhed o, orddet d, long qDefault) { return ""; }
        public RzHook HookCreate(ContextRz context) { throw new NotImplementedException(); }
        public bool CompanyInfoShow(ContextRz x) { return false; }
        public bool SetCompanyType(ContextRz x, ArrayList companies) { return false; }
        public bool SetCompanyGroup(ContextNM x, ArrayList cs, bool undo, String strClass, String strGroup) { return false; }
        public bool AddNewChoiceList(ContextRz x) { return false; }
        public bool AssignAgentShow(ContextRz x, ArrayList companies) { return false; }
        public bool AllChoicesShow(ContextRz x) { return false; }
        public LoginInfo LoginInfoAskOnThread(ContextRz context, bool closeOnAccept, LoginInfo xLoginInfo = null) { return null; }
        public void PopLogin(ContextRz context, DataConnectionSqlServer xd) { }
        public bool CheckLogin() { return false; }
        public void CloseLogin() { }
        public void UpdateCheck(ContextRz x) { }
        public void LiveSupportRequest(ContextRz x) { }
        public void DatabaseManagerShow(ContextRz x) { }
        public void QuickBooksSettingsShow(ContextRz x) { }
        public void EmailBlasterShow(ContextRz context) { }
        public void PostQBShow(ContextRz context, Enums.OrderType type) { }
        public void ImportShow(ContextRz context) { }
        public void PaymentScreenShow(ContextRz context) { }
        public void PhoneMonitorShow(ContextRz context) { }
        public void DutyMonitorShow(ContextRz context) { }
        public void ToolsShow(ContextRz context) { }
        public void ToolsSqlShow(ContextRz context) { }
        public void ToolsTextShow(ContextRz context) { }
        public void UserApply(ContextRz context) { }
        public void ChatWithSomeone(ContextRz context) { }
        public void SandboxShow(ContextRz context) { }
        public void InspectionReportShow(ContextRz x, qualitycontrol report) { }

        public void DataTableDevelop(ContextRz context) { }
        public void DataSourcesList(ContextRz context) { }
        public void TestOptionsShow(ContextRz x) { }
        public void DataFieldsDevelop(ContextRz x) { }
        public void DataTableSizesManage(ContextRz x) { }
        public void OrderLinksWorkBenchShow(ContextRz x, ActArgs args) { }
        public void OrderLinkChoose(ContextRz x, OrderLinkArgs args) { }
        public void RestoreOrder(ContextRz context) { }
        public void RestoreOrderLine(ContextRz context) { }
        public void RestoreCompany(ContextRz context) { }
        public void RestoreContact(ContextRz context) { }
        public void CreditCardNumbersShow(ContextRz context) { }
        public void ReportShow(ContextRz context, Core.Report r, bool autoCalculate) { }
        public void ReportShow(ContextRz context, Core.Report r, ReportArgs args) { }
        public void GridShow(Context x, NewMethod.Grid g, String caption) { }
        public String QBCreateCompany(ContextRz x, Enums.CompanySelectionType type, company v, String address1, String address2) { return ""; }
        public bool ShowAddQBCompany(company c, ref string strCompanyName, Enums.CompanySelectionType t, String strAddress1, String strAddress2) { return false; }
        public void QBCreateTerms(ContextRz x, String terms) { }
        public void PartSearchShow(ContextRz x, String partToSearch) { }
        public void OrderSearchShow(ContextRz x, Enums.OrderType typeToSearch, String partToSearch) { }
        public void ShowTransmitOrders(ContextRz context, List<ordhed> a, Enums.TransmitType ty) { }
        public void ShowPartCrossReference(Context x, PartCrossReferenceSearchOptions options) { }
        public void AskForLineCancelArgs(ContextRz context, OrderLineCancelArgs args) { }
        //public company ChooseCompany(ContextRz context, String companyname, String companyemailaddress, String contactname, String companyphone, String companyfax, bool inhibitshow) { throw new NotImplementedException(); }
        public DateTime AskPostpone(ContextRz x, DateTime date) { throw new NotImplementedException(); }
        public void PhoneReportShow(ContextRz context) { throw new NotImplementedException(); }
        public void ChatHistoryShow(ContextRz context) { throw new NotImplementedException(); }
        public void ConsolidateCompanies(ContextRz context, ArrayList companies) { throw new NotImplementedException(); }
        public void ConsolidateContacts(ContextRz context, ArrayList contacts) { throw new NotImplementedException(); }
        public void PrintBarcodeLabel(ContextRz context, orddet_line line, string strLabel = "outgoing_line_item") { throw new NotImplementedException(); }
        public void MergeChoose(ContextRz context, OrderLinkArgs args) { throw new NotImplementedException(); }
        public void SearchForCompany(ContextRz context, company cm, NewMethod.ListArgs.IGenericNotify notify) { throw new NotImplementedException(); }
        public void ReceivePaymentsShow(ContextRz context, company customer) { throw new NotImplementedException(); }
        public void PayBillsShow(ContextRz context, company vendor) { throw new NotImplementedException(); }
        public void DepositsShow(ContextRz context) { throw new NotImplementedException(); }
        public void EditBudgetShow(ContextRz context) { throw new NotImplementedException(); }
        //KT Company Credits}
        public List<companycredit> ChooseCompanyCredit(ContextRz context, company company, ordhed ordhed) { throw new NotImplementedException(); }
        public void ShowBinSwapper(Context x, ActArgs a) { throw new NotImplementedException(); }


        //KT Refactored from LeaderWinUserRzSensible
        public void ApplyServiceCharge(ContextRz context, ordhed_service service, ref ordhed_sales sale, ref ordhed_invoice invoice) { throw new NotImplementedException(); }
        public virtual string ChooseIndustrySection(ContextRz x) { throw new NotImplementedException(); }
        public ArrayList EnterLabelLines(orddet_line line) { throw new NotImplementedException(); }
        public void InspectionReportShowLegacy(Rz5.ContextRz x, Rz5.qualitycontrol report) { throw new NotImplementedException(); }
        public void ShowUserInfoChanges() { throw new NotImplementedException(); }
        public String VerifyCompanyName(String name) { throw new NotImplementedException(); }

        //KT Adding this so I can access frmAddToFQSO from other places in the code.
        public ordhed ChooseFQSO(ContextRz x, string company_id, string t) { throw new NotImplementedException(); }

        public void ValidationFormShow(ContextRz x, validation_form v) { throw new NotImplementedException(); }

        public void GetDockDateChecker(ContextRz x, orddet_line l) { throw new NotImplementedException(); }
        public void ShowOrderTestOptions(ContextRz x, ordhed o) { throw new NotImplementedException(); }
        public void ManageHubspot(ContextRz x, object c) { throw new NotImplementedException(); }

        public void RzPublishShow(ContextRz x) { throw new NotImplementedException(); }
        public bool CompanyHasTermsConditions(ContextRz context, company currentCompany) { throw new NotImplementedException(); }
        public bool ConfirmCustomerTermsConditions(ContextRz context, company currentCompany) { throw new NotImplementedException(); }
        public void ResolveTBDVendor(ContextRz x, orddet_line l) { throw new NotImplementedException(); }
        


        //End LeaderServiceRz
        public String LogFile
        {
            get
            {
                return Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppParentPath()) + "RzServiceLog.txt";
            }
        }

        public void StartLog()
        {
            if (File.Exists(LogFile))
            {
                lock (SyncRoot)
                {
                    File.Delete(LogFile);
                }
            }
        }

        public static Object SyncRoot = new Object();
        public override void Comment(string comment, System.Drawing.Color color)
        {
            base.Comment(comment, color);

            try
            {
                lock (SyncRoot)
                {
                    FileStream f = new FileStream(LogFile, FileMode.Append, FileAccess.Write);
                    StreamWriter w = new StreamWriter(f);
                    w.WriteLine(DateTime.Now.ToString() + "  :  " + comment);
                    w.Close();
                    w.Dispose();
                    w = null;
                    f.Close();
                    f.Dispose();
                    f = null;
                }
            }
            catch { }
        }

        public RMASelectionResult ChooseVendorRMA(RMASelectionArgs args)
        {
            throw new NotImplementedException();
        }

        public ArrayList ChooseFromArray(ContextRz context, ArrayList choices, String caption) { throw new NotImplementedException(); }
        //public bool SendOutlookMessage(string ToAddress, string BodyText, string SubjectString, bool boolTextOnly, bool boolUserEdit, string CCString, string strAttachFile, bool boolForceSilent, ArrayList colCC, string strBCC, string strReplyAddress, string strOtherAttachment, string strSignature, bool bDeliverNow, ref string error) { throw new NotImplementedException(); }
        public String AskForSalesOrderIdToAdd() { throw new NotImplementedException(); }
        public void AskForOrder(ref String type, ref String order) { throw new NotImplementedException(); }
        public String ChooseGroup(n_user u) { throw new NotImplementedException(); }
        public void UserAccountsShow(ContextRz context) { throw new NotImplementedException(); }
        public void ReportsShow(ContextRz context) { throw new NotImplementedException(); }

        public void AddCompanyOptions(ContextRz context, CompanyLogic logic, ActHandle h) { throw new NotImplementedException(); }
        public void AddPanelOptions(ContextRz context, PanelLogic logic, ActHandle h) { throw new NotImplementedException(); }
        public void ManageImportsShow(ContextRz context) { throw new NotImplementedException(); }

        public void AccountsShow(ContextRz context) { throw new NotImplementedException(); }
        public void CurrenciesShow(ContextRz context) { throw new NotImplementedException(); }
        public void JournalEntryShow(ContextRz context) { throw new NotImplementedException(); }
        public void PostOrdersShow(ContextRz context) { throw new NotImplementedException(); }
        public account ChooseAnAccount(ContextRz context, String caption, AccountCriteria criteria) { throw new NotImplementedException(); }
       
    }
}

