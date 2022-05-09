using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Focus
{
    public partial class FocusItems : UserControl
    {
        public FocusItems()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            UnloadItems();
            fp.Controls.Clear();
            LoadItems();
        }

        void CompleteDispose()
        {
            try
            {
                foreach (Control c in fp.Controls)
                {
                    c.Dispose();
                }
            }
            catch { }
        }

        void LoadItems()
        {
            lv.Items.Clear();
            lv.BeginUpdate();
            bool wasSuppressed = suppress;
            suppress = true;
            try
            {
                ArrayList a = RzWin.Context.QtC("focus_item", "select * from focus_item where the_n_user_uid = '" + RzWin.User.unique_id + "' and isnull(is_done, 0) = 0 order by date_created");
                foreach (focus_item f in a)
                {
                    ListViewItem i = lv.Items.Add(f.name);
                    i.SubItems.Add(f.description);
                    i.ImageKey = f.item_type;
                    i.Tag = f;
                }
            }
            catch { }
            suppress = wasSuppressed;
            lv.EndUpdate();
        }

        void UnloadItems()
        {
            ArrayList a = new ArrayList(DisplayedItems);
            foreach (focus_item f in a)
            {
                HideItem(f);
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            CompleteLoad();
        }

        bool suppress = false;
        private void lv_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (suppress)
                return;

            if (e.Item.Checked)
                ShowItem((focus_item)e.Item.Tag);
            else
                HideItem((focus_item)e.Item.Tag);
        }

        ArrayList DisplayedItems = new ArrayList();

        void ShowItem(focus_item i)
        {
            IFocusControl c = RzWin.Leader.FocusAsControl(RzWin.Context, i, true);
            if (c == null)
                return;

            FocusItemHandle h = new FocusItemHandle();
            fp.Controls.Add(h);
            h.Width = fp.Width - 10;
            i.CurrentHandle = h;
            DisplayedItems.Add(i);
            h.CompleteLoad(i, c);
            h.DoneClicked += new EventHandler(h_DoneClicked);
        }

        void h_DoneClicked(object sender, EventArgs e)
        {
            try
            {
                FocusItemHandle h = (FocusItemHandle)sender;
                HideItem(h.xItem);
            }
            catch { }
        }

        void HideItem(focus_item i)
        {
            try
            {
                fp.Controls.Remove((Control)i.CurrentHandle);
                ((IDisposable)i.CurrentHandle).Dispose();
                i.CurrentHandle = null;
                DisplayedItems.Remove(i);
                i.CurrentHandle = null;

                ListViewItem li = GetListItem(i);
                if (li != null)
                {
                    suppress = true;
                    li.Checked = false;

                    if (i.is_done)
                    {
                        lv.Items.Remove(li);
                        RzWin.Form.RefreshInbox();

                    }
                    suppress = false;
                }
            }
            catch { }
        }

        ListViewItem GetListItem(focus_item f)
        {
            foreach (ListViewItem i in lv.Items)
            {
                if ((focus_item)i.Tag == f)
                    return i;
            }
            return null;
        }

        private void mnuDone_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList a = new ArrayList();
                foreach (ListViewItem i in lv.SelectedItems)
                {
                    a.Add(i);
                }

                foreach (ListViewItem i in a)
                {
                    focus_item f = (focus_item)i.Tag;
                    f.is_done = true;
                    f.is_viewed = true;
                    f.Update(RzWin.Context);

                    lv.Items.Remove(i);
                }
                RzWin.Form.RefreshInbox();

            }
            catch { }
        }

        private void FocusItems_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                lv.Width = this.ClientRectangle.Width / 3;
                cmdClearAll.Left = lv.Right - cmdClearAll.Width;

                lv.Height = this.ClientRectangle.Height - lv.Top;
                fp.Left = lv.Right;
                fp.Top = 0;
                fp.Height = this.ClientRectangle.Height;
                fp.Width = this.ClientRectangle.Width - fp.Left;

                foreach (Control c in fp.Controls)
                {
                    c.Width = fp.Width - 30;
                }
            }
            catch { }
        }

        private void cmdClearAll_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("mark " + Tools.Number.LongFormat(lv.Items.Count) + " " + nTools.Pluralize("Item", lv.Items.Count) + " as 'done'"))
                return;

            foreach (ListViewItem i in lv.Items)
            {
                focus_item f = (focus_item)i.Tag;
                f.is_done = true;
                f.is_viewed = true;
                f.Update(RzWin.Context);
            }

            CompleteLoad();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            ShowSelected();
        }

        void ShowSelected()
        {
            ArrayList a = new ArrayList();
            foreach (ListViewItem i in lv.SelectedItems)
            {
                a.Add(i);
            }

            foreach (ListViewItem i in a)
            {
                focus_item f = (focus_item)i.Tag;

                switch (f.item_type.ToLower())
                {
                    case "usernote":
                        usernote n = usernote.GetById(RzWin.Context, f.extra_info);
                        if (n != null)
                            RzWin.Context.Show(n);
                        break;

                }
            }
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            ShowSelected();
        }
    }
}
