using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
//using NewMethod;

//using Word = Microsoft.Office.Interop.Word;
//using Excel = Microsoft.Office.Interop.Excel;
//using Outlook = Microsoft.Office.Interop.Outlook;

using OfficeInterop;

namespace ToolsOffice
{
    public static class OutlookOffice
    {
        //Public Static Variables
        public static int olMailItem = 0;
        public static int olFolderSentMail = 5;
        public static int olFolderInbox = 6;
        //Private Static Variables
        private static Redemption.MAPIUtils RedemptUtils;

        //Public Static Functions
        public static bool SendOutlookMessage(String ToAddress, ref String error)
        {
            return SendOutlookMessage(ToAddress, "", "", false, true, "", "", false, null, "", "", "", "", ref error);
        }
        public static bool SendOutlookMessage(String ToAddress, String BodyText, String SubjectString, bool boolTextOnly, bool boolUserEdit, String CCString, String strAttachFile, bool boolForceSilent, ArrayList colCC, String strBCC, String strReplyAddress, String strOtherAttachment, String strSignature, ref String error)
        {
            return SendOutlookMessage(ToAddress, BodyText, SubjectString, boolTextOnly, boolUserEdit, CCString, strAttachFile, boolForceSilent, colCC, strBCC, strReplyAddress, strOtherAttachment, strSignature, false, ref error);
        }
        public static bool SendOutlookMessage(String ToAddress, String BodyText, String SubjectString, bool boolTextOnly, bool boolUserEdit, String CCString, String strAttachFile, bool boolForceSilent, ArrayList colCC, String strBCC, String strReplyAddress, String strOtherAttachment, String strSignature, bool bDeliverNow, ref String error)
        {
            try
            {
                String[] aryAttach;

                Outlook.Application OutlookApp = new Outlook.Application();

                Outlook.MailItem xMessage = (Outlook.MailItem)OutlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                xMessage = (Outlook.MailItem)OutlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                xMessage.Subject = SubjectString;
                if (ToolsStrings.StrExt(BodyText))
                {
                    if (boolTextOnly)
                        xMessage.Body = BodyText;
                    else
                        xMessage.HTMLBody = BodyText;
                }
                else
                {
                    if (boolTextOnly)
                        xMessage.Body = "\r\n\r\n" + strSignature;
                    else
                        xMessage.HTMLBody = "<br><br>" + strSignature;
                }

                xMessage.To = ToAddress;
                if (ToolsStrings.StrExt(strReplyAddress))
                {
                    xMessage.ReplyRecipients.Add(strReplyAddress);
                }

                //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                //CC String

                if (ToolsStrings.StrExt(CCString))
                {
                    AddCCS(xMessage, CCString);
                }
                else if (colCC != null)
                {
                    foreach (String x in colCC)
                    {
                        xMessage.Recipients.Add(ToolsStrings.Trim(x));
                    }
                }

                if (ToolsStrings.StrExt(strBCC))
                {
                    xMessage.BCC = strBCC;
                }

                if (ToolsStrings.StrExt(strAttachFile))
                {
                    int pos = 1;
                    aryAttach = strAttachFile.Split(new String[] { "|" }, StringSplitOptions.None);
                    foreach (String strFileName in aryAttach)
                    {
                        if (System.IO.File.Exists(strFileName))
                        {
                            xMessage.Attachments.Add(strFileName, (int)Outlook.OlAttachmentType.olByValue, (object)pos, System.IO.Path.GetFileName(strFileName));
                            pos++;
                        }
                    }
                }

                if (ToolsStrings.StrExt(strOtherAttachment))
                {
                    if (System.IO.File.Exists(strOtherAttachment))
                    {
                        xMessage.Attachments.Add(strOtherAttachment, (int)Outlook.OlAttachmentType.olByValue, (object)1, System.IO.Path.GetFileName(strOtherAttachment));
                    }
                }

                if ((!boolForceSilent) && (boolUserEdit))
                    xMessage.Display((Object)false);
                else
                    xMessage.Send();
                if (bDeliverNow)
                {
                    Redemption.MAPIUtils RedemptUtils = new Redemption.MAPIUtils();
                    RedemptUtils.DeliverNow();
                }

                OutlookApp = null;
                return true;
            }
            catch (Exception ex)
            {
                if (!boolForceSilent)
                    error = "There was an error sending this message: " + ex.Message;
                //if (Tools.Strings.HasString(ex.Message, "RPC server"))
                //    ResetOutlook();
                return false;
            }
        }
        public static void DoOutlookSendReceive()
        {
            try
            {
                Redemption.MAPIUtils RedemptUtils = new Redemption.MAPIUtils();
                RedemptUtils.DeliverNow();
            }
            catch { }
        }
        public static void AddCCS(Outlook.MailItem xMessage, String strCC)
        {
            try
            {
                if (!ToolsStrings.StrExt(strCC))
                    return;

                String[] s = ToolsStrings.Split(strCC, ",");
                foreach (String a in s)
                {
                    if (ToolsStrings.StrExt(a))
                        xMessage.Recipients.Add(a);
                }
            }
            catch { }
            return;
        }
        public static String GetSenderEmailAddress(Outlook.MailItem xItem)
        {
            return "";
            //try
            //{
            //    int PrSenderEmailAddress = 0xC1F001E;
            //    if (RedemptUtils == null)
            //    {
            //        RedemptUtils = new Redemption.MAPIUtilsClass();
            //    }

            //    return (String)RedemptUtils.HrGetOneProp(xItem.MAPIOBJECT, PrSenderEmailAddress);
            //}
            //catch
            //{
            //    return "";
            //}
        }

        public static String GetRecipientEmailAddress(Outlook.MailItem xItem, bool status, ref String error)
        {
            /*
            String ret = "";
            int PrSMTPAddress = 0x39FE001E;
            try
            {

                if (RedemptUtils == null)
                {
                    RedemptUtils = new Redemption.MAPIUtilsClass();
                }


                ret = (String)RedemptUtils.HrGetOneProp(xItem.Recipients[1].AddressEntry.MAPIOBJECT, PrSMTPAddress);
            }
            catch (Exception ex1)
            {
                if (status)
                    error = "RTE getting the address via MAPI: " + ex1.Message;
            }

            if (status)
                error = "The address so far is: " + ret;

            try
            {
                if (!ToolsStrings.StrExt(ret))
                    ret = xItem.Recipients[1].Address;
            }
            catch (Exception ex2)
            {
                if (status)
                    error = "RTE via recipients: " + ex2.Message;

                ret = "";
            }

            if (status)
                error = "Returning " + status;

            return ret;
             * */
            return "";
        }

        public static ArrayList GetMessageInfoByFolder(String strFolder)
        {
            ////nStatus.SetStatus("Initializing Outlook");
            //Outlook.Application OutlookApp = new Outlook.Application();

            //Outlook.NameSpace n = OutlookApp.GetNamespace("MAPI");
            //Outlook.MAPIFolder inbox = null;
            //foreach (Outlook.MAPIFolder f in n.Folders)
            //{
            //    if (Tools.Strings.StrCmp(f.Name, strFolder))
            //    {
            //        inbox = f;
            //        break;
            //    }
            //    foreach (Outlook.MAPIFolder jf in f.Folders)
            //    {
            //        if (Tools.Strings.StrCmp(jf.Name, strFolder))
            //        {
            //            inbox = jf;
            //            break;
            //        }
            //    }
            //}

            //if (inbox == null)
            //{
            //    nStatus.TellUser("The folder " + strFolder + " was not found.");
            //    return new ArrayList();
            //}

            //nStatus.SetStatus("Found " + inbox.Name);

            ////String[] path = Tools.Strings.Split(strFolder, "/");

            ////foreach (String p in path)
            ////{
            ////    if (Tools.Strings.StrExt(p))
            ////    {
            ////        for (int fi = 1; fi <= inbox.Folders.Count; fi++)
            ////        {
            ////            Outlook.MAPIFolder f = inbox.Folders.Item(fi);
            ////            if (Tools.Strings.StrCmp(f.Name, p))
            ////            {
            ////                inbox = f;
            ////                break;
            ////            }
            ////        }
            ////    }
            ////}



            ////if (inbox == null)
            ////{
            ////    nStatus.SetStatus("The folder '" + strFolder + "' was not found.");
            ////    return null;
            ////}

            //ArrayList a = GetMessageInfoByFolderAndAddresses(inbox, null, inbox.Name);
            //OutlookApp = null;
            //return a;
            return new ArrayList();
        }

        public static ArrayList GetMessageInfoByFolderAndSubject(String strFolder, String strSubject)
        {
            //nStatus.SetStatus("Initializing Outlook");
            //Outlook.Application OutlookApp = new Outlook.Application();

            //Outlook.NameSpace n = OutlookApp.GetNamespace("MAPI");
            //Outlook.MAPIFolder inbox = n.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            //String[] path = Tools.Strings.Split(strFolder, "/");

            //foreach (String p in path)
            //{
            //    if (Tools.Strings.StrExt(p))
            //    {
            //        foreach(Outlook.MAPIFolder f in inbox.Folders)
            //        {
            //            if (Tools.Strings.StrCmp(f.Name, p))
            //            {
            //                inbox = f;
            //                break;
            //            }
            //        }
            //    }
            //}



            //if (inbox == null)
            //{
            //    nStatus.SetStatus("The folder '" + strFolder + "' was not found.");
            //    return null;
            //}

            //ArrayList a = GetMessageInfoByFolderAndSubject(inbox, strSubject);
            //OutlookApp = null;
            //return a;
            return new ArrayList();
        }
        public static ArrayList GetMessageInfoByFolderAndSubject(Outlook.MAPIFolder xFolder, String strSubject)
        {
            
            ArrayList a = new ArrayList();
            //nStatus.SetStatus("Getting by folder...");

            //object x = xFolder.Items.GetFirst();

            //while (x != null)
            //{
            //    try
            //    {
            //        Outlook.MailItem m = (Outlook.MailItem)x;
            //        nStatus.SetStatus(m.Subject);

            //        if (Tools.Strings.HasString(m.Subject, strSubject))
            //        {
            //            MessageInfo i = new MessageInfo();
            //            i.FromAddress = GetSenderEmailAddress(m);
            //            i.Subject = m.Subject;
            //            i.Sent = m.SentOn;
            //            a.Add(i);
            //        }
            //    }
            //    catch (Exception)
            //    { }

            //    x = xFolder.Items.GetNext();
            //}
            return a;
        }
        public static ArrayList GetAttachmentsByFolder(String strFolder)
        {
            return new ArrayList();

            //try
            //{
            //    nStatus.SetStatus("Initializing Outlook, looking for " + strFolder);
            //    //nStatus.TellUser("Outlook.Application OutlookApp = new Outlook.Application();");
            //    Outlook.Application OutlookApp = new Outlook.Application();

            //    nStatus.SetStatus("Getting the namespace...");
            //    //nStatus.TellUser("Outlook.NameSpace n = OutlookApp.GetNamespace");
            //    Outlook.NameSpace n = OutlookApp.GetNamespace("MAPI");

            //    //nStatus.TellUser("Outlook.MAPIFolder inbox = n.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);");
            //    Outlook.MAPIFolder inbox = n.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            //    nStatus.SetStatus("Iterating the inbox folders...");
            //    //nStatus.TellUser("for (int fi = 1; fi <= inbox.Folders.Count; fi++)");
            //    foreach(Outlook.MAPIFolder f in inbox.Folders)
            //    {
            //        if (Tools.Strings.StrCmp(f.Name, strFolder))
            //        {
            //            nStatus.SetStatus("Matched " + f.Name);
            //            inbox = f;
            //            break;
            //        }
            //    }

            //    if (inbox == null)
            //    {
            //        nStatus.SetStatus("The folder '" + strFolder + "' was not found.");
            //        return null;
            //    }

            //    //nStatus.TellUser("Getting attachments in " + inbox.Name);
            //    ArrayList a = GetAttachmentsByFolder(inbox);
            //    nStatus.TellUser("Finished getting attachments");
            //    if (!nTools.GetControlKey())
            //    {
            //        nStatus.SetStatus("Setting OutlookApp to null...");
            //        OutlookApp = null;
            //    }
            //    else
            //    {
            //        nStatus.SetStatus("Skipping null set on OutlookApp");
            //    }
            //    return a;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }
        public static ArrayList GetAttachmentsByFolder(Outlook.MAPIFolder xFolder)
        {
            return new ArrayList();
            //try
            //{
            //    nStatus.TellUser("Getting attachments by folder from " + xFolder.Name + "...");
            //    nStatus.SetStatus("Getting attachments by folder from " + xFolder.Name + "...");
            //    ArrayList a = new ArrayList();

            //    nStatus.SetStatus("Iterating items...");
            //    //nStatus.TellUser("for (int k = 1; k <= xFolder.Items.Count; k++)");
            //    for (int k = 1; k <= xFolder.Items.Count; k++)
            //    {
            //        try
            //        {
            //            nStatus.SetStatus("Getting item " + k.ToString());
            //            nStatus.TellUser("Outlook.MailItem m = (Outlook.MailItem)xFolder.Items.Item(k);");
            //            Outlook.MailItem m = (Outlook.MailItem)xFolder.Items[k];
            //            nStatus.SetStatus(m.Subject);

            //            MessageInfo i = new MessageInfo();

            //            if (!nTools.GetControlKey())
            //            {
            //                nStatus.TellUser("i.FromAddress = GetSenderEmailAddress(m);");
            //                i.FromAddress = GetSenderEmailAddress(m);
            //            }
            //            else
            //            {
            //                nStatus.SetStatus("Skipping sender email address");
            //                i.FromAddress = "mike@recognin.com";
            //            }

            //            i.Subject = m.Subject;
            //            i.Sent = m.SentOn;

            //            i.Attachments = new ArrayList();

            //            nStatus.SetStatus("Iterating attachments...");
            //            nStatus.TellUser("for (int j = 1; j <= m.Attachments.Count; j++)");
            //            for (int j = 1; j <= m.Attachments.Count; j++)
            //            {
            //                nStatus.TellUser("Outlook.Attachment at = (Outlook.Attachment)m.Attachments.Item(j);");
            //                Outlook.Attachment at = (Outlook.Attachment)m.Attachments[j];

            //                nStatus.TellUser("at.FileName");
            //                nStatus.SetStatus("Saving " + at.FileName + " from " + i.FromAddress);
            //                String fn = "c:\\temp_" + Tools.Strings.GetNewID() + "_" + at.FileName;
            //                nStatus.TellUser("at.SaveAsFile(fn); [" + at.FileName + "] to [" + fn + "]");
            //                at.SaveAsFile(fn);

            //                i.Attachments.Add(fn);
            //            }
            //            a.Add(i);
            //        }
            //        catch (Exception)
            //        { }

            //    }
            //    return a;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }

        public static ArrayList GetMessageInfoByAddresses(ArrayList addresses)
        {
            return new ArrayList();
            //nStatus.SetStatus("Initializing Outlook");
            //Outlook.Application OutlookApp = new Outlook.Application();

            //ArrayList folders = new ArrayList();
            //folders.Add(Outlook.OlDefaultFolders.olFolderInbox);
            //folders.Add(Outlook.OlDefaultFolders.olFolderSentMail);

            //Outlook.NameSpace n = OutlookApp.GetNamespace("MAPI");
            //ArrayList ret = new ArrayList();
            //foreach (Outlook.OlDefaultFolders f in folders)
            //{

            //    Outlook.MAPIFolder inbox = n.GetDefaultFolder(f);

            //    if (inbox == null)
            //    {
            //        nStatus.SetStatus("The folder '" + f.ToString() + "' was not found.");
            //        return null;
            //    }

            //    ret.AddRange(GetMessageInfoByFolderAndAddresses(inbox, addresses, ""));

            //}
            //OutlookApp = null;
            //return ret;
        }

        public static ArrayList CacheFolderMessages(Outlook.MAPIFolder xFolder, String strRef)
        {
            return new ArrayList();
            //ArrayList messages = new ArrayList();

            ////get them all in memory at once to avoid send/receive inserts
            //nStatus.SetStatus("Caching messages in " + xFolder.Name);
            //try
            //{
            //    for (int im = 1; im <= xFolder.Items.Count; im++)
            //    {
            //        messages.Add(xFolder.Items[im]);
            //    }
            //    return messages;
            //}
            //catch (Exception exm)
            //{
            //    nStatus.TellUser("RTE caching messages in " + xFolder.Name + ": [" + strRef + "] " + exm.Message);
            //    return null;
            //}
        }

        public static ArrayList GetMessageInfoByFolderAndAddresses(Outlook.MAPIFolder xFolder, ArrayList addresses, String strPath)
        {
            return new ArrayList();
            ////nStatus.SetStatus("Getting by folder...");

            //nStatus.SetStatus("Scanning " + strPath + xFolder.Name);

            //ArrayList ret = new ArrayList();
            //Outlook.MailItem m = null;

            //ArrayList messages = null;

            //for (int t = 0; t < 3; t++)
            //{
            //    messages = CacheFolderMessages(xFolder, "attempt " + t.ToString());
            //    if (messages != null)
            //        break;
            //}

            //if (messages == null)
            //{
            //    nStatus.TellUser("Failed to scan " + xFolder.Name);
            //    return ret;
            //}

            //foreach (Object x in messages)
            //{
            //    if (x is Outlook.MailItem)
            //    {
            //        m = (Outlook.MailItem)x;
            //    }
            //    else
            //        continue;

            //    try
            //    {
            //        bool status = Tools.Strings.StrCmp(m.Subject, "!test!");
            //        if (status)
            //        {
            //            nStatus.SetStatus("Test message found.");
            //        }


            //        String from = "";
            //        try
            //        {
            //            from = GetSenderEmailAddress(m).ToLower();
            //        }
            //        catch { }

            //        if (status)
            //        {
            //            nStatus.SetStatus("Found " + from + " as the from address for " + m.Subject);
            //        }

            //        String to = "";
            //        try
            //        {
            //            to = m.To.ToLower();

            //        }
            //        catch { }

            //        try
            //        {
            //            if (!Tools.Strings.StrExt(to))
            //            {
            //                if (status)
            //                    nStatus.SetStatus("No plain to address.");

            //                to = GetRecipientEmailAddress(m, status).ToLower();
            //            }
            //        }
            //        catch { }

            //        if (status)
            //        {
            //            nStatus.SetStatus("Found " + to + " as the to address.");

            //            to = to.Replace("'", "").Replace("\"", "").Trim().ToLower();

            //            nStatus.SetStatus("Using " + to + " as the to address for " + m.Subject);

            //            //if (addresses.Contains(to))
            //            //{
            //            //    nStatus.SetStatus("Contains " + to);
            //            //}
            //            //else
            //            //{
            //            //    nStatus.SetStatus("Does not contain " + to);

            //            //    foreach (String s in addresses)
            //            //    {
            //            //        nStatus.SetStatus(s);
            //            //    }
            //            //}
            //        }

            //        //if (addresses.Contains(from) || addresses.Contains(to))
            //        //{
            //        try
            //        {
            //            MessageInfo i = new MessageInfo();
            //            i.FromAddress = from;
            //            i.ToAddress = to;
            //            i.Subject = m.Subject;
            //            i.Sent = m.SentOn;
            //            i.Body = m.HTMLBody;
            //            i.UniqueID = Tools.Strings.GetNewID();
            //            i.MAPID = m.EntryID;
            //            if (!Tools.Strings.StrExt(i.Body))
            //                i.Body = nTools.ConvertTextToHTML(m.Body);

            //            if (i.Subject == null)
            //                i.Subject = "";

            //            ret.Add(i);

            //            //try
            //            //{
            //            //    for (int a = 1; a <= m.Attachments.Count; a++)
            //            //    {
            //            //        Outlook.Attachment at = m.Attachments.Item(a);
            //            //        nStatus.SetStatus("Saving " + at.FileName);                                    
            //            //        String strFileName = "c:\\attachments\\" + i.UniqueID + "__" + Tools.Strings.GetNewID() + "_" + at.FileName;
            //            //        at.SaveAsFile(strFileName);
            //            //    }
            //            //}
            //            //catch (Exception ex)
            //            //{
            //            //    nStatus.TellUser("Attachment RTE: " + ex.Message);
            //            //}

            //            nStatus.SetStatus("Added " + m.Subject);
            //        }
            //        catch (Exception ex)
            //        {
            //            nStatus.TellUser("RTE adding message: " + ex.Message);
            //        }
            //        //}
            //        //else
            //        //{
            //        //    if (status)
            //        //        nStatus.SetStatus("Neither '" + from + "' or '" + to + "' matched the " + Tools.Number.LongFormat(addresses.Count) + " addresses.");
            //        //}

            //    }
            //    catch
            //    {
            //    }

            //}

            //for (int fi = 1; fi <= xFolder.Folders.Count; fi++)
            //{
            //    Outlook.MAPIFolder fx = xFolder.Folders[fi];
            //    ret.AddRange(GetMessageInfoByFolderAndAddresses(fx, addresses, strPath + xFolder.Name + "/"));
            //}

            //return ret;
        }

        //Public Functions
        public static void ShowMessageByMessageID(String strMessageID)
        {
        }
        public static String GetRecipientAddressList(Outlook.MailItem xItem)
        {
            //nStatus.NeedImplement("nEmail.GetRecipientAddressList");
            return "";
        }

        public static ArrayList GetMessages(String strServer, String strUser, String strPassword)
        {
            return new ArrayList();

            //try
            //{
            //    Pop3Client email = new Pop3Client(strUser, strPassword, strServer);
            //    email.OpenInbox();

            //    while (email.NextEmail())
            //    {
            //        if (email.IsMultipart)
            //        {
            //            IEnumerator enumerator = email.MultipartEnumerator;
            //            while (enumerator.MoveNext())
            //            {
            //                //Pop3Component multipart = (Pop3Component)enumerator.Current;
            //                //if (multipart.IsBody)
            //                //{
            //                //    Console.WriteLine("Multipart body:" +
            //                //    multipart.Body);
            //                //}
            //                //else
            //                //{
            //                //    Console.WriteLine("Attachment name=" +
            //                //    multipart.Name); // ... etc

            //                //}
            //            }
            //        }
            //    }

            //    email.CloseConnection();

            //}
            //catch (Pop3LoginException pex)
            //{
            //    nStatus.TellUser("You seem to have a problem logging in: " + pex.Message);
            //}
            //catch (Exception ex)
            //{
            //    nStatus.TellUser("Error: " + ex.Message);
            //}

            //return new ArrayList();
        }

        public static String GetReplyToAddress(Outlook.MailItem objMsg)
        {
            /*
            String strAddress = "";
            try
            {
                Outlook.MailItem objReply = objMsg.Reply();
                Outlook.Recipient objRecip = objReply.ReplyRecipients[1];
                strAddress = objRecip.Address;
                if (!ToolsStrings.StrExt(strAddress))
                    strAddress = objRecip.Name;
            }
            catch
            {   //Err = 287
                String tell = "GetReplyToAddress:\r\nThe Outlook E-mail Security Patch is apparently installed on this machine.";
                tell += "\r\nYou must response Yes to the prompt about accessing e-mail addresses if you want to get the Reply To address.";
                MessageBox.Show(tell);
            }
            return strAddress;
             * */
            return "";
        }
        public static String GetReplyToAddress_Post(Outlook.PostItem objMsg)
        {
            /*
            String strAddress = "";
            try
            {
                Outlook.MailItem objReply = objMsg.Reply();
                Outlook.Recipient objRecip = objReply.ReplyRecipients[1];
                strAddress = objRecip.Address;
                if (!ToolsStrings.StrExt(strAddress))
                    strAddress = objRecip.Name;
            }
            catch (Exception ee)
            {   //Err = 287
                String tell = "GetReplyToAddress:\r\nThe Outlook E-mail Security Patch is apparently installed on this machine.";
                tell += "\r\nYou must response Yes to the prompt about accessing e-mail addresses if you want to get the Reply To address.";
                MessageBox.Show(tell);
            }
            return strAddress;
             */
            return ""; 
        }

        public static void DeleteOutlookMessage(String strID, OutlookMAPIFolder xInbox)
        {
            //try
            //{
            //    Outlook.MAPIFolder xFolder = xInbox.FolderGet("Scanned").xFolder;
            //    Outlook.Items emails = xInbox.Items;
            //    for (Int32 i = 1; i <= emails.Count; i++)
            //    {
            //        if (emails[i] is Outlook.MailItem)
            //        {
            //            Outlook.MailItem xItem = (Outlook.MailItem)emails[i];
            //            if (Tools.Strings.StrCmp(xItem.EntryID, strID))
            //            {
            //                xItem.Move(xFolder);
            //                return;
            //            }
            //        }
            //        if (emails[i] is Outlook.PostItem)
            //        {
            //            Outlook.PostItem xPost = (Outlook.PostItem)emails[i];
            //            if (Tools.Strings.StrCmp(xPost.EntryID, strID))
            //            {
            //                xPost.Move(xFolder);
            //                return;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //    //nError.HandleError(new nError.nErrorObject(ee.Message, "void DeleteOutlookMessage(String strID, Outlook.MAPIFolder xInbox)", 0, "EMailProcessor.cs", "Rz3_Common.EMailProcessor", ee.ToString(), "Rz3_Common.EMailProcessor.void DeleteOutlookMessage(String strID, Outlook.MAPIFolder xInbox)"));
            //}
        }

    }

    public class MessageInfo
    {
        public String FromAddress = "";
        public String ToAddress = "";
        public String Subject = "";
        public DateTime Sent;
        public ArrayList Attachments;
        public String Body = "";
        public String UniqueID = "";
        public String MAPID = "";
    }

}
