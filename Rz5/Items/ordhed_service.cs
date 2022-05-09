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
    public partial class ordhed_service : ordhed_service_auto
    {
        //Constructor
        public ordhed_service()
        {
            OrderType = Enums.OrderType.Service;
            ServiceLines = new VarRefServiceLinesHeader(this);
        }
        public override void Inserting(Context x)
        {
            base.Inserting(x);
            ordertype = "Service";
            showonwarehouse = true;
        }
        public override void Updating(Context x)
        {
            bool has_open = false;
            bool has = false;
            bool allQB = true;

            foreach (orddet_line l in DetailsVar.RefsList(x))
            {
                if (!l.was_service_in)
                    has_open = true;
                if (!l.qb_sent_service)
                    allQB = false;

                has = true;
            }

            if (has && allQB)
                senttoqb = true;

            isclosed = (has && !has_open);

            //Override the previious if drop-ship conditions met            
            if (!isclosed)
                isclosed = OrderLogic.CheckCloseDropShip(x, this);


            if (!has)
                onhold = true;
            else
                onhold = false;
            base.Updating(x);
        }
        public override Var VarGetByName(string name)
        {
            switch (name.ToLower().Trim())
            {
                case "servicelines":
                    return ServiceLines;
                default:
                    return base.VarGetByName(name);
            }
        }
        protected override int GridColorCalc(Context x)
        {
            if (isvoid)
                return Color.Gray.ToArgb();
            else if (isclosed)
                return Color.Blue.ToArgb();
            else
                return Color.Green.ToArgb();
        }
        public override void CalculateAllAmounts(ContextRz context)
        {
            base.CalculateAllAmounts(context);
            foreach (orddet_line l in DetailsList(context))
            {
                l.CalculateAmounts(context);
            }

            Double cost = CalculateTotalServiceAmount(context);



            creditamount = context.SelectScalarDouble("select SUM(creditamount) from companycredit where applied_to_order_uid = '" + this.unique_id + "'");
            //creditamount = 0;
            //foreach (companycredit c in CompanyCreditVar.RefsList(context))
            //{
            //    if (c.applied_to_order_uid == this.unique_id)
            //        creditamount += c.creditamount;
            //}

            sub_total = cost;
            expenses = shippingamount + handlingamount + taxamount;
            cost += expenses;
            ordertotal = cost - creditamount;
            ordertotal = Tools.Number.CommonSensibleRounding(ordertotal);
        }
        protected virtual Double CalculateTotalServiceAmount(ContextRz context)
        {
            Double ret = 0;
            foreach (service_line sl in ServiceLines.RefsList(context))
            {
                ret += sl.total_cost;
            }
            return ret;
        }


        public override bool TransmitPossible(ContextRz context, Enums.TransmitType ttype, List<string> ignoredPropertiesList)
        {

            if (!base.TransmitPossible(context, ttype, new List<string>() { "no stock type" }))//Allow print & email of TBD  
                return false;

            //StringBuilder sb = new StringBuilder();
            //List<string> missingProps = new List<string>();
            //if (!CheckVerify(context, missingProps))
            //{
            //    string msg = "";
            //    foreach (string s in missingProps)
            //        msg += s + Environment.NewLine;
            //    //context.TheLeader.Error(missingProps);
            //    return false;
            //}

            return true;
        }




        public override List<orddet> DetailsListForPrint(ContextRz context, bool consolidate_if_possible, string template_name)
        {
            List<orddet> ret = new List<orddet>();
            foreach (service_line sl in ServiceLines.RefsList(context))
            {
                ret.Add(ServiceLineCreateForPrint(context, sl));
            }
            return ret;
        }
        protected virtual orddet_line ServiceLineCreateForPrint(ContextRz context, service_line sl)
        {
            orddet_line l = null;
            try { l = (orddet_line)DetailsList(context)[0]; }
            catch { }
            orddet_line ol = orddet_line.New(context);
            ol.unique_id = "not_an_id";
            //KT Looks like they are manually calling fullpartnumber the service name, so I'll call internalcomment service_notes
            ol.fullpartnumber = sl.service_name;
            ol.internalcomment = sl.service_notes;
            ol.quantity = sl.quantity;
            ol.service_cost = sl.total_cost;
            ol.unit_cost = sl.unit_cost;
            if (l != null)
                ol.ship_date_service_due = l.ship_date_service_due;
            return ol;
        }
        public VarRefServiceLinesHeader ServiceLines;
        public ListArgs ServicesArgsGet(ContextRz context)
        {
            ListArgs ret = new ListArgs(context);
            ret.TheCaption = "Services";
            ret.AddAllow = true;
            ret.AddCaption = "Add A Service";
            ret.LiveItems = ServiceLines.RefsGet(context);
            ret.TheTemplate = "servicelines";
            ret.TheClass = "service_line";
            return ret;
        }
        //KT Refactored from RzSensible.ordhed_service 2-25-2015
        public void ServiceDetailsAssign(ContextRz context)
        {
            //assign all of the services to the earliest shipped line
            Rz5.orddet_line earliest = EarliestShippedLine(context);
            if (earliest != null)
            {
                foreach (Rz5.service_line sl in ServiceLines.RefsList(context))
                {
                    //invoke the related orddet_line
                    Rz5.orddet_line current = (Rz5.orddet_line)sl.TheLine.RefGet(context);
                    //If that orddet_line exists
                    if (current != null)
                    {
                        //remove each service line from refs list
                        current.ServiceLines.RefsRemove(context, sl);
                        //update the line
                        current.Update(context);
                    }
                    earliest.ServiceLines.RefsAdd(context, sl);
                    sl.Update(context);
                }
                //Clear teh Service Cost                
                ClearServiceCost(context);
                //Update the line item
                earliest.Update(context);
            }

        }
        public void ClearServiceCost(ContextRz context)
        {
            foreach (orddet_line l in DetailsList(context))
            {

                l.service_cost = 0;
                l.Update(context);
                //Also clear it on the Sales Order
                //ClearServiceCostSaleLine(context, l);

            }
        }

        public void ClearServiceCostSaleLine(ContextRz context)
        {
            ////assign all of the services to the earliest shipped line
            //Rz5.orddet_line earliest = EarliestShippedLine(context);
            //if (earliest != null)
            //{
            foreach (Rz5.service_line sl in ServiceLines.RefsList(context))
            {
                //invoke the related orddet_line
                Rz5.orddet_line current = (Rz5.orddet_line)sl.TheLine.RefGet(context);
                //If that orddet_line exists
                if (current != null)
                {
                    //remove each service line from refs list
                    current.ServiceLines.RefsRemove(context, sl);
                    //update the line
                    current.Update(context);
                }
                sl.Update(context);
            }
            //Clear teh Service Cost                
            ClearServiceCost(context);
            //Update the line item
            //earliest.Update(context);
            // }
            //foreach (orddet_line l in DetailsList(context))
            //{
            //    ordhed_sales TheSale = ordhed_sales.GetById(context, l.orderid_sales);
            //    if (TheSale != null)
            //    {
            //        foreach (orddet_line ll in TheSale.DetailsList(context))
            //        {
            //            if (ll.orderid_service == this.unique_id)
            //            {
            //                ll.service_cost = 0;
            //                ll.Update(context);
            //            }

            //        }
            //    }
            //}
        }

        //End Refactor

        //public virtual void ServiceDetailsAssign(ContextRz context)
        //{
        //    //assign all of the services to the earliest shipped line
        //    orddet_line earliest = EarliestShippedLine(context);
        //    if (earliest != null)
        //    {
        //        foreach (Rz5.service_line sl in ServiceLines.RefsList(context))
        //        {
        //            orddet_line current = (orddet_line)sl.TheLine.RefGet(context);
        //            if (current != null)
        //            {
        //                current.ServiceLines.RefsRemove(context, sl);
        //                context.Update(current);
        //            }
        //            earliest.ServiceLines.RefsAdd(context, sl);
        //            context.Update(sl);
        //        }
        //        context.Update(earliest);
        //    }
        //    //clears any existing service cost for lines that the services were removed from
        //    foreach (orddet_line l in DetailsList(context))
        //    {
        //        l.service_cost = 0;
        //        context.Update(l, true);
        //    }
        //}
        protected virtual orddet_line EarliestShippedLine(Rz5.ContextRz context)
        {
            orddet_line ret = null;
            DateTime d = Tools.Dates.NullDate;
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.was_shipped)
                {
                    if (!Tools.Dates.DateExists(d) || l.ship_date_actual < d)
                    {
                        ret = l;
                        d = ret.ship_date_actual;
                    }
                }
            }
            if (ret == null)
            {
                foreach (orddet_line l in DetailsList(context))
                {
                    return l;
                }
            }
            return ret;
        }
        public override String TrackingNumbersGet(ContextRz context)
        {
            string outt = "";
            foreach (orddet_line l in DetailsList(context))
            {
                String lnums = l.tracking_service_out;
                List<String> nums = Tools.Strings.SplitLinesList(lnums);
                foreach (String num in nums)
                {
                    if (Tools.Strings.StrExt(num))
                    {
                        if (!Tools.Strings.HasString(outt, num))
                        {
                            if (outt != "")
                                outt += ",";
                            outt += num;
                        }
                    }
                }
            }
            string inn = "";
            foreach (orddet_line l in DetailsList(context))
            {
                String lnums = l.tracking_service_in;
                List<String> nums = Tools.Strings.SplitLinesList(lnums);
                foreach (String num in nums)
                {
                    if (Tools.Strings.StrExt(num))
                    {
                        if (!Tools.Strings.HasString(inn, num))
                        {
                            if (inn != "")
                                inn += ",";
                            inn += num;
                        }
                    }
                }
            }
            string ret = "";
            if (Tools.Strings.StrExt(outt))
                ret = outt;
            if (Tools.Strings.StrExt(inn))
            {
                if (Tools.Strings.StrExt(outt))
                    ret += "\r\n";
                ret += inn;
            }
            if (Tools.Strings.StrExt(ret))
                return ret;
            else
                return trackingnumber;
        }
        //Public Override Functions
        private void ShowQCDetails()
        {
            MessageBox.Show("reorg");
            //string id = "";
            //foreach (KeyValuePair<string, nObject> kvp in AllDetails)
            //{
            //    orddet d = (orddet)kvp.Value;
            //    if (Tools.Strings.StrExt(d.the_qualitycontrol_uid))
            //    {
            //        id = d.the_qualitycontrol_uid;
            //        break;
            //    }
            //}
            //orddet dd = null;
            //if (!Tools.Strings.StrExt(id))
            //{
            //    if (!Rz3App.xMainForm.TheContextNM.TheLeader.AskYesNo("No QC information is associated with this order.  Do you want to add a new QC record?"))
            //        return;
            //    qualitycontrol qc = new qualitycontrol(Rz3App.xSys);
            //    qc.ISave();
            //    foreach (KeyValuePair<string, nObject> kvp in AllDetails)
            //    {
            //        dd = (orddet)kvp.Value;
            //        dd.the_qualitycontrol_uid = qc.unique_id;
            //        dd.IUpdate();
            //        break;
            //    }
            //}
            //Rz4.qualitycontrol CurrentQC = Rz4.qualitycontrol.GetByID(Rz3App.xMainForm.TheContextNM.xSys, id);
            //if (CurrentQC == null)
            //    return;
            //partrecord CurrentPart = partrecord.GetByID(Rz3App.xMainForm.TheContextNM.xSys, CurrentQC.the_partrecord_uid);
            //orddet CurrentDetail = orddet.GetByID(Rz3App.xMainForm.TheContextNM.xSys, CurrentQC.the_orddet_uid);
            //ordhed CurrentOrder = CurrentDetail.OrderObject;
            //Rz3App.xLogic.GetReceiveQuantityString_QC(Rz3App.xMainForm.TheContextRz, CurrentPart, CurrentOrder, CurrentDetail, 0, Rz3App.xMainForm);
        }
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;
            switch (args.ActionName.ToLower())
            {
                case "showqcdetails":
                    ShowQCDetails();
                    break;
                //case "companydetails":
                //    ShowCompanyDetails(xrz);
                //    break;
                case "applyspecificinvoice":
                    ApplySpecificInvoice(xrz);
                    break;
                case "toqbsasbill":
                    //xrz.TheSysRz.TheQuickBooksLogic.SendOrder(xrz, this);
                    break;
                //case "toqbsasinvoice":
                //    contextRz.TheSysRz.TheQuickBooksLogic.SendOrder((ContextRz)args.TheContext, this, new QBSendArgs(false, true));
                //    break;
                case "un-readytoship":
                    this.onhold = true;
                    this.packinginfo = "";
                    break;
                case "chargecustomer":
                    xrz.TheSysRz.TheServiceLogic.ChargeCustomerServiceCost(xrz, this, this.ordertotal);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        private void VoidService(ContextRz xrz)
        {
            throw new NotImplementedException();
        }

        void ApplySpecificInvoice(ContextRz context)
        {
            String s = context.TheLeader.AskForString("Invoice Number", "", "Invoice Number");
            if (!Tools.Strings.StrExt(s))
                return;

            ordhed o = (ordhed)context.QtO(ordhed.MakeOrdhedName(Enums.OrderType.Invoice), "select * from " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + " where ordernumber = '" + s + "'");
            if (o == null)
            {
                context.TheLeader.Tell("The invoice numbered '" + s + "' could not be found.");
                return;
            }

            if (!context.TheLeader.AreYouSure("apply " + this.ToString() + " to " + o.ToString()))
                return;

            this.apply_ordhed_invoice_uid = o.unique_id;
            context.Update(this);
            context.TheLeader.Tell("Done");
        }
        public override bool ShouldSendToQB(ContextRz context)
        {
            //if (args.AsInvoice)
            //{
            //    if (senttoqb_invoice)
            //    {
            //        if (args.Silent)
            //        {
            //            return false;
            //        }
            //        else
            //        {
            //            if (Rz3App.xUser.IsDeveloper())
            //            {
            //                if (!context.TheLeader.AskYesNo("This order has already been sent; do you want to re-send it?"))
            //                    return false;
            //            }
            //            else
            //            {
            //                context.TheLeader.Tell(GetFriendlyName() + " is already marked as having been sent.");
            //                return false;
            //            }
            //        }
            //    }
            //    return true;
            //}
            if (senttoqb)
            {
                //if (args.Silent)
                //    return false;
                //else
                //{
                if (context.xUser.IsDeveloper())
                {
                    if (!context.TheLeader.AskYesNo("This order has already been sent; do you want to re-send it?"))
                        return false;
                }
                else
                {
                    context.TheLeader.Tell(ToString() + " is already marked as having been sent.");
                    return false;
                }
                //}
            }
            return true;
        }

        public bool SendServiceOrderToQuickbooks(ContextRz xrz)
        {
            return xrz.TheSysRz.TheQuickBooksLogic.SendOrder(xrz, this);
        }

        public override Enums.OrderType OrderType
        {
            get
            {
                return Enums.OrderType.Service;
            }
            set
            {
                if (value != Enums.OrderType.Service)
                    throw new Exception("Order Type Error");
            }
        }
        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeViewedByServiceOrder((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeEditedByServiceOrder((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeDeletedByServiceOrder((ContextRz)context, this, context.xUser);
        }
        public List<orddet_line> DetailsListShippable(ContextRz context)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.ShippableService(context))
                    ret.Add(l);
            }
            return ret;
        }
        public List<orddet_line> DetailsListShippableComplete(ContextRz context)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.ShippableServiceComplete(context))
                    ret.Add(l);
            }
            return ret;
        }
        public List<orddet_line> DetailsListShippablePartial(ContextRz context)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.ShippableServicePartial(context))
                    ret.Add(l);
            }
            return ret;
        }
        public List<orddet_line> DetailsListPutAwayable(ContextRz context)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.PutAwayableService(context))
                    ret.Add(l);
            }
            return ret;
        }
        public List<orddet_line> DetailsListPutAwayableComplete(ContextRz context)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.PutAwayableServiceComplete(context))
                    ret.Add(l);
            }
            return ret;
        }
        public List<orddet_line> DetailsListPutAwayablePartial(ContextRz context)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.PutAwayableServicePartial(context))
                    ret.Add(l);
            }
            return ret;
        }
        public virtual bool ShipPossible(ContextRz context)
        {
            return true;
        }
        public virtual void Ship(ContextRz context)
        {
            Close(context, CloseType.Ship);
        }
        public void PutAway(ContextRz context)
        {
            if (context.TheSysRz.TheLineLogic.IsDropShipServiceVendor(base_company_uid))
                Close(context, CloseType.DropShipServiceReceive);
            else
                Close(context, CloseType.Receive);

        }






        public List<orddet_line> DetailsListShippableService(ContextRz context)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.ShippableService(context))
                    ret.Add(l);
            }
            return ret;
        }
        public List<orddet_line> DetailsListPutAwayableService(ContextRz context)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.PutAwayableService(context))
                    ret.Add(l);
            }
            return ret;
        }
        public override bool VoidPossible(ContextRz context, StringBuilder sb)
        {
            bool ret = base.VoidPossible(context, sb);

            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (l.was_service_out)
                {
                    sb.AppendLine(l.ToString() + " has already been shipped for service");
                    ret = false;
                }
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

        protected override bool LineIsComplete(orddet_line l)
        {
            //return base.LineIsComplete(l);
            return l.was_service_out && l.was_service_in;  //for payment this is correct, right?  or should it be when the parts only have gone out?
        }

        protected override void PostExpensesToTransaction(ContextRz context)
        {
            //switch (type)
            //{
            //    case CloseType.Ship:
            PostExpenseToTransactionReceivable(context, "Outgoing Shipping", "Shipping", shippingamount);
            PostExpenseToTransactionReceivable(context, "Outgoing Handling", "Handling", handlingamount);
            //    break;
            //case CloseType.Receive:
            PostExpenseToTransactionReceivable(context, "Incoming Shipping", "Shipping", taxamount);  //just to stay with the 3 expense structure
                                                                                                      //    break;
                                                                                                      //default:
                                                                                                      //    throw new Exception(type.ToString() + " not recognized");
                                                                                                      //}
        }



        public int GetServiceLineCount(ContextRz x)
        {
            int ret = 0;
            foreach (orddet_line l in this.DetailsList(x))
            {
                ret += l.ServiceLines.CountGet(x);
            }
            return ret;
        }
    }



    public class VarRefServiceLinesHeader : VarRefMany<ordhed_service, service_line>
    {
        public ordhed_service TheOrder;

        public VarRefServiceLinesHeader(ordhed_service h)
            : base(h, new CoreVarRefManyAttribute("ServiceLines", "Rz4.ordhed_service", "Rz4.service_line", "TheOrder", "the_service_order_uid"))
        {
            TheOrder = h;
        }

        protected override QueryClass QueryCreate(Context context)
        {
            QueryClass q = new QueryClass("service_line");
            q.Where = new ExpressionBinaryOperator(new ExpressionIdentifier(TheAttributeRef.LinkField), BinaryOperatorType.Equality, new ExpressionLiteralString(TheOrder.unique_id));
            q.OrderBy.Add(new QueryOrder(new QueryField("line_code")));
            return q;
        }

        public override service_line RefAddNew(Context x)
        {
            //Create new Ref (i.e. create the new service line as a ref)
            service_line l = base.RefAddNew(x);
            //set the header property of the line item, to the current header
            l.service_notes = GetServiceNotesFromLineItem((ContextRz)x);
            l.the_service_order_uid = TheOrder.unique_id;
            //Update the line item            
            x.Update(l);
            //
            TheOrder.ServiceDetailsAssign((ContextRz)x);
            return l;
        }

        private string GetServiceNotesFromLineItem(ContextRz x)
        {
            string ret = "";
            orddet_line theLine = (orddet_line)TheOrder.DetailsList(x)[0];
            if (theLine == null)
                return ret;
            ret = "PN: " + theLine.fullpartnumber + "| MFG: " + theLine.manufacturer + "| QTY: " + theLine.quantity + "| DC: " + theLine.datecode + "| ROHS: " + theLine.rohs_info + "| CONDITION: " + theLine.condition + "| PRICE PER PART: $" + theLine.unit_cost.ToString() + " USD";
            return ret;

        }
    }

}
