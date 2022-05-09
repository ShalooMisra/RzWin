using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Core;

namespace Rz5.Win.Controls
{
    public partial class OrderFinder : UserControl
    {
        public Enums.OrderType TheType;

        public OrderFinder()
        {
            InitializeComponent();
            lblSummary.Text = "";
        }

        public void Init(Enums.OrderType type)
        {
            TheType = type;
            lblCaption.Text = RzLogic.GetFriendlyOrderType(TheType) + "#";
        }

        public ordhed_new OrderCurrent;
        private void tmrVRMA_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            OrderUpdate();
        }

        public event EventHandler OrderFound;
        public void OrderUpdate()
        {
            ordhed_new tempOrder = (Rz5.ordhed_new)RzWin.Context.QtO("ordhed_" + TheType.ToString().ToLower(), "select * from ordhed_" + TheType.ToString().ToLower() + " where ordernumber = '" + RzWin.Context.Filter(txtNumber.Text) + "'");
            if (tempOrder == null)
            {
                tempOrder = (Rz5.ordhed_new)RzWin.Context.QtO("ordhed_" + TheType.ToString().ToLower(), "select * from ordhed_" + TheType.ToString().ToLower() + " where ordernumber = '" + RzWin.Context.Filter(RzWin.Context.TheSysRz.TheOrderLogic.PadOrderNumber(RzWin.Context, txtNumber.Text)) + "'");
                if (tempOrder == null)
                {
                    OrderCurrent = null;
                    lblSummary.Text = "";
                    return;
                }
            }

            //try to get the instance that's already on the screen, if possible
            OrderCurrent = (ordhed_new)RzWin.Context.TheLeader.ItemShownByTag(RzWin.Context, new ItemTag(tempOrder));
            if (OrderCurrent == null)
                OrderCurrent = tempOrder;

            lblSummary.Text = RzLogic.GetFriendlyOrderType(TheType) + " " + OrderCurrent.ordernumber + "\r\n" + Tools.Dates.DateFormat(OrderCurrent.orderdate) + "  -  " + OrderCurrent.companyname;
            if (OrderFound != null)
                OrderFound(null, null);
        }

        private void txtVRMA_TextChanged(object sender, EventArgs e)
        {
            tmr.Stop();
            tmr.Start();
        }

    }
}
