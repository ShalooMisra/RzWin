using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;
using ToolsWin;
using NewMethod;

namespace Rz5.Focus
{
    public partial class FocusItemHandle : UserControl
    {
        public event CloseHandler CloseRequest;
        public focus_item xItem = null;
        IFocusControl xControl = null;

        public event EventHandler DoneClicked;

        public FocusItemHandle()
        {
            InitializeComponent();
        }

        public void SetWidth(Control c)
        {
            this.Width = c.Width + cmdDone.Right + 2 + 4;
        }

        public void HideLines()
        {
            pbBottom.Visible = false;
            pbTop.Visible = false;
            pbLeft.Visible = false;
            pbRight.Visible = false;
        }

        public void CompleteLoad(focus_item f, IFocusControl c)
        {
            xItem = f;
            xControl = c;

            Control cc = (Control)c;

            Controls.Add(cc);
            //this.Width = c.Width + cmdDone.Right + 2;
            this.Height = cc.Height + 8;

            try
            {
                if (cc is nView)
                {
                    nView s = (nView)cc;
                    s.CloseRequest += new CloseHandler(s_CloseRequest);
                }
            }
            catch { }

            DoResize();
        }

        void s_CloseRequest(object sender, CloseArgs args)
        {
            xControl.CompleteSave();
            if (DoneClicked != null)
                DoneClicked(this, null);
        }

        public void DoResize()
        {
            if( xControl == null )
                return;

            try
            {
                Control cc = (Control)xControl;
                cc.Left = cmdDone.Right + 2;
                cc.Top = 4;
                cc.Width = this.ClientRectangle.Width - (cc.Left + 4);
                cc.Height = this.ClientRectangle.Height -8;
            }
            catch { }
        }

        private void cmdDone_Click(object sender, EventArgs e)
        {
            xControl.CompleteSave();

            xItem.is_viewed = true;
            xItem.is_done = true;
            xItem.Update(RzWin.Context);

            if( DoneClicked != null )
                DoneClicked(this, null);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            xControl.CompleteSave();
            if (DoneClicked != null)
                DoneClicked(this, null);
            else if (CloseRequest != null)
                CloseRequest(this, null);
        }

        private void FocusItemHandle_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
