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
    public partial class RMASelection : ToolsWin.Dialogs.OKCancel
    {
        public static RMASelectionResult Select(RMASelectionArgs args)
        {
            RMASelection s = new RMASelection();
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
        public RMASelection()
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
            ofRMA.Init(Enums.OrderType.RMA);
            ofVendRMA.Init(Enums.OrderType.VendRMA);
            ScreenRefresh();
        }

        public override void Cancel()
        {
            TheResult.Cancel = true;
            base.Cancel();
        }

        public override void OK()
        {
            bool isIHS = false;
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

            if (optUseRMA.Checked)
            {
                ofRMA.OrderUpdate();
                if (ofRMA.OrderCurrent == null)
                {
                    RzWin.Context.TheLeader.Tell("Please enter a valid RMA number");
                    return;
                }
                TheResult.TheRMA = (ordhed_rma)ofRMA.OrderCurrent;
                TheResult.NewRMA = false;
            }
            else
            {
                TheResult.NewRMA = true;
                TheResult.TheRMA = null;
            }

            if (chkVRMA.Checked)
            {
                TheResult.DoVRMA = true;
                if (optUseVRMA.Checked)
                {
                    ofVendRMA.OrderUpdate();
                    if (ofVendRMA.OrderCurrent == null)
                    {
                        RzWin.Context.TheLeader.Tell("Please enter a valid VRMA number");
                        return;
                    }
                    TheResult.TheVRMA = (ordhed_vendrma)ofVendRMA.OrderCurrent;
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



            if (optReplacementRMA.Checked)
            {
                if (RzWin.Leader.AskYesNo("Are we performing in-house services for this order, such as re-baking?"))
                {
                    isIHS = true;

                    if (chkVRMA.Checked)
                    {
                        RzWin.Leader.Tell("Sorry, at this time it is not possible to schedule a line for RMA IHS and also schedule a Vendor replacement for that line.  Please create a separate RMA / Vendor rma for the QTY that is going back to the vendor.  If this poses an issuse, please see management for resolution.");
                        chkVRMA.Checked = false;
                        ScreenRefresh();
                        return;
                    }
                    else
                    {
                        TheResult.InHouseService = true;
                    }
                }


            }

            TheResult.DoCustomerReplacement = optReplacementRMA.Checked;

            //If not Vendor RMA ask if going into stock


            //if (isIHS)
            //    TheResult.DoCustomerReplacement = false;
            //else
            //    TheResult.DoCustomerReplacement = optReplacementRMA.Checked;
            TheResult.DoVendorReplacement = optReplacementVendor.Checked;
            TheResult.UseVendorReplacementForCustomer = chkUseVendorReplacement.Checked;

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
                gbVRMA.Visible = chkVRMA.Checked;

                ofRMA.Visible = optUseRMA.Checked;
                ofVendRMA.Visible = optUseVRMA.Checked;

                chkUseVendorReplacement.Visible = optReplacementRMA.Checked && optReplacementVendor.Checked;
            }
            catch { }
        }

        private void chkVRMA_Click(object sender, EventArgs e)
        {
            ScreenRefresh();
        }

        private void chkReplacement_Click(object sender, EventArgs e)
        {
            ScreenRefresh();
        }

        private void optNewVRMA_Click(object sender, EventArgs e)
        {
            ScreenRefresh();
        }

        private void optUseVRMA_Click(object sender, EventArgs e)
        {
            ScreenRefresh();
        }

        private void optUseRMA_Click(object sender, EventArgs e)
        {
            ScreenRefresh();
        }

        private void optCreditVendRMA_CheckedChanged(object sender, EventArgs e)
        {
            ScreenRefresh();
        }

        private void optReplacementVendor_CheckedChanged(object sender, EventArgs e)
        {
            ScreenRefresh();
        }

        private void optCreditRMA_CheckedChanged(object sender, EventArgs e)
        {
            ScreenRefresh();
        }

        private void optReplacementRMA_CheckedChanged(object sender, EventArgs e)
        {
            ScreenRefresh();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ScreenRefresh();
        }
    }
}
