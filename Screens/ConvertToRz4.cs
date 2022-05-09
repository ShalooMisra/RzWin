using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5.Win.Screens
{
    public partial class ConvertToRz4 : UserControl
    {
        //Private Variables
        private Context context;
        private Leader leader;

        //Contructors
        public ConvertToRz4()
        {
            InitializeComponent();
            throb.BackColor = Color.White;
        }
        //Private Functions
        private void LeaderInit()
        {
            leader = new Core.Leader();
            context = RzWin.Context.Clone();
            context.TheLeader = leader;
            leader.StatusSet += new StatusSetHandler(leader_StatusSet);
            leader.ProgressSet += new ProgressSetHandler(leader_ProgressSet);
        }
        private void LeaderInitUn()
        {
            leader.StatusSet -= new StatusSetHandler(leader_StatusSet);
            leader.ProgressSet -= new ProgressSetHandler(leader_ProgressSet);
        }
        private void Stat(String s)
        {
            if (txt.TextLength >= 5000)
                txt.Text = "";
            txt.AppendText(s + "\r\n");
        }
        private void Prog(int percent)
        {
            try
            {
                pb.Value = percent;
            }
            catch { }
        }
        //Buttons
        private void cmdConvert_Click(object sender, EventArgs e)
        {
            if (bwNowTo2009.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            LeaderInit();
            throb.ShowThrobber();
            bwNowTo2009.RunWorkerAsync();
        }
        private void cmdOrderInstances_Click(object sender, EventArgs e)
        {
            if (bgwReSave.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            LeaderInit();
            throb.ShowThrobber();
            bgwReSave.RunWorkerAsync();
        }
        private void cmdPrep_Click(object sender, EventArgs e)
        {
            if (bwPrepare.IsBusy)
                return;
            if (!RzWin.Context.TheLeader.AreYouSure("delete ALL OF THE orddet_line info in the system now"))
                return;
            bool update = RzWin.Context.TheLeader.AskYesNo("Would you like the system to update the database structure before the conversion?");
            RzWin.Leader.StartPopStatus();
            LeaderInit();
            throb.ShowThrobber();
            bwPrepare.RunWorkerAsync(update);
        }
        private void cmdConvert2_Click(object sender, EventArgs e)
        {
            if (bw2009To2005.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            LeaderInit();
            throb.ShowThrobber();
            bw2009To2005.RunWorkerAsync();
        }
        private void cmdfinish_Click(object sender, EventArgs e)
        {
            if (bgFinish.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            LeaderInit();
            throb.ShowThrobber();
            bgFinish.RunWorkerAsync();
        }
        //Control Events
        private void leader_ProgressSet(int percent)
        {
            Invoke(new NewMethod.SetProgressDelegate(Prog), new Object[] { percent });
        }
        private void leader_StatusSet(string s, Color c)
        {
            Invoke(new NewMethod.SetStatusDelegate(Stat), new Object[] { s });
        }
        //Background Workers
        private void bwPrepare_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bool update = (bool)e.Argument;
                if (update)
                {
                    RzWin.Leader.Comment("Doing Structure Update");
                    RzWin.Context.xSys.UpdateDataStructure(RzWin.Context, true);
                    RzWin.Leader.Comment("Doing Field Maintenance");
                    RzWin.Context.Sys.FieldMaintenance(RzWin.Context);
                }
                RzWin.Leader.Comment("Doing Rz5 Conversion Prep");
                RzWin.Context.TheSysRz.ThePanelLogic.ConvertToRz4Prep(RzWin.Context, new ActArgs());
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
            }
        }
        private void bwPrepare_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
            LeaderInitUn();
            RzWin.Leader.Comment("Rz5 Conversion Prep Complete.");
            RzWin.Leader.StopPopStatus(true);
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                RzWin.Leader.Comment("Doing Rz5 Conversion");
                RzWin.Context.TheSysRz.ThePanelLogic.ConvertToRz4NowTo2009(RzWin.Context, new ActArgs());
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
            }
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
            LeaderInitUn();
            RzWin.Leader.Comment("Rz5 Conversion Complete NowTo2009.");                         
            RzWin.Leader.StopPopStatus(true);
        }
        private void bw2009To2005_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                RzWin.Leader.Comment("Doing Rz5 Conversion");
                RzWin.Context.TheSysRz.ThePanelLogic.ConvertToRz42009To2005(RzWin.Context, new ActArgs());
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
            }
        }
        private void bw2009To2005_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
            LeaderInitUn();
            RzWin.Leader.Comment("Rz5 Conversion Complete 2009To2005.");
            RzWin.Leader.StopPopStatus(true);
        }
        private void bgFinish_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                RzWin.Context.TheSysRz.ThePanelLogic.ConvertToRz4Finish(RzWin.Context, new ActArgs());
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
            }
        }
        private void bgFinish_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
            LeaderInitUn();
            RzWin.Leader.Comment("Finish Complete.");
            RzWin.Leader.StopPopStatus(true);
        }
        private void bgwReSave_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                RzWin.Context.TheSysRz.ThePanelLogic.ResSaveAllOrderInstances(RzWin.Context);
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
            }
        }
        private void bgwReSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
            LeaderInitUn();
            RzWin.Leader.Comment("ReSave Complete.");
            RzWin.Leader.StopPopStatus(true);
        }
    }
}
