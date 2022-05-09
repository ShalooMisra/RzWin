using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmChooseFromClipboard : Form
    {

        //public static nObject Choose(n_sys xs, String strClass, String strUserID, String strExtra, System.Windows.Forms.IWin32Window owner)
        //{
        //    return Choose(xs, strClass, strUserID, strExtra, owner);
        //}

        public static nObject Choose(SysNewMethod xs, String strClass, String strUserID, String strExtra, System.Windows.Forms.IWin32Window owner)  //, ClipboardExtraSearch extrasearch
        {
            frmChooseFromClipboard xForm = new frmChooseFromClipboard();
            xForm.CompleteLoad(strClass, strUserID, strExtra);  //, extrasearch
            xForm.ShowDialog(owner);
            nObject x = xForm.SelectedObject;
            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return x;
        }

        public nObject SelectedObject;

        public frmChooseFromClipboard()
        {
            InitializeComponent();
        }

        public void CompleteLoad(String strClass, String strUserID, String strExtra)  //, ClipboardExtraSearch extrasearch
        {
            lv.Items.Clear();
            String strSQL = "select distinct(n_clip.unique_id) from n_clip ";
            if (Tools.Strings.StrExt(strExtra))
            {
                strSQL += " inner join " + strClass + " on " + strClass + ".unique_id = n_clip.link_id and " + strExtra;
            }
            strSQL += "where the_n_user_uid = '" + strUserID + "' and link_class = '" + strClass + "'";

            ArrayList a = NMWin.ContextDefault.TheData.SelectScalarArray(strSQL);
            foreach(String s in a)
            {
                n_clip c = n_clip.GetById(NMWin.ContextDefault, s);
                ListViewItem i = lv.Items.Add(c.name);
                i.Tag = c;
            }

            //if( extrasearch != null )
            //{
            //    this.Width = this.Width * 2;
            //    lv.Width = this.ClientRectangle.Width - (lv.Left * 2);
            //    lv.Height = lv.Height / 2;
            //    Controls.Add(extrasearch);
            //    extrasearch.Left = lv.Left;
            //    extrasearch.Top = lv.Bottom;
            //    extrasearch.Height = this.ClientRectangle.Height - (extrasearch.Top + cmdOK.Height);
            //    extrasearch.Width = this.ClientRectangle.Width - extrasearch.Left;
            //    extrasearch.CompleteLoad(xs);
            //    extrasearch.GotnObject += new GotnObjectHandler(extrasearch_GotnObject);
            //}
        }

        void extrasearch_GotnObject(nObject o)
        {
            SelectedObject = o;
            this.Hide();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedObject = null;
            this.Hide();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem i = lv.SelectedItems[0];
                n_clip c = (n_clip)i.Tag;
                SelectedObject = c.GetInstanceObject(NMWin.ContextDefault);
                if (SelectedObject != null)
                    this.Hide();
            }
            catch (Exception)
            { }
        }
    }
}