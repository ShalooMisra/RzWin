using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;

namespace CoreWin
{
    public partial class frmTest : Form
    {
        //Public Variables
        public ProveResult TheResult;
        //Private Variables
        private Context TheContext;
        private ProofLogic TheTest;
        private bool Auto = false;

        //Constructors
        public frmTest()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad(Context x, bool auto_run = false)
        {
            if (x == null)
                return false;
            TheContext = x;
            TheTest = TheContext.TheSys.ProofLogic;
            Auto = auto_run;
            return true;
        }
        public void RunTests()
        {
            rt.Text = "";
            cmdTest.Enabled = false;
            cmdTest.Text = "Running....";
            if (TheTest == null)
            {
                TheResult = new ProveResult();
                TheResult.Passed = false;
                TheResult.Log("Test logic is null.");
                ShowPassFail();
                return;
            }
            TheResult = TheTest.Prove(TheContext);
            cmdTest.Enabled = true;
            cmdTest.Text = "Run All Tests";
            if (TheResult == null)
            {
                TheResult = new ProveResult();
                TheResult.Passed = false;
                TheResult.Log("Test result is null.");
            }
            rt.Text = TheResult.ToString();
            ShowPassFail();
            if (TheContext.Sys.ProofLogic.InProveMode)
                Close();
        }
        //Private Functions
        private void ShowPassFail()
        {
            lblResult.Text = "Done: " + Tools.Dates.FormatHMS(TheResult.Duration.TotalSeconds);
            if (TheResult.Passed)
                lblResult.ForeColor = Color.Green;
            else
                lblResult.ForeColor = Color.Red;
        }
        //Buttons
        private void cmdTest_Click(object sender, EventArgs e)
        {
            RunTests();
        }
        //Control Events
        private void frmTest_Load(object sender, EventArgs e)
        {
            if (Auto)
                timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            RunTests();
        }
    }
}
