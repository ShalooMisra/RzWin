using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;

namespace ToolsWin.Dialogs
{
    public partial class Ask : ToolsWin.Dialogs.OKCancel
    {
        public static String AskString(String strPrompt)
        {
            return AskString(false, strPrompt, "", strPrompt);
        }

        public static String AskString(bool multi_line, String strPrompt, String strDefault, String strCaption)
        {
            return AskString(multi_line, strPrompt, strDefault, strCaption, null);
        }

        public static String AskString(bool multi_line, String strPrompt, String strDefault, String strCaption, System.Windows.Forms.IWin32Window owner)
        {
            return AskString(multi_line, strPrompt, strDefault, strCaption, owner, false);
        }

        public static String AskString(bool multi_line, String strPrompt, String strDefault, String strCaption, System.Windows.Forms.IWin32Window owner, bool password)
        {
            Ask f = new Ask();
            f.Init();
            f.SetPrompt(strPrompt);
            f.SetText(strDefault);
            f.SetCaption(strCaption);

            if (multi_line)
            {
                f.SetMultiLine();
                f.CloseOnEnter = false;
            }
            else
            {
                f.CloseOnEnter = true;
            }

            if (password)
                f.PasswordSet();
                        
            f.ShowDialog(owner);
            return f.ReturnString;
        }

        public String ReturnString;

        public bool CloseOnEnter = false;
        public bool MultiLine = false;
        public Ask()
        {
            InitializeComponent();
            txtInput.Focus();
        }

        public void SetMultiLine()
        {
            CloseOnEnter = false;
            MultiLine = true;

            txtInput.Visible = false;
            txtInputMulti.Visible = true;

            //txtInput.ScrollBars = ScrollBars.Both;
            //txtInput.WordWrap = false;
            this.Height = 400;
            DoResize();

            txtInput.Text = "";
            txtInputMulti.Text = TheText;
            txtInputMulti.Focus();
        }

        public override void OK()
        {
            if (MultiLine)
                this.ReturnString = txtInputMulti.Text.Replace("\r\n", "\n").Replace("\n", "\r\n");  //collapse rn to n, then expand all n to rn
            else
                this.ReturnString = txtInput.Text;

            base.OK();
        }

        public override void Cancel()
        {
            this.ReturnString = "";
            base.Cancel();
        }

        String TheText = "";
        public void SetText(String s)
        {
            TheText = s;
            if (MultiLine)
            {
                txtInputMulti.Text = s;
                txtInputMulti.Focus();
            }
            else
            {
                txtInput.Text = s;
                txtInput.Focus();
            }
        }

        public void PasswordSet()
        {
            //txtInput.UseSystemPasswordChar = true;
            txtInput.PasswordChar = '*';
        }

        public void SetPrompt(String s)
        {
            lblPrompt.Text = s;
        }

        public void SetCaption(String s)
        {
            this.Text = s;
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CloseOnEnter)
            {
                if (e.KeyChar == 10 || e.KeyChar == 13)
                {
                    OK();
                }
            }
        }

        private void frmAsk_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        

        public override void DoResize()
        {
            base.DoResize();

            try
            {
                if (MultiLine)
                {
                    txtInputMulti.Height = pContents.ClientRectangle.Height - txtInputMulti.Top;
                    txtInputMulti.Width = pContents.ClientRectangle.Width - (txtInputMulti.Left * 2);
                }
                else
                {
                    txtInput.Height = pContents.ClientRectangle.Height - txtInput.Top;
                    txtInput.Width = pContents.ClientRectangle.Width - (txtInput.Left * 2);
                }
            }
            catch { }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (MultiLine)
                return;

            String s = txtInput.Text;
            if (s.Contains("\r") || s.Contains("\n"))
            {
                String[] ary = Tools.Strings.SplitLines(s);
                foreach (String line in ary)
                {
                    if (Tools.Strings.StrExt(line))
                    {
                        txtInput.Text = line;
                        return;
                    }
                }
            }
        }

        public override void FocusSet()
        {
            base.FocusSet();
            if (MultiLine)
                txtInputMulti.Focus();
            else
                txtInput.Focus();
        }
    }
}