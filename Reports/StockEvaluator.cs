using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Tools.Database;
using Core;

namespace Rz5
{
    public partial class StockEvaluator : nWebReport
    {
        //Public Variables
        public bool TempTableMode = false;
        public bool OpenRfqMode = false;
        public ArrayList OpenRfqParts = null;
        //Private Variables
        private String[] lists;        
        private StockEvaluatorCore TheCore;

        //Constructors
        public StockEvaluator()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void DoResize()
        {
            ShowOptionSpace = true;
            if (gbOptions != null)
                OptionBoxWidth = gbOptions.Width;
            base.DoResize();
            try
            {
                gbOptions.Left = 0;
                gbOptions.Top = 0;
                gbOptions.Height = this.ClientRectangle.Height - gb.Height;

                if (TempTableMode)
                {
                    rt.Visible = true;
                    rt.BringToFront();
                    rt.Height = gbOptions.Height - rt.Top - 5;
                    lblLists.Text = "Paste Part Numbers Below";
                }
            }
            catch { }
        }
        public override void RunReport()
        {
            if (TempTableMode)
            {
                lists = Tools.Strings.SplitLines(rt.Text);
                if (!Tools.Strings.StrExt(rt.Text))
                    lists = new String[] { };
            }
            else
            {
                lists = Tools.Strings.SplitLines(txtLists.Text);
                if (!Tools.Strings.StrExt(txtLists.Text))
                    lists = new String[] { };
            }
            if (lists.Length == 0)
            {
                if (TempTableMode)
                    RzWin.Leader.Tell("Please enter at least 1 part number before continuing.");
                else
                    RzWin.Leader.Tell("Please enter at least 1 list name before continuing.");
                return;
            }
            wb.ReloadWB();
            if (chkExcel.Checked)
            {
                ReportTargetExcel exl = GetReportTargetExcel();
                exl.InitExcel();
                TheCore.TheTarget = exl;
            }
            else
                TheCore.TheTarget = GetReportTargetHtml();
            base.RunReport();
            ShowThrobber();
            StartAsync();
        }
        public override void DoAsync()
        {
            if (TempTableMode)
            {
                string table = GetTempTable();
                string temp = "TempTable:" + table;
                SearchList(RzWin.Context, temp, (DataConnectionSqlServer)RzWin.Context.Data.Connection);
                RzWin.Context.Execute("drop table " + table);
                return;
            }
            foreach (String s in lists)
            {
                SearchList(RzWin.Context, s, (DataConnectionSqlServer)RzWin.Context.Data.Connection);
            }
        }
        public override void AsyncFinished()
        {
            base.AsyncFinished();

            if (chkExcel.Checked)
            {
                ((ReportTargetExcel)TheCore.TheTarget).ShowExcel();
                wb.Clear();
                wb.Add("Done.");
            }
            else
                wb.Add(((ReportTargetHtml)TheCore.TheTarget).HtmlResult);

            HideThrobber();
        }
        //Public Virtual Functions
        public virtual ReportTargetExcel GetReportTargetExcel()
        {
            return new ReportTargetExcel();
        }
        public virtual ReportTargetHtml GetReportTargetHtml(bool use_hyper_links = true)
        {
            return new ReportTargetHtml(use_hyper_links);
        }
        //Public Functions
        public void SetListNames(ArrayList names)
        {
            txtLists.Text = "";
            foreach (String s in names)
            {
                txtLists.Text += s + "\r\n";
            }
        }
        //Private Functions
        private void SearchList(ContextRz context, String s, DataConnectionSqlServer data)
        {
            TheCore.SearchList(context, s, data);
        }
        private String GetTempTable()
        {
            string table = "temp_" + Tools.Strings.GetNewID() + "_table";
            RzWin.Context.Execute("create table " + table + " (fullpartnumber varchar(255))");
            foreach (string s in lists)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                RzWin.Context.Execute("insert into " + table + " (fullpartnumber) values ('" + RzWin.Context.Filter(s.Trim()) + "')");
            }
            return table;
        }
        //Buttons
        private void cmdGo_Click(object sender, EventArgs e)
        {
            TheCore = ((SysRz5)RzWin.Context.xSys).ThePartLogic.GetStockEvaluatorCore();

            TheCore.bReqs = chkReqs.Checked;
            TheCore.bBids = chkBids.Checked;
            TheCore.bSales = chkSales.Checked;
            TheCore.bPurchases = chkPurchases.Checked;
            TheCore.bInventory = chkInventory.Checked;
            TheCore.bStock = chkStock.Checked;
            TheCore.bConsign = chkConsign.Checked;
            TheCore.bExcess = chkExcess.Checked;
            TheCore.bBuy = chkAllocated.Checked;
            TheCore.bOnlyTotals = chkOnlyTotals.Checked;

            TheCore.OpenRfqMode = OpenRfqMode;
            TheCore.OpenRfqParts = OpenRfqParts;            

            RunReport();
        }
    }
}
