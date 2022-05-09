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
    public partial class frmEMailTest : Form
    {
        public String BODYTEXT = "";
        public String RecipientAddress = "";
        public String SenderAddress = "";
        public String BodyType = "";

        public frmEMailTest()
        {
            InitializeComponent();
        }
        //Private Functions
        private void DoProcess()
        {
            try
            {
                BODYTEXT = txtBody.Text;
                RecipientAddress = txtRecipientAddress.GetValue_String();
                SenderAddress = txtSenderAddress.GetValue_String();
                if (optReq.Checked)
                    BodyType = "REQ";
                else if (optOffer.Checked)
                    BodyType = "OFFER";
                else
                    BodyType = txtSubject.Text;
                Close();
            }
            catch (Exception ee)
            {
                nError.HandleError(ee);
            }
        }
        private void DoCancel()
        {
            BODYTEXT = "";
            Close();
        }
        //Buttons
        private void cmdProcess_Click(object sender, EventArgs e)
        {
            DoProcess();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DoCancel();
        }
    }
}