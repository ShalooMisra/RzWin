
using System;
using System.Text;
using System.Windows.Forms;
namespace Rz5
{
    public partial class frmDockDateChecker : Form
    {
        private orddet_line l;
        private ContextRz x;
        private DateTime SelectedDate;
        bool expanded = false;
        public frmDockDateChecker(ContextRz xx, orddet_line ll)
        {
            l = ll;
            x = xx;
            InitializeComponent();

        }

        public bool CompleteLoad()
        {


            gbChange.Visible = false;

            if (string.IsNullOrEmpty(l.vendor_uid) && l.stocktype != Enums.StockType.Stock.ToString() && l.stocktype != Enums.StockType.Consign.ToString())
            {
                x.Leader.Tell("No Vendor detected for the line item.  Cannot derive address for dock date check.");
                return false;
            }
            SelectedDate = l.customer_dock_date;
            HandleDockColor();

            //Company
            company vendor = company.GetById(x, l.vendor_uid);
            lblCompanyName.Text = vendor.companyname;
            //Line Data
            lblLineCode.Text = l.linecode_sales.ToString();
            lblPartNumber.Text = l.fullpartnumber;
            lblCurrentDock.Text = l.customer_dock_date.ToString("MM/DD/YYYY");
            calDockDate.SetDate(l.customer_dock_date);

            if (vendor == null)
                return false;
            //if (string.IsNullOrEmpty(l.orderid_purchase))
            //    return false;
            //ordhed_purchase po = ordhed_purchase.GetById(x, l.orderid_purchase);
            if (!BuildAddress(x, vendor))
                return false;
            return true;
        }

        private void HandleDockColor()
        {
            //Handle Dock Date color indicator
            if (SelectedDate >= DateTime.Today.AddDays(1)) //if current dock is >= tomorrow           
                lblCurrentDock.ForeColor = System.Drawing.Color.Green;
            else
                lblCurrentDock.ForeColor = System.Drawing.Color.Red;
        }

        private bool BuildAddress(ContextRz x, company c)
        {
            companyaddress address = c.GetPrimaryBillingAddress(x);
            if (address != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(address.line1 + Environment.NewLine);//Line1
                if (!string.IsNullOrEmpty(address.line2))
                    sb.Append(address.line2 + Environment.NewLine);//Line2
                if (!string.IsNullOrEmpty(address.line3))
                    sb.Append(address.line3 + Environment.NewLine);//Line3
                sb.Append(address.adrcity + ", " + address.adrstate + " " + address.adrzip + Environment.NewLine);
                sb.Append(address.adrcountry);
                txtAddress.Text = sb.ToString();
                return true;
            }
            else
            {
                x.Leader.Tell("No Primary Billing Address found for this company.  Please correct and run this again.");
                return false;
            }
                

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheSysRz.TheLineLogic.SetInitialLineDockDates(l, calDockDate.SelectionRange.Start); 
            l.Update(RzWin.Context);
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbUpdateDock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(expanded)
            {//collapse
                expanded = false;
                Width = 265;
                gbChange.Visible = false;
                lbUpdateDock.Text = "Change ...";
            }
            else
            {
                expanded = true;
                Width = 517;
                gbChange.Visible = true;
                lbUpdateDock.Text = "Cancel ...";
            }
            
           
        }

        private void calDockDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            SelectedDate = calDockDate.SelectionRange.Start;
            lblCurrentDock.Text = SelectedDate.ToString("MM/dd/yyyy");
            HandleDockColor();
        }
    }
}
