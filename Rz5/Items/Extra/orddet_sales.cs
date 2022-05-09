using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;
using Rz5.Enums;

namespace Rz5
{
    public partial class orddet_line
    {
        public VarRefOrderNew<ordhed> SalesVar;
        public VarRefFieldPlusName<orddet_line, company> CustomerVar;
        public VarRefFieldPlusName<orddet_line, companycontact> CustomerContactVar;
        public VarRefFieldPlusName<orddet_line, n_user> SellerVar;
        //KT - Testing Assigning "seller" form company owner rather than Ordhed owner.
        public VarRefFieldPlusName<orddet_line, company> SellerVar2;

        public bool Completeable(ContextRz context)
        {
            List<String> messages = new List<string>();
            return Completeable(context, messages, new List<string>());
        }

        public bool Completeable(ContextRz x, ref String message, bool supress_msg = false)
        {
            List<String> messages = new List<string>();
            bool b = Completeable(x, messages, new List<string>(), supress_msg);

            foreach (String m in messages)
            {
                message += "#" + linecode_sales.ToString() + " : " + m + "\r\n";
            }

            return b;
        }
        public bool Completeable(ContextRz x, ref String message, ref List<string> fields, bool supress_msg = false)
        {
            List<String> messages = new List<string>();
            bool b = Completeable(x, messages, fields, supress_msg);

            foreach (String m in messages)
            {
                message += "#" + linecode_sales.ToString() + " : " + m + "\r\n";
            }

            return b;
        }

        public virtual bool Completeable(ContextRz x, List<String> messages, List<String> fieldNames, bool supress_msg = false)
        {
            List<Enums.OrderLineStatus> completableStatus = new List<OrderLineStatus>() { Enums.OrderLineStatus.Hold , Enums.OrderLineStatus.PreInvoiced};
            if (!completableStatus.Contains(Status))
                return false;
            bool b = true;

            ////Part number
            //if (!Tools.Strings.StrExt(fullpartnumber))
            //{
            //    b = false;
            //    messages.Add("No part number");
            //    fieldNames.Add("fullpartnumber");
            //}
            ////Unit Price
            //if (!x.TheSysRz.TheSalesLogic.UnitPriceOK(this))
            //{
            //    b = false;
            //    messages.Add("No price");
            //    fieldNames.Add("unit_price");
            //}
            ////Shipping Method
            //if (!x.TheSysRz.TheLineLogic.ShipViaInvoiceOK(this))
            //{
            //    b = false;
            //    messages.Add("No shipping method");
            //    fieldNames.Add("shipvia_invoice");
            //}

            ////Cust Dock Date
            //if (!Tools.Dates.DateExists(customer_dock_date))
            //{
            //    messages.Add("No customer dock date");
            //    fieldNames.Add("customer_dock_date");
            //    b = false;
            //}
            ////KT 8-24-2015 - check for lines that are not assocaited with a quote.
            //if (String.IsNullOrEmpty(quote_line_uid))
            //{
            //    b = false;
            //    messages.Add("No quote associated with this line.");
            //    fieldNames.Add("quote_line_uid");
            //    return b;
            //}

            //Stocktype Specific Criteria
            switch (StockType)
            {
                case StockType.Service:
                    b = true;
                    break;
                case Enums.StockType.Stock:
                case Enums.StockType.Buy:
                    if (needs_purchasing || StockType == Enums.StockType.Buy)
                        b = Completeable_Buy(x, messages, supress_msg);
                    else
                        b = Completeable_Stock(x, messages);
                    break;
                case Enums.StockType.Consign:
                    b = Completeable_Consign(x, messages);
                    break;
                default:
                    b = false;
                    messages.Add("No stock type");
                    break;
            }

            if (!b)
                return false;
            else
                return true;
        }
        public virtual bool Completeable_Stock(ContextRz x, List<String> messages)
        {
            bool b = true;

            //Inventory Link
            if (!Tools.Strings.StrExt(inventory_link_uid)) // && !x.TheLeaderRz.IsWeb())
            {
                b = false;
                messages.Add("No stock allocation link created.");
            }

            //Lot Number
            if (Tools.Strings.StrExt(lotnumber) && !Tools.Strings.HasString(lotnumber, "stock"))
            {
                //Rz5.consignment_code code = Rz5.consignment_code.GetByName(x, lotnumber);
                //if (code == null)
                //{
                //    b = false;
                //    messages.Add("No stock lot " + lotnumber);
                //}
            }

            //KT 11-10-2015 Refactored from  Rz5 orddet_line
            //if (!Tools.Dates.DateExists(customer_dock_date))
            //{
            //    messages.Add("No customer dock date");
            //    b = false;
            //}

            return b;
        }
        public virtual bool Completeable_Consign(ContextRz x, List<String> messages)
        {
            bool b = true;
            if (!Tools.Strings.StrExt(inventory_link_uid))// && !x.TheLeaderRz.IsWeb())
            {
                b = false;
                messages.Add("No consignment allocation link created");
            }
            
            Rz5.consignment_code code = (Rz5.consignment_code)x.QtO("consignment_code", "select * from consignment_code where code_name = '" + consignment_code + "' and vendor_uid = '" + vendor_uid + "'");
            if (code == null)
            {
                b = false;
                messages.Add("No consignment code: " + consignment_code);
            }
            //if (!Tools.Dates.DateExists(customer_dock_date))
            //{
            //    messages.Add("No customer dock date");
            //    b = false;
            //}
            //KT End 11-10-2015 Refactor
            if (string.IsNullOrEmpty(vendor_uid))
            {
                messages.Add("No Consginment vendor id");
                b = false;
            }
            //Ensure Consignment has vendor uid


            //Ensure Consignment has consignment code
            //if (string.IsNullOrEmpty(consignment_code))
            //{
            //    x.Leader.Error("Line: " + fullpartnumber + "  (Linecode: " + linecode_sales + ") consignment, missing consignment code.");
            //    return false;
            //}

            ////Ensure Consignment has vendor uid
            //if (string.IsNullOrEmpty(vendor_uid))
            //{
            //    x.Leader.Error("Line: " + l.fullpartnumber + "  (Linecode: " + l.linecode_sales + ") Consingnment: Missing vendor ID");
            //    return false;
            //}




            return b;
        }
        public virtual bool Completeable_Buy(ContextRz x, List<String> messages, bool supress_msg = false)
        {
            bool b = true;
            company vend = (company)VendorVar.RefGet(x); //CustomerVar.RefGet(x);  // company.GetByID(x.xSys, vendor_uid);
            //Needs Vendor
            //Vendor Needs Vet
            //Vetted but Blocked
           
            b = x.TheSysRz.TheOrderLogic.CheckVendorApprovalStatus(x,null, messages, vend,  false);


           



            //KT End 11-10-2015 Refactor
            return b;
        }

        public virtual bool Invoiceable(ContextRz context, StringBuilder sb, bool preInvoice = false)
        {
            switch (Status)
            {
                case Rz5.Enums.OrderLineStatus.Open:
                case Enums.OrderLineStatus.Received_From_Service:
                    return true;
                default:
                    //if (drop_ship && !InvoiceHas)
                    if (!InvoiceHas && status == "Open")
                        return true;
                    else if (preInvoice)
                        return true;
                    else
                    {
                        if (sb != null)
                            sb.AppendLine(ToString() + " is not open and is not drop-ship");
                        return false;
                    }
            }
        }

        public bool SalesHas
        {
            get
            {
                return OrderHas(Enums.OrderType.Sales);  // Tools.Strings.StrExt(ordernumber_sales);
            }
        }

        public virtual void ShipDueDateAcceptableCheck(ContextRz context, DateTime shipDate)
        {
        }

        public virtual void SetShipDateDue(ContextRz context, DateTime shipDateDue)
        {
            ShipDueDateAcceptableCheck(context, shipDateDue);
            ship_date_due = shipDateDue;
        }

        public LineAssignedAgent SellerAssignedAgent(ContextRz context)
        {
            return new LineAssignedAgent(context, seller_uid);
        }
    }
}