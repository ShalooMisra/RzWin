using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin
{
    public partial class ViewBase : UserControl
    {
        public event CloseHandler CloseRequest;
        public ViewBase()
        {
            InitializeComponent();
        }

        public void CloseRequestSend()
        {
            if (CloseRequest != null)
            {
                CloseRequest(this, new CloseArgs());
            }
        }

        protected virtual void InitUn()
        {
            this.Resize -= new System.EventHandler(this.ViewBase_Resize);
        }

        private void ViewBase_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        protected virtual void DoResize()
        {
        }
    }
}
