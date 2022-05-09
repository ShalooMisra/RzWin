using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ToolsWin;

namespace ToolsWin.Dialogs
{
    public partial class Paste : ToolsWin.Dialogs.OKCancel
    {
        public static String AskForPaste()
        {
            ToolsWin.Dialogs.Paste f = new ToolsWin.Dialogs.Paste();
            f.SetTextFromClipboard();
            f.ShowDialog();
            return f.ReturnString;
        }

        public String ReturnString;

        public Paste()
        {
            InitializeComponent();
            txtPaste.Focus();
        }

        public override void Cancel()
        {
            ReturnString = "";
            base.Cancel();
        }

        public override void OK()
        {
            ReturnString = txtPaste.Text;
            base.OK();
        }

        public void SetTextFromClipboard()
        {
            txtPaste.Text = System.Windows.Forms.Clipboard.GetText();
        }

        public void SetText(String s)
        {
            txtPaste.Text = s;
        }
    }
}