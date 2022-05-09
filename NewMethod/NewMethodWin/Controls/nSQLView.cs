using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class nSQLView : UserControl
    {
        public nSQL CurrentSQL;
        public SysNewMethod xSys;

        public nSQLView()
        {
            InitializeComponent();
        }

        public void CompleteLoad(SysNewMethod xs, nSQL sql, String strPrefix)
        {
            xSys = xs;
            CurrentSQL = sql;
            ShowSQL();
            txtPrefix.Text = strPrefix;
        }

        private void ShowSQL()
        {
            tv.Nodes.Clear();
            txt.Text = "";

            tv.BeginUpdate();
            try
            {
                ShowSQL(CurrentSQL, tv.Nodes);
                tv.ExpandAll();
            }
            catch { }
            tv.EndUpdate();

            ShowSQLText();
        }

        private void ShowSQL(nSQL sql, TreeNodeCollection nodes)
        {
            String s = sql.strWhere;
            if (!Tools.Strings.StrExt(s))
            {
                if( Convert.ToInt32(sql.Clause) > 0 )
                    s = sql.Clause.ToString();
            }

            if (Tools.Strings.StrExt(s))
            {
                TreeNode n = nodes.Add(s);
                if (sql.SubClauses != null)
                {
                    foreach (nSQL ss in sql.SubClauses)
                    {
                        ShowSQL(ss, n.Nodes);
                    }
                }
            }
            else
            {
                if (sql.SubClauses != null)
                {
                    foreach (nSQL ss in sql.SubClauses)
                    {
                        ShowSQL(ss, nodes);
                    }
                }
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            ShowSQLText();
        }

        private void ShowSQLText()
        {
            txt.Text = CurrentSQL.RenderSQL();
        }

        private void nSQLView_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            try
            {
                gb.Left = 0;
                gb.Top = 0;
                gb.Width = this.ClientRectangle.Width;

                tv.Left = 0;
                tv.Top = gb.Bottom;
                tv.Width = this.ClientRectangle.Width / 2;
                tv.Height = this.ClientRectangle.Height - tv.Top;

                txt.Left = tv.Right;
                txt.Top = gb.Bottom;
                txt.Height = this.ClientRectangle.Height - txt.Top;
                txt.Width = this.ClientRectangle.Width - txt.Left;
            }
            catch { }
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            NMWin.Leader.Reorg();
            //xSys.ShowSQL(txtPrefix.Text + "\r\n\r\n" + txt.Text);
        }
    }
}
