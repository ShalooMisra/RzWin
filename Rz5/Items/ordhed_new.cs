using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Tools;
using Core;
using Core.Display;
using NewMethod;
using HubspotApis;
using System.Linq;
using SensibleDAL;

namespace Rz5
{
    public partial class ordhed_new : ordhed_new_auto
    {
        public VarRefOrderLinesNew DetailsVar;
        protected n_user CurrentAgent;
        public override List<Var> VarsGetInitially()
        {
            List<Var> ret = base.VarsGetInitially();
            ret.Add(DetailsVar);
            return ret;
        }

        public ordhed_new()
        {
            DetailsVarInit();
        }

        protected virtual void DetailsVarInit()
        {
            DetailsVar = new VarRefOrderLinesNew(this);
        }

        ~ordhed_new()
        {
            try
            {
                DetailsVar.Dispose();
                DetailsVar = null;
            }
            catch { }
        }




        public override void Updating(Context x)
        {
            base.Updating(x);
            //DateTime first_dock = Tools.Dates.GetNullDate();
            //bool first = true;
            trackingnumber = TrackingNumbersGet((ContextRz)x);
            days_to_pay = ordhed.GetDaysAllowed(terms);
            //foreach (orddet_line d in DetailsList((ContextRz)x))
            //{
            //    //if (first)
            //    //{
            //    //    first_dock = d.customer_dock_date;
            //    //    first = false;
            //    //}
            //    if (!Tools.Strings.StrExt(d.seller_uid))
            //        d.seller_uid = this.base_mc_user_uid;
            //    if (!Tools.Strings.StrExt(d.seller_name))
            //        d.seller_name = this.agentname;
            //    if (!Tools.Strings.StrExt(d.buyer_uid))
            //        d.buyer_uid = this.orderbuyerid;
            //    if (!Tools.Strings.StrExt(d.buyer_name))
            //        d.buyer_name = this.buyername;
            //}

            //dockdate = first_dock;
        }

        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;

            switch (args.ActionName.ToLower().Trim())
            {
                case "applyfullpayment":
                    ApplyFullPayment(xrz);
                    args.Handled = true;
                    break;
                case "close":
                    Close(xrz, CloseType.Receive);
                    break;

                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override bool DeletePossible(Context x)
        {
            if (isclosed)
                return false;

            return base.DeletePossible(x);
        }

        public virtual void TrackingNumberAdd(ContextRz context, String number)
        {
            List<orddet_line> dets = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                dets.Add(l);
            }

            context.TheSysRz.TheLineLogic.TrackingAdd(context, dets, OrderType, number);
            context.Update(this);
        }

        //2012_10_11 changed so that the numbers can be entered on the order and saved, along with unique numbers from the details
        public virtual String TrackingNumbersGet(ContextRz context)
        {
            List<String> numbers = new List<string>();
            foreach (String s in Tools.Strings.SplitLinesList(trackingnumber))
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                string[] str = Tools.Strings.Split(s, ",");
                foreach (string ss in str)
                {
                    if (!Tools.Strings.StrExt(ss))
                        continue;
                    if (!numbers.Contains(ss.ToUpper().Trim()))
                        numbers.Add(ss.ToUpper().Trim());
                }
            }
            foreach (orddet_line l in DetailsList(context))
            {
                String lnums = l.TrackingNumberGet(OrderType);
                List<String> nums = Tools.Strings.SplitLinesList(lnums);
                foreach (String num in nums)
                {
                    if (!Tools.Strings.StrExt(num))
                        continue;
                    string[] str = Tools.Strings.Split(num, ",");
                    foreach (string ss in str)
                    {
                        if (!Tools.Strings.StrExt(ss))
                            continue;
                        if (!numbers.Contains(ss.ToUpper().Trim()))
                            numbers.Add(ss.ToUpper().Trim());
                    }
                }
            }
            numbers.Sort();
            StringBuilder sb = new StringBuilder();
            foreach (String s in numbers)
            {
                sb.AppendLine(s);
            }
            return sb.ToString();
        }

        public override IVarRefOrderLines Details
        {
            get
            {
                return DetailsVar;
            }
        }



        public int DetailsCount(ContextRz context)
        {
            return DetailsVar.RefsGet(context).Count;
        }

        public override int GetNextLineCode(ContextRz context)
        {
            int winner = 0;
            foreach (orddet_line d in DetailsList(context))
            {
                int l = d.LineCodeGet(this.OrderType);
                if (l > winner)
                    winner = l;
            }
            return winner + 1;
        }

        public List<orddet_line> DetailsListStatus(ContextRz context, Enums.OrderLineStatus status)
        {
            List<orddet_line> ret = new List<orddet_line>();

            foreach (orddet_line l in DetailsList(context))
            {
                if (l.Status == status)
                    ret.Add(l);
            }

            return ret;
        }

        public List<orddet_quote> DetailsListStatusQuote(ContextRz context, Enums.OrderLineStatus status)
        {
            List<orddet_quote> ret = new List<orddet_quote>();

            foreach (orddet_quote q in DetailsList(context))
            {
                if (q.Status == status)
                    ret.Add(q);
            }

            return ret;
        }

        public List<orddet_line> DetailsListStatus(ContextRz context, Enums.OrderLineStatus[] statuses)
        {
            List<orddet_line> ret = new List<orddet_line>();

            foreach (orddet_line l in DetailsList(context))
            {
                foreach (Enums.OrderLineStatus s in statuses)
                {
                    if (l.Status == s)
                        ret.Add(l);
                }
            }

            return ret;
        }

        public override List<orddet> DetailsListSummed(ContextRz context)
        {
            return context.TheSysRz.TheOrderLogic.DetailsSum(context, DetailsList(context), OrderType);
        }

        public int QuantityCount(ContextRz context)
        {
            int ret = 0;
            foreach (orddet_line l in DetailsList(context))
            {
                ret += l.quantity;
            }
            return ret;
        }

        public override orddet GetNewDetail(ContextRz context)
        {
            return DetailsVar.RefAddNew(context);
        }



        public override int PictureCount(ContextRz x, bool countLines = true, String extraWhere = "")
        {

            List<string> ordhedIds = new List<string>();
            ordhedIds.Add(this.unique_id);
            //For Sales, include Quotes attachments
            if (this.OrderType == Enums.OrderType.Sales)
            {
                foreach (ordlnk l in this.LinksToVar.RefsList(x))
                {

                    if (l.OrderType1 == Enums.OrderType.Quote)
                        if (!ordhedIds.Contains(l.orderid1))
                            ordhedIds.Add(l.orderid1);

                }
            }
            //For Invoices, include Quote and Sales Attachments
            else if (this.OrderType == Enums.OrderType.Invoice)
            {
                foreach (ordlnk l in this.LinksToVar.RefsList(x))
                {

                    if (l.OrderType1 == Enums.OrderType.Quote)
                        if (!ordhedIds.Contains(l.orderid1))
                            ordhedIds.Add(l.orderid1);
                    if (l.OrderType1 == Enums.OrderType.Sales)
                        if (!ordhedIds.Contains(l.orderid1))
                            ordhedIds.Add(l.orderid1);

                }
            }

            int ret = 0;

            //ret = x.TheLogicRz.PictureData.GetScalar_Integer();


            List<String> details_ids = new List<string>();
            foreach (orddet_line l in DetailsList(x))
            {
                details_ids.Add(l.unique_id);
            }





            String search = "select count(*) from partpicture where the_ordhed_uid in (" + Data.GetIn(ordhedIds) + ")";
            if (countLines && details_ids.Count > 0)
                search += " or the_orddet_uid in (" + Tools.Data.GetIn(details_ids) + ")";
            

            if (Tools.Strings.StrExt(extraWhere))
                search += " and " + extraWhere;
            ret += x.TheLogicRz.PictureData.GetScalar_Integer(search);
            return ret;
        }

        public override List<Rz5.orddet> MakeLink(ContextRz x, Enums.OrderType t)
        {
            OrderLinkArgs args = new OrderLinkArgs((ordhed_new)this);
            args.TheLinkType = t;
            x.TheLeaderRz.OrderLinkChoose(x, args);
            if (args.Lines.Count == 0)
                return new List<Rz5.orddet>();

            return MakeLink(x, args);
        }

        public virtual List<Rz5.orddet> MakeLink(ContextRz x, OrderLinkArgs args)
        {
            List<Rz5.orddet> ret = new List<orddet>();

            foreach (OrderLinkLine l in args.Lines)
            {
                if (l.Quantity < l.TheLine.quantity)
                {
                    orddet_line remaining = l.TheLine.Split(x, (l.TheLine.quantity - l.Quantity));
                    x.Update(remaining);
                }
                Details.RefsAdd(x, l.TheLine);
                l.TheLine.ParentOrderTypeSet(x, this.OrderType);

                //2013_08_20
                //i don't think this is right; t is the type being linked from, this.OrderType is the type being linked to
                //if (t == Enums.OrderType.Purchase)
                //{
                //    l.TheLine.needs_purchasing = true;
                //    l.TheLine.StockType = Rz5.Enums.StockType.Buy;
                //    l.TheLine.lotnumber = "BUY";
                //}

                if (this.OrderType == Enums.OrderType.Purchase)
                {
                    l.TheLine.needs_purchasing = true;
                    l.TheLine.StockType = Rz5.Enums.StockType.Buy;
                    l.TheLine.lotnumber = "BUY";
                }

                //switch the line to Hold so it can be edited and completed again
                if (args.TheLinkType == Enums.OrderType.Purchase && this.OrderType == Enums.OrderType.Sales)
                {
                    l.TheLine.Status = Enums.OrderLineStatus.Hold;
                }

                l.TheLine.Update(x);
                ret.Add(l.TheLine);
            }

            x.TheSysRz.TheOrderLogic.Link2Orders(x, this, args.TheOrderLinked);
            x.TheDelta.Update(x, this);


            //MakeLinkObject(x, args.TheOrderLinked);
            //this.IUpdate();

            return ret;
        }

        public override bool VoidPossible(ContextRz context, StringBuilder sb)
        {
            bool ret = base.VoidPossible(context, sb);

            foreach (orddet_line l in DetailsList(context))
            {
                if (!l.VoidPossible(context, OrderType, sb))
                    ret = false;
            }

            return ret;
        }
        public virtual void CancelLines(ContextRz context, List<orddet_line> lines)
        {
            foreach (orddet_line l in lines)
            {
                OrderLineCancelArgs args = new OrderLineCancelArgs(l);
                args.TypesToCancel.Add(this.OrderType);
                l.Cancel(context, args);
            }
        }
        public override bool Void(ContextRz context)
        {


            if (!base.Void(context))
                return false;
            isvoid = true;
            VoidLines(context);

            context.Update(this);
            //AddLog(context, "Voided.");
            return true;
        }

        protected virtual void VoidLines(ContextRz context)
        {
            List<orddet_line> lines = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                lines.Add(l);
            }
            CancelLines(context, lines);
            foreach (orddet_line l in lines)
            {
                orddet_line clone = (orddet_line)l.CloneValues(context);
                clone.orderid_purchase = "";
                clone.orderid_rma = "";
                clone.orderid_service = "";
                clone.orderid_vendrma = "";
                clone.orderid_invoice = "";
                clone.orderid_sales = "";
                clone.ordernumber_purchase = "";
                clone.ordernumber_rma = "";
                clone.ordernumber_service = "";
                clone.ordernumber_vendrma = "";
                clone.ordernumber_invoice = "";
                clone.ordernumber_sales = "";
                clone.ISet("orderid_" + ordertype.ToLower(), unique_id);
                clone.ISet("ordernumber_" + ordertype.ToLower(), ordernumber);
                clone.Status = Enums.OrderLineStatus.Void;
                clone.unique_id = "";
                clone.service_cost = 0;
                context.Insert(clone);
                DetailsVar.RefsAdd(context, clone);
            }

        }

        public override void VoidUn(ContextRz context)
        {
            base.VoidUn(context);

            //remove the void lines, since they're copies
            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (l.Status == Enums.OrderLineStatus.Void)
                    l.Delete(context);
            }
            Update(context);
        }

        public List<ordhed_new> LinkedOrdersGet(ContextRz x)
        {
            return LinkedOrdersGet(x, Enums.OrderType.Any);
        }

        public List<ordhed_new> LinkedOrdersGet(ContextRz x, Enums.OrderType type)
        {
            List<ordhed_new> ret = new List<ordhed_new>();
            List<String> ex = new List<string>();
            foreach (orddet_line l in DetailsVar.RefsList(x))
            {
                List<ordhed_new> linked = null;
                if (type == Enums.OrderType.Any)
                    linked = l.OrdersGet(x);
                else
                {
                    linked = new List<ordhed_new>();
                    linked.Add((ordhed_new)l.OrderObjectGet(x, type));
                }

                foreach (ordhed_new n in linked)
                {
                    if (n != null)
                    {
                        if (!ex.Contains(n.unique_id))
                        {
                            ex.Add(n.unique_id);
                            ret.Add(n);
                        }
                    }
                }
            }
            return ret;
        }

        public virtual void MarkSentToQB(ContextRz context)
        {
            senttoqb = true;
            datesenttoqb = System.DateTime.Now;
            context.TheDelta.Update(context, this);
        }

        public void CheckAutoASN(ContextRz context)
        {
            ((SysRz5)context.xSys).TheOrderLogic.CheckAutoASN(context, this);
        }

        public void CreateASNEmail(ContextRz context)
        {
            emailtemplate t = null;

            //                    CurrentOrder.legacycontact += "-FULLASN";
            //else if (optNotifySummary.Checked )
            //    CurrentOrder.legacycontact += "-SUMMARYASN";

            if (context.TheLeader.AskYesNo("Do you want to include the line item info in this email?"))
                t = emailtemplate.GetByName(context, "Advance Invoice Shipment Notification");
            else
                t = emailtemplate.GetByName(context, "Advance Invoice Shipment Summary");


            if (t != null)
            {
                //if (context.TheLeader.AskYesNo("Do you want to send the automatic advance shipment notification?"))
                //{
                t.SendOrderEmail(context, this, false, "", false, true, false, "", "", "", "", "", true);
                //}
            }
            else
                context.TheLeader.TellTemp("Please create the ASN email templates before continuing.");
        }

        public void OrderDateSet(ContextRz context, DateTime d)
        {
            orderdate = d;
            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                l.ISet("orderdate_" + OrderType.ToString().ToLower(), d);
            }
        }

        public virtual bool NewCurrencyApplicableToDetail(ContextRz context, orddet_line l)
        {
            throw new NotImplementedException();
        }

        public List<orddet_line> NewCurrencyApplicableDetails(ContextRz context)
        {
            List<orddet_line> ret = new List<orddet_line>();

            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (NewCurrencyApplicableToDetail(context, l))
                    ret.Add(l);
            }
            return ret;
        }

        protected void PostExpenseToTransactionPayable(ContextRz transContext, String expenseAccountName, String caption, Double expenseAmount)
        {
            PostExpenseToTransactionPayable(transContext, transContext.Accounts.GetAccount(transContext, expenseAccountName), caption, expenseAmount);
        }

        protected void PostExpenseToTransactionPayable(ContextRz transContext, account expenseAccount, String caption, Double expenseAmount)
        {
            if (expenseAmount == 0)
                return;

            JournalEntry e = new JournalEntry(caption + " on " + ToString());
            e.Add(transContext, expenseAccount, expenseAmount, 0);
            e.Add(transContext, transContext.Accounts.GetAccount(transContext, "Accounts Payable"), 0, expenseAmount);
            e.Post(transContext);

            company vendor = CompanyVar.RefGet(transContext);
            if (vendor == null)
                throw new Exception("Vendor not found");

            vendor.balance_owed_vendor_Add(transContext, expenseAmount);
        }

        protected void PostExpenseToTransactionReceivable(ContextRz transContext, String incomeAccountName, String caption, Double expenseAmount)
        {
            PostExpenseToTransactionReceivable(transContext, transContext.Accounts.GetAccount(transContext, incomeAccountName), caption, expenseAmount);
        }

        protected void PostExpenseToTransactionReceivable(ContextRz transContext, account incomeAccount, String caption, Double expenseAmount)
        {
            if (expenseAmount == 0)
                return;

            JournalEntry e = new JournalEntry(caption + " on " + ToString());
            e.Add(transContext, transContext.Accounts.GetAccount(transContext, "Accounts Receivable"), expenseAmount, 0);
            e.Add(transContext, incomeAccount, 0, expenseAmount);
            e.Post(transContext);

            company customer = CompanyVar.RefGet(transContext);
            if (customer == null)
                throw new Exception("Customer not found");

            customer.balance_owed_customer_Add(transContext, expenseAmount);
        }

        //void PayExpenseToTransactionPayable(ContextRz context, ref Double paymentAmountLeftToApply, Double expenseAmount, String expenseName, ref Double expensesAlreadyPaid, account cashAccount)
        //{
        //    if (expensesAlreadyPaid >= expenseAmount)
        //    {
        //        expensesAlreadyPaid -= expenseAmount;
        //        return;
        //    }

        //    Double expenseAmountSplit = expensesAlreadyPaid;
        //    Double amountToApply = expenseAmount - expensesAlreadyPaid;
        //    expensesAlreadyPaid = 0;

        //    JournalEntry e = new JournalEntry(Tools.Strings.NiceFormat(expenseName) + " on " + ToString());
        //    e.Add(context, context.Accounts.GetAccount(context, "Accounts Payable"), amountToApply, 0);
        //    e.Add(context, cashAccount, 0, amountToApply);
        //    e.Post(context);
        //}

        //void PayExpenseToTransactionReceivable(ContextRz context, ref Double paymentAmountLeftToApply, Double expenseAmount, String expenseName, ref Double expensesAlreadyPaid, account cashAccount)
        //{
        //    if (expensesAlreadyPaid >= expenseAmount)
        //    {
        //        expensesAlreadyPaid -= expenseAmount;
        //        return;
        //    }

        //    Double expenseAmountSplit = expensesAlreadyPaid;
        //    Double amountToApply = expenseAmount - expensesAlreadyPaid;
        //    expensesAlreadyPaid = 0;

        //    JournalEntry e = new JournalEntry(Tools.Strings.NiceFormat(expenseName) + " on " + ToString());
        //    e.Add(context, cashAccount, amountToApply, 0);
        //    e.Add(context, context.Accounts.GetAccount(context, "Accounts Receivable"), 0, amountToApply);
        //    e.Post(context);
        //}

        public account CashAccount(ContextRz context)
        {
            switch (OrderType)
            {
                case Enums.OrderType.Invoice:
                case Enums.OrderType.VendRMA:
                    account retIn = context.Accounts.GetAccount(context, "Undeposited Funds");
                    if (retIn == null)
                        throw new Exception("Account 'Undeposited Funds' was not found");
                    else
                        return retIn;
                //case Enums.OrderType.Purchase:
                //case Enums.OrderType.RMA:
                //case Enums.OrderType.Service:
                //    account retOut = context.Accounts.GetAccount(context, "Checking");
                //    if (retOut == null)
                //        throw new Exception("Account 'Checking' was not found");
                //    else
                //        return retOut;
                default:
                    throw new Exception("Payments cannot be applied to orders of type " + OrderType);
            }
        }

        public void ApplyFullPayment(ContextRz context)
        {
            ApplyPayment(context, ordertotal, null);
        }

        public checkpayment ApplyPayment(ContextRz context, Double paymentAmount, IPayment thePayment)
        {
            if (!isclosed)
                throw new Exception(ToString() + " is still open");

            if (outstandingamount < paymentAmount)
                throw new Exception("The amount " + Tools.Number.MoneyFormat(paymentAmount) + " is more than the outstanding amount of " + Tools.Number.MoneyFormat(outstandingamount));

            //get the customer fresh each time since for now, the actual property is used for the += value
            company comp = company.GetById(context, base_company_uid);  // CompanyVar.RefGet(context);
            if (comp == null)
                throw new Exception("The company for " + ToString() + " could not be found");

            if (thePayment == null)
            {
                switch (OrderType)
                {
                    case Enums.OrderType.Invoice:
                    case Enums.OrderType.VendRMA:
                        thePayment = payment_in.New(context);
                        break;
                    case Enums.OrderType.Purchase:
                    case Enums.OrderType.RMA:
                    case Enums.OrderType.Service:
                        thePayment = payment_out.New(context);
                        break;
                    default:
                        throw new Exception("Payments cannot be applied to orders of type " + OrderType);
                }

                thePayment.SetCompany(comp);
                thePayment.amount = 0;  //this gets updated in the transaction
                thePayment.description = ToString();
                thePayment.Insert(context);
            }

            ContextRz xx = (ContextRz)context.Clone();
            xx.BeginTran();

            checkpayment theCheckPayment = ApplyPaymentInTrans(xx, paymentAmount, thePayment, comp, CashAccount(context));

            try
            {
                xx.CommitTran();
            }
            catch (Exception ex)
            {
                thePayment.Invalidate(context);
                theCheckPayment.Invalidate(context);
                comp.Invalidate(context);
                this.Invalidate(context);

                throw new Exception("Application of this payment failed: " + ex.Message);
            }

            return theCheckPayment;
        }

        public checkpayment ApplyPaymentInTrans(ContextRz context, Double paymentAmount, IPayment thePayment, company comp, account cashAccount)
        {
            checkpayment theCheckPayment = AddTransaction(context);
            if (thePayment is payment_in)
                theCheckPayment.payment_in_uid = thePayment.unique_id;
            else
                theCheckPayment.payment_out_uid = thePayment.unique_id;

            theCheckPayment.Update(context);

            thePayment.amount += paymentAmount;
            thePayment.Update(context);

            theCheckPayment.subtotal = paymentAmount;
            theCheckPayment.Update(context);

            amount_paid_Add(context, paymentAmount);

            switch (OrderType)
            {
                case Enums.OrderType.Invoice:
                case Enums.OrderType.VendRMA:
                    comp.balance_owed_customer_Subtract(context, paymentAmount);
                    break;
                case Enums.OrderType.Purchase:
                case Enums.OrderType.RMA:
                case Enums.OrderType.Service:
                    comp.balance_owed_vendor_Subtract(context, paymentAmount);
                    break;
                default:
                    throw new Exception("Payments cannot be applied to orders of type " + OrderType);
            }

            JournalEntry entry = new JournalEntry("Payment on " + ToString());

            switch (OrderType)
            {
                case Enums.OrderType.Invoice:
                case Enums.OrderType.VendRMA:
                    entry.Add(context, cashAccount, paymentAmount, 0);
                    entry.Add(context, context.Accounts.GetAccount(context, "Accounts Receivable"), 0, paymentAmount);
                    break;
                case Enums.OrderType.Purchase:
                case Enums.OrderType.RMA:
                case Enums.OrderType.Service:
                    entry.Add(context, context.Accounts.GetAccount(context, "Accounts Payable"), paymentAmount, 0);
                    entry.Add(context, cashAccount, 0, paymentAmount);
                    break;
                default:
                    throw new Exception("Payments cannot be applied to orders of type " + OrderType);
            }

            entry.Post(context);

            return theCheckPayment;
        }

        public override void amount_paid_Add(Context context, Double amount)
        {
            base.amount_paid_Add(context, amount);
            RecalcPaidAndOutstandingFlag(context);
        }

        public override void amount_paid_Subtract(Context context, Double amount)
        {
            base.amount_paid_Subtract(context, amount);
            RecalcPaidAndOutstandingFlag(context);
        }

        void RecalcPaidAndOutstandingFlag(Context context)
        {
            this.ispaidVar.Value = (amount_paid >= ordertotal);
            outstandingamount = ordertotal - amount_paid;
            context.Execute("update " + TableName + " set outstandingamount = isnull(ordertotal, 0) - isnull(amount_paid, 0), ispaid = case when isnull(amount_paid, 0) >= isnull(ordertotal, 0) then 1 else 0 end, date_paid = case when isnull(amount_paid, 0) >= isnull(ordertotal, 0) then getdate() else '1/1/1900' end where unique_id = '" + unique_id + "'");
        }

        public void ispaid_Set(Context context, bool value)
        {
            ispaidVar.Value = value;
            context.Execute("update " + TableName + " set ispaid = " + Tools.Database.DataConnectionSqlServer.BoolFilter(value) + " where unique_id = '" + unique_id + "'");
        }

        public void posted_expenses_Set(Context context, bool value)
        {
            this.posted_expensesVar.Value = value;
            context.Execute("update " + TableName + " set posted_expenses = " + Tools.Database.DataConnectionSqlServer.BoolFilter(value) + " where unique_id = '" + unique_id + "'");
        }


        protected virtual bool LineIsComplete(orddet_line l)
        {
            throw new NotImplementedException();
        }

        protected void CloseAllLineViews(ContextRz context)
        {
            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                context.TheLeader.ViewsClose(l);
            }
        }

        ///////////////////////////////////////////////
        //Closing

        public virtual void AfterClose(ContextRz context, List<orddet_line> lines, CloseType closeType)
        {
            switch (OrderType)
            {
                case Enums.OrderType.Service:
                    {

                        break;
                    }

                case Enums.OrderType.VendRMA:
                    {
                        //Close Related Orders on DropShip.
                        if (this.OrderHasDropShipLines(context, (ordhed)this))
                        {

                            CheckCloseRelatedOrders(context, lines);
                        }
                        break;
                    }


            }


        }
        private void CheckCloseRelatedOrders(ContextRz context, List<orddet_line> lines)
        {

            //Get the related Orders to this Vendor RMA.
            List<string> relatedPOIds = lines.Select(sel => sel.orderid_purchase).Distinct().ToList();
            List<string> relatedSaleIds = lines.Select(sel => sel.orderid_sales).Distinct().ToList();
            List<string> relatedServiceIds = lines.Select(sel => sel.orderid_service).Distinct().ToList();
            //Get Line item for this 
            //Seems lazy, but only want to close orders when there is only one order id associated.
            if (relatedPOIds.Count == 1)
            {
                ordhed p = (ordhed)context.QtO("ordhed_purchase", "select * from ordhed_purchase where unique_id = '" + relatedPOIds[0] + "'");
                if (p != null)
                    CheckCloseRelatedOrder(context, p);
            }
            if (relatedSaleIds.Count == 1)
            {
                ordhed ss = (ordhed)context.QtO("ordhed_sales", "select * from ordhed_sales where unique_id = '" + relatedSaleIds[0] + "'");
                if (ss != null)
                    CheckCloseRelatedOrder(context, ss);
            }
            if (relatedServiceIds.Count == 1)
            {
                ordhed s = (ordhed)context.QtO("ordhed_service", "select * from ordhed_service where unique_id = '" + relatedServiceIds[0] + "'");
                if (s != null)
                    CheckCloseRelatedOrder(context, s);
            }










        }

        private void CheckCloseRelatedOrder(ContextRz context, ordhed o)
        {
            //    //if "this" is the ONLY line in the PO, set to closed using the this.drop_ship_comments
            //    List<orddet> linesList = o.DetailsList(context);

            //    //This ordhed can be of any type.  get the type so we know which orderid_ we need to query.
            //    if (linesList.Count == 1)
            //        if (linesList[0].unique_id == this.unique_id)
            //        {//If it's not already closed
            if (!o.isclosed)
            {
                context.TheLeader.ViewsClose(o);
                o.isclosed = true;
                o.internalcomment += "Closed Via Drop-ship VendorRMA";
                o.Update(context);
            }


            //}
        }


        protected virtual void PostExpensesToTransaction(ContextRz context) { }

        //Used in the below 2 methods.
        PossibleArgs closeArgs = new PossibleArgs();

        public List<orddet_line> CloseableLines(ContextRz context, CloseType closeType)
        {
            List<orddet_line> ret = new List<orddet_line>();
           

            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                
                l.Closeable(context, OrderType, closeType, closeArgs);
                if (closeArgs.Possible)
                    ret.Add(l);
            }
            return ret;
        }

        public virtual void Closeable(ContextRz context, List<orddet_line> lines, CloseType closeType, PossibleArgs args)
        {
            if (CompanyVar.RefGet(context) == null)
                args.LogAdd("No company is selected");

            foreach (orddet_line l in lines)
            {
                l.Closeable(context, OrderType, closeType, closeArgs);
            }
        }

        protected virtual void BeforeCloseCheck(ContextRz context, List<orddet_line> lines, CloseType type)
        {
            CloseAllLineViews(context);
            SplitPartiallyFilledLines(context, lines, type);

            if (type == CloseType.Ship && OrderType == Enums.OrderType.Invoice)
            {
                //RemoveUnFilledLines(context, type, lines);
                PrepareInventoryForShipping(context, lines);
                partrecord.ShippedTableCheck(context);
            }

        }

        protected virtual void BeforeCloseFinal(ContextRz context, List<orddet_line> lines, CloseType type)
        {
            //KT PO# 3133841 had 2 lines, one fully recieved and one shipped, yet because they were already closed
            // (*i.e. not Closable), the order wouldn't close.  This is a specific check to handle that.
            if (!isclosed && lines.Count <= 0) //IF not closed here, yet no lines to close, check if the lines are already closed
                foreach (orddet_line l in DetailsList(context))
                {
                    if (l.Closed(context, OrderType, type))
                        lines.Add(l);
                }

        }

        public void ManualClose(ContextRz x, ordhed o)
        {

            string reCloseEmailMessage = "";
            try
            {
                //SendReCloseEmailAlert(x, reCloseEmailMessage);

                //Try to close normally.

                //If not successful, set isclosed = true;
                if (x.Leader.AreYouSure("want to manually close this order"))
                {
                    switch (o)
                    {
                        case ordhed_service os:
                            {
                                ManualCloseService(x, os, out reCloseEmailMessage);
                                break;
                            }
                        case ordhed_purchase op:
                            {
                                ManualClosePurchase(x, op, out reCloseEmailMessage);
                                break;
                            }
                    }

                }

                if (!string.IsNullOrEmpty(reCloseEmailMessage))
                    SendReCloseEmailAlert(x, reCloseEmailMessage);

            }
            catch (Exception ex)
            {

            }


        }

        private void ManualCloseService(ContextRz x, ordhed_service o, out string reCloseEmailMessage)
        {
            reCloseEmailMessage = "";
            string heading = "";
            string message = "";
            o.Ship(x);
            if (!o.isclosed)
            {
                heading = "SvcOrder#: " + o.ordernumber + " was re-closed.  Reason: <br />";
                reCloseEmailMessage = heading + "Service Order Closure Failed.";
            }
            if (message != null)
                reCloseEmailMessage = heading + message;


        }

        private void ManualClosePurchase(ContextRz x, ordhed_purchase p, out string reCloseEmailMessage)
        {
            reCloseEmailMessage = "";
            if (p.isclosed)
                return;
            p.PutAway(x);
            string heading;
            string message = "";
            if (!p.isclosed)
            {
                heading = "PO#: " + p.ordernumber + " was re-closed.  Reason: <br />";
                bool doReclose = false;

                //Check to see if these lines need to be tagged for received / put away, update if so
                CheckReceivedAndPutAway(x);

                //If all lines are OpenAndFilled, do clost
                if (ListOpenFilledLines(x, CloseType.Receive).Count == 0)
                {
                    //If this is Zero, it means that no lines are in a Closeable status, this could mean they are already closed as well.
                    //The above method contains another method that checks if the lines are closed for order type
                    //For Purchase orders, a line needs to be put_away OR was_received to be considered closed.
                    message = "No lines were in a closeable status.";
                    doReclose = true;
                }
                else
                {
                    //context.Leader.Tell("There are no lines to close");
                    if (!x.Leader.AskYesNo("There doesn't appear to be any closable lines.  Would you like to go through the lines and refresh the order status? (Click YES if you think this order's completion status is incorrect)."))
                        return;
                    else
                    {
                        //Shipped / Scrapped
                        if (AllLinesShippedOrScrapped(x))
                            if (x.Leader.AskYesNo("This order is not closed, yet all lines appear to be shipped or scrapped.  Should we close this PO and mark as received?  (Please be sure this is really the case, and contact IT if you aren't sure.)"))
                            {
                                doReclose = true;
                                message = "All lines shipped or scrapped.";
                            }
                        //Drop-ship Vendor RMA
                        if (OrderHasDropShipLines(x, p))
                        {
                            if (x.Leader.AskYesNo("Were the lines on this purchase order drop-ship VRMA from test house to the vendor?"))
                            {
                                doReclose = true;
                                message = "Lines were drop-shipped Vendor RMA";
                            }
                        }
                    }
                }
                if (doReclose)
                {
                    ForceClosePurchaseOrder(x);
                    reCloseEmailMessage = heading + message;
                }
                return;
            }

        }

        private void SendReCloseEmailAlert(ContextRz x, string reCloseEmailMessage)
        {
            nEmailMessage msg = new nEmailMessage();
            msg.IsHTML = true;
            msg.Subject = "Re-Close Email Alert.";
            msg.FromAddress = "rz@sensiblemicro.com";
            msg.ToAddress = "systems@sensiblemicro.com";
            msg.ToName = "Systems Management";
            //msg.ServerName = "smtp.sensiblemicro.com";
            //msg.ServerPort = 25;
            //msg.SSLRequired = false;
            msg.HTMLBody = reCloseEmailMessage;
            string error = "";
            msg.SetDefaultServer();
            msg.Send(ref error);







        }

        private bool AllLinesShippedOrScrapped(ContextRz x)
        {
            int shippedLinesCount = 0;
            foreach (orddet_line l in DetailsList(x))
            {
                if (l.status.ToLower().Contains("shipped") || l.status.ToLower() == Enums.OrderLineStatus.Scrapped.ToString().ToLower())
                    shippedLinesCount++;
            }
            if (shippedLinesCount == DetailsList(x).Count)
                return true;
            return false;
        }

        private bool OrderHasDropShipLines(ContextRz x, ordhed o)
        {
            bool ret = false;
            foreach (orddet_line l in o.DetailsList(x))
            {
                if (l.drop_ship)
                    ret = true;
            }
            return ret;
        }

        private void ForceClosePurchaseOrder(ContextRz x)
        {
            isclosed = true;
            this.Update(x);
            //is_received = true;  can be closed an not received

        }

        private void CheckReceivedAndPutAway(ContextRz x)
        {
            foreach (orddet_line l in this.DetailsList(x))
            {
                if (l.status == Enums.OrderLineStatus.Shipped.ToString())
                {
                    //bool changed = false;
                    if (!l.put_away)
                    {
                        if (x.Leader.AskYesNo("This line shows shipped, yet has no put-away flag, do you want to mark as Put Away?"))
                        {
                            l.put_away = true;
                            //changed = true;
                        }

                    }
                    if (!l.was_received)
                    {
                        if (x.Leader.AskYesNo("This line shows shipped, yet has no was_received flag, do you want to mark as already Received?"))
                        {
                            l.was_received = true;
                            //changed = true;
                        }
                    }
                    //if (changed)
                    //l.Update(x);

                }
            }
        }



        public void Close(ContextRz context, CloseType type, int throwTestErrorOn = -1)
        {
            List<orddet_line> lineList = ListOpenFilledLines(context, type);
            Close(context, type, lineList, throwTestErrorOn);
        }

        public virtual void Close(ContextRz context, CloseType closeType, List<orddet_line> linesToClose, int throwTestErrorOn = -1)
        {
            //if (lines.Count == 0)
            //{
            //    //context.Leader.Tell("There are no lines to close");
            //    if (!context.Leader.AskYesNo("There don't appear to be any closable lines.  Would you like to go through the lines and refresh the order status? (Click YES if you think this order's completion status is incorrect)."))
            //        return;
            //}
            try
            {
                //
                BeforeCloseCheck(context, linesToClose, closeType);
            }
            catch (Exception ex)
            {
                context.Leader.Tell(ex.Message);
                return;
            }

            PossibleArgs args = new PossibleArgs();
            Closeable(context, linesToClose, closeType, args);
            if (!args.Possible)
            {
                TellCloseNotPossible(context, closeType, args);
                return;
            }

            BeforeCloseFinal(context, linesToClose, closeType);

            ContextRz xx = (ContextRz)context.Clone();

            int closeIndex = 0;
            foreach (orddet_line line in linesToClose)
            {
                try
                {
                    xx.BeginTran();
                    line.CloseInTrans(xx, this.OrderType, closeType, closeIndex == throwTestErrorOn);

                    Double filledValue = line.CloseValue(this.OrderType, closeType);
                    if (filledValue != 0)
                        filled_total_Add(xx, filledValue);

                    xx.CommitTran();
                }
                catch (Exception ex)
                {
                    context.Leader.Tell("The close process failed; incomplete transactions will be rolled back.\r\n\r\n" + ex.Message);
                    Invalidate(context);
                    return;
                }

                closeIndex++;
            }

            AfterClose(context, linesToClose, closeType);

            //KT Added this because PO's were not getting closed properly nor marked as is_received.  This is a workaround, need to watch to make sure everything is smooth after.cs
            bool allLinesComplete = AllLinesComplete(context, linesToClose);
            if (allLinesComplete)
            {
                isclosed = true;
                is_received = true;
            }
            else
            {
                isclosed = false;
                is_received = false;
            }
            this.Update(context);

            context.TheLeader.Comment("Close update complete");
        }

        private bool AllLinesComplete(ContextRz x, List<orddet_line> linesToClose)
        {

            switch (this.OrderType)
            {
                case Enums.OrderType.Purchase:
                    {
                        foreach (orddet_line l in DetailsList(x))
                        {
                            if (!l.was_received || !l.put_away)
                                return false;
                        }
                        break;
                    }
                default:
                    {
                        if (DetailsList(x).Count != linesToClose.Count)
                            return false;
                        break;
                    }

            }


            return true;
        }

        //Posting

        public void Post(ContextRz context, int throwTestErrorOn = -1)
        {
            Post(context, ListPostableLines(context), throwTestErrorOn);
        }

        public void Post(ContextRz context, List<orddet_line> lines, int throwTestErrorOn = -1)
        {
            if (lines.Count == 0)
            {
                context.Leader.Tell("There are no lines to post");
                return;
            }

            //try
            //{
            //    BeforePost(context, lines, closeType);
            //}
            //catch (Exception ex)
            //{
            //    context.Leader.Tell(ex.Message);
            //    return;
            //}

            //PossibleArgs args = new PossibleArgs();
            //Postable(context, lines, args);
            //if (!args.Possible)
            //{
            //    context.Leader.Tell("Cannot post : " + args.Log.ToString());
            //    return;
            //}

            ContextRz xx = (ContextRz)context.Clone();

            int postIndex = 0;
            foreach (orddet_line line in lines)
            {
                try
                {
                    xx.BeginTran();
                    line.PostInTrans(xx, this.OrderType);

                    //if (postIndex == throwTestErrorOn)
                    //    throw new Exception("Test error");

                    //slip all of the expenses in with the first successful line transaction
                    if (!posted_expenses)
                    {
                        PostExpensesToTransaction(xx);
                        posted_expenses_Set(xx, true);
                    }

                    xx.CommitTran();
                }
                catch (Exception ex)
                {
                    context.Leader.Tell("The post process failed; incomplete transactions will be rolled back.\r\n\r\n" + ex.Message);
                    Invalidate(context);
                    return;
                }

                postIndex++;
            }

            //AfterPost(context, lines, closeType);
            context.Update(this);

            context.TheLeader.Comment("Post complete");
        }

        public List<orddet_line> ListPostableLines(ContextRz context)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                switch (OrderType)
                {
                    case Enums.OrderType.Invoice:
                    case Enums.OrderType.VendRMA:
                        if (!l.Closed(context, this.OrderType, CloseType.Ship))
                            continue;
                        break;
                    case Enums.OrderType.Purchase:
                    case Enums.OrderType.RMA:
                        if (!l.Closed(context, this.OrderType, CloseType.Receive))
                            continue;
                        break;
                    case Enums.OrderType.Service:
                        if (!l.Closed(context, this.OrderType, CloseType.Ship) && !l.Closed(context, this.OrderType, CloseType.Receive))
                            continue;
                        break;
                }
                switch (OrderType)
                {
                    case Enums.OrderType.Invoice:
                        if (!l.posted_invoice)
                            ret.Add(l);
                        break;
                    case Enums.OrderType.Purchase:
                        if (!l.posted_purchase)
                            ret.Add(l);
                        break;
                    case Enums.OrderType.Service:
                        if (!l.posted_service)
                            ret.Add(l);
                        break;
                    case Enums.OrderType.RMA:
                        if (!l.posted_rma)
                            ret.Add(l);
                        break;
                    case Enums.OrderType.VendRMA:
                        if (!l.posted_vendrma)
                            ret.Add(l);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            return ret;
        }

        public string PostStatus(ContextRz context)
        {
            List<orddet_line> postable = ListPostableLines(context);
            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (postable.Contains(l))
                    continue;
                if (l.isvoid || l.Status == Enums.OrderLineStatus.Void)
                    continue;
                switch (OrderType)
                {
                    case Enums.OrderType.Invoice:
                        if (!l.posted_invoice)
                            return "Partial";
                        break;
                    case Enums.OrderType.Purchase:
                        if (!l.posted_purchase)
                            return "Partial";
                        break;
                    case Enums.OrderType.Service:
                        if (!l.posted_service)
                            return "Partial";
                        break;
                    case Enums.OrderType.RMA:
                        if (!l.posted_rma)
                            return "Partial";
                        break;
                    case Enums.OrderType.VendRMA:
                        if (!l.posted_vendrma)
                            return "Partial";
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            return "Complete";
        }

        protected virtual void TellCloseNotPossible(ContextRz context, CloseType type, PossibleArgs args)
        {
            context.Leader.Tell("Cannot " + type.ToString().ToLower() + " : " + args.Log.ToString());

            String details = args.Details.ToString();
            if (details != "")
                context.Leader.ShowText(details);
        }

        protected virtual void SplitPartiallyFilledLines(ContextRz context, List<orddet_line> lines, CloseType closeType)
        {
            List<orddet_line> toSplit = new List<orddet_line>();
            foreach (orddet_line l in lines)
            {
                if (l.LineType != LineType.Inventory)
                    continue;

                int qFilled = l.QuantityClosable(context, OrderType, closeType);
                if (qFilled > 0 && qFilled < l.quantity)
                {
                    toSplit.Add(l);
                }
            }

            if (toSplit.Count == 0)
                return;

            bool removeUnFilled = (OrderType == Enums.OrderType.Invoice);

            if (removeUnFilled)
            {
                if (!context.Leader.AreYouSure("split and remove unfilled quantities on " + Tools.Strings.PluralizePhrase("line", toSplit.Count)))
                    throw new Exception("User canceled split");
            }
            else
            {
                if (!context.Leader.AreYouSure("split partial on " + Tools.Strings.PluralizePhrase("line", toSplit.Count)))
                    throw new Exception("User canceled split");
            }

            foreach (orddet_line l in toSplit)
            {
                int qFilled = l.QuantityClosable(context, OrderType, closeType);
                orddet_line rest = (orddet_line)l.Split(context, l.quantity - qFilled);
                rest.Status = Rz5.Enums.OrderLineStatus.Open;
                context.Update(rest);

                //remove rest
                if (removeUnFilled)
                    DetailsVar.RefsRemove(context, rest);
                rest.Status = Rz5.Enums.OrderLineStatus.Open;
                rest.Update(context);
            }
        }

        public virtual void RemoveUnFilledLines(ContextRz context, CloseType type, List<orddet_line> lines)
        {
            List<orddet_line> toRemove = ListOpenEmptyLines(context, type);

            if (toRemove.Count == 0)
                return;

            if (toRemove.Count == DetailsVar.RefsCount(context))
                throw new Exception("No lines on this order are shippable");

            if (!context.Leader.AreYouSure("Remove " + Tools.Strings.PluralizePhrase("line", toRemove.Count) + " un-filled lines from this invoice"))
                throw new Exception("User canceled");

            foreach (orddet_line l in toRemove)
            {
                DetailsVar.RefsRemove(context, l);
                l.Status = Rz5.Enums.OrderLineStatus.Open;
                l.Update(context);

                if (lines.Contains(l))
                    lines.Remove(l); //this is the live collection that will be used
            }
        }

        public int InventoryLineCount(ContextRz context)
        {
            int ret = 0;
            foreach (orddet_line l in DetailsVar.RefsList(context))
            {
                if (l.LineType == LineType.Inventory)
                    ret++;
            }
            return ret;
        }

        public List<orddet_line> DetailsListClosable(ContextRz context, CloseType type, PossibleArgs possibleArgs)
        {
            
            List<orddet_line> ret = new List<orddet_line>();
            List<orddet_line> linesWithAllProperties = new List<orddet_line>();
            //Add lines with no missing properties to the ready List
            foreach (orddet_line l in DetailsList(context))
                if (!MissingPropertiesList.ContainsKey(l))
                    linesWithAllProperties.Add(l);
            //For each line with no missing properties, check other logics.
            foreach (orddet_line l in linesWithAllProperties)
            {
                if (l.Closeable(context, OrderType, type, possibleArgs))
                    ret.Add(l);
            }
            return ret;
        }

        public List<orddet_line> ListOpenFilledLines(ContextRz context, CloseType type)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.OpenAndFilled(context, OrderType, type))
                    ret.Add(l);
            }
            return ret;
        }

        public List<orddet_line> ListOpenEmptyLines(ContextRz context, CloseType type)
        {
            List<orddet_line> ret = new List<orddet_line>();
            foreach (orddet_line l in DetailsList(context))
            {
                if (l.OpenAndEmpty(context, OrderType, type))
                    ret.Add(l);
            }
            return ret;
        }

        protected virtual void PrepareInventoryForShipping(ContextRz context, List<orddet_line> lines)
        {
            foreach (orddet_line l in lines)
            {
                if (l.LineType == LineType.Inventory)
                    l.PrepareForShipping(context, OrderType);
            }
        }

        public void CloseAndPayNoTrans(ContextRz context)
        {
            context.Execute("update " + TableName + " set isclosed = 1, ispaid = 1, filled_total = ordertotal, outstandingamount = 0, posted_expenses = 1 where unique_id = '" + unique_id + "'");
        }
    }

    public class VarRefOrderLinesNew : VarRefMany<ordhed, orddet_line>, IVarRefOrderLines
    {
        public ordhed TheOrder;

        public VarRefOrderLinesNew(ordhed o)
            : base(o, new CoreVarRefManyAttribute("Details", "Rz4.ordhed_" + o.OrderType.ToString().ToLower(), "Rz4.orddet_line", o.OrderType.ToString(), "orderid_" + o.OrderType.ToString().ToLower()))
        {
            TheOrder = o;
        }

        protected override QueryClass QueryCreate(Context context)
        {
            QueryClass q = new QueryClass("orddet_line");
            q.Where = new ExpressionBinaryOperator(new ExpressionIdentifier(TheAttributeRef.LinkField), BinaryOperatorType.Equality, new ExpressionLiteralString(TheOrder.unique_id));
            q.OrderBy.Add(((SysRz5)((ContextNM)context).xSys).TheOrderLogic.GetQueryClassOrder(TheOrder));
            return q;
        }

        public String DetailClass
        {
            get
            {
                return "orddet_line";
            }
        }

        public override void RefsAdd(Context x, IItems items, bool includeReverse)
        {
            base.RefsAdd(x, items, includeReverse);

            foreach (orddet_line l in items.AllGet(x))
            {
                TheOrder.DetailRefAdd((ContextRz)x, l);
            }
        }

        public override void RefsRemove(Context x, IItems items, bool do_reverse)
        {
            base.RefsRemove(x, items, do_reverse);
            foreach (orddet_line l in items.AllGet(x))
            {
                l.ValSet("orderid_" + TheOrder.OrderType.ToString().ToLower(), "");
                l.ValSet("ordernumber_" + TheOrder.OrderType.ToString().ToLower(), "");
                l.ValSet("linecode_" + TheOrder.OrderType.ToString().ToLower(), 0);
                x.Update(l);
            }
        }

        public override ShowArgs ShowArgsCreate(Context x, IItems items)
        {
            return new ShowArgsOrder(x, items, TheOrder.OrderType);
        }

    }

    public enum CloseType
    {
        Ship,
        Receive,
        DropShipServiceReceive, //For closing PO's when their drop-shipped lines get received for the 1st time on the service order.
        DropShipVendorRma //For closing PO's being drop-shipped from test house to vendor after test hour rejection
    }
}
