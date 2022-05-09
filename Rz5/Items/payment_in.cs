using System;
using System.Collections.Generic;
using System.Text;

using Core;

namespace Rz5
{
    public partial class payment_in : payment_in_auto, IPayment
    {
        public payment_in()
        {            
        }

        public void SetCompany(company comp)
        {
            customer_uid = comp.unique_id;
            customer_name = comp.companyname;
        }

        public void DepositInTrans(ContextRz context, account bankAccount, deposit deposit)
        {
            deposit_name = deposit.name;
            deposit_uid = deposit_uid;
            is_deposited = true;
            Update(context);

            JournalEntry entry = new JournalEntry(deposit.description + "-" + description);
            entry.Add(context, bankAccount, amount, 0);
            entry.Add(context, "Undeposited Funds", 0, amount);
            entry.Post(context);
        }
    }
}
