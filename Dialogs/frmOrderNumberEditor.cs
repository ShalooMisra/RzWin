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
    public partial class frmOrderNumberEditor : Form
    {
        //Protected Variables
        protected ContextNM TheContext;

        //Constructors
        public frmOrderNumberEditor()
        {
            InitializeComponent();
        }
        //Public functions
        public bool CompleteLoad(ContextNM x)
        {
            if (x == null)
                return false;
            TheContext = x;
            LoadScreen();
            return true;
        }
        public virtual void LoadScreen()
        {
            txtQuote.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.Quote.ToString()));
            txtInvoice.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.Invoice.ToString()));
            txtSO.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.Sales.ToString()));
            txtPO.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.Purchase.ToString()));
            txtRFQ.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.RFQ.ToString()));
            txtRMA.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.RMA.ToString()));
            txtVRMA.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.VendRMA.ToString()));
            txtService.SetValue(n_set.GetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.Service.ToString()));
            ud.Value = Convert.ToDecimal(RzWin.Context.Sys.TheOrderLogic.OrderNumberLengthGet(RzWin.Context));            
        }
        public virtual void SaveScreen()
        {
            int i = 0;
            i = GetValueInt(txtQuote.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.Quote.ToString(), i);
            i = GetValueInt(txtInvoice.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.Invoice.ToString(), i);
            i = GetValueInt(txtSO.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.Sales.ToString(), i);
            i = GetValueInt(txtPO.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.Purchase.ToString(), i);
            i = GetValueInt(txtRFQ.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.RFQ.ToString(), i);
            i = GetValueInt(txtRMA.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.RMA.ToString(), i);
            i = GetValueInt(txtVRMA.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.VendRMA.ToString(), i);
            i = GetValueInt(txtService.GetValue_String());
            if (i > 0)
                n_set.SetSetting_Integer(RzWin.Context, "next_order_number_" + Enums.OrderType.Service.ToString(), i);
            RzWin.Context.Sys.TheOrderLogic.OrderNumberLengthSet(RzWin.Context, Convert.ToInt32(ud.Value));
        }
        //Private Functions
        protected int GetValueInt(string s)
        {
            try
            {
                if (!Tools.Strings.StrExt(s))
                    return -1;
                return Convert.ToInt32(s);
            }
            catch { }
            return -1;
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveScreen();
        }
    }
}
