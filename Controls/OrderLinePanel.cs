using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rz5.Win.Controls
{
    public partial class OrderLinePanel : UserControl
    {
        public orddet_line TheLine;
        public Enums.OrderType TheType;

        public OrderLinePanel()
        {
            InitializeComponent();
        }

        public void Init(orddet_line line, Enums.OrderType type)
        {
            TheLine = line;
            TheType = type;

            lblType.Text = RzLogic.GetFriendlyOrderType(TheType);

            TheOrder = (ordhed_new)TheLine.OrderObjectGet(RzWin.Context, TheType);
            if (TheOrder == null)
            {
                optNone.Checked = true;
                pOrder.Visible = false;
            }
            else
            {
                optOrder.Checked = true;
                pOrder.Visible = true;
                txtOrder.Text = TheOrder.ordernumber;
                Preview();
            }
        }

        private void txtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            tmr.Stop();

            if( optOrder.Checked )
                tmr.Start();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (bg.IsBusy)
                return;

            tmr.Stop();
            bg.RunWorkerAsync();
        }

        public ordhed_new TheOrder = null;
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            TheOrder = (ordhed_new)ordhed.GetByNumberAndType(RzWin.Context, txtOrder.Text, TheType);
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (TheOrder == null)
            {
                lblPreview.Text = "Not Found: " + txtOrder.Text;
            }
            else
            {
                Preview();
            }
        }

        void Preview()
        {
            lblPreview.Text = TheOrder.ToString() + "\r\n" + TheOrder.companyname + "\r\n" + Tools.Dates.DateFormat(TheOrder.orderdate);
        }

        private void optNone_Click(object sender, EventArgs e)
        {
            if (optNone.Checked)
            {
                pOrder.Visible = false;
                TheOrder = null;
            }
            else
            {
                pOrder.Visible = true;
            }
        }

        public bool Valid
        {
            get
            {
                return (optNone.Checked || (TheOrder != null));
            }
        }

        public bool None
        {
            get
            {
                return optNone.Checked;
            }
        }

        public void Apply()
        {
            if (optNone.Checked)
                TheLine.OrderObjectClear(RzWin.Context, TheType);
            else
            {
                ordhed_new n = (ordhed_new)TheLine.OrderObjectGet(RzWin.Context, TheType);
                if( n.unique_id != TheOrder.unique_id)
                {
                    n.DetailsVar.RefsRemove(RzWin.Context, TheLine);
                    n.Update(RzWin.Context);

                    TheOrder.DetailsVar.RefsAdd(RzWin.Context, TheLine);
                    TheOrder.Update(RzWin.Context);

                    TheLine.Update(RzWin.Context);
                }
            }

        }
    }
}
