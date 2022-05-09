using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using Core;
using NewMethod;
using HubspotApis;
using System.Linq;
using SensibleDAL;

namespace Rz5
{
    public partial class dealheader : dealheader_auto
    {


        //Public Properties
        public company CustomerObject
        {
            set
            {
                if (value == null)
                {
                    customer_uid = "";
                    customer_name = "";
                }
                else
                {
                    customer_uid = value.unique_id;
                    customer_name = value.companyname;
                }
            }
        }
        public companycontact ContactObject
        {
            set
            {
                if (value == null)
                {
                    contact_uid = "";
                    contact_name = "";
                }
                else
                {
                    contact_uid = value.unique_id;
                    contact_name = value.contactname;
                }
            }
        }
        //Public Variables
        public Dictionary<String, nObject> AllOrders;
        public DealHalfQuote CustomerHalf;
        public DealHalfBid VendorHalf;




        //Constructor
        //Public Static Functions
        public static long GetNextBatchNumber(ContextRz x)
        {
            long l = n_set.GetSetting_Long(x, "current_orderbatch_number");
            l++;
            n_set.SetSetting_Long(x, "current_orderbatch_number", l);
            return l;
        }
        public static dealheader MakeManualDeal(ContextRz x, company comp, companycontact cont)
        {
            dealheader d = dealheader.New(x);
            x.Insert(d);

            d.NameInit(x, comp, cont);

            //Don't set Batch Agent Automatically, Allow user to set, which will trigger Split commission etc logic.   
            //d.base_mc_user_uid = x.xUser.unique_id;
            //d.agentname = x.xUser.name;
            d.main_n_team_uid = x.xUser.main_n_team_uid;
            d.teamname = x.xSys.TranslateTeamIDToName(d.main_n_team_uid);
            d.start_date = DateTime.Now;
            d.manually_created = true;
            d.CustomerObject = comp;
            d.ContactObject = cont;
            d.is_portal_generated = false;            
           
            

            x.Update(d);

            d.Init(x);
            return d;
        }


        protected virtual void NameInit(ContextRz x, company comp, companycontact cont)
        {
            long l = GetNextBatchNumber(x);
            dealheader_name = l.ToString();
        }
        public static bool CheckDealLinks(ContextRz x, ordhed OldOrder, ordhed NewOrder)
        {
            //contextRz.TheLeader.Error("reorg");
            return false;
            //dealheader xDeal = OldOrder.GetDealHeader(x);

            //if (xDeal == null)
            //    xDeal = CreateNewDeal(OldOrder);

            //return SetOrderDeal(NewOrder, xDeal);
        }
        public static dealheader CreateNewDeal(ContextRz x, ordhed xOrder)
        {
            dealheader xDeal = dealheader.New(x);

            xDeal.start_date = DateTime.Now;
            xDeal.dealheader_name = x.xUser.name + " deal begun " + nTools.DateFormat_ShortDateTime(DateTime.Now);
            switch (xOrder.ordertype.ToLower().Trim())
            {
                case "quote":
                    xDeal.dealheader_name = xDeal.dealheader_name + " for customer ";
                    break;
                case "sales":
                    xDeal.dealheader_name = xDeal.dealheader_name + " for customer ";
                    break;
                case "invoice":
                    xDeal.dealheader_name = xDeal.dealheader_name + " for customer ";
                    break;
                case "rma":
                    xDeal.dealheader_name = xDeal.dealheader_name + " for customer ";
                    break;
                default:
                    xDeal.dealheader_name = xDeal.dealheader_name + " for vendor ";
                    break;
            }
            xDeal.dealheader_name = xDeal.dealheader_name + xOrder.companyname;
            xDeal.base_mc_user_uid = xOrder.base_mc_user_uid;
            xDeal.is_portal_generated = false;
            xDeal.opportunity_stage = SM_Enums.OpportunityStage.rfq_received.ToString();
            if (!Tools.Strings.StrExt(xDeal.base_mc_user_uid))
                xDeal.base_mc_user_uid = x.xUser.unique_id;
            x.Insert(xDeal);
            SetOrderDeal(x, xOrder, xDeal);
            return xDeal;
        }
        public static bool SetOrderDeal(ContextRz context, ordhed xOrder, dealheader xDeal)
        {
            xOrder.base_dealheader_uid = xDeal.unique_id;
            context.Update(xOrder);

            //foreach (KeyValuePair<String, nObject> k in details)
            //{
            //    orddet d = (orddet)k.Value;
            //    d.base_dealheader_uid = xDeal.unique_id;
            //    d.base_dealdetail_uid = "";
            //    d.ISave();
            //}

            return true;
        }

        internal ArrayList GetRelatedQuote(ContextRz x)
        {
            ArrayList ret = null;
            List<string> ordhed_quote_ids = x.SelectScalarList("select distinct base_ordhed_uid From orddet_quote where base_dealheader_uid = '" + unique_id + "'");
            if (ordhed_quote_ids.Count <= 0)
                return null;
            string quote_id = ordhed_quote_ids[0];//Since there's a 1:1 relationship between a Quote Line and an ordhed_quote, this [0] should be safe.
            ret = x.QtC("ordhed_quote", "select * from ordhed_quote where unique_id = '" + quote_id + "'");
            //ret = x.QtC("ordhed_quote", "select * from dealheader");
            return ret;
        }

        public static void AcceptDetail_Deal(ContextNM context, ordhed xOrder, orddet xObject)
        {
            //dealheader xDeal;
            //dealdetail xDetail;

            //if (Tools.Strings.StrExt(xOrder.base_dealheader_uid))
            //{
            //    xDeal = xOrder.GetDealHeader(Rz3App.xMainForm.TheContextNM);
            //    if (xDeal != null)
            //    {
            //        xObject.base_dealheader_uid = xDeal.unique_id;
            //        xDetail = xObject.GetDealDetail();
            //        if (xDetail == null)
            //            xDetail = dealdetail.CreateNewDealDetail(context, xDeal, xObject);
            //    }
            //}
        }
        public static dealheader ShowManualDeal(ContextRz x, company comp, companycontact cont)
        {
            return ShowManualDeal(x, comp, cont, "", 0, 0, "", "");
        }
        public static dealheader ShowManualDeal(ContextRz x, company comp, companycontact cont, String fullpartnumber, int targetquantity, Double targetprice, String datecode, String manufacturer)
        {
            if (((SysRz5)x.xSys).TheCompanyLogic.DealContactRequired(cont))
            {
                x.TheLeader.Error("Please choose both a company and contact before continuing");
                return null;
            }
            dealheader d = MakeManualDeal(x, comp, cont);
            if (Tools.Strings.StrExt(fullpartnumber))
            {
                orddet_quote det = d.CustomerHalf.QuoteAdd(x);
                if (det != null)
                {
                    det.target_quantity = targetquantity;
                    det.target_price = targetprice;
                    det.fullpartnumber = fullpartnumber;
                    det.manufacturer = manufacturer;
                    det.datecode = datecode;
                    x.Update(det);
                }
            }
            x.Show(d);
            return d;
        }
        public static void MakeManualDealAndItemAndShow(ContextRz x, company comp, companycontact cont, Enums.OrderType type)
        {
            MakeManualDealAndItemAndShow(x, comp, cont, type, null);
        }
        public static void MakeManualDealAndItemAndShow(ContextRz x, company comp, companycontact cont, Enums.OrderType type, partrecord p)
        {
            dealheader xDeal = null;

            if (type == Enums.OrderType.RFQ)
            {
                xDeal = dealheader.MakeManualDeal(x, null, null);
            }
            else
            {
                xDeal = dealheader.MakeManualDeal(x, comp, cont);
            }


            orddet det;

            switch (type)
            {
                case Enums.OrderType.RFQ:
                    det = xDeal.VendorHalf.BidAdd(x, comp, cont);
                    break;
                default:
                    //if (p == null)
                    det = xDeal.CustomerHalf.QuoteAdd(x);
                    //else
                    //    det = xDeal.CustomerHalf.QuoteAddStock(x, comp, cont, p);

                    if (p != null)
                    {
                        det.fullpartnumber = p.fullpartnumber;
                        det.manufacturer = p.manufacturer;
                        det.datecode = p.datecode;
                        det.condition = p.condition;
                        det.quantity = Convert.ToInt32(p.quantity);
                        x.Update(det);
                    }

                    break;
            }

            x.TheLeaderRz.ShowDealItem(x, xDeal, det);
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;
            switch (args.ActionName.ToLower())
            {
                case "report":
                    Report(xrz);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }
        public override string ToString()
        {
            return dealheader_name;
        }
        public override void Updating(Context x)
        {
            base.Updating(x);
            if (CustomerHalf != null)
            {
                n_user uo = (n_user)this.UserObjectGet((ContextRz)x);
                foreach (orddet_quote q in CustomerHalf.QuotesList((ContextRz)x))
                {
                    q.base_company_uid = customer_uid;
                    q.companyname = customer_name;
                    q.base_companycontact_uid = contact_uid;
                    q.contactname = contact_name;
                    q.UserObjectSet(uo);
                    //Update Line Agents.
                    q.agentname = agentname;
                    q.base_mc_user_uid = base_mc_user_uid;
                    x.Update(q, true);
                }
            }
        }
        //Public Functions
        public virtual void ApplyLinkedPart(orddet_quote q, partrecord p)
        {
            //do nothing
        }
        public void Init(ContextRz x)
        {
            CustomerHalf = ((SysRz5)x.xSys).TheOrderLogic.GetDealHalfQuote();
            CustomerHalf.Init(x, this);
            VendorHalf = ((SysRz5)x.xSys).TheOrderLogic.GetDealHalfBid();
            VendorHalf.Init(x, this);


            //make the links
            foreach (orddet_rfq rx in VendorHalf.BidsList(x))
            {
                foreach (orddet_quote y in CustomerHalf.QuotesList(x))
                {
                    if (rx.the_orddet_quote_uid == y.unique_id)
                    {
                        y.AddDetailDirectly(rx);
                        rx.ParentDetailSet(x, y);
                    }

                    if (y.the_orddet_rfq_uid == rx.unique_id)
                    {
                        rx.AddDetailDirectly(y);
                        y.ParentDetailSet(x, rx);
                    }
                }
            }

            CacheOrders(x);

            //check for blank customer info
            if (!Tools.Strings.StrExt(customer_uid))
            {
                Dictionary<String, dealcompany> companies = CustomerHalf.CompaniesList(x);
                if (companies.Count > 0)
                {
                    foreach (KeyValuePair<String, dealcompany> k in companies)
                    {
                        dealcompany comp = k.Value;
                        customer_uid = comp.the_company_uid;
                        customer_name = comp.companyname;
                        contact_uid = comp.the_companycontact_uid;
                        contact_name = comp.contactname;
                        x.Update(this);
                        break;
                    }
                }
            }
        }
        public void CacheOrders(ContextNM x)
        {
            AllOrders = new Dictionary<string, nObject>();
            AddOrders(x, Enums.OrderType.RFQ);
            AddOrders(x, Enums.OrderType.Quote);
            AddOrders(x, Enums.OrderType.Service);
            AddOrders(x, Enums.OrderType.Sales);
            AddOrders(x, Enums.OrderType.Invoice);
            AddOrders(x, Enums.OrderType.Purchase);
            AddOrders(x, Enums.OrderType.RMA);
            AddOrders(x, Enums.OrderType.VendRMA);
        }
        public void AddOrder(ordhed o)
        {
            if (AllOrders == null)
                return;
            if (AllOrders.ContainsKey(o.unique_id))
                return;
            AllOrders.Add(o.unique_id, o);
        }
        public void Report(ContextRz context)
        {
            context.TheLeaderRz.StockEvaluatorReport(this);
        }
        public Dictionary<String, nObject> GetOrdersD(Enums.OrderType t)
        {
            Dictionary<String, nObject> x = new Dictionary<string, nObject>();
            if (AllOrders == null)
                return x;

            foreach (KeyValuePair<String, nObject> k in AllOrders)
            {
                ordhed h = (ordhed)k.Value;
                if (h.OrderType == t)
                    x.Add(h.unique_id, h);
            }
            return x;
        }
        public int CountOrders(Enums.OrderType t)
        {
            if (AllOrders == null)
                return 0;

            int i = 0;
            foreach (KeyValuePair<String, nObject> k in AllOrders)
            {
                ordhed h = (ordhed)k.Value;
                if (h.OrderType == t)
                    i++;
            }
            return i;
        }
        public void AbsorbDetails(ArrayList parent, ArrayList details, bool as_vendor)
        {
            //foreach (orddet x in details)
            //{
            //    x.Details = new ArrayList();
            //    bool m = false;
            //    foreach (dealcompany c in parent)
            //    {
            //        if (c.Matches(x.base_company_uid, x.base_companycontact_uid))
            //        {
            //            m = true;
            //            c.Details.Add(x);
            //        }
            //    }

            //    if (!m)
            //    {
            //        dealcompany c = new dealcompany(xSys);
            //        c.the_dealheader_uid = this.unique_id;
            //        c.the_company_uid = x.base_company_uid;
            //        c.the_companycontact_uid = x.base_companycontact_uid;
            //        c.as_vendor = as_vendor;
            //        c.ISave();

            //        if (as_vendor)
            //            Vendors.Add(c);
            //        else
            //            Customers.Add(c);

            //        c.Details = new ArrayList();
            //    }
            //}
        }
        public Item GetObjectByID(String strID)
        {
            Item ret = null;

            if (CustomerHalf != null)
            {
                if (CustomerHalf.Details.ContainsKey(strID))
                    ret = CustomerHalf.Details[strID];
            }

            if (VendorHalf != null && ret == null)
            {
                if (VendorHalf.Details.ContainsKey(strID))
                    ret = VendorHalf.Details[strID];
            }

            return ret;
        }
        public bool UpdateQuoteStats(ContextRz context)
        {
            try
            {
                if (!Tools.Strings.StrExt(unique_id))
                    return false;
                if (CustomerHalf == null)
                    return false;
                List<orddet_quote> list = CustomerHalf.QuotesList(context);
                if (list == null)
                    return false;
                if (list.Count <= 0)
                    return false;
                Dictionary<string, ArrayList> quotes = new Dictionary<string, ArrayList>();
                foreach (orddet_quote q in list)
                {
                    bool is_new = false;
                    ArrayList a = null;
                    quotes.TryGetValue(q.prefix + q.basenumberstripped, out a);
                    if (a == null)
                    {
                        a = new ArrayList();
                        is_new = true;
                    }
                    a.Add(q);
                    if (is_new)
                        quotes.Add(q.prefix + q.basenumberstripped, a);
                }
                DataTable dt = context.TheSysRz.TheQuoteLogic.GetQuoteStats(context, unique_id, true);
                if (dt == null)
                    return false;
                if (dt.Rows.Count <= 0)
                    return false;
                foreach (DataRow dr in dt.Rows)
                {
                    string pn = dr["partnumber"].ToString();
                    if (!Tools.Strings.StrExt(pn))
                        continue;
                    ArrayList a = null;
                    quotes.TryGetValue(pn, out a);
                    if (a == null)
                        continue;
                    if (a.Count <= 0)
                        continue;
                    foreach (orddet_quote q in a)
                    {
                        q.stock_matches = Tools.Data.NullFilterInt(dr["stock_matches"]);
                        q.excess_matches = Tools.Data.NullFilterInt(dr["excess_matches"]);
                        q.consign_matches = Tools.Data.NullFilterInt(dr["consign_matches"]);
                        q.sale_matches = Tools.Data.NullFilterInt(dr["sale_matches"]);
                        //q.sale_average = nData.NullFilter_Float(dr["sale_average"]);
                        //q.sale_min = nData.NullFilter_Float(dr["sale_min"]);
                        q.sale_max = nData.NullFilter_Float(dr["sale_max"]);
                        //q.sale_earliest = nData.NullFilter_DateTime(dr["sale_earliest"]);
                        q.sale_latest = nData.NullFilter_DateTime(dr["sale_latest"]);
                        //q.purchase_matches = Tools.Data.NullFilterInt(dr["purchase_matches"]);
                        //q.purchase_average = nData.NullFilter_Float(dr["purchase_average"]);
                        //q.purchase_min = nData.NullFilter_Float(dr["purchase_min"]);
                        //q.purchase_max = nData.NullFilter_Float(dr["purchase_max"]);
                        //q.purchase_earliest = nData.NullFilter_DateTime(dr["purchase_earliest"]);
                        //q.purchase_latest = nData.NullFilter_DateTime(dr["purchase_latest"]);
                        q.quote_matches = Tools.Data.NullFilterInt(dr["quote_matches"]);
                        //double quote_total_price = nData.NullFilter_Float(dr["quote_total_price"]);
                        //q.quote_average = quote_total_price / (double)q.quote_matches;
                        //q.quote_min = nData.NullFilter_Float(dr["quote_min"]);
                        q.quote_max = nData.NullFilter_Float(dr["quote_max"]);
                        //q.quote_earliest = nData.NullFilter_DateTime(dr["quote_earliest"]);
                        q.quote_latest = nData.NullFilter_DateTime(dr["quote_latest"]);
                        context.Update(q);
                    }
                }
                return true;
            }
            catch { }
            return false;
        }
        public void RemoveReq(ContextRz context, orddet_quote r)
        {
            //Added for compile
            ArrayList Customers = new ArrayList();
            foreach (KeyValuePair<string, dealcompany> kvp in CustomerHalf.CompaniesList(context))
            {
                Customers.Add(kvp.Value);
            }
            //Added for compile
            RemoveDetail(context, Customers, r);
        }
        public void RemoveBid(ContextRz context, orddet_rfq b)
        {
            //Added for compile
            ArrayList Vendors = new ArrayList();
            foreach (KeyValuePair<string, dealcompany> kvp in VendorHalf.CompaniesList(context))
            {
                Vendors.Add(kvp.Value);
            }
            //Added for compile
            RemoveDetail(context, Vendors, b);
        }
        //public void RemoveService(orddet_service s)
        //{
        //    //Added for compile
        //    ArrayList Vendors = new ArrayList();
        //    foreach (KeyValuePair<string, dealcompany> kvp in VendorHalf.CompaniesList(Rz3App.xMainForm.TheContextNM))
        //    {
        //        Vendors.Add(kvp.Value);
        //    }
        //    //Added for compile
        //    RemoveDetail(Vendors, s);
        //}
        public void RemoveDetail(ContextRz context, ArrayList cs, orddet_old x)
        {
            if (x.ParentDetailGet(context) != null)
                x.ParentDetailGet(context).DetailsGet(context).Remove(x);
            x.RemoveNodes();
            foreach (dealcompany c in cs)
            {
                c.Details.Remove(x);
            }
        }
        public void AbsorbCompanyAndContact(company comp, companycontact cont)
        {
            if (comp == null)
                return;
            if (cont == null)
                return;
            this.customer_uid = comp.unique_id;
            this.contact_uid = cont.unique_id;
            this.customer_name = comp.companyname;
            this.contact_name = cont.contactname;
        }
        public dealcompany GetVendor(String strCompanyID, String strContactID)
        {
            //return GetCompany(Vendors, strCompanyID, strContactID);
            return null;
        }
        public dealcompany GetCustomer(String strCompanyID, String strContactID)
        {
            //return GetCompany(Customers, strCompanyID, strContactID);
            return null;
        }
        public ArrayList GetOrders(ContextRz context, Enums.OrderType t)
        {
            String strTable = "ordhed";
            if (t != Rz5.Enums.OrderType.Any)
                strTable = ordhed.MakeOrdhedName(t);
            ArrayList quoteLines = GetAllOrddetQuotes(context);
            if (quoteLines == null || quoteLines.Count <= 0)
                return null;
            List<string> orderIDs = new List<string>();

            List<string> quoteLineUids = new List<string>();
            foreach (orddet_quote q in quoteLines)
            {
                string quoteLineUId = q.unique_id;
                orddet_line l = (orddet_line)context.QtO("orddet_line", "select * from orddet_line where quote_line_uid = '" + quoteLineUId + "'");
                if (l == null)
                    return null;
                switch (t)
                {
                    case Rz5.Enums.OrderType.Sales:
                        {
                            if (!orderIDs.Contains(l.orderid_sales))
                                orderIDs.Add(l.orderid_sales);
                            break;
                        }
                    case Rz5.Enums.OrderType.Quote:
                        {
                            if (!orderIDs.Contains(l.orderid_quote))
                                orderIDs.Add(l.orderid_quote);
                            break;
                        }
                    case Rz5.Enums.OrderType.Invoice:
                        {
                            if (!orderIDs.Contains(l.orderid_invoice))
                                orderIDs.Add(l.orderid_invoice);
                            break;
                        }

                }
            }

            //if (orderIDs.Count == 0)
            //    return null;
            //if (orderIDs.Count > 1)
            //{
            //    context.Leader.Error("More than 1 order was found to be associated with this quote line.  This is probably an bug in the code, please notify IT.");
            //    return null;
            //}


            String strSQL = "select * from " + strTable + " where unique_id IN (" + Tools.Data.GetIn(orderIDs) + ")";
            if (t != Enums.OrderType.Any)
                strSQL += " and ordertype = '" + t.ToString() + "'";
            strSQL += " order by ordertype, orderdate";
            return context.QtC(strTable, strSQL);
        }
        public ArrayList GetAllParts(ContextRz context)
        {
            return context.QtC("partrecord", "select * from partrecord where unique_id in (select base_partrecord_uid from dealpart where base_dealheader_uid = '" + unique_id + "') order by stocktype, fullpartnumber");
        }
        public ArrayList GetAllDetails(ContextRz context)
        {
            return context.QtC("dealdetail", "select * from dealdetail where base_dealheader_uid = '" + unique_id + "' order by fullpartnumber");
        }

        public ArrayList GetAllOrddetQuotes(ContextRz context)
        {
            return context.QtC("orddet_quote", "select * from orddet_quote where base_dealheader_uid = '" + unique_id + "' order by fullpartnumber");
        }
        public ArrayList GetAllOrderDetails(ContextRz context)
        {
            return context.QtC("orddet", "select * from orddet where base_dealheader_uid = '" + unique_id + "'");
        }
        public void ExportToCsvAsCustomer(ContextRz context)
        {
            context.Reorg();
            //try
            //{
            //    String strFolder = context.TheLeader.ChooseFolder();
            //    if (!Directory.Exists(strFolder))
            //        return;

            //    String name = context.TheLeader.AskForString("Name", "Export1", "Name");
            //    if (!Tools.Strings.StrExt(name))
            //        return;

            //    if (!Tools.Strings.HasString(name, ".csv"))
            //        name += ".csv";

            //    String strFile = Tools.Folder.ConditionFolderName(strFolder) + name;
            //    context.TheData.TheConnection.ExportCSV("select fullpartnumber, alternatepart, manufacturer, datecode, target_quantity, target_price, quantityordered, unitprice from orddet_quote where base_dealheader_uid = '" + this.unique_id + "' order by linecode", strFile, false, "Part,Alternate,Manufacturer,DC,Target Qty,Target Price,Quote Qty,Quote Price");
            //    Tools.FileSystem.Shell(strFile);
            //}
            //catch (Exception ex)
            //{
            //    context.TheLeader.Tell("xError: " + ex.Message);
            //}
        }
        public void ExportToExcelAsCustomer(ContextRz context)
        {
            try
            {
                String strFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "RzTemp\\";
                if (!System.IO.Directory.Exists(strFile))
                    System.IO.Directory.CreateDirectory(strFile);

                strFile += "temp_" + Tools.Strings.GetNewID() + ".xlsx";

                OfficeInterop.ExcelApplication xlApp = new OfficeInterop.ExcelApplication();
                OfficeInterop.ExcelWorkbook xlBook = xlApp.Workbook;
                OfficeInterop.ExcelWorksheet xlSheet = xlBook.Worksheet(1);
                int x = 1;
                xlSheet.SetCellValue(1, 1, dealheader_name);
                xlSheet.SetCellValue(2, 1, nTools.DateFormat_ShortDateTime(date_created));
                x = 4;
                ExportCustomer(context, xlSheet, ref x);
                x++;
                xlApp.Workbook.SaveAs(strFile);
                Tools.FileSystem.Shell(strFile);
            }
            catch (Exception ex)
            {
                context.TheLeader.Tell("Export Error: " + ex.Message);
            }
        }
        protected virtual void WriteExportCustomerHeader(OfficeInterop.ExcelWorksheet xlSheet, int x)
        {
            if (xlSheet != null)
            {
                xlSheet.SetCellValue(x, 1, "Qty Needed");
                xlSheet.SetCellValue(x, 2, "Part Number");
                xlSheet.SetCellValue(x, 3, "Alternate");
                xlSheet.SetCellValue(x, 4, "Vendor");
                xlSheet.SetCellValue(x, 5, "Contact");
                xlSheet.SetCellValue(x, 6, "Qty Avail");
                xlSheet.SetCellValue(x, 7, "Bid Qty");
                xlSheet.SetCellValue(x, 8, "Bid Price");
                xlSheet.SetCellValue(x, 9, "Condition");
                xlSheet.SetCellValue(x, 10, "Notes");
                xlSheet.SetCellValue(x, 11, "Ship Date");
                xlSheet.SetCellValue(x, 12, "Quote Quantity");
                xlSheet.SetCellValue(x, 13, "Quote Price");
            }
        }
        public void ExportCustomer(ContextRz context, OfficeInterop.ExcelWorksheet xlSheet, ref int x)  //, dealcompany c
        {
            xlSheet.SetCellValue(x, 1, customer_name);
            if (Tools.Strings.StrExt(contact_name))
                xlSheet.SetCellValue(x, 3, contact_name);
            company cx = CustomerObjectGet(context);
            if (cx != null)
            {
                if (Tools.Strings.StrExt(cx.primaryphone))
                    xlSheet.SetCellValue(x, 5, "Phone: " + cx.primaryphone);
            }
            x++;
            //write the header
            WriteExportCustomerHeader(xlSheet, x);
            x++;
            foreach (orddet_quote q in CustomerHalf.QuotesList(context))
            {
                xlSheet.SetCellValue(x, 1, Tools.Number.LongFormat(q.target_quantity));
                xlSheet.SetCellValue(x, 2, q.fullpartnumber);
                xlSheet.SetCellValue(x, 3, q.alternatepart);
                xlSheet.SetCellValue(x, 12, Tools.Number.LongFormat(q.quantityordered));
                xlSheet.SetCellValue(x, 13, nTools.MoneyFormat_2_6(q.unitprice));
                x++;
                foreach (orddet_rfq rq in q.DetailsGet(context))
                {
                    xlSheet.SetCellValue(x, 4, rq.companyname);
                    xlSheet.SetCellValue(x, 5, rq.contactname);
                    xlSheet.SetCellValue(x, 6, Tools.Number.LongFormat(rq.quantitystocked));
                    xlSheet.SetCellValue(x, 7, Tools.Number.LongFormat(rq.quantityordered));
                    xlSheet.SetCellValue(x, 8, nTools.MoneyFormat_2_6(rq.unitprice));
                    xlSheet.SetCellValue(x, 9, rq.condition);
                    xlSheet.SetCellValue(x, 10, rq.internalcomment + "  " + rq.quicknote);
                    if (Tools.Strings.StrExt(rq.manufacturer))
                        xlSheet.SetCellValue(x, 11, "Mfg: " + rq.manufacturer);
                    if (Tools.Strings.StrExt(rq.datecode))
                        xlSheet.SetCellValue(x, 12, "DC: " + rq.datecode);
                    if (Tools.Strings.StrExt(rq.datecode))
                        xlSheet.SetCellValue(x, 13, "Available: " + Tools.Number.LongFormat(rq.quantitycancelled));
                    if (Tools.Strings.StrExt(rq.leadtime))
                        xlSheet.SetCellValue(x, 14, "Lead time: " + rq.leadtime);
                    if (Tools.Strings.StrExt(rq.packaging))
                        xlSheet.SetCellValue(x, 15, "Packaging: " + rq.packaging);
                    if (Tools.Strings.StrExt(rq.condition))
                        xlSheet.SetCellValue(x, 16, "Condition: " + rq.condition);
                    if (Tools.Strings.StrExt(rq.alternatepart))
                        xlSheet.SetCellValue(x, 17, "Alt: " + rq.alternatepart);
                    if (Tools.Strings.StrExt(rq.description))
                        xlSheet.SetCellValue(x, 18, "Desc: " + rq.description);
                    if (Tools.Strings.StrExt(rq.rohs_info))
                        xlSheet.SetCellValue(x, 18, "Rohs: " + rq.rohs_info);
                    x++;
                }
            }
        }
        public void ExportToExcelAsVendor()
        {

        }
        public bool CheckDealQuotes(ContextRz context, List<orddet_quote> list)
        {
            try
            {
                if (list == null)
                    return false;
                if (list.Count <= 0)
                    return false;
                foreach (orddet_quote q in list)
                {
                    if (q == null)
                        continue;
                    if (q.isselected && q.IsQuoted)
                    {
                        if (!q.CheckQuoteBeforeSave(context))
                            return false;
                    }
                }
                return true;
            }
            catch { }
            return false;
        }
        //public bool CheckDealQuotes()
        //{
        //    try
        //    {
        //        if (CustomerHalf.Details == null)
        //            return false;
        //        if (CustomerHalf.Details.Count <= 0)
        //            return false;
        //        foreach (KeyValuePair<string, nObject> kvp in CustomerHalf.Details)
        //        {
        //            orddet_quote q = (orddet_quote)kvp.Value;
        //            if (q == null)
        //                continue;
        //            if (q.isselected && q.IsQuoted)
        //            {
        //                if (!q.CheckQuoteBeforeSave())
        //                    return false;
        //            }
        //        }
        //        return true;
        //    }
        //    catch { }
        //    return false;
        //}
        public NewMethod.n_user UserObjectGet(ContextNM x)
        {
            return (NewMethod.n_user)x.xSys.Users.GetByID(base_mc_user_uid);
        }
        public company CustomerObjectGet(ContextNM x)
        {
            return company.GetById(x, customer_uid);
        }
        public companycontact ContactObjectGet(ContextNM x)
        {
            return companycontact.GetById(x, contact_uid);
        }
        public ArrayList ReqsGetAll(ContextRz x)
        {
            if (CustomerHalf != null)
            {
                List<orddet_quote> quotes = CustomerHalf.QuotesList(x);
                ArrayList ret = new ArrayList();
                foreach (orddet_quote q in quotes)
                {
                    ret.Add(q);
                }
                return ret;
            }
            else
                return x.QtC("orddet_quote", "select * from orddet_quote where base_dealheader_uid = '" + this.unique_id + "' order by linecode");
        }
        public ArrayList BidsGetAll(ContextRz x)
        {
            if (VendorHalf != null)
            {
                List<orddet_rfq> bids = VendorHalf.BidsList(x);
                ArrayList ret = new ArrayList();
                foreach (orddet_rfq r in bids)
                {
                    ret.Add(r);
                }
                return ret;
            }
            else
                return x.QtC("orddet_rfq", "select * from orddet_rfq where base_dealheader_uid = '" + this.unique_id + "' order by linecode");
        }
        public void Obliterate(ContextRz context)
        {
            if (!Tools.Strings.StrExt(unique_id))
            {
                context.TheLeader.Tell("No ID");
                return;
            }

            context.Execute("delete from ordhed_quote where base_dealheader_uid = '" + this.unique_id + "'");
            context.Execute("delete from orddet_quote where base_dealheader_uid = '" + this.unique_id + "'");
            context.Execute("delete from ordhed_rfq where base_dealheader_uid = '" + this.unique_id + "'");
            context.Execute("delete from orddet_rfq where base_dealheader_uid = '" + this.unique_id + "'");
            context.Execute("delete from dealdetail where base_dealheader_uid = '" + this.unique_id + "'");
            context.Execute("delete from dealpart where base_dealheader_uid = '" + this.unique_id + "'");
            context.Execute("delete from dealcompany where the_dealheader_uid = '" + this.unique_id + "'");
            context.Delete(this);
        }
        public orddet BidReceive(ContextRz x, orddet_quote req)
        {
            company comp = null;
            companycontact cont = null;

            if (!x.Leader.ChooseCompany(x, ref comp, ref cont))
                return null;

            orddet_old other = (orddet_old)VendorHalf.DetailAdd(x, comp, cont);
            if (other != null)
            {
                other.target_quantity = req.target_quantity;
                other.quantityordered = req.target_quantity;
                other.Update(x);
                req.DetailAbsorb(x, other);
            }
            return other;
        }
        //Private Functions
        private void AddOrders(ContextNM x, Enums.OrderType t)
        {
            String strSQL = "select * from ordhed_" + t.ToString().ToLower() + " where base_dealheader_uid = '" + unique_id + "' order by orderdate";
            ArrayList a = x.QtC("ordhed_" + t.ToString().ToLower(), strSQL);
            foreach (ordhed order in a)
            {
                AllOrders.Add(order.unique_id, order);
            }
        }

        public virtual bool FormalQuoteCreatePossible(ContextRz context, List<orddet_quote> quotes)
        {
            if (!CheckDealQuotes(context, quotes))
            {
                context.TheLeader.Error("One or more of the quotes in this batch is missing some required information.");
                return false;
            }

            if (!CurrenciesAndRatesMatch(context, quotes))
            {
                context.TheLeader.Error("The currency and exchange rate information is not consistent among these quotes");
                return false;
            }

            return true;
        }

        static bool CurrenciesAndRatesMatch(ContextRz context, List<orddet_quote> quotes)
        {
            String name = "";
            Double rate = 0;

            foreach (orddet_quote q in quotes)
            {
                if (context.Accounts.IsBaseCurrency(q.currency_name))
                {
                    if (name == "")
                        name = context.Accounts.BaseCurrency;
                    else if (!Tools.Strings.StrCmp(name, context.Accounts.BaseCurrency))
                        return false;
                }
                else
                {
                    if (name == "")
                        name = q.currency_name;
                    else if (!Tools.Strings.StrCmp(name, q.currency_name))
                        return false;

                    if (rate == 0)
                        rate = q.exchange_rate;
                    else if (rate != q.exchange_rate)
                        return false;
                }
            }

            return true;
        }
    }

    //Public Classes
    public partial class dealheader_auto : nObject
    {
    }
    public class DealHalf
    {
        //Public Virtual Properties
        public virtual String Caption
        {
            get
            {
                return "Customer";
            }
        }
        public virtual String TableName
        {
            get
            {
                return "";
            }
        }
        //Public Variables
        public dealheader TheDealHeader;
        public Dictionary<String, Item> Details;
       
        //Public Virtual Functions
        public virtual void Init(ContextNM x, dealheader deal)
        {
            TheDealHeader = deal;
            Details = new Dictionary<string, Item>();
            if (!Tools.Strings.StrExt(deal.unique_id))
                return;
            Details = x.TheData.QtD(x, TableName, "select * from " + TableName + " where base_dealheader_uid = '" + deal.unique_id + "' and isnull(linkid, '') <> 'auto' and isnull(is_removedfromque,0) = 0 order by linecode, companyname, orderdate, fullpartnumber");
           

        }
        public virtual orddet DetailAdd(ContextRz x, company comp, companycontact cont)
        {
            return null;
        }

        //Public Functions
        public Dictionary<String, dealcompany> CompaniesList(ContextRz context)
        {
            Dictionary<String, dealcompany> ret = new Dictionary<String, dealcompany>();

            foreach (KeyValuePair<String, Item> kvp in Details)
            {
                orddet_old d = (orddet_old)kvp.Value;

                String caption = d.companyname;
                //if (Tools.Strings.StrExt(d.contactname))
                //    caption += " - " + d.contactname;
                if (!Tools.Strings.StrExt(caption))
                    caption = "No company assigned";

                dealcompany c = null;
                if (ret.ContainsKey(caption.ToLower()))
                {
                    c = ret[caption.ToLower()];
                }
                else
                {
                    c = new dealcompany();
                    c.companyname = d.companyname;
                    c.the_company_uid = d.base_company_uid;
                    c.contactname = d.contactname;
                    c.the_companycontact_uid = d.base_companycontact_uid;

                    companycontact contact = companycontact.GetById(context, d.base_companycontact_uid);
                    if (contact != null)
                    {
                        c.phone = contact.primaryphone;
                        c.email = contact.primaryemailaddress;

                        //update the detail in cases of changed company and contact names
                        if (!Tools.Strings.StrCmp(d.contactname, c.contactname) || !Tools.Strings.StrCmp(d.companyname, c.companyname))
                        {
                            d.contactname = contact.contactname;
                            d.companyname = contact.companyname;
                            context.Update(d);
                        }
                    }

                    if (!Tools.Strings.StrExt(c.phone) || !Tools.Strings.StrExt(c.email))
                    {
                        company company = company.GetById(context, d.base_company_uid);
                        if (company != null)
                        {
                            if (!Tools.Strings.StrExt(c.phone))
                                c.phone = company.primaryphone;

                            if (!Tools.Strings.StrExt(c.email))
                                c.email = company.primaryemailaddress;
                        }
                    }
                    c.Details = new ArrayList();
                    ret.Add(caption.ToLower(), c);
                }

                c.Details.Add(kvp.Value);
            }

            return ret;
        }
    }
    public class DealHalfQuote : DealHalf
    {
        //Public Override Properties
        public override string TableName
        {
            get
            {
                return "orddet_quote";
            }
        }
        public override string Caption
        {
            get
            {
                return "Vendor";
            }
        }
        //Public Variables
        public ordhed_quote xFormalQuote;
        public ordhed_sales xSalesOrder;


        HubspotApi.Deal TheHubspotDeal;

        //Public Override Functions
        public override orddet DetailAdd(ContextRz x, company comp, companycontact cont)
        {
            return QuoteAdd(x);
        }
        
        public virtual bool FormalQuoteCreate(ContextRz x, bool bShow, List<orddet_quote> selquotes = null)
        {
            if (string.IsNullOrEmpty(TheDealHeader.customer_uid))
                x.Leader.Error("Customer ID not detected.  Cannot create quote.");

            company c = TheDealHeader.CustomerObjectGet(x);
            //Set Formal Quote to Company Owner's Name
            n_user agent = n_user.GetById(x, c.base_mc_user_uid);
            ////Formal Quotes and beyond must always be in the company owner's name.
            //if (agent.unique_id != c.base_mc_user_uid)
            //    agent = n_user.GetById(x,c.base_mc_user_uid);

            ordhed_quote h;
            string msg = "";
            if (selquotes == null)
                selquotes = SelectedQuotesGet(x, ref msg);
            if (selquotes.Count == 0)
            {
                if (Tools.Strings.StrExt(msg))
                    x.TheLeader.Error(msg);
                else
                    x.TheLeader.Error("No selected quotes");
                return false;
            }

            //At batch to quote time, we just pop an alert if has aged invoices
            x.TheSysRz.TheQuoteLogic.CheckAgedInvoices(x, c, TheDealHeader, false);


            //Ensure possible
            if (!TheDealHeader.FormalQuoteCreatePossible(x, selquotes))
                return false;




            //Check for Existing linked Formal Quote
            h = (ordhed_quote)x.QtO("ordhed_quote", "select * from ordhed_quote where base_dealheader_uid = '" + TheDealHeader.unique_id + "'");
            bool newquote = false;
            if (h != null)
            {
                //If no Existing item found, offer to add to existing                
                if (x.TheLeader.AskYesNo("Do you want to create a new quote? (click \"NO\" If you want to add this to an existing Quote / Sale)"))
                {
                    newquote = true;
                    h = null;
                }
                else
                {
                    //x.TheLeader.Tell("A quote already exists for this batch / customer PO.  If you are adding a new item to the quote, please right-click your req and choose 'Add to FQ / SO '");
                    foreach (orddet_quote q in selquotes)
                        TheDealHeader.CustomerHalf.AddToFQSO(x, q, TheDealHeader);
                    return false;
                }

            }

            //Check null, we may have just added to an existing FQ
            if (h == null)
            {
                //New Quote
                h = (ordhed_quote)ordhed.CreateNew(x, Rz5.Enums.OrderType.Quote);


                //If only service lines, set header opp stage to "Service"
                if (IsServiceOnly(x))
                    h.opportunity_type = "Service";





                //Set Split Agent For Quote Header
                if (agent.Name == "Vendor")
                    agent = x.xUser;
                SetQuoteAgent(x, h, agent);

                //Now that we have ther agent, set the buyer to the seller by default
                h.buyername = h.agentname;
                h.orderbuyerid = h.base_mc_user_uid;


                if (c == null)
                {
                    x.TheLeader.Error("This company could not be located.");
                    return false;
                }
                if (!h.CanAssignCompany(x, c))
                    return false;
                h.AbsorbCompany(x, c);

                h.currency_name = selquotes[0].currency_name;
                h.exchange_rate = selquotes[0].exchange_rate;
                //Pass the Hubspot ID
                h.hubspot_deal_id = TheDealHeader.hubspot_deal_id;

                companycontact xct = TheDealHeader.ContactObjectGet(x);
                if (xct != null)
                {
                    if (!h.CanAssignContact(x, xct))
                        return false;

                    h.AbsorbContact(x, xct);
                }
                h.base_dealheader_uid = TheDealHeader.unique_id;
                h.created_by_tree = true;
                //KT Add OEM product signal
                h.is_oem_product = TheDealHeader.is_oem_product;               
            }


            //Set Opportunity Stage
            h.opportunity_stage = SM_Enums.OpportunityStage.formal_quote_created.ToString();
            //Set Opportunity type

            //Get the opp type now, can't create Quote without, will use this variable to set on the quote after creation
            string oppty_type = x.Leader.ChooseOneChoice(x, "opportunity_type", "Opportunity Type:") ?? "";            
            h.opportunity_type = oppty_type;



            h.xDeal = TheDealHeader;
            h.Update(x);
            //this is where the option needs to go for the user to choose to quote just the previously unquoted items, etc
            
            ArrayList previousquotes = new ArrayList();            
            foreach (orddet_quote p in selquotes)
            {
                ordhed existingHeader = p.OrderObject(x);
                if (existingHeader != null)
                {
                    if (!newquote)
                        previousquotes.Add(p);
                }             

            }
            if (previousquotes.Count > 0)
            {
                if (newquote)
                {
                    foreach (orddet_quote rem in previousquotes)
                    {
                        selquotes.Remove(rem);
                    }
                }
            }

           
            bool phx = false;
            foreach (orddet_quote q in selquotes)
            {
                if (!phx && !Tools.Strings.StrExt(h.warranty_period))
                    phx = ApplyWarrantyPeriod(h, q);
                AddQuoteDetailToOrder(x, h, q, agent);
                
            }
            //h.GatherDetails();

            //Checked for AR Alerts
            x.TheSysRz.TheQuoteLogic.CheckARAlerts(x, c, h);

            //Hubspot

            //if (agent.is_hubspot_enabled)
            //{
            //    TheHubspotDeal = null;
            //    //Fetch the deal from Hubpsot API     
            //    if (TheDealHeader.hubspot_deal_id > 0)
            //    {
            //        //If the deal is found 
            //        TheHubspotDeal = HubspotApi.Deals.GetDealByID(TheDealHeader.hubspot_deal_id);
            //        //x.TheSysRz.TheOrderLogic.UpdateHubspotDeal(x, TheDealHeader, TheHubspotDeal);
            //        if (TheHubspotDeal == null)
            //            throw new Exception("Hubpsot API did not return a deal for ID: " + TheDealHeader.hubspot_deal_id);
            //    }
            //    else if (TheHubspotDeal == null)
            //        TheHubspotDeal = x.TheSysRz.TheOrderLogic.CreateHubspotDeal(x, this);



            //    if (TheHubspotDeal != null)
            //        if (TheHubspotDeal.dealId > 0)
            //            h.hubspot_deal_id = TheHubspotDeal.dealId;
            //}
            //h.Update(x);
            TheDealHeader.AddOrder(h);
            if (bShow)
                x.Show(h);
            xFormalQuote = h;
            return true;
        }

        private void SetQuoteAgent(ContextRz x, ordhed_quote h, n_user agent)
        {
            //the CreateNew method is not aware of the sender, i.e. batch.  Therefore need to set Agent name out here.    

            //By default set to current Batch Owner's name
            //if (TheDealHeader == null)
            //    CurrentDealAgent = n_user.GetById(x, TheDealHeader.base_mc_user_uid);
            h.agentname = agent.name;
            h.base_mc_user_uid = agent.unique_id;


            //sales assistant team

            if (x.xUser.IsTeamMember(x, "sales_assistant", agent))
            {
                h.base_mc_user_uid = agent.unique_id;
                h.agentname = agent.name;

                return;
            }

            ////If Current batch agent is an assistant to someone (regardless of company owner, i.e. vendors), make the quote under the leader's   
            ////Sales Rep assigned assistant
            //bool isAssitant = !string.IsNullOrEmpty(agent.assistant_to_uid);
            //if (isAssitant)
            //{
            //    n_user u = n_user.GetById(x, agent.assistant_to_uid);
            //    if (u == null)
            //        throw new Exception("Users appears to be an assistant, could not determine the assistant-to user.  Cannot set the Formal Quote to the proper account.");
            //    h.base_mc_user_uid = u.unique_id;
            //    h.agentname = u.name;
            //}

            



        }

        private bool IsServiceOnly(ContextRz x)
        {
            //if the only quotes are service type return true.            
            string msg = "";

            List<orddet_quote> selectedQuotes = this.SelectedQuotesGet(x, ref msg);
            if (selectedQuotes.Count <= 0)
                return false;
            foreach (orddet_quote q in selectedQuotes)
            {
                if (q.StockType != Enums.StockType.Service)
                    return false;

            }

            return true;
        }

        protected virtual bool ApplyWarrantyPeriod(ordhed_quote h, orddet_quote q)
        {
            return true;
        }
        protected void AddQuoteDetailToOrder(ContextRz context, ordhed_quote o, orddet_quote q, n_user agent)
        {
            ArrayList acceptedBids = new ArrayList();
            ArrayList allBids = new ArrayList();
            if (q.DetailsGet(context) != null)
            {
                if (q.DetailsGet(context).Count > 0)
                {
                    foreach (orddet_rfq r in q.DetailsGet(context))
                    {
                        allBids.Add(r);
                        if (r.is_accepted)
                            acceptedBids.Add(r);
                    }
                }
            }

            if (acceptedBids.Count == 0 && allBids.Count == 1)
            {
                acceptedBids = allBids;  //consider a single bid as accepted
            }

            if (acceptedBids.Count <= 0)
                return;

            this.Details = new Dictionary<string, Item>();
            foreach (orddet_rfq r in acceptedBids)
            {
                //Create a new quote line, then apply bid info, then delete the old quote line
                orddet_quote qt = (orddet_quote)q.CloneValues(context);
                qt.source = q.source;
                //Carry Split Commission
                qt.split_commission_ID = q.split_commission_ID;
                //Fill quote values from bid.
                //QT
                int qty = Convert.ToInt32(r.quantityordered);
                qt.quantityordered = qty;
                //Unit Cose (Bid Price)
                qt.unitcost = r.unitprice;
                //Maunfacturer
                qt.manufacturer = r.manufacturer;
                //Date Code
                qt.datecode = r.datecode;
                //Condition
                qt.condition = r.condition;
                //Vendor Information
                qt.vendorid = r.base_company_uid;
                qt.vendor_company_uid = r.base_company_uid;
                qt.vendorname = r.companyname;
                qt.vendorcontactid = r.base_companycontact_uid;
                qt.vendorcontactname = r.contactname;
                qt.country_of_origin_vendor = r.country;

                //STOCK / CONSIGN
                if (r.isinstock)
                {
                    //STOCK
                    qt.stockid = r.stockid;
                    if (r.StockType == Enums.StockType.Stock)
                    {
                        qt.stocktype = Enums.StockType.Stock.ToString();
                        qt.StockType = Enums.StockType.Stock;
                        if (r.unitprice <= 0)
                            if (agent.IsTeamMember(context, "Distributor Sales", agent))
                            {
                                double dblCost = context.TheSysRz.TheOrderLogic.ApplyDistySalesStockCost(context, q);
                                qt.unitcost = dblCost;
                                r.unitprice = dblCost;
                                //Make sure to set the bid cost at this time, as this is what carries from FQ to Sale
                                r.Update(context);
                            }


                    }
                    //CONSIGN
                    else if (r.StockType == Enums.StockType.Consign)
                    {
                        //Consignment Stock
                        if (!string.IsNullOrEmpty(r.consignment_code))//then if consginment code, overwrite this with the consignment split
                        {
                            qt.consignment_code = r.consignment_code;
                            qt.stocktype = Enums.StockType.Consign.ToString();
                            qt.StockType = Enums.StockType.Consign;
                            consignment_code code = consignment_code.GetByName(context, r.consignment_code);
                            if (code == null)
                                throw new Exception("Invalid consignment code.");
                            qt.unitcost = code.CostCalc(q.unitprice);
                            //q.unitcost = context.TheSysRz.TheOrderLogic.ApplyConsignmentCost(context, q, r);
                        }
                    }
                }

                

                //List Acquisition, can apply to stock, or excess, mostly excess
                context.TheSysRz.TheQuoteLogic.SetListAttribution(context, r, qt);

                //Insert the new quote line.
                context.Insert(qt);

                //Absorb the bid into the new quote line
                qt.DetailAbsorb(context, r);

                //Stamp the Bid with the ID of the resulting quote line.
                r.the_orddet_quote_uid = qt.unique_id;
                context.Update(r);

                //Add new quote line to dealheader, old quote will get deleted after this bids loop.
                this.Details.Add(qt.unique_id, qt);

                //Add this new quote line to the ordhed_quote
                if (!o.DetailsVar.RefsGet(context).ContainsId(context, qt.Uid))
                    o.DetailsVar.RefsAdd(context, qt);


            }

            //Delete the original quote line, as it should now be one 
            //(or more, in case of mixed stocktypes with separate allocations, etc) 
            //stock lines to fill it's place.
            context.Delete(q);




            //return;
            //else if (acceptedBids.Count == 1)
            //{
            //orddet_rfq r = (orddet_rfq)acceptedBids[0];
            //q.unitcost = r.unitprice; //1st take cost for the bid price
            //Apply DistySales pricing rules if user is disty sales, and stock has no cost.
            //if (r.stocktype.ToLower() == "stock")
            //if (r.unitprice <= 0)
            //    if (CurrentDealAgent.IsTeamMember(context, "Distributor Sales", CurrentDealAgent))
            //    {
            //        double dblCost = context.TheSysRz.TheOrderLogic.ApplyDistySalesStockCost(context, q);
            //        q.unitcost = dblCost;
            //        r.unitprice = dblCost;
            //        //Make sure to set the bid cost at this time, as this is what carries from FQ to Sale
            //        r.Update(context);
            //    }


            //if (!string.IsNullOrEmpty(r.consignment_code))//then if consginment code, overwrite this with the consignment split
            //{
            //    consignment_code code = consignment_code.GetByName(context, r.consignment_code);
            //    q.unitcost = code.CostCalc(q.unitprice);
            //    //q.unitcost = context.TheSysRz.TheOrderLogic.ApplyConsignmentCost(context, q, r);
            //}

            //q.vendorid = r.base_company_uid;
            //q.consignment_code = r.consignment_code;

            ////This is the consignment / stock vendor
            //q.vendor_company_uid = r.base_company_uid;
            //q.vendorname = r.companyname;
            //q.vendorcontactid = r.base_companycontact_uid;
            //q.vendorcontactname = r.contactname;

            ////List Acquisition
            //context.TheSysRz.TheQuoteLogic.SetListAttribution(context, r, q);


            //context.TheDelta.Update(context, q);
            //  }

            //if (!o.DetailsVar.RefsGet(context).ContainsId(context, q.Uid))
            //    o.DetailsVar.RefsAdd(context, q);
        }


        public virtual bool SalesOrderCreate(ContextRz x, bool show)
        {
            if (!FormalQuoteCreate(x, false))
                return false;
            if (xFormalQuote == null)
                return false;
            xSalesOrder = x.TheSysRz.TheQuoteLogic.SalesOrderCreate(x, xFormalQuote);
            if (xSalesOrder == null)
                return false;
            if (show)
                x.Show(xSalesOrder);
            return true;
        }
        //Public Functions
        public bool FormalQuoteCreate(ContextRz x, List<orddet_quote> quoteLnes = null)
        {
            return FormalQuoteCreate(x, true, quoteLnes);
        }
        public bool SalesOrderCreate(ContextRz x)
        {
            return SalesOrderCreate(x, true);
        }
        public orddet_quote QuoteAdd(ContextRz x)
        {
            //company comp = TheDeal.CustomerObjectGet(x);
            //if (comp == null)
            //{
            //    x.TheLeader.Error("Please select a customer before continuing");
            //    return null;
            //}

            orddet_quote r = orddet_quote.New(x);
            x.Insert(r);
            QuoteAbsorb(x, r);
            return r;
        }
        protected virtual void QuoteAbsorbExtra(orddet_quote r, company c)
        {
            //do nothing
        }
        public void QuoteAbsorb(ContextRz x, orddet_quote r)
        {
            company comp = TheDealHeader.CustomerObjectGet(x);
            QuoteAbsorbExtra(r, comp);
            r.base_dealheader_uid = TheDealHeader.unique_id;
            r.agentname = TheDealHeader.agentname;
            r.base_mc_user_uid = TheDealHeader.base_mc_user_uid;
            if (comp.companyname.Length > 50)
                comp.companyname = comp.companyname.Substring(0, 49);
            r.CompanyVar.RefSet(x, comp);
            r.ContactVar.RefSet(x, TheDealHeader.ContactObjectGet(x));            
            r.linecode = Details.Count + 1;
            r.orderdate = DateTime.Now;
            r.base_dealheader_uid = TheDealHeader.unique_id;


            //SplitCommission
            if (!string.IsNullOrEmpty(TheDealHeader.split_commission_ID))
                r.split_commission_ID = TheDealHeader.split_commission_ID;
       
            r.Update(x);
            Details.Add(r.unique_id, r);
            
        }
        public List<orddet_quote> QuotesList(ContextRz context)
        {
            List<orddet_quote> ret = new List<orddet_quote>();
            foreach (KeyValuePair<String, Item> k in Details)
            {
                ret.Add((orddet_quote)k.Value);
            }
            return ret;
        }
        public bool AddToSalesOrder(ContextRz x, orddet_rfq d)
        {
            return AddToSalesOrder(x, d, true);
        }


        public bool AddToSalesOrder(ContextRz x, orddet_rfq d, bool show)
        {
            if (x == null)
                return false;
            if (d == null)
                return false;
            if (!Tools.Strings.StrExt(d.the_orddet_quote_uid))
                return false;
            orddet_quote q = orddet_quote.GetById(x, d.the_orddet_quote_uid);
            if (q == null)
                return false;


            string id = x.Leader.AskForSalesOrderIdToAdd();
            if (!Tools.Strings.StrExt(id))
                return false;
            ordhed_sales s = ordhed_sales.GetById(x, id);
            if (s == null)
                return false;
            orddet_line l = (orddet_line)s.GetNewDetail((ContextRz)x);
            l.importid = q.importid;
            l.quantity = Convert.ToInt32(q.quantityordered);
            l.fullpartnumber = q.fullpartnumber;
            l.datecode = q.datecode;
            l.description = q.description;
            l.internalcomment = q.internalcomment;
            l.internalpartnumber = q.internalpartnumber;
            l.manufacturer = q.manufacturer;
            l.packaging = q.packaging;
            l.partsetup = q.partsetup;
            l.partsperpack = q.partsperpack;
            l.quote_line_uid = q.unique_id;
            l.rohs_info = q.rohs_info;
            l.unit_cost = d.unitprice;
            l.unit_price = q.unitprice;
            l.vendor_contact_name = d.contactname;
            l.vendor_contact_uid = d.base_companycontact_uid;
            l.vendor_name = d.companyname;
            l.vendor_uid = d.base_company_uid;
            l.warranty_period = q.warranty_period;
            l.Update(x);
            if (show)
                x.Show(s);
            return true;
        }


        //KT Making These Strings 
        public string AddQuoteToFormalQuote(ContextRz x, ordhed_quote s, orddet_quote q)
        {
            return AddQuoteToFormalQuote(x, s, q, false);
        }
        public string AddQuoteToFormalQuote(ContextRz context, ordhed_quote s, orddet_quote q, bool show)
        {
            if (context == null)
                return null;
            if (s == null)
                return null;
            if (q == null)
                return null;
            orddet_quote qq = (orddet_quote)q.CloneValues(context);
            qq.base_ordhed_uid = s.unique_id;
            //qq.base_dealheader_uid = "";
            qq.base_dealdetail_uid = "";
            qq.is_removedfromque = true;
            orddet_rfq d = null;
            foreach (orddet_rfq dd in q.DetailsGet(context))
            {
                if (dd.is_accepted)
                {
                    d = (orddet_rfq)dd.CloneValues(context);
                    break;
                }
            }
            if (d == null)
                d = orddet_rfq.New(context);
            qq.vendor_company_uid = d.base_company_uid;
            qq.vendorid = d.base_company_uid;
            qq.vendorname = d.companyname;
            qq.vendorcontactid = d.base_companycontact_uid;
            qq.vendorcontactname = d.contactname;
            if (d.unitprice > 0)
                qq.unitcost = d.unitprice;

            //KT Get all stuff form Insert from Batch
            qq.internalpartnumber = q.internalpartnumber;



            context.Insert(qq);
            if (Tools.Strings.StrExt(d.base_company_uid))
            {
                d.base_dealdetail_uid = "";
                d.base_dealheader_uid = "";
                d.the_orddet_quote_uid = qq.unique_id;
                context.Insert(d);
            }
            if (show)
                context.Show(s);
            return qq.unique_id;
        }

        public void AddToFQSO(ContextRz x, orddet_quote o, dealheader xDeal)
        {
            //ordhed oh = frmChooseFQSO.ChooseFormalQuoteSalesOrder(RzWin.Context, o.base_company_uid);
            ordhed oh = x.Leader.ChooseFQSO(x, o.base_company_uid, "FormalQuote");
            if (oh == null)
                return;
            //KT Close the orddet_quote

            //RzWin.Form.TabCloseByID(o.unique_id);
            x.Leader.CloseTabsByID(x, o.unique_id);
            //Get SalesOrder where orderid_quote = oh.unique_id
            //KT Add the line to the selected FQ
            ((SysRz5)x.xSys).TheOrderLogic.CheckQuoteBeforeSave(x, o);
            string NewQuoteLineUID = xDeal.CustomerHalf.AddQuoteToFormalQuote(x, (ordhed_quote)oh, o);
            //KT Clost the Formal Quote we are adding to.
            x.Leader.CloseTabsByID(x, oh.unique_id);
            if (NewQuoteLineUID == null)
            {
                x.Leader.Tell("The new quote line was NOT successfully addded.");
                return;
            }
            else
            {
                //kt open / reopen quote after new line add
                NMWin.ContextDefault.Show(oh);
            }

            List<string> SalesIDs = x.TheSysRz.TheQuoteLogic.GetRelatedSalesIDs(x, oh.unique_id);
            switch (SalesIDs.Count)
            {
                case 0:
                    break;
                case 1:
                    {
                        string SalesID = SalesIDs[0];
                        ordhed_sales sale = ordhed_sales.GetById(x, SalesID);
                        try
                        {
                            if (x.Leader.AskYesNo("It appears this quote is associated with SO# " + sale.ordernumber + ".  Would you like to add this to the Sales Order as well as the Quote?"))
                            {
                                //string quoteid = RzWin.Context.SelectScalarString("select quote_lind_uid from orddet_line where orderid_quote = '"+'";
                                xDeal.CustomerHalf.AddQuoteToSalesOrder(x, sale, o, NewQuoteLineUID, oh.unique_id, false);
                                bool focus = false;
                                //if (NMWin.MainForm.tabs.IsObjectOpen(sale.unique_id, ref focus))
                                //{
                                x.Leader.CloseTabsByID(x, sale.unique_id);

                                //}
                                NMWin.ContextDefault.Show(sale);
                                x.Leader.Tell("Successfully added quote line to Formal Quote# " + oh.ordernumber + " and Sales Order " + sale.ordernumber + ".");
                            }
                            else
                            {
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            string error = ex.ToString();
                        }
                    }
                    break;
                default:
                    x.Leader.Tell("There appears to be more than on sales order associated with this sale.  Please correct before proceeding.");
                    break; //I may do something in the future when there are more than one sales order ids in the list.
            }
        }



        public bool AddQuoteToSalesOrder(ContextRz x, ordhed_sales s, orddet_quote q, string NewQuoteLineUID, string orderid_quote)
        {
            return AddQuoteToSalesOrder(x, s, q, NewQuoteLineUID, orderid_quote, false);
        }
        public bool AddQuoteToSalesOrder(ContextRz x, ordhed_sales s, orddet_quote q, string NewQuoteLineUID, string orderid_quote, bool show)
        {
            if (x == null)
                return false;
            if (s == null)
                return false;
            if (q == null)
                return false;
            orddet_rfq d = null;
            foreach (orddet_rfq dd in q.DetailsGet(x))
            {
                if (dd.is_accepted)
                {
                    d = dd;
                    break;
                }
            }
            if (d == null)
                d = orddet_rfq.New(x);
            orddet_line l = (orddet_line)s.GetNewDetail((ContextRz)x);
            l.importid = q.importid;
            l.quantity = Convert.ToInt32(q.quantityordered);
            l.fullpartnumber = q.fullpartnumber;
            l.condition = q.condition;
            l.datecode = q.datecode;
            l.description = q.description;
            l.internalcomment = q.internalcomment;
            l.internalpartnumber = q.internalpartnumber;
            l.manufacturer = q.manufacturer;
            l.packaging = q.packaging;
            l.partsetup = q.partsetup;
            l.partsperpack = q.partsperpack;
            l.quote_line_uid = q.unique_id;
            l.rohs_info = q.rohs_info;
            if (d.unitprice > 0)
                l.unit_cost = d.unitprice;
            else
                l.unit_cost = q.unitcost;
            l.unit_price = q.unitprice;
            l.vendor_contact_name = d.contactname;
            l.vendor_contact_uid = d.base_companycontact_uid;
            l.vendor_name = d.companyname;
            l.vendor_uid = d.base_company_uid;
            l.warranty_period = q.warranty_period;
            //KT link get related data to the new sales line
            l.quote_line_uid = NewQuoteLineUID;
            l.orderid_quote = orderid_quote;
            l.internal_customer = q.internalpartnumber;

            partrecord p = null;
            if (d.isinstock)
                p = partrecord.GetById(x, d.stockid);
            Enums.StockType tpe = Enums.StockType.Buy;
            if (p != null)
                tpe = p.StockType;
            l.StockType = tpe;
            if (d != null)
                l.datecode_purchase = d.datecode;
            if (l.StockType == Enums.StockType.Stock || l.StockType == Enums.StockType.Consign)
                if (!l.LinkAndAllocate((ContextRz)x, p))
                    return false;
            x.Update(l);
            if (show)
                x.Show(s);
            return true;
        }

        public virtual List<orddet_quote> SelectedQuotesGet(ContextRz x, ref string msg)
        {

            //Get All Quotes in LvQuotes where is_selected = true
            List<orddet_quote> ret = new List<orddet_quote>();
            foreach (orddet_quote q in QuotesList(x))
                if (q.isselected)
                    ret.Add(q);

            return ret;
        }

       
    }
    public class DealHalfBid : DealHalf
    {
        //Public Override Properties
        public override string TableName
        {
            get
            {
                return "orddet_rfq";
            }
        }
        public override String Caption
        {
            get
            {
                return "Vendor";
            }
        }

        //Public Override Functions
        public override orddet DetailAdd(ContextRz x, company comp, companycontact cont)
        {
            return BidAdd(x, comp, cont);
        }
        //Public Functions
        protected virtual void BidAddExtra(company comp, orddet_rfq r)
        {
            if (comp != null)
                r.StockType = Enums.StockType.Buy;
        }
        public orddet_rfq BidAdd(ContextNM x, company comp, companycontact cont)
        {
            orddet_rfq b = orddet_rfq.New(x);
            BidAddExtra(comp, b);
            BidAbsorb(x, b);

            x.Insert(b);
            if (comp != null)
            {
                if (Tools.Strings.StrExt(comp.unique_id))
                {
                    b.CompanyVar.RefSet(x, comp);
                    if (b.companyname != comp.companyname)
                        b.companyname = comp.companyname;  //2014_05_03 i saw this not get set on the first pass, then get set on the second pass
                }
            }
            if (cont != null)
            {
                if (Tools.Strings.StrExt(cont.unique_id))
                    b.ContactVar.RefSet(x, cont);
            }
            Details.Add(b.unique_id, b);
            return b;
        }

        public void BidAbsorb(Context x, orddet_rfq b)
        {
            b.base_dealheader_uid = TheDealHeader.unique_id;
            b.agentname = TheDealHeader.agentname;
            b.base_mc_user_uid = TheDealHeader.base_mc_user_uid;
            b.orderdate = DateTime.Now;
            b.base_dealheader_uid = TheDealHeader.unique_id;
            b.linecode = Details.Count + 1;
        }

        public List<orddet_rfq> BidsList(ContextRz context)
        {
            List<orddet_rfq> ret = new List<orddet_rfq>();
            foreach (KeyValuePair<String, Item> k in Details)
            {
                ret.Add((orddet_rfq)k.Value);
            }
            return ret;
        }
        public bool FormalBidCreate(ContextRz x, String vendor_uid, String vendor_contact_uid)
        {
            return FormalBidCreate(x, vendor_uid, vendor_contact_uid, true);
        }
        public bool FormalBidCreate(ContextRz x, String vendor_uid, String vendor_contact_uid, bool bShow)
        {
            ordhed_rfq h;

            company xc = company.GetById(x, vendor_uid);
            if (xc == null)
            {
                x.TheLeader.Error("The vendor could not be located.");
                return false;
            }

            //this is where the option needs to go for the user to choose to quote just the previously unquoted items, etc

            if (BidsList(x).Count == 0)
            {
                x.TheLeader.Error("Please enter at least one bid before continuing.");
                return false;
            }
            //if (!TheDeal.CheckDealQuotes())
            //{
            //    x.TheLeader.Error("One or more of the quotes in this batch is missing some required information.");
            //    return false;
            //}

            h = (ordhed_rfq)x.QtO("ordhed_rfq", "select * from ordhed_rfq where base_dealheader_uid = '" + TheDealHeader.unique_id + "'");

            if (h == null)
            {
                h = (ordhed_rfq)ordhed.CreateNew(x, Rz5.Enums.OrderType.RFQ);

                //if (!h.CanAssignCompany(xc))
                //    return false;

                h.AbsorbCompany(x, xc);

                companycontact xct = companycontact.GetById(x, vendor_contact_uid);
                if (xct != null)
                {
                    //if (!h.CanAssignContact(xct))
                    //    return false;

                    h.AbsorbContact(x, xct);
                }

                h.base_dealheader_uid = TheDealHeader.unique_id;
                h.created_by_tree = true;
                x.Update(h);
            }

            x.Reorg();
            //h.xDeal = TheDeal;
            x.Update(h);

            foreach (orddet_rfq q in BidsList(x))
            {
                if (q.companyname == xc.companyname)
                {
                    q.base_ordhed_uid = h.unique_id;
                    q.OrderType = h.OrderType;
                    q.ordernumber = h.ordernumber;
                    x.Update(q);
                }
            }

            //force the cache
            //h.GatherDetails();
            x.Update(h);
            TheDealHeader.AddOrder(h);
            //FireOrderAdded(h);
            if (bShow)
                x.Show(h);
            //xFormalQuote = h;
            return true;
        }
    }


}
