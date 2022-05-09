using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Rz5.Reports;

namespace Rz5.Win.Views
{
    public partial class ViewReport : UserControl
    {
        public Core.Report TheReport;

        public ViewReport()
        {
            InitializeComponent();
            throb.Visible = false;
            throb.BackColor = Color.White;
        }

        ReportArgs currentArgs;

        public void Init(Core.Report r)
        {
            Init(r, null);
        }

        public void Init(Core.Report r, ReportArgs args)
        {
            TheReport = r;
            lblTitle.Text = r.Title;
            lblDescription.Text = r.Description;

            InitArgs(args);
            InitOtherControls(r);
        }

        private void InitOtherControls(Core.Report r)
        {
            string reportName = r.GetType().FullName;
            switch (reportName)
            {
                case ("Rz5.Reports.CommissionReport"):
                    {
                        CommissionReport c = (CommissionReport)r;
                        int llWidth = fp.Width - 5;
                        LinkLabel llS = c.AddCommissionScheduleLinkLabel();
                        llS.Width = llWidth;
                        fp.Controls.Add(llS);

                        //LinkLabel llC = c.AddRegularPayCalendarLinkLabel();
                        //llC.Width = llWidth;
                        //fp.Height += llS.Height + llC.Height;                       
                        //fp.Controls.Add(llC);
                        break;
                    }
            }
        }

        void InitUn()
        {
            try
            {
                fp.Controls.Clear();
            }
            catch { }
        }

        void InitArgs(ReportArgs args)
        {
            if (args == null)
                currentArgs = TheReport.ArgsCreate(RzWin.Context);
            else
                currentArgs = args;

            try
            {
                foreach (ReportCriteria c in currentArgs.Criteria)
                {
                    Rz5.Win.Controls.ReportCriteriaControl control = ((LeaderWinUserRz)RzWin.Context.TheLeaderRz).CriteriaControlCreate(c);
                    if (control != null)
                    {
                        fp.Controls.Add(control);
                        control.Init(c);
                        control.Width = Convert.ToInt32(fp.Width * 0.95);
                        //control.ValueChanged += new EventHandler(control_ValueChanged);
                    }
                }
            }
            catch { }
        }

        //void control_ValueChanged(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshReport();
        }

        ReportTargetHtml currentTarget;
        public void RefreshReport()
        {
            if (!currentArgs.ValidCheck(RzWin.Context))
                return;

            wb.ReloadWB();
            wb.Add("<font face=\"Calibri\">Calculating...</font>");

            cmdRefresh.Visible = false;
            throb.Visible = true;
            throb.ShowThrobber();
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            TheReport.Calculate(RzWin.Context, currentArgs);
            RenderToTarget();
        }

        void RenderToTarget()
        {
            currentTarget = TheReport.GetReportTargetHtml();
            currentTarget.Render(RzWin.Context, TheReport);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            wb.ReloadWB();
            wb.Add(currentTarget.HtmlResult);
            throb.HideThrobber();
            throb.Visible = false;
            cmdRefresh.Visible = true;
            pExport.Visible = RzWin.Logic.ExportReportsAllowed(RzWin.Context);
            lblCount.Visible = true;
            lblCount.Text = Tools.Strings.PluralizePhrase("Result", TheReport.Lines.Count);
        }

        private void ViewReport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                pHeader.Left = 0;
                pHeader.Top = 0;

                //fp.Width = pHeader.Width;
                fp.Top = pHeader.Bottom;
                fp.Left = 0;
                fp.Height = this.ClientRectangle.Height - (fp.Top + pBottom.Height);

                pBottom.Left = 0;
                pBottom.Top = fp.Bottom;

                wb.Top = 0;
                //wb.Left = pHeader.Right;
                wb.Width = this.ClientRectangle.Width - wb.Left;
                wb.Height = this.ClientRectangle.Height - wb.Top;

                picSide.Top = 0;
                picSide.Height = this.ClientRectangle.Height - picSide.Top;
            }
            catch { }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            ReportTargetCsv csv = new ReportTargetCsv(Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + Tools.Strings.FilterTrash(TheReport.Title) + "_" + Tools.Dates.GetNowPathHMS() + ".csv");
            csv.Render(RzWin.Context, TheReport);
            csv.Show(RzWin.Context, TheReport);
        }

        protected virtual void WBNavigate(Tools.GenericEvent e)
        {
            if (e.Message.ToLower().Contains("show.rzl"))
            {
                e.Handled = true;
                String q = Tools.Strings.ParseDelimit(e.Message, "?", 2);
                string cid = Tools.Strings.ParseDelimit(q, "&", 1).Replace("cid=", "").Trim();
                string uid = Tools.Strings.ParseDelimit(q, "&", 2).Replace("uid=", "").Trim();
                if (!Tools.Strings.StrExt(cid))
                    return;
                if (!Tools.Strings.StrExt(uid))
                    return;
                RzWin.Context.Show(RzWin.Context.TheSys.ItemGetByTag(RzWin.Context, new Core.ItemTag(cid, uid)));
            }
            else if (e.Message.ToLower().Contains("do.rzl"))
            {
                e.Handled = true;
                String cmd = Tools.Strings.ParseDelimit(e.Message, "cmd=", 2).Trim();
                if (Tools.Strings.StrExt(cmd))
                    TheReport.ProcessCommand(RzWin.Context, cmd);
            }
            else if (e.Message.ToLower().Contains("sort.rzl"))
            {
                e.Handled = true;
                String colIndexString = Tools.Strings.ParseDelimit(e.Message, "column=", 2);
                if (!Tools.Number.IsNumeric(colIndexString))
                    return;

                TheReport.SortByColumnIndex(Int32.Parse(colIndexString));

                wb.ReloadWB();
                RenderToTarget();
                wb.Add(currentTarget.HtmlResult);
            }
        }

        private void wb_OnNavigate(Tools.GenericEvent e)
        {
            WBNavigate(e);
        }

        private void cmdExcel_Click(object sender, EventArgs e)
        {
            ReportTargetExcel xl = new ReportTargetExcel();
            xl.Render(RzWin.Context, TheReport);
            xl.Show(RzWin.Context, TheReport);
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            wb.PrintWithDialog();
        }
    }
}
