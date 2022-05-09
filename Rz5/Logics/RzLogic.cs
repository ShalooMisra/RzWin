using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;



using Tools;
//using ToolsWin;
using Core;
using NewMethod;
using Tools.Database;
//using Tie;
using CoreWin;
using System.Linq;

namespace Rz5
{
    public class RzLogic : NewMethod.Logic
    {
        public static String TestServer = "vanburgh02";
        public static String TestDatabase = "rz3";
        public static bool CacheActiveCompaniesOnly = false;

        public static String SalesServer = "";
        public static String SalesDatabase = "";
        public static String ExportFolder = "";
        public static String GenericLabelContactName = "";

        public String CompanyIdentifier = "";
        public String LastBidID = "";
        public String LocalAreaCode = "";
        public String DefaultPrinterName = "";

        public String CompanyName = "";
        //public String NotifyEmailAddress = "notify@recognin.com";
        //public String NotifyEmailPassword = "N0tify";
        public String NotifyEmailAddress = "ktill@sensiblemicro.com";
        public String NotifyEmailPassword = "";
        public bool UpperCaseEverything = false;

        //company switches
        //public bool IsCTG = false;
        //public bool IsBozz = false;
        public bool IsDemo = false;
        //public bool IsUltimate = false;
        //public bool IsGlobal = false;
        //public bool IsMagellan = false;
        //public bool IsFoundation = false;
        //public bool IsArrowtronics = false;
        //public bool IsKimtronics = false;
        //public bool IsAtometron = false;
        //public bool IsBraun = false;
        //public bool IsTim = false;
        //public bool IsEarthTron = false;
        //public bool IsAxiom = false;
        //public bool IsIsttar = false;
        //public bool IsINet = false;
        //public bool IsNTC = false;
        //public bool IsPipeline = false;
        //public bool IsTesla = false;
        //public bool IsGemTek = false;
        //public bool IsMerit = false;
        public bool IsPhoenix = false;
        //public bool IsPhoenixWarehouse = false;
        public bool IsPhoenixBrazil = false;
        //public bool IsPhoenixEMEA = false;
        //public bool IsCI = false;
        //public bool IsSelect = false;
        //public bool IsVoxx = false;
        public bool IsForte = false;
        //public bool IsIntegrity = false;
        //public bool IsPrism = false;
        //public bool IsLegend = false;
        //public bool IsTES = false;
        //public bool IsZeris = false;
        //public bool IsIconix = false;
        //public bool IsVoyager = false;
        //public bool IsConcord = false;
        //public bool IsMarketPlace = false;
        //public bool IsG2 = false;
        //public bool IsAlfa = false;
        //public bool IsCuetech = false;
        //public bool IsRecognin = false;
        //public bool IsSTL = false;
        //public bool IsForex = false;

        //settings

        public bool CreditQuoteCreator = false;
        public Double MarkUpPercentage = 0;
        public Int32 MarkUpMinimum = 0;
        public Double DefaultHandling = 0;
        public String DefaultBuyerID = "";
        public Double CreditCardPercent = 0;
        public bool AutoCloseOrders = false;
        public bool VerifyOrderData = false;
        public String DefaultEmailAddress = "";
        public bool CompareDistilledCompanyNames = true;
        public bool UseAlternateReqScreens = false;
        public bool UseMergedQuotes = false;
        public bool AssignOrdersToCompanyAgent = false;
        private bool m_ContactsFollowCompanies = true;
        public virtual bool ContactsFollowCompanies
        {
            get
            {
                return m_ContactsFollowCompanies;
            }
            set
            {
                m_ContactsFollowCompanies = value;
            }
        }



        //public String DefaultAgentName
        //{
        //    get
        //    {
        //        if( DefaultUser == null )
        //            return "";
        //        else
        //            return DefaultUser.name;
        //    }
        //}
        //public NewMethod.n_user DefaultUser;
        public bool EnforceInventory = false;
        public String ShippingCaption = "";
        public String HandlingCaption = "";
        public String TaxCaption = "";


        public String InternalUPS;
        public String InternalFedex;
        public String InternalDHL;



        public void SetInternalUPS(ContextRz context, String value)
        {
            InternalUPS = value;
            n_set.SetSetting(context, "internal_ups", value);
        }

        public void SetInternalFedex(ContextRz context, String value)
        {
            InternalFedex = value;
            n_set.SetSetting(context, "internal_fedex", value);
        }

        public void SetInternalDHL(ContextRz context, String value)
        {
            InternalDHL = value;
            n_set.SetSetting(context, "internal_dhl", value);
        }


        public String InternalOther = "";

        String m_ShipToAddress = "";
        public String ShipToAddress
        {
            get
            {
                return m_ShipToAddress;
            }
            set
            {
                m_ShipToAddress = value;
            }
        }


        public String ServerFolderPath = "";
        //public bool UseArch = false;
        //public int ArchSite = -1;
        public bool MakePOsOptional = false;
        public bool CarryStockLinks = false;
        //web logins
        public String UserName_APLS = "";
        public String Password_APLS = "";
        public String File_APLS = "";
        public String File_USBid = "";
        public String File_SourceESB = "";
        public String File_ICSource = "";
        public String File_FindChips = "";
        public String File_Haystack = "";
        public String File_PartsBase = "";
        public String File_PartsBase2 = "";
        public String CreditCard_1 = "";
        public String CreditCard_2 = "";
        public String CreditCard_3 = "";
        public String CreditCard_4 = "";
        public String EmailAddress_FindChips = "";
        public String EmailAddress_Haystack = "";
        public String UploadCode = "";
        public String HandlingQBName = "Bank Fee";

        //arch
        public int SiteIndex = 0;

        public override void Init(Context context)
        {
            ContextRz x = (ContextRz)context;

            VerifyOrderData = true;
            //DefaultEmailAddress = "mike@recognin.com";
            DefaultEmailAddress = "ktill@sensiblemicro.com";
            //DefaultUser = NewMethod.n_user.GetByName(TheContext.xSys, "Recognin Technologies");
            ServerFolderPath = "\\\\server\\path\\";

            //RzApp.CacheCompanies(TheContext);
            CacheSalesPeople(x);
            //Rz3App.CacheAssignedAgents();
            UseMergedQuotes = n_set.GetSetting_Boolean(x, "use_merged_quotes");
            InitCreditCards(x);
            PictureData = new DataConnectionSqlMy("10.2.0.7", "Rz3_Pictures", "redacted", "redacted");



            MarketingConnection = (DataConnectionSqlServer)x.TheData.TheConnection;
            InternalUPS = x.GetSetting("internal_ups");
            InternalFedex = x.GetSetting("internal_fedex");
            InternalDHL = x.GetSetting("internal_dhl");

        }


        public void InitCreditCards(ContextNM x)
        {
            CreditCard_1 = n_set.GetSetting(x, "creditcard_1");
            CreditCard_2 = n_set.GetSetting(x, "creditcard_2");
            CreditCard_3 = n_set.GetSetting(x, "creditcard_3");
            CreditCard_4 = n_set.GetSetting(x, "creditcard_4");
        }

        public virtual String GetDatabaseCaption(ContextRz context)
        {
            //if( IsDevelopmentDatabase() )
            //    return "Development Database";
            //else 
            if (IsTestDatabase(context))
                return "Test Database";
            else
                return "Production Database";
        }
        //public virtual int GetBackgroundColor(ContextRz context)
        //{
        //    if( IsDevelopmentDatabase(context) )
        //        return 13158655;
        //    else
        //        return 0;
        //}
        //public bool IsDevelopmentDatabase(ContextRz context)
        //{
        //    switch (context.TheData.TheKeySql.ServerName.ToLower())
        //    {
        //        case "laptop06":
        //            return true;
        //        case "vanurgh02":
        //            return true;
        //        case "vanburgh03":
        //            return true;
        //    }
        //    return false;
        //}
        public bool IsTestDatabase(ContextRz context)
        {
            return (Tools.Strings.StrCmp(context.TheData.TheKeySql.ServerName, RzLogic.TestServer) && Tools.Strings.StrCmp(context.TheData.TheKeySql.DatabaseName, RzLogic.TestDatabase));
        }
        public virtual String GetCompanySQL_Customer(ContextRz context)
        {
            return GetCompanySQL(context).Replace("<EXTRAWHERE>", "and ( isnull(iscustomer, 0) = 1 or ( isnull(isvendor, 0) = 0 and isnull(iscustomer, 0) = 0 ) )");
        }
        public virtual String GetCompanySQL_Vendor(ContextRz context)
        {
            return GetCompanySQL(context).Replace("<EXTRAWHERE>", "and ( isnull(isvendor, 0) = 1 or ( isnull(isvendor, 0) = 0 and isnull(iscustomer, 0) = 0 ) )");
        }
        public virtual String GetCompanySQL_Company(ContextRz context)
        {
            String s = GetCompanySQL(context);
            String i = CheckAppendInvisibleCompanies(context, "", "");
            if (Tools.Strings.StrExt(i))
                return s.Replace("<EXTRAWHERE>", " and " + i);
            else
                return s.Replace("<EXTRAWHERE>", "");
        }
        public virtual String GetCompanySQL(ContextRz context)
        {
            if (Tools.Strings.HasString(System.Environment.MachineName.ToLower(), "vanburgh") && Tools.Strings.HasString(context.TheData.TheKeySql.ServerName, "ctg"))
            {
                if (CacheActiveCompaniesOnly)
                    return "select top 1 '' as caption, '' as unique_id from company union all SELECT top 10 isnull(COMPANYNAME, '') AS caption, unique_id FROM company WHERE isactive = 1 and COMPANYNAME NOT LIKE '-%' AND isnull(COMPANYNAME, '') > '' and SUBSTRING(COMPANYNAME, 1, 1) <> '_' AND LEN(COMPANYNAME) > 0 <EXTRAWHERE> ORDER BY caption ";
                else
                    return "select top 1 '' as caption, '' as unique_id from company union all SELECT top 10 isnull(COMPANYNAME, '') AS caption, unique_id FROM company WHERE COMPANYNAME NOT LIKE '-%' AND isnull(COMPANYNAME, '') > '' and SUBSTRING(COMPANYNAME, 1, 1) <> '_' AND LEN(COMPANYNAME) > 0 <EXTRAWHERE> ORDER BY caption ";
            }
            else
            {
                if (CacheActiveCompaniesOnly)
                    return "select top 1 '' as caption, '' as unique_id from company union all SELECT isnull(COMPANYNAME, '') AS caption, unique_id FROM company WHERE isactive = 1 and COMPANYNAME NOT LIKE '-%' AND isnull(COMPANYNAME, '') > '' and SUBSTRING(COMPANYNAME, 1, 1) <> '_' AND LEN(COMPANYNAME) > 0 <EXTRAWHERE> ORDER BY caption ";
                else
                    return "select top 1 '' as caption, '' as unique_id from company union all SELECT isnull(COMPANYNAME, '') AS caption, unique_id FROM company WHERE COMPANYNAME NOT LIKE '-%' AND isnull(COMPANYNAME, '') > '' and SUBSTRING(COMPANYNAME, 1, 1) <> '_' AND LEN(COMPANYNAME) > 0 <EXTRAWHERE> ORDER BY caption ";
            }
        }
        public virtual bool CacheSalesPeopleList(ContextRz x)
        {
            //SalesPeople = x.SelectScalarArray("select name from n_user where isnull(is_inactive, 0) = 0 and isnull(name, '') > '' and isnull(main_n_team_uid, '') > '' order by name");
            SalesPeople = x.SelectScalarArray("select name from n_user where isnull(name, '') > '' and isnull(main_n_team_uid, '') > ''  order by name");
            //if (SalesPeople.Count <= 0)
            //    SalesPeople = x.SelectScalarArray("select name from n_user where isnull(is_inactive, 0) = 0 and isnull(name, '') > '' and isnull(is_inactive, 0) = 0 order by name");
            AssignedPeople = SalesPeople;
            return true;
        }
        public virtual void CacheCompanyList(ContextRz x)
        {
            CacheCompanyList(x, "company", GetCompanySQL_Company(x));
        }
        public virtual void SaveToAvail(ContextNM context, nObject xObject)
        {
        }
        public virtual ArrayList GetSalesManagers(ContextRz context)
        {
            return context.QtC("n_user", "select * from n_user where unique_id in (select distinct(the_n_user_uid) from n_member where is_captain = 1 and (select max(name) from n_team where n_team.unique_id = n_member.the_n_team_uid) like 'Team_%') order by name");
        }
        public virtual ArrayList GetSalesTeams(ContextRz context)
        {
            return context.QtC("n_team", "select * from n_team where left(name, 5) = 'team_' order by name");
        }
        public virtual ImportInventory GetImportInventoryLogic()
        {
            return new ImportInventory();
        }

        public virtual string GetOrderSearchTotalsHTML(ContextRz context, OrderSearchViewBy v)
        {
            switch (v.CurrentOrderType.ToString().ToLower().Trim())
            {
                case "sales":
                    return GetSalesOrderTotalsHTML(context, v.TheArgs.SQL);
                case "quote":
                    return GetQuoteTotalsHTML(context, v.TheArgs.SQL);
                case "invoice":
                    return GetInvoiceTotalsHTML(context, v.TheArgs.SQL);
                case "purchase":
                    return GetPurchaseTotalsHTML(context, v.TheArgs.SQL);
                case "rma":
                    return GetRMATotalsHTML(context, v.TheArgs.SQL);
                case "vendrma":
                    return GetVRMATotalsHTML(context, v.TheArgs.SQL);
                case "service":
                    return GetServiceTotalsHTML(context, v.TheArgs.SQL);
                default:
                    return "";
                    //return GetTotalsHTML(context, v.TheArgs.SQL, v.CurrentOrderType.ToString());
            }
        }
        public virtual String GetSalesOrderTotalsHTML(ContextRz context, nSQL s)
        {
            //return "";
            //KT Refactored from RzSensible
            Double st = 0;
            Double pt = 0;
            Double stf = 0;
            Double ptf = 0;
            Double stu = 0;
            Double ptu = 0;
            SalesTotalCalc(context, s, "", ref st, ref pt);
            SalesTotalCalc(context, s, "isnull(was_shipped, 0) = 1", ref stf, ref ptf);
            SalesTotalCalc(context, s, "isnull(was_shipped, 0) = 0", ref stu, ref ptu);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Total Sales:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Total Profit:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Invoiced:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Profit:</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Open Balance:</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Open Profit:</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">$ " + Tools.Number.MoneyFormat(st) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">$ " + Tools.Number.MoneyFormat(pt) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">$ " + Tools.Number.MoneyFormat(stf) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">$ " + Tools.Number.MoneyFormat(ptf) + "</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">$ " + Tools.Number.MoneyFormat(stu) + "</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">$ " + Tools.Number.MoneyFormat(ptu) + "</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        public virtual String GetQuoteTotalsHTML(ContextRz context, nSQL s)
        {
            //return "";
            //KT Refactored from RzSensible
            string sql = "select sum(orddet_quote.quantityordered * orddet_quote.unitprice) as quote_total from ordhed_quote inner join orddet_quote on ordhed_quote.unique_id = orddet_quote.base_ordhed_uid where ";
            sql += s.RenderSQL();
            double quote_total = 0;
            DataTable dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    quote_total += nData.NullFilter_Double(dr["quote_total"]);
                }
            }
            sql = "select sum(orddet_quote.quantityordered * orddet_quote.unitcost) as quote_total_cost from ordhed_quote inner join orddet_quote on ordhed_quote.unique_id = orddet_quote.base_ordhed_uid where ";
            sql += s.RenderSQL();
            double quote_total_cost = 0;
            dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    quote_total_cost += nData.NullFilter_Double(dr["quote_total_cost"]);
                }
            }
            double quote_profit = quote_total - quote_total_cost;
            sql = "select sum(orddet_quote.quantityordered * orddet_quote.unitprice) as quote_total from ordhed_quote inner join orddet_quote on ordhed_quote.unique_id = orddet_quote.base_ordhed_uid where ";
            sql += s.RenderSQL();
            sql += " and orddet_quote.unique_id in (select quote_line_uid from orddet_line) and (isnull(orddet_quote.isvoid,0) = 0 or isnull(ordhed_quote.isvoid,0) = 0) ";
            double sales_total = 0;
            dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sales_total += nData.NullFilter_Double(dr["quote_total"]);
                }
            }
            sql = "select sum(orddet_quote.quantityordered * orddet_quote.unitcost) as quote_total_cost from ordhed_quote inner join orddet_quote on ordhed_quote.unique_id = orddet_quote.base_ordhed_uid where ";
            sql += s.RenderSQL();
            sql += " and orddet_quote.unique_id in (select quote_line_uid from orddet_line) and (isnull(orddet_quote.isvoid,0) = 0 or isnull(ordhed_quote.isvoid,0) = 0) ";
            double sales_total_cost = 0;
            dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sales_total_cost += nData.NullFilter_Double(dr["quote_total_cost"]);
                }
            }
            double sales_profit = sales_total - sales_total_cost;
            sql = "select sum(orddet_quote.quantityordered * orddet_quote.unitprice) as quote_total from ordhed_quote inner join orddet_quote on ordhed_quote.unique_id = orddet_quote.base_ordhed_uid where ";
            sql += s.RenderSQL().Replace("and isnull(ordhed_quote.isvoid, 0) = '0'", "").Trim();
            sql += " and (isnull(orddet_quote.isvoid,0) = 1 or isnull(ordhed_quote.isvoid,0) = 1) ";
            double sales_total_loss = 0;
            dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sales_total_loss += nData.NullFilter_Double(dr["quote_total"]);
                }
            }
            sql = "select sum(orddet_quote.quantityordered * orddet_quote.unitcost) as quote_total_cost from ordhed_quote inner join orddet_quote on ordhed_quote.unique_id = orddet_quote.base_ordhed_uid where ";
            sql += s.RenderSQL().Replace("and isnull(ordhed_quote.isvoid, 0) = '0'", "").Trim();
            sql += " and (isnull(orddet_quote.isvoid,0) = 1 or isnull(ordhed_quote.isvoid,0) = 1) ";
            double sales_total_loss_cost = 0;
            dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sales_total_loss_cost += nData.NullFilter_Double(dr["quote_total_cost"]);
                }
            }
            double sales_profit_loss = sales_total_loss - sales_total_loss_cost;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Total Quotes:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Total Profit:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Sale Wins:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Profit:</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Sales Loss:</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Profit Loss:</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(quote_total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(quote_profit) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(sales_total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(sales_profit) + "</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(sales_total_loss) + "</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(sales_profit_loss) + "</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            return sb.ToString();


        }
        public virtual string GetInvoiceTotalsHTML(ContextRz context, nSQL s)
        {
            string sql = "";
            //return "";
            //KT Refactored from RzSensible
            //Total Invoices
            //string sql = "select ordhed_invoice.ordertotal as invoice_total,ordhed_invoice.ordernumber from ordhed_invoice inner join orddet_line on ordhed_invoice.unique_id = orddet_line.orderid_invoice or ordhed_invoice.unique_id = orddet_line.legacyid_invoice where ";
            //sql += s.RenderSQL();
            //sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_invoice.ordernumber,ordhed_invoice.ordertotal ";
            double total = 0;
            DataTable dt = context.TheSysRz.TheCompanyLogic.GetInvoiceTotalsDataTable(context, s, "ordertotal");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    total += nData.NullFilter_Double(dr["invoice_total"]);
                }
            }


            //Open Balance

            //sql = "select ordhed_invoice.outstandingamount as invoice_total,ordhed_invoice.ordernumber from ordhed_invoice inner join orddet_line on ordhed_invoice.unique_id = orddet_line.orderid_invoice or ordhed_invoice.unique_id = orddet_line.legacyid_invoice where ";
            //sql += s.RenderSQL();
            //sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_invoice.ordernumber,ordhed_invoice.outstandingamount ";
            double open_total = 0;
            //dt = context.Select(sql);
            dt = context.TheSysRz.TheCompanyLogic.GetInvoiceTotalsDataTable(context, s, "outstandingamount");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    open_total += nData.NullFilter_Double(dr["invoice_total"]);
                }
            }

            //Closed Gross Profit
            //sql = "select ordhed_invoice.gross_profit as invoice_total,ordhed_invoice.ordernumber from ordhed_invoice inner join orddet_line on ordhed_invoice.unique_id = orddet_line.orderid_invoice or ordhed_invoice.unique_id = orddet_line.legacyid_invoice where ";
            //sql += s.RenderSQL();
            //sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_invoice.ordernumber,ordhed_invoice.gross_profit ";
            double closed_gp = 0;
            //dt = context.Select(sql);
            dt = context.TheSysRz.TheCompanyLogic.GetInvoiceTotalsDataTable(context, s, "gross_profit");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    closed_gp += nData.NullFilter_Double(dr["invoice_total"]);
                }
            }

            //Closed Net Profit
            //sql = "select ordhed_invoice.net_profit as closed_np_total,ordhed_invoice.ordernumber from ordhed_invoice inner join orddet_line on ordhed_invoice.unique_id = orddet_line.orderid_invoice or ordhed_invoice.unique_id = orddet_line.legacyid_invoice where ";
            //sql += s.RenderSQL();
            //sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_invoice.ordernumber,ordhed_invoice.net_profit ";
            double closed_np = 0;
            //dt = context.Select(sql);
            dt = context.TheSysRz.TheCompanyLogic.GetInvoiceTotalsDataTable(context, s, "net_profit");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    closed_np += nData.NullFilter_Double(dr["invoice_total"]);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Total Invoices:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Gross Profit:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Net Profit:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Open Balance:</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(closed_gp) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(closed_np) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(open_total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        public virtual string GetPurchaseTotalsHTML(ContextRz context, nSQL s)
        {
            //return "";
            //KT Refactored from RzSensible
            string sql = "select ordhed_purchase.ordertotal as purchase_total,ordhed_purchase.ordernumber from ordhed_purchase inner join orddet_line on ordhed_purchase.unique_id = orddet_line.orderid_purchase or ordhed_purchase.unique_id = orddet_line.legacyid_purchase where ";
            sql += s.RenderSQL();
            sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_purchase.ordernumber,ordhed_purchase.ordertotal ";
            double total = 0;
            DataTable dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    total += nData.NullFilter_Double(dr["purchase_total"]);
                }
            }
            sql = "select ordhed_purchase.outstandingamount as purchase_total,ordhed_purchase.ordernumber from ordhed_purchase inner join orddet_line on ordhed_purchase.unique_id = orddet_line.orderid_purchase or ordhed_purchase.unique_id = orddet_line.legacyid_purchase where ";
            sql += s.RenderSQL();
            sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_purchase.ordernumber,ordhed_purchase.outstandingamount ";
            double open_total = 0;
            dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    open_total += nData.NullFilter_Double(dr["purchase_total"]);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Total PO's:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Open Balance</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(open_total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        public virtual string GetRMATotalsHTML(ContextRz context, nSQL s)
        {
            //return "";
            //KT Refactored from RzSensible
            string sql = "select ordhed_rma.ordertotal as rma_total,ordhed_rma.ordernumber from ordhed_rma inner join orddet_line on ordhed_rma.unique_id = orddet_line.orderid_rma or ordhed_rma.unique_id = orddet_line.legacyid_rma where ";
            sql += s.RenderSQL();
            sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_rma.ordernumber,ordhed_rma.ordertotal ";
            double total = 0;
            DataTable dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    total += nData.NullFilter_Double(dr["rma_total"]);
                }
            }
            sql = "select ordhed_rma.outstandingamount as rma_total,ordhed_rma.ordernumber from ordhed_rma inner join orddet_line on ordhed_rma.unique_id = orddet_line.orderid_rma or ordhed_rma.unique_id = orddet_line.legacyid_rma where ";
            sql += s.RenderSQL();
            sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_rma.ordernumber,ordhed_rma.outstandingamount ";
            double open_total = 0;
            dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    open_total += nData.NullFilter_Double(dr["rma_total"]);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Total RMA's:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Credit Balance</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(open_total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        public virtual string GetVRMATotalsHTML(ContextRz context, nSQL s)
        {
            //return "";
            //KT Refactored from RzSensible
            string sql = "select ordhed_vendrma.ordertotal as vendrma_total,ordhed_vendrma.ordernumber from ordhed_vendrma inner join orddet_line on ordhed_vendrma.unique_id = orddet_line.orderid_vendrma or ordhed_vendrma.unique_id = orddet_line.legacyid_vendrma where ";
            sql += s.RenderSQL();
            sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_vendrma.ordernumber,ordhed_vendrma.ordertotal ";
            double total = 0;
            DataTable dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    total += nData.NullFilter_Double(dr["vendrma_total"]);
                }
            }
            sql = "select ordhed_vendrma.outstandingamount as vendrma_total,ordhed_vendrma.ordernumber from ordhed_vendrma inner join orddet_line on ordhed_vendrma.unique_id = orddet_line.orderid_vendrma or ordhed_vendrma.unique_id = orddet_line.legacyid_vendrma where ";
            sql += s.RenderSQL();
            sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_vendrma.ordernumber,ordhed_vendrma.outstandingamount ";
            double open_total = 0;
            dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    open_total += nData.NullFilter_Double(dr["vendrma_total"]);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Total VRMA's:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Credit Balance</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(open_total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        public virtual string GetServiceTotalsHTML(ContextRz context, nSQL s)
        {
            //return "";
            //KT Refactored from RzSensible
            string sql = "select ordhed_service.ordertotal as service_total,ordhed_service.ordernumber from ordhed_service inner join orddet_line on ordhed_service.unique_id = orddet_line.orderid_service or ordhed_service.unique_id = orddet_line.legacyid_service where ";
            sql += s.RenderSQL();
            sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_service.ordernumber,ordhed_service.ordertotal ";
            double total = 0;
            DataTable dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    total += nData.NullFilter_Double(dr["service_total"]);
                }
            }
            sql = "select ordhed_service.outstandingamount as service_total,ordhed_service.ordernumber from ordhed_service inner join orddet_line on ordhed_service.unique_id = orddet_line.orderid_service or ordhed_service.unique_id = orddet_line.legacyid_service where ";
            sql += s.RenderSQL();
            sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_service.ordernumber,ordhed_service.outstandingamount ";
            double open_total = 0;
            dt = context.Select(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    open_total += nData.NullFilter_Double(dr["service_total"]);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Total Service:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Open Balance</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(open_total) + "</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        public virtual string GetTotalsHTML(ContextRz context, nSQL s, string type)
        {
            if (Tools.Strings.StrCmp(type, "any"))
                return "";
            type = type.ToLower();
            string extra = "";
            if (Tools.Strings.StrCmp(type, "rma"))
                extra = "_rma";
            else if (Tools.Strings.StrCmp(type, "vendrma"))
                extra = "_vendrma";
            string sql = "select sum(orddet_line.total_price" + extra + ")+(ordhed_" + type + ".shippingamount+ordhed_" + type + ".handlingamount+ordhed_" + type + ".taxamount) as " + type + "_total from ordhed_" + type + " inner join orddet_line on ordhed_" + type + ".unique_id = orddet_line.orderid_" + type + " or ordhed_" + type + ".unique_id = orddet_line.legacyid_" + type + " where ";
            sql += s.RenderSQL();
            sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_" + type + ".shippingamount,ordhed_" + type + ".handlingamount,ordhed_" + type + ".taxamount ";
            DataTable dt = context.Select(sql);
            if (dt == null)
                return "";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">Total:</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#000099\" align=\"center\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
            sb.AppendLine("  </tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">" + context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(nData.NullFilter_Double(dr[type + "_total"])) + "</font></b></td>");
                sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
                sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
                sb.AppendLine("    <td width=\"17%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
                sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
                sb.AppendLine("    <td width=\"16%\" align=\"center\" bgcolor=\"#000099\"><b><font size=\"4\" color=\"#FFFFFF\">&nbsp;</font></b></td>");
                sb.AppendLine("  </tr>");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }

        public virtual void ShowDiscrepancyForm(ordhed_purchase o)
        {

        }
        public virtual string TargetPriceCaption
        {
            get
            {
                return "Target Price";
            }
        }
        public virtual void ShowUpBoard(bool modal, System.Windows.Forms.IWin32Window owner)
        {
        }
        public Double ComputePrice(Double dblCost, long lngQuantity, Double dblPercentage, Double dblMinProfit)
        {
            Double dblReturn = 0;
            Double dblProfit = 0;
            return ComputePrice(dblCost, lngQuantity, dblPercentage, dblPercentage, ref dblReturn, ref dblProfit);
        }
        public Double ComputePrice(Double dblCost, long lngQuantity, Double dblPercentage, Double dblMinProfit, ref Double dblReturnProfit, ref Double dblReturnProfitWithMinimum)
        {
            Double dblCostTotal;
            Double dblQuotePrice;
            Double dblQuoteTotal;
            Double dblPercentageHold;
            Double dblMinProfitHold;
            if (lngQuantity <= 0)
                return 0;
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            //Override with the system settings
            dblPercentage = MarkUpPercentage;
            dblMinProfit = MarkUpMinimum;
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            dblCostTotal = dblCost * lngQuantity;
            dblPercentage = Math.Round(dblPercentage / 100, 2);
            dblPercentageHold = (dblPercentage * dblCostTotal) + dblCostTotal;
            dblMinProfitHold = dblMinProfit + dblCostTotal;
            if (dblMinProfitHold > dblPercentageHold)
                dblQuoteTotal = dblMinProfitHold;
            else
                dblQuoteTotal = dblPercentageHold;
            dblQuotePrice = dblQuoteTotal / lngQuantity;
            dblReturnProfit = dblPercentageHold;
            dblReturnProfitWithMinimum = dblQuoteTotal;
            return dblQuotePrice;
        }
        public virtual ArrayList GetHomeScreenOptions(NewMethod.n_user u)
        {
            ArrayList a = new ArrayList();
            //if (Rz3App.xLogic.IsAAT)
            //    a.Add(new HomeScreenOption("fax_notes", "Fax Send Log", "usernote_fax", "isnull(usernote_fax.isclosed, 0) = 0 and ( usernote_fax.for_mc_user_uid in(<userids>) or usernote_fax.by_mc_user_uid in(<userids>) )", "isnull(usernote_fax.isclosed, 0) = 0", "usernote_fax.displaydate desc", "DEFAULT_USER_NOTES_FAX"));

            //a.Add(new HomeScreenOptionNotes(false));
            //a.Add(new HomeScreenOptionNotes(true));

            a.Add(new HomeScreenOptionNotes("notes", "User Notes", "usernote", " ( usernote.for_mc_user_uid in(<userids>) or usernote.by_mc_user_uid in(<userids>) )", "isnull(usernote.isclosed, 0) = 0", "usernote.displaydate desc", "DEFAULT_USER_NOTES"));
            //a.Add(new HomeScreenOptionNotes("notes_closed", "User Notes (closed)", "usernote", "isnull(usernote.isclosed, 0) = 1 and ( usernote.for_mc_user_uid in(<userids>) or usernote.by_mc_user_uid in(<userids>) )", "isnull(usernote.isclosed, 0) = 0", "usernote.displaydate desc", "DEFAULT_USER_NOTES"));

            a.Add(new HomeScreenOption("contactnotes", "Company Notes", "contactnote", "contactnote.base_mc_user_uid in(<userids>)", "isnull(usernote.isclosed, 0) = 0", "contactnote.notedate desc", "DEFAULT_CONTACT_NOTES"));

            a.Add(new HomeScreenOption("calls", "Calls", "calllog", "calllog.base_mc_user_uid in(<userids>) ", "", "calllog.datecall desc", "USERCALLS"));



            //a.Add(new HomeScreenOptionBatches("ordertrees", "Order Batches", "dealheader", "isnull(manually_created, 0) = 1 and dealheader.base_mc_user_uid in(<userids>) ", "isnull(manually_created, 0) = 1", "dealheader.start_date desc", "USERDEALS"));
            a.Add(new HomeScreenOptionBatches("ordertrees", "Order Batches", "dealheader", "dealheader.base_mc_user_uid in(<userids>) ", "isnull(manually_created, 0) = 1", "dealheader.start_date desc", "USERDEALS"));


            if (UseMergedQuotes)
            {
                a.Add(new HomeScreenOption("mergedquotes", "Quotes", "orddet_quote", "orddet_quote.base_mc_user_uid in(<userids>) ", "", "orddet_quote.orderdate desc", "USERMERGEDQUOTES"));
                a.Add(new HomeScreenOption("mergedbids", "Bids", "orddet_rfq", "orddet_rfq.base_mc_user_uid in(<userids>) ", "", "orddet_rfq.orderdate desc", "USERMERGEDBIDS"));
            }
            else
            {
                //if(RzLicense.LicenseType == LicenseTypes.Custom || Rz3App.xUser.IsDeveloper())
                //{
                //a.Add(new HomeScreenOption("requirements", "Requirements", "req", "req.base_mc_user_uid in(<userids>) ", "", "req.datecreated desc", "USERREQS"));
                //a.Add(new HomeScreenOption("reqbatches", "Req Batches", "reqbatch", "reqbatch.base_mc_user_uid in(<userids>) ", "", "reqbatch.datecreated desc", "USERREQBATCHES"));
                //a.Add(new HomeScreenOption("bids", "Bids", "quote", "quote.base_mc_user_uid in(<userids>) and quote.quotetype = 'receiving' ", "quote.quotetype = 'receiving'", "quote.quotedate desc", "USERQUOTESGET"));
                //a.Add(new HomeScreenOption("quickquotes", "Quick Quotes", "quote", "quote.base_mc_user_uid in(<userids>) and quote.quotetype = 'giving out' ", "quote.quotetype = 'giving out'", "quote.quotedate desc", "USERQUOTESGIVE"));
                a.Add(new HomeScreenOption("rfqs", "RFQs", ordhed.MakeOrdhedName(Enums.OrderType.RFQ), ordhed.MakeOrdhedName(Enums.OrderType.RFQ) + ".base_mc_user_uid in(<userids>) and " + ordhed.MakeOrdhedName(Enums.OrderType.RFQ) + ".ordertype = 'rfq' ", ordhed.MakeOrdhedName(Enums.OrderType.RFQ) + ".ordertype = 'rfq'", ordhed.MakeOrdhedName(Enums.OrderType.RFQ) + ".orderdate desc", "USERRFQS"));
                //a.Add(new HomeScreenOption("mergedbids", "RFQ/Bid Lines", "orddet_rfq", "orddet_rfq.base_mc_user_uid in(<userids>) ", "", "orddet_rfq.orderdate desc", "USERMERGEDBIDS"));
                a.Add(new HomeScreenOption("formalquotes", "Quotes", ordhed.MakeOrdhedName(Enums.OrderType.Quote), ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".base_mc_user_uid in(<userids>) and " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".ordertype = 'quote' ", ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".ordertype = 'quote'", ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".orderdate desc", "USERFORMALQUOTES"));
                //}
            }
            a.Add(new HomeScreenOption("salesorders", "Sales Orders", ordhed.MakeOrdhedName(Enums.OrderType.Sales), ordhed.MakeOrdhedName(Enums.OrderType.Sales) + ".base_mc_user_uid in(<userids>) and " + ordhed.MakeOrdhedName(Enums.OrderType.Sales) + ".ordertype = 'sales' ", ordhed.MakeOrdhedName(Enums.OrderType.Sales) + ".ordertype = 'sales'", ordhed.MakeOrdhedName(Enums.OrderType.Sales) + ".orderdate desc", "USERSALESORDERS"));
            a.Add(new HomeScreenOption("purchaseorders", "Purchase Orders", ordhed.MakeOrdhedName(Enums.OrderType.Purchase), ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".base_mc_user_uid in(<userids>) and " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".ordertype = 'purchase' ", ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".ordertype = 'purchase'", ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".orderdate desc", "USERPOS"));
            if (u.SuperUser)
                a.Add(new HomeScreenOption("invoices", "Invoices", ordhed.MakeOrdhedName(Enums.OrderType.Invoice), ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".base_mc_user_uid in(<userids>) and " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".ordertype = 'invoice' ", ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".ordertype = 'invoice'", ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".orderdate desc", "USERINVOICES"));
            //if(RzLicense.LicenseType == LicenseTypes.Custom || Rz3App.xUser.IsDeveloper())
            //{
            Boolean bView = true;
            //if(Rz3App.xLogic.IsNasco)
            //{
            //    bView = Rz3App.xUser.IsTeamMember("PHONE MANAGEMENT");
            //    if( !bView )
            //        bView = Rz3App.xUser.super_user;
            //}
            if (bView)
                a.Add(new HomeScreenOption("phonecalls", "Phone Calls", "phonecall", "phonecall.base_mc_user_uid in(<userids>) ", "", "phonecall.calldate desc", "USERPHONE"));
            //}
            a.Add(new HomeScreenOption("checkpayments", "Checks/Payments", "checkpayment", "", "", "checkpayment.transdate desc", "HOME_CHECKPAYMENT"));
            return a;
        }
        public void LogEvent(String strName, String strDescription)
        {
            LogEvent(strName, strDescription, "", "", "", "", "", "", false, false);
        }
        public void LogEvent(String strName, String strDescription, String strPart, String strCompanyID, String strCompanyName, String strContactID, String strContactName, String strNotes, bool boolAccept, bool boolReject)
        {
            MessageBox.Show("reorg");
            //userevent xEvent = new userevent(Rz3App.xSys);
            //xEvent.base_mc_user_uid = Rz3App.xUser.unique_id;
            //xEvent.eventname = strName;
            //xEvent.eventdescription = strDescription;
            //xEvent.fullpartnumber = strPart;
            //xEvent.base_company_uid = strCompanyID;
            //xEvent.companyname = strCompanyName;
            //xEvent.is_accepted = boolAccept;
            //xEvent.is_rejected = boolReject;
            //xEvent.event_notes = strNotes;
            //xEvent.ISave_Async();
        }
        public bool ShouldNotSell(ContextRz context, String companyname, String contactname, String address1, String address2, String city, String state, String zip, String country, String phone, String fax, String email)
        {
            if (!context.TheData.TheConnection.TableExists("donotsell"))
                return false;
            String strSQL = "";
            if (Tools.Strings.StrExt(companyname))
            {
                if (Tools.Strings.StrExt(strSQL))
                    strSQL += " or ";
                strSQL += " companyname = '" + context.Filter(companyname) + "' ";
            }
            if (Tools.Strings.StrExt(contactname))
            {
                if (Tools.Strings.StrExt(strSQL))
                    strSQL += " or ";
                strSQL += " contactname = '" + context.Filter(companyname) + "' ";
            }
            if (Tools.Strings.StrExt(address1) && Tools.Strings.StrExt(city) && Tools.Strings.StrExt(country))
            {
                if (Tools.Strings.StrExt(strSQL))
                    strSQL += " or ";
                strSQL += " ( address1 = '" + context.Filter(address1) + "' and city = '" + context.Filter(city) + "' and country = '" + context.Filter(country) + "' ) ";
            }
            if (phone.Length > 6)
            {
                if (Tools.Strings.StrExt(strSQL))
                    strSQL += " or ";
                strSQL += " phone = '" + context.Filter(phone) + "' ";
            }
            if (fax.Length > 6)
            {
                if (Tools.Strings.StrExt(strSQL))
                    strSQL += " or ";
                strSQL += " fax = '" + context.Filter(fax) + "' ";
            }
            if (email.Length > 4)
            {
                if (Tools.Strings.StrExt(strSQL))
                    strSQL += " or ";
                strSQL += " email = '" + context.Filter(email) + "' ";
            }
            if (!Tools.Strings.StrExt(strSQL))
                return false;
            strSQL = "select * from donotsell where " + strSQL;
            return context.TheData.TheConnection.StatementExists(strSQL);
        }
        public virtual usernote NotifyAccounting(ContextRz context, nObject xObject, String strCaption, String strNote)
        {
            return null;
        }
        public virtual usernote NotifyWarehouse(ContextRz context, nObject xObject, String strCaption, String strNote)
        {
            return null;
        }
        public virtual usernote NotifyManagement(ContextRz context, nObject xObject, String strCaption, String strNote)
        {
            return null;
        }
        public virtual void EditInvoiceDetFees(orddet_line d)
        {

        }
        public virtual String GetPictureFileName(String strFile)
        {
            return GetPictureFileName(strFile, false);
        }
        public virtual bool ExportReportsAllowed(ContextNM x)
        {
            //return true;
            //KT Refactored from RzSensible
            return x.xUser.SuperUser;
        }
        public virtual String GetPictureFileName(String strFile, bool black_and_white)
        {
            String strBase = "";
            if (black_and_white)
            {
                strBase = System.IO.Path.GetFileNameWithoutExtension(strFile) + "_bw" + Path.GetExtension(strFile);
                String ret = GetPictureFileName(strBase, false);
                if (File.Exists(ret))
                    return ret;
            }

            if ((Tools.Strings.HasString(strFile, ":\\") || Tools.Strings.HasString(strFile, "\\\\")) && System.IO.File.Exists(strFile))
                return strFile;
            strBase = System.IO.Path.GetFileName(strFile);

            String strName = "c:\\" + strBase;
            if (System.IO.File.Exists(strName))
                return strName;
            strName = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()) + "graphics\\" + strBase;
            if (System.IO.File.Exists(strName))
                return strName;
            strName = Tools.Folder.ConditionFolderName(nTools.GetAppParentPath()) + strBase;
            if (System.IO.File.Exists(strName))
                return strName;
            strName = Tools.Folder.ConditionFolderName(nTools.GetAppParentPath()) + "graphics\\" + strBase;
            if (System.IO.File.Exists(strName))
                return strName;

            if (Tools.Misc.IsDevelopmentMachine())
            {
                strName = "c:\\eternal\\code\\newmethod\\projects\\rz3_common\\graphics\\" + strBase;
                if (System.IO.File.Exists(strName))
                    return strName;
            }

            if (Tools.Strings.StrExt(CompanyIdentifier))
            {
                strName = Tools.Folder.ConditionFolderName(nTools.GetAppParentPath()) + "graphics\\" + strBase;
                if (!File.Exists(strName + ".tried"))
                {
                    Tools.Files.SaveFileAsString(strName + ".tried", "Tried on " + DateTime.Now.ToString());

                    String strRemote = "http://www.recognin.com/" + CompanyIdentifier + "/" + strBase;
                    if (Tools.Files.DownloadInternetFile(strRemote, strName))
                    {
                        if (File.Exists(strName))
                            return strName;
                    }
                }
            }

            //strName = Tools.Folder.ConditionFolderName(Rz3App.xLogic.ServerFolderPath) + strBase;
            //if (System.IO.File.Exists(strName))
            //    return strName;
            //return nTools.GetHighestFileName(Tools.Folder.ConditionFolderName(nTools.GetAppParentPath()) + "graphics\\", strBase);
            return "";
        }
        public String GetCompanySummaryByID(ContextRz context, String strID)
        {
            DataTable d = context.Select("select primarycontact, primaryphone, primaryfax, primaryemailaddress from company where unique_id = '" + strID + "'");
            if (!nTools.DataTableExists(d))
                return "";
            DataRow r = d.Rows[0];
            String ret = "";
            String s = nData.NullFilter_String(r["primarycontact"]);
            if (Tools.Strings.StrExt(s))
                ret += "Contact: " + s + "\r\n";
            s = nData.NullFilter_String(r["primaryphone"]);
            if (Tools.Strings.StrExt(s))
                ret += "Phone: " + s + "\r\n";
            s = nData.NullFilter_String(r["primaryfax"]);
            if (Tools.Strings.StrExt(s))
                ret += "Fax: " + s + "\r\n";
            s = nData.NullFilter_String(r["primaryemailaddress"]);
            if (Tools.Strings.StrExt(s))
                ret += "Email: " + s + "\r\n";
            if (ret.EndsWith("\r\n"))
                ret = Tools.Strings.Left(ret, ret.Length - 2);
            return ret;
        }
        public String GetContactSummaryByID(ContextRz context, String strID)
        {
            DataTable d = context.Select("select primaryphone, primaryfax, primaryemailaddress, calc_qquote_count, calc_fquote_count, calc_sale_count, calc_last_qquote, calc_last_fquote, calc_last_sale from companycontact where unique_id = '" + strID + "'");
            if (!nTools.DataTableExists(d))
                return "";
            DataRow r = d.Rows[0];
            String ret = "";
            String s = nData.NullFilter_String(r["primaryphone"]);
            if (Tools.Strings.StrExt(s))
                ret += "Phone: " + s + "\r\n";
            s = nData.NullFilter_String(r["primaryfax"]);
            if (Tools.Strings.StrExt(s))
                ret += "Fax: " + s + "\r\n";
            s = nData.NullFilter_String(r["primaryemailaddress"]);
            if (Tools.Strings.StrExt(s))
                ret += "Email: " + s + "\r\n";
            int calc_qquote_count = Tools.Data.NullFilterInt(r["calc_qquote_count"]);
            int calc_fquote_count = Tools.Data.NullFilterInt(r["calc_fquote_count"]);
            int calc_sale_count = Tools.Data.NullFilterInt(r["calc_sale_count"]);
            DateTime calc_last_qquote = nData.NullFilter_Date(r["calc_last_qquote"]);
            DateTime calc_last_fquote = nData.NullFilter_Date(r["calc_last_fquote"]);
            DateTime calc_last_sale = nData.NullFilter_Date(r["calc_last_sale"]);
            if (calc_qquote_count > 0)
            {
                ret += Tools.Number.LongFormat(calc_qquote_count) + " Quick Quotes, Last: " + nTools.DateFormat(calc_last_qquote) + "\r\n";
            }
            if (calc_fquote_count > 0)
            {
                ret += Tools.Number.LongFormat(calc_fquote_count) + " Formal Quotes, Last: " + nTools.DateFormat(calc_last_fquote) + "\r\n";
            }
            if (calc_sale_count > 0)
            {
                ret += Tools.Number.LongFormat(calc_sale_count) + " Sales, Last: " + nTools.DateFormat(calc_last_sale) + "\r\n";
            }
            if (ret.EndsWith("\r\n"))
                ret = Tools.Strings.Left(ret, ret.Length - 2);
            return ret;
        }
        public String GetMinimumReorderSQL()
        {
            return "select unique_id, fullpartnumber, manufacturer, datecode, quantity, reorder_quantity, description from partrecord where isnull(reorder_quantity, 0) > 0 and isnull(quantity, 0) < isnull(reorder_quantity, 0) order by fullpartnumber, manufacturer";
        }
        public String GetReorderReport(ContextRz context)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h1>Minimum Quantity Reorder Report</h1>As Of " + System.DateTime.Now.ToString() + "<br><hr><br>");
            DataTable d = context.Select(GetMinimumReorderSQL());
            if (d == null)
                return "";
            if (!Tools.Data.DataTableExists(d))
            {
                sb.AppendLine("No line items are below their minimum quantity.");
                return sb.ToString();
            }
            sb.AppendLine("<table cellpadding=1 cellspacing=1 border=1><tr>");
            sb.AppendLine("<td>Part Number</td><td align=right>Min QTY Stock</td><td align=right>On Hand</td><td>Manufacturer</td><td>Date Code</td><td>Description</td>");
            sb.Append("</tr>");
            foreach (DataRow r in d.Rows)
            {
                sb.AppendLine("<tr><td>" + nData.NullFilter_String(r["fullpartnumber"]) + "&nbsp;</td><td align=right>&nbsp;" + Tools.Number.LongFormat(nData.NullFilter_Long(r["reorder_quantity"])) + "</td><td align=right>&nbsp;" + Tools.Number.LongFormat(nData.NullFilter_Long(r["quantity"])) + "</td><td>" + nData.NullFilter_String(r["manufacturer"]) + "&nbsp;</td><td>" + nData.NullFilter_String(r["datecode"]) + "&nbsp;</td><td>" + nData.NullFilter_String(r["description"]) + "&nbsp;</td></tr>");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        public bool EmailReorderReport(ContextRz context)
        {
            String s = n_set.GetSetting(context, "minimum_quantity_reorder_report_address");
            if (!nTools.IsEmailAddress(s))
            {
                context.TheLeader.Comment("Requesting report email address...");
                ConfigureMinimumQuantityReorderReport(context);
                s = n_set.GetSetting(context, "minimum_quantity_reorder_report_address");
            }
            return context.Logic.EmailReorderReport(context, s);
        }
        public void ConfigureMinimumQuantityReorderReport(ContextRz context)
        {
            String s = context.TheLeader.AskForString("What email address should this report go to?", n_set.GetSetting(context, "minimum_quantity_reorder_report_address"), "Email Address");
            if (!nTools.IsEmailAddress(s))
                return;
            n_set.SetSetting(context, "minimum_quantity_reorder_report_address", s);
        }
        public bool EmailReorderReport(ContextRz context, String strAddress)
        {
            context.TheLeader.Comment("Emailing reorder report to " + strAddress + "...");
            nEmailMessage m = new nEmailMessage();
            m.HTMLBody = GetReorderReport(context);
            if (!Tools.Strings.StrExt(m.HTMLBody))
            {
                context.TheLeader.Comment("GetReorderReport returned no information.");
                return false;
            }
            m.Subject = "Minimum Quantity Reorder Report On " + System.DateTime.Now.ToString();
            m.ToAddress = strAddress;
            m.ToName = strAddress;
            m.FromName = "Notify";
            m.FromAddress = "notify@recognin.com";
            m.SetDefaultServer();
            String s = "";
            if (!m.Send(ref s))
            {
                context.TheLeader.Comment("Send error: " + s);
                return false;
            }
            else
            {
                context.TheLeader.Comment("Sent to " + strAddress + ".");
                return true;
            }
        }
        public void SetFromNotification(nEmailMessage m)
        {
            SetFromNotification(m, false);
        }
        public virtual void SetFromNotification(nEmailMessage m, bool use_company_name)
        {
            if (use_company_name)
                m.SetNotifyServer(GetCompanyName(), NotifyEmailAddress, NotifyEmailPassword);
            else
                m.SetNotifyServer("RzNote", NotifyEmailAddress, NotifyEmailPassword);
        }
        public String GetCompanyName()
        {
            //if( IsAAT )
            //    return "AAT Technology";
            //else 
            //if(IsNTC)
            //{
            //    if( IsGemTek )
            //        return "GemTek";
            //    else
            //        return "National Team Components";
            //}
            return "";
        }
        public virtual String QBInvoiceNumberField
        {
            get
            {
                return "ordernumber";
            }
        }
        public virtual String QBInvoiceDateField
        {
            get
            {
                return "orderdate";
            }
        }
        public String GetIncompleteOverSalesSQL()
        {
            String strSQL = "select * from orddet_line where ";
            strSQL += "    isnull(was_shipped, 0) = 0 and isnull(ordernumber_sales, '') > '' ";
            strSQL += "    and isnull(isvoid, 0) = 0 ";
            strSQL += "    and ship_date_due < '" + Tools.Dates.DateFormat(DateTime.Now.Subtract(TimeSpan.FromDays(1))) + " 11:59:59 PM' ";
            strSQL += "    and ship_date_due > cast('01/02/1900' as datetime)";
            strSQL += "    and ( isnull(overdue_notify_date, cast('01/01/1900' as datetime)) <= getdate() or datediff(d, getdate(), overdue_notify_date) = 0 )";
            strSQL += "    order by ship_date_due";
            return strSQL;
        }
        public virtual String GetDutyList()
        {
            return "BrokerForum Upload|Email Minimum Stock Level Report|Notify Overdue Incomplete Sales|Test Function|Contact Activity Totals|Auto Archive|Stock Export|Excess Export|Avail Export|Calculate Stats|Concerns|Rz2 Sync|Truncate Database Log|Stock Export and Upload|BrokerForum And Netcomponents Upload|Reindex Database|BackUp Database|Daily ProfitReport Log|RTE|RzRescue|RzLink|DropTempTables|CloseBooks";
        }
        public virtual void MarkConcern(ContextRz context, String strKey)
        {
            MarkConcern(context, strKey, Convert.ToInt64(1));
        }
        public void MarkConcern(ContextRz context, String strKey, int count)
        {
            MarkConcern(context, strKey, Convert.ToInt64(count));
        }
        public virtual void MarkConcern(ContextRz context, String strKey, long count)
        {
        }
        public String GetConcernReportHTML(ContextRz context, bool include_links)
        {
            bool b = false;
            return GetConcernReportHTML(context, 4, ref b, include_links);
        }
        public String GetConcernReportHTML(ContextRz context, int days, ref bool any_concerns, bool include_links)
        {
            any_concerns = true;    // always show the report
            DateTime d;
            ArrayList a = context.TheData.TheConnection.GetFieldArray("concerns");
            ArrayList cols = new ArrayList();
            foreach (String s in a)
            {
                if (nTools.StartsWith(s, "on_"))
                {
                    d = nTools.ParseDate_YYYY_MM_DD(Tools.Strings.Mid(s, 4));
                    if (Tools.Dates.DateExists(d))
                    {
                        if (d >= System.DateTime.Now.Subtract(TimeSpan.FromDays(30)))
                            cols.Add(d);
                    }
                }
            }
            cols.Sort();
            String fields = "";
            ArrayList hold = new ArrayList();
            //if (cols.Count > 0)
            //{
            for (int i = cols.Count - 1; i > (cols.Count - 1) - days; i--)
            {
                if (i >= 0)
                {
                    hold.Add(cols[i]);
                }
            }
            //}
            cols = new ArrayList();
            foreach (DateTime dx in hold)
            {
                cols.Add(dx);
            }
            ArrayList fieldnames = new ArrayList();
            for (int i = 0; i < cols.Count; i++)
            {
                d = (DateTime)cols[i];
                if (Tools.Strings.StrExt(fields))
                    fields += ", ";
                String f = "on_" + d.Year.ToString() + "_" + d.Month.ToString() + "_" + d.Day.ToString();
                fields += f;
                fieldnames.Add(f);
            }

            if (fields == "")
                return "None";

            String strSQL = "select name, last_date, threshold, description, " + fields + " from concerns where threshold > 0 order by name";
            DataTable dt = context.Select(strSQL);
            if (!Tools.Data.DataTableExists(dt))
                return "";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<title>Rz Concerns</title>");
            sb.AppendLine(Tools.Strings.DownloadInternetString("http://www.recognin.com/email_style.txt"));
            sb.AppendLine("</head>");
            sb.AppendLine("<body>	");
            sb.AppendLine("                               <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\">");
            sb.AppendLine("					<tr>");
            sb.AppendLine("						<td valign=\"middle\"><a href=\"http://www.recognin.com/\" target=\"_blank\"><img src=\"http://www.recognin.com/recogniz.jpg\" border=\"0\" alt=\"Rz Concerns\" width=\"32\" height=\"32\" /></a></td>");
            sb.AppendLine("						<td valign=\"middle\" align=\"right\">");
            sb.AppendLine("							<div style=\"font:normal 12px Verdana, sans-serif;margin-right:12px;\">Rz3");
            sb.AppendLine("                              Concern Report</div>");
            sb.AppendLine("						</td>");
            sb.AppendLine("					</tr>");
            sb.AppendLine("					<tr>");
            sb.AppendLine("						<td colspan=\"2\" align=\"left\" style=\"height:35px;width:541px;\">");
            sb.AppendLine("							<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:541px;\">");
            sb.AppendLine("							<tr>");
            sb.AppendLine("								<td bgcolor=\"#00B106\" style=\"background-color:#00B106;height:8px;font-size:1px;\">&nbsp;</td>");
            sb.AppendLine("							</tr>");
            sb.AppendLine("							<tr>");
            sb.AppendLine("								<td bgcolor=\"#F3F3F3\" style=\"background-color: left; height: 27px; border-left: 1px solid #cececd; border-right: 1px solid #cececd; border-top: 0px solid #cececd; border-bottom: 1px solid #cececd; background-position: top 50%\"><div style=\"text-align:right;padding-right:12px;font:normal 10px Verdana, sans-serif;color:#666;\">" + String.Format("{0:f}", DateTime.Now) + "</div></td>");
            sb.AppendLine("							</tr>");
            sb.AppendLine("							</table>");
            sb.AppendLine("						</td>");
            sb.AppendLine("					</tr>");
            sb.AppendLine("					<tr>");
            sb.AppendLine("					<div style=\"font:bold 25px Arial, sans-serif;border-bottom:1px solid #ccc;padding-bottom:5px;margin:26px 0px 5px 0px;\">Concerns Update</div>");
            sb.AppendLine("                    <img src=\"http://www.recognin.com/warning.gif\" /> <span  class=\"negative\" style=\"font-style: normal; font-variant: normal; font-weight: bold; font-size: 14px; font-family: Arial, sans-serif\">Overdue: <overdue_count></span><br>");
            sb.AppendLine("                    <img src=\"http://www.recognin.com/info.gif\" /> <span class=\"neutral\" style=\"font-style: normal; font-variant: normal; font-weight: bold; font-size: 14px; font-family: Arial, sans-serif\">Upcoming: <upcoming_count></span><br>		");
            sb.AppendLine("                    <img src=\"http://www.recognin.com/tick.gif\" /> <span class=\"positive\" style=\"font-style: normal; font-variant: normal; font-weight: bold; font-size: 14px; font-family: Arial, sans-serif\">OK: <ok_count></span>");
            sb.AppendLine("					</tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("<br>");
            sb.AppendLine("<table>");
            sb.AppendLine("	<thead class=\"sortable \">");
            sb.AppendLine("	<tr>");
            sb.AppendLine("			<th class=\"alignLeft alignBottom\" >Name</th>");
            sb.AppendLine("			<th class=\"alignRight alignBottom\" >Last</th>");
            int colcount = 3;    //includes the last status column
            for (int i = 0; i < cols.Count; i++)
            {
                DateTime dx = (DateTime)cols[i];
                sb.AppendLine("			<th class=\"alignRight alignBottom\" >" + nTools.GetDateCaption(dx) + "</th>");
                colcount++;
            }
            sb.AppendLine("	</tr>");
            sb.AppendLine("	</thead>");
            ArrayList aOK = new ArrayList();
            ArrayList aUpcoming = new ArrayList();
            ArrayList aOverdue = new ArrayList();
            foreach (DataRow r in dt.Rows)
            {
                ConcernHandle c = new ConcernHandle();
                c.Name = nData.NullFilter_String(r["name"]);
                c.Last = nData.NullFilter_DateTime(r["last_date"]);
                c.Threshold = nData.NullFilter_Long(r["threshold"]);
                c.Description = nData.NullFilter_String(r["description"]);
                c.Accept = System.DateTime.Now.Subtract(TimeSpan.FromMinutes(Convert.ToDouble(c.Threshold)));
                if (c.Last < c.Accept)
                {
                    aOverdue.Add(c);
                    c.TimeLeft = c.Accept.Subtract(c.Last);
                    if (c.TimeLeft.TotalDays >= 1)
                        c.Status = Tools.Number.LongFormat(c.TimeLeft.TotalDays) + " " + nTools.Pluralize("Day", c.TimeLeft.TotalDays) + " Overdue";
                    else if (c.TimeLeft.TotalHours >= 1)
                        c.Status = Tools.Number.LongFormat(c.TimeLeft.TotalHours) + " " + nTools.Pluralize("Hour", c.TimeLeft.TotalHours) + " Overdue";
                    else
                        c.Status = Tools.Number.LongFormat(c.TimeLeft.TotalMinutes) + " " + nTools.Pluralize("Min", c.TimeLeft.TotalMinutes) + " Overdue";
                }
                else
                {
                    c.Accept = c.Last.Add(TimeSpan.FromMinutes(Convert.ToDouble(c.Threshold)));
                    c.TimeLeft = c.Accept.Subtract(System.DateTime.Now);
                    if (c.TimeLeft.TotalMinutes > (c.Threshold * 0.75))
                    {
                        aOK.Add(c);
                        c.Status = "OK";
                    }
                    else
                    {
                        aUpcoming.Add(c);
                        if (c.TimeLeft.TotalDays >= 1)
                            c.Status = Tools.Number.LongFormat(c.TimeLeft.TotalDays) + " " + nTools.Pluralize("Day", c.TimeLeft.TotalDays) + " Left";
                        else if (c.TimeLeft.TotalHours >= 1)
                            c.Status = Tools.Number.LongFormat(c.TimeLeft.TotalHours) + " " + nTools.Pluralize("Hour", c.TimeLeft.TotalHours) + " Left";
                        else
                            c.Status = Tools.Number.LongFormat(c.TimeLeft.TotalMinutes) + " " + nTools.Pluralize("Min", c.TimeLeft.TotalMinutes) + " Left";
                    }
                }
                for (int id = 0; id < days; id++)
                {
                    try
                    {
                        c.Points.Add(nData.NullFilter_Long(r[id + 4]));
                    }
                    catch { }
                }
            }
            sb.AppendLine("   <tbody>");
            foreach (ConcernHandle ch in aOverdue)
            {
                sb.AppendLine(ch.GetHTML(colcount, "warning", "negative", include_links, System.Drawing.Color.Red));
            }
            foreach (ConcernHandle ch in aUpcoming)
            {
                sb.AppendLine(ch.GetHTML(colcount, "info", "neutral", include_links, System.Drawing.Color.Black));
            }
            foreach (ConcernHandle ch in aOK)
            {
                sb.AppendLine(ch.GetHTML(colcount, "tick", "positive", include_links, System.Drawing.Color.Green));
            }
            sb.AppendLine("   </tbody>");
            sb.AppendLine("</table>");
            return sb.ToString().Replace("<overdue_count>", Tools.Number.LongFormat(aOverdue.Count)).Replace("<upcoming_count>", Tools.Number.LongFormat(aUpcoming.Count)).Replace("<ok_count>", Tools.Number.LongFormat(aOK.Count));
        }
        public virtual void PopCompleteOEMEmailList(ContextRz context)
        {
            PopCompleteEmailList(context, true, false);
        }
        public virtual void PopCompleteNonVendorEmailList(ContextRz context)
        {
            PopCompleteEmailList(context, false, true);
        }
        public virtual void PopCompleteEmailList(ContextRz context)
        {
            PopCompleteEmailList(context, false, false);
        }
        public virtual void PopCompleteEmailList(ContextRz context, bool only_oem, bool non_vendor)
        {
            if (only_oem)
                PopCompleteEmailList(context, " and (isnull(company.abs_type, '') = 'OEM' or company.companytype like '%oem%') ");
            else if (non_vendor)
                PopCompleteEmailList(context, " and (isnull(company.agentname, '') <> 'vendor' and isnull(company.isvendor, 0) = 0 and isnull(company.companytype, '') <> 'vendor' ) ");
            else
                PopCompleteEmailList(context, "");
        }
        public virtual void PopCompleteEmailList(ContextRz context, String strCompanyWhere)
        {
            String email = "";
            SortedList s = new SortedList();
            context.TheLeader.StartPopStatus();
            context.TheLeader.Comment("Calculating company addresses...");
            String strSQL = "";
            //if( only_oem )
            strSQL = "select distinct(isnull(primaryemailaddress, '')) as primaryemailaddress from company where isnull(donotemail, 0) = 0 and len(isnull(primaryemailaddress, '')) > 0 " + strCompanyWhere + " order by primaryemailaddress";
            //else
            //    strSQL = "select distinct(isnull(primaryemailaddress, '')) from company where isnull(donotemail, 0) = 0 and len(primaryemailaddress) > 0";
            ArrayList a = context.TheData.SelectScalarArray(strSQL);
            foreach (String st in a)
            {
                email = st.Trim();
                if (nTools.IsEmailAddress(email))
                {
                    try
                    {
                        s.Add(email, email);
                        context.TheLeader.Comment("Added " + email);
                    }
                    catch
                    {
                    }
                }
            }
            context.TheLeader.Comment("Calculating contact addresses...");
            if (Tools.Strings.StrExt(strCompanyWhere))
                strSQL = "select distinct(isnull(companycontact.primaryemailaddress, '')) as primaryemailaddress from companycontact inner join company on company.unique_id = companycontact.base_company_uid where isnull(companycontact.donotemail, 0) = 0 and len(companycontact.primaryemailaddress) > 0 " + strCompanyWhere + " order by companycontact.primaryemailaddress";
            else
                strSQL = "select distinct(isnull(primaryemailaddress, '')) from companycontact where isnull(donotemail, 0) = 0 and len(primaryemailaddress) > 0";

            a = context.TheData.SelectScalarArray(strSQL);
            foreach (String st in a)
            {
                email = st.Trim();
                if (nTools.IsEmailAddress(email))
                {
                    try
                    {
                        s.Add(email, email);
                        context.TheLeader.Comment("Added " + email);
                    }
                    catch
                    {
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            if (s.Count == 0)
                sb.AppendLine("No records.");
            else
            {
                foreach (DictionaryEntry d in s)
                {
                    sb.AppendLine((String)d.Value);
                }
            }
            context.TheLeader.Comment("Done.");
            context.TheLeader.StopPopStatus(false);
            Tools.FileSystem.PopText(sb.ToString());
        }
        public virtual void PopInvalidEmailList(ContextRz context, bool only_oem)
        {
            context.Reorg();

            //why is this here?
            //try
            //{
            //    SortedList s = new SortedList();
            //    context.TheLeader.StartPopStatus();
            //    context.TheLeader.Comment("Calculating company addresses...");
            //    String strSQL = "";
            //    if( only_oem )
            //        strSQL = "select distinct(isnull(primaryemailaddress, '')) as emailadr, ('company~' + unique_id) as linkid from company where isnull(donotemail, 0) = 0 and len(primaryemailaddress) > 0 and abs_type = 'OEM' or companytype like '%oem%'";
            //    else
            //        strSQL = "select distinct(isnull(primaryemailaddress, '')) as emailadr, ('company~' + unique_id) as linkid from company where isnull(donotemail, 0) = 0 and len(primaryemailaddress) > 0";
            //    DataTable dt = context.Select(strSQL);
            //    if(dt != null)
            //    {
            //        foreach(DataRow dr in dt.Rows)
            //        {
            //            String email = dr["emailadr"].ToString();
            //            if( !Tools.Strings.StrExt(email) )
            //                continue;
            //            if(!nTools.IsEmailAddress(email))
            //            {
            //                try
            //                {
            //                    s.Add(dr["linkid"].ToString(), email);
            //                    context.TheLeader.Comment("Added " + email);
            //                }
            //                catch(Exception)
            //                {
            //                }
            //            }
            //        }
            //    }
            //    context.TheLeader.Comment("Calculating contact addresses...");
            //    if( only_oem )
            //        strSQL = "select distinct(isnull(primaryemailaddress, '')) as emailadr, ('companycontact~' + unique_id) as linkid from companycontact where isnull(donotemail, 0) = 0 and len(primaryemailaddress) > 0 and base_company_uid in (select company.unique_id from company where company.abs_type = 'OEM' or company.companytype like '%oem%')";
            //    else
            //        strSQL = "select distinct(isnull(primaryemailaddress, '')) as emailadr, ('companycontact~' + unique_id) as linkid from companycontact where isnull(donotemail, 0) = 0 and len(primaryemailaddress) > 0";
            //    dt = context.Select(strSQL);
            //    if(dt != null)
            //    {
            //        foreach(DataRow dr in dt.Rows)
            //        {
            //            String email = dr["emailadr"].ToString();
            //            if( !Tools.Strings.StrExt(email) )
            //                continue;
            //            if(!nTools.IsEmailAddress(email))
            //            {
            //                try
            //                {
            //                    s.Add(dr["linkid"].ToString(), email);
            //                    context.TheLeader.Comment("Added " + email);
            //                }
            //                catch(Exception)
            //                {
            //                }
            //            }
            //        }
            //    }
            //    StringBuilder sb = new StringBuilder();
            //    if( s.Count == 0 )
            //        sb.AppendLine("No records.");
            //    else
            //    {
            //        sb.AppendLine("  <h1>Invalid Emails</h1>");
            //        sb.AppendLine("  <table border=\"4\" width=\"100%\">");
            //        foreach(DictionaryEntry d in s)
            //        {
            //            sb.AppendLine("    <tr>");
            //            sb.AppendLine("      <td width=\"100%\" align=\"center\" bgcolor=\"#F0F0F0\"><a href=\"showlink_" + d.Key.ToString() + "\"><b><font color=\"#000080\">" + d.Value.ToString() + "</font></b></a></td>");
            //            sb.AppendLine("    </tr>");
            //        }
            //        sb.AppendLine("  </table>");
            //    }
            //    context.TheLeader.Comment("Done.");
            //    context.TheLeader.StopPopStatus(false);
            //    Form xForm = new Form();
            //    xForm.Text = "Invalid Emails";
            //    xForm.Height = 700;
            //    xForm.Width = 900;
            //    xForm.StartPosition = FormStartPosition.CenterScreen;
            //    Browser xBrowser = new Browser();
            //    xBrowser.OnNavigate += new OnNavigateHandler(xBrowser_OnNavigate);
            //    xBrowser.ReloadWB();
            //    if( !Tools.Strings.StrExt(sb.ToString()) )
            //        xBrowser.Add("No Results.");
            //    else
            //        xBrowser.Add(sb.ToString());
            //    xForm.Controls.Add(xBrowser);
            //    xBrowser.Top = 0;
            //    xBrowser.Left = 0;
            //    xBrowser.Width = xForm.ClientRectangle.Width;
            //    xBrowser.Height = xForm.ClientRectangle.Height;
            //    xForm.Show();
            //    xForm.BringToFront();
            //}
            //catch(Exception ee)
            //{
            //}
        }
        void xBrowser_OnNavigate(ContextRz context, GenericEvent e)
        {
            if (e.Message.Contains("showlink_"))
            {
                e.Handled = true;
                String hold = Tools.Strings.ParseDelimit(e.Message, "showlink_", 2).Trim();
                String id = Tools.Strings.ParseDelimit(hold, "~", 2).Trim();
                String type = Tools.Strings.ParseDelimit(hold, "~", 1).Trim();
                switch (type.ToLower())
                {
                    case "company":
                        company c = company.GetById(context, id);
                        if (c != null)
                            context.Show(c);
                        break;
                    case "companycontact":
                        companycontact cc = companycontact.GetById(context, id);
                        if (cc != null)
                            context.Show(cc);
                        break;
                }
            }
        }
        public String GetIncompleteEmailReport_Company(Context context)
        {
            return GetIncompleteEmailReport(context, "company", "primaryemailaddress", "base_mc_user_uid");
        }
        public String GetIncompleteEmailReport_Contact(Context context)
        {
            return GetIncompleteEmailReport(context, "companycontact", "primaryemailaddress", "base_mc_user_uid");
        }
        public String GetIncompleteEmailReport(Context context, String strTable, String strAddressField, String strUserField)
        {
            try
            {
                context.Execute("drop table temp_incomplete_email_report");
            }
            catch { }

            context.Execute("create table temp_incomplete_email_report( the_n_user_uid varchar(255), user_name varchar(255), incomplete_count int)");
            context.Execute("insert into temp_incomplete_email_report( the_n_user_uid, user_name ) select unique_id, name from n_user");
            context.Execute("update temp_incomplete_email_report set incomplete_count = (select count(*) from " + strTable + " where " + strUserField + " = the_n_user_uid and ( " + strAddressField + " > '' and ( " + strAddressField + " not like '%_@_%._%' or " + strAddressField + " like '% %' ) ))");
            return context.TheData.TheConnection.ConvertSQLToHTML("select user_name as [Agent], incomplete_count as [Incomplete Addresses] from temp_incomplete_email_report where incomplete_count > 0 order by incomplete_count desc");
        }
        public virtual bool CalcContactActivityTotals(ContextRz context)
        {
            return CalcContactActivityTotals(context, "");
        }
        public virtual bool CalcContactActivityTotals(ContextRz context, String strIn)
        {
            context.TheLeader.Comment("Calculating quick quotes...");
            if (!CalculateOneContactActivityTotal(context, strIn, "quote", "base_companycontact_uid", "qquote", "datecreated", "quotetype = 'giving out'", ""))
                return false;
            context.TheLeader.Comment("Calculating part searches...");
            if (!CalculateOneContactActivityTotal(context, strIn, "hit", "base_companycontact_uid", "partsearch", "hitdate", "", ""))
                return false;
            context.TheLeader.Comment("Calculating formal quotes...");

            CalculateOneContactActivityTotal(context, strIn, ordhed.MakeOrdhedName(Enums.OrderType.Quote), "base_companycontact_uid", "fquote", "orderdate", "ordertype = 'quote' and isnull(isvoid, 0) = 0", "");

            context.Execute("update companycontact set calc_fquote_count = isnull(calc_qquote_count, 0) + isnull(calc_fquote_count, 0)");
            context.Execute("update companycontact set calc_last_fquote = calc_last_qquote where calc_last_qquote > calc_last_fquote");

            context.TheLeader.Comment("Calculating sales...");
            if (!CalculateOneContactActivityTotal(context, strIn, ordhed.MakeOrdhedName(Enums.OrderType.Invoice), "base_companycontact_uid", "sale", "orderdate", "ordertype = 'invoice' and isnull(isvoid, 0) = 0", "ordertotal"))
                return false;
            context.TheLeader.Comment("Applying colors...");
            context.Execute("update companycontact set grid_color = " + System.Drawing.Color.Blue.ToArgb().ToString() + " where isnull(calc_sale_count, 0) > 0");
            context.Execute("update companycontact set grid_color = " + System.Drawing.Color.Green.ToArgb().ToString() + " where isnull(calc_sale_count, 0) = 0 and isnull(calc_fquote_count, 0) > 0");
            context.Execute("update companycontact set grid_color = " + System.Drawing.Color.Red.ToArgb().ToString() + " where isnull(calc_sale_count, 0) = 0 and isnull(calc_fquote_count, 0) = 0");
            //            if (calc_sale_count > 0)
            //    grid_color = System.Drawing.Color.Blue.ToArgb();
            //else
            //{
            //    if( calc_fquote_count > 0 )
            //        grid_color = System.Drawing.Color.Green.ToArgb();
            //    else
            //        grid_color = System.Drawing.Color.Red.ToArgb();
            context.TheLeader.Comment("Done.");
            return true;
        }
        private bool CalculateOneContactActivityTotal(ContextRz context, String strIn, String strTable, String strField, String strKey, String strDateField, String strExtra, String totalamountfield)
        {
            String strSQL = "";
            //Count
            strSQL = "update companycontact set calc_" + strKey + "_count = (select count(*) from " + strTable + " where " + strField + " = companycontact.unique_id";
            if (Tools.Strings.StrExt(strExtra))
                strSQL += " and " + strExtra;
            strSQL += " ) ";
            if (Tools.Strings.StrExt(strIn))
                strSQL += " where companycontact.unique_id in (" + strIn + ")";
            context.Execute(strSQL);

            //Last
            strSQL = "update companycontact set calc_last_" + strKey + " = (select max(" + strDateField + ") from " + strTable + " where " + strField + " = companycontact.unique_id";
            if (Tools.Strings.StrExt(strExtra))
                strSQL += " and " + strExtra;
            strSQL += " ) ";
            if (Tools.Strings.StrExt(strIn))
                strSQL += " where companycontact.unique_id in (" + strIn + ")";
            context.Execute(strSQL);

            if (Tools.Strings.StrExt(totalamountfield))
            {
                //Amount
                strSQL = "update companycontact set calc_" + strKey + "_amount = (select sum(isnull(" + totalamountfield + ", 0)) from " + strTable + " where " + strField + " = companycontact.unique_id";
                if (Tools.Strings.StrExt(strExtra))
                    strSQL += " and " + strExtra;
                strSQL += " ) ";
                if (Tools.Strings.StrExt(strIn))
                    strSQL += " where companycontact.unique_id in (" + strIn + ")";
                context.Execute(strSQL);
            }
            return true;
        }
        public void RunPDAExport(ContextRz context)
        {
            context.Reorg();
            //context.Execute("drop table temp_pda_export", true);
            //context.Execute("create table temp_pda_export( company varchar(255), contact varchar(255), phone varchar(255), fax varchar(255), email varchar(255), address1 varchar(255), address2 varchar(255), address3 varchar(255), city varchar(255), state varchar(255), zip varchar(255), country varchar(255) )");
            //context.Execute("insert into temp_pda_export ( company, contact, phone, fax, email ) select isnull(companyname, ''), isnull(primarycontact, ''), isnull(primaryphone, ''), isnull(primaryfax, ''), isnull(primaryemailaddress, '') from company where isnull(companyname, '') > ''");
            //context.Execute("insert into temp_pda_export ( company, contact, phone, fax, email ) select isnull(companyname, ''), isnull(contactname, ''), isnull(primaryphone, ''), isnull(primaryfax, ''), isnull(primaryemailaddress, '') from companycontact where isnull(companyname, '') > '' and isnull(contactname, '') > ''");
            //context.Execute("insert into temp_pda_export ( company, address1, address2, address3, city, state, zip, country ) select isnull(company.companyname, ''), isnull(line1, ''), isnull(line2, ''), isnull(line3, ''), isnull(adrcity, ''), isnull(adrstate, ''), isnull(adrzip, ''), isnull(adrcountry, '') from companyaddress inner join company on company.unique_id = companyaddress.base_company_uid");
            //String s = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "exports\\";
            //if( !Directory.Exists(s) )
            //    Directory.CreateDirectory(s);
            //String n = context.TheLeader.AskForString("File Name", "pda_export", "Export Name", RzApp.xMainForm);
            //if( !Tools.Strings.StrExt(n) )
            //    return;
            //s += n + ".csv";
            //DataTable d = context.Select("select * from temp_pda_export group by company, contact, phone, fax, email, address1, address2, address3, city, state, zip, country order by company, contact");
            //long l = 0;
            //if (TheContext.xSys.xData.ExportDataTableToCsv(d, s, ref l))
            //    nTools.ExploreFolder(Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "exports\\");
        }
        //public bool SendLabelPrintRequest(ContextRz context, String strLabelName, nObject xObject)
        //{
        //    return SendLabelPrintRequest(context, strLabelName, xObject, "", true);
        //}
        //public bool SendLabelPrintRequest(String strLabelName, nObject xObject, String strExtra, bool send_network)
        //{


        //    //if( !strLabelName.ToLower().EndsWith(".lwl") )
        //    //    strLabelName += ".lwl";
        //    //label_queue q = (label_queue)TheContext.xSys.MakeObject("label_queue");
        //    //q.label_template = strLabelName;
        //    //q.object_id = xObject.unique_id;
        //    //q.object_class = xObject.ClassName;
        //    //q.extra_data = strExtra;
        //    //switch(xObject.ClassName.ToLower())
        //    //{
        //    //    case "companycontact":
        //    //        companycontact c = (companycontact)xObject;
        //    //        q.fixed_address = Tools.Strings.KillBlankLines(c.GetFullMailingAddress());
        //    //        q.split_address = c.companyname + "|" + c.contactname + "|" + c.line1.Replace("|", "") + "|" + c.line2.Replace("|", "") + "|" + c.line3.Replace("|", "") + "|" + c.adrcity.Replace("|", "") + "|" + c.adrstate.Replace("|", "") + "|" + c.adrzip.Replace("|", "") + "|" + c.adrcountry.Replace("|", "");
        //    //        break;
        //    //    case "company":
        //    //        company com = (company)xObject;
        //    //        companyaddress ca = (companyaddress)xObject.xSys.QtO("companyaddress", "select top 1 * from companyaddress where base_company_uid = '" + com.unique_id + "' and line1 > ''");
        //    //        if(ca == null)
        //    //        {
        //    //            context.TheLeader.Comment(com.ToString() + " doesn't appear to have a valid address.");
        //    //            return false;
        //    //        }
        //    //        String strContact = "";
        //    //        if( Tools.Strings.StrExt(com.primarycontact) )
        //    //            strContact = "Attn: " + com.primarycontact;
        //    //        if(!Tools.Strings.StrExt(strContact))
        //    //        {
        //    //            if(!Tools.Strings.StrCmp(GenericLabelContactName, "<none>"))
        //    //            {
        //    //                if(!Tools.Strings.StrExt(GenericLabelContactName))
        //    //                {
        //    //                    GenericLabelContactName = n_set.GetSetting(context, "generic_label_contact_name");
        //    //                    if( !Tools.Strings.StrExt(GenericLabelContactName) )
        //    //                        GenericLabelContactName = "<none>";
        //    //                }
        //    //                if( !Tools.Strings.StrCmp(GenericLabelContactName, "<none>") && Tools.Strings.StrExt(GenericLabelContactName) )
        //    //                    strContact = GenericLabelContactName;
        //    //            }
        //    //        }
        //    //        if( Tools.Strings.StrExt(strContact) )
        //    //            strContact = "\r\n" + strContact;
        //    //        q.fixed_address = Tools.Strings.KillBlankLines(com.companyname + strContact + "\r\n" + ca.GetAddressString());
        //    //        break;
        //    //}
        //    //q.ISave();
        //    //if( !send_network )
        //    //    return true;
        //    //try
        //    //{
        //    //    String strServer = n_set.GetSetting(context, "label_server");
        //    //    if(!Tools.Strings.StrExt(strServer))
        //    //    {
        //    //        TellUserTemp("No computer has been set as the label manager.", RzApp.xMainForm.TheContextNM);
        //    //        return false;
        //    //    }
        //    //    IPHostEntry IPHost = Dns.Resolve(strServer);
        //    //    string[] aliases = IPHost.Aliases;
        //    //    IPAddress[] addr = IPHost.AddressList;
        //    //    EndPoint ep = new IPEndPoint(addr[0], 618);
        //    //    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    //    sock.Connect(ep);
        //    //    if(sock.Connected)
        //    //    {
        //    //        sock.Send(Encoding.ASCII.GetBytes(q.unique_id));
        //    //        sock.Close();
        //    //        context.TheLeader.TellTemp("The print request was sent to " + strServer + ".");
        //    //        return true;
        //    //    }
        //    //    else
        //    //    {
        //    //        return false;
        //    //    }
        //    //}
        //    //catch(Exception ex)
        //    //{
        //    //    //nStatus.TellUserTemp("Contacting the label server failed: " + ex.Message);
        //    //    return false;
        //    //}
        //}
        public void NewHotPart(ContextRz context, company c, companycontact co, String strPart)
        {
            orddet_quote q = orddet_quote.New(context);
            q.UserObjectSet((n_user)context.xUser);
            q.CompanyObjectSet(c);
            q.ContactObjectSet(co);
            q.fullpartnumber = strPart;
            q.is_priority = true;
            context.Insert(q);
            context.Show(q);
        }
        public String GetFlipChartHTML(ContextRz context)
        {
            String strSQL = "select saleheader.orderdate as [saledate], saleheader.companyname as [customer], saleheader.isvoid as [salevoid], saleheader.advance_payment_made as [advance_payment_received], saleheader.has_issue, purchaseheader.companyname as [vendor], purchaseheader.is_confirmed as [purchaseconfirmed], purchaseheader.advance_payment_made as [advance_payment_sent], saleline.fullpartnumber, saleline.quantityordered as [orderedquantity], saleline.quantityfilled as [filledquantity], saleline.unitcost as [salecost],  saleline.unitprice as [saleprice], purchaseheader.terms as [purchaseterms], saleheader.agentname as [saleagent], purchaseheader.orderdate as [purchasedate], purchaseheader.ordernumber as [purchasenumber], purchaseheader.trackingnumber as [purchasetracking], purchaseline.filldate as [datereceived], saleline.filldate as [dateshipped] ";
            strSQL += " from " + ordhed.MakeOrddetName(Enums.OrderType.Sales) + " saleline   ";
            strSQL += " inner join " + ordhed.MakeOrdhedName(Enums.OrderType.Sales) + " saleheader on saleheader.unique_id = saleline.base_ordhed_uid   ";
            strSQL += " inner join " + ordhed.MakeOrddetName(Enums.OrderType.Purchase) + " purchaseline on purchaseline.ordertype = 'purchase' and purchaseline.stockid = saleline.stockid and exists(select * from ordlnk where ordlnk.orderid1 = saleline.base_ordhed_uid and orderid2 = purchaseline.base_ordhed_uid )   ";
            strSQL += " inner join " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + " purchaseheader on purchaseheader.unique_id = purchaseline.base_ordhed_uid   ";
            strSQL += " where saleheader.ordertype = 'SALES' and isnull(saleheader.isclosed, 0) = 0 and isnull(saleheader.isflipdeal, 0) = 0   ";
            strSQL += " group by saleheader.orderdate, saleheader.companyname, saleheader.isvoice, saleheader.advance_payment_made, saleheader.has_issue, purchaseheader.companyname, purchaseheader.is_confirmed, purchaseheader.advance_payment_made, saleline.fullpartnumber, saleline.quantityordered, saleline.quantityfilled, saleline.unitcost,  saleline.unitprice, purchaseheader.terms, saleheader.agentname, purchaseheader.orderdate, purchaseheader.ordernumber, purchaseheader.trackingnumber, purchaseline.filldate, saleline.filldate   ";
            strSQL += " order by saleheader.orderdate, saleline.fullpartnumber  ";
            DataTable d = context.Select(strSQL);
            if (!Tools.Data.DataTableExists(d))
                return "<h1>font color=gray>No Results.</font></h1>";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=1 cellpadding=1 cellspacing=1>");
            sb.Append("<tr>");
            sb.Append("<td><b>Part Number</b></td>");
            sb.Append("<td><b>QTY</b></td>");
            sb.Append("<td><b>COG</b></td>");
            sb.Append("<td><b>% GP</b></td>");
            sb.Append("<td><b>Vendor Terms</b></td>");
            sb.Append("<td><b>Sales Rep</b></td>");
            sb.Append("<td><b>OEM Rep</b></td>");
            sb.Append("<td><b>PO To Vendor</b></td>");
            sb.Append("<td><b>NTC PO#</b></td>");
            sb.Append("<td><b>A/P</b></td>");
            sb.Append("<td><b>Inbound Tracking</b></td>");
            sb.Append("<td><b>Received In</b></td>");
            sb.Append("<td><b>Shipped Out</b></td>");
            sb.Append("</tr>\r\n");
            String strPart = "";
            long lngQuantity = 0;
            Double dblCost = 0;
            Double dblPrice = 0;
            Double dblTotalCost = 0;
            Double dblProfitPercent = 0;
            String strVendorTerms = "";
            String strSalesRep = "";
            String strOEMRep = "";
            DateTime dtPO;
            String strPONumber = "";
            String strAP = "";
            String strInboundTracking = "";
            DateTime dtReceived;
            DateTime dtShipped;
            foreach (DataRow r in d.Rows)
            {
                strPart = nData.NullFilter_String(r["fullpartnumber"]);
                lngQuantity = nData.NullFilter_Long(r["orderedquantity"]);
                dblCost = nData.NullFilter_Double(r["salecost"]);
                dblPrice = nData.NullFilter_Double(r["saleprice"]);
                dblTotalCost = Math.Round(lngQuantity * dblCost, 2);
                Double dblTotalPrice = Math.Round(lngQuantity * dblPrice, 2);
                Double dblProfit = dblTotalPrice - dblTotalCost;
                dblProfitPercent = dblProfit / dblTotalCost;
                dblProfitPercent = Math.Round(dblProfitPercent * 100, 0);
                //dblGP = nData.NullFilter_Double(r[""]);
                strVendorTerms = nData.NullFilter_String(r["purchaseterms"]);
                strSalesRep = nData.NullFilter_String(r["saleagent"]);
                strOEMRep = nData.NullFilter_String(r["saleagent"]);
                dtPO = nData.NullFilter_Date(r["purchasedate"]);
                strPONumber = nData.NullFilter_String(r["purchasenumber"]);
                //strAP = nData.NullFilter_String(r[""]);
                strInboundTracking = nData.NullFilter_String(r["purchasetracking"]);
                dtReceived = nData.NullFilter_Date(r["datereceived"]);
                dtShipped = nData.NullFilter_Date(r["dateshipped"]);
                bool IsShipped = Tools.Dates.DateExists(dtShipped);
                bool IsMoneyReceived = nData.NullFilter_Boolean(r["advance_payment_received"]);
                bool IsMoneySent = nData.NullFilter_Boolean(r["advance_payment_sent"]);
                bool IsVoid = nData.NullFilter_Boolean(r["isvoid"]);
                bool IsConfirmed = nData.NullFilter_Boolean(r["is_confirmed"]);
                bool IsIssue = nData.NullFilter_Boolean(r["has_issue"]);
                String strColor = "";
                if (IsVoid)
                    strColor = "#FF66CC";
                else if (IsIssue)
                    strColor = "#3366FF";
                else if (IsShipped)
                    strColor = "#66FF33";
                else if (IsMoneySent)
                    strColor = "#FF00FF";
                else if (IsMoneyReceived)
                    strColor = "#FFFF00";
                else if (IsConfirmed)
                    strColor = "#CC99FF";
                if (Tools.Strings.StrExt(strColor))
                    sb.Append("<tr bgcolor=\"" + strColor + "\">");
                else
                    sb.Append("<tr>");
                sb.Append("<td nowrap>" + strPart + "&nbsp;</td>");
                sb.Append("<td nowrap align=\"right\">" + Tools.Number.LongFormat(lngQuantity) + "&nbsp;</td>");
                sb.Append("<td nowrap align=\"right\">" + nTools.MoneyFormat(dblTotalCost) + "&nbsp;</td>");
                sb.Append("<td nowrap align=\"right\">" + Tools.Number.LongFormat(dblProfitPercent) + "%&nbsp;</td>");
                sb.Append("<td nowrap>" + strVendorTerms + "&nbsp;</td>");
                sb.Append("<td nowrap>" + strSalesRep + "&nbsp;</td>");
                sb.Append("<td nowrap>" + strOEMRep + "&nbsp;</td>");
                sb.Append("<td nowrap align=\"center\">" + nTools.DateFormat(dtPO) + "</td>");
                sb.Append("<td nowrap>" + strPONumber + "&nbsp;</td>");
                sb.Append("<td nowrap>" + strAP + "&nbsp;</td>");
                sb.Append("<td nowrap>" + strInboundTracking + "&nbsp;</td>");
                sb.Append("<td nowrap align=\"center\">" + nTools.DateFormat(dtReceived) + "</td>");
                sb.Append("<td nowrap align=\"center\">" + nTools.DateFormat(dtShipped) + "</td>");
                sb.Append("</tr>\r\n");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        public String GetBuyReportHTML(ContextRz context)
        {
            StringBuilder sb = new StringBuilder();
            DataTable d = context.Select("select fullpartnumber as [Part Number], quantity as [Quantity], manufacturer as [Manufacturer], datecode as [Date Code], location as [Location], ordhed.companyname as [Customer], buy_date as [Buy Date] from partrecord left join ordhed on ordhed.unique_id = partrecord.buy_sales_id where stocktype = 'buy' and isnull(fullpartnumber, '') > '' and quantity > 0 order by buy_date desc, fullpartnumber");
            return nData.ConvertDataTableToHTML(d);
        }
        public String GetServiceReportHTML()
        {
            //StringBuilder sb = new StringBuilder();
            //DataTable d = Rz3App.xSys.xData.GetDataTable("select fullpartnumber as [Part Number], quantity as [Quantity], manufacturer as [Manufacturer], datecode as [Date Code], location as [Location], ordhed.companyname as [Customer], buy_date as [Buy Date] from partrecord left join ordhed on ordhed.unique_id = partrecord.buy_sales_id where stocktype = 'buy' and isnull(fullpartnumber, '') > '' and quantity > 0 order by buy_date desc, fullpartnumber");
            //return nData.ConvertDataTableToHTML(d);
            return "";
        }
        public String GetBuyAndServiceReportHTML(ContextRz context)
        {
            return GetBuyReportHTML(context) + "\r\n\r\n" + GetServiceReportHTML();
        }
        //public void MakeRz3IndexesExist()
        //{
        //    MakeRz3IndexesExist(TheContext.xSys.xData);
        //}
        //public void MakeRz3IndexesExist(nData dt)
        //{
        //    ArrayList a = new ArrayList();
        //    //partrecord
        //    //prefix_basenumberstripped_index
        //    a.Add("create clustered index prefix_basenumberstripped_index on partrecord (stocktype, prefix, basenumberstripped, alternatepart )");
        //    a.Add("create index alternatepartstripped_index on partrecord (alternatepartstripped)");
        //    a.Add("create index userdata_01_index on partrecord (userdata_01)");
        //    a.Add("create index importid_index on partrecord (importid)");
        //    //offer
        //    AddOfferIndex(a);
        //    //req
        //    a.Add("create clustered index prefix_basenumberstripped_index on req (prefix, basenumberstripped)");
        //    a.Add("create index alternatepartstripped_index on req (alternatepartstripped)");
        //    a.Add("create index search_company on req (base_company_uid)");
        //    //quote
        //    a.Add("create clustered index prefix_basenumberstripped_index on quote (quotetype, basenumberstripped, prefix, alternatepartstripped, alternatepart_01, alternatepart_02, alternatepart_03, alternatepart_04)");
        //    a.Add("create index search_company on quote (base_company_uid)");
        //    //companycontact
        //    a.Add("create index search_company on companycontact (base_company_uid)");
        //    a.Add("create index search_contact on companycontact (contactname)");
        //    //orders
        //    GetRz3OrderIndexes(a);
        //    //usernote
        //    a.Add("create index search_note on usernote(for_mc_user_uid, by_mc_user_uid, shouldpopup)");
        //    foreach (DictionaryEntry d in TheContext.xSys.CoalesceClasses())
        //    {
        //        n_class c = (n_class)d.Value;
        //        a.Add("create index search_unique on " + c.class_name + " (unique_id)");
        //    }
        //    foreach(String s in a)
        //    {
        //        if(dt.Execute(s, false, true))
        //        {
        //            context.TheLeader.Comment("Index Complete: " + s);
        //        }
        //        else
        //        {
        //            //context.TheLeader.Comment("Index Exists: " + s);
        //        }
        //    }
        //}
        public virtual void AddOfferIndex(ArrayList a)
        {
            if (a != null)
                a.Add("create clustered index prefix_basenumberstripped_index on offer (prefix, basenumberstripped)");
        }
        public virtual void RemoveOfferIndex(DataConnection dt)
        {
            if (dt != null)
                dt.Execute("drop index prefix_basenumberstripped_index on offer");
        }



        //public void GetRzOrderIndexes(ArrayList a)
        //{
        //    GetRz3OrderIndexes("ordhed_rfq", "orddet_rfq", a);
        //    GetRz3OrderIndexes("ordhed_quote", "orddet_quote", a);
        //    GetRz3OrderIndexes("ordhed_service", "", a);        //orddet_service
        //    GetRz3OrderIndexes("ordhed_sales", "", a);          //orddet_sales
        //    GetRz3OrderIndexes("ordhed_purchase", "", a);       //orddet_purchase
        //    GetRz3OrderIndexes("ordhed_invoice", "", a);        //orddet_invoice
        //    GetRz3OrderIndexes("ordhed_rma", "", a);            //orddet_rma
        //    GetRz3OrderIndexes("ordhed_vendrma", "", a);        //orddet_vendrma
        //}
        //public void GetRz3OrderIndexes(String strOrdhed, String strOrddet, ArrayList a)
        //{
        //    //ordhed
        //    a.Add("create index search_ordernumber on " + strOrdhed + " (ordernumber)");  //if this ever gets un-commented, this index needs to be unique
        //    a.Add("create index search_company on " + strOrdhed + " (companyname)");
        //    a.Add("create clustered index search_ordhed_general on " + strOrdhed + " (ordernumber, orderdate, companyname)");
        //    //orddet
        //    if (Tools.Strings.StrExt(strOrddet))
        //    {
        //        a.Add("create index prefix_basenumberstripped_index on " + strOrddet + " (ordertype, prefix, basenumberstripped, alternatepartstripped, internalstripped)");
        //        a.Add("create clustered index search_order on " + strOrddet + " (base_ordhed_uid)");
        //    }
        //}
        //public void RemoveRz3Indexes(nData dt)
        //{
        //    try
        //    {
        //        //partrecord
        //        dt.Execute("drop index prefix_basenumberstripped_index on partrecord", false, true);
        //        dt.Execute("drop index alternatepartstripped_index on partrecord", false, true);
        //        dt.Execute("drop index userdata_01_index on partrecord", false, true);
        //        dt.Execute("drop index importid_index on partrecord", false, true);
        //        //offer
        //        RemoveOfferIndex(dt);
        //        //req
        //        dt.Execute("drop index prefix_basenumberstripped_index on req", false, true);
        //        dt.Execute("drop index alternatepartstripped_index on req", false, true);
        //        dt.Execute("drop index search_company on req", false, true);
        //        //quote
        //        dt.Execute("drop index prefix_basenumberstripped_index on quote", false, true);
        //        dt.Execute("drop index alternatepartstripped_index on quote", false, true);
        //        dt.Execute("drop index search_company on quote", false, true);
        //        //companycontact
        //        dt.Execute("drop index search_company on companycontact", false, true);
        //        dt.Execute("drop index search_contact on companycontact", false, true);
        //        //orders
        //        Rz3RemoveRz3OrderIndexes(dt);
        //        //usernote
        //        dt.Execute("drop index search_note on usernote", false, true);
        //        foreach (DictionaryEntry d in TheContext.xSys.CoalesceClasses())
        //        {
        //            n_class c = (n_class)d.Value;
        //            dt.Execute("drop index search_unique on " + c.class_name, false, true);
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        context.TheLeader.Comment("Error removing indexes: " + ee.Message);
        //    }
        //}
        //public void Rz3RemoveRz3OrderIndexes(nData dt)
        //{
        //    Rz3RemoveRz3OrderIndexes(dt, "ordhed_rfq", "orddet_rfq");
        //    Rz3RemoveRz3OrderIndexes(dt, "ordhed_quote", "orddet_quote");
        //    Rz3RemoveRz3OrderIndexes(dt, "ordhed_service", "");
        //    Rz3RemoveRz3OrderIndexes(dt, "ordhed_sales", "");
        //    Rz3RemoveRz3OrderIndexes(dt, "ordhed_purchase", "");
        //    Rz3RemoveRz3OrderIndexes(dt, "ordhed_invoice", "");
        //    Rz3RemoveRz3OrderIndexes(dt, "ordhed_rma", "");
        //    Rz3RemoveRz3OrderIndexes(dt, "ordhed_vendrma", "");
        //}
        //public void Rz3RemoveRz3OrderIndexes(DataConnection dt, String strOrdhed, String strOrddet)
        //{
        //    //ordhed
        //    dt.Execute("drop index search_ordernumber on " + strOrdhed, false, true);
        //    dt.Execute("drop index search_company on " + strOrdhed, false, true);
        //    dt.Execute("drop index search_ordhed_general on " + strOrdhed, false, true);
        //    //orddet
        //    if (Tools.Strings.StrExt(strOrddet))
        //    {
        //        dt.Execute("drop index prefix_basenumberstripped_index on " + strOrddet, false, true);
        //        dt.Execute("drop index alternatepartstripped_index on " + strOrddet, false, true);
        //        dt.Execute("drop index search_order on " + strOrddet, false, true);
        //    }
        //}
        public void ShowMultiSearchReport(ContextRz context)
        {
            context.Reorg();
            //if(!context.xUser.CheckPermit(context, "Report:View:MultiSearchReport"))
            //{
            //    context.TheLeader.ShowNoRight();
            //    return;
            //}
            //String strTable = "temp_" + Tools.Strings.GetNewID();
            //context.Execute("select distinct(user_name) as [Agent] into " + strTable + " from multisearch_log where isnull(user_name, '') > '' and user_name not like 'Recognin%' order by user_name");
            //DataTable d = context.Select("select distinct(site_name) from multisearch_log order by site_name");
            //foreach(DataRow r in d.Rows)
            //{
            //    String strColumn = nData.NullFilter_String(r[0]);
            //    context.Execute("alter table " + strTable + " add [" + strColumn + "] int");
            //    context.Execute("update " + strTable + " set [" + strColumn + "] = (select count(*) from multisearch_log where multisearch_log.user_name = " + strTable + ".Agent and multisearch_log.site_name = '" + strColumn + "' )");
            //}
            //String s = context.xSys.xData.ConvertSQLToHTML("select * from " + strTable + " order by Agent");
            //RzApp.xMainForm.ShowHTML("<h1>MultiSearch Report</h1>" + s, "MultiSearch Report");
        }
        //public bool CanBeViewedBy(IAssignedAgent x, NewMethod.n_user u)
        //{
        //    if (x == null)
        //        return true;
        //    if (u.SuperUser)
        //        return true;
        //    if (Tools.Strings.StrCmp(u.unique_id, x.UserID))
        //        return true;
        //    String username = x.UserName;
        //    if (!Rz3App.xLogic.IsCTG)
        //    {
        //        switch (x.GetClassName().ToLower())
        //        {
        //            case "companycontact":
        //                if (username == "")
        //                {
        //                    companycontact contact = (companycontact)x;
        //                    company comp = contact.CompanyObject;
        //                    if (comp != null)
        //                        username = comp.agentname;
        //                }
        //                break;
        //        }
        //    }
        //    switch (username.ToLower())
        //    {
        //        case "":
        //        case "bad record":
        //        case "house account":
        //        case "house":
        //        case "unassigned":
        //            return true;
        //    }
        //    switch (x.GetClassName().ToLower().Trim())
        //    {
        //        case "company":
        //            company c = (company)x;
        //            if (c == null)
        //                return false;
        //            if (Tools.Strings.StrCmp(c.companytype, "vendor") || c.isvendor)
        //                return true;
        //            break;
        //        case "ordhed_purchase":  //this never happens; ordhed doesn't pass to here
        //            return true;
        //        case "ordhed_invoice":  //this never happens; ordhed doesn't pass to here
        //            if (Rz3App.xLogic.IsCTG)
        //            {
        //                if (Rz3App.SalesPeople.Contains(u.name))
        //                    return true;
        //            }
        //            break;
        //    }
        //    if (Rz3App.xLogic.IsCTG)
        //        return u.IsOnTeamWith(x.UserID);
        //    else
        //    {
        //        if (u.IsOnTeamWith(x.UserID) && u.CheckPermit(context, "View:Company:ViewAllCompaniesOnTeam", true))
        //            return true;
        //        else
        //            return u.CheckPermit(Permissions.ViewAllCompanies, true);
        //    }
        //}
        //public bool CanBeEditedBy(IAssignedAgent x, NewMethod.n_user u)
        //{
        //    if (x == null)
        //        return true;
        //    if (u.SuperUser)
        //        return true;
        //    if (!Tools.Strings.StrExt(x.UserID))
        //        return true;
        //    if (Tools.Strings.StrCmp(u.unique_id, x.UserID))
        //        return true;
        //    switch (x.UserName.ToLower())
        //    {
        //        case "":
        //        case "bad record":
        //        case "house account":
        //        case "house":
        //        case "unassigned":
        //        case "vendor":
        //            return true;
        //    }
        //    switch (x.GetClassName().ToLower().Trim())
        //    {
        //        case "ordhed_purchase":
        //            return true;
        //    }
        //    if (Rz3App.xLogic.IsCTG)
        //        return u.IsOnTeamWith(x.UserID);
        //    else
        //    {
        //        if (u.IsOnTeamWith(x.UserID) && u.CheckPermit(context, "Edit:Company:EditAllCompaniesOnTeam", true))
        //            return true;
        //        else
        //            return u.CheckPermit(context, "Edit:Company:EditAllCompanies", true);
        //    }
        //}
        public virtual string GetUpdateFolder(ContextNM x)
        {
            string folder = "";
            String id = x.GetSetting("company_identifier");
            if (Tools.Strings.StrExt(id))
                folder = "Rz3_" + id;
            else
                folder = "Rz4";
            return folder;
        }
        public virtual void ShowEmailsBySQL(ContextRz context, String strSQL, String strAddress)
        {
        }
        public virtual void UpdateCompanyAddresses(ContextRz context)
        {
        }
        public virtual void UpdateContactDomains(ContextRz context)
        {
        }
        public void RemoveUser(ContextRz context, String strTable, String strName)
        {
            String strID = NewMethod.n_user.TranslateNameToID(context, strName);
            if (!Tools.Strings.StrExt(strID))
                return;
            String strSQL = "delete from " + strTable + " where the_n_user_uid = '" + strID + "'";
            context.Execute(strSQL);
        }
        public void ReplaceUser(ContextRz context, String strTable, String strOriginalName, String strReplaceName)
        {
            String strOriginalID = NewMethod.n_user.TranslateNameToID(context, strOriginalName);
            if (!Tools.Strings.StrExt(strOriginalID))
                return;
            String strReplaceID = NewMethod.n_user.TranslateNameToID(context, strReplaceName);
            if (!Tools.Strings.StrExt(strReplaceID))
                return;
            String strSQL = "update " + strTable + " set original_n_user_uid = '" + strOriginalID + "', the_n_user_uid = '" + strReplaceID + "' where the_n_user_uid = '" + strOriginalID + "'";
            context.Execute(strSQL);
            strSQL = "update " + strTable + " set original_n_user_uid = '" + strOriginalID + "' where original_n_user_uid is null and the_n_user_uid = '" + strReplaceID + "'";
            context.Execute(strSQL);
        }
        public bool RestoreFromRecall(ContextRz context, String strClass, String strID)
        {
            context.Reorg();
            return false;
            //n_class c = TheContext.xSys.GetClassByName(strClass);
            //if( c == null )
            //    return false;
            //StringBuilder sb = new StringBuilder();
            //int i = 0;
            //foreach(DictionaryEntry d in c.CoalesceProps())
            //{
            //    n_prop p = (n_prop)d.Value;
            //    if( i > 0 )
            //        sb.Append(", ");
            //    sb.Append(p.name);
            //    i++;
            //}
            //String strRecallDatabase = GetRecallDBName();
            //nObject x = TheContext.xSys.GetByID(strClass, strID);
            //if(x != null)
            //{
            //    context.TheLeader.Tell("This item: [" + x.ToString() + "] already exists.");
            //    return false;
            //}
            //String strSQL = "insert into " + strClass + "( unique_id, " + sb.ToString() + " ) select top 1 unique_id, " + sb.ToString() + " from " + strRecallDatabase + ".dbo." + strClass + " where recall_type = 3 and unique_id = '" + strID + "' order by recall_date desc";
            //return context.Execute(strSQL);
        }
        public virtual string GetRecallDBName()
        {
            return "Rz3_Recall";
        }
        public bool IsBelowMinVersion(ContextRz context)
        {
            long min = n_set.GetSetting_Long(context, "minimum_system_version");
            if (min <= 0)
                return false;
            long cur = Tools.Misc.GetVersionNumber(Tools.ToolsNM.AssemblyNM);
            if (cur < min)
                return true;
            return false;
        }
        public virtual bool Test_QuoteToSalesOrder(ContextNM context)
        {
            //ArrayList AllObjects = new ArrayList();
            //try
            //{
            //    //Create Company With Contact And Address
            //    company cust = new company(Rz3App.xSys);
            //    cust.companyname = "The Simpsons Co.";
            //    cust.companytype = "OEM";
            //    cust.iscustomer = true;
            //    cust.primaryemailaddress = "foo@foo.com";
            //    cust.primaryfax = "555-555-55554";
            //    cust.primaryphone = "555-555-55555";
            //    cust.ISave();
            //    AllObjects.Add(cust);
            //    companycontact cust_cont = new companycontact(Rz3App.xSys);
            //    cust_cont.contactname = "Homer Simpson";
            //    cust_cont.primaryemailaddress = cust.primaryemailaddress;
            //    cust_cont.primaryfax = cust.primaryfax;
            //    cust_cont.primaryphone = cust.primaryphone;
            //    cust_cont.base_company_uid = cust.unique_id;
            //    cust_cont.ISave();
            //    AllObjects.Add(cust_cont);
            //    companyaddress com_adr_ship = new companyaddress(Rz3App.xSys);
            //    com_adr_ship.adrcity = "Tampa";
            //    com_adr_ship.adrcountry = "United States";
            //    com_adr_ship.adrstate = "Florida";
            //    com_adr_ship.adrzip = "33611";
            //    com_adr_ship.base_company_uid = cust.unique_id;
            //    com_adr_ship.base_companycontact_uid = cust_cont.unique_id;
            //    com_adr_ship.defaultbilling = false;
            //    com_adr_ship.defaultshipping = true;
            //    com_adr_ship.description = "Shipping";
            //    com_adr_ship.line1 = "555 Somewhere Lane.";
            //    com_adr_ship.ISave();
            //    AllObjects.Add(com_adr_ship);
            //    companyaddress com_adr_bill = new companyaddress(Rz3App.xSys);
            //    com_adr_bill.adrcity = "Tampa";
            //    com_adr_bill.adrcountry = "United States";
            //    com_adr_bill.adrstate = "Florida";
            //    com_adr_bill.adrzip = "33611";
            //    com_adr_bill.base_company_uid = cust.unique_id;
            //    com_adr_bill.base_companycontact_uid = cust_cont.unique_id;
            //    com_adr_bill.defaultbilling = true;
            //    com_adr_bill.defaultshipping = false;
            //    com_adr_bill.description = "Billing";
            //    com_adr_bill.line1 = "555 Somewhere Lane.";
            //    com_adr_bill.ISave();
            //    AllObjects.Add(com_adr_bill);
            //    //Create Vendor With Contact And Address
            //    company vend = new company(Rz3App.xSys);
            //    vend.companyname = "The Vendor Co.";
            //    vend.companytype = "Disty";
            //    vend.isvendor = true;
            //    vend.primaryemailaddress = "foo@foo.com";
            //    vend.primaryfax = "555-555-55554";
            //    vend.primaryphone = "555-555-55555";
            //    vend.ISave();
            //    AllObjects.Add(vend);
            //    companycontact vend_cont = new companycontact(Rz3App.xSys);
            //    vend_cont.contactname = "Test Vendor Contact";
            //    vend_cont.primaryemailaddress = vend.primaryemailaddress;
            //    vend_cont.primaryfax = vend.primaryfax;
            //    vend_cont.primaryphone = vend.primaryphone;
            //    vend_cont.base_company_uid = vend.unique_id;
            //    vend_cont.ISave();
            //    AllObjects.Add(vend_cont);
            //    companyaddress ven_adr_ship = new companyaddress(Rz3App.xSys);
            //    ven_adr_ship.adrcity = "Anywhere";
            //    ven_adr_ship.adrcountry = "United States";
            //    ven_adr_ship.adrstate = "NorthCarolina";
            //    ven_adr_ship.adrzip = "52365";
            //    ven_adr_ship.base_company_uid = vend.unique_id;
            //    ven_adr_ship.base_companycontact_uid = vend_cont.unique_id;
            //    ven_adr_ship.defaultbilling = false;
            //    ven_adr_ship.defaultshipping = true;
            //    ven_adr_ship.description = "Shipping";
            //    ven_adr_ship.line1 = "888 Big Walk Way";
            //    ven_adr_ship.ISave();
            //    AllObjects.Add(ven_adr_ship);
            //    companyaddress ven_adr_bill = new companyaddress(Rz3App.xSys);
            //    ven_adr_bill.adrcity = "Anywhere";
            //    ven_adr_bill.adrcountry = "United States";
            //    ven_adr_bill.adrstate = "NorthCarolina";
            //    ven_adr_bill.adrzip = "52365";
            //    ven_adr_bill.base_company_uid = vend.unique_id;
            //    ven_adr_bill.base_companycontact_uid = vend_cont.unique_id;
            //    ven_adr_bill.defaultbilling = true;
            //    ven_adr_bill.defaultshipping = false;
            //    ven_adr_bill.description = "Billing";
            //    ven_adr_bill.line1 = "888 Big Walk Way";
            //    ven_adr_bill.ISave();
            //    AllObjects.Add(ven_adr_bill);
            //    //Create Formal Quote With Detail
            //    ordhed_quote quote = new ordhed_quote(Rz3App.xSys);
            //    quote.base_company_uid = cust.unique_id;
            //    quote.base_companycontact_uid = cust_cont.unique_id;
            //    quote.base_mc_user_uid = Rz3App.xUser.unique_id;
            //    quote.billingaddress = com_adr_bill.GetAddressString();
            //    quote.shippingaddress = com_adr_ship.GetAddressString();
            //    quote.companyname = cust.companyname;
            //    quote.contactname = cust_cont.contactname;
            //    quote.ordernumber = ordhed_quote.GetNextNumber(Rz3App.xSys, Enums.OrderType.Quote);
            //    quote.ordertype = "quote";
            //    quote.primaryemailaddress = cust.primaryemailaddress;
            //    quote.primaryfax = cust.primaryfax;
            //    quote.primaryphone = cust.primaryphone;
            //    quote.shipvia = "UPS Ground";
            //    quote.terms = "COD";
            //    quote.username = Rz3App.xUser.name;
            //    quote.ISave();
            //    AllObjects.Add(quote);
            //    orddet quote_det = quote.LineCreate();
            //    quote_det.fullpartnumber = "AD7244JR";
            //    quote_det.datecode = "00+";
            //    quote_det.condition = "NEW";
            //    quote_det.manufacturer = "Analog Device";
            //    quote_det.quantityordered = 100;
            //    quote_det.unitprice = 5;
            //    quote_det.ISave();
            //    AllObjects.Add(quote_det);
            //    ordhed_sales sales = (ordhed_sales)quote.MakeSalesOrder(Rz3App.xMainForm.TheContextNM);
            //    foreach (KeyValuePair<string, nObject> kvp in sales.AllDetails)
            //    {
            //        orddet d = (orddet)kvp.Value;
            //        d.vendor_company_uid = vend.unique_id;
            //        d.vendorcontactid = vend_cont.unique_id;
            //        d.vendorcontactname = vend_cont.contactname;
            //        d.vendorname = vend.companyname;
            //        d.unitcost = 2.5;
            //        d.ISave();
            //        AllObjects.Add(d);
            //    }
            //    AllObjects.Add(sales);
            //    sales.orderreference = "TestRef-123";
            //    //this is good but we need to figure it out with the async possibility of CompleteSalesOrder
            //    //ArrayList pos = new ArrayList();
            //    //sales.CompleteSalesOrder(Rz3App.xMainForm.TheContextNM, ref pos);
            //    //if (pos == null)
            //    //    return false;
            //    //if (pos.Count <= 0)
            //    //    return false;
            //    //ordhed inv = new ordhed(Rz3App.xSys);
            //    //foreach (ordhed o in pos)
            //    //{
            //    //    AllObjects.Add(o);
            //    //    o.FillCompleteOrder(context, true, ref inv);
            //    //    AllObjects.Add(inv);
            //    //    foreach (KeyValuePair<string, nObject> kvp in inv.AllDetails)
            //    //    {
            //    //        orddet d = (orddet)kvp.Value;
            //    //        AllObjects.Add(d);
            //    //    }
            //    //    inv.FillCompleteOrder(context);
            //    //}
            //}
            //catch { }
            //foreach (nObject o in AllObjects)
            //{
            //    o.IDelete();
            //}
            return true;
        }
        //public void LoadAgentTeamCombo(ContextRz x, ComboBox cbo)
        //{
        //    LoadAgentTeamCombo(x, cbo, true, false);
        //}
        public void LoadAgentTeamCombo(ContextRz x, ComboBox cbo, bool only_salespeople, bool force_all)
        {
            String defaultValue = "";
            cbo.Items.Clear();
            foreach (String s in x.TheSysRz.TheUserLogicRz.AgentOptionsList(x, true, true, false, ref defaultValue))
            {
                cbo.Items.Add(s);
            }
            cbo.Text = defaultValue;
        }
        public ArrayList GetAgentTeamCollection(ContextRz x, String strCode)
        {
            return GetAgentTeamCollection(x, strCode, false);
        }
        private void TellUserTemp(string s, ContextNM x)
        {
            if (x != null)
                x.TheLeader.TellTemp(s);
        }
        public virtual void CheckWebMemberCache(ContextRz x)
        {

        }
        public ArrayList SalespeopleListWithoutManagers(ContextRz x)
        {
            ContextRz xrz = (ContextRz)x;

            //AAAAAAAAHHHHH.  how did i not see that this essentially removes the managers from SalesPeople when it runs!!!!
            //ArrayList salespeople = Rz3App.SalesPeople;
            ArrayList salespeople = new ArrayList(xrz.Logic.SalesPeople);
            foreach (AssistantHandle h in GetAssistantHandles(x))
            {
                salespeople.Remove(h.ManagerUser.name);
            }
            salespeople.Sort();
            return salespeople;
        }
        public virtual ArrayList ManagersList(ContextRz x)
        {
            ArrayList managers = new ArrayList();
            foreach (AssistantHandle h in GetAssistantHandles(x))
            {
                managers.Add(h.ManagerUser.name);
            }
            managers.Sort();
            return managers;
        }
        public ArrayList GetAgentTeamCollection(ContextRz x, String strCode, bool name)
        {
            String strType;
            String strName;
            n_team xTeam;
            NewMethod.n_user yUser;
            ArrayList colHold;
            colHold = new ArrayList();
            switch (strCode.ToLower().Trim())
            {
                case "<all>":
                case "":
                    foreach (DictionaryEntry d in x.xSys.Users.AllByName)
                    {
                        NewMethod.n_user u = (NewMethod.n_user)d.Value;
                        if (name)
                            colHold.Add(u.name);
                        else
                            colHold.Add(u.unique_id);
                    }
                    return colHold;
                case "<managers>":
                    ArrayList managers = ManagersList(x);
                    colHold = new ArrayList();
                    foreach (String s in managers)
                    {
                        colHold.Add(x.xSys.TranslateUserNameToID(s));
                    }
                    return colHold;
                case "<salespeople>":
                    ArrayList salespeople = SalespeopleListWithoutManagers(x);
                    colHold = new ArrayList();
                    foreach (String s in salespeople)
                    {
                        colHold.Add(x.xSys.TranslateUserNameToID(s));
                    }
                    return colHold;
                default:
                    strType = Tools.Strings.ParseDelimit(strCode, ":", 1).Trim();
                    strName = Tools.Strings.ParseDelimit(strCode, ":", 2).Trim();
                    switch (strType.Trim().ToLower())
                    {
                        case "agent":
                            yUser = NewMethod.n_user.GetByName(x, strName);
                            if (yUser == null)
                            {
                                x.TheLeader.Tell("The user '" + strName + "' could not be found in the system.");
                                return new ArrayList();
                            }
                            if (name)
                                colHold.Add(yUser.name);
                            else
                                colHold.Add(yUser.unique_id);
                            break;
                        case "team":
                            xTeam = n_team.GetByName(x, strName);
                            if (xTeam == null)
                            {
                                x.TheLeader.Tell("The team '" + strName + "' could not be found.");
                                return new ArrayList();
                            }
                            if (name)
                                return xTeam.GetUserNames(x);
                            else
                                return xTeam.GetUserIDs(x);
                        default:
                            return new ArrayList();
                    }
                    return colHold;
            }
        }
        public virtual String ReplaceAndStripPhoneNumber(String p)
        {
            return nTools.StripPhoneNumber(p);
        }
        public String ReplaceAndStripPhone(ContextRz context, String p)
        {
            String a = context.SelectScalarString("select realphone from alternatephone where phone = '" + nTools.StripPhoneNumber(p) + "'");
            if (Tools.Strings.StrExt(a))
                return nTools.StripPhoneNumber(a);
            context.SelectScalarString("select primaryphone from companycontact where alternatephone = '" + nTools.StripPhoneNumber(p) + "'");
            if (Tools.Strings.StrExt(a))
                return nTools.StripPhoneNumber(a);
            return nTools.StripPhoneNumber(p);
        }
        public void ShowInternalSearchReport(ContextRz context)
        {
            String strPart = context.TheLeader.AskForString("Please enter a whole or partial part number:", "", "Part Number");
            if (!Tools.Strings.StrExt(strPart))
                return;
            context.TheLeader.StartPopStatus();
            context.TheLeader.Comment("Searching...");
            DataTable d = context.Select("select searchdate, fullpartnumber, n_user.name from partsearch inner join n_user on n_user.unique_id = partsearch.base_mc_user_uid where fullpartnumber like '%" + context.Filter(strPart) + "%' order by searchdate desc");
            long l = 0;
            context.TheLeader.Comment("Exporting...");
            context.TheData.TheConnection.ExportCSV(d, Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "temp_report.csv", ref l);
            context.TheLeader.Comment("Opening...");
            Tools.Files.OpenFileInDefaultViewer(Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "temp_report.csv");
            context.TheLeader.StopPopStatus(false);
        }
        public virtual ArrayList GetAssistantHandlesForChat(ContextRz x)
        {
            return GetAssistantHandles(x);
        }
        public virtual ArrayList GetAssistantHandles(ContextRz x)
        {
            return new ArrayList();
        }
        public bool TriedAlternate = false;
        public bool AlternateWorks = false;
        public void ShowContactStatistics()
        {
            //long total = Rz3App.xSys.xData.GetScalar("select count(*) from companycontact");
            //long dupe = Rz3App.xSys.xData.GetScalar("select count(*) from companycontact where contactname like '% DUPE%'");
            //long consolidations = Rz3App.xSys.GetSetting_Long("consolidated_contacts");
            //String strHTML = "<table><tr><td>Total:</td><td
        }
        public virtual void EmailManagementReports(ContextRz context)
        {
        }
        public ArrayList GetStandardQuantityReplacements()
        {
            return GetStandardQuantityReplacements(1);
        }
        public ArrayList GetStandardQuantityReplacements(int factor)
        {
            ArrayList QuantityReplacements = new ArrayList();
            QuantityReplacements.Add(new QuantityReplacement(3 * factor, 1, 5));
            QuantityReplacements.Add(new QuantityReplacement(2.5 * factor, 5, 10));
            QuantityReplacements.Add(new QuantityReplacement(1.8 * factor, 10, 100));
            QuantityReplacements.Add(new QuantityReplacement(1.6 * factor, 100, 500));
            QuantityReplacements.Add(new QuantityReplacement(1.9 * factor, 500, 1000));
            QuantityReplacements.Add(new QuantityReplacement(1.5 * factor, 1000, 1500));
            QuantityReplacements.Add(new QuantityReplacement(1.8 * factor, 1500, 2500));
            QuantityReplacements.Add(new QuantityReplacement(1.38 * factor, 2500, 20000));
            QuantityReplacements.Add(new QuantityReplacement(1.23 * factor, 20000, 50000));
            QuantityReplacements.Add(new QuantityReplacement(1.17 * factor, 50000, 100000));
            return QuantityReplacements;
        }
        public void UnsubscribeAnAddress(ContextRz context, String strAddress)
        {
            UnsubscribeAnAddress(context, strAddress, context.TheData.TheConnection);
        }
        public void UnsubscribeAnAddress(ContextRz context, String strAddress, DataConnection d)
        {
            String strSQL = "insert into unsubscribe(emailaddress, unsubscribe_timestamp, domain) values ('" + d.SyntaxFilter(strAddress) + "', getdate(), '" + d.SyntaxFilter(nTools.ParseEmailDomain(strAddress)) + "') ";
            d.Execute(strSQL, true);
            context.TheLeader.Comment("New Unsubscribe: " + strAddress);
        }
        public void ResubscribeAnAddress(ContextRz context, String strAddress)
        {
            ResubscribeAnAddress(context, strAddress, context.TheData.TheConnection);
        }
        public void ResubscribeAnAddress(ContextRz context, String strAddress, DataConnection d)
        {
            String strSQL = "delete from unsubscribe where emailaddress = '" + d.SyntaxFilter(strAddress) + "'";
            d.Execute(strSQL, true);
            context.TheLeader.Comment("Resubscribe: " + strAddress);
        }
        public void RecalcAgentTotals(ContextRz context)
        {
            RecalcAgentTotals(context, MarketingConnection);
            if (MarketingConnection.ServerName != context.TheData.ServerName)
                RecalcAgentTotals(context, context.TheData.TheConnection);
        }
        public void RecalcAgentTotals(ContextRz context, DataConnection d)
        {
            String s = "";
            if (!d.ConnectPossible(ref s))
            {
                context.TheLeader.Comment("Recacl connect failed: " + s);
                return;
            }
            context.TheLeader.Comment("Recalculating agent assignment totals...");
            d.Execute("alter table n_user add calc_contact_count int", true);
            d.Execute("update n_user set calc_contact_count = ( select count(*) from companycontact where companycontact.base_mc_user_uid = n_user.unique_id )");
        }
        public bool CheckImportCubeOrderAndPartTables(ContextRz context, DataConnectionSqlServer live, DataConnectionSqlServer temp)
        {
            context.Reorg();
            return false;

            //if( DataConnectionSqlServer.IsDefinitlelySameDatabase(live, temp) )
            //    return true;
            //bool view = false;
            //if(live.ViewExists("ordhed"))
            //{
            //    temp.Execute("drop view ordhed", true);
            //    temp.Execute("drop view orddet", true);
            //    view = true;
            //}
            //String strOrderFields = "unique_id, base_dealheader_uid, ordernumber, orderdate, ordertype, base_company_uid, companyname, base_companycontact_uid, contactname, base_mc_user_uid, agentname, subtract_1, subtract_2, subtract_3, subtract1_caption, subtract2_caption, subtract3_caption, isvoid, isclosed, rma_data, is_authorized, onhold, primaryemailaddress, terms, shipvia, date_modified, shippingamount, handlingamount, taxamount";
            //String strOrderIndex = "unique_id";
            //String strDetailFields = "unique_id, base_dealheader_uid, base_dealdetail_uid, base_ordhed_uid, ordernumber, ordertype, base_company_uid, companyname, vendor_company_uid, vendorname, fullpartnumber, quantityordered, quantityfilled, unitprice, unitcost, stockid, linecode, original_stock_id, buytype, isvoid, datecode, manufacturer, date_modified, orderdate, base_mc_user_uid";
            //String strDetailIndex = "unique_id";
            //BringCompletelyIn(context, live, temp, "ordlnk");
            //BringCompletelyIn(context, live, temp, "dealheader");
            //BringCompletelyIn(context, live, temp, "dealdetail");
            //DateTime dCutoff = nCube.CutoffDate;
            //BringCompletelyIn(context, live, temp, "ordhed_service", strOrderFields + ", apply_ordhed_invoice_uid", strOrderIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "ordhed_sales", strOrderFields, strOrderIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "ordhed_invoice", strOrderFields, strOrderIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "ordhed_purchase", strOrderFields, strOrderIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "ordhed_rma", strOrderFields, strOrderIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "ordhed_vendrma", strOrderFields, strOrderIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "ordhed_quote", strOrderFields, strOrderIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "ordhed_rfq", strOrderFields, strOrderIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "orddet_service", strDetailFields + ", is_service", strDetailIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "orddet_sales", strDetailFields, strDetailIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "orddet_invoice", strDetailFields, strDetailIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "orddet_purchase", strDetailFields, strDetailIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "orddet_rma", strDetailFields, strDetailIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "orddet_vendrma", strDetailFields, strDetailIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "orddet_quote", strDetailFields + ", target_quantity", strDetailIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "orddet_rfq", strDetailFields + ", target_quantity", strDetailIndex, "orderdate", dCutoff);
            //BringCompletelyIn(context, live, temp, "partrecord", "fullpartnumber, unique_id, stocktype, original_stocktype, quantity", "unique_id, stocktype", "", Tools.Dates.GetNullDate());
            //BringCompletelyIn(context, live, temp, "domain", "domain_name, always_dist, always_oem, always_exclude");
            //BringCompletelyIn(context, live, temp, "req", "base_mc_user_uid, companyname, datecreated, fullpartnumber, targetquantity", "", "datecreated", dCutoff);
            //BringCompletelyIn(context, live, temp, "quote", "base_mc_user_uid, companyname, quotetype, quotedate, fullpartnumber, quotequantity", "", "quotedate", dCutoff);
            //if(view)
            //{
            //    String strSQL = "create view ordhed as ";
            //    strSQL += "select " + strOrderFields + " from ordhed_service";
            //    strSQL += " union all ";
            //    strSQL += "select " + strOrderFields + " from ordhed_sales";
            //    strSQL += " union all ";
            //    strSQL += "select " + strOrderFields + " from ordhed_purchase";
            //    strSQL += " union all ";
            //    strSQL += "select " + strOrderFields + " from ordhed_invoice";
            //    strSQL += " union all ";
            //    strSQL += "select " + strOrderFields + " from ordhed_rma";
            //    strSQL += " union all ";
            //    strSQL += "select " + strOrderFields + " from ordhed_vendrma";
            //    strSQL += " union all ";
            //    strSQL += "select " + strOrderFields + " from ordhed_quote";
            //    strSQL += " union all ";
            //    strSQL += "select " + strOrderFields + " from ordhed_rfq";
            //    temp.Execute(strSQL);
            //    strSQL = "create view orddet as ";
            //    strSQL += "select " + strDetailFields + " from orddet_service";
            //    strSQL += " union all ";
            //    strSQL += "select " + strDetailFields + " from orddet_sales";
            //    strSQL += " union all ";
            //    strSQL += "select " + strDetailFields + " from orddet_purchase";
            //    strSQL += " union all ";
            //    strSQL += "select " + strDetailFields + " from orddet_invoice";
            //    strSQL += " union all ";
            //    strSQL += "select " + strDetailFields + " from orddet_rma";
            //    strSQL += " union all ";
            //    strSQL += "select " + strDetailFields + " from orddet_vendrma";
            //    strSQL += " union all ";
            //    strSQL += "select " + strDetailFields + " from orddet_quote";
            //    strSQL += " union all ";
            //    strSQL += "select " + strDetailFields + " from orddet_rma";
            //    temp.Execute(strSQL);
            //}
            //return true;
        }
        public void BringCompletelyIn(ContextRz context, DataConnectionSqlServer from, DataConnectionSqlServer to, String strTable)
        {
            BringCompletelyIn(context, from, to, strTable, "", "", "", Tools.Dates.GetNullDate());
        }
        public void BringCompletelyIn(ContextRz context, DataConnectionSqlServer from, DataConnectionSqlServer to, String strTable, String strFields)
        {
            BringCompletelyIn(context, from, to, strTable, strFields, "", "", Tools.Dates.GetNullDate());
        }
        public void BringCompletelyIn(ContextRz context, DataConnectionSqlServer from, DataConnectionSqlServer to, String strTable, String strFields, String strIndex, String strDateField, DateTime dCutoff)
        {
            context.TheLeader.Comment("Bringing in " + strTable + "...");
            String strFromServer = from.DatabaseName;
            if (!Tools.Strings.StrCmp(from.ServerName, to.ServerName))
            {
                if (!to.LinkSQLServer(from))
                    throw new Exception("Failed to link server");

                strFromServer = from.ServerName + "." + from.DatabaseName;
            }
            if (to.TableExists(strTable))
                to.RenameTable(strTable, "temp_removed_" + strTable + "_" + nTools.GetDateTimeString());
            if (!Tools.Strings.StrExt(strFields))
                strFields = "*";
            String strSQL = "select " + strFields + " into " + strTable + " from " + strFromServer + ".dbo." + strTable;
            if (Tools.Strings.StrExt(strDateField) && Tools.Dates.DateExists(dCutoff))
                strSQL += " where " + strDateField + " >= cast('" + nTools.DateFormat(dCutoff) + " 12:00:00 am' as datetime) ";
            String ex = "";

            to.Execute(strSQL);

            //index it
            if (Tools.Strings.StrExt(strIndex))
                to.Execute("create index initial_cube_index on " + strTable + " ( " + strIndex + " ) ");
        }
        public virtual void UpdateContactStats(ContextRz context, NewMethod.n_user u, String strCompany, String strContact, String strPhone, String strEmail, String strPartsIn, String strActions)
        {
        }
        public DateTime GetEarliestOrderChange(DataConnection data, DateTime dCutoff)
        {
            ArrayList a = new ArrayList();
            a.Add(data.ScalarDateTime("select min(orderdate) from ordhed_purchase where date_modified >= cast('" + nTools.DateFormat(dCutoff) + " 12:00:00am' as datetime)"));
            a.Add(data.ScalarDateTime("select min(orderdate) from ordhed_invoice where date_modified >= cast('" + nTools.DateFormat(dCutoff) + " 12:00:00am' as datetime)"));
            a.Add(data.ScalarDateTime("select min(orderdate) from ordhed_rma where date_modified >= cast('" + nTools.DateFormat(dCutoff) + " 12:00:00am' as datetime)"));
            a.Add(data.ScalarDateTime("select min(orderdate) from orddet_purchase where date_modified >= cast('" + nTools.DateFormat(dCutoff) + " 12:00:00am' as datetime)"));
            a.Add(data.ScalarDateTime("select min(orderdate) from orddet_invoice where date_modified >= cast('" + nTools.DateFormat(dCutoff) + " 12:00:00am' as datetime)"));
            a.Add(data.ScalarDateTime("select min(orderdate) from orddet_rma where date_modified >= cast('" + nTools.DateFormat(dCutoff) + " 12:00:00am' as datetime)"));
            a.Sort();
            DateTime d = (DateTime)a[0];
            if (Tools.Dates.DateExists(d))
                return d;
            else
                return dCutoff;
        }
        public String FilterContactName(String s)
        {
            if (s.ToLower().EndsWith(" gone") || s.ToLower().EndsWith("-gone") || s.ToLower().EndsWith(" dupe") || s.ToLower().EndsWith("-dupe"))
                return Tools.Strings.Left(s, s.Length - 5).Trim();
            else
                return s;
        }
        public ArrayList GetCapLengths()
        {
            ArrayList a = new ArrayList();
            a.Add("54: 2 1/8 : 2C : A");
            a.Add("79.4 : 3 1/8 : 3C : B");
            a.Add("105 : 4 1/8 : 4C : C");
            a.Add("117.52 : 4 5/8 : 4L : D");
            a.Add("130 : 5 1/8 : 5C : E");
            a.Add("143 : 5 5/8 : 5L : F");
            a.Add("149 : G");
            a.Add("168 : H");
            a.Add("194 : I");
            a.Add("219 : 8 5/8 : 8L : J");
            a.Add("92 : 3 5/8 : K/L");
            a.Add("67 : 2 5/8 : 2L : M");
            a.Add("79 : 1 5/8 : 1.625 : N");
            return a;
        }
        public ArrayList GetCapDiameters()
        {
            ArrayList a = new ArrayList();
            a.Add("35 : 1 3/8 : 1.375 : A");
            a.Add("51 : 2 : B");
            a.Add("63.5 : 2 1/2 : 2.50 : C");
            a.Add("45 : 1 3/4 : 1.75 : E");
            a.Add("76.2 : 3 : D");
            a.Add("89 : 3 1/2 : 3.5");
            return a;
        }
        public virtual void HandleLineCardRequest(ArrayList contacts)
        {
        }
        public virtual void ShowDailyStats(ContextRz context, bool yesterday) { }
        public virtual bool EmailDailyStats(ContextRz context, bool yesterday) { return false; }
        public virtual String GetTodaysPhoneReport(ContextRz context, bool only_salespeople_divided) { return ""; }
        public virtual partrecord ChoosePart(String strPartNumber)
        {

            //this needs to be re-done
            return null;

            //frmPartSearch xForm = new frmPartSearch();
            //xForm.GetPartSearch().SelectMode = true;
            //xForm.GetPartSearch().CompleteLoad();
            //xForm.GetPartSearch().SetPartNumber(strPartNumber);
            //xForm.Width = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width *.9);
            //xForm.Height = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height * .9);
            //xForm.StartPosition = FormStartPosition.CenterScreen;
            //xForm.DoResize();
            //xForm.Show();
            //xForm.DoResize();
            //xForm.Hide();
            //xForm.ShowDialog(owner);

            //partrecord ret = null;
            //try
            //{
            //    ret = (partrecord)xForm.GetPartSearch().SelectedObject;
            //}
            //catch { }

            //try
            //{
            //    xForm.Close();
            //    xForm.Dispose();
            //    xForm = null;
            //}
            //catch { }
            //return ret;
        }
        public virtual bool EmailRecentQuotes(ContextRz context)
        {
            return false;
        }
        public virtual void IgnoreByEmail(ContextRz context, String strFragment)
        {
            context.TheLeader.Tell("Need to override IgnoreByEmail");
        }
        public virtual void SendRz4CheckIn(ContextRz context)
        {
            //string post = "?user_id=" + context.xUser.unique_id + "&user_name=" + context.xUser.name + "&machine_name=" + Environment.MachineName + "&company_identifier=" + n_set.GetSetting(context, "company_identifier");
            //BrowserPlain b = new BrowserPlain();
            //b.Navigate("http://portal.recognin.com:8086/Rz4CheckIn.aspx" + post);
        }
        public bool IsCustomerEmail(ContextRz context, String s)
        {
            if (!Tools.Strings.StrExt(s))
                return false;

            return context.SelectScalarInt64("select count(*) from ordhed_invoice where primaryemailaddress = '" + context.Filter(s) + "' and isnull(isvoid, 0) = 0") > 0;
        }
        public bool IsProspectEmail(ContextRz context, String s)
        {
            if (!Tools.Strings.StrExt(s))
                return false;

            return context.SelectScalarInt64("select count(*) from ordhed_quote where primaryemailaddress = '" + context.Filter(s) + "' and isnull(isvoid, 0) = 0") > 0;
        }
        public bool IsUserAssistantOf(ContextRz x, String strUserID)
        {
            foreach (AssistantHandle h in GetAssistantHandles(x))
            {
                if (h.AssistantUser.unique_id == x.xUser.unique_id && h.ManagerUser.unique_id == strUserID)
                    return true;
            }
            return false;
        }
        public ArrayList GetUserAssistantsAndManager(ContextRz x, String strID)
        {
            ArrayList userids = new ArrayList();
            userids.Add(strID);
            foreach (AssistantHandle h in x.Logic.GetAssistantHandles(x))
            {
                if (h.AssistantUser.unique_id == strID)
                    userids.Add(h.ManagerUser.unique_id);
                else if (h.ManagerUser.unique_id == strID)
                    userids.Add(h.AssistantUser.unique_id);
            }
            return userids;
        }
        public ArrayList GetNotifyEmailList(ContextRz x, NewMethod.n_user yUser)
        {
            ArrayList ret = new ArrayList();

            if (Tools.Strings.StrExt(yUser.email_address))
            {
                ret.Add(yUser.email_address.ToLower());
            }

            foreach (AssistantHandle h in GetAssistantHandles(x))
            {
                if (h.AssistantUser.unique_id == yUser.unique_id)
                {
                    if (Tools.Strings.StrExt(h.ManagerUser.email_address))
                        ret.Add(h.ManagerUser.email_address.ToLower());
                }
            }
            return ret;
        }
        public void ChangeUserName(ContextRz context)
        {
            NewMethod.n_user u = context.TheLeaderRz.AskForUser(null, false);
            if (u == null)
                return;

            String strName = context.TheLeader.AskForString("New Name", u.name, "New Name");
            if (!Tools.Strings.StrExt(strName))
                return;

            if (Tools.Strings.StrCmp(strName, u.Name))
                return;

            NewMethod.n_user x = (NewMethod.n_user)context.xSys.Users.GetByName(strName);
            if (x != null)
            {
                context.TheLeader.Tell("The name '" + strName + "' already exists as a user.");
                return;
            }

            ChangeUserName(context, u, strName);
        }
        protected virtual ArrayList GetChangeUserNameFields()
        {
            ArrayList fields = new ArrayList();

            ArrayList ordertypes = ordhed.OrderTypesStringArray;
            foreach (String t in ordertypes)
            {
                fields.Add("ordhed_" + t + ".agentname");
                fields.Add("ordhed_" + t + ".buyername");
                fields.Add("orddet_" + t + ".agentname");
                fields.Add("orddet_" + t + ".buyername");
            }

            fields.Add("agent_ordhed.agent_name");
            fields.Add("batchquote.agentname");
            fields.Add("calllog.agentname");
            fields.Add("chat_message.recipient");
            fields.Add("chat_message.sender");
            fields.Add("company.agentname");
            fields.Add("companycontact.agentname");
            fields.Add("contactnote.agentname");
            fields.Add("phonecall.username");
            fields.Add("quote.agentname");
            fields.Add("quote.buyername");
            fields.Add("req.agentname");
            fields.Add("reqbatch.agentname");
            fields.Add("usernote.createdbyname");
            fields.Add("usernote.createdforname");
            return fields;
        }
        public void ChangeUserName(ContextRz context, NewMethod.n_user u, String strName)
        {
            if (!context.TheLeader.AreYouSure("change " + u.name + "'s name to '" + strName + "'"))
                return;
            context.TheLeader.StartPopStatus("Changing the name...");
            ArrayList fields = GetChangeUserNameFields();
            foreach (String s in fields)
            {
                String strTable = Tools.Strings.ParseDelimit(s, ".", 1);
                String strField = Tools.Strings.ParseDelimit(s, ".", 2);
                context.TheLeader.Comment("Updating " + s + "...");
                context.Execute("update " + strTable + " set " + strField + " = '" + context.Filter(strName) + "' where " + strField + " = '" + context.Filter(u.name) + "'");
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
            }
            u.name = strName;
            context.Update(u);
            context.TheLeader.Comment("Done.");
            context.TheLeader.StopPopStatus(true);
        }
        public virtual void LogWebQuote(ContextRz context, String strPart, String strLink)
        {

        }
        public virtual bool DoCrucialBackup(ContextRz context, DataConnectionSqlServer d, String strBackupFile)
        {
            String strDatabase = d.DatabaseName + "_temp_crucial_backup";
            if (d.DatabaseExists(strDatabase))
            {
                context.TheLeader.Error(strDatabase + " already exists.");
                return false;
            }

            String s = strBackupFile;
            ArrayList a = new ArrayList();
            CrucialBackupTablesList(a);

            String err = "";
            if (!d.BackupTableList_Tables(a, strDatabase, ref err, CrucialBackupDataPath))
            {
                context.TheLeader.Error("Backup error: " + err);
                return false;
            }

            DataConnectionSqlServer dnew = new DataConnectionSqlServer(d.ServerName, strDatabase, d.TheKey.UserName, d.TheKey.UserPassword);
            ordhed.CreateOrderViews(context, dnew);

            if (!d.BackupTableList_Database(ref s, strDatabase, ref err))
            {
                context.TheLeader.Error("BackupTableList_Database error " + err);
                return false;
            }

            return true;
        }
        public virtual void CrucialBackupTablesList(ArrayList a)
        {
            a.Add("n_user");
            a.Add("n_team");
            a.Add("n_member");
            a.Add("n_template");
            a.Add("n_column");
            a.Add("n_set");
            a.Add("n_choice");
            a.Add("n_choices");
            a.Add("mfg_link");
            a.Add("partrecord");
            a.Add("n_permit");

            a.Add("ordhed_rfq");
            a.Add("ordhed_service");
            a.Add("ordhed_quote");
            a.Add("ordhed_sales");
            a.Add("ordhed_purchase");
            a.Add("ordhed_invoice");
            a.Add("ordhed_rma");
            a.Add("ordhed_vendrma");

            a.Add("orddet_line");

            a.Add("orddet_rfq");
            a.Add("orddet_quote");

            //a.Add("orddet_service_bak_reorg");
            //a.Add("orddet_sales_bak_reorg");
            //a.Add("orddet_purchase_bak_reorg");
            //a.Add("orddet_invoice_bak_reorg");
            //a.Add("orddet_rma_bak_reorg");
            //a.Add("orddet_vendrma_bak_reorg");

            a.Add("ordlnk");
            a.Add("req");
            a.Add("reqbatch");
            a.Add("quote");
            a.Add("company");
            a.Add("companycontact");
            a.Add("companyaddress");
            a.Add("contactnote");
            a.Add("avail_folder");
            a.Add("printheader");
            a.Add("printdetail");
            a.Add("phonecall");
            a.Add("dealheader");
            a.Add("dealdetail");
            a.Add("dealpart");
            a.Add("dealcompany");
            a.Add("marketing_batch");
            a.Add("checkpayment");
            a.Add("emailtemplate");
            a.Add("blast_emailtemplate");
            a.Add("n_data_target");
            a.Add("mc_duty");
            a.Add("pack");
            a.Add("account");
            a.Add("journal");
            a.Add("currency");
        }
        public virtual String CrucialBackupDataPath
        {
            get
            {
                return @"c:\";
            }
        }
        public ArrayList InvisibleCompanies = new ArrayList();
        public String CheckAppendInvisibleCompanies(ContextRz context, String strWhere, String strTablePrefix)
        {
            if (context.xUser == null)
                return strWhere;

            if (context.xUser.SuperUser || InvisibleCompanies.Count == 0)
                return strWhere;

            StringBuilder ret = new StringBuilder(strWhere);
            if (Tools.Strings.StrExt(strWhere))
                ret.Append(" and ");

            ret.Append(" ( ");

            int i = 0;
            String strPrefix = "";
            if (Tools.Strings.StrExt(strTablePrefix))
                strPrefix = strTablePrefix + ".";
            foreach (String s in InvisibleCompanies)
            {
                if (i > 0)
                    ret.Append(" and ");
                ret.Append(" " + strPrefix + "companyname not like '" + s + "' ");
                i++;
            }

            ret.Append(" ) ");
            return ret.ToString();
        }

        public DataConnectionSqlServer MarketingConnection;
        //public DataConnectionSqlServer PictureData;

        public DataConnectionSqlMy PictureData;
        //KT - Added this 
        //public DataConnectionSqlServer PictureData2;

        public virtual void SendMultipleQuotes(ContextRz context, List<orddet> objects)
        {

        }
        public virtual String AvailCriteriaAppend(String s)
        {
            return s;
        }
        public virtual String TemplateSecure(ContextNM x, String class_name, String template_name)
        {
            return template_name;
        }
        public virtual ListArgs SalesSearchArgsGet(ContextRz x, SearchComparison compare, PartSearchParameters pars)
        {
            ListArgs ret = x.TheSysRz.TheLineLogic.OrdLineSearchArgsGet(x, compare, new Enums.OrderType[] { Enums.OrderType.Sales, Enums.OrderType.Invoice }, pars);
            ret.TheTemplate = TemplateSecure(x, "orddet_line", "SALESSEARCHnew");
            return ret;
        }
        public virtual ListArgs PurchaseSearchArgsGet(ContextRz x, SearchComparison compare, PartSearchParameters pars)
        {
            ListArgs ret = x.TheSysRz.TheLineLogic.OrdLineSearchArgsGet(x, compare, new Enums.OrderType[] { Enums.OrderType.Purchase }, pars);
            ret.TheTemplate = TemplateSecure(x, "orddet_line", "BUYSEARCHnew");
            return ret;
        }
        public virtual ListArgs RMASearchArgsGet(ContextRz x, Enums.PartSearchType SearchType, SearchComparison compare, PartSearchParameters pars)
        {
            ListArgs ret = null;
            switch (SearchType)
            {
                case Enums.PartSearchType.VendRMA:
                    ret = x.TheSysRz.TheLineLogic.OrdLineSearchArgsGet(x, compare, new Enums.OrderType[] { Enums.OrderType.VendRMA }, pars);
                    ret.TheTemplate = TemplateSecure(x, "orddet_line", "vendrmasearchnew");
                    break;
                default:
                    ret = x.TheSysRz.TheLineLogic.OrdLineSearchArgsGet(x, compare, new Enums.OrderType[] { Enums.OrderType.RMA }, pars);
                    ret.TheTemplate = TemplateSecure(x, "orddet_line", "rmasearchnew");
                    break;
            }
            return ret;
        }
        public virtual ListArgs AttachmentSearchArgsGet(ContextRz x, SearchComparison compare, String strPart)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTemplate = "partpictures_partsearchscreen";
            ret.TheClass = "partpicture";
            ret.TheTable = "partpicture";
            ret.TheConnection = this.PictureData;
            ret.AddAllow = false;
            if (strPart == "")
                ret.HeaderOnly = true;
            strPart = PartObject.StripPart(strPart);
            if (!Tools.Strings.StrExt(strPart))
                strPart = "BLANK PART NUMBER";

            ArrayList a = PartObject.GetSearchPermutations(x, strPart, compare, false, false, false, false, false);
            String strBuild = "";
            if (a.Count > 0)
                strBuild = PartObject.BuildWhere(a);
            ret.TheWhere = strBuild;

            //Order By
            ret.TheOrder = "date_created desc";

            //ret.TheWhere = " part_stripped like '" + x.context.Filter(strPart) + "%' ";
            ret.TheCaption = "Attachments";
            return ret;
        }
        public virtual ListArgs HomeScreenSearchArgsGet(ContextNM x, HomeScreenOption option)
        {
            return HomeScreenSearchArgsGet(x, option, null);
        }
        public virtual ListArgs HomeScreenSearchArgsGet(ContextNM x, HomeScreenOption option, HomePanelSearchArgs args)
        {
            ListArgs ret = new ListArgs(x);
            long lngLimit = 200;
            if (option.UnlimitedResults)
            {
                lngLimit = -1;
                if (string.IsNullOrEmpty(option.DateRange))
                {
                    if (!x.Leader.AreYouSure(" show \"unlimited\" results?  No date range is set, which can return a large amount of records and cause Rz to become unsresponsive as it processes the dataset."))
                    {
                        x.Leader.Tell("Showing only the top 200 results.  It is recommended you set a date range when querying for large amounts of records.");
                        lngLimit = 200;
                    }
                }               
            }            
            option.Limit = lngLimit;
            String where = "";
            if (option.All)
                where = " " + option.WhereNoUsers + " ";
            else
                where = nTools.Replace(option.Where, "<userids>", option.SelectedIDs);
            if (Tools.Strings.StrExt(option.DateRange))
            {
                if (!Tools.Strings.StrExt(where))
                    where = option.DateRange;
                else
                    where += " and " + option.DateRange;
            }
            //if (((RzLogic)x.TheLogic).IsAAT && option.NSNView)
            //{
            //    if (Tools.Strings.StrExt(option.NSNSearch))
            //    {
            //        if (!Tools.Strings.StrExt(where))
            //            where = option.NSNSearch;
            //        else
            //            where += " and " + option.NSNSearch;
            //        if (Tools.Strings.StrCmp(option.ClassName, "req"))
            //            option.OrderField = "alternatepart";
            //    }
            //}

            if (args != null)
                where += option.SearchGet(x, args);

            //if (Tools.Strings.StrExt(search_term))
            //    where = where.Replace("<searchterm>", "'" + x.context.Filter(search_term) + "'");
            //else


            ret.TheWhere = where;
            ret.TheCaption = option.Caption;
            ret.TheOrder = option.OrderField;

            return ret;
        }
        public virtual PartCrossReferenceResults GetNewPartCrossRecerenceResultClass(ContextNM x)
        {
            return new PartCrossReferenceResults(x);
        }
        public virtual PartCrossReferenceResults PartCrossReferenceArgsGet(ContextNM x, PartCrossReferenceSearchOptions option)
        {
            if (option == null)
                return null;
            if (!Tools.Strings.StrExt(option.SQL_PartField))
                return null;
            if (!Tools.Strings.StrExt(option.SQL_Table))
                return null;
            PartCrossReferenceResults p = GetNewPartCrossRecerenceResultClass(x);
            if (option.search_Bid)
            {
                p.results_Bid = new ListArgs(x);
                p.results_Bid.TheWhere = "orddet_rfq.prefix + orddet_rfq.basenumberstripped in (" + option.SQL_String + ")";
                p.results_Bid.TheOrder = "orddet_rfq.orderdate desc";
                p.results_Bid.TheTable = "orddet_rfq";
                p.results_Bid.TheTemplate = "PartCrossReferenceResults_orddet_rfq";
                p.results_Bid.TheClass = "orddet_rfq";
            }
            if (option.search_Consign)
            {
                p.results_Consign = new ListArgs(x);
                p.results_Consign.TheWhere = "partrecord.stocktype = 'consign' and partrecord.prefix + partrecord.basenumberstripped in (" + option.SQL_String + ")";
                p.results_Consign.TheOrder = "partrecord.date_created desc";
                p.results_Consign.TheTable = "partrecord";
                p.results_Consign.TheTemplate = "PartCrossReferenceResults_partrecord_consign";
                p.results_Consign.TheClass = "partrecord";
            }
            if (option.search_Excess)
            {
                p.results_Excess = new ListArgs(x);
                p.results_Excess.TheWhere = "partrecord.stocktype = 'excess' and partrecord.prefix + partrecord.basenumberstripped in (" + option.SQL_String + ")";
                p.results_Excess.TheOrder = "partrecord.date_created desc";
                p.results_Excess.TheTable = "partrecord";
                p.results_Excess.TheTemplate = "PartCrossReferenceResults_partrecord_excess";
                p.results_Excess.TheClass = "partrecord";
            }
            //KT
            if (option.search_Master)
            {
                p.results_Master = new ListArgs(x);
                p.results_Master.TheWhere = "partrecord.stocktype = 'master' and partrecord.prefix + partrecord.basenumberstripped in (" + option.SQL_String + ")";
                p.results_Master.TheOrder = "partrecord.date_created desc";
                p.results_Master.TheTable = "partrecord";
                p.results_Master.TheTemplate = "PartCrossReferenceResults_partrecord_master";
                p.results_Master.TheClass = "partrecord";
            }



            if (option.search_Invoice)
            {
                p.results_Invoice = new ListArgs(x);
                p.results_Invoice.TheWhere = "orddet_line.prefix + orddet_line.basenumberstripped in (" + option.SQL_String + ") and len(isnull(orderid_invoice,'')) > 0";
                p.results_Invoice.TheOrder = "orddet_line.orderdate_invoice desc";
                p.results_Invoice.TheTable = "orddet_line";
                p.results_Invoice.TheTemplate = "PartCrossReferenceResults_orddet_invoice_line";
                p.results_Invoice.TheClass = "orddet_line";
            }
            if (option.search_Purchase)
            {
                p.results_Purchase = new ListArgs(x);
                p.results_Purchase.TheWhere = "orddet_line.prefix + orddet_line.basenumberstripped in (" + option.SQL_String + ") and len(isnull(orderid_purchase,'')) > 0";
                p.results_Purchase.TheOrder = "orddet_line.orderdate_purchase desc";
                p.results_Purchase.TheTable = "orddet_line";
                p.results_Purchase.TheTemplate = "PartCrossReferenceResults_orddet_purchase_line";
                p.results_Purchase.TheClass = "orddet_line";
            }
            if (option.search_Quote)
            {
                p.results_Quote = new ListArgs(x);
                p.results_Quote.TheWhere = "isnull(orddet_quote.unitprice,0)> 0 and isnull(orddet_quote.quantityordered,0)> 0 and orddet_quote.prefix + orddet_quote.basenumberstripped in (" + option.SQL_String + ")";
                p.results_Quote.TheOrder = "orddet_quote.orderdate desc";
                p.results_Quote.TheTable = "orddet_quote";
                p.results_Quote.TheTemplate = "PartCrossReferenceResults_orddet_quote";
                p.results_Quote.TheClass = "orddet_quote";
            }
            if (option.search_Req)
            {
                p.results_Req = new ListArgs(x);
                p.results_Req.TheWhere = "(isnull(orddet_quote.unitprice,0)<= 0 or isnull(orddet_quote.quantityordered,0)<= 0) and orddet_quote.prefix + orddet_quote.basenumberstripped in (" + option.SQL_String + ")";
                p.results_Req.TheOrder = "orddet_quote.orderdate desc";
                p.results_Req.TheTable = "orddet_quote";
                p.results_Req.TheTemplate = "PartCrossReferenceResults_orddet_req";
                p.results_Req.TheClass = "orddet_quote";
            }
            if (option.search_RMA)
            {
                p.results_RMA = new ListArgs(x);
                p.results_RMA.TheWhere = "orddet_line.prefix + orddet_line.basenumberstripped in (" + option.SQL_String + ") and len(isnull(orderid_rma,'')) > 0";
                p.results_RMA.TheOrder = "orddet_line.orderdate_rma desc";
                p.results_RMA.TheTable = "orddet_line";
                p.results_RMA.TheTemplate = "PartCrossReferenceResults_orddet_rma_line";
                p.results_RMA.TheClass = "orddet_line";
            }
            if (option.search_Sales)
            {
                p.results_Sales = new ListArgs(x);
                p.results_Sales.TheWhere = "orddet_line.prefix + orddet_line.basenumberstripped in (" + option.SQL_String + ") and len(isnull(orderid_sales,'')) > 0";
                p.results_Sales.TheOrder = "orddet_line.orderdate_invoice desc";
                p.results_Sales.TheTable = "orddet_line";
                p.results_Sales.TheTemplate = "PartCrossReferenceResults_orddet_sales_line";
                p.results_Sales.TheClass = "orddet_line";
            }
            if (option.search_Service)
            {
                p.results_Service = new ListArgs(x);
                p.results_Service.TheWhere = "orddet_line.prefix + orddet_line.basenumberstripped in (" + option.SQL_String + ") and len(isnull(orderid_service,'')) > 0";
                p.results_Service.TheOrder = "orddet_line.orderdate_service desc";
                p.results_Service.TheTable = "orddet_line";
                p.results_Service.TheTemplate = "PartCrossReferenceResults_orddet_service_line";
                p.results_Service.TheClass = "orddet_line";
            }
            if (option.search_Stock)
            {
                p.results_Stock = new ListArgs(x);
                p.results_Stock.TheWhere = "partrecord.stocktype = 'stock' and partrecord.prefix + partrecord.basenumberstripped in (" + option.SQL_String + ")";
                p.results_Stock.TheOrder = "partrecord.date_created desc";
                p.results_Stock.TheTable = "partrecord";
                p.results_Stock.TheTemplate = "PartCrossReferenceResults_partrecord_stock";
                p.results_Stock.TheClass = "partrecord";
            }
            if (option.search_vRMA)
            {
                p.results_vRMA = new ListArgs(x);
                p.results_vRMA.TheWhere = "orddet_line.prefix + orddet_line.basenumberstripped in (" + option.SQL_String + ") and len(isnull(orderid_vendrma,'')) > 0";
                p.results_vRMA.TheOrder = "orddet_line.orderdate_vendrma desc";
                p.results_vRMA.TheTable = "orddet_line";
                p.results_vRMA.TheTemplate = "PartCrossReferenceResults_orddet_vendrma_line";
                p.results_vRMA.TheClass = "orddet_line";
            }

            //KT Refactored from RzSensible
            if (option.search_LowestSalesPrice)
                LowestSalesPriceCalc(x, p, option);
            if (option.search_AvgSalesPrice)
                AvgSalesPriceCalc(x, p, option);
            if (option.search_LowestPurchasePrice)
                LowestPurchasePriceCalc(x, p, option);
            if (option.search_AvgPurchasePrice)
                AvgPurchasePriceCalc(x, p, option);
            return p;

        }

        //KT The Below Methods were refactored from RzSensible
        private void LowestSalesPriceCalc(ContextNM x, PartCrossReferenceResults p, PartCrossReferenceSearchOptions option)
        {
            ListArgs args;
            ((PartCrossReferenceResults)p).results_LowestSalesPrice = new ListArgs(x);
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs = new ArrayList();
            string table = "temp_" + Tools.Strings.GetNewID() + "_table";
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "select partrecord.unique_id, partrecord.prefix + partrecord.basenumberstripped as partrecord_part, price as partrecord_price into " + table + " from partrecord where partrecord.importid = '" + nData.SyntaxFilterGeneral(option.SQL_KeyFieldValue) + "'";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add lowest_sales_price float";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add lowest_sales_price_perc_diff float";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add temp_hold float";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set lowest_sales_price = (select isnull(min(orddet_line.unitprice),0) from orddet_line where len(isnull(orddet_line.orderid_sales,'')) > 0 and orddet_line.prefix + orddet_line.basenumberstripped =  " + table + ".partrecord_part)";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set temp_hold = (lowest_sales_price-partrecord_price)";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set temp_hold = 0 where temp_hold < 0";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set lowest_sales_price_perc_diff =(temp_hold / lowest_sales_price)*100  where temp_hold > 0";  //switched this around
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set lowest_sales_price_perc_diff = 0 where isnull(lowest_sales_price_perc_diff,0) <= 0";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "delete from " + table + " where lowest_sales_price_perc_diff <=0";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " drop column temp_hold";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.PrepareArgs.Add(args);
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.TheWhere = "partrecord.unique_id in (select " + table + ".unique_id from " + table + " where " + table + ".lowest_sales_price_perc_diff " + option.search_LowestSalesPriceComparison + " " + option.search_LowestSalesPricePercent.ToString() + ")";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.TheOrder = "partrecord.date_created desc";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.TheTable = "partrecord";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.TheTemplate = "PartCrossReferenceResults_LowestSalesPrice";
            ((PartCrossReferenceResults)p).results_LowestSalesPrice.TheClass = "partrecord";
        }
        private void AvgSalesPriceCalc(ContextNM x, PartCrossReferenceResults p, PartCrossReferenceSearchOptions option)
        {
            ListArgs args;
            ((PartCrossReferenceResults)p).results_AvgSalesPrice = new ListArgs(x);
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs = new ArrayList();
            string table = "temp_" + Tools.Strings.GetNewID() + "_table";
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "select partrecord.unique_id, partrecord.prefix + partrecord.basenumberstripped as partrecord_part, price as partrecord_price into " + table + " from partrecord where partrecord.importid = '" + nData.SyntaxFilterGeneral(option.SQL_KeyFieldValue) + "'";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add avg_sales_price float";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add avg_sales_price_perc_diff float";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add temp_hold float";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add temp_count int";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set temp_count = (select count(*) from ordet_line where len(isnull(orddet_line.orderid_sales,'')) > 0 and orddet_line.prefix + orddet_line.basenumberstripped =  " + table + ".partrecord_part and isnull(orddet_line.unitprice,0) > 0)";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "delete from " + table + " where isnull(temp_count,0) <=0";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set temp_hold = (select sum(orddet_line.unitprice) from orddet_line where len(isnull(orddet_line.orderid_sales,'')) > 0 and orddet_line.prefix + orddet_line.basenumberstripped =  " + table + ".partrecord_part and isnull(orddet_line.unitprice,0) > 0)";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set avg_sales_price = (temp_hold/temp_count) where temp_count > 0";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set avg_sales_price = 0 where isnull(avg_sales_price,0) <= 0";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set avg_sales_price_perc_diff =(partrecord_price/avg_sales_price)*100  where avg_sales_price > 0";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " drop column temp_hold";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " drop column temp_count";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.PrepareArgs.Add(args);
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.TheWhere = "partrecord.unique_id in (select " + table + ".unique_id from " + table + " where " + table + ".avg_sales_price_perc_diff " + option.search_AvgSalesPriceComparison + " " + option.search_AvgSalesPricePercent.ToString() + ")";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.TheOrder = "partrecord.date_created desc";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.TheTable = "partrecord";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.TheTemplate = "PartCrossReferenceResults_AvgSalesPrice";
            ((PartCrossReferenceResults)p).results_AvgSalesPrice.TheClass = "partrecord";
        }
        private void LowestPurchasePriceCalc(ContextNM x, PartCrossReferenceResults p, PartCrossReferenceSearchOptions option)
        {
            ListArgs args;
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice = new ListArgs(x);
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs = new ArrayList();
            string table = "temp_" + Tools.Strings.GetNewID() + "_table";
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "select partrecord.unique_id, partrecord.prefix + partrecord.basenumberstripped as partrecord_part, price as partrecord_price into " + table + " from partrecord where partrecord.importid = '" + nData.SyntaxFilterGeneral(option.SQL_KeyFieldValue) + "'";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add lowest_purchase_price float";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add lowest_purchase_price_perc_diff float";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add temp_hold float";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set lowest_purchase_price = (select isnull(min(orddet_line.unitcost),0) from orddet_line where len(isnull(orddet_line.orderid_purchase,'')) > 0 and orddet_line.prefix + orddet_line.basenumberstripped =  " + table + ".partrecord_part)";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set temp_hold = (lowest_purchase_price-partrecord_price)";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set temp_hold = 0 where temp_hold < 0";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set lowest_purchase_price_perc_diff =(temp_hold/lowest_purchase_price)*100  where temp_hold > 0";   // this needs to be the other way around  lowest_purchase_price/temp_hold
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set lowest_purchase_price_perc_diff = 0 where isnull(lowest_purchase_price_perc_diff,0) <= 0";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "delete from " + table + " where lowest_purchase_price_perc_diff <=0";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " drop column temp_hold";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.PrepareArgs.Add(args);
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.TheWhere = "partrecord.unique_id in (select " + table + ".unique_id from " + table + " where " + table + ".lowest_purchase_price_perc_diff " + option.search_LowestPurchasePriceComparison + " " + option.search_LowestPurchasePricePercent.ToString() + ")";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.TheOrder = "partrecord.date_created desc";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.TheTable = "partrecord";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.TheTemplate = "PartCrossReferenceResults_LowestPurchasePrice";
            ((PartCrossReferenceResults)p).results_LowestPurchasePrice.TheClass = "partrecord";
        }
        private void AvgPurchasePriceCalc(ContextNM x, PartCrossReferenceResults p, PartCrossReferenceSearchOptions option)
        {
            ListArgs args;
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice = new ListArgs(x);
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs = new ArrayList();
            string table = "temp_" + Tools.Strings.GetNewID() + "_table";
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "select partrecord.unique_id, partrecord.prefix + partrecord.basenumberstripped as partrecord_part, price as partrecord_price into " + table + " from partrecord where partrecord.importid = '" + nData.SyntaxFilterGeneral(option.SQL_KeyFieldValue) + "'";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add avg_purchase_price float";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add avg_purchase_price_perc_diff float";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add temp_hold float";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " add temp_count int";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set temp_count = (select count(*) from orddet_line where len(isnull(orddet_line.orderid_purchase,'')) > 0 and orddet_line.prefix + orddet_line.basenumberstripped =  " + table + ".partrecord_part and isnull(orddet_line.unitcost,0) > 0)";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "delete from " + table + " where isnull(temp_count,0) <=0";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set temp_hold = (select sum(orddet_line.unitcost) from orddet_line where len(isnull(orddet_line.orderid_purchase,'')) > 0 and orddet_line.prefix + orddet_line.basenumberstripped =  " + table + ".partrecord_part and isnull(orddet_line.unitcost,0) > 0)";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set avg_purchase_price = (temp_hold/temp_count) where temp_count > 0";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set avg_purchase_price = 0 where isnull(avg_purchase_price,0) <= 0";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "update " + table + " set avg_purchase_price_perc_diff =(partrecord_price/avg_purchase_price)*100  where avg_purchase_price > 0";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " drop column temp_hold";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            args = new ListArgs(x);
            args.TheTable = table;
            args.ThePrepareStatement = "alter table " + table + " drop column temp_count";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.PrepareArgs.Add(args);
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.TheWhere = "partrecord.unique_id in (select " + table + ".unique_id from " + table + " where " + table + ".avg_purchase_price_perc_diff " + option.search_AvgPurchasePriceComparison + " " + option.search_AvgPurchasePricePercent.ToString() + ")";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.TheOrder = "partrecord.date_created desc";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.TheTable = "partrecord";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.TheTemplate = "PartCrossReferenceResults_AvgPurchasePrice";
            ((PartCrossReferenceResults)p).results_AvgPurchasePrice.TheClass = "partrecord";
        }
        //End Refactor Block



        //KT Refactored from RzSensible
        void SalesTotalCalc(ContextRz context, nSQL s, String where, ref Double sales, ref Double profit)
        {
            string sql = "select sum(orddet_line.total_price) as sales, sum(orddet_line.gross_profit) as profit from ordhed_sales inner join orddet_line on ordhed_sales.unique_id = orddet_line.orderid_sales where ";
            sql += s.RenderSQL();
            sql += " and isnull(orddet_line.status,'') != 'Canceled' and isnull(orddet_line.isvoid,0) = 0 and isnull(orddet_line.status,'') != 'Void' and isnull(orddet_line.was_rma,0) = 0 and isnull(orddet_line.was_vendrma,0) = 0 ";
            if (Tools.Strings.StrExt(where))
                sql += " and " + where;

            DataTable dt = context.Select(sql);
            if (dt == null)
            {
                sales = 0;
                profit = 0;
                return;
            }

            sales = Tools.Data.NullFilterDouble(dt.Rows[0]["sales"]);
            profit = Tools.Data.NullFilterDouble(dt.Rows[0]["profit"]);
        }
        private string GetTempPartTable(ContextNM x, ArrayList parts)
        {
            string table = Tools.Strings.GetNewID() + "_table";

            try
            {
                x.Execute("create table " + table + " (part_number varchar(255))");
            }
            catch { }

            foreach (string s in parts)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                x.Execute("insert into " + table + " (part_number) values ('" + s.Trim() + "')");
            }
            return table;
        }
        public virtual ArrayList UserPanelOptionTree(ContextRz x, bool web)
        {
            ArrayList a = new ArrayList();
            UserPanelSection u;
            UserPanelSection s;
            UserPanelSection ss;

            if (x.TheSysRz.ThePermitLogic.CheckPermit(x, Permissions.ThePermits.ViewTeamsAndUsers, x.xUser))
            {
                //Users
                u = new UserPanelSection();
                u.SectionName = "Users";
                u.GraphicImage = "Users.bmp";
                //Users Sub-Sections
                s = new UserPanelSection();
                s.SectionName = "Teams and Users";
                s.GraphicImage = "Users.bmp";
                u.AllSections.Add(s);
                a.Add(u);
            }
            if (!web)
            {
                //Reports
                u = new UserPanelSection();
                u.SectionName = "Reports";
                u.GraphicImage = "Statistics.bmp";
                //Reports Sub-Sections
                s = new UserPanelSection();
                s.SectionName = "Statistic Reports";
                s.GraphicImage = "Reports.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Quote Completion";
                s.GraphicImage = "Reports.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Stock Value Report";
                s.GraphicImage = "Reports.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Commission Report";
                s.GraphicImage = "money.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Sales Report";
                s.GraphicImage = "money.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Purchase Report";
                s.GraphicImage = "money.bmp";
                u.AllSections.Add(s);
                a.Add(u);
                s = new UserPanelSection();
                s.SectionName = "Profit Report (Rz Canned)";
                s.GraphicImage = "money.bmp";
                u.AllSections.Add(s);


                //ArrayList cubes = x.xSys.GetCubes();
                //if (cubes != null)
                //{
                //    if (cubes.Count > 0)
                //    {
                //        //Statistics Sub-Sections
                //        s = new UserPanelSection();
                //        s.SectionName = "Summaries";
                //        s.GraphicImage = "Summaries.bmp";
                //        u.AllSections.Add(s);
                //        a.Add(u);
                //    }
                //}
                //Printed Forms
                u = new UserPanelSection();
                u.SectionName = "Printed Forms";
                u.GraphicImage = "PrintedForms.bmp";
                //Printed Forms Sub-Sections
                s = new UserPanelSection();
                s.SectionName = "Design";
                s.GraphicImage = "Design.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Import";
                s.GraphicImage = "Import.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Import PDF Terms & Conditions";
                s.GraphicImage = "BinSwapper.bmp";
                u.AllSections.Add(s);
                a.Add(u);
                ////Foreign Exchange
                //u = new UserPanelSection();
                //u.SectionName = "Foreign Exchange";
                //u.GraphicImage = "money.bmp";
                ////Foreign Exchange Sub-Sections
                //s = new UserPanelSection();
                //s.SectionName = "Currency Editor";
                //s.GraphicImage = "money.bmp";
                //u.AllSections.Add(s);
                //a.Add(u);
            }
            //Choices
            u = new UserPanelSection();
            u.SectionName = "Choices";
            u.GraphicImage = "Choices.bmp";
            //Choices Sub-Sections
            s = new UserPanelSection();
            s.SectionName = "Add New Choice List";
            s.GraphicImage = "AddNewChoiceList.bmp";
            if (!web)
                s.SQL = "select unique_id, name from n_choices order by name";
            u.AllSections.Add(s);
            if (web)
            {
                s = new UserPanelSection();
                s.SectionName = "Edit Choices";
                s.GraphicImage = "EditList.bmp";
                u.AllSections.Add(s);
                a.Add(u);
            }
            else
            {
                //Choices Sub-Sections
                ss = new UserPanelSection();
                ss.SectionName = "Edit List : ";
                ss.GraphicImage = "EditList.bmp";
                ss.KeyField = "name";
                ss.UIDField = "unique_id";
                s.AllSections.Add(ss);
                a.Add(u);
            }
            if (!web)
            {
                //Email
                u = new UserPanelSection();
                u.SectionName = "Email";
                u.GraphicImage = "Email.bmp";
                //Email Sub-Sections
                //if (RzLicense.LicenseType != LicenseTypes.Lite || Rz3App.xUser.IsDeveloper())
                //{
                s = new UserPanelSection();
                s.SectionName = "Email Templates";
                s.GraphicImage = "EmailTemplates.bmp";
                u.AllSections.Add(s);
                //}
                s = new UserPanelSection();
                s.SectionName = "Email Blaster";
                s.GraphicImage = "EmailBlaster.bmp";
                u.AllSections.Add(s);
                a.Add(u);

                //Monitors
                u = new UserPanelSection();
                u.SectionName = "Monitors";
                u.GraphicImage = "Monitors.bmp";
                //Monitors Sub-Sections
                s = new UserPanelSection();
                s.SectionName = "Duty Monitor";
                s.GraphicImage = "DutyMonitor.bmp";
                u.AllSections.Add(s);
                //if (RzLicense.LicenseType != LicenseTypes.Lite || Rz3App.xUser.IsDeveloper())
                //{
                s = new UserPanelSection();
                s.SectionName = "Phone/Fax Monitor";
                s.GraphicImage = "PhoneFaxMonitor.bmp";
                u.AllSections.Add(s);
                //}
                a.Add(u);
            }
            //System Management
            u = new UserPanelSection();
            u.SectionName = "System Management";
            u.GraphicImage = "SystemManagement.bmp";
            //System Management Sub-Sections
            s = new UserPanelSection();
            s.SectionName = "Your Company Information";
            s.GraphicImage = "YourCompanyInformation.bmp";
            u.AllSections.Add(s);
            s = new UserPanelSection();
            s.SectionName = "Community Settings";
            s.GraphicImage = "YourCompanyInformation.bmp";
            u.AllSections.Add(s);
            s = new UserPanelSection();
            s.SectionName = "RzLink Manager";
            s.GraphicImage = "YourCompanyInformation.bmp";
            u.AllSections.Add(s);
            if (!web)
            {
                s = new UserPanelSection();
                s.SectionName = "Order Number Editor";
                s.GraphicImage = "OrderNumberEditor.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Bin Swapper";
                s.GraphicImage = "BinSwapper.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Database Manager";
                s.GraphicImage = "DatabaseManager.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Web Update";
                s.GraphicImage = "WebUpdate.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Address Options";
                s.GraphicImage = "AddressOptions.bmp";
                u.AllSections.Add(s);
                s = new UserPanelSection();
                s.SectionName = "Picture Resize Tool";
                s.GraphicImage = "PictureResizeTool.bmp";
                u.AllSections.Add(s);
                if (x.xUser.super_user)
                {
                    s = new UserPanelSection();
                    s.SectionName = "Restore Company";
                    s.GraphicImage = "DatabaseManager.bmp";
                    u.AllSections.Add(s);
                    s = new UserPanelSection();
                    s.SectionName = "Restore Contact";
                    s.GraphicImage = "DatabaseManager.bmp";
                    u.AllSections.Add(s);
                    s = new UserPanelSection();
                    s.SectionName = "Restore Order";
                    s.GraphicImage = "DatabaseManager.bmp";
                    u.AllSections.Add(s);
                    s = new UserPanelSection();
                    s.SectionName = "Restore Order Line";
                    s.GraphicImage = "DatabaseManager.bmp";
                    u.AllSections.Add(s);
                }
                if (x.xUser.IsDeveloper())
                {
                    s = new UserPanelSection();
                    s.SectionName = "SandBox";
                    s.GraphicImage = "YourCompanyInformation.bmp";
                    u.AllSections.Add(s);
                    //Rz Publish Upload
                    bool isDesignMode = x.xSys.isDesignMode();

                    if (isDesignMode)
                    {
                        s = new UserPanelSection();
                        s.SectionName = "Publish Rz";
                        s.GraphicImage = "YourCompanyInformation.bmp";
                        u.AllSections.Add(s);
                    }
                }
                if (x.xUser.IsDeveloper() && n_set.GetSetting_Boolean(x, "needs_rz4_conversion"))
                {
                    s = new UserPanelSection();
                    s.SectionName = "Convert To Rz4";
                    s.GraphicImage = "YourCompanyInformation.bmp";
                    u.AllSections.Add(s);
                }
            }
            a.Add(u);
            return a;
        }
        public virtual bool ShowAllChoices(ContextNM x)
        {
            ((ILeaderRz)x.TheLeader).AllChoicesShow((ContextRz)x);
            return true;
        }
        public virtual bool AddNewChoiceList(ContextNM x)
        {
            ((ILeaderRz)x.TheLeader).AddNewChoiceList((ContextRz)x);
            return true;
        }
        public virtual bool ContactReminderShow(ContextNM x)
        {
            if (!x.xUser.CheckPermit(x, "Company:Search:Search Companies"))
            {
                x.TheLeader.ShowNoRight();
                return false;
            }

            ((ILeaderRz)x.TheLeader).ContactReminderShow((ContextRz)x);
            return true;
        }
        public virtual bool ShowPartTestingScreen(ContextNM x, qualitycontrol q)
        {
            return false;
        }
        public virtual bool HomeScreenShow(ContextNM x)
        {
            if (!x.xUser.CheckPermit(x, "General:Search:Search Home"))
            {
                x.TheLeader.ShowNoRight();
                return false;
            }
            ((ILeaderRz)x.TheLeader).HomeScreenShow((ContextRz)x);
            return true;
        }
        public virtual bool OrderLinksShow(ContextNM x, string order_uid)
        {
            ((ILeaderRz)x.TheLeader).OrderLinksShow((ContextRz)x, order_uid);
            return true;
        }
        public virtual bool PaymentsShow(ContextNM x, string order_uid)
        {
            ((ILeaderRz)x.TheLeader).PaymentsShow((ContextRz)x, order_uid);
            return true;
        }
        public virtual bool UserManagerShow(ContextNM x)
        {
            ((ILeaderRz)x.TheLeader).UserManagerShow((ContextRz)x);
            return true;
        }
        public virtual bool CompanyInfoShow(ContextNM x)
        {
            ((ILeaderRz)x.TheLeader).CompanyInfoShow((ContextRz)x);
            return true;
        }
        public virtual void AskForSalesLineCancel(orddet d)
        {

        }
        public virtual bool ReqSourcingManagerShow(ContextNM x)
        {
            ((ILeaderRz)x.TheLeader).ReqSourcingManagerShow((ContextRz)x);
            return true;
        }
        public virtual bool ReqQuotingManagerShow(ContextRz x)
        {
            x.TheLeaderRz.ReqQuotingManagerShow((ContextRz)x);
            return true;
        }
        private void CheckLicenseType(ContextRz context)
        {
            //if (RzLicense.LicenseType != LicenseTypes.Custom)
            //{
            //RzLicense.LicenseType = LicenseTypes.Custom;
            if (!Tools.Strings.StrExt(RzLicense.LicenseID))
                RzLicense.LicenseID = Tools.Strings.GetNewID();
            RzLicense.ApplyNewLicense(context, RzLicense.LicenseID);  //, RzLicense.LicenseType
            //}
        }
        public virtual void CheckCompanyIdentifier(ContextRz context)
        {
            context.TheLeader.Comment("CheckingCompanyIdentifier()");
            if (!Tools.Strings.StrExt(CompanyIdentifier))
                CompanyIdentifier = n_set.GetSetting(context, "company_identifier");
            context.Logic.UseAlternateReqScreens = n_set.GetSetting_Boolean(context, "usealtreqscreens");
            ArrayList QBGeneral = new ArrayList();
            ArrayList QBInvoice = new ArrayList();
            ArrayList QBPO = new ArrayList();
            QBGeneral.Add("SetClassToInitials");
            switch (CompanyIdentifier.ToLower().Trim())
            {
                //case "phoenix":
                //    Rz3App.xLogic.IsPhoenix = true;
                //    Rz3App.xLogic.UpperCaseEverything = true;
                //    break;
                //case "phoenixwarehouse":
                //    Rz3App.xLogic.IsPhoenix = true;
                //    IsPhoenixWarehouse = true;
                //    Rz3App.xLogic.UpperCaseEverything = true;
                //    break;
                //case "phoenixbrazil":
                //    Rz3App.xLogic.IsPhoenix = true;
                //    Rz3App.xLogic.UpperCaseEverything = true;
                //    IsPhoenixBrazil = true;
                //    break;
                //case "phoenixemea":
                //    Rz3App.xLogic.IsPhoenix = true;
                //    Rz3App.xLogic.UpperCaseEverything = true;
                //    IsPhoenixEMEA = true;
                //    break;
                case "demo":
                    //RzLicense.LicenseType = LicenseTypes.Custom;
                    CheckLicenseType(context);
                    context.Logic.IsDemo = true;
                    break;
                //case "forex":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsForex = true;
                //    break;
                //case "braun":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsBraun = true;
                //    break;
                //case "bozz":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsBozz = true;
                //    break;
                //case "stl":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsSTL = true;
                //    break;
                //case "legend":
                //    Rz3App.xLogic.IsLegend = true;
                //    break;
                //case "ultimate":
                //    Rz3App.xLogic.IsUltimate = true;
                //    break;
                //case "earthtron":
                //    Rz3App.xLogic.IsEarthTron = true;
                //    break;
                //case "atometron":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsAtometron = true;
                //    break;
                //case "aat":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsAAT = true;
                //    OrderNumberLength = 5;
                //    QBInvoice.Add("IncludeRTag");
                //    contextRz.TheSysRz.TheQuickBooksLogic.OutgoingShipping = "Shipping/Handling";
                //    contextRz.TheSysRz.TheQuickBooksLogic.IncomingShipping = "Shipping/Handling";
                //    QBGeneral.Remove("SetClassToInitials");
                //    QBGeneral.Add("SingleOverheadCharge");
                //    nStartup.ShowLinksOption = true;
                //    break;
                //case "pmt":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsPMT = true;
                //    Rz3App.xLogic.CarryStockLinks = true;
                //    break;
                //case "inet":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsINet = true;
                //    if (!Rz3App.xLogic.UseAlternateReqScreens)
                //        Rz3App.xLogic.UseAlternateReqScreens = true;
                //    QBPO.Add("UseReferenceNumber");
                //    QBGeneral.Remove("SetClassToInitials");
                //    break;
                //case "axiom":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsAxiom = true;
                //    //Rz3App.xLogic.UseArch = true;
                //    //Rz3App.xLogic.ArchSite = Rz3App.xSys.xData.GetScalar_Integer("select top 1 site_index from arch_site");
                //    break;
                //case "ntc":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsNTC = true;
                //    Rz3App.xLogic.CarryStockLinks = true;
                //    UploadCode = "98";
                //    ExportFolder = "c:\\";
                //    NotifyEmailAddress = "ntc@recognin.com";
                //    NotifyEmailPassword = "ntcpassword";
                //    break;
                //case "nasco":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsNasco = true;
                //    Rz3App.xLogic.CompareDistilledCompanyNames = false;
                //    break;
                //case "merit":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsMerit = true;
                //    //QBGeneral.Add("InventoryOnly");
                //    //QBInvoice.Add("DropLeadingZeroes");
                //    //QBPO.Add("DropLeadingZeroes");
                //    //QBPO.Add("PurchaseOrder");
                //    //QBPO.Add("AutoCreateCustomer");
                //    break;
                //case "pipeline":
                //    Rz3App.xLogic.IsPipeline = true;
                //    Rz3App.xLogic.AssignOrdersToCompanyAgent = true;
                //    break;
                //case "tesla":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsTesla = true;
                //    break;
                //case "ci":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsCI = true;
                //    break;
                //case "select":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsSelect = true;
                //    OrderNumberLength = 5;
                //    Rz3App.xLogic.MakePOsOptional = true;
                //    Rz3App.xLogic.CarryStockLinks = true;
                //    Rz3App.xLogic.AssignOrdersToCompanyAgent = true;
                //    break;
                //case "isttar":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsIsttar = true;
                //    break;
                //case "arrowtronics":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsArrowtronics = true;
                //    if (!Rz3App.xLogic.UseAlternateReqScreens)
                //        Rz3App.xLogic.UseAlternateReqScreens = true;
                //    break;
                //case "kimtronics":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsKimtronics = true;
                //    break;
                //case "voxx":
                //    CheckLicenseType();
                //    Rz3App.xLogic.IsVoxx = true;
                //    ExportFolder = "c:\\";
                //    UploadCode = "97";
                //    InvisibleCompanies.Add("Foxconn%");
                //    break;
                case "forte":
                    CheckLicenseType(context);
                    context.Logic.IsForte = true;
                    ExportFolder = "c:\\";
                    UploadCode = "97";
                    InvisibleCompanies.Add("Foxconn%");
                    break;
                    //case "integrity":
                    //    CheckLicenseType();
                    //    Rz3App.xLogic.IsIntegrity = true;
                    //    break;
                    //case "prism":
                    //    Rz3App.xLogic.IsPrism = true;
                    //    Rz3App.xLogic.HandlingCaption = "C.O.D.";
                    //    break;
                    //case "gemtek":
                    //    CheckLicenseType();
                    //    Rz3App.xLogic.IsNTC = true;
                    //    Rz3App.xLogic.IsGemTek = true;
                    //    Rz3App.xLogic.CarryStockLinks = true;
                    //    UploadCode = "96";
                    //    ExportFolder = "c:\\";
                    //    NotifyEmailAddress = "gemtek@recognin.com";
                    //    NotifyEmailPassword = "gemtek1";
                    //    break;
                    //case "tes":
                    //    CheckLicenseType();
                    //    IsTES = true;
                    //    break;
                    //case "zeris":
                    //    CheckLicenseType();
                    //    IsZeris = true;
                    //    break;
                    //case "iconix":
                    //    CheckLicenseType();
                    //    IsIconix = true;
                    //    break;
                    //case "voyager":
                    //    CheckLicenseType();
                    //    //Rz3App.xLogic.IsAtometron = true;
                    //    Rz3App.xLogic.IsVoyager = true;
                    //    //Tools.Dymo.NewDymoVersion = true;
                    //    break;
                    //case "cuetech":
                    //    CheckLicenseType();
                    //    Rz3App.xLogic.IsCuetech = true;
                    //    break;
                    //case "concord":
                    //    Rz3App.xLogic.IsConcord = true;
                    //    break;
                    //case "marketplace":
                    //    Rz3App.xLogic.IsMarketPlace = true;
                    //    break;
                    //case "g2":
                    //    Rz3App.xLogic.IsG2 = true;
                    //    break;
                    //case "alfa":
                    //    Rz3App.xLogic.IsAlfa = true;
                    //    break;
                    //case "recognin":
                    //    Rz3App.xLogic.IsRecognin = true;
                    //    break;
            }
            context.TheLeader.Comment("Using Company : " + CompanyIdentifier);
            //contextRz.TheSysRz.TheQuickBooksLogic.GeneralOption = GetOptions(QBGeneral);
            //contextRz.TheSysRz.TheQuickBooksLogic.InvoiceOption = GetOptions(QBInvoice);
            //contextRz.TheSysRz.TheQuickBooksLogic.POOption = GetOptions(QBPO);
        }
        private String GetOptions(ArrayList a)
        {
            String s = "";
            foreach (String x in a)
            {
                if (Tools.Strings.StrExt(s))
                    s += ",";
                s += x;
            }
            return s;
        }
        public virtual void LogOrderActivity(ordhed h, Enums.TransmitType t)
        {
            MessageBox.Show("reorg");

            //try
            //{
            //    if (h == null)
            //        return;
            //    string act = "";
            //    switch (t)
            //    {
            //        case Enums.TransmitType.Print:
            //        case Enums.TransmitType.PDF:
            //            act = "Order Printed";
            //            break;
            //        case Enums.TransmitType.Fax:
            //            act = "Order Faxed";
            //            break;
            //        case Enums.TransmitType.Email:
            //            act = "Order Emailed";
            //            break;
            //    }
            //    if (!Tools.Strings.StrExt(act))
            //        return;
            //    order_activity o = new order_activity(Rz3App.xSys);
            //    o.activity_text = act;
            //    o.activity_date = DateTime.Now;
            //    o.activity_username = Rz3App.xUser.name;
            //    o.the_deal_uid = h.base_dealheader_uid;
            //    o.the_n_user_uid = Rz3App.xUser.unique_id;
            //    o.ISave();
            //}
            //catch { }
        }
        public virtual String ManagerEmailAddresses
        {
            get
            {
                //this is overridden in customerspecific classes.
                //it CANNOT have actual email addresses, or 1 company's profit report WILL be emailed to another company
                String ret = "";
                if (Tools.Misc.IsDevelopmentMachine())
                    ret = "ktill@sensiblemicro.com";
                else
                    ret = DefaultEmailAddress;
                return ret;
            }
        }
        public void EmailReport(ContextRz context, String strCaption, String strAddress, String strHTMLReport)
        {
            context.TheLeader.Comment("Emailing " + strCaption + " report to " + strAddress + "...");
            nEmailMessage m = new nEmailMessage();
            SetFromNotification(m);

            ArrayList addys = nTools.SplitArray(strAddress, "|");

            m.ToAddress = (String)addys[0];

            for (int i = 1; i < addys.Count; i++)
            {
                m.AddBccRecipient((String)addys[i]);
            }

            m.Subject = strCaption + " Report " + DateTime.Now.ToString();
            m.HTMLBody = strHTMLReport;
            String s = "";
            if (!m.Send(ref s))
                throw new Exception("Email not sent");
            else
                context.TheLeader.Comment(strCaption + " report email sent.");
        }
        //from RzApp


        //public static RzLogic xLogic;
        public bool SuspendCache = false;
        public DataTable CustomerList;
        public DataTable VendorList;
        public DataTable CompanyList;
        //Company switches
        public bool IsSelectTech = false;
        public bool IsPacificMicro = false;

        public ArrayList SalesPeople;
        public ArrayList AssignedPeople;
        public ArrayList AssignedAgents;
        public String InstanceID;
        public bool ShowReqStatus = false;


        public void CacheCompanies(ContextRz context)
        {
            if (SuspendCache)
                return;
            context.TheLeader.Comment("Caching companies...");
            CacheCompanyList(context);

            context.TheLeaderRz.CacheCompanies();

            context.TheLeader.Comment("Done.");
        }
        public void CacheCompanyList(ContextNM x, String s, String strSQL)
        {
            switch (s.ToLower())
            {
                case "customer":
                    CustomerList = x.Select(strSQL);
                    break;
                case "vendor":
                    VendorList = x.Select(strSQL);
                    break;
                case "company":
                    CompanyList = x.Select(strSQL);
                    break;
            }
            //DataTable t =
            //if (t == null)
            //{
            //    s = new CompanyStub[1];
            //    s.SetValue(new CompanyStub("<none>", ""), 0);
            //    return;
            //}
            //if (t.Rows.Count == 0)
            //{
            //    s = new CompanyStub[1];
            //    s.SetValue(new CompanyStub("<none>", ""), 0);
            //    return;
            //}
            //s = new CompanyStub[t.Rows.Count];
            //long l = 0;
            //foreach (DataRow r in t.Rows)
            //{
            //    s.SetValue(new CompanyStub((String)r[0], (String)r[1]), l);
            //    l++;
            //}
        }

        public void StartHook(ContextRz context, String server, int port, String password, bool ignoresounds)
        {
            if (context.xHook != null)
                StopHook(context);
            context.xHook = context.TheLeaderRz.HookCreate(context);  // new RzHook();
            context.xHook.ApplicationName = "Rz3";
            context.xHook.ApplicationVersion = 2;
            context.xHook.HostName = server;
            context.xHook.HostPort = port;
            context.xHook.UserID = context.xUser.unique_id;
            context.xHook.UserName = context.xUser.name;
            context.xHook.SendEncrypted = true;
            context.xHook.Password = password;

            if (!ignoresounds)
                context.xHook.InitSoundSettings(context);

            String se = "";
            if (!context.xHook.ConnectWithPersistence(ref se))
                context.xHook.StartPersistence();
        }

        public void RequestObjectLockCheck(ContextRz context, String strID, String strCaption)
        {
            if (context.xHook == null)
                return;
            if (!context.xHook.IsConnected())
                return;
            // TieMessage m = new TieMessage(context.xHook.SessionID, "object_lock_check", "<all>");
            // m.ContentString = Tools.Xml.BuildXmlProp("object_id", strID) + Tools.Xml.BuildXmlProp("object_caption", strCaption) + Tools.Xml.BuildXmlProp("requesting_session", context.xHook.SessionID);
            //context.xHook.SendAsync(m);
        }

        public void RequestObjectClose(ContextRz context, String ObjectCaption, String SessionID, String ObjectID, String UserName, String MachineName)
        {
            bool b = true;
            if (context.xHook == null)
                b = false;
            if (!context.xHook.IsConnected())
                b = false;
            if (!b)
            {
                context.TheLeader.TellTemp("The Tie system could not be accessed to send this request.");
                return;
            }
            //TieMessage m = new TieMessage(context.xHook.SessionID, "object_close_request", SessionID);
            //m.ContentString = Tools.Xml.BuildXmlProp("object_id", ObjectID) + Tools.Xml.BuildXmlProp("object_caption", ObjectCaption) + Tools.Xml.BuildXmlProp("requesting_session", context.xHook.SessionID) + Tools.Xml.BuildXmlProp("requesting_user", UserName) + Tools.Xml.BuildXmlProp("requesting_machine", MachineName);
            //context.xHook.SendAsync(m);
        }

        public void StopHook(ContextRz context)
        {
            if (context == null)
                return;

            if (context.xHook == null)
                return;

            try
            {
                context.xHook.StopPersistence();
                context.xHook.Close();
                context.xHook = null;
            }
            catch
            {
            }
        }

        public bool CacheSalesPeople(ContextRz x)
        {
            return CacheSalesPeopleList(x);
        }
        public bool CacheAssignedAgents(ContextRz x)
        {
            AssignedAgents = x.SelectScalarArray("select distinct(name) from n_user where unique_id in (select distinct(base_mc_user_uid) from company where len(isnull(base_mc_user_uid,'')) > 0) and unique_id in (select distinct(base_mc_user_uid) from companycontact where len(isnull(base_mc_user_uid,'')) > 0)");
            return true;
        }
        public void CheckPrintedFormGraphics(ContextRz context)
        {
            try
            {
                String graphicsfolder = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppParentPath()) + @"Graphics\";
                if (!System.IO.Directory.Exists(graphicsfolder))
                    nTools.MakeFolderExist(graphicsfolder);
                if (context.SelectScalarInt64("select count(*) from filelink where linktype = 'printedform_graphics'") <= 0)
                    return;
                ArrayList a = context.QtC("filelink", "select * from filelink where linktype = 'printedform_graphics'");
                if (a != null)
                {
                    if (a.Count > 0)
                    {
                        foreach (filelink fl in a)
                        {
                            if (!Tools.Strings.StrExt(fl.linkname))
                                continue;
                            String filename = fl.linkname + "." + fl.filetype;
                            if (!System.IO.File.Exists(filename))
                            {
                                if (!fl.LoadPictureData(context))
                                    continue;
                                fl.SaveDataAsFile(fl.linkname, true, graphicsfolder);
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { context.TheLeader.Comment("Error CheckPrintedFormGraphics():" + ee.Message); }
        }


        public void CheckSaveCompany(ContextRz x, String strName, String strContact, String strPhone, String strFax)
        {
            CheckSaveCompany(x, strName, strContact, strPhone, strFax, "VENDOR");
        }
        public void CheckSaveCompany(ContextRz x, String strName, String strContact, String strPhone, String strFax, String strType)
        {
            if (!Tools.Strings.StrExt(strName))
                return;
            company xCompany = company.GetByName(x, strName);
            if (xCompany != null)
                return;
            xCompany = company.New(x);
            xCompany.companyname = strName;
            xCompany.primarycontact = strContact;
            xCompany.primaryphone = strPhone;
            xCompany.primaryfax = strFax;
            xCompany.companytype = strType;
            x.Insert(xCompany);
        }

        public static Enums.OrderType ConvertOrderType(String ordertype)
        {
            switch (ordertype.ToLower().Trim())
            {
                case "rfq":
                    return Enums.OrderType.RFQ;
                case "quote":
                    return Enums.OrderType.Quote;
                case "sales":
                    return Enums.OrderType.Sales;
                case "purchase":
                    return Enums.OrderType.Purchase;
                case "invoice":
                    return Enums.OrderType.Invoice;
                case "rma":
                    return Enums.OrderType.RMA;
                case "vendrma":
                    return Enums.OrderType.VendRMA;
                case "service":
                    return Enums.OrderType.Service;
                default:
                    return Enums.OrderType.Any;
            }
        }
        public static String ConvertOrderType(Enums.OrderType t)
        {
            switch (t)
            {
                case Enums.OrderType.RFQ:
                    return "RFQ";
                case Enums.OrderType.Quote:
                    return "Quote";
                case Enums.OrderType.Sales:
                    return "Sales";
                case Enums.OrderType.Purchase:
                    return "Purchase";
                case Enums.OrderType.Invoice:
                    return "Invoice";
                case Enums.OrderType.RMA:
                    return "RMA";
                case Enums.OrderType.VendRMA:
                    return "VendRMA";
                case Enums.OrderType.Service:
                    return "Service";
            }
            return "";
        }
        public static Enums.OrderDirection ConvertOrderDirection(Enums.OrderType t)
        {
            switch (t)
            {
                case Enums.OrderType.RFQ:
                    return Enums.OrderDirection.Incoming;
                case Enums.OrderType.Quote:
                    return Enums.OrderDirection.Outgoing;
                case Enums.OrderType.Sales:
                    return Enums.OrderDirection.Outgoing;
                case Enums.OrderType.Purchase:
                    return Enums.OrderDirection.Incoming;
                case Enums.OrderType.Invoice:
                    return Enums.OrderDirection.Outgoing;
                case Enums.OrderType.RMA:
                    return Enums.OrderDirection.Incoming;
                case Enums.OrderType.VendRMA:
                    return Enums.OrderDirection.Outgoing;
            }
            return Enums.OrderDirection.Outgoing;
        }
        public static Enums.OrderQuantityType ConvertOrderQuantityType(Enums.OrderType t)
        {
            switch (t)
            {
                case Enums.OrderType.RFQ:
                    return Enums.OrderQuantityType.Ordered;
                case Enums.OrderType.Quote:
                    return Enums.OrderQuantityType.Ordered;
                case Enums.OrderType.Sales:
                    return Enums.OrderQuantityType.Ordered;
                case Enums.OrderType.Purchase:
                    return Enums.OrderQuantityType.Ordered;
                case Enums.OrderType.Invoice:
                    return Enums.OrderQuantityType.Filled;
                case Enums.OrderType.RMA:
                    return Enums.OrderQuantityType.Ordered;
                case Enums.OrderType.VendRMA:
                    return Enums.OrderQuantityType.Filled;
            }
            return Enums.OrderQuantityType.Ordered;
        }
        public usernote NotifyAgent(ContextRz context, nObject xObject, String strCaption, String strNote, String strAgentName)
        {
            return NotifyAgent(context, xObject, strCaption, strNote, strAgentName, true);
        }
        public usernote NotifyAgent(ContextRz context, nObject xObject, String strCaption, String strNote, String strAgentName, bool pop)
        {
            usernote xNote = usernote.New(context);
            xNote.by_mc_user_uid = context.xUser.unique_id;
            xNote.for_mc_user_uid = NewMethod.n_user.TranslateNameToID(context, strAgentName);
            xNote.notetext = strNote;
            xNote.displaydate = System.DateTime.Now;
            xNote.shouldpopup = pop;
            context.Insert(xNote);
            xNote.CreateObjectLink(context, xObject, strCaption);
            return xNote;
        }

        public usernote NotifyAgentPlusEmail(ContextRz context, nObject xObject, String strCaption, String strNote, String strAgentName)
        {
            usernote ret = NotifyAgent(context, xObject, strCaption, strNote, strAgentName, true);

            n_user u = (n_user)context.xSys.Users.GetByName(strAgentName);
            if (u != null)
            {
                if (Tools.Email.IsEmailAddress(u.email_address))
                {
                    Tools.nEmailMessage m = new Tools.nEmailMessage();
                    context.Logic.SetFromNotification(m);

                    if (Tools.Misc.IsDevelopmentMachine())
                        m.ToAddress = "mike@recognin.com";
                    else
                    {
                        m.ToAddress = u.email_address;

                        foreach (n_user c in u.ThisUsersTeamCaptains(context))
                        {
                            if (Tools.Email.IsEmailAddress(c.email_address))
                                m.AddBccRecipient(c.email_address);
                        }

                        foreach (AssistantHandle h in context.Logic.GetAssistantHandles(context))
                        {
                            if (Tools.Strings.StrCmp(h.ManagerUser.name, u.name) && Tools.Email.IsEmailAddress(h.AssistantUser.email_address))
                            {
                                m.AddBccRecipient(h.AssistantUser.email_address);
                            }
                        }
                    }

                    m.Subject = strCaption;
                    m.HTMLBody = strNote;
                    m.Send();
                }
            }

            return ret;
        }

        //public static void ShutDown()
        //{
        //    if( xMainForm != null )
        //        xMainForm.Close();
        //    xMainForm = null;
        //}
        public static String GetFriendlyOrderType(Enums.OrderType t)
        {
            switch (t)
            {
                case Enums.OrderType.RFQ:
                    return "Vendor Bid";
                case Enums.OrderType.Quote:
                    return "Formal Quote";
                case Enums.OrderType.Sales:
                    return "Sales Order";
                case Enums.OrderType.Purchase:
                    return "Purchase Order";
                case Enums.OrderType.Invoice:
                    return "Invoice";
                case Enums.OrderType.RMA:
                    return "RMA";
                case Enums.OrderType.VendRMA:
                    return "Vendor RMA";
                case Enums.OrderType.Service:
                    return "Service Order";
            }
            return "";
        }


        public object GetEnumOrderTypeFromFirendlyString(string orderType)
        {
            switch (orderType.ToLower())
            {
                case "vendor bid":
                case "orddet_rfq":
                case "bidline":
                    return Enums.OrderType.RFQ;
                case "formal quote":
                case "orddet_quote":
                case "reqline":
                    return Enums.OrderType.Quote;
                case "oales order":
                case "orddet_sales":
                case "ordhed_sales":
                case "viewdetailsales":
                    return Enums.OrderType.Sales;
                case "purchase order":
                case "orddet_purchase":
                case "ordhed_purchase":
                case "viewdetailpurchase":
                    return Enums.OrderType.Purchase;
                case "invoice":
                case "orddet_invoice":
                case "ordhed_invoice":
                case "viewdetailinvoice":
                    return Enums.OrderType.Invoice;
                case "rma":
                case "orddet_rma":
                case "ordhed_rma":
                case "viewdetailrma":
                    return Enums.OrderType.RMA;
                case "vendor rma":
                case "vendrma":
                case "orddet_vendrma":
                case "ordhed_vendrma":
                case "viewdetailvendrma":
                    return Enums.OrderType.VendRMA;
                case "Service Order":
                case "orddet_service":
                case "ordhed_service":
                case "viewdetailservice":
                    return Enums.OrderType.Service;
                default:
                    return Enums.OrderType.Any;
            }

        }




        public virtual bool UserNotesDiabled(n_user user)
        {
            return false;
        }


        //KT TAB Management
        public void SaveOpenTabs(ContextRz x, bool autoDelete = true)
        {
            //Only save if any open objects, that way we don't wipe existing tabs if no tabs open
            int objectTabCount = 0;
            foreach (TabPageCore tbp in NMWin.MainForm.TabsList)
                if (tbp.TheItem != null)
                    objectTabCount++;
            if (objectTabCount > 0)
            {


                if (autoDelete)
                    DeleteRecentTabs(x);


                foreach (TabPageCore tbp in NMWin.MainForm.TabsList)
                {


                    if (tbp.TheItem != null)//FOr now, only objects, not things like People Search, etc
                    {
                        bool insert = false;
                        recent_item i = recent_item.GetById(x, tbp.TabID);
                        if (i == null)
                        {
                            i = new recent_item();
                            insert = true;
                        }

                        i.user_uid = x.xUser.unique_id;
                        i.user_name = x.xUser.name;
                        i.item_name = tbp.OriginalCaption;
                        i.is_bookmarked = tbp.Locked;
                        i.item_uid = tbp.TheItem.Uid;
                        i.item_classid = tbp.TheItem.ClassId;
                        i.item_orderType = tbp.TheView.Name;
                        if (insert)
                            i.Insert(x);
                        else
                            i.Update(x, true);
                    }

                }
            }
        }

        public void DeleteRecentTabs(ContextRz x)
        {
            ArrayList recentTabs = GetRecentTabs(x);
            //int index = 0;
            foreach (recent_item i in recentTabs)
            {
                i.Delete(x);
                //index++;
            }            //if (index > 0)
            //    x.Leader.Tell("Deleted " + index + " tabs.");

        }

        public void ShowRecentTabs(ContextRz x)
        {
            ArrayList recentTabs = GetRecentTabs(x);
            string tabMsg = "";
            if (recentTabs.Count == 0)
                tabMsg = "No Tabs";
            else
                foreach (recent_item r in recentTabs)
                {
                    tabMsg += r.item_name + Environment.NewLine;
                }
            x.Leader.Tell(tabMsg);
        }


        public void OpenRecentTabs(ContextRz x)
        {
            ArrayList recentTabs = GetRecentTabs(x);
            foreach (recent_item ri in recentTabs)
            {
                openObjectFromRecentTabs(ri);
            }
        }

        public ArrayList GetRecentTabs(ContextRz x)
        {
            return NMWin.ContextDefault.QtC("recent_item", "select * from recent_item where user_uid = '" + x.xUser.unique_id + "'");
        }


        private void openObjectFromRecentTabs(recent_item ri)
        {
            nObject o = new nObject();
            ContextRz x = (ContextRz)NMWin.ContextDefault;

            switch (ri.item_classid)
            {

                case "ordhed_service":
                    o = ordhed_service.GetById(x, ri.item_uid);
                    x.Show(o);
                    break;
                case "ordhed_sales":
                    o = ordhed_sales.GetById(x, ri.item_uid);
                    x.Show(o);
                    break;
                case "ordhed_invoice":
                    o = ordhed_invoice.GetById(x, ri.item_uid);
                    x.Show(o);
                    break;
                case "ordhed_purchase":
                    o = ordhed_purchase.GetById(x, ri.item_uid);
                    x.Show(o);
                    break;
                case "ordhed_rma":
                    o = ordhed_rma.GetById(x, ri.item_uid);
                    x.Show(o);
                    break;
                case "ordhed_vendrma":
                    o = ordhed_vendrma.GetById(x, ri.item_uid);
                    x.Show(o);
                    break;
                case "orddet_line":
                    o = orddet_line.GetById(x, ri.item_uid);
                    Enums.OrderType orderType = (Enums.OrderType)GetEnumOrderTypeFromFirendlyString(ri.item_orderType);
                    x.Show(new ShowArgsOrder(x, o, orderType));//Gotta pass order type somehow, maybe new database field
                    break;
                case "partrecord":
                    o = partrecord.GetById(x, ri.item_uid);
                    x.Show(o);
                    break;
                case "company":
                    o = company.GetById(x, ri.item_uid);
                    x.Show(o);
                    break;
                case "companycontact":
                    o = companycontact.GetById(x, ri.item_uid);
                    x.Show(o);
                    break;

                default:
                    x.Show(o);
                    break;

            }


        }

        //private Rz5.Enums.OrderType GetOrderTypeFromString(string item_orderType)
        //{


        //    switch (item_orderType)
        //    {
        //        case "ViewDetailSales":
        //            return Enums.OrderType.Sales;
        //        case "ViewDetailPurchase":
        //            return Enums.OrderType.Purchase;
        //        case "ViewDetailInvoice":
        //            return Enums.OrderType.Invoice;
        //        case "ViewDetailQuote":
        //            return Enums.OrderType.Quote;
        //        case "ViewDetailRFQ":
        //            return Enums.OrderType.RFQ;
        //        case "ViewDetailService":
        //            return Enums.OrderType.Service;
        //        case "ViewDetailRMA":
        //            return Enums.OrderType.RMA;
        //        case "ViewDetailVendRMA":
        //            return Enums.OrderType.VendRMA;

        //        default:
        //            return Enums.OrderType.Sales;
        //    }

        //}


    }

    public enum OwnerSettingField
    {
        owner_companyid,
        owner_companyname,
        owner_address1,
        owner_address2,
        owner_city,
        owner_state,
        owner_zip,
        owner_phone,
        owner_fax,
        owner_country,
        company_logo_url
    }

    public class OwnerSettings
    {
        public static void SetValue(ContextRz context, OwnerSettingField field, String value)
        {
            context.SetSetting(field.ToString(), value);
        }

        public static String GetValue(ContextRz context, OwnerSettingField field, Boolean bHTML = false)
        {
            return n_set.GetSetting(context, field.ToString());
        }

        public static String GetValue(ContextRz context, String value)
        {
            return GetValue(context, value, false);
        }
        public static String GetValue(ContextRz context, String value, Boolean bHTML)
        {
            switch (value.ToLower())
            {
                case "companyname":
                    return GetValue(context, OwnerSettingField.owner_companyname, bHTML);
                case "address1":
                    return GetValue(context, OwnerSettingField.owner_address1, bHTML);
                case "address2":
                    return GetValue(context, OwnerSettingField.owner_address2, bHTML);
                case "city":
                    return GetValue(context, OwnerSettingField.owner_city, bHTML);
                case "state":
                    return GetValue(context, OwnerSettingField.owner_state, bHTML);
                case "zip":
                    return GetValue(context, OwnerSettingField.owner_zip, bHTML);
                case "phone":
                    return GetValue(context, OwnerSettingField.owner_phone, bHTML);
                case "fax":
                    return GetValue(context, OwnerSettingField.owner_country, bHTML);
                case "country":
                    return GetValue(context, OwnerSettingField.owner_companyname, bHTML);
                case "addressblock":
                    return GetAddressBlock(context, bHTML);
                case "company_logo_url":
                    return GetValue(context, OwnerSettingField.company_logo_url, bHTML);



            }
            return value;
        }
        public static string GetCompanyLogoPath(ContextRz x)
        {
            return "\\\\storage\\sm_storage\\rz_attachments\\rz_company_logo.jpg";
            //return "\\\\storage\\sm_storage\\rz_attachments\\test_image.jpg";
        }

        //public static string GetCompanyLogoPath(ContextRz x)
        //{
        //    //variable to store the eventual local file path, from which PictureBoxes will render, etc.       
        //    string logoPath = "";

        //    //logoUrl
        //    string logoUrl = OwnerSettings.GetValue(x, OwnerSettingField.company_logo_url, false);
        //    if (string.IsNullOrEmpty(logoUrl))
        //    {
        //        //IF no Logo Url detected, set the value now to a default from 2019
        //        OwnerSettings.SetValue(x, OwnerSettingField.company_logo_url, @"https://www.sensiblemicro.com/hubfs/Ext-Assets/Sensible-Micro-Logo-240x120.png");
        //        //Then relad, it should now be detected
        //        logoUrl = OwnerSettings.GetValue(x, OwnerSettingField.company_logo_url, false);
        //    }
        //    //IF logoUrl is still null, throw exception
        //    if (string.IsNullOrEmpty(logoUrl))
        //        throw new Exception("Could not identify Company Logo Url.  Url: " + logoUrl);


        //    //Check to see if this object exists in the database.
        //    partpicture f = (partpicture)x.QtO("partpicture", "select * from partpicture where fullpartnumber = '" + logoUrl + "' ");
        //    if (f == null)
        //    {
        //        //IF Not, let's add a new one, probably lazy progrtamming tho
        //        f = new partpicture();
        //        f.fullpartnumber = logoUrl;
        //        f.SetPictureDataByFile(x, logoPath);
        //        f.Insert(x);

        //    }

        //    //Set the path of the locally Stored Logo    
        //    //Tools.Picture.GetFilePathFromLogoUrl(logoUrl, out logoPath);

        //    return logoPath;
        //}




        public static String AssociateWithHTML(ContextRz context, String html)
        {
            return ParseDefaultCompanySettings(context, html, true);
        }
        public static String ParseDefaultCompanySettings(ContextRz context, String line)
        {
            return ParseDefaultCompanySettings(context, line, false);
        }
        public static String ParseDefaultCompanySettings(ContextRz context, String line, Boolean bHTML)
        {
            String[] values = ParseCompanySettingValues(line);
            String value = line;
            foreach (String s in values)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                value = value.Replace("<owner_settings." + s.Trim() + ">", OwnerSettings.GetValue(context, s.Trim(), bHTML));
            }
            value = value.TrimEnd(((String)"\r\n").ToCharArray());
            return value;
        }
        public static String GetAddressBlock(ContextRz context)
        {
            return GetAddressBlock(context, false);
        }
        public static String GetAddressBlock(ContextRz context, Boolean bHTML)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(OwnerSettings.GetValue(context, OwnerSettingField.owner_address1, bHTML));
            if (Tools.Strings.StrExt(OwnerSettings.GetValue(context, OwnerSettingField.owner_address2, bHTML)))
                sb.AppendLine(OwnerSettings.GetValue(context, OwnerSettingField.owner_address2, bHTML));
            sb.AppendLine(OwnerSettings.GetValue(context, OwnerSettingField.owner_city, bHTML) + ", " + OwnerSettings.GetValue(context, OwnerSettingField.owner_state, bHTML) + "  " + OwnerSettings.GetValue(context, OwnerSettingField.owner_zip, bHTML) + "  " + OwnerSettings.GetValue(context, OwnerSettingField.owner_country, bHTML));
            String pf = "";
            if (Tools.Strings.StrExt(OwnerSettings.GetValue(context, OwnerSettingField.owner_phone, bHTML)))
                pf = "P. " + OwnerSettings.GetValue(context, OwnerSettingField.owner_phone, bHTML);
            if (Tools.Strings.StrExt(OwnerSettings.GetValue(context, OwnerSettingField.owner_fax, bHTML)))
            {
                if (Tools.Strings.StrExt(pf))
                    pf += " F. " + OwnerSettings.GetValue(context, OwnerSettingField.owner_fax, bHTML);
                else
                    pf = "F. " + OwnerSettings.GetValue(context, OwnerSettingField.owner_fax, bHTML);
            }
            if (Tools.Strings.StrExt(pf))
                sb.AppendLine(pf);
            String ret = sb.ToString();
            if (bHTML)
                ret = ret.Replace("\r\n", "<br>");
            if (Tools.Strings.StrExt(ret))
                ret = ret.TrimEnd(((String)"<br>").ToCharArray());
            if (Tools.Strings.StrCmp(ret, ","))
                ret = "";
            return Tools.Strings.KillBlankLines(ret);
        }
        //Private Static Functions
        private static String[] ParseCompanySettingValues(String line)
        {
            StringBuilder sb = new StringBuilder();
            if (Tools.Strings.HasString(line, "\n"))
            {
                String parseby = "\n";
                if (Tools.Strings.HasString(line, "\r\n"))
                    parseby = "\r\n";
                String[] lines = Tools.Strings.Split(line, parseby);
                foreach (String s in lines)
                {
                    String ret = ParseCompanySettingLine(s.Trim());
                    if (Tools.Strings.StrExt(ret))
                        sb.AppendLine(ret);
                }
            }
            else
                sb.AppendLine(ParseCompanySettingLine(line));
            return Tools.Strings.Split(sb.ToString(), "\r\n");
        }
        private static String ParseCompanySettingLine(String line)
        {
            ArrayList a = new ArrayList();
            StringBuilder sb = new StringBuilder();
            Char[] chars = line.ToCharArray();
            String build = "";
            bool building = false;
            foreach (char c in chars)
            {
                if (Tools.Strings.StrCmp(c.ToString(), "<") && !building)
                {
                    build = "<";
                    building = true;
                    continue;
                }
                if (Tools.Strings.StrCmp(c.ToString(), ">") && building)
                {
                    build += ">";
                    building = false;
                    a.Add(build);
                    continue;
                }
                if (building)
                    build += c.ToString();
            }
            foreach (String s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                String text = s.Replace("<", "").Replace(">", "").Trim();
                if (!Tools.Strings.StrCmp(Tools.Strings.ParseDelimit(text, ".", 1).Trim(), "owner_settings"))
                    continue;
                String value = Tools.Strings.ParseDelimit(text, ".", 2).Trim();
                if (!Tools.Strings.StrExt(value))
                    continue;
                sb.AppendLine(value);
            }
            return sb.ToString();
        }

    }







    public class UserPanelSection
    {
        public string UIDField = "";
        public string KeyField = "";
        public ArrayList AllSections = new ArrayList();
        public string SectionName = "";
        public string GraphicImage = "";
        public string SQL = "";
    }

    public enum SearchComparison
    {
        Normal = 0,
        Fuzzy = 1,
        Exact = 2,
    }

    //public enum CompanyFlag
    //{
    //    Bozz = 0,
    //    Legend = 1,
    //    Ultimate = 2,
    //    EarthTron = 3,
    //    Atometron = 4,
    //    AAT = 5,
    //    PMT = 6,
    //    INet = 7,
    //    Axiom = 8,
    //    NTC = 9,
    //    Nasco = 10,
    //    Merit = 11,
    //    Pipeline = 12,
    //    Tesla = 13,
    //    Phoenix = 14,
    //    CI = 15,
    //    BasicEParts = 16,
    //    Select = 17,
    //    Isttar = 18,
    //    Arrowtronics = 19,
    //    Kimtronics = 20,
    //    Voxx = 21,
    //    Integrity = 22,
    //    Prism = 23,
    //    GemTek = 24,
    //    TES = 25,
    //    Iconix = 26,
    //    Voyager = 27,
    //    Concord = 28,
    //    SensibleMicro = 29,
    //    MarketPlace = 30,
    //    G2 = 31,
    //}

    public class ConcernHandle
    {
        public String Name = "";
        public String Description = "";
        public DateTime Last;
        public DateTime Accept;
        public TimeSpan TimeLeft;
        public long Threshold;
        public String Status;
        public ArrayList Points = new ArrayList();
        public String GetHTML(int colcount, String strPic, String strClass, bool include_link, System.Drawing.Color color)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("		<tr >");

                if (include_link)
                    sb.AppendLine("			<td nowrap class=\"alignLeft\"><a href=\"concern.rzl?name=" + Name + "\">" + Name + "</a></td>");
                else
                    sb.AppendLine("			<td nowrap class=\"alignLeft\">" + Name + "</td>");

                sb.AppendLine("			<td nowrap class=\"alignRight\">" + nTools.DateFormat_ShortDateTime(Last) + "</td>");
                foreach (long l in Points)
                {
                    sb.AppendLine("			<td nowrap class=\"alignRight\"><font color=\"" + Tools.Html.GetHTMLColor(color) + "\">" + Tools.Number.LongFormat(l) + "</font></td>");
                }
                sb.AppendLine("			<td nowrap class=\"alignRight\"><span class=\"" + strClass + "\">" + Status + "</span><img src=\"http://www.recognin.com/" + strPic + ".gif\" width=\"16\" height=\"16\" /></td>");
                sb.AppendLine("		</tr>");
                if (Tools.Strings.StrExt(Description))
                    sb.AppendLine("		<tr><td colspan=\"" + colcount.ToString() + "\"><font size=\"2\" color=\"#C0C0C0\">" + Description + "</font></td></tr>");
                return sb.ToString();
            }
            catch
            {
                return "error";
            }
        }
    }

    public interface IAssignedAgent
    {
        n_user UserObjectGet(ContextRz context);
        void UserObjectSet(n_user value);
        String UserID { get; set; }
        String UserName { get; set; }
        String ClassId { get; }
        String GetExtraClassInfo();
    }

    public partial class PartCrossReferenceResults
    {
        //Public Variables
        public ListArgs results_Stock;
        public ListArgs results_Consign;
        public ListArgs results_Excess;
        //KT
        //KT Refactored from RzSensible - PartCrossReferenceResults_Sensible.cs
        //public ListArgs_Sensible results_LowestSalesPrice;
        //public ListArgs_Sensible results_AvgSalesPrice;
        //public ListArgs_Sensible results_LowestPurchasePrice;
        //public ListArgs_Sensible results_AvgPurchasePrice;
        public ListArgs results_LowestSalesPrice;
        public ListArgs results_AvgSalesPrice;
        public ListArgs results_LowestPurchasePrice;
        public ListArgs results_AvgPurchasePrice;



        //KT
        public ListArgs results_Master;
        public ListArgs results_Req;
        public ListArgs results_Bid;
        public ListArgs results_Quote;
        public ListArgs results_Sales;
        public ListArgs results_Invoice;
        public ListArgs results_Purchase;
        public ListArgs results_RMA;
        public ListArgs results_vRMA;
        public ListArgs results_Service;
        //Protected Variables
        protected ContextNM TheContext;

        //Constructors
        public PartCrossReferenceResults(ContextNM x)
        {
            TheContext = x;
        }
    }

    public partial class PartCrossReferenceSearchOptions
    {
        public string SQL_FieldCalledAs
        {
            get { return "part_number"; }
        }
        public string SQL_String
        {
            get
            {
                string where = "";
                if (Tools.Strings.StrExt(SQL_Where))
                    where = "where " + SQL_Where;
                return "select " + SQL_PartField + " as part_number from " + SQL_Table + " " + where;
            }
        }
        public string SQL_Where = "";
        public string SQL_Table = "";
        public string SQL_PartField = "";
        public string SQL_KeyFieldValue = "";
        public bool search_Stock = false;
        public bool search_Consign = false;
        public bool search_Excess = false;
        public bool search_Req = false;
        public bool search_Bid = false;
        public bool search_Quote = false;
        public bool search_Sales = false;
        public bool search_Invoice = false;
        public bool search_Purchase = false;
        public bool search_RMA = false;
        public bool search_vRMA = false;
        //KT
        public bool search_Master = false;
        public bool search_Service = false;
        public bool search_LowestSalesPrice = false;
        public double search_LowestSalesPricePercent = 0;
        public string search_LowestSalesPriceComparison = "";
        public bool search_AvgSalesPrice = false;
        public double search_AvgSalesPricePercent = 0;
        public string search_AvgSalesPriceComparison = "";
        public bool search_LowestPurchasePrice = false;
        public double search_LowestPurchasePricePercent = 0;
        public string search_LowestPurchasePriceComparison = "";
        public bool search_AvgPurchasePrice = false;
        public double search_AvgPurchasePricePercent = 0;
        public string search_AvgPurchasePriceComparison = "";
    }
}