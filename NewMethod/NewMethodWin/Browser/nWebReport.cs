using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;
using ToolsWin;

namespace NewMethod
{
    public partial class nWebReport : UserControl
    {
        public bool ShowOptionSpace = false;
        public int OptionBoxWidth = 0;
        public bool ShowChart = false;
        public bool ShowChartOnly = false;

        public nWebReport()
        {
            InitializeComponent();
            //chart.Visible = false;
            throb.BackColor = Color.White;
        }

        public void CompletelyClearChart()
        {
            //if (m_chart != null)
            //{
            //    try
            //    {
            //        Controls.Remove(m_chart);
            //        m_chart.Dispose();
            //        m_chart = null;
            //    }
            //    catch { }
            //}
            //ChartInit();
            //DoResize();
        }

        //nChart m_chart = null;
        //public nChart chart
        //{
        //    get
        //    {
        //        if (m_chart == null)
        //        {
        //            try
        //            {
        //                ChartInit();
        //            }
        //            catch { }
        //        }

        //        return m_chart;
        //    }
        //}

        void ChartInit()
        {
            //m_chart = new nChart();
            //Controls.Add(m_chart);
        }

        private void nWebReport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public virtual void Init()
        {
            CompleteStructure();
        }

        public virtual void CompleteStructure()
        {
            DoResize();
        }

        public virtual void StartAsync()
        {
            if (bg.IsBusy)
                return;            
            bg.RunWorkerAsync();
        }

        public virtual void AsyncFinished()
        {
            throb.HideThrobber();
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            DoAsync();
        }

        public virtual void DoAsync()
        {

        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AsyncFinished();
        }

        public void ShowThrobber()
        {
            throb.ShowThrobber();
        }

        public void HideThrobber()
        {
            throb.HideThrobber();
        }

        public virtual void DoResize()
        {
            try
            {
                if (ShowOptionSpace)
                {
                    int w = 150;
                    if (OptionBoxWidth > 0)
                        w = OptionBoxWidth;
                    wb.Left = w;
                    wb.Top = 0;
                    wb.Width = this.ClientRectangle.Width - w;
                }
                else
                {
                    wb.Left = OptionBoxWidth;
                    wb.Top = 0;
                    wb.Width = this.ClientRectangle.Width - OptionBoxWidth;
                }

                if (ShowChartOnly)
                    wb.Height = 0;
                else
                {
                    if (ShowChart)
                        wb.Height = ((this.ClientRectangle.Height - gb.Height) / 3) * 2;
                    else
                        wb.Height = this.ClientRectangle.Height - gb.Height;
                }

                gb.Left = 0;
                gb.Top = this.ClientRectangle.Height - gb.Height;
                gb.Width = this.ClientRectangle.Width;

                pb.Width = gb.Width - (pb.Left * 2);
                lblStatus.Left = pb.Right - lblStatus.Width;


                //if (ShowChart)
                //{
                //    chart.Left = wb.Left;
                //    chart.Width = wb.Width;
                //    chart.Top = wb.Bottom;
                //    chart.Height = this.ClientRectangle.Height - (wb.Bottom + gb.Height);
                //}
            }
            catch
            {}
        }

        public void EnableChart()
        {
            //ShowChart = true;
            //chart.Visible = true;
            //DoResize();
        }

        public void DisableChart()
        {
            //ShowChart = false;
            //chart.Visible = false;
            //DoResize();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        public virtual void StartReport()
        {
            ClearReport();
        }

        public virtual void RunReport()
        {
            ClearReport();
            
        }

        public virtual void ClearReport()
        {
            wb.ReloadWB();
            SetProgress(0);
            SetStatus("");
        }

        public void SetProgress(int p)
        {
            try
            {
                pb.Value = p;
            }
            catch (Exception)
            { }
        }

        public virtual void SetStatus(String s)
        {
            lblStatus.Text = s;
            lblStatus.Refresh();
        }

        public virtual String GetCaption()
        {
            return "";
        }

        public virtual void Print()
        {
            try
            {
                if (ShowChartOnly)
                    PopChartPicture();
                else
                    wb.Print();
            }
            catch { }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        public void PopChartPicture()
        {
            Tools.FileSystem.Shell(SaveChartPicture());
        }

        String SaveChartPicture()
        {
            //String strFileName = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + "temp_hold_chart_picture_" + Tools.Folder.GetNowPath() + ".jpg";
            //System.Drawing.Image image = Win32API.GetControlShotAlternate(chart);
            //try
            //{

            //    image.Save(strFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    try
            //    {
            //        image.Dispose();
            //        image = null;
            //    }
            //    catch{}

            //    return strFileName;
            //}
            //catch (Exception ex)
            //{
            //    context.TheLeader.Tell("Error in picture save: " + ex.Message);
            //    return "";
            //}
            return "";
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            String s = wb.GetPageHTML();
            String f = Tools.FileSystem.GetAppPath() + "temp_html.htm";
            Tools.Files.SaveFileAsString(f, s);
            Tools.FileSystem.PopTextFile(f);
        }

        private void cmdEmail_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            String err = "";
            if (ShowChartOnly)
            {
                //ToolsOffice.OutlookOffice.SendOutlookMessage("", "", "Chart", false, true, "", SaveChartPicture(), false, null, "", "", "", "", ref err);
            }
            else
            {
                String s = wb.GetPageHTML();
                String f = Tools.FileSystem.GetAppPath() + "temp_html.htm";
                Tools.Files.SaveFileAsString(f, s);

                //ToolsOffice.OutlookOffice.SendOutlookMessage("", "", "report", false, true, "", f, false, null, "", "", "", "", ref err);
            }
        }

        public void ShowSQLAsTable(String strSQL)
        {
            DataTable d = NMWin.Data.Select(strSQL);
            ShowSQLAsTable(d);
        }

        public void ShowSQLAsTable(DataTable d)
        {
            if (!nTools.DataTableExists(d))
            {
                wb.Add("<p>No Results</p>");
                return;
            }

            wb.Add("<br><table border=\"1\" cellpadding=\"1\" cellspacing=\"1\"><tr>");

            foreach (DataColumn c in d.Columns)
            {
                wb.Add("<td nowrap>" + c.Caption + "</td>");
            }

            wb.Add("</tr>");

            foreach (DataRow r in d.Rows)
            {
                wb.Add("<tr>");
                foreach (DataColumn c in d.Columns)
                {
                    Object o = r[c.Ordinal];
                    if (o == null)
                        wb.Add("<td nowrap>&nbsp;</td>");
                    else
                        wb.Add("<td nowrap>" + o.ToString() + "</td>");
                }
                wb.Add("</tr>");
            }

            wb.Add("</table>");
        }

        private void wb_OnNavigate(GenericEvent e)
        {
            if (Tools.Strings.HasString(e.Message, ".rzl?"))
            {
                e.Handled = true;
                String s = Tools.Strings.ParseDelimit(e.Message, ".rzl?", 2);
                NMWin.ContextDefault.xSys.ThrowByKey(NMWin.ContextDefault, s);
            }
            else
            {
                GotNavigate(e);
            }
        }

        public virtual void GotNavigate(GenericEvent e)
        {

        }

        public DataTable ExportTable = null;

        public void SetExportTable(DataTable d)
        {
            ExportTable = d;
            cmdExport.Visible = Tools.Data.DataTableExists(ExportTable);
        }

        public virtual void DoExport()
        {
            if (!Tools.Data.DataTableExists(ExportTable))
                return;
            String strHeader = "";
            foreach (DataColumn c in ExportTable.Columns)
            {
                if (Tools.Strings.StrExt(strHeader))
                    strHeader += ",";
                strHeader += "\"" + c.Caption + "\"";
            }
            long l = 0;
            String strFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "export_" + Tools.Strings.GetNewID() + ".csv";
            NMWin.Leader.StartPopStatus("Exporting...");
            NMWin.Data.ExportDataTableToCsv(ExportTable, strFile, ref l, strHeader);
            NMWin.Leader.Comment("Done: " + Tools.Number.LongFormat(l) + " rows exported.");
            NMWin.Leader.Comment("Opening...");
            Tools.FileSystem.Shell(strFile);
            NMWin.Leader.StopPopStatus(true);       
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            DoExport();
        }

        public virtual void AddDomainLink(String strDomain, String strCaption)
        {            
            wb.Add(Tools.Html.GetDomainLink(strDomain, strCaption));
        }

        public virtual void AddSmallStyle()
        {
            wb.Add(Tools.Html.GetSmallStyle());
        }

        public virtual void InvokeAdd(String s)
        {
            this.Invoke(new AddHandler(ActuallyAdd), new object[] { s });
        }

        void ActuallyAdd(String s)
        {
            wb.Add(s + "<br>");
            wb.ScrollToBottom();
        }

        public void Log(String s)
        {
            InvokeAdd(s);
        }

        delegate void AddHandler(String s);
    }
}
