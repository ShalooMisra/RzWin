using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using NewMethod;

namespace Rz5
{
    public partial class ImportBids : UserControl
    {
        //Private Variables
        ContextRz TheContext;
        long Count = 0;

        //Constructors
        public ImportBids()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(ContextRz x)
        {
            TheContext = x;
            dv.DisableAccept();
            dv.CompleteLoad();
            dv.SetAcceptCaption("Import These Bids");
            dv.AddCommonField("companyname", "Vendor Name", "vendor|company", true);
            dv.AddCommonField("contactname", "Contact Name", "contact|contactname");
            dv.AddCommonField("fullpartnumber", "Part Number", "part|part number", true);
            dv.AddCommonField("quantityordered", "Quantity", "qty|quantity", true);
            dv.AddCommonField("unitprice", "Price", "price", true);
            dv.AddCommonField("manufacturer", "Manufacturer", "mfg|mfr|manufacturer|brand");
            dv.AddCommonField("datecode", "Date Code", "dc|datecode");
            dv.AddCommonField("packaging", "Packaging", "packaging|pack");
            dv.AddCommonField("alternatepart", "Alternate Part #", "alternate|internal");
            dv.AddCommonField("internalcomment", "Quick Note", "note|notes|quick note");
            dv.AddCommonField("delivery", "Delivery", "delivery|need by|delivery date|dock date");
            dv.AddCommonField("description", "Description", "descr|description|descr.");
            dv.AddCommonField("leadtime", "Lead Time", "lead|leadtime");
            dv.SetClass("orddet_rfq");
            dv.Clear();
            DoResize();
        }
        public void DoResize()
        {
            try
            {
                SetBorder();
                dv.Top = pbTop.Bottom + 5;
                dv.Left = pbLeft.Right + 5;
                dv.Width = pbRight.Left - dv.Left - 5;
                dv.Height = pbBottom.Top - dv.Top - 5;
            }
            catch { }
        }
        //Private Functions
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();

            }
            catch (Exception)
            { }
        }
        private void StartImport()
        {
            ArrayList a = dv.GetObjects();
            foreach (nObjectHolder h in a)
            {
                orddet_rfq q = (orddet_rfq)h.xObject;
                if (Tools.Strings.StrExt(q.fullpartnumber))
                {
                    q.orderdate = DateTime.Now;
                    company vendor = company.GetByDistilledName(TheContext, company.DistillCompanyName(q.companyname));
                    if (vendor != null)
                    {
                        q.CompanyObjectSet(vendor);
                        companycontact contact = companycontact.GetByDistilledName(TheContext, companycontact.DistillContactName(q.contactname), vendor.unique_id);
                        if (contact != null)
                            q.ContactObjectSet(contact);
                    }
                    if (!Tools.Strings.StrExt(q.unique_id))
                        q.Insert(TheContext);
                    else
                        q.Update(TheContext);
                }
            }
            dv.NotifyFinished();
        }
        //Control Events
        private void ImportBids_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void dv_Accept()
        {
            Count = dv.Count;
            if (Count <= 0)
                return;
            if (!RzWin.Context.TheLeader.AskYesNo("Are you sure you want to import " + Tools.Number.LongFormat(Count) + " bids"))
                return;
            StartImport();
        }
        private void dv_AfterImport()
        {
            TheContext.TheLeader.Tell("Finished Importing " + Count.ToString() + " Bids.");
        }
    }
}
