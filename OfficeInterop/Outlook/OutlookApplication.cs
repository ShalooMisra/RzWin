using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

//using Outlook = Microsoft.Office.Interop.Outlook;

namespace OfficeInterop
{
    public class OutlookApplication
    {
        private Outlook.Application xOutlookApp;

        public OutlookApplication()
        {
            xOutlookApp = new Outlook.Application();
        }

        //Private Functions
        public static void OutlookSendReceive()
        {
            Int64 lne = 1;
            try
            {
                Redemption.MAPIUtils RedemptUtils = new Redemption.MAPIUtils();
                lne = 2;
                RedemptUtils.DeliverNow();
            }
            catch (Exception ee)
            {
                //nError.HandleError(new nError.nErrorObject(ee.Message, "void OutlookSendReceive()", lne, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void OutlookSendReceive()"));
            }
        }
        
        public ArrayList FillOutlookMessages(ArrayList colSourceRouting, ArrayList colDestRouting, ref OutlookMAPIFolder xInbox)
        {
            return FillOutlookMessages(colSourceRouting, colDestRouting, ref xInbox, "", 0);
        }

        public OutlookMAPIFolder GetInbox()
        {
            Outlook.NameSpace xName = xOutlookApp.GetNamespace("MAPI");
            Outlook.MAPIFolder xStaticInbox = xName.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            return new OutlookMAPIFolder(xStaticInbox);
        }

        public  ArrayList FillOutlookMessages(ArrayList colSourceRouting, ArrayList colDestRouting, ref OutlookMAPIFolder xInbox, String strInbox, Int64 lngLimit)
        {                     
            return new ArrayList();
            //try
            //{
            //    ArrayList colHold = new ArrayList();
            //    Outlook.NameSpace xName = xOutlookApp.GetNamespace("MAPI");
            //    Outlook.MAPIFolder xStaticInbox = xName.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            //    xInbox = new OutlookMAPIFolder(xStaticInbox.Folders["Recogniz"]);
            //    Int64 lngHold = 0;
            //    Outlook.Items emails = xInbox.Items;
            //    for (Int32 i = 1; i <= emails.Count; i++)
            //    {
            //        EmailMessage xMessage = GetEmailMessageOld(emails[i], colSourceRouting);
            //        if (xMessage != null)
            //            colHold.Add(xMessage);
            //        if (lngLimit > 0 && lngHold >= (lngLimit - 1))
            //            break;
            //        lngHold++;
            //    }
            //    return colHold;
            //}
            //catch (Exception ee)
            //{
            //    nError.HandleError(new nError.nErrorObject(ee.Message, "ArrayList FillOutlookMessages(Outlook.Application xOutlookApp, ArrayList colSourceRouting, ArrayList colDestRouting, ref Outlook.MAPIFolder xInbox, String strInbox , Int64 lngLimit )", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.ArrayList FillOutlookMessages(Outlook.Application xOutlookApp, ArrayList colSourceRouting, ArrayList colDestRouting, ref Outlook.MAPIFolder xInbox, String strInbox , Int64 lngLimit )"));
            //    return new ArrayList();
            //}
        }

        private EmailMessage GetEmailMessageOld(object email_item, ArrayList colSourceRouting, bool OutlookScriptAddress)
        {
            //xSys.GetSetting_Boolean("outlook_script_address")
            return null;
            //try
            //{
            //    String strRouting = "";
            //    Int32 PrSenderEmailAddress = 0xC1F001E;
            //    Boolean boolScriptAddress = OutlookScriptAddress;
            //    Redemption.MAPIUtils RedemptUtils = new Redemption.MAPIUtils();
            //    Outlook.MailItem xItem = null;
            //    Outlook.PostItem xPost = null;
            //    EmailMessage xMessage = new EmailMessage();
            //    if (email_item is Outlook.MailItem)
            //    {
            //        xItem = (Outlook.MailItem)email_item;
            //        xMessage = new EmailMessage();
            //        xMessage.UniqueID = Tools.Strings.GetNewID();
            //        if (boolScriptAddress)
            //            xMessage.SetFromAddress(GetReplyToAddress(xItem));
            //        else
            //            xMessage.SetFromAddress((String)RedemptUtils.HrGetOneProp(xItem.MAPIOBJECT, PrSenderEmailAddress));
            //        xMessage.SetToAddress(xItem.To);
            //        xMessage.SUBJECT = xItem.Subject;
            //        if (!WillDateFail(xItem))
            //            xMessage.messagedate = xItem.SentOn;
            //        if (Tools.Strings.StrExt(xItem.HTMLBody))
            //            xMessage.BODYTEXT = RemoveThingsInHTML(xItem.HTMLBody);
            //        else
            //            xMessage.BODYTEXT = (String)((xItem.Body == null) ? "" : xItem.Body);
            //        if (xMessage.BODYTEXT.ToUpper().Contains("HYPERLINK"))
            //            xMessage.BODYTEXT = RemoveThingsInQuotes(xMessage.BODYTEXT.Replace("HYPERLINK", ""));
            //        xMessage.MESSAGEID = xItem.EntryID;
            //        xMessage.ROUTINGINFO = strRouting;
            //        xMessage.colAttachments = new ArrayList();
            //        if (!Tools.Strings.StrExt(xMessage.FromAddress.addressstring))
            //            xMessage.SetFromAddress("DONOTSCAN");
            //        if (ShouldMove(xMessage, colSourceRouting))
            //        {
            //            MoveOutlookMessage(xMessage.MESSAGEID, xInbox, "temp");
            //            return null;
            //        }
            //        return xMessage;
            //    }
            //    if (email_item is Outlook.PostItem)
            //    {
            //        xPost = (Outlook.PostItem)email_item;
            //        xMessage = new EMailMessageOld();
            //        xMessage.UniqueID = Tools.Strings.GetNewID();
            //        if (boolScriptAddress)
            //            xMessage.SetFromAddress(GetReplyToAddress_Post(xPost));
            //        else
            //            xMessage.SetFromAddress((String)RedemptUtils.HrGetOneProp(xPost.MAPIOBJECT, PrSenderEmailAddress));
            //        xMessage.SetToAddress("");
            //        xMessage.SUBJECT = xPost.Subject;
            //        if (!WillDateFail_Post(xPost))
            //            xMessage.messagedate = xPost.SentOn;
            //        if (Tools.Strings.StrExt(xPost.HTMLBody))
            //            xMessage.BODYTEXT = RemoveThingsInHTML(xPost.HTMLBody);
            //        else
            //            xMessage.BODYTEXT = (String)((xPost.Body == null) ? "" : xPost.Body);
            //        if (xMessage.BODYTEXT.ToUpper().Contains("HYPERLINK"))
            //            xMessage.BODYTEXT = RemoveThingsInQuotes(xMessage.BODYTEXT.Replace("HYPERLINK", ""));
            //        xMessage.MESSAGEID = xPost.EntryID;
            //        xMessage.ROUTINGINFO = strRouting;
            //        xMessage.colAttachments = new ArrayList();
            //        if (!Tools.Strings.StrExt(xMessage.FromAddress.addressstring))
            //            xMessage.SetFromAddress("DONOTSCAN");
            //        if (ShouldMove(xMessage, colSourceRouting))
            //        {
            //            MoveOutlookMessage(xMessage.MESSAGEID, xInbox, "temp");
            //            return null;
            //        }
            //        return xMessage;
            //    }
            //    return null;
            //}
            //catch { return null; }
        }

    }
}
