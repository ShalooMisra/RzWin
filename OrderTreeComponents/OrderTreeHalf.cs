using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class OrderTreeHalf : UserControl
    {
        //Public Events
        public event OrderTreeObjectClickHandler ObjectClicked;
        public event OrderTreeObjectClickHandler ObjectDeleted;
        public event OrderTreeObjectClickHandler AddOppositeDetail;
        public event OrderTreeObjectClickHandler CloseAllOpenObjects;
        public event OrderTreeObjectClickHandler AddOppositeServiceDetail;
        public event OrderAddedHandler OrderAdded;
        public event OrderTreeObjectClickHandler SaveAllRequest;
        //Public Variables
        public OrderTree xTree;
        public bool LimitedMode = false;
        public String RestrictParentID = "";
        //Protected Variables
        protected dealheader xDeal;
        protected DealHalf TheHalf = null;
        protected DealHalf TheOtherHalf = null;
        //Private Variables
        private TreeNode CompanyNode;
        private String m_CompanyCaption = "";

        //Constructors
        public OrderTreeHalf()
        {
            InitializeComponent();
        }
        //Public Virtual Functions
        public virtual void CompleteLoad(dealheader d, DealHalf half, DealHalf other_half)
        {
            xDeal = d;
            TheHalf = half;
            TheOtherHalf = other_half;
            DoResize();
        }

        void InitUn()
        {
            InitUnNodes(tv.Nodes);

            try
            {
                tv.Nodes.Clear();
            }
            catch { }
        }

        protected virtual void AcceptBid(orddet_rfq b)
        {
            if (b != null)
            {
                b.Accept(RzWin.Context);
                b.RefreshNodes(RzWin.Context);
            }
        }

        void InitUnNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode n in nodes)
            {
                try
                {
                    InitUnNodes(n.Nodes);
                    Object x = n.Tag;
                    if (x != null)
                    {
                        if (x is dealcompany)
                        {
                            dealcompany c = (dealcompany)x;
                            c.MyNode = null;
                            if (c.MyNodes != null)
                            {
                                c.MyNodes.Clear();
                                c.MyNodes = null;
                            }
                        }
                        else if (x is orddet_old)
                        {
                            orddet_old d = (orddet_old)x;
                            d.MyNode = null;
                            if (d.MyNodes != null)
                            {
                                d.MyNodes.Clear();
                                d.MyNodes = null;
                            }
                        }
                        n.Tag = null;
                    }
                }
                catch { }
            }
        }

        public virtual void AddOneCompany(dealcompany c, string caption)
        {
            TreeNode n = CompanyNode.Nodes.Add(caption);
            n.Tag = c;
            c.MyNode = n;
            c.AddNode(n);
            n.ImageKey = "person";
            n.SelectedImageKey = "person";
            foreach (orddet_old d in c.Details)
            {
                bool con = true;
                if (Tools.Strings.StrExt(RestrictParentID))
                {
                    if (d.ParentDetailGet(RzWin.Context) == null)
                        con = false;
                    else
                        con = (d.ParentDetailGet(RzWin.Context).unique_id == RestrictParentID);
                }
                if (con)
                {
                    c.ShowOneDetail(RzWin.Context, d);
                    foreach (orddet_old x in d.DetailsList())
                    {
                        d.ShowDetail(RzWin.Context, x);
                    }
                }
            }
            CompanyNode.ExpandAll();
        }
        public virtual orddet DetailAdd()
        {
            company comp = null;
            companycontact cont = null;

            if (!RzWin.Leader.ChooseCompany(RzWin.Context, ref comp, ref cont))
                return null;

            orddet d = TheHalf.DetailAdd(RzWin.Context, comp, cont);
            if (d != null)
            {
                //see if the company is already displayed
                //dealcompany c = MakeCompanyExist(comp, cont);
                //c.Details.Add(d);
                //c.ShowOneDetail(d);
                ReShow();

                FireObjectClicked(d);
            }
            return d;
        }
        public virtual bool QuoteClicked()
        {
            //if (RzLicense.LicenseType == LicenseTypes.Lite)
            //{
            //    Rz3App.xMainForm.ShowUpgradeToPro();
            //    return false;
            //}

            return true;
        }
        //Protected Virtual Functions
        protected virtual void InitMenu()
        {

        }
        protected virtual void ShowTree(String strCompanyCaption)
        {
            m_CompanyCaption = strCompanyCaption;
            tv.BeginUpdate();
            tv.Nodes.Clear();
            try
            {
                CompanyNode = tv.Nodes.Add(strCompanyCaption);
                CompanyNode.ImageKey = "people";
                CompanyNode.SelectedImageKey = "people";
                foreach (KeyValuePair<String, dealcompany> kvp in TheHalf.CompaniesList(RzWin.Context))
                {
                    if (!Tools.Strings.StrExt(RestrictParentID) || kvp.Value.HasParentID(RzWin.Context, RestrictParentID))
                        AddOneCompany(kvp.Value, ((dealcompany)kvp.Value).Caption);
                }
            }
            catch { }
            tv.ExpandAll();
            tv.EndUpdate();
        }
        protected virtual bool CreateSOClicked()
        {
            //if (RzLicense.LicenseType == LicenseTypes.Lite)
            //{
            //    Rz3App.xMainForm.ShowUpgradeToPro();
            //    return false;
            //}

            return true;
        }
        protected virtual bool AddToSOClicked(orddet_rfq d)
        {
            return true;
        }
        protected virtual bool AddToFQSOClicked(orddet_quote q)
        {
            return true;
        }
        protected virtual void StockAdd()
        {

        }
        //Protected Functions
        protected void FireObjectClicked(nObject x)
        {
            if (ObjectClicked != null)
                ObjectClicked(x, "");
        }
        protected void FireSaveAllRequest()
        {
            if (SaveAllRequest != null)
                SaveAllRequest(null, "");
        }
        protected void FireOrderAdded(ordhed o)
        {
            if (OrderAdded != null)
                OrderAdded(o);
        }
        protected void FireCloseAllOpenObjects(ordhed o)
        {
            if (CloseAllOpenObjects != null)
                CloseAllOpenObjects(o, "");
        }
        //Public Functions
        public void FireObjectDeleted(nObject x)
        {
            if (ObjectDeleted != null)
                ObjectDeleted(x, "");
        }
        public virtual void DoResize()
        {
            try
            {
                tv.Left = 0;
                tv.Top = 0;
                tv.Width = this.ClientRectangle.Width; ;
                tv.Height = this.ClientRectangle.Height;

                int theta = 25;

                cmdNew.Left = this.ClientRectangle.Width - (cmdNew.Width + theta);
                cmdImport.Left = this.ClientRectangle.Width - (cmdImport.Width + theta);
                cmdQuote.Left = this.ClientRectangle.Width - (cmdQuote.Width + theta);
                cmdCreateSO.Left = this.ClientRectangle.Width - (cmdCreateSO.Width + theta);
                cmdXL.Left = this.ClientRectangle.Width - (cmdXL.Width + theta);
                cmdImportReverse.Left = this.ClientRectangle.Width - (cmdImportReverse.Width + theta);
            }
            catch { }
        }
        public void ReShow()
        {
            ShowTree(m_CompanyCaption);
        }
        public dealcompany GetSelectedCompany()
        {
            try
            {
                return (dealcompany)tv.SelectedNode.Tag;
            }
            catch { return null; }
        }
        public orddet_old GetSelectedDetail()
        {
            try
            {
                return (orddet_old)tv.SelectedNode.Tag;
            }
            catch { return null; }
        }
        public OrderTreeNodeHandle GetSelectedHandle()
        {
            try
            {
                return (OrderTreeNodeHandle)tv.SelectedNode.Tag;
            }
            catch { return null; }
        }
        public void AddOtherDetail(orddet d)
        {
            orddet other = null;

            if (d is orddet_quote)
                other = xDeal.BidReceive(RzWin.Context, (orddet_quote)d);
            else
            {
                orddet_quote q = xDeal.CustomerHalf.QuoteAdd(RzWin.Context);
                orddet_rfq b = (orddet_rfq)d;
                b.the_orddet_quote_uid = q.unique_id;
                b.Update(RzWin.Context);

                q.fullpartnumber = b.fullpartnumber;
                q.Update(RzWin.Context);

                q.CacheDetails(RzWin.Context);
                other = q;
            }

            ReShowAll();
            FireObjectClicked(other);
        }
        public void HideOptions()
        {
            cmdNew.Visible = false;
            cmdImport.Visible = false;
            cmdQuote.Visible = false;
            cmdCreateSO.Visible = false;
        }
        public void MakePartVisible(String part)
        {

            foreach (TreeNode n1 in tv.Nodes)
            {
                foreach (TreeNode n2 in n1.Nodes)
                {
                    foreach (TreeNode n in n2.Nodes)
                    {

                        if (Tools.Strings.HasString(n.Text, part))
                        {
                            tv.Focus();
                            n.EnsureVisible();
                            tv.SelectedNode = n;
                            return;
                        }
                    }
                }
            }
        }
        //Private Functions
        private void ReShowAll()
        {
            //xTree.ReShow();
        }
        protected virtual void ShowImport(bool opp)
        {
        }
        private void ShowQuoteStats(orddet_quote q)
        {
            frmQuoteStats f = new frmQuoteStats();
            f.CompleteLoad(q.unique_id, false);
            f.Show();
        }
        private orddet_quote GetSelectedQuote()
        {
            orddet_quote q = null;
            orddet d = GetSelectedDetail();
            if (d == null)
            {
                d = GetSelectedHandle().xDetail;
                if (d == null)
                    return null;
            }
            if (!(d is orddet_quote))
                return null;
            q = (orddet_quote)d;
            return q;
        }
        private void PrintReqReport(orddet_quote q, bool purchasing)
        {
            xTree.ShowReqReport(q, purchasing);
        }
        //Buttons
        private void cmdNew_Click(object sender, EventArgs e)
        {
            DetailAdd();
        }
        private void cmdImport_Click(object sender, EventArgs e)
        {
            ShowImport(false);
        }
        private void cmdQuote_Click(object sender, EventArgs e)
        {
            QuoteClicked();            

        }
        private void cmdXL_Click(object sender, EventArgs e)
        {
            if (xDeal == null)
                return;
            xDeal.ExportToExcelAsCustomer(RzWin.Context);
        }
        private void cmdCreateSO_Click(object sender, EventArgs e)
        {
            CreateSOClicked();
        }
        //Control Events
        private void OrderTreeHalf_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void tv_Click(object sender, EventArgs e)
        {
            try
            {
                MouseEventArgs a = (MouseEventArgs)e;
                if (a.Button == MouseButtons.Right)
                    return;

                NodeShow(tv.SelectedNode);
            }
            catch { }
        }

        public void NodeShow(TreeNode node)
        {
            Object x = node.Tag;
            if (x == null)
                return;

            String s = x.GetType().ToString();
            if (s.EndsWith("OrderTreeNodeHandle"))
            {
                OrderTreeNodeHandle h = (OrderTreeNodeHandle)x;
                FireObjectClicked(h.xDetail);
            }
            else
            {
                orddet d = (orddet)x;
                FireObjectClicked(d);
            }
        }

        public List<TreeNode> NodesGather()
        {
            List<TreeNode> nodes = new List<TreeNode>();

            NodesGather(tv.Nodes, nodes);

            return nodes;
        }

        void NodesGather(TreeNodeCollection nodes, List<TreeNode> ret)
        {
            foreach (TreeNode n in nodes)
            {
                ret.Add(n);
                NodesGather(n.Nodes, ret);
            }
        }

        private void tv_MouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo i = tv.HitTest(new Point(e.X, e.Y));
            if (i == null)
                return;

            if (i.Node == null)
                return;

            tv.SelectedNode = i.Node;
        }
        //Menus
        private void mnuAddDetail_Click(object sender, EventArgs e)
        {
            dealcompany c = GetSelectedCompany();
            if (c != null)
            {
                orddet d = TheHalf.DetailAdd(RzWin.Context, c.CompanyObjectGet(RzWin.Context), c.ContactObjectGet(RzWin.Context));  // c.AddNewDetail(xDeal, as_vendor, null, false);
                if (d != null)
                {
                    ReShow();
                    FireObjectClicked(d);
                }
            }
            else
            {
                orddet d = GetSelectedDetail();
                if (d != null)
                {
                    AddOtherDetail(d);
                }
            }
        }
        private void mnuTree_Opening(object sender, CancelEventArgs e)
        {
            InitMenu();
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            dealcompany c = GetSelectedCompany();
            if (c != null)
                return;
            else
            {
                orddet_old d = GetSelectedDetail();
                if (d != null)
                {
                    if (!RzWin.Leader.AreYouSure("remove " + d.GetTreeCaption(RzWin.Context)))
                        return;
                    d.base_dealheader_uid = "";
                    d.base_dealdetail_uid = "";
                    d.Update(RzWin.Context);
                    TheHalf.Details.Remove(d.unique_id);
                    d.RemoveNodes();
                    d.Delete(RzWin.Context);
                    FireObjectDeleted(d);
                }
                else
                {
                    OrderTreeNodeHandle h = GetSelectedHandle();
                    if (h != null)
                    {
                        if (h.xDetail is orddet_quote)
                        {
                            orddet_quote r = (orddet_quote)h.xDetail;
                            r.the_orddet_rfq_uid = "";
                            r.ParentDetailGet(RzWin.Context).DetailsGet(RzWin.Context).Remove(r);
                            r.ParentDetailSet(RzWin.Context, null);
                            r.Update(RzWin.Context);
                        }
                        else
                        {
                            orddet_rfq b = (orddet_rfq)h.xDetail;
                            b.the_orddet_quote_uid = "";
                            b.ParentDetailGet(RzWin.Context).DetailsGet(RzWin.Context).Remove(b);
                            b.ParentDetailSet(RzWin.Context, null);
                            b.Update(RzWin.Context);
                        }
                        h.MyNode.Parent.Nodes.Remove(h.MyNode);
                    }
                }
            }
        }
        private void mnuViewCompany_Click(object sender, EventArgs e)
        {
            dealcompany c = GetSelectedCompany();
            if (c == null)
                return;

            company xc = company.GetById(RzWin.Context, c.the_company_uid);
            if (xc != null)
                RzWin.Context.Show(xc);
        }
        private void mnuViewContact_Click(object sender, EventArgs e)
        {
            dealcompany c = GetSelectedCompany();
            if (c == null)
                return;

            companycontact xo = companycontact.GetById(RzWin.Context, c.the_companycontact_uid);
            if (xo != null)
                RzWin.Context.Show(xo);
        }
        private void mnuShow_Click(object sender, EventArgs e)
        {
            orddet_old d = GetSelectedDetail();
            if (d == null)
                return;

            d.isselected = !d.isselected;
            d.Update(RzWin.Context);
            d.RefreshNodes(RzWin.Context);
        }
        private void mnuQuote_Click(object sender, EventArgs e)
        {
            QuoteClicked();
        }
        private void mnuAccept_Click(object sender, EventArgs e)
        {
            orddet_rfq b = null;

            OrderTreeNodeHandle h = GetSelectedHandle();
            if (h != null)
            {
                if (h.xDetail.OrderType == Enums.OrderType.RFQ)
                {
                    b = (orddet_rfq)h.xDetail;
                }
            }
            else
            {
                try
                {
                    b = (orddet_rfq)GetSelectedDetail();
                }
                catch { }
            }

            //if (b != null)
            //{
            //    b.Accept();
            //    b.RefreshNodes();
            //}

            AcceptBid(b);
        }
        private void mnuAddStock_Click(object sender, EventArgs e)
        {
            StockAdd();
        }
        private void mnuAddService_Click(object sender, EventArgs e)
        {
            orddet d = GetSelectedDetail();
            if (d != null)
            {
                if (AddOppositeServiceDetail != null)
                    AddOppositeServiceDetail(d, "");
            }
        }
        private void mnuCreateAllPOs_Click(object sender, EventArgs e)
        {
            //foreach (TreeNode n in CompanyNode.Nodes)
            //{
            //    try
            //    {
            //        dealcompany c = (dealcompany)n.Tag;
            //        if( c != null )
            //            CreateOrder(true, c);
            //    }
            //    catch { }
            //}
        }
        private void mnuAttachDetail_Click(object sender, EventArgs e)
        {
            orddet d = GetSelectedDetail();
            if (d != null)
            {
                if (AddOppositeDetail != null)
                    AddOppositeDetail(d, "existing");
            }
        }
        private void mnuCut_Click(object sender, EventArgs e)
        {
            orddet_old d = GetSelectedDetail();
            if (d == null)
            {
                RzWin.Leader.Tell("Please select a detail to cut.");
                return;
            }

            d.base_dealheader_uid = "";
            d.base_dealdetail_uid = "";
            d.Update(RzWin.Context);
            d.RemoveNodes();
            d.Delete(RzWin.Context);
            FireObjectDeleted(d);

            orddet.TheCutDetail = d;
        }
        private void mnuPaste_Click(object sender, EventArgs e)
        {
            try
            {
                if (orddet.TheCutDetail == null)
                {
                    RzWin.Leader.Tell("Please select 'cut' on an item before pasting.");
                    return;
                }

                dealcompany c = GetSelectedCompany();
                if (c == null)
                {
                    RzWin.Leader.Tell("Please choose 'paste' on a company in the tree.");
                    return;
                }

                orddet d = orddet.TheCutDetail;
                orddet.TheCutDetail = null;

                d.unique_id = "";
                d.Update(RzWin.Context);
                c.AbsorbQuoteDetail(RzWin.Context, (orddet_quote)d, null);
                if (d != null)
                    FireObjectClicked(d);
            }
            catch (Exception ex)
            {

            }
        }
        private void mnuDuplicate_Click(object sender, EventArgs e)
        {
            //orddet d = GetSelectedDetail();
            //if (d == null)
            //    return;

            //orddet n = d.Duplicate();

            //dealcompany c = xDeal.MakeCompanyExist(d.base_company_uid, d.companyname, d.base_companycontact_uid, d.contactname, as_vendor, false);

            //if (c == null)
            //    return;

            //c.AbsorbNewDetail(n, null, as_vendor, false);

            //FireObjectClicked(n);

        }
        private void mnuOrder_Click(object sender, EventArgs e)
        {
            CreateSOClicked();
        }
        private void mnuAddToSO_Click(object sender, EventArgs e)
        {
            //orddet_rfq r = null;
            //orddet d = GetSelectedDetail();
            //if (d == null)
            //{
            //    d = GetSelectedHandle().xDetail;
            //    if (d == null)
            //        return;
            //}
            //if (!(d is orddet_rfq))
            //    return;
            //r = (orddet_rfq)d;
            //AddToSOClicked(r);
        }
        private void mnuQuoteStats_Click(object sender, EventArgs e)
        {
            orddet_quote q = null;
            orddet d = GetSelectedDetail();
            if (d == null)
            {
                d = GetSelectedHandle().xDetail;
                if (d == null)
                    return;
            }
            if (!(d is orddet_quote))
                return;
            q = (orddet_quote)d;
            ShowQuoteStats(q);
        }
        private void mnuPrintAgent_Click(object sender, EventArgs e)
        {
            orddet_quote q = GetSelectedQuote();
            if (q == null)
                return;
            PrintReqReport(q, false);
        }
        private void mnuPrintPurchasing_Click(object sender, EventArgs e)
        {
            orddet_quote q = GetSelectedQuote();
            if (q == null)
                return;
            PrintReqReport(q, true);
        }
        private void mnuAddToFQSO_Click(object sender, EventArgs e)
        {
            orddet_quote q = null;
            orddet d = GetSelectedDetail();
            if (d == null)
            {
                d = GetSelectedHandle().xDetail;
                if (d == null)
                    return;
            }
            if (!(d is orddet_quote))
                return;
            q = (orddet_quote)d;
            AddToFQSOClicked(q);
        }
    }

    //Public Delegates
    public delegate void OrderTreeObjectClickHandler(nObject x, String strExtra);
    public delegate void OrderAddedHandler(ordhed o);
}
