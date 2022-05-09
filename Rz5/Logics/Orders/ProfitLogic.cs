using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Rz5.Reports;
using Core;
using NewMethod;
using Tools.Database;
using System.Data;

namespace Rz5
{
    public class ProfitLogic : NewMethod.Logic
    {
        public virtual void ProfitReportShow(Context x, ActArgs args)
        {
            ProfitReportShow((ContextRz)x);
            args.Result(true);
        }
        public virtual void ProfitReportShow(ContextRz context)
        {
            if (!CanViewProfitReport(context))
            {
                context.TheLeader.ShowNoRight();
                return;
            }
            context.TheLeaderRz.ReportShow(context, ProfitReportCreate(context), false);
        }
        public virtual void SalesForecastShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            xrz.TheLeaderRz.ReportShow(xrz, new SalesForecast(xrz), false);
        }
        public virtual void SalesLineReportShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            xrz.TheLeaderRz.ReportShow(xrz, new SalesLineReport(xrz), false);
        }
        protected virtual bool CanViewProfitReport(ContextRz context)
        {
            return context.xUser.CheckPermit(context, "Sales:Profit:ViewProfitReport");
        }
        //public virtual bool CommissionReportShow(ContextRz context)
        //{
        //    Reports.CommissionReport r = new Reports.CommissionReport(context);
        //    context.TheLeaderRz.ReportShow(context, r, false);
        //    return true;
        //}
        public bool CommissionReportShow(ContextRz context)
        {
            CommissionReport r = new CommissionReport(context);
            context.TheLeaderRz.ReportShow(context, r, false);
            return true;
        }
        //KT
        public override void ActInstance(Context x, ActArgs args)
        {
            ArrayList deductions = new ArrayList();
            foreach (IItem i in args.TheItems.AllGet(x))
            {
                deductions.Add((profit_deduction)i);
            }
            args.Handled = true;
            base.ActInstance(x, args);
        }



        //KT Original GetBogey
        public virtual double GetBogey(ContextRz context, string UserID)
        {
            if (context == null)
                return 0;
            if (!Tools.Strings.StrExt(UserID))
                return 0;
            n_user u = n_user.GetById(context, UserID);
            if (u != null)
                if (u.commission_bogey > 0 && u.commission_bogey != null)
                    return u.commission_bogey;
                else return 0;
            else
                return 0;
        }






        //KT Action List Handlers for lvDeductions on ViewHeaderSales.
        public virtual void ActsListInstanceDeductions(Context context, ActSetup m)
        {
            //m.Clear();
            ContextRz xrz = (ContextRz)context;
            if (xrz.xUser.CheckPermit(xrz, "permit_ManageDeductions", true))
            {
                m.Add("Delete");
            }


        }


        //KT 11-4-2015 - Simpler methods fro credits and charges // Note, DOES NOT TAKE DEDUCT PROFIT into account
        public virtual double GetOrderCredits(ContextRz context, string InvoiceID)
        {
            double credits = 0;
            credits = context.SelectScalarDouble("select SUM(hit_amount) from ordhit where is_credit = 1 and the_ordhed_uid  = '" + InvoiceID + "'");
            //credits += GetAssignedCompanyCredits(context, new List<string>() { InvoiceID });
            return credits;
        }





        //public n_user SetSplitCommissionForObject(ContextRz x, object o, n_user SplitAgent, string SplitCommissionType)
        //{
        //    //2020 Rules.  Compay Owners will always be the "Agent" on orders
        //    //Split agents will always be someone other than the Company owner / order owner
        //    company c = GetCompanyForSplitObject(x, o);
        //    if (c == null)
        //        return null;
        //    //throw new Exception("Could not locate a company associated wtih object: " + o.ToString());
        //    n_user companyAgent = n_user.GetById(x, c.base_mc_user_uid);
        //    ////Confirm that the company agent isn't already the split agent.
        //    //if (companyAgent != null)
        //    //    if (companyAgent == SplitAgent)
        //    //        return null;

        //    //Pass string variables to the DB update Method.          
        //    if (SplitAgent == null)//Clear Split Commission
        //        UpdateSplitCommissionRzObject(x, o, "", "", "");
        //    else //Set Split Commission
        //        UpdateSplitCommissionRzObject(x, o, SplitAgent.name, SplitAgent.unique_id, SplitCommissionType);
        //    return SplitAgent;

        //}

        //public n_user SetSplitCommissionForObject(ContextRz x, object o)
        //{
        //    n_user SplitAgent = null;
        //    int splitCommissionAmount = 0;
        //    //2020 Rules.  Compay Owners will always be the "Agent" on orders
        //    //Split agents will always be someone other than the Company owner / order owner
        //    company c = GetCompanyForSplitObject(x, o);
        //    if (c == null)
        //        return null;
        //    //throw new Exception("Could not locate a company associated wtih object: " + o.ToString());
        //    n_user companyAgent = n_user.GetById(x, c.base_mc_user_uid);
        //    ////Confirm that the company agent isn't already the split agent.
        //    //if (companyAgent != null)
        //    //    if (companyAgent == SplitAgent)
        //    //        return null;

        //    //Pass string variables to the DB update Method.          
        //    if (SplitAgent == null)//Clear Split Commission
        //        //UpdateSplitCommissionRzObject(x, o, "", "", "");
        //        UpdateSplitCommissionRzObject(x, null);
        //    else //Set Split Commission
        //        UpdateSplitCommissionRzObject(x, o);
        //    return SplitAgent;

        //}

        //public void SetSplitCommissionForObject(ContextRz x, object o)
        //{
        //    n_user SplitAgent = null;
        //    int splitCommissionAmount = 0;
        //    //2020 Rules.  Compay Owners will always be the "Agent" on orders
        //    //Split agents will always be someone other than the Company owner / order owner
        //    company c = GetCompanyForSplitObject(x, o);
        //    if (c == null)
        //        return null;
        //    //throw new Exception("Could not locate a company associated wtih object: " + o.ToString());
        //    n_user companyAgent = n_user.GetById(x, c.base_mc_user_uid);
        //    ////Confirm that the company agent isn't already the split agent.
        //    //if (companyAgent != null)
        //    //    if (companyAgent == SplitAgent)
        //    //        return null;

        //    //Pass string variables to the DB update Method.          
        //    if (SplitAgent == null)//Clear Split Commission
        //        //UpdateSplitCommissionRzObject(x, o, "", "", "");
        //        UpdateSplitCommissionRzObject(x, null);
        //    else //Set Split Commission
        //        UpdateSplitCommissionRzObject(x, o);
        //    return SplitAgent;

        //}

        //private company GetCompanyForSplitObject(ContextRz x, object o)
        //{
        //    company ret = null;
        //    if (o is company)
        //        ret = (company)o;


        //    else if (o is dealheader)
        //    {
        //        dealheader d = (dealheader)o;
        //        ret = company.GetById(x, d.customer_uid);
        //    }
        //    else if (o is orddet_quote)
        //    {
        //        orddet_quote q = (orddet_quote)o;
        //        ret = company.GetById(x, q.base_company_uid);
        //    }
        //    else if (o is orddet_line)
        //    {
        //        orddet_line l = (orddet_line)o;
        //        ret = company.GetById(x, l.customer_uid);
        //    }

        //    return ret;
        //}

        //public n_user SetSplitCommissionForObject(ContextRz x, object o, n_user CompanySplitCommissionAgent, n_user ExistingSplitCommissionAgent, string SplitCommissionType)
        //{
        //    //Make string variables to avoid null refs
        //    string strSplitCommissionAgentName = "";
        //    string strSplitCommissionAgentUid = "";
        //    string strSplitCommissionType = "";
        //    if (!string.IsNullOrEmpty(SplitCommissionType))
        //        strSplitCommissionType = SplitCommissionType;
        //    n_user SplitCommissionAgent = null;


        //    //If both are null, we are clearing, pass empty strings and return.
        //    if (CompanySplitCommissionAgent == null && ExistingSplitCommissionAgent == null)
        //    {
        //        UpdateSplitCommissionRzObject(x, o, "", "", "");
        //        return null;
        //    }

        //    //If we have no existing agent, assign the NewSplitCommissionAgent
        //    if (ExistingSplitCommissionAgent == null)
        //        SplitCommissionAgent = CompanySplitCommissionAgent;
        //    else
        //    {
        //        //We have an existing Split Agent, check to see if it's changing and alert user if changing the split agent.
        //        bool changingSplitAgent = CompanySplitCommissionAgent.unique_id != ExistingSplitCommissionAgent.unique_id;
        //        if (changingSplitAgent)
        //        {
        //            //If change detected, confirm with user.
        //            if (x.Leader.AskYesNo("Are you sure you want to replace " + ExistingSplitCommissionAgent.Name + " with new split agent " + NewSplitCommissionAgent.Name + "?"))
        //                SplitCommissionAgent = CompanySplitCommissionAgent;
        //            else
        //                SplitCommissionAgent = ExistingSplitCommissionAgent;
        //        }
        //        else//If not changing, i.e. it's the same user, just return            
        //            SplitCommissionAgent = ExistingSplitCommissionAgent;
        //    }





        //    //Validate that we have a Split Agent and viable Split Type.
        //    if (SplitCommissionAgent != null)
        //    {
        //        strSplitCommissionAgentName = SplitCommissionAgent.name;
        //        strSplitCommissionAgentUid = SplitCommissionAgent.unique_id;

        //        //If we have an agent, but not type, alert user and about.
        //        if (string.IsNullOrEmpty(SplitCommissionType))
        //        {
        //            x.Leader.Error("Please select the appropriate split commission type.");
        //            return null;
        //        }
        //    }


        //    //Pass string variables to the DB update Method.            
        //    UpdateSplitCommissionRzObject(x, o, strSplitCommissionAgentName, strSplitCommissionAgentUid, strSplitCommissionType);
        //    return SplitCommissionAgent;


        //}

        //private void UpdateSplitCommissionRzObject(ContextRz x, object o, string strSplitCommissionAgentName, string strSplitCommissionAgentUid, string strSplitCommissionType)
        //{
        //    if (o is company)
        //    {
        //        company c = o as company;
        //        c.split_commission_agent_uid = strSplitCommissionAgentUid;
        //        c.split_commission_agent_name = strSplitCommissionAgentName;
        //        c.split_commission_default_type = strSplitCommissionType;
        //        if (string.IsNullOrEmpty(strSplitCommissionAgentUid))//If we don't have an agent at this point, also clear the date.
        //            c.split_commission_date_active = new DateTime(1900, 01, 01);
        //        else if (c.split_commission_date_active <= new DateTime(1902, 01, 01))
        //            c.split_commission_date_active = DateTime.Now;
        //        c.Update(x);
        //    }
        //    else if (o is orddet_quote)
        //    {
        //        orddet_quote q = o as orddet_quote;
        //        q.split_commission_agent_uid = strSplitCommissionAgentUid;
        //        q.split_commission_agent_name = strSplitCommissionAgentName;
        //        q.split_commission_type = strSplitCommissionType;
        //        q.Update(x);
        //    }
        //    else if (o is orddet_line)
        //    {
        //        orddet_line l = o as orddet_line;
        //        l.split_commission_agent_uid = strSplitCommissionAgentUid;
        //        l.split_commission_agent_name = strSplitCommissionAgentName;
        //        l.split_commission_type = strSplitCommissionType;
        //        l.Update(x);
        //    }
        //    else if (o is dealheader)
        //    {
        //        dealheader d = o as dealheader;
        //        d.split_commission_agent_uid = strSplitCommissionAgentUid;
        //        d.split_commission_agent_name = strSplitCommissionAgentName;
        //        d.split_commission_type = strSplitCommissionType;
        //        d.Update(x);
        //    }
        //}

        private void UpdateSplitCommissionRzObject(ContextRz x, object o)
        {
            //Clear split if o is null
            if (o == null)
            {

            }


            string strSplitCommissionAgentName = null;
            string strSplitCommissionAgentUid = null;
            int intSplitCommissionPercent = 0;

            if (o is company)
            {

                company c = o as company;
                split_commission cs = new split_commission();
                cs.base_company_uid = ((company)o).unique_id;

                if (string.IsNullOrEmpty(strSplitCommissionAgentUid))//If we don't have an agent at this point, also clear the date.
                    c.split_commission_date_active = new DateTime(1900, 01, 01);
                else if (c.split_commission_date_active <= new DateTime(1902, 01, 01))
                    c.split_commission_date_active = DateTime.Now;
                c.Update(x);
            }
            else if (o is orddet_quote)
            {
                orddet_quote q = o as orddet_quote;
                q.Update(x);
            }
            else if (o is orddet_line)
            {
                orddet_line l = o as orddet_line;
                l.Update(x);
            }
            else if (o is dealheader)
            {
                dealheader d = o as dealheader;
                d.Update(x);
            }
        }




        public virtual double GetOrderCredits(ContextRz context, List<string> invoiceIDs)
        {
            double credits = 0;
            //Get List of all valid invoice ID's for user in time period, sum up all the ordhits related to them.          
            //credits = context.SelectScalarDouble("select SUM(hit_amount) from ordhit where is_credit = 1 and the_ordhed_uid IN(" + Tools.Data.GetIn(invoiceIDs) + "'");
            credits = context.SelectScalarDouble("select SUM(hit_amount) from ordhit where is_credit = 1 AND the_ordhed_uid IN (" + Tools.Data.GetIn(invoiceIDs) + ")");
            //credits += GetAssignedCompanyCredits(context, invoiceIDs);
            return credits;
        }

        public void SetSplitCommissionForOrderLines(ContextRz x, object currentObject, string split_commission_id)
        {
            int changed = 0;
            split_commission sc = split_commission.GetById(x, split_commission_id);
            if (currentObject is ordhed_quote)
            {
                foreach (orddet_quote q in ((ordhed_quote)currentObject).DetailsList(x))
                {
                    if (!string.IsNullOrEmpty(q.split_commission_ID))
                        continue;
                    q.split_commission_ID = split_commission_id;
                    q.Update(x);
                    changed++;
                }

            }
            else if (currentObject is ordhed)
            {
                foreach (orddet_line l in ((ordhed)currentObject).DetailsList(x))
                {
                    if (!string.IsNullOrEmpty(l.split_commission_ID))
                        continue;
                    l.split_commission_ID = split_commission_id;
                    l.Update(x);
                    changed++;
                }
            }
            if (changed > 0)
                x.Leader.Tell("Set split commission on " + changed + " lines.");
        }



        public virtual double GetAssignedCompanyCredits(ContextRz context, List<string> invoiceIDs)
        {
            double ret = 0;
            ret += context.SelectScalarDouble("select SUM(creditamount) from companycredit where applied_to_order_uid IN (" + Tools.Data.GetIn(invoiceIDs) + ")" + "AND credit_type= 'customer_credit'");
            return ret;
        }

        public virtual ArrayList GetInvoiceCreditsList(ContextRz context, string InvoiceID)
        {
            ArrayList ret = context.QtC("ordhit", "select * from ordhit where is_credit = 1 and the_ordhed_uid  = '" + InvoiceID + "'");
            return ret;
        }

        //KT 11-4-2015 - Simpler methods fro credits and charges // Note, DOES NOT TAKE DEDUCT PROFIT into account
        public virtual double GetOrderCharges(ContextRz context, string InvoiceID)
        {
            double charges = 0;
            charges = context.SelectScalarDouble("select SUM(hit_amount) from ordhit where is_credit != 1 and the_ordhed_uid = '" + InvoiceID + "'");
            return charges;
        }
        public virtual ArrayList GetInvoiceChargesList(ContextRz context, string InvoiceID)
        {
            ArrayList ret = context.QtC("ordhit", "select * from ordhit where is_credit != 1 and the_ordhed_uid  = '" + InvoiceID + "'");
            return ret;
        }

        //KT Gather RMA's related to Invoice
        public virtual double GetTotalRMACostForInvoice(ContextRz context, string InvoiceID)
        {
            double RMAs = 0;
            RMAs = context.SelectScalarDouble("select SUM(ordertotal) from ordhed_rma where unique_id IN(select orderid_rma from orddet_line where orderid_invoice = '" + InvoiceID + "')");
            return RMAs;
        }

        public virtual double GetRefundPayments(ContextRz context, string InvoiceID)
        {
            //KT - 8-29-2015 - NEed keep working this, this throws off the balance, but makes the "credits" correct.
            double refund_payments = 0;
            refund_payments = context.SelectScalarDouble("select SUM(transamount) from checkpayment where  transamount < 0 and base_ordhed_uid  = '" + InvoiceID + "'");
            //end
            return refund_payments;
        }

        public double calc_TotalNetCommission(ContextRz x, DataTable dtCommissionData, double Bogey, double invoiceCredits, string userID, double payrollDeductions)//)
        {

            double ret = 0;
            if (dtCommissionData == null)
                return 0;

            //In order to subtract Payroll deductions from Net PRofit 1st, rather than at the end, I need to basically add it to the bogey, and satisfy that before paying out.
            Bogey += payrollDeductions;
            //Debug Test
            //Bogey = 0;
            //Query is orderbydescendign by comm percent, so higher comm pecent lines get set against bogey 1st.
            var query = dtCommissionData.AsEnumerable().Select(data => new { NetProfit = data.Field<double>(0), CommPercent = data.Field<double>(1), lineUID = data.Field<string>(2) }).OrderByDescending(o => o.CommPercent);
            foreach (var v in query)
            {
                //As of 5-9-2019, am simply dividing the overall commissoin by half as a "Spli"
                //Another option would be to us the "current" user permissoni, but I think that is simplistic, and ignored the invoice-level override capabilites, etc.
                //What if, on split, we determine the higher percentage (i.e. 12) and both users get half of that?
                double commission_percent = v.CommPercent;
                //if (!string.IsNullOrEmpty(v.SplitCommissionAgentUID))
                //    commission_percent = GetSplitCommission(x, v.lineUID, commission_percent);


                if (Bogey < 0)
                    Bogey = 0;
                if (Bogey > 0)
                    Bogey = Bogey - v.NetProfit;
                if (Bogey < 0)
                    ret += (Bogey * -1) * commission_percent; // if bogey falls less than zero, that amount is commissionable, need to add it
                if (Bogey == 0)
                    ret += (v.NetProfit * commission_percent);

            }
            //KT Added on 4-11-2017 - Commission Report was calcing this credit for EVERY Line.  Find for single line orders, VERY WRONG for all else, especially Kazle's 35 line order! :P
            //Now passing in the user's currentl commissing percent as set in Rz -> Users.  Not botherinf with differentiating if the invoice had both stock and buy lines.   

            //Buy commissing percent is default and always used to subtract out invoice credits from the percentage
            double userCommissionRate = x.SelectScalarDouble("select commission_percent from n_user where unique_id = '" + userID + "'");
            if (invoiceCredits > 0)
                ret -= (invoiceCredits * userCommissionRate);

            return ret;
        }
        //internal double GetSplitCommission(ContextRz x, string lineUID, string lineSellerUID, string splitAgentUID)
        //{
        //    //WTF, have to use decimals, not doubles.  Since Double is a floating point thing, the result of .15 - .5 is 0.049999999999999989?????
        //    n_user lineOwner = n_user.GetById(x, lineSellerUID);
        //    n_user splitAgent = n_user.GetById(x, splitAgentUID);
        //    orddet_line l = orddet_line.GetById(x, lineUID);
        //    decimal splitAgentPercent = .05m;
        //    if (l.split_commission_type.ToLower() == SM_Enums.SplitCommissionType.design_split.ToString())
        //        splitAgentPercent = .1m;
        //    decimal lineOwnerSplitPercent = .15m - splitAgentPercent;//Standard Split
        //    if (lineSellerUID == splitAgentUID)//This is the split agent we're calculating
        //        return Convert.ToDouble(splitAgentPercent);
        //    else
        //        return
        //            Convert.ToDouble(lineOwnerSplitPercent);
        //}




        internal double GetStandardSplitCommission(ContextRz x, DataRow dr)
        {
            string lineUID = nData.NullFilter_String(dr["unique_id"]);
            orddet_line l = orddet_line.GetById(x, lineUID);
            string split_commissionID = l.split_commission_ID ?? "";
            //string seller_id = l.seller_uid;



            //string split_type = l.split_commission_type;
            //If both split and list aquisition, since list acq is 3%, split percent wins at 5%?
            //if (!string.IsNullOrEmpty(l.split_commission_agent_uid))
            //    return GetSplitCommissionPercentage(x, l, lineCommission, dr);
            //if (!string.IsNullOrEmpty(l.list_acquisition_agent_uid))
            //    return GetListAcquisitionCommissionPercentage(x, l, lineCommission, dr, sectionUserID);
            // else 
            //if (string.IsNullOrEmpty(split_commissionID))
            //    return 0;
            split_commission sc = split_commission.GetById(x, split_commissionID);
            if (sc == null)
                return 0;
            return sc.split_commission_percent;


            //double splitPercent = 0;
            //bool isSplit = false;
            //if (sc.split_commission_agent_id == sectionUserID)
            //    isSplit = true;

            //splitPercent = sc.split_commission_percent;
            //double ret = 0;
            ////if (isSplit)
            //ret = splitPercent;
            ////else
            ////    ret = lineCommission - splitPercent;
            ////return lineCommission;
            //return ret;

        }

        public double GetListAcquisitionSplitPercentage(ContextRz x, DataRow dr)
        {

            //decimal list_acquisition_agent_percent = .03m;
            //decimal original_seller_percent = Convert.ToDecimal(lineCommission);
            //decimal new_seller_percent = original_seller_percent - list_acquisition_agent_percent;

            string seller_uid = nData.NullFilter_String(dr["base_mc_user_uid"]);
            string list_acquisition_uid = nData.NullFilter_String(dr["list_acquisition_agent_uid"]);

            if (!string.IsNullOrEmpty(list_acquisition_uid))
                if (seller_uid != list_acquisition_uid)
                    return .03;
            //string list_agent_name = nData.NullFilter_String(dr["list_acquisition_agent"]);
            //string seller_uid = nData.NullFilter_String(dr["base_mc_user_uid"]);
            //string seller_name = nData.NullFilter_String(dr["agentName"]);
            ////THe same info will be passed here twice, once with the actual seller as the agent, and again with the list_agent as the agent.
            ////We're overwriting this value in the pevious buld of the datatable so we can differentiate wihcih commissing percent.
            ////since sometime we'll have a line marked as list asquisition, and it'll be sold by the same person which means it should be full commission, then comparing names won't work. 
            ////bool isListAgentRow = nData.NullFilter_String(dr["split_commission_type"]) == "list_agent_row";
            ////if the sellerUID == tColumnHeader split ID then this is the SPLIT agent, calculate accordingly
            ////IF seller == lsit agent, then that means this is NOT A split
            //if (seller_uid == list_acquisition_uid)
            //    return Convert.ToDouble(original_seller_percent);
            //else
            //{
            //    if (sectionUserID != seller_uid)
            //    //    return Convert.ToDouble(new_seller_percent);
            //    //else if (sectionUserID == list_acquisition_uid)
            //        return Convert.ToDouble(list_acquisition_agent_percent);
            //}


            return 0;

        }


        public virtual DataTable GetPayRollDeductionDataTable(ContextRz context, DateTime start, DateTime end, CommissionReportArgs argsx)
        {
            string sql = "select l.customer_name, l.customer_uid, l.ordernumber_sales, l.orderid_sales, l.ordernumber_invoice, l.orderid_invoice, l.seller_uid, l.seller_name, p.date_created, p.name, p.description, p.amount from profit_deduction p inner join orddet_line l on p.the_orddet_line_uid = l.unique_id where is_payroll_deduction = 1 and p.payroll_deduction_date BETWEEN '" + start + "' AND '" + end + "'";
            List<string> agentIds = argsx.Agent.AgentIds;
            if (agentIds.Count > 0)
                sql += " and seller_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " )";
            //if (argsx.Agent.Exists())
            //    sql += " and seller_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " )";
            DataTable ret = context.Data.Select(sql);
            return ret;
        }



        public virtual ArrayList GetCanceledLinesSales(ContextRz x, string orderid_sales)
        {
            return x.QtC("orddet_line", "select * from orddet_line_canceled where orderid_sales = '" + orderid_sales + "'");
        }


        public virtual ArrayList GetCanceledLinesPurchase(ContextRz x, string orderid_purchase)
        {
            return x.QtC("orddet_line", "select * from orddet_line_canceled where orderid_purchase = '" + orderid_purchase + "'");
        }

        public virtual CommissionReportSectionUser GetCommissionReportSectionUser(ContextRz context, string user_id, string user_name, DateTime start_date, DateTime end_date)
        {
            return new CommissionReportSectionUser(context, user_id, user_name, start_date, end_date);
        }

        public virtual Report ProfitReportCreate(ContextRz context)
        {
            //return new ProfitReport(context);
            return new ProfitReportSensible(context);
        }

        public List<profit_deduction> GetDeductionsForOrder(ContextRz x, ordhed_sales ordhed_sale)
        {
            //These can be either:
            //Deductions on the line
            //Deductions on a canceled line
            //Service Lines related to the lines
            //Service Lines related to the canceled lines.

            List<profit_deduction> ret = new List<profit_deduction>();


            //Standard Deductions
            //List<profit_deduction> standardDeductions = new List<profit_deduction>();
            foreach (orddet_line l in ordhed_sale.DetailsList(x))
                foreach (profit_deduction d in l.DeductionsVar.RefsList(x))
                {
                    ret.Add(d);
                }
            //Canceled Deductions
            ArrayList canceledSalesDeductions = GetCanceledDeductions(x, ordhed_sale);
            foreach (profit_deduction pc in canceledSalesDeductions)
            {
                if (!ret.Contains(pc))
                    ret.Add(pc);
            }

            //standard and canceled service lines
            List<profit_deduction> serviceDeductions = GetServiceDeductionsForOrder(x, canceledSalesDeductions, ordhed_sale);
            foreach (profit_deduction ps in serviceDeductions)
            {
                if (!ret.Contains(ps))
                    ret.Add(ps);
            }
            return ret;
        }

        private List<profit_deduction> GetServiceDeductionsForOrder(ContextRz x, ArrayList canceledSalesDeductions, ordhed_sales ordhed_sale)
        {
            //Get Service lines, then conver them to profit deduction.
            List<profit_deduction> ret = new List<profit_deduction>();
            List<orddet_line> lineList = ordhed_sale.DetailsList(x).Cast<orddet_line>().ToList();
            List<orddet_line> canceledLineLine = GetCanceledLinesSales(x, ordhed_sale.unique_id).Cast<orddet_line>().ToList();


            foreach (orddet_line l in lineList)
            {

                //Service Costs
                if (l.service_cost > 0)
                {
                    profit_deduction pdSvc = ConvertServiceLineToProfitDeduction(x, l);
                    if (pdSvc != null)
                        if (!ret.Contains(pdSvc))
                            ret.Add(pdSvc);
                }

                //Only Canceled GCATS get treated as deductions.
            }

            foreach (orddet_line l in canceledLineLine)
            {

                // Canceled Service Costs
                if (l.service_cost > 0)
                {
                    profit_deduction pdSvc = ConvertServiceLineToProfitDeduction(x, l, true);
                    if (pdSvc != null)
                        if (!ret.Contains(pdSvc))
                            ret.Add(pdSvc);
                }

                //Gcat Costs for canceled lines ONLY, else their cost is already on the line item.
                if (l.fullpartnumber.ToLower().Contains("gcat"))
                {
                    profit_deduction pdGcat = ConvertGcatCostToProfitDeduction(x, l);
                    if (pdGcat != null)
                        if (!ret.Contains(pdGcat))
                            ret.Add(pdGcat);

                }


            }


            return ret;
        }

        private profit_deduction ConvertServiceLineToProfitDeduction(ContextRz x, orddet_line l, bool canceledLine = false)
        {
            profit_deduction pd = new profit_deduction();
            pd.unique_id = l.unique_id; //We are setting this uid to the lines ID fro 2 reasons.  1) nList requires items to have a uid, these wouldn't have one. 2) I'll use this id to remove service cost from the proper canceled line.
            pd.name = l.fullpartnumber;
            if (canceledLine)
                pd.name = "<canceled> " + pd.name;
            pd.amount = l.service_cost;
            pd.date_created = l.date_created;
            pd.description = "service line";
            pd.linecode_sales = l.linecode_sales;
            pd.linecode_purchase = l.linecode_purchase;

            return pd;

        }

        private profit_deduction ConvertGcatCostToProfitDeduction(ContextRz x, orddet_line l, bool canceledLine = false)
        {
            profit_deduction pd = new profit_deduction();
            //pd.unique_id = Guid.NewGuid().ToString();
            pd.unique_id = l.unique_id; //We are setting this uid to the lines ID fro 2 reasons.  1) nList requires items to have a uid, these wouldn't have one. 2) I'll use this id to remove service cost from the proper canceled line.
            pd.name = l.fullpartnumber;
            if (canceledLine)
                pd.name = "<canceled> " + pd.name;
            pd.amount = l.total_cost;
            pd.date_created = l.date_created;
            pd.description = "gcat line";
            pd.linecode_sales = l.linecode_sales;
            pd.linecode_purchase = l.linecode_purchase;

            return pd;


        }

        public virtual ArrayList GetCanceledDeductions(ContextRz x, ordhed o)
        {


            string strOrderIdType = null;
            ArrayList CanceledLines = null;

            //if (string.IsNullOrEmpty(strOrderIdType))
            //    return null;
            switch (o.OrderType)
            {
                case Enums.OrderType.Sales:
                    CanceledLines = GetCanceledLinesSales(x, o.unique_id);
                    break;
                case Enums.OrderType.Purchase:
                    CanceledLines = GetCanceledLinesPurchase(x, o.unique_id);
                    break;
                default:
                    {
                        return null;
                    }

            }

            ArrayList ret = new ArrayList();
            string strOrderType = "sales_order_uid";
            switch (o.OrderType)
            {
                case Enums.OrderType.Purchase:
                    strOrderType = "purchase_order_uid";
                    break;
                default:
                    strOrderType = "sales_order_uid";
                    break;
            }
            foreach (orddet_line l in CanceledLines)
            {

                var v = x.QtC("profit_deduction", "select * from profit_deduction where the_orddet_line_uid = '" + l.unique_id + "'");
                foreach (profit_deduction p in v)
                {
                    p.name = "<canceled>" + p.name;
                    ret.Add(p);
                }

            }


            return ret;


            //return x.QtC("profit_deduction", "select * from profit_deduction where the_orddet_line_uid in (select unique_id_canceled from orddet_line_canceled where orderid_sales = '" + orderid_sales + "')");
            //return x.QtC("profit_deduction", "select * from profit_deduction where " + strOrderIdType + "  = '" + unique_id + "'");
        }
    }




    public class ProfitReportArgs : ReportArgs, IDisposable
    {
        public List<String> UserIds = new List<String>();

        public ReportCriteriaDateRange DateRange;
        public ReportCriteriaAgent Agent;
        public bool SalesMode = false;
        public DataConnectionSqlServer xData;
        public bool OnlyTotals = false;
        public bool IncludeChartLinks = false;
        public bool CacheOnly = false;
        public bool TotalsOnly = false;
        public List<String> LimitToLineIds = new List<String>();
        //public bool DropTables = true;

        public ProfitReportArgs(ContextRz context)
            : base(context)
        {
            DateRange = new ReportCriteriaDateRange("Ship Date");
            DateRange.AllowFuture = false;
            DateRange.IncludeDayOptions = false;
            DateRange.DefaultOption = "This Month";
            Criteria.Add(DateRange);
            Agent = new ReportCriteriaAgent("Agent");
            Criteria.Add(Agent);
        }

        public virtual void Dispose()
        {
            try
            {
                xData = null;
                UserIds.Clear();
                UserIds = null;
                DateRange = null;
            }
            catch { }
        }



        public override bool ValidCheck(Context context)
        {
            if (!base.ValidCheck(context))
                return false;

            if (!ValidCheckUser((ContextRz)context))
                return false;

            if (!DateRange.TheRange.Valid)
            {
                context.TheLeader.Error("Please select a valid start date before continuing.");
                return false;
            }

            return true;
        }

        protected virtual bool ValidCheckUser(ContextRz context)
        {
            //if (UserIds.Count <= 0 && !context.xUser.SuperUser)
            //{
            //    context.TheLeader.ShowNoRight();
            //    return false;
            //}
            return true;
        }

    }





    public class ProfitReportSensible : Rz5.Report, IDisposable
    {
        //Public Variables
        public ProfitReportArgs CurrentArgs;
        public ReportTotal TotalProfit;
        public ReportTotal TotalVolume;
        public ReportTotalPercent TotalMargin;
        public ReportTotalPercent NetPercent;
        public ReportTotal TotalSales = new ReportTotal("");
        public ReportTotal TotalCost = new ReportTotal("");
        public ReportTotal TotalGP = new ReportTotal("");
        public ReportTotal TotalNP = new ReportTotal("");
        public String ReportKey;
        public String StaticFinalTable = "";
        public bool trackmarks = Tools.Misc.IsDevelopmentMachine();

        public ProfitReportSensible(ContextRz x)
            : base(x)
        {

        }
        //Public Static Functions
        public static String GetReportAsHTML(ContextRz context, ProfitReportArgs args)
        {
            ProfitReport CurrentCore = new ProfitReport(context);
            CurrentCore.Calculate(context, args);
            ReportTargetHtml t = new ReportTargetHtml(false);
            t.Render(context, CurrentCore);
            CurrentCore.InitUn(context);
            CurrentCore.Dispose();
            return t.HtmlResult;
        }
        //Public Override Functions



        public override void Dispose()
        {
            try
            {
                if (CurrentArgs != null)
                {
                    CurrentArgs.Dispose();
                    CurrentArgs = null;
                }
            }
            catch
            {
            }
        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
            CurrentArgs = (ProfitReportArgs)args;
            base.CalculateLines(context, args);
            List<orddet_line> lines = OrderLinesSelect((ContextRz)context);
            foreach (orddet_line l in lines)
            {
                LineAdd((ContextRz)context, l);
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            return new ProfitReportArgs((ContextRz)context);
        }
        public override string Title
        {
            get
            {
                return "Profit Report";
            }
        }
        //Public Functions
        public void InitUn(ContextRz context)
        {
            //DropReportTables(context);
        }
        //Protected Virtual Functions
        protected override void InitColumns(Context context)
        {
            Columns = new Dictionary<string, ReportColumn>();
            ColumnAdd(new ReportColumn("Agent"));
            ColumnAdd(new ReportColumn("Invoice"));
            ColumnAdd(new ReportColumn("Date"));
            ColumnAdd(new ReportColumn("Customer"));
            ColumnAdd(new ReportColumn("Vendor"));
            ColumnAdd(new ReportColumn("Part"));
            ColumnAdd(new ReportColumn("Price", ValueUse.TotalMoney));
            ColumnAdd(new ReportColumn("Cost", ValueUse.TotalMoney));
            ColumnAdd(new ReportColumn("Profit", ValueUse.TotalMoney));
            ColumnAdd(new ReportColumn("Total Margin", ValueUse.Percentage));
            ColumnAdd(new ReportColumn("Net Percent", ValueUse.Percentage));
            ColumnAdd(new ReportColumn("Sales"));
        }
        protected virtual void LineAdd(ContextRz context, orddet_line l)
        {
            ProfitReportSectionUserSensible userSection = null;
            if (Sections.ContainsKey(l.seller_uid))
                userSection = (ProfitReportSectionUserSensible)Sections[l.seller_uid];
            else
            {
                userSection = UserSectionCreate(context, l.seller_uid, l.seller_name);
                Sections.Add(l.seller_uid, userSection);
            }

            userSection.OrderLineAdd(context, this, userSection, l);
        }
        protected virtual ProfitReportSectionUserSensible UserSectionCreate(ContextRz context, String user_id, String user_name)
        {
            return new ProfitReportSectionUserSensible(context, user_id, user_name);
        }
        protected virtual List<orddet_line> OrderLinesSelect(ContextRz context)
        {
            String sql = "select orddet_line.* from orddet_line inner join ordhed_invoice on orddet_line.orderid_invoice = ordhed_invoice.unique_id where orddet_line.quantity > 0 and isnull(orddet_line.was_shipped, 0) = 1 ";
            if (CurrentArgs.DateRange.TheRange.Valid)
                sql += " and " + CurrentArgs.DateRange.TheRange.GetSQL("orddet_line.orderdate_invoice");
            else
                sql += " and orddet_line.orderdate_invoice > '1/2/1900' ";
            if (CurrentArgs.Agent != null)
            {
                if (CurrentArgs.Agent.AgentIds != null)
                {
                    if (CurrentArgs.Agent.AgentIds.Count > 0)
                        sql += " and orddet_line.seller_uid in ( " + Tools.Data.GetIn(CurrentArgs.Agent.AgentIds) + " ) ";
                }
            }
            //if (CurrentArgs.UserIds != null)
            //{
            //    if (CurrentArgs.UserIds.Count > 0)
            //        sql += " and orddet_line.seller_uid in ( " + Tools.Data.GetIn(CurrentArgs.UserIds) + " ) ";
            //}
            if (CurrentArgs.LimitToLineIds.Count > 0)
                sql += " and orddet_line.unique_id in ( " + Tools.Data.GetIn(CurrentArgs.LimitToLineIds) + " ) ";
            sql += " order by orddet_line.seller_name, orddet_line.ordernumber_sales, orddet_line.ordernumber_invoice";
            ArrayList a = context.QtC("orddet_line", sql);
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in a)
            {
                ret.Add(l);
            }
            return ret;
        }
        //Protected Override Functions
        protected override void InitTotals()
        {
            base.InitTotals();
            TotalProfit = new ReportTotal("Totals"); //Total Profit
            TotalProfit.Overline = 1;
            TotalProfit.Underline = 2;
            TotalProfit.ValueColumn = 8;
            TotalProfit.CaptionColumn = 5;
            Totals.Add(TotalProfit);

            TotalVolume = new ReportTotal("Total Volume");
            TotalVolume.Overline = 1;
            TotalVolume.Underline = 2;
            TotalVolume.ValueColumn = 6;
            Totals.Add(TotalVolume);

            TotalCost = new ReportTotal("Total Cost");
            TotalCost.Overline = 1;
            TotalCost.Underline = 2;
            TotalCost.ValueColumn = 7;
            Totals.Add(TotalCost);

            TotalMargin = new ReportTotalPercent("Total Margin");
            TotalMargin.Overline = 1;
            TotalMargin.Underline = 2;
            TotalMargin.ValueColumn = 9;
            Totals.Add(TotalMargin);

            NetPercent = new ReportTotalPercent("Net Percent");
            NetPercent.Overline = 1;
            NetPercent.Underline = 2;
            NetPercent.ValueColumn = 10;
            Totals.Add(NetPercent);

            TotalSales = new ReportTotal("");
            //TotalCost = new ReportTotal("");
            TotalGP = new ReportTotal("");
            TotalNP = new ReportTotal("");
        }
    }
    public class ProfitReportSectionUserSensible : ReportSection, IComparable
    {
        //Public Variables
        public String UserID = "";
        public String UserName = "";
        public ReportTotal TotalProfit;
        public ReportTotal TotalVolume;
        public ReportTotalPercent TotalMargin;
        public ReportTotalPercent NetPercent;
        public ReportTotal TotalSales = new ReportTotal("");
        public ReportTotal TotalCost = new ReportTotal("");
        public ReportTotal TotalGP = new ReportTotal("");
        public ReportTotal TotalNP = new ReportTotal("");
        public override string Caption
        {
            get
            {
                return UserName;
            }
        }

        //Constructors
        public ProfitReportSectionUserSensible(ContextRz context, String user_id, String user_name)
        {
            UserID = user_id;
            UserName = user_name;

            TotalProfit = new ReportTotal("Totals For " + UserName);
            TotalProfit.BoldFont = false;
            TotalProfit.Overline = 1;
            TotalProfit.ValueColumn = 8;
            TotalProfit.CaptionColumn = 5;
            Totals.Add(TotalProfit);

            TotalVolume = new ReportTotal("Sales Volume For " + UserName);
            TotalVolume.BoldFont = false;
            TotalVolume.Overline = 1;
            TotalVolume.ValueColumn = 6;
            Totals.Add(TotalVolume);

            TotalMargin = new ReportTotalPercent("Total Margin For " + UserName);
            TotalMargin.BoldFont = false;
            TotalMargin.Overline = 1;
            TotalMargin.ValueColumn = 9;
            Totals.Add(TotalMargin);

            NetPercent = new ReportTotalPercent("Net Percent For " + UserName);
            NetPercent.BoldFont = false;
            NetPercent.Overline = 1;
            NetPercent.ValueColumn = 10;
            Totals.Add(NetPercent);
        }
        //Public Virtual Functions
        public virtual void OrderLineAdd(ContextRz context, ProfitReportSensible r, ProfitReportSectionUserSensible u, orddet_line l)
        {
            //check for a matching order line
            ProfitReportSectionOrder orderSection = null;
            if (Sections.ContainsKey(l.ordernumber_sales))
                orderSection = (ProfitReportSectionOrder)Sections[l.ordernumber_sales];
            //add it if its missing
            if (orderSection == null)
            {
                orderSection = new ProfitReportSectionOrder(l.ordernumber_sales);
                Sections.Add(orderSection.InvoiceNumber, orderSection);
            }
            //add l to the order line
            orderSection.OrderLineAdd(context, r, u, l);

            ////check for a matching order line
            //ProfitReportSectionOrder orderSection = null;
            //if (Sections.ContainsKey(l.ordernumber_invoice))
            //    orderSection = (ProfitReportSectionOrder)Sections[l.ordernumber_invoice];
            ////add it if its missing
            //if (orderSection == null)
            //{
            //    orderSection = new ProfitReportSectionOrder(l.ordernumber_invoice);
            //    Sections.Add(orderSection.InvoiceNumber, orderSection);
            //}
            ////add l to the order line
            //orderSection.OrderLineAdd(context, r, u, l);
        }
        //Public Functions
        public int CompareTo(Object x)
        {
            ProfitReportSectionUser u = (ProfitReportSectionUser)x;
            return UserName.Trim().ToLower().CompareTo(u.UserName.Trim().ToLower());
        }
    }
    public class ProfitReportSectionOrder : ReportSection
    {
        public ReportTotal TotalProfit;
        public ReportTotal TotalVolume;
        public ReportTotalPercent TotalMargin;
        public ReportTotalPercent NetPercent;
        public ReportTotal TotalSales = new ReportTotal("");
        public ReportTotal TotalCost = new ReportTotal("");
        public ReportTotal TotalGP = new ReportTotal("");
        public ReportTotal TotalNP = new ReportTotal("");
        public String InvoiceNumber;

        public ProfitReportSectionOrder(String invoiceNumber)
        {
            InvoiceNumber = invoiceNumber;

            TotalProfit = new ReportTotal("");
            TotalProfit.BoldFont = false;
            TotalProfit.Overline = 1;
            TotalProfit.ValueColumn = 8;
            Totals.Add(TotalProfit);

            TotalVolume = new ReportTotal("Sub-Total");
            TotalVolume.BoldFont = false;
            TotalVolume.Overline = 1;
            TotalVolume.CaptionColumn = 5;
            TotalVolume.ValueColumn = 6;
            Totals.Add(TotalVolume);

            TotalMargin = new ReportTotalPercent("Total Margin");
            TotalMargin.BoldFont = false;
            TotalMargin.Overline = 1;
            TotalMargin.ValueColumn = 9;
            Totals.Add(TotalMargin);

            NetPercent = new ReportTotalPercent("Net Percent");
            NetPercent.BoldFont = false;
            NetPercent.Overline = 1;
            NetPercent.ValueColumn = 10;
            Totals.Add(NetPercent);
        }
        public ReportLine OrderLineAdd(ContextRz context, ProfitReportSensible r, ProfitReportSectionUserSensible u, orddet_line l)
        {
            ReportLine ret = new ReportLine();
            ProfitLineSet(context, r, ret, l);
            Lines.Add(ret);
            ProfitAdd(context, r, u, l, l.gross_profit);
            VolumeAdd(context, r, u, l, l.total_price);
            CostAdd(context, r, u, l, l.total_cost);

            foreach (profit_deduction d in l.DeductionsVar.RefsList(context))
            {
                ret = new ReportLine();
                ret.ForeColor = Color.Red;
                r.Set(ret, "Part", d.name);
                r.Set(ret, "Profit", d.amount * -1, "-" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(d.amount));
                Lines.Add(ret);
                ProfitAdd(context, r, u, l, (d.amount * -1));
                CostAdd(context, r, u, l, (d.amount));//added
            }
            //services
            if (!l.charge_service_to_customer)
            {
                if (l.service_cost > 0)
                {
                    ret = new ReportLine();
                    ret.ForeColor = Color.Red;
                    r.Set(ret, "Part", "Service Cost #" + l.ordernumber_service);
                    r.Set(ret, "Profit", l.service_cost * -1, "-" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(l.service_cost));
                    Lines.Add(ret);
                    ProfitAdd(context, r, u, l, (l.service_cost * -1));
                    CostAdd(context, r, u, l, (l.service_cost));//added
                }
            }
            if (l.rma_subtraction != 0)
            {
                ret = new ReportLine();
                ret.ForeColor = Color.Red;
                r.Set(ret, "Part", "RMA " + l.ordernumber_rma);
                r.Set(ret, "Price", l.total_price_rma * -1, "-" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(l.total_price_rma));
                r.Set(ret, "Profit", l.rma_subtraction * -1, "-" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(l.rma_subtraction));
                Lines.Add(ret);

                ProfitAdd(context, r, u, l, (l.rma_subtraction * -1));
                VolumeAdd(context, r, u, l, (l.total_price * -1));
            }
            //AltTotalsAdd(context, r, u, l);
            MarginTotalAdd(context, r, u, l);
            NetPercentAdd(context, r, u, l);
            return ret;
        }
        protected virtual void ProfitLineSet(ContextRz context, Rz5.Report report, ReportLine rl, orddet_line ol)
        {
            report.Set(rl, "Agent", ol.seller_name);
            rl.Set(report.ColumnIndex("Invoice"), ol.ordernumber_invoice, ol.ordernumber_invoice, new Core.ItemTag("ordhed_invoice", ol.orderid_invoice));
            //report.Set(rl, "Invoice", ol.ordernumber_invoice);
            report.Set(rl, "Date", Tools.Dates.DateFormat(ol.orderdate_invoice));
            rl.Set(report.ColumnIndex("Customer"), Tools.Strings.ParseDelimit(ol.customer_name, "[", 1), Tools.Strings.ParseDelimit(ol.customer_name, "[", 1), new Core.ItemTag("company", ol.customer_uid));
            //report.Set(rl, "Customer", Tools.Strings.ParseDelimit(ol.customer_name, "[", 1));
            if (ol.PurchaseHas)
            {
                rl.Set(report.ColumnIndex("Vendor"), Tools.Strings.ParseDelimit(ol.vendor_name, "[", 1) + " [PO# " + ol.ordernumber_purchase + "]", Tools.Strings.ParseDelimit(ol.vendor_name, "[", 1) + " [PO# " + ol.ordernumber_purchase + "]", new Core.ItemTag("company", ol.vendor_uid));
                //report.Set(rl, "Vendor", Tools.Strings.ParseDelimit(ol.vendor_name, "[", 1) + " [PO# " + ol.ordernumber_purchase + "]");
            }
            else
            {
                if (ol.StockTypeReceive == Rz5.Enums.StockType.Consign)
                    report.Set(rl, "Vendor", "Consignment [Lot# " + ol.lotnumber + "]");
                else
                    report.Set(rl, "Vendor", "Stock");
            }
            report.Set(rl, "Part", ol.fullpartnumber);
            report.Set(rl, "Price", ol.total_price, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(ol.total_price));
            report.Set(rl, "Cost", ol.total_cost, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(ol.total_cost));
            report.Set(rl, "Profit", ol.gross_profit, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(ol.gross_profit));
            report.Set(rl, "Total Margin", context.Sys.TheOrderLogic.GetMarginNetValue(ol.gross_profit, ol.total_price), context.Sys.TheOrderLogic.GetMarginNetPercent(ol.gross_profit, ol.total_price));
            report.Set(rl, "Net Percent", context.Sys.TheOrderLogic.GetMarginNetValue(ol.gross_profit, ol.total_cost), context.Sys.TheOrderLogic.GetMarginNetPercent(ol.gross_profit, ol.total_cost));
            rl.Set(report.ColumnIndex("Sales"), ol.ordernumber_sales, ol.ordernumber_sales, new Core.ItemTag("ordhed_sales", ol.orderid_sales));
        }
        protected virtual void ProfitAdd(ContextRz context, ProfitReportSensible r, ProfitReportSectionUserSensible u, orddet_line l, Double amount)
        {
            //this order
            this.TotalProfit.Value += amount;
            //this user
            u.TotalProfit.Value += amount;
            //overall
            r.TotalProfit.Value += amount;
        }
        protected virtual void VolumeAdd(ContextRz context, ProfitReportSensible r, ProfitReportSectionUserSensible u, orddet_line l, Double amount)
        {
            //this order
            this.TotalVolume.Value += amount;
            //this user
            u.TotalVolume.Value += amount;
            //overall
            r.TotalVolume.Value += amount;
        }
        protected virtual void CostAdd(ContextRz context, ProfitReportSensible r, ProfitReportSectionUserSensible u, orddet_line l, Double amount)
        {
            //this order
            this.TotalCost.Value += amount;
            //this user
            u.TotalCost.Value += amount;
            //overall
            r.TotalCost.Value += amount;
        }
        protected virtual void MarginTotalAdd(ContextRz context, ProfitReportSensible r, ProfitReportSectionUserSensible u, orddet_line l)
        {
            //this order
            this.TotalMargin.Value = context.Sys.TheOrderLogic.GetMarginNetValue(this.TotalProfit.Value, this.TotalVolume.Value);
            //this user
            u.TotalMargin.Value = context.Sys.TheOrderLogic.GetMarginNetValue(u.TotalProfit.Value, u.TotalVolume.Value);
            //overall
            r.TotalMargin.Value = context.Sys.TheOrderLogic.GetMarginNetValue(r.TotalProfit.Value, r.TotalVolume.Value);
        }
        protected virtual void NetPercentAdd(ContextRz context, ProfitReportSensible r, ProfitReportSectionUserSensible u, orddet_line l)
        {
            //this order
            this.NetPercent.Value = context.Sys.TheOrderLogic.GetMarginNetValue(this.TotalProfit.Value, this.TotalCost.Value);
            //this user
            u.NetPercent.Value = context.Sys.TheOrderLogic.GetMarginNetValue(u.TotalProfit.Value, u.TotalCost.Value);
            //overall
            r.NetPercent.Value = context.Sys.TheOrderLogic.GetMarginNetValue(r.TotalProfit.Value, r.TotalCost.Value);
        }
        //protected virtual void AltTotalsAdd(ContextRz context, ProfitReportSensible r, ProfitReportSectionUserSensible u, orddet_line l)
        //{
        //    //this order
        //    this.TotalSales.Value += l.total_price;
        //    this.TotalCost.Value += l.total_cost + l.total_deduction;
        //    this.TotalGP.Value += l.gross_profit;
        //    this.TotalNP.Value += l.net_profit;
        //    //this user
        //    u.TotalSales.Value += l.total_price;
        //    u.TotalCost.Value += l.total_cost + l.total_deduction;
        //    u.TotalGP.Value += l.gross_profit;
        //    u.TotalNP.Value += l.net_profit;
        //    //overall
        //    r.TotalSales.Value += l.total_price;
        //    r.TotalCost.Value += l.total_cost + l.total_deduction;
        //    r.TotalGP.Value += l.gross_profit;
        //    r.TotalNP.Value += l.net_profit;
        //}
        //protected virtual void MarginTotalAdd(ContextRz context, ProfitReportSensible r, ProfitReportSectionUserSensible u, orddet_line l)
        //{
        //    //this order
        //    this.TotalMargin.Value = context.Sys.TheOrderLogic.GetMarginNetValue(this.TotalGP.Value, this.TotalSales.Value);
        //    //this user
        //    u.TotalMargin.Value = context.Sys.TheOrderLogic.GetMarginNetValue(u.TotalGP.Value, u.TotalSales.Value);
        //    //overall
        //    r.TotalMargin.Value = context.Sys.TheOrderLogic.GetMarginNetValue(r.TotalGP.Value, r.TotalSales.Value);
        //}
        //protected virtual void NetPercentAdd(ContextRz context, ProfitReportSensible r, ProfitReportSectionUserSensible u, orddet_line l)
        //{
        //    //this order
        //    this.NetPercent.Value = context.Sys.TheOrderLogic.GetMarginNetValue(this.TotalNP.Value, this.TotalCost.Value);
        //    //this user
        //    u.NetPercent.Value = context.Sys.TheOrderLogic.GetMarginNetValue(u.TotalNP.Value, u.TotalCost.Value);
        //    //overall
        //    r.NetPercent.Value = context.Sys.TheOrderLogic.GetMarginNetValue(r.TotalNP.Value, r.TotalCost.Value);
        //}
    }
    //public class ProfitReportArgs : Rz5.ProfitReportArgs
    //{
    //    public ProfitReportArgs(Rz5.ContextRz context)
    //        : base(context)
    //    {

    //    }
    //    protected override bool ValidCheckUser(ContextRz context)
    //    {
    //        return true;
    //    }
    //}


}
