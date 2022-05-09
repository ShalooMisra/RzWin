using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Tools.Database;

namespace Rz5.Reports
{
    public class AccountDetail : Rz5.Report
    {
        account Account;
        public AccountDetail(ContextRz context, account accountToUse) : base(context)
        {
            Account = accountToUse;
        }

        public override Core.Report Clone(Context context)
        {
            //return base.Clone(context);
            return new AccountDetail((ContextRz)context, Account);
        }

        protected override void InitColumns(Core.Context context)
        {
            ColumnAdd("Date");
            ColumnAdd("Memo");
            ColumnAdd("Split");
            ColumnAdd("Amount", ValueUse.TotalMoney);
        }

        protected override void InitTotals()
        {
            base.InitTotals();
            AutoTotal("Total", "Amount");
        }

        public override void CalculateLines(Context context, ReportArgs args)
        {
            base.CalculateLines(context, args);

            AccountDetailArgs argsx = (AccountDetailArgs)args;

            String sql = "select * from journal where account_id = '" + Account.unique_id + "' ";
            if (argsx.TransactionDateRange.TheRange.Valid)
                sql += " and " + argsx.TransactionDateRange.TheRange.GetSQL("date_created");

            sql += " order by date_created";

            foreach (journal j in context.QtC("journal", sql))
            {
                ReportLine l = LineAdd();
                l.SetInc(j.date_created);
                l.SetInc(j.description);
                l.SetInc(j.split);

                switch (Account.Category)
                {
                    case AccountCategory.Asset:
                    case AccountCategory.Expense:
                        if (j.debit_amount > 0)
                            l.SetInc(j.debit_amount);
                        else
                            l.SetInc(j.credit_amount * -1);
                        break;
                    case AccountCategory.Liability:
                    case AccountCategory.Equity:
                    case AccountCategory.Income:
                        if (j.credit_amount > 0)
                            l.SetInc(j.credit_amount);
                        else
                            l.SetInc(j.debit_amount * -1);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public override string Title
        {
            get
            {
                return "Summary of " + Account.full_name;
            }
        }

        public override ReportArgs ArgsCreate(Context context)
        {
            return new AccountDetailArgs(context);
        }
    }

    public class AccountDetailArgs : ReportArgs
    {
        public ReportCriteriaDateRange TransactionDateRange;

        public AccountDetailArgs(Context context)
            : base(context)
        {
            TransactionDateRange = new ReportCriteriaDateRange("Date");
            TransactionDateRange.DefaultOption = "Year To Date";
            TransactionDateRange.TheRange = Tools.Dates.DateRange.YearToDate;
            Criteria.Add(TransactionDateRange);
        }
    }
}
