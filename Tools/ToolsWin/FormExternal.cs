using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin
{
    public partial class FormExternal : Form
    {
        public event ShowInTabHandler ShowInTab;
        Control CurrentControl;
        public String TabID = "";
        bool LeaveInMemory = false;

        public FormExternal()
        {
            InitializeComponent();
        }

        void CompleteDispose()
        {
            try
            {
                Controls.Remove(CurrentControl);

                if (CurrentControl is ViewBase)
                {
                    ViewBase s = (ViewBase)CurrentControl;
                    s.CloseRequest -= new CloseHandler(s_CloseRequest);
                }

                if (!LeaveInMemory)
                {
                    CurrentControl.Dispose();
                    CurrentControl = null;
                }
            }
            catch { }
        }

        public void ShowControlNormally(Control c, String text, Icon icon)
        {
            WindowState = FormWindowState.Normal;
            Show();
            Width = c.Width + 10;
            Height = c.Height + 30;
            SetControl(c, true);
            Text = text;
            Icon = icon;
            DoResize();
        }

        public void SetControl(Control c)
        {
            SetControl(c, false);
        }

        public void SetControl(Control c, bool hide_pic)
        {
            this.BackColor = c.BackColor;
            CurrentControl = c;
            Controls.Add(c);

            try
            {
                if (c is ViewBase)
                {
                    ViewBase s = (ViewBase)c;
                    s.CloseRequest += new CloseHandler(s_CloseRequest);
                }
            }
            catch { }

            if (hide_pic)
                pic.Visible = false;
            else
                pic.BringToFront();
    
            DoResize();
        }

        public void s_CloseRequest(object sender, CloseArgs args)
        {
            try
            {
                if( args != null )
                    args.Handled = true;
                this.Close();
                this.Dispose();
            }
            catch { }
        }

        public void SetViewControl(ViewBase v)
        {
            SetControl(v);
            v.CloseRequest += new CloseHandler(v_CloseRequest);
            pic.Visible = false;
        }

        void v_CloseRequest(object sender, CloseArgs args)
        {
            this.Close();
            this.Dispose();
        }

        public void DoResize()
        {
            try
            {
                if (CurrentControl != null)
                {
                    CurrentControl.Left = 0;
                    CurrentControl.Top = 0;
                    CurrentControl.Width = this.ClientRectangle.Width;
                    CurrentControl.Height = this.ClientRectangle.Height;
                }
            }
            catch (Exception)
            { }

            try
            {
                pic.Left = this.ClientRectangle.Width - pic.Width;
                pic.Top = this.ClientRectangle.Height - pic.Height;
            }
            catch (Exception)
            { }

        }

        private void FormExternal_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void pic_Click(object sender, EventArgs e)
        {
            if (ShowInTab != null && CurrentControl != null)
            {
                LeaveInMemory = true;
                ShowInTab(CurrentControl, this.Text, this.TabID);
                this.Close();
                this.Dispose();
            }
        }

        public delegate void ShowInTabHandler(Control u, String caption, String id);
    }
}