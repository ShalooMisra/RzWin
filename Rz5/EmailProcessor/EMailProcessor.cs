using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Data;
using System.Net.Mail;
//using Outlook = Microsoft.Office.Interop.Outlook;
using Tools;
using ToolsWin;
using NewMethod;

using OfficeInterop;

namespace Rz3_Common
{

    public delegate void AboutToProcessHandler(EMailMessageOld ThisMessage, Boolean boolClear);
    public delegate void FoundInfoHandler(String ITEMNUMBER, String SOURCEADDRESS, String strType);
    public delegate void ShouldStopHandler(ref Boolean boolCancel);
    public delegate void FoundPartHandler(partrecord xPart, String strSource);
    public delegate void GotMatchHandler(DataTable rst, String strAddress, String strDesc, String strType);
    public delegate void GotSQLHandler(String ThisSQL);
    public delegate void SQLDebugHandler(String strDebug);
    public delegate void NewAddressHandler();
    public delegate void GotUpdateHandler();
    public delegate void GotConfirmHandler();

    namespace Enums
    {
        public enum MailProcessType
        {
            DoNot = 0,
            Normal = 1,
            RollingPre = 2,
            RollingPost = 3,
            Tagged = 4,
            AttachmentOnly = 5
        }
    }
    public partial class EMailProcessor
    {
        n_sys xSys;
        ContextNM TheContext;
        //Public Events
        public event AboutToProcessHandler eAboutToProcess;
        public event FoundInfoHandler eFoundInfo;
        public event ShouldStopHandler eShouldStop;
        public event FoundPartHandler eFoundPart;
        public event GotMatchHandler eGotMatch;
        public event GotSQLHandler eGotSQL;
        public event SQLDebugHandler eSQLDebug;
        public event NewAddressHandler eNewAddress;
        public event GotUpdateHandler eGotUpdate;
        public event GotConfirmHandler eGotConfirm;

        //Public Properties
        public Int64 TotalMinutes
        {
            get
            {
                Int64 lne = 1;
                try
                {
                    TimeSpan ts = DateTime.Now - BatchStart;
                    lne++;
                    return (Int64)ts.TotalMinutes;
                }
                catch (Exception ee)
                {
                    nError.HandleError(new nError.nErrorObject(ee.Message, "Int64 TotalMinutes", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Int64 TotalMinutes"));
                    return 0;
                }
            }
        }
        public Double MessagesPerMinute
        {
            get
            {
                Int64 lne = 1;
                try
                {
                    Int64 lngMinutes = TotalMinutes;
                    lne++;
                    if (lngMinutes <= 0)
                    {
                        lne++;
                        return 0;
                    }
                    lne++;
                    return Math.Round((Double)TotalMessages / (Double)lngMinutes, 4);
                }
                catch (Exception ee)
                {
                    nError.HandleError(new nError.nErrorObject(ee.Message, "Double MessagesPerMinute", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Double MessagesPerMinute"));
                    return 0;
                }
            }
        }
        public Double MatchesPerMinute
        {
            get
            {
                Int64 lne = 1;
                try
                {
                    Int64 lngMinutes = TotalMinutes;
                    lne++;
                    if (lngMinutes <= 0)
                    {
                        lne++;
                        return 0;
                    }
                    lne++;
                    return Math.Round((Double)TotalMatches / (Double)lngMinutes, 4);
                }
                catch (Exception ee)
                {
                    nError.HandleError(new nError.nErrorObject(ee.Message, "Double MatchesPerMinute", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Double MatchesPerMinute"));
                    return 0;
                }
            }
        }
        public Double PartsPerMinute
        {
            get
            {
                Int64 lne = 1;
                try
                {
                    Int64 lngMinutes = TotalMinutes;
                    lne++;
                    if (lngMinutes <= 0)
                    {
                        lne++;
                        return 0;
                    }
                    lne++;
                    return Math.Round((Double)TotalParts / (Double)lngMinutes, 4);
                }
                catch (Exception ee)
                {
                    nError.HandleError(new nError.nErrorObject(ee.Message, "Double PartsPerMinute", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Double PartsPerMinute"));
                    return 0;
                }
            }
        }
        //Public Static Vars
        public static String GlobalEmailMessage = "";
        //Public Vars
        public OutlookApplication xOutlookApp;
        public OutlookMAPIFolder xInbox;
        public ArrayList colSourceRestrictions = new ArrayList();
        public ArrayList colDestRestrictions = new ArrayList();
        public Boolean boolTestOnly = false;
        public Boolean boolShowResponse = false;
        public ArrayList colMailItems = new ArrayList();
        public ArrayList colMatches = new ArrayList();
        public ArrayList colConfirm = new ArrayList();
        public String InboxFolder = "";
        public DateTime BatchStart;
        public Int64 lngRound = 0;
        public Int64 TotalMatches = 0;
        public Int64 TotalMessages = 0;
        public Int64 TotalParts = 0;
        public Int64 TotalUnmatchedResponses = 0;
        public Int64 TotalMatchedResponses = 0;
        public Int64 TotalUpdated = 0;
        public Int64 TotalConfirm = 0;
        public Int64 MessageParts = 0;
        public Int64 MessageMatches = 0;
        public Int64 lngCurrentMessage = 0;
        public Boolean boolBrokerForum = false;
        public Boolean boolInBracket = false;
        public ArrayList colBFStock = new ArrayList();
        public ArrayList colBFReqs = new ArrayList();
        public Boolean boolProperHeader = false;
        public company xCompany = new company(Rz3App.xSys);
        public partrecord CurrentPart = new partrecord(Rz3App.xSys);
        public String CurrentMessageID = "";
        public String ActiveReplyAddress = "";
        //Private Vars
        private ArrayList MessagePartArray = new ArrayList();
        private String companyname = "";
        private String contactname = "";
        private String phonenumber = "";
        private String faxnumber = "";
        private ArrayList colHotReqs = new ArrayList();
        private Int64 lngLastHotReq = 0;
        private String[,] aryHeaders = new String[8, 2];
        private String[,] aryHeaderTypes = new String[8, 4];
        private String[] aryWords = new String[50];
        private Int64 lngPartsFound = 0;
        private ArrayList colMessages = new ArrayList();
        private String strMessageAddress = "";
        private EMailMessageOld yMessage = new EMailMessageOld();

        public Dictionary<String, Dictionary<String, partrecord>> dMatches = new Dictionary<string, Dictionary<String, partrecord>>();
        public Dictionary<String, Dictionary<String, ArrayList>> dParts = new Dictionary<string, Dictionary<String, ArrayList>>();

        public EMailProcessor()
        {
            Init(Rz3App.xMainForm.TheContextNM);
        }
        public EMailProcessor(ContextNM x)
        {
            Init(x);
        }
        public void Init(ContextNM x)
        {
            Int64 lne = 1;
            try
            {
                xOutlookApp = new OutlookApplication();
                lne++;
                xSys = Rz3App.xSys;
                TheContext = x;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Constructor()", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Constructor()"));
            }
        }
        //Public Functions
        public void GetMail()
        {
            GetMail(0);
        }
        public void GetMail(Int64 lngLimit)
        {
            try
            {
                EMailMessageOld yMessage = new EMailMessageOld();
                String strSQL = "";
                if (xSys.GetSetting_Boolean("nativeemail"))
                {
                    ReceiveMessages_Internal();
                    if (lngLimit > 0)
                        strSQL = "select top " + lngLimit.ToString() + " * from message where scanned = 0";
                    else
                        strSQL = "select * from message where scanned = 0";
                    ArrayList colHold = xSys.QtC("message", strSQL);
                    colMailItems = new ArrayList();
                    foreach (message xMessage in colHold)
                    {
                        yMessage = new EMailMessageOld();
                        yMessage.BODYTEXT = xMessage.bodytext;
                        yMessage.MESSAGEHTML = xMessage.bodyhtml;
                        yMessage.FromAddress.addressstring = xMessage.fromaddresstext;
                        yMessage.SUBJECT = xMessage.subject;
                        yMessage.MESSAGEID = xMessage.unique_id;
                        yMessage.messagedate = DateTime.Now;
                        colMailItems.Add(yMessage);
                        xMessage.scanned = true;
                        xMessage.IUpdate();
                    }
                }
                else
                {
                    InboxFolder = "Recogniz";
                    Boolean boolDownloadNew = true;
                    nStatus.SetStatus("Connecting...");
                    OutlookApplication.OutlookSendReceive();
                    nStatus.SetStatus("Filling Outlook data...");
                    CheckRecognizFolders(xOutlookApp.GetInbox());
                    colMailItems = xOutlookApp.FillOutlookMessages(colSourceRestrictions, colDestRestrictions, ref xInbox, InboxFolder, lngLimit);
                    nStatus.SetStatus("Filled: " + colMailItems.Count.ToString() + " messages.");
                }
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "void GetMail(Int64 lngLimit)", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void GetMail(Int64 lngLimit)"));
            }
        }
        public void DoReceive()
        {
            Int64 lne = 1;
            try
            {
                nStatus.SetStatus("Receiving...");
                lne++;
                if (Rz3App.xSys.GetSetting_Boolean("nativeemail"))
                {
                    lne++;
                    ReceiveMessages_Internal();
                }
                else
                {
                    lne++;
                    OutlookApplication.OutlookSendReceive();
                }
                lne++;
                nStatus.SetStatus("Complete.");
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "void DoReceive", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void DoReceive"));
            }
        }
        public void ProcessMessages()
        {
            ProcessMessages(0);
        }
        public void ProcessMessages(Int64 lngLimit)
        {
            try
            {
                Boolean boolCancel = false;
                lngRound++;
                lngCurrentMessage = 1;
                EMailMessageOld xMsg = null;
                foreach (EMailMessageOld xMessage in colMailItems)
                {
                    xMsg = xMessage;
                    MessageParts = 0;
                    MessageMatches = 0;
                    colMatches = new ArrayList();
                    DoAboutToProcess(xMessage, true);
                    nStatus.SetStatus("Processing Message " + lngCurrentMessage.ToString() + " of " + colMailItems.Count.ToString() + "...");
                    yMessage = xMessage;
                    CurrentMessageID = xMessage.MESSAGEID;
                    nStatus.SetStatus("Calculating Contents...");
                    xMessage.CalculateContents();
                    if (xMessage.CONTENTSTYPE.Equals(Enums.MessageType.Unknown))
                    {
                        if (!boolTestOnly)
                        {
                            nStatus.SetStatus("Unknown Message Type: " + yMessage.SUBJECT);
                            HandleUnknown();
                        }
                    }
                    else
                    {
                        boolBrokerForum = IsBrokerForum(xMessage.SUBJECT);
                        ProcessMessage(xMessage.ProcessType(colSourceRestrictions, colDestRestrictions));
                    }
                    DeleteThisMessage();
                    TotalMessages++;
                    DoShouldStop(ref boolCancel);
                    if (boolCancel)
                        break;
                    lngCurrentMessage++;
                }
                DoAboutToProcess(xMsg, false);
            }
            catch (Exception ee)
            {
                nStatus.SetStatus("Rz3_Common.EMailProcessor.void ProcessMessages(Int64 lngLimit) :" + ee.Message);
                nError.HandleError(new nError.nErrorObject(ee.Message, "void ProcessMessages(Int64 lngLimit)", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void ProcessMessages(Int64 lngLimit)"));
            }
        }
        public void ProcessMessage(Enums.MailProcessType xProcessType)
        {
            try
            {
                dMatches = new Dictionary<string, Dictionary<String, partrecord>>();
                String strLine = "";
                Int64 lngStart = 0;
                Int64 lngLength = 0;
                Boolean boolRollingAddresses = false;
                String strChar = "";
                String strHold = "";
                Boolean bNegStep = false;
                ClearMessages();
                String FilterString = "!@#$%^&*,=+|<>";
                Boolean boolCancel = false;
                switch (xProcessType)
                {
                    case Rz3_Common.Enums.MailProcessType.DoNot:
                        return;
                    case Rz3_Common.Enums.MailProcessType.Normal:
                        ActiveReplyAddress = FilterAnAddress(yMessage.FromAddress.addressstring);
                        lngStart = 0;
                        lngLength = yMessage.BODYTEXT.Length;
                        break;
                    case Rz3_Common.Enums.MailProcessType.RollingPre:
                        ActiveReplyAddress = "";
                        lngStart = 0;
                        lngLength = yMessage.BODYTEXT.Length;
                        boolRollingAddresses = true;
                        break;
                    case Rz3_Common.Enums.MailProcessType.RollingPost:
                        ActiveReplyAddress = FilterAnAddress(yMessage.FromAddress.addressstring);
                        lngStart = yMessage.BODYTEXT.Length;
                        lngLength = 1;
                        bNegStep = true;
                        boolRollingAddresses = true;
                        break;
                    case Rz3_Common.Enums.MailProcessType.Tagged:
                        ActiveReplyAddress = FilterAnAddress(GetTagValue("EMAIL:", yMessage.BODYTEXT));
                        if (!Tools.Strings.StrExt(ActiveReplyAddress))
                        {
                            ActiveReplyAddress = FilterAnAddress(GetTagValue("EMAIL :", yMessage.BODYTEXT));
                            if (!Tools.Strings.StrExt(ActiveReplyAddress))
                            {
                                ActiveReplyAddress = FilterAnAddress(GetTagValue("E-MAIL:", yMessage.BODYTEXT));
                                if (Tools.Strings.StrExt(ActiveReplyAddress))
                                    ActiveReplyAddress = FilterAnAddress(GetTagValue("E-MAIL :", yMessage.BODYTEXT));
                            }
                        }
                        lngStart = 0;
                        lngLength = yMessage.BODYTEXT.Length;
                        boolRollingAddresses = false;
                        break;
                    case Rz3_Common.Enums.MailProcessType.AttachmentOnly:
                        ActiveReplyAddress = "DONOT";
                        lngStart = 0;
                        break;
                }
                if (lngLength > 400000)
                    return;
                if (nTools.GetControlKey())
                {
                    if (!Tools.Strings.StrExt(ActiveReplyAddress))
                        nStatus.TellUser("(start of processing) The active reply address appears to be blank: " + xProcessType.ToString());
                    else
                        nStatus.TellUser("(start of processing) The active reply address appears to be: " + ActiveReplyAddress);
                }
                lngPartsFound = 0;
                Int64 lngWords = 0;
                yMessage.BODYTEXT += "\r\n";
                String strAll = yMessage.BODYTEXT;
                //Tools.FileSystem.PopText(strAll);
                EMailProcessor.GlobalEmailMessage = strAll;
                addresshandler xHandler = (addresshandler)xSys.QtO("addresshandler", "select * from addresshandler where emailaddress = '" + ActiveReplyAddress + "' and SCANCOMPANY = 1");
                if (xHandler != null)
                {
                    //yMessage.MESSAGEHTML 
                    xHandler.ScanData(yMessage.BODYTEXT, ref companyname, ref contactname, ref phonenumber, ref faxnumber);
                    if (xHandler.savecompany && Tools.Strings.StrExt(companyname))
                        Rz3App.CheckSaveCompany(companyname, contactname, phonenumber, faxnumber);
                }
                else
                {
                    companyname = "";
                    contactname = "";
                    phonenumber = "";
                    faxnumber = "";
                }
                boolInBracket = false;
                colBFStock = new ArrayList();
                colBFReqs = new ArrayList();
                try
                {
                    if (!bNegStep)
                    {
                        for (Int64 lngCount = lngStart; lngCount < lngLength + 1; lngCount++)
                        {
                            try { strChar = yMessage.BODYTEXT.Substring((Int32)lngCount, 1); }
                            catch { }
                            if (strChar == " " || strChar == "\t" || strChar == "\r" || strChar == "\n" || strChar == Convert.ToChar(160).ToString())
                            {
                                strHold = strHold.Trim();
                                if (strHold.Length > 0)
                                {
                                    lngWords++;
                                    if (bNegStep)
                                        strHold = nTools.StrReverse(strHold);
                                    if (boolBrokerForum)
                                    {
                                        if (strHold.IndexOf("", 0) > 0)
                                        {
                                            boolInBracket = false;
                                            RollBF();
                                        }
                                        if (strHold.ToUpper().IndexOf("FOUND") > 0)
                                            boolInBracket = true;
                                    }
                                    //Tools.FileSystem.PopText(yMessage.BODYTEXT);
                                    if (IsPart(strHold, FilterString))
                                    {
                                        if (PartObject.IsPartPackageSetup(strHold))
                                        {
                                            strHold = "";
                                            continue;
                                        }
                                        strHold = strHold.ToUpper();
                                        if (AddToArray(strHold))
                                        {
                                            lngPartsFound++;
                                            if (bNegStep)
                                                lngCount += -1;
                                            else
                                                lngCount += 1;
                                            //Tools.FileSystem.PopText(yMessage.BODYTEXT);
                                            GetMatches(strHold, lngCount, strLine);
                                            DoShouldStop(ref boolCancel);
                                            if (boolCancel)
                                                break;
                                        }
                                    }
                                    else if (nTools.IsEmailAddress(strHold))
                                    {
                                        if (boolRollingAddresses)
                                        {
                                            DoNewAddress();
                                            strHold = strHold.Replace(",", "");
                                            strHold = strHold.Replace("<", "");
                                            strHold = strHold.Replace(">", "");
                                            if (xSys.GetSetting_Boolean("emailsingleresponse"))
                                                FlushMessages();
                                            ActiveReplyAddress = strHold;
                                        }
                                    }
                                }
                                strHold = "";
                                if (strChar == "\n")
                                    strLine = "";
                                else
                                    if (strChar == "\r")
                                        strLine += strChar;
                                //Added below
                                if (strChar == " ")
                                    strLine += strChar;
                                //Added above
                            }
                            else
                            {
                                strHold += strChar;
                                strLine += strChar;
                            }
                            System.Windows.Forms.Application.DoEvents();
                        }
                    }
                    else
                    {
                        for (Int64 lngCount = lngStart; lngCount < lngLength + 1; lngCount--)
                        {
                            strChar = yMessage.BODYTEXT.Substring((Int32)lngCount, 1);
                            if (strChar == " " || strChar == "\t" || strChar == Convert.ToChar(10).ToString() || strChar == Convert.ToChar(13).ToString() || strChar == Convert.ToChar(160).ToString())
                            {
                                strHold = strHold.Trim();
                                if (strHold.Length > 0)
                                {
                                    lngWords++;
                                    if (bNegStep)
                                        strHold = nTools.StrReverse(strHold);
                                    if (boolBrokerForum)
                                    {
                                        if (strHold.IndexOf("", 0) > 0)
                                        {
                                            boolInBracket = false;
                                            RollBF();
                                        }
                                        if (strHold.ToUpper().IndexOf("FOUND") > 0)
                                            boolInBracket = true;
                                    }
                                    if (IsPart(strHold, FilterString))
                                    {
                                        strHold = strHold.ToUpper();
                                        if (AddToArray(strHold))
                                        {
                                            lngPartsFound++;
                                            if (bNegStep)
                                                lngCount += 1 * -1;
                                            else
                                                lngCount += 1 * 1;
                                            GetMatches(strHold, lngCount, strLine);
                                            DoShouldStop(ref boolCancel);
                                            if (boolCancel)
                                                break;
                                        }
                                    }
                                    else if (nTools.IsEmailAddress(strHold))
                                    {
                                        if (boolRollingAddresses)
                                        {
                                            DoNewAddress();
                                            strHold = strHold.Replace(",", "");
                                            strHold = strHold.Replace("<", "");
                                            strHold = strHold.Replace(">", "");
                                            if (xSys.GetSetting_Boolean("emailsingleresponse"))
                                                FlushMessages();
                                            ActiveReplyAddress = strHold;
                                        }
                                    }
                                }
                                strHold = "";
                                if (strChar == Convert.ToChar(10).ToString())
                                    strLine = "";
                                else
                                {
                                    if (strChar == Convert.ToChar(13).ToString())
                                        strLine += strChar;
                                }
                            }
                            else
                            {
                                strHold += strChar;
                                strLine += strChar;
                            }
                            System.Windows.Forms.Application.DoEvents();
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
                catch (Exception ee)
                {
                    nStatus.SetStatus("Rz3_Common.EMailProcessor.void ProcessMessage(Enums.MailProcessType xProcessType) :" + ee.Message);
                    nError.HandleError(new nError.nErrorObject(ee.Message, "void ProcessMessage(Enums.MailProcessType xProcessType)", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void ProcessMessage(Enums.MailProcessType xProcessType)"));
                }
            }
            catch (Exception eee)
            {
                nStatus.SetStatus("Rz3_Common.EMailProcessor.void ProcessMessage(Enums.MailProcessType xProcessType) :" + eee.Message);
                nError.HandleError(new nError.nErrorObject(eee.Message, "void ProcessMessage(Enums.MailProcessType xProcessType)", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", eee.ToString(), "Rz3_Common.EMailProcessor.void ProcessMessage(Enums.MailProcessType xProcessType)"));
            }
            if (dMatches.Count > 0)
                SendEmailResponses();
            FlushMessages();
        }
        public void SendEmailResponses()
        {
            try
            {
                string subject = xSys.GetSetting("email_response_subject");
                string ccto = xSys.GetSetting("email_response_cc");
                foreach (KeyValuePair<String, Dictionary<String, partrecord>> kvp in dMatches)
                {
                    string email = kvp.Key;


                    if (!Tools.Strings.StrExt(email))
                        continue;
                    String HTML = GetResponseEMail(kvp.Value);
                    String strOriginal = yMessage.BODYTEXT;
                    if (strOriginal.IndexOf("<br>") <= 0)
                        strOriginal = strOriginal.Replace("\r\n", "<br>\r\n");
                    HTML = HTML.Replace("[ORIGINAL]", strOriginal);
                    nStatus.SetStatus("Sending match response to: " + email);

                    if (Environment.MachineName == "V4")
                    {
                        email = "test@recognin.com";
                        nEmailMessage m = new nEmailMessage();
                        Rz3App.xLogic.SetFromNotification(m);
                        m.ToAddress = email;
                        m.Subject = subject;
                        m.HTMLBody = HTML;
                        m.Send();
                    }
                    else
                    {
                        String err = "";
                        ToolsOffice.OutlookOffice.SendOutlookMessage(email, HTML, subject, false, false, ccto, "", true, null, "", "", "", "", ref err);
                    }
                }
            }
            catch { }
        }
        public Int64 GetMatches(String strHold, Int64 lngCount, String strLine)
        {
            try
            {

                if (nTools.GetControlKey())
                {
                    if (!Tools.Strings.StrExt(ActiveReplyAddress))
                        nStatus.TellUser("The active reply address appears to be blank.");
                    else
                        nStatus.TellUser("The active reply address appears to be: " + ActiveReplyAddress);
                }
                String WholeText = yMessage.BODYTEXT;
                if (Rz3App.xLogic.IsAAT)
                    CheckHotReqs(strHold);
                partrecord xPart = new partrecord(xSys);
                xPart.fullpartnumber = strHold;
                xPart.companyname = companyname;
                xPart.userdata_01 = CurrentMessageID;
                xPart.companyemailaddress = ActiveReplyAddress;
                xPart.user_defined = yMessage.SUBJECT;
                if (xSys.GetSetting_Boolean("savefullemail") && !xSys.GetSetting_Boolean("nativeemail"))
                    xPart.description = yMessage.BODYTEXT.Substring(0, 4000);
                if (yMessage.CONTENTSTYPE == Rz3_Common.Enums.MessageType.Offer)
                    xPart.isoffer = true;
                else
                {
                    xPart.isoffer = false;
                    xPart.stocktype = "Req";
                }
                String substringtest = WholeText.Substring(((Int32)lngCount - strLine.Length) - 1).Replace("\r\n", "\n");
                if (substringtest.StartsWith("\n"))
                    substringtest = substringtest.Substring(1);  //added the -1 above to grab the actual first character of the line.  if that screws up other messages the only issue would be an extra line break, which this filters
                //Int32 lngMark = substringtest.IndexOf("\r\n");//was just \n
                
                Int32 lngMark = substringtest.IndexOf("\n");//back to just \n

                if (lngMark > 0)
                {
                    String ThisLine = substringtest.Substring(0, lngMark);
                    ThisLine = ThisLine.Replace("&nbsp;", " ").Trim();

                    if (ThisLine.ToLower().Replace(" ", "").StartsWith("youshow"))
                        return 0;


                    if (ThisLine.ToLower().Replace(" ", "").StartsWith("-------------------------"))
                        return 0;

                    //-------------------------

                    ParseLine(xPart, ThisLine);
                    CurrentPart = xPart;
                    DoFoundPart(xPart, ActiveReplyAddress);
                    if (Rz3App.xLogic.IsLegend)
                        CheckForMatches(xPart, ActiveReplyAddress);
                }
                else
                {
                    DoFoundPart(xPart, ActiveReplyAddress);
                    if (Rz3App.xLogic.IsLegend)
                        CheckForMatches(xPart, ActiveReplyAddress);
                }
                if (boolBrokerForum)
                {
                    if (boolInBracket)
                        colBFStock.Add(xPart);
                    return 0;
                }
                else
                {
                    if (Tools.Strings.StrExt(xPart.fullpartnumber))
                        ReceiveEmailResult(xPart, ActiveReplyAddress, strLine);
                }
                return 0;
            }
            catch (Exception ee)
            {
                nStatus.SetStatus("Rz3_Common.EMailProcessor.Int64 GetMatches(String strHold, Int64 lngCount, String strLine) :" + ee.Message);
                nError.HandleError(new nError.nErrorObject(ee.Message, "Int64 GetMatches(String strHold, Int64 lngCount, String strLine)", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Int64 GetMatches(String strHold, Int64 lngCount, String strLine)"));
                return 0;
            }
        }
        public void ClearSettings()
        {
            BatchStart = DateTime.Now;
            lngRound = 0;
            TotalMessages = 0;
            TotalMatches = 0;
            TotalParts = 0;
            TotalMatchedResponses = 0;
            TotalUnmatchedResponses = 0;
            TotalUpdated = 0;
            TotalConfirm = 0;
        }
        public void HandleUnknown()
        {
            //try
            //{
            //    if (xSys.GetSetting_Boolean("nativeemail"))
            //        return;
            //    if (Tools.Strings.StrExt(xSys.GetSetting("forwardemailaddress")))
            //        ForwardOutlookMessage(yMessage.MESSAGEID, xInbox, xSys.GetSetting("forwardemailaddress"));
            //    nStatus.SetStatus("Moving Outlook Message...");
            //    String MoveToFolder = "Unread";
            //    MoveOutlookMessage(yMessage.MESSAGEID, xInbox, MoveToFolder);
            //}
            //catch (Exception ee)
            //{
            //    nError.HandleError(new nError.nErrorObject(ee.Message, "void HandleUnknown", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void HandleUnknown"));
            //}
        }
        public void LoadRestrictions()
        {
            try
            {
                nStatus.SetStatus("Loading The Source Address Restrictions...");
                String strSQL = "SELECT * FROM ADDRESSHANDLER WHERE (SCANCOMPANY = 0 or SCANCOMPANY IS NULL) and SOURCEDEST <> 'DEST'";
                colSourceRestrictions = xSys.QtC("addresshandler", strSQL);
                nStatus.SetStatus("Loading The Destination Address Restrictions...");
                strSQL = "SELECT * FROM ADDRESSHANDLER WHERE (SCANCOMPANY = 0 or SCANCOMPANY IS NULL) and SOURCEDEST = 'DEST'";
                colDestRestrictions = xSys.QtC("addresshandler", strSQL);
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "void LoadRestrictions", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void LoadRestrictions"));
            }
        }
        public String GetType(String strIn, Int64 lngPosition, ref Int64 lngStrength, ref String filteredresponse, ref Boolean number, ref Boolean dbl, ref LineParseInfo info)
        {
            try
            {
                number = false;
                dbl = false;
                String strPrefix = "";
                String strBase = "";
                PartObject.ParsePartNumber(strIn, ref strPrefix, ref strBase);
                //Part Number  removed below because the partnumber is already a part of the match object
                //besides, ITEMNUMBER is not the field FULLPARTNUMBER is
                //if (lngPosition < 3 && strBase.Length > 0) //&& strPrefix.Length > 0 (removed because ALOT of parts do not have a prefix
                //{
                //    lngStrength = 65;
                //    return "ITEMNUMBER";
                //}
                //Part Package (DIP, PLCC, etc.)
                if (PartObject.IsPartPackageSetup(strIn) && !info.PARTSETUP)
                {
                    info.PARTSETUP = true;
                    lngStrength = 65;
                    return "PARTSETUP";
                }
                //Manufacturer  removed (lngPosition > 0 &&) from the bottom comparison, had an email
                //where Mfg was in the first row... go figure
                if (lngPosition < 6 && strIn.Length > 1 && strIn.Length < 10 && IsTotalString(strIn, "ABC") && !Tools.Strings.StrCmp(strIn, "qty") && !info.MANUFACTURER)
                {
                    info.MANUFACTURER = true;
                    lngStrength = 65;
                    return "MANUFACTURER";
                }
                //DateCode
                if (strIn.IndexOf("+") > 0 && !info.DATECODE)
                {
                    info.DATECODE = true;
                    lngStrength = 65;
                    return "DATECODE";
                }
                if (lngPosition == 3 && strIn.Length == 4 && IsTotalString(strIn.Replace("+", ""), "123") && strIn.Substring(strIn.Length - 2) != "00" && !info.DATECODE)
                {
                    info.DATECODE = true;
                    lngStrength = 65;
                    return "DATECODE";
                }
                //Price
                if (lngPosition > 2 && strIn.IndexOf(".") > 0 && IsTotalString(strIn.Replace(".", "").Replace("$", ""), "123") && !info.MATCHPRICE)
                {
                    info.MATCHPRICE = true;
                    number = true;
                    dbl = true;
                    lngStrength = 65;
                    return "MATCHPRICE";
                }
                //Check for price with a comma for period
                if (lngPosition > 2 && strIn.IndexOf(",") > 0 && IsTotalString(strIn.Replace(",", "").Replace("$", ""), "123"))
                {
                    Int32 i = Tools.Strings.Split(strIn.Trim(), ",").Length;
                    if (i == 2)
                    {
                        strIn = strIn.Replace(",", ".");
                        if (lngPosition > 2 && strIn.IndexOf(".") > 0 && IsTotalString(strIn.Replace(".", "").Replace("$", ""), "123") && !info.MATCHPRICE)
                        {
                            info.MATCHPRICE = true;
                            lngStrength = 65;
                            filteredresponse = strIn;
                            number = true;
                            dbl = true;
                            return "MATCHPRICE";
                        }
                    }
                }
                //Quantity removed (lngPosition > 1 && ) from below, an email had qty first row
                if (Tools.Number.IsNumeric(strIn) && !info.QUANTITY)
                {
                    if (strIn.StartsWith("0")) //Possibly DateCode
                    {
                        if (strIn.Length > 1 && strIn.Length < 5 && !info.DATECODE)//Assume DateCode
                        {
                            info.DATECODE = true;
                            lngStrength = 65;
                            return "DATECODE";
                        }
                    }
                    info.QUANTITY = true; 
                    lngStrength = 65;
                    number = true;
                    return "QUANTITY";
                }
                lngStrength = 100;
                return "UNKNOWN";
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "String GetType(String strIn, Int64 lngPosition, ref Int64 lngStrength, ref String filteredresponse, ref Boolean number, ref Boolean dbl)", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.String GetType(String strIn, Int64 lngPosition, ref Int64 lngStrength, ref String filteredresponse, ref Boolean number, ref Boolean dbl)"));
                lngStrength = 100;
                return "UNKNOWN";
            }
        }
        public Boolean IsPart(String PartString, String ExcludeString)
        {
            try
            {
                String strBase = "";
                String strPrefix = "";
                Boolean boolInclude = false;
                PartString = PartString.Trim().ToUpper();
                FilterSingleCharacters(PartString, ExcludeString, ref boolInclude);
                if (boolInclude)
                    return false;
                if (PartString.IndexOf(".COM") > 0)
                    return false;
                if (PartString.IndexOf(".NET") > 0)
                    return false;
                if (PartString.IndexOf("DAY") > 0)
                    return false;
                if (PartString.IndexOf("D/C") > 0)
                    return false;
                if (PartString.Length > 2)
                    if (PartString.Substring(PartString.Length - 2) == "EA")
                        return false;
                if (PartString.IndexOf("AREA") > 0)
                    return false;
                String strStart = PartString.Substring(0, 1);
                if (Tools.Strings.StrCmp(strStart, "/"))
                    return false;
                if (Tools.Strings.StrCmp(strStart, "\\"))
                    return false;

                //changed for mati 2009_09_30
                //if (CharCount(PartString, ".") > 1)
                //    return false;
                //if (CharCount(PartString, "-") > 1)
                //    return false;

                if (CharCount(PartString, ".") > 4)
                    return false;
                if (CharCount(PartString, "-") > 4)
                    return false;

                if (NumberMix(PartString.Replace("-", "").Replace(".", "").Replace("/", "")) >= 100)
                    return false;
                if (CharCount(PartString, "/") > 1)
                    return false;
                if (CharCount(PartString, "\\") > 1)
                    return false;
                if (NumberMix(PartString.Replace("/", "")) >= 100)
                    return false;
                if (NumberMix(PartString.Replace("\\", "")) >= 100)
                    return false;
                if (PartString.Trim().Length == 5 && Tools.Number.IsNumeric(PartString.Trim()))
                    return false;
                PartObject.ParsePartNumber(PartString, ref strPrefix, ref strBase);
                Int64 lngNumberMix = NumberMix(PartString);
                if (strPrefix.Length >= 0 && strPrefix.Length < 6 && strBase.Length >= 2 || (lngNumberMix > 10 && lngNumberMix < 100 && PartString.Length > 5))
                {
                    if (PartString.ToUpper().IndexOf("HTTP:") > 0 || PartString.ToUpper().IndexOf("PHONE") > 0 || PartString.ToUpper().IndexOf("$") > 0 || PartString.ToUpper().IndexOf(":") > 0 || PartString.ToUpper().IndexOf("@") > 0 || PartString.ToUpper().IndexOf("(") > 0 || PartString.ToUpper().IndexOf(")") > 0)
                        return false;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Boolean IsPart(String PartString, String ExcludeString)", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Boolean IsPart(String PartString, String ExcludeString)"));
                return false;
            }
        }
        public Int64 CharCount(String strIn, String strSeek)
        {
            Int64 lne = 1;
            try
            {
                Int64 lngCounter = 0;
                lne++;
                Char[] ary = strIn.ToCharArray();
                lne++;
                foreach (char strChar in ary)
                {
                    if (Tools.Strings.StrCmp(strChar.ToString(), strSeek))
                        lngCounter++;
                }
                lne++;
                return lngCounter;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Int64 CharCount(String strIn, String strSeek)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Int64 CharCount(String strIn, String strSeek)"));
                return 0;
            }
        }
        public Int64 NumberMix(String strIn)
        {
            Int64 lne = 1;
            try
            {
                Int64 lngAlpha = 0;
                lne++;
                Int64 lngNumber = 0;
                lne++;
                Char[] ary = strIn.ToCharArray();
                lne++;
                foreach (char strChar in ary)
                {
                    lne = 5;
                    if (Tools.Number.IsNumeric(strChar.ToString()))
                    {
                        lne = 6;
                        lngNumber++;
                    }
                    else
                    {
                        lne = 7;
                        lngAlpha++;
                    }
                }
                lne++;
                if (strIn.Length <= 0)
                {
                    lne++;
                    return 0;
                }
                lne++;
                Int64 returnnumb = ((lngNumber / (Int64)strIn.Length) * 100);
                lne++;
                return returnnumb;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Int64 NumberMix(String strIn)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Int64 NumberMix(String strIn)"));
                return 0;
            }
        }
        public Int64 StringCount(String InString, String CountString)
        {
            Int64 lne = 1;
            try
            {
                Int64 lngHold = 0;
                lne++;
                Char[] ary = InString.ToCharArray();
                lne++;
                foreach (char strChar in ary)
                {
                    lne = 4;
                    if (Tools.Strings.StrCmp(strChar.ToString(), CountString))
                    {
                        lne = 5;
                        lngHold++;
                    }
                }
                lne++;
                return lngHold;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Int64 StringCount(String InString, String CountString)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Int64 StringCount(String InString, String CountString)"));
                return 0;
            }
        }
        public String FilterSingleCharacters(String strIn, String strExclude, ref Boolean boolIncludes)
        {
            Int64 lne = 1;
            try
            {
                boolIncludes = false;
                lne++;
                String strHold = strIn;
                lne++;
                String strProduct = "";
                lne++;
                Char[] ary = strHold.ToCharArray();
                lne++;
                foreach (char strChar in ary)
                {
                    lne = 6;
                    Char[] ary2 = strExclude.ToCharArray();
                    lne = 7;
                    foreach (char strChar2 in ary2)
                    {
                        lne = 8;
                        if (Tools.Strings.StrCmp(strChar.ToString(), strChar2.ToString()))
                        {
                            lne = 9;
                            boolIncludes = true;
                            lne = 10;
                            return strProduct;
                        }
                    }
                    lne = 11;
                    strProduct += strChar.ToString();
                }
                lne++;
                return strProduct;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "String FilterSingleCharacters(String strIn, String strExclude, ref Boolean boolIncludes)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.String FilterSingleCharacters(String strIn, String strExclude, ref Boolean boolIncludes)"));
                return "";
            }
        }
        public String GetProcessType(String strAddress)
        {
            Int64 lne = 1;
            try
            {
                Int64 lngMark = strAddress.IndexOf("@");
                lne++;
                if (lngMark <= 0)
                {
                    lne++;
                    return "";
                }
                lne++;
                String strHead = strAddress.Substring((Int32)lngMark - 1).Trim();
                lne++;
                String strDomain = strAddress.Substring(0, (Int32)lngMark).Trim();
                lne++;
                if (Tools.Strings.StrCmp(strDomain, "*"))
                {
                    lne++;
                    return strHead.ToUpper().Trim();
                }
                lne++;
                String strSQL = "SELECT * FROM ADDRESSHANDLERTABLE WHERE EMAILADDRESS = '" + strAddress + "'";
                lne++;
                DataTable dt = xSys.xData.GetDataTable(strSQL);
                lne++;
                if (dt == null)
                {
                    lne++;
                    return GetFuzzyProcessType(strDomain);
                }
                lne++;
                if (dt.Rows.Count <= 0)
                {
                    lne++;
                    return GetFuzzyProcessType(strDomain);
                }
                lne++;
                return dt.Rows[0]["HANDLERTAGS"].ToString();
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "String GetProcessType(String strAddress)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.String GetProcessType(String strAddress)"));
                return "";
            }
        }
        public String GetFuzzyProcessType(String strFuzzy)
        {
            Int64 lne = 1;
            try
            {
                String strSQL = "SELECT * FROM ADDRESSHANDLERTABLE WHERE EMAILADDRESS = '*" + strFuzzy + "'";
                lne++;
                DataTable dt = xSys.xData.GetDataTable(strSQL);
                lne++;
                if (dt == null)
                {
                    lne++;
                    return "";
                }
                lne++;
                if (dt.Rows.Count <= 0)
                {
                    lne++;
                    return "";
                }
                lne++;
                return dt.Rows[0]["HANDLERTAGS"].ToString();
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "String GetFuzzyProcessType(String strFuzzy)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.String GetFuzzyProcessType(String strFuzzy)"));
                return "";
            }
        }
        public Object GetRestriction(ArrayList colSourceRestrictions, ArrayList colDestRestrictions, ref Boolean boolCool)
        {
            Int64 lne = 1;
            try
            {
                addresshandler h = null;
                lne++;
                //Source
                h = ContainsAddress(yMessage, colSourceRestrictions, false, false);
                lne++;
                if (h != null)
                {
                    lne++;
                    return h;
                }
                lne++;
                //Dest
                h = ContainsAddress(yMessage, colDestRestrictions, true, false);
                lne++;
                if (h != null)
                {
                    lne++;
                    return h;
                }
                lne++;
                //Source Fuzzy
                h = ContainsAddress(yMessage, colDestRestrictions, false, true);
                lne++;
                if (h != null)
                {
                    lne++;
                    return h;
                }
                lne++;
                h = ContainsAddress(yMessage, colSourceRestrictions, false, true);
                lne++;
                if (h != null)
                {
                    lne++;
                    return h;
                }
                lne++;
                //Dest Fuzzy
                h = ContainsAddress(yMessage, colDestRestrictions, true, true);
                lne++;
                if (h != null)
                {
                    lne++;
                    return h;
                }
                lne++;
                return h;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Object GetRestriction(ArrayList colSourceRestrictions, ArrayList colDestRestrictions, ref Boolean boolCool)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Object GetRestriction(ArrayList colSourceRestrictions, ArrayList colDestRestrictions, ref Boolean boolCool)"));
                return null;
            }
        }
        public Boolean IsBrokerForum(String strSubject)
        {
            Int64 lne = 1;
            try
            {
                if (xSys.GetSetting_Boolean("emailonlyreqs"))
                {
                    lne++;
                    return false;
                }
                else
                {
                    lne++;
                    return Tools.Strings.StrCmp(strSubject, "The Broker Forum - Exact Match");
                }
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Boolean IsBrokerForum(String strSubject)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Boolean IsBrokerForum(String strSubject)"));
                return false;
            }
        }
        public void RollBF()
        {
            Int64 lne = 1;
            try
            {
                foreach (req xReq in colBFReqs)
                {
                    lne = 2;
                    if (!xReq.ISave())
                    {
                        lne = 3;
                        nStatus.TellUser("There was an error saving a requirement.");
                    }
                    else
                    {
                        lne = 4;
                        if (nTools.GetControlKey())
                        {
                            lne = 5;
                            nStatus.TellUser("The req '" + xReq.fullpartnumber + "' was saved.");
                        }
                    }
                    lne = 6;
                    foreach (partrecord xStock in colBFStock)
                    {
                        lne = 7;
                        emailmatch xMatch = new emailmatch(xSys);
                        lne = 8;
                        xMatch.fullpartnumber = xStock.fullpartnumber;
                        lne = 9;
                        xMatch.datecode = xStock.datecode;
                        lne = 10;
                        xMatch.requiredpart = xReq.fullpartnumber;
                        lne = 11;
                        xMatch.requiredquantity = xReq.targetquantity;
                        lne = 12;
                        xMatch.requirementid = xReq.unique_id;
                        lne = 13;
                        xMatch.sourceaddress = xStock.companyemailaddress;
                        lne = 14;
                        if (!xMatch.ISave())
                        {
                            lne = 15;
                            nStatus.TellUser("There was an error saving an email match.");
                        }
                        else
                        {
                            lne = 16;
                            if (nTools.GetControlKey())
                            {
                                lne = 17;
                                nStatus.TellUser("The email match '" + xStock.fullpartnumber + "' was saved.");
                            }
                        }
                    }
                }
                lne++;
                colBFReqs = new ArrayList();
                lne++;
                colBFStock = new ArrayList();
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "void RollBF()", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void RollBF()"));
            }
        }
        public void ReceiveMessages_Internal()
        {
            ReceiveMessages_Internal(false);
        }
        public void ReceiveMessages_Internal(Boolean boolTemp)
        {
            //Dim xServer As New emailserver
            //Dim xMessage As EmailMessage
            //Dim yMessage As Object
            //Dim strCool As String
            //Set xReceiver = New EmailReceiver
            //If boolTemp Then
            //    Set xReceiver.MessageCollection = xReceiver.GetTempEmails()
            //    Else
            //    Call ClearTempFolder
            //    xServer.ServerName = xRz2.SysSettings.emailserver
            //    xServer.UserName = xRz2.SysSettings.emailuser
            //    xServer.Password = xRz2.SysSettings.emailpassword
            //    Set xReceiver.xSocket = frmEMailProcess.xSocket
            //    Call xReceiver.DoFullReceive(xServer)
            //End If
            //For Each xMessage In xReceiver.MessageCollection
            //    Set yMessage = xRz2.MakeObject("MESSAGE")
            //    yMessage.fromaddresstext = xMessage.FromAddress
            //    yMessage.SUBJECT = xMessage.SUBJECT
            //    yMessage.BODYTEXT = xMessage.Body
            //    yMessage.bodyhtml = xMessage.bodyhtml
            //    yMessage.messagedate = xMessage.DateReceived
            //    If yMessage.messagedate <= CDate("01/02/1900") Then
            //        yMessage.messagedate = Now
            //    End If
            //    If Not yMessage.ISave(strCool) Then
            //        If xTools.GetControlKey() Then
            //            Call xRz2.MessageBox("Message Save Error:" & vbCrLf & strCool)
            //        End If
            //    End If
            //Next xMessage
        }
        //public void ForwardOutlookMessage(String MESSAGEID, Outlook.MAPIFolder xInbox, String strAddress)
        //{
        //    Int64 lne = 1;
        //    try
        //    {
        //        Outlook.Items emails = xInbox.Items;
        //        lne = 2;
        //        for (Int32 i = 1; i <= emails.Count; i++)
        //        {
        //            lne = 3;
        //            Outlook.MailItem xItem = (Outlook.MailItem)emails[i];
        //            lne = 4;
        //            if (Tools.Strings.StrCmp(xItem.EntryID, MESSAGEID))
        //            {
        //                lne = 5;
        //                xItem.To = strAddress;
        //                lne = 6;
        //                xItem.Send();
        //            }
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        nError.HandleError(new nError.nErrorObject(ee.Message, "void ForwardOutlookMessage(String MESSAGEID, Outlook.MAPIFolder xInbox, String strAddress)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void ForwardOutlookMessage(String MESSAGEID, Outlook.MAPIFolder xInbox, String strAddress)"));
        //    }
        //}


        //private Boolean WillDateFail(Outlook.MailItem xItem)
        //{
        //    try
        //    {
        //        DateTime dt = xItem.SentOn;
        //        return false;
        //    }
        //    catch
        //    {
        //        return true;
        //    }
        //}
        //private Boolean WillDateFail_Post(Outlook.PostItem xItem)
        //{
        //    try
        //    {
        //        DateTime dt = xItem.SentOn;
        //        return false;
        //    }
        //    catch
        //    {
        //        return true;
        //    }
        //}
        private Boolean ShouldMove(EMailMessageOld xMessage, ArrayList colSource)
        {
            Int64 lne = 1;
            try
            {
                if (colSource == null)
                {
                    lne++;
                    return false;
                }
                lne++;
                if (colSource.Count <= 0)
                {
                    lne++;
                    return false;
                }
                lne++;
                foreach (addresshandler xHandler in colSource)
                {
                    lne = 6;
                    if (Tools.Strings.StrCmp(xHandler.emailaddress, xMessage.FromAddress.addressstring))
                    {
                        lne = 7;
                        if (xHandler.handlertags.ToLower().StartsWith("move"))
                        {
                            lne = 8;
                            return true;
                        }
                    }
                }
                lne++;
                return false;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Boolean ShouldMove(EMailMessageOld xMessage, ArrayList colSource)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Boolean ShouldMove(EMailMessageOld xMessage, ArrayList colSource)"));
                return false;
            }
        }
        //private void MoveOutlookMessage(String MESSAGEID, Outlook.MAPIFolder xInbox, String MoveToFolder)
        //{
        //    Int64 lne = 1;
        //    try
        //    {
        //        Outlook.MAPIFolder yFolder = xInbox.Folders[MoveToFolder];
        //        lne++;
        //        Outlook.Items emails = xInbox.Items;
        //        lne++;
        //        for (Int32 i = 1; i <= emails.Count; i++)
        //        {
        //            lne = 4;
        //            Outlook.MailItem xItem = (Outlook.MailItem)emails[i];
        //            lne = 5;
        //            if (Tools.Strings.StrCmp(xItem.EntryID, MESSAGEID))
        //            {
        //                lne = 6;
        //                xItem.Move(yFolder);
        //                lne = 7;
        //                return;
        //            }
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        nError.HandleError(new nError.nErrorObject(ee.Message, "void MoveOutlookMessage(String MESSAGEID, Outlook.MAPIFolder xInbox, String MoveToFolder)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void MoveOutlookMessage(String MESSAGEID, Outlook.MAPIFolder xInbox, String MoveToFolder)"));
        //    }
        //}
        private void CheckRecognizFolders(OutlookMAPIFolder xFolder)
        {
            try
            {
                if (!xFolder.FolderExists("Recogniz"))
                    xFolder.FolderAdd("Recogniz", "");
                OutlookMAPIFolder xRecogniz = xFolder.FolderGet("Recogniz");
                if (!xRecogniz.FolderExists("Scanned"))
                    xRecogniz.FolderAdd("Scanned", "");
                if (!xRecogniz.FolderExists("Unread"))
                    xRecogniz.FolderAdd("Unread", "");
                if (!xRecogniz.FolderExists("Temp"))
                    xRecogniz.FolderAdd("Temp", "");
            }
            catch (Exception ee)
            {
            }
        }


        private void DeleteThisMessage()
        {
            try
            {
                if (!Tools.Strings.StrExt(yMessage.MESSAGEID))
                    return;

                if (xSys.GetSetting_Boolean("nativeemail"))
                    return;
                nStatus.SetStatus("Moving Outlook Message...");
                ToolsOffice.OutlookOffice.DeleteOutlookMessage(yMessage.MESSAGEID, xInbox);
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "void DeleteThisMessage()", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void DeleteThisMessage()"));
            }
        }


        private void DeleteMatches()
        {
            Int64 lne = 1;
            try
            {
                String strSQL = "DELETE FROM EMAILMATCHTABLE WHERE MESSAGEID = '" + yMessage.UniqueID + "' AND MATCHTEXT <> 'FOUND'";
                lne++;
                xSys.xData.Execute(strSQL, false, true);
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "void DeleteMatches()", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void DeleteMatches()"));
            }
        }
        private void FoundPart(partrecord xMatch, String strAddress, String strSource)
        {
            Int64 lne = 1;
            try
            {
                TotalParts++;
                lne++;
                MessageParts++;
                lne++;
                DoFoundInfo(xMatch.fullpartnumber, strAddress, "PART");
                lne++;
                DoFoundPart(xMatch, strSource);
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "void FoundPart(partrecord xMatch, String strAddress, String strSource)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void FoundPart(partrecord xMatch, String strAddress, String strSource)"));
            }
        }
        private void GotMatch(DataTable rst, String strAddress, String strDesc, String strType)
        {
        }
        private String GetVendor(DataTable rst)
        {
            Int64 lne = 1;
            try
            {
                return rst.Rows[0]["vendor"].ToString();
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "String GetVendor(DataTable rst)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.String GetVendor(DataTable rst)"));
                return "";
            }
        }
        private Int64 GetReqQty(String strID, String strItem, String strDate, String strType)
        {
            Int64 lne = 1;
            try
            {
                String strSQL = "SELECT * FROM EMAILMATCHTABLE WHERE MESSAGEID = '" + strID + "' AND ITEMNUMBER = '" + strItem + "' AND MATCHDATE = '" + strDate + "' AND OFFERREQTYPE = 'REQ' AND MATCHTEXT = 'FOUND'";
                lne++;
                DataTable rst = xSys.xData.GetDataTable(strSQL);
                lne++;
                return nData.NullFilter_Int64(rst.Rows[0]["quantity"]);
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Int64 GetReqQty(String strID, String strItem, String strDate, String strType)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Int64 GetReqQty(String strID, String strItem, String strDate, String strType)"));
                return 0;
            }
        }
        private String ParseDynamic(String strIn)
        {
            Int64 lne = 1;
            try
            {
                String strHold = "";
                lne++;
                Char[] strExclude = ((String)"/()-.\\").ToCharArray();
                lne++;
                foreach (char strChar in strExclude)
                {
                    lne = 4;
                    strHold = ReplaceDynamic(strIn, strChar.ToString());
                }
                lne++;
                return strHold;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "String ParseDynamic(String strIn)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.String ParseDynamic(String strIn)"));
                return strIn;
            }
        }
        private String ReplaceDynamic(String strIn, String strFind)
        {
            Int64 lne = 1;
            try
            {
                Int32 lngMark = strIn.IndexOf(strFind);
                lne++;
                if (lngMark == 0)
                {
                    lne++;
                    return strIn;
                }
                lne++;
                return strIn.Substring((Int32)lngMark - 1) + "%";
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "String ReplaceDynamic(String strIn, String strFind)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.String ReplaceDynamic(String strIn, String strFind)"));
                return strIn;
            }
        }
        private Int64 MultiLine(String strQuote)
        {
            Int64 lne = 1;
            try
            {
                String strHold = "";
                lne = 2;
                for (Int64 lngCount = 1; lngCount < 100001; lngCount++)
                {
                    lne = 3;
                    strHold = Tools.Strings.ParseDelimit(strQuote, ",Q", (Int32)lngCount);
                    lne = 4;
                    if (Tools.Strings.StrCmp(strHold, "%%EOF%%"))
                    {
                        lne = 5;
                        if (lngCount <= 2)
                        {
                            lne = 6;
                            return 1;
                        }
                        lne = 7;
                        return lngCount - 1;
                    }
                }
                lne = 8;
                return 1;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Int64 MultiLine(String strQuote)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Int64 MultiLine(String strQuote)"));
                return 1;
            }
        }
        private void RecordJoin(nObject xObject, DataTable rst, String strProperty, String strFieldName)
        {
            Int64 lne = 1;
            try
            {
                String strField = "";
                lne++;
                if (Tools.Strings.StrExt(strFieldName))
                {
                    lne++;
                    strField = strFieldName;
                }
                else
                {
                    lne++;
                    strField = strProperty;
                }
                lne++;
                String altProp = strProperty;
                lne++;
                if (Tools.Strings.StrCmp(altProp, "QUANTITYAVA"))
                {
                    lne++;
                    altProp = "QUANTITY";
                }
                lne++;
                xObject.ISet(altProp, rst.Rows[0][strField]);
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "void RecordJoin(nObject xObject, DataTable rst, String strProperty, String strFieldName)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void RecordJoin(nObject xObject, DataTable rst, String strProperty, String strFieldName)"));
            }
        }
        private void ParseLine(partrecord xMatch, String strLine)
        {
            try
            {
                if (xMatch == null)
                {
                    nStatus.SetStatus("ParseLine: (xMatch == null)");
                    return;
                }
                String strNxtColumn = "";
                Int64 lngWords = 0;
                String strHold = "";
                Int64 lngStrength = 0;
                Char[] ary = strLine.ToCharArray();
                foreach (char strChar in ary)
                {
                    try
                    {
                        if (Tools.Strings.StrCmp(strChar.ToString(), " ") || Tools.Strings.StrCmp(strChar.ToString(), "\t"))
                        {
                            if (Tools.Strings.StrExt(strHold))
                            {
                                if (lngWords < 49)
                                {
                                    aryWords[lngWords] = strHold;
                                    lngWords++;
                                }
                                strHold = "";
                            }
                        }
                        else
                            strHold += strChar.ToString();
                    }
                    catch { nStatus.SetStatus("foreach (char strChar in ary)"); }
                }
                if (Tools.Strings.StrExt(strHold))
                    aryWords[lngWords] = strHold;
                Int64 lngPos = 1;
                LineParseInfo info = new LineParseInfo();
                for (Int64 lngCount = 0; lngCount <= lngWords; lngCount++)
                {
                    try
                    {
                        String filteredresponse = "";
                        Boolean number = false;
                        Boolean dbl = false;
                        String wordcheck = aryWords[lngCount];
                        String strType = GetType(aryWords[lngCount], lngCount + 1, ref lngStrength, ref filteredresponse, ref number, ref dbl, ref info);
                        switch (strType.ToUpper())
                        {
                            case "DESCRIPTION":
                                strNxtColumn = aryHeaders[lngPos, 1];
                                break;
                            default:
                                if (Tools.Strings.StrCmp(strType, "matchprice"))
                                    strType = "PRICE";
                                if (!Tools.Strings.StrCmp(strType, "unknown"))
                                {
                                    Object o = xMatch.IGet(strType);
                                    if (o != null)
                                    {
                                        String obj = "";
                                        try
                                        {
                                            obj = o.ToString();
                                            obj = obj.Replace("0", "").Replace(".", "");
                                            if (Tools.Strings.StrExt(obj))
                                                continue;
                                        }
                                        catch { }
                                    }
                                }
                                String value = aryWords[lngCount];
                                if (Tools.Strings.StrExt(filteredresponse))
                                    value = filteredresponse;
                                if (number)
                                {
                                    if (dbl)
                                    {
                                        Double din = 0;
                                        try
                                        {
                                            value = StripToDouble(value);
                                            din = Double.Parse(value.Trim());
                                            xMatch.ISet(strType, din);
                                        }
                                        catch { }
                                    }
                                    else
                                    {
                                        Int64 iin = 0;
                                        try
                                        {
                                            iin = Int64.Parse(value.Trim());
                                            xMatch.ISet(strType, iin);
                                        }
                                        catch { }
                                    }
                                }
                                else
                                    xMatch.ISet(strType, value);
                                if (Tools.Strings.StrCmp(strType, "UNKNOWN"))
                                    break;
                                break;
                        }
                    }
                    catch { nStatus.SetStatus("for (Int64 lngCount = 0; lngCount < lngWords; lngCount++)"); }
                }
            }
            catch (Exception ee)
            {
                nStatus.SetStatus("Error ParseLine: " + ee.Message);
                nError.HandleError(new nError.nErrorObject(ee.Message, "void ParseLine(partrecord xMatch, String strLine)", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void ParseLine(partrecord xMatch, String strLine)"));
            }
        }
        private Int64 CountResults(String strSQL)
        {
            Int64 lne = 1;
            try
            {
                DataTable rst = xSys.xData.GetDataTable(strSQL);
                lne++;
                return nData.NullFilter_Int64(rst.Rows[0]["ASNAME"]);
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Int64 CountResults(String strSQL)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Int64 CountResults(String strSQL)"));
                return 0;
            }
        }
        private Boolean AddToArray(String strIn)
        {
            Int64 lne = 1;
            try
            {
                foreach (String s in MessagePartArray)
                {
                    lne = 2;
                    if (Tools.Strings.StrCmp(s, strIn))
                    {
                        lne = 3;
                        return false;
                    }
                }
                lne = 4;
                return true;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Boolean AddToArray(String strIn)", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.Boolean AddToArray(String strIn)"));
                return false;
            }
        }
        //Left off with Error Handling
        private company GetCompanyFromList()
        {
            try
            {
                String strAddress = ActiveReplyAddress.Trim();
                if (!Tools.Strings.StrExt(strAddress))
                    return null;
                String strSQL = "SELECT * FROM COMPANYEMAIL WHERE EMAILADDRESS LIKE '%" + strAddress + "%'";
                companyemail email = (companyemail)xSys.QtO("companyemail", strSQL);
                if (email == null)
                {
                    email = new companyemail(xSys);
                    email.emailaddress = strAddress;
                    email.ISave();
                }
                company comp = new company(xSys);
                comp.primaryemailaddress = email.emailaddress;
                return comp;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return null;
            }
        }
        private Boolean IsHeaderLine(String strLine)
        {
            try
            {
                String strHeaderType = "";
                Int64 lngCount = 1;
                Int64 lngScore = 0;
                Int64 lngPlace = 1;
                String strHold = "";
                Boolean bHeader = false;
                while (!Tools.Strings.StrCmp(strHold, "%%EOF%%"))
                {
                    strHold = Tools.Strings.ParseDelimit(strLine, " ", (Int32)lngCount).Trim();
                    if (!Tools.Strings.StrExt(strHold))
                    {
                        lngCount++;
                        continue;
                    }
                    if (!Tools.Strings.StrCmp(strHold, "%%EOF%%"))
                        continue;
                    if (CheckHeaderStrings(strHold, ref strHeaderType))
                        lngScore++;
                    else
                        lngScore--;
                    lngCount++;
                }
                if (lngScore > -3)
                {
                    lngCount = 1;
                    while (!Tools.Strings.StrCmp(strHold, "%%EOF%%"))
                    {
                        strHold = Tools.Strings.ParseDelimit(strLine, " ", (Int32)lngCount).Trim();
                        if (!Tools.Strings.StrExt(strHold))
                            continue;
                        if (!Tools.Strings.StrCmp(strHold, "%%EOF%%"))
                            continue;
                        if (CheckHeaderStrings(strHold, ref strHeaderType))
                        {
                            if (Tools.Strings.StrCmp(strHeaderType, "IGNORE"))
                            {
                                lngCount++;
                                continue;
                            }
                            aryHeaders[lngPlace, 1] = strHeaderType;
                            aryHeaders[lngPlace, 2] = lngPlace.ToString();
                            bHeader = true;
                            lngPlace = lngPlace + 1;
                            lngCount++;
                            continue;
                        }
                        lngPlace++;
                        lngCount++;
                    }
                    return true;
                }
                return bHeader;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return false;
            }
        }
        private Boolean CheckHeaderStrings(String strHold, ref String strHeaderType)
        {
            try
            {
                LoadHeaderAry();
                for (Int32 lngCount = 1; lngCount < aryHeaderTypes.GetUpperBound(0); lngCount++)
                {
                    for (Int32 lngNext = 1; lngNext < aryHeaderTypes.GetUpperBound(1); lngNext++)
                    {
                        if (strHold.ToUpper().IndexOf(aryHeaderTypes[lngCount, lngNext]) > 0)
                        {
                            if (Tools.Strings.StrCmp(aryHeaderTypes[lngCount, lngNext], ""))
                                continue;
                            strHeaderType = GetHType(lngCount);
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return false;
            }
        }
        private void LoadHeaderAry()
        {
            try
            {
                //***** Part Headers
                aryHeaderTypes[1, 1] = "PART";
                aryHeaderTypes[1, 2] = "ITEM";
                aryHeaderTypes[1, 3] = "NEED:";
                //***** Quantity Headers
                aryHeaderTypes[2, 1] = "QUANTITY";
                aryHeaderTypes[2, 2] = "QTY";
                //***** DateCode Headers
                aryHeaderTypes[3, 1] = "DATECODE";
                aryHeaderTypes[3, 2] = "D/C";
                aryHeaderTypes[3, 3] = "DC";
                //***** Price Headers
                aryHeaderTypes[4, 1] = "PRICE";
                aryHeaderTypes[4, 2] = "PR";
                aryHeaderTypes[4, 3] = "COST";
                //***** Condition Headers
                aryHeaderTypes[5, 1] = "COND";
                aryHeaderTypes[5, 2] = "CONDITION";
                //***** Manufacturer Headers
                aryHeaderTypes[6, 1] = "MFG";
                aryHeaderTypes[6, 2] = "MNF";
                aryHeaderTypes[6, 3] = "MANUFACTURER";
                //***** Description Headers
                aryHeaderTypes[7, 1] = "DESCRIPTION";
                aryHeaderTypes[7, 2] = "DESCR";
                //***** Number Headers
                aryHeaderTypes[8, 1] = "NO";
                aryHeaderTypes[8, 2] = "NUMBER";
                aryHeaderTypes[8, 3] = "#";
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private String GetHType(Int64 lngType)
        {
            try
            {
                switch (lngType)
                {
                    case 1:
                        return "ITEMNUMBER";
                    case 2:
                        return "QUANTITY";
                    case 3:
                        return "DATECODE";
                    case 4:
                        return "PRICE";
                    case 5:
                        return "CONDITION";
                    case 6:
                        return "MANUFACTURER";
                    case 7:
                        return "DESCRIPTION";
                    default:
                        return "IGNORE";
                }
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return "IGNORE";
            }
        }
        private void CheckHotReqs(String strPart)
        {
            try
            {
                String strPrefix = "";
                String strBase = "";
                if (colHotReqs == null || ((Tools.Misc.GetTicks() - lngLastHotReq) > (60000 * 10)))
                    CacheHotReqs();
                PartObject.ParsePartNumber(strPart, ref strPrefix, ref strBase);
                strBase = PartObject.StripPart(strBase);
                if (!Tools.Strings.StrExt(strBase))
                    return;
                if (HasHotReq(strBase, colHotReqs))
                {
                    if (xSys.xUser.IsDeveloper() && nTools.GetControlKey())
                        TheContext.TheLeader.TellTemp("Requirement Matches Offer: " + strPart);
                    req xReq = GetHotReq(strBase, colHotReqs);
                    if (xReq == null)
                        return;
                    String strOriginal = yMessage.BODYTEXT;
                    if (strOriginal.IndexOf("<br>") <= 0)
                        strOriginal = strOriginal.Replace("\r\n", "<br>\r\n");
                    ordhed xQuote = ordhed.GetByID(xSys, xReq.userdata_01);
                    NewMethod.n_user yUser;
                    String subject = "Email Scanner Requirement Match Found: " + xReq.fullpartnumber;
                    if (Rz3App.xLogic.IsAAT)
                        subject = xReq.fullpartnumber;
                    if (xQuote == null)
                    {
                        yUser = NewMethod.n_user.GetByID(xSys, xReq.base_mc_user_uid);
                        if (yUser == null)
                            return;
                        if (xSys.xUser.IsDeveloper() && nTools.GetControlKey())
                            TheContext.TheLeader.TellTemp("Sending match message to " + yUser.email_address);
                        String err = "";
                        ToolsOffice.OutlookOffice.SendOutlookMessage(yUser.email_address, "Email Scanner Requirement Match Found:<br>\r\n" + strOriginal, subject, false, false, "", "", true, null, "", "", "", "", ref err);
                    }
                    else
                    {
                        yUser = NewMethod.n_user.GetByID(xSys, xQuote.base_mc_user_uid);
                        if (yUser == null)
                            return;
                        if (xSys.xUser.IsDeveloper() && nTools.GetControlKey())
                            TheContext.TheLeader.TellTemp("Sending match message to " + yUser.email_address);
                        String err1 = "";
                        ToolsOffice.OutlookOffice.SendOutlookMessage(yUser.email_address, "Email Scanner Requirement Match Found:<br>\n" + "Quote " + xQuote.ordernumber + "<br>\n<br><hr><br>" + strOriginal, subject, false, false, "", "", true, null, "", "", "", "", ref err1);
                    }
                }
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void CacheHotReqs()
        {
            try
            {
                colHotReqs = xSys.QtC("req", "select * from req where hot_req = 1");
                lngLastHotReq = Tools.Misc.GetTicks();
                if (xSys.xUser.IsDeveloper() && nTools.GetControlKey())
                    TheContext.TheLeader.TellTemp("Cached Hot Reqs: " + colHotReqs.Count.ToString() + " total.");
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private String RemoveThingsInHTML(String strIn)
        {
            try
            {
                //Tools.FileSystem.PopText(strIn);
                String holdend = Tools.Strings.ParseDelimit(strIn, "<BODY>", 2).Trim();
                if (!Tools.Strings.StrExt(holdend))
                    holdend = Tools.Strings.ParseDelimit(strIn, "<body>", 2).Trim();
                if (Tools.Strings.StrExt(holdend))
                    holdend = "<BODY>" + holdend;
                //Tools.FileSystem.PopText(holdend);
                holdend = holdend.Replace("\r\n", " ");//Added
                holdend = holdend.Replace("<br>", "");//strIn = strIn.Replace("<br>", "\r\n");
                holdend = holdend.Replace("<BR>", "");//strIn = strIn.Replace("<BR>", "\r\n");
                holdend = holdend.Replace("</tr>", "\r\n");
                holdend = holdend.Replace("</TR>", "\r\n");
                holdend = holdend.Replace("</div>", "\r\n");//Added
                holdend = holdend.Replace("</DIV>", "\r\n");//Added
                holdend = holdend.Replace("&nbsp;", " ");//Added
                holdend = holdend.Replace(">", "<");
                String build = "";
                //Tools.FileSystem.PopText(holdend);
                String[] ary = Tools.Strings.Split(holdend, "<");
                Boolean bLongEmail = false;
                Int64 iLong = 0;
                if (ary.Length > 100000)
                {
                    iLong = (ary.Length / 100000);
                    nStatus.SetStatus("This email is quite large, processing may take a while. " + iLong.ToString() + " count cycles.");
                    bLongEmail = true;
                }
                Int64 iCount = 1;
                Boolean bFirst = true;
                Int32 countup = 1;
                for (Int32 i = 0; i < ary.Length; i++)
                {
                    if (countup == 100000)
                    {
                        iCount++;
                        countup = 0;
                        if (!(iCount > iLong))
                            nStatus.SetStatus("Cycle " + iCount.ToString() + " of " + iLong.ToString() + ". ");
                    }
                    if (bLongEmail)
                    {
                        if (bFirst)
                        {
                            bFirst = false;
                            nStatus.SetStatus("Cycle " + iCount.ToString() + " of " + iLong.ToString() + ". ");
                        }
                    }
                    if (i % 2 == 0)
                        build += ary[i] + " ";
                    System.Windows.Forms.Application.DoEvents();
                    countup++;
                }
                //Tools.FileSystem.PopText(build);
                return build;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return strIn;
            }
        }
        private String RemoveThingsInQuotes(String strIn)
        {
            try
            {
                String[] ary = Tools.Strings.Split(strIn, "\r\n");
                String build = "";
                for (Int32 i = 0; i < ary.Length; i++)
                {
                    if (i % 2 == 0)
                        build += ary[i] + " ";
                }
                return build;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return strIn;
            }
        }
        private void ClearMessages()
        {
            colMessages = new ArrayList();
            strMessageAddress = "";
        }
        private String FilterAnAddress(String AddressIn)
        {
            try
            {
                String strHold = AddressIn.Trim();
                if (strHold.StartsWith("SMTP:"))
                {
                    if (strHold.Length > 5)
                        return strHold.Substring(6);
                    else
                        return AddressIn;
                }
                else
                    return AddressIn;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return AddressIn;
            }
        }
        private String GetTagValue(String strTag, String strText)
        {
            return GetTagValue(strTag, strText, false, 1, false);
        }
        private String GetTagValue(String strTag, String strText, Boolean boolNoSpace, Int64 lngStart, Boolean LineBreak)
        {
            try
            {
                Int64 lngMark = strText.ToUpper().IndexOf(strTag.ToUpper(), (Int32)lngStart);
                if (lngMark <= 0)
                    return "";
                lngMark = lngMark + strTag.Length;
                Int64 lngMark2 = 0;
                if (LineBreak)
                {
                    lngMark2 = strText.IndexOf("\n", (Int32)lngMark);
                    if (lngMark2 > 0)
                        return strText.Substring((Int32)lngMark, (Int32)(lngMark2 - lngMark));
                    else
                        return strText.Substring((Int32)lngMark);
                }
                Boolean boolOn = false;
                String strHold = "";
                String strChar = "";
                for (Int64 lngAll = 1; lngAll < 1001; lngAll++)
                {
                    strChar = strText.Substring((Int32)lngMark, 1);
                    if ((strChar == " " && !boolNoSpace) || strChar == Convert.ToChar(9).ToString() || strChar == Convert.ToChar(10).ToString() || strChar == Convert.ToChar(13).ToString() || strChar == "" || strChar == "/")
                    {
                        if (!boolOn)
                        {
                            lngMark++;
                            continue;
                        }
                        return strHold.Trim();
                    }
                    else
                    {
                        boolOn = true;
                        strHold += strChar;
                        lngMark++;
                    }
                }
                return "";
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return "";
            }
        }
        private void FlushMessages()
        {
            try
            {
                if (colMessages.Count > 0)
                {
                    if (xSys.GetSetting_Boolean("emailautorespond"))
                    {
                        SendEmailAutoResponse(colMessages, strMessageAddress, true);
                    }
                }
                ClearMessages();
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void SendEmailAutoResponse(ArrayList colMatches, String strAddress)
        {
            SendEmailAutoResponse(colMatches, strAddress, false);
        }
        private void SendEmailAutoResponse(ArrayList colMatches, String strAddress, Boolean boolForce)
        {
            try
            {
                String strEmail = "";
                if (!xSys.GetSetting_Boolean("emailautorespond"))
                    return;
                if (!boolForce && xSys.GetSetting_Boolean("emailsingleresponse"))
                {
                    if (Tools.Strings.StrExt(strAddress))
                    {
                        strMessageAddress = strAddress;
                        if (nTools.GetControlKey())
                            nStatus.TellUser("The address for this reply appears to be: " + strMessageAddress);
                    }
                    else
                    {
                        if (nTools.GetControlKey())
                            nStatus.TellUser("The address for this reply appears to be blank.");
                    }
                    foreach (partrecord x in colMatches)
                    {
                        if (!ContainsPart(x, colMessages))
                            colMessages.Add(x);
                    }
                    return;
                }
                strEmail = GetEmailResponseHeader();
                n_template xTemplate = n_template.GetByName(xSys, "QUICKCONFIRMDETAILS");
                if (xTemplate == null)
                {
                    nStatus.SetStatus("Automatic replies are enabled, but the structure of the outgoing messages needs to be configured.");
                    return;
                }
                strEmail += ((n_sys_Rz3_Common)n_sys.ContextDefault.xSys).ThePrintLogic.GetAsHTMLTable(xTemplate, colMatches);
                strEmail += GetEmailResponseFooter();
                if (xSys.GetSetting_Boolean("includeoriginalmessage"))
                    strEmail += "\n\r" + "\n\r" + "<br><br>Original Message:<br>" + "\n\r" + GlobalEmailMessage.Replace("\n", "<br>").Replace("\r", "");
                String strReply = strAddress;
                String strSubject = xSys.GetSetting("email_response_subject");
                if (!Tools.Strings.StrExt(strSubject))
                    strSubject = "RFQ Response";
                if (!Tools.Strings.StrExt(strReply))
                {
                    if (nTools.GetControlKey())
                        nStatus.TellUser("This response is ready to send, but the address appears to be blank.");
                }
                String err3 = "";
                ToolsOffice.OutlookOffice.SendOutlookMessage(strReply, strEmail, strSubject, false, nTools.GetControlKey(), xSys.GetSetting("email_response_cc"), "", true, null, "", "", "", "", ref err3);
                nStatus.SetStatus("Sent response to " + strAddress);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private String GetEmailResponseHeader()
        {
            try
            {
                return Tools.Files.OpenFileAsString(Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()) + "email_response_header.txt");
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return "";
            }
        }
        private String GetEmailResponseFooter()
        {
            try
            {
                return Tools.Files.OpenFileAsString(Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()) + "email_response_footer.txt");
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return "";
            }
        }
        private Boolean ContainsPart(partrecord r, ArrayList parts)
        {
            try
            {
                foreach (partrecord p in parts)
                {
                    if (p == r)
                        return true;
                }
                return false;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return false;
            }
        }
        private Boolean HasHotReq(String basenumber, ArrayList reqs)
        {
            try
            {
                foreach (req r in reqs)
                {
                    if (Tools.Strings.StrCmp(r.basenumberstripped, basenumber))
                        return true;
                }
                return false;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return false;
            }
        }
        private req GetHotReq(String basenumber, ArrayList reqs)
        {
            try
            {
                String p = "";
                String b = "";
                foreach (req r in reqs)
                {
                    PartObject.ParsePartNumber(r.fullpartnumber, ref p, ref b);
                    if (Tools.Strings.StrCmp(basenumber, b))
                        return r;
                }
                return null;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return null;
            }
        }
        private addresshandler ContainsAddress(EMailMessageOld address, ArrayList list, Boolean bToAddress, Boolean bBase)
        {
            try
            {
                String fuzzy = "*@";
                foreach (addresshandler h in list)
                {
                    if (bToAddress)
                    {
                        if (bBase)
                        {
                            if (Tools.Strings.StrCmp(fuzzy + address.ToAddress.basestring, h.emailaddress))
                                return h;
                        }
                        else
                        {
                            if (Tools.Strings.StrCmp(address.ToAddress.addressstring, h.emailaddress))
                                return h;
                        }
                    }
                    else
                    {
                        if (bBase)
                        {
                            if (Tools.Strings.StrCmp(fuzzy + address.FromAddress.basestring, h.emailaddress))
                                return h;
                        }
                        else
                        {
                            if (Tools.Strings.StrCmp(address.FromAddress.addressstring, h.emailaddress))
                                return h;
                        }
                    }
                }
                return null;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return null;
            }
        }
        private void ReceiveEmailResult(partrecord xPart, String FromAddress, String strLine)
        {
            try
            {
                if (nTools.GetControlKey())
                {
                    if (!Tools.Strings.StrExt(FromAddress))
                        nStatus.TellUser("The address from this result appears to be blank.");
                    else
                        nStatus.TellUser("The address from this result appears to be: " + FromAddress);
                }
                xPart.user_defined = strLine.Trim();
                //xPart.FindCompanyObject();
                if (xPart.isoffer)
                {
                    offer xOffer = new offer(xSys);
                    xOffer.fullpartnumber = xPart.fullpartnumber;
                    xOffer.manufacturer = xPart.manufacturer;
                    xOffer.datecode = xPart.datecode;
                    xOffer.quantity = xPart.quantity;
                    if (!Tools.Strings.StrExt(xPart.companyname))
                        xPart.companyname = FromAddress;
                    xOffer.companyname = xPart.companyname;
                    xOffer.emailaddress = FromAddress;
                    xOffer.price = xPart.price;
                    if (xOffer.ISave())
                    {
                        if (nTools.GetControlAndShiftKeys())
                            nStatus.TellUser("The offer '" + xOffer.fullpartnumber + "' was saved.");
                    }
                    else
                    {
                        if (nTools.GetControlAndShiftKeys())
                            nStatus.TellUser("Error: The offer '" + xOffer.fullpartnumber + "' was not saved.");
                    }
                    nStatus.SetStatus("Saved Offer For Part " + xOffer.fullpartnumber);
                }
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private Boolean IsTotalString(String strIn, String strType)
        {
            try
            {
                Char[] ary = strIn.ToCharArray();
                foreach (char strChar in ary)
                {
                    if (Tools.Strings.StrCmp(strType, "ABC"))
                    {
                        if (!nTools.CharInAlphabet(strChar))
                            return false;
                    }
                    else
                    {
                        if (!Tools.Number.IsNumeric(strChar.ToString()))
                            return false;
                    }
                }
                return true;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
                return false;
            }
        }
        private String StripToDouble(String value)
        {
            String build = "";
            Char[] chars = value.ToCharArray();
            foreach (char c in chars)
            {
                if (Tools.Number.IsNumeric(c.ToString()))
                    build += c.ToString();
                if (Tools.Strings.StrCmp(c.ToString(), "."))
                    build += c.ToString();
            }
            return build;
        }
        //Private Event Calls
        private void DoAboutToProcess(EMailMessageOld ThisMessage, Boolean boolClear)
        {
            if (eAboutToProcess != null)
                eAboutToProcess(ThisMessage, boolClear);
        }
        private void DoFoundInfo(String ITEMNUMBER, String SOURCEADDRESS, String strType)
        {
            if (eFoundInfo != null)
                eFoundInfo(ITEMNUMBER, SOURCEADDRESS, strType);
        }
        private void DoShouldStop(ref Boolean boolCancel)
        {
            if (eShouldStop != null)
                eShouldStop(ref boolCancel);
        }
        private void DoFoundPart(partrecord xPart, String strSource)
        {
            if (eFoundPart != null)
                eFoundPart(xPart, strSource);
        }
        private bool AlreadyHaveMatch(partrecord xPart, String strEmail)
        {
            Dictionary<String, partrecord> a = null;
            dMatches.TryGetValue(strEmail, out a);
            if (a == null)
                return false;
            if (a.Count <= 0)
                return false;
            foreach (KeyValuePair<String, partrecord> kvp in a)
            {
                partrecord p = kvp.Value;
                if (Tools.Strings.StrCmp(p.prefix + p.basenumberstripped, xPart.prefix + xPart.basenumberstripped))
                    return true;
            }
            return false;
        }
        private void CheckForMatches(partrecord xPart, String strEmail)
        {
            try
            {
                if (xPart == null)
                    return;
                if (xPart.isoffer)
                    return;
                if (!Tools.Strings.StrExt(strEmail))
                    return;
                strEmail = FilterAnAddress(strEmail).Trim().ToLower();
                strEmail = strEmail.Replace(",", "").Trim();
                strEmail = strEmail.Replace(";", "").Trim();
                if (!Tools.Strings.StrExt(strEmail))
                    return;
                string p = "";
                string b = "";
                xPart.fullpartnumber = PartObject.StripPart(xPart.fullpartnumber);
                PartObject.ParsePartNumber(xPart.fullpartnumber, ref p, ref b);
                xPart.prefix = p;
                xPart.basenumber = b;
                xPart.basenumberstripped = PartObject.StripPart(xPart.basenumber);
                if (!Tools.Strings.StrExt(xPart.basenumberstripped))
                    return;
                if (AlreadyHaveMatch(xPart, strEmail))
                    return;
                ArrayList matches = xSys.QtC("partrecord", "select * from partrecord where stocktype = 'stock' and prefix + basenumberstripped = '" + xSys.xData.SyntaxFilter(xPart.prefix + xPart.basenumberstripped) + "' and quantity > 0");
                if (matches == null)
                    return;
                if (matches.Count <= 0)
                    return;
                Dictionary<String, partrecord> a = null;
                dMatches.TryGetValue(strEmail, out a);
                bool n = false;
                if (a == null)
                {
                    a = new Dictionary<String, partrecord>();
                    n = true;
                }
                foreach (partrecord pr in matches)
                {
                    if (a.ContainsKey(pr.unique_id))
                        continue;
                    pr.ad_quantity = xPart.quantity;
                    a.Add(pr.unique_id, pr);
                }
                if (n)
                    dMatches.Add(strEmail, a);
            }
            catch { }
        }
        private SortedList GetEmailResponseColumns()
        {
            try
            {
                n_template t = n_template.GetByName(xSys, "QUICKCONFIRMDETAILS");
                if (t == null)
                    return null;
                t.GatherColumns();
                if (t.AllColumns == null)
                    return null;
                if (t.AllColumns.Count <= 0)
                    return null;
                return t.AllColumns;
            }
            catch
            { return null; }
        }
        private string GetResponseEMail(Dictionary<String, partrecord> parts)
        {
            try
            {
                if (parts == null)
                    return "";
                if (parts.Count <= 0)
                    return "";
                String header = GetEmailResponseHeader();
                String footer = GetEmailResponseFooter();
                StringBuilder sb = new StringBuilder();
                SortedList cols = GetEmailResponseColumns();
                sb.AppendLine("<TABLE width=\"100%\" border=0>");
                sb.AppendLine("  <TBODY>");
                sb.AppendLine("  <TR>");

                foreach (DictionaryEntry d in cols)
                {
                    n_column c = (n_column)d.Value;
                    sb.AppendLine("    <TD><FONT color=black><B>" + c.column_caption + "</B></FONT></TD>");
                }
                sb.AppendLine("  </TR>");
                foreach (KeyValuePair<String, partrecord> kvp in parts)
                {
                    partrecord p = kvp.Value;

                    //long total_qty = GetMatchTotalQty(parts, fullpartnumber);
                    //long req_qty = p.ad_quantity;
                    long ad_qty = 0;
                    if (p.ad_quantity <= p.quantity && p.ad_quantity > 0)
                        ad_qty = p.ad_quantity;
                    else
                        ad_qty = p.quantity;

                    sb.AppendLine("  <TR>");
                    foreach (DictionaryEntry d in cols)
                    {
                        n_column c = (n_column)d.Value;
                        string str = "";
                        if (Tools.Strings.StrCmp(c.field_name, "quantity"))
                            str = ad_qty.ToString();
                        else
                            str = GetValueAsString(c, p);

                        str = str.Replace("'", "").Trim();
                        sb.AppendLine("    <TD><FONT color=black>" + str + "</FONT></TD>");
                    }
                    sb.AppendLine("  </TR>");
                }
                sb.AppendLine("  </TABLE>");
                return header + "\r\n" + sb.ToString() + "\r\n" + footer;
            }
            catch(Exception ex)
            {
                TheContext.TheLeader.TellTemp("Error in GetResponseEmail: " + ex.Message);                
                return "";
            }
        }
        private long GetMatchTotalQty(Dictionary<String, partrecord> parts)
        {
            long l = 0;
            try
            {
                foreach (KeyValuePair<String, partrecord> kvp in parts)
                {
                    partrecord p = kvp.Value;
                    l += p.quantity;
                }
            }
            catch { }
            return l;
        }
        private string GetValueAsString(n_column col, partrecord xMatch)
        {
            if (col == null)
                return "";
            if (xMatch == null)
                return "";
            NewMethod.Enums.DataType dt = (NewMethod.Enums.DataType)col.data_type;
            switch (dt)
            {
                case NewMethod.Enums.DataType.Document:
                case NewMethod.Enums.DataType.Memo:
                case NewMethod.Enums.DataType.String:
                    return (String)xMatch.IGet(col.field_name);
                case NewMethod.Enums.DataType.Float: //Need check money format
                    return nTools.MoneyFormat_2_6((Double)xMatch.IGet(col.field_name));
                case NewMethod.Enums.DataType.Integer:
                case NewMethod.Enums.DataType.Long:
                    return ((Int64)xMatch.IGet(col.field_name)).ToString();
                case NewMethod.Enums.DataType.Date:
                    return ((DateTime)xMatch.IGet(col.field_name)).ToShortDateString();
                case NewMethod.Enums.DataType.Boolean:
                    return ((Boolean)xMatch.IGet(col.field_name)).ToString();
            }
            return "";
        }
        private void DoGotMatch(DataTable rst, String strAddress, String strDesc, String strType)
        {
            if (eGotMatch != null)
                eGotMatch(rst, strAddress, strDesc, strType);
        }
        private void DoGotSQL(String ThisSQL)
        {
            if (eGotSQL != null)
                eGotSQL(ThisSQL);
        }
        private void DoSQLDebug(String strDebug)
        {
            if (eSQLDebug != null)
                eSQLDebug(strDebug);
        }
        private void DoNewAddress()
        {
            if (eNewAddress != null)
                eNewAddress();
        }
        private void DoGotUpdate()
        {
            if (eGotUpdate != null)
                eGotUpdate();
        }
        private void DoGotConfirm()
        {
            if (eGotConfirm != null)
                eGotConfirm();
        }
        //Public Classes
        public class LineParseInfo
        {
            public bool PARTSETUP = false;
            public bool MANUFACTURER = false;
            public bool DATECODE = false;
            public bool MATCHPRICE = false;
            public bool QUANTITY = false;
        }
    }
}