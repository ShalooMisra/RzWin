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
    public partial class ordhed_vendrma : ordhed_vendrma_auto
    {
        public ordhed_vendrma()
        {
            OrderType = Enums.OrderType.VendRMA;
        }

        public void Ship(ContextRz context, int throwTestErrorOn = -1)
        {
            Close(context, CloseType.Ship, throwTestErrorOn);
        }

        public override void Updating(Context x)
        {
            //this.DetailsVar.Init(x);    
            if (DetailsVar.Initialized)
            {
                bool has_details = false;
                bool has_open = false;

                foreach (orddet_line l in DetailsVar.RefsList(x))
                {
                    has_details = true;

                    switch (l.Status)
                    {
                        case Enums.OrderLineStatus.Void:
                        case Enums.OrderLineStatus.Vendor_RMA_Shipped:
                        //MAke Destroys and Quarantines closed
                        case Enums.OrderLineStatus.Quarantined:
                        case Enums.OrderLineStatus.Scrapped:
                            break;
                        default:
                            has_open = true;
                            break;
                    }
                }

                if (has_details && !has_open)
                    isclosed = true;
                else if (has_details && has_open)
                    isclosed = false;                
            }

            base.Updating(x);
        }

        public override void CalculateAllAmounts(ContextRz context)
        {
            base.CalculateAllAmounts(context);

            Double t = 0;
            Double subTotalExchanged = 0;            
            foreach (orddet_line l in DetailsList(context))
            {
                l.CalculateAmounts(context);
                t += l.total_price_vendrma;

                subTotalExchanged += l.total_price_vendrma_exchanged;
            }

            sub_total = t;
            //expenses = shippingamount + handlingamount + taxamount;
            expenses = context.Sys.TheProfitLogic.GetOrderCharges(context, unique_id);
            t += expenses;
            ordertotal = ordertotal = Tools.Number.CommonSensibleRounding(t);
            outstandingamount = ordertotal - AmountPaid(context);
            ordertotal_exchanged = subTotalExchanged + shippingamount_exchanged + handlingamount_exchanged + taxamount_exchanged;                       
        }
        
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                //case "companydetails":
                //    ShowCompanyDetails();
                //    break;
                case "makepos":
                case "reorderpo":
                case "makepo":
                case "newdocs_purchase":
                    args.TheContext.Show(RerderPO((ContextRz)args.TheContext));
                    args.ShouldClose = true;
                    break;
                case "sendasn":
                    ((ContextRz)args.TheContext).TheSysRz.TheOrderLogic.SendASN((ContextRz)args.TheContext, this);
                    break;
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
                return Enums.OrderType.VendRMA;
            }
            set
            {
                if (value != Enums.OrderType.VendRMA)
                    throw new Exception("Order Type Error");
            }
        }

        public override void Inserting(Context x)
        {
            base.Inserting(x);
            ordertype = "VendRMA";
        }
        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeViewedByVRMA((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeEditedByVRMA((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeDeletedByVRMA((ContextRz)context, this, context.xUser);
        }
        public override Double SubTotal(ContextRz context)
        {
            Double sub = 0;
            foreach (orddet_line l in DetailsList(context))
            {

                sub += l.total_price_vendrma;
            }
            return sub;
        }

       
       
        public List<orddet_line> DetailsListShippable(ContextRz context)
        {
            return DetailsListClosable(context, CloseType.Ship, new PossibleArgs());
        }

        //public List<orddet_line> DetailsListShippableComplete(ContextRz context)
        //{
        //    List<orddet_line> ret = new List<orddet_line>();
        //    foreach (orddet_line l in DetailsList(context))
        //    {
        //        if (l.ShippableVendRMAComplete(context))
        //            ret.Add(l);
        //    }
        //    return ret;
        //}

        //public List<orddet_line> DetailsListShippablePartial(ContextRz context)
        //{
        //    List<orddet_line> ret = new List<orddet_line>();
        //    foreach (orddet_line l in DetailsList(context))
        //    {
        //        if (l.ShippableVendRMAPartial(context))
        //            ret.Add(l);
        //    }
        //    return ret;
        //}

        public override void AfterClose(ContextRz context, List<orddet_line> lines, CloseType type)
        {
            base.AfterClose(context, lines, type);
            this.ship_date_actual = DateTime.Now;
            this.dockdate = DateTime.Now;
        }

        protected override void PostExpensesToTransaction(ContextRz context)
        {
            PostExpenseToTransactionReceivable(context, "Outgoing Shipping", "Shipping", shippingamount);
            PostExpenseToTransactionReceivable(context, "Outgoing Handling", "Handling", handlingamount);
            PostExpenseToTransactionReceivable(context, "Outgoing Tax", "Tax", taxamount);
        }

        public void FakeFill(ContextRz context)
        {
            foreach (orddet_line l in DetailsList(context))
            {
                l.FakePackVendRMA(context);
            }
        }

        public ordhed_purchase RerderPO(ContextRz x)
        {
            ordhed_sales xSales = null;
            ordhed_purchase xPurchase = GetLinkedPurchase(x);
            if (xPurchase != null)
                xSales = xPurchase.GetLinkedSalesOrder(x);
            
            //ordhed xOrder = this.GetNewOrder(Enums.OrderType.Purchase);  //this incorrectly maintained the same stock link.  if it happened to be to a stock line, for instance, the user couldn't then set the cost.
            //instead, just make a new PO and let them enter a new line normally
            
            ordhed_purchase xOrder = (ordhed_purchase)ordhed.CreateNew(x, Rz5.Enums.OrderType.Purchase);
            xOrder.companyname = xPurchase.companyname;
            xOrder.base_company_uid = xPurchase.base_company_uid;
            xOrder.contactname = xPurchase.contactname;
            xOrder.base_companycontact_uid = xPurchase.base_companycontact_uid;
            xOrder.primaryphone = xPurchase.primaryphone;
            xOrder.primaryfax = xPurchase.primaryfax;
            xOrder.primaryemailaddress = xPurchase.primaryemailaddress;
            xOrder.shippingaddress = xPurchase.shippingaddress;
            xOrder.billingaddress = xPurchase.billingaddress;
            xOrder.billingname = xPurchase.billingname;
            xOrder.shippingname = xPurchase.shippingname;
            x.Update(xOrder);
            if (xSales == null)
            {
                x.TheLeader.Tell("The original sales order in this transaction could not be located.  Please check the order and manually create the needed links.");
                x.Show(xOrder);
                return xOrder;
            }

            xSales.WaitingForReOrder = true;
            x.Update(xSales);

            x.TheSysRz.TheOrderLogic.Link2Orders(x, xSales, xOrder);

            if (xPurchase != null)
            {
                xPurchase.packinginfo = "Vendor RMA";
                x.Update(xPurchase);
            }

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

                if (xSales != null)
                    xSales.DetailsVar.RefsAdd(x, p);
                    
                x.TheDelta.Update(x, p);
            }

            if( xSales != null )
                x.TheDelta.Update(x, xSales);

            return xOrder;
        }

        public override bool VoidPossible(ContextRz context, StringBuilder sb)
        {
            bool ret = base.VoidPossible(context, sb);

            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (l.was_vendrma_shipped)
                {
                    sb.AppendLine(l.ToString() + " has already been shipped");
                    ret = false;
                }
            }
            return ret;
        }

        protected override bool LineIsComplete(orddet_line l)
        {
            //return base.LineIsComplete(l);
            return l.was_vendrma_shipped;
        }
    }
}
