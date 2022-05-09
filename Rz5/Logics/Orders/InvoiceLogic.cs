using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Rz5
{
    public class InvoiceLogic : NewMethod.Logic
    {
        public override void ActInstance(Context context, ActArgs args)
        {

        }


        public virtual orddet_line MakeLineFromStock(ContextRz x, partrecord p, ordhed_invoice i)
        {//KT this can be used for mass-shipping inventory when there is no sales order, etc(i.e. lot buys / liquidation)
            try
            {

                x.Leader.Comment("Creating line item from " + p.fullpartnumber);
                orddet_line l = new orddet_line();
                l.importid = p.importid;
                l.stocktype = p.stocktype;
                l.quantity = (Int32)p.quantity;
                if (!string.IsNullOrEmpty(p.base_company_uid))
                {
                    company c = company.GetById(x, p.base_company_uid);
                    l.vendor_uid = c.unique_id;
                    l.vendor_name = c.companyname;
                    if (!string.IsNullOrEmpty(p.base_companycontact_uid))
                    {
                        companycontact contact = companycontact.GetById(x, p.base_companycontact_uid);
                        //l.VendorContactVar.RefSet(x, contact);
                        l.customer_contact_uid = contact.unique_id;
                        l.customer_name = contact.contactname;
                    }
                }

                l.unit_price = p.price;
                l.unit_cost = p.cost;
                l.fullpartnumber = p.fullpartnumber;

                l.manufacturer = p.manufacturer;
                l.alternatepart = p.alternatepart;
                l.internal_customer = p.internalpartnumber;
                l.datecode = p.datecode;
                l.description = p.description;
                l.condition = p.condition;
                //l.orderid_quote = p.base_ordhed_uid;
                //l.ordernumber_quote = p.ordernumber;
                //l.quote_line_uid = p.unique_id;
                l.rohs_info = p.rohs_info;
                l.lotnumber = p.lotnumber;
                //l.consignment_code = p.lotnumber;
                l.consignment_code = p.consignment_code;
                l.packaging = p.packaging;
                l.seller_uid = i.base_mc_user_uid;
                l.seller_name = i.agentname;

                //KT Consider Carrying quoted part number into new 'quotedpartnumber' field on orddet_line
                l.quoted_partnumber = p.fullpartnumber;


                //List Acquisition Agent
                l.list_acquisition_agent = p.list_acquisition_agent;
                l.list_acquisition_agent_uid = p.list_acquisition_agent_uid;


                l.CostCalc(x);

                l.bid_partnumber = p.fullpartnumber;
                l.datecode_purchase = p.datecode;
                //Maintain linkage between original stock id and Inventory link uid
                l.inventory_link_uid = p.unique_id;
                

                //Ah, this is why the line was inserted already.
                l.receive_location = p.location;
                x.Insert(l);
                if (l.StockType == Enums.StockType.Stock || l.StockType == Enums.StockType.Consign || l.StockType == Enums.StockType.Excess)
                {
                    if (!l.LinkAndAllocate(x, p, false))
                        return null;
                }

                if (l.StockType == Enums.StockType.Buy)
                    l.needs_purchasing = true;


                //x.Delete(p);
                return l;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }


        public List<ordhed_invoice> GetAgedInvoicesForCompany(ContextRz x, company c)
        {
            List<ordhed_invoice> agedInvoiceList = new List<ordhed_invoice>();
            try
            {
                string sql = "select * From ordhed_invoice where  isclosed = 1 ";
                sql += "and base_company_uid = '" + c.unique_id + "' ";
                sql += "and terms like 'Net%' ";
                sql += "and  dateclosed >= '2015-01-01' ";
                List<ordhed_invoice> termsInvoiceList = x.QtC("ordhed_invoice", sql).Cast<ordhed_invoice>().ToList();

                foreach (ordhed_invoice i in termsInvoiceList)
                {
                    //Not interested in invoices that have no outstanding amount
                    if (i.outstandingamount <= 0)
                        continue;
                    string strTerms = i.terms.ToLower().Replace("net", "");
                    int termDays = 0;
                    if (!Int32.TryParse(strTerms, out termDays))
                        continue;
                    double elapsedDays = (DateTime.Now - (DateTime)i.dateclosed).TotalDays;
                    if (elapsedDays >= termDays)
                        agedInvoiceList.Add(i);
                }
                int totalAgedInvoice = agedInvoiceList.Count();               
            }
            catch (Exception ex)
            {
                x.Leader.Error(ex.Message);
                return null;
            }


            return agedInvoiceList;
        }


        public double GetAgedInvoiceAmountForCompany(ContextRz x, company c)
        {
            List<ordhed_invoice> invList = GetAgedInvoicesForCompany(x, c);
            if (invList != null)
                if (invList.Count > 0)
                    return invList.Sum(s => s.outstandingamount);
            return 0;
        }

        public ordhed_invoice ChooseExistingInvoiceForCompany(ContextRz x, company c)
        {
            ordhed_invoice i = null;
            ArrayList existingInvoices = GetInvoicesForCompany(x, c);
            i = (ordhed_invoice)x.Leader.ChooseObjectFromCollection(x, existingInvoices);
            return i;
        }
        public ArrayList GetInvoicesForCompany(ContextRz context, company c)
        {
            return context.QtC("ordhed_invoice", "select * from ordhed_invoice where base_company_uid = '" + c.unique_id + "'");
        }


    }
}
