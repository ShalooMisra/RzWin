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
    public partial class ordhed_rma : ordhed_rma_auto
    {
        //Constructor
        public ordhed_rma()
        {
            OrderType = Enums.OrderType.RMA;
        }

        public override void Inserting(Context x)
        {
            base.Inserting(x);
            ordertype = "RMA";
        }

        public override void Updating(Context x)
        {
            base.Updating(x);

            if (DetailsVar.Initialized)
            {
                int q = QuantityCount((ContextRz)x);

                if (q > 0)
                {
                    this.isclosed = (q == QuantityCountPutAwayRMA((ContextRz)x));
                }
                else
                    this.isclosed = false;
            }
        }

        public void PutAway(ContextRz context, int throwTestErrorOn = 1)
        {
            Close(context, CloseType.Receive, throwTestErrorOn);
        }

        public override void CalculateAllAmounts(ContextRz context)
        {
            base.CalculateAllAmounts(context);

            Double t = 0;
            Double subTotalExchanged = 0;
            foreach (orddet_line l in DetailsList(context))
            {
                l.CalculateAmounts(context);               
                t += l.unit_price_rma * l.quantity;
                subTotalExchanged += l.total_price_rma_exchanged;
            }

            sub_total = t;
            expenses = shippingamount + handlingamount + taxamount;
            t += expenses;
            //ordertotal = t;
            ordertotal = Tools.Number.CommonSensibleRounding(t);
            outstandingamount = ordertotal - AmountPaid(context);
            ordertotal_exchanged = subTotalExchanged + shippingamount_exchanged + handlingamount_exchanged + taxamount_exchanged;
        }

        public int QuantityCountPutAwayRMA(ContextRz context)
        {
            int ret = 0;
            foreach (orddet_line l in DetailsList(context))
            {
                // IF scrapped or quarantined, include in count to determine if it's closed
                if (l.status == Rz5.Enums.OrderLineStatus.Quarantined.ToString() || l.status == Rz5.Enums.OrderLineStatus.Scrapped.ToString())
                    ret += l.quantity;
                else if (l.was_rma_received && l.Status != Enums.OrderLineStatus.RMA_Receiving)
                    ret += l.quantity;
               
               
            }
            return ret;
        }

        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                //case "companydetails":
                //    ShowCompanyDetails();
                //    break;
                default:
                    base.HandleAction(args);
                    break;
            }
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
                return Enums.OrderType.RMA;
            }
            set
            {
                if (value != Enums.OrderType.RMA)
                    throw new Exception("Order Type Error");
            }
        }
        public override Double SubTotal(ContextRz context)
        {
            Double sub = 0;
            foreach (orddet_line l in DetailsList(context))
            {

                sub += l.total_price_rma;
            }
            return sub;
        }

        public override void AfterClose(ContextRz context, List<orddet_line> lines, CloseType type)
        {
            base.AfterClose(context, lines, type);
            this.receive_date_actual = DateTime.Now;
            this.dockdate = DateTime.Now;
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
        //        if (l.PutAwayableRMAComplete(context))
        //            ret.Add(l);
        //    }
        //    return ret;
        //}

        //public List<orddet_line> DetailsListPutAwayablePartial(ContextRz context)
        //{
        //    List<orddet_line> ret = new List<orddet_line>();
        //    foreach (orddet_line l in DetailsList(context))
        //    {
        //        if (l.PutAwayableRMAPartial(context))
        //            ret.Add(l);
        //    }
        //    return ret;
        //}

        //protected virtual void PutAwayPrepare(ContextRz context, List<orddet_line> lines)
        //{
        //    foreach (orddet_line l in lines)
        //    {
        //        context.Leader.CloseTabsByID(context, l.unique_id);
        //        l.PutAwayRMAPrepare(context);
        //    }
        //}

        //public void PutAway(ContextRz context)
        //{
        //    PutAway(context, DetailsListPutAwayable(context));
        //}

        //public void PutAway(ContextRz context, List<orddet_line> lines)
        //{
        //    PutAwayPrepare(context, lines);

        //    ContextRz xTrans = (ContextRz)context.Clone();
        //    foreach (orddet_line l in lines)
        //    {
        //        try
        //        {
        //            xTrans.BeginTran();
        //            l.PutAwayRMAInTrans(context);

        //            filled_total_Add(xTrans, l.total_price_rma);

        //            //slip all of the expenses in with the first successful line transaction
        //            if (context.Accounts.Enabled && !posted_expenses)
        //            {
        //                PostShippingToTransaction(xTrans);
        //                PostHandlingToTransaction(xTrans);
        //                PostTaxToTransaction(xTrans);

        //                posted_expenses = true;
        //                xTrans.Execute("update ordhed_purchase set posted_expenses = 1 where unique_id = '" + unique_id + "'");
        //            }

        //            xTrans.CommitTran();
        //        }
        //        catch (Exception ex)
        //        {
        //            context.Leader.Tell("The put-away process failed; the transactions will be rolled back and the RMA screen will be closed if it is open\r\n\r\n" + ex.Message);
        //            context.Leader.CloseTabsByID(context, unique_id);
        //        }
        //    }

        //    context.Update(this);

        //    //this is all handled in Updating
        //    //bool completed = true;
        //    //foreach (orddet_line l in DetailsList(context))
        //    //{
        //    //    if (l.was_rma_received)
        //    //        continue;
        //    //    completed = false;
        //    //    break;
        //    //}
        //    //if (completed)
        //    //{
        //    //    isclosed = true;
        //    //    context.Update(this);
        //    //}
        //}

        protected override void PostExpensesToTransaction(ContextRz context)
        {
            PostExpenseToTransactionPayable(context, "Incoming Shipping", "Shipping", shippingamount);
            PostExpenseToTransactionPayable(context, "Incoming Handling", "Handling", handlingamount);
            PostExpenseToTransactionPayable(context, "Incoming Tax", "Tax", taxamount);
        }

        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeViewedByRMA((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeEditedByRMA((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeDeletedByRMA((ContextRz)context, this, context.xUser);
        }

        public void FakeFill(ContextRz context)
        {
            foreach (orddet_line l in DetailsList(context))
            {
                l.FakeUnPackRMA(context);
            }
        }

        public override bool VoidPossible(ContextRz context, StringBuilder sb)
        {
            bool ret = base.VoidPossible(context, sb);

            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (l.was_rma_received)
                {
                    sb.AppendLine(l.ToString() + " has already been received");
                    ret = false;
                }
            }
            return ret;
        }

        protected override bool LineIsComplete(orddet_line l)
        {
            //return base.LineIsComplete(l);
            return l.was_rma_received;
        }
    }
}
