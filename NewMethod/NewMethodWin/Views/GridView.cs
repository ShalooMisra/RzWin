using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using CoreWin;

namespace NewMethod.Grids
{
    public partial class GridView : UserControl
    {
        public Grid TheGrid;
        public GridView()
        {
            InitializeComponent();
            throb.BackColor = Color.White;
        }

        public virtual void Init(Grid the_grid)
        {
            TheGrid = the_grid;
            lblCaption.Text = TheGrid.Caption;
            if (TheGrid.DateSensitive)
            {
                pDate.Visible = true;
                dtStart.SetValue(TheGrid.DateStart);
                dtEnd.SetValue(TheGrid.DateEnd);
            }
            else
                pDate.Visible = false;

            InitHtml();
        }

        public virtual void InitHtml()
        {
            if (bgLoad.IsBusy)
                return;

            if (TheGrid.DateSensitive)
            {
                TheGrid.DateStart = dtStart.GetValue_Date();
                TheGrid.DateEnd = dtEnd.GetValue_Date();
            }

            wb.ReloadWB();
            wb.Add("Loading...");
            throb.ShowThrobber();
            bgLoad.RunWorkerAsync();
        }

        public virtual void InitUn()
        {
            try
            {
                if (bgLoad.IsBusy)
                    bgLoad.CancelAsync();

                TheHtml = "";
                TheGrid = null;
            }
            catch { }
        }

        private void GridView_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public virtual void DoResize()
        {
            try
            {
                //pOptions.Left = this.ClientRectangle.Width - pOptions.Width;

                pOptions.Top = lblCaption.Bottom;
                pOptions.Left = 0;
                pOptions.Height = this.ClientRectangle.Height - pOptions.Bottom;

                wb.Left = pOptions.Right;
                wb.Top = lblCaption.Bottom;
                wb.Width = this.ClientRectangle.Width - wb.Left;
                wb.Height = this.ClientRectangle.Height - wb.Top;
            }
            catch
            {

            }
        }

        String TheHtml;
        private void bgLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            TheHtml = TheGrid.RenderAsHTML();
        }

        private void bgLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            wb.ReloadWB();
            wb.Add(TheHtml);
            throb.HideThrobber();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            InitHtml();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            String strFileName = ToolsWin.FileSystem.FileNameCreate(this.ParentForm);
            if (File.Exists(strFileName))
            {
                NMWin.Leader.Tell("Please choose a file name that doesn't exist.");
                return;
            }

            Tools.Files.SaveFileAsString(strFileName, TheHtml);
            Tools.FileSystem.Shell(strFileName);
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            wb.Print();
        }

        private void cmdCSV_Click(object sender, EventArgs e)
        {
            String strFileName = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + "report_" + Tools.Strings.GetNewID() + ".csv";
            if (File.Exists(strFileName))
            {
                NMWin.Leader.Tell("Please choose a file name that doesn't exist.");
                return;
            }

            NMWin.Leader.StartPopStatus("Exporting to " + strFileName);
            long l = 0;
            TheGrid.RenderAsCsv(strFileName, ref l);
            NMWin.Leader.Comment("Done: " + Tools.Number.LongFormat(l) + " rows were exported.");
            NMWin.Leader.StopPopStatus();
            Tools.FileSystem.Shell(strFileName);
        }

        private void cmdExportXls_Click(object sender, EventArgs e)
        {
            String strFileName = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + "report_" + Tools.Strings.GetNewID() + ".xlsx";
            if (File.Exists(strFileName))
            {
                NMWin.Leader.Tell("Please choose a file name that doesn't exist.");
                return;
            }

            NMWin.Leader.StartPopStatus("Exporting to " + strFileName);
            long l = 0;
            TheGrid.RenderAsXlsx(strFileName, ref l);
            NMWin.Leader.Comment("Done: " + Tools.Number.LongFormat(l) + " rows were exported.");
            NMWin.Leader.StopPopStatus();
            //Tools.FileSystem.Shell(strFileName);  this process already makes it visible
        }

        private void cmdChart_Click(object sender, EventArgs e)
        {
            NMWin.Leader.Reorg();
            //List<GridColumn> cols = TheGrid.ColumnsGet();
            //if (cols.Count == 0)
            //    return;

            //ArrayList a = new ArrayList();
            //foreach (GridColumn g in cols)
            //{
            //    a.Add(g);
            //}

            //GridColumn name = (GridColumn)frmChooseObject.ChooseFromPlainCollection(this.ParentForm, a, "Name Column");
            //if (name == null)
            //    return;

            //GridColumn value = (GridColumn)frmChooseObject.ChooseFromPlainCollection(this.ParentForm, a, "Value");
            //if (value == null)
            //    return;

            //String caption = context.TheLeader.AskForString("Caption", "Chart 1", "Caption", this.ParentForm);
            //if (!Tools.Strings.StrExt(caption))
            //    return;

            //nCubeSummary s = TheGrid.CubeSummaryGetAs(caption, name, value);
            //if (s == null)
            //    return;

            //nChart t = new nChart();
            //MainForm parent = (MainForm)this.ParentForm;
            //parent.TabShow(t, caption);
            //t.ShowSingleSeriesSummary(s, caption, true);
        }

        private void lblChartBy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NMWin.Leader.Reorg();

            //List<GridColumn> cols = TheGrid.ColumnsGet();
            //if (cols.Count == 0)
            //    return;

            //ArrayList a = new ArrayList();
            //foreach (GridColumn g in cols)
            //{
            //    a.Add(g);
            //}

            //GridColumn name = (GridColumn)frmChooseObject.ChooseFromPlainCollection(this.ParentForm, a, "Date Column");
            //if (name == null)
            //    return;

            //GridColumn value = (GridColumn)frmChooseObject.ChooseFromPlainCollection(this.ParentForm, a, "Value");
            //if (value == null)
            //    return;

            //String caption = context.TheLeader.AskForString("Caption", "Chart 1", "Caption", this.ParentForm);
            //if (!Tools.Strings.StrExt(caption))
            //    return;


            //Tools.CubeInterval interval = Tools.CubeInterval.Month;
            //if (optYear.Checked)
            //    interval = Tools.CubeInterval.Year;

            //nCubeSummary s = TheGrid.CubeSummaryDateGetAs(caption, name, value, interval);
            //if (s == null)
            //    return;

            //nChart t = new nChart();
            //MainForm parent = (MainForm)this.ParentForm;
            //parent.TabShow(t, caption);
            //t.ShowSingleSeriesSummary(s, caption, true);
        }
    }
}
