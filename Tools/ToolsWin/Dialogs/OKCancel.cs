using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin.Dialogs
{
    public partial class OKCancel : DialogBase
    {
        public OKCancel()
        {
            InitializeComponent();
        }

        String m_OKCaption = "OK";
        public String OKCaption
        {
            get
            {
                return m_OKCaption;
            }

            set
            {
                m_OKCaption = value;
            }
        }

        String m_CancelCaption = "Cancel";
        public String CancelCaption
        {
            get
            {
                return m_CancelCaption;
            }

            set
            {
                m_CancelCaption = value;
            }
        }

        public override void Init()
        {
            base.Init();
            cmdCancel.Text = CancelCaption;
            cmdOK.Text = OKCaption;
        }

        private void OKCancel_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public virtual void DoResize()
        {
            try
            {
                pContents.Left = 0;
                pContents.Top = 0;
                pContents.Width = this.ClientRectangle.Width;
                pContents.Height = this.ClientRectangle.Height - pOptions.Height;

                pOptions.Top = pContents.Bottom;
                pOptions.Left = 0;
                pOptions.Width = this.ClientRectangle.Width;

                cmdCancel.Left = 0;
                cmdCancel.Top = 0;
                //cmdCancel.Width = pOptions.ClientRectangle.Width / 2;

                //cmdCancel.Top = (pOptions.Height / 2) - (cmdCancel.Height / 2);

                cmdOK.Left = cmdCancel.Right;
                cmdOK.Top = 0;
                cmdOK.Width = pOptions.ClientRectangle.Width - cmdOK.Left;

                //cmdOK.Left = pOptions.Width - cmdOK.Width;
                //cmdOK.Top = (pOptions.Height / 2) - (cmdOK.Height / 2);
            }
            catch { }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        public virtual void Cancel()
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CloseMode)
            {
                this.Close();
                return;                   
            }
            else
                OK();
        }

        public virtual void OK()
        {
            this.Close();
        }

        public virtual void FocusSet()
        {

        }

        private void OKCancel_Activated(object sender, EventArgs e)
        {
            FocusSet();
        }

        protected void DisableButtons()
        {
            cmdOK.Enabled = false;
            cmdCancel.Enabled = false;
            this.ControlBox = false;
        }

        protected void EnableButtons()
        {
            cmdOK.Enabled = true;
            cmdCancel.Enabled = true;
            this.ControlBox = true;
        }

        bool CloseMode = false;
        protected void CloseSwitch()
        {
            cmdOK.Enabled = true;
            cmdOK.Text = "Close";
            cmdCancel.Enabled = false;
            CloseMode = true;
        }
    }
}
