using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Rz5
{
    public partial class HomePanel : UserControl
    {
        public HomePanel()
        {
            InitializeComponent();
        }

        private void lblCaption_Click(object sender, EventArgs e)
        {

        }

        public event EventHandler SearchClicked;

        protected void SearchClickedFire()
        {
            if (SearchClicked != null)
                SearchClicked(this, null);
        }

        public virtual HomePanelSearchArgs SearchArgs
        {
            get
            {
                return null;
            }
        }

        String m_Caption = "";
        public String Caption
        {
            get
            {
                return m_Caption;
            }

            set
            {
                m_Caption = value;
                lblCaption.Text = value;
            }
        }        
    }

}
