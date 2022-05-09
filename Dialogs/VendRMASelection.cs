using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Win.Dialogs
{
    public partial class VendRMASelection : ToolsWin.Dialogs.OKCancel
    {
        public static RMASelectionResult Select(RMASelectionArgs args)
        {
            VendRMASelection s = new VendRMASelection();
            s.Init(args);
            s.ShowDialog();
            RMASelectionResult r = s.TheResult;

            try
            {
                s.Close();
                s.Dispose();
                s = null;
            }
            catch { }

            return r;
        }

        public RMASelectionResult TheResult = new RMASelectionResult();
        public VendRMASelection()
        {
            InitializeComponent();
        }

        int maxQuantity;
        public void Init(RMASelectionArgs args)
        {
            base.Init();
            txtQuantity.Text = args.Quantity.ToString();
            maxQuantity = args.Quantity;
            txtQuantity.Enabled = args.QuantityEnabled;
            chkVRMA.Checked = true;
            chkVRMA.Enabled = false;
            gbVRMA.Visible = true;
            of.Init(Enums.OrderType.VendRMA);
            ScreenRefresh();
        }

        public override void Cancel()
        {
            TheResult.Cancel = true;
            base.Cancel();
        }

        public override void OK()
        {
            if (!Tools.Number.IsNumeric(txtQuantity.Text))
            {
                RzWin.Context.TheLeader.Tell("Please enter a valid quantity");
                return;
            }

            if (Int32.Parse(txtQuantity.Text) <= 0)
            {
                RzWin.Context.TheLeader.Tell("Please enter a valid quantity");
                return;
            }

            if (Int32.Parse(txtQuantity.Text) > maxQuantity)
            {
                RzWin.Context.TheLeader.Tell("The maximum quantity is " + Tools.Number.LongFormat(maxQuantity));
                return;
            }

            TheResult.NewRMA = false;
            TheResult.TheRMA = null;

            if (chkVRMA.Checked)
            {
                TheResult.DoVRMA = true;
                if (optUseVRMA.Checked)
                {
                    of.OrderUpdate();
                    if (of.OrderCurrent == null)
                    {
                        RzWin.Context.TheLeader.Tell("Please enter a valid VRMA number");
                        return;
                    }
                    TheResult.TheVRMA = (ordhed_vendrma)of.OrderCurrent;
                    TheResult.NewVRMA = false;
                }
                else
                {
                    TheResult.NewVRMA = true;
                    TheResult.TheVRMA = null;
                }
            }
            else
                TheResult.DoVRMA = false;

            try
            {
                TheResult.Quantity = Int32.Parse(txtQuantity.Text);
            }
            catch { }

            TheResult.DoVendorReplacement = chkReplacement.Checked;
            base.OK();
        }

        private void optNewRMA_Click(object sender, EventArgs e)
        {
            ScreenRefresh();
        }

        public void ScreenRefresh()
        {
            try
            {
                of.Visible = optUseVRMA.Checked;
            }
            catch { }
        }

        private void optNewVRMA_Click(object sender, EventArgs e)
        {
            ScreenRefresh();
        }

        private void optUseVRMA_Click(object sender, EventArgs e)
        {
            ScreenRefresh();
        }
    }
}
