using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tools.Database;

namespace NewMethod
{
    public partial class frmConversionOptions : Form
    {
        public static Enums.DataConversionType AskForType(System.Windows.Forms.IWin32Window owner, ref String def, String strInstructions, FieldType dt)
        {
            frmConversionOptions xForm = new frmConversionOptions();
            xForm.SetInstructions(strInstructions);
            xForm.SetOptions(dt);
            xForm.ShowDialog(owner);

            def = xForm.DefaultString;
            Enums.DataConversionType t = xForm.SelectedType;

            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return t;
        }

        public Enums.DataConversionType SelectedType = NewMethod.Enums.DataConversionType.Cancel;
        public String DefaultString;

        public frmConversionOptions()
        {
            InitializeComponent();
        }

        public void SetInstructions(String s)
        {
            lblInstruct.Text = s;
        }

        public void SetOptions(FieldType dt)
        {
            cboOptions.Items.Clear();
            switch (dt)
            {
                case FieldType.Boolean:
                    cboOptions.Items.Add("0");
                    cboOptions.Items.Add("1");
                    cboOptions.Text = "0";
                    break;
                case FieldType.DateTime:
                    cboOptions.Items.Add(nTools.DateFormat(System.DateTime.Now));
                    cboOptions.Items.Add("<no date>");
                    cboOptions.Text = "<no date>";
                    break;
                case FieldType.Int32:
                case FieldType.Int64:
                case FieldType.Double:
                    cboOptions.Items.Add("0");
                    cboOptions.Text = "0";
                    break;
            }
            cboOptions.Enabled = false;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            ClickOK();
        }

        private void ClickOK()
        {
            if (optCancel.Checked)
                SelectedType = NewMethod.Enums.DataConversionType.Cancel;
            else if (optDelete.Checked)
                SelectedType = NewMethod.Enums.DataConversionType.DeleteRow;
            else
            {
                if (!Tools.Strings.StrExt(cboOptions.Text))
                {
                    NMWin.Leader.Tell("Please enter a value to use, or choose a different conversion option.");
                    return;
                }
                DefaultString = cboOptions.Text;
                SelectedType = NewMethod.Enums.DataConversionType.SetDefault;
            }
            this.Hide();
        }

        private void optConvert_CheckedChanged(object sender, EventArgs e)
        {
            cboOptions.Enabled = optConvert.Checked;
        }
    }
}