using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Win.Controls
{
    public partial class EditMoney : nEdit_Money
    {
        public static bool CheckedCurrencies = false;
        public static bool HasCurrencies = false;

        public EditMoney()
        {
            InitializeComponent();
        }

        //protected override void DoubleClickHandle()
        //{
        //    if (CheckedCurrencies && !HasCurrencies)
        //        return;

        //    if (!CheckedCurrencies)
        //    {
        //        HasCurrencies = Rz3App.SelectScalarInt64("select count(*) from currency_exchange") > 0;
        //        CheckedCurrencies = true;
        //    }

        //    if (!HasCurrencies)
        //        return;

        //    SetByOtherCurrency();
        //}

        //void SetByOtherCurrency()
        //{
        //    if (Rz3App.xSys == null)
        //        return;

        //    Win.Dialogs.CurrencyConverter.SelectConversion(this);
        //}
    }
}
