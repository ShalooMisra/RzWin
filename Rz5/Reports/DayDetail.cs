using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Tools;
//using ToolsWin;
using NewMethod;

namespace Rz5
{
    public class DayDetail
    {
        public static void CalculatePhoneEmailByDay(ContextRz context, String strTable, ref String strEmailTable, int days, Tools.Dates.DateRange dr, bool check_internal)
        {
            context.Reorg();
            //String strSQL = "";

            //context.Execute("alter table " + strTable + " add rowid varchar(50)");
            //context.Execute("update " + strTable + " set rowid = replace(cast(newid() as varchar(50)), '-', '')");

            //nTools.StripPhoneNumberField(xSys.xData, strTable, "phone");

            ////the agent's email address
            //context.Execute("alter table " + strTable + " add agent_email varchar(255)");
            //context.Execute("update " + strTable + " set agent_email  = (select max(email_address) from n_user where n_user.unique_id = " + strTable + ".the_n_user_uid)");

            //bool link_emails = false;
            //if (!Tools.Misc.IsDevelopmentMachine())
            //{
            //    //bring in the emails
            //    nData dj = context.Logic.GetEmailJournalConnection();

            //    DataTable relevant_emails = null;
            //    if (dj != null)
            //    {
            //        if (dj.CanConnect())
            //        {
            //            String strAgentEmails = nTools.GetIn(context.SelectScalarArray("select distinct(agent_email) from " + strTable + " where isnull(agent_email, '') > ''"));
            //            String strCustomerEmails = nTools.GetIn(context.SelectScalarArray("select distinct(email) from " + strTable + " where isnull(email, '') > ''"));

            //            if (Tools.Strings.StrExt(strAgentEmails) && Tools.Strings.StrExt(strCustomerEmails))
            //            {
            //                nDateRange er = new nDateRange(dr);
            //                er.EndDate = er.EndDate.Add(TimeSpan.FromDays(days + 1));

            //                strSQL = " select arc.id, arc.receiveddate, sender.email as sender, receiver.email as receiver from arc ";
            //                strSQL += " inner join arc_add sender on sender.id = arc.id and sender.type = 0 ";
            //                strSQL += " inner join arc_add receiver on receiver.id = arc.id and receiver.type = 1 ";
            //                strSQL += " where " + er.GetSQL("arc.receiveddate") + " ";

            //                if( check_internal )
            //                    strSQL += " and ( sender.email in (" + strAgentEmails + " ) or sender.email in (" + strCustomerEmails + " )  or receiver.email in (" + strAgentEmails + " )  or receiver.email in (" + strCustomerEmails + " ) )  ";
            //                else
            //                    strSQL += " and ( sender.email in (" + strCustomerEmails + " ) or receiver.email in (" + strCustomerEmails + " ) )  ";

            //                strSQL += " group by arc.id, arc.receiveddate, sender.email, receiver.email ";
            //                strSQL += " order by arc.receiveddate desc ";

            //                context.TheLeader.Comment("Finding emails....");
            //                relevant_emails = dj.GetDataTable(strSQL);

            //                if (relevant_emails != null)
            //                {
            //                    context.TheLeader.Comment("Saving emails....");
            //                    link_emails = xSys.xData.ImportDataTable(relevant_emails, strEmailTable);
            //                }
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    link_emails = true;
            //    context.Execute("select top 1 cast(1 as int) as id, getdate() as receiveddate, 'mike@recognin.com' as sender, '2001@recognin.com' as receiver into " + strEmailTable + " from partrecord");
            //    context.Execute("insert into " + strEmailTable + "(id, receiveddate, sender, receiver) values (2, getdate(), 'mike@recognin.com', '2001@recognin.com')");
            //}

            //bool phone_archive = xSys.xData.TableExists("phonecall_sys_archive");

            ////create the stat columns and fill them
            //for (int i = 0; i < days; i++)
            //{
            //    String strField = "phone_in_day_" + i.ToString();
            //    context.Execute("alter table " + strTable + " add " + strField + " int");

            //    strSQL = "update " + strTable + " set " + strField + " = (select isnull(count(*), 0) from phonecall where phonecall.direction = 'in' ";
                
            //    if( check_internal )
            //        strSQL += " and phonecall.base_mc_user_uid = " + strTable + ".the_n_user_uid ";

            //    strSQL += " and ( phonecall.strippedphone = " + strTable + ".phone or phonecall.alternate_1 = " + strTable + ".phone or phonecall.alternate_2 = " + strTable + ".phone or phonecall.alternate_3 = " + strTable + ".phone or phonecall.alternate_4 = " + strTable + ".phone) and datediff(d, calldate, dateadd(d, " + i.ToString() + ", " + strTable + ".quote_date)) = 0";
                
            //    if (phone_archive)
            //        strSQL += " and isnull(sys_archive_flag, 0) = 0 ";

            //    strSQL += ") where isnull(phone, '') > ''";
            //    context.Execute(strSQL);

            //    if (phone_archive)
            //    {
            //        strSQL = "update " + strTable + " set " + strField + " = " + strField + " + (select isnull(count(*), 0) from phonecall_sys_archive where phonecall_sys_archive.direction = 'in' ";
                    
            //        if( check_internal )
            //            strSQL += " and phonecall_sys_archive.base_mc_user_uid = " + strTable + ".the_n_user_uid ";

            //        strSQL += " and ( phonecall_sys_archive.strippedphone = " + strTable + ".phone or phonecall_sys_archive.alternate_1 = " + strTable + ".phone or phonecall_sys_archive.alternate_2 = " + strTable + ".phone or phonecall_sys_archive.alternate_3 = " + strTable + ".phone or phonecall_sys_archive.alternate_4 = " + strTable + ".phone) and datediff(d, calldate, dateadd(d, " + i.ToString() + ", " + strTable + ".quote_date)) = 0) where isnull(phone, '') > ''";

            //        context.Execute(strSQL);
            //    }

            //    strField = "phone_out_day_" + i.ToString();
            //    context.Execute("alter table " + strTable + " add " + strField + " int");
            //    strSQL = "update " + strTable + " set " + strField + " = (select isnull(count(*), 0) from phonecall where phonecall.direction <> 'in' ";
                
            //    if( check_internal )
            //        strSQL += " and phonecall.base_mc_user_uid = " + strTable + ".the_n_user_uid ";

            //    strSQL += " and ( phonecall.strippedphone = " + strTable + ".phone or phonecall.alternate_1 = " + strTable + ".phone or phonecall.alternate_2 = " + strTable + ".phone or phonecall.alternate_3 = " + strTable + ".phone or phonecall.alternate_4 = " + strTable + ".phone) and datediff(d, calldate, dateadd(d, " + i.ToString() + ", " + strTable + ".quote_date)) = 0 ";

            //    if (phone_archive)
            //        strSQL += " and isnull(sys_archive_flag, 0) = 0 ";

            //    strSQL += " ) where isnull(phone, '') > ''";
            //    context.Execute(strSQL);

            //    if (phone_archive)
            //    {
            //        strSQL = "update " + strTable + " set " + strField + " = " + strField + " + (select isnull(count(*), 0) from phonecall_sys_archive where phonecall_sys_archive.direction <> 'in' ";
                    
            //        if( check_internal )
            //            strSQL += " and phonecall_sys_archive.base_mc_user_uid = " + strTable + ".the_n_user_uid ";

            //        strSQL += " and ( phonecall_sys_archive.strippedphone = " + strTable + ".phone or phonecall_sys_archive.alternate_1 = " + strTable + ".phone or phonecall_sys_archive.alternate_2 = " + strTable + ".phone or phonecall_sys_archive.alternate_3 = " + strTable + ".phone or phonecall_sys_archive.alternate_4 = " + strTable + ".phone) and datediff(d, calldate, dateadd(d, " + i.ToString() + ", " + strTable + ".quote_date)) = 0) where isnull(phone, '') > ''";
            //        context.Execute(strSQL);
            //    }

            //    strField = "email_in_day_" + i.ToString();
            //    context.Execute("alter table " + strTable + " add " + strField + " int");
            //    if (link_emails)
            //    {
            //        strSQL = "update " + strTable + " set " + strField + " = (select count(*) from " + strEmailTable + " where sender = " + strTable + ".email ";
                    
            //        if( check_internal )
            //            strSQL += " and receiver = " + strTable + ".agent_email ";
            //        strSQL += " and datediff(d, receiveddate, dateadd(d, " + i.ToString() + ", " + strTable + ".quote_date)) = 0) where isnull(email, '') > ''";
            //        context.Execute(strSQL);
            //    }

            //    strField = "email_out_day_" + i.ToString();
            //    context.Execute("alter table " + strTable + " add " + strField + " int");
            //    if (link_emails)
            //    {
            //        strSQL = "update " + strTable + " set " + strField + " = (select count(*) from " + strEmailTable + " where receiver = " + strTable + ".email ";
            //        if( check_internal )
            //            strSQL += " and sender = " + strTable + ".agent_email ";
            //        strSQL += " and datediff(d, receiveddate, dateadd(d, " + i.ToString() + ", " + strTable + ".quote_date)) = 0) where isnull(email, '') > ''";
            //        context.Execute(strSQL);
            //    }
            //}
        }

        //public static void WriteDayTableHeader(BrowserPlain wb, int days)
        //{
        //    for (int i = 0; i < days; i++)
        //    {
        //        String cap = "Day " + i.ToString();
        //        if (i == 0)
        //            cap = "Day Of";

        //        wb.Add("<td nowrap>" + cap + "</td>");
        //    }
        //}

        //public static void WriteDay(BrowserPlain wb, String strRowID, int i, DataRow r, DateTime start)
        //{
        //    int act = 0;
        //    wb.Add(GetDay(strRowID, i, r, start, ref act));
        //}

        public static String GetDay(String strRowID, int i, DataRow r, DateTime start, ref int activity_count)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.Append("<td><table border=1>");

                DateTime xd = start;
                if (i > 0)
                    xd = xd.Add(TimeSpan.FromDays(i));

                switch (xd.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        sb.Append("<tr bgcolor=\"#C0C0C0\">");
                        break;
                    default:
                        sb.Append("<tr>");
                        break;
                }

                sb.Append("<td nowrap><font size=\"1\">Phone Out</font></td><td nowrap><font size=\"1\">Email Out</font></td><td nowrap><font size=\"1\">Phone In</font></td><td nowrap><font size=\"1\">Email In</font></td></tr>");

                switch (xd.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        sb.Append("<tr bgcolor=\"#C0C0C0\">");
                        break;
                    default:
                        sb.Append("<tr>");
                        break;
                }

                sb.Append("<td>");
                GetOne(sb, "phone_out_day_", i, r, strRowID, ref activity_count);
                sb.Append("</td><td>");
                GetOne(sb, "email_out_day_", i, r, strRowID, ref activity_count);
                sb.Append("</td><td>");
                GetOne(sb, "phone_in_day_", i, r, strRowID, ref activity_count);
                sb.Append("</td><td>");
                GetOne(sb, "email_in_day_", i, r, strRowID, ref activity_count);
                sb.Append("</td></tr>");
                sb.Append("</table></td>");
            }
            catch (Exception)
            {
            }

            return sb.ToString();
        }

        public static void GetOne(StringBuilder sb, String strKey, int i, DataRow r, String strRowID)
        {
            int act = 0;
            GetOne(sb, strKey, i, r, strRowID, ref act);  
        }

        public static void GetOne(StringBuilder sb, String strKey, int i, DataRow r, String strRowID, ref int act)
        {
            int count = 0;
            try
            {
                count = Tools.Data.NullFilterInt(r[strKey + i.ToString()]);
            }
            catch { }

            act += count;

            if (count == 0)
                sb.Append("0");
            else
            {
                sb.Append("<a href=x_show_" + strKey + i.ToString() + ".rzp?rowid=" + strRowID + ">" + Tools.Number.LongFormat(count) + "</a>");
            }
        }

        public static void HandleDayDetailNavigate(ContextRz context, GenericEvent e, String strTable, String strEmailTable)
        {
            e.Handled = true;
            String s = Tools.Strings.ParseDelimit(e.Message, "x_show_", 2);
            String strWhat = Tools.Strings.ParseDelimit(s, ".", 1);
            String strID = Tools.Strings.ParseDelimit(s, "rowid=", 2);

            String strThing = Tools.Strings.ParseDelimit(strWhat, "_", 1);
            String strDirection = Tools.Strings.ParseDelimit(strWhat, "_", 2);
            String strDay = Tools.Strings.ParseDelimit(strWhat, "_", 4);

            //get the line from the report
            DataTable d = context.Select("select * from " + strTable + " where rowid = '" + strID + "'");
            if (d == null)
            {
                context.TheLeader.Tell("This row couldn't be retreived from the database.");
                return;
            }

            if (d.Rows.Count < 1)
            {
                context.TheLeader.Tell("This row couldn't be retreived from the database.");
                return;
            }
            DataRow r = d.Rows[0];
            String strUserID = nData.NullFilter_String(r["the_n_user_uid"]);
            String strPhone = nData.NullFilter_String(r["phone"]);
            String strEmail = nData.NullFilter_String(r["email"]);
            String strAgentEmail = nData.NullFilter_String(r["agent_email"]);

            DateTime dtQuote = nData.NullFilter_Date(r["quote_date"]);

            switch (strThing.ToLower())
            {
                case "phone":
                    //show calls
                    String strCallWhere = " x.direction = '" + strDirection + "' and x.base_mc_user_uid = '" + strUserID + "' and x.strippedphone = '" + strPhone + "' and datediff(d, calldate, dateadd(d, " + strDay + ", cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(dtQuote) + "' as datetime))) = 0";
                    String strCallSQL = "select calldate as [Date], username as [Agent], phonenumber as [Phone], direction as [Direction], duration as [Seconds] from phonecall x where " + strCallWhere;
                    if (context.TheData.TheConnection.TableExists("phonecall_sys_archive"))
                        strCallSQL += " union all select calldate, username, phonenumber, direction, duration from phonecall_sys_archive x where " + strCallWhere;
                    strCallSQL += " order by calldate";

                    context.TheLeader.ShowHtml(context, "Calls", context.TheData.TheConnection.ConvertSQLToHTML(strCallSQL));

                    break;
                case "email":

                    String strEmailSQL = "select * from " + strEmailTable + " where ";

                    if (Tools.Strings.StrCmp(strDirection, "in"))
                        strEmailSQL += " sender = '" + strEmail + "' and receiver = '" + strAgentEmail + "'";
                    else
                        strEmailSQL += " receiver = '" + strEmail + "' and sender = '" + strAgentEmail + "'";

                    strEmailSQL += " and datediff(d, receiveddate, dateadd(d, " + strDay + ", cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(dtQuote) + "' as datetime))) = 0 order by receiveddate";

                    if (context.xUser.IsDeveloper())
                        context.TheLeader.ShowSql(strEmailSQL);

                    context.Logic.ShowEmailsBySQL(context, strEmailSQL, "");
                    break;
            }
        }
    }
}
