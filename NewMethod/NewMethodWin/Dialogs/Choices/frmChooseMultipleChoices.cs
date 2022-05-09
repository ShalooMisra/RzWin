using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmChooseMultipleChoices : Form
    {
        public static ArrayList ChooseFromArray(ArrayList source, String strCaption)
        {
            frmChooseMultipleChoices xForm = new frmChooseMultipleChoices();
            xForm.CompleteLoad(source, strCaption);
            xForm.ShowDialog();

            ArrayList ret = xForm.SelectedStrings;

            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }

            return ret;
        }

        public String SelectedChoice = "";
        private n_choices CurrentList;
        public ArrayList SelectedStrings = new ArrayList();

        public frmChooseMultipleChoices()
        {
            InitializeComponent();
        }

        public String DefaultChoicesFullBarSeparated = "";
        public void CompleteLoad(n_choices c, String strCaption)
        {
            CurrentList = c;
            lst.Items.Clear();
            foreach (n_choice ch in c.AllChoices)
            {
                int index = lst.Items.Add(ch.name);
                lst.SetItemChecked(index, DefaultChoicesFullBarSeparated.ToLower().Contains("|" + ch.Name.ToLower() + "|"));
            }
            lblCaption.Text = strCaption;
            ShowChecked();
            DoResize();
        }

        public void CompleteLoad(ArrayList a, String strCaption)
        {
            CurrentList = null;
            lst.Items.Clear();
            foreach (String s in a)
            {
                lst.Items.Add(s);
            }
            lblCaption.Text = strCaption;
            ShowChecked();
            DoResize();
            txtScan.Text = "";
            txtScan.Focus();
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedChoice = "";
            SelectedStrings.Clear();
            this.Hide();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void Accept()
        {
            String s = "";
            foreach (String x in lst.CheckedItems)
            {
                if (Tools.Strings.StrExt(x))
                {
                    if (Tools.Strings.StrExt(s))
                        s += "|";
                    s += x.Trim();

                    SelectedStrings.Add(x.Trim());
                }
            }

            if (!Tools.Strings.StrExt(s))
                return;

            SelectedChoice = s;
            this.Hide();
        }

        private void frmChooseOneChoice_Activated(object sender, EventArgs e)
        {
            ToolsWin.Screens.SetOnMouse(this);
        }

        private void frmChooseMultipleChoices_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            try
            {
                lst.Left = 0;
                lst.Width = this.ClientRectangle.Width;
                lst.Height = this.ClientRectangle.Height - (lst.Top + cmdOK.Height + pScan.Height);
                cmdOK.Top = this.ClientRectangle.Height - cmdOK.Height;
                cmdCancel.Top = cmdOK.Top;
                cmdCancel.Left = 0;
                cmdCancel.Width = this.ClientRectangle.Width / 2;
                cmdOK.Left = cmdCancel.Right;
                cmdOK.Width = this.ClientRectangle.Width - cmdCancel.Width;
                pScan.Top = lst.Bottom;
            }
            catch (Exception)
            { }
        }

        private void lblPaste_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                String s = ToolsWin.Clipboard.GetClipText();
                if (!Tools.Strings.StrExt(s))
                    return;

                String[] ary = Tools.Strings.SplitLines(s);

                System.Collections.ArrayList items = new System.Collections.ArrayList();

                foreach (String si in lst.Items)
                {
                    items.Add(si);
                }

                foreach(String line in ary)
                {
                    if (Tools.Strings.StrExt(line))
                    {
                        int i = 0;
                        foreach (String si in items)
                        {
                            if (Tools.Strings.StrCmp(line, si))
                            {
                                lst.SetItemCheckState(i, CheckState.Checked);
                            }
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                NMWin.Leader.Tell(ex.Message);
            }
        }

        private void txtScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                case '\n':
                    CheckEnteredValue();
                    e.Handled = true;
                    break;
            }
        }

        void CheckEnteredValue()
        {
            String s = txtScan.Text.Trim();
            if( !Tools.Strings.StrExt(s) )
                return;

            //if (!lst.Items.Contains(s))
            //    return;

            int i = 0;
            bool found = false;
            foreach(String si in lst.Items)
            {
                if( Tools.Strings.StrCmp(s, si) )
                {
                    found = true;
                    break;
                }
                i++;
            }

            if (found)
            {
                lst.SetItemChecked(i, true);
                txtScan.Text = "";
                txtScan.Focus();
            }
        }

        private void lblCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckEnteredValue();
        }

        private void lst_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void lst_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void lst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        bool suppress = false;
        private void lst_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (suppress)
                return;


            ShowChecked();
        }

        void ShowChecked()
        {
            lblChecked.Text = Tools.Strings.PluralizePhrase("item", lst.CheckedItems.Count) + " checked";
        }

        private void lblCheckAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckAll(true);
        }

        private void lblCheckNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckAll(false);
        }

        void CheckAll(bool check)
        {
            suppress = true;
            try
            {
               for(int i = 0 ; i < lst.Items.Count ; i++)
               {
                   lst.SetItemChecked(i, check);
               }
            }
            catch { }
            suppress = false;
            ShowChecked();
        }

        private void lst_MouseUp(object sender, MouseEventArgs e)
        {
            ShowChecked();
        }
    }
}