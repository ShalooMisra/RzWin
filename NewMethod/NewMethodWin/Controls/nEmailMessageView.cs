using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;

namespace NewMethod
{
    public partial class nEmailMessageView : UserControl
    {
        public nEmailMessage xMessage;

        public nEmailMessageView()
        {
            InitializeComponent();
        }

        public void CompleteLoad(nEmailMessage m)
        {
            xMessage = m;

            lblToAddress.Text = "To Address: " + m.ToAddress;
            lblToName.Text = "To Name: " + m.ToName;

            lblFromAddress.Text = "From Address: " + m.FromAddress;
            lblFromName.Text = "From Name: " + m.FromName;

            lblServerName.Text = "Server Name: " + m.ServerName;
            lblServerPort.Text = "Server Port: " + m.ServerPort.ToString();
            lblUserName.Text = "User Name: " + m.ServerUserName;

            txtSubject.Text = m.Subject;

            wb.ReloadWB();
            wb.Add(m.HTMLBody);
        }

    }
}
