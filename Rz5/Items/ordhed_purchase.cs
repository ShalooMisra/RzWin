using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class ordhed_purchase : ordhed_purchase_auto
    {

        public VarRefMany<ordhed_purchase, profit_deduction> DeductionsVar;


        //Constructor
        public ordhed_purchase()
        {
            OrderType = Enums.OrderType.Purchase;
            DeductionsVar = new VarRefMany<ordhed_purchase, profit_deduction>(this, new CoreVarRefManyAttribute("Deductions", "ordhed_purchase", "profit_deduction", "Purchase", "purchase_order_uid"));




        }

        //Public Override Functions
        //Refactored from RzSensible 2-26-2015
        public override void CancelLines(ContextRz context, List<Rz5.orddet_line> lines)
        {
            foreach (orddet_line l in lines)
            {
                OrderLineCancelArgs args = new OrderLineCancelArgs(l);
                args.TypesToCancel.Add(this.OrderType);
                args.TypesToCancel.Add(Rz5.Enums.OrderType.Sales);
                l.Cancel(context, args);
            }
        }

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

        //End Refactor

        public override void HandleAction(ActArgs args)
        {

            switch (args.ActionName.ToLower())
            {

                case "reorder":
                    ReOrder((ContextRz)args.TheContext);
                    break;
                //case "re-close":
                //    {
                //        bool doReclose = false;

                //        //Check to see if these lines need to be tagged for received / put away, update if so
                //        CheckReceivedAndPutAway(x);

                //        //If all lines are OpenAndFilled, do clost
                //        if (ListOpenFilledLines((ContextRz)args.TheContext, CloseType.Receive).Count == 0)
                //        {
                //            //If this is Zero, it means that no lines are in a Closeable status, this could mean they are already closed as well.
                //            //The above method contains another method that checks if the lines are closed for order type
                //            //For Purchase orders, a line needs to be put_away OR was_received to be considered closed.
                //            doReclose = true;
                //        }
                //        else
                //        {
                //            //context.Leader.Tell("There are no lines to close");
                //            if (!args.TheContext.Leader.AskYesNo("There doesn't appear to be any closable lines.  Would you like to go through the lines and refresh the order status? (Click YES if you think this order's completion status is incorrect)."))
                //                return;
                //            else
                //            {
                //                if (AllLinesShippedOrScrapped((ContextRz)args.TheContext))
                //                    if (args.TheContext.Leader.AskYesNo("This order is not closed, yet all lines appear to be shipped or scrapped.  Should we close this PO and mark as received?  (Please be sure this is really the case, and contact IT if you aren't sure.)"))
                //                        doReclose = true;
                //            }

                //        }
                //        if (doReclose)
                //            ForceClosePurchaseOrder(x);

                //        break;
                //    }

                default:
                    base.HandleAction(args);
                    break;
            }
        }


        //private bool CheckIsOpenYetAllLinesShipped(ContextRz x)
        //{
        //    //KT Final Adding this else if to handle scenario where PO not Complete, yet all lines shipped
        //    //If we've reacehd this point then there are no putawayable lines.  
        //    //If all all lines shipped then ask user if they want top close PO and mark received.
        //    if (!isclosed)
        //    {
        //        if (AllLinesShipped(x))


        //    }
        //}


        public void PutAway(ContextRz context, int throwTestErrorOn = -1)
        {
            Close(context, CloseType.Receive, throwTestErrorOn);
        }

        public static ListArgs SearchArgsGet(ContextNM q, String search)
        {
            ListArgs ret = new ListArgs(q);
            ret.TheTable = "ordhed_purchase";
            ret.TheClass = "ordhed_purchase";
            ret.TheCaption = "Purchase Orders";
            ret.AddAllow = true;
            ret.AddCaption = "Add A New Purchase Order";
            ret.OptionsAllow = true;
            ret.TheLimit = 200;
            ret.TheTemplate = "Purchase Order Search";

            String match = " like '%" + q.Filter(search) + "%'";
            ret.TheWhere = " ( companyname " + match + " or primaryphone " + match + " or primaryfax " + match + " or primaryemailaddress " + match + " or ordernumber " + match + " or orderreference " + match + " or exists( select unique_id from orddet_purchase x where x.base_ordhed_uid = ordhed_purchase.unique_id and ( x.fullpartnumber " + match + " or x.description " + match + " ) ) )";

            return ret;
        }

        public override Rz5.orddet GetNewDetail(ContextRz context)
        {
            orddet_line l = (orddet_line)base.GetNewDetail(context);
            if (is_consign)
            {
                l.StockType = Rz5.Enums.StockType.Consign;
            }
            else
                l.StockType = Rz5.Enums.StockType.Stock;

            //skip list aquisition logic for consignment po:
            if (!is_consign)
                l.HandleListAquisitionAgent(context);

            l.lotnumber = this.lot_number;

            context.Update(l);
            return l;
        }


        public override Double SubTotal(ContextRz context)
        {
            Double sub = 0;
            foreach (orddet_line l in DetailsList(context))
            {

                sub += l.total_cost;
            }
            return sub;
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
                return Enums.OrderType.Purchase;
            }
            set
            {
                if (value != Enums.OrderType.Purchase)
                    throw new Exception("Order Type Error");
            }
        }

        public override void Inserting(Context x)
        {
            base.Inserting(x);
            ordertype = "Purchase";
        }


        //KT - 2-26-2015 - Refactored from RzSensible - original code block commented out below.

        public override void Updating(Context x)
        {

            List<profit_deduction> all = DeductionsVar.RefsList((Rz5.ContextRz)x);
            List<profit_deduction> assigned = new List<profit_deduction>();
            List<profit_deduction> unassigned = new List<profit_deduction>();
            orddet_line ll = null;
            foreach (orddet_line l in DetailsList((Rz5.ContextRz)x))
            {
                if (l.Status == Rz5.Enums.OrderLineStatus.Void)
                    continue;
                if (ll == null)
                    ll = l;
                foreach (profit_deduction p in l.DeductionsVar.RefsList((Rz5.ContextRz)x))
                {
                    if (all.Contains(p))
                        assigned.Add(p);
                }


            }
            foreach (profit_deduction p in all)
            {
                if (assigned.Contains(p))
                    continue;
                unassigned.Add(p);
            }
            if (ll != null)
            {
                foreach (profit_deduction p in unassigned)
                {
                    ll.DeductionsVar.RefsAdd(x, p);
                    //KT - Tag the linecodes to the deduction
                    p.linecode_sales = ll.linecode_sales;
                    p.linecode_purchase = ll.linecode_purchase;
                    p.Update(x);
                }
            }
            base.Updating(x);

        }
        //public override void Updating(Context x)
        //{
        //    total_quantity = 0;
        //    bool not_received = false;
        //    int lines = 0;
        //    bool allQB = true;
        //    foreach (orddet_line d in DetailsList((ContextRz)x))
        //    {
        //        total_quantity += d.quantity;//sum of the quantityordered of the details
        //        if (d.Status != Enums.OrderLineStatus.Void && (!d.was_received || d.Status == Enums.OrderLineStatus.Buy))
        //            not_received = true;

        //        if (!d.qb_sent_purchase)
        //            allQB = false;

        //        bool changeFlag = false;

        //        if (d.vendor_name != companyname)
        //        {
        //            d.vendor_name = companyname;
        //            changeFlag = true;
        //        }

        //        if(d.vendor_uid != base_company_uid)
        //        {
        //            d.vendor_uid = base_company_uid;
        //            changeFlag = true;
        //        }

        //        if(d.vendor_contact_name != contactname)
        //        {                
        //            d.vendor_contact_name = contactname;
        //            changeFlag = true;
        //        }

        //        if(d.vendor_contact_uid != base_companycontact_uid)
        //        { 
        //            d.vendor_contact_uid = base_companycontact_uid;
        //            changeFlag = true;
        //        }

        //        if (!Tools.Strings.StrCmp(d.buyer_name, agentname))
        //        {
        //            if (!d.BuyerVar.Initialized)
        //            {
        //                d.buyer_uid = base_mc_user_uid;
        //                d.buyer_name = agentname;
        //            }
        //            else
        //            {
        //                Context xx = x.Clone();
        //                xx.TheDelta = new Delta(xx);
        //                xx.TheDelta.StartChangeCache();
        //                d.BuyerVar.RefSet(xx, AgentVar.RefGet(x));
        //            }

        //            changeFlag = true;
        //        }

        //        if( changeFlag )
        //            d.Update(x, inhibit_notify: true);

        //        lines++;
        //    }

        //    isclosed = (lines > 0 && !not_received);
        //    is_received = isclosed;

        //    if (lines > 0 && allQB)
        //        senttoqb = true;

        //    if (shipped_quantity >= total_quantity)
        //        shipped_complete = true;

        //    base.Updating(x);
        //}

        protected override int GridColorCalc(Context x)
        {
            if (isvoid)
                return Color.Gray.ToArgb();
            else if (isclosed)
                return Color.Blue.ToArgb();
            else
                return Color.Green.ToArgb();
        }

        public bool ConsignmentOnlyIs(ContextRz x)
        {
            //if (AllDetails.Count == 0)
            //    return false;

            foreach (orddet d in DetailsList(x))
            {
                if (d.StockType != Enums.StockType.Consign)
                    return false;
            }

            return true;
        }

        public List<orddet_line> DetailsListPutAwayable(ContextRz context)
        {
            return DetailsListClosable(context, CloseType.Receive, new PossibleArgs());
        }

        //public List<orddet_line> DetailsListPutAwayableComplete(ContextRz context)
        //{
        //    List<orddet_line> ret = new List<orddet_line>();
        //    foreach (orddet_line l in DetailsList(context))
        //    {
        //        if (l.PutAwayableComplete(context))
        //            ret.Add(l);
        //    }
        //    return ret;
        //}

        //public List<orddet_line> DetailsListPutAwayablePartial(ContextRz context)
        //{
        //    List<orddet_line> ret = new List<orddet_line>();
        //    foreach (orddet_line l in DetailsList(context))
        //    {
        //        if (l.PutAwayablePartial(context))
        //            ret.Add(l);
        //    }
        //    return ret;
        //}

        //KT - Refactored from Rz5, replaced existing (commented out below). 2-26-2015
        public override void CalculateAllAmounts(Rz5.ContextRz context)
        {
            base.CalculateAllAmounts(context);
            Double cost = 0;
            //KT - Company Credits

            foreach (orddet_line l in DetailsList(context))
            {
                l.CalculateAmounts(context);
                if (!l.was_vendrma)
                    cost += l.total_cost;
            }
            sub_total = cost;
            expenses = shippingamount + handlingamount + taxamount;
            foreach (profit_deduction p in DeductionsVar.RefsList(context))
            {
                if (p.include_on_po)
                    expenses += p.amount;
            }

            credit_amount = context.SelectScalarDouble("select SUM(creditamount) from companycredit where applied_to_order_uid = '" + this.unique_id + "'");
            //credit_amount = 0;
            //foreach (companycredit c in CompanyCreditVar.RefsList(context))
            //{
            //    if (c.applied_to_order_uid == this.unique_id)
            //        credit_amount += c.creditamount;
            //}
            //KT - This is the part that gets the companycredit to factor into the total for the order (including printables, etc.)
            //cost += expenses;
            //KT Get company Credits to show on viewheader_purchase
            creditamount = credit_amount;
            cost += expenses - credit_amount;
            //ordertotal = Math.Round(cost, 2);            
            //ordertotal = Math.Round(cost, 2);
            ordertotal = Tools.Number.CommonSensibleRounding(cost);
            outstandingamount = ordertotal - AmountPaid(context);

            //KT 9-6-2016 - So I have no idea where/ how ispaid is getting set on Purchase Orders, but it certainly appears to be.  This is a workaround to set it as appropriate on load / save.
            if (outstandingamount == 0 && ispaid == false)
            {
                ispaid_Set(context, true);
                //KT 10-11-2016 - Holy Cow this was terrible.  This was making PO creation impossible (3 months later ...) When creating a PO, this was getting fired before the insert could complete, and therefore there was nothing to update.
                //context.Update(this);

            }

            else if (outstandingamount != 0 && ispaid == true)
            {
                ispaid_Set(context, false);
                //KT 10-11-2016 - Holy Cow this was terrible.  This was making PO creation impossible (3 months later ...) When creating a PO, this was getting fired before the insert could complete, and therefore there was nothing to update.
                //context.Update(this);
            }

        }



        public bool PostBillPossible(ContextRz context)
        {
            if (posted_expenses)
                return false;  //already posted

            if (ordertotal == 0)
                return false;

            PossibleArgs args = new PossibleArgs();
            Closeable(context, DetailsVar.RefsList(context), CloseType.Receive, args);
            return args.Possible;
        }

        //public override void Closeable(ContextRz context, CloseType type, List<orddet_line> lines, PossibleArgs args)
        //{
        //    if (CompanyVar.RefGet(context) == null)
        //    {
        //        args.LogAdd("No vendor is selected");
        //        args.Possible = false;
        //    }

        //    foreach (orddet_line l in lines)
        //    {
        //        l.PutAwayable(context, args, false);
        //    }
        //    return args;
        //}

        //protected virtual void PutAwayPrepare(ContextRz context, List<orddet_line> lines)
        //{
        //    foreach (orddet_line l in lines)
        //    {
        //        context.Leader.CloseTabsByID(context, l.unique_id);
        //        l.PutAwayPrepare(context);
        //    }
        //}

        protected virtual void CheckForFilledSales(ContextRz context, List<orddet_line> lines)
        {
            Dictionary<String, ordhed_sales> sales = new Dictionary<string, ordhed_sales>();
            foreach (orddet_line l in lines)
            {
                if (Tools.Strings.StrExt(l.orderid_sales) && !l.was_invoice)
                {
                    if (!sales.ContainsKey(l.orderid_sales))
                    {
                        ordhed_sales sale = (ordhed_sales)context.TheLeader.ItemShownByTag(context, new ItemTag("ordhed_sales", l.orderid_sales));
                        if (sale == null)
                            sale = (ordhed_sales)l.SalesVar.RefGet(context);

                        if (sale != null)
                        {
                            if (sale.IsCompletelyReceived(context))
                            {
                                sales.Add(sale.unique_id, sale);
                            }
                        }
                    }
                }
            }

            if (sales.Count > 0)
            {
                if (context.TheLeader.SuggestYesNo("Completely received: " + Tools.Strings.PluralizePhrase("sales order", sales.Count) + ".  Do you want to create invoices?"))
                {
                    List<ordhed_invoice> invoices = new List<ordhed_invoice>();
                    foreach (KeyValuePair<String, ordhed_sales> k in sales)
                    {
                        List<ordhed_invoice> ret = k.Value.MakeInvoiceWithChecks(context);
                        if (ret != null)
                        {
                            foreach (ordhed_invoice i in ret)
                            {
                                invoices.Add(i);
                            }
                        }
                    }

                    foreach (ordhed_invoice i in invoices)
                    {
                        context.Show(i);
                    }
                }
            }
        }

        public override void AfterClose(ContextRz context, List<orddet_line> lines, CloseType closeType)
        {
            base.AfterClose(context, lines, closeType);
            this.receive_date_actual = DateTime.Now;
            this.dockdate = DateTime.Now;
            Update(context);

            ContextRz xTrans = (ContextRz)context.Clone();

            foreach (orddet_line l in lines)
            {
                //this is the switch the allows both transactions, the put away and the after stuff, to be tracked separately
                //maybe on save if the PO sees any lines that still have this flag it should just run the process?
                //since that can only happen when there's an interruption after the put away trans and before or during the after trans

                if (!l.needs_post_put_away)
                    continue;

                String tid = xTrans.BeginTran();
                try
                {
                    l.AfterPutAwayInTrans(xTrans);
                    l.Update(xTrans);
                    xTrans.CommitTran(tid);

                }
                catch (Exception ex)
                {
                    context.Leader.Tell("The after put-away process failed.\r\n\r\n" + ex.Message);
                    context.Leader.CloseTabsByID(context, unique_id);
                    return;
                }
            }

            Update(context);

            if (!context.xUser.IsDeveloper())
                CheckForFilledSales(context, lines);
        }

        protected override void PostExpensesToTransaction(ContextRz context)
        {
            PostExpenseToTransactionPayable(context, "Incoming Shipping", "Shipping", shippingamount);
            PostExpenseToTransactionPayable(context, "Incoming Handling", "Handling", handlingamount);
            PostExpenseToTransactionPayable(context, "Incoming Tax", "Tax", taxamount);
        }

        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return ((Rz5.PermitLogic)(context.xSys).ThePermitLogic).CanBeViewedByPurchaseOrder((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return ((Rz5.PermitLogic)(context.xSys).ThePermitLogic).CanBeEditedByPurchaseOrder((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return ((Rz5.PermitLogic)(context.xSys).ThePermitLogic).CanBeDeletedByPurchaseOrder((ContextRz)context, this, context.xUser);
        }

        public virtual ordhed_vendrma MakeVendorRMAHeader(ContextRz x, orddet_line sale_line, bool expectVendorReplacement)  //the sale line is passed in here for the consignment setting; the actual line adding needs to happen where this is called from
        {
            if (!x.xUser.CheckPermit(x, "Order:Create:Can Make VendRMA"))
            {
                x.TheLeader.ShowNoRight();
                return null;
            }
            ordhed_vendrma xVRMA = (ordhed_vendrma)GetNewOrderHeader(x, Enums.OrderType.VendRMA);
            xVRMA.shippingname = "";
            xVRMA.shippingaddress = "";
            xVRMA.currency_name = currency_name;

            //xVRMA.exchange_rate = exchange_rate;

            if (x.Accounts.IsBaseCurrency(currency_name))
            {
                xVRMA.exchange_rate = 1;
            }
            else
            {
                currency curr = x.Accounts.GetCurrency(x, currency_name);
                if (curr == null)
                    throw new Exception("The PO currency " + currency_name + " could not be found");

                xVRMA.exchange_rate = curr.exchange_rate;
            }

            if (is_consign)
            {
                xVRMA.is_consign = true;
                xVRMA.lot_number = lot_number;
            }
            else
            {
                if (sale_line.StockType == Rz5.Enums.StockType.Consign)
                {
                    xVRMA.is_consign = true;
                    xVRMA.lot_number = sale_line.lotnumber;
                }
            }

            if (expectVendorReplacement)
                xVRMA.action_taken = "Replace";
            else
                xVRMA.action_taken = "Credit";

            x.Update(xVRMA);
            x.TheSysRz.TheOrderLogic.Link2Orders(x, this, xVRMA);
            return xVRMA;
        }

        public ordhed_vendrma VendRMACreate(ContextRz context)
        {
            RMASelectionResult res = new RMASelectionResult();
            res.NewVRMA = true;
            res.DoVendorReplacement = false;
            res.Quantity = DetailsVar.RefsList(context)[0].quantity;
            return context.TheSysRz.TheLineLogic.VendRMA(context, DetailsVar.RefsList(context), res);
        }

        public void FakeFill(ContextRz context)
        {
            foreach (orddet_line l in DetailsList(context))
            {
                l.FakeUnPackPurchase(context);
                context.Update(l);
            }
        }

        public void FakeFillPartial(ContextRz context)
        {
            foreach (orddet_line l in DetailsList(context))
            {
                int fake = l.quantity / 2;
                if (fake <= 0)
                    fake = 1;

                l.FakeUnPackPurchase(context, 1);
                context.Update(l);
            }
        }

        public override bool CanAssignCompany(ContextRz context, company c)
        {
            if (!base.CanAssignCompany(context, c))
                return false;
            string msg = "";
            if (!c.VendorApprovedCheck((ContextRz)context, ref msg))
                return false;

            return true;
        }

        //public override void SendToQB(ContextRz context, bool confirm = true, bool showComments = true)
        //{
        //    //if (LinesForQB(context, mergeOK: true).Count == 0)
        //    //{
        //    //    context.TheLeader.Error(ToString() + " has no lines ready to send to QB");
        //    //    return;
        //    //}

        //    base.SendToQB(context);
        //}

        public bool FullyReceived(ContextRz context)
        {
            foreach (orddet_line l in DetailsList(context))
            {
                if (!l.was_received)
                    return false;
            }

            return true;
        }

        public override bool ShouldSendToQB(ContextRz context)
        {
            //return base.ShouldSendToQB(args);
            return (LinesForQB(context, mergeOK: true).Count > 0);
        }

        public virtual List<orddet_line> LinesForQB(ContextRz context, bool mergeOK = false)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (l.was_received && !l.qb_sent_purchase)
                    ret.Add(l);
            }
            return ret;
        }

        public override void MarkSentToQB(ContextRz context)
        {
            base.MarkSentToQB(context);
            foreach (orddet_line l in LinesForQB(context, mergeOK: false))
            {
                l.qb_sent_purchase = true;
                context.TheDelta.Update(context, l);
            }
        }

        public override void DetailRefAdd(ContextRz x, orddet_line l)
        {
            base.DetailRefAdd(x, l);
            //also in beforeupdate
            l.vendor_name = companyname;
            l.vendor_uid = base_company_uid;
            l.vendor_contact_name = contactname;
            l.vendor_contact_uid = base_companycontact_uid;
            x.TheSysRz.TheOrderLogic.AfterLineAddedPurchase((ContextRz)x, l);

            l.currency_name_cost = currency_name;
            l.exchange_rate_cost = exchange_rate;
            l.is_consumption = is_consumption;
        }



        public bool SendPurchaseOrderToQuickbooks(ContextRz xrz)
        {
            return xrz.TheSysRz.TheQuickBooksLogic.SendOrder(xrz, this);
        }


        public ordhed_purchase ReOrder(ContextRz x)
        {
            ordhed_purchase xOrder = (ordhed_purchase)ordhed.CreateNew(x, Rz5.Enums.OrderType.Purchase);
            xOrder.companyname = this.companyname;
            xOrder.base_company_uid = this.base_company_uid;
            xOrder.contactname = this.contactname;
            xOrder.base_companycontact_uid = this.base_companycontact_uid;
            xOrder.primaryphone = this.primaryphone;
            xOrder.primaryfax = this.primaryfax;
            xOrder.primaryemailaddress = this.primaryemailaddress;
            xOrder.shippingaddress = this.shippingaddress;
            xOrder.billingaddress = this.billingaddress;
            xOrder.billingname = this.billingname;
            xOrder.shippingname = this.shippingname;
            x.Update(xOrder);

            //at least copy the line info over for them
            foreach (orddet_line sd in DetailsVar.RefsList(x))
            {
                orddet_line p = xOrder.DetailsVar.RefAddNew(x);
                p.fullpartnumber = sd.fullpartnumber;
                p.manufacturer = sd.manufacturer;
                p.datecode = sd.datecode;
                p.quantity = sd.quantity;
                p.Status = Enums.OrderLineStatus.Buy;
                x.Update(p);

                x.TheDelta.Update(x, p);
            }

            return xOrder;
        }

        public override bool VoidPossible(ContextRz context, StringBuilder sb)
        {
            bool ret = base.VoidPossible(context, sb);

            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (l.was_received)
                {
                    sb.AppendLine(l.ToString() + " has already been received");
                    ret = false;
                }
            }
            return ret;
        }

        public override void AbsorbCompany(ContextRz context, company xCompany)
        {

            String shippingNameHold = shippingname;
            base.AbsorbCompany(context, xCompany);
            //KT Removed this, as it interferes with my new PO logic supporting alternate ship-to's.
            //shippingname = shippingNameHold;
        }

        public override void ApplyNewCurrency(ContextRz context, currency newCurrency)
        {
            base.ApplyNewCurrency(context, newCurrency);

            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (NewCurrencyApplicableToDetail(context, l))
                    l.ApplyNewCurrencyCost(context, newCurrency);
            }
        }

        public override bool NewCurrencyApplicableToDetail(ContextRz context, orddet_line l)
        {
            return !l.was_received;
        }

        protected override bool LineIsComplete(orddet_line l)
        {
            //return base.LineIsComplete(l);
            return l.was_received || l.put_away;
        }

        public override string FriendlyOrderType
        {
            get
            {
                if (is_credit_card)
                    return "Credit Card";
                else if (is_bill)
                    return "Bill";
                else
                    return base.FriendlyOrderType;
            }
        }
    }
}
