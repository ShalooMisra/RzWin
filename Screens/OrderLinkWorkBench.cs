using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Win.Screens
{
    public partial class OrderLinkWorkBench : UserControl
    {
        public OrderLinkWorkBench()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        void Search()
        {
            ListArgs args = new ListArgs(RzWin.Context);
            args.TheTemplate = "InvoiceWorkBench";
            args.TheTable = "ordhed_invoice";
            args.TheClass = "ordhed_invoice";
            args.TheWhere = "isnull(isvoid, 0) = 0 ";
            if (Tools.Dates.DateExists(dtStart.GetValue_Date()))
            {
                if (!Tools.Dates.DateExists(dtEnd.GetValue_Date()))
                {
                    RzWin.Context.TheLeader.Tell("Select and end date");
                    return;
                }

                args.TheWhere += " and " + new Tools.Dates.DateRange(dtStart.GetValue_Date(), dtEnd.GetValue_Date()).GetSQL("orderdate");
            }

            String agent = ctl_Agent.GetUserName();
            if (Tools.Strings.StrExt(agent))
                args.TheWhere += " and agentname= '" + RzWin.Context.Filter(agent) + "'";


            args.TheWhere += " and exists ( select * from orddet_line where orddet_line.orderid_invoice = ordhed_invoice.unique_id and ( isnull(ordernumber_sales, '') = '' or ( isnull(vendor_name, '') > '' and isnull(ordernumber_purchase, '') = '' ) ) )";
            args.TheOrder = "orderdate";
            args.AddAllow = false;

            lv.Init(args);
        }

        private void OrderLinkWorkBench_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                lv.Width = this.ClientRectangle.Width - lv.Left;
            }
            catch { }
        }

        private void ctl_Agent_ClearUser(Tools.GenericEvent e)
        {
            ctl_Agent.SetUserName("");
        }

        private void ctl_Agent_ChangeUser(Tools.GenericEvent e)
        {
            String agent = "";
            String id = "";
            frmChooseUser.ChooseUserName(ref id, ref agent, RzWin.Logic.SalesPeople, false);
            if (Tools.Strings.StrExt(agent))
                ctl_Agent.SetUserName(agent);
        }
    }
}
