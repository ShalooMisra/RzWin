using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Core;
using NewMethod;
using Tools.Database;
using System.Windows.Forms;
using GoogleApis;
using System.Linq;
using OutlookApp = Outlook.Application;
using Outlook;
using Rz5.Enums;


namespace Rz5
{
    public partial class emailtemplate : emailtemplate_auto
    {
        public ArrayList aAttachments;
        public String AttachmentFileString
        {
            get
            {
                String s = "";
                if (aAttachments == null)
                    return s;
                if (aAttachments.Count <= 0)
                    return s;
                foreach (filelink f in aAttachments)
                {
                    String filename = f.SaveDataAsFile(f.linkname, true);
                    if (Tools.Strings.StrExt(filename))
                        s += filename + "|";

                }
                return s;
            }
        }

        public static emailtemplate GetByName(ContextRz x, String strName)
        {
            return (emailtemplate)x.QtO("emailtemplate", "select * from emailtemplate where templatename = '" + x.TheData.Filter(strName) + "'");
        }
        public static String GetLikelyAddress(nObject xObject)
        {
            switch (nTools.Trim(xObject.ClassId).ToLower())
            {
                case "ordhed":
                    return (String)xObject.IGet("primaryemailaddress");
                case "company":
                    return (String)xObject.IGet("primaryemailaddress");
                case "companycontact":
                    return (String)xObject.IGet("primaryemailaddress");
            }

            return "";
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;
            switch (args.ActionName.ToLower())
            {
                case "duplicate":
                    Duplicate(xrz);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }
        public override string ToString()
        {
            return "Email Template " + templatename;
        }
        //Public Functions
        public bool IsOrder
        {
            get
            {
                return (Tools.Strings.StrCmp(class_name, "ordhed") || Tools.Strings.StrCmp(class_name, "order"));
            }
        }
        public void Duplicate(ContextRz context)
        {
            String s = context.TheLeader.AskForString("New Name?", templatename, "New Name");
            if (!Tools.Strings.StrExt(s))
                return;

            emailtemplate t = (emailtemplate)this.CloneValues(context);
            t.unique_id = "";
            t.templatename = s;
            context.Insert(t);

            //detail layout
            n_template tem = n_template.GetByName(context, this.GetTemplateID());
            if (tem != null)
            {
                tem.Duplicate(context, t.GetTemplateID());
            }
        }
        public bool SendGeneralEmail(ContextRz context, nObject xObject, String strAddress)
        {
            return SendGeneralEmail(context, xObject, strAddress, "", "", null, "");
        }
        public bool SendGeneralEmail(ContextRz context, Object xObject, String strAddress, String strBCC, String strFromAddress, ArrayList colPayload, String strPay)
        {

            String strHeader = "";
            String strFooter = "";
            String strSubject = "";

            GetGeneralEmailData(context, ref strSubject, ref strHeader, ref strFooter, xObject, colPayload, strPay);
            String err = "";
            //return ToolsOffice.OutlookOffice.SendOutlookMessage(strAddress, strHeader + strFooter, strSubject, false, true, "", AttachmentFileString, false, null, strBCC, strFromAddress, "", context.xUser.email_signature, ref err);
            //return context.TheSysRz.TheEmailLogic.SendOutlookEmail(strAddress, strHeader + strFooter, strSubject, false, true, "", AttachmentFileString, false, null, strBCC, strFromAddress, "", context.xUser.email_signature, true, ref err);
            return false;
        }
        public String GetGeneralEmailData(ContextRz context, Object xObject, ref String strSubject)
        {
            String strHeader = "";
            String strFooter = "";
            //String strSubject = "";

            GetGeneralEmailData(context, ref strSubject, ref strHeader, ref strFooter, xObject, null, "");
            return strHeader + strFooter;
        }
        public String GetGeneralEmailData(ContextRz context, ref String Subject, ref String Header, ref String Footer, Object xObject, ArrayList colPayload, String strPay)
        {
            String strHeader = "";
            String strFooter = "";
            String strSubject = "";

            company xCompany = null;
            companycontact xContact = null;
            ordhed xOrder = null;
            company xVendor = null;

            ArrayList col;

            if (xObject.GetType() == System.Type.GetType("ArrayList"))
            {
                col = (ArrayList)xObject;
            }
            else
            {
                col = new ArrayList();
                col.Add(xObject);

                nObject n = (nObject)xObject;

                switch (n.ClassId.ToLower().Trim())
                {
                    case "companycontact":
                        xCompany = (company)context.GetById("company", (String)n.IGet("base_company_uid"));
                        break;
                    case "ordhed":
                        xCompany = (company)context.GetById("company", (String)n.IGet("base_company_uid"));
                        break;
                    case "orddet":
                        xOrder = (ordhed)context.GetById("ordhed", (String)n.IGet("base_ordhed_uid"));
                        xVendor = (company)context.GetById("company", (String)n.IGet("vendor_company_uid"));
                        break;
                    case "checkpayment":
                        xCompany = (company)context.GetById("company", (String)n.IGet("base_company_uid"));
                        break;
                }
            }

            col.Add(context.xUser);

            strHeader = emailbody;
            strFooter = emailfooter;
            strSubject = subjectstring;

            if (xCompany != null)
                col.Add(xCompany);

            if (xContact != null)
                col.Add(xContact);

            if (xOrder != null)
                col.Add(xOrder);

            foreach (nObject o in col)
            {
                strHeader = o.AssociateWithHTML(strHeader);
                strFooter = o.AssociateWithHTML(strFooter);
                strSubject = o.AssociateWithHTML(strSubject);
            }

            if (xVendor != null)
            {
                strHeader = xVendor.AssociateWithHTML(strHeader, "VENDOR");
                strFooter = xVendor.AssociateWithHTML(strFooter, "VENDOR");
                strSubject = xVendor.AssociateWithHTML(strSubject, "VENDOR");
            }

            int i = 1;
            if (colPayload != null)
            {
                foreach (nObject p in colPayload)
                {
                    strHeader = p.AssociateWithHTML(strHeader, p.ClassId + "_" + nTools.Trim(i.ToString()));
                    strFooter = p.AssociateWithHTML(strFooter, p.ClassId + "_" + nTools.Trim(i.ToString()));
                    strSubject = p.AssociateWithHTML(strSubject, p.ClassId + "_" + nTools.Trim(i.ToString()));
                    i = i + 1;
                }

                nObject blank = (nObject)context.Item(strPay);
                if (blank != null)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        strHeader = blank.AssociateWithHTML(strHeader, strPay + "_" + nTools.Trim(j.ToString()));
                        strFooter = blank.AssociateWithHTML(strFooter, strPay + "_" + nTools.Trim(j.ToString()));
                        strSubject = blank.AssociateWithHTML(strSubject, strPay + "_" + nTools.Trim(j.ToString()));
                    }
                }
            }

            Header = strHeader;
            Footer = strFooter;
            Subject = strSubject;
            return "";
        }
        public String GetTemplateID()
        {
            return "ORDEREMAIL-" + unique_id;
        }
        public String SendOrderEmail(ContextRz context, ordhed xOrder)
        {
            return SendOrderEmail(context, xOrder, false, "", false, true, false, "", "", "", "", "", true);
        }
        public String SendOrderEmail(ContextRz context, ordhed xOrder, String strAddress)
        {
            return SendOrderEmail(context, xOrder, strAddress, "");
        }
        public String SendOrderEmail(ContextRz context, ordhed xOrder, String strAddress, String strCCLines)
        {
            return SendOrderEmail(context, xOrder, false, strAddress, false, true, false, "", "", "", "", strCCLines, true);
        }
        public String SendOrderEmail(ContextRz context, ordhed xOrder, String strAddress, ArrayList supplied_details)
        {
            return SendOrderEmail(context, xOrder, false, strAddress, false, true, false, "", "", "", "", "", true, supplied_details, true);
        }
        public String SendOrderEmail(ContextRz context, ordhed xOrder, bool boolReturnOnly, String strOverrideAddress, bool boolPrintOnly, bool boolPreview, bool boolSkipOutlook, String FromAddress, String FromName, String strAttachFile, String strExtraSubject, String strCCLines, bool consolidate_lines)
        {
            return SendOrderEmail(context, xOrder, boolReturnOnly, strOverrideAddress, boolPrintOnly, boolPreview, boolSkipOutlook, FromAddress, FromName, strAttachFile, strExtraSubject, strCCLines, consolidate_lines, null, true);
        }
        public String SendOrderEmail(ContextRz context, ordhed xOrder, bool boolReturnOnly, String strOverrideAddress, bool boolPrintOnly, bool boolPreview, bool boolSkipOutlook, String FromAddress, String FromName, String strAttachFile, String strExtraSubject, String strCCLines, bool consolidate_lines, ArrayList SuppliedDetails, bool IncludePDF)
        {
            try
            {
                String toAddress = "";
                String strHeader;
                String strFooter;
                String strDetails = "";
                ArrayList colDetails;
                company xCompany;
                companycontact xContact;
                String strSubject;
                string replyTo = "noreply@sensiblemicro.com";
                string strSignature = "";
                //List<string> bccList = new List<string>();

                xCompany = xOrder.CompanyVar.RefGet(context);
                xContact = xOrder.ContactVar.RefGet(context);

                if (xCompany == null)
                {
                    xCompany = company.GetById(context, xOrder.base_company_uid);
                    if (xCompany == null)
                    {
                        if ((!boolReturnOnly) && !Tools.Strings.StrExt(strOverrideAddress))
                        {
                            context.TheLeader.Error("This order's company could not be located.");
                            return "";
                        }
                    }
                }


                //Line Item Details
                if (!exclude_details)
                {
                    if (SuppliedDetails != null)
                        colDetails = SuppliedDetails;
                    else
                    {
                        colDetails = new ArrayList();
                        List<orddet> details = xOrder.DetailsListForPrint(context, consolidate_lines, templatename);
                        foreach (orddet dx in details)
                        {
                            colDetails.Add(dx);
                        }
                    }

                    n_template yTemplate;
                    yTemplate = n_template.GetByName(context, GetTemplateID());
                    if (yTemplate != null)
                    {
                        yTemplate.GatherColumns(context);
                        context.TheSysRz.TheOrderLogic.ColumnsAdjustForEmail(context, yTemplate, colDetails);
                        strDetails = context.TheSysRz.ThePrintLogic.EmailOrderTableRender((ContextRz)context, xOrder.OrderType, this, yTemplate, colDetails);
                    }
                }


                ////Rz User for To Address
                //NewMethod.n_user yUser;
                //yUser = xOrder.AgentVar.RefGet(context);
                //if (yUser == null)
                //    yUser = context.xUser;
                //Ensure for this part we have the agent and not the current user from before
                //Rz User for To Address
                NewMethod.n_user yUser = xOrder.AgentVar.RefGet(context);
                if (yUser == null)
                    yUser = n_user.GetById(context, xOrder.base_mc_user_uid);  //this is getting here without the agent var officially set sometimes and i don't think i can take another salesperson complaint

                if (!Tools.Email.IsEmailAddress(yUser.email_address))
                {
                    context.Leader.Error(yUser.Name + " does not appear to have a valied email address configured in Rz.");
                    return "";
                }



                //Header - Associate with HTML
                strHeader = xOrder.AssociateWithHTML(emailbody, "ordhed");
                strHeader = xOrder.AssociateWithHTML(strHeader, "ordhed_" + xOrder.ordertype.ToLower());
                strHeader = context.xUser.AssociateWithHTML(strHeader);
                strHeader = yUser.AssociateWithHTML(strHeader, "agent");
                strHeader = yUser.AssociateWithHTML(strHeader, "mc_user");
                strHeader = OwnerSettings.AssociateWithHTML(context, strHeader);
                string trackingLink = GetTrackingLink(xOrder.DetailsList(context), xOrder.OrderType);
                //strHeader = strHeader.Replace("<TrackingLink>", GetTrackingLink(xOrder.trackingnumber, xOrder.shipvia));
                strHeader = strHeader.Replace("<TrackingLink>", trackingLink);
                //strHeader = strHeader.Replace("&lt;TrackingLink&gt;", GetTrackingLink(xOrder.trackingnumber, xOrder.shipvia));
                strHeader = strHeader.Replace("&lt;TrackingLink&gt;", GetTrackingLink(xOrder.DetailsList(context), xOrder.OrderType));

                //Subject - Associate with HTML
                strSubject = xOrder.AssociateWithHTML(subjectstring, "ordhed") + "  " + strExtraSubject;
                strSubject = xOrder.AssociateWithHTML(strSubject, "ordhed_" + xOrder.ordertype.ToLower());
                strSubject = context.xUser.AssociateWithHTML(strSubject);
                strSubject = yUser.AssociateWithHTML(strSubject, "agent");
                strSubject = yUser.AssociateWithHTML(strSubject, "mc_user");
                strSubject = OwnerSettings.AssociateWithHTML(context, strSubject);
                strFooter = xOrder.AssociateWithHTML(emailfooter, "ordhed");
                strFooter = xOrder.AssociateWithHTML(strFooter, "ordhed_" + xOrder.ordertype.ToLower());
                strFooter = context.xUser.AssociateWithHTML(strFooter);
                strFooter = yUser.AssociateWithHTML(strFooter, "agent");
                strFooter = yUser.AssociateWithHTML(strFooter, "mc_user");
                strFooter = OwnerSettings.AssociateWithHTML(context, strFooter);

                //Font
                String strFont;
                strFont = yUser.GetSetting(context, "font");
                if (!Tools.Strings.StrExt(strFont))
                    strFont = "Times New Roman";
                strHeader = nTools.StrReplace(strHeader, "<agent.font>", strFont);
                strFooter = nTools.StrReplace(strFooter, "<agent.font>", strFont);

                strHeader = nTools.StrReplace(strHeader, "<datetime.now>", DateTime.Now.ToShortDateString());
                strFooter = nTools.StrReplace(strFooter, "<datetime.now>", DateTime.Now.ToShortDateString());
                strHeader = nTools.StrReplace(strHeader, "&lt;datetime.now&gt;", DateTime.Now.ToShortDateString());
                strFooter = nTools.StrReplace(strFooter, "&lt;datetime.now&gt;", DateTime.Now.ToShortDateString());

                //Company - Associate with HTML
                if (xCompany != null)
                {
                    strHeader = xCompany.AssociateWithHTML(strHeader);
                    strSubject = xCompany.AssociateWithHTML(strSubject);
                    strFooter = xCompany.AssociateWithHTML(strFooter);
                }
                //Contact - Associate with HTML
                if (xContact != null)
                {
                    strHeader = xContact.AssociateWithHTML(strHeader);
                    strSubject = xContact.AssociateWithHTML(strSubject);
                    strFooter = xContact.AssociateWithHTML(strFooter);
                }

                String strAll;
                ArrayList colAddresses;
                String strCC;



                //if (yUser != null)
                //    colAddresses = context.TheSysRz.TheEmailLogic.GetNotifyEmailList(context, yUser);  //old way
                //else
                //    colAddresses = new ArrayList();


                //BCC               
                List<string> bccList = context.TheSysRz.TheEmailLogic.GetOrderEmailBccList(context, xOrder, templatename);
                //On Customer ORder Shipped, check to include any companycontacts that are set to "send_company_shipping_email_alert" = true
                //List<string> bccList = GetBccListForOrder(context, pars);
                //Cc List

                List<string> ccList = new List<string>();
                try
                {
                    String[] ccs = Tools.Strings.SplitLines(strCCLines);
                    foreach (String cs in ccs)
                    {
                        if (nTools.IsEmailAddress(cs))
                            if (!ccList.Contains(cs))
                                ccList.Add(cs);
                    }
                }
                catch
                {

                }

                //New Line for Text-only?
                if (this.is_text)
                    strHeader += "\r\n";




                //Add RM's (if any) to the CC
                if (yUser.IsAssistantLeader(context))
                {
                    ArrayList rmList = yUser.GetAssistantsForLeader(context, yUser.unique_id);
                    foreach (n_user u in rmList)
                    {
                        if (!string.IsNullOrEmpty(u.email_address))
                            ccList.Add(u.email_address);
                    }
                }

                //ReturnOnly / PrintOnlyt = non-email functions?
                if (boolReturnOnly || boolPrintOnly)
                {
                    if (this.is_text)
                        strAll = strHeader + "\r\n\r\n" + strDetails + strFooter;
                    else if (Tools.Strings.HasString(strHeader, "<head>"))
                        strAll = strHeader + strDetails + strFooter;
                    else
                        strAll = "<html><head></head><body>" + strHeader + strDetails + strFooter + "</body></html>";
                    if (boolPrintOnly)
                    {
                        //PrintHTMLString(strAll);
                        throw new NotImplementedException("emailtemplate.SendOrderEmail.boolPrintOnly");
                    }
                    return strAll;
                }
                else
                {

                    //Convert the CCList to comma separated string
                    string ccString = "";
                    foreach (string s in ccList)
                    {
                        if (s != ccList.Last())
                            ccString += s + ",";
                        else
                            ccString += s;
                    }

                    //Body
                    string bdy = "";

                    //Text Only?
                    bool textOnly = false;
                    if (is_text)
                    {
                        textOnly = true;
                        bdy = strHeader + "\r\n\r\n" + strDetails + strFooter;
                    }
                    else if (Tools.Strings.HasString(strHeader, "<head>"))
                        bdy = strHeader + strDetails + strFooter;
                    else
                        bdy = "<html><head></head><body>" + strHeader + strDetails + strFooter + "</body></html>";
                    string file_name = "";


                    //To Address
                    toAddress = "";
                    if (!string.IsNullOrEmpty(strOverrideAddress))
                        toAddress = strOverrideAddress;
                    else
                        toAddress = GetToAddress(context, (n_user)yUser, xOrder, xContact);



                    //From Address
                    string fromAddress = GetFromAddress(context, xOrder);


                    //Create Lists from strings
                    List<string> toList = new List<string>() { toAddress };
                    List<string> attachList = new List<string>() { strAttachFile };
                    string error = "";
                    bool isDraft = true;
                    bool boolUserEdit = true;

                    context.TheSysRz.TheEmailLogic.SendEmail(context, toList, bdy, strSubject, textOnly, boolUserEdit, ccList, bccList, attachList, isDraft, strSignature, fromAddress, boolPreview, ref error);



                }

                return "";
            }
            catch (System.Exception ex)
            {
                context.TheLeader.Tell("Email Send Error: " + ex.Message + "/r/n" + ex.InnerException);
                return "";
            }
        }



        private string GetToAddress(ContextRz context, n_user u, ordhed xOrder, companycontact xContact)
        {
            string ret = null;

            switch (xOrder.OrderType)
            {
                case OrderType.Invoice:
                    ret = u.email_address;
                    break;
                case OrderType.Quote:
                    ret = xContact.primaryemailaddress;
                    break;
                default:
                    ret = "ktill@sensiblemicro.com";
                    break;
            }

            if (context.xUser.IsDeveloper() || context.xUser.Name == "Kevin Till")
                ret = "ktill@sensiblemicro.com";

            if (!Tools.Email.IsEmailAddress(ret))
                ret = null;
            return ret;


        }

        private string GetFromAddress(ContextRz context, ordhed xOrder)
        {
            switch (xOrder.OrderType)
            {
                case OrderType.Invoice:
                    return "shipping@sensiblemicro.com";
                case OrderType.Quote:
                    return "quotes@sensiblemicro.com";
                default:
                    return "noreply@sensiblemicro.com";
            }


        }




        public String GetSubjectHtml(nObject x)
        {
            return x.AssociateWithHTML(subjectstring, x.ClassId);
        }

        public String GetBodyHtml(nObject x)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(x.AssociateWithHTML(emailbody, x.ClassId));
            sb.Append(x.AssociateWithHTML(emailfooter, x.ClassId));
            return sb.ToString();
        }

        public String GetTrackingLink(String strTrackingNumber, String strShipVia)
        {
            if (!Tools.Strings.StrExt(strTrackingNumber))
                return "";

            String strRef = "";

            if (Tools.Strings.HasString(strShipVia, "UPS"))
                strRef = "http://wwwapps.ups.com/WebTracking/track?HTMLVersion=5.0&loc=en_US&Requester=UPSHome&trackNums=" + strTrackingNumber + "&track.x=Track";
            else if (Tools.Strings.HasString(strShipVia, "FEDEX"))
                strRef = "http://www.fedex.com/Tracking?ascend_header=1&clienttype=dotcom&cntry_code=us&language=english&tracknumbers=" + strTrackingNumber;
            else if (Tools.Strings.HasString(strShipVia, "DHL"))
                strRef = "http://track.dhl-usa.com/atrknav.asp?ShipmentNumber=" + strTrackingNumber;

            if (!Tools.Strings.StrExt(strRef))
                return "";

            return "&nbsp;&nbsp;<a target=\"_new\" title=\"Track\" href=\"" + strRef + "\">Track This Shipment</a>";
        }
        public String GetTrackingLink(List<orddet> lines, Rz5.Enums.OrderType t)
        {
            if (lines == null)
                return "";
            if (lines.Count == 0)
                return "";

            if (!(lines[0] is orddet_line))
                return "";


            //Get Distinct Tracking numbers:       
            //A Little Odd, but since there's some swithc logic going odd, and I need to eliminate duplicate Tracking Numbers
            //Then for now, let's maintain a list of orddet lines, and check that    
            List<string> usedTrackingNumbers = new List<string>();


            String strBuild = "";
            foreach (orddet_line l in lines)
            {

                string shipvia = "";
                string tracking = "";
                switch (t)
                {
                    case Rz5.Enums.OrderType.Invoice:
                        shipvia = l.shipvia_invoice;
                        tracking = l.tracking_invoice.Trim().ToUpper();
                        break;
                    case Rz5.Enums.OrderType.Purchase:
                        shipvia = l.shipvia_purchase;
                        tracking = l.tracking_purchase.Trim().ToUpper();
                        break;
                    case Rz5.Enums.OrderType.RMA:
                        shipvia = l.shipvia_rma;
                        tracking = l.tracking_rma.Trim().ToUpper();
                        break;
                    case Rz5.Enums.OrderType.VendRMA:
                        shipvia = l.shipvia_vendrma;
                        tracking = l.tracking_vendrma.Trim().ToUpper();
                        break;
                }

                if (!Tools.Strings.StrExt(shipvia))
                    continue;
                if (!Tools.Strings.StrExt(tracking))
                    continue;
                if (!usedTrackingNumbers.Contains(tracking.Trim().ToUpper()))//Not Already used
                {
                    if (Tools.Strings.StrExt(strBuild))
                        strBuild += ",";
                    if (Tools.Strings.HasString(shipvia, "UPS"))
                        strBuild += "<a target=\"_new\" title=\"Track\" href=\"http://wwwapps.ups.com/WebTracking/track?HTMLVersion=5.0&loc=en_US&Requester=UPSHome&trackNums=" + tracking + "&track.x=Track\">" + tracking + "</a>";
                    else if (Tools.Strings.HasString(shipvia, "FEDEX"))
                        strBuild += "<a target=\"_new\" title=\"Track\" href=\"http://www.fedex.com/Tracking?ascend_header=1&clienttype=dotcom&cntry_code=us&language=english&tracknumbers=" + tracking + "\">" + tracking + "</a>";
                    else if (Tools.Strings.HasString(shipvia, "DHL"))
                        strBuild += "<a target=\"_new\" title=\"Track\" href=\"http://track.dhl-usa.com/atrknav.asp?ShipmentNumber=" + tracking + "\">" + tracking + "</a>";
                    //Add to distinct list
                    usedTrackingNumbers.Add(tracking.Trim().ToUpper());

                }

            }
            return strBuild;
        }

        public bool Preview(object xObject)
        {
            throw new NotImplementedException("emailtemplate.DoPreview");
            return false;
            //String strPath;
            //String strFile;

            //strFile = GetCompleteHTML(xObject)
            //ThrowGlobalHTMLString(strFile, false, false)
            //return;
        }
        public String GetCompleteHTML(object xObject)
        {
            throw new NotImplementedException("emailtemplate.GetCompleteHTML");
            return "";
            //String strFile;
            //ordhed xOrder;

            //if( xObject = null )
            //{
            //     xOrder= GetDemoOrder()
            //    strFile = SendEmail(xOrder, , true)
            //    else
            //    switch( nTools.Trim(nTools.LCase(xObject.ClassName)) )
            //{
            //        break;
            //case "ordhed":
            //            strFile = SendEmail(xObject, , true)
            //        default:
            //            strFile = FullAssociateWithHTML(xObject, emailbody + emailfooter)
            //    }

            //}

            //GetCompleteHTML = strFile
        }
        public void SendBatch(String strSQL, company xCompany)
        {
            throw new NotImplementedException("emailtemplate.SendBatch");
            //\\On Error GoTo Error_H
            //displaytemplate xTemplate;
            //ArrayList colBatch;
            //bool boolCool;
            //String strResult;
            //String strAddress;

            // xTemplate= xRz2.GetTemplateByName(GetTemplateID())
            // colBatch= xRz2.QTC(strSQL, , , , boolCool)
            //strResult = AssociateObjectWithHTML(xCompany, emailbody)
            //if( xTemplate = null )
            //{
            //    xRz2.MessageBox("The item detail section of this email template has not yet been configured.", vbInformation + vbOKOnly, "Not Configured.")
            //    else
            //    strResult = strResult + xTemplate.GetAsHTMLTable(colBatch, true)
            //}

            //strResult = strResult + AssociateObjectWithHTML(xCompany, emailfooter)
            //strAddress = colBatch(1).legacyvendoremail
            //SendOutlookMessage(strAddress, strResult, subjectstring, false, true)
            //return;
            //Error_H:
        }
        public bool DoAction(ActArgs args)
        {
            switch (args.ActionName.ToLower().Trim())
            {
                case "preview":
                    Preview(null);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
            return false;
        }
        //Private Functions
        public String GetAsHTMLTableWithDescription(ContextRz context, Rz5.Enums.OrderType type, n_template x, ArrayList a, String strBackColor)
        {
            if (a == null)
                return "";
            if (a.Count <= 0)
                return "";
            if (x == null)
                return "";

            SortedList colColumns = x.GetColumns(context);
            StringBuilder strHTML = new StringBuilder();
            strHTML.AppendLine("<table border=\"0\" width=\"100%\">");
            strHTML.AppendLine("<tr>");
            n_column xColumn;
            String strColor = "black";
            foreach (DictionaryEntry d in colColumns)
            {
                xColumn = (n_column)d.Value;
                strHTML.Append("<td bgcolor=\"" + strBackColor + "\"><font color=" + strColor + "><b>" + xColumn.column_caption + "</b></font></td>");
            }
            strHTML.AppendLine("</tr>");
            foreach (orddet xObject in a)
            {
                strHTML.AppendLine("<tr>");
                foreach (DictionaryEntry d in colColumns)
                {
                    xColumn = (n_column)d.Value;
                    String strVal = context.TheSysRz.ThePrintLogic.GetColumnValue(xColumn, new LineHandleObject(context, xObject));

                    //Set the $ sign
                    if (xColumn.column_caption.Contains("Price") || xColumn.column_caption.Contains("Cost") || xColumn.column_caption == "Amount")
                        strVal = "$" + strVal;

                    strHTML.AppendLine("<td><font color=" + strColor + " >" + strVal + "</font></td>");

                    //    if (Tools.Strings.StrExt(xColumn.column_format))
                    //    {
                    //        strHTML.AppendLine("<td><font color=" + strColor + " >" + String.Format(xColumn.column_format, xObject.IGet(xColumn.field_name)) + "</font></td>");
                    //    }
                    //    else
                    //    {


                    //        switch (xColumn.data_type)
                    //        {
                    //            case (Int32)FieldType.Int64:
                    //            case (Int32)FieldType.Int32:
                    //                strHTML.AppendLine("<td><font color=" + strColor + " >" + Tools.Number.LongFormat(Tools.Data.NullFilterIntegerFromIntOrLong(xObject.IGet(xColumn.field_name))) + "</font></td>");
                    //                break;
                    //            case (Int32)FieldType.Boolean:
                    //                strHTML.AppendLine("<td><font color=" + strColor + " >" + nTools.BoolToYN(Tools.Data.NullFilterBool(xObject.IGet(xColumn.field_name))) + "</font></td>");
                    //                break;
                    //            case (Int32)FieldType.Double:
                    //                strHTML.AppendLine("<td><font color=" + strColor + " >" + nTools.MoneyFormat_2_6(Tools.Data.NullFilterDouble(xObject.IGet(xColumn.field_name))) + "</font></td>");
                    //                break;
                    //            case (Int32)FieldType.DateTime:
                    //                strHTML.AppendLine("<td><font color=" + strColor + " >" + nTools.DateFormat(Tools.Data.NullFilterDate(xObject.IGet(xColumn.field_name))) + "</font></td>");
                    //                break;
                    //            default:
                    //                strHTML.AppendLine("<td><font color=" + strColor + " >" + Tools.Data.NullFilterString(xObject.IGet(xColumn.field_name).ToString()) + "</font></td>");
                    //                break;
                    //        }
                    //    }
                }
                strHTML.AppendLine("</tr>");

                String strDesc = "";

                //2011_06_30 not valid anymore
                //if (type == Enums.OrderType.Service && xObject is orddet_line)
                //    strVal = Tools.Html.ConvertTextToHTML(((orddet_line)xObject).ServiceDescriptionsList(context));
                //else 

                if (xObject is orddet_line)
                    strDesc = ((orddet_line)xObject).DescriptionForPrint(context, type, this.templatename);
                else if (xObject is orddet_old)
                    strDesc = ((orddet_old)xObject).description;

                if (!Tools.Strings.StrExt(strDesc) && Tools.Strings.StrExt(xObject.description))
                    strDesc = "Description: " + xObject.description;

                if (Tools.Strings.StrExt(strDesc) && !strDesc.StartsWith("Description"))
                    strDesc = "Description: " + strDesc;

                if (Tools.Strings.StrExt(strDesc))
                {
                    strHTML.AppendLine("<tr>");
                    strHTML.AppendLine("<td colspan=\"" + colColumns.Count + "\" bgcolor=\"" + strBackColor + "\"><font color=" + strColor + " >" + Tools.Html.ConvertTextToHTML(strDesc) + "</font></td>");
                    strHTML.AppendLine("</tr>");
                }
            }
            strHTML.AppendLine("</table>");
            return strHTML.ToString();
        }
        public String GetAsTextWithDescription(ContextRz context, n_template x, ArrayList a)
        {
            try
            {
                if (a == null)
                    return "";
                if (a.Count <= 0)
                    return "";
                if (x == null)
                    return "";
                n_column xColumn;
                SortedList colColumns = x.GetColumns(context);
                StringBuilder strText = new StringBuilder();
                foreach (DictionaryEntry d in colColumns)
                {
                    xColumn = (n_column)d.Value;
                    if (!Tools.Strings.StrExt(strText.ToString()))
                        strText.Append(xColumn.column_caption);
                    else
                        strText.Append("\t\t" + xColumn.column_caption);
                }
                strText.Append("\r\n\r\n");
                string line = "";
                foreach (orddet xObject in a)
                {
                    foreach (DictionaryEntry d in colColumns)
                    {
                        xColumn = (n_column)d.Value;
                        if (Tools.Strings.StrExt(xColumn.column_format))
                        {
                            if (Tools.Strings.StrExt(line))
                                line += "\t\t" + String.Format(xColumn.column_format, xObject.IGet(xColumn.field_name));
                            else
                                line += String.Format(xColumn.column_format, xObject.IGet(xColumn.field_name));
                        }
                        else
                        {
                            switch (xColumn.data_type)
                            {
                                case (Int32)FieldType.Text:
                                    if (Tools.Strings.StrExt(line))
                                        line += "\t\t" + (String)xObject.IGet(xColumn.field_name);
                                    else
                                        line += (String)xObject.IGet(xColumn.field_name);
                                    break;
                                case (Int32)FieldType.Int64:
                                    if (Tools.Strings.StrExt(line))
                                        line += "\t\t" + Tools.Number.LongFormat((long)xObject.IGet(xColumn.field_name));
                                    else
                                        line += Tools.Number.LongFormat((long)xObject.IGet(xColumn.field_name));
                                    break;
                                case (Int32)FieldType.Int32:
                                    if (Tools.Strings.StrExt(line))
                                        line += "\t\t" + Tools.Number.LongFormat((int)xObject.IGet(xColumn.field_name));
                                    else
                                        line += Tools.Number.LongFormat((int)xObject.IGet(xColumn.field_name));
                                    break;
                                case (Int32)FieldType.Boolean:
                                    if (Tools.Strings.StrExt(line))
                                        line += "\t\t" + nTools.BoolToYN((bool)xObject.IGet(xColumn.field_name));
                                    else
                                        line += nTools.BoolToYN((bool)xObject.IGet(xColumn.field_name));
                                    break;
                                case (Int32)FieldType.Double:
                                    if (Tools.Strings.StrExt(line))
                                        line += "\t\t" + nTools.MoneyFormat_2_6((Double)xObject.IGet(xColumn.field_name));
                                    else
                                        line += nTools.MoneyFormat_2_6((Double)xObject.IGet(xColumn.field_name));
                                    break;
                                case (Int32)FieldType.DateTime:
                                    if (Tools.Strings.StrExt(line))
                                        line += "\t\t" + nTools.DateFormat((DateTime)xObject.IGet(xColumn.field_name));
                                    else
                                        line += nTools.DateFormat((DateTime)xObject.IGet(xColumn.field_name));
                                    break;
                                default:
                                    if (Tools.Strings.StrExt(line))
                                        line += "\t\t" + xObject.IGet(xColumn.field_name).ToString();
                                    else
                                        line += xObject.IGet(xColumn.field_name).ToString();
                                    break;
                            }
                        }
                    }
                    if (Tools.Strings.StrExt(xObject.description))
                        line += "  Description: " + xObject.description + "\r\n\r\n";
                    strText.AppendLine(line);
                    line = "";
                }
                strText.AppendLine();
                strText.AppendLine();
                return strText.ToString();
            }
            catch { }
            return "";
        }
        public String GetHtml(ContextRz context, nObject xObject, ref String subject)
        {
            if (xObject.ClassId.ToLower().StartsWith("ordhed"))
                return SendOrderEmail(context, (ordhed)xObject, true, "", false, false, false, "", "", "", "", "", true);
            else
                return GetGeneralEmailData(context, xObject, ref subject);
        }
    }
}
