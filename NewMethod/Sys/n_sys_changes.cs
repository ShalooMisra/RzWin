using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Core;
using Tools.Database;
using System.Web;

namespace NewMethod
{
    public partial class SysNewMethod
    {
        private Timer NotifyTimer;
        private bool m_Recall = false;
        public bool Recall
        {
            get
            {
                if (!m_Recall)
                    return false;

                if (RecallConnection == null)
                    return false;

                //if (!xSys.RecallConnection.CanConnect())
                //    return false;

                return true;
            }
            set
            {
                m_Recall = value;
            }
        }
        public DataConnectionSqlServer RecallConnection;
        public String RecallMachineName;
        public bool RecallWarnings = false;

        //Public Functions
        //public void InstanceDataChanged(String strClass)
        //{
        //    CoreClassHandle c = GetClassByName(strClass);
        //    if (c == null)
        //        return;

        //    //c.instance_data_changed = System.DateTime.Now;

        //    //NotifyClassChange(strClass, false);
        //}
        //public void InstanceCountChanged(String strClass)
        //{
        //    CoreCal c = GetClassByName(strClass);
        //    if (c == null)
        //        return;

        //    //c.instance_data_changed = System.DateTime.Now;
        //    //c.instance_count_changed = System.DateTime.Now;

        //    //NotifyClassChange(strClass, true);
        //}
        //public void NotifyClassChange(String strClass, bool adds)
        //{

        //    if (ClassChanges == null)
        //        return;

        //    try
        //    {
        //        nChange c = (nChange)ClassChanges[strClass];
        //        if (c == null)
        //            return;

        //        c.LastRequestTicks = System.DateTime.Now.Ticks;
        //    }
        //    catch
        //    { }
        //}
        //public nChange GetClassChange(String strClass)
        //{
        //    nChange c;

        //    if (ClassChanges == null)
        //    {
        //        ClassChanges = new Hashtable();
        //    }

        //    c = (nChange)ClassChanges[strClass];

        //    if (c != null)
        //        return c;

        //    try
        //    {
        //        c = new nChange();
        //        c.ClassName = strClass;
        //        ClassChanges.Add(strClass, c);
        //        return c;
        //    }
        //    catch
        //    {
        //    }

        //    return null;
        //}
        //public void RegisterNotifyClass(IChangeSubscriber x, String strClass)
        //{
        //    //start the timer if it isn't started already
        //    if (NotifyTimer == null)
        //    {
        //        NotifyTimer = new Timer();
        //        NotifyTimer.Interval = 1000;
        //        NotifyTimer.Tick += new EventHandler(NotifyTimer_Tick);
        //        NotifyTimer.Start();
        //    }

        //    nChange c = GetClassChange(strClass);
        //    c.AddSubscriber(x);
        //}
        //public void UnRegisterNotifyClass(IChangeSubscriber x)
        //{
        //    if (ClassChanges == null)
        //        return;

        //    nChange c;
        //    foreach (DictionaryEntry d in ClassChanges)
        //    {
        //        c = (nChange)d.Value;
        //        c.RemoveSubscriber(x);
        //    }
        //}
        //public void RegisterNotifySchema(IChangeSubscriber x)
        //{
        //    if (SchemaChange == null)
        //    {
        //        SchemaChange = new nChange();
        //        SchemaChange.ClassName = "<schema>";
        //    }

        //    SchemaChange.AddSubscriber(x);
        //}
        //public void UnRegisterNotifySchema(IChangeSubscriber x)
        //{
        //    if (SchemaChange == null)
        //        return;

        //    SchemaChange.RemoveSubscriber(x);
        //}
        //public void NotifySchemaChange()
        //{
        //    if (SchemaChange == null)
        //        return;

        //    SchemaChange.NotifySubscribers();
        //}
        public bool InitRecall(ContextNM context, DataKeySql key, String machineName)
        {
            RecallConnection = new DataConnectionSqlServer(key.ServerName, key.DatabaseName, key.UserName, key.UserPassword);
            RecallMachineName = machineName;
            if (RecallConnection.ConnectPossible())
            {
                if (context.TheData.TheConnection.IsDefinitelySameTable("n_team", RecallConnection))
                {
                    context.TheLeader.Error("The recall connection appears to be the same as the main database connection; disabling Recall");
                    return false;
                }
                else
                {
                    Recall = true;                 
                    RecallWarnings = true;
                    return true;
                }
            }
            return false;
        }
        ////Private Functions
        //private void NotifyTimer_Tick(object sender, EventArgs e)
        //{
        //    if (ClassChanges == null)
        //        return;
        //    NotifyTimer.Stop();

        //    try
        //    {
        //        //check each change to see if it has been long enough
        //        foreach (DictionaryEntry d in ClassChanges)
        //        {
        //            nChange c = (nChange)d.Value;
        //            if (c.LastRequestTicks > 0)
        //            {
        //                if ((System.DateTime.Now.Ticks - c.LastRequestTicks) >= 1500)
        //                {
        //                    c.LastRequestTicks = 0;
        //                    c.NotifySubscribers();
        //                    c.LastRequestTicks = 0;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    { }

        //    NotifyTimer.Start();
        //}

        //public virtual string GetChangeHistory(ContextNM x, Core.ItemTag o, ref DataTable changes, List<String> show_props = null)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    nObject xObject = (nObject)x.QtO(o.ClassId, "select * from " + o.ClassId + " where unique_id = '" + o.Uid + "'");
        //    if (xObject == null)
        //    {
        //        sb.AppendLine("No historical information could be found for this item.");
        //        sb.AppendLine("<br><font size=\"1\">-end-<br>");
        //        return sb.ToString();
        //    }
        //    changes = x.xSys.RecallConnection.Select("select * from " + o.ClassId + " where unique_id = '" + o.Uid + "' order by recall_date desc");
        //    sb.AppendLine(xObject.GetClipHeader(x) + "<br>");
        //    if (!nTools.DataTableExists(changes))
        //    {
        //        sb.AppendLine("No historical information could be found for this item.");
        //        sb.AppendLine("<br><font size=\"1\">-end-<br>");
        //        return sb.ToString();
        //    }
        //    else
        //    {
        //        DataRow lastRow = null;
        //        foreach (DataRow row in changes.Rows)
        //        {
        //            if (!Tools.Strings.StrExt(Tools.Data.NullFilterString(row["recall_action_id"])))
        //            {
        //                lastRow = row;
        //                break;
        //            }
        //        }
        //        if (lastRow == null)
        //        {
        //            sb.AppendLine("No data changes could be found for this item.");
        //            sb.AppendLine("<br><font size=\"1\">-end-<br>");
        //            return sb.ToString();
        //        }
        //        int change_count = 0;
        //        int action_count = 0;
        //        Stack all_rows = new Stack();
        //        foreach (DataRow row in changes.Rows)
        //        {
        //            if (Tools.Strings.StrExt(Tools.Data.NullFilterString(row["recall_action_id"])))
        //                action_count += 1;
        //            else
        //                change_count += 1;
        //            all_rows.Push(row);
        //        }
        //        sb.AppendLine("<table border=\"0\" cellspacing=\"0\" cellpadding=\"4\">");
        //        sb.AppendLine("  <tr>");
        //        sb.AppendLine("    <td>Change Count:</td>");
        //        sb.AppendLine("    <td align=\"right\">" + Tools.Number.LongFormat(change_count) + "</td>");
        //        sb.AppendLine("  </tr>");
        //        sb.AppendLine("  <tr>");
        //        sb.AppendLine("    <td>Action&nbsp; Count:</td>");
        //        sb.AppendLine("    <td align=\"right\">" + Tools.Number.LongFormat(action_count) + "</td>");
        //        sb.AppendLine("  </tr>");
        //        sb.AppendLine("</table>");
        //        sb.AppendLine("<br><br>");
        //        Stack all_writes = new Stack();
        //        bool first = true;
        //        nObject last = (nObject)x.Item(o.ClassId);
        //        DataRow r = null;
        //        while (all_rows.Count > 0)
        //        {
        //            r = (DataRow)all_rows.Pop();
        //            String actionId = Tools.Data.NullFilterString(r["recall_action_id"]);
        //            String userName = Tools.Data.NullFilterString(r["recall_user_name"]);
        //            DateTime actionDate = Tools.Data.NullFilterDate(r["recall_date"]);
        //            if (first)//Should be the creation record so write the whole object?
        //            {
        //                last.AbsorbRow(x, r);
        //                all_writes.Push(WriteObject(x, last, null, (Int32)nData.NullFilter(r["recall_type"], FieldType.Int32), (DateTime)nData.NullFilter(r["recall_date"], FieldType.DateTime), (String)nData.NullFilter(r["recall_user_name"], FieldType.String), show_props));
        //                first = false;
        //            }
        //            else
        //            {
        //                if (Tools.Strings.StrExt(actionId))
        //                    all_writes.Push("<br><font color=\"red\">Action: " + actionId + " by " + userName + " on " + actionDate.ToString() + "</font><br><br>");
        //                else
        //                {
        //                    nObject current = (nObject)x.Item(o.ClassId);
        //                    current.AbsorbRow(x, r);
        //                    all_writes.Push(WriteObject(x, current, last, (Int32)nData.NullFilter(r["recall_type"], FieldType.Int32), (DateTime)nData.NullFilter(r["recall_date"], FieldType.DateTime), (String)nData.NullFilter(r["recall_user_name"], FieldType.String), show_props));
        //                    last = current;
        //                }
        //            }
        //        }
        //        all_writes.Push("Current Values:<br>" + WriteWholeObject(x, (nObject)o.FirstGet(x), Tools.Dates.GetNullDate(), "", -1, show_props));
        //        while (all_writes.Count > 0)
        //        {
        //            sb.AppendLine(all_writes.Pop().ToString());
        //        }
        //    }
        //    sb.AppendLine("<br><font size=\"1\">-end-<br>");
        //    return sb.ToString();
        //}
        //private String WriteObject(ContextNM x, nObject o, nObject l, int t, DateTime d, String u, List<String> show_props = null)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    if (l == null) //write the whole thing
        //        sb.AppendLine(WriteWholeObject(x, o, d, u, t, show_props));
        //    else    //write the differences
        //        sb.AppendLine(WriteChanges(x, o, l, d, u, t, show_props));
        //    return sb.ToString();
        //}
        //private String WriteChanges(ContextNM x, nObject o, nObject l, DateTime d, String u, int t, List<String> show_props = null)
        //{
        //    bool limit_props = false;
        //    if (show_props != null && show_props.Count > 0)
        //        limit_props = true;
        //    StringBuilder sb = new StringBuilder();
        //    List<String> changes = new List<String>();
        //    int c = 1;
        //    bool is_modified = false;
        //    int var_count = 0;
        //    List<VarVal> list = o.VarValsGet();
        //    SortList(ref list);
        //    foreach (VarVal p in list)
        //    {
        //        if (IsIDProp(x, p.TheValAttribute))
        //            continue;
        //        if (IsIgnoreProp(x, p.TheValAttribute))
        //            continue;
        //        if (limit_props && !show_props.Contains(p.Name))
        //            continue;
        //        if (c > 2)
        //        {
        //            c = 1;
        //            changes.Add("</tr>");
        //            changes.Add("<tr>");
        //        }
        //        Object v;
        //        String sl;
        //        String so;
        //        v = o.IGet(p.Name);
        //        if (v == null)
        //            so = "";
        //        else
        //            so = v.ToString();
        //        v = l.IGet(p.Name);
        //        if (v == null)
        //            sl = "";
        //        else
        //            sl = v.ToString();
        //        if (so != sl)
        //        {
        //            var_count += 1;
        //            if (Tools.Strings.StrCmp(p.Name, "date_modified"))
        //            {
        //                is_modified = true;
        //                break;
        //            }
        //            so = Tools.Strings.Left(so, 255);
        //            sl = Tools.Strings.Left(sl, 255);
        //            changes.Add("<td><font size=\"1\" color=\"#0000FF\">" + p.TheValAttribute.Caption + "</font></td>");
        //            changes.Add("<td><font size=\"1\" color=\"red\">" + sl + "</font></td>");
        //            changes.Add("<td><font size=\"1\" color=\"#008000\">" + so + "</font></td>");
        //            if (c == 1)
        //                changes.Add("<td width=\"50\"></td>");
        //            c++;
        //        }
        //    }
        //    if (is_modified && var_count <= 1)
        //    {
        //        changes = new List<string>();
        //        changes.Add("<td><font color=\"grey\">Viewed By: " + u + " on " + d.ToString() + "</font></td>");
        //    }
        //    if (changes.Count > 0)
        //    {
        //        switch (t)
        //        {
        //            case (Int32)Enums.RecallType.Delete:
        //                sb.AppendLine("Deleted by " + u + " on " + d.ToString() + "<br>");
        //                return sb.ToString();
        //            case (Int32)Enums.RecallType.Insert:
        //                sb.AppendLine("Created by " + u + " on " + d.ToString() + "<br>");//don't return, so it will show the original state                    
        //                break;
        //            default:
        //                if (!is_modified)
        //                    sb.AppendLine("Modified by " + u + " on " + d.ToString() + "<br>");
        //                break;
        //        }
        //        sb.AppendLine("<table border=\"1\" bordercolor=\"#CCCCCC\">");
        //        sb.AppendLine("  <tr>");
        //        foreach (string s in changes)
        //        {
        //            sb.AppendLine(s);
        //        }
        //        sb.AppendLine("</tr></table><br>");
        //    }
        //    return sb.ToString();
        //}
        //private String WriteWholeObject(ContextNM x, nObject o, DateTime d, String u, int t, List<String> show_props = null)
        //{
        //    bool limit_props = false;
        //    if (show_props != null && show_props.Count > 0)
        //        limit_props = true;
        //    StringBuilder sb = new StringBuilder();
        //    List<CoreVarValAttribute> s = x.TheSys.CoreClassGet(o.ClassId).VarValsGet();
        //    if (s == null)
        //    {
        //        sb.AppendLine("No properties could be found for this kind of information (" + o.ClassId + ")");
        //        return sb.ToString();
        //    }
        //    if (t != -1)
        //    {
        //        switch (t)
        //        {
        //            case (Int32)Enums.RecallType.Delete:
        //                sb.AppendLine("Deleted by " + u + " on " + d.ToString() + "<br>");
        //                return sb.ToString();
        //            case (Int32)Enums.RecallType.Insert:
        //                sb.AppendLine("Created by " + u + " on " + d.ToString() + "<br>");//don't return, so it will show the original state                    
        //                break;
        //            default:
        //                sb.AppendLine("Modified by " + u + " on " + d.ToString() + "<br>");
        //                break;
        //        }
        //    }
        //    sb.AppendLine("<table border=\"1\" bordercolor=\"#CCCCCC\">");
        //    sb.AppendLine("  <tr>");
        //    int c = 1;
        //    SortList(ref s);
        //    foreach (CoreVarValAttribute p in s)
        //    {
        //        if (IsIDProp(x, p))
        //            continue;
        //        if (IsIgnoreProp(x, p))
        //            continue;
        //        if (limit_props && !show_props.Contains(p.Name))
        //            continue;
        //        if (c > 4)
        //        {
        //            c = 1;
        //            sb.AppendLine("</tr>");
        //            sb.AppendLine("<tr>");
        //        }
        //        //caption
        //        sb.AppendLine("<td><font size=\"1\" color=\"#0000FF\">" + p.Caption + "</font></td>");
        //        //value
        //        Object v = o.IGet(p.Name);
        //        String st;
        //        if (v == null)
        //            st = "";
        //        else
        //            st = Tools.Strings.Left(v.ToString(), 255);
        //        sb.AppendLine("<td><font size=\"1\">" + st + "</font></td>");
        //        c++;
        //    }
        //    sb.AppendLine("</tr></table><br>");
        //    return sb.ToString();
        //}
        public virtual ChangeHistoryInfo GetChangeHistory(ContextNM x, Core.ItemTag o, ref DataTable changes, List<String> show_props = null)
        {
            ChangeHistoryInfo ch = new ChangeHistoryInfo();
            string changeHistorySQL = "select * from " + o.ClassId + " where unique_id = '" + o.Uid + "'";
            nObject xObject = (nObject)x.QtO(o.ClassId, changeHistorySQL);
            if (xObject == null)
            {
                ch.TheHTML.AppendLine("No historical information could be found for this item.");
                ch.TheHTML.AppendLine("<br><font size=\"1\">-end-<br>");
                return ch;
            }
            changes = x.xSys.RecallConnection.Select("select * from " + o.ClassId + " where unique_id = '" + o.Uid + "' order by recall_date desc");
            ch.TheHTML.AppendLine(xObject.GetClipHeader(x) + "<br>");
            if (!nTools.DataTableExists(changes))
            {
                ch.TheHTML.AppendLine("No historical information could be found for this item.");
                ch.TheHTML.AppendLine("<br><font size=\"1\">-end-<br>");
                return ch;
            }
            else
            {
                DataRow lastRow = null;
                foreach (DataRow row in changes.Rows)
                {
                    if (!Tools.Strings.StrExt(Tools.Data.NullFilterString(row["recall_action_id"])))
                    {
                        lastRow = row;
                        break;
                    }
                }
                if (lastRow == null)
                {
                    ch.TheHTML.AppendLine("No data changes could be found for this item.");
                    ch.TheHTML.AppendLine("<br><font size=\"1\">-end-<br>");
                    return ch;
                }
                Stack all_rows = new Stack();
                foreach (DataRow row in changes.Rows)
                {
                    all_rows.Push(row);
                }
                Stack all_writes = new Stack();
                bool first = true;
                nObject last = (nObject)x.Item(o.ClassId);
                DataRow r = null;
                int count_a = 0;
                int count_c = 0;
                while (all_rows.Count > 0)
                {
                    r = (DataRow)all_rows.Pop();
                    String actionId = Tools.Data.NullFilterString(r["recall_action_id"]);
                    String userName = Tools.Data.NullFilterString(r["recall_user_name"]);
                    DateTime actionDate = Tools.Data.NullFilterDate(r["recall_date"]);
                    if (first)//Should be the creation record so write the whole object?
                    {
                        last.AbsorbRow(x, r);
                        all_writes.Push(WriteObject(x, last, null, (Int32)nData.NullFilter(r["recall_type"], FieldType.Int32), (DateTime)nData.NullFilter(r["recall_date"], FieldType.DateTime), (String)nData.NullFilter(r["recall_user_name"], FieldType.String), ref ch, show_props));
                        first = false;
                    }
                    else
                    {
                        if (Tools.Strings.StrExt(actionId))
                        {
                            all_writes.Push("<font color=\"red\">Action: " + HttpUtility.HtmlEncode(actionId) + " by " + HttpUtility.HtmlEncode(userName) + " on " + HttpUtility.HtmlEncode(actionDate.ToString()) + "</font><br><br>");
                            count_a += 1;
                        }
                        else
                        {
                            nObject current = (nObject)x.Item(o.ClassId);
                            current.AbsorbRow(x, r);
                            string html = WriteObject(x, current, last, (Int32)nData.NullFilter(r["recall_type"], FieldType.Int32), (DateTime)nData.NullFilter(r["recall_date"], FieldType.DateTime), (String)nData.NullFilter(r["recall_user_name"], FieldType.String), ref ch, show_props);
                            if (Tools.Strings.StrExt(html))
                            {
                                all_writes.Push(html);
                                if (!html.ToLower().Contains("viewed by:"))
                                    count_c += 1;
                            }
                            last = current;
                        }
                    }
                }
                ch.TheHTML.AppendLine("<table border=\"0\" cellspacing=\"0\" cellpadding=\"4\">");
                ch.TheHTML.AppendLine("  <tr>");
                ch.TheHTML.AppendLine("    <td>Change Count:</td>");
                ch.TheHTML.AppendLine("    <td align=\"right\">" + Tools.Number.LongFormat(count_c) + "</td>");
                ch.TheHTML.AppendLine("  </tr>");
                ch.TheHTML.AppendLine("  <tr>");
                ch.TheHTML.AppendLine("    <td>Action Count:</td>");
                ch.TheHTML.AppendLine("    <td align=\"right\">" + Tools.Number.LongFormat(count_a) + "</td>");
                ch.TheHTML.AppendLine("  </tr>");
                ch.TheHTML.AppendLine("</table>");
                ch.TheHTML.AppendLine("<br><br>");
                all_writes.Push("Current Values:<br>" + WriteWholeObject(x, (nObject)o.FirstGet(x), Tools.Dates.GetNullDate(), "", -1, ref ch, show_props));
                while (all_writes.Count > 0)
                {
                    ch.TheHTML.AppendLine(all_writes.Pop().ToString());
                }
            }
            ch.TheHTML.AppendLine("<br><font size=\"1\">-end-<br>");
            return ch;
        }
        private String WriteObject(ContextNM x, nObject o, nObject l, int t, DateTime d, String u, ref ChangeHistoryInfo ch, List<String> show_props = null)
        {
            StringBuilder sb = new StringBuilder();
            if (l == null) //write the whole thing
                sb.AppendLine(WriteWholeObject(x, o, d, u, t, ref ch, show_props));
            else    //write the differences
                sb.AppendLine(WriteChanges(x, o, l, d, u, t, ref ch, show_props));
            return sb.ToString();
        }
        //private String WriteChanges(ContextNM x, nObject o, nObject l, DateTime d, String u, int t, ref ChangeHistoryInfo ch, List<String> show_props = null)
        //{
        //    bool limit_props = false;
        //    if (show_props != null && show_props.Count > 0)
        //        limit_props = true;
        //    StringBuilder sb = new StringBuilder();
        //    List<String> changes = new List<String>();
        //    int c = 1;
        //    bool is_modified = false;
        //    int var_count = 0;
        //    List<VarVal> list = o.VarValsGet();
        //    SortList(ref list);
        //    foreach (VarVal p in list)
        //    {
        //        if (IsIDProp(x, p.TheValAttribute))
        //            continue;
        //        if (IsIgnoreProp(x, p.TheValAttribute))
        //            continue;
        //        if (limit_props && !show_props.Contains(p.Name))
        //            continue;
        //        if (c > 2)
        //        {
        //            c = 1;
        //            changes.Add("</tr>");
        //            changes.Add("<tr>");
        //        }
        //        Object v;
        //        String sl;
        //        String so;
        //        v = o.IGet(p.Name);
        //        if (v == null)
        //            so = "";
        //        else
        //            so = v.ToString();
        //        v = l.IGet(p.Name);
        //        if (v == null)
        //            sl = "";
        //        else
        //            sl = v.ToString();
        //        if (so != sl)
        //        {
        //            var_count += 1;
        //            if (Tools.Strings.StrCmp(p.Name, "date_modified"))
        //            {
        //                is_modified = true;
        //                continue;
        //            }
        //            so = Tools.Strings.Left(so, 255);
        //            sl = Tools.Strings.Left(sl, 255);
        //            if (p.FieldType == FieldType.DateTime)
        //            {
        //                if (so.StartsWith(Tools.Dates.GetNullDate().ToShortDateString()))
        //                    so = "";
        //                if (sl.StartsWith(Tools.Dates.GetNullDate().ToShortDateString()))
        //                    sl = "";
        //                if (Tools.Strings.StrCmp(so, sl))
        //                {
        //                    var_count -= 1;
        //                    continue;
        //                }
        //            }
        //            else if (p.FieldType == FieldType.Boolean)
        //            {
        //                if (Tools.Strings.StrCmp(so, "true"))
        //                    so = "Y";
        //                else if (Tools.Strings.StrCmp(so, "false"))
        //                    so = "N";
        //                if (Tools.Strings.StrCmp(sl, "true"))
        //                    sl = "Y";
        //                else if (Tools.Strings.StrCmp(sl, "false"))
        //                    sl = "N";
        //            }
        //            changes.Add("<td><font size=\"1\" color=\"#0000FF\">" + HttpUtility.HtmlEncode(p.TheValAttribute.Caption) + "</font></td>");
        //            string hold = sl;
        //            if (!Tools.Strings.StrExt(hold))
        //                sl = "<font size=\"1\" color=\"grey\">(Blank)</font>";
        //            else
        //                sl = "<font size=\"1\" color=\"red\">" + HttpUtility.HtmlEncode(hold) + "</font>";
        //            hold = so;
        //            if (!Tools.Strings.StrExt(hold))
        //                so = "<font size=\"1\" color=\"grey\">(Blank)</font>";
        //            else
        //                so = "<font size=\"1\" color=\"#008000\">" + HttpUtility.HtmlEncode(hold) + "</font>";
        //            changes.Add("<td>" + sl + "</td>");
        //            changes.Add("<td>" + so + "</td>");
        //            if (!ch.TheProps.Contains(p.TheValAttribute))
        //                ch.TheProps.Add(p.TheValAttribute);
        //            c++;
        //        }
        //    }
        //    bool is_modified_only = false;
        //    if (is_modified && var_count <= 1)
        //    {
        //        changes = new List<string>();
        //        changes.Add("<td><font color=\"grey\">Viewed By: " + HttpUtility.HtmlEncode(u) + " on " + HttpUtility.HtmlEncode(d.ToString()) + "</font></td>");
        //        is_modified_only = true;
        //    }
        //    if (changes.Count > 0)
        //    {
        //        switch (t)
        //        {
        //            case (Int32)Enums.RecallType.Delete:
        //                sb.AppendLine("Deleted by " + HttpUtility.HtmlEncode(u) + " on " + HttpUtility.HtmlEncode(d.ToString()) + "<br>");
        //                return sb.ToString();
        //            case (Int32)Enums.RecallType.Insert:
        //                sb.AppendLine("Created by " + HttpUtility.HtmlEncode(u) + " on " +HttpUtility.HtmlEncode(d.ToString()) + "<br>");//don't return, so it will show the original state                    
        //                break;
        //            default:
        //                if (!is_modified_only)
        //                    sb.AppendLine("Modified by " + HttpUtility.HtmlEncode(u) + " on " + HttpUtility.HtmlEncode(d.ToString()) + "<br>");
        //                break;
        //        }
        //        sb.AppendLine("<table border=\"1\" bordercolor=\"#CCCCCC\">");
        //        sb.AppendLine("  <tr>");
        //        foreach (string s in changes)
        //        {
        //            sb.AppendLine(s);
        //        }
        //        sb.AppendLine("</tr></table><br>");
        //    }
        //    return sb.ToString();
        //}
        private String WriteChanges(ContextNM x, nObject o, nObject l, DateTime d, String u, int t, ref ChangeHistoryInfo ch, List<String> show_props = null)
        {
            bool limit_props = false;
            if (show_props != null && show_props.Count > 0)
                limit_props = true;
            StringBuilder sb = new StringBuilder();
            List<String> changes = new List<String>();
            int c = 1;
            bool is_modified = false;
            int var_count = 0;
            List<VarVal> list = o.VarValsGet();
            SortList(ref list);
            foreach (VarVal p in list)
            {
                if (IsIDProp(x, p.TheValAttribute))
                    continue;
                if (IsIgnoreProp(x, p.TheValAttribute))
                    continue;
                Object v;
                String sl;
                String so;
                v = o.IGet(p.Name);
                if (v == null)
                    so = "";
                else
                    so = v.ToString();
                v = l.IGet(p.Name);
                if (v == null)
                    sl = "";
                else
                    sl = v.ToString();
                if (so != sl)
                {
                    var_count += 1;
                    if (Tools.Strings.StrCmp(p.Name, "date_modified"))
                    {
                        is_modified = true;
                        continue;
                    }
                    so = Tools.Strings.Left(so, 255);
                    sl = Tools.Strings.Left(sl, 255);
                    if (p.FieldType == FieldType.DateTime)
                    {
                        if (so.StartsWith(Tools.Dates.GetNullDate().ToShortDateString()))
                            so = "";
                        if (sl.StartsWith(Tools.Dates.GetNullDate().ToShortDateString()))
                            sl = "";
                        if (Tools.Strings.StrCmp(so, sl))
                        {
                            var_count -= 1;
                            continue;
                        }
                    }
                    else if (p.FieldType == FieldType.Boolean)
                    {
                        if (Tools.Strings.StrCmp(so, "true"))
                            so = "Y";
                        else if (Tools.Strings.StrCmp(so, "false"))
                            so = "N";
                        if (Tools.Strings.StrCmp(sl, "true"))
                            sl = "Y";
                        else if (Tools.Strings.StrCmp(sl, "false"))
                            sl = "N";
                    }
                    if (!ch.TheProps.Contains(p.TheValAttribute))
                        ch.TheProps.Add(p.TheValAttribute);
                    if (limit_props && !show_props.Contains(p.Name))
                        continue;
                    if (c > 2)
                    {
                        c = 1;
                        changes.Add("</tr>");
                        changes.Add("<tr>");
                    }
                    changes.Add("<td><font size=\"1\" color=\"#0000FF\">" + HttpUtility.HtmlEncode(p.TheValAttribute.Caption) + "</font></td>");
                    string hold = sl;
                    if (!Tools.Strings.StrExt(hold))
                        sl = "<font size=\"1\" color=\"grey\">(Blank)</font>";
                    else
                        sl = "<font size=\"1\" color=\"red\">" + HttpUtility.HtmlEncode(hold) + "</font>";
                    hold = so;
                    if (!Tools.Strings.StrExt(hold))
                        so = "<font size=\"1\" color=\"grey\">(Blank)</font>";
                    else
                        so = "<font size=\"1\" color=\"#008000\">" + HttpUtility.HtmlEncode(hold) + "</font>";
                    changes.Add("<td>" + sl + "</td>");
                    changes.Add("<td>" + so + "</td>");
                    c++;
                }
            }
            bool is_modified_only = false;
            if (is_modified && var_count <= 1)
            {
                changes = new List<string>();
                changes.Add("<td><font color=\"grey\">Viewed By: " + HttpUtility.HtmlEncode(u) + " on " + HttpUtility.HtmlEncode(d.ToString()) + "</font></td>");
                is_modified_only = true;
            }
            if (changes.Count > 0)
            {
                switch (t)
                {
                    case (Int32)Enums.RecallType.Delete:
                        sb.AppendLine("Deleted by " + HttpUtility.HtmlEncode(u) + " on " + HttpUtility.HtmlEncode(d.ToString()) + "<br>");
                        return sb.ToString();
                    case (Int32)Enums.RecallType.Insert:
                        sb.AppendLine("Created by " + HttpUtility.HtmlEncode(u) + " on " + HttpUtility.HtmlEncode(d.ToString()) + "<br>");//don't return, so it will show the original state                    
                        break;
                    default:
                        if (!is_modified_only)
                            sb.AppendLine("Modified by " + HttpUtility.HtmlEncode(u) + " on " + HttpUtility.HtmlEncode(d.ToString()) + "<br>");
                        break;
                }
                sb.AppendLine("<table border=\"1\" bordercolor=\"#CCCCCC\">");
                sb.AppendLine("  <tr>");
                foreach (string s in changes)
                {
                    sb.AppendLine(s);
                }
                sb.AppendLine("</tr></table><br>");
            }
            return sb.ToString();
        }
        private String WriteWholeObject(ContextNM x, nObject o, DateTime d, String u, int t, ref ChangeHistoryInfo ch, List<String> show_props = null)
        {
            bool limit_props = false;
            if (show_props != null && show_props.Count > 0)
                limit_props = true;
            StringBuilder sb = new StringBuilder();
            List<CoreVarValAttribute> s = x.TheSys.CoreClassGet(o.ClassId).VarValsGet();
            if (s == null)
            {
                sb.AppendLine("No properties could be found for this kind of information (" + o.ClassId + ")");
                return sb.ToString();
            }
            if (t != -1)
            {
                switch (t)
                {
                    case (Int32)Enums.RecallType.Delete:
                        sb.AppendLine("Deleted by " + HttpUtility.HtmlEncode(u) + " on " + HttpUtility.HtmlEncode(d.ToString()) + "<br>");
                        return sb.ToString();
                    case (Int32)Enums.RecallType.Insert:
                        sb.AppendLine("Created by " + HttpUtility.HtmlEncode(u)  + " on " + HttpUtility.HtmlEncode(d.ToString()) + "<br>");//don't return, so it will show the original state                    
                        break;
                    default:
                        sb.AppendLine("Modified by " + HttpUtility.HtmlEncode(u) + " on " + HttpUtility.HtmlEncode(d.ToString()) + "<br>");
                        break;
                }
            }
            sb.AppendLine("<table border=\"1\" bordercolor=\"#CCCCCC\">");
            sb.AppendLine("  <tr>");
            int c = 1;
            SortList(ref s);
            foreach (CoreVarValAttribute p in s)
            {
                if (IsIDProp(x, p))
                    continue;
                if (IsIgnoreProp(x, p))
                    continue;
                if (limit_props && !show_props.Contains(p.Name))
                    continue;
                if (c > 4)
                {
                    c = 1;
                    sb.AppendLine("</tr>");
                    sb.AppendLine("<tr>");
                }
                //caption
                sb.AppendLine("<td><font size=\"1\" color=\"#0000FF\">" + HttpUtility.HtmlEncode(p.Caption) + "</font></td>");
                //value
                Object v = o.IGet(p.Name);
                String st;
                String hold = "";
                if (v == null)
                    st = "";
                else
                    st = Tools.Strings.Left(v.ToString(), 255);
                if (p.TheFieldType == FieldType.DateTime)
                {
                    if (st.StartsWith(Tools.Dates.GetNullDate().ToShortDateString()))
                        st = "(Blank)";
                }
                else if (p.TheFieldType == FieldType.Boolean)
                {
                    if (Tools.Strings.StrCmp(st, "true"))
                        st = "Y";
                    else if (Tools.Strings.StrCmp(st, "false"))
                        st = "N";
                }
                if (!Tools.Strings.StrExt(st))
                    st = "(Blank)";
                if (Tools.Strings.StrCmp(st, "(Blank)"))
                    hold = "<font size=\"1\" color=\"grey\">" + st + "</font>";
                else
                    hold = "<font size=\"1\">" + HttpUtility.HtmlEncode(st) + "</font>";
                sb.AppendLine("<td>" + hold + "</td>");
                c++;
            }
            sb.AppendLine("</tr></table><br>");
            return sb.ToString();
        }
        public bool IsIDProp(ContextNM x, CoreVarValAttribute p)
        {
            if (x.xUser.IsDeveloper())
                return false;
            string prop = p.Name.ToLower().Trim();
            if (Tools.Strings.StrCmp(prop, "importid"))
                return false;
            if (prop.EndsWith("_uid"))
                return true;
            if (prop.EndsWith("_id"))
                return true;
            if (prop.StartsWith("orderid_"))
                return true;
            if (prop.StartsWith("qcid_"))
                return true;
            if (prop.Contains("legacyid"))
                return true;
            if (prop.Contains("userid"))
                return true;
            switch (prop)
            {
                case "unique_id":
                case "companyid":
                case "linkid":
                case "vendorid":
                    return true;
            }
            return false;
        }
        public bool IsIgnoreProp(ContextNM x, CoreVarValAttribute p)
        {
            string prop = p.Name.ToLower().Trim();
            switch (prop)
            {
                case "date_created":
                case "datecreated":
                //case "date_modified":
                case "datemodified":
                    return true;
            }
            if (x.xUser.IsDeveloper())
                return false;
            if (prop.StartsWith("stripped") || prop.EndsWith("stripped"))
                return true;
            if (prop.StartsWith("distilled") || prop.EndsWith("distilled"))
                return true;
            switch (prop)
            {
                case "grid_color":
                case "icon_index":
                case "modifiedby":
                    return true;
            }
            return false;
        }
        public void SortList(ref List<CoreVarValAttribute> s)
        {
            SortedList sl = new SortedList();
            List<CoreVarValAttribute> l = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute v in s)
            {
                sl.Add(v.Name, v);
            }
            foreach (DictionaryEntry d in sl)
            {
                l.Add((CoreVarValAttribute)d.Value);
            }
            s = l;
        }
        public void SortList(ref List<VarVal> s)
        {
            SortedList sl = new SortedList();
            List<VarVal> l = new List<VarVal>();
            foreach (VarVal v in s)
            {
                sl.Add(v.Name, v);
            }
            foreach (DictionaryEntry d in sl)
            {
                l.Add((VarVal)d.Value);
            }
            s = l;
        }
    }
    public class ChangeHistoryInfo
    {
        public List<CoreVarValAttribute> TheProps = new List<CoreVarValAttribute>();
        public StringBuilder TheHTML = new StringBuilder();
    }
    public class SystemLoadArgs
    {
        public String Name = "";
        public String Alias = "";
        public bool recall = false;
        public bool auto_load_subsystems = false;
        public n_data_target recall_target;
        public bool SkipDataConnection = false;
        //public n_sys xSys;
        public SysNewMethod SystemObject;

        public SystemLoadArgs()
        {

        }
        public SystemLoadArgs(String strName)
        {
            Name = strName;
        }
        public SystemLoadArgs(String strName, String strAlias)
        {
            Name = strName;
            Alias = strAlias;
        }
        public SystemLoadArgs(String strName, String strAlias, SysNewMethod xs)
        {
            Name = strName;
            Alias = strAlias;
            SystemObject = xs;
        }
        public SystemLoadArgs(String strName, String strAlias, SysNewMethod xs, n_data_target t)
        {
            Name = strName;
            Alias = strAlias;
            SystemObject = xs;
            recall = true;
            recall_target = t;
        }
    }
}