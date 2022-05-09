using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using Tools;
using NewMethod;



namespace Rz5
{
    public partial class DutyMonitor : UserControl, ICompleteLoad
    {
        DutyLogic TheLogic
        {
            get
            {
                return ((SysRz5)RzWin.Context.TheSys).TheDutyLogic;
            }
        }
        
        private mc_done CurrentDone;
        private mc_duty CurrentDuty;
        private mc_duty DisplayedDuty;

        public DutyMonitor()
        {
            InitializeComponent();
            picActive.Image = IM.Images["LED-Red.bmp"];
        }

        public void CompleteLoad()
        {
            TheLogic.DutyStarted += new ThreadDoneHandler(TheLogic_DutyStarted);
            TheLogic.DutyComplete += new ThreadDoneHandler(TheLogic_DutyComplete);
            TheLogic.DutiesLoadCheck((ContextRz)RzWin.Context);
            LoadDatabases();
            DutiesShow();
            ctl_duty_function.SimpleList = RzWin.Logic.GetDutyList();
            if (!Tools.Strings.HasString(RzWin.Form.Text, "Duty Monitor"))
                RzWin.Form.Text += " - Duty Monitor";
            wbSingle.ShowControls = true;
        }

        void LoadDatabases()
        {
            string l = "";
            ArrayList a = RzWin.Context.SelectScalarArray("select distinct(name) from master.sys.databases where name not in ('master', 'tempdb', 'model', 'msdb') order by name");
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (Tools.Strings.StrExt(l))
                    l += "|";
                l += s;
            }
            ctl_duty_targets.SimpleList = l;
        }

        void InitUn()
        {
            try
            {
                TheLogic.DutyStarted -= new ThreadDoneHandler(TheLogic_DutyStarted);
                TheLogic.DutyComplete -= new ThreadDoneHandler(TheLogic_DutyComplete);
            }
            catch { }
        }

        void TheLogic_DutyComplete(DutyRunHandle dh)
        {
            this.Invoke(new ThreadDoneHandler(w_RunWorkerCompleted), new object[] { dh });
        }

        void DutiesShow()
        {
            tv.Nodes.Clear();
            tv.BeginUpdate();

            foreach (mc_duty d in TheLogic.Duties)
            {
                InsertDuty(d);
            }

            tv.EndUpdate();
        }

        private void InsertDuty(mc_duty d)
        {
            d.CacheRecentDone(RzWin.Context);
            TreeNode n = tv.Nodes.Add("");
            n.Tag = d;
            n.Checked = true;
            d.MyNode = n;
            StyleDuty(d, n);

            foreach (mc_done done in d.AllDone)
            {
                AddDone(d, done);
            }
        }

        private void AddDone(mc_duty duty, mc_done done)
        {
            try
            {
                int above = duty.MyNode.Nodes.Count - 5;
                if (above > 0)
                {
                    List<TreeNode> remove = new List<TreeNode>();
                    for (int i = 0; i < above; i++)
                    {
                        remove.Add(duty.MyNode.Nodes[i]);
                    }
                    foreach (TreeNode r in remove)
                    {
                        ((mc_done)r.Tag).MyNode = null;
                        r.Tag = null;
                        duty.MyNode.Nodes.Remove(r);
                    }
                }
            }
            catch { }

            TreeNode nd = duty.MyNode.Nodes.Add("");
            nd.Tag = done;
            done.MyNode = nd;
            StyleDone(done, nd);
        }

        private void StyleDuty(mc_duty d, TreeNode n)
        {
            n.Text = d.GetTreeCaption();
            n.ForeColor = d.GetTreeColor();
        }

        private void StyleDone(mc_done d, TreeNode n)
        {
            n.Text = d.GetTreeCaption();
            n.ForeColor = d.GetTreeColor();
        }

        private void cmdStartStop_Click(object sender, EventArgs e)
        {
            StartStopTimers();
        }

        List<mc_duty> DutiesCheckedGet()
        {
            List<mc_duty> ret = new List<mc_duty>();
            foreach (TreeNode n in tv.Nodes)
            {
                if (n.Checked)
                    ret.Add((mc_duty)n.Tag);
            }
            return ret;
        }

        public bool Started = false;
        public void StartStopTimers()
        {
            if (Started)
            {
                Stop();
                cmdStartStop.Text = "Start";
                cmdStartStop.ImageKey = "Start.bmp";
            }
            else
            {
                Start();
                cmdStartStop.Text = "Stop";
                cmdStartStop.ImageKey = "Stop.bmp";
            }
        }

        List<mc_duty> DutiesChecked;
        public void Start()
        {
            //TheLogic.LogClear();

            DutiesChecked = DutiesCheckedGet();
            if (DutiesChecked.Count == 0)
            {
                RzWin.Context.TheLeader.TellTemp("No selected duties.");
                Stop();
                return;
            }

            String name = "_any_";
            if (DutiesChecked.Count == 1 && DutiesChecked.Count != tv.Nodes.Count)
            {
                name = RzWin.Leader.AskForString("Run name", "", "Name");
            }

            //DutyLogic.LogFile = "c:\\rz_duty_monitor" + name + ".txt";

            if (Tools.Strings.StrExt(name))
                RzWin.Form.Text += " - " + name;

            tmr.Interval = TheLogic.DutyIntervalMilliseconds;
            tmr.Start();
            Started = true;

        }

        private void Stop()
        {
            tmr.Stop();
            Started = false;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();

            TheLogic.Check((ContextRz)RzWin.Context, DutiesChecked);

            if (DisplayedDuty != null)
            {
                lblNext.Text = nTools.FormatDHMS(DisplayedDuty.GetSecondsUntilNextRun());
                if (DisplayedDuty.is_disabled)
                    lblNext.Text += " [disabled]";
                lblNext.Refresh();
            }
            else
                lblNext.Text = "<next>";

            tmr.Start();
        }

        void done_GotStatus(object sender, string status)
        {
            if (CurrentDone == null)
                return;

            if (CurrentDone != sender)
                return;

            LoadCurrentDone(CurrentDone);            
        }

        private delegate void SetCurrentDoneStatusHandler();
        private void LoadCurrentDone(mc_done done)
        {
            CurrentDone = done;

            if (this.InvokeRequired)
            {
                SetCurrentDoneStatusHandler d = new SetCurrentDoneStatusHandler(SetCurrentDoneStatus);
                this.Invoke(d);
            }
            else
            {
                SetCurrentDoneStatus();
            }
        }

        private void SetCurrentDoneStatus()
        {
            if (CurrentDone == null)
            {
                txtStatus.Text = "";
                return;
            }
            txtStatus.Text = CurrentDone.done_status;
        }

        private void RemovePastDone(mc_duty d)
        {
            DateTime start = d.GetRecentStartDate();
            foreach (mc_done done in d.AllDone)
            {
                if (done.start_date < start)
                {
                    d.MyNode.Nodes.Remove(done.MyNode);
                }
            }
        }

        void w_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        private void mnuRun_Click(object sender, EventArgs e)
        {
            mc_duty d = GetSelectedDuty();
            if (d == null)
                return;

            RunDuty(d);
        }

        void RunDuty(mc_duty d)
        {
            ContextRz context = (ContextRz)RzWin.Context.Clone();
            context.TheLeader = RzWin.Context.Sys.TheDutyLogic.DutyLeaderCreate();

            mc_done done = TheLogic.RunDuty(context, d);
        }

        void TheLogic_DutyStarted(DutyRunHandle dh)
        {
            this.Invoke(new ThreadDoneHandler(DutyStartedActually), new object[] { dh });
        }

        void DutyStartedActually(DutyRunHandle dh)
        {
            AddDone(dh.d, dh.done);
            LoadCurrentDone(dh.done);
            StyleDuty(dh.d, dh.d.MyNode);
        }
       
        void w_RunWorkerCompleted(DutyRunHandle dh)
        {
            try
            {
                mc_duty d = dh.d;
                StyleDuty(d, d.MyNode);
                StyleDone(d.CurrentDone, d.CurrentDone.MyNode);
                RemovePastDone(d);
            }
            catch (Exception ex)
            {
                RzWin.Leader.Comment("RTE in w_RunWorkerCompleted: " + ex.Message);
            }
        }

        private mc_duty GetSelectedDuty()
        {
            try
            {
                TreeNode n = tv.SelectedNode;
                if (n == null)
                    return null;

                if (n.Tag == null)
                    return null;

                return (mc_duty)n.Tag;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private mc_done GetSelectedDone()
        {
            try
            {
                TreeNode n = tv.SelectedNode;
                if (n == null)
                    return null;

                if (n.Tag == null)
                    return null;

                return (mc_done)n.Tag;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void tv_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
                try
                {
                    TreeViewHitTestInfo info = tv.HitTest(new Point(e.X, e.Y));
                    if (info == null)
                        return;

                    TreeNode n = info.Node;
                    if (n == null)
                        return;

                    tv.SelectedNode = n;
                }
                catch (Exception)
                { }
            //}
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            mc_duty d = GetSelectedDuty();
            if (d != null)
            {
                if (!RzWin.Leader.AreYouSure("delete duty '" + d.duty_name + "'"))
                    return;

                d.Delete(RzWin.Context);
                if( d.MyNode != null )
                    tv.Nodes.Remove(d.MyNode);
            }
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            SaveDuty();
        }

        private void cmdNewDuty_Click(object sender, EventArgs e)
        {
            AddNewDuty();
        }

        public void AddNewDuty()
        {
            mc_duty d = mc_duty.New(RzWin.Context);
            d.is_disabled = true;
            d.duty_name = "New Duty";
            d.Insert(RzWin.Context);

            TheLogic.Duties.Add(d);
            DutiesShow();

            SetDisplayedDuty(d);
        }

        private void SetDisplayedDuty(mc_duty d)
        {
            DoResize();
            if (DisplayedDuty != null)
                SaveDuty();

            DisplayedDuty = d;
            DisplayDuty();
        }

        private void DisplayDuty()
        {
            DoResize();

            if (DisplayedDuty == null)
                return;

            //ctl_duty_name.SetValue(DisplayedDuty.duty_name);
            ctl_duty_function.SetValue(DisplayedDuty.function_name);
            ctl_ideal_hour.SetValue(DisplayedDuty.ideal_hour);
            ctl_ideal_minute.SetValue(DisplayedDuty.ideal_minute);
            ctl_ideal_weekday.SetValue(DisplayedDuty.ideal_weekday);

            switch (DisplayedDuty.duty_interval)
            {
                case 0:
                case 5:
                    opt5Minutes.Checked = true;
                    break;
                case 10:
                    opt10Minutes.Checked = true;
                    break;
                case 30:
                    opt30Minutes.Checked = true;
                    break;
                case 60:
                    optHour.Checked = true;
                    break;
                case 120:
                    opt2Hours.Checked = true;
                    break;
                case 240:
                    opt4Hours.Checked = true;
                    break;
                case 1440:
                    optDay.Checked = true;
                    break;
                case 10080:
                    optWeek.Checked = true;
                    break;
                default:
                    optDay.Checked = true;
                    break;
            }
            cmdShowOptions.Visible = false;
            //if (Tools.Strings.StrCmp(DisplayedDuty.function_name, "AAT InvUpload") && Rz3App.xLogic.IsAAT)
            //    cmdShowOptions.Visible = true;
            //if (Tools.Strings.StrCmp(DisplayedDuty.function_name, "Delete Dibbs Docs") && Rz3App.xLogic.IsAAT)
            //    ctl_monthstodelete.Visible = true;
            ctl_duty_targets.Visible = false;
            if (Tools.Strings.StrCmp(DisplayedDuty.function_name, "RzRescue"))
            {
                ctl_duty_targets.Visible = true;
                ctl_duty_targets.SetValue(DisplayedDuty.duty_targets);
            }
        }

        private void SaveDuty()
        {
            if (DisplayedDuty == null)
                return;
            DisplayedDuty.duty_name = (String)ctl_duty_function.GetValue(); //  this is ignored elsewhere and confusing (String)ctl_duty_name.GetValue();
            DisplayedDuty.function_name = (String)ctl_duty_function.GetValue();
            DisplayedDuty.ideal_hour = ctl_ideal_hour.GetValue_Integer();
            DisplayedDuty.ideal_minute = ctl_ideal_minute.GetValue_Integer();
            DisplayedDuty.ideal_weekday = ctl_ideal_weekday.GetValue_String();
            if( opt5Minutes.Checked )
                DisplayedDuty.duty_interval = 5;
            else if( opt10Minutes.Checked )
                DisplayedDuty.duty_interval = 10;
            else if( opt30Minutes.Checked )
                DisplayedDuty.duty_interval = 30;
            else if( optHour.Checked )
                DisplayedDuty.duty_interval = 60;
            else if( opt2Hours.Checked )
                DisplayedDuty.duty_interval = 120;
            else if (opt4Hours.Checked)
                DisplayedDuty.duty_interval = 240;
            else if (optDay.Checked)
                DisplayedDuty.duty_interval = 1440;
            else if (optWeek.Checked)
                DisplayedDuty.duty_interval = 10080;
            else
                DisplayedDuty.duty_interval = 1440;
            if (ctl_duty_targets.Visible)
            {
                if (!UpdateRescueDB())
                    return;
            }
            DisplayedDuty.Update(RzWin.Context);
            StyleDuty(DisplayedDuty, DisplayedDuty.MyNode);
            //if (ctl_monthstodelete.Visible && Rz3App.xLogic.IsAAT)
            //{
            //    Int32 mnths = 0;
            //    try { mnths = Convert.ToInt32(ctl_monthstodelete.GetValue()); }
            //    catch { }
            //    if (mnths > 0)
            //        Rz3App.xSys.SetSetting_Integer("dibbs_monthstodelete", mnths);
            //}
        }

        private bool UpdateRescueDB()
        {
            string db = ctl_duty_targets.GetValue_String();
            if (!Tools.Strings.StrExt(db))
            {
                RzWin.Leader.Tell("You need to select a database to be backed up before saving this duty.");
                return false;
            }
            DisplayedDuty.duty_targets = db;
            DisplayedDuty.duty_name = "RzRescue [" + db + "]";
            return true;
        }

        private void tv_DoubleClick(object sender, EventArgs e)
        {
            mc_duty d = GetSelectedDuty();
            if (d == null)
                return;

            SetDisplayedDuty(d);
        }

        private void DutyMonitor_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            try
            {
                gb.Left = 0;
                gb.Top = 0;

                if (DisplayedDuty == null)
                    gb.Height = this.ClientRectangle.Height;
                else
                    gb.Height = this.ClientRectangle.Height - gbDuty.Height;

                tv.Top = 0;
                tv.Left = gb.Right;
                tv.Height = gb.Height;
                tv.Width = (this.ClientRectangle.Width - gb.Width) / 2;

                txtStatus.Top = 0;
                txtStatus.Left = tv.Right;
                txtStatus.Width = this.ClientRectangle.Width - txtStatus.Left;
                txtStatus.Height = gb.Height / 2;

                wbSingle.Left = tv.Right;
                wbSingle.Top = txtStatus.Bottom;
                wbSingle.Width = this.ClientRectangle.Width - txtStatus.Left;
                wbSingle.Height = gb.Height - wbSingle.Top;

                if (DisplayedDuty == null)
                    gbDuty.Visible = false;
                else
                {
                    gbDuty.Visible = true;
                    gbDuty.Left = 0;
                    gbDuty.Top = this.ClientRectangle.Height - gbDuty.Height;
                    gbDuty.Width = this.ClientRectangle.Width;
                }
            }
            catch (Exception)
            { }
        }

        private void mnu_Opening(object sender, CancelEventArgs e)
        {
            mc_duty d = GetSelectedDuty();
            if (d == null)
                return;

            if (d.is_disabled)
                mnuEnable.Text = "Enable " + d.duty_name;
            else
                mnuEnable.Text = "Disable " + d.duty_name;

            mnuRun.Text = "Run " + d.duty_name;
        }

        private void mnuEnable_Click(object sender, EventArgs e)
        {
            mc_duty d = GetSelectedDuty();
            if (d == null)
                return;

            d.is_disabled = !d.is_disabled;
            d.Update(RzWin.Context);
            StyleDuty(d, d.MyNode);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            SaveDuty();
            DisplayedDuty = null;
            DoResize();
        }

        private void tv_Click(object sender, EventArgs e)
        {
            wbSingle.ReloadWB();
            //txtSingleStatus.Text = "";
            mc_done d = GetSelectedDone();
            if (d == null)
                return;
            //txtSingleStatus.Text = nTools.DateFormat_ShortDateTime(d.start_date) + " to " + nTools.DateFormat_ShortDateTime(d.end_date) + "\r\n\r\n" + d.done_status;

            wbSingle.Add(nTools.DateFormat_ShortDateTime(d.start_date) + " to " + nTools.DateFormat_ShortDateTime(d.end_date) + "<br><br>" + d.done_status);
        }

        private void tmrRunning_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tmr.Enabled)
                    picActive.Image = IM.Images["LED-Green.bmp"];
                else
                    picActive.Image = IM.Images["LED-Red.bmp"];
            }
            catch (Exception)
            { }
        }

        protected virtual void cmdShowOptions_Click(object sender, EventArgs e)
        {
            //AAT_AutoInvUpload upload = new AAT_AutoInvUpload();
            //Rz3App.xMainForm.TabShow(upload, "Auto Upload Templates");
            //upload.CompleteLoad(Rz3App.xSys);
        }

        private void mnuSearch_Click(object sender, EventArgs e)
        {
            mc_duty dx = GetSelectedDuty();

            if (dx == null)
                return;

            String s = RzWin.Leader.AskForString("Search for?", "", "Search Term");
            if (!Tools.Strings.StrExt(s))
                return;

            ArrayList a = RzWin.Context.QtC("mc_done", "select * from mc_done where base_mc_duty_uid = '" + dx.unique_id + "' and done_status like '%" + RzWin.Context.Filter(s) + "%' order by start_date desc");
            if (a.Count == 0)
            {
                RzWin.Leader.Tell("No results were found.");
                return;
            }

            int max = 5;
            if (a.Count > 5)
            {
                String m = RzWin.Leader.AskForString("There are " + Tools.Number.LongFormat(a.Count) + " results.  How many do you want to see?", "5", "Count");
                if (!Tools.Strings.StrExt(m))
                    return;

                if (!Tools.Number.IsNumeric(m))
                    return;

                max = Int32.Parse(m);                       
            }

            if (max > a.Count)
                max = a.Count;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < max; i++)
            {
                mc_done x = (mc_done)a[i];
                sb.Append(x.unique_id + "\r\nOn: " + x.start_date.ToString() + "\r\n\r\n" + x.done_status);
                sb.AppendLine("---------------------------------------------------\r\n\r\n");
            }
            Tools.FileSystem.PopText(sb.ToString());
        }

        private void lblCheckAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetAll(true);
        }

        private void lblCheckNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetAll(false);
        }

        void SetAll(bool check)
        {
            foreach (TreeNode n in tv.Nodes)
            {
                n.Checked = check;
            }
        }

        private void ctl_duty_function_SelectionChanged(GenericEvent e)
        {
            ctl_duty_targets.Visible = false;
            if (Tools.Strings.StrCmp(ctl_duty_function.GetValue_String(), "RzRescue"))
                ctl_duty_targets.Visible = true;
        }
    }
}
