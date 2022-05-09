using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using NewMethod;
using Core;

namespace Rz5
{
    public partial class companyaddress : companyaddress_auto
    {
        public static String FilterAddressTrash(String strIn)
        {
            strIn = strIn.Replace("street", "");
            strIn = strIn.Replace("st.", "");
            strIn = strIn.Replace("st", "");
            return strIn;
        }
        public static companyaddress GetByDescription(ContextRz context, String strCompanyID, String strDescription)
        {
            return (companyaddress)context.QtO("companyaddress", "select * from companyaddress where base_company_uid = '" + strCompanyID + "' and description = '" + context.Filter(strDescription) + "'");
        }
        public static void PrintLabel(ContextRz context, companyaddress a, String strLabel)
        {
            Tools.Dymo.PrintAddressLabel(context, a.GetAddressString(context, true), strLabel);
        }
        public static void PrintLabelsFromStringArray(ContextRz context, ArrayList a)
        {
            String strLabel = companyaddress.GetAddressLabelFile(context);
            if (!Tools.Strings.StrExt(strLabel))
                return;

            Tools.Dymo.PrintAddressLabel(context, a, strLabel);
        }
        public static String GetAddressLabelFile(ContextRz context)
        {
            context.Reorg();
            return "";
            //String strLabel = Tools.FileSystem.GetAppPath() + "Labels\\Address.lwl";
            //if (!System.IO.File.Exists(strLabel))
            //{
            //    strLabel = nTools.ChooseAFile(owner);
            //    if (!System.IO.File.Exists(strLabel))
            //        return "";
            //}
            //return strLabel;
        }
        //Public Override Functions

        public override void Updating(Context x)
        {
            base.Updating(x);
            company c = company.GetById(x, base_company_uid);
            if (c != null)
            {
                bool up = false;
                if (!Tools.Strings.StrExt(c.city))
                {
                    c.city = this.adrcity;
                    up = true;
                }

                if (!Tools.Strings.StrExt(c.statename))
                {
                    c.statename = this.adrstate;
                    up = true;
                }

                if (!Tools.Strings.StrExt(c.country))
                {
                    c.country = this.adrcountry;
                    up = true;
                }

                if (up)
                    x.Update(c);
            }
        }
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;

            switch (args.ActionName.ToLower().Trim())
            {
                case "printlabel":
                case "print label":
                    PrintLabel(null);
                    break;
                case "copyaddress":
                    CopyAddress(xrz);
                    break;
                case "pasteaddress":
                    PasteAddress(xrz);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override void Inserting(Context x)
        {
            if( !Tools.Strings.StrExt(description) )
                description = "Shipping/Billing";

            base.Inserting(x);
        }

        public override String ToString()
        {
            String s = "Address";

            if (Tools.Strings.StrExt(description))
                s += " [" + description + "]";

            return s;
        }

        //public override string ToString()
        //{
        //    String s = "";

        //    if (Tools.Strings.StrExt(s))
        //        s += "  ";

        //    if (Tools.Strings.StrExt(line1))
        //        s += line1;

        //    if (Tools.Strings.StrExt(s))
        //        s += "  ";

        //    if (Tools.Strings.StrExt(line2))
        //        s += line2;

        //    if (Tools.Strings.StrExt(s))
        //        s += "  ";

        //    if (Tools.Strings.StrExt(adrcity))
        //        s += adrcity;

        //    if (Tools.Strings.StrExt(s))
        //        s += "  ";

        //    if (Tools.Strings.StrExt(adrstate))
        //        s += adrstate;

        //    if (Tools.Strings.StrExt(s))
        //        s += "  ";

        //    if (Tools.Strings.StrExt(adrzip))
        //        s += adrzip;

        //    if (Tools.Strings.StrExt(s))
        //        s += "  ";

        //    if (Tools.Strings.StrExt(adrcountry))
        //        s += adrcountry;

        //    return s;
        //}

        public override String GetClipHTML(ContextNM context)
        {
            String s = GetClipHeader(context);

            s += GetClipLine_Big(context, "description");
            s += nTools.ConvertTextToHTML(GetAddressString((ContextRz)context));

            return s;
        }
       //Public Functions
        public String GetAddressString(ContextRz context)
        {
            return GetAddressString(context, false);
        }
        public String GetAddressString(ContextRz context, bool ask_company_contact)
        {
            StringBuilder sb = new StringBuilder();
            if (ask_company_contact)
            {
                String cc = nTools.Replace(context.SelectScalarString("select isnull(companyname, '') + '<br>' + isnull(primarycontact, '') from company where unique_id = '" + base_company_uid + "'"), "<br>", "\r\n");
                cc = context.TheLeader.AskForString("Company / Contact", cc, true, "Company / Contact");
                if (Tools.Strings.StrExt(cc))
                    sb.AppendLine(cc);
            }
            if (Tools.Strings.StrExt(line1))
                sb.AppendLine(line1.Trim());
            if (Tools.Strings.StrExt(line2))
                sb.AppendLine(line2.Trim());
            if (Tools.Strings.StrExt(line3))
                sb.AppendLine(line3.Trim());
            sb.AppendLine(adrcity.Trim() + ", " + adrstate.Trim() + "  " + adrzip.Trim());
            if (Tools.Strings.StrExt(adrcountry))
                sb.AppendLine(adrcountry.Trim());
            return Tools.Strings.KillBlankLines(sb.ToString());
        }
        public void PrintLabel(ContextRz context)
        {
            String strLabel = companyaddress.GetAddressLabelFile(context);
            if (!Tools.Strings.StrExt(strLabel))
                return;

            companyaddress.PrintLabel(context, this, strLabel);
        }

        public void PasteAddress(ContextRz context)
        {
            PasteAddress(context.Leader.GetClipboardText());
        }

        public void PasteAddress(String data)
        {
            try
            {
                Tools.MailingAddress m = Tools.Industry.ParseAddress(data);
                if (m == null)
                    return;
                line1 = m.Line1;
                line2 = m.Line2;
                line3 = m.Line3;
                adrcity = m.City;
                adrstate = m.State;
                adrzip = m.Zip;
                adrcountry = m.Country;
            }
            catch
            { }
        }
        public void CopyAddress(ContextRz context)
        {
            StringBuilder sb = new StringBuilder();
            if (nTools.StrExt(line1))
                sb.AppendLine(line1);
            if (nTools.StrExt(line2))
                sb.AppendLine(line2);
            if (nTools.StrExt(line3))
                sb.AppendLine(line3);
            sb.AppendLine(adrcity + ", " + adrstate + "  " + adrzip);
            sb.AppendLine(adrcountry);
            context.Leader.SetClipboardText(sb.ToString());
        }
    }
}
