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
        public VarRefOrderNew<ordhed> RMAVar;
        public VarRefPacks PacksRMAVar;

        public ListArgs PacksRMAArgs(ContextRz context)
        {
            ListArgs args = new ListArgs(context);
            args.LiveItems = PacksRMAVar.RefsGet(context);
            args.TheClass = "pack";
            args.AddAllow = true;
            args.AddCaption = "Receive";
            args.TheTemplate = "Packs";
            return args;
        }

         
        public bool PutAwayableRMA(ContextRz context)
        {
            return Closeable(context, OrderType.RMA, CloseType.Receive, new PossibleArgs());
        }

        void CloseInTransRma(ContextRz context)
        {
            was_rma_received = true;
            put_away_rma = true;
            if (VendRMAVar.RefGet(context) != null)
                Status = Enums.OrderLineStatus.Vendor_RMA_Packing;
            else
                Status = Enums.OrderLineStatus.RMA_Received;
            receive_date_rma_actual = DateTime.Now;
        }

        public bool RMAHas
        {
            get
            {
                return OrderHas(Enums.OrderType.RMA);  // Tools.Strings.StrExt(ordernumber_rma);
            }
        }


        //public virtual void PutAwayRMAInTrans(ContextRz context)
        //{
        //    PutAwayRMAInTransDetail(context);

        //    was_rma_received = true;

        //    if (VendRMAVar.RefGet(context) != null)
        //        Status = Enums.OrderLineStatus.Vendor_RMA_Packing;
        //    else
        //        Status = Enums.OrderLineStatus.RMA_Received;

        //    this.receive_date_rma_actual = DateTime.Now;

        //    Update(context);

        //    if (context.Accounts.Enabled)
        //        PutAwayRMAInTransAccounts(context);
        //}


        protected virtual void PostTransRMA(ContextRz context)
        {
            //for now, just log the customer credit if its being credited
            ordhed_rma parent = (ordhed_rma)RMAVar.RefGet(context);
            if (parent == null)
                throw new Exception("RMA not found for line " + ToString());

            switch(parent.action_taken.ToLower())
            {
                case "credit":
                    break;
                default:
                    return;
            }

            //2013_08_03
            //this was using total_cost but isn't total_price_rma correct?
            //also, what if payment has already been received for the sale?

            ordhed_invoice theInvoice = (ordhed_invoice)InvoiceVar.RefGet(context);
            if (theInvoice.ispaid)
            {
                JournalEntry e = new JournalEntry("Credit Memo: " + ToString());
                e.Add(context, context.Accounts.GetAccount(context, "Sales Returns"), total_price_rma, 0);
                e.Add(context, context.Accounts.GetAccount(context, "Accounts Receivable"), 0, total_price_rma);
                e.Post(context);
            }
            else
            {
                JournalEntry e = new JournalEntry("Credit Memo: " + ToString());
                e.Add(context, context.Accounts.GetAccount(context, "Sales Returns"), total_price_rma, 0);
                e.Add(context, context.Accounts.GetAccount(context, "Accounts Receivable"), 0, total_price_rma);
                e.Post(context);
            }
            posted_rma = true;
            Update(context);
        }

        public virtual void PutAwayRMAPrepare(ContextRz x)
        {
            SplitOpenQuantitiesRMA(x);
        }

        public virtual void SplitOpenQuantitiesRMA(ContextRz x)
        {
            //split the line for any quantity that won't be put away now
            int pq = PutAwayRMAQuantity(x);
            if (quantity > pq)
            {
                int spl = quantity - pq;
                if (!x.TheLeader.AskYesNo(ToString() + " has a quantity of " + Tools.Number.LongFormat(quantity) + " but only " + Tools.Strings.PluralizePhrase("piece", pq) + " have been scanned.  Do you want to split the remaining " + Tools.Strings.PluralizePhrase("piece", spl) + " into a new line?"))
                    throw new Exception("Put away canceled");
                Split(x, spl);
            }
        }

        protected virtual int PutAwayRMAQuantity(ContextRz context)
        {
            return QuantityClosable(context, OrderType.RMA, CloseType.Receive);
        }

        public void FakeUnPackRMA(ContextRz context)
        {
            FakeUnPackRMA(context, quantity);
        }

        public virtual void FakeUnPackRMA(ContextRz context, int quantity)
        {
            FakePack(context, PacksRMAVar);
        }

        public virtual void CloseableRma(ContextRz context, PossibleArgs args)
        {
            if (was_rma_received)
                args.LogAdd("Already RMA received");

            if (Status != OrderLineStatus.RMA_Receiving)
                args.LogAdd("Not in RMA Receiving status");
        }
    }
}
