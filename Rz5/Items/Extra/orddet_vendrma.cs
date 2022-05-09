using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;
using Rz5.Enums;
using Core;

namespace Rz5
{
    public partial class orddet_line
    {
        public VarRefOrderNew<ordhed> VendRMAVar;
        public VarRefPacks PacksVendRMAVar;

        public ListArgs PacksVendRMAArgs(ContextRz context)
        {
            ListArgs args = new ListArgs(context);
            args.LiveItems = PacksVendRMAVar.RefsGet(context);
            args.TheClass = "pack";
            args.AddAllow = true;
            args.AddCaption = "Pack";
            args.TheTemplate = "Packs";
            return args;
        }

        public virtual int QuantityToShipVendRma(ContextRz context)
        {
            return QuantityClosable(context, OrderType.VendRMA, CloseType.Ship);
        }

        protected virtual void CloseInTransVendRma(ContextRz context)
        {
            this.was_vendrma_shipped = true;
            this.ship_date_vendrma_actual = DateTime.Now;
            this.Status = Rz5.Enums.OrderLineStatus.Vendor_RMA_Shipped;            
        }

        public bool VendRMAHas
        {
            get
            {
                return OrderHas(Enums.OrderType.VendRMA);  // Tools.Strings.StrExt(ordernumber_vendrma);
            }
        }

        public virtual void FakePackVendRMA(ContextRz context)
        {
            FakePack(context, PacksVendRMAVar);
        }



        //public bool ShippableVendRMA(ContextRz context)
        //{
        //    if (Status != Enums.OrderLineStatus.Void && !was_vendrma_shipped)
        //        return  > 0;
        //    else
        //        return false;
        //}

        //public bool ShippableVendRMAComplete(ContextRz context)
        //{
        //    if (Status != Enums.OrderLineStatus.Void && !was_vendrma_shipped)
        //        return quantity > 0 && quantity_packed_vendrma == quantity;
        //    else
        //        return false;
        //}

        //public bool ShippableVendRMAPartial(ContextRz context)
        //{
        //    if (Status != Enums.OrderLineStatus.Void && !was_vendrma_shipped)
        //        return quantity > 0 && quantity_packed_vendrma > 0 && quantity_packed_vendrma < quantity;
        //    else
        //        return false;
        //}

        //public void ShipInTransVendRMA(ContextRz context, bool throwTestError)
        //{
        //    ShipInTransVendRmaDetail(context);

        //    if (throwTestError)
        //        throw new Exception("Test error");



        //    Update(context);

        //    if (context.Accounts.Enabled)
        //        ShipInTransVendRmaAccounts(context);
        //}

        //public virtual bool ShipInTransVendRMA(ContextRz context)
        //{
        //    int sq = PacksVendRMAVar.QuantitySum(context);
        //    if (sq == 0)
        //    {
        //        context.TheLeader.Error("Nothing has been scanned out");
        //        return false;
        //    }
        //    if (sq < quantity)
        //        Split(context, quantity - sq);
        //    foreach (pack l in PacksVendRMAVar.RefsList(context))
        //    {
        //        partrecord p = l.ThePartGet(context);
        //        if (p == null)
        //            context.TheLeader.Error("The linked part for " + l.ToString() + " could not be found");
        //        else
        //        {
        //            if (p.quantity > l.quantity)
        //            {
        //                partrecord going = (partrecord)p.CloneValues(context);
        //                going.quantity = l.quantity;
        //                context.Insert(going);
        //                p.quantity -= l.quantity;
        //                Unallocate(context, p, l.quantity, "Sales Order " + ordernumber_sales, unique_id);
        //                //p.quantityallocated -= l.quantity;
        //                context.Update(p);
        //                p = going;  //switch p to the line that's going out
        //            }
        //            p.ShippedHandle(context, "VRMA " + this.ordernumber_vendrma, false);
        //        }
        //    }

        //    context.Update(this);
        //    return true;
        //}

        protected virtual void PostTransVendRMA(ContextRz context)
        {
            ordhed_vendrma parent = (ordhed_vendrma)VendRMAVar.RefGet(context);
            if (parent == null)
                throw new Exception("VRMA not found for line " + ToString());

            switch (parent.action_taken.ToLower())
            {
                case "credit":
                    break;
                default:
                    return;
            }

            //2013_08_04 i'm not sure what accounts to hit here
            JournalEntry e = new JournalEntry("Debit Memo: " + ToString());
            e.Add(context, context.Accounts.GetAccount(context, "Sales Returns"), total_price_vendrma, 0);
            e.Add(context, context.Accounts.GetAccount(context, "Accounts Receivable"), 0, total_price_vendrma);
            e.Post(context);
            posted_vendrma = true;
            Update(context);
        }

        //private void Unallocate(ContextRz context, partrecord p, int quantity, string refer, string id)
        //{
        //    if (p == null)
        //        return;
        //    foreach (Allocation a in p.Allocations)
        //    {
        //        if (Tools.Strings.StrCmp(a.ID, id) && Tools.Strings.StrCmp(a.Reference, refer))
        //        {
        //            int qty = a.Quantity - quantity;
        //            p.AllocateUn(context, a.Quantity, a.Reference, a.ID);
        //            if (qty > 0)
        //                p.Allocate(context, qty, a.Reference, a.ID);
        //        }
        //    }
        //}

        public virtual void CloseableVendRma(ContextRz context, PossibleArgs args)
        {
            //KT this may not be terrible clean, but if not orderid_sales or orderid_purchase, then it's a manually created VENDRMA
            if (string.IsNullOrEmpty(orderid_sales) && string.IsNullOrEmpty(orderid_purchase))               
                    return;

            if (was_vendrma_shipped)
                args.LogAdd("Already VRMA Shipped");

            if (Status != OrderLineStatus.Vendor_RMA_Packing)
                args.LogAdd("Not in VRMA Packing status");
        }
    }
}
