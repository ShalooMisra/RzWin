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
    public partial class frmNewPassword : Form
    {
        public event GotInfoHandler GotInfo;

        public frmNewPassword()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void DoOK()
        {
            if (!CheckEnabled())
                return;

            if( GotInfo != null )
            {
                GotInfo(this, new GotInfoArgs(txtOld.Text, txtNewPassword.Text));
            }
        }

        private void frmNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(Convert.ToInt32(e.KeyChar))
            {
            case 32:
                e.Handled = true;
                this.Close();
                break;
            case 13:
                e.Handled = true;
                DoOK();
                break;
            }
        }

        private bool CheckEnabled()
        {
            if (!Tools.Strings.StrExt(txtNewPassword.Text))
                return false;

            if (!Tools.Strings.StrCmp(txtNewPassword.Text, txtConfirm.Text))
                return false;

            return true;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            DoOK();
        }

        public void SetOnMouse()
        {
            this.Top = (System.Windows.Forms.Cursor.Position.Y - this.Height);
            this.Left = (System.Windows.Forms.Cursor.Position.X - (this.Width / 2));
        }

        private void frmNewPassword_Load(object sender, EventArgs e)
        {

        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = CheckEnabled();
        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = CheckEnabled();
        }
    }


    public class GotInfoArgs
    {
        public string OldPassword = "";
        public string NewPassword = "";

        public GotInfoArgs(String s_old, String s_new)
        {
            OldPassword = s_old;
            NewPassword = s_new;
        }
    }

    public delegate void GotInfoHandler(Object sender, GotInfoArgs args);

}