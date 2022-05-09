using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rz5.Win.Dialogs
{
    public partial class RFQChooser : ToolsWin.Dialogs.OKCancel
    {
        public static orddet_rfq Choose(String partNumber)
        {
            RFQChooser c = new RFQChooser();
            c.Init(partNumber);
            c.ShowDialog();
            orddet_rfq ret = c.Result;
            try
            {
                c.Close();
                c.Dispose();
                c = null;
            }
            catch { }
            return ret;
        }

        public Rz5.orddet_rfq Result;

        public RFQChooser()
        {
            InitializeComponent();
        }

        public void Init(String part)
        {
            txtPartNumber.Text = part;
            lvResult.Init(RzWin.Context.TheSysRz.TheQuoteLogic.QuoteSearchArgsGet(RzWin.Context, Enums.PartSearchType.Quotes_Receiving, SearchComparison.Normal, new PartSearchParameters(part), true));
        }

        public override void Cancel()
        {
            Result = null;
            base.Cancel();
        }

        public override void OK()
        {
            Result = (Rz5.orddet_rfq)lvResult.GetSelectedObject();
            if (Result == null)
            {
                
                RzWin.Context.TheLeader.Error("Please choose an RFQ before continuing");
                return;
            }
            base.OK();
        }

        private void lvResult_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;
            Result = (Rz5.orddet_rfq)args.TheItems.FirstGet(RzWin.Context);
            OK();
        }

        public override void DoResize()
        {
            base.DoResize();

            try
            {
                lvResult.Left = 0;
                lvResult.Width = pContents.ClientRectangle.Width;
                lvResult.Height = pContents.ClientRectangle.Height - lvResult.Top;
            }
            catch { }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            lvResult.Init(RzWin.Context.TheSysRz.TheQuoteLogic.QuoteSearchArgsGet(RzWin.Context, Enums.PartSearchType.Bids, SearchComparison.Normal, new PartSearchParameters(txtPartNumber.Text), true));
        }
    }
}
