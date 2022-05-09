using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Rz5;
using System.Resources;

namespace RzInterfaceWin.Controls
{
    public partial class nEdit_Currency : NewMethod.nEdit_Money
    {
        public nEdit_Currency()
        {
            InitializeComponent();
            picCurrency.BackColor = Color.Transparent;
            picCurrency.Cursor = Cursors.Hand;
            zz_OriginalDesign = false;
            UseParentBackColor = true;
            picCurrency.Size = new Size(20, 20);
        }

        Item Item;
        String CurrencyNameField;
        String RateField;
        String BaseField;
        String ForeignField;
        int Decimals;
        bool AllowCurrencyChange;
        CompleteSomething SaveDelegate;
        CompleteSomething LoadDelegate;

        public void Init(Item item, String currencyNameField, String rateField, String baseField, String foreignField, int decimals, bool allowChange, CompleteSomething saveDelegate, CompleteSomething loadDelegate)
        {
            Item = item;
            CurrencyNameField = currencyNameField;
            RateField = rateField;
            BaseField = baseField;
            ForeignField = foreignField;
            Decimals = decimals;
            AllowCurrencyChange = allowChange;
            SaveDelegate = saveDelegate;
            LoadDelegate = loadDelegate;
        }

        public void LoadValues()
        {
            if (RzWin.Accounts.IsBaseCurrency(Item.ValGetString(CurrencyNameField)))
            {
                SetValue(Item.ValGet(BaseField));
            }
            else
            {
                SetValue(Item.ValGet(ForeignField));
            }

            String curr = Item.ValGetString(CurrencyNameField);

            if (RzWin.Accounts.IsBaseCurrency(curr))
            {
                nameLabel.Text = RzWin.Accounts.BaseCurrency;
                picCurrency.BackgroundImage = RzWin.Leader.CurrencyImage(RzWin.Accounts.BaseCurrency);
                SetValue(Item.ValGet(BaseField));
            }
            else
            {
                nameLabel.Text = curr;
                picCurrency.BackgroundImage = RzWin.Leader.CurrencyImage(curr);
                SetValue(Item.ValGet(ForeignField));
            }
        }

        public void SaveValues()
        {
            if (RzWin.Accounts.IsBaseCurrency(Item.ValGetString(CurrencyNameField)))
            {
                Item.ValSet(RateField, (Double)1);
                Item.ValSet(BaseField, GetValue_Double());
                Item.ValSet(ForeignField, GetValue_Double());
            }
            else
            {
                Double rate = (Double)Item.ValGet(RateField);
                Double foreignValue = GetValue_Double();
                Double baseValue = currency.CalculateExchangeFromForeign(foreignValue, rate, Decimals);

                Item.ValSet(BaseField, baseValue);
                Item.ValSet(ForeignField, foreignValue);
            }
            ClearInfo();
        }

        private void picCurrency_Click(object sender, EventArgs e)
        {
            String finalCurrency = "";
            Double finalBase = 0;
            Double finalForeign = 0;
            Double finalRate = 0;

            if (!Dialogs.CurrencyExchange.Ask(Item.ValGetString(CurrencyNameField), (double)Item.ValGet(RateField), (double)Item.ValGet(BaseField), (double)Item.ValGet(ForeignField), Decimals, AllowCurrencyChange, ref finalCurrency, ref finalBase, ref finalForeign, ref finalRate))
                return;

            SaveDelegate();

            Item.ValSet(CurrencyNameField, finalCurrency);
            Item.ValSet(BaseField, finalBase);
            Item.ValSet(ForeignField, finalForeign);
            Item.ValSet(RateField, finalRate);
            Item.Update(RzWin.Context);

            LoadDelegate();
        }

        //private void picCurrency_MouseHover(object sender, EventArgs e)
        //{
        //    if (tTip == null)
        //        tTip = new ToolTip();

        //    tTip.ToolTipIcon = ToolTipIcon.Info;
        //    tTip.Show(Summarize(), this.ParentForm, Cursor.Position, 4000);
        //}

        //String Summarize()
        //{
        //    return "Yo!";
        //}

        public override void DoResize()
        {
            try
            {
                base.DoResize();
                txtValue.Width -= (picCurrency.Width + 4);
                picCurrency.Left = txtValue.Right;
                picCurrency.Top = txtValue.Top;

                nameLabel.Left = picCurrency.Left - 2;
                nameLabel.Top = picCurrency.Top - (nameLabel.Height + 2);
            }
            catch { }
        }
    }

    public delegate void CompleteSomething();
}
