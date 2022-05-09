using Core;
using HubspotApis;
using NewMethod;
using Rz5.Enums;
using SensibleDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Tools;
using static SM_Enums;

namespace Rz5
{
    //order interaction
    public class OrderLogic : NewMethod.Logic
    {
        //moved back to ordhed_sales because its related to only 1 sales order
        //public virtual bool MakeInvoicePossible(ContextRz x, ordhed_sales sale, StringBuilder sb)
        //{
        //    return true;
        //}
        public virtual bool DoVoidNotify(ContextRz context, ordhed o)
        {

            switch (o.OrderType)
            {
                case Rz5.Enums.OrderType.Service:
                    {
                        ordhed_service os = (ordhed_service)o;
                        //os.ClearServiceCost(context);
                        os.ClearServiceCostSaleLine(context);
                        break;
                    }
                case Rz5.Enums.OrderType.Sales:
                    {
                        CloseAssociatedQuotes(context, (ordhed_sales)o);
                        break;
                    }
                case Rz5.Enums.OrderType.Invoice:
                case Rz5.Enums.OrderType.RMA:
                case Rz5.Enums.OrderType.VendRMA:
                    if (!context.TheLeader.AreYouSure("permanently void " + o.ToString() + " and notify the accounting department"))
                        return false;
                    context.Logic.NotifyAccounting(context, o, "Voided Order", o.ToString() + " was voided by " + context.xUser.name + " at " + nTools.TimeFormat(DateTime.Now) + " on " + nTools.DateFormat(DateTime.Now));
                    break;

            }


            CloseHubspotDeals(context, o);

            return true;
        }




        private void CloseHubspotDeals(ContextRz context, ordhed o)
        {
            switch (o.OrderType)
            {
                case Rz5.Enums.OrderType.Quote:
                    {
                        ordhed_quote q = (ordhed_quote)o;
                        if (q == null)
                            return;
                        if (q.hubspot_deal_id <= 0)
                            return;
                        HubspotApi.Deals.SetDealLost(q.hubspot_deal_id, q.opportunity_lost_reason);
                    }
                    break;
                case Rz5.Enums.OrderType.Sales:
                    {
                        ordhed_sales s = (ordhed_sales)o;
                        if (s == null)
                            return;
                        if (s.hubspot_deal_id <= 0)
                            return;
                        HubspotApi.Deals.SetDealLost(s.hubspot_deal_id, s.opportunity_lost_reason);
                    }
                    break;
                default:
                    return;
            }
        }
        public virtual bool CheckVerify(ContextRz x, ordhed o, List<string> missingProps)
        {
            //paradigm:
            //cast as proper order type
            //Fill the missing props
            //return a bool based on the missing props list.

            switch (o.OrderType)
            {
                case Enums.OrderType.Quote:
                    {
                        ordhed_quote q = (ordhed_quote)o;
                        //Run Checkverify - adds missing props to the sb
                        return x.TheSysRz.TheQuoteLogic.CheckVerify(x, o, missingProps);
                    }
                case Enums.OrderType.Sales:
                    {
                        ordhed_sales s = (ordhed_sales)o;
                        //Run Checkverify - adds missing props to the sb
                        return x.TheSysRz.TheSalesLogic.CheckVerify(x, o, missingProps);


                    }
            }

            return false;
        }







        protected void CloseAssociatedQuotes(ContextRz x, ordhed_sales s)
        {
            ArrayList RelatedQuotes = s.GetRelatedQuotes(x);
            if (RelatedQuotes == null)
                return;
            foreach (ordhed_quote q in RelatedQuotes)
            {


                //string reason = "Sale Voided";
                //q.opportunity_lost_reason = reason;
                q.opportunity_stage = OpportunityStage.sale_lost.ToString();
                q.isclosed = true;
                q.Update(x);
            }
        }



        //KT Refactored from RzSensible


        //KT End Refactor from RzSensible


        public virtual bool PurchaseOrdersCreatePossible(ContextRz x, ordhed_sales sale, List<orddet_line> lines)
        {
            validation_form vf = null;
            ////KT Check SO Terms, if TBD - Hard Stop, require manager override.
            //if (sale.terms == "TBD" && !sale.is_TermsOverride)
            //{
            //    x.TheLeader.Tell("Sorry, the terms on this order are set to \"TBD\".  PO Creation is not possible.  Please put in accurate terms, or see manager for an override.");
            //    return false;
            //}
            //Problem Customers.
            company c = company.GetById(x, sale.base_company_uid);
            if (c.is_problem)
            {

                if (x.TheSysRz.ThePermitLogic.CheckPermit(x, Permissions.ThePermits.CanOverrideProblemCustomer, x.xUser))
                {
                    if (x.Leader.AskYesNo(c.companyname + " is flagged as a problem customer, would you like to override this block and proceed with the order?"))
                        return true;
                    else
                        return false;
                }
                else
                {
                    x.TheLeader.Tell("Sorry, This company has been flagged as a problem customer.  Sale cannot proceed without managerial override.");
                    return false;
                }

            }


            List<SalesLineGroup> sections = SalesLinesSplitForPurchase(x, sale, lines);
            if (sections.Count == 0)
            {
                //x.TheLeader.Error("Before creating new orders from this one, make sure that the line items are selected (using the 'Select All' menu option), that these line items have not already been purchased, and that the appropriate line items are associated with a vendor.");
                return false;
            }

            double companyCredit = 0;
            string companyCreditAlert = "";
            foreach (SalesLineGroup g in sections)
            {


                List<string> inventoryTypes = new List<string>() { Enums.StockType.Consign.ToString().ToLower(), Enums.StockType.Stock.ToString().ToLower() };
                foreach (orddet_line l in g.TheLines)
                {

                    //KT 4-24-2018 - Moved to Completeable_Consign in orddet_sales.cs
                    ////Ensure stock and consign lines have a valid inventory_link_uid
                    //if (inventoryTypes.Contains(l.stocktype.ToLower()) && string.IsNullOrEmpty(l.inventory_link_uid))
                    //{
                    //    x.Leader.Error("Line: " + l.fullpartnumber + "  (Linecode: " + l.linecode_sales + ") appears to be a consignment part, yet has not inventory link.  This should have happened during allocation.  Try reallocating, or see IT For resolution.");
                    //    return false;
                    //}

                    ////Ensure Consignment has consignment code and vendor uid.
                    //if (inventoryTypes.Contains(l.stocktype.ToLower()) && (string.IsNullOrEmpty(l.consignment_code) || string.IsNullOrEmpty(l.vendor_uid)))
                    //{
                    //    x.Leader.Error("Line: " + l.fullpartnumber + "  (Linecode: " + l.linecode_sales + ") appears to be a consignment part, yet has no consignment code or vendor id.  This should have happened during allocation.  Try reallocating, or see IT For resolution.");
                    //    return false;
                    //}

                }

                ////KT - Check SOA - Do they have any kind of approval at all?
                //if (!g.TheVendor.SOA_components)
                //{
                //    x.TheLeader.Tell("Sorry," + g.TheVendor.companyname + " does not appear to have a proper Scope of Approval, purchasing is not possible until this is resolved.");
                //    return false;
                //}
                ////KT - Is AVL Checked?
                //if (!g.TheVendor.isverified)
                //{
                //    x.TheLeader.Error("Sorry, " + g.TheVendor.companyname + " is not on our AVL.  Please see management to correct.");
                //    return false;
                //}
                //KT Check for Outstanding Vendor Credits
                companyCredit = GetCompanyCredits(x, g.TheVendor);
                if (companyCredit > 0)
                    companyCreditAlert = g.TheVendor.companyname + " has $" + Tools.Number.MoneyFormat(companyCredit) + " in outstanding vendor credits, please consider using them for this order.";



                ////ignore lines with no vendor, as in stock
                ////there shouldn't be any though, because SalesLinesGetForPurchase above should remove stock items
                if (g.TheVendor == null)
                {
                }
                else
                {
                    //if any of the remaining groups can't be purchased, cancel the process and let the user make changes
                    if (!PurchaseOrderCreatePossible(x, g))
                        return false;
                }
            }

            //PreValidation
            vf = validation_form.GetByOrderID(x, sale);
            if (vf == null)
                vf = validation_form.ValidationFormCreate(x, sale);
            if (vf == null)
                return false;

            //Prevalidate
            if (!Prevalidate(x, sale, vf))
            {
                UpdateValidationFormStatus(x, vf, false);
                return false;
            }
            else
                UpdateValidationFormStatus(x, vf, true);

            //Handle Validation Tracking 
            validation_tracking vt = TrackValidation(x, sale, Enums.SalesOrderValidationStage.Validation.ToString());

            //Send Validation Email
            //if(vt != null)
            //HandleValidationEmail(x, sale, vt, false);

            if (!string.IsNullOrEmpty(companyCreditAlert))
                x.Leader.Tell(companyCreditAlert);
            return true;
        }

        public bool CheckVendorApprovalStatus(ContextRz x, ordhed o, List<string> messages, company vend, bool suppress_msg)
        {
            bool ret = true;
            if (vend == null)
            {
                //b = false;
                messages.Add("No vendor");
                ret = false;
            }
            string msg = "";
            //if(o != null)
            //{
            //    if (o.OrderType == OrderType.Service)
            //    {                   
            //        if (!vend.SOA_services)
            //        {
            //            messages.Add("Is does not have a scope of approval for services.");
            //            ret = false;
            //        }

            //    }
            //}          


            //Vendor has not been vetted            
            if (!x.TheSysRz.TheCompanyLogic.CheckVetted(x, vend))
            {
                messages.Add("Vendor needs to be vetted");
                ret = false;
            }
            //Vendor Blocked
            if (!vend.VendorApprovedCheck(x, ref msg, suppress_msg))
            {

                if (Tools.Strings.StrExt(msg))
                    messages.Add(msg);
                else
                    messages.Add("Blocked vendor");
                ret = false;
            }

            //KT - Check SOA - Do they have any kind of approval at all?   
            if (o != null)
            {
                if (o.OrderType == OrderType.Service)
                {
                    if (!vend.SOA_services)
                    {
                        messages.Add("No scope of approval for services.");
                        ret = false;
                    }

                }
            }
            //this i bad, but should work
            else if (!vend.SOA_components)
            {
                messages.Add(vend.companyname + " does not appear to have a proper Scope of Approval");
                ret = false;
            }
            //KT - Is AVL Checked?
            if (!vend.isverified)
            {
                messages.Add(vend.companyname + " is not on our AVL");
                ret = false;
            }

            if (vend.is_locked || vend.islocked_purchase)
            {
                x.TheLeader.Error(vend.companyname + " is locked");
                ret = false;
            }

            return ret;
        }

        public bool CheckOrderNeedsCustomerFinancials(ContextRz context, company c)
        {
            if (!c.has_financials)
                return false;
            else
                return true;
        }

        public ArrayList GetCompanyShipAccounts(ContextRz x, string companyId, bool includeInternal, RzLogic logic)
        {
            ArrayList ret = new ArrayList();
            ArrayList defaultShipVia = x.SelectScalarArray("select distinct c.name  from n_choice c inner join n_choices cs on c.the_n_choices_uid = cs.unique_id where cs.name = 'default_shipvia'");
            if (defaultShipVia != null)
                if (defaultShipVia.Count > 0)
                    ret.AddRange(defaultShipVia);
            ret = x.SelectScalarArray("SELECT DISTINCT(ACCOUNTNUMBER) FROM shippingaccount WHERE accountnumber > '' and base_company_uid = '" + companyId + "' ORDER BY ACCOUNTNUMBER");
            if (includeInternal)
            {
                //if(ret.Count > 0)
                ret.Add("---Sensible Accounts---");
                ArrayList internalAccounts = new ArrayList();
                internalAccounts.Add(logic.InternalUPS);
                internalAccounts.Add(logic.InternalFedex);
                internalAccounts.Add(logic.InternalDHL);
                internalAccounts.Add(logic.InternalOther);
                internalAccounts.Add(x.GetSetting("dhl_account"));
                internalAccounts.Add("Free-Freight");
                //internalAccounts.Add("Pre-Paid");



                foreach (string s in internalAccounts)
                    if (!string.IsNullOrEmpty(s))
                        ret.Add(s);
            }

            return ret;
            //ret.AddRange(companyShipVia);
            //return ret;
        }



        public virtual double GetCompanyCredits(ContextRz context, company c)
        {
            double ret = 0;
            ret = context.SelectScalarDouble("select SUM(creditamount) from companycredit where base_company_uid = '" + c.unique_id + "' AND isnull(is_applied, 0) = 0");

            return ret;
        }

        public virtual bool CanAssignContactExtra(ContextRz context, companycontact c, ordhed o)
        {
            return true;
        }




        public virtual OrderMapObject OrderMapObjectCreate(Rz5.ContextRz context)
        {
            return new OrderMapObject();
        }

        public virtual bool CheckLineStatusForTotals(ContextRz x, orddet_line l)
        {
            //KT - changed this to match what we had in RzSensible ordhed_sales
            // Line Calculations10-7-2015 (   if (l.Status != Rz5.Enums.OrderLineStatus.Void && !l.was_rma && !l.was_vendrma)   )
            //return l.Status != Rz5.Enums.OrderLineStatus.Void && !l.was_rma;
            return l.Status != Rz5.Enums.OrderLineStatus.Void && !l.was_rma && !l.was_vendrma;
        }



        public string GetFriendlyReportText(ContextRz x, nObject o, string s, bool includePrefix = true)
        {
            string ret = "";
            string type = o.GetType().ToString().ToLower();
            switch (type)
            {
                case "rz5.orddet_line":
                case "rz5.orddet_quote":
                    ret = GetFriendlyReportTextOrddet(x, o, s, includePrefix);
                    break;
                case "rz5.ordhed_quote":
                case "rz5.ordhed_sales":
                case "rz5.ordhed_purchase":
                    ret = GetFriendlyReportTextOrdhed(x, o, s, includePrefix);
                    break;
            }
            return ret;
        }

        private string GetFriendlyReportTextOrdhed(ContextRz x, nObject o, string s, bool includePrefix)
        {
            string ret = "";
            switch (s)
            {

                //Quote Header
                case "shippingaddress":
                    {
                        ret = "Shipping Address";
                        break;
                    }
                case "shipvia":
                    {
                        ret = "Shipping Method";
                        break;
                    }
                case "opportunity_type":
                    {
                        ret = "Opportunity Type";
                        break;
                    }

                //Sales Header
                case "terms":
                    {
                        ret = "Terms";
                        break;
                    }
                case "orderreference":

                    {
                        ret = "Customer PO";
                        break;
                    }
                case "shipping_adress":

                    {
                        ret = "Shipping Address";
                        break;
                    }
                case "billing_address":

                    {
                        ret = "Billing Address";
                        break;
                    }

                //Sales Header Logics
                case "no_line_items":

                    {
                        ret = "No Line Items";
                        break;
                    }
                case "validation_not_complete":

                    {
                        ret = "Validation Not Complete";
                        break;
                    }
                case "tbd_terms":

                    {
                        ret = "Terms Can't Be \"TBD\"";
                        break;
                    }

                case "financials_not_verified":
                    {
                        ret = "Customer Financials Not Verified";
                        break;
                    }

                //Purchase Header
                case "lines_need_put_away":
                    {

                        {
                            ret = "Line Items Not Put Away";
                            break;
                        }
                    }



                default:
                    {
                        ret = s;
                        break;
                    }
            }

            //if (includePrefix)
            //    ret = "Header: " + ret;
            return ret;
        }



        //public void AssociateOrderWithBatchHubspotDeal(ContextRz x, ordhed currentOrder)
        //{
        //    string batchID = GetAssociatedBatchID(x, currentOrder);
        //    if (!string.IsNullOrEmpty(batchID))
        //    {
        //        dealheader d = dealheader.GetById(x, batchID);
        //        if (d != null)
        //        {
        //            if (d.hubspot_deal_id > 0)
        //            {
        //                currentOrder.hubspot_deal_id = d.hubspot_deal_id;
        //                currentOrder.Update(x);
        //            }

        //        }
        //    }
        //}

        private string GetFriendlyReportTextOrddet(ContextRz x, nObject o, string s, bool includePrefix)
        {
            string ret = "";
            switch (s)
            {
                //Quote Line
                case "quantityordered":

                    {
                        ret = "Quantity";
                        break;
                    }
                case "fullpartnumber":

                    {
                        ret = "Part number";
                        break;
                    }
                case "internalpartnumber":

                    {
                        ret = "Internal part number";
                        break;
                    }
                case "manufacturer":

                    {
                        ret = "Manufacturer";
                        break;
                    }
                case "rohs_info":

                    {
                        ret = "RoHS status";
                        break;
                    }
                case "condition":

                    {
                        ret = "Line condition";
                        break;
                    }
                case "datecode":

                    {
                        ret = "Date code";
                        break;
                    }
                case "delivery":

                    {
                        ret = "Quoted delivery";
                        break;
                    }
                case "unitprice":

                    {
                        ret = "Unit price";
                        break;
                    }
                case "unitcost":

                    {
                        ret = "Unit cost";
                        break;
                    }

                //Sales Lines
                case "shipvia_invoice":
                    {
                        ret = "ShipVia";
                        break;
                    }
                case "customer_dock_date":

                    {
                        ret = "Dock date";
                        break;
                    }
                case "vendor_uid": //This means different things depending on stocktype
                    {
                        if (o.GetType().ToString().ToLower() == "orddet_line")
                        {
                            orddet_line l = (orddet_line)o;
                            if (l.stocktype.ToLower() == Enums.StockType.Consign.ToString().ToLower())
                                ret = "No consingment vendor link";
                            else if (l.stocktype.ToLower() == Enums.StockType.Buy.ToString().ToLower())
                                ret = "No vendor Link";
                        }

                        break;
                    }
                //Sales Lines - Buy
                case "vendor_vetted":

                    {
                        ret = "Vendor not vetted";
                        break;
                    }

                case "vendor_avl":

                    {
                        ret = "Not Set";
                        break;
                    }
                case "vendor_soa":

                    {
                        ret = "Not Set";
                        break;
                    }
                case "vendor_verified":

                    {
                        ret = "Not Set";
                        break;
                    }
                case "vendor_not_locked":

                    {
                        ret = "Not Set";
                        break;
                    }
                //Stock / Consign                    
                case "invetory_link_uid":

                    {
                        ret = "Not Set";
                        break;
                    }
                //Consign
                case "consignment_code":

                    {
                        ret = "Not Set";
                        break;
                    }


                default:
                    {
                        ret = s;
                        break;
                    }
            }

            if (includePrefix)
            {
                string orddetType = o.GetType().ToString().ToLower();
                switch (orddetType)
                {
                    case "rz5.orddet_line":
                        {
                            orddet_line l = (orddet_line)o;
                            ret = "#" + l.linecode_sales.ToString() + ": " + ret;
                            break;
                        }
                    case "rz5.orddet_quote":
                        {
                            orddet_quote l = (orddet_quote)o;
                            ret = "#" + l.linecode.ToString() + ": " + ret;
                            break;
                        }



                }
            }



            return ret;
        }

        //public List<ordhed_purchase> PurchaseOrdersCreateWithCheck(ContextRz x, ordhed_sales sale, List<orddet_sales> lines)
        //{
        //    if (!PurchaseOrdersCreatePossible(x, sale, lines))
        //        return null;

        //    return PurchaseOrdersCreate(x, sale, lines);
        //}
        public virtual void AbsorbCompanyAddresses(ContextRz context, ordhed o, company xCompany)
        {
            o.billingaddress = "";
            o.shippingaddress = "";
            //KT Set Default Shipping to Sensible Micro on initial creation
            if (o.OrderType == Enums.OrderType.Purchase)
            {
                o.shippingname = "Sensible Micro Corporation";
                //o.shippingaddress = OwnerSettings.GetValue(context, OwnerSettingField.owner_address1) + Environment.NewLine + OwnerSettings.GetValue(context, OwnerSettingField.owner_city) + ", " + OwnerSettings.GetValue(context, OwnerSettingField.owner_state) + OwnerSettings.GetValue(context, OwnerSettingField.owner_zip);
                //o.primaryphone = OwnerSettings.GetValue(context, OwnerSettingField.owner_phone);
                //o.primaryfax = OwnerSettings.GetValue(context, OwnerSettingField.owner_fax);
                o.shippingaddress = OwnerSettings.GetAddressBlock(context);



                //KT Do I need to set default billing here?
                o.billingname = o.companyname;
                o.billingaddress = xCompany.GetPrimaryBillingAddressString(context);



            }
            else
            {


                companyaddress addr = xCompany.GetPrimaryBillingAddress(context);
                if (addr != null)
                    o.billingaddress = addr.GetAddressString(context);
                addr = xCompany.GetPrimaryShippingAddress(context);
                if (addr != null)
                    o.shippingaddress = addr.GetAddressString(context);
            }
        }
        public virtual void CreateHoldNoteByName(ContextRz context, ordhed o, string strHold)
        {

        }
        public virtual DateTime GetFollowUpDate(ordhed o)
        {
            return o.followup_date;
        }
        public virtual bool AllowIsOnTeamWith()
        {
            return false;
        }
        public virtual void CheckNotifyGovernmentOrder(ContextRz x, ordhed o)
        {

        }




        public string GetAssociatedBatchID(ContextRz context, ordhed currentOrder)
        {
            string ret = "";

            switch (currentOrder.OrderType)
            {
                case OrderType.Sales:
                    ret = context.SelectScalarString("select DISTINCT q.base_dealheader_uid from orddet_quote q inner join orddet_line l on q.unique_id = l.quote_line_uid where l.orderid_sales = '" + currentOrder.unique_id + "'");
                    break;
                case OrderType.Invoice:
                    ret = context.SelectScalarString("select DISTINCT q.base_dealheader_uid from orddet_quote q inner join orddet_line l on q.unique_id = l.quote_line_uid where l.orderid_invoice = '" + currentOrder.unique_id + "'");
                    break;
            }
            return ret;
        }


        public static bool CheckCloseDropShip(Context context, ordhed o)
        {
            int DropShippedServiceLineCount = GetDropShippedLineCount((ContextRz)context, o);

            if (DropShippedServiceLineCount > 0)
            {
                int currentLineCount = o.DetailsList((ContextRz)context).Count;
                if (DropShippedServiceLineCount == currentLineCount)
                    return true;
            }
            return false;
        }

        public static int GetDropShippedLineCount(ContextRz x, ordhed o)
        {
            int ret = 0;
            foreach (orddet_line l in o.DetailsList(x))
                if (l.drop_ship == true)
                    ret++;
            return ret;
        }



        public virtual void CheckAutoASN(ContextRz context, ordhed_new o)
        {

        }
        public virtual bool UpperCasePartInfo()
        {
            return false;
        }
        public virtual string GetTermsAsCustomer(company c, string terms)
        {
            if (c == null)
                return "";
            return c.termsascustomer;
        }
        public virtual string GetTermsAsVendor(company c, string terms)
        {
            if (c == null)
                return "";
            return c.termsasvendor;
        }
        public virtual qualitycontrol GetNewInspection(ContextRz x)
        {
            return qualitycontrol.New(x);
        }
        public virtual void CalcOrdersExtra(ContextRz x, string strTable, bool ExcludeManagers, bool MergeAssistants)
        {

        }
        public virtual LineHandleObject GetLineHandleObject(ContextRz context, ordhed o, nObject line)
        {
            return new LineHandleObject(context, line);
        }
        public virtual List<ordhed_purchase> PurchaseOrdersCreate(ContextRz x, ordhed_sales sale, List<orddet_line> lines, ref bool cancel)
        {
            List<ordhed_purchase> ret = new List<ordhed_purchase>();
            List<SalesLineGroup> sections = SalesLinesSplitForPurchase(x, sale, lines);
            if (sections.Count == 0)
                return ret;

            sections = SalesLineGroupFilter(x, sale, sections, ref cancel);
            if (sections == null)  //canceled
                return ret;

            foreach (SalesLineGroup g in sections)
            {
                ordhed_purchase po = PurchaseOrderCreate(x, g);
                ret.Add(po);
            }

            return ret;
        }

        public virtual QueryOrder GetQueryClassOrder(Rz5.ordhed o)
        {
            return new QueryOrder(new QueryField("linecode_" + o.OrderType.ToString().ToLower()));
        }
        public virtual bool DontShowConsignmentPOs()
        {
            return false;
        }
        public virtual void AbsorbRFQDetailExtra(orddet_rfq r, orddet_quote q)
        {
            //do nothing
        }
        protected virtual List<SalesLineGroup> SalesLineGroupFilter(ContextRz context, ordhed_sales sale, List<SalesLineGroup> sections, ref bool cancel)
        {
            return sections;
        }

        public virtual List<Rz5.orddet_line> SalesLinesGetForPurchase(ContextRz x, Rz5.ordhed_sales sale, List<Rz5.orddet_line> lines)
        {
            //List<Rz5.orddet_line> ret = new List<Rz5.orddet_line>();
            //foreach (Rz5.orddet_line xDetail in lines)
            //{
            //    if (xDetail.NeedsPurchasing)
            //        ret.Add(xDetail);
            //}
            //return ret;

            //KT Refactored from RzSensible
            List<Rz5.orddet_line> ret = new List<Rz5.orddet_line>();
            foreach (Rz5.orddet_line xDetail in lines)
            {
                if (xDetail.NeedsPurchasing && !Tools.Strings.StrExt(xDetail.orderid_purchase))
                    ret.Add(xDetail);
            }
            return ret;
        }

        public virtual bool PurchaseOrderCreatePossible(ContextRz x, SalesLineGroup g)
        {


            List<string> missingProps = new List<string>();
            if (!g.TheSale.CheckVerify(x, missingProps))
            {
                string msg = "";
                foreach (string s in missingProps)
                    msg += s + Environment.NewLine;
                //x.TheLeader.Tell(sb.ToString());
                return false;
            }

            if (!x.xUser.CheckPermit(x, "Order:Create:Can Make Purchase"))
                return false;

            return true;
        }

        //the public interface to PurchaseOrderCreate, which forces a validity check
        public ordhed_purchase PurchaseOrderCreateWithCheck(ContextRz x, SalesLineGroup g)
        {
            if (!PurchaseOrderCreatePossible(x, g))
                return null;
            return PurchaseOrderCreate(x, g);
        }

        protected virtual Rz5.ordhed_purchase PurchaseOrderCreate(ContextRz x, SalesLineGroup g)
        {
            ordhed_purchase xOrder = null;
            if (g.TheTargetType == Rz5.SalesLineGroupTargetType.ExistingOrder && g.TheTargetOrder != null)
                xOrder = (ordhed_purchase)g.TheTargetOrder;
            if (xOrder == null)
            {
                xOrder = (ordhed_purchase)Rz5.ordhed.CreateNew(x, Rz5.Enums.OrderType.Purchase);
                xOrder.the_sales_order_uid = g.TheSale.unique_id;
                //if(string.IsNullOrEmpty( xOrder.the_sales_order_uid))
                //{
                //    if (x.Leader.AskYesNo("Are you creating a Stock PO?"))                    
                //        xOrder.is_stock = true; 
                //}







                //xOrder.base_mc_user_uid = x.xUser.unique_id;
                if (Tools.Strings.StrExt(g.TheSale.buyername) && Tools.Strings.StrExt(g.TheSale.orderbuyerid))
                {
                    xOrder.base_mc_user_uid = g.TheSale.orderbuyerid;
                    xOrder.agentname = g.TheSale.buyername;
                }
                else
                {
                    xOrder.base_mc_user_uid = g.TheSale.base_mc_user_uid;
                    xOrder.agentname = g.TheSale.agentname;
                }
                if (!Tools.Strings.StrExt(g.ConsignmentCode))
                {
                    if (g.TheVendor != null && g.TheVendorContact != null)
                    {
                        if (!Tools.Strings.StrCmp(g.TheVendor.unique_id, g.TheVendorContact.base_company_uid))
                            g.TheVendorContact = null;  //this should never happen now, but i fixed it here before fixing the actual root cause just in case  2011_07_21
                    }
                    xOrder.AbsorbCompanyAndContact(x, g.TheVendor, g.TheVendorContact);
                }
                else
                {
                    consignment_code code = consignment_code.GetByName(x, g.ConsignmentCode);
                    if (code != null)
                    {
                        xOrder.base_company_uid = code.vendor_uid;
                        xOrder.companyname = code.vendor_name;
                        xOrder.base_companycontact_uid = code.vendor_contact_uid;
                        xOrder.contactname = code.vendor_contact_name;
                        xOrder.is_consign = true;
                        xOrder.is_consumption = true;
                        xOrder.lot_number = code.code_name;
                    }
                    else
                        x.TheLeader.Error("The lot number " + g.ConsignmentCode + " could not be found");
                }
                xOrder.legacycontact = g.TheSale.legacycontact;
                xOrder.soreference = g.TheSale.ordernumber;
                xOrder.buyinid = g.TheSale.unique_id;

                //xOrder.shipvia = g.TheSale.shipvia;


                x.Update(xOrder);
                x.TheSysRz.TheOrderLogic.Link2Orders(x, g.TheSale, xOrder);
            }
            foreach (orddet_line detail in g.TheLines)
            {
                PurchaseOrderLineAdd(x, (ordhed_purchase)xOrder, detail);
            }
            if (xOrder.ConsignmentOnlyIs(x))
                PurchaseOrderConsumptionAfterCreateWithLines(x, xOrder, (ordhed_sales)g.TheSale);


            //If the customer has specific Purchase Restrictiuons (i.e. must be rohs)
            AddCustomerTermsToPO(x, g, xOrder);

            return xOrder;
        }

        private void AddCustomerTermsToPO(ContextRz x, SalesLineGroup g, ordhed_purchase xOrder)
        {
            company customer = company.GetById(x, g.TheSale.base_company_uid);
            if (customer != null)
            {
                company_terms_conditions ct = customer.GetExistingCompanyTC(x);
                if (ct != null)
                {
                    if (ct.has_rohs_restriction)
                        xOrder.printcomment = "PARTS MUST BE ROHS.  ";
                }

            }

            //JoeM - 12-16-2021 - Some kind of ""
            string cooComment = GenerateCountryOfOriginComment(x, g, xOrder);
            if (!string.IsNullOrEmpty(cooComment))
                xOrder.printcomment += Environment.NewLine + cooComment;



        }

        private string GenerateCountryOfOriginComment(ContextRz x, SalesLineGroup g, ordhed_purchase xOrder)
        {
            string ret = "";
            //Loop through the line items, if any have coo_vendor, include a string <Partnumber> : COO <country>
            foreach (orddet_line l in g.TheSale.DetailsList(x))
            {
                //Ensure only the printcomment for lines related to this PO.
                if (l.orderid_purchase == xOrder.unique_id)
                    if (!string.IsNullOrEmpty(l.country_of_origin_vendor))
                    {
                        //If we already have a line, add a space
                        if (!string.IsNullOrEmpty(ret))
                            ret += Environment.NewLine;
                        ret += l.fullpartnumber.Trim().ToUpper() + ": " + l.country_of_origin_vendor.Trim().ToUpper();
                    }

            }
            return ret;
        }

        //this takes the consignment code into account to keep the POs separate
        public virtual List<SalesLineGroup> SalesLinesSplitForPurchase(ContextRz x, Rz5.ordhed_sales sale, List<Rz5.orddet_line> lines)
        {
            Dictionary<String, SalesLineGroup> groups = new Dictionary<String, SalesLineGroup>();

            foreach (orddet_line dd in lines)
            {
                consignment_code code = null;
                String use_vendor_id = dd.vendor_uid;
                String use_vendor_contact_id = dd.vendor_contact_uid;
                String vendor_unique_key = dd.vendor_uid;

                if (dd.StockType == Rz5.Enums.StockType.Consign)
                {
                    code = (consignment_code)Rz5.consignment_code.GetByName(x, dd.consignment_code);
                    if (code != null)
                    {
                        use_vendor_id = code.vendor_uid;
                        use_vendor_contact_id = code.vendor_contact_uid;
                        vendor_unique_key = "LOT " + code.code_name;
                    }
                }
                SalesLineGroup hold = null;
                groups.TryGetValue(vendor_unique_key, out hold);
                if (hold == null)
                {
                    company vendor = company.GetById(x, use_vendor_id);
                    Rz5.companycontact vendorcontact = Rz5.companycontact.GetById(x, use_vendor_contact_id);
                    hold = new SalesLineGroup(vendor, vendorcontact, sale);
                    hold.TheLines.Add(dd);
                    if (code != null)
                        hold.ConsignmentCode = code.code_name;
                    groups.Add(vendor_unique_key, hold);
                }
                else
                    hold.TheLines.Add(dd);
            }

            List<SalesLineGroup> ret = new List<SalesLineGroup>();
            foreach (KeyValuePair<String, SalesLineGroup> k in groups)
            {
                ret.Add(k.Value);
            }
            return ret;
        }


        public virtual double GetCreditAmount(ContextRz context, ordhed o)
        {
            //KT Refactored from RzSensible
            if (o == null)
                return 0;
            double charge = 0;
            ArrayList a = context.QtC("ordhit", "select * from ordhit where the_ordhed_uid = '" + o.unique_id + "'");
            if (a == null)
                return 0;
            foreach (ordhit h in a)
            {
                if (h.deduct_profit == true)
                    charge -= h.hit_amount;
                else
                    charge += h.hit_amount;
            }
            return charge;


        }

        public virtual void CreditsAppend(ContextRz context, ordhed o, List<orddet> ret)
        {
            Double cred = Tools.Data.NullFilterDouble(o.IGet("credit_amount"));
            if (cred == 0)
                return;

            String cap = Tools.Data.NullFilterString(o.IGet("credit_caption"));
            if (!Tools.Strings.StrExt(cap))
                cap = "CREDIT";

            ret.Add(CreditLineForPrint(context, cap, cred));
        }


        public virtual orddet_line CreditLineForPrint(ContextRz context, String caption, Double credit)
        {
            orddet_line l = orddet_line.New(context);
            l.unique_id = "not_an_id";
            l.fullpartnumber = caption;
            l.quantity = 1;
            l.unit_price = credit;
            l.total_price = credit;
            return l;
        }

        public virtual List<orddet> DetailsSum(ContextNM context, List<orddet> a, Enums.OrderType type)
        {
            List<orddet> ret = new List<orddet>();
            Dictionary<String, orddet_line> dict = new Dictionary<string, orddet_line>();
            orddet_line yDetail;
            foreach (orddet_line xDetail in a)
            {
                String strAll = DetailSumKey(context, xDetail, type).ToLower().Trim();
                orddet_line lne;
                if (dict.ContainsKey(strAll))
                {
                    //craft the consolidated line
                    yDetail = (orddet_line)dict[strAll];
                    yDetail.quantity += xDetail.quantity;
                    yDetail.quantity_packed += xDetail.quantity_packed;
                    yDetail.quantity_packed_service += xDetail.quantity_packed_service;
                    yDetail.quantity_packed_vendrma += xDetail.quantity_packed_vendrma;
                    yDetail.quantity_unpacked += xDetail.quantity_unpacked;
                    yDetail.quantity_unpacked_rma += xDetail.quantity_unpacked_rma;
                    yDetail.quantity_unpacked_service += xDetail.quantity_unpacked_service;
                    yDetail.SummedIds.Add(xDetail.unique_id);
                    yDetail.Updating(context);
                    lne = yDetail;
                    yDetail.DetailSummedWith((ContextRz)context, xDetail, type);
                }
                else
                {
                    //new detail line, either the 1st detail, or not consolidated, or this detail is different than the other.
                    orddet_line nd = (orddet_line)xDetail.CloneValues(context);
                    nd.SummedIds = new List<string>();
                    nd.SummedIds.Add(xDetail.unique_id);
                    nd.unique_id = "<none>";
                    dict.Add(strAll, nd);
                    ret.Add(nd);
                    lne = nd;
                    nd.DetailSummedWith((ContextRz)context, xDetail, type);
                }
            }
            return ret;
        }

        public virtual String DetailSumKey(ContextNM context, orddet_line xDetail, Enums.OrderType type)
        {
            String strAll = xDetail.fullpartnumber + "|" + xDetail.packaging + "|" + xDetail.manufacturer + "|" + xDetail.datecode + "|" + xDetail.condition; // + "|" + xDetail.lotnumber   nTools.DateFormat(xDetail.shipdate) + "|" + nTools.DateFormat(xDetail.requireddate) + "|"

            switch (type)
            {
                case Enums.OrderType.Quote:
                case Enums.OrderType.Sales:
                case Enums.OrderType.Invoice:
                    strAll += "|" + nTools.MoneyFormat_2_6(xDetail.unit_price) + "|" + xDetail.description;
                    break;
                case Enums.OrderType.RMA:
                    strAll += "|" + nTools.MoneyFormat_2_6(xDetail.unit_price_rma) + "|" + xDetail.description;
                    break;
                case Enums.OrderType.Purchase:
                    strAll += "|" + nTools.MoneyFormat_2_6(xDetail.unit_cost) + "|" + xDetail.description + "|" + Tools.Dates.DateFormat(xDetail.receive_date_due);
                    break;
                case Enums.OrderType.VendRMA:
                    strAll += "|" + nTools.MoneyFormat_2_6(xDetail.unit_price_vendrma) + "|" + xDetail.description;
                    break;
                case Enums.OrderType.Service:
                    break;
            }

            return strAll;
        }

        public virtual void PurchaseOrderLineAdd(ContextRz context, Rz5.ordhed_purchase purchase, Rz5.orddet_line sale_line)
        {
            sale_line.PurchaseVar.RefSet(context, purchase);
            sale_line.was_purchase = true;
        }

        public virtual void PurchaseOrderConsumptionAfterCreateWithLines(ContextRz context, ordhed_purchase p, ordhed_sales sale)
        {

        }

        public override void ActsListInstance(Context context, ActSetup m)
        {
            base.ActsListInstance(context, m);
            ActsListOrder(context, m);
        }

        protected virtual void ActsListOrder(Context context, ActSetup m)
        {
            ContextRz xrz = (ContextRz)context;
            ordhed o = null;
            Enums.OrderType t = Enums.OrderType.Any;
            foreach (IItem b in m.TheItems.AllGet(context))
            {
                if (!(b is ordhed))
                    continue;
                o = (ordhed)b;
                if (o != null)
                    t = o.OrderType;
                break;
            }
            m.Add("Links");
            m.Add("Print");
            switch (t)
            {
                case Enums.OrderType.Quote:
                    ActsListOrderQuote(xrz, m);
                    break;
                case Enums.OrderType.Sales:
                    ActsListOrderSales(xrz, m);
                    break;
                case Enums.OrderType.Purchase:
                    ActsListOrderPurchase(xrz, m);
                    break;
                case Enums.OrderType.Invoice:
                    ActsListOrderInvoice(xrz, m);
                    break;
                case Enums.OrderType.RMA:
                    ActsListOrderRMA(xrz, m);
                    break;
                case Enums.OrderType.VendRMA:
                    ActsListOrderVendRMA(xrz, m);
                    break;
                case Enums.OrderType.Service:
                    ActsListOrderService(xrz, m);
                    break;
            }


            //Quickbooks
            switch (t)
            {
                case OrderType.Sales:
                case OrderType.Invoice:
                case OrderType.Purchase:
                case OrderType.Service:
                    {
                        if (o != null)
                            CheckAddQuickbooksLinks(xrz, m, o);
                        break;
                    }


            }

            //Manual Close
            switch (t)
            {
                case OrderType.Purchase:
                case OrderType.Service:
                    AddManualClose(xrz, m);
                    break;
            }


            //Options by OrderType
            switch (t)
            {
                case OrderType.Purchase:
                case OrderType.Invoice:
                    CheckAddPaymentLinks(xrz, m);
                    m.Add("Remove Un-filled Lines");
                    break;
                case OrderType.Sales:
                    m.Add("Pre-Invoice");
                    break;
            }

            if (t != Enums.OrderType.RFQ)  // moved the permission checking into VoidAdd, and made it check the actual order.  not being able to void all orders doesn't mean they can't void they're own ((n_sys_Rz4)((ContextRz)context).xSys).ThePermitLogic.CheckPermit(Permissions.ThePermits.VoidAllOrders, ((ContextRz)context).xUser)
                VoidAdd((ContextRz)context, m);


            if (xrz.xUser.super_user)
            {
                m.Add("Test Options");

            }


            //Confirm Dock Dates
            m.Add("Confirm Dock Dates");




            //if (xrz.Accounts.Enabled && (xrz.xUserRz.AccountingIs || xrz.xUserRz.IsDeveloper()))
            //    m.Add("Print Check");

            if (!m.Has("Make Link"))
                m.Add("Make Link");

            m.Add("Paste Line Info");
        }

        private void AddManualClose(ContextRz xrz, ActSetup m)
        {

            //Order Management Options
            bool canManagePurchaseOrder = xrz.TheSysRz.ThePermitLogic.CheckPermit(xrz, Permissions.ThePermits.EditAllPurchaseOrders, (xrz.xUser));
            if (canManagePurchaseOrder)
            {
                //Manually close an order
                m.Add("Manual Close");
            }
        }

        protected virtual void ActsListOrderQuote(ContextRz context, ActSetup m)
        {
            m.Add("Email");
            //m.Add("Import Lines");
            //m.Add("Sales Order");
            //KT 11-20-2015
            m.Add("View Order Batch");
        }

        protected virtual void ActsListOrderSales(ContextRz context, ActSetup m)
        {
            //KT 11-20-2015
            m.Add("View Order Batch");
            m.Add("Print All Documents");

        }

        protected virtual void ActsListOrderInvoice(ContextRz context, ActSetup m)
        {
            m.Add("Email");
            m.Add("Line Report");



        }

        protected virtual void ActsListOrderPurchase(ContextRz context, ActSetup m)
        {
            m.Add("Email");
            m.Add("Reorder");
            //m.Add("Re-Close");
        }
        private void ActsListOrderRMA(ContextRz xrz, ActSetup m)
        {

        }
        protected virtual void ActsListOrderVendRMA(ContextRz xrz, ActSetup m)
        {
            m.Add("Reorder PO");
            m.Add("Email");
            if (xrz.TheSysRz.ThePermitLogic.CheckPermit(xrz, Permissions.ThePermits.CanChargeCustomerServiceCost, ((ContextRz)xrz).xUser))
                m.Add("Charge Customer");
        }

        private void ActsListOrderService(ContextRz xrz, ActSetup m)
        {
            m.Add("Email");
            if (xrz.TheSysRz.ThePermitLogic.CheckPermit(xrz, Permissions.ThePermits.CanChargeCustomerServiceCost, xrz.xUser))
                m.Add("Charge Customer");
        }

        protected virtual void CheckAddQuickbooksLinks(ContextRz xrz, ActSetup m, ordhed o)
        {
            OrderType t = o.OrderType;
            if (!xrz.Accounts.Enabled || ((ContextRz)xrz).GetSettingBoolean("allow_qbs_posting"))
            {
                if (!xrz.Accounts.Enabled)
                {
                    if (xrz.TheSysRz.ThePermitLogic.CheckPermit(xrz, Permissions.ThePermits.ApplyPayments, xrz.xUser))
                    {

                        switch (t)
                        {
                            case OrderType.Sales:
                                {
                                    m.Add("Sync QB");
                                    m.Add("Customer To QB");
                                    break;
                                }
                            case OrderType.Service:
                            case OrderType.Purchase:
                                {
                                    m.Add("Vendor To QB");
                                    //IF no Sales, allow direct send of PO to QB, else, have users use teh Sales order to sync everything
                                    //This prevents accidentally updating a line with a new QTY (example), and accidentally updating from the PO, whichi would NOT uypdate the QB Sales ORder.  
                                    //int count = o.GetRelatedSales(xrz).Count;
                                    //if (count <= 0)
                                    m.Add("Sync QB");
                                    break;
                                }


                        }

                    }
                }
            }
        }

        private void CheckAddPaymentLinks(ContextRz xrz, ActSetup m)
        {
            if (xrz.TheSysRz.ThePermitLogic.CheckPermit(xrz, Permissions.ThePermits.ApplyPayments, xrz.xUser))
            {
                m.Add("Payments");
                m.Add("New Payment");
            }
        }


        public bool isOrderMissingProperties(ContextRz x, nObject o)
        {
            ordhed_sales theSale = null;
            ordhed_quote theQuote = null;


            string objectType = o.GetType().ToString().ToLower();
            switch (objectType)
            {
                case ("rz5.orddet_quote"):
                case ("rz5.orddet_line"):
                    {
                        return isObjectMissingProperties(x, o);
                    }
                case ("rz5.ordhed_quote"):
                case ("rz5.ordhed_sales"):
                    {
                        bool missingHeaderProps = isObjectMissingProperties(x, o);
                        if (missingHeaderProps)
                            return true;

                        if (objectType == "rz5.ordhed_quote")
                        {
                            theQuote = (ordhed_quote)o;
                            foreach (orddet_quote q in theQuote.DetailsList(x))
                                if (isObjectMissingProperties(x, q))
                                    return true;
                        }
                        else if (objectType == "rz5.ordhed_sales")
                        {
                            theSale = (ordhed_sales)o;
                            foreach (orddet_line l in theQuote.DetailsList(x))
                                if (isObjectMissingProperties(x, l))
                                    return true;
                        }
                        break;

                    }
                default:
                    return true;
            }
            return false;
        }


        public bool isObjectMissingProperties(ContextRz x, nObject o)
        {
            if (GetMissingPropertiesForObject(x, o, false).Count > 0)
                return true;
            return false;
        }

        private List<string> GetMissingLogics(ContextRz x, nObject o)
        {
            List<string> ret = new List<string>();
            switch (o.GetType().ToString().ToLower())
            {
                case ("rz5.orddet_quote"):
                    {
                        ret = x.TheSysRz.TheQuoteLogic.GetRequiredQuoteDetailLogics(x, (orddet_quote)o);
                        return ret;
                    }
                case ("rz5.ordhed_quote"):
                    {
                        ret = x.TheSysRz.TheQuoteLogic.GetRequiredQuoteHeaderLogics(x, o);
                        return ret;
                    }
                case ("rz5.ordhed_sales"):
                    {
                        ret = x.TheSysRz.TheSalesLogic.GetRequiredSalesHeaderLogics(x, o);
                        return ret;
                    }
                case ("rz5.ordhed_purchase"):
                    {
                        ret = x.TheSysRz.TheSalesLogic.GetRequiredPurchaseHeaderLogics(x, o);
                        return ret;
                    }
                case ("rz5.orddet_line"):
                    {
                        ret = x.TheSysRz.TheSalesLogic.GetRequiredLineLogics(x, o);
                        return ret;
                    }
                default:
                    return ret;
            }
        }



        private List<string> GetRequiredProps(ContextRz x, nObject o)
        {
            List<string> ret = new List<string>();
            switch (o.GetType().ToString().ToLower())
            {
                case ("rz5.orddet_quote"):
                    {
                        orddet_quote q = (orddet_quote)o;
                        if (q.StockType != Enums.StockType.Service) // Service lines don't need this                            
                            ret = x.TheSysRz.TheQuoteLogic.GetRequiredQuoteLineProperties();
                        return ret;
                    }
                case ("rz5.ordhed_quote"):
                    {
                        ret = x.TheSysRz.TheQuoteLogic.GetRequiredQuoteHeaderProperties();
                        return ret;
                    }
                case ("rz5.ordhed_sales"):
                    {
                        ret = x.TheSysRz.TheSalesLogic.GetRequiredSalesHeaderProperties();
                        return ret;
                    }
                case ("rz5.orddet_line"):
                    {
                        orddet_line l = (orddet_line)o;
                        if (!l.fullpartnumber.ToLower().Contains("gcat") && l.StockType != Enums.StockType.Service) // GCAT lines don't need this   
                            ret = x.TheSysRz.TheSalesLogic.GetRequiredLineProperties(o);
                        return ret;
                    }
                default:
                    return ret;
            }
        }

        public List<string> GetMissingPropertiesToList(ContextRz x, ordhed o)
        {

            List<string> ret = new List<string>();
            foreach (KeyValuePair<nObject, List<string>> kvp in o.MissingPropertiesList)
                foreach (string s in kvp.Value)
                    ret.Add(s);
            return ret;
        }




        public Dictionary<nObject, List<string>> GetMissingPropertiesForObject(ContextRz x, nObject o, bool gatherFromUser, bool includePrefix = true)
        {

            Dictionary<nObject, List<string>> ret = new Dictionary<nObject, List<string>>();
            bool propertyUpdated = false;



            string missingProp = "";
            List<string> requiredProps = GetRequiredProps(x, o);
            List<string> missingProps = new List<string>();

            string answer = "";
            if (requiredProps != null)
            {

                List<CoreVarValAttribute> props = o.GetProps(x).Where(w => requiredProps.Contains(w.Name.ToLower())).ToList();
                foreach (CoreVarValAttribute cva in props)
                {
                    missingProp = CheckPropertyForValue(cva, o);
                    if (!string.IsNullOrEmpty(missingProp))
                    {
                        if (gatherFromUser)
                        {
                            answer = GetPropertyValueFromUser(x, cva, o);
                            if (answer != null)
                            {
                                try
                                {
                                    propertyUpdated = SavePropertyFromAnswer(x, cva, answer, o);
                                    if (!propertyUpdated)
                                        missingProps.Add(missingProp);//if the save wansn't successful, add to missing props list.
                                }
                                catch { }

                            }
                            else
                                missingProps.Add(missingProp);

                        }
                        else
                            missingProps.Add(missingProp);
                    }

                }
            }


            //Logics, things that aren't simply missing properties, but require logic checks in code to determine.
            List<string> missingLogics = GetMissingLogics(x, o);
            if (missingLogics.Count > 0)//If there Are missing Logics, add them to missing props
                missingProps.AddRange(missingLogics);

            if (missingProps.Count > 0)
            {
                if (!ret.ContainsKey(o))
                    ret.Add(o, missingProps);
                else ret[o].AddRange(missingProps);
            }
            return ret;
        }













        private static ordhed_sales GetOpportunitySale(ContextRz x, object rzObject)
        {
            //We only update ordheds, dealheaders may not even have a related order, and making changed to batch, should not win over changes to Sales Order.
            //Sales order is the golden standard of data.
            ordhed_sales ret = null;
            if (rzObject is ordhed_sales)
                ret = (ordhed_sales)rzObject;

            else if (rzObject is dealheader)
            {
                dealheader d = (dealheader)rzObject;
                ArrayList saleList = d.GetOrders(x, OrderType.Sales);
                if (saleList == null)
                    return null;
                //List<ordhed_sales> sList = saleList.Cast<ordhed_sales>().ToList();
                //if (sList == null)
                //    return null;
                if (saleList.Count > 1)
                {
                    x.Error("More than one Sales Order was detected for batch# " + d.dealheader_name + ".  Cannot get the related sale to update the opportunity stage.");
                    return null;
                }

                if (saleList.Count == 1)
                    ret = (ordhed_sales)saleList[0];

            }
            else if (rzObject is ordhed)
            {
                ordhed o = (ordhed)rzObject;
                ret = (ordhed_sales)o.GetRelatedSale(x);

            }
            return ret;
        }

        private dealheader GetOpportunityDealheader(ContextRz x, object rzObject)
        {
            dealheader ret = null;
            if (rzObject is dealheader)
                ret = (dealheader)rzObject;

            else if (rzObject is ordhed)
            {
                ordhed o = (ordhed)rzObject;
                ret = o.GetRelatedDealheader(x);
            }

            return ret;
        }

        private ordhed_quote GetOpportunityQuote(ContextRz x, object rzObject)
        {
            ordhed_quote ret = null;
            //Quote Object
            if (rzObject is ordhed_quote)
                ret = (ordhed_quote)rzObject;
            //DealheaderObject
            else if (rzObject is dealheader)
            {
                dealheader d = (dealheader)rzObject;
                ArrayList arrList = d.GetRelatedQuote(x);
                if (arrList != null)
                    if (arrList.Count > 0)
                        ret = (ordhed_quote)arrList[0];
            }

            //Orhded Object
            else if (rzObject is ordhed)
            {
                ordhed o = (ordhed)rzObject;
                ArrayList arrList = o.GetRelatedQuotes(x);
                if (arrList != null)
                    if (arrList.Count > 0)
                        ret = (ordhed_quote)arrList[0];
            }

            return ret;
        }





        //public Dictionary<string, string> GenerateBaseHubspotDealProperties(ContextRz x, object rzObject)
        //{



        //    Dictionary<string, string> props = new Dictionary<string, string>();
        //    string hubspot_owner_id = "";
        //    string createdate = "";
        //    string dealstageName = "";
        //    string dealstageID = "";
        //    string rz_agent_id = "";
        //    string rz_company_id = "";
        //    string rz_contact_id = "";
        //    string rz_batch_id = "";
        //    string rz_batch_name = "";
        //    string rz_sales_id = "";
        //    string rz_sales_number = "";
        //    string rz_invoice_id = "";
        //    string rz_invoice_number = "";
        //    string rz_quote_id = "";
        //    string rz_quote_number = "";
        //    string opportunity_lost_reason = "";
        //    string affiliate_id = "";



        //    if (rzObject is dealheader)
        //    {

        //        dealheader d = (dealheader)rzObject;
        //        if (d == null)
        //            return null;
        //        rz_agent_id = d.base_mc_user_uid;
        //        rz_company_id = d.customer_uid;
        //        rz_contact_id = d.contact_uid;
        //        rz_batch_id = d.unique_id;
        //        rz_batch_name = d.dealheader_name;
        //        dealstageName = d.opportunity_stage;
        //        dealstageID = HubspotApi.Deals.GetDealStageIDFromDealStageName(d.opportunity_stage);
        //        createdate = HubspotApi.ConvertDateTimeToUnixTimestampMillis(d.date_created).ToString();
        //        opportunity_lost_reason = d.ClosureReason;
        //    }
        //    else if (rzObject is ordhed_quote || rzObject is ordhed_sales || rzObject is ordhed_invoice)
        //    {
        //        ordhed o = (ordhed)rzObject;
        //        if (o == null)
        //            return null;
        //        rz_agent_id = o.base_mc_user_uid;
        //        rz_company_id = o.base_company_uid;
        //        rz_contact_id = o.base_companycontact_uid;
        //        dealstageName = o.opportunity_stage;
        //        dealstageID = GetHubsotDealStageFromRzOpportunityStage(x, rzObject);
        //        opportunity_lost_reason = o.opportunity_lost_reason;
        //        if (rzObject is ordhed_quote)
        //        {
        //            rz_quote_id = o.unique_id;
        //            rz_quote_number = o.ordernumber;
        //        }
        //        else if (rzObject is ordhed_sales)
        //        {
        //            rz_sales_id = o.unique_id;
        //            rz_sales_number = o.ordernumber;
        //        }
        //        else if (rzObject is ordhed_invoice)
        //        {
        //            rz_invoice_id = o.unique_id;
        //            rz_invoice_number = o.ordernumber;
        //        }
        //    }

        //    //Owner
        //    HubspotApi.Owner hubOwner = HubspotLogic.GetHubspotDealOwner(rz_agent_id);
        //    if (hubOwner != null)
        //        hubspot_owner_id = hubOwner.ownerId.ToString();

        //    //Affiliate ID
        //    affiliate_id = GetAffiliateID_OrderObject(x, rzObject);

        //    //Check fro null/empty, else empty values will overwrite existing.
        //    if (!string.IsNullOrEmpty(hubspot_owner_id))
        //        props.Add("hubspot_owner_id", hubspot_owner_id);
        //    if (!string.IsNullOrEmpty(rz_agent_id))
        //        props.Add("rz_agent_id", rz_agent_id);
        //    if (!string.IsNullOrEmpty(rz_company_id))
        //        props.Add("rz_company_id", rz_company_id);
        //    if (!string.IsNullOrEmpty(rz_contact_id))
        //        props.Add("rz_contact_id", rz_contact_id);
        //    //if (!string.IsNullOrEmpty(part_number))
        //    //    props.Add("part_number", part_number);
        //    //if (!string.IsNullOrEmpty(manufacturer))
        //    //    props.Add("manufacturer", manufacturer);
        //    if (!string.IsNullOrEmpty(dealstageID))
        //        props.Add("dealstage", dealstageID);
        //    //Don't check null here, opp lost just overwrites
        //    props.Add("closed_lost_reason", opportunity_lost_reason);
        //    if (!string.IsNullOrEmpty(rz_batch_id))
        //        props.Add("rz_batch_id", rz_batch_id);
        //    if (!string.IsNullOrEmpty(rz_batch_name))
        //        props.Add("rz_batch_name", rz_batch_name);
        //    if (!string.IsNullOrEmpty(rz_quote_id))
        //        props.Add("rz_quote_id", rz_quote_id);
        //    if (!string.IsNullOrEmpty(rz_quote_number))
        //        props.Add("rz_quote_number", rz_quote_number);
        //    if (!string.IsNullOrEmpty(rz_sales_id))
        //        props.Add("rz_sales_id", rz_sales_id);
        //    if (!string.IsNullOrEmpty(rz_sales_number))
        //        props.Add("rz_sales_number", rz_sales_number);
        //    if (!string.IsNullOrEmpty(rz_invoice_id))
        //        props.Add("rz_invoice_id", rz_invoice_id);
        //    if (!string.IsNullOrEmpty(rz_invoice_number))
        //        props.Add("rz_invoice_number", rz_invoice_number);
        //    if (!string.IsNullOrEmpty(createdate))
        //        props.Add("createdate", createdate);
        //    if (!string.IsNullOrEmpty(affiliate_id))
        //        props.Add("affiliate_id", affiliate_id);
        //    return props;


        //}










        ////Hubspot Management
        //public HubspotApi.Deal CreateHubspotDeal(ContextRz x, object rzObject)
        //{

        //    string errorMessage = "Cannot create Hubspot Deal.  ";
        //    //Original create Date

        //    //Confirm Valid Contact ID
        //    string contactID = null;
        //    //Get the object's agent ID, confirm they are Hubspot enabled
        //    string agentID = null;

        //    //Get the Rz Object Type
        //    if (rzObject is ordhed)
        //    {
        //        ordhed o = (ordhed)rzObject;
        //        contactID = o.base_companycontact_uid;
        //        agentID = o.base_mc_user_uid;

        //    }
        //    else if (rzObject is dealheader)
        //    {
        //        dealheader d = (dealheader)rzObject;
        //        contactID = d.contact_uid;
        //        agentID = d.base_mc_user_uid;

        //    }

        //    //Alert and return if no valid Agent ID
        //    if (string.IsNullOrEmpty(agentID))
        //    {
        //        x.Leader.Error(errorMessage + "Agent ID not found for this order.");
        //        return null;
        //    }
        //    //Alert and return if no valid Agent
        //    n_user u = n_user.GetById(x, agentID);
        //    if (u == null)
        //    {
        //        x.Leader.Error(errorMessage + "Rz User not found with id: " + agentID);
        //        return null;
        //    }

        //    //Do nothing if owning agent is not Hubspot enabeld.
        //    if (!u.is_hubspot_enabled)
        //        return null;


        //    //Alert and return if no valid contact ID
        //    if (string.IsNullOrEmpty(contactID))
        //    {
        //        x.Leader.Error(errorMessage + "Contact ID not set for this order.");
        //        return null;
        //    }

        //    //Confirm Actual contact associated with the ID we found
        //    companycontact theContact = companycontact.GetById(x, contactID);
        //    if (theContact == null)
        //    {
        //        x.Leader.Error(errorMessage + "The system was unable to find the contact related to this order (contact uid = '" + contactID + "').");
        //        return null;
        //    }

        //    //Confirm Valid Contact Email Address
        //    if (string.IsNullOrEmpty(theContact.primaryemailaddress))
        //    {
        //        x.Leader.Error(errorMessage + "No email address exists in Rz for " + theContact.contactname + ".");
        //        return null;
        //    }
        //    if (!Email.IsEmailAddress(theContact.primaryemailaddress))
        //    {
        //        x.Leader.Error(errorMessage + theContact.primaryemailaddress + " is not a valid email address.");
        //        return null;
        //    }


        //    //Generate the associations
        //    HubspotApi.Associations ass = HubspotApi.Deals.CreateDealAssociations(theContact.primaryemailaddress);
        //    if (ass == null)
        //    {
        //        bool createContact = false;
        //        createContact = x.Leader.AskYesNo(theContact.primaryemailaddress + " is not a valid Hubspot Contact.  Would you like to add it?");
        //        if (createContact)
        //        {
        //            //Add this contact and associate with this Hubspot User.
        //            HubspotApi.Contact hsContact = x.TheSysRz.TheOrderLogic.CreateHubspotContact(x, theContact, HubspotApi.Contacts.ContactSource.RzDealCreated);
        //            ass = HubspotApi.Deals.CreateDealAssociations(theContact.primaryemailaddress);
        //            if (ass == null)
        //            {
        //                x.Leader.Error(errorMessage + "error creating Hubspot deal associations for " + theContact.primaryemailaddress + ".  Is this the right email address for the contact?");
        //                return null;
        //            }
        //        }
        //        else
        //        { return null; }

        //    }

        //    //Generate the Properties
        //    Dictionary<string, string> props = HubspotLogic.GenerateBaseHubspotDealProperties(rzObject);

        //    //Handle Rz-specific property logic
        //    props = HubspotLogic.GenerateRzHubspotProperties(rzObject, props);

        //    //On Create Only, set the businesstype
        //    string businessType = HubspotLogic.GetHubpsotDealBusinessType(theContact.primaryemailaddress);
        //    props.Add("dealtype", businessType);

        //    if (props == null)
        //    {
        //        x.Leader.Error(errorMessage + "error creating Hubspot deal properties for the rzObject.");
        //        return null;
        //    }

        //    //Create the Deal
        //    //HubspotApi hsa = new HubspotApi();
        //    //Tag source as  "rz_generated" for all quotes foming from OrderLogic.
        //    //"quote_source" may be in use wtih other marketing fields.  Need to confirm with them 1st
        //    //props.Add("quote_source", "rz_generated");

        //    HubspotApi.Deal ret = HubspotApi.Deals.CreateDeal(ass, props);


        //    if (ret != null)
        //    {
        //        if (ret.dealId > 0)
        //            HubspotLogic.GetAndSyncRelatedHubspotID(rzObject, ret.dealId);
        //    }


        //    return ret;

        //}
        //public HubspotApi.Deal UpdateHubspotDeal(ContextRz x, object rzObject)
        //{
        //    long dealID = 0;
        //    bool isRzOpportunityLost = false;
        //    bool isHubspotDealLost = false;

        //    //Check to see if the Rz Object is Closed
        //    if (rzObject is dealheader)
        //    {
        //        dealheader d = (dealheader)rzObject;
        //        if (d != null)
        //        {

        //            dealID = d.hubspot_deal_id;
        //            isRzOpportunityLost = d.is_closed;
        //        }

        //    }
        //    if (rzObject is ordhed)
        //    {
        //        ordhed o = (ordhed)rzObject;
        //        if (o != null)
        //        {
        //            dealID = o.hubspot_deal_id;
        //            isRzOpportunityLost = o.isclosed;
        //        }

        //    }

        //    //Valid Deal ID?
        //    if (dealID <= 0)
        //        return null;

        //    //Get the deal to check for certain properties
        //    HubspotApi.Deal ret = HubspotApi.Deals.GetDealByID(dealID);//This will never be null, need to check DealID
        //    if (ret.dealId <= 0)
        //        return null;



        //    //If Object closed in Hubspot but still open in Rz, Check if deal has been closed, if so, close Rz Deal    
        //    string currentHsDealStageID = ret.properties.Where(w => w.Key == "dealstage").Select(s => s.Value.value).FirstOrDefault();
        //    string currentHsDealStage = HubspotApi.Deals.GetDealStageNameFromDealStageID(currentHsDealStageID);
        //    string sales_lost_reason = ret.properties.Where(w => w.Key == "closed_lost_reason").Select(s => s.Value.value).FirstOrDefault();
        //    //if (!string.IsNullOrEmpty(sales_lost_reason))
        //    if (currentHsDealStage == HubspotApi.DealStage.sale_lost)
        //        isHubspotDealLost = true;
        //    //If this has been closed in Hubspot
        //    if (isHubspotDealLost)
        //    { //IF it's already closed in Rz, don't update deal
        //        if (isRzOpportunityLost)
        //            return ret;
        //        //Offer to close it
        //        else if (HubspotLogic.CheckCloseRzObjectFromHubspot(rzObject, ret))//If close successful, return null to halt deal update.
        //            return null;
        //        return ret;
        //    }


        //    //Get the base properties for the deal
        //    Dictionary<string, string> props = HubspotLogic.GenerateBaseHubspotDealProperties(rzObject);
        //    //Handle Rz-specific property logic
        //    props = HubspotLogic.GenerateRzHubspotProperties(rzObject, props);
        //    if (props == null)
        //        return null;

        //    //Update the deal
        //    ret = HubspotApi.Deals.UpdateDeal(dealID, props);
        //    if (ret != null)
        //    {
        //        if (ret.dealId > 0)
        //            HubspotLogic.GetAndSyncRelatedHubspotID(rzObject, ret.dealId);
        //    }

        //    return ret;
        //}
        //private static string GetHubsotDealStageFromRzOpportunityStage(ContextRz x, object rzObject)
        //{

        //    string strOppStage = "";
        //    if (rzObject is dealheader)
        //    {
        //        dealheader d = (dealheader)rzObject;
        //        strOppStage = d.opportunity_stage;
        //    }

        //    if (rzObject is ordhed)
        //    {
        //        ordhed o = (ordhed)rzObject;
        //        if (string.IsNullOrEmpty(o.opportunity_stage))//not identified on ordhed, let's derive from sale order.  If it's an invoice, it can't be voided, so unless it's a voided sale we're loading opp stage should be sale won. 
        //        {
        //            //Formal Quote, might be voided
        //            if (o is ordhed_quote && o.isvoid == true)
        //                o.opportunity_stage = OpportunityStage.sale_lost.ToString();
        //            //Sales Order might be voided
        //            else if (o is ordhed_sales && o.isvoid == true)
        //                o.opportunity_stage = OpportunityStage.sale_lost.ToString();
        //            else
        //                o.opportunity_stage = OpportunityStage.sale_won.ToString();
        //            o.Update(x);
        //            strOppStage = o.opportunity_stage;
        //        }
        //        else
        //            strOppStage = o.opportunity_stage;

        //    }


        //    if (strOppStage.ToLower().Trim().Contains("won"))
        //        return HubspotApi.DealStage.sale_won;
        //    else if (strOppStage.ToLower().Trim().Contains("lost"))
        //        return HubspotApi.DealStage.sale_lost;
        //    else if (strOppStage.ToLower().Trim().Contains("created"))
        //        return HubspotApi.DealStage.formal_quote_created;
        //    else if (strOppStage.ToLower().Trim().Contains("rfq"))
        //        return HubspotApi.DealStage.rfq_received;

        //    return null;
        //}
        //private HubspotApi.Contact CreateHubspotContact(ContextRz x, companycontact c, string contactSource)
        //{
        //    SystemLogic.Logs.LogEvent(SM_Enums.LogType.Information, "Creating Hubspot contact for " + c.primaryemailaddress, true, "Rz");
        //    Dictionary<string, string> props = GenerateHubspotContactProperties(x, c);
        //    //We'll want the Hubspot Owner right?  Probably expecially if no company existis at ALL in HS, would nee to link it to a user.


        //    //string ownerEmail = GetHubspotOwnerEmailFromRzObject(x, c);
        //    //if (string.IsNullOrEmpty(ownerEmail))
        //    //    return null;


        //    if (props == null)
        //        return null;
        //    string message = "<b>Details</b><br />";
        //    foreach (KeyValuePair<string, string> kvp in props)
        //    { message += kvp.Key + ": " + kvp.Value + "<br />"; }


        //    HubspotApi.Contact ret = HubspotApi.Contacts.CreateHubspotContact(props, contactSource);
        //    if (ret.Properties == null)
        //        return null;
        //    SystemLogic.Logs.LogEvent(SM_Enums.LogType.Information, "Rz Deal: Hubspot Contact successfully created for " + c.primaryemailaddress + " (VID: " + ret.vid + ")", true, "Rz");
        //    SystemLogic.Email.SendMail(SystemLogic.Email.EmailGroupAddress.RzAlert, SystemLogic.Email.EmailGroup.Systems, "HubSpot contact created via Rz Deal Sync: " + c.primaryemailaddress, message);
        //    HubspotApi.Associations ass = HubspotApi.Deals.CreateDealAssociations(c.primaryemailaddress);
        //    return ret;


        //}
        //private Dictionary<string, string> GenerateHubspotContactProperties(ContextRz x, companycontact c)
        //{
        //    Dictionary<string, string> props = new Dictionary<string, string>();

        //    //FirstName *Required
        //    KeyValuePair<string, string> kvp = GenerateHubspotContactProperty(x, c, "firstname");
        //    if (string.IsNullOrEmpty(kvp.Value))
        //        return null;
        //    props.Add(kvp.Key, kvp.Value);

        //    //Email *Required
        //    kvp = GenerateHubspotContactProperty(x, c, "email");
        //    if (string.IsNullOrEmpty(kvp.Value))
        //        return null;
        //    props.Add(kvp.Key, kvp.Value);

        //    //website
        //    kvp = GenerateHubspotContactProperty(x, c, "website");
        //    if (!string.IsNullOrEmpty(kvp.Value))
        //        props.Add(kvp.Key, kvp.Value);

        //    //lastname
        //    kvp = GenerateHubspotContactProperty(x, c, "lastname");
        //    if (!string.IsNullOrEmpty(kvp.Value))
        //        props.Add(kvp.Key, kvp.Value);


        //    return props;
        //}
        //private KeyValuePair<string, string> GenerateHubspotContactProperty(ContextRz x, companycontact c, string key)
        //{


        //    string value = null;
        //    string valueText = null;
        //    List<string> requiredContactProperties = new List<string>() { "email", "firstname" };

        //    switch (key)
        //    {
        //        case "firstname":
        //            {
        //                value = c.first_name.Trim().ToLower();
        //                value = Strings.CapitalizeFirstLetter(value);
        //                valueText = "first name";
        //                break;
        //            }
        //        case "email":
        //            {
        //                value = c.primaryemailaddress.Trim().ToLower();
        //                valueText = "email address";
        //                break;
        //            }
        //        case "lastname":
        //            {
        //                var names = c.contactname.Split(' ');
        //                if (names.Length > 1)
        //                {
        //                    value = Strings.CapitalizeFirstLetter(value);
        //                    valueText = "last name";
        //                }
        //                else
        //                    return new KeyValuePair<string, string>();//retun null if no last name
        //                break;
        //            }
        //        case "website":
        //            {
        //                MailAddress address = new MailAddress(c.primaryemailaddress);
        //                string website = address.Host.Trim().ToLower();
        //                value = website;
        //                valueText = "website";
        //                break;
        //            }
        //            //case "company":
        //            //    {
        //            //        string company = c.companyname.Trim().ToLower();
        //            //        value = c.companyname.Trim().ToLower();
        //            //        valueText = "email address";
        //            //        break;
        //            //    }

        //    }

        //    //first name and email are required
        //    if (requiredContactProperties.Contains(key))
        //    {
        //        if (string.IsNullOrEmpty(value))
        //            value = x.Leader.AskForString("Please enter a " + valueText + " for this contact.");
        //        if (String.IsNullOrEmpty(value))
        //        {
        //            x.Leader.Error("Sorry, cannot create hubspot deal without the " + valueText);
        //            return new KeyValuePair<string, string>();
        //        }
        //    }







        //    KeyValuePair<string, string> ret = new KeyValuePair<string, string>(key, value);
        //    return ret;
        //}
        //private string GetHubspotOwnerEmailFromRzObject(ContextRz x, object rzObject)
        //{

        //    string ownerRzUserID = null;

        //    if (rzObject is dealheader)
        //    {
        //        dealheader d = (dealheader)rzObject;
        //        ownerRzUserID = d.base_mc_user_uid;
        //    }

        //    else if (rzObject is ordhed)
        //    {
        //        ordhed o = (ordhed)rzObject;
        //        ownerRzUserID = o.base_mc_user_uid;
        //    }
        //    else if (rzObject is companycontact)
        //    {
        //        companycontact cc = (companycontact)rzObject;
        //        ownerRzUserID = cc.base_mc_user_uid;
        //    }

        //    n_user u = n_user.GetById(x, ownerRzUserID);
        //    if (u == null)
        //        return null;

        //    //Vendors shold be assigned to Phil
        //    if (u.Name == "Vendor")
        //        return "pscott@sensiblemicro.com";

        //    if (!Email.IsEmailAddress(u.email_address))
        //        return null;


        //    return u.email_address.ToLower().Trim();
        //}
        public HubspotApi.Deal LoadHubspotDealControls(ContextRz x, GroupBox gb, LinkLabel lbl, object rzObject)
        {
            //Instantiate the return variable
            HubspotApi.Deal ret = null;
            //if (!x.xUserRz.is_hubspot_enabled)
            //    return null;
            //HubID Variable
            long hubID = 0;


            //Global Variables, check them for null to do logics.
            dealheader d = null;
            ordhed_quote q = null;
            ordhed_sales s = null;
            ordhed_invoice i = null;


            if (rzObject is dealheader)
            {   //dealheader
                d = (dealheader)rzObject;
                if (d == null)
                {
                    x.Error("Unable to retrieve dealheder for " + rzObject.ToString() + " Type: " + rzObject.GetType().ToString());
                    return null;
                }
                hubID = d.hubspot_deal_id;
            }
            else
            {
                //It's an ordhed, use ordertype to target Sales and Invoices and pull Hub ID Appropriately
                ordhed o = (ordhed)rzObject;
                if (o == null)
                {
                    x.Error("Unable to retrieve order object for " + rzObject.ToString() + " Type: " + rzObject.GetType().ToString());
                    return null;
                }
                switch (o.OrderType)
                {
                    case Enums.OrderType.Quote:
                        {
                            q = (ordhed_quote)rzObject;
                            if (q == null)
                            {
                                x.Error("Unable to retrieve sales order object for " + rzObject.ToString() + " Type: " + rzObject.GetType().ToString());
                                return null;
                            }
                            hubID = q.hubspot_deal_id;
                            break;
                        }
                    case Enums.OrderType.Sales:
                        {
                            s = (ordhed_sales)rzObject;
                            if (s == null)
                            {
                                x.Error("Unable to retrieve sales order object for " + rzObject.ToString() + " Type: " + rzObject.GetType().ToString());
                                return null;
                            }
                            hubID = s.hubspot_deal_id;
                            break;
                        }
                    case Enums.OrderType.Invoice:
                        {
                            i = (ordhed_invoice)rzObject;
                            if (i == null)
                            {
                                x.Error("Unable to retrieve invoice order object for " + rzObject.ToString() + " Type: " + rzObject.GetType().ToString());
                                return null;
                            }
                            hubID = i.hubspot_deal_id;
                            break;
                        }
                }
            }

            ////At this point, we may have an orphaned order, where there is a dealheader with a hubID, but the related quotes haven't been tagged:
            //if(hubID <= 0)



            //By this time we should have a valid HubID, if one exists, else return null
            if (hubID <= 0)
            {
                //x.Error("The System returned an invalid Hubspot Deal ID: " + hubID);
                //lbl.Text = "<not set>";
                lbl.Visible = false;
                return null;
            }

            //Fetch the deal from Hubpsot API                     
            ret = HubspotApi.Deals.GetDealByID(hubID);
            if (ret == null)
            {
                x.Error("Hubspot API call returned a null Deal: " + hubID);
                return null;
            }
            if (ret.dealId <= 0)
            {
                //Offer to clear the probably-deleted hubspot deal association
                if (x.Leader.AskYesNo(hubID + " is not a valid Hubspot Deal ID, it may have been deleted.  Would you like to remove this link? "))
                {

                    if (d != null)
                    {
                        d.hubspot_deal_id = 0;
                        d.Update(x);
                    }
                    else if (q != null)
                    {
                        q.hubspot_deal_id = 0;
                        q.Update(x);
                    }
                    else if (s != null)
                    {
                        s.hubspot_deal_id = 0;
                        s.Update(x);
                    }
                    else if (i != null)
                    {
                        i.hubspot_deal_id = 0;
                        i.Update(x);
                    }

                }
                else
                {
                    x.Error("Hubspot API call returned an invalid dealID: " + ret.dealId);

                }

                return null;
            }

            //Deal successfully retrieved, load UI Values.
            lbl.Text = ret.dealId.ToString();
            lbl.Visible = true;
            //gb.Visible = true;
            return ret;
        }

        ////End Hubspot Management


        //Opportunity Management
        public void SetOpportunityOpen(ContextRz x, object rzObject)
        {
            if (rzObject is dealheader)//dealheader
                SetOpportunityOpen_Dealheader(x, (dealheader)rzObject);
            else //ordhed
            {
                ordhed o = (ordhed)rzObject;
                if (o == null)
                {
                    x.Leader.Error("Unable to retrieve ordhed object from " + rzObject.ToString() + " Type: " + rzObject.GetType());
                    return;
                }
                SetOpportunityOpen_Ordhed(x, o);
            }

        }

        private void SetOpportunityOpen_Ordhed(ContextRz x, ordhed o)
        {
            //if (o.opportunity_lost_reason != "Sale Voided")
            //{

            o.opportunity_stage = OpportunityStage.sale_won.ToString();
            o.opportunity_lost_reason = null;
            o.isclosed = false;
            o.Update(x);
            //}
        }

        private void SetOpportunityOpen_Dealheader(ContextRz x, dealheader currentBatch)
        {
            currentBatch.opportunity_stage = OpportunityStage.rfq_received.ToString();
            currentBatch.ClosureReason = null;
            currentBatch.is_closed = false;
            currentBatch.Update(x);
        }

        public bool SetOpportunityLost(ContextRz x, object rzObject, string inputReason, out string outPutReason)
        {
            outPutReason = "";
            string selectedReason = inputReason;
            if (string.IsNullOrEmpty(selectedReason))
                selectedReason = x.Leader.ChooseOneChoice(x, "opportunity_lost_reason", "Please choose a reason:");


            if (String.IsNullOrEmpty(selectedReason))
            {
                x.Leader.Error("You must choose a reason. ");
                return false;
            }



            if (rzObject is dealheader)
                SetOpportunityLost_dealheader(x, (dealheader)rzObject, selectedReason);
            else if (rzObject is ordhed)
                SetOpportunityLost_ordhed(x, (ordhed)rzObject, selectedReason);
            outPutReason = selectedReason;
            return true;
        }


        public static void SetOpportunityLost_ordhed(ContextRz x, ordhed o, string lostReason)
        {
            //ordhed_quote q = rdc.ordhed_quotes.Where(w => w.unique_id == o.unique_id).FirstOrDefault();
            o.opportunity_stage = SM_Enums.OpportunityStage.sale_lost.ToString();
            o.opportunity_lost_reason = lostReason;
            o.isclosed = true;
            o.Update(x);

        }


        public static void SetOpportunityLost_dealheader(ContextRz x, dealheader currentBatch, string lostReason)
        {
            //dealheader dh = (dealheader)currentBatch;
            //Mark the Quote Lost  
            currentBatch.opportunity_stage = SM_Enums.OpportunityStage.sale_lost.ToString();
            currentBatch.ClosureReason = lostReason;
            currentBatch.is_closed = true;
            //currentBatch.Update(x);
            //x.Update(currentBatch);
            currentBatch.Update(x);



        }




        private string GetPrefixByObjectType(nObject o)
        {
            if (o is orddet_line)
            {
                orddet_line line = (orddet_line)o;
                return "#" + line.linecode_sales.ToString();
            }
            else if (o is orddet_quote)
            {
                orddet_quote line = (orddet_quote)o;
                return "#" + line.linecode.ToString();
            }
            //else if (o is ordhed_sales || o is ordhed_quote)
            //{
            //    return "Header: ";
            //}
            return null;

        }

        private bool SavePropertyFromAnswer(ContextRz x, CoreVarValAttribute cva, string answer, nObject o)
        {
            //If the answer is valid, identify the appropriate type, then save it using the appropriate method, else, add the missing data into the dictionary.   
            bool propertyChanged = false;
            switch (cva.TheFieldType.ToString().ToLower())
            {
                case "string":
                    {
                        o.GetType().GetProperty(cva.Name).SetValue(o, answer, null);
                        propertyChanged = true;
                        break;
                    }
                case "int32":
                case "int64":
                    {
                        Int32 answerInt32;
                        bool isInt = Int32.TryParse(answer, out answerInt32); // Check for Ints 1st , this will catch doubles with no decimals?
                        if (isInt)
                            o.GetType().GetProperty(cva.Name).SetValue(o, answerInt32, null);
                        propertyChanged = true;
                        break;
                    }

                case "double":
                    {
                        double answerDouble;
                        bool isDouble = double.TryParse(answer, out answerDouble);
                        if (isDouble)
                            o.GetType().GetProperty(cva.Name).SetValue(o, answerDouble, null);
                        propertyChanged = true;
                        break;
                    }
                case "datetime":
                    {
                        if (answer != "1/1/1900")
                        {
                            DateTime dt;
                            DateTime.TryParse(answer, out dt);
                            o.GetType().GetProperty(cva.Name).SetValue(o, dt, null);
                            propertyChanged = true;

                        }
                        break;
                    }
            }


            if (propertyChanged)
            {
                o.Update(x);
                //propertyChanged = false;//reset it for the next loop.
            }

            return propertyChanged;

        }



        public double ApplyDistySalesStockCost(ContextRz context, orddet_quote q)
        {
            double total = q.unitprice;
            //as of 5-16-2018, current rules for Disty Sales selling zero cost stock, is to apply cost as 2% of overall quote amount.
            double ret = 0;
            ret = total * .02;
            return ret;
        }


        private string GetPropertyValueFromUser(ContextRz x, CoreVarValAttribute cva, object o)
        {
            string type = o.GetType().ToString();
            string answer = "";
            Dictionary<string, string> properties = new Dictionary<string, string>();//Generic properties to use on datepicker (to identify what you are picking date for, etc)
            switch (type)
            {
                case ("Rz5.ordhed_quote"):
                    {
                        switch (cva.Name)
                        {

                            case "shipvia":
                                {
                                    answer = x.TheLeaderRz.ChooseOneChoice(x, "shipvia", "Please Choose a ShipVia");
                                    break;

                                }
                            case "contactname":
                                {

                                    break;
                                }
                            case "opportunity_type":
                                {
                                    answer = x.TheLeaderRz.ChooseOneChoice(x, "opportunity_type", "Please Set the Opportunity Type");
                                    break;

                                }
                        }
                        break;
                    }
                case ("Rz5.orddet_quote"):
                    {
                        orddet detail = (orddet)o;
                        orddet_quote oq = (orddet_quote)o;
                        string captionPrefix = oq.fullpartnumber + " (Line" + oq.linecode + "): ";
                        switch (cva.Name)
                        {
                            case "fullpartnumber":
                                {
                                    answer = x.Leader.AskForString(captionPrefix + "Part Number").ToUpper();
                                    break;
                                }
                            case "quantityordered":
                            case "target_quantity":
                                {
                                    bool validateInt32 = false;
                                    while (validateInt32 == false)
                                    {
                                        Int32 answerInt32;
                                        answer = x.Leader.AskForString(captionPrefix + cva.Name, null);
                                        if (string.IsNullOrEmpty(answer))
                                            return null;
                                        validateInt32 = Int32.TryParse(answer, out answerInt32);
                                        if (!validateInt32)
                                            x.Leader.Tell("'" + answer + "' is not a Number ... Please provide an number or decimal value");
                                    }
                                    break;
                                }

                            case "internalpartnumber":
                                {
                                    answer = x.TheLeader.AskForString("There is no internal partnumber, please add one now.", detail.fullpartnumber, false).Trim().ToUpper();
                                    //        if (!Tools.Strings.StrExt(s))
                                    //            //q.internalpartnumber = "N/A";
                                    //            q.internalpartnumber = q.fullpartnumber;
                                    //if (x.Leader.AskYesNo(captionPrefix + "Missing Internal Part Number.  Would you like to auto-fill the MPN (" + detail.fullpartnumber + ")?"))
                                    //    answer = detail.fullpartnumber;
                                    //else
                                    //    answer = x.Leader.AskForString(captionPrefix + "Please provide the Internal Part Number:").ToUpper();
                                    break;

                                }
                            case "manufacturer":
                            case "target_manufacturer":
                                {
                                    answer = x.Leader.AskForString(captionPrefix + cva.Name).ToUpper();
                                    break;
                                }
                            case "rohs_info":
                                {
                                    answer = x.TheLeaderRz.ChooseOneChoice(x, "rohs_info", captionPrefix + "RoHS Info");
                                    break;
                                }
                            case "condition":
                            case "target_condition":
                                {
                                    answer = x.TheLeaderRz.ChooseOneChoice(x, "condition", captionPrefix + cva.Name);
                                    break;
                                }
                            case "datecode":
                            case "target_datecode":
                                {
                                    answer = x.Leader.AskForString(captionPrefix + cva.Name).ToUpper();
                                    break;
                                }
                            case "delivery":
                            case "target_delivery":
                                {
                                    answer = x.TheLeaderRz.ChooseOneChoice(x, "delivery", captionPrefix + cva.Name + " (Lead Time)");
                                    break;
                                }
                            case "target_price":
                            case "unitprice":
                                {

                                    bool validateDouble = false;
                                    while (validateDouble == false)
                                    {
                                        double answerDouble;
                                        answer = x.Leader.AskForString(captionPrefix + "Unit Price:", null);
                                        if (string.IsNullOrEmpty(answer))
                                            return null;
                                        validateDouble = double.TryParse(answer, out answerDouble);
                                        if (!validateDouble)
                                            x.Leader.Tell("'" + answer + "' is not a Number ... Please provide an number or decimal value");
                                    }
                                    break;
                                }
                            case "unitcost":
                                {

                                    bool validateDouble = false;
                                    while (validateDouble == false)
                                    {
                                        double answerDouble;
                                        answer = x.Leader.AskForString(captionPrefix + "Unit Cost:", null);
                                        if (string.IsNullOrEmpty(answer))
                                            return null;
                                        validateDouble = double.TryParse(answer, out answerDouble);
                                        if (!validateDouble)
                                            x.Leader.Tell("'" + answer + "' is not a Number ... Please provide an number or decimal value");
                                    }
                                    break;
                                }

                                //Quote Setup Details




                        }
                        break;

                    }
                case ("Rz5.orddet_line"):
                    {
                        orddet detail = (orddet)o;
                        orddet_line l = (orddet_line)o;
                        string prop = cva.Name.ToLower();

                        string caption = prop + " (Line " + l.linecode_sales.ToString() + ")";
                        properties.Add("fullpartnumber", l.fullpartnumber);
                        properties.Add("quantity", l.quantity.ToString());
                        properties.Add("linecode_sales", l.linecode_sales.ToString());


                        switch (prop)
                        {
                            case "customer_dock_date":
                                {

                                    answer = x.TheLeaderRz.AskForDate(caption, DateTime.MinValue, properties).ToShortDateString();
                                    break;
                                }
                            case "shipvia_invoice":
                            case "shipvia_purchase":
                                {
                                    answer = x.TheLeaderRz.ChooseOneChoice(x, "shipvia", "Please Choose a ShipVia").ToString();
                                    break;
                                }
                            case "rohs_info_vendor":
                            case "rohs_info":
                                {
                                    answer = x.TheLeaderRz.ChooseOneChoice(x, "rohs_info", "Please set RoHS Status").ToString();
                                    break;
                                }
                            case "condition":
                                {
                                    answer = x.TheLeaderRz.ChooseOneChoice(x, "condition", "Please set the condition").ToString();
                                    break;
                                }
                            case "fullpartnumber":
                            case "manufacturer":
                            case "datecode":
                            case "datecode_purchase":
                                {
                                    answer = x.Leader.AskForString(caption, null);
                                    break;
                                }

                            case "quantity":
                                {
                                    bool cancel = false;
                                    answer = x.Leader.AskForDouble(caption, 0.00, "Quantity", ref cancel).ToString();
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        //If no rules how to handle, just return null, and the system will just prompt the user to go fill it out. I.e. Contact Selection.
                        answer = null;
                        break;
                    }
            }

            if (!string.IsNullOrEmpty(answer))
                return answer;
            return null;
        }



        //public bool CheckDetailData(ContextRz context, List<orddet> details, Enums.OrderType orderType)
        //{

        //    switch (orderType)
        //    {
        //        case Enums.OrderType.Quote:
        //            {
        //                if (context.TheSysRz.TheReqLogic.CheckReqData(context,details).Count > 0)
        //                    return false;
        //                return true;
        //            }
        //    }

        //    return true;
        //}


        private string CheckPropertyForValue(CoreVarValAttribute attr, object o)
        {
            //string ret = "";
            //CheckType = Especially DateTIme

            var nameOfProperty = attr.Name;
            var propertyInfo = o.GetType().GetProperty(nameOfProperty);
            var value = propertyInfo.GetValue(o, null);
            //Check DateTime (since null has a value)

            DateTime dateTime;
            if (DateTime.TryParse(value.ToString(), out dateTime))
                if (value.ToString() == "1/1/1900 12:00:00 AM")
                    return nameOfProperty;



            if (string.IsNullOrEmpty(value.ToString()))
                return nameOfProperty;
            if (value.ToString() == "0")//for Int check for 0
                return nameOfProperty;
            return null;
            //return ret;
        }
        //End Order Data Property Check System


        protected virtual void VoidAdd(ContextRz context, ActSetup m)
        {
            bool allVoid = true;
            bool allNotVoid = true;
            bool allEditable = true;
            foreach (IItem b in m.TheItems.AllGet(context))
            {
                ordhed h = (ordhed)b;
                if (h.isvoid)
                    allNotVoid = false;
                else
                    allVoid = false;

                if (!h.CanBeEditedBy(context, new ShowArgs(context, h)))
                    allEditable = false;
            }

            if (allEditable || context.TheSysRz.ThePermitLogic.CheckPermit(context, Permissions.ThePermits.VoidAllOrders, ((ContextRz)context).xUser))
            {
                if (allVoid)
                    m.Add("UnVoid");
                else if (allNotVoid)
                    m.Add("Void");
            }
        }





        public override void ActInstance(Context context, ActArgs args)
        {
            List<ordhed> oList = new List<ordhed>();
            foreach (IItem i in args.TheItems.AllGet(context))
            {
                oList.Add((ordhed)i);
            }

            ContextRz xrz = (ContextRz)context;

            switch (args.ActionName.Trim().ToLower())
            {
                case "salesreppaid":
                    xrz.Leader.ShowTransmitOrders((ContextRz)context, oList, Enums.TransmitType.Print);
                    args.Handled = true;
                    break;
                case "buyerpaid":
                    args.Handled = true;
                    break;
                case "print":
                    args.Handled = true;
                    foreach (ordhed o in oList)
                    {
                        if (!((ContextRz)context).TheLeaderRz.IsWeb())
                        {
                            if (o.OrderType == Enums.OrderType.Purchase)
                            {
                                company TheVendor = (Rz5.company)(context.GetById("company", o.base_company_uid));
                                //KT only want to prevent non super users from printing non-vetted PO's.  Consignment PO's, etc.
                                //if (!((ContextRz)context).xUserRz.SuperUser)
                                if (!((ContextRz)context).TheSysRz.TheCompanyLogic.CheckVetted(context, TheVendor))
                                {
                                    context.Leader.Tell(TheVendor + " needs to be vetted before we can submit a PO.  Please notify your manager and/or the quality team for resolution before submitting the PO.");
                                    return;
                                }
                            }
                            else if (!o.TransmitPossible((ContextRz)context, Enums.TransmitType.Print))
                                return;
                        }
                    }
                    xrz.Leader.ShowTransmitOrders((ContextRz)context, oList, Rz5.Enums.TransmitType.Print);
                    break;
                case "fax":
                    args.TheContext.Reorg();
                    //args.Handled = true;
                    //foreach (ordhed o in lines)
                    //{
                    //    if (!o.TransmitPossible((ContextRz)context, Enums.TransmitType.Print))
                    //        return;
                    //}
                    //context.Logic.ShowTransmitOrders((ContextRz)context, lines, Rz4.Enums.TransmitType.Fax);
                    break;
                case "email":
                    args.Handled = true;
                    foreach (ordhed o in oList)
                        if (!o.TransmitPossible((ContextRz)context, Enums.TransmitType.Print))
                            return;

                    xrz.Leader.ShowTransmitOrders((ContextRz)context, oList, Rz5.Enums.TransmitType.Email);
                    break;
                case "pdf":
                case "print pdf":
                case "printpdf":
                    args.Handled = true;
                    foreach (ordhed o in oList)
                    {
                        if (!o.TransmitPossible((ContextRz)context, Enums.TransmitType.Print))
                            return;
                    }
                    xrz.Leader.ShowTransmitOrders((ContextRz)context, oList, Rz5.Enums.TransmitType.PDF);
                    args.Handled = true;
                    break;
                case "linereport":
                    ArrayList a = new ArrayList();
                    Enums.OrderType t = Rz5.Enums.OrderType.Invoice;
                    foreach (ordhed h in oList)
                    {
                        a.Add(h.unique_id);
                        t = h.OrderType;
                    }
                    ordhed.ShowLineReport((ContextRz)context, t, a, "Order Report");
                    args.Handled = true;
                    break;
                case "printcheck":
                    ShowPrintCheck((ContextRz)context);
                    break;
                case "printalldocuments":
                    PrintAllDocuments(xrz, oList, false);
                    break;
                case "testoptions":
                    ShowTestOptions(xrz, oList);
                    break;
                case "removeun-filledlines":
                    {
                        ordhed_invoice o = (ordhed_invoice)oList[0];
                        List<orddet_line> lines = o.DetailsList(xrz).Cast<orddet_line>().ToList();
                        o.RemoveUnFilledLines(xrz, CloseType.Ship, lines);
                        break;
                    }
                case "confirmdockdates":
                    {
                        foreach (ordhed o in oList)
                            ConfirmDockDates((ContextRz)context, o);
                        break;
                    }

                case "pre-invoice":
                    {
                        //InvoiceNewShow(context, args);
                        CreatePreInvoice(xrz, (ordhed_sales)oList[0]);

                        break;
                    }
                case "manualclose":
                    {
                        foreach (ordhed_new o in oList)
                        {
                            o.ManualClose((ContextRz)context, o);
                        }
                        break;
                    }

                default:
                    base.ActInstance(context, args);
                    break;
            }
        }

        private void CreatePreInvoice(ContextRz x, ordhed_sales s)
        {
            //List<orddet_line> lines = s.DetailsList(x).Cast<orddet_line>().ToList();
            //List<string> existingInvoiceNumbers = lines.Where(w => w.orderid_invoice.Length > 0 && w.orderid_invoice != null).Select(ss => ss.ordernumber_invoice).Distinct().ToList();
            //if(existingInvoiceNumbers.Count() > 0)
            //{
            //    string noInvoiceMessage = "Lines on this invoice already belong to the following invoices." + Environment.NewLine;
            //    foreach (string invNumber in existingInvoiceNumbers)
            //        noInvoiceMessage += "Invoice "+ invNumber + Environment.NewLine;
            //    noInvoiceMessage += "Cannot create pre-invoice.";
            //    x.Error(noInvoiceMessage);
            //    return;
            //}


            //List<ordhed_invoice> Invoices = s.MakeInvoice(x, lines);
            //foreach (ordhed_invoice i in Invoices)
            //    x.Show(i);

            //Invoicing the Sale
            List<ordhed_invoice> Invoices = s.CreateInvoice(x, true);
            if (Invoices == null || Invoices.Count <= 0)
                return;
            foreach (ordhed_invoice i in Invoices)
                x.Show(i);
        }

        private void ShowTestOptions(ContextRz x, List<ordhed> oList)
        {
            //x.Leader.Tell("Test Options!");

            foreach (ordhed o in oList)
            {
                x.Leader.ShowOrderTestOptions(x, o);
                //foreach(orddet_line l in o.DetailsList(x))
                //{
                //    x.Leader.GetDockDateChecker(x, l);
                //}
            }
        }

        public void PrintAllDocuments(ContextRz x, List<ordhed> oList, bool notifyOnly = true)
        {
            //Print Customer Sales Work Up                
            if (oList.Count != 1)
            {
                x.Leader.Tell("Too many (or not enough) sales orders in oList, cannot print all documents.");
                return;
            }

            ordhed_sales s = null;
            foreach (ordhed o in oList)
            {
                s = (ordhed_sales)o;
            }
            if (s == null)
            {
                x.Leader.Tell("Sales Order Not found, cannot print all documents.");
                return;
            }


            //Gather Any Missing Items - Keep Gathering all before printing, that way if any error, won't print anything.'
            //Sale Data
            List<string> missingSalesData = new List<string>();
            missingSalesData = MissingPrintItems(x, new List<ordhed>() { s }, s, Enums.OrderType.Sales);
            if (missingSalesData.Count > 0)
                return;

            //PO Data
            List<string> missingPOData = new List<string>();
            ArrayList pList = s.GetRelatedPurchases(x);
            foreach (ordhed_purchase p in pList)
            {
                missingPOData = MissingPrintItems(x, new List<ordhed>() { p }, s, Enums.OrderType.Purchase, false);
                if (missingPOData.Count > 0 || notifyOnly == true)
                    return;
            }

            //Print Formal Quote
            ArrayList qList = s.GetRelatedQuotes(x);
            ordhed_quote q = null;
            if (qList == null || qList.Count == 0)
            {
                x.Leader.Tell("Could not locate the Formal Quote for this order.  Be aware Formal Quote won't be printed, and you should investigate why there is no quote associated with this Sales Order.");
                //return;
            }
            else if (qList.Count > 1)
            {
                x.Leader.Tell("More than one quote detected for this order, Quote will not print.  Please print manually.");
                //return;
            }
            else if (qList.Count > 0)
                q = (ordhed_quote)qList[0];
            //if (q == null)
            //{
            //    x.Leader.Tell("Formal Quote not detected. Cannot print quote, please investigate and re-print when resolved.");
            //    //return;
            //}
            if (q != null)
            {
                List<string> missingQuoteData = new List<string>();
                missingQuoteData = MissingPrintItems(x, new List<ordhed>() { q }, s, Enums.OrderType.Quote);
                if (missingQuoteData.Count > 0)
                    return;
            }

            //Passed all checks to this point, go ahead and print
            if (x.xUser.IsDeveloper())
            {
                if (!x.Leader.AreYouSure("want to print all documents?"))
                    return;
            }
            //Get Print Parameters
            TransmitParameters CurrentParameters = GetPrintParameters();
            if (string.IsNullOrEmpty(CurrentParameters.PrinterName))
                return;
            //Sales Workup
            PrintOrders(x, s, new ArrayList() { s }, "SM Customer Sales Work-Up", CurrentParameters);
            //Purchase Orders
            PrintOrders(x, s, s.GetRelatedPurchases(x), "SM Purchase Order", CurrentParameters);
            //Formal Quotes
            PrintOrders(x, s, s.GetRelatedQuotes(x), "SM Formal Quote", CurrentParameters);
            //Service Orders
            PrintOrders(x, s, s.GetRelatedServiceOrders(x, s.DetailsList(x)), "SM Service Order", CurrentParameters);


            //Easter Egg
            if (x.xUser.Name == "Joe Mar" || x.xUser.IsDeveloper())
            {

                List<string> randomMessages = new List<string>();
                randomMessages.Add("Heathcliff");
                randomMessages.Add("Tami Tonaldson");
                randomMessages.Add("Ron Myers");
                randomMessages.Add("John Sullivan");
                //randomMessages.Add("God you're lookin handsome today.");
                //randomMessages.Add("Damn, you pushed that button like you MEANT it!");
                //randomMessages.Add("I love it when you push by buttons.");
                //randomMessages.Add("Does this screen make my RAM look fat?");
                //randomMessages.Add("Wait, what did you want me to do, I forgot?");
                //randomMessages.Add("You know what Joe?  You're the MAN! ");
                Random r = new Random();
                int index = r.Next(randomMessages.Count);
                string randomString = "Excellent!  " + randomMessages[index] + " would approve of you actions!";
                x.Leader.Tell(randomString);
            }

        }

        private TransmitParameters GetPrintParameters()
        {
            TransmitParameters ret = new TransmitParameters(Enums.TransmitType.Print);
            ret.PrintTemplate = new printheader();
            ret.CopyCount = 1;
            ret.ForceSynchronous = false;
            if (Strings.StrExt(ret.PrintTemplate.printername) && PrintSessionPrinter.PrinterExists(ret.PrintTemplate.printername))
                ret.PrinterName = ret.PrintTemplate.printername;
            else
                ret.PrinterName = GetPrinterFromDialog();
            return ret;
        }

        private void PrintOrders(ContextRz x, ordhed_sales s, ArrayList orderList, string printTemplate, TransmitParameters CurrentParameters)
        {
            //TransmitParameters CurrentParameters = new TransmitParameters(Enums.TransmitType.Print);
            if (orderList == null)
                return;
            if (orderList.Count == 0)
                return;
            if (CurrentParameters.PrintTemplate == null)
                return;
            CurrentParameters.PrintTemplate = printheader.GetByName(x, printTemplate);

            if (CurrentParameters.PrinterName != null)
            {

                foreach (ordhed o in orderList)
                {
                    o.Transmit(x, CurrentParameters);
                }
            }
        }

        internal void ConfirmDockDates(ContextRz context, ordhed o)
        {
            foreach (orddet_line l in o.DetailsList(context))
                context.Leader.GetDockDateChecker(context, l);
        }



        private string GetPrinterFromDialog()
        {
            //CurrentParameters.PrinterName = PrintSessionPrinter.GetCurrentPrinter();
            //CurrentParameters.PrinterName = PrintSessionPrinter.ChoosePrinter(NewMethod.frmMain);
            PrintDialog printDialog1 = new PrintDialog();
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
                return printDialog1.PrinterSettings.PrinterName;
            return null;
        }

        private List<string> MissingPrintItems(ContextRz x, List<ordhed> orderList, ordhed_sales s, Enums.OrderType orderType, bool notify = true)
        {
            List<string> ret = new List<string>();
            //Common Header Info
            foreach (ordhed o in orderList)
            {
                if (string.IsNullOrEmpty(o.agentname))
                    ret.Add("Agent Name");
                if (string.IsNullOrEmpty(o.terms))
                    ret.Add("Terms");
                if (string.IsNullOrEmpty(o.contactname))
                    ret.Add("Contact Name");
                if (string.IsNullOrEmpty(o.billingaddress))
                    ret.Add("Billing Address");
                if (string.IsNullOrEmpty(o.orderdate.ToString()))
                    ret.Add("Order Date");
                if (string.IsNullOrEmpty(o.ordernumber.ToString()))
                    ret.Add("Order Number");
                switch (orderType)
                {//Order Specific Header Info
                    case Enums.OrderType.Sales:
                        {
                            if (string.IsNullOrEmpty(o.orderreference))
                                ret.Add("Customer PO");
                            if (string.IsNullOrEmpty(o.shippingaccount))
                                ret.Add("Shipping Account");
                            if (string.IsNullOrEmpty(o.shippingaddress))
                                ret.Add("Shipping Address");
                            if (string.IsNullOrEmpty(o.shipvia))
                                ret.Add("Shipping Method");
                            break;
                        }
                    case Enums.OrderType.Purchase:
                        {

                            if (string.IsNullOrEmpty(o.shippingaccount))
                                ret.Add("Shipping Account");
                            if (string.IsNullOrEmpty(o.shippingaddress))
                                ret.Add("Shipping Address");
                            if (string.IsNullOrEmpty(o.shipvia))
                                ret.Add("Shipping Method");
                            break;
                        }
                }
            }
            //Check Lines
            switch (orderType)
            {//Order Specific Line Info
                case Enums.OrderType.Sales:
                    {
                        foreach (ordhed_sales o in orderList)
                        {
                            foreach (orddet_line l in o.DetailsList(x))
                            {
                                if (l.status == Enums.OrderLineStatus.Open.ToString() || l.status == Enums.OrderLineStatus.Buy.ToString())
                                {
                                    if (l.stocktype == Enums.StockType.Buy.ToString())
                                        if (string.IsNullOrEmpty(l.ordernumber_purchase))
                                            ret.Add("Line " + l.linecode_sales + ": SMC PO Number");
                                    if (string.IsNullOrEmpty(l.vendor_name))
                                        ret.Add("Line " + l.linecode_sales + ": Vendor Name");
                                    if (string.IsNullOrEmpty(l.fullpartnumber))
                                        ret.Add("Line " + l.linecode_sales + ": Part Number");
                                    if (string.IsNullOrEmpty(l.manufacturer))
                                        ret.Add("Line " + l.linecode_sales + ": Manufacturer");
                                    if (string.IsNullOrEmpty(l.quantity.ToString()))
                                        ret.Add("Line " + l.linecode_sales + ": Quantity");
                                    if (string.IsNullOrEmpty(l.unit_cost.ToString()))
                                        ret.Add("Line " + l.linecode_sales + ": Unit Cost");
                                    if (string.IsNullOrEmpty(l.total_cost.ToString()))
                                        ret.Add("Line " + l.linecode_sales + ": Total Cost");
                                    if (string.IsNullOrEmpty(l.unit_price.ToString()))
                                        ret.Add("Line " + l.linecode_sales + ": Unit Price");
                                    if (string.IsNullOrEmpty(l.total_price.ToString()))
                                        ret.Add("Line " + l.linecode_sales + ": Total Price");
                                    if (l.customer_dock_date < new DateTime(1905, 1, 1))
                                        ret.Add("Line " + l.linecode_sales + ": Customer Dock");
                                }
                            }
                        }
                        break;
                    }
                case Enums.OrderType.Purchase:
                    {
                        foreach (ordhed_purchase o in orderList)
                        {
                            foreach (orddet_line l in o.DetailsList(x))
                            {
                                if (l.status == Enums.OrderLineStatus.Open.ToString() || l.status == Enums.OrderLineStatus.Buy.ToString())
                                {
                                    if (string.IsNullOrEmpty(l.quantity.ToString()))
                                        ret.Add("Line " + l.linecode_sales + ": Quantity"); //Quantity
                                    if (string.IsNullOrEmpty(l.fullpartnumber))
                                        ret.Add("Line " + l.linecode_sales + ": Part Number"); //Part Number
                                    if (string.IsNullOrEmpty(l.manufacturer))
                                        ret.Add("Line " + l.linecode_sales + ": Manufacturer"); //MFG
                                    if (string.IsNullOrEmpty(l.condition))
                                        ret.Add("Line " + l.linecode_sales + ": Condition"); //Condition
                                    if (string.IsNullOrEmpty(l.rohs_info))
                                        ret.Add("Line " + l.linecode_sales + ": RoHS Info"); //RoHS
                                    if (string.IsNullOrEmpty(l.datecode))
                                        ret.Add("Line " + l.linecode_sales + ": Date Code");  //Date Code
                                    if (l.receive_date_due < new DateTime(2006, 1, 1))
                                        ret.Add("Line " + l.linecode_sales + ": Receive Due Date"); //recieve due date
                                    if (string.IsNullOrEmpty(l.shipvia_purchase))
                                        ret.Add("Line " + l.linecode_sales + ": ShipVia - Purchase"); //ShipVia Purchase
                                    if (string.IsNullOrEmpty(l.unit_cost.ToString()))
                                        ret.Add("Line " + l.linecode_sales + ": Unit Cost");
                                    if (string.IsNullOrEmpty(l.total_cost.ToString()))
                                        ret.Add("Line " + l.linecode_sales + ": Total Cost");
                                }
                            }
                        }
                        break;
                    }
                case Enums.OrderType.Quote:
                    {
                        foreach (ordhed_quote o in orderList)
                        {
                            List<string> relatedQuoteLines = x.SelectScalarList("select distinct quote_line_uid from orddet_line where orderid_sales = '" + s.unique_id + "'");
                            foreach (orddet_quote q in o.DetailsList(x))
                            {


                                if (relatedQuoteLines.Contains(q.unique_id)) // Dont' check other lines on the quote if they are not related to the SO
                                {
                                    if (string.IsNullOrEmpty(q.fullpartnumber))
                                        ret.Add("Line " + q.linecode + ": Part Number");
                                    if (string.IsNullOrEmpty(q.manufacturer))
                                        ret.Add("Line " + q.linecode + ": Manufacturer");
                                    if (string.IsNullOrEmpty(q.internalpartnumber))
                                        ret.Add("Line " + q.linecode + ": Customer Internal");
                                    if (string.IsNullOrEmpty(q.datecode))
                                        ret.Add("Line " + q.linecode + ": Date Code");
                                    if (string.IsNullOrEmpty(q.condition))
                                        ret.Add("Line " + q.linecode + ": Condition");
                                    if (string.IsNullOrEmpty(q.rohs_info))
                                        ret.Add("Line " + q.linecode + ": RoHS Info");
                                    if (string.IsNullOrEmpty(q.delivery))
                                        ret.Add("Line " + q.linecode + ": Lead Time");
                                    if (string.IsNullOrEmpty(q.quantityordered.ToString()))
                                        ret.Add("Line " + q.linecode + ": Quote Quantity");
                                    if (string.IsNullOrEmpty(q.unitprice.ToString()))
                                        ret.Add("Line " + q.linecode + ": Unit Price");
                                }


                            }
                        }
                        break;
                    }
            }
            if (notify && ret.Count > 0)
                NotifyOrdersMissingForPrint(x, ret, orderList[0]);
            else if (!notify)
            {
                if (GatherMissingItemsForPrintFromUser(x, orderList, s, orderType))
                    ret = new List<string>();// Boolean, if true, clear missing props so print will happen?
            }

            return ret;
        }

        private bool GatherMissingItemsForPrintFromUser(ContextRz x, List<ordhed> orderList, ordhed_sales s, Enums.OrderType orderType)
        {
            company c = company.GetById(x, s.base_company_uid);
            ArrayList companyList = new ArrayList() { c };
            n_user agent = n_user.GetById(x, s.base_mc_user_uid);
            string getShipVia = null;
            string getShipAccount = null;
            //foreach (ordhed o in orderList)
            //{
            //    if (string.IsNullOrEmpty(o.agentname))
            //    {
            //        o.agentname = agent.name;
            //        o.base_mc_user_uid = agent.unique_id;
            //    }                    
            //    if (string.IsNullOrEmpty(o.terms))
            //    {
            //        string terms = x.Leader.ChooseOneChoice(x, "terms");
            //        if (string.IsNullOrEmpty(terms))
            //            return;
            //        o.terms = terms;                   
            //    }                    
            //    if (string.IsNullOrEmpty(o.contactname))
            //    {
            //        ArrayList contactArrayList = c.GetAllContacts(x);
            //        List<companycontact> cList = contactArrayList.Cast<companycontact>().ToList();
            //        o.contactname = x.Leader.ChooseOneString(x, "Please choose a contact", cList.Select(ss => ss.Name).ToList());
            //        o.base_companycontact_uid = cList.Where(w => w.Name == o.contactname).Select(ss => ss.unique_id).FirstOrDefault();
            //        if (string.IsNullOrEmpty(o.contactname) || (string.IsNullOrEmpty(o.base_companycontact_uid))
            //            return;
            //    }                    
            //    if (string.IsNullOrEmpty(o.billingaddress))
            //    {
            //        ret.Add("Billing Address");
            //    }                   
            //    if (string.IsNullOrEmpty(o.orderdate.ToString()))
            //        ret.Add("Order Date");
            //    if (string.IsNullOrEmpty(o.ordernumber.ToString()))
            //        ret.Add("Order Number");
            //    switch (orderType)
            //    {//Order Specific Header Info
            //        case Enums.OrderType.Sales:
            //            {
            //                if (string.IsNullOrEmpty(o.orderreference))
            //                    ret.Add("Customer PO");
            //                if (string.IsNullOrEmpty(o.shippingaccount))
            //                    ret.Add("Shipping Account");
            //                if (string.IsNullOrEmpty(o.shippingaddress))
            //                    ret.Add("Shipping Address");
            //                if (string.IsNullOrEmpty(o.shipvia))
            //                    ret.Add("Shipping Method");
            //                break;
            //            }
            //        case Enums.OrderType.Purchase:
            //            {

            //                if (string.IsNullOrEmpty(o.shippingaccount))
            //                    ret.Add("Shipping Account");
            //                if (string.IsNullOrEmpty(o.shippingaddress))
            //                    ret.Add("Shipping Address");
            //                if (string.IsNullOrEmpty(o.shipvia))
            //                    ret.Add("Shipping Method");                            
            //                break;
            //            }
            //    }
            //}
            //Check Lines
            switch (orderType)
            {//Order Specific Line Info
                case Enums.OrderType.Sales:
                    {
                        //foreach (ordhed_sales o in orderList)
                        //{
                        //    foreach (orddet_line l in o.DetailsList(x))
                        //    {
                        //        if (l.status == Enums.OrderLineStatus.Open.ToString() || l.status == Enums.OrderLineStatus.Buy.ToString())
                        //        {
                        //            if (l.stocktype == Enums.StockType.Buy.ToString())
                        //                if (string.IsNullOrEmpty(l.ordernumber_purchase))
                        //                    ret.Add("Line " + l.linecode_sales + ": SMC PO Number");
                        //            if (string.IsNullOrEmpty(l.vendor_name))
                        //                ret.Add("Line " + l.linecode_sales + ": Vendor Name");
                        //            if (string.IsNullOrEmpty(l.fullpartnumber))
                        //                ret.Add("Line " + l.linecode_sales + ": Part Number");
                        //            if (string.IsNullOrEmpty(l.manufacturer))
                        //                ret.Add("Line " + l.linecode_sales + ": Manufacturer");
                        //            if (string.IsNullOrEmpty(l.quantity.ToString()))
                        //                ret.Add("Line " + l.linecode_sales + ": Quantity");
                        //            if (string.IsNullOrEmpty(l.unit_cost.ToString()))
                        //                ret.Add("Line " + l.linecode_sales + ": Unit Cost");
                        //            if (string.IsNullOrEmpty(l.total_cost.ToString()))
                        //                ret.Add("Line " + l.linecode_sales + ": Total Cost");
                        //            if (string.IsNullOrEmpty(l.unit_price.ToString()))
                        //                ret.Add("Line " + l.linecode_sales + ": Unit Price");
                        //            if (string.IsNullOrEmpty(l.total_price.ToString()))
                        //                ret.Add("Line " + l.linecode_sales + ": Total Price");
                        //            if (l.customer_dock_date < new DateTime(1905, 1, 1))
                        //                ret.Add("Line " + l.linecode_sales + ": Customer Dock");
                        //        }
                        //    }
                        //}
                        break;
                    }
                case Enums.OrderType.Purchase:
                    {


                        foreach (ordhed_purchase o in orderList)
                        { //PO Variables
                            string poMessageSuffix = "  Cannot print PO# " + o.ordernumber + "  Please correct and try again, or print PO individually.";

                            if (string.IsNullOrEmpty(o.shipvia))
                            {
                                getShipVia = x.Leader.ChooseOneChoice(x, "shipvia", "Please choose the shipping method for PO# " + o.ordernumber);
                                o.shipvia = getShipVia;
                                if (string.IsNullOrEmpty(o.shipvia) || string.IsNullOrEmpty(o.shipvia))
                                {
                                    x.Leader.Tell("Invalid PO ShipVia." + poMessageSuffix);
                                    return false;
                                }
                            }
                            if (string.IsNullOrEmpty(o.shippingaccount))
                            {
                                List<string> availableShippingAccounts = new List<string>();
                                string fedEx = n_set.GetSetting(x, "internal_fedex");
                                string ups = n_set.GetSetting(x, "internal_ups");
                                availableShippingAccounts.Add(fedEx + "  (FedEx)");
                                availableShippingAccounts.Add(ups + "  (UPS)");

                                //List<string> availableShippingAccounts = x.SelectScalarList("select distinct accountnumber from shippingaccount where base_company_uid = '" + o.base_company_uid + "'");
                                if (availableShippingAccounts.Count == 0)
                                {
                                    x.Leader.Tell("No Shipping accounts on file for " + o.companyname + ".  Please correct and try to print again.");
                                    return false;
                                }
                                getShipAccount = x.Leader.ChooseOneString(x, "Please choose the shipping account for this PO.", availableShippingAccounts);
                                if (string.IsNullOrEmpty(getShipAccount))
                                {
                                    x.Leader.Tell("Please choose a valid shipping account for this PO before printing");
                                    return false;
                                }
                                if (getShipAccount.ToLower().Contains("fedex"))
                                    o.shippingaccount = fedEx;
                                else if (getShipAccount.ToLower().Contains("ups"))
                                    o.shippingaccount = ups;
                            }


                            foreach (orddet_line l in o.DetailsList(x))
                            {

                                if (l.status == Enums.OrderLineStatus.Open.ToString() || l.status == Enums.OrderLineStatus.Buy.ToString())
                                {
                                    if (l.receive_date_due < new DateTime(2006, 1, 1))
                                    {
                                        l.receive_date_due = x.Leader.ChooseDate(DateTime.Now.AddDays(1), "Please select the Sensible Micro Dock Date (i.e. the date we need it on our dock in order to meet the customer dock date of: " + l.customer_dock_date + ")");
                                        if (l.receive_date_due < new DateTime(1902, 1, 1) || string.IsNullOrEmpty(l.receive_date_due.ToString()))
                                        {
                                            x.Leader.Tell("Invalid SMC Dock Date (" + l.receive_date_due + ")." + poMessageSuffix);
                                            return false;
                                        }
                                    }
                                    if (string.IsNullOrEmpty(l.shipvia_purchase))
                                    {
                                        if (!string.IsNullOrEmpty(getShipVia))
                                            l.shipvia_purchase = getShipVia;

                                    }

                                }
                                l.Update(x);
                            }

                            o.Update(x);
                        }
                        break;


                    }
                    //case Enums.OrderType.Quote:
                    //    {
                    //        foreach (ordhed_quote o in orderList)
                    //        {
                    //            List<string> relatedQuoteLines = x.SelectScalarList("select distinct quote_line_uid from orddet_line where orderid_sales = '" + s.unique_id + "'");
                    //            foreach (orddet_quote q in o.DetailsList(x))
                    //            {


                    //                if (relatedQuoteLines.Contains(q.unique_id)) // Dont' check other lines on the quote if they are not related to the SO
                    //                {
                    //                    if (string.IsNullOrEmpty(q.fullpartnumber))
                    //                        ret.Add("Line " + q.linecode + ": Part Number");
                    //                    if (string.IsNullOrEmpty(q.manufacturer))
                    //                        ret.Add("Line " + q.linecode + ": Manufacturer");
                    //                    if (string.IsNullOrEmpty(q.internalpartnumber))
                    //                        ret.Add("Line " + q.linecode + ": Customer Internal");
                    //                    if (string.IsNullOrEmpty(q.datecode))
                    //                        ret.Add("Line " + q.linecode + ": Date Code");
                    //                    if (string.IsNullOrEmpty(q.condition))
                    //                        ret.Add("Line " + q.linecode + ": Condition");
                    //                    if (string.IsNullOrEmpty(q.rohs_info))
                    //                        ret.Add("Line " + q.linecode + ": RoHS Info");
                    //                    if (string.IsNullOrEmpty(q.delivery))
                    //                        ret.Add("Line " + q.linecode + ": Lead Time");
                    //                    if (string.IsNullOrEmpty(q.quantityordered.ToString()))
                    //                        ret.Add("Line " + q.linecode + ": Quote Quantity");
                    //                    if (string.IsNullOrEmpty(q.unitprice.ToString()))
                    //                        ret.Add("Line " + q.linecode + ": Unit Price");
                    //                }


                    //            }
                    //        }
                    //        break;
                    //    }
            }
            return true;
        }

        private void NotifyOrdersMissingForPrint(ContextRz x, List<string> missingList, ordhed o, bool showOrder = true)
        {
            string message = "";
            string missingString = string.Join(Environment.NewLine, missingList);
            switch (o.OrderType)
            {
                case Enums.OrderType.Sales:
                    {
                        message = "Sales Order";
                        break;
                    }
                case Enums.OrderType.Purchase:
                    {
                        message = "Purchase Order";
                        break;
                    }
                case Enums.OrderType.Quote:
                    {
                        message = "Formal Quote";
                        break;
                    }
            }

            message += " is missing the following items: " + Environment.NewLine + Environment.NewLine + missingString + Environment.NewLine + Environment.NewLine + "Please corrent and print again.";
            x.Leader.Tell(message);
            if (showOrder)
            {
                // x.TheLeader.ViewsClose(o);
                x.Show(o);
                //Control c = RzWin.Form.TabCheckShow("emailblaster");
                //x.TheLeader.ViewCreate(x, new ShowArgs(x, o));              
            }

        }




        public void ShowPrintCheck(ContextRz x)
        {
            x.TheLeaderRz.ShowPrintCheck(x, null);
        }

        public virtual string GetMarginNetPercent(double divide_into, double divide_by)
        {
            //try
            //{
            //    double d = (divide_into / divide_by) * 100;
            //    if (!Tools.Number.IsNumeric(d.ToString()))
            //        return String.Format("{0:##0.0}", 0) + "%";
            //    if (d.ToString().ToLower().Contains("nan"))
            //        return String.Format("{0:##0.0}", 0) + "%";
            //    if (d.ToString().ToLower().Contains("infinity"))
            //        return String.Format("{0:##0.0}", 0) + "%";
            //    return String.Format("{0:##0.0}", d) + "%";
            //}
            //catch { }
            //return String.Format("{0:##0.0}", 0) + "%";


            //KT Refactored from RzSensible
            try
            {
                double d = GetMarginNetValue(divide_into, divide_by);
                if (!Tools.Number.IsNumeric(d.ToString()))
                    return String.Format("{0:##0.0}", 0) + "%";
                if (d.ToString().ToLower().Contains("nan"))
                    return String.Format("{0:##0.0}", 0) + "%";
                if (d.ToString().ToLower().Contains("infinity"))
                    return String.Format("{0:##0.0}", 0) + "%";
                return String.Format("{0:##0.0}", d) + "%";
            }
            catch { }
            return String.Format("{0:##0.0}", 0) + "%";
        }
        public virtual double GetMarginNetValue(double divide_into, double divide_by)
        {
            //try
            //{
            //    double d = (divide_into / divide_by) * 100;
            //    if (Tools.Strings.StrCmp(d.ToString(), "nan"))
            //        return 0;
            //    if (Tools.Strings.StrCmp(d.ToString(), "infinity"))
            //        return 0;
            //    return d;
            //}
            //catch { }
            //return 0;


            //KT Refactored from RzSensible
            try
            {
                double d = (divide_into / divide_by) * 100;
                if (Tools.Strings.StrCmp(d.ToString(), "nan"))
                    return 0;
                if (Tools.Strings.StrCmp(d.ToString(), "infinity"))
                    return 100;
                return Tools.Number.CommonSensibleRounding(d);
            }
            catch { }
            return 100;
        }

        //KT Get RMA's related to an invoice
        public List<ordhed_rma> GetRelatedRMAs(Rz5.ContextRz context, ordhed_invoice i)
        {
            List<ordhed_rma> ret = new List<ordhed_rma>();

            if (i == null)
                return ret;
            List<string> RMAIDs = context.SelectScalarList("select unique_id from ordhed_rma where unique_id IN(select orderid_rma from orddet_line where orderid_invoice = '" + i.unique_id + "')");

            foreach (string s in RMAIDs)
            {
                ret.Add((ordhed_rma)context.GetById("ordhed_rma", s));
            }
            return ret;
        }


        public bool CanMarkQuoteLost(ContextRz x, ordhed_quote q)
        {
            if (q.HasLinkedSale(x))
            {
                ordhed_sales s = (ordhed_sales)q.GetRelatedSale(x);
                if (!s.isvoid)
                    return false;
            }
            return true;
        }

        public virtual void AskForSalesLineCancel(orddet d)
        {

        }
        public virtual bool CheckQuoteBeforeSave(ContextNM context, orddet_quote q)
        {
            //try
            //{
            //    if (q == null)
            //        return false;
            //    if (!Tools.Strings.StrExt(q.internalpartnumber))
            //    {
            //        string s = context.TheLeader.AskForString("There is no internal partnumber, please add one now.", "", false);
            //        if (!Tools.Strings.StrExt(s))
            //            //q.internalpartnumber = "N/A";
            //            q.internalpartnumber = q.fullpartnumber;
            //        else
            //            q.internalpartnumber = s;
            //        q.Update(context);
            //    }




            //    return true;
            //}
            //catch { }
            //return false;
            return true;
        }
        public virtual DealHalfQuote GetDealHalfQuote()
        {
            return new DealHalfQuote();
        }
        public virtual DealHalfBid GetDealHalfBid()
        {
            return new DealHalfBid();
        }



        public void Link2Orders(ContextRz context, ordhed order1, ordhed order2)
        {
            ordlnk xLink = order1.GetNewLink(context);
            xLink.Order2Var.RefSet(context, order2);
            xLink = order2.GetNewLink(context);
            xLink.Order2Var.RefSet(context, order1);
            context.TheLeader.Comment("The link was created.");
        }

        public virtual void AfterLineAddedPurchase(ContextRz context, orddet_line line)
        {
            switch (line.Status)
            {
                case Enums.OrderLineStatus.Hold:
                    line.Status = Enums.OrderLineStatus.Buy;
                    break;
            }
        }

        public ListArgs ShippingScreenArgsGetReceive(ContextRz context, bool purchase, bool service, bool rma, Tools.Dates.DateRange range)
        {
            ListArgs ret = new ListArgs(context);
            ret.TheClass = "orddet_line";
            ret.TheTable = "orddet_line";
            ret.TheTemplate = "LinesReceiving";

            List<String> stats = new List<string>();

            if (purchase)
            {
                stats.Add(orddet.StatusConvert(Enums.OrderLineStatus.Buy));
                stats.Add(orddet.StatusConvert(Enums.OrderLineStatus.Open));
                stats.Add(orddet.StatusConvert(Enums.OrderLineStatus.Hold));
            }


            if (service)
                stats.Add(orddet.StatusConvert(Enums.OrderLineStatus.Out_For_Service));

            if (rma)
                stats.Add(orddet.StatusConvert(Enums.OrderLineStatus.RMA_Receiving));

            if (stats.Count == 0)
                stats.Add("none");

            ret.TheWhere = " isnull(isvoid, 0) = 0 and status in (" + Tools.Data.GetIn(stats) + ") and len(isnull(orderid_sales, 0)) > 0 and status not in ('hold') and fullpartnumber not like '%GCAT%' and vendor_uid != '037ED306-8D90-42D6-AAAA-AD91B900F263' and projected_dock_date is not null";

            if (range != null)
                //KT 8-27 - Experimenting with using customer dock on the receive screen
                //ret.TheWhere += " and " + range.GetSQL("receive_date_next");
                //ret.TheWhere += " and " + range.GetSQL("customer_dock_date");
                ret.TheWhere += " and " + range.GetSQL("projected_dock_date");
            //KT 8-27 - Experimenting with using customer dock on the receive screen
            //ret.TheOrder = "receive_date_next desc";
            ret.TheOrder = "projected_dock_date";
            ret.AddAllow = false;
            return ret;
        }

        public ListArgs ShippingScreenArgsGetShip(ContextRz context, bool sales, bool service, bool vendrma, Tools.Dates.DateRange range)
        {
            ListArgs ret = new ListArgs(context);
            ret.TheClass = "orddet_line";
            ret.TheTable = "orddet_line";
            ret.TheTemplate = "LinesShipping";

            List<String> stats = new List<string>();

            if (sales)
            {
                stats.Add(orddet.StatusConvert(Enums.OrderLineStatus.Open));
                stats.Add(orddet.StatusConvert(Enums.OrderLineStatus.Packing));
                stats.Add(orddet.StatusConvert(Enums.OrderLineStatus.Buy));
            }

            if (service)
            {
                stats.Add(orddet.StatusConvert(Enums.OrderLineStatus.Packing_For_Service));
                stats.Add(orddet.StatusConvert(Enums.OrderLineStatus.Received_From_Service));
            }


            if (vendrma)
                stats.Add(orddet.StatusConvert(Enums.OrderLineStatus.Vendor_RMA_Packing));

            if (stats.Count == 0)
                stats.Add("none");

            ret.TheWhere = " isnull(isvoid, 0) = 0 and status in (" + Tools.Data.GetIn(stats) + ") and len(isnull(orderid_sales, 0)) > 0 ";

            if (range != null)
                ret.TheWhere += " and " + range.GetSQL("ship_date_next");

            ret.TheOrder = "ship_date_next desc";
            ret.AddAllow = false;
            return ret;
        }

        //public String GetNextNumber(n_sys xs, Enums.OrderType type)
        //{
        //    return GetNextNumber(xs, type, true);
        //}

        public virtual String GetNextNumber(ContextRz x, Enums.OrderType type)  //, bool set
        {
            //return PadOrderNumber(x, n_set.NextInteger(x, "next_order_number_" + type.ToString()).ToString());

            //int x = xs.GetSetting_Integer();
            //int y = x + 1;
            //if (set)
            //    SetNextNumber(xs, y, type);

            //return x.ToString());  // Tools.Strings.Right("000000" + x.ToString(), 6);

            //KT Refactored from RzSensible
            Rz5.Enums.OrderType purch = Rz5.Enums.OrderType.Purchase;
            if (type == Rz5.Enums.OrderType.Service)
                type = purch;
            string number = PadOrderNumber(x, n_set.NextInteger(x, "next_order_number_" + type.ToString()).ToString());
            String prefix = n_set.GetSetting(x, "order_prefix_" + type.ToString());
            if (type == Rz5.Enums.OrderType.Purchase)
                return prefix + number;
            else
                return prefix + number;
        }

        //public void SetNextNumber(n_sys xs, int number, Enums.OrderType type)
        //{
        //    xs.SetSetting_Integer("next_order_number_" + type.ToString(), number);
        //}

        public virtual String PadOrderNumber(ContextRz context, String s)
        {
            int l = OrderNumberLengthGet(context);
            if (l == 0)
                l = 6;

            return Tools.Strings.Right("00000000000000" + s, l);

            //while (s.Length < Rz3App.xLogic.OrderNumberLength)
            //{
            //    s = "0" + s;
            //}
            //return s;
        }

        public override void ActsListStatic(Context x, ActSetup set)
        {
            ActHandle h = new ActHandle(new Act("Orders", new ActHandler(OrdersShow)));
            set.Add(h);

            h.SubActs.Add(new ActHandle(new Act("New Order Batch", new ActHandler(BatchNewShow))));
            h.SubActs.Add(new ActHandle(new Act("New Vendor Bid", new ActHandler(BidNewShow))));
            h.SubActs.Add(new ActHandle(new Act("New Quote", new ActHandler(QuoteNewShow))));
            h.SubActs.Add(new ActHandle(new Act("New Sales Order", new ActHandler(SalesNewShow))));
            h.SubActs.Add(new ActHandle(new Act("New Purchase Order", new ActHandler(PurchaseNewShow))));
            h.SubActs.Add(new ActHandle(new Act("New Service Order", new ActHandler(ServiceNewShow))));
            //KT - Testing allowing new VRMA to return non-invoiced consignment parts that fail inspection (i.e. just like on a voided SO)
            h.SubActs.Add(new ActHandle(new Act("New Vendor RMA", new ActHandler(VendRMANewShow))));
            //if (!((ContextRz)x).xUserRz.WarehouseIs)
            //{
            //    h.AddSubSeparator();
            //    h.SubActs.Add(new ActHandle(new Act("Profit Report", new ActHandler(((ContextRz)x).TheSysRz.TheProfitLogic.ProfitReportShow))));
            //}
        }

        public virtual ActHandle ActsListShipping(ContextRz x, ActSetup acts)
        {
            if (x.CheckPermit(Permissions.ThePermits.ViewShipScreen))
            {
                ActHandle h = new ActHandle(new Act("Ship", new ActHandler(ShipShow)));
                acts.Add(h);
                h.SubActs.Add(new ActHandle(new Act("Due Today", new ActHandler(ShipShowToday))));
                if (x.CheckPermit("CanUseBinSwapper"))
                    h.SubActs.Add(new ActHandle(new Act("Bin Swapper", new ActHandler(ShowBinSwapper))));
                return h;
            }
            else
                return null;
        }

        public void OrdersShow(Context x, ActArgs args)
        {
            if (!((ContextRz)x).CheckPermit("Order:Search:Search Orders"))
            {
                x.TheLeader.ShowNoRight();
                args.Result(false);
                return;
            }

            ((ILeaderRz)x.TheLeader).OrderSearchShow((ContextRz)x, args);
            args.Result(true);
        }
        public void BatchNewShow(Context x, ActArgs args)
        {
            if (((ContextRz)x).CheckPermit("MainForm.mnuNewOrderTree_Click"))
            {
                dealheader d = dealheader.MakeManualDeal((ContextRz)x, null, null);
                x.Show(d);
                args.Result(true);
                return;
            }
            else
            {
                x.TheLeader.ShowNoRight();
                args.Result(false);
            }
        }
        public void BidNewShow(Context x, ActArgs args)
        {
            ShowNewOrder((ContextRz)x, Enums.OrderType.RFQ);
            args.Result(true);
        }
        public void QuoteNewShow(Context x, ActArgs args)
        {
            ShowNewOrder((ContextRz)x, Enums.OrderType.Quote);
            args.Result(true);
        }
        public void SalesNewShow(Context x, ActArgs args)
        {
            ShowNewOrder((ContextRz)x, Enums.OrderType.Sales);
            args.Result(true);
        }
        public virtual void PurchaseNewShow(Context x, ActArgs args)
        {
            //this is an ActionHandler, thus should only be fired when using the main Toolstrop subactions under the Orders Menu.


            ShowNewOrder((ContextRz)x, Enums.OrderType.Purchase);
            args.Result(true);
        }
        public void ServiceNewShow(Context x, ActArgs args)
        {
            ShowNewOrder((ContextRz)x, Enums.OrderType.Service);
            args.Result(true);
        }
        //KT 6-21-2016
        public void VendRMANewShow(Context x, ActArgs args)
        {
            ShowNewOrder((ContextRz)x, Enums.OrderType.VendRMA);
            args.Result(true);
        }

        public void InvoiceNewShow(Context x, ActArgs args)
        {
            ShowNewOrder((ContextRz)x, Enums.OrderType.Invoice);
            args.Result(true);
        }


        public virtual bool CanCreateOrder(ContextRz context, Enums.OrderType type)
        {
            return context.xUser.CheckPermit(context, "Order:Create:Can Make " + type.ToString());
        }


        public virtual ordhed ShowNewOrder(ContextRz context, Enums.OrderType type)
        {
            if (!CanCreateOrder(context, type))
            {
                context.TheLeader.ShowNoRight();
                return null;
            }
            ordhed o = ordhed.CreateNew(context, type);


            if (o is ordhed_purchase)
            {
                if (context.Leader.AskYesNo("Are you creating a Stock PO?"))
                {
                    ((ordhed_purchase)o).is_stock = true;
                    ((ordhed_purchase)o).Update(context);
                }
            }


            context.Show(o);
            return o;
        }

        public void ShipShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ShippingScreenShow((ContextRz)x, args);
        }

        public void ShowBinSwapper(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ShowBinSwapper((ContextRz)x, args);
            //((ILeaderRz)x.TheLeader).Tell("Coming Soon!");
        }


        public void ShipShowToday(Context x, ActArgs args)
        {
            ShippingScreenShowArgs sargs = null;
            if (args is ShippingScreenShowArgs)
                sargs = (ShippingScreenShowArgs)args;
            else
                sargs = new ShippingScreenShowArgs();

            sargs.DueToday = true;
            ((ILeaderRz)x.TheLeader).ShippingScreenShow((ContextRz)x, sargs);
        }


        public virtual bool OrderSearchShow(ContextRz x)
        {
            if (!x.CheckPermit("Order:Search:Search Orders"))
            {
                x.TheLeader.ShowNoRight();
                return false;
            }
            ((ILeaderRz)x.TheLeader).OrderSearchShow((ContextRz)x, new OrderSearchShowArgs());
            return true;
        }
        public virtual void OrderRestore(ContextRz x)
        {
            ordhed.Restore(x);
        }
        public virtual void OrderLineRestore(ContextRz x)
        {
            orddet.Restore(x);
        }
        private bool HasSalesOrder(ContextRz context, ordhed o)
        {
            if (o == null)
                return false;
            ArrayList a = o.GetLinkedSalesOrders(context);
            if (a == null)
                return false;
            return a.Count > 0;
        }

        public virtual void ColumnsAdjustForEmail(ContextRz context, n_template template, ArrayList coldetails)
        {
            //ColumnsAdjustForEmail((ContextRzCommon)context, yTemplate, colDetails);
        }

        public virtual void SendASN(ContextRz context, ordhed order)
        {
            String strName = "Advance " + order.OrderType.ToString() + " Shipment Notification";
            emailtemplate t = emailtemplate.GetByName(context, strName);
            if (t == null)
            {
                context.TheLeader.Error("Before using this feature, please create an email template named '" + strName + "'");
                return;
            }
            t.SendOrderEmail(context, order, false, "", false, true, false, "", "", "", "", "", true);
        }

        public virtual ListArgs OrdHedSearchCompanyArgsGet(ContextRz x, OrderSearchParameters pars)
        {
            ListArgs ret = new ListArgs(x);

            if (pars.CurrentOrderType != Enums.OrderType.Any)
                ret.TheTemplate = "ORDERSEARCH-" + pars.CurrentOrderType.ToString().ToUpper();
            else
                ret.TheTemplate = "order_search_results";

            nSQL xsAbsolute = new nSQL(true);
            xsAbsolute.strClass = pars.CurrentOrderClass;
            if (pars.CurrentOrderClass != pars.CurrentOrderTable)
                xsAbsolute.strAlternateTable = pars.CurrentOrderTable;

            String strOrderType = "";
            if (pars.OrderType != Enums.OrderType.Any)
                strOrderType = pars.OrderType.ToString();

            if (pars.CurrentOrderType != Enums.OrderType.Any)
            {
                ret.TheCaption = Tools.Strings.NiceFormat(pars.CurrentOrderType.ToString()) + " Search";
                xsAbsolute.AddWhere(x, pars.CurrentOrderTable + ".ordertype", pars.CurrentOrderType.ToString(), NewMethod.Enums.CompareType.Equal);
                strOrderType = pars.CurrentOrderType.ToString();  //for use below
            }
            else
            {
                if (Tools.Strings.StrExt(strOrderType))
                {
                    ret.TheCaption = Tools.Strings.NiceFormat(strOrderType) + " Search";
                    xsAbsolute.AddWhere(x, pars.CurrentOrderTable + ".ordertype", strOrderType, NewMethod.Enums.CompareType.Equal);
                }
            }

            //if (!pars.IncludeVoid && !Tools.Strings.StrExt(pars.OrderNumber))
            if (!pars.IncludeVoid)
            {
                xsAbsolute.AddWhere(x, "isnull(" + pars.CurrentOrderTable + ".isvoid, 0)", "0", NewMethod.Enums.CompareType.Equal);
            }
            else//Show only voids if void selected.  Note this means we can no longer see voids grouped in with sales.
            {
                xsAbsolute.AddWhere(x, "isnull(" + pars.CurrentOrderTable + ".isvoid, 0)", "1", NewMethod.Enums.CompareType.Equal);
            }

            if (!pars.bSuppliedLimit)
            {
                xsAbsolute.AddWhere_Date(x.xSys, pars.CurrentOrderTable + ".orderdate", pars.StartDate, pars.EndDate);
                String strStatus = pars.OrderStatus;
                if (Tools.Strings.StrCmp(strStatus, "open"))
                    xsAbsolute.AddWhere_Boolean(x, pars.CurrentOrderTable + ".isclosed", false);
                else if (Tools.Strings.StrCmp(strStatus, "closed"))
                    xsAbsolute.AddWhere_Boolean(x, pars.CurrentOrderTable + ".isclosed", true);
                //KT Here is where it checks for which agent's orders to return.  
                //If a user doesn't have permission to view all orders, restrict to their agent.
                if (!x.CheckPermit(Permissions.ThePermits.OpenAllOrders))
                    xsAbsolute.AddWhere(x, pars.CurrentOrderTable + ".agentname", pars.Agent.Name);//Allow Current User to view own orders
                else if (pars.SelectedAgent != null)// Else if agent DOES have permission to view all users, is one selected?  If so restrict.
                {                    //Else if user does have permission to view all, has user selected a specific agent?
                    xsAbsolute.AddWhere(x, pars.CurrentOrderTable + ".agentname", pars.SelectedAgent.Name);
                }
                //NewMethod.n_user u = null;
                //bool isCaptain = false;
                //if (!string.IsNullOrEmpty(pars.Agent))                       
                //{
                //    //foreach (NewMethod.n_user u in n_user.HiddenAccounts)
                //     //n_user salesAgent = n_user.GetById(x, s.base_mc_user_uid);//needed for email     
                //    u = n_user.GetByName(x, pars.Agent.ToString());
                //    if (IsUserTeamCaptainofSelectedAgent(x, (Rz5.n_user)u))//Allow Current User to view own orders
                //        //xsAbsolute.AddWhere(x, pars.CurrentOrderTable + ".agentname", pars.Agent);//Allow Current User to view own orders
                //        isCaptain = true;
                //}


                bool pfe = false;
                String strPhone = pars.PhoneFaxEmail;
                if (Tools.Strings.StrExt(strPhone))
                    pfe = true;
                if (nTools.IsEmailAddress(strPhone))
                    xsAbsolute.AddWhere(x, pars.CurrentOrderTable + ".primaryemailaddress", strPhone);
                else
                {
                    strPhone = strPhone.Replace("-", "%");
                    nSQL xp = new nSQL(false);
                    xp.AddWhere(x, "replace(replace(replace(replace(replace(" + pars.CurrentOrderTable + ".primaryphone, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", strPhone);
                    xp.AddWhere(x, "replace(replace(replace(replace(replace(" + pars.CurrentOrderTable + ".primaryfax, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", strPhone);
                    xsAbsolute.AddNonAbsolute(xp);
                }
                if (Tools.Strings.StrExt(pars.Phone) && !pfe)
                {
                    nSQL xp = new nSQL(false);
                    xp.AddWhere(x, "replace(replace(replace(replace(replace(" + pars.CurrentOrderTable + ".primaryphone, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", pars.Phone.Replace("-", "%").Replace(" ", "%").Replace("(", "%").Replace(")", "%").Replace(".", "%"));
                    xsAbsolute.AddNonAbsolute(xp);
                }
                if (Tools.Strings.StrExt(pars.Fax) && !pfe)
                {
                    nSQL xp = new nSQL(false);
                    xp.AddWhere(x, "replace(replace(replace(replace(replace(" + pars.CurrentOrderTable + ".primaryfax, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", pars.Fax.Replace("-", "%").Replace(" ", "%").Replace("(", "%").Replace(")", "%").Replace(".", "%"));
                    xsAbsolute.AddNonAbsolute(xp);
                }
                if (Tools.Strings.StrExt(pars.Email) && !pfe)
                    xsAbsolute.AddWhere(x, pars.CurrentOrderTable + ".primaryemailaddress", pars.Email);
                if (Tools.Strings.StrExt(pars.PartNumber))
                {
                    switch (pars.DetailType)
                    {
                        case Enums.OrderType.Any:
                            StringBuilder sbAll = new StringBuilder();
                            sbAll.Append(" ( ");
                            sbAll.Append(OrdHedSearchGetByPart(x, pars, Enums.OrderType.Quote));
                            sbAll.Append(" or " + OrdHedSearchGetByPart(x, pars, Enums.OrderType.RFQ));
                            sbAll.Append(" or " + OrdHedSearchGetByPart(x, pars, Enums.OrderType.Sales));
                            sbAll.Append(" or " + OrdHedSearchGetByPart(x, pars, Enums.OrderType.Purchase));
                            sbAll.Append(" or " + OrdHedSearchGetByPart(x, pars, Enums.OrderType.Service));
                            sbAll.Append(" or " + OrdHedSearchGetByPart(x, pars, Enums.OrderType.Invoice));
                            sbAll.Append(" or " + OrdHedSearchGetByPart(x, pars, Enums.OrderType.RMA));
                            sbAll.Append(" or " + OrdHedSearchGetByPart(x, pars, Enums.OrderType.VendRMA));
                            sbAll.Append(" ) ");

                            xsAbsolute.CheckAdd();
                            xsAbsolute.AddDirectWhere(sbAll.ToString());

                            break;
                        default:
                            xsAbsolute.CheckAdd();
                            xsAbsolute.AddDirectWhere(OrdHedSearchGetByPart(x, pars, pars.DetailType));
                            break;
                    }
                }

                //String strMFG = pars.Manufacturer;  //removed 2011_06_20 - is there even a box for this option anywhere?
                //if (Tools.Strings.StrExt(strMFG))
                //{
                //    xsAbsolute.CheckAdd();
                //    if (strMFG.Length > 3)
                //        xsAbsolute.AddDirectWhereAnd(" exists (select * from " + detailTable + " where " + detailTable + "." + linkField + " = " + pars.CurrentOrderTable + ".unique_id and " + detailTable + ".manufacturer like '%" + Rz3App.context.Filter(PartObject.StripPart(strMFG)) + "%')");
                //    else
                //        xsAbsolute.AddDirectWhereAnd(" exists (select * from " + detailTable + " where " + detailTable + "." + linkField + " = " + pars.CurrentOrderTable + ".unique_id and " + detailTable + ".manufacturer like '" + Rz3App.context.Filter(PartObject.StripPart(strMFG)) + "%')");
                //}

                //Optional
                xsAbsolute.AddWhere(x, pars.CurrentOrderTable + ".companyname", pars.CompanyName.Replace(" ", "%"));
                xsAbsolute.AddWhere(x, pars.CurrentOrderTable + ".contactname", pars.ContactName.Replace(" ", "%"));

                nSQL xsOptional = new nSQL(false);
                xsOptional.AddWhere(x, pars.CurrentOrderTable + ".ordernumber", pars.OrderNumber);
                xsOptional.AddWhere(x, pars.CurrentOrderTable + ".orderreference", pars.OrderNumber);
                xsOptional.AddWhere(x, pars.CurrentOrderTable + ".hubspot_deal_id", pars.HubspotDealID);

                if (Tools.Strings.StrExt(pars.Everything))
                {
                    xsOptional.AddWhere(x, pars.CurrentOrderTable + ".ordernumber", pars.Everything);
                    xsOptional.AddWhere(x, pars.CurrentOrderTable + ".orderreference", pars.Everything);

                    xsOptional.AddWhere(x, pars.CurrentOrderTable + ".companyname", pars.Everything, NewMethod.Enums.CompareType.LikeTrailing);
                    xsOptional.AddWhere(x, pars.CurrentOrderTable + ".contactname", pars.Everything, NewMethod.Enums.CompareType.LikeTrailing);
                }

                if (pars.OrderType == Enums.OrderType.Purchase)
                {
                    switch (pars.OnlyConfirmedPOs.ToLower())
                    {
                        case "confirmed":
                            {
                                xsOptional.AddDirectWhereAnd(" isnull(is_confirmed, 0) = 1 ");
                                break;
                            }
                        case "un-confirmed":
                            {
                                xsOptional.AddDirectWhereAnd(" isnull(is_confirmed, 0) = 0 ");
                                break;
                            }
                        default:
                            break;
                    }



                }
                //KT DDL For Paid Invoice Status
                else if (pars.OrderType == Enums.OrderType.Invoice)
                {
                    switch (pars.InvoiceStatus)
                    {
                        case "All":
                            break;
                        case "Open": //Payments are 0 or less than total
                                     //xsOptional.AddDirectWhereAnd(" ( (select SUM(transamount) from checkpayment where base_ordhed_uid = ordhed_invoice.unique_id) < ordhed_invoice.ordertotal ) ");
                            xsOptional.AddDirectWhereAnd("ROUND((select isnull(SUM(transamount),0) from checkpayment where base_ordhed_uid = ordhed_invoice.unique_id),2) < ROUND(ordhed_invoice.ordertotal,2)");

                            break;
                        case "Aged": //Open orders that where today is Greated than their Terms Dictate.   
                            {
                                //xsOptional.AddDirectWhereAnd("(isnull((select SUM(transamount) from checkpayment where base_ordhed_uid = ordhed_invoice.unique_id), 0) = 0) and (datediff(day, orderdate, GetDate()) > 30 AND outstandingamount > 0)");
                                string agedInvoiceWhere = "(isnull((select SUM(transamount) from checkpayment where base_ordhed_uid = ordhed_invoice.unique_id), 0) = 0) and ordhed_invoice.ordertotal > 0 ";
                                agedInvoiceWhere += "and(datediff(day, orderdate, GetDate()) > (case ";

                                agedInvoiceWhere += "WHEN ordhed_invoice.terms LIKE '%N30%' then 30 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms LIKE '%60%' then 60 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms LIKE '%50%' then 50 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms LIKE '%45%' then 45 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms LIKE '%40%' then 40 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms LIKE '%30%' then 30 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms LIKE '%20%' then 20 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms LIKE '%15%' then 15 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms LIKE '%14%' then 14 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms LIKE '%7%' then 7 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms LIKE '1' then 1 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms = 'Mastercard' then 0 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms = 'Escrow' then 0 ";
                                agedInvoiceWhere += "WHEN ordhed_invoice.terms = 'Upon Delivery' then 0 ";
                                agedInvoiceWhere += "ELSE 30 ";
                                agedInvoiceWhere += "end)) ";
                                xsOptional.AddDirectWhereAnd(agedInvoiceWhere);
                            }

                            break;
                    }

                }
                else if (pars.OrderType == Enums.OrderType.Sales)
                {
                    switch (pars.InvoiceStatus)
                    {
                        case "All":
                            break;
                        case "Invoiced":
                            xsOptional.AddDirectWhereAnd("(select count(orderid_invoice) from orddet_line where LEN(isnull(orderid_invoice, 0)) > 0 and orderid_sales = ordhed_Sales.unique_id) > 0");
                            break;
                        case "Not Invoiced":
                            xsOptional.AddDirectWhereAnd("(select count(orderid_invoice) from orddet_line where LEN(isnull(orderid_invoice, 0)) > 0 and orderid_sales = ordhed_Sales.unique_id) = 0");
                            break;
                    }
                }
                else if (pars.OrderType == Enums.OrderType.Quote)
                {
                    switch (pars.oppportinity_stage)
                    {
                        case "All":
                            break;
                        case "Open":
                            xsOptional.AddDirectWhereAnd("opportunity_stagenot like '%lost%'");
                            break;
                        case "Won":
                            xsOptional.AddDirectWhereAnd("opportunity_stage = 'Won' || opportunity_stage = " + OpportunityStage.sale_won.ToString() + "'");
                            break;
                        case "Lost":
                            xsOptional.AddDirectWhereAnd("opportunity_stage = 'Lost'  || opportunity_stage = '" + OpportunityStage.sale_lost.ToString() + "");
                            break;
                    }
                }



                xsAbsolute.AddNonAbsolute(xsOptional);
                xsAbsolute.AddWhere(x, pars.CurrentOrderTable + ".trackingnumber", pars.TrackingNumber);
                if (pars.ConsignmentOnly && pars.CurrentOrderType != Enums.OrderType.Any)
                    xsAbsolute.AddDirectWhereAnd(pars.CurrentOrderTable + ".unique_id in (select orderid_" + pars.CurrentOrderType.ToString() + " from orddet_line where stocktype = 'consign')");
            }
            String inv = x.Logic.CheckAppendInvisibleCompanies(x, "", "");
            if (Tools.Strings.StrExt(inv))
                xsAbsolute.AddDirectWhereAnd(inv);
            xsAbsolute.strOrder = pars.CurrentOrderTable + ".orderdate desc";
            ret.TheOrder = pars.CurrentOrderTable + ".orderdate desc";
            if (pars.bSuppliedLimit)
            {
                xsAbsolute.lngLimit = (pars.RowLimit != 0) ? pars.RowLimit : 200;
            }
            else
            {
                if (pars.UnlimitedResults)
                    xsAbsolute.lngLimit = -1;
                else
                    xsAbsolute.lngLimit = pars.RowLimit;
            }
            //2010_11_09  this was missing!
            ret.TheLimit = Convert.ToInt32(xsAbsolute.lngLimit);
            if (PreLimitSQL(pars, strOrderType))
                LimitSQL(x, xsAbsolute, pars);
            if (pars.OpenQuotes)
                xsAbsolute.AddDirectWhereAnd("not exists ( select * from ordlnk where ordlnk.orderid1 = " + pars.CurrentOrderTable + ".unique_id and ordertype2 = 'SALES' )");
            if (!x.xUser.super_user)
                AddHiddenAccounts(x, ref xsAbsolute);
            if (Tools.Strings.StrExt(pars.Office))
                xsAbsolute.AddDirectWhereAnd(pars.CurrentOrderTable + ".base_mc_user_uid in (select unique_id from n_user where main_location = '" + pars.Office + "')");



            ret.SQL = xsAbsolute;
            ret.TheWhere = xsAbsolute.RenderSQL();

            if (pars.CurrentOrderType == Enums.OrderType.Any)
                ret.TheClass = "ordhed";
            else
                ret.TheClass = "ordhed_" + pars.CurrentOrderType.ToString().ToLower();

            ret.AddAllow = false;

            return ret;
        }

        public bool IsUserTeamCaptainofSelectedAgent(ContextRz x, n_user selectedAgent)
        {
            if (selectedAgent == null)
                return false;
            //x holds the current user x.xUser       
            //Captains are currently only used for team managers
            //If you are a team captain, you can view and edit all companies and orders on your team. 
            foreach (n_team team in n_team.GetAllTeamsForUser(x, selectedAgent.unique_id))//All the teams the Agent belongs to
            {
                //if xUser is Captain of one of those teams
                n_member m = n_member.GetMemberByTeamID(x, team, x.xUser.unique_id);
                if (m != null)
                    if (m.is_captain)
                    {
                        return true;//Allow Access
                    }

            }
            return false;//Deny Access
        }



        public bool Prevalidate(ContextRz x, ordhed_sales s, validation_form vf)
        {
            //Get lines at this point so stock is included.   
            List<orddet_line> lines = s.DetailsListCompleteReady(x, true);
            if (lines.Count <= 0)
                return false;

            foreach (orddet_line l in lines)
            {

                if (!x.TheSysRz.TheLineLogic.CheckEraiTable(x, l.fullpartnumber))
                    return false;
            }

            if (!ValidateCompanyTermsConditions(x, s.base_company_uid))
                return false;



            return true;

        }

        private bool ValidateCompanyTermsConditions(ContextRz x, string companyID)
        {
            company_terms_conditions ct = company_terms_conditions.GetByCompanyID(x, companyID);
            company c = company.GetById(x, companyID);
            string termsMessage = "";
            Dictionary<string, string> termsList = new Dictionary<string, string>();
            if (ct != null)
            {
                if (ct.has_broker_restriction)
                    termsList.Add("Broker Restriction", null);
                if (ct.has_rohs_restriction)
                    termsList.Add("RoHS Restriction", null);
                if (ct.has_coo_restriction)
                    termsList.Add("COO (Country of Origin) Restriction", null);


                if (ct.has_dc_restriction)
                    termsList.Add("DateCode Restriction", ct.has_dc_restriction_detail);
                if (ct.has_packaging_restriction)
                    termsList.Add("Packaging Restriction", ct.has_packaging_restriction_detail);
                if (ct.has_testing_restriction)
                    termsList.Add("Testing Restriction", ct.has_testing_restriction_detail);
            }
            if (termsList.Count > 0)
            {
                termsMessage = c.companyname + " has the following Terms / Conditions / Restrictions:  " + Environment.NewLine + Environment.NewLine;
            }
            foreach (KeyValuePair<string, string> kvp in termsList)
            {
                if (kvp.Value != null)
                    termsMessage += kvp.Key + " (" + kvp.Value + ")" + Environment.NewLine;
                else
                    termsMessage += kvp.Key + Environment.NewLine;
            }
            if (!string.IsNullOrEmpty(termsMessage))
            {
                termsMessage += Environment.NewLine + Environment.NewLine + "Please ensure all order lines and services are in compliance.";
                x.Leader.Tell(termsMessage);
            }

            return true;
        }

        public void UpdateValidationFormStatus(ContextRz x, validation_form vf, bool pass)
        {
            if (vf == null)
                return;
            if (pass)
                vf.prevalidation_complete = true;
            else
                vf.prevalidation_complete = false;
            vf.date_modified = DateTime.Now;
            vf.pv_agentname = x.xUser.Name;
            vf.pv_agent_uid = x.xUser.unique_id;
            vf.Update(x);
            //validation_tracking vt = null;          


        }


        private bool PrevalCheckLineDockDates(ContextRz x, List<orddet_line> lines)
        {
            //I might be able to grab or calculate the estimated lead time based on whether they are overseas, or otherwise going for testing.  May need to add signals earlier in the order process.
            //Maybe upon 1st address creation for a company, grab Country, if != USA, set flag add_10_days, etc.
            string message = "Are the following customer dock dates realistic?  (Remember to add 10 days for ALL external testing i.e. overseas vendors)";
            string linesDockDates = "";
            foreach (orddet_line l in lines)
            {

                linesDockDates += l.fullpartnumber + "  |  " + l.vendor_name + "  |  " + l.customer_dock_date.ToString("M-d-yyyy") + Environment.NewLine + Environment.NewLine;
            }
            if (!x.Leader.OkCancelFormatting(message, linesDockDates))
                return false;

            return true;
        }






        public string GetAndSyncOpportunityStage(ContextRz x, object rzObject)
        {

            //Instantiating these just to make it easier to remember them all while I develop and not have to reference nEnum over and over again.
            //string rfq_received = OpportunityStage.rfq_received.ToString();
            //string formal_quote_created = OpportunityStage.formal_quote_created.ToString();
            //string sale_won = OpportunityStage.sale_won.ToString();
            //string sale_lost = OpportunityStage.sale_lost.ToString();

            //Carry the original & new stage to determine if update needed.
            string originalStage = "";
            string newStage = "";



            //Get any existing stage from the object.  IF null, set to the base value for the object type
            if (rzObject is dealheader)
            {
                dealheader d = (dealheader)rzObject;
                originalStage = d.opportunity_stage;
                if (string.IsNullOrEmpty(originalStage))
                    originalStage = OpportunityStage.rfq_received.ToString();

            }
            else if (rzObject is ordhed)
            {
                ordhed o = (ordhed)rzObject;
                originalStage = o.opportunity_stage;
                if (string.IsNullOrEmpty(originalStage))
                {
                    if (o is ordhed_quote)
                        originalStage = OpportunityStage.formal_quote_created.ToString();
                    else
                        originalStage = OpportunityStage.sale_won.ToString();
                }

            }

            //We'll refer to the existence and status of the sale to determine opp stage, the formal Quote when no sale, and the dealheader when no quote. 
            //Process objects in the above order.            
            List<ordhed_sales> sList = null;
            List<ordhed_quote> qList = null;

            ordhed_sales oppOrdhedSales = GetOpportunitySale(x, rzObject);
            ordhed_quote oppFormalQuote = GetOpportunityQuote(x, rzObject);
            dealheader oppDealheader = GetOpportunityDealheader(x, rzObject);


            //Sale Wins, followed by FQ, then dealheader
            //Get the Current Stage (gotta check each order type for full sync.
            if (oppOrdhedSales != null)
                originalStage = oppOrdhedSales.opportunity_stage;
            else if (oppFormalQuote != null)
                originalStage = oppFormalQuote.opportunity_stage;
            else if (oppDealheader != null)
                originalStage = oppDealheader.opportunity_stage;

            //If nothing higher than a dealheader exists, set to rfq received.
            if (oppDealheader != null)
            {
                if (oppFormalQuote == null && oppOrdhedSales == null)
                    if (originalStage != OpportunityStage.rfq_received.ToString())
                    {
                        newStage = OpportunityStage.rfq_received.ToString();
                        oppDealheader.opportunity_stage = newStage;
                        oppDealheader.Update(x);
                        return newStage;
                    }


            }


            //Derive the current opportunity stage based on company rules, and the highest-level order object available:
            //Sales Logic
            if (oppOrdhedSales != null)
            {
                if (oppOrdhedSales.isvoid)
                    newStage = OpportunityStage.sale_lost.ToString();
                else
                    newStage = OpportunityStage.sale_won.ToString();
            }
            //If was sale won, but no sale exists
            if (oppOrdhedSales == null)
            {
                if (originalStage == OpportunityStage.sale_won.ToString())
                    if (oppFormalQuote != null)
                        newStage = OpportunityStage.formal_quote_created.ToString();
                    else if (oppDealheader != null)
                        newStage = OpportunityStage.rfq_received.ToString();
            }
            //Quote Logic
            else if (oppFormalQuote != null)
            {
                if (oppFormalQuote.isvoid)
                    newStage = OpportunityStage.sale_lost.ToString();
                else
                    newStage = OpportunityStage.sale_won.ToString();
            }
            else if (oppDealheader != null)
            {
                if (oppDealheader.is_closed)
                    newStage = OpportunityStage.sale_lost.ToString();
                else
                    newStage = OpportunityStage.sale_won.ToString();
            }

            //if at this point, we don't have a new stage, just set it to the original stage
            if (string.IsNullOrEmpty(newStage))
                newStage = originalStage;




            //Loop through the objects and update as necessary
            if (oppOrdhedSales != null)
                if (oppOrdhedSales.opportunity_stage != newStage)
                {
                    oppOrdhedSales.opportunity_stage = newStage;
                    oppOrdhedSales.Update(x);
                }
            if (oppFormalQuote != null)
                if (oppFormalQuote.opportunity_stage != newStage)
                {
                    oppFormalQuote.opportunity_stage = newStage;
                    oppFormalQuote.Update(x);
                }
            if (oppDealheader != null)
                if (oppDealheader.opportunity_stage != newStage)
                {
                    oppDealheader.opportunity_stage = newStage;
                    oppDealheader.Update(x);
                }



            return newStage;
        }








        public validation_tracking TrackValidation(ContextRz x, ordhed_sales s, string new_stage, bool overrideComplete = false)
        {
            // This bool is true if you want the sender to override the complete status.  Genreally we want that status to stick, and only be changed when actually necessary (i.e. gets placed on a hold)
            if (!overrideComplete)// This bool is true if you want the sender to override the complete status. 
            {
                //Genreally we want that status to stick, and only be changed when actually necessary, i.e. holds.
                if (s.validation_stage == Enums.SalesOrderValidationStage.ValidationComplete.ToString())
                    return null;
            }
            if (s.validation_stage == new_stage)
                return null;

            validation_tracking vt = new validation_tracking();
            vt.hold_reason = "N/A";
            vt.previous_stage = s.validation_stage;

            //bool isResolved = ();
            if (vt.previous_stage.ToLower().Contains("hold"))
            {
                vt.hold_reason = x.Leader.AskForString("Please provide resolution notes.", "", "Resolution");
                //if (string.IsNullOrEmpty(vt.hold_reason))
                //{
                //    x.Leader.Tell("You must provide a resolution.");
                //    return null;
                //}
            }
            if (new_stage.ToLower().Contains("hold"))
            {
                vt.hold_reason = x.Leader.AskForString("Please provide a reason for putting this order on " + new_stage + ":", "", "");
            }


            if (string.IsNullOrEmpty(vt.hold_reason))
            {
                x.Leader.Tell("You must provide a reason for updating the validation stage.");
                return null;
            }

            //Set the new stage
            vt.new_stage = new_stage;


            //if (s.validation_stage.ToLower().Contains("hold"))
            //    if (!x.CheckPermit(Permissions.ThePermits.CanValidate))
            //    {
            //        throw new Exception("Sorry, this order is on validation hold.  You do not have permission to change this validation. Please see mamangement for assistance.");
            //    }


            //Perform hold-specific tasks.
            //if (new_stage.ToLower().Contains("hold"))
            //{
            //    ////Get a reason for the hold
            //    //string hold_reason = x.Leader.AskForString("Please provide details for changing the validation stage.", "", "");
            //    //if (string.IsNullOrEmpty(hold_reason))
            //    //{
            //    //    x.Leader.Tell("You must provide a reason to put this order on  " + new_stage + ".");
            //    //    return null;
            //    //}
            //    ////If we have a valid reason, put the order on hold.
            //    //vt.hold_reason = hold_reason;
            //    //SendValidationHoldEmail(x, s, vt, false);
            //    //DoValidationHold(x, vt, s, new_stage);
            //}
            //else
            //    vt.new_stage = new_stage;



            //Save a new Validation Record
            SaveValidationTracking(x, s, vt);

            //Set Sale Validation
            SaveSaleValidation(x, s, vt);

            //Send Email Notification
            SendValidationHoldEmail(x, s, vt, false);
            return vt;
        }



        //public void DoValidationHold(ContextRz x, validation_tracking vt, ordhed_sales s, string HoldStage)
        //{

        //    if (s == null)
        //        return;



        //    //string alert_string = "";
        //    //string new_stage = "";
        //    if (HoldStage == Enums.SalesOrderValidationStage.ValidationHold.ToString())
        //    {
        //        //alert_string = "Validation Hold";
        //        vt.new_stage = Enums.SalesOrderValidationStage.ValidationHold.ToString();
        //    }
        //    else if (HoldStage == Enums.SalesOrderValidationStage.InspectionHold.ToString())
        //    {
        //        //alert_string = "Inspection Hold";
        //        vt.new_stage = Enums.SalesOrderValidationStage.InspectionHold.ToString();
        //    }
        //    else if (HoldStage == Enums.SalesOrderValidationStage.CustomerHold.ToString())
        //    {
        //        //alert_string = "Customer Hold";
        //        vt.new_stage = Enums.SalesOrderValidationStage.CustomerHold.ToString();
        //    }

        //    SendValidationHoldEmail(x, s, vt, false);

        //}

        private void SaveSaleValidation(ContextRz x, ordhed_sales s, validation_tracking vt)
        {


            //Save Items to Sales Order           
            s.validation_stage_agent = s.agentname;
            s.validation_stage_agent_id = s.base_mc_user_uid;
            s.validation_stage_timestamp = DateTime.Now;
            s.validation_stage = vt.new_stage;
            s.validation_hold_reason = vt.hold_reason ?? null;
            s.Update(x);
        }

        public validation_tracking SaveValidationTracking(ContextRz x, ordhed_sales s, validation_tracking vt)
        {

            try
            {
                vt.orderid_sales = s.unique_id;
                vt.ordernumber_sales = s.ordernumber;
                vt.agentname = x.xUser.Name;
                vt.agent_uid = x.xUser.unique_id;
                vt.companyname = s.companyname;
                vt.company_uid = s.unique_id;
                vt.Insert(x);
                return vt;
            }
            catch (Exception ex)
            {
                x.Leader.Tell(ex.Message);
                return null;
            }
        }

        public void SendStockAlertEmail(ContextRz x, List<orddet_line> stocklines, ordhed_sales sale)//alert shipping that a new stock or consign order is in validation
        {
            string PartNumbers = "";
            string company = sale.companyname;
            string sonumber = sale.ordernumber;
            foreach (orddet_line l in stocklines)
            {
                PartNumbers += "Line" + l.linecode_sales + ": " + l.fullpartnumber + ", " + "QTY: " + l.quantity;
                if (l != stocklines.Last())
                    PartNumbers += Environment.NewLine;
            }

            nEmailMessage m = new nEmailMessage();
            m.IsHTML = true;
            m.FromAddress = "stock_alert@sensiblemicro.com";
            m.ServerName = "smtp.sensiblemicro.local";
            m.ToAddress = "shipping@sensiblemicro.com";
            m.Subject = "New Stock Order Alert";
            m.HTMLBody = @"The Following Stock Lines for Sales Order " + sonumber + "(" + company + ")" + " are in validation and will need to ship soon:<br /><br />" + PartNumbers;
            m.Send();//Send to sales agent ALWAYS on complete withough confirmation

        }

        public void SendValidationHoldEmail(ContextRz x, ordhed_sales s, validation_tracking vt, bool confirm_email)
        {

            //List<SalesOrderValidationStage> holdStages = new List<SalesOrderValidationStage>() { SalesOrderValidationStage.CustomerHold, SalesOrderValidationStage.InspectionHold, SalesOrderValidationStage.ValidationHold };

            List<string> holdStages = new List<string>() { SalesOrderValidationStage.CustomerHold.ToString(), SalesOrderValidationStage.InspectionHold.ToString(), SalesOrderValidationStage.ValidationHold.ToString() };




            //setup string vars
            nEmailMessage m = new nEmailMessage();
            m.IsHTML = true;
            m.FromAddress = "validation@sensiblemicro.com";
            m.ServerName = "smtp.sensiblemicro.local";


            //set stage specific properties (subject, body, etc.) - interesting, can't use a switch statement with Enum.toString() becase return type ToString is not a constant.  Needs if else.

            //Validtion Hold
            if (vt.new_stage == Enums.SalesOrderValidationStage.ValidationHold.ToString() || vt.new_stage == Enums.SalesOrderValidationStage.InspectionHold.ToString() || vt.new_stage == Enums.SalesOrderValidationStage.CustomerHold.ToString())
                m = CreateValidationHoldEmail(x, s, vt, m);
            //Prevalidation
            else if (vt.previous_stage == Enums.SalesOrderValidationStage.PreValidation.ToString() && vt.new_stage == Enums.SalesOrderValidationStage.PreValidation.ToString())
                m = CreatePrevalidationEmail(x, s, vt, m);
            //Hold Resolved
            else if (holdStages.Contains(vt.previous_stage) && !holdStages.Contains(vt.new_stage))//Hold Resolutions
                m = CreateHoldResolutionEmail(x, s, vt, m);
            //Generic Change Notification
            else
                m = CreateValidationChangeEmail(x, s, vt, m);

            //Update the "to" address in case user decides to send confirmation, or in case confirm_email was false, 
            //in which case the email should go through withotu confirmation.
            if (x.xUser.IsDeveloper())
                m.ToAddress = "ktill@sensiblemicro.com";
            else
                m.ToAddress = "sm_validation@sensiblemicro.com";

            // was a confirmation prompt requested before email?
            if (confirm_email == true)
            {
                if (x.Leader.AskYesNo("Would you like to send an email to notify the validation team?"))
                    m.Send();
            }
            else
                //x.Leader.Tell("Email from "+m.FromAddress + " will be sent to "+ m.ToAddress+Environment.NewLine+ "Subject:  "+m.Subject +Environment.NewLine +  "Body: " + m.HTMLBody);
                m.Send();
        }

        private nEmailMessage CreateHoldResolutionEmail(ContextRz x, ordhed_sales s, validation_tracking vt, nEmailMessage m)
        {
            if (m == null)
                return null;
            //ExtraRecipients
            n_user salesAgent = s.AgentVar.RefGet(x);
            if (salesAgent != null)
            {
                if (x.xUser.IsDeveloper())
                    m.CcRecipients.Add("systems@sensiblemicro.com");
                else
                    m.CcRecipients.Add(salesAgent.email_address.Trim().ToLower());
            }

            //Subject
            m.Subject = "Hold Resolved: SO# " + s.ordernumber;
            //Body
            m.HTMLBody = "Order Number: <b>" + s.ordernumber + "</b>";
            m.HTMLBody += "<br />Agent: <b>" + s.agentname + "</b> ";
            m.HTMLBody += "<br /> Customer: <b>" + s.companyname + "</b> ";
            m.HTMLBody += "<br /> Validator: <b>" + vt.agentname + "</b> ";
            m.HTMLBody += "<br /> New Validation Stage: <b>" + s.validation_stage + "</b> ";
            m.HTMLBody += "<br /> Resoltion Reason: <b>" + vt.hold_reason + "</b>";
            return m;
        }

        private nEmailMessage CreateValidationChangeEmail(ContextRz x, ordhed_sales s, validation_tracking vt, nEmailMessage m)
        {
            if (m == null)
                return null;
            //ExtraRecipients
            //Subject
            m.Subject = "Sales Order# " + s.ordernumber + " has entered  the " + s.validation_stage + " stage";
            //Body
            m.HTMLBody = "Order Number: <b>" + s.ordernumber + "</b>";
            m.HTMLBody += "<br />Agent: <b>" + s.agentname + "</b> ";
            m.HTMLBody += "<br /> Customer: <b>" + s.companyname + "</b> ";
            m.HTMLBody += "<br /> Validator: <b>" + vt.agentname + "</b> ";
            m.HTMLBody += "<br /> New Validation Stage: <b>" + s.validation_stage + "</b> ";
            m.HTMLBody += "<br /> Previous Validation Stage: <b>" + vt.previous_stage + "</b>";
            return m;
        }
        private nEmailMessage CreateValidationHoldEmail(ContextRz x, ordhed_sales s, validation_tracking vt, nEmailMessage m)
        {
            if (m == null)
                return null;
            //ExtraRecipients
            n_user salesAgent = n_user.GetById(x, s.base_mc_user_uid);//needed for email          
            if (salesAgent != null)
                m.CcRecipients.Add(salesAgent.email_address);
            m.BccRecipients.Add("sm_exec@sensiblemicro.com");
            //Subject
            m.Subject = "Hold Alert:  Sales Order# " + s.ordernumber + " has entered has been placed on " + vt.new_stage + ".";
            //Body
            m.HTMLBody = "Order Number: <b>" + s.ordernumber + "</b>";
            m.HTMLBody += "<br /> Agent: <b>" + s.agentname + "</b>";
            m.HTMLBody += "<br /> Validator: <b>" + vt.agentname + "</b>";
            m.HTMLBody += "<br /> Customer: <b>" + s.companyname + "</b>";
            m.HTMLBody += "<br /> Hold Type: <b>" + vt.new_stage + "</b>";
            m.HTMLBody += "<br />Hold reason: <b>" + vt.hold_reason + "</b>";
            return m;
        }
        public nEmailMessage CreatePrevalidationEmail(ContextRz x, ordhed_sales s, validation_tracking vt, nEmailMessage m)
        {
            if (m == null)
                return null;
            //ExtraRecipients
            //Subject
            m.Subject = "Sales Order# " + s.ordernumber + " has been created";
            //Body           
            m.HTMLBody = "Order Number: <b>" + s.ordernumber + "</b>";
            m.HTMLBody += "<br /> Agent: <b>" + s.agentname + "</b>";
            m.HTMLBody += "<br /> Customer: <b>" + s.companyname + "</b>";
            m.HTMLBody += "<br /> Validation Stage: <b>" + s.validation_stage + "</b>";
            return m;
        }





        protected virtual bool PreLimitSQL(OrderSearchParameters p, string type)
        {
            return true;
        }

        protected virtual String OrdHedSearchGetByPart(ContextRz x, OrderSearchParameters pars, Enums.OrderType type)
        {
            String strPart = pars.PartNumber;
            string insert = "";
            switch (type)
            {
                case Enums.OrderType.Invoice:
                case Enums.OrderType.Sales:
                case Enums.OrderType.RMA:
                case Enums.OrderType.Service:
                    insert = " or internal_customer like '%" + x.Filter(strPart) + "%' ";
                    break;
                case Enums.OrderType.Purchase:
                case Enums.OrderType.VendRMA:
                    insert = " or internal_vendor like '%" + x.Filter(strPart) + "%' ";
                    break;
            }
            switch (type)
            {
                case Enums.OrderType.Quote:
                case Enums.OrderType.RFQ:
                    if (strPart.Length > 3)
                        return " exists (select * from orddet_" + type.ToString().ToLower() + " where base_ordhed_uid = " + pars.CurrentOrderTable + ".unique_id and ( orddet_" + type.ToString().ToLower() + ".part_number_stripped like '%" + x.Filter(PartObject.StripPart(strPart)) + "%' or orddet_" + type.ToString().ToLower() + ".alternatepartstripped like '%" + x.Filter(PartObject.StripPart(strPart)) + "%' or internalstripped like '%" + x.Filter(strPart) + "%' ))";
                    else
                        return " exists (select * from orddet_" + type.ToString().ToLower() + " where base_ordhed_uid = " + pars.CurrentOrderTable + ".unique_id and ( orddet_" + type.ToString().ToLower() + ".part_number_stripped like '" + x.Filter(PartObject.StripPart(strPart)) + "%' or orddet_" + type.ToString().ToLower() + ".alternatepartstripped like '" + x.Filter(PartObject.StripPart(strPart)) + "%' or internalstripped like '%" + x.Filter(strPart) + "%' ))";
                default:
                    if (strPart.Length > 3)
                        return " exists (select * from orddet_line where orderid_" + type.ToString().ToLower() + " = " + pars.CurrentOrderTable + ".unique_id and ( orddet_line.part_number_stripped like '%" + x.Filter(PartObject.StripPart(strPart)) + "%' or orddet_line.alternatepartstripped like '%" + x.Filter(PartObject.StripPart(strPart)) + "%' " + insert + " or orddet_line.purchased_as_stripped like '%" + x.Filter(strPart) + "%'))";
                    else
                        return " exists (select * from orddet_line where orderid_" + type.ToString().ToLower() + " = " + pars.CurrentOrderTable + ".unique_id and ( orddet_line.part_number_stripped like '" + x.Filter(PartObject.StripPart(strPart)) + "%' or orddet_line.alternatepartstripped like '" + x.Filter(PartObject.StripPart(strPart)) + "%' " + insert + " or orddet_line.purchased_as_stripped like '" + x.Filter(strPart) + "%'))";
            }
        }

        public virtual void LimitSQL(ContextRz x, nSQL s, OrderSearchParameters pars)
        {
            bool add_limit = false;




            switch (pars.CurrentOrderType.ToString().ToLower())
            {
                case "rfq":
                    if (!x.CheckPermit(Permissions.ThePermits.OpenAllFormalQuotes))
                        add_limit = true;
                    break;
                case "quote":
                    if (!x.CheckPermit(Permissions.ThePermits.OpenAllFormalQuotes))
                        add_limit = true;
                    break;
                case "sales":
                    if (!x.CheckPermit(Permissions.ThePermits.OpenAllSalesOrders))
                        add_limit = true;
                    break;
                case "invoice":
                    if (!x.CheckPermit(Permissions.ThePermits.OpenAllInvoices))
                        add_limit = true;
                    break;
                case "purchase":
                    if (!x.CheckPermit(Permissions.ThePermits.OpenAllPurchaseOrders))
                        add_limit = true;
                    break;
                case "rma":
                    if (!x.CheckPermit(Permissions.ThePermits.OpenAllRMAs))
                        add_limit = true;
                    break;
                case "vendrma":
                    if (!x.CheckPermit(Permissions.ThePermits.OpenAllVRMAs))
                        add_limit = true;
                    break;
                case "service":
                    if (!x.CheckPermit(Permissions.ThePermits.OpenAllServiceOrders))
                        add_limit = true;
                    break;
                default:
                    if (!x.xUser.super_user && !x.CheckPermit(Permissions.ThePermits.OpenAllOrders))
                        add_limit = true;
                    break;
            }


            if (x.xUser.IsTeamMember(x, "sales_assistant", x.xUser)) // ALlow load all agents in picker if sales_assistant
                add_limit = false;

            bool hasSplitCommissionOrders = UserHasSplitCommissionOrders(x, pars);
            //IF we have a specifig agent chosen,  or of current agent only has permits to see his own.
            if (pars.SelectedAgent != null)
                if (add_limit || hasSplitCommissionOrders)
                {
                    s.CheckAdd();

                    LimitSqlByAgent(x, s, pars);
                }
        }

        private bool UserHasSplitCommissionOrders(ContextRz x, Rz5.OrderSearchParameters pars)
        {
            //Joe / Super User may be viewing non super-user Collin's orders, as a manager.  Need to add these split orders to the Grid
            string selectedAgent = pars.Agent.Name;
            ArrayList splitCommissionLines = x.SelectScalarArray("select * from orddet_line where split_commission_agent_uid = '" + pars.Agent.unique_id + "'");
            if (splitCommissionLines.Count > 0)
                return true;
            return false;

        }

        protected virtual void LimitSqlByAgent(ContextRz context, nSQL s, OrderSearchParameters pars)
        {
            //KT - HEre I might be able to catch team
            //IF current user is assistant to base_mc_user_uid of current order, allow open.

            //Original Code
            //if (!String.IsNullOrEmpty(context.xUserRz.assistant_to_uid))
            //showAgentIDs.Add(context.xUserRz.assistant_to_uid);
            //s.AddDirectWhere(" " + pars.CurrentOrderTable + ".base_mc_user_uid = '" + context.xUser.unique_id + "' OR " + pars.CurrentOrderTable + ".base_mc_user_uid = '" + context.xUserRz.assistant_to_uid + "'");
            //else
            //    s.AddDirectWhere(" " + pars.CurrentOrderTable + ".base_mc_user_uid = '" + context.xUser.unique_id + "' ");



            //KT new Method - carry a list of allowed ID's
            //get a list of allowed to view ID's
            List<string> showAgentIDs = new List<string>();

            showAgentIDs.Add(context.xUser.unique_id);//Include the current user on the list so they can see their own order           

            //Assistants
            if (!string.IsNullOrEmpty(context.xUserRz.assistant_to_uid))//if you are the assistant to a selected user, show them in the list.
                showAgentIDs.Add(context.xUserRz.assistant_to_uid);


            //Assistant Leaders
            //if you are the assistant leader of the selected user, allow to view your users.
            ArrayList assistants = new ArrayList();
            if (context.xUser.IsAssistantLeader(context))
                assistants = context.xUser.GetAssistantsForLeader(context, context.xUser.unique_id);

            foreach (n_user uu in assistants)
            {
                if (!showAgentIDs.Contains(uu.unique_id))
                    showAgentIDs.Add(uu.unique_id);
            }

            //Team Captains
            //n_user u = n_user.GetByName(context, pars.Agent);//if you are the team captain of the selected user, show your team members in the list
            if (IsUserTeamCaptainofSelectedAgent(context, pars.Agent) && !showAgentIDs.Contains(pars.Agent.unique_id))
                showAgentIDs.Add(pars.Agent.unique_id);
            if (showAgentIDs.Count == 0) //if nothing in here, add the current user
                showAgentIDs.Add(context.xUser.unique_id);

            //Split Commission  - If you are the split commission agent on one or more orddet_quote, or orddet_line, you can view the order (including any NON split lines on that order)         
            List<string> splitCommissionOrderIds = GetSplitCommissionOrderIds(context, pars);

            //Make sure the selected user's id is in the list.  |Important if manager, etc, is viewing the report (i.e. xUser is not the sale owner, or split agent)
            if (!showAgentIDs.Contains(pars.Agent.unique_id))
                showAgentIDs.Add(pars.Agent.unique_id);
            //Add the parameters
            string daWhere = " " + pars.CurrentOrderTable + ".base_mc_user_uid IN (" + Tools.Data.GetIn(showAgentIDs) + ")";
            if (splitCommissionOrderIds.Count > 0)
                daWhere += " OR  (" + pars.CurrentOrderTable + ".unique_id IN(" + Tools.Data.GetIn(splitCommissionOrderIds) + "))";

            s.AddDirectWhere(daWhere);

        }

        private List<string> GetSplitCommissionOrderIds(ContextRz context, OrderSearchParameters pars)
        {
            List<string> ret = new List<string>();
            //If the current user is a split commission agent.
            //If the user is any kind of split ont he company level, allow view
            string agentID = context.xUser.unique_id;
            if (context.xUser.unique_id != pars.Agent.unique_id)
                agentID = pars.Agent.unique_id;

            string sql = "select * from orddet_line where split_commission_agent_uid = '" + agentID + "'  and LEN(orderid_sales) > 0";
            string dateLimit = "";
            DateTime nullDateTime = new DateTime(1901, 01, 01);
            if (pars.StartDate > nullDateTime && pars.EndDate > nullDateTime)
                dateLimit = " AND date_created between cast('" + pars.StartDate + "' as datetime) and cast('" + pars.EndDate + "' as datetime) ";
            else if (pars.StartDate > nullDateTime)
                dateLimit = " AND date_created >= cast('" + pars.StartDate + "' as datetime) ";
            else if (pars.EndDate > nullDateTime)
                dateLimit = " AND date_created < cast('" + pars.EndDate + "' as datetime) ";



            ArrayList orderIDsWithSplitCommission = context.QtC("orddet_line", sql + dateLimit);
            foreach (orddet_line l in orderIDsWithSplitCommission)
            {
                //Need to switch by order type
                if (pars.CurrentOrderType == OrderType.Sales)
                {
                    if (!string.IsNullOrEmpty(l.orderid_sales))
                        if (!ret.Contains(l.orderid_sales))
                            ret.Add(l.orderid_sales);
                }
                else if (pars.CurrentOrderType == OrderType.Invoice)
                {
                    if (!string.IsNullOrEmpty(l.orderid_invoice))
                        if (!ret.Contains(l.orderid_invoice))
                            ret.Add(l.orderid_invoice);
                }
                else if (pars.CurrentOrderType == OrderType.Purchase)
                {
                    if (!string.IsNullOrEmpty(l.orderid_purchase))
                        if (!ret.Contains(l.orderid_purchase))
                            ret.Add(l.orderid_purchase);
                }
                else if (pars.CurrentOrderType == OrderType.RMA)
                {
                    if (!string.IsNullOrEmpty(l.orderid_rma))
                        if (!ret.Contains(l.orderid_rma))
                            ret.Add(l.orderid_rma);
                }

                else if (pars.CurrentOrderType == OrderType.VendRMA)
                {
                    if (!string.IsNullOrEmpty(l.orderid_vendrma))
                        if (!ret.Contains(l.orderid_vendrma))
                            ret.Add(l.orderid_vendrma);
                }

            }
            string quoteSql = "select * from orddet_quote where split_commission_agent_uid = '" + agentID + "'  and LEN(base_ordhed_uid) > 0";
            ArrayList quoteIDsWithSplitCommission = context.QtC("orddet_quote", quoteSql + dateLimit);

            foreach (orddet_quote l in quoteIDsWithSplitCommission)
            {
                if (!ret.Contains(l.base_ordhed_uid))
                    ret.Add(l.base_ordhed_uid);
            }

            return ret;
        }

        private void AddHiddenAccounts(ContextNM x, ref nSQL sql)
        {
            if (x == null)
                return;
            if (n_user.HiddenAccounts == null)
                return;
            if (n_user.HiddenAccounts.Count <= 0)
                return;
            string s = "";
            foreach (NewMethod.n_user u in n_user.HiddenAccounts)
            {
                if (u == null)
                    continue;
                if (Tools.Strings.StrExt(s))
                    s = ",'" + u.unique_id + "'";
                else
                    s = "'" + u.unique_id + "'";
            }
            if (Tools.Strings.StrExt(s))
                sql.AddDirectWhereAnd("base_mc_user_uid not in (" + s + ")");
        }

        public virtual void OrdHedBeforeUpdate(ContextNM x, ordhed o)
        {

        }

        public virtual ListArgs OrdHedPrintTemplateArgsGet(ContextRz x, nObject CurrentObject, Enums.TransmitType type)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTemplate = "CHOOSEPRINTTEMPLATE";
            ret.TheClass = "printheader";
            ret.AddAllow = false;
            if (CurrentObject is ordhed)
                ret.TheWhere = "printname not like '%default%' and ORDERTYPE = '" + ((ordhed)CurrentObject).ordertype + "' and ( printdescription not like 'for:%' or printdescription like 'for:%" + x.Filter(x.xUser.name) + "%' )";
            else
                ret.TheWhere = "printname not like '%default%' and class_name = '" + CurrentObject.ClassId + "' and ( printdescription not like 'for:%' or printdescription like 'for:%" + x.Filter(x.xUser.name) + "%' )";
            if (type == Enums.TransmitType.Fax)
                ret.TheWhere += " and printname not like '%internal%' ";
            ret.TheOrder = "PRINTTAG";
            return ret;
        }

        private int z_OrderNumberLength = 0;



        public int OrderNumberLengthGet(ContextRz context)
        {
            if (z_OrderNumberLength <= 0)
                z_OrderNumberLength = n_set.GetSetting_Integer(context, "order_number_length");
            if (z_OrderNumberLength <= 0)
            {
                z_OrderNumberLength = 6;
                n_set.SetSetting_Integer(context, "order_number_length", z_OrderNumberLength);
            }
            return z_OrderNumberLength;
        }

        public void OrderNumberLengthSet(ContextRz context, int value)
        {
            if (value <= 0)
            {
                value = 6;
            }
            z_OrderNumberLength = value;
            n_set.SetSetting_Integer(context, "order_number_length", z_OrderNumberLength);
        }

        public ordhed_purchase ShowNewBill(ContextRz context, company vendor, bool is_credit_card = false)
        {
            ordhed_purchase ret = AddNewBill(context, vendor);
            ret.is_credit_card = is_credit_card;
            context.Show(ret);
            return ret;
        }
        public ordhed_purchase AddNewBill(ContextRz context, company vendor)
        {
            ordhed_purchase p = (ordhed_purchase)ordhed.CreateNew(context, Enums.OrderType.Purchase);
            p.is_bill = true;

            if (vendor != null)
                p.AbsorbCompany(context, vendor);

            p.Update(context);
            return p;
        }

        public creditmemo_hed ShowNewCreditMemo(ContextRz context, company cust, PaymentType t)
        {
            creditmemo_hed ret = AddNewCreditMemo(context, cust, t);
            context.Show(ret);
            return ret;
        }
        public creditmemo_hed AddNewCreditMemo(ContextRz context, company cust, PaymentType t)
        {
            creditmemo_hed c = creditmemo_hed.New(context);
            c.Type = t;
            c.orderdate = DateTime.Now;
            c.base_mc_user_uid = ((ContextRz)context).xUser.unique_id;
            c.agentname = ((ContextRz)context).xUser.name;
            c.ordernumber = context.TheSysRz.TheOrderLogic.PadOrderNumber(context, n_set.NextInteger(context, "next_credit_memo_number").ToString());
            if (cust != null)
                c.AbsorbCompany(context, cust);
            c.Insert(context);
            return c;
        }


    }
    public class SalesLineGroup
    {
        public company TheVendor;
        public companycontact TheVendorContact;
        public ordhed_sales TheSale;
        public List<orddet_line> TheLines = new List<orddet_line>();
        public String ConsignmentCode = "";
        public SalesLineGroupTargetType TheTargetType;
        public ordhed TheTargetOrder;
        public string TheWarehouse = "";

        public SalesLineGroup(company vendor, companycontact contact, ordhed_sales sale)
        {
            TheVendor = vendor;
            TheVendorContact = contact;
            TheSale = sale;
        }

        public SalesLineGroup(ordhed_sales sale)
        {
            TheSale = sale;
        }

        public SalesLineGroup(ordhed_sales sale, List<orddet_line> lines)
            : this(sale)
        {
            foreach (orddet_line d in lines)
            {
                TheLines.Add(d);
            }
        }
    }


    public enum SalesLineGroupTargetType
    {
        Unknown = 0,
        NewOrder = 1,
        ExistingOrder = 2,
    }


    public class RMASelectionResult
    {
        public bool Cancel = false;
        public bool NewRMA = false;
        public ordhed_rma TheRMA;
        public bool DoVRMA = false;
        public bool NewVRMA = false;
        public ordhed_vendrma TheVRMA;
        public bool DoCustomerReplacement = false;
        public bool DoVendorReplacement = false;
        public bool UseVendorReplacementForCustomer = false;
        public int Quantity;
        //KT In House Service RMA
        public bool InHouseService = false;
    }

    public class RMASelectionArgs
    {
        public int Quantity;
        public bool QuantityEnabled = false;

        public RMASelectionArgs(int quantity, bool enabled)
        {
            Quantity = quantity;
            QuantityEnabled = enabled;
        }
    }

    public class MakeOrderArgs
    {
        public Enums.OrderType TheType;
        public bool NewOrder;
        public ordhed_new UseOrder;
        public bool Canceled = false;

        public MakeOrderArgs(Enums.OrderType type)
        {
            TheType = type;
        }
    }

    public class OrderLinkArgs
    {
        public ordhed_new TheOrder;
        public Enums.OrderType TheLinkType = Enums.OrderType.Any;
        public ordhed_new TheOrderLinked;
        public List<OrderLinkLine> Lines = new List<OrderLinkLine>();
        public orddet_line TheOriginalLine = null;

        public OrderLinkArgs(ordhed_new order)
        {
            TheOrder = order;
        }

        public OrderLinkArgs(orddet_line l)
        {
            TheOriginalLine = l;
        }
    }

    public class OrderLinkLine
    {
        public orddet_line TheLine;
        public int Quantity = 0;

        public OrderLinkLine(orddet_line l, int q)
        {
            TheLine = l;
            Quantity = q;
        }
    }

    public class OrderLineCancelArgs
    {
        public orddet_line TheLine;
        public List<Enums.OrderType> TypesToCancel = new List<Enums.OrderType>();
        public bool OperationCanceled = false;
        public String Comment = "";
        public bool SuppressLineDeletion = false;

        public OrderLineCancelArgs(orddet_line l)
        {
            TheLine = l;
        }
    }

    public class OrderLineCancelStatus
    {
        public List<OrderLineCancelStatusEntry> Entries = new List<OrderLineCancelStatusEntry>();
    }

    public class OrderLineCancelStatusEntry
    {
        public ordhed_new TheOrder;
        public bool CancelPossible = false;
        public String NotPossibleReason = "";
    }

    public class OrderSearchShowArgs : ActArgs
    {
        public bool UseExisting = true;
        public Rz5.Enums.OrderType TypeToSearch = Enums.OrderType.Any;
        public String PartToSearch = "";

        public OrderSearchShowArgs()
        {

        }

        public OrderSearchShowArgs(Rz5.Enums.OrderType typeToSearch, String partToSearch)
        {
            UseExisting = false;
            TypeToSearch = typeToSearch;
            PartToSearch = partToSearch;
        }
    }

    public class ShippingScreenShowArgs : ActArgs
    {
        public bool DueToday = false;
    }

    public class OrddetLineArgs : ActArgs
    {
        public Enums.OrderType TheType = Enums.OrderType.Any;
    }

    public class OrderSearchViewBy
    {
        public Enums.OrderType CurrentOrderType = Enums.OrderType.Any;
        public Boolean bFormalQuotes = false;
        public Boolean bSalesOrders = false;
        public Boolean bPurchases = false;
        public Boolean bInvoices = false;
        public Boolean bRMAs = false;
        public Boolean bVendorRMAs = false;
        public Boolean bRFQs = false;
        public Boolean bService = false;
        public Boolean bBuyIns = false;
        public ListArgs TheArgs;
    }

    public class OrderHandle
    {
        //Public Variables
        public String strID = "";
        public String strNumber = "";
        public String strCompany = "";
        public String strCustID = "";
        public String strAgentName = "";
        public String strOrderDate = "";
        public Enums.OrderType type = Enums.OrderType.Any;
        public bool Incomplete = false;
        public bool Authorized = false;
        public bool Void = false;
        public bool ShownInChart = false;
        public int CenterX = 0;
        public int CenterY = 0;
        //Private Variables

        //Constructors
        public OrderHandle()
        {
        }
        //Public Functions
        public Point GetPoint()
        {
            return new Point(CenterX, CenterY);
        }
        public virtual String GetOrderType()
        {
            switch (type)
            {
                case Enums.OrderType.Quote:
                    return "Quote " + strNumber;
                case Enums.OrderType.Sales:
                    return "Sales " + strNumber;
                case Enums.OrderType.Purchase:
                    return "PO " + strNumber;
                case Enums.OrderType.Invoice:
                    return "Inv " + strNumber;
                case Enums.OrderType.RMA:
                    return "RMA " + strNumber;
                case Enums.OrderType.VendRMA:
                    return "VRMA " + strNumber;
                case Enums.OrderType.Service:
                    return "Service " + strNumber;
                case Enums.OrderType.RFQ:
                    return "Vendor Bid " + strNumber;
            }
            return "";
        }
        public virtual void ShowOrder(ContextRz context)
        {
            //if (RzWin.Context.xSys == null)
            //{
            //    TheContext.TheLeader.Tell("OrderHandle.ShowOrder failed: xSys == null");
            //    return;
            //}
            ordhed o = ordhed.GetById(context, strID);
            if (o == null)
            {
                context.TheLeader.Tell("OrderHandle.ShowOrder failed: ordhed o == null");
                return;
            }
            context.Show(o);
        }
        public String GetCaption()
        {
            return strCompany;
        }
        public OrderHandle(String id, String number, Enums.OrderType t, String c, String custid, String agent, String orderdate, Boolean isvoid, bool authorized)
        {
            strID = id;
            strNumber = number;
            type = t;
            strCompany = c;
            strAgentName = agent;
            strOrderDate = orderdate;
            strCustID = custid;
            Void = isvoid;
            Authorized = authorized;
        }
        public override string ToString()
        {
            return "[" + GetOrderType() + "](" + strOrderDate + ") " + strCompany;
        }
    }


    public class LinkHandle
    {
        public String strID1 = "";
        public String strID2 = "";
        public LinkHandle(String s1, String s2)
        {
            strID1 = s1;
            strID2 = s2;
        }
    }

    public class OrderMapObject
    {
        //Public Variables
        public ArrayList FinalIDCollection;
        public ArrayList Maps;
        public ArrayList m_Quote;
        public ArrayList m_Sales;
        public ArrayList m_Purchase;
        public ArrayList m_Invoice;
        public ArrayList m_RMA;
        public ArrayList m_VendRMA;
        public int ColumnCount = 0;
        public int ColumnWidth = 0;
        public ArrayList ary;
        public SortedList Links;
        public int SalesIndex = -1;
        public int PurchaseIndex = -1;
        public int InvoiceIndex = -1;
        public int RMAIndex = -1;
        public int VendRMAIndex = -1;
        public SortedList aLinks;
        public ArrayList all_handles;
        public ArrayList lvHandles;

        //Public Functions
        public void CompleteLoad(ContextRz context, ordhed o, int width, bool include_void)
        {
            if (o == null)
            {
                context.TheLeader.Tell("OrderMapObject.CompleteLoad failed: ordhed o == null");
                return;
            }
            if (!Tools.Strings.StrExt(o.unique_id))
            {
                context.TheLeader.Tell("OrderMapObject.CompleteLoad failed: o.unique_id is empty");
                return;
            }
            //this has got to bring in any order in the deal, and also any order in any deal 1 link deep
            Maps = new ArrayList();

            FinalIDCollection = o.LinkedOrderIdsGet(context);

            if (o is ordhed_new)
            {
                foreach (orddet_line l in ((ordhed_new)o).DetailsList(context))//We're going through each line and getting the orders based on orderid.  This is why Service Orders are limited ot one.   
                {
                    foreach (Enums.OrderType t in ordhed.OrderTypes)
                    {
                        String oid = "";
                        try { oid = l.OrderIdGet(t); }
                        catch { }
                        if (Tools.Strings.StrExt(oid) && !FinalIDCollection.Contains(oid))
                            FinalIDCollection.Add(oid);
                    }
                }
            }

            String strWhere = "";
            if (FinalIDCollection.Count > 0)
                strWhere = " unique_id in (" + nTools.GetIn(FinalIDCollection) + ") ";
            else
                strWhere = " unique_id > '' ";

            strWhere += " and ordernumber > '' and ordertype > '' and unique_id > '' ";

            if (!include_void)
                strWhere += " and isnull(isvoid, 0) = 0";

            CompleteLoadFromWhere(context, strWhere, width);
        }
        public void CompleteLoadFromWhere(ContextRz context, String strWhere, int width)
        {
            m_Quote = new ArrayList();
            m_Sales = new ArrayList();
            m_Purchase = new ArrayList();
            m_Invoice = new ArrayList();
            m_RMA = new ArrayList();
            m_VendRMA = new ArrayList();
            String strIDs = "";
            lvHandles = new ArrayList();
            AddOrderHandles(context, m_Quote, strWhere, Enums.OrderType.Quote, ref strIDs);
            AddOrderHandles(context, m_Quote, strWhere, Enums.OrderType.RFQ, ref strIDs);  //added 2009-05-13, but rarely used
            AddOrderHandles(context, m_Sales, strWhere, Enums.OrderType.Sales, ref strIDs);
            AddOrderHandles(context, m_Purchase, strWhere, Enums.OrderType.Purchase, ref strIDs);
            AddOrderHandles(context, m_Purchase, strWhere, Enums.OrderType.Service, ref strIDs);
            AddOrderHandles(context, m_Invoice, strWhere, Enums.OrderType.Invoice, ref strIDs);
            AddOrderHandles(context, m_RMA, strWhere, Enums.OrderType.RMA, ref strIDs);
            AddOrderHandles(context, m_VendRMA, strWhere, Enums.OrderType.VendRMA, ref strIDs);

            List<String> extraLinks = new List<string>();
            AddExtraPOLinksToVRMAList(context, m_VendRMA, m_Purchase, extraLinks);
            AddExtraSaleLinksToVRMAList(context, m_Invoice, m_Sales, extraLinks);

            all_handles = new ArrayList();
            all_handles.AddRange(m_Quote);
            all_handles.AddRange(m_Sales);
            all_handles.AddRange(m_Purchase);
            all_handles.AddRange(m_Invoice);
            all_handles.AddRange(m_RMA);
            all_handles.AddRange(m_VendRMA);
            //figure out how many columns are needed
            ColumnCount = 0;
            ary = new ArrayList();
            if (m_Quote.Count > 0)
            {
                ColumnCount++;
                ary.Add(m_Quote);
            }
            if (m_Sales.Count > 0)
            {
                SalesIndex = ColumnCount;
                ColumnCount++;
                ary.Add(m_Sales);
            }
            else
            {
                SalesIndex = -1;
            }
            if (m_Purchase.Count > 0)
            {
                PurchaseIndex = ColumnCount;
                ColumnCount++;
                ary.Add(m_Purchase);
            }
            else
            {
                PurchaseIndex = -1;
            }
            if (m_Invoice.Count > 0)
            {
                InvoiceIndex = ColumnCount;
                ColumnCount++;
                ary.Add(m_Invoice);
            }
            else
            {
                InvoiceIndex = -1;
            }
            if (m_RMA.Count > 0)
            {
                RMAIndex = ColumnCount;
                ColumnCount++;
                ary.Add(m_RMA);
            }
            else
            {
                RMAIndex = -1;
            }
            if (m_VendRMA.Count > 0)
            {
                VendRMAIndex = ColumnCount;
                ColumnCount++;
                ary.Add(m_VendRMA);
            }
            else
            {
                VendRMAIndex = -1;
            }
            if (ary.Count == 0)
            {
                context.TheLeader.Tell("OrderMapObject.CompleteLoadFromWhere failed: ary.Count == 0");
                return;
            }
            //Get the links
            Links = new SortedList();
            aLinks = new SortedList();
            DataTable d = context.Select("select orderid1, orderid2 from ordlnk where orderid1 > '' and orderid2 > '' and orderid1 in (" + strIDs + ")");
            foreach (DataRow r in d.Rows)
            {
                String sid = (String)r["orderid1"] + "*" + (String)r["orderid2"];
                String sc = (String)Links[sid];
                if (sc == null)
                    Links.Add(sid, sid);
            }
            foreach (DataRow r in d.Rows)
            {
                String sid = (String)r["orderid1"];
                String sc = (String)r["orderid2"];
                try
                {
                    String c = (String)aLinks[sid + "*" + sc];
                    if (c == null)
                    {
                        String scc = (String)aLinks[sc + "*" + sid];
                        if (scc == null)
                            aLinks.Add(sid + "*" + sc, sid + "*" + sc);
                    }
                }
                catch { }
            }

            foreach (String lnk in extraLinks)
            {
                Links.Add(lnk, lnk);
            }

            if ((PurchaseIndex > -1) && (InvoiceIndex > -1))
                ColumnCount--;
            if ((RMAIndex > -1) && (VendRMAIndex > -1))
                ColumnCount--;
            ColumnWidth = width / ColumnCount;
        }

        public virtual void AddExtraPOLinksToVRMAList(ContextRz context, ArrayList aVRMAs, ArrayList aPOs, List<String> extraLinks)
        {

        }

        public virtual void AddExtraSaleLinksToVRMAList(ContextRz context, ArrayList aVRMAs, ArrayList aPOs, List<String> extraLinks)
        {

        }

        public ArrayList GetBaseOrders()
        {
            ArrayList a = new ArrayList();
            if (m_Quote != null)
            {
                if (m_Quote.Count > 0)
                    return m_Quote;
            }
            if (m_Sales != null)
            {
                if (m_Sales.Count > 0)
                    return m_Sales;
            }
            if (m_Purchase != null)
            {
                if (m_Purchase.Count > 0)
                {
                    if (m_Invoice != null)
                    {
                        if (m_Invoice.Count > 0)
                        {
                            foreach (OrderHandle o in m_Invoice)
                            {
                                a.Add(o);
                            }
                            foreach (OrderHandle o in m_Purchase)
                            {
                                a.Add(o);
                            }
                            return a;
                        }
                    }
                    return m_Purchase;
                }
            }
            if (m_Invoice != null)
            {
                if (m_Invoice.Count > 0)
                    return m_Invoice;
            }
            if (m_RMA != null)
            {
                if (m_RMA.Count > 0)
                    return m_RMA;
            }
            if (m_VendRMA != null)
            {
                if (m_VendRMA.Count > 0)
                    return m_VendRMA;
            }
            return null;
        }
        public void AddOrderHandles(ContextRz context, ArrayList a, String strWhere, Enums.OrderType t, ref String strIDs)
        {
            DataTable d = context.Select("select unique_id, ordertype, ordernumber, companyname, is_received, agentname, orderdate, base_company_uid, isvoid, is_authorized from " + ordhed.MakeOrdhedName(t) + " where ordertype = '" + t.ToString() + "' and " + strWhere.Replace("<ordertype>", t.ToString()) + " order by orderdate");
            //dude; DataTableExists comes back false when there are no rows, and 'Tell' pops a modal message box
            if (!Tools.Data.DataTableExists(d))
            {
                //TheContext.TheLeader.Tell("OrderMapObject.AddOrderHandles failed: DataTable doesn't exist");
                return;
            }
            foreach (DataRow r in d.Rows)
            {
                OrderHandle h = new OrderHandle((String)r["unique_id"], (String)r["ordernumber"], RzLogic.ConvertOrderType((String)r["ordertype"]), (String)r["companyname"], r["base_company_uid"].ToString(), r["agentname"].ToString(), nData.NullFilter_DateTime(r["orderdate"]).ToShortDateString(), nData.NullFilter_Boolean(r["isvoid"]), nData.NullFilter_Boolean(r["is_authorized"]));
                if ((h.type == Enums.OrderType.Purchase) && !nData.NullFilter_Boolean(r["is_received"]))
                {
                    h.Incomplete = true;
                }
                if (Tools.Strings.StrExt(strIDs))
                    strIDs += ", ";
                strIDs += "'" + h.strID + "'";
                a.Add(h);
                lvHandles.Add(h);
            }
        }
    }
}
