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
    public partial class ReportCriteriaControlRadio : ReportCriteriaControl
    {
        public ReportCriteriaControlRadio()
        {
            InitializeComponent();
        }

        ReportCriteriaRadio currentCritera;
        public override void Init(ReportCriteria c)
        {
            base.Init(c);
            currentCritera = (ReportCriteriaRadio)c;
            cboList.Items.Clear();
            foreach (String s in currentCritera.ValueCaptions)
            {
                cboList.Items.Add(s);
            }
            cboList.Text = currentCritera.SelectedCaption;
        }

        private void cboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCritera.SelectedCaption = cboList.Text;
        }
    }
}
