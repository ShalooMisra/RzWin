using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;
using Rz5.Enums;

namespace Rz5
{
    public partial class orddet_line : orddet_line_auto
    {
        public VarRefOrderNew<ordhed> InvoiceVar;
        public VarRefPacks PacksOutVar;

        public ListArgs PacksOutArgs(ContextRz context)
        {
            ListArgs args = new ListArgs(context);
            args.LiveItems = PacksOutVar.RefsGet(context);
            args.TheClass = "pack";
            args.AddAllow = true;
            args.AddCaption = "Pack";
            args.TheTemplate = "Packs";
            return args;
        }

        public virtual Double InvoiceCharges
        {
            get
            {
                return shipping_fee_invoice + charge1_fee_invoice + charge2_fee_invoice;
            }
        }

        public virtual List<Rz5.ordhed> AppropriateFindInvoice(List<Rz5.ordhed> orders)
        {
            List<Rz5.ordhed> appropriate = new List<Rz5.ordhed>();
            foreach (Rz5.ordhed h in orders)
            {
                ordhed_invoice invoice = (ordhed_invoice)h;
                if (!invoice.isvoid) // && !invoice.isclosed)  // && Tools.Strings.StrCmp(invoice.warehouse_id, this.warehouse)
                {
                    appropriate.Add(invoice);
                }
            }
            return appropriate;
        }

        string notShippableLog = "";
        public bool Shippable(ContextRz context)
        {
            return Closeable(context, OrderType.Invoice, CloseType.Ship, new PossibleArgs());
        }

        public virtual void CloseableInvoice(ContextRz context, PossibleArgs args)
        {
            string strLineCode = "Line " + this.LineCodeGet(OrderType.Invoice).ToString() + ": ";
            if (was_shipped)
                args.LogAdd(strLineCode + "Already shipped");
            if (string.IsNullOrEmpty(inventory_link_uid))
                args.LogAdd(strLineCode + "Missing Inventory link.");
            if (Status != OrderLineStatus.Packing)
                args.LogAdd(strLineCode + "Not in Packing status");
        }

        public virtual int QuantityToShip(ContextRz context)
        {
            return QuantityClosable(context, OrderType.Invoice, CloseType.Ship);
        }

        void CloseInTransInvoice(ContextRz context)
        {
            needs_post_ship = true;
            was_shipped = true;
            ship_date_actual = DateTime.Now;
            Status = Rz5.Enums.OrderLineStatus.Shipped;
            if (qc_status != SM_Enums.QcStatus.Final_Inspection.ToString())
                qc_status = SM_Enums.QcStatus.Shipped.ToString();
            ship_agent_uid = context.xUser.unique_id;
            ship_agent_name = context.xUser.name;
        }

        public virtual void AfterShipInTrans(ContextRz context)
        {
            needs_post_ship = false;
        }

        protected virtual void PostInTransInvoice(ContextRz context)
        {
            JournalEntry e = null;

            if (LineType == Rz5.LineType.Inventory && total_cost != 0)
            {
                e = new JournalEntry("COGS - Shipment: " + ToString());
                e.Add(context, context.Accounts.GetAccount(context, "Cost of Goods Sold"), total_cost, 0);
                e.Add(context, context.Accounts.GetAccount(context, "Inventory Asset"), 0, total_cost);
                e.Post(context);
            }

            if (total_price != 0)
            {
                e = new JournalEntry("Sales - Shipment: " + ToString());
                e.Add(context, context.Accounts.GetAccount(context, "Accounts Receivable"), total_price, 0);
                e.Add(context, context.Accounts.GetAccount(context, "Sales"), 0, total_price);
                e.Post(context);

                //we also owe the company
                company customer = CustomerVar.RefGet(context);
                if (customer == null)
                    throw new Exception("The customer " + customer_name + " could not be found");

                customer.balance_owed_customer_Add(context, total_price);
            }
            posted_invoice = true;
            Update(context);
        }

        public bool InvoiceHas
        {
            get
            {
                return OrderHas(Enums.OrderType.Invoice);
            }
        }

        public virtual void FakePackInvoice(ContextRz context)
        {
            FakePack(context, PacksOutVar);
        }

        public virtual void UnShip(ContextRz context, String loc)
        {
            List<pack> packsOut = PacksOutVar.RefsList(context);
            foreach (pack p in packsOut)
            {
                p.CancelShipment(context);
                PacksOutVar.RefsRemove(context, p);
                context.TheDelta.Delete(context, p);
            }

            was_shipped = false;
            notes_sales += "\r\nUnShipped by " + context.xUser.name + " on " + DateTime.Now.ToString();
            if (Status == Enums.OrderLineStatus.Shipped)
                Status = Enums.OrderLineStatus.Packing;

            context.TheDelta.Update(context, this);
        }



    }
}