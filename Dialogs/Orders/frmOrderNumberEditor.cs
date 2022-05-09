using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;
using NewMethod;

namespace RzInterfaceWin.Dialogs
{
    public partial class frmOrderNumberEditor : Rz5.frmOrderNumberEditor 
    {
        //Constructors
        public frmOrderNumberEditor()
        {
            InitializeComponent();
        }
        public override void LoadScreen()
        {
            txtQuote.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.Quote.ToString()));
            txtInvoice.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.Invoice.ToString()));
            txtSO.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.Sales.ToString()));
            txtPO.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.Purchase.ToString()));
            txtRFQ.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.RFQ.ToString()));
            txtRMA.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.RMA.ToString()));
            txtVRMA.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.VendRMA.ToString()));
            txtService.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.Purchase.ToString()));
            ud.Value = Convert.ToDecimal(RzWin.Context.Sys.TheOrderLogic.OrderNumberLengthGet(RzWin.Context));
        }
        public override void SaveScreen()
        {
            int i = 0;
            i = GetValueInt(txtQuote.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.Quote.ToString(), i);
            i = GetValueInt(txtInvoice.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.Invoice.ToString(), i);
            i = GetValueInt(txtSO.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.Sales.ToString(), i);
            i = GetValueInt(txtPO.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.Purchase.ToString(), i);
            i = GetValueInt(txtRFQ.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.RFQ.ToString(), i);
            i = GetValueInt(txtRMA.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.RMA.ToString(), i);
            i = GetValueInt(txtVRMA.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.VendRMA.ToString(), i);
            i = GetValueInt(txtService.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Rz5.Enums.OrderType.Purchase.ToString(), i);
            RzWin.Context.Sys.TheOrderLogic.OrderNumberLengthSet(RzWin.Context, Convert.ToInt32(ud.Value));
        }
        //Control Events
        private void txtService_zz_GotKeyUp(object sender, KeyEventArgs e)
        {
            txtPO.SetValue(txtService.GetValue_String());
        }
        private void txtPO_zz_GotKeyUp(object sender, KeyEventArgs e)
        {
            txtService.SetValue(txtPO.GetValue_String());
        }
    }
}
