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
    public partial class ReportCriteriaControl : UserControl
    {
        public event EventHandler ValueChanged;
        public ReportCriteria TheCriteria;

        public ReportCriteriaControl()
        {
            InitializeComponent();
        }

        public virtual void Init(ReportCriteria c)
        {
            TheCriteria = c;
            lblCaption.Text = c.Caption;
        }

        protected void ValueChangedFire()
        {
            if (ValueChanged != null)
                ValueChanged(TheCriteria, null);
        }

        private void ReportCriteriaControl_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        protected virtual void DoResize()
        {
            picTop.Width = this.ClientRectangle.Width - picTop.Left;
        }
    }
}
