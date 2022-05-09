using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rz5.Win.Controls
{
    public partial class PathStep : UserControl
    {
        public event MenuOpeningHandler MenuOpening;
        public event MenuClickHandler MenuClicked;
        public PathStep()
        {
            InitializeComponent();
        }

        public void Init(CompletionStatus status)
        {
            Init(status, "", "");
        }

        public void Init(CompletionStatus status, String act, String info)
        {
            CurrentStatus = status;
            if (Tools.Strings.StrExt(act))
            {
                lblAction.Visible = true;
                lblAction.Text = act;
                lblAction.Tag = act;
                lblCaption.TextAlign = ContentAlignment.TopCenter;

            }
            else
            {
                //lblCaption.TextAlign = ContentAlignment.MiddleCenter;
                lblCaption.TextAlign = ContentAlignment.TopCenter;
                lblAction.Visible = false;
            }

            if (Tools.Strings.StrExt(info))
            {
                lblInfo.Visible = true;
                lblInfo.Text = info;
            }
            else
                lblInfo.Visible = false;
        }

        String m_Caption = "";
        public String Caption
        {
            get
            {
                return m_Caption;
            }

            set
            {
                m_Caption = value;
                lblCaption.Text = value;
            }
        }

        CompletionStatus m_CompletionStatus = CompletionStatus.Skip;
        public CompletionStatus CurrentStatus
        {
            get
            {
                return m_CompletionStatus;
            }

            set
            {
                m_CompletionStatus = value;
                switch (m_CompletionStatus)
                {
                    case CompletionStatus.Skip:
                        lblCaption.BackColor = Color.Gray;
                        lblCaption.ForeColor = Color.White;
                        break;
                    case CompletionStatus.Open:
                        lblCaption.BackColor = Color.White;
                        lblCaption.ForeColor = Color.Black;
                        break;
                    case CompletionStatus.Working:
                        lblCaption.BackColor = Color.Yellow;
                        lblCaption.ForeColor = Color.Black;
                        break;
                    case CompletionStatus.Completed:
                        lblCaption.BackColor = Color.Green;
                        lblCaption.ForeColor = Color.White;
                        break;
                    case CompletionStatus.Problem:
                        lblCaption.BackColor = Color.Red;
                        lblCaption.ForeColor = Color.White;
                        break;
                }

                lblAction.BackColor = lblCaption.BackColor;
                lblInfo.BackColor = lblCaption.BackColor;
            }
        }

        private void mnu_Opening(object sender, CancelEventArgs e)
        {
            List<String> menu = null;
            if (MenuOpening != null)
            {
                menu = MenuOpening();

                if (menu.Count == 0)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                e.Cancel = true;
                return;
            }

            MenuClear();

            foreach (String s in menu)
            {
                ToolStripItem i = mnu.Items.Add(s);
                i.Tag = s;
                i.Click += new EventHandler(i_Click);
            }
        }

        void i_Click(object sender, EventArgs e)
        {
            if (MenuClicked != null)
            {
                try
                {
                    MenuClicked((String)((ToolStripItem)sender).Tag);
                }
                catch { }
            }
        }

        void MenuClear()
        {
            try
            {
                foreach (ToolStripItem i in mnu.Items)
                {
                    i.Click -= new EventHandler(i_Click);
                }

                mnu.Items.Clear();
            }
            catch { }
        }

        private void lblCaption_MouseDown(object sender, MouseEventArgs e)
        {
            mnu.Show(Cursor.Position);
        }

        private void lblAction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MenuClicked != null)
                MenuClicked((String)lblAction.Tag);
        }

        bool m_HideBars = false;
        public bool HideBars
        {
            get
            {
                return m_HideBars;
            }

            set
            {
                m_HideBars = value;
                picRight.Visible = !value;
                picLeft.Visible = !value;
            }
        }

        public void SetEnabled(bool enabled)
        {
            this.Enabled = enabled;
            lblAction.Enabled = enabled;
        }
    }

    public delegate List<String> MenuOpeningHandler();
    public delegate void MenuClickHandler(String option);
}
