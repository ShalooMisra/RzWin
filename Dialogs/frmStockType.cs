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
    public partial class frmStockType : Form
    {
        public static Enums.StockType Choose(IWin32Window owner)
        {
            frmStockType f = new frmStockType();
            f.ShowDialog(owner);

            Enums.StockType ret = f.SelectedType;

            try
            {
                f.Close();
                f.Dispose();                  
            }
            catch { }

            return ret;
        }

        public Enums.StockType SelectedType = Enums.StockType.Any;
        public frmStockType()
        {
            InitializeComponent();
        }

        public void SetCaption(String s)
        {
            lblCaption.Text = s;
            //if (Rz3App.xLogic.IsCTG && !Rz3App.xUser.IsDeveloper())
            //{
            //    label1.Text = "To create a 'buy' line on a PO, please create the line on the\r\ncustomer sales order and create the PO from there.";
            //    cmdBuy.Enabled = false;
            //}
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedType = Enums.StockType.Any;
            this.Hide();
        }

        private void cmdStock_Click(object sender, EventArgs e)
        {
            SelectedType = Enums.StockType.Stock;
            this.Hide();
        }

        private void cmdBuy_Click(object sender, EventArgs e)
        {
            SelectedType = Enums.StockType.Buy;
            this.Hide();
        }
    }
}