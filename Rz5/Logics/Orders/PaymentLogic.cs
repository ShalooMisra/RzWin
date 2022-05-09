using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewMethod;
using Core;
using System.Collections;

namespace Rz5
{
    public class PaymentLogic : NewMethod.Logic
    {
        public override void ActsListStatic(Context x, ActSetup set)
        {
            ContextRz xrz = (ContextRz)x;

            base.ActsListStatic(x, set);
            if (!xrz.TheSysRz.ThePermitLogic.CheckPermit(xrz, Permissions.ThePermits.ViewAR_APScreen, ((ContextRz)x).xUser))
                return;
            if (xrz.Accounts.Enabled)
                return;
            ActHandle h = new ActHandle(new Act("AR/AP", new ActHandler(PaymentsShow)));
            set.Add(h);
            if (xrz.xUser.CheckPermit(xrz, "Accounting:Post:PostToQB"))
            {
                ActHandle hq = new ActHandle(new Act("Post To Quickbooks"));
                h.SubActs.Add(hq);
                hq.SubActs.Add(new ActHandle(new Act("Invoices", new ActHandler(PostQBInvoice))));
                hq.SubActs.Add(new ActHandle(new Act("Purchases", new ActHandler(PostQBPurchase))));
                hq.SubActs.Add(new ActHandle(new Act("RMAs", new ActHandler(PostQBRMA))));
                hq.SubActs.Add(new ActHandle(new Act("Vendor RMAs", new ActHandler(PostQBVendRMA))));
            }
            if (((ContextRz)x).xUser.IsDeveloper())
            {
                ActHandle ah = new ActHandle(new Act("Import From QBs", new ActHandler(ImportFromQBs)));
                h.SubActs.Add(ah);
            }
        }
        public void PaymentsShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).PaymentScreenShow((ContextRz)x);
            args.Result(true);
        }
        public void PostQBInvoice(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).PostQBShow((ContextRz)x, Enums.OrderType.Invoice);
            args.Result(true);
        }
        public void PostQBPurchase(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).PostQBShow((ContextRz)x, Enums.OrderType.Purchase);
            args.Result(true);
        }
        public void PostQBRMA(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).PostQBShow((ContextRz)x, Enums.OrderType.RMA);
            args.Result(true);
        }
        public void PostQBVendRMA(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).PostQBShow((ContextRz)x, Enums.OrderType.VendRMA);
            args.Result(true);
        }
        public void ImportFromQBs(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ImportFromQB((ContextRz)x);
        }

        //KT Transfer Payments to new Ordhed
        public void TransferPayments(checkpayment p, ordhed_invoice i)
        {
            //
            //
        }
    }

    public interface IPaymentScreen
    {
        void ShowOrder(ordhed o);
    }

    public interface IPayment
    {
        String unique_id { get; set; }
        void SetCompany(company comp);
        Double amount { get; set; }
        String description { get; set; }
        void Insert(Context x);
        void Update(Context x, bool inhibitNotify = false);
        void Invalidate(Context x);
    }

    public enum PaymentType
    {
        Customer,
        Vendor,
        CreditCard,
    }




    public class PaymentBatch
    {
        public PaymentType BatchType;
        public company Company;
        public Double Amount;
        public String Memo = "";
        public String Method = "";
        public List<PaymentBatchDetail> Details = new List<PaymentBatchDetail>();
        public List<creditmemo_det> Credits = new List<creditmemo_det>();
        public account Account;
        public String PayID = "";

        public PaymentBatch(ContextRz context, PaymentType type, company company)
        {
            BatchType = type;
            SetCompany(context, company);
            GatherDetails(context);
        }

        public void SetCompany(ContextRz context, company company)
        {
            Company = company;
            GatherDetails(context);
        }

        public void GatherDetails(ContextRz context)
        {
            Details.Clear();
            
            if (Company == null)                
                return;

            //Details.Add(new PaymentBatchDetail(this, null));

            String orderType = "";
            switch (BatchType)
            {
                case PaymentType.Customer:
                    orderType = "ordhed_invoice";
                    break;
                case PaymentType.Vendor:
                    orderType = "ordhed_purchase";
                    break;
            }

            //ArrayList orders = context.QtC(orderType, "select * from " + orderType + " where base_company_uid = '" + Company.unique_id + "' and isnull(isclosed, 0) = 1 and isnull(ispaid, 0) = 0 and isnull(isvoid, 0) = 0 order by orderdate");
            ArrayList orders = context.QtC(orderType, "select * from " + orderType + " where base_company_uid = '" + Company.unique_id + "' and isnull(ispaid, 0) = 0 and isnull(isvoid, 0) = 0 order by orderdate");
            foreach (ordhed_new o in orders)
            {
                Details.Add(new PaymentBatchDetail(this, o));
            }
        }

        public String BalanceCaption
        {
            get
            {
                if (Company == null)
                    return "";

                switch (BatchType)
                {
                    case PaymentType.Customer:
                        return "Customer Balance: " + Tools.Number.MoneyFormat(Company.balance_owed_customer);
                    case PaymentType.Vendor:
                        return "Vendor Balance: " + Tools.Number.MoneyFormat(Company.balance_owed_vendor);
                    default:
                        return "";
                }
            }
        }

        public String AppliedCaption
        {
            get
            {
                return "Applied: " + Tools.Number.MoneyFormat(DetailTotal);
            }
        }

        public String OpenCaption
        {
            get
            {
                return "Open: " + Tools.Number.MoneyFormat(Amount - DetailTotal);
            }
        }

        public bool Valid(ref String instruction)
        {
            if (Company == null)
            {
                string comp = "company";
                if (BatchType == PaymentType.Vendor)
                    comp = "vendor";
                instruction = "Select a " + comp;
                return false;
            }
            if (Amount <= 0)
            {
                instruction = "Enter a payment amount";
                return false;
            }

            if (Amount != DetailTotal)
            {
                instruction = "The entire amount of " + Tools.Number.MoneyFormat(Amount) + " must be applied";
                return false;
            }

            if (BatchType == PaymentType.Vendor && Account == null)
            {
                instruction = "Select an account";
                return false;
            }

            return true;
        }

        public Double DetailTotal
        {
            get
            {
                Double ret = 0;
                foreach (PaymentBatchDetail d in Details)
                {
                    ret += d.Amount;
                }
                return ret;
            }
        }

        public Double CreditTotal
        {
            get
            {
                Double ret = 0;
                foreach (creditmemo_det d in Credits)
                {
                    ret += d.Balance;
                }
                return ret;
            }
        }

        public Double OrderTotal
        {
            get
            {
                Double ret = 0;
                foreach (PaymentBatchDetail d in Details)
                {
                    if (d.Order == null)
                        continue;

                    ret += d.Amount;
                }
                return ret;
            }
        }

        public void Post(ContextRz context)
        {
            String inst = "";
            if (!Valid(ref inst))
                throw new Exception(inst);

            switch (BatchType)
            {
                case PaymentType.Customer:
                    PostCustomer(context);
                    break;
                default:
                    PostVendor(context);
                    break;
            }
        }

        void PostCustomer(ContextRz context)
        {
            ContextRz xx = (ContextRz)context.Clone();
            xx.BeginTran();

            payment_in pin = payment_in.New(context);
            pin.description = Memo;
            pin.payment_method = Method;
            pin.SetCompany(Company);
            pin.Insert(xx);

            foreach (PaymentBatchDetail d in Details)
            {
                if (d.Amount <= 0)
                    continue;

                //get a fresh db copy for now
                company c = company.GetById(context, Company.unique_id);
                if (c == null)
                    throw new Exception("Company not found");

                if (d.Order == null)
                    c.ApplyAdvancePaymentInTrans(xx, Memo, d.Amount);
                else
                    ((ordhed_invoice)d.Order).ApplyPaymentInTrans(xx, d.Amount, pin, c, d.Order.CashAccount(context));  //get fresh company copy from the db
            }

            xx.CommitTran();
        }

        void PostVendor(ContextRz context)
        {
            ContextRz xx = (ContextRz)context.Clone();
            xx.BeginTran();

            payment_out pout = payment_out.New(context);
            pout.description = Memo;
            pout.account_full_name = Account.full_name;
            pout.account_name = Account.name;
            pout.account_number = Account.number;
            pout.account_uid = Account.unique_id;
            pout.payment_method = Method;
            pout.SetCompany(Company);
            pout.Insert(xx);

            foreach (PaymentBatchDetail d in Details)
            {
                if (d.Amount <= 0)
                    continue;
                if (((ordhed_purchase)d.Order).is_credit)
                {
                    Company.ApplyVendorCreditInTrans(xx, Memo, d.Amount, Account);
                    ((ordhed_purchase)d.Order).amount_paid_Add(xx, d.Amount);
                }
                else
                    ((ordhed_purchase)d.Order).ApplyPaymentInTrans(xx, d.Amount, pout, Company, Account);
            }
            pout.balance = Account.balance - pout.amount;
            pout.Update(xx);
            PayID = pout.unique_id;
            xx.CommitTran();
        }
    }


    public class PaymentBatchDetail
    {
        PaymentBatch Batch;
        public ordhed_new Order;
        public Double Amount;

        public PaymentBatchDetail(PaymentBatch batch, ordhed_new order)
        {
            Batch = batch;
            Order = order;
        }

        public void ChangeAmount(ContextRz context)
        {
            Double amountToShow = 0;
            if (Order != null)
                amountToShow = Order.outstandingamount;
            else
                amountToShow = Batch.Amount - Batch.OrderTotal;

            bool cancel = false;
            Double paymentAmount = context.Leader.AskForDouble("Payment amount to apply", amountToShow, "Payment amount", ref cancel);
            if (cancel)
                return;

            if (Order != null)
            {
                if (paymentAmount > Order.outstandingamount)
                {
                    context.Leader.Tell("The amount entered is more than the outstanding amount of the order");
                    return;
                }
            }

            Amount = paymentAmount;
        }

        public void ShowOrder(ContextRz context)
        {
            if (Order == null)
                return;

            context.Show(Order);
        }
    }
}
