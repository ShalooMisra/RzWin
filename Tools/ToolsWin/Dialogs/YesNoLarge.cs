using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin.Dialogs
{
    public partial class YesNoLarge : OKCancel
    {
        public bool Yes = false;

        public String Caption
        {
            set
            {
                RT.Text = value;
            }
        }

        public YesNoLarge()
        {
            InitializeComponent();
        }
        public static bool AskLarge(String ask, string title = "Are you sure?")
        {
            YesNoLarge yn = new YesNoLarge();
            yn.lblTitle.Text = title;
            yn.Init();
            yn.OKCaption = "Yes";
            yn.CancelCaption = "No";
            yn.Caption = ask;
            yn.ShowDialog();
            bool ret = yn.Yes;
            try
            {
                yn.Close();
                yn.Dispose();
                yn = null;
            }
            catch { }

            return ret;
        }

        public override void OK()
        {
            Yes = true;
            base.OK();
        }
        public override void Cancel()
        {
            Yes = false;
            base.Cancel();
        }
    }
}
