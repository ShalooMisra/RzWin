using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class dealcompany
    {
        public ArrayList Details;
        public ArrayList MyNodes;
        public TreeNode MyNode;

        public String companyname;
        public String contactname;
        public String email;
        public String phone;
        public String the_company_uid;
        public String the_companycontact_uid;
        public String the_dealheader_uid;

        //Public Functions
        public String Caption
        {
            get
            {
                String s = "";

                if (Tools.Strings.StrExt(companyname) && Tools.Strings.StrExt(contactname))
                    s = contactname + " at " + companyname;
                else if (Tools.Strings.StrExt(companyname))
                    s = companyname;
                else
                    s = "No Company Link";

                if (Tools.Strings.StrExt(email))
                    s += "  " + email;

                if (Tools.Strings.StrExt(phone))
                    s += "  " + phone;

                return s;
            }
        }
        public bool Matches(String strCompanyID, String strContactID)
        {
            //return (strCompanyID == the_company_uid) && (strContactID == the_companycontact_uid);
            return (strCompanyID == the_company_uid);
        }
        public void RemoveNodes()
        {
            try
            {
                if (MyNodes == null)
                    return;

                foreach (TreeNode n in MyNodes)
                {
                    n.Parent.Nodes.Remove(n);
                }
                MyNodes.Clear();
            }
            catch { }
        }
        public void AddNode(TreeNode n)
        {
            if (MyNodes == null)
                MyNodes = new ArrayList();
            MyNodes.Add(n);
        }
        public void RefreshNodes()
        {
            if (MyNodes == null)
                return;

            foreach (TreeNode n in MyNodes)
            {
                n.Text = Caption;
            }
        }

        public bool HasParentID(ContextRz context, String strID)
        {
            if (Details == null)
                return false;

            if (!Tools.Strings.StrExt(strID))
                return false;

            foreach (orddet_old d in Details)
            {
                if (d.ParentDetailGet(context) != null)
                {
                    if (d.ParentDetailGet(context).unique_id == strID)
                        return true;
                }
                else
                {
                    if (d is orddet_quote)
                    {
                        orddet_quote q = (orddet_quote)d;
                        if (Tools.Strings.StrCmp(q.the_orddet_rfq_uid, strID))
                            return true;
                    }
                    else
                    {
                        orddet_rfq b = (orddet_rfq)d;
                        if (Tools.Strings.StrCmp(b.the_orddet_quote_uid, strID))
                            return true;
                    }
                }
            }

            return false;
        }

        public int GetSelectedBidCount()
        {
            if (Details == null)
                return 0;

            int i = 0;

            foreach (orddet_old x in Details)
            {
                if (x.OrderType == Rz5.Enums.OrderType.RFQ)
                {
                    orddet_rfq q = (orddet_rfq)x;
                    if (q.isselected && q.IsBid)
                        i++;
                }
            }
            return i;
        }
        public orddet AddNewDetail(ContextRz context, dealheader xDeal, bool as_vend, orddet_old parent, bool as_serv)
        {
            orddet_old d;
            orddet_quote r;
            orddet_rfq b;
            //orddet_service s;

            if (as_vend && !as_serv)
            {
                b = orddet_rfq.New(context);
                b.warranty_period = ((SysRz5)context.xSys).TheCompanyLogic.GetCompanyWarranty(context, this.the_company_uid, true);
                AbsorbRFQDetail(context, b, parent);
                d = (orddet_old)b;
            }
            //else if (as_serv)
            //{
            //    s = new orddet_service(xDeal.xSys);
            //    AbsorbServiceDetail(s, parent);
            //    d = (orddet)s;
            //}
            else
            {
                r = orddet_quote.New(context);
                r.warranty_period = ((SysRz5)context.xSys).TheCompanyLogic.GetCompanyWarranty(context, this.the_company_uid);
                AbsorbQuoteDetail(context, r, parent);
                d = (orddet_old)r;
            }
            d.agentname = xDeal.agentname;
            d.base_mc_user_uid = xDeal.base_mc_user_uid;
            return d;
        }

        //public void AbsorbServiceDetail(orddet_service s, orddet_old parent)
        //{
        //    s.is_service = true;

        //    if (parent != null)
        //    {
        //        orddet_quote pq = (orddet_quote)parent;
        //        s.the_orddet_quote_uid = parent.unique_id;
        //    }

        //    AbsorbNewDetail(s, parent, false, true);
        //}

        public void AbsorbRFQDetail(ContextRz context, orddet_rfq b, orddet_old parent)
        {
            b.DetailsSet(new ArrayList());
            if (parent != null)
            {
                orddet_quote pq = (orddet_quote)parent;
                b.the_orddet_quote_uid = parent.unique_id;
                //the new rfq's target price is going to be the req's target
                b.target_price = pq.target_price;
                b.target_quantity = pq.target_quantity;
                b.alternatepart = pq.alternatepart;
                context.TheSysRz.TheOrderLogic.AbsorbRFQDetailExtra(b, pq);                
            }
            AbsorbNewDetail(context, b, parent, true, false);
        }

        public void AbsorbQuoteDetail(ContextRz context, orddet_quote q, orddet_old parent)
        {
            q.DetailsSet(new ArrayList());
            q.ServiceDetailsSet(new ArrayList());
            //q.AllOptions = new Dictionary<String, nObject>();

            if (parent != null)
            {
                q.the_orddet_rfq_uid = parent.unique_id;
            }

            AbsorbNewDetail(context, q, parent, false, false);
        }

        public void AbsorbNewDetail(ContextRz context, orddet_old d, orddet_old parent, bool as_vend, bool as_serv)
        {
            if (parent != null)
            {
                if (as_serv)
                {
                    d.alternatepart = parent.fullpartnumber;
                }
                else
                {
                    d.fullpartnumber = parent.fullpartnumber;
                    d.internalpartnumber = parent.internalpartnumber;
                    d.manufacturer = parent.manufacturer;
                    d.datecode = parent.datecode;
                    d.condition = parent.condition;
                }
                d.base_dealdetail_uid = parent.base_dealdetail_uid;

                if (d.ClassId == "orddet_rfq")
                {
                    orddet_rfq rq = (orddet_rfq)d;
                    rq.the_orddet_quote_uid = parent.unique_id;
                }
                else if (d.ClassId == "orddet_quote")
                {
                    orddet_quote rqx = (orddet_quote)d;
                    rqx.the_orddet_rfq_uid = parent.unique_id;
                }
            }
            else
                d.base_dealdetail_uid = Tools.Strings.GetNewID();

            d.base_company_uid = the_company_uid;
            d.companyname = companyname;
            d.base_companycontact_uid = the_companycontact_uid;
            d.contactname = contactname;
            d.orderdate = DateTime.Now;
            d.base_dealheader_uid = the_dealheader_uid;

            if (parent != null)
            {
                //must be here for the caching issue
                parent.AddDetail(context, d);
            }

            context.Update(d);

            if (parent != null)
            {
                //parent.AddDetail(d);
                //can't do this here; the caching issue

                d.ParentDetailSet(context, parent);
                parent.ShowDetail(context, d);
            }

            //this.companyname = "";

            Details.Add(d);
            ShowOneDetail(context, d);
        }

        public void ShowOneDetail(ContextRz context, orddet_old d)
        {
            if (MyNode == null)
                return;

            TreeNode dn = MyNode.Nodes.Add(d.GetTreeCaption(context));
            dn.Tag = d;
            d.MyNode = dn;
            d.AddNode(dn);
            d.RefreshNodes(context);
            MyNode.ExpandAll();
        }

        public nObject GetObjectByID(String strID)
        {
            foreach (nObject x in Details)
            {
                if (x.unique_id == strID)
                    return x;
            }
            return null;
        }

        public orddet AddStock(dealheader xDeal, IWin32Window owner)
        {
            return null;
            //ExtraSearch_partrecord ps = new ExtraSearch_partrecord();
            //ps.PartNumber = "";

            //partrecord p = (partrecord)frmChooseFromClipboard.Choose(Rz3App.xSys, "partrecord", Rz3App.xUser.unique_id, "", owner, ps);
            //if (p == null)
            //    return null;

            //return AddStock(xDeal, p);
        }
        public orddet AddStock(dealheader xDeal, partrecord p)
        {
            //orddet_quote rq = (orddet_quote)AddNewDetail(xDeal, false, null, false);
            //if (rq == null)
            //    return null;

            //rq.fullpartnumber = p.fullpartnumber;
            //rq.manufacturer = p.manufacturer;
            //rq.datecode = p.datecode;
            //rq.condition = p.condition;
            //rq.buytype = p.buytype;

            //if( Rz3App.xLogic.IsPhoenix )
            //{
            //    rq.description = p.description;
            //    rq.target_condition = p.condition;
            //    rq.target_manufacturer = p.manufacturer;
            //}

            //rq.ISave();

            //orddet_rfq b = null;
            //if (p.StockType == Rz3_Common.Enums.StockType.Stock || p.StockType == Rz3_Common.Enums.StockType.Buy)
            //{
            //    dealcompany sc = xDeal.MakeCompanyExist("", "Stock", "", "", true, false);
            //    b = AddStock(xDeal, rq, p, sc);
            //}
            //else if (p.StockType == Rz3_Common.Enums.StockType.Consign)
            //{
            //    if (Tools.Strings.StrExt(p.base_company_uid) && Tools.Strings.StrExt(p.companyname))
            //    {
            //        dealcompany sc = xDeal.MakeCompanyExist(p.base_company_uid, p.companyname, "", "", true, false);
            //        b = (orddet_rfq)sc.AddNewDetail(xDeal, true, rq, false);

            //        b.target_quantity = p.quantity;
            //        b.quantityordered = p.quantity;
            //        b.condition = p.condition;
            //        b.description = p.description;
            //        b.manufacturer = p.manufacturer;
            //        b.ISave();
            //    }
            //    else
            //    {
            //        context.TheLeader.Tell("Please enter a company name for this consignment before continuing.");
            //        return null;
            //    }
            //}
            //else if (Tools.Strings.StrExt(p.vendorid) && Tools.Strings.StrExt(p.vendorname))
            //{
            //    dealcompany sc = xDeal.MakeCompanyExist(p.vendorid, p.vendorname, "", "", true, false);
            //    b = (orddet_rfq)sc.AddNewDetail(xDeal, true, rq, false);

            //    b.target_quantity = p.quantity;
            //    b.quantityordered = p.quantity;
            //    b.condition = p.condition;
            //    b.description = p.description;
            //    b.manufacturer = p.manufacturer;
            //    b.ISave();
            //}
            //else if (Tools.Strings.StrExt(p.base_company_uid) && Tools.Strings.StrExt(p.companyname))
            //{
            //    dealcompany sc = xDeal.MakeCompanyExist(p.base_company_uid, p.companyname, "", "", true, false);
            //    b = (orddet_rfq)sc.AddNewDetail(xDeal, true, rq, false);

            //    b.target_quantity = p.quantity;
            //    b.quantityordered = p.quantity;
            //    b.condition = p.condition;
            //    b.description = p.description;
            //    b.manufacturer = p.manufacturer;
            //    b.ISave();
            //}
            //else
            //{
            //    return rq;
            //}

            //rq.ShowDetail(b);
            //return b;
            return null;
        }

        public orddet_rfq AddStock(ContextRz context, dealheader xDeal, orddet_quote rq, partrecord p, dealcompany sc)
        {
            orddet_rfq b = (orddet_rfq)sc.AddNewDetail(context, xDeal, true, rq, false);
            b.the_orddet_quote_uid = rq.unique_id;
            b.fullpartnumber = p.fullpartnumber;
            b.manufacturer = p.manufacturer;
            b.datecode = p.datecode;
            b.isinstock = true;
            b.stockid = p.unique_id;
            b.unitprice = p.cost;
            b.isselected = true;
            b.is_accepted = true;
            b.base_dealheader_uid = rq.base_dealheader_uid;
            context.Update(b);

            b.ParentDetailSet(context, rq);
            return b;
        }

        public static void CreateMissingDealCompanies(ContextNM context)
        {
            context.TheLeader.StartPopStatus();

            context.TheLeader.Comment("Creating missing customers...");
            CreateMissingCompanies(context, false);

            context.TheLeader.Comment("Creating missing vendors...");
            CreateMissingCompanies(context, true);

            context.TheLeader.Comment("Done.");
            context.TheLeader.StopPopStatus(true);
        }

        public static void CreateMissingCompanies(ContextNM x, bool as_vendor)
        {
            String sb = "0";
            String st = "orddet_quote";

            if (as_vendor)
            {
                sb = "1";
                st = "orddet_rfq";
            }

            String strSQL = "insert into dealcompany( unique_id, the_dealheader_uid, the_company_uid, companyname, the_companycontact_uid, contactname, as_vendor, as_service ) ";
            strSQL += " select cast(newid() as varchar(50)) as unique_id, isnull(base_dealheader_uid, '') as the_dealheader_uid, isnull(base_company_uid, '') as the_company_uid, isnull(companyname, '') as companyname, isnull(base_companycontact_uid, '') as the_companycontact_uid, isnull(contactname, '') as contactname, " + sb + " as as_vendor, 0 as as_service ";
            strSQL += " from " + st + " ";
            strSQL += " where not exists ";
            strSQL += " 		( select * from dealcompany where isnull(as_vendor, 0) = " + sb + " and isnull(dealcompany.the_dealheader_uid, '') = isnull(" + st + ".base_dealheader_uid, '') and isnull(dealcompany.the_company_uid, '') = isnull(" + st + ".base_company_uid, '') and isnull(dealcompany.the_companycontact_uid, '') = isnull(" + st + ".base_companycontact_uid, '') ) ";
            strSQL += " and isnull(base_dealheader_uid, '') > '' and isnull(base_company_uid, '') > '' ";
            strSQL += " group by base_dealheader_uid, base_company_uid, companyname, base_companycontact_uid, contactname ";

            x.Execute(strSQL);
        }

        public ArrayList GetExpandedDetails(bool vend)
        {
            if (vend)
                return Details;

            ArrayList ret = new ArrayList();

            foreach (orddet_quote q in Details)
            {
                //if (q.AllOptions == null)
                ret.Add(q);
                //else
                //{
                //    if (q.IsUniqueQuote)
                //        ret.Add(q);

                //    foreach (KeyValuePair<String, nObject> k in q.AllOptions)
                //    {
                //        orddet_quote qo = (orddet_quote)k.Value;
                //        if (qo.quantityordered > 0 && qo.unitprice > 0)
                //            ret.Add(qo);
                //    }
                //}
            }

            return ret;
        }

        public company CompanyObjectGet(ContextNM x)
        {
            return company.GetById(x, the_company_uid);
        }

        public companycontact ContactObjectGet(ContextNM x)
        {
            return companycontact.GetById(x, the_companycontact_uid);
        }
    }
}
