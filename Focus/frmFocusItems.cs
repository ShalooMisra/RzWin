using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using NewMethod;



namespace Rz5.Focus
{
    public partial class frmFocusItems : Form
    {
        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static int SW_SHOWNOACTIVATE = 4;
        static IntPtr HWND_TOPMOST = (IntPtr)(-1);
        static uint SWP_NOACTIVATE = 0x0010;

        public static frmFocusItems TheShowForm = null;
        public static void ShowItems(ArrayList a, Point p)
        {
            if (TheShowForm == null)
            {
                TheShowForm = new frmFocusItems();
                TheShowForm.Text = "Inbox Items";
                TheShowForm.Icon = RzWin.Form.Icon;
                TheShowForm.ShowInTaskbar = true;
            }

            TheShowForm.ShowItemArray(a);

            bool b = ShowWindow(TheShowForm.Handle, SW_SHOWNOACTIVATE);
            bool x = SetWindowPos(TheShowForm.Handle, HWND_TOPMOST, p.X - TheShowForm.Width, p.Y - TheShowForm.Height, TheShowForm.Width, TheShowForm.Height, SWP_NOACTIVATE);
            if (TheShowForm.Top < 0)
                TheShowForm.Top = 0;
        }

        public frmFocusItems()
        {
            InitializeComponent();
            Clear();
            OriginalWidth = this.ClientRectangle.Width;
        }
        int OriginalWidth = 0;

        ArrayList ItemControls = new ArrayList();
        ArrayList ItemIDs = new ArrayList();
        int CurrentTop = 0;
        public void ShowItemArray(ArrayList a)
        {
            foreach (focus_item i in a)
            {
                if (!ItemIDs.Contains(i.unique_id))
                {
                    FocusItemPreview p = new FocusItemPreview();
                    Controls.Add(p);
                    ItemControls.Add(p);
                    ItemIDs.Add(i.unique_id);
                    p.Top = CurrentTop;
                    p.Left = pbLeft.Width;
                    p.Width = OriginalWidth - (pbLeft.Width * 2);
                    p.CompleteLoad(i);
                    CurrentTop += p.Height;
                }
            }
            this.Height = CurrentTop;
            lblCaption.Text = Tools.Number.LongFormat(ItemControls.Count) + " " + nTools.Pluralize("Item", ItemControls.Count);
            lblViewAll.Visible = (ItemControls.Count > 1);
        }

        public void Clear()
        {
            CurrentTop = picbar.Bottom + 2;
            foreach (FocusItemPreview p in ItemControls)
            {
                Controls.Remove(p);
                p.Dispose();
            }
            ItemControls.Clear();
            ItemIDs.Clear();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clear();
        }

        private void lblViewAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Form.ShowFocusInbox();
        }

        private void cmdMinimize_Click(object sender, EventArgs e)
        {
            this.Text = "Inbox Items";
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Minimized;
        }
    }
}