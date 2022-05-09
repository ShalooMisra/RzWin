using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SensibleDAL.dbml;



namespace SensibleDAL
{
    public class ConsignmentData
    {
        RzDataContext rdc = new RzDataContext();
        CompanyData compData = new CompanyData();
        LineData lineData = new LineData();
        decimal? ListCost = 0;



        public class ConsignmentSalesData
        {
            public string InvoiceNumber { get; set; }
            public string InvoiceID { get; set; }
            public DateTime InvoiceDate { get; set; }
            public string Agent { get; set; }
            public string CustomerName { get; set; }
            public string CustomerUid { get; set; }
            public string LineID { get; set; }
            public string VendorName { get; set; }
            public string VendorUid { get; set; }
            public string ConsignmentCode { get; set; }
            public string MFG { get; set; }
            public string PartNumber { get; set; }
            public int QTY { get; set; }
            public double TotalPrice { get; set; }
            public double UnitPrice { get; set; }
            public double UnitCost { get; set; }
            public double TotalCost { get; set; }
            public string SO { get; set; }
            public bool WasRma { get; set; }
            public double PayoutPct { get; set; }
            public double KeepPct { get; set; }
            public string PayKeepPct { get; set; }
            public double PayoutAmnt { get; set; }
            public double KeepAmnt { get; set; }
            public double UnitPayoutAmnt { get; set; }
            public double UnitKeepAmnt { get; set; }
            public double InvoicePaymentAmnt { get; set; }
            public DateTime InvoicePaymentDate { get; set; }
            public string PaymentAccount { get; set; }
            public double Credits { get; set; }
            public double Charges { get; set; }
            public string StockType { get; set; }
            public string InventoryLinkUID { get; set; }


        }


        public List<company> GetShowConsignlmentProfitCompanies()
        {
            List<company> ret = new List<company>();
            Dictionary<string, string> dictCompanies = new Dictionary<string, string>();
            dictCompanies.Add("54b32ae75a8f45ddbe5acc19abeee0c2", "Harris Corporation [Rochester, NY]");


            foreach (KeyValuePair<string, string> kvp in dictCompanies)
            {
                ret.Add(compData.GetCompanyByID(kvp.Key));
            }
            return ret;
        }


        public DateTime GetOldestConsignmentDate(string companyID)
        {
            return (DateTime)rdc.consignment_codes.Where(w => w.vendor_uid == companyID).OrderBy(o => o.date_created).Select(s => s.date_created).FirstOrDefault();
        }

        public DataTable GetConsignmentMatches(string CompanyID, DateTime StartDate, DateTime EndDate, string type, string part = null)//Matched by part number
        {

            DataTable d = new DataTable();
            d.Columns.Add("Type", typeof(string));
            d.Columns.Add("PartNumber", typeof(string));
            d.Columns.Add("MFG", typeof(string));
            d.Columns.Add("QTY", typeof(int));
            d.Columns.Add("SMVCost", typeof(string));
            d.Columns.Add("UnitCost", typeof(decimal));
            d.Columns.Add("TotalListCost", typeof(decimal));
            d.Columns.Add("UnitPrice", typeof(decimal));
            d.Columns.Add("TotalPrice", typeof(decimal));
            d.Columns.Add("TotalCost", typeof(decimal));
            d.Columns.Add("Revenue", typeof(decimal));
            d.Columns.Add("Date", typeof(DateTime));


            List<string> ConsignmentCodes = rdc.consignment_codes.Where(w => w.vendor_uid == CompanyID).Select(s => s.code_name).Distinct().ToList();

            switch (type.ToLower())
            {
                case "quotes":
                    {

                        d = GetConsignmentMatchQuotes(d, CompanyID, StartDate, EndDate);
                        break;
                    }
                case "sales":
                    {
                        d = GetConsignmentMatchSales(d, CompanyID, StartDate, EndDate, ConsignmentCodes, part);
                        break;
                    }
                case "all":
                    {

                        d = GetConsignmentMatchQuotes(d, CompanyID, StartDate, EndDate);
                        d.Merge(GetConsignmentMatchSales(d, CompanyID, StartDate, EndDate, ConsignmentCodes, part));

                        break;
                    }
            }

            d = AddInitialConsignmentCosttoDataTable(d, CompanyID);
            DataView dv = d.DefaultView;
            dv.Sort = "TotalPrice desc";
            d = dv.ToTable();
            return d;

        }

        public static double GetPOPaidAmount(string poId)
        {

            using (RzDataContext rdc = new RzDataContext())
            {
                double paidAmount = rdc.checkpayments.Where(w => w.base_ordhed_uid == poId).Sum(s => s.transamount) ?? 0;
                return paidAmount;

            }

        }

        public object GetConsignmentMatchesLinq(string CompanyID, DateTime StartDate, DateTime EndDate, string type, string part = null)//Matched by part number
        {
            var query = rdc.consignment_activity_quotes(CompanyID, StartDate, EndDate);
            return query.ToList();
        }



        private List<List<string>> GetAllConsignedParts(List<string> consignmentCodes, DateTime StartDate, DateTime EndDate, string part = "")
        {

            List<List<string>> AllConsignedPartsLists = new List<List<string>>();
            List<string> manifestCodes = new List<string>();
            List<string> nonmanifestCodes = new List<string>();
            List<string> manifestPartList = new List<string>();
            List<string> nonmanifestPartList = new List<string>();//identified by partrecord and quotes.
            List<string> PartrecordConsignedParts = new List<string>();
            List<string> OrddetConsignedParts = new List<string>();


            //Get separate lists of codes that have a manifest with ones that don't
            foreach (string s in consignmentCodes)
            {
                if (rdc.consignment_manifests.Any(w => consignmentCodes.Contains(w.consignment_code)))
                    manifestCodes.Add(s);
                else
                    nonmanifestCodes.Add(s);
            }

            //Get all the consginmentparts that match any manifest lists codes
            foreach (string mc in manifestCodes)
                manifestPartList.AddRange(rdc.consignment_manifests.Where(w => w.consignment_code == mc).Select(s => s.fullpartnumber).Distinct().ToList());
            if (manifestPartList.Count > 0)
            {
                AllConsignedPartsLists.AddRange(Tools.Lists.splitList(manifestPartList, 2000));
            }

            // Get all the consginmentparts that don't have a manifest by searching partrecord, and ordddet
            foreach (string nmc in nonmanifestCodes)
            {
                nonmanifestPartList.AddRange(rdc.partrecords.Where(w => w.date_created >= StartDate && w.fullpartnumber.Length > 0 && w.consignment_code == nmc && w.fullpartnumber.Contains(part ?? "")).Select(s => s.fullpartnumber).Distinct().ToList());
                nonmanifestPartList.AddRange(rdc.orddet_lines.Where(w => w.date_created >= StartDate && w.fullpartnumber.Length > 0 && w.consignment_code == nmc && w.fullpartnumber.Contains(part ?? "")).Select(s => s.fullpartnumber).Distinct().ToList());

            }
            if (nonmanifestPartList.Count > 0)
                AllConsignedPartsLists.AddRange(Tools.Lists.splitList(nonmanifestPartList, 2000));

            //Get all teh alternate parts that may be called out on Partrecord or Consignment_manifest
            foreach (List<string> altsList in GetAlternatesToList(consignmentCodes))
            {
                foreach (List<string> l in Tools.Lists.splitList(altsList, 2000))
                    AllConsignedPartsLists.Add(l);
            }

            return AllConsignedPartsLists;
        }

        private List<List<string>> GetAlternatesToList(List<string> consignmentCodeList)
        {
            //Alternate PArts and userdata_01 only exist in partrecord and consignment_manifest, not needed for orddet_line as that's directly matched on consignment_code / importid
            List<List<string>> ret = new List<List<string>>();
            List<string> userDataAlternates = new List<string>();
            List<string> userDataAlternatesSplit = new List<string>();
            foreach (string s in consignmentCodeList)
            {
                if (rdc.consignment_manifests.Any(w => w.consignment_code == s))
                {
                    ret.Add(rdc.consignment_manifests.Where(w => w.consignment_code == s && w.alternatepart.Length > 0).Select(ss => ss.alternatepart).Distinct().ToList());
                    userDataAlternates.AddRange(rdc.consignment_manifests.Where(w => w.consignment_code == s && w.userdata_01.Length > 0).Select(ss => ss.userdata_01).Distinct().ToList());
                }
                if (rdc.partrecords.Any(w => w.consignment_code == s))
                {
                    ret.Add(rdc.partrecords.Where(w => w.consignment_code == s && w.alternatepart.Length > 0).Select(ss => ss.alternatepart).Distinct().ToList());
                    userDataAlternates.AddRange(rdc.partrecords.Where(w => w.consignment_code == s && w.userdata_01.Length > 0).Select(ss => ss.userdata_01).Distinct().ToList());
                }
            }
            //UserDataAlternates are comma separated, get them into their own list of strings
            if (userDataAlternates.Count > 0)
            {
                foreach (string s in userDataAlternates)
                    userDataAlternatesSplit.AddRange(s.Split(',').ToList());

            }

            if (userDataAlternatesSplit.Count > 0)
                ret.Add(userDataAlternatesSplit);

            return ret;
        }


        private DataTable GetConsignmentMatchQuotes(DataTable d, string CompanyID, DateTime StartDate, DateTime EndDate, List<List<string>> allConsignedPartsSplit, string part = null)//Matched by part number
        {
            List<orddet_quote> QuotedList = new List<orddet_quote>();

            foreach (List<string> list in allConsignedPartsSplit)
            {
                QuotedList.AddRange(rdc.orddet_quotes.Where(w => w.date_created >= StartDate && w.fullpartnumber.Length > 0 && list.Contains(w.fullpartnumber) && w.fullpartnumber.Contains(part ?? "")));
            }

            QuotedList = QuotedList.Where(w => w.unitprice > 0 && w.quantityordered > 0).Distinct().ToList(); //Remove the Duplicates from this list.

            foreach (orddet_quote q in QuotedList)
            {
                string mfg = "";
                if (!string.IsNullOrEmpty(q.target_manufacturer))
                    mfg = q.target_manufacturer;
                else if (!string.IsNullOrEmpty(q.manufacturer))
                    mfg = q.manufacturer;

                DataRow dr = d.NewRow();
                dr["Type"] = "Quote";
                dr["PartNumber"] = q.fullpartnumber.ToUpper();
                dr["MFG"] = mfg.ToUpper();
                dr["QTY"] = q.quantityordered;
                dr["SMVCost"] = "N/A";
                dr["UnitCost"] = q.unitcost;
                dr["UnitPrice"] = q.unitprice;
                dr["TotalCost"] = q.unitcost * q.quantityordered;
                dr["TotalPrice"] = q.totalprice;
                dr["Revenue"] = (q.totalprice - (q.unitcost * q.quantityordered));
                dr["Date"] = q.date_created;
                d.Rows.Add(dr);
            }
            return d;

        }
        public static object GetConsignmentActivity_Quotes(string unique_id, DateTime startDate, DateTime endDate)
        {
            RzDataContext rdc = new RzDataContext();
            return rdc.consignment_activity_quotes(unique_id, startDate, endDate);
        }


        private DataTable GetConsignmentMatchQuotes(DataTable d, string CompanyID, DateTime StartDate, DateTime EndDate)//Matched by part number
        {
            foreach (consignment_activity_quotesResult q in rdc.consignment_activity_quotes(CompanyID, StartDate, EndDate).ToList())
            {
                DataRow dr = d.NewRow();
                dr["Type"] = q.Type;
                dr["PartNumber"] = q.PartNumber.ToUpper();
                dr["MFG"] = q.MFG.ToUpper();
                dr["QTY"] = q.QTY;
                dr["SMVCost"] = q.SMVCost;
                dr["UnitCost"] = q.UnitCost;
                dr["UnitPrice"] = q.UnitPrice;
                dr["TotalCost"] = q.TotalCost;
                dr["TotalPrice"] = q.TotalPrice;
                dr["Revenue"] = q.Revenue ?? 0;
                dr["Date"] = q.Date;
                d.Rows.Add(dr);
            }
            return d;

        }




        private DataTable GetConsignmentMatchSales(DataTable d, string CompanyID, DateTime StartDate, DateTime EndDate, List<string> ConsignmentCodes, string part = null)//Matched by part number
        {

            List<orddet_line> SoldList = new List<orddet_line>();
            List<string> badStatus = LineData.GetInvalid_orddet_Status();
            foreach (string s in ConsignmentCodes)
            {
                SoldList.AddRange(rdc.orddet_lines.Where(w => w.consignment_code == s && !badStatus.Contains(w.status) && w.orderid_sales.Length > 0 && w.quantity > 0 && w.unit_price > 0 && !w.ordernumber_sales.Contains("CR") && w.date_created >= StartDate && w.date_created <= EndDate.AddDays(1) && w.quantity > 0 && !w.ordernumber_sales.Contains("CR") && w.fullpartnumber.Contains(part ?? "")).OrderBy(o => o.fullpartnumber).ToList());
            }

            SoldList = SoldList.Distinct().ToList();
            foreach (orddet_line l in SoldList)
            {
                DataRow dr = d.NewRow();
                dr["Type"] = "Sale";
                dr["PartNumber"] = l.fullpartnumber.ToUpper();
                dr["MFG"] = l.manufacturer.ToUpper();
                dr["QTY"] = l.quantity;
                dr["SMVCost"] = "N/A";
                dr["UnitCost"] = l.unit_cost;
                //dr["TotalListCost"] = l.unit_cost;
                dr["UnitPrice"] = l.unit_price;
                dr["TotalCost"] = l.total_cost;
                dr["TotalPrice"] = l.total_price;
                dr["Revenue"] = l.total_price - l.total_cost;
                dr["Date"] = l.date_created;
                d.Rows.Add(dr);
            }
            return d;
        }

        private DataTable AddInitialConsignmentCosttoDataTable(DataTable d, string companyID)
        {

            //Get the lowest cost that matches the companyid and partnumber from consignment manifest.  Overwrite the Revenue row if present        
            List<consignment_manifest> cmL = new List<consignment_manifest>();

            //Get the manifest
            cmL = rdc.consignment_manifests.Where(w => w.base_company_uid == companyID).ToList();
            //Get Listof consignment codes for company
            List<string> cList = cmL.Select(s => s.consignment_code).Distinct().ToList();

            //For every part on the manifest, get the partrecord, so we can grab SMV
            List<partrecord> smvPartLIst = rdc.partrecords.Where(w => w.base_company_uid == companyID && cList.Contains(w.consignment_code) && w.suggested_market_value > 0).ToList();

            foreach (DataRow dr in d.Rows)
            {

                string dataRowPart = dr["PartNumber"].ToString().Trim();
                int dataRowQTY = Convert.ToInt32(dr["QTY"]);

                //Get the Suggested Market Value (SMV)
                partrecord p = smvPartLIst.Where(w => w.fullpartnumber == dataRowPart).FirstOrDefault();
                double smvCost = 0;
                if (p != null)
                    smvCost = p.suggested_market_value ?? 0;

                //Get the cost fromt he initial manifest
                ListCost = 0;
                ListCost = GetManifestListCost(cmL, dataRowPart);



                if (ListCost == 0 || ListCost == null)
                {
                    //We still haven't matched the part, try removing all special characters and the last 2 digits.
                    string cleanedManifestPart = Tools.Strings.FilterTrash(dataRowPart.Trim());
                    ListCost = GetManifestListCost(cmL, cleanedManifestPart);
                    if (ListCost == 0 || ListCost == null)
                        ListCost = GetListCostFromSubString(cmL, dataRowPart);
                }

                if (ListCost > 0)
                {
                    //The the QTY from the quote lines
                    int listQty = Convert.ToInt32(dr["QTY"]);
                    //Get the cost we are quoting
                    decimal totalListCost = (ListCost ?? 0) * listQty;
                    dr["TotalListCost"] = totalListCost;
                    //Get the price we are quoting at
                    decimal totalListPrice = (decimal?)dr["TotalPrice"] ?? 0;
                    //Subtract cost from price for revenue
                    dr["Revenue"] = totalListPrice - totalListCost;
                }
                //IF there's a SMV, and it's less than the listCost, show it, the idea being to notify consignmetn partners when our agents want to alert them to SMV suggestions
                if (smvCost > 0 && (decimal)smvCost < ListCost)
                    dr["SMVCost"] = smvCost;


            }

            return d;

        }


        private decimal? GetManifestListCost(List<consignment_manifest> cmL, string manifestPart)
        {
           
            if (cmL.Any(w => Tools.Strings.FilterTrash(w.fullpartnumber.Trim().ToUpper()) == manifestPart))
                ListCost = (decimal?)cmL.Where(w => Tools.Strings.FilterTrash(w.fullpartnumber.Trim().ToUpper()) == manifestPart).Select(s => s.cost).Min();
            else if (cmL.Any(w => Tools.Strings.FilterTrash(w.alternatepart.Trim().ToUpper()) == manifestPart))
                ListCost = (decimal?)cmL.Where(w => Tools.Strings.FilterTrash(w.alternatepart.Trim().ToUpper()) == manifestPart).Select(s => s.cost).Min();
            else if (cmL.Any(w => Tools.Strings.FilterTrash(w.userdata_01.Trim().ToUpper()).Contains(manifestPart)))
                ListCost = (decimal?)cmL.Where(w => Tools.Strings.FilterTrash(w.userdata_01.ToUpper()).Contains(manifestPart)).Select(s => s.cost).Min();
            return ListCost;
        }



        private decimal? GetListCostFromSubString(List<consignment_manifest> cmL, string manifestPart)
        {
            ListCost = 0;
            string substringManifestPart = Tools.Strings.FilterTrash(manifestPart);

            for (int i = 1; i < 5; i++)
            {
                string subPart = substringManifestPart.Substring(0, substringManifestPart.Length - i);

                ListCost = GetManifestListCost(cmL, subPart);
                if (ListCost > 0)
                    return ListCost;
            }

            return ListCost;
        }

        public List<company> GetConsignmentCompanies()
        {
            List<string> consignmentCompanyIDs = rdc.consignment_codes.Select(s => s.vendor_uid).ToList();
            return rdc.companies.Where(w => consignmentCompanyIDs.Contains(w.unique_id)).OrderBy(o => o.companyname).ToList();
        }


        public List<ConsignmentSalesData> GetConsignmentData(DateTime startDate, DateTime endDate, string companyId, bool fullyPaidOnly = false)
        {


            List<string> consignmentStockTypes = new List<string>() { "consign", " consigned" };
            //Get a List consignment All lines
            List<orddet_line> consignmentLines = new List<orddet_line>();
            if (companyId == "All")
                consignmentLines = rdc.orddet_lines.Where(w => consignmentStockTypes.Contains(w.stocktype.ToLower())
                && w.orderdate_invoice >= startDate.Date
                && w.orderid_invoice.Length > 0
                && w.orderid_invoice != null
                && !w.ordernumber_invoice.Contains("CR")).ToList(); //For fully paid, Do not constrain to the orderdate_invoice, as things get paid much later than invoice created.
                                                                    //Filter to Company
            else
                consignmentLines = rdc.orddet_lines.Where(w => w.vendor_uid == companyId
                && consignmentStockTypes.Contains(w.stocktype.ToLower())
                    && w.orderdate_invoice >= startDate.Date
                    && w.orderid_invoice.Length > 0 && w.orderid_invoice != null
                    && !w.ordernumber_invoice.Contains("CR")
                ).ToList();

            //Get a List if Invoices here, so we can calculate Invoice Total below
            List<string> constignmentInvoiceIds = consignmentLines.Select(s => s.orderid_invoice).Distinct().ToList();
            List<ordhed_invoice> consignmentInvoices = rdc.ordhed_invoices.Where(w => constignmentInvoiceIds.Contains(w.unique_id)).ToList();
            //Build the Initial CSD List
            List<ConsignmentSalesData> csdList = consignmentLines.Select(s => new ConsignmentSalesData
            {
                InvoiceID = s.orderid_invoice,
                VendorName = s.vendor_name,
                VendorUid = s.vendor_uid,
                InventoryLinkUID = s.inventory_link_uid,
                ConsignmentCode = s.consignment_code,
                InvoiceNumber = s.ordernumber_invoice,
                SO = s.ordernumber_sales,
                StockType = s.stocktype,
                InvoiceDate = (DateTime)s.orderdate_invoice,
                Agent = s.seller_name,
                CustomerName = s.customer_name,
                CustomerUid = s.customer_uid,
                PartNumber = s.fullpartnumber.ToUpper(),
                MFG = s.manufacturer,
                QTY = (int)s.quantity_packed,
                WasRma = (bool)s.was_rma,
                //Credits = (double)rdc.ordhits.Where(w => w.the_ordhed_uid == inv.unique_id && w.is_credit == true).Select(s => s.hit_amount).FirstOrDefault(),
                //TotalPrice = GetConsignmentLineTotalPrice(s),
                TotalPrice = (double)s.total_price,
                UnitPrice = (double)s.unit_price,
                UnitCost = (double)s.unit_cost,
                TotalCost = (double)s.total_cost,
                PayoutPct = (double)s.consignment_percent

                //TotalPrice = Number.CommonSensibleRounding((double)s.total_price),
                //UnitPrice = Number.CommonSensibleRounding((double)s.unit_price),
                //UnitCost = Number.CommonSensibleRounding((double)s.unit_cost),
                //TotalCost = Number.CommonSensibleRounding((double)s.total_cost),
                //PayoutPct = Number.CommonSensibleRounding((double)s.consignment_percent)


            }).ToList();


            //Handle RMA Stuff
            foreach (ConsignmentSalesData csd in csdList)
            {
                if (csd.WasRma)
                {
                    csd.TotalPrice = csd.TotalPrice * -1;
                    csd.SO = csd.SO + " (RMA)";
                }

            }


            //Fully Paid Only
            if (fullyPaidOnly)
                csdList = GetFullyPaidConsignmentSalesData(csdList, startDate, endDate);

            //Set Pay Keep Amounts
            SetConsignmentPayKeepAmounts(csdList);

            //Set Pay Keep String
            GetConsignmentSalesPayKeepString(csdList);

            return csdList.OrderBy(o => o.InvoiceDate).ToList();
        }

        private List<ConsignmentSalesData> GetFullyPaidConsignmentSalesData(List<ConsignmentSalesData> csdList, DateTime startDate, DateTime endDate)
        {
            //Get Paymnent Data
            List<string> invoiceIdsFromInvoiceQuery = csdList.Select(s => s.InvoiceID).Distinct().ToList();
            List<checkpayment> paymentsList = rdc.checkpayments.Where(
                w => invoiceIdsFromInvoiceQuery.Contains(w.base_ordhed_uid)
                && w.transdate.Value.Date >= startDate.Date
                                           && w.transdate.Value.Date <= endDate.Date
                                           && w.base_ordhed_uid != null
                                           && w.base_ordhed_uid.Length > 0
                                           && w.transamount > 0
                                           && w.base_company_uid != null
                                           && w.base_company_uid.Length > 0

                ).ToList();


            //Carry a list of invoices id's that have payments
            List<string> invoiceIdsThatHavePayment = paymentsList.Select(s => s.base_ordhed_uid).Distinct().ToList();

            //Get a list of orheds so we can compare to the ordertotal, this is to account for non-consigned lines.
            List<ordhed_invoice> invoicesWithPaymentsList = rdc.ordhed_invoices.Where(w => invoiceIdsThatHavePayment.Contains(w.unique_id)).ToList();

            //Get a list of ordhits to convert to CSD, do this here, so I can work with in-memory list instead of spamming database cals in the foreach.
            List<ordhit> creditList = rdc.ordhits.Where(w => invoiceIdsThatHavePayment.Contains(w.the_ordhed_uid) && w.is_credit == true).ToList();

            //List of Fully Paid Invoice IDs
            List<string> fullyPaidInvoiceIds = new List<string>();

            foreach (ConsignmentSalesData csd in csdList)
            {
                //Payment's for this CSD's invoice
                List<checkpayment> currentInvoicePayments = paymentsList.Where(w => w.base_ordhed_uid == csd.InvoiceID).ToList();
                if (currentInvoicePayments.Count == 0)
                    continue;
                csd.PaymentAccount = currentInvoicePayments.Select(sel => sel.qb_account).FirstOrDefault();
                csd.InvoicePaymentAmnt = (double)currentInvoicePayments.Sum(sum => sum.transamount);
                csd.InvoicePaymentDate = (DateTime)currentInvoicePayments.Max(max => max.transdate);


                //Calculate related Invoice Total    
                ordhed_invoice currentInvoice = invoicesWithPaymentsList.Where(w => w.unique_id == csd.InvoiceID).FirstOrDefault();
                double orderTotal = (double)currentInvoice.ordertotal;

                //Compare the values
                if (csd.InvoicePaymentAmnt >= orderTotal)
                    fullyPaidInvoiceIds.Add(csd.InvoiceID);
            }

            //Return a new list with only the fully paid csds
            List<ConsignmentSalesData> ret = csdList.Where(w => fullyPaidInvoiceIds.Contains(w.InvoiceID)).ToList();
            return ret;
        }



        private void GetConsignmentSalesPayKeepString(List<ConsignmentSalesData> ret)
        {
            foreach (ConsignmentSalesData csd in ret)
            {
                csd.PayKeepPct = csd.PayoutPct.ToString() + " / " + (100 - csd.PayoutPct).ToString();
            }
        }

        //private void SetConsignmentPayKeepAmounts(List<ConsignmentSalesData> csdList)
        //{
        //    foreach (ConsignmentSalesData csd in csdList)
        //    {
        //        if (csd.UnitPrice <= 0)
        //            continue;

        //        if (csd.TotalPrice <= 0)
        //            continue;

        //        //KT - removing these percentages, the percentage split should alread have been handled, and representeng by unit cost and unit price.
        //        //Consignment Percent              
        //        //double payPercent = .01 * csd.PayoutPct;
        //        //double keepPercent = .01 * (100 - csd.PayoutPct);

        //        //To get the desired 12.3 , need to mult qty(10) against unitCost 1.243431 = 12.43431‬
        //        //csd.TotalPrice = Number.CommonSensibleRounding(csd.TotalPrice);
        //        //Don't round unit-level, affects resulting Consignment PO calcs.  That rounding can be handled later.

        //        //Set CSD Values for unrounded unit
        //        csd.UnitPayoutAmnt = csd.UnitCost;
        //        csd.UnitKeepAmnt = csd.UnitPrice;

        //        //Consignment is largely dependent on cost.  At Quote time, price we quote at, combined with the split rate, determines the cost.  Our keep value is price minus that cost.


        //        //Round the totals
        //        csd.TotalCost = Number.CommonSensibleRounding(csd.TotalCost);
        //        csd.TotalPrice = Number.CommonSensibleRounding(csd.TotalPrice);

        //        //Subtract Total Cost from Total Price for total Payout
        //        double totalPayout = Number.CommonSensibleRounding(csd.TotalPrice - csd.TotalCost);

        //        //Subtract Total Payout from total price, remainder is the keep.
        //        double totalKeep = csd.TotalPrice - totalPayout;

        //        //Set teh CSD Object values
        //        csd.PayoutAmnt = totalPayout;
        //        csd.KeepAmnt = totalKeep;
        //    }

        //}

        private void SetConsignmentPayKeepAmounts(List<ConsignmentSalesData> csdList)
        {
            foreach (ConsignmentSalesData csd in csdList)
            {
                if (csd.UnitPrice <= 0)
                    continue;

                if (csd.TotalPrice <= 0)
                    continue;               
              
                //Don't round unit-level, affects resulting Consignment PO calcs.  That rounding can be handled later.                
                csd.UnitPayoutAmnt = csd.UnitCost;
                csd.UnitKeepAmnt = csd.UnitPrice;

                //Round the totals and set csd values
                csd.TotalCost = Tools.Number.CommonSensibleRounding(csd.TotalCost);
                csd.TotalPrice = Tools.Number.CommonSensibleRounding(csd.TotalPrice);

                //Consignment is largely dependent on cost.  At Quote time, price we quote at, combined with the split rate, determines the cost.  Our keep value is price minus that cost.
                //Subtract Total Cost from Total Price for total Payout
                csd.PayoutAmnt = csd.TotalCost;
                csd.KeepAmnt = csd.TotalPrice - csd.PayoutAmnt; ;
            }

        }



        private List<orddet_line> GetConsignmentLines(DateTime startDate, DateTime endDate, string companyId)
        {
            List<orddet_line> ret = new List<orddet_line>();
            List<consignment_code> cList = new List<consignment_code>();
            if (companyId == "All")
                cList = rdc.consignment_codes.ToList();
            else
                cList = rdc.consignment_codes.Where(w => w.vendor_uid == companyId).ToList();

            ret = rdc.orddet_lines.Where(w => cList.Select(s => s.code_name).ToList().Contains(w.consignment_code) && w.consignment_code.Length > 0).ToList();

            return ret;
        }



    }
}
