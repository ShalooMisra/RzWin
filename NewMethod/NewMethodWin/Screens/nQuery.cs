using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Collections.Generic;
using Tools.Database;

namespace NewMethod
{
    public partial class nQuery : UserControl, ICompleteLoad
    {
        //Public Variables
        public Tools.Database.DataConnection xConnect;
        //Private Variables
        private String CurrentSQL = "";
        private DateTime StartDate;
        private DataTable ResultTable;
        private int ColumnInQuestion = -1;
        private SysNewMethod xSys
        {
            get
            {
                return NMWin.ContextDefault.xSys;
            }
        }

        //Constructors
        public nQuery()
        {
            InitializeComponent();
            throb.BackColor = Color.White;
            txtSQL.Focus();
            cmdExportToExcel.Enabled = false;
        }
        public nQuery(string sql)
        {
            InitializeComponent();
            throb.BackColor = Color.White;
            txtSQL.Focus();
            cmdExportToExcel.Enabled = false;

            CompleteLoad();
            SetSQL(sql);
        }
        //Public Functions
        public void CompleteLoad()
        {
            xConnect = NMWin.Data;
            DoResize();
        }
        public void SetSQL(String strSQL)
        {
            txtSQL.Text = strSQL;
            CurrentSQL = txtSQL.Text;

            switch (GetSQLType(CurrentSQL).ToLower())
            {
                case "select":
                    txtResult.Visible = false;
                    lv.Visible = true;
                    break;
                default:
                    txtResult.Visible = true;
                    lv.Visible = false;
                    break;
            }

            DoResize();
        }
        public void RunSQL(String strSQL)
        {
            CurrentSQL = strSQL;
            if (IsSQLQuery(CurrentSQL))
            {
                lv.Visible = true;
                txtResult.Visible = false;
                lv.Items.Clear();
                lv.Columns.Clear();
            }
            else
            {
                String s = GetSQLType(CurrentSQL);

                if (!NMWin.ContextDefault.xUser.IsDeveloper())
                {
                    NMWin.Leader.Tell("This query is not available.");
                    return;
                }

                if (!NMWin.Leader.AreYouSure("run this " + s + " command"))
                {
                    throb.HideThrobber();
                    cmdRun.Enabled = true;
                    return;
                }

                cmdExportToExcel.Visible = false;
                lv.Visible = false;
                txtResult.Visible = true;
                SetStatus("Running SQL command...");
            }

            CurrentSQL = strSQL;
            throb.ShowThrobber();
            SetStatus("Running...");
            cmdRun.Enabled = false;

            StartDate = DateTime.Now;

            bg.RunWorkerAsync();
        }
        public long RunCommand(String strSQL)
        {
            long a = 0;
            try
            {
                xConnect.Execute(strSQL, ref a);
                return a;
            }
            catch(Exception ex)
            {
                NMWin.Leader.Tell(ex.Message);
                return -2;
            }
        }
        public long RunQuery(String strSQL)
        {
            try
            {
                ResultTable = xConnect.Select(strSQL);
                if (ResultTable == null)
                    return -2;
                else
                    return ResultTable.Rows.Count;
            }
            catch (Exception ex)
            {
                NMWin.Leader.Tell(ex.Message);
                return -2;
            }
        }
        public void ShowDataTable(DataTable d)
        {
            ShowTableColumns(d);
            ShowTableData(d);
        }
        public void ShowTableColumns(DataTable d)
        {
            lv.BeginUpdate();
            lv.Columns.Clear();
            foreach (DataColumn c in d.Columns)
            {
                lv.Columns.Add(c.Caption);
            }
            lv.EndUpdate();
        }
        public void ShowTableData(DataTable d)
        {
            lv.BeginUpdate();
            lv.Items.Clear();
            foreach (DataRow r in d.Rows)
            {
                ListViewItem l = lv.Items.Add(nData.NullFilter_String(r[0]));
                for (int i = 1; i < d.Columns.Count; i++)
                {
                    l.SubItems.Add(nData.NullFilter_String(r[i]));
                }
            }
            lv.EndUpdate();
        }
        public virtual string ExportToHTML()
        {
            if (!IsSQLQuery(txtSQL.Text))
            {
                NMWin.Leader.Tell("This doesn't appear to be a query.");
                return "";
            }
            if (ResultTable == null)
            {
                if (chkSkipShow.Checked)
                {
                    ResultTable = xConnect.Select(txtSQL.Text);
                    if (ResultTable == null)
                        return "";
                }
                else
                {
                    NMWin.Leader.Tell("Please run a query first.");
                    return "";
                }
            }
            string data = nData.ConvertDataTableToHTML(ResultTable);
            string file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + Tools.Strings.GetNewID() + ".html";
            Tools.Files.SaveFileAsString(file, data);
            if (!Tools.Files.FileExists(file))
            {
                NMWin.Leader.Tell("File " + file + " does not exist.");
                return "";
            }
            return file;
        }
        //Private Functions
        private void SetStatus(String s)
        {
            try
            {
                lblStatus.Text = s;
            }
            catch { }
        }
        private bool IsSQLQuery(String strSQL)
        {
            String type = GetSQLType(strSQL);
            return Tools.Strings.StrCmp(type, "select") || Tools.Strings.StrCmp(type, "show");
        }
        private String GetSQLType(String strSQL)
        {
            String s = strSQL.Replace("\r\n", " ").ToLower().Trim();

            s = Tools.Strings.RemoveSqlStrings(s);

            if (s.StartsWith("--") && !NMWin.ContextDefault.xUser.IsDeveloper())
            {
                return "invalid";
            }

            if (s.StartsWith("select ") && s.Contains(" into "))
                return "selectinto";

            return Tools.Strings.ParseDelimit(s, " ", 1);
        }
        private void DoResize()
        {
            try
            {
                //txtResult.Width = split.Panel1.Width -(txtSQL.Left * 2);
                //txtResult.Height = split.Panel1.Height - ((txtSQL.Top * 2) + cmdRun.Height);
                //cmdRun.Top = txtSQL.Bottom - (cmdRun.Height * 2);
                //cmdRun.Height is about the width of the slider bar of the text box
                //cmdRun.Left = split.Panel1.Width - (cmdRun.Width + cmdRun.Height);

                //cmdExportToExcel.Top = cmdRun.Top;
                //cmdExportToExcel.Left = cmdRun.Left - (cmdExportToExcel.Width + 20);

                //cmdExportToCsv.Left = cmdExportToExcel.Left - (cmdExportToCsv.Width + 20);
                //cmdExportToCsv.Top = cmdExportToExcel.Top;

                gb.Left = this.ClientRectangle.Width - gb.Width;
                gb.Top = 0;
                gb.Height = this.ClientRectangle.Height - sb.Height;

                split.Left = 0;
                split.Top = 0;
                split.Width = this.ClientRectangle.Width - gb.Width;
                split.Height = this.ClientRectangle.Height - sb.Height;

            }
            catch (Exception)
            {
            }
        }
        private void SetResult(String s)
        {
            txtResult.Visible = true;
            lv.Visible = false;
            txtResult.Text = s;
        }
        private void CompareTables()
        {
            String t1 = Tools.Strings.ParseDelimit(txtSQL.Text, "|", 1);
            String t2 = Tools.Strings.ParseDelimit(txtSQL.Text, "|", 2);

            if (!Tools.Strings.StrExt(t1) || !Tools.Strings.StrExt(t2))
            {
                SetResult("Please enter the table names separated by '|'.");
                return;
            }

            DataTable dt1 = xConnect.Select("SELECT  column_name, data_type, character_maximum_length FROM information_schema.columns WHERE table_name = '" + t1 + "' ORDER BY column_name");
            //DataTable dt2 = xData.Select("SELECT  column_name, data_type, character_maximum_length FROM information_schema.columns WHERE table_name = '" + t2 + "' ORDER BY column_name");

            //int i1 = 0;
            //int i2 = 0;
            //int max = dt1.Rows.Count;
            //if (dt2.Rows.Count > max)
            //    max = dt2.Rows.Count;

            //ArrayList a

            //for (int i = 0; i < max; i++)
            //{

            //}

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Comparing " + t1 + " with " + t2);
            sb.AppendLine("-----------------");

            ArrayList af = new ArrayList();

            foreach (DataRow r in dt1.Rows)
            {
                String strColumn = nData.NullFilter_String(r["column_name"]);
                int max = Tools.Data.NullFilterInt(r["character_maximum_length"]);
                sb.Append(strColumn + "\t\t" + nData.NullFilter_String(r["data_type"]) + "\t\t" + max.ToString());

                DataTable dt2 = xConnect.Select("SELECT  column_name, data_type, character_maximum_length FROM information_schema.columns WHERE table_name = '" + t2 + "' and column_name = '" + strColumn + "' ORDER BY column_name");

                if (!Tools.Data.DataTableExists(dt2))
                    sb.Append("\t\tmissing in " + t2);
                else
                {
                    af.Add(strColumn);
                    DataRow r2 = dt2.Rows[0];
                    int max2 = Tools.Data.NullFilterInt(r2["character_maximum_length"]);

                    if (max2 != max)
                        sb.Append("\t\tsize difference (" + max2.ToString() + " in " + t2 + ")");
                }

                sb.Append("\r\n");
            }

            String strSQL = "";
            if (af.Count > 0)
                strSQL = "SELECT  column_name, data_type, character_maximum_length FROM information_schema.columns WHERE table_name = '" + t2 + "' and column_name not in (" + nTools.GetIn(af) + ") ORDER BY column_name";
            else
                strSQL = "SELECT  column_name, data_type, character_maximum_length FROM information_schema.columns WHERE table_name = '" + t2 + "' ORDER BY column_name";

            DataTable dt3 = xConnect.Select(strSQL);
            if (Tools.Data.DataTableExists(dt3))
            {
                sb.AppendLine("\r\nMissing from " + t1);

                foreach (DataRow r in dt3.Rows)
                {
                    String strColumn = nData.NullFilter_String(r["column_name"]);
                    sb.AppendLine(strColumn);
                }
            }

            SetResult(sb.ToString());
        }
        //Buttons
        private void cmdRun_Click(object sender, EventArgs e)
        {
            txtResult.Text = "Running...";
            if (optSQL.Checked)
                RunSQL(txtSQL.Text);
            else if (optCompareTables.Checked)
                CompareTables();
        }
        private void cmdExportToExcel_Click(object sender, EventArgs e)
        {
            //if (!IsSQLQuery(txtSQL.Text))
            //{
            //    context.TheLeader.Tell("This doesn't appear to be a query.");
            //    return;
            //}

            //if (ResultTable == null)
            //{
            //    if (chkSkipShow.Checked)
            //    {
            //        ResultTable = xConnect.Select(txtSQL.Text);
            //        if (ResultTable == null)
            //            return;
            //    }
            //    else
            //    {
            //        context.TheLeader.Tell("Please run a query first.");
            //        return;
            //    }
            //}
            //Tools.Excel.ExportTableToExcel(ResultTable, true);
        }
        private void cmdExportToCsv_Click(object sender, EventArgs e)
        {
            if (!IsSQLQuery(txtSQL.Text))
            {
                NMWin.Leader.Tell("This doesn't appear to be a query.");
                return;
            }

            if (ResultTable == null)
            {
                if (chkSkipShow.Checked)
                {
                    ResultTable = xConnect.Select(txtSQL.Text);
                    if (ResultTable == null)
                        return;
                }
                else
                {
                    NMWin.Leader.Tell("Please run a query first.");
                    return;
                }
            }

            String s = "c:\\exports\\";
            if (!Directory.Exists(s))
                Directory.CreateDirectory(s);

            String n = NMWin.Leader.AskForString("Export Name", "export_" + Tools.Strings.GetNewID(), "Export Name");
            if (!Tools.Strings.StrExt(n))
                return;

            if (!s.ToLower().EndsWith(".csv"))
                s += n + ".csv";

            if (File.Exists(s))
            {
                if (!NMWin.Leader.AreYouSure("delete the existing copy of '" + s + "'"))
                    return;
                File.Delete(s);
            }

            long l = 0;
            xConnect.ExportCSV(ResultTable, s, ref l);
            nTools.ExploreFolder("c:\\exports\\");
        }
        private void cmdDataSource_Click(object sender, EventArgs e)
        {
            Tools.Database.DataConnection t = frmDataSources.ChooseConnection(this.ParentForm, xSys);
            if (t == null)
                return;

            String err = "";
            if (!t.ConnectPossible(ref err))
            {
                SetResult("Can't connect: " + err);
                return;
            }

            xConnect = t;
            SetResult("The connection has been switched to " + xConnect.TheKey.ServerName + " / " + xConnect.TheKey.DatabaseName);
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            ResultTable = null;
            SetResult("Cleared.");
        }
        private void cmdExportToHTML_Click(object sender, EventArgs e)
        {
            String file = ExportToHTML();
            if (File.Exists(file))
            {
                NMWin.MainForm.BrowseWebAddress("file://" + file);
            }
        }
        private void sendToMeButton_Click(object sender, EventArgs e)
        {
            if (!IsSQLQuery(txtSQL.Text))
            {
                NMWin.Leader.Tell("This doesn't appear to be a query.");
                return;
            }
            String s = "c:\\exports\\";
            if (!Directory.Exists(s))
                Directory.CreateDirectory(s);
            String n = NMWin.Leader.AskForString("Export Name", "export_" + Tools.Strings.GetNewID(), "Export Name");
            if (!Tools.Strings.StrExt(n))
                return;
            if (!s.ToLower().EndsWith(".xlsx"))
                s += n + ".xlsx";
            if (File.Exists(s))
            {
                if (!NMWin.Leader.AreYouSure("delete the existing copy of '" + s + "'"))
                    return;
                File.Delete(s);
            }
            SetStatus("Querying...");
            try
            {
                ResultTable = xConnect.Select(txtSQL.Text);
            }
            catch (Exception ex)
            {
                NMWin.Leader.Error(ex);
                return;
            }
            SetStatus("Exporting...");
            try
            {
                List<String> captions = new List<string>();
                List<Tools.Database.FieldType> types = new List<Tools.Database.FieldType>();
                foreach (DataColumn c in ResultTable.Columns)
                {
                    captions.Add(c.Caption);

                    if (c.DataType == typeof(Int32))
                        types.Add(Tools.Database.FieldType.Int32);
                    else if (c.DataType == typeof(Int64))
                        types.Add(Tools.Database.FieldType.Int64);
                    else if (c.DataType == typeof(DateTime))
                        types.Add(Tools.Database.FieldType.DateTime);
                    else if (c.DataType == typeof(Double))
                        types.Add(Tools.Database.FieldType.Double);
                    else if (c.DataType == typeof(Boolean))
                        types.Add(Tools.Database.FieldType.Boolean);
                    else
                        types.Add(Tools.Database.FieldType.String);
                }
                Tools.Excel.DataTableToExcel(s, ResultTable, captions, types);
            }
            catch (Exception ex)
            {
                NMWin.Leader.Error(ex);
                return;
            }
            FileInfo f = new FileInfo(s);
            if (f.Length > (1024 * 1024 * 10)) //10MB
            {
                if (!NMWin.Leader.AreYouSure("send this file when its size is " + Tools.Files.SpaceFormat(f.Length)))
                    return;
            }
            string email = NMWin.Leader.AskForString("Please enter the email address to send this to", "mike@recognin.com");
            if (!Tools.Strings.StrExt(email))
                return;
            if (!Tools.Email.IsEmailAddress(email))
                return;
            if (!NMWin.Leader.AreYouSure("export send this list to " + email))
                return;
            Tools.nEmailMessage m = new Tools.nEmailMessage();
            m.SetNotifyServer("RzNote", "notify@recognin.com", "N0tify");
            m.ToAddress = email;
            m.Subject = "Query Result : " + Tools.Strings.Left(n, 50);
            m.HTMLBody = "Query Result<br/><br/>" + HttpUtility.HtmlEncode(txtSQL.Text);
            m.AddAttachment(s);
            SetStatus("Sending...");
            String err = "";
            if (!m.Send(ref err))
            {
                NMWin.Leader.Error("Not sent: " + err);
                SetStatus("Not sent: " + err);
            }
            else
                SetStatus("Sent " + s + " size " + Tools.Files.SpaceFormat(f.Length));
        }
        private void cmdSaveToTable_Click(object sender, EventArgs e)
        {
            if (!Tools.Data.DataTableExists(ResultTable))
            {
                NMWin.ContextDefault.TheLeader.Tell("You must run a query before saving.");
                return;
            }
            string table = NMWin.ContextDefault.TheLeader.AskForString("Please enter the new table name below.", "temp_" + Tools.Strings.GetNewID() + "_table");
            if (!Tools.Strings.StrExt(table))
                return;
            if (NMWin.ContextDefault.TableExists(table))
            {
                NMWin.ContextDefault.TheLeader.Tell("This table already exists.");
                return;
            }
            ((DataConnectionSqlServer)NMWin.ContextDefault.TheData.TheConnection).ImportDataTable(ResultTable, table);
            NMWin.ContextDefault.TheLeader.Tell("Done.");
        }
        //Control Events
        private void nQuery_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void split_SplitterMoved(object sender, SplitterEventArgs e)
        {
            DoResize();
        }
        private void chkSkipShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSkipShow.Checked)
            {
                cmdExportToCsv.Visible = true;
                cmdExportToExcel.Visible = true;
                cmdExportToHTML.Visible = true;
                cmdSaveToTable.Visible = true;
            }
        }
        private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnInQuestion = e.Column;
            mnuColumn.Show(System.Windows.Forms.Cursor.Position);
        }
        //Background Workers
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            if (IsSQLQuery(CurrentSQL))
            {
                e.Result = RunQuery(CurrentSQL);
            }
            else
            {
                e.Result = RunCommand(CurrentSQL);
            }
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TimeSpan t = DateTime.Now.Subtract(StartDate);
            switch ((Int64)e.Result)
            {
                case -2:
                    txtResult.Text = "Error";
                    SetStatus("Error");
                    break;
                case -1:
                    txtResult.Text = "Command complete in " + Tools.Dates.FormatHMS(t.TotalSeconds);
                    SetStatus("Command completein " + Tools.Dates.FormatHMS(t.TotalSeconds));
                    break;
                default:
                    long a = (Int64)e.Result;
                    
                    if (IsSQLQuery(CurrentSQL))
                    {
                        //txtResult.Text = "Done: " + Tools.Number.LongFormat(a) + " returned in " + Tools.Dates.FormatHMS(t.TotalSeconds);
                        SetStatus(Tools.Number.LongFormat(a) + " returned in " + Tools.Dates.FormatHMS(t.TotalSeconds));

                        if (ResultTable == null)
                            return;

                        bool shown = false;
                        if (ResultTable.Rows.Count == 1)
                        {
                            if (ResultTable.Columns.Count == 1)
                            {
                                //show the scalar value as text
                                cmdExportToExcel.Visible = false;
                                lv.Visible = false;
                                txtResult.Visible = true;

                                Object o = ResultTable.Rows[0][0];
                                if (o == null)
                                    txtResult.Text = "<null>";
                                else
                                    txtResult.Text = o.ToString();

                                shown = true;
                            }
                        }

                        if( !shown )
                            ShowDataTable(ResultTable);
    
                        cmdExportToExcel.Visible = true;
                        cmdExportToCsv.Visible = true;
                        cmdExportToHTML.Visible = true;
                        cmdSaveToTable.Visible = true;
                    }
                    else
                    {
                        txtResult.Text = "Done: " + Tools.Number.LongFormat(a) + " affected in " + Tools.Dates.FormatHMS(t.TotalSeconds);
                        SetStatus(Tools.Number.LongFormat(a) + " affected in " + Tools.Dates.FormatHMS(t.TotalSeconds));
                    }
                    break;
            }
            throb.HideThrobber();
            cmdRun.Enabled = true;
        }
        //Menus
        private void mnuCopyColumnValues_Click(object sender, EventArgs e)
        {
            if (ColumnInQuestion < 0)
                return;

            StringBuilder sb = new StringBuilder();
            foreach (ListViewItem i in lv.Items)
            {
                sb.AppendLine(i.SubItems[ColumnInQuestion].Text.Trim());
            }

            Tools.FileSystem.PopText(sb.ToString());
        }
        private void toolCopy_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem i = lv.SelectedItems[0];
                String s = "";
                int c = 0;
                foreach (ListViewItem.ListViewSubItem u in i.SubItems)
                {
                    s += lv.Columns[c].Text + ": " + u.Text + "\r\n";
                    c++;
                }
                s = Tools.Strings.KillBlankLines(s);
                try
                {
                    s += "\r\nSystem ID: " + (String)i.Tag;
                }
                catch
                {
                    try
                    {
                        nObjectHandle h = (nObjectHandle)i.Tag;
                        s += "\r\nSystem ID: " + h.unique_id;
                    }
                    catch { }
                }
                Tools.FileSystem.PopText(s);
            }
            catch { }
        }
    }
}
