using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NewMethod;
using Core;
using HubspotApis;
using Rz5.Enums;
using SensibleDAL;
using System.Linq;

namespace Rz5
{
    public class QuoteLogic : NewMethod.Logic
    {
        public override void ActInstance(Context context, ActArgs args)
        {
            List<ordhed_quote> quotes = new List<ordhed_quote>();
            List<ordhed> lines = new List<ordhed>();
            ContextRz x = (ContextRz)context;
            foreach (IItem i in args.TheItems.AllGet(context))
            {
                quotes.Add((ordhed_quote)i);
                lines.Add((ordhed)i);
            }

            List<string> ignoredPropertiesList = new List<string>() { "tbd_terms", "insufficient credit", "orderreference" };

            switch (args.ActionName.Trim().ToLower())
            {

                case "salesorder":
                    ordhed_sales sale = SalesOrderCreate(x, quotes);
                    if (sale != null)
                        context.Show(sale);
                    break;
                case "print":
                    {
                        args.Handled = true;
                        foreach (ordhed o in quotes)
                            if (!o.TransmitPossible((ContextRz)context, Enums.TransmitType.Print, ignoredPropertiesList))
                                return;

                        ((ContextRz)context).TheLeaderRz.ShowTransmitOrders(x, lines, Rz5.Enums.TransmitType.Print);
                        break;
                    }
                case "email":
                    {
                        args.Handled = true;
                        foreach (ordhed o in quotes)
                            if (!o.TransmitPossible((ContextRz)context, Enums.TransmitType.Print, ignoredPropertiesList))
                                return;
                        ((ContextRz)context).TheLeaderRz.ShowTransmitOrders(x, lines, TransmitType.Email);
                        break;
                    }

                default:
                    base.ActInstance(context, args);
                    break;
            }
        }

        public virtual bool CheckVerify(ContextRz x, ordhed o, List<string> missingProps)
        {
            ////Using this in 2 cases below
            //Dictionary<nObject, List<string>> missingQuoteProps = new Dictionary<nObject, List<string>>();

            ordhed_quote quote = (ordhed_quote)o;
            bool alreadyVerified = quote.is_all_data_gathered;
            bool verified = true;
            if (x.TheSysRz.TheOrderLogic.isObjectMissingProperties(x, quote))
            {
                verified = false;
            }
            if (verified)
            {

                if (!alreadyVerified)
                    x.Update(quote);
                return true;
            }
            else
                return false;
        }

        public virtual List<string> GetRequiredQuoteLineProperties(bool target = false)
        {
            List<string> ret = new List<string>();

            //Common stuff
            ret.Add("fullpartnumber");
            if (target)
            {
                //Target stuff
                ret.Add("target_quantity");
                ret.Add("target_price");
                ret.Add("target_manufacturer");
                ret.Add("target_datecode");
                ret.Add("target_datecode");
                ret.Add("target_condition");
                ret.Add("target_delivery");
            }
            else
            {
                //Original Stuff
                ret.Add("quantityordered");
                ret.Add("fullpartnumber");
                ret.Add("internalpartnumber");
                ret.Add("manufacturer");
                ret.Add("rohs_info");
                ret.Add("condition");
                ret.Add("datecode");
                ret.Add("delivery");
                ret.Add("unitprice");
                ret.Add("unitcost");
            }

            return ret;
        }

        //public virtual bool CheckAllOrderData(ordhed_quote q)
        //{
        //    //Check all required fields for a Formal Quote

        //    return false;
        //}

        public virtual void ActDetail(Context context, ActArgs args)
        {
            List<orddet_quote> quotes = new List<orddet_quote>();
            ordhed_quote header = null;
            foreach (IItem i in args.TheItems.AllGet(context))
            {
                if (header == null)
                    header = (ordhed_quote)((orddet_quote)i).OrderObject((ContextRz)context);
                quotes.Add((orddet_quote)i);
            }

            switch (args.ActionName.Trim().ToLower())
            {
                //KT 4-5-2016 Refactored from RzSensible
                case "delete":
                    HandleQuoteDelete((ContextRz)context, quotes);
                    break;
                case "salesorder":
                    if (header != null)
                        HandleAddtoSO((ContextRz)context, args, header);
                    break;
                default:
                    base.ActInstance(context, args);
                    break;
            }
        }
        public virtual List<string> GetRelatedSalesIDs(Context context, string id)
        {
            List<string> ret = context.SelectScalarList("select DISTINCT unique_id from ordhed_sales where unique_id IN(select DISTINCT orderid_sales from orddet_line where orderid_quote = '" + id + "' AND LEN(isnull(orderid_sales, 0))> 0 )");
            return ret;
        }

        //KT 4-5-2016 - Refactored
        private void HandleQuoteDelete(ContextRz x, List<orddet_quote> quotes)
        {
            if (!x.TheLeader.AskYesNo("Are you sure you want to delete " + Tools.Strings.PluralizePhrase("quote", quotes.Count)))
                return;
            foreach (orddet_quote q in quotes)
            {
                ordhed_quote qte = (ordhed_quote)q.TheOrderVar.RefItemGet(x);
                if (qte != null)
                    qte.Details.RefsRemove(x, q);
                q.base_ordhed_uid = "";
                q.Update(x);
            }
        }



        //KT 4-5-2016 new
        private void HandleAddtoSO(ContextRz x, ActArgs args, ordhed_quote header)
        {
            orddet_quote q = (orddet_quote)args.TheItems.FirstGet(x);
            company comp = company.GetById(x, q.base_company_uid);
            List<orddet_quote> quotes = new List<orddet_quote>();
            foreach (IItem i in args.TheItems.AllGet(x))
            {
                quotes.Add((orddet_quote)i);
            }
            //KT 4-5-2016
            //Check for Existing Lines Sales Orders
            switch (GetRelatedSalesIDs(x, header.unique_id).Count)
            {
                case 0:
                    {
                        x.Leader.Tell("The line has been added to the Formal Quote, but there does not appear to be a Sales Order associated with it, therefore cannot add to Sales Order.");
                        break;
                    }
                default:
                    {
                        ordhed oh = x.Leader.ChooseFQSO(x, comp.unique_id, "SalesOrder");
                        if (oh == null)
                        {
                            return;
                        }
                        else
                        {
                            foreach (orddet_quote qq in quotes)
                            {
                                MakeSalesOrderLines(x, (ordhed_sales)oh, qq);
                            }
                        }
                        break;
                    }
            }
        }



        //public bool CompanyHasTermsAndConditions(ContextRz context, company_terms_conditions currentTerms)
        //{
        //    if (currentTerms.has_dc_restriction)
        //        return true;
        //    else if (currentTerms.has_packaging_restriction)
        //        return true;
        //    else if (currentTerms.has_rohs_restriction)
        //        return true;
        //    else if (currentTerms.has_broker_restriction)
        //        return true;
        //    else if (currentTerms.has_coo_restriction)
        //        return true;
        //    else if (currentTerms.has_testing_restriction)
        //        return true;
        //    else if (currentTerms.requires_traceability)
        //        return true;
        //    return false;
        //}

        //public void SendManagerEmailAlert(ContextRz x, ArrayList quoteLines)
        //{
        //    nObjectHolder noh = (nObjectHolder)quoteLines[0]; // Needed to convert array item to orddet_quote
        //    orddet_quote qq = (orddet_quote)noh.xObject;
        //    if (qq == null)
        //        return;
        //    if (string.IsNullOrEmpty(qq.base_dealheader_uid))
        //        return;
        //    dealheader d = dealheader.GetById(x, qq.base_dealheader_uid);
        //    string AgentName = x.xUser.Name;
        //    Tools.nEmailMessage m = new Tools.nEmailMessage();
        //    if (x.xUser.IsDeveloper())
        //        m.ToAddress = "ktill@sensiblemicro.com";
        //    else
        //        m.ToAddress = "rz_sales_alerts@sensiblemicro.com";
        //    m.FromAddress = "rz_new_req@sensiblemicro.com";

        //    if (quoteLines.Count > 1)
        //        m.Subject = AgentName + " has imported new Reqs. for " + d.customer_name + "  Batch ID: " + d.Name;
        //    else
        //        m.Subject = AgentName + " has a new req for " + d.customer_name + "   PN: " + qq.fullpartnumber + " QTY: " + qq.target_quantity;


        //    m.IsHTML = true;

        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("<b>Cusomter:</b> " + d.customer_name);
        //    sb.Append("<br />");
        //    sb.Append("<b>Batch#:</b> " + d.dealheader_name);
        //    sb.Append("<br />"); sb.Append("<b>Agent:</b> " + AgentName);
        //    sb.Append("<br />");
        //    sb.Append("<br />");
        //    sb.Append("<hr />");

        //    foreach (nObjectHolder hh in quoteLines)
        //    {
        //        orddet_quote q = (orddet_quote)hh.xObject;
        //        sb.Append("<b>Part:</b> " + q.fullpartnumber);
        //        sb.Append("<br />");
        //        sb.Append("<b>QTY:</b> " + q.target_quantity);
        //        sb.Append("<br />");
        //        sb.Append("<b>Target MFG:</b> " + q.target_manufacturer);
        //        sb.Append("<br />");
        //        sb.Append("<b>Target Price:</b> " + q.target_price);
        //        sb.Append("<br />");
        //        sb.Append("<b>Target Condition:</b> " + q.target_condition);
        //        sb.Append("<br />");
        //        sb.Append("<b>Target Delivery:</b> " + q.target_delivery);
        //        sb.Append("<br />");
        //        sb.Append("<b>Date:</b> " + q.date_created.ToString("MM/dd/yyyy"));
        //        sb.Append("<br />");
        //        sb.Append("<b>Cust Dock:</b> " + q.customer_dock_date_initial.ToString("MM/dd/yyyy"));
        //        sb.Append("<br />");
        //        sb.Append("<br />");
        //        sb.Append("<hr />");
        //        q.was_email_alert_sent = true;
        //        q.Update(x);

        //    }

        //    m.HTMLBody = sb.ToString();
        //    m.ServerName = "smtp.sensiblemicro.local";
        //    m.Send();



        //}

        public virtual ordhed_sales SalesOrderCreate(ContextRz context, List<ordhed_quote> quotes)
        {
            ordhed_quote quote_header = null;
            List<orddet_quote> details = new List<orddet_quote>();

            foreach (ordhed_quote h in quotes)
            {
                if (quote_header == null)
                    quote_header = h;
            }

            foreach (orddet_quote d in quote_header.DetailsList(context))
            {
                if (!details.Contains(d))
                    details.Add(d);
            }

            return SalesOrderCreate(context, quote_header, details);
        }


        public virtual ordhed_sales SalesOrderCreate(ContextRz context, ordhed_quote q)
        {
            //return SalesOrderCreate(context, q, q.DetailsListQuoteSelected(context));
            //KT 5-9-2017 - We don't need to check for selected lines, if they are on the quote, they are going
            //to the sale assuming all properties and logic checks passed.
            return SalesOrderCreate(context, q, q.DetailsListQuote(context));
        }

        public virtual ordhed_sales SalesOrderCreate(ContextRz context, ordhed_quote header, List<orddet_quote> quotes)
        {
            if (!context.xUser.CheckPermit(context, "Order:Create:Can Make Sales"))
            {
                context.TheLeader.ShowNoRight();
                return null;
            }
            ordhed_sales s = header.SalesOrderHeaderCreate(context);
            if (s == null)
                return null;

            //lines
            foreach (orddet_quote q in quotes)
            {
                MakeSalesOrderLines(context, s, q);
            }

            ////HubSpot
            //n_user u = n_user.GetById(context, header.base_mc_user_uid);
            //if (u.is_hubspot_enabled)
            //    if (header.hubspot_deal_id > 0)
            //        SetHubspotDealWon(context, header.hubspot_deal_id, s, quotes);


            //header.MakeLinkObject(context, h);
            context.TheSysRz.TheOrderLogic.Link2Orders(context, header, s);

            //Set the Quote to Closed
            header.isclosed = true;

            //header.IUpdate();
            context.TheDelta.Update(context, header);

            //refresh the so totals
            context.Update(s);

            //Udpate Customer Info
            company comp = company.GetById(context, s.base_company_uid);
            UpdateCustomerInfo(context, comp);
            //Validation Tracking
            validation_tracking vt = context.TheSysRz.TheOrderLogic.TrackValidation(context, s, Enums.SalesOrderValidationStage.PreValidation.ToString());

            return s;



        }

        private void UpdateCustomerInfo(ContextRz context, company comp)
        {
            string companytype = comp.companytype;
            if (companytype.ToLower().Contains("vendor"))
                return;
            if (comp.companytype != "C")
            {
                comp.companytype = "C";
                comp.Update(context);
            }

        }



        //private void SetHubspotDealWon(ContextRz x, long hubID, ordhed_sales o, List<orddet_quote> lines)
        //{
        //    Dictionary<string, string> props = new Dictionary<string, string>();
        //    props.Add("dealstage", HubspotApi.DealStage.sale_won);
        //    props.Add("closed_won_reason", "Sale Created in Rz");

        //    //Close date is NOT The date the sale get's lost, it's the day it's won
        //    long closeDate = HubspotApi.ConvertDateTimeToUnixTimestampMillis(DateTime.Now);
        //    props.Add("closedate", closeDate.ToString());

        //    HubspotApi.Deal deal = HubspotApi.Deals.UpdateDeal(hubID, props);
        //    if (deal.dealId == 0)
        //        throw new Exception("Hubspot Deal returned an invalid ID.   Likely the API put failed.");
        //    o.hubspot_deal_id = deal.dealId;
        //}




        public virtual bool CompanyAndContactRequired()
        {
            return false;
        }
        public virtual void MakeSalesOrderLines(ContextRz context, ordhed_sales h, orddet_quote q)
        {
            context.TheLeaderRz.CloseTabsByID(context, h.unique_id);
            if (q.DetailsGet(context).Count == 0)
            {
                MakeSalesOrderLine(context, h, q, company.GetById(context, q.vendorid), companycontact.GetById(context, q.vendorcontactid), null, Convert.ToInt32(q.quantityordered), q.unitcost, q.StockType, null);
                return;
            }
            partrecord p = null;
            List<orddet_rfq> bids = q.GetSplitBids(context);
            if (bids.Count > 1)
            {
                if (!context.TheLeader.AskYesNo("There are " + Tools.Strings.PluralizePhrase("bid", bids.Count) + " on the quote for " + q.fullpartnumber + ".  Do you want to make a new line for each bid?"))
                {
                    orddet_rfq bb = bids[0];


                    Enums.StockType tpe = DetermineSaleStockType(context, bb);


                    orddet_line l = MakeSalesOrderLine(context, h, q, bb.CompanyVar.RefGet(context), bb.ContactVar.RefGet(context), bb, Convert.ToInt32(q.quantityordered), bb.unitprice, tpe, p);

                    //context.Update(l);
                    return;
                }
            }

            foreach (orddet_rfq bid in bids)
            {
                Enums.StockType tpe = DetermineSaleStockType(context, bid);
                orddet_line l = MakeSalesOrderLine(context, h, q, bid.CompanyVar.RefGet(context), bid.ContactVar.RefGet(context), bid, Convert.ToInt32(q.quantityordered), bid.unitprice, tpe, p);
                if (l == null)
                    return;


                ////KT Fire Overbuy Alert after orddeT_line created.
                ////KT OverBuy Alert - Sales Order         
                //if (bid.stockid != null)
                //{
                //    partrecord stockpart = (partrecord)context.QtO("partrecord", "select * from partrecord where unique_id = '" + bid.stockid + "'");
                //    if (stockpart != null)
                //        context.TheSysRz.ThePartLogic.OverbuyAlert(context, stockpart, l, true);
                //}
                //context.Update(l);
            }
            context.Show(h);
        }

        private StockType DetermineSaleStockType(ContextRz context, orddet_rfq bb)
        {
            partrecord p = null;
            StockType ret = Enums.StockType.Any;
            //Service Lines
            if (bb.StockType == StockType.Service)
                return bb.StockType;
            if (bb.StockType == Enums.StockType.Excess || bb.StockType == Enums.StockType.Buy)
                ret = Enums.StockType.Buy;
            else if (bb.StockType == Enums.StockType.Stock || bb.StockType == Enums.StockType.Consign)
            {
                if (bb.isinstock)
                    p = partrecord.GetById(context, bb.stockid);
                if (p != null)
                    ret = p.StockType;
            }
            return ret;
        }

        protected virtual orddet_line MakeSalesOrderLine(ContextRz x, ordhed_sales salesOrder, orddet_quote q, company bidVendor, companycontact bidVendorContact, orddet_rfq vendor_bid, int qty, Double cost, Enums.StockType type, partrecord linked_stock)
        {
            try
            {


                orddet_line l = salesOrder.DetailsVar.RefAddNew(x);
                l.source = q.source;
                l.importid = q.importid;
                l.StockType = type;
                l.quantity = qty;
                if (bidVendor != null)
                {
                    l.VendorVar.RefSet(x, bidVendor);
                    if (bidVendorContact != null)
                        l.VendorContactVar.RefSet(x, bidVendorContact);

                }
                l.unit_price = q.unitprice;
                l.unit_cost = q.unitcost;
                l.fullpartnumber = q.fullpartnumber;
                l.manufacturer = q.manufacturer;
                l.alternatepart = q.alternatepart;
                l.internal_customer = q.internalpartnumber;
                l.datecode = q.datecode;
                l.description = q.description;
                l.condition = q.condition;
                l.orderid_quote = q.base_ordhed_uid;
                l.ordernumber_quote = q.ordernumber;
                l.quote_line_uid = q.unique_id;
                l.rohs_info = q.rohs_info;
                l.country_of_origin_vendor = q.country_of_origin_vendor;


                //Dock Dates
                x.TheSysRz.TheLineLogic.SetInitialLineDockDates(l, q.dockdate);


                l.lotnumber = q.lotnumber;
                l.consignment_code = q.consignment_code;
                //KT Consider Carrying quoted part number into new 'quotedpartnumber' field on orddet_line
                l.quoted_partnumber = q.fullpartnumber;
                //Carry Shgipvia from Quote
                if (q.OrderObject(x) != null)
                    l.shipvia_invoice = q.OrderObject(x).shipvia;

                l.packaging = q.packaging;

                //Seller Name
                l.seller_uid = salesOrder.base_mc_user_uid;
                l.seller_name = salesOrder.agentname;

                //Initially set the buyer name as the seller                
                if (!Tools.Strings.StrExt(l.buyer_uid))
                    l.buyer_uid = salesOrder.base_mc_user_uid;
                if (!Tools.Strings.StrExt(l.buyer_name))
                    l.buyer_name = salesOrder.agentname;
                l.buyer_name = salesOrder.buyername;
                l.buyer_uid = salesOrder.orderbuyerid;


                //List Acquisition Agent
                l.list_acquisition_agent = q.list_acquisition_agent;
                l.list_acquisition_agent_uid = q.list_acquisition_agent_uid;

                //Affiliate ID
                l.affiliate_id = q.affiliate_id;

                //Split Commission
                l.split_commission_ID = q.split_commission_ID;

                //Internal Vendor Part/Service numbers, GCAT etc.
                l.internalpart_vendor = q.internalpart_vendor;
                l.internalpart_vendor_uid = q.internalpart_vendor_uid;



                l.CostCalc(x);
                if (vendor_bid != null)
                {
                    //Carry forward bid specific properties
                    l.bid_partnumber = vendor_bid.fullpartnumber;
                    l.datecode_purchase = vendor_bid.datecode;
                    l.rohs_info_vendor = vendor_bid.rohs_info;

                }

                //Maintain linkage between original stock id and Inventory link uid
                l.inventory_link_uid = q.stockid;
                linked_stock = (partrecord)x.QtO("partrecord", "select * from partrecord where unique_id = '" + l.inventory_link_uid + "'");
                if (linked_stock != null)
                {
                    l.receive_location = linked_stock.location;
                }

                //Allocation
                if (l.StockType == Enums.StockType.Stock || l.StockType == Enums.StockType.Consign || l.StockType == Enums.StockType.Excess)
                {
                    if (!l.LinkAndAllocate(x, linked_stock, false))
                        return null;
                }

                if (l.StockType == Enums.StockType.Buy)
                    l.needs_purchasing = true;
                if (l.StockType == StockType.Stock || l.StockType == StockType.Consign)
                {//Set stocktype to in-house automatically for stock and consign.
                    if (!l.fullpartnumber.ToLower().Trim().Contains("gcat"))
                        l.qc_status = SM_Enums.QcStatus.In_House.ToString();
                }

                l.Update(x);
                return l;
            }
            catch (Exception ex)
            {
                x.Leader.Tell(ex.Message);
            }
            return null;
        }

        public virtual String QuoteBcc(ordhed xOrder)
        {
            //KT 4-5-2016 - Refactored from Rz5
            if (xOrder == null)
                return "";
            if (xOrder.OrderType == Rz5.Enums.OrderType.Quote || xOrder.OrderType == Rz5.Enums.OrderType.Invoice)
                return "outgoing.quotes@sensiblemicro.com";
            else
                return "";
        }

        public virtual orddet_rfq AddStockBid(ContextRz x, orddet_quote q, partrecord p)
        {
            orddet_rfq b = orddet_rfq.New(x);
            b.the_orddet_quote_uid = q.unique_id;

            //IF this is the GCAT ID, set fullpartnumber to be the quoted req part, and the description as stock_line text
            //GCAT Stock ID = "ce60a6330c7a4ceea76e2086060d13b4"
            //if (p.unique_id == "ce60a6330c7a4ceea76e2086060d13b4" || p.fullpartnumber.Trim().ToLower().Contains("gcat"))
            //{
            //    b.fullpartnumber = q.fullpartnumber;
            //    b.description = p.fullpartnumber;
            //    b.quantity = 1;
            //    b.unitprice = p.price;
            //    b.stocktype = StockType.Service.ToString();
            //    b.StockType = StockType.Service;
            //    b.manufacturer = p.manufacturer;

            //}
            //else
            //{
            //    b.fullpartnumber = p.fullpartnumber;
            //    b.StockType = p.StockType;
            //}

            b.fullpartnumber = p.fullpartnumber;
            b.StockType = p.StockType;

            if (!string.IsNullOrEmpty(p.consignment_code))
            {
                b.consignment_code = p.consignment_code;
            }
            //This is the company that we bough the stock from (if any)   
            b.companyname = p.companyname;
            b.base_company_uid = p.base_company_uid;
            //We are the vendor
            b.vendorname = "Sensible Micro Corporation";
            b.vendor_company_uid = "037ED306-8D90-42D6-AAAA-AD91B900F263";
            b.vendorid = "037ED306-8D90-42D6-AAAA-AD91B900F263";

            //List Acquisition Agent
            b.list_acquisition_agent = p.list_acquisition_agent;
            b.list_acquisition_agent_uid = p.list_acquisition_agent_uid;


            b.manufacturer = p.manufacturer;
            b.importid = p.importid;


            b.datecode = p.datecode;
            b.quantitycancelled = Convert.ToInt32(p.quantity);
            b.quantityordered = q.target_quantity;
            b.quantitystocked = p.quantity = p.quantityallocated;
            b.target_quantity = Convert.ToInt32(q.target_quantity);
            b.condition = p.condition;
            b.packaging = p.packaging;
            b.lotnumber = p.lotnumber;
            b.location = p.location;
            b.rohs_info = p.rohs_info;
            b.boxnum = p.boxnum;
            b.isinstock = true;
            b.unitprice = p.cost;
            b.base_dealheader_uid = q.base_dealheader_uid;
            //Stock Intenventory link uid
            b.stockid = p.unique_id;





            b.isselected = true;
            x.Insert(b);
            q.BidAbsorb(x, b);

            return b;
        }

        public virtual ListArgs QuoteSearchArgsGet(ContextRz x, Enums.PartSearchType SearchType, SearchComparison compare, PartSearchParameters par, bool includeReqs)
        {
            ListArgs ret = null;
            switch (SearchType)
            {
                case Enums.PartSearchType.Quotes_Giving:
                    ret = OrdDetSearchArgsGet(x, compare, "'quote'", par);
                    break;
                case Enums.PartSearchType.Quotes_Receiving:
                case Enums.PartSearchType.Bids:
                    ret = OrdDetSearchArgsGet(x, compare, "'rfq'", par);
                    break;
                default:
                    ret = OrdDetSearchArgsGet(x, compare, "", par);  //'quote', 'rfq'
                    break;
            }

            if (!includeReqs)
                ret.TheWhere += " and quantityordered > 0 and unitprice > 0 ";

            ret.TheTemplate = x.TheLogicRz.TemplateSecure(x, "orddet", "simple_quotes");

            return ret;
        }

        public virtual ListArgs QuoteSearchArgsGetCompany(ContextRz x, String companyId, String contactId)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "orddet";
            ret.TheClass = "orddet";
            ret.TheWhere = "base_company_uid = '" + companyId + "'";
            if (Tools.Strings.StrExt(contactId))
                ret.TheWhere += " and base_companycontact_uid = '" + contactId + "'";

            ret.TheOrder = "orderdate desc";
            ret.TheTemplate = x.TheLogicRz.TemplateSecure(x, "orddet", "simple_quotes");
            return ret;
        }

        public virtual ListArgs OrdDetSearchArgsGet(ContextRz x, SearchComparison compare, String strType, PartSearchParameters par)
        {
            ListArgs ret = new ListArgs(x);
            if (strType == "" || Tools.Strings.HasString(strType, ","))
                ret.TheTable = "orddet";
            else
                ret.TheTable = ordhed.MakeOrddetName(strType.Replace("'", ""));
            if (par.SearchTerm == "")
                ret.HeaderOnly = true;
            ret.AddAllow = false;
            ret.TheClass = ret.TheTable;
            ret.TheOrder = ret.TheTable + ".orderdate desc";
            StringBuilder sb = new StringBuilder();
            sb.Append(" ( ");
            if (Tools.Strings.StrExt(strType))
                sb.AppendLine(" " + ret.TheTable + ".ordertype in ( " + strType + " ) ");
            ArrayList a = PartObject.GetSearchPermutations(x, par.SearchTerm, compare, true, false, false, false, true, "", true);
            if (a.Count > 0)
            {
                if (Tools.Strings.StrExt(strType))
                    sb.AppendLine(" and ");
                sb.AppendLine(" ( ");
                sb.Append(PartObject.BuildWhere(a));

                AddManufacturerCriteriaToQuoteSearch(x, par, sb);

                sb.AppendLine(" ) ");
            }
            sb.Append(" ) ");
            switch (strType.ToLower().Trim())
            {
                case "'rfq', 'quote'":
                case "'quote', 'rfq'":
                    ret.TheCaption = "Customer Quotes and Vendor Bids";
                    break;
                case "'sales', 'invoice'":
                case "'invoice', 'sales'":
                    ret.TheCaption = "Sales Orders and Invoices";
                    break;
                case "'purchase'":
                    ret.TheCaption = "Purchase Orders";
                    break;
                case "'rma', 'vendrma'":
                case "'vendrma', 'rma'":
                    ret.TheCaption = "Customer and Vendor RMAs";
                    break;
            }
            if (Tools.Strings.StrExt(par.CompanyName))
                sb.Append(" and companyname = '" + x.Filter(par.CompanyName) + "'");
            if (Tools.Strings.StrExt(par.AgentID))
                sb.Append(" and base_mc_user_uid = '" + x.Filter(par.AgentID) + "'");
            //if (sb.ToString() != "")
            //    sb.Append(" or ");
            //sb.Append(" manufacturer like '%" + x.Filter(par.SearchTerm) + "%' ");
            ret.TheWhere = sb.ToString();
            return ret;
        }

        public virtual void AddManufacturerCriteriaToQuoteSearch(Context x, PartSearchParameters par, StringBuilder sb)
        {
            if (sb.ToString() != "")
                sb.Append(" or ");
            sb.Append(" manufacturer like '%" + x.Filter(par.SearchTerm) + "%' ");
        }

        public virtual usernote CreateFollowUpReminder(ContextRz x, ordhed q)
        {
            //KT 4-5-2016 Refactor -  Sensible had this commented out, let's ask sales team if / how they would like it.  
            //Setting SU only so I can test.


            usernote xNote = usernote.New(x);
            xNote.base_company_uid = q.base_company_uid;
            xNote.for_mc_user_uid = x.xUser.unique_id;
            xNote.by_mc_user_uid = x.xUser.unique_id;
            xNote.notetext = "Follow Up Reminder";
            xNote.shouldpopup = true;
            x.Insert(xNote);
            xNote.displaydate = DateTime.Now.Add(new TimeSpan(4, 0, 0));
            x.Update(xNote);
            xNote.CreateObjectLink(x, q, q.ToString());
            return xNote;
        }

        public virtual void CheckPriorityFlag(ContextNM x, orddet_quote q)
        {

        }

        public DataTable GetQuoteStats(ContextRz x, string id)
        {
            return GetQuoteStats(x, id, false);
        }

        public virtual List<string> GetRequiredQuoteHeaderProperties()
        {
            List<string> ret = new List<string>();
            ret.Add("companyname");
            ret.Add("billingaddress");
            ret.Add("shippingaddress");
            ret.Add("agentname");
            //ret.Add("terms");
            ret.Add("shipvia");
            ret.Add("contactname");
            ret.Add("opportunity_type");
            ret.Add("orderreference");
            return ret;
        }



        public virtual DataTable GetQuoteStats(ContextRz x, string id, bool from_deal)
        {
            return null;  //need to set this back up
                          //string SQL = "select distinct(orddet_quote.prefix + orddet_quote.basenumberstripped) as partnumber, ";
                          ////stock_matches
                          //SQL += "(select count(*) from partrecord where partrecord.prefix + partrecord.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped and partrecord.stocktype = 'stock') as stock_matches, ";
                          ////excess_matches
                          //SQL += "(select count(*) from partrecord where partrecord.prefix + partrecord.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped and partrecord.stocktype = 'excess') as excess_matches,";
                          ////consign_matches
                          //SQL += "(select count(*) from partrecord where partrecord.prefix + partrecord.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped and partrecord.stocktype = 'consign') as consign_matches,";
                          ////sale_matches
                          //SQL += "(select count(*) from orddet_line where ordernumber_invoice > '' and was_shipped = 1 and orddet_line.prefix + orddet_line.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as sale_matches,";
                          ////sale_average
                          //SQL += "(select ((select sum(unitprice) from orddet_line where ordernumber_invoice > '' and was_shipped = 1 and orddet_line.prefix + orddet_line.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped)/(select count(*) from orddet_line where ordernumber_invoice > '' and was_shipped = 1 and orddet_line.prefix + orddet_line.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped)) from orddet_line where orddet_line.prefix + orddet_line.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as sale_average,";
                          ////sale_min
                          //SQL += "(select min(unitprice) from orddet_sales where unitprice > 0 and orddet_sales.prefix + orddet_sales.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as sale_min,";
                          ////sale_max
                          //SQL += "(select max(unitprice) from orddet_sales where orddet_sales.prefix + orddet_sales.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as sale_max,";
                          ////sale_earliest
                          //SQL += "(select min(orderdate) from orddet_sales where orderdate > cast('1/1/1900' as datetime) and orddet_sales.prefix + orddet_sales.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as sale_earliest,";
                          ////sale_latest
                          //SQL += "(select max(orderdate) from orddet_sales where orddet_sales.prefix + orddet_sales.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as sale_latest,";
                          ////purchase_matches
                          //SQL += "(select count(*) from orddet_purchase where orddet_purchase.prefix + orddet_purchase.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as purchase_matches,";
                          ////purchase_average
                          //SQL += "(select ((select sum(unitprice) from orddet_purchase where orddet_purchase.prefix + orddet_purchase.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped)/(select count(*) from orddet_purchase where orddet_purchase.prefix + orddet_purchase.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped)) from orddet_purchase where orddet_purchase.prefix + orddet_purchase.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as purchase_average,";
                          ////purchase_min
                          //SQL += "(select min(unitprice) from orddet_purchase where unitprice > 0 and orddet_purchase.prefix + orddet_purchase.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as purchase_min,";
                          ////purchase_max
                          //SQL += "(select max(unitprice) from orddet_purchase where orddet_purchase.prefix + orddet_purchase.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as purchase_max,";
                          ////purchase_earliest
                          //SQL += "(select min(orderdate) from orddet_purchase where orderdate > cast('1/1/1900' as datetime) and orddet_purchase.prefix + orddet_purchase.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as purchase_earliest,";
                          ////purchase_latest
                          //SQL += "(select max(orderdate) from orddet_purchase where orddet_purchase.prefix + orddet_purchase.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as purchase_latest,";
                          ////quote_matches
                          //SQL += "(select count(*) from orddet_quote where orddet_quote.prefix + orddet_quote.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as quote_matches,";
                          ////quote_total_price
                          //SQL += "(select sum(unitprice) from orddet_quote where orddet_quote.prefix + orddet_quote.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped)  as quote_total_price,";
                          ////quote_min
                          //SQL += "(select min(unitprice) from orddet_quote where unitprice > 0 and orddet_quote.prefix + orddet_quote.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as quote_min,";
                          ////quote_max
                          //SQL += "(select max(unitprice) from orddet_quote where orddet_quote.prefix + orddet_quote.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as quote_max,";
                          ////quote_earliest
                          //SQL += "(select min(orderdate) from orddet_quote where orderdate > cast('1/1/1900' as datetime) and orddet_quote.prefix + orddet_quote.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as quote_earliest,";
                          ////quote_latest
                          //SQL += "(select max(orderdate) from orddet_quote where orddet_quote.prefix + orddet_quote.basenumberstripped = orddet_quote.prefix + orddet_quote.basenumberstripped) as quote_latest ";
                          //string prop = "unique_id";
                          //if (from_deal)
                          //    prop = "base_dealheader_uid";
                          //SQL += "from orddet_quote where orddet_quote." + prop + " = '" + id + "'";
                          //return x.xSys.xData.GetDataTable(SQL, false, true);
        }

        internal List<string> GetRequiredQuoteDetailLogics(ContextRz x, orddet_quote q)
        {
            List<string> ret = new List<string>();
            if (InsufficientStockQuantity(x, q))
                ret.Add("Insufficient stock quantity.");
            return ret;
        }

        private bool InsufficientStockQuantity(ContextRz x, orddet_quote q)
        {
            //Check all bids for this quote line.
            //If purely stock bids (i.e. return fase if any buy lines found)
            //confirm available total qty of parts to fullfill quote line amount.


            long availableQty = 0;

            foreach (orddet_rfq bid in q.GetSplitBids(x))
            {
                //Don't bother checking availability of buy bids.  Any buy could potentially fill any missing qty
                if (string.IsNullOrEmpty(bid.stockid))
                    continue;

                partrecord p = partrecord.GetById(x, bid.stockid);
                if (p == null)
                {
                    x.Error("Stock line not found in database.");
                    return false;
                }

                long stock_bid_qty = (p.quantity - p.quantityallocated);
                availableQty += stock_bid_qty;

                if (q.quantityordered > availableQty)
                {

                    //ordhed_quote theQuote = ordhed_quote.GetById(x, q.base_ordhed_uid);
                    //ordhed theSale = theQuote.GetRelatedSale(x);

                    //if (string.IsNullOrEmpty(p.allocated_notes))//No allocated notes, yet allocated quantity
                    //{
                    //    x.Leader.Error("The stock for this line shows as over allocation, yet no allocation data available.  Please confirm stock before proceeding.");
                    //    return true;
                    //}
                    //else
                    //{
                    //string quote_line_uid = q.unique_id;
                    string stockId = q.stockid;
                    if (p.unique_id == q.stockid)//It's allocated for THIS Order, therefor no issue
                        return false;
                    //Confirm whether the order being opened is the same order that has the allocation.  If different order, throw error.



                    throw new Exception("The stock for this has no un-allocated qty to sell.  Please confirm stock before proceeding.");
                    //return true;
                    //}

                    ////get sales order ID from allocated notes for match
                    //string allocatedSalesLineID = p.allocated_notes.Split(':')[3].Replace("]", "").Trim();
                    //if (string.IsNullOrEmpty(allocatedSalesLineID))
                    //{
                    //    x.Leader.Error("The stock for this line shows as over allocation, yet could not determine the order on which it was allocated.  Please confirm stock before proceeding.");
                    //    return true;

                    //}


                    //orddet_line l = (orddet_line)x.QtO("orddet_line", "select * from orddet_line where unique_id = '" + allocatedSalesLineID + "'");
                    //if (l == null)
                    //{
                    //    x.Leader.Error("The stock for this line shows as over allocation, yet no sale was associated with id '" + allocatedSalesLineID + "'.  Please confirm stock before proceeding.");
                    //    return true;
                    //}
                    //if (l.quote_line_uid == q.unique_id)
                    //    return false;
                    //return true;//Allocated on a different line??
                }
            }
            return false;
        }

        internal List<string> GetRequiredQuoteHeaderLogics(ContextRz x, nObject o)
        {

            List<string> ret = new List<string>();
            ordhed_quote q = (ordhed_quote)o;
            if (q == null)
                return ret;

            //IF Terms are Net, and no customer Financials
            company c = q.CompanyVar.RefGet(x);
            if (!x.TheSysRz.TheCompanyLogic.IsCompanyFinancialsVerified(c, q.terms))
            {
                //sb.Append("Company Financials Not Verified!");
                //missingProps.Add("Company Financials Not Verified!");
                ret.Add(q.terms + ": Financials not verified");
            }
            if (q.terms == "TBD")
                ret.Add("tbd_terms");
            //IF set to credit terms, check available
            if (q.terms.ToLower().Contains("net") || q.terms.ToLower() == "tbd")
            {
                double outstandInvoiceAmount = x.TheSysRz.TheCompanyLogic.CalculateOutstandingBalance_Company(x, c);
                {
                    double remainingCredit = c.creditascustomer - outstandInvoiceAmount;
                    if (q.ordertotal > remainingCredit)
                        ret.Add("Insufficient credit:  ($" + Tools.Number.MoneyFormat_2_6(remainingCredit) + ")");
                    //ret.Add("Credit Alert: ($" + Tools.Number.MoneyFormat_2_6(q.ordertotal) + ") > ($" + Tools.Number.MoneyFormat_2_6(remainingCredit) + ")");
                }
            }

            return ret;
        }

        internal void SetListAttribution(ContextRz context, orddet_rfq r, orddet_quote q)
        {
            q.list_acquisition_agent = r.list_acquisition_agent;
            q.list_acquisition_agent_uid = r.list_acquisition_agent_uid;
        }

        public bool CheckAgedInvoices(ContextRz x, company c, object RzObject, bool sendEmailAlert = false)
        {
            dealheader batch = null;
            ordhed_quote quote = null;
            if (RzObject is dealheader)
                batch = (dealheader)RzObject;
            else if (RzObject is ordhed_quote)
                quote = (ordhed_quote)RzObject;
            else
                return false;

            string ordernumber = "";
            string companyName = "";
            string agentName = "";
            string agentEmail = "";
            string orderType = "";
            n_user u = null;
            if (batch != null)
            {
                ordernumber = batch.dealheader_name;
                companyName = batch.customer_name;
                u = n_user.GetById(x, batch.base_mc_user_uid);
                orderType = batch.GetType().ToString();


            }
            else if (quote != null)
            {
                ordernumber = quote.ordernumber;
                companyName = quote.companyname;
                u = n_user.GetById(x, quote.base_mc_user_uid);
                orderType = quote.GetType().ToString();
            }

            if (u != null)
            {
                agentName = u.name;
                agentEmail = u.email_address;
            }

            double agedInvoiceAmount = x.TheSysRz.TheInvoiceLogic.GetAgedInvoiceAmountForCompany(x, c);
            if (agedInvoiceAmount > 0)
            {
                List<string> ccList = new List<string>() { "joemar@sensiblemicro.com" };
                if (!string.IsNullOrEmpty(agentEmail))
                    ccList.Add(agentEmail);
                x.Leader.Tell(c.companyname + " has $" + agedInvoiceAmount.ToString("#.####") + " in aged invoices.  You may quote them, but you will not be able to complete a Sales Order order until this is resolved.");

                if (sendEmailAlert == true)
                {
                    string body = "<b>Please resolve the following aged balance before proceeding with a new Sales Order:</b><br />";
                    body += "Company:  <b>" + c.companyname + "</b><br />";
                    body += "OrderType: <b>" + orderType + "</b><br />";
                    body += "OrderNumber: <b>" + ordernumber + "</b><br />";
                    body += "Agent: <b>" + agentName + "</b><br />";
                    body += "Sales agent, sales manager, and Accounts Payable have been notified by email for quickest resolition.";
                    SystemLogic.Email.SendMail("rz_alerts@sensiblemicro.com", "ap@sensiblemicro.com", c.companyname + ": Aged Balance Alert", body, ccList.ToArray());
                }
                return true;
            }
            return false; //No Aged Invoices
        }

        internal void CheckARAlerts(ContextRz x, company c, ordhed_quote q)
        {
            //Check if the company needs AR verification
            bool alertAR = false;
            //No checks needed for certain terms, neither last invoice date nor current credit standing apply to these terms per JC 11/29/2021
            if (skipARAlert(x, c))
                return;
            //Check if the company needs AR Contact Verification
            if (CompanyNeedsARContactVerification(x, c))
                alertAR = true;
            //CHeck if this quote amount Exceeds the remaining credit limit
            else if (AmountExceedsAvailableCredit(x, c, q.ordertotal))
                alertAR = true;
            //if alertAR is true, doe the alerting
            if (alertAR)
            { 
                //IF the quoting agent is Phil Scott, don't send AR Alert, jsut the popup
                if (q.agentname == "Phil Scott")
                    SendAPQuoteAlert(x, c, q.ordernumber, true, false);
                else
                    SendAPQuoteAlert(x, c, q.ordernumber);
            }
        }

        private bool skipARAlert(ContextRz x, company c)
        {
            //Send alert if the Terms as customer dictate

            //For Vendor Accounts, i.e. phil, they are 99% always cash terms.  Therefor if vendor, and TBD Terms, skip alert.
            if (c.termsascustomer.ToLower() == "tbd" && c.companytype.ToLower().Contains("vendor"))
                return true;

            List<string> noAlertTerms = new List<string>() { "cod", "ach", "tt", "advance", "wire", "credit", "card", "visa", "credit card", "amex", "mastercard", "paypal" };
            string currentCompanyTerms = c.termsascustomer.Trim().ToLower();
            foreach (string word in currentCompanyTerms.Split(' '))
            {
                //While the list doesn't contain any words
                if (noAlertTerms.Contains(word))
                    return true;
            }
            return false;
        }

        private bool AmountExceedsAvailableCredit(ContextRz x, company c, double amount)
        {

            double currentOutstandingAmount = x.TheSysRz.TheCompanyLogic.CalculateOutstandingBalance_Company(x, c);
            double currentCompanyCreditLimit = c.creditascustomer;
            //double totalAmount = this.ordertotal;
            double computedBalance = currentOutstandingAmount + amount;
            if (computedBalance >= currentCompanyCreditLimit)
                return true;
            return false;
        }

        private bool CompanyNeedsARContactVerification(ContextRz x, company c)
        {
            //Check if this customer has been Invoice in less than a year, if not, alert
            ordhed_invoice i = (ordhed_invoice)x.QtO("ordhed_invoice", "select top 1 * from ordhed_invoice where base_company_uid = '" + c.unique_id + "' order by date_created desc");
            if (i == null)//If no invoice, need AR Contact verify
                return true;
            DateTime lastInvoiceDate = i.date_created;
            TimeSpan ts = DateTime.Today - lastInvoiceDate;
            if (ts.TotalDays >= 365)
                return true;
            return false;
        }


        private void SendAPQuoteAlert(ContextRz x, company c, string orderNumber, bool doPopup = true, bool doEmail = true)
        {
            string body = x.xUserRz.name + " has created a quote for " + c.companyname + " who has not been invoiced in over a year OR has been quoted for an order that exceeds their credit limit.  Please confirm accurate AR contact information, and consider increasing the credit limit as needed.";
            if (doEmail)
            {
                string agentEmail = "";
                var agentEmails = new List<string>();
                // do stuff...
              


                n_user u = n_user.GetById(x, c.base_mc_user_uid);
                if (u != null)
                    if (!string.IsNullOrEmpty(u.email_address))
                        if (Tools.Email.IsEmailAddress(u.email_address))
                            agentEmail = u.email_address.Trim().ToLower();

                if (!string.IsNullOrEmpty(agentEmail))
                    agentEmails.Add(agentEmail);

                SensibleDAL.SystemLogic.Email.SendMail("AR_Alert@sensiblemicro.com", "ap@sensiblemicro.com", c.companyname + " requires AR Verification for Formal Quote # " + orderNumber, body, agentEmails.ToArray());
            }

            if (doPopup)
                x.Leader.Tell(body);

        }

        //internal void CheckQuoteVendorVetted(ContextRz x, ordhed_quote q)
        //{
        //    List<orddet_quote> quoteLines = q.DetailsList(x).Cast<orddet_quote>().ToList();
        //    List<company> unVettedVendors = new List<company>();

        //    foreach (orddet_quote ql in quoteLines)
        //    {
        //        List<orddet_rfq> acceptedBids = ql.GetAcceptedBids(x);
        //        foreach (orddet_rfq r in acceptedBids)
        //        {
        //            company bidVendor = company.GetById(x, r.base_company_uid);
        //            if (bidVendor != null)
        //                if (!(bidVendor.is_vetted))
        //                    if (!unVettedVendors.Contains(bidVendor))
        //                        unVettedVendors.Add(bidVendor);
        //        }

        //    }
        //    if (unVettedVendors.Count <= 0)
        //        return;
        //    company customer = company.GetById(x, q.base_company_uid);
        //    if (customer == null)
        //        throw new Exception("Error identifying the customer for formal quote " + q.ordernumber);
        //    x.TheSysRz.TheCompanyLogic.SendCompanyNeedsVettingEmailAlert(x, customer, q, unVettedVendors);



        //}
        //public void SetSplitCommission(ContextRz x, string agent_uid, object o, string split_agent_uid, string split_type)
        //{
        //    //Batches and Orders can be created by different users, the agent name will be manually set, that is where we will fire this.
        //    n_user agent = n_user.GetById(x, agent_uid);
        //    n_user splitAgent = n_user.GetById(x, split_agent_uid);
        //    if (splitAgent == null)
        //        throw new Exception("Could not locate a split agent with id: " + split_agent_uid);


        //    if (o is dealheader || o is ordhed_quote)
        //        SetDealheaderSplitCommission(x, agent, (dealheader)o, splitAgent, split_type);



        //}
        //private void SetDealheaderSplitCommission(ContextRz x, n_user agent, dealheader d, n_user splitAgent, string split_type)
        //{
        //    if (agent == null)
        //        return;  //If we don't know the agent, we can't check if that agent is alsot he split agent.


        //    if (agent.unique_id != splitAgent.unique_id)//If the batch agent is not already the split agent, set the split agent
        //    {
        //        d.split_commission_agent_uid = splitAgent.unique_id;
        //        d.split_commission_agent_name = splitAgent.name;
        //        d.split_commission_type = split_type;

        //    }
        //    else
        //    {
        //        d.split_commission_agent_uid = "";
        //        d.split_commission_agent_name = "";
        //        d.split_commission_type = "";
        //    }
        //    d.Update(x);
        //    if (!string.IsNullOrEmpty(d.split_commission_ID))
        //        SetOrddetQuoteSplitCommission(x,d);


        //}

        //private void SetOrddetQuoteSplitCommission(ContextRz x, dealheader d)
        //{
        //    ArrayList listQuotes = d.GetAllOrddetQuotes(x);
        //    split_commission sc = (split_commission)x.QtO("split_commission", "select * from split_commission where dealheader_uid = '"+d.split_commission_ID+"' ");
        //    if (sc == null)
        //        return;
        //    //Update the Quote Lines as well.
        //    foreach (orddet_quote q in listQuotes)
        //    {
        //        q.split_commission_ID = sc.unique_id;
        //        q.Update(x);
        //    }
        //}
        //private void SetOrddetQuoteSplitCommission(ContextRz x, ArrayList listQuotes, n_user splitAgent, string split_type)
        //{
        //    //Update the Quote Lines as well.
        //    foreach (orddet_quote q in listQuotes)
        //    {
        //        if (q.split_commission_agent_uid != splitAgent.unique_id)
        //        {
        //            q.split_commission_agent_uid = splitAgent.unique_id;
        //            q.split_commission_agent_name = splitAgent.name;
        //            q.split_commission_type = split_type;
        //        }
        //        else
        //        {
        //            q.split_commission_agent_uid = "";
        //            q.split_commission_agent_name = "";
        //            q.split_commission_type = "";
        //        }

        //        q.Update(x);
        //    }
        //}
    }
}
