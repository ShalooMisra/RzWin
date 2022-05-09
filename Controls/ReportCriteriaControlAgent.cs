using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;

namespace Rz5.Win.Controls
{
    public partial class ReportCriteriaControlAgent : ReportCriteriaControl
    {
        //Private Variables
        private ReportCriteriaAgent AgentCriteria
        {
            get
            {
                return (ReportCriteriaAgent)TheCriteria;
            }
        }
        
        //Constructors
        public ReportCriteriaControlAgent()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void Init(ReportCriteria c)
        {
            base.Init(c);

            cboAgent.Items.Clear();

            String defaultValue = "";
            foreach (String s in RzWin.Context.TheSysRz.TheUserLogicRz.AgentOptionsListSales(RzWin.Context, true, ref defaultValue))
            {
                cboAgent.Items.Add(s);
            }

            cboAgent.Text = defaultValue;
            SetCriteria();
        }
        protected void SetCriteria()
        {
            AgentCriteria.AgentIds = RzWin.Context.TheSysRz.TheUserLogicRz.AgentIdsList(RzWin.Context, cboAgent.Text);
        }
        //Control Events 
        private void cboAgent_SelectedValueChanged(object sender, EventArgs e)
        {
            SetCriteria();
        }    
    }
}
