using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Win.Screens
{
    public partial class Shipping : UserControl, IShippingScreen
    {
        public Shipping()
        {
            InitializeComponent();
        }

        public void Init(bool dueToday)
        {
            if (dueToday)
            {
                Tools.Dates.DateRange range = new Tools.Dates.DateRange(DateTime.Now, DateTime.Now);
                hReceive.Init(Enums.OrderDirection.Incoming, range);
                hShip.Init(Enums.OrderDirection.Outgoing, range);
                optOn.Checked = true;
                dt1.Value = DateTime.Now;
            }
            else
            {
                hReceive.Init(Enums.OrderDirection.Incoming);
                hShip.Init(Enums.OrderDirection.Outgoing);
                //dt1.Value = Tools.Dates.NullDate;
                //dt2.Value = Tools.Dates.NullDate;
                //Added this arbitraty date which is 1.5 years ago (today is 3-12-2018) which should be sufficient to eliminate old order lines.
                dt1.Value = new DateTime(2016,06, 01);
                
            }
        }

        private void ShippingScreen_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        protected virtual void DoResize()
        {
            try
            {
                pTop.Left = (this.ClientRectangle.Width / 2) - (pTop.Width / 2);
                pTop.Top = 0;
                //pTop.Width = this.ClientRectangle.Width;

                hReceive.Left = 0;
                hReceive.Top = 0; // pTop.Bottom;
                hReceive.Width = this.ClientRectangle.Width / 2;
                hReceive.Height = this.ClientRectangle.Height - hReceive.Top;

                hShip.Left = hReceive.Right;
                hShip.Top = 0;  // pTop.Bottom;
                hShip.Height = this.ClientRectangle.Height - hShip.Top;
                hShip.Width = this.ClientRectangle.Width - hShip.Left;
            }
            catch { }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            Search();
        }

        void Search()
        {
            Tools.Dates.DateRange range = null;

            if (optAllDates.Checked)
            {
                //range stays null
            }

            if (optOn.Checked)
            {
                range = new Tools.Dates.DateRange(dt1.Value, dt1.Value);
            }

            if(optBefore.Checked)
            {
                range = new Tools.Dates.DateRange(Tools.Dates.NullDate, dt1.Value);
            }

            if(optAfter.Checked)
            {
                range = new Tools.Dates.DateRange(dt1.Value, Tools.Dates.NullDate);
            }

            if (optBetween.Checked)
            {
                range = new Tools.Dates.DateRange(dt1.Value, dt2.Value);
            }

            hReceive.Search(range);
            hShip.Search(range);
        }

        private void optAllDates_CheckedChanged(object sender, EventArgs e)
        {
            Checks();
        }

        void Checks()
        {
            if (optAllDates.Checked)
            {
                dt1.Visible = false;
                dt2.Visible = false;
            }

            if (optOn.Checked || optBefore.Checked || optAfter.Checked)
            {
                if (!Tools.Dates.DateExists(dt1.Value))
                    dt1.Value = DateTime.Now;

                dt1.Visible = true;
                dt2.Visible = false;
            }

            if (optBetween.Checked)
            {
                if (!Tools.Dates.DateExists(dt1.Value))
                    dt1.Value = Tools.Dates.GetMonthStart(DateTime.Now);

                if (!Tools.Dates.DateExists(dt2.Value))
                    dt2.Value = Tools.Dates.GetMonthEnd(DateTime.Now);

                dt1.Visible = true;
                dt2.Visible = true;
            }
        }
    }

    public interface IShippingScreen
    {
        void Init(bool dueToday);
    }
}
