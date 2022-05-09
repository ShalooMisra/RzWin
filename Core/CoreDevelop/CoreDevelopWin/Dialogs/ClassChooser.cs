using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Core;
using CoreDevelop;

namespace CoreDevelopWin
{
    public partial class ClassChooser : Form
    {
        //Public Variables
        public String TheClassName = "";

        //Constructors
        public ClassChooser()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static string ChooseAClassName(CoreDevelop.ContextDevelop context, BoxSys sys, BoxClass from, string caption = "")
        {
            ClassChooser c = new ClassChooser();
            c.CompleteLoad(context, sys, from, caption);
            c.ShowDialog();
            return c.TheClassName;
        }
        //Public Functions
        public void CompleteLoad(CoreDevelop.ContextDevelop context, BoxSys sys, BoxClass from, string caption = "")
        {
            if (Tools.Strings.StrExt(caption))
                lblCaption.Text = caption;
            lvClasses.Items.Clear();
            lvClasses.SuspendLayout();
            try
            {
                foreach (KeyValuePair<string, BoxClass> kvp in sys.Classes)
                {
                    if (from == kvp.Value)
                        continue;
                    ListViewItem xLst = lvClasses.Items.Add(kvp.Key);
                    xLst.SubItems.Add(kvp.Value.Vars.Count.ToString());
                    xLst.Tag = kvp.Value;
                }
            }
            catch { }
            lvClasses.ResumeLayout();
        }
        //Private Functions
        private void Accept()
        {
            BoxClass b = null;
            if (lvClasses.SelectedItems.Count <= 0)
                return;
            try { b = (BoxClass)lvClasses.SelectedItems[0].Tag; }
            catch { }
            if (b != null)
                TheClassName = b.Name;
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            TheClassName = "";
            Close();
        }
        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Accept();
            Close();
        }
    }
}
