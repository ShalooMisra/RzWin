using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin.Dialogs
{
    public partial class YesNo : ToolsWin.Dialogs.OKCancel
    {
        public static List<String> IgnoreIds = new List<string>();
        public static bool Ask(String ask)
        {
            return Ask(ask, "");
        }

        public static bool Ask(String ask, String ignore_id)
        {
            if (Tools.Strings.StrExt(ignore_id))
            {
                if (IgnoreIds.Contains(ignore_id.ToLower()))
                {
                    return true;
                }
            }

            YesNo yn = new YesNo();
            yn.Init();
            yn.Caption = ask;
            yn.IgnoreId = ignore_id;
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

        public static bool Ask(String ask, String ignore_id, ContentAlignment a)
        {
            if (Tools.Strings.StrExt(ignore_id))
            {
                if (IgnoreIds.Contains(ignore_id.ToLower()))
                {
                    return true;
                }
            }

            YesNo yn = new YesNo();
            yn.Init();
            yn.lblAsk.TextAlign = a;
            yn.Caption = ask;
            yn.IgnoreId = ignore_id;
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

        public bool Yes = false;

        String m_IgnoreId = "";
        public String IgnoreId
        {
            set
            {
                if (Tools.Strings.StrExt(value))
                {
                    cmdIgnore.Visible = true;
                    m_IgnoreId = value;
                }
                else
                {
                    cmdIgnore.Visible = false;
                    m_IgnoreId = "";
                }
            }
        }
        public YesNo()
        {
            InitializeComponent();

            OKCaption = "Yes";
            CancelCaption = "No";
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


        public String Caption
        {
            set
            {
                lblAsk.Text = value;
            }
        }

        private void cmdIgnore_Click(object sender, EventArgs e)
        {
            YesNo.IgnoreIds.Add(m_IgnoreId.ToLower());
            OK();
        }

        public override void DoResize()
        {
            base.DoResize();

            try
            {
                cmdIgnore.Left = pContents.ClientRectangle.Width - cmdIgnore.Width;
                cmdIgnore.Top = 0;
            }
            catch { }
        }
    }
}
