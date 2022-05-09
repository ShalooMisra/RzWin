using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Core;

namespace Rz5
{
    public partial class CurrencySelector : UserControl
    {
        public event CurrencySelectionChanged SelectionChanged;

        public CurrencySelector()
        {
            InitializeComponent();
            picCurrency.BackColor = Color.Transparent;
            picCurrency.Size = new Size(20, 20);
        }

        bool loading = false;
        String lastCurrencyName = "";
        public void Init(String currency, Double rate)
        {
            loading = true;
            nameList.Items.Clear();

            foreach (String c in RzWin.Accounts.CurrencyNames(RzWin.Context))
            {
                nameList.Items.Add(c);
            }

            if (RzWin.Accounts.IsBaseCurrency(currency))
            {
                nameList.SelectedItem = nameList.Items[nameList.Items.IndexOf(RzWin.Accounts.BaseCurrency)];
                picCurrency.BackgroundImage = RzWin.Leader.CurrencyImage(RzWin.Accounts.BaseCurrency);
                nameLabel.Text = RzWin.Accounts.BaseCurrency;
                rateLabel.Visible = false;
                rateCaptionLabel.Visible = false;
            }
            else
            {
                nameList.SelectedItem = nameList.Items[nameList.Items.IndexOf(currency)];
                picCurrency.BackgroundImage = RzWin.Leader.CurrencyImage(currency);
                nameLabel.Text = currency;
                rateLabel.Visible = true;
                rateCaptionLabel.Visible = true;
            }

            //rateLabel.Text = rate.ToString();
            rateLabel.Text = Rz5.currency.Inverse(rate).ToString();  //inverse rate

            loading = false;
            lastCurrencyName = nameList.Text;
        }

        private void nameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            if (SelectionChanged != null)
            {
                bool cancel = false;
                SelectionChanged(nameList.Text, ref cancel);
                if (cancel)
                {
                    loading = true;
                    nameList.SelectedItem = nameList.Items[nameList.Items.IndexOf(lastCurrencyName)];
                    loading = false;
                }
            }

            lastCurrencyName = nameList.Text;
        }
    }

    public delegate void CurrencySelectionChanged(String selectedCurrencyName, ref bool cancel);
}
