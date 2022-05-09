using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public partial class DatabaseManager : UserControl, ICompleteLoad
    {
        DataTable resultset;
        SysNewMethod xSys
        {
            get
            {
                return TheContext.xSys;
            }
        }
        public ContextNM TheContext
        {
            get
            {
                return RzWin.Context;
            }
        }
        public DataConnectionSqlServer CurrentData = null;
        private ArrayList selected = null;
        private String strBackupFile = "";
        private long startdata = 0;
        private long startlog = 0;

        //Constructors
        public DatabaseManager()
        {
            InitializeComponent();
            throb.BackColor = Color.White;
        }
        //Public Functions
        public void CompleteLoad()
        {
            SetData((DataConnectionSqlServer)RzWin.Context.TheData.TheConnection);
            ctlFileName.SetValue(CurrentData.DatabaseName + "_" + System.DateTime.Now.Year.ToString() + "_" + Tools.Strings.Right("00" + System.DateTime.Now.Month.ToString(), 2) + "_" + Tools.Strings.Right("00" + System.DateTime.Now.Day.ToString(), 2) + "_" + Tools.Strings.Right("00" + System.DateTime.Now.Hour.ToString(), 2) + "_" + Tools.Strings.Right("00" + System.DateTime.Now.Minute.ToString(), 2) + "_" + Tools.Strings.Right("00" + System.DateTime.Now.Second.ToString(), 2) + ".bak");
            lblLocation.Text = RzWin.Context.GetSetting("backup_folder");
            if (!Tools.Strings.StrExt(lblLocation.Text))
                lblLocation.Text = "<click to select>";
            else
                lblLocation.Text = Tools.Folder.ConditionFolderName(lblLocation.Text);

            cmdCrucialBackup.Visible = RzWin.Context.xUser.IsDeveloper();
            cmdCrucialRestore.Visible = RzWin.Context.xUser.IsDeveloper();

            DoResize();
        }
        //Private Functions
        private void SetData(DataConnectionSqlServer d)
        {
            CurrentData = d;
            startdata = CurrentData.GetDataFileSizeInK();
            startlog = CurrentData.GetLogFileSizeInK();
            ShowDatabaseStats();
        }
        private void ShowDatabaseStats()
        {

            lblSource.Text = CurrentData.ToString() + "\r\n" + "Initial Data File Size: " + Tools.Number.LongFormat(startdata) + "\r\nCurrent Data File Size: " + Tools.Number.LongFormat(CurrentData.GetDataFileSizeInK()) + "\r\nInitial Log File Size: " + Tools.Number.LongFormat(startlog) + "\r\nCurrent Log File Size: " + Tools.Number.LongFormat(CurrentData.GetLogFileSizeInK());
        }
        private bool CheckData()
        {
            if (CurrentData == null)
            {
                RzWin.Leader.Tell("Please select a data source.");
                return false;
            }
            if (CurrentData == null)
            {
                RzWin.Leader.Tell("This data source ( " + CurrentData.ToString() + ") does not appear to be available.");
                return false;
            }
            return true;
        }
        private void RunAsyncCommand(String s)
        {
            throb.ShowThrobber();
            bg.RunWorkerAsync(s);
        }
        private DataTable GetTempRecordset()
        {
            return CurrentData.GetTableTable();
        }
        private void DoBackup()
        {
            String err = "";
            String s = strBackupFile;
            if (CurrentData.Backup(ref s, ref err))
            {
                RzWin.Logic.MarkConcern(RzWin.Context, "Database_Backup");
                RzWin.Context.SetSettingDateTime("last_full_backup", DateTime.Now);
            }
            if (Tools.Strings.StrExt(err))
                RzWin.Context.TheLeader.Tell("Error: " + err);
            else
                RzWin.Context.TheLeader.TellTemp("Done.");
        }
        private void DoCrucialBackup()
        {
            //RzWin.Leader.StartPopStatus();
            if (RzWin.Logic.DoCrucialBackup(RzWin.Context, CurrentData, strBackupFile))
            {
                RzWin.Logic.MarkConcern(RzWin.Context, "Database_CrucialBackup");
            }
            else
            {
                RzWin.Leader.Tell("The crucial backup failed.");
            }
            //RzWin.Leader.StopPopStatus(true);
        }
        private void SetStatus(String strStatus)
        {
            lblStatusLine.Text = strStatus;
        }
        private void ShowTempTables()
        {
            lvTemp.Items.Clear();
            if (!Tools.Data.DataTableExists(resultset))
            {
                ListViewItem i = lvTemp.Items.Add("No potentially removable tables were found.");
                i.ForeColor = System.Drawing.Color.Gray;
                lblStatus.Text = "No potentially removable tables were found.";
                return;
            }

            lvTemp.BeginUpdate();
            try
            {
                foreach (DataRow r in resultset.Rows)
                {
                    System.Drawing.Color c = System.Drawing.Color.Black;
                    bool b = false;

                    String strTable = nData.NullFilter_String(r["name"]);

                    if (strTable.ToLower().StartsWith("temp_"))
                    {
                        b = true;
                        c = System.Drawing.Color.Blue;
                    }

                    //if (strTable.ToLower().StartsWith("hold_"))
                    //{
                    //    b = true;
                    //    c = System.Drawing.Color.Red;
                    //}

                    if (strTable.ToLower().StartsWith("log_report_"))
                    {
                        b = true;
                        c = System.Drawing.Color.Green;
                    }

                    if (strTable.ToLower().StartsWith("log_summary_"))
                    {
                        b = true;
                        c = System.Drawing.Color.Green;
                    }

                    if (strTable.ToLower().StartsWith("log_orders_"))
                    {
                        b = true;
                        c = System.Drawing.Color.Green;
                    }

                    if (strTable.ToLower().StartsWith("log_dealdetail_"))
                    {
                        b = true;
                        c = System.Drawing.Color.Green;
                    }

                    if (b)
                    {
                        ListViewItem i = lvTemp.Items.Add(strTable);
                        i.SubItems.Add(nTools.DateFormat(nData.NullFilter_Date(r["crdate"])));
                        i.ForeColor = c;
                    }
                }
            }
            catch (Exception)
            { }
            lvTemp.EndUpdate();
            SetTempStatus();
        }
        private void SetTempStatus()
        {
            lblStatus.Text = Tools.Number.LongFormat(lvTemp.Items.Count) + " Items [ " + Tools.Number.LongFormat(lvTemp.CheckedItems.Count) + " Selected ]";
            cmdDropTemp.Visible = (lvTemp.CheckedItems.Count > 0);
        }
        private void SetAll(bool b)
        {
            foreach (ListViewItem i in lvTemp.Items)
            {
                i.Checked = b;
            }
        }
        private String GetSelectedTables()
        {
            String s = "";
            selected = new ArrayList();
            foreach (ListViewItem i in lvTemp.CheckedItems)
            {
                s += i.Text + "\r\n";
                selected.Add(i.Text);
            }
            return s;
        }
        private void DropSelected()
        {
            foreach (String s in selected)
            {
                CurrentData.DropTable(s);
            }
        }
        private void DoResize()
        {
            try
            {
                gb.Left = 0;
                gb.Top = 0;
                gb.Height = this.ClientRectangle.Height - sb.Height;

                gbBackup.Left = gb.Right;
                gbBackup.Top = 0;

                gbTemp.Left = gb.Right;
                gbTemp.Top = gbBackup.Bottom;
                gbTemp.Height = this.ClientRectangle.Height - (gbTemp.Top + sb.Height);

                lvTemp.Height = gbTemp.ClientRectangle.Height - (lvTemp.Top + 20);
            }
            catch (Exception)
            {
            }
        }
        private void CrucialRestore()
        {
            RzWin.Context.Reorg();

            //if( !RzWin.User.IsDeveloper() )
            //{
            //    RzWin.Leader.ShowNoRight();
            //    return;
            //}

            //String dName = RzWin.Leader.AskForString("Please enter the name of the database to restore from.", "", "Database Name");
            //if( !Tools.Strings.StrExt(dName) )
            //    return;

            //if (Tools.Strings.StrCmp(dName, xSys.xData.database_name))
            //{
            //    RzWin.Leader.Tell("The restore database appears to be the same as the main Rz3 database.");
            //    return;
            //}

            //if( !xSys.xData.DatabaseExists(dName) )
            //{
            //    RzWin.Leader.Tell("The database " + dName + " doesn't appear to exist on the Rz3 server.");
            //    return;
            //}

            //n_data_target t = new n_data_target(2, xSys.xData.server_name, dName, xSys.xData.user_name, xSys.xData.user_password);
            //nData d = new nData(t);
            //String sx = "";
            //if (!d.CanConnect(ref sx))
            //{
            //    RzWin.Leader.Tell("This data source doesn't appear to be available: " + sx);
            //    return;
            //}

            //if (nData.IsDefinitlelySameDatabase(xSys.xData, d))
            //{
            //    RzWin.Leader.Tell("The restore database appears to be the same as the main Rz3 database.");
            //    return;
            //}

            //ArrayList tables = d.GetTableArray();
            //tables.Sort();
            //StringBuilder sb = new StringBuilder();
            //foreach (String s in tables)
            //{
            //    sb.AppendLine(s);
            //}

            //Tools.FileSystem.PopText(sb.ToString());

            //if (!RzWin.Leader.AreYouSure("non-reversibly replace all of the tables listed here from " + d.server_name + "/" + d.database_name))
            //    return;


            //RzWin.Leader.StartPopStatus("Restoring...");
            //foreach (String s in tables)
            //{
            //    CrucialRestoreTable(s, d);
            //}
            //RzWin.Leader.Comment("Done.");
            //RzWin.Leader.StopPopStatus(true);
        }
        private void CrucialRestoreTable(String strTable, DataConnectionSqlServer d)
        {
            if (RzWin.Context.Data.TableExists(strTable))
            {
                RzWin.Leader.Comment("Archiving previous copy of " + strTable + "...");

                if (!RzWin.Context.Data.Connection.RenameTable(strTable, strTable + "_replaced_" + nTools.GetDateTimeString()))
                {
                    RzWin.Leader.Comment("Rename failed on " + strTable + ": this table was not restored.");
                    return;
                }
            }

            RzWin.Leader.Comment("Restoring " + strTable + "...");
            RzWin.Context.Execute("select * into " + strTable + " from " + d.DatabaseName + ".dbo." + strTable);
        }
        //Buttons
        private void cmdLoadTempTables_Click(object sender, EventArgs e)
        {
            lvTemp.Items.Clear();
            lblStatus.Text = "Loading potentially removable tables...";
            if (!CheckData())
                return;
            
            RunAsyncCommand("fill_temp");
        }
        private void cmdChooseSource_Click(object sender, EventArgs e)
        {
            RzWin.Context.Reorg();
            //n_data_target t = NewMethod.frmDataSources.Choose(this.ParentForm, xSys);
            //if (t == null)
            //    return;

            //String s = "";
            //nData d = new nData(t);
            //if( !d.CanConnect(ref s) )
            //{
            //    RzWin.Leader.Tell("This data source doesn't appear to be available: " + s);
            //    return;
            //}
            //SetData(d);
        }
        private void cmdAll_Click(object sender, EventArgs e)
        {
            SetAll(true);
        }
        private void cmdNone_Click(object sender, EventArgs e)
        {
            SetAll(false);
        }
        private void cmdDropTemp_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("continue and permanently delete these tables"))
                return;

            RzWin.Leader.Tell("The tables in this list are only considered 'potentially removable' due to features of their table names like temp_ and other prefixes.  This DOES NOT mean that they can be removed.  DO NOT CONTINUE unless you are sure that the tables you've selected should be permanently deleted.");

            String s = GetSelectedTables();
            if (s.Length > 600)
                s = Tools.Strings.Left(s, 600) + "\r\n[and others]";
            if (!RzWin.Leader.AreYouSure("permanently delete these " + Tools.Number.LongFormat(selected.Count) + " table(s):\r\n\r\n" + s))
                return;

            SetStatus("Deleting...");
            RunAsyncCommand("delete_selected");
        }
        private void cmdBackup_Click(object sender, EventArgs e)
        {
            if (Tools.Strings.HasString(lblLocation.Text, "<click to select>"))
            {
                TheContext.TheLeader.TellTemp("Please select both a backup file and location.");
                return;
            }

            if (!RzWin.Leader.AreYouSure("start the backup process now"))
                return;

            strBackupFile = Tools.Folder.ConditionFolderName(lblLocation.Text) + ctlFileName.GetValue_String();
            SetStatus("Backing up to " + strBackupFile);
            RunAsyncCommand("backup");
        }
        private void cmdShrink_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("start the shrinking now"))
                return;

            SetStatus("Shrinking...");
            RunAsyncCommand("shrink");
        }
        private void cmdReindex_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("start the indexing now"))
                return;

            SetStatus("Reindexing...");
            RunAsyncCommand("reindex");
        }
        private void cmdTruncate_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("start the log truncation now"))
                return;

            SetStatus("Truncating...");
            RunAsyncCommand("truncate_log");
        }
        private void cmdCrucialBackup_Click(object sender, EventArgs e)
        {
            if (Tools.Strings.HasString(lblLocation.Text, "<click to select>"))
            {
                TheContext.TheLeader.TellTemp("Please select both a backup file and location.");
                return;
            }

            if (!RzWin.Leader.AreYouSure("start the crucial backup process now"))
                return;

            strBackupFile = Tools.Folder.ConditionFolderName(lblLocation.Text) + ctlFileName.GetValue_String();
            SetStatus("Backing up crucial table to " + strBackupFile);
            RunAsyncCommand("crucialbackup");
        }
        private void cmdCrucialRestore_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("continue with the non-reversible process of replacing the live critical Rz3 information with data from another database"))
                return;

            CrucialRestore();
        }
        private void cmdDropIndexes_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("drop the indexes now"))
                return;
            SetStatus("Dropping Indexes...");
            RunAsyncCommand("dropindex");
        }
        private void cmdCreateIndexes_Click(object sender, EventArgs e)
        {
            SetStatus("Creating Indexes...");
            RunAsyncCommand("createindex");
        }
        //Control Events
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            switch ((String)e.Argument)
            {
                case "fill_temp":
                    resultset = GetTempRecordset();
                    e.Result = e.Argument;
                    break;
                case "delete_selected":
                    DropSelected();
                    resultset = GetTempRecordset();
                    RzWin.Logic.MarkConcern(RzWin.Context, "Database_RemoveTempTables");
                    e.Result = "fill_temp";
                    break;
                case "shrink":
                    try { CurrentData.Shrink(); }
                    catch { RzWin.Logic.MarkConcern(RzWin.Context, "Database_Shrink"); }
                    break;
                case "createindex":
                    RzWin.Context.Reorg();    
                //RzWin.Logic.MakeRz3IndexesExist();
                    break;
                case "reindex":
                    if( CurrentData.Reindex() )
                        RzWin.Logic.MarkConcern(RzWin.Context, "Database_Reindex");
                    break;
                case "dropindex":
                    RzWin.Context.Reorg();    
                    //RzWin.Logic.RemoveRz3Indexes(xSys.xData);
                    //RzWin.Logic.MarkConcern("Database_DropIndexes");
                    break;
                case "backup":
                    DoBackup();
                    break;
                case "crucialbackup":
                    DoCrucialBackup();
                    break;
                case "truncate_log":
                    CurrentData.TruncateLog();
                    RzWin.Logic.MarkConcern(RzWin.Context, "Database_TruncateLog");
                    break;
            }
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch ((String)e.Result)
            {
                case "fill_temp":
                    ShowTempTables();
                    break;
                case "delete_selected":
                    break;
                case "backup":
                    Tools.Files.OpenFileInDefaultViewer(lblLocation.Text);
                    break;
                case "truncate_log":
                case "shrink":
                case "reindex":
                    ShowDatabaseStats();
                    break;
            }
            ShowDatabaseStats();
            throb.HideThrobber();
            SetStatus("Done.");
        }
        private void lvTemp_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            SetTempStatus();
        }
        private void lblLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String s = "";
            if (ToolsWin.Keyboard.GetControlKey())
                s = RzWin.Leader.AskForString("Folder", "c:\\backup\\", "Folder");
            else
                s = ToolsWin.FileSystem.ChooseAFolder(s);
            if (!Tools.Strings.StrExt(s))
                return;
            s = Tools.Folder.ConditionFolderName(s);
            if (!System.IO.Directory.Exists(s))
                return;
            lblLocation.Text = s;
            RzWin.Context.SetSetting("backup_folder", s);
        }
        private void DatabaseManager_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
