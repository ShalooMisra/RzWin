using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmList : Form
    {
        public frmList()
        {
            InitializeComponent();

        }

        public void ShowList(String strClass, String strWhere, String strOrder, long lngLimit)
        {
            xList.ShowTemplate("all_" + strClass, strClass);
            xList.ShowData(strClass, strWhere, strOrder, lngLimit);
            DoResize();
        }

        private void frmList_Load(object sender, EventArgs e)
        {

        }

        private void frmList_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public void DoResize()
        {
            xList.Location = new Point(0, 0);
            xList.Height = this.ClientRectangle.Height;
            xList.Width = this.ClientRectangle.Width;
            xList.DoResize();
        }

    }
}