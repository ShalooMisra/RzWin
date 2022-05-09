using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public class nStatusBox : RichTextBox
    {
        public new void AppendText(String s)
        {
            try
            {
                if (InvokeRequired)
                    Invoke(new SetStatusDelegate(ActuallyAppendText), new object[] { s });
                else
                    ActuallyAppendText(s);
            }
            catch { }
        }

        private void ActuallyAppendText(String s)
        {
            base.AppendText(s);
            if (Text.Length > 50000)
            {
                Text = Text.Substring(0, 20000);
            }
        }

        public void AddLine(String s)
        {
            AppendText(s + "\n");
        }
    }
}
