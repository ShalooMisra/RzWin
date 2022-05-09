using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public delegate void ActionLinkClickHandler(Object sender, String ActionKey);
    
    public partial class nActionLink : UserControl
    {
        public String CurrentKey = "";
        private bool IsSeparator = false;
        bool custom_pic = false;
        //Public Events
        public event ActionLinkClickHandler LinkClicked;

        public nActionLink()
        {
            InitializeComponent();
            ps.BackgroundImage = IM16.Images["action"];
        }
        //Public Functions
        public void CompleteLoad(String str)
        {
            SetSmall();
            CurrentKey = str.ToLower();
            lbl.Text = str;
            DoResize();
        }
        public void CompleteLoad(ActHandle h)
        {
            SetSmall();
            lblDescription.Text = "";
            if (h is ActHandleSeparator)
            {
                IsSeparator = true;
                ps.Visible = false;
                CurrentKey = "";
                lbl.Text = "---------------";
            }
            else
            {              
                CurrentKey =  h.Name;
                lbl.Text = h.Caption;
                ps.Visible = true;
            }
            DoResize();
        }

        public String GetText()
        {
            return lbl.Text;
        }

        //public void CompleteLoad(n_menu m)
        //{
        //    SetSmall();
        //    CurrentKey = m.unique_id;
        //    lbl.Text = m.name;
        //    lblDescription.Text = m.tag_line;
        //    ps.Visible = true;

        //    Image i = m.xSys.GetResourceImage_Trans(m.icon_key);
        //    if (i != null)
        //    {
        //        ps.BackgroundImage = i;
        //        custom_pic = true;
        //    }

        //    DoResize();
        //}
        void CompleteDispose()
        {
            try
            {
                this.lbl.Click -= new System.EventHandler(this.lbl_Click);
                this.lbl.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.x_MouseDown);
                this.lbl.MouseEnter -= new System.EventHandler(this.x_MouseEnter);
                this.lbl.MouseLeave -= new System.EventHandler(this.x_MouseLeave);
                this.lbl.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.x_MouseUp);
                this.ps.Click -= new System.EventHandler(this.ps_Click);
                this.ps.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.x_MouseDown);
                this.ps.MouseEnter -= new System.EventHandler(this.x_MouseEnter);
                this.ps.MouseLeave -= new System.EventHandler(this.x_MouseLeave);
                this.ps.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.x_MouseUp);
                this.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.x_MouseDown);
                this.MouseEnter -= new System.EventHandler(this.x_MouseEnter);
                this.MouseLeave -= new System.EventHandler(this.x_MouseLeave);
                this.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.x_MouseUp);
                this.Resize -= new System.EventHandler(this.nActionLink_Resize);
            }
            catch { }
        }
        public void DoResize()
        {
            int w = lbl.Right;
            if( lblDescription.Width > w )
                w = lblDescription.Right;

            this.Width = w;

            if (Tools.Strings.StrExt(lblDescription.Text))
                this.Height = 34;
            else
                this.Height = 20;
        }
        public void SetEnabled(bool e)
        {
            this.Enabled = e;
            ps.Enabled = e;
            lbl.Enabled = e;
        }
        public void SetSmall()
        {
            lbl.Font = new Font("Calibri", 10, FontStyle.Bold);
            lbl.ForeColor = Color.Blue;
            if( !custom_pic )
                ps.BackgroundImage = IM16.Images["action"];
            DoResize();
        }
        public void SetBig()
        {
            if (IsSeparator)
                return;
            lbl.Font = new Font("Calibri", 12, FontStyle.Bold);//was 14
            lbl.ForeColor = Color.Green;
            if( !custom_pic )
                ps.BackgroundImage = IM16.Images["action_hover"];
            DoResize();
        }

        //i don't think this actually does the same as -=
        //public void ClearLinkClicked()
        //{
        //    LinkClicked = null;
        //}
        //Private Functions

        private void DoClick()
        {
            if (IsSeparator)
                return;
            if (LinkClicked != null)
                LinkClicked(this, CurrentKey);
        }
        //Control Events
        private void x_MouseLeave(object sender, EventArgs e)
        {
            SetSmall();
        }
        private void x_MouseUp(object sender, MouseEventArgs e)
        {
            //SetBig();
        }
        private void x_MouseDown(object sender, MouseEventArgs e)
        {
            SetSmall();
        }
        private void x_MouseEnter(object sender, EventArgs e)
        {
            SetBig();
        }
        private void ps_Click(object sender, EventArgs e)
        {
            DoClick();
        }
        private void lbl_Click(object sender, EventArgs e)
        {
            DoClick();
        }
        private void nActionLink_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
