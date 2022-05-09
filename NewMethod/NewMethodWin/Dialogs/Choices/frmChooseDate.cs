using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace NewMethod
{
    public partial class frmChooseDate : Form
    {
        private bool SetPosition = true;
        private bool do_drop = true;

        public static DateTime ChooseDate(DateTime dtStart, String strCaption, System.Windows.Forms.IWin32Window owner)
        {
            frmChooseDate xForm = new frmChooseDate();
            xForm.CompleteLoad(dtStart, strCaption);
            xForm.ShowDialog(owner);
            return xForm.SelectedDate;
        }

        public DateTime SelectedDate;

        public frmChooseDate()
        {
            InitializeComponent();
        }

        public void CompleteLoad(DateTime dtStart, String strCaption)
        {
            dt.Value = dtStart;
            lblCaption.Text = strCaption;
        }

        private void frmChooseDate_Activated(object sender, EventArgs e)
        {
            if (!SetPosition)
                return;

            SetPosition = false;
            ToolsWin.Screens.SetOnMouse(this);

            if (do_drop)
            {
                do_drop = false;
                //this is supposed to drop the list
                //it works, but the call doesn't return until the form is closed
                //isn't there a timeout for sendmessage?
                //SendMessage(dt.Handle, 0x100, 0x73, 0x3E0001);
            }
        }

        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, int lParam);

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedDate = Tools.Dates.GetNullDate();
            this.Hide();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            ClickOK();
        }

        private void ClickOK()
        {
            SelectedDate = dt.Value;
            this.Hide();
        }

        private void dt_ValueChanged(object sender, EventArgs e)
        {
            //this gets kicked off when the month or year is scrolled
            //ClickOK();
        }

        private void lblCaption_Click(object sender, EventArgs e)
        {

        }
    }
}