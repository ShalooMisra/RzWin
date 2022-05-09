using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public partial class frmChooseProp : Form
    {
        public static String Choose(SysNewMethod xSys, CoreClassHandle xClass, IWin32Window owner)
        {
            frmChooseProp p = new frmChooseProp();
            p.Init(xSys, xClass);
            p.ShowDialog(owner);

            CoreVarValAttribute sel = p.SelectedProp;

            try
            {
                p.Close();
                p.Dispose();
                p = null;
            }
            catch { }

            if (sel == null)
                return "";
            else
                return sel.Name;
        }

        SysNewMethod xSys;
        CoreClassHandle xClass;
        public CoreVarValAttribute SelectedProp;

        public frmChooseProp()
        {
            InitializeComponent();
        }

        public void Init(SysNewMethod xsys, CoreClassHandle xclass)
        {
            xSys = xsys;
            xClass = xclass;

            props = new List<CoreVarValAttribute>();
            foreach (CoreVarValAttribute a in xclass.VarValsGet())
            {
                props.Add(a);
            }

            Search();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        List<CoreVarValAttribute> props;
        void Search()
        {
            lvProps.Items.Clear();
            if (txtSearch.Text.Length < 3)
                return;

            foreach (CoreVarValAttribute p in props)
            {
                if (Tools.Strings.HasString(p.Name, txtSearch.Text) || Tools.Strings.HasString(p.Caption, txtSearch.Text))
                {
                    ListViewItem i = lvProps.Items.Add(p.Name);
                    i.SubItems.Add(p.Caption);
                    i.SubItems.Add(p.TheFieldType.ToString());
                    i.Tag = p;
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if( lvProps.Items.Count == 1 )
                    {
                        e.Handled = true;
                        HandleClick(lvProps.Items[0]);
                    }
                    break;
            }
        }

        void HandleClick(ListViewItem i)
        {
            if (i == null)
                return;

            SelectedProp = (CoreVarValAttribute)i.Tag;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedProp = null;
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                HandleClick(lvProps.SelectedItems[0]);
            }
            catch { }
        }

        private void lvProps_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                HandleClick(lvProps.SelectedItems[0]);
            }
            catch { }
        }
    }
}
