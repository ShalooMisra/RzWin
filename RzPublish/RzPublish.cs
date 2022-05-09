using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Tools;
using Core;
using NewMethod;
using Rz5;
using System.Net;
using System.Threading;
using ToolsWin;

namespace Rz5
{
    public partial class Upload : UserControl
    {
        public String ArrayLog = "";
        private UploadCore TheUploadCore = new UploadCore();
        //test
        //Constructors
        public Upload()
        {
            InitializeComponent();
            throb.BackColor = Color.White;
        }

        //Public Functions
        public void Init()
        {
            lvProject.Items.Clear();
            foreach (UploadFolder f in TheUploadCore.FoldersList(RzWin.Context))
            {
                ListViewItem i = lvProject.Items.Add(f.Name);
                i.Tag = f;
            }

            lv.Items.Clear();
            //lv.SuspendLayout();
            //try
            //{
            //    foreach (String s in TheUploadCore.MainstreamCompanies)
            //    {
            //        ListViewItem xLst = lv.Items.Add(s);
            //        if (Tools.Strings.StrCmp(s, "Rz3"))
            //            xLst.Tag = s;
            //        else
            //            xLst.Tag = "Rz3_" + s;
            //    }
            //}
            //catch { }
            //lv.ResumeLayout();

            ScreenRefresh();
        }

        void l_ProgressSet(int percent)
        {
            Invoke(new ProgressSetHandler(ProgressSetActually), new Object[] { percent });
        }

        void ProgressSetActually(int percent)
        {
            pb.Value = percent;
            pb.Refresh();
        }

        void l_StatusSet(string s, Color c)
        {
            Invoke(new StatusSetHandler(StatusSetActually), new Object[] { s, c });
        }

        void StatusSetActually(string s, Color c)
        {
            lblStatus.Text = s;
            lblStatus.ForeColor = c;
            if (s.StartsWith("Error:"))
                MessageBox.Show(s);
        }

        void ScreenRefresh()
        {
            UploadFolder f = UploadFolderSelected;
            if (f == null)
            {
                cmdUpload.Text = "Upload";
                cmdUpload.Enabled = false;
            }
            else
            {
                cmdUpload.Text = "Upload " + f.Name;
                cmdUpload.Enabled = true;

                pMainstream.Visible = (f.Name == "Mainstream");
            }
        }

        UploadFolder UploadFolderSelected
        {
            get
            {
                try
                {
                    return (UploadFolder)lvProject.SelectedItems[0].Tag;
                }
                catch { return null; }
            }
        }

        private void CheckUnCheckAll(bool check)
        {
            foreach (ListViewItem xLst in lv.Items)
            {
                xLst.Checked = check;
            }
        }

        UploadFolder FolderCurrent;
        List<String> mainstreams;
        bool alternateSite = false;

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            FolderCurrent = UploadFolderSelected;
            if (FolderCurrent == null)
                return;

            FolderCurrent.Beta = chkBeta.Checked;
            if (UploadFolderSelected.Name == "SensibleTest")
            {
                FolderCurrent.Test = true;
            }
            alternateSite = optAlternate.Checked;
            //if (chkIncludeSHDocVw.Checked)
            //    FolderCurrent.FilesAddSHDocVw();

            mainstreams = new List<String>();
            if (FolderCurrent.Name == "Mainstream")
            {
                foreach (ListViewItem i in lv.CheckedItems)
                {
                    mainstreams.Add((String)i.Tag);
                }
            }
            UploadCore.RunTests = false;
            cmdUpload.Enabled = false;
            throb.ShowThrobber();
            bg.RunWorkerAsync();

        }

        //Background Workers

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
            cmdUpload.Enabled = true;
            StatusSetActually("Done.", Color.Green);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckUnCheckAll(chkAll.Checked);
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {


            Leader TheLeader = new Leader();
            TheLeader.StatusSet += new StatusSetHandler(l_StatusSet);
            TheLeader.ProgressSet += new ProgressSetHandler(l_ProgressSet);

            TheLeader.ProgressClear();

            //if (alternateSite)
            //    TheUploadCore.FtpSite = "mike.recognin.com";
            //else
            //    TheUploadCore.FtpSite = "versions.recognin.com";

            Context context = RzWin.Context.Clone();
            context.TheLeader = TheLeader;

            if (FolderCurrent.Name != "Mainstream")
                TheUploadCore.Run(context, FolderCurrent);

            //if (FolderCurrent.Name == "Mainstream")
            //{
            //    TheUploadCore.IncrementAndBuild(context, FolderCurrent);
            //    foreach (String m in mainstreams)
            //    {
            //        UploadFolder ms = UploadCore.MainstreamCreate(m);
            //        TheUploadCore.Upload(context, ms);
            //    }
            //}

            TheLeader.StatusSet -= new StatusSetHandler(l_StatusSet);
            TheLeader.ProgressSet -= new ProgressSetHandler(l_ProgressSet);

        }

        private void lvProject_Click(object sender, EventArgs e)
        {
            ScreenRefresh();
        }


    }
}