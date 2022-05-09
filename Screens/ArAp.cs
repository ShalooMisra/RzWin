using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using OfficeInterop;
using Tools.Database;

namespace Rz5
{
    public partial class ArAp : UserControl, ICompleteLoad
    {
        //Public Variables
        public SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.xSys;
            }
        }
        //Protected Variables
        protected Boolean bAddExtra = false;
        protected String TempTable;
        protected company CurrentCompany;
        //Private Variables
        private Boolean bReportComplete = false;
        private Boolean bAvoidFinish = false;

        //Constructors
        public ArAp()
        {
            InitializeComponent();
            throb.BackColor = Color.White;
            //lv.Set
        }
        //Public Virtual Functions
        public virtual void SetUpColumns()
        {
            lv.Columns.Clear();
            ColumnHeader com = lv.Columns.Add("Company");
            if (optReceivable.Checked)
                com.Text = "Customer";
            else if (optPayable.Checked)
                com.Text = "Vendor";
            com.Width = 109;
            ColumnHeader contact = lv.Columns.Add("Contact");
            contact.TextAlign = HorizontalAlignment.Left;
            contact.Width = 67;
            ColumnHeader extra = lv.Columns.Add("Phone");
            extra.TextAlign = HorizontalAlignment.Left;
            extra.Width = 78;
            ColumnHeader email = lv.Columns.Add("Email");
            email.TextAlign = HorizontalAlignment.Left;
            email.Width = 63;
            ColumnHeader c = lv.Columns.Add("Amount");
            c.TextAlign = HorizontalAlignment.Right;
            c.Width = 69;
            if (optReceivable.Checked)
                c.Text = "Receivable";
            else if (optPayable.Checked)
                c.Text = "Payable";
            else
            {
                if (!bAddExtra)
                {
                    lv.Columns.Remove(email);
                    lv.Columns.Remove(contact);
                }
                com.Width = 115;
                extra.Width = 78;
                c.Text = "Receivable";
                c.Width = 69;
                c.TextAlign = HorizontalAlignment.Right;
                c = lv.Columns.Add("Payable");
                c.Width = 60;
                c.TextAlign = HorizontalAlignment.Right;
                c = lv.Columns.Add("Balance");
                c.Width = 63;
                c.TextAlign = HorizontalAlignment.Right;
            }
        }
        public virtual void CalcData()
        {
            TempTable = "temp_" + Tools.Strings.GetNewID();
            String strSQL = "create table " + TempTable + " (";
            strSQL += " companyid varchar(255), ";
            strSQL += " companyname varchar(255), ";
            strSQL += " contact varchar(255), ";
            strSQL += " phone varchar(255), ";
            strSQL += " fax varchar(255), ";
            strSQL += " email varchar(255), ";
            strSQL += " is_locked bit, ";
            strSQL += " is_problem bit, ";
            strSQL += " is_pastdue bit, ";
            strSQL += " total_ap float, ";
            strSQL += " total_ar float ";
            strSQL += ") ";
            RzWin.Context.Execute(strSQL);

            strSQL = "insert into " + TempTable + " (companyid, companyname, contact, phone, fax, email, is_locked, is_problem, is_pastdue) ";
            strSQL += " select c.unique_id, c.companyname, c.primarycontact, c.primaryphone, c.primaryfax, c.primaryemailaddress, c.is_locked, c.is_problem, c.ispastdue from company c inner join ordhed o on o.base_company_uid = c.unique_id where o.ordertype in ('invoice', 'purchase', 'rma', 'vendrma') and isnull(o.isvoid, 0) = 0 and isnull(o.ispaid, 0) = 0 and o.outstandingamount > 0 ";
            if (CurrentCompany != null)
                strSQL += " and base_company_uid = '" + CurrentCompany.unique_id + "' ";
            strSQL += " group by c.unique_id, c.companyname, c.primarycontact, c.primaryphone, c.primaryfax, c.primaryemailaddress, c.is_locked, c.is_problem, c.ispastdue order by c.companyname";
            RzWin.Context.Execute(strSQL);

            strSQL = "update " + TempTable + " set total_ap = (select sum(isnull(outstandingamount, 0)) from ordhed o where o.base_company_uid = " + TempTable + ".companyid and o.ordertype in ('purchase', 'rma') and isnull(o.isvoid, 0) = 0 and isnull(o.ispaid, 0) = 0 and o.outstandingamount > 0)";
            RzWin.Context.Execute(strSQL);

            strSQL = "update " + TempTable + " set total_ar = (select sum(isnull(outstandingamount, 0)) from ordhed o where o.base_company_uid = " + TempTable + ".companyid and o.ordertype in ('invoice', 'vendrma') and isnull(o.isvoid, 0) = 0 and isnull(o.ispaid, 0) = 0 and o.outstandingamount > 0)";
            RzWin.Context.Execute(strSQL);

        }
        public virtual void ShowData()
        {
            String strSQL = "select * from " + TempTable + " where companyname > '' ";
            if (optReceivable.Checked)
                strSQL += " and total_ar > 0 ";
            else if (optPayable.Checked)
                strSQL += " and total_ap > 0 ";
            Double dblTotalAP = 0;
            Double dblTotalAR = 0;
            Double dblTotalBalance = 0;
            strSQL += " order by companyname";
            DataTable d = RzWin.Context.Select(strSQL);
            if (Tools.Data.DataTableExists(d))
            {
                foreach (DataRow r in d.Rows)
                {
                    ListViewItem i = lv.Items.Add(nData.NullFilter_String(r["companyname"]));
                    i.UseItemStyleForSubItems = false;
                    i.Tag = nData.NullFilter_String(r["companyid"]);
                    if (!optBoth.Checked || bAddExtra)
                        i.SubItems.Add(r["contact"].ToString());
                    i.SubItems.Add(r["phone"].ToString());
                    if (!optBoth.Checked || bAddExtra)
                        i.SubItems.Add(r["email"].ToString());
                    Double ar = Math.Round(nData.NullFilter_Float(r["total_ar"]), 2);
                    Double ap = Math.Round(nData.NullFilter_Float(r["total_ap"]), 2);
                    Double bal = ar - ap;
                    dblTotalAR += ar;
                    dblTotalAP += ap;
                    dblTotalBalance += bal;
                    ListViewItem.ListViewSubItem s;
                    if (optReceivable.Checked || optBoth.Checked)
                    {
                        s = i.SubItems.Add(nTools.MoneyFormat(ar));
                        if (ar < 0)
                            s.ForeColor = Color.Red;
                        else if (ar > 0)
                            s.ForeColor = Color.Green;
                    }
                    if (optPayable.Checked || optBoth.Checked)
                    {
                        s = i.SubItems.Add(nTools.MoneyFormat(ap));
                        if (ap < 0)
                            s.ForeColor = Color.Red;
                        else if (ap > 0)
                            s.ForeColor = Color.Blue;
                    }
                    if (optBoth.Checked)
                    {
                        s = i.SubItems.Add(nTools.MoneyFormat(bal));
                        if (bal < 0)
                            s.ForeColor = Color.Red;
                        else if (bal > 0)
                            s.ForeColor = Color.Green;
                    }
                }
            }
            else
                lv.Items.Add("<no results>");
            if (optReceivable.Checked || optBoth.Checked)
            {
                lblAR.Visible = true;
                lblARCap.Visible = true;
                lblAR.Text = "$ " + nTools.MoneyFormat(dblTotalAR);
                if (dblTotalAR > 0)
                    lblAR.ForeColor = Color.Green;
                else
                    lblAR.ForeColor = Color.Black;
            }
            else
            {
                lblAR.Visible = false;
                lblARCap.Visible = false;
            }
            if (optPayable.Checked || optBoth.Checked)
            {
                lblAP.Visible = true;
                lblAPCap.Visible = true;
                lblAP.Text = "$ " + nTools.MoneyFormat(dblTotalAP);
                if (dblTotalAP > 0)
                    lblAP.ForeColor = Color.Blue;
                else
                    lblAP.ForeColor = Color.Black;
            }
            else
            {
                lblAP.Visible = false;
                lblAPCap.Visible = false;
            }
            if (optBoth.Checked)
            {
                lblBalance.Visible = true;
                lblBalanceCap.Visible = true;
                lblBalance.Text = "$ " + nTools.MoneyFormat(dblTotalBalance);
                if (dblTotalBalance > 0)
                    lblBalance.ForeColor = Color.Green;
                else if (dblTotalBalance < 0)
                    lblBalance.ForeColor = Color.Red;
                else
                    lblBalance.ForeColor = Color.Black;
            }
            else
            {
                lblBalance.Visible = false;
                lblBalanceCap.Visible = false;
            }
            RzWin.Context.Execute("drop table " + TempTable);
        }
        public virtual string GetExtraSQL()
        {
            return "";
        }
        public virtual void AfterRunReport()
        {
           
        }
        public virtual void DoLVClick()
        {
            ShowSelectedCompanysOrders();
        }
        public virtual void DoLVMouseDown(MouseEventArgs e)
        {

        }
        //Public Functions
        public void CompleteLoad()
        {
            DoResize();
            lvOrders.ShowTemplate("arap_orders", "ordhed");
        }
        public void DoResize()
        {
            try
            {
                gb.Left = 2;
                gb.Top = 2;
                gb.Width = (this.ClientRectangle.Width - gb.Left) - 2;

                gbTotals.Left = gb.Left;
                gbTotals.Top = (this.ClientRectangle.Height - gbTotals.Height) - 2;
                gbTotals.Width = gb.Width;

                cmdExport.Top = (gbTotals.Top - cmdExport.Height) - 2;
                cmdExport2.Top = cmdExport.Top;

                lv.Left = gb.Left;
                lv.Top = gb.Bottom + 2;
                lv.Height = (cmdExport.Top - lv.Top) - 2;

                lvOrders.Left = lv.Right + 2;
                lvOrders.Top = lv.Top;
                lvOrders.Height = lv.Height;
                lvOrders.Width = (this.ClientRectangle.Width - lvOrders.Left) - 2;

                cmdExport.Left = lv.Left;
                cmdExport.Width = lv.Width;
                cmdExport2.Left = lvOrders.Left;
                cmdExport2.Width = lvOrders.Width;
            }
            catch
            {
            }
        }
        public void RunReport()
        {
            RunReport(false);
        }
        public void RunReport(bool AvoidFinish)
        {
            bAvoidFinish = AvoidFinish;
            lvOrders.Clear();
            lv.Items.Clear();
            SetUpColumns();
            CurrentCompany = null;
            String id = compStub.GetCompanyID();
            if (Tools.Strings.StrExt(id))
                CurrentCompany = company.GetById(RzWin.Context, id);
            throb.ShowThrobber();
            bg.RunWorkerAsync();
        }
        public void ShowOrdersByCompany(String strCompanyID)
        {
            String strTypes = "";
            String join = "";
            if (optReceivable.Checked)
            {
                strTypes = "'invoice', 'vendrma'";
                join = " inner join ordhed on ordhed.unique_id = orddet_line.orderid_invoice or ordhed.unique_id = orddet_line.orderid_vendrma ";
            }
            else if (optPayable.Checked)
            {
                strTypes = "'purchase', 'rma'";
                join = " inner join ordhed on ordhed.unique_id = orddet_line.orderid_purchase or ordhed.unique_id = orddet_line.orderid_rma ";
            }
            else
            {
                strTypes = "'invoice', 'purchase', 'rma', 'vendrma'";
                join = " inner join ordhed on ordhed.unique_id = orddet_line.orderid_purchase or ordhed.unique_id = orddet_line.orderid_rma or ordhed.unique_id = orddet_line.orderid_invoice or ordhed.unique_id = orddet_line.orderid_vendrma ";
            }
            String extra = GetExtraSQL();
            lvOrders.AsyncMode = false;
            if (optOrders.Checked)
            {
                lvOrders.ShowTemplate("arap_orders", "ordhed");
                lvOrders.ShowData("ordhed", "base_company_uid = '" + strCompanyID + "' and isnull(ordhed.isvoid, 0) = 0 and isnull(ordhed.ispaid, 0) = 0 and ordhed.outstandingamount > 0 and ordertype in (" + strTypes + ") " + extra, "ordertype, orderdate, companyname");
            }
            else
            {
                lvOrders.ShowTemplate("arap_order_lines2", "orddet_line");
                string SQL = "select " + lvOrders.GetFieldList("orddet_line").Replace("orddet_line.alternatepart_03", "ordhed.orderreference").Replace("orddet_line.alternatepart_04", "ordhed.trackingnumber") + " from orddet_line " + join + " where ordhed.base_company_uid = '" + strCompanyID + "' and isnull(ordhed.isvoid, 0) = 0 and isnull(ordhed.ispaid, 0) = 0 and ordhed.outstandingamount > 0 and ordhed.ordertype in (" + strTypes + ") " + extra + " order by ordhed.ordertype, ordhed.orderdate, ordhed.companyname";
                lvOrders.ShowData(SQL, "ordhed", -1, false);
                //lvOrders.ShowTemplate("arap_order_lines", "orddet");
                //string SQL = "select " + lvOrders.GetFieldList("orddet").Replace("orddet.alternatepart_03", "ordhed.orderreference").Replace("orddet.alternatepart_04", "ordhed.trackingnumber") + " from orddet inner join ordhed on ordhed.unique_id = orddet.base_ordhed_uid where ordhed.base_company_uid = '" + strCompanyID + "' and isnull(ordhed.isvoid, 0) = 0 and isnull(ordhed.ispaid, 0) = 0 and ordhed.outstandingamount > 0 and ordhed.ordertype in (" + strTypes + ") " + extra + " order by ordhed.ordertype, ordhed.orderdate, ordhed.companyname";
                //lvOrders.ShowData(SQL, "ordhed", -1, false);
            }
        }
        //Protected Functions
        protected void ShowSelectedCompanysOrders()
        {
            String s = GetSelectedCompanyID();
            if (Tools.Strings.StrExt(s))
                ShowOrdersByCompany(s);
        }
        protected String GetSelectedCompanyID()
        {
            try { return (String)lv.SelectedItems[0].Tag; }
            catch
            { }
            return "";
        }
        //Buttons
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RunReport();
        }
        private void cmdExport_Click(object sender, EventArgs e)
        {
            if (optBoth.Checked)
            {
                bReportComplete = false;
                bAddExtra = true;
                RunReport();
                while (!bReportComplete)
                {
                    Application.DoEvents();
                }
            }
            bAddExtra = false;
            List<FieldType> types = new List<FieldType>();
            types.Add(FieldType.String);//Company
            types.Add(FieldType.String);//Contact
            types.Add(FieldType.String);//Phone
            types.Add(FieldType.String);//Email
            types.Add(FieldType.Double);//Amount
            types.Add(FieldType.Double);//Receivable
            types.Add(FieldType.Double);//Payable
            types.Add(FieldType.Double);//Balance
            ToolsWin.Excel.ListViewToExcel(lv, types);
            if (optBoth.Checked)
                RunReport();
        }
        private void cmdExport2_Click(object sender, EventArgs e)
        {
            try
            {
                lvOrders.DoExport("excel");
            }
            catch (Exception ex)
            {
                RzWin.Context.Error(ex.Message);
            }
        }
        //Control Events
        private void ArAp_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lv_DoubleClick(object sender, EventArgs e)
        {

        }
        private void lv_Click(object sender, EventArgs e)
        {
            DoLVClick();
        }
        private void lv_MouseDown(object sender, MouseEventArgs e)
        {
            DoLVMouseDown(e);
        }
        //Background Workers
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            bReportComplete = false;
            CalcData();
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowData();
            throb.HideThrobber();
            bReportComplete = true;
            if (!bAvoidFinish)
                AfterRunReport();
            bAvoidFinish = false;
        }
        //Menus
        private void mnuViewOrders_Click(object sender, EventArgs e)
        {
            ShowSelectedCompanysOrders();
        }
    }
}