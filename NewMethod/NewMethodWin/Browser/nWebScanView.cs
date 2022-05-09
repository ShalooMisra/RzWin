using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class nWebScanView : UserControl
    {
        public SysNewMethod xSys;
        public String ScanName;

        public nWebScanView()
        {
            InitializeComponent();
        }

        public void CompleteLoad(SysNewMethod xs, String scan_name)
        {
            xSys = xs;
            ScanName = scan_name;

            lv.Items.Clear();
            lv.BeginUpdate();
            try
            {
                DataTable d = NMWin.ContextDefault.Select("select unique_id, url, scandate from raw_" + ScanName + " order by scandate");
                foreach (DataRow r in d.Rows)
                {
                    ListViewItem i = lv.Items.Add(nData.NullFilter_Date(r["scandate"]).ToString());
                    i.Tag = nData.NullFilter_String(r["unique_id"]);
                    i.SubItems.Add(nData.NullFilter_String(r["url"]));
                }
            }
            catch { }
            lv.EndUpdate();
        }

        private void lv_Click(object sender, EventArgs e)
        {
            try
            {
                String s = (String)lv.SelectedItems[0].Tag;
                if (Tools.Strings.StrExt(s))
                {
                    String html = NMWin.Data.GetScalar_String("select all_html from raw_" + ScanName + " where unique_id = '" + s + "'");
                    wb.ReloadWB();
                    wb.Add(html);
                }
            }
            catch { }
        }

        private void nWebScanView_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                wb.Top = 0;
                wb.Width = this.ClientRectangle.Width - wb.Left;
                wb.Height = this.ClientRectangle.Height;

                lv.Top = 0;
                lv.Height = this.ClientRectangle.Height;

            }
            catch { }
        }
    }
}
