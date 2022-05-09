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
    public partial class ReportCriteriaControlString : ReportCriteriaControl
    {
        private ReportCriteriaString TheString
        {
            get
            {
                return (ReportCriteriaString)TheCriteria;
            }
        }
        public ReportCriteriaControlString()
        {
            InitializeComponent();
        }
        public override void Init(ReportCriteria c)
        {
            base.Init(c);

            loading = true;
            txtValue.Text = TheString.Value;
            loading = false;
        }

        bool loading = false;
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
                TheString.Value = txtValue.Text;
        }
    }
}
