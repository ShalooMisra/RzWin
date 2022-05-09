using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using Core;
using Tools.Database;

namespace NewMethod
{
    public delegate void nDataViewColumnClick(Object sender, int column);
    public delegate void nDataViewAcceptHandler();
    public delegate void nDataViewClearHandler();
    public delegate void nDataViewImportHandler();

    public partial class nDataView : UserControl, ICompleteLoad
    {
        public event nDataViewAcceptHandler Accept;
        public event nDataViewAcceptHandler AfterClear;
        public event nDataViewImportHandler BeforeImport;
        public event nDataViewImportHandler AfterImport;
        public event nDataViewImportHandler FinishedShow;
        public event nDataViewColumnClick ColumnClick;

        SysNewMethod xSys
        {
            get
            {
                return NMWin.ContextDefault.xSys;
            }
        }
        public nDataTable CurrentTable;
        public CoreClassHandle CurrentClass;
        public ArrayList CommonFields = new ArrayList();
        public String CurrentFile = "";
        public bool SkipFirstRowCheck = false;
        private int ColumnInQuestion = -1;
        private ArrayList RequiredChecks = new ArrayList();
        public bool OnlyMatchExact = false;

        bool bRunning = false;
        bool bCancel = false;

        public nDataView()
        {
            InitializeComponent();


        }

        public void CompleteLoad()
        {
            CommonFields = new ArrayList();
            ClearRequired();
            throb.UseParentBackColor = false;
            throb.BackColor = this.BackColor;
            cmdClearColumns.Visible = NMWin.ContextDefault.xUser.IsDeveloper();
            cmdSetColumns.Visible = NMWin.ContextDefault.xUser.IsDeveloper();
        }

        private bool m_ForceSharedFolder = true;
        public bool ForceSharedFolder
        {
            get
            {
                return m_ForceSharedFolder;
            }
        }

        private bool m_DisableAutoMatching = false;
        public bool DisableAutoMatching
        {
            get
            {
                return m_DisableAutoMatching;
            }

            set
            {
                m_DisableAutoMatching = value;
                chkAutoMatch.Checked = m_DisableAutoMatching;
            }
        }

        private bool m_AlwaysDisableAccept = false;
        public bool AlwaysDisableAccept
        {
            get
            {
                return m_AlwaysDisableAccept;
            }
            set
            {
                m_AlwaysDisableAccept = value;
            }
        }

        public void SetAcceptCaption(String caption)
        {
            cmdAccept.Text = caption;
        }

        public Int64 Count
        {
            get
            {
                if (CurrentTable == null)
                    return 0;
                return CurrentTable.Count;
            }
        }

        private void cmdExcelImport_Click(object sender, EventArgs e)
        {
            ImportFile("xls", ToolsWin.FileSystem.ChooseAFile());
        }

        void CurrentTable_CancelCheck(nDataTableCancelArgs args)
        {
            if (bCancel)
                args.Cancel = true;
        }

        private void SetRunning()
        {
            bRunning = true;
            bCancel = false;
            cmdExcelImport.Text = "Cancel";
            cmdExcelImport.Refresh();
        }

        private void SetStopped()
        {
            bRunning = false;
            bCancel = false;
            cmdExcelImport.Text = "XLS";
            cmdExcelImport.Refresh();
        }

        private void NotifyBeforeImport()
        {
            if (BeforeImport != null)
                BeforeImport();
        }

        void CurrentTable_GotStatus(string status)
        {
            SetStatus(status);
        }

        void CurrentTable_GotProgress(int progress)
        {
            SetProgress(progress);
        }

        private void bgExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            FileImportArgs args = (FileImportArgs)e.Argument;

            try
            {
                switch (args.Extension.ToLower())
                {
                    case "xlsx":
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
                args.Success = true;
            }
            catch (Exception ex)
            {
                args.Success = false;
                args.ResultMessage = ex.Message;
            }
            e.Result = args;
        }

        private void bgExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ToolsOffice.ExcelOffice.largeColumnSupport = false;
            SetStopped();

            FileImportArgs args = (FileImportArgs)e.Result;

            if (!args.Success)
            {
                NMWin.Leader.Tell("This file could not be scanned: " + args.ResultMessage);
                SetStatus("This file could not be scanned: " + args.ResultMessage);
                Clear();
                HideThrobber();
                return;
            }

            ShowTable();
            if (AutoMatchColumns() > 0 && !SkipFirstRowCheck)
                CheckChopFirst();

            HideThrobber();
            SetStatus("Ready.");
        }

        private void CheckChopFirst()
        {
            if (NMWin.Leader.AskYesNo("The first row of this file appears to contain the column names.  Should it be removed from the item list?"))
            {
                CurrentTable.RemoveFirst();
                ShowTable();
            }
        }

        public int AutoMatchColumns()
        {
            if (DisableAutoMatching)
                return 0;

            PeekHeadings();

            int i = 0;
            foreach (nDataColumn c in CurrentTable.Columns)
            {
                if (c.p == null)  //only do it if it hasn't been matched
                {
                    nCommonField f = GetCommonFieldByAlias(c.Heading, true);
                    if (f != null)
                    {
                        if (!CurrentTable.HasColumnField(f.Field))
                        {
                            SetColumn(c.order, f, "");
                            i++;
                        }
                    }
                }
            }
            if (!OnlyMatchExact)
            {
                foreach (nDataColumn c in CurrentTable.Columns)
                {
                    if (c.p == null)  //only do it if it hasn't been matched
                    {
                        nCommonField f = GetCommonFieldByAlias(c.Heading, false);
                        if (f != null)
                        {
                            if (!CurrentTable.HasColumnField(f.Field))
                            {
                                SetColumn(c.order, f, "");
                                i++;
                            }
                        }
                    }
                }
            }
            return i;
        }

        private void PeekHeadings()
        {
            foreach (nDataColumn c in CurrentTable.Columns)
            {
                if (c.Heading.ToLower().StartsWith("f") && c.Heading.Length <= 3)
                    c.Heading = "";
                if (c.Heading.ToLower().StartsWith("column_"))
                    c.Heading = "";
                int i = 0;
                while (i < 20 && !Tools.Strings.StrExt(c.Heading))
                {
                    c.Heading = CurrentTable.GetRowValue(i, c.order);
                    i++;
                }
            }
        }

        private nCommonField GetCommonFieldByAlias(String strText, bool exact)
        {
            if (!Tools.Strings.StrExt(strText))
                return null;

            foreach (nCommonField f in CommonFields)
            {
                if (f.Matches(strText, exact))
                {
                    if (!CurrentTable.HasColumnField(f.Field))
                        return f;
                }
            }
            return null;
        }

        public void ShowTable()
        {
            lv.Items.Clear();
            lv.Columns.Clear();
            lv.BeginUpdate();

            try
            {
                foreach (nDataColumn c in CurrentTable.Columns)
                {
                    try
                    {
                        ColumnHeader ch;

                        if (CurrentClass == null)
                            ch = lv.Columns.Add(c.unique_id);
                        else
                            ch = lv.Columns.Add(c.Caption);
                        ch.Width = 100;// lv.Width / CurrentTable.Columns.Count;
                        //if (ch.Width < 20)
                        //    ch.Width = 50;
                    }
                    catch (Exception)
                    { }
                }

                foreach (nDataRow r in CurrentTable.GetQuickRows())
                {
                    ListViewItem i = lv.Items.Add("");

                    for (int j = 0; j < CurrentTable.Columns.Count; j++)
                    {
                        try
                        {
                            if (j == 0)
                                i.Text = (String)r.Values[j];
                            else
                                i.SubItems.Add((String)r.Values[j]);
                        }
                        catch (Exception)
                        { }
                    }
                    i.Tag = r;
                }
            }
            catch (Exception)
            { }

            lv.EndUpdate();
            AllowAccept();

            FireFinishedShow();

            ShowTotal();
        }

        void FireFinishedShow()
        {
            if (FinishedShow != null)
                FinishedShow();
        }

        public void AllowAccept()
        {
            if (!m_AlwaysDisableAccept)
                cmdAccept.Visible = true;
        }

        public void DisableAccept()
        {
            cmdAccept.Visible = false;
        }

        public void Clear()
        {
            bool b = false;
            if (CurrentTable != null)
                b = (CurrentTable.Count > 0);

            SetStatus("Clearing...");
            lv.Items.Clear();
            lv.Columns.Clear();
            if (CurrentTable != null)
                CurrentTable.Clear();
            DisableAccept();
            SetStatus("Ready.");
            SetProgress(0);
            ShowTotal();

            if (b)
            {
                if (AfterClear != null)
                    AfterClear();
            }
        }

        private void ShowTotal()
        {
            if (CurrentTable == null)
                lblItems.Text = "<no items>";
            else if (CurrentTable.Count == 1)
                lblItems.Text = "1 Item";
            else
            {
                if (CurrentTable.Count > CurrentTable.GetQuickRows().Count)
                    lblItems.Text = Tools.Number.LongFormat(CurrentTable.Count) + " Items [ " + Tools.Number.LongFormat(CurrentTable.GetQuickRows().Count) + " Items Showing ]";
                else
                    lblItems.Text = Tools.Number.LongFormat(CurrentTable.Count) + " Items";
            }

            if (CurrentTable == null)
            {
                lblTableName.Visible = false;
            }
            else
            {
                if (CurrentTable.TableMode)
                {
                    lblTableName.Visible = true;
                    lblTableName.Text = CurrentTable.TableName;
                }
                else
                    lblTableName.Visible = false;
            }
        }

        public void SetNoClass()
        {
            mnu.Items.Clear();
            ToolStripMenuItem i = new ToolStripMenuItem();
            i.Text = "Rename";
            i.Tag = "<rename>";
            i.Click += new EventHandler(i_Click);
            mnu.Items.Add(i);

            i = new ToolStripMenuItem();
            i.Text = "Remove";
            i.Tag = "<remove>";
            i.Click += new EventHandler(i_Click);
            mnu.Items.Add(i);
        }

        public void SetClass(String strClass)
        {
            CurrentClass = NMWin.ContextDefault.TheSys.CoreClassGet(strClass);

            mnu.Items.Clear();

            ClearRequired();

            ToolStripItem i;
            i = mnu.Items.Add("<copy>");
            i.Tag = "<copy>";
            i.Click += new EventHandler(i_Click);

            i = mnu.Items.Add("<rename>");
            i.Tag = "<rename>";
            i.Click += new EventHandler(i_Click);

            if (CurrentClass == null)
                return;

            i = mnu.Items.Add("<none>");
            i.Tag = "<none>";
            i.Click += new EventHandler(i_Click);

            i = mnu.Items.Add("<search>");
            i.Tag = "<search>";
            i.Click += new EventHandler(i_Click);

            mnu.Items.Add(new ToolStripSeparator());

            foreach (nCommonField f in CommonFields)
            {
                i = mnu.Items.Add(f.Caption);
                i.Tag = f;
                i.Click += new EventHandler(i_Click);

                if (f.IsRequired)
                {
                    CheckBox x = new CheckBox();
                    gb.Controls.Add(x);
                    x.Visible = true;
                    x.Enabled = false;
                    x.Tag = f.Field;
                    x.Left = lblRequired.Left;
                    x.Top = lblRequired.Bottom + (RequiredChecks.Count * x.Height);
                    x.Text = f.Caption;
                    RequiredChecks.Add(x);
                }
            }
            ToolStripMenuItem rest = (ToolStripMenuItem)mnu.Items.Add("All Fields");
            SortedList<string, string> sl = new SortedList<string, string>();
            foreach (CoreVarValAttribute p in CurrentClass.VarValsGet())
            {
                try { sl.Add(p.Caption, p.Name); }
                catch { }
            }
            foreach (KeyValuePair<string, string> kvp in sl)
            {
                i = rest.DropDownItems.Add(kvp.Key + " [" + kvp.Value + "]");
                i.Tag = kvp.Value;
                i.Click += new EventHandler(i_Click);
            }
            //foreach(CoreVarValAttribute p in CurrentClass.VarValsGet())
            //{
            //    i = rest.DropDownItems.Add(p.Caption + " [" + p.Name + "]");
            //    i.Tag = p.Name;
            //    i.Click += new EventHandler(i_Click);
            //}
        }

        public void ClearRequired()
        {
            foreach (CheckBox c in RequiredChecks)
            {
                gb.Controls.Remove(c);
                c.Dispose();
            }
            RequiredChecks = new ArrayList();
        }

        void i_Click(object sender, EventArgs e)
        {
            if (ColumnInQuestion < 0)
                return;

            ToolStripItem i = null;

            try
            {
                i = (ToolStripItem)sender;
            }
            catch (Exception)
            {
                return;
            }

            nCommonField cf = null;
            String strField = "";
            try
            {
                cf = (nCommonField)i.Tag;
            }
            catch (Exception)
            {
                try
                {
                    strField = (String)i.Tag;

                    switch (strField.ToLower().Trim())
                    {
                        case "<copy>":
                            if (CurrentTable != null)
                            {
                                ShowThrobber();
                                CurrentTable.CopyColumn(NMWin.ContextDefault, ColumnInQuestion);
                                ShowTable();
                                HideThrobber();
                            }
                            return;
                        case "<rename>":
                            if (CurrentTable != null)
                            {
                                String s = NMWin.Leader.AskForString("New column name:", "", "Column Name");
                                if (!Tools.Strings.StrExt(s))
                                    return;

                                if (CurrentTable.RenameFieldByIndex(ColumnInQuestion, s))
                                {
                                    ColumnHeader c = lv.Columns[ColumnInQuestion];
                                    c.Text = s;
                                }

                                FireFinishedShow();
                            }
                            return;
                        case "<remove>":
                            if (CurrentTable != null)
                            {
                                ShowThrobber();
                                nDataColumn c = (nDataColumn)CurrentTable.Columns[ColumnInQuestion];
                                CurrentTable.xData.Execute("alter table " + CurrentTable.TableName + " drop column " + c.unique_id);
                                CurrentTable.Columns.Remove(c);
                                CurrentTable.RefreshFromDatabase(NMWin.ContextDefault);
                                ShowTable();
                                HideThrobber();
                            }
                            return;
                        case "<search>":
                            String strProp = ChooseProp();
                            if (!Tools.Strings.StrExt(strProp))
                                return;
                            SetColumn(ColumnInQuestion, cf, strProp);
                            return;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }

            SetColumn(ColumnInQuestion, cf, strField);
        }

        private void SetColumn(int ColumnInQuestion, nCommonField cf, String strField)
        {
            try
            {
                //get the column
                nDataColumn c = (nDataColumn)CurrentTable.Columns[ColumnInQuestion];

                if (cf == null)
                    cf = new nCommonField(strField, "", "");

                if (Tools.Strings.StrCmp(cf.Field, "<none>"))
                {
                    c.Caption = "<click here>";
                    c.IsExtra = false;
                    c.p = null;
                    ColumnHeader ch = lv.Columns[c.order];
                    ch.Text = "<click here>";
                }
                else
                {
                    CoreVarValAttribute p = null;
                    if (cf.IsExtra)
                    {
                        c.IsExtra = true;
                        p = new CoreVarValAttribute(cf.Field, cf.FieldType.ToString());
                        p.Caption = cf.Caption;
                        p.TheFieldLength = 255;
                        p.TheFieldType = Tools.Database.FieldType.String;
                    }
                    else
                    {
                        c.IsExtra = false;
                        p = CurrentClass.VarValGet(cf.Field);
                    }
                    //!! Need to check if it's a duplicate column assignment
                    //foreach (nDataColumn cc in CurrentTable.Columns)
                    //{
                    //    if (cc.p == null)
                    //        continue;
                    //    if (Tools.Strings.StrCmp(cc.p.name, p.name))
                    //    { 
                    //        SetStatus("Duplicate column assignment detected!");
                    //        return;
                    //    }
                    //}
                    if (Tools.Strings.StrExt(cf.Caption))
                        c.Caption = cf.Caption;
                    else
                        c.Caption = p.Caption;
                    c.p = p;
                    ColumnHeader ch = lv.Columns[c.order];
                    ch.Text = c.Caption;
                }
            }
            catch { }
            CheckRequired();
        }

        public String ChooseProp()
        {
            return frmChooseProp.Choose(xSys, CurrentClass, this.ParentForm);
        }

        public void CheckRequired()
        {
            foreach (CheckBox x in RequiredChecks)
            {
                x.Checked = CurrentTable.HasColumnField((String)x.Tag);

                if (Tools.Strings.StrCmp((String)x.Tag, "fullpartnumber") && !x.Checked)
                {
                    if (CurrentTable.HasColumnField("prefix") && CurrentTable.HasColumnField("basenumber"))
                        x.Checked = true;
                }
            }
        }

        public void AddCommonField(String strField, String strCaption, String strAlias)
        {
            AddCommonField(strField, strCaption, strAlias, false);
        }

        public void AddCommonField(String strField, String strCaption, String strAlias, bool required)
        {
            CommonFields.Add(new nCommonField(strField, strCaption, strAlias, false, required));
        }

        public void AddExtraField(String strField, String strCaption)
        {
            AddExtraField(strField, strCaption, "");
        }

        public void AddExtraField(String strField, String strCaption, String strAlias)
        {
            AddExtraField(strField, strCaption, strAlias, false, FieldType.String);
        }

        public void AddExtraField(String strField, String strCaption, String strAlias, bool required)
        {
            AddExtraField(strField, strCaption, strAlias, required, FieldType.String);
        }

        public void AddExtraField(String strField, String strCaption, String strAlias, bool required, FieldType t)
        {
            CommonFields.Add(new nCommonField(strField, strCaption, strAlias, true, required, t));
        }

        //private void lv_ColumnClickExt(object sender, ManagedControls.ManagedListView.ColumnClickExtEventArgs e)
        //{
        //    //if (ColumnClicked != null)
        //    //    ColumnClicked(this, e.Column);
        //    ColumnInQuestion = e.Column;
        //    mnu.Show(System.Windows.Forms.Cursor.Position);
        //}

        private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnInQuestion = e.Column;

            if (ColumnClick != null)
                ColumnClick(this, e.Column);

            if (ToolsWin.Keyboard.GetShiftKey())
                mnuData.Show(System.Windows.Forms.Cursor.Position);
            else
                mnu.Show(System.Windows.Forms.Cursor.Position);
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {

            String s = "";
            foreach (CheckBox x in RequiredChecks)
            {
                //KT Changed this to check for the word "Master" in the cmdAccept Button text, if present, don't require quanity.
                //if (!x.Checked)
                if (!x.Checked && RequiredChecks.Contains(x.Text))
                    if (cmdAccept.Text.Contains("Master") && x.Text=="Quantity")
                    {

                    }
                    else
                        s += x.Text + "\r\n";
            }

            if (Tools.Strings.StrExt(s))
            {
                NMWin.Leader.Tell("Please match these required column(s) before continuing:\r\n" + s);
                return;
            }

            if (Accept != null)
                Accept();


        }

        public bool HasRequiredFields()
        {
            foreach (CheckBox x in RequiredChecks)
            {
                if (!x.Checked)
                    return false;
            }
            return true;
        }

        private void mnuRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in lv.SelectedItems)
            {
                nDataRow r = (nDataRow)i.Tag;
                CurrentTable.RemoveRow(r);
            }
            ShowTable();
        }

        private void nDataView_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        bool m_HideOptions = false;
        public bool HideOptions
        {
            get
            {
                return m_HideOptions;
            }

            set
            {
                m_HideOptions = value;
                DoResize();
            }
        }

        public void DoResize()
        {
            try
            {
                if (m_HideOptions)
                {
                    gb.Visible = false;

                    gbTop.Top = 0;
                    gbTop.Left = 0;
                    gbTop.Width = this.ClientRectangle.Width - gbTop.Left;

                    lv.Left = 0;
                    lv.Top = gbTop.Bottom;
                    lv.Width = this.ClientRectangle.Width - lv.Left;
                    lv.Height = this.ClientRectangle.Height - lv.Top;
                }
                else
                {
                    gb.Visible = true;
                    gb.Top = 0;
                    gb.Left = 0;
                    gb.Height = this.ClientRectangle.Height;

                    gbTop.Top = 0;
                    gbTop.Left = gb.Width;
                    gbTop.Width = this.ClientRectangle.Width - gbTop.Left;

                    lv.Left = gb.Right;
                    lv.Top = gbTop.Bottom;
                    lv.Width = this.ClientRectangle.Width - lv.Left;
                    lv.Height = this.ClientRectangle.Height - lv.Top;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public ArrayList GetObjects()
        {
            ArrayList ret = new ArrayList();

            foreach (nDataRow r in CurrentTable.GetAllRows(NMWin.ContextDefault))
            {
                nObject o = (nObject)NMWin.ContextDefault.Item(CurrentClass.Name);
                if (o != null)
                {
                    nObjectHolder h = new nObjectHolder(o);
                    foreach (nDataColumn c in CurrentTable.Columns)
                    {
                        if (c.p != null)
                        {

                            String s = nData.NullFilter_String((String)r.Values[c.order]);

                            if (c.IsExtra)
                            {
                                h.AddExtraProp(c.p.Name, (String)r.Values[c.order]);
                            }
                            else
                            {
                                switch (c.p.TheFieldType)
                                {
                                    case FieldType.Double:
                                        s = s.Replace("$", "").Trim();
                                        break;
                                    case FieldType.Int32:
                                    case FieldType.Int64:
                                        //s = s.Replace(",", "").Trim();
                                        //s = s.Replace("pcs.", "").Trim();
                                        //s = s.Replace("pcs", "").Trim();
                                        s = Tools.Number.QuantityFilter(s);
                                        break;
                                }
                                o.ISet_String(c.p.Name, s, c.p.TheFieldType);
                            }
                        }
                    }
                    ret.Add(h);
                }
            }
            return ret;
        }

        private void cmdImportFromCSV_Click(object sender, EventArgs e)
        {
            ImportFile("csv", ToolsWin.FileSystem.ChooseAFile());
        }

        public void ShowThrobber()
        {
            throb.ShowThrobber();
        }

        public void HideThrobber()
        {
            throb.HideThrobber();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            if (!NMWin.Leader.AreYouSure("clear this entire list"))
                return;

            Clear();
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
                lblStatus.Text = s;
                lblStatus.Refresh();
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

        private void chkShared_CheckedChanged(object sender, EventArgs e)
        {
            m_ForceSharedFolder = chkShared.Checked;
        }

        //private void cmdSQL_Click(object sender, EventArgs e)
        //{
        //    ImportFromSQL();
        //}

        //private void ImportFromSQL()
        //{
        //    n_data_target t = frmDataSources.Choose(this.ParentForm, this.xSys);
        //    if (t == null)
        //        return;

        //    ImportFromSQL(t);
        //}

        //public void ImportFromSQL(n_data_target t)
        //{
        //    ShowThrobber();
        //    SetRunning();
        //    CurrentTable = new nDataTable(xSys.xData);
        //    CurrentTable.GotProgress += new DataTableProgressHandler(CurrentTable_GotProgress);
        //    CurrentTable.GotStatus += new DataTableStatusHandler(CurrentTable_GotStatus);
        //    CurrentTable.CancelCheck += new DataTableCancelHandler(CurrentTable_CancelCheck);
        //    SetStatus("Importing from " + t.name);
        //    bgSQL.RunWorkerAsync(t);
        //}

        //private void bgSQL_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    n_data_target t = (n_data_target)e.Argument;
        //    try
        //    {
        //        CurrentTable.ImportFromSQL(t);
        //        e.Result = true;
        //    }
        //    catch { e.Result = false; }
        //}

        //private void bgSQL_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    ShowTable();
        //    AutoMatchColumns();
        //    switch ((Int64)e.Result)
        //    {
        //        case -1:
        //            SetStatus("Error: This import was not successful.");
        //            break;
        //        case 0:
        //            SetStatus("The import finished, but no data was imported.");
        //            context.TheLeader.Tell("The import finished, but no data was imported.");
        //            break;
        //        default:
        //            SetStatus("Done: " + Tools.Number.LongFormat((Int64)e.Result) + " records were imported.");
        //            context.TheLeader.Tell("Done: " + Tools.Number.LongFormat((Int64)e.Result) + " records were imported.");
        //            break;
        //    }

        //    NotifyFinished();
        //    HideThrobber();
        //}

        public void NotifyFinished()
        {
            if (AfterImport != null)
                AfterImport();
        }

        //private void cmdxls2_Click(object sender, EventArgs e)
        //{

        //    ImportFile("xls", ToolsWin.FileSystem.ChooseAFile(), true);
        //}

        public void ImportFile(String strExt, String file)
        {
            ImportFile(strExt, file, false);
        }

        private void ImportFile(String strExt, String file, bool two)
        {
            if (bRunning)
            {
                if (bCancel)
                    return;

                if (!NMWin.Leader.AreYouSure("cancel this import"))
                    return;

                SetStatus("Cancelling...");
                bCancel = true;
                return;
            }

            if (Count > 0)
            {
                if (!NMWin.Leader.AreYouSure("clear the list and import new information"))
                    return;
            }

            NotifyBeforeImport();
            Clear();

            //String f = nTools.ChooseAFile();
            String f = file;

            if (!Tools.Strings.StrExt(f))
                return;

            if (!System.IO.File.Exists(f))
            {
                NMWin.Leader.Tell(f + " could not be found.");
                return;
            }
            switch (strExt.ToLower())
            {
                case "xls":
                    if (NMWin.User.IsDeveloper())
                        ToolsOffice.ExcelOffice.largeColumnSupport = NMWin.Leader.AskYesNo("Is this going to be run as a 'Large Column' import?");
                    String ex = System.IO.Path.GetExtension(f).Replace(".", "").ToLower();
                    if (ex != "xls" && ex != "xlsx")
                    {
                        NMWin.Leader.Tell("Please choose a file with the ." + strExt + " extension.");
                        ToolsOffice.ExcelOffice.largeColumnSupport = false;
                        return;
                    }
                    break;
                default:
                    if (!Tools.Strings.StrCmp(strExt, System.IO.Path.GetExtension(f).Replace(".", "")))
                    {
                        NMWin.Leader.Tell("Please choose a file with the ." + strExt + " extension.");
                        return;
                    }
                    break;
            }
            CurrentFile = f;
            ShowThrobber();
            SetStatus("Importing from " + f);
            SetRunning();
            CurrentTable = new nDataTable(NMWin.Data);
            CurrentTable.GotProgress += new DataTableProgressHandler(CurrentTable_GotProgress);
            CurrentTable.GotStatus += new DataTableStatusHandler(CurrentTable_GotStatus);
            CurrentTable.CancelCheck += new DataTableCancelHandler(CurrentTable_CancelCheck);

            FileImportArgs args = new FileImportArgs(f, strExt);
            args.TwoRelatedSheets = two;
            bgExcel.RunWorkerAsync(args);
        }

        private void lblTableName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentTable == null)
                return;

            if (!CurrentTable.TableMode)
                return;
            ToolsWin.Clipboard.SetClip(CurrentTable.TableName);
        }

        private void lblRename_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String s = NMWin.Leader.AskForString("New Table Name:", CurrentTable.TableName, false, "New Table Name");
            if (!Tools.Strings.StrExt(s))
                return;

            if (CurrentTable.xData.TableExists(s))
            {
                if (!NMWin.Leader.AskYesNo(s + " already exists as a table.  Do you want to remove it?"))
                    return;

                CurrentTable.xData.RenameTable(s, "temp_renamed_" + Tools.Strings.GetNewID() + "_" + s);
            }

            CurrentTable.RenameTable(s);
            lblTableName.Text = s;
        }

        private void cmdHide_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void mnuCountSpecificBlank_Click(object sender, EventArgs e)
        {
            CountSpecific("");
        }

        private void CountSpecific(String strVal)
        {
            if (ColumnInQuestion < 0)
                return;

            long l = CurrentTable.CountSpecificValue(ColumnInQuestion, strVal);
            NMWin.Leader.Tell("This table has " + Tools.Number.LongFormat(l) + " lines that equal '" + strVal + "' in this column");
        }

        public void DeleteSpecific(String strVal)
        {
            if (ColumnInQuestion < 0)
                return;

            long l = CurrentTable.CountSpecificValue(ColumnInQuestion, strVal);
            if (l <= 0)
            {
                NMWin.Leader.Tell("No rows were found with this criteria.");
                return;
            }

            if (!NMWin.Leader.AreYouSure("delete " + Tools.Number.LongFormat(l) + " rows"))
                return;

            l = 0;
            CurrentTable.DeleteSpecificValue(ColumnInQuestion, strVal, ref l);
            CurrentTable.RefreshFromDatabase(NMWin.ContextDefault);
            ShowTable();
            SetStatus(Tools.Number.LongFormat(l) + " rows were removed.");
        }

        private void mnuCountSpecificOther_Click(object sender, EventArgs e)
        {
            String val = NMWin.Leader.AskForString("Value", "", false, "Value");
            if (!Tools.Strings.StrExt(val))
                return;

            CountSpecific(val);
        }

        private void mnuDeleteBlank_Click(object sender, EventArgs e)
        {
            DeleteSpecific("");
        }

        private void mnuDeleteOther_Click(object sender, EventArgs e)
        {
            String val = NMWin.Leader.AskForString("Value", "", false, "Value");
            if (!Tools.Strings.StrExt(val))
                return;

            DeleteSpecific(val);
        }

        private void mnuTruncateSpace_Click(object sender, EventArgs e)
        {
            TruncateAfter(" ");
        }

        private void mnuTruncateColon_Click(object sender, EventArgs e)
        {
            TruncateAfter(":");
        }

        private void mnuTruncateSemicolon_Click(object sender, EventArgs e)
        {
            TruncateAfter(";");
        }

        private void mnuTruncateOther_Click(object sender, EventArgs e)
        {
            String strVal = NMWin.Leader.AskForString("Value", "", false, "Value");
            if (!Tools.Strings.StrExt(strVal))
                return;

            TruncateAfter(strVal);
        }

        private void TruncateAfter(String val)
        {
            if (ColumnInQuestion < 0)
                return;

            long l = CurrentTable.CountIncludingValue(ColumnInQuestion, val);
            if (l <= 0)
            {
                NMWin.Leader.Tell("No rows were found with this criteria.");
                return;
            }

            if (!NMWin.Leader.AreYouSure("truncate data on " + Tools.Number.LongFormat(l) + " rows"))
                return;

            l = 0;
            CurrentTable.TruncateIncludingValue(ColumnInQuestion, val, ref l);
            CurrentTable.RefreshFromDatabase(NMWin.ContextDefault);
            ShowTable();
            SetStatus(Tools.Number.LongFormat(l) + " rows were truncated.");
        }

        private void mnuSplitOther_Click(object sender, EventArgs e)
        {
            String strVal = NMWin.Leader.AskForString("Value", "", "Value");
            if (!Tools.Strings.StrExt(strVal))
                return;

            SplitRight(strVal);
        }

        private void SplitRight(String val)
        {
            if (ColumnInQuestion < 0)
                return;

            long l = CurrentTable.CountIncludingValue(ColumnInQuestion, val);
            if (l <= 0)
            {
                NMWin.Leader.Tell("No rows were found with this criteria.");
                return;
            }

            if (!NMWin.Leader.AreYouSure("split data on the right side on " + Tools.Number.LongFormat(l) + " rows"))
                return;

            l = 0;
            CurrentTable.SplitOnValue_Right(NMWin.ContextDefault, ColumnInQuestion, val, ref l, false);
            //CurrentTable.RefreshFromDatabase();      //happens automatically
            ShowTable();
            SetStatus(Tools.Number.LongFormat(l) + " rows were split.");
        }

        private void mnuSplitSpace_Click(object sender, EventArgs e)
        {
            SplitRight(" ");
        }

        private void mnuSplitColon_Click(object sender, EventArgs e)
        {
            SplitRight(":");
        }

        private void mnuSplitSemicolon_Click(object sender, EventArgs e)
        {
            SplitRight(";");
        }

        private void mnuSplitSlash_Click(object sender, EventArgs e)
        {
            SplitRight("/");
        }

        private void AppendColumn(String strSeparator)
        {
            if (ColumnInQuestion < 0)
                return;
            Dictionary<String, String> d = new Dictionary<String, String>();
            foreach (nDataColumn c in CurrentTable.Columns)
            {
                d.Add(c.unique_id, c.Caption);
            }
            String s = frmChooseFromDictionary.Choose(d, "Choose a column to append", false, this.ParentForm);
            if (!Tools.Strings.StrExt(s))
                return;
            CurrentTable.AppendColumn(NMWin.ContextDefault, ColumnInQuestion, s, strSeparator);
            ShowTable();
        }

        private void cmdExportToCsv_Click(object sender, EventArgs e)
        {
            if (CurrentTable != null)
                CurrentTable.ExportToCsv();
        }

        private void mnuAppendNoSeparator_Click(object sender, EventArgs e)
        {
            AppendColumn("");
        }

        private void mnuAppendWithSpace_Click(object sender, EventArgs e)
        {
            AppendColumn(" ");
        }

        private void mnuWithCustom_Click(object sender, EventArgs e)
        {
            String s = NMWin.Leader.AskForString("Seperator: ", "", "Seperator");
            if (!Tools.Strings.StrExt(s))
                return;
            AppendColumn(s);
        }

        public void SetDataTable(nDataTable d)
        {
            CurrentTable = d;
            ShowTable();
        }

        private void cmdImportFromDBF_Click(object sender, EventArgs e)
        {
            ImportFile("dbf", ToolsWin.FileSystem.ChooseAFile());
        }

        private void mnuSplitEmailDomain_Click(object sender, EventArgs e)
        {
            if (ColumnInQuestion < 0)
                return;

            long l = CurrentTable.CountIncludingValue(ColumnInQuestion, "@");
            if (l <= 0)
            {
                NMWin.Leader.Tell("No rows were found with email addresses.");
                return;
            }

            if (!NMWin.Leader.AreYouSure("create a new column for the email domain of " + Tools.Number.LongFormat(l) + " rows"))
                return;

            l = 0;
            CurrentTable.SplitEmailDomain(NMWin.ContextDefault, ColumnInQuestion, ref l);
            //CurrentTable.RefreshFromDatabase();      //happens automatically
            ShowTable();
            SetStatus(Tools.Number.LongFormat(l) + " rows were split.");
        }

        private void lblProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nDataTable dp = CurrentTable.Process(NMWin.ContextDefault);
            if (dp == null)
                return;

            nDataView v = new nDataView();
            NMWin.MainForm.TabShow(v, "Processed Table");
            v.CompleteLoad();
            v.SetDataTable(dp);
            //v.ShowTable();
        }

        private void mnuSplitColumnsComma_Click(object sender, EventArgs e)
        {
            SplitColumnIntoColumns(",");
        }

        private void mnuSplitColumnsOther_Click(object sender, EventArgs e)
        {
            String s = NMWin.Leader.AskForString("Split by?", ",", "Split by?");
            if (!Tools.Strings.StrExt(s))
                return;

            SplitColumnIntoColumns(s);
        }

        void SplitColumnIntoColumns(String by)
        {
            if (ColumnInQuestion < 0)
                return;

            long l = CurrentTable.CountIncludingValue(ColumnInQuestion, by);
            if (l <= 0)
            {
                NMWin.Leader.Tell("No rows were found with '" + by + "'");
                return;
            }

            if (!NMWin.Leader.AreYouSure("create new columns for the " + Tools.Strings.PluralizePhrase("matching row", l)))
                return;

            l = 0;
            CurrentTable.SplitColumnIntoColumns(NMWin.ContextDefault, ColumnInQuestion, by, ref l);
            //CurrentTable.RefreshFromDatabase();      //happens automatically
            ShowTable();
            SetStatus(Tools.Number.LongFormat(l) + " rows were split.");
        }

        private void properlyCaseContactNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ColumnInQuestion < 0)
                return;

            String field = CurrentTable.GetColumnNameByColumnIndex(ColumnInQuestion);
            if (!Tools.Strings.StrExt(field))
                return;

            DataTable d = CurrentTable.xData.Select("select unique_id, " + field + " as [TheValue] from " + CurrentTable.TableName);
            foreach (DataRow r in d.Rows)
            {
                String uid = nData.NullFilter(r["unique_id"]);
                String val = nData.NullFilter(r["TheValue"]).Trim().ToLower();

                String newval = Tools.People.ContactNameClean(val);
                newval = Tools.People.ToProperCase(newval);
                CurrentTable.xData.Execute("update " + CurrentTable.TableName + " set " + field + " = '" + CurrentTable.xData.SyntaxFilter(newval) + "' where unique_id = '" + uid + "'");
            }

            CurrentTable.RefreshFromDatabase(NMWin.ContextDefault);
            ShowTable();
            SetStatus("Done");
        }

        private void spacifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ColumnInQuestion < 0)
                return;

            String field = CurrentTable.GetColumnNameByColumnIndex(ColumnInQuestion);
            if (!Tools.Strings.StrExt(field))
                return;

            CurrentTable.xData.Execute("update " + CurrentTable.TableName + " set " + field + " = ltrim(rtrim(replace(isnull(" + field + ", ''), '  ', ' ')))");

            CurrentTable.RefreshFromDatabase(NMWin.ContextDefault);
            ShowTable();
            SetStatus("Done");

        }

        private void cmdSelectFile_Click(object sender, EventArgs e)
        {
            String file = ToolsWin.FileSystem.ChooseAFile();
            String ext = Tools.Files.GetFileExtention(file);
            if (!Tools.Strings.StrExt(ext))
                return;
            //if (!Tools.Strings.StrCmp(ext, "xls") && !Tools.Strings.StrCmp(ext, "csv") && !Tools.Strings.StrCmp(ext, "dbf"))  //&& !Tools.Strings.StrCmp(ext, "xlsx") this doesn't work yet; the parsing isn't correct
            //{
            //    context.TheLeader.Tell("Please choose a file with one of the following extentions: xls, csv, dbf");
            //    return;
            //}
            ImportFile(ext, file);
        }

        private void cmdClearColumns_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (nDataColumn c in CurrentTable.Columns)
            {
                c.p = null;
                SetColumn(i, null, "<none>");
                c.Heading = "";
                i++;
            }
        }

        private void cmdSetColumns_Click(object sender, EventArgs e)
        {
            cmdClearColumns_Click(sender, e);
            AutoMatchColumns();
        }

        private void mnuSplitContactFirstName_Click(object sender, EventArgs e)
        {
            if (ColumnInQuestion < 0)
                return;
            long l = CurrentTable.CountWithValue(ColumnInQuestion);
            if (l <= 0)
            {
                NMWin.Leader.Tell("No rows were found with contact names.");
                return;
            }
            if (!NMWin.Leader.AreYouSure("create a new column for the contact first name of " + Tools.Number.LongFormat(l) + " rows"))
                return;
            nDataColumn c = (nDataColumn)CurrentTable.Columns[ColumnInQuestion];
            if (c == null)
                throw new Exception("Field not found");
            nDataColumn n = new nDataColumn(CurrentTable.Columns.Count);
            CurrentTable.AddField(n.unique_id);
            CurrentTable.Columns.Add(n);
            DataTable dt = NMWin.ContextDefault.Select("select unique_id," + c.unique_id + " from " + CurrentTable.TableName);
            if (dt == null || dt.Rows.Count <= 0)
            {
                NMWin.Leader.Tell("No rows were found with contact names.");
                return;
            }
            l = 0;
            long err = 0;
            foreach (DataRow dr in dt.Rows)
            {
                string id = Tools.Data.NullFilterString(dr["unique_id"]);
                string name = Tools.Data.NullFilterString(dr[c.unique_id]);
                string first = Tools.Strings.NiceFormat(Tools.People.FirstNameParse(name));
                if (!Tools.Strings.StrExt(name))
                    continue;
                l++;
                try { NMWin.ContextDefault.Execute("update " + CurrentTable.TableName + " set " + n.unique_id + "='" + NMWin.ContextDefault.Filter(first) + "' where unique_id = '" + id + "'"); }
                catch { err++; }
            }
            CurrentTable.RefreshFromDatabase(NMWin.ContextDefault);
            ShowTable();
            SetStatus(Tools.Number.LongFormat(l) + " rows were split.");
        }

        //public static String ContactNameClean(String val)
        //{
        //    String ret = val.ToLower().Trim();
        //    bool changed = true;
        //    int i = 0;
        //    while (changed)
        //    {
        //        ret = ContactNameClean(ret, ref changed);

        //        i++;
        //        if (i > 5)
        //            break;
        //    }
        //    return ret;
        //}



    }

    public class nObjectHolder
    {
        public nObject xObject;
        public SortedList ExtraProps = new SortedList();
        public nObjectHolder(nObject x)
        {
            xObject = x;
        }

        public void AddExtraProp(String strName, String strVal)
        {
            nVar v = new nVar();
            v.variable_name = strName;
            v.variable_value = strVal;
            try
            {
                ExtraProps.Add(v.variable_name, v);
            }
            catch (Exception)
            { }
        }

        public Int64 Get_Long(String strField)
        {
            nVar v = (nVar)ExtraProps[strField];
            if (v == null)
                return 0;
            String lng = Get_String(strField);
            if (Tools.Strings.StrExt(lng))
            {
                lng = lng.Replace("k", "");
                lng = lng.Replace("pcs", "");
                lng = lng.Replace("peices", "");
                lng = lng.Replace("K", "");
                lng = lng.Replace("PCS", "");
                lng = lng.Replace("PEICES", "");
            }
            if (Tools.Strings.StrExt(lng))
                v.variable_value = lng;
            try
            {
                return Convert.ToInt64(v.variable_value);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Double Get_Double(String strField)
        {
            nVar v = (nVar)ExtraProps[strField];
            if (v == null)
                return 0;
            String dbl = Get_String(strField);
            if (Tools.Strings.StrExt(dbl))
            {
                dbl = dbl.Replace("$", "");
                dbl = dbl.Replace("usd", "");
                dbl = dbl.Replace("USD", "");
            }
            if (Tools.Strings.StrExt(dbl))
                v.variable_value = dbl;
            try
            {
                return Convert.ToDouble(v.variable_value);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public String Get_String(String strField)
        {
            nVar v = (nVar)ExtraProps[strField];
            if (v == null)
                return "";
            try
            {
                return Convert.ToString(v.variable_value);
            }
            catch (Exception)
            {
                return "";
            }
        }



    }

    public class nCommonField
    {
        public String Field = "";
        public String Caption = "";
        public String[] Aliases;
        public bool IsExtra = false;
        public bool IsRequired = false;
        public Tools.Database.FieldType FieldType = Tools.Database.FieldType.String;

        public nCommonField(String strField, String strCaption, String strAliases)
        {
            Field = strField;
            Caption = strCaption;
            Aliases = Tools.Strings.Split(strAliases, "|");
        }

        public nCommonField(String strField, String strCaption, String strAliases, bool extra, bool required)
        {
            Field = strField;
            Caption = strCaption;
            Aliases = Tools.Strings.Split(strAliases, "|");
            IsExtra = extra;
            IsRequired = required;
        }

        public nCommonField(String strField, String strCaption, String strAliases, bool extra, bool required, FieldType t)
        {
            Field = strField;
            Caption = strCaption;
            Aliases = Tools.Strings.Split(strAliases, "|");
            IsExtra = extra;
            IsRequired = required;
            FieldType = t;
        }

        public bool Matches(String strText, bool exact)
        {
            foreach (String s in Aliases)
            {
                if (Tools.Strings.StrExt(s))
                {
                    if (exact)
                    {
                        if (Tools.Strings.StrCmp(Tools.Strings.FilterTrash(strText), Tools.Strings.FilterTrash(s)))
                            return true;
                    }
                    else
                    {
                        if (Tools.Strings.HasString(Tools.Strings.FilterTrash(strText), Tools.Strings.FilterTrash(s)))
                            return true;
                    }
                }
            }

            return false;
        }
    }

    public class FileImportArgs
    {
        public String FileName = "";
        public String Extension = "";
        public bool TwoRelatedSheets = false;
        public int Index1 = -1;
        public int Index2 = -1;
        public String ResultMessage = "";
        public bool Success = true;

        public FileImportArgs(String strFile, String strExtension)
        {
            FileName = strFile;
            Extension = strExtension;
        }

        public void SetIndexes(String s)
        {
            try
            {
                String[] ary = Tools.Strings.Split(s, ",");
                String s1 = ary[0];
                String s2 = ary[1];

                Index1 = Int32.Parse(s1);
                Index2 = Int32.Parse(s2);
            }
            catch (Exception)
            { }
        }
    }


}
