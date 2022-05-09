using SensibleDAL.dbml;
using SensibleDAL.ef;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SensibleDAL
{
    public class ShippingLogic
    {
        [Serializable]
        public class priorityObject
        {
            public string line_uid { get; set; }
            public string salesAgent { get; set; }
            public string salesAgentID { get; set; }
            //public int priorityWeight { get; set; }
            public string customerName { get; set; }
            public string customerID { get; set; }
            public DateTime customerDock { get; set; }
            public DateTime projectedDock { get; set; }
            public string vendorName { get; set; }
            public string vendorID { get; set; }
            public string ordernumberSales { get; set; }
            public string orderIDSales { get; set; }
            public DateTime orderDateSales { get; set; }
            public string ordernumberPurchase { get; set; }
            public string orderIDPurchase { get; set; }
            public DateTime dockDate { get; set; }
            public DateTime recievedDate { get; set; }
            public double grossProfit { get; set; }
            public double totalPrice { get; set; }
            public string saleTerms { get; set; }
            public string poTerms { get; set; }
            //public int estimatedDaysToProcess { get; set; }
            public string qcStatus { get; set; }
            //public DateTime processByDate { get; set; }
            //public int priorityValue { get; set; }
            public string partNumber { get; set; }
            public int qty { get; set; }
            public int gpPriority { get; set; }
            public int datePriority { get; set; }
            public string lineStatus { get; set; }
            public int linePriority { get; set; }
            public bool hasManualPriority { get; set; }
            public string idea_insp_id { get; set; }
            public int lineCount { get; set; } //Count of lines on an order.



        }

        public static List<string> GetUnshippedStatus()
        {
            return new List<string>() { "buy", "open", "hold", "rma receiving", "out for service", "packing", "received from service", "packing for service", "preinvoiced" };
        }

        public static List<string> GetIgnoredStatus()
        {
            return new List<string>() { "quarantined", "scrapped", "void", "shipped", "hold", "rma" };
        }



        private static int GetDayCountFromTermsString(string poTerms)
        {
            string termString = poTerms.ToLower();
            List<string> payImmediatelyTerms = new List<string>() { "cod", "cc", "credit card", "visa", "mastercard", "dicsover", "amex", "american express", "wire transfer", "wire in advance", "escrow", "paypal" };
            if (payImmediatelyTerms.Contains(termString))
                return 0;


            if (termString.Contains("30"))
                return 30;
            if (termString.Contains("60"))
                return 60;
            if (termString.Contains("50"))
                return 50;
            if (termString.Contains("45"))
                return 45;
            if (termString.Contains("40"))
                return 40;
            if (termString.Contains("30"))
                return 30;
            if (termString.Contains("20"))
                return 20;
            if (termString.Contains("15"))
                return 15;
            if (termString.Contains("7"))
                return 7;
            ///Keep this at the end, so it doesn't get triggered by numbers like 15
            if (termString.Contains("1"))
                return 1;

            return 5;//arttifically returning an aggressive turnaround when actual term can't be determined.
        }


        private static int CheckShipPriorityCustomerDock(orddet_line l)
        {
            int ret = 0;
            DateTime today = DateTime.Today;
            TimeSpan ts = (DateTime)l.customer_dock_date - today;
            ret = ts.Days;
            if (l.customer_dock_date > DateTime.Today)//Future dates will be lower priority, therefore negative
                ret = ret * -1;
            return ret;
        }

        private static int CheckShipPriorityProjectedDock(orddet_line l)
        {
            int ret = 0;
            DateTime today = DateTime.Today;
            DateTime Proj = l.projected_dock_date ?? l.customer_dock_date.Value;
            TimeSpan ts = Proj - today;
            ret = ts.Days;
            return ret;
        }


        private static int CheckShipPriorityGP(orddet_line l)
        {
            int ret = 0;
            int gpWeight = 5;
            double gp = l.gross_profit ?? 0;
            if (gp > 10000)
            {
                double divisor = 0;
                divisor = gp / 10000;
                ret = Convert.ToInt32(Math.Floor(divisor));
            }
            return ret * gpWeight;
        }


        //public static int CheckShipDatePriority(orddet_line l, ordhed_purchase p = null)
        //{
        //    //Date Due is determined by the amout of days we have to pay the vendor vs vs the amount of days to ship to customer
        //    //i.e. daysToPayVendor vs. daysTilDock
        //    //Days to pay vendor depends on date of receive 
        //    //If we haven't received it, then the clock to pay hasn't started ticking, so we don't worry about po Terms.          
        //    //However if the customer dock is in the future, should have a lower (negative) priority        

        //    int daysTillDock = CheckShipPriorityProjectedDock(l);//Negative Values are in the future
        //                                                         //if (daysTillDock < 0)
        //    //daysTillDock = daysTillDock * -1;
        //    if (l.receive_date_actual == new DateTime(1900, 01, 01))//HAven't received, no worry, set to Customer Dock
        //        return daysTillDock;
        //    //else if (p != null)
        //    //{
        //    //    int daysToPayVendor = CheckDaysToPayVendor(l, p);
        //    //    if (daysToPayVendor > daysTillDock) //The higher value should return here, lower value = less priority.
        //    //        return daysToPayVendor;
        //    //}
        //    return daysTillDock;

        //}

        //public static int CheckShipDatePriority(orddet_line l, ordhed_purchase p = null)
        //{

        //    //positive value = future, negative = past, = today.
        //    int totalDays = CheckShipPriorityProjectedDock(l) * -1;

        //    //Multiple total days by -1, meaning the farther in the futurem, the lower the pri, conversely, past due inspection will get a higher priority.
        //    return totalDays;
        //}

        public static int CheckShipDatePriority(orddet_line l)
        {

            //positive value = future, negative = past, = today.
            int totalDays = CheckShipPriorityProjectedDock(l) * -1;

            //Multiple total days by -1, meaning the farther in the futurem, the lower the pri, conversely, past due inspection will get a higher priority.
            return totalDays;
        }

        public static Dictionary<string, string> LoadShippingAccountDictionary(string companyID, Dictionary<string, string> otherDict, bool includeEmporium = false)//, bool includeInternal = false)
        {
            company c = null;
            Dictionary<string, string> dictShippingAddresses = new Dictionary<string, string>();
            using (RzDataContext rdc = new RzDataContext())
            {
                c = rdc.companies.Where(w => w.unique_id == companyID).FirstOrDefault();
                if (c != null)
                {
                    List<shippingaccount> sList = rdc.shippingaccounts.Where(w => (w.accountnumber ?? "").Length > 0 && w.base_company_uid == c.unique_id).OrderBy(oo => oo.accountnumber).ToList();
                    //ArrayList a = RzWin.Context.SelectScalarArray("SELECT DISTINCT(ACCOUNTNUMBER) FROM shippingaccount WHERE accountnumber > '' and base_company_uid = '" + CurrentOrder.CompanyVar.RefGet(RzWin.Context).unique_id + "' ORDER BY ACCOUNTNUMBER");

                    foreach (shippingaccount s in sList)
                    {
                        string text = s.description.ToUpper();
                        KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(s.accountnumber, text);
                        if (!dictShippingAddresses.ContainsKey(kvp.Key))
                            dictShippingAddresses.Add(kvp.Key, kvp.Value);
                    }
                }

                // n_set.SetSetting(context, "internal_ups", value);
                string smUpsAcct = rdc.n_sets.Where(w => w.name == "internal_ups").Select(s => s.setting_value).FirstOrDefault();
                if (!string.IsNullOrEmpty(smUpsAcct))
                    dictShippingAddresses.Add(smUpsAcct, "SM UPS");
                string smFedexAcct = rdc.n_sets.Where(w => w.name == "internal_fedex").Select(s => s.setting_value).FirstOrDefault();
                if (!string.IsNullOrEmpty(smFedexAcct))
                    dictShippingAddresses.Add(smFedexAcct, "SM Fedex");
                string smDhlAcct = rdc.n_sets.Where(w => w.name == "internal_dhl").Select(s => s.setting_value).FirstOrDefault();
                if (!string.IsNullOrEmpty(smDhlAcct))
                    dictShippingAddresses.Add(smDhlAcct, "SM DHL");

            }



            //if(includeInternal)
            //{
            //ret.Add("---Sensible Accounts---");
            dictShippingAddresses.Add("Free-Freight", "");
            //dictShippingAddresses.Add("Pre-Paid", "Pre-Paid");
            dictShippingAddresses.Add("Pre-Pay & Add", "Add");
            dictShippingAddresses.Add("Pre-Pay & Don't Add", "Don't Add");
            //}

            if (includeEmporium)
            {
                //KT Emporium Partners:
                string EmporiumUPS = "AR4350";
                string EmporiumDHL = "959472253";
                dictShippingAddresses.Add(EmporiumDHL, "Emporium DHL");
                dictShippingAddresses.Add(EmporiumUPS, "Emporium UPS");

            }

            //For adding any other addresses, including any manual ones that may not be pard of the DDL
            if (otherDict != null)
                foreach (KeyValuePair<string, string> kvp in otherDict)
                {
                    if (!string.IsNullOrEmpty(kvp.Key))
                        if (!dictShippingAddresses.ContainsKey(kvp.Key))
                            dictShippingAddresses.Add(kvp.Key, kvp.Value);
                }
            return dictShippingAddresses;
        }

        //private static int CheckDaysToPayVendor(orddet_line l, ordhed_purchase p)
        //{
        //    //return variable gives us how many days left until we have to pay the vendor
        //    int daysLeftToPayVendor = 0;
        //    //Get the receive data ctual
        //    DateTime actualReceiveDate = (DateTime)l.receive_date_actual; //  1900/1/1 if null
        //                                                                  //Get Number of days to pay based on terms
        //    int daysToPayFromReceive = GetDayCountFromTermsString(p.terms);
        //    //Add number of days to pay to recieve data actual to get the date Due date to pay the vendor (negative if in past)
        //    DateTime dateDueToPayVendor = actualReceiveDate.AddDays(daysToPayFromReceive);
        //    //This date is either in the pat or in the future.  Compare this date to today, and get totalDays
        //    TimeSpan tsToPayVendor = DateTime.Today.Date - dateDueToPayVendor.Date; //.date means we ignore time, therefore a time 12 hours in the past should return 1 even though not a full day.
        //    daysLeftToPayVendor = tsToPayVendor.Days;

        //    if (dateDueToPayVendor < DateTime.Today)
        //        daysLeftToPayVendor = daysLeftToPayVendor * -1;


        //    return daysLeftToPayVendor;
        //}




        //public static List<priorityObject> GetInboundPriorityLines(DateTime startDate, DateTime? endDate = null)
        //{

        //    //Rz Where
        //    //and status in ('Buy', 'Open', 'Hold', 'Out For Service', 'RMA Receiving')
        //    //and len(isnull(orderid_sales, 0)) > 0
        //    //and status not in ('hold')
        //    //and fullpartnumber not like '%GCAT%'

        //    using (RzDataContext rdc = new RzDataContext())
        //    {
        //        if (endDate == null)
        //            endDate = DateTime.MaxValue;

        //        List<orddet_line> lineList = rdc.orddet_lines
        //            .Where(
        //            w => (w.orderid_sales ?? "").Length > 0
        //            && (w.customer_dock_date.Value.Date >= startDate.Date && w.customer_dock_date.Value.Date <= endDate.Value.Date)
        //            && !w.fullpartnumber.ToLower().Contains("gcat")
        //            && GetUnshippedStatus().Contains(w.status.ToLower())
        //            && !GetIgnoredStatus().Contains(w.status.ToLower())
        //            ).ToList();
        //        List<string> lineListIds = lineList.Select(s => s.unique_id).Distinct().ToList();
        //        //List<string> lineListSaleIds = lineList.Select(s => s.orderid_sales).Distinct().ToList();
        //        List<string> lineListPurchaseIds = lineList.Select(s => s.orderid_purchase).Distinct().ToList();
        //        //List<ordhed_sale> saleList = rdc.ordhed_sales.Where(w => lineListSaleIds.Contains(w.unique_id)).ToList();
        //        List<ordhed_purchase> purchaseList = rdc.ordhed_purchases.Where(w => lineListPurchaseIds.Contains(w.unique_id)).ToList();





        //        //Get Priorirty Objects relating to this group of lines, so it can be queried below:
        //        List<line_process> lpList = new List<line_process>();
        //        lpList = rdc.line_processes.Where(w => lineListIds.Contains(w.orddet_line_uid)).ToList();



        //        List<priorityObject> ret = new List<priorityObject>();


        //        foreach (orddet_line l in lineList)
        //        {
        //            priorityObject pp = new priorityObject();
        //            ordhed_purchase p = purchaseList.Where(w => w.unique_id == l.orderid_purchase).FirstOrDefault();


        //            pp.line_uid = l.unique_id ?? "";
        //            pp.salesAgent = l.seller_name ?? "";
        //            pp.partNumber = l.fullpartnumber ?? "";
        //            pp.salesAgentID = l.seller_uid ?? "";
        //            pp.ordernumberSales = l.ordernumber_sales ?? "";
        //            pp.orderIDSales = l.orderid_sales ?? "";
        //            pp.customerName = l.customer_name ?? "";
        //            pp.customerID = l.customer_uid ?? "";

        //            pp.vendorName = l.vendor_name ?? "";
        //            pp.vendorID = l.vendor_uid ?? "";
        //            pp.ordernumberPurchase = l.ordernumber_purchase ?? "";
        //            pp.orderIDPurchase = l.orderid_purchase;

        //            pp.customerDock = l.customer_dock_date.Value;
        //            pp.projectedDock = (l.projected_dock_date ?? DateTime.MinValue);


        //            pp.dockDate = l.customer_dock_date.Value.Date;
        //            pp.recievedDate = l.receive_date_actual.Value.Date;
        //            pp.totalPrice = l.total_price.Value;
        //            pp.grossProfit = l.gross_profit.Value;

        //            pp.orderDateSales = l.orderdate_sales.Value;
        //            pp.qcStatus = l.qc_status;

        //            pp.qty = l.quantity.Value;
        //            pp.lineStatus = l.status ?? "";
        //            pp.idea_insp_id = l.insp_id ?? "";

        //            //5 point priority per 1000GP
        //            pp.gpPriority = CheckShipPriorityGP(l);
        //            //1 point priority per day till dock, p can be null
        //            pp.datePriority = CheckShipDatePriority(l, p);
        //            // Start with algorithmic priority
        //            pp.linePriority = pp.gpPriority + pp.datePriority;
        //            //override with manual priority if present.
        //            line_process lp = lpList.Where(w => w.orddet_line_uid == l.unique_id).FirstOrDefault();
        //            if (lp != null)
        //                //if (lp.line_priority != 0)
        //                pp.linePriority = lp.line_priority.Value;
        //            //Add to return list.
        //            ret.Add(pp);
        //        }
        //        // }).ToList();
        //        if (endDate < DateTime.MaxValue)
        //            ret = ret.Where(w => w.orderDateSales <= endDate.Value.Date).ToList();

        //        return ret;
        //    }

        //}

        public static List<priorityObject> GetInboundPriorityLines(DateTime? startDate, DateTime? endDate = null)
        {

            //Rz Where
            //and status in ('Buy', 'Open', 'Hold', 'Out For Service', 'RMA Receiving')
            //and len(isnull(orderid_sales, 0)) > 0
            //and status not in ('hold')
            //and fullpartnumber not like '%GCAT%'

            using (RzDataContext rdc = new RzDataContext())
            {
                if (endDate == null)
                    endDate = DateTime.MaxValue;

                List<orddet_line> lineList = rdc.orddet_lines
                    .Where(
                    w => (w.orderid_sales ?? "").Length > 0
                    && (w.customer_dock_date.Value.Date >= startDate.Value.Date && w.customer_dock_date.Value.Date <= endDate.Value.Date)
                    && !w.fullpartnumber.ToLower().Contains("gcat")
                    && GetUnshippedStatus().Contains(w.status.ToLower())
                    && !GetIgnoredStatus().Contains(w.status.ToLower())
                    ).ToList();
                List<string> lineListIds = lineList.Select(s => s.unique_id).Distinct().ToList();

                //Get a list of ordhed_sales so we can get CustomerPO
                List<ordhed_sale> salesList = new List<ordhed_sale>();
                List<string> salesIdList = new List<string>();
                salesIdList = lineList.Where(w => w.orderid_sales.Length > 0 && w.orderid_sales != null).Select(s => s.orderid_sales).Distinct().ToList();
                salesList = rdc.ordhed_sales.Where(w => salesIdList.Contains(w.unique_id)).ToList();


                //Get a list of ordhed_purchase so we cans get PO Terms
                List<ordhed_purchase> poList = new List<ordhed_purchase>();
                List<string> poIdList = new List<string>();
                poIdList = lineList.Where(w => w.orderid_purchase.Length > 0 && w.orderid_purchase != null).Select(s => s.orderid_purchase).Distinct().ToList();
                poList = rdc.ordhed_purchases.Where(w => poIdList.Contains(w.unique_id)).ToList();


                //Get Priorirty Objects relating to this group of lines, so it can be queried below:
                List<line_process> lpList = new List<line_process>();
                lpList = rdc.line_processes.Where(w => lineListIds.Contains(w.orddet_line_uid)).ToList();

                //List<priorityObject> ret = new List<priorityObject>();
                List<priorityObject> ret = new List<priorityObject>();

                foreach (orddet_line l in lineList)
                {
                    priorityObject pp = new priorityObject();
                    string customerString = l.customer_name ?? "";
                    ordhed_sale s = salesList.Where(w => w.unique_id == l.orderid_sales).FirstOrDefault();                   
                    if (s != null)
                        if (!string.IsNullOrEmpty(s.orderreference))
                            customerString += " (" + s.orderreference+ ")";

                    string termsString = "";
                    ordhed_purchase p = poList.Where(w => w.unique_id == l.orderid_purchase).FirstOrDefault();
                    if (p != null)
                        if (!string.IsNullOrEmpty(p.terms))
                            termsString = " (" + p.terms.Trim().ToUpper() + ")";

                    pp.line_uid = l.unique_id ?? "";
                    pp.salesAgent = l.seller_name ?? "";
                    pp.partNumber = l.fullpartnumber ?? "";
                    pp.salesAgentID = l.seller_uid ?? "";
                    pp.ordernumberSales = l.ordernumber_sales ?? "";
                    pp.orderIDSales = l.orderid_sales ?? "";
                    pp.customerName = customerString ?? "";
                    pp.customerID = l.customer_uid ?? "";
                    pp.vendorName = l.vendor_name ?? "";
                    pp.vendorID = l.vendor_uid ?? "";
                    pp.ordernumberPurchase = l.ordernumber_purchase ?? "";
                    if (!string.IsNullOrEmpty(pp.ordernumberPurchase))
                        pp.ordernumberPurchase += termsString;
                    pp.orderIDPurchase = l.orderid_purchase;
                    pp.customerDock = l.customer_dock_date.Value;
                    pp.projectedDock = (l.projected_dock_date ?? DateTime.MinValue);
                    pp.dockDate = l.customer_dock_date.Value.Date;
                    pp.recievedDate = l.receive_date_actual.Value.Date;
                    pp.totalPrice = l.total_price.Value;
                    pp.grossProfit = l.gross_profit.Value;
                    pp.orderDateSales = l.orderdate_sales.Value;
                    pp.qcStatus = l.qc_status;
                    pp.qty = l.quantity.Value;
                    pp.lineStatus = l.status ?? "";
                    pp.idea_insp_id = l.insp_id ?? "";
                   
                    
                    //1-18-2022 Per Joe, let's go more manual.  
                    ////Algorithmic approach
                    //// 5 point priority per 1000GP
                    //pp.gpPriority = CheckShipPriorityGP(l);
                    //// 1 point priority per day till dock, p can be null
                    //pp.datePriority = CheckShipDatePriority(l);
                    //// Start with algorithmic priority, GP Priority + DatePriority
                    //pp.linePriority = pp.gpPriority + pp.datePriority;


                    line_process lp = lpList.Where(w => w.orddet_line_uid == l.unique_id && w.type == SM_Enums.LineProcessType.LinePriority.ToString()).FirstOrDefault();


                    //Manual Approach
                    pp.hasManualPriority = false;
                    pp.linePriority = 0;
                    if (lp != null)
                    {
                        pp.linePriority = (lp.line_priority ?? 0);
                        pp.hasManualPriority = true;
                    }
                    pp.lineCount = rdc.orddet_lines.Where(w => w.orderid_sales == l.orderid_sales && w.vendor_name.ToLower() != "source tbd" && !w.fullpartnumber.ToLower().Contains("gcat")).Count();
                    //Add to return list.
                    ret.Add(pp);
                }
                // }).ToList();
                if (endDate < DateTime.MaxValue)
                    ret = ret.Where(w => w.orderDateSales <= endDate.Value.Date).ToList();

                return ret;
            }

        }


        public static class Tracking
        {


            public static string getTrackShipmentUrl(string carrier, string trackingnumber)
            {
                string shortcarrier = "";
                if (carrier.ToLower().Contains("fedex"))
                    shortcarrier = "fedex";
                else if (carrier.ToLower().Contains("ups"))
                    shortcarrier = "ups";
                else if (carrier.ToLower().Contains("ups"))
                    shortcarrier = "usps";
                else if (carrier.ToLower().Contains("dhl"))
                    shortcarrier = "dhl";

                switch (shortcarrier)
                {
                    case "ups":
                        {
                            return trackUPS(trackingnumber);
                        }
                    case "fedex":
                        {
                            return trackFedex(trackingnumber);
                        }
                    case "usps":
                        {
                            return trackUSPS(trackingnumber);
                        }
                    case "dhl":
                        {
                            return trackDHL(trackingnumber);
                        }
                    default:
                        return "";
                }

            }


            static string trackUPS(string trackingnumber)
            {
                return "http://wwwapps.ups.com/WebTracking/track?loc=en_US&track.x=Track&trackNums=" + trackingnumber;
            }
            static string trackFedex(string trackingnumber)
            {
                return "http://fedex.com/Tracking?action=track&language=english&cntry_code=us&tracknumbers=" + trackingnumber;
            }
            static string trackUSPS(string trackingnumber)
            {
                return "https://tools.usps.com/go/TrackConfirmAction.action?tLabels=" + trackingnumber;
            }

            static string trackDHL(string trackingnumber)
            {
                return "http://www.dhl.com/en/express/tracking.html?AWB=" + trackingnumber + "&brand=DHL";
            }

        }



    }













}
