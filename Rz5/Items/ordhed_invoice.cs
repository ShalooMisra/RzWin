using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class ordhed_invoice : ordhed_invoice_auto
    {
        //Constructor
        public ordhed_invoice()
        {
            OrderType = Enums.OrderType.Invoice;
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;

            switch (args.ActionName.ToLower())
            {
                case "ship":
                    Ship(xrz);
                    break;
                case "sendasn":
                    xrz.Sys.TheOrderLogic.SendASN((ContextRz)args.TheContext, this);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public List<orddet_line> DetailsListShippable(ContextRz context, PossibleArgs possibleArgs)
        {
            return DetailsListClosable(context, CloseType.Ship, possibleArgs);
        }

        public void Ship(ContextRz context, int throwTestErrorOn = -1)
        {
            context.Sys.RecallLogAction(context, this, "ship");
            //Lots of updating and refreshign in this method.
            Close(context, CloseType.Ship, throwTestErrorOn);
            CheckCloseSalesOrder(context);
        }

        private void CheckCloseSalesOrder(ContextRz x)
        {
            ordhed_sales s = (ordhed_sales)GetRelatedSale(x);
            if (s == null)
                return;
            if (s.isclosed != true)
                s.Close(x, CloseType.Ship, 1);



        }

        public override void CalculateAllAmounts(ContextRz context)
        {
            base.CalculateAllAmounts(context);

            sub_total = 0;
            ordertotal = 0;
            //KT Per FT, need a total that only includes charges  
            invoicetotal = 0;

            double gp = 0;
            double net = 0;
            double credits = 0;
            double charges = 0;

            ArrayList chargesList = ((SysRz5)context.xSys).TheProfitLogic.GetInvoiceChargesList(context, unique_id);
            foreach (ordhit h in chargesList)
            {
                charges += h.hit_amount;
            }
            credits = ((SysRz5)context.xSys).TheProfitLogic.GetOrderCredits(context, new List<string>() { unique_id });
            double assignedCredits = ((SysRz5)context.xSys).TheProfitLogic.GetAssignedCompanyCredits(context, new List<string>() { unique_id });
            ArrayList deductionsList = ((SysRz5)context.xSys).TheProfitLogic.GetInvoiceCreditsList(context, unique_id);

            double nonprofit_credits = 0; //credits that do no deduct from profit.  I.e. credit belonging to ex-employee mistake that new employee should nto take a hit for.
            foreach (ordhit h in deductionsList)
            {
                //if (h.deduct_profit == true)
                //    credits += h.hit_amount;
                //else nonprofit_credits = h.hit_amount;
                if (h.deduct_profit != true)
                    nonprofit_credits = h.hit_amount;
            }


            double services = 0;
            costamount = 0;
            //KT 8-26-2015
            double deductions = 0;

            Double exchangedSubTotal = 0;

            foreach (orddet_line l in DetailsList(context))
            {
                if (l.Active)
                {

                    l.CalculateAmounts(context);
                    //When to include rma'd lines in totals?
                    //if (!l.was_rma)
                    //{
                    //    // sub_total += l.total_price;
                    //    //KT - 5-23-16 - FT reported rounding issue on Inv# 16030- adding an extra cent
                    //    //Not sure where this rounding ever came from?
                    //    // sub_total += System.Math.Ceiling(l.total_price * 100) / 100;
                    //    sub_total += l.total_price;
                    //}

                    sub_total += l.total_price;
                    services += l.service_cost;
                    gp += l.gross_profit;
                    net += l.net_profit;
                    costamount += l.total_cost;
                    exchangedSubTotal += l.total_price_exchanged;
                }
            }



            //Removed the two below roundings per FT Request on 8-28-2017
            ordertotal += (double)((decimal)sub_total - (decimal)deductions + (decimal)charges - (decimal)credits - (decimal)nonprofit_credits);// - (decimal)assignedCredits);
            //Sensible R
            ordertotal = Tools.Number.CommonSensibleRounding(ordertotal);


            //Deduct any Assigned Credits
            //if (assignedCredits > 0)
            //    ordertotal -= assignedCredits;

          

            gross_profit = gp;
            net_profit = net - services - credits;
            double amntPaid = AmountPaid(context);
            amntPaid = Tools.Number.CommonSensibleRounding(amntPaid);
            outstandingamount = ordertotal - amntPaid;
            //outstandingamount = invoicetotal - AmountPaid(context);
            DateTime? maxPaymentDate = context.SelectScalarDateTime("select Max(transdate) from checkpayment where base_ordhed_uid = '" + this.unique_id + "' group by unique_id");
            //Need to save Null to the Database for DateTime Sql Consistency, and to pass Prooflogic
            if (maxPaymentDate.Value.Year > 1900)
                payment_date = maxPaymentDate.Value;

            if (outstandingamount == 0)
                ispaid_Set(context, true);
            else
                ispaid_Set(context, false);

            profitamount = gp;
            ordertotal_exchanged = shippingamount_exchanged + handlingamount_exchanged + taxamount_exchanged + exchangedSubTotal;
        }

        public virtual bool CheckVerify(ContextRz context, List<string> missingProps)
        {
            return context.TheSysRz.TheSalesLogic.CheckVerify(context, this, missingProps);
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
                return Enums.OrderType.Invoice;
            }
            set
            {
                if (value != Enums.OrderType.Invoice)
                    throw new Exception("Order Type Error");
            }
        }

        //KT Refactored from Rz5 8-26-2015
        public override orddet GetNewDetail(ContextRz context)
        {
            orddet_line l = (orddet_line)DetailsVar.RefAddNew(context);
            l.shipvia_invoice = this.shipvia;
            return l;
        }

        public override void Inserting(Context x)
        {
            base.Inserting(x);
            ordertype = "Invoice";
        }

        public override void Updating(Context context)
        {
            CalculateCreditCardCharge((ContextRz)context);
            bool has_packing = false;
            bool has_blank = false;
            bool has_lines = false;
            bool has_preinvoice = false;
            orddet_line first = null;
            is_stock = false;
            foreach (orddet_line d in DetailsList((ContextRz)context))
            {
                d.Updating(context);

                if (d.StockType == Enums.StockType.Stock || d.StockType == Enums.StockType.Consign)
                    is_stock = true;
                if (d.Status == Rz5.Enums.OrderLineStatus.Packing)
                    has_packing = true;
                if (d.Status == Rz5.Enums.OrderLineStatus.PreInvoiced)
                    has_preinvoice = true;
                if (d.status == "")
                    has_blank = true;
                if (first == null)
                    first = d;
                if (d.Status != Enums.OrderLineStatus.PreInvoiced)
                    if (d.Status != Enums.OrderLineStatus.Shipped)
                        has_lines = false;
                    else
                        has_lines = true;
            }
            ChargesCalc((ContextRz)context);
            if (!has_blank)  //skip the status change for legacy lines
            {
                if (!isvoid)
                {
                    if (has_packing || !has_lines || has_preinvoice)
                        isclosed = false;
                    else
                        isclosed = true;
                }
            }
            base.Updating(context);
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
        public virtual void ChargesCalc(ContextNM context)
        {
            ChargesGatherFromLines(context);
        }

        public void ChargesGatherFromLines(ContextNM context)
        {
            //Dont understand this function. There are no entry areas on an invoice line item to add shipping/handling/tax information.
            //So after logging this info on the header, this function comes in and overwrites everything with zeros. - Joel
            return;

            Double s = 0;
            Double h = 0;
            Double t = 0;

            foreach (orddet_line d in DetailsVar.RefsGetAsItems(context).AllGet(context))
            {
                s += d.shipping_fee_invoice;
                h += d.charge1_fee_invoice;
                t += d.charge2_fee_invoice;
            }

            //this doesn't make sense; it already totals them by line
            //bool fc = false;

            //if (s > 0)
            shippingamount = s;
            //else if (shippingamount > 0)
            //{
            //    if (first != null)
            //    {
            //        first.shipping_fee_invoice = shippingamount;
            //        fc = true;
            //        shippingamount = 0;
            //    }
            //}

            //if (h > 0)
            handlingamount = h;
            //else if (handlingamount > 0)
            //{
            //    if (first != null)
            //    {
            //        first.charge1_fee_invoice = handlingamount;
            //        fc = true;
            //        handlingamount = 0;
            //    }
            //}

            //if (t > 0)
            taxamount = t;
            //else if (taxamount > 0)
            //{
            //    if (first != null)
            //    {
            //        first.charge2_fee_invoice = taxamount;
            //        fc = true;
            //        taxamount = 0;
            //    }
            //}

            //if (fc)
            //    first.IUpdate();
        }

        public List<orddet_line> PotentiallyShippableLines(ContextRz context)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (l.was_shipped)
                    continue;
                if (l.Status == Enums.OrderLineStatus.Void)
                    continue;
                ret.Add(l);
            }
            return ret;
        }

        public override void Closeable(ContextRz context, List<orddet_line> lines, CloseType closeType, PossibleArgs args)
        {
            int inventoryLineCount = InventoryLineCount(context);
            if (inventoryLineCount > 0)
            {
                if (!Tools.Strings.StrExt(billingaddress))
                    args.AddMessage(ToString() + " has no billing address");

                if (!Tools.Strings.StrExt(shippingaddress))
                    args.AddMessage(ToString() + " has no shipping address");

                if (!Tools.Strings.StrExt(shipvia))
                    args.AddMessage(ToString() + " has no shipvia");
            }

            if (!Tools.Strings.StrExt(terms))
                args.AddMessage(ToString() + " has no terms");

            base.Closeable(context, lines, closeType, args);
        }

        public override void AfterClose(ContextRz context, List<orddet_line> lines, CloseType closeType)
        {
            base.AfterClose(context, lines, closeType);

            this.ship_date_actual = DateTime.Now;
            this.dockdate = DateTime.Now;
            Update(context);

            ContextRz xTrans = (ContextRz)context.Clone();

            foreach (orddet_line l in lines)
            {
                if (!l.needs_post_ship)
                    continue;

                String tid = xTrans.BeginTran();
                try
                {
                    l.AfterShipInTrans(xTrans);
                    l.Update(xTrans);
                    xTrans.CommitTran(tid);
                }
                catch (Exception ex)
                {
                    context.Leader.Tell("The after close process failed.\r\n\r\n" + ex.Message);
                    context.Leader.CloseTabsByID(context, unique_id);
                    return;
                }
            }

            Update(context);

            ServiceDetailsAssign(context, lines);

            //update all of the sales and purchase orders involved
            Dictionary<String, ordhed_sales> SOsToUpdate = new Dictionary<string, ordhed_sales>();
            Dictionary<String, ordhed_purchase> POsToUpdate = new Dictionary<string, ordhed_purchase>();

            foreach (orddet_line l in lines)
            {
                if (Tools.Strings.StrExt(l.orderid_sales) && !SOsToUpdate.ContainsKey(l.orderid_sales))
                    SOsToUpdate.Add(l.orderid_sales, (ordhed_sales)l.SalesVar.RefGet(context));

                //KT Ok, here, RefSet has not happened on the new replacement line, therefore refGet returns ''
                if (Tools.Strings.StrExt(l.orderid_purchase) && !POsToUpdate.ContainsKey(l.orderid_purchase))
                    POsToUpdate.Add(l.orderid_purchase, (ordhed_purchase)l.PurchaseVar.RefGet(context));
            }

            foreach (KeyValuePair<String, ordhed_sales> k in SOsToUpdate)//This is where Sales Orders Get Closed
                context.Update(k.Value);

            foreach (KeyValuePair<String, ordhed_purchase> k in POsToUpdate)
                context.Update(k.Value);
        }

        protected override void PostExpensesToTransaction(ContextRz context)
        {
            PostExpenseToTransactionReceivable(context, "Outgoing Shipping", "Shipping", shippingamount);
            PostExpenseToTransactionReceivable(context, "Outgoing Handling", "Handling", handlingamount);
            PostExpenseToTransactionReceivable(context, "Outgoing Tax", "Tax", taxamount);
        }

        protected void ServiceDetailsAssign(ContextRz q, List<orddet_line> lines)
        {
            //check service detail assignments
            Dictionary<String, ordhed_service> linkedServices = new Dictionary<string, ordhed_service>();
            foreach (orddet_line l in lines)
            {
                if (l.OrderHas(Enums.OrderType.Service))
                {
                    ordhed_service s = (ordhed_service)l.ServiceVar.RefGet(q);
                    if (s != null)
                    {
                        if (!linkedServices.ContainsKey(s.unique_id))
                            linkedServices.Add(s.unique_id, s);
                    }
                }
            }

            foreach (KeyValuePair<String, ordhed_service> k in linkedServices)
            {
                k.Value.ServiceDetailsAssign(q);
            }
        }

        private void CalculateCreditCardCharge(ContextRz context)
        {
            if (context.Logic.CreditCardPercent <= 0)
                return;
            if (nTools.IsTermsCreditCard(terms))
            {
                Double dblTotal = SubTotal(context);
                handlingamount = Math.Round(dblTotal * (context.TheLogicRz.CreditCardPercent / 100), 2);
            }
        }


        //public List<orddet_line> DetailsListShippableComplete(ContextRz context)
        //{
        //    List<orddet_line> ret = new List<orddet_line>();
        //    foreach (orddet_line l in DetailsList(context))
        //    {
        //        if (l.ShippableComplete(context))
        //            ret.Add(l);
        //    }
        //    return ret;
        //}

        //public List<orddet_line> DetailsListShippablePartial(ContextRz context)
        //{
        //    List<orddet_line> ret = new List<orddet_line>();
        //    foreach (orddet_line l in DetailsList(context))
        //    {
        //        if (l.ShippablePartial(context))
        //            ret.Add(l);
        //    }
        //    return ret;
        //}
        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeViewedByInvoice((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeEditedByInvoice((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeDeletedByInvoice((ContextRz)context, this, context.xUser);
        }

        public ordhed_rma ProofRMACreate(ContextRz context)
        {
            RMASelectionResult sel = new RMASelectionResult();
            sel.NewRMA = true;
            sel.NewVRMA = false;
            sel.DoCustomerReplacement = false;
            sel.Quantity = DetailsVar.RefsList(context)[0].quantity;

            ordhed_rma rma = context.TheSysRz.TheLineLogic.RMA(context, DetailsVar.RefsList(context), this, sel);
            ordrma rmaData = rma.LinkedRMAGet(context);
            rmaData.planned_status = "return";
            rmaData.Update(context);
            return rma;
        }

        public void FakeFill(ContextRz context)
        {
            foreach (orddet_line l in DetailsList(context))
            {
                l.FakePackInvoice(context);
            }
        }

        public DateTime EarliestShipDateOtherwiseInvoiceDate(ContextRz context)
        {
            DateTime earliest = Tools.Dates.NullDate;
            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (Tools.Dates.DateExists(l.ship_date_actual))
                {
                    if (l.ship_date_actual < earliest || !Tools.Dates.DateExists(earliest))
                        earliest = l.ship_date_actual;
                }
            }

            if (!Tools.Dates.DateExists(earliest))
                earliest = orderdate;

            return earliest;
        }

        public override List<orddet> DetailsListForPrint(ContextRz context, bool consolidate_if_possible, string template_name)
        {
            List<orddet> ret = base.DetailsListForPrint(context, consolidate_if_possible, template_name);

            if (Tools.Strings.HasString(template_name, "invoice") || Tools.Strings.HasString(template_name, "Sales Order"))
                context.TheSysRz.TheOrderLogic.CreditsAppend(context, this, ret);

            return ret;
        }

        public virtual void SetShipDate(ContextRz context, DateTime newShipDate)
        {
            dockdate = newShipDate;
            Update(context);

            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                l.ship_date_actual = newShipDate;
                l.Update(context);
            }
        }

        protected override bool LineIsComplete(orddet_line l)
        {
            return l.was_shipped;
        }

    }


}
