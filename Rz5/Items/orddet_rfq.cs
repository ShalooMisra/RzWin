using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Core;
using NewMethod;
using System.Drawing;

namespace Rz5
{
    public partial class orddet_rfq : orddet_rfq_auto
    {
        //Public Variables
        public bool IsCanceled
        {
            get
            {
                return Tools.Strings.StrCmp("canceled", status);
            }
        }

        public override Enums.OrderType OrderType
        {
            get
            {
                return Enums.OrderType.RFQ;
            }
            set
            {
                if (value != Enums.OrderType.RFQ)
                    throw new Exception("Invalid order type");
                base.OrderType = value;
            }
        }

        public orddet_quote MyReq;
        protected override void ParentDetailAbsorb(ContextRz context, orddet parent)
        {
            base.ParentDetailAbsorb(context, parent);
            if (parent == null)
                the_orddet_quote_uid = "";
            else
                the_orddet_quote_uid = parent.unique_id;
        }
        protected override void ParentDetailCache(ContextRz context)
        {
            base.ParentDetailCache(context);
            if (Tools.Strings.StrExt(the_orddet_quote_uid))
                m_ParentDetail = orddet_quote.GetById(context, the_orddet_quote_uid);
        }

        //Constructor
        public orddet_rfq()
        {
            OrderType = Enums.OrderType.RFQ;
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;
            switch (args.ActionName.ToLower())
            {
                case "vieworder":
                    ViewOrder((ContextRz)args.TheContext);
                    args.Handled = true;
                    break;
                case "makepo":
                    MakePO(xrz);
                    args.Handled = true;
                    break;
                case "givequote":
                    args.TheContext.Show(MakeQuoteExist(xrz));
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }
        public override void Inserting(Context x)
        {
            OrderType = Enums.OrderType.RFQ;
            base.Inserting(x);
        }
        public override void Updating(Context x)
        {
            base.Updating(x);

            orddet_old parentDetail = this.ParentDetailGet((ContextRz)x);
            if (parentDetail != null)
            {
                bool c = false;
                if (parentDetail.unitcost == 0 && unitprice != 0 && parentDetail.unitcost != unitprice)
                {
                    parentDetail.unitcost = unitprice;
                    c = true;
                }

                if (parentDetail.vendor_company_uid == "" && base_company_uid != "" && parentDetail.vendor_company_uid != base_company_uid)
                {
                    parentDetail.vendor_company_uid = base_company_uid;
                    parentDetail.vendorname = companyname;
                    c = true;
                }
                if (parentDetail.vendorcontactid == "" && base_companycontact_uid != "" && parentDetail.vendorcontactid != base_companycontact_uid)
                {
                    parentDetail.vendorcontactid = base_companycontact_uid;
                    parentDetail.vendorcontactname = contactname;
                    c = true;
                }
                if (c)
                    x.Update(parentDetail);
            }
            type_caption = "Vendor Bid";
        }

        protected override int GridColorCalc(Context x)
        {
            if (IsCanceled)
                return Color.Red.ToArgb();
            else
                return Color.Green.ToArgb();
        }

        public override void CacheDetails(ContextRz context)
        {
            DetailsSet(context.QtC("orddet_quote", "select * from orddet_quote where the_orddet_rfq_uid = '" + this.unique_id + "' order by fullpartnumber, orderdate"));
        }
        public override String GetTreeCaption(ContextRz context, bool show_company)
        {
            return context.TheSysRz.TheReqLogic.GetRFQTreeCaption(this, show_company);
        }
        public override void RefreshNodes(ContextRz context)
        {
            if (MyNodes == null)
                return;

            base.RefreshNodes(context);

            foreach (TreeNode n in MyNodes)
            {
                if (isinstock)
                {
                    n.ImageKey = "stock";
                    n.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (isselected)
                    {
                        if (IsBid)
                        {
                            if (is_accepted)
                                n.ImageKey = "bid_enabled_accepted";
                            else if (IsCanceled)
                                n.ImageKey = "bid_canceled";
                            else
                                n.ImageKey = "bid_enabled";
                        }
                        else
                            n.ImageKey = "rfq_enabled";

                        n.ForeColor = System.Drawing.Color.Green;
                        if (Tools.Strings.StrCmp(n.ImageKey, "bid_canceled"))
                            n.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        if (IsBid)
                        {
                            if (IsCanceled)
                                n.ImageKey = "bid_canceled";
                            else
                                n.ImageKey = "bid_disabled";
                        }
                        else
                            n.ImageKey = "rfq_disabled";

                        n.ForeColor = System.Drawing.Color.Gray;
                        if (Tools.Strings.StrCmp(n.ImageKey, "bid_canceled"))
                            n.ForeColor = System.Drawing.Color.Red;
                    }
                }

                n.SelectedImageKey = n.ImageKey;
            }
        }
        public override string ToString()
        {
            //if (IsBid)
            return "Bid for " + fullpartnumber;
            //else
            //    return "RFQ for " + fullpartnumber;
        }

        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeViewedByRFQ((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeEditedByRFQ((ContextRz)context, this, context.xUser);
        }
        //Public Functions
        public bool IsBid
        {
            get
            {
                return (unitprice > 0) && (quantityordered > 0);
            }
        }
        public String GetBestStockID()
        {
            MessageBox.Show("reorg");
            return "";

            /*
            if (Tools.Strings.StrExt(stockid))
                return stockid;

            if (Details == null)
                return "";
            foreach (orddet_quote q in Details)
            {
                if (Tools.Strings.StrExt(q.stockid))
                    return q.stockid;
            }
            return "";
             * */
        }
        protected virtual bool IsContactRequired()
        {
            return false;
        }
        public orddet_quote MakeQuoteExist(ContextRz context)
        {
            if (this.m_ParentDetail == null)
                this.ParentDetailCache(context);

            if (this.m_ParentDetail != null)
                return (orddet_quote)m_ParentDetail;

            if (Tools.Strings.StrExt(the_orddet_quote_uid))
            {
                m_ParentDetail = orddet_quote.GetById(context, the_orddet_quote_uid);
                if (m_ParentDetail != null)
                    return (orddet_quote)m_ParentDetail;
            }

            ////the company has to be known first.
            //String strCaption = "Please choose a customer";
            //String strCompanyID = "";
            //String strCompanyName = "";
            //String strContactID = "";
            //String strContactName = "";

            company company = null;
            companycontact contact = null;

            context.Leader.ChooseCompany(context, ref company, ref contact);
            if (company == null)
                return null;

            if (IsContactRequired())
            {
                if (contact == null)
                {
                    context.TheLeader.Tell("Please choose both a company and a contact.");
                    return null;
                }
            }
            TryCacheDeal(context);
            dealheader d = this.xDeal;
            if (d == null)
            {
                d = dealheader.MakeManualDeal(context, company, contact);
                d.Init(context);
            }

            //bool was_created = false;
            //dealcompany cc = d.MakeCompanyExist(strCompanyID, strCompanyName, strContactID, strContactName, false, ref was_created, false);

            orddet_quote q = orddet_quote.New(context);
            q.base_dealheader_uid = base_dealheader_uid;
            q.base_dealdetail_uid = base_dealdetail_uid;
            q.base_company_uid = company.unique_id;
            q.companyname = company.companyname;
            q.base_companycontact_uid = contact.unique_id;
            q.contactname = contact.contactname;
            q.CompanyVar.RefSet(context, company);
            q.ContactVar.RefSet(context, contact);
            q.fullpartnumber = fullpartnumber;
            q.quantityordered = quantityordered;
            q.alternatepart = alternatepart;
            q.internalpartnumber = internalpartnumber;
            q.vendor_company_uid = base_company_uid;
            q.vendorname = companyname;
            q.unitcost = unitprice;
            q.Insert(context);


            the_orddet_quote_uid = q.unique_id;
            Update(context);

            return q;
        }
        public void MakePO(ContextRz context)
        {
            company xc = CompanyObjectGet(context);
            if (xc == null)
                return;

            ordhed_purchase h = (ordhed_purchase)ordhed.CreateNew(context, Enums.OrderType.Purchase);

            if (!h.CanAssignCompany(context, xc))
                return;

            h.AbsorbCompany(context, xc);

            companycontact xct = ContactObjectGet(context);
            if (xct != null)
            {
                if (!h.CanAssignContact(context, xct))
                    return;

                h.AbsorbContact(context, xct);
            }

            h.base_dealheader_uid = base_dealheader_uid;
            context.Update(h);

            //CreateLinkedPartRecord(Rz3App.xMainForm.TheContextNM, Enums.StockType.Buy, false, h.unique_id, "");
            context.Update(this);

            orddet_line sp = (orddet_line)h.DetailsVar.RefAddNew(context);
            //sp.linecode = 1;
            sp.fullpartnumber = this.fullpartnumber;
            sp.unit_cost = this.unitprice;
            sp.quantity = Convert.ToInt32(quantityordered);
            sp.manufacturer = manufacturer;
            sp.datecode = datecode;
            sp.condition = condition;
            sp.vendor_name = companyname;
            sp.vendor_uid = base_company_uid;
            sp.vendor_contact_name = contactname;
            sp.vendor_contact_uid = base_companycontact_uid;
            context.Update(sp);

            context.Show(h);
        }
        public virtual void Accept(ContextRz context)
        {
            is_accepted = !is_accepted;
            context.Update(this);
            orddet_quote q = (orddet_quote)ParentDetailGet(context);
            if (q == null)
                throw new Exception("Associated req not detected.");
            if (is_accepted)
            {
                //update the cost on the req
                q.unitcost = unitprice;                
                company vend = CompanyVar.RefGet(context);
                q.StockType = this.StockType;
                q.stocktype = this.stocktype;
                q.vendorid = this.vendorid ?? "";
                q.vendorname = this.vendorname ?? "";
                q.vendor_company_uid = this.vendorid ?? "";
                q.stockid = this.stockid ?? "";
                q.importid = this.importid ?? "";
                q.isinstock = this.isinstock;
                if (IsGcatBid())

                {
                    q.description = this.description;
                    q.quantity  = 1;
                    q.quantityordered = 1;
                }
                else
                {
                    q.quantity += (int)this.quantityordered;
                }
                    
                q.vendorcontactid = "";
                q.vendorcontactname = "";
                companycontact vendContact = ContactVar.RefGet(context);
                if (vendContact != null)
                { 
                    q.vendorcontactid = vendContact.unique_id;
                    q.vendorcontactname = vendContact.contactname;
                }
               

            }
            else
            {
                q.unitcost = 0;
                q.quantity -= (int)this.quantityordered;                
                q.StockType = Enums.StockType.Any;
                q.stocktype = Enums.StockType.Any.ToString();
                q.vendorid = "";
                q.vendorname = "";
                q.vendor_company_uid =  "";
                q.stockid ="";
                q.importid =  "";
                q.isinstock = false;
                q.description = "";                           
                q.vendorcontactid = "";
                q.vendorcontactname = "";
            }

            context.Update(q);
        }

        private bool IsGcatBid()
        {
            //GCAT Partrecord = "ce60a6330c7a4ceea76e2086060d13b4"
            if (this.stockid == "ce60a6330c7a4ceea76e2086060d13b4")
                return true;
            return false;
        }

        public void AbsorbCompanyAndContact(company comp, companycontact cont)
        {
            if (comp == null)
            {
                this.base_company_uid = "";
                this.companyname = "";
            }
            else
            {
                this.base_company_uid = comp.unique_id;
                this.companyname = comp.companyname;
            }

            if (cont == null)
            {
                this.base_companycontact_uid = "";
                this.contactname = "";
            }
            else
            {
                this.base_companycontact_uid = cont.unique_id;
                this.contactname = cont.contactname;
            }
        }
        private void ViewOrder(ContextRz x)
        {
            ordhed_rfq o = null;
            try { o = (ordhed_rfq)this.OrderObject(x); }
            catch { }
            if (o == null)
            {
                x.TheLeader.Tell("This order could not be found.");
                return;
            }
            x.Show(new ShowArgsOrder(x, o, Enums.OrderType.RFQ));
        }
    }
}
