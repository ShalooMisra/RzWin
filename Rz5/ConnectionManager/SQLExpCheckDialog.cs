using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Net;
using NewMethodx;
using OthersCodex;
using ConnectionManager;

namespace SQLInstallManager
{
    public partial class SQLExpCheckDialog : Form
    {
        private int SmallHeight = 184;
        private int BigHeight = 502;
        private bool EverythingOK = false;
        private string server;
        private string userName;
        private string databaseName;

        public SQLExpCheckDialog()
        {
            InitializeComponent();

            BeginDownload();
        }

        public SQLExpCheckDialog(string server, string userName, string databaseName)
        {
            InitializeComponent();

            this.server = server;
            this.userName = userName;
            this.databaseName = databaseName;
            BeginDownload();
        }

        public void Init()
        {
            Tools.Style.StyleCurrent.IconFormDefault = this.Icon;

            Height = SmallHeight;

            cpServer.Caption = "Check for SQL Server on this computer";
            cpServer.Message = "Rz3 uses the SQL Server program to store information.  To continue with a local installation, SQL Server 2005 (or later) needs to be installed on this computer.  SQL Server Express 2005 is a free version of this software from Microsoft; click the link above to download and install it.";
            cpServer.LinkText = "Install SQL Server 2005 Express [free]";
            cpServer.CompleteLoad();

            cpLocalConnection.Caption = "Test the local information connection";
            cpLocalConnection.Message = "Rz3 needs to connect to this computer's information store.  Be sure that the entered password is correct, and that no software such as Windows Firewall could be preventing the connection.";
            cpLocalConnection.LinkText = "";
            cpLocalConnection.CompleteLoad();

            cpDatabase.Caption = "Check for an Rz3 database on this computer";
            cpDatabase.Message = "Rz3 needs a pre-loaded database to use as an information source.  To download a new pre-loaded database, click the link above.";
            cpDatabase.LinkText = "Download a pre-loaded Rz3 database";
            cpDatabase.CompleteLoad();

            cpConnectExternal.Caption = "Check the information connection";
            cpConnectExternal.Message = "Rz needs to connect to an information source on another computer that has an information source already installed.  Make sure the name of the computer is spelled correctly, and that no software programs such as Windows Firewall or similar are running on the information source computer.";
            //cpConnectExternal.LinkText = "Ping the external computer";
            cpConnectExternal.LinkText = "";
            cpConnectExternal.CompleteLoad();

            this.server = System.Environment.MachineName;
            this.userName = "sa";
            this.databaseName = "Rz3";

            //txtServer.SelectAll();
            SetStatus("");
            ShowHelpBlock();
        }

        private void CheckState()
        {
            //this.Height = BigHeight;
            //gbLocal.Visible = true;
            //gbRemote.Visible = false;

            //txtServer.Enabled = false;
            this.server = Environment.MachineName;

            StartCheckingLocalServer();

            //if (optLocal.Checked)
            //{
            //    //gbLocal.Visible = true;
            //    gbRemote.Visible = false;

            //    txtServer.Enabled = false;
            //    this.server = Environment.MachineName;

            //    StartCheckingLocalServer();
            //}
            //else
            //{
            //    gbLocal.Visible = false;
            //    gbRemote.Visible = true;
            //    txtServer.Enabled = true;

            //    StartCheckingRemoteConnection();
            //}

            //txtUserName.Visible = chkAdvanced.Checked;
            //lblUserName.Visible = txtUserName.Visible;

            //txtDatabaseName.Visible = chkAdvanced.Checked;
            //lblDatabaseName.Visible = txtDatabaseName.Visible;
            CheckShowOpen();
        }

        private void CheckShowOpen()
        {
            if (EverythingOK)
            {
                cmdOpenRz3.Visible = true;
                pic.Visible = true;
                pic.BackgroundImage = il.Images["done"];
                lblComplete.Visible = true;
            }
            else
            {
                cmdOpenRz3.Visible = false;
                lblComplete.Visible = false;
                pic.Visible = false;
            }
        }

        void GetUserName()
        {
            //if (chkAdvanced.Checked)
            //    return txtUserName.Text;
            //else
            //    return "sa";
        }

        void GetDatabaseName()
        {
            //if (chkAdvanced.Checked)
            //    return txtDatabaseName.Text;
            //else
            //    return "Rz3";
        }

        public String[] Split(String strIn, String strSplit)
        {
            return strIn.Split(new String[] { strSplit }, StringSplitOptions.None);
        }

        private void ShowHelpBlock()
        {
            //try
            //{
            //    String s = nTools.DownloadInternetFileAsString("http://www.recognin.com/contact_block.htm");
            //    if (nTools.HasString(s, "mike"))
            //        wb.Navigate("http://www.recognin.com/contact_block.htm");
            //}
            //catch { }
        }

        private void BeginDownload()
        {
            String pass = frmPassword.AskPassword(this);
            if (!nTools.StrExt(pass))
                return;

            txtPassword.Text = pass;

            StartExpressProcess();
        }

        //-----------------------Events-----------------------//
        #region Events

        private void chkAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            CheckState();
        }

        private void ClickOK()
        {
            if (ToolsConnection.ConnectionFileDataSet(this.server, this.userName, txtPassword.Text, this.databaseName))
                CheckState();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            ClickOK();
        }

        private void cpDatabase_LinkClicked()
        {
            RunNextDatabaseProcess();
        }

        private void cmdOpenRz3_Click(object sender, EventArgs e)
        {
            //String strPath = nTools.GetAppPath() + "Peak.exe";
            //Program.Shell(strPath, "");
            //if (nTools.IsDevelopmentMachinePlain())
            //{
            //    nTools.PopText(strPath);
            //}
            //MessageBox.Show("The command to open Rz3 was sent, but depending on your computer's configuration, you may need to open Rz3 from the Start menu instead.");
        }

        //private void cpServer_LinkClicked()
        //{
        //    String pass = frmPassword.AskPassword(this);
        //    if (!nTools.StrExt(pass))
        //        return;

        //    txtPassword.Text = pass;

        //    StartExpressProcess();
        //}

        private void frmConnect_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                case '\n':
                    e.Handled = true;
                    ClickOK();
                    break;
            }
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            String s = "";
            if (TestConnect(ref s, ""))
                MessageBox.Show("Connection success.");
            else
                MessageBox.Show("Connection failed: " + s);
        }
       
        private void pic_Click(object sender, EventArgs e)
        {

        }

        private void lblComplete_Click(object sender, EventArgs e)
        {

        }

        private void cpLocalConnection_Load(object sender, EventArgs e)
        {

        }

        private void lblFromRecognin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String s = NewMethod.Ask.AskString(true, "Please paste the connection info from Recognin here", "", "Connection Info", null);
            if (nTools.StrExt(s))
            {
                if (!nTools.SaveFileAsString(ToolsConnection.ConnectionFileName, s))
                    MessageBox.Show("Save error");
                else
                {
                    ToolsConnection.ConnectionManagerRestart();
                    this.Close();
                }
            }
        }

        private void lblRequstLiveSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String f = nTools.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "RzSupport.exe";
            if (!File.Exists(f))
            {
                if (!nTools.DownloadInternetFile("http://www.recognin.com/RzSupport.exe", f))
                {
                    MessageBox.Show("The live support application could not be downloaded");
                    return;
                }
            }
            nTools.Shell(f);
        }

        private void opt_CheckedChanged(object sender, EventArgs e)
        {
            //if (optRemote.Checked)
            //    this.server = "";

            //CheckState();
        }

        void xClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            SetProgress(e.ProgressPercentage);
        }
        
        void xClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == false && e.Error == null)
            {
                SetProgress(100);
                File.Move(TempExpressExePath, ExpressExePath);
                StartExpressInstall();
            }
            else
            {
                if (e.Cancelled)
                    MessageBox.Show("The SQL Express download was cancelled.");
                else if (e.Error != null)
                    MessageBox.Show("An error occurred during the download: " + e.Error.Message);
            }
        }

        void xDBClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == false && e.Error == null)
            {
                SetProgress(100);
                File.Move(TempDatabasePathZip, DatabasePathZip);
                RunNextDatabaseProcess();
            }
            else
            {
                if (e.Cancelled)
                    MessageBox.Show("The database download was cancelled.");
                else if (e.Error != null)
                    MessageBox.Show("An error occurred during the database download: " + e.Error.Message);
            }
        }

        #endregion Events

        //--------------------File Actions--------------------//
        #region File Actions

        public String OpenFileAsString(String strFile)
        {
            String s;
            try
            {
                System.IO.StreamReader w = new System.IO.StreamReader(strFile);
                s = w.ReadToEnd();
                w.Close();
                return s;
            }
            catch
            {
                return "";
            }
        }

        public bool SaveFileAsString(String strFileName, String strData)
        {
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(strFileName, false);
                file.Write(strData);
                file.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion File Actions

        //-----------------Background Worker------------------//
        #region Background Worker

        private void bgIsInstalled_DoWork(object sender, DoWorkEventArgs e)
        {
            IsLocalServerInstalled = OthersCode.SQLServerTools.Is2K5Installed();

            if (IsLocalServerInstalled)
            {
                String s = "";
                LocalConnectionPassed = TestConnect(ref s, "master");
                LocalConnectionMessage = s;

                if (LocalConnectionPassed)
                {
                    LocalConnectionPassedWDatabase = TestConnect(ref s, "");
                    LocalConnectionMessageWDatabase = s;
                }
            }

        }

        private void bgIsInstalled_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EverythingOK = false;
            cpServer.Visible = true;
            if (IsLocalServerInstalled)
            {
                cpServer.SetState(CheckPointState.Done);
                cpServer.SetExplicitLink(); //to allow for re-downloading and installation
                SetStatus("");

                //see if the local connect passed
                cpLocalConnection.Visible = true;
                if (LocalConnectionPassed)
                {
                    cpLocalConnection.SetState(CheckPointState.Done);
                    SetStatus("");

                    cpDatabase.Visible = true;
                    if (LocalConnectionPassedWDatabase)
                    {
                        cpDatabase.SetState(CheckPointState.Done);
                        SetStatus("");
                        EverythingOK = true;
                        CheckShowOpen();
                    }
                    else
                    {
                        cpDatabase.SetState(CheckPointState.Warning);
                        SetStatus("Please download a pre-loaded Rz3 database.", Color.Red);
                        CheckShowOpen();
                    }
                }
                else
                {
                    cpLocalConnection.SetState(CheckPointState.Warning);
                    SetStatus("Connection failed: " + LocalConnectionMessage, Color.Red);
                    CheckShowOpen();
                }
            }
            else
            {
                cpServer.SetState(CheckPointState.Warning);
                SetStatus("Please install SQL Server Express before continuing.", Color.Red);
                CheckShowOpen();
            }
        }

        private void bgRemoteConnection_DoWork(object sender, DoWorkEventArgs e)
        {
            String s = "";
            RemoteConnectionPassed = TestConnect(ref s, "");
            RemoteConnectionMessage = s;
        }

        private void bgRemoteConnection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cpConnectExternal.Visible = true;
            if (RemoteConnectionPassed)
            {
                SetStatus("");
                cpConnectExternal.SetState(CheckPointState.Done);
                EverythingOK = true;
                CheckShowOpen();
            }
            else
            {
                EverythingOK = false;
                cpConnectExternal.SetState(CheckPointState.Warning);
                SetStatus("Connection failed: " + RemoteConnectionMessage);
            }
        }
        #endregion Background Worker

        //---------------Connection Management----------------//
        #region Connection Management

        private bool TestConnect(ref String status, String strUse)
        {
            String strUser = this.userName;
            //String strUser = "";
            String strDatabase = "";
            if (strUse != "")
                strDatabase = strUse;
            else
                strDatabase = this.databaseName;

            String strConnect = "Provider=SQLOLEDB.1;User Id=" + strUser + ";Password=" + txtPassword.Text + ";Initial Catalog=" + strDatabase + ";Data Source=" + this.server;

            OleDbConnection xConnect;

            try
            {
                xConnect = new OleDbConnection(strConnect);
                xConnect.Open();
                xConnect.Close();
                xConnect.Dispose();
                xConnect = null;
                status = "Success";
                return true;
            }
            catch (Exception e)
            {
                status = e.Message;
                return false;
            }
        }

        bool IsLocalServerInstalled = false;

        bool LocalConnectionPassed = false;
        String LocalConnectionMessage = "";

        bool LocalConnectionPassedWDatabase = false;
        String LocalConnectionMessageWDatabase = "";

        public void StartCheckingLocalServer()
        {
            if (bgIsInstalled.IsBusy)
                return;

            IsLocalServerInstalled = false;
            cpServer.Visible = false;
            cpLocalConnection.Visible = false;
            cpDatabase.Visible = false;
            SetStatus("Checking for SQL Server....", Color.Green);
            bgIsInstalled.RunWorkerAsync();
        }

        public bool RemoteConnectionPassed = false;
        public String RemoteConnectionMessage = "";

        public void StartCheckingRemoteConnection()
        {
            if (bgRemoteConnection.IsBusy)
                return;

            if (!nTools.StrExt(this.server))
                return;

            RemoteConnectionPassed = false;
            cpConnectExternal.Visible = false;
            SetStatus("Checking the connection to " + this.server + "....", Color.Green);
            bgRemoteConnection.RunWorkerAsync();
        }

        #endregion Connection Management

        //-------SQL Server Express Install and Setup---------//
        #region SQL Server Setup

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(@"Cancelling now will terminate your download./r/nClick 'Yes' to cancel or 'No' to continue.",
                            "Cancel Download?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                this.Dispose();
        }

        void StartExpressProcess()
        {
            if (!File.Exists(ExpressExePath))
            {
                StartExpressDownload();
            }
            else
                StartExpressInstall();
        }

        void StartExpressDownload()
        {
            if (File.Exists(TempExpressExePath))
                File.Delete(TempExpressExePath);

            try
            {
                SetStatus("Downloading SQL Server Express...", Color.Green);
                WebClient xClient = new WebClient();
                xClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(xClient_DownloadProgressChanged);
                xClient.DownloadFileCompleted += new AsyncCompletedEventHandler(xClient_DownloadFileCompleted);
                xClient.DownloadFileAsync(new Uri("http://www.recognin.com/InstallFiles/SQLEXPR.EXE", UriKind.Absolute), TempExpressExePath);
            }
            catch
            {
            }
        }

        public String ExpressExePath
        {
            get
            {
                return nTools.GetAppPath() + "SQLEXPR.EXE";
            }
        }

        public String TempExpressExePath
        {
            get
            {
                return nTools.GetAppPath() + "SQLEXPR.EXE.tmp";
            }
        }

        void StartExpressInstall()
        {
            SetStatus("Installing SQL Server Express...", Color.Green);

            EmbeddedInstall EI = new EmbeddedInstall();

            EI.AutostartSQLBrowserService = false;
            EI.AutostartSQLService = true;
            EI.Collation = "SQL_Latin1_General_Cp1_CS_AS";
            EI.DisableNetworkProtocols = false;
            EI.InstanceName = "MSSQLSERVER";
            EI.ReportErrors = true;
            EI.SetupFileLocation = ExpressExePath;
            EI.SqlBrowserPassword = "";
            //EI.SqlDataDirectory = "C:\\Program Files\\Microsoft SQL Server\\";
            //EI.SqlInstallDirectory = "C:\\Program Files\\";
            //EI.SqlInstallSharedDirectory = "C:\\Program Files\\";
            EI.SqlServicePassword = ""; // N/A
            EI.SysadminPassword = txtPassword.Text; //<<Supply a secure sysadmin password>>
            EI.UseSQLSecurityMode = true;

            if (EI.InstallExpress())
                SetStatus("The SQL Server install process was started.", Color.Green);
            else
                SetStatus("There was an error starting the SQL Server install process.", Color.Red);
        }

        public String DatabasePath
        {
            get
            {
                return MainRzPath + "Data\\Rz3_Install.mdf";
            }
        }

        void RunNextDatabaseProcess()
        {
            try
            {

                if (File.Exists(DatabasePath))
                {
                    nData d = new nData();
                    d.target_type = 2;
                    d.server_name = this.server;
                    d.database_name = "master";
                    d.user_name = this.userName;

                    d.user_password = txtPassword.Text;
                    d.SetConnectionString();

                    String s = "";
                    if (!d.CanConnect(ref s))
                    {
                        MessageBox.Show("The local server could not be connected to: " + s);
                        CheckState();
                        return;
                    }

                    String sx = "";
                    SetStatus("Configuring the database...", Color.Green);

                    //if (d.Restore(DatabasePathBak, "Rz3_Install_Data", "Rz3_Install_Log", nTools.GetAppPath(), "Rz3", ref sx))
                    if (d.Attach(MainRzPath + "Data\\Rz3_Install.mdf", MainRzPath + "Data\\Rz3_Install_log.ldf", "Rz3", ref sx))
                    {
                        SetStatus("");
                        CheckState();
                    }
                    else
                    {
                        MessageBox.Show("There was an error configuring the database: " + sx);
                    }
                    return;
                }

                if (File.Exists(DatabasePathZip))
                {
                    //try
                    //{
                    //    if (File.Exists(TempDatabasePathBak))
                    //        File.Delete(TempDatabasePathBak);
                    //}
                    //catch { }

                    SetStatus("Unzipping the database...", Color.Green);
                    if (!nTools.UnZipOneFile(DatabasePathZip, Path.GetDirectoryName(DatabasePath)))
                    {
                        MessageBox.Show("There was an error unzipping the new database.");
                        SetStatus("There was an error unzipping the new database.", Color.Red);
                        return;
                    }

                    //File.Move(TempDatabasePathBak, DatabasePathBak);
                    RunNextDatabaseProcess();
                    return;
                }

                try
                {
                    if (File.Exists(TempDatabasePathZip))
                        File.Delete(TempDatabasePathZip);
                }
                catch { }

                SetStatus("Downloading the pre-loaded database...", Color.Green);

                String DataFolderPath = MainRzPath + "Data\\";
                if (!Directory.Exists(DataFolderPath))
                    Directory.CreateDirectory(DataFolderPath);

                WebClient xClient = new WebClient();
                xClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(xClient_DownloadProgressChanged);
                xClient.DownloadFileCompleted += new AsyncCompletedEventHandler(xDBClient_DownloadFileCompleted);
                xClient.DownloadFileAsync(new Uri("http://www.recognin.com/InstallFiles/Rz3InstallDatabase.zip", UriKind.Absolute), TempDatabasePathZip);
            }
            catch
            {
                ;
            }
        }

        public String MainRzPath
        {
            get
            {
                String s = nTools.GetAppPath();
                if (!s.EndsWith("\\Rz3\\"))
                    s = nTools.GetAppParentPath();
                return s;
            }
        }

        public String TempDatabasePathZip
        {
            get
            {

                return MainRzPath + "Data\\Rz3InstallDatabase.zip.tmp";
            }
        }

        public String DatabasePathZip
        {
            get
            {
                return MainRzPath + "Data\\Rz3InstallDatabase.zip";
            }
        }
        #endregion SQL Server Setup

        //------------------Progress Handler------------------//
        #region Progress Handler

        void SetStatus(String s)
        {
            SetStatus(s, Color.Black);
        }

        void SetStatus(String s, Color c)
        {
            lblStatus.Text = s;
            lblStatus.ForeColor = c;
        }

        delegate void SetProgressHandler(int p);

        void SetProgress(int p)
        {
            try
            {
                Invoke(new SetProgressHandler(ActuallySetProgress), new object[] { p });
            }
            catch { }
        }

        void ActuallySetProgress(int p)
        {
            try
            {
                pb.Value = p;
            }
            catch { }
        }
        #endregion Progress Handler

        //private void cancelButton_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Cancelling now will terminate your download. Are you sure you want to cancel?",
        //                    "Cancel Download?", MessageBoxButtons.YesNo);
        //    if (DialogResult.Yes)
        //        this.Dispose();
        //}



        //public String TempDatabasePathBak
        //{
        //    get
        //    {
        //        return nTools.GetAppPath() + "Rz3InstallDatabase.bak.tmp";
        //    }
        //}

    }
}