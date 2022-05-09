using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin.Dialogs
{
    public partial class AreYouSure : ToolsWin.Dialogs.OKCancel
    {
        public static bool Ask(String ask)
        {
            return Ask(null, ask);
        }

        public static bool Ask(IWin32Window owner, String ask)
        {
            AreYouSure ays = new AreYouSure();
            ays.Init(ask);
            ays.ShowDialog(owner);

            bool ret = ays.Yes;

            try
            {
                ays.Close();
                ays.Dispose();
                ays = null;
            }
            catch { }

            return ret;
        }

        bool Yes = false;
        public AreYouSure()
        {
            InitializeComponent();
            OKCaption = "Yes";
            CancelCaption = "No";
        }

        public void Init(String ask)
        {
            base.Init();
            this.Text = "Sure?";
            lblAsk.Text = "Are you sure you want to " + ask + "?";
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
