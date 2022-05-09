using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class DealImport
        : UserControl
    {
        public ContextRz TheContext
        {
            get
            {
                return RzWin.Context;
            }
        }
        public dealheader xDeal;
        public company vendor;
        public String ImportClass = "";
        public bool Opposite = false;
        public OrderTree xTree;

        public DealImport()
        {
            InitializeComponent();
        }
        public void InitBid(dealheader d, company v)
        {
            xDeal = d;
            vendor = v;
            ImportClass = "orddet_rfq";
            Opposite = false;
            gb.Text = "Bid Import";
            lblCompany.Text = v.companyname;
            lblContact.Text = "";
            lblViewCompany.Visible = false;
            lblViewContact.Visible = false;
            SetForBids();
        }
        public void InitReq(dealheader d, bool opp)
        {
            xDeal = d;
            //xDC = dc;
            ImportClass = "orddet_quote";
            Opposite = opp;
            lblCompany.Text = d.customer_name;

            if (d.contact_name == "")
            {
                lblViewContact.Visible = false;
                lblContact.Text = "<none>";
            }
            else
            {
                lblViewContact.Visible = true;
                lblContact.Text = d.contact_name;
            }

            gb.Text = "Requirement Import";
            SetForReqs();
        }
        public virtual void SetForReqs()
        {
            dv.CompleteLoad();
            dv.SetAcceptCaption("Import These Requirements");
            dv.AddCommonField("fullpartnumber", "Part Number", "part|number", true);
            dv.AddCommonField("target_quantity", "Target Quantity", "qty|quantity|quanity");
            dv.AddCommonField("manufacturer", "Manufacturer", "mfg|mfr|manufacturer|brand");
            dv.AddCommonField("datecode", "Date Code", "dc|datecode");
            dv.AddCommonField("target_price", "Target Price", "targetprice|price");
            dv.AddCommonField("internalcomment", "Quick Note", "note|notes|quick note");
            dv.AddCommonField("delivery", "Delivery", "delivery|need by|delivery date|dock date");
            dv.AddCommonField("description", "Description", "descr|description|descr.");
            dv.AddCommonField("alternatepart", "Alternate Part #", "alternate|internal");
            dv.AddCommonField("unitprice", "Quote Price", "");
            dv.AddCommonField("quantityordered", "Quote Quantity", "");

            dv.AddExtraField("bidprice", "Bid Price", "cost|bid");
            dv.AddExtraField("bidquantity", "Bid Quantity", "bidquantity");
            dv.AddExtraField("bidvendor", "Bid Vendor", "vendor");
            dv.AddExtraField("bidcontact", "Bid Vendor Contact", "vendor contact");

            dv.SetClass("orddet_quote");
            dv.Clear();
        }
        public void SetForBids()
        {
            dv.CompleteLoad();
            dv.SetAcceptCaption("Import These Bids");
            dv.AddCommonField("fullpartnumber", "Part Number", "part|number", true);
            dv.AddCommonField("target_quantity", "Target Quantity", "qty|quantity|quanity");
            dv.AddCommonField("manufacturer", "Manufacturer", "mfg|mfr|manufacturer|brand");
            dv.AddCommonField("datecode", "Date Code", "dc|datecode");
            dv.AddCommonField("target_price", "Target Price", "targetprice|price");
            dv.AddCommonField("internalcomment", "Quick Note", "note|notes|quick note");
            dv.AddCommonField("delivery", "Delivery", "delivery|need by|delivery date|dock date");
            dv.AddCommonField("description", "Description", "descr|description|descr.");
            dv.AddCommonField("alternatepart", "Alternate Part #", "alternate|internal");
            dv.AddCommonField("unitprice", "Bid Price", "");
            dv.AddCommonField("quantityordered", "Bid Quantity", "");
            dv.AddCommonField("leadtime", "Lead Time", "");
            dv.AddCommonField("packaging", "Packaging", "");
            dv.SetClass("orddet_rfq");
            dv.Clear();
        }
        private void lblViewCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TheContext.Show(company.GetById(RzWin.Context, xDeal.customer_uid));
        }
        private void lblViewContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TheContext.Show(companycontact.GetById(RzWin.Context, xDeal.contact_uid));
        }
        private void dv_Accept()
        {
            if (xTree != null)
                xTree.IsLoading = true;
            dv.SetStatus("Importing...");
            RunImport();
            dv.SetStatus("Done");
            if (Tools.Strings.StrExt(dv.CurrentFile))
                AttachFile((ContextRz)TheContext, dv.CurrentFile);
            dv.NotifyFinished();
        }
        public void AttachFile(ContextRz x, string file)
        {
            if (xDeal == null)
                return;
            if (!Tools.Strings.StrExt(file))
                return;
            if (!Tools.Files.FileExists(file))
                return;
            partpicture p = partpicture.New(x);
            p.the_ordhed_uid = xDeal.unique_id;
            if (partpicture.IsPictureFileName(file))
                p.SetPictureDataByFile(x, file);
            else
                p.SetDocDataByFile(RzWin.Context, file);
            p.filename = Tools.Files.GetFileNameNoExtention(file);
            String ext = System.IO.Path.GetExtension(file);
            if (Tools.Strings.StrExt(ext))
                p.filetype = ext;
            p.description = Tools.Files.GetFileNameNoExtention(file);
            if (p.unique_id == "")
                p.InsertTo(x, RzWin.Logic.PictureData);
            else
                p.UpdateTo(x, RzWin.Logic.PictureData);
            p.SavePictureData(x);
        }
        private void RunImport()
        {
            if (Tools.Strings.StrCmp(ImportClass, "orddet_quote"))
                RunReqImport();
            else
                RunBidImport();
        }
        public void RunBidImport()
        {
            int count = 1;
            ArrayList a = dv.GetObjects();
            foreach (nObjectHolder h in a)
            {
                orddet_rfq q = (orddet_rfq)h.xObject;
                if (Tools.Strings.StrExt(q.fullpartnumber))
                {
                    q.linecode = count;
                    count++;

                    q.CompanyObjectSet(vendor);
                    q.xDeal = xDeal;
                    q.base_dealheader_uid = xDeal.unique_id;
                    q.Update(RzWin.Context);
                    xDeal.VendorHalf.Details.Add(q.unique_id, q);
                }
            }
        }
        public void RunReqImport()
        {
            String changeId = TheContext.TheDelta.StartChangeCache();
            bool is_bom = RzWin.Context.Leader.AskYesNo("Is this a BOM?");
            if (xDeal.is_bom != is_bom)
                xDeal.is_bom = is_bom;

            int count = 1;
            ArrayList a = dv.GetObjects();
            //if (a.Count > 1)//Multiple reqs = don't send an email per req, find a way to combine.
            foreach (nObjectHolder h in a)
            {
                Int32 BidQuantity = Convert.ToInt32(h.Get_Long("bidquantity"));
                Double BidPrice = h.Get_Double("bidprice");
                String BidVendor = h.Get_String("bidvendor");
                String BidContact = h.Get_String("bidcontact");
                orddet_quote q = (orddet_quote)h.xObject;

                q.is_bom = is_bom;
                if (((SysRz5)TheContext.xSys).TheReqLogic.ReqImportIgnoreBlankPart() || Tools.Strings.StrExt(q.fullpartnumber))
                {
                    q.linecode = count;
                    count++;
                    if (!Tools.Strings.StrExt(q.unique_id))
                        q.Insert(TheContext);
                    xDeal.CustomerHalf.QuoteAbsorb(TheContext, q);
                    if (Tools.Strings.StrExt(BidVendor) && (BidQuantity > 0 || BidPrice > 0))
                    {
                        company vendor = company.GetByName(RzWin.Context, BidVendor);
                        if (vendor == null)
                        {
                            vendor = company.New(RzWin.Context);
                            vendor.companyname = BidVendor;
                            vendor.Insert(RzWin.Context);
                        }
                        companycontact vendorcontact = null;
                        if (Tools.Strings.StrExt(BidContact))
                        {
                            vendorcontact = (companycontact)RzWin.Context.QtO("companycontact", "select * from companycontact where base_company_uid = '" + vendor.unique_id + "' and contactname = '" + RzWin.Context.Filter(BidContact) + "'");
                            if (vendorcontact == null)
                            {
                                vendorcontact = vendor.AddContact(RzWin.Context);
                                vendorcontact.contactname = BidContact;
                                vendorcontact.Update(RzWin.Context);
                            }
                        }
                        if (vendor != null)
                        {
                            dealcompany cv = null;
                            bool was_created = false;
                            if (BidQuantity == 0)
                                BidQuantity = Convert.ToInt32(q.target_quantity);
                            orddet_rfq b = q.AddBid(TheContext);
                            b.fullpartnumber = q.fullpartnumber;
                            b.quantityordered = BidQuantity;

                            if (b.quantityordered == 0)
                                b.quantityordered = q.quantityordered;

                            b.unitprice = BidPrice;

                            //2012_11_12 why wasn't the vendor info here?
                            b.CompanyObjectSet(vendor);
                            b.ContactObjectSet(vendorcontact);

                            b.Update(RzWin.Context);
                        }
                    }
                }
            }

            if (a.Count >= 1)
            {
                // TheContext.TheSysRz.TheQuoteLogic.SendManagerEmailAlert(TheContext,a);
            }

            TheContext.TheDelta.EndChangeCache(TheContext, changeId);
        }
        private void DealImport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void DoResize()
        {
            try
            {
                dv.Width = this.ClientRectangle.Width - dv.Left;
                dv.Height = this.ClientRectangle.Height - dv.Top;
            }
            catch { }
        }
        public void Clear()
        {
            xDeal = null;
            ImportClass = "";
            lblViewCompany.Visible = false;
            lblCompany.Text = "<none>";
            lblViewContact.Visible = false;
            lblContact.Text = "<none>";
            gb.Text = "";
            dv.Clear();
        }
        private void dv_AfterImport()
        {
            if (xTree != null)
            {
                xTree.IsLoading = false;
                xTree.LoadReqQuoteLV();
            }
        }
    }
}
