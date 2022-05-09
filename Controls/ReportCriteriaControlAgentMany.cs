using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5.Win.Controls;
using Core;
using Rz5;
using System.Collections;
using NewMethod;

namespace RzInterfaceWin
{
    public partial class ReportCriteriaControlAgentMany : ReportCriteriaControl
    {
        //Private Variables
        private ReportCriteriaAgentMany AgentCriteria
        {
            get
            {
                return (ReportCriteriaAgentMany)TheCriteria;
            }
        }
        private ArrayList Agents = new ArrayList();

        //Constructors
        public ReportCriteriaControlAgentMany()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void Init(ReportCriteria c)
        {
            base.Init(c);
            ShowAgents();
        }
        //Private Functions
        private void ShowAgents()
        {
            if (Agents.Count == 0)
                lblChooseAgents.Text = "<click to choose>";
            else if (Agents.Count == 1)
                lblChooseAgents.Text = (String)Agents[0];
            else
                lblChooseAgents.Text = (String)Agents[0] + " +" + Convert.ToInt32(Agents.Count - 1).ToString();
        }
        private List<string> GetAsIDs()
        {
            List<string> l = new List<string>();
            foreach (string s in Agents)
            {
                NewMethod.n_user u = n_user.GetByName(RzWin.Context, s);
                if (u != null)
                    l.Add(u.unique_id);
            }
            return l;
        }
        //Control Events
        private void lblClearAgents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AgentCriteria.AgentIds = new List<string>();
            Agents = new ArrayList();
            ShowAgents();
        }
        private void lblChooseAgents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Agents = frmChooseUser_Multiple.Choose(RzWin.Logic.SalesPeople, "Agent Selection", null);
            AgentCriteria.AgentIds = GetAsIDs();
            ShowAgents();
        }
    }
}
