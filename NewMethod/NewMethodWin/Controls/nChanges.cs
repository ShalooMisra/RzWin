using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Core;
using Tools.Database;

namespace NewMethod
{
    public partial class nChanges : UserControl
    {
        //Public Delegates
        public delegate void DisplayChangeFileDelegate(String strFile);
        //Public Variables
        public Core.ItemTag CurrentObject;
        public String Caption = "";
        //Private Variables
        private DataTable recall_table;

        //Constructors
        public nChanges()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(nObject xObject)
        {
            CompleteLoad(new Core.ItemTag(xObject), xObject.GetClipHeader(NMWin.ContextDefault));
        }
        public void CompleteLoad(Core.ItemTag tag, String caption)
        {
            Caption = caption;
            DoResize();
            sp.SplitterDistance = Convert.ToInt32(Convert.ToDouble(sp.Height) * 0.9);
            wb.Clear();
            CurrentObject = tag;
            if (CurrentObject == null)
                return;
            if (!NMWin.ContextDefault.xSys.Recall)
            {
                wb.Add("This item is not configured for historical change tracking.");
                return;
            }
            wb.Add(caption);
            wb.Add("Retreiving the change history for " + caption);
            Thread t = new Thread(new ThreadStart(ShowChanges));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        public void ShowChanges()
        {
            if( CurrentObject == null )
                return;
            ChangeHistoryInfo ch = NMWin.ContextDefault.xSys.GetChangeHistory(NMWin.ContextDefault, CurrentObject, ref recall_table);
            string changes = ch.TheHTML.ToString();
            String strFileName = Tools.OperatingSystem.GetTempFileName(".htm");
            System.IO.StreamWriter file = new System.IO.StreamWriter(strFileName, false);
            file.WriteLine(changes);
            file.Close();
            InvokeDisplay(strFileName);
        }
        void InvokeDisplay(String strFileName)
        {
            //invoke the display
            if (this.InvokeRequired)
            {
                DisplayChangeFileDelegate del = new DisplayChangeFileDelegate(DisplayChangeFile);
                this.Invoke(del, new object[] { strFileName });
            }
            else
            {
                DisplayChangeFile(strFileName);
            }
        }
        //Private Functions
        private void DoResize()
        {
            try
            {
                sp.Left = 0;
                sp.Top = 0;
                sp.Width = Convert.ToInt32(Convert.ToDouble(this.ClientRectangle.Width) * 0.8);
                sp.Height = this.ClientRectangle.Height;

                lv.Left = sp.Right;
                lv.Top = 0;
                lv.Height = this.ClientRectangle.Height;
                lv.Width = this.ClientRectangle.Width - sp.Width;
            }
            catch { }
        }
        private void DisplayChangeFile(String strFile)
        {
            wb.Clear();
            wb.Navigate("file:///" + strFile);

            lv.Items.Clear();
            foreach (DataRow row in recall_table.Rows)
            {

                ListViewItem i = lv.Items.Add(nTools.DateFormat_ShortDateTime(nData.NullFilter_Date(row["recall_date"])));
                i.SubItems.Add(nData.NullFilter_String(row["recall_user_name"]));
                i.SubItems.Add(nData.NullFilter_String(row["recall_machine_name"]));
                i.SubItems.Add(nData.NullFilter_String(row["recall_version"]));
                i.Tag = nData.NullFilter_String(row["recall_uid"]);

                switch (Tools.Data.NullFilterInt(row["recall_type"]))
                {
                    case 1:
                        i.ForeColor = Color.Green;
                        break;
                    case 2:
                        i.ForeColor = Color.Blue;
                        break;
                    case 3:
                        i.ForeColor = Color.Red;
                        break;
                }

                String actionId = Tools.Data.NullFilterString(row["recall_action_id"]);
                if (Tools.Strings.StrExt(actionId))
                {
                    i.Tag += "-action";
                    i.ForeColor = Color.Red;
                }
            }
        }
        //private String WriteObject(nObject o, nObject l, int t, DateTime d, String u)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    switch (t)
        //    {
        //        case (Int32)Enums.RecallType.Delete:
        //            sb.AppendLine("Deleted by " + u + " on " + d.ToString() + "<br>");
        //            return sb.ToString();
        //        case (Int32)Enums.RecallType.Insert:
        //            sb.AppendLine("Created by " + u + " on " + d.ToString() + "<br>");//don't return, so it will show the original state                    
        //            break;
        //        default:
        //            sb.AppendLine("Modified by " + u + " on " + d.ToString() + "<br>");
        //            break;
        //    }
        //    if (l == null) //write the whole thing
        //        sb.AppendLine(WriteWholeObject(o));
        //    else    //write the differences
        //        sb.AppendLine(WriteChanges(o, l));
        //    return sb.ToString();
        //}
        //private String WriteChanges(nObject o, nObject l)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("<table border=\"1\" bordercolor=\"#CCCCCC\">");
        //    sb.AppendLine("  <tr>");
        //    int c = 1;
        //    foreach (VarVal p in o.VarValsGet())
        //    {
        //        if (c > 2)
        //        {
        //            c = 1;
        //            sb.AppendLine("</tr>");
        //            sb.AppendLine("<tr>");
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
        //            so = Tools.Strings.Left(so, 255);
        //            sl = Tools.Strings.Left(sl, 255);
        //            //sb.AppendLine("<td><font size=\"1\" color=\"#0000FF\">" + p.Name + "</font></td>");
        //            //sb.AppendLine("<td><font size=\"1\" color=\"#008000\">" + sl + "</font></td>");
        //            //sb.AppendLine("<td><font size=\"1\" color=\"black\">" + so + "</font></td>");
        //            sb.AppendLine("<td><font size=\"1\" color=\"#0000FF\">" + p.Name + "</font></td>");
        //            sb.AppendLine("<td><font size=\"1\" color=\"red\">" + sl + "</font></td>");
        //            sb.AppendLine("<td><font size=\"1\" color=\"#008000\">" + so + "</font></td>");
        //            if (c == 1)
        //                sb.AppendLine("<td width=\"50\"></td>");
        //            c++;
        //        }
        //    }
        //    sb.AppendLine("</tr></table><br>");
        //    return sb.ToString();
        //}
        //private String WriteWholeObject(nObject o)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    List<CoreVarValAttribute> s = NMWin.ContextDefault.TheSys.CoreClassGet(o.ClassId).VarValsGet();
        //    if (s == null)
        //    {
        //        sb.AppendLine("No properties could be found for this kind of information (" + o.ClassId + ")");
        //        return sb.ToString();
        //    }
        //    sb.AppendLine("<table border=\"1\" bordercolor=\"#CCCCCC\">");
        //    sb.AppendLine("  <tr>");
        //    int c = 1;
        //    foreach (CoreVarValAttribute p in s)
        //    {
        //        if (c > 4)
        //        {
        //            c = 1;
        //            sb.AppendLine("</tr>");
        //            sb.AppendLine("<tr>");
        //        }
        //        //caption
        //        sb.AppendLine("<td><font size=\"1\" color=\"#0000FF\">" + p.Name + "</font></td>");
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
        private String GetSelectedUID()
        {
            try
            {
                return (String)lv.SelectedItems[0].Tag;
            }
            catch { return ""; }
        }
        private bool RestoreByUID(String s)
        {
            CoreClassHandle c = NMWin.ContextDefault.TheSys.CoreClassGet(CurrentObject.ClassId);
            if (c == null)
                return false;

            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (CoreVarValAttribute p in c.VarValsGet())
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append(p.Name);
                i++;
            }

            String strID = NMWin.ContextDefault.xSys.RecallConnection.GetScalar_String("select unique_id from " + CurrentObject.ClassId + " where recall_uid = '" + s + "'");
            String strRecallDatabase = NMWin.ContextDefault.xSys.RecallConnection.TheKey.DatabaseName;

            Context xx = NMWin.ContextDefault.Clone();
            String id = xx.BeginTran();

            nObject x = (nObject)NMWin.ContextDefault.GetById(CurrentObject.ClassId, strID);
            if (x != null)
            {
                if (!NMWin.Leader.AreYouSure("delete and replace the existing instance of this item [" + x.ToString() + "]"))
                    return false;
                xx.Execute("delete from " + CurrentObject.ClassId + " where unique_id = '" + x.unique_id + "'");
                //xx.Delete(x);
            }
            else
            {
                if (!NMWin.Leader.AreYouSure("restore this item"))
                    return false;
            }

            String strSQL = "insert into " + CurrentObject.ClassId + "( unique_id, " + sb.ToString() + " ) select top 1 unique_id, " + sb.ToString() + " from " + strRecallDatabase + ".dbo." + CurrentObject.ClassId + " where recall_uid = '" + s + "'";
            xx.Execute(strSQL);

            try
            {
                xx.CommitTran(id);
                NMWin.Leader.Tell("Done.");
                return true;
            }
            catch(Exception ex)
            {
                NMWin.Leader.Error(ex);
                return false;
            }
        }
        //Control Events
        private void nChanges_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void sp_SplitterMoved(object sender, SplitterEventArgs e)
        {
            DoResize();
        }
        private void lv_Click(object sender, EventArgs e)
        {
            String s = GetSelectedUID();
            if (!Tools.Strings.StrExt(s))
                return;

            if (s.EndsWith("-action"))
                return;

            wb2.ReloadWB();

            List<CoreVarValAttribute> props = NMWin.ContextDefault.TheSys.VarVals(CurrentObject.ClassId);
            if (props == null)
            {
                wb2.Add("Class Info Not Found.");
                return;
            }

            DataTable d = NMWin.ContextDefault.xSys.RecallConnection.Select("select * from " + CurrentObject.ClassId + " where recall_uid = '" + s + "'");
            if (!Tools.Data.DataTableExists(d))
            {
                wb2.Add("<h2>Not Found</h2>");
            }
            else
            {
                DataRow r = d.Rows[0];
                wb2.Add("Date: " + nTools.DateFormat_ShortDateTime(nData.NullFilter_Date(r["recall_date"])) + "<br>");
                wb2.Add("User: " + nData.NullFilter_String(r["recall_user_name"]) + "<br>");
                wb2.Add("Machine: " + nData.NullFilter_String(r["recall_machine_name"]) + "<br>");
                wb2.Add("Version: " + nData.NullFilter_String(r["recall_version"]) + "<br>");

                wb2.Add("<table border=\"1\" bordercolor=\"#CCCCCC\">");

                foreach (CoreVarValAttribute p in props)
                {
                    Object v = null;
                    String so = "";
                    try
                    {
                        v = r[p.Name];
                        so = Convert.ToString(v);
                    }
                    catch { }

                    wb2.Add("<tr><td><font size=\"1\" color=\"#0000FF\">" + p.Name + "</font></td>");
                    wb2.Add("<td><font size=\"1\" color=\"black\">" + so + "</font></td></tr>");
                }

                wb2.Add("</table>");
            }
        }
        //Menus
        private void mnuRestore_Click(object sender, EventArgs e)
        {
            String s = GetSelectedUID();
            if (!Tools.Strings.StrExt(s))
                return;
            RestoreByUID(s);
        }
    }
}
