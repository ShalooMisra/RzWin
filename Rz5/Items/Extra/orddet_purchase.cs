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
    public partial class orddet_line
    {
        public VarRefOrderNew<ordhed> PurchaseVar;
        public VarRefPacks PacksInVar;
        public VarRefFieldPlusName<orddet_line, n_user> BuyerVar;
        public VarRefFieldPlusName<orddet_line, company> VendorVar;
        public VarRefFieldPlusName<orddet_line, companycontact> VendorContactVar;

        public ListArgs PacksInArgs(ContextRz context)
        {
            ListArgs args = new ListArgs(context);
            args.LiveItems = PacksInVar.RefsGet(context);
            args.TheClass = "pack";
            args.AddAllow = true;
            args.AddCaption = "Receive";
            args.TheTemplate = "Packs";
            return args;
        }

        public virtual bool NeedsPurchasing
        {
            get
            {
                return needs_purchasing;
            }
        }

        public Int64 QBPurchaseQuantity
        {
            get
            {
                return quantity;
            }
        }

        public virtual List<Rz5.ordhed> AppropriateFindPurchase(List<Rz5.ordhed> orders)
        {
            List<Rz5.ordhed> appropriate = new List<Rz5.ordhed>();
            foreach (Rz5.ordhed h in orders)
            {
                ordhed_purchase purchase = (ordhed_purchase)h;
                if (!purchase.isvoid)
                {
                    if (StockType == Rz5.Enums.StockType.Buy && purchase.base_company_uid == vendor_uid && !purchase.is_consign)
                        appropriate.Add(purchase);
                    else if (StockType == Rz5.Enums.StockType.Consign && purchase.lot_number == lotnumber && purchase.is_consign && purchase.base_company_uid == vendor_uid)
                        appropriate.Add(purchase);
                }
            }
            return appropriate;
        }

        public virtual bool PutAwayable(ContextRz context)
        {            
            return Closeable(context, OrderType.Purchase, CloseType.Receive, new PossibleArgs());
        }

        public virtual void CloseablePurchase(ContextRz context, PossibleArgs args)
        {

            if (!Tools.Strings.StrExt(purchase_expense_account_name) && LineType != Rz5.LineType.Inventory)
                args.LogAdd("No expense account has been selected");

            if (was_received || put_away)
                args.LogAdd("Already put away");

            List<OrderLineStatus> closeableOrderLineStatusList = new List<OrderLineStatus>() { OrderLineStatus.Buy, OrderLineStatus.Received_From_Service, OrderLineStatus.Vendor_RMA_Shipped, OrderLineStatus.PreInvoiced };

            if (!closeableOrderLineStatusList.Contains(Status))
                args.LogAdd(Status + " is not a valid status for closing purchase lines");
        }

        protected virtual void CloseInTransPurchase(ContextRz context)
        {
            needs_post_put_away = true;
            if (!status.ToLower().Contains("shipped"))//Don't put away lines that are already shipped.
                PutAwayMark(context);//This is where PutAway values are set, as well as receive date_actual.
        }

        public Enums.StockType StockTypeReceive
        {
            get
            {
                return PartObject.ConvertStockType(stocktype_receive);
            }

            set
            {
                stocktype_receive = value.ToString();

                switch (value)
                {
                    case Enums.StockType.Stock:
                        switch (StockType)
                        {
                            case Rz5.Enums.StockType.Stock:
                            case Rz5.Enums.StockType.Buy:
                                break;
                            default:
                                //it needs to stay blank by default
                                //StockType = Rz4.Enums.StockType.Stock;
                                break;
                        }
                        break;
                    case Enums.StockType.Consign:
                        StockType = Rz5.Enums.StockType.Consign;
                        break;
                }
            }
        }

        public bool PurchaseHas
        {
            get
            {
                return OrderHas(Enums.OrderType.Purchase);
            }
        }

        protected virtual void PostInTransPurchase(ContextRz context)
        {
            //only stock receives and consumption POs are accounting events (not regular consignment POs)
            if (LineType == Rz5.LineType.Inventory && StockType == Enums.StockType.Consign && !is_consumption)
                return;

            JournalEntry e = new JournalEntry("Put away: " + ToString());
            e.Add(context, PurchaseAccountName(context), total_cost, 0);
            e.Add(context, AccountsPayableAccountName(context), 0, total_cost);
            e.Post(context);

            //we also owe the company as a vendor
            company vendor = VendorVar.RefGet(context);
            if (vendor == null)
                throw new Exception("The vendor " + vendor_name + " could not be found");

            vendor.balance_owed_vendor_Add(context, total_cost);
            posted_purchase = true;
            Update(context);
        }

        public virtual String PurchaseAccountName(ContextRz context)
        {
            switch (LineType)
            {
                case Rz5.LineType.Inventory:
                    return "Inventory Asset";
                case Rz5.LineType.Service:
                case Rz5.LineType.Supplies:
                    return GetBillAccount(context);
                default:
                    throw new Exception("Line type " + LineType.ToString() + " is not supported");
            }
        }
        private string GetBillAccount(ContextRz context)
        {
            if (!Tools.Strings.StrExt(purchase_expense_account_name))
            {
                switch (LineType)
                {
                    case Rz5.LineType.Service:
                        return "Services";
                    case Rz5.LineType.Supplies:
                        return "Supplies";
                    default:
                        throw new Exception("Line type " + LineType.ToString() + " is not supported on a Bill.");
                }
            }
            return purchase_expense_account_name;
        }

        public virtual String AccountsPayableAccountName(ContextRz context)
        {
            if (Tools.Strings.StrExt(orderid_purchase))
            {
                ordhed_purchase p = ordhed_purchase.GetById(context, orderid_purchase);
                if (p != null)
                {
                    if (p.is_credit_card)
                        return p.cc_account_full_name;
                }
            }
            return "Accounts Payable";
        }

        protected virtual int PutAwayQuantity(ContextRz context)
        {
            return QuantityClosable(context, OrderType.Purchase, CloseType.Receive);
        }

        public virtual void AfterPutAwayInTrans(ContextRz context)
        {
            needs_post_put_away = false;
        }

        public void PutAwayMark(ContextNM x)
        {
            put_away_date = DateTime.Now;
            put_away = true;
            put_away_user = x.xUser.name;
            //KT Added Or check for is RMA IHS - This may not be necessary?
            List<OrderLineStatus> validPutAwayStatus = new List<OrderLineStatus>() { Enums.OrderLineStatus.Hold, Enums.OrderLineStatus.Buy, OrderLineStatus.PreInvoiced };
            if (validPutAwayStatus.Contains(Status)  || is_RMA_IHS == true)
            {
                if (ServiceHas && !was_service_out)
                {
                    Status = Rz5.Enums.OrderLineStatus.Packing_For_Service;
                }
                else
                {
                    //KT - This checks to see if a Sales order is attached.  If so, "Open" else "Recieved" 
                    if (SalesVar.RefGet(x) != null)
                        Status = Rz5.Enums.OrderLineStatus.Open;
                    else
                        Status = Rz5.Enums.OrderLineStatus.Received;
                }
            }

            was_received = true;
            //Moving this to when line is clicked "In-House"
            //receive_date_actual = DateTime.Now;            
            receive_agent_uid = x.xUser.unique_id;
            receive_agent_name = x.xUser.name;
            //KT added the OR here to branch IHS Logic to behave like a buy
            if (StockType == Enums.StockType.Buy || is_RMA_IHS == true)
                ((SysRz5)x.xSys).TheLineLogic.PutAwayMarkBuy(x, this);
            Update(x);
            //KT I'd like to close the PO tab here.

        }

        public virtual void FakeUnPackPurchase(ContextRz context, int fakeQuantity = -1)
        {
            FakePack(context, PacksInVar, fakeQuantity);
        }



    }
}