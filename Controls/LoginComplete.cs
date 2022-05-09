using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Rz5
{
    public partial class LoginComplete : UserControl
    {
        public LoginComplete()
        {
            InitializeComponent();
        }
        public void DoResize()
        {
            try
            {
                lblTop.Width = this.Width;
                lblBottom.Width = this.Width;
            }
            catch { }

        }
        private void pLogin_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
