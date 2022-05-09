using System;
using System.Collections.Generic;
using System.Text;

using Core;
using System.Collections;
using NewMethod;

namespace Rz5
{
    //Increasing means...
    //Asset accounts - debit
    //Liability accounts - credit
    //Owner's equity - credit
    //Revenue/Income accounts - credit
    //Expense accounts - debit

    public partial class account : account_auto
    {
        //Public Variables
        private List<account> SubAccounts;

        //Constructors
        public account()
        {
        }
        //Public Override Functions
        public override string ToString()
        {
            return name + " [" + type.ToString() + "] Bal: " + Tools.Number.MoneyFormat(balance);
        }
        public override void  Updating(Context x)
        {
 	        base.Updating(x);
            if (Category == AccountCategory.Other)
                Category = InferCategory(Type);
            if( Tools.Strings.StrExt(parent_name) )
                full_name = parent_name + ":" + name;
            else
                full_name = name;
        }        
        //Public Functions
        public List<account> SubAccountsList(ContextRz context, bool force_recache = false)
        {
            if (SubAccounts == null)
                force_recache = true;
            if (force_recache)
            {
                SubAccounts = new List<account>();
                ArrayList a = context.QtC("account", "select * from account where parent_id = '" + this.Uid + "'");
                foreach (account ac in a)
                {
                    SubAccounts.Add(ac);
                }
            }
            return SubAccounts;                       
        }
        public void SubAccountsListAdd(ContextRz context, account a)
        {
            if (SubAccounts == null)
                SubAccounts = new List<account>();
            SubAccounts.Add(a);
        }
        public void SubAccountsListSet(ContextRz context, List<account> list)
        {
            SubAccounts = list;
        }

        public void RecordPayment(ContextRz context, account pay_to, company c, double amnt, string reference, string memo, DateTime asof)
        {
            RecordPayment(context, this, pay_to, c, amnt, reference, memo, asof, true);//Posting
            if (pay_to.Type == AccountType.Bank)//Add entry for this bank account
                RecordDeposit(context, this, pay_to, c, amnt, reference, memo, asof, false);//Non-Posting
        }
        public void RecordDeposit(ContextRz context, account deposit_from, company c, double amnt, string reference, string memo, DateTime asof)
        {
            RecordDeposit(context, deposit_from, this, c, amnt, reference, memo, asof, true);//Posting
            if (deposit_from.Type == AccountType.Bank)//Add entry for this bank account
                RecordPayment(context, deposit_from, this, c, amnt, reference, memo, asof, false);//Non-Posting
        }
        private void RecordPayment(ContextRz context, account pay_from, account pay_to, company c, double amnt, string reference, string memo, DateTime asof, bool post)
        {
            payment_out p = new payment_out();
            p.account_name = pay_from.full_name;
            p.account_uid = pay_from.unique_id;
            p.account_number = pay_from.number;
            p.dest_account_name = pay_to.full_name;
            p.dest_account_uid = pay_to.unique_id;
            p.dest_account_number = pay_to.number;
            p.amount = amnt;
            if (Tools.Strings.StrExt(reference))
            {
                if (Tools.Number.IsNumeric(reference))
                    p.check_number = Convert.ToInt32(reference);
                else
                    p.reference_number = reference;
            }
            p.description = memo;
            if (c != null)
            {
                p.vendor_uid = c.unique_id;
                p.vendor_name = c.companyname;
            }
            p.Insert(context);
            if (post)
            {
                JournalEntry j = new JournalEntry(p.description);
                j.Add(context, pay_from, 0, p.amount);
                j.Add(context, pay_to, p.amount, 0);
                j.Post(context);
            }
            account a = account.GetById(context, pay_from.unique_id);
            p.balance = a.balance;
            p.date_created = asof;
            p.Update(context);
        }
        private void RecordDeposit(ContextRz context, account deposit_from, account deposit_to, company c, double amnt, string reference, string memo, DateTime asof, bool post)
        {
            deposit d = new deposit();
            d.account_name = deposit_to.full_name;
            d.account_uid = deposit_to.unique_id;
            d.account_number = deposit_to.number;
            d.dest_account_name = deposit_from.full_name;
            d.dest_account_uid = deposit_from.unique_id;
            d.dest_account_number = deposit_from.number;
            d.description = memo;
            d.name = reference;
            d.total_amount = amnt;
            if (c != null)
            {
                d.vendor_uid = c.unique_id;
                d.vendor_name = c.companyname;
            }
            d.Insert(context);
            if (post)
            {
                JournalEntry j = new JournalEntry(d.description);
                j.Add(context, deposit_to, d.total_amount, 0);
                j.Add(context, deposit_from, 0, d.total_amount);
                j.Post(context);
            }
            account a = account.GetById(context, deposit_to.unique_id);
            d.balance = a.balance;
            d.date_created = asof;
            d.Update(context);
        }

        public static string GetAccountFullNameStripBullet(string account_name)
        {
            if (!account_name.Contains("■"))
                return account_name;
            return Tools.Strings.ParseDelimit(account_name, "■", 2).Trim();
        }
        public static string GetAccountFullNameWithBullet(account a)
        {
            string s = "";
            if (a.number != 0)
                s = a.number.ToString() + " ■ ";
            s += a.full_name;
            return s;
        }
        public static string GetAccountFullNameWithBullet(budget_account a)
        {
            account aa = new account();
            aa.full_name = a.account_fullname;
            aa.number = a.account_number;
            return GetAccountFullNameWithBullet(aa);
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

        public AccountCategory Category
        {
            get
            {
                if (category == "")
                    return AccountCategory.Other;

                AccountCategory enumValue = (AccountCategory)Enum.Parse(typeof(AccountCategory), category.Replace(" ", ""));
                return enumValue;
            }
            set
            {
                category = Tools.Strings.NiceEnum(value.ToString());
            }
        }

        public double Balance(ContextRz context)
        {
            double d = balance;

            foreach (account a in SubAccountsList(context))
            {
                d += a.Balance(context);
            }
            return d;
        }

        public account Find(ContextRz context, String fullNameOrId)
        {
            if (!Tools.Strings.StrExt(fullNameOrId))
                return null;

            if (Tools.Strings.StrCmp(unique_id, fullNameOrId))
                return this;

            if (Tools.Strings.StrCmp(full_name, fullNameOrId))
                return this;

            foreach (account a in SubAccountsList(context))
            {
                account ret = a.Find(context, fullNameOrId);
                if (ret != null)
                    return ret;
            }

            return null;
        }

        public String FormattedNumber
        {
            get
            {
                return Tools.Strings.Right("00000" + number.ToString(), 5);
            }
        }

        public void SetTypeAndCategory(String newType)
        {
            if (newType == "")
            {
                Type = AccountType.Null;
                Category = AccountCategory.Other;
                return;
            }

            AccountType enumValue = (AccountType)Enum.Parse(typeof(AccountType), newType.Replace(" ", ""));
            Type = enumValue;
            Category = InferCategory(Type);            
        }

        public static account CreateNewAccount(ContextRz context)
        {
            return CreateNewAccount(context, "");
        }
        public static account CreateNewAccount(ContextRz context, string parent_id)
        {
            account a = context.TheLeaderRz.AskForNewAccount(context, parent_id);
            if (a == null)
                return null;
            if (a.Type == AccountType.Null)
            {
                context.TheLeader.Tell("You must enter an account type for this new account.");
                return null;
            }
            if (!Tools.Strings.StrExt(a.full_name))
            {
                context.TheLeader.Tell("You must enter a name for this new account.");
                return null;
            }
            if (a.number == 0)
            {
                context.TheLeader.Tell("You must enter a number for this new account.");
                return null;
            }
            string id = "";
            if (a.number != 0)
            {
                id = context.SelectScalarString("select unique_id from account where number = " + a.number.ToString());
                if (Tools.Strings.StrExt(id))
                {
                    context.TheLeader.Tell("There is already an account with the number " + a.number.ToString() + ".");
                    return null;
                }
            }
            id = context.SelectScalarString("select unique_id from account where full_name = '" + context.Filter(a.full_name) + "'");
            if (Tools.Strings.StrExt(id))
            {
                context.TheLeader.Tell("There is already an account with the name " + a.full_name + ".");
                return null;
            }
            a.Insert(context);
            context.Accounts.InitAccounts(context);
            return a;
        }
        public int GetNextSubAccountNumber(ContextRz context)
        {
            try
            {
                String accountNumberBase = FormattedNumber;
                char[] ary = accountNumberBase.ToCharArray();
                int spot = ary.Length - 2;
                if (Tools.Strings.StrExt(parent_id))
                    spot = ary.Length - 1;
                string s = ary[spot].ToString();
                int count = SubAccountsList(context).Count + 1;
                if (count > 9)
                    return 0;
                ary[spot] = count.ToString().ToCharArray()[0];
                string build = "";
                foreach (char c in ary)
                {
                    build += c.ToString();
                }
                return Convert.ToInt32(build.Trim());
            }
            catch { }
            return 0;
        }

        public ListArgs SubAccountArgs(ContextRz context)
        {
            ListArgs ret = new ListArgs(context);
            ret.TheTable = "account";
            ret.TheWhere = "parent_id = '" + unique_id + "'";
            ret.TheOrder = "number";
            ret.TheTemplate = "sub_accounts";
            ret.TheClass = "account";
            ret.AddAllow = true;
            ret.AddCaption = "Add a Sub-Account";
            return ret;
        }

        public void ClearParent()
        {
            parent_id = "";
            parent_name = "";
        }

        public void SetParent(account parent)
        {
            parent_id = parent.unique_id;
            parent_name = parent.full_name;
        }

        public account GetParent(ContextRz context)
        {
            return context.Accounts.GetAccount(context, parent_id);
        }

        public bool HasParent
        {
            get
            {
                return Tools.Strings.StrExt(parent_id);
            }
        }

        public static AccountCategory InferCategory(AccountType acctType)
        {
            switch (acctType)
            {
                case AccountType.Bank:
                case AccountType.AccountsReceivable:
                case AccountType.OtherCurrentAssets:
                case AccountType.FixedAssets:
                case AccountType.OtherAssets:
                    return AccountCategory.Asset;
                case AccountType.AccountsPayable:
                case AccountType.CreditCard:
                case AccountType.OtherCurrentLiabilities:
                case AccountType.LongTermLiabilities:
                    return AccountCategory.Liability;
                case AccountType.Equity:
                    return AccountCategory.Equity;
                case AccountType.Income:
                case AccountType.OtherIncome:
                    return AccountCategory.Income;
                case AccountType.Expense:
                case AccountType.CostOfGoodsSold:
                case AccountType.OtherExpense:
                    return AccountCategory.Expense;
                default:
                    return AccountCategory.Other;
            }
        }

        public void ShowAccountReport(ContextRz context)
        {
            context.Leader.ReportShow(context, new Reports.AccountDetail(context, this), true);            
        }

        public void ShowCheckRegister(ContextRz context)
        {
            context.Leader.CheckRegisterShow(context, this);
        }

        public bool DeletePossible(ContextRz context, ref String reason)
        {
            if (!base.DeletePossible(context))
            {
                reason = "base returned false";
                return false;
            }

            if (built_in)
            {
                reason = ToString() + " is a built-in account";
                return false;
            }

            if (context.SelectScalarInt32("select count(*) from journal where account_id = '" + unique_id + "'") > 0)
            {
                reason = ToString() + " is involved in journal transactions";
                return false;
            }

            if (balance != 0)
            {
                //this should never happen without journal entries
                reason = ToString() + " has a balance";
                return false;
            }

            return true;
        }

        public void SetStartingBankBalance(ContextRz context)
        {
            bool canceled = false;
            Double amount = context.Leader.AskForDouble("Starting balance for " + ToString(), 0, "Starting balance", ref canceled);
            if (canceled || amount == 0)
                return;

            DateTime asOf = context.Leader.AskForDate("Balance as of", DateTime.Now);
            if (!Tools.Dates.DateExists(asOf))
                return;

            SetStartingBankBalance(context, amount, asOf);
        }

        public void SetStartingBankBalance(ContextRz context, Double amount, DateTime asOf)
        {
            JournalEntry entry = new JournalEntry("Starting balance for " + ToString());
            entry.Add(context, this, amount, 0);
            entry.Add(context, context.Accounts.GetAccount(context, "Opening Balance Equity"), 0, amount);
            entry.Post(context, asOf);
            deposit d = new deposit();            
            d.account_name = full_name;
            d.account_uid = unique_id;
            d.account_number = number;
            d.cleared = true;
            d.description = "Starting Balance";
            d.total_amount = amount;
            d.balance = amount;
            d.Insert(context);
            d.date_created = asOf;
            d.Update(context);                
        }

        public String GetExtra(String key)
        {
            Dictionary<String, String> extra = ParseExtra;
            if (extra.ContainsKey(key.ToLower()))
                return extra[key.ToLower()];
            else
                return "";
        }

        public void SetExtra(String key, String value)
        {
            if (value.Contains("\r") || value.Contains("\n") || value.Contains("\t"))
                throw new Exception("Cannot set extra values with newlines or tabs");

            Dictionary<String, String> extra = ParseExtra;
            if (extra.ContainsKey(key.ToLower()))
                extra[key.ToLower()] = value;
            else
                extra.Add(key.ToLower(), value);
            SetExtra(extra);
        }

        Dictionary<String, String> ParseExtra
        {
            get
            {
                Dictionary<String, String> ret = new Dictionary<string, string>();
                foreach (String line in Tools.Strings.SplitLinesList(extra_info))
                {
                    if (!Tools.Strings.StrExt(line))
                        continue;

                    ret.Add(Tools.Strings.ParseDelimit(line, "\t", 1).ToLower(), Tools.Strings.ParseDelimit(line, "\t", 2));
                }
                return ret;
            }
        }

        public static account GetByFullName(Context x, String full_name)
        {
            return (account)x.QtO("account", "select * from account where full_name = '" + x.Filter(full_name) + "'");
        }

        void SetExtra(Dictionary<String, String> values)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<String, String> k in values)
            {
                sb.AppendLine(k.Key + "\t" + k.Value);
            }
            extra_info = sb.ToString();
        }

        public DateTime GetLastReconcileDate(ContextRz x)
        {
            return x.GetSettingDateTime(unique_id + "_last_reconciled_date");
        }
        public void SetLastReconcileDate(ContextRz x, DateTime d)
        {
            x.SetSettingDateTime(unique_id + "_last_reconciled_date", d);
        }

        public List<account> ListWithSubAccounts(ContextRz x)
        {
            List<account> ret = new List<account>();
            ret.Add(this);
            AppendSubAccounts(x, ret);
            return ret;
        }

        private void AppendSubAccounts(ContextRz x, List<account> accounts)
        {
            if (SubAccountsList(x).Count <= 0)
                return;
            foreach (account a in SubAccountsList(x))
            {
                accounts.Add(a);
                a.AppendSubAccounts(x, accounts);
            }
        }

        public static int EditAccountNumber(ContextRz x, account a)
        {
            int d = a.number;
            int n = x.TheLeader.AskForInt32("Enter the new account number below.", d, "New Account Number");
            if (n == d)
                return d;
            if (n == 0)
            {
                x.TheLeader.Tell("Account number cannot be zero.");
                return d;
            }
            string id = x.SelectScalarString("select unique_id from account where unique_id != '" + a.unique_id + "' and number = " + n.ToString());
            if (Tools.Strings.StrExt(id))
            {
                x.TheLeader.Tell("An account already exists with this account number.");
                return d;
            }
            return n;
        }
    }
    public class AccountGroup
    {
        public string Name = "";
        public List<account> Accounts = new List<account>();
        public List<AccountGroup> SubGroups = new List<AccountGroup>();
        public AccountCategory SubCategory = AccountCategory.Other;
        public AccountType SubType = AccountType.Null;

        public AccountGroup(ContextRz context, String name, AccountCategory category = AccountCategory.Other, AccountType type = AccountType.Null)
        {
            Name = name;
            SubCategory = category;
            SubType = type;
        }        
        public void GatherAccounts(ContextRz context)
        {
            Accounts = new List<account>();
            if (SubType == AccountType.Null)
            {
                foreach(AccountGroup ag in SubGroups)
                {
                    ag.GatherAccounts(context);
                }
                return;
            }
            ArrayList a = context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(SubType.ToString()) + "' and len(isnull(parent_id,'')) <= 0 order by number, full_name");
            foreach (account ac in a)
            {
                if (ac.Category != SubCategory)
                {
                    ac.Category = SubCategory;
                    ac.Update(context);
                }
                Accounts.Add(ac);
            }
        }
        public override string ToString()
        {
            string s = Name;
            if (Accounts.Count > 0)
                s += " [" + Accounts.Count.ToString() + "]";
            return s;
        }
        public Double GroupTotal(ContextRz context)
        {
            double d = 0;
            foreach (AccountGroup ag in SubGroups)
            {
                d += ag.GroupTotal(context);
            }
            foreach (account a in Accounts)
            {
                d += a.Balance(context);
            }
            return d;
        }

        public account Find(ContextRz context, String fullNameOrId)
        {
            if (!Tools.Strings.StrExt(fullNameOrId))
                return null;

            foreach (AccountGroup g in SubGroups)
            {
                account ret = g.Find(context, fullNameOrId);
                if (ret != null)
                    return ret;
            }

            foreach (account a in Accounts)
            {
                account ret = a.Find(context, fullNameOrId);
                if (ret != null)
                    return ret;
            }

            return null;
        }

        public void Find(ContextRz context, AccountCriteria criteria, List<account> result)
        {
            foreach (account a in Accounts)
            {
                if (criteria.Matches(a))
                    result.AddRange(a.ListWithSubAccounts(context));
            }

            foreach (AccountGroup g in SubGroups)
            {
                g.Find(context, criteria, result);
            }
        }
    }

    public class AccountCriteria
    {
        public AccountRetrieval RetrievalType;
        public List<AccountCategory> Categories = new List<AccountCategory>();
        public List<AccountType> Types = new List<AccountType>();

        public AccountCriteria(AccountRetrieval rtype = AccountRetrieval.NonHidden)
        {
            RetrievalType = rtype;
        }
        public AccountCriteria(AccountCategory category, AccountRetrieval rtype = AccountRetrieval.NonHidden)
        {
            RetrievalType = rtype;
            Categories.Add(category);
        }
        public AccountCriteria(AccountType type, AccountRetrieval rtype = AccountRetrieval.NonHidden)
        {
            RetrievalType = rtype;
            Types.Add(type);
        }
        public bool Matches(account a)
        {
            if (Categories.Count > 0)
            {
                if (!Categories.Contains(a.Category))
                    return false;
            }
            if (Types.Count > 0)
            {
                if (!Types.Contains(a.Type))
                    return false;
            }
            switch (RetrievalType)
            {
                case AccountRetrieval.All:
                    return true;
                case AccountRetrieval.NonHidden:
                    return !a.is_hidden;
                case AccountRetrieval.OnlyHidden:
                    return a.is_hidden;
                default:
                    return true;
            }
        }
    }
    public enum AccountRetrieval
    {
        All,
        NonHidden,
        OnlyHidden,
    }
    public enum AccountCategory
    {
        Asset,
        Liability,
        Equity,
        Income,
        Expense,
        Other
    }

    public enum AccountType
    {
        Null,

        //Assets
		Bank,
		AccountsReceivable,
		OtherCurrentAssets,
        FixedAssets,
		OtherAssets,

        //Liabilities
        AccountsPayable,
		CreditCard,
		OtherCurrentLiabilities,
		LongTermLiabilities,

		//Equity
        Equity,

        //Profit/Loss [Income Statement]
        Income,
        OtherIncome,
        CostOfGoodsSold,
        Expense,
        OtherExpense,
    }
}
