using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OfficeInterop
{
    public class EmailMessage
    {
        private Outlook.MailItem EMail;

        public ArrayList colAttachments = new ArrayList();
        public String UniqueID = "";
        public String SUBJECT = "";
        public String BODYTEXT = "";
        public String MESSAGEID = "";
        public String ROUTINGINFO = "";
        public String MESSAGEHTML = "";
        public DateTime messagedate;

        public EmailMessage()
        {
            
        }

        public EmailMessage(Outlook.MailItem m)
        {
            if (m == null)
                return;
            EMail = m;
            BODYTEXT = m.Body;
            messagedate = m.CreationTime;
            MESSAGEHTML = m.HTMLBody;
            MESSAGEID = m.EntryID;
            SUBJECT = m.Subject;
            UniqueID = ToolsStrings.GetNewID();
        }

        public void MoveToFolder(OutlookMAPIFolder f)
        {
            if (f == null)
                return;
            if (EMail == null)
                return;
            try { EMail.Move(f.xFolder); }
            catch { }
        }
    }
}
