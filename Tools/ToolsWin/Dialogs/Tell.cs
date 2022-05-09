using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using ToolsWin;

namespace ToolsWin.Dialogs
{
    public partial class Tell : DialogBase
    {
        public static void TellModal(String message)
        {
            TellModal(null, message, message);
        }

        public static void TellModal(IWin32Window owner, String caption, String message)
        {
            Tell t = new Tell();
            t.Init(caption, message);
            t.FormBorderStyle = FormBorderStyle.Sizable;
            t.ModalPrepare();
            t.ShowDialog(owner);           

            try
            {
                t.Close();
                t.Dispose();
                t = null;
            }
            catch { }
        }

        public static void TellTemp(IWin32Window owner, String caption, String message, int seconds)
        {
            Tell t = new Tell();
            t.Init(caption, message);
            t.TempStart(seconds);
            t.ShowDialog(owner);              
            try
            {
                t.Close();
                t.Dispose();
                t = null;
            }
            catch { }
        }

        int ticks = 4;
        bool modalIs = false;
        public Tell()
        {
            InitializeComponent();
            this.Icon = null;
        }

        public void Init(String caption, String message)
        {
            base.Init();
            this.Text = caption;
            txtMessage.Text = message;
        }

        public void ModalPrepare()
        {
            txtMessage.BringToFront();
            cmdWait.BringToFront();
            cmdWait.Text = "OK";
            modalIs = true;
            DoResize();
            //txtMessage.Dock = DockStyle.Fill;
        }

        public void TempStart(int seconds)
        {
            lblTicks.Visible = true;
            ticks = seconds;
            tmrClose.Start();
        }

        public void SetCaption(String s)
        {
            txtMessage.Text = s;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdWait_Click(object sender, EventArgs e)
        {
            if (modalIs)
            {
                this.Close();
            }
            else
            {
                tmrClose.Stop();
                ModalPrepare();
            }
        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            ticks--;
            if (ticks == 0)
                this.Close();
            else
            {
                lblTicks.Text = ticks.ToString();
            }
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void Tell_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                if (modalIs)
                {

                    txtMessage.Left = 5;
                    txtMessage.Top = 5;
                    //If the lblTicks is Visible, resize to accomodate.
                    txtMessage.Width = this.ClientRectangle.Width;
                    if(lblTicks.Visible)
                        txtMessage.Width -= (lblTicks.Width + 5);
                    //txtMessage.Height = this.ClientRectangle.Height - (cmdWait.Height + 15);
                    //This will resize the modal to accomodate more or less text (lines)
                    int txtHeight = TextRenderer.MeasureText(txtMessage.Text, txtMessage.Font, txtMessage.ClientSize, TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl).Height;
                    txtMessage.Height = txtHeight + 15;

                    cmdWait.Top = txtMessage.Bottom + 5;
                    cmdWait.Left = (this.ClientRectangle.Width / 2) - (cmdWait.Width / 2);
                }
            }
            catch { }
        }
    }
}