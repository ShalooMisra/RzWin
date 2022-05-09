using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class frmOrderSelection : Form
    {
        public static void Choose(ref String strType, ref String strOrder)
        {
            frmOrderSelection xForm = new frmOrderSelection();
            xForm.ShowDialog();

            strType = xForm.SelectedType;
            strOrder = xForm.SelectedNumber;

            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }
        }

        public static ordhed Choose(System.Windows.Forms.IWin32Window owner)
        {
            frmOrderSelection xForm = new frmOrderSelection();
            xForm.ShowDialog(owner);

            return ordhed.GetByNumberAndType(RzWin.Context, xForm.SelectedNumber, xForm.SelectedType);
        }

        public String SelectedType = "";
        public String SelectedNumber = "";

        public frmOrderSelection()
        {
            InitializeComponent();
            CheckOrderInfo();
        }

        private void frmOrderSelection_Activated(object sender, EventArgs e)
        {
            ToolsWin.Screens.SetOnMouse(this);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedType = "";
            SelectedNumber = "";
            this.Hide();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!Tools.Strings.StrExt(cboOrderType.Text))
            {
                RzWin.Leader.Tell("Please choose an order type");
                return;
            }

            if (!Tools.Strings.StrExt(txtOrderNumber.Text))
            {
                RzWin.Leader.Tell("Please enter an order number.");
                return;
            }

            SelectedType = cboOrderType.Text;
            SelectedNumber = txtOrderNumber.Text;
            this.Close();
        }

        void CheckOrderInfo()
        {
            ordhed o = null;

            if (txtOrderNumber.Text.Length == RzWin.Context.Sys.TheOrderLogic.OrderNumberLengthGet(RzWin.Context) && Tools.Strings.StrExt(cboOrderType.Text))
            {
                o = ordhed.GetByNumberAndType(RzWin.Context, txtOrderNumber.Text, cboOrderType.Text);
            }

            if (o == null)
            {
                lblOrder.Text = "<no order found yet>";
                lblOrder.ForeColor = Color.Gray;
            }
            else
            {
                lblOrder.Text = o.ToString() + "\r\n" + o.companyname + "\r\nOn " + nTools.DateFormat(o.orderdate) + "\r\nBy " + o.agentname;
                lblOrder.ForeColor = Color.Blue;
            }
        }

        private void cboOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckOrderInfo();
        }

        private void txtOrderNumber_TextChanged(object sender, EventArgs e)
        {
            CheckOrderInfo();
        }
    }
}