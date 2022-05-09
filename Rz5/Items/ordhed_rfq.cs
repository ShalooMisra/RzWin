using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class ordhed_rfq : ordhed_rfq_auto
    {
        //Constructor
        public ordhed_rfq()
        {
            OrderType = Enums.OrderType.RFQ;
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                //case "companydetails":
                //    ShowCompanyDetails();
                //    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }
        //public override void ShowCompanyDetails()
        //{
        //    try
        //    {
        //        String showtext = "";
        //        if (!Tools.Strings.StrExt(base_company_uid))
        //            showtext = "There is no linked company.";
        //        else
        //        {
        //            company c = company.GetByID(xSys, base_company_uid);
        //            if (c == null)
        //                showtext = "This company was not found in the system.";
        //            else
        //            {
        //                showtext = c.companyname + "\r\n";
        //                companyaddress ca = companyaddress.GetByDescription(xSys, c.unique_id, "Billing");
        //                if (ca != null)
        //                {
        //                    if (Tools.Strings.StrExt(ca.line1) && !Tools.Strings.StrCmp(c.companyname, ca.line1))
        //                        showtext += ca.line1 + "\r\n";
        //                    if (Tools.Strings.StrExt(ca.line2) && !Tools.Strings.StrCmp(c.companyname, ca.line2))
        //                        showtext += ca.line2 + "\r\n";
        //                    if (Tools.Strings.StrExt(ca.line3) && !Tools.Strings.StrCmp(c.companyname, ca.line3))
        //                        showtext += ca.line3 + "\r\n";
        //                    String csz = "";
        //                    if (Tools.Strings.StrExt(ca.adrcity))
        //                        csz += ca.adrcity;
        //                    if (Tools.Strings.StrExt(ca.adrstate))
        //                    {
        //                        if (Tools.Strings.StrExt(csz))
        //                            csz += ", " + ca.adrstate;
        //                        else
        //                            csz += ca.adrstate;
        //                    }
        //                    if (Tools.Strings.StrExt(ca.adrzip))
        //                    {
        //                        if (Tools.Strings.StrExt(csz))
        //                            csz += " " + ca.adrzip;
        //                        else
        //                            csz += ca.adrzip;
        //                    }
        //                    if (Tools.Strings.StrExt(csz))
        //                        showtext += csz + "\r\n";
        //                }
        //                if (Tools.Strings.StrExt(c.primaryphone))
        //                    showtext += "Phone: " + c.primaryphone + "\r\n";
        //                if (Tools.Strings.StrExt(c.primaryfax))
        //                    showtext += "Fax: " + c.primaryfax + "\r\n";
        //                if (Tools.Strings.StrExt(c.primaryemailaddress))
        //                    showtext += "Email: " + c.primaryemailaddress + "\r\n";
        //            }
        //        }
        //        nStatus.InputMessageBoxMultiLine("", showtext, "Company Summary", RzApp.xMainForm);
        //    }
        //    catch (Exception)
        //    { }
        //}
        public override Enums.OrderType OrderType
        {
            get
            {
                return Enums.OrderType.RFQ;
            }
            set
            {
                if (value != Enums.OrderType.RFQ)
                    throw new Exception("Order Type Error");
            }
        }

        public override void Inserting(Context x)
        {
            base.Inserting(x);
            ordertype = "RFQ";
        }
        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeViewedByRFQ((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeEditedByRFQ((ContextRz)context, this, context.xUser);
        }
    }
}
