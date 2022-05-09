using System;
using System.Collections.Generic;
using System.Text;

using Core;
using System.Collections;

namespace Rz5
{
    public partial class budget : budget_auto
    {
        //Private Variables
        private List<budget_account> Accounts;

        //Constructors
        public budget()
        {

        }
        //Public Static Functions
        public static budget CreateNewBudget(ContextRz context, NewBudgetArgs args)
        {
            if (args.Year <= 1999)
            {
                context.TheLeader.Tell("You must choose a valid year for this budget.");
                return null;
            }
            string id = context.SelectScalarString("select unique_id from budget where budget_name = '" + context.Filter(args.Name) + "'");
            if (Tools.Strings.StrExt(id))
            {
                context.TheLeader.Tell("There is already a budget with the name " + args.Name + ".");
                return null;
            }
            budget b = new budget();
            b.budget_name = args.Name;
            b.budget_year = args.Year;
            b.Insert(context);
            CreateBudgetAccounts(context, b, args);
            return b;
        }
        public static budget GetByName(ContextRz context, string name)
        {
            if (!Tools.Strings.StrExt(name))
                return null;
            return (budget)context.QtO("budget", "select * from budget where budget_name = '" + context.Filter(name) + "'");
        }
        //Public Functions
        public List<budget_account> AccountList(ContextRz context)
        {
            if (Accounts == null)
                GatherAccounts(context);
            return Accounts;
        }
        public void GatherAccounts(ContextRz context)
        {
            Accounts = new List<budget_account>();
            if (!Tools.Strings.StrExt(unique_id))
                return;
            ArrayList a = context.QtC("budget_account", "select * from budget_account where budget_uid = '" + unique_id + "'");
            foreach (budget_account ba in a)
            {
                Accounts.Add(ba);
            }
        }
        public string GetBudgetHTML(ContextRz context)
        {
            string y = Tools.Strings.Right(budget_year.ToString(), 2);            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"1\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td class=\"header\" width=\"8%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>Account</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"8%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>Annual Total</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>JAN" + y + "</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>FEB" + y + "</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>MAR" + y + "</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>APR" + y + "</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>MAY" + y + "</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>JUN" + y + "</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>JUL" + y + "</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>AUG" + y + "</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>SEP" + y + "</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>OCT" + y + "</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>NOV" + y + "</b></td>");
            sb.AppendLine("    <td class=\"header\" width=\"7%\" align=\"center\" bgcolor=\"#C0C0C0\"><b>DEC" + y + "</b></td>");
            sb.AppendLine("  </tr>");
            foreach (budget_account a in AccountList(context))
            {
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"8%\">" + a.account_fullname + "</td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\">" + Tools.Number.MoneyFormat(a.annual_total) + "</td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_jan\" value=\"" + Tools.Number.MoneyFormat(a.jan) + "\"/></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_feb\" value=\"" + Tools.Number.MoneyFormat(a.feb) + "\"/></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_mar\" value=\"" + Tools.Number.MoneyFormat(a.march) + "\"/></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_apr\" value=\"" + Tools.Number.MoneyFormat(a.april) + "\"/></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_may\" value=\"" + Tools.Number.MoneyFormat(a.may) + "\"/></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_jun\" value=\"" + Tools.Number.MoneyFormat(a.june) + "\"/></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_jul\" value=\"" + Tools.Number.MoneyFormat(a.july) + "\"/></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_aug\" value=\"" + Tools.Number.MoneyFormat(a.august) + "\"/></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_sep\" value=\"" + Tools.Number.MoneyFormat(a.sept) + "\"/></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_oct\" value=\"" + Tools.Number.MoneyFormat(a.oct) + "\"/></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_nov\" value=\"" + Tools.Number.MoneyFormat(a.nov) + "\"/></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\"><input id=\"ctl_" + a.unique_id + "_dec\" value=\"" + Tools.Number.MoneyFormat(a.december) + "\"/></td>");
                sb.AppendLine("  </tr>");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        public void ClearBudget(ContextRz context)
        {
            if (Accounts == null || Accounts.Count <= 0)
                GatherAccounts(context);
            foreach (budget_account b in Accounts)
            {
                b.ClearBudget(context);
            }
        }
        //Private Static Functions
        private static void CreateBudgetAccounts(ContextRz context, budget b, NewBudgetArgs bArgs)
        {
            if (b == null)
                return;
            AccountCriteria args = new AccountCriteria();
            args.Types.Add(AccountType.Income);
            args.Types.Add(AccountType.CostOfGoodsSold);
            args.Types.Add(AccountType.Expense);
            args.Types.Add(AccountType.OtherIncome);
            args.Types.Add(AccountType.OtherExpense);
            List<account> l = context.Accounts.GetAccounts(context, args);
            foreach (account a in l)
            {
                budget_account ba = new budget_account();
                ba.account_fullname = a.full_name;
                ba.account_name = a.name;
                ba.account_number = a.number;
                ba.account_uid = a.unique_id;                
                ba.budget_name = b.budget_name;
                ba.budget_uid = b.unique_id;
                ba.budget_year = b.budget_year;
                if (!bArgs.FromScratch)
                    ValuesFromPreviousYear(context, ba);
                ba.Insert(context);
            }
        }
        private static void ValuesFromPreviousYear(ContextRz context, budget_account a)
        {
            int year = a.budget_year - 1;
            if (year <= 1900)
                return;
            Tools.Dates.DateRange dr = new Tools.Dates.DateRange();
            for (int i = 1; i < 12; i++)
            {
                dr.StartDate = new DateTime(year, i, 1);
                dr.EndDate = Tools.Dates.GetMonthEnd(dr.StartDate);
                double bal = context.SelectScalarDouble("select top 1 balance from journal where account_uid = '" + a.account_uid + "' and date_created " + dr.GetBetweenSQL() + " order by date_created desc");
                switch (i)
                {
                    case 1:
                        a.jan = bal;
                        break;
                    case 2:
                        a.feb = bal;
                        break;
                    case 3:
                        a.march = bal;
                        break;
                    case 4:
                        a.april = bal;
                        break;
                    case 5:
                        a.may = bal;
                        break;
                    case 6:
                        a.june = bal;
                        break;
                    case 7:
                        a.july = bal;
                        break;
                    case 8:
                        a.august = bal;
                        break;
                    case 9:
                        a.sept = bal;
                        break;
                    case 10:
                        a.oct = bal;
                        break;
                    case 11:
                        a.nov = bal;
                        break;
                    case 12:
                        a.december = bal;
                        break;
                }
            }
        }
    }
}
