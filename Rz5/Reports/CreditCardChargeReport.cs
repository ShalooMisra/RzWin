using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Tools.Database;
using System.Data;

namespace Rz5.Reports
{
    public class CreditCardChargeReport : Rz5.Report
    {
        //Constructors   
        public CreditCardChargeReport(ContextRz context)
            : base(context)
        {
            
        }
        //Public Override Functions
        public override void CalculateLines(Context context, ReportArgs args)
        {
            base.CalculateLines(context, args);
            ContextRz x = (ContextRz)context;
            CreditCardChargeArgs argsx = (CreditCardChargeArgs)args;
            String sql = "select l.orderid_purchase,l.orderdate_purchase,l.ordernumber_purchase,p.companyname,p.base_company_uid,l.fullpartnumber,p.cc_account_full_name,l.total_cost from ordhed_purchase p inner join orddet_line l on p.unique_id = l.orderid_purchase where isnull(p.is_credit_card, 0) = 1 and isnull(l.isvoid, 0) = 0 and l.status != 'Void' ";
            if (argsx.Account.Exists() && !Tools.Strings.StrCmp(argsx.Account.SelectedCaption, "All"))
                sql += " and cc_account_full_name = '" + context.Filter(argsx.Account.SelectedCaption) + "'";
            if (argsx.Date.Exists())
                sql += " and orderdate_purchase " + argsx.Date.TheRange.GetBetweenSQL();
            DataTable dt = x.Select(sql);
            foreach (DataRow dr in dt.Rows)
            {
                DateTime orderdate_purchase = Tools.Data.NullFilterDate(dr["orderdate_purchase"]);
                string ordernumber_purchase = Tools.Data.NullFilterString(dr["ordernumber_purchase"]);
                string orderid_purchase = Tools.Data.NullFilterString(dr["orderid_purchase"]);
                string companyname = Tools.Data.NullFilterString(dr["companyname"]);
                string base_company_uid = Tools.Data.NullFilterString(dr["base_company_uid"]);
                string fullpartnumber = Tools.Data.NullFilterString(dr["fullpartnumber"]);
                string account = Tools.Data.NullFilterString(dr["cc_account_full_name"]);
                double total_cost = Tools.Data.NullFilterDouble(dr["total_cost"]);
                ReportLine l = new ReportLine();
                if (Tools.Dates.DateExists(orderdate_purchase))
                    l.SetInc(orderdate_purchase.ToShortDateString());
                else
                    l.SetInc("");
                l.SetInc(ordernumber_purchase, new ItemTag("ordhed_purchase", orderid_purchase));
                l.SetInc(companyname, new ItemTag("company", base_company_uid));
                l.SetInc(fullpartnumber);
                l.SetInc(account);
                l.SetInc(total_cost, Tools.Number.MoneyFormat(total_cost));
                Lines.Add(l);                
            }
        }
        public override string Title
        {
            get
            {
                return "Credit Card Charge Report";
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            return new CreditCardChargeArgs(context);
        }
        //Protected Override Functions
        protected override void InitColumns(Core.Context context)
        {
            ColumnAdd("Date");
            ColumnAdd("Number");
            ColumnAdd("Vendor");
            ColumnAdd("Item");
            ColumnAdd("Credit Card");
            ColumnAdd("Amount", ValueUse.TotalMoney);
        }
        protected override void InitTotals()
        {
            base.InitTotals();
            AutoTotal("Total", "Amount");
        }
    }
    public class CreditCardChargeArgs : ReportArgs
    {
        //Public Variables
        public ReportCriteriaDateRange Date;
        public ReportCriteriaRadio Account;

        //Constructors
        public CreditCardChargeArgs(Context context)
            : base(context)
        {
            Date = new ReportCriteriaDateRange("Date");
            Date.DefaultOption = "Between";
            Date.TheRange = new Tools.Dates.DateRange(Tools.Dates.GetMonthStart(DateTime.Now), DateTime.Now);
            Criteria.Add(Date);
            
            List<account> acnts = ((ContextRz)context).Accounts.GetAccounts((ContextRz)context, new AccountCriteria(AccountType.CreditCard));
            List<string> l = new List<string>();
            l.Add("All");
            foreach (account a in acnts)
            {
                l.Add(a.full_name);
            }
            Account = new ReportCriteriaRadio("Credit Card Account", l);
            Criteria.Add(Account);
        }
    }
}



