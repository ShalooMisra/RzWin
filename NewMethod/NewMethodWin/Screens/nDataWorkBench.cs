using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NewMethod
{
    public partial class nDataWorkBench : UserControl, ICompleteLoad
    {
        SysNewMethod xSys
        {
            get
            {
                return NMWin.ContextDefault.xSys;
            }
        }
        ArrayList Tables = new ArrayList();
        nDataTable CurrentTable;
        bool bCancel = false;
        nRefresh xRefresh;

        public nDataWorkBench()
        {
            InitializeComponent();
            throb.BackColor = throb.Parent.BackColor;
        }

        public void CompleteLoad()
        {
            ShowTables();
        }

        void ShowTables()
        {
            xRefresh = new nRefresh();
            lvTables.Items.Clear();
            lvTables.BeginUpdate();
            try
            {
                foreach (nDataTableHandle h in Tables)
                {
                    ListViewItem i = lvTables.Items.Add(h.TableName);
                    i.SubItems.Add(Tools.Number.LongFormat(h.RowCount));
                    i.Tag = h;
                    h.xControl = lvTables;
                    xRefresh.Add(h);
                }
            }
            catch { }
            lvTables.EndUpdate();
        }

        private void cmdAddFile_Click(object sender, EventArgs e)
        {
            String s = ToolsWin.FileSystem.ChooseAFile();
            if (!Tools.Strings.StrExt(s))
                return;

            AddFile(s);          
        }

        void AddFile(String s)
        {
            String ext = Tools.Strings.Mid(Path.GetExtension(s), 2);
            switch (ext.ToLower())
            {
                case "xls":
                case "csv":
                case "dbf":
                    break;
                default:
                    NMWin.Leader.Tell("This system isn't currently able to import files in this format.");
                    return;
            }

            AddFile(s, ext);
        }

        void AddFile(String strFile, String strExt)
        {
            throb.ShowThrobber();
            SetStatus("Importing from " + strFile);

            CurrentTable = new nDataTable(NMWin.Data);
            CurrentTable.GotProgress += new DataTableProgressHandler(CurrentTable_GotProgress);
            CurrentTable.GotStatus += new DataTableStatusHandler(CurrentTable_GotStatus);
            CurrentTable.CancelCheck += new DataTableCancelHandler(CurrentTable_CancelCheck);

            FileImportArgs args = new FileImportArgs(strFile, strExt);
            bg.RunWorkerAsync(args);
        }

        void CurrentTable_CancelCheck(nDataTableCancelArgs args)
        {
            if (bCancel)
                args.Cancel = true;
        }

        void CurrentTable_GotProgress(int progress)
        {
            SetProgress(progress);
        }

        void CurrentTable_GotStatus(string status)
        {
            SetStatus(status);
        }

        public void SetStatus(String s)
        {
            if (this.InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(SetStatusHandler);
                this.Invoke(d, new object[] { s });
            }
            else
            {
                SetStatusHandler(s);
            }
        }

        public void SetProgress(int p)
        {
            if (this.InvokeRequired)
            {
                SetProgressDelegate d = new SetProgressDelegate(SetProgressHandler);
                this.Invoke(d, new object[] { p });
            }
            else
            {
                SetProgressHandler(p);
            }
        }

        private void SetStatusHandler(String s)
        {
            try
            {
                sb.AddLine(s);
            }
            catch (Exception)
            { }
        }

        private void SetProgressHandler(int p)
        {
            try
            {
                pb.Value = p;
                pb.Refresh();
            }
            catch (Exception)
            { }
        }

        public void SetProgressPercent(Int32 total, Int32 current)
        {
            SetProgressPercent(Convert.ToInt64(total), Convert.ToInt64(current));
        }

        public void SetProgressPercent(Int64 total, Int64 current)
        {
            SetProgress(Convert.ToInt32(Math.Round(Convert.ToDouble((Convert.ToDouble(current) / Convert.ToDouble(total)) * 100), 0)));
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            FileImportArgs args = (FileImportArgs)e.Argument;

            bool b = false;
            try
            {
                switch (args.Extension.ToLower())
                {
                    case "xls":
                        CurrentTable.AbsorbExcelFile(NMWin.ContextDefault, args.FileName, "", false);
                        break;
                    case "csv":
                        CurrentTable.AbsorbCSVFile(NMWin.ContextDefault, args.FileName);
                        break;
                    case "dbf":
                        CurrentTable.AbsorbDBFFile(NMWin.ContextDefault, args.FileName);
                        break;
                    default:
                        throw new Exception("Unrecognized extension");
                }
                e.Result = true;
            }
            catch
            {
                e.Result = false;
            }
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            CurrentTable.GotProgress -= new DataTableProgressHandler(CurrentTable_GotProgress);
            CurrentTable.GotStatus -= new DataTableStatusHandler(CurrentTable_GotStatus);
            CurrentTable.CancelCheck -= new DataTableCancelHandler(CurrentTable_CancelCheck);

            if (!(bool)e.Result)
            {
                NMWin.Leader.Tell("This file could not be scanned.");
                SetStatus("This file could not be scanned.");
                throb.HideThrobber();
                return;
            }

            ShowTable(CurrentTable);
            AddTable(CurrentTable);

            throb.HideThrobber();
            SetStatus("Ready.");
        }

        void AddTable(nDataTable t)
        {
            Tables.Add(t.GetAsHandle());
            ShowTables();
        }

        void ShowTable(nDataTable dt)
        {
            dv.CurrentTable = null;
            dv.Clear();
            dv.SetNoClass();
            dv.CurrentTable = dt;
            dv.ShowTable();
        }

        private void nDataWorkBench_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public void DoResize()
        {
            try
            {
                gbLeft.Left = 0;
                gbLeft.Top = 0;
                gbLeft.Height = this.ClientRectangle.Height - sb.Height;

                lvTables.Width = gbLeft.ClientRectangle.Width - (lvTables.Left * 2);
                lvTables.Height = gbLeft.ClientRectangle.Height - (20 + lvTables.Top);

                sb.Left = 0;
                sb.Top = gbLeft.Bottom;
                sb.Width = this.ClientRectangle.Width;

                dv.Left = gbLeft.Right;
                dv.Top = 0;
                dv.Width = this.ClientRectangle.Width - dv.Left;
                dv.Height = this.ClientRectangle.Height - sb.Height;
            }
            catch { }
        }

        private void mnuCombine_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedIndices.Count < 2)
            {
                NMWin.Leader.Tell("Please select at least 2 tables to combine.");
                return;
            }

            CombineTables();
        }

        nDataTable CombineResult;

        void CombineTables()
        {
            ArrayList handles = new ArrayList();
            foreach (ListViewItem i in lvTables.SelectedItems)
            {
                handles.Add(i.Tag);
            }

            ArrayList fields = nDataTableHandle.GetCommonFields(NMWin.Data, handles);

            if (fields.Count < 2) //every table has unique_id, so it doesn't count
            {
                NMWin.Leader.Tell("There don't appear to be any commonly named fields in these tables.");
                return;
            }

            if (!NMWin.Leader.AreYouSure("combine these " + Tools.Number.LongFormat(handles.Count) + " tables with " + Tools.Number.LongFormat(fields.Count - 1) + " fields in common"))
                return;


            CombineTables(handles, fields);
        }

        void CombineTables(ArrayList handles, ArrayList fields)
        {
            if (bgCombine.IsBusy)
            {
                NMWin.Leader.Tell("Apparently a previous combine operation is already running.");
                return;
            }

            CombineResult = new nDataTable(NMWin.Data);
            CombineResult.GotProgress += new DataTableProgressHandler(CurrentTable_GotProgress);
            CombineResult.GotStatus += new DataTableStatusHandler(CurrentTable_GotStatus);
            CombineResult.CancelCheck += new DataTableCancelHandler(CurrentTable_CancelCheck);

            CombineTablesArgs args = new CombineTablesArgs();
            args.Handles = handles;
            args.Fields = fields;
            throb.ShowThrobber();
            bgCombine.RunWorkerAsync(args);

        }

        private void bgCombine_DoWork(object sender, DoWorkEventArgs e)
        {
            CombineTablesArgs args = (CombineTablesArgs)e.Argument;
            nDataTableHandle.CombineTables(NMWin.ContextDefault, CombineResult, args.Handles, args.Fields, xRefresh);
        }

        private void bgCombine_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CombineResult.GotProgress -= new DataTableProgressHandler(CurrentTable_GotProgress);
            CombineResult.GotStatus -= new DataTableStatusHandler(CurrentTable_GotStatus);
            CombineResult.CancelCheck -= new DataTableCancelHandler(CurrentTable_CancelCheck);

            CurrentTable = CombineResult;
            ShowTable(CombineResult);
            AddTable(CurrentTable);
            throb.HideThrobber();

            NMWin.Leader.Tell("Done.");
        }

        private void lvTables_DoubleClick(object sender, EventArgs e)
        {
            nDataTableHandle h = GetSelectedHandle();
            if (h == null)
                return;

            CurrentTable = h.xTable;
            ShowTable(CurrentTable);
        }

        nDataTableHandle GetSelectedHandle()
        {
            try
            {
                return (nDataTableHandle)lvTables.SelectedItems[0].Tag;

            }
            catch { return null; }
        }

    }

    public class CombineTablesArgs
    {
        public ArrayList Handles;
        public ArrayList Fields;

    }
}
