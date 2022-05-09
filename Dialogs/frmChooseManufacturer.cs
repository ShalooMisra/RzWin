using NewMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rz5;

namespace Rz5
{
    public partial class frmChooseManufacturer : Form
    {


        public List<string> AllManufacturers = n_choices.ChoiceListGet(RzWin.Context, "manufacturer");
        public string SelectedManufacturer { get; set; }
        private string PartNumber;
        private bool AddMfgToChoiceList = false;
        private bool bInhibit = false;

        public frmChooseManufacturer(string partNumber, bool addMfgToChoiceList = false)
        {
            InitializeComponent();
            AddMfgToChoiceList = addMfgToChoiceList;
            LoadList();
            this.StartPosition = FormStartPosition.CenterScreen;
            PartNumber = partNumber;
        }


        public void LoadList()
        {
            cbo.DataSource = AllManufacturers;

        }


        public void SetListFocus()
        {
            cbo.Focus();
        }


        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedManufacturer();
        }

        private void cbo_SelectedValueChanged(object sender, EventArgs e)
        {
            GetSelectedManufacturer();
        }


        public string GetSelectedManufacturer()
        {
            DataRowView v;
            string s = "";
            try
            {
                v = (DataRowView)cbo.SelectedValue;
                s = (string)v[0];

            }
            catch (Exception)
            {
                s = (string)cbo.Text;
            }

            SelectedManufacturer = s.Trim().ToUpper();
            return SelectedManufacturer;
        }

        public void Clear()
        {
            cbo.Text = "";
        }

        public void FocusOnBox()
        {
            cbo.Focus();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {

            ClickOK();

        }

        private void ClickOK()
        {
            //input value could be eiher an item selected from list, or a user typed string that doesn't exist in list.
            //Sanitize
            string inputValue = Tools.Strings.SanitizeInput(cbo.Text ?? "").Trim().ToUpper();
            if (!Tools.Strings.StrExt(inputValue))
            {
                RzWin.Context.Error("Please select a name before continuing.");
                DialogResult = DialogResult.No;

            }
            else
            {
                SelectedManufacturer = inputValue;
                DialogResult = DialogResult.OK;

            }
            Close();



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string encudedPartNumber = System.Web.HttpUtility.UrlEncode(PartNumber);
            string url = "https://www.google.com/search?q=" + encudedPartNumber;
            // Navigate to a URL.
            System.Diagnostics.Process.Start("http://www.microsoft.com");
        }

        private void llGoogleMfg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string encudedPartNumber = System.Web.HttpUtility.UrlEncode(PartNumber);
            string url = "https://www.google.com/search?q=" + encudedPartNumber;
            // Navigate to a URL.
            System.Diagnostics.Process.Start(url);
        }
    }
}
