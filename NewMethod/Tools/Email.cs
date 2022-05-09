using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace Tools
{
    public class nEmailMessage
    {
        //Public Variables
        public String FromName = "";
        public String FromAddress = "";
        public String ReplyToAddress = "";
        public String ToName = "";
        public String ToAddress = "";
        public String Subject = "";
        public String MessageData = "";
        public bool IsHTML = true;
        public ArrayList Attachments = new ArrayList();
        public List<string> CcRecipients = new List<string>();
        public List<string> BccRecipients = new List<string>();
        public String HTMLBody
        {
            set
            {
                MessageData = value;
                IsHTML = true;
            }
            get
            {
                return MessageData;
            }
        }
        public String TextBody
        {
            set
            {
                MessageData = value;
                IsHTML = false;
            }
            get
            {
                return MessageData;
            }
        }
        public int ServerPort = 25;
        public String ServerName = "";
        public String ServerUserName = "";
        public String ServerPassword = "";
        public bool SSLRequired = false;

        //Public Static Functions
        public static bool SendCollection(ArrayList messages)
        {
            ArrayList failed = new ArrayList();
            return SendCollection(messages, failed, false, false);
        }
        public static void SetRecipient(ArrayList messages, String RecipientAddress)
        {
            foreach (nEmailMessage m in messages)
            {
                SetRecipient(m, RecipientAddress);
            }
        }
        public static void SetRecipient(nEmailMessage m, String RecipientAddress)
        {
            m.ToAddress = RecipientAddress;
        }
        public static void SetFromRecognin(ArrayList messages)
        {
            foreach (nEmailMessage m in messages)
            {
                SetFromRecognin(m);
            }
        }
        public static void SetFromRecognin(nEmailMessage m)
        {
            m.SetNotifyServer();
        }
        public static bool EmailMike(String strSubject, String strBody)
        {
            nEmailMessage m = new nEmailMessage();
            m.ToAddress = "mike@recognin.com";
            m.ToName = "Mike Bloise";
            m.FromAddress = "mike@recognin.com";
            m.Subject = strSubject;
            m.HTMLBody = strBody;
            m.SetDefaultServer();
            return m.Send();
        }

        public void SetToAndExtras(List<String> emailAddresses)
        {
            for (int x = 0; x < emailAddresses.Count; x++)
            {
                if (x == 0)
                    ToAddress = emailAddresses[x];
                else
                    AddBccRecipient(emailAddresses[x]);
            }
        }

        public static bool SendCollection(ArrayList messages, bool ShowStatus, bool CloseStatus)
        {
            ArrayList f = new ArrayList();
            return SendCollection(messages, f, ShowStatus, CloseStatus);
        }
        public static bool SendCollection(ArrayList messages, ArrayList failedmessages, bool ShowStatus, bool CloseStatus)
        {
            bool s = false;

            //if (ShowStatus)
            //    s = context.TheLeader.StartPopStatus();

            if (failedmessages == null)
                failedmessages = new ArrayList();

            foreach (nEmailMessage m in messages)
            {
                if (!m.Send())
                {
                    //context.TheLeader.Comment("Failed to send message: " + m.ToString());
                    failedmessages.Add(m);
                }
                else
                {
                    //context.TheLeader.Comment("Sent: " + m.ToString());
                }
            }

            if (ShowStatus && s)
            {
                if (failedmessages.Count > 0)
                {
                    //context.TheLeader.StopPopStatus(true);
                    //context.TheLeader.Tell("Some of the emails could not be sent.  Please check the status list for descriptions of the problem.");
                }
                else
                {
                    //context.TheLeader.StopPopStatus(!CloseStatus);
                }
            }

            return (failedmessages.Count == 0);
        }
        //Public Functions
        public void SetDefaultServer()
        {
            ServerPort = 25;
            ServerName = "smtp.sensiblemicro.local";
            //ServerUserName = "notify@recognin.com";
            //ServerPassword = "N0tify";
            //ServerName = "smtpout.secureserver.net";
            //ServerUserName = "notify@recognin.com";
            //ServerPassword = "N0tify";
        }
        public void SetNotifyServer()
        {
            SetNotifyServer("Rz");
        }
        public void SetNotifyServer(String strFromName)
        {
            //SetNotifyServer(strFromName, "notify@recognin.com", "N0tify");
            SetNotifyServer(strFromName, "Rznotify@sensiblemicro.com", null);
        }
        public void SetNotifyServer(String strFromName, String strEmailAddress, String strPassword)
        {
            if (!Tools.Strings.StrExt(strFromName))
                strFromName = "Rz";

            ServerPort = 25;
            //ServerName = "smtpout.secureserver.net";
            ServerName = "smtp.sensiblemicro.local";
            //ServerUserName = strEmailAddress;
            //ServerPassword = strPassword;
            FromName = strFromName;
            FromAddress = strEmailAddress;
        }
        public void AddAttachment(String strFile)
        {
            Attachments.Add(strFile);
        }
        public void AddCcRecipient(String strCCRecip)
        {
            CcRecipients.Add(strCCRecip);
        }
        public void AddBccRecipient(String strBCCRecip)
        {
            BccRecipients.Add(strBCCRecip);
        }
        public bool Send()
        {
            String s = "";
            return Send(ref s);
        }
        public virtual bool Send(ref String strError)
        {
            try
            {
                System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(FromAddress, FromName);
                System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress(ToAddress, ToName);
                System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(from, to);
                if (Tools.Email.IsEmailAddress(ReplyToAddress))
                    m.ReplyTo = new System.Net.Mail.MailAddress(ReplyToAddress, FromName);
                m.IsBodyHtml = IsHTML;
                m.Body = MessageData;
                m.Subject = Subject;
                //Attachments
                foreach (String s in Attachments)
                {
                    if (!string.IsNullOrEmpty(s))
                        m.Attachments.Add(new System.Net.Mail.Attachment(s));
                }
                //CC
                foreach (string s in CcRecipients)
                {
                    m.CC.Add(new MailAddress(s));
                }
                //Bcc
                foreach (string s in BccRecipients)
                {
                    m.Bcc.Add(new MailAddress(s));
                }

                //SMTP Client
                ServerName = "smtp.sensiblemicro.local";
                SmtpClient client = new SmtpClient(ServerName);
                client.Credentials = new NetworkCredential(ServerUserName, ServerPassword);
                client.Timeout = 1200000;
                client.EnableSsl = SSLRequired;
                if (ServerPort > 0)
                    client.Port = ServerPort;
                bool sent = false;
                try
                {
                    client.Send(m);
                    sent = true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    if (ex.InnerException != null)
                        strError += " : " + ex.InnerException.Message;
                }
                if (!sent)
                {
                    client.Port = 80;
                    try
                    {
                        client.Send(m);
                    }
                    catch (Exception ex2)
                    {
                        strError += " Port 80 failed also: " + ex2.Message;
                        return false;
                    }
                    strError = "";
                }
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }
        public String GetFriendlyName()
        {
            return "To: " + ToAddress + "  From: " + FromAddress + "   Subject: " + Subject;
        }
    }

}
