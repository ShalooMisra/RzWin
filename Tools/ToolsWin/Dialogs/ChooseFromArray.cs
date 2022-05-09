using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;

namespace ToolsWin.Dialogs
{
    public partial class ChooseFromArray : ToolsWin.Dialogs.OKCancel
    {
        public static String Choose(List<String> list, String caption, bool allowManualEntry = false)
        {
            ArrayList a = new ArrayList(list);
            return Choose(a, caption, allowManualEntry);
        }

        public static String Choose(ArrayList a, String caption, bool allowManualEntry = false, String suggested = "")
        {
            ChooseFromArray xForm = new ChooseFromArray();
            xForm.CompleteLoad(a, allowManualEntry);
            if (a.Count < 10)
                xForm.Height = xForm.Height / 2;            
            xForm.Text = caption;
            //if (AllowManualEntry)
            xForm.TextSet(suggested);
            xForm.ShowDialog();
            String s = xForm.ResultString;
            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return s;
        }

        public String ResultString = "";

        public ChooseFromArray()
        {
            InitializeComponent();
        }

        public void CompleteLoad(ArrayList a, bool AllowManualEntry)
        {
            txtSel.Enabled = AllowManualEntry;
            lv.BeginUpdate();
            foreach (String s in a)
            {
                lv.Items.Add(s);
            }
            lv.EndUpdate();
        }

        public void TextSet(String s)
        {
            txtSel.Text = s;
        }

        public override void OK()
        {
            try
            {
                if (!Tools.Strings.StrExt(txtSel.Text))
                    return;

                ResultString = txtSel.Text;
                base.OK();
            }
            catch
            { }
        }

        //private void cmdCancel_Click(object sender, EventArgs e)
        //{
        //    ResultString = "";
        //    this.Hide();
        //}

        public override void Cancel()
        {
            ResultString = "";
            base.Cancel();
        }

        private void lv_Click(object sender, EventArgs e)
        {
            try
            {
                txtSel.Text = lv.SelectedItems[0].Text;
            }
            catch (Exception)
            { }
        }

        public override void DoResize()
        {
            base.DoResize();

            try
            {
                gbSelected.Left = 0;
                gbSelected.Width = pContents.ClientRectangle.Width;
                gbSelected.Top = pContents.ClientRectangle.Height - gbSelected.Height;

                lv.Left = 0;
                lv.Top = 0;
                lv.Width = pContents.ClientRectangle.Width;
                lv.Height = pContents.ClientRectangle.Height - gbSelected.Height;
            }
            catch { }

        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            OK();
        }
    }
}