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
    public partial class OrderSelection : ToolsWin.Dialogs.OKCancel
    {
        public static void Select(MakeOrderArgs args)
        {
            OrderSelection s = new OrderSelection();
            s.Init(args);
            s.ShowDialog();

            try
            {
                s.Close();
                s.Dispose();
                s = null;
            }
            catch { }
        }

        public MakeOrderArgs TheArgs;
        public OrderSelection()
        {
            InitializeComponent();
        }

        public void Init(MakeOrderArgs args)
        {
            base.Init();
            TheArgs = args;
            this.Text = RzLogic.GetFriendlyOrderType(TheArgs.TheType) + " Selection";
            optNew.Text = "Make A New " + RzLogic.GetFriendlyOrderType(TheArgs.TheType);
            optUse.Text = "Use An Existing " + RzLogic.GetFriendlyOrderType(TheArgs.TheType);
            of.Init(TheArgs.TheType);
            ScreenRefresh();
        }

        public override void Cancel()
        {
            TheArgs.Canceled = true;
            base.Cancel();
        }

        public override void OK()
        {
            if (optUse.Checked)
            {
                of.OrderUpdate();
                if (of.OrderCurrent == null)
                {
                    RzWin.Context.TheLeader.Tell("Please enter a valid " + RzLogic.GetFriendlyOrderType(TheArgs.TheType) + " number");
                    return;
                }
                TheArgs.UseOrder = of.OrderCurrent;
                TheArgs.NewOrder = false;
            }
            else
            {
                TheArgs.UseOrder = null;
                TheArgs.NewOrder = true;
            }

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
                of.Visible = optUse.Checked;
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
