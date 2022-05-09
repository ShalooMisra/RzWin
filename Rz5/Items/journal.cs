using System;
using System.Collections.Generic;
using System.Text;

using Core;

namespace Rz5
{
    public partial class journal : journal_auto
    {
        public journal()
        {

        }

        account m_Account;
        public account Account
        {
            get
            {
                return m_Account;
            }

            set
            {
                m_Account = value;
                account_id = value.Uid;
                account_name = value.name;
                account_number = value.number;
                //type = Tools.Strings.NiceEnum(value.Type.ToString());
                Type = value.Type;
            }
        }

        public AccountType Type
        {
            get
            {
                if (type == "")
                    return AccountType.Null;
                AccountType enumValue = (AccountType)Enum.Parse(typeof(AccountType), type.Replace(" ", ""));
                return enumValue;
            }
            set
            {
                type = Tools.Strings.NiceEnum(value.ToString());
            }
        }

        public static journal CreateNoInsert(ContextRz context, account acct, Double debit, Double credit)
        {
            if (acct == null)
                throw new Exception("Account used for journal is null");

            journal ret = journal.New(context);
            ret.Account = acct;
            ret.debit_amount = debit;
            ret.credit_amount = credit;
            return ret;
        }

        public bool Increasing
        {
            get
            {
                switch (Account.Category)
                {
                    case AccountCategory.Other:
                        throw new Exception(Account.category + " is not relevant here");
                    case AccountCategory.Asset:
                    case AccountCategory.Expense:
                        return debit_amount > 0;
                    default:
                        return credit_amount > 0;
                }
            }
        }

        public Double Amount
        {
            get
            {
                if (debit_amount != 0)
                    return debit_amount;
                else
                    return credit_amount;
            }
        }
    }
}
