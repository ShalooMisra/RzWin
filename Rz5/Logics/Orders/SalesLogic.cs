using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewMethod;


namespace Rz5
{
    public class SalesLogic : NewMethod.Logic
    {
        public virtual bool CheckVerify(ContextRz context, ordhed o, List<string> missingProps)
        {
            bool verified = true;
            bool alreadyVerified;
            //if (sale.isverified)
            //    return true;  

            switch (o.OrderType)
            {
                case Rz5.Enums.OrderType.Sales:
                    {
                        ordhed_sales sale = (ordhed_sales)o;
                        alreadyVerified = sale.isverified;


                        if (sale.Details.RefsCount(context) <= 0)
                        {
                            //sb.AppendLine("Missing Information: No Line Items");
                            //missingProps.Add("Missing Information: No Line Items");
                            missingProps.Add("no_line_items");
                            verified = false;
                        }

                        //KT - Per Krystina, this happens at the VERY end, so not something that should prevent cutting PO's
                        //if (sale.validation_stage != Enums.SalesOrderValidationStage.ValidationComplete.ToString())
                        //{
                        //    //sb.AppendLine("Header: Validation Not Completed");
                        //    missingProps.Add("validation_not_complete");
                        //    verified = false;
                        //}

                        //KT Check SO Terms, if TBD - Hard Stop, require manager override.
                        if (sale.terms == "TBD" && !sale.is_TermsOverride)
                        {
                            //sb.AppendLine("Sorry, the terms on this order are set to \"TBD\".  PO Creation is not possible.  Please put in accurate terms, or see manager for an override.");
                            //sb.AppendLine("Header: TBD Vendor: Requires manager ovveride to create PO");
                            //missingProps.Add("Header: TBD Vendor: Requires manager ovveride to create PO");
                            missingProps.Add("tbd_terms");
                            return false;
                        }
                        //KT Refactored from RzSensible.SalesLogic
                        if (!context.TheSysRz.TheCompanyLogic.IsCompanyFinancialsVerified(sale.CompanyVar.RefGet(context), sale))
                        {
                            //sb.Append("Company Financials Not Verified!");
                            //missingProps.Add("Company Financials Not Verified!");
                            missingProps.Add("financials_not_verified");
                            return false;
                        }




                        if (verified)
                        {
                            sale.isverified = true;
                            if (!alreadyVerified)
                                context.Update(sale);
                            return true;
                        }
                        else
                            return false;

                    }
                case Rz5.Enums.OrderType.Invoice:
                    {
                        ordhed_invoice invoice = (ordhed_invoice)o;
                        if (invoice.CompanyVar.RefGet(context) != null)
                        {
                            if (!(context.TheSysRz.TheCompanyLogic.IsCompanyFinancialsVerified(invoice.CompanyVar.RefGet(context), invoice)))
                                return false;
                        }
                        return true;
                    }
                case Enums.OrderType.Purchase:
                    {
                        //ordhed_purchase p = (ordhed_purchase)o;
                        //if (p != null)
                        //{
                        //    if (p.DetailsListPutAwayable(context).Count <= 0)
                        //        missingProps.Add("lines_need_put_away");

                        //}
                        return true;
                    }
            }
            return false;

        }

        //public virtual string GetCompletionList(ContextRz context, ordhed o, bool supress_msg = false)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(GetCompletionListSales(context, (ordhed_sales)o, supress_msg));
        //    switch (o.OrderType)
        //    {
        //        case Enums.OrderType.Sales:
        //            {

        //                break;
        //            }
        //            //case Enums.OrderType.Quote:
        //            //    {
        //            //        sb.Append(GetCompletionListQuote(context, (ordhed_quote)o, supress_msg));
        //            //        break;
        //            //    }
        //    }

        //    return sb.ToString();
        //}

        //public virtual string GetCompletionListQuote(ContextRz context, ordhed_quote quote, bool supress_msg)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    //quote.CheckVerify(context, sb);
        //    foreach (orddet_quote l in quote.DetailsList(context))
        //    {
        //        string s = "";
        //        l.Completeable(context, ref s, supress_msg);
        //        if (Tools.Strings.StrExt(s))
        //            sb.Append(s);
        //    }

        //    return sb.ToString();
        //}

        //public virtual string GetCompletionListSales(ContextRz context, ordhed_sales sale, bool supress_msg = false)
        //{
        //    //Header Details
        //    //StringBuilder sb = new StringBuilder();List<string> missingProps = new List<string>();

        //    sale.CheckVerify(context, sb);
        //    foreach (orddet_line l in sale.DetailsList(context))
        //    {
        //        string s = "";
        //        l.Completeable(context, ref s, supress_msg);
        //        if (Tools.Strings.StrExt(s))
        //            sb.Append(s);
        //    }

        //    return sb.ToString();
        //}
        //public virtual List<SalesLineGroup> GetExistingInvoices(ContextRz context, Rz5.ordhed_sales sale, List<SalesLineGroup> sections)
        //{
        //    List<SalesLineGroup> sections_list = new List<SalesLineGroup>(sections);
        //    List<ordhed> existing = sale.PotentialInvoicesList(context);
        //    if (existing.Count > 0)
        //    {
        //        bool cancel = false;
        //        sections_list = context.Leader.ChooseOrderLines(context, sale, sections, Rz5.Enums.OrderType.Invoice, existing, ref cancel);
        //        if (sections_list == null)
        //            return null;
        //    }
        //    return sections_list;
        //}

        public virtual List<SalesLineGroup> CreateNewInvoice(ContextRz context, Rz5.ordhed_sales sale, List<SalesLineGroup> sections)
        {
            List<SalesLineGroup> sections_list = new List<SalesLineGroup>();
            //List<ordhed> existing = sale.PotentialInvoicesList(context);
            List<ordhed> newInvoice = new List<ordhed>();
            bool cancel = false;
            //sections_list = context.Leader.ChooseOrderLines(context, sale, sections, Rz5.Enums.OrderType.Invoice, newInvoice, ref cancel);
            List<orddet_line> lines = new List<orddet_line>();
            sections_list = new List<SalesLineGroup>();
            List<orddet> orddetList = sale.DetailsList(context);
            foreach (orddet o in orddetList)
            {
                orddet_line line = (orddet_line)o;
                if (line == null)
                    throw new Exception("Invalid orddet_line for Invoice process.");
                lines.Add(line);
            }


            SalesLineGroup singleSalesLineForTesting = new SalesLineGroup(sale, lines);
            sections_list.Add(singleSalesLineForTesting);
            if (sections_list == null)
                return null;
            if (cancel)
                return null;
            return sections_list;
        }

        public virtual List<SalesLineGroup> GetExistingInvoices(ContextRz context, Rz5.ordhed_sales sale, List<SalesLineGroup> sections)
        {
            List<SalesLineGroup> sections_list = new List<SalesLineGroup>();
            List<ordhed> existing = sale.PotentialInvoicesList(context);
            bool cancel = false;
            sections_list = context.Leader.ChooseOrderLines(context, sale, sections, Rz5.Enums.OrderType.Invoice, existing, ref cancel);
            if (sections_list == null)
                return null;
            if (cancel)
                return null;
            return sections_list;
        }
        public virtual bool UnitPriceOK(orddet_line l)
        {
            //KT 8-25-2015 added this to ensure we can quote / sell GCAT orders at no price.
            if (!l.fullpartnumber.ToLower().Contains("gcat"))
                return l.unit_price > 0;
            else return true;
        }
        public virtual bool ShouldPOsBeCreated(ContextRz x, ordhed_sales so, List<Rz5.orddet_line> lines)
        {
            return !so.StockOrConsignCompletelyIs(x, lines);
        }
        public virtual ListArgs SalesSearchArgsGetCompany(ContextRz x, String companyId, String contactId)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "orddet_line";
            ret.TheClass = "orddet_line";
            ret.TheWhere = "isnull(ordernumber_sales, '') > '' and customer_uid = '" + companyId + "'";
            if (Tools.Strings.StrExt(contactId))
                ret.TheWhere += " and customer_contact_uid = '" + contactId + "'";

            ret.TheOrder = "orderdate_sales desc";
            ret.TheTemplate = x.TheLogicRz.TemplateSecure(x, "orddet_line", "SALESSEARCHnew");
            return ret;
        }
        public virtual ListArgs PurchaseSearchArgsGetCompany(ContextRz x, String companyId, String contactId)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "orddet_line";
            ret.TheClass = "orddet_line";
            ret.TheWhere = "isnull(ordernumber_purchase, '') > '' and vendor_uid = '" + companyId + "'";
            if (Tools.Strings.StrExt(contactId))
                ret.TheWhere += " and vendor_contact_uid = '" + contactId + "'";

            ret.TheOrder = "orderdate_sales desc";
            ret.TheTemplate = x.TheLogicRz.TemplateSecure(x, "orddet_line", "BUYSEARCHnew");
            return ret;
        }
        public virtual void AddCancelLineToSalesOrder(ContextRz context, orddet_line l, string comment)
        {
            try
            {
                if (l == null)
                    return;
                Rz5.orddet_line d = (Rz5.orddet_line)l.CloneValues(context);//.CloneWithNewID();
                d.unique_id = "";
                d.TableName = "orddet_line_canceled";
                d.orderid_invoice = "";
                d.orderid_quote = "";
                d.orderid_rma = "";
                d.orderid_service = "";
                d.orderid_vendrma = "";
                d.ordernumber_invoice = "";
                d.orderid_purchase = l.orderid_purchase;
                d.ordernumber_purchase = l.ordernumber_purchase;
                d.ordernumber_quote = "";
                d.ordernumber_rma = "";
                d.ordernumber_service = "";
                d.ordernumber_vendrma = "";
                d.Status = Rz5.Enums.OrderLineStatus.Void;
                //KT Adding a reference to the original uid for SQL join to track cancelled lines
                d.unique_id_canceled = l.unique_id;
                d.rohs_info = l.rohs_info;
                d.datecode = l.datecode;

                d.Insert(context);
            }
            catch (Exception ee)
            {
                string msg = ee.Message;
            }
        }
        public virtual void CloneSaleOrhitsToInvoice(ContextNM x, ordhed_sales sale, Rz5.ordhed_invoice invoice)
        {
            sale.invoice_created = true;
            sale.last_invoice_date = DateTime.Now;
            sale.Update(x);
            ArrayList hits = x.QtC("ordhit", "select * from ordhit where the_ordhed_uid = '" + sale.unique_id + "'");
            foreach (ordhit h in hits)
            {
                ordhit hh = (ordhit)h.CloneValues(x);//CloneWithNewID();
                hh.unique_id = "";
                hh.the_ordhed_uid = invoice.unique_id;
                hh.Insert(x);
            }
            


        }

        internal List<string> GetRequiredSalesHeaderProperties()
        {
            //terms
            //orderreference
            //billingaddress
            //shipping address
            //more than 0 lines
            //validation_stage == Validation_Complete
            //terms == TBD and ! sale.IsTermsOverride
            //Financials Verified
            List<string> ret = new List<string>() { "terms", "orderreference", "shipping_adress", "billing_address", "has_lines", "tbd_and_override", "financials_verified" };

            return ret;
        }

        internal List<string> GetRequiredLineProperties(nObject o)
        {
            List<string> ret = new List<string> { "fullpartnumber", "manufacturer", "quantity", "condition", "unit_cost"};
            orddet_line l = (orddet_line)o;
            if (!string.IsNullOrEmpty(l.orderid_sales))
                ret.Add("unit_price");
            if (!string.IsNullOrEmpty(l.orderid_sales)) //Marked for a sales order, add non-stock items to requirements          
                ret.AddRange(new List<String>() { "shipvia_invoice", "customer_dock_date", "rohs_info", "datecode" });
            if (!string.IsNullOrEmpty(l.orderid_purchase)) //No Sales Order / Standalong PO Purchase skip sales-specific stuff
            {
                ret.AddRange(new List<String>() { "shipvia_purchase", "rohs_info_vendor", "datecode_purchase" });
            }               
            return ret;
        }



        internal List<string> GetRequiredSalesHeaderLogics(ContextRz x, nObject o)
        {
            List<string> ret = new List<string>();
            ordhed_sales s = (ordhed_sales)o;
            if (s == null)
                return ret;
            CheckVerify(x, s, ret);
            return ret;
        }

        internal List<string> GetRequiredPurchaseHeaderLogics(ContextRz x, nObject o)
        {
            List<string> ret = new List<string>();
            ordhed_purchase p = (ordhed_purchase)o;
            if (p == null)
                return ret;
            CheckVerify(x, p, ret);
            return ret;
        }

        internal List<string> GetRequiredLineLogics(ContextRz x, nObject o)
        {
            List<string> ret = new List<string>();
            orddet_line l = (orddet_line)o;
            if (l == null)
                return ret;

            if (l.line_validation_status == SM_Enums.LineValidationStatus.ReSourced.ToString())
                ret.Add("New Vendor Sourced");

            // Has to be in hold
            switch (l.Status)
            {
                case Enums.OrderLineStatus.Hold:
                    {
                        switch (l.StockType)
                        {
                            //Service Lines like GCAT should already have all properties.
                            case Enums.StockType.Service:
                                return ret;
                            case Enums.StockType.Stock:
                            case Enums.StockType.Buy:
                                if (l.needs_purchasing || l.StockType == Enums.StockType.Buy)
                                    ret.AddRange(GetRequiredBuyLineLogics(x, l));
                                else
                                    ret.AddRange(GetRequiredStockLineLogics(x, l));
                                break;
                            case Enums.StockType.Consign:
                                ret.AddRange(GetRequiredConsignLineLogics(x, l));
                                break;
                            default:
                                ret.Add("No stock type");
                                break;
                        }
                        break;
                    }

            }


            //if (l.Status == Enums.OrderLineStatus.Hold)
            //    //Stocktype Specific Criteria
            //    switch (l.StockType)
            //    {
            //        case Enums.StockType.Stock:
            //        case Enums.StockType.Buy:
            //            if (l.needs_purchasing || l.StockType == Enums.StockType.Buy)
            //                ret.AddRange(GetRequiredBuyLineLogics(x, l));
            //            else
            //                ret.AddRange(GetRequiredStockLineLogics(x, l));
            //            break;
            //        case Enums.StockType.Consign:
            //            ret.AddRange(GetRequiredConsignLineLogics(x, l));
            //            break;
            //        default:
            //            ret.Add("No stock type");
            //            break;
            //    }

            return ret;
        }




        private List<string> GetRequiredConsignLineLogics(ContextRz x, orddet_line l)
        {
            List<string> ret = new List<string>();

            //Must have inventory link
            if (!Tools.Strings.StrExt(l.inventory_link_uid))
                ret.Add("Missing link to inventory");

            //Must have consignment code
            Rz5.consignment_code code = (Rz5.consignment_code)x.QtO("consignment_code", "select * from consignment_code where code_name = '" + l.consignment_code + "' and vendor_uid = '" + l.vendor_uid + "'");
            if (code == null)
                ret.Add("No consignment code: " + l.consignment_code);

            //Must have link to the consginment vendor
            if (string.IsNullOrEmpty(l.vendor_uid))
                ret.Add("Missing link to consgignment vendor");

            return ret;
        }

        private List<string> GetRequiredStockLineLogics(ContextRz x, orddet_line l)
        {
            List<string> ret = new List<string>();

            //Must have inventory link
            if (!Tools.Strings.StrExt(l.inventory_link_uid))
                ret.Add("Missing link to inventory");
            //Stock Lot is some kind of consignment code thing????  Don't think this has ever come up.
            //if (Tools.Strings.StrExt(l.lotnumber) && !Tools.Strings.HasString(l.lotnumber, "stock"))
            //{
            //    //Rz5.consignment_code code = Rz5.consignment_code.GetByName(x, l.lotnumber);
            //    Rz5.consignment_code code = Rz5.consignment_code.GetByName(x, l.consignment_code);
            //    if (code == null)
            //        ret.Add("No stock lot " + l.lotnumber);
            //}

            //KT the end result of the above seems to just check fro a consignment code, based on some odd parameters. 
            //Consign Lines would never get here.  Removing for now, as it's preventing an order from processing.


            return ret;
        }

        public static List<string> GetRequiredBuyLineLogics(ContextRz x, orddet_line l)
        {
            List<string> ret = new List<string>();
            //Buy Lines must have vendor:
            company vend = l.VendorVar.RefGet(x);
            if (vend == null)
            {
                ret.Add("No vendor");
                return ret;
            }
            ////Rohs info from vendor
            //if(string.IsNullOrEmpty(l.rohs_info_vendor))
            //    ret.Add("RoHS info");

            //Vendor has not been vetted
            if (!x.TheSysRz.TheCompanyLogic.CheckVetted(x, vend))
                ret.Add(vend.companyname + " needs to be vetted");
            //Service Vendor, cannpt buy product (not sure if this is useful)
            if (!vend.isServiceVendor(x))
                ret.Add(vend.companyname + " is a Service Vendor");
            //No Scope of Authorite for components
            if (!vend.SOA_components)
                ret.Add(vend.companyname + " no SOA for Component Purchases");
            //Vendor Not on AVL
            if (!vend.isverified)
                ret.Add(vend.companyname + " not on our AVL");
            //Vendor is locked
            if (vend.is_locked || vend.islocked_purchase)
                ret.Add(vend.companyname + " is locked");

            //if (!l.was_received)
            //    ret.Add("Not received");
            return ret;
        }
    }

}
