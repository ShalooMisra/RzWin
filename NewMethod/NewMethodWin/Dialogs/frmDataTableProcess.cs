using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmDataTableProcess : Form
    {
        public static List<ColumnAction> GetActions(DataTable d)
        {
            frmDataTableProcess f = new frmDataTableProcess();
            f.CompleteLoad(d);
            f.ShowDialog();

            List<ColumnAction> ret = f.SelectedActions;

            try
            {
                f.Close();
                f.Dispose();
                f = null;
            }
            catch{}

            return ret;
        }

        public List<ColumnAction> SelectedActions;

        public frmDataTableProcess()
        {
            InitializeComponent();
        }

        public void CompleteLoad(DataTable d)
        {
            lv.Items.Clear();
            int ix = 0;
            foreach (DataColumn c in d.Columns)
            {
                ListViewItem i = lv.Items.Add(c.Caption);
                i.SubItems.Add("Compare");
                i.SubItems.Add(nData.NullFilter(d.Rows[0][ix]));
                i.Tag = ColumnAction.Compare;
                ix++;
            }
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {

        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAction(ColumnAction.Compare);
        }

        void SetAction(ColumnAction c)
        {
            try
            {
                ListViewItem i = lv.SelectedItems[0];
                i.Tag = c;
                i.SubItems[1].Text = c.ToString();
            }
            catch { }
        }

        private void coalesceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAction(ColumnAction.Coalesce);
        }

        private void sumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAction(ColumnAction.Sum);
        }

        private void firstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAction(ColumnAction.First);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedActions = null;
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedActions = new List<ColumnAction>();
            foreach (ListViewItem i in lv.Items)
            {
                SelectedActions.Add((ColumnAction)i.Tag);
            }
            this.Close();
        }
    }
}
