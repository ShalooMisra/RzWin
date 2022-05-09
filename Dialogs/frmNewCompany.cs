using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class frmNewCompany : Form
    {
        public String SelectedName = "";
        public String IgnoreID = "";

        public frmNewCompany()
        {
            InitializeComponent();
        }

        public void CompleteLoad(String strCompanyName)
        {
            throb.BackColor = throb.Parent.BackColor;
            lst.ShowTemplate("similar_companies", "company");
            txtCompany.Text = strCompanyName;
            CheckChange();
        }

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            KickChange();
        }

        private void KickChange()
        {
            tmr.Stop();
            tmr.Interval = 1500;
            tmr.Start();
        }

        private void CheckChange()
        {
            throb.ShowThrobber();

            String strU = "";
            if (RzWin.Logic.CompareDistilledCompanyNames)
                strU = company.DistillCompanyName(txtCompany.Text);
            else
                strU = txtCompany.Text;

            ShowSimilar();

            if (lst.GetCount() > 0)
            {
                ShowNotUnique(strU);
            }
            else
            {
                if (!Tools.Strings.StrExt(strU))
                {
                    lblUnique.ForeColor = System.Drawing.Color.Black;
                    lblUnique.Text = "";
                    cmdOK.Enabled = false;
                }
                else if (strU.Length <= 4)
                {
                    lblUnique.ForeColor = System.Drawing.Color.Red;
                    lblUnique.Text = "<too short>: " + strU;
                    cmdOK.Enabled = true;
                }
                else
                {
                    lblUnique.ForeColor = System.Drawing.Color.Green;
                    lblUnique.Text = "Unique: " + strU;
                    cmdOK.Enabled = true;
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            String strU = "";
            if (RzWin.Logic.CompareDistilledCompanyNames)
                strU = company.DistillCompanyName(txtCompany.Text);
            else
                strU = txtCompany.Text;

            //2010_01_14   had to get rid of this because of names like "Q Components"
            //if( strU.Length < 2 )
            //{
            //    RzWin.Context.Error("This company name is not sufficiently unique.  Please enter a longer, more descriptive company name.");
            //    return;
            //}

            //if( lst.GetCount() > 0 )
            //{
            //    RzWin.Context.Error("Please enter a company name that is unique enough to generate no matches with existing companies.");
            //    return;
            //}
            
            SelectedName = txtCompany.Text;
            this.Close();
        }

        public void ShowSimilar()
        {
            lst.Clear();
            if( company.DistillCompanyName(txtCompany.Text).Length <= 4 )
                return;

            String strSQL = " (companyname like '" + RzWin.Context.Filter(txtCompany.Text).Replace("[", "\\[") + "%' or distilledname like '" + RzWin.Context.Filter(company.DistillCompanyName(txtCompany.Text)).Replace("[", "\\[") + "%' ) and unique_id <> '" + IgnoreID + "'";

            lst.ShowData("company", strSQL, "companyname", 10);
        }

        private void lst_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            CheckChange();
        }

        private void lst_FinishedFill(object sender)
        {
            try
            {
                throb.HideThrobber();
                if (lst.GetCount() > 0)
                {
                    String strU = "";
                    if (RzWin.Logic.CompareDistilledCompanyNames)
                        strU = company.DistillCompanyName(txtCompany.Text);
                    else
                        strU = txtCompany.Text;
                    ShowNotUnique(strU);
                }
            }
            catch (Exception)
            { }
        }

        void ShowNotUnique(String strU)
        {
            lblUnique.ForeColor = System.Drawing.Color.Red;
            lblUnique.Text = "<not unique>: " + strU;
            uniqueInstructions.Visible = true;
            cmdOK.Enabled = true;  //just let them, there's already a warning
        }
    }
}