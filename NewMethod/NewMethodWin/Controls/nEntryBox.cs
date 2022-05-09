using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class nEntryBox : System.Windows.Forms.TextBox
    {
        public event KeyPressEventHandler GetEnter;

        public nEntryBox()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogChar(char charCode)
        {
            if (charCode == 10 || charCode == 13)
            {
                if (GetEnter != null)
                    GetEnter(this, new KeyPressEventArgs(charCode));

                return true;
            }
            else
            {
                return base.ProcessDialogChar(charCode);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (GetEnter != null)
                    GetEnter(this, new KeyPressEventArgs('a'));

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            return base.ProcessKeyPreview(ref m);
        }

        protected override bool ProcessKeyMessage(ref Message m)
        {
            return base.ProcessKeyMessage(ref m);
        }

    }
}
