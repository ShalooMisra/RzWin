using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HubspotApis;
using System.Net.Mail;
using SensibleDAL;
using NewMethod;

namespace Rz5
{
    public class PhoneLogic : NewMethod.Logic
    {
        public static string TheColor = "#0000FF";
        public static string SummaryColor1 = "#66FFCC";
        public static string SummaryColor2 = "#66CCFF";
        public virtual String GetCallSQLWhere(ContextRz context, PhoneReportArgs args)
        {
            String strWhere = "";
            if (args.UserIDs.Count > 0)
                strWhere = "base_mc_user_uid in (" + nTools.GetIn(args.UserIDs) + ") ";
            else
                strWhere = "base_mc_user_uid not in ('NOTANID') ";
            if (Tools.Strings.StrExt(args.ExtraSQL))
                strWhere += " and " + args.ExtraSQL;
            if (args.OnlyCustomers)
                strWhere += " and isnull(is_customer, 0) = 1 ";
            if (args.OnlyProspects)
                strWhere += " and isnull(is_prospect, 0) = 1 ";
            if (args.OnlyIn)
                strWhere += " and direction = 'in' ";
            if (args.OnlyOut)
                strWhere += " and direction = 'out' ";
            if (args.OnlyInfo)
                strWhere += " and ( isnull(companyname, '') > '' or isnull(contact, '') > '' ) ";
            if (args.OnlyOEM)
                strWhere += " and isnull(abs_type, '') not like '%Dist%' ";
            if (args.OnlyDist)
                strWhere += " and abs_type like '%Dist%' ";

            return strWhere;
        }
        public virtual String GetCallSQL(ContextRz context, PhoneReportArgs args)
        {
            String ret = GetCallSQLWhere(context, args);
            ret = "select * from " + ((SysRz5)context.xSys).ThePhoneLogic.GetPhoneCallTable() + " where " + ret + " order by calldate ";
            if (args.Descending)
                ret += " desc";
            return ret;
        }
        public virtual String GetCallReportHtml(ContextRz context, PhoneReportArgs args)
        {
            StringBuilder sb = new StringBuilder();

            String strSQL = context.TheSysRz.ThePhoneLogic.GetCallSQL(context, args);
            DataTable d = context.Select(strSQL);
            long lngDuration = 0;
            long lngCount = 0;

            try
            {
                sb.Append("<h1>" + args.Caption + "</h1>");
                String strColor = "";
                sb.Append("<table width=100% border=0><tr><td><b>Agent</b></td><td><b>Date-Time</b></td><td><b>Phone Number</b></td><td><b>Duration</b></td><td><b>Company</b></td><td><b>Contact</b></td><td><b>Type</b></td><td><b>Notes</b></td></tr>");
                foreach (DataRow r in d.Rows)
                {
                    String strExtra = "";
                    bool call_list = nData.NullFilter_Boolean(r["from_call_list"]);
                    if (call_list)
                        strExtra = "[On Call List]";
                    String strBackColor = "white";
                    if (nData.NullFilter_Boolean(r["is_agent_customer"]))
                        strBackColor = "#EEEEFF";
                    else if (nData.NullFilter_Boolean(r["is_agent_prospect"]))
                        strBackColor = "#EEFFEE";
                    else if (nData.NullFilter_Boolean(r["is_customer"]))
                        strBackColor = "#FFEEEE";
                    if (Tools.Strings.StrCmp(nData.NullFilter_String(r["phonenumber"]), "in") || Tools.Strings.StrCmp(nData.NullFilter_String(r["direction"]), "in"))
                        strColor = "#00FF00";
                    else
                        strColor = PhoneLogic.TheColor;
                    String strCompanyColor = strColor;
                    bool other_agent = false;
                    try
                    {
                        if (nData.NullFilter(r["alternate_1"]) == "x")
                            other_agent = true;
                    }
                    catch { }
                    if (other_agent)
                        strCompanyColor = "#AAAAAA";
                    sb.Append("<tr bgcolor=\"" + strBackColor + "\"><td nowrap><font color=" + strColor + ">" + nData.NullFilter_String(r["username"]) + "</font></td><td nowrap><font color=" + strColor + ">" + nTools.DateFormat_ShortDateTime(nData.NullFilter_Date(r["calldate"])) + "</font></td><td nowrap><font color=" + strColor + "><a href=\"phonenumbersearch.rzl?number=" + nTools.StripPhoneNumber(nData.NullFilter_String(r["PhoneNumber"])) + "\">" + nData.NullFilter_String(r["PhoneNumber"]) + "</a></font>");

                    String extraLinks = ExtraLinksRender(context, sb, r);

                    sb.Append("</td><td nowrap><font color=" + strColor + ">" + Tools.Dates.FormatHMS(nData.NullFilter_Long(r["Duration"])) + extraLinks + "</font></td>");
                    sb.Append("<td nowrap><font color=" + strCompanyColor + ">" + nData.NullFilter_String(r["company"]) + "</font></td><td nowrap><font color=" + strCompanyColor + ">" + nData.NullFilter_String(r["contact"]) + "</font></td>");
                    sb.Append("<td nowrap><font color=" + strColor + ">" + nData.NullFilter_String(r["abs_type"]) + "</font></td><td nowrap><font color=" + strColor + ">" + strExtra + "&nbsp;</font></td></tr>");
                    lngDuration += Tools.Data.NullFilterIntegerFromIntOrLong(r["duration"]);
                    lngCount++;
                }
                sb.Append("</table><br><br>");
                sb.Append("<h2>" + Tools.Number.LongFormat(lngCount) + " calls for a total of " + Tools.Dates.FormatHMS(lngDuration) + "</h2>");
                sb.Append("<br><table border=\"1\"><tr><td><b>Legend<b></td></tr><tr><td bgcolor=\"#EEEEFF\">Customer</td></tr><tr><td bgcolor=\"#EEFFEE\">Prospect</td></tr><tr><td bgcolor=\"#FFEEEE\">Another's Customer</td></tr><tr><td><font color=\"#00FF00\">Call In</td></tr><tr><td><font color=\"#0000FF\">Call Out</td></tr></table><br>");
            }
            catch { }
            if (context.xUser.IsDeveloper())
                sb.Append("<br><br><br>SQL:<br>" + nTools.ConvertTextToHTML(strSQL));
            sb.Append("<br><br>Including Agents:<br>");
            foreach (String s in args.UserIDs)
            {
                NewMethod.n_user xu = (NewMethod.n_user)context.xSys.Users.GetByID(s);
                if (xu != null)
                    sb.Append(xu.Name + "<br>");
            }
            if (Tools.Strings.StrExt(args.ExtraSQL))
                sb.Append("<br>Extra Criteria:<br>" + args.ExtraSQL);
            return sb.ToString();
        }
        protected virtual String ExtraLinksRender(ContextRz context, StringBuilder sb, DataRow r)
        {
            return "";
        }
        public virtual String GetExtraCallUserWhere(ContextRz context, NewMethod.n_user u)
        {
            return "";
        }
        public virtual void SetFromCallList(ContextRz context, NewMethod.n_user u, Rz5.companycontact ct, Rz5.phonecall p)
        {

        }
        public virtual bool ApplyExtraCallExit()
        {
            return false;
        }
        public virtual string GetPhoneCallTable()
        {
            return "phonecall";
        }
        public virtual void ApplyExtraCallStuff(ContextRz context, phonecall c, String strippedphone, String strUserWhere)
        {

        }


        public SortedList UsersByExtension = null;
        public virtual void CacheUsers(ContextRz context, ref string status)
        {
            StringBuilder sb = new StringBuilder();
            UsersByExtension = new SortedList();
            ArrayList a = context.QtC("n_user", "select * from n_user where isnull(is_inactive, 0) = 0 and isnull(phone_ext, '') > ''");
            foreach (NewMethod.n_user u in a)
            {
                String ss = u.GetSetting(context, "phone_server_name");
                if (Tools.Strings.StrExt(ss))
                {
                    if (!Tools.Strings.StrCmp(ss, Environment.MachineName))
                        continue;
                }
                String[] exs = Tools.Strings.Split(u.phone_ext, ",");
                foreach (String ex in exs)
                {
                    if (Tools.Strings.StrExt(ex))
                    {
                        try { UsersByExtension.Add(ex, u); }
                        catch { sb.AppendLine(u.name + " apparently has a duplicate extension."); }
                    }
                }
            }
            status = sb.ToString();
        }
        public void ParseCalls(PhoneCallArgs args)
        {
            while (Tools.Strings.HasString(args.PhoneBuffer, "\n\n"))
            {
                args.PhoneBuffer = args.PhoneBuffer.Replace("\n\n", "\n");
            }
            if (!Tools.Strings.StrExt(args.PhoneBuffer))
                return;
            bool bComplete = args.PhoneBuffer.EndsWith("\n");
            String[] ary = Tools.Strings.Split(args.PhoneBuffer, "\n");
            int s = ary.Length;
            if (!bComplete)
            {
                s = ary.Length - 1;
                args.PhoneBuffer = LeftOver(ary[ary.Length - 1]);
            }
            else
                args.PhoneBuffer = "";
            StringBuilder sb = new StringBuilder();
            if (s > 0)
            {
                for (int i = 0; i < s; i++)
                {
                    PhoneCallArgs a = new PhoneCallArgs(args.TheContext, ary[i]);
                    ParseCall(a);
                    if (Tools.Strings.StrExt(a.TheStatus))
                        sb.AppendLine(a.TheStatus);
                }
            }
            args.TheStatus = sb.ToString();
        }
        public virtual void GotCall(Rz5.PhoneCallArgs args, Rz5.phonecall c)
        {

        }
        public virtual void ParseCall(PhoneCallArgs args)
        {
            args.TheContext.Leader.Comment("Parsing " + args.TheLine + "...");
            if (!Tools.Strings.StrExt(args.TheLine))
                return;
            try
            {
                Stack stk = new Stack();
                string[] str = Tools.Strings.Split(args.TheLine, " ");
                foreach (string s in str)
                {
                    if (!Tools.Strings.StrExt(s))
                        continue;
                    stk.Push(s);
                }
                Rz5.phonecall SensibleCall = new Rz5.phonecall();
                SensibleCall.phonenumber = stk.Pop().ToString().Trim();//1
                SensibleCall.callextension = stk.Pop().ToString().Trim();//2
                string strDur = stk.Pop().ToString().Trim();//3
                SensibleCall.duration = (Int32.Parse(Tools.Strings.Left(strDur, 2)) * 60 * 60) + (Int32.Parse(Tools.Strings.Mid(strDur, 4, 2)) * 60) + (Int32.Parse(Tools.Strings.Mid(strDur, 7, 2)));
                stk.Pop();//4
                string date = stk.Pop().ToString().Trim();
                string time = stk.Pop().ToString().Trim();
                try
                {
                    SensibleCall.calldate = DateTime.Parse(date + "/" + DateTime.Now.Year.ToString() + " " + time + ":00");//5,6
                }
                catch
                {
                    SensibleCall.calldate = DateTime.Parse(date + "/" + DateTime.Now.Year.ToString());
                }
                string dir = "in";
                switch (stk.Pop().ToString().ToUpper().Trim())//7
                {
                    case "IVOT":
                    case "POT":
                        dir = "out";
                        break;
                }
                SensibleCall.direction = dir;
                SensibleCall.alldata += " | " + args.TheLine.Trim();
                NewMethod.n_user u = args.TheContext.TheSysRz.ThePhoneLogic.GetUserByExtension(args.TheContext, SensibleCall.callextension);
                if (u != null)
                {
                    SensibleCall.base_mc_user_uid = u.unique_id;
                    SensibleCall.username = u.name;
                    SensibleCall.main_mc_team_uid = u.main_n_team_uid;
                    args.TheContext.TheLeaderRz.Comment("Using " + u.name + " from ext " + SensibleCall.callextension);
                }
                //if (SensibleCall.duration <= 10 && SensibleCall.phonenumber != "0114989122216861")
                if (SensibleCall.duration <= 5)
                    args.TheStatus += "Skipped save call. Duration under 10 seconds : " + SensibleCall.duration.ToString() + "\r\n";
                else
                {
                    SensibleCall.Insert(args.TheContext);
                    SensibleCall.ApplyExtraCallStuffCompanyContact(args.TheContext);
                    args.TheStatus += "Saved call " + SensibleCall.ToString() + "\r\n";
                    //Log in Hubspot if we are this far            
                    //if ((SensibleCall.base_mc_user_uid == "a192e149aca4495585d2934e037d5898" || SensibleCall.base_mc_user_uid == "192e06d0d3994bde9348f0b6fea738d8" || SensibleCall.base_mc_user_uid == "24172ac97b0f4d9688ae9945bc64d395") && SensibleCall.strippedphone != "6179256372") //Kevin Till
                    if (u != null)
                        if (u.is_hubspot_enabled)
                        {
                            //List of numbers that hubpot uses that we need to omit else it will cause duplication
                            //i.e. when HS is set to dial your phone 1st to initiate a call.
                            List<string> hubspotIgnoreList = HubspotLogic.GetDialInHubspotNumbers();
                            if (!hubspotIgnoreList.Contains(SensibleCall.strippedphone)) //Web Dialed-numbers willa already be there, shouldn't be added
                                LogCallToHubspot(SensibleCall, args);
                        }


                }
                SensibleCall = null;
            }
            catch (Exception ex)
            {
                args.TheStatus += "Call parse error: " + ex.Message + "\r\n";
            }

        }



        private void LogCallToHubspot(phonecall call, PhoneCallArgs args)
        {
            try
            {
                HubspotApi hsa = new HubspotApi();

                company comp = company.GetById(args.TheContext, call.base_company_uid);
                n_user u = n_user.GetById(args.TheContext, call.base_mc_user_uid);
                HubspotApi.HubPhoneCall hp = new HubspotApi.HubPhoneCall();
                string companyname = "";
                if (comp != null)
                {
                    hp.companyWebAddress = comp.primarywebaddress ?? "";
                    companyname = comp.companyname;
                }
                else
                    companyname = call.phonenumber;

                //hp.contactEmailAddress = contact.primaryemailaddress;
                hp.durationMilliseconds = call.duration;
                hp.externalAccountId = call.base_mc_user_uid; //rzAgent uid
                hp.externalId = call.unique_id; //phonecall uid
                hp.ownerEmailAddress = u.email_address;
                hp.status = "COMPLETED";//Not marking as completed.
                DateTime callTimestamp = call.calldate;
                hp.timestamp = HubspotApi.ConvertDateTimeToUnixTimestampMillis(callTimestamp);

                if (call.direction.ToLower() == "in")//inbound
                {
                    hp.fromNumber = call.phonenumber;
                }
                else
                    hp.toNumber = call.phonenumber;//outbound

                hp.body = "Logged from Rz (" + call.phonenumber + ")";
                if (string.IsNullOrEmpty(hp.companyWebAddress))
                    hp.body += ":  No Company Website set for " + companyname + " in Rz.  Cannot Associate call with company.";
                HubspotApi.Engagement theCall = HubspotApi.Engagements.CreateHubspotCall(hp);
                if (!string.IsNullOrEmpty(theCall.engagement.id.ToString()))
                {
                    call.hubspot_engagement_id = theCall.engagement.id.ToString();
                    call.Update(args.TheContext);
                    args.TheStatus += "Call Successfully logged to Hubspot. EngagementID: " + call.hubspot_engagement_id;
                }


                //args.TheContext.Leader.Tell("Successfully logged call to Hubspot.");
            }
            catch (Exception ex)
            {
                string errorBody = ex.Message + Environment.NewLine;
                errorBody += "Extension: " + call.phoneline ?? "Not Found";
                errorBody += "<br />";
                errorBody += "Number: " + call.phonenumber ?? "Not Found";
                errorBody += "<br />";
                errorBody += "Direction: " + call.direction ?? "Not Found";
                errorBody += "<br />";
                errorBody += "User: " + call.username ?? "Not Found";
                errorBody += "<br />";
                errorBody += "Time: " + call.timestarted ?? "Not Found";
                errorBody += "<br />";
                //args.TheContext.Leader.Error(ex);
                SendErrorToAdmin(errorBody);

            }

        }

        private void SendErrorToAdmin(string error)
        {
            SmtpClient smtp = new SmtpClient("smtp.sensiblemicro.local");
            smtp.EnableSsl = false;
            smtp.Port = 25;
            smtp.Send("rz_phonecall@sensiblemicro.com", "ktill@sensiblemicro.com", "Phonecall not logged in Hubspot", error);
        }


        public virtual string LeftOver(String leftover)
        {
            return leftover;
        }
        public NewMethod.n_user GetUserByExtension(ContextRz x, String strExt)
        {
            if (!Tools.Strings.StrExt(strExt))
                return null;
            string s = "";
            if (UsersByExtension == null)
                CacheUsers(x, ref s);
            return (NewMethod.n_user)UsersByExtension[strExt];
        }
    }
    public class PhoneCallArgs
    {
        public ContextRz TheContext;
        public String PhoneBuffer = "";
        public String TheLine = "";
        public String TheStatus = "";
        public bool DebugMode = false;
        public bool KeepAll = false;

        public PhoneCallArgs(ContextRz x, string buffer, bool debug = false)
        {
            TheContext = x;
            PhoneBuffer = buffer;
            DebugMode = debug;
        }
        public PhoneCallArgs(ContextRz x, string line)
        {
            TheContext = x;
            TheLine = line;
        }
    }
}
