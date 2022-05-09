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
    public partial class DealList : UserControl
    {
        //Public Variables
        public dealheader xDeal;
        public ImageList il;
        public Dictionary<String, nLineHandle> DisplayedObjects = new Dictionary<string, nLineHandle>();
        //Public Events
        public event EventHandler ReloadRequest;
        public event ReqLineEventHandler ReceiveBid;
        public event BidLineEventHandler MakePO;
        public event EventHandler SavedObject;
        public event EventHandler GotResize;

        //Constructors
        public DealList()
        {
            InitializeComponent();
        }
        //Public Functions
        public void ShowObject(nObject o)
        {
            String msg = "";
            ShowObject(o, ref msg);
        }
        public bool ShowObject(nObject o, ref String msg)
        {
            if (o == null)
            {
                msg = "the item is null";
                return false;
            }
            if (DisplayedObjects.ContainsKey(o.unique_id))
            {
                nLineHandle h = DisplayedObjects[o.unique_id];
                msg = "the item is already displayed";
                return false;
            }
            else
            {
                nLine l = null;
                switch (o.ClassId.ToLower())
                {
                    case "orddet_quote":
                        IReqLine rl = ((LeaderWinUserRz)RzWin.Context.TheLeader).GetReqLine();
                        orddet_quote qo = (orddet_quote)o;
                        Image qi = null;
                        if( il != null )
                        {
                            if (qo.IsQuoted)
                                qi = il.Images["quote"];
                            else
                                qi = il.Images["req"];
                        }
                        
                        //the event hookup has to be first, because the control uses it to show or hide the link for it
                        rl.ReceiveBid += new ReqLineEventHandler(rl_ReceiveBid);
                        rl.CompleteLoad(qo, qi, true);
                        l = (nLine)rl;
                        break;
                    case "orddet_rfq":
                        IBidLine bl = ((LeaderWinUserRz)RzWin.Context.TheLeader).GetBidLine();
                        orddet_rfq rq = (orddet_rfq)o;
                        Image i = null;
                        if (il != null)
                        {
                            if (rq.isinstock)
                                i = il.Images["stock"];
                            else
                                i = il.Images["rfq"];
                        }

                        bl.MakePO += new BidLineEventHandler(bl_MakePO);
                        bl.CompleteLoad((orddet_rfq)o, i);
                        
                        l = (nLine)bl;
                        break;
                    case "orddet_service":
                        MessageBox.Show("reorg");
                        //ServiceLine sl = new ServiceLine();
                        //orddet_service sq = (orddet_service)o;
                        //if( il != null )
                        //    sl.CompleteLoad((orddet_service)o, il.Images["service"]);
                        //else
                        //    sl.CompleteLoad((orddet_service)o, null);
                        //l = sl;
                        break;
                }
                if (l != null)
                {
                    if (DisplayedObjects.Count > 0)
                    {
                        ArrayList keys = new ArrayList();
                        foreach (KeyValuePair<string, nLineHandle> kvp in DisplayedObjects)
                        {
                            nLineHandle lne = (nLineHandle)kvp.Value;
                            lne.xLine.CompleteSave();
                            keys.Add(kvp.Key);
                        }
                        foreach (string s in keys)
                        {
                            CloseObjectIfOpen(s);
                        }
                    }
                    //DisplayedObjects = new Dictionary<string, nLineHandle>();
                    //this.Controls.Clear();
                    this.Controls.Add(l);
                    l.CloseRequest += new nLineHandler(l_CloseRequest);
                    l.ExpandedChanged += new nLineHandler(l_ExpandedChanged);
                    l.SavedObject += new EventHandler(l_SavedObject);
                    l.ReloadRequest += new EventHandler(l_ReloadRequest);
                    DisplayedObjects.Add(o.unique_id, new nLineHandle(o, l));
                    l.DoResize();
                    l.ReSetFocus();
                }
                else
                {
                    msg = "l is null";
                    return false;
                }
            }
            ArrangeControls();
            FireResize();
            return true;
        }

        void InitUnLine(nLine l)
        {
            try
            {
                l.CloseRequest -= new nLineHandler(l_CloseRequest);
                l.ExpandedChanged -= new nLineHandler(l_ExpandedChanged);
                l.SavedObject -= new EventHandler(l_SavedObject);
                l.ReloadRequest -= new EventHandler(l_ReloadRequest);

                if( l is ReqLine )
                {
                    ((ReqLine)l).ReceiveBid -= new ReqLineEventHandler(rl_ReceiveBid);
                }
                else if (l is BidLine)
                {
                    ((BidLine)l).MakePO -= new BidLineEventHandler(bl_MakePO);
                }

                l.Dispose();
            }
            catch { }
        }

        public void InitUn()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    if (c is nLine)
                        InitUnLine((nLine)c);
                }

                this.Controls.Clear();
                if (DisplayedObjects != null)
                {
                    DisplayedObjects.Clear();
                    DisplayedObjects = null;
                }

                xDeal = null;
                il = null;
            }
            catch { }
        }
        public void CloseAllObjects()
        {
            try
            {
                Dictionary<string, nLineHandle> d = DisplayedObjects;
                foreach (KeyValuePair<string, nLineHandle> kvp in d)
                {
                    nLineHandle l = kvp.Value;
                    if (l != null)
                    {
                        DisplayedObjects.Remove(l.xObject.unique_id);
                        InitUnLine(l.xLine);
                        this.Controls.Remove(l.xLine);
                    }
                }
            }
            catch { }
        }
        public void CloseObjectIfOpen(String strID)
        {
            try
            {
                nLineHandle l = DisplayedObjects[strID];
                if (l != null)
                {
                    DisplayedObjects.Remove(strID);
                    InitUnLine(l.xLine);
                    this.Controls.Remove(l.xLine);
                }
            }
            catch { }

            //ArrangeControls();
            //FireResize();
        }
        public void ArrangeControls()
        {
            RzWin.Leader.Comment("Arranging controls...");
            int y = 0;

            foreach (KeyValuePair<String, nLineHandle> l in DisplayedObjects)
            {
                l.Value.xLine.Top = y;
                y += l.Value.xLine.Height;
                l.Value.xLine.Left = 0;
                l.Value.xLine.Width = this.ClientRectangle.Width - 20;
            }

            this.Height = y;
        }
        public void Remove(Control c)
        {
            Controls.Remove(c);
        }
        //Private Functions
        private void FireResize()
        {
            if (GotResize != null)
                GotResize(null, null);
        }
        //Control Events
        private void bl_MakePO(IBidLine l)
        {
            if (MakePO != null)
                MakePO(l);            
        }
        private void rl_ReceiveBid(IReqLine l)
        {
            if (ReceiveBid != null)
            {
                ReceiveBid(l);
                l_CloseRequest((nLine)l, l.CurrentObject, false);
            }
        }
        private void l_ReloadRequest(object sender, EventArgs e)
        {
            if (ReloadRequest != null)
                ReloadRequest(sender, e);
        }
        private void l_ExpandedChanged(nLine l, nObject xObject, bool delete)
        {
            ArrangeControls();
            FireResize();
        }
        private void l_CloseRequest(nLine l, nObject o, bool delete)
        {
            try
            {
                DisplayedObjects.Remove(l.CurrentObject.unique_id);
                this.Controls.Remove(l);

                InitUnLine(l);

                if (delete)
                {
                    switch (o.ClassId.ToLower())
                    {
                        case "orddet_quote":
                            orddet_quote q = (orddet_quote)o;
                            xDeal.RemoveReq(RzWin.Context, q);
                            ((ReqLine)l).ReceiveBid -= new ReqLineEventHandler(rl_ReceiveBid);
                            break;
                        case "orddet_rfq":
                            orddet_rfq b = (orddet_rfq)o;
                            xDeal.RemoveBid(RzWin.Context, b);
                            ((BidLine)l).MakePO -= new BidLineEventHandler(bl_MakePO);
                            break;
                        //case "orddet_service":
                        //    orddet_service s = (orddet_service)o;
                        //    xDeal.RemoveService(s);
                        //    break;
                    }
                }
                else
                {
                    switch (o.ClassId.ToLower())
                    {
                        case "orddet_quote":
                            orddet_quote q = (orddet_quote)o;
                            q.RefreshNodes(RzWin.Context);
                            break;
                        case "orddet_rfq":
                            orddet_rfq b = (orddet_rfq)o;
                            b.RefreshNodes(RzWin.Context);
                            break;
                        //case "orddet_service":
                        //    orddet_service s = (orddet_service)o;
                        //    s.RefreshNodes();
                        //    break;
                    }
                }
            }
            catch { }

            ArrangeControls();
            FireResize();

        }
        private void l_SavedObject(object sender, EventArgs e)
        {
            if (SavedObject != null)
                SavedObject(sender, e);
        }
    }
    public class nLineHandle
    {
        //Public Variables
        public nObject xObject;
        public nLine xLine;
        
        //Constructors
        public nLineHandle(nObject o, nLine l)
        {
            xObject = o;
            xLine = l;
        }
    }
}
