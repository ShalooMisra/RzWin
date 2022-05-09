using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5.Win.Controls
{
    public partial class ShippingScreenHalf : UserControl
    {
        Enums.OrderDirection TheDirection;

        public ShippingScreenHalf()
        {
            InitializeComponent();
        }

        public void Init(Enums.OrderDirection direction)
        {
            Init(direction, null);
        }

        public void Init(Enums.OrderDirection direction, Tools.Dates.DateRange range)
        {
            TheDirection = direction;
            switch (TheDirection)
            {
                case Enums.OrderDirection.Incoming:
                    chkInOut.Text = "Purchase Orders";
                    chkService.Text = "Service Orders Returning";
                    chkRMA.Text = "RMAs";
                    pic.BackgroundImage = il.Images["PutAway"];
                    break;
                default:
                    chkInOut.Text = "Sales";
                    chkService.Text = "Service Orders Leaving";
                    chkRMA.Text = "Vendor RMAs";
                    pic.BackgroundImage = il.Images["Ship"];                   
                    break;
            }

            Search(range);
            DoResize();
        }

        public void Search(Tools.Dates.DateRange range)
        {
            switch (TheDirection)
            {
                case Enums.OrderDirection.Incoming:
                    lv.Init(RzWin.Context.TheSysRz.TheOrderLogic.ShippingScreenArgsGetReceive(RzWin.Context, chkInOut.Checked, chkService.Checked, chkRMA.Checked, range));
                    break;
                default:
                    lv.Init(RzWin.Context.TheSysRz.TheOrderLogic.ShippingScreenArgsGetShip(RzWin.Context, chkInOut.Checked, chkService.Checked, chkRMA.Checked, range));
                    break;
            }
        }

        private void ShippingScreenHalf_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                int push = 0;

                if (TheDirection == Enums.OrderDirection.Incoming)
                    push = (this.ClientRectangle.Width / 4) * -1;
                else
                    push = (this.ClientRectangle.Width / 4);

                pTop.Left = ((this.ClientRectangle.Width / 2) - (pTop.Width / 2)) + push;
                pTop.Top = 0;

                lv.Left = 0;
                lv.Top = pTop.Bottom + 6;
                lv.Height = this.ClientRectangle.Height - lv.Top;
                lv.Width = this.ClientRectangle.Width;
            }
            catch { }
        }

        private void lv_AboutToThrow(Context x, ShowArgs args)
        {
            args.Handled = true;

            ShowArgsOrder show_args = null;
            foreach (orddet_line l in args.TheItems.AllGet(x))
            {
                switch (l.Status)
                {
                    case Enums.OrderLineStatus.Buy:
                        show_args = new ShowArgsOrder(x, l, Enums.OrderType.Purchase);
                        break;
                    case Enums.OrderLineStatus.Packing:
                        show_args = new ShowArgsOrder(x, l, Enums.OrderType.Invoice);
                        break;
                    case Enums.OrderLineStatus.Packing_For_Service:
                    case Enums.OrderLineStatus.Out_For_Service:
                        show_args = new ShowArgsOrder(x, l, Enums.OrderType.Service);
                        break;
                    case Enums.OrderLineStatus.RMA_Receiving:
                        show_args = new ShowArgsOrder(x, l, Enums.OrderType.RMA);
                        break;
                    case Enums.OrderLineStatus.Vendor_RMA_Packing:
                        show_args = new ShowArgsOrder(x, l, Enums.OrderType.VendRMA);
                        break;
                    default:
                        show_args = new ShowArgsOrder(x, l, Enums.OrderType.Sales);
                        break;
                }
            }

            RzWin.Context.Show(show_args);
        }
    }
}
