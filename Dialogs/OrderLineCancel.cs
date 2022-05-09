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
    public partial class OrderLineCancel : ToolsWin.Dialogs.OKCancel
    {
        public static void Choose(OrderLineCancelArgs args)
        {
            OrderLineCancel c = new OrderLineCancel();
            c.Init(args);
            c.ShowDialog();

            try
            {
                c.Close();
                c.Dispose();
                c = null;
            }
            catch { }
        }

        OrderLineCancelArgs TheArgs;
        int NotPossibleCount = 0;
        public OrderLineCancel()
        {
            InitializeComponent();
        }

        public void Init(OrderLineCancelArgs args)
        {
            this.Icon = RzWin.Leader.TheMainForm.Icon;

            TheArgs = args;
            lblCaption.Text = "Cancel " + args.TheLine.ToString();
            lblStatus.Text = "";
            lblNotPossible.Text = "";

            OrderLineCancelStatus s = args.TheLine.CancelStatusGet(RzWin.Context);
            foreach (OrderLineCancelStatusEntry e in s.Entries)
            {
                if (e.CancelPossible)
                {
                    ListViewItem i = lv.Items.Add(e.TheOrder.ordernumber);
                    i.SubItems.Add(e.TheOrder.OrderType.ToString());
                    i.SubItems.Add(e.TheOrder.companyname);
                    i.SubItems.Add(Tools.Dates.DateFormat(e.TheOrder.orderdate));
                    i.Tag = e;
                    if (TheArgs.TypesToCancel.Contains(e.TheOrder.OrderType))
                        i.Checked = true;
                }
                else
                {
                    lblNotPossible.Text += e.TheOrder.ToString() + " (" + e.NotPossibleReason + ")\r\n";
                    NotPossibleCount++;
                }
            }

            CheckCheck();
        }

        void CheckCheck()
        {
            if (lv.CheckedItems.Count > 0)
            {
                //cmdOK.Enabled = true;

                if (lv.CheckedItems.Count == lv.Items.Count && NotPossibleCount == 0)
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = TheArgs.TheLine.ToString() + " will be deleted";
                }
            }
            else
            {
                //cmdOK.Enabled = false;
                lblStatus.Text = "";
            }
        }

        public override void Cancel()
        {
            TheArgs.TypesToCancel.Clear();
            TheArgs.OperationCanceled = true;
            base.Cancel();
        }

        public override void OK()
        {
            TheArgs.TypesToCancel.Clear();
            foreach (ListViewItem i in lv.CheckedItems)
            {
                try
                {
                    OrderLineCancelStatusEntry e = (OrderLineCancelStatusEntry)i.Tag;
                    TheArgs.TypesToCancel.Add(e.TheOrder.OrderType);
                }
                catch { }
            }

            TheArgs.OperationCanceled = false;
            base.OK();
        }

        private void lv_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            CheckCheck();
        }
    }
}
