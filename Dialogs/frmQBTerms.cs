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
    public partial class frmQBTerms : Form
    {
        public static void Ask(System.Windows.Forms.IWin32Window owner, String strTerms, ref bool Cancelled, ref int DaysDue, ref Double DiscountPercent, ref int DiscountDays)
        {
            frmQBTerms xForm = new frmQBTerms();
            xForm.CompleteLoad(strTerms);
            xForm.ShowDialog(owner);

            if (xForm.Cancelled)
            {
                Cancelled = true;
                DaysDue = 0;
                DiscountPercent = 0;
                DiscountDays = 0;
            }
            else
            {
                Cancelled = false;
                DaysDue = xForm.DaysDue;
                DiscountPercent = xForm.DiscountPercent;
                DiscountDays = xForm.DiscountDays;
            }
        }

        public bool Cancelled = false;
        public int DaysDue = 0;
        public Double DiscountPercent = 0;
        public int DiscountDays = 0;
        public String CurrentTerms = "";

        public frmQBTerms()
        {
            InitializeComponent();
        }

        public void CompleteLoad(String terms)
        {
            CurrentTerms = terms;
            lblTerms.Text = terms;
            CheckPercent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            this.Hide();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            DoOK();
        }

        private void DoOK()
        {
            DoOK(RzWin.Form.TheContextNM);
        }
        private void DoOK(ContextNM x)
        {
            if (!Tools.Number.IsNumeric(txtDueDays.Text))
            {
                x.TheLeader.TellTemp("Please enter the number of days allowed by the terms " + CurrentTerms);
                return;
            }

            if (Tools.Number.IsNumeric(txtDiscountPercent.Text))
            {
                if (Convert.ToDouble(txtDiscountPercent.Text) > 0)
                {
                    int i = 0;
                    if (Tools.Number.IsNumeric(txtDiscountDays.Text))
                        i = Convert.ToInt32(txtDiscountDays.Text);

                    if (i == 0)
                    {
                        x.TheLeader.TellTemp("A discount percent of " + txtDiscountPercent.Text + "% has been entered.  To continue, enter the number of days that the discount applies to.");
                        return;
                    }
                }
            }

            DaysDue = Convert.ToInt32(txtDueDays.Text);
            DiscountPercent = Convert.ToInt32(txtDiscountDays.Text);
            DiscountDays = Convert.ToInt32(txtDiscountDays.Text);
            Cancelled = false;
            this.Hide();
        }

        private void txtDiscountPercent_TextChanged(object sender, EventArgs e)
        {
            CheckPercent();
        }

        private void CheckPercent()
        {
            if (!Tools.Number.IsNumeric(txtDiscountPercent.Text))
            {
                txtDiscountDays.Enabled = false;
                return;
            }

            txtDiscountDays.Enabled = (Convert.ToDouble(txtDiscountPercent.Text) > 0);
        }
    }
}