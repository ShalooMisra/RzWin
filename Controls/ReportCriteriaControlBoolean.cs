using System;
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
    public partial class ReportCriteriaControlBoolean : ReportCriteriaControl
    {
        public ReportCriteriaControlBoolean()
        {
            InitializeComponent();
            lblCaption.Visible = false;
        }

        ReportCriteriaBoolean currentCritera;
        public override void Init(ReportCriteria c)
        {
            base.Init(c);
            currentCritera = (ReportCriteriaBoolean)c;
            chkValue.Checked = currentCritera.Value;
            chkValue.Text = currentCritera.Caption;
        }

        private void chkValue_Click(object sender, EventArgs e)
        {
            currentCritera.Value = chkValue.Checked;
        }
    }
}
