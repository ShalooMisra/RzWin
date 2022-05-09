using Rz5;
using System.Windows.Forms;
using System;

namespace Rz5
{
    public partial class frmOrderTestOptions : Form
    {
        ContextRz x;
        ordhed o;
        public frmOrderTestOptions(ContextRz xrz, ordhed ord)
        {
            x = xrz;
            o = ord;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblConfirmDockDates_Click(object sender, EventArgs e)
        {
            foreach (orddet_line l in o.DetailsList(x))
            {
                x.Leader.GetDockDateChecker(x, l);

            }

        }

        private void llResetVendorRMA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!x.Leader.AskYesNo("Do you want to reset the Vrma Shipped Shatus?"))
                return;




            //Reset all Line Lvel Properties
            foreach (orddet_line l in o.DetailsList(x))
            {
                //Delete All Packs
                foreach (pack p in l.PacksVendRMAVar.RefsList(x))
                {
                    p.Delete(x);
                }

                if (l.was_vendrma_shipped)
                    l.was_vendrma_shipped = false;
                if (l.quantity_packed_vendrma != l.quantity)
                    l.quantity_packed_vendrma = l.quantity;
                if (l.Status != Enums.OrderLineStatus.Vendor_RMA_Packing)
                    l.Status = Enums.OrderLineStatus.Vendor_RMA_Packing;
                l.Update(x);

            }

        }
    }
}
