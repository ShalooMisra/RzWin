using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeInterop
{
    public class OutlookMAPIFolder
    {
        public Outlook.MAPIFolder xFolder;

        public OutlookMAPIFolder(Outlook.MAPIFolder f)
        {
            xFolder = f;
        }

        public bool FolderExists(String strFolderName)
        {
            //try
            //{
            //    Outlook.MAPIFolder xHold = xFolder.Folders[strFolderName];
            //    String strHold = xFolder.Folders[strFolderName].Name;
            //    return true;
            //}
            //catch (Exception ee)
            //{
            //    return false;
            //}
            return false;
        }

        public void FolderAdd(String folder, String extra)
        {
            xFolder.Folders.Add(folder, "");
            //xFolder.Folders.Add("Scanned", "");
        }

        public OutlookMAPIFolder FolderGet(String name)
        {
            //Outlook.MAPIFolder f = xFolder.Folders[name];
            //return new OutlookMAPIFolder(f);
            return null;
        }

        public List<EmailMessage> GetEmailMessages()
        {
            //List<EmailMessage> l = new List<EmailMessage>();
            //if (xFolder == null)
            //    return l;
            //for (Int32 i = 1; i <= xFolder.Items.Count; i++)
            //{
            //    Outlook.MailItem m = (MOutlook.MailItem)xFolder.Items[i];
            //    if (m == null)
            //        continue;
            //    EmailMessage em = new EmailMessage(m);
            //    l.Add(em);
            //}
            //return l;
            return null;
        }
    }
}
