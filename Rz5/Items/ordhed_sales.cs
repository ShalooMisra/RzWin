using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using Core;
using NewMethod;
using System.Linq;
using System.Windows.Forms;

namespace Rz5
{
    public partial class ordhed_sales : ordhed_sales_auto
    {

        //Constructor
        //[CoreVarRefMany("Deductions", "ordhed_sales", "profit_deduction", "Sales", "sales_order_uid")]
        public VarRefMany<ordhed_sales, profit_deduction> DeductionsVar;


        public ordhed_sales()
        {
            OrderType = Enums.OrderType.Sales;
            DeductionsVar = new VarRefMany<ordhed_sales, profit_deduction>(this, new CoreVarRefManyAttribute("Deductions", "ordhed_sales", "profit_deduction", "Sales", "sales_order_uid"));

        }

        //KT 10-7-2015 - Refactored from RzSensible
        public override orddet GetNewDetail(ContextRz context)
        {
            orddet_line l = (orddet_line)DetailsVar.RefAddNew(context);
            l.shipvia_invoice = this.shipvia;
            return l;
        }


        //KT - This was not present when I refactored from RzSensible
        public override Var VarGetByName(string name)
        {
            switch (name)
            {
                case "Deductions":
                    return DeductionsVar;
                default:
                    return base.VarGetByName(name);

            }
        }






        public virtual bool MakeInvoicePossible(ContextRz x, List<orddet_line> lines, List<string> missingProps)
        {
            bool b = true;

            if (!x.xUser.CheckPermit(x, "Order:Create:Can Make Invoice"))
            {
                //sb.AppendLine("This workstation isn't configured to access this function");
                missingProps.Add("This workstation isn't configured to access this function");
                return false;
            }

            if (this.terms == "TBD")
            {
                //sb.AppendLine("The terms on this order are still \"TBD\".  Cannot ship this item until this is resolved.");
                missingProps.Add("The terms on this order are still \"TBD\".  Cannot ship this item until this is resolved.");
                return false;
            }

            if (lines.Count == 0)
            {
                //sb.AppendLine("No lines are ready to be shipped");
                missingProps.Add("No lines are ready to be shipped");
                return false;
            }
            if (validation_stage.ToLower().Contains("hold"))
            {
                //sb.AppendLine("Cannot ship, please resolve the " + validation_stage + ":  '" + validation_hold_reason + "'");
                missingProps.Add("Cannot ship, please resolve the " + validation_stage + ":  '" + validation_hold_reason + "'");
                if (x.CheckPermit(Permissions.ThePermits.CanShipValidationHold))//Can Override, ask user if they want to
                {
                    if (!x.Leader.AskYesNo("This order is on validation hold, but you are authorized to override.  Would you like to override the hold and ship this order?"))
                        return false;
                }
                else
                    return false;
            }

            //sb.Clear();
            bool possible = true;
            //foreach (orddet_line l in lines)
            //{
            //    if (!l.Invoiceable(x, sb))//This is checking each line if it's possible to invoce.  But some lines may want not be ready.  This is stopping the invoice in these cases.
            //        possible = false;
            //}



            if (!CheckVerify(x, missingProps))
                b = false;

            if (!possible)
                b = false;

            return b;
        }
        public List<orddet_line> DetailsListInvoiceable(ContextRz context)
        {
            StringBuilder sb = new StringBuilder();
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.Invoiceable(context, sb))
                    ret.Add(l);
            }
            return ret;
        }
        public List<ordhed_invoice> MakeInvoiceWithChecks(ContextRz x, bool preInvoice = false)
        {
            //this used to be just the invoiceable lines, but then its impossible to know if the shipper intends to ship everything and needs to be warned of problems,
            //or if he understands that some lines aren't going to go. this way he gets the warning about any problem lines, and if he wants to do only some lines, he can
            //multi-select the lines and use the right-click invoice option

            //KT Don't Allow shipment if status != 'ValidationComplete'
            if (validation_stage != Enums.SalesOrderValidationStage.ValidationComplete.ToString())
            {
                x.Leader.Tell("This order is not in the ValidationComplete stage.  Cannot ship.");
                return null;
            }



            //2012_06_26 should be just lines that haven't been invoiced.  still include potential problems, but not invoiced lines
            List<orddet_line> lines = new List<orddet_line>();
            foreach (orddet_line l in DetailsVar.RefsList(x))
            {
                //Shouldn't this be checking "invoiceable"??
                if (!l.was_shipped)

                    if (l.Invoiceable(x, null, preInvoice))
                        lines.Add(l);




                //KT 10-19-2015 - This was passing all line, not just open lines into the invoice routine, causing it to fail, forcing user to fo manual line-by-line invoice method (see Above), ugly
                //if (!l.InvoiceHas && !l.was_shipped)
                // if (!l.InvoiceHas && !l.was_shipped && l.status == "Open")
                //lines.Add(l);
            }

            return MakeInvoiceWithChecks(x, lines, preInvoice);
        }
        public List<Rz5.ordhed_invoice> MakeInvoiceWithChecks(Rz5.ContextRz x, List<Rz5.orddet_line> lines, bool preInvoice = false)
        {
            //StringBuilder sb = new StringBuilder();
            List<string> missingProps = new List<string>();
            if (!MakeInvoicePossible(x, lines, missingProps))
            {
                string msg = "Please check these items before continuing:" + Environment.NewLine;
                foreach (String s in missingProps)
                    missingProps.Add(s + Environment.NewLine);
                //x.TheLeader.Error("Please check these items before continuing:\r\n\r\n" + sb.ToString());
                x.TheLeader.Error(msg);
                return null;
            }

            if (!MakeInvoiceConfirm(x, lines))
                return null;

            return MakeInvoice(x, lines, preInvoice);
        }
        //this is after the system knows that the invoicing is possible, allowing the user to cancel after receiving warnings
        protected virtual bool MakeInvoiceConfirm(ContextRz context, List<Rz5.orddet_line> lines)
        {
            //this stuff may only be for ctg; if that's the case i'll move it up to their system

            ReadyToShip = true;
            Update(context);

            bool b = true;
            ArrayList service = GetLinkedServiceOrders(context);
            if (service.Count > 0)
            {
                if (!context.TheLeader.AskYesNo("This order is linked to " + Tools.Number.LongFormat(service.Count) + " service orders.  Do you still want to create an invoice?"))
                    b = false;
            }

            if (is_government)
            {
                if (!context.TheLeader.AskYesNo("This order appears to be a government order.  Do you still want to create an invoice?"))
                    b = false;
            }

            return b;
        }
        public virtual List<Rz5.ordhed_invoice> MakeInvoice(Rz5.ContextRz x, List<Rz5.orddet_line> lines, bool preInvoice = false)
        {
            company theCustomer = company.GetById(x, this.base_company_uid);

            n_user SalesAgent = null;
            if (theCustomer != null)
                if (!theCustomer.companytype.ToLower().Contains("vendor"))//If this is not a vendor.
                    SalesAgent = n_user.GetById(x, theCustomer.base_mc_user_uid);//Default to compay owner
            //Else use current User.
            if (SalesAgent == null)
                SalesAgent = n_user.GetById(x, this.base_mc_user_uid);
            //When evaluation order process in test system, this is null.
            if (SalesAgent == null)
                throw new Exception("Error getting the Sales Agent referenc from the Sales Order");

            currency curr = x.Accounts.GetCurrency(x, currency_name);
            if (curr == null)
                throw new Exception("The currency " + currency_name + " could not be found");

            Dictionary<String, SalesLineGroup> sections = new Dictionary<String, SalesLineGroup>();
            int linec = 0;
            SalesLineGroup g = new SalesLineGroup(this);
            sections.Add("x", g);
            foreach (orddet_line d in lines)
            {
                g.TheLines.Add(d);
                linec++;
            }
            if (linec == 0)
            {
                x.TheLeader.Error("Only lines that are selected and open can be invoiced, and no selected, open lines were found on this sales order");
                return null;
            }
            List<SalesLineGroup> sections_list = new List<SalesLineGroup>();
            foreach (KeyValuePair<String, SalesLineGroup> kvp in sections)
            {
                sections_list.Add(kvp.Value);
            }

            //if in FastForwarMode (Proof Logic) create new Invoice every time.
            if (NMWin.Leader.FastForwardMode)
                sections_list = ((SysRz5)x.xSys).TheSalesLogic.CreateNewInvoice(x, this, sections_list);
            else
                sections_list = ((SysRz5)x.xSys).TheSalesLogic.GetExistingInvoices(x, this, sections_list);
            if (sections_list == null)
                return null;
            List<Rz5.ordhed_invoice> ret = new List<Rz5.ordhed_invoice>();
            foreach (SalesLineGroup section in sections_list)
            {
                ItemsInstance linesa = new ItemsInstance();
                foreach (orddet_line s in section.TheLines)
                {
                    linesa.Add(x, s);
                }
                ordhed_invoice xInvoice = null;
                if (section.TheTargetType == SalesLineGroupTargetType.NewOrder || section.TheTargetOrder == null)
                {
                    xInvoice = InvoiceObjectCreate(x);
                    xInvoice.AgentVar.RefSet(x, n_user.GetById(x, this.base_mc_user_uid));
                    x.Update(xInvoice);
                    x.TheSysRz.TheOrderLogic.Link2Orders(x, this, xInvoice);
                }
                else
                    xInvoice = (ordhed_invoice)section.TheTargetOrder;
                if (xInvoice == null)
                    continue;


                xInvoice.DetailsVar.RefsAdd(x, linesa);

                //Pass Hubspot ID
                xInvoice.hubspot_deal_id = this.hubspot_deal_id;


                //set the fill dates on the sales order lines,
                //assuming that if an invoice was made, the parts are shipped
                Double accumulated_shipping = 0;

                xInvoice.currency_name = curr.name;
                xInvoice.exchange_rate = curr.exchange_rate; //take today's rate when the invoice is created

                foreach (orddet_line o in linesa.All)  //switched this to just the lines being invoiced
                {
                    if (preInvoice)
                        o.Status = Rz5.Enums.OrderLineStatus.PreInvoiced;
                    else
                        o.Status = Rz5.Enums.OrderLineStatus.Packing;
                    o.was_invoice = true;
                    o.ApplyNewCurrencyPrice(x, curr); //take today's rate when the invoice is created
                    x.Update(o);

                    accumulated_shipping += o.shipping_fee_invoice;
                }
                //apply all the shipping from the sales lines to the new invoice
                xInvoice.shippingamount += accumulated_shipping;

                //Commission Percent
                xInvoice.commission_percent = SalesAgent.commission_percent;

                //this was empty in Rz3.RzLogic but is used in a few customer overrides
                x.TheSysRz.TheSalesLogic.CloneSaleOrhitsToInvoice(x, this, xInvoice);
                x.Update(xInvoice);
                ret.Add(xInvoice);
            }
            return ret;
        }
        protected virtual ordhed_invoice InvoiceObjectCreate(ContextRz context)
        {
            ordhed_invoice ret = (ordhed_invoice)GetNewOrderHeader(context, Rz5.Enums.OrderType.Invoice);
            if (!Tools.Strings.StrExt(credit_to_invoice) && credit_amount > 0)
            {
                ret.credit_amount = credit_amount;
                ret.credit_caption = credit_caption;

                credit_to_invoice = ret.ordernumber;
                context.Update(this);
            }
            return ret;
        }
        public virtual List<ordhed> PotentialInvoicesList(Context x)
        {
            List<ordhed> ret = new List<ordhed>();
            ArrayList a = GetLinkedInvoiceCollection((ContextRz)x);
            if (a.Count > 0)
            {
                foreach (ordhed_invoice i in a)
                {
                    //if (!i.isclosed)  //don't jump on closed invoices (joe wants this ability)
                    //{
                    ret.Add(i);
                    // }
                }
            }

            return ret;
        }
        public ordhed_invoice InvoiceCreatePartial(ContextRz x)
        {
            return null;

            //List<PartialInvoiceLineHandle> lines = new List<PartialInvoiceLineHandle>();  // Win.Dialogs.PartialInvoice.AskForHandles(x, this);

            //foreach (KeyValuePair<String, nObject> kvp in AllDetails)
            //{
            //    orddet_sales sale = (orddet_sales)kvp.Value;
            //    bool cancel = false;
            //    int q = x.TheLeader.AskForInt32("Quantity For " + sale.ToString(), Convert.ToInt32(sale.quantityordered - sale.quantityfilled), "Invoice Quantity", ref cancel);
            //    if (q > 0)
            //    {
            //        PartialInvoiceLineHandle h = new PartialInvoiceLineHandle(sale);
            //        h.Quantity = q;
            //        lines.Add(h);
            //    }
            //}

            //if (lines.Count == 0)
            //    return null;

            //if (!x.TheLeader.AreYouSure("invoice " + Tools.Strings.PluralizePhrase("line", lines.Count)))
            //    return null;

            //ordhed_invoice invoice = (ordhed_invoice)GetNewOrderHeader(x, Enums.OrderType.Invoice);
            //if (invoice == null)
            //    return null;
            //dealheader.CheckDealLinks(x, this, invoice);
            //invoice.is_partial = true;
            //foreach (PartialInvoiceLineHandle h in lines)
            //{
            //    //ordline yDetail = invoice.LineCreate(x);
            //    //yDetail.AbsorbDetailFull(h.SaleLine);
            //    //Int64 hold_qty = yDetail.quantityordered;
            //    //yDetail.quantityfilled = 0;
            //    //yDetail.quantityordered = h.Quantity;
            //    //yDetail.IUpdate();
            //    //dealdetail.CheckDealLinksDetail(x, h.SaleLine, yDetail);
            //    //h.SaleLine.IUpdate();
            //    //yDetail.PickReceiveStock(x, Enums.FillType.Pick, true, false);
            //    //yDetail.quantityordered = hold_qty;
            //    //yDetail.IUpdate();
            //}            
            //MakeLinkObject(x, invoice);
            //return invoice;
        }

        public List<ordhed_invoice> CreateInvoice(ContextRz x, bool preInvoice = false)
        {
            List<ordhed_invoice> ret;
            ContextRz xx = (ContextRz)x.Clone();
            String cid = xx.TheDelta.StartChangeCache();
            ret = this.MakeInvoiceWithChecks(xx, preInvoice);
            if (ret == null)
            {
                return null;
            }

            xx.TheDelta.EndChangeCache(x, cid);
            if (xx.xSys.Recall)
            {
                string inv_numb = "";
                foreach (ordhed_invoice i in ret)
                {
                    if (Tools.Strings.StrExt(inv_numb))
                        inv_numb += ",";
                    inv_numb += i.ordernumber;
                }
                if (Tools.Strings.StrExt(inv_numb))
                    xx.xSys.RecallActionLog(this, Tools.Strings.PluralizePhrase("Invoice", Convert.ToDouble(ret.Count)) + " created: " + inv_numb, xx.xUser);
            }

            return ret;
        }

        public override Double SubTotal(ContextRz context)
        {
            Double sub = 0;
            foreach (orddet_line l in DetailsList(context))
            {
                sub += l.total_price;
            }
            return sub;
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;

            switch (args.ActionName.ToLower())
            {
                //case "companydetails":
                //    ShowCompanyDetails();
                //    break;
                case "newinvoice":
                case "makeinvoice":
                case "newdocs_invoice":
                case "makepickticket":
                    MakeInvoiceWithChecks(xrz);
                    break;
                case "salesordercomplete":
                case "completesalesorder":
                    CompleteSalesOrder(xrz);
                    break;
                //case "makepos":
                //case "reorderpo":
                //case "makepo":
                //case "newdocs_purchase":
                //    CheckCreatePOs((ContextRz)args.TheContext);
                //    break;

                //kt 11-20-2015 - Handle View Order Batch
                case "vieworderbatch":
                    ViewOrderBatch(xrz);
                    break;
                //case "quickbooks":
                //    SendSalesOrderToQuickbooks(xrz);
                //    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public bool SendSalesOrderToQuickbooks(ContextRz xrz)
        {
            //Send The Sale
            bool success = true;
            success = xrz.TheSysRz.TheQuickBooksLogic.SendOrder(xrz, this);
            if (!success)
                return false;
            //Sync Purchases
            ArrayList relatedPOs = this.GetRelatedPurchases(xrz);
            if (relatedPOs.Count > 0)
                success = SyncQBRelatedPurchaseOrders(xrz, relatedPOs);
            if (!success)
                return false;
            //Sync Service Orders
            ArrayList relatedServiceOrders = this.GetRelatedServiceOrders(xrz, DetailsList(xrz));
            if (relatedServiceOrders.Count > 0)
                success = SyncQBRelatedServiceOrders(xrz, relatedServiceOrders);
            if (!success)
                return false;
            xrz.Leader.Comment("Successfully sent " + this.OrderType.ToString() + " Order# " + this.ordernumber + " to Quickbooks.");
            return success;

        }

        private bool SyncQBRelatedServiceOrders(ContextRz xrz, ArrayList relatedServiceOrders)
        {
            try
            {

                if (!xrz.Leader.AskYesNo("Would you like to synchronize " + relatedServiceOrders.Count + " related Service orders at this time?"))
                    return false;

                foreach (ordhed_service p in relatedServiceOrders)
                {
                    xrz.Leader.StartPopStatus("Sending Service Order# " + p.ordernumber + " ...");
                    if (!xrz.TheSysRz.TheQuickBooksLogic.SendOrder(xrz, p))
                        xrz.Leader.Comment("There was a problem sending Service Order# " + p.ordernumber + " to Quickbooks.");
                    else
                        xrz.Leader.Comment("Successfully sent Service Order# " + p.ordernumber + " to Quickbooks.");



                }
                return true;
            }
            catch (Exception ex)
            {
                xrz.Leader.Error(ex);
                return false;
            }
        }

        private bool SyncQBRelatedPurchaseOrders(ContextRz xrz, ArrayList relatedPOs)
        {
            try
            {

                List<ordhed_purchase> pList = new List<ordhed_purchase>();
                foreach (ordhed_purchase p in relatedPOs)
                {
                    if (!p.isvoid)
                        pList.Add(p);
                }


                if (!xrz.Leader.AskYesNo("There are " + pList.Count + " related purchase orders.  Would you like to create/update them in Quickbooks at this time?"))
                    return false;

                foreach (ordhed_purchase p in pList)
                {
                    xrz.Leader.StartPopStatus("Sending PO# " + p.ordernumber + " ...");
                    if (!xrz.TheSysRz.TheQuickBooksLogic.SendOrder(xrz, p))
                        xrz.Leader.Comment("There was a problem sending PO# " + p.ordernumber + " to Quickbooks.");
                    else
                        xrz.Leader.Comment("Successfully sent PO# " + p.ordernumber + " to Quickbooks.");



                }
                return true;
            }
            catch (Exception ex)
            {
                xrz.Leader.Error(ex);
                return false;
            }


        }

        protected void ViewOrderBatch(ContextRz context)
        {

            string batchid = context.TheSysRz.TheOrderLogic.GetAssociatedBatchID(context, this);
            if (!Tools.Strings.StrExt(batchid))
            {
                context.Leader.Tell("No Order batch was found for this order.");
                return;
            }
            else
            {
                //delheader d = dealheader.GetById(context, batchid)
                context.Show(dealheader.GetById(context, batchid));
            }


        }

        public string GetAssociatedSalesBatchID(ContextRz context)
        {
            return context.SelectScalarString("select DISTINCT q.base_dealheader_uid from orddet_quote q inner join orddet_line l on q.unique_id = l.quote_line_uid where l.orderid_sales = '" + this.unique_id + "'");
        }


        //public override void ShowCompanyDetails()
        //{
        //    try
        //    {
        //        String showtext = "";
        //        if (!Tools.Strings.StrExt(base_company_uid))
        //            showtext = "There is no linked company.";
        //        else
        //        {
        //            company c = company.GetByID(xSys, base_company_uid);
        //            if (c == null)
        //                showtext = "This company was not found in the system.";
        //            else
        //            {
        //                showtext = c.companyname + "\r\n";
        //                companyaddress ca = companyaddress.GetByDescription(xSys, c.unique_id, "Billing");
        //                if (ca != null)
        //                {
        //                    if (Tools.Strings.StrExt(ca.line1) && !Tools.Strings.StrCmp(c.companyname, ca.line1))
        //                        showtext += ca.line1 + "\r\n";
        //                    if (Tools.Strings.StrExt(ca.line2) && !Tools.Strings.StrCmp(c.companyname, ca.line2))
        //                        showtext += ca.line2 + "\r\n";
        //                    if (Tools.Strings.StrExt(ca.line3) && !Tools.Strings.StrCmp(c.companyname, ca.line3))
        //                        showtext += ca.line3 + "\r\n";
        //                    String csz = "";
        //                    if (Tools.Strings.StrExt(ca.adrcity))
        //                        csz += ca.adrcity;
        //                    if (Tools.Strings.StrExt(ca.adrstate))
        //                    {
        //                        if (Tools.Strings.StrExt(csz))
        //                            csz += ", " + ca.adrstate;
        //                        else
        //                            csz += ca.adrstate;
        //                    }
        //                    if (Tools.Strings.StrExt(ca.adrzip))
        //                    {
        //                        if (Tools.Strings.StrExt(csz))
        //                            csz += " " + ca.adrzip;
        //                        else
        //                            csz += ca.adrzip;
        //                    }
        //                    if (Tools.Strings.StrExt(csz))
        //                        showtext += csz + "\r\n";
        //                }
        //                if (Tools.Strings.StrExt(c.primaryphone))
        //                    showtext += "Phone: " + c.primaryphone + "\r\n";
        //                if (Tools.Strings.StrExt(c.primaryfax))
        //                    showtext += "Fax: " + c.primaryfax + "\r\n";
        //                if (Tools.Strings.StrExt(c.primaryemailaddress))
        //                    showtext += "Email: " + c.primaryemailaddress + "\r\n";
        //            }
        //        }
        //        nStatus.InputMessageBoxMultiLine("", showtext, "Company Summary", RzApp.xMainForm);
        //    }
        //    catch (Exception)
        //    { }
        //}
        public override Enums.OrderType OrderType
        {
            get
            {
                return Enums.OrderType.Sales;
            }
            set
            {
                if (value != Enums.OrderType.Sales)
                    throw new Exception("Invalid order type");
            }
        }
        public override void Inserting(Context x)
        {
            base.Inserting(x);
            ordertype = "Sales";
            showonwarehouse = true;
            CheckHold();
        }
        public override void Updating(Context context)
        {
            if (!Tools.Strings.StrExt(billingname))
                billingname = companyname;
            if (!Tools.Strings.StrExt(shippingname))
                shippingname = companyname;
            bool has_hold = false;
            bool has_open = false;
            bool has_blank = false;
            bool has_buy = false;
            bool has_packing = false;
            bool out_for_service = false;
            bool has_preinvoice = false;
            open_line_count = 0;
            is_stock = false;
            foreach (orddet_line d in DetailsList((ContextRz)context))
            {

                d.Updating(context);

                if (d.StockType == Enums.StockType.Stock || d.StockType == Enums.StockType.Consign)
                    is_stock = true;
                if (d.Status == Rz5.Enums.OrderLineStatus.Hold)
                    has_hold = true;
                if (d.Status == Rz5.Enums.OrderLineStatus.Open || d.Status == Rz5.Enums.OrderLineStatus.Buy || d.Status == Rz5.Enums.OrderLineStatus.Packing || d.Status == Rz5.Enums.OrderLineStatus.Packing_For_Service || d.Status == Rz5.Enums.OrderLineStatus.Out_For_Service)
                    has_open = true;
                if (d.status == "")
                    has_blank = true;
                if (d.Status == Enums.OrderLineStatus.Buy)
                    has_buy = true;
                if (d.Status == Enums.OrderLineStatus.Packing)
                    has_packing = true;
                if (d.Status == Enums.OrderLineStatus.PreInvoiced)
                    has_preinvoice = true;
                if (d.Status == Enums.OrderLineStatus.Packing_For_Service || d.Status == Enums.OrderLineStatus.Out_For_Service)
                    out_for_service = true;
                if (d.Status == Enums.OrderLineStatus.Open)
                    open_line_count++;
                if (d.is_rma_replacement)
                    has_rma_replacement = true;
            }
            if (!has_blank)  //skip the status change for legacy lines
            {
                if (!isvoid && DetailsCount((ContextRz)context) == 0)
                {
                    onhold = true;
                    isclosed = false;
                }
                else
                {
                    if (has_hold && !onhold && !isvoid)
                    {
                        isclosed = false;
                        onhold = true;
                    }
                    else if (!isvoid && !has_hold && !has_open && !has_preinvoice)
                    {
                        isclosed = true;
                        onhold = false;
                    }
                    else if (has_open && !has_hold)
                    {
                        onhold = false;
                        isclosed = false;
                    }
                }
                if (isvoid)
                    status_caption = "Void";
                else if (has_hold)
                    status_caption = "Hold";
                else if (out_for_service)
                    status_caption = "Out For Service";
                else if (has_buy)
                    status_caption = "On Order";
                else if (has_packing)
                    status_caption = "Packing";
                else
                    status_caption = "Shipped";
            }
            if (isclosed)
            {
                //If this is already closed, but has holds or open lines, re-open.
                if (has_hold && has_open)
                    isclosed = false;
            }
                
            //Override the previious if drop-ship conditions met
            if (!isclosed)
                isclosed = OrderLogic.CheckCloseDropShip(context, this);
            base.Updating(context);
        }



        //KT 9-6-2017 - Removed Many Comments to make this easier to follow, see "_bak" version below if need to reference intact source.
        public override void CalculateAllAmounts(ContextRz context)
        {
            base.CalculateAllAmounts(context);
            double subTotalExchanged = 0;
            sub_total = 0;
            ordertotal = 0;
            expenses = 0;
            total_profit_subtractions = 0;
            total_po_deductions = 0;
            gross_profit = 0;
            total_quantity = 0;
            total_quantity_filled = 0;
            open_balance = 0;
            credit_amount = 0;
            rma_loss = 0;
            double charge_amount = 0;
            total_Credits = 0;
            total_Charges = 0;
            total_line_cost = 0;
            double total_payroll_deductions = 0;
            double refundBalance = 0;

            List<profit_deduction> AllDeductionsForSale = new List<profit_deduction>(); // Keep a list of all deductions for this order, use to find canceled deductions


            //KT Get SUM of all Credits and Charges on related invoices
            //Get a list of unique invoice IDs related to the order
            List<string> relatedInvoices = new List<string>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (!relatedInvoices.Contains(l.orderid_invoice))
                    relatedInvoices.Add(l.orderid_invoice);
            }
            credit_amount = context.SelectScalarDouble("select SUM(hit_amount) from ordhit where the_ordhed_uid IN (" + Tools.Data.GetIn(relatedInvoices) + ")" + "AND (deduct_profit = 1)");
            charge_amount = context.SelectScalarDouble("select SUM(hit_amount) from ordhit where the_ordhed_uid IN (" + Tools.Data.GetIn(relatedInvoices) + ")" + "AND (deduct_profit = 0)");

            //End refactor block

            //Load PoPayments
            Calculate_All_PO_Balance(this, context);

            foreach (orddet_line l in DetailsList(context))
            {
                l.CalculateAmounts(context);

                if (context.TheSysRz.TheOrderLogic.CheckLineStatusForTotals(context, l))//l.Status != Enums.OrderLineStatus.Void && !l.was_rma && was_vendrma
                {

                    //KT Refactored from RzSensible 10-7-2015    
                    //Sometimes we scrapp / quarantine lines before sending to Vendor, therefore no RMA to offset price, but need to maintain lost cost
                    List<string> noPriceStatus = new List<string>() { "scrapped", "quarantined" }; //"scrap", "destroy", "destroyed", "quarantine", 
                    if (!noPriceStatus.Contains(l.status.ToLower()))
                    {
                        //if(string.IsNullOrEmpty)
                        sub_total += l.total_price;//Don't add the customer_price into net profit for scrap / quarantine if it's not on an invoice
                    }

                    gross_profit += l.gross_profit;
                    expenses += l.InvoiceCharges;
                    total_quantity += (int)l.quantity;//sum of the quantity of the details
                    total_quantity_filled += (int)l.quantity_packed;//sum of the packed quantities
                    open_balance += (l.quantity - l.quantity_packed) * l.unit_price;//sum of each lines quantity not filled * the line's unitprice
                    subTotalExchanged += l.total_price_exchanged;


                    if (!l.is_RMA_IHS)//KT 3-28-2016 - Checking for RMA_IHS before adding to total coast, see SO# 141108
                        total_line_cost += l.total_cost;
                    if (!l.is_RMA_IHS && (l.stocktype == "Stock" || l.stocktype == "Consign")) //Stock Cost assuming not RMA_IHS,in RMA IHS, the part isn't being returned, already has a cost on the original line
                        costamount += l.total_cost;


                    costamount -= total_payroll_deductions;

                }
                else if (l.was_rma || l.was_vendrma) //Non-Voided but RMA / VRMA
                {
                    //Original Code
                    expenses += l.InvoiceCharges;
                    total_quantity += (int)l.quantity;//sum of the quantity of the details
                    total_quantity_filled += (int)l.quantity_packed;//sum of the packed quantities
                    open_balance += (l.quantity - l.quantity_packed) * l.unit_price;//sum of each lines quantity not filled * the line's unitprice    
                    //If we don't have a vendor RMA For and RMA, and stocktype not stock or consign, need to carry line cost.  Once we get VRMA, this won't carry
                    if (!l.was_vendrma && (l.stocktype != Enums.StockType.Consign.ToString() && l.stocktype != Enums.StockType.Stock.ToString()))
                        total_line_cost += l.total_cost;
                }
            }

            List<profit_deduction> allDeductions = context.TheSysRz.TheProfitLogic.GetDeductionsForOrder(context, this);

            if (allDeductions != null)
                foreach (profit_deduction p in allDeductions)
                {
                    //if (!AllDeductionsForSale.Any(a => a.unique_id == p.unique_id))
                    total_profit_subtractions += p.amount;
                }

            //Identify any costs against canceled lines.
            ArrayList canceledLines = context.TheSysRz.TheProfitLogic.GetCanceledLinesSales(context, this.unique_id);
            double canceledServiceCosts = GetCanceledSeviceCosts(context, canceledLines);
            double canceledGcatCostss = GetCanceledGcatCosts(context, canceledLines);


            profitamount = gross_profit;//for labels?      
            if (this.isvoid)//For voided lines, ensure to subtract un-refunded po_payments.
                total_profit_subtractions += po_payment;

            //Round the things!
            ordertotal = Tools.Number.CommonSensibleRounding(sub_total);
            total_line_cost = Tools.Number.CommonSensibleRounding(total_line_cost);
            total_profit_subtractions = Tools.Number.CommonSensibleRounding(total_profit_subtractions);
            credit_amount = Tools.Number.CommonSensibleRounding(credit_amount);


            net_profit = ordertotal - total_line_cost - total_profit_subtractions - credit_amount;

            if (total_quantity_filled <= 0)//blank if nothing is filled, P if its partially filled, and Y if its compeltely filled
                invoice_info = "";
            else if (total_quantity == total_quantity_filled)
                invoice_info = "Y";
            else
                invoice_info = "P";

            ordertotal_exchanged = subTotalExchanged + shippingamount_exchanged + handlingamount_exchanged + taxamount_exchanged;

            //Round the final Totals!
            net_profit = Tools.Number.CommonSensibleRounding(net_profit);
            ordertotal_exchanged = Tools.Number.CommonSensibleRounding(ordertotal_exchanged);
        }

        public double GetCanceledGcatCosts(ContextRz context, ArrayList lines)
        {
            double ret = 0;

            foreach (orddet_line cl in lines)
                if (cl.fullpartnumber.ToLower().Contains("gcat"))
                    ret += cl.total_cost;
            return ret;
        }

        public double GetCanceledSeviceCosts(ContextRz x, ArrayList lines)
        {
            double ret = 0;
            foreach (orddet_line cl in lines)
                ret += cl.service_cost;
            return ret;
        }







        //KT Get List of related PO's
        public void Calculate_All_PO_Balance(ordhed_sales s, ContextRz context)
        {            //KT Since this is the first of the cost calculations, resetting costamount here instead of in CalculateAllAmounts
            costamount = 0;
            s.po_payment = 0;
            s.vrma_payment = 0;
            ArrayList Purchases = GetRelatedPurchases(context);
            foreach (ordhed_purchase p in Purchases)
            {
                Calculate_Single_PO_Balance(p, s, context);
            }
        }
        protected void Calculate_Single_PO_Balance(ordhed_purchase PO, ordhed_sales SO, Rz5.ContextRz context)
        {



            //KT Sum of total PO
            double total_po_balance = 0;

            //KT Sum of all line costs on this po
            double total_line_cost = 0;
            total_line_cost = context.SelectScalarDouble("select SUM(total_cost) + SUM(total_deduction) + SUM(service_cost) from orddet_line where stocktype != 'stock' AND orderid_purchase = '" + PO.unique_id + "' AND orderid_sales = '" + SO.unique_id + "'");

            //KT Sum of all deductions on this po
            //double total_deduction_cost = 0;
            //total_deduction_cost = context.SelectScalarDouble("select SUM(total_deduction) from orddet_line where stocktype != 'stock' AND orderid_purchase = '" + PO.unique_id + "' ");

            //KT Sum of all services charges on this po
            double total_service_cost = 0;
            total_service_cost = context.SelectScalarDouble("select SUM(service_cost) from orddet_line where stocktype != 'stock' AND orderid_purchase = '" + PO.unique_id + "'");


            ////KT Sum of all "payroll deduction" deductions charges on this po (Stock OverBuys, etc)
            //double total_payroll_deduction = 0;
            //total_payroll_deduction = context.SelectScalarDouble("select SUM(amount) from profit_deduction where stocktype != 'stock' and is_payroll_deduction = 1 AND orderid_purchase = '" + PO.unique_id + "'");

            //KT Get sum of Vendor Credits
            double applied_vendor_credits = 0;
            applied_vendor_credits = context.SelectScalarDouble("select SUM(creditamount) from companycredit where applied_to_order_uid = '" + PO.unique_id + "'");

            //KT Get sum deductions applied to the po, if we don't remove these, they get counted both in costamount, and in line subtractions.  Other deductions would only come our in subtractions as usual.
            double deductions_already_applied_to_po = 0;
            deductions_already_applied_to_po = context.SelectScalarDouble("select SUM(amount) from profit_deduction where include_on_po = 1 and purchase_order_uid = '" + PO.unique_id + "'");



            //KT Get sum of po Payments
            //NOTE that this sql is looking at "subtotal" since "fees" are getting added as deductions when you add them to a payment.
            double po_payment = 0;
            //KT 10-13-15 No, actually I think we may need to do transamount, it's throwing off orders where people are adding fees to payments, transamount should catch all.
            //po_payment = context.SelectScalarDouble("select SUM(subtotal) from checkpayment where base_ordhed_uid = '" + PO.unique_id + "'");
            po_payment = context.SelectScalarDouble("select SUM(transamount) from checkpayment where base_ordhed_uid = '" + PO.unique_id + "' AND isnull(withhold_from_profit, 0) != 1");

            //KT Get sum of vrma Payments
            double vrma_payment = 0;
            vrma_payment = context.SelectScalarDouble("select SUM(transamount) from checkpayment where base_ordhed_uid IN(select orderid_vendrma from orddet_line where orderid_purchase = '" + PO.unique_id + " and orderid_sales = '" + SO.unique_id + "'')");

            //KT Get sum cost of VENDRMA lines
            double cost_of_vrma_lines = 0;
            cost_of_vrma_lines = context.SelectScalarDouble("select SUM(total_cost) from orddet_line where orderid_purchase = '" + PO.unique_id + "' AND was_vendrma = 1");//          checkpayment where base_ordhed_uid IN(select orderid_vendrma from orddet_line where orderid_purchase = '" + PO.unique_id + "')");




            //Have We Paid?
            if (po_payment > 0) //if SUM of po_payments and and applied_vendor_credits > 0
            {
                //Is there a VendorRMA?
                if (vrma_payment > 0) //Yes
                {
                    if (po_payment == vrma_payment)//If po_payment exactly matches vrma_payment, then there is no cost?
                    {
                        //total_po_balance = total_line_cost;
                        total_po_balance = 0;
                    }
                    else //po_payment is different from vrma amount
                    {
                        if (po_payment > vrma_payment)//po_payment is more than the vrma_paymment (refund), were only some of the lines VRMA's?  I.e. does the cost_of_vrma_lines == vrma_payment?
                        {

                            total_po_balance = (po_payment - vrma_payment);
                        }
                        else if (po_payment < vrma_payment)
                        {
                            total_po_balance = po_payment;
                        }
                    }
                }
                else//No - No VRMA Payment
                {
                    //Is paid amount == to the sum of all lines. 
                    if (po_payment == total_line_cost)
                    {
                        total_po_balance = po_payment;
                    }
                    else//paid amount is not equal to line balance
                    {

                        if (po_payment > total_line_cost)//PO Payment is greater than total line cost
                        {
                            total_po_balance = total_line_cost;
                        }
                        else if (po_payment < total_line_cost)//PO Payment is less than total line cost
                        {

                            //KT no clue how to properly handle this vendor credit situation.
                            //if (applied_vendor_credits > 0)//a credit has been applied, and this should come out of profit
                            //{
                            //    total_po_balance = applied_vendor_credits - po_payment;
                            //}
                            //else
                            total_po_balance = po_payment;
                        }
                    }
                }
            }
            else if (po_payment < 0) //Rare instances where we have no vrma but a refund on a PO, and that refund was more than the amount paid (see SO# 150106)
            {
                //No Idea What we do here, for now, setting to actul po_payment to the numbers make more sense.
                total_po_balance = po_payment;
            }
            else //No - Haven't Paid PO
            {

                //total_po_balance = 0;
                //KT 3-28-2016
                total_po_balance = total_line_cost;

            }
            //KT think I need to remove deductuions that are already on a PO, we're subtracting them as cost as line deduction and balancing that with po payment already?
            costamount += total_po_balance + applied_vendor_credits - deductions_already_applied_to_po;// +total_deduction_cost + total_service_cost;
            //KT 3-28-2016 - Per FT, we need to see a PO Balance regardless of whether a payment was made. I may do something with the below version, but for now seeing if I Can do this in "else" above
            //costamount += total_line_cost + applied_vendor_credits - deductions_already_applied_to_po;// +total_deduction_cost + total_service_cost;
            SO.po_payment += po_payment;
            SO.vrma_payment += vrma_payment;

        }





        //public virtual bool CheckVerify(ContextRz context, StringBuilder sb)
        //{
        //    return context.TheSysRz.TheSalesLogic.CheckVerify(context, this, sb, new List<string>());
        //}


        public override bool TransmitPossible(ContextRz context, Enums.TransmitType ttype, List<string> ignoredPropertiesList)
        {

            if (!base.TransmitPossible(context, ttype, new List<string>() { "Cannot be Source TBD" }))//Allow print & email of TBD  
                return false;

            //StringBuilder sb = new StringBuilder();
            List<string> missingProps = new List<string>();
            if (!CheckVerify(context, missingProps))
            {
                string msg = "";
                foreach (string s in missingProps)
                    msg += s + Environment.NewLine;
                //context.TheLeader.Error(missingProps);
                return false;
            }

            return true;
        }
        public List<Rz5.orddet_line> DetailsListCompleteReady(ContextRz context, bool supress_msg = false)
        {
            String message = "";
            int count = 0;
            return DetailsListCompleteReady(context, ref message, ref count, supress_msg);
        }

        public virtual List<Rz5.orddet_line> DetailsListCompleteReady(ContextRz context, ref String message, ref int count_not_ready, bool supress_msg = false)
        {
            List<Rz5.orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.Status == Enums.OrderLineStatus.PreInvoiced)
                {
                    //IF  a buy line, and no po id yet, allow completion
                    if (l.StockType == Enums.StockType.Buy)
                        if (string.IsNullOrEmpty(l.orderid_purchase))
                            ret.Add(l);
                }

                else if (l.Status == Enums.OrderLineStatus.Hold)//Only Hold lines are ready to be completed
                {
                    //CHeck if this line is in the MissingPRoperties List

                    if (MissingPropertiesList.ContainsKey(l))
                        count_not_ready++;
                    else if (l.vendor_name == "Source TBD")
                        count_not_ready++;
                    else
                        ret.Add(l);
                }
                else count_not_ready++;

                //else if (l.Status == Enums.OrderLineStatus.Hold)
                //    count_not_ready++;
            }
            return ret;
        }

        public virtual bool SalesOrderCompletePossible(ContextRz x, List<Rz5.orddet_line> lines)
        {


            //StringBuilder sb = new StringBuilder();
            List<string> missingProps = new List<string>();
            if (!CheckVerify(x, missingProps))
            {
                //x.TheLeader.Error(sb.ToString());
                string msg = "Missing Properties: " + Environment.NewLine;
                foreach (string m in missingProps)
                    msg += m + Environment.NewLine;
                return false;
            }

            bool icCreditCard = nTools.IsTermsCreditCard(terms);

            if (icCreditCard)
            {
                if (!x.TheLeader.AskYesNo("This appears to be a credit card order.  Is a valid credit card present on the company record? (Company -> Credit Card Info tab)"))
                    return false;
            }
            else
            {
                List<string> skipCreditCheckTerms = new List<string>() { "ach", "ach in advance", "cod", "wire", "tt", "advance", "wire in advance", "cod certified", "paypal", "check in advance", "30% tt", "credit", "upon delivery", "upon delivery of file" };
                if (!skipCreditCheckTerms.Contains(terms.ToLower()))
                    if (!SalesOrderCompletePossibleCreditLimit(x))
                    {
                        x.TheLeader.Tell("This order cannot be completed due to exceeding the customer's credit limit. Please contact the accounting department.");
                        return false;
                    }

            }



            //if (!SalesOrderCompletePossibleCredit(x)) //This only does credit card specific checks legacy code
            //    return false;



            company cust = CompanyVar.RefGet(x);
            if (cust == null)
            {
                x.TheLeader.Tell("This order cannot be completed; select a customer before continuing");
                return false;
            }

            if (cust.is_locked)
            {
                x.TheLeader.Tell("This order cannot be completed; " + cust.companyname + " is marked as 'Locked' by accounting");
                return false;
            }

            String s = "";
            bool b = true;
            foreach (orddet_line d in lines)
            {
                String err = "";
                if (!d.Completeable(x, ref err))
                {
                    b = false;
                    s += err + "\r\n";
                }
            }
            if (!b)
            {
                x.TheLeader.Tell("Please correct these lines:\r\n\r\n" + s);
                return false;
            }
            else
                return true;
        }
        //protected virtual bool SalesOrderCompletePossibleCredit(ContextRz context)
        //{
        //    if (nTools.IsTermsCreditCard(terms))
        //    {
        //        if (!context.TheLeader.AskYesNo("This appears to be a credit card order.  Is a valid credit card present on the company record? (Company -> Credit Card Info tab)"))
        //            return false;
        //    }
        //    return true;
        //}
        protected virtual bool SalesOrderCompletePossibleCreditLimit(ContextRz context)
        {
            company c = this.CompanyVar.RefGet(context);
            if (c == null)
                return true;

            if (c.creditascustomer <= 0)
                return true;

            //KT - Found this commented out, need to see what the code does and how it can be applied to sensible:
            //2012_05_01 we need to identify who actually applies payments and make this specific to them; most companies don't apply them
            //ArApInfo a = context.TheSysRz.TheCompanyLogic.CalculateOutstandingBalance(context, c);

            //if (a == null)
            //return true;
            //if (c.creditascustomer < a.OutstandingAR)
            //return false;
            //double d = 0;
            //d = context.TheSysRz.TheCompanyLogic.CalculateOutstandingBalance_Company(context, c);
            //if (d == 0)
            //    return true;
            //if (c.creditascustomer < d)
            //{
            //    context.TheSysRz.TheCompanyLogic.CalculateOutstandingBalance_Company(context, c, true, "Cannot Complete Sales Order:  Amount is above their current outstanding balance.");
            //    return false;
            //}



            //Total shold be a SUM Of Non-invoiced Sales that are not voided
            //Get A LIst of LInes for this company that are not on an invoice and that are not void.  Limiting to >= 2017 as we have lots of old SO lines that are invalid.
            //double total = context.SelectScalarDouble("select sum(unit_price * quantity) from orddet_line where customer_uid = '" + this.base_company_uid + "' and status != '" + Enums.OrderLineStatus.Void.ToString() + "' and len(isnull(orderid_invoice, 0)) = 0 and date_created >= '1-1-2017'");
            //double total = context.SelectScalarDouble("select SUM(unit_price * quantity) from orddet_line where customer_uid = '" + this.base_company_uid + "' and status = '" + Enums.OrderLineStatus.Hold.ToString() + "'");
            //double total = a.OutstandingAR + this.ordertotal;

            //if (c.creditascustomer < total)
            //{
            //    context.Leader.Tell("This order exceeds the combined amount of Outstanding Sales Order Balances.  Please check the orders screen for this company's sales orders and investigate the outstanding Sales Orders.");
            //    return false;
            //}

            //KT End Commented section



            if (c.creditascustomer < this.ordertotal)  //we can at least say that if this order is over the limit, then stop it
                return false;

            return true;
        }
        public bool StockOrConsignCompletelyIs(ContextRz x, List<Rz5.orddet_line> lines)
        {
            foreach (Rz5.orddet_line d in lines)
            {
                if ((d.StockType == Enums.StockType.Stock && d.needs_purchasing && !Tools.Strings.StrExt(d.ordernumber_purchase)) || d.StockType == Enums.StockType.Buy)  //added the needs_purchasing flag 2012_08_14  added existing PO 2013_10_08
                    return false;
            }
            return true;
        }
        public bool StockCompletelyIs(ContextRz x, List<Rz5.orddet_line> lines)
        {
            foreach (Rz5.orddet_line d in lines)
            {
                if (d.StockType != Rz5.Enums.StockType.Stock || d.needs_purchasing)
                    return false;
            }

            return true;
        }

        public SalesOrderCompleteResult CompleteSalesOrder(ContextRz context)
        {
            List<orddet_line> completableLines = DetailsListCompleteReady(context);
            return CompleteSalesOrder(context, completableLines);
        }

        public virtual SalesOrderCompleteResult CompleteSalesOrder(ContextRz context, List<Rz5.orddet_line> lines)  //, ref ArrayList AllPOs
        {
            SalesOrderCompleteResult ret = new SalesOrderCompleteResult(false);
            List<orddet_line> stockLines = new List<orddet_line>();
            try
            {

                if (!SalesOrderCompletePossible(context, lines))
                    return ret;

                Rz5.company xCompany = CompanyVar.RefGet(context);
                if (xCompany != null)
                {
                    if (xCompany.HasCriticalProblems && !context.xUser.SuperUser)
                    {
                        if (!context.TheLeader.AskYesNo(xCompany.ToString() + " appears to be " + xCompany.ProblemDescription + ".  Have you cleared this sale with accounting?"))
                            return ret;
                    }
                }

                //moved here so that if the POs process is canceled it can cancel the entire SO complete process
                if (!context.TheSysRz.TheSalesLogic.ShouldPOsBeCreated(context, this, lines))
                {
                    context.TheLeader.Comment("No POs needed; skipping...");
                }
                else
                {
                    //Remove Lines that already have A po?
                    List<orddet_line> remove = new List<orddet_line>();

                    Dictionary<String, ordhed_purchase> purchases = new Dictionary<String, ordhed_purchase>();
                    foreach (orddet_line l in lines)
                    {

                        //Since we're completing a sales order, and the line has no PO yet, always copy over sales RoHS and Datecode info?
                        //Potential Problem, users may update the Sales rohs and line info AFTER this, however, they can just go to the PO, this
                        //closes the loop on the activate process.
                        //if (string.IsNullOrEmpty(l.rohs_info_vendor))
                        l.rohs_info_vendor = l.rohs_info;
                        //if (string.IsNullOrEmpty(l.datecode_purchase))
                        l.datecode_purchase = l.datecode;


                        if (Tools.Strings.StrCmp(l.po_option, "Add To PO") && Tools.Strings.StrExt(l.po_option_number))
                        {
                            ordhed_purchase p = (ordhed_purchase)ordhed.GetByNumberAndType(context, l.po_option_number, Enums.OrderType.Purchase);
                            if (p != null)
                            {
                                p.DetailsVar.RefsAdd(context, l);
                                //p.shipvia = this.shipvia;
                                l.Status = Enums.OrderLineStatus.Buy;
                                l.receive_date_due = new DateTime(1900, 1, 1);
                                l.qc_status = SM_Enums.QcStatus.Inbound.ToString();
                                //Update the PO Settings
                                context.Update(p);
                                //Update the linbe settings
                                context.Update(l);
                                //Add line to list of lines to that already have a PO.
                                remove.Add(l);


                                if (!purchases.ContainsKey(p.unique_id))
                                    purchases.Add(p.unique_id, p);
                            }
                        }
                    }

                    foreach (orddet_line l in remove)
                    {
                        lines.Remove(l);
                    }

                    foreach (KeyValuePair<String, ordhed_purchase> k in purchases)
                    {
                        context.Show(k.Value);
                    }

                    if (!CheckCreatePOs(context, lines, ret))
                        return ret;
                    //Gather the POs, get Ship Method and Date                   
                    ArrayList poList = GetLinkedPurchaseOrders(context);
                    bool poShipDetailsGathered = false;
                    //Will REvisit - Works but hard to identify which line you are setting up
                    // And even more complicated if multiple lines on multiple pos.
                    //Build a form 
                    //foreach (ordhed_purchase p in poList)
                    //    poShipDetailsGathered = GatherAllPOShipDetails(context, p);
                    //if (poShipDetailsGathered)
                    //    if (context.Leader.AskYesNo("Sales Order Completed.  Would you like to print all documents for the sales packet?  (Work-Up, PO's, Quote)"))
                    //        context.TheSysRz.TheOrderLogic.PrintAllDocuments(context, new List<ordhed> { this });
                }

                bool completelyStock = false;
                CompleteSalesOrderFinalize(context, lines, IsStockSale(context, lines, ref completelyStock), completelyStock);

                foreach (orddet_line d in lines)
                {
                    if (d.Status == Rz5.Enums.OrderLineStatus.Hold)
                    {
                        if (d.PurchaseHas && !d.was_received)
                            d.Status = Enums.OrderLineStatus.Buy;
                        else
                            d.Status = Rz5.Enums.OrderLineStatus.Open;
                        context.Update(d);
                    }

                }

                //If any lines are stock, alert shipping //WAIT There will be no stock lines in this method.
                foreach (orddet_line ll in lines)
                {
                    if (ll.stocktype == Enums.StockType.Stock.ToString() || ll.stocktype == Enums.StockType.Consign.ToString())
                        stockLines.Add(ll);
                }

                //Set the qcStatusI
                foreach (orddet_line ll in lines)
                {
                    if (ll.stocktype == Enums.StockType.Stock.ToString() || ll.stocktype == Enums.StockType.Consign.ToString())
                        ll.qc_status = SM_Enums.QcStatus.In_House.ToString();
                    else
                        ll.qc_status = SM_Enums.QcStatus.Inbound.ToString();
                }
                //Confirm Dock Date
                //context.TheSysRz.TheOrderLogic.ConfirmDockDates(context, this);

                //Stock Email Alert
                if (stockLines.Count > 0)
                    context.TheSysRz.TheOrderLogic.SendStockAlertEmail(context, stockLines, this);

                //Krystina Cabal requested removal of this on 10/3 as not useful and she prefers to manually check, so amounts to just an extra popup.
                //if (context.Leader.AskYesNo("Would you like to print all related documents?"))
                //    context.TheSysRz.TheOrderLogic.PrintAllDocuments(context, new List<ordhed>() { this }, false);

                context.TheLeader.Comment("Done.");
                context.TheLeader.StopPopStatus();


                try
                {
                    //this.isclosed = true;
                    //this.Close(RzWin.Context);
                    context.Update(this);

                    ret.Passed = true;
                }
                catch
                {
                    ret.Passed = false;
                }

            }
            catch (Exception ex)
            {
                context.Leader.Tell(ex.Message);
            }
            return ret;
        }

        private bool GatherAllPOShipDetails(ContextRz context, ordhed_purchase p)
        {
            foreach (orddet_line l in p.DetailsList(context))
            {

                string choice = "";
                //ShipVia Purchase
                if (string.IsNullOrEmpty(l.shipvia_purchase))
                {
                    choice = context.Leader.ChooseOneChoice(context, "shipvia");
                    if (!string.IsNullOrEmpty(choice))
                        l.shipvia_purchase = choice;
                    else return false;
                }
                //Ship Account Purchase
                if (string.IsNullOrEmpty(l.shippingaccount_purchase))
                {
                    //Get a list of Objects form an ArrayList by casting to each item to an object then all into a list
                    ArrayList poShipAccounts = context.TheSysRz.TheOrderLogic.GetCompanyShipAccounts(context, l.vendor_uid, true, context.TheLogicRz);
                    List<object> oList = new List<object>();
                    foreach (string s in poShipAccounts)
                        oList.Add(s);
                    if (oList.Count > 0)
                    {

                        choice = (string)frmChooseObject.ChooseFromPlainCollection(oList, "Choose Account");
                        if (!string.IsNullOrEmpty(choice))
                            l.shipvia_purchase = choice;
                        else return false;
                    }
                    else
                    {
                        context.Leader.Tell(l.customer_name + " does not have any shipping accounts setup.");
                        return false;
                    }
                }
                //Delivery Due Date
                if (l.receive_date_due.Date <= new DateTime(1901, 1, 1) || l.receive_date_due.Date == null)
                    l.receive_date_due = l.customer_dock_date.AddDays(-2);

                l.receive_date_due = context.Leader.ChooseDate(l.receive_date_due, "Please confirm the receive due date.");
                if (l.receive_date_due <= new DateTime(1970, 1, 1))
                {
                    context.Leader.Tell("Invalid Receive Due Date.");
                    return false;
                }
                l.Update(context);
            }


            return true;
        }

        public bool IsStockSale(ContextRz context, List<orddet_line> lines, ref bool completely_stock)
        {
            int stocklines = 0;
            int buylines = 0;

            foreach (orddet_line d in lines)
            {
                if (d.OrderHas(Enums.OrderType.Purchase))
                    buylines++;
                else
                    stocklines++;
            }

            if (buylines == 0 && stocklines == 0)
            {
                completely_stock = false;
                return false;
            }
            if (stocklines == 0)
            {
                completely_stock = false;
                return false;
            }
            else
            {
                completely_stock = (buylines == 0);
                return true;
            }
        }
        public virtual void CompleteSalesOrderFinalize(ContextRz context, List<orddet_line> lines, bool stock_sale, bool completely_stock)
        {

        }
        public virtual bool CheckCreatePOs(ContextRz x, List<Rz5.orddet_line> lines, SalesOrderCompleteResult result)
        {
            //KT - IS this redundant, I see the check happens twice.  The next check seems ot only check lines that require a purchase, but need to learn more about SalesLinesGetForPurchase to be sure.
            //if (!x.TheSysRz.TheOrderLogic.PurchaseOrdersCreatePossible(x, this, lines))
            //return false;
            List<Rz5.orddet_line> for_purchase = x.TheSysRz.TheOrderLogic.SalesLinesGetForPurchase(x, this, lines);

            if (for_purchase.Count == 0)
                return true;

            //KT This is just after the CheckCompletePossible
            if (!x.TheSysRz.TheOrderLogic.PurchaseOrdersCreatePossible(x, this, for_purchase))
                return false;

            //ask to print documentation

            bool Canceled = false;
            List<ordhed_purchase> pos = ((SysRz5)x.xSys).TheOrderLogic.PurchaseOrdersCreate(x, this, for_purchase, ref Canceled);  //2012_10_09  this was passing in "lines" instead of "for_purchase", creating the po-for-stock-line problem
            if (Canceled)
                return false;
            if (pos == null)
                x.Show(this);
            else if (pos.Count == 0)
                x.Show(this);
            else
            {
                List<IItem> items = new List<IItem>();
                foreach (ordhed_purchase p in pos)
                {
                    if (result != null)
                        result.POs.Add(p);
                    if (((SysRz5)x.xSys).TheOrderLogic.DontShowConsignmentPOs() && p.ConsignmentOnlyIs(x))
                        continue;
                    items.Add(p);
                }
                x.TheLeader.ShowList(x, "POs from " + this.ToString(), items);
            }
            return !Canceled;

        }
        public List<orddet_line> DetailsListOnHold(ContextRz context)
        {
            return DetailsListStatus(context, Enums.OrderLineStatus.Hold);
        }
        protected override int GridColorCalc(Context x)
        {
            if (isvoid)
                return System.Drawing.Color.Gray.ToArgb();
            else if (onhold)
                return System.Drawing.Color.Red.ToArgb();
            else if (isclosed)
                return System.Drawing.Color.Blue.ToArgb();
            else
                return System.Drawing.Color.Green.ToArgb();
        }
        //public string GetCompletionList(ContextRz context, bool supress_msg = false)
        //{
        //    return context.TheSysRz.TheSalesLogic.GetCompletionList(context, this, supress_msg);
        //}
        //public List<orddet_line> InvoiceableLines(ContextRz context)
        //{
        //    StringBuilder sb
        //    List<orddet_line> ret = new List<orddet_line>();
        //    foreach (orddet_line l in DetailsList(context))
        //    {
        //        if( l.Invoiceable(context) )
        //            ret.Add(l);
        //    }
        //    return ret;
        //}
        public virtual bool PutAwayPossible(ContextRz context)
        {
            return true;
        }

        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeViewedBySalesOrder((ContextRz)context, this, context.xUser, this.base_company_uid);

        }


        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeEditedBySalesOrder((ContextRz)context, this, context.xUser);
        }

        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeDeletedBySalesOrder((ContextRz)context, this, context.xUser);
        }
        public override void DetailAddWithChecks(ContextNM context)
        {
            if (!((ContextRz)context).TheLeaderRz.IsWeb() && context.TheLeader.AskYesNo("Is the new line already on a purchase order?"))
            {
                List<orddet> lines = MakeLink((ContextRz)context, Rz5.Enums.OrderType.Purchase);
                foreach (orddet_line l in lines)
                {
                    l.needs_purchasing = true;
                    l.StockType = Enums.StockType.Stock;
                    l.Update(context);
                }
                return;
            }
            base.DetailAddWithChecks(context);
        }

        public override void DetailRefAdd(ContextRz x, orddet_line l)
        {
            base.DetailRefAdd(x, l);
            l.currency_name_price = currency_name;
            l.exchange_rate_price = exchange_rate;
        }



        //private bool GetGcatPartInfo(ContextRz context, out string strPartNumber, out string strMfg, out int intQty)
        //{

        //    strPartNumber = "";
        //    strMfg = "";
        //    intQty = 1;


        //    //Get the PartNumber   
        //    string promptPrefix = "Please provide ";
        //    string prompt = "the part number to be tested.";
        //    strPartNumber = Strings.SanitizeInput(context.Leader.AskForString(promptPrefix + prompt)).Trim().ToUpper();
        //    if (string.IsNullOrEmpty(strPartNumber))
        //    {
        //        context.Leader.Error(promptPrefix + prompt);
        //        return false;
        //    }

        //    //Get the Manufacturer
        //    prompt = "the manufacturer to be tested.";
        //    strMfg = Strings.SanitizeInput(context.Leader.AskForString(promptPrefix + prompt)).Trim().ToUpper();
        //    if (string.IsNullOrEmpty(strMfg))
        //    {
        //        context.Leader.Error(promptPrefix + prompt);
        //        return false;
        //    }

        //    ////Get the Qty
        //    //prompt = "the quantity to be tested.";
        //    //string strQty = Strings.SanitizeInput(context.Leader.AskForString(promptPrefix + prompt)).Trim().ToUpper();
        //    //int validQty;
        //    //if (!int.TryParse(strQty, out validQty))
        //    //{
        //    //    context.Leader.Error(strQty + " is not a valid quantity.");
        //    //    return false;
        //    //}

        //    return true;
        //}





        public void ReceiveDueDateSet(ContextRz context)
        {
            DateTime d = context.TheLeader.AskForDate("Receive date", DateTime.Now);
            if (!Tools.Dates.DateExists(d))
                return;

            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                l.receive_date_due = d;
                context.TheDelta.Update(context, l);
            }
        }
        public void ShipDueDateSet(ContextRz context)
        {
            DateTime d = context.TheLeader.AskForDate("Ship due date", DateTime.Now);
            if (!Tools.Dates.DateExists(d))
                return;

            ShipDueDateSet(context, d);
        }
        public virtual void ShipDueDateSet(ContextRz context, DateTime d)
        {
            List<orddet_line> linesToUpdate = new List<orddet_line>();

            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                switch (l.Status)
                {
                    case Enums.OrderLineStatus.Hold:
                    case Enums.OrderLineStatus.Open:
                    case Enums.OrderLineStatus.Packing:
                    case Enums.OrderLineStatus.Buy:
                        break;
                    default:
                        continue;
                }

                try
                {
                    l.ShipDueDateAcceptableCheck(context, d);
                }
                catch (Exception ex)
                {
                    context.Leader.Tell(ex.Message);
                    return;
                }

                linesToUpdate.Add(l);
            }

            foreach (orddet_line l in linesToUpdate)
            {
                l.SetShipDateDue(context, d);
            }

            //update after
            foreach (orddet_line l in linesToUpdate)
            {
                context.TheDelta.Update(context, l);
            }
        }
        //public void CustomerDockDateSet(ContextRz context)
        //{
        //    DateTime d = context.TheLeader.AskForDate("Customer dock date", DateTime.Now);
        //    if (!Tools.Dates.DateExists(d))
        //        return;

        //    foreach (orddet_line l in DetailsVar.RefsList(context))
        //    {
        //        context.TheSysRz.TheLineLogic.SetInitialLineDockDates(l, d);               
        //        context.TheDelta.Update(context, l);
        //    }
        //}
        public override List<orddet> DetailsListForPrint(ContextRz context, bool consolidate_if_possible, string template_name)
        {
            List<orddet> ret = base.DetailsListForPrint(context, consolidate_if_possible, template_name);

            if (Tools.Strings.HasString(template_name, "invoice") || Tools.Strings.HasString(template_name, "Sales Order"))
                context.TheSysRz.TheOrderLogic.CreditsAppend(context, this, ret);

            return ret;
        }

        public override void ApplyNewCurrency(ContextRz context, currency newCurrency)
        {
            base.ApplyNewCurrency(context, newCurrency);

            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (NewCurrencyApplicableToDetail(context, l))
                    l.ApplyNewCurrencyPrice(context, newCurrency);
            }
        }

        public override bool NewCurrencyApplicableToDetail(ContextRz context, orddet_line l)
        {
            return !l.was_shipped && !l.InvoiceHas;
        }

    }
    public class PartialInvoiceLineHandle
    {
        public orddet_line SaleLine = null;
        public int Quantity = 0;

        public PartialInvoiceLineHandle(orddet_line sale)
        {
            SaleLine = sale;
        }
    }

    public class SalesOrderCompleteResult
    {
        public bool Passed = false;
        public List<ordhed_purchase> POs = new List<ordhed_purchase>();

        public SalesOrderCompleteResult(bool passed)
        {
            Passed = passed;
        }
    }



}
