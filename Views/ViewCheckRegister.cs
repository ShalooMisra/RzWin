using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;
using System.Collections;
using CoreWin;
using NewMethod;

namespace RzInterfaceWin
{
    public partial class ViewCheckRegister : UserControl
    {
        //Private Variables
        account TheAccount;
        string HTML = "";

        //Constructors
        public ViewCheckRegister()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init(account a)
        {
            TheAccount = a;
            SetDates();
            LoadPayees("payment_out", "vendor_name", ctl_payee);
            LoadPayees("company", "companyname", ctlPayee);
            LoadAccounts();
            CheckRegisterSearchArgs args = new CheckRegisterSearchArgs();
            args.Range = new Tools.Dates.DateRange(dtStart.GetValue_Date(), dtEnd.GetValue_Date());
            DoSearch(args);
        }
        public void DoResize()
        {
            try
            {
                SetBorder();
                pTop.Left = pbLeft.Right + 5;
                pTop.Top = pbTop.Bottom + 5;
                pTop.Width = pbRight.Left - pTop.Left - 5;
                wb.Left = pTop.Left;
                wb.Width = pTop.Width;
                wb.Top = pTop.Bottom + 5;
                pBottom.Left = pTop.Left;
                pBottom.Width = pTop.Width;
                pBottom.Top = pbBottom.Top - pBottom.Height - 5;
                wb.Height = pBottom.Top - wb.Top - 5;
                throb.Top = wb.Top;
                throb.Left = wb.Left;                
                cmdSearch.Left = pTop.Width - cmdSearch.Width - 5;
                ctl_memo.Width = cmdSearch.Left - ctl_memo.Left - 5;
            }
            catch { }
        }
        //Private Functions
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();
            }
            catch
            { }
        }
        private void SetDates()
        {
            dtStart.SetValue(Tools.Dates.GetMonthStart(DateTime.Now));
            dtEnd.SetValue(DateTime.Now);
            ctlDate.SetValue(DateTime.Now);
        }
        private void LoadPayees(string table, string prop, nEdit_List l)
        {
            ArrayList a = RzWin.Context.SelectScalarArray("select distinct(" + prop + ") from " + table + " order by " + prop + "");
            string build = "";
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (Tools.Strings.StrExt(build))
                    build += "|";
                build += s;
            }
            l.SimpleList = build;
        }
        private void LoadAccounts()
        {
            List<account> l = RzWin.Context.TheSysRz.TheAccountLogic.GetAccounts(RzWin.Context, new AccountCriteria());
            string build = "";
            foreach (account aa in l)
            {
                if (Tools.Strings.StrCmp(TheAccount.full_name, aa.full_name))
                    continue;
                if (Tools.Strings.StrCmp("Undeposited Funds", aa.full_name))
                    continue;
                if (Tools.Strings.StrExt(build))
                    build += "|";
                build += account.GetAccountFullNameWithBullet(aa);
            }
            ctlAccount.SimpleList = build;
        }
        private void DoSearch(CheckRegisterSearchArgs a)
        {
            if (bgw.IsBusy)
                return;
            wb.Navigate("about:blank");
            throb.Visible = true;
            throb.BringToFront();
            throb.ShowThrobber();
            HTML = "";
            bgw.RunWorkerAsync(a);
        }
        private CheckRegisterSearchArgs SearchArgsGet()
        {
            CheckRegisterSearchArgs a = new CheckRegisterSearchArgs();
            a.Range = new Tools.Dates.DateRange(dtStart.GetValue_Date(), dtEnd.GetValue_Date());
            a.Payee = ctl_payee.GetValue_String();
            a.Ref = ctl_ref.GetValue_String();
            a.Memo = ctl_memo.GetValue_String();
            a.Amount = ctl_amnt.GetValue_Double();
            return a;
        }
        private void Record()
        {
            if (!Tools.Strings.StrExt(ctlAccount.GetValue_String()))
            {
                RzWin.Context.TheLeader.Tell("You need to select an account for this transaction.");
                return;
            }
            string name = account.GetAccountFullNameStripBullet(ctlAccount.GetValue_String());
            account a = account.GetByFullName(RzWin.Context, name);
            if (a == null)
            {
                RzWin.Context.TheLeader.Tell("The account " + name + " could not be located.");
                return;
            }
            company c = null;
            if (Tools.Strings.StrExt(ctlPayee.GetValue_String().Trim()))
                c = company.GetByName(RzWin.Context, ctlPayee.GetValue_String().Trim());
            if (a.Type == AccountType.AccountsPayable || a.Type == AccountType.AccountsReceivable)
            {
                if (c == null)
                {
                    RzWin.Context.TheLeader.Tell("The account " + a.name + " must have a company reference.");
                    return;
                }
            }
            TabPageCore t = ((LeaderWinUserRz)RzWin.Context.TheLeaderRz).TheMainForm.TabGetByID(TheAccount.ToString().Replace(" ", "").Trim());
            TheAccount = account.GetById(RzWin.Context, TheAccount.unique_id);//Grab new instance in case the balance has changed?
            if (ctlPayment.GetValue_Double() > 0)
                TheAccount.RecordPayment(RzWin.Context, a, c, ctlPayment.GetValue_Double(), ctlRef.GetValue_String(), ctlMemo.GetValue_String(), ctlDate.GetValue_Date());
            else if (ctlDeposit.GetValue_Double() > 0)
                TheAccount.RecordDeposit(RzWin.Context, a, c, ctlDeposit.GetValue_Double(), ctlRef.GetValue_String(), ctlMemo.GetValue_String(), ctlDate.GetValue_Date());
            else
            {
                RzWin.Context.TheLeader.Tell("You need to enter a value in either the payment or deposit boxes to record a transaction.");
                return;
            }
            ClearBottomEntry();
            DoSearch(SearchArgsGet());
            TheAccount = account.GetById(RzWin.Context, TheAccount.unique_id);
            t.SetCaption(TheAccount.ToString());
        }
        private void ClearBottomEntry()
        {
            ctlDate.SetValue(DateTime.Now);
            ctlAccount.cboValue.SelectedItem = null;
            ctlDeposit.SetValue(0);
            ctlMemo.SetValue("");
            ctlPayee.SetValue("");
            ctlPayment.SetValue(0);
            ctlRef.SetValue("");
            LoadPayees("payment_out", "vendor_name", ctl_payee);
        }
        //Buttons
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DoSearch(SearchArgsGet());
        }
        private void cmdRecord_Click(object sender, EventArgs e)
        {
            Record();
        }
        //Control Events
        private void ViewCheckRegister_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void ctlPayment_DataChanged(Tools.GenericEvent e)
        {
            double d = ctlPayment.GetValue_Double();
            if (d == 0)
                return;
            if (d < 0)
            {
                ctlPayment.SetValue(0);
                ctlDeposit.SetValue(d * -1);
                return;
            }
            ctlDeposit.SetValue(0);
        }
        private void ctlDeposit_DataChanged(Tools.GenericEvent e)
        {
            double d = ctlDeposit.GetValue_Double();
            if (d == 0)
                return;
            if (d < 0)
            {
                ctlDeposit.SetValue(0);
                ctlPayment.SetValue(d * -1);
                return;
            }
            ctlPayment.SetValue(0);
        }
        private void wb_OnNavigate2(WebBrowserNavigatingEventArgs args)
        {
            string id = "";
            if (args.Url.ToString().ToLower().Contains("account~"))
            {
                args.Cancel = true;
                id = Tools.Strings.ParseDelimit(args.Url.ToString().ToLower(), "account~", 2).Trim();
                if (!Tools.Strings.StrExt(id))
                    return;
                account a = account.GetById(RzWin.Context, id);
                if (a != null)
                    a.ShowAccountReport(RzWin.Context);
            }
            else if (args.Url.ToString().ToLower().Contains("company~"))
            {
                args.Cancel = true;
                id = Tools.Strings.ParseDelimit(args.Url.ToString().ToLower(), "company~", 2).Trim();
                if (!Tools.Strings.StrExt(id))
                    return;
                company c = company.GetById(RzWin.Context, id);
                if (c != null)
                    RzWin.Context.Show(c);
            }
        }
        //Background Workers
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckRegisterSearchArgs a = (CheckRegisterSearchArgs)e.Argument;
            HTML = RzWin.Context.TheSysRz.TheAccountLogic.GetCheckRegisterHTML(RzWin.Context, TheAccount, a);            
            //string table = "temp_" + Tools.Strings.GetNewID() + "_table";
            //RzWin.Context.Execute("select unique_id,date_created,vendor_uid,vendor_name,amount,description,account_uid,account_name,cleared,reference_number,check_number,'Payment' as type,dest_account_name,dest_account_uid,balance,account_number,dest_account_number into " + table + " from payment_out where account_uid = '" + TheAccount.unique_id + "' and date_created " + a.Range.GetBetweenSQL());
            //RzWin.Context.Execute("insert into " + table + " select unique_id,date_created,vendor_uid,vendor_name,total_amount as amount,description,account_uid,account_name,cleared,name as reference_number,'' as check_number,'Deposit' as type,dest_account_name,dest_account_uid,balance,account_number,dest_account_number from deposit where account_uid = '" + TheAccount.unique_id + "' and date_created " + a.Range.GetBetweenSQL());
            //DataTable dt = RzWin.Context.Select("select * from " + table + " order by date_created asc");
            //RzWin.Context.Execute("drop table " + table);
            //a.HTML = new StringBuilder();
            //a.HTML.AppendLine("<head>");
            //a.HTML.AppendLine("<style type=\"text/css\">");
            //a.HTML.AppendLine("body {  font-family: Sans-Serif; }");
            //a.HTML.AppendLine("</style>");
            //a.HTML.AppendLine("</head>");
            //a.HTML.AppendLine("<body>");
            //a.HTML.AppendLine("<table border=\"1\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            //a.HTML.AppendLine("  <tr>");
            //a.HTML.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">Date</td>");
            //a.HTML.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">Number</td>");
            //a.HTML.AppendLine("    <td width=\"26%\" colspan=\"2\" bgcolor=\"#F1F0EF\" align=\"center\">Payee</td>");
            //a.HTML.AppendLine("    <td width=\"12%\" align=\"center\" bgcolor=\"#F1F0EF\">Payment</td>");
            //a.HTML.AppendLine("    <td width=\"12%\" align=\"center\" bgcolor=\"#F1F0EF\">Cleared</td>");
            //a.HTML.AppendLine("    <td width=\"12%\" align=\"center\" bgcolor=\"#F1F0EF\">Deposit</td>");
            //a.HTML.AppendLine("    <td width=\"12%\" align=\"center\" bgcolor=\"#F1F0EF\">Balance</td>");
            //a.HTML.AppendLine("  </tr>");
            //a.HTML.AppendLine("  <tr>");
            //a.HTML.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">&nbsp;</td>");
            //a.HTML.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">Type</td>");
            //a.HTML.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">Account</td>");
            //a.HTML.AppendLine("    <td width=\"13%\" bgcolor=\"#F1F0EF\" align=\"center\">Memo</td>");
            //a.HTML.AppendLine("    <td width=\"12%\" bgcolor=\"#F1F0EF\" align=\"center\">&nbsp;</td>");
            //a.HTML.AppendLine("    <td width=\"12%\" bgcolor=\"#F1F0EF\" align=\"center\">&nbsp;</td>");
            //a.HTML.AppendLine("    <td width=\"12%\" bgcolor=\"#F1F0EF\" align=\"center\">&nbsp;</td>");
            //a.HTML.AppendLine("    <td width=\"12%\" bgcolor=\"#F1F0EF\" align=\"center\">&nbsp;</td>");
            //a.HTML.AppendLine("  </tr>");
            //a.HTML.AppendLine("</table>");
            //a.HTML.AppendLine("<table border=\"1\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            //foreach (DataRow dr in dt.Rows)
            //{
            //    a.HTML.AppendLine(GetHTMLRow(dr, a));
            //}
            //if (dt.Rows.Count <= 0)
            //    a.HTML.AppendLine("<tr><td width=\"100%\" bgcolor=\"#E0EFE0\">No Results</td></tr>");
            //a.HTML.AppendLine("</table>");
            //a.HTML.AppendLine("</body>");
            //e.Result = a;
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //CheckRegisterSearchArgs a = (CheckRegisterSearchArgs)e.Result;
            throb.Visible = false;
            throb.HideThrobber();
            wb.ReloadWB();
            wb.Add(HTML.ToString());
            wb.GetDocument().Window.ScrollTo(0, 100000);
            wb.Focus();
        }
    }
}
