using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmEditQuoteOption : Form
    {
        //Private Variables
        private ContextNM TheContext;
        private orddet_quote TheQuote;
        private ReqLine TheLine;

        //Constructors
        public frmEditQuoteOption()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad(ContextNM x, orddet_quote q)
        {
            if (x == null)
                return false;
            TheContext = x;
            if (q == null)
                return false;
            TheQuote = q;
            TheLine = (ReqLine)((LeaderWinUserRz)TheContext.TheLeader).GetReqLine();
            if (TheLine == null)
                return false;
            TheLine.CloseRequest += new nLineHandler(TheLine_CloseRequest);
            TheLine.CompleteLoad(q, null, false);
            this.Controls.Add(TheLine);
            TheLine.Dock = DockStyle.Fill;
            return true;
        }
        //Protected Functions
        protected void CompleteDispose()
        {
            if (TheLine == null)
                return;
            TheLine.CloseRequest -= new nLineHandler(TheLine_CloseRequest);    
        }
        //Control Events
        private void TheLine_CloseRequest(nLine l, nObject xObject, bool delete)
        {
            Close();
        }
    }
}
