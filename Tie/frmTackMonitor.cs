using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tie
{
    public partial class frmTackMonitor : Form
    {
        public static void ShowTack(TieTack t)
        {
            frmTackMonitor xForm = new frmTackMonitor();
            xForm.Show();
            xForm.CompleteLoad(t);
        }

        public frmTackMonitor()
        {
            InitializeComponent();
        }

        public void CompleteLoad(TieTack t)
        {
            xMon.CompleteLoad(t);
        }
    }
}