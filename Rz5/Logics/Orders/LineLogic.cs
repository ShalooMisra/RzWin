using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Core;
using HubspotApis;
using NewMethod;
using SensibleDAL;

namespace Rz5
{
    public class LineLogic : NewMethod.Logic
    {
        public override void ActsListInstance(Context context, ActSetup m)
        {
            base.ActsListInstance(context, m);
            ActsListInstanceLine(context, m);
        }
        public virtual void UpdateLineFromPack(ContextRz x, pack p, orddet_line l)
        {

        }
        public virtual void PutAwayMarkBuy(ContextNM x, orddet_line l)
        {
            //Refactored from RzSensible 5-18-2018
            //did this for sensible only since they were complaining that the lines were changing to
            //stock lines after a receive when they were actually a buy line.
            //l.StockType = Enums.StockType.Stock;  //added 2012_06_18
            l.needs_purchasing = true;  //added 2012_07_31
        }
        protected virtual void ActsListInstanceLine(Context context, ActSetup m)
        {
            Enums.OrderType type = Enums.OrderType.Any;
            if (m is ActSetupOrder)
            {
                ActSetupOrder mm = (ActSetupOrder)m;
                type = mm.TheOrderType;
            }

            //handled in DeletePossible now
            //m.BlockDelete = true;

            List<orddet_line> lines = new List<orddet_line>();
            foreach (IItem i in m.TheItems.AllGet(context))
            {
                lines.Add((orddet_line)i);
            }
            bool all_on_hold = true;
            bool all_open = true;
            bool has_shipped = false;
            bool any_are_void = false;
            bool all_can_be_sent_for_service = true;
            bool allNotSentToQBPurchase = true;
            bool allNotSentToQBService = true;
            bool allOnSameSalesOrder = true;
            bool allNotInvoiced = true;
            bool allNeedPostShip = true;
            bool allNeedPostReceive = true;
            String salesOrderNumber = "";


            //bool all_on_sales = true;
            List<String> sales_numbers = new List<string>();
            List<String> po_numbers = new List<string>();
            List<String> invoice_numbers = new List<string>();
            List<String> service_numbers = new List<string>();
            List<String> rma_numbers = new List<string>();
            List<String> vendrma_numbers = new List<string>();
            foreach (orddet_line l in lines)
            {
                if (l.Status != Enums.OrderLineStatus.Hold)
                    all_on_hold = false;
                if (l.Status != Enums.OrderLineStatus.Open)
                    all_open = false;
                if (l.Status == Enums.OrderLineStatus.Shipped)
                    has_shipped = true;
                if (l.SalesHas)
                {
                    if (!sales_numbers.Contains(l.ordernumber_sales))
                        sales_numbers.Add(l.ordernumber_sales);
                }
                if (l.PurchaseHas)
                {
                    if (!po_numbers.Contains(l.ordernumber_purchase))
                        po_numbers.Add(l.ordernumber_purchase);
                }
                if (l.InvoiceHas)
                {
                    if (!invoice_numbers.Contains(l.ordernumber_invoice))
                        invoice_numbers.Add(l.ordernumber_invoice);
                }
                if (l.ServiceHas)
                {
                    if (!service_numbers.Contains(l.ordernumber_service))
                        service_numbers.Add(l.ordernumber_service);
                }
                if (l.RMAHas)
                {
                    if (!rma_numbers.Contains(l.ordernumber_rma))
                        rma_numbers.Add(l.ordernumber_rma);
                }
                if (l.VendRMAHas)
                {
                    if (!vendrma_numbers.Contains(l.ordernumber_vendrma))
                        vendrma_numbers.Add(l.ordernumber_vendrma);
                }
                if (l.isvoid || l.Status == Enums.OrderLineStatus.Void)
                    any_are_void = true;

                //KT 12-8-2015 - This is where the ability to send for service is set.
                if (l.OrderHas(Enums.OrderType.Service))
                    all_can_be_sent_for_service = false;
                else if (l.was_service_out && !l.was_service_in)
                    all_can_be_sent_for_service = false;
                else if (l.was_shipped && !l.was_rma_received)
                    all_can_be_sent_for_service = false;

                if (l.qb_sent_purchase)
                    allNotSentToQBPurchase = false;

                if (l.qb_sent_service)
                    allNotSentToQBService = false;

                if (l.InvoiceHas)
                    allNotInvoiced = false;

                if (!l.SalesHas)
                    allOnSameSalesOrder = false;
                else
                {
                    if (salesOrderNumber == "")
                        salesOrderNumber = l.ordernumber_sales;
                    else if (salesOrderNumber != l.ordernumber_sales)
                        allOnSameSalesOrder = false;
                }

                if (!l.needs_post_put_away)
                    allNeedPostReceive = false;

                if (!l.needs_post_ship)
                    allNeedPostShip = false;
            }
            if (any_are_void)
            {
                m.Clear();
                m.Close();
                return;
            }
            if (all_on_hold && Tools.Strings.StrCmp(type.ToString(), "sales"))
                GetSalesOrderCompleteTag(m);
            if (Tools.Strings.StrCmp(type.ToString(), "sales") && allNotInvoiced && allOnSameSalesOrder)
                m.Add("Make Invoice");
            if (all_open)
                m.Add("Ship");
            if (lines.Count == 1)
                LineManagementOptionsAdd(context, m);
            if (lines.Count == 1)
            {
                switch (type)
                {
                    //the other order types can't have lines just appear on them from nowhere
                    case Enums.OrderType.Sales:
                    case Enums.OrderType.Service:
                    case Enums.OrderType.Purchase:
                        //KT 3-31-2016 - More Descriptive Name
                        //m.Add("Duplicate / Resource", "Duplicate / Resource" + Tools.Strings.NiceFormat(type.ToString()));
                        m.Add("Duplicate / Re-Source", "Duplicate" + Tools.Strings.NiceFormat(type.ToString()));
                        //For inbound / In-house lines / blank qc_status (i.e. before the code was in place), allow toggle between those two statuses
                        if (lines[0].qc_status == SM_Enums.QcStatus.Inbound.ToString() || lines[0].qc_status == SM_Enums.QcStatus.In_House.ToString() || string.IsNullOrEmpty(lines[0].qc_status))
                            m.Add("Toggle In-House", "In-House");


                        break;
                }
                switch (type)
                {
                    //the other order types can't have lines just appear on them from nowhere
                    case Enums.OrderType.Sales:
                        m.Add("Set Quote ID");
                        m.Add("Add GCAT Service", "gcat");
                        if (lines[0].vendor_name == "Source TBD")
                            m.Add("Resolve TBD");
                        if (lines[0].line_validation_status == SM_Enums.LineValidationStatus.ReSourced.ToString())
                        {
                            ContextRz xrz = (ContextRz)context;
                            if (xrz.TheSysRz.ThePermitLogicRz.CheckPermit(xrz, Permissions.ThePermits.CanValidate, xrz.xUser))
                                m.Add("Approve Re-Sourced Vendor");
                        }
                        break;
                    case Enums.OrderType.Service:
                        m.Add("Destroy");
                        break;
                }
            }

            if (all_can_be_sent_for_service)
                m.Add("Send For Service");


            //Order Links       
            AddOrders(m, sales_numbers, "Sales Order", "viewsales");
            AddOrders(m, po_numbers, "Purchase Order", "viewpos");
            AddOrders(m, invoice_numbers, "Invoice", "viewinvoices");
            AddOrders(m, service_numbers, "Service Order", "viewservices");
            AddOrders(m, rma_numbers, "RMA", "viewrmas");
            AddOrders(m, vendrma_numbers, "Vendor RMA", "viewvendorrmas");
            AddRMAOptions(m, type, rma_numbers, vendrma_numbers);
            AddReceiveOptions((ContextRz)context, type, lines, m, po_numbers, rma_numbers, service_numbers);
            AddShipOptions((ContextRz)context, type, lines, m, invoice_numbers, vendrma_numbers, service_numbers);
            if (AllowLineStatusChanges((ContextRz)context, m) && m.IsRightClick)
                AddLineStatusChanges((ContextRz)context, m);

            if (m.IsRightClick)
                CheckAddLineStatusChangeAlt((ContextRz)context, m);


            if (allNeedPostReceive)
                m.Add("Finish Put Away");

            if (allNeedPostShip)
                m.Add("Finish Shipping");


            //Refactored from RzSensible 5-18-2018
            m.Add("Legacy Inspection Reports");
            m.Add("Scrap / Quarantine");

            m.AddSeparator();
            m.Add("Cancel");
            m.Add("Toggle Print");
        }

        public void SetInitialLineDockDates(orddet_line l, DateTime date)
        {
            l.customer_dock_date = date;
            l.customer_dock_date_initial = date;
            l.projected_dock_date = date;
        }

        public bool IsDropShipServiceVendor(string service_vendor_uid)
        {
            if (string.IsNullOrEmpty(service_vendor_uid))
                return false;
            List<string> dropShipVendorIDs = new List<string>() { "c75d3d332e0849ab8794fba5a8a921f6", "7a28f08ba2a1467d87bc5a2311f9d0b2" };
            if (dropShipVendorIDs.Contains(service_vendor_uid))
                return true;
            return false;
        }

        public bool IsServiceLineEligibleForAutoShip(ContextRz context, orddet_line l)
        {
            if (context.TheSysRz.TheLineLogic.IsDropShipServiceVendor(l.service_vendor_uid) || l.fullpartnumber.ToLower().Contains("gcat"))
                return true;
            return false;
        }

        public bool IsServiceLineEligibleForAutoReceive(ContextRz context, orddet_line l)
        {
            if (l.fullpartnumber.ToLower().Contains("gcat"))
                return true;
            return false;

        }

        protected virtual void GetSalesOrderCompleteTag(ActSetup m)
        {
            if (m != null)
                m.Add("Sales Order Complete");
        }



        protected virtual void LineManagementOptionsAdd(Context context, ActSetup m)
        {
            //KT 3-31-2016 - More Descriptive Name
            //m.Add("Split / Schedule");
            m.Add("Split / Schedule", "Split");
            //m.Add("Split");

            if (((ContextRz)context).xUserRz.SuperUser)
                m.Add("Merge");
        }
        protected virtual void CheckAddLineStatusChangeAlt(ContextRz context, ActSetup m)
        {
            //override
        }
        protected virtual void AddLineStatusChanges(ContextRz context, ActSetup m)
        {
            m.AddSeparator();
            m.Add("Switch To Hold");
            AddLineStatusChangeOpen(context, m);
            m.Add("Switch To Buy");
            m.Add("Switch To Re-Sourced");
            m.Add("Switch To Received");
            m.Add("Switch To Packing");
            m.Add("Switch To Shipped");
            m.Add("Switch To Packing For Service");
            m.Add("Switch To Out For Service");
            m.Add("Switch To RMA Receiving");
            m.Add("Switch To RMA Received");
            m.Add("Switch To Vendor RMA Packing");
            m.Add("Switch To Vendor RMA Shipped");
            m.AddSeparator();
        }
        protected virtual void AddLineStatusChangeOpen(ContextRz context, ActSetup m)
        {
            m.Add("Switch To Open");
        }
        protected virtual void AddReceiveOptions(ContextRz context, Enums.OrderType type, List<orddet_line> lines, ActSetup m, List<String> po_numbers, List<String> rma_numbers, List<String> service_numbers)
        {
            if (po_numbers.Count > 0 && type == Enums.OrderType.Purchase && (lines[0].Status == Enums.OrderLineStatus.Buy || lines[0].Status == Enums.OrderLineStatus.PreInvoiced))
            {
                //m.Add("Receive PO");
                m.Add("Receive Line");
                if (HasInspection((ContextNM)context, lines, Enums.OrderType.Purchase))
                    m.Add("View Inspection PO");
            }
            if (rma_numbers.Count > 0 && type == Enums.OrderType.RMA)
            {
                m.Add("Receive RMA");
                if (HasInspection((ContextNM)context, lines, Enums.OrderType.RMA))
                    m.Add("View Inspection RMA");
            }
            if (service_numbers.Count > 0 && type == Enums.OrderType.Service && lines[0].Status == Enums.OrderLineStatus.Out_For_Service)
                m.Add("Receive Service line");
        }
        protected virtual void AddShipOptions(ContextRz context, Enums.OrderType type, List<orddet_line> lines, ActSetup m, List<String> invoice_numbers, List<String> vrma_numbers, List<String> service_numbers)
        {

            //Refactored from RzSensible 5-18-2018
            //The Rz version was not calling base. code, therefore I commented out all the base code, see below
            if (invoice_numbers.Count > 0 && type == Rz5.Enums.OrderType.Invoice)
            {
                if (context.TheSysRz.ThePermitLogicRz.CheckPermit(context, Permissions.ThePermits.EditInventoryLineItems, context.xUser))
                    m.Add("Fix Inventory Link");

                orddet_line l = (orddet_line)lines[0];
                if (l != null)
                {
                    m.Add("Print Barcode", "printbarcode_sales");
                    // if (((Rz5.CompanyLogic)((SysSensible)context.xSys).TheCompanyLogic).IsCompanyFinancialsVerified(l.OrderObjectGet(context, Rz5.Enums.OrderType.Invoice).CompanyVar.RefGet(context), l.OrderObjectGet(context, Rz5.Enums.OrderType.Invoice)))
                    if (context.TheSysRz.TheCompanyLogic.IsCompanyFinancialsVerified(l.OrderObjectGet(context, Rz5.Enums.OrderType.Invoice).CompanyVar.RefGet(context), l.OrderObjectGet(context, Rz5.Enums.OrderType.Invoice)))
                        //m.Add("Ship Invoice");
                        m.Add("Pack Line");
                }
            }
            //purchase_numbers
            if (type == Rz5.Enums.OrderType.Sales)
                m.Add("Print Barcode", "printbarcode_sales");
            if (vrma_numbers.Count > 0 && type == Rz5.Enums.OrderType.VendRMA)
                m.Add("Ship Vendor RMA");

            //if (service_numbers.Count > 0 && type == Rz5.Enums.OrderType.Service)
            //    m.Add("Ship Service Order");


            //Base Code 5-18-2018
            //bool allUnShipped = true;
            //bool allUnShippedVRMA = true;
            //bool allUnShippedService = true;

            //foreach (orddet_line l in lines)
            //{
            //    if (l.was_shipped)
            //        allUnShipped = false;

            //    if (l.was_vendrma_shipped)
            //        allUnShippedVRMA = false;

            //    if (l.was_service_out)
            //        allUnShippedService = false;
            //}
            //if (invoice_numbers.Count > 0 && type == Enums.OrderType.Invoice && allUnShipped)
            //    m.Add("Ship Line");
            //if (vrma_numbers.Count > 0 && type == Enums.OrderType.VendRMA && allUnShippedVRMA)
            //    m.Add("Ship Vendor RMA");
            //if (service_numbers.Count > 0 && type == Enums.OrderType.Service && allUnShippedService)
            //    m.Add("Ship Service Order");






        }
        protected virtual void AddRMAOptions(ActSetup m, Enums.OrderType type, List<String> rma_numbers, List<String> vendrma_numbers)
        {
            if (rma_numbers.Count == 0 && type == Enums.OrderType.Invoice)
                m.Add("RMA");
            if (vendrma_numbers.Count == 0 && (type == Enums.OrderType.Purchase || type == Enums.OrderType.RMA))
                m.Add("Vendor RMA");
        }
        void AddOrders(ActSetup m, List<String> numbers, String name, String key)
        {
            if (numbers.Count > 0)
            {
                if (numbers.Count == 1)
                    m.Add("View " + name + " " + numbers[0], key);
                else
                    m.Add("View " + Tools.Strings.PluralizePhrase(name, numbers.Count), key);
            }
        }



        protected virtual bool AllowLineStatusChanges(ContextRz x, ActSetup m)
        {
            if (x.TheSysRz.ThePermitLogicRz.CheckPermit(x, Permissions.ThePermits.CanChangeLineStatus, x.xUser))
                return true;
            return x.xUser.SuperUser;
        }
        public override void ActInstance(Context context, ActArgs args)
        {
            ContextRz xrz = (ContextRz)context;

            List<orddet_line> lines = new List<orddet_line>();
            foreach (IItem i in args.TheItems.AllGet(context))
            {
                lines.Add((orddet_line)i);
            }

            if (args.ActionName.Contains("switchto"))
            {
                string actionType = args.ActionName.Replace("switchto", "");
                if (!context.Leader.AreYouSure("you want to switch " + lines.Count + " lines to the '" + Tools.Strings.CapitalizeFirstLetter(actionType) + "' status?"))
                    return;
            }
            switch (args.ActionName.ToLower())
            {
                case "makepo":
                case "salesordercomplete":
                    ordhed_sales s = (ordhed_sales)lines[0].SalesVar.RefGet(context);
                    if (s == null)
                    {
                        context.TheLeader.Error("The sales order was not found");
                        return;
                    }
                    s.CompleteSalesOrder(xrz, lines);
                    break;
                case "ship":
                case "makeinvoice":
                case "startashipment":
                    ordhed_sales sale = (ordhed_sales)lines[0].SalesVar.RefGet(context);
                    if (sale == null)
                    {
                        context.TheLeader.Error("The sales order was not found");
                        return;
                    }

                    List<ordhed_invoice> invoices = sale.MakeInvoiceWithChecks(xrz, lines);
                    if (invoices != null)
                    {
                        foreach (ordhed_invoice i in invoices)
                        {
                            context.Show(i);
                        }
                    }
                    break;
                case "sendforservice":
                    ordhed_service serv = SendForService(xrz, lines);
                    if (serv != null)
                        context.Show(serv);
                    break;
                case "rma":
                    RMA((ContextRz)context, lines);
                    break;
                case "vendorrma":
                    ordhed_vendrma vrma = VendRMA(xrz, lines);
                    if (vrma != null)
                        context.Show(vrma);
                    break;
                case "trackingnumbers-invoice":
                    TrackingAdd(xrz, lines, Rz5.Enums.OrderType.Invoice);
                    break;
                case "trackingnumbers-po":
                    TrackingAdd(xrz, lines, Rz5.Enums.OrderType.Purchase);
                    break;
                case "trackingnumbers-rma":
                    TrackingAdd(xrz, lines, Rz5.Enums.OrderType.RMA);
                    break;
                case "trackingnumbers-vendrma":
                    TrackingAdd(xrz, lines, Rz5.Enums.OrderType.VendRMA);
                    break;
                case "viewsales":
                    ViewOrders(xrz, lines, Rz5.Enums.OrderType.Sales);
                    break;
                case "viewpos":
                    ViewOrders(xrz, lines, Rz5.Enums.OrderType.Purchase);
                    break;
                case "viewinvoices":
                    ViewOrders(xrz, lines, Rz5.Enums.OrderType.Invoice);
                    break;
                case "viewservices":
                    ViewOrders(xrz, lines, Rz5.Enums.OrderType.Service);
                    break;
                case "viewrmas":
                    ViewOrders(xrz, lines, Rz5.Enums.OrderType.RMA);
                    break;
                case "viewvendorrmas":
                case "viewvendrmas":
                    ViewOrders(xrz, lines, Rz5.Enums.OrderType.VendRMA);
                    break;
                case "switchtohold":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.Hold);
                    break;
                case "switchtoopen":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.Open);
                    break;
                case "switchtobuy":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.Buy);
                    break;
                case "switchtoreceived":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.Received);
                    break;
                case "switchtopacking":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.Packing);
                    break;
                case "switchtoshipped":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.Shipped);
                    break;
                case "switchtormareceiving":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.RMA_Receiving);
                    break;
                case "switchtormareceived":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.RMA_Received);
                    break;
                case "switchtovendorrmapacking":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.Vendor_RMA_Packing);
                    break;
                case "switchtovendorrmashipped":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.Vendor_RMA_Shipped);
                    break;
                case "switchtopackingforservice":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.Packing_For_Service);
                    break;
                case "switchtooutforservice":
                    SwitchTo(xrz, lines, Rz5.Enums.OrderLineStatus.Out_For_Service);
                    break;
                case "switchtore-sourced":
                    SwitchTo(xrz, lines, SM_Enums.LineValidationStatus.ReSourced);
                    break;
                case "receiveline":
                    ReceivePO(xrz, lines);
                    break;
                case "receiverma":
                    ReceiveRMA(xrz, lines);
                    break;
                //case "shipinvoice":
                case "packline":
                    ShipInvoice(xrz, lines);
                    break;
                case "receiveserviceline":
                    ReceiveService(xrz, lines);
                    break;
                case "shipserviceorder":
                    ShipService(xrz, lines);
                    break;
                case "shipvendorrma":
                    ShipVRMA(xrz, lines);
                    break;
                case "viewinspectionpo":
                    ViewInspectionPO(xrz, lines);
                    break;
                case "viewinspectionrma":
                    ViewInspectionRMA(xrz, lines);
                    break;
                    //case "qbpobill":
                    //    QuickBooksBill(xrz, lines, Enums.OrderType.Purchase);
                    //    break;
                    //case "qbservicebill":
                    //    QuickBooksBill(xrz, lines, Enums.OrderType.Service);
                    //break;
                case "finishputaway":
                    FinishPutAway(xrz, lines);
                    break;
                case "finishshipping":
                    FinishShipping(xrz, lines);
                    break;
                                                         
                //Refactored from RzSensible 5-18-2018
                case "legacyinspectionreports":
                    LegacyInspectionReports((Rz5.ContextRz)context, lines);
                    args.Handled = true;
                    break;
                case "destroy":
                    DestroyServiceParts((Rz5.ContextRz)context, lines);
                    args.Handled = true;
                    break;
                case "setquoteid":
                    SetQuoteID((Rz5.ContextRz)context, lines);
                    args.Handled = true;
                    break;
                case "printbarcode_sales":
                    ((Rz5.ContextRz)context).Leader.PrintBarcodeLabel((Rz5.ContextRz)context, lines[0]);
                    args.Handled = true;
                    break;
                case "printbarcode_purchase":
                    ((Rz5.ContextRz)context).Leader.PrintBarcodeLabel((Rz5.ContextRz)context, lines[0]);//, "incoming_line_item");
                    args.Handled = true;
                    break;
                case "scrap/quarantine":
                    ScrapQuarantine((ContextRz)context, lines);
                    args.Handled = true;
                    break;
                case "fixinventorylink":
                    FixInventoryLink(xrz, lines);
                    break;

                case "toggleprint":
                    TogglePrintLines(xrz, lines);
                    break;
                case "approvere-sourcedvendor":
                    ApproveReSourcedVendor(xrz, lines);
                    break;
                case "resolvetbd":
                    ResolveTBDLine(xrz, lines);
                    break;



                default:
                    base.ActInstance(context, args);
                    break;
            }
        }

        private void ResolveTBDLine(ContextRz x, List<orddet_line> lines)
        {
            //invoke frmTBDResolution modally
            foreach (orddet_line l in lines)
            {
                x.Leader.ResolveTBDVendor(x, l);
            }

        }

        private void ApproveReSourcedVendor(ContextRz x, List<orddet_line> lines)
        {



            //throw new NotImplementedException();
            foreach (orddet_line l in lines)
            {
                if (l.line_validation_status == SM_Enums.LineValidationStatus.ReSourced.ToString())
                {
                    if (!x.Leader.AreYouSure("you want to approve " + l.vendor_name + "?"))
                        return;
                    l.line_validation_status = "";
                    l.Update(x);
                }

            }

        }

        private void TogglePrintLines(ContextRz x, List<orddet_line> lines)
        {
            //For each selected line
            //set noPrint = !noPrint
            //if(noPrint)
            //color the background black, and change text white.
            foreach (orddet_line l in lines)
            {
                l.noPrint = !l.noPrint;
                l.Update(x);
            }

        }

        private void FixInventoryLink(ContextRz xrz, List<orddet_line> lines)
        {
            //Confirm with USer


            if (!xrz.Leader.AreYouSure("Update the inventory linkage?  This will remove existing pack data."))
                return;

            //Use StockChooser to update inventory link uid
            orddet_line line = lines[0];
            //Remove existing packs                     
            line.PacksOutVar.RefsRemoveAll(xrz);


            partrecord part = xrz.TheLeaderRz.StockChoose(xrz, line.fullpartnumber);
            if (part == null)
                return;
            line.inventory_link_uid = part.unique_id;
            line.Update(xrz);

        }

        //KT Method to set seller name on all lines when order agent is changed.
        public void SetLinesAgents(ContextRz context, List<orddet> lines, ordhed currentorder)
        //public void SetLinesSeller(ContextRz context, List<orddet_line> lines)
        {
            if (string.IsNullOrEmpty(currentorder.buyername))
            {
                currentorder.buyername = currentorder.agentname;
            }

            if (currentorder.OrderType == Enums.OrderType.Sales)
            {
                foreach (orddet_line l in lines)
                {

                    l.seller_name = currentorder.agentname;
                    l.seller_uid = currentorder.base_mc_user_uid;
                    l.buyer_name = currentorder.buyername;
                    l.buyer_uid = context.SelectScalarString("select unique_id from n_user where name = '" + currentorder.buyername + "'");
                    context.Update(l);

                }
            }
            else if (currentorder.OrderType == Enums.OrderType.Purchase) // For PO's don't mess with seller name, just update Buyer name.
            {
                foreach (orddet_line l in lines)
                {
                    if (l.buyer_name != currentorder.buyername)
                    {
                        l.buyer_name = currentorder.buyername;
                        l.buyer_uid = context.SelectScalarString("select unique_id from n_user where name = '" + currentorder.buyername + "'");
                        l.Update(context);//(context.Update(l);
                    }


                }
            }





        }



        public bool AgentExistsInRz(ContextRz context, string user_id)
        {

            NewMethod.n_user u = NewMethod.n_user.GetById(context, user_id);
            if (u != null)
                return true;
            else
                return false;
        }

        //KT - Added an initial Customer Dock Date.  It will only get set if the SQL data is "1/1/1900 12:00:00 AM" and the date chooser is not blank.
        public void SaveInitialCustomerDock(orddet_line l)
        {

            if (l.customer_dock_date_initial.ToString() == "1/1/1900 12:00:00 AM" && l.customer_dock_date.ToString() != "1/1/1900 12:00:00 AM")
            {
                l.customer_dock_date_initial = l.customer_dock_date;
            }
        }

        void FinishPutAway(ContextRz context, List<orddet_line> lines)
        {
            ordhed_purchase p = (ordhed_purchase)lines[0].PurchaseVar.RefGet(context);
            if (p == null)
                throw new Exception("The PO for these lines could not be found");

            p.AfterClose(context, lines, CloseType.Receive);
        }

        void FinishShipping(ContextRz context, List<orddet_line> lines)
        {
            ordhed_invoice i = (ordhed_invoice)lines[0].InvoiceVar.RefGet(context);
            if (i == null)
                throw new Exception("The invoice for these lines could not be found");

            i.AfterClose(context, lines, CloseType.Ship);
        }

        protected virtual void ViewInspectionPO(ContextRz context, List<orddet_line> lines)
        {
            orddet_line l = lines[0];
            if (l == null)
                return;
            pack p = (pack)context.QtO("pack", "select * from pack where the_orddet_purchase_uid = '" + l.unique_id + "'");
            qualitycontrol q = (qualitycontrol)context.QtO("qualitycontrol", "select * from qualitycontrol where the_companycontact_uid = '" + p.unique_id + "' and the_orddet_uid = '" + l.unique_id + "'");
            context.TheLeaderRz.QCShow(context, p, l, "PO# " + l.ordernumber_purchase, q);
        }
        protected virtual void ViewInspectionRMA(ContextRz context, List<orddet_line> lines)
        {
            context.Reorg();
            //orddet_line l = lines[0];
            //if (l == null)
            //    return;
            //pack p = (pack)context.QtO("pack", "select * from pack where the_orddet_rma_uid = '" + l.unique_id + "'");
            //qualitycontrol q = (qualitycontrol)context.QtO("qualitycontrol", "select * from qualitycontrol where the_partrecord_uid = '" + p.unique_id + "' and the_orddet_uid = '" + l.unique_id + "'");
            //frmQC qc = new frmQC();
            //if (!qc.CompleteLoad(contextRz, p, l, "RMA# " + l.ordernumber_rma, q))
            //    return;
            //qc.ShowDialog();
        }
        //protected virtual void QuickBooksBill(ContextRz context, List<orddet_line> lines, Enums.OrderType type)
        //{
        //    try
        //    {
        //        ordhed_new order = null;
        //        StringBuilder sb = new StringBuilder();
        //        List<BillLineHandle> handles = new List<BillLineHandle>();
        //        foreach (orddet_line l in lines)
        //        {
        //            BillLineHandle h = new BillLineHandle();
        //            h.TheLine = l;
        //            h.TheType = type;
        //            handles.Add(h);

        //            if (order == null)
        //            {
        //                if (type == Enums.OrderType.Purchase)
        //                    order = (ordhed_new)l.PurchaseVar.RefGet(context);
        //                else
        //                    order = (ordhed_new)l.ServiceVar.RefGet(context);
        //            }

        //            if (type == Enums.OrderType.Purchase)
        //            {
        //                if (!sb.ToString().Contains(l.ordernumber_purchase))
        //                    sb.Append(" PO#" + l.ordernumber_purchase);
        //            }
        //            else if (type == Enums.OrderType.Service)
        //            {
        //                if (!sb.ToString().Contains(l.ordernumber_service))
        //                    sb.Append(" Service#" + l.ordernumber_service);
        //            }
        //        }

        //        context.TheSysRz.TheQuickBooksLogic.SendBill(context, order.CompanyVar.RefGet(context), context.TheSysRz.TheQuickBooksLogic.BillReferenceCalc(order), context.TheSysRz.TheQuickBooksLogic.MemoCalc(order), context.TheSysRz.TheQuickBooksLogic.InitalsCalc(context, order), context.TheSysRz.TheQuickBooksLogic.PayableAccountCalc(order), order.shipvia, order.terms, context.TheSysRz.TheQuickBooksLogic.BillDateCalc(order), handles, new List<orddet_line>(), sb.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        context.TheLeader.Error(ex);
        //    }
        //}
        public virtual bool ShipViaInvoiceOK(orddet_line l)
        {
            if (l == null)
                return false;
            return Tools.Strings.StrExt(l.shipvia_invoice);
        }
        public virtual void ActDetail(ContextRz context, ActArgs args)
        {
            ContextRz xrz = (ContextRz)context;

            List<orddet> lines = new List<orddet>();
            foreach (IItem i in args.TheItems.AllGet(context))
            {
                lines.Add((orddet)i);
            }
            switch (args.ActionName.ToLower())
            {
                case "duplicatesupplier":
                    orddet.SetSupplier(lines);
                    args.Handled = true;
                    break;
                case "sendforservice":
                    orddet.SendForService(xrz, lines, true);
                    args.Handled = true;
                    break;
                case "sendmultiplequotes":
                    context.Logic.SendMultipleQuotes(xrz, lines);
                    args.Handled = true;
                    break;
                case "copylineinfo":
                    orddet.GlobalLineInfo = new ArrayList();
                    foreach (object x in lines)
                    {
                        orddet.GlobalLineInfo.Add(x);
                    }
                    args.Handled = true;
                    break;
                case "newformalquote":
                    orddet.ShowNewFormalQuote(xrz, lines);
                    args.Handled = true;
                    break;
                case "emailvendorgroup":
                    List<orddet> details = new List<orddet>();
                    foreach (orddet d in lines)
                    {
                        details.Add(d);
                    }
                    orddet_quote.EmailVendorGroup(xrz, details);
                    args.Handled = true;
                    break;
                case "setlotnumber":
                    orddet.SetLotNumber(xrz, lines);
                    args.Handled = true;
                    break;
                default:
                    base.ActInstance(context, args);
                    break;
            }
        }
        protected virtual bool AddANote()
        {
            return false;
        }
        public virtual void ActsListOrdDetOld(ContextRz context, ActSetup m)
        {
            Enums.OrderType t = Enums.OrderType.Any;
            foreach (IItem b in m.TheItems.AllGet(context))
            {
                if (!(b is orddet_old))
                    continue;
                orddet_old o = (orddet_old)b;
                t = o.OrderType;
                break;
            }
            m.Add("Select");
            switch (t)
            {
                case Enums.OrderType.RFQ:
                    m.Add("Make PO");
                    m.Add("Give Quote");
                    break;
                case Enums.OrderType.Quote:
                    if (AddANote())
                        m.Add("Add A Note");
                    m.Add("Receive Bid");
                    m.Add("Formal Quote");
                    m.Add("New Formal Quote");
                    m.Add("Sales Order");
                    m.AddSeparator();
                    if (!context.Logic.UseMergedQuotes)
                        m.Add("Email Vendor");
                    else
                        m.Add("Email Vendor Group");
                    m.Add("Send For Service");
                    m.Add("Void");
                    m.Add("UnVoid");
                    break;
            }
            if (t != Enums.OrderType.Quote)
                m.Add("View Order");
            m.Add("View Order Batch");
            m.Add("Hot Part");

            m.Add("Duplicate");
            m.Add("Copy Line Info");
            m.Add("Pictures");
            if (context.xUser.IsDeveloper())
                m.Add("Forms");
        }
        protected bool HasInspection(ContextNM context, List<orddet_line> lines, Rz5.Enums.OrderType type)
        {
            string id = "";
            foreach (orddet_line l in lines)
            {
                int count = context.SelectScalarInt32("select count(unique_id) from qualitycontrol where the_orddet_uid = '" + l.unique_id + "'");
                if (count <= 0)
                    continue;
                return true;
            }
            return false;
        }
        public virtual void ViewOrders(ContextRz context, List<orddet_line> lines, Rz5.Enums.OrderType type)
        {
            Dictionary<String, ordhed_new> pos = new Dictionary<string, ordhed_new>();
            foreach (orddet_line l in lines)
            {
                ordhed_new p = (ordhed_new)l.OrderObjectGet(context, type);
                if (p != null)
                {
                    if (!pos.ContainsKey(p.unique_id))
                        pos.Add(p.unique_id, p);
                }
            }

            if (pos.Count == 0)
                return;

            foreach (KeyValuePair<String, ordhed_new> kvp in pos)
            {
                context.Show(kvp.Value);
            }
        }
        public void TrackingAdd(ContextRz context, List<orddet_line> lines, Enums.OrderType type)
        {
            String add = context.TheLeader.AskForString(type.ToString() + " Tracking Numbers", "", true);
            if (!Tools.Strings.StrExt(add))
                return;

            TrackingAdd(context, lines, type, add);
        }
        public virtual void TrackingAdd(ContextRz context, List<orddet_line> lines, Enums.OrderType type, String add)
        {
            String prop = "tracking_" + type.ToString().ToLower();
            List<String> nums = Tools.Strings.SplitLinesList(add);
            foreach (String num in nums)
            {
                if (Tools.Strings.StrExt(num))
                {
                    foreach (orddet_line line in lines)
                    {
                        String existing = Tools.Data.NullFilterString(line.IGet(prop));
                        if (!Tools.Strings.HasString(existing, num))
                        {
                            if (existing != "")
                                existing += "\r\n";
                            existing += num;
                        }

                        line.ISet(prop, existing);
                        context.Update(line);
                    }
                }
            }
        }

        protected virtual void SwitchTo(ContextRz context, List<orddet_line> lines, SM_Enums.LineValidationStatus s)
        {
            foreach (orddet_line l in lines)
            {
                l.line_validation_status = s.ToString();              

                context.Update(l);
            }
        }


        protected virtual void SwitchTo(ContextRz context, List<orddet_line> lines, Rz5.Enums.OrderLineStatus s)
        {
            foreach (orddet_line l in lines)
            {
                l.Status = s;

                switch (l.Status)
                {
                    case Enums.OrderLineStatus.Vendor_RMA_Packing:
                        l.was_vendrma_shipped = false;
                        break;
                    case Enums.OrderLineStatus.Buy:
                        l.was_received = false;
                        break;
                    case Enums.OrderLineStatus.Packing:
                        l.was_shipped = false;
                        break;
                    case Enums.OrderLineStatus.RMA_Receiving:
                        l.was_rma_received = false;
                        break;
                    case Enums.OrderLineStatus.Packing_For_Service:
                        l.was_service_out = false;
                        break;
                    case Enums.OrderLineStatus.Hold:
                        l.was_shipped = false;
                        l.was_received = false;
                        l.was_service_out = false;
                        l.was_service_in = false;
                        break;
                    case Enums.OrderLineStatus.Shipped:
                        l.was_shipped = true;
                        l.ship_date_actual = l.orderdate_invoice;
                        if (l.qc_status != SM_Enums.QcStatus.Final_Inspection.ToString())
                            l.qc_status = SM_Enums.QcStatus.Shipped.ToString();
                        break;
                }

                context.Update(l);
            }
        }
        protected virtual void ReceivePO(ContextRz context, List<orddet_line> lines)
        {
            context.TheLeaderRz.ReceivePO(context, lines);
        }
        protected virtual void ReceiveRMA(ContextRz context, List<orddet_line> lines)
        {
            context.TheLeaderRz.ReceiveRMA(context, lines);
        }
        protected virtual void ShipVRMA(ContextRz context, List<orddet_line> lines)
        {
            context.TheLeaderRz.ShipVRMA(context, lines);
        }
        protected virtual void ReceiveService(ContextRz context, List<orddet_line> lines)
        {
            context.TheLeaderRz.ReceiveService(context, lines);
        }
        protected virtual void ShipService(ContextRz context, List<orddet_line> lines)
        {
            context.TheLeaderRz.ShipService(context, lines);
        }
        protected virtual void ShipInvoice(ContextRz context, List<orddet_line> lines)
        {
            context.TheLeaderRz.ShipInvoice(context, lines);
        }
        public virtual ordhed_service SendForService(ContextRz context, List<orddet_line> lines)
        {
            //option to jump on an existing service order
            MakeOrderArgs args = context.Leader.AskForMakeOrderArgs(Enums.OrderType.Service);
            if (args.Canceled)
                return null;
            ////If no order designated return null, else othe line logic will still fire.
            //if (args.NewOrder == false && args.UseOrder == null)
            //    return null;

            ordhed_service serv = null;

            if (args.NewOrder)
            {
                serv = (ordhed_service)ordhed.CreateNew(context, Enums.OrderType.Service);
            }
            else
                serv = (ordhed_service)args.UseOrder;

            if (serv == null)
                return null;

            foreach (orddet_line l in lines)
            {
                l.ServiceVar.RefSet(context, serv);
                //if (l.Status == Enums.OrderLineStatus.Open)
                l.Status = Enums.OrderLineStatus.Packing_For_Service;
                l.Update(context);
            }

            serv.Update(context);
            return serv;
        }
        public virtual ordhed_rma RMA(ContextRz context, List<orddet_line> lines)
        {
            //context.Reorg();
            //return null;
            if (lines.Count == 0)
            {
                context.TheLeader.Error("No lines");
                return null;
            }
            ordhed_invoice invoice_order = (ordhed_invoice)lines[0].OrderObjectGet(context, Rz5.Enums.OrderType.Invoice);
            if (invoice_order == null)
            {
                context.TheLeader.Error("The invoice for this scan could not be found");
                return null;
            }
            int rmaQuantity = 0;
            bool rmaQuantityEnabled = true;
            //only single line selections can be split
            //so if there's more than 1, the quantity has to be the total quantity
            //the alternative would be to show each line on the rma screen and allow a quantity selection for each
            if (lines.Count == 1)
                rmaQuantityEnabled = lines[0].quantity > 1;
            else
                rmaQuantityEnabled = false;
            foreach (orddet_line l in lines)
            {
                rmaQuantity += l.quantity;
            }
            //RMASelectionResult r = Win.Dialogs.RMASelection.Select(new RMASelectionArgs(rmaQuantity, rmaQuantityEnabled));
            RMASelectionResult r = context.Leader.RMASelectionGet(context, new RMASelectionArgs(rmaQuantity, rmaQuantityEnabled));
            if (r == null)
                return null;
            if (r.Cancel)
                return null;
            if (!rmaQuantityEnabled && (r.Quantity != rmaQuantity))  //lines[0].quantity  changed 2014_04_29
            {
                context.TheLeader.Error("Only single lines can be split for an RMA.  Add each line individually.");
                return null;
            }
            //KT **Jsut a Note, not my code.** This return is the creation of a new RMA
            return RMA(context, lines, invoice_order, r);
        }
        public virtual ordhed_rma RMA(ContextRz context, List<orddet_line> lines, ordhed_invoice invoice_order, RMASelectionResult r)
        {
            //Variables
            ordhed_rma rma = null;
            int totalRmaQuantity = 0;



            //Instruction
            foreach (orddet_line l in lines)
            {
                totalRmaQuantity += l.quantity;
            }


            if (r.Quantity != totalRmaQuantity)
            {
                //When splitting RMA lines, the line will have the original Inventory Link UID.  Rz will not detect a valid part based on that ID, so will fail when trying to split.
                lines[0].Split(context, lines[0].quantity - r.Quantity, null, true);
            }

            if (r.NewRMA)
            {
                rma = (Rz5.ordhed_rma)invoice_order.GetNewOrderHeader(context, Rz5.Enums.OrderType.RMA);
                rma.billingname = invoice_order.billingname;
                rma.shippingname = invoice_order.shippingname;
                rma.currency_name = invoice_order.currency_name;

                if (context.Accounts.IsBaseCurrency(invoice_order.currency_name))
                {
                    rma.exchange_rate = 1;
                }
                else
                {
                    //rma.exchange_rate = invoice_order.exchange_rate;
                    currency curr = context.Accounts.GetCurrency(context, invoice_order.currency_name);
                    if (curr == null)
                        throw new Exception("The invoice currency " + invoice_order.currency_name + " could not be found");

                    rma.exchange_rate = curr.exchange_rate;
                }

                rma.Update(context);
                ((SysRz5)context.xSys).TheOrderLogic.Link2Orders(context, invoice_order, rma);
            }
            else
            {
                rma = r.TheRMA;
                context.TheLeader.ViewsClose(rma);
            }
            foreach (orddet_line l in lines)
            {
                l.RMAVar.RefSet(context, rma);
                l.was_rma = true;
                l.exchange_rate_rma = rma.exchange_rate;

                if (context.Accounts.IsBaseCurrency(l.currency_name_price))
                {
                    l.unit_price_rma = l.unit_price;
                    l.unit_price_rma_exchanged = l.unit_price_rma;
                }
                else
                    l.unit_price_rma = currency.CalculateExchangeFromForeign(l.unit_price_exchanged, l.exchange_rate_rma, 6);


                //KT My Attempt at forking to RMA - In House Service 2-24-2015                
                if (r.InHouseService)
                {
                    l.is_RMA_IHS = true;
                }


                l.Status = Rz5.Enums.OrderLineStatus.RMA_Receiving;
                l.Update(context);
            }
            //Sets new changes to the RMA Header
            rma.Update(context);
            //KT - ordRMA is the base values that apply to VRMA nd RMA  - i.e. ordhed is to ordhed_RMA
            ordrma rmaData = rma.LinkedRMAGet(context);
            if (rmaData == null)
            {
                rmaData = ordrma.New(context);
                rmaData.rma_ordhed_uid = rma.unique_id;

                //KT - this created the base ordhed_rma header?
                rmaData.Insert(context);
            }

            Rz5.ordhed_vendrma vrma = null;
            if (r.DoVRMA)
            {
                if (r.NewVRMA)
                {
                    ordhed_purchase po = (ordhed_purchase)lines[0].OrderObjectGet(context, Rz5.Enums.OrderType.Purchase);
                    if (po == null)
                        context.TheLeader.Error("The PO for this item could not be found.  Please find the PO and create the VRMA from it manually");
                    else
                    {
                        vrma = (Rz5.ordhed_vendrma)po.MakeVendorRMAHeader(context, lines[0], r.DoVendorReplacement);
                    }

                    if (rmaData != null)
                    {
                        rmaData.vendrma_ordhed_uid = vrma.unique_id;
                        context.TheDelta.Update(context, rmaData);
                    }
                }
                else
                {
                    vrma = r.TheVRMA;
                    context.TheLeader.ViewsClose(vrma);
                }

                foreach (orddet_line l in lines)
                {
                    l.VendRMAVar.RefSet(context, vrma);
                    l.was_vendrma = true;

                    if (context.Accounts.IsBaseCurrency(l.currency_name_cost))
                    {
                        l.unit_price_vendrma = l.unit_cost;
                        l.unit_price_vendrma_exchanged = l.unit_cost;
                    }
                    else
                    {
                        l.unit_price_vendrma_exchanged = l.unit_cost_exchanged;
                        l.unit_price_vendrma = currency.CalculateExchangeFromForeign(l.unit_cost_exchanged, l.exchange_rate_vendrma, 6);
                    }

                    l.Update(context);
                }
                vrma.Update(context);
            }

            //KT -This is where the new scheduled replacement line comes from
            List<orddet_line> replacementLines = new List<orddet_line>();
            if (r.DoCustomerReplacement)
            {
                ordhed_sales sale = (ordhed_sales)lines[0].SalesVar.RefGet(context);  // lines[0].SalesOrderGet(context);
                if (sale == null)
                    context.TheLeader.Error("The sales order could not be found to add the replacement");
                else
                {
                    context.TheLeader.ViewsClose(sale);

                    foreach (orddet_line l in lines)
                    {
                        orddet_line replacement_line = (orddet_line)sale.DetailsVar.RefAddNew(context);
                        //taken care of
                        //replacement_line.ISave();

                        //KT - Here is where the replacement lines fields get set.
                        l.IdentityApplyTo(context, replacement_line);
                        replacement_line.quantity = l.quantity;
                        replacement_line.stocktype = "";

                        //KT fork based on is_RMA_IHS - Set all pertinent values for replacement line.
                        if (l.is_RMA_IHS == true)
                        {
                            replacement_line.vendor_uid = l.vendor_uid;
                            replacement_line.vendor_name = l.vendor_name;
                            replacement_line.vendor_contact_uid = l.vendor_contact_uid;
                            replacement_line.vendor_contact_name = l.vendor_contact_name;
                            //KT 6-2-2017 replacement line should NOT have IHS on it, else cost not included.
                            //replacement_line.is_RMA_IHS = true;

                            //Dock Dates
                            context.TheSysRz.TheLineLogic.SetInitialLineDockDates(replacement_line, l.customer_dock_date);

                            //stocktype
                            replacement_line.stocktype = l.stocktype;
                            replacement_line.quote_line_uid = l.quote_line_uid;
                            replacement_line.was_rma = false;
                            replacement_line.was_vendrma = false;
                            replacement_line.Status = Rz5.Enums.OrderLineStatus.Open;
                            replacement_line.internalcomment = "In House Service for RMA " + rma.ordernumber;
                            replacement_line.orderid_purchase = l.orderid_purchase;
                            replacement_line.ordernumber_purchase = l.ordernumber_purchase;
                            ordhed_purchase p = (ordhed_purchase)l.PurchaseVar.RefGet(context);
                            replacement_line.PurchaseVar.RefSet(context, p);
                        }
                        else
                        {
                            replacement_line.vendor_uid = "";
                            replacement_line.vendor_name = "";
                            replacement_line.vendor_contact_uid = "";
                            replacement_line.vendor_contact_name = "";
                            replacement_line.Status = Rz5.Enums.OrderLineStatus.Hold;
                            replacement_line.internalcomment = "Replacement for RMA " + rma.ordernumber;
                        }
                        replacement_line.lotnumber = "";
                        replacement_line.consignment_code = "";
                        replacement_line.Update(context);
                        replacementLines.Add(replacement_line);
                    }

                    sale.Update(context);
                    context.Show(sale);
                }

                //2013_07_15 we need to discuss this especially with the currencies
                ////we need to talk about how Sensible wants this;
                ////we should come to a consensus but i didn't want to break anything for Sensible
                //foreach (orddet_line l in lines)
                //{
                //    l.unit_price_rma = GetRMAUnitPrice(l);
                //}
            }
            else
            {
                //2013_07_15 we need to discuss this especially with the currencies
                //foreach (orddet_line l in lines)
                //{
                //    l.unit_price_rma = l.unit_price;
                //}
            }





            foreach (orddet_line l in lines)
            {
                context.TheDelta.Update(context, l);
            }

            if (r.DoVRMA && vrma != null && r.DoVendorReplacement)
            {
                ordhed_purchase p = null;
                foreach (orddet_line ln in lines)
                {
                    p = (ordhed_purchase)ln.OrderObjectGet(context, Enums.OrderType.Purchase);
                    if (p != null)
                        break;
                }

                if (p != null)
                {
                    if (r.UseVendorReplacementForCustomer && replacementLines.Count > 0)
                    {
                        foreach (orddet_line replacement_line in replacementLines)
                        {
                            p.DetailsVar.RefsAdd(context, replacement_line);
                            replacement_line.Status = Enums.OrderLineStatus.Buy;
                            replacement_line.vendor_name = p.companyname;
                            replacement_line.vendor_uid = p.base_company_uid;
                            replacement_line.vendor_contact_name = p.contactname;
                            replacement_line.vendor_contact_uid = p.base_companycontact_uid;
                            context.TheDelta.Update(context, replacement_line);
                        }
                    }
                    else
                    {
                        //add a new replacement line
                        foreach (orddet_line ln in lines)
                        {
                            orddet_line replacement_line = (orddet_line)p.DetailsVar.RefAddNew(context);

                            //handled
                            //replacement_line.ISave();

                            ln.IdentityApplyTo(context, replacement_line);

                            replacement_line.quantity = ln.quantity;
                            replacement_line.stocktype = ln.stocktype;
                            replacement_line.vendor_name = p.companyname;
                            replacement_line.vendor_uid = p.base_company_uid;
                            replacement_line.vendor_contact_name = p.contactname;
                            replacement_line.vendor_contact_uid = p.base_companycontact_uid;
                            replacement_line.lotnumber = ln.lotnumber;
                            replacement_line.consignment_code = ln.consignment_code;
                            replacement_line.Status = Rz5.Enums.OrderLineStatus.Buy;
                            replacement_line.internalcomment = "Replacement for VRMA " + vrma.ordernumber;
                            context.TheDelta.Update(context, replacement_line);
                        }
                    }
                }
                else
                    context.TheLeader.Error("The PO for VRMA " + vrma.ordernumber + " could not be found.  The replacement needs to be manually scheduled");

            }

            if (vrma != null)
                context.Show(vrma);


            //Hubspot
            ordhed_invoice rmaInvoice = (ordhed_invoice)lines[0].InvoiceVar.RefGet(context);
            if (rmaInvoice != null)
            {
                if (rmaInvoice.hubspot_deal_id > 0)
                    HandleHubspotRMATasks(context, rmaInvoice, lines);
            }






            context.Show(rma);

            return rma;
        }

        internal void SetLineSourceTBD(ContextRz x, orddet_line l)
        {
            //b69d82053406485a9422059cd0a764bd	Source TBD
            company v = company.GetByName(x, "Source TBD");
            if (v == null)
                throw new Exception("Company record for 'Source TBD' not found.");
            l.VendorVar.RefSet(x, v);
            //l.vendor_name = "Source TBD";
            //l.vendor_uid = "b69d82053406485a9422059cd0a764bd";

        }

        private void HandleHubspotRMATasks(ContextRz x, ordhed_invoice theInvoice, List<orddet_line> rmaLines)
        {
            try
            {


                if (rmaLines.Count == 0)
                    return;
                //if deal exists for this sale, AND All lines are RMA,  Close it set to lost, and set reason to "RMA"
                //If only Partial RMA, update deal Amount to new amount?
                long hubID = theInvoice.hubspot_deal_id;
                if (hubID == 0)
                    return;

                theInvoice.CalculateAllAmounts(x);
                //Get a List of the lines currently on the Invoice.  Will include any rma splits as well
                List<orddet> linesOnTheInvoice = theInvoice.DetailsList(x);

                List<orddet> nonRmaLines = new List<orddet>();
                foreach (orddet l in linesOnTheInvoice)
                {
                    if (!l.status.ToLower().Contains("rma"))
                        nonRmaLines.Add(l);
                }



                //if (nonRmaLines.Count > 0)
                //{
                //    //Since we can assumt 1 customer PO = 1 batch = 1 Sales Order = 1 invoice, we can get the hubspot ID From this invoice, and Close it.
                //    Dictionary<string, string> props = HubspotLogic.GenerateBaseHubspotDealProperties(theInvoice);
                //    HubspotApi.Deals.UpdateDeal(theInvoice.hubspot_deal_id, props);
                //}

                //else//If no other valid lines on the order,  set to closed_rma
                //    HubspotApi.Deals.SetDealLost(theInvoice.hubspot_deal_id, "RMA");

            }
            catch (Exception ex)
            {
                x.Leader.Error(ex.Message);
            }








        }

        protected virtual double GetRMAUnitPrice(orddet_line l)
        {
            return 0;
        }
        public virtual ordhed_vendrma VendRMA(ContextRz context, List<orddet_line> lines)
        {
            int rmaQuantity = 0;
            bool rmaQuantityEnabled = true;

            //only single line selections can be split
            //so if there's more than 1, the quantity has to be the total quantity
            //the alternative would be to show each line on the rma screen and allow a quantity selection for each
            if (lines.Count == 1)
                rmaQuantityEnabled = lines[0].quantity > 1;
            else
                rmaQuantityEnabled = false;

            foreach (orddet_line l in lines)
            {
                rmaQuantity += l.quantity;
            }

            RMASelectionResult r = context.Leader.ChooseVendorRMA(new RMASelectionArgs(rmaQuantity, rmaQuantityEnabled));

            if (r == null)
                return null;

            if (r.Cancel)
                return null;

            if (!rmaQuantityEnabled && lines[0].quantity != r.Quantity)
            {
                context.TheLeader.Error("Only single lines can be split for a Vendor RMA.  Add each line individually.");
                return null;
            }

            return VendRMA(context, lines, r);
        }
        public virtual ordhed_vendrma VendRMA(ContextRz context, List<orddet_line> lines, RMASelectionResult r)
        {
            ordhed_vendrma vrma = null;
            ordhed_purchase po = (ordhed_purchase)lines[0].OrderObjectGet(context, Rz5.Enums.OrderType.Purchase);
            if (po == null)
            {
                context.TheLeader.Error("The PO for this item could not be found.  Please find the PO and create the VRMA from it manually");
                return null;
            }
            if (r.TheVRMA == null)
            {
                vrma = (Rz5.ordhed_vendrma)po.GetNewOrderHeader(context, Rz5.Enums.OrderType.VendRMA);
                context.TheDelta.Update(context, vrma);
                //ordrma rmaData = null;
                //ordhed_rma rmaHeader = (ordhed_rma)lines[0].OrderObjectGet(context, Enums.OrderType.RMA);
                //if (rmaHeader != null)
                //    rmaData = rmaHeader.LinkedRMA;
                //if (rmaData != null)
                //{
                //    rmaData.vendrma_ordhed_uid = vrma.unique_id;
                //    context.TheDelta.Update(context, rmaData);
                //}
                foreach (orddet_line l in lines)
                {
                    if (l.OrderHas(Enums.OrderType.RMA))
                    {
                        ordhed_rma rma = (ordhed_rma)l.OrderObjectGet(context, Enums.OrderType.RMA);
                        if (rma != null)
                        {
                            ordrma rmaData = rma.LinkedRMAGet(context);
                            if (rmaData == null)
                            {
                                rmaData = new ordrma();
                                rmaData.rma_ordhed_uid = rma.unique_id;
                                context.TheDelta.Insert(context, rmaData);
                            }
                            if (rmaData != null)
                            {
                                rmaData.vendrma_ordhed_uid = vrma.unique_id;
                                rmaData.Update(context);
                                vrma.LinkedRMASet(rmaData);
                            }
                        }
                    }
                }
            }
            else
            {
                vrma = r.TheVRMA;
            }
            ((SysRz5)context.xSys).TheOrderLogic.Link2Orders(context, po, vrma);
            if (r.Quantity != lines[0].quantity)
            {
                lines[0].Split(context, lines[0].quantity - r.Quantity);
            }
            foreach (orddet_line l in lines)
            {
                l.VendRMAVar.RefSet(context, vrma);
                l.was_vendrma = true;
                l.Status = Enums.OrderLineStatus.Vendor_RMA_Packing;
                l.unit_price_vendrma = l.unit_cost;
                l.Update(context);
            }
            if (vrma != null && r.DoVendorReplacement)
            {
                ordhed_purchase p = null;
                //Add the Sale Line
                //ordhed_sales sale = null;
                ordhed_sales sale = (ordhed_sales)lines[0].SalesVar.RefGet(context);  // lines[0].SalesOrderGet(context);


                foreach (orddet_line ln in lines)
                {
                    p = (ordhed_purchase)ln.OrderObjectGet(context, Enums.OrderType.Purchase);
                    if (p != null)
                        break;
                }
                if (p != null)
                {
                    //add a new replacement line
                    foreach (orddet_line ln in lines)
                    {
                        orddet_line replacement_line = (orddet_line)p.DetailsVar.RefAddNew(context);
                        ln.IdentityApplyTo(context, replacement_line);
                        replacement_line.quantity = ln.quantity;
                        replacement_line.stocktype = ln.stocktype;
                        replacement_line.vendor_name = p.companyname;
                        replacement_line.vendor_uid = p.base_company_uid;
                        replacement_line.vendor_contact_name = p.contactname;
                        replacement_line.vendor_contact_uid = p.base_companycontact_uid;
                        replacement_line.lotnumber = ln.lotnumber;
                        replacement_line.consignment_code = ln.consignment_code;
                        replacement_line.Status = Rz5.Enums.OrderLineStatus.Buy;
                        replacement_line.internalcomment = "Replacement for VRMA " + vrma.ordernumber;
                        context.TheDelta.Update(context, replacement_line);

                        //Associate the line with the original sale.
                        if (sale == null)
                            context.TheLeader.Error("The sales order could not be found to add the replacement");
                        else
                        {
                            replacement_line.SalesVar.RefSet(context, sale);
                            //replacement_line.orderid_sales = sale.unique_id;
                            //replacement_line.ordernumber_sales = sale.ordernumber;
                            sale.Update(context);
                            context.Show(sale);
                        }
                        //Add the Sale Line
                        // ordhed_sales sale = (ordhed_sales)lines[0].SalesVar.RefGet(context);  // lines[0].SalesOrderGet(context);                     

                    }
                }
                else
                    context.TheLeader.Error("The PO for VRMA " + vrma.ordernumber + " could not be found.  The replacement needs to be manually scheduled");
            }
            //KT - 1st attempt to create placeholder sales line for re-sourcing.
            if (!r.DoVendorReplacement)
            {
                if (context.Leader.AskYesNo("You have indicated that this vendor will NOT be replacing this part.  Would you like to create a 'Source TBD' line on the Sales Order?"))
                {
                    //Create a duplicate Sales Order Line set to Source TBD
                    List<orddet_line> replacementLines = new List<orddet_line>();
                    ordhed_sales sale = (ordhed_sales)lines[0].SalesVar.RefGet(context);  // lines[0].SalesOrderGet(context);
                    if (sale == null)
                        context.TheLeader.Error("The sales order could not be found to add the replacement");
                    else
                    {
                        context.TheLeader.ViewsClose(sale);

                        foreach (orddet_line l in lines)
                        {
                            orddet_line replacement_line = sale.DetailsVar.RefAddNew(context);
                            l.IdentityApplyTo(context, replacement_line);
                            company c = company.GetByName(context, "Source TBD");
                            replacement_line.vendor_uid = c.unique_id;
                            replacement_line.vendor_name = c.companyname;
                            replacement_line.vendor_contact_uid = "";
                            replacement_line.vendor_contact_name = "";
                            replacement_line.Status = Rz5.Enums.OrderLineStatus.Hold;
                            replacement_line.internalcomment = "Replacement for VRMA " + vrma.ordernumber;
                            replacement_line.lotnumber = "";
                            replacement_line.consignment_code = "";
                            replacement_line.quantity = l.quantity;
                            replacement_line.stocktype = "";
                            replacement_line.internalcomment = "Replacement for VRMA " + vrma.ordernumber;
                            context.TheDelta.Update(context, replacement_line);
                        }

                        sale.Update(context);
                        context.Show(sale);
                    }

                    //2013_07_15 we need to discuss this especially with the currencies
                    ////we need to talk about how Sensible wants this;
                    ////we should come to a consensus but i didn't want to break anything for Sensible
                    //foreach (orddet_line l in lines)
                    //{
                    //    l.unit_price_rma = GetRMAUnitPrice(l);
                    //}




                }
            }
            vrma.Update(context);
            //Since Seting the line VRMA, per sensible logic, changes the sub_total, we need to update the po in the datatbase.
            po.Update(context);
            return vrma;
        }
        public virtual bool PrintInternalComment()
        {
            return true;
        }
        public virtual ListArgs OrdLineSearchArgsGet(ContextRz x, SearchComparison compare, Enums.OrderType[] types, PartSearchParameters pars)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "orddet_line";

            if (pars.SearchTerm == "")
                ret.HeaderOnly = true;

            ret.AddAllow = false;
            ret.TheClass = ret.TheTable;
            ret.TheOrder = ret.TheTable + ".orderdate_" + types[0].ToString().ToLower() + " desc";
            StringBuilder sb = new StringBuilder();
            sb.Append(" ( ");
            bool btypes = false;
            String stypes = "";
            if (types.Length > 0)
            {
                btypes = true;
                sb.Append("( ");
                bool ft = true;
                foreach (Enums.OrderType t in types)
                {
                    if (!ft)
                    {
                        sb.Append(" or ");
                        stypes += ", ";
                    }
                    stypes += t.ToString();
                    ft = false;
                    sb.Append("isnull(orddet_line.ordernumber_" + t.ToString().ToLower() + ", '') > ''");
                }
                sb.Append(" )");
            }
            if (Tools.Strings.StrExt(pars.AgentID))
                sb.Append(" and orddet_line.seller_uid = '" + pars.AgentID + "' ");

            SearchPermutations(x, sb, compare, pars, btypes);

            //ArrayList a = PartObject.GetSearchPermutations(x, pars.SearchTerm, compare, true, false, false, false, true, "", true);
            //if (a.Count > 0)
            //{
            //    if (btypes)
            //        sb.AppendLine(" and ");
            //    sb.AppendLine(" ( ");
            //    sb.Append(PartObject.BuildWhere(a));
            //    sb.Append(" or internal_customer like '%" + pars.SearchTerm + "%%' ");
            //    sb.Append(" or internal_vendor like '%" + pars.SearchTerm + "%%' ");
            //    sb.AppendLine(" ) ");
            //}


            sb.Append(" ) ");
            ret.TheCaption = stypes;

            //if (sb.ToString() != "")
            //    sb.Append(" or ");
            //sb.Append(" manufacturer like '%" + Rz3App.context.Filter(strPart) + "%' ");

            ret.TheWhere = sb.ToString();

            //Refactored from RzSensible 5-19-2018
            if (Tools.Strings.StrExt(pars.CompanyName))
                ret.TheWhere += " and customer_name = '" + x.Filter(pars.CompanyName) + "'";


            return ret;
        }
        public virtual void SearchPermutations(ContextRz x, StringBuilder sb, SearchComparison compare, PartSearchParameters pars, bool btypes)
        {
            ArrayList a = PartObject.GetSearchPermutations(x, pars.SearchTerm, compare, true, false, false, false, true, "", true);
            if (a.Count > 0)
            {
                if (btypes)
                    sb.AppendLine(" and ");
                sb.AppendLine(" ( ");
                sb.Append(PartObject.BuildWhere(a));
                sb.Append(" or internal_customer like '%" + pars.SearchTerm + "%%' ");
                sb.Append(" or internal_vendor like '%" + pars.SearchTerm + "%%' ");
                sb.AppendLine(" ) ");
            }
        }

        public bool CheckEraiTable(ContextRz context, string partNumber)
        {
            //KT Trim the string
            if (partNumber.Length > 4)
            {
                //string strippedpart = Strings.StripNonAlphaNumeric(partNumber, false);
                //string strippedSubstring = strippedpart.Substring(0, 4);
                //GEt a list of 5 lines that match the first 5 characters.  5 is pretty arbitrary
                List<string> potentialERAIMatches = context.SelectScalarList("select fullpartnumber from erai_import where fullpartnumber LIKE'" + partNumber + "%'");
                //Strip out all characters form each part in this list
                List<string> potentialERAIMatchesStripped = new List<string>();
                List<string> nonAlphaCharacters = new List<string>() { "=", "-", "_", ",", ":", ";" };
                List<string> matchedParts = new List<string>();
                foreach (string s in potentialERAIMatches)
                {//Add stripped parts to list for comparison to stroppedpart
                 //if (s.Length >= partNumber.Length)
                 //potentialERAIMatchesStripped.Add(Strings.StripNonAlphaNumeric(s, false).Substring(0, strippedpart.Length - 1));
                 //Stripping may not be good, then for instancem, if we saearched for ABC123, and the reported part is ABC123-TR, then the latter would become ABC123TR, and thus
                 //would NOT contain the original Part, and would get missed.
                 //May Be Better to check for an alphanumeric, and truncate at that character
                 //potentialERAIMatchesStripped.Add(Strings.StripNonAlphaNumeric(s, false));

                    //Check the string for any of the alphanumberics, add to a list;
                    List<string> detectedNonAlphas = new List<string>();
                    foreach (string na in nonAlphaCharacters)
                    {
                        if (s.Contains(na))
                            detectedNonAlphas.Add(na);
                    }
                    //Now that we have a list of detected NonAlphas, let's check the DetectedPotentialMatch for the 1st occurence of each at at time, split the part to the left of that, and compare that to the searched part.
                    foreach (string f in detectedNonAlphas)
                    {
                        foreach (string matchedPart in potentialERAIMatches)
                        {
                            int index = matchedPart.IndexOf(f);
                            string test = matchedPart.Substring(0, index);
                            if (test.ToLower() == partNumber.ToLower())
                            {
                                matchedParts.Add(matchedPart);
                            }
                        }
                    }


                }
                //if (potentialERAIMatchesStripped.Contains(partNumber))
                if (matchedParts.Count > 0)
                {//stripplist contains stripped part, apply same strip to where clause in SQL to return results matching the strppedpart

                    StringBuilder sb = new StringBuilder();
                    foreach (string match in matchedParts)
                    {
                        //string details = context.Data.SelectScalarString("select fullpartnumber + ', MFG: ' + manufacturer + ', DC: ' + datecode from Rz3.dbo.erai_import where REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(fullpartnumber, '-', ''), '/', ''), '\',''),'.',''),' ',''),'#',''),',','') LIKE '" + match + "%'");
                        string details = context.Data.SelectScalarString("select fullpartnumber + ', MFG: ' + manufacturer + ', DC: ' + datecode from Rz3.dbo.erai_import where fullpartnumber LIKE '" + match + "%'");
                        sb.Append(details + Environment.NewLine);

                    }
                    //ArrayList partDetails = context.Data.SelectScalarArray("select fullpartnumber + ', MFG: ' + manufacturer + ', DC: ' + datecode from Rz3.dbo.erai_import where REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(fullpartnumber, '-', ''), '/', ''), '\',''),'.',''),' ',''),'#',''),',','') LIKE '" + partNumber + "%'");
                    //if (matchedParts.Count > 0)
                    {//Create the message
                        string warningMessage = "The following potential matches to this part were found in our ERAI Reported parts database:" + Environment.NewLine + Environment.NewLine;
                        string testString = sb.ToString();
                        //foreach (string s in matchedParts)
                        //{
                        //    if (s.Contains(partNumber))
                        //        warningMessage += s + Environment.NewLine;
                        //}
                        warningMessage += Environment.NewLine + sb.ToString() + Environment.NewLine;
                        if (!context.Leader.AskYesNoLarge(warningMessage, "Would you like to proceed?"))
                            return false;
                    }
                }

            }
            return true;
        }




        //public double ApplyConsignmentCost(ContextRz x, double unit_cost, double unit_price, string code_name)
        //{
        //    double consginment_cost = unit_cost; //original Cost
        //    if (unit_price > 0)
        //    {

        //        //consignment_code code = (consignment_code)x.QtO("consignment_code", "select * from consignment_code where code_name = '" + q.consignment_code + "'");
        //        consignment_code code = consignment_code.GetByName(x, code_name);
        //        if (code == null)
        //            return consginment_cost;
        //        //KT My Code, changeing to 
        //        //double payPct = ((100 -(double)code.keep_percent) / 100) ;
        //        //if (code != null)
        //        //    ret = q.unitprice * (payPct);
        //        consginment_cost = code.CostCalc(unit_price);
        //    }
        //    return consginment_cost;
        //}


        //Refactored from RzSensible 5-18-2018
        private void AddCostDeduction(Rz5.ContextRz x, Rz5.ordhed_sales so, double cost, string name)
        {
            if (cost <= 0)
                return;
            List<orddet> dets = so.DetailsList(x);
            if (dets == null)
                return;
            orddet_line l = null;
            foreach (orddet det in dets)
            {
                if (det == null)
                    continue;
                if (!(det is orddet_line))
                    continue;
                l = (orddet_line)det;
                break;
            }
            if (l == null)
                return;
            ////KT - Refactored Profit Deduction from RzSensible to Rz5
            //profit_deduction d = (RzSensible.profit_deduction)l.Deductions.RefAddNew(x);
            profit_deduction d = (Rz5.profit_deduction)l.DeductionsVar.RefAddNew(x);
            d.amount = cost;
            d.name = name;
            d.Insert(x);
        }

        //Refactored from RzSensible 5-18-2018
        private void UpdatePartRecord(Rz5.ContextRz x, Rz5.orddet_line l, Rz5.partrecord p)
        {
            if (p == null)
                return;
            if (l == null)
                return;
            if (l.quantity >= p.quantity)
                p.Delete(x);
            else
            {
                p.quantity -= l.quantity;
                p.Insert(x);
            }
        }

        //Refactored from RzSensible 5-18-2018
        private List<Rz5.Enums.OrderType> GetCancelList(Rz5.ContextRz x, orddet_line l)
        {
            List<Rz5.Enums.OrderType> list = new List<Rz5.Enums.OrderType>();
            list.Add(Rz5.Enums.OrderType.Service);
            Rz5.OrderLineCancelStatus s = l.CancelStatusGet(x);
            foreach (Rz5.OrderLineCancelStatusEntry e in s.Entries)
            {
                if (e.TheOrder.OrderType == Rz5.Enums.OrderType.Service)
                    continue;
                if (e.CancelPossible)
                    list.Add(e.TheOrder.OrderType);
            }
            return list;
        }

        //Refactored from RzSensible 5-18-2018
        private void SetQuoteID(Rz5.ContextRz context, List<orddet_line> lines)
        {
            try
            {
                string s = context.TheLeader.AskForString("Please enter the quote ID to apply to the line(s).");
                //if (!Tools.Strings.StrExt(s))
                //    return;
                foreach (orddet_line l in lines)
                {
                    l.quote_line_uid = s;
                    l.Update(context);
                }
            }
            catch { }
        }

        private void QuarantineParts(Rz5.ContextRz context, List<orddet_line> lines)
        {
            foreach (orddet_line l in lines)
            {
                partrecord p = partrecord.GetById(context, l.inventory_link_uid);
                if (p == null)
                {
                    context.TheLeader.Tell("Part was not found in inventory, has it been Put Away from the PO?");
                    return;
                }
                else
                {
                    p.location = "QUARANTINED";
                    l.status = Rz5.Enums.OrderLineStatus.Quarantined.ToString();
                    l.status_caption = Rz5.Enums.OrderLineStatus.Quarantined.ToString();
                    p.Update(context);
                    l.Update(context);
                }

            }
        }

        private void ScrapParts(Rz5.ContextRz context, List<orddet_line> lines)
        {
            foreach (orddet_line l in lines)
            {
                l.status = Rz5.Enums.OrderLineStatus.Scrapped.ToString();
                l.status_caption = Rz5.Enums.OrderLineStatus.Scrapped.ToString();
                partrecord p = partrecord.GetById(context, l.inventory_link_uid);
                if (p == null)
                {

                    if (context.TheLeader.AskYesNo("Part was not found in inventory, are they being scrapped offsite (i.e. at customer facility)?"))
                        l.internalcomment += "|  Scrapped at customer location on " + DateTime.Today + " by:  " + context.xUser.name;
                    else
                    {
                        context.TheLeader.Tell("Part was not found in inventory, has it been Put Away from the PO?");
                        return;
                    }
                }
                else
                {

                    //This line may have been received from a Service Order (qty_unpacked_service), or it may have been received from a Purchase order (qty_unpacked)
                    long unpackedQty = l.quantity_unpacked;
                    if (unpackedQty == 0)
                        unpackedQty = l.quantity_unpacked_service;





                    if (unpackedQty == 0)
                        throw new Exception("This line has 0 quantity_unpacked, cannot scrap a zero quantity. ");

                    //If the QTY of this line is less than the partrecord QTY, then it's a split, and we should split the partrecord accordingly and update the line linkage.
                    if (p.quantity < unpackedQty)
                        throw new Exception("Error: Trying to scrap QTY of " + unpackedQty + " which is more than the current quantity of the inventory item: " + p.quantity);

                    if (p.quantity > unpackedQty)
                    {
                        p.quantity -= unpackedQty;
                        p.quantityallocated -= unpackedQty;
                        p.Update(context);
                    }
                    else
                    {
                        p.Delete(context);
                    }
                    l.internalcomment += "|  Scrapped at SMC wareouse " + DateTime.Today + " by:  " + context.xUser.name;
                }
                l.Update(context);


                SendScrappedPartAlert(context, l);
            }


        }

        private void SendScrappedPartAlert(ContextRz x, orddet_line l)
        {
            //Sales admins need to know when a part is scrapped so they can properly ...
            //White Horse:  7a28f08ba2a1467d87bc5a2311f9d0b2  
            List<string> scrapAlertVendorIds = new List<string>() { "7a28f08ba2a1467d87bc5a2311f9d0b2" }; ///White horse and Emporium
            ordhed_service svc = (ordhed_service)x.QtO("ordhed_service", "select * from ordhed_service where unique_id = '" + l.orderid_service + "'");
            if (svc == null)
                return;

            if (!scrapAlertVendorIds.Contains(svc.base_company_uid))
                return;
            string to = "ap@sensiblemicro.com";
            if (x.xUser.name.ToLower() == "kevint")
                to = "systems@sensiblemicro.com";
            string subject = l.fullpartnumber.Trim().ToUpper() + " was Scrapped.";
            StringBuilder message = new StringBuilder();
            message.Append("This order will be one piece short, please notify customers accordingly.<br /><br />");
            message.Append("Customer: " + l.customer_name + "<br />");
            message.Append("SO# " + l.ordernumber_sales + "<br />");
            message.Append("Part: " + l.fullpartnumber + "<br />");
            message.Append("MFG: " + l.manufacturer + "<br />");
            message.Append("QTY: " + l.quantity + "<br />");
            //List<string> ccList = new List<string>() { "systems@sensiblemicro.com" };
            SensibleDAL.SystemLogic.Email.SendMail("rz_scrap@sensiblemicro.com", to, subject, message.ToString(), null);




        }

        private void ScrapQuarantine(Rz5.ContextRz context, List<orddet_line> lines)
        {
            try
            {
                string s = "this part?";
                if (lines.Count > 1)
                    s = "these parts?";
                Tools.Strings.PluralizePhrase("", lines.Count);
                if (!context.TheLeader.AskYesNo("Are you sure you want to scrap or quarantine " + s))
                    return;
                if (lines == null)
                    return;
                if (!context.TheLeader.AskYesNo("Are these parts being quarantined?  (Choose No if they are to be scrapped.)"))//Scrap
                {
                    ScrapParts(context, lines);
                }
                else//Quarantine
                {
                    QuarantineParts(context, lines);
                }

            }
            catch (Exception ex)
            {
                context.TheLeader.Tell(ex.Message);
            }
        }

        private void DestroyServiceParts(Rz5.ContextRz context, List<orddet_line> lines)
        {
            try
            {
                string s = "this part?";
                if (lines.Count > 1)
                    s = "these parts?";
                Tools.Strings.PluralizePhrase("", lines.Count);
                if (!context.TheLeader.AskYesNo("Are you sure you want to destroy " + s))
                    return;
                if (lines == null)
                    return;
                foreach (orddet_line l in lines)
                {
                    Rz5.OrderLineCancelArgs args = new Rz5.OrderLineCancelArgs(l);
                    args.TypesToCancel = GetCancelList(context, l);
                    args.Comment = "Destroyed on Service Order " + l.ordernumber_service;
                    Rz5.partrecord p = l.LinkedInventory(context);
                    double cost = l.total_cost;
                    ordhed_sales so = (ordhed_sales)l.OrderObjectGet(context, Rz5.Enums.OrderType.Sales);
                    l.Cancel(context, args);
                    if (so != null)
                        AddCostDeduction(context, so, cost, "Cost for Parts " + args.Comment);
                    if (p != null)
                        UpdatePartRecord(context, l, p);
                }
            }
            catch { }
        }

        private void LegacyInspectionReportIdsAdd(Rz5.ContextRz context, orddet_line l, List<String> ids, String id, String table)
        {
            if (!Tools.Strings.StrExt(id))
                return;

            DataTable d = context.Select("select stockid, original_stock_id from " + table + " where unique_id = '" + id + "'");
            if (!Tools.Data.DataTableExists(d))
                return;

            foreach (DataRow r in d.Rows)
            {
                String idx = Tools.Data.NullFilterString(r[0]);
                if (Tools.Strings.StrExt(idx) && !ids.Contains(idx))
                    ids.Add(idx);

                idx = Tools.Data.NullFilterString(r[1]);
                if (Tools.Strings.StrExt(idx) && !ids.Contains(idx))
                    ids.Add(idx);
            }
        }

        private void LegacyInspectionReportIdsAdd(Rz5.ContextRz context, orddet_line l, List<String> ids)
        {
            LegacyInspectionReportIdsAdd(context, l, ids, l.legacyid_sales, "orddet_sales_bak_reorg");
            LegacyInspectionReportIdsAdd(context, l, ids, l.legacyid_invoice, "orddet_invoice_bak_reorg");
            LegacyInspectionReportIdsAdd(context, l, ids, l.legacyid_purchase, "orddet_purchase_bak_reorg");
        }

        private void LegacyInspectionReports(Rz5.ContextRz context, List<orddet_line> lines)
        {
            List<String> ids = new List<string>();

            foreach (orddet_line l in lines)
            {
                LegacyInspectionReportIdsAdd(context, l, ids);
            }

            if (ids.Count == 0)
            {
                context.TheLeader.Tell("No legacy line items were found");
                return;
            }

            ArrayList a = context.QtC("partrecord", "select * from partrecord where unique_id in (" + Tools.Data.GetIn(ids) + " )");
            if (a.Count == 0)
            {
                context.TheLeader.Tell("No legacy inspection reports were found");
                return;
            }

            foreach (Rz5.partrecord p in a)
            {
                qualitycontrol q = (qualitycontrol)p.QCObjectGet(context);
                if (q != null)
                    ((ILeaderRz)context.Leader).InspectionReportShowLegacy(context, q);
            }
        }


        //KT Handle Adding a GCAT LINE
        public object CreateGCATLine(ContextRz x, object o)
        {

            double gcat_cost = 0;
            //Opting to not pre-captyre cost, since I'm now auto
            //string strCost = Tools.Strings.SanitizeInput(x.Leader.AskForDouble("Please enter the cost to the customer", 250, "GCAT Cost", ref cancel).ToString());
            //if (!double.TryParse(strCost, out gcat_cost))
            //    throw new Exception("Please enter a valid number for the cost.");

            if (o is orddet_quote)
            {
                orddet_quote theGCATReq = CreateGCATReq(x, (orddet_quote)o);
                //Create a bid to pre-set GCAT stock line
                orddet_rfq gcatBidLine = CreateGCATBid(x, theGCATReq, gcat_cost);
                //Auto-Accept the bid
                theGCATReq.BidAbsorb(x, gcatBidLine);
                gcatBidLine.Accept(x);
                //Update the UI
                return theGCATReq;
            }
            else if (o is orddet_line)
            {
                return CreateGCATorddet(x, (orddet_line)o, gcat_cost);
            }



            return null;
        }

        private orddet_quote CreateGCATReq(ContextRz x, orddet_quote q)
        {

            orddet_quote theGCATquote = (orddet_quote)q.Duplicate(x);
            theGCATquote.description = "";//Un-set this after duplicate
            theGCATquote.fullpartnumber = SetGCATItemName();
            theGCATquote.manufacturer = "N/A";
            theGCATquote.vendorname = "Sensible Micro Corporation";
            theGCATquote.vendorid = "037ED306-8D90-42D6-AAAA-AD91B900F263";
            theGCATquote.internalpartnumber = "GCAT - LAB ANALYSIS";//Default, can be overwritten later.
            //theGCATquote.internalpartnumber = theGCATquote.internalpartnumber;
            //This is the inventory line for our GCAT service part
            theGCATquote.stockid = "ce60a6330c7a4ceea76e2086060d13b4";
            //Line association with internal vendor part name and part uid
            if (q != null)
            {
                theGCATquote.internalpart_vendor_uid = q.unique_id;
                theGCATquote.internalpart_vendor = q.fullpartnumber;
            }

            //Partrecord / line item stuff            
            theGCATquote.quantity = 1;
            theGCATquote.quantityordered = 1;
            theGCATquote.target_quantity = 1;
            //This is the field that becomse qty on the quote line.
            theGCATquote.quantityordered = 1;

            //set color to purple -8388480
            theGCATquote.grid_color = -8388480;
            theGCATquote.Update(x);
            return theGCATquote;
        }



        private orddet_rfq CreateGCATBid(ContextRz x, orddet_quote quoteBeingTested, double gcat_cost = 0)
        {

            //(orddet_rfq)quoteBeingTested.Duplicate(x);//orddet_rfq.New(x);
            //Create a new orddet_rfq
            orddet_rfq TheGCATBid = orddet_rfq.New(x);


            //Set the associated Quote line UID
            TheGCATBid.the_orddet_quote_uid = quoteBeingTested.unique_id;
            TheGCATBid.base_dealheader_uid = quoteBeingTested.base_dealheader_uid;
            //Use the above quote_line_uid and set on the bid.
            if (gcat_cost > 0)
                TheGCATBid.unitprice = gcat_cost;
            TheGCATBid.companyname = "Sensible Micro Corporation";
            TheGCATBid.base_company_uid = "037ED306-8D90-42D6-AAAA-AD91B900F263";
            TheGCATBid.fullpartnumber = SetGCATItemName();
            TheGCATBid.manufacturer = "N/A";
            //theGCATquote.internalpartnumber = TheGCATBid.fullpartnumber;
            TheGCATBid.internalpartnumber = "GCAT - LAB ANALYSIS";//Default, can be overwritten later.
            //This is the inventory line for our GCAT service part
            TheGCATBid.stockid = "ce60a6330c7a4ceea76e2086060d13b4";
            //The Part Number and unique_id of the part being tested, or other internal vendor identifiers we may want to capture from our vendor partners.
            TheGCATBid.internalpart_vendor_uid = TheGCATBid.stockid;
            TheGCATBid.internalpart_vendor = TheGCATBid.fullpartnumber;

            //Partrecord / line item stuff            
            TheGCATBid.quantity = 1;
            TheGCATBid.quantityordered = 1;

            //If we've identified a line item (i.e. not a GCAT only order).
            if (quoteBeingTested != null)
            {
                TheGCATBid.internalpart_vendor_uid = quoteBeingTested.unique_id;
                TheGCATBid.internalpart_vendor = quoteBeingTested.fullpartnumber;
            }
            //Stocktype.Service
            TheGCATBid.StockType = Enums.StockType.Service;
            TheGCATBid.stocktype = Enums.StockType.Service.ToString();
            //Line Status
            TheGCATBid.status = Enums.OrderLineStatus.Open.ToString();

            TheGCATBid.isselected = true;
            x.Insert(TheGCATBid);
            return TheGCATBid;

        }

        private orddet_line CreateGCATorddet(ContextRz x, orddet_line lineBeingTested, double gcat_cost = 0)
        {

            //Some dark magic in the Dumplicate feature allows the lines to update on the Sale
            //WIthout proper implementation, really hard to get line items dettails section of viewHeader to update with the new line.           
            orddet_line TheGCATDetail = lineBeingTested.Duplicate(x, Enums.OrderType.Sales);
            TheGCATDetail.description = "";//Un-set this after duplicate
            TheGCATDetail.vendor_name = "Sensible Micro Corporation";
            TheGCATDetail.vendor_uid = "037ED306-8D90-42D6-AAAA-AD91B900F263";
            TheGCATDetail.fullpartnumber = SetGCATItemName();
            TheGCATDetail.manufacturer = "N/A";
            TheGCATDetail.internal_customer = "GCAT - LAB ANALYSIS";//Default, can be overwritten later.
            TheGCATDetail.internalpartnumber = "GCAT - LAB ANALYSIS";//Default, can be overwritten later.
            //This is the inventory line for our GCAT service part
            TheGCATDetail.inventory_link_uid = "ce60a6330c7a4ceea76e2086060d13b4";

            //Line association with internal vendor part name and part uid
            TheGCATDetail.internalpart_vendor = lineBeingTested.fullpartnumber;
            TheGCATDetail.internalpart_vendor_uid = lineBeingTested.unique_id;

            //Partrecord / line item stuff
            TheGCATDetail.quote_line_uid = "GCAT_QUOTE_UID"; //needed for packs 
            TheGCATDetail.quantity = 1;
            TheGCATDetail.quantity_unpacked = 1;
            //TheGCATDetail.quantity_packed = 1;
            if (gcat_cost > 0)
                TheGCATDetail.unit_cost = gcat_cost;


            //The Part Number and unique_id of the part being tested, or other internal vendor identifiers we may want to capture from our vendor partners.           
            //If we've identified a line item (i.e. not a GCAT only order).
            if (lineBeingTested != null)
            {
                TheGCATDetail.internalpart_vendor_uid = lineBeingTested.unique_id;
                TheGCATDetail.internalpart_vendor = lineBeingTested.fullpartnumber;
            }
            //Stocktype.Service
            TheGCATDetail.StockType = Enums.StockType.Service;
            TheGCATDetail.stocktype = Enums.StockType.Service.ToString();
            //Line Status
            TheGCATDetail.status = Enums.OrderLineStatus.Open.ToString();
            TheGCATDetail.status_caption = Enums.OrderLineStatus.Open.ToString();
            x.Update(TheGCATDetail);
            return TheGCATDetail;

        }


        //public string SetGCATItemName(string fullpartnumber)
        //{
        //    return "GCAT-" + fullpartnumber.Trim().ToUpper();
        //}

        public string SetGCATItemName()
        {
            return "GCAT - LAB ANALYSIS";
        }



    }
}
