using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethodx;

namespace Tie
{
    public partial class frmPinvitation : Form
    {
        public static String GetInvitationText(IWin32Window owner)
        {
            frmPinvitation p = new frmPinvitation();
            p.ShowDialog(owner);

            String s = p.InvitationText;
            try
            {
                p.Close();
                p.Dispose();
                p = null;
            }
            catch { }
            return s;
        }

        public String InvitationText;

        public frmPinvitation()
        {
            InitializeComponent();
        }

        private void lblPaste_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                txt.Text = Clipboard.GetText();
            }
            catch { }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            InvitationText = "";
            this.Hide();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            String s = txt.Text.Replace("\r", "").Replace("\n", "").Trim();
            if (!Tools.Strings.StrExt(s))
            {
                MessageBox.Show("Please past the invitation text in the box before continuing.");
                return;
            }

            InvitationText = txt.Text;
            this.Hide();
        }
    }
}