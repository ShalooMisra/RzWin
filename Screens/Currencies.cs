using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NewMethod;
using Rz5;

namespace RzInterfaceWin.Screens
{
    public partial class Currencies : UserControl
    {
        //Private Variables
        private currency currentCurrency;

        //Constructors
        public Currencies()
        {
            InitializeComponent();
        }
        //Private Functions
        private void DoResize()
        {
            try
            {
                ts.Top = 0;
                ts.Left = 0;
                ts.Width = this.ClientRectangle.Width;
                ts.Height = this.ClientRectangle.Height;
                pTop.Left = 7;
                pTop.Top = 7;
                lst.Left = 7;
                lst.Top = pTop.Bottom;
                lst.Width = tabCurrency.ClientRectangle.Width - (lst.Left * 2);
                if (currentCurrency == null)
                {
                    lst.Height = tabCurrency.ClientRectangle.Height - lst.Top;
                }
                else
                {
                    lst.Height = tabCurrency.ClientRectangle.Height - (lst.Top + pInstance.Height);
                    pInstance.Left = 7;
                    pInstance.Top = tabCurrency.ClientRectangle.Height - pInstance.Height;
                    pInstance.Width = tabCurrency.ClientRectangle.Width - (pInstance.Left * 2);
                }
            }
            catch { }
        }
        private void SetCurrentCurrency(currency c)
        {
            currentCurrency = c;
            NMWin.LoadFormValues(pInstance, currentCurrency);
            pInstance.Visible = true;
            DoResize();
        }
        //Buttons
        private void okButton_Click(object sender, EventArgs e)
        {
            NMWin.GrabFormValues(pInstance, currentCurrency);
            currentCurrency.Update(RzWin.Context);
            lst.ReDoSearch();
            currentCurrency = null;
            pInstance.Visible = false;
            DoResize();
        }
        //Control Events
        private void Currencies_Load(object sender, EventArgs e)
        {
            lst.ShowTemplate("all_currencies_2", "currency");
            lst.ShowData("currency", "", "name");
            wb.Navigate("http://www.xe.com/currencyconverter/");
            DoResize();
        }
        private void Currencies_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lst_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;
            SetCurrentCurrency((currency)args.TheItems.AllGet(RzWin.Context)[0]);
        }
        private void lst_AboutToAdd(object sender, Core.AddArgs args)
        {
            args.Handled = true;
            currency c = currency.New(RzWin.Context);
            c.Insert(RzWin.Context);
            SetCurrentCurrency(c);
        }
    }
}
