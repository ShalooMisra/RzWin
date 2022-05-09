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
    public partial class CreditCardEntry : ToolsWin.Dialogs.OKCancel
    {
        //Constructors
        public CreditCardEntry()
        {
            InitializeComponent();
        }
        //Public Functions
        public override void Init()
        {
            base.Init();
            LoadCreditCards();
        }        
        //Private Functions
        private void LoadCreditCards()
        {
            txtCard1.SetValue(n_set.GetSetting(RzWin.Context, "creditcard_1"));
            txtCard2.SetValue(n_set.GetSetting(RzWin.Context, "creditcard_2"));
            txtCard3.SetValue(n_set.GetSetting(RzWin.Context, "creditcard_3"));
            txtCard4.SetValue(n_set.GetSetting(RzWin.Context, "creditcard_4"));
        }
        private void SaveCreditCards()
        {
            n_set.SetSetting(RzWin.Context, "creditcard_1", txtCard1.GetValue_String());
            n_set.SetSetting(RzWin.Context, "creditcard_2", txtCard2.GetValue_String());
            n_set.SetSetting(RzWin.Context, "creditcard_3", txtCard3.GetValue_String());
            n_set.SetSetting(RzWin.Context, "creditcard_4", txtCard4.GetValue_String());

            txtCard1.ClearInfo();
            txtCard2.ClearInfo();
            txtCard3.ClearInfo();
            txtCard4.ClearInfo();
        }
        public override void OK()
        {
            SaveCreditCards();
            base.OK();
        }
    }
}
