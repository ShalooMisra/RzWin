using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;
using Core;

namespace RzInterfaceWin
{
    public partial class ViewAccountingReport : UserControl
    {
        //Public Variables
        public AccountingReport TheReport;

        //Constructors
        public ViewAccountingReport()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init(AccountingReport r)
        {
            TheReport = r;
            lblTitle.Text = TheReport.ReportTitle.Replace("&", "&&");
            throb.BackColor = Color.Transparent;
            SetDates();
            RunReport();
        }
        public void DoResize()
        {
            try
            {
                SetBorder();
                pHeader.Top = pbTop.Bottom + 5;
                pHeader.Left = pbLeft.Right + 5;
                pHeader.Height = pbBottom.Top - pHeader.Top - 5;
                wb.Top = pHeader.Top;
                wb.Left = pHeader.Right + 5;
                wb.Height = pHeader.Height;
                wb.Width = pbRight.Left - wb.Left - 5;
                picSide.Height = pHeader.Height;                
                //dtStart.DoResize();
                //dtEnd.DoResize();
            }
            catch { }
        }
        //Private Functions
        private void RunReport()
        {
            if (bw.IsBusy)
                return;
            if (TheReport == null)
                return;
            ShowResults("");
            TheReport.DateRange = new Tools.Dates.DateRange(reportDate.TheRange.TheRange.StartDate, reportDate.TheRange.TheRange.EndDate);
            if (TheReport.ReportType == AccountingReportType.BalanceSheet)
                TheReport.DateRange = new Tools.Dates.DateRange(reportDate.TheRange.TheRange.StartDate, reportDate.TheRange.TheRange.StartDate);
            throb.ShowThrobber();
            bw.RunWorkerAsync();
        }
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
            ReportCriteriaDateRange r = new ReportCriteriaDateRange("");
            r.TheRange = TheReport.DateRange;
            r.AllowAny = false;
            r.AllowBeforeAfter = false;
            if (TheReport.ReportType == AccountingReportType.BalanceSheet)
            {
                r.Caption = "Date";
                r.DefaultOption = "On";
                r.HideEndDate = true;
                r.AllowBetween = false;
                r.AllowYearToDate = false;
            }
            else
            {
                r.Caption = "Dates";
                r.DefaultOption = "Between";                
            }
            reportDate.Init(r);
        }
        private void ShowResults(string result)
        {
            if (!TheReport.PDF)
            {                
                wb.ReloadWB();
                wb.Add(result);
            }
            else
            {
                if (Tools.Files.FileExists(result))
                    Tools.FileSystem.Shell(result);
            }
        }
        //Buttons
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            wb.Navigate("about:blank");
            RunReport();
        }
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            wb.PrintWithDialog();
        }
        //Control Events
        private void ViewAccountingReport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void wb_OnNavigate2(WebBrowserNavigatingEventArgs args)
        {
            if (args.Url.ToString().Contains("showaccountreport_"))
            {
                args.Cancel = true;
                string id = Tools.Strings.ParseDelimit(args.Url.ToString(), "showaccountreport_", 2).Trim();
                if (!Tools.Strings.StrExt(id))
                    return;
                account a = account.GetById(RzWin.Context, id);
                if (a == null)
                    return;
                a.ShowAccountReport(RzWin.Context);
            }
        }
        //Background Workers
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = TheReport.GetReport(RzWin.Context);
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
            ShowResults(e.Result.ToString());
        }
    }
}
