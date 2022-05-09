using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CoreWin
{
    public partial class StatusView : UserControl
    {
        ArrayList AllLines;

        public StatusView()
        {
            AllLines = new ArrayList();
            InitializeComponent();

            AddControl(true);
            AddControl(false);
            AddControl(false);
            AddControl(false);
            AddControl(false);
            AddControl(false);
            AddControl(false);
            AddControl(false);
 
            DoResize();
        }

        public nStatusLine GetLineByIndex(Int32 index)
        {
            return (nStatusLine)AllLines[index];
        }

        public void AddControl(bool visible)
        {
            nStatusLine l = new nStatusLine();
            l.SetStatus("");
            l.SetProgress(0);
            l.Visible = visible;
            this.Controls.Add(l);
            AllLines.Add(l);
        }

        public void AddLine()
        {
            int c = GetVisibleCount();

            if (c >= AllLines.Count)
                AddControl(false);

            nStatusLine l = (nStatusLine)AllLines[c];
            l.Visible = true;
            DoResize();
        }

        public void RemoveLine()
        {
            Int32 c = GetVisibleCount();

            if (c <= 1)
                return;

            nStatusLine l = (nStatusLine)AllLines[c - 1];
            //AllLines.Remove(l);
            //this.Controls.Remove(l);
            l.Visible = false;
            DoResize();
        }

        public void SetStatusByIndex(Object sender, StatusArgs args)
        {
            GetLineByIndex(args.index).SetStatus(args.status);
        }

        public void SetProgressByIndex(Object sender, ProgressArgs args)
        {
            GetLineByIndex(args.index).SetProgress(args.progress);
        }

        public void SetActivityByIndex(Object sender, ActivityArgs args)
        {

        }

        private void nStatusView_Load(object sender, EventArgs e)
        {

        }

        private void nStatusView_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private Int32 GetVisibleCount()
        {
            Int32 i = 0;
            foreach (nStatusLine l in AllLines)
            {
                if (l.Visible)
                    i++;
            }
            return i;
        }

        private void DoResize()
        {
            Int32 theta = 10;
            Int32 level;
            Int32 left = 0;

            Int32 visible_count = GetVisibleCount();

            try
            {
                foreach (nStatusLine l in AllLines)
                {
                    if (l.Visible)
                    {
                        l.Left = left;
                        l.Width = ((this.ClientRectangle.Width - (theta * (visible_count - 1))) / visible_count);
                        left += l.Width + theta;
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
