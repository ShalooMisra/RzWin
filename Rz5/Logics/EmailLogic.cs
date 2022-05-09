using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using NewMethod;
using System.Net.Mail;
using Outlook;
using OutlookApp = Outlook.Application;
using Rz5.Enums;
using GoogleApis;
using System.Windows.Forms;
using NewMethod.Enums;

namespace Rz5
{
    public class EmailLogic : NewMethod.Logic
    {
        public override void ActsListStatic(Context x, ActSetup set)
        {
            base.ActsListStatic(x, set);
            if (((ContextNM)x).CheckPermit("System:View:ViewEmailBlaster"))
            {
                ActHandle h = new ActHandle(new Act("Email", new ActHandler(EmailShow)));
                set.Add(h);
                h.SubActs.Add(new ActHandle(new Act("Email Blaster", new ActHandler(EmailShow))));
            }
        }
        public void EmailShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).EmailBlasterShow((ContextRz)x);
            args.Result(true);
        }
        public virtual void AddContactInfoExtra(ContextRz context, string DetailTable, bool team = false)
        {

        }
        public virtual void AddAgentInfoExtra(ContextRz context, string DetailTable)
        {

        }
        public virtual Tools.nEmailMessage GetEmailMessage(blast_emailtemplate xTemplate, blast_emailserver xServer)
        {
            return new Tools.nEmailMessage();
        }
        public virtual ArrayList GetNotifyEmailList(ContextRz context, NewMethod.n_user u)
        {
            ArrayList a = u.GetNotifyEmailList(context);
            return a;
        }

        public virtual void SendGenericEmailMessage(ContextRz context, string to, string from, string subject, string body, List<string> cc, bool isHtml = true)
        {
            MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from, from, Encoding.UTF8);
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = body;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = isHtml;
            mail.Priority = MailPriority.High;
            SmtpClient client = GetSMTPClient();
            try
            {
                client.Send(mail);
            }
            catch (System.Exception ex)
            {
                System.Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                context.Leader.Tell(errorMessage);
            }
        }

        private SmtpClient GetSMTPClient()
        {
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.sensiblemicro.local";
            client.EnableSsl = false;
            return client;
        }

        public string GetDefaultEmailTemplate(ContextRz context, nObject currentObject)
        {
            string ret = null;


            if (currentObject is ordhed)
            {
                switch (((ordhed)currentObject).OrderType)
                {
                    case Enums.OrderType.Invoice:
                        ret = GeDefaultEmailTemplate_Invoice(context, (ordhed)currentObject);
                        break;
                }
            }
            return ret;
        }

        private string GeDefaultEmailTemplate_Invoice(ContextRz context, ordhed o)
        {
            string ret = null;
            //	OrderShipped_Disty = 16cc356e39c24cd2acbd4da17625f69f
            //  OrderShipped = 2f8d14df24cc4911a7dc22fa4eb60d04
            n_user u = n_user.GetById(context, o.base_mc_user_uid);
            if (u != null)
            {
                if (u.IsTeamMember(context, "Distributor Sales"))
                    ret = "16cc356e39c24cd2acbd4da17625f69f";
            }

            return ret;
        }


        internal List<string> GetOrderEmailBccList(ContextRz context, ordhed xOrder, string templateName)
        {
            List<string> ret = new List<string>();
            switch (xOrder.OrderType)
            {
                case Enums.OrderType.Quote:
                    ret.Add(context.TheSysRz.TheQuoteLogic.QuoteBcc(xOrder));
                    break;
                case Enums.OrderType.Invoice:
                    ret.Add("shipping@sensiblemicro.com");
                    if (templateName == "_OrderShipped - HS 2020")
                        ret.AddRange(GetBccListForOrder_Invoice(context, xOrder));
                    break;
            }

            return ret;
        }




        private List<string> GetBccListForOrder_Invoice(ContextRz x, ordhed xOrder)
        {
            List<string> bccList = new List<string>();
            List<companycontact> contactList = x.QtC("companycontact", "select * From companycontact where base_company_uid = '" + xOrder.base_company_uid + "' AND ISNULL(send_company_shipping_email_alert, 0) = 1").Cast<companycontact>().ToList();
            foreach (companycontact c in contactList)
            {
                if (Tools.Email.IsEmailAddress(c.primaryemailaddress))
                    if (!bccList.Contains(c.primaryemailaddress))
                        bccList.Add(c.primaryemailaddress.Trim().ToLower());
            }

            return bccList;
        }






        public bool SendEmail(ContextRz x, List<string> toList, string BodyText, string SubjectString, bool boolTextOnly, bool boolUserEdit, List<string> ccList, List<string> bccList, List<string> attachList, bool isDraft, string strSignature, string fromAddress, bool boolPreview, ref string error)
        {
            //Get the Email Client
            EmailClient emailClient = GetEmailClient(x);
            //Send based on selected Email Client
            string err = error;
            switch (emailClient)
            {
                case EmailClient.Outlook:
                    {  //context.xUser.email_signature
                        string strBcc = string.Join(",", bccList);
                        return SendOutlookEmail(x, toList, BodyText, SubjectString, boolTextOnly, boolUserEdit, ccList, bccList, attachList, isDraft, strSignature, ref err);
                        //ToolsOffice.OutlookOffice.SendOutlookMessage(toAddress, bdy, strSubject, false, true, "", AttachmentFileString, false, null, strBcc, replyTo, strSignature, context.xUser.email_signature, ref err);

                    }

                case EmailClient.Gmail:
                    return SendGmail(x, SubjectString, BodyText, toList, ccList, bccList, attachList, isDraft, fromAddress);


                case EmailClient.Generic:
                    {
                        //SendGenericEmail(context, toAddress, bdy, strSubject, textOnly, false, ccList, strAttachFile, false, colAddresses, bccList, replyTo, file_name, strSignature, ref err, fromAddress);
                        return SendGenericEmail(x, SubjectString, BodyText, toList, ccList, bccList, attachList, isDraft, fromAddress, boolPreview);

                    }

            }

            return false;
        }



        public EmailClient GetEmailClient(ContextRz x)
        {
            switch (x.xUser.email_client.ToLower())
            {
                case "outlook":
                    return EmailClient.Outlook;
                case "gmail":
                case "google":
                    return EmailClient.Gmail;
                case "generic":
                    return EmailClient.Generic;
                default:
                    return EmailClient.Generic;
            }
        }

        //private void GetPerUserNoficationsList(ContextRz context, NewMethod.n_user yUser, ordhed xOrder, ArrayList colAddresses)
        //{
        //    switch (yUser.name.ToLower())
        //    {
        //        case "larrym":
        //            {
        //                colAddresses.Add("bavila@sensiblemicro.com");
        //                break;
        //            }                    
        //    }
        //}

        public bool SendGmail(ContextRz context, string strSubject, string bdy, List<string> toList, List<string> ccList, List<string> bccList, List<string> attachmentList, bool isDraft, string from)
        {
            try
            {
                gmailapi.CreateGmailMessage(strSubject, bdy, toList, ccList, bccList, attachmentList, isDraft, from);
                return true;

            }
            catch (System.Exception ex)
            {
                context.Leader.Tell(ex.Message);
                return false;
            }

        }





        public bool SendGenericEmail(ContextRz context, string strSubject, string bdy, List<string> toList, List<string> ccList, List<string> bccList, List<string> attachList, bool isDraft, string fromAddress, bool boolPreview)
        {
            //KT Since no preview window, let's ask they user if they are sure.
            try
            {
                if (toList.Count > 1)
                    throw new System.Exception("nEmailMessage does not support multiple 'To:' addresses.");
                string strToAddress = toList[0];
                string strCCConcat = string.Join(",", ccList);
                string strBCCConcat = string.Join(",", bccList);
                string attachFileConcat = string.Join(",", attachList);

                string confirmDetails = "Subject:  " + strSubject + Environment.NewLine + Environment.NewLine + "To:  " + strToAddress + Environment.NewLine + "Cc:  " + strCCConcat + Environment.NewLine + "Bcc:  " + strBCCConcat;
                if (boolPreview)
                    if (!context.Leader.AskYesNoLarge(Environment.NewLine + Environment.NewLine + confirmDetails, "Ready to send this email with the following?"))
                        return false;


                Tools.nEmailMessage nmsg = new Tools.nEmailMessage();
                nmsg.IsHTML = true;
                nmsg.HTMLBody = bdy;
                nmsg.FromAddress = fromAddress;

                nmsg.ToAddress = strToAddress;
                nmsg.Subject = strSubject;
                nmsg.ServerName = "smtp.sensiblemicro.local";
                nmsg.BccRecipients = bccList;
                nmsg.CcRecipients = ccList;

                nmsg.ServerPort = 25;
                if (!string.IsNullOrEmpty(attachFileConcat))
                    nmsg.AddAttachment(attachFileConcat);

                //bool showPreview = false;
                //if (showPreview)
                //    ShowGenericEmailPreview(bdy);
                bool sent = nmsg.Send();
                if (sent)
                {
                    context.Leader.Tell("Successfully sent email." + Environment.NewLine + nmsg.Subject + Environment.NewLine + nmsg.ToAddress);
                    return true;
                }
                else
                    return false;
            }

            catch (System.Exception ex)
            {
                return false;
            }

        }


        public void SendGenericEmail(ContextRz context, string to, string bdy, string strSubject, bool text, bool boolPreview, List<string> ccList, string strAttachFile, bool v3, ArrayList colAddresses, List<string> bccList, string v4, string file_name, string email_signature, ref string err, string fromAddress)
        {


            //KT Since no preview window, let's ask they user if they are sure.
            string strCCConcat = string.Join(",", ccList);
            string strBCCContat = string.Join(",", bccList);
            string confirmDetails = "Subject:  " + strSubject + Environment.NewLine + Environment.NewLine + "To:  " + to + Environment.NewLine + "Cc:  " + strCCConcat + Environment.NewLine + "Bcc:  " + strBCCContat;
            if (!context.Leader.AskYesNoLarge(Environment.NewLine + Environment.NewLine + confirmDetails, "Ready to send this email with the following?"))
                return;


            Tools.nEmailMessage nmsg = new Tools.nEmailMessage();
            nmsg.IsHTML = !text;
            nmsg.HTMLBody = bdy;
            nmsg.FromAddress = fromAddress;
            nmsg.ToAddress = to;
            nmsg.Subject = strSubject;
            nmsg.ServerName = "smtp.sensiblemicro.local";
            nmsg.BccRecipients = bccList;
            nmsg.CcRecipients = ccList;

            nmsg.ServerPort = 25;
            if (!string.IsNullOrEmpty(strAttachFile))
                nmsg.AddAttachment(strAttachFile);

            bool showPreview = false;
            if (showPreview)
                ShowGenericEmailPreview(bdy);
            bool sent = nmsg.Send();
            if (sent)
                context.Leader.Tell("Successfully sent email." + Environment.NewLine + nmsg.Subject + Environment.NewLine + nmsg.ToAddress);

        }

        private void ShowGenericEmailPreview(string bdy)
        {
            Form emailForm = new System.Windows.Forms.Form();
            emailForm.FormBorderStyle = FormBorderStyle.Sizable;
            emailForm.AutoSize = true;
            System.Drawing.Rectangle rect = Screen.AllScreens[0].Bounds;
            WebBrowser browser = new System.Windows.Forms.WebBrowser();
            browser.Width = Convert.ToInt32(rect.Width * .8);
            browser.DocumentText = bdy;
            emailForm.Controls.Add(browser);
            emailForm.ShowDialog();
        }


        //public void SendOutlookEmail(ContextRz context, string strAddress, string bdy, string strSubject, bool textOnly, bool boolPreview, string ccString, string strAttachFile, ArrayList colAddresses, string bccString, string file_name, string email_signature, ref string err)
        //{
        //    OutlookApp outlookApp = new OutlookApp();
        //    MailItem mi = outlookApp.CreateItem(OlItemType.olMailItem);
        //    mi.Subject = strSubject;
        //    mi.To = strAddress;
        //    //mi.Body = bdy;
        //    mi.HTMLBody = bdy;
        //    mi.CC = ccString;
        //    mi.BCC = bccString;
        //    if (!string.IsNullOrEmpty(strAttachFile))
        //    {
        //        mi.Attachments.Add(strAttachFile);
        //    }
        //    mi.Importance = OlImportance.olImportanceHigh;
        //    mi.Display(false);

        //}


        public bool SendOutlookEmail(ContextRz x, List<string> toList, string bodyText, string subjectString, bool boolTextOnly, bool boolUserEdit, List<string> ccList, List<string> bccList, List<string> attachList, bool isDraft, string strSignature, ref string err)
        {
            try
            {


                OutlookApp outlookApp = new OutlookApp();
                MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem);
                mailItem.Subject = subjectString;
                mailItem.HTMLBody = bodyText;
                Recipients mailRecipients = mailItem.Recipients;
                foreach (String s in toList)
                {
                    Recipient oTORecip = mailRecipients.Add(s);
                    oTORecip.Type = (int)OlMailRecipientType.olTo;
                    oTORecip.Resolve();
                }

                foreach (String s in ccList)
                {
                    Recipient oCCRecip = mailRecipients.Add(s);
                    oCCRecip.Type = (int)OlMailRecipientType.olCC;
                    oCCRecip.Resolve();
                }

                foreach (String s in bccList)
                {
                    Recipient oBCCRecip = mailRecipients.Add(s);
                    oBCCRecip.Type = (int)OlMailRecipientType.olBCC;
                    oBCCRecip.Resolve();
                }


                //mailItem.To = toList;
                //if (!string.IsNullOrEmpty(cCString))
                //    mailItem.CC = cCString;
                //if (!string.IsNullOrEmpty(strBCC))
                //    mailItem.BCC = strBCC;

                Attachments mailAttachments = mailItem.Attachments;
                int attachmentIndex = 0;
                foreach (String s in attachList)
                {
                    attachmentIndex++;
                    Outlook.Attachment oAttach = mailAttachments.Add(s, "", "", "attachment" + attachmentIndex.ToString());
                }

                //if (!string.IsNullOrEmpty(strAttachFile))
                //    mailItem.Attachments.Add(strAttachFile);

                //Set a high priority to the message
                mailItem.Importance = OlImportance.olImportanceHigh;

                mailItem.Display(false);

                return true;
            }
            catch (System.Exception ex)
            {
                //if (ex is Microsoft.Office.Interop.Outlook.Exception)
                return false;
            }
        }


        //public bool SendOutlookEmail(string toAddress, string bodyText, string subjectString, bool boolTextOnly, bool boolUserEdit, string cCString, string strAttachFile, bool boolForceSilent, ArrayList colCC, string strBCC, string strReplyAddress, string strOtherAttachment, string strSignature, bool bDeliverNow, ref string error)
        //{
        //    try
        //    {


        //        OutlookApp outlookApp = new OutlookApp();
        //        MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem);
        //        mailItem.Subject = subjectString;
        //        mailItem.HTMLBody = bodyText;
        //        mailItem.To = toAddress;
        //        if (!string.IsNullOrEmpty(cCString))
        //            mailItem.CC = cCString;
        //        if (!string.IsNullOrEmpty(strBCC))
        //            mailItem.BCC = strBCC;
        //        if (!string.IsNullOrEmpty(strAttachFile))
        //            mailItem.Attachments.Add(strAttachFile);

        //        //Set a high priority to the message
        //        mailItem.Importance = OlImportance.olImportanceHigh;

        //        mailItem.Display(false);

        //        return true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        //if (ex is Microsoft.Office.Interop.Outlook.Exception)
        //        return false;
        //    }
        //}
    }
}
