using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HubspotApis;
using SensibleDAL.dbml;
using static HubspotApis.HubspotApi;

namespace SensibleDAL
{

    public class SalesLogic
    {

        //static RzDataContext rdc = new RzDataContext();
        public static List<string> ExcludedStatus = new List<string>(new string[] { "RMA Receiving", "RMA Received", "Void", "Vendor RMA Packing", "Vendor RMA Shipped" });
        public static List<string> CompletedStatus = new List<string>() { SM_Enums.RzLineStatus.Quarantined.ToString(), SM_Enums.RzLineStatus.Scrapped.ToString(), SM_Enums.RzLineStatus.Shipped.ToString(), "Vendor RMA Shipped", SM_Enums.RzLineStatus.Void.ToString() };



        public class OrderQueryResult
        {
            public string Order { get; set; }
            public string OrderType { get; set; }
            public string orderid_sales { get; set; }
            public string orderid_invoice { get; set; }
            public string orderid_quote { get; set; }
            public DateTime OrderDate { get; set; }
            public string Status { get; set; }
            public string AgentName { get; set; }
            public string AgentID { get; set; }
            //public string SplitAgentName { get; set; }
            //public string SplitAgentID { get; set; }
            public double Total { get; set; }
            public double GP { get; set; }
            public double NP { get; set; }
            public double OpenGP { get; set; }

            public string CustomerName { get; set; }
            public string VendorName { get; set; }
            public double CustomerID { get; set; }
            public DateTime CustomerDock { get; set; }
            //Payment Details
            public DateTime PaidDate { get; set; }
            public double PaidAmount { get; set; }
            //Line Details
            public string MFG { get; set; }
            public string Part { get; set; }
            public int QTY { get; set; }
            public double unit_price { get; set; }
        }

        //Get Current Total Sales
        protected decimal GetTotalSales_Company(string companyid)
        {
            double? ret = 0;
            using (RzDataContext rdc = new RzDataContext())
            {
                ret = rdc.orddet_lines.Where(c => c.customer_uid == companyid && !ExcludedStatus.Contains(c.status)).Select(s => s.total_price).Sum();

            }

            return (decimal)ret;
        }

        //Get Current Total Orders Shipped
        protected int GetTotalOrders_Company(string Companyid)
        {
            int ret = 0;
            using (RzDataContext rdc = new RzDataContext())
            {
                ret = rdc.orddet_lines.Where(c => c.customer_uid == Companyid && ExcludedStatus.Contains(c.status)).Select(u => u.orderid_sales).Distinct().Count();
            }
            return ret;
        }

        //Get total invoices paid on time in period
        protected int GetTotalInvoicesPaidOnTime_Company(string companyid)
        {
            DateTime start = new DateTime(2016, 1, 1);
            DateTime end = new DateTime(2016, 7, 1);
            int ret = 0;
            //Get list of Invoices in Period
            using (RzDataContext rdc = new RzDataContext())
            {
                List<orddet_line> lines = rdc.orddet_lines.Where(w => w.customer_uid == companyid && ExcludedStatus.Contains(w.status) && (w.orderdate_invoice >= start && w.orderdate_invoice < end)).ToList();
                //Check each for paid in full status (i.e. sum payments for the distinct invoiceIDs in list of invoices where sum >= total invoice amount)
                List<checkpayment> paymentsforlines = rdc.checkpayments.Where(c => c.base_company_uid == companyid && lines.Any(l => l.orderid_invoice == c.base_ordhed_uid)).ToList();
            }

            return ret;
        }

        public DataTable GetShippedNetProfit_SalesAgents(List<n_user> n_userList, DateTime start, DateTime end, bool positiveProfit = false)
        {

            DataTable d = new DataTable();
            d.Columns.Add("ID", typeof(string));
            d.Columns.Add("Name", typeof(string));
            d.Columns.Add("Net Profit", typeof(string));
            decimal net_profit = 0;
            foreach (n_user u in n_userList)
            {

                net_profit = GetShippedNetProfit_SingleAgent(u.unique_id, start, end);
                if (positiveProfit)
                {
                    if (net_profit > 0)
                    {
                        d.Rows.Add(u.unique_id, u.name, net_profit);
                    }
                }
                else
                    d.Rows.Add(u.unique_id, u.name, net_profit);
            }
            return d;
        }



        public decimal GetShippedNetProfit_SingleAgent(string n_user_uid, DateTime start, DateTime end)
        {
            decimal? np = 0;
            using (RzDataContext rdc = new RzDataContext())
            {
                np = (decimal?)rdc.orddet_lines.Where(l => l.seller_uid == n_user_uid && l.customer_uid.Length > 0 && !ExcludedStatus.Contains(l.status) && (l.orderdate_invoice >= start && l.orderdate_invoice < end) && l.status == "shipped").Select(n => n.net_profit).Sum();
            }
            if (np != null)
                return (decimal)np;
            else
                return 0;
        }


        public static decimal GetShippedNetProfit_SingleUser(string UserID, DateTime start, DateTime end)
        {
            decimal? np = 0;
            using (RzDataContext rdc = new RzDataContext())
            {
                np = (decimal?)rdc.orddet_lines.Where(l => l.seller_uid == UserID && l.customer_uid.Length > 0 && !ExcludedStatus.Contains(l.status) && (l.orderdate_invoice >= start && l.orderdate_invoice < end) && l.status == "shipped").Select(n => n.net_profit).Sum();
            }
            if (np != null)
                return (decimal)np;
            else
                return 0;
        }


        public decimal GetProjectedNetProfit_SingleAgent(string n_user_uid, DateTime start, DateTime end)
        {
            //projected = includes scheduled to ship in the date range
            decimal? projectedNP;
            using (RzDataContext rdc = new RzDataContext())
            {
                projectedNP = (decimal?)rdc.orddet_lines.Where(l => l.seller_uid == n_user_uid && (l.customer_dock_date >= start && l.customer_dock_date < end) && !ExcludedStatus.Contains(l.status) && l.orderid_sales.Length > 0).Select(s => s.net_profit).Sum();
            }
            if (projectedNP != null)
                return (decimal)projectedNP;
            else
                return 0;
        }

        public decimal GetTotalFormalQuotes_SingleAgent(string n_user_uid, DateTime start, DateTime end)
        {
            decimal? np = 0;
            using (RzDataContext rdc = new RzDataContext())
            {
                np = (decimal?)rdc.ordhed_quotes.Where(l => l.base_mc_user_uid == n_user_uid && l.base_company_uid.Length > 0 && (l.orderdate >= start && l.orderdate < end)).Select(n => n.unique_id).Count();
            }
            if (np != null)
                return (decimal)np;
            else
                return 0;
        }
        public decimal GetTotalQuotedDollars_SingleAgent(string n_user_uid, DateTime start, DateTime end)
        {
            decimal? np = 0;
            using (RzDataContext rdc = new RzDataContext())
            {
                np = (decimal?)rdc.ordhed_quotes.Where(l => l.base_mc_user_uid == n_user_uid && l.base_company_uid.Length > 0 && (l.orderdate >= start && l.orderdate < end)).Select(n => n.profitamount).Sum();
            }
            if (np != null)
                return (decimal)np;
            else
                return 0;
        }
        public decimal GetTotalSaleDollars_SingleAgent(string n_user_uid, DateTime start, DateTime end)
        {
            decimal? ts = 0;
            using (RzDataContext rdc = new RzDataContext())
            {
                ts = (decimal?)rdc.orddet_lines.Where(l => l.seller_uid == n_user_uid && l.customer_uid.Length > 0 && (l.orderdate_sales >= start && l.orderdate_sales < end)).Select(n => n.total_price).Sum();
            }
            if (ts != null)
                return (decimal)ts;
            else
                return 0;
        }

        public decimal GetOpenQuoteValue_SingleAgent(string n_user_uid, DateTime start, DateTime end)
        {
            decimal? oq = 0;
            decimal ret = 0;
            using (RzDataContext rdc = new RzDataContext())
            {
                oq = (decimal?)rdc.ordhed_quotes.Where(l => l.base_mc_user_uid == n_user_uid && l.base_company_uid.Length > 0 && l.orderdate >= DateTime.Now.AddDays(-90) && l.opportunity_stage == "Open").Select(n => n.profitamount).Sum();

            }
            //oq = (decimal?)RDC.orddet_lines.Where(l => l.seller_uid == RzUser.unique_id && l.customer_uid.Length > 0 && (l.customer_dock_date >= start && l.customer_dock_date < end) && l.status.ToLower() != "shipped").Select(n => n.net_profit).Sum();
            if (oq != null)
            {
                ret = GetTotalQuotedDollars_SingleAgent(n_user_uid, start, end) - (decimal)oq;
                return ret;
            }
            else
                return 0;
        }

        public decimal Get_PercentToGoal(IEnumerable<OrderQueryResult> orderQueryResult, string valueType, string n_user_uid, DateTime start, DateTime end, decimal? goal)
        {
            decimal achievedAmount = 0;
            decimal percentToGoal = 0;

            switch (valueType)
            {
                case "gp":
                    {
                        achievedAmount = (decimal)orderQueryResult.Sum(s => s.GP);
                        break;
                    }

                case "np":
                    {
                        achievedAmount = (decimal)orderQueryResult.Sum(s => s.NP);
                        break;
                    }
            }


            if (goal > 0 && !string.IsNullOrEmpty(valueType))
            {
                percentToGoal = (achievedAmount / (decimal)goal) * 100;
                if (percentToGoal >= 100)
                    return 100;
                else
                    return (decimal)percentToGoal;
            }
            return 0;
        }
        public decimal GetNP_PercentToGoal(string n_user_uid, DateTime start, DateTime end, decimal? goal)
        {
            if (goal > 0)
            {
                decimal? percentToGoal = 0;
                decimal? shippedNP = GetShippedNetProfit_SingleAgent(n_user_uid, start, end);
                percentToGoal = (shippedNP / goal) * 100;
                if (percentToGoal >= 100)
                    return 100;
                else
                    return (decimal)percentToGoal;
            }
            return 0;
        }


        public static IEnumerable<OrderQueryResult> GetSalesBreakDown(RzDataContext rdc, string type, DateTime start, DateTime end, List<string> badStatus, List<n_user> includedAgents, bool includeMissing = true)
        {

            IEnumerable<OrderQueryResult> orderQueryResult = null;
            switch (type)
            {
                case "quoted":
                    {
                        orderQueryResult = GetQuotedOrders(rdc, start, end, badStatus, includedAgents);
                        break;

                    }
                case "booked":
                    {

                        orderQueryResult = GetBookedOrders(rdc, start, end, badStatus, includedAgents).ToList();


                        break;

                    }
                case "invoiced":
                    {
                        orderQueryResult = GetInvoicedOrders(rdc, start, end, badStatus, includedAgents).ToList();
                        break;

                    }
            }
            if (orderQueryResult.Count() > 0)
                if (includeMissing)
                {

                    orderQueryResult = orderQueryResult.Concat(GetMissingSalesBreakdownAgents(rdc, orderQueryResult, includedAgents.Select(s => s.unique_id).ToList()));

                }

            return orderQueryResult;



        }

        public static List<OrderQueryResult> GetBookedOrders(RzDataContext rdc, DateTime start, DateTime end, List<string> excludedStatus, List<n_user> includedAgents)
        {
            //Problem, Source TBD. The will have an orderdate that will be BEFORE The date that an actual vendor gets selected.  Therefore need another special date
            //for when the TBS Gets cleared.
            List<OrderQueryResult> ret = new List<OrderQueryResult>();

            var bookedQuery = rdc.orddet_lines.Where(line => (line.tbd_cleared_date.Value < new DateTime(1901, 1, 1) || line.tbd_cleared_date.Value == null)// without this this, TBD line might be picked up in the query
                            && line.vendor_name != "Source TBD"
                            && line.orderdate_sales >= start
                            && line.orderdate_sales <= end
                            && (line.orderid_sales ?? "").Length > 0
                            && !excludedStatus.Contains(line.status)
                            && includedAgents.Select(s => s.unique_id).ToList().Contains(line.seller_uid));
            foreach (var line in bookedQuery)
            {
                ret.Add(CreateOrderQueryObject(line));
                if (!string.IsNullOrEmpty(line.split_commission_agent_uid))
                    ret.Add(CreateOrderQueryObject(line, true));
            }

            var tbdClearedQuery = rdc.orddet_lines.Where(line => line.tbd_cleared_date >= start
            && line.orderdate_sales <= end
            && !excludedStatus.Contains(line.status)
            && (line.orderid_sales ?? "").Length > 0
            && includedAgents.Select(s => s.unique_id).ToList().Contains(line.seller_uid));

            foreach (var line in tbdClearedQuery)
            {
                ret.Add(CreateOrderQueryObject(line));
                if (!string.IsNullOrEmpty(line.split_commission_agent_uid))
                    ret.Add(CreateOrderQueryObject(line, true));
            }

            ///Loop through each, when split detected, and isn't same as agent, create a new line for split 

            return ret;
        }

        private static OrderQueryResult CreateOrderQueryObject(orddet_line line, bool isSplit = false)
        {
            OrderQueryResult oqr = new OrderQueryResult();
            oqr.Order = line.ordernumber_sales;
            oqr.orderid_invoice = line.orderid_invoice;
            oqr.orderid_sales = line.orderid_sales;
            oqr.OrderDate = (DateTime)line.orderdate_sales;
            oqr.OrderType = "booked";
            oqr.CustomerDock = (DateTime)line.customer_dock_date;
            oqr.CustomerName = line.customer_name;
            oqr.Status = line.status;
            if (isSplit)
            {
                oqr.AgentName = line.split_commission_agent_name;
                oqr.AgentID = line.split_commission_agent_uid;
            }
            else
            {
                oqr.AgentName = line.seller_name;
                oqr.AgentID = line.seller_uid;

            }

            oqr.Total = CalculateOrderQueryTotal(line.split_commission_agent_name, (double)line.total_price);
            oqr.GP = CalculateOrderQueryTotal(line.split_commission_agent_name, (double)line.gross_profit);
            oqr.NP = CalculateOrderQueryTotal(line.split_commission_agent_name, (double)line.net_profit);
            return oqr;
        }



        //public static double GetSplitCommissionPercentage(string unique_id, double lineCommission, string splitAgentUid, string lineAgentUid)
        //{
        //    orddet_line l = null;
        //    using (RzDataContext rdc = new RzDataContext())
        //        l = rdc.orddet_lines.Where(w => w.unique_id == unique_id).FirstOrDefault();
        //    if (l == null)
        //        return 0;

        //    //OFficial Rules of Split Commission, everything except DESGIN SPLIT is 5%, DESIGN SPLIT is 10%
        //    decimal splitAgentPercent = .05m;
        //    if (l.split_commission_type.ToLower() == "design")
        //        splitAgentPercent = .1m;
        //    decimal lineOwnerSplitPercent = .15m - splitAgentPercent;


        //    //if the sellerUID == tColumnHeader split ID then this is the SPLIT agent, calculate accordingly
        //    bool isSplitAgentCalc = lineAgentUid == splitAgentUid;
        //    if (isSplitAgentCalc)
        //        return Convert.ToDouble(splitAgentPercent);
        //    else
        //        return
        //            Convert.ToDouble(lineOwnerSplitPercent);
        //}

        public static List<OrderQueryResult> GetInvoicedOrders(RzDataContext rdc, DateTime start, DateTime end, List<string> badStatus, List<n_user> includedAgents)
        {
            List<OrderQueryResult> ret = new List<OrderQueryResult>();
            var query = rdc.orddet_lines
                .Where(line => line.orderdate_invoice >= start && line.orderdate_invoice <= end && line.orderid_sales.Length > 0 && line.orderid_invoice.Length > 0
                   && includedAgents.Select(s => s.unique_id).ToList().Contains(line.seller_uid)
                   && line.status.ToLower() == "shipped");


            foreach (var line in query)
            {
                ret.Add(CreateOrderQueryObject(line));
                if (!string.IsNullOrEmpty(line.split_commission_agent_uid))
                    ret.Add(CreateOrderQueryObject(line, true));
            }
            return ret;
        }

        public static List<OrderQueryResult> GetProjectedOrders(RzDataContext rdc, DateTime start, DateTime end, List<string> badStatus, List<n_user> includedAgents)
        {
            //Problem, Source TBD. The will have an orderdate that will be BEFORE The date that an actual vendor gets selected.  Therefore need another special date
            //for when the TBS Gets cleared.
            //IEnumerable<OrderQueryResult> projectedQuery = null;
            List<OrderQueryResult> ret = new List<OrderQueryResult>();
            badStatus.Add("shipped");



            var projectedQuery = rdc.orddet_lines.Where(w => (w.tbd_cleared_date.Value < new DateTime(1901, 1, 1) || w.tbd_cleared_date.Value == null)// without this this, TBD line might be picked up in the query
                              && w.vendor_name != "Source TBD"
                              && w.orderid_sales.Length > 0
                              && w.customer_dock_date >= start
                              && w.customer_dock_date <= end
                              && !badStatus.Contains(w.status)
                              && !w.fullpartnumber.Contains("gcat")
                              && includedAgents.Select(s => s.unique_id).ToList().Contains(w.seller_uid));
            foreach (var line in projectedQuery)
            {
                OrderQueryResult oqr = new OrderQueryResult();
                oqr.Order = line.ordernumber_sales;
                oqr.orderid_sales = line.orderid_sales;
                oqr.OrderDate = (DateTime)line.orderdate_sales;
                oqr.OrderType = "booked";
                oqr.CustomerDock = (DateTime)line.customer_dock_date;
                oqr.CustomerName = line.customer_name;
                oqr.Status = line.status;
                oqr.AgentName = line.seller_name;
                oqr.AgentID = line.seller_uid;
                //oqr.Total = line.total_price ?? 0;
                //oqr.GP = line.gross_profit ?? 0;
                //oqr.NP = line.net_profit ?? 0;
                oqr.Total = CalculateOrderQueryTotal(line.split_commission_agent_name, (double)line.total_price);
                oqr.GP = CalculateOrderQueryTotal(line.split_commission_agent_name, (double)line.gross_profit);
                oqr.OpenGP = CalculateOrderQueryTotal(line.split_commission_agent_name, (double)line.net_profit);

                ret.Add(oqr);
            }

            var tbdClearedQuery = rdc.orddet_lines.Where(line => line.tbd_cleared_date >= start
                  && line.orderid_sales.Length > 0
                  && line.tbd_cleared_date <= end
                  && line.customer_dock_date >= start
                  && line.customer_dock_date <= end
                  && !badStatus.Contains(line.status)
                  && !line.fullpartnumber.Contains("gcat")
                  && includedAgents.Select(s => s.unique_id).ToList().Contains(line.seller_uid));
            foreach (var line in projectedQuery)
            {
                OrderQueryResult oqr = new OrderQueryResult();

                oqr.Order = line.ordernumber_sales;
                oqr.orderid_sales = line.orderid_sales;
                oqr.OrderType = "booked";
                oqr.OrderDate = (DateTime)line.tbd_cleared_date;
                oqr.CustomerName = line.customer_name;
                oqr.CustomerDock = (DateTime)line.customer_dock_date;
                oqr.Status = line.status;
                oqr.AgentName = line.seller_name;
                oqr.AgentID = line.seller_uid;
                //oqr.Total = line.total_price ?? 0;
                //oqr.GP = line.gross_profit ?? 0;
                //oqr.NP = line.net_profit ?? 0;
                oqr.Total = CalculateOrderQueryTotal(line.split_commission_agent_name, (double)line.total_price);
                oqr.GP = CalculateOrderQueryTotal(line.split_commission_agent_name, (double)line.gross_profit);
                oqr.OpenGP = CalculateOrderQueryTotal(line.split_commission_agent_name, (double)line.net_profit);

                ret.Add(oqr);

            }

            return ret;
        }

        public static List<OrderQueryResult> GetQuotedOrders(RzDataContext rdc, DateTime start, DateTime end, List<string> badStatus, List<n_user> includedAgents)
        {
            List<OrderQueryResult> ret = new List<OrderQueryResult>();
            //Since only orddet_quotes know about split, need to search for quoted lines either belongig to or split with any includedAgents.
            var agents = includedAgents.Select(s => s.unique_id).Distinct();

            //Need quote lines 1st, so we can pull approprate headers for normal and split agents (splits live on the orddet).
            List<orddet_quote> normalAndSplitQuoteLines = rdc.orddet_quotes
                .Where(w => (w.date_created.Value.Date >= start && w.date_created.Value.Date <= end)
                && (agents.Contains(w.base_mc_user_uid) || agents.Contains(w.split_commission_agent_uid)))
                .Distinct().ToList();

            List<string> normalAndSplitQuoteIds = normalAndSplitQuoteLines.Select(s => s.base_ordhed_uid).Distinct().ToList();


            //Get a list of Quote Headers for the totals
            int total = normalAndSplitQuoteIds.Count;
            int remaining = total;
            int startIndex = 0;
            int take = 2000;
            List<ordhed_quote> quoteHeaderList = new List<ordhed_quote>();
            while (remaining > 0)
            {

                List<ordhed_quote> tempList = rdc.ordhed_quotes.Where(w => normalAndSplitQuoteIds.Skip(startIndex).Take(take).Contains(w.unique_id) && w.isvoid != true).ToList();
                if (tempList == null || tempList.Count <= 0)
                    continue;
                //Take the next 2000 rows
                startIndex += take;
                remaining -= take;
                quoteHeaderList.AddRange(tempList);

            }

            foreach (var formalQuote in quoteHeaderList)
            {
                try
                {

                    var quotesLinesForThisOrder = normalAndSplitQuoteLines
                        .Where(w => w.base_ordhed_uid == formalQuote.unique_id);
                    if (!quotesLinesForThisOrder.Any())
                        continue;
                    //If any quotes are split, we split the totals
                    string splitCommissionAgent = quotesLinesForThisOrder.Where(w => (w.split_commission_agent_name ?? "").Length > 0).Select(s => s.split_commission_agent_name).FirstOrDefault();
                    OrderQueryResult oqr = new OrderQueryResult();
                    oqr.Status = formalQuote.opportunity_stage;
                    oqr.CustomerName = formalQuote.companyname;
                    oqr.Order = formalQuote.ordernumber;
                    oqr.OrderType = "quoted";
                    oqr.OrderDate = (DateTime)formalQuote.orderdate;
                    oqr.AgentName = formalQuote.agentname;
                    oqr.AgentID = formalQuote.base_mc_user_uid;
                    //SplitAgentName = q.split_commission_agent_name,
                    oqr.Total = CalculateOrderQueryTotal(splitCommissionAgent, (double)formalQuote.ordertotal);
                    oqr.GP = CalculateOrderQueryTotal(splitCommissionAgent, (double)formalQuote.profitamount);
                    if (formalQuote.opportunity_stage == "Open")
                        oqr.OpenGP = CalculateOrderQueryTotal(splitCommissionAgent, Convert.ToDouble(formalQuote.profitamount));
                    else
                        oqr.OpenGP = Convert.ToDouble(formalQuote.profitamount);
                    ret.Add(oqr);
                }
                catch (Exception ex)
                {
                    SystemLogic.Email.SendMail("test@sensiblemicro.com", "ktill@sensiblemicro.com", formalQuote.ordernumber, "Problem!");
                    break;

                }

            }

            return ret.OrderByDescending(o => o.Total).ToList(); ;
        }


        public static IEnumerable<OrderQueryResult> GetOpenQuotes(RzDataContext rdc, DateTime start, DateTime end, List<n_user> includedAgents)
        {
            IEnumerable<OrderQueryResult> ret = null;

            ret = (from q in rdc.ordhed_quotes
                       //where q.isclosed == false && q.base_mc_user_uid == u.unique_id && q.date_created >= goal.PeriodStart && q.date_created <= goal.PeriodEnd && q.opportunity_stage == "Open"
                   where q.isclosed == false &&
                   includedAgents.Select(s => s.unique_id).ToList().Contains(q.base_mc_user_uid)
                   && q.date_created >= start && q.date_created <= end && q.opportunity_stage == "Open"
                   select new OrderQueryResult
                   {
                       CustomerName = q.companyname,
                       Order = q.ordernumber,
                       Status = q.opportunity_stage,
                       GP = (double)q.profitamount,
                       OrderDate = (DateTime)q.orderdate,
                       orderid_quote = q.unique_id,
                       OrderType = "openQuote"
                   });

            return ret;
        }

        private static IEnumerable<OrderQueryResult> GetMissingSalesBreakdownAgents(RzDataContext rdc, IEnumerable<OrderQueryResult> orderQueryResult, List<string> includedAgentsIDs)
        {
            IEnumerable<OrderQueryResult> ret = null;


            ret = from u in rdc.n_users
                  where !orderQueryResult.Select(s => s.AgentName).Distinct().ToList().Contains(u.name)
                  && includedAgentsIDs.Contains(u.unique_id)
                  select new OrderQueryResult
                  {
                      Status = "",
                      Order = "",
                      AgentName = u.name,
                      AgentID = u.unique_id,
                      Total = Convert.ToDouble(0),
                      GP = Convert.ToDouble(0),

                  };

            return ret;
        }


        public static IEnumerable<OrderQueryResult> GetAgingSales(RzDataContext rdc, DateTime start, List<n_user> includedAgents)
        {
            IEnumerable<OrderQueryResult> ret = null;

            ret = (from l in rdc.orddet_lines
                   where !CompletedStatus.Contains(l.status)
                   where !ExcludedStatus.Contains(l.status)
                   && includedAgents.Select(s => s.unique_id).ToList().Contains(l.seller_uid)
                   && l.orderdate_sales <= start
                   && l.orderdate_sales >= new DateTime(2017, 1, 1)
                   && l.orderid_sales.Length > 0
                   && l.customer_uid.Length > 0
                   select new OrderQueryResult
                   {
                       CustomerName = l.customer_name,
                       VendorName = l.vendor_name,
                       Order = l.ordernumber_sales,
                       Status = l.status,
                       GP = (double)l.gross_profit,
                       OrderDate = (DateTime)l.orderdate_sales,
                       orderid_invoice = l.orderid_invoice,
                       OrderType = "agingSales",
                       QTY = l.quantity ?? 0
                   }).Distinct().ToList();

            return ret;
        }



        private static double CalculateOrderQueryTotal(string splitCommissionAgent, double value)
        {
            if (value == 0)
                return value;
            if (!string.IsNullOrEmpty(splitCommissionAgent))
                return value * .5;
            else
                return value;
        }

        //private class AgedRealResults
        //{
        //    public int hubspotDealID { get; set; }
        //    public string dealName { get; set; }
        //    public DateTime dateCreated_Hubspot { get; set; }
        //    public DateTime dateCreated_Rz { get; set; }

        //}

        public static void HandleAgedDealsRz(RzDataContext rdc, int olderThanDays, string orderNumber, out int count, out string htmlResults)
        {




            //This needs to:
            //1:  Find all Hubspot ID's for batches, not Won, and older than 30 days for batches (not formal quotes, they should all be starting as batches)
            //2:  set the batch to closed, mark oppty_lost_reason matching current paradigm (as of now it's Hubspot Pipeline).
            htmlResults = "";
            count = 0;
            string reason = "Aged";
            DateTime cutoffDate = new DateTime(2022,07, 01);//Only look at objects created after this date.  There may be a time wher ethe date is 1900 (SQL default) when this routine runs.
            DateTime agedThresholdDate = DateTime.Today.Date.AddDays(-olderThanDays);

            //Carry a list of the affected deals for report output
            List<dealheader> closedDealResultsList = new List<dealheader>();

            //Order Batches
            //Order By is VERY Important here for the following dates to make sense  
            List<dealheader> batchList = rdc.dealheaders.Where(w => w.hubspot_deal_id > 0 && !w.opportunity_stage.ToLower().Contains("won") && w.is_closed == false && w.date_created.Value.Date >= cutoffDate && w.date_created.Value.Date <= agedThresholdDate.Date).OrderByDescending(o => o.date_created).ToList();

            //Only Auto-Age DistySales
            //batchList = batchList.Where(w => w.agentname.ToLower().Contains("phil scott")).ToList();

            if (batchList.Count > 0)
            {
                //Helpful to confirm the date range of these dealheaders, for sanity check
                dealheader mostRecentDeal = batchList.First();
                dealheader oldestDeal = batchList.Last();
                DateTime mostRecentBatchDate = mostRecentDeal.date_created.Value;
                DateTime oldestBatchDate = oldestDeal.date_created.Value;
                foreach (dealheader d in batchList)
                {
                    //Get the corresponding Hubspot Deal
                    Deal deal = HubspotApi.Deals.GetDealByID(d.hubspot_deal_id ?? 0);

                    //Close the Hubspot Deal  //Close the hubspot deal
                    if (d.hubspot_deal_id > 0)
                        Deals.SetDealLost((int)d.hubspot_deal_id, reason, true);

                    //CloseHubspotDealRz(rdc, d, reason, true);
                    if (d.opportunity_stage != "sale_lost" || d.is_closed != true)
                        SetRzDealObjectLostFromExternalApplication(rdc, d, reason);
                    count++;
                    closedDealResultsList.Add(d);

                }
            }




            //Formal Quotes           

            //Carry a list of the affected deals for report output
            List<ordhed_quote> closedQuoteResultsList = new List<ordhed_quote>();
            List<ordhed_quote> quoteList = new List<ordhed_quote>();
            //I can use the orderNumber to target a specific order for testing.  
            //start with a query and filter as needed before toList();        
            

            var query = rdc.ordhed_quotes.Where(w => w.date_created.Value.Date <= agedThresholdDate.Date && w.date_created.Value.Date >= cutoffDate && !w.opportunity_stage.ToLower().Contains("won") && w.isclosed == false && w.hubspot_deal_id > 0);
            if (!string.IsNullOrEmpty(orderNumber))
                query = query.Where(w => w.ordernumber == orderNumber);
            //Order By is VERY Important here for the following dates to make sense
            quoteList = query.OrderByDescending(o => o.date_created).ToList();

            //Only Auto-Age DistySales
            
            if (quoteList.Count > 0)
            {
                ordhed_quote mostRecentQuote = quoteList.First();
                ordhed_quote oldestQuote = quoteList.Last();
                DateTime mostRecentQuoteDate = mostRecentQuote.date_created.Value;
                DateTime oldestQuoteDate = oldestQuote.date_created.Value;

                foreach (ordhed_quote q in quoteList)
                {
                    //Get the corresponding Hubspot Deal
                    Deal deal = HubspotApi.Deals.GetDealByID(q.hubspot_deal_id ?? 0);
                    //Close the Hubspot Deal
                    if (q.hubspot_deal_id > 0)
                        Deals.SetDealLost((int)q.hubspot_deal_id, reason, true);
                    //CloseHubspotDealRz(rdc, q, reason, true);
                    if (q.opportunity_stage != "sale_lost")
                        SetRzDealObjectLostFromExternalApplication(rdc, q, reason);
                    count++;


                    closedQuoteResultsList.Add(q);


                }
            }


            htmlResults = GenerateAgedDealHtmlResults(batchList, quoteList);


        }

        public static string GenerateAgedDealHtmlResults(List<dealheader> batchList, List<ordhed_quote> quoteList)
        {
            string ret = @"<html>";
            ret += @"<head>";
            ret += @"<title>";
            ret += @"Aged Quotes";
            ret += @"</title>";
            ret += @"<style>";
            ret += @" table, th, td {  border: 1px solid black;} ";
            ret += @"</style>";
            ret += @"</head>";
            ret += @"<body>";
            ret += "<b><label>Aged Deals Routine Daily Summary Report:</label></b><br />";



            if (batchList.Count > 0)
            {
                ret += @"<br />";
                ret += "<b>Order Batches Closed:</b>";
                ret += "<table>";
                ret += "<tr><th>Company</th><th>Agent</th><th>DealName</th><th>DateCreated</th></tr>";
                foreach (dealheader d in batchList)
                {


                    string dateCreated = d.date_created.Value.ToShortDateString();
                    string batchName = d.dealheader_name;
                    string agentName = d.agentname;
                    string companyName = d.customer_name;
                    ret += "<tr>";
                    ret += "<td>" + companyName + "</td>";
                    ret += "<td>" + agentName + "</td>";
                    ret += "<td>" + batchName + "</td>";
                    ret += "<td>" + dateCreated + "</td>";
                    ret += "</tr>";

                }
                ret += "</table>";
            }
            if (quoteList.Count > 0)
            {
                ret += @"<br />";
                ret += "<b>Formal Quotes Closed:</b>";
                ret += "<table>";
                foreach (ordhed_quote q in quoteList)
                {


                    string dateCreated = q.date_created.Value.ToShortDateString();
                    string batchName = q.ordernumber;
                    string agentName = q.agentname;
                    string companyName = q.companyname;
                    ret += "<tr>";
                    ret += "<td>" + companyName + "</td>";
                    ret += "<td>" + agentName + "</td>";
                    ret += "<td>" + batchName + "</td>";
                    ret += "<td>" + dateCreated + "</td>";
                    ret += "</tr>";

                }
                ret += "</table>";
            }
            else
            {
                ret += @"<br />";
                ret += "<i>No Deals aged for this period.</i>";
            }
            ret += @"</body>";

            return ret;
        }







        //public static void CloseHubspotDealRz(RzDataContext rdc, object dealObject, string reason, bool isAged = false)
        //{
        //    if (dealObject is dealheader)
        //    {
        //        dealheader d = (dealheader)dealObject;
        //        CloseHubspotDealRz_OrderBatch(rdc, d, reason, true);
        //    }
        //    else if (dealObject is ordhed_quote)
        //    {
        //        ordhed_quote q = (ordhed_quote)dealObject;
        //        CloseHubspotDealRz_FormalQuote(rdc, q, reason, true);
        //    }

        //}

        //private static void CloseHubspotDealRz_OrderBatch(RzDataContext rdc, dealheader d, string reason, bool isAged)
        //{

        //    if (d == null)
        //        throw new Exception("Unable to close Hubspot Deal, Order Batch not found.");

        //    //Handle the Hubspot Deal
        //    if (d.hubspot_deal_id > 0)
        //    {
        //        if (d.opportunity_stage != "sale_lost")
        //        {
        //            d.ClosureReason = reason;
        //            d.opportunity_stage = "sale_lost";
        //            rdc.SubmitChanges();


        //        }
        //        //Close the hubspot deal
        //        Deals.SetDealLost((int)d.hubspot_deal_id, reason, isAged);
        //    }



        //}

        //public static void CloseHubspotDealRz_FormalQuote(RzDataContext rdc, ordhed_quote q, string reason = null, bool aged = false)
        //{

        //    if (q == null)
        //        throw new Exception("Unable to close Hubspot Deal, Formal Quote not found.");
        //    //Close the hubspot deal
        //    if (q.hubspot_deal_id > 0)
        //        Deals.SetDealLost((int)q.hubspot_deal_id, reason, aged);

        //    //Close the Rz Formal Quote
        //    if (q.opportunity_stage != "sale_lost" || q.isclosed != true)
        //    {
        //        q.isclosed = true;
        //        q.opportunity_lost_reason = reason;
        //        q.opportunity_stage = "sale_lost";
        //        rdc.SubmitChanges();
        //    }


        //}

        public static void SetRzDealObjectLostFromExternalApplication(RzDataContext rdc, object rzObject, string reason)
        {

            if (string.IsNullOrEmpty(reason))
                throw new Exception("Must provide an oppoiurnity lost reason to mark closed.");

            int count = 0;
            ordhed_quote theQuote = null;
            dealheader theBatch = null;
            if (rzObject is dealheader)
            {
                theBatch = (dealheader)rzObject;
            }
            else if (rzObject is ordhed_quote)
            {
                theQuote = (ordhed_quote)rzObject;
            }
            if (theQuote == null && theBatch == null)
                return;
            if (theQuote != null)
            {

                //Sometimes there can be multiple quotes with same HubID, this automation should close them all.
                List<ordhed_quote> qList = new List<ordhed_quote>();
                long hubID = theQuote.hubspot_deal_id ?? 0;
                if (hubID > 0)
                    qList = rdc.ordhed_quotes.Where(w => w.hubspot_deal_id == hubID).ToList();
                else
                    qList = rdc.ordhed_quotes.Where(w => w.unique_id == theQuote.unique_id).ToList();

                foreach (ordhed_quote q in qList)
                {
                    q.opportunity_lost_reason = reason;
                    q.opportunity_stage = "sale_lost";
                    q.isclosed = true;
                    q.isvoid = true;
                    count++;
                }
                rdc.SubmitChanges();
            }

            else if (theBatch != null)
            {
                //Sometimes there can be multiple quotes with same HubID, this automation should close them all.
                List<dealheader> dList = new List<dealheader>();
                long hubID = theBatch.hubspot_deal_id ?? 0;
                if (hubID > 0)
                    dList = rdc.dealheaders.Where(w => w.hubspot_deal_id == hubID).ToList();
                else
                    dList = rdc.dealheaders.Where(w => w.unique_id == theQuote.unique_id).ToList();

                foreach (dealheader d in dList)
                {
                    d.ClosureReason = reason;
                    d.opportunity_stage = "sale_lost";
                    d.is_closed = true;
                    count++;
                }
                rdc.SubmitChanges();
            }






        }



    }
    public class SalesTheory
    {

        //Public Variables
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<hubspot_engagement> weeklyEngagementList { get; set; }
        public List<n_user> agentList { get; set; }


        //Helper List for the Ids
        public static List<string> SelectedAgentIds = new List<string>();
        //AgentObject Weekly Numbers
        public List<SalesTheoryObject> weeklySalesTheoryObjects = new List<SalesTheory.SalesTheoryObject>();
        //List<SalesTheory.SalesTheoryObject> dailySalesTheoryObjects = new List<SalesTheory.SalesTheoryObject>();
        //Days, separated by that day's list of sales theory objects
        public Dictionary<DateTime, List<SalesTheory.SalesTheoryObject>> dailySalesTheoryObjects = new Dictionary<DateTime, List<SalesTheory.SalesTheoryObject>>();

        //Data Queries
        //Phone Calls Query - Call counts & Conversations
        public static List<hubspot_engagement> phoneCallQuery = new List<hubspot_engagement>(); //Needed for conversation Query

        //Bonus Points Query
        public static List<hubspot_engagement> bonusQuery = new List<hubspot_engagement>();

        //ConversationPoints Query
        public static List<hubspot_engagement> conversationQuery = new List<hubspot_engagement>();
        //RFQ Points
        public static List<dealheader> rfqQuery = new List<dealheader>();
        //Sals Points Goal Query
        //public static List<ordhed_sale> salesGoalPointsQuery = new List<ordhed_sale>();
        public static List<orddet_line> salesGoalPointsQuery = new List<orddet_line>();


        public class SalesTheoryObject
        {

            //Points           
            //public double phonecallPoints { get; set; } //>50 = 2pt, >59 = 3pt, >74 = 4pt
            public double rfqPoints { get; set; } //1pt per batch
            public double salesGoalPoints { get; set; } //5pt if agent hits his daily goal
            public int conversationPoints { get; set; } //1pt when call is marked "Connected" (or maybe lasts longer than 5 min?)


            //Counts
            //public int phonecallCount { get; set; } //>50 = 2pt, >59 = 3pt, >74 = 4pt
            public int rfqCount { get; set; } //1pt per batch  
            public int salesGoalCount { get; set; } //5pt if agent hits his daily goal
            public int conversationCount { get; set; } //1pt when call is marked "Connected" (or maybe lasts longer than 5 min?)



            //Bonus
            public double bonusPoints { get; set; }
            public int bonusCount { get; set; }
            public string bonusTitle { get; set; }
            public string bonusIconClass { get; set; }

            //General
            public string agentName { get; set; }
            public string agentEmail { get; set; }
            public string agentImageUrl { get; set; } //Image for board, etc.
            public string rz_user_uid { get; set; }
            public SalesTheoryAgentType salesTheoryAgentType { get; set; }
            public double currentPoints { get; set; }
        }

        public enum SalesTheoryAgentType
        {
            Sales,//SalesAgent
            RM, //RelationShip Manager
            DistySales //Distributor Sales
        }


        private void LoadDataSets(List<hubspot_engagement> engagementList, SM_Enums.BonusCategoryName bonusCategoryName)
        {

            weeklyEngagementList = engagementList.Where(w => w.hs_date_created.Value >= startDate && w.hs_date_created.Value < endDate.AddDays(1)).OrderBy(o => o.hs_date_created).OrderByDescending(o => o.hs_date_created.Value).ToList();
            hubspot_engagement oldestWeeklyEng = weeklyEngagementList.OrderBy(o => o.date_created).FirstOrDefault();
            hubspot_engagement newestWeeklyEng = weeklyEngagementList.OrderByDescending(o => o.date_created).FirstOrDefault();
            //phoneCallQuery = engagementList.Where(c => c.type.ToLower() == "call").ToList();
            bonusQuery = GetBonusQuery(weeklyEngagementList, bonusCategoryName);
            //conversationQuery = phoneCallQuery.Where(w => w.call_disposition != null && w.call_disposition.ToLower() == "connected").ToList();
            conversationQuery = phoneCallQuery.Where(w => (w.call_disposition ?? "").ToLower() == "connected").ToList();
            salesGoalPointsQuery = GetSalesPointsQuery_Line();
            using (RzDataContext rdc = new RzDataContext())
            {
                rfqQuery = rdc.dealheaders.Where(w => (DateTime)w.date_created >= startDate && (DateTime)w.date_created <= endDate && SelectedAgentIds.Contains(w.base_mc_user_uid)).ToList();

            }

        }

        private List<hubspot_engagement> GetBonusQuery(List<hubspot_engagement> engagementList, SM_Enums.BonusCategoryName bonusCategoryName)
        {
            switch (bonusCategoryName)
            {
                case SM_Enums.BonusCategoryName.PhoneCallCount:
                    return engagementList.Where(c => c.type.ToLower() == "call").ToList();
                case SM_Enums.BonusCategoryName.VideoCreationCount:
                    return engagementList.Where(c => c.type.ToLower() == "note" && c.body.Contains("soapbox.wistia.com/videos/")).ToList();

            }
            return null;
        }

        //public void Load(List<hubspot_engagement> engagementList, List<n_user> al, DateTime start, DateTime end)
        //{
        //    agentList = al;
        //    SelectedAgentIds = al.Select(s => s.unique_id).Distinct().ToList();
        //    startDate = start;
        //    endDate = end;
        //    LoadDataSets(engagementList);
        //    LoadDailySalesTheoryObjects();
        //    LoadWeeklySalesTheoryObjects();
        //}

        public void Load(List<hubspot_engagement> engagementList, List<n_user> al, DateTime start, DateTime end, SM_Enums.BonusCategoryName bonusCategoryName)
        {
            agentList = al;
            SelectedAgentIds = al.Select(s => s.unique_id).Distinct().ToList();
            startDate = start;
            endDate = end;
            LoadDataSets(engagementList, bonusCategoryName);
            LoadDailySalesTheoryObjects(bonusCategoryName);
            LoadWeeklySalesTheoryObjects();
        }


        private List<ordhed_sale> GetSalesPointsQuery()
        {
            List<ordhed_sale> sourceData = null;
            using (RzDataContext rdc = new RzDataContext())
            {
                sourceData = rdc.ordhed_sales.Where(w => ((DateTime)w.date_created >= startDate && (DateTime)w.date_created < endDate) && ((bool)w.isvoid != true) && SelectedAgentIds.Contains(w.base_mc_user_uid)).ToList();

            }

            AddTBDClearedLines(sourceData);
            return sourceData;
        }
        private List<orddet_line> GetSalesPointsQuery_Line()
        {
            List<orddet_line> sourceData = null;
            using (RzDataContext rdc = new RzDataContext())
            {

                sourceData = rdc.orddet_lines.Where(w => ((DateTime)w.orderdate_sales >= startDate && (DateTime)w.orderdate_sales < endDate) && (!SalesLogic.ExcludedStatus.Contains(w.status)) && SelectedAgentIds.Contains(w.seller_uid)).ToList();

            }

            //AddTBDClearedLines(sourceData);
            return sourceData;
        }


        private void AddTBDClearedLines(List<ordhed_sale> sourceData)
        {
            List<orddet_line> tbdCleardLines = new List<orddet_line>();
            // sourceData = rdc.ordhed_sales.Where(w => ((DateTime)w.date_created >= startDate && (DateTime)w.date_created < endDate) && ((bool)w.isvoid != true) && SelectedAgentIds.Contains(w.base_mc_user_uid)).ToList();

            using (RzDataContext rdc = new RzDataContext())
            {
                tbdCleardLines = rdc.orddet_lines.Where(w => (DateTime)w.tbd_cleared_date >= startDate && (DateTime)w.tbd_cleared_date < endDate).ToList();

            }
            if (tbdCleardLines.Count == 0)
                return;
            List<string> existingSaleIds = sourceData.Select(s => s.unique_id).ToList();
            List<string> tbdClearedSaleIds = tbdCleardLines.Select(s => s.orderid_sales).ToList();
            foreach (orddet_line l in tbdCleardLines)
            {
                //If the id DOES exists, then it *should* already have this line's GP included.
                if (!existingSaleIds.Contains(l.unique_id))
                {
                    //Since I need ordhed_sales, let's make a new object, that only contains the amount of the TBD line, else
                    //I'll be returning the entire sale amount, not jsut the update lines.
                    //The changed ID will have a unique_id, can use that to determine total value.
                    ordhed_sale s = new ordhed_sale();
                    s.unique_id = l.orderid_sales;
                    s.ordernumber = l.ordernumber_sales;
                    s.agentname = l.seller_name;
                    s.base_mc_user_uid = l.seller_uid;
                    s.ordertotal = l.total_price;
                    s.gross_profit = l.gross_profit;
                    s.orderdate = l.tbd_cleared_date;
                    sourceData.Add(s);
                }
            }


        }

        public static double GetPercentOfTargetPossible(SalesTheory.SalesTheoryObject o)
        {
            double ret = 1;//1 = 100 percent
            switch (o.salesTheoryAgentType)
            {
                case SalesTheoryAgentType.RM:
                    {
                        ret = .8;
                        break;
                    }

            }
            return ret;

        }



        public void LoadDailySalesTheoryObjects(SM_Enums.BonusCategoryName bonusCategoryName)
        {
            Dictionary<DateTime, List<SalesTheory.SalesTheoryObject>> ret = new Dictionary<DateTime, List<SalesTheoryObject>>();
            if (weeklyEngagementList.Count() == 0)
                return;

            List<DateTime> daysSoFar = weeklyEngagementList.GroupBy(g => g.hs_date_created.Value.Date).Select(s => s.Key).Distinct().ToList();
            foreach (DateTime day in daysSoFar)
            {
                List<SalesTheory.SalesTheoryObject> stoList = new List<SalesTheory.SalesTheoryObject>();
                foreach (n_user u in agentList)
                {
                    SalesTheory.SalesTheoryObject ao = LoadDailySalesTheoryObject(u.unique_id, u.email_address, bonusCategoryName, day);
                    if (ao != null)
                        stoList.Add(ao);
                }
                dailySalesTheoryObjects.Add(day, stoList);
            }
        }


        private SalesTheory.SalesTheoryObject LoadDailySalesTheoryObject(string agent_id, string agent_email, SM_Enums.BonusCategoryName bonusCategoryName, DateTime? singleDay = null)//Use the data to const
        {
            SalesTheory.SalesTheoryObject o = new SalesTheory.SalesTheoryObject();
            //Counts
            //o.phonecallCount = 0;

            o.rfqCount = 0;
            o.salesGoalCount = 0;
            o.conversationCount = 0;
            //Points
            //o.phonecallPoints = 0;

            o.rfqPoints = 0;
            o.salesGoalPoints = 0;
            o.conversationPoints = 0;
            o.salesTheoryAgentType = GetSalesTheoryAgentType(agent_id);

            //Bonus Category
            o.bonusCount = 0;
            o.bonusPoints = 0;
            o.bonusTitle = "";
            o.bonusIconClass = "";


            //The Data
            List<hubspot_engagement> theData = null;
            if (singleDay != null)
                theData = weeklyEngagementList.Where(w => w.hs_date_created.Value.Date == singleDay).ToList();
            else
                theData = weeklyEngagementList;

            int dayCount = theData.Select(s => s.hs_date_created.Value.Date).Distinct().Count();
            if (theData == null)
                return null;



            //var agentQuery = theData.Where(w => w.base_mc_user_uid == agent_id);
            var agentQuery = theData.Where(w => w.ownerEmail.Trim().ToLower() == agent_email.ToLower().Trim());
            int test = agentQuery.Where(w => w.type == "note").Count();
            if (!agentQuery.Any())
                return null;

            //****  At this point, if it's a daily cals, the dataset should already be filtered to the proper day / agent.



            //The Owner / User
            o.rz_user_uid = agent_id;
            o.agentName = agentQuery.Select(s => s.ownerName).FirstOrDefault();
            //o.agentEmail = theData.Select(s => s.ownerEmail.Trim().ToLower()).FirstOrDefault(); //needed for bonus query notes, becausethey dont' have base_mc_user_uid
            hubspot_engagement oldestAgentEng = agentQuery.OrderBy(oo => oo.date_created).FirstOrDefault();
            hubspot_engagement newestAgentEng = agentQuery.OrderByDescending(oo => oo.date_created).FirstOrDefault();

            //Weights:
            ////Phonecalls
            //double phoneCallWeight = GetPhoneCallWeight(o);

            //Bonus
            double bonusWeight = GetBonusWeight(o, bonusCategoryName);
            //Conversations
            int conversationWeight = GetConversationWeight(o);
            //RFQs
            double rfqWeight = GetRfqWeight(o);

            //Sales Goal
            int salesGoalWeight = GetSalesGoalWeight(o);



            ////Phone Calls
            //o.phonecallCount = CalculateAgentPhonecallCount(agentQuery);
            //o.phonecallPoints = CalculateAgentPhonecallPoints(o, phoneCallWeight);

            //Bonus Category
            SetBonusProperties(o, bonusCategoryName);
            o.bonusCount = CalculateAgentBonusCount(agentQuery, bonusCategoryName);
            o.bonusPoints = CalculateAgentBonusPoints(o, bonusWeight, bonusCategoryName);

            //Conversations
            o.conversationCount = CalculateAgentConversationCount(agentQuery);
            o.conversationPoints = o.conversationCount * conversationWeight;
            //Rz Data, no agentQuery needed.
            //RFQs
            o.rfqCount = CalculateAgentRfqCount(agent_id, singleDay);
            o.rfqPoints = o.rfqCount * rfqWeight;
            //10-8-2018 - Switching this to "Percent Of Goal" instead of 20 per day hit
            //MAx of 20, so, what percent of 20 is the actual percent of the goal
            double salesGoalPoints = CalculateAgentDailySalesGoalPoints(agent_id, singleDay);  //CalculateAgentSalesGoalCount(agent_id, agentQuery);
            double salesGoalPointValue = salesGoalPoints * salesGoalWeight;
            //Rounding Up
            o.salesGoalPoints = Math.Ceiling(salesGoalPointValue);





            //Add them all up
            o.currentPoints = CalculateCurrentPoints(o);
            return o;
        }

        private void SetBonusProperties(SalesTheoryObject o, SM_Enums.BonusCategoryName bonusCategoryName)
        {
            switch (bonusCategoryName)
            {
                case SM_Enums.BonusCategoryName.PhoneCallCount:
                    {
                        o.bonusTitle = "PhoneCall Points:";
                        o.bonusIconClass = "fas fa-phone pointSquare-icon";
                        break;
                    }
                case SM_Enums.BonusCategoryName.VideoCreationCount:
                    {
                        o.bonusTitle = "Videos Created:";
                        o.bonusIconClass = "fas fa-film pointSquare-icon";
                        break;
                    }
            }
        }

        private double GetRfqWeight(SalesTheoryObject o)
        {
            //RFQs Current Rule 10/08/2018:   2.5pts / rfq
            //if (o.agentName == "Chris Sikora")
            //    return 1;
            if (o.agentName == "Phil Scott")
                return 0;
            return 2.5;
        }

        private int GetSalesGoalWeight(SalesTheoryObject o)
        {
            //if (o.agentName == "Chris Sikora")
            //    return 0;
            return 20;
        }

        private double GetPhoneCallWeight(SalesTheoryObject o)
        {
            switch (o.salesTheoryAgentType)
            {
                case SalesTheoryAgentType.DistySales:
                    return 1;
                case SalesTheoryAgentType.Sales:
                    return .5;
            }
            return .5;
        }



        private double GetBonusWeight(SalesTheoryObject o, SM_Enums.BonusCategoryName bonusName)
        {
            //10 points for a video
            switch (bonusName)
            {
                case SM_Enums.BonusCategoryName.PhoneCallCount:
                    return GetPhoneCallWeight(o);
                case SM_Enums.BonusCategoryName.VideoCreationCount:
                    return 10;
            }
            return 0;
        }

        private int GetConversationWeight(SalesTheoryObject o)
        {
            switch (o.salesTheoryAgentType)
            {
                case SalesTheoryAgentType.DistySales:
                    {
                        //if (o.agentName == "Chris Sikora")
                        //    return 2;
                        //else if (o.agentName == "Phil Scott")
                        return 5;
                    }
                case SalesTheoryAgentType.Sales:
                    return 5;
            }
            return 5;
        }


        private SalesTheory.SalesTheoryAgentType GetSalesTheoryAgentType(string agent_id)
        {
            using (RzDataContext rdc = new RzDataContext())
            {
                n_user u = rdc.n_users.Where(w => w.unique_id == agent_id).FirstOrDefault();
                if (u == null)
                    return SalesTheory.SalesTheoryAgentType.Sales;
                switch (u.name)
                {

                    case "Phil Scott":
                        return SalesTheory.SalesTheoryAgentType.DistySales;
                }
                //default if we've reached here.
                return SalesTheory.SalesTheoryAgentType.Sales;
            }
        }



        private int GetAgentConversationWeight(SalesTheory.SalesTheoryObject o)
        {
            //Current Rule 9/20/2018:   5pts / RM, 3 sales
            int ret = 3;
            switch (o.salesTheoryAgentType)
            {
                case SalesTheory.SalesTheoryAgentType.RM:
                    ret = 5;
                    break;
            }
            return ret;
        }



        private int CalculateAgentConversationCount(IEnumerable<hubspot_engagement> agentQuery)
        {
            int conversationCount = 0;
            string agentName = agentQuery.Select(s => s.ownerName).FirstOrDefault();
            var query = agentQuery.Where(w => w.type.ToLower() == "call" && w.call_disposition != null && w.call_disposition.ToLower() == "connected");
            if (query.Any())
                conversationCount = query.Count();
            return conversationCount;
        }

        private double CalculateCurrentPoints(SalesTheory.SalesTheoryObject o)
        {
            //Figure out total possible, i.e. RM's won't get Sales, so they are total of 80.
            //Then see what percent of that target total is achieved                  
            double tally = 0;
            //tally += o.phonecallPoints;
            tally += o.bonusPoints;
            tally += o.rfqPoints;
            tally += o.salesGoalPoints;
            tally += o.conversationPoints;
            return tally;
        }

        private double CalculateCurrentPointsByAgentType(SalesTheory.SalesTheoryObject o)
        {
            //Figure out total possible, i.e. RM's won't get Sales, so they are total of 80.
            //Then see what percent of that target total is achieved
            double targetTotal = 100;
            double percentOfTargetPossible = SalesTheory.GetPercentOfTargetPossible(o);
            targetTotal = targetTotal * percentOfTargetPossible;//i.e. 100 * .8 = 80
            double tally = 0;
            tally += o.bonusPoints;
            tally += o.rfqPoints;
            tally += o.salesGoalPoints;
            tally += o.conversationPoints;

            double ret = 0;
            ret = (tally / targetTotal) * 100;
            //Round up for even numbers:        
            return ret;
        }



        private int CalculateAgentSalesGoalCount(string agent_id, IEnumerable<hubspot_engagement> agentQuery)
        {
            int ret = 0;
            return ret;
        }


        private double CalculateAgentDailySalesGoalPoints(string agent_id, DateTime? theDate = null)
        {

            double ret = 0;
            double totalPoints = 0;
            //Get the curretn User
            n_user u = agentList.Where(w => w.unique_id == agent_id).FirstOrDefault();
            //Get Current User's monthly goal
            double monthlyGoal = 0;
            using (RzDataContext rdc = new RzDataContext())
            {
                monthlyGoal = (double)rdc.n_users.Where(w => w.unique_id == u.unique_id).Select(s => s.monthly_np_goal ?? 0).FirstOrDefault();
            }

            //If no goal, no points awarded
            if (monthlyGoal <= 0)
                return 0;

            //Get the days where sales were made, get percentage of daily goal as points
            List<int> daysWithSales = new List<int>();
            //Filter the main query.
            var calcQuery = salesGoalPointsQuery.Where(w => w.seller_uid == agent_id);
            if (theDate != null)
                calcQuery = calcQuery.Where(w => w.orderdate_sales.Value.Date == theDate.Value.Date);
            //Set the days WithSales Value.
            daysWithSales = calcQuery.Select(s => s.orderdate_sales.Value.Day).Distinct().ToList();
            //No days with salles, award no points.
            if (daysWithSales.Count <= 0)
                return 0;
            //Loop through each of the potentially 7 days in teh source data, and get their day numbers, i.e. 13, 31, 28, 1, etc.
            foreach (int day in daysWithSales)
            {
                //Saily sales goal
                double dailyGP = 0;
                double dailyGoal = monthlyGoal / 21;
                //Get the gp total for this day
                dailyGP += calcQuery.Where(w => w.orderdate_sales.Value.Day == day).Sum(s => (double)s.gross_profit);
                //Capping at 100$ (i.e. 1)
                if (dailyGP >= dailyGoal)
                    totalPoints += 1;//1 = 100%
                else
                {
                    //So for multuple days on a weekly calc, we'lll get a percent of the sum?  WIll that work?
                    //is shuould, day1 = 50%, day 2 = 50%, calc for those days would be (100)/100 * weight
                    totalPoints += (dailyGP / dailyGoal);
                }


            }
            //Divide the total sales of days where the goal was met by total possible days to meet it
            ret = totalPoints;

            return ret;

        }




        private int CalculateAgentRfqCount(string agent_uid, DateTime? theDate)
        {


            int batchCount = 0;
            //Filter the dataset
            var calcQuery = rfqQuery.Where(w => w.base_mc_user_uid == agent_uid);
            if (theDate != null)
                calcQuery = rfqQuery.Where(w => w.base_mc_user_uid == agent_uid && w.date_created.Value.Date == theDate);
            //Get the agentName for debugging
            string agentName = calcQuery.Select(s => s.agentname).FirstOrDefault();
            //List of days that contain rfq's
            List<int> daysWithRfqs = new List<int>();//Actual date numbers in the week, i.e. MAy 4th = 4
            daysWithRfqs = calcQuery.Select(s => s.date_created.Value.Day).Distinct().ToList();
            //If no days with Rfq's return 0
            if (daysWithRfqs.Count <= 0)
                return 0;
            //Must be linked at least to a company
            List<string> companyIDList = calcQuery.Select(s => s.customer_uid).Distinct().ToList();
            //Else return 0
            if (companyIDList.Count <= 0)
                return 0;
            //Get List of distinct contact IDs, only all 3 RFQ's per company contact, per day.
            List<string> contactIDList = calcQuery.Select(s => s.contact_uid ?? "").Distinct().ToList();

            //For each of the days with Rfq;s
            foreach (int day in daysWithRfqs)
            {
                //For each on the contacts in these RFQs
                foreach (string c in contactIDList)
                {
                    //Get the total numbers of deals for this contact for this day.
                    int dayContactDealCount = calcQuery.Count(w => w.contact_uid == c && w.date_created.Value.Day == day);
                    //Note:  The idea of capping RFQs is justified, I believe, as many different parts in the same day is indicitative
                    //of BOM uploads (whis are 1-shot earnings if you will) as well as agents getting bid-spammed (customer sending large BCC with list to award lowest bidder on low-margin parts)
                    //therefore, cap at 3 will discourage time spent on such without some consideration / managerial guidance

                    //Cap this to only allow max 3 batches per contact at a company (see above)
                    if (dayContactDealCount >= 3)
                        batchCount += 3;
                    else
                        batchCount += dayContactDealCount;

                }
            }
            return batchCount;
        }



        private int CalculateAgentBonusCount(IEnumerable<hubspot_engagement> agentQuery, SM_Enums.BonusCategoryName bonusCategoryName)
        {
            switch (bonusCategoryName)
            {
                case SM_Enums.BonusCategoryName.PhoneCallCount:
                    {
                        return CalculateAgentPhoneCallCount(agentQuery);
                    }
                case SM_Enums.BonusCategoryName.VideoCreationCount:
                    {
                        return CalculateAgentVideoCount(agentQuery);

                    }
            }
            return 0;
        }

        private double CalculateAgentBonusPoints(SalesTheoryObject o, double bonusWeight, SM_Enums.BonusCategoryName bonusCategoryName)
        {
            switch (bonusCategoryName)
            {
                case SM_Enums.BonusCategoryName.PhoneCallCount:
                    {
                        return CalculateAgentPhonecallPoints(o, bonusWeight);
                    }
                case SM_Enums.BonusCategoryName.VideoCreationCount:
                    {
                        return CalculateAgentVideoCreationPoints(o, bonusWeight);
                    }
            }

            return 0;
        }

        private double CalculateAgentVideoCreationPoints(SalesTheoryObject o, double bonusWeight)
        {
            double goal = 10; // weight = 1, so only 1 video needed.
            double ret = o.bonusCount * bonusWeight;
            if (o.bonusCount >= 1)
                return 10;
            return 0;
        }


        //private int CalculateAgentPhonecallCount(IEnumerable<hubspot_engagement> engQuery)
        //{
        //    return CalculateWeeklyAgentPhoneCallPoints(engQuery);
        //}


        private double CalculateAgentPhonecallPoints(SalesTheoryObject o, double phoneCallWeight)
        {
            double goal = GetPhoneCallGoal(o);
            double ret = o.bonusCount * phoneCallWeight;
            if (o.bonusCount >= goal)
                ret += 10;
            return ret;

        }

        private double GetPhoneCallGoal(SalesTheoryObject o)
        {

            switch (o.salesTheoryAgentType)
            {
                case SalesTheoryAgentType.DistySales:
                    return 50;
            }
            //Sales
            return 80;
        }


        //public void LoadWeeklySalesTheoryObjects()
        //{
        //    if (weeklyEngagementList.Count() == 0)
        //        return;


        //    foreach (n_user u in agentList)
        //    {
        //        SalesTheory.SalesTheoryObject ao = LoadSalesTheoryObject(u.unique_id);
        //        if (ao != null)
        //            weeklySalesTheoryObjects.Add(ao);
        //    }


        //}



        public void LoadWeeklySalesTheoryObjects()
        {
            if (dailySalesTheoryObjects.Count() == 0)
                return;


            List<SalesTheoryObject> totalList = new List<SalesTheoryObject>();
            foreach (List<SalesTheoryObject> soList in dailySalesTheoryObjects.Values.ToList())
            {

                foreach (SalesTheoryObject so in soList)
                {
                    totalList.Add(so);
                }
            }

            if (totalList.Count == 0)
                return;
            foreach (string rzUserID in totalList.Select(s => s.rz_user_uid).Distinct())
            {

                SalesTheoryObject weeklyObject = new SalesTheoryObject();
                var individualAgentList = totalList.Where(w => w.rz_user_uid == rzUserID).ToList();
                //Agent uid
                // string rzUSerID = tempList.Select(s => s.rz_user_uid).FirstOrDefault();
                weeklyObject.rz_user_uid = rzUserID;
                //Agent Name
                weeklyObject.agentName = individualAgentList.Select(s => s.agentName).FirstOrDefault();
                //Agent Image
                weeklyObject.agentImageUrl = individualAgentList.Select(s => s.agentImageUrl).FirstOrDefault();

                //Bonus Category
                weeklyObject.bonusCount = individualAgentList.Sum(s => s.bonusCount);
                weeklyObject.bonusPoints = individualAgentList.Sum(s => s.bonusPoints);
                weeklyObject.bonusTitle = individualAgentList.Select(s => s.bonusTitle).FirstOrDefault();
                weeklyObject.bonusIconClass = individualAgentList.Select(s => s.bonusTitle).FirstOrDefault();

                //Convesations
                weeklyObject.conversationCount = individualAgentList.Sum(s => s.conversationCount);
                weeklyObject.conversationPoints = individualAgentList.Sum(s => s.conversationPoints);
                //RFQ
                weeklyObject.rfqCount = individualAgentList.Sum(s => s.rfqCount);
                weeklyObject.rfqPoints = individualAgentList.Sum(s => s.rfqPoints);
                //Sales
                weeklyObject.salesGoalCount = individualAgentList.Sum(s => s.salesGoalCount);
                weeklyObject.salesGoalPoints = individualAgentList.Sum(s => s.salesGoalPoints);
                //Total
                weeklyObject.currentPoints = individualAgentList.Sum(s => s.currentPoints);
                weeklySalesTheoryObjects.Add(weeklyObject);
            }


        }










        private int CalculateAgentPhoneCallCount(IEnumerable<hubspot_engagement> engQuery)
        {



            //Get Number of days so far.
            string agent = "";
            agent = engQuery.Select(w => w.ownerName).FirstOrDefault();
            int ret = 0;
            ret += CalculateDailyAgentPhoneCallCount(engQuery);
            return ret;
            //List<string> days = engQuery.Select(s => s.hs_date_created.Value.ToShortDateString()).Distinct().ToList();
            ////List<int> currentDays = engQuery.Select(s => s.hs_date_created.Value.Day).Distinct().ToList();
            //foreach (string day in days)
            //{
            //    DateTime date = DateTime.Parse(day);
            //    var query = engQuery.Where(w => w.hs_date_created.Value.Day == date.Day);
            //    ret += CalculateDailyAgentPhoneCallCount(query);
            //}
            //return ret;
        }

        private int CalculateDailyAgentPhoneCallCount(IEnumerable<hubspot_engagement> agentQuery)
        {//Current Rule 9/20/2018:   .5pts / call
            int ret = 0;

            int currentCount = agentQuery.Where(w => w.type == "CALL").Count();
            if (currentCount > 0)
                ret = currentCount;
            return ret;
        }



        private int CalculateAgentVideoCount(IEnumerable<hubspot_engagement> agentQuery)
        {
            //Get Number of days so far.
            string agent = "";
            agent = agentQuery.Select(w => w.ownerName).FirstOrDefault();
            int ret = 0;
            ret += CalculateAgentVideoPoints(agentQuery);
            return ret;
            //List<int> days = agentQuery.Select(s => s.hs_date_created.Value.Day).Distinct().ToList();
            ////List<int> currentDays = engQuery.Select(s => s.hs_date_created.Value.Day).Distinct().ToList();
            //foreach (int day in days)
            //{
            //    //DateTime date = DateTime.Parse(day);
            //    var query = agentQuery.Where(w => w.hs_date_created.Value.Day == day);
            //    ret += CalculateDailyAgentVideoPoints(query);
            //}
            //return ret;

        }


        private class WistiaVideoObject
        {
            public string videoID { get; set; }
            public DateTime date_created { get; set; }
        }


        private int CalculateAgentVideoPoints(IEnumerable<hubspot_engagement> agentQuery)
        {
            //Current Rule 9/20/2018:   .5pts / call
            int currentCount = 0;
            List<WistiaVideoObject> wvList = new List<WistiaVideoObject>();
            //Requires users to past the url into a note field:
            var noteQuery = agentQuery.Where(w => w.type.ToLower() == "note");
            currentCount = noteQuery.Where(w => w.body.Contains("soapbox.wistia.com/videos")).Count();

            ////For Emails with soapbox in body - causes duplication unless you can store previus emails in a database table to check if they are new or old IDs
            ////Exmaple ID: //IGKRnVOpGC
            //var emailQuery = agentQuery.Where(w => w.type.ToLower() == "email");
            //var wistiaQuery = emailQuery.Where(w => w.html != null && w.html.Contains("soapbox.wistia.com/videos"));
            //foreach (hubspot_engagement he in wistiaQuery)
            //{
            //    string html = he.html;
            //    string wholeString = he.html;
            //    string startString = "soapbox.wistia.com/videos/";
            //    string endString = " ";

            //    string wistiaID = Tools.Strings.GetStringBetweenTwoStrings(wholeString, startString);
            //    if (string.IsNullOrEmpty(wistiaID))
            //        continue;

            //    WistiaVideoObject wv = new WistiaVideoObject();
            //    wv.videoID = wistiaID;
            //    wvList.Add(wv);
            //}
            //var queryDistinctVideoIds = wvList.Select(s => s.videoID).Distinct().ToList();
            //currentCount = queryDistinctVideoIds.Count();

            return currentCount;
        }





    }
    public class LineLogic
    {
        [Serializable]
        public class TbdLineObject
        {
            public string unique_id { get; set; }
            public string date_created { get; set; }
            public string fullpartnumber { get; set; }
            public string manufacturer { get; set; }
            public string sales_order { get; set; }
            public string quantity { get; set; }
            public string unit_price { get; set; }
            public string status { get; set; }
            public string customer_name { get; set; }
            public string vendor_name { get; set; }
            public string seller_name { get; set; }
            public string customer_dock { get; set; }
          

        }

        public static List<TbdLineObject> GetTBDLines()
        {
            List<TbdLineObject> ret = new List<TbdLineObject>();
            List<orddet_line> linesList = new List<orddet_line>();

            using (RzDataContext rdc = new RzDataContext())
            {
                linesList = rdc.orddet_lines.Where(w => w.vendor_name == "Source TBD" && w.status != "void" && ((w.fullpartnumber ?? "").Length > 0)).ToList();
                

            }
               
            if (linesList.Count <= 0)
                return ret;//return empty list
            foreach (orddet_line l in linesList)
            {
                TbdLineObject lo = new TbdLineObject();
                lo.unique_id = l.unique_id;
                lo.date_created = l.date_created.Value.ToShortDateString();
                lo.fullpartnumber = l.fullpartnumber;
                lo.manufacturer = l.manufacturer;
                lo.sales_order = l.ordernumber_sales;
                lo.quantity = l.quantity.ToString();
                lo.unit_price = l.unit_price.ToString();
                lo.status = l.status;
                lo.customer_name = l.customer_name;
                lo.vendor_name = l.vendor_name;
                lo.seller_name = l.seller_name;
                lo.customer_dock = l.customer_dock_date.Value.ToShortDateString();
                ret.Add(lo);
            }
            return ret;
        }

        public static void GenerateSourceTBDEmailReport()
        {
            List<TbdLineObject> tbdList = LineLogic.GetTBDLines();
            string subject = "Source TBD Email Report";

            double total = 0;





            string body = "";
            foreach (LineLogic.TbdLineObject lo in tbdList)
            {
                double LineTotal = (Convert.ToDouble(lo.unit_price) * Convert.ToDouble(lo.quantity));
                total += LineTotal;
                body += "Created: " + lo.date_created + " | ";
                body += "Company: " + lo.customer_name + " | ";
                body += "Agent: " + lo.seller_name + " | ";
                body += "Part: " + lo.fullpartnumber.Trim().ToUpper() + " | ";
                body += "MFG: " + lo.manufacturer.Trim().ToUpper() + " | ";
                body += "Sale: " + lo.sales_order.Trim().ToUpper() + " | ";
                body += "QTY: " + lo.quantity.Trim().ToUpper() + " | ";
                body += "Price: " + LineTotal.ToString("C") + " | ";
                body += "Status: " + lo.status;
                body += "<br />";
            }
            //List<string> ccList = new List<string>() { "ktill@sensiblemicro.com" };
            string bodyintro = "<strong> Here are the current Source TBD Lines. Total: " + total.ToString("C") + "</strong> <br /><br />";
            SystemLogic.Email.SendMail("tbd@sensiblemicro.com", "sales@sensiblemicro.com", subject, bodyintro + body, null);

        }


    }
    public class SourcingLogic
    {
        [Serializable]
        public class SourcingObject
        {
            public string ordernumber { get; set; }
            public string orderType { get; set; }
            public string agent { get; set; }
            public string customer { get; set; }
            public DateTime orderdate { get; set; }
            public double ordertotal { get; set; }
            public string sourcing_status { get; set; }
            public string validation_stage { get; set; }
            public string orderreference { get; set; }
            public string comment { get; set; }
            public bool hasUnshippedLateLines { get; set; } //This is to handle schedule ships.   Omit orders where the only unshipped lines and a future proj dock date.
            public string lastValidationTrackingReason { get; set; }

        }
        public static List<SourcingObject> GetSourcingObjects(DateTime startDate, DateTime today)
        {
            List<SourcingObject> ret = new List<SourcingObject>();
            using (RzDataContext rdc = new RzDataContext())
            {
                var quoteQuery = rdc.ordhed_quotes.Where(w => w.date_created.Value >= startDate && (w.orderreference != null && w.orderreference.Length > 0) && w.isclosed.Value != true && w.isvoid.Value != true);
                //Create the objects
                ret.AddRange(quoteQuery.Select(s => new SourcingObject {
                    ordernumber = s.ordernumber,
                    agent = s.agentname,
                    customer = s.companyname,
                    orderdate = s.orderdate.Value,
                    ordertotal = s.ordertotal.Value,
                    orderreference = s.orderreference,
                    orderType = "Quote",
                    sourcing_status = GetSourcingSatatus_Quote(s),
                    validation_stage = "Quoting",
                    comment = s.internalcomment,
                    hasUnshippedLateLines = true,
                    lastValidationTrackingReason = "Quoting"
                }).ToList());

               
                var salesQuery = rdc.ordhed_sales.Where(w => w.date_created.Value >= startDate && (w.orderreference != null && w.orderreference.Length > 0) && w.isclosed.Value != true && w.isvoid.Value != true);
                List<orddet_line> lineQuery = rdc.orddet_lines.Where(w => salesQuery.Select(s => s.unique_id).Distinct().ToList().Contains(w.unique_id) && w.status != "shipped" && w.projected_dock_date.Value.Date <= DateTime.Today).ToList();

             


                List<validation_tracking> validationTrackingObjectList = rdc.validation_trackings.Where(w => salesQuery.Select(s => s.unique_id).Distinct().ToList().Contains(w.orderid_sales)).ToList();
                //Create the objects
                ret.AddRange(salesQuery.Select(s => new SourcingObject {
                    ordernumber = s.ordernumber,
                    agent = s.agentname,
                    customer = s.companyname,
                    orderdate = s.orderdate.Value,
                    ordertotal = s.ordertotal.Value,
                    orderreference = s.orderreference,
                    orderType = "Sale",
                    sourcing_status = GetSourcingSatatus_Sales(s),
                    validation_stage = s.validation_stage,
                    comment = s.internalcomment,
                    hasUnshippedLateLines = OrderHasUnshippedLateLines(lineQuery, s),
                    lastValidationTrackingReason = GetLastValidationTrackingReason(validationTrackingObjectList, s)
                }).ToList());

            }
            SourcingObject testSale = ret.Where(w => w.ordernumber == "211487").FirstOrDefault();
            return ret;

        }

        private static string GetLastValidationTrackingReason(List<validation_tracking> validationTrackingObjectList, ordhed_sale s)
        {
            string lastReason = validationTrackingObjectList.Where(w => w.orderid_sales == s.unique_id).OrderByDescending(oo => oo.date_created.Value).Select(ss => ss.hold_reason).FirstOrDefault();
            //Since this shows in other grids, if blank, let's return the validation stage
            if (string.IsNullOrEmpty(lastReason))
                lastReason = s.validation_stage;
            return lastReason;
        }

        private static bool OrderHasUnshippedLateLines(List<orddet_line> lineQuery, ordhed_sale s)
        {
            return lineQuery.Where(w => w.orderid_sales == s.unique_id).Any();
        }

        private static string GetSourcingSatatus_Quote(ordhed_quote q)
        {
            
            if (q.ready_to_validate ?? false)
                return "ReadyToValidate";
            else
                return "NR";//Not Ready

        }
        private static string GetSourcingSatatus_Sales(ordhed_sale s)
        {
            using (RzDataContext rdc = new RzDataContext())
            {
                if (rdc.orddet_lines.Where(l => l.orderid_sales == s.unique_id && l.line_validation_status == SM_Enums.LineValidationStatus.ReSourced.ToString()).Any())
                    return SM_Enums.LineValidationStatus.ReSourced.ToString();
            }

            return "SaleCreated";
            
        }
    }

}
