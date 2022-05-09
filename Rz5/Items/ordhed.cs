using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

using OfficeInterop;
using Tools;
using Core;
using Core.Display;
using NewMethod;
using Tools.Database;
using Rz5.Enums;
using HubspotApis;
using System.Linq;

namespace Rz5
{
    public partial class ordhed : ordhed_auto, IAssignedAgent
    {


        public virtual IVarRefOrderLines Details
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //[CoreVarRefSingle("Company", "Rz4.ordhed", "Rz4.company", "", "base_company_uid")]
        public OrderCompanyVar CompanyVar;

        //[CoreVarRefSingle("Contact", "Rz4.ordhed", "Rz4.companycontact", "", "base_companycontact_uid")]
        public OrderContactVar ContactVar;

        //[CoreVarRefSingle("Agent", "Rz4.ordhed", "Rz4.n_user", "", "base_mc_user_uid")]
        public OrderAgentVar AgentVar;

        //[CoreVarRefSingle("LinksFrom", "Rz4.ordhed", "Rz4.ordlnk", "Order1", "orderid1")]
        public VarRefMany<ordhed, ordlnk> LinksFromVar;

        //[CoreVarRefSingle("LinksTo", "Rz4.ordhed", "Rz4.ordlnk", "Order2", "orderid2")]
        public VarRefMany<ordhed, ordlnk> LinksToVar;

        //LinksFromVar = new VarRefMany<ordhed, ordlnk>(this, new CoreVarRefManyAttribute("LinksFrom", "Rz4.ordhed", "Rz4.ordlnk", "Order1", "orderid1"));
        //LinksToVar = new VarRefMany<ordhed, ordlnk>(this, new CoreVarRefManyAttribute("LinksTo", "Rz4.ordhed", "Rz4.ordlnk", "Order2", "orderid2"));


        //KT - 11-30-2015 - form ordhed_purchase.cs  CoreVarRefMany - For use  below, in including CompanyCredit on Printable
        //[CoreVarRefMany("CompanyCredit", "ordhed_purchase", "companycredit", "Purchase", "purchase_order_uid")]
        public VarRefMany<ordhed, companycredit> CompanyCreditVar;
        //public VarRefMany<ordhed, companycredit> AppliedToOrderVar; 


        public override List<Var> VarsGetInitially()
        {
            List<Var> ret = base.VarsGetInitially();
            ret.Add(CompanyVar);
            ret.Add(ContactVar);
            ret.Add(AgentVar);
            ret.Add(LinksFromVar);
            ret.Add(LinksToVar);

            //KT 11-30-2015
            ret.Add(CompanyCreditVar);
            //ret.Add(AppliedToOrderVar); 

            return ret;
        }

        public virtual int PictureCount(ContextRz x, bool countLines = true, String extraWhere = "")
        {
            throw new NotImplementedException();

        }

        public override Var VarGetByName(string name)
        {
            switch (name.ToLower().Trim())
            {
                case "details":
                    return (Var)Details;
                case "company":
                    return CompanyVar;
                case "contact":
                    return ContactVar;
                case "agent":
                    return AgentVar;
                case "linksfrom":
                    return LinksFromVar;
                case "linksto":
                    return LinksToVar;
                case "companycredit":
                    return CompanyCreditVar;
                //case "appliedtoorder":
                //    return AppliedToOrderVar; 
                default:
                    return base.VarGetByName(name);
            }
        }

        public int TempCopyCount = 0;
        private ordrma m_LinkedRMA;
        public ordrma LinkedRMAGet(ContextRz context)
        {
            if (m_LinkedRMA == null)
                GetLinkedRMASummary(context);
            return m_LinkedRMA;
        }

        public void LinkedRMASet(ordrma value)
        {
            m_LinkedRMA = value;
        }

        private ArrayList m_AllTransactions;
        public ArrayList AllTransactionsGet(ContextRz context)
        {
            //KT 8-16-2016 This was prevent totals from being updated on PAyment.cs when deleting from lv.  Since the deleted payment
            //was in m_AllTransactions, GatherTransactions was never getting fired, thus the old transaction kept being included in the calcs.  This method
            //is called by AmountPaid() from many places.  
            //if (m_AllTransactions == null)
            GatherTransactions(context);
            return m_AllTransactions;
        }

        public void AllTransactionsSet(ArrayList value)
        {
            m_AllTransactions = value;
        }

        private Dictionary<String, Item> m_Hits = null;
        public Dictionary<String, Item> GetHits(ContextRz context)
        {
            if (m_Hits == null)
            {
                m_Hits = context.TheData.QtD(context, "ordhit", "select * from ordhit where the_ordhed_uid = '" + this.unique_id + "' order by date_created");
            }
            return m_Hits;
        }
        //Constructor
        public ordhed()
        {
            CompanyVar = new OrderCompanyVar(this);
            ContactVar = new OrderContactVar(this);
            AgentVar = new OrderAgentVar(this);
            LinksFromVar = new VarRefMany<ordhed, ordlnk>(this, new CoreVarRefManyAttribute("LinksFrom", "Rz4.ordhed", "Rz4.ordlnk", "Order1", "orderid1"));
            LinksToVar = new VarRefMany<ordhed, ordlnk>(this, new CoreVarRefManyAttribute("LinksTo", "Rz4.ordhed", "Rz4.ordlnk", "Order2", "orderid2"));

            //KT 11-30-2015
            CompanyCreditVar = new VarRefMany<ordhed, companycredit>(this, new CoreVarRefManyAttribute("CompanyCredit", "ordhed", "companycredit", "ordhed", "base_ordhed_uid"));
            //[CoreVarRefMany("CompanyCredit", "ordhed_purchase", "companycredit", "Purchase", "purchase_order_uid")]
        }
        ~ordhed()
        {
            try
            {
                CompanyVar.Dispose();
                ContactVar.Dispose();
                AgentVar.Dispose();
                LinksFromVar.Dispose();
                LinksToVar.Dispose();

                //KT 11-30-2015
                CompanyCreditVar.Dispose();
                m_AllTransactions = null;
            }
            finally
            {
                //base.Finalize();
            }
        }
        //Public Static Functions
        public static Enums.StockType AskForStockType(String strCaption)
        {
            return AskForStockType(strCaption);
        }

        public static ordhed CreateNew(ContextRz context, Enums.OrderType type)
        {
            ordhed xOrder = (ordhed)context.Item("ordhed_" + type.ToString().ToLower());
            xOrder.orderdate = DateTime.Now;
            xOrder.dockdate = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0));
            xOrder.base_mc_user_uid = ((ContextRz)context).xUser.unique_id;
            xOrder.agentname = ((ContextRz)context).xUser.name;
            xOrder.orderbuyerid = ((ContextRz)context).xUser.unique_id;
            xOrder.buyername = ((ContextRz)context).xUser.name;
            xOrder.ordernumber = context.TheSysRz.TheOrderLogic.GetNextNumber(context, type);
            xOrder.Insert(context);

            //Set 1st Validation Stage "Pre-Validation"
            if (type == Enums.OrderType.Sales)
            {

                ordhed_sales s = (ordhed_sales)xOrder;
                //ordhed_sales.GetById(context, xOrder.unique_id);
                s.validation_stage = Enums.SalesOrderValidationStage.PreValidation.ToString();
                s.Update(context);
                //SendNewSOPrevalidationEmail(context, s);
            }

            if (type == Enums.OrderType.Purchase)
            {
                ordhed_purchase p = (ordhed_purchase)xOrder;
                //s.Update(context); 
                //SendNewSOPrevalidationEmail(context, s);
            }


            return xOrder;
        }


        public static String MakeOrdhedName(String strType)
        {
            return "ordhed_" + strType.ToLower();
        }
        public static String MakeOrdhedName(Enums.OrderType ot)
        {
            return "ordhed_" + ot.ToString().ToLower();
        }
        public static String MakeOrddetName(String strType)
        {
            switch (strType)
            {
                case "quote":
                case "rfq":
                    return "orddet_" + strType.ToLower();

                default:
                    return "orddet_line";
            }
        }
        public static String MakeOrddetName(Enums.OrderType ot)
        {
            return "orddet_" + ot.ToString().ToLower();
        }
        public static bool CalcOrders(ContextRz context, ArrayList users, Tools.Dates.DateRange dr, String strTable, String strTable2, String strOrderType, String strPartField, bool MergeAssistants, bool ExcludeDistributors, bool ExcludeManagers)
        {
            String strHeaderTable = MakeOrdhedName(strOrderType);
            String strDetailTable = MakeOrddetName(strOrderType);
            context.TheLeader.Comment("Calculating " + strOrderType + "s...");
            context.Execute("create table " + strTable + " (quick_uid varchar(50), order_uid varchar(50), company_uid varchar(50), contact_uid varchar(50), contactname varchar(255), the_n_user_uid varchar(255), original_n_user_uid varchar(255), user_name varchar(255), quote_part varchar(255), basenumberstripped varchar(255), quote_company varchar(255), quote_date datetime, profit float, primaryemailaddress varchar(255), primaryphone varchar(255))");
            String strSQL = "";
            //no longer needed
            //if(Tools.Strings.StrCmp(strOrderType, "quote"))
            //{
            //    //Quick quotes
            //    strSQL = "insert into " + strTable + "( quick_uid, order_uid, company_uid, contact_uid, contactname, the_n_user_uid, quote_part, basenumberstripped, quote_company, quote_date ) select unique_id, '' as order_uid, base_company_uid, base_companycontact_uid, contactname, base_mc_user_uid, fullpartnumber, basenumberstripped, companyname, quotedate from quote where quotetype = 'giving out' and " + dr.GetSQL("quotedate");
            //    Rz3App.context.Execute(strSQL);
            //}
            //Formal quotes
            if (Tools.Strings.StrCmp(strOrderType, "quote"))
                strSQL = "insert into " + strTable + "( quick_uid, order_uid, company_uid, contact_uid, contactname, the_n_user_uid, quote_part, basenumberstripped, quote_company, quote_date, profit, primaryemailaddress, primaryphone ) select '' as quick_uid, " + strHeaderTable + ".unique_id as order_uid, " + strHeaderTable + ".base_company_uid as company_uid, " + strHeaderTable + ".base_companycontact_uid, " + strHeaderTable + ".contactname, " + strHeaderTable + ".base_mc_user_uid, " + strDetailTable + ".fullpartnumber, " + strDetailTable + ".basenumberstripped, " + strHeaderTable + ".companyname, " + strHeaderTable + ".orderdate, max(isnull(" + strDetailTable + ".lineprofit, 0)), " + strHeaderTable + ".primaryemailaddress, " + strHeaderTable + ".primaryphone from " + strHeaderTable + " inner join " + strDetailTable + " on " + strDetailTable + ".base_ordhed_uid = " + strHeaderTable + ".unique_id where isnull(" + strHeaderTable + ".isvoid, 0) = 0 and " + strHeaderTable + ".ordertype = '" + strOrderType + "' and " + dr.GetSQL(strHeaderTable + ".orderdate") + " and " + strDetailTable + ".quantityordered > 0 and " + strDetailTable + ".unitprice > 0 group by " + strHeaderTable + ".unique_id, " + strHeaderTable + ".base_company_uid, " + strHeaderTable + ".base_companycontact_uid, " + strHeaderTable + ".contactname, " + strHeaderTable + ".base_mc_user_uid, fullpartnumber, basenumberstripped, " + strHeaderTable + ".companyname, " + strHeaderTable + ".orderdate, " + strHeaderTable + ".primaryemailaddress, " + strHeaderTable + ".primaryphone";
            else
                strSQL = "insert into " + strTable + "( quick_uid, order_uid, company_uid, contact_uid, contactname, the_n_user_uid, quote_part, basenumberstripped, quote_company, quote_date, profit, primaryemailaddress, primaryphone ) select '' as quick_uid, " + strHeaderTable + ".unique_id as order_uid, " + strHeaderTable + ".base_company_uid as company_uid, " + strHeaderTable + ".base_companycontact_uid, " + strHeaderTable + ".contactname, " + strHeaderTable + ".base_mc_user_uid, " + strDetailTable + ".fullpartnumber, " + strDetailTable + ".basenumberstripped, " + strHeaderTable + ".companyname, " + strHeaderTable + ".orderdate, max(isnull(" + strDetailTable + ".gross_profit, 0)), " + strHeaderTable + ".primaryemailaddress, " + strHeaderTable + ".primaryphone from " + strHeaderTable + " inner join " + strDetailTable + " on " + strDetailTable + ".orderid_" + strOrderType.ToLower() + " = " + strHeaderTable + ".unique_id where isnull(" + strHeaderTable + ".isvoid, 0) = 0 and " + dr.GetSQL(strHeaderTable + ".orderdate") + " and " + strDetailTable + ".quantity > 0 and " + strDetailTable + ".unit_price > 0 group by " + strHeaderTable + ".unique_id, " + strHeaderTable + ".base_company_uid, " + strHeaderTable + ".base_companycontact_uid, " + strHeaderTable + ".contactname, " + strHeaderTable + ".base_mc_user_uid, fullpartnumber, basenumberstripped, " + strHeaderTable + ".companyname, " + strHeaderTable + ".orderdate, " + strHeaderTable + ".primaryemailaddress, " + strHeaderTable + ".primaryphone";
            context.Execute(strSQL);
            //Get Assistants (Original Rz code)
            ((SysRz5)context.xSys).TheOrderLogic.CalcOrdersExtra(context, strTable, ExcludeManagers, MergeAssistants);
            //aggregate them
            if (Tools.Strings.StrCmp(strPartField, "fullpartnumber"))
                strSQL = "select max(quick_uid) as quick_uid, max(order_uid) as order_uid, company_uid, contact_uid, contactname, the_n_user_uid, original_n_user_uid, quote_part, basenumberstripped, quote_company, max(quote_date) as quote_date, cast(0 as int) as invoiced, cast(0 as float) as sold_profit, max(profit) as profit, max(primaryemailaddress) as primaryemailaddress, max(primaryphone) as primaryphone into " + strTable2 + " from " + strTable + " group by company_uid, contact_uid, contactname, the_n_user_uid, original_n_user_uid, quote_part, basenumberstripped, quote_company";
            else
                strSQL = "select max(quick_uid) as quick_uid, max(order_uid) as order_uid, company_uid, contact_uid, contactname, the_n_user_uid, original_n_user_uid, max(quote_part) as quote_part, basenumberstripped, quote_company, max(quote_date) as quote_date, cast(0 as int) as invoiced, cast(0 as float) as sold_profit, max(profit) as profit, max(primaryemailaddress) as primaryemailaddress, max(primaryphone) as primaryphone into " + strTable2 + " from " + strTable + " group by company_uid, contact_uid, contactname, the_n_user_uid, original_n_user_uid, basenumberstripped, quote_company";
            context.Execute(strSQL);
            //remove blanks
            strSQL = "delete from " + strTable2 + " where isnull(quote_company, '') = '' or isnull(quote_part, '') = ''";
            context.Execute(strSQL);
            if (ExcludeDistributors)
            {
                //remove distributors
                strSQL = "alter table " + strTable2 + " add is_dist bit";
                context.Execute(strSQL);
                strSQL = "update " + strTable2 + " set is_dist = 1 where exists( select * from company where company.unique_id = " + strTable2 + ".company_uid and company.abs_type = 'dist')";
                context.Execute(strSQL);
                strSQL = "update " + strTable2 + " set is_dist = 1 where exists( select * from companycontact where companycontact.unique_id = " + strTable2 + ".contact_uid and companycontact.abs_type = 'dist')";
                context.Execute(strSQL);
                strSQL = "delete from " + strTable2 + " where isnull(is_dist, 0) = 1";
                context.Execute(strSQL);
            }
            return true;
        }
        public static bool PrepareTable3(ContextRz context, Tools.Dates.DateRange dr, String strTable2, String strTable3, bool include_phone, bool include_lag, bool include_same_day, bool merge_assistants)
        {
            String strSQL = "create table " + strTable3 + "( the_n_user_uid varchar(255), user_name varchar(255), quote_count int, invoiced_count int, invoiced_percent float, small_quotes int, large_quotes int, small_sales int, large_sales int, quote_profit float, sold_profit float)";
            context.Execute(strSQL);
            strSQL = "insert into " + strTable3 + "(the_n_user_uid) select distinct(the_n_user_uid) from " + strTable2 + " ";    //all users, even if there are quotes but no invoices
            context.Execute(strSQL);
            strSQL = "update " + strTable3 + " set user_name = (select max(name) from n_user where n_user.unique_id = " + strTable3 + ".the_n_user_uid)";
            context.Execute(strSQL);
            strSQL = "update " + strTable3 + " set quote_count = (select count(*) from " + strTable2 + " where " + strTable2 + ".the_n_user_uid = " + strTable3 + ".the_n_user_uid)";
            context.Execute(strSQL);
            strSQL = "alter table " + strTable3 + " add deals_in_range int";
            context.Execute(strSQL);
            strSQL = "update " + strTable3 + " set deals_in_range = (select count(*) from " + strTable2 + " where " + strTable2 + ".the_n_user_uid = " + strTable3 + ".the_n_user_uid and invoiced > 0)";
            context.Execute(strSQL);
            bool phone_archive = false;
            if (include_phone)
            {
                phone_archive = context.TheData.TableExists("phonecall_sys_archive");
                strSQL = "alter table " + strTable3 + " add phone_seconds int";
                context.Execute(strSQL);
                strSQL = "update " + strTable3 + " set phone_seconds = (select isnull(sum(duration), 0) from phonecall where phonecall.base_mc_user_uid = " + strTable3 + ".the_n_user_uid and " + dr.GetSQL("calldate") + " ";
                if (phone_archive)
                    strSQL += " and isnull(sys_archive_flag, 0) = 0 ";
                strSQL += ") ";
                context.Execute(strSQL);
                if (phone_archive)
                {
                    strSQL = "update " + strTable3 + " set phone_seconds = phone_seconds + (select isnull(sum(duration), 0) from phonecall_sys_archive where phonecall_sys_archive.base_mc_user_uid = " + strTable3 + ".the_n_user_uid and " + dr.GetSQL("calldate") + " ) ";
                    context.Execute(strSQL);
                }
                if (merge_assistants)    //add the assistants' time
                {
                    ArrayList ahs = ((ContextRz)context).Logic.GetAssistantHandles(context);
                    foreach (AssistantHandle ah in ahs)
                    {
                        try
                        {
                            strSQL = "update " + strTable3 + " set phone_seconds = phone_seconds + (select isnull(sum(duration), 0) from phonecall where phonecall.base_mc_user_uid = '" + ah.AssistantUser.unique_id + "' and " + dr.GetSQL("calldate") + " ";
                            if (phone_archive)
                                strSQL += " and isnull(sys_archive_flag, 0) = 0 ";
                            strSQL += ") where " + strTable3 + ".the_n_user_uid = '" + ah.ManagerUser.unique_id + "'";
                            context.Execute(strSQL);
                            if (phone_archive)
                            {
                                strSQL = "update " + strTable3 + " set phone_seconds = phone_seconds + (select isnull(sum(duration), 0) from phonecall_sys_archive where phonecall_sys_archive.base_mc_user_uid = '" + ah.AssistantUser.unique_id + "' and " + dr.GetSQL("calldate") + " ) where " + strTable3 + ".the_n_user_uid = '" + ah.ManagerUser.unique_id + "'";
                                context.Execute(strSQL);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            if (include_lag)
            {
                strSQL = "alter table " + strTable3 + " add average_lag float";
                context.Execute(strSQL);
                strSQL = "update " + strTable3 + " set average_lag = (select avg(datediff(d, quote_date, earliest_sale_date) * 1.0) from " + strTable2 + " where " + strTable2 + ".the_n_user_uid = " + strTable3 + ".the_n_user_uid and earliest_sale_date is not null )";
                context.Execute(strSQL);
            }
            if (include_same_day)
            {
                strSQL = "alter table " + strTable2 + " add call_same_day int, email_same_day int";
                context.Execute(strSQL);
                //bring in the phone stats
                context.Execute("alter table " + strTable2 + " add phone varchar(255)");
                context.Execute("update " + strTable2 + " set phone  = (select max(primaryphone) from companycontact where companycontact.unique_id = " + strTable2 + ".contact_uid) where isnull(contact_uid, '') > ''");
                context.Execute("update " + strTable2 + " set phone  = (select max(primaryphone) from company where company.unique_id = " + strTable2 + ".company_uid) where isnull(company_uid, '') > '' and isnull(phone, '') = ''");
                nTools.StripPhoneNumberField(context.TheData.TheConnection, strTable2, "phone");
                phone_archive = context.TheData.TableExists("phonecall_sys_archive");
                strSQL = "update " + strTable2 + " set call_same_day = (select isnull(count(*), 0) from phonecall where phonecall.direction <> 'in' and phonecall.base_mc_user_uid = " + strTable2 + ".the_n_user_uid and phonecall.strippedphone = " + strTable2 + ".phone and datediff(d, calldate, " + strTable2 + ".quote_date) = 0 ";
                if (phone_archive)
                    strSQL += " and isnull(sys_archive_flag, 0) = 0 ";
                strSQL += " ) where isnull(phone, '') > ''";
                context.Execute(strSQL);
                if (phone_archive)
                {
                    strSQL = "update " + strTable2 + " set call_same_day = call_same_day + (select isnull(count(*), 0) from phonecall_sys_archive where phonecall_sys_archive.direction <> 'in' and phonecall_sys_archive.base_mc_user_uid = " + strTable2 + ".the_n_user_uid and phonecall_sys_archive.strippedphone = " + strTable2 + ".phone and datediff(d, calldate, " + strTable2 + ".quote_date) = 0) where isnull(phone, '') > ''";
                    context.Execute(strSQL);
                }
                //email stats
                strSQL = "alter table " + strTable3 + " add call_same_day_count int, call_same_day_percent float, email_same_day_count int, email_same_day_percent float";
                context.Execute(strSQL);
                strSQL = "update " + strTable3 + " set call_same_day_count = (select count(*) from " + strTable2 + " where " + strTable2 + ".the_n_user_uid = " + strTable3 + ".the_n_user_uid and call_same_day > 0)";
                context.Execute(strSQL);
                strSQL = "update " + strTable3 + " set call_same_day_percent = (select cast(((call_same_day_count * 1.0) / (quote_count * 1.0)) * 100.0 as int)) where quote_count > 0";
                context.Execute(strSQL);
            }
            //small_quotes as [< $1000], large_quotes as [$1000+], quote_profit as [Quoted Profit], sold_profit as [Sold Profit]
            //strSQL = "alter table " + strTable3 + " add small_quotes int, large_quotes int, quote_profit float, sold_profit float";
            //Rz3App.context.Execute(strSQL);
            strSQL = "update " + strTable3 + " set small_quotes = (select count(*) from " + strTable2 + " where " + strTable2 + ".the_n_user_uid = " + strTable3 + ".the_n_user_uid and profit < 1000)";
            context.Execute(strSQL);
            strSQL = "update " + strTable3 + " set large_quotes = (select count(*) from " + strTable2 + " where " + strTable2 + ".the_n_user_uid = " + strTable3 + ".the_n_user_uid and profit >= 1000)";
            context.Execute(strSQL);
            strSQL = "update " + strTable3 + " set small_sales = (select count(*) from " + strTable2 + " where " + strTable2 + ".the_n_user_uid = " + strTable3 + ".the_n_user_uid and sold_profit < 1000)";
            context.Execute(strSQL);
            strSQL = "update " + strTable3 + " set large_sales = (select count(*) from " + strTable2 + " where " + strTable2 + ".the_n_user_uid = " + strTable3 + ".the_n_user_uid and sold_profit >= 1000)";
            context.Execute(strSQL);
            strSQL = "update " + strTable3 + " set quote_profit = (select sum(profit) from " + strTable2 + " where " + strTable2 + ".the_n_user_uid = " + strTable3 + ".the_n_user_uid)";
            context.Execute(strSQL);
            strSQL = "update " + strTable3 + " set sold_profit = (select sum(isnull(sold_profit, 0)) from " + strTable2 + " where " + strTable2 + ".the_n_user_uid = " + strTable3 + ".the_n_user_uid)";
            context.Execute(strSQL);
            return true;
        }
        public static void MatchWithSales(ContextNM context, String strTable2, bool UseLimit, int days)
        {
            //match with sales
            context.TheLeader.Comment("Calculating sales...");
            String strSQL = "update " + strTable2 + " set invoiced = ( select count(*) from ordhed_invoice inner join orddet_line on orddet_line.orderid_invoice = ordhed_invoice.unique_id where ( ordhed_invoice.base_mc_user_uid = " + strTable2 + ".the_n_user_uid or ordhed_invoice.base_mc_user_uid = " + strTable2 + ".original_n_user_uid ) and ordhed_invoice.companyname = " + strTable2 + ".quote_company and orddet_line.basenumberstripped = " + strTable2 + ".basenumberstripped and ordhed_invoice.orderdate >= " + strTable2 + ".quote_date ";
            if (UseLimit)
                strSQL += " and ordhed_invoice.orderdate <= dateadd(d, " + days.ToString() + ", " + strTable2 + ".quote_date ) ";
            strSQL += " )";
            context.Execute(strSQL);
            context.TheLeader.Comment("Calculating sale amount...");
            strSQL = "update " + strTable2 + " set sold_profit = ( select sum(orddet_line.gross_profit) from ordhed_invoice inner join orddet_line on orddet_line.orderid_invoice = ordhed_invoice.unique_id where ( ordhed_invoice.base_mc_user_uid = " + strTable2 + ".the_n_user_uid or ordhed_invoice.base_mc_user_uid = " + strTable2 + ".original_n_user_uid ) and ordhed_invoice.companyname = " + strTable2 + ".quote_company and orddet_line.basenumberstripped = " + strTable2 + ".basenumberstripped and ordhed_invoice.orderdate >= " + strTable2 + ".quote_date ";
            if (UseLimit)
                strSQL += " and ordhed_invoice.orderdate <= dateadd(d, " + days.ToString() + ", " + strTable2 + ".quote_date ) ";
            strSQL += " )";
            context.Execute(strSQL);
            //calculate the earliest sale
            context.Execute("alter table " + strTable2 + " add earliest_sale_date datetime");
            strSQL = "update " + strTable2 + " set earliest_sale_date = ( select min(ordhed_invoice.orderdate) from ordhed_invoice inner join orddet_line on orddet_line.orderid_invoice = ordhed_invoice.unique_id where ( ordhed_invoice.base_mc_user_uid = " + strTable2 + ".the_n_user_uid or ordhed_invoice.base_mc_user_uid = " + strTable2 + ".original_n_user_uid ) and ordhed_invoice.companyname = " + strTable2 + ".quote_company and orddet_line.basenumberstripped = " + strTable2 + ".basenumberstripped and ordhed_invoice.orderdate >= " + strTable2 + ".quote_date ";
            if (UseLimit)
                strSQL += " and ordhed_invoice.orderdate <= dateadd(d, " + days.ToString() + ", " + strTable2 + ".quote_date ) ";
            strSQL += " )";
            context.Execute(strSQL);
        }
        public static void MatchWithQuotes(ContextNM x, String strTable2, bool UseLimit, int days)
        {
            MatchWithQuotes(x, strTable2, UseLimit, days, "quote_date", "quote_company", "quote_company", "the_n_user_uid", "original_n_user_uid", "invoiced", "latest_quote_date", false, true); //using the invoiced field doesn't make sense, but the default caller expects it
        }
        public static void MatchWithQuotes(ContextNM x, String strTable2, bool UseLimit, int days, String date_compare_field, String company_compare_field, String email_compare_field, String user_compare_field, String user_compare_field2, String count_field, String date_result_field, bool ignore_agent_matching, bool quotes_before_info)
        {
            MatchWithOrders(x, strTable2, UseLimit, days, date_compare_field, company_compare_field, email_compare_field, user_compare_field, user_compare_field2, count_field, date_result_field, ignore_agent_matching, quotes_before_info, "quote");
        }
        public static void MatchWithOrders(ContextNM x, String strTable2, bool UseLimit, int days, String date_compare_field, String company_compare_field, String email_compare_field, String user_compare_field, String user_compare_field2, String count_field, String date_result_field, bool ignore_agent_matching, bool quotes_before_info, String strOrderType)
        {
            String strDateComparison = "<=";
            String strLimitComparison = ">=";
            String strLimitSymbol = "-";
            if (!quotes_before_info)
            {
                strDateComparison = ">=";
                strLimitComparison = "<=";
                strLimitSymbol = "";
            }
            String linkField = "orderid_" + strOrderType.ToLower();
            if (Tools.Strings.StrCmp(strOrderType, "quote"))
                linkField = "base_ordhed_uid";
            String quantityField = "quantity";
            if (Tools.Strings.StrCmp(strOrderType, "quote"))
                quantityField = "quantityordered";
            x.TheLeader.Comment("Calculating " + strOrderType + "...");
            String strSQL = "update " + strTable2 + " set " + count_field + " = ( select isnull(count(*), 0) from " + MakeOrdhedName(strOrderType) + " inner join " + MakeOrddetName(strOrderType) + " on " + MakeOrddetName(strOrderType) + "." + linkField + " = " + MakeOrdhedName(strOrderType) + ".unique_id where " + MakeOrdhedName(strOrderType) + ".ordertype = '" + strOrderType + "' ";
            if (!ignore_agent_matching)
                strSQL += " and ( " + MakeOrdhedName(strOrderType) + ".base_mc_user_uid = " + strTable2 + "." + user_compare_field + " or " + MakeOrdhedName(strOrderType) + ".base_mc_user_uid = " + strTable2 + "." + user_compare_field2 + ") ";
            strSQL += " and ( " + MakeOrdhedName(strOrderType) + ".companyname = " + strTable2 + "." + company_compare_field + " or " + MakeOrdhedName(strOrderType) + ".primaryemailaddress = " + strTable2 + "." + email_compare_field + " ) and " + MakeOrddetName(strOrderType) + "." + quantityField + " > 0 and " + MakeOrddetName(strOrderType) + ".basenumberstripped = " + strTable2 + ".basenumberstripped and " + MakeOrdhedName(strOrderType) + ".orderdate " + strDateComparison + " " + strTable2 + "." + date_compare_field + " ";
            if (UseLimit)
                strSQL += " and " + MakeOrdhedName(strOrderType) + ".orderdate " + strLimitComparison + " dateadd(d, " + strLimitSymbol + days.ToString() + ", " + strTable2 + "." + date_compare_field + "  )";
            strSQL += ")";
            x.Execute(strSQL);
            x.TheData.TheConnection.FieldMakeExist(strTable2, new Field(date_result_field, FieldType.DateTime, 0));
            strSQL = "update " + strTable2 + " set " + date_result_field + " = ( select max(" + MakeOrdhedName(strOrderType) + ".orderdate) from " + MakeOrdhedName(strOrderType) + " inner join " + MakeOrddetName(strOrderType) + " on " + MakeOrddetName(strOrderType) + "." + linkField + " = " + MakeOrdhedName(strOrderType) + ".unique_id where " + MakeOrdhedName(strOrderType) + ".ordertype = '" + strOrderType + "' ";
            if (!ignore_agent_matching)
                strSQL += " and ( " + MakeOrdhedName(strOrderType) + ".base_mc_user_uid = " + strTable2 + "." + user_compare_field + " or " + MakeOrdhedName(strOrderType) + ".base_mc_user_uid = " + strTable2 + "." + user_compare_field2 + " ) ";
            strSQL += " and ( " + MakeOrdhedName(strOrderType) + ".companyname = " + strTable2 + "." + company_compare_field + "  or  " + MakeOrdhedName(strOrderType) + ".primaryemailaddress = " + strTable2 + "." + email_compare_field + " ) and " + MakeOrddetName(strOrderType) + "." + quantityField + " > 0 and " + MakeOrddetName(strOrderType) + ".basenumberstripped = " + strTable2 + ".basenumberstripped and " + MakeOrdhedName(strOrderType) + ".orderdate " + strDateComparison + " " + strTable2 + "." + date_compare_field + " ";
            if (UseLimit)
                strSQL += " and " + MakeOrdhedName(strOrderType) + ".orderdate " + strLimitComparison + " dateadd(d, " + strLimitSymbol + days.ToString() + ", " + strTable2 + "." + date_compare_field + "  )";
            strSQL += " )";
            x.Execute(strSQL);
        }
        //public static void MatchWithQuotes_Optimistic(String strTable2, bool UseLimit, int days, String date_compare_field, String company_compare_field, String email_compare_field, String user_compare_field, String user_compare_field2, String count_field, String date_result_field, bool quotes_before_info)
        //{
        //    String strDateComparison = "<=";
        //    String strLimitComparison = ">=";
        //    String strLimitSymbol = "-";

        //    if (!quotes_before_info)
        //    {
        //        strDateComparison = ">=";
        //        strLimitComparison = "<=";
        //        strLimitSymbol = "";
        //    }

        //    //match with quotes
        //    context.TheLeader.Comment("Calculating quotes...");
        //    String strSQL = "update " + strTable2 + " set " + count_field + " = ( select isnull(count(*), 0) from " + MakeOrdhedName(Enums.OrderType.Quote) + " inner join " + MakeOrddetName(Enums.OrderType.Quote) + " on " + MakeOrddetName(Enums.OrderType.Quote) + ".base_ordhed_uid = " + MakeOrdhedName(Enums.OrderType.Quote) + ".unique_id where " + MakeOrdhedName(Enums.OrderType.Quote) + ".ordertype = 'quote' ";

        //    //if (!ignore_agent_matching)
        //    //    strSQL += " and ( " + MakeOrdhedName(Enums.OrderType.Quote) + ".base_mc_user_uid = " + strTable2 + "." + user_compare_field + " or " + MakeOrdhedName(Enums.OrderType.Quote) + ".base_mc_user_uid = " + strTable2 + "." + user_compare_field2 + ") ";

        //    strSQL += " and ( " + MakeOrdhedName(Enums.OrderType.Quote) + ".companyname = " + strTable2 + "." + company_compare_field + " or " + MakeOrdhedName(Enums.OrderType.Quote) + ".primaryemailaddress = " + strTable2 + "." + email_compare_field + " ) and " + MakeOrddetName(Enums.OrderType.Quote) + ".quantityordered > 0 and " + MakeOrddetName(Enums.OrderType.Quote) + ".basenumberstripped = " + strTable2 + ".basenumberstripped and " + MakeOrdhedName(Enums.OrderType.Quote) + ".orderdate " + strDateComparison + " " + strTable2 + "." + date_compare_field + " ";


        //    if (UseLimit)
        //        strSQL += " and " + MakeOrdhedName(Enums.OrderType.Quote) + ".orderdate " + strLimitComparison + " dateadd(d, " + strLimitSymbol + days.ToString() + ", " + strTable2 + "." + date_compare_field + "  )";
        //    strSQL += ")";
        //    Rz3App.context.Execute(strSQL);
        //    if (!Rz3App.xLogic.UseDistributedOrders)
        //    {
        //        strSQL = "update " + strTable2 + " set " + count_field + " = " + count_field + " + ( select isnull(count(*), 0) from quote where quote.quotetype = 'giving out' ";
        //        //if (!ignore_agent_matching)
        //        //    strSQL += " and ( quote.base_mc_user_uid = " + strTable2 + "." + user_compare_field + " or quote.base_mc_user_uid = " + strTable2 + "." + user_compare_field2 + " ) ";
        //        strSQL += " and quote.companyname = " + strTable2 + "." + company_compare_field + " and quote.basenumberstripped = " + strTable2 + ".basenumberstripped and quote.quotedate " + strDateComparison + " " + strTable2 + "." + date_compare_field + " ";

        //        if (UseLimit)
        //            strSQL += " and quote.quotedate " + strLimitComparison + " dateadd(d, " + strLimitSymbol + days.ToString() + ", " + strTable2 + "." + date_compare_field + " )";
        //        strSQL += " )";
        //        Rz3App.context.Execute(strSQL);
        //    }
        //    //calculate the latest quote
        //    Rz3App.xSys.xData.MakeFieldExist(strTable2, date_result_field, (int)FieldType.DateTime, 0);
        //    strSQL = "update " + strTable2 + " set " + date_result_field + " = ( select max(" + MakeOrdhedName(Enums.OrderType.Quote) + ".orderdate) from " + MakeOrdhedName(Enums.OrderType.Quote) + " inner join " + MakeOrddetName(Enums.OrderType.Quote) + " on " + MakeOrddetName(Enums.OrderType.Quote) + ".base_ordhed_uid = " + MakeOrdhedName(Enums.OrderType.Quote) + ".unique_id where " + MakeOrdhedName(Enums.OrderType.Quote) + ".ordertype = 'quote' ";

        //    //if (!ignore_agent_matching)
        //    //    strSQL += " and ( " + MakeOrdhedName(Enums.OrderType.Quote) + ".base_mc_user_uid = " + strTable2 + "." + user_compare_field + " or " + MakeOrdhedName(Enums.OrderType.Quote) + ".base_mc_user_uid = " + strTable2 + "." + user_compare_field2 + " ) ";

        //    strSQL += " and ( " + MakeOrdhedName(Enums.OrderType.Quote) + ".companyname = " + strTable2 + "." + company_compare_field + "  or  " + MakeOrdhedName(Enums.OrderType.Quote) + ".primaryemailaddress = " + strTable2 + "." + email_compare_field + " ) and " + MakeOrddetName(Enums.OrderType.Quote) + ".quantityordered > 0 and " + MakeOrddetName(Enums.OrderType.Quote) + ".basenumberstripped = " + strTable2 + ".basenumberstripped and " + MakeOrdhedName(Enums.OrderType.Quote) + ".orderdate " + strDateComparison + " " + strTable2 + "." + date_compare_field + " ";
        //    if (UseLimit)
        //        strSQL += " and " + MakeOrdhedName(Enums.OrderType.Quote) + ".orderdate " + strLimitComparison + " dateadd(d, " + strLimitSymbol + days.ToString() + ", " + strTable2 + "." + date_compare_field + "  )";
        //    strSQL += " )";
        //    Rz3App.context.Execute(strSQL);
        //    if (!Rz3App.xLogic.UseDistributedOrders)
        //    {
        //        //quick
        //        strSQL = "update " + strTable2 + " set " + date_result_field + " = ( select max(quote.quotedate) from quote where quote.quotetype = 'giving out' ";
        //        //if (!ignore_agent_matching)
        //        //    strSQL += " and ( quote.base_mc_user_uid = " + strTable2 + "." + user_compare_field + " or quote.base_mc_user_uid = " + strTable2 + "." + user_compare_field2 + " ) ";
        //        strSQL += " and quote.companyname = " + strTable2 + "." + company_compare_field + " and quote.basenumberstripped = " + strTable2 + ".basenumberstripped and quote.quotedate " + strDateComparison + " " + strTable2 + "." + date_compare_field + " ";
        //        if (UseLimit)
        //            strSQL += " and quote.quotedate " + strLimitComparison + " dateadd(d, " + strLimitSymbol + days.ToString() + ", " + strTable2 + "." + date_compare_field + " )";
        //        strSQL += " ) where " + date_result_field + " is null";
        //        Rz3App.context.Execute(strSQL);
        //    }
        //}
        public static void DropOrderViews(ContextNM x)
        {
            //drop the views
            try
            {
                x.Execute("drop view ordhed");
            }
            catch { }

            try
            {
                x.Execute("drop view orddet");
            }
            catch { }
        }
        public static void CreateOrderViews(ContextRz x)
        {
            CreateOrderViews(x, x.Connection);
        }
        public static void CreateOrderViews(ContextRz x, DataConnectionSqlServer data)
        {
            String strFields = "unique_id";
            List<CoreVarAttribute> a = x.xSys.PropsGetByClass("ordhed");
            foreach (CoreVarAttribute aa in a)
            {
                List<Field> fields = new List<Field>();
                aa.FieldsAppend(fields);
                foreach (Field f in fields)
                {
                    if (Tools.Strings.StrExt(strFields))
                        strFields += ",";
                    strFields += f.Name;
                }
            }
            CreateOrdHedView(data, strFields);
            strFields = "unique_id";
            List<CoreVarAttribute> rfq = x.xSys.PropsGetByClass("orddet_rfq");
            List<CoreVarAttribute> quote = x.xSys.PropsGetByClass("orddet_quote");
            a = new List<CoreVarAttribute>();
            foreach (CoreVarAttribute aa in rfq)
            {
                if (quote.Contains(aa))
                    a.Add(aa);
            }
            foreach (CoreVarAttribute aa in a)
            {
                List<Field> fields = new List<Field>();
                aa.FieldsAppend(fields);
                foreach (Field f in fields)
                {
                    if (Tools.Strings.StrExt(strFields))
                        strFields += ",";
                    strFields += f.Name;
                }
            }
            strFields = x.TheLeaderRz.GetOrddetFieldsExtra(x, strFields);
            CreateOrdDetView(data, strFields);
        }
        public static void CreateOrdHedView(DataConnectionSqlServer data, String strFields)
        {
            int i = data.ScalarInt32("if exists (select * from information_schema.tables where table_schema = 'dbo' and table_name = 'ordhed' and table_catalog = '" + data.Filter(data.DatabaseName) + "') select 1");
            if (i == 1)//Rz5 no longer uses this table, rename it
                data.Execute("sp_rename ordhed, ordhed_" + Tools.Strings.GetNewID());
            String strSQL = "create view ordhed as ";
            strSQL += "select " + strFields + " from ordhed_rfq";
            strSQL += " union all ";
            strSQL += "select " + strFields + " from ordhed_service";
            strSQL += " union all ";
            strSQL += "select " + strFields + " from ordhed_quote";
            strSQL += " union all ";
            strSQL += "select " + strFields + " from ordhed_sales";
            strSQL += " union all ";
            strSQL += "select " + strFields + " from ordhed_purchase";
            strSQL += " union all ";
            strSQL += "select " + strFields + " from ordhed_invoice";
            strSQL += " union all ";
            strSQL += "select " + strFields + " from ordhed_rma";
            strSQL += " union all ";
            strSQL += "select " + strFields + " from ordhed_vendrma";
            data.Execute(strSQL);
        }
        public static void CreateOrdDetView(DataConnectionSqlServer data, String strFields)
        {
            int i = data.ScalarInt32("if exists (select * from information_schema.tables where table_schema = 'dbo' and table_name = 'orddet' and table_catalog = '" + data.Filter(data.DatabaseName) + "') select 1");
            if (i == 1)//Rz5 no longer uses this table, rename it
                data.Execute("sp_rename orddet, orddet_" + Tools.Strings.GetNewID());
            String strSQL = "create view orddet as ";
            strSQL += "select " + strFields + " from orddet_rfq";
            strSQL += " union all ";
            strSQL += "select " + strFields + " from orddet_quote";
            data.Execute(strSQL);
        }
        public static void ConvertDistributedOrders(ContextRz x, String strType)
        {
            x.TheLeader.Reorg();
            //x.TheLeader.Comment("Converting " + strType + "...");
            //x.Execute("truncate table ordhed_" + strType);
            //x.xSys.CopyObjectsBetweenTables("ordhed", "ordhed", "ordhed_" + strType, "ordertype = '" + strType + "'", "unique_id");
            //x.Execute("truncate table orddet_" + strType);
            //x.xSys.CopyObjectsBetweenTables("orddet", "orddet", "orddet_" + strType, "ordertype = '" + strType + "'", "base_ordhed_uid");
        }
        public static void RunSQLOnOrderTables(ContextRz x, String strSQL)
        {
            ArrayList a = GetOrderTableNames();
            foreach (String s in a)
            {
                x.Execute(strSQL.Replace("<order table>", s));
            }
        }
        public static ArrayList GetOrderTableNames()
        {
            ArrayList a = new ArrayList();
            List<Enums.OrderType> t = OrderTypes;
            foreach (Enums.OrderType s in t)
            {
                a.Add("ordhed_" + s.ToString().ToLower());
            }
            return a;
        }
        public static List<Enums.OrderType> OrderTypes
        {
            get
            {
                List<Enums.OrderType> a = new List<Enums.OrderType>();
                a.Add(Enums.OrderType.RFQ);
                a.Add(Enums.OrderType.Service);
                a.Add(Enums.OrderType.Quote);
                a.Add(Enums.OrderType.Sales);
                a.Add(Enums.OrderType.Purchase);
                a.Add(Enums.OrderType.Invoice);
                a.Add(Enums.OrderType.RMA);
                a.Add(Enums.OrderType.VendRMA);
                return a;
            }
        }
        public static ArrayList OrderTypesStringArray
        {
            get
            {
                ArrayList ret = new ArrayList();
                foreach (Enums.OrderType t in OrderTypes)
                {
                    ret.Add(t.ToString().ToLower());
                }
                return ret;
            }
        }
        public static void HideOriginalOrderTables(ContextRz x)
        {
            if (x.TheData.TheConnection.TableExists("ordhed"))
                x.TheData.TheConnection.RenameTable("ordhed", "ordhed_original_data");
            if (x.TheData.TheConnection.TableExists("orddet"))
                x.TheData.TheConnection.RenameTable("orddet", "orddet_original_data");
            ordhed.CreateOrderViews(x);
        }
        public static void ShowOriginalOrderTables(ContextRz x)
        {
            ordhed.DropOrderViews(x);
            //rename _original_data back to normal
            if (x.TheData.TheConnection.TableExists("ordhed_original_data"))
                x.TheData.TheConnection.RenameTable("ordhed_original_data", "ordhed");
            if (x.TheData.TheConnection.TableExists("orddet_original_data"))
                x.TheData.TheConnection.RenameTable("orddet_original_data", "orddet");
        }
        public static void ConvertTemplatesForDist(ContextNM x)
        {
            String strSQL = "update n_template set class_name = 'orddet_<order_type>' where template_name = 'ORDERDETAIL<order_type>'";
            RunSQLOnOrderTypes(x, strSQL);
            strSQL = "update n_template set class_name = 'orddet_<order_type>' where template_name = 'ordersearch-details-<order_type>'";
            RunSQLOnOrderTypes(x, strSQL);
            strSQL = "update n_template set class_name = 'ordhed_<order_type>' where template_name = 'ORDERSEARCH-<order_type>'";
            RunSQLOnOrderTypes(x, strSQL);
            strSQL = "update n_template set class_name = 'orddet_purchase' where template_name = 'BUYSEARCH'";
            x.Execute(strSQL);
        }
        public static void RestoreTemplatesFromDist(ContextNM x)
        {
            String strSQL = "update n_template set class_name = 'orddet' where template_name = 'ORDERDETAIL<order_type>'";
            RunSQLOnOrderTypes(x, strSQL);
            strSQL = "update n_template set class_name = 'orddet' where template_name = 'ordersearch-details-<order_type>'";
            RunSQLOnOrderTypes(x, strSQL);
            strSQL = "update n_template set class_name = 'ordhed' where template_name = 'ORDERSEARCH-<order_type>'";
            RunSQLOnOrderTypes(x, strSQL);
            strSQL = "update n_template set class_name = 'orddet' where template_name = 'BUYSEARCH'";
            x.Execute(strSQL);
        }
        public static void RunSQLOnOrderTypes(ContextNM x, String strSQL)
        {
            String s = strSQL.Replace("<order_type>", "rfq");
            x.Execute(s);
            s = strSQL.Replace("<order_type>", "service");
            x.Execute(s);
            s = strSQL.Replace("<order_type>", "quote");
            x.Execute(s);
            s = strSQL.Replace("<order_type>", "sales");
            x.Execute(s);
            s = strSQL.Replace("<order_type>", "purchase");
            x.Execute(s);
            s = strSQL.Replace("<order_type>", "invoice");
            x.Execute(s);
            s = strSQL.Replace("<order_type>", "rma");
            x.Execute(s);
            s = strSQL.Replace("<order_type>", "vendrma");
            x.Execute(s);
        }
        public static ordhed GetById(ContextRz context, String strID, Enums.OrderType type)
        {
            return (ordhed)context.GetById("ordhed_" + type.ToString().ToLower(), strID);
        }
        public static ordhed GetByNumberAndType(ContextRz context, String strNumber, String type)
        {
            return GetByNumberAndType(context, strNumber, RzLogic.ConvertOrderType(type));
        }
        public static ordhed GetByNumberAndType(ContextRz context, String strNumber, Enums.OrderType type)
        {
            if (type == Rz5.Enums.OrderType.Any)
                return null;

            return (ordhed)context.QtO(ordhed.MakeOrdhedName(type), "select * from " + ordhed.MakeOrdhedName(type) + " where ordertype = '" + type.ToString() + "' and ordernumber = '" + strNumber + "'");
        }
        public static int GetDaysAllowed(String strTerms)
        {
            String s = strTerms.Replace(" ", "");
            if (Tools.Strings.HasString(s, new String[] { "cod", "c.o.d", "cash", "cc", "creditcard", "tt" }))
                return 0;
            //this has to go in reverse or else net10 will be seen as net1, etc
            if (Tools.Strings.HasString(s, "net60"))
                return 60;
            if (Tools.Strings.HasString(s, "net45"))
                return 45;
            if (Tools.Strings.HasString(s, "net30"))
                return 30;
            if (Tools.Strings.HasString(s, "net15"))
                return 15;
            if (Tools.Strings.HasString(s, "net10"))
                return 10;
            if (Tools.Strings.HasString(s, "net5"))
                return 5;
            if (Tools.Strings.HasString(s, "net1"))
                return 1;
            return 0;
        }
        public static bool PrepareOrderImport(ContextRz context, nDataTable dt)
        {
            context.Reorg();
            return false;

            //dt.SetActualFieldNames();
            //dt.AddField("orderdate");
            //dt.SetFieldIfBlank("orderdate", "01/01/1900");
            //dt.AddField("ordernumber");
            //dt.SetFieldIfBlank("ordernumber", "000000");
            //if (!dt.FormalizeFieldTypes(false))
            //    return false;
            //return true;
        }
        public static bool Import(ContextRz context, nDataTable dtOrders, Enums.OrderType ot)
        {
            context.Reorg();
            return false;

            //if (!PrepareOrderImport(dtOrders))
            //    return false;
            ////add the company id
            //dtOrders.AddField("base_company_uid");
            //if (dtOrders.FieldExists("extra_companysystemid"))
            //{
            //    if (!dtOrders.xData.Execute("update " + dtOrders.TableName + " set base_company_uid = (select max(unique_id) from company where company.companycode = " + dtOrders.TableName + ".extra_companysystemid) where exists(select max(unique_id) from company where isnull(company.companycode, '') > '' and company.companycode = " + dtOrders.TableName + ".extra_companysystemid) and isnull(" + dtOrders.TableName + ".extra_companysystemid, '') > ''"))
            //        return false;
            //}
            //else if (dtOrders.FieldExists("vendorcode"))
            //{
            //    if (!dtOrders.xData.Execute("update " + dtOrders.TableName + " set base_company_uid = (select max(unique_id) from company where company.legacyid = " + dtOrders.TableName + ".vendorcode) where exists(select max(unique_id) from company where isnull(company.legacyid, '') > '' and company.legacyid = " + dtOrders.TableName + ".vendorcode) and isnull(" + dtOrders.TableName + ".vendorcode, '') > ''"))
            //        return false;
            //}
            ////else if (dtOrders.FieldExists("companycode"))
            ////{
            ////    if (!dtOrders.xData.Execute("update " + dtOrders.TableName + " set base_company_uid = (select max(unique_id) from company where company.companycode = " + dtOrders.TableName + ".companycode) where exists(select max(unique_id) from company where isnull(company.companycode, '') > '' and company.companycode = " + dtOrders.TableName + ".companycode) and isnull(" + dtOrders.TableName + ".companycode, '') > ''"))
            ////        return false;
            ////}
            //else
            //{
            //    if (!context.TheLeader.AreYouSure("continue without a specific field referencing the exact company the orders are linked to"))
            //        return false;
            //}
            ////company name
            //dtOrders.AddField("companyname");
            //if (!dtOrders.xData.Execute("update " + dtOrders.TableName + " set companyname = (select max(companyname) from company where company.unique_id = " + dtOrders.TableName + ".base_company_uid) where exists(select max(companyname) from company where isnull(company.unique_id, '') > '' and company.unique_id = " + dtOrders.TableName + ".base_company_uid) and isnull(" + dtOrders.TableName + ".base_company_uid, '') > ''"))
            //    return false;
            //if (!dtOrders.CheckCriteria("have no company name", "isnull(companyname, '') = ''", false))
            //    return false;
            //if (!dtOrders.CheckCriteria("have no part number", "isnull(fullpartnumber, '') = ''", false))
            //    return false;
            ////too restrictive
            ////if (!dtOrders.CheckCriteria("have no quantity", "isnull(quantity, 0) = 0", false))
            ////    return false;
            ////if (!dtOrders.CheckCriteria("have no price", "isnull(price, 0.0) = 0", false))
            ////    return false;
            //if (!CheckImportAgentLink(dtOrders))
            //    return false;
            ////line items
            //dtOrders.AddField("manufacturer");
            //dtOrders.AddField("alternatepart");
            //dtOrders.AddField("datecode");
            //dtOrders.AddField("ordernumber");
            //dtOrders.AddField("vendorname");
            //long l = 0;
            //PartObject.ParsePartNumber(dtOrders, true, ref l);
            ////convert the numeric fields
            //if (dtOrders.FieldExists("quantityordered"))
            //    dtOrders.ConvertField_Long("quantityordered", false);
            //if (dtOrders.FieldExists("quantityfilled"))
            //    dtOrders.ConvertField_Long("quantityfilled", false);
            //if (dtOrders.FieldExists("unitprice"))
            //    dtOrders.ConvertField_Float("unitprice", false);
            //if (dtOrders.FieldExists("unitcost"))
            //    dtOrders.ConvertField_Float("unitcost", false);
            //if (!CalcImportDetailTotals(dtOrders, ot))
            //    return false;
            //String strSQL = "insert into " + MakeOrddetName(ot) + "(unique_id, base_ordhed_uid, ordertype, fullpartnumber, prefix, basenumber, basenumberstripped, datecode, manufacturer, quantityordered, quantityfilled, unitprice, unitcost, extendedorder, extendedfilled, stockvalue, lineprofit, totalvalue, totalprice, ordernumber, orderdate, companyname, isselected, alternatepart, vendorname) select cast(newid() as varchar(255)) as unqiue_id, unique_id as base_ordhed_uid, '" + ot.ToString() + "' as ordertype, fullpartnumber, left(prefix, 10), basenumber, basenumberstripped, datecode, left(manufacturer, 25), quantityordered, quantityfilled, unitprice, unitcost, extendedorder, extendedfilled, stockvalue, lineprofit, totalvalue, totalprice, ordernumber, orderdate, left(companyname, 50), 1 as isselected, alternatepart, vendorname from " + dtOrders.TableName + " where isnull(fullpartnumber, '') > ''";
            //if (!dtOrders.xData.Execute(strSQL))
            //    return false;
            ////order header stuff
            //dtOrders.AddField("firstpartnumber");
            //dtOrders.AddField("ordertotal", "float", "0");    //= (sum of totalprice)
            //dtOrders.AddField("grossamount", "float", "0");
            //dtOrders.AddField("costamount", "float", "0");
            //dtOrders.AddField("totalvalue", "float", "0");
            //dtOrders.AddField("profitamount", "float", "0");
            //if (!dtOrders.xData.Execute("update " + dtOrders.TableName + " set firstpartnumber = fullpartnumber, ordertotal = totalprice, grossamount = totalvalue, costamount = stockvalue, profitamount = lineprofit"))
            //    return false;
            ////ordertype
            //dtOrders.AddField("ordertype");
            //dtOrders.SetFieldIfBlank("ordertype", RzLogic.ConvertOrderType(ot));
            //return ImportOrderList(dtOrders, ot);
        }
        public static bool Import(ContextNM x, nDataTable dtHeader, String strHeaderUID, String strCompanyUID, nDataTable dtDetail, String strDetailUID, Enums.OrderType ot)
        {
            x.Reorg();
            return false;

            //if (!PrepareOrderImport(dtHeader))
            //    return false;

            //dtHeader.AddField("ordertype");
            //dtHeader.SetFieldIfBlank("ordertype", RzLogic.ConvertOrderType(ot));

            //dtDetail.AddField("ordertype");
            //dtDetail.SetFieldIfBlank("ordertype", RzLogic.ConvertOrderType(ot));

            ////add the company id, by code and entire name
            //dtHeader.AddField("base_company_uid");
            //if (!dtHeader.xData.Execute("update " + dtHeader.TableName + " set base_company_uid = (select max(unique_id) from company where company.companycode = " + dtHeader.TableName + "." + strCompanyUID + ") where exists(select unique_id from company where isnull(company.companycode, '') > '' and company.companycode = " + dtHeader.TableName + "." + strCompanyUID + ") and isnull(" + dtHeader.TableName + "." + strCompanyUID + ", '') > ''"))
            //    return false;

            ////company name
            //dtHeader.AddField("companyname");
            //if (!dtHeader.xData.Execute("update " + dtHeader.TableName + " set companyname = (select max(companyname) from company where company.unique_id = " + dtHeader.TableName + ".base_company_uid) where exists(select companyname from company where isnull(company.unique_id, '') > '' and company.unique_id = " + dtHeader.TableName + ".base_company_uid) and isnull(" + dtHeader.TableName + ".base_company_uid, '') > ''"))
            //    return false;
            ////try again for the company ids
            //if (!dtHeader.xData.Execute("update " + dtHeader.TableName + " set base_company_uid = (select max(unique_id) from company where company.companyname = " + dtHeader.TableName + ".companyname) where exists(select unique_id from company where isnull(company.companyname, '') > '' and company.companyname = " + dtHeader.TableName + ".companyname) and isnull(" + dtHeader.TableName + ".companyname, '') > '' and isnull(" + dtHeader.TableName + ".base_company_uid, '') = ''"))
            //    return false;

            //if (dtHeader.xData.FieldExists(dtHeader.TableName, "contact_code"))
            //{
            //    dtHeader.AddField("base_companycontact_uid");
            //    if (!dtHeader.xData.Execute("update " + dtHeader.TableName + " set base_companycontact_uid = (select max(unique_id) from companycontact where companycontact.interests = " + dtHeader.TableName + ".contact_code) where exists(select unique_id from companycontact where isnull(companycontact.interests, '') > '' and companycontact.interests = " + dtHeader.TableName + ".contact_code) and isnull(" + dtHeader.TableName + ".contact_code, '') > ''"))
            //        return false;

            //    dtHeader.AddField("contactname");
            //    dtHeader.AddField("primaryphone");
            //    dtHeader.AddField("primaryfax");
            //    dtHeader.AddField("primaryemailaddress");

            //    dtHeader.xData.Execute("update x set x.contactname = y.contactname, x.primaryphone = y.primaryphone, x.primaryfax = y.primaryfax, x.primaryemailaddress = y.primaryemailaddress from " + dtHeader.TableName + " x inner join companycontact y on x.base_companycontact_uid = y.unique_id where isnull(x.base_companycontact_uid, '') > ''");
            //}

            ////try for the contact?

            //if (!CheckImportAgentLink(dtHeader))
            //    return false;
            ////too restrictive, especially until the duplicate company name issue is solved
            ////if (!dtHeader.CheckCriteria("have no company link", "isnull(base_company_uid, '') = ''", false))
            ////    return false;
            ////details
            //dtDetail.SetActualFieldNames();
            //if (!dtDetail.FormalizeFieldTypes(false))
            //    return false;
            //if (!dtDetail.CheckCriteria("have no part number", "isnull(fullpartnumber, '') = ''", false))
            //    return false;
            ////if (!dtDetail.CheckCriteria("have no quantity", "isnull(quantityfilled, 0) = 0", false))
            ////    return false;
            ////if (!dtDetail.CheckCriteria("have no price", "isnull(unitprice, 0.0) = 0", false))
            ////    return false;
            ////what if the legacy customer and vendor ids conflict?
            ////legacyid is the vendor column now
            //dtDetail.AddField("vendor_company_uid");
            //dtDetail.AddField("vendorname");
            //if (dtDetail.FieldExists("vendorcode"))
            //{
            //    if (!dtDetail.LinkInInfo("vendor_company_uid", "vendorcode", "company", "legacyid", "unique_id"))
            //        return false;
            //    if (!dtDetail.LinkInInfo("vendorname", "vendor_company_uid", "company", "unique_id", "companyname"))
            //        return false;
            //}
            //long l = 0;
            //context.TheLeader.Comment("Handling part numbers...");
            //PartObject.ParsePartNumber(dtDetail, true, ref l);
            //String strEmpty = "";
            //if (dtDetail.xData.IsTextField(dtDetail.TableName, strDetailUID))
            //    strEmpty = "isnull(" + dtDetail.TableName + "." + strDetailUID + ", '') > ''";
            //else
            //    strEmpty = "isnull(" + dtDetail.TableName + "." + strDetailUID + ", 0) > 0";
            //dtDetail.AddField("base_ordhed_uid");

            //context.TheLeader.Comment("Setting the order id...");
            //if (!dtDetail.xData.Execute("update " + dtDetail.TableName + " set base_ordhed_uid = (select max(unique_id) from " + dtHeader.TableName + " where " + dtHeader.TableName + "." + strHeaderUID + " = " + dtDetail.TableName + "." + strDetailUID + ") where " + strEmpty + " and exists( select unique_id from " + dtHeader.TableName + " where " + dtHeader.TableName + "." + strHeaderUID + " = " + dtDetail.TableName + "." + strDetailUID + ")"))
            //    return false;
            ////if( !dtDetail.CheckCriteria("have no order link", "isnull(base_ordhed_uid, '') = ''", false) )
            ////    return false;
            ////ordernumber, companyname, isselected
            //dtDetail.AddField("ordernumber");
            //dtDetail.AddField("ordertype");
            //dtDetail.AddField("companyname");
            //dtDetail.AddField("base_company_uid");
            //dtDetail.AddDateField("orderdate");
            //dtDetail.AddField("agentname");
            //dtDetail.AddField("base_mc_user_uid");

            //context.TheLeader.Comment("Updating order info...");
            //if (!dtDetail.xData.Execute("update " + dtDetail.TableName + " set ordernumber = (select max(ordernumber) from " + dtHeader.TableName + " where " + dtHeader.TableName + ".unique_id = " + dtDetail.TableName + ".base_ordhed_uid)"))
            //    return false;

            //if (!dtDetail.xData.Execute("update x set x.companyname = y.companyname, x.base_company_uid = y.base_company_uid from " + dtDetail.TableName + " x inner join " + dtHeader.TableName + " y on y.unique_id = x.base_ordhed_uid"))
            //    return false;

            //if (!dtDetail.xData.Execute("update " + dtDetail.TableName + " set orderdate = (select max(orderdate) from " + dtHeader.TableName + " where " + dtHeader.TableName + ".unique_id = " + dtDetail.TableName + ".base_ordhed_uid)"))
            //    return false;

            //if (!dtDetail.xData.Execute("update x set x.agentname = y.agentname, x.base_mc_user_uid = y.base_mc_user_uid, x.ordertype = y.ordertype from " + dtDetail.TableName + " x inner join " + dtHeader.TableName + " y on y.unique_id = x.base_ordhed_uid"))
            //    return false;

            //context.TheLeader.Comment("Calculating totals...");
            //if (!CalcImportDetailTotals(dtDetail, ot))
            //    return false;
            ////order header stuff
            //dtHeader.AddField("firstpartnumber");
            //if (!dtHeader.xData.Execute("update " + dtHeader.TableName + " set firstpartnumber = (select max(fullpartnumber) from " + dtDetail.TableName + " x where x.base_ordhed_uid = " + dtHeader.TableName + ".unique_id)"))
            //    return false;
            //dtHeader.AddField("ordertotal", "float", "0");    //= (sum of totalprice)
            //dtHeader.AddField("grossamount", "float", "0");
            //dtHeader.AddField("costamount", "float", "0");
            //dtHeader.AddField("totalvalue", "float", "0");
            //dtHeader.AddField("profitamount", "float", "0");
            //if (!dtHeader.xData.Execute("update " + dtHeader.TableName + " set ordertotal = (select sum(totalprice) from " + dtDetail.TableName + " where " + dtDetail.TableName + ".base_ordhed_uid = " + dtHeader.TableName + ".unique_id)"))
            //    return false;
            //if (!dtHeader.xData.Execute("update " + dtHeader.TableName + " set grossamount = (select sum(totalvalue) from " + dtDetail.TableName + " where " + dtDetail.TableName + ".base_ordhed_uid = " + dtHeader.TableName + ".unique_id)"))
            //    return false;
            //if (!dtHeader.xData.Execute("update " + dtHeader.TableName + " set costamount = (select sum(stockvalue) from " + dtDetail.TableName + " where " + dtDetail.TableName + ".base_ordhed_uid = " + dtHeader.TableName + ".unique_id)"))
            //    return false;
            //if (!dtHeader.xData.Execute("update " + dtHeader.TableName + " set totalvalue = (select sum(totalvalue) from " + dtDetail.TableName + " where " + dtDetail.TableName + ".base_ordhed_uid = " + dtHeader.TableName + ".unique_id)"))
            //    return false;
            //if (!dtHeader.xData.Execute("update " + dtHeader.TableName + " set profitamount = (select sum(lineprofit) from " + dtDetail.TableName + " where " + dtDetail.TableName + ".base_ordhed_uid = " + dtHeader.TableName + ".unique_id)"))
            //    return false;

            ////actual order import
            //if (!ImportOrderList(dtHeader, ot))
            //    return false;

            //dtDetail.xData.Execute("alter table " + dtDetail.TableName + " add isselected bit", true);
            //dtDetail.xData.Execute("update " + dtDetail.TableName + " set isselected  = 1", true);

            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "delivery", (int)FieldType.String, 255);
            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "alternatepart", (int)FieldType.String, 255);
            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "description", (int)FieldType.String, 255);
            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "assemblyname", (int)FieldType.String, 255);
            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "shipdate", (int)FieldType.DateTime, 255);
            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "internalcomment", (int)FieldType.String, 8000);
            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "linecode", (int)FieldType.Int32, 0);
            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "quantitycancelled", (int)FieldType.Int32, 0);
            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "quantitypurchased", (int)FieldType.Int32, 0);
            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "quantitystocked", (int)FieldType.Int32, 0);
            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "base_dealheader_uid", (int)FieldType.String, 255);
            //dtDetail.xData.MakeFieldExist(dtDetail.TableName, "grid_color", (int)FieldType.Int32, 0);

            //if (ot == Rz4.Enums.OrderType.RFQ)
            //{
            //    dtDetail.xData.MakeFieldExist(dtDetail.TableName, "the_orddet_quote_uid", (int)FieldType.String, 255);
            //    dtDetail.xData.Execute("update " + dtDetail.TableName + " set grid_color = " + System.Drawing.Color.Green.ToArgb());
            //}
            //else if (ot == Rz4.Enums.OrderType.Quote)
            //{
            //    dtDetail.xData.Execute("update " + dtDetail.TableName + " set grid_color = " + System.Drawing.Color.Blue.ToArgb());
            //}

            //ArrayList a = new ArrayList();
            //a.Add("fullpartnumber");
            //a.Add("quantityordered");
            //a.Add("quantityfilled");
            //a.Add("orderdate");
            //a.Add("ordernumber");
            //a.Add("companyname");
            //a.Add("base_company_uid");
            //a.Add("unitprice");
            //a.Add("isselected");
            //a.Add("base_ordhed_uid");
            //a.Add("prefix");
            //a.Add("basenumber");
            //a.Add("basenumberstripped");
            //a.Add("vendor_company_uid");
            //a.Add("vendorname");
            //a.Add("extendedorder");
            //a.Add("extendedfilled");
            //a.Add("stockvalue");
            //a.Add("lineprofit");
            //a.Add("totalvalue");
            //a.Add("totalprice");
            //a.Add("delivery");
            //a.Add("assemblyname");
            //a.Add("agentname");
            //a.Add("base_mc_user_uid");
            //a.Add("shipdate");
            //a.Add("internalcomment");
            //a.Add("linecode");
            //a.Add("ordertype");
            //a.Add("quantitycancelled");
            //a.Add("alternatepart");
            //a.Add("description");
            //a.Add("quantitypurchased");
            //a.Add("quantitystocked");
            //a.Add("base_dealheader_uid");
            //a.Add("grid_color");

            //if (ot == Rz4.Enums.OrderType.RFQ)
            //    a.Add("the_orddet_quote_uid");

            //if (ot == Rz4.Enums.OrderType.Quote)
            //{
            //    dtDetail.xData.MakeFieldExist(dtDetail.TableName, "target_quantity", (int)FieldType.Int32, 0);
            //    dtDetail.xData.Execute("update " + dtDetail.TableName + " set target_quantity = isnull(target_quantity, 0)");

            //    dtDetail.xData.MakeFieldExist(dtDetail.TableName, "target_price", (int)FieldType.Double, 0);
            //    dtDetail.xData.Execute("update " + dtDetail.TableName + " set target_price = isnull(target_price, 0)");

            //    a.Add("target_quantity");
            //    a.Add("target_price");
            //}

            //SortedList props = x.xSys.CoalescePropsByClass(MakeOrddetName(ot));
            //long importcount = 0;
            //if (!dtDetail.ImportObjects(MakeOrddetName(ot), "unique_id", props, a, ref importcount))
            //    return false;
            //return true;
        }
        //Public Virtual Functions
        public virtual void CheckOutgoingTerms(ContextRz context, company c)
        {
            if (!Tools.Strings.StrExt(terms))
                terms = context.TheSysRz.TheOrderLogic.GetTermsAsCustomer(c, terms);
        }
        public virtual void CheckIncomingTerms(ContextRz context, company c)
        {
            if (!Tools.Strings.StrExt(terms))
                terms = context.TheSysRz.TheOrderLogic.GetTermsAsVendor(c, terms);
        }
        public virtual Enums.OrderType OrderType
        {
            get
            {
                return RzLogic.ConvertOrderType(ordertype);
            }
            set
            {
                ordertype = RzLogic.ConvertOrderType(value);
            }
        }
        public virtual void CheckForProblems(ContextRz context)
        {

        }
        public virtual void CheckNotifyGovernmentOrder(ContextRz context)
        {
            context.TheSysRz.TheOrderLogic.CheckNotifyGovernmentOrder(context, this);
        }
        //public virtual void CheckGovernment(company c)
        //{
        //    if (Rz3App.xLogic.IsCTG)
        //    {
        //        company co = (company)c;
        //        if (co.is_government)
        //            is_government = co.is_government;
        //        if (is_government)
        //        {
        //            CheckGovernmentMessage();
        //        }
        //    }
        //}
        public virtual void CheckHold()
        {

        }
        //private void PrintPackingSlip(ContextRz context)
        //{
        //    TransmitParameters CurrentParameters = new TransmitParameters(Rz5.Enums.TransmitType.Print);
        //    CurrentParameters.PrintTemplate = printheader.GetById(context, "0dc0b6a3be99486192cff6f213dd8b1c");  //what is this?
        //    if (CurrentParameters.PrintTemplate == null)
        //        return;
        //    if (Tools.Strings.StrExt(CurrentParameters.PrintTemplate.printername) && PrintSessionPrinter.PrinterExists(CurrentParameters.PrintTemplate.printername))
        //        CurrentParameters.PrinterName = CurrentParameters.PrintTemplate.printername;
        //    else
        //        CurrentParameters.PrinterName = PrintSessionPrinter.GetCurrentPrinter();
        //    CurrentParameters.CopyCount = 1;
        //    CurrentParameters.ForceSynchronous = false;
        //    this.Transmit(context, CurrentParameters);
        //}
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;

            if (Tools.Strings.StrCmp(args.ActionName, "newdocs-invoice"))
                args.Name = "newdocs_invoice";
            if (Tools.Strings.StrCmp(args.ActionName, "newdocs-vendrma"))
                args.Name = "newdocs_vendrma";
            if (Tools.Strings.StrCmp(args.ActionName, "newdocs-sales"))
                args.Name = "newdocs_sales";
            if (Tools.Strings.StrCmp(args.ActionName, "newdocs-purchase"))
                args.Name = "newdocs_purchase";
            if (Tools.Strings.StrCmp(args.ActionName, "newdocs-rma"))
                args.Name = "newdocs_rma";
            switch (args.ActionName.ToLower().Trim())
            {
                case "printboxlabel":
                    PrintBoxLabel(null);
                    break;
                case "sendtoupsworldship":
                    if (UPSWorldship.SendToUPSWorldship(this))
                        args.TheContext.TheLeader.Tell("Sent!");
                    else
                        args.TheContext.TheLeader.Tell("Failed To Send!");
                    break;
                case "updateupstracking":
                    if (UPSWorldship.UpdateOrderTracking(this))
                        args.TheContext.TheLeader.Tell("Success!");
                    else
                        args.TheContext.TheLeader.Tell("Failed To Update!");
                    break;
                case "salesreppaid":
                    is_reppaid = true;
                    args.TheContext.Update(this);
                    break;
                case "buyerpaid":
                    is_buyerpaid = true;
                    args.TheContext.Update(this);
                    break;
                case "links":
                    ShowMap(xrz);
                    args.Handled = true;
                    break;
                case "emailfollow-upquote":
                    DoAction_EmailFollowUpQuote(xrz);
                    break;
                case "emailfollow-uppo":
                    EmailFollowUpPO(xrz);
                    break;
                case "send/updateqb":
                case "sendtoqb":
                case "syncqb":
                    SendToQB(xrz, false, true);
                    break;
                case "customertoqb":
                case "vendortoqb":
                case "companytoqb":
                    ExportCompanyToQB(xrz);
                    break;
                case "additem":
                    AddItem(xrz);
                    break;
                case "renumber":
                    ReNumber(xrz);
                    break;
                case "void":
                    Void(xrz);
                    args.Handled = true;
                    break;
                case "unvoid":
                    VoidUn(xrz);
                    break;
                case "checkautoclose":
                    throw new NotImplementedException("Order.CheckAutoClose");
                case "thankyouemail":
                    SendThankYouEmail(xrz);
                    break;
                case "unclose":
                    UnClose(xrz);
                    break;
                case "notifybuyer":
                    NotifyBuyer(xrz);
                    break;
                case "newtransaction":
                    DoAction_NewTransaction(xrz);
                    break;
                //case "printpdf":
                //    DoAction_PrintPDF(xrz);
                //    break;
                case "recreatecompany":
                    ReCreateCompany(xrz, base_company_uid);
                    break;
                case "pocomplete":
                    CompletePurchaseOrder(xrz);
                    break;
                case "faxandemail":
                case "email":
                    Email(xrz);
                    break;
                case "directemailpo":
                    DirectEmailPO(xrz);
                    break;
                case "directemailquote":
                    DirectEmailQuote(xrz);
                    break;
                case "printpreview":
                    Preview();
                    break;
                case "popqb":
                    PopQB();
                    break;
                case "transactions":
                    DoAction_Transactions(xrz);
                    break;
                case "viewcompany":
                    CompanyView(xrz);
                    break;
                case "putonhold":
                    PutOnHold(xrz);
                    break;
                case "print":
                    Print(xrz);
                    break;
                case "fax":
                    //DoAction_Fax(xrz);
                    break;
                case "selectall":
                case "selectdetails":
                    SelectAll(true);
                    break;
                case "unselectall":
                    SelectAll(false);
                    break;
                case "breaklink":
                    BreakLink(xrz);
                    break;
                case "makelink":
                    MakeLink(xrz);
                    break;
                case "sendasn":
                    SendASN(xrz);
                    break;
                case "unselectdetails":
                    SelectAll(false);
                    break;
                case "scan/viewdocuments":
                    DoAction_ScanViewDocuments(xrz);
                    break;
                case "faxvendors":
                    CreateVendorRFQs(xrz);
                    break;
                case "readytoship":
                    CompleteServiceOrder(xrz);
                    break;
                case "payments":
                    ShowPayments(xrz);
                    break;
                case "newpayment":
                    ShowNewPayment(xrz);
                    break;
                case "emailwillquote":
                    DoAction_SendWillQuoteEmail(xrz);
                    break;
                case "trackorder(google)":
                    TrackOrderGoogle(xrz);
                    break;
                case "packingslipcomplete":
                    SendPackingSlipComplete(xrz);
                    break;
                case "creditcardcharged":
                    SendCreditCardCharged(xrz);
                    break;
                case "pickall":
                    PickAll(xrz);
                    break;
                case "pastelineinfo":
                    PasteLineInfo(xrz);
                    return;
                case "applyinvoice":
                    ApplyInvoice(xrz);
                    return;
                case "linereport":
                    ShowLineReport(xrz);
                    break;
                case "reorderso":
                    args.TheContext.Show(ReOrderSOCreate((ContextRz)args.TheContext));
                    break;
                case "testpictures":
                    TestPicturesShow(xrz);
                    break;
                case "printpackingslip":
                    //if (!Rz3App.xLogic.IsAAT)
                    //    break;
                    //PrintPackingSlip((ContextRz)args.TheContext);
                    break;
                //case "fillfromlist":
                //    Rz3App.xLogic.FillFromList((ContextRz)args.TheContext, this);
                //    break;
                case "deal":
                    ShowDeal(xrz);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }



        public override void Inserting(Context x)
        {
            ContextRz xrz = (ContextRz)x;

            datecreated = DateTime.Now;
            datemodified = DateTime.Now;
            CheckDefaultBuyer(xrz);
            handlingamount = xrz.Logic.DefaultHandling;
            showonwarehouse = true;
            followup_date = xrz.TheSysRz.TheOrderLogic.GetFollowUpDate(this);
            base.Inserting(x);
        }

        public override void Updating(Context x)
        {
            ContextRz xrz = (ContextRz)x;

            if (!Tools.Strings.StrExt(billingname))
                billingname = companyname;
            if (!Tools.Strings.StrExt(shippingname))
                shippingname = companyname;

            CalculateExchange(xrz);
            CalculateAllAmounts(xrz);

            email_domain = Tools.Email.ParseEmailDomain(primaryemailaddress);
            email_suffix = Tools.Email.ParseEmailSuffix(primaryemailaddress);

            if (!Tools.Dates.DateExists(orderdate))
                orderdate = DateTime.Now;
            if (isclosed && !Tools.Dates.DateExists(dateclosed))
                dateclosed = DateTime.Now;

            ISet_Conditional("firstpartnumber", "");
            foreach (orddet d in DetailsList(xrz))
            {
                ISet_Conditional("firstpartnumber", d.fullpartnumber);
                break;
            }

            if (Changed)
            {
                datemodified = DateTime.Now;
                modifiedby = ((ContextRz)x).xUser.unique_id;
            }
            strippedphone = phonecall.GetFinalPhoneNumber(xrz, primaryphone);
            if (xrz.Logic.UpperCaseEverything)
            {
                companyname = companyname.ToUpper();
                contactname = contactname.ToUpper();
                primaryphone = primaryphone.ToUpper();
                primaryfax = primaryfax.ToUpper();
                billingaddress = billingaddress.ToUpper();
                shippingaddress = shippingaddress.ToUpper();
            }
            xrz.TheSysRz.TheOrderLogic.OrdHedBeforeUpdate(xrz, this);

            shippingamount_print = xrz.Accounts.CurrencySymbol(currency_name) + " " + Tools.Number.MoneyFormat(Math.Round(shippingamount_exchanged, 2));
            handlingamount_print = xrz.Accounts.CurrencySymbol(currency_name) + " " + Tools.Number.MoneyFormat(Math.Round(handlingamount_exchanged, 2));
            taxamount_print = xrz.Accounts.CurrencySymbol(currency_name) + " " + Tools.Number.MoneyFormat(Math.Round(taxamount_exchanged, 2));
            ordertotal_print = xrz.Accounts.CurrencySymbol(currency_name) + " " + Tools.Number.MoneyFormat(Math.Round(ordertotal_exchanged, 2));

            base.Updating(x);
        }

        public virtual void ClearCurrency(ContextRz x)
        {
            currency_name = x.Accounts.BaseCurrency;
            exchange_rate = 1;
        }

        public virtual void SetCurrency(ContextRz x, currency curr)
        {
            currency_name = curr.name;
            exchange_rate = curr.exchange_rate;
        }

        public virtual void CalculateExchange(ContextRz x)
        {
            if (x.Accounts.IsBaseCurrency(currency_name))
            {
                currency_name = x.Accounts.BaseCurrency;  //fill in if blank
                exchange_rate = 1;
                ordertotal_exchanged = ordertotal;
                grossamount_exchanged = grossamount;
                shippingamount_exchanged = shippingamount;
                handlingamount_exchanged = handlingamount;
                taxamount_exchanged = taxamount;
            }
            else
            {
                if (exchange_rate == 0)
                    throw new Exception(ToString() + " has currency " + currency_name + " but has an exchange rate of 0");

                //ordertotal = currency.CalculateExchangeFromForeign(ordertotal_exchanged, exchange_rate, 2);
                //grossamount = currency.CalculateExchangeFromForeign(grossamount_exchanged, exchange_rate, 2);
                shippingamount = currency.CalculateExchangeFromForeign(shippingamount_exchanged, exchange_rate, 2);
                handlingamount = currency.CalculateExchangeFromForeign(handlingamount_exchanged, exchange_rate, 2);
                taxamount = currency.CalculateExchangeFromForeign(taxamount_exchanged, exchange_rate, 2);
            }
        }

        public override string ToString()
        {
            return FriendlyOrderType + " " + ordernumber;
        }
        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return CanBeViewedBy_Main(context, args);
        }

        public bool CanBeViewedBy_Main(ContextNM context, ShowArgs args)
        {
            if (context.xUser.SuperUser)
                return true;
            if (context.xUser.CheckPermit(context, "Orders:View:ViewAllOrders-" + OrderType.ToString()))
                return true;
            if (context.xUser.CheckPermit(context, "Order:View:View All Orders"))
                return true;
            if (Tools.Strings.StrCmp(base_mc_user_uid, context.xUser.unique_id) && context.xUser.CheckPermit(context, "General:View:CanViewOrdhed-" + OrderType.ToString()))
                return true;
            return CanBeEditedBy_Main(context, args);
        }

        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            //if(Rz3App.xLogic.IsMerit && !Rz3App.xUser.SuperUser)
            //{
            //    switch(OrderType)
            //    {
            //        case Rz4.Enums.OrderType.Sales:
            //        case Rz4.Enums.OrderType.Purchase:
            //            if( nTools.GetDayStart(orderdate) < nTools.GetDayStart(DateTime.Now) )
            //                return false;
            //            break;
            //    }
            //}
            return CanBeEditedBy_Main(context, args);
        }
        public bool CanBeEditedBy_Main(ContextNM context, ShowArgs args)
        {
            ContextRz xrz = (ContextRz)context;

            if (context.xUser.SuperUser)
                return true;
            switch (OrderType)
            {
                case Rz5.Enums.OrderType.Purchase:
                case Rz5.Enums.OrderType.Service:
                case Rz5.Enums.OrderType.Quote:
                    return true;
                case Rz5.Enums.OrderType.RFQ:
                case Rz5.Enums.OrderType.Sales:
                case Rz5.Enums.OrderType.RMA:
                case Rz5.Enums.OrderType.VendRMA:
                    try
                    {
                        if (xrz.TheSysRz.TheOrderLogic.AllowIsOnTeamWith() && xrz.xUser.IsOnTeamWith(xrz, base_mc_user_uid))
                            return true;
                        if (Tools.Strings.StrExt(orderbuyerid) && !Tools.Strings.StrCmp(orderbuyerid, base_mc_user_uid))
                        {
                            if (xrz.TheSysRz.TheOrderLogic.AllowIsOnTeamWith() && xrz.xUser.IsOnTeamWith(xrz, orderbuyerid))
                                return true;
                        }
                    }
                    catch { }
                    break;
            }
            if (xrz.xUser.CheckPermit(xrz, "Orders:Edit:EditAllOrders-" + OrderType.ToString()))
                return true;
            return base.CanBeDeletedBy(context, args);
        }
        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            ContextRz xrz = (ContextRz)context;

            if (context.xUser.SuperUser)
                return true;
            switch (OrderType)
            {
                case Rz5.Enums.OrderType.RFQ:
                case Rz5.Enums.OrderType.Quote:
                case Rz5.Enums.OrderType.Purchase:
                case Rz5.Enums.OrderType.Service:
                case Rz5.Enums.OrderType.Sales:
                    try
                    {
                        if (xrz.TheSysRz.TheOrderLogic.AllowIsOnTeamWith() && xrz.xUser.IsOnTeamWith(xrz, base_mc_user_uid))
                            return true;
                    }
                    catch { }
                    break;
            }
            if (context.xUser.CheckPermit(xrz, "Orders:Delete:DeleteAllOrders-" + OrderType.ToString()))
                return true;
            return base.CanBeDeletedBy(context, args);
        }
        protected override int GridColorCalc(Context x)
        {
            if (isvoid)
                return System.Drawing.Color.Gray.ToArgb();
            else if (onhold)
                return System.Drawing.Color.Red.ToArgb();
            else if (isclosed)
                return System.Drawing.Color.Blue.ToArgb();
            else
                return System.Drawing.Color.Green.ToArgb();
        }
        public override String GetExtraClassInfo()
        {
            return ordertype;
        }
        public override String GetClipHTML(ContextNM x)
        {
            String s = GetClipHeader(x);
            s += GetClipLine(x, "ordernumber", RzLogic.GetFriendlyOrderType(OrderType) + " Number");
            s += GetClipLine(x, "orderdate", "Date");
            if (OrderDirection == Enums.OrderDirection.Incoming)
                s += GetClipLine(x, "companyname", "Vendor");
            else
                s += GetClipLine(x, "companyname", "Customer");
            return s;
        }
        //Public Functions
        public IItems DetailsAsItems(ContextRz context)
        {
            return Details.RefsGetAsItems(context);
        }
        public List<orddet> DetailsList(ContextRz context)
        {
            List<orddet> ret = new List<orddet>();
            foreach (IItem i in DetailsAsItems(context).AllGet(context))
            {
                ret.Add((orddet)i);
            }
            return ret;
        }

        public void UpdateDueDate()
        {
            if (!Tools.Dates.DateExists(requireddate))
                return;
            double add_days = 0;
            string t = terms.ToLower().Replace("net", "").Trim();
            if (Tools.Number.IsNumeric(t))
            {
                try { add_days = Convert.ToDouble(t); }
                catch { add_days = 2; }
            }
            else
                add_days = 2;
            dockdate = requireddate.AddDays(add_days);
        }
        //public Dictionary<String, nObject> PartDetails
        //{
        //    get
        //    {
        //        return GetLinesByService(false);
        //    }
        //}
        //public Dictionary<String, nObject> ServiceDetails
        //{
        //    get
        //    {
        //        return GetLinesByService(true);
        //    }
        //}
        //public Dictionary<String, nObject> GetLinesByService(bool service)
        //{
        //    //Dictionary<String, nObject> d = AllDetails;
        //    Dictionary<String, nObject> ret = new Dictionary<string, nObject>();

        //    MessageBox.Show("reorg");
        //    //foreach (KeyValuePair<String, nObject> k in d)
        //    //{
        //    //    orddet x = (orddet)k.Value;
        //    //    if (x.is_service == service)
        //    //        ret.Add(k.Key, k.Value);
        //    //}
        //    return ret;
        //}
        //public companycontact ContactObject
        //{
        //    get
        //    {
        //        return GetContactObject();
        //    }
        //    set
        //    {
        //        companycontact.SetContactObject(this, value, "base_company_uid", "companyname", "base_companycontact_uid", "contactname");
        //    }
        //}
        //public company GetCompanyObject()
        //{
        //    return (company)xSys.GetByID("company", base_company_uid);
        //}
        //public companycontact GetContactObject()
        //{
        //    return (companycontact)xSys.GetByID("companycontact", base_companycontact_uid);
        //}
        //public NewMethod.n_user GetUserObject()
        //{
        //    return NewMethod.n_user.GetByID(xSys, base_mc_user_uid);
        //}
        public String OrddetName
        {
            get
            {
                return "orddet_" + OrderType.ToString().ToLower();
            }
        }
        //public orddet GetNewDetail()
        //{
        //    return GetNewDetail((ContextRz)SysRz4.Context);
        //}




        public virtual orddet GetNewDetail(ContextRz context)    //ContextRz context
        {
            context.TheLeader.Error("reorg");
            return null;

            /*

            orddet xDetail = (orddet)xSys.MakeObject(OrddetName);

            //this has to happen this way; ISave gives the detail an id, and InsertDetail adds it to the list with the ID
            //what can't happen is for the detail to have a base_ordhed_uid; otherwise if the order has to cache its details it will
            //cache the blank detail from the database because of the ID, then not accept the actual new instance of the detail being added

            //the status needs to be set first so that BeforeSave can override it
            //actually stuff like the status and isselected should be moved to BeforeSave anyway;
            //they're related to the creation of the detail, not specifically creating the detail for a header
            xDetail.status = Enums.OrderLineStatus.Open.ToString();
            xDetail.ISave();
            InsertDetail(xDetail);

            xDetail.base_ordhed_uid = unique_id;
            xDetail.ordernumber = ordernumber;
            xDetail.ordertype = ordertype;
            xDetail.linecode = GetNextLineCode();
            xDetail.isselected = true;

            if (OrderType == Rz4.Enums.OrderType.Purchase && Rz3App.xLogic.IsMerit)
                xDetail.shipdate = orderdate;
            else
                xDetail.shipdate = dockdate;

            xDetail.requireddate = requireddate;

            //if (Rz3App.xLogic.IsPhoenix)
            //{
            //    company c = CompanyObject;
            //    if (c != null)
            //    {
            //        xDetail.warranty_period = nData.NullFilter_String(c.IGet("warranty_period"));
            //    }
            //}

            UpdateOneDetailInfo(xDetail);
            xDetail.ISave();

            return xDetail;
             * 
             * */
        }
        public orddet GetNewDetail(orddet d)
        {
            MessageBox.Show("reorg");
            return null;

            /*

            if (d == null)
                return GetNewDetail();
            orddet xDetail = (orddet)xSys.MakeObject(OrddetName);
            xDetail.base_ordhed_uid = unique_id;
            xDetail.ordernumber = ordernumber;
            xDetail.status = Enums.OrderLineStatus.Open.ToString();
            xDetail.ordertype = ordertype;
            xDetail.linecode = GetNextLineCode();
            xDetail.isselected = true;
            xDetail.shipdate = dockdate;
            xDetail.requireddate = requireddate;
            xDetail.fullpartnumber = d.fullpartnumber;
            xDetail.datecode = d.datecode;
            xDetail.manufacturer = d.manufacturer;
            xDetail.unitprice = d.unitprice;
            xDetail.unitcost = d.unitcost;
            xDetail.agentname = d.agentname;
            xDetail.internalpartnumber = d.internalpartnumber;
            xDetail.alternatepart = d.alternatepart;
            xDetail.alternatepart_01 = d.alternatepart_01;
            xDetail.alternatepart_02 = d.alternatepart_02;
            xDetail.alternatepart_03 = d.alternatepart_03;
            xDetail.alternatepart_04 = d.alternatepart_04;
            xDetail.alternatepartstripped = d.alternatepartstripped;
            xDetail.base_dealdetail_uid = d.base_dealdetail_uid;
            xDetail.base_dealheader_uid = d.base_dealheader_uid;
            xDetail.base_division_uid = d.base_division_uid;
            xDetail.base_mc_user_uid = d.base_mc_user_uid;
            xDetail.boxnum = d.boxnum;
            xDetail.buyerid = d.buyerid;
            xDetail.buyername = d.buyername;
            xDetail.buyinid = d.buyinid;
            xDetail.buytype = d.buytype;
            xDetail.category = d.category;
            xDetail.companyname = d.companyname;
            xDetail.condition = d.condition;
            xDetail.country = d.country;
            xDetail.delivery = d.delivery;
            xDetail.description = d.description;
            xDetail.dockdate = d.dockdate;
            xDetail.shipvia = d.shipvia;
            xDetail.quantitybacked = d.quantitybacked;
            xDetail.quantitycancelled = d.quantitycancelled;
            xDetail.quantityfilled = d.quantityfilled;
            xDetail.quantityordered = d.quantityordered;
            xDetail.quantitypurchased = d.quantitypurchased;
            xDetail.quantitystocked = d.quantitystocked;
            xDetail.referencenumber = d.referencenumber;
            xDetail.requireddate = d.requireddate;
            xDetail.servicecost = d.servicecost;
            xDetail.packaging = d.packaging;
            xDetail.partsperpack = d.partsperpack;
            xDetail.internalcomment = d.internalcomment;
            xDetail.location = d.location;
            xDetail.partsetup = d.partsetup;
            //xDetail.warranty_period = d.warranty_period;
            xDetail.shipvia = d.shipvia;
            xDetail.ISave();
            InsertDetail(xDetail);
            return xDetail;
             * 
             * */
        }

        public void InsertDetail(ContextRz context, orddet d)
        {
            Details.RefsAdd(context, d);

            //contextRz.TheLeader.Error("reorg");
            //d.ParentOrder = this;
            //try
            //{
            //    AllDetails.Add(d.unique_id, d);
            //}
            //catch
            //{
            //    ;
            //}
        }
        public virtual int GetNextLineCode(ContextRz context)
        {
            //contextRz.TheLeader.Error("reorg");
            return 0;
        }
        //public ArrayList GetDetailCollection()
        //{
        //    return GetDetailCollection(false, false);
        //}
        //public ArrayList GetDetailCollection(bool boolOrderByVendor, bool boolOnlySelected)
        //{
        //    if (boolOrderByVendor)
        //    {
        //        return Rz3App.xSys.QtC(OrddetName, "SELECT * FROM " + OrddetName + " WHERE base_ordhed_uid = '" + unique_id + "' AND vendor_company_uid <> '' AND vendor_company_uid IS NOT NULL ORDER BY vendor_company_uid");
        //    }
        //    else
        //    {
        //        if (boolOnlySelected)
        //        {
        //            return Rz3App.xSys.QtC(OrddetName, "SELECT * FROM " + OrddetName + " WHERE ISSELECTED = 1 AND base_ordhed_uid = '" + Rz3App.context.Filter(unique_id) + "' ORDER BY LINECODE");
        //        }
        //        else
        //        {
        //            return Rz3App.xSys.QtC(OrddetName, "SELECT * FROM " + OrddetName + " WHERE base_ordhed_uid = '" + Rz3App.context.Filter(unique_id) + "' ORDER BY LINECODE");
        //        }
        //    }
        //}

        public virtual void AbsorbCompany(ContextRz context, company xCompany)
        {
            CompanyVar.RefSet(context, xCompany);

            if (xCompany == null)
            {
                billingname = "";
                shippingname = "";
            }
            else
            {
                billingname = xCompany.companyname;
                shippingname = xCompany.companyname;
            }

            ContactVar.RefsRemoveAll(context);

            if (!Tools.Strings.StrExt(primaryphone))
                primaryphone = xCompany.primaryphone;
            if (!Tools.Strings.StrExt(primaryfax))
                primaryfax = xCompany.primaryfax;
            if (!Tools.Strings.StrExt(primaryemailaddress))
                primaryemailaddress = xCompany.primaryemailaddress;
            if (xCompany.is_government)
                is_government = true;

            abs_type = xCompany.abs_type;

            if (context.Accounts.IsBaseCurrency(xCompany.default_currency))
            {
                ClearCurrency(context);
            }
            else
            {
                currency curr = context.Accounts.GetCurrency(context, xCompany.default_currency);
                if (curr == null)
                {
                    context.Leader.Tell("The currency " + xCompany.default_currency + " applied to " + xCompany.ToString() + " could not be found.  Using " + context.Accounts.BaseCurrency);
                    ClearCurrency(context);
                }
                else
                {
                    SetCurrency(context, curr);
                }
            }

            CheckTerms((ContextRz)context, xCompany);
            AbsorbCompanyAddresses(context, xCompany);
            if (OrderType == Rz5.Enums.OrderType.Purchase && Tools.Strings.StrExt(xCompany.po_notify))
            {
                String[] notify = Tools.Strings.SplitLines(xCompany.po_notify);
                foreach (String n in notify)
                {
                    NewMethod.n_user u = (NewMethod.n_user)context.xSys.Users.GetByName(n);
                    if (u != null)
                    {
                        usernote note = usernote.New(context);
                        note.by_mc_user_uid = context.xUser.unique_id;
                        note.createdbyname = context.xUser.name;
                        note.for_mc_user_uid = u.unique_id;
                        note.createdforname = u.name;
                        note.subjectstring = context.xUser.name + " is creating a PO to " + xCompany.companyname;
                        note.notetext = note.subjectstring;
                        context.Insert(note);
                        note.shouldpopup = true;
                        context.Update(note);
                    }
                }
            }
        }

        protected virtual void CheckTerms(ContextRz context, company xCompany)
        {
            switch (OrderType)
            {
                case Enums.OrderType.Service:
                    CheckIncomingTerms(context, xCompany);
                    shipvia = xCompany.shipviacustomer;
                    break;
                default:

                    switch (OrderDirection)
                    {
                        case Enums.OrderDirection.Outgoing:
                            CheckOutgoingTerms(context, xCompany);
                            if (!Tools.Strings.StrExt(shipvia))
                                shipvia = xCompany.shipviacustomer;
                            //KT Noticed that when switching companies, terms were not getting set to the company's 
                            //designated terms (potential exposure)
                            if (OrderType == Enums.OrderType.Sales)
                                terms = xCompany.termsascustomer;
                            else if (OrderType == Enums.OrderType.Purchase)
                                terms = xCompany.termsasvendor;
                            //if (Rz3App.xLogic.IsAAT && Tools.Strings.StrCmp(shipvia, "UPS RedSaver"))
                            //    shipvia = xCompany.shipviacustomer;
                            break;
                        default:
                            CheckIncomingTerms(context, xCompany);
                            if (!Tools.Strings.StrExt(shipvia))
                                shipvia = xCompany.shipviavendor;
                            break;
                    }
                    break;
            }
        }

        protected virtual void AbsorbCompanyAddresses(ContextRz context, company xCompany)
        {
            context.TheSysRz.TheOrderLogic.AbsorbCompanyAddresses(context, this, xCompany);
        }

        public virtual void CalculateAllAmounts(ContextRz context)
        {

        }
        public virtual Double AmountPaid(ContextRz context)
        {
            Double d = 0;
            foreach (checkpayment c in AllTransactionsGet(context))
            {
                d += c.transamount;
            }
            return d;
        }

        public DateTime LastPaymentDate(ContextRz context)
        {
            DateTime ret = Tools.Dates.GetNullDate();
            foreach (checkpayment c in AllTransactionsGet(context))
            {
                if (c.transdate > ret)
                    ret = c.transdate;
            }
            return ret;
        }

        public bool HasLinkedSale(ContextRz context)
        {
            return (GetLinkedSalesOrder(context) != null);
        }
        public bool WillVendorGiveRefund(ContextRz context)
        {
            GetLinkedRMASummary(context);
            if (LinkedRMAGet(context) == null)
                return false;
            return LinkedRMAGet(context).vendor_refund;
        }
        public void GetLinkedRMASummary(ContextRz context)
        {
            switch (OrderType)
            {
                case Enums.OrderType.RMA:
                    LinkedRMASet((ordrma)context.QtO("ordrma", "select * from ordrma where rma_ordhed_uid = '" + unique_id + "'"));
                    break;
                case Enums.OrderType.VendRMA:
                    LinkedRMASet((ordrma)context.QtO("ordrma", "select * from ordrma where vendrma_ordhed_uid = '" + unique_id + "'"));
                    break;
            }
        }
        public void CloseParentOrders(ContextRz context)
        {
            ordhed xOrder;
            long lngDetails;
            long lngLinkDetails;
            ArrayList colLinks = context.QtC("ordlnk", "select * from ordlnk where orderid1 = '" + unique_id + "'");
            foreach (ordlnk xLink in colLinks)
            {
                if ((OrderType == Enums.OrderType.Sales && xLink.OrderType2 == Enums.OrderType.Quote) || (OrderType == Enums.OrderType.Invoice && xLink.OrderType2 == Enums.OrderType.Quote) || (OrderType == Enums.OrderType.Invoice && xLink.OrderType2 == Enums.OrderType.Sales) || (OrderType == Enums.OrderType.RMA && xLink.OrderType2 == Enums.OrderType.Purchase) || (OrderType == Enums.OrderType.VendRMA && xLink.OrderType2 == Enums.OrderType.Invoice))
                {
                    xOrder = xLink.Order2Var.RefGet(context);
                    if (xOrder != null)
                    {
                        lngDetails = DetailCountGet(context);
                        lngLinkDetails = xOrder.DetailCountGet(context);
                        if (lngDetails == lngLinkDetails)
                        {
                            if (context.TheLeader.AskYesNo("The " + nTools.NiceFormat(xLink.ordertype2) + " document " + xLink.ordernumber2 + " is linked to this order, and appears to be ready to close.  Should this document be closed?"))
                            {
                                xOrder.isclosed = true;
                                context.Update(xOrder);
                            }
                        }
                    }
                }
            }
        }

        public int DetailCountGet(ContextRz context)
        {
            return DetailsAsItems(context).CountGet(context);
        }

        public int DetailCountGet(ContextRz context, Enums.OrderLineStatus status)
        {
            int i = 0;
            try { i = DetailsListStatus(context, status).Count; }
            catch { }
            return i;
        }

        public bool AcceptCompany(ContextRz context, String c)
        {
            String s = "";
            return AcceptCompany(context, company.GetByName(context, c), ref s);
        }
        public bool AcceptCompany(ContextRz context, company xCompany, ref String strReason)
        {
            if (!xCompany.CurrentAgentCanAssign(context))
            {
                strReason = "The company '" + companyname + "' cannot be assigned by this user.";
                return false;
            }
            base_company_uid = xCompany.unique_id;
            companyname = xCompany.companyname;
            billingname = xCompany.companyname;
            shippingname = xCompany.companyname;
            if (!Tools.Strings.StrExt(primaryphone))
                primaryphone = xCompany.primaryphone;
            if (!Tools.Strings.StrExt(primaryfax))
                primaryfax = xCompany.primaryfax;
            if (!Tools.Strings.StrExt(primaryemailaddress))
                primaryemailaddress = xCompany.primaryemailaddress;
            country = xCompany.country;
            return true;
        }
        //public void AcceptDetail(ContextNM context, orddet xObject, bool boolCancel)
        //{
        //    contextRz.TheLeader.Error("reorg");

        //    //xObject.base_ordhed_uid = unique_id;
        //    //xObject.ordernumber = ordernumber;
        //    //xObject.ordertype = ordertype;
        //    //xObject.linecode = GetNextLineCode();
        //    //xObject.isselected = true;
        //    //xObject.shipdate = dockdate;
        //    //xObject.requireddate = requireddate;
        //    //dealheader.AcceptDetail_Deal(context, this, xObject);
        //}
        public bool ShouldNotify(String strKey)
        {
            return Tools.Strings.HasString(legacycontact, strKey);
        }

        public void ReCreateCompany(ContextRz context, String strID)
        {
            if (!Tools.Strings.StrExt(strID))
            {
                context.TheLeader.Tell("This order has aparently already lost its company link.  Open the order search, find an order that has not been saved since the company was deleted, right-click the order, and select 'Create Company'.");
                return;
            }
            company xCompany = company.GetById(context, strID);
            if (xCompany != null)
            {
                context.Show(xCompany);
                return;
            }
            xCompany = company.New(context);
            xCompany.unique_id = strID;
            xCompany.companyname = companyname;
            if (!Tools.Strings.StrExt(xCompany.companyname))
                xCompany.companyname = "Company From " + ToString();
            context.Insert(xCompany);
            context.Show(xCompany);
        }

        public List<orddet> MakeLink(ContextRz x)
        {
            return MakeLink(x, Enums.OrderType.Any);
        }

        public virtual List<orddet> MakeLink(ContextRz x, Rz5.Enums.OrderType t)
        {
            String strOrder = "";
            String strType = "";

            x.Leader.AskForOrder(ref strType, ref strOrder);

            if (!Tools.Strings.StrExt(strType))
                return new List<orddet>();
            if (!Tools.Strings.StrExt(strOrder))
                return new List<orddet>();
            ordhed xOrder = (ordhed)x.QtO("ordhed", "SELECT * FROM " + MakeOrdhedName(strType) + " WHERE ORDERNUMBER = '" + strOrder + "' AND ORDERTYPE = '" + strType + "'");
            if (xOrder == null)
            {
                x.TheLeader.Tell("The order selected could not be located by the order number '" + strOrder + "' and the type '" + strType + "'.");
                return new List<orddet>();
            }
            x.TheSysRz.TheOrderLogic.Link2Orders(x, this, xOrder);

            return new List<orddet>();
        }
        public void BreakLink(ContextRz context)
        {
            String strOrder = "";
            String strType = "";

            context.Leader.AskForOrder(ref strType, ref strOrder);
            if (!Tools.Strings.StrExt(strType) || !Tools.Strings.StrExt(strOrder))
                return;

            ArrayList a = context.QtC("ordlnk", "SELECT * FROM ordlnk WHERE ( orderid1 = '" + unique_id + "' and ORDERNUMBER2 = '" + strOrder + "' AND ORDERTYPE2 = '" + strType + "') or ( orderid2 = '" + unique_id + "' and ORDERNUMBER1 = '" + strOrder + "' AND ORDERTYPE1 = '" + strType + "')");
            if (a.Count <= 0)
            {
                context.TheLeader.Tell("No links seem to exist between " + ToString() + " and " + nTools.NiceFormat(strType) + " document " + strOrder + ".");
                return;
            }
            if (a.Count > 2)
            {
                if (!context.TheLeader.AskYesNo("There appear to be " + Tools.Number.LongFormat(a.Count) + " links between these orders.  Normally there should only be 2.  Do you want to continue?"))
                    return;
            }
            context.TheLeader.StartPopStatus();
            foreach (ordlnk l in a)
            {
                context.TheLeader.Comment("Deleting " + l.ToString() + "...");
                l.Delete(context);
            }
            //AssignNewDealHeader(strType, strOrder);
            context.TheLeader.Comment("Done.");
            context.TheLeader.StopPopStatus(true);
        }

        public bool PrintBoxLabel(ContextRz context)
        {
            ArrayList colObjects = new ArrayList();
            colObjects.Add(this);
            if (!Tools.Dymo.PrintDymoLabel(context, "outside_box", colObjects, null, false))
                return false;
            return true;
        }
        public static void BreakUpDealsByOrderID(ContextRz x, ArrayList ids)
        {
            ordhed.RunSQLOnOrderTables(x, "update <order table> set base_dealheader_uid = unique_id where unique_id in ( " + nTools.GetIn(ids) + " ) ");
            orddet.RunSQLOnDetailTables(x, "update <detail table> set base_dealheader_uid = base_ordhed_uid, base_dealdetail_uid = unique_id where base_ordhed_uid in ( " + nTools.GetIn(ids) + " ) ");
        }
        public void AbsorbCompanyAndContact(ContextRz context, company xCompany, companycontact xContact)
        {
            if (xCompany != null)
                AbsorbCompany(context, xCompany);
            else
                return;
            if (xContact != null)
                AbsorbContact(context, xContact);
        }
        public virtual void AbsorbContact(ContextNM context, companycontact xContact)
        {
            if (xContact == null)
                return;
            try    //this can raise an exception
            {
                ContactVar.RefSet(context, xContact);
            }
            catch (Exception)
            {
                return;
            }
            try
            {

                try
                {
                    if ((bool)xContact.IGet("never_follow_up"))
                        followup_date = Tools.Dates.GetNullDate();
                }
                catch { }

                if (Tools.Strings.StrExt(xContact.contactname))
                    contactname = xContact.contactname;
                if (Tools.Strings.StrExt(xContact.primaryphone))
                    primaryphone = xContact.primaryphone;
                if (Tools.Strings.StrExt(xContact.primaryfax))
                    primaryfax = xContact.primaryfax;
                if (Tools.Strings.StrExt(xContact.primaryemailaddress))
                    primaryemailaddress = xContact.primaryemailaddress;
                if (xContact.HasValidMailingAddress())
                {
                    switch (OrderType)
                    {
                        case Rz5.Enums.OrderType.Sales:
                        case Rz5.Enums.OrderType.Purchase:
                            //billingaddress = xContact.BuildAddress();
                            //shippingaddress = xContact.BuildAddress();
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void ClearCompany(ContextRz x)
        {
            CompanyVar.RefsRemoveAll(x);
            ContactVar.RefsRemoveAll(x);
            terms = "";
            shippingaccount = "";
            freightbilling = "";
            billingaddress = "";
            shippingaddress = "";
            primaryphone = "";
            primaryfax = "";
            primaryemailaddress = "";
            billingname = "";
            shippingname = "";
        }
        public Double ShippedAmount(ContextRz context)
        {
            return SubTotal(context) + shippingamount + handlingamount + taxamount;
        }
        public Double FiledAmount(ContextRz context)
        {
            return SubTotal(context) + shippingamount + handlingamount + taxamount;
        }

        //this is automatic now
        //public void GatherDetails()
        //{
        //    contextRz.TheLeader.Error("reorg");

        //    //Tools.FileSystem.PopText(System.Threading.Thread.CurrentThread.);
        //    //m_AllDetails = xSys.QtD(OrddetName, "select * from " + OrddetName + " where base_ordhed_uid = '" + unique_id + "' order by linecode");
        //    //foreach (KeyValuePair<String, nObject> k in m_AllDetails)
        //    //{
        //    //    orddet d = (orddet)k.Value;
        //    //    d.ParentOrder = this;
        //    //}
        //}

        //public void GatherLinks()
        //{
        //    AllLinks = xSys.QtC("ordlnk", "select * from ordlnk where orderid1 = '" + unique_id + "' or orderid2 = '" + unique_id + "'");
        //}
        public void GatherTransactions(ContextRz context)
        {
            AllTransactionsSet(context.QtC("checkpayment", "select * from checkpayment where base_ordhed_uid = '" + unique_id + "' and transtype = '" + TransactionType + "' order by transdate"));
        }
        public String TransactionType
        {
            get
            {
                switch (OrderType)
                {
                    case Enums.OrderType.Invoice:
                    case Enums.OrderType.RMA:
                    case Enums.OrderType.Service:
                        return "Payment";
                    case Enums.OrderType.Purchase:
                    case Enums.OrderType.VendRMA:
                        return "Check";
                        //Below was original, changed to match type in Payments screen
                        //case Enums.OrderType.Invoice:
                        //    return "Payment";
                        //case Enums.OrderType.VendRMA:
                        //    return "Payment";
                        //case Enums.OrderType.Purchase:
                        //    return "Check";
                        //case Enums.OrderType.RMA:
                        //    return "Check";                      
                }
                return "";
            }
        }
        public virtual Double SubTotal(ContextRz context)
        {
            return 0;
        }
        public virtual String FriendlyOrderType
        {
            get
            {
                return RzLogic.GetFriendlyOrderType(OrderType);
            }
        }
        public Enums.OrderDirection OrderDirection
        {
            get
            {
                return RzLogic.ConvertOrderDirection(OrderType);
            }
        }
        public Enums.OrderQuantityType QuantityType
        {
            get
            {
                return RzLogic.ConvertOrderQuantityType(OrderType);
            }
        }

        public checkpayment AddTransaction(ContextRz context)
        {
            checkpayment xCP = checkpayment.New(context);
            xCP.sendTransactionAlertEmail = true;
            xCP.sendAffiliateAlertEmail = true;
            xCP.base_ordhed_uid = unique_id;
            xCP.transtype = TransactionType;
            xCP.transdate = DateTime.Now;
            xCP.base_company_uid = base_company_uid;
            context.Insert(xCP);
            if (m_AllTransactions != null)
                m_AllTransactions.Add(xCP);
            return xCP;
        }


        public bool IsCompletelyReceived(ContextRz context)
        {
            List<IItem> details = Details.RefsGetAsItems(context).AllGet(context);
            if (details.Count == 0)
                return false;

            foreach (orddet_line l in details)
            {
                if (!l.was_received)
                    return false;
            }

            return true;
        }

        public void PrintPDF(ContextRz context)
        {
            context.Reorg();
            //context.Logic.ShowTransmitOrder(context, this, Enums.TransmitType.PDF);
        }
        public void PrintPDF(ContextRz context, printheader xLayout)
        {
            PrintPDF(context, xLayout, unique_id.Replace("-", ""));
        }
        public void PrintPDF(ContextRz context, printheader xLayout, String strID)
        {
            PrintSessionPdf pdf = new PrintSessionPdf(context, xLayout, this);
            pdf.Print();
        }
        public String PDFFileName(String strID)
        {
            return OrderType.ToString() + "_" + ordernumber + "_" + Tools.Strings.FilterTrash(companyname) + "_" + strID + ".pdf";
        }
        public void Preview(ContextRz context, printheader xLayout)
        {
            context.Reorg();
            //context.Logic.ShowTransmitOrder(context, this, xLayout);
        }
        public void Preview()
        {
        }

        public orddet GetDetailByNumber(ContextRz context, String strPart)
        {
            foreach (orddet d in DetailsList(context))
            {
                if (Tools.Strings.StrCmp(d.fullpartnumber, strPart))
                    return d;
            }
            return null;
        }

        public orddet GetDetailByLineCode(ContextRz context, long l)
        {
            foreach (orddet d in DetailsList(context))
            {
                if (d.LineCodeGet(this.OrderType) == l)
                    return d;
            }
            return null;
        }
        public bool CurrentAgentAccess(ContextRz context)
        {
            if (context.xUser.CheckPermit(context, "Order:View:Can View " + nTools.NiceFormat(ordertype)))
                return true;
            if (Tools.Strings.StrCmp(context.xUser.unique_id, base_mc_user_uid))
                return true;
            return false;
        }
        public void SelectAll(bool boolSelect)
        {

        }
        public void UpdateDetailTotals()
        {
            MessageBox.Show("reorg");


        }

        public ordlnk GetNewLink(ContextRz context)
        {
            ordlnk xLink = LinksFromVar.RefAddNew(context);
            xLink.Order1Var.RefSet(context, this);
            xLink.orderid1 = unique_id;  //should already be set
            xLink.ordernumber1 = ordernumber;
            xLink.ordertype1 = ordertype;
            context.TheDelta.Update(context, xLink);
            return xLink;
        }
        public ordhed GetNewOrder(ContextRz x, Enums.OrderType type)
        {
            return GetNewOrder(x, type, false, false, GetValidLines(x));
        }
        public ordhed GetNewOrder(ContextRz context, Enums.OrderType type, bool boolRMA, bool boolSkipLink, ArrayList lines)
        {
            if (lines.Count <= 0)
            {
                context.TheLeader.Tell("Before continuing, select the line items using the 'Select All' menu option.");
                return null;
            }

            ordhed xOrder = GetNewOrderHeader(context, type);
            if (xOrder == null)
                return null;

            if (!boolSkipLink)
                dealheader.CheckDealLinks(context, this, xOrder);
            //the details
            //broken out so it can be overridden
            GetNewOrderDetails(context, xOrder, lines, boolSkipLink);
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            //Create the link
            if (!boolSkipLink)
            {
                //MakeLinkObject(x, xOrder);
                context.TheSysRz.TheOrderLogic.Link2Orders(context, this, xOrder);
            }
            if (OrderType == Enums.OrderType.Quote && xOrder.OrderType == Enums.OrderType.Sales)//Quotes get closed when Sale is created
            {
                isclosed = true;
                context.Update(this);
            }
            return xOrder;
        }

        public ordhed GetNewOrderHeader(ContextRz x, Enums.OrderType type)
        {
            company xCompany = CompanyVar.RefGet(x);
            if (xCompany != null)
            {
                if (xCompany.ispastdue && (type == Enums.OrderType.Quote || type == Enums.OrderType.Sales || type == Enums.OrderType.Invoice))
                {
                    if (!xCompany.ShowPastDue(x))
                        return null;
                }
            }

            //if (!CheckForUnselected())
            //    return null;

            ordhed xOrder = ordhed.CreateNew(x, type);
            xOrder.CompanyVar.RefSet(x, xCompany);
            xOrder.ContactVar.RefSet(x, ContactVar.RefGet(x));

            //xOrder.base_companycontact_uid = base_companycontact_uid;
            //xOrder.contactname = contactname;

            //is the buyer system even used anymore?
            //xOrder.orderbuyerid = orderbuyerid;
            //xOrder.buyername = buyername;

            //what was this for?
            //xOrder.legacycontact = legacycontact;

            //xOrder.AgentVar.RefSet(x, AgentVar.RefGet(x));
            //if (!Tools.Strings.StrExt(xOrder.agentname))
            //    xOrder.agentname = agentname;
            //if (!Tools.Strings.StrExt(xOrder.base_mc_user_uid))
            //    xOrder.base_mc_user_uid = base_mc_user_uid;
            //n_user orderAgent = xOrder.AgentVar.RefSet(x, AgentVar.RefGet(x));

            n_user orderAgent = n_user.GetById(x, xCompany.base_mc_user_uid);
            if (orderAgent != null)
            {
                xOrder.agentname = orderAgent.name;
                xOrder.base_mc_user_uid = orderAgent.unique_id;
            }
            //xOrder.AgentVar.RefSet(x, AgentVar.RefGet(x));
            //if (!Tools.Strings.StrExt(xOrder.agentname))
            //    xOrder.agentname = agentname;
            //if (!Tools.Strings.StrExt(xOrder.base_mc_user_uid))
            //    xOrder.base_mc_user_uid = base_mc_user_uid;




            xOrder.is_government = is_government;
            //credit card stuff
            xOrder.creditcardnumber = creditcardnumber;
            xOrder.securitycode = securitycode;
            xOrder.creditcardtype = creditcardtype;
            xOrder.expiration_year = expiration_year;
            xOrder.expiration_month = expiration_month;
            xOrder.nameoncard = nameoncard;
            xOrder.cardbillingaddr = cardbillingaddr;
            xOrder.cardbillingzip = cardbillingzip;
            xOrder.legacycontact = legacycontact;
            //if (Rz3App.xLogic.IsAAT)
            //    xOrder.c_of_c = c_of_c;
            switch (OrderType)
            {
                case Enums.OrderType.Quote:
                    xOrder.orderreference = orderreference;
                    if (xOrder.OrderType == Enums.OrderType.Sales)
                        xOrder.AbsorbCharges(this);
                    break;
                case Enums.OrderType.Sales:
                    xOrder.orderreference = orderreference;
                    xOrder.soreference = ordernumber;
                    switch (xOrder.OrderType)
                    {
                        case Enums.OrderType.Invoice:
                            xOrder.printcomment = printcomment;
                            xOrder.AbsorbCharges(this);
                            break;
                    }
                    break;
                case Enums.OrderType.Invoice:
                    xOrder.orderreference = orderreference;
                    xOrder.soreference = ordernumber;
                    xOrder.invoice_number = ordernumber;
                    xOrder.invoice_date = orderdate;
                    xOrder.CheckForProblems(x);
                    break;
                default:
                    xOrder.soreference = soreference;
                    break;
            }
            switch (xOrder.OrderType)
            {
                case Enums.OrderType.Invoice:
                    xOrder.subtract_1 = subtract_1;
                    xOrder.subtract_2 = subtract_2;
                    xOrder.subtract_3 = subtract_3;
                    break;
                case Rz5.Enums.OrderType.RMA:
                    xOrder.requireddate = DateTime.Now.AddDays(30);
                    break;
                case Enums.OrderType.VendRMA:
                    //removed 2012_07_24
                    //there were complaints on this - the vendor supplies this and its confusing if we put this in here
                    //xOrder.orderreference = ordernumber;

                    xOrder.soreference = soreference;
                    break;
            }
            if (OrderDirection == xOrder.OrderDirection)
            {
                xOrder.billingname = billingname;
                xOrder.shippingname = shippingname;
            }
            xOrder.primaryphone = primaryphone;
            xOrder.primaryfax = primaryfax;
            xOrder.primaryemailaddress = primaryemailaddress;
            xOrder.billingaddress = billingaddress;
            xOrder.shippingaddress = shippingaddress;
            xOrder.shippingaccount = shippingaccount;
            xOrder.internalcomment = internalcomment;
            xOrder.shipvia = shipvia;
            xOrder.terms = terms;
            xOrder.base_mc_user_uid = base_mc_user_uid;
            xOrder.orderbuyerid = orderbuyerid;
            xOrder.dockdate = dockdate;
            xOrder.requireddate = requireddate;
            xOrder.freightbilling = freightbilling;
            xOrder.packinginfo = packinginfo;
            xOrder.orderfob = orderfob;
            x.Update(xOrder);
            return xOrder;
        }

        public ArrayList GetValidLines(ContextRz context)
        {
            ArrayList a = new ArrayList();
            foreach (orddet d in DetailsList(context))
            {
                orddet xDetail = d;
                if (!Tools.Strings.StrCmp(xDetail.status, "canceled") && !xDetail.isvoid)
                    a.Add(xDetail);
            }
            return a;
        }
        public ArrayList GetUnFilledValidLines()
        {
            ArrayList a = new ArrayList();
            //foreach (orddet d in DetailsList(context))
            //{
            //    orddet xDetail = (orddet)k.Value;
            //    if (xDetail.isselected && xDetail.quantityfilled < xDetail.quantityordered && !Tools.Strings.StrCmp(xDetail.status, "canceled"))
            //    {
            //        a.Add(xDetail);
            //    }
            //}
            return a;
        }
        public virtual void GetNewOrderDetails(ContextNM x, ordhed xOrder, ArrayList lines, bool skip_link)
        {
            MessageBox.Show("reorg");
            //foreach (orddet xDetail in lines)
            //{
            //    if (xDetail.isselected && !Tools.Strings.StrCmp(xDetail.status, "canceled"))
            //    {
            //        //If it is a sales order being turned into an invoice
            //        if (OrderType == Enums.OrderType.Sales && xOrder.OrderType == Enums.OrderType.Invoice)
            //        {
            //            //If the auto create lines feature is on
            //            //If xRz2.SysSettings.AUTOCREATESALELINES Then
            //            //If this line doesn't already have a stock ID
            //            if (!Tools.Strings.StrExt(xDetail.stockid))
            //            {
            //                //Create it
            //                xDetail.CreateLinkedPartRecord(x, Enums.StockType.Stock);
            //            }
            //        }
            //        //not the place for allocation
            //        orddet yDetail = xOrder.GetNewDetail();

            //        //2011_01_17
            //        //this needs to be much more controlled based on the order types involved
            //        yDetail.AbsorbDetailFull(xDetail);
            //        //AssociateDetails(xDetail, yDetail, false);

            //        //this all needs to be overridden
            //        if (Rz3App.xLogic.IsVoyager)
            //        {
            //            if (OrderType == Rz4.Enums.OrderType.Quote && xOrder.OrderType == Rz4.Enums.OrderType.Sales)
            //            {
            //                yDetail.shipdate = Tools.Dates.GetNullDate();  //set the lines to no ship date
            //            }
            //        }

            //        yDetail.quantityfilled = 0;
            //        yDetail.IUpdate();
            //        if (!skip_link)
            //            dealdetail.CheckDealLinksDetail(x, xDetail, yDetail);
            //    }
            //}
        }
        public void AbsorbCharges(ordhed xOrder)
        {
            shippingamount = xOrder.shippingamount;
            handlingamount = xOrder.handlingamount;
            taxamount = xOrder.taxamount;
            subtract_1 = xOrder.subtract_1;
            subtract_2 = xOrder.subtract_2;
            subtract_3 = xOrder.subtract_3;
            shipping_caption = xOrder.shipping_caption;
            handling_caption = xOrder.handling_caption;
            tax_caption = xOrder.tax_caption;
            subtract1_caption = xOrder.subtract1_caption;
            subtract2_caption = xOrder.subtract2_caption;
            subtract3_caption = xOrder.subtract3_caption;
        }

        public virtual void SendToQB(ContextRz context, bool confirm = true, bool showComments = true)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //((SysRz5)context.xSys).TheQuickBooksLogic.SendOrder((ContextRz)context, (ordhed_new)this);





            bool proceed = false;
            if (confirm)
                proceed = context.Leader.AskYesNo("Would you like to synchronize " + this.OrderType.ToString() + " Order #" + this.ordernumber + " with Quickbooks?");
            else
                proceed = true;

            if (!proceed)
                return;

            DateTime startTime = DateTime.Now;
            //context.TheLeader.Comment("Start Time: " + startTime);
            int totalSalesLines = 0;
            int totalPurchaseLines = 0;
            int totalServiceLines = 0;



            if (showComments)
                context.TheLeader.StartPopStatus("Starting Quickbooks Synchronization. " + startTime);



            //context.Leader.Comment("Sending " + this.OrderType.ToString() + " Order# " + this.ordernumber + " to Quickbooks ...");
            bool success = false;
            switch (this.OrderType)
            {
                case Enums.OrderType.Sales:
                    {
                        ordhed_sales sale = (ordhed_sales)this;
                        totalSalesLines = sale.DetailsList(context).Count();
                        success = sale.SendSalesOrderToQuickbooks(context);
                        break;
                    }
                case Enums.OrderType.Purchase:
                    {
                        ordhed_purchase purchase = (ordhed_purchase)this;
                        totalPurchaseLines = purchase.DetailsList(context).Count();
                        success = purchase.SendPurchaseOrderToQuickbooks(context);

                        break;
                    }
                case Enums.OrderType.Service:
                    {
                        ordhed_service serviceOrder = (ordhed_service)this;
                        totalServiceLines = serviceOrder.DetailsList(context).Count();
                        success = serviceOrder.SendServiceOrderToQuickbooks(context);
                        break;
                    }
            }

            if (success)
                context.Leader.Comment("Synchronization successful. ");
            else
                context.Leader.Comment("There was a problem sending " + this.OrderType.ToString() + " Order# " + this.ordernumber + " to Quickbooks.");


            string countMessage = "";
            if (totalSalesLines > 0)
                countMessage += "Total Sales Lines: " + totalSalesLines + Environment.NewLine;
            if (totalPurchaseLines > 0)
                countMessage += "Total Purchase Lines: " + totalPurchaseLines + Environment.NewLine;
            if (totalServiceLines > 0)
                countMessage += "Total Service Lines: " + totalServiceLines + Environment.NewLine;
            context.Leader.Comment(countMessage + Environment.NewLine);

            DateTime endTime = DateTime.Now;
            context.Leader.Comment("End time: " + endTime);
            double TotalMinutes = (endTime - startTime).TotalMinutes;
            double TotalSeconds = (endTime - startTime).TotalSeconds;

            TimeSpan totalDuration = (endTime - startTime);
            string duration = String.Format("{0} minutes, {1} seconds", totalDuration.Minutes, totalDuration.Seconds);
            context.Leader.Comment("Total Sync Duration: " + duration);
            if (showComments)
                context.TheLeader.StopPopStatus();

            //Cursor.Current = Cursors.Default;
        }

        public virtual bool ShouldSendToQB(ContextRz context)
        {
            if (!string.IsNullOrEmpty(qb_order_TxnID))
            {
                if (context.xUser.IsDeveloper())
                {
                    if (!context.TheLeader.AskYesNo(ToString() + " has already been sent; do you want to re-send it?"))
                        return false;
                }
                else
                {
                    context.TheLeader.Error(ToString() + " is already marked as having been sent.");
                    return false;
                }
            }
            return true;
        }

        public void Fax(ContextRz context)
        {
            context.Reorg();
            //context.Logic.ShowTransmitOrder(context, this, Enums.TransmitType.Fax);
        }

        public void Fax(ContextRz context, TransmitParameters pars)
        {
            String strFax = primaryfax;
            if (Tools.Strings.HasString(strFax, ","))
                strFax = Tools.Strings.ParseDelimit(strFax, ",", 1);
            if (!Tools.Strings.StrExt(strFax))
            {
                strFax = context.TheLeader.AskForString("Enter the fax number for '" + companyname + "'.", "", "");
                if (!Tools.Strings.StrExt(strFax))
                    return;
                if (context.TheLeader.AskYesNo("Do you want to set " + strFax + " as " + companyname + "'s fax number?"))
                {
                    company c = CompanyVar.RefGet(context);
                    if (c != null)
                    {
                        c.primaryfax = strFax;
                        context.Update(c);
                    }
                }
            }

            pars.FaxNumber = strFax.Replace(".", "").Trim();
            String s = context.xUser.GetSetting(context, "fax_printer_name");
            if (!Tools.Strings.StrExt(s))
            {
                s = context.TheLeader.AskForString("Please enter the fax printer name below:");
                if (Tools.Strings.StrExt(s))
                    context.xUser.SetSetting(context, "fax_printer_name", s);
            }

            if (Tools.Strings.StrExt(s))
            {
                pars.type = Rz5.Enums.TransmitType.Print;
                pars.PrinterName = s;
                pars.Print(context, this);
            }
            else
            {
                //context.TheLeader.Error("reorg");
                //SendFaxRequest(pars);
            }
        }
        //public bool SendFaxRequest(TransmitParameters pars)
        //{
        //    String prefix = Rz3App.xSys.GetSetting("fax_prefix_#");
        //    if (Tools.Strings.StrExt(prefix))
        //        pars.FaxPrefix = prefix;
        //    frmFaxRequest f = new frmFaxRequest();
        //    f.Show();
        //    f.CompleteLoad(Rz3App.xSys, pars, this);
        //    return true;
        //}
        public void Transmit(ContextRz context, TransmitParameters pars)
        {
            switch (pars.type)
            {
                case Enums.TransmitType.PDF:
                case Enums.TransmitType.Print:
                    pars.Print(context, this);
                    break;
                case Enums.TransmitType.Fax:
                    Fax(context, pars);
                    break;
                case Enums.TransmitType.Email:
                    Email(context, pars);
                    break;
            }
            //user_activity.AddActivity((ContextRz)context, "Order" + pars.type.ToString(), pars.type.ToString() + "ed " + this.ToString(), "Order" + pars.type.ToString(), 0, this);
            OrderComplete(context);
        }
        public virtual void OrderComplete(ContextRz context)
        {

        }
        public void Print(ContextRz x)
        {
            List<ordhed> orders = new List<ordhed>();
            orders.Add(this);
            x.Leader.ShowTransmitOrders(x, orders, Enums.TransmitType.Print);
            //context.Logic.ShowTransmitOrder(context, this, Enums.TransmitType.Print);
        }

        public void Email(ContextRz context)
        {
            List<ordhed> orders = new List<ordhed>();
            orders.Add(this);
            context.Leader.ShowTransmitOrders(context, orders, Enums.TransmitType.Email);
        }

        public void Email(ContextRz context, TransmitParameters pars)
        {
            try
            {
                if (pars.EmailTemplate == null)
                    return;
                String strEmail = primaryemailaddress;
                if (!Tools.Strings.StrExt(strEmail))
                {
                    strEmail = context.TheLeader.AskForString("Enter the email address for '" + companyname + "'.", "", "");
                    if (!Tools.Strings.StrExt(strEmail))
                        return;
                    if (context.TheLeader.AskYesNo("Do you want to set " + strEmail + " as " + companyname + "'s email address?"))
                    {
                        company c = CompanyVar.RefGet(context);
                        if (c != null)
                        {
                            c.primaryemailaddress = strEmail;
                            context.Update(c);
                        }
                    }
                    primaryemailaddress = strEmail;
                    context.Update(this);
                }
                pars.EmailAddress = strEmail;




                string emailSent = pars.EmailTemplate.SendOrderEmail(context, this, false, "", false, true, pars.UseInternalEmail, "", "", pars.Attachment, "", pars.CCLines, pars.ConsolidateLines, null, pars.IncludePDF);
            }
            catch (Exception ex)
            {
                context.TheLeader.Tell("There was an error sending this email: " + ex.Message);
            }
        }




        public Enums.FillType FillType
        {
            get
            {
                switch (OrderType)
                {
                    case Enums.OrderType.Purchase:
                        return Enums.FillType.Receive;
                    case Enums.OrderType.RMA:
                        return Enums.FillType.Receive;
                    case Enums.OrderType.Invoice:
                        return Enums.FillType.Pick;
                    case Enums.OrderType.VendRMA:
                        return Enums.FillType.Pick;
                }
                return Enums.FillType.Receive;
            }
        }
        public Double GetNetProfit(bool SubtractOverhead)
        {
            MessageBox.Show("reorg");
            return 0;

            //Double dblNet = 0;
            //foreach (orddet d in DetailsList(context))
            //{
            //    orddet d = (orddet)k.Value;
            //    dblNet += d.GetNetProfit();
            //}
            //if (SubtractOverhead)
            //{
            //    dblNet -= shippingamount;
            //    dblNet -= handlingamount;
            //    dblNet -= taxamount;
            //}
            //return dblNet;
        }
        public Double GetGrossProfit(ContextRz context, bool SubtractOverhead)
        {
            Double dblGross = 0;
            context.TheLeader.Error("reorg");

            //foreach (orddet d in DetailsList(context))
            //{
            //    orddet d = (orddet)k.Value;
            //    dblGross += d.GetGrossProfit();
            //}
            //if (SubtractOverhead)
            //{
            //    dblGross -= shippingamount;
            //    dblGross -= handlingamount;
            //    dblGross -= taxamount;
            //}
            return dblGross;
        }
        public bool CheckOrderData(ContextRz x, List<string> ignoreList = null)
        {

            if (this.OrderType == Enums.OrderType.Purchase)
            {
                //Consignment PO's will be missing these properties, and that's fine.
                ordhed_purchase p = (ordhed_purchase)this;
                if (p.is_consign)
                    return true;
            }

            LoadMissingProperties(x, true);

            if (ignoreList != null)
                if (MissingPropertiesList.Count > 0)
                    MissingPropertiesList = RemoveIgnoredProperties(ignoreList);

            if (MissingPropertiesList.Count > 0)
            {
                x.Leader.Tell("Please gather all required properties before transmitting this order.");
                return false;
            }
            return true;
        }



        //public virtual bool CheckOrderData(ContextNM context, StringBuilder sb)
        //{
        //    if (OrderType == Rz5.Enums.OrderType.Service)
        //        return true;
        //    bool boolContinue = true;
        //    if (!Tools.Strings.StrExt(base_company_uid))
        //    {
        //        boolContinue = false;
        //        sb.AppendLine("This " + OrderType.ToString() + " is not assigned to a company");
        //    }
        //    if (OrderType == Enums.OrderType.Quote || OrderType == Enums.OrderType.RFQ)
        //        return boolContinue;
        //    if (!Tools.Strings.StrExt(orderreference) && OrderDirection == Enums.OrderDirection.Outgoing && OrderType != Enums.OrderType.VendRMA)
        //    {
        //        boolContinue = false;
        //        sb.AppendLine("The order reference is blank");
        //    }
        //    if (!Tools.Strings.StrExt(terms))
        //    {
        //        boolContinue = false;
        //        sb.AppendLine("The terms field is blank");
        //    }
        //    //Ship Via on orddet_line not ordhed anymore
        //    //if (!Tools.Strings.StrExt(shipvia))
        //    //{
        //    //    boolContinue = false;
        //    //    sb.AppendLine("The ship via field is blank");
        //    //}
        //    return boolContinue;
        //}


        public Double GetTotalCost(ContextRz context)
        {
            Double dbl = 0;
            foreach (orddet_line d in DetailsList(context))
            {
                dbl += d.unit_cost * d.quantity_unpacked;
            }
            return dbl;
        }
        public Double GetTotalPrice(ContextRz context)
        {
            Double dbl = 0;
            foreach (orddet_line d in DetailsList(context))
            {
                dbl += d.unit_price * d.quantity_packed;
            }
            return dbl;
        }

        public String GetVendorNames(ContextRz context)
        {
            String ret = "";
            foreach (orddet_line d in DetailsList(context))
            {
                String v = d.vendor_name;
                if (Tools.Strings.StrExt(v))
                {
                    if (!Tools.Strings.HasString(ret, v))
                    {
                        if (ret != "")
                            ret += ", ";
                        ret += v;
                    }
                }
            }
            return ret;
        }

        public String UserID
        {
            get
            {
                return base_mc_user_uid;
            }
            set
            {
                base_mc_user_uid = value;
            }
        }
        public String UserName
        {
            get
            {
                return agentname;
            }
            set
            {
                agentname = value;
            }
        }
        public n_user UserObjectGet(ContextRz context)
        {
            return (n_user)context.xSys.Users.GetByID(base_mc_user_uid);
        }
        public n_user BuyerObjectGet(ContextRz context)
        {
            return (n_user)context.xSys.Users.GetByID(orderbuyerid);
        }
        public void UserObjectSet(n_user value)
        {
            if (value == null)
            {
                base_mc_user_uid = "";
                agentname = "";
            }
            else
            {
                base_mc_user_uid = value.unique_id;
                agentname = value.name;
            }
        }

        public n_user BuyerObject(ContextRz context)
        {
            return (n_user)context.xSys.Users.GetByID(orderbuyerid);
        }

        public void BuyerObject(n_user value)
        {
            if (value == null)
            {
                orderbuyerid = "";
                buyername = "";
            }
            else
            {
                orderbuyerid = value.unique_id;
                buyername = value.name;
            }
        }

        public String GetAgentEmailAddress(ContextRz context)
        {
            NewMethod.n_user u = UserObjectGet(context);
            if (u == null)
                return context.Logic.DefaultEmailAddress;
            else
                return u.email_address;
        }
        public virtual void SendASN(ContextRz context)
        {
            emailtemplate xEmail = context.TheLeaderRz.AskForEmailTemplate(this);
            if (xEmail == null)
                return;
            xEmail.SendOrderEmail(context, this);
        }
        public void NotifyBuyer(ContextRz context)
        {
            emailtemplate xEmail = context.TheLeaderRz.AskForEmailTemplate(this);
            if (xEmail == null)
                return;
            String strAddress = GetAgentEmailAddress(context);
            if (!Tools.Strings.StrExt(strAddress))
                strAddress = context.TheLeader.AskForString("Please enter the purchaser's e-mail address.", "", "E-mail Address");
            if (!Tools.Strings.StrExt(strAddress))
                return;
            xEmail.SendOrderEmail(context, this, strAddress);
        }

        public orddet FindMatchingDetail(orddet xDetail)
        {
            MessageBox.Show("reorg");
            //foreach (orddet d in DetailsList(context))
            //{
            //    orddet d = (orddet)k.Value;
            //    //in the original, this was d.unitprice = xDetail.unitcost for some reason
            //    if (Tools.Strings.StrCmp(d.fullpartnumber, xDetail.fullpartnumber) && Tools.Strings.StrCmp(d.manufacturer, xDetail.manufacturer) && Tools.Strings.StrCmp(d.datecode, xDetail.datecode) && (d.unitprice == xDetail.unitprice))
            //    {
            //        return d
            //    }
            //}
            return null;
        }
        public virtual Double Expenses
        {
            get
            {
                return (shippingamount + handlingamount + taxamount);
            }
        }
        public Double CalcRMAAmount(ContextRz context)
        {
            return context.SelectScalarDouble("select ordertotal from " + MakeOrdhedName(Enums.OrderType.RMA) + " where unique_id in (select orderid2 from ordlnk where ordertype2 ='RMA' and orderid1 = '" + unique_id + "')");
        }



        //public List<ordhed_sales> GetRelatedSales(ContextRz context)
        //{

        //    List<ordhed_sales> ret = new List<ordhed_sales>();

        //    foreach (orddet_line l in this.DetailsList(context))
        //    {
        //        ordhed_sales s = (ordhed_sales)context.QtO("ordhed_sales", "select * from ordhed_sales where unique_id = '" + l.orderid_sales + "'");
        //        if (s != null)
        //            ret.Add(s);
        //    }
        //    return ret;
        //    //return (ordhed)context.QtO(MakeOrdhedName(Enums.OrderType.Sales), "select * from " + MakeOrdhedName(Enums.OrderType.Sales) + " where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'sales')");
        //}

        public ordhed GetRelatedSale(ContextRz context)
        {
            return (ordhed)context.QtO(MakeOrdhedName(Enums.OrderType.Sales), "select * from " + MakeOrdhedName(Enums.OrderType.Sales) + " where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'sales')");
        }
        public ArrayList GetRelatedPurchases(ContextRz context)
        {
            return context.QtC(MakeOrdhedName(Enums.OrderType.Purchase), "select * from " + MakeOrdhedName(Enums.OrderType.Purchase) + " where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'purchase')");
        }
        //KT 9-1-2015
        public ArrayList GetRelatedInvoices(ContextRz context)
        {
            return context.QtC(MakeOrdhedName(Enums.OrderType.Invoice), "select * from " + MakeOrdhedName(Enums.OrderType.Invoice) + " where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'invoice')");
        }

        public dealheader GetRelatedDealheader(ContextRz context)
        {

            //return context.QtC("ordhed_quote", "select * from ordhed_quote where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'quote')");  
            //return context.QtC(MakeOrdhedName(Enums.OrderType.Quote), "select * from " + MakeOrdhedName(Enums.OrderType.Quote) + " where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'quote')");
            //Loop through the lines, need to assumy 1 quote per sale, get dealheader from any orddet_quote.dealheader.uid.
            string dealheaderUID = null;

            if (OrderType == OrderType.Quote)
            {
                List<orddet_quote> qList = DetailsList(context).Cast<orddet_quote>().ToList();
                dealheaderUID = qList.Select(s => s.base_dealheader_uid).FirstOrDefault();
            }
            else
            {

                ArrayList arrQuotes = GetRelatedQuotes(context);
                if (arrQuotes == null)
                    return null;
                if (arrQuotes.Count <= 0)
                    return null;
                ordhed_quote q = (ordhed_quote)arrQuotes[0];
                if (q == null)
                    return null;
                List<orddet_quote> qList = q.DetailsList(context).Cast<orddet_quote>().ToList();
                //Need to get the related quote.
                if (qList.Count == 1)
                {
                    dealheaderUID = qList.Select(s => s.base_dealheader_uid).FirstOrDefault();
                }
            }
            dealheader ret = null;
            if (!string.IsNullOrEmpty(dealheaderUID))
                ret = (dealheader)context.QtO("dealheader", "select * from dealheader where unique_id = '" + dealheaderUID + "'");
            return ret;

        }
        public ArrayList GetRelatedQuotes(ContextRz context)
        {
            ArrayList ret = null;


            List<orddet> odList = DetailsList(context);
            List<string> quoteHeaderUids = new List<string>();
            foreach (orddet_line l in odList)
            {
                orddet_quote q = orddet_quote.GetById(context, l.quote_line_uid);
                if (q != null)
                {
                    if (!string.IsNullOrEmpty(q.base_ordhed_uid))
                        if (!quoteHeaderUids.Contains(q.base_ordhed_uid))
                            quoteHeaderUids.Add(q.base_ordhed_uid);
                }
            }
            if (quoteHeaderUids.Count > 0)
                ret = context.QtC("ordhed_quote", "select * from ordhed_quote where unique_id in (" + Data.GetIn(quoteHeaderUids) + ")");
            return ret;
        }

        //public ordhed_quote GetRelatedQuote(ContextRz context)
        //{
        //    ordhed_quote q = null;
        //    //return context.QtC("ordhed_quote", "select * from ordhed_quote where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'quote')");  
        //    //return context.QtC(MakeOrdhedName(Enums.OrderType.Quote), "select * from " + MakeOrdhedName(Enums.OrderType.Quote) + " where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'quote')");
        //    if (OrderType == OrderType.Quote)
        //    {
        //        q = (ordhed_quote)this;
        //        return q;
        //    }

        //    List<orddet_line> lines = DetailsList(context).Cast<orddet_line>().ToList();
        //    string quote_line_uid = lines.Select(s => s.quote_line_uid).FirstOrDefault();
        //    if (string.IsNullOrEmpty(quote_line_uid))
        //        return null;
        //    orddet_quote qq = orddet_quote.GetById(context, quote_line_uid);
        //    if (qq == null)
        //        return null;
        //    ordhed_quote ohQ = ordhed_quote.GetById(context, qq.base_ordhed_uid);
        //    return ohQ;
        //}





        public ArrayList GetRelatedPayments(ContextRz context)
        {
            return context.QtC("checkpayment", "select * from checkpayment where base_ordhed_uid = '" + this.unique_id + "'");


        }


        public ArrayList GetRelatedServiceOrders(ContextRz context, List<orddet> lines)
        {
            if (lines.Count <= 0)
                return null;
            ArrayList svcList = new ArrayList();
            foreach (orddet d in lines)
            {
                string svcID = "";
                ordhed_service svcHead = new ordhed_service();
                orddet_line l = (orddet_line)d;
                svcID = l.orderid_service;
                if (!string.IsNullOrEmpty(svcID))
                {
                    svcHead = ordhed_service.GetById(context, l.orderid_service);
                    if (!svcList.Contains(svcHead))
                        svcList.Add(svcHead);
                }
            }

            return svcList;
            //return context.QtC("ordhed_quote", "select * from ordhed_quote where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'quote')");  
            //return context.QtC(MakeOrdhedName(Enums.OrderType.Service), "select * from " + MakeOrdhedName(Enums.OrderType.Service) + " where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'service')");
        }

        public bool DidAgentPurchase(ContextRz context, String agentid)
        {
            ordhed xSale = GetRelatedSale(context);
            if (xSale == null)
                return false;
            return context.TheData.TheConnection.StatementExists("select unique_id from " + MakeOrdhedName(Enums.OrderType.Purchase) + " where ordertype = 'PURCHASE' and base_mc_user_uid = '" + base_mc_user_uid + "' and unique_id in (select orderid2 from ordlnk where orderid1 = '" + xSale.unique_id + "')");
        }

        public ordhed GetLinkedRMA(ContextRz context)
        {
            return (ordhed)context.QtO(MakeOrdhedName(Enums.OrderType.RMA), "select * from " + MakeOrdhedName(Enums.OrderType.RMA) + " where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'RMA' )");
        }
        public ordhed_purchase GetLinkedPurchase(ContextRz context)
        {
            return (ordhed_purchase)context.QtO(MakeOrdhedName(Enums.OrderType.Purchase), "select * from " + MakeOrdhedName(Enums.OrderType.Purchase) + " where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'PURCHASE' )");
        }
        public ArrayList GetLinkedServiceOrders(ContextRz context)
        {
            return context.QtC(MakeOrdhedName(Enums.OrderType.Service), "select * from " + MakeOrdhedName(Enums.OrderType.Service) + " where unique_id in (select orderid2 from ordlnk where orderid1 = '" + unique_id + "' and ordertype2 = 'SERVICE' )");
        }
        //public void PrintAATResaleCert()
        //{
        //    MessageBox.Show("reorg");
        //    //try
        //    //{
        //    //    filelink link = (filelink)xSys.QtO("filelink", "select * from filelink where linktype = 'resalecert' and linkname = 'Resale Certificate' and filetype = 'pdf' and objectclass = 'ordhed'");
        //    //    if (link == null)
        //    //        return;
        //    //    link.LoadPictureData();
        //    //    link.ShellData();
        //    //}
        //    //catch (Exception)
        //    //{
        //    //}
        //}
        public Double GetReturnValue(ContextRz context)
        {
            context.TheLeader.Error("reorg");

            Double dbl = 0;
            //foreach (orddet d in DetailsList(context))
            //{
            //    orddet d = (orddet)k.Value;
            //    dbl += (d.unitprice * d.quantityfilled);
            //}
            return dbl;
        }
        //public String GetPONumber()
        //{
        //    return xSys.xData.GetScalar_String("select ordernumber2 from ordlnk where ordertype2 = 'SALES' and orderid1 = '" + unique_id + "'");
        //}
        public void ExportCompanyToQB(ContextRz context)
        {
            company c = CompanyVar.RefGet(context);
            if (c == null)
                throw new Exception("A linked company was not found for " + ToString());

            context.TheSysRz.TheQuickBooksLogic.MakeCompanyExist(context, this);
            context.TheLeader.TellTemp(CompanyVar.RefGet(context).ToString() + " was sent to QuickBooks.");
        }
        public Enums.CompanySelectionType CompanyType
        {
            get
            {
                switch (OrderType)
                {
                    case Enums.OrderType.Quote:
                        return Enums.CompanySelectionType.Customer;
                    case Enums.OrderType.Sales:
                        return Enums.CompanySelectionType.Customer;
                    case Enums.OrderType.Invoice:
                        return Enums.CompanySelectionType.Customer;
                    case Enums.OrderType.VendRMA:
                        return Enums.CompanySelectionType.Customer;
                    default:
                        return Enums.CompanySelectionType.Vendor;
                }
            }
        }
        public bool CheckDoNotSell(ContextRz context)
        {
            company xCompany = CompanyVar.RefGet(context);
            if (xCompany == null)
                return true;
            companyaddress xAddress = xCompany.GetPrimaryBillingAddress(context);
            if (xAddress == null)
                xAddress = companyaddress.New(context);

            if (context.Logic.ShouldNotSell(context, companyname, contactname, xAddress.line1, xAddress.line2, xAddress.adrcity, xAddress.adrstate, xAddress.adrzip, xAddress.adrcountry, primaryphone, primaryfax, primaryemailaddress))
            {
                context.TheLeader.Error("This company, contact, phone number, or address is listed on the ITAR 'Do Not Sell' list, and cannot be transmitted.");
                return false;
            }
            else
            {
                return true;
            }
        }
        public usernote CreateFollowUpReminder(ContextRz context)
        {
            usernote xNote = usernote.New(context);
            xNote.base_company_uid = base_company_uid;
            xNote.for_mc_user_uid = context.xUser.unique_id;
            xNote.by_mc_user_uid = context.xUser.unique_id;
            xNote.notetext = "Follow Up Reminder";
            xNote.shouldpopup = true;
            context.Insert(xNote);
            xNote.displaydate = DateTime.Now.Add(new TimeSpan(4, 0, 0));
            context.Update(xNote);
            xNote.CreateObjectLink(context, this, this.ToString());
            return xNote;
        }
        public void PopQB()
        {
            throw new NotImplementedException("Order.PopQBInfo");
            //PopQBInfo(companyname, contactname, primaryphone, primaryfax, primaryemailaddress);
        }
        //public int GetNoCostLineCount()
        //{
        //    int i = 0;
        //    contextRz.TheLeader.Error("reorg");
        //    //foreach (orddet d in DetailsList(context))
        //    //{
        //    //    orddet d = (orddet)k.Value;
        //    //    if (d.unitprice != 0 && d.unitcost == 0)
        //    //        i++;
        //    //}
        //    return i;
        //}



        public void PutOnHold(ContextRz context)
        {
            String strHold;
            strHold = "An Order Has Been Put On Hold\r\nOrder: " + ToString() + "\r\nOrder Agent: " + agentname + "\r\nHold Date: " + nTools.DateFormat(DateTime.Now) + "\r\nHold Agent: " + context.xUser.name + "\r\n";
            onhold = true;
            holdreason = strHold;
            context.Update(this);
            //create notes to everyone.
            context.TheSysRz.TheOrderLogic.CreateHoldNoteByName(context, this, strHold);
            CreateHoldNoteByID(context, base_mc_user_uid, strHold);
            if (Tools.Strings.StrExt(orderbuyerid) && !Tools.Strings.StrCmp(base_mc_user_uid, orderbuyerid))
                CreateHoldNoteByID(context, orderbuyerid, strHold);
            context.TheLeader.TellTemp(ToString() + " has been placed on hold.");
        }
        //public bool CheckHold(ContextNM context)
        //{
        //    if (!onhold)
        //        return true;

        //    if (Tools.Strings.StrExt(holdreason))
        //    {
        //        context.TheLeader.Tell(GetFriendlyName() + " has been placed on hold:\r\n\r\n" + holdreason);
        //        return false;
        //    }

        //    //2010_01_29    this has to be allowed even for sales orders, or else the proforma invoice can't be printed.
        //    return true;

        //    //if (OrderType != Rz4.Enums.OrderType.Sales)
        //    //    return true;


        //    //else if (OrderType == Rz4.Enums.OrderType.Sales)
        //    //{
        //    //    if (!Rz3App.xLogic.IsSelect)
        //    //    {
        //    //        context.TheLeader.Tell(GetFriendlyName() + " has not been completed.  To continue, click 'Sales Order Complete'.");
        //    //        return false;
        //    //    }
        //    //}
        //    //return true;

        //    // 2010_01_12  this was just returning true before; wtf?
        //    // 2010_01_14  it was because the sales order case was already handled; this was a problem for service orders

        //    //context.TheLeader.Tell(GetFriendlyName() + " has not been completed.  To continue, click 'Sales Order Complete'.");
        //    //return false;
        //}
        public bool CheckFillSales(ContextRz context)    //Called by a purchase order line item that is received
        {
            ordhed a = ordhed.New(context);  // new ordhed(context.xSys);
            return CheckFillSales(context, ref a);
        }
        public bool CheckFillSales(ContextRz context, ref ordhed invoice)    //Called by a purchase order line item that is received
        {
            if (!IsReceived(context))
                return false;

            ArrayList sales = GetLinkedSalesOrders(context);
            if (sales.Count <= 0)
                return false;
            bool b = false;
            foreach (ordhed_sales xSales in sales)
            {
                if (xSales.isvoid)
                {
                    context.TheLeader.TellTemp(xSales.ToString() + " is linked to this PO, but it is marked as void.");
                }
                else
                {
                    ArrayList a = context.QtC(ordhed.MakeOrdhedName(Enums.OrderType.Purchase), GetLinkedPOSQL(xSales.unique_id));
                    ArrayList colPOs = new ArrayList();
                    foreach (ordhed o in a)
                    {
                        if (!o.isvoid)
                            colPOs.Add(o);
                    }
                    if (colPOs == null)
                        return false;
                    if (colPOs.Count <= 0)
                        return false;
                    bool received = true;
                    foreach (ordhed xPO in colPOs)
                    {
                        if (!Tools.Strings.StrCmp(xPO.unique_id, this.unique_id) && !xPO.isvoid && (!Tools.Strings.StrCmp(xPO.packinginfo, "Vendor RMA")))
                        {
                            if (!xPO.IsReceived(context))
                                received = false;
                        }
                    }
                    if (received && !xSales.ReadyToShip)
                    {
                        if (context.TheLeader.AskYesNo(xSales.ToString() + " is ready to ship.  Do you want to convert this order to an invoice?"))
                        {
                            List<ordhed_invoice> invoices = xSales.MakeInvoiceWithChecks(context);
                            if (invoices != null && invoices.Count > 0)
                                invoice = invoices[0];
                            //invoice = GenerateInvoiceFromSalesOrder(context, xSales, ref b);
                        }
                    }
                }
            }
            return b;
        }

        public virtual void ApplyNewCurrency(ContextRz context, currency newCurrency)
        {
            currency_name = newCurrency.Name;
            exchange_rate = newCurrency.exchange_rate;

            SetShipping(shippingamount);
            SetHandling(handlingamount);
            SetTax(taxamount);

            //the details are handled in overrides
        }

        public void SetShipping(Double shippingInBaseUnits)
        {
            shippingamount = shippingInBaseUnits;
            shippingamount_exchanged = currency.CalculateExchangeFromBase(shippingamount, exchange_rate, 2);
        }

        public void SetHandling(Double handlingInBaseUnits)
        {
            handlingamount = handlingInBaseUnits;
            handlingamount_exchanged = currency.CalculateExchangeFromBase(handlingamount, exchange_rate, 2);
        }

        public void SetTax(Double taxInBaseUnits)
        {
            taxamount = taxInBaseUnits;
            taxamount_exchanged = currency.CalculateExchangeFromBase(taxamount, exchange_rate, 2);
        }

        public bool ReadyToShip
        {
            get
            {
                return Tools.Strings.StrCmp(packinginfo, "Ready To Ship");
            }
            set
            {
                if (value)
                {
                    packinginfo = "Ready To Ship";
                }
                else
                {
                    packinginfo = "";
                }
            }
        }
        public bool WaitingForReOrder
        {
            get
            {
                return Tools.Strings.StrCmp(packinginfo, "Waiting For Re-order");
            }
            set
            {
                if (value)
                {
                    packinginfo = "Waiting For Re-order";
                }
                else
                {
                    packinginfo = "";
                }
            }
        }
        public String GetLinkedPOSQL()
        {
            return GetLinkedPOSQL("");
        }
        public String GetLinkedPOSQL(String strSalesID)
        {
            if (!Tools.Strings.StrExt(strSalesID))
                strSalesID = unique_id;
            return "select * from " + MakeOrdhedName(Enums.OrderType.Purchase) + " where ordertype = 'PURCHASE' and unique_id in (select orderid2 from ordlnk where ordertype1 = 'sales' and orderid1 = '" + strSalesID + "')";
        }
        public void CheckFillVendRMA(ContextRz context)
        {
            //how should an rma be linked to a vendor rma?
            //directly, through the rma creation screen
            ordhed xVRMA = GetLinkedVendorRMA(context);
            if (xVRMA == null)
                return;
            xVRMA.ReadyToShip = true;
            context.Update(xVRMA);
            context.TheLeader.Tell(xVRMA.ToString() + " has been marked 'Ready To Ship'.");
        }
        public ordlnk GetLink(ContextRz context, String strOrderID1, String strOrderType1, String strOrderID2, String strOrderType2)
        {
            try
            {
                ArrayList a = GetLinks(context, strOrderID1, strOrderType1, strOrderID2, strOrderType2);
                if (a.Count <= 0)
                    return null;
                else
                    return (ordlnk)a[0];
            }
            catch
            {
                return null;
            }
        }
        public ArrayList GetLinks(ContextRz context, String strOrderID1, String strOrderType1, String strOrderID2, String strOrderType2)
        {
            ArrayList ret = new ArrayList();
            ArrayList ids = new ArrayList();
            foreach (ordlnk l in LinksListAll(context))
            {
                //Compare the orderid(if exist) to teh orderID on the link. 
                bool b = true;
                if (Tools.Strings.StrExt(strOrderID1) && !Tools.Strings.StrCmp(strOrderID1, l.orderid1))
                    b = false;
                if (Tools.Strings.StrExt(strOrderType1) && !Tools.Strings.StrCmp(strOrderType1, l.ordertype1))
                    b = false;
                if (Tools.Strings.StrExt(strOrderID2) && !Tools.Strings.StrCmp(strOrderID2, l.orderid2))
                    b = false;
                if (Tools.Strings.StrExt(strOrderType2) && !Tools.Strings.StrCmp(strOrderType2, l.ordertype2))
                    b = false;
                if (b)
                {
                    if (!ids.Contains(l.unique_id))
                    {
                        ids.Add(l.unique_id);
                        ret.Add(l);
                    }
                }
            }
            return ret;
        }

        public List<ordlnk> LinksListAll(ContextRz context)  //this is how the links collection was originally set up; why is this useful?
        {
            List<ordlnk> ret = new List<ordlnk>();

            foreach (ordlnk l in LinksFromVar.RefsList(context))
            {
                ret.Add(l);
            }

            foreach (ordlnk l in LinksToVar.RefsList(context))
            {
                ret.Add(l);
            }

            return ret;
        }

        public ordhed_sales GetLinkedSalesOrder(ContextRz context)
        {
            ordlnk xLink = GetLink(context, "", "sales", unique_id, "");
            if (xLink == null)
                return null;
            return (ordhed_sales)xLink.Order1Var.RefGet(context);
        }
        public ordhed GetLinkedPurchaseOrder(ContextRz context)
        {
            ordhed so = GetLinkedSalesOrder(context);
            if (OrderType == Enums.OrderType.Sales)
                so = this;
            if (so == null)
                return null;
            ordlnk xLink = so.GetLink(context, "", "purchase", so.unique_id, "");
            if (xLink == null)
                return null;
            return xLink.Order1Var.RefGet(context);
        }

        //KT - Copied from GetLinkedSalesOrders 10-5-2015
        public ArrayList GetLinkedPurchaseOrders(ContextRz context)
        {
            ArrayList links = GetLinks(context, "", "purchase", unique_id, "");
            ArrayList ids = new ArrayList();
            ArrayList ret = new ArrayList();
            foreach (ordlnk xLink in links)
            {
                if (xLink.Order1Var.RefGet(context) == null)
                    continue;
                String order1id = xLink.Order1Var.RefGet(context).unique_id;
                if (!ids.Contains(order1id))
                {
                    ret.Add(xLink.Order1Var.RefGet(context));
                    ids.Add(order1id);
                }
            }
            return ret;
        }



        public ArrayList GetLinkedSalesOrders(ContextRz context)
        {
            ArrayList links = GetLinks(context, "", "sales", unique_id, "");
            ArrayList ids = new ArrayList();
            ArrayList ret = new ArrayList();
            foreach (ordlnk xLink in links)
            {
                String order1id = xLink.Order1Var.RefGet(context).unique_id;
                if (!ids.Contains(order1id))
                {
                    ret.Add(xLink.Order1Var.RefGet(context));
                    ids.Add(order1id);
                }
            }
            return ret;
        }
        public ordhed GetLinkedInvoice(ContextRz context)
        {
            ordlnk xLink = GetLink(context, "", "invoice", unique_id, "");
            if (xLink == null)
                return null;
            return xLink.Order1Var.RefGet(context);
        }

        public ordhed_quote GetLinkedQuote(ContextRz context)
        {
            ordlnk xLink = GetLink(context, "", "quote", unique_id, "");
            if (xLink == null)
                return null;
            return (ordhed_quote)xLink.Order1Var.RefGet(context);
        }
        public ArrayList GetLinkedInvoiceCollection(ContextRz x)
        {
            string inn = "";
            foreach (orddet d in DetailsList(x))
            {
                if (!(d is orddet_line))
                    continue;
                if (!Tools.Strings.StrExt(((orddet_line)d).orderid_invoice))
                    continue;
                if (Tools.Strings.StrExt(inn))
                    inn += ",";
                inn += "'" + ((orddet_line)d).orderid_invoice + "'";
            }
            if (!Tools.Strings.StrExt(inn))
                return new ArrayList();
            return x.QtC(MakeOrdhedName(Enums.OrderType.Invoice), "select * from " + MakeOrdhedName(Enums.OrderType.Invoice) + " where unique_id in (" + inn + ")");
        }
        public ArrayList GetLinkedPOCollection(ContextRz x)
        {
            return x.QtC(MakeOrdhedName(Enums.OrderType.Purchase), "select * from " + MakeOrdhedName(Enums.OrderType.Purchase) + " where unique_id in (select orderid1 from ordlnk where orderid2 = '" + unique_id + "' and ordertype1 = 'purchase')");
        }
        public ordhed GetLinkedVendorRMA(ContextRz context)
        {
            ordlnk xLink = null;
            switch (OrderType)
            {
                case Enums.OrderType.RMA:
                    return null;
                default:
                    xLink = GetLink(context, "", "vendrma", unique_id, "");
                    break;
            }
            if (xLink == null)
                return null;

            return xLink.Order1Var.RefGet(context);
        }


        public bool IsReceived(ContextRz context)
        {
            int uf = GetUnFilledCount(context);
            return (uf == 0);
        }
        public int GetUnFilledCount(ContextRz context)
        {
            int i = 0;

            context.TheLeader.Error("reorg");

            //foreach (orddet d in DetailsList(context))
            //{
            //    orddet d = (orddet)k.Value;
            //    if (d.quantityfilled < d.quantityordered)
            //        i++;
            //}
            return i;
        }

        //public void ShowMap()
        //{
        //    ShowMap(new ActArgs());
        //}
        public void ShowMap(ContextRz context)
        {
            if (!context.xUser.CheckPermit(context, Permissions.ThePermits.ViewOrderLinks))
            {
                context.TheLeader.ShowNoRight();
                return;
            }
            context.Logic.OrderLinksShow(context, unique_id);
        }
        public void ShowDeal(ContextNM x)
        {
            //dealheader d = GetDealHeader(x);
            //if (d == null)
            //{
            //    context.TheLeader.Tell(this.ToString() + " doesn't appear to be attached to a deal.");
            //    return;
            //}
            //Rz3App.xMainForm.ShowDeal(d);
        }

        protected string GetWarningPartInfo(ContextRz context, orddet d)
        {
            if (d == null)
                return "";
            part_warning p = (part_warning)context.QtO("part_warning", "select top 1 * from part_warning where part_number = '" + d.prefix + d.basenumberstripped + "'");
            if (p == null)
                return "";
            return p.part_number + " : " + p.notes;
        }

        public bool CompletePurchaseOrder(ContextRz context)
        {
            //foreach (orddet d in DetailsList(context))
            //{
            //    if (Rz3App.xLogic.IsNasco)
            //    {
            //        if (!CheckNascoDetail(context, d))
            //            return false;
            //    }
            //}
            //AddLog(context, "Purchase Order Completed.");
            //if (Rz3App.xLogic.IsNasco)
            //    return SendToApprovalDept(true);
            return true;
        }
        public bool SendPackingSlipComplete(ContextRz context)
        {
            if (!context.TheLeader.AskYesNo("This will complete this packing slip and notify the credit department that the credit card is ready to be charged. Do you want to continue?"))
                return false;
            NewMethod.n_user user = NewMethod.n_user.GetByName(context, "Receptionist");
            usernote n = null;
            company c = null;
            if (user != null)
            {
                n = usernote.New(context);
                n.notetype = "PackingSlipComplete";
                n.the_ordhed_uid = this.unique_id;
                n.for_mc_user_uid = user.unique_id;
                n.createdforname = user.name;
                n.displaydate = DateTime.Now;
                n.subjectstring = this.ToString() + " is ready for a credit check.";
                n.shouldpopup = true;
                n.notetext = this.ToString() + " is ready for a credit check.";
                context.Insert(n);
                n.CreateObjectLink(context, this, this.ToString());
                c = company.GetById(context, this.base_company_uid);
                if (c != null)
                    n.CreateObjectLink(context, c, c.ToString());
            }
            n_team t = n_team.GetByName(context, "Credit Team");
            if (t == null)
                return false;
            ArrayList a = t.GetUserIDs(context);
            foreach (String str in a)
            {
                user = NewMethod.n_user.GetById(context, str);
                if (user != null)
                {
                    n = usernote.New(context);
                    n.notetype = "PackingSlipComplete";
                    n.the_ordhed_uid = this.unique_id;
                    n.for_mc_user_uid = user.unique_id;
                    n.createdforname = user.name;
                    n.displaydate = DateTime.Now;
                    n.subjectstring = this.ToString() + " is ready for the credit card to be processed.";
                    n.shouldpopup = true;
                    n.notetext = this.ToString() + " is ready for the credit card to be processed.";
                    context.Insert(n);
                    n.CreateObjectLink(context, this, this.ToString());
                    c = company.GetById(context, this.base_company_uid);
                    if (c != null)
                        n.CreateObjectLink(context, c, c.ToString());
                }
            }
            packingslip_complete = true;
            context.Update(this);
            return true;
        }
        public bool SendCreditCardCharged(ContextRz context)
        {
            n_team t = n_team.GetByName(context, "Warehouse Team");
            if (t == null)
                return false;
            ArrayList a = t.GetUserIDs(context);
            foreach (String str in a)
            {
                NewMethod.n_user user = NewMethod.n_user.GetById(context, str);
                if (user != null)
                {
                    usernote n = usernote.New(context);
                    n.notetype = "CCCharged";
                    n.the_ordhed_uid = this.unique_id;
                    n.for_mc_user_uid = user.unique_id;
                    n.createdforname = user.name;
                    n.displaydate = DateTime.Now;
                    n.subjectstring = this.ToString() + " has had the credit card processed and is ready to ship.";
                    n.shouldpopup = true;
                    n.notetext = this.ToString() + " has had the credit card processed and is ready to ship.";
                    context.Insert(n);
                    n.CreateObjectLink(context, this, this.ToString());
                    company c = company.GetById(context, this.base_company_uid);
                    if (c != null)
                        n.CreateObjectLink(context, c, c.ToString());
                }
            }
            credit_card_charged = true;
            context.Update(this);
            return true;
        }
        public bool SendToCreditDept(ContextRz context)
        {
            if (!context.TheLeader.AskYesNo("This will complete this sale and notify the credit department that the order is ready for review. Do you want to continue?"))
                return false;
            n_team t = n_team.GetByName(context, "Credit Team");
            if (t == null)
                return false;
            ArrayList a = t.GetUserIDs(context);
            foreach (String str in a)
            {
                NewMethod.n_user user = NewMethod.n_user.GetById(context, str);
                if (user != null)
                {
                    usernote n = usernote.New(context);
                    n.notetype = "CreditCheck";
                    n.the_ordhed_uid = this.unique_id;
                    n.for_mc_user_uid = user.unique_id;
                    n.createdforname = user.name;
                    n.displaydate = DateTime.Now;
                    n.subjectstring = this.ToString() + " is ready for a credit check.";
                    n.shouldpopup = true;
                    n.notetext = this.ToString() + " is ready for a credit check.";
                    context.Insert(n);
                    n.CreateObjectLink(context, this, this.ToString());
                    company c = company.GetById(context, this.base_company_uid);
                    if (c != null)
                        n.CreateObjectLink(context, c, c.ToString());
                }
            }
            onhold = false;
            context.Update(this);
            return true;
        }
        //public bool SendToApprovalDept()
        //{
        //    return SendToApprovalDept(false);
        //}
        //public bool SendToApprovalDept(Boolean bPO)
        //{
        //    if (!context.TheLeader.AskYesNo("This will complete this " + (bPO ? "purchase" : "sale") + " and notify the approval department that the order is ready for review. Do you want to continue?"))
        //        return false;
        //    if (Rz3App.xUser.super_user)
        //    {
        //        onhold = false;
        //        credit_check_approved = true;
        //        ISave();
        //        return true;
        //    }
        //    NewMethod.n_user user = NewMethod.n_user.GetByName(xSys, "Rick Bagnasco");
        //    n_team t = n_team.GetByName(xSys, "ORDER APPROVAL");
        //    if (t == null)
        //        return false;
        //    ArrayList a = t.GetUserIDs();
        //    Boolean bJustRick = false;
        //    if (user != null)
        //        bJustRick = (user.is_away ? false : true);
        //    foreach (String str in a)
        //    {
        //        if (!bJustRick)
        //            user = NewMethod.n_user.GetByID(xSys, str);
        //        if (user != null)
        //        {
        //            usernote n = new usernote(xSys);
        //            n.the_ordhed_uid = this.unique_id;
        //            n.for_mc_user_uid = user.unique_id;
        //            n.createdforname = user.name;
        //            n.displaydate = DateTime.Now;
        //            n.subjectstring = this.ToString() + " is ready for approval.";
        //            n.shouldpopup = true;
        //            n.notetext = this.ToString() + " is ready for approval.";
        //            n.ISave();
        //            n.CreateObjectLink(this, this.ToString());
        //            company c = company.GetByID(xSys, this.base_company_uid);
        //            if (c != null)
        //                n.CreateObjectLink(c, c.ToString());
        //        }
        //        if (bJustRick)
        //            break;
        //    }
        //    onhold = false;
        //    credit_check_approved = false;
        //    ISave();
        //    return true;
        //}

        public bool CompleteServiceOrder(ContextRz x)
        {
            x.Reorg();
            return false;

            /*

            StringBuilder sb = new StringBuilder();
            if (!CheckVerify(sb))
            {
                x.TheLeader.Tell(sb.ToString());
                return false;
            }
            //check to make sure each service line has a description
            String s = "";
            bool b = true;
            foreach (KeyValuePair<String, nObject> k in ServiceDetails)
            {
                orddet d = (orddet)k.Value;
                if (!Tools.Strings.StrExt(d.fullpartnumber))
                {
                    s += "One service line has no service description";
                    b = false;
                }
                if (d.quantityordered == 0)
                {
                    s += d.ToString() + " has no quantity.";
                    b = false;
                }
            }
            foreach (KeyValuePair<String, nObject> k in PartDetails)
            {
                orddet d = (orddet)k.Value;
                partrecord p = d.LinkedPart;
                if (p == null)
                {
                    s += d.ToString() + " is not linked to an inventory line (please remove it and select from inventory).";
                    b = false;
                }
            }
            if (!b)
            {
                context.TheLeader.Tell("At least 1 line on this order doesn't meet the needed requirements; below are the details:\r\n\r\n" + s);
                return false;
            }
            //Change the stock locations
            foreach (KeyValuePair<String, nObject> k in PartDetails)
            {
                orddet d = (orddet)k.Value;
                partrecord p = d.LinkedPart;
                if (p != null)
                {
                    if (Tools.Strings.StrExt(p.location))
                        p.location = "Waiting For Service At " + companyname + " : Service Order " + ordernumber + "  [" + p.location + "]";
                    else
                        p.location = "Waiting For Service At " + companyname + " : Service Order " + ordernumber;
                    p.ISave();
                }
            }
            if (!CheckAllocateStock())
                return false;
            AddLog(x, "Service Order Completed.");
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            //Allocate it
            //AllocateStock();
            ReadyToShip = true;
            onhold = false;
            ISave();
            return true;
             * 
             * */
        }
        public void UnCompleteServiceOrder(ContextRz context)
        {
            ReadyToShip = false;
            onhold = false;
            context.Update(this);
        }
        public bool CheckAllocateStock(ContextRz context)
        {
            context.TheLeader.Error("reorg");
            return false;


            //bool ok = true;
            //StringBuilder sb = new StringBuilder();
            //foreach (KeyValuePair<String, nObject> kvp in PartDetails)
            //{
            //    orddet xDetail = (orddet)kvp.Value;
            //    partrecord xPart = xDetail.LinkedPart;
            //    if (xPart != null)
            //    {
            //        if (xPart.StockType != Rz4.Enums.StockType.Buy)
            //        {
            //            if (xDetail.quantityordered > xPart.quantity)
            //            {
            //                sb.AppendLine(Tools.Number.LongFormat(xDetail.quantityordered) + " is a higher quantity than this inventory line has (" + Tools.Number.LongFormat(xPart.quantity) + ").");
            //                ok = false;
            //            }
            //        }
            //    }
            //}
            //if (!ok)
            //    context.TheLeader.Tell(sb.ToString());
            //return ok;
        }
        public void AllocateStock(ContextRz context)
        {
            context.TheLeader.Error("reorg");

            /*

            foreach (KeyValuePair<String, nObject> kvp in PartDetails)
            {
                orddet xDetail = (orddet)kvp.Value;
                partrecord xPart = xDetail.LinkedPart;
                if (xPart != null)
                {
                    if (xPart.StockType != Rz4.Enums.StockType.Buy)
                    {
                        if (xDetail.quantityordered == xPart.quantity)
                        {
                            partrecord pr = (partrecord)xPart.CloneWithNewID();
                            xPart.SetBuy(unique_id, GetFriendlyName() + " for " + companyname);
                            xPart.ISave();
                            if (Rz3App.xLogic.IsGemTek)
                            {
                                pr.quantity = 0;
                                pr.ISave();
                            }
                            if (Rz3App.xLogic.IsPMT)
                            {
                                pr.StockType = Rz4.Enums.StockType.Archive;
                                pr.TableName = "partrecord_archive";
                                pr.ISave();
                            }
                        }
                        else
                        {
                            partrecord n = xPart.SplitBuy(xDetail.quantityordered, "", unique_id, GetFriendlyName() + " for " + companyname);
                            xDetail.original_stock_id = xPart.unique_id;
                            xDetail.LinkedPart = n;
                            xDetail.ISave();
                            dealdetail.CheckDealLinksStock(x, xDetail, n, null, null);
                        }
                    }
                }
            }
             * 
             * */
        }
        public DateTime EstimateDueDate()
        {
            int days = ordhed.GetDaysAllowed(this.terms);
            if (days > 0)
                return orderdate.Add(TimeSpan.FromDays(days));
            else
                return orderdate;
        }
        public bool HasAtLeastOnePartNumber(ContextRz context)
        {
            foreach (orddet d in DetailsList(context))
            {
                if (Tools.Strings.StrExt(d.fullpartnumber))
                    return true;
            }
            return false;
        }

        public void UnAuthorize()
        {
            is_authorized = false;
            authorized_date = Tools.Dates.GetNullDate();
        }
        public usernote Notify(ContextRz context, String strName, String strText)
        {
            return Notify(context, strName, strText, "");
        }
        public usernote Notify(ContextRz context, String strName, String strText, String strID)
        {
            usernote xNote = usernote.New(context);
            xNote.by_mc_user_uid = context.xUser.unique_id;
            if (Tools.Strings.StrExt(strID))
                xNote.for_mc_user_uid = strID;
            else
                xNote.for_mc_user_uid = NewMethod.n_user.TranslateNameToID(context, strName);
            xNote.notetext = strText;
            xNote.is_pending = false;
            context.Insert(xNote);
            xNote.CreateObjectLink(context, this, companyname);

            xNote.displaydate = DateTime.Now;
            xNote.shouldpopup = true;
            context.Update(xNote);

            return xNote;
        }


        public void DetailInsert(ContextRz context, orddet d)
        {
            //auto
            //d.OrderObjectSet(context, this);

            Details.RefsAdd(context, d);

            context.TheDelta.Update(context, d);
            context.TheDelta.Update(context, this);
        }

        public bool HasLinkedInvoice(ContextRz context)
        {
            ordlnk l = GetLink(context, unique_id, "", "", "invoice");
            return (l != null);
        }

        public virtual bool TransmitPossible(ContextRz context, Enums.TransmitType ttype, List<string> ignoredPropertiesList = null)
        {

            //Checkf or order-level logics that should block printing / emailing
            string noTransmitReason = "";
            if (!CheckTransmitPossibleByOrderType(context, ttype, out noTransmitReason))
            {
                context.Leader.Error(noTransmitReason);
                return false;
            }

            if (!CheckDoNotSell(context))
                return false;
            if (ignoredPropertiesList == null)
                ignoredPropertiesList = new List<string>();

            //IF Disty Sales, no need to check order data
            if (context.xUserRz.Teams.AllByName.ContainsKey("distributor sales"))
                return true;

            if (!CheckOrderData(context, ignoredPropertiesList))
                return false;
            return true;
        }

        private bool CheckTransmitPossibleByOrderType(ContextRz x, TransmitType ttype, out string noTransmitReason)
        {
            noTransmitReason = "";
            switch (this.OrderType)
            {
                case OrderType.Quote:
                    {
                        if (!CheckTransmitPossibleQuote(x))
                        {
                            noTransmitReason = "Cannot Quote Customers when Vendor is Source TBD.";
                            return false;
                        }
                        break;
                    }

            }

            return true;
        }

        private bool CheckTransmitPossibleQuote(ContextRz x)
        {
            bool ret = true;
            ordhed_quote o = (ordhed_quote)this;
            if (o == null)
                return false;
            if (!x.Leader.ConfirmCustomerTermsConditions(x, o.CompanyVar.RefGet(x)))
            {                
                x.Leader.Error("Please resolve any company restrictions before proceeding.");
                return false;
            }
            


            //Check for SourceTBD Vendors
            List<orddet_quote> quoteLinesList = o.DetailsListQuote(x);
            //Formal Quote lines should not allowed to be sent with Source TBD
            foreach (orddet_quote q in quoteLinesList)
            {
                if (q.vendorname == "Source TBD")
                    ret = false;
            }

            return ret;

        }





        public bool CheckCreditCard(ContextRz context)
        {
            if (nTools.IsTermsCreditCard(terms))
            {
                return context.TheLeader.AskYesNo("This appears to be a credit card order.  Have you confirmed that the card has been accepted for the full amount?");
            }
            else
            {
                if (nTools.IsTermsCOD(terms))
                    return context.TheLeader.AskYesNo("This appears to be a COD order.  Have you confirmed that full payment has been received?");
            }
            return true;
        }

        //private bool HasBeenCompletelyPicked()
        //{
        //    contextRz.TheLeader.Error("reorg");
        //    return false;


        //    //bool picked = true;
        //    //GatherDetails();
        //    //foreach (orddet d in DetailsList(context))
        //    //{
        //    //    if (!(kvp.Value is orddet))
        //    //        continue;
        //    //    orddet d = (orddet)kvp.Value;
        //    //    if (d == null)
        //    //        continue;
        //    //    if (!d.isselected)
        //    //        continue;
        //    //    if (d.quantityordered == d.quantityfilled)
        //    //        continue;
        //    //    picked = false;
        //    //    break;
        //    //}
        //    //return picked;
        //}
        public bool IsEitherKindOfRMA()
        {
            if (OrderType == Enums.OrderType.RMA)
                return true;
            if (OrderType == Enums.OrderType.VendRMA)
                return true;
            return false;
        }

        public ordhed MakeLinkedVendorRMA(ContextRz context, System.Windows.Forms.IWin32Window owner)
        {
            ordhed xInvoice = GetLinkedInvoice(context);
            if (xInvoice == null)
            {
                context.TheLeader.Tell("The invoice for RMA '" + ordernumber + "' could not be found.  Please create the Vendor RMA portion of this process manually, by opening the correct purchase order and clicking 'Vend RMA'.");
                return null;
            }
            ordhed xSales = xInvoice.GetLinkedSalesOrder(context);
            if (xSales == null)
            {
                context.TheLeader.Tell("The sales order for invoice '" + xInvoice.ordernumber + "' could not be found.  Please create the Vendor RMA portion of this process manually, by opening the correct purchase order and clicking 'Vend RMA'.");
                return null;
            }
            ArrayList colPurchases = context.QtC(ordhed.MakeOrdhedName(Enums.OrderType.Purchase), xSales.GetLinkedPOSQL());
            if (colPurchases.Count == 0)
            {
                context.TheLeader.Tell("No purchase orders could be found for the sales order '" + xSales.ordernumber + "'.  Please create the Vendor RMA portion of this process manually, by opening the correct purchase order and clicking 'Vend RMA'.");
                return null;
            }
            ordhed xPurchase;
            if (colPurchases.Count > 1)
            {
                xPurchase = (ordhed)context.TheLeaderRz.ChooseObjectFromCollection(context, colPurchases);
                if (xPurchase == null)
                {
                    context.TheLeader.Tell("No purchase orders could be found for the sales order '" + xSales.ordernumber + "'.  Please create the Vendor RMA portion of this process manually, by opening the correct purchase order and clicking 'Vend RMA'.");
                    return null;
                }
            }
            else
                xPurchase = (ordhed)colPurchases[0];
            List<orddet_line> l = new List<orddet_line>();
            foreach (orddet d in DetailsList(context))
            {
                if (!Tools.Strings.StrCmp(d.status, "canceled") && !d.isvoid)
                    l.Add((orddet_line)d);
            }
            ordhed_vendrma xVRMA = context.TheSysRz.TheLineLogic.VendRMA(context, l);
            //ordhed xVRMA = xPurchase.GetNewOrder(context, Enums.OrderType.VendRMA);
            if (xVRMA == null)
                return null;
            xVRMA.rma_data = rma_data;
            if (Tools.Strings.StrExt(xVRMA.unique_id))
                xVRMA.Update(context);
            else
                xVRMA.Insert(context);
            context.TheSysRz.TheOrderLogic.Link2Orders(context, this, xVRMA);
            return xVRMA;
        }

        public void SendThankYouEmail(ContextRz context)
        {
            emailtemplate xTemplate = emailtemplate.GetByName(context, "Notify_Customer_Sales");
            if (xTemplate == null)
            {
                context.TheLeader.Tell("Before this feature can be used, an email template named 'Notify_Customer_Sales' must be created.");
                return;
            }
            xTemplate.SendOrderEmail(context, this);
        }


        public virtual bool CheckForServiceOrders(ContextRz context)
        {
            //MessageBox.Show("reorg");

            ArrayList a = GetLinkedServiceOrders(context);
            if (a.Count > 0)
            {
                if (!context.TheLeader.AskYesNo("This order has " + Tools.Strings.PluralizePhrase("linked service order", a.Count) + ".  Do you want to continue invoicing?"))
                    return false;
            }
            //else
            //{
            //    a = Rz3App.xSys.QtC("orddet_service", "select * from orddet_service inner join ordhed_service hed on hed.unique_id = orddet_service.base_ordhed_uid where quantityfilled = 0 and isnull(hed.isclosed, 0) = 0 and isnull(hed.isvoid, 0) = 0 and fullpartnumber in ( select fullpartnumber from orddet_sales where base_ordhed_uid = '" + this.unique_id + "')");
            //    if (a.Count > 0)
            //    {
            //        if (!context.TheLeader.AskYesNo(Tools.Strings.PluralizePhrase("open service order", a.Count) + " has part numbers matching this order.  Do you want to continue invoicing?"))
            //            return false;
            //    }
            //}

            return true;
        }

        public void NotifyPickTicket(ContextRz context, ordhed inv)
        {
            if (inv == null)
                return;
            n_team t = n_team.GetByName(context, "Warehouse Team");
            if (t == null)
                return;
            ArrayList a = t.GetUserIDs(context);
            foreach (String str in a)
            {
                NewMethod.n_user user = NewMethod.n_user.GetById(context, str);
                if (user != null)
                {
                    usernote n = usernote.New(context);
                    n.notetype = "PickTicketCreate";
                    n.the_ordhed_uid = inv.unique_id;
                    n.for_mc_user_uid = user.unique_id;
                    n.createdforname = user.name;
                    n.displaydate = DateTime.Now;
                    n.subjectstring = inv.ToString() + " has been created and is ready to be picked.";
                    n.shouldpopup = true;
                    n.notetext = inv.ToString() + " has been created and is ready to be picked";
                    context.Insert(n);
                    n.CreateObjectLink(context, inv, inv.ToString());
                    company c = company.GetById(context, inv.base_company_uid);
                    if (c != null)
                        n.CreateObjectLink(context, c, c.ToString());
                }
            }
        }

        public virtual bool CanAssignCompany(ContextRz context, company c)
        {
            if (c.is_locked)
            {
                context.Leader.Tell(c.ToString() + " is marked as 'Locked'");
                if (!context.xUser.SuperUser)
                    return false;
            }

            if (c.HasAnyProblems)
            {
                //context.TheLeader.Error("Please note that '" + c.companyname + "' has been " + c.ProblemDescription + ".");
                //if (OrderDirection == Rz5.Enums.OrderDirection.Outgoing)
                //    context.Logic.NotifyAccounting(context, this, "Problem Customer Order", "This order was created for a problem customer.");
            }
            //moved to phoenix's ordhed_purchase CanAssignCompany override
            //if (Rz3App.xLogic.IsPhoenix && !Rz3App.xLogic.IsPhoenixWarehouse)
            //{
            //    if (!context.xUser.IsDeveloper() && OrderType == Rz4.Enums.OrderType.Purchase && !c.needs_contact)  //needs contact is the flag for verified vendor
            //    {
            //        context.TheLeader.Error("Please be aware that " + c.ToString() + " has not been marked as a verified vendor.");
            //        return false;
            //    }
            //    if (OrderType == Rz4.Enums.OrderType.Purchase && c.divisionof.Contains(",DA,"))
            //    {
            //        switch (Rz3App.xUser.Name)
            //        {
            //            case "Ed Garfio":
            //            case "Craig Brechner":
            //                context.TheLeader.Tell("Warning: this vendor has been marked as a dis-approved vendor.");
            //                break;
            //            default:
            //                context.TheLeader.Error("This vendor has been marked as a dis-approved vendor.  Please correct this before continuing.");
            //                return false;
            //        }
            //    }
            //}
            return true;
        }
        public bool CanAssignContact(ContextRz context, companycontact c)
        {
            if (context.xUser.SuperUser)
                return true;
            if (c.bad_data)
            {
                context.TheLeader.Error(c.ToString() + " is marked as having bad contact data, and cannot be assigned to an order.");
                return false;
            }
            if (Tools.Strings.StrCmp(c.agentname, "bad record"))
            {
                context.TheLeader.Error(c.ToString() + " is marked as 'BAD RECORD', and cannot be assigned to an order.");
                return false;
            }
            if (OrderDirection == Enums.OrderDirection.Incoming)
                return true;
            if (OrderType == Rz5.Enums.OrderType.Service)
                return true;
            if (!Tools.Strings.StrExt(c.base_mc_user_uid))
                return true;
            if (Tools.Strings.StrCmp(c.base_mc_user_uid, context.xUser.unique_id))
                return true;
            return context.TheSysRz.TheOrderLogic.CanAssignContactExtra(context, c, this);
        }
        public bool CanHaveTransactions()
        {
            if (OrderType == Enums.OrderType.Purchase)
                return true;
            if (OrderType == Enums.OrderType.Invoice)
                return true;
            if (OrderType == Enums.OrderType.RMA)
                return true;
            if (OrderType == Enums.OrderType.VendRMA)
                return true;
            return false;
        }
        //public ArrayList GetDetailArray()
        //{
        //    ArrayList a = new ArrayList();
        //    Dictionary<String, nObject> ds;
        //    if (OrderType == Rz4.Enums.OrderType.Service)
        //        ds = ServiceDetails;
        //    else
        //        ds = AllDetails;
        //    foreach (KeyValuePair<String, nObject> k in ds)
        //    {
        //        orddet d = (orddet)k.Value;
        //        a.Add(d);
        //    }
        //    return a;
        //}

        public virtual List<orddet> DetailsListSummed(ContextRz context)
        {
            throw new NotImplementedException();
        }
        public void DoAction_ScanViewDocuments(ContextRz context)
        {
            MessageBox.Show("reorg");
            //DocumentScanner s = new DocumentScanner();
            //Rz3App.xMainForm.TabShow(s, "Documents On " + GetFriendlyName());
            //s.CompleteLoad(this);
        }

        //removed this since it doesn't do anything but call SendToQB
        //public virtual void SendToQuickbooks(ContextRz context)
        //{
        //    //StringBuilder sb = new StringBuilder();
        //    //if (!CheckVerify(sb))
        //    //{
        //    //    context.TheLeader.Tell(sb.ToString());
        //    //    return;
        //    //}
        //    SendToQB(context);
        //}
        public void AddItem(ContextRz context)
        {
            AddLineItem(context, "", 0, 0);
        }

        public virtual bool VoidPossible(ContextRz context, StringBuilder sb)
        {
            if (!context.xUser.CheckPermit(context, "Order:Edit:Can Void " + nTools.NiceFormat(ordertype)))
            {
                context.TheLeader.ShowNoRight();
                return false;
            }
            if (senttoqb && !context.xUser.SuperUser)
            {
                context.TheLeader.Tell("This order has been sent to QuickBooks already, please contact your accounting department if this order needs to be voided.");
                return false;
            }

            return true;
        }

        public virtual void VoidUn(ContextRz context)
        {
            isvoid = false;
            context.TheSysRz.TheOrderLogic.SetOpportunityOpen(context, this);
            context.TheDelta.Update(context, this);
        }

        public virtual bool Void(ContextRz context)
        {
            //string voidReason = context.Leader.AskForString("Please indicate the reason for voiding this order.");
            //if (string.IsNullOrEmpty(voidReason))
            //{
            //    context.Leader.Error("You must enter a reason for voiding this order.  Void canceled.");
            //    return false;
            //}

            //internalcomment += Environment.NewLine + "Void Reason: " + voidReason;




            StringBuilder sb = new StringBuilder();
            if (!VoidPossible(context, sb))
            {
                context.TheLeader.Error(ToString() + " cannot be voided:\r\n\r\n" + sb.ToString());
                return false;
            }




            if (senttoqb)
            {
                if (!context.TheLeader.AreYouSure("void " + ToString() + " even though it has already been flagged as sent to QuickBooks"))
                    return false;
            }

            //switch (OrderType)
            //{
            //    case Enums.OrderType.Quote:
            //        {
            //            //string reason = context.Leader.AskForString("Please provide a reason for closing this order: ");
            //            //if (string.IsNullOrEmpty(reason))
            //            //    throw new Exception("Please provide a reason for voiding this quote.");
            //            //voidReason = "Formal Quote Voided From Rz";
            //            ordhed_quote q = (ordhed_quote)this;
            //            if (q == null)
            //                throw new Exception("Cannot void quote. Reason:  invalid cast (ordhed_quote)");
            //            voidReason = q.opportunity_lost_reason;
            //            //q.opportunity_lost_reason = voidReason;
            //            q.opportunity_stage = SM_Enums.OpportunityStage.sale_lost.ToString();
            //            q.isclosed = true;


            //            //Close the Hubspot Deal:
            //            //SensibleDAL.SalesLogic.CloseHubspotDealRz(this.unique_id, reason);
            //            //SensibleDAL.SalesLogic.SetRzFormalQuoteLost(this.unique_id, reason);   


            //            break;
            //        }
            //    case OrderType.Sales:             
            //        {
            //            opportunity_stage = SM_Enums.OpportunityStage.sale_lost.ToString();
            //            break;
            //        }
            //}
            //Handle Rz Opportunity   
            //string voidReason = context.Leader.ChooseOneChoice(context, "opportunity_lost_reason", "Please choose a reason for voiding this order.");
            //if (String.IsNullOrEmpty(voidReason))
            //{
            //    context.Leader.Error("You must choose a reason. ");
            //    return false;
            //}
            string selectedReason = "";
            if (!context.TheSysRz.TheOrderLogic.SetOpportunityLost(context, this, selectedReason, out selectedReason))
                return false;

            //Handle Hubspot
            long hubspotDealID = GetHubspotDealIDFromOrdhed(context, this);
            if (hubspotDealID > 0)
                HubspotApi.Deals.SetDealLost(hubspotDealID, selectedReason);


            return ((SysRz5)context.xSys).TheOrderLogic.DoVoidNotify(context, this);
        }



        private long GetHubspotDealIDFromOrdhed(ContextRz context, ordhed ordhed)
        {
            long ret = 0;
            switch (OrderType)
            {
                case Enums.OrderType.Quote:
                    {
                        ordhed_quote q = (ordhed_quote)this;
                        ret = q.hubspot_deal_id;
                        break;
                    }
                case Enums.OrderType.Sales:
                    {
                        ordhed_sales s = (ordhed_sales)this;
                        ret = s.hubspot_deal_id;
                        break;
                    }
            }

            return ret;
        }

        public void UnClose(ContextRz context)
        {
            if (!context.xUser.CheckPermit(context, "Order:Edit:Close Orders"))
            {
                context.TheLeader.ShowNoRight();
                return;
            }
            isclosed = false;
            context.Update(this);
        }

        public void DirectEmailPO(ContextRz context)
        {
            if ((!context.xUser.CheckPermit(context, "Order:Transmit:Can Transmit " + nTools.NiceFormat(ordertype))) && (!context.xUser.CheckPermit(context, "Order:Transmit:Can Email " + nTools.NiceFormat(ordertype))))
            {
                context.TheLeader.ShowNoRight();
                return;
            }

            //if( !CheckTransmit() )
            //    return;

            //needs the web conversion
            if (!TransmitPossible(context, Enums.TransmitType.Email))
                return;

            TransmitParameters tp = new TransmitParameters(Rz5.Enums.TransmitType.Email);
            tp.EmailTemplate = emailtemplate.GetByName(context, "E-mail Purchase Order");
            if (tp.EmailTemplate != null)
            {
                try
                {
                    this.Transmit(context, tp);
                }
                catch
                {
                }
            }
        }
        public void DirectEmailQuote(ContextRz context)
        {
            context.TheLeader.Error("reorg");

            //if ((!Rz3App.xUser.CheckPermit(context, "Order:Transmit:Can Transmit " + nTools.NiceFormat(ordertype))) && (!Rz3App.xUser.CheckPermit(context, "Order:Transmit:Can Email " + nTools.NiceFormat(ordertype))))
            //{
            //    args.TheContext.TheLeader.ShowNoRight();
            //    return;
            //}

            ////this needs to be converted to support the web
            //if (!TransmitPossible(args.TheContext, Enums.TransmitType.Email))
            //    return;

            //TransmitParameters tp = new TransmitParameters(Rz4.Enums.TransmitType.Email);
            //tp.EmailTemplate = emailtemplate.GetByName(xSys, "*E-mail Formal Quote");
            //if (tp.EmailTemplate != null)
            //{
            //    try
            //    {
            //        this.Transmit(args.TheContext, tp);
            //    }
            //    catch
            //    {
            //    }
            //}

            //if (Rz3App.xLogic.IsAAT)
            //    Rz3App.xLogic.LogOrderActivity(this, "Direct Email Quote");
        }
        public orddet AddLineItem(ContextRz context, String strPartNumber, long lngQuantity, Double dblPrice)
        {
            orddet xDetail = GetNewDetail(context);
            xDetail.fullpartnumber = strPartNumber;
            if (xDetail is orddet_old)
            {
                orddet_old old = (orddet_old)xDetail;
                old.quantityordered = Convert.ToInt32(lngQuantity);
                old.unitprice = dblPrice;
            }
            else if (xDetail is orddet_line)
            {
                orddet_line l = (orddet_line)xDetail;
                l.quantity = Convert.ToInt32(lngQuantity);
                l.unit_price = dblPrice;
            }
            if (Tools.Strings.StrExt(xDetail.unique_id))
                context.Update(xDetail);
            else
                context.Insert(xDetail);
            return xDetail;
        }
        public void CompanyView(ContextRz context)
        {
            context.Show(CompanyVar.RefGet(context));
        }

        //public virtual void DoAction_Print(ContextRz context)
        //{
        //    if ((!context.xUser.CheckPermit(context, "Order:Transmit:Can Transmit " + nTools.NiceFormat(ordertype))) && (!context.xUser.CheckPermit(context, "Order:Transmit:Can Print " + nTools.NiceFormat(ordertype))))
        //    {
        //        context.TheLeader.ShowNoRight();
        //        return;
        //    }
        //    TransmitBegin(context, Enums.TransmitType.Print);
        //}       
        //public void DoAction_PrintPDF(ContextRz context)
        //{
        //    if ((!context.xUser.CheckPermit(context, "Order:Transmit:Can Transmit " + nTools.NiceFormat(ordertype))) && (!context.xUser.CheckPermit(context, "Order:Transmit:Can Print " + nTools.NiceFormat(ordertype))))
        //    {
        //        context.TheLeader.ShowNoRight();
        //        return;
        //    }
        //    TransmitBegin(context, Enums.TransmitType.PDF);
        //}
        //public void DoAction_Fax(ContextRz context)
        //{
        //    if ((!context.xUser.CheckPermit(context, "Order:Transmit:Can Transmit " + nTools.NiceFormat(ordertype))) && (!context.xUser.CheckPermit(context, "Order:Transmit:Can Fax " + nTools.NiceFormat(ordertype))))
        //    {
        //        context.TheLeader.ShowNoRight();
        //        return;
        //    }
        //    TransmitBegin(context, Enums.TransmitType.Fax);
        //}

        //this shouldn't be used anymore, right?  the order is the place for void orders, not the links
        //public void UpdateLinksVoid(bool v)
        //{
        //    foreach (ordlnk l in AllLinks)
        //    {
        //        l.isvoid = v;
        //    }
        //}

        public ordrma CreateLinkedRMASummary(ContextRz context)
        {
            ordrma linkedRma = ordrma.New(context);
            LinkedRMASet(linkedRma);
            switch (OrderType)
            {
                case Enums.OrderType.RMA:
                    linkedRma.rma_ordhed_uid = unique_id;
                    break;
                case Enums.OrderType.VendRMA:
                    linkedRma.vendrma_ordhed_uid = unique_id;
                    break;
            }
            context.Insert(linkedRma);
            return linkedRma;
        }
        public void UpdateLegacyRMA(ContextRz context)
        {
            ordrma linkedRma = LinkedRMAGet(context);
            GetLinkedRMASummary(context);
            if (linkedRma != null)
                return;
            CreateLinkedRMASummary(context);
            String[] ary = Tools.Strings.Split(rma_data, "\r\n");
            linkedRma.return_reason = ary[0];
            linkedRma.customer_reimbursed = ary[1];
            switch (ary[2].ToLower().Replace(" ", "").Trim())
            {
                case "ship":
                    linkedRma.current_status = "The parts will be shipped back to us";
                    break;
                case "warehouse":
                    linkedRma.current_status = "The parts are in our warehouse";
                    break;
                case "noreturn":
                    linkedRma.current_status = "The parts will not be returned";
                    break;
            }
            switch (ary[3].Replace(" ", "").Trim().ToLower())
            {
                case "return":
                    linkedRma.planned_status = "The parts will be returned to the vendor";
                    break;
                case "keep":
                    linkedRma.planned_status = "The parts will be kept in our stock";
                    break;
                case "discard":
                    linkedRma.planned_status = "The parts will be discarded";
                    break;
                case "noreturn":
                    linkedRma.planned_status = "The parts will be discarded";
                    break;
            }
            ordhed xVendRMA = GetLinkedVendorRMA(context);
            if (xVendRMA != null)
                linkedRma.vendrma_ordhed_uid = xVendRMA.unique_id;
            context.Update(linkedRma);
        }
        public String GetPlannedStatus(ContextRz context)
        {
            GetLinkedRMASummary(context);
            if (LinkedRMAGet(context) == null)
                return "";
            return LinkedRMAGet(context).planned_status;
        }
        public void UpdateUnlinkedVendorRMA(ContextRz context)
        {
            GetLinkedRMASummary(context);
            if (LinkedRMAGet(context) != null)
                return;
            CreateLinkedRMASummary(context);
            String[] ary = Tools.Strings.Split(rma_data, "\r\n");
            LinkedRMAGet(context).return_reason = ary[0];
            LinkedRMAGet(context).vendor_reimbursed = ary[1];
            switch (ary[2].Replace(" ", "").Trim().ToLower())
            {
                case "ship":
                    LinkedRMAGet(context).current_status = "The parts will be shipped back to us";
                    break;
                case "warehouse":
                    LinkedRMAGet(context).current_status = "The parts are in our warehouse";
                    break;
                case "noreturn":
                    LinkedRMAGet(context).current_status = "The parts will not be returned";
                    break;
            }
            switch (ary[3].Replace(" ", "").Trim().ToLower())
            {
                case "return":
                    LinkedRMAGet(context).planned_status = "The parts will be returned to the vendor";
                    break;
                case "keep":
                    LinkedRMAGet(context).planned_status = "The parts will be kept in our stock";
                    break;
                case "discard":
                    LinkedRMAGet(context).planned_status = "The parts will be discarded";
                    break;
                case "noreturn":
                    LinkedRMAGet(context).planned_status = "The parts will be discarded";
                    break;
            }
            context.Update(LinkedRMAGet(context));
        }

        public void DoAction_SendWillQuoteEmail(ContextRz context)
        {
            try
            {
                String address = primaryemailaddress;
                emailtemplate e = (emailtemplate)context.QtO("emailtemplate", "select * from emailtemplate where templatename = 'Will Quote Email' and class_name like 'ordhed%' and ordertype = 'Quote'");
                if (e == null)
                    return;
                //String email = GetWillQuoteEmail(ref address);
                companycontact cc = this.ContactVar.RefGet(context);
                if (cc != null)
                {
                    if (nTools.IsEmailAddress(cc.primaryemailaddress))
                        address = cc.primaryemailaddress;
                }
                if (!Tools.Strings.StrExt(address))
                {
                    company c = this.CompanyVar.RefGet(context);
                    if (c != null)
                    {
                        if (nTools.IsEmailAddress(cc.primaryemailaddress))
                            address = c.primaryemailaddress;
                    }
                }
                if (Tools.Strings.StrExt(address))
                    e.SendOrderEmail(context, this, address);
                //args.ShouldClose = true;
            }
            catch
            {
            }
        }
        public void TrackOrderGoogle(ContextRz context)
        {
            context.TheLeader.Error("reorg");

            //TrackOrder track = new TrackOrder();
            //track.CompleteLoad(xSys, this, Rz4.Enums.OrderTrackingSite.Google);
            //Rz3App.xMainForm.TabShow(track, "Order Tracking - " + GetFriendlyName());
        }



        public void DoAction_Transactions(ContextRz context)
        {
            context.TheLeader.Error("reorg");
            //context.xSys.ThrowObjectList("checkpayment", "checkpayment.base_ordhed_uid = '" + unique_id + "'", "transdate", "check-payment", 100, "Transactions");
        }
        public void DoAction_NewTransaction(ContextRz context)
        {
            if (!context.xUser.CheckPermit(context, "Transactions:Create:Apply Transactions"))
            {
                context.TheLeader.ShowNoRight();
                return;
            }
            checkpayment xTransaction = AddTransaction(context);
            context.Show(xTransaction);
            context.Update(this);
        }
        public void ShowNewPayment(ContextRz x)
        {
            checkpayment p = AddTransaction(x);

            x.Show(p);
        }
        public void ShowPayments(ContextRz context)
        {
            context.TheLogicRz.PaymentsShow(context, unique_id);
        }

        public void CreateVendorRFQs(ContextRz context)
        {
            context.TheLeader.Error("reorg");

            //try
            //{
            //    if ((!context.xUser.CheckPermit(context, "Order:Transmit:Can Transmit " + nTools.NiceFormat(ordertype))) && (!context.xUser.CheckPermit(context, "Order:Transmit:Can Fax " + nTools.NiceFormat(ordertype))))
            //    {
            //        context.TheLeader.ShowNoRight();
            //        return;
            //    }
            //    Dictionary<String, ArrayList> vendors = new Dictionary<String, ArrayList>();
            //    ArrayList a;
            //    ArrayList rfqs = new ArrayList();
            //    foreach (orddet d in DetailsList(context))
            //    {
            //        orddet d = (orddet)kvp.Value;
            //        company vendor = company.GetByID(xSys, d.vendor_company_uid);
            //        if (vendor == null)
            //            continue;
            //        a = null;
            //        vendors.TryGetValue(d.vendor_company_uid, out a);
            //        if (a == null)
            //        {
            //            a = new ArrayList();
            //            a.Add(d);
            //            vendors.Add(d.vendor_company_uid, a);
            //            continue;
            //        }
            //        a.Add(d);
            //        vendors.Remove(d.vendor_company_uid);
            //        vendors.Add(d.vendor_company_uid, a);
            //    }
            //    foreach (KeyValuePair<String, ArrayList> kvp in vendors)
            //    {
            //        ArrayList det = (ArrayList)kvp.Value;
            //        if (det.Count <= 0)
            //            continue;
            //        company vendor = company.GetByID(xSys, kvp.Key);
            //        if (vendor == null)
            //            continue;
            //        ordhed rfq = new ordhed(xSys);
            //        rfq.ordernumber = ordhed.GetNextNumber(xSys, Rz4.Enums.OrderType.RFQ);
            //        rfq.orderreference = ordernumber;
            //        rfq.OrderType = Rz4.Enums.OrderType.RFQ;
            //        rfq.base_mc_user_uid = Rz3App.xUser.unique_id;
            //        rfq.agentname = Rz3App.xUser.name;
            //        rfq.base_company_uid = vendor.unique_id;
            //        rfq.companyname = vendor.companyname;
            //        rfq.primaryphone = vendor.primaryphone;
            //        rfq.primaryfax = vendor.primaryfax;
            //        rfq.primaryemailaddress = vendor.primaryemailaddress;
            //        rfq.ISave();
            //        foreach (orddet dd in det)
            //        {
            //            orddet d = rfq.GetNewDetail();
            //            d.fullpartnumber = dd.fullpartnumber;
            //            d.quantityordered = dd.quantityordered;
            //            d.datecode = dd.datecode;
            //            d.manufacturer = dd.manufacturer;
            //            d.condition = dd.condition;
            //            d.ISave();
            //        }
            //        rfqs.Add(rfq);
            //    }
            //    foreach (ordhed o in rfqs)
            //    {
            //        Rz3App.xLogic.ShowTransmitOrder(context, o, Enums.TransmitType.Fax);
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }
        public void DoAction_EmailFollowUpQuote(ContextRz context)
        {
            try
            {
                String address = "";
                emailtemplate e = (emailtemplate)context.QtO("emailtemplate", "select * from emailtemplate where templatename = 'Quote Follow Up' and class_name = 'ordhed' and ordertype = 'Quote'");
                if (e == null)
                    return;
                //String email = GetFollowUpQuote(ref address);
                companycontact cc = this.ContactVar.RefGet(context);
                if (cc != null)
                    address = cc.primaryemailaddress;
                if (!Tools.Strings.StrExt(address))
                {
                    company c = this.CompanyVar.RefGet(context);
                    if (c != null)
                        address = c.primaryemailaddress;
                }
                if (Tools.Strings.StrExt(address))
                {
                    e.SendOrderEmail(context, this, address);
                    this.followup_date = DateTime.Now;
                    context.Update(this);
                }
                //args.ShouldClose = true;
            }
            catch
            {
            }

            //if (Rz3App.xLogic.IsAAT)
            //    Rz3App.xLogic.LogOrderActivity(this, "Email Follow Up");
        }
        public void EmailFollowUpPO(ContextRz context)
        {
            context.TheLeader.Error("reorg");

            //String address = "";
            //String email = GetFollowUpPO(ref address);
            //if (Tools.Strings.StrExt(address))
            //{
            //    String err = "";
            //    ToolsOffice.OutlookOffice.SendOutlookMessage(address, email, "Purchase Order Follow Up - " + this.ordernumber, false, true, "", "", false, null, "", "", "", "", ref err);
            //}
            //args.ShouldClose = true;
        }
        public void ApplyCreditCardFee(ContextRz context)
        {
            try
            {
                Double d = GetOrderLineTotal(context);
                String per = "";
                //if (!Rz3App.xLogic.IsAAT)
                //{
                //    frmChooseCreditCharge xForm = new frmChooseCreditCharge();
                //    xForm.ShowDialog();
                //    per = xForm.SelectedChoice;
                //}
                //else
                per = "3";
                if (!Tools.Strings.StrExt(per))
                    return;
                nDouble p = per;
                Double pp = p;
                Double charge = Math.Round(d * (pp / Convert.ToDouble(100)), 2);
                handlingamount = charge;
                context.Update(this);
            }
            catch
            {
            }
        }
        public Double GetOrderLineTotal(ContextRz context)
        {
            try
            {
                Double d = 0;

                context.TheLeader.Error("reorg");

                //ArrayList a = GetDetailCollection();
                //foreach (orddet od in a)
                //{
                //    d += od.quantityordered * od.unitprice;
                //}
                return d;
            }
            catch
            {
                return 0;
            }
        }
        public void AskRestockingFee(ContextRz context)
        {
            bool b = context.TheLeader.AskYesNo("Does this RMA require a restocking fee?");
            if (!b)
                return;
            Double add = this.SubTotal(context) * 0.1;
            this.handlingamount = (-1) * add;
            context.Update(this);
        }
        //Private Static Functions
        private static void CheckImportAgentLink(nDataTable d)
        {
            d.AddField("base_mc_user_uid");
            d.AddField("agentname");
            if (d.FieldExists("user_code"))
            {
                d.LinkInInfo("base_mc_user_uid", "user_code", "n_user", "user_code", "unique_id");
                d.LinkInInfo("agentname", "base_mc_user_uid", "n_user", "unique_id", "name");
            }
        }
        private static void CalcImportDetailTotals(nDataTable dtDetail, Enums.OrderType ot)
        {
            //totals
            dtDetail.AddField("quantityordered", "int", "0");
            dtDetail.AddField("quantityfilled", "int", "0");
            dtDetail.AddField("unitprice", "float", "0");
            dtDetail.AddField("unitcost", "float", "0");
            dtDetail.AddField("extendedorder", "float", "0");
            dtDetail.AddField("extendedfilled", "float", "0");
            dtDetail.AddField("stockvalue", "float", "0");
            dtDetail.AddField("lineprofit", "float", "0");
            dtDetail.AddField("totalvalue", "float", "0");
            dtDetail.AddField("totalprice", "float", "0");
            //fill in quantities
            dtDetail.xData.Execute("update " + dtDetail.TableName + " set quantityordered = quantityfilled where isnull(quantityfilled, 0) > 0 and isnull(quantityordered, 0) = 0");

            String strQuantity = "quantityfilled";
            switch (ot)
            {
                case Rz5.Enums.OrderType.RFQ:
                case Rz5.Enums.OrderType.Quote:
                case Rz5.Enums.OrderType.Sales:
                case Rz5.Enums.OrderType.Purchase:
                    strQuantity = "quantityordered";
                    break;
            }

            dtDetail.xData.Execute("update " + dtDetail.TableName + " set extendedorder = (isnull(quantityordered, 0) * isnull(unitprice, 0)), extendedfilled = (isnull(quantityfilled, 0) * isnull(unitprice, 0)), stockvalue = (isnull(quantityordered, 0) * isnull(unitcost, 0)), lineprofit = ((isnull(" + strQuantity + ", 0) * isnull(unitprice, 0)) - (isnull(" + strQuantity + ", 0) * isnull(unitcost, 0))), totalvalue = (isnull(" + strQuantity + ", 0) * isnull(unitprice, 0)),  totalprice = (isnull(" + strQuantity + ", 0) * isnull(unitprice, 0))");
        }
        private static bool ImportOrderList(ContextRz context, nDataTable dtOrders, Enums.OrderType ot)
        {
            return ImportOrderList(context, dtOrders, ot);
        }
        private static bool ImportOrderList(ContextRz context, nDataTable dtOrders, Enums.OrderType ot, ContextNM x)
        {
            context.Reorg();
            return false;

            //dtOrders.AddField("alternatetracking");  //for legacy imports
            //dtOrders.AddField("terms");
            //dtOrders.AddField("shipvia");
            //dtOrders.AddField("orderfob");
            //dtOrders.AddField("printcomment");
            //dtOrders.AddField("internalcomment");
            //dtOrders.AddField("dockdate", "datetime", "orderdate");
            //dtOrders.AddField("requireddate", "datetime", "orderdate");
            //dtOrders.AddField("orderreference");
            //dtOrders.AddField("companycode");
            //dtOrders.AddField("shippingname");
            //dtOrders.AddField("billingname");
            //dtOrders.AddField("shippingaddress");
            //dtOrders.AddField("billingaddress");
            //dtOrders.AddField("contactname");
            //dtOrders.AddField("base_companycontact_uid");
            //dtOrders.AddField("primaryphone");
            //dtOrders.AddField("primaryfax");
            //dtOrders.AddField("primaryemailaddress");

            //ArrayList a = new ArrayList();
            //a.Add("companyname");
            //a.Add("base_company_uid");
            //a.Add("contactname");
            //a.Add("base_companycontact_uid");
            //a.Add("primaryphone");
            //a.Add("primaryfax");
            //a.Add("primaryemailaddress");
            //a.Add("ordertype");
            //a.Add("orderdate");
            //a.Add("ordernumber");
            //a.Add("firstpartnumber");
            //a.Add("ordertotal");
            //a.Add("grossamount");
            //a.Add("costamount");
            //a.Add("totalvalue");
            //a.Add("profitamount");
            //a.Add("base_mc_user_uid");
            //a.Add("agentname");
            //a.Add("alternatetracking");
            //a.Add("terms");
            //a.Add("shipvia");
            //a.Add("orderfob");
            //a.Add("printcomment");
            //a.Add("internalcomment");
            //a.Add("dockdate");
            //a.Add("requireddate");
            //a.Add("orderreference");
            //a.Add("companycode");
            //a.Add("shippingname");
            //a.Add("billingname");
            //a.Add("shippingaddress");
            //a.Add("billingaddress");

            //SortedList props = x.xSys.CoalescePropsByClass("ordhed");
            //long importcount = 0;
            //if (!dtOrders.ImportObjects(ordhed.MakeOrdhedName(ot), "unique_id", props, a, ref importcount))
            //    return false;
            ////link by company name if no company id is there.
            //if (!dtOrders.HasColumnField("base_company_uid") && dtOrders.HasColumnField("companyname"))
            //{
            //    String strSQL = "update " + ordhed.MakeOrdhedName(ot) + " set base_company_uid = (select max(unique_id) from company where company.companyname = " + ordhed.MakeOrdhedName(ot) + ".companyname) where isnull(base_company_uid, '') = '' and isnull(companyname, '') > ''";
            //    if (!x.context.Execute(strSQL))
            //        return false;
            //}
            //x.TheLeader.TellTemp("Done: " + Tools.Number.LongFormat(importcount) + " " + ot.ToString() + " orders were imported.");
            //return true;
        }
        //Private Functions
        protected bool CheckCreditCardFields()
        {
            try
            {
                if (!Tools.Strings.StrExt(creditcardnumber))
                    return false;
                if (!Tools.Strings.StrExt(creditcardtype))
                    return false;
                if (!Tools.Strings.StrExt(securitycode))
                    return false;
                if (expiration_month <= 0)
                    return false;
                if (expiration_year <= 0)
                    return false;
                if (!Tools.Strings.StrExt(nameoncard))
                    return false;
                if (!Tools.Strings.StrExt(cardbillingaddr))
                    return false;
                if (!Tools.Strings.StrExt(cardbillingzip))
                    return false;
            }
            catch { }
            return true;
        }
        private bool HasDetailShipVia(ContextRz context)
        {
            context.TheLeader.Error("reorg");

            //try
            //{
            //    GatherDetails();
            //    foreach (orddet d in DetailsList(context))
            //    {
            //        orddet d = (orddet)kvp.Value;
            //        if (d == null)
            //            continue;
            //        if (!d.isselected)
            //            continue;
            //        if (!Tools.Strings.StrExt(d.shipvia))
            //            return false;
            //    }
            //    return true;
            //}
            //catch { }
            return false;
        }
        protected void SendBasicPurchase(ContextRz context)
        {
            n_team t = n_team.GetByName(context, "Purchasing Team");
            if (t == null)
                return;
            ArrayList a = t.GetUserIDs(context);
            foreach (String str in a)
            {
                NewMethod.n_user user = NewMethod.n_user.New(context);
                if (user != null)
                {
                    usernote n = usernote.New(context);
                    n.the_ordhed_uid = this.unique_id;
                    n.for_mc_user_uid = user.unique_id;
                    n.notetype = "PurchaseOrderCreation";
                    n.createdforname = user.name;
                    n.displaydate = DateTime.Now;
                    n.subjectstring = this.ToString() + " is ready to have the purchase orders created.";
                    n.shouldpopup = true;
                    n.notetext = this.ToString() + " is ready to have the purchase orders created.";
                    context.Insert(n);
                    n.CreateObjectLink(context, this, this.ToString());
                }
            }
        }

        protected void SendBasicTicket(ContextRz context)
        {
            n_team t = n_team.GetByName(context, "Warehouse Team");
            if (t == null)
                return;
            ArrayList a = t.GetUserIDs(context);
            foreach (String str in a)
            {
                NewMethod.n_user user = NewMethod.n_user.GetById(context, str);
                if (user != null)
                {
                    usernote n = usernote.New(context);
                    n.the_ordhed_uid = this.unique_id;
                    n.for_mc_user_uid = user.unique_id;
                    n.notetype = "PickTicketCreate";
                    n.createdforname = user.name;
                    n.displaydate = DateTime.Now;
                    n.subjectstring = this.ToString() + " is ready to have the pick ticket created.";
                    n.shouldpopup = true;
                    n.notetext = this.ToString() + " is ready to have the pick ticket created.";
                    context.Insert(n);
                    n.CreateObjectLink(context, this, this.ToString());
                }
            }
        }
        private Boolean GetPORecvStatus(ContextRz context)
        {
            context.TheLeader.Error("reorg");
            return false;


        }


        private void CheckDefaultBuyer(ContextRz context)
        {
            if (Tools.Strings.StrExt(context.Logic.DefaultBuyerID))
                orderbuyerid = context.Logic.DefaultBuyerID;
        }



        private void ReNumber(ContextRz context)
        {
            if (!context.TheLeader.AreYouSure("change the number of this order"))
                return;
            String strNewNumber = context.TheLeader.AskForString("Enter the new order number: ", "Order Number", false);  // context.TheLeader.AskForString("Enter the new order number: ", "Order Number", context.TheSysRz.TheOrderLogic.GetNextNumber(xSys, OrderType), owner);
            if (!Tools.Strings.StrExt(strNewNumber))
                return;
            ordernumber = strNewNumber;
            context.Update(this);
            foreach (ordlnk l in LinksListAll(context))
            {
                if (Tools.Strings.StrCmp(l.orderid1, unique_id))
                    l.ordernumber1 = ordernumber;
                else if (Tools.Strings.StrCmp(l.orderid2, unique_id))
                    l.ordernumber2 = ordernumber;
                context.TheDelta.Update(context, l);
            }
        }

        private bool Verify(ContextRz context)
        {
            String strReport = "";
            bool boolOK = true;
            switch (OrderType)
            {
                case Enums.OrderType.Sales:
                    if (!Tools.Strings.StrExt(terms))
                    {
                        strReport = strReport + "Missing Information: Terms\r\n";
                        boolOK = false;
                    }
                    if (!Tools.Strings.StrExt(orderreference))
                    {
                        strReport = strReport + "Missing Information: PO Number\r\n";
                        boolOK = false;
                    }

                    if (!Tools.Strings.StrExt(shipvia))
                    {
                        strReport = strReport + "Missing Information: Ship Via\r\n";
                        boolOK = false;
                    }
                    if (!Tools.Dates.DateExists(requireddate))
                    {
                        strReport = strReport + "Missing Information: Required Date\r\n";
                        boolOK = false;
                    }
                    if (!Tools.Strings.StrExt(billingaddress))
                    {
                        strReport = strReport + "Missing Information: Billing Address\r\n";
                        boolOK = false;
                    }
                    if (!Tools.Strings.StrExt(shippingaddress))
                    {
                        strReport = strReport + "Missing Information: Shipping Address\r\n";
                        boolOK = false;
                    }
                    //int i = GetNoCostLineCount(context);
                    //if (i > 0)
                    //{
                    //    strReport = strReport + "At least one line item has a price, but no cost\r\n";
                    //    boolOK = false;
                    //}
                    break;
            }
            if (boolOK)
            {
                isverified = true;
                context.Update(this);
                return true;
            }
            else
            {
                context.TheLeader.Tell("This order appears to be missing some required information: \r\n" + strReport);
                return false;
            }
        }



        public void CreateHoldNoteByName(ContextRz context, String strName, String strText)
        {
            CreateHoldNoteByID(context, NewMethod.n_user.TranslateNameToID(context, strName), strText);
        }
        private void CreateHoldNoteByID(ContextRz context, String strID, String strText)
        {
            if (!Tools.Strings.StrExt(strID))
                return;
            usernote xNote = usernote.New(context);
            xNote.by_mc_user_uid = context.xUser.unique_id;
            xNote.for_mc_user_uid = strID;
            xNote.notetext = strText;
            xNote.displaydate = DateTime.Now;
            xNote.shouldpopup = true;
            context.Insert(xNote);
            xNote.CreateObjectLink(context, this, ToString());
        }

        //private bool CheckForUnselected()
        //{
        //    try
        //    {
        //        if (AllDetails == null)
        //            return false;
        //        if (AllDetails.Count <= 0)
        //            return false;
        //        int a = AllDetails.Count;
        //        int i = GetValidLines().Count;
        //        if (a == i)
        //            return true;
        //        a = a - i;
        //        if (a <= 0)
        //            return true;
        //        if (a == 1)
        //            return context.TheLeader.AskYesNo("There is 1 unselected item on this order. Are you sure you want to leave it off this new order?");
        //        else
        //            return context.TheLeader.AskYesNo("There are " + a.ToString() + " unselected items on this order. Are you sure you want to leave them off this new order?");
        //    }
        //    catch { }
        //    return false;
        //}
        protected void CheckForNetReminder(ContextRz context)
        {
            if (!this.terms.ToLower().StartsWith("net"))
                return;
            string id = context.SelectScalarString("select top 1 unique_id from " + ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Invoice) + " where ordertype = 'invoice' and base_company_uid = '" + this.base_company_uid + "' and terms like 'net%'");
            if (Tools.Strings.StrExt(id))
                return;
            context.TheLeader.Tell("It appears that this is the first invoice for this customer using NET terms. Please double-check to see that this customer has been approved for these terms.");
        }


        //private String MixWithWord(ContextRz context, nObject xObject, String strWordFile)
        //{
        //    if (!File.Exists(strWordFile))
        //        return "";
        //    try
        //    {
        //        Object obj = System.Reflection.Missing.Value;
        //        WordApplication xApp = new WordApplication();
        //        WordDocument xDoc = xApp.DocumentOpen(strWordFile);
        //        ToolsWordNM.MixObjectWithWordDocument(xObject, xDoc);
        //        company xCompany = new company(xSys);
        //        companycontact xContact = new companycontact(xSys);
        //        ordhed xOrder = new ordhed(xSys);
        //        company xVendor = new company(xSys);
        //        NewMethod.n_user xAgent = new NewMethod.n_user(xSys);
        //        switch (xObject.ClassName.ToLower())
        //        {
        //            case "company":
        //                xAgent = NewMethod.n_user.GetByID(xSys, ((company)xObject).base_mc_user_uid);
        //                break;
        //            case "companycontact":
        //                xAgent = NewMethod.n_user.GetByID(xSys, ((companycontact)xObject).base_mc_user_uid);
        //                xCompany = company.GetByID(xSys, ((companycontact)xObject).base_company_uid);
        //                break;
        //            case "ordhed":
        //                xAgent = NewMethod.n_user.GetByID(xSys, ((ordhed)xObject).base_mc_user_uid);
        //                xCompany = company.GetByID(xSys, ((ordhed)xObject).base_company_uid);
        //                xOrder = (ordhed)xObject;
        //                break;
        //            case "orddet":
        //                contextRz.TheLeader.Error("reorg");

        //                //xOrder = ordhed.GetByID(xSys, ((orddet)xObject).base_ordhed_uid);
        //                //xVendor = company.GetByID(xSys, ((orddet)xObject).vendor_company_uid);

        //                if (xOrder != null)
        //                    xAgent = xOrder.AgentVar.RefGet(contextRz);
        //                break;
        //            case "checkpayment":
        //                xCompany = company.GetByID(xSys, ((checkpayment)xObject).base_company_uid);
        //                break;
        //        }
        //        if (xAgent == null)
        //            xAgent = Rz3App.xUser;
        //        if (xAgent != null)
        //            ToolsWordNM.MixObjectWithWordDocument(xAgent, xDoc);
        //        if (xCompany != null)
        //            ToolsWordNM.MixObjectWithWordDocument(xCompany, xDoc);
        //        if (xContact != null)
        //            ToolsWordNM.MixObjectWithWordDocument(xContact, xDoc);
        //        if (xOrder != null)
        //            ToolsWordNM.MixObjectWithWordDocument(xOrder, xDoc);
        //        if (xVendor != null)
        //            ToolsWordNM.MixObjectWithWordDocument(xVendor, xDoc);
        //        ToolsWordNM.MixObjectWithWordDocument(Rz3App.xUser, xDoc, "", 0, "xUser");
        //        if (Tools.Strings.StrCmp(xObject.ClassName, "ordhed"))
        //        {
        //            String s1 = Tools.Strings.ParseDelimit(xOrder.shippingaddress, "\r\n", 1);
        //            String s2 = Tools.Strings.ParseDelimit(xOrder.shippingaddress, "\r\n", 2);
        //            String s3 = Tools.Strings.ParseDelimit(xOrder.shippingaddress, "\r\n", 3);
        //            String s4 = Tools.Strings.ParseDelimit(xOrder.shippingaddress, "\r\n", 4);
        //            String b1 = Tools.Strings.ParseDelimit(xOrder.billingaddress, "\r\n", 1);
        //            String b2 = Tools.Strings.ParseDelimit(xOrder.billingaddress, "\r\n", 2);
        //            String b3 = Tools.Strings.ParseDelimit(xOrder.billingaddress, "\r\n", 3);
        //            String b4 = Tools.Strings.ParseDelimit(xOrder.billingaddress, "\r\n", 4);
        //            xDoc.ReplaceText("<ORDHED.SHIPPINGADDRESS_1>", s1, 100);
        //            xDoc.ReplaceText("<ORDHED.SHIPPINGADDRESS_2>", s2, 100);
        //            xDoc.ReplaceText("<ORDHED.SHIPPINGADDRESS_3>", s3, 100);
        //            xDoc.ReplaceText("<ORDHED.SHIPPINGADDRESS_4>", s4, 100);
        //            xDoc.ReplaceText("<ORDHED.BILLINGADDRESS_1>", b1, 100);
        //            xDoc.ReplaceText("<ORDHED.BILLINGADDRESS_2>", b2, 100);
        //            xDoc.ReplaceText("<ORDHED.BILLINGADDRESS_3>", b3, 100);
        //            xDoc.ReplaceText("<ORDHED.BILLINGADDRESS_4>", b4, 100);
        //            List<orddet> colDetails = ((ordhed)xObject).DetailsList(context);
        //            Int32 intCount = 1;
        //            orddet hold = null;
        //            foreach (orddet det in colDetails)
        //            {
        //                if (hold == null)
        //                    hold = det;
        //                ToolsWordNM.MixObjectWithWordDocument(det, xDoc, "DETAIL", intCount, "");
        //                intCount += 1;
        //            }
        //            ToolsWordNM.ClearTags(xDoc, "DETAIL", hold, intCount, 100);
        //        }
        //        String ret = strWordFile.Replace(".doc", "_" + Tools.Strings.GetNewID() + ".doc");
        //        xDoc.SaveAs(ret);
        //        Object o = true;
        //        xDoc.Close();
        //        xApp.Close();
        //        return ret.ToString();
        //    }
        //    catch (Exception ee)
        //    {
        //        return "";
        //    }
        //}
        private void ApplyInvoice(ContextRz context)
        {
            String strInvoiceNumber = context.TheLeader.AskForString("Invoice Number", "", "Invoice Number");
            if (!Tools.Strings.StrExt(strInvoiceNumber))
                return;
            String strID = context.SelectScalarString("select unique_id from " + ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Invoice) + " where ordertype = 'invoice' and ordernumber = '" + strInvoiceNumber + "'");
            if (!Tools.Strings.StrExt(strID))
            {
                context.TheLeader.Tell("The invoice '" + strInvoiceNumber + "' could not be found.");
                return;
            }
            context.Execute("update " + ordhed.MakeOrdhedName(Enums.OrderType.Service) + " set apply_ordhed_invoice_uid = '" + context.Filter(strID) + "' where unique_id = '" + context.Filter(unique_id) + "'");
            context.TheLeader.Tell("Done.");
        }

        public virtual List<LineHandle> DetailsListForPrintLines(ContextRz context, bool consolidate_if_possible, String template_name)
        {
            List<orddet> details = DetailsListForPrint(context, consolidate_if_possible, template_name);
            List<LineHandle> ret = new List<LineHandle>();
            foreach (orddet d in details)
            {
                if (!d.noPrint)
                    ret.Add(((SysRz5)context.xSys).TheOrderLogic.GetLineHandleObject(context, this, d));
            }
            return ret;
        }

        public virtual List<orddet> DetailsListForPrint(ContextRz context, bool consolidate_if_possible, String template_name)
        {
            return ((SysRz5)context.xSys).ThePrintLogic.DetailsListForPrint(context, this, consolidate_if_possible, template_name);
           
        }

       

        public static bool GetAsVendor(Enums.OrderDirection dir)
        {
            return (dir == Rz5.Enums.OrderDirection.Incoming);
        }
        public static bool GetAsService(Enums.OrderType t)
        {
            return (t == Rz5.Enums.OrderType.Service);
        }
        public void PickAll(ContextRz context)
        {
            context.TheLeader.Error("reorg");

        }
        public void PasteLineInfo(ContextRz context)
        {
            bool b = true;
            if (orddet.GlobalLineInfo == null)
                b = false;
            else if (orddet.GlobalLineInfo.Count == 0)
                b = false;

            if (!b)
                return;

            if (!context.TheLeader.AreYouSure("paste " + Tools.Strings.PluralizePhrase("line", orddet.GlobalLineInfo.Count)))
                return;

            foreach (orddet d in orddet.GlobalLineInfo)
            {
                if (d is orddet_old)
                {
                    orddet_old old = (orddet_old)d;
                    orddet n = AddLineItem(context, old.fullpartnumber, old.quantityordered, old.unitprice);
                    n.manufacturer = d.manufacturer;
                    n.datecode = d.datecode;
                    n.condition = d.condition;
                    n.description = d.description;
                    context.Update(n);
                }
                else if (d is orddet_line)
                {
                    orddet_line line = (orddet_line)d;
                    orddet n = AddLineItem(context, line.fullpartnumber, line.quantity, line.unit_price);
                    n.manufacturer = d.manufacturer;
                    n.datecode = d.datecode;
                    n.condition = d.condition;
                    n.description = d.description;
                    context.Update(n);
                }
            }
            context.Update(this);
        }
        public void ShowLineReport(ContextRz context)
        {
            ArrayList a = new ArrayList();
            a.Add(unique_id);
            ShowLineReport(context, OrderType, a, ToString());
        }
        public static void ShowLineReport(ContextRz context, Enums.OrderType type, ArrayList ids, String strCaption)
        {
            String strQuantityField = "quantityfilled";
            String strAmountField = "extendedfilled";
            if (type == Rz5.Enums.OrderType.Sales)
            {
                strQuantityField = "quantityordered";
                strAmountField = "extendedorder";
            }
            String strSQL = "select hed.orderdate as [Date], hed.ordernumber as [Document #], hed.companyname as [Customer Name], hed.ordertotal as [Document Amount], line." + strAmountField + " as [Sales Amount], (line." + strQuantityField + " * line.unitcost) as [Total Cost], line.lineprofit as [Gross Profit] from " + MakeOrdhedName(type) + " hed inner join " + MakeOrddetName(type) + " line on line.base_ordhed_uid = hed.unique_id ";
            strSQL += " where hed.unique_id in ( " + nTools.GetIn(ids) + " ) order by hed.ordernumber, line.linecode";
            ArrayList formats = new ArrayList();
            formats.Add("");
            formats.Add("");
            formats.Add("");
            formats.Add("{0:C}");
            formats.Add("{0:C}");
            formats.Add("{0:C}");
            formats.Add("{0:C}");
            ArrayList alignments = new ArrayList();
            alignments.Add("");
            alignments.Add("");
            alignments.Add("");
            alignments.Add("right");
            alignments.Add("right");
            alignments.Add("right");
            alignments.Add("right");
            context.TheLeader.ShowHtml(context, strCaption, nData.ConvertDataTableToHTML(context.Select(strSQL), formats, alignments, false));
        }

        public String GetStrippedPartsIn(ContextRz context)
        {
            ArrayList a = new ArrayList();
            foreach (orddet d in DetailsList(context))
            {
                String s = PartObject.StripPart(d.fullpartnumber);
                if (s.Length > 3)
                    a.Add(s);
            }
            return nTools.GetIn(a);
        }

        public bool IsRockwellCollins
        {
            get
            {
                if (Tools.Strings.HasString(companyname, "Rockwell") && Tools.Strings.HasString(companyname, "Collins"))
                    return true;

                if (Tools.Strings.HasString(primaryemailaddress, "@rockwellcollins.com"))
                    return true;

                return false;
            }
        }

        public bool IsLockheed
        {
            get
            {
                if (Tools.Strings.HasString(companyname, "lockheed"))
                    return true;

                if (Tools.Strings.HasString(primaryemailaddress, "@lmco.com"))
                    return true;

                return false;
            }
        }

        public bool IsRaytheon
        {
            get
            {
                if (Tools.Strings.HasString(companyname, "raytheon"))
                    return true;

                if (Tools.Strings.HasString(primaryemailaddress, "@raytheon.com"))
                    return true;

                return false;
            }
        }

        public bool IsL3
        {
            get
            {
                if (Tools.Strings.StartsWith(companyname, "L3") || Tools.Strings.StartsWith(companyname, "L-3"))
                    return true;

                if (Tools.Strings.HasString(primaryemailaddress, "@l-3com.com"))
                    return true;

                return false;
            }
        }

        public bool IsNorthrop
        {
            get
            {
                if (Tools.Strings.HasString(companyname, "northrop"))
                    return true;

                if (Tools.Strings.HasString(primaryemailaddress, "@ngc.com"))
                    return true;

                return false;
            }
        }

        public bool IsBoeing
        {
            get
            {
                if (Tools.Strings.HasString(companyname, "boeing"))
                    return true;

                if (Tools.Strings.HasString(primaryemailaddress, "@boeing.com"))
                    return true;

                return false;
            }
        }

        public bool IsInternational(ContextRz x)
        {
            foreach (orddet d in DetailsList(x))
            {
                if (!(d is orddet_line))
                    continue;
                orddet_line l = (orddet_line)d;
                if (Tools.Strings.StrCmp("FedEx international priority", l.shipvia_invoice))
                    return true;
                if (Tools.Strings.StrCmp("FedEx international economy", l.shipvia_invoice))
                    return true;
                if (Tools.Strings.StrCmp("Ups worldwide express", l.shipvia_invoice))
                    return true;
                if (Tools.Strings.StrCmp("Ups worldwide express plus", l.shipvia_invoice))
                    return true;
                if (Tools.Strings.StrCmp("Ups worldwide standard", l.shipvia_invoice))
                    return true;
                if (Tools.Strings.StrCmp("Ups worldwide expedited", l.shipvia_invoice))
                    return true;
                if (Tools.Strings.StrCmp("Dhl intl air/ocean", l.shipvia_invoice))
                    return true;
                if (l.shipvia_invoice.ToLower().Contains("worldwide"))
                    return true;
                if (l.shipvia_invoice.ToLower().Contains("international"))
                    return true;
                if (l.shipvia_invoice.ToLower().Contains("intl"))
                    return true;
                if (l.shipvia_invoice.ToLower().Contains("dhl"))
                    return true;
            }
            if (Tools.Strings.StrCmp("FedEx international priority", shipvia))
                return true;
            if (Tools.Strings.StrCmp("FedEx international economy", shipvia))
                return true;
            if (Tools.Strings.StrCmp("Ups worldwide express", shipvia))
                return true;
            if (Tools.Strings.StrCmp("Ups worldwide express plus", shipvia))
                return true;
            if (Tools.Strings.StrCmp("Ups worldwide standard", shipvia))
                return true;
            if (Tools.Strings.StrCmp("Ups worldwide expedited", shipvia))
                return true;
            if (Tools.Strings.StrCmp("Dhl intl air/ocean", shipvia))
                return true;
            if (shipvia.ToLower().Contains("worldwide"))
                return true;
            if (shipvia.ToLower().Contains("international"))
                return true;
            if (shipvia.ToLower().Contains("intl"))
                return true;
            if (shipvia.ToLower().Contains("dhl"))
                return true;
            return false;
        }

        public ordhed Duplicate(ContextRz context)
        {
            context.TheLeader.Error("reorg");
            return null;

            //ordhed ret = (ordhed)this.CloneWithNewID();
            //ret.ordernumber = GetNextNumber(context.xSys, ret.OrderType);
            //ret.orderdate = DateTime.Now;
            //ret.ISave_PreserveID(context);
            //GatherDetails();
            //foreach (orddet d in DetailsList(context))
            //{
            //    orddet dx = (orddet)((orddet)kvp.Value).CloneWithNewID();
            //    dx.base_ordhed_uid = ret.unique_id;
            //    dx.ISave_PreserveID(context);
            //}
            //ret.IUpdate();
            //ret.GatherDetails();
            //return ret;
        }

        public ordhed ReOrderSOCreate(ContextNM context)
        {
            context.TheLeader.Error("reorg");
            return null;

            /*

            ordhed ret = ordhed.CreateNew(context, Rz4.Enums.OrderType.Sales);
            ret.ISave();

            ret.CompanyObject = this.CompanyObject;
            ret.ContactObject = this.ContactObject;

            ret.primaryphone = primaryphone;
            ret.primaryfax = primaryfax;
            ret.primaryemailaddress = primaryemailaddress;
            ret.shippingname = shippingname;
            ret.shippingaddress = shippingaddress;
            ret.billingname = billingname;
            ret.billingaddress = billingaddress;

            ret.IUpdate();

            foreach (orddet d in DetailsList(context))
            {
                orddet dx = (orddet)((orddet)kvp.Value).CloneWithNewID();
                dx.base_ordhed_uid = ret.unique_id;
                dx.shipdate = Tools.Dates.GetNullDate();
                dx.shipvia = "";
                dx.ISave_PreserveID(context);
            }

            ret.IUpdate();
            ret.GatherDetails();

            return ret;
             * 
             * */
        }

        void TestPicturesShow(ContextRz context)
        {
            test_pictures p = TestPicturesGet(context);
            if (p == null)
            {
                p = test_pictures.New(context);
                p.the_ordhed_uid = this.unique_id;
                context.Insert(p);
            }

            context.Show(p);
        }

        public test_pictures TestPicturesGet(ContextRz context)
        {
            return (test_pictures)context.QtO("test_pictures", "select * from test_pictures where the_ordhed_uid = '" + this.unique_id + "'");
        }

        public virtual ListArgsOrder DetailArgsGet(ContextRz context)
        {
            //details.ExtraClassInfo = CurrentOrder.ordertype;
            //details.CurrentCollection = GetOrderDetailsForLV();
            //details.ShowTemplate("ORDERDETAIL" + CurrentOrder.ordertype, CurrentOrder.OrddetName, Rz3App.xUser.TemplateEditor);
            //details.RefreshFromCollection();

            ListArgsOrder ret = new ListArgsOrder(context, OrderType);
            ret.TheClass = Details.DetailClass;
            ret.TheTable = Details.DetailClass;
            //ret.LiveObjects = AllDetails;
            ret.LiveItems = DetailsAsItems(context);
            ret.TheTemplate = "ORDERDETAIL" + ordertype;  //New
            //ret.ExtraClassInfo = ordertype;
            ret.AddAllow = true;
            ret.AddCaption = "Add A New " + FriendlyOrderType + " Line";
            ret.TheCaption = OrderType.ToString() + " Line Items";
            return ret;
        }

        public virtual void DetailAddWithChecks(ContextNM context)
        {
            orddet TheDetail = this.GetNewDetail((ContextRz)context);
            context.Update(TheDetail);
            context.Show(new ShowArgsOrder(context, TheDetail, this.OrderType));
        }

        public static void Restore(ContextRz x)
        {
            if (!x.xSys.Recall)
            {
                x.TheLeader.Tell("This system isn't set up for Recall.");
                return;
            }
            string orderNumbers = x.TheLeader.AskForString("Order Numbers?", "", true);
            if (!Tools.Strings.StrExt(orderNumbers))
                return;
            ArrayList a = x.Leader.ChooseFromArray(x, ordhed.OrderTypesStringArray, "Order type");
            if (a.Count == 0)
                return;
            string strType = (String)a[0];
            if (!Tools.Strings.StrExt(strType))
                return;

            List<String> numbersList = Tools.Strings.SplitLinesList(orderNumbers);
            foreach (String orderNumber in numbersList)
            {
                Restore(x, orderNumber, strType, (numbersList.Count <= 5));
            }

            if (numbersList.Count > 5)
                x.TheLeader.Tell("Done");
        }

        public static void Restore(ContextRz x, String orderNumber, String orderType, bool showRestored)
        {
            string strSQL = "select unique_id from " + ordhed.MakeOrdhedName(orderType) + " where ordernumber = '" + orderNumber + "' ";
            string s = x.SelectScalarString(strSQL);
            if (Tools.Strings.StrExt(s))
            {
                x.TheLeader.Tell("The " + orderType + " document number " + orderNumber + " appears to already exist in the main database.");
                return;
            }
            s = x.Sys.RecallConnection.ScalarString(strSQL);
            if (!Tools.Strings.StrExt(s))
            {
                x.TheLeader.Tell("The " + orderType + " document number " + orderNumber + " wasn't found in the Recall system.");
                return;
            }
            DataTable st = x.Sys.RecallConnection.Select("select top 1 * from " + ordhed.MakeOrdhedName(orderType) + " where unique_id = '" + s + "' and recall_type = 3 order by recall_date desc");
            if (!Tools.Data.DataTableExists(st))
            {
                x.TheLeader.Tell("No deleted order was found with UID " + s);
                return;
            }

            CoreClassHandle h = x.Sys.CoreClassGet(ordhed.MakeOrdhedName(orderType).ToLower());
            DataRow r = st.Rows[0];
            ordhed ox = Restore(x, r, orderType, h);

            if (showRestored)
                x.xSys.ThrowByKey(x, ordhed.MakeOrdhedName(orderType) + ":" + s);
        }

        public static ordhed Restore(ContextNM x, DataRow r, String strType, CoreClassHandle handle)
        {
            ordhed ox = (ordhed)x.Item(ordhed.MakeOrdhedName(strType));
            ox.unique_id = nData.NullFilter_String(r["unique_id"]);
            foreach (CoreVarValAttribute p in handle.VarValsGet())
            {
                try { ox.ISet(p.Name, r[p.Name]); }
                catch { }
            }
            ox.InsertWithExistingId(x);
            RestoreDetails(x, ox, strType);
            return ox;
        }
        private static void RestoreDetails(ContextNM x, ordhed ox, String strType)
        {
            if (Tools.Strings.StrCmp(strType, "quote"))
                return;
            if (Tools.Strings.StrCmp(strType, "rfq"))
                return;
            ArrayList a = x.Sys.RecallConnection.ScalarArray("select distinct(unique_id) from orddet_line where orderid_" + strType.ToLower() + " = '" + ox.unique_id + "'");
            if (a == null)
                return;
            if (a.Count <= 0)
                return;
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                try { x.Execute("update orddet_line set ordernumber_" + strType.ToLower() + " = '" + ox.ordernumber + "', orderid_" + strType.ToLower() + " = '" + ox.unique_id + "' where unique_id = '" + s + "'"); }
                catch { }
            }
        }
        public List<orddet> DetailsListStatus(ContextRz context, Enums.OrderLineStatus s)
        {
            List<orddet> ret = new List<orddet>();
            foreach (orddet d in DetailsList(context))
            {
                if (d.Status == s)
                {
                    ret.Add(d);
                }
            }
            return ret;
        }

        public void NumberChange(ContextRz context)
        {

            //KT - Checks whether user has permission to change Order Number
            if (!context.xUser.CheckPermit(context, "permit_ChangeOrderNumbers", true))
                return;
            String s = context.TheLeader.AskForString("New order number", ordernumber, false);
            if (!Tools.Strings.StrExt(s))
                return;
            if (Tools.Strings.StrCmp(s, ordernumber))
                return;
            string id = context.SelectScalarString("select unique_id from " + ClassId + " where ordernumber = '" + context.Filter(s) + "' and ordertype = '" + ordertype + "'");
            if (Tools.Strings.StrExt(id))
            {
                context.TheLeader.Tell("There is already a " + ordertype.ToLower() + " in the system with the order number: " + s);
                return;
            }
            ordernumber = s;
            UpdateLineOrderNumber(context);
            context.Update(this);
        }
        public void UpdateLineOrderNumber(ContextRz context)
        {
            if (!Tools.Strings.StrExt(ordernumber))
                return;
            string field = GetLineOrderNumberField(context);
            switch (field.ToLower())
            {
                case "ordernumber_rfq":
                case "ordernumber_quote":
                    return;
            }
            if (!Tools.Strings.StrExt(field))
                return;
            foreach (orddet_line d in DetailsList(context))
            {
                d.ISet(field, ordernumber);
                context.Update(d);
            }
        }
        public string GetLineOrderNumberField(ContextRz context)
        {
            switch (this.OrderType)
            {
                case Enums.OrderType.Invoice:
                    return "ordernumber_invoice";
                case Enums.OrderType.Purchase:
                    return "ordernumber_purchase";
                case Enums.OrderType.Quote:
                    return "ordernumber_quote";
                case Enums.OrderType.RFQ:
                    return "ordernumber_rfq";
                case Enums.OrderType.RMA:
                    return "ordernumber_rma";
                case Enums.OrderType.Sales:
                    return "ordernumber_sales";
                case Enums.OrderType.Service:
                    return "ordernumber_service";
                case Enums.OrderType.VendRMA:
                    return "ordernumber_vendrma";
                default:
                    return "";
            }
        }
        public ArrayList LinkedOrderIdsGet(ContextRz context)
        {
            ArrayList linkedids = context.SelectScalarArray("select distinct(orderid2) from ordlnk where ordlnk.orderid1 = '" + unique_id + "'");
            ArrayList deals = null;
            String linkedidsin = nTools.GetIn(linkedids);

            for (int r = 0; r < 5; r++)
            {
                ArrayList secondlinkedids = null;
                if (Tools.Strings.StrExt(linkedidsin))
                    secondlinkedids = context.SelectScalarArray("select distinct(orderid2) from ordlnk where ordlnk.orderid1 in ( " + linkedidsin + " ) and orderid2 not in (" + linkedidsin + ")");
                else
                    secondlinkedids = new ArrayList();

                if (secondlinkedids.Count == 0)
                    break;

                foreach (String x in secondlinkedids)
                {
                    if (!linkedids.Contains(x))
                        linkedids.Add(x);
                }

                linkedidsin = nTools.GetIn(linkedids);
            }

            if (Tools.Strings.StrExt(unique_id))
                linkedids.Add(unique_id);
            if (linkedids.Count > 0)
                deals = context.SelectScalarArray("select distinct(base_dealheader_uid) from ordhed where base_dealheader_uid > '' and unique_id in( " + nTools.GetIn(linkedids) + ")");
            else
                deals = new ArrayList();
            ArrayList dealorders = null;
            if (deals.Count > 0)
                dealorders = context.SelectScalarArray("select distinct(unique_id) from ordhed where isnull(isvoid, 0) = 0 and base_dealheader_uid in (" + nTools.GetIn(deals) + ")");
            else
                dealorders = new ArrayList();
            //this is where every possible order id needs to be added
            ArrayList ret = new ArrayList();
            foreach (String s in linkedids)
            {
                if (!ret.Contains(s))
                    ret.Add(s);
            }
            foreach (String s in dealorders)
            {
                if (!ret.Contains(s))
                    ret.Add(s);
            }

            return ret;
        }

        public void DateChange(ContextRz context)
        {
            if (!context.xUser.CheckPermit(context, "permit_CanChangeOrderDate", true) && !context.xUser.SuperUser)
                return;
            DateTime d = context.TheLeaderRz.ChooseDate(orderdate, "Choose a new order date:");
            if (!Tools.Dates.DateExists(d))
                return;
            orderdate = d;
            context.TheDelta.Update(context, this);
            foreach (orddet detail in DetailsList(context))
            {
                detail.OrderDateSet(context, orderdate, OrderType);
            }
        }

        public Dictionary<nObject, List<string>> MissingPropertiesList = new Dictionary<nObject, List<string>>();

        public void LoadMissingProperties(ContextRz x, bool gatherValues = false)
        {
            this.MissingPropertiesList = new Dictionary<nObject, List<string>>();//Clear out the old list, so no key add conflicts.           
                                                                                 //Fill the master list with missing Header Properties



            //Dictionary<nObject, List<string>> missingHeaderProperties = RzWin.Context.TheSysRz.TheOrderLogic.GetMissingPropertiesForObject(RzWin.Context, CurrentOrder, gatherValues, true);
            Dictionary<nObject, List<string>> missingHeaderProperties = x.TheSysRz.TheOrderLogic.GetMissingPropertiesForObject(x, this, gatherValues, true);
            if (missingHeaderProperties.Count > 0)
                foreach (KeyValuePair<nObject, List<string>> kvp in missingHeaderProperties)
                    if (!MissingPropertiesList.ContainsKey(kvp.Key))
                        MissingPropertiesList.Add(kvp.Key, kvp.Value);
                    else
                        MissingPropertiesList[kvp.Key].AddRange(kvp.Value);
            //Fill the master list with missing Detail Properties

            foreach (orddet det in DetailsList(x))
            {
                Dictionary<nObject, List<string>> missingDetailProperties = new Dictionary<nObject, List<string>>();
                missingDetailProperties = x.TheSysRz.TheOrderLogic.GetMissingPropertiesForObject(x, det, gatherValues, true);
                if (missingDetailProperties.Count > 0)
                    foreach (KeyValuePair<nObject, List<string>> kvp in missingDetailProperties)
                        if (!this.MissingPropertiesList.ContainsKey(kvp.Key))
                            this.MissingPropertiesList.Add(kvp.Key, kvp.Value);
                        else
                            this.MissingPropertiesList[kvp.Key].AddRange(kvp.Value);
            }
        }

        private Dictionary<nObject, List<string>> RemoveIgnoredProperties(List<string> ignoreList)
        {
            Dictionary<nObject, List<string>> remainingMissingItems = new Dictionary<nObject, List<string>>();
            Dictionary<nObject, List<string>> removeList = new Dictionary<nObject, List<string>>();

            foreach (KeyValuePair<nObject, List<string>> kvp in MissingPropertiesList) //For each specific Object, check it's missing properties, and remove them if on ignore list.
            {
                foreach (string s in kvp.Value)
                {
                    string ignoredProp = s;
                    if (ignoredProp.Contains(":"))
                        ignoredProp = s.Substring(0, s.IndexOf(':'));
                    if (ignoreList.Contains(ignoredProp.ToLower()))//if it's on the ignore list, don't add to the remaining missing list.
                        continue;
                    else
                    {
                        if (!remainingMissingItems.ContainsKey(kvp.Key))
                            remainingMissingItems.Add(kvp.Key, kvp.Value);
                        continue;
                    }


                }

            }




            ////Remove Exactly Matching Properties
            //foreach (string s in ignoreList)
            //{
            //    foreach (KeyValuePair<nObject, List<string>> kvp in MissingPropertiesList)
            //    {

            //        foreach (string ss in kvp.Value.ToArray())
            //            if (!s.Contains(ss))//if not on the ignore list, add to ret.
            //                remainingMissingItems.Add(kvp.Key, kvp.Value);
            //    }
            //}

            ////Remove Custom Matching Properties.
            //foreach (KeyValuePair<nObject, List<string>> kvp in MissingPropertiesList) // or foreach(book b in books.Values)
            //{
            //    string check = kvp.Value.ToString();
            //    foreach (string s in ignoreList)
            //    {
            //        if (check.Equals(s, StringComparison.CurrentCultureIgnoreCase))
            //            remainingMissingItems.Remove(kvp.Key);
            //    }

            //}

            return remainingMissingItems;
        }




        public virtual bool CheckVerify(ContextRz context, List<string> missingProps)
        {
            //return context.TheSysRz.TheSalesLogic.CheckVerify(context, this, sb, new List<string>());
            return context.TheSysRz.TheOrderLogic.CheckVerify(context, this, missingProps);
        }

        public virtual void DetailRefAdd(ContextRz x, orddet_line l)
        {
            l.ValSet("orderid_" + this.OrderType.ToString().ToLower(), this.unique_id);
            l.ValSet("ordernumber_" + this.OrderType.ToString().ToLower(), this.ordernumber);
            l.ValSet("orderdate_" + this.OrderType.ToString().ToLower(), this.orderdate);
            if (l.LineCodeGet(this.OrderType) == 0)
                l.LineCodeSet(this.OrderType, this.GetNextLineCode((ContextRz)x));
            //CONFIRMED- Canceled line getting created here????
            l.CompanyRefSet((ContextRz)x, this.CompanyVar.RefGet(x), this.OrderType);
            l.ContactRefSet((ContextRz)x, this.ContactVar.RefGet(x), this.OrderType);
            l.AgentRefSet((ContextRz)x, this.AgentVar.RefGet(x), this.OrderType);
        }

        public virtual void CompanyRefSet(ContextRz x, company c)
        {

        }

        public virtual bool PrePrintConfirmation(ContextRz context, String templateName)
        {
            return true;
        }
    }
    public class TransmitParameters
    {
        public Enums.TransmitType type;
        public String TemplateName = "";
        public bool Cancelled = false;
        public String EmailAddress = "";
        public String FaxNumber = "";
        public System.Windows.Forms.IWin32Window owner;
        public printheader PrintTemplate;
        public emailtemplate EmailTemplate;
        public int CopyCount = 1;
        public String PrinterName = "";
        public bool ForceSynchronous = false;
        public String CCLines = "";
        public bool UseInternalEmail = false;
        public String FaxPrefix = "";
        public Boolean ConsolidateLines = false;
        public bool SuppressInvalidPackingSlipLines { get; set; }
        public bool BlackAndWhite = false;
        public bool IncludePDF = true;
        public string Attachment = "";

        public TransmitParameters(Enums.TransmitType t)
        {
            type = t;
        }



        //public void GetParameters(ordhed xOrder, System.Windows.Forms.IWin32Window owner)
        //{
        //    frmTransmit xForm = new frmTransmit();
        //    xForm.CompleteLoad(xOrder, this);
        //    xForm.ShowDialog(owner);
        //}
        public void Print(ContextRz context, nObject x)
        {
            //this is a bad design; all of the options from the transmitparameters either get lost here or have to be sent manually

            switch (type)
            {
                case Enums.TransmitType.PDF:
                    this.BlackAndWhite = false;
                    //if (ForceSynchronous)
                    PrintSessionPdf pdf = new PrintSessionPdf(context, PrintTemplate, x);
                    pdf.ConsolidateLines = ConsolidateLines;
                    pdf.Print();
                    //PrintTemplate.PrintObject(context, x, "pdf", this.CopyCount, this.BlackAndWhite, this.ConsolidateLines);
                    //else
                    //    PrintTemplate.PrintObjectAsync(context, x, "pdf", this.CopyCount, this.BlackAndWhite, this.ConsolidateLines);
                    break;
                default:
                    //this.BlackAndWhite = true;  //this is how it was before but is this even appropriate?  What about color printers?
                    //if (ForceSynchronous)

                    PrintSessionPrinter print = new PrintSessionPrinter(context, PrintTemplate, x);
                    print.ConsolidateLines = this.ConsolidateLines;
                    print.Print(PrinterName, this.CopyCount, false, this.ConsolidateLines);
                    //PrintTemplate.PrintObject(context, x, PrinterName, this.CopyCount, this.BlackAndWhite, this.ConsolidateLines);
                    //else
                    //    PrintTemplate.PrintObjectAsync(context, x, PrinterName, this.CopyCount, this.BlackAndWhite, this.ConsolidateLines);
                    break;
            }
        }
    }
    public class OrderSearchParameters
    {
        public String CurrentTemplate = "";
        public String CurrentOrderClass = "";
        public String CurrentOrderTable = "";
        //public String CurrentDetailTable = "";
        public Enums.OrderType DetailType = Enums.OrderType.Any;
        public Enums.OrderType CurrentOrderType = Enums.OrderType.Any;
        public DateTime StartDate = Tools.Dates.NullDate;
        public DateTime EndDate = Tools.Dates.NullDate;
        public String OrderStatus = "";
        //public String Agent = "";
        public n_user Agent = null;
        public n_user SelectedAgent = null;
        public String Office = "";
        public String PhoneFaxEmail = "";
        public String PartNumber = "";
        public String Phone = "";
        public String Fax = "";
        public String Email = "";
        public String CompanyName = "";
        public String ContactName = "";
        public String CompanyType = "";
        public String OrderNumber = "";
        public string HubspotDealID = "";
        public String TrackingNumber = "";
        public Enums.OrderType OrderType = Enums.OrderType.Any;
        public String Manufacturer = "";
        public Int32 RowLimit = 0;
        public String Terms = "";
        public nDouble OrderTotal = 0;
        public String OrderTotalType = "";
        public Boolean UnderPaid = false;
        public Boolean bSuppliedLimit = false;
        public Boolean UnlimitedResults = false;
        public bool limit_by_user = false;
        public bool OpenQuotes = false;
        public bool ConsignmentOnly = false;
        public String Everything = "";
        public bool IncludeVoid = true;
        //KT
        public string InvoiceStatus = "";
        public string oppportinity_stage = "";
        public string OnlyConfirmedPOs = "";
    }

    ////this was horribly designed originally, but its actually a good test of 
    ////the new trail system to see if it can handle all of this craziness
    //public class TrailOrderDetailAdd : Trail
    //{
    //    public ordhed TheOrder;
    //    public orddet TheDetail;
    //    public Enums.StockType TheStockType = Enums.StockType.Any;
    //    public partrecord ThePart = null;

    //    public TrailOrderDetailAdd(Context context, ordhed hed)
    //        : base(context, "Order Line Add")
    //    {
    //        TheOrder = hed;

    //        switch (TheOrder.OrderType)
    //        {
    //            case Rz4.Enums.OrderType.Sales:
    //                //if (!TheOrder.onhold && !((ContextNM)context).xUser.IsDeveloper() && !Rz3App.xLogic.IsNTC)
    //                //    StopAdd(new StopAreYouSure(context, this, "continue, even though this order has already been completed"));
    //                //if (TheOrder.ReadyToShip && !((ContextNM)context).xUser.IsDeveloper())
    //                //    StopAdd(new StopAreYouSure(context, this, "continue, even though this order has already been marked 'Ready To Ship'"));
    //                break;
    //            //case Enums.OrderType.Purchase:
    //            //    if (Rz3App.xLogic.IsPhoenix)
    //            //        TheStockType = Rz4.Enums.StockType.Buy;
    //            //    else
    //            //        StopAdd(new StopStockType(context, this));
    //            //    break;
    //        }

    //        //add the actual detail add process
    //        StopAdd(new StopDetailCreate(context, this));

    //        //switch (TheOrder.OrderType)
    //        //{
    //        //    case Enums.OrderType.Purchase:
    //        //        if (!Rz3App.xLogic.IsPhoenix)
    //        //            StopAdd(new StopStockCreate(context, this));
    //        //        break;
    //        //}
    //    }

    //    public override void Finished(Context context)
    //    {
    //       // contextRz.TheLeader.Error("reorg");

    //        //if (TheOrder.OrderDirection == Enums.OrderDirection.Incoming)
    //        //{
    //        //    TheDetail.base_mc_user_uid = TheOrder.orderbuyerid;
    //        //    TheDetail.buyerid = TheOrder.orderbuyerid;
    //        //}
    //        //else
    //        //{
    //        //    TheDetail.base_mc_user_uid = TheOrder.base_mc_user_uid;
    //        //    TheDetail.buyerid = TheOrder.orderbuyerid;
    //        //}
    //        context.Update(TheDetail);
    //        context.Show(new ShowArgsOrder(context, TheDetail, TheOrder.OrderType));
    //    }
    //}
    //public class StopOrderDetailAdd : Stop
    //{
    //    public TrailOrderDetailAdd TheOrderTrail
    //    {
    //        get
    //        {
    //            return (TrailOrderDetailAdd)TheTrail;
    //        }
    //    }

    //    public ordhed TheOrder
    //    {
    //        get
    //        {
    //            return TheOrderTrail.TheOrder;
    //        }
    //    }

    //    public orddet TheDetail
    //    {
    //        get
    //        {
    //            return TheOrderTrail.TheDetail;
    //        }
    //    }

    //    public StopOrderDetailAdd(Context context, Trail t)
    //        : base(context, t)
    //    {
    //    }
    //}
    ////public class StopStockType : StopOrderDetailAdd
    ////{
    ////    public StopStockType(Context context, Trail t)
    ////        : base(context, t)
    ////    {

    ////    }

    ////    public void Answer(Enums.StockType type)
    ////    {
    ////        TheOrderTrail.TheStockType = type;
    ////        Answered = true;
    ////        if (TheOrderTrail.TheStockType == Enums.StockType.Any)
    ////            TheTrail.CanceledIs = true;
    ////    }

    ////    public override bool CompleteIs
    ////    {
    ////        get
    ////        {
    ////            return TheOrderTrail.TheStockType != Enums.StockType.Any;
    ////        }
    ////    }
    ////}
    //public class StopDetailCreate : StopOrderDetailAdd
    //{
    //    public StopDetailCreate(Context context, Trail t)
    //        : base(context, t)
    //    {

    //    }

    //    public override bool CompleteIs
    //    {
    //        get
    //        {
    //            return TheOrderTrail.TheDetail != null;
    //        }
    //    }

    //    public override void Prepare(Context context)
    //    {
    //        base.Prepare(context);
    //        TheOrderTrail.TheDetail = TheOrder.GetNewDetail((ContextRz)context);
    //    }
    //}
    ////public class StopStockCreate : StopOrderDetailAdd
    ////{
    ////    public StopStockCreate(Context context, Trail t)
    ////        : base(context, t)
    ////    {

    ////    }

    ////    public override bool CompleteIs
    ////    {
    ////        get
    ////        {
    ////            return TheOrderTrail.ThePart != null;
    ////        }
    ////    }

    ////    public override void Prepare(Context context)
    ////    {
    ////        base.Prepare(context);

    ////    }

    ////    public void Answer(ContextRz context, partrecord part)
    ////    {
    ////        Answered = true;
    ////        TheOrderTrail.ThePart = part;
    ////        if (TheOrderTrail.ThePart == null)
    ////        {
    ////            TheDetail.IDelete();
    ////            try
    ////            {
    ////                //TheOrder.AllDetails.Remove(TheDetail.unique_id);
    ////                TheOrder.Details.RefsRemove(context, TheDetail);
    ////            }
    ////            catch
    ////            {
    ////            }
    ////            TheTrail.CanceledIs = true;
    ////            return;
    ////        }

    ////    }
    ////}
    //public class TrailOrderTransmit : Trail
    //{
    //    public ordhed TheOrder;
    //    public Enums.TransmitType TheType;

    //    public TrailOrderTransmit(Context context, ordhed hed, Enums.TransmitType type)
    //        : base(context, "Order Transmit")
    //    {
    //        TheOrder = hed;
    //        TheType = type;
    //    }

    //    public override void Finished(Context context)
    //    {
    //        //base.Finished(context);
    //    }
    //}
    //public class StopOrderTransmitShow : Stop
    //{
    //    public StopOrderTransmitShow(Context context, Trail t)
    //        : base(context, t)
    //    {

    //    }
    //}

    public interface IVarRefOrderLines : IVarRefMany
    {
        String DetailClass { get; }
        IItem ByIdGet(Context x, String id);
    }
    public class ShowArgsOrder : ShowArgs
    {
        public Enums.OrderType TheOrderType;
        public string TabName = "";

        public ShowArgsOrder(Context x, IItems items, Enums.OrderType type, string tabName = null)
            : base(x, items)
        {
            TheOrderType = type;
            TabName = tabName;
        }
    }
    public class ListArgsOrder : ListArgs
    {
        public Enums.OrderType TheOrderType = Enums.OrderType.Any;
        public ListArgsOrder(ContextNM context, Enums.OrderType t) : base(context)
        {
            TheOrderType = t;
        }

        public override ActSetup ActSetupCreate()
        {
            return new ActSetupOrder(TheOrderType);
        }
    }
    public class ActSetupOrder : ActSetup
    {
        public Enums.OrderType TheOrderType;

        public ActSetupOrder(Enums.OrderType t)
        {
            TheOrderType = t;
        }
    }
    public class OrderCompanyVar : VarRefFieldPlusName<ordhed, company>
    {
        public OrderCompanyVar(ordhed o)
            : base(o, new CoreVarRefSingleAttribute("Company", "Rz4.ordhed", "Rz4.company", "", "base_company_uid"), "companyname", "companyname")
        {
        }

        ordhed TheOrder
        {
            get
            {
                return (ordhed)Parent;
            }
        }

        public override void RefSet(Context x, company value, bool includeReverse)
        {
            base.RefSet(x, value, includeReverse);

            TheOrder.CompanyRefSet((ContextRz)x, value);

            foreach (orddet l in TheOrder.DetailsList((ContextRz)x))
            {
                l.CompanyRefSet((ContextRz)x, value, TheOrder.OrderType);
            }
        }

        public override void RefsRemoveAll(Context x)
        {
            base.RefsRemoveAll(x);

            foreach (orddet l in TheOrder.DetailsList((ContextRz)x))
            {
                l.CompanyRefSet((ContextRz)x, null, TheOrder.OrderType);
            }
        }
    }
    public class OrderContactVar : VarRefFieldPlusName<ordhed, companycontact>
    {
        public OrderContactVar(ordhed o)
            : base(o, new CoreVarRefSingleAttribute("Contact", "Rz4.ordhed", "Rz4.companycontact", "", "base_companycontact_uid"), "contactname", "contactname")
        {
        }

        ordhed TheOrder
        {
            get
            {
                return (ordhed)Parent;  //TheItem
            }
        }

        public override void RefSet(Context x, companycontact value, bool includeReverse)
        {
            base.RefSet(x, value, includeReverse);

            foreach (orddet l in TheOrder.DetailsList((ContextRz)x))
            {
                l.ContactRefSet((ContextRz)x, value, TheOrder.OrderType);
            }
        }

        public override void RefsRemoveAll(Context x)
        {
            base.RefsRemoveAll(x);

            foreach (orddet l in TheOrder.DetailsList((ContextRz)x))
            {
                l.ContactRefSet((ContextRz)x, null, TheOrder.OrderType);
            }
        }
    }
    public class OrderAgentVar : VarRefFieldPlusName<ordhed, n_user>
    {
        public OrderAgentVar(ordhed o)
            : base(o, new CoreVarRefSingleAttribute("Agent", "Rz4.ordhed", "Rz4.n_user", "", "base_mc_user_uid"), "name", "agentname")
        {
        }

        ordhed TheOrder
        {
            get
            {
                return (ordhed)Parent;
            }
        }

        public override void RefSet(Context x, n_user value, bool includeReverse)
        {
            base.RefSet(x, value, includeReverse);

            foreach (orddet l in TheOrder.DetailsList((ContextRz)x))
            {
                l.AgentRefSet((ContextRz)x, value, TheOrder.OrderType);
            }
        }

        public override void RefsRemoveAll(Context x)
        {
            base.RefsRemoveAll(x);

            foreach (orddet l in TheOrder.DetailsList((ContextRz)x))
            {
                l.AgentRefSet((ContextRz)x, null, TheOrder.OrderType);
            }
        }
    }
}