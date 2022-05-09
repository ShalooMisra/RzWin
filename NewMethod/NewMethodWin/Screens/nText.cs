using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class nText : UserControl
    {
        public nText()
        {
            InitializeComponent();
        }

        private void cmdFindAndReplace_Click(object sender, EventArgs e)
        {
            String strFind = txtFindReplace.Text.Replace("\r\n", "\n");
            String strReplace = txtReplace.Text.Replace("\r\n", "\n");

            if (chkCaseSensitiveReplace.Checked)
                txt.Text = txt.Text.Replace(strFind, strReplace);
            else
                txt.Text = nTools.Replace(txt.Text, strFind, strReplace);
        }

        private void cmdRemoveNumbers_Click(object sender, EventArgs e)
        {
            Remove("0");
            Remove("1");
            Remove("2");
            Remove("3");
            Remove("4");
            Remove("5");
            Remove("6");
            Remove("7");
            Remove("8");
            Remove("9");
        }

        private void cmdRemoveSymbols_Click(object sender, EventArgs e)
        {
            Remove(".");
            Remove("<");
            Remove(">");
            Remove("/");
            Remove("\\");
            Remove("?");
            Remove("'");
            Remove("\"");
            Remove(":");
            Remove(";");
            Remove("*");
            Remove("@");
            Remove("#");
            Remove("$");
            Remove("%");
            Remove("^");
            Remove("&");
            Remove("(");
            Remove(")");
            Remove("-");
            Remove("_");
            Remove("+");
            Remove("=");
            Remove("{");
            Remove("}");
            Remove("[");
            Remove("]");
            Remove("|");
            //Remove("_");
            //Remove("+");
            //Remove("=");


        }

        private void Remove(String s)
        {
            txt.Text = txt.Text.Replace(s, "");
        }

        private void cmdRemoveExtraSpaces_Click(object sender, EventArgs e)
        {
            RemoveExtra(" ");
        }

        private void RemoveExtra(String strRemove)
        {
            while (Tools.Strings.HasString(txt.Text, strRemove + strRemove))
            {
                txt.Text = nTools.Replace(txt.Text, strRemove + strRemove, strRemove);
            }
        }

        private void cmdRemoveExtraLines_Click(object sender, EventArgs e)
        {
            ArrayList a = GetLineArray();
            ArrayList b = new ArrayList();
            foreach (String s in a)
            {
                if (Tools.Strings.StrExt(s))
                    b.Add(s);
            }
            SetText(b);
        }

        private void cmdAddBeginning_Click(object sender, EventArgs e)
        {
            AddEachLine(txtAdd.Text, true);
        }

        private void cmdAddEnd_Click(object sender, EventArgs e)
        {
            AddEachLine(txtAdd.Text, false);
        }

        private String[] GetLines()
        {
            return txt.Lines;
            //return Tools.Strings.SplitLines(txt.Text);
        }

        private ArrayList GetLineArray()
        {
            ArrayList a = new ArrayList();
            String[] ary = GetLines();
            foreach (String s in ary)
            {
                a.Add(s);
            }
            return a;
        }

        private List<String> GetLineList()
        {
            List<String> a = new List<String>();
            String[] ary = GetLines();
            foreach (String s in ary)
            {
                a.Add(s);
            }
            return a;
        }

        private void AddEachLine(String strAdd, bool start)
        {
            String[] ary = GetLines();
            StringBuilder sb = new StringBuilder();
            foreach (String s in ary)
            {
                if (start)
                {
                    sb.Append(strAdd);
                    sb.AppendLine(s);
                }
                else
                {
                    sb.Append(s);
                    sb.AppendLine(strAdd);
                }
            }
            txt.Text = sb.ToString();
        }

        private void cmdRemoveAllLineBreaks_Click(object sender, EventArgs e)
        {
            txt.Text = txt.Text.Replace("\r", "").Replace("\n", "");
        }

        private void nText_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            try
            {
                sp.Top = 0;
                //sp.Left = gbReplace.Right;
                sp.Height = this.ClientRectangle.Height;
                sp.Width = this.ClientRectangle.Width - txt.Left;

                txt.Left = 0;
                txt.Top = 0;
                txt.Width = sp.Panel1.ClientRectangle.Width - 380;
                txt.Height = sp.Panel1.ClientRectangle.Height;

                tvBlurbs.Left = 0;
                tvBlurbs.Top = 0;
                tvBlurbs.Height = sp.Panel2.ClientRectangle.Height;

                txtBlurbs.Left = tvBlurbs.Right;
                txtBlurbs.Top = 0;
                txtBlurbs.Height = sp.Panel2.ClientRectangle.Height;
                txtBlurbs.Width = sp.Panel2.ClientRectangle.Width - (txtBlurbs.Left + 50);
            }
            catch (Exception)
            { }
        }

        private void cmdGleanEmailAddresses_Click(object sender, EventArgs e)
        {
            txt.Text = txt.Text.Replace(",", " ").Replace("\n", " ").Replace("\r", " ").Replace("/", " ").Replace("\\", " ").Replace(";", " ").Replace("'", " ");


            ArrayList a = SplitBySpaces();
            ArrayList b = new ArrayList();

            foreach (String s in a)
            {
                if (nTools.IsEmailAddress(s))
                    b.Add(s);
            }

            SetText(b);
            RemoveDuplicates();
            Alphabetize();
        }

        private ArrayList SplitBySpaces()
        {
            String[] ary = Tools.Strings.Split(txt.Text, " ");
            ArrayList a = new ArrayList();
            foreach (String s in ary)
            {
                if (Tools.Strings.StrExt(s))
                    a.Add(s);
            }
            return a;
        }

        private void SetText(ArrayList a)
        {
            StringBuilder sb = new StringBuilder();
            foreach (String s in a)
            {
                sb.Append(s + "\n");
            }
            SetText(sb.ToString());
        }

        private void SetText(String s)
        {
            txt.Text = s;
        }

        private void Alphabetize()
        {
            ArrayList a = GetLineArray();
            a.Sort();
            SetText(a);
        }

        private void TransformSQLIn()
        {
            ArrayList a = GetLineArray();
            StringBuilder sb = new StringBuilder();
            bool b = false;
            foreach (String s in a)
            {
                String replaced = s.Replace("\t", "").Replace("'", "''").Trim();
                if (Tools.Strings.StrExt(replaced))
                {
                    if (b)
                        sb.Append(", ");

                    sb.Append("'" + replaced + "'");

                    b = true;
                }
            }

            SetText(sb.ToString());
        }

        private void cmdTransformSQLIn_Click(object sender, EventArgs e)
        {
            TransformSQLIn();
        }

        private void cmdAlphabetize_Click(object sender, EventArgs e)
        {
            Alphabetize();
        }

        private void cmdRemoveWith_Click(object sender, EventArgs e)
        {
            RemoveLines(txtRemove.Text, true);
        }

        private void cmdRemoveWithout_Click(object sender, EventArgs e)
        {
            RemoveLines(txtRemove.Text, false);
        }

        void RemoveLines(String strRemove, bool with)
        {
            StringBuilder sb = new StringBuilder();
            ArrayList a = GetLineArray();
            foreach (String s in a)
            {
                if (Tools.Strings.HasString(s, strRemove))
                {
                    if (!with)
                        sb.AppendLine(s);
                }
                else
                {
                    if( with)
                        sb.AppendLine(s);
                }
            }
            SetText(sb.ToString());
        }

        private void cmdRemoveAfter_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            ArrayList a = GetLineArray();
            foreach (String s in a)
            {
                sb.AppendLine(Tools.Strings.ParseDelimit(s, txtRemove.Text, 1).Trim());
            }
            SetText(sb.ToString());
        }

        private void cmdRemoveBefore_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            ArrayList a = GetLineArray();
            foreach (String s in a)
            {
                sb.AppendLine(Tools.Strings.ParseDelimit(s, txtRemove.Text, 2).Trim());
            }
            SetText(sb.ToString());
        }

        bool inhibit = false;
        private void sp_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (inhibit)
                return;

            DoResize();
        }

        private void cmdBreak_Click(object sender, EventArgs e)
        {
            if (Blurbs == null)
            {
                Blurbs = new ArrayList();
                String[] ary = Tools.Strings.Split(txt.Text, Normalize(txtBreak.Text));
                foreach (String s in ary)
                {
                    TextBlurb b = new TextBlurb(s);
                    Blurbs.Add(b);
                }
            }
            else
            {

            }

            ShowBlurbs();
        }

        public String Normalize(String s)
        {
            return s.Replace("\r", "");
        }

        public ArrayList Blurbs = null;

        private void cmdClearBlurbs_Click(object sender, EventArgs e)
        {
            Blurbs = null;
            ShowBlurbs();
        }

        void ShowBlurbs()
        {
            tvBlurbs.Nodes.Clear();
            txtBlurbs.Text = "";
            if (Blurbs == null)
                return;

            ShowBlurbNode(Blurbs, tvBlurbs.Nodes, 0);
        }

        void ShowBlurbNode(ArrayList blurbs, TreeNodeCollection nodes, int level)
        {
            if (blurbs.Count == 0)
                return;

            foreach (TextBlurb b in blurbs)
            {
                TreeNode n = nodes.Add(b.SingleLine);
                txtBlurbs.AppendText(b.Indent(b.Text, level) + "\n\n----<break>----\n\n");

                ShowBlurbNode(b.SubBlurbs, n.Nodes, level + 1);
            }
        }

        private void cmdRemoveCr_Click(object sender, EventArgs e)
        {
            txt.Text = txt.Text.Replace("\r", "");
        }

        private void Trim_Click(object sender, EventArgs e)
        {
            ArrayList a = GetLineArray();
            ArrayList ret = new ArrayList();
            foreach (String s in a)
            {
                ret.Add(s.Replace("\t", "").Trim());
            }
            SetText(ret);
        }

        private void cmdRemoveDuplicates_Click(object sender, EventArgs e)
        {
            RemoveDuplicates();
        }

        void RemoveDuplicates()
        {
            ArrayList a = GetLineArray();
            ArrayList ret = new ArrayList();
            ArrayList refer = new ArrayList();
            foreach (String s in a)
            {
                if (Tools.Strings.StrExt(s))
                {
                    if (!refer.Contains(s.Trim().ToLower()))
                    {
                        ret.Add(s.Trim());
                        refer.Add(s.Trim().ToLower());
                    }
                }
            }
            SetText(ret);
        }

        private void cmdCommatize_Click(object sender, EventArgs e)
        {
            Commatize();
        }

        void Commatize()
        {
            ArrayList a = GetLineArray();
            bool b = false;
            List<String> strings = new List<string>();
            foreach (String s in a)
            {
                if (Tools.Strings.StrExt(s))
                {
                    strings.Add(s.Trim());
                }
            }

            SetText(Tools.Strings.CommaSeparateBlanksIgnore(strings));
        }

        private void cmdCsv_Click(object sender, EventArgs e)
        {
            if (!Tools.Number.IsNumeric(txtCsvColumns.Text))
                return;

            int cols = Int32.Parse(txtCsvColumns.Text);
            String[] chunks = Tools.Strings.Split(txt.Text, txtCsvSeparator.Text);

            StringBuilder result = new StringBuilder();
            int c = 0;
            foreach (String chunk in chunks)
            {
                if (c > 0)
                    result.Append(",");
                result.Append("\"" + chunk.Replace("\"", "").Replace("'", ""));

                c++;
                if (c >= cols)
                    result.Append("\r\n");
            }

            SetText(result.ToString());
        }

        private void parseEmailDomainButton_Click(object sender, EventArgs e)
        {
            List<String> lines = GetLineList();
            StringBuilder sb = new StringBuilder();
            foreach (String l in lines)
            {
                if (l.Trim() == "")
                    continue;

                sb.AppendLine(l.Replace("\"", "").Replace(",", "").ToLower() + "," + Tools.Email.ParseEmailDomain(l.Replace("\"", "").Replace(",", "").ToLower()));
            }
            txt.Text = sb.ToString();
            txt.SelectionStart = 0;
            txt.SelectionLength = 0;
            txt.ScrollToCaret();
        }
    }

    public class TextBlurb
    {
        public String Text = "";
        public ArrayList SubBlurbs = new ArrayList();
        public TextBlurb(String t)
        {
            Text = Indent(t, 0);
        }

        public String Indent(String s, int level)
        {
            String[] ary = Tools.Strings.SplitLines(s);
            StringBuilder b = new StringBuilder();
            foreach (String l in ary)
            {
                String indent = "";
                for (int i = 0; i < level; i++)
                {
                    indent += "    ";
                }

                b.AppendLine(indent + l.Trim());
            }
            return b.ToString();
        }

        public String SingleLine
        {
            get
            {
                String s = Text.Replace("\r", " ").Replace("\n", " ").Trim();
                if( s.Length > 60 )
                    s = s.Substring(0, 50);
                return s;
            }
        }
    }

}
