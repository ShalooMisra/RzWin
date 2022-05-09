using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using CoreWin;

namespace Rz5.Win.Screens
{
    public partial class RzLink : UserControl  //, IStatusView
    {
        //Private Variables
        private company TheCompany;
        delegate void HandleStatus(String s);
        delegate void HandleProgress(int i);

        //Constructors
        public RzLink()
        {
            InitializeComponent();
            ////nStatus.RegisterStatusView(this);
        }
        //Public Functions
        public void Init()
        {
            LoadLV();
            if (RzWin.Context.TheSysRz.TheLinkLogic.Activated(RzWin.Context))
                InitActive();
            else
                InitInActive();
        }
        public void SetStatusByIndex(Object sender, StatusArgs args)
        {
            if (this.InvokeRequired)
            {
                HandleStatus d = new HandleStatus(AddStatus);
                this.Invoke(d, new object[] { args.status });
            }
            else
                AddStatus(args.status);
        }
        public void SetProgressByIndex(Object sender, ProgressArgs args)
        {
            if (this.InvokeRequired)
            {
                HandleProgress d = new HandleProgress(AddProgress);
                this.Invoke(d, new object[] { args.progress });
            }
            else
                AddProgress(args.progress);
        }
        public void SetActivityByIndex(Object sender, ActivityArgs args)
        {

        }
        public void AddLine()
        {

        }
        public void RemoveLine()
        {

        }
        public void DoResize()
        {
            try
            {
                SetBorder();
                cmdAddComp.Top = (pbBottom.Top - cmdAddComp.Height) - 2;
                lv.Height = (cmdAddComp.Top - lv.Top) - 2;
                gbStatus.Height = (pbBottom.Top - gbStatus.Top) - 2;
                pb.Top = (gbStatus.ClientRectangle.Height - pb.Height) - 2;
                rt.Height = (pb.Top - rt.Top) - 2;
                gbStatus.Width = (pbRight.Left - gbStatus.Left) - 2;
                rt.Width = (gbStatus.ClientRectangle.Width - rt.Left) - 2;
                pb.Width = rt.Width;
            }
            catch { }
        }
        //Private Functions
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();

            }
            catch (Exception)
            { }
        }
        private void InitActive()
        {
            cmdActivate.Enabled = true;
            pActive.Enabled = true;
            cmdActivate.Text = "Update";           
            lblLink.Text = "Log Into RzLink";
            txtLink.Text = RzWin.Context.TheSysRz.TheLinkLogic.LinkUrl(RzWin.Context);
        }
        private void InitInActive()
        {
            cmdActivate.Enabled = true;
            pActive.Enabled = false;
            cmdActivate.Text = "Activate";
        }
        private void Activate()
        {
            if (bg.IsBusy)
                return;
            if (NoLoginCompanies())
            {
                if (!RzWin.Context.TheLeader.AskYesNo("There are no companies in your database that have a username/password. Do you still want to activate and upload your database?"))
                    return;
            }
            rt.Text = "";
            pb.Value = 0;
            cmdActivate.Enabled = false;
            throb.Visible = true;
            throb.BringToFront(); 
            throb.ShowThrobber();
            bg.RunWorkerAsync();
        }
        private bool ActuallyActivate()
        {
            try
            {
                string m = "";
                bool b = RzWin.Context.TheSysRz.TheLinkLogic.Export(RzWin.Context, ref m);
                
                //will this work?
                RzWin.Leader.ProgressPercent = 10;
                RzWin.Leader.Comment(m);
                return b;
            }
            catch { }
            return false;
        }
        private void LoadLV()
        {
            lv.Items.Clear();
            lv.SuspendLayout();
            try
            {
                DataTable dt = RzWin.Context.Select("select unique_id,companyname,internetusername,internetpassword from company where len(isnull(internetusername,'')) > 0");
                if (dt == null)
                {
                    lv.ResumeLayout();
                    return;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem xLst = lv.Items.Add(nData.NullFilter_String(dr["companyname"]));
                    xLst.SubItems.Add(nData.NullFilter_String(dr["internetusername"]));
                    xLst.SubItems.Add(nData.NullFilter_String(dr["internetpassword"]));
                    xLst.Tag = dr["unique_id"].ToString();
                }
            }
            catch { }
            lv.ResumeLayout();
        }
        private void UpdateCompanyLogin()
        {
            if (TheCompany == null)
                return;
            string id = RzWin.Context.SelectScalarString("select unique_id from company where internetusername = '" + txtCompUser.Text + "' and internetpassword = '" + txtCompPW.Text + "'");
            if (Tools.Strings.StrExt(id))
            {
                if (!Tools.Strings.StrCmp(TheCompany.unique_id, id))
                {
                    RzWin.Context.TheLeader.Tell("Another company already has this username/password assigned to their account.");
                    return;
                }
            }
            TheCompany.internetusername = txtCompUser.Text;
            TheCompany.internetpassword = txtCompPW.Text;
            TheCompany.Update(RzWin.Context);
            LoadLV();
        }
        private void AddCompany()
        {
            TheCompany = frmChooseCompany_Big.ChooseCompany("Choose Company");
            if (TheCompany == null)
                return;
            lblComp.Text = TheCompany.companyname;
            txtCompUser.Text = TheCompany.internetusername;
            txtCompPW.Text = TheCompany.internetpassword;
        }
        private void LoadSelectedCompany()
        {
            ListViewItem xLst = null;
            try { xLst = lv.SelectedItems[0]; }
            catch { }
            if (xLst == null)
                return;
            TheCompany = company.GetById(RzWin.Context, xLst.Tag.ToString());
            if (TheCompany == null)
                return;
            lblComp.Text = TheCompany.companyname;
            txtCompUser.Text = TheCompany.internetusername;
            txtCompPW.Text = TheCompany.internetpassword;
        }
        private void FinishActivation()
        {
            if (RzWin.Context.GetSettingBoolean("rz_link_active"))
                return;
            RzWin.Context.TheSysRz.TheLinkLogic.activatedCheck = false;
            RzWin.Context.SetSettingBoolean("rz_link_active", true);
        }
        private bool NoLoginCompanies()
        {
            DataTable dt = RzWin.Context.Select("select unique_id,companyname from company where len(isnull(internetusername,'')) > 0");
            if (dt == null)
                return true;
            if (dt.Rows.Count <= 0)
                return true;
            return false;
        }
        private void OpenPortal()
        {
            if (!Tools.Strings.StrExt(txtLink.Text))
                return;
            Tools.FileSystem.Shell(txtLink.Text);
        }
        private void AddStatus(String s)
        {
            rt.Text = s + "\r\n" + rt.Text;
        }
        private void AddProgress(int p)
        {
            int i = pb.Value + p;
            pb.Value = i;
        }
        //Buttons
        private void cmdActivate_Click(object sender, EventArgs e)
        {
            Activate();
        }
        private void cmdUpdateComp_Click(object sender, EventArgs e)
        {
            UpdateCompanyLogin();
        }
        private void cmdAddComp_Click(object sender, EventArgs e)
        {
            AddCompany();
        }
        //Control Events
        private void RzLink_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToolsWin.WebWin.BrowseWebAddress(RzWin.Context.TheSysRz.TheLinkLogic.LinkUrl(RzWin.Context));
        }
        private void lblCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToolsWin.Clipboard.SetClip(txtLink.Text);
        }
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedCompany();
        }
        private void lv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            LoadSelectedCompany();
        }
        //Background Workers
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            RzWin.Leader.Comment("Uploading...");
            e.Result = ActuallyActivate();
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //RzWin.Leader.Comment("Done");
            //throb.HideThrobber();
            //throb.Visible = false;
            //cmdActivate.Enabled = true;
            //if ((bool)e.Result)
            //    FinishActivation();
            //nStatus.SetProgress(10);
            //Init();
            //OpenPortal();
        }
    }
}
