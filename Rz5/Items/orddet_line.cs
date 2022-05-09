using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;
using Rz5.Enums;
using System.Linq;

namespace Rz5
{
    public partial class orddet_line : orddet_line_auto
    {
        public VarRefDeductions DeductionsVar;

        public override List<Var> VarsGetInitially()
        {
            List<Var> ret = base.VarsGetInitially();
            ret.Add(SalesVar);
            ret.Add(PurchaseVar);
            ret.Add(InvoiceVar);
            ret.Add(ServiceVar);
            ret.Add(RMAVar);
            ret.Add(VendRMAVar);
            ret.Add(PacksInVar);
            ret.Add(PacksInServiceVar);
            ret.Add(PacksRMAVar);
            ret.Add(PacksOutVar);
            ret.Add(PacksOutServiceVar);
            ret.Add(PacksVendRMAVar);
            ret.Add(DeductionsVar);
            ret.Add(CustomerVar);
            ret.Add(CustomerContactVar);
            ret.Add(VendorVar);
            ret.Add(VendorContactVar);
            ret.Add(ServiceVendorVar);
            ret.Add(ServiceVendorContactVar);
            ret.Add(SellerVar);
            ret.Add(BuyerVar);
            ret.Add(ServiceAgentVar);
            return ret;
        }

        public override Var VarGetByName(string name)
        {
            switch (name.ToLower().Trim())
            {
                case "sales":
                    return SalesVar;
                case "purchase":
                    return PurchaseVar;
                case "service":
                    return ServiceVar;
                case "invoice":
                    return InvoiceVar;
                case "rma":
                    return RMAVar;
                case "vendrma":
                    return VendRMAVar;
                case "packsin":
                    return PacksInVar;
                case "packsinservice":
                    return PacksInServiceVar;
                case "packsrma":
                    return PacksRMAVar;
                case "packsout":
                    return PacksOutVar;
                case "packsoutservice":
                    return PacksOutServiceVar;
                case "packsvendrma":
                    return PacksVendRMAVar;
                case "servicelines":
                    return ServiceLines;
                case "deductions":
                    return DeductionsVar;
                case "customer":
                    return CustomerVar;
                case "customercontact":
                    return CustomerContactVar;
                case "vendor":
                    return VendorVar;
                case "vendorcontact":
                    return VendorContactVar;
                case "servicevendor":
                    return ServiceVendorVar;
                case "servicevendorcontact":
                    return ServiceVendorContactVar;
                case "seller":
                    return SellerVar;
                case "buyer":
                    return BuyerVar;
                case "serviceagent":
                    return ServiceAgentVar;
                default:
                    return base.VarGetByName(name);
            }
        }

        //Constructor
        public orddet_line()
        {
            SalesVar = new VarRefOrderNew<ordhed>(this, new CoreVarRefSingleAttribute("Sales", "orddet_line", "ordhed_sales", "Details", "orderid_" + Enums.OrderType.Sales.ToString().ToLower()), Enums.OrderType.Sales);
            PurchaseVar = new VarRefOrderNew<ordhed>(this, new CoreVarRefSingleAttribute("Purchase", "orddet_line", "ordhed_purchase", "Details", "orderid_" + Enums.OrderType.Purchase.ToString().ToLower()), Enums.OrderType.Purchase);
            InvoiceVar = new VarRefOrderNew<ordhed>(this, new CoreVarRefSingleAttribute("Invoice", "orddet_line", "ordhed_invoice", "Details", "orderid_" + Enums.OrderType.Invoice.ToString().ToLower()), Enums.OrderType.Invoice);
            ServiceVar = new VarRefOrderNew<ordhed>(this, new CoreVarRefSingleAttribute("Service", "orddet_line", "ordhed_service", "Details", "orderid_" + Enums.OrderType.Service.ToString().ToLower()), Enums.OrderType.Service);
            RMAVar = new VarRefOrderNew<ordhed>(this, new CoreVarRefSingleAttribute("RMA", "orddet_line", "ordhed_rma", "Details", "orderid_" + Enums.OrderType.RMA.ToString().ToLower()), Enums.OrderType.RMA);
            VendRMAVar = new VarRefOrderNew<ordhed>(this, new CoreVarRefSingleAttribute("VendRMA", "orddet_line", "ordhed_vendrma", "Details", "orderid_" + Enums.OrderType.VendRMA.ToString().ToLower()), Enums.OrderType.VendRMA);

            PacksInVar = new VarRefPacks(this, "PacksIn", "LineIn", "the_orddet_purchase_uid");
            PacksInServiceVar = new VarRefPacks(this, "PacksInService", "LineInService", "the_orddet_service_in_uid");
            PacksRMAVar = new VarRefPacks(this, "PacksRMA", "LineRMA", "the_orddet_rma_uid");

            PacksOutVar = new VarRefPacks(this, "PacksOut", "LineOut", "the_orddet_invoice_uid");
            PacksOutServiceVar = new VarRefPacks(this, "PacksOutService", "LineOutService", "the_orddet_service_out_uid");
            PacksVendRMAVar = new VarRefPacks(this, "PacksVendRMA", "LineVendRMA", "the_orddet_vendrma_uid");

            ServiceLines = new VarRefServiceLines(this);
            DeductionsVar = new VarRefDeductions(this, "Deductions", "TheLine");

            CustomerVar = new VarRefFieldPlusName<orddet_line, company>(this, new CoreVarRefSingleAttribute("Customer", "Rz4.orddet_line", "Rz4.company", "", "customer_uid"), "companyname", "customer_name");
            CustomerContactVar = new VarRefFieldPlusName<orddet_line, companycontact>(this, new CoreVarRefSingleAttribute("CustomerContact", "Rz4.orddet_line", "Rz4.companycontact", "", "customer_contact_uid"), "contactname", "customer_contact_name");

            VendorVar = new VarRefFieldPlusName<orddet_line, company>(this, new CoreVarRefSingleAttribute("Vendor", "Rz4.orddet_line", "Rz4.company", "", "vendor_uid"), "companyname", "vendor_name");
            VendorContactVar = new VarRefFieldPlusName<orddet_line, companycontact>(this, new CoreVarRefSingleAttribute("VendorContact", "Rz4.orddet_line", "Rz4.companycontact", "", "vendor_contact_uid"), "contactname", "vendor_contact_name");

            ServiceVendorVar = new VarRefFieldPlusName<orddet_line, company>(this, new CoreVarRefSingleAttribute("ServiceVendor", "Rz4.orddet_line", "Rz4.company", "", "service_vendor_uid"), "companyname", "service_vendor_name");
            ServiceVendorContactVar = new VarRefFieldPlusName<orddet_line, companycontact>(this, new CoreVarRefSingleAttribute("ServiceVendorContact", "Rz4.orddet_line", "Rz4.companycontact", "", "service_vendor_contact_uid"), "contactname", "service_vendor_contact_name");
            //KT is this where the seller is getting tagged?  Can I change this var (or make a new one) that related this line with the Company Owner rather thatn the n_user assigned on the order_header? MEssed with this on 1/30
            //Opted not to continue, the method that assigns agents wants an n_user overload, which relates the order to who is logged in, and this is used for both seller and buyer
            //I can change the sellervar I think but it would implicate the buyer as well.  Too many questions, need to learn more at a future date.
            SellerVar = new VarRefFieldPlusName<orddet_line, n_user>(this, new CoreVarRefSingleAttribute("Seller", "Rz4.orddet_line", "Rz4.n_user", "", "seller_uid"), "name", "seller_name");
            //KT - this my work
            //SellerVar2 = new VarRefFieldPlusName<orddet_line, company>(this, new CoreVarRefSingleAttribute("Seller", "Rz4.orddet_line", "Rz4.company", "company.base_mc_user_uid", "seller_uid"), "agentname", "seller_name");

            BuyerVar = new VarRefFieldPlusName<orddet_line, n_user>(this, new CoreVarRefSingleAttribute("Buyer", "Rz4.orddet_line", "Rz4.n_user", "", "buyer_uid"), "name", "buyer_name");
            ServiceAgentVar = new VarRefFieldPlusName<orddet_line, n_user>(this, new CoreVarRefSingleAttribute("ServiceAgent", "Rz4.orddet_line", "Rz4.n_user", "", "service_agent_uid"), "name", "service_agent_name");
        }



        public void HandleListAquisitionAgent(ContextRz x)
        {
            //For Standalone PO's, not linked to a Sales Order, ask for List Aquisition Agent
            if (!string.IsNullOrEmpty(this.orderid_sales))
                return;

            //If list aquisition already set
            if (!string.IsNullOrEmpty(this.list_acquisition_agent_uid))
                return;

            //Instantiate the Object
            List<n_user> existingListAquisitionAgentList = new List<n_user>();


            //Get any existing Excess matches by part and Vendor, alert the excess agents and disty sales to properly manage stock Also detect any existing list aquisition agents.
            List<partrecord> existingExcess = GetExistingListAquisitionExcessMatches(x, this.fullpartnumber, this.vendor_uid);
            if (existingExcess.Count > 0)
            {
                //Get a list of existing list agent ids from partrecords
                List<string> listExistingAquiAgentIds = existingExcess.Select(s => s.list_acquisition_agent_uid).Distinct().ToList();
                //Add these users to the list
                existingListAquisitionAgentList = x.QtC("n_user", "select * From n_user where  unique_id in ( " + Tools.Data.GetIn(listExistingAquiAgentIds) + " ) ").Cast<n_user>().ToList();
                //using this list send the email alert, even if the stuff that happens later fails, we need to notify.
                SendExcessSaleEmailAlert(existingExcess, existingListAquisitionAgentList);
            }

            //The Single Aquisition agent.
            n_user listAquisitionAgent = null;
            //If there is exactly one existing agent, use that.
            if (existingListAquisitionAgentList.Count == 1)
                listAquisitionAgent = existingListAquisitionAgentList[0];
            //IF there are more than one detected agent, we need to fix manually
            else if (existingListAquisitionAgentList.Count > 1)
                throw new Exception("We have detected matches for this part for more thatn 1 agent.  Please work with Sales and IT to properly set the list Aquisition agent for this line item.");

            //IF unable to auto-identify List Aquisition agent, offer to choose.
            if (listAquisitionAgent == null)
                if (x.Leader.AskYesNo("Would you like to set the List Acquisition Agent for this line?"))
                    listAquisitionAgent = n_user.Choose(x, false);
            //Let user choose

            //No null, no agent was set.
            if (listAquisitionAgent != null)
            {
                this.list_acquisition_agent = listAquisitionAgent.name;
                this.list_acquisition_agent_uid = listAquisitionAgent.unique_id;
                this.Update(x);
            }
            //else
            //{
            //    x.Leader.Tell("List Aquisition agent was NOT set.");
            //    return;
            //}




        }

        private void SendExcessSaleEmailAlert(List<partrecord> existingExcess, List<n_user> listAquisitionAgentList)
        {
            List<string> ccList = new List<string>();
            List<n_user> ccUsers = new List<n_user>();
            foreach (n_user u in listAquisitionAgentList)
            {
                if (Tools.Email.IsEmailAddress(u.email_address))
                    if (!ccList.Contains(u.email_address))
                        ccList.Add(u.email_address.Trim().ToLower());
            }

            ccList.Add("ktill@sensiblemicro.com");
            //List<n_user> aquisitionAgentlist = new List<n_user>();
            //List<string> listAqAgents = existingExcess.Where(w => w.list_acquisition_agent_uid.Length > 0).Select(s => s.list_acquisition_agent_uid).Distinct().ToList();
            //Include any list aquisitiona gents in the email alert
            //if (listAqAgents != null)
            //    foreach (string s in listAqAgents)
            //    {
            //        n_user u = (n_user)RzWin.Context.QtO("n_user", "select * from n_user where unique_id = '" + s + "'");
            //        if (u != null)
            //            if (Tools.Email.IsEmailAddress(u.email_address))
            //                if (!ccList.Contains(u.email_address))
            //                    ccList.Add(u.email_address);
            //    }


            StringBuilder message = new StringBuilder();
            message.Append("<b>PO# " + this.ordernumber_purchase + " matches Excess Line " + this.fullpartnumber + ". </b><br/>");
            message.Append("<br /><em>(Please confirm list aquisition agent, and update the excess partrecord for qty, etc.)</em><br/>");
            message.Append("PO# " + this.ordernumber_purchase + " Part: " + this.fullpartnumber.Trim().ToUpper() + " QTY: " + this.quantity + " MFG: " + this.manufacturer + " Vendor: " + this.vendor_name);
            message.Append("<br /> ---------------- <br />");
            foreach (partrecord p in existingExcess)
            {
                message.Append("Part: " + p.fullpartnumber.Trim().ToUpper() + " QTY: " + p.quantity + " MFG: " + p.manufacturer + " Vendor: " + p.companyname + "<br />");
                message.Append("ImportID: " + p.importid + " ListAgent: " + p.list_acquisition_agent + "<br />");
                message.Append("<br/>");
            }

            //Include DistySales in the email Alert (they manage excess)
            SensibleDAL.SystemLogic.Email.SendMail("rz_excess@sensiblemicro.com", "distysales@sensiblemicro.com", "Excess Sale Alert: PO# " + this.ordernumber_purchase, message.ToString(), ccList.ToArray());

            return;
        }


        private List<partrecord> GetExistingListAquisitionExcessMatches(ContextRz x, string fullpartnumber, string vendor_uid)
        {
            List<partrecord> ret = new List<partrecord>();
            ret = x.QtC("partrecord", "select * from partrecord where stocktype = 'excess' AND fullpartnumber = '" + fullpartnumber + "' AND base_company_uid = '" + vendor_uid + "'").Cast<partrecord>().ToList();

            return ret;
        }




        ~orddet_line()
        {
            try
            {
                SalesVar.Dispose();
                SalesVar = null;

                PurchaseVar.Dispose();
                PurchaseVar = null;

                InvoiceVar.Dispose();
                InvoiceVar = null;

                ServiceVar.Dispose();
                ServiceVar = null;

                RMAVar.Dispose();
                RMAVar = null;

                VendRMAVar.Dispose();
                VendRMAVar = null;

                PacksInVar.Dispose();
                PacksInVar = null;

                PacksInServiceVar.Dispose();
                PacksInServiceVar = null;

                PacksRMAVar.Dispose();
                PacksRMAVar = null;

                PacksOutVar.Dispose();
                PacksOutVar = null;

                PacksOutServiceVar.Dispose();
                PacksOutServiceVar = null;

                PacksVendRMAVar.Dispose();
                PacksVendRMAVar = null;

            }
            catch { }
        }

        private ordhed_quote m_TheQuote = null;
        public ordhed_quote TheQuoteGet(ContextRz context)
        {
            if (!Tools.Strings.StrExt(orderid_quote))
                return null;
            if (m_TheQuote == null)
                m_TheQuote = ordhed_quote.GetById(context, orderid_quote);
            return m_TheQuote;
        }

        public void TheQuoteSet(ordhed_quote value)
        {
            m_TheQuote = value;
        }

        public List<String> SummedIds;

        public override void Inserting(Context x)
        {
            base.Inserting(x);

            if (!Tools.Strings.StrExt(status))
                Status = Rz5.Enums.OrderLineStatus.Hold;

            //KT  - Refactored from RzSensible
            ArrayList a = x.QtC("profit_deduction", "select * from profit_deduction where purchase_order_uid = '" + orderid_purchase + "'");
            if (a == null)
                return;
            total_fees = 0;
            foreach (profit_deduction p in a)
            {
                if (p == null)
                    continue;
                total_fees += p.amount;
            }



            //KT 11-10-2015 Refactored from RzSensible
            if (!Tools.Strings.StrExt(orderid_purchase))
                return;
        }

        public override void Updating(Context context)
        {
            ContextRz xrz = (ContextRz)context;

            switch (StockType)
            {
                case Enums.StockType.Consign:
                    StockTypeReceive = Enums.StockType.Consign;
                    break;
                default:
                    StockTypeReceive = Enums.StockType.Stock;
                    break;
            }

            if (xrz.Accounts.IsBaseCurrency(currency_name_price))
            {
                currency_name_price = xrz.Accounts.BaseCurrency;  //fill in if blank
                exchange_rate_price = 1;
                unit_price_exchanged = unit_price;
                total_price_exchanged = total_price;
                unit_price_rma_exchanged = unit_price_rma;
                total_price_rma_exchanged = total_price_rma;
            }

            if (xrz.Accounts.IsBaseCurrency(currency_name_cost))
            {
                currency_name_cost = xrz.Accounts.BaseCurrency;  //fill in if blank
                exchange_rate_cost = 1;
                unit_cost_exchanged = unit_cost;
                total_cost_exchanged = total_cost;
                unit_price_vendrma_exchanged = unit_price_vendrma;
                total_price_vendrma_exchanged = total_price_vendrma;
            }

            //CalculateAmounts(xrz);
            //CalculatePackQuantities(xrz);

            //if (Status == Rz4.Enums.OrderLineStatus.Packing && quantity > 0 && quantity_packed == quantity)
            //    Status = Rz4.Enums.OrderLineStatus.Packed;

            ShipInfoCalc();
            status_caption = StatusCaption;

            String pre = "";
            String bas = "";
            PartObject.ParsePartNumber(fullpartnumber, ref pre, ref bas);
            prefix = Tools.Strings.FilterTrash(pre);
            basenumber = Tools.Strings.FilterTrash(bas);
            basenumberstripped = basenumber;

            internalstripped = Tools.Strings.FilterTrash(internal_customer);
            part_number_stripped = Tools.Strings.FilterTrash(fullpartnumber);

            if (!purchased_as_other)
                purchased_as_number = fullpartnumber;

            purchased_as_stripped = Tools.Strings.FilterTrash(purchased_as_number);

            unit_price_print = xrz.Accounts.CurrencySymbol(currency_name_price) + " " + Tools.Number.MoneyFormat(Math.Round(unit_price_exchanged, 6));
            total_price_print = xrz.Accounts.CurrencySymbol(currency_name_price) + " " + Tools.Number.MoneyFormat(Math.Round(total_price_exchanged, 6));
            unit_cost_print = xrz.Accounts.CurrencySymbol(currency_name_cost) + " " + Tools.Number.MoneyFormat(Math.Round(unit_cost_exchanged, 6));
            total_cost_print = xrz.Accounts.CurrencySymbol(currency_name_cost) + " " + Tools.Number.MoneyFormat(Math.Round(total_cost_exchanged, 6));
            unit_price_rma_print = xrz.Accounts.CurrencySymbol(currency_name_price) + " " + Tools.Number.MoneyFormat(Math.Round(unit_price_rma_exchanged, 6));
            total_price_rma_print = xrz.Accounts.CurrencySymbol(currency_name_price) + " " + Tools.Number.MoneyFormat(Math.Round(total_price_rma_exchanged, 6));
            unit_price_vendrma_print = xrz.Accounts.CurrencySymbol(currency_name_cost) + " " + Tools.Number.MoneyFormat(Math.Round(unit_price_vendrma_exchanged, 6));
            total_price_vendrma_print = xrz.Accounts.CurrencySymbol(currency_name_cost) + " " + Tools.Number.MoneyFormat(Math.Round(total_price_vendrma_exchanged, 6));

            part_master m = part_master.Find(xrz, fullpartnumber);
            if (m != null)
            {
                if (m.manufacturer != "")
                    manufacturer = m.manufacturer;
                if (m.description != "")
                    description = m.description;
            }

            base.Updating(context);
        }

        public virtual void ApplyNewCurrencyPrice(ContextRz context, currency newCurrency)
        {
            currency_name_price = newCurrency.name;
            exchange_rate_price = newCurrency.exchange_rate;
            CurrencyUpdate(context);
        }

        public virtual void ApplyNewCurrencyCost(ContextRz context, currency newCurrency)
        {
            currency_name_cost = newCurrency.name;
            exchange_rate_cost = newCurrency.exchange_rate;
            CurrencyUpdate(context);
        }

        public virtual void CurrencyUpdate(ContextRz x)
        {
            if (x.Sys.TheAccountLogic.IsBaseCurrency(currency_name_price))
            {
                exchange_rate_price = 1;
                exchange_rate_rma = 1;
                unit_price_exchanged = unit_price;
                unit_price_rma_exchanged = unit_price_rma;
            }
            else
            {
                if (exchange_rate_price == 0)
                    throw new Exception(ToString() + " has a price currency of " + currency_name_price + " but an exchange rate of 0");

                unit_price_exchanged = currency.CalculateExchangeFromBase(unit_price, exchange_rate_price, 6);
                unit_price_rma_exchanged = currency.CalculateExchangeFromBase(unit_price_rma, exchange_rate_rma, 6);
            }

            if (x.Sys.TheAccountLogic.IsBaseCurrency(currency_name_cost))
            {
                exchange_rate_cost = 1;
                exchange_rate_vendrma = 1;
                unit_cost_exchanged = unit_cost;
                unit_price_vendrma_exchanged = unit_price_vendrma;
            }
            else
            {
                if (exchange_rate_cost == 0)
                    throw new Exception(ToString() + " has a cost currency of " + currency_name_cost + " but an exchange rate of 0");

                unit_cost_exchanged = currency.CalculateExchangeFromBase(unit_cost, exchange_rate_cost, 6);
                unit_price_vendrma_exchanged = currency.CalculateExchangeFromBase(unit_price_vendrma, exchange_rate_vendrma, 6);
            }
        }

        protected virtual void CalculatePackQuantities(ContextRz context)
        {
            if (PacksInVar.Initialized)
                quantity_unpacked = PacksInVar.QuantitySum(context);

            if (PacksOutVar.Initialized)
                //KT 11-11-2015 - Since I don't associate a "pack" with GCAT lines, need to prevent QTY packed getting overwritten to 0               
                if (quote_line_uid != "GCAT_QUOTE_UID")
                    quantity_packed = PacksOutVar.QuantitySum(context);

            if (PacksRMAVar.Initialized)
                quantity_unpacked_rma = PacksRMAVar.QuantitySum(context);

            if (PacksVendRMAVar.Initialized)
                quantity_packed_vendrma = PacksVendRMAVar.QuantitySum(context);

            if (PacksOutServiceVar.Initialized)
                quantity_packed_service = PacksOutServiceVar.QuantitySum(context);

            if (PacksInServiceVar.Initialized)
                quantity_unpacked_service = PacksInServiceVar.QuantitySum(context);
        }

        void ShipInfoCalc()
        {
            ship_date_next = ship_date_due;
            receive_date_next = receive_date_due;
            switch (Status)
            {
                case Enums.OrderLineStatus.Open:
                    ship_date_next = ship_date_due;
                    shipvia_next = shipvia_invoice;
                    ship_to_next = customer_name + " (Sales Order# " + ordernumber_sales + ")";
                    break;
                case Enums.OrderLineStatus.Packing:
                    ship_date_next = ship_date_due;
                    shipvia_next = shipvia_invoice;
                    ship_to_next = customer_name + " (Invoice# " + ordernumber_invoice + ")";
                    break;
                case Enums.OrderLineStatus.Buy:
                    receive_date_next = receive_date_due;
                    shipvia_receive_next = shipvia_purchase;
                    receive_from_next = vendor_name + " (PO# " + ordernumber_purchase + ")";
                    break;
                case Enums.OrderLineStatus.Packing_For_Service:
                    ship_date_next = ship_date_service_due;
                    shipvia_next = shipvia_service_out;
                    ship_to_next = service_vendor_name + " (Service Order# " + ordernumber_service + ")";
                    break;
                case Enums.OrderLineStatus.Out_For_Service:
                    receive_date_next = receive_date_service_due;
                    shipvia_receive_next = shipvia_service_in;
                    receive_from_next = service_vendor_name + " (Service Order# " + ordernumber_purchase + ")";
                    break;
                case Enums.OrderLineStatus.RMA_Receiving:
                    receive_date_next = receive_date_rma_due;
                    shipvia_receive_next = shipvia_rma;
                    receive_from_next = customer_name + " (RMA# " + ordernumber_rma + ")";
                    break;
                case Enums.OrderLineStatus.Vendor_RMA_Packing:
                    ship_date_next = ship_date_vendrma_due;
                    shipvia_next = shipvia_vendrma;
                    ship_to_next = vendor_name + " (VRMA# " + ordernumber_vendrma + ")";
                    break;
            }
        }


        //KT 11-10-2015 - This was never called as base in Sensible code
        //Rather sensible code overwrote this completely
        //therefore I am completely commenting out and replacing with Sensible version.
        //public virtual void CalculateAmounts(ContextRz context)
        //{
        //    total_price = Math.Round(unit_price * quantity, 2);
        //    total_cost = Math.Round(unit_cost * quantity, 2);
        //    gross_profit = total_price - total_cost;

        //    if (Deductions.Initialized)
        //    {
        //        total_deduction = 0;
        //        foreach (profit_deduction d in Deductions.RefsList(context))
        //        {
        //            total_deduction += d.amount;
        //        }
        //    }

        //    if (RMAHas)
        //    {
        //        rma_subtraction = gross_profit;
        //    }
        //    else
        //    {
        //        rma_subtraction = 0;
        //    }

        //    net_profit = gross_profit - (total_deduction + rma_subtraction);

        //    total_price_rma = Math.Round(unit_price_rma * quantity, 2);
        //    total_price_vendrma = Math.Round(unit_price_vendrma * quantity, 2);

        //    total_price_exchanged = Math.Round(unit_price_exchanged * quantity, 2);
        //    total_cost_exchanged = Math.Round(unit_cost_exchanged * quantity, 2);

        //    total_price_rma_exchanged = Math.Round(unit_price_rma_exchanged * quantity, 2);
        //    total_price_vendrma_exchanged = Math.Round(unit_price_vendrma_exchanged * quantity, 2);

        //    CalculateServiceAmount(context);
        //}


        public void CalculateAmounts(Rz5.ContextRz context)
        {

            ////KT - 1-12-2015 - The "2" in the overload below was causing rounding issues. Pushed it out ot 6, which fixed it (re: PO# 3128571)
            //total_price = Math.Round(unit_price * quantity, 2);
            //total_cost = Math.Round(unit_cost * quantity, 2);         
            total_price = unit_price * quantity;
            total_price = Tools.Number.CommonSensibleRounding(total_price);
            total_cost = Tools.Number.CommonSensibleRounding(unit_cost * quantity);
            gross_profit = Tools.Number.CommonSensibleRounding(total_price - total_cost);

            //KT Added this after discussing with FT, we've never addresses scraps, and they were holding their GP, throwing off Commission Report
            //We agree this should be the simplest way to deal with it.
            if (status == OrderLineStatus.Scrapped.ToString() || status == OrderLineStatus.Quarantined.ToString())
            {
                gross_profit = 0;
                gross_profitVar.Value = Convert.ToDouble(0);
            }



            total_deduction = 0;
            //KT In trying to update deductions, this RefsList isn't getting refreshed when adding from frmdeductions.
            //How can I refresh this.
            //Deductions.UpdateAll(NMWin.ContextDefault);

            foreach (Rz5.profit_deduction d in DeductionsVar.RefsList(context))
            {
                if (!d.is_payroll_deduction)
                    total_deduction += d.amount;
            }
            //KT - This was setting rma_subtraction to Gross Profit by virtue of there being an RMA associated, even if it was void.
            //if (RMAHas)
            if (was_rma)
                rma_subtraction = gross_profit;
            else
                rma_subtraction = 0;


            //KT 9-21-07 Also, since rma_subtraction is already in gross profit, isn't this taking it out again?  SHouldn't it be:  net_profit = gross_profit - total_deduction ;
            net_profit = Tools.Number.CommonSensibleRounding(gross_profit - (total_deduction + rma_subtraction));
            //total_price_rma = Math.Round(unit_price_rma * quantity, 2);
            //total_price_vendrma = Math.Round(unit_price_vendrma * quantity, 2);
            total_price_rma = Tools.Number.CommonSensibleRounding(unit_price_rma * quantity);
            total_price_vendrma = Tools.Number.CommonSensibleRounding(unit_price_vendrma * quantity);
            if (ServiceLines.Initialized && !charge_service_to_customer)
            {
                Rz5.ordhed_service s = (Rz5.ordhed_service)this.OrderObjectGet(context, Rz5.Enums.OrderType.Service);
                if (s == null)
                    return;
                if (!s.charge_service_to_customer)
                {
                    int lines = 0;
                    Double serv = 0;
                    foreach (Rz5.service_line l in ServiceLines.RefsList(context))
                    {
                        l.CalculateAmounts();
                        serv += l.total_cost;
                        lines++;
                    }

                    if (lines > 0)
                        service_cost = serv;
                }
            }
            //This used to be in line.Updating(x), moving to this method so it only gets called when saving a line and header, not on every update.
            CalculatePackQuantities(context);

        }

        protected override int GridColorCalc(Context x)
        {
            if (status == "")
                return 0;

            switch (Status)
            {
                case Rz5.Enums.OrderLineStatus.Void:
                    return System.Drawing.Color.Gray.ToArgb();
                case Rz5.Enums.OrderLineStatus.Packing:
                    return System.Drawing.Color.SteelBlue.ToArgb();
                case Rz5.Enums.OrderLineStatus.Shipped:
                case Enums.OrderLineStatus.Received:
                case Rz5.Enums.OrderLineStatus.Received_From_Service:
                case Rz5.Enums.OrderLineStatus.Vendor_RMA_Shipped:
                    return System.Drawing.Color.Blue.ToArgb();
                case Rz5.Enums.OrderLineStatus.Hold:
                    return System.Drawing.Color.Red.ToArgb();
                //case Rz4.Enums.OrderLineStatus.Packed:
                //    return System.Drawing.Color.Purple.ToArgb();
                case Rz5.Enums.OrderLineStatus.Buy:
                case Enums.OrderLineStatus.Packing_For_Service:
                case Enums.OrderLineStatus.Out_For_Service:
                    return System.Drawing.Color.Goldenrod.ToArgb();
                case Rz5.Enums.OrderLineStatus.Quarantined:
                case Rz5.Enums.OrderLineStatus.Scrapped:
                    return System.Drawing.Color.Purple.ToArgb();
                default:
                    return System.Drawing.Color.Green.ToArgb();
            }
        }

        public bool Active
        {
            get
            {
                return Status != Enums.OrderLineStatus.Void && Status != Enums.OrderLineStatus.Frozen;
            }
        }

        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;

            switch (args.ActionName.ToLower())
            {
                case "split":
                    {

                        bool isScheduledShip = xrz.Leader.AskYesNo("Would you like to split this line into scheduled shipments?");
                        if (isScheduledShip)
                            // return SplitScheduledShipLines(context);\
                            SplitScheduledShipLines(xrz);
                        else
                            SplitSingleLine(xrz);
                        break;
                    }
                case "duplicatesales":
                    Duplicate(xrz, Enums.OrderType.Sales);
                    break;
                case "duplicatepurchase":
                    Duplicate(xrz, Enums.OrderType.Purchase);
                    break;
                case "duplicateinvoice":
                    Duplicate(xrz, Enums.OrderType.Invoice);
                    break;
                case "duplicateservice":
                    Duplicate(xrz, Enums.OrderType.Service);
                    break;
                case "duplicaterma":
                    Duplicate(xrz, Enums.OrderType.RMA);
                    break;
                case "duplicatevendrma":
                    Duplicate(xrz, Enums.OrderType.VendRMA);
                    break;
                case "cancel":
                    {
                        bool boolContinue = AlertIfLineHasExtraDeductions(xrz);
                        if (!boolContinue)
                            return;
                        string voidReason = xrz.TheLeader.AskForString("Please enter a reason for canceling this line .", "", true);
                        if (string.IsNullOrEmpty(voidReason))
                        {
                            xrz.Leader.Tell("Reason not provided.  Void cancelled.");
                            return;
                        }
                        internalcomment += Environment.NewLine + "Void Reason: " + voidReason;
                        this.Update(xrz);
                        Cancel(xrz, Enums.OrderType.Any);
                        args.Handled = true;
                        break;
                    }

                case "printpartlabel":
                case "printbarcode":
                    PrintBarcodeLabel(xrz);
                    break;
                case "merge":
                    Merge(xrz);
                    break;
                case "in-house":
                    ToggleInHouse(xrz);
                    break;
                case "gcat":
                    SendForGCATService(xrz);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }



        private bool AlertIfLineHasExtraDeductions(ContextRz x)
        {
            bool ret = true;
            string messagePre = "The line you are canceling has a ";
            string messageMid = "";
            string messagePost = ". Would you like to remove the cost?";
            if (this.service_cost > 0)
                messageMid = "service cost";
            else if (this.fullpartnumber.ToLower().Contains("gcat"))
                messageMid = "gcat cost";

            if (!string.IsNullOrEmpty(messageMid))
            {
                //ret = x.Leader.AskYesNo(messagePre + messageMid + messagePost);
                ret = x.Leader.AskYesNo(messagePre + messageMid + ".  Are you sure you want to cancel? The " + messageMid + " will still be carried against Net Profit and will need to be resolved.");
                //x.Leader.Tell(messagePre + messageMid + " which is currently included in this order's profit deductions. Make sure you remediate this before invoicing the customer.");              
                if (ret)
                {
                    if (messageMid == "service cost")
                    {
                        //Remove service cost?
                    }
                    else if (messageMid == "gcat cost")
                    {
                        //Remote Unit cost?
                    }

                }

            }


            return ret;
        }

        private void ToggleInHouse(ContextRz xrz)
        {
            try
            {
                string qcs = null;
                if (string.IsNullOrEmpty(qc_status) || qc_status == SM_Enums.QcStatus.Inbound.ToString())//If Empty, probably line existed before new code, allow to set in-house     
                {
                    qcs = SM_Enums.QcStatus.In_House.ToString();
                    this.receive_date_actual = DateTime.Now;
                }                    
                else if (qc_status == SM_Enums.QcStatus.In_House.ToString())
                {
                    qcs = SM_Enums.QcStatus.Inbound.ToString();
                    this.receive_date_actual = DateTime.MinValue;
                }
                   
                if (!string.IsNullOrEmpty(qcs))
                {
                    qc_status = qcs;
                    Update(xrz);
                    xrz.Leader.Tell(fullpartnumber + " has been marked " + qc_status);
                    SendQcStatusEmail(xrz, qc_status);

                }
            }
            catch (Exception ex)
            {
                xrz.Leader.Error(ex);
            }

        }


        private void SendForGCATService(ContextRz x)
        {
            orddet_line gcatDetail = (orddet_line)x.TheSysRz.TheLineLogic.CreateGCATLine(x, this);

            x.Show(new ShowArgsOrder(x, gcatDetail, OrderType.Sales));
        }


        private void SendQcStatusEmail(ContextRz xrz, string qc_status)
        {
            if (string.IsNullOrEmpty(seller_uid))
                return;
            string so = ordernumber_sales ?? "(No Sale)";

            string subject = fullpartnumber + " from SO# " + so + " is now " + qc_status;
            string body = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("<b>PartNumber: </b>" + fullpartnumber);
            sb.Append("<br />");
            sb.Append("<b>Customer: </b>" + customer_name ?? "No Customer");
            sb.Append("<br />");
            sb.Append("<b>Sale: </b>" + ordernumber_sales ?? "No Sale");
            sb.Append("<br />");
            sb.Append("<b>PO: </b>" + ordernumber_purchase ?? "Unknown");
            sb.Append("<br />");
            sb.Append("<b>Vendor: </b>" + vendor_name ?? "Unknown");
            sb.Append("<br />");
            sb.Append("<b>Current Dock: </b>" + customer_dock_date.ToString("MM/dd/yyyy"));
            sb.Append("<br />");

            body = sb.ToString();


            n_user u = n_user.GetById(xrz, seller_uid);
            if (u == null)
                return;

            List<string> cc = new List<string>() { "ktill@sensiblemicro.com" };
            xrz.TheSysRz.TheEmailLogic.SendGenericEmailMessage(xrz, u.email_address, "receiving_alert@sensiblemicro.com", subject, body, cc);
        }

        public bool Merge(ContextRz context)
        {
            OrderLinkArgs args = new OrderLinkArgs(this);
            args.TheLinkType = Enums.OrderType.Any;

            context.Leader.MergeChoose(context, args);

            if (args.Lines.Count == 0)
                return false;

            bool b = true;
            foreach (OrderLinkLine link in args.Lines)
            {
                if (!Merge(context, link.TheLine))
                    b = false;
            }
            return b;
        }

        bool Merge(ContextRz context, orddet_line line)
        {
            //errors
            if (Tools.Strings.StrCmp(line.unique_id, unique_id))
            {
                context.TheLeader.Tell("A line cannot be merged with itself");
                return false;
            }

            if (line.quantity != quantity)
            {
                context.TheLeader.Tell("Merged lines must have matching quantities");
                return false;
            }

            //if (was_shipped || was_received || put_away || line.was_shipped || line.was_received || line.put_away)
            //{
            //    context.TheLeader.Tell("Lines that have already been shipped or received cannot be merged.");
            //    return false;
            //}

            List<ordhed_new> orders = line.OrdersGet(context);
            foreach (ordhed_new order in orders)
            {
                if (this.OrderHas(order.OrderType))
                {
                    context.TheLeader.Tell("This line is already on an order of type " + order.OrderType.ToString());
                    return false;
                }
            }

            //warnings
            if (!Tools.Strings.StrCmp(line.fullpartnumber, fullpartnumber))
            {
                if (!context.TheLeader.AreYouSure("merge lines with different part numbers"))
                    return false;

                if (line.OrderHas(Enums.OrderType.Purchase) && !OrderHas(Enums.OrderType.Purchase))
                {
                    if (context.TheLeader.AskYesNo("Do you want to make " + line.fullpartnumber + " the number that the vendor will see, and keep " + fullpartnumber + " as the part number"))
                    {
                        this.purchased_as_other = true;
                        this.purchased_as_number = line.fullpartnumber;
                    }
                }
            }

            AbsorbOrderLineInfo(context, line);

            foreach (ordhed_new order in orders)
            {
                order.DetailsVar.RefsRemove(context, line);
                order.DetailsVar.RefsAdd(context, this);
                context.Update(order);
            }

            context.TheDelta.Delete(context, line);
            context.TheDelta.Update(context, this);

            //is this even worth doing?
            //if (OrderHas(Enums.OrderType.Service))
            //{
            //    ordhed_service s = (ordhed_service)OrderObjectGet(context, Enums.OrderType.Service);
            //    if (s != null)
            //        s.CheckShipOrder(context);
            //}

            return true;
        }

        protected virtual void AbsorbOrderLineInfo(ContextRz context, orddet_line l)
        {
            if (unit_price == 0 && l.unit_price > 0)
                unit_price = l.unit_price;

            if (!Tools.Strings.StrExt(customer_uid) && Tools.Strings.StrExt(l.customer_uid))
            {
                customer_uid = l.customer_uid;
                customer_name = l.customer_name;
                customer_contact_uid = l.customer_contact_uid;
                customer_contact_name = l.customer_contact_name;
            }

            if (!Tools.Strings.StrExt(seller_uid) && Tools.Strings.StrExt(l.seller_uid))
            {
                seller_uid = l.seller_uid;
                seller_name = l.seller_name;
            }

            if (unit_cost == 0 && l.unit_cost > 0)
                unit_cost = l.unit_cost;

            if (!Tools.Strings.StrExt(vendor_uid) && Tools.Strings.StrExt(l.vendor_uid))
            {
                vendor_uid = l.vendor_uid;
                vendor_name = l.vendor_name;
                vendor_contact_uid = l.vendor_contact_uid;
                vendor_contact_name = l.vendor_contact_name;
                StockType = Enums.StockType.Buy;
                needs_purchasing = true;
            }

            if (!Tools.Strings.StrExt(buyer_uid) && Tools.Strings.StrExt(l.buyer_uid))
            {
                buyer_uid = l.buyer_uid;
                buyer_name = l.buyer_name;
            }

            //Ship and Receive Dates
            if (!Tools.Dates.DateExists(receive_date_due) && Tools.Dates.DateExists(l.receive_date_due))
                receive_date_due = l.receive_date_due;
            if (!Tools.Dates.DateExists(ship_date_due) && Tools.Dates.DateExists(l.ship_date_due))
                ship_date_due = l.ship_date_due;

            //ShipVia && Shipping Accounts
            if (!Tools.Strings.StrExt(shipvia_invoice) && Tools.Strings.StrExt(l.shipvia_invoice))
                shipvia_invoice = l.shipvia_invoice;
            if (!Tools.Strings.StrExt(shippingaccount_invoice) && Tools.Strings.StrExt(l.shippingaccount_invoice))
                shippingaccount_invoice = l.shippingaccount_invoice;
            if (!Tools.Strings.StrExt(shipvia_purchase) && Tools.Strings.StrExt(l.shipvia_purchase))
                shipvia_purchase = l.shipvia_purchase;
            if (!Tools.Strings.StrExt(shippingaccount_purchase) && Tools.Strings.StrExt(l.shippingaccount_purchase))
                shippingaccount_purchase = l.shippingaccount_purchase;
            if (!Tools.Strings.StrExt(shipvia_rma) && Tools.Strings.StrExt(l.shipvia_rma))
                shipvia_rma = l.shipvia_rma;
            if (!Tools.Strings.StrExt(shippingaccount_rma) && Tools.Strings.StrExt(l.shippingaccount_rma))
                shippingaccount_rma = l.shippingaccount_rma;
            if (!Tools.Strings.StrExt(shipvia_vendrma) && Tools.Strings.StrExt(l.shipvia_vendrma))
                shipvia_vendrma = l.shipvia_vendrma;
            if (!Tools.Strings.StrExt(shippingaccount_vendrma) && Tools.Strings.StrExt(l.shippingaccount_vendrma))
                shippingaccount_vendrma = l.shippingaccount_vendrma;
            if (!Tools.Strings.StrExt(shipvia_service_in) && Tools.Strings.StrExt(l.shipvia_service_in))
                shipvia_service_in = l.shipvia_service_in;
            if (!Tools.Strings.StrExt(shippingaccount_service_in) && Tools.Strings.StrExt(l.shippingaccount_service_in))
                shippingaccount_service_in = l.shippingaccount_service_in;
            if (!Tools.Strings.StrExt(shipvia_service_out) && Tools.Strings.StrExt(l.shipvia_service_out))
                shipvia_service_out = l.shipvia_service_out;
            if (!Tools.Strings.StrExt(shippingaccount_service_out) && Tools.Strings.StrExt(l.shippingaccount_service_out))
                shippingaccount_service_out = l.shippingaccount_service_out;

            //Deductions
            List<profit_deduction> deds = new List<profit_deduction>();
            foreach (profit_deduction d in l.DeductionsVar.RefsList(context))
            {
                deds.Add(d);
            }

            foreach (profit_deduction d in deds)
            {
                l.DeductionsVar.RefsRemove(context, d);
                DeductionsVar.RefsAdd(context, d);
                context.Update(d);
            }

            //Services
            List<service_line> slines = new List<service_line>();
            foreach (service_line s in l.ServiceLines.RefsList(context))
            {
                slines.Add(s);
            }

            foreach (service_line s in slines)
            {
                l.ServiceLines.RefsRemove(context, s);
                ServiceLines.RefsAdd(context, s);
                context.Update(s);
            }

            if (!Tools.Strings.StrExt(service_vendor_uid) && Tools.Strings.StrExt(l.service_vendor_uid))
            {
                service_vendor_uid = l.service_vendor_uid;
                service_vendor_name = l.service_vendor_name;
                service_vendor_contact_uid = l.service_vendor_contact_uid;
                service_vendor_contact_name = l.service_vendor_contact_name;
            }

            if (unit_price_rma == 0 && l.unit_price_rma > 0)
                unit_price_rma = l.unit_price_rma;

            if (unit_price_vendrma == 0 && l.unit_price_vendrma > 0)
                unit_price_vendrma = l.unit_price_vendrma;

            if (!was_received && l.was_received)
                was_received = true;

            if (!was_service_out && l.was_service_out)
                was_service_out = true;

            if (!was_service_in && l.was_service_in)
                was_service_in = true;

            if (!was_shipped && l.was_shipped)
                was_shipped = true;

            if (!was_rma_received && l.was_rma_received)
                was_rma_received = true;

            if (!was_vendrma_shipped && l.was_vendrma_shipped)
                was_vendrma_shipped = true;

            if (l.Status > Status)
                Status = l.Status;
        }

        public bool Cancel(ContextRz context, Enums.OrderType from)
        {
            OrderLineCancelArgs args = new OrderLineCancelArgs(this);
            if (from != Enums.OrderType.Any)
                args.TypesToCancel.Add(from);

            context.Leader.AskForLineCancelArgs(context, args);

            if (args.OperationCanceled)
                return false;

            return Cancel(context, args);
        }

        public bool Cancel(ContextRz context, OrderLineCancelArgs args)
        {
            if (args.TypesToCancel.Contains(Enums.OrderType.Sales) && Tools.Strings.StrExt(inventory_link_uid))
            {
                partrecord p = partrecord.GetById(context, inventory_link_uid);
                if (p != null)
                    p.AllocateUn(context, quantity, "Sales Order " + ordernumber_sales, unique_id);
            }


            //KT - Commented out the below, so that no matter where a line gets cancelled, it gives option to leave comment as to why
            //if (args.TypesToCancel.Contains(Enums.OrderType.Sales))
            ((SysRz5)context.xSys).TheSalesLogic.AddCancelLineToSalesOrder(context, this, args.Comment);
            List<ordhed_new> keep = OrdersGet(context);
            List<ordhed_new> remove = new List<ordhed_new>();
            foreach (ordhed_new ohn in keep)
            {
                if (args.TypesToCancel.Contains(ohn.OrderType))
                    remove.Add(ohn);
            }
            foreach (ordhed_new ohn in remove)
            {
                keep.Remove(ohn);
            }
            if (keep.Count == 0)
            {
                List<ordhed_new> orders = OrdersGet(context);

                if (args.SuppressLineDeletion)
                {
                    foreach (ordhed_new o in orders)
                    {
                        o.DetailsVar.RefsRemove(context, this);
                    }
                }
                else
                    Obliterate(context);

                foreach (ordhed_new n in orders)
                {
                    ItemsInstance hold = n.DetailsVar.RefsGet(context);
                    context.Update(n);
                }
            }
            else
            {
                //remove it from every other order
                foreach (ordhed_new n in remove)
                {
                    if (!keep.Contains(n))
                    {
                        n.DetailsVar.RefsRemove(context, this);
                        context.Update(n);
                    }
                }
                List<Enums.OrderType> keepTypes = new List<Enums.OrderType>();
                foreach (ordhed_new kn in keep)
                {
                    keepTypes.Add(kn.OrderType);
                }
                List<Enums.OrderType> removeTypes = new List<Enums.OrderType>();
                foreach (ordhed_new kn in remove)
                {
                    removeTypes.Add(kn.OrderType);
                }

                if (keep.Count == 1 && keep[0].OrderType == Enums.OrderType.Sales)
                    Status = Enums.OrderLineStatus.Hold;
                //This was causing canceled lines that should have been in hold, to flip to Open instead of staying in HOLD.  Moving to an else condition
                else if (removeTypes.Contains(Enums.OrderType.Invoice) && keepTypes.Contains(Enums.OrderType.Sales))
                    Status = Enums.OrderLineStatus.Open;

                if (keepTypes.Contains(Enums.OrderType.Purchase) && !keepTypes.Contains(Enums.OrderType.Sales) && (Status == Enums.OrderLineStatus.Open || Status == Enums.OrderLineStatus.Packing))
                {
                    if (was_received)
                        Status = Enums.OrderLineStatus.Received;
                    else
                        Status = Enums.OrderLineStatus.Buy;
                }

                if (keepTypes.Contains(Enums.OrderType.Invoice) && removeTypes.Contains(Enums.OrderType.RMA))
                {
                    if (Status == Enums.OrderLineStatus.RMA_Receiving || (Status == Enums.OrderLineStatus.Vendor_RMA_Packing && !VendRMAHas))
                        Status = Enums.OrderLineStatus.Shipped;
                }

                if (keepTypes.Contains(Enums.OrderType.Invoice) && removeTypes.Contains(Enums.OrderType.VendRMA))
                {
                    if (Status == Enums.OrderLineStatus.Vendor_RMA_Packing || (Status == Enums.OrderLineStatus.RMA_Receiving && !RMAHas))
                        Status = Enums.OrderLineStatus.Shipped;
                }

                //if (qc_status != Enums.QcStatus.Final_Inspection.ToString())
                //    qc_status = Enums.QcStatus.Shipped.ToString();


                if (removeTypes.Contains(Enums.OrderType.Purchase))
                {
                    //if we're canceling a line off the PO BUT there is still SO linkage, set line to TBD.
                    if(keepTypes.Contains(Enums.OrderType.Sales))
                    {
                        context.TheSysRz.TheLineLogic.SetLineSourceTBD(context,this);
                    }
                    else
                    {
                        vendor_name = "";
                        vendor_uid = "";
                    }
                    
                    vendor_contact_name = "";
                    vendor_contact_uid = "";
                    //unit_cost = 0;
                }


                if (removeTypes.Contains(Enums.OrderType.RMA))
                {
                    was_rma = false;
                    rma_subtraction = 0;
                }
                if (removeTypes.Contains(Enums.OrderType.VendRMA))
                {
                    was_vendrma = false;
                }


                //IF we're keeping on a PO, but cancelling from an SO, ask user if we want to flip stocktype to stock.
                if (keepTypes.Contains(OrderType.Purchase) && removeTypes.Contains(OrderType.Sales))
                {
                    //See if this line was put away
                    if (put_away)
                    {
                        //Get the partrecord from stock
                        partrecord p = (partrecord)NMWin.ContextDefault.QtO("partrecord", "select * from partrecord where purchase_line_uid = '" + unique_id + "'");
                        if (p != null)
                        {
                            bool changeToStock = NMWin.ContextDefault.Leader.AskYesNo("This line has been canceled from the Sale, but was purchased from a vendor, and is already put into stock.  Would you like to update the partrecord to STOCK at this time?");
                            if (changeToStock)
                            {
                                p.StockType = StockType.Stock;
                                p.Update(NMWin.ContextDefault);
                            }
                        }
                        //If no poartrecord found in stock, return.
                    }
                }


                context.Update(this);
            }
            foreach (ordhed_new ohn in remove)
            {
                if (ohn.OrderType == Enums.OrderType.Purchase)
                {
                    if (ohn.DetailsList(context).Count == 0 && !ohn.isvoid)
                    {
                        if (context.TheLeader.AskYesNo("PO #" + ohn.ordernumber + " has no remaining lines.  Do you want to void it?"))
                        {
                            ohn.isvoid = true;
                            context.Update(ohn);
                        }
                    }
                }
            }
            return true;
        }

        public virtual void IdentityApplyTo(ContextRz context, orddet_line l)  //this is for part info only, not vendor or source info
        {
            l.fullpartnumber = fullpartnumber;
            l.quantity = quantity;
            l.datecode = datecode;
            l.condition = condition;
            l.manufacturer = manufacturer;
            l.description = description;
            l.unit_price = unit_price;
            l.unit_cost = unit_cost;
            l.consignment_code = consignment_code;
            l.receive_date_due = receive_date_due;
            l.quote_line_uid = quote_line_uid;
        }

        public virtual orddet_line Duplicate(ContextRz context, Enums.OrderType type)
        {
            //return null;

            ordhed_new order = null;
            //Create the ordhed_new object
            if (type != OrderType.Any)
            {
                order = (ordhed_new)this.OrderObjectGet(context, type);
                if (order == null)
                {
                    context.TheLeader.Error("The " + RzLogic.GetFriendlyOrderType(type) + " for this line could not be found");
                    return null;
                }
            }

            //Create the new duplicated orddet_line object
            orddet_line ret = orddet_line.New(context);
            context.Insert(ret);

            //Set base object identity
            IdentityApplyTo(context, ret);

            //Itendity apply includes description.  Per JEN, for GCAT Lines, we want no description.
            if (ret.fullpartnumber.ToLower().Contains("gcat"))
                ret.description = "";

            //Ordertype Specific logics
            if (order != null)
                ((VarRefOrderNew<ordhed>)ret.VarGetByName(type.ToString().ToLower())).RefSet(context, order);
            if (type == Enums.OrderType.Sales || type == OrderType.Any)  //any is a work-around for sales when the original line is already off of the order
                ret.Status = Enums.OrderLineStatus.Hold;
            else if (type == Enums.OrderType.Purchase)
                ret.Status = Enums.OrderLineStatus.Buy;

            //For Source TBD Or empty Vendor lines - set new sales date
            SetNewSalesDate(ret);

            //Carry QB Identities
            ret.qb_line_ListID = qb_line_ListID;
            ret.qb_line_subitem_ListID = qb_line_subitem_ListID;
            if (type == OrderType.Sales)
                ret.internal_customer = internal_customer;

            //Carry Split Commission            
            ret.split_commission_ID = split_commission_ID;

            //Carry quality related properties.
            ret.datecode = datecode;
            ret.datecode_purchase = datecode_purchase;
            ret.rohs_info = rohs_info;
            ret.rohs_info_vendor = rohs_info_vendor;

            //Clear the nonconID, as any new lines would need a new inspection.
            ret.nonconid = 0;
            ret.CalculateAmounts(context);
            context.Update(ret);
            return ret;
        }

        public override int LineCodeGet(Enums.OrderType type)
        {
            return Tools.Data.NullFilterIntegerFromIntOrLong(IGet("linecode_" + type.ToString().ToLower()));
        }

        public String ShipViaGet(Enums.OrderType type)
        {
            String t = type.ToString().ToLower();
            if (type == Enums.OrderType.Sales)
                t = "invoice";
            else if (type == Enums.OrderType.Service)
                t = "service_out";
            return Tools.Data.NullFilterString(IGet("shipvia_" + t));
        }

        public String ShippingAccountGet(Enums.OrderType type)
        {
            String t = type.ToString().ToLower();
            if (type == Enums.OrderType.Sales)
                t = "invoice";
            else if (type == Enums.OrderType.Service)
                t = "service_out";
            return Tools.Data.NullFilterString(IGet("shippingaccount_" + t));
        }

        public String TrackingNumberGet(Enums.OrderType type)
        {
            String t = type.ToString().ToLower();
            if (type == Enums.OrderType.Sales)
                t = "invoice";
            else if (type == Enums.OrderType.Service)
                t = "service_out";
            return Tools.Data.NullFilterString(IGet("tracking_" + t));
        }

        public void LineCodeSet(Enums.OrderType type, int lc)
        {
            ISet("linecode_" + type.ToString().ToLower(), lc);
        }

        public void OrderObjectRefresh(ContextRz context, ordhed o)
        {
            ISet("orderid_" + o.OrderType.ToString().ToLower(), o.unique_id);
            ISet("ordernumber_" + o.OrderType.ToString().ToLower(), o.ordernumber);
        }

        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return true;
        }

        public ordhed OrderObjectGet(ContextRz context, Enums.OrderType t)
        {
            try
            {
                return (ordhed)((IVarRefSingle)VarGetByName(t.ToString().ToLower())).RefItemGet(context);
            }
            catch { return null; }
        }

        public void OrderObjectClear(ContextRz context, Enums.OrderType t)
        {
            try
            {
                ((IVarRefSingle)VarGetByName(t.ToString().ToLower())).RefsRemoveAll(context);
            }
            catch { }
        }

        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return false;
        }

        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            if (!(args is ShowArgsOrder))
                return context.xUser.SuperUser;

            ShowArgsOrder o = (ShowArgsOrder)args;
            Enums.OrderType compareType = o.TheOrderType;

            if (OrderHas(Enums.OrderType.Invoice))  //if the line has been invoiced, then invoice restrictions apply, not sales and purchase permissions
            {
                switch (compareType)
                {
                    case Enums.OrderType.Sales:
                    case Enums.OrderType.Purchase:
                        compareType = Enums.OrderType.Invoice;
                        break;
                }
            }

            ordhed header = OrderObjectGet((ContextRz)context, compareType);
            if (header != null)
                return header.CanBeEditedBy(context, args);

            if (context.xUser.CheckPermit(context, "General:Edit:CanEditOrddet-" + compareType.ToString()))
                return true;

            return context.xUser.SuperUser;
        }

        private orddet_line SplitSingleLine(ContextRz context)
        {
            bool cancel = false;
            int i = context.TheLeader.AskForInt32("Enter the quantity to remove from this line and add to the new line", 0, "Split Quantity", ref cancel);
            if (cancel)
                return null;

            if (i == 0)
                return null;

            if (i >= quantity)
            {
                context.TheLeader.Error("Lines can only be split for a quantity less than the total quantity");
                return null;
            }

            return SplitWithInteraction(context, i);
        }

        private void SplitScheduledShipLines(ContextRz x)
        {


            x.Leader.StartPopStatus("Beginning scheduled ship process.");
            List<orddet_line> scheduledLineList = new List<orddet_line>();
            //Get Total Shipments from user
            int totalShipments = x.Leader.AskForInt32("How many total monthly shipments would you like to create?", 0, "Total Monthly Shipments");
            if (totalShipments <= 0)
                throw new Exception("Please enter a valid number of total shipments.");
            x.Leader.Comment("Total Shipments = " + totalShipments);
            int startingQty = this.quantity;
            //Ask user for what quantity per ship, by default, divide the totalshipments % scheduleqty
            int qtyPerShip = x.Leader.AskForInt32("What quantity would you like to set for each shipment?", 0, "Quantity per scheduled line.");
            if (qtyPerShip == 0)
                throw new Exception("Please proide a valid quantity to schedule.");
            x.Leader.Comment("Qty Per Ship = " + qtyPerShip);

            int remainingScheduledQty = qtyPerShip * totalShipments;
            int leftoverQty = startingQty - remainingScheduledQty;
            leftoverQty = Math.Abs(leftoverQty);



            if (leftoverQty != 0)
            {
                bool addRemainderToLastShipment = x.Leader.AskYesNo("Dividing your declared total shipments (" + totalShipments + ") by the quanity you have specified (" + qtyPerShip + ") leaves " + leftoverQty + " unit(s) remaining.  Would you like to add this to the final shipment?");
                if (!addRemainderToLastShipment)
                    throw new Exception("Scheduled ship error.  Qty per ship doesn't divide evently into the total number of shipments, and remaining quantity is not accounted for.  Please manually split / schedule this line.");
                x.Leader.Comment("Remainder will be added to the final scheduled line qty.");

            }
            //else
            //    x.Leader.Comment("Scheduled QTY matches total line Quantity.  No leftover lines to address.");

            //Default ot one month from today
            DateTime scheduleddate = DateTime.Today.AddMonths(1);
            //If we have an intiial dock date use taht instead of today.  Else we'll be getting 1900 year dates.
            if (customer_dock_date_initial > new DateTime(1900, 02, 02))
                customer_dock_date_initial.AddMonths(1);
            //Not user zero based index for better user understanding
            for (int i = 1; i < totalShipments; i++)
            {
                //Remember we are always splitting the fist line, therefore if many splits, make sure on the LAST split, to keep the splutQTY on the 1st line and the leftovers on the last line.                
                string strLine = (i).ToString();
                x.Leader.Comment("Scheduling line " + strLine);

                //properties for date_picker             
                Dictionary<string, string> properties = BuildSplitLineProperties();

                //Get the scheduled date for new line from the user.
                scheduleddate = x.Leader.AskForDate("Enter a scheduled date", scheduleddate, properties);
                if (scheduleddate == null)
                    throw new Exception("Invalid scheduled date.");

                //Create a new Split line.
                orddet_line l = new orddet_line();
                if (i != totalShipments - 1)//One before total shipments will create the final line
                    l = Split(x, qtyPerShip, scheduleddate);
                else if (quantity != qtyPerShip)
                    l = Split(x, qtyPerShip);

                //Iterate the scheduled date, assuming 1 month in future which is usuall true.           
                scheduleddate = scheduleddate.AddMonths(1);
                x.Leader.Comment("Scheduled QTY matches total line Quantity.  No leftover lines to address.");
                x.Leader.Comment("Successfully scheduling line for" + scheduleddate.ToShortDateString());
                scheduledLineList.Add(l);

            }


            x.Leader.Comment("Finshed scheduled ship process." + scheduledLineList.Count + " lines scheduled.");
            x.Leader.StopPopStatus(true);
            //return ret;
        }

        private Dictionary<string, string> BuildSplitLineProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            string caption = " (Line " + linecode_sales.ToString() + ")";
            properties.Add("fullpartnumber", fullpartnumber);
            properties.Add("quantity", quantity.ToString());
            properties.Add("linecode_sales", linecode_sales.ToString());
            return properties;
        }

        public virtual orddet_line SplitWithInteraction(ContextRz context, int split_qty)
        {
            return Split(context, split_qty);
        }

        public virtual orddet_line Split(ContextRz context, int split_qty, DateTime? scheduledDate = null, bool isRMA = false)
        {
            if (split_qty <= 0)
            {
                context.TheLeader.Error("Split is not an option for zero or negative quantities");
                return null;
            }
            if (split_qty >= quantity)
            {
                context.TheLeader.Error("Split is not an option for the total or higher than the total quantity");
                return null;
            }
            if (!CheckAllPacks(context))
                return null;
            //The New Line that is split off from the existing
            orddet_line newLine = (orddet_line)CloneValues(context);
            newLine.ordernumber_sales = "";
            newLine.orderid_sales = "";
            newLine.linecode_sales = 0;

            if (scheduledDate != null)
            {
                context.TheSysRz.TheLineLogic.SetInitialLineDockDates(newLine, (DateTime)scheduledDate);
            }




            newLine.ordernumber_purchase = "";
            newLine.orderid_purchase = "";
            newLine.linecode_purchase = 0;

            newLine.ordernumber_invoice = "";
            newLine.orderid_invoice = "";
            newLine.linecode_invoice = 0;

            newLine.ordernumber_rma = "";
            newLine.orderid_rma = "";
            newLine.linecode_rma = 0;

            newLine.ordernumber_vendrma = "";
            newLine.orderid_vendrma = "";
            newLine.linecode_vendrma = 0;

            newLine.ordernumber_service = "";
            newLine.orderid_service = "";
            newLine.linecode_service = 0;

            if (!Tools.Strings.StrExt(line_group_id))
                line_group_id = Tools.Strings.GetNewID();


            newLine.line_group_id = line_group_id;

            //Customer Internal
            if (!string.IsNullOrEmpty(orderid_sales))
                newLine.internal_customer = internal_customer;


            //Varry over QB Identifiers for item, subitem
            newLine.qb_line_ListID = qb_line_ListID;
            newLine.qb_line_subitem_ListID = qb_line_subitem_ListID;
            newLine.internal_customer = internal_customer;

            //CloneValues automatically clones qb_line_TxnID, this needs to be un-set
            newLine.qb_line_TxnID = string.Empty;
            newLine.qb_line_TxnID_purchase = string.Empty;

            //List Acquisition Agent
            newLine.list_acquisition_agent = list_acquisition_agent;
            newLine.list_acquisition_agent_uid = list_acquisition_agent_uid;

            //KT Set the new qtys,but use variables. Due to Rz Change Cache, if the Allocations fail, it will still decrement qTY in the ui, and if the user saves, those get written to db.
            int existingLineQty = this.quantity - split_qty;
            int newLineQty = split_qty;


            //KT Don't carry service cost
            newLine.service_cost = 0;


            //Commit the new Line
            context.Insert(newLine);

            //newLine contains the original line values, this. is the split line.  I.e. if we split off 1 unit off a 10 unit line:
            //that 1 unit line becomes "this", and the 9 pcs becomes newLine



            //Split Partrecords if not an RMA
            if (!string.IsNullOrEmpty(this.inventory_link_uid) && !isRMA)
                CheckSplitPartrecords(context, newLine, split_qty);
            //Split any packs
            //CheckAllocation(context, newLine);
            SplitAllPacks(context, this, newLine);

            //KT if we have succeffully allocated and split, then time to update the original line values.
            newLine.quantity = split_qty;
            this.quantity = existingLineQty;

            if (this.quantity_unpacked > 0)
            {
                //this.quantity_unpacked -= split_qty;
                //newLine.quantity_unpacked = split_qty;
                this.quantity_unpackedVar.Value = this.quantity_unpacked - split_qty;
                newLine.quantity_unpackedVar.Value = split_qty;
            }
            if (this.quantity_unpacked_service > 0)
            {
                this.quantity_unpacked_serviceVar.Value = quantity_unpacked_service - split_qty;
                newLine.quantity_unpacked_serviceVar.Value = split_qty;
                //this.quantity_unpacked_service -= split_qty;
                //newLine.quantity_unpacked_service = split_qty;
            }
            if (this.quantity_packed > 0)
            {
                this.quantity_packedVar.Value = quantity_packed - split_qty;
                newLine.quantity_packedVar.Value = split_qty;
                //this.quantity_packed -= split_qty;
                //newLine.quantity_packed = split_qty;
            }


            //Since moving calculate all amounts from Updating, this is necessary to recalc on split.
            this.CalculateAmounts(context);
            newLine.CalculateAmounts(context);
            context.TheDelta.Update(context, this);
            context.TheDelta.Update(context, newLine);

            //KT 11-13-2015 - I can't think of a scenario where we'd ever want to duplicate the deductions when we split
            //CheckDeductions(context, ret);
            List<ordhed_new> orders = OrdersGet(context);
            foreach (ordhed_new n in orders)
            {
                n.DetailsVar.RefsAdd(context, newLine);
                context.Update(n);
                ordhed_new referenced = (ordhed_new)newLine.OrderObjectGet(context, n.OrderType);
                if (referenced != n)
                {
                    ;
                }
                //For Source TBD Or empty Vendor lines - set new sales date
                SetNewSalesDate(newLine);
            }


            newLine.nonconid = 0;
            newLine.Status = Status;
            newLine.CustomerVar.RefSet(context, CustomerVar.RefGet(context));
            newLine.CustomerContactVar.RefSet(context, CustomerContactVar.RefGet(context));
            newLine.VendorVar.RefSet(context, VendorVar.RefGet(context));
            newLine.VendorContactVar.RefSet(context, VendorContactVar.RefGet(context));
            newLine.SellerVar.RefSet(context, SellerVar.RefGet(context));
            newLine.BuyerVar.RefSet(context, BuyerVar.RefGet(context));


            return newLine;
        }

        private void CheckSplitPartrecords(ContextRz x, orddet_line newLine, int split_qty)
        {
            //Grab the currently assocated partrecord.
            partrecord existingPartrecord = partrecord.GetById(x, this.inventory_link_uid);
            if (existingPartrecord == null)
            {
                if (!x.Leader.AskYesNo("This line is linked to a partrecord, but no partrecord can be found.  Has it been shipped?  If you're not sure click no."))
                    //throw new Exception("This line is linked to a partrecord via inventory_link_uid: " + this.inventory_link_uid + ", yet no part can be found in stock that matches that ID.");

                    return;
            }
            else
            {
                partrecord newPart = SplitRelatedStockPart(x, newLine, existingPartrecord, split_qty);

                //Set the new part QTY to match the split line's qty
                newPart.quantity = split_qty;
                //Allocation will happen later.  This needs to be 0, since clone keeps at original allocation qty, and allocation method deploys +=
                newPart.quantityallocated = 0;
                x.Insert(newPart);
                //Udpate the split line with the partrecord linkage to the new part.   
                newLine.quantity = Convert.ToInt32(newPart.quantity);
                newLine.inventory_link_uid = newPart.unique_id;
                newLine.Update(x);
                //Allocate the new part.
                newPart.Allocate(x, newLine.quantity, "Sales Order " + newLine.ordernumber_sales, newLine.unique_id);
            }





        }

        private partrecord SplitRelatedStockPart(ContextRz x, orddet_line newLine, partrecord existingPartrecord, int split_qty)
        {
            //decrement the original line qty.
            existingPartrecord.quantity -= split_qty;
            //Since qty split has already happened, need to re-combine the qty to match the allocated qty. 
            long originalqty = this.quantity;
            //Unallocate the existing line.
            existingPartrecord.AllocateUn(x, originalqty, "Sales Order " + this.ordernumber_sales, unique_id);
            //re-allocate it with the new QTY
            existingPartrecord.Allocate(x, this.quantity - split_qty, "Sales Order " + this.ordernumber_sales, unique_id);
            //Create the new Part     
            return (partrecord)existingPartrecord.CloneValues(x);
        }

        private void SplitAllPacks(ContextRz context, orddet_line existingLine, orddet_line newLine)
        {
            //Since things can get deleted, etc, let's refresh the qty_unpacked whenever we split a lint, instead
            //of relying on +=, etc.  Just get a fresh, current qty count            

            foreach (Rz5.pack p in this.PacksInVar.RefsList(context))
            {
                pack newPack = p.Split(context, newLine.quantity);
                p.Update(context);
                newLine.PacksInVar.RefsAdd(context, newPack);
            }

            foreach (Rz5.pack p in this.PacksOutVar.RefsList(context))
            {
                pack newPack = p.Split(context, newLine.quantity);
                p.Update(context);
                newLine.PacksOutVar.RefsAdd(context, newPack);
            }
        }

        private void SetNewSalesDate(orddet_line ret)
        {
            if (vendor_uid == "b69d82053406485a9422059cd0a764bd" || vendor_name.ToLower().Contains("source tbd") || string.IsNullOrEmpty(vendor_uid))
                ret.orderdate_sales = DateTime.Now;
        }

        protected virtual bool PackCheckAlt(ContextRz context, int pack_quantity_check, String verb, String order_caption, VarRefPacks packvar)
        {
            if (packvar.RefsGet(context).Count > 1)
            {
                context.TheLeader.Error("This line has been " + verb + "ed from more than 1 inventory location, and can't be split.  Remove the " + verb + "ing entries before continuing.");
                return false;
            }
            //KT Not sure what this is for.  Seems unnecessary, if there is an unpacked quantity, and that's less than the total, throw an error?  how does this help.
            //if (pack_quantity_check > 0 && pack_quantity_check < quantity)
            //{
            //    context.TheLeader.Error("This line has been partially " + verb + "ed on " + order_caption + " and can't be split.  Completely " + verb + " it or remove the " + verb + "ing entries before continuing.");
            //    return false;
            //}
            return true;
        }

        public void PackGrabAlt(ContextRz context, VarRefPacks fromPacks, VarRefPacks toPacks)
        {
            pack f = (pack)fromPacks.RefsGet(context).FirstGet(context);
            if (f == null)
                return;
            pack s = f.Split(context, this.quantity);
            //s.Insert(context);
            toPacks.RefsAdd(context, s);
            //s.Update(context);
            //f.Update(context);
            s.m_ThePart = null;
            f.m_ThePart = null;
        }

        protected virtual void GrabAllPacksAlt(ContextRz context, ref orddet_line ret)
        {
            if (ret == null)
                return;
            if (PackCheckAlt(context, quantity_unpacked, "un-pack", "Purchase Order " + ordernumber_purchase, PacksInVar))
                ret.PackGrabAlt(context, PacksInVar, ret.PacksInVar);
            if (PackCheckAlt(context, quantity_packed, "pack", "Invoice " + ordernumber_invoice, PacksOutVar))
                ret.PackGrabAlt(context, PacksOutVar, ret.PacksOutVar);
            if (PackCheckAlt(context, quantity_packed_service, "pack", "Service Order " + ordernumber_service, PacksOutServiceVar))
                ret.PackGrabAlt(context, PacksOutServiceVar, ret.PacksOutServiceVar);
            if (PackCheckAlt(context, quantity_unpacked_service, "un-pack", "Service Order " + ordernumber_service, PacksInServiceVar))
                ret.PackGrabAlt(context, PacksInServiceVar, ret.PacksInServiceVar);
            if (PackCheckAlt(context, quantity_unpacked_rma, "un-pack", "RMA " + ordernumber_rma, PacksRMAVar))
                ret.PackGrabAlt(context, PacksRMAVar, ret.PacksRMAVar);
            if (PackCheckAlt(context, quantity_packed_vendrma, "pack", "Vendor RMA " + ordernumber_invoice, PacksVendRMAVar))
                ret.PackGrabAlt(context, PacksVendRMAVar, ret.PacksVendRMAVar);
            context.Update(ret);
        }

        //public virtual void ClearAfterSplit()
        //{
        //    quantity_packed = 0;
        //    quantity_packed_service = 0;
        //    quantity_packed_vendrma = 0;
        //    quantity_unpacked = 0;
        //    quantity_unpacked_rma = 0;
        //    quantity_unpacked_service = 0;
        //    service_cost = 0;
        //}

        protected virtual bool CheckAllPacks(ContextRz context)
        {
            if (!PackCheck(context, quantity_unpacked, "un-pack", "Purchase Order " + ordernumber_purchase, PacksInVar))
                return false;
            if (!PackCheck(context, quantity_packed, "pack", "Invoice " + ordernumber_invoice, PacksOutVar))
                return false;
            if (!PackCheck(context, quantity_packed_service, "pack", "Service Order " + ordernumber_service, PacksOutServiceVar))
                return false;
            if (!PackCheck(context, quantity_unpacked_service, "un-pack", "Service Order " + ordernumber_service, PacksInServiceVar))
                return false;
            if (!PackCheck(context, quantity_unpacked_rma, "un-pack", "RMA " + ordernumber_rma, PacksRMAVar))
                return false;
            if (!PackCheck(context, quantity_packed_vendrma, "pack", "Vendor RMA " + ordernumber_invoice, PacksVendRMAVar))
                return false;
            return true;
        }

        protected virtual void GrabAllPacks(ContextRz context, ref orddet_line ret)
        {
            if (ret == null)
                return;
            ret.PackGrab(context, PacksInVar, ret.PacksInVar);
            ret.PackGrab(context, PacksOutVar, ret.PacksOutVar);
            ret.PackGrab(context, PacksOutServiceVar, ret.PacksOutServiceVar);
            ret.PackGrab(context, PacksInServiceVar, ret.PacksInServiceVar);
            ret.PackGrab(context, PacksRMAVar, ret.PacksRMAVar);
            ret.PackGrab(context, PacksVendRMAVar, ret.PacksVendRMAVar);
            context.Update(ret);
        }

        public virtual void CheckPacks(ContextRz context, orddet_line l)
        {
            //KT 11-10-2015 - This was empty, refactored from RzSensible
            if (l == null)
                return;
            if (this.quantity_unpacked > 0)
            {
                foreach (Rz5.pack p in this.PacksInVar.RefsList(context))
                {
                    p.quantity = this.quantity;
                    if (!Tools.Strings.StrExt(p.unique_id))
                        p.Insert(context);
                    else
                        p.Update(context);
                }
                this.quantity_unpacked = this.quantity;
                //KT - Removing this, is this what's setting the qty packed on the unpacked lines to full qty?
                //l.quantity_unpacked = l.quantity;
                Rz5.pack pp = l.PacksInVar.RefAddNew(context);
                pp.quantity = l.quantity_unpacked;
                if (!Tools.Strings.StrExt(pp.unique_id))
                    pp.Insert(context);
                else
                    pp.Update(context);
                if (!Tools.Strings.StrExt(l.unique_id))
                    l.Insert(context);
                else
                    l.Update(context);
            }
            if (this.quantity_packed > 0)
            {
                foreach (Rz5.pack p in this.PacksOutVar.RefsList(context))
                {
                    p.quantity = this.quantity;
                    if (!Tools.Strings.StrExt(p.unique_id))
                        p.Insert(context);
                    else
                        p.Update(context);
                }
                this.quantity_unpacked = this.quantity;
                l.quantity_packed = l.quantity;
                Rz5.pack pp = l.PacksOutVar.RefAddNew(context);
                pp.quantity = l.quantity_packed;
                if (!Tools.Strings.StrExt(pp.unique_id))
                    pp.Insert(context);
                else
                    pp.Update(context);
                if (!Tools.Strings.StrExt(l.unique_id))
                    l.Insert(context);
                else
                    l.Update(context);
            }
        }

        //private void CheckAllocation(ContextRz context, orddet_line l)
        //{
        //    if (l == null)
        //        return;
        //    if (!Tools.Strings.StrExt(inventory_link_uid))
        //        return;
        //    string r = "Sales Order " + ordernumber_sales;
        //    partrecord pr = partrecord.GetById(context, inventory_link_uid);
        //    if (pr == null)
        //        return;
        //    if (pr.Allocations.Count > 0)
        //    {
        //        pr.AllocateUn(context, l.quantity + quantity, r, unique_id);
        //        pr.Allocate(context, quantity, r, unique_id);
        //        pr.Allocate(context, l.quantity, r, l.unique_id);
        //    }
        //}

        private void CheckDeductions(ContextRz context, orddet_line l)
        {
            if (l == null)
                return;
            if (this.DeductionsVar.CountGet(context) <= 0)
                return;
            ArrayList a = new ArrayList();
            List<IItem> lst = this.DeductionsVar.RefsGetAsItems(context).AllGet(context);
            foreach (IItem i in lst)
            {
                if (i == null)
                    continue;
                profit_deduction p = (profit_deduction)i;
                profit_deduction pp = l.DeductionsVar.RefAddNew(context);
                pp.name = p.name;
                pp.amount = p.amount;
                pp.Update(context);
            }
            this.DeductionsVar.RefsRemoveAll(context);
        }

        private bool PackCheck(ContextRz context, int pack_quantity_check, String verb, String order_caption, VarRefPacks packvar)   //quantity_packed, "pack", "Invoice " + ordernumber_invoice, PacksOutVar
        {
            //are these needed?

            //if (packvar.RefsGet(context).Count > 1)
            //{
            //    context.TheLeader.Error("This line has been " + verb + "ed from more than 1 inventory location, and can't be split.  Remove the " + verb + "ing entries before continuing.");
            //    return false;
            //}

            //if (pack_quantity_check > 0 && pack_quantity_check < quantity)
            //{
            //    context.TheLeader.Error("This line has been partially " + verb + "ed on " + order_caption + " and can't be split.  Completely " + verb + " it or remove the " + verb + "ing entries before continuing.");
            //    return false;
            //}

            return true;
        }
        public void PackGrab(ContextRz context, VarRefPacks fromPacks, VarRefPacks toPacks)
        {
            //this is a good idea but it needs work; it should only grab away like this if the line is fully packed, not on partial shipments or receives
            //pack f = (pack)fromPacks.RefsGet(context).FirstGet(context);
            //if (f == null)
            //    return;

            //pack s = f.Split(context, this.quantity);
            //s.ISave();
            //toPacks.RefsAdd(context, s);
            //s.IUpdate();
            //f.IUpdate();
        }

        public List<ordhed_new> OrdersGet(ContextRz context)
        {
            List<ordhed_new> ret = new List<ordhed_new>();

            ordhed_new x = (ordhed_new)SalesVar.RefGet(context);
            if (x != null)
            {
                ret.Add(x);

                //ordhed_new y = (ordhed_new)context.TheLeader.ItemShownByTag(context, new ItemTag("ordhed_sales", x.unique_id));
                //if (y != null)
                //{
                //    if (x == y)
                //    {
                //        ;
                //    }
                //    else
                //    {
                //        ;
                //    }
                //}
            }

            x = (ordhed_new)PurchaseVar.RefGet(context);
            if (x != null)
                ret.Add(x);

            x = (ordhed_new)ServiceVar.RefGet(context);
            if (x != null)
                ret.Add(x);

            x = (ordhed_new)InvoiceVar.RefGet(context);
            if (x != null)
                ret.Add(x);

            x = (ordhed_new)RMAVar.RefGet(context);
            if (x != null)
                ret.Add(x);

            x = (ordhed_new)VendRMAVar.RefGet(context);
            if (x != null)
                ret.Add(x);

            return ret;
        }

        //public bool Closeable(ContextRz context, OrderType orderType, CloseType closeType, out PossibleArgs args)
        //{
        //    return Closeable(context, orderType, closeType, out args);
        //}

        public virtual bool Closeable(ContextRz context, OrderType orderType, CloseType closeType, PossibleArgs args)
        {

            //if (status.ToLower().Contains("shipped"))
            //    return false;
            //args = new PossibleArgs();
            args.Possible = true;//True until determined false below.
            string strLineCode = "Line " + LineCodeGet(orderType).ToString() + ": ";

            if (Closed(context, orderType, closeType))
            {
                //args.LogAdd(strLineCode +"Already closed");
                return false;
            }

            if (LineType != Rz5.LineType.Inventory)
                return true;
            long qtyCLosable = QuantityClosable(context, orderType, closeType);
            if (qtyCLosable <= 0)
            {
                args.LogAdd(strLineCode + "Line not packed / no closable quantity");
                return false;
            }

            switch (orderType)
            {
                case OrderType.Invoice:
                    CloseableInvoice(context, args);
                    break;
                case OrderType.Purchase:
                    CloseablePurchase(context, args);
                    break;
                case OrderType.Service:
                    switch (closeType)
                    {
                        case CloseType.Ship:
                            CloseableServiceOut(context, args);
                            break;
                        case CloseType.DropShipServiceReceive:
                        case CloseType.Receive:
                            CloseableServiceIn(context, args);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;
                case OrderType.RMA:
                    CloseableRma(context, args);
                    break;
                case OrderType.VendRMA:
                    CloseableVendRma(context, args);
                    break;
                default:
                    throw new Exception(strLineCode + "Order type " + orderType.ToString() + " not recognized");
            }

            return args.Possible;
        }


        public bool Closed(ContextRz context, OrderType orderType, CloseType closeType)
        {
            switch (orderType)
            {
                case OrderType.Invoice:
                    return was_shipped;
                case OrderType.Purchase:
                    {
                        return was_received || put_away;
                    }

                case OrderType.Service:
                    switch (closeType)
                    {
                        case CloseType.Ship://This includes Drop-shipped VendRMA's
                            return was_service_out;
                        case CloseType.Receive:
                            return was_service_in;
                        case CloseType.DropShipServiceReceive:
                            {
                                if (Status == OrderLineStatus.Received_From_Service)
                                    return true;
                            }
                            return false;
                        default:
                            throw new NotImplementedException();
                    }
                case OrderType.RMA:
                    return was_rma_received;
                case OrderType.VendRMA:
                    return was_vendrma_shipped;
                case OrderType.Sales:
                    {
                        List<string> closedSalesLineStatus = new List<string>() { "open", "buy", "out for service" };
                        return !closedSalesLineStatus.Contains(status);
                    }

                default:
                    throw new Exception("Order type " + orderType.ToString() + " not recognized");
            }
        }

        public virtual int QuantityClosable(ContextRz context, OrderType orderType, CloseType closeType)
        {
            switch (orderType)
            {
                case OrderType.Invoice:
                    return quantity_packed;
                case OrderType.Purchase:
                    switch (closeType)
                    {
                        case CloseType.DropShipServiceReceive:
                            return quantity_unpacked_service;
                        case CloseType.DropShipVendorRma:
                            return quantity;
                        default:
                            return quantity_unpacked;
                    }

                case OrderType.Service:
                    switch (closeType)
                    {
                        case CloseType.Ship:
                            //return quantity_packed_service;
                            {
                                if (quantity_packed_service == 0)
                                {
                                    quantity_packed_service = quantity;
                                    //this.Update(context);
                                }
                                return quantity_packed_service;
                            }
                        case CloseType.DropShipServiceReceive:
                        case CloseType.Receive:
                            return quantity_unpacked_service;
                        default:
                            throw new NotImplementedException();
                    }
                case OrderType.RMA:
                    return quantity_unpacked_rma;
                case OrderType.VendRMA:
                    return quantity_packed_vendrma;
                default:
                    throw new NotImplementedException();
            }
        }

        public bool OpenAndFilled(ContextRz context, OrderType orderType, CloseType closeType)
        {
            if (Closed(context, orderType, closeType))
                return false;

            if (LineType != Rz5.LineType.Inventory)
                return true;

            if (orderType == OrderType.Service && closeType == CloseType.Receive)
            {
                if (!was_service_out)
                    return false;
            }
            if (orderType == OrderType.Service && closeType == CloseType.Ship)
            {
                return true;//Allow shipping of multiple lines on a Service Order, where only 1 pack will exist.
            }
            if (orderType == OrderType.Purchase)
            {
                if (closeType == CloseType.DropShipVendorRma)
                    return true;
                List<Enums.OrderLineStatus> ClosablePoStatusList = new List<OrderLineStatus>() { OrderLineStatus.Buy, OrderLineStatus.PreInvoiced };
                if (!ClosablePoStatusList.Contains(Status))
                {
                    //This Overrides status when status is not a valid closable type
                    if (closeType != CloseType.DropShipServiceReceive)
                        return false;
                }




            }


            //if (status.ToLower().Contains("shipped"))//So we don't re-put away lines that have already shipped.
            //    return false;

            return (QuantityClosable(context, orderType, closeType) > 0);
        }

        public bool OpenAndEmpty(ContextRz context, OrderType orderType, CloseType closeType)
        {
            if (Closed(context, orderType, closeType))
                return false;

            if (LineType != Rz5.LineType.Inventory)
                return false;  //services are always already filled

            return (QuantityClosable(context, orderType, closeType) <= 0);
        }

        public Double CloseValue(OrderType orderType, CloseType closeType)
        {
            switch (orderType)
            {
                case OrderType.Purchase:
                    return total_cost;
                case OrderType.Sales:
                case OrderType.Invoice:
                    return total_price;
                case OrderType.Service:
                    switch (closeType)
                    {
                        case CloseType.Ship:
                            return service_cost;
                        case CloseType.DropShipServiceReceive:
                        case CloseType.Receive:
                            return 0;
                        default:
                            throw new NotImplementedException();
                    }
                case OrderType.RMA:
                    return total_price_rma;
                case OrderType.VendRMA:
                    return total_price_vendrma;
                default:
                    throw new NotImplementedException();
            }
        }

        public void PrepareForShipping(ContextRz context, OrderType type)
        {
            //anything in common here like drop-ships, etc

            //then anything company specific
            PrepareForShippingInventory(context, type);
        }

        protected virtual void PrepareForShippingInventory(ContextRz context, OrderType type)
        {
            switch (type)
            {
                case OrderType.Invoice:
                    PreparePacksForShipping(context, OrderType.Sales, PacksOutVar);
                    //PreparePacksForShipping(context, type, PacksOutVar);
                    break;
                case OrderType.Service:
                    PreparePacksForShipping(context, type, PacksOutServiceVar);
                    break;
                case OrderType.VendRMA:
                    PreparePacksForShipping(context, type, PacksVendRMAVar);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        protected virtual void PreparePacksForShipping(ContextRz context, OrderType type, VarRefPacks packs)
        {
            foreach (pack p in packs.RefsList(context))
            {
                p.PrepareInventoryForShipping(context, this, type);
            }
        }

        public void CloseInTrans(ContextRz context, OrderType orderType, CloseType closeType, bool throwTestError)
        {
            //This will put the line into inventory
            if (LineType == Rz5.LineType.Inventory)
                CloseInTransInventory(context, orderType, closeType);

            //if (throwTestError)
            //    throw new Exception("Test error");

            switch (orderType)
            {
                case OrderType.Invoice:
                    CloseInTransInvoice(context);
                    break;
                case OrderType.Purchase:
                    CloseInTransPurchase(context);
                    break;
                case OrderType.Service:
                    switch (closeType)
                    {
                        case CloseType.Ship:
                            CloseInTransServiceOut(context);
                            break;
                        case CloseType.DropShipServiceReceive:
                        case CloseType.Receive:
                            if (context.TheSysRz.TheLineLogic.IsServiceLineEligibleForAutoReceive(context, this))
                            {
                                this.FakeUnPackService(context);
                                this.Status = Enums.OrderLineStatus.Received_From_Service;

                            }
                            else
                                CloseInTransServiceIn(context);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;
                case OrderType.RMA:
                    CloseInTransRma(context);
                    break;
                case OrderType.VendRMA:
                    CloseInTransVendRma(context);
                    break;
                case OrderType.Sales:
                    break;
                default:
                    throw new NotImplementedException();
            }

            Update(context);
        }

        public void PostInTrans(ContextRz context, OrderType orderType)
        {
            switch (orderType)
            {
                case OrderType.Invoice:
                    PostInTransInvoice(context);
                    break;
                case OrderType.Purchase:
                    PostInTransPurchase(context);
                    break;
                case OrderType.Service:
                    //switch(closeType)
                    //{
                    //    case CloseType.Ship:
                    //what else needs to be done here?
                    PostTransServiceOut(context);
                    //        break;
                    //    case CloseType.Receive:
                    //        //is there any financial transaction here?
                    //        break;
                    //    default:
                    //        throw new NotImplementedException();
                    //}
                    break;
                case OrderType.RMA:
                    PostTransRMA(context);
                    break;
                case OrderType.VendRMA:
                    PostTransVendRMA(context);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public virtual void CloseInTransInventory(ContextRz context, OrderType orderType, CloseType closeType)
        {
            switch (orderType)
            {
                case OrderType.Invoice:
                    foreach (pack l in PacksOutVar.RefsList(context))
                    {
                        l.ShipInTrans(context, this, OrderType.Invoice);
                    }
                    break;
                case OrderType.Purchase:
                    if (PacksInVar.RefsList(context).Count == 0 && closeType != CloseType.DropShipServiceReceive)//DropShips are received on the Service order.   In these cases, ignore missing pack (this po is getting closed by the service order upon receive)
                    {
                        if (!context.TheLeader.AreYouSure("put away this line with no packs?"))//Drop Ship VendorRMa, etc.
                            throw new Exception("Receive canceled");
                    }
                    foreach (pack l in PacksInVar.RefsList(context))
                    {
                        //if (!this.status.ToLower().Contains("shipped"))// Some Situations, like re-close, we could have shipped parts, and we are just trying to resolve the order, don't want to put away again.
                        //{
                        //if(context.Leader.AskYesNo("This line does not appear to have been shipped.  Click 'YES' to add it to inventory.  Anything else will proceed without putting into inventory."))
                        //{                        

                        if (!l.put_away)
                        {
                            partrecord p = null;
                            // NEEd to confirm the inventoryLink uid doesn't exist, else duplicate put away!!                      


                            //If an inventory item linked to this line already exists, don't duplicate put away.
                            //This could also mean thes was an excess bid, then we replace the inventiry link tot he excess line, and replace with thie partrecord ID.  Also should probably decrement the excess quantity.
                            if (!string.IsNullOrEmpty(inventory_link_uid))
                            {
                                //if line has invenoty link uid already, implies already put away OR excess
                                //if no partrecord found linked to it, possible partrecord got orphaned/
                                //Alert user, offer to remove linkage.
                                p = (partrecord)context.GetById("partrecord", inventory_link_uid);





                                if (p == null)//Linked part not found in inventory
                                {


                                    //If the line shows shipped, maybe it's already in shipped stock..
                                    if (this.status == OrderLineStatus.Shipped.ToString())
                                    {
                                        shipped_stock ss = (shipped_stock)context.QtO("shipped_stock", "select * from shipped_stock where unique_id = '" + inventory_link_uid + "'");
                                        if (ss != null)//IF we see a shipped stock that matched, then this is shipped, all good here.
                                            return;
                                    }
                                    else if (this.Status == OrderLineStatus.Scrapped)
                                    {
                                        //One reason a linked part may not be in inventory or shipped stock is if it was scrapped.  Quarantines would be handled via VRMA, or eventually a scrap.
                                        return;
                                    }
                                    else
                                    {
                                        //If stock is excess, consign, or has an importid, that import item may have been removed / updated from the vendor
                                        if (stocktype == StockType.Excess.ToString() || stocktype == StockType.Consign.ToString() || !string.IsNullOrEmpty(importid))
                                        {
                                            //This line may be linked to an impor that has been deleted.
                                            throw new Exception("This line was associated wtih an part that is no longer in inventory.  It's possible that part has been replaced with an updated stock list import.  Please open the line from the sales order to re-allocate this line to the correct partrecord.");

                                        }

                                    }

                                }

                                //Check to confirm this linked part is not already in inventory
                                if (p == null)
                                    p = (partrecord)context.GetById("partrecord", inventory_link_uid);

                                //We have located the partrecord associated with the line.  If it's excess, we need to do stuff.
                                if (p != null)
                                {
                                    //Check if Excess
                                    if (p.StockType == StockType.Excess)
                                    {
                                        //If so, remove that linkage, to be replaced with the partrecord generated from teh PutAway.
                                        inventory_link_uid = "";
                                        this.Update(context);
                                        //Next update that Excess part to reflect the subtraction of Quantity
                                        p.quantity -= this.quantity;
                                        p.Update(context);
                                        //Finally put away the line, which creates a new partrecord for the received part and links to line item.
                                        l.PutAwayInTrans(context, this, OrderType.Purchase);
                                    }
                                }
                                else//No Existing conflicting line line present, put away
                                    l.PutAwayInTrans(context, this, OrderType.Purchase);
                            }
                            else//This is where normal buy put_aways will land.
                                l.PutAwayInTrans(context, this, OrderType.Purchase);


                        }
                    }
                    break;
                case OrderType.Service:
                    switch (closeType)
                    {
                        case CloseType.Ship:
                            ShipServiceInTrans(context);
                            break;
                        case CloseType.DropShipServiceReceive:
                            {
                                if (context.TheSysRz.TheLineLogic.IsDropShipServiceVendor(service_vendor_uid))
                                    foreach (pack l in PacksInServiceVar.RefsList(context))
                                    {
                                        //Drop Ship Service Vendors, don't have a part allocated in stock.
                                        //Therefore we need to put the line away in stock as we would a normal purchase.
                                        if (!l.put_away)
                                            l.PutAwayInTrans(context, this, OrderType.Service);

                                    }
                                break;
                            }
                        case CloseType.Receive:
                            {
                                PutAwayServiceInTrans(context);
                                break;
                            }

                        default:
                            throw new NotImplementedException();
                    }
                    break;
                case OrderType.RMA:
                    foreach (pack l in PacksRMAVar.RefsList(context))
                    {

                        l.PutAwayInTrans(context, this, OrderType.RMA);
                    }
                    break;
                case OrderType.VendRMA:
                    {

                        foreach (pack l in PacksVendRMAVar.RefsList(context))
                        {
                            l.ShipInTrans(context, this, OrderType.VendRMA);

                        }
                        //Close related Orders.

                        break;
                    }
                case OrderType.Sales:
                    {
                        break;
                    }

                default:
                    throw new NotImplementedException();
            }
        }





        //public bool ShippableComplete(ContextRz context)
        //{
        //    if (was_shipped)
        //        return false;

        //    if (LineType != Rz5.LineType.Inventory)
        //        return true;

        //    switch (Status)
        //    {
        //        case Rz5.Enums.OrderLineStatus.Packing:
        //        //case Rz4.Enums.OrderLineStatus.Packed:
        //            return quantity > 0 && quantity_packed >= quantity;  //how should we handle over-packs?
        //        default:
        //            return false;
        //    }
        //}

        //public bool ShippablePartial(ContextRz context)
        //{
        //    switch (Status)
        //    {
        //        case Rz5.Enums.OrderLineStatus.Packing:
        //        //case Rz4.Enums.OrderLineStatus.Packed:
        //            return quantity > 0 && quantity_packed > 0 && quantity_packed < quantity;
        //        default:
        //            return false;
        //    }
        //}



        public bool OrderHas(Enums.OrderType type)
        {
            return Tools.Strings.StrExt(OrderNumberGet(type));
        }

        public string OrderNumberGet(Enums.OrderType type)
        {
            return Tools.Data.NullFilterString(IGet("ordernumber_" + type.ToString().ToLower()));
        }

        public string OrderIdGet(Enums.OrderType type)
        {
            return Tools.Data.NullFilterString(IGet("orderid_" + type.ToString().ToLower()));
        }

        public bool QuantityEditableIs
        {
            get
            {
                if (was_received)
                    return false;

                if (was_shipped)
                    return false;

                if (was_service_out)
                    return false;

                if (was_vendrma_shipped)
                    return false;

                if (was_rma_received)
                    return false;

                return true;
            }
        }

        public void Obliterate(ContextRz context)
        {
            foreach (ordhed_new n in OrdersGet(context))
            {
                n.DetailsVar.RefsRemove(context, this);
            }

            context.Delete(this);
        }

        public int PictureCount(ContextRz context)
        {
            String search = "select count(*) from partpicture where the_orddet_uid = '" + this.unique_id + "'";
            return context.Logic.PictureData.GetScalar_Integer(search);
        }


        public ListArgs DeductionArgsGet(ContextRz context)
        {
            ListArgs args = new ListArgs(context);
            args.TheClass = "profit_deduction";
            args.TheTable = "profit_deduction";
            args.TheTemplate = "Profit Deductions";
            args.TheOrder = "date_created";
            args.AddAllow = true;
            args.AddCaption = "Add A Deduction";
            args.LiveItems = DeductionsVar.RefsGetAsItems(context);
            return args;
        }

        public virtual void FakePack(ContextRz context, VarRefPacks var, int fakeQuantity = -1)
        {
            pack p = var.RefAddNew(context);
            p.fullpartnumber = this.fullpartnumber;
            if (fakeQuantity == -1)
                p.quantity = this.quantity;
            else
                p.quantity = fakeQuantity;
            p.pack_complete = true;
            context.TheDelta.Update(context, p);
            partrecord stock = this.LinkedInventory(context);
            if (stock != null)
                p.ThePartSet(context, stock);
            context.TheDelta.Update(context, this);
        }

        public void FakeUnPack(ContextRz context, VarRefPacks var)
        {
            pack p = var.RefAddNew(context);
            p.fullpartnumber = this.fullpartnumber;
            p.quantity = this.quantity;
            p.location = "Test";

            context.TheDelta.Update(context, p);
            context.TheDelta.Update(context, this);
        }

        public OrderLineCancelStatus CancelStatusGet(ContextRz context)
        {
            OrderLineCancelStatus ret = new OrderLineCancelStatus();
            CancelStatusGet(context, ret, SalesVar, was_shipped, "already shipped");
            CancelStatusGet(context, ret, PurchaseVar, was_received, "already received");
            CancelStatusGet(context, ret, ServiceVar, was_service_out, "already sent for service");
            CancelStatusGet(context, ret, InvoiceVar, was_shipped, "already shipped");
            CancelStatusGet(context, ret, RMAVar, was_rma_received, "already RMA received");
            CancelStatusGet(context, ret, VendRMAVar, was_vendrma_shipped, "already Vendor RMA shipped");
            return ret;
        }

        public void CancelStatusGet(ContextRz context, OrderLineCancelStatus s, VarRefOrderNew<ordhed> var, bool not_possible, String reason)
        {
            ordhed_new o = (ordhed_new)var.RefGet(context);
            if (o == null)
            {
                return;
            }
            else
            {
                OrderLineCancelStatusEntry entry = new OrderLineCancelStatusEntry();
                s.Entries.Add(entry);

                entry.TheOrder = o;

                if (not_possible)
                {
                    entry.CancelPossible = false;
                    entry.NotPossibleReason = reason;
                }
                else
                    entry.CancelPossible = true;
            }
        }

        public void ParentOrderTypeSet(ContextRz context, Enums.OrderType t)
        {
            switch (t)
            {
                case Enums.OrderType.Sales:
                case Enums.OrderType.Invoice:
                    if (Status == Enums.OrderLineStatus.Received)
                        Status = Enums.OrderLineStatus.Open;

                    if (was_received)
                    {
                        //allocate the quantity since its being added to a sale
                        foreach (pack p in this.PacksInVar.RefsList(context))
                        {
                            partrecord part = p.ThePartGet(context);
                            if (part != null)
                            {
                                if (part.quantityallocated == 0)
                                {
                                    part.quantityallocated = quantity;
                                    context.TheDelta.Update(context, part);
                                    break;
                                }
                            }
                        }
                    }

                    break;
            }
        }

        public virtual String StatusCaption
        {
            get
            {
                if (Status == Enums.OrderLineStatus.Shipped && needs_post_ship)
                    return "Incompletely Shipped";
                else if (needs_post_put_away)
                    return "Incompletely Put Away";
                else
                    return Status.ToString().Replace("_", " ");
            }
        }

        public partrecord LinkedInventory(ContextRz context)
        {
            if (!Tools.Strings.StrExt(inventory_link_uid))
                return null;

            return partrecord.GetById(context, inventory_link_uid);
        }

        public virtual bool LinkAndAllocate(ContextRz context)
        {
            partrecord p = context.Leader.StockChoose(context, fullpartnumber);
            if (p == null)
            {
                context.Leader.Error("No inventory selected.");
                return false;
            }
           return LinkAndAllocate(context, p);

        }
        public virtual bool LinkAndAllocate(ContextRz context, partrecord p, bool ask_apply = true)
        {


            //if (!context.TheSysRz.ThePartLogic.CanAllocatePartrecord(context, p, quantity))
            //    return false;


            //Inventory Link_uid -safety net
            if (p != null && string.IsNullOrEmpty(inventory_link_uid))
                inventory_link_uid = p.unique_id;
            inventory_link_caption = p.ToString();

            //StockType
            stocktype = p.stocktype;

            //List Acquisition Agent
            list_acquisition_agent = p.list_acquisition_agent;
            list_acquisition_agent_uid = p.list_acquisition_agent_uid;

            lotnumber = p.lotnumber;
            if (ask_apply)
            {
                if (context.TheLeader.AskYesNo("Would you like to apply this selected parts information onto this line item?"))
                {
                    if (Tools.Strings.StrExt(p.datecode))
                        datecode = p.datecode;
                    if (Tools.Strings.StrExt(p.manufacturer))
                        manufacturer = p.manufacturer;
                    if (Tools.Strings.StrExt(p.condition))
                        condition = p.condition;
                    if (Tools.Strings.StrExt(p.packaging))
                        packaging = p.packaging;
                    if (Tools.Strings.StrExt(p.base_company_uid))
                        vendor_uid = p.base_company_uid;
                    if (Tools.Strings.StrExt(p.companyname))
                        vendor_name = p.companyname;
                }
            }
            ApplyAllocateExtra(context, p);
            if (p.StockType == Enums.StockType.Consign)
            {
                if (!Tools.Strings.StrExt(p.base_company_uid))
                {
                    context.TheLeader.Error("This consignment item " + p.ToString() + " is not linked to a supplier and cannot be attached to an order until this is set.");
                    return false;
                }
                vendor_name = p.companyname;
                vendor_uid = p.base_company_uid;
                vendor_contact_name = p.companycontactname;
                vendor_contact_uid = p.base_companycontact_uid;
                //lotnumber = p.consignment_code;
                consignment_code = p.consignment_code;
                ApplyConsignmentCostInfo(context, p, unit_price);
            }
            context.Update(this);
            p.Allocate(context, quantity, "Sales Order " + ordernumber_sales, unique_id);
            return true;

        }



        protected virtual void ApplyAllocateExtra(ContextRz context, partrecord p)
        {
            if (Tools.Strings.StrExt(p.location))
                receive_location = p.location;
        }
        protected virtual bool CheckAllocateLessQtyAndSplit(ContextRz context, partrecord p)
        {
            context.TheLeader.Error("This item does not have enough free quantity to allocate");
            return false;
        }

        //protected virtual bool CheckAllocateLessQtyAndSplit(ContextRz context, partrecord p, int desiredQty)
        //{
        //    //KT This needs to detect when we are allocating less thatn the entire qty
        //    //Then it needs to split the line appropriately, and allocate the line with the matching amount.
        //    //Then the user can allocate the remainign line similarly.
        //    //That said, this doesn't happen if user handles consign properly in the batch, just adding informationals for now
        //    //While I get with Phil so see what difficulties he may be bumping into.
        //    //if (!context.Leader.AskYesNo("It appears you are allocating less quantity than the line requires.  Would you like to split the remaning qty into a new line?"))
        //    //    {
        //    //    context.TheLeader.Error("Cannot allocate qty less than the line requires.  Please split the line, or adjust the needed qty.");
        //    //    return false;
        //    //}
        //    //else
        //    //{
        //    //    Split(context, desiredQty);
        //    //    return true;
        //    //}
        //    if (p.quantity < desiredQty)
        //        context.TheLeader.Error("Cannot allocate qty less than the line requires.  Please split the line, or adjust the needed qty.");
        //    else context.TheLeader.Error("This item does not have enough free quantity to allocate");
        //    return false;
        //}
        //public virtual void ApplyConsignmentCostInfo(ContextRz context, partrecord p)
        //{
        //    //KT 11-10-2015 REfactored from Rz5 - this method existed here, but was empty
        //    Rz5.consignment_code code = Rz5.consignment_code.GetByName(context, p.consignment_code);
        //    if (code != null)
        //        unit_cost = code.CostCalc(p.price);


        //}

        public virtual void ApplyConsignmentCostInfo(ContextRz context, partrecord p, double unit_price)
        {
            //KT 11-10-2015 REfactored from Rz5 - this method existed here, but was empty
            Rz5.consignment_code code = Rz5.consignment_code.GetByName(context, p.consignment_code);
            if (code != null)
                unit_cost = code.CostCalc(unit_price);


        }

        public void PrintBarcodeLabel(ContextRz context)
        {
            context.Leader.PrintBarcodeLabel(context, this);
        }

        public List<ordhed_new> LinkedOrders(ContextRz context)
        {
            List<ordhed_new> ret = new List<ordhed_new>();
            List<ordhed_new> orders = OrdersGet(context);

            ArrayList ids = new ArrayList();

            foreach (ordhed o in orders)
            {
                ArrayList oids = o.LinkedOrderIdsGet(context);
                foreach (String id in oids)
                {
                    if (!ids.Contains(id))
                        ids.Add(id);
                }
            }

            if (ids.Count == 0)
                return ret;

            String ins = Tools.Data.GetIn(ids);
            ArrayList inst = context.QtC("ordhed_sales", "select * from ordhed_sales where unique_id in (" + ins + ") order by orderdate");
            foreach (ordhed_new n in inst)
            {
                ret.Add(n);
            }

            inst = context.QtC("ordhed_purchase", "select * from ordhed_purchase where unique_id in (" + ins + ") order by orderdate");
            foreach (ordhed_new n in inst)
            {
                ret.Add(n);
            }

            inst = context.QtC("ordhed_invoice", "select * from ordhed_invoice where unique_id in (" + ins + ") order by orderdate");
            foreach (ordhed_new n in inst)
            {
                ret.Add(n);
            }

            inst = context.QtC("ordhed_service", "select * from ordhed_service where unique_id in (" + ins + ") order by orderdate");
            foreach (ordhed_new n in inst)
            {
                ret.Add(n);
            }

            inst = context.QtC("ordhed_rma", "select * from ordhed_rma where unique_id in (" + ins + ") order by orderdate");
            foreach (ordhed_new n in inst)
            {
                ret.Add(n);
            }

            inst = context.QtC("ordhed_vendrma", "select * from ordhed_vendrma where unique_id in (" + ins + ") order by orderdate");
            foreach (ordhed_new n in inst)
            {
                ret.Add(n);
            }

            return ret;
        }

        public bool DeductionHas(ContextRz context, String name, Double amount)
        {
            foreach (profit_deduction d in DeductionsVar.RefsList(context))
            {
                if (Tools.Strings.StrCmp(d.name, name) && d.amount == amount)
                    return true;
            }
            return false;
        }

        public void ServiceAgentCheck(ContextRz context)
        {
            ordhed_service s = (ordhed_service)ServiceVar.RefGet(context);
            if (s != null)
            {
                service_agent_name = s.agentname;
                service_agent_uid = s.base_mc_user_uid;
                ordernumber_service = s.ordernumber;
                context.Update(this);
            }
        }

        public bool VoidPossible(ContextRz context, Enums.OrderType type, StringBuilder sb)
        {
            bool ret = true;
            if (type == Enums.OrderType.Invoice && was_shipped)
            {
                sb.AppendLine(ToString() + " has already shipped");
                ret = false;
            }

            if (type == Enums.OrderType.Purchase && was_received)
            {
                sb.AppendLine(ToString() + " has already received");
                ret = false;
            }

            if (type == Enums.OrderType.Service && was_service_out)
            {
                sb.AppendLine(ToString() + " has already shipped to service");
                ret = false;
            }

            if (type == Enums.OrderType.Service && was_service_in)
            {
                sb.AppendLine(ToString() + " has already come back from service");
                ret = false;
            }

            if (type == Enums.OrderType.RMA && was_rma_received)
            {
                sb.AppendLine(ToString() + " has already been RMA received");
                ret = false;
            }

            if (type == Enums.OrderType.VendRMA && was_vendrma_shipped)
            {
                sb.AppendLine(ToString() + " has already been VRMA shipped");
                ret = false;
            }

            return ret;
        }

        public virtual String DescriptionForPrint(ContextRz context, Enums.OrderType type, String templateName)
        {
            return description;
        }

        public virtual void DetailSummedWith(ContextRz context, orddet_line line, Enums.OrderType type)
        {

        }

        public override void CompanyRefSet(ContextRz context, company companyObject, Enums.OrderType t)
        {
            switch (t)
            {
                case Enums.OrderType.Sales:
                case Enums.OrderType.Invoice:
                case Enums.OrderType.RMA:
                    CustomerVar.RefSet(context, companyObject);
                    break;
                case Enums.OrderType.Purchase:
                case Enums.OrderType.VendRMA:
                    VendorVar.RefSet(context, companyObject);
                    break;
                case Enums.OrderType.Service:
                    ServiceVendorVar.RefSet(context, companyObject);
                    break;
            }
        }

        public override void OrderDateSet(ContextRz context, DateTime d, Enums.OrderType t)
        {
            base.OrderDateSet(context, d, t);
            switch (t)
            {
                case Enums.OrderType.Sales:
                    orderdate_sales = d;
                    break;
                case Enums.OrderType.Invoice:
                    orderdate_invoice = d;
                    break;
                case Enums.OrderType.RMA:
                    orderdate_rma = d;
                    break;
                case Enums.OrderType.Purchase:
                    orderdate_purchase = d;
                    break;
                case Enums.OrderType.VendRMA:
                    orderdate_vendrma = d;
                    break;
                case Enums.OrderType.Service:
                    orderdate_service = d;
                    break;
            }
            context.TheDelta.Update(context, this);
        }

        public override void ContactRefSet(ContextRz context, companycontact contactObject, Enums.OrderType t)
        {
            switch (t)
            {
                case Enums.OrderType.Sales:
                case Enums.OrderType.Invoice:
                case Enums.OrderType.RMA:
                    CustomerContactVar.RefSet(context, contactObject);
                    break;
                case Enums.OrderType.Purchase:
                case Enums.OrderType.VendRMA:
                    VendorContactVar.RefSet(context, contactObject);
                    break;
                case Enums.OrderType.Service:
                    ServiceVendorContactVar.RefSet(context, contactObject);
                    break;
            }
        }

        public override void AgentRefSet(ContextRz context, n_user userObject, Enums.OrderType t)
        {
            switch (t)
            {
                case Enums.OrderType.Sales:
                case Enums.OrderType.Invoice:
                case Enums.OrderType.RMA:
                    SellerVar.RefSet(context, userObject);
                    break;
                case Enums.OrderType.Purchase:
                case Enums.OrderType.VendRMA:
                    BuyerVar.RefSet(context, userObject);
                    break;
                case Enums.OrderType.Service:
                    ServiceAgentVar.RefSet(context, userObject);
                    break;

            }
        }

        public virtual void CostCalc(ContextRz context)
        {
            if (StockType == Rz5.Enums.StockType.Consign)  //StockType == Rz4.Enums.StockType.Stock ||   this should never have been there, right?  there's no cost calc on stock
            {
                //String code_name = Rz5.consignment_code.ParseCode(lotnumber);
                String code_name = Rz5.consignment_code.ParseCode(consignment_code);
                if (Tools.Strings.StrExt(code_name))
                {
                    Double price = unit_price;
                    if (price <= 0)
                    {
                        SetCost(context, 0);
                    }
                    else
                    {
                        Rz5.consignment_code code = Rz5.consignment_code.GetByName(context, code_name);
                        if (code != null)
                        {
                            try
                            {
                                SetCost(context, code.CostCalc(price));
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        public void SetCost(ContextRz context, Double costInBaseCurrency)
        {
            unit_cost = costInBaseCurrency;
            CurrencyUpdate(context);
        }

        public override String GetClipHTML(ContextNM context)
        {
            String s = GetClipHeader(context);
            s += PartObject.GetClipLine_Part(this, "quantity");
            return s;
        }

        public LineType LineType
        {
            get
            {
                if (line_type == "")
                    return Rz5.LineType.Inventory;
                try
                {
                    return (Rz5.LineType)Enum.Parse(typeof(Rz5.LineType), line_type);
                }
                catch
                {
                    return Rz5.LineType.Inventory;
                }
            }

            set
            {
                line_type = value.ToString();
            }
        }
    }

    public class VarRefOrderNew<TTo> : VarRefSingle<orddet_line, TTo>  //  where TTo : Rz4.ordhed
    {
        //public orddet_line TheDetail;
        public Enums.OrderType TheType;
        public VarRefOrderNew(IItem parent, CoreVarAttribute attr, Enums.OrderType t)
            : base(parent, attr)
        {
            //TheDetail = detail;
            TheType = t;
        }

        public override void RefSet(Context x, TTo value, bool includeReverse)
        {
            base.RefSet(x, value, includeReverse);

            if (value != null)
            {
                object wtf = value;  //doing (ordhed)value doesn't work for some reason
                ordhed o = (ordhed)wtf;

                x.TheDelta.Update(x, o);
            }
            x.TheDelta.Update(x, Parent);
        }

        protected override QueryClass QueryCreate(Context context)
        {
            QueryClass q = new QueryClass("ordhed_" + TheType.ToString().ToLower());
            q.Where = new ExpressionBinaryOperator(new ExpressionIdentifier("unique_id"), BinaryOperatorType.Equality, new ExpressionLiteralString((String)((nObject)Parent).IGet(TheAttributeRef.LinkField)));
            //q.OrderBy.Add(new QueryOrder(new QueryField("linecode_" + TheOrder.OrderType.ToString().ToLower())));
            return q;
        }
    }

    public class VarRefPacks : VarRefMany<orddet_line, pack>  // where TTo : telequip
    {
        public orddet_line TheDetail
        {
            get
            {
                return (orddet_line)Parent;
            }
        }
        //public String TheField;
        String TheName;

        public VarRefPacks(IItem parent, String name, String rev, String field)
            : base(parent, new CoreVarRefManyAttribute(name, "Rz4.orddet_line", "Rz4.pack", rev, field))
        {
            //TheDetail = d;
            //TheField = field;
            TheName = name;
        }

        protected override QueryClass QueryCreate(Context context)
        {
            QueryClass q = new QueryClass("pack");
            q.Where = new ExpressionBinaryOperator(new ExpressionIdentifier(TheAttributeRef.LinkField), BinaryOperatorType.Equality, new ExpressionLiteralString(TheDetail.unique_id));
            q.OrderBy.Add(new QueryOrder(new QueryField("line_code")));
            return q;
        }

        public override void RefsAdd(Context x, IItems items, bool includeReverse)
        {
            base.RefsAdd(x, items, includeReverse);

            foreach (pack l in items.AllGet(x))
            {
                l.ValSet(TheAttributeRef.LinkField, TheDetail.unique_id);
                l.fullpartnumber = TheDetail.fullpartnumber;
                l.manufacturer = TheDetail.manufacturer;
                l.datecode = TheDetail.datecode;
                l.quantity = TheDetail.quantity;//When creating a pack, the qty gets auto
                l.lot_code = TheDetail.lotnumber;
                x.Update(l);
            }
        }

        public int QuantitySum(ContextRz context)
        {
            int ret = 0;
            foreach (Object x in RefsList(context))
            {
                pack l = (pack)x;
                if (l.pack_complete)
                    ret += l.quantity;
                else
                    return ret;
            }
            return ret;
        }
    }

    public class VarRefDeductions : VarRefMany<orddet_line, profit_deduction>  // where TTo : telequip
    {
        public orddet_line TheDetail
        {
            get
            {
                return (orddet_line)Parent;
            }
        }
        String TheName;

        public VarRefDeductions(IItem parent, String name, String rev)
            : base(parent, new CoreVarRefManyAttribute(name, "Rz4.orddet_line", "Rz4.profit_deduction", "TheLine", "the_orddet_line_uid"))
        {
            TheName = name;
        }

        protected override QueryClass QueryCreate(Context context)
        {
            QueryClass q = new QueryClass("profit_deduction");
            q.Where = new ExpressionBinaryOperator(new ExpressionIdentifier(TheAttributeRef.LinkField), BinaryOperatorType.Equality, new ExpressionLiteralString(TheDetail.unique_id));
            q.OrderBy.Add(new QueryOrder(new QueryField("date_created")));
            return q;
        }

        public override void RefsAdd(Context x, IItems items, bool includeReverse)
        {
            base.RefsAdd(x, items, includeReverse);

            foreach (profit_deduction l in items.AllGet(x))
            {
                l.ValSet("the_orddet_line_uid", TheDetail.unique_id);
            }
        }

        public Double ValueSum(ContextRz context)
        {
            Double ret = 0;
            foreach (Object x in RefsList(context))
            {
                profit_deduction l = (profit_deduction)x;
                ret += l.amount;
            }
            return ret;
        }
    }

    public class VarRefFieldPlusName<TFrom, TTo> : VarRefSingle<TFrom, TTo>
    {
        public String NameFieldFrom = "";
        public String NameFieldTo = "";

        public VarRefFieldPlusName(IItem parent, CoreVarAttribute attr, String nameFieldFrom, String nameFieldTo)
            : base(parent, attr)
        {
            NameFieldFrom = nameFieldFrom;
            NameFieldTo = nameFieldTo;
        }

        public override void RefSet(Context x, TTo value, bool includeReverse)
        {
            base.RefSet(x, value, includeReverse);

            if (value == null)
                return;  //clearing is already done in the base

            Parent.ValSet(NameFieldTo, ((IItem)value).ValGet(NameFieldFrom));
            x.TheDelta.Update(x, Parent);
        }

        public override void RefsRemoveAll(Context x)
        {
            Parent.ValSet(NameFieldTo, "");
            base.RefsRemoveAll(x);
        }
    }

    public class LineAssignedAgent : IAssignedAgent
    {
        public LineAssignedAgent(ContextRz context, String userId)
        {
            m_UserObject = (n_user)context.xSys.Users.GetByID(userId);
        }

        n_user m_UserObject = null;

        public n_user UserObjectGet(ContextRz context)
        {
            return m_UserObject;
        }

        public void UserObjectSet(n_user value)
        {
            m_UserObject = value;
        }

        public String UserID
        {
            get
            {
                if (m_UserObject == null)
                    return "";
                else
                    return m_UserObject.unique_id;
            }
            set
            {
            }
        }

        public String UserName
        {
            get
            {
                if (m_UserObject == null)
                    return "";
                else
                    return m_UserObject.name;
            }
            set
            {
            }
        }

        public String ClassId { get { return ""; } }
        public String GetExtraClassInfo() { return ""; }
    }

    public enum CompletionStatus
    {
        Skip = 0,
        Open = 1,
        Working = 2,
        Completed = 3,
        Problem = 4,
    }

    public enum LineType
    {
        Inventory,
        Service,
        Supplies,
    }
}
