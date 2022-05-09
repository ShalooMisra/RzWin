using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;
using NewMethod;
using Rz5.Enums;

namespace Rz5
{
    public partial class orddet_line
    {
        public VarRefOrderNew<ordhed> ServiceVar;
        public VarRefServiceLines ServiceLines;
        public VarRefPacks PacksInServiceVar;
        public VarRefPacks PacksOutServiceVar;
        public VarRefFieldPlusName<orddet_line, company> ServiceVendorVar;
        public VarRefFieldPlusName<orddet_line, companycontact> ServiceVendorContactVar;
        public VarRefFieldPlusName<orddet_line, n_user> ServiceAgentVar;

        public ListArgs PacksOutServiceArgs(ContextRz context)
        {
            ListArgs args = new ListArgs(context);
            args.LiveItems = PacksOutServiceVar.RefsGet(context);
            args.TheClass = "pack";
            args.AddAllow = true;
            args.AddCaption = "Pack";
            args.TheTemplate = "Packs";
            return args;
        }

        public ListArgs PacksInServiceArgs(ContextRz context)
        {
            ListArgs args = new ListArgs(context);
            args.LiveItems = PacksInServiceVar.RefsGet(context);
            args.TheClass = "pack";
            args.AddAllow = true;
            args.AddCaption = "Receive";
            args.TheTemplate = "Packs";
            return args;
        }

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

        protected virtual void CalculateServiceAmount(ContextRz context)
        {
            if (ServiceLines.Initialized && !charge_service_to_customer)
            {
                int lines = 0;
                Double serv = 0;
                foreach (service_line l in ServiceLines.RefsList(context))
                {
                    l.CalculateAmounts();
                    serv += l.total_cost;
                    lines++;
                }

                //shouldn't this set it back to zero if the total is zero?

                //if (lines > 0)
                //    service_cost = serv;

                //2012_09_19 i agree, i just changed this to use the calculated value no matter what

                service_cost = serv;
            }
        }

        public bool ShippableService(ContextRz context)
        {
            if (Status == Enums.OrderLineStatus.Void)
                return false;
            if (Status == Enums.OrderLineStatus.Out_For_Service)
                return false;
            if (was_service_out)
                return false;
            return quantity_packed_service > 0;
        }

        public bool ShippableServiceComplete(ContextRz context)
        {
            if (Status == Enums.OrderLineStatus.Void)
                return false;



            if (Status == Enums.OrderLineStatus.Out_For_Service)
                return false;

            //If this was sent for Service, could have been scrapped at remote location
            if (was_service_out)
            {
                if (Status == Enums.OrderLineStatus.Scrapped)
                    return true;
                return false;
            }            
          
            if (Status != Enums.OrderLineStatus.Packing_For_Service)
                return false;
            return true;
        }



        public bool ShippableServicePartial(ContextRz context)
        {
            if (Status == Enums.OrderLineStatus.Void)
                return false;
            if (Status == Enums.OrderLineStatus.Out_For_Service)
                return false;

            if (was_service_out)
                return false;

            return quantity > 0 && quantity_packed_service > 0 && quantity_packed_service < quantity;
        }

        public bool PutAwayableServiceComplete(ContextRz context)
        {
            if (Status != Enums.OrderLineStatus.Out_For_Service)
                return false;

            if (was_service_in)
                return false;

            return quantity > 0 && quantity_unpacked_service == quantity;
        }

        public bool PutAwayableServicePartial(ContextRz context)
        {
            if (Status != Enums.OrderLineStatus.Out_For_Service)
                return false;

            if (was_service_in)
                return false;

            return quantity > 0 && quantity_unpacked_service > 0 && quantity_unpacked_service < quantity;
        }

        public bool PutAwayableService(ContextRz context)
        {
            return PutAwayableServiceComplete(context) || PutAwayableServicePartial(context);
        }

        void CloseInTransServiceOut(ContextRz context)
        {
            if (drop_ship)
                return;
            Status = Rz5.Enums.OrderLineStatus.Out_For_Service;
            was_service_out = true;
            ship_date_service_actual = DateTime.Now;
        }

        void CloseInTransServiceIn(ContextRz context)
        {
            was_service_in = true;
            receive_date_service_actual = DateTime.Now;
        }


        protected virtual void PostTransServiceOut(ContextRz context)
        {
            foreach (service_line l in ServiceLines.RefsList(context))
            {
                JournalEntry e = new JournalEntry("Shipping to service: " + ToString() + " : " + l.ToString());
                e.Add(context, "Third Party Service", l.total_cost, 0);
                e.Add(context, AccountsPayableAccountName(context), 0, l.total_cost);
                e.Post(context);

                //we also owe the company as a vendor
                company serviceVendor = ServiceVendorVar.RefGet(context);
                if (serviceVendor == null)
                    throw new Exception("The service vendor " + service_vendor_name + " could not be found");

                serviceVendor.balance_owed_vendor_Add(context, l.total_cost);
                posted_service = true;
                Update(context);
            }
        }

        public virtual bool PutAwayServiceInTrans(ContextRz context)
        {
            //this should already be handled in Prepare();
            ////split the line for any quantity that won't be put away now
            //int pq = PacksInServiceVar.QuantitySum(context);
            //if (quantity > pq)
            //{
            //    int spl = quantity - pq;
            //    if (!context.TheLeader.AskYesNo("This line has a quantity of " + Tools.Number.LongFormat(quantity) + " but only " + Tools.Strings.PluralizePhrase("piece", pq) + " have been scanned.  Do you want to split the remaining " + Tools.Strings.PluralizePhrase("piece", spl) + " into a new line?"))
            //        return false;

            //    Split(context, spl);
            //}
            if (context.TheSysRz.TheLineLogic.IsServiceLineEligibleForAutoReceive(context, this))
                return true;

            foreach (pack l in PacksInServiceVar.RefsList(context))
            {
                //Right here, I need to link to the inventory link uid

                //partrecord p = (partrecord)l.ThePartGet(context);//This will be null if this was a drop-ship service
                partrecord p = partrecord.GetById(context, inventory_link_uid);
                if (p == null)
                {
                    context.TheLeader.Error("The linked part for " + l.ToString() + " could not be found");
                }
                else
                {
                    if (p.internalcomment != "")
                        p.internalcomment += "\r\n";
                    p.internalcomment += "Received from service on " + ordernumber_service + " to " + l.location;
                    p.location = l.location;
                    context.Update(p);
                }
            }

            AfterPutAwayService(context);
            context.Update(this);
            return true;
        }

        protected virtual void AfterPutAwayService(ContextRz context)
        {
            //if its attached to an invoice, its ready for packing
            ordhed i = OrderObjectGet(context, Rz5.Enums.OrderType.Invoice);
            if (i != null)
                this.Status = Rz5.Enums.OrderLineStatus.Packing;
            else
            {
                ordhed sal = OrderObjectGet(context, Rz5.Enums.OrderType.Sales);
                if (sal == null)
                    this.Status = Rz5.Enums.OrderLineStatus.Received_From_Service;
                else
                    this.Status = Rz5.Enums.OrderLineStatus.Open;
            }
        }

        public virtual bool ShipServiceInTrans(ContextRz context)
        {
            //this should already be handled in Prepare();
            ////split the line for any quantity that won't be put away now
            //int pq = PacksOutServiceVar.QuantitySum(context);
            //if (quantity > pq)
            //{
            //    int spl = quantity - pq;
            //    if (!context.TheLeader.AskYesNo("This line has a quantity of " + Tools.Number.LongFormat(quantity) + " but only " + Tools.Strings.PluralizePhrase("piece", pq) + " have been scanned.  Do you want to split the remaining " + Tools.Strings.PluralizePhrase("piece", spl) + " into a new line?"))
            //        return false;

            //    Split(context, spl);
            //}

            //foreach (pack l in PacksOutServiceVar.RefsList(context))
            //{
            //    //l.quantity_shipped = l.quantity;
            //l.IUpdate();
            //Drop-Ship Service Logic:
            if (context.TheSysRz.TheLineLogic.IsDropShipServiceVendor(service_vendor_uid))
            {
                if (quantity_packed_service != quantity)
                {
                    quantity_packed_service = quantity;
                    context.Update(this);
                }
                //If this line has been marked drop-ship, then we are don on our end, consider it closed.
                if (drop_ship)  
                    return false;

                return true;
            }
            else if (!context.TheSysRz.TheLineLogic.IsServiceLineEligibleForAutoShip(context, this))

            {

                //partrecord p = l.ThePartGet(context);
                partrecord p = partrecord.GetById(context, inventory_link_uid);
                if (p == null)
                {
                    context.TheLeader.Error("The linked part for " + fullpartnumber + " could not be found.  Has it been put away yet?");
                    return false;
                }
                else
                {
                    if (p.internalcomment != "")
                        p.internalcomment += "\r\n";
                    p.internalcomment += "Sending for service on " + ordernumber_service + " Original Location: " + p.location;
                    p.location = "Out For Service On " + ordernumber_service;
                    context.Update(p);
                }
            }
            //}

            this.Status = OrderLineStatus.Out_For_Service;
            this.was_service_out = true;
            context.Update(this);

            return true;
        }

        public ordhed_service SendForService(ContextRz context)
        {
            List<orddet_line> lst = new List<orddet_line>();
            lst.Add(this);
            return context.TheSysRz.TheLineLogic.SendForService(context, lst);
        }

        public bool ServiceHas
        {
            get
            {
                return OrderHas(Enums.OrderType.Service);  //Tools.Strings.StrExt(ordernumber_service);
            }
        }

        public void FakePackService(ContextRz context)
        {
            FakePack(context, PacksOutServiceVar);
        }

        public void FakeUnPackService(ContextRz context)
        {
            FakePack(context, PacksInServiceVar);
        }

        public virtual void CloseableServiceOut(ContextRz context, PossibleArgs args)
        {
            if (was_service_out)
                args.LogAdd("Already service shipped");

            //It's valid that a line may be in "out for service" (i.e. White Horse) whild still being closable (i.e. drop ship vendrma)
            if (drop_ship)
                return;

            if (Status != OrderLineStatus.Packing_For_Service)
                args.LogAdd("Not in Packing For Service status");
        }

        public virtual void CloseableServiceIn(ContextRz context, PossibleArgs args)
        {
            if (was_service_in)
                args.LogAdd("Already service received");

            if (Status != OrderLineStatus.Out_For_Service)
                args.LogAdd("Not in Out For Service status");
        }
    }

    public class VarRefServiceLines : VarRefMany<orddet_line, service_line>
    {
        public orddet_line TheLine
        {
            get
            {
                return (orddet_line)Parent;
            }
        }

        public VarRefServiceLines(IItem parent)
            : base(parent, new CoreVarRefManyAttribute("ServiceLines", "Rz4.orddet_line", "Rz4.service_line", "TheLine", "the_orddet_line_uid"))
        {

        }

        protected override QueryClass QueryCreate(Context context)
        {
            QueryClass q = new QueryClass("service_line");
            q.Where = new ExpressionBinaryOperator(new ExpressionIdentifier(TheAttributeRef.LinkField), BinaryOperatorType.Equality, new ExpressionLiteralString(TheLine.unique_id));
            q.OrderBy.Add(new QueryOrder(new QueryField("line_code")));
            return q;
        }

        public override service_line RefAddNew(Context x)
        {
            service_line l = base.RefAddNew(x);
            l.the_orddet_line_uid = TheLine.unique_id;
            l.the_service_order_uid = TheLine.orderid_service;
            x.Update(l);
            return l;
        }

        public override void RefsAdd(Context x, IItems items, bool includeReverse)
        {
            base.RefsAdd(x, items, includeReverse);

            foreach (service_line sl in items.AllGet(x))
            {
                sl.the_orddet_line_uid = TheLine.unique_id;
                sl.the_service_order_uid = TheLine.orderid_service;
                x.Update(sl);
            }
        }
    }
}
