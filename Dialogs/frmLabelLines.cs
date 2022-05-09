using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;
using System.Collections.Generic;

namespace Rz5
{
    public partial class frmLabelLines : Form
    {
        public static ArrayList EnterLines(orddet_line xdet)
        {
            frmLabelLines xForm = RzWin.Leader.GetLabelLinesForm();
            xForm.CompleteLoad(xdet);
            xForm.ShowDialog();

            ArrayList a = xForm.GetLines();
            if (xForm.Cancelled)
                a = null;

            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return a;
        }
        public bool Cancelled = false;
        public frmLabelLines()
        {
            InitializeComponent();
        }

        public virtual void CompleteLoad(orddet_line x)
        {
            lblTop.Text = "Part: " + x.fullpartnumber + "\r\nMfg: " + x.manufacturer + "\r\nQty: " + Tools.Number.LongFormat(x.quantity) + "\r\nD/C: " + x.datecode;
            txtData.Text = x.quantity.ToString() + " : " + x.datecode;            
        }

        protected String GetLineInfo(orddet_line x)
        {
            ArrayList serials = RzWin.Context.Data.ScalarArray("select the_number from serial_number where the_orddet_uid = '" + x.unique_id + "' order by the_number");
            if (serials.Count == 0)
                return x.quantity.ToString() + " : " + x.datecode;

            long remaining = x.quantity;
            long xn = 1;
            StringBuilder sb = new StringBuilder();
            foreach (String ser in serials)
            {
                sb.AppendLine(xn.ToString() + " : " + x.datecode + " : " + ser + " : OF " + x.quantity.ToString());
                remaining--;
                xn++;
            }

            if (remaining > 0)
                sb.AppendLine(remaining.ToString() + " : " + x.datecode);
            return sb.ToString();
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            ShowSummary();
        }

        protected void ShowSummary()
        {
            ArrayList a = GetLines();
            if (a.Count == 0)
            {
                lblStatus.Text = "No Labels";
                return;
            }
            lblStatus.Text = Tools.Number.LongFormat(a.Count) + " Labels";
        }
        protected ArrayList GetLines()
        {
            String[] ary = Tools.Strings.SplitLines(txtData.Text);
            ArrayList a = new ArrayList();
            foreach (String s in ary)
            {
                a.Add(s);
            }
            return a;
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            Cancelled = false;
            this.Hide();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            this.Hide();
        }
    }
}