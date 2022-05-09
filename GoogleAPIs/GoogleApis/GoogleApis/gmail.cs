using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Diagnostics;
using MimeKit;


namespace GoogleApis
{
    public class gmailapi
    {


        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static GmailService service;
        static string[] Scopes = { GmailService.Scope.GmailModify };
        static string ApplicationName = "Gmail API .NET Quickstart";
        static string DraftId;
        static string DraftUrl;
        static string ThreadId;


        public static void gmailProgram(string[] args)
        {

        }

        static void initGmailService()
        {
            //Authenticate
            string[] Scopes = { GmailService.Scope.GmailInsert, GmailService.Scope.GmailMetadata, GmailService.Scope.GmailModify };

            // Create Gmail API service.
            service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = authentication.getAuthenticationCredential(Scopes),
                ApplicationName = ApplicationName,
            });


        }

        internal static void CreateGmailTest(string subject, string body, string to, string from = "noreply@sensiblemicro.com", bool isDraft = true)
        {

            List<string> toList = new List<string>() { to };
            CreateGmailMessage(subject, body, toList, null, null, null, isDraft, from);
        }

        public static void CreateGmailMessage(string subject, string bodyhtml, List<string> toList, List<string> ccList, List<string> bccList, List<string> attachmentPathList, bool draft = true, string from = "noreply@sensiblemicro.com")
        {

            if (string.IsNullOrEmpty(from))
                from = "noreply@sensiblemicro.com";
            MailMessage mail = new MailMessage();
            mail.Subject = subject;
            mail.Body = bodyhtml;
            mail.From = new MailAddress(from);
            mail.IsBodyHtml = true;

            if (toList != null)
                foreach (string add in toList)
                {
                    if (string.IsNullOrEmpty(add))
                        continue;

                    mail.To.Add(new MailAddress(add));
                }

            if (ccList != null)
                foreach (string add in ccList)
                {
                    if (string.IsNullOrEmpty(add))
                        continue;

                    mail.CC.Add(new MailAddress(add));
                }

            //Always include ktill
            //if (!bccList.Contains("ktill@sensiblemicro.com"))
            //    bccList.Add("ktill@sensiblemicro.com");

            if (bccList != null)
                foreach (string add in bccList)
                {
                    if (string.IsNullOrEmpty(add))
                        continue;

                    mail.Bcc.Add(new MailAddress(add));
                }


            if (attachmentPathList != null)
                foreach (string path in attachmentPathList)
                {
                    if (string.IsNullOrEmpty(path))
                        continue;
                    Attachment attachment = new Attachment(path);//bytes, mimeType, Path.GetFileName(path), true);
                    mail.Attachments.Add(attachment);
                }

            MimeMessage mimeMessage = MimeMessage.CreateFromMailMessage(mail);
            Message message = new Message();
            message.Raw = Base64UrlEncode(mimeMessage.ToString());

            if (draft)
                ComposeDraft(message);
            //else
            //    SendMessage(message);

        }

        private static void SendMessage(Message message)
        {
            var result = service.Users.Messages.Send(message, "me").Execute();
        }

        private static void ComposeDraft(Message message)
        {
            initGmailService();
            if (service == null)
                throw new Exception("Gmail Service cannot be null.");

            Draft draft = new Draft();
            draft.Message = message;
            draft = service.Users.Drafts.Create(draft, "me").Execute();
            string messageID = draft.Message.Id;

            //No matter what I've trued, new drafts won't open up directly, you just ahve to click thiem 
            //from teh Gmail drafts ui first
            string url = @"https://mail.google.com/mail/u/0/#drafts?compose=" + draft.Id;
            DraftUrl = url;


            //Open the Browser to the draft (must be logged in)
            Console.WriteLine("ThreadId: " + ThreadId);
            Console.WriteLine("DraftId: " + DraftId);
            Console.WriteLine("DraftIUrl: " + DraftUrl);


            OpenDraftInBrowser(url);
            //Thus actually SENDS thge message, not just a draft.
            //var result = service.Users.Messages.Send(message, "me").Execute();

        }

        //From Google API .Net docs
        //https://developers.google.com/gmail/api/v1/reference/users/drafts/get
        private static Draft CreateDraft(String userId, Message email)
        {
            Draft draft = new Draft();
            draft.Message = email;

            try
            {
                return service.Users.Drafts.Create(draft, userId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return null;
        }


        private static void OpenDraftInBrowser(string Url)
        {

            Process.Start(Url);

        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }



        public static void ListGmailLabels(GmailService service)
        {
            // Define parameters of request.
            UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            // List labels.
            IList<Label> labels = request.Execute().Labels;
            Console.WriteLine("Labels:");
            if (labels != null && labels.Count > 0)
            {
                foreach (var labelItem in labels)
                {
                    Console.WriteLine("{0}", labelItem.Name);
                }
                Console.Read();
            }
            else
            {
                Console.WriteLine("No labels found.");
            }
        }

    }
}

