using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tools.Database;

namespace NewMethod
{
    public partial class ActivityReport : UserControl, ICompleteLoad
    {
        SysNewMethod xSys
        {
            get
            {
                return NMWin.ContextDefault.xSys;
            }
        }
        public ActivityReport()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            start.SetValue(nTools.GetDayStart(DateTime.Now));
            end.SetValue(DateTime.Now);
            txtEndTime.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

            LoadUsers();
            LoadClasses();
            DoResize();
        }

        private void LoadClasses()
        {
            chkRecall.Checked = xSys.Recall;

            lstClasses.Items.Clear();
            String[] ary = xSys.GetActiveClasses();
            foreach(String s in ary)
            {
                lstClasses.Items.Add(s, true);
            }
        }

        private void LoadUsers()
        {
            lstUsers.Items.Clear();
            foreach (n_user u in xSys.Users.All)
            {
                lstUsers.Items.Add(u.Name);
            }
        }

        public void DoResize()
        {
            try
            {
                wb.Top = 0;
                wb.Width = this.ClientRectangle.Width - wb.Left;
                wb.Height = this.ClientRectangle.Height;
            }
            catch (Exception)
            { }
        }

        private void ActivityReport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            ShowActivity();
        }

        private void ShowActivity()
        {
            wb.ReloadWB();

            String strUsers = "";
            String strNames = "";
            String strMachines = "";

            if (chkRecall.Checked && !xSys.Recall)
            {
                NMWin.Leader.Tell("This system is not configured for recall.");
                chkRecall.Checked = false;
            }

            foreach (String s in lstUsers.CheckedItems)
            {
                if (Tools.Strings.StrExt(strUsers))
                    strUsers += ", ";

                strUsers += "'" + xSys.TranslateUserNameToID(s) + "'";

                if (Tools.Strings.StrExt(strNames))
                    strNames += ", ";

                strNames += "'" + s + "'";            
            }

            String[] ary = Tools.Strings.Split(txtMachines.Text, "\r\n");
            foreach (String s in ary)
            {
                if (Tools.Strings.StrExt(s))
                {
                    if (Tools.Strings.StrExt(strMachines))
                        strMachines += ", ";

                    strMachines += "'" + s + "'";
                }
            }

            if ((!Tools.Strings.StrExt(strUsers)) && (!Tools.Strings.StrExt(strMachines)))
            {
                NMWin.Leader.Tell("Please select at least 1 user or machine.");
                return;
            }

            wb.Add("Activity Report for ");

            if (Tools.Strings.StrExt(strNames))
                wb.Add(" Users: " + strNames);

            if( Tools.Strings.StrExt(strMachines) )
                wb.Add(" Machines: " + strMachines);

            foreach (String s in lstClasses.CheckedItems)
            {
                ShowActivity(s, strUsers, strMachines, chkRecall.Checked, nTools.ConcatDateTime(start.GetValue_Date(), txtStartTime.Text), nTools.ConcatDateTime(end.GetValue_Date(), txtEndTime.Text));
            }
        }

        private void ShowActivity(String strClass, String strUsers, String strMachines, bool include_recall, DateTime dtStart, DateTime dtEnd)
        {
            wb.Add("<br><b>" + strClass + "</b><br>");

            DataConnection data = xSys.RecallConnection;

            String strWhere = "";

            if( Tools.Strings.StrExt(strUsers) && Tools.Strings.StrExt(strMachines) )
                strWhere += " ( recall_user_uid in ( " + strUsers + " ) or recall_machine_name in ( " + strMachines + " ) )" ;
            else if( Tools.Strings.StrExt(strUsers) )
                strWhere += " recall_user_uid in ( " + strUsers + " ) ";
            else
                strWhere += " recall_machine_name in ( " + strMachines + " ) ";

            strWhere = Tools.Dates.DateRange.GetSQLIncludingTime("recall_date", dtStart, dtEnd) + " and " + strWhere;

            DataTable d = data.Select("select * from " + strClass + " where " + strWhere + " order by recall_date");

            if( !Tools.Data.DataTableExists(d) )
            {
                wb.Add("No records for " + strClass + "<br>");
                return;
            }

            nObject x;

            wb.Add("<table border=1><tr><td>Date</td><td>User</td><td>Machine</td><td>Action</td><td>Description</td></tr>");

            foreach(DataRow r in d.Rows)
            {
                x = (nObject)NMWin.ContextDefault.Item(strClass);
                x.AbsorbRow(NMWin.ContextDefault, r);

                String strName = nData.NullFilter_String(r["recall_user_name"]);
                String strMachine = nData.NullFilter_String(r["recall_machine_name"]);
                DateTime dt = nData.NullFilter_DateTime(r["recall_date"]);
                int type = Tools.Data.NullFilterInt(r["recall_type"]);
                String strType = "";

                switch(type)
                {
                    case 1:
                        strType = "Created";
                        break;
                    case 2:
                        strType = "Updated";
                        break;
                    case 3:
                        strType = "Deleted";
                        break;
                    default:
                        strType = "Unknown";
                        break;
                }

                wb.Add("<tr><td>" + dt.ToString() + "</td><td>" + strName + "</td><td>" + strMachine + "</td><td>" + strType + "</td><td>" + x.GetClipHTML(NMWin.ContextDefault) + "</td></tr>");
            }
            wb.Add("</table>");
        }
    }
}
