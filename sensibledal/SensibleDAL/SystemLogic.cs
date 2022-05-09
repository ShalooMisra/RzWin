using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using SensibleDAL.dbml;
using Serilog;
using Serilog.Context;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

namespace SensibleDAL
{
    public class SystemLogic
    {



        public class Logs
        {

            public static void LogFS(StreamWriter sw, string msg)
            {
                string message = DateTime.Now.ToShortTimeString() + ": " + msg + Environment.NewLine;
                Console.WriteLine(message);
                sw.Write(message);
            }


            public static void LogEvent(Exception ex, string custom_message = null, bool emailAlert = true)
            {
                string message = ex.Message;
                if (!string.IsNullOrEmpty(custom_message))
                    message = custom_message;
                message += " <br />StackTrace: " + ex.StackTrace;
                LogEvent(SM_Enums.LogType.Error, message, emailAlert);
            }




            public static void LogEvent(SM_Enums.LogType logType, string message, bool emailAlert = true, string systemName = "Portal")
            {
                try
                {

                    if (systemName != "Portal")
                        return;
                    if (message.Contains("Thread was being aborted"))
                        return;


                    //Get the current Page if any
                    string IP = HttpContext.Current.Request.UserHostAddress.ToString();
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    string path = HttpContext.Current.Request.Url.AbsolutePath;
                    string host = HttpContext.Current.Request.Url.Host;


                    //We may get many of the same error by IP and message in a short amount of time.  Limit matching error logs to 1 ever 30 second when the IP and the Message are the same.
                    if (logType is SM_Enums.LogType.Error)
                        if (SuppressFrequentErrorLogs(message, IP))
                            return;




                    string userName = "No user found";
                    System.Security.Principal.IPrincipal CurrentUser = HttpContext.Current.User;
                    if (CurrentUser != null)
                        userName = CurrentUser.Identity.Name;

                    //Build message
                    //if (string.IsNullOrEmpty(message))
                    message += Environment.NewLine;
                    message += "<br />  IP: " + IP + Environment.NewLine;
                    message += "<br />  Url: " + url + Environment.NewLine;
                    message += "<br />  Path: " + path + Environment.NewLine;
                    message += "<br />  Host: " + host + Environment.NewLine;
                    message += "<br />  User: " + userName + Environment.NewLine;
                    //Get the current user form HttpContext

                    //Init Database Logger Database
                    string connStr = DataLogic.GetSystemConnectionString("SeriLog");
                    var tableName = "Logs";

                    var sinkOpts = new SinkOptions();
                    sinkOpts.TableName = tableName;


                    Serilog.Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.MSSqlServer(connectionString: connStr, sinkOptions: sinkOpts)
                        .CreateLogger();





                    //Serilog Properties
                    using (LogContext.PushProperty("IP", GetIP()))
                    using (LogContext.PushProperty("UserName", CurrentUser.Identity.Name))
                    using (LogContext.PushProperty("HostName", HttpContext.Current.Request.UserHostName))
                    using (LogContext.PushProperty("Url", url))
                    using (LogContext.PushProperty("Path", path))
                    using (LogContext.PushProperty("Host", host))


                        switch (logType)
                        {
                            case SM_Enums.LogType.Information:
                                {
                                    Serilog.Log.Information(SM_Enums.LogType.Information.ToString() + ": " + message);
                                    break;
                                }
                            case SM_Enums.LogType.Warning:
                                {
                                    Serilog.Log.Warning(SM_Enums.LogType.Warning.ToString() + ": " + message);
                                    if (emailAlert)
                                        Email.SendMail(Email.EmailGroupAddress.Systems, Email.EmailGroup.Systems, logType.ToString().ToUpper() + ": Portal Log Event", message);
                                    break;
                                }
                            case SM_Enums.LogType.Error:
                                {
                                    Serilog.Log.Error(SM_Enums.LogType.Error.ToString() + ": " + message);
                                    if (emailAlert)
                                        Email.SendMail(Email.EmailGroupAddress.Systems, Email.EmailGroup.Systems, logType.ToString().ToUpper() + ": Portal Log Event", message);
                                    break;
                                }
                        }
                    Serilog.Log.CloseAndFlush();
                }
                catch (Exception ex)
                {
                    Exception baseException = ex.GetBaseException();
                    if (baseException is System.Threading.ThreadAbortException)
                        return;

                    Email.SendMail("serilog@sensiblemicro.com", "ktill@sensiblemicro.com", "Serilog error", ex.Message + "Internal: " + ex.InnerException.Message);
                    Serilog.Log.CloseAndFlush();
                }
            }

            private static bool SuppressFrequentErrorLogs(string message, string IP)
            {

                //Extract the ip/message values from the message
                //string testIP = GetIPAddressFromLogMessage(message);
                string testIP = IP;
                string testMessage = message;
                string loggedIP = null;
                string loggedError = null;
                dbml.Log oldestLogFromLastFiveMinutes = null;
                List<dbml.Log> lastFiveMinutesLogs = new List<dbml.Log>();

                //First just check the oldest log in the last 5 minutes.
                using (SeriLogDataContext sdc = new SeriLogDataContext())
                    oldestLogFromLastFiveMinutes = sdc.Logs.Where(w => (DateTime)w.TimeStamp >= DateTime.Now.AddMinutes(-5) && w.Level == "Error").OrderByDescending(o => o.TimeStamp).FirstOrDefault();

                //If it's the same, suppress now, it's an ongoing event.
                if (oldestLogFromLastFiveMinutes != null)
                {
                    loggedIP = GetIPAddressFromLogMessage(oldestLogFromLastFiveMinutes.Message);
                    loggedError = GetMessageFromLogMessage(oldestLogFromLastFiveMinutes.Message);
                    if (testMessage.Trim() == loggedError.Trim() && testIP == loggedIP)
                        return true;

                }

                //List of Logs in last X minutes
                //Note - If errors are coming non-stop I won't see evidence of a specific log until I get a lapse of at least X minutes of that specific error.                
                using (SeriLogDataContext sdc = new SeriLogDataContext())
                    lastFiveMinutesLogs = sdc.Logs.Where(w => (DateTime)w.TimeStamp >= DateTime.Now.AddMinutes(-5) && w.Level == "Error").ToList();

                //Loop through the found error logs. 
                foreach (dbml.Log l in lastFiveMinutesLogs)
                {
                     loggedIP = GetIPAddressFromLogMessage(l.Message);
                     loggedError = GetMessageFromLogMessage(l.Message);

                    //Compare both the IP and the error message 
                    if (testMessage.Trim() == loggedError.Trim() && testIP == loggedIP)
                        return true;
                }

                //If no errors have occurred recently, we'll have no log message, etc.
                if (string.IsNullOrEmpty(loggedError) && string.IsNullOrEmpty(loggedIP))
                    return false;
                    
                //Check for Dev IP.
                if (testMessage.Trim() == loggedError.Trim() && testIP == loggedIP)
                    return true;

                return false;
            }

            private static string GetMessageFromLogMessage(string message)
            {
                //Extract the Message
                string ret = "";
                int charLocation = message.IndexOf("<", StringComparison.Ordinal);
                if (charLocation > 0)
                {

                    ret = message.Substring(0, charLocation);
                    ret = ret.Replace("\r\n", "");
                    ret = ret.Replace("Error: ", "");
                }
                return ret;
            }

            private static string GetIPAddressFromLogMessage(string message)
            {
                //Extract the IP
                string ret = "";

                //Regex pattern to detect IP Addresses
                Regex rgxIp = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                MatchCollection result = rgxIp.Matches(message);
                //Check for match results
                if (result != null && result.Count > 0)
                {
                    //If not null, then should be a single result
                    ret = result[0].Value;
                }
                else if (message.Substring(0, 70).Contains("::1"))
                    return "::1";


                return ret;
            }

            public static String GetIP()
            {
                String ip =
                    HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (string.IsNullOrEmpty(ip))
                {
                    ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                return ip;
            }

        }


        public class Email
        {

            public class EmailGroup
            {
                public static string PortalAlerts = "portal_alerts@sensiblemicro.com";
                public static string Systems = "systems@sensiblemicro.com";

            }
            public class EmailGroupAddress
            {
                public static string PortalAlert = "portal_alert@sensiblemicro.com";
                public static string RzAlert = "rz_alert@sensiblemicro.com";
                public static string Systems = "systems@sensiblemicro.com";
                public static string PortalWelcome = "portal_welcome@sensiblemicro.com";


            }
            //public static void SendMail(string from, string to, string subject, string body, List<string> cc = null, List<string> bcc = null, bool isHTML = true, string smtpSrv = "smtp.sensiblemicro.local", string fromName = "")
            //{
            //    SendMail(from, to, subject, body, cc.ToArray(), bcc.ToArray(), isHTML, smtpSrv, fromName);
            //}

            public static void SendMail(string from, string to, string subject, string body, string[] cc = null, string[] bcc = null, bool isHTML = true, string smtpSrv = "smtp.sensiblemicro.local", string fromName = "")
            {
                try
                {
                    MailMessage objMail = new MailMessage(from, to, subject, body);

                    //Set the From name if possible, else default to the from address
                    if (string.IsNullOrEmpty(fromName))
                        fromName = from;
                    objMail.From = new MailAddress(from, fromName);




                    objMail.IsBodyHtml = isHTML;
                    SmtpClient objsmtp = new SmtpClient(smtpSrv, 25);
                    if (bcc != null)
                        foreach (string s in bcc)
                            objMail.Bcc.Add(s);
                    if (cc != null)
                        foreach (string s in cc)
                            objMail.CC.Add(s);
                    objsmtp.EnableSsl = false;
                    objsmtp.Send(objMail);
                }
                catch (Exception ex)
                {
                    string test = ex.Message;
                }
            }

        }
    }
}
