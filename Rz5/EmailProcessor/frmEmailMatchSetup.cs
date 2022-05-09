using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz3_Common
{
    public partial class frmEmailMatchSetup : Form
    {
        n_sys xSys
        {
            get
            {
                return n_sys.ContextDefault.xSys;
            }
        }
        String[] aryStatements = new String[5];

        public frmEmailMatchSetup()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad()
        {
            try
            {
                FillStatements();
                ShowSelected();
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        //Private Functions
        private void FillStatements()
        {
            try
            {
                aryStatements[0] = "SELECT * FROM PARTRECORD WHERE FULLPARTNUMBER = '<FULLPARTNUMBER>' AND STOCKTYPE IN ('Stock', 'Consigned', 'OEM', 'excess', '') AND QUANTITY >= 500";
                aryStatements[1] = "SELECT * FROM PARTRECORD WHERE FULLPARTNUMBER = '<FULLPARTNUMBER>' AND STOCKTYPE IN ('Stock', 'Consigned', 'OEM', 'excess', '') AND QUANTITY >= 50";
                aryStatements[2] = "SELECT * FROM PARTRECORD WHERE BASENUMBER = '<BASENUMBER>' AND STOCKTYPE IN ('Stock', 'Consigned', 'OEM', 'excess', '') AND QUANTITY > 0";
                aryStatements[3] = "SELECT * FROM PARTRECORD WHERE BASENUMBERSTRIPPED = '<BASENUMBERSTRIPPED>' AND STOCKTYPE IN ('Stock', 'Consigned', 'OEM', 'excess', '') AND QUANTITY > 0";
                aryStatements[4] = "SELECT * FROM PARTRECORD WHERE BASENUMBERTRUNCED = '<BASENUMBERTRUNCED>' AND STOCKTYPE IN ('Stock', 'Consigned', 'OEM', 'excess', '') AND QUANTITY > 0";
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void ShowSelected()
        {
            try
            {
                txtCustom.Text = xSys.GetSetting("emailstocksql");
                for (Int32 i = 0; i < 5; i++)
                {
                    if (Tools.Strings.StrCmp(txtCustom.Text, aryStatements[i]))
                    {
                        switch (i)
                        {
                            case 0:
                                optFull.Checked = true;
                                break;
                            case 1:
                                optFull50.Checked = true;
                                break;
                            case 2:
                                optBase.Checked = true;
                                break;
                            case 3:
                                optStripped.Checked = true;
                                break;
                            case 4:
                                optTrunced.Checked = true;
                                break;
                        }
                    }
                }
                optCustom.Checked = true;
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void SaveTheSetting()
        {
            try
            {
                String strSQL = "";
                if (optFull.Checked)
                    strSQL = aryStatements[0];
                else if (optFull50.Checked)
                    strSQL = aryStatements[1];
                else if (optBase.Checked)
                    strSQL = aryStatements[2];
                else if (optStripped.Checked)
                    strSQL = aryStatements[3];
                else if (optTrunced.Checked)
                    strSQL = aryStatements[4];
                else if (optCustom.Checked)
                    strSQL = txtCustom.Text;
                else
                    strSQL = aryStatements[0];
                xSys.SetSetting("emailstocksql", strSQL);
                xSys.SetSetting_Boolean("emailmatchstock", true);
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        //Buttons
        private void cmdApply_Click(object sender, EventArgs e)
        {
            SaveTheSetting();
            this.Close();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}