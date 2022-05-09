using System;
using System.Collections.Generic;
using System.Text;

using Core;

namespace Rz5
{
    public partial class creditmemo_det : creditmemo_det_auto
    {
        public creditmemo_det()
        {

        }
        public override void Updating(Context x)
        {
            base.Updating(x);
            total_price = quantity * unit_price;
            string p = "";
            string b = "";
            PartObject.ParsePartNumber(fullpartnumber, ref p, ref b);
            prefixstripped = PartObject.StripPart(p);
            basenumberstripped = PartObject.StripPart(b);
        }
        public bool PostPossible(ContextRz context, PossibleArgs a)
        {
            if (!Tools.Strings.StrExt(account_uid))
            {
                a.LogAdd("There was no account associated with this detail line: " + linecode.ToString());
                a.Possible = false;
            }
            if (quantity <= 0)
            {
                a.LogAdd("There was no quantity associated with this detail line: " + linecode.ToString());
                a.Possible = false;
            }
            if (unit_price <= 0)
            {
                a.LogAdd("There was no price associated with this detail line: " + linecode.ToString());
                a.Possible = false;
            }
            return a.Possible;
        }
        public void PostCreditToTransaction(ContextRz context)
        {
            JournalEntry e = new JournalEntry("Credit Memo " + ordernumber);
            switch (Type)
            {
                case PaymentType.Customer:
                    e.Add(context, account_full_name, 0, total_price);
                    e.Add(context, "Accounts Receiveable", total_price, 0);
                    break;
                case PaymentType.Vendor:
                    e.Add(context, account_full_name, total_price, 0);
                    e.Add(context, "Accounts Payable", 0, total_price);
                    break;
                case PaymentType.CreditCard://not sure what to do here                    
                default:
                    throw new Exception("Credit Memo type: " + Type.ToString() + " not found.");
            }
            e.Post(context);
        }
        public PaymentType Type
        {
            get
            {
                if (type == "")
                    return PaymentType.Customer;
                PaymentType enumValue = (PaymentType)Enum.Parse(typeof(PaymentType), type.Replace(" ", ""));
                return enumValue;
            }
            set
            {
                type = Tools.Strings.NiceEnum(value.ToString());
            }
        }
        public void is_paid_Set(Context context, bool value)
        {
            this.is_paidVar.Value = value;
            context.Execute("update " + TableName + " set is_paid = " + Tools.Database.DataConnectionSqlServer.BoolFilter(value) + " where unique_id = '" + unique_id + "'");
        }
        public void applied_amount_Add(Context context, double value)
        {
            double d = this.applied_amount + value;
            this.applied_amountVar.Value = d;
            context.Execute("update " + TableName + " set applied_amount = " + d.ToString() + " where unique_id = '" + unique_id + "'");
        }
        public double Balance
        {
            get
            {
                return total_price - applied_amount;
            }
        }
    }
}
