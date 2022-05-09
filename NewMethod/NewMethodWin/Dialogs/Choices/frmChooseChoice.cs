using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmChooseChoice : Form
    {
        public SysNewMethod xSys;
        public n_choices SelectedChoices;

        public frmChooseChoice()
        {
            InitializeComponent();
        }

        private void frmChooseClass_Load(object sender, EventArgs e)
        {

        }

        public void LoadChoices()
        {
            tv.BeginUpdate();
                tv.Nodes.Clear();
                LoadSystem(xSys, null);
            tv.EndUpdate();
        }

        public void LoadSystem(SysNewMethod s, TreeNode p)
        {
            TreeNode n;
            TreeNode nc;

            if( p == null )
                n = tv.Nodes.Add(s.Name);
            else
                n = p.Nodes.Add(s.Name);

            
            foreach(n_choices c in s.AllChoices.All)
            {
                nc = n.Nodes.Add(c.name);
                nc.Tag = c;
            }

            //foreach(n_sys xs in s.ParentSystems.All)
            //{
            //    TreeNode t = n.Nodes.Add(xs.system_name);
            //    LoadSystem(xs, t);
            //}

            if (p == null)
                n.ExpandAll();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedChoices = (n_choices)tv.SelectedNode.Tag;
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedChoices = null;
            this.Close();
        }
    }
}