using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;
using RzInterfaceWin.Controls;
using Core;

namespace RzInterfaceWin.Dialogs
{
    public partial class CurrencyExchange : Form
    {
        public static bool Ask(String currencyName, Double exchange_rate, Double startingBasevalue, Double startingForeignValue, int decimals, bool allowChange, ref String finalCurrency, ref Double finalBase, ref Double finalForeign, ref Double finalRate)
        {
            Dialogs.CurrencyExchange x = new Dialogs.CurrencyExchange();
            x.Location = Cursor.Position;
            x.Init(currencyName, exchange_rate, startingBasevalue, startingForeignValue, decimals, allowChange);
            x.ShowDialog();

            bool ret = x.Accepted;
            finalCurrency = x.FinalCurrency;
            finalBase = x.FinalBase;
            finalForeign = x.FinalForeign;
            finalRate = x.FinalRate;

            try
            {
                x.Close();
                x.Dispose();
                x = null;
            }
            catch { }

            return ret;
        }

        public CurrencyExchange()
        {
            InitializeComponent();
            picBase.BackColor = Color.Transparent;
            picForeign.BackColor = Color.Transparent;            
        }

        currency currentCurrency;
        Double currentRate;
        int decimalPlaces;

        bool loading = false;

        public bool Accepted = false;
        public String FinalCurrency = "";
        public Double FinalBase = 0;
        public Double FinalForeign = 0;
        public Double FinalRate = 0;

        public void Init(String currencyName, Double exchange_rate, Double startingBasevalue, Double startingForeignValue, int decimals, bool allowChange)
        {
            loading = true;

            decimalPlaces = decimals;

            currencyChoice.Enabled = allowChange;
            currencyChoice.Items.Clear();

            foreach (String n in RzWin.Accounts.CurrencyNames(RzWin.Context))
            {
                currencyChoice.Items.Add(n);
            }

            baseValue.Text = Tools.Number.MoneyFormat_2_6(startingBasevalue);
            picBase.BackgroundImage = RzWin.Leader.CurrencyImage(RzWin.Accounts.BaseCurrency);
            
            if (RzWin.Accounts.IsBaseCurrency(currencyName)) //was at the base
            {
                currentCurrency = null;
                currentRate = 1;
                currencyChoice.SelectedItem = currencyChoice.Items[currencyChoice.Items.IndexOf(RzWin.Accounts.BaseCurrency)];
                Shrink();
            }
            else
            {
                currentCurrency = RzWin.Accounts.GetCurrency(RzWin.Context, currencyName);
                currentRate = exchange_rate;  //NOT the rate from the currency; its the rate from the source document
                currencyChoice.SelectedItem = currencyChoice.Items[currencyChoice.Items.IndexOf(currentCurrency.name)];
                foreignValue.Text = Tools.Number.MoneyFormat_2_6(startingForeignValue);
                picForeign.BackgroundImage = RzWin.Leader.CurrencyImage(currentCurrency.name);
                rateLabel.Text = Tools.Number.MoneyFormat_2_6(currentRate);
                Grow();
            }

            loading = false;
        }

        private void currencyChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            loading = true;
            if (RzWin.Accounts.IsBaseCurrency(currencyChoice.Text))
            {
                currentRate = 1;
                loading = true;
                foreignValue.Text = baseValue.Text;
                loading = false;
                Ok();
                return;
            }

            currentCurrency = RzWin.Accounts.GetCurrency(RzWin.Context, currencyChoice.Text);
            currentRate = currentCurrency.exchange_rate;
            rateLabel.Text = Tools.Number.MoneyFormat_2_6(currentRate);

            rateLabel.Text = currentRate.ToString();
            foreignValue.Text = Tools.Number.MoneyFormat_2_6(currency.CalculateExchangeFromBase(Double.Parse(baseValue.Text), currentRate, decimalPlaces));

            picForeign.BackgroundImage = RzWin.Leader.CurrencyImage(currentCurrency.name);

            Grow();
            loading = false;
        }

        void Shrink()
        {
            this.Height = 85;
        }

        void Grow()
        {
            this.Height = 315;
        }

        private void baseValue_TextChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            loading = true;
            if (!Tools.Number.IsNumeric(baseValue.Text))
            {
                foreignValue.Text = "";
                loading = false;
                return;
            }

            foreignValue.Text = Tools.Number.MoneyFormat_2_6(currency.CalculateExchangeFromBase(Double.Parse(baseValue.Text), currentRate, decimalPlaces));
            loading = false;
        }

        private void foreignValue_TextChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            loading = true;
            if (!Tools.Number.IsNumeric(foreignValue.Text))
            {
                baseValue.Text = "";
                loading = false;
                return;
            }

            baseValue.Text = Tools.Number.MoneyFormat_2_6(currency.CalculateExchangeFromForeign(Double.Parse(foreignValue.Text), currentRate, decimalPlaces));
            loading = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Accepted = false;
            FinalCurrency = "";
            FinalBase = 0;
            FinalForeign = 0;
            FinalRate = 0;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Ok();
        }

        void Ok()
        {
            Accepted = true;
            FinalCurrency = currencyChoice.Text;
            FinalBase = Double.Parse(baseValue.Text);
            FinalForeign = Double.Parse(foreignValue.Text);
            FinalRate = currentRate;
            this.Close();
        }
    }
}
