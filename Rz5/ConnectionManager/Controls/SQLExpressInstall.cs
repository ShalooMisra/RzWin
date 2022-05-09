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
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Net;
//using ICSharpCode;
using NewMethodx;
using OthersCodex;
using ConnectionManagerCore;

namespace ConnectionManager
{
    public partial class SQLExpressInstall : ConnectionManagerPanel
    {
        //Private Delegates
        private delegate void SetProgressHandler(int p);
        private delegate void SetStatusHandler(string s, Color c);
        //Private Variables
        private const string databaseName = "Rz4";
        private string server = "";
        private string userName = "sa";
        private const string password = "rzdbp@55w0rd";
        private WebClient Client;
        private BackgroundWorker bgUnzipWorker;
        private BackgroundWorker bgExpressInstall;
        private BackgroundWorker bgIsRunning;
        private bool configured = false;
        private InstallStep step;
        private bool isRunning = false;

        //Constructors
        public SQLExpressInstall()
        {
            InitializeComponent();
            this.configured = false;
            //if (defaultSQLInstance)
            //    this.server = SystemInformation.ComputerName;
            //else
                this.server = SystemInformation.ComputerName + "\\" + ToolsConnection.RzMSSqlInstanceName;
            SetStatus("Checking your installation...", Color.Green);
            CheckIsRunning();
            EvaluateInstall();
        }

        //Private Functions
        private void CheckIsRunning() 
        {
            bgIsRunning = new BackgroundWorker();
            bgIsRunning.DoWork += new DoWorkEventHandler(this.bgIsRunning_DoWork);
            bgIsRunning.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgIsRunning_RunWorkerCompleted);
            if(!bgIsRunning.IsBusy)
                bgIsRunning.RunWorkerAsync();
        }
        private void ConfigureCustomDB()
        {
            if (!File.Exists(ToolsConnection.DatabasePath))
            {
                MessageBox.Show("The Rz database has not been downloaded");
                return;
            }
            //SetStatus("Configuring the database...", Color.Green);

            nData d = new nData();
            d.target_type = 2;
            d.server_name = this.server;
            d.database_name = "master";
            d.user_name = this.userName;

            d.user_password = password;
            d.SetConnectionString();

            String s = "";
            if (!d.CanConnect(ref s))
            {
                MessageBox.Show("Could not connect to the local server: " + s);
                //SetStatus("Server connection error.", Color.Red);
                return;
            }

            String sx = "";

            if (!d.Attach(ToolsConnection.DatabasePath, "", databaseName, ref sx))  //ToolsConnection.DatabasePathLog  switched to single file 2011_06_05
            {
                MessageBox.Show("There was an error configuring the database: " + sx);
                return;
            }

            if (TestConnectRz())
            {
                ToolsConnection.ConnectionFileDataSet(this.server, this.userName, password, databaseName);
                SetStatus("");
                this.configured = true;
            }
            else
            {
                MessageBox.Show("There was an error configuring the database: " + sx);
            }
            //}
        }
        private void DownloadCustomDB()
        {
            ToolsConnection.ConnectionFolderMakeExist();
            //if (!Directory.Exists(this.DataFolderPath))
            //    Directory.CreateDirectory(this.DataFolderPath);
            try
            {
                if (!File.Exists(ToolsConnection.DatabasePath) && File.Exists(ToolsConnection.DatabasePathZip))
                {
                    this.bgUnzipWorker = new BackgroundWorker();
                    this.bgUnzipWorker.WorkerReportsProgress = true;
                    this.bgUnzipWorker.DoWork += new DoWorkEventHandler(this.bgUnzipWorker_DoWork);
                    this.bgUnzipWorker.ProgressChanged += new ProgressChangedEventHandler(this.bgUnzipWorker_ProgressChanged);
                    this.bgUnzipWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgUnzipWorker_RunWorkerCompleted);
                    this.bgUnzipWorker.RunWorkerAsync();
                }

                if (!File.Exists(ToolsConnection.DatabasePathZip))
                {
                    SetStatus("Downloading the pre-loaded database...", Color.Green);

                    if (File.Exists(ToolsConnection.TempDatabasePathZip))
                        File.Delete(ToolsConnection.TempDatabasePathZip);

                    WebClient Client = new WebClient();
                    Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
                    Client.DownloadFileCompleted += new AsyncCompletedEventHandler(DBClient_DownloadFileCompleted);
                    Client.DownloadFileAsync(new Uri(ToolsConnection.RzWebsiteFolderUrl + ToolsConnection.RzDBZipFile, UriKind.Absolute), ToolsConnection.TempDatabasePathZip);
                }
            }
            catch (Exception e)
            {
               MessageBox.Show("Download error: " + ToolsConnection.RzWebsiteFolderUrl + ToolsConnection.RzDBZipFile + "\r\n" + ToolsConnection.TempDatabasePathZip + "\r\n\r\n" + e.Message);
            }
        }
        private void EvaluateInstall()
        {
            SetProgress(0);
            {
                EnableNextButton(true);
                if (this.configured)
                {
                    this.step = InstallStep.Complete;
                }
                else
                {
                    //If the sqlexpress.exe assembly isn't present, download it
                    if (!File.Exists(ToolsConnection.ExpressExePath) && !TestConnectMaster())
                    {
                        this.step = InstallStep.Step1;
                        goto ShowSteps;
                    }
                    //If the sqlexpress.exe is present, but an Rz instance isn't installed, run the setup
                    else if (!EmbeddedInstall.IsRzExpressInstalled() && !this.isRunning)
                    {
                        this.step = InstallStep.Step2;
                        goto ShowSteps;
                    }
                    //If the custom db hasn't be setup, download and unzip it.
                    else if (!File.Exists(ToolsConnection.DatabasePath))
                    {
                        this.step = InstallStep.Step3;
                        goto ShowSteps;
                    }
                    //If the cutom db hasn't been configured, set it up.
                    else if (!TestConnectRz())  // || !ToolsConnection.ConnectionFileExists
                    {
                        this.step = InstallStep.Step4;
                        goto ShowSteps;
                    }
                    else 
                    {
                        ToolsConnection.ConnectionFileDataSet(server, userName, password, databaseName);
                        this.configured = true; 
                        EvaluateInstall();
                    }
                }
            ShowSteps:
                ShowStep();                
            }
        }
        private void InitUn()
        {
            try
            {
                InitUnWebClient();
                if (File.Exists(ToolsConnection.TempExpressExePath))
                    File.Delete(ToolsConnection.TempExpressExePath);
                if (File.Exists(ToolsConnection.TempDatabasePathZip))
                    File.Delete(ToolsConnection.TempDatabasePathZip);
            }
            catch { }
        }
        private void InitUnWebClient()
        {
            try
            {
                if (Client != null)
                {
                    Client.CancelAsync();
                    Client.Dispose();
                    Client = null;
                }
            }
            catch { }
        }
        private void PauseProcess()
        {
            EvaluateInstall();
            this.EnableNextButton(true);
            SetStatus(lblStatus.Text + ". Click 'Next' to continue.", Color.Green);
        }
        private void ShowStep()
        {
            string next = " Click 'Next' to continue.";
            switch (this.step)
            {
                case InstallStep.Step1:
                    {
                        SetStatus("Rz needs to download Microsoft SQL Server Express 2008." + next, Color.Green);
                        break;
                    }
                case InstallStep.Step2:
                    {
                        SetStatus("To install the server, click 'Next'.", Color.Green);
                        //ClickNext();
                        break;
                    }
                case InstallStep.Step3:
                    {
                        UpdateCheckList(this.pictureBox1, this.lblServerInstalled);
                        if (!File.Exists(ToolsConnection.DatabasePathZip))
                            SetStatus("Click 'Next' to download the custom database.", Color.Green);
                        else
                            SetStatus("Click 'Next' to unzip the database.", Color.Green);
                        //ClickNext();
                        break;
                    }
                case InstallStep.Step4:
                    {
                        UpdateCheckList(this.pictureBox1, this.lblServerInstalled);
                        UpdateCheckList(this.pictureBox2, this.lblCustomDBInstalled);
                        SetStatus("The custom database needs configuration." + next, Color.Green);
                        //ClickNext();
                        break;
                    }
                case InstallStep.Complete:
                    {
                        UpdateCheckList(this.pictureBox1, this.lblServerInstalled);
                        UpdateCheckList(this.pictureBox2, this.lblCustomDBInstalled);
                        UpdateCheckList(this.pictureBox3, this.lblConfigured);
                        SetStatus("Installation complete. Click 'Next' to launch Rz.", Color.Green);
                        SetProgress(100);
                        CancelEnable(false);
                        break;
                    }
                default:
                    break;
            }
        }

        void CancelEnable(bool enabled)
        {
            cancelButton.Enabled = enabled;
        }

        //void NextEnable(bool enabled)
        //{
        //    nextButton.Enabled = enabled;
        //}

        private void StartExpressDownload()
        {
            ToolsConnection.ConnectionFolderMakeExist();

            if (File.Exists(ToolsConnection.TempExpressExePath))
                File.Delete(ToolsConnection.TempExpressExePath);

            try
            {
                SetStatus("Downloading SQL Server Express...", Color.Green);

                String bilge = @"c:\bilge\SQLEXPR.EXE";
                if (File.Exists(bilge))
                {
                    File.Copy(bilge, ToolsConnection.TempExpressExePath);
                    SetProgress(100);
                    File.Move(ToolsConnection.TempExpressExePath, ToolsConnection.ExpressExePath);
                    SetStatus("SQL Server download complete.", Color.Green);
                    EvaluateInstall();
                }
                else
                {
                    this.Client = new WebClient();
                    this.Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
                    this.Client.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
                    this.Client.DownloadFileAsync(new Uri(ConnectionManager.strURL, UriKind.Absolute), ToolsConnection.TempExpressExePath);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Download Error " + ConnectionManager.strURL + "\r\n" + ToolsConnection.TempExpressExePath + "\r\n\r\n" + e.Message);
            }

        }
        private void StartExpressInstall()
        {
            SetStatus("Installing SQL Server Express...", Color.Green);
            EmbeddedInstall EI = new EmbeddedInstall();
            EI.AutostartSQLBrowserService = false;
            EI.AutostartSQLService = true;
            EI.Collation = "SQL_Latin1_General_CP1_CI_AS";
            //EI.DisableNetworkProtocols = false;
            EI.InstanceName = ToolsConnection.RzMSSqlInstanceName;
            EI.ReportErrors = true;
            EI.SetupFileLocation = ToolsConnection.ExpressExePath;
            //EI.SqlBrowserPassword = "";
            EI.SqlServicePassword = ""; // N/A
            EI.SqlAgentServicePassword = ""; // N/A
            EI.SqlAdminPassword = ""; // N/A
            EI.SysadminPassword = password; //<<Supply a secure sysadmin password>>
            EI.UseSQLSecurityMode = true;
            if (!EI.InstallExpress(ToolsConnection.ExpressExePath))
                SetStatus("There was an error during the SQL Server installation.", Color.Red);
        }
        private bool TestConnectRz()
        {
            return TestConnect(databaseName);
        }
        private bool TestConnectMaster()
        {
            return TestConnect("master");
        }
        private bool TestConnect(String db)
        {
            String strConnect = "Provider=SQLOLEDB.1;User Id=" + "sa" + ";Password=" + password + ";Initial Catalog=" + db + ";Data Source=" + this.server + ";Connect Timeout=2";

            OleDbConnection xConnect;

            try
            {
                xConnect = new OleDbConnection(strConnect);
                xConnect.Open();
                xConnect.Close();
                xConnect.Dispose();
                xConnect = null;
                return true;
            }
            catch
            {
                return false;
                //MessageBox.Show(e.Message);
            }
            //}
            //return !this.tmout;
        }
        private void UnzipCustomDB()
        {
            try
            {
                if (!Tools.Zip.UnZipOneFile(ToolsConnection.DatabasePathZip, ToolsConnection.ConnectionFolderName))
                {
                    DialogResult result = MessageBox.Show("There was an error unzipping the new database. You can delete the zipped database and download it again without losing any data. If you would like to delete the file, click 'Yes'. Click 'No' to try unzipping again.", "Decompression Error", MessageBoxButtons.OKCancel);
                    SetStatus("There was an error unzipping the new database.", Color.Red);
                    if (result == DialogResult.Yes)
                        File.Delete(ToolsConnection.DatabasePathZip);
                    EvaluateInstall();
                }
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
        }
        private void UpdateCheckList(PictureBox picBox, Label lbl)
        {
            try
            {
                picBox.BackgroundImageLayout = ImageLayout.Stretch;
                picBox.BackgroundImage = Image.FromFile(Tools.FileSystem.GetAppPath() + "Checkmark.jpg");
            }
            catch { picBox.BackColor = Color.Green; }

            picBox.Show();
            lbl.ForeColor = Color.Black;
        }
        private void ActuallySetProgress(int p)
        {
            try
            {
                pb.Value = p;
            }
            catch { }
        }
        private void SetProgress(int p)
        {
            try
            {
                Invoke(new SetProgressHandler(ActuallySetProgress), new object[] { p });
            }
            catch { }
        }
        private void SetStatus(String s)
        {
            SetStatus(s, Color.Black);
        }
        private void SetStatus(String s, Color c)
        {
            if (lblStatus.InvokeRequired)
                lblStatus.Invoke(new SetStatusHandler(ActuallySetStatus), new object[] { s, c });
            else
                ActuallySetStatus(s, c);
        }
        private void ActuallySetStatus(String s, Color c)
        {
            lblStatus.Text = s;
            lblStatus.ForeColor = c;
        }
        //Buttons
        protected override void nextButton_Click(object sender, EventArgs e)
        {
            ClickNext();
        }

        void ClickNext()
        {
            EnableNextButton(false);
            SetStatus("");
            switch (this.step)
            {
                case InstallStep.Step1:
                    {
                        StartExpressDownload();
                        break;
                    }
                case InstallStep.Step2:
                    {
                        EnableNextButton(false);
                        bgExpressInstall = new BackgroundWorker();
                        bgExpressInstall.DoWork += new DoWorkEventHandler(this.bgExpressInstall_DoWork);
                        bgExpressInstall.ProgressChanged += new ProgressChangedEventHandler(this.bgExpressInstall_ProgressChanged);
                        bgExpressInstall.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgExpressInstall_RunWorkerCompleted);
                        bgExpressInstall.RunWorkerAsync();
                        break;
                    }
                case InstallStep.Step3:
                    {
                        DownloadCustomDB();
                        break;
                    }
                case InstallStep.Step4:
                    {
                        bgExpressInstall = new BackgroundWorker();
                        bgExpressInstall.DoWork += new DoWorkEventHandler(this.bgExpressInstall_DoWork);
                        bgExpressInstall.ProgressChanged += new ProgressChangedEventHandler(this.bgExpressInstall_ProgressChanged);
                        bgExpressInstall.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgExpressInstall_RunWorkerCompleted);
                        bgExpressInstall.RunWorkerAsync();
                        break;
                    }
                case InstallStep.Complete:
                    {
                        String peak = "";
                        try
                        {
                            peak = Tools.FileSystem.GetAppParentPath() + "Peak.exe";
                            Tools.FileSystem.Shell(peak);
                            
                            //ProcessStartInfo info = new ProcessStartInfo();
                            //info.FileName = ;
                            //Process rz = new Process();
                            //rz.Start();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message + "\r\n\r\n" + peak);
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        protected override void cancelButton_Click(object sender, EventArgs e)
        {
            if (this.step != InstallStep.Complete)
            {
                DialogResult dialogResult = MessageBox.Show("Cancelling now will terminate installation. " +
                                                            "Click 'Yes' to cancel or 'No' to continue.",
                                                            "Cancel Download?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    InitUnWebClient();
                    this.ParentForm.Dispose();
                }
            }
            else
                this.Dispose();
        }
        //Background Workers
        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == false && e.Error == null)
            {
                SetProgress(100);
                File.Move(ToolsConnection.TempExpressExePath, ToolsConnection.ExpressExePath);
                SetStatus("SQL Server download complete.", Color.Green);
            }
            else
            {
                if (e.Cancelled)
                    MessageBox.Show("The SQL Express download was cancelled.");
                else if (e.Error != null)
                    MessageBox.Show("An error occurred during the download: " + e.Error.Message);
            }
            EvaluateInstall();
        }
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            SetProgress(e.ProgressPercentage);
        }
        private void DBClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == false && e.Error == null)
            {
                SetProgress(100);
                SetStatus("Database download completed.", Color.Green);
                File.Move(ToolsConnection.TempDatabasePathZip, ToolsConnection.DatabasePathZip);
            }
            else
            {
                if (e.Cancelled)
                    MessageBox.Show("The database download was cancelled.");
                else if (e.Error != null)
                    MessageBox.Show("An error occurred during the database download: " + e.Error.Message);
            }
            EvaluateInstall();
        }
        private void bgExpressInstall_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableNextButton(true);
            EvaluateInstall();
        }
        private void bgExpressInstall_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetProgress(e.ProgressPercentage);
        }
        private void bgExpressInstall_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.step == InstallStep.Step2)
                StartExpressInstall();
            else if (this.step == InstallStep.Step4)
                ConfigureCustomDB();
        }
        private void bgIsRunning_DoWork(object sender, DoWorkEventArgs e)
        {
            this.isRunning = EmbeddedInstall.IsRzExpressRunning();
            System.Threading.Thread.Sleep(2000);
        }
        private void bgIsRunning_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this.isRunning)
                bgIsRunning.RunWorkerAsync();
            else
                EvaluateInstall();
        }
        private void bgUnzipWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetProgress(100);
            SetStatus("Files unzipped successfully.", Color.Green);
            EvaluateInstall();
        }
        private void bgUnzipWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetProgress(e.ProgressPercentage);
        }
        private void bgUnzipWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SetStatus("Unzipping the database...", Color.Green);
            UnzipCustomDB();
        }
        //Privte Enums
        private enum InstallStep 
        { 
            Step1, 
            Step2, 
            Step3, 
            Step4, 
            Complete 
        }
    }
}