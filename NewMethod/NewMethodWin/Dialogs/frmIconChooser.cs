using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmIconChooser : Form
    {
        public String SelectedKey = "";

        public frmIconChooser()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static String Choose(SysNewMethod xs, IWin32Window owner)
        {
            NMWin.Leader.Reorg();
            return "";
            //SysNewMethod.xChooseIcon.ShowDialog(owner);
            //String r = SysNewMethod.xChooseIcon.SelectedKey;
            //SysNewMethod.xChooseIcon.Hide();
            //return r;
        }
        //Public Functions
        public void CompleteLoad(SysNewMethod xs)
        {
            tv.BeginUpdate();
            LoadSystem(xs, tv.Nodes);
            tv.ExpandAll();
            tv.EndUpdate();
        }
        //Private Functions
        private void LoadSystem(SysNewMethod xs, TreeNodeCollection nodes)
        {
            TreeNode n = nodes.Add("Available Pictures");
            n.ImageKey = "NM";
            n.SelectedImageKey = "NM";
            String[] ary = xs.GetResourceList();
            if (ary != null)
            {
                for (Int32 ii = ary.Length - 1; ii > -1; ii--)
                {
                    String k = nTools.Replace(ary[ii], xs.Name + "_Resources.", "");
                    TreeNode x = n.Nodes.Add(k);
                    x.Tag = k;
                    Image i = xs.GetResourceImage(k);
                    if (i != null)
                    {
                        x.ImageIndex = il.Images.Add(i, Color.Magenta);
                        x.SelectedImageIndex = x.ImageIndex;
                    }
                }
            }
        }
        private void DoOK()
        {
            try
            {
                TreeNode n = tv.SelectedNode;
                if (n == null)
                    return;
                String s = (String)n.Tag;
                if (!Tools.Strings.StrExt(s))
                    return;
                SelectedKey = s;
                this.Hide();
            }
            catch { }
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedKey = "";
            this.Hide();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            DoOK();
        }
        //Control Events
        private void tv_DoubleClick(object sender, EventArgs e)
        {
            DoOK();
        }
    }
}