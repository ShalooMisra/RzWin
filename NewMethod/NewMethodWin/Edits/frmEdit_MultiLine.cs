using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmEdit_MultiLine : Form
    {
        public static String Edit(String s)
        {
            frmEdit_MultiLine xForm = new frmEdit_MultiLine();
            xForm.CompleteLoad(s);
            xForm.ShowDialog();
            String h = xForm.SelectedText;
            xForm.Close();
            xForm = null;
            return h;
        }

        public String SelectedText = "";

        public frmEdit_MultiLine()
        {
            InitializeComponent();
        }

        public void CompleteLoad(String s)
        {
            txt.Text = s;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedText = "";
            this.Hide();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedText = txt.Text;
            this.Hide();
        }

        private void cmdChopFirst_Click(object sender, EventArgs e)
        {
            String[] ary = Tools.Strings.Split(txt.Text, "\r\n");
            String r = "";
            for (int i = 1; i < ary.Length; i++)
            {
                r += ary[i] + "\r\n";
            }
            txt.Text = r;
        }
    }
}