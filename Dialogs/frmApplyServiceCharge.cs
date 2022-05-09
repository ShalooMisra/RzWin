using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rz5
{
    public partial class frmApplyServiceCharge : Form
    {
        //Public Variables
        public ordhed_sales TheSalesOrder;
        public ordhed_invoice TheInvoice;
        //Private Variables
        private ContextRz TheContext;
        private ordhed_service TheServiceOrder;

        //Constructors
        public frmApplyServiceCharge()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad(ContextRz x, ordhed_service s)
        {
            if (x == null)
                return false;
            if (s == null)
                return false;
            TheContext = x;
            TheServiceOrder = s;
            LoadSalesOrders();
            LoadInvoices();
            return true;
        }
        //Private Functions
        private void LoadSalesOrders()
        {
            fSales.Controls.Clear();
            Dictionary<string, ordhed_sales> d = new Dictionary<string, ordhed_sales>();
            List<orddet> lst = TheServiceOrder.DetailsList(TheContext);
            foreach(orddet_line l in lst)
            {
                if (Tools.Strings.StrExt(l.orderid_sales))
                {
                    ordhed_sales s = (ordhed_sales)l.OrderObjectGet(TheContext, Enums.OrderType.Sales);
                    if (s == null)
                        continue;
                    try { d.Add(s.unique_id, s); }
                    catch { }
                }
            }
            foreach (KeyValuePair<string, ordhed_sales> kvp in d)
            {
                if (kvp.Value == null)
                    continue;
                RadioButton r = new RadioButton();
                r.AutoSize = false;
                r.Text = kvp.Value.ToString();
                r.Width = fSales.ClientRectangle.Width - 2;
                r.Tag = kvp.Value;
                fSales.Controls.Add(r);
            }
        }
        private void LoadInvoices()
        {
            fInvoices.Controls.Clear();
            Dictionary<string, ordhed_invoice> d = new Dictionary<string, ordhed_invoice>();
            List<orddet> lst = TheServiceOrder.DetailsList(TheContext);
            foreach (orddet_line l in lst)
            {
                if (Tools.Strings.StrExt(l.orderid_invoice))
                {
                    ordhed_invoice s = (ordhed_invoice)l.OrderObjectGet(TheContext, Enums.OrderType.Invoice);
                    if (s == null)
                        continue;
                    try { d.Add(s.unique_id, s); }
                    catch { }
                }
            }
            foreach (KeyValuePair<string, ordhed_invoice> kvp in d)
            {
                if (kvp.Value == null)
                    continue;
                RadioButton r = new RadioButton();
                r.AutoSize = false;
                r.Text = kvp.Value.ToString();
                r.Width = fSales.ClientRectangle.Width - 2;
                r.Tag = kvp.Value;
                fInvoices.Controls.Add(r);
            }
        }
        private void Accept()
        {
            TheSalesOrder = null;
            TheInvoice = null;
            try
            {
                foreach (RadioButton r in fSales.Controls)
                {
                    if (!r.Checked)
                        continue;
                    TheSalesOrder = (ordhed_sales)r.Tag;
                    break;
                }
                foreach (RadioButton r in fInvoices.Controls)
                {
                    if (!r.Checked)
                        continue;
                    TheInvoice = (ordhed_invoice)r.Tag;
                    break;
                }
            }
            catch { }
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            TheSalesOrder = null;
            TheInvoice = null;
            Close();
        }
        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Accept();
            Close();
        }
    }
}
