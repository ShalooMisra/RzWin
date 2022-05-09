//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;

//using NewMethod;

//namespace Rz4.VirtualFloor
//{
//    public partial class ActivityReport : UserControl
//    {
//        n_user xUser;
//        DateTime xDate;

//        public ActivityReport()
//        {
//            InitializeComponent();
//            throb.BackColor = Color.White;
//        }

//        public void CompleteLoad(n_user u, Image i, DateTime d)
//        {
//            xUser = u;
//            picActivity.Image = i;
//            xDate = d;

//            if (!user_activity.ActivityData.TableExists(TableName))
//            {
//                cmdGo.Enabled = false;
//                lv.Items.Add("No Data");
//                return;
//            }

//            optAll.Text = "All Activity On " + nTools.DateFormat(d);

//            ShowOptions();
//        }

//        void ShowOptions()
//        {
//            lvActivityTypes.Items.Clear();
//            lvActivityTypes.BeginUpdate();
//            try
//            {
//                String strSQL = "select name, count(unique_id) as frequency from " + TableName + " group by name order by name";
//                DataTable d = user_activity.ActivityData.Select(strSQL);
//                foreach (DataRow r in d.Rows)
//                {
//                    ListViewItem i = lvActivityTypes.Items.Add(nData.NullFilter_String(r["name"]));
//                    i.SubItems.Add(Tools.Data.NullFilterInt(r["frequency"]).ToString());
//                }
//            }
//            catch { }
//            lvActivityTypes.EndUpdate();
//        }

//        public String TableName
//        {
//            get
//            {
//                return user_activity.GetActivityTableName(xUser.unique_id, xDate);
//            }
//        }


//        String strTypes = "";
//        private void cmdGo_Click(object sender, EventArgs e)
//        {
//            Do_Go();
//        }
//        private void Do_Go()
//        {
//            Do_Go(RzWin.Form.TheContextNM);
//        }
//        private void Do_Go(ContextNM x)
//        {
//            lv.Items.Clear();
//            strTypes = "";

//            if (optAll.Checked)
//                strTypes = " isnull(name, '') > '' ";
//            else
//            {
//                if (lvActivityTypes.CheckedItems.Count == 0)
//                {
//                    x.TheLeader.TellTemp("Please choose an activity type, or select the 'All' option.");
//                    return;
//                }

//                foreach (ListViewItem i in lvActivityTypes.CheckedItems)
//                {
//                    if (Tools.Strings.StrExt(strTypes))
//                        strTypes += ", ";
//                    strTypes += "'" + user_activity.ActivityData.SyntaxFilter(i.Text) + "'";
//                }

//                strTypes = " name in ( " + strTypes + " ) ";
//            }

//            throb.ShowThrobber();
//            bg.RunWorkerAsync();
//        }
//        DataTable thedata;
//        private void bg_DoWork(object sender, DoWorkEventArgs e)
//        {
//            thedata = user_activity.ActivityData.Select("select * from " + TableName + " where " + strTypes + " order by date_created");
//        }

//        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
//        {
//            ShowResult();
//            throb.HideThrobber();
//        }

//        void ShowResult()
//        {
//            lv.BeginUpdate();
//            try
//            {

//                foreach (DataRow r in thedata.Rows)
//                {
//                    user_activity a = new user_activity(RzWin.Context.xSys);
//                    a.ICreate(RzWin.Context.xSys, r);
//                    ListViewItem i = lv.Items.Add(nTools.TimeFormat(a.date_created));
//                    i.SubItems.Add(a.name);
//                    i.SubItems.Add(a.description);
//                    if (a.activity_value > 0)
//                    {
//                        i.SubItems.Add(a.activity_value.ToString());
//                    }
//                    else
//                    {
//                        i.SubItems.Add("");
//                    }
//                }
//            }
//            catch { }
//            lv.EndUpdate();
//        }

//        private void ActivityReport_Resize(object sender, EventArgs e)
//        {
//            DoResize();
//        }

//        void DoResize()
//        {
//            try
//            {
//                lvActivityTypes.Height = this.ClientRectangle.Height - lvActivityTypes.Top;
//                lv.Width = this.ClientRectangle.Width - lv.Left;
//                lv.Height = this.ClientRectangle.Height - lv.Top;
//            }
//            catch { }
//        }

//    }
//}
