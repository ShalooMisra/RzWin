using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Rz5;
using NewMethod;

namespace RzInterfaceWin
{
    public partial class Rz5ConversionPanel : UserControl
    {
        //Public Variables
        public bool IsFinished = false;
        //Private Variables
        private Core.Leader leader;
        private Context context;
        private ImportRz5 ImportLogic;
        private int Year = 0;
        private string OrderType = "";
        private String Done = "";

        //Constructors
        public Rz5ConversionPanel()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init(ImportRz5 logic, int year)
        {
            ImportLogic = logic;
            Year = year;
        }
        public void Init(ImportRz5 logic, string ord_type)
        {
            ImportLogic = logic;
            OrderType = ord_type;
        }
        public void BeginConversion()
        {
            if (Year <= 0)
            {
                lblYear.Text = "Bad Year: " + Year.ToString();
                lblYear.ForeColor = Color.Red;
                return;
            }
            lblYear.Text = "Year: " + Year.ToString();
            bgw.RunWorkerAsync();
        }
        public void BeginReSave()
        {
            if (OrderType == "")
            {
                lblYear.Text = "Bad Order Type: " + OrderType;
                lblYear.ForeColor = Color.Red;
                return;
            }
            lblYear.Text = "OrderType: " + OrderType.ToString();
            bgw.RunWorkerAsync("resave");
        }
        //Status Events
        private void SetStatus(string s, Color c)
        {
            if (this.InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(SetStatusActually);
                this.Invoke(d, new object[] { s });
            }
            else
                SetStatusActually(s);
        }
        private void SetStatusActually(string s)
        {
            if (Tools.Strings.Split(rt.Text, "\n").Length >= 15)
                rt.Text = "";
            rt.Text = s + "\r\n" + rt.Text;
        }
        //Background Workers
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            leader = new Core.Leader();
            context = RzWin.Context.Clone();
            context.TheLeader = leader;
            leader.StatusSet += new StatusSetHandler(SetStatus);
            if (e.Argument != null)
            {
                if (e.Argument.ToString() == "resave")
                    ImportLogic.ResSaveAllOrderInstances((ContextRz)context, OrderType);
            }
            else
                Done = ImportLogic.ImportOrddetLines((ContextRz)context, Year);
            leader.StatusSet -= new StatusSetHandler(SetStatus);
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsFinished = true;
            rt.Text = Done;
        }
    }
}
