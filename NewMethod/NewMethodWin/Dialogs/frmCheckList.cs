using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmCheckList : Form
    {
        public static String Choose(SysNewMethod xs, String strClass, String strSQL, System.Windows.Forms.IWin32Window owner)
        {
            frmCheckList xForm = new frmCheckList();
            xForm.CompleteLoad(xs, strClass, strSQL);
            xForm.ShowDialog(owner);
            String r = xForm.SelectedIDs;
            xForm.Close();
            xForm = null;
            return r;
        }

        public String SelectedIDs = "";
        SysNewMethod xSys;
        public frmCheckList()
        {
            InitializeComponent();
        }

        public void CompleteLoad(SysNewMethod xs, String strClass, String strSQL)
        {
            xSys = xs;

            DoResize();

            lv.Items.Clear();
            DataTable d = NMWin.ContextDefault.Select(strSQL);

            lv.Columns.Clear();
            if (d == null)
                return;

            if (d.Columns.Count <= 1)
                return;

            foreach (DataColumn c in d.Columns)
            {
                if( !Tools.Strings.StrCmp(c.Caption, "unique_id") )
                {
                    ColumnHeader col = lv.Columns.Add(c.Caption);
                    col.Width = lv.Width / (d.Columns.Count - 1);
                }
            }

            if (!nTools.DataTableExists(d))
            {
                cmdOK.Enabled = false;
                return;
            }

            cmdOK.Enabled = true;

            foreach (DataRow r in d.Rows)
            {
                ListViewItem xLst = new ListViewItem();
                //unique id first
                xLst.Tag = (String)nData.NullFilter_String(r[0]);

                int i = 0;
                foreach (DataColumn col in d.Columns)
                {
                    if (!Tools.Strings.StrCmp(col.Caption, "unique_id"))
                    {
                        if (i == 0)
                            xLst.Text = nData.NullFilter_String(r[i + 1]);
                        else
                            xLst.SubItems.Add(nData.NullFilter_String(r[i + 1]));
                        i++;
                    }
                }

                lv.Items.Add(xLst);
            }

            d = null;
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedIDs = "";
            this.Hide();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            String s = "";
            foreach(ListViewItem i in lv.Items)
            {
                if( i.Checked )
                {
                    if( Tools.Strings.StrExt(s) )
                        s += ", ";
                    s += "'" + (String)i.Tag + "'";

                }
            }
            SelectedIDs = s;
            this.Hide();
        }

        private void frmCheckList_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public void DoResize()
        {
            try
            {
                lv.Left = 0;
                lv.Top = cmdAll.Height;
                lv.Width = this.ClientRectangle.Width;
                lv.Height = this.ClientRectangle.Height - (cmdOK.Height + lv.Top);

                cmdCancel.Top = lv.Bottom;
                cmdOK.Top = lv.Bottom;
                cmdCancel.Left = 0;
                cmdCancel.Width = this.ClientRectangle.Width / 2;
                cmdOK.Left = cmdCancel.Right;
                cmdOK.Width = this.ClientRectangle.Width - cmdCancel.Width;

                cmdAll.Top = 0;
                cmdAll.Left = 0;
                cmdAll.Width = cmdCancel.Width;

                cmdNone.Left = cmdOK.Left;
                cmdNone.Top = 0;
                cmdNone.Width = cmdOK.Width;
            }
            catch (Exception)
            { }
        }

        private void cmdAll_Click(object sender, EventArgs e)
        {
            CheckAll(true);
        }

        private void cmdNone_Click(object sender, EventArgs e)
        {
            CheckAll(false);
        }

        private void CheckAll(bool c)
        {
            foreach (ListViewItem i in lv.Items)
            {
                i.Checked = c;
            }
        }
    }
}