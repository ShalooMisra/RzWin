using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace RzSensible
{
    public partial class ArAp : Rz5.ArAp
    {
        //Private Variables
        private Rz5.Enums.OrderType TheType = Rz5.Enums.OrderType.Any;
        private Tools.Dates.DateRange TheRange = new Tools.Dates.DateRange();

        //Constructors
        public ArAp()
        {
            InitializeComponent();
        }
        //Private Functions
        private void ShowAll()
        {
            lvOrders.Clear();
            lv.Items.Clear();
            SetUpColumns();
            CurrentCompany = null;
            String strTypes = "";
            String join = "";
            String extra = "";
            String id = compStub.GetCompanyID();
            if (Tools.Strings.StrExt(id))
                extra = " and ordhed.base_company_uid = '" + id + "' ";    
            if (pDateRange.Enabled)
            {
                TheRange = new Tools.Dates.DateRange(dtStart.GetValue_Date(), dtEnd.GetValue_Date());
                extra += " and ordhed.orderdate " + TheRange.GetBetweenSQL();
            }
            if (TheType == Rz5.Enums.OrderType.Invoice)
            {
                strTypes = " 'invoice' ";
                join = " inner join ordhed on ordhed.unique_id = orddet_line.orderid_invoice ";
            }
            else if (TheType == Rz5.Enums.OrderType.Purchase)
            {
                strTypes = " 'purchase' ";
                join = " inner join ordhed on ordhed.unique_id = orddet_line.orderid_purchase ";
            }
            else
                return;
            lvOrders.AsyncMode = false;
            if (optOrders.Checked)
            {
                lvOrders.ShowTemplate("arap_orders", "ordhed");
                lvOrders.ShowData("ordhed", " isnull(ordhed.isvoid, 0) = 0 and ordertype in (" + strTypes + ") " + extra, "ordertype, orderdate, companyname");
            }
            else
            {
                lvOrders.ShowTemplate("arap_order_lines2", "orddet_line");
                string SQL = "select " + lvOrders.GetFieldList("orddet_line").Replace("orddet_line.alternatepart_03", "ordhed.orderreference").Replace("orddet_line.alternatepart_04", "ordhed.trackingnumber") + " from orddet_line " + join + " where isnull(ordhed.isvoid, 0) = 0 and ordhed.ordertype in (" + strTypes + ") " + extra + " order by ordhed.ordertype, ordhed.orderdate, ordhed.companyname";
                lvOrders.ShowData(SQL, "ordhed", -1, false);
            }
        }
        private void SetPast3()
        {
            dtStart.SetValue(DateTime.Now.Subtract(new TimeSpan(90, 0, 0, 0)));
            dtEnd.SetValue(DateTime.Now);
            ShowAll();
        }
        private void SetPast12()
        {
            dtStart.SetValue(new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, 1));
            dtEnd.SetValue(DateTime.Now);
            ShowAll();
        }
        private void DoCheckChanged()
        {
            if (chkUseDate.Checked)
            {
                pDateRange.Enabled = true;
                dtStart.SetValue(DateTime.Now);
                dtEnd.SetValue(DateTime.Now);
            }
            else
            {
                pDateRange.Enabled = false;
                dtStart.ClearDate();
                dtEnd.ClearDate();
            }
        }
        //Control Events
        private void chkUseDate_CheckedChanged(object sender, EventArgs e)
        {
            DoCheckChanged();
        }
        //Buttons
        private void cmdAllInvoices_Click(object sender, EventArgs e)
        {
            TheType = Rz5.Enums.OrderType.Invoice;
            ShowAll();
        }
        private void cmdAllPurchases_Click(object sender, EventArgs e)
        {
            TheType = Rz5.Enums.OrderType.Purchase;
            ShowAll();
        }
        private void cmdPast3_Click(object sender, EventArgs e)
        {
            SetPast3();
        }
        private void cmdPast12_Click(object sender, EventArgs e)
        {
            SetPast12();
        }
    }
}
