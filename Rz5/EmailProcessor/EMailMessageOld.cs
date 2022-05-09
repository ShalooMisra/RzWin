using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using OfficeInterop;
using NewMethod;

namespace Rz3_Common
{
    public partial class EMailMessageOld : EmailMessage
    {
        n_sys xSys;
        public emailaddress FromAddress;
        public emailaddress ToAddress;
        public Enums.MessageType CONTENTSTYPE = Rz3_Common.Enums.MessageType.Unknown;

        public EMailMessageOld()
        {
            Int64 lne = 1;
            try
            {
                xSys = Rz3App.xSys;
                lne++;
                FromAddress = new emailaddress(xSys);
                lne++;
                ToAddress = new emailaddress(xSys);
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Constructor()", lne, "EMailMessageOld.cs", "Rz3_Common.EMailMessageOld", ee.ToString(), "Rz3_Common.EMailMessageOld.Constructor()"));
            }
        }
        //Public Functions
        public Enums.MessageType CalculateContents()
        {
            try
            {
                String strHold = "";
                String strHold2 = "";
                if (xSys.GetSetting_Boolean("emailonlyreqs"))
                {
                    CONTENTSTYPE = Rz3_Common.Enums.MessageType.Req;
                    return CONTENTSTYPE;
                }
                String[] aryReq = Tools.Strings.Split(xSys.GetSetting("email_req_keywords"), "\n");
                String[] aryOffer = Tools.Strings.Split(xSys.GetSetting("email_offer_keywords"), "\n");
                Boolean boolFound = false;
                Boolean boolFound2 = false;
                String strSubject = SUBJECT.ToUpper();
                switch (strSubject.ToLower().Replace(" ", ""))
                {
                    case "re:newrfqsentthroughthebrokerforum":
                    case "re:newrfqfromthebrokerforum":
                        CONTENTSTYPE = Rz3_Common.Enums.MessageType.Offer;
                        return CONTENTSTYPE;
                    case "req":
                        return Rz3_Common.Enums.MessageType.Req;
                    case "offer":
                        return Rz3_Common.Enums.MessageType.Offer;
                }
                if (aryReq != null)
                {
                    foreach (String s in aryReq)
                    {
                        if (Tools.Strings.StrExt(s))
                        {
                            if (strSubject.ToLower().Contains(s.ToLower()))
                            {
                                CONTENTSTYPE = Rz3_Common.Enums.MessageType.Req;
                                return CONTENTSTYPE;
                            }
                        }
                    }
                }
                if (aryOffer != null)
                {
                    foreach (String s in aryOffer)
                    {
                        if (Tools.Strings.StrExt(s))
                        {
                            if (strSubject.ToLower().Contains(s.ToLower()))
                            {
                                CONTENTSTYPE = Rz3_Common.Enums.MessageType.Offer;
                                strHold2 = s;
                                boolFound2 = true;
                                break;
                            }
                        }
                    }
                }
                if (boolFound && boolFound2)
                    return GetAccurateContentType(strSubject, strHold, strHold2);
                if (boolFound || boolFound2)
                    return CONTENTSTYPE;
                CONTENTSTYPE = Rz3_Common.Enums.MessageType.Unknown;
                return CONTENTSTYPE;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Enums.MessageType CalculateContents()", 0, "EMailMessageOld.cs", "Rz3_Common.EMailMessageOld", ee.ToString(), "Rz3_Common.EMailMessageOld.Enums.MessageType CalculateContents()"));
                return Rz3_Common.Enums.MessageType.Unknown;
            }
        }
        public Enums.MailProcessType ProcessType(ArrayList colSourceRestrictions, ArrayList colDestRestrictions)
        {
            try
            {
                addresshandler xRestriction = GetRestriction(colSourceRestrictions, colDestRestrictions);
                if (xRestriction == null)
                    return Rz3_Common.Enums.MailProcessType.Normal;
                switch (xRestriction.handlertags.Replace(" ", "").ToUpper())
                {
                    case "PREADDRESSED":
                    case "ROLLINGPRE":
                        return Rz3_Common.Enums.MailProcessType.RollingPre;
                    case "POSTADDRESSES":
                    case "ROLLINGPOST":
                        return Rz3_Common.Enums.MailProcessType.RollingPost;
                    case "TAGGED":
                        return Rz3_Common.Enums.MailProcessType.Tagged;
                    case "EXCLUDE":
                        return Rz3_Common.Enums.MailProcessType.DoNot;
                    default:
                        return Rz3_Common.Enums.MailProcessType.Normal;
                }
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Enums.MailProcessType ProcessType(ArrayList colSourceRestrictions, ArrayList colDestRestrictions)", 0, "EMailMessageOld.cs", "Rz3_Common.EMailMessageOld", ee.ToString(), "Rz3_Common.EMailMessageOld.Enums.MailProcessType ProcessType(ArrayList colSourceRestrictions, ArrayList colDestRestrictions)"));
                return Rz3_Common.Enums.MailProcessType.Normal;
            }
        }
        public addresshandler GetRestriction(ArrayList colSourceRestrictions, ArrayList colDestRestrictions)
        {
            try
            {
                addresshandler xHandler = null;
                if (ContainsRestriction(FromAddress.addressstring, colSourceRestrictions, ref xHandler))
                    return xHandler;
                if (ContainsRestriction(ToAddress.addressstring, colDestRestrictions, ref xHandler))
                    return xHandler;
                String strFuzzy = "*@" + FromAddress.basestring;
                if (ContainsRestriction(strFuzzy.ToUpper(), colSourceRestrictions, ref xHandler))
                    return xHandler;
                strFuzzy = "*@" + ToAddress.basestring;
                if (ContainsRestriction(strFuzzy.ToUpper(), colDestRestrictions, ref xHandler))
                    return xHandler;
                return null;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "addresshandler GetRestriction(ArrayList colSourceRestrictions, ArrayList colDestRestrictions)", 0, "EMailMessageOld.cs", "Rz3_Common.EMailMessageOld", ee.ToString(), "Rz3_Common.EMailMessageOld.addresshandler GetRestriction(ArrayList colSourceRestrictions, ArrayList colDestRestrictions)"));
                return null;
            }
        }
        public String GetProcessType(String strAddress)
        {
            try
            {
                Int32 lngMark = strAddress.IndexOf("@", 1);
                if (lngMark <= 0)
                    return "";
                String strHead = strAddress.Substring(1, lngMark - 1).Trim();
                String strDomain = strAddress.Substring(strAddress.Length - lngMark).Trim();
                if (Tools.Strings.StrCmp(strDomain, "*"))
                    return strHead.ToUpper();
                String strSQL = "SELECT * FROM ADDRESSHANDLER WHERE EMAILADDRESS = '" + strAddress + "'";
                DataTable dt = xSys.xData.GetDataTable(strSQL);
                if (dt == null)
                    return GetFuzzyProcessType(strDomain);
                return dt.Rows[0]["handlertags"].ToString().Trim();
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "String GetProcessType(String strAddress)", 0, "EMailMessageOld.cs", "Rz3_Common.EMailMessageOld", ee.ToString(), "Rz3_Common.EMailMessageOld.String GetProcessType(String strAddress)"));
                return "";
            }
        }
        public String GetFuzzyProcessType(String strFuzzy)
        {
            Int64 lne = 1;
            try
            {
                String strSQL = "SELECT * FROM ADDRESSHANDLER WHERE EMAILADDRESS = '*" + strFuzzy + "'";
                lne++;
                DataTable dt = xSys.xData.GetDataTable(strSQL);
                lne++;
                if (dt == null)
                {
                    lne++;
                    return "";
                }
                lne++;
                return dt.Rows[0]["handlertags"].ToString();
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "String GetFuzzyProcessType(String strFuzzy)", lne, "EMailMessageOld.cs", "Rz3_Common.EMailMessageOld", ee.ToString(), "Rz3_Common.EMailMessageOld.String GetFuzzyProcessType(String strFuzzy)"));
                return "";
            }
        }
        public void SetToAddress(String NewAddress)
        {
            Int64 lne = 1;
            try
            {
                ToAddress = new emailaddress(xSys);
                lne++;
                ToAddress.addressstring = NewAddress;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "void SetToAddress(String NewAddress)", lne, "EMailMessageOld.cs", "Rz3_Common.EMailMessageOld", ee.ToString(), "Rz3_Common.EMailMessageOld.void SetToAddress(String NewAddress)"));
            }
        }
        public void SetFromAddress(String NewAddress)
        {
            Int64 lne = 1;
            try
            {
                FromAddress = new emailaddress(xSys);
                lne++;
                FromAddress.addressstring = NewAddress;
                lne++;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "void SetFromAddress(String NewAddress)", lne, "EMailMessageOld.cs", "Rz3_Common.EMailMessageOld", ee.ToString(), "Rz3_Common.EMailMessageOld.void SetFromAddress(String NewAddress)"));
            }
        }
        public Enums.MessageType GetAccurateContentType(String strSubject, String strReq, String strOffer)
        {
            Int64 lne = 1;
            try
            {
                Int32 lngNumber1 = strSubject.IndexOf(strReq, 1);
                lne++;
                Int32 lngNumber2 = strSubject.IndexOf(strOffer, 1);
                lne++;
                if (lngNumber2 < lngNumber1)
                {
                    lne++;
                    return Rz3_Common.Enums.MessageType.Offer;
                }
                else
                {
                    lne++;
                    return Rz3_Common.Enums.MessageType.Req;
                }
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Enums.MessageType GetAccurateContentType(String strSubject, String strReq, String strOffer)", lne, "EMailMessageOld.cs", "Rz3_Common.EMailMessageOld", ee.ToString(), "Rz3_Common.EMailMessageOld.Enums.MessageType GetAccurateContentType(String strSubject, String strReq, String strOffer)"));
                return Rz3_Common.Enums.MessageType.Unknown;
            }
        }
        //Private Functions
        private Boolean ContainsRestriction(String address, ArrayList colRestrictions, ref addresshandler xHandle)
        {
            Int64 lne = 1;
            try
            {
                xHandle = null;
                lne++;
                foreach (addresshandler h in colRestrictions)
                {
                    lne++;
                    if (Tools.Strings.StrCmp(h.emailaddress, address))
                    {
                        lne++;
                        xHandle = h;
                        lne++;
                        return true;
                    }
                }
                lne++;
                return false;
            }
            catch (Exception ee)
            {
                nError.HandleError(new nError.nErrorObject(ee.Message, "Boolean ContainsRestriction(String address, ArrayList colRestrictions, ref addresshandler xHandle)", lne, "EMailMessageOld.cs", "Rz3_Common.EMailMessageOld", ee.ToString(), "Rz3_Common.EMailMessageOld.Boolean ContainsRestriction(String address, ArrayList colRestrictions, ref addresshandler xHandle)"));
                return false;
            }
        }
    }

    namespace Enums
    {
        public enum MessageType
        {
            Offer = 0,
            Req = 1,
            Unknown = 2,
            Confirmation = 3
        }
    }
}
