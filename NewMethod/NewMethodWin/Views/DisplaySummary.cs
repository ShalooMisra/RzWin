using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod.Grids
{
    public partial class DisplaySummary : UserControl
    {
        public ContextNM TheContext;
        public Summary TheSummary;

        public DisplaySummary()
        {
            InitializeComponent();
        }

        public virtual void Init(ContextNM context, Summary summary)
        {
            TheContext = context;
            TheSummary = summary;
            TheSummary.Init(context);

            details.ShowTemplate(summary.TheTemplate, summary.TheClass);
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            lv.Items.Clear();
            lv.Columns.Clear();
            TheSummary.Calc();

            ColumnHeader cn = lv.Columns.Add(TheSummary.YCaption);
            cn.Width = 200;

            foreach (SummaryColumn c in TheSummary.Columns)
            {
                ColumnHeader cx = lv.Columns.Add(c.Name);
                cx.Width = (lv.Width - cn.Width) / TheSummary.Columns.Count;
            }

            foreach (SummaryRow r in TheSummary.Rows)
            {
                ListViewItem item = lv.Items.Add(r.Name);
                item.Tag = r;
                foreach (SummaryValue v in r.Values)
                {
                    item.SubItems.Add(v.Count.ToString());
                }
            }
        }

        private void DisplaySummary_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                pOptions.Left = 0;
                pOptions.Top = 0;
                pOptions.Height = this.ClientRectangle.Height;

                sp.Top = 0;
                sp.Left = pOptions.Right;
                sp.Height = this.ClientRectangle.Height;
                sp.Width = this.ClientRectangle.Width - sp.Left;

                lv.Left = 0;
                lv.Top = 0;
                lv.Width = sp.Panel1.ClientRectangle.Width;
                lv.Height = sp.Panel1.ClientRectangle.Height;

                details.Left = 0;
                details.Top = 0;
                details.Width = sp.Panel2.ClientRectangle.Width;
                details.Height = sp.Panel2.ClientRectangle.Height;
            }
            catch { }
        }

        private void lv_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewItem cell = lv.GetItemAt(e.X, e.Y);
                int cell_index = 0;
                int cell_left = 0;
                foreach (ColumnHeader h in lv.Columns)
                {
                    cell_left += h.Width;
                    if (e.X <= cell_left)
                        break;
                    cell_index++;
                }

                ClickHandle(cell, cell_index);
            }
            catch{}
        }

        protected virtual void ClickHandle(ListViewItem item, int column_index)
        {
            if (column_index < 1)
                return;

            try
            {
                SummaryColumn c = TheSummary.Columns[column_index - 1];
                SummaryRow r = (SummaryRow)item.Tag;
                ClickHandle(r, c);
            }
            catch { }
        }

        protected virtual void ClickHandle(SummaryRow row, SummaryColumn col)
        {
            details.ShowData(TheSummary.ListArgsGet(row, col));
        }

        private void sp_SplitterMoved(object sender, SplitterEventArgs e)
        {
            DoResize();
        }
    }
}
