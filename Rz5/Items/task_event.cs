using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class task_event : task_event_auto
    {
        public NewMethod.n_user User
        {
            set
            {
                user_uid = value.unique_id;
                user_name = value.name;
            }
        }

        public usernote TaskGet(ContextNM context)
        {
            return usernote.GetById(context, task_uid);
        }

        public static String Report(ContextNM context, NewMethod.n_user u)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                ArrayList activity = context.QtC("task_event", "select * from task_event where user_name = '" + context.Filter(u.name) + "' and event_date >= '" + DateTime.Now.Subtract(TimeSpan.FromDays(7)).ToString() + "' order by event_date desc");

                sb.AppendLine("<table border=\"1\" cellpadding=\"2\" cellspacing=\"2\"><tr><td>Date</td><td>From</td><td>To</td><td>Title</td><td>Notes</td><td>Current</td></tr>");

                foreach (task_event evt in activity)
                {
                    usernote task = evt.TaskGet(context);
                    sb.AppendLine("<tr><td>" + Tools.Dates.DateFormat_ShortDateTime(evt.event_date) + "</td><td><font color=\"" + Tools.Html.GetHTMLColor(usernote.ColorByStatus(evt.from_status).ToArgb()) + "\">" + evt.from_user + "/" + evt.from_status + "</font></td><td><font color=\"" + Tools.Html.GetHTMLColor(usernote.ColorByStatus(evt.to_status).ToArgb()) + "\">" + evt.to_user + "/" + evt.to_status + "</font></td><td>" + task.Summary + "</td><td>" + evt.notes + "</td><td><font color=\"" + Tools.Html.GetHTMLColor(usernote.ColorByStatus(task.current_status).ToArgb()) + "\">" + task.current_status + "</font></td></tr>");
                }

                sb.AppendLine("</table>");
                return sb.ToString();
            }
            catch(Exception ex)
            {
                return "Report Error: " + ex.Message;
            }
        }
    }
}
