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
    public partial class view_addresshandler : ViewPlusMenu
    {
        public view_addresshandler()
        {
            InitializeComponent();
        }
        //Public Override Functions
        protected override void DoResize()
        {
            try
            {
                base.DoResize();
                ctl_emailaddress.Width = (ctl_emailaddress.Left) - 10;  //xMenu.Left - 
                ctl_description.Width = ctl_emailaddress.Width;
                ctl_handlertags.Width = ctl_emailaddress.Width;
                ctl_sourcedest.Width = ctl_emailaddress.Width;
                ts.Left = ctl_sourcedest.Left;
                ts.Width = ctl_emailaddress.Width;
                ts.Height = (this.ClientRectangle.Height - ts.Top) - 2;
                ctl_companystop.Top = (tabCompany.Height - ctl_companystop.Height) - 2;
                ctl_companystop.Width = (tabCompany.Width - ctl_companystop.Left) - 2;
                ctl_contactstop.Top = ctl_companystop.Top;
                ctl_contactstop.Width = ctl_companystop.Width;
                ctl_phonestop.Top = ctl_companystop.Top;
                ctl_phonestop.Width = ctl_companystop.Width;
                ctl_faxstop.Top = ctl_companystop.Top;
                ctl_faxstop.Width = ctl_companystop.Width;
                ctl_companymap.Width = ctl_companystop.Width;
                ctl_companymap.Height = (ctl_companystop.Top - ctl_companymap.Top) - 2;
                ctl_contactmap.Width = ctl_companystop.Width;
                ctl_contactmap.Height = ctl_companymap.Height;
                ctl_phonemap.Width = ctl_companystop.Width;
                ctl_phonemap.Height = ctl_companymap.Height;
                ctl_faxmap.Width = ctl_companystop.Width;
                ctl_faxmap.Height = ctl_companymap.Height;
            }
            catch (Exception)
            { }
        }
        //Control Events
        private void view_addresshandler_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

    }
}
