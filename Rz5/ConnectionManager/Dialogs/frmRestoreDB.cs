using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethodx;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace ConnectionManager
{
    public partial class frmRestoreDB : Form
    {
        //Private Variables
        private nData xData;

        //Constructors
        public frmRestoreDB()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad(nData d)
        {
            if (d == null)
                return false;
            xData = d;
            LoadScreen();
            return xData.CanConnect();
        }
        //Private Functions
        private void LoadScreen()
        {
            try
            {
                if (xData == null)
                    return;
                txtServer.Text = xData.server_name;
                txtUserName.Text = xData.user_name;
                txtPassword.Text = xData.user_password;
            }
            catch { }
        }
        private void RunRestore()
        {
            try
            {
                SetStatus("Running restore.");
                if (!CheckForAvailability())
                    return;
                if(!UpdateDataConnection())
                {
                    MessageBox.Show("This connection information is invalid.");
                    SetStatus("This connection information is invalid.");
                    return;
                }
                if (!Tools.Files.FileExists(txtBackUpFile.Text))
                {
                    MessageBox.Show("The backup file does not exist.");
                    SetStatus("The backup file does not exist.");
                    return;
                }
                RestoreDatabase();
                SetStatus("Restore complete.");
                CheckRestoreStatus();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error: " + ee.Message);
                SetStatus("Error: " + ee.Message);
            }
        }
        private void RestoreDatabase()
        {
            try
            {
                Server srvSql = new Server(new ServerConnection(xData.server_name, xData.user_name, xData.user_password));
                Restore rstDatabase = new Restore();
                rstDatabase.Action = RestoreActionType.Database;
                rstDatabase.Database = txtRestoreToName.Text;
                BackupDeviceItem bkpDevice = new BackupDeviceItem(txtBackUpFile.Text, DeviceType.File);
                rstDatabase.Devices.Add(bkpDevice);
                rstDatabase.ReplaceDatabase = true;
                srvSql.KillAllProcesses(txtRestoreToName.Text);
                rstDatabase.SqlRestoreAsync(srvSql);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error: " + ee.Message);
                SetStatus("Error: " + ee.Message);
            }
        }
        private bool UpdateDataConnection()
        {
            if (xData == null)
            {
                xData = new nData();
                xData.database_name = "master";
            }
            xData.server_name = txtServer.Text;
            xData.user_name = txtUserName.Text;
            xData.user_password = txtPassword.Text;
            xData.SetConnectionString();
            return TestDataConnection();
        }
        private bool TestDataConnection()
        {
            SetStatus("Testing data connection.");
            if (xData == null)
                return false;
            return xData.CanConnect();
        }
        private void BrowseForFile()
        {
            try
            {
                string file = "";
                ofd.ShowDialog();
                file = ofd.FileName;
                if (!Tools.Strings.StrExt(file))
                    return;
                if (!Tools.Files.FileExists(file))
                    return;
                txtBackUpFile.Text = file;
            }
            catch { }
        }
        private bool CheckForAvailability()
        {
            try
            {
                SetStatus("Checking for availability.");
                if (!Tools.Strings.StrExt(txtRestoreToName.Text))
                    return false;
                nData d = new nData();
                d.target_type = (Int32)NewMethodx.Enums.ServerTypes.SQLServer; 
                d.database_name = txtRestoreToName.Text;
                d.server_name = xData.server_name;
                d.user_name = xData.user_name;
                d.user_password = xData.user_password;
                d.SetConnectionString();
                if (d.CanConnect())
                {
                    SetStatus("Database exists.");
                    return true;
                }
                else
                {
                    MessageBox.Show("This database doesn't appear to exist. Please choose an existing database.");
                    SetStatus("This database doesn't appear to exist. Please choose an existing database.");
                    return false;
                }
            }
            catch { }
            return false;
        }
        private void SetStatus(string s)
        {
            RT.Text = s + "\r\n" + RT.Text;
        }
        private void CheckRestoreStatus()
        {
            try
            {
                SetStatus("Checking restore status.");
                nData d = new nData();
                d.target_type = (Int32)NewMethodx.Enums.ServerTypes.SQLServer;
                d.database_name = txtRestoreToName.Text;
                d.server_name = xData.server_name;
                d.user_name = xData.user_name;
                d.user_password = xData.user_password;
                d.SetConnectionString();
                if (d.CanConnect())
                    SetStatus("Successfully restored.");
                else
                    SetStatus("Restore not found.");
            }
            catch { }
        }
        private void sqlRestore_Complete(object sender, ServerMessageEventArgs e)
        {

        }
        private void sqlRestore_PercentComplete(object sender, ServerMessageEventArgs e)
        {

        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cmdRun_Click(object sender, EventArgs e)
        {
            RunRestore();
        }
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            BrowseForFile();
        }
        private void cmdCheck_Click(object sender, EventArgs e)
        {
            CheckForAvailability();
        }
    }
}
