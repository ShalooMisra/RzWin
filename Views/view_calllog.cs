using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class view_calllog :  ViewPlusMenu
    {
        //Constructors
        public view_calllog()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void CompleteLoad()
        {
            ctl_callresult.LoadList(true);
            ctl_responsetype.LoadList(true);
            base.CompleteLoad();
        }
        protected override void DoResize()
        {
            try
            {
                base.DoResize();
                ctl_callresult.Width = (xActions.Left - ctl_callresult.Left) - 5;
                ctl_callorder.Left = ctl_callresult.Right - ctl_callorder.Width;
                ctl_responsetype.Width = (ctl_callorder.Left - ctl_responsetype.Left) - 5;
                ctl_callnotes.Width = ctl_callresult.Width;
                ctl_callnotes.Height = (this.ClientRectangle.Height - ctl_callnotes.Top) - 5;
            }
            catch { }
        }
        //Control Events
        private void view_calllog_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}

