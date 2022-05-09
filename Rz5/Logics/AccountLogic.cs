using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;
using NewMethod;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

namespace Rz5
{
    public partial class AccountLogic : NewMethod.Logic
    {
        public bool Enabled = true;        
        public String BaseCurrency = "USD";
        public String BaseSymbol = "$";

        public override void ActsListStatic(Context x, ActSetup acts)
        {
            ContextRz xrz = (ContextRz)x;
            if (!xrz.Accounts.Enabled)
                return;
            if(!xrz.xUserRz.AccountingIs && !xrz.xUserRz.IsDeveloper())
                return;

            ActHandle h = new ActHandle(new Act("Accounts", new ActHandler(AccountsShow)));
            acts.Add(h);
            h.SubActs.Add(new ActHandle(new Act("Chart Of Accounts", new ActHandler(AccountsShow))));

            ActHandle activities = new ActHandle(new Act("Activities", null));
            h.SubActs.Add(activities);
            activities.SubActs.Add(new ActHandle(new Act("Post Orders", new ActHandler(PostOrdersShow))));
            activities.SubActs.Add(new ActHandle(new Act("Journal Entries", new ActHandler(JournalEntryShow))));

            if (xrz.xUser.CheckPermit(xrz, "Accounting:Post:PostToQB") && ((ContextRz)x).GetSettingBoolean("allow_qbs_posting"))
            {
                ActHandle hq = new ActHandle(new Act("Post To Quickbooks"));
                activities.SubActs.Add(hq);
                hq.SubActs.Add(new ActHandle(new Act("Invoices", new ActHandler(PostQBInvoice))));
                hq.SubActs.Add(new ActHandle(new Act("Purchases", new ActHandler(PostQBPurchase))));
                hq.SubActs.Add(new ActHandle(new Act("RMAs", new ActHandler(PostQBRMA))));
                hq.SubActs.Add(new ActHandle(new Act("Vendor RMAs", new ActHandler(PostQBVendRMA))));
            }

            ActHandle budget = new ActHandle(new Act("Budget", null));
            h.SubActs.Add(budget);
            budget.SubActs.Add(new ActHandle(new Act("Edit Budget", new ActHandler(EditBudgetShow))));

            ActHandle customers = new ActHandle(new Act("Customers", null));
            h.SubActs.Add(customers);
            customers.SubActs.Add(new ActHandle(new Act("Receive Payments", new ActHandler(ReceivePaymentsShow))));
            customers.SubActs.Add(new ActHandle(new Act("Accounts Receivable Aging", new ActHandler(ArAgingShow))));
            customers.SubActs.Add(new ActHandle(new Act("Credit Memo", new ActHandler(CreditMemoCustomerShow))));

            ActHandle vendors = new ActHandle(new Act("Vendors", null));
            h.SubActs.Add(vendors);
            vendors.SubActs.Add(new ActHandle(new Act("Pay Bills", new ActHandler(PayBillsShow))));
            vendors.SubActs.Add(new ActHandle(new Act("Accounts Payable Aging", new ActHandler(ApAgingShow))));
            vendors.SubActs.Add(new ActHandle(new Act("Credit Memo", new ActHandler(CreditMemoVendorShow))));

            ActHandle banking = new ActHandle(new Act("Banking", null));
            h.SubActs.Add(banking);
            banking.SubActs.Add(new ActHandle(new Act("Make Deposits", new ActHandler(DepositsShow))));
            banking.SubActs.Add(new ActHandle(new Act("Write Checks", new ActHandler(WriteChecksShow))));
            banking.SubActs.Add(new ActHandle(new Act("Reconcile Bank", new ActHandler(ReconcileBankShow))));

            ActHandle cc = new ActHandle(new Act("Credit Cards", null));
            h.SubActs.Add(cc);
            cc.SubActs.Add(new ActHandle(new Act("Enter Credit Card Charges", new ActHandler(CreditCardChargesShow))));
            cc.SubActs.Add(new ActHandle(new Act("Credit Card Charge Report", new ActHandler(CreditCardChargeReportShow))));
            cc.SubActs.Add(new ActHandle(new Act("Reconcile Credit Card", new ActHandler(ReconcileCCShow))));
            cc.SubActs.Add(new ActHandle(new Act("Credit Memo", new ActHandler(CreditMemoCCShow))));

            ActHandle reports = new ActHandle( new Act("Reports", null));
            h.SubActs.Add(reports);
            reports.SubActs.Add(new ActHandle(new Act("Income Statement [Profit & Loss]", new ActHandler(IncomeStatementShow))));
            reports.SubActs.Add(new ActHandle(new Act("Statement Of Owners Equity", new ActHandler(StatementOfOwnersEquityShow))));
            reports.SubActs.Add(new ActHandle(new Act("Balance Sheet", new ActHandler(BalanceSheetShow))));
            reports.SubActs.Add(new ActHandle(new Act("Statement Of Cash Flows", new ActHandler(StatementOfCashFlowsShow))));
            reports.SubActs.Add(new ActHandleSeparator());
            reports.SubActs.Add(new ActHandle(new Act("Trial Balance", new ActHandler(TrialBalanceShow))));
            reports.SubActs.Add(new ActHandle(new Act("Accounts Receivable Aging", new ActHandler(ArAgingShow))));
            reports.SubActs.Add(new ActHandle(new Act("Accounts Payable Aging", new ActHandler(ApAgingShow))));

            ActHandle other = new ActHandle(new Act("Other", null));
            h.SubActs.Add(other);
            other.SubActs.Add(new ActHandle(new Act("Currencies", new ActHandler(CurrenciesShow))));
        }

        public void AccountsShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).AccountsShow((ContextRz)x);
        }

        public void CurrenciesShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).CurrenciesShow((ContextRz)x);
        }

        public void IncomeStatementShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            Tools.Dates.DateRange dr = new Tools.Dates.DateRange(Tools.Dates.GetMonthStart(DateTime.Now), DateTime.Now);
            xrz.Accounts.ShowIncomeStatement(xrz,dr);
        }
        public void TrialBalanceShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            Tools.Dates.DateRange dr = new Tools.Dates.DateRange(Tools.Dates.GetMonthStart(DateTime.Now), DateTime.Now);
            xrz.Accounts.ShowTrialBalance(xrz, dr);
        }
        public void CreditCardChargeReportShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ReportShow((ContextRz)x, new Reports.CreditCardChargeReport((ContextRz)x), false);
        }
        public void StatementOfOwnersEquityShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            Tools.Dates.DateRange dr = new Tools.Dates.DateRange(Tools.Dates.GetMonthStart(DateTime.Now), DateTime.Now);
            xrz.Accounts.ShowStatementOfOwnersEquity(xrz,dr);
        }

        public void BalanceSheetShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            xrz.Accounts.ShowBalanceSheet(xrz, DateTime.Now);
        }

        public void StatementOfCashFlowsShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            Tools.Dates.DateRange dr = new Tools.Dates.DateRange(new DateTime(DateTime.Now.Year, 1, 1), DateTime.Now);
            xrz.Accounts.ShowStatementOfCashFlows(xrz, dr);
        }

        public void PostOrdersShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).PostOrdersShow((ContextRz)x);
        }
        public void JournalEntryShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).JournalEntryShow((ContextRz)x);
        }
        public void EditBudgetShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).EditBudgetShow((ContextRz)x);
        }
        public void ReceivePaymentsShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ReceivePaymentsShow((ContextRz)x, null);
        }
        public void CreditMemoCustomerShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheSysRz.TheOrderLogic.ShowNewCreditMemo((ContextRz)x, null, PaymentType.Customer);
        }
        public void CreditMemoVendorShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheSysRz.TheOrderLogic.ShowNewCreditMemo((ContextRz)x, null, PaymentType.Vendor);
        }
        public void CreditMemoCCShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheSysRz.TheOrderLogic.ShowNewCreditMemo((ContextRz)x, null, PaymentType.CreditCard);
        }
        public void ArAgingShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ReportShow((ContextRz)x, new Reports.ArApAging((ContextRz)x, false), false);
        }
        public void ApAgingShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ReportShow((ContextRz)x, new Reports.ArApAging((ContextRz)x, true), false);
        }
        public void PayBillsShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).PayBillsShow((ContextRz)x, null);
        }

        public void DepositsShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).DepositsShow((ContextRz)x);
        }
        public void ReconcileBankShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ReconcileBankShow((ContextRz)x);
        }
        public void ReconcileCCShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ReconcileCCShow((ContextRz)x);
        }
        public void WriteChecksShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ShowPrintCheck((ContextRz)x, null);
        }
        public void CreditCardChargesShow(Context x, ActArgs args)
        {
            ((ContextRz)x).Sys.TheOrderLogic.ShowNewBill((ContextRz)x, null, true);
        }
        public string GetCheckRegisterHTML(ContextRz x, account a, CheckRegisterSearchArgs args)
        {
            string table = "temp_" + Tools.Strings.GetNewID() + "_table";
            x.Execute("select unique_id,date_created,vendor_uid,vendor_name,amount,description,account_uid,account_name,cleared,reference_number,check_number,'Payment' as type,dest_account_name,dest_account_uid,balance,account_number,dest_account_number into " + table + " from payment_out where account_uid = '" + a.unique_id + "' and date_created " + args.Range.GetBetweenSQL());
            x.Execute("insert into " + table + " select unique_id,date_created,vendor_uid,vendor_name,total_amount as amount,description,account_uid,account_name,cleared,name as reference_number,'' as check_number,'Deposit' as type,dest_account_name,dest_account_uid,balance,account_number,dest_account_number from deposit where account_uid = '" + a.unique_id + "' and date_created " + args.Range.GetBetweenSQL());
            DataTable dt = x.Select("select * from " + table + " order by date_created asc");
            x.Execute("drop table " + table);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<head>");
            sb.AppendLine("<style type=\"text/css\">");
            sb.AppendLine("body {  font-family: Sans-Serif; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<table border=\"1\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">Date</td>");
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">Number</td>");
            sb.AppendLine("    <td width=\"26%\" colspan=\"2\" bgcolor=\"#F1F0EF\" align=\"center\">Payee</td>");
            sb.AppendLine("    <td width=\"12%\" align=\"center\" bgcolor=\"#F1F0EF\">Payment</td>");
            sb.AppendLine("    <td width=\"12%\" align=\"center\" bgcolor=\"#F1F0EF\">Cleared</td>");
            sb.AppendLine("    <td width=\"12%\" align=\"center\" bgcolor=\"#F1F0EF\">Deposit</td>");
            sb.AppendLine("    <td width=\"12%\" align=\"center\" bgcolor=\"#F1F0EF\">Balance</td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">Type</td>");
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">Account</td>");
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">Memo</td>");
            sb.AppendLine("    <td width=\"12%\" bgcolor=\"#F1F0EF\" align=\"center\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"12%\" bgcolor=\"#F1F0EF\" align=\"center\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"12%\" bgcolor=\"#F1F0EF\" align=\"center\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"12%\" bgcolor=\"#F1F0EF\" align=\"center\">&nbsp;</td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("<table border=\"1\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendLine(GetCheckRegisterHTMLRow(dr, args));
            }
            if (dt.Rows.Count <= 0)
                sb.AppendLine("<tr><td width=\"100%\" bgcolor=\"#E0EFE0\">No Results</td></tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            return sb.ToString();
        }
        private String GetCheckRegisterHTMLRow(DataRow dr, CheckRegisterSearchArgs a)
        {
            StringBuilder sb = new StringBuilder();
            string id = Tools.Data.NullFilterString(dr["unique_id"]);
            DateTime date = Tools.Data.NullFilterDate(dr["date_created"]);
            string vendor_id = Tools.Data.NullFilterString(dr["vendor_uid"]);
            string vendor_name = Tools.Data.NullFilterString(dr["vendor_name"]);
            double amnt = Tools.Data.NullFilterDouble(dr["amount"]);
            string descr = Tools.Data.NullFilterString(dr["description"]);
            string dest_account_uid = Tools.Data.NullFilterString(dr["dest_account_uid"]);
            string dest_account_name = Tools.Data.NullFilterString(dr["dest_account_name"]);
            int dest_account_number = Tools.Data.NullFilterIntegerFromIntOrLong(dr["dest_account_number"]);
            double balance = Tools.Data.NullFilterDouble(dr["balance"]);
            bool cleared = Tools.Data.NullFilterBoolFromBoolOrInt(dr["cleared"]);
            string reference_number = Tools.Data.NullFilterString(dr["reference_number"]);
            string check_number = Tools.Data.NullFilterString(dr["check_number"]);
            if (check_number == "0")
                check_number = "";
            string type = Tools.Data.NullFilterString(dr["type"]);
            double pay = 0;
            double dep = 0;
            if (Tools.Strings.StrCmp("Payment", type))
                pay = amnt;
            else
                dep = amnt;
            string top_color = "FFFFFF";
            string bottom_color = "E0EFE0";
            if (a.Amount != 0)
            {
                if (a.Amount == pay || a.Amount == dep)
                {
                    top_color = "FFFF00";
                    bottom_color = "FFFF00";
                }
            }
            if (Tools.Strings.StrExt(a.Memo))
            {
                if (Tools.Strings.StrExt(descr))
                {
                    if (descr.ToLower().Contains(a.Memo.ToLower()))
                    {
                        top_color = "FFFF00";
                        bottom_color = "FFFF00";
                    }
                }
            }
            if (Tools.Strings.StrExt(a.Payee))
            {
                if (Tools.Strings.StrExt(vendor_name))
                {
                    if (vendor_name.ToLower().Contains(a.Payee.ToLower()))
                    {
                        top_color = "FFFF00";
                        bottom_color = "FFFF00";
                    }
                }
            }
            if (Tools.Strings.StrExt(a.Ref))
            {
                if (Tools.Strings.StrExt(reference_number) || Tools.Strings.StrExt(check_number))
                {
                    if (reference_number.ToLower().Contains(a.Ref.ToLower()) || check_number.ToLower().Contains(a.Ref.ToLower()))
                    {
                        top_color = "FFFF00";
                        bottom_color = "FFFF00";
                    }
                }
            }
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#" + top_color + "\">" + date.ToShortDateString() + "&nbsp;</td>");
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#" + top_color + "\">" + check_number + "&nbsp;</td>");
            sb.AppendLine("    <td width=\"26%\"  bgcolor=\"#" + top_color + "\" colspan=\"2\"><a href=\"company~" + vendor_id + "\" style=\"text-decoration: none; color: black;\">" + vendor_name + "</a>&nbsp;</td>");
            string s = Tools.Number.MoneyFormat(pay);
            if (pay <= 0)
                s = "&nbsp;";
            sb.AppendLine("    <td width=\"12%\"  bgcolor=\"#" + top_color + "\" align=\"right\">" + s + "&nbsp;</td>");
            sb.AppendLine("    <td width=\"12%\"  bgcolor=\"#" + top_color + "\" align=\"center\">" + (cleared ? "Y" : "&nbsp;") + "</td>");
            s = Tools.Number.MoneyFormat(dep);
            if (dep <= 0)
                s = "&nbsp;";
            sb.AppendLine("    <td width=\"12%\"  bgcolor=\"#" + top_color + "\" align=\"right\">" + s + "&nbsp;</td>");
            sb.AppendLine("    <td width=\"12%\"  bgcolor=\"#" + top_color + "\" align=\"right\">" + Tools.Number.MoneyFormat(balance) + "&nbsp;</td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#" + bottom_color + "\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#" + bottom_color + "\">" + type + "&nbsp;</td>");
            if (dest_account_number != 0)
                dest_account_name = dest_account_number.ToString() + " ■ " + dest_account_name;
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#" + bottom_color + "\"><a href=\"account~" + dest_account_uid + "\" style=\"text-decoration: none; color: black;\">" + dest_account_name + "</a>&nbsp;</td>");
            sb.AppendLine("    <td width=\"13%\" bgcolor=\"#" + bottom_color + "\">" + descr + "&nbsp;</td>");
            sb.AppendLine("    <td width=\"12%\" bgcolor=\"#" + bottom_color + "\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"12%\" bgcolor=\"#" + bottom_color + "\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"12%\" bgcolor=\"#" + bottom_color + "\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"12%\" bgcolor=\"#" + bottom_color + "\">&nbsp;</td>");
            sb.AppendLine("  </tr>");
            return sb.ToString();
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


        public bool IsBaseCurrency(String cur)
        {
            switch (cur.ToUpper())
            {
                case "":
                    return true;
                default:
                    return Tools.Strings.StrCmp(cur, BaseCurrency);
            }
        }

        public bool IsOtherCurrency(String cur)
        {
            return !IsBaseCurrency(cur);
        }

        public account ChooseAnAccount(ContextRz context, String caption, AccountCriteria criteria)
        {
            List<String> names = new List<string>();
            foreach (account a in context.Accounts.GetAccounts(context, criteria))
            {
                names.Add(a.full_name);
            }
            String chosen = context.TheLeader.ChooseBetweenStrings(caption, names);
            if (!Tools.Strings.StrExt(chosen))
                return null;
            return context.Accounts.GetAccount(context, chosen);
        }

        Dictionary<String, currency> m_currencies = null;
        List<String> m_currencyNames = null;
        DateTime lastCurrencyCheck = Tools.Dates.NullDate;

        void CurrencyCacheCheck(ContextRz context)
        {
            if (m_currencies == null || DateTime.Now.Subtract(lastCurrencyCheck).TotalHours > 4)
            {
                CurrencyCache(context);
                if (m_currencies.Count == 0)
                {
                    currency c = currency.New(context);
                    c.name = "USD";
                    c.symbol = "$";
                    c.exchange_rate = 1;
                    c.Insert(context);
                    m_currencies.Add("USD", c);
                }

            }
        }

        public void CurrencyCache(ContextRz context)
        {
            ArrayList a = context.QtC("currency", "select * from currency order by name");
            m_currencies = new Dictionary<String, currency>();
            m_currencyNames = new List<string>();

            foreach (currency c in a)
            {
                m_currencies.Add(c.name.ToUpper(), c);
                m_currencyNames.Add(c.name.ToUpper());
            }

            lastCurrencyCheck = DateTime.Now;
        }

        public List<String> CurrencyNames(ContextRz context)
        {
            CurrencyCacheCheck(context);
            return m_currencyNames;
        }

        public currency GetCurrency(ContextRz context, String name)
        {
            CurrencyCacheCheck(context);
            if (!Tools.Strings.StrExt(name))
                return m_currencies[BaseCurrency];
            else
                return m_currencies[name.ToUpper()];
        }

        public String CurrencySymbol(String name)
        {
            //switch (name.ToUpper())
            //{
            //    case "EUR":
            //        return "€";
            //    case "GBP":
            //        return "£";
            //    default:
            //        return "$";
            //}

            switch (name.ToUpper())
            {
                case "":
                case "USD":
                    return "$";
                default:
                    return name.ToUpper();
            }
        }

        public AccountGroup AllAccounts;
            //Balance Sheet AccountGroups
            public AccountGroup Assets;
                public AccountGroup CurrentAssets;
                    public AccountGroup BankAssets;
                    public AccountGroup ARAssets;
                public AccountGroup OtherCurrentAssets;
                    public AccountGroup FixedAssets;
                    public AccountGroup OtherAssets;

             public AccountGroup LiabilitiesAndEquity;
                public AccountGroup Liabilities;
                  public AccountGroup CurrentLiabilities;
                     public AccountGroup APLiabilities;
                     public AccountGroup CreditCardLiabilities;
                     public AccountGroup OtherCurrentLiabilities;
                  public AccountGroup LongTermLiabilities;
             public AccountGroup Equity;
            //Balance Sheet AccountGroups

            //Income Statement AccountGroups
            public AccountGroup OrdinaryIncomeExpense;
                public AccountGroup Income;
                public AccountGroup CostOfGoodsSold;
                public AccountGroup Expense;

            public AccountGroup OtherIncomeExpense;
                public AccountGroup OtherIncome;
                public AccountGroup OtherExpense;
            //Income Statement AccountGroups

        public void InitAccounts(ContextRz context)
        {
            InitAssetAccounts(context);
            InitLiabilityAndEquityAccounts(context);
            InitIncomeStatementAccounts(context);

            Assets.GatherAccounts(context);
            LiabilitiesAndEquity.GatherAccounts(context);
            OrdinaryIncomeExpense.GatherAccounts(context);
            OtherIncomeExpense.GatherAccounts(context);

            //This isnt an actual account; just calculated from the Income Statement
            //if (dr != null)
            //    GetNetIncomeAccount(context, dr);

            AllAccounts = new AccountGroup(context, "Accounts", AccountCategory.Other, AccountType.Null);
            AllAccounts.SubGroups.Add(Assets);
            AllAccounts.SubGroups.Add(LiabilitiesAndEquity);
            AllAccounts.SubGroups.Add(OrdinaryIncomeExpense);
            AllAccounts.SubGroups.Add(OtherIncomeExpense);
        }
        private void InitAssetAccounts(ContextRz context)
        {
            Assets = new AccountGroup(context, "Assets");

            CurrentAssets = new AccountGroup(context, "Current Assets");
            Assets.SubGroups.Add(CurrentAssets);

            BankAssets = new AccountGroup(context, "Checking/Savings", AccountCategory.Asset, AccountType.Bank);
            CurrentAssets.SubGroups.Add(BankAssets);

            ARAssets = new AccountGroup(context, "Accounts Receivable", AccountCategory.Asset, AccountType.AccountsReceivable);
            CurrentAssets.SubGroups.Add(ARAssets);

            OtherCurrentAssets = new AccountGroup(context, "Other Current Assets", AccountCategory.Asset, AccountType.OtherCurrentAssets);
            CurrentAssets.SubGroups.Add(OtherCurrentAssets);

            FixedAssets = new AccountGroup(context, "Fixed Assets", AccountCategory.Asset, AccountType.FixedAssets);
            Assets.SubGroups.Add(FixedAssets);

            OtherAssets = new AccountGroup(context, "Other Assets", AccountCategory.Asset, AccountType.OtherAssets);
            Assets.SubGroups.Add(OtherAssets);
        }
        private void InitLiabilityAndEquityAccounts(ContextRz context)
        {
            LiabilitiesAndEquity = new AccountGroup(context, "Liabilities & Equity");

            Liabilities = new AccountGroup(context, "Liabilities", AccountCategory.Liability);
            LiabilitiesAndEquity.SubGroups.Add(Liabilities);

            CurrentLiabilities = new AccountGroup(context, "Current Liabilities", AccountCategory.Liability);
            Liabilities.SubGroups.Add(CurrentLiabilities);

            APLiabilities = new AccountGroup(context, "Accounts Payable", AccountCategory.Liability, AccountType.AccountsPayable);
            CurrentLiabilities.SubGroups.Add(APLiabilities);

            CreditCardLiabilities = new AccountGroup(context, "Credit Cards", AccountCategory.Liability, AccountType.CreditCard);
            CurrentLiabilities.SubGroups.Add(CreditCardLiabilities);

            OtherCurrentLiabilities = new AccountGroup(context, "Other Current Liabilities", AccountCategory.Liability, AccountType.OtherCurrentLiabilities);
            CurrentLiabilities.SubGroups.Add(OtherCurrentLiabilities);

            LongTermLiabilities = new AccountGroup(context, "Long Term Liabilities", AccountCategory.Liability, AccountType.LongTermLiabilities);
            Liabilities.SubGroups.Add(LongTermLiabilities);

            Equity = new AccountGroup(context, "Equity", AccountCategory.Equity, AccountType.Equity);
            LiabilitiesAndEquity.SubGroups.Add(Equity);
        }
        private void InitIncomeStatementAccounts(ContextRz context)
        {
            OrdinaryIncomeExpense = new AccountGroup(context, "Ordinary Income/Expense");

            Income = new AccountGroup(context, "Income", AccountCategory.Income, AccountType.Income);
            OrdinaryIncomeExpense.SubGroups.Add(Income);

            CostOfGoodsSold = new AccountGroup(context, "Cost Of Goods Sold", AccountCategory.Expense, AccountType.CostOfGoodsSold);
            OrdinaryIncomeExpense.SubGroups.Add(CostOfGoodsSold);

            Expense = new AccountGroup(context, "Expense", AccountCategory.Expense, AccountType.Expense);
            OrdinaryIncomeExpense.SubGroups.Add(Expense);

            OtherIncomeExpense = new AccountGroup(context, "Other Income/Expense");

            OtherIncome = new AccountGroup(context, "Other Income", AccountCategory.Income, AccountType.OtherIncome);
            OtherIncomeExpense.SubGroups.Add(OtherIncome);

            OtherExpense = new AccountGroup(context, "Other Expense", AccountCategory.Other, AccountType.OtherExpense);
            OtherIncomeExpense.SubGroups.Add(OtherExpense);
        }

        public void ConfirmInventoryValue(ContextRz context)
        {
            //i don't understand how sql can return sum(round(x, 2)) with more than 2 decimal places, but it does
            Double inventoryValue = Math.Round(context.SelectScalarDouble("select sum( round( isnull(quantity, 0) * isnull(cost, 0), 2) ) from partrecord where stocktype = 'Stock'"), 2);
            Double assetValue = 0;
            InitAccounts(context);
            foreach (account a in InventoryAssetAccounts(context))
            {
                assetValue += a.balance;
            }

            if (inventoryValue != assetValue)
                throw new Exception("Inventory value out of balance: " + Tools.Number.MoneyFormat(inventoryValue) + " in inventory, " + Tools.Number.MoneyFormat(assetValue) + " in inventory assets");
        }

        public List<account> InventoryAssetAccounts(ContextRz context)
        {
            List<account> ret = new List<account>();
            ret.Add(GetAccount(context, "Inventory Asset"));
            return ret;
        }

        public account GetAccount(ContextRz context, String fullNameOrId)
        {
            if (!Tools.Strings.StrExt(fullNameOrId))
                return null;

            if (AllAccounts == null)
                InitAccounts(context);

            return AllAccounts.Find(context, fullNameOrId);
        }

        public List<account> GetAccounts(ContextRz context, AccountCriteria criteria)
        {
            List<account> ret = new List<account>();
            if (AllAccounts == null)
                InitAccounts(context);
            AllAccounts.Find(context, criteria, ret);
            return ret;
        }

        public virtual void CloseTheBooks(ContextRz x, Tools.Dates.DateRange range)
        {
            x.TheLeader.Comment("Closing books for " + range.CaptionTo);
            account income_summary = account.GetByFullName(x, "Income Summary");
            if (income_summary == null)
                throw new Exception("Income Summary account could not be found.");
            account retained_earnings = account.GetByFullName(x, "Retained Earnings");
            if (retained_earnings == null)
                throw new Exception("Retained Earnings account could not be found.");
            ArrayList ie = x.QtC("account", "select * from account where type in ('Income', 'Other Income') and (isnull(is_hidden,0) != 1 and isnull(built_in,0) != 1) and balance != 0");
            List<account> income = new List<account>();
            foreach (account a in ie)
            {
                income.Add(a);
            }
            ie = x.QtC("account", "select * from account where type in ('Expense', 'Other Expense', 'Cost Of Goods Sold') and (isnull(is_hidden,0) != 1 and isnull(built_in,0) != 1) and balance != 0");
            List<account> expense = new List<account>();
            foreach (account a in ie)
            {
                expense.Add(a);
            }
            foreach (account a in income)//Income accounts - credit
            {
                JournalEntry e = new JournalEntry("Closing Balance for " + range.EndDate.ToShortDateString());
                a.balance = x.SelectScalarDouble("select top 1 balance from journal where account_id = '" + a.unique_id + "' and date_created " + range.GetBetweenSQL() + " order by date_created desc");
                if (a.balance == 0)
                    continue;
                if (a.balance < 0)
                {
                    e.Add(x, income_summary, a.balance * -1, 0);
                    e.Add(x, a, 0, a.balance * -1);
                }
                else
                {
                    e.Add(x, income_summary, 0, a.balance);
                    e.Add(x, a, a.balance, 0);
                }
                e.Post(x);
            }
            foreach (account a in expense)//Expense accounts - debit
            {
                JournalEntry e = new JournalEntry("Closing Balance for " + range.EndDate.ToShortDateString());
                a.balance = x.SelectScalarDouble("select top 1 balance from journal where account_id = '" + a.unique_id + "' and date_created " + range.GetBetweenSQL() + " order by date_created desc");
                if (a.balance == 0)
                    continue;
                if (a.balance < 0)
                {
                    e.Add(x, income_summary, 0, a.balance * -1);
                    e.Add(x, a, a.balance * -1, 0);
                }
                else
                {
                    e.Add(x, income_summary, a.balance, 0);
                    e.Add(x, a, 0, a.balance);
                }
                e.Post(x);
            }
            //Owner's equity - credit
            income_summary = account.GetByFullName(x, "Income Summary");
            if (income_summary.balance != 0)
            {
                JournalEntry ee = new JournalEntry("Closing Balance for " + range.EndDate.ToShortDateString());
                ee.Add(x, retained_earnings, 0, income_summary.balance);
                ee.Add(x, income_summary, income_summary.balance, 0);
                ee.Post(x);
            }
            x.SetSettingDateTime("last_book_closing", range.EndDate);
        }
    }
    public class CheckRegisterSearchArgs
    {
        public Tools.Dates.DateRange Range = new Tools.Dates.DateRange();
        public string Payee = "";
        public string Ref = "";
        public string Memo = "";
        public double Amount = 0;
    }
    public class NewBudgetArgs
    {
        public string Name = "";
        public int Year = 0;
        public bool FromScratch = false;
    }
    public class PrintCheckArgs
    {
        public account Account;
        public Int32 CheckNumber = 1;
        public List<payment_out> Payments = new List<payment_out>();
    }
    public class ReconcileArgs
    {
        public account Account;
        public double BeginAmount = 0;
        public double EndAmount = 0;
        public double Difference = 0;
        public DateTime StatementDate;
        public ReconcileArg ServiceArgs = new ReconcileArg();
        public ReconcileArg InterestArgs = new ReconcileArg();
        public List<payment_out> ClearedPayments = new List<payment_out>();
        public List<deposit> ClearedDeposits = new List<deposit>();

        public bool CheckDifference(ContextRz x)
        {
            if (Difference != 0)
            {
                if (!x.TheLeader.AskYesNo("There is a " + Tools.Number.MoneyFormat(Difference) + " discrepancy between your statement and the transactions you selected. Your account will be adjusted to reflect the current bank statement. OK to continue?"))
                    return false;
                JournalEntry j = new JournalEntry("Reconciliation Discrepancy");
                if (Difference > 0)
                {
                    j.Add(x, x.TheSysRz.TheAccountLogic.GetAccount(x, "Reconciliation Discrepancies"), 0, Difference);
                    j.Add(x, Account, Difference, 0);
                    MakeDeposit(x, Account, Difference);
                }
                else
                {
                    j.Add(x, x.TheSysRz.TheAccountLogic.GetAccount(x, "Reconciliation Discrepancies"), Difference * -1, 0);
                    j.Add(x, Account, 0, Difference * -1);
                    MakePayment(x, Account, Difference * -1);
                }
                j.Post(x);
            }
            return true;
        }
        private void MakeDeposit(ContextRz x, account a, double amnt)
        {
            deposit d = new deposit();
            d.account_name = a.full_name;
            d.account_uid = a.unique_id;
            d.account_number = a.number;
            d.cleared = true;
            d.description = "Reconciliation Discrepancies";
            d.total_amount = amnt;
            d.balance = a.balance + d.total_amount;
            d.Insert(x);
        }
        private void MakePayment(ContextRz x, account a, double amnt)
        {
            payment_out p = new payment_out();
            p.account_name = a.full_name;
            p.account_uid = a.unique_id;
            p.account_number = a.number;
            p.cleared = true;
            p.description = "Reconciliation Discrepancies";
            p.amount = amnt;
            p.balance = a.balance - p.amount;
            p.Insert(x);
        }
    }
    public class ReconcileArg
    {
        public account Account;
        public double Amount = 0;
        public DateTime Date;
    }
    public class JournalEntry
    {
        public String Description;
        List<journal> Items = new List<journal>();
        public List<String> Sql = new List<string>();

        public JournalEntry(String desc)
        {
            Description = desc;
        }

        public void Add(ContextRz context, String acctName, Double debitAmount, Double creditAmount)
        {
            account acct = context.Accounts.GetAccount(context, acctName);
            if (acct == null)
                throw new Exception("Transaction account " + acctName + " was not found");
            Add(context, acct, debitAmount, creditAmount);
        }

        public void Add(ContextRz context, account acct, Double debitAmount, Double creditAmount)
        {
            Items.Add(journal.CreateNoInsert(context, acct, debitAmount, creditAmount));
        }

        public bool Balances
        {
            get
            {
                Double debit = 0;
                Double credit = 0;

                foreach (journal j in Items)
                {
                    debit += j.debit_amount;
                    credit += j.credit_amount;
                }
                //return debit == credit;
                return Math.Round(debit, 2) == Math.Round(credit, 2);
            }
        }

        public Double Total
        {
            get
            {
                Double debit = 0;
               
                foreach (journal j in Items)
                {
                    debit += j.debit_amount;
                }

                return debit;
            }
        }

        public void Post(ContextRz context)
        {
            Post(context, DateTime.Now);
        }

        public void Post(ContextRz context, DateTime asOf)
        {
            if (context.TheDelta.TransactionMode)
            {
                Post_TransAlreadyHandled(context, asOf);
            }
            else
            {
                ContextRz xx = (ContextRz)context.Clone();
                String id = xx.TheDelta.BeginTran();
                Post_TransAlreadyHandled(xx, asOf);
                xx.TheDelta.CommitTran(id);
            }
        }

        void Post_TransAlreadyHandled(ContextRz context, DateTime asOf)
        {
            if (!Balances)
                throw new Exception("Cannot post transaction " + Description + " : does not balance");

            List<String> accountsInvolved = new List<string>();
            foreach (journal j in Items)
            {
                if (!accountsInvolved.Contains(j.Account.full_name))
                    accountsInvolved.Add(j.Account.full_name);
            }

            String entryId = Tools.Strings.GetNewID();

            foreach (journal j in Items)
            {
                bool increasing = j.Increasing;
                String symbol;

                j.description = Description;
                List<String> accountsExceptThis = new List<string>(accountsInvolved);
                accountsExceptThis.Remove(j.Account.full_name);
                j.split = Tools.Strings.CommaSeparateBlanksIgnore(accountsExceptThis);
                j.entry_id = entryId;

                context.Insert(j);

                if(increasing)
                    symbol = "+";
                else
                    symbol = "-";

                context.Execute("WAITFOR DELAY '00:00:00:10'");
                context.Execute("update account set balance = round(balance " + symbol + " " + j.Amount.ToString() + ",2) where unique_id = '" + j.Account.Uid + "'");
                context.Execute("update journal set date_created = getdate(), balance = ( select balance from account where account.unique_id = '" + j.Account.Uid + "' ) where journal.unique_id = '" + j.unique_id + "'");
                
                //?
                string ms = "' + cast(datepart(ms,getdate()) as varchar(50)) as datetime) ";
                if (asOf.Millisecond > 0)
                    ms = asOf.Millisecond.ToString() + "' as datetime)";
                string date = " cast('" + asOf.ToShortDateString() + " " + asOf.Hour.ToString() + ":" + asOf.Minute.ToString() + ":" + asOf.Second.ToString() + "." + ms;
                //?

                //the asOf needs to be handled here.  If it isn't current, don't the balances of all journal items after the added one need to be adjusted the same direction?
                if (Tools.Dates.IsEarlierDay(asOf, DateTime.Now))
                {
                    context.Execute("update journal set date_created = " + date + " where unique_id = '" + j.unique_id + "'");
                    context.Execute("update journal set balance = round(balance " + symbol + " " + j.Amount.ToString() + ",2) where account_id = '" + j.Account.unique_id + "' and unique_id <> '" + j.unique_id + "' and datediff(d, date_created, '" + Tools.Dates.DateFormat(asOf) + "') < 0");                    
                }
                else if (Tools.Dates.IsLaterDay(asOf, DateTime.Now))
                {
                    context.Execute("update journal set date_created = " + date + " where unique_id = '" + j.unique_id + "'");
                    //should system check for other future entries and update them?!?
                    //context.Execute("update journal set balance = round(balance " + symbol + " " + j.Amount.ToString() + ",2) where account_id = '" + j.Account.unique_id + "' and unique_id <> '" + j.unique_id + "' and datediff(d, date_created, '" + Tools.Dates.DateFormat(asOf) + "') < 0");
                }
            }

            foreach (String sql in Sql)
            {
                context.Execute(sql);
            }
        }
    }
    public class PostOrdersArgs
    {
        public ArrayList Invoices = new ArrayList();
        public ArrayList Purchases = new ArrayList();
        public ArrayList RMAs = new ArrayList();
        public ArrayList VRMAs = new ArrayList();
        public ArrayList Services = new ArrayList();
        public List<ordhed_new> PostList = new List<ordhed_new>();

        public void PostOrders(ContextRz x)
        {            
            if (PostList == null || PostList.Count <= 0)
                return;
            foreach (ordhed_new o in PostList)
            {
                o.Post(x);
            }
        }
        public void DoSearch(ContextRz x, PostSearchArgs args)
        {
            Invoices = new ArrayList();
            Purchases = new ArrayList();
            RMAs = new ArrayList();
            VRMAs = new ArrayList();
            Services = new ArrayList();
            if (args.Invoice)
                Invoices = x.QtC("ordhed_invoice", "select * from ordhed_invoice where unique_id in (select orderid_invoice from orddet_line where status != 'Void' and ISNULL(isvoid, 0) = 0 and LEN(ISNULL(orderid_invoice,'')) > 0 and ISNULL(was_shipped,0) = 1 and ISNULL(posted_invoice,0) = 0)");
            if (args.Purchase)
                Purchases = x.QtC("ordhed_purchase", "select * from ordhed_purchase where unique_id in (select orderid_purchase from orddet_line where status != 'Void' and ISNULL(isvoid, 0) = 0 and LEN(ISNULL(orderid_purchase,'')) > 0 and ISNULL(was_received,0) = 1 and ISNULL(posted_purchase,0) = 0)");
            if (args.RMA)
                RMAs = x.QtC("ordhed_rma", "select * from ordhed_rma where unique_id in (select orderid_rma from orddet_line where status != 'Void' and ISNULL(isvoid, 0) = 0 and LEN(ISNULL(orderid_rma,'')) > 0 and ISNULL(was_rma_received,0) = 1 and ISNULL(posted_rma,0) = 0)");
            if (args.VRMA)
                VRMAs = x.QtC("ordhed_vendrma", "select * from ordhed_vendrma where unique_id in (select orderid_vendrma from orddet_line where status != 'Void' and ISNULL(isvoid, 0) = 0 and LEN(ISNULL(orderid_vendrma,'')) > 0 and ISNULL(was_vendrma_shipped,0) = 1 and ISNULL(posted_vendrma,0) = 0)");
            if (args.Service)
                Services = x.QtC("ordhed_service", "select * from ordhed_service where unique_id in (select orderid_service from orddet_line where status != 'Void' and ISNULL(isvoid, 0) = 0 and LEN(ISNULL(orderid_service,'')) > 0 and ISNULL(was_service_in,0) = 1 and ISNULL(was_service_out,0) = 1 and ISNULL(posted_service,0) = 0)");
        }
    }
    public class PostSearchArgs
    {
        public bool Invoice = false;
        public bool Purchase = false;
        public bool RMA = false;
        public bool VRMA = false;
        public bool Service = false;
    }
}