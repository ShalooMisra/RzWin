using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

using Tools;
using Core;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public partial class EmailBlaster : UserControl, ICompleteLoad
    {
        protected SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.xSys;
            }
        }
        protected blast_adrhed xList;
        protected blast_emailtemplate xTemplate;
        protected blast_emailserver xServer;
        Boolean bCancel = false;
        Boolean bCheckBox = false;
        int StopAfter = 0;
        int JustSent = 0;
        Boolean bInhibitLoad = false;
        Int32 udValue = 0;
        delegate void SetStatusDelegate(String sIn, Boolean bClear, Boolean bJustInText);
        delegate String GetRTDelegate();
        DataTable EmailsToSend;
        public EmailBlaster()
        {
            InitializeComponent();
        }
        public void CompleteLoad()
        {
            CompleteLoad(null, null);
        }
        public void CompleteLoad(DataTable dtEmails, blast_adrhed l)
        {
            if( l != null )
                xList = l;
            lvTemplates.ShowTemplate("EmailBlasterEmailTemplateView", "blast_emailtemplate", RzWin.User.TemplateEditor);
            lvSample.ShowTemplate("email_sample", "blast_adrdet", RzWin.User.TemplateEditor);
            lvSample.Clear();
            LoadAddressCBO();
            LoadTemplateLV();
            LoadTemplateCBO();
            SetListStatus();
            SetTemplateStatus();
            LoadServerSettings(false);
            //if (Rz3App.xLogic.IsAAT)
            //    LoadUsersAccount();
            DoResize();
            if(dtEmails != null)
            {
                //if( xList == null )  //happens in LoadEmails...
                //    GetNewList();
                LoadEmailsFromDataTable(dtEmails);
            }
            else
                LoadList();
        }
        //Public Virtual Functions
        public virtual void LoadServerSettings(Boolean bInhibit)
        {
            try
            {
                bInhibitLoad = bInhibit;
                cboServerTemplates.DataSource = null;
                DataTable dt = RzWin.Context.Select("select unique_id, templatename from blast_emailserver");
                bInhibitLoad = bInhibit;
                cboServerTemplates.DataSource = dt;
                cboServerTemplates.DisplayMember = "templatename";
                if (cboServerTemplates.DataSource == null)
                {
                    txtServerName.Text = RzWin.Context.GetSetting("blast_servername");
                    txtServerPort.Text = RzWin.Context.GetSettingInt32("blast_serverport").ToString();
                    txtServerUserName.Text = RzWin.Context.GetSetting("blast_username");
                    txtServerPassword.Text = RzWin.Context.GetSetting("blast_password");
                    txtFromAddress.Text = RzWin.Context.GetSetting("blast_fromaddress");
                    txtFromName.Text = RzWin.Context.GetSetting("blast_fromname");
                }
            }
            catch (Exception)
            {
            }
        }
        public virtual void SaveServerSettings()
        {
            try
            {
                if (!Tools.Strings.StrExt(cboServerTemplates.Text))
                {
                    RzWin.Leader.Tell("You must type in a name for this template in the dropdown box.");
                    return;
                }
                if (!Tools.Strings.StrExt(txtServerName.Text))
                {
                    RzWin.Leader.Tell("You must type in a servername for this template before saving.");
                    return;
                }
                if (!Tools.Strings.StrExt(txtServerPort.Text))
                {
                    RzWin.Leader.Tell("You must type in a serverport for this template before saving.");
                    return;
                }
                Int32 i = Int32.Parse(txtServerPort.Text.Trim());
                if (xServer == null)
                    NewServerSettings();
                xServer.servername = txtServerName.Text;
                xServer.serverport = i;
                xServer.username = txtServerUserName.Text;
                xServer.password = txtServerPassword.Text;
                xServer.fromaddress = txtFromAddress.Text;
                xServer.fromname = txtFromName.Text;
                xServer.templatename = cboServerTemplates.Text;
                xServer.ssl_required = chkSSLRequired.Checked;
                if (Tools.Strings.StrExt(xServer.unique_id))
                    xServer.Update(RzWin.Context);
                else
                    xServer.Insert(RzWin.Context);
                MessageBox.Show("Saved.");
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error saving these settings. Please make sure the portnumber you entered is actually a number and try again.");
            }
        }
        public virtual void LoadServerTemplate()
        {
            if (xServer == null)
                NewServerSettings();
            txtServerName.Text = xServer.servername;
            txtServerPort.Text = xServer.serverport.ToString();
            txtServerUserName.Text = xServer.username;
            txtServerPassword.Text = xServer.password;
            txtFromAddress.Text = xServer.fromaddress;
            txtFromName.Text = xServer.fromname;
            chkSSLRequired.Checked = xServer.ssl_required;
        }
        //Public Functions
        public void DoResize()
        {
            try
            {
                TS.Top = 0;
                TS.Left = 0;
                TS.Width = this.ClientRectangle.Width;
                TS.Height = this.ClientRectangle.Height;
                gbAddressLists.Top = -6;
                gbAddressLists.Left = 0;
                gbAddressLists.Height = tabEmail.ClientRectangle.Height;
                gbSendingStatus.Top = -6;
                gbSendingStatus.Left = tabEmail.ClientRectangle.Right - gbSendingStatus.Width;
                gbSendingStatus.Height = tabEmail.ClientRectangle.Height;
                pCurrent.Top = 0;
                pCurrent.Left = gbAddressLists.Right;
                pCurrent.Width = tabEmail.ClientRectangle.Width - ( gbSendingStatus.Width + gbAddressLists.Width );
                lvSample.Top = pCurrent.Bottom;
                lvSample.Left = gbAddressLists.Right;
                lvSample.Width = tabEmail.ClientRectangle.Width - ( gbSendingStatus.Width + gbAddressLists.Width );
                lvSample.Height = tabEmail.ClientRectangle.Height - lvSample.Top;
                tsSendSettings.Top = 104;
                tsSendSettings.Left = 6;
                tsSendSettings.Height = gbSendingStatus.Height - 106;
                cmdClearResults.Top = tabSendEmails.ClientRectangle.Height - 26;
                cmdCancelSend.Top = cmdClearResults.Top;
                cmdSendEmails.Top = tabSendEmails.ClientRectangle.Height - 52;
                RT.Height = tabSendEmails.ClientRectangle.Height - ( RT.Top + 53 );
                tsEditViewTemplate.Top = 6;
                tsEditViewTemplate.Left = tabTemplate.ClientRectangle.Width - tsEditViewTemplate.Width;
                tsEditViewTemplate.Height = tabTemplate.ClientRectangle.Height - 12;
                lvTemplates.Top = 0;
                lvTemplates.Left = 0;
                lvTemplates.Width = tabTemplate.ClientRectangle.Width - tsEditViewTemplate.Width;
                lvTemplates.Height = tabTemplate.ClientRectangle.Height;
                lvTemplates.DoResize();
                cmdDeleteTemplates.Top = tabEditTemplate.ClientRectangle.Height - 27;    // (cmdDeleteTemplates.Height + 30);
                cmdCreateTemplate.Top = tabEditTemplate.ClientRectangle.Height - 27;
                cmdSaveTemplate.Top = tabEditTemplate.ClientRectangle.Height - 27;
                cmdSaveTemplateAs.Top = tabEditTemplate.ClientRectangle.Height - 27;
                lblTemplateStatus.Top = tabEditTemplate.ClientRectangle.Height - 27;
                txtBody.Height = cmdDeleteTemplates.Top - ( txtBody.Top + 5 );
                WB.Height = tabViewTemplate.ClientRectangle.Height - 12;
                txtEmailBody.Height = WB.Height;
            }
            catch(Exception)
            {
            }
        }
        public void LoadEmailsFromDataTable(DataTable dt)
        {
            try
            {
                SortedList s = new SortedList();
                if( dt == null )
                    return;
                //foreach (DataRow dr in dt.Rows)
                //{
                //    String email = dr[1].ToString().Trim().ToLower();
                //    if (!nTools.IsEmailAddress(email))
                //        continue;
                //    try
                //    {
                //        s.Add(email, email);
                //    }
                //    catch { }
                //}
                if( xList == null )
                    GetNewList(false);
                xList.MakeDetailTableExist(RzWin.Context);

                lvSample.DisableAutoRefresh();

                if(xList != null)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        String email = dr[1].ToString().Trim().ToLower();
                        if (!nTools.IsEmailAddress(email))
                            continue;
                        try
                        {
                            xList.AddAddress(RzWin.Context, email, dr[0].ToString(), "");
                        }
                        catch
                        {
                        }
                    }
                }
                LoadList();

                lvSample.EnableAutoRefresh();
            }
            catch(Exception)
            {
            }
        }
        private void ClearTemplateLV()
        {
            RzWin.Context.TheLeader.Error("reorg");
            //lvTemplates.CurrentCollection = new Dictionary<string, nObject>();
            //lvTemplates.CurrentCollection.Clear();
            //lvTemplates.CollectionMode = true;
            //lvTemplates.RefreshFromCollection();
        }
        private void LoadTemplateLV()
        {
            blast_emailtemplate t;
            lvTemplates.ShowData("blast_emailtemplate", "", "template_name", 200);  //changed to order by name instead of date 2009/09/21
        }
        private void LoadAddressCBO()
        {
            cboAddressLists.DataSource = RzWin.Context.Select("select unique_id, list_name from blast_adrhed order by list_name");
            cboAddressLists.DisplayMember = "list_name";
            cboAddressLists.ValueMember = "unique_id";
            cboAddressLists.Text = "";
        }
        private void LoadTemplateCBO()
        {
            cboEmailTemplates.DataSource = RzWin.Context.Select("select unique_id, template_name from blast_emailtemplate order by template_name");
            cboEmailTemplates.DisplayMember = "template_name";
            cboEmailTemplates.ValueMember = "unique_id";
            cboEmailTemplates.Text = "";
        }
        private void BrowseForFile()
        {
            oFile.Filter = "Importable Files(*.xls, *.csv, *.txt)|*.xls;*.csv;*.txt";
            DialogResult dr = oFile.ShowDialog();
            if( dr.Equals(DialogResult.Cancel) )
                return;
            if( !Tools.Strings.StrExt(oFile.FileName) )
                return;
            txtFromFile.Text = oFile.FileName;
        }
        private void ImportSelectedFile()
        {
            if(!CheckRequiredText(txtFromFile))
            {
                MessageBox.Show("You must first select a file to import.");
                return;
            }
            if (xList == null)
            {
                RzWin.Leader.Tell("Please choose or create a list before importing.");
                return;
            }
            Int32 i = Tools.Strings.Split(txtFromFile.Text, ".").GetUpperBound(0);
            String ext = Tools.Strings.Split(txtFromFile.Text, ".")[ i ].ToLower();
            if (!ext.Equals("txt") && !ext.Equals("xls") && !ext.Equals("csv"))
            {
                MessageBox.Show("The file type you selected is not recognized. Please try to select the file again.");
                return;
            }
            lvSample.DisableAutoRefresh();
            switch(ext)
            {
                case "txt":
                case "csv":
                    String s = Tools.Files.OpenFileAsString(txtFromFile.Text);
                    if(!Tools.Strings.StrExt(s))
                    {
                        RzWin.Leader.Tell("This text file appears to have no information in it.");
                        return;
                    }
                    s = s.Replace("\r", "").Replace("\"", "");
                    String[] ary = Tools.Strings.Split(s, "\n");
                    for(Int32 x = 0 ; x < ary.Length ; x++)
                    {
                        String sline = ary[x];
                        String semail = Tools.Strings.ParseDelimit(sline, ",", 1).Trim();
                        String scontact = Tools.Strings.ParseDelimit(sline, ",", 2).Trim();
                        String sagent = "";
                        try
                        {
                            sagent = Tools.Strings.ParseDelimit(sline, ",", 3).Trim();
                        }
                        catch { }
                        if(semail.Contains("@"))
                        {
                            if( semail.Contains(".") )
                                AddFastAddress(semail, scontact, sagent);
                        }
                    }
                    txtFromFile.Text = "";
                    break;
                case "xls":
                    try
                    {
                        nDataTable dt = new nDataTable((DataConnectionSqlServer)RzWin.Context.Data.Connection);
                        String path = txtFromFile.Text.Trim();
                        if(path.Contains(" "))
                        {
                            RzWin.Leader.Tell("The file you are trying to import is in a folder location that contains spaces. Please move the file to the root of the drive and try again.\n\r\n\r(Example: C:\\thisfile.xls)");
                            return;
                        }
                        dt.AbsorbExcelFile_ByFile(RzWin.Context, path, "Sheet1$");
                        if(dt.Columns.Count <= 0)
                        {
                            RzWin.Leader.Tell("This file doesn't appear to have any data.");
                            return;
                        }
                        nDataColumn xColumn = (nDataColumn)dt.Columns[0];
                        String strField = xColumn.unique_id;
                        dt.CheckCriteria(RzWin.Context, "have no valid address", " " + strField + " not like '_%@%_%._%'");
                        DataTable d = RzWin.Context.Select("select " + strField + " from " + dt.TableName);
                        foreach(DataRow dr in d.Rows)
                        {
                            AddFastAddress(dr[0].ToString());
                        }
                        txtFromFile.Text = "";
                        break;
                    }
                    catch(Exception)
                    {
                        RzWin.Leader.Tell("There was an error in importing this excel file.");
                        return;
                    }
            }
            LoadList();
            lvSample.EnableAutoRefresh();
            FinishedImport();
        }
        protected virtual void FinishedImport()
        {

        }
        protected void SetListStatus()
        {
            if(!( xList == null ))
            {
                if(xList.unique_id.Length > 0)
                {
                    lblListStatus.Text = "Saved";
                    lblListStatus.ForeColor = Color.Green;
                    return;
                }
                lblListStatus.Text = "Not Saved";
                lblListStatus.ForeColor = Color.Red;
                return;
            }
            lblListStatus.Text = "";
        }
        private void SetTemplateStatus()
        {
            if(!( xTemplate == null ))
            {
                if(xTemplate.unique_id.Length > 0)
                {
                    lblTemplateStatus.Text = "Saved";
                    lblTemplateStatus.ForeColor = Color.Green;
                    return;
                }
                lblTemplateStatus.Text = "Not Saved";
                lblTemplateStatus.ForeColor = Color.Red;
                return;
            }
            lblTemplateStatus.Text = "";
        }        
        private void AddOneAddress()
        {
            if(!CheckRequiredText(txtAddOne))
            {
                MessageBox.Show("You need to enter an address before trying to add.");
                return;
            }
            AddAddress(txtAddOne.Text);
            txtAddOne.Text = "";
        }        
        private void AddFastAddress(String strAddress)
        {
            AddFastAddress(strAddress, "", "");
        }
        protected virtual void AddFastAddress(String strAddress, String contactname, String strAgent)
        {
            if (!nTools.IsEmailAddress(strAddress))
                return;
            xList.AddAddress(RzWin.Context, strAddress, "", contactname);
        }
        private void LoadUsersAccount()
        {
            try
            {
                string template = RzWin.Context.SelectScalarString("select templatename from blast_emailserver where fromname = '" + RzWin.User.name + "'");
                if (!Tools.Strings.StrExt(template))
                    return;
                int index = -1;
                DataTable dt = (DataTable)cboServerTemplates.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    index++;
                    if (Tools.Strings.StrCmp(dr["templatename"].ToString(), template))
                        break;
                }
                cboServerTemplates.SelectedIndex = index;
            }
            catch { }
        }
        private void AddAddress(String strAddress)
        {
            if( xList == null )
                GetNewList(false);
            xList.AddAddress(RzWin.Context, strAddress, "", "");
            LoadList();
        }
        protected void LoadList()
        {
            if(xList == null)
            {
                lvSample.Clear();
                txtListName.Text = "";
                txtListDescription.Text = "";
                lblTotal.Text = "-";
                lblSent.Text = "-";
                SetListStatus();
                //pCurrent.Enabled = false;
                return;
            }
            //pCurrent.Enabled = true;
            txtListName.Text = xList.list_name;
            txtListDescription.Text = xList.description;
            //always update the structure, just in case the class structure changes
            xList.MakeDetailTableExist(RzWin.Context);
            ShowCounts();
            SetListStatus();
            lvSample.AlternateConnection = RzWin.Logic.MarketingConnection;
            lvSample.AlternateTableName = xList.DetailTable;
            lvSample.ShowData("blast_adrdet", "", "email_adr", SysNewMethod.ListLimitDefault);
        }
        protected void ShowCounts()
        {
            xList.CalculateCounts(RzWin.Context);
            DisplayCounts();
        }
        private void DisplayCounts()
        {
            if( InvokeRequired )
                Invoke(new DisplayHandler(ActuallyDisplayCounts));
            else
                ActuallyDisplayCounts();
        }
        delegate void DisplayHandler();
        private void ActuallyDisplayCounts()
        {
            lblTotal.Text = Tools.Number.LongFormat(xList.total_count);
            lblSent.Text = Tools.Number.LongFormat(xList.sent_count);
            lblJustSent.Text = Tools.Number.LongFormat(JustSent);
        }
        private void DeleteList()
        { 
            if (xList == null)
                return;
            DeleteOneList(xList);
            xList = null;
            LoadList();
            LoadAddressCBO();
        }
        private void DeleteOneList(blast_adrhed list)
        {
            if (list == null)
                return;
            RzWin.Context.Execute("drop table " + list.DetailTable);
            list.Delete(RzWin.Context);
        }
        public void GetNewList(bool auto_load)
        {
            xList = blast_adrhed.New(RzWin.Context);
            xList.list_name = "NewList(" + DateTime.Now.ToString() + ")";
            xList.description = "";
            xList.Insert(RzWin.Context);
            xList.MakeDetailTableExist(RzWin.Context);
            if( auto_load )
                LoadList();
        }
        private Boolean SaveList(Boolean bSaveAs)
        {
            if(xList == null)
                GetNewList(true);
            if(bSaveAs)
            {
                String sName = RzWin.Leader.AskForString("Please enter the name for this list:", "", "List Name");
                if (!Tools.Strings.StrExt(sName))
                    return false;
                xList.list_name = sName;
                txtListName.Text = sName;
                xList.description = txtListDescription.Text;
                xList.Update(RzWin.Context);
                LoadList();
                LoadAddressCBO();
                return true;
            }
            else
            {
                xList.list_name = txtListName.Text;
                xList.description = txtListDescription.Text;
                xList.Update(RzWin.Context);
                LoadList();
                LoadAddressCBO();
                return true;
            }
        }
        private void ClearList(Boolean bOnlySelected)
        {
            if(!bOnlySelected)
            {
                if( !RzWin.Leader.AskYesNo("You are about to clear this list from the screen. Ok to continue?") )
                    return;
                xList = null;
                LoadList();
            }
            else
            {
                if( !RzWin.Leader.AskYesNo("You are about to clear all selected email addresses from this list. Ok to continue?") )
                    return;
                Int32 x = 0;
            }
        }
        private void ClearResults()
        {
            if( !RzWin.Leader.AskYesNo("Are you sure you want to clear these results?") )
                return;
            RT.Clear();
            RT.Text = "";
        }
        private Boolean CheckRequiredText(Control c)
        {
            if( c == null )
                return false;
            try
            {
                if( c.Text.Trim().Length > 0 )
                    return true;
                else
                    return false;
            }
            catch(Exception)
            {
                return false;
            }
        }
        private blast_adrdet GetNewAddressNoInsert(String sAddOne)
        {
            if( !Tools.Strings.StrExt(sAddOne) || !sAddOne.Contains("@") )
                return null;
            blast_adrdet d = blast_adrdet.New(RzWin.Context);
            if(xList != null)
            {
                d.the_blast_adrhed_uid = xList.unique_id;
                d.list_name = xList.list_name;
            }
            d.email_adr = sAddOne.Trim();
            d.domain_name = Tools.Strings.Split(sAddOne, "@")[ 1 ].ToString().Trim();
            return d;
        }
        private void RemoveSelectedAddresses()
        {
            try
            {
                ArrayList a = lvSample.GetSelectedIDs();
                if (a == null)
                    return;
                string inn = Tools.Data.GetIn(a);
                if (!Tools.Strings.StrExt(inn))
                    return;
                if (xList == null)
                    return;
                RzWin.Context.Execute("delete from " + xList.DetailTable + " where unique_id in (" + inn + ")", true);
                LoadList();
            }
            catch { }
        }
        //private ArrayList GetSelectedObjects()
        //{
        //    if (lvAddresses.SelectedItems.Count <= 0)
        //        return null;
        //    try
        //    {
        //        ArrayList a = new ArrayList();
        //        foreach (ListViewItem x in lvAddresses.SelectedItems)
        //        {
        //            nObject d;
        //            dAddresses.TryGetValue(x.Tag.ToString(), out d);
        //            a.Add((blast_adrdet)d);
        //        }
        //        return a;
        //    }
        //    catch (Exception)
        //    { return null; }
        //}
        private void SendEmails()
        {
            if(xList == null)
            {
                RzWin.Context.TheLeader.Tell("Please load a list of emails before continuing.");
                return;
            }
            if(xServer == null)
            {
                RzWin.Context.TheLeader.Tell("Please enter the server details before continuing.");
                return;
            }

            EmailsToSend = RzWin.Logic.MarketingConnection.Select("select unique_id from " + xList.DetailTable + " where isnull(was_sent, 0) = 0 order by email_adr");
            if(!Tools.Data.DataTableExists(EmailsToSend))
            {
                RzWin.Leader.Tell("No emails were found for this list.");
                return;
            }

            if (Tools.Strings.HasString(xTemplate.email_body, "contactname"))
            {
                long l = RzWin.Logic.MarketingConnection.GetScalar_Long("select count(*) from " + xList.DetailTable + " where isnull(contact_name, '') = ''");
                if (!RzWin.Leader.AreYouSure("send these messages, even though the content has a ContactName tag and " + Tools.Number.LongFormat(l) + " addresses have no contact name?"))
                    return;
            }

            if (Tools.Strings.HasString(xTemplate.email_body, "weblogin"))
            {
                long l = RzWin.Logic.MarketingConnection.GetScalar_Long("select count(*) from " + xList.DetailTable + " where isnull(website_login, '') = ''");
                if (!RzWin.Leader.AreYouSure("send these messages, even though the content has a WebLogin tag and " + Tools.Number.LongFormat(l) + " addresses have no login name?"))
                    return;
            }

            if( !RzWin.Leader.AskYesNo("You are about to send " + Tools.Number.LongFormat(EmailsToSend.Rows.Count) + " emails using the template named '" + xTemplate.template_name + "' with the subject '" + xTemplate.email_subject + "'. Ok to continue?") )
                return;
            bCancel = false;
            if (chkStopAfter.Checked)
                StopAfter = Convert.ToInt32(numStopAfter.Value);
            else
                StopAfter = 0;
            SetSendStatus(true);
            SetSendStatus("Starting..");
            bgThread.RunWorkerAsync();
        }
        protected virtual void SendEmailOnThreadPre()
        {

        }
        private void SendEmailOnThread()
        {
            SendEmailOnThreadPre();
            JustSent = 0;
            DisplayCounts();
            blast_adrdet.dUsers = GetUserAccounts();
            foreach(DataRow r in EmailsToSend.Rows)
            {
                blast_adrdet addr = xList.GetAddressByID(RzWin.Context, nData.NullFilter_String(r[0]));
                if(addr != null)
                {
                    SetSendStatus("Sending to " + addr.email_adr);
                    nEmailMessage m = addr.GetAsEmailMessage(RzWin.Context, xTemplate, xServer);
                    String s = "";
                    if (!m.Send(ref s))
                        SetSendStatus("Error:" + s);
                    else
                    {
                        addr.was_sent = true;
                        addr.sent_date = DateTime.Now;
                        addr.UpdateTo(RzWin.Context, RzWin.Logic.MarketingConnection, xList.DetailTable);
                        xList.sent_count++;
                        JustSent++;
                        DisplayCounts();
                        if (bCheckBox)
                        {
                            try
                            {
                                Double d = Convert.ToDouble(60.0) / Convert.ToDouble(udValue);
                                Int32 i = Convert.ToInt32(d * 60);
                                SleepSeconds(i);
                            }
                            catch (Exception)
                            {
                                SleepSeconds(3);
                            }
                        }
                        if (StopAfter > 0)
                        {
                            if (JustSent >= StopAfter)
                            {
                                SetSendStatus("Reached Limit; Stopping...");
                                return;
                            }
                        }
                    }
                    if( IsCanceled() )
                        return;
                }
                else
                    SetSendStatus("Email address came back empty.");
            }
        }
        private Dictionary<String, NewMethod.n_user> GetUserAccounts()
        {
            try
            {
                Dictionary<String, NewMethod.n_user> users = new Dictionary<String, NewMethod.n_user>();
                ArrayList a = RzWin.Context.QtC("n_user", "select * from n_user");
                foreach (NewMethod.n_user u in a)
                {
                    if (!Tools.Strings.StrExt(u.email_address))
                        continue;
                    users.Add(u.unique_id, u);
                }
                return users;
            }
            catch { return null; }
        }
        private void SetSendStatus(Boolean bClear)
        {
            if( !bClear )
                return;
            if(RT.InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(SetRT);
                RT.Invoke(d, new object[]{ "", true });
            }
            else
                SetRT("", true, false);
        }
        protected void SetSendStatus(String sStatus)
        {
            if(RT.InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(SetRT);
                RT.Invoke(d, new object[]{ sStatus, false, false });
            }
            else
                SetRT(sStatus, false, false);
        }
        private void SetSendStatus(String sStatus, Boolean bJustInText)
        {
            if(!bJustInText)
            {
                SetSendStatus(sStatus);
                return;
            }
            if(RT.InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(SetRT);
                RT.Invoke(d, new object[]{ sStatus, false, bJustInText });
            }
            else
                SetRT(sStatus, false, bJustInText);
        }
        private void SetRT(String sIn, Boolean bClear, Boolean bJustInText)
        {
            if(!bClear)
            {
                if(bJustInText)
                {
                    RT.Text = sIn;
                    RT.Refresh();
                }
                else
                {
                    RT.Text = sIn + "\r\n" + RT.Text;
                    RT.Refresh();
                }
            }
            else
            {
                RT.Clear();
                RT.Text = "";
            }
        }
        private void SleepSeconds(int sec)
        {
            String sHold = GetRTText();
            for(int i = 0 ; i < sec ; i++)
            {
                SetSendStatus("\n\rWaiting... " + ( i + 1 ).ToString() + " of " + sec.ToString() + " second(s)...\n\r" + sHold, true);
                System.Threading.Thread.Sleep(1000);
                if( IsCanceled() )
                    return;
            }
            SetSendStatus(sHold, true);
        }
        private String GetRTText()
        {
            if(RT.InvokeRequired)
            {
                GetRTDelegate d = new GetRTDelegate(GetRT);
                return (String)RT.Invoke(d, new object[]{});
            }
            else
                return GetRT();
        }
        private String GetRT()
        {
            return RT.Text;
        }
        private void ClearBody()
        {
            if( !RzWin.Leader.AskYesNo("You are about to clear this email templates body area. Ok to continue?") )
                return;
            txtBody.Text = "";
        }
        private void DeleteSelectedTemplates()
        {
            try
            {
                ArrayList a = lvTemplates.GetSelectedObjects();
                if( a.Count <= 0 )
                    return;
                foreach(blast_emailtemplate t in a)
                {
                    t.Delete(RzWin.Context);
                }
            }
            catch(Exception)
            {
            }
        }
        private void CreateNewTemplate(Boolean bLoad)
        {
            xTemplate = blast_emailtemplate.New(RzWin.Context);
            if( bLoad )
                LoadTemplate();
        }
        protected virtual void LoadTemplate()
        {
            if( xTemplate == null )
                return;
            txtTemplateName.Text = xTemplate.template_name;
            txtTemplateDescription.Text = xTemplate.description;
            txtEmailSubject.Text = xTemplate.email_subject;
            txtBody.Text = xTemplate.email_body;
            txtAttachments.Text = xTemplate.attachments;
            optHTML.Checked = true;
            optText.Checked = xTemplate.is_text;
            SetTemplateStatus();
            LoadTemplateView();
        }
        private Boolean SaveTemplate(Boolean bSaveAs)
        {
            if(!CheckRequiredText(txtBody))
            {
                RzWin.Leader.Tell("This email template contains no body information. Aborting save.");
                return false;
            }
            if( xTemplate == null )
                CreateNewTemplate(false);
            if(bSaveAs)
            {
                String sName = RzWin.Leader.AskForString("Please enter the name for this template:", xTemplate.template_name, "Template Name");
                if( !Tools.Strings.StrExt(sName) )
                    return false;
                xTemplate = blast_emailtemplate.New(RzWin.Context);
                SaveTemplateInfo();
                xTemplate.template_name = sName;
                txtTemplateName.Text = sName;
                xTemplate.Insert(RzWin.Context);
                LoadTemplateCBO();
                SetTemplateStatus();
                LoadTemplateView();
                return true;
            }
            else
            {
                if( !CheckRequiredText(txtTemplateName) )
                    return SaveTemplate(true);
                SaveTemplateInfo();

                if (xTemplate.InsertedIs)
                    xTemplate.Update(RzWin.Context);
                else
                    xTemplate.Insert(RzWin.Context);
                LoadTemplateCBO();
                SetTemplateStatus();
                LoadTemplateView();
                return true;
            }
        }
        protected virtual void SaveTemplateInfo()
        {
            xTemplate.template_name = txtTemplateName.Text;
            xTemplate.description = txtTemplateDescription.Text;
            xTemplate.email_subject = txtEmailSubject.Text;
            xTemplate.email_body = txtBody.Text;
            xTemplate.is_text = optText.Checked;
            xTemplate.attachments = txtAttachments.Text;
        }
        private Boolean LoadSelectedTemplate()
        {
            try
            {
                DataRowView drv = (DataRowView)cboEmailTemplates.SelectedItem;
                if(drv == null)
                {
                    MessageBox.Show("You must first select an email template from the drop-down menu above.");
                    return false;
                }
                xTemplate = blast_emailtemplate.GetById(RzWin.Context, drv[0].ToString());
                LoadTemplate();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        private void LoadTemplateView()
        {
            if( xTemplate == null )
                return;
            if(xTemplate.is_text)
            {
                txtEmailBody.BringToFront();
                txtEmailBody.Text = xTemplate.email_body;
            }
            else
            {
                WB.BringToFront();
                WB.ReloadWB();

                blast_adrdet b = blast_adrdet.New(RzWin.Context);
                b.agent_email = "agent@companyname.com";
                b.agent_name = "Test Agent Name";
                b.contact_name = "Test Contact";
                b.company_name = "Test Company, Inc.";
                b.website_id = 201;
                b.website_login = "test website login";
                b.website_password = "test website password";
                b.domain_name = "testdomain.com";
                b.email_adr = "test@testdomain.com";
                b.contact_first_name = "FirstName";

                WB.Add(b.BuildBody(RzWin.Context, xTemplate));
                WB.Refresh();
            }
        }
        private void NewServerSettings()
        {
            xServer = blast_emailserver.New(RzWin.Context);
        }
        private Boolean IsCanceled()
        {
            if(bCancel)
            {
                if( RzWin.Leader.AskYesNo("Do you want to stop sending these messages?") )
                    return bCancel;
                bCancel = false;
            }
            return bCancel;
        }
        private Boolean SettingsSet()
        {
            if (xServer == null)
                return false;

            if( !Tools.Strings.StrExt(xServer.servername) )
                return false;
            if( !Tools.Strings.StrExt(xServer.fromaddress) )
                return false;
            return true;
        }
        private void LoadAllRz3Emails()
        {
            RzWin.Context.Execute("drop table temp_email_batch", true);
            RzWin.Context.Execute("select distinct(primaryemailaddress) as email into temp_email_batch from company");
            RzWin.Context.Execute("insert into temp_email_batch(email) select distinct(primaryemailaddress) from companycontact");
            if( xList == null )
                GetNewList(false);
            xList.AddAddressesFromSQL(RzWin.Context, "select distinct(email) from temp_email_batch where email like '%_@%_%._%' order by email");
            LoadList();
        }
        private void ImportViaSql(String extra)
        {
            String strBaseFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + "RzEmailSQL.txt";
            if (!File.Exists(strBaseFile))
            {
                Tools.Files.SaveFileAsString(strBaseFile, "select primaryemailaddress, max(contactname), max(agentname) \r\nfrom companycontact \r\nwhere \r\nisnull(abs_type, '') <> 'DIST' \r\nand isnull(donotemail, 0) = 0 \r\nand isnull(bad_data, 0) = 0 \r\nand agentname not like '%bad record%' \r\nand primaryemailaddress like '%_@%_%._%' \r\ngroup by primaryemailaddress \r\norder by primaryemailaddress");

                //, max(agentname)
            }

            String strFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + "RzEmailSQL_Temp.txt";
            if (File.Exists(strFile))
                File.Delete(strFile);

            String strBaseInfo = Tools.Files.OpenFileAsString(strBaseFile).Replace("<extra>", extra);
            Tools.Files.SaveFileAsString(strFile, strBaseInfo);

            //File.Copy(strBaseFile, strFile);
            Tools.FileSystem.Shell(strFile);

            RzWin.Leader.Tell("Please edit the file, then click 'OK'");

            //Tools.Files.SaveFileAsString(strFile, "select primaryemailaddress, max(contactname) \r\nfrom companycontact \r\nwhere \r\nisnull(abs_type, '') <> 'DIST' \r\nand isnull(donotemail, 0) = 0 \r\nand isnull(bad_data, 0) = 0 \r\nand agentname not like '%bad record%' \r\nand primaryemailaddress like '%_@%_%._%' \r\ngroup by primaryemailaddress \r\norder by primaryemailaddress");

            //String strSQL = nStatus.InputMessageBoxMultiLine("SQL", , "SQL", this.ParentForm);

            String strSQL = Tools.Files.OpenFileAsString(strFile);
            if (!Tools.Strings.StrExt(strSQL))
                return;

            DataTable dt = RzWin.Context.Select(strSQL);
            if (!Tools.Data.DataTableExists(dt))
            {
                RzWin.Leader.Tell("No result.");
                return;
            }

            lvSample.DisableAutoRefresh();

            foreach (DataRow r in dt.Rows)
            {
                String semail = nData.NullFilter_String(r[0]);
                String scontact = nData.NullFilter_String(r[1]);
                String sagent = nData.NullFilter_String(r[2]);
                if (semail.Contains("."))
                    AddFastAddress(semail, scontact, sagent);
            }

            LoadList();
            lvSample.EnableAutoRefresh();
        }
        public void SetList(blast_adrhed l)
        {
            xList = l;
            LoadList();
            cboAddressLists.Text = "";
            cboAddressLists.SelectedItem = null;
        }
        //Buttons
        private void cmdSendEmails_Click(object sender, EventArgs e)
        {
            try
            {
                SetSendStatus("Checking...");

                if(!Tools.Strings.StrExt(cboEmailTemplates.Text))
                {
                    RzWin.Leader.Tell("Please choose an email template before continuing.");
                    return;
                }
                RT.Clear();
                RT.Text = "";
                DataRowView drv = (DataRowView)cboEmailTemplates.SelectedItem;
                if(drv == null)
                {
                    MessageBox.Show("You must first select an email template from the drop-down menu above.");
                    return;
                }
                if(xList == null)
                {
                    MessageBox.Show("You must first select a list of email addresses to send this email to.");
                    return;
                }
                if(!SettingsSet())
                {
                    MessageBox.Show("You must first set the email server settings before trying to send these emails.");
                    return;
                }

                SetSendStatus("Checking the email template");
                if (!LoadSelectedTemplate())
                {
                    RzWin.Context.TheLeader.Tell("There was an error loading the selected template. Terminating send.");
                    return;
                }

                if (!CheckBeforeSending())
                    return;

                SetSendStatus("Sending...");
                SendEmails();
            }
            catch(Exception ex)
            {
                SetSendStatus("Error: " + ex.Message);
            }
        }
        protected virtual bool CheckBeforeSending()
        {
            return true;
        }
        private void cmdClearResults_Click(object sender, EventArgs e)
        {
            ClearResults();
        }
        private void cmdBrowseFile_Click(object sender, EventArgs e)
        {
            BrowseForFile();
        }
        private void cmdImportFile_Click(object sender, EventArgs e)
        {
            ImportSelectedFile();
        }
        private void cmdAddOne_Click(object sender, EventArgs e)
        {
            AddOneAddress();
        }
        protected virtual void DoLoadList()
        {
            try
            {
                DataRowView drv = (DataRowView)cboAddressLists.SelectedItem;
                if (drv == null)
                {
                    MessageBox.Show("You must first select a list from the drop-down menu above.");
                    return;
                }
                if (!RzWin.Leader.AskYesNo("You are about to load the list named: " + drv[1].ToString() + ". Ok to continue?"))
                    return;                
                SetList(blast_adrhed.GetById(RzWin.Context, drv[0].ToString()));
            }
            catch { }
        }
        private void cmdLoadList_Click(object sender, EventArgs e)
        {
            DoLoadList();
        }
        private void cmdDeleteList_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView)cboAddressLists.SelectedItem;
                if(drv == null)
                {
                    MessageBox.Show("You must first select a list from the drop-down menu above.");
                    return;
                }
                if( !RzWin.Leader.AskYesNo("You are about to delete the list named: " + drv[1].ToString() + ", and all emails attached. This will also unload any current list you are viewing. Ok to continue?") )
                    return;
                xList = blast_adrhed.GetById(RzWin.Context, drv[0].ToString());
                DeleteList();
                cboAddressLists.Text = "";
                cboAddressLists.SelectedItem = null;
            }
            catch(Exception)
            {
            }
        }
        private void cmdDeleteMultiple_Click(object sender, EventArgs e)
        {
            DataTable dt = RzWin.Context.Select("select unique_id, list_name from blast_adrhed order by list_name");
            ArrayList a = new ArrayList();
            foreach (DataRow dr in dt.Rows)
            {
                string id = Tools.Data.NullFilterString(dr["unique_id"]);
                string name = Tools.Data.NullFilterString(dr["list_name"]);
                if (!Tools.Strings.StrExt(id))
                    continue;
                if (!Tools.Strings.StrExt(name))
                    continue;
                a.Add(name + "  [" + id + "]");
            }
            ArrayList choices = frmChooseMultipleChoices.ChooseFromArray(a, "Select The Lists Below");
            if (choices == null)
                return;
            if (choices.Count <= 0)
                return;
            string t = "";
            if (choices.Count == 1)
                t = "you want to remove this list";
            else
                t = "you want to remove these " + choices.Count.ToString() + " lists";
            if (!RzWin.Context.TheLeader.AreYouSure(t))
                return;
            string inn = "";
            foreach (string s in choices)
            {
                string id = Tools.Strings.ParseDelimit(Tools.Strings.ParseDelimit(s, "  [", 2), "]", 1).Trim();
                if (!Tools.Strings.StrExt(id))
                    continue;
                if (Tools.Strings.StrExt(inn))
                    inn += ",";
                inn += "'" + id + "'";
            }
            if (!Tools.Strings.StrExt(inn))
                return;
            a = RzWin.Context.QtC("blast_adrhed", "select * from blast_adrhed where unique_id in (" + inn + ")");
            foreach (blast_adrhed b in a)
            {
                DeleteOneList(b);
            }
            LoadAddressCBO();
        }
        private void cmdSaveList_Click(object sender, EventArgs e)
        {
            SaveList(false);
        }
        private void cmdSaveListAs_Click(object sender, EventArgs e)
        {
            SaveList(true);
        }
        private void cmdClearList_Click(object sender, EventArgs e)
        {
            ClearList(false);
        }
        private void cmdRemoveAddresses_Click(object sender, EventArgs e)
        {
            if( !RzWin.Leader.AskYesNo("You are about to delete all selected email addresses from the list named: " + xList.list_name + ". Ok to continue?") )
                return;
            RemoveSelectedAddresses();
        }
        private void cmdClearFileName_Click(object sender, EventArgs e)
        {
            txtFromFile.Text = "";
        }
        private void cmdClearBody_Click(object sender, EventArgs e)
        {
            ClearBody();
        }
        private void cmdDeleteTemplates_Click(object sender, EventArgs e)
        {
            if( !RzWin.Leader.AskYesNo("You are about to delete all selected email templates. Ok to continue?") )
                return;
            DeleteSelectedTemplates();
        }
        private void cmdCreateTemplate_Click(object sender, EventArgs e)
        {
            if (xTemplate != null)
            {
                if (!RzWin.Leader.AskYesNo("You are about to create a new email template. This will erase all unsaved changes to the current template. Ok to continue?"))
                    return;
            }
            CreateNewTemplate(true);
        }
        private void cmdSaveTemplateAs_Click(object sender, EventArgs e)
        {
            SaveTemplate(true);
        }
        private void cmdSaveTemplate_Click(object sender, EventArgs e)
        {
            SaveTemplate(false);
        }
        private void cmdSaveSettings_Click(object sender, EventArgs e)
        {
            SaveServerSettings();
            LoadServerSettings(true);
        }
        private void cmdNewServerTemplate_Click(object sender, EventArgs e)
        {
            cboServerTemplates.SelectedItem = null;
            NewServerSettings();
            LoadServerTemplate();
        }
        private void cmdViewSelectedEmailTemplate_Click(object sender, EventArgs e)
        {
            if( !LoadSelectedTemplate() )
                MessageBox.Show("There was an error loading this template. Click over to the Edit Template tab and try again there.");
            else
            {
                TS.SelectedTab = tabTemplate;
                tsEditViewTemplate.SelectedTab = tabViewTemplate;
            }
        }
        private void cmdClearTemplateSelection_Click(object sender, EventArgs e)
        {
            cboEmailTemplates.SelectedItem = null;
            cboEmailTemplates.Text = "";
        }
        private void cmdCancelSend_Click(object sender, EventArgs e)
        {
            if(!bCancel)
            {
                SetSendStatus("Canceling..");
                bCancel = true;
            }
        }
        private void cmdLoadAllRz3Emails_Click(object sender, EventArgs e)
        {
            if( !RzWin.Leader.AskYesNo("You are about to load the all the Rz email addresses from the system. This will create a new list for the addresses.\n\rOk to continue?") )
                return;
            LoadAllRz3Emails();
        }
        private void cmdClearByAlphabet_Click(object sender, EventArgs e)
        {
            String strBar = RzWin.Leader.AskForString("What is the cutoff to use?", "", "Cutoff");
            if (!Tools.Strings.StrExt(strBar))
                return;
            xList.ClearByAlpha(RzWin.Context, strBar);
            LoadList();
        }
        private void cmdSQL_Click(object sender, EventArgs e)
        {
            if (xList == null)
            {
                RzWin.Leader.Tell("Please load or save a list before continuing");
                return;
            }
            ImportViaSql("");
        }
        private void cmdImportAgents_Click(object sender, EventArgs e)
        {
            ArrayList choices = frmChooseUser_Multiple.Choose(RzWin.Logic.SalesPeople, "Agent Selection");
            if (choices == null)
                return;
            if (choices.Count == 0)
                return;

            StringBuilder sb = new StringBuilder();
            sb.Append(" and isnull(agentname, '') > '' and agentname in ( 'not_an_agent' ");
            foreach (String s in choices)
            {
                sb.Append(", '" + RzWin.Context.Filter(s) + "'");
            }
            sb.Append(")");
            ImportViaSql(sb.ToString());
        }
        private void cmdImportAssignedAgents_Click(object sender, EventArgs e)
        {
            RzWin.Logic.CacheAssignedAgents(RzWin.Context);
            ArrayList choices = frmChooseUser_Multiple.Choose(RzWin.Logic.AssignedAgents, "Agent Selection");
            if (choices == null)
                return;
            if (choices.Count == 0)
                return;
            StringBuilder sb = new StringBuilder();
            sb.Append(" isnull(agentname, '') > '' and agentname in (");
            string build = "";
            foreach (String s in choices)
            {
                if (Tools.Strings.StrExt(build))
                    build += ",";
                build += "'" + RzWin.Context.Filter(s) + "'";
            }
            sb.Append(build + ")");
            RzWin.Context.Execute("drop table temp_email_batch", true);
            RzWin.Context.Execute("select distinct(primaryemailaddress) as email into temp_email_batch from company where " + sb.ToString());
            RzWin.Context.Execute("insert into temp_email_batch(email) select distinct(primaryemailaddress) from companycontact where " + sb.ToString());
            if (xList == null)
                GetNewList(false);
            xList.AddAddressesFromSQL(RzWin.Context, "select distinct(email) from temp_email_batch where email like '%_@%_%._%' order by email");
            LoadList();
        }
        //Control Events
        private void txtAddOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( e.KeyChar == 13 )
                AddOneAddress();
        }
        private void lvAddresses_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
        }
        private void lvTemplates_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
            blast_emailtemplate b = (blast_emailtemplate)lvTemplates.GetSelectedObject();
            if( b == null )
                return;
            xTemplate = b;
            LoadTemplate();
        }
        private void EmailBlaster_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void TS_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoResize();
        }
        private void tsEditViewTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoResize();
        }
        private void chkPerHour_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPerHour.Checked)
            {
                udEmailCount.Enabled = true;
                udEmailCount.Value = 700;
                bCheckBox = true;
                udValue = 700;
            }
            else
            {
                udEmailCount.Enabled = false;
                udEmailCount.Value = 0;
                bCheckBox = false;
                udValue = 0;
            }
        }
        private void udEmailCount_ValueChanged(object sender, EventArgs e)
        {
            udValue = (Int32)udEmailCount.Value;
        }
        private void cboServerTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bInhibitLoad)
                {
                    LoadServerTemplate();
                    bInhibitLoad = false;
                    return;
                }
                DataRowView drv = (DataRowView)cboServerTemplates.SelectedItem;
                xServer = blast_emailserver.GetById(RzWin.Context, drv[0].ToString());
                LoadServerTemplate();
            }
            catch (Exception)
            {
            }
        }
        private void lblRecalc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowCounts();
        }
        private void lvSample_AboutToThrow(object sender, ShowArgs args)
        {
            RzWin.Context.Reorg();
            //args.Handled = true;
            //if (xTemplate == null)
            //{
            //    RzWin.Leader.Tell("Please select a template before continuing.");
            //    return;
            //}
            //if (xServer == null)
            //{
            //    RzWin.Leader.Tell("Please select an email server before continuing.");
            //    return;
            //}
            //blast_adrdet addr = xList.GetAddressByID(RzWin.Context, lvSample.GetSelectedID());
            //if (addr != null)
            //    addr.ShowMessage(xTemplate, xServer);
        }
        private void lblSetContactInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (xList == null)
                return;
            throb.ShowThrobber();
            bgContact.RunWorkerAsync();
        }
        private void lblClearSent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (xList == null)
                return;
            xList.MarkUnsent(RzWin.Context);
            LoadList();
        }
        private void chkStopAfter_CheckedChanged(object sender, EventArgs e)
        {
            numStopAfter.Enabled = chkStopAfter.Checked;
        }
        private void lblSingleAgent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewMethod.n_user u = NewMethod.n_user.Choose(RzWin.Context, false);
            if (u == null)
                return;

            if (!nTools.IsEmailAddress(u.email_address))
            {
                RzWin.Leader.Tell("Please choose an agent with a valid email address.");
                return;
            }

            xList.SetAgent(RzWin.Context, u);
            LoadList();
        }
        private void lblBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String s = ToolsWin.FileSystem.ChooseAFile();
            if (!Tools.Strings.StrExt(s))
                return;

            if (!System.IO.File.Exists(s))
                return;

            if (Tools.Strings.StrExt(txtAttachments.Text))
                txtAttachments.AppendText("\r\n");

            txtAttachments.AppendText(s);
        }
        //Background Workers
        private void bgThread_DoWork(object sender, DoWorkEventArgs e)
        {
            SendEmailOnThread();
        }
        private void bgThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetSendStatus("Done.\r\n");
        }
        private void bgContact_DoWork(object sender, DoWorkEventArgs e)
        {
            xList.AbsorbContactInfo(RzWin.Context);
        }
        private void bgContact_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadList();
            throb.HideThrobber();
        }
        private void bgWebsite_DoWork(object sender, DoWorkEventArgs e)
        {
            xList.AbsorbWebsiteInfo(RzWin.Context);
        }
        private void bgWebsite_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadList();
            throb.HideThrobber();
        }
        private void lblReplyTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String reply = RzWin.Context.TheLeader.AskForString("Reply to address");
            if (!Tools.Email.IsEmailAddress(reply))
                return;

            xList.SetReplyTo(RzWin.Context, reply);
            LoadList();
        }
        private void lblFrom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String from = RzWin.Context.TheLeader.AskForString("From address");
            if (!Tools.Email.IsEmailAddress(from))
                return;

            xList.SetFromAddress(RzWin.Context, from);
            LoadList();
        }
        private void lblFindAgents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (xList == null)
                return;
            throb.ShowThrobber();
            bgAgent.RunWorkerAsync();
        }
        private void bgAgent_DoWork(object sender, DoWorkEventArgs e)
        {
            xList.FindAgent(RzWin.Context);
        }
        private void bgAgent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadList();
            throb.HideThrobber();
        }
    }
}