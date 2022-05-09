using System;


namespace ToolsWin.Dialogs
{
    public partial class OkCancelFormatting : DialogBase
    {
        public OkCancelFormatting()
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


        }

        public static bool AskOkCancel(string title, string body)
        {
            OkCancelFormatting o = new OkCancelFormatting();
            o.Init();
            o.OKCaption = "Yes";
            o.CancelCaption = "No";
            o.rtBody.Text = body;
            o.rtTitle.Text = title;
            o.rtTitle.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            o.ShowDialog();
            bool ret = false;
            switch (o.DialogResult)
            {
                case System.Windows.Forms.DialogResult.Yes:
                    {
                        ret = true;
                        break;
                    }
                default:
                    {
                        ret = false;
                        break;
                    }
            }
            try
            {
                o.Close();
                o.Dispose();
                o = null;
            }
            catch { }

            return ret;
        }

        private void OKCancel_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public virtual void DoResize()
        {
            try
            {
                
                rtTitle.Top = 0;
                rtTitle.Width = this.ClientRectangle.Width;
                rtTitle.Height = 30;


                rtBody.Left = 0;
                rtBody.Top = rtTitle.Bottom + 1;
                rtBody.Width = this.ClientRectangle.Width;
                rtBody.Height = this.ClientRectangle.Height - pOptions.Height - rtTitle.Height;

                pOptions.Top = rtBody.Bottom;
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
            DialogResult = System.Windows.Forms.DialogResult.No;
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
            DialogResult = System.Windows.Forms.DialogResult.Yes;
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
