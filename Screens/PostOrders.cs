using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;
using System.Collections;

namespace RzInterfaceWin
{
    public partial class PostOrders : UserControl
    {
        //Private Variables
        private PostOrdersArgs Args = new PostOrdersArgs();

        //Constructors
        public PostOrders()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init()
        {
            Args = new PostOrdersArgs();
            DoSearch();
        }
        public void DoResize()
        {
            try
            {
                gbOptions.Top = 5;
                gbOptions.Left = 5;
                gbOptions.Height = this.ClientRectangle.Height - (gbOptions.Top * 2);
                pCommands.Top = 5;
                pCommands.Left = gbOptions.Right + 2;
                pCommands.Width = this.ClientRectangle.Width - pCommands.Left - 5;
                lv.Left = pCommands.Left;
                lv.Top = pCommands.Bottom + 2;
                lv.Width = pCommands.Width;
                lv.Height = this.ClientRectangle.Height - lv.Top - 5;
                SizeColumns();
            }
            catch { }
        }
        //Private Functions
        private void Post()
        {
            if (bgwPost.IsBusy)
                return;
            Args.PostList = new List<ordhed_new>();
            foreach (ListViewItem xLst in lv.CheckedItems)
            {
                Args.PostList.Add((ordhed_new)xLst.Tag);
            }
            if (Args.PostList.Count <= 0)
                return;
            throb.ShowThrobber();
            bgwPost.RunWorkerAsync();
        }
        private void PostActually()
        {
            Args.PostOrders(RzWin.Context);
        }
        private void DoSearch()
        {
            if (bgwSearch.IsBusy)
                return;
            throb.ShowThrobber();
            bgwSearch.RunWorkerAsync(GetPostSearchArgs());
        }
        private void DoSearchActually(PostSearchArgs args)
        {
            Args.DoSearch(RzWin.Context, args);
        }
        private PostSearchArgs GetPostSearchArgs()
        {
            PostSearchArgs p = new PostSearchArgs();
            p.Invoice = chkInvoice.Checked;
            p.Purchase = chkPurchase.Checked;
            p.RMA = chkRMA.Checked;
            p.VRMA = chkVRMA.Checked;
            p.Service = chkService.Checked;
            //partial or complete options?
            return p;
        }
        private void ShowResults()
        {
            lv.Items.Clear();
            lv.SuspendLayout();
            try
            {
                foreach (ordhed_invoice o in Args.Invoices)
                {
                    AddLVLine(o);
                }
                foreach (ordhed_purchase o in Args.Purchases)
                {
                    AddLVLine(o);
                }
                foreach (ordhed_rma o in Args.RMAs)
                {
                    AddLVLine(o);
                }
                foreach (ordhed_vendrma o in Args.VRMAs)
                {
                    AddLVLine(o);
                }
                foreach (ordhed_service o in Args.Services)
                {
                    AddLVLine(o);
                }
            }
            catch { }
            lv.ResumeLayout();
        }
        private void AddLVLine(ordhed_new o)
        {
            if (o == null)
                return;
            string s = o.PostStatus(RzWin.Context);
            ListViewItem xLst = lv.Items.Add(o.ordertype);
            xLst.SubItems.Add(o.ordernumber);
            xLst.SubItems.Add(o.companyname);
            double post_amount = 0;
            foreach (orddet_line l in o.ListPostableLines(RzWin.Context))
            {
                switch (o.OrderType)
                {
                    case Rz5.Enums.OrderType.Purchase:
                        post_amount += l.total_cost;
                        break;
                    case Rz5.Enums.OrderType.RMA:
                        post_amount += l.total_price_rma;
                        break;
                    case Rz5.Enums.OrderType.VendRMA:
                        post_amount += l.total_price_vendrma;
                        break;
                    default:
                        post_amount += l.total_price;
                        break;
                }
            }
            if (post_amount == 0)
                post_amount = o.ordertotal;
            xLst.SubItems.Add(Tools.Number.MoneyFormat(post_amount));
            ListViewItem.ListViewSubItem sub = xLst.SubItems.Add(s);
            sub.ForeColor = Color.Green;
            if (!Tools.Strings.StrCmp("complete", s))
                sub.ForeColor = Color.Red;
            xLst.Tag = o;            
        }
        private void CheckUncheckAll(bool check)
        {
            foreach (ListViewItem xLst in lv.Items)
            {
                xLst.Checked = check;
            }
        }
        private void SizeColumns()
        {
            int count = 1;
            foreach (ColumnHeader c in lv.Columns)
            {
                int perc = 0;
                switch (count)
                {
                    case 1:
                    case 4:
                        perc = 15;
                        break;
                    case 2:
                    case 5:
                        perc = 17;
                        break;
                    case 3:
                        perc = 32;
                        break;
                }
                count += 1;
                c.Width = Convert.ToInt32(lv.Width * (perc / (Decimal)100.0));
            }
        }
        private void ShowSelectedOrder()
        {
            try
            {
                ListViewItem xLst = lv.SelectedItems[0];
                ordhed_new o = (ordhed_new)xLst.Tag;
                RzWin.Context.Show(o);
            }
            catch { }
        }
        //Buttons
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DoSearch();
        }
        private void cmdPost_Click(object sender, EventArgs e)
        {
            Post();
        }
        private void cmdCheck_Click(object sender, EventArgs e)
        {
            CheckUncheckAll(true);
        }
        private void cmdUnCheck_Click(object sender, EventArgs e)
        {
            CheckUncheckAll(false);
        }
        //Control Events
        private void PostOrders_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lv_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectedOrder();
        }
        //Menu Items
        private void toolOpen_Click(object sender, EventArgs e)
        {
            ShowSelectedOrder();
        }
        //Background Workers
        private void bgwPost_DoWork(object sender, DoWorkEventArgs e)
        {
            PostActually();
        }
        private void bgwPost_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
            RzWin.Context.TheLeader.Tell("Done.");
            DoSearch();
        }
        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            PostSearchArgs p = (PostSearchArgs)e.Argument;
            DoSearchActually(p);
        }
        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowResults();
            throb.HideThrobber();            
        }
    }
}
