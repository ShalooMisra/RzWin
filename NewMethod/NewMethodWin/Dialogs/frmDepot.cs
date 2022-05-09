using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Tools.Database;

namespace NewMethod
{
    public partial class frmDepot : Form
    {
        //Public Variables
        public DepotConnection CurrentConnection = null;
        //Private Variables
        private ArrayList Connections;
        
        //Constructors
        public frmDepot()
        {
            InitializeComponent();
            DisableEdit();
        }
        //Public Functions
        public void CompleteLoad()
        {
            pIdent.Visible = false;
            if (Tools.Misc.IsDevelopmentMachine())
                pIdent.Visible = true;
            LoadDepot();
        }
        //Private Functions
        private void CheckWriteFolder()
        {
            string folder = Tools.Folder.ConditionFolderName(Tools.Folder.GetFolderName(DepotConnection.GetDepotFileName()));
            bool possible = false;
            if (Tools.Folder.FolderExists(folder))
            {
                if (Tools.Files.SaveFileAsString(folder + "text.txt", "testing1..2..3"))
                {
                    if (Tools.Files.FileExists(folder + "text.txt"))
                    {
                        Tools.Files.TryDeleteFile(folder + "text.txt");
                        possible = true;
                    }
                }
            }
            if (!possible)
                NMWin.Leader.Tell("The folder cannot be written to. Please restart Rz under 'Administrative Rights' to edit the depot options.");
        }
        private void EnableEdit()
        {
            //this.Height = 587;
            ToolsWin.Screens.ShowDownTo(this, gbConnection);
            CheckWriteFolder();
        }
        private void DisableEdit()
        {
            //this.Height = 361;
            ToolsWin.Screens.ShowDownTo(this, lv);
        }

        private void LoadDepot()
        {
            lv.Items.Clear();

            Connections = new ArrayList();

            if (!System.IO.File.Exists(DepotConnection.GetDepotFileName()))
            {
                //this will create the blank file if needed
                if (!SaveDepot())
                    return;
            }

            String XMLData = Tools.Files.OpenFileAsString(DepotConnection.GetDepotFileName());

            if (!Tools.Strings.StrExt(XMLData))
                return;

            XmlDocument xDoc = new System.Xml.XmlDocument();

            try
            {
                xDoc.LoadXml(XMLData);
            }
            catch (Exception e)
            {
                return;
            }

            XmlNodeList l = xDoc.GetElementsByTagName("connection");
            XmlNode x;
            foreach (XmlNode n in l)
            {
                DepotConnection c = new DepotConnection();

                x = n.SelectSingleNode("description");
                if (x != null)
                    c.Description = x.InnerText;

                x = n.SelectSingleNode("servername");
                if (x != null)
                    c.ServerName = x.InnerText;

                x = n.SelectSingleNode("databasename");
                if (x != null)
                    c.DatabaseName = x.InnerText;

                x = n.SelectSingleNode("username");
                if (x != null)
                    c.UserName = x.InnerText;

                x = n.SelectSingleNode("password");
                if (x != null)
                    c.Password = x.InnerText;

                x = n.SelectSingleNode("recallservername");
                if (x != null)
                    c.RecallServerName = x.InnerText;

                x = n.SelectSingleNode("recalldatabasename");
                if (x != null)
                    c.RecallDatabaseName = x.InnerText;

                x = n.SelectSingleNode("recallusername");
                if (x != null)
                    c.RecallUserName = x.InnerText;

                x = n.SelectSingleNode("recallpassword");
                if (x != null)
                    c.RecallPassword = x.InnerText;

                Connections.Add(c);
            }

            foreach (DepotConnection c in Connections)
            {
                ListViewItem i = lv.Items.Add(c.Description);
                i.Tag = c;
            }
        }
        private bool SaveDepot()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\"?>");
            sb.AppendLine("   <connections>");

            foreach (DepotConnection d in Connections)
            {
                sb.AppendLine("      <connection>");
                sb.AppendLine("         <description>" + d.Description + "</description>");
                sb.AppendLine("         <servername>" + d.ServerName + "</servername>");
                sb.AppendLine("         <databasename>" + d.DatabaseName + "</databasename>");
                sb.AppendLine("         <username>" + d.UserName + "</username>");
                sb.AppendLine("         <password>" + d.Password + "</password>");
                sb.AppendLine("         <recallservername>" + d.RecallServerName + "</recallservername>");
                sb.AppendLine("         <recalldatabasename>" + d.RecallDatabaseName + "</recalldatabasename>");
                sb.AppendLine("         <recallusername>" + d.RecallUserName + "</recallusername>");
                sb.AppendLine("         <recallpassword>" + d.RecallPassword + "</recallpassword>");
                sb.AppendLine("      </connection>");
            }

            sb.AppendLine("   </connections>");
            return Tools.Files.SaveFileAsString(DepotConnection.GetDepotFileName(), sb.ToString());
        }
        private void ShowCompanyIdentifier()
        {
            ListViewItem i = lv.SelectedItems[0];
            if (i == null)
                return;
            DepotConnection c = (DepotConnection)i.Tag;
            DataConnectionSqlServer d = new DataConnectionSqlServer(c.ServerName, c.DatabaseName, c.UserName, c.Password);
            if (d == null)
                return;
            if (!d.ConnectPossible())
                return;
            string str = d.GetScalar_String("select setting_value from n_set where name = 'company_identifier'");
            txtCompIdent.SetValue(str);
            NMWin.Leader.Tell("Done.");
        }
        private void UpdateCompanyIdentifier(ContextNM x)
        {
            ListViewItem i = lv.SelectedItems[0];
            if (i == null)
                return;
            DepotConnection c = (DepotConnection)i.Tag;
            DataConnectionSqlServer d = new DataConnectionSqlServer(c.ServerName, c.DatabaseName, c.UserName, c.Password);
            if (d == null)
                return;
            if (!d.ConnectPossible())
                return;
            d.Execute("update n_set set setting_value = '" + txtCompIdent.GetValue_String() + "' where name = 'company_identifier'");
            x.TheLeader.Tell("Saved");
        }        
        private void LoadConnection(DepotConnection c)
        {
            description.SetValue(c.Description);
            server.SetValue(c.ServerName);
            database.SetValue(c.DatabaseName);
            username.SetValue(c.UserName);
            password.SetValue(c.Password);
            recall_server.SetValue(c.RecallServerName);
            recall_database.SetValue(c.RecallDatabaseName);
            recall_username.SetValue(c.RecallUserName);
            recall_password.SetValue(c.RecallPassword);
            CurrentConnection = c;
            EnableEdit();
        }
        private void SaveConnection()
        {
            CheckWriteFolder();
            if (CurrentConnection == null)
                return;
            CurrentConnection.Description = (String)description.GetValue();
            CurrentConnection.ServerName = (String)server.GetValue();
            CurrentConnection.DatabaseName = (String)database.GetValue();
            CurrentConnection.UserName = (String)username.GetValue();
            CurrentConnection.Password = (String)password.GetValue();
            CurrentConnection.RecallServerName = (String)recall_server.GetValue();
            CurrentConnection.RecallDatabaseName = (String)recall_database.GetValue();
            CurrentConnection.RecallUserName = (String)recall_username.GetValue();
            CurrentConnection.RecallPassword = (String)recall_password.GetValue();
            SaveDepot();
            LoadDepot();
            DisableEdit();
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (!chkAskAgain.Checked)
            {
                if (NMWin.Leader.AreYouSure("remove the system selection option"))
                {
                    nTools.TryDeleteFile(DepotConnection.GetDepotFileName());
                }
            }

            CurrentConnection = null;
            this.Hide();
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            DepotConnection c = new DepotConnection();
            c.Description = "New Connection 1";
            Connections.Add(c);
            LoadConnection(c);
        }
        private void cmdCancel_Click()
        {
            this.Hide();
        }
        private void cmdApply_Click(object sender, EventArgs e)
        {
            SaveConnection();
        }
        private void cmdContinue_Click(object sender, EventArgs e)
        {

            ListViewItem i;

            try
            {
                i = lv.SelectedItems[0];
            }
            catch (Exception)
            {
                return;
            }

            if (i == null)
                return;

            CurrentConnection = (DepotConnection)i.Tag;
            this.Hide();
        }
        private void cmdDisable_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(DepotConnection.GetDepotFileName());
            CurrentConnection = null;
            this.Hide();
        }
        private void cmdSetCompIdent_Click(object sender, EventArgs e)
        {
            UpdateCompanyIdentifier(NMWin.ContextDefault);
        }
        private void cmdSetIdent_Click(object sender, EventArgs e)
        {
            frmCompanyFlag f = new frmCompanyFlag();
            f.ShowDialog();
            string comp_ident = f.CompanyIdent;
            txtCompIdent.SetValue(comp_ident);
        }
        //Control Events
        private void lv_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem i = lv.SelectedItems[0];
            if (i == null)
                return;

            CurrentConnection = (DepotConnection)i.Tag;
            this.Hide();
        }        
        //Menus
        private void mnuEdit_Click(object sender, EventArgs e)
        {
            ListViewItem i = lv.SelectedItems[0];
            if (i == null)
                return;

            LoadConnection((DepotConnection)i.Tag);
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            ListViewItem i = lv.SelectedItems[0];
            if (i == null)
                return;

            if (!NMWin.Leader.AreYouSure("delete this connection"))
                return;

            Connections.Remove((DepotConnection)i.Tag);
            SaveDepot();
            LoadDepot();
        }
        private void mnuCompIdent_Click(object sender, EventArgs e)
        {
            ShowCompanyIdentifier();
        }

        //Public Static Functions
        public static void ShowDepotOptions()
        {
            frmDepot xForm = new frmDepot();
            xForm.Show();
            xForm.CompleteLoad();
        }
        public static DepotConnection Choose()
        {
            frmDepot xForm = new frmDepot();
            xForm.CompleteLoad();
            xForm.ShowDialog();
            return xForm.CurrentConnection;
        }

    }

}