using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tie
{
    public partial class frmClientConnection : Form
    {
        public static void ShowClientConnection(ClientConnection c)
        {
            frmClientConnection xForm = new frmClientConnection();
            xForm.CompleteLoad(c);
            xForm.Show();
        }

        public frmClientConnection()
        {
            InitializeComponent();
        }

        public void CompleteLoad(ClientConnection c)
        {
            Text = c.GetSummaryName();
            xView.SetEnd(c);
        }
    }
}