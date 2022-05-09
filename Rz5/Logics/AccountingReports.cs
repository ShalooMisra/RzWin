using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections;
using System.Data;

namespace Rz5
{
    public partial class AccountLogic
    {
        public void ShowIncomeStatement(ContextRz context, Tools.Dates.DateRange dr, bool pdf = false)
        {
            IncomeStatementReport r = new IncomeStatementReport(dr, pdf);
            context.TheLeaderRz.ShowAccountingReport(context, r);
        }
        public void ShowStatementOfOwnersEquity(ContextRz context, Tools.Dates.DateRange dr, bool pdf = false)
        {
            OwnersEquityReport r = new OwnersEquityReport(dr, pdf);
            context.TheLeaderRz.ShowAccountingReport(context, r);
        }
        public void ShowBalanceSheet(ContextRz context, DateTime dr, bool pdf = false)
        {
            Tools.Dates.DateRange d = new Tools.Dates.DateRange(dr, dr);
            BalanceSheetReport r = new BalanceSheetReport(d, pdf);
            context.TheLeaderRz.ShowAccountingReport(context, r);
        }
        public void ShowStatementOfCashFlows(ContextRz context, Tools.Dates.DateRange dr, bool pdf = false)
        {
            CashFlowsReport r = new CashFlowsReport(dr, pdf);
            context.TheLeaderRz.ShowAccountingReport(context, r);
        }
        public void ShowTrialBalance(ContextRz context, Tools.Dates.DateRange dr, bool pdf = false)
        {
            TrialBalanceReport r = new TrialBalanceReport(dr, pdf);
            context.TheLeaderRz.ShowAccountingReport(context, r);
        }
        public void ShowReconciliationReport(ContextRz context, ReconcileArgs args, bool pdf = false)
        {
            Tools.Dates.DateRange d = new Tools.Dates.DateRange(args.StatementDate, args.StatementDate);
            ReconciliationReport r = new ReconciliationReport(d, args, pdf);
            context.TheLeaderRz.ShowAccountingReport(context, r);
        }
    }
    public abstract class AccountingReport
    {
        //Public Variables
        public Tools.Dates.DateRange DateRange;
        public bool PDF = false;
        public AccountingReportAction Action = new AccountingReportAction();
        //Protected Variables
        protected List<ReportLine> ReportLines;
        protected List<List<account>> AllAccounts = new List<List<account>>();

        //Constructors
        public AccountingReport(Tools.Dates.DateRange dr, bool pdf)
        {
            DateRange = dr;
            PDF = pdf;
        }
        //Public Abstract Functions
        public abstract String ReportTitle
        {
            get;
        }
        public abstract AccountingReportType ReportType
        {
            get;
        }
        //Protected Abstract Functions
        protected abstract void InitAccounts(ContextRz context);
        protected abstract void LoadAccountBalances(ContextRz context);
        protected abstract void CreateAccountTrees(ContextRz context);
        protected abstract void FillAllAccounts(ContextRz context);
        protected abstract void CreateReportLines(ContextRz context);
        //Public Functions
        public void RunReport(ContextRz context)
        {
            InitAccounts(context);
            LoadAccountBalances(context);
            CreateAccountTrees(context);
            FillAllAccounts(context);
            CreateReportLines(context);
        }
        public string GetReport(ContextRz context)
        {
            RunReport(context);
            if (PDF)
                return GetPDF(context);
            else
                return GetHTML(context);
        }
        public account GetAccountByName(ContextRz context, string full_name)
        {
            if (!Tools.Strings.StrExt(full_name))
                return null;
            foreach (List<account> l in AllAccounts)
            {
                foreach (account a in l)
                {
                    account aa = GetAccountByName(context, a, full_name);
                    if (aa != null)
                        return aa;
                }
            }
            return null;
        }
        //Protected Functions                       
        protected string GetHTML(ContextRz context)
        {
            string comp = OwnerSettings.GetValue(context, OwnerSettingField.owner_companyname, false);
            string date_range = FormatDateForReport(DateRange.StartDate) + " through " + FormatDateForReport(DateRange.EndDate);
            if (ReportType == AccountingReportType.BalanceSheet || ReportType == AccountingReportType.TrialBalance || ReportType == AccountingReportType.Reconciliation)
                date_range = "As of " + FormatDateForReport(DateRange.EndDate);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<head>");
            sb.AppendLine("    <style type=\"text/css\">");
            sb.AppendLine("		body {  font-family: Sans-Serif; }");
            sb.AppendLine("	</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td align=\"center\"><font size=\"4\">" + comp + "</font></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td align=\"center\"><font size=\"5\">" + ReportTitle + "</font></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td align=\"center\"><font size=\"2\">" + date_range + "</font></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td>&nbsp;</td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            switch (ReportType)
            {
                case AccountingReportType.TrialBalance:
                    sb.AppendLine(GetTrialBalanceHTML(context));
                    break;
                default:
                    sb.AppendLine(GetStandardHTML(context));
                    break;
            }
            return sb.ToString();
        }
        protected string GetPDF(ContextRz context)
        {
            string file = "c:\\bilge\\temp_" + Tools.Strings.GetNewID() + "_pdf.pdf";
            //Tools.PDFWrapper pdf = new Tools.PDFWrapper(file, false);
            //pdf.cb.SetLineWidth(.25f);
            //string comp = OwnerSettings.GetValue(context, OwnerSettingField.owner_companyname, false);
            //Font fontHeader = FontFactory.GetFont("Sans-Serif", 7);
            //fontHeader.SetStyle("bold");
            //Paragraph p = new Paragraph(comp, fontHeader);
            //p.Alignment = Element.ALIGN_CENTER;
            //pdf.doc1.Add(p);
            //fontHeader = FontFactory.GetFont("Sans-Serif", 9);
            //fontHeader.SetStyle("bold");
            //p = new Paragraph("Balance Sheet", fontHeader);
            //p.Alignment = Element.ALIGN_CENTER;
            //pdf.doc1.Add(p);
            //fontHeader = FontFactory.GetFont("Sans-Serif", 6);
            //p = new Paragraph("As of " + DateTime.Now.ToLongDateString(), fontHeader);
            //p.Alignment = Element.ALIGN_CENTER;
            //pdf.doc1.Add(p);
            //p = new Paragraph("\n");
            //pdf.doc1.Add(p);
            //PdfPTable table = new PdfPTable(2);
            //table.TotalWidth = 216f;
            //table.LockedWidth = true;
            //float[] widths = new float[] { 2f, 1f };
            //table.SetWidths(widths);
            //foreach (ReportLine l in ReportLines)
            //{
            //    Font fontBody = FontFactory.GetFont("Sans-Serif", 6);
            //    if (l.is_header || l.is_final_total || l.is_total)
            //        fontBody.SetStyle("bold");
            //    PdfPCell c = new PdfPCell(new Paragraph(l.Text, fontBody));
            //    c.Border = 0;
            //    c.HorizontalAlignment = 0;
            //    table.AddCell(c);
            //    fontBody = FontFactory.GetFont("Sans-Serif", 6);
            //    string bal = "";
            //    Paragraph par = null;
            //    if (!l.is_header)
            //    {
            //        bal = Tools.Number.MoneyFormat(l.amount);
            //        if (l.is_final_total)//double line bottom
            //        {
            //            par = new Paragraph(Tools.Number.MoneyFormat(l.amount), fontBody);
            //            fontBody.SetStyle("underline");
            //            //par.Add(new Phrase("\n" + new string('_', Tools.Number.MoneyFormat(l.amount).Length), fontBody));
            //            //bal = Tools.Number.MoneyFormat(l.amount) + "\n" + new string('A', Tools.Number.MoneyFormat(l.amount).Length);                        
            //            //bal = Tools.Number.MoneyFormat(l.amount) + "\n" + new string('\u2550', 10);
            //        }
            //        else if (l.is_total)//single line bottom
            //            fontBody.SetStyle("underline");
            //    }
            //    if (par == null)
            //        par = new Paragraph(bal, fontBody);
            //    c = new PdfPCell(par);
            //    c.Border = 0;
            //    c.HorizontalAlignment = 2;
            //    table.AddCell(c);
            //    //if (!l.is_header)
            //    //{
            //    //    return Assets.GroupTotal(context) == LiabilitiesAndEquity.GroupTotal(context);
            //    //{
            //    //    if (l.is_final_total)//double line bottom
            //    //    {
            //    //        float curY = pdf.writer.GetVerticalPosition(false);
            //    //        float x = pdf.doc1.Left + par.Chunks[0].GetWidthPoint();
            //    //        pdf.cb.MoveTo(x, curY);
            //    //        pdf.cb.LineTo(x + 40, curY);
            //    //        pdf.cb.Stroke();
            //    //    }
            //    //}
            //    //}
            //    fontBody = FontFactory.GetFont("Sans-Serif", 6);
            //    if (l.is_final_total || l.is_total)
            //    {
            //        c = new PdfPCell(new Paragraph("", fontBody));
            //        c.Border = 0;
            //        c.HorizontalAlignment = 0;
            //        table.AddCell(c);
            //        c = new PdfPCell(new Paragraph("", fontBody));
            //        c.Border = 0;
            //        c.HorizontalAlignment = 2;
            //        table.AddCell(c);
            //    }
            //}
            //pdf.doc1.Add(table);
            //pdf.CloseDoc();
            //Tools.FileSystem.Shell(file);
            return file;
        }
        protected void ShowAccounts(ContextRz context, account a, int indent)
        {
            string line = Indent(indent) + account.GetAccountFullNameWithBullet(a);
            if (a.SubAccountsList(context).Count <= 0)
            {
                if (a.balance != 0)
                    ReportLines.Add(new ReportLine(line, a.balance, false, false, false, a.unique_id));
            }
            else
            {
                double total = 0;
                foreach (account aa in a.SubAccountsList(context))
                {
                    total += aa.balance;
                }
                if (total != 0)
                {
                    ReportLines.Add(new ReportLine(line, 0, true, false, false, a.unique_id));
                    indent += 1;
                    foreach (account aa in a.SubAccountsList(context))
                    {
                        ShowAccounts(context, aa, indent);
                    }
                    indent -= 1;
                    ReportLines.Add(new ReportLine(Indent(indent) + "Total " + account.GetAccountFullNameWithBullet(a), a.Balance(context), false, true, false, a.unique_id));
                }
            }
        }
        protected void CreateAccountTree(ContextRz context, ref List<account> l)
        {
            Dictionary<String, account> hold = new Dictionary<String, account>();
            foreach (account a in l)
            {
                if (!Tools.Strings.StrExt(a.parent_id))
                    hold.Add(a.unique_id, a);
            }
            foreach (account a in l)
            {
                if (Tools.Strings.StrExt(a.parent_id))
                {
                    account aa = null;
                    hold.TryGetValue(a.parent_id, out aa);
                    if (aa != null)
                        aa.SubAccountsListAdd(context, a);
                }
            }
            foreach (KeyValuePair<string, account> kvp in hold)
            {
                if (kvp.Value.SubAccountsList(context).Count > 0)
                    kvp.Value.SubAccountsListSet(context, SortAccountTree(kvp.Value.SubAccountsList(context)));
            }
            l = new List<account>();
            foreach (KeyValuePair<string, account> kvp in hold)
            {
                if (kvp.Value.balance != 0 && kvp.Value.SubAccountsList(context).Count > 0)
                {
                    account a = (account)kvp.Value.CloneValues(context);
                    a.unique_id = "notanid_" + kvp.Value.unique_id;
                    a.name = a.name + " - Other";
                    a.full_name = a.name;
                    kvp.Value.SubAccountsListAdd(context, a);
                    kvp.Value.balance = 0;
                }
                l.Add(kvp.Value);
            }
            l = SortAccountTree(l);
        }
        protected void LoadAccounts(ContextRz context, ref List<account> al, AccountType t)
        {
            if (context == null)
                return;
            if (al == null)
                al = new List<account>();
            ArrayList acnts = context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(t.ToString()) + "'");
            foreach (account a in acnts)            
            {                 
                if (a == null)
                    continue;
                a.balance = 0;
                al.Add(a);
            }
            SortAccountTree(al);
        }
        protected String Indent(int count)
        {
            string indent = "&nbsp;&nbsp;&nbsp;";
            if (PDF)
                indent = "   ";
            string ret = "";
            if (count <= 0)
                return ret;
            for (int i = 0; i < count; i++)
            {
                ret += indent;
            }
            return ret;
        }
        protected List<account> SortAccountTree(List<account> al)
        {
            //sort accounts by number (if it has one) stack non-numbered accounts on top
            ArrayList non_numbered = new ArrayList();
            SortedList sl = new SortedList();
            try
            {
                foreach (account a in al)
                {
                    if (a.number != 0)
                        sl.Add(a.number, a);
                    else
                        non_numbered.Add(a);
                }
            }
            catch
            {
                return al;
            }
            al = new List<account>();
            foreach (account a in non_numbered)
            {
                al.Add(a);
            }
            foreach (DictionaryEntry d in sl)
            {
                al.Add((account)d.Value);
            }
            return al;
        }
        //Private Functions
        private string GetStandardHTML(ContextRz context)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"22%\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"68%\">");
            sb.AppendLine("      <table border=\"0\" width=\"100%\" cellspacing=\"0\">");
            foreach (ReportLine l in ReportLines)
            {
                sb.AppendLine("        <tr>");
                string bal = "";
                if (!l.is_header)
                {
                    if (l.is_final_total)
                        bal = "<div style=\"display: inline-block; border-bottom-style: double;\"><b>" + Tools.Number.MoneyFormat(l.amount) + "</b></div>";
                    else if (l.is_total)
                        bal = "<div style=\"display: inline-block; border-width: thin; border-top-style: solid;\">" + Tools.Number.MoneyFormat(l.amount) + "</div>";
                    else
                        bal = Tools.Number.MoneyFormat(l.amount);
                }
                sb.AppendLine("          <td width=\"56%\"><font size=\"2\"><div>" + l.GetAccountText(context, Action) + "</div></font></td>");
                sb.AppendLine("          <td width=\"44%\">");
                sb.AppendLine("            <table border=\"0\" width=\"39%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("              <tr>");
                sb.AppendLine("                <td width=\"100%\" align=\"right\"><font size=\"2\">" + bal + "</font></td>");
                sb.AppendLine("              </tr>");
                sb.AppendLine("            </table>");
                sb.AppendLine("          </td>");
                sb.AppendLine("        </tr>");
                if (l.is_final_total || l.is_total)
                {
                    sb.AppendLine("        <tr>");
                    sb.AppendLine("          <td width=\"56%\"><font size=\"2\">&nbsp;</font></td>");
                    sb.AppendLine("          <td width=\"44%\"><font size=\"2\">&nbsp;</font></td>");
                    sb.AppendLine("        </tr>");
                }
            }
            sb.AppendLine("      </table>");
            sb.AppendLine("    </td>");
            sb.AppendLine("    <td width=\"10%\">&nbsp;</td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            return sb.ToString();
        }
        private string GetTrialBalanceHTML(ContextRz context)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"22%\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"47%\">");
            sb.AppendLine("      <table border=\"0\" width=\"100%\" cellspacing=\"5\" cellpadding=\"0\">");
            sb.AppendLine("        <tr>");
            sb.AppendLine("          <td width=\"33%\"></td>");
            sb.AppendLine("          <td width=\"33%\" align=\"center\"><b><font size=\"2\"><div style=\"display: inline-block; border-width: thin; border-bottom-style: solid; border-top-style: solid;\">Debit</div></font></b></td>");
            sb.AppendLine("          <td width=\"34%\" align=\"center\"><b><font size=\"2\"><div style=\"display: inline-block; border-width: thin; border-bottom-style: solid; border-top-style: solid;\">Credit</div></font></b></td>");
            sb.AppendLine("        </tr>");
            foreach (ReportLine l in ReportLines)
            {
                string debit = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                string credit = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                if (l.debit > 0)
                    debit = Tools.Number.MoneyFormat(l.debit);
                else
                    credit = Tools.Number.MoneyFormat(l.credit);
                string div_b = "";
                string div_e = "";
                if (l.is_final_total)
                {
                    div_b = "<div style=\"display: inline-block; border-bottom-style: double;\"><b>";
                    div_e = "</b></div>";
                    debit = Tools.Number.MoneyFormat(l.debit);
                    credit = Tools.Number.MoneyFormat(l.credit);
                    l.is_final_total = false;
                }
                else if (l.is_total)
                {
                    div_b = "<div style=\"display: inline-block; border-width: thin; border-bottom-style: solid;\">";
                    div_e = "</div>";
                    l.is_total = false;
                }
                sb.AppendLine("        <tr>");
                sb.AppendLine("          <td width=\"33%\"><b><font size=\"2\">" + l.GetAccountText(context, Action) + "</font></b></td>");
                sb.AppendLine("          <td width=\"33%\" align=\"right\"><font size=\"2\">" + div_b + debit + div_e + "</font></td>");
                sb.AppendLine("          <td width=\"34%\" align=\"right\"><font size=\"2\">" + div_b + credit + div_e + "</font></td>");
                sb.AppendLine("        </tr>");
            }
            sb.AppendLine("      </table>");
            sb.AppendLine("    </td>");
            sb.AppendLine("    <td width=\"31%\">&nbsp;</td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        private account GetAccountByName(ContextRz context, account a, string full_name)
        {
            if (!Tools.Strings.StrExt(full_name))
                return null;
            if (a == null)
                return null;
            if (Tools.Strings.StrCmp(a.full_name, full_name))
                return a;
            if (a.SubAccountsList(context).Count > 0)
            {
                account aa = GetSubAccountByName(context, a, full_name);
                if (aa != null)
                    return aa;
            }
            return null;
        }
        private account GetSubAccountByName(ContextRz context, account a, string full_name)
        {
            if (!Tools.Strings.StrExt(full_name))
                return null;
            if (a == null)
                return null;
            foreach (account aa in a.SubAccountsList(context))
            {
                if (Tools.Strings.StrCmp(aa.full_name, full_name))
                    return aa;
                if (aa.SubAccountsList(context).Count > 0)
                {
                    account aaa = GetSubAccountByName(context, aa, full_name);
                    if (aaa != null)
                        return aaa;
                }
            }
            return null;
        }
        private String FormatDateForReport(DateTime dt)
        {
            string hold = dt.ToLongDateString();
            hold = hold.Replace("Monday,", "").Trim();
            hold = hold.Replace("Tuesday,", "").Trim();
            hold = hold.Replace("Wednesday,", "").Trim();
            hold = hold.Replace("Thursday,", "").Trim();
            hold = hold.Replace("Friday,", "").Trim();
            hold = hold.Replace("Saturday,", "").Trim();
            hold = hold.Replace("Sunday,", "").Trim();
            return hold;
        }
        //Public Classes
        public class ReportLine
        {
            public string Text = "";
            public double amount = 0;
            public double credit = 0;
            public double debit = 0;
            public bool is_header = false;
            public bool is_total = false;
            public bool is_final_total = false;
            private string AccountID = "";

            public ReportLine(string text, double amnt, bool header = false, bool total = false, bool final = false, string account_id = "")
            {
                AccountID = account_id;
                Text = text;
                amount = amnt;
                is_header = header;
                is_total = total;
                is_final_total = final;
            }
            public override string ToString()
            {
                string amnt = Tools.Number.MoneyFormat(amount);
                if (credit > 0 || debit > 0)
                {
                    if (is_final_total)
                        amnt = " Credit: " + Tools.Number.MoneyFormat(credit) + " Debit: " + Tools.Number.MoneyFormat(debit);
                    else
                    {
                        if (credit > 0)
                            amnt = " Credit: " + Tools.Number.MoneyFormat(credit);
                        else
                            amnt = " Debit: " + Tools.Number.MoneyFormat(debit);
                    }
                }
                return Text + " : " + amnt;
            }
            public string GetAccountText(ContextRz x, AccountingReportAction a)
            {
                string text = "";
                if (!Tools.Strings.StrExt(Text))
                    text = "&nbsp;";
                if (is_header || is_final_total || is_total)
                    text = "<b>" + Text + "</b>";
                else
                    text = Text;
                if (Tools.Strings.StrExt(AccountID))
                    text = x.TheLeaderRz.GetAccountReportLink(AccountID, text, a);
                return text;
            }
        }
    }
    public class AccountingReportAction
    {
        public string ScreenId = "";
        public string SpotId = "";
    }
    public class IncomeStatementReport : AccountingReport
    {
        public double NetIncomeAmount = 0;
        private IncomeArgs Args;
        private List<account> IncomeAccounts;
        private List<account> CostOfGoodsAccounts;
        private List<account> ExpenseAccounts;
        private List<account> OtherIncomeAccounts;
        private List<account> OtherExpenseAccounts;

        //Constructors
        public IncomeStatementReport(Tools.Dates.DateRange dr, bool pdf)
            : base(dr, pdf)
        {

        }
        //Public Override Functions
        public override String ReportTitle
        {
            get
            {
                return "Income Statement [Profit & Loss]";
            }
        }
        public override AccountingReportType ReportType
        {
            get
            {
                return AccountingReportType.IncomeStatement;
            }
        }
        //Protected Override Functions
        protected override void InitAccounts(ContextRz context)
        {
            IncomeAccounts = new List<account>();
            LoadAccounts(context, ref IncomeAccounts, AccountType.Income);

            CostOfGoodsAccounts = new List<account>();
            LoadAccounts(context, ref CostOfGoodsAccounts, AccountType.CostOfGoodsSold);

            ExpenseAccounts = new List<account>();
            LoadAccounts(context, ref ExpenseAccounts, AccountType.Expense);

            OtherIncomeAccounts = new List<account>();
            LoadAccounts(context, ref OtherIncomeAccounts, AccountType.OtherIncome);

            OtherExpenseAccounts = new List<account>();
            LoadAccounts(context, ref OtherExpenseAccounts, AccountType.OtherExpense);
        }
        protected override void LoadAccountBalances(ContextRz context)
        {
            Args = new IncomeArgs();
            //Revenue/Income accounts - credit
            foreach (account a in IncomeAccounts)
            {
                a.balance = context.SelectScalarDouble("select sum(credit_amount) - sum(debit_amount) from journal where account_id = '" + a.unique_id + "' and date_created " + DateRange.GetBetweenSQL());
                Args.TotalIncome += a.balance;
            }
            //CostOfGoods accounts - debit
            foreach (account a in CostOfGoodsAccounts)
            {
                a.balance = context.SelectScalarDouble("select sum(debit_amount) - sum(credit_amount) from journal where account_id = '" + a.unique_id + "' and date_created " + DateRange.GetBetweenSQL());
                Args.TotalCOGS += a.balance;
            }
            //Expense accounts - debit
            foreach (account a in ExpenseAccounts)
            {
                a.balance = context.SelectScalarDouble("select sum(debit_amount) - sum(credit_amount) from journal where account_id = '" + a.unique_id + "' and date_created " + DateRange.GetBetweenSQL());
                Args.TotalExpense += a.balance;
            }
            //OtherIncome accounts - credit
            foreach (account a in OtherIncomeAccounts)
            {
                a.balance = context.SelectScalarDouble("select sum(credit_amount) - sum(debit_amount) from journal where account_id = '" + a.unique_id + "' and date_created " + DateRange.GetBetweenSQL());
                Args.TotalOtherIncome += a.balance;
            }
            //OtherExpense accounts - debit
            foreach (account a in OtherExpenseAccounts)
            {
                a.balance = context.SelectScalarDouble("select sum(debit_amount) - sum(credit_amount) from journal where account_id = '" + a.unique_id + "' and date_created " + DateRange.GetBetweenSQL());
                Args.TotalOtherExpense += a.balance;
            }
            NetIncomeAmount = Args.NetIncomeAmount;
        }
        protected override void CreateAccountTrees(ContextRz context)
        {
            CreateAccountTree(context, ref IncomeAccounts);
            CreateAccountTree(context, ref CostOfGoodsAccounts);
            CreateAccountTree(context, ref ExpenseAccounts);
            CreateAccountTree(context, ref OtherIncomeAccounts);
            CreateAccountTree(context, ref OtherExpenseAccounts);
        }
        protected override void FillAllAccounts(ContextRz context)
        {
            AllAccounts.Add(IncomeAccounts);
            AllAccounts.Add(CostOfGoodsAccounts);
            AllAccounts.Add(ExpenseAccounts);
            AllAccounts.Add(OtherIncomeAccounts);
            AllAccounts.Add(OtherExpenseAccounts);
        }
        protected override void CreateReportLines(ContextRz context)
        {
            ReportLines = new List<ReportLine>();
            if (NetIncomeAmount == 0)
            {
                ReportLines.Add(new ReportLine("Net Income", NetIncomeAmount, false, false, true));
                return;
            }
            //OrdinaryIncomeExpense
            ReportLines.Add(new ReportLine("Ordinary Income/Expense", 0, true));
            //Income
            if (Args.TotalIncome != 0)
            {
                ReportLines.Add(new ReportLine(Indent(1) + "Income", 0, true));
                foreach (account a in IncomeAccounts)
                {
                    ShowAccounts(context, a, 2);
                }
                ReportLines.Add(new ReportLine(Indent(1) + "Total Income", Args.TotalIncome, false, true, false));
            }
            //COGS
            if (Args.TotalCOGS != 0)
            {
                ReportLines.Add(new ReportLine(Indent(1) + "Cost Of Goods Sold", 0, true));
                foreach (account a in CostOfGoodsAccounts)
                {
                    ShowAccounts(context, a, 2);
                }
                ReportLines.Add(new ReportLine(Indent(1) + "Total COGS", Args.TotalCOGS, false, true, false));
            }
            if (Args.GrossProfit != 0)
                ReportLines.Add(new ReportLine("Gross Profit", Args.GrossProfit, false, true, false));
            //Expense
            if (Args.TotalExpense != 0)
            {
                ReportLines.Add(new ReportLine(Indent(1) + "Expense", 0, true));
                foreach (account a in ExpenseAccounts)
                {
                    ShowAccounts(context, a, 2);
                }
                ReportLines.Add(new ReportLine(Indent(1) + "Total Expense", Args.TotalExpense, false, true, false));
            }
            ReportLines.Add(new ReportLine("Net Ordinary Income/Expense", Args.NetOrdinaryIncome, false, true, false));
            if ((Args.TotalOtherIncome - Args.TotalOtherExpense) != 0)
            {
                ReportLines.Add(new ReportLine(Indent(1) + "Other Income/Expense", 0, true));
                //Other Income
                if (Args.TotalOtherIncome != 0)
                {
                    ReportLines.Add(new ReportLine(Indent(1) + "Other Income", 0, true));
                    foreach (account a in OtherIncomeAccounts)
                    {
                        ShowAccounts(context, a, 2);
                    }
                    ReportLines.Add(new ReportLine(Indent(1) + "Total Other Income", Args.TotalOtherIncome, false, true, false));
                }
                //Other Expense
                if (Args.TotalOtherExpense != 0)
                {
                    ReportLines.Add(new ReportLine(Indent(1) + "Other Expense", 0, true));
                    foreach (account a in OtherExpenseAccounts)
                    {
                        ShowAccounts(context, a, 2);
                    }
                    ReportLines.Add(new ReportLine(Indent(1) + "Total Other Expense", Args.TotalOtherExpense, false, true, false));
                }
                ReportLines.Add(new ReportLine(Indent(1) + "Net Other Income/Expense", Args.TotalOtherIncome - Args.TotalOtherExpense, false, true, false));
            }
            ReportLines.Add(new ReportLine("Net Income", NetIncomeAmount, false, false, true));
        }
        private class IncomeArgs
        {
            public double TotalIncome = 0; //Income Accounts
            public double TotalCOGS = 0; //Cost Of Goods Accounts
            public double GrossProfit//Income - COGS
            {
                get
                {
                    return TotalIncome - TotalCOGS;
                }
            }
            public double TotalExpense = 0; //Expense Accounts
            public double NetOrdinaryIncome//GrossProfit - TotalExpense
            {
                get
                {
                    return GrossProfit - TotalExpense;
                }
            }
            public double TotalOtherIncome = 0; //Other Income Accounts
            public double TotalOtherExpense = 0; //Other Expense Accounts
            public double NetOtherIncome//TotalOtherIncome - TotalOtherExpense
            {
                get
                {
                    return TotalOtherIncome - TotalOtherExpense;
                }
            }
            public double NetIncomeAmount//NetOrdinaryIncome + NetOtherIncome
            {
                get
                {
                    return NetOrdinaryIncome + NetOtherIncome;
                }
            }
        }
    }
    public class OwnersEquityReport : AccountingReport
    {
        private OwnersEquityArgs Args;
        private List<account> EquityAccounts;

        //Constructors
        public OwnersEquityReport(Tools.Dates.DateRange dr, bool pdf)
            : base(dr, pdf)
        {

        }
        //Public Override Functions
        public override string ReportTitle
        {
            get
            {
                return "Statement Of Owner's Equity";
            }
        }
        public override AccountingReportType ReportType
        {
            get
            {
                return AccountingReportType.OwnersEquity;
            }
        }
        //Protected Override Functions
        protected override void InitAccounts(ContextRz context)
        {
            EquityAccounts = new List<account>();
            LoadAccounts(context, ref EquityAccounts, AccountType.Equity);
        }
        protected override void LoadAccountBalances(ContextRz context)
        {
            //+ Beginning Capital (Should be all equity accounts for the beginning date range)
            //+ Net Income (Should be net income for date range)
            //- Withdraws (Should be any equity withdraws for date range)
            //= End Balance Capital (Should be BegCap + NetIncome - Withdraws)
            Args = new OwnersEquityArgs();
            IncomeStatementReport IncomeReport = new IncomeStatementReport(DateRange, PDF);
            IncomeReport.RunReport(context);
            foreach (account a in EquityAccounts)//Need to get balance of all equity accounts at start date range
            {
                a.balance = context.SelectScalarDouble("select top 1 balance from journal where account_id = '" + a.unique_id + "' and date_created < cast('" + DateRange.StartDate.ToShortDateString() + " 00:00:00' as datetime) order by date_created desc");
                Args.StartingEquity += a.balance;
            }
            Args.NetIncome = IncomeReport.NetIncomeAmount;
            foreach (account a in EquityAccounts)//Need to get balance of all increases to equity accounts during date range
            {   //Owner's equity - credit
                Args.Increases += context.SelectScalarDouble("select sum(credit_amount) from journal where account_id = '" + a.unique_id + "' and date_created " + DateRange.GetBetweenSQL());
            }
            foreach (account a in EquityAccounts)//Need to get balance of all withdraws to equity accounts during date range
            {   //Owner's equity - credit
                Args.Withdraws += context.SelectScalarDouble("select sum(debit_amount) from journal where account_id = '" + a.unique_id + "' and date_created " + DateRange.GetBetweenSQL());
            }
        }
        protected override void CreateAccountTrees(ContextRz context)
        {
            CreateAccountTree(context, ref EquityAccounts);
        }
        protected override void FillAllAccounts(ContextRz context)
        {
            AllAccounts.Add(EquityAccounts);
        }
        protected override void CreateReportLines(ContextRz context)
        {
            ReportLines = new List<ReportLine>();
            ReportLines.Add(new ReportLine("Starting Equity:", Args.StartingEquity));
            if (Args.NetIncome != 0)
                ReportLines.Add(new ReportLine("Net Income(+):", Args.NetIncome));
            if (Args.Increases != 0)
                ReportLines.Add(new ReportLine("Captial Increases(+):", Args.Increases));
            if (Args.Withdraws != 0)
                ReportLines.Add(new ReportLine("Capital Withdraws(-):", Args.Withdraws * -1));
            ReportLines.Add(new ReportLine("", 0, true));
            ReportLines.Add(new ReportLine("Ending Equity:", Args.EndingEquity, false, false, true));
        }
        private class OwnersEquityArgs
        {
            public double StartingEquity = 0;
            public double NetIncome = 0;
            public double Increases = 0;
            public double Withdraws = 0;
            public double EndingEquity
            {
                get
                {
                    return StartingEquity + NetIncome + Increases - Withdraws;
                }
            }
        }
    }
    public class BalanceSheetReport : AccountingReport
    {
        public double CashOnHand = 0;
        private BalanceSheetArgs Args;
        private List<account> BankAccounts;
        private List<account> AccountsReceivableAccounts;
        private List<account> OtherCurrentAssetAccounts;
        private List<account> FixedAssetAccounts;
        private List<account> OtherAssetAccounts;
        private List<account> AccountsPayableAccounts;
        private List<account> CreditCardAccounts;
        private List<account> OtherCurrentLiabilityAccounts;
        private List<account> LongTermLiabilityAccounts;
        private List<account> EquityAccounts;

        //Constructors
        public BalanceSheetReport(Tools.Dates.DateRange dr, bool pdf)
            : base(dr, pdf)
        {

        }
        //Public Override Functions
        public override string ReportTitle
        {
            get
            {
                return "Balance Sheet";
            }
        }
        public override AccountingReportType ReportType
        {
            get
            {
                return AccountingReportType.BalanceSheet;
            }
        }
        //Protected Override Functions
        protected override void InitAccounts(ContextRz context)
        {
            BankAccounts = new List<account>();
            LoadAccounts(context, ref BankAccounts, AccountType.Bank);

            AccountsReceivableAccounts = new List<account>();
            LoadAccounts(context, ref AccountsReceivableAccounts, AccountType.AccountsReceivable);

            OtherCurrentAssetAccounts = new List<account>();
            LoadAccounts(context, ref OtherCurrentAssetAccounts, AccountType.OtherCurrentAssets);

            FixedAssetAccounts = new List<account>();
            LoadAccounts(context, ref FixedAssetAccounts, AccountType.FixedAssets);

            OtherAssetAccounts = new List<account>();
            LoadAccounts(context, ref OtherAssetAccounts, AccountType.OtherAssets);

            AccountsPayableAccounts = new List<account>();
            LoadAccounts(context, ref AccountsPayableAccounts, AccountType.AccountsPayable);

            CreditCardAccounts = new List<account>();
            LoadAccounts(context, ref CreditCardAccounts, AccountType.CreditCard);

            OtherCurrentLiabilityAccounts = new List<account>();
            LoadAccounts(context, ref OtherCurrentLiabilityAccounts, AccountType.OtherCurrentLiabilities);

            LongTermLiabilityAccounts = new List<account>();
            LoadAccounts(context, ref LongTermLiabilityAccounts, AccountType.LongTermLiabilities);

            EquityAccounts = new List<account>();
            LoadAccounts(context, ref EquityAccounts, AccountType.Equity);
        }
        protected override void LoadAccountBalances(ContextRz context)
        {
            Args = new BalanceSheetArgs();
            Tools.Dates.DateRange dr = new Tools.Dates.DateRange(new DateTime(DateRange.EndDate.Year, 1, 1), DateRange.EndDate);
            IncomeStatementReport IncomeReport = new IncomeStatementReport(dr, PDF);
            IncomeReport.RunReport(context);
            Args.NetIncome = IncomeReport.NetIncomeAmount;
            foreach (account a in BankAccounts)
            {
                a.balance = GetTopAccountBalance(context, a);
                Args.TotalCheckingSavings += a.balance;
            }
            foreach (account a in AccountsReceivableAccounts)
            {
                a.balance = GetTopAccountBalance(context, a);
                Args.TotalAccountsReceivable += a.balance;
            }
            foreach (account a in OtherCurrentAssetAccounts)
            {
                a.balance = GetTopAccountBalance(context, a);
                Args.TotalOtherCurrentAssets += a.balance;
                if (Tools.Strings.StrCmp(a.full_name, "Undeposited Funds"))
                    CashOnHand = Args.TotalCheckingSavings + a.balance;
            }
            foreach (account a in FixedAssetAccounts)
            {
                a.balance = GetTopAccountBalance(context, a);
                Args.TotalFixedAssets += a.balance;
            }
            foreach (account a in OtherAssetAccounts)
            {
                a.balance = GetTopAccountBalance(context, a);
                Args.TotalOtherAssets += a.balance;
            }
            foreach (account a in AccountsPayableAccounts)
            {
                a.balance = GetTopAccountBalance(context, a);
                Args.TotalAccountsPayable += a.balance;
            }
            foreach (account a in CreditCardAccounts)
            {
                a.balance = GetTopAccountBalance(context, a);
                Args.TotalCreditCards += a.balance;
            }
            foreach (account a in OtherCurrentLiabilityAccounts)
            {
                a.balance = GetTopAccountBalance(context, a);
                Args.TotalOtherCurrentLiabilities += a.balance;
            }
            foreach (account a in LongTermLiabilityAccounts)
            {
                a.balance = GetTopAccountBalance(context, a);
                Args.TotalLongTermLiabilities += a.balance;
            }
            foreach (account a in EquityAccounts)
            {
                a.balance = GetTopAccountBalance(context, a);
                Args.TotalEquity += a.balance;
            }
            Args.TotalEquity += Args.NetIncome;
        }
        protected override void CreateAccountTrees(ContextRz context)
        {
            CreateAccountTree(context, ref BankAccounts);
            CreateAccountTree(context, ref AccountsReceivableAccounts);
            CreateAccountTree(context, ref OtherCurrentAssetAccounts);
            CreateAccountTree(context, ref FixedAssetAccounts);
            CreateAccountTree(context, ref OtherAssetAccounts);
            CreateAccountTree(context, ref AccountsPayableAccounts);
            CreateAccountTree(context, ref CreditCardAccounts);
            CreateAccountTree(context, ref OtherCurrentLiabilityAccounts);
            CreateAccountTree(context, ref LongTermLiabilityAccounts);
            CreateAccountTree(context, ref EquityAccounts);
        }
        protected override void FillAllAccounts(ContextRz context)
        {
            AllAccounts.Add(BankAccounts);
            AllAccounts.Add(AccountsReceivableAccounts);
            AllAccounts.Add(OtherCurrentAssetAccounts);
            AllAccounts.Add(FixedAssetAccounts);
            AllAccounts.Add(OtherAssetAccounts);
            AllAccounts.Add(AccountsPayableAccounts);
            AllAccounts.Add(CreditCardAccounts);
            AllAccounts.Add(OtherCurrentLiabilityAccounts);
            AllAccounts.Add(LongTermLiabilityAccounts);
            AllAccounts.Add(EquityAccounts);
        }
        protected override void CreateReportLines(ContextRz context)
        {
            ReportLines = new List<ReportLine>();
            //Assets
            ReportLines.Add(new ReportLine("ASSETS", 0, true));
            if (Args.TotalCurrentAssets != 0)
            {
                ReportLines.Add(new ReportLine(Indent(1) + "Current Assets", 0, true));
                //Checking/Savings
                if (Args.TotalCheckingSavings != 0)
                {
                    ReportLines.Add(new ReportLine(Indent(2) + "Checking/Savings", 0, true));
                    foreach (account a in BankAccounts)
                    {
                        ShowAccounts(context, a, 3);
                    }
                    ReportLines.Add(new ReportLine(Indent(2) + "Total Checking/Savings", Args.TotalCheckingSavings, false, true, false));
                }
                //Accounts Receivable
                if (Args.TotalAccountsReceivable != 0)
                {
                    ReportLines.Add(new ReportLine(Indent(2) + "Accounts Receivable", 0, true));
                    foreach (account a in AccountsReceivableAccounts)
                    {
                        ShowAccounts(context, a, 3);
                    }
                    ReportLines.Add(new ReportLine(Indent(2) + "Total Accounts Receivable", Args.TotalAccountsReceivable, false, true, false));
                }
                //Other Current Assets
                if (Args.TotalOtherCurrentAssets != 0)
                {
                    ReportLines.Add(new ReportLine(Indent(2) + "Other Current Assets", 0, true));
                    foreach (account a in OtherCurrentAssetAccounts)
                    {
                        ShowAccounts(context, a, 3);
                    }
                    ReportLines.Add(new ReportLine(Indent(2) + "Total Other Current Assets", Args.TotalOtherCurrentAssets, false, true, false));
                }
                ReportLines.Add(new ReportLine(Indent(1) + "Total Current Assets", Args.TotalCurrentAssets, false, true, false));
            }
            //Fixed Assets
            if (Args.TotalFixedAssets != 0)
            {
                ReportLines.Add(new ReportLine(Indent(2) + "Fixed Assets", 0, true));
                foreach (account a in FixedAssetAccounts)
                {
                    ShowAccounts(context, a, 3);
                }
                ReportLines.Add(new ReportLine(Indent(2) + "Total Other Current Assets", Args.TotalFixedAssets, false, true, false));
            }
            //Other Assets
            if (Args.TotalOtherAssets != 0)
            {
                ReportLines.Add(new ReportLine(Indent(2) + "Other Assets", 0, true));
                foreach (account a in OtherAssetAccounts)
                {
                    ShowAccounts(context, a, 3);
                }
                ReportLines.Add(new ReportLine(Indent(2) + "Total Other Current Assets", Args.TotalOtherAssets, false, true, false));
            }
            ReportLines.Add(new ReportLine("TOTAL ASSETS", Args.TotalAssets, false, false, true));
            //Liabilities & Equity
            ReportLines.Add(new ReportLine("LIABILITIES & EQUITY", 0, true));
            if (Args.TotalLiabilities != 0)
            {
                ReportLines.Add(new ReportLine(Indent(1) + "Liabilities", 0, true));
                if (Args.TotalCurrentLiabilities != 0)
                {
                    ReportLines.Add(new ReportLine(Indent(2) + "Current Liabilities", 0, true));
                    //Accounts Payable
                    if (Args.TotalAccountsPayable != 0)
                    {
                        ReportLines.Add(new ReportLine(Indent(3) + "Accounts Payable", 0, true));
                        foreach (account a in AccountsPayableAccounts)
                        {
                            ShowAccounts(context, a, 4);
                        }
                        ReportLines.Add(new ReportLine(Indent(3) + "Total Accounts Payable", Args.TotalAccountsPayable, false, true, false));
                    }
                    //Credit Cards
                    if (Args.TotalCreditCards != 0)
                    {
                        ReportLines.Add(new ReportLine(Indent(3) + "Credit Cards", 0, true));
                        foreach (account a in CreditCardAccounts)
                        {
                            ShowAccounts(context, a, 4);
                        }
                        ReportLines.Add(new ReportLine(Indent(3) + "Total Credit Cards", Args.TotalCreditCards, false, true, false));
                    }
                    //Other Current Liabilities
                    if (Args.TotalOtherCurrentLiabilities != 0)
                    {
                        ReportLines.Add(new ReportLine(Indent(3) + "Other Current Liabilities", 0, true));
                        foreach (account a in OtherCurrentLiabilityAccounts)
                        {
                            ShowAccounts(context, a, 4);
                        }
                        ReportLines.Add(new ReportLine(Indent(3) + "Total Other Current Liabilities", Args.TotalOtherCurrentLiabilities, false, true, false));
                    }
                    ReportLines.Add(new ReportLine(Indent(2) + "Total Current Liabilities", Args.TotalCurrentLiabilities, false, true, false));
                }
                //Long Term Liabilities
                if (Args.TotalLongTermLiabilities != 0)
                {
                    ReportLines.Add(new ReportLine(Indent(2) + "Long Term Liabilities", 0, true));
                    foreach (account a in LongTermLiabilityAccounts)
                    {
                        ShowAccounts(context, a, 3);
                    }
                    ReportLines.Add(new ReportLine(Indent(2) + "Total Long Term Liabilities", Args.TotalLongTermLiabilities, false, true, false));
                }
                ReportLines.Add(new ReportLine(Indent(1) + "Total Liabilities", Args.TotalLiabilities, false, true, false));
            }
            //Equity
            if (Args.TotalEquity != 0)
            {
                ReportLines.Add(new ReportLine(Indent(1) + "Equity", 0, true));
                foreach (account a in EquityAccounts)
                {
                    ShowAccounts(context, a, 2);
                }
                if (Args.NetIncome != 0)
                    ReportLines.Add(new ReportLine(Indent(2) + "Net Income", Args.NetIncome));
                ReportLines.Add(new ReportLine(Indent(1) + "Total Equity", Args.TotalEquity, false, true));
            }
            ReportLines.Add(new ReportLine("TOTAL LIABILITIES & EQUITY", Args.TotalLiabilitiesEquity, false, false, true));
        }
        //Private Functions
        private double GetTopAccountBalance(ContextRz context, account a)
        {
            return context.SelectScalarDouble("select top 1 balance from journal where account_id = '" + a.unique_id + "' and date_created <= cast('" + DateRange.EndDate.ToShortDateString() + " 23:59:59' as datetime) order by date_created desc");
        }
        private class BalanceSheetArgs
        {
            public double TotalCheckingSavings = 0; //Bank Accounts
            public double TotalAccountsReceivable = 0; //Accounts Receivable Accounts
            public double TotalOtherCurrentAssets = 0; //Other Current Asset Accounts
            public double TotalCurrentAssets//TotalCheckingSavings + TotalAccountsReceivable + TotalOtherCurrentAssets
            {
                get
                {
                    return TotalCheckingSavings + TotalAccountsReceivable + TotalOtherCurrentAssets;
                }
            }
            public double TotalFixedAssets = 0; //Fixed Asset Accounts
            public double TotalOtherAssets = 0; //Other Asset Accounts
            public double TotalAssets//TotalCurrentAssets + TotalFixedAssets + TotalOtherAssets
            {
                get
                {
                    return TotalCurrentAssets + TotalFixedAssets + TotalOtherAssets;
                }
            }
            public double TotalAccountsPayable = 0; //Accounts Payable Accounts
            public double TotalCreditCards = 0; //Credit Card Accounts
            public double TotalOtherCurrentLiabilities = 0; //Other Current Liability Accounts
            public double TotalCurrentLiabilities// = 0; //TotalAccountsPayable + TotalCreditCards + TotalOtherCurrentLiabilities
            {
                get
                {
                    return TotalAccountsPayable + TotalCreditCards + TotalOtherCurrentLiabilities;
                }
            }
            public double TotalLongTermLiabilities = 0; //Long Term Liability Accounts
            public double TotalLiabilities//TotalAccountsPayable + TotalCreditCards + TotalCurrentLiabilities + TotalLongTermLiabilities
            {
                get
                {
                    return TotalAccountsPayable + TotalCreditCards + TotalOtherCurrentLiabilities + TotalLongTermLiabilities;
                }
            }
            public double TotalEquity = 0; //EquityAccounts
            public double TotalLiabilitiesEquity//TotalLiabilities + TotalEquity
            {
                get
                {
                    return TotalLiabilities + TotalEquity;
                }
            }
            public double NetIncome = 0;
        }
    }
    public class CashFlowsReport : AccountingReport
    {
        private CashFlowsArgs Args;
        private List<account> OperatingAccounts;
        private List<account> InvestingAccounts;
        private List<account> FinancingAccounts;

        //Constructors
        public CashFlowsReport(Tools.Dates.DateRange dr, bool pdf)
            : base(dr, pdf)
        {

        }
        //Public Override Functions
        public override string ReportTitle
        {
            get
            {
                return "Statement Of Cash Flows";
            }
        }
        public override AccountingReportType ReportType
        {
            get
            {
                return AccountingReportType.CashFlows;
            }
        }
        //Protected Override Functions
        protected override void InitAccounts(ContextRz context)
        {
            OperatingAccounts = new List<account>();
            LoadAccounts(context, ref OperatingAccounts, AccountType.AccountsReceivable);
            LoadAccounts(context, ref OperatingAccounts, AccountType.OtherCurrentAssets);
            foreach (account a in OperatingAccounts)
            {
                if (Tools.Strings.StrCmp(a.full_name, "Undeposited Funds"))
                {
                    OperatingAccounts.Remove(a);
                    break;
                }
            }
            LoadAccounts(context, ref OperatingAccounts, AccountType.AccountsPayable);
            LoadAccounts(context, ref OperatingAccounts, AccountType.CreditCard);
            LoadAccounts(context, ref OperatingAccounts, AccountType.OtherCurrentLiabilities);

            InvestingAccounts = new List<account>();
            LoadAccounts(context, ref InvestingAccounts, AccountType.FixedAssets);
            LoadAccounts(context, ref InvestingAccounts, AccountType.OtherAssets);

            FinancingAccounts = new List<account>();
            LoadAccounts(context, ref FinancingAccounts, AccountType.LongTermLiabilities);
            LoadAccounts(context, ref FinancingAccounts, AccountType.Equity);
        }
        protected override void LoadAccountBalances(ContextRz context)
        {
            Args = new CashFlowsArgs();
            IncomeStatementReport income = new IncomeStatementReport(DateRange, PDF);
            BalanceSheetReport begin = new BalanceSheetReport(new Tools.Dates.DateRange(DateRange.StartDate, DateRange.StartDate), PDF);
            BalanceSheetReport end = new BalanceSheetReport(new Tools.Dates.DateRange(DateRange.EndDate, DateRange.EndDate), PDF);
            income.RunReport(context);
            if (Tools.Strings.StrCmp(DateRange.StartDate.ToShortDateString(), DateRange.EndDate.ToShortDateString()))
                begin = new BalanceSheetReport(new Tools.Dates.DateRange(DateRange.StartDate.Subtract(TimeSpan.FromDays(1)), DateRange.StartDate.Subtract(TimeSpan.FromDays(1))), PDF);
            begin.RunReport(context);
            end.RunReport(context);
            Args.NetIncome = income.NetIncomeAmount;
            Args.CashAtBeg = begin.CashOnHand;
            Args.CashAtEnd = end.CashOnHand;
            account b;
            account e;
            double ba = 0;
            double ea = 0;
            foreach (account a in OperatingAccounts)
            {
                b = begin.GetAccountByName(context, a.full_name);
                e = end.GetAccountByName(context, a.full_name);
                ba = 0;
                ea = 0;
                try { ba = b.balance; }
                catch { }
                try { ea = e.balance; }
                catch { }
                double val = 0;
                switch (a.Type)
                {
                    case AccountType.AccountsReceivable:
                    case AccountType.OtherCurrentAssets:
                        val = ea - ba;
                        break;
                    case AccountType.AccountsPayable:
                    case AccountType.CreditCard:
                    case AccountType.OtherCurrentLiabilities:
                        val = ba - ea;
                        break;
                }
                a.balance = val * -1;
                Args.TotalOperating += a.balance;
            }
            Args.TotalOperating = Args.TotalOperating + Args.NetIncome;
            foreach (account a in InvestingAccounts)
            {
                b = begin.GetAccountByName(context, a.full_name);
                e = end.GetAccountByName(context, a.full_name);
                ba = 0;
                ea = 0;
                try { ba = b.balance; }
                catch { }
                try { ea = e.balance; }
                catch { }
                double val = 0;
                val = ea - ba;
                a.balance = val * -1;
                Args.TotalInvesting += a.balance;
            }
            foreach (account a in FinancingAccounts)
            {
                b = begin.GetAccountByName(context, a.full_name);
                e = end.GetAccountByName(context, a.full_name);
                ba = 0;
                ea = 0;
                try { ba = b.balance; }
                catch { }
                try { ea = e.balance; }
                catch { }
                double val = 0;
                val = ba - ea;
                a.balance = val * -1;
                Args.TotalFinancing += a.balance;
            }
        }
        protected override void CreateAccountTrees(ContextRz context)
        {
            CreateAccountTree(context, ref OperatingAccounts);
            CreateAccountTree(context, ref InvestingAccounts);
            CreateAccountTree(context, ref FinancingAccounts);
        }
        protected override void FillAllAccounts(ContextRz context)
        {
            AllAccounts.Add(OperatingAccounts);
            AllAccounts.Add(InvestingAccounts);
            AllAccounts.Add(FinancingAccounts);
        }
        protected override void CreateReportLines(ContextRz context)
        {
            ReportLines = new List<ReportLine>();            
            //Operations
            ReportLines.Add(new ReportLine("OPERATING ACTIVITIES", 0, true));
            if (Args.NetIncome != 0)
                ReportLines.Add(new ReportLine(Indent(1) + "Net Income", Args.NetIncome));
            ReportLines.Add(new ReportLine(Indent(1) + "Adjustments to reconcile Net Income", 0, true));
            ReportLines.Add(new ReportLine(Indent(1) + "to net cash provided by operations:", 0, true));
            foreach (account a in OperatingAccounts)
            {
                ShowAccounts(context, a, 2);
            }
            ReportLines.Add(new ReportLine("Net cash provided by Operating Activities", Args.TotalOperating, false, true, false));            
            //Investing
            if (Args.TotalInvesting != 0)
            {
                ReportLines.Add(new ReportLine("INVESTING ACTIVITIES", 0, true));
                foreach (account a in InvestingAccounts)
                {
                    ShowAccounts(context, a, 1);
                }
                ReportLines.Add(new ReportLine("Net cash provided by Investing Activities", Args.TotalInvesting, false, true, false));
            }
            //Financing
            if (Args.TotalFinancing != 0)
            {
                ReportLines.Add(new ReportLine("FINANCING ACTIVITIES", 0, true));
                foreach (account a in FinancingAccounts)
                {
                    ShowAccounts(context, a, 1);
                }
                ReportLines.Add(new ReportLine("Net cash provided by Financing Activities", Args.TotalFinancing, false, true, false));
            }
            if (Args.NetCashIncrease != 0)
                ReportLines.Add(new ReportLine("Net cash increase for period", Args.NetCashIncrease));
            if (Args.CashAtBeg != 0)
                ReportLines.Add(new ReportLine("Cash at beginning of period", Args.CashAtBeg));
            ReportLines.Add(new ReportLine("Cash at end of period", Args.CashAtEnd, false, false, true));
        }
        private class CashFlowsArgs
        {
            public double TotalOperating = 0;
            public double TotalInvesting = 0;
            public double TotalFinancing = 0;
            public double NetIncome = 0;
            public double NetCashIncrease
            {
                get
                {
                    return TotalOperating + TotalInvesting + TotalFinancing;
                }
            }
            public double CashAtBeg = 0;
            public double CashAtEnd = 0;
        }
    }
    public class TrialBalanceReport : AccountingReport
    {        
        private TrialBalanceArgs Args;
        private List<account> TrialAccounts;

        //Constructors
        public TrialBalanceReport(Tools.Dates.DateRange dr, bool pdf)
            : base(dr, pdf)
        {

        }
        //Public Override Functions
        public override string ReportTitle
        {
            get
            {
                return "Trial Balance";
            }
        }
        public override AccountingReportType ReportType
        {
            get
            {
                return AccountingReportType.TrialBalance;
            }
        }
        //Protected Override Functions
        protected override void InitAccounts(ContextRz context)
        {
            TrialAccounts = new List<account>();
            Dictionary<string, DataRow> journals = new Dictionary<string, DataRow>();
            DataTable dt = context.Select("select a.unique_id,j.balance from journal j inner join account a on a.unique_id = j.account_id where j.date_created " + DateRange.GetBetweenSQL() + " order by a.number,j.date_created desc");
            string inn = "";
            foreach (DataRow dr in dt.Rows)
            {
                string id = Tools.Data.NullFilterString(dr["unique_id"]);
                if (!Tools.Strings.StrExt(id))
                    continue;
                if (Tools.Strings.StrExt(inn))
                    inn += ",";
                inn += "'" + id + "'";
                try { journals.Add(id, dr); }
                catch { }
            }
            ArrayList acnts = context.QtC("account", "select * from account where unique_id in (" + inn + ")");
            foreach (account a in acnts)
            {
                if (a == null)
                    continue;
                DataRow dr = null;
                journals.TryGetValue(a.unique_id, out dr);
                if (dr != null)
                    a.balance = Tools.Data.NullFilterDouble(dr["balance"]);
                else
                    a.balance = 0;
                TrialAccounts.Add(a);
            }
            SortAccountTree(TrialAccounts);
        }
        protected override void LoadAccountBalances(ContextRz context)
        {
            //Handled in InitAccounts();
        }
        protected override void CreateAccountTrees(ContextRz context)
        {
            //Not needed
        }
        protected override void FillAllAccounts(ContextRz context)
        {
            AllAccounts.Add(TrialAccounts);
        }
        protected override void CreateReportLines(ContextRz context)
        {
            ReportLines = new List<ReportLine>();
            Args = new TrialBalanceArgs();
            int count = 0;
            foreach (account a in TrialAccounts)
            {
                count++;
                ReportLine r = new ReportLine(a.full_name, 0, false, false, false, a.unique_id);//account.GetAccountFullNameWithBullet(a)
                switch (a.Category)
                {
                    case AccountCategory.Asset:
                    case AccountCategory.Expense: //debit(+) credit(-)
                        if (a.balance > 0)
                        {
                            r.debit = a.balance;
                            Args.TotalDebits += r.debit;
                        }
                        else
                        {
                            r.credit = a.balance * -1;
                            Args.TotalCredits += r.credit;
                        }
                        break;
                    case AccountCategory.Liability:
                    case AccountCategory.Equity:
                    case AccountCategory.Income: //debit(-) credit(+)
                        if (a.balance > 0)
                        {
                            r.credit = a.balance;
                            Args.TotalCredits += r.credit;
                        }
                        else
                        {
                            r.debit = a.balance * -1;
                            Args.TotalDebits += r.debit;
                        }
                        break;
                }
                if (count == TrialAccounts.Count)
                    r.is_total = true;
                ReportLines.Add(r);
            }
            ReportLine total = new ReportLine("TOTAL", 0, false, false, true);
            total.credit = Args.TotalCredits;
            total.debit = Args.TotalDebits;
            ReportLines.Add(total);
        }
        //Private Classes
        private class TrialBalanceArgs
        {
            public double TotalCredits = 0;
            public double TotalDebits = 0;
        }
    }
    public class ReconciliationReport : AccountingReport
    {
        //Private Variables
        private ReconcileArgs Args;

        //Constructors
        public ReconciliationReport(Tools.Dates.DateRange dr, ReconcileArgs args, bool pdf)
            : base(dr, pdf)
        {
            Args = args;
        }
        //Public Override Functions
        public override string ReportTitle
        {
            get
            {
                return "Reconciliation Report";
            }
        }
        public override AccountingReportType ReportType
        {
            get
            {
                return AccountingReportType.Reconciliation;
            }
        }
        //Protected Override Functions
        protected override void InitAccounts(ContextRz context)
        {

        }
        protected override void LoadAccountBalances(ContextRz context)
        {

        }
        protected override void CreateAccountTrees(ContextRz context)
        {
      
        }
        protected override void FillAllAccounts(ContextRz context)
        {

        }
        protected override void CreateReportLines(ContextRz context)
        {
            ReconciliationArgs a = new ReconciliationArgs();
            ReportLines = new List<ReportLine>();
            ReportLines.Add(new ReportLine("Beginning Balance", Args.BeginAmount));
            ReportLines.Add(new ReportLine(Indent(1) + "Cleared Transactions", 0, true));
            a.PaymentCount = Args.ClearedPayments.Count;
            a.DepositCount = Args.ClearedDeposits.Count;
            if (Args.Difference != 0)
            {
                if (Args.Difference < 0)
                {
                    a.PaymentTotal += Args.Difference * -1;
                    a.PaymentCount++;
                }
                else
                {
                    a.DepositTotal += Args.Difference;
                    a.DepositCount++;
                }
            }
            foreach (payment_out p in Args.ClearedPayments)
            {
                a.PaymentTotal += p.amount;
            }
            foreach (deposit d in Args.ClearedDeposits)
            {
                a.DepositTotal += d.total_amount;
            }
            a.PaymentTotal = a.PaymentTotal * -1;
            a.ClearedAmount = a.PaymentTotal + a.DepositTotal;
            if (a.PaymentCount > 0)
                ReportLines.Add(new ReportLine(Indent(2) + "Checks and Payments - " + Tools.Strings.PluralizePhrase("item", a.PaymentCount), a.PaymentTotal));
            if (a.DepositCount > 0)
                ReportLines.Add(new ReportLine(Indent(2) + "Deposits and Credits - " + Tools.Strings.PluralizePhrase("item", a.DepositCount), a.DepositTotal));
            ReportLines.Add(new ReportLine(Indent(1) + "Total Cleared Transactions", a.ClearedAmount, false, true));
            a.ClearedBalance = Args.BeginAmount + a.ClearedAmount;
            ReportLines.Add(new ReportLine("Cleared Balance", a.ClearedBalance, false, false, true));
            ReportLines.Add(new ReportLine("", 0, true));
            ReportLines.Add(new ReportLine("Register Balance as of " + Args.StatementDate.ToShortDateString(), Args.EndAmount));
            ReportLines.Add(new ReportLine("Ending Balance", Args.EndAmount));
        }
        //Private Classes
        private class ReconciliationArgs
        {
            public int PaymentCount = 0;
            public double PaymentTotal = 0;
            public int DepositCount = 0;
            public double DepositTotal = 0;
            public double ClearedAmount = 0;
            public double ClearedBalance = 0;
        }
    }
    public enum AccountingReportType
    {
        IncomeStatement,
        OwnersEquity,
        BalanceSheet,
        CashFlows,
        TrialBalance,
        Reconciliation,
    }
}