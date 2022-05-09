using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;
using Core;

namespace NewMethod
{
    public partial class nClip : UserControl
    {
        //Public Static Variables
        
        //Public Delegates
        public delegate void ClipEventHandler(GenericEvent e);
        //Public Events
        public event ClipEventHandler OnClipEvent;        
        //Public Variables
        public n_user CurrentUser;
        //Private Variables
        private n_clip CurrentClip;
        
        //Constructors
        public nClip()
        {
            InitializeComponent();
        }
        //Public Functions
        public void DoResize()
        {
            wb.Top = 0;
            wb.Left = 0;
            wb.Width = sc.Panel2.ClientRectangle.Width;
            wb.Height = sc.Panel2.ClientRectangle.Height - lblRefresh.Height;

            //wb.Left = 0;
            //wb.Top = 0;
            //wb.Width = sc.Panel2.ClientRectangle.Width;
            //wb.Height = sc.Panel2.ClientRectangle.Height - lblRefresh.Height;
            //lblRefresh.Top = sc.Panel2.ClientRectangle.Height - lblRefresh.Height;

            tv.Left = 0;
            tv.Top = 0;
            tv.Width = sc.Panel1.Width;
            tv.Height = sc.Panel1.Height - chkBlock.Height;

            chkBlock.Left = 0;
            chkBlock.Top = tv.Bottom;

            lblRefresh.Left = 0;
            lblRefresh.Top = wb.Bottom;
            lblRefresh.Width = wb.Width;
        }
        public void CompleteLoad()
        {
            tv.BeginUpdate();
            tv.Nodes.Clear();
            tv.EndUpdate();

            if (CurrentUser == null)
                return;

            if (CurrentUser.RootClip == null)
                return;

            ShowClips();
            sc.SplitterDistance = sc.Width / 2;
        }
        public void ShowClips()
        {
            tv.BeginUpdate();
            tv.Nodes.Clear();
            //Adds all the clips to the node tree
            CurrentUser.RootClip.ShowClip(tv.Nodes);
            //Aut-expands the node tree
            CurrentUser.RootClip.MyNode.Expand();
            tv.EndUpdate();

            chkBlock.Checked = CurrentUser.GetSetting_Boolean(NMWin.ContextDefault, "auto_clip");
            n_clip.AutoClip = chkBlock.Checked;

            ShowClip(CurrentUser.RootClip);
        }
        public void ReShowClip()
        {
            ShowClip(CurrentClip);
        }
        public void ShowClip(n_clip c)
        {
            if (c == null)
                return;

            wb.ReloadWB();
            CurrentClip = c;
            if (CurrentClip.ClipType == NewMethod.Enums.ClipType.Instance)
            {
                CurrentClip.RefreshSummary(NMWin.ContextDefault);
                wb.Add("<html><body>" + CurrentClip.summary + "</body></html>");
            }
            else if (CurrentClip.IsRoot())
                wb.Add("<html><body>" + CurrentUser.GetClipHTML(NMWin.ContextDefault) + "</body></html>");

            RefreshRefresh();
        }
        public n_clip GetSelectedClip()
        {
            TreeNode n = tv.SelectedNode;
            if (n == null)
                return null;

            return (n_clip)n.Tag;
        }
        public nObject GetSelectedObject()
        {
            n_clip c = GetSelectedClip();
            if (c == null)
                return null;
            return c.GetInstanceObject(NMWin.ContextDefault);
        }
        public nObjectHandle GetSelectedHandle()
        {
            n_clip c = GetSelectedClip();
            if (c == null)
                return null;
            return c.GetInstanceHandle();
        }
        //Private Functions
        private void AddNewFolder()
        {
            n_clip c = GetSelectedClip();
            if (c == null)
                return;

            n_clip n = n_clip.New(NMWin.ContextDefault);
            n.ClipType = NewMethod.Enums.ClipType.Folder;
            n.name = "New Folder";
            n.is_expanded = true;
            n.the_n_user_uid = CurrentUser.unique_id;
            n.the_n_clip_uid = c.unique_id;
            NMWin.ContextDefault.Insert(n);

            n.Clear();

            c.Add(n);
            n.MyNode.EnsureVisible();
        }
        private void RefreshRefresh()
        {
            if (CurrentClip == null)
            {
                lblRefresh.Text = "Refresh";
                lblRefresh.Enabled = false;
                return;
            }

            if (CurrentClip.ClipType != NewMethod.Enums.ClipType.Instance)
            {
                lblRefresh.Text = "Refresh";
                lblRefresh.Enabled = false;
                return;
            }

            if (CurrentClip.IsRoot())
            {
                lblRefresh.Text = "Refresh";
                lblRefresh.Enabled = false;
                return;
            }

            lblRefresh.Enabled = true;
            if (!Tools.Dates.DateExists(CurrentClip.last_update))
                CurrentClip.last_update = CurrentClip.date_created;

            TimeSpan ts = System.DateTime.Now.Subtract(CurrentClip.last_update);

            int i = 0;
            try
            {
                i = Convert.ToInt32(ts.TotalSeconds);
            }
            catch (Exception)
            { }

            lblRefresh.Text = "< click to refresh>  (updated " + Tools.Dates.FormatHMS(i) + " ago)";
        }
        private void ShowCurrentObject()
        {
            nObjectHandle h = GetSelectedHandle();
            if (h == null)
                return;
            nObject o = h.GetObject(NMWin.ContextDefault);
            if (o == null)
                return;
            NMWin.ContextDefault.Show(new ShowArgs(NMWin.ContextDefault, o));
        }
        //Control Events
        private void nClip_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void tv_Click(object sender, EventArgs e)
        {
            TreeNode n = tv.SelectedNode;
            if (n == null)
                return;

            n_clip c = (n_clip)n.Tag;
            if (c == null)
                return;

            ShowClip(c);
        }
        private void tv_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            tv.LabelEdit = false;
            if (Tools.Strings.StrExt(e.Label))
            {
                n_clip c = (n_clip)e.Node.Tag;
                if (c != null)
                {
                    c.name = e.Label;
                    NMWin.ContextDefault.Update(c);
                }
                e.Node.Text = e.Label;
            }
        }
        private void tv_MouseDown(object sender, MouseEventArgs e)
        {
            try { tv.SelectedNode = tv.GetNodeAt(new Point(e.X, e.Y)); }
            catch { }
        }
        private void tv_ItemDrag(object sender, ItemDragEventArgs e)
        {
            try
            {
                TreeNode t = (TreeNode)e.Item;
                n_clip c = (n_clip)t.Tag;
                if (c.IsRoot())
                    return;

                tv.DoDragDrop(t, DragDropEffects.Move);
            }
            catch (Exception)
            { }
        }
        private void tv_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode dragNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

                // Get the target node from the mouse coords
                Point pt = tv.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = tv.GetNodeAt(pt);

                n_clip dc = (n_clip)dragNode.Tag;
                if (dc == null)
                    return;

                n_clip dt = (n_clip)targetNode.Tag;
                if (dt == null)
                    return;

                if (Tools.Strings.StrCmp(dc.unique_id, dt.unique_id))
                    return;

                dc.MyNode.Parent.Nodes.Remove(dc.MyNode);
                dc.ParentClip.RemoveClip(dc);

                dt.MyNode.Nodes.Add(dc.MyNode);
                dc.ParentClip = dt;
                dt.AllClips.Add(dc);
                dc.the_n_clip_uid = dt.unique_id;
                NMWin.ContextDefault.Update(dc);
                dc.MyNode.EnsureVisible();
            }
        }
        private void tv_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            return;
        }
        private void tv_DragOver(object sender, DragEventArgs e)
        {
            return;

            TreeNode n = tv.GetNodeAt(new Point(e.X, e.Y));
            if (n == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            n_clip c = (n_clip)n.Tag;
            if (c == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if (c.IsRoot() || c.ClipType == NewMethod.Enums.ClipType.Folder)
            {
                e.Effect = DragDropEffects.Move;
                tv.SelectedNode = n;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void tv_DoubleClick(object sender, EventArgs e)
        {
            ShowCurrentObject();
        }
        private void wb_OnNavigate(GenericEvent e)
        {
            if (e.Message.ToLower().Trim().EndsWith(".rzl"))
            {
                String[] s = Tools.Strings.Split(e.Message, "/");
                String l = s[s.Length - 1];
                l = Tools.Strings.ParseDelimit(l, ".", 1);


                if (Tools.Strings.StrExt(l))
                {
                    if (OnClipEvent != null)
                    {
                        GenericEvent ge = new GenericEvent();
                        ge.Message = l;
                        OnClipEvent(ge);
                    }
                    e.Handled = true;
                }
            }

            if (Tools.Strings.HasString(e.Message, "show_object.rzl/?"))
            {
                e.Handled = true;
                String k = Tools.Strings.ParseDelimit(e.Message, ".rzl/?", 2);
                NMWin.ContextDefault.xSys.ThrowByKey(NMWin.ContextDefault, k);
                return;
            }

        }
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            RefreshRefresh();
        }
        private void lblRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentClip == null)
                return;

            CurrentClip.RefreshSummary(NMWin.ContextDefault);

            if (CurrentClip.MyNode != null)
                CurrentClip.MyNode.Text = CurrentClip.name;

            NMWin.ContextDefault.Update(CurrentClip);
            ShowClip(CurrentClip);
            RefreshRefresh();
        }
        private void sc_SplitterMoved(object sender, SplitterEventArgs e)
        {
            DoResize();
        }
        private void chkBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentUser == null)
                return;
            CurrentUser.SetSetting_Boolean(NMWin.ContextDefault, "auto_clip", chkBlock.Checked);
            n_clip.AutoClip = chkBlock.Checked;
        }
        //Menus
        private void mnuRename_Click(object sender, EventArgs e)
        {
            if (tv.SelectedNode == null)
                return;

            tv.SelectedNode.Text = tv.SelectedNode.Text.Replace("~", "");
            tv.LabelEdit = true;
            tv.SelectedNode.BeginEdit();
        }
        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            n_clip c = GetSelectedClip();
            if (c == null)
                return;

            if( c.ClipType != NewMethod.Enums.ClipType.Instance )
                return;

            nObject o = c.GetInstanceObject(NMWin.ContextDefault);
            if (o == null)
                return;

            c.name = "~" + o.ToString();
            NMWin.ContextDefault.Update(c);
            c.UpdateNodes();
        }
        private void mnuNewFolder_Click(object sender, EventArgs e)
        {
            AddNewFolder();
        }
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            ShowCurrentObject();
        }
        private void mnuClip_Opening(object sender, CancelEventArgs e)
        {
            n_clip c = GetSelectedClip();
            if (c == null)
            {
                e.Cancel = true;
                return;
            }

            if (c.ClipType == NewMethod.Enums.ClipType.Folder || c.IsRoot())
            {
                mnuNewFolder.Visible = true;
                sepNewFolder.Visible = true;
                mnuOpen.Visible = false;
                mnuRefresh.Visible = true;
            }
            else
            {
                mnuNewFolder.Visible = false;
                sepNewFolder.Visible = false;
                mnuOpen.Visible = true;
                mnuRefresh.Visible = true;
            }

            if (c.IsRoot() || c.ClipType == NewMethod.Enums.ClipType.Folder)
                mnuClearItems.Visible = true;
            else
                mnuClearItems.Visible = false;
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            n_clip c = GetSelectedClip();
            if( c == null )
                return;

            if (c.IsRoot())
            {
                NMWin.Leader.Tell("The main clipboard branch cannot be removed.");
                return;
            }

            if (!NMWin.Leader.AreYouSure("delete item " + c.name))
                return;

            c.CompleteDelete(NMWin.ContextDefault);
            tv.Nodes.Remove(c.MyNode);
        }
        private void mnuClearItems_Click(object sender, EventArgs e)
        {
            n_clip c = GetSelectedClip();
            if (c == null)
                return;

            if (!(c.IsRoot() || c.ClipType == NewMethod.Enums.ClipType.Folder))
                return;

            if (!NMWin.Leader.AreYouSure("clear the clipboard folder " + c.name))
                return;

            if (c.IsRoot())
            {
                NMWin.Data.Execute("delete from n_clip where the_n_user_uid = '" + CurrentUser.unique_id + "'");
                c.Clear();
                CompleteLoad();
                return;
            }

            foreach (n_clip x in c.AllClips)
            {
                if (!x.IsRoot() && x.ClipType != NewMethod.Enums.ClipType.Folder)
                {
                    x.CompleteDelete(NMWin.ContextDefault);
                    tv.Nodes.Remove(x.MyNode);
                }
            }
        }
    }
}
