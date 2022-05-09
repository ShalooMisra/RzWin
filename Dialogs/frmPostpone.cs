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
    public partial class frmPostpone : Form
    {
        public DateTime TheDate;

        public frmPostpone()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdoneHour_Click(object sender, EventArgs e)
        {
            TimeSpan t = new TimeSpan(1, 0, 0);
            TheDate = TheDate.Add(t);
            this.Hide();
        }

        private void cmdTwoHours_Click(object sender, EventArgs e)
        {
            TimeSpan t = new TimeSpan(2, 0, 0);
            TheDate = TheDate.Add(t);
            this.Hide();
        }

        private void cmdOneDay_Click(object sender, EventArgs e)
        {
            TimeSpan t = new TimeSpan(1, 0, 0, 0);
            TheDate = TheDate.Add(t);
            this.Hide();
        }

        private void cmdTwoDays_Click(object sender, EventArgs e)
        {
            TimeSpan t = new TimeSpan(2, 0, 0, 0);
            TheDate = TheDate.Add(t);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan t = new TimeSpan(7, 0, 0, 0);
            TheDate = TheDate.Add(t);
            this.Hide();
        }

        private void cmdTwoWeeks_Click(object sender, EventArgs e)
        {
            TimeSpan t = new TimeSpan(14, 0, 0, 0);
            TheDate = TheDate.Add(t);
            this.Hide();
        }

        private void cmdOneMonth_Click(object sender, EventArgs e)
        {
            TimeSpan t = new TimeSpan(30, 0, 0, 0);
            TheDate = TheDate.Add(t);
            this.Hide();
        }

        private void cmdTwoMonths_Click(object sender, EventArgs e)
        {
            TimeSpan t = new TimeSpan(60, 0, 0, 0);
            TheDate = TheDate.Add(t);
            this.Hide();
        }

        private void frmPostpone_Activated(object sender, EventArgs e)
        {
            ToolsWin.Screens.SetOnMouse(this);
        }
    }
}