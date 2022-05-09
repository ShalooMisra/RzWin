using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Tie
{
    public partial class View_Knot : UserControl
    {
        public TieKnot CurrentKnot;

        public View_Knot()
        {
            InitializeComponent();
        }

        public void SetKnot(TieKnot t)
        {
            CurrentKnot = t;
            CurrentKnot.SetStatus += new KnotStatusHandler(CurrentKnot_SetStatus);
        }

        void CurrentKnot_SetStatus(string status)
        {
            SetStatus(status);
        }

        public void SetStatus(String s)
        {
            if (InvokeRequired)
                Invoke(new SetStatusHandler(ActuallySetStatus), new object[] { s });
            else
                ActuallySetStatus(s);
        }

        private void ActuallySetStatus(String s)
        {
            try
            {
                txt.AppendText(s + "\n");
                txt.ScrollToCaret();
            }
            catch { }
        }

    }
}
