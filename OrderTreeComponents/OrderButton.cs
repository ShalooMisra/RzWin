using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Rz5
{
    public delegate void OrderButtonHandler(OrderButton b);

    public partial class OrderButton : UserControl
    {
        public event OrderButtonHandler ButtonClicked;
        public event OrderButtonHandler DropClicked;

        public Enums.OrderType TheType;

        public OrderButton()
        {
            InitializeComponent();
        }

        public void CompleteLoad(Enums.OrderType t, Image i, Color c)
        {
            TheType = t;
            cmd.BackgroundImage = i;
            picTop.BackColor = c;
            picBottom.BackColor = c;
            picRight.BackColor = c;
            picLeft.BackColor = c;
            lbl.ForeColor = c;
        }

        public void SetText(String s)
        {
            lbl.Text = s;
        }

        private void cmdDrop_Click(object sender, EventArgs e)
        {
            if (DropClicked != null)
                DropClicked(this);
        }

        private void cmd_Click(object sender, EventArgs e)
        {
            if (ButtonClicked != null)
                ButtonClicked(this);
        }
    }
}
