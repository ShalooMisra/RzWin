using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Rz5.Focus
{
    public partial class FocusItemPreview : UserControl
    {
        public focus_item xItem;
        public FocusItemPreview()
        {
            InitializeComponent();
        }

        public void CompleteLoad(focus_item i)
        {
            xItem = i;
            lblName.Text = i.name;
            lblDescription.Text = i.description;
            lblDate.Text = i.date_created.ToString();

            try
            {
                if (il.Images.ContainsKey(i.item_type))
                {
                    pic.Image = il.Images[i.item_type];
                }
            }
            catch { }
        }

        private void lblName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((LeaderWinUserRz)RzWin.Context.TheLeaderRz).DisplayFocusItem(RzWin.Context, xItem);
        }
    }
}
