using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethodx;
using ConnectionManagerCore;

namespace ConnectionManager
{
    public partial class ConnectionSettingsBox : Form
    {
        public ConnectionSettingsBox()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (nTools.StrExt(this.textBox1.Text))
            {
                if( ToolsConnection.ConnectionFileDataSetDirect(this.textBox1.Text))
                {
                    this.Close();
                    ToolsConnection.ConnectionManagerRestart();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
                nextButton.Enabled = true;
            else
                nextButton.Enabled = false;
        }

    }
}
