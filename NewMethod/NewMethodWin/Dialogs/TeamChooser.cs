using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ToolsWin;

namespace NewMethod.Win.Dialogs
{
    public partial class TeamChooser : ToolsWin.Dialogs.OKCancel
    {
        public static n_team Choose(ContextNM q)
        {
            TeamChooser c = new TeamChooser();
            c.Init(q);
            c.ShowDialog();
            n_team ret = c.TeamSelected;

            try
            {
                c.Close();
                c.Dispose();
                c = null;
            }
            catch { }

            return ret;
        }

        public n_team TeamSelected = null;

        public TeamChooser()
        {
            InitializeComponent();
        }

        public void Init(ContextNM q)
        {
            lv.Items.Clear();
            lv.BeginUpdate();

            try
            {
                foreach (DictionaryEntry d in q.xSys.Teams.AllByName)
                {
                    n_team t = (n_team)d.Value;
                    ListViewItem i = lv.Items.Add(t.name);
                    i.SubItems.Add(t.MemberOverview(q));
                    i.Tag = t;
                }
            }
            catch { }

            lv.EndUpdate();
        }

        public override void InitUn()
        {
            lv.Items.Clear();
            base.InitUn();
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            OK();
        }

        public override void OK()
        {
            try
            {
                ListViewItem i = lv.SelectedItems[0];
                TeamSelected = (n_team)i.Tag;
            }
            catch
            {
                TeamSelected = null;
                return;
            }

            base.OK();
        }

        public override void Cancel()
        {
            TeamSelected = null;
            base.Cancel();
        }
    }
}
