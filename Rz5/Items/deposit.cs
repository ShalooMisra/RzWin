using System;
using System.Collections.Generic;
using System.Text;

using Core;

namespace Rz5
{
    public partial class deposit : deposit_auto
    {
        public deposit()
        {

        }
        
        public static List<payment_in> ListPayments(ContextRz context)
        {
            List<payment_in> ret = new List<payment_in>();
            foreach (payment_in p in context.QtC("payment_in", "select * from payment_in where isnull(is_deposited, 0) = 0 order by date_created"))
            {
                ret.Add(p);
            }
            return ret;
        }

        public static void MakeDeposit(ContextRz context, account bankAccount, List<payment_in> payments, String memo)
        {
            Context xx = context.Clone();
            xx.BeginTran();

            deposit d = deposit.New(xx);
            d.name = memo;
            d.description = memo;
            d.account_full_name = bankAccount.full_name;
            d.account_name = bankAccount.name;
            d.account_number = bankAccount.number;
            d.account_uid = bankAccount.unique_id;
            d.Insert(xx);

            Double depositTotal = 0;
            foreach (payment_in p in payments)
            {
                p.DepositInTrans(context, bankAccount, d);
                depositTotal += p.amount;
            }

            d.total_amount = depositTotal;
            d.balance = bankAccount.balance + depositTotal;
            d.Update(xx);

            xx.CommitTran();
        }
    }
}
