using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Core;
using NewMethod;

namespace Rz3_Common
{
    public partial class EMailProcessor_Screen : UserControl, ICompleteLoad, IStatusView 
    {
        delegate void SetStatusHandler(String s);
        n_sys xSys;
        public EMailProcessor xProcess;
        Boolean boolStop = false;
        public Boolean boolScanning = false;
        Int64 lngTime = 0;

        public EMailProcessor_Screen()
        {
            try
            {
                InitializeComponent();
                nStatus.RegisterStatusView(this);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        //Public Functions
        public void CompleteLoad()
        {
            try
            {
                DoResize();
                FillCommands();
                ClearStats();
                PB.Value = 0;
                LoadSettings();
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        public void DoResize()
        {
            try
            {
                SetBorder();
                gbCommands.Top = pbTop.Bottom + 2;
                gbCommands.Left = pbLeft.Right + 2;
                gbCurrentBatch.Left = gbCommands.Left;
                gbCurrentBatch.Top = gbCommands.Bottom + 3;
                PB.Left = gbCommands.Left;
                PB.Top = gbCurrentBatch.Bottom + 3;
                PB.Width = (pbRight.Left - PB.Left) - PB.Left;
                txtStatus.Left = PB.Left;
                txtStatus.Top = PB.Bottom + 3;
                txtStatus.Width = PB.Width;
                txtStatus.Height = (pbBottom.Top - txtStatus.Top) - 2;
                ts.Top = gbCommands.Top;
                ts.Left = gbCommands.Right + 3;
                ts.Width = (pbRight.Left - ts.Left) - 2;
                ts.Height = gbCurrentBatch.Bottom - ts.Top;
                lblMessageNumber.Width = (tabMessage.ClientRectangle.Width - lblMessageNumber.Left) - lblMessageNumber.Left;
                pMsgInfo.Width = (tabMessage.ClientRectangle.Width - pMsgInfo.Left) - pMsgInfo.Left;
                lblMessageFrom.Width = (pMsgInfo.Width - lblMessageFrom.Left) - 2;
                lblMessageTo.Width = lblMessageFrom.Width;
                lblMessageSubject.Width = lblMessageFrom.Width;
                gbMessageBody.Width = (tabMessage.ClientRectangle.Width - gbMessageBody.Left) - gbMessageBody.Left;
                optDest.Left = (tabHandlers.ClientRectangle.Width / 2) + 1;
                optSource.Left = ((tabHandlers.ClientRectangle.Width / 2) - optSource.Width) - 1;
                lvHandlers.Width = (tabHandlers.ClientRectangle.Width - lvHandlers.Left) - lvHandlers.Left;
                lvHandlers.Height = (tabHandlers.ClientRectangle.Height - lvHandlers.Top) - 2;
                cmdApply.Top = (tabKeywords.ClientRectangle.Height - cmdApply.Height) - 2;
                cmdTest.Top = cmdApply.Top;
                gbRequirements.Width = (tabKeywords.ClientRectangle.Width / 2) - 6; ;
                gbOffers.Width = gbRequirements.Width;
                gbRequirements.Left = 2;
                gbOffers.Left = gbRequirements.Right + 4;
                gbRequirements.Height = (cmdApply.Top - gbRequirements.Top) - 2;
                gbOffers.Height = gbRequirements.Height;
                cmdApply.Left = gbRequirements.Left;
                cmdApply.Width = gbRequirements.Width;
                cmdTest.Left = gbOffers.Left;
                cmdTest.Width = gbOffers.Width;
                gbMailClient.Width = (tabOptions.ClientRectangle.Width - gbMailClient.Left) - gbMailClient.Left;
                optOutlook.Left = (gbMailClient.Width / 2) - (optOutlook.Width + 2);
                optNative.Left = optOutlook.Right + 2;
                txtCC.Width = (tabOptions.ClientRectangle.Width - txtCC.Left) - 2;
                txtSubject.Width = txtCC.Width;
                cmdEditResponseHeader.Width = (tabOptions.ClientRectangle.Width / 2) - (cmdEditResponseHeader.Left * 2);
                cmdEditResponseColumns.Width = cmdEditResponseHeader.Width;
                cmdEditResponseFooter.Width = cmdEditResponseHeader.Width;
                cmdAutoStart.Left = cmdEditResponseHeader.Right + 2;
                cmdApplyOptions.Left = cmdAutoStart.Left;
                cmdAutoStart.Width = (tabOptions.ClientRectangle.Width - cmdAutoStart.Left) - 2;
                cmdApplyOptions.Width = cmdAutoStart.Width;
            }
            catch (Exception)
            { }
        }
        public void StartProcessing()
        {
            try
            {
                boolStop = false;
                if (!DoSettings())
                    return;
                xProcess.LoadRestrictions();
                xProcess.ClearSettings();
                StartTimer();
                boolScanning = false;
                timer1_Tick(this, new EventArgs());
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        //Private Functions
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();

            }
            catch (Exception)
            { }
        }
        private void FillCommands()
        {
            try
            {
                lvCommands.Items.Clear();
                AddCommand("START PROCESSING", "Start Processing", "Start The Process Timer To Run Continuously.");
                AddCommand("PROCESS ONE", "Process One", "Process Only The First Message In The Inbox.");
                AddCommand("STOP PROCESSING", "Stop Processing", "Stop The Process.");
                AddCommand("SYSTEM TEST", "System Test", "Manually Enter Data To Scan.");
                AddCommand("RECEIVE", "Receive", "Download new messages.");
                AddCommand("RESPONSE TEST", "Response Test", "View An Example Automatic Response.");
                AddCommand("MATCHING OPTIONS", "Matching Setup", "Tell Rz3 how to match parts.");
                //AddCommand("INTERNALTEST", "Internal Test", "Test matching with the internal POP3 client.");
                //AddCommand("TEMPTEST", "Temporary Folder", "Test reception of messages from the temporary folder.");
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void AddCommand(String strKey, String strText, String strDescr)
        {
            try
            {
                ListViewItem xLst = lvCommands.Items.Add(strText);
                xLst.SubItems.Add(strDescr);
                xLst.Tag = strKey;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void ClearStats()
        {
            txtMessageBody.Text = "";
            lblBatchStartedOn.Text = "";
            lblRound.Text = "";
            lblTotalMinutes.Text = "";
            lblScannedMessages.Text = "";
            lblMessagesPerMinute.Text = "";
            lblMatchesFound.Text = "";
            lblMatchesPerMinute.Text = "";
            lblPartsFound.Text = "";
            lblPartsPerMinute.Text = "";
            lblMessageFrom.Text = "";
            lblMessageTo.Text = "";
            lblMessageSubject.Text = "";
            //lblMessageMatches.Text = "";
            //lblMessageParts.Text = "";
            lblPartsUpdated.Text = "";
            lblPartsConfirmed.Text = "";
        }
        private void LoadSettings()
        {
            try
            {
                if (xSys.GetSetting_Boolean("nativeemail"))
                    optNative.Checked = true;
                else
                    optOutlook.Checked = true;
                txtReqKeywords.Text = xSys.GetSetting("email_req_keywords");
                txtOfferKeywords.Text = xSys.GetSetting("email_offer_keywords");
                lvHandlers.ShowTemplate("address_handlers", "addresshandler", Rz3App.xUser.TemplateEditor);
                ShowHandlers();
                chkAllReqs.Checked = xSys.GetSetting_Boolean("emailonlyreqs");
                if (xSys.GetSetting_Boolean("emailautorespond"))
                {
                    chkAutoRespond.Checked = true;
                    chkSingleResponse.Enabled = true;
                    chkSingleResponse.Checked = xSys.GetSetting_Boolean("emailsingleresponse");
                    chkIncludeOriginal.Checked = xSys.GetSetting_Boolean("includeoriginalmessage");
                }
                else
                {
                    chkAutoRespond.Checked = false;
                    chkSingleResponse.Checked = false;
                    chkSingleResponse.Enabled = false;
                    chkIncludeOriginal.Checked = false;
                    chkIncludeOriginal.Enabled = false;
                }
                txtSubject.SetValue(xSys.GetSetting("email_response_subject"));
                txtCC.SetValue(xSys.GetSetting("email_response_cc"));
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void ShowHandlers()
        {
            try
            {
                if (optSource.Checked)
                    lvHandlers.ShowData("addresshandler", "sourcedest = 'source'", "emailaddress", 200);
                else
                    lvHandlers.ShowData("addresshandler", "sourcedest = 'dest'", "emailaddress", 200);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void StopCountDown()
        {
            try
            {
                PB.Value = 0;
                timer2.Enabled = false;
                timer2.Stop();
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void DoRetreive()
        {
            DoRetreive(0);
        }
        private void DoRetreive(Int64 limit)
        {
            try
            {
                nStatus.SetStatus("Retreiving Mail...");
                xProcess.GetMail(limit);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void DoProcess()
        {
            DoProcess(0);
        }
        private void DoProcess(Int64 limit)
        {
            try
            {
                nStatus.SetStatus("Processing...");
                xProcess.ProcessMessages(limit);
                nStatus.SetStatus("Done.");
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private Boolean DoSettings()
        {
            try
            {
                if (xProcess != null)
                    CloseTheProcessor();

                xProcess = new EMailProcessor();
                xProcess.eAboutToProcess += new AboutToProcessHandler(xProcess_AboutToProcess);
                xProcess.eFoundInfo += new FoundInfoHandler(xProcess_eFoundInfo);
                xProcess.eShouldStop += new ShouldStopHandler(xProcess_eShouldStop);
                xProcess.eFoundPart += new FoundPartHandler(xProcess_eFoundPart);
                xProcess.eGotMatch += new GotMatchHandler(xProcess_eGotMatch);
                xProcess.eGotSQL += new GotSQLHandler(xProcess_eGotSQL);
                xProcess.eSQLDebug += new SQLDebugHandler(xProcess_eSQLDebug);
                xProcess.eNewAddress += new NewAddressHandler(xProcess_eNewAddress);
                xProcess.eGotUpdate += new GotUpdateHandler(xProcess_eGotUpdate);
                xProcess.eGotConfirm += new GotConfirmHandler(xProcess_eGotConfirm);
                nStatus.SetStatus("Configuring the Rz3 e-mail system...");
                return true;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return false;
            }
        }

        void CloseTheProcessor()
        {
            try
            {
                xProcess.eAboutToProcess -= new AboutToProcessHandler(xProcess_AboutToProcess);
                xProcess.eFoundInfo -= new FoundInfoHandler(xProcess_eFoundInfo);
                xProcess.eShouldStop -= new ShouldStopHandler(xProcess_eShouldStop);
                xProcess.eFoundPart -= new FoundPartHandler(xProcess_eFoundPart);
                xProcess.eGotMatch -= new GotMatchHandler(xProcess_eGotMatch);
                xProcess.eGotSQL -= new GotSQLHandler(xProcess_eGotSQL);
                xProcess.eSQLDebug -= new SQLDebugHandler(xProcess_eSQLDebug);
                xProcess.eNewAddress -= new NewAddressHandler(xProcess_eNewAddress);
                xProcess.eGotUpdate -= new GotUpdateHandler(xProcess_eGotUpdate);
                xProcess.eGotConfirm -= new GotConfirmHandler(xProcess_eGotConfirm);
                xProcess = null;
            }
            catch { }
        }

        private void StopTimer()
        {
            try
            {
                timer1.Enabled = false;
                timer1.Stop();
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void StartTimer()
        {
            try
            {
                timer1.Interval = 60000;
                timer1.Enabled = true;
                timer1.Start();
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void StartCountDown()
        {
            try
            {
                PB.Value = 0;
                timer2.Interval = 1000;
                timer2.Enabled = true;
                timer2.Start();
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void SystemTest()
        {
            try
            {
                boolStop = false;
                frmEMailTest xForm = new frmEMailTest();
                xForm.ShowDialog();
                EMailMessageOld xMessage = new EMailMessageOld();
                xMessage.SetFromAddress(xForm.SenderAddress);
                xMessage.SetToAddress(xForm.RecipientAddress);
                xMessage.SUBJECT = xForm.BodyType;
                xMessage.BODYTEXT = xForm.BODYTEXT;

                if (xMessage.SUBJECT == "REQ")
                    xMessage.CONTENTSTYPE = Rz3_Common.Enums.MessageType.Req;

                if (!Tools.Strings.StrExt(xMessage.BODYTEXT))
                    return;

                DoSettings();
                xProcess.LoadRestrictions();
                xProcess.colMailItems.Add(xMessage);

                DoProcess();
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void TestRespond()
        {
            TestRespond(false);
        }
        private void TestRespond(Boolean bInternal)
        {
            try
            {
                boolStop = false;
                EMailMessageOld xMessage = new EMailMessageOld();
                xMessage.SetFromAddress("test@recognin.com");
                xMessage.SetToAddress("test@recognin.com");
                xMessage.SUBJECT = "REQ";
                xMessage.BODYTEXT = GetResponseReq();
                if (!DoSettings())
                    return;
                xProcess.colMailItems.Add(xMessage);
                xProcess.boolShowResponse = true;
                xProcess.boolTestOnly = false;
                message yMessage = new message(xSys);
                yMessage.subject = "Test Req";
                yMessage.bodytext = xMessage.BODYTEXT;
                yMessage.bodyhtml = xMessage.BODYTEXT;
                yMessage.fromaddresstext = "test@recognin.com";
                yMessage.messagedate = DateTime.Now;
                yMessage.ISave();
                xMessage.MESSAGEID = yMessage.unique_id;
                DoProcess();
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private String GetResponseReq()
        {
            try
            {
                String strSQL = "SELECT TOP 10 FULLPARTNUMBER, MANUFACTURER, QUANTITY, DATECODE FROM PARTRECORD WHERE QUANTITY > 0 AND LEN(BASENUMBER) > 5 AND BASENUMBER LIKE '0%' AND STOCKTYPE IN ('stock', 'oem', 'excess', 'consign', 'consigned')";
                DataTable dt = xSys.xData.GetDataTable(strSQL);
                Boolean bExists = false;
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        bExists = true;
                }
                if (!bExists)
                {
                    strSQL = "SELECT TOP 10 FULLPARTNUMBER, MANUFACTURER, QUANTITY, DATECODE FROM PARTRECORD WHERE QUANTITY > 0 AND LEN(BASENUMBER) > 5 AND STOCKTYPE IN ('stock', 'oem', 'excess', 'consign', 'consigned')";
                    dt = xSys.xData.GetDataTable(strSQL);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                            bExists = true;
                    }
                    if (!bExists)
                    {
                        nStatus.TellUser("No inventory information could be found.  Please use the 'System Test' option and manually enter part numbers.");
                        return "";
                    }
                }
                String strHold = "PART\tMFG\tQTY\tDC\n";
                foreach (DataRow dr in dt.Rows)
                {
                    strHold += dr["fullpartnumber"].ToString() + "\t" + dr["manufacturer"].ToString() + "\t" + dr["quantity"].ToString() + "\t" + dr["datecode"].ToString() + "\t\n";
                }
                return strHold;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return "";
            }
        }
        private void RunTempTest()
        {
            //Dim colHold As Collection
            //Dim xReceiver As New EmailReceiver
            //Dim xMessage As EmailMessage
            //Dim yMessage As EmailMessageOld
            //EMailProcessor xProcess = new EMailProcessor();
            //ArrayList colHold = xReceiver.GetTempEmails()
            //Set xProcess.colMailItems = New Collection
            //For Each xMessage In colHold
            //    Set yMessage = New EmailMessageOld
            //    yMessage.BODYTEXT = xMessage.Body
            //    yMessage.MESSAGEHTML = xMessage.bodyhtml
            //    yMessage.FromAddress.addressstring = xMessage.FromAddress
            //    yMessage.SUBJECT = xMessage.SUBJECT
            //    yMessage.MESSAGEHTML = xMessage.bodyhtml
            //    yMessage.MESSAGEID = xMessage.unique_id
            //    yMessage.messagedate = Now
            //    xProcess.colMailItems.Add yMessage
            //Next xMessage

            //Call DoProcess(0)
        }
        private void SetStatus(String sIn)
        {
            try
            {
                txtStatus.Text = sIn + "\r\n" + txtStatus.Text;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void GatherStats()
        {
            try
            {
                String s0 = "{0:###,###,##0}";
                String s4 = "{0:0.00##}";
                lblBatchStartedOn.Text = xProcess.BatchStart.ToShortDateString() + " " + xProcess.BatchStart.ToShortTimeString();
                lblRound.Text = String.Format(s0, xProcess.lngRound);
                lblTotalMinutes.Text = String.Format(s0, xProcess.TotalMinutes);
                lblScannedMessages.Text = String.Format(s0, xProcess.TotalMessages);
                lblMessagesPerMinute.Text = String.Format(s4, xProcess.MessagesPerMinute);
                lblMatchesFound.Text = String.Format(s0, xProcess.TotalMatches);
                lblMatchesPerMinute.Text = String.Format(s4, xProcess.MatchesPerMinute);
                lblPartsFound.Text = String.Format(s0, xProcess.TotalParts);
                lblPartsPerMinute.Text = String.Format(s4, xProcess.PartsPerMinute);
                //lblMessageMatches.Text = String.Format(s0, xProcess.MessageMatches);
                //lblMessageParts.Text = String.Format(s0, xProcess.MessageParts);
                lblPartsUpdated.Text = String.Format(s0, xProcess.TotalUpdated);
                lblPartsConfirmed.Text = String.Format(s0, xProcess.TotalConfirm);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void EditEmailResponseHeader()
        {
            try
            {
                String filepath = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()) + "email_response_header.txt";
                if (!File.Exists(filepath))
                    Tools.Files.SaveFileAsString(filepath, "");
                Tools.FileSystem.PopTextFile(filepath);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void EditEmailResponseColumns()
        {
            try
            {
                Form xForm = new Form();
                nList lst = new nList();
                xForm.Controls.Add(lst);
                lst.Dock = DockStyle.Fill;
                xForm.Width = 680;
                xForm.Height = 470;
                xForm.StartPosition = FormStartPosition.CenterScreen;
                xForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                xForm.MaximizeBox = false;
                xForm.Text = "Edit Response Columns";
                lst.ShowTemplate("QUICKCONFIRMDETAILS", "partrecord", true);
                lst.DoResize();
                xForm.ShowDialog();
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void EditEmailResponseFooter()
        {
            try
            {
                String filepath = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()) + "email_response_footer.txt";
                if (!File.Exists(filepath))
                    Tools.Files.SaveFileAsString(filepath, "");
                Tools.FileSystem.PopTextFile(filepath);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        //IStatusView Events
        public void SetStatusByIndex(Object sender, StatusArgs args)
        {
            if (InvokeRequired)
            {
                SetStatusHandler h = new SetStatusHandler(SetStatus);
                this.Invoke(h, new object[] { args.status });
            }
            else
                SetStatus(args.status);
        }
        public void SetProgressByIndex(Object sender, ProgressArgs args)
        { }
        public void SetActivityByIndex(Object sender, ActivityArgs args)
        { }
        public void AddLine()
        { }
        public void RemoveLine()
        { }
        //Event Handlers
        private void xProcess_AboutToProcess(EMailMessageOld ThisMessage, bool boolClear)
        {
            try
            {
                GatherStats();
                if (boolClear)
                    lvParts.Items.Clear();
                lblMessageFrom.Text = ThisMessage.FromAddress.addressstring;
                lblMessageTo.Text = ThisMessage.ToAddress.addressstring;
                lblMessageSubject.Text = ThisMessage.SUBJECT;
                txtMessageBody.Text = ThisMessage.BODYTEXT;
                lblMessageNumber.Text = "Message " + String.Format("{0:n}", xProcess.lngCurrentMessage.ToString()) + " Of " + String.Format("{0:n}", xProcess.colMailItems.Count.ToString());
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void xProcess_eFoundPart(partrecord xPart, string strSource)
        {
            try
            {
                ListViewItem xLst = lvParts.Items.Add(strSource);
                xLst.SubItems.Add(xPart.fullpartnumber);
                xLst.SubItems.Add(xPart.quantity.ToString());
                xLst.SubItems.Add(xPart.manufacturer);
                xLst.SubItems.Add(xPart.datecode);
                nDouble d = xPart.price;
                xLst.SubItems.Add(d.MoneyFormat());
                nStatus.SetStatus(xPart.fullpartnumber + " [ " + Tools.Number.LongFormat(xPart.quantity) + " ], " + strSource);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void xProcess_eShouldStop(ref bool boolCancel)
        {
            boolCancel = boolStop;
        }
        private void xProcess_eFoundInfo(string ITEMNUMBER, string SOURCEADDRESS, string strType)
        {
            try
            {
                if (Tools.Strings.StrCmp(strType, "match"))
                    nStatus.SetStatus("Match Found " + SOURCEADDRESS);
                else
                    nStatus.SetStatus("Part Found From " + SOURCEADDRESS + ":  " + ITEMNUMBER);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void xProcess_eGotConfirm()
        {

        }
        private void xProcess_eGotUpdate()
        {

        }
        private void xProcess_eNewAddress()
        {

        }
        private void xProcess_eSQLDebug(string strDebug)
        {

        }
        private void xProcess_eGotSQL(string ThisSQL)
        {

        }
        private void xProcess_eGotMatch(DataTable rst, string strAddress, string strDesc, string strType)
        {

        }
        //Buttons
        private void cmdApply_Click(object sender, EventArgs e)
        {
            try
            {
                xSys.SetSetting("email_req_keywords", txtReqKeywords.Text);
                xSys.SetSetting("email_offer_keywords", txtOfferKeywords.Text);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void cmdTest_Click(object sender, EventArgs e)
        {
            try
            {
                String s = nStatus.InputMessageBox("Enter the subject line to test:", "", "", this.ParentForm);
                if (!Tools.Strings.StrExt(s))
                    return;
                EMailMessageOld xM = new EMailMessageOld();
                xM.SUBJECT = s;
                switch (xM.CalculateContents())
                {
                    case Rz3_Common.Enums.MessageType.Offer:
                        nStatus.TellUser("Offer");
                        break;
                    case Rz3_Common.Enums.MessageType.Req:
                        nStatus.TellUser("Req");
                        break;
                    case Rz3_Common.Enums.MessageType.Unknown:
                        nStatus.TellUser("Unknown");
                        break;
                    case Rz3_Common.Enums.MessageType.Confirmation:
                        nStatus.TellUser("Confirmation");
                        break;
                }
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void cmdEditResponseHeader_Click(object sender, EventArgs e)
        {
            EditEmailResponseHeader();
        }
        private void cmdEditResponseColumns_Click(object sender, EventArgs e)
        {
            EditEmailResponseColumns();
        }
        private void cmdEditResponseFooter_Click(object sender, EventArgs e)
        {
            EditEmailResponseFooter();
        }
        private void cmdAutoStart_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Files.SaveFileAsString(Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()) + "auto_pass.txt", xSys.xData.user_password);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void cmdApplyOptions_Click(object sender, EventArgs e)
        {
            try
            {
                xSys.SetSetting("email_response_subject", txtSubject.GetValue_String());
                xSys.SetSetting("email_response_cc", txtCC.GetValue_String());
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        //Control Events
        private void EMailProcessor_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void optSource_CheckedChanged(object sender, EventArgs e)
        {
            ShowHandlers();
        }
        private void optOutlook_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                xSys.SetSetting_Boolean("nativeemail", optOutlook.Checked);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void chkAllReqs_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                xSys.SetSetting_Boolean("emailonlyreqs", chkAllReqs.Checked);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void chkAutoRespond_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                xSys.SetSetting_Boolean("emailautorespond", chkAutoRespond.Checked);
                chkSingleResponse.Enabled = chkAutoRespond.Checked;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void chkSingleResponse_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                xSys.SetSetting_Boolean("emailsingleresponse", chkSingleResponse.Checked);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void chkIncludeOriginal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                xSys.SetSetting_Boolean("includeoriginalmessage", chkIncludeOriginal.Checked);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lvCommands_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem xLst = lvCommands.SelectedItems[0];
                if (xLst == null)
                    return;
                String strKey = xLst.Tag.ToString();
                if (!Tools.Strings.StrExt(strKey))
                    return;
                switch (strKey.ToUpper())
                {
                    case "START PROCESSING":
                        StartProcessing();
                        break;
                    case "PROCESS ONE":
                        boolStop = false;
                        if (!DoSettings())
                            return;
                        xProcess.LoadRestrictions();
                        DoRetreive(1);
                        DoProcess(1);
                        break;
                    case "STOP PROCESSING":
                        if (!nStatus.AskUser_YesNo("Are you sure that you want to stop this process?"))
                            return;
                        boolStop = true;
                        StopTimer();
                        StopCountDown();
                        break;
                    case "RECEIVE":
                        xProcess = new EMailProcessor();
                        xProcess.DoReceive();
                        break;
                    case "SYSTEM TEST":
                        SystemTest();
                        break;
                    case "RESPONSE TEST":
                        TestRespond();
                        break;
                    case "MATCHING OPTIONS":
                        frmEmailMatchSetup xForm = new frmEmailMatchSetup();
                        xForm.CompleteLoad();
                        xForm.ShowDialog();
                        break;
                    case "PROCESS TEST":
                        break;
                    case "INTERNALTEST":
                        TestRespond(true);
                        break;
                    case "TEMPTEST":
                        RunTempTest();
                        break;
                }
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void lvHandlers_AboutToAdd(object sender, AddArgs args)
        {
            try
            {
                args.Handled = true;
                addresshandler a = new addresshandler(xSys);
                if (optSource.Checked)
                    a.sourcedest = "source";
                else
                    a.sourcedest = "dest";
                xSys.ThrowObjectUp(a);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        //Timers
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (boolScanning)
                    return;
                Int64 lngLimit = 0;
                StopCountDown();
                boolScanning = true;
                if (Tools.Number.IsNumeric(txtBufferSize.Text))
                    lngLimit = Int64.Parse(txtBufferSize.Text);
                else
                    lngLimit = 10;
                DoRetreive(lngLimit);
                DoProcess(0);
                StopTimer();
                StartTimer();
                StartCountDown();
                boolScanning = false;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (PB.Value >= 60)
                {
                    PB.Value = 0;
                    timer2.Enabled = false;
                    timer2.Stop();
                }
                else
                    PB.Value = PB.Value + 1;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
    }
}
