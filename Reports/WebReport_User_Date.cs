using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using NewMethod;

namespace Rz5
{
    public partial class WebReport_User_Date : NewMethod.nWebReport
    {
        //Public Variables
        public bool OnlySalespeople = false;
        public bool OptionsOnTopMode = false;
        public bool AllowAllUsers = false;

        //Constructors
        public WebReport_User_Date()
        {
            InitializeComponent();
        }
        //Public Virtual Functions
        public virtual bool zz_OnNavigate(GenericEvent e)
        {
            return false;
        }
        public virtual void LoadAgentTeams()
        {
            RzWin.Logic.LoadAgentTeamCombo(RzWin.Context, cboAgent, OnlySalespeople, ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, Permissions.ThePermits.ViewAllUsersOnReports, RzWin.Context.xUser));
            //Rz3App.xLogic.LoadAgentTeamCombo(cboAgent, OnlySalespeople, AllowAllUsers);
        }
        //Public Override Functions
        public override void RunReport()
        {
            base.RunReport();
        }
        public override void CompleteStructure()
        {
            base.CompleteStructure();
            ShowOptionSpace = true;
            OptionBoxWidth = gbOptions.Width;
            LoadAgentTeams();
            dtStart.SetValue(nTools.GetDate_ThisMonthStart());
            dtEnd.SetValue(DateTime.Now); 
            DoResize();
        }
        public override void DoResize()
        {
            try
            {
                if (OptionsOnTopMode)
                {
                    base.DoResize();
                    gbOptions.Height = dtEnd.Bottom + 10;
                    gbOptions.Left = 0;
                    gbOptions.Width = this.ClientRectangle.Width;

                    wb.Left = 0;
                    wb.Top = gbOptions.Bottom;
                    wb.Width = this.ClientRectangle.Width;
                    wb.Height = this.ClientRectangle.Height - (wb.Top + gb.Height);

                    gb.Left = 0;
                    gb.Top = this.ClientRectangle.Height - gb.Height;
                    gb.Width = this.ClientRectangle.Width;

                    panelAgent.Left = dtStart.Right + 25;
                    panelAgent.Top = dtStart.Top;

                    cmdView.Left = panelAgent.Left;
                    cmdView.Top = panelAgent.Bottom + 25;
                    cmdView.Width = cboAgent.Width;
                }
                else
                {
                    base.OptionBoxWidth = gbOptions.Width;
                    base.DoResize();

                    gbOptions.Top = 0;
                    gbOptions.Left = 0;
                    //if (ShowChart)
                    //{
                    //    if (ShowChartOnly)
                    //        gbOptions.Height = chart.Height;
                    //    else
                    //        gbOptions.Height = wb.Height * 2;
                    //}
                    //else
                    //{
                        //gbOptions.Height = wb.Height;
                        gbOptions.Height = this.ClientRectangle.Height;
                    //}

                    gb.Left = wb.Left;
                    gb.Width = wb.Width;
                }
            }
            catch { }
        }
        public override void GotNavigate(GenericEvent e)
        {
            base.GotNavigate(e);

            if (Tools.Strings.HasString(e.Message, "viewcompany.rzl"))
            {
                String cid = Tools.Strings.ParseDelimit(e.Message, "=", 2);
                RzWin.Context.xSys.ThrowByKey(RzWin.Context, "company:" + cid);
                e.Handled = true;
            }
        }
        //Public Functions
        public void SetCaption(String s)
        {
            lblCaption.Text = s;
        }
        public String GetUserIDInString()
        {
            ArrayList a = GetUserIDCollection();
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (String s in a)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append("'" + s + "'");
                i++;
            }
            return sb.ToString();
        }
        public String GetUserNameInString()
        {
            ArrayList a = GetUserNameCollection();
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (String s in a)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append("'" + s + "'");
                i++;
            }
            return sb.ToString();
        }
        public Tools.Dates.DateRange GetDateRange()
        {
            return new Tools.Dates.DateRange(dtStart.GetValue_Date(), dtEnd.GetValue_Date());
        }
        public ArrayList GetUserNameCollection()
        {
            return RzWin.Logic.GetAgentTeamCollection(RzWin.Context, cboAgent.Text, true);
        }
        public ArrayList GetUserIDCollection_BlankIfAll()
        {
            switch (cboAgent.Text)
            {
                case "<all>":
                case "":
                    return new ArrayList();
                default:
                    return GetUserIDCollection();
            }
        }
        public ArrayList GetUserIDCollection()
        {
            return RzWin.Logic.GetAgentTeamCollection(RzWin.Context, cboAgent.Text, false);
        }
        public void SetOrderBy(String sorder, String strDefault)
        {
            lblOrderBy.Visible = true;
            cboOrderBy.Items.Clear();
            cboOrderBy.Visible = true;

            String[] ary = Tools.Strings.Split(sorder, "|");
            foreach (String s in ary)
            {
                cboOrderBy.Items.Add(s);
            }
            cboOrderBy.Text = strDefault;
        }
        public String GetOrderBy()
        {
            return cboOrderBy.Text;
        }
        public void SetUserName(String strName)
        {
            cboAgent.Text = "Agent: " + strName;
        }
        public void SetDateRange(Tools.Dates.DateRange dr)
        {
            dtStart.SetValue(dr.StartDate);
            dtEnd.SetValue(dr.EndDate);
        }
        public void HideOrderBy()
        {
            lblOrderBy.Visible = false;
            cboOrderBy.Visible = false;
        }
        //Buttons
        private void cmdView_Click(object sender, EventArgs e)
        {
            RunReport();
        }
        //Control Events
        private void cboAgent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!RzWin.User.SuperUser)
                e.Handled = true;
        }
        private void wb_OnNavigate(GenericEvent e)
        {
            if (zz_OnNavigate(e))
                e.Handled = true;
        }
    }
}

