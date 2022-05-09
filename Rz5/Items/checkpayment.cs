using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class checkpayment : checkpayment_auto
    {
        //Public Vairables
        private ordhed z_CurrentOrder = null;
        public ordhed CurrentOrder(ContextRz context)
        {
            if (!Tools.Strings.StrExt(base_ordhed_uid))
                return null;
            if (z_CurrentOrder == null)
                z_CurrentOrder = ordhed.GetById(context, base_ordhed_uid);
            return z_CurrentOrder;
        }

        public override void Updating(Context x)
        {
            base.Updating(x);
            transamount = CalcTotal();
        }

        public Double CalcTotal()
        {
            //KT 11-5-2015 - Removing feeamount Amoutn, we don't use
            //return subtotal + feeamount + handlingamount + taxamount;
            //KT 11-17-2015 - Need to round this up.
            return subtotal;
            //return System.Math.Ceiling(subtotal * 100) / 100;

        }

        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;

            switch (args.ActionName.ToLower().Trim())
            {
                //case "delete":
                //    this.IDelete();
                //    break;
                case "sendtoqb":
                    args.TheContext.TheLeader.StartPopStatus();
                    SendToQB(xrz);
                    args.TheContext.TheLeader.StopPopStatus(true);
                    break;
                case "applyfullpayment":
                    ApplyFullPayment(xrz);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }
        public override string ToString()
        {
            String s = "Payment";
            if (Tools.Strings.StrExt(referencedata))
                s += " [" + referencedata + "]";

            s += " from " + nTools.DateFormat(transdate);
            return s;
        }
        //Public Functions
        public Enums.TransactionType TransactionType
        {
            get
            {
                switch (transtype.ToLower().Trim())
                {
                    case "check":
                        return Enums.TransactionType.Check;
                    default:
                        return Enums.TransactionType.Payment;
                }
            }

            set
            {
                switch (value)
                {
                    case Enums.TransactionType.Check:
                        transtype = "Check";
                        break;
                    default:
                        transtype = "Payment";
                        break;
                }
            }
        }
        public bool SendToQB(ContextRz context)
        {
            return context.TheSysRz.TheQuickBooksLogic.SendCheckPayment(context, this);
        }
        private ordhed xOrder;
        public ordhed OrderObjectGet(ContextRz context)
        {
            if (xOrder == null)
            {
                xOrder = ordhed.GetById(context, this.base_ordhed_uid);
                return xOrder;
            }
            else
            {
                if (!Tools.Strings.StrCmp(this.base_ordhed_uid, xOrder.unique_id))
                    xOrder = ordhed.GetById(context, this.base_ordhed_uid);
                return xOrder;
            }
        }

        void OrderObjectSet(ordhed value)
        {
            xOrder = value;
            this.base_ordhed_uid = xOrder.unique_id;
        }

        //Private Functions
        protected virtual void ApplyFullPayment(ContextRz context)
        {
            //KT - Refactored from Rz5          
            if (CurrentOrder(context) == null)
                return;            
            //KT 11-17-2015 - Needs to be rounded up
            subtotal = CurrentOrder(context).ordertotal;
            //KT 4-8-2018 - found invoice # roudning down somehow.
            subtotal = Tools.Number.CommonSensibleRounding(subtotal);
        }

        private double GetFreeAmountPO(Rz5.ContextRz context, Rz5.ordhed CurrentOrder)
        {
            double d = 0;
            if (CurrentOrder == null)
                return 0;
            if (CurrentOrder.OrderType != Rz5.Enums.OrderType.Purchase)
                return 0;
            foreach (profit_deduction p in ((ordhed_purchase)CurrentOrder).DeductionsVar.RefsList(context))
            {
                if (p.include_on_po)
                    d += p.amount;
            }
            return d;
        }


    }
}
