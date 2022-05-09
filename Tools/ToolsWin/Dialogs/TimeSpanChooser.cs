using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin.Dialogs
{
    public partial class TimeSpanChooser : OKCancel
    {
        public static TimeSpan Choose()
        {
            TimeSpanChooser f = new TimeSpanChooser();
            f.Init();
            f.ShowDialog();

            TimeSpan ret = f.SelectedSpan;

            try
            {
                f.Close();
                f.Dispose();
                f = null;
            }
            catch { }

            return ret;
        }

        public TimeSpan SelectedSpan;
        public TimeSpanChooser()
        {
            InitializeComponent();
        }

        public void Init()
        {
            ConfirmShow();
        }

        TimeSpan CurrentSpan
        {
            get
            {
                int days = 0;
                int hours = 0;
                int minutes = 0;

                if (Tools.Number.IsNumeric(txtDays.Text))
                    days = Int32.Parse(txtDays.Text);

                if (Tools.Number.IsNumeric(txtHours.Text))
                    hours = Int32.Parse(txtHours.Text);

                if (Tools.Number.IsNumeric(txtMinutes.Text))
                    minutes = Int32.Parse(txtMinutes.Text);

                return new TimeSpan(days, hours, minutes, 0);
            }
        }

        public override void OK()
        {
            TimeSpan s = CurrentSpan;
            if (s.TotalSeconds <= 0)
                return;

            SelectedSpan = CurrentSpan;
            base.OK();
        }

        public override void Cancel()
        {
            SelectedSpan = TimeSpan.FromSeconds(0);
            base.Cancel();
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            ConfirmShow();
        }

        void ConfirmShow()
        {
            TimeSpan s = CurrentSpan;
            if (s.TotalSeconds <= 0)
            {
                lblConfirm.Text = "";
            }
            else
            {
                lblConfirm.Text = Tools.Dates.FormatDHM(Convert.ToInt32(s.TotalMinutes));
            }
        }
    }
}
