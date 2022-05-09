using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Rz5
{
    public partial class CrossReferenceResult : UserControl
    {
        public CrossReferenceResult()
        {
            InitializeComponent();
        }

        private void CrossReferenceResult_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                lv.Left = 0;
                lv.Top = 0;
                lv.Width = this.ClientRectangle.Width;
                lv.Height = this.ClientRectangle.Height / 2;

                wb.Left = 0;
                wb.Top = lv.Bottom;
                wb.Width = this.ClientRectangle.Width;
                wb.Height = this.ClientRectangle.Height - wb.Top;
            }
            catch { }
        }
    }
}
