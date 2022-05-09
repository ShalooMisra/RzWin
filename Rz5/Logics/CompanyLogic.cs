using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Core;
using NewMethod;
using Tools.Database;
using SensibleDAL;

namespace Rz5
{
    public class CompanyLogic : NewMethod.Logic
    {
        public virtual string GetCompanyWarranty(ContextNM x, string comp_id, bool as_vendor = false)
        {
            return "";
        }
        public virtual bool DisableContactNoteControls(contactnote n)
        {
            return false;
        }
        public virtual void ActsListInstanceGroupExtra(ContextRz context, ActSetup mnu)
        {

        }
        public virtual void ActsListInstanceDomainExtra(ContextRz context, ActSetup mnu)
        {

        }
        public virtual void ActsListInstanceFindRecordings(ContextRz context, ActSetup mnu)
        {

        }

        public virtual ListArgs PeopleSearchCompanyArgsGet(ContextRz x, PeopleSearchParameters pars)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheContext = x;
            ret.OptionsAllow = true;
            ret.AddAllow = false;
            ret.TheClass = "company";
            ret.TheTemplate = "COMPANYSEARCH";
            ret.TheTable = "company";
            ret.TheOrder = "companyname";
            if (pars.Empty)
            {
                ret.HeaderOnly = true;
                return ret;
            }
            nSQL xs = new nSQL(true);
            xs.strClass = "company";
            if (Tools.Strings.StrExt(pars.AgentNamePipeDelimited))
                xs.AddDirectWhereAnd("agentname in (" + nTools.GetIn(nTools.SplitArray(pars.AgentNamePipeDelimited, "|")) + ")");
            else
            {
                if (pars.OnlyUnassigned)
                    xs.AddDirectWhereAnd(" ( agentname is null or agentname in ('', 'unclaimed', 'house', 'bad record' ) or agentname like 'team:%' )");
            }
            //xs.AddWhere(Rz3App.xSys, "companyname", pars.CompanyName.Replace(" ", "%"));
            xs.AddWhere(x, "companyname", pars.CompanyName.Replace(" ", "%"), NewMethod.Enums.CompareType.LikeVeryFuzzy, FieldType.String);
            if (Tools.Strings.StrExt(pars.GroupName))
                xs.AddWhere(x, "group_name", "," + pars.GroupName + ",");
            if (Tools.Strings.StrExt(pars.SourceName))
                xs.AddDirectWhereAnd(" ( source like '%" + pars.SourceName + "%' or wherefoundcompany like '%" + pars.SourceName + "%' ) ");
            if (Tools.Strings.StrExt(pars.CallSchedule))
                xs.AddWhere(x, "call_schedule", "|" + pars.CallSchedule + "|", NewMethod.Enums.CompareType.LikeFuzzy);
            String strPhone = pars.PhoneFaxEmail;
            if (nTools.IsEmailAddress(strPhone))
                xs.AddDirectWhereAnd(" ( primaryemailaddress = '" + x.Filter(strPhone) + "' or exists( select unique_id from companycontact t where t.base_company_uid = company.unique_id and t.primaryemailaddress = '" + x.Filter(strPhone) + "') )");
            else
            {
                strPhone = strPhone.Replace("-", "%").Replace(" ", "%").Replace("(", "%").Replace(")", "%").Replace(".", "%");
                nSQL xp = new nSQL(false);
                xp.AddWhere(x, "replace(replace(replace(replace(replace(primaryphone, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", strPhone);
                xp.AddWhere(x, "replace(replace(replace(replace(replace(primaryfax, '-',  ''), ' ', ''), '(', ''), ')', ''), '.', '')", strPhone);
                xp.AddWhere(x, "primaryemailaddress", strPhone);
                xs.AddNonAbsolute(xp);
            }
            String strContact = pars.ContactName;
            if (Tools.Strings.StrExt(strContact))
            {
                if (strContact.Length > 6)
                    strContact = strContact.Replace(" ", "%");
                xs.CheckAdd();
                if (strContact.Length > 4)
                    xs.AddDirectWhere(" ( primarycontact like '%" + x.Filter(strContact) + "%' or exists( select * from companycontact c where c.base_company_uid = company.unique_id and c.contactname like '%" + x.Filter(strContact) + "%') )");
                else
                    xs.AddDirectWhere(" ( primarycontact like '" + x.Filter(strContact) + "%' or exists( select * from companycontact c where c.base_company_uid = company.unique_id and c.contactname like '" + x.Filter(strContact) + "%') )");
            }
            Boolean bSales = pars.HasSales;
            Boolean bPOs = pars.HasPurchases;

            //KT 3-30-2016 - HAs Sales was doiong nothing:
            if (bSales)
                xs.AddDirectWhereAnd("unique_id IN(select DISTINCT base_company_uid from ordhed_sales)");
            if (bPOs)
                xs.AddDirectWhereAnd("unique_id IN(select DISTINCT base_company_uid from ordhed_purchase)");
            //if (bSales && bPOs)
            //{                 

            //    xs.AddDirectWhereAnd(" isnull(calc_invoice_volume, 0) > 0 ");
            //    xs.AddDirectWhereAnd(" isnull(calc_purchase_volume, 0) > 0 ");
            //}
            //else
            //{    
            //if (bSales)
            //    xs.AddDirectWhereAnd(" isnull(calc_invoice_volume, 0) > 0 ");
            //if (bPOs)
            //    xs.AddDirectWhereAnd(" isnull(calc_purchase_volume, 0) > 0 ");
            //}


            String strSQL = "";
            String strOrderNumber = pars.OrderNumber;
            DateTime dtOrderDate = pars.OrderDate;
            String strPartNumber = pars.PartNumber;
            if (Tools.Strings.StrExt(strOrderNumber) || Tools.Dates.DateExists(dtOrderDate) || Tools.Strings.StrExt(strPartNumber))
            {
                strSQL = " exists( select ordhed.unique_id from ordhed ";
                if (Tools.Strings.StrExt(strPartNumber))
                    strSQL += " inner join orddet on orddet.base_ordhed_uid = ordhed.unique_id and orddet.prefix + orddet.basenumberstripped like '%" + x.Filter(PartObject.StripPart(strPartNumber)) + "%'";
                strSQL += " where ordhed.base_company_uid = company.unique_id ";
                if (Tools.Strings.StrExt(strOrderNumber))
                    strSQL += " and ( ordernumber = '" + x.Filter(strOrderNumber) + "' or orderreference = '" + x.Filter(strOrderNumber) + "' )";
                if (Tools.Dates.DateExists(dtOrderDate))
                    strSQL += " and datediff(d, orderdate, cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(dtOrderDate) + "' as datetime)) = 0";
                strSQL += " )";
                xs.AddDirectWhereAnd(strSQL);
            }
            String strAddress = pars.Address;
            if (Tools.Strings.StrExt(strAddress))
            {
                strSQL = " exists( select unique_id from companyaddress where companyaddress.base_company_uid = company.unique_id ";
                strSQL += " and ( adrcity like '" + x.Filter(strAddress) + "%'";
                strSQL += " or adrstate like '" + x.Filter(strAddress) + "%'";
                strSQL += " or adrzip like '" + x.Filter(strAddress) + "%'";
                strSQL += " or adrcountry like '" + x.Filter(strAddress) + "%'";
                strSQL += " or line1 like '%" + x.Filter(strAddress) + "%'";
                strSQL += " or line2 like '%" + x.Filter(strAddress) + "%'";
                strSQL += " or line3 like '%" + x.Filter(strAddress) + "%' )";
                strSQL += " )";
                xs.AddDirectWhereAnd(strSQL);
            }
            if (Tools.Strings.StrExt(pars.CompanyType))
            {
                switch (pars.CompanyType.ToLower().Trim())
                {
                    case "dist":
                    case "distributor":
                    case "d":
                        xs.AddWhere(x, "companytype", "dist");
                        break;
                    case "oem":
                    case "o":
                        xs.AddWhere(x, "companytype", "oem");
                        break;
                    case "non-dist":
                        xs.AddWhere(x, "companytype", "dist", NewMethod.Enums.CompareType.NotEqual);
                        break;
                    case "non-oem":
                        xs.AddWhere(x, "companytype", "oem", NewMethod.Enums.CompareType.NotEqual);
                        break;
                    default:
                        String type = pars.CompanyType.ToLower().Trim();
                        if (Tools.Strings.StrExt(type))
                            xs.AddWhere(x, "companytype", type, NewMethod.Enums.CompareType.Equal);
                        break;
                }
            }
            if (Tools.Strings.StrExt(pars.IndustrySegment))
                xs.AddDirectWhereAnd(" unique_id in ( select the_company_uid from mfg_link where manufacturer = '" + pars.IndustrySegment + "' ) ");
            if (Tools.Strings.StrExt(pars.CompanySubType))
                xs.AddDirectWhereAnd("specialty = '" + pars.CompanySubType + "'");
            FilterSQL_Company(xs, pars);
            String inv = x.Logic.CheckAppendInvisibleCompanies(x, "", "");
            if (Tools.Strings.StrExt(inv))
                xs.AddDirectWhereAnd(inv);
            if (pars.ReqMin > 0)
                xs.AddDirectWhereAnd("calc_reqs > " + pars.ReqMin.ToString());
            if (Tools.Strings.StrExt(pars.MfgType))
                xs.AddDirectWhereAnd("unique_id in (select the_company_uid from mfg_link where manufacturer = '" + pars.MfgType + "' and link_type = 'MFG') ");
            if (Tools.Strings.StrExt(pars.ComType))
                xs.AddDirectWhereAnd("unique_id in (select the_company_uid from mfg_link where manufacturer = '" + pars.ComType + "' and link_type = 'COM') ");
            if (Tools.Strings.StrExt(pars.Rank))
                xs.AddDirectWhereAnd("company_criteria = '" + pars.Rank + "'");
            if (Tools.Strings.StrExt(pars.TimeZone))
                xs.AddDirectWhereAnd("timezone = '" + pars.TimeZone + "'");


            if (!string.IsNullOrEmpty(pars.industry_segment))
                xs.AddDirectWhereAnd("industry_segment LIKE '%" + pars.industry_segment + "%'");






            LimitSQLCompany(x, xs);
            if (Tools.Strings.StrExt(pars.GeneralTerm))
            {
                String comp = "";
                if (pars.GeneralTerm.Length > 4)
                {
                    comp = " like '%" + x.Filter(pars.GeneralTerm) + "%'";
                    xs.AddDirectWhereAnd(" ( companyname " + comp + " or primarycontact " + comp + " or primaryphone " + comp + " or primaryfax " + comp + " or primaryemailaddress " + comp + " ) ");
                }
                else
                {
                    comp = " like '" + x.Filter(pars.GeneralTerm) + "%'";
                    xs.AddDirectWhereAnd(" ( companyname " + comp + " ) ");
                }
            }
            if (Tools.Strings.StrExt(pars.Office))
                xs.AddDirectWhereAnd(" base_mc_user_uid in (select unique_id from n_user where main_location = '" + pars.Office + "')");
            ret.SQL = xs;
            ret.TheWhere = xs.RenderSQL();
            ret.TheLimit = Convert.ToInt32(xs.lngLimit);
            return ret;
        }
        //public virtual ListArgs PeopleSearchCompanyArgsGet(ContextRz x, PeopleSearchParameters pars)
        //{
        //    ListArgs ret = new ListArgs(x);
        //    ret.TheContext = x;
        //    ret.OptionsAllow = true;
        //    ret.AddAllow = false;
        //    ret.TheClass = "company";
        //    ret.TheTemplate = "COMPANYSEARCH";
        //    ret.TheTable = "company";
        //    ret.TheOrder = "companyname";
        //    ret.TheCaption = "Company Search Results";
        //    if( pars.Empty )
        //    {
        //        ret.HeaderOnly = true;
        //        return ret;
        //    }
        //    nSQL xs = new nSQL(true);
        //    xs.strClass = "company";
        //    if (Tools.Strings.StrExt(pars.AgentNamePipeDelimited))
        //        xs.AddDirectWhereAnd("agentname in (" + nTools.GetIn(nTools.SplitArray(pars.AgentNamePipeDelimited, "|"), pars.IncludeBlankAgents) + ")");
        //    else
        //    {
        //        if (pars.OnlyUnassigned)
        //            xs.AddDirectWhereAnd(" ( agentname is null or agentname in ('', 'unclaimed', 'house', 'bad record' ) or agentname like 'team:%' )");
        //    }
        //    xs.AddWhere(x, "companyname", pars.CompanyName.Replace(" ", "%"));
        //    if (Tools.Strings.StrExt(pars.GroupName))
        //        xs.AddWhere(x, "group_name", "," + pars.GroupName + ",");
        //    if (Tools.Strings.StrExt(pars.SourceName))
        //        xs.AddDirectWhereAnd(" ( source like '%" + pars.SourceName + "%' or wherefoundcompany like '%" + pars.SourceName + "%' ) ");
        //    if (Tools.Strings.StrExt(pars.CallSchedule))
        //        xs.AddWhere(x, "call_schedule", "|" + pars.CallSchedule + "|", NewMethod.Enums.CompareType.LikeFuzzy);
        //    bool pfe = false;
        //    String strPhone = pars.PhoneFaxEmail;
        //    if (Tools.Strings.StrExt(strPhone))
        //        pfe = true;
        //    if (nTools.IsEmailAddress(strPhone))
        //        xs.AddDirectWhereAnd(" ( primaryemailaddress = '" + x.Filter(strPhone) + "' or exists( select unique_id from companycontact t where t.base_company_uid = company.unique_id and t.primaryemailaddress = '" + x.Filter(strPhone) + "') )");
        //    else
        //    {
        //        if (Tools.Strings.StrExt(strPhone))
        //        {
        //            strPhone = strPhone.Replace("-", "%").Replace(" ", "%").Replace("(", "%").Replace(")", "%").Replace(".", "%");
        //            nSQL xp = new nSQL(false);
        //            xp.AddWhere(x, "replace(replace(replace(replace(replace(primaryphone, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", strPhone);
        //            xp.AddWhere(x, "replace(replace(replace(replace(replace(primaryfax, '-',  ''), ' ', ''), '(', ''), ')', ''), '.', '')", strPhone);
        //            xp.AddWhere(x, "primaryemailaddress", strPhone);
        //            xs.AddNonAbsolute(xp);
        //        }
        //    }
        //    if (Tools.Strings.StrExt(pars.Phone) && !pfe)
        //    {
        //        nSQL xp = new nSQL(false);
        //        xp.AddWhere(x, "replace(replace(replace(replace(replace(primaryphone, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", pars.Phone.Replace("-", "%").Replace(" ", "%").Replace("(", "%").Replace(")", "%").Replace(".", "%"));
        //        xs.AddNonAbsolute(xp);
        //    }
        //    if (Tools.Strings.StrExt(pars.Fax) && !pfe)
        //    {
        //        nSQL xp = new nSQL(false);
        //        xp.AddWhere(x, "replace(replace(replace(replace(replace(primaryfax, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", pars.Fax.Replace("-", "%").Replace(" ", "%").Replace("(", "%").Replace(")", "%").Replace(".", "%"));
        //        xs.AddNonAbsolute(xp);
        //    }
        //    if (Tools.Strings.StrExt(pars.Email) && !pfe)
        //        xs.AddDirectWhereAnd(" ( primaryemailaddress like '" + x.Filter(pars.Email) + "%' or exists( select unique_id from companycontact t where t.base_company_uid = company.unique_id and t.primaryemailaddress like '" + x.Filter(pars.Email) + "%') )");
        //    String strContact = pars.ContactName;
        //    if (Tools.Strings.StrExt(strContact))
        //    {
        //        if (strContact.Length > 6)
        //            strContact = strContact.Replace(" ", "%");
        //        xs.CheckAdd();
        //        if (strContact.Length > 4)
        //            xs.AddDirectWhere(" ( primarycontact like '%" + x.Filter(strContact) + "%' or exists( select * from companycontact c where c.base_company_uid = company.unique_id and c.contactname like '%" + x.Filter(strContact) + "%') )");
        //        else
        //            xs.AddDirectWhere(" ( primarycontact like '" + x.Filter(strContact) + "%' or exists( select * from companycontact c where c.base_company_uid = company.unique_id and c.contactname like '" + x.Filter(strContact) + "%') )");
        //    }
        //    Boolean bSales = pars.HasSales;
        //    Boolean bPOs = pars.HasPurchases;
        //    if (bSales && bPOs)
        //        xs.AddDirectWhereAnd(" (isnull((select sum(orddet_line.total_price) from orddet_line inner join ordhed_sales on ordhed_sales.unique_id = orddet_line.orderid_sales where ordhed_sales.base_company_uid = company.unique_id and len(isnull(orddet_line.orderid_sales,''))>0),0)>0 or isnull((select sum(orddet_line.total_cost) from orddet_line inner join ordhed_purchase on ordhed_purchase.unique_id = orddet_line.orderid_purchase where ordhed_purchase.base_company_uid = company.unique_id and len(isnull(orddet_line.orderid_purchase,''))>0),0)>0) ");
        //    else
        //    {
        //        if (bSales)
        //            xs.AddDirectWhereAnd(" isnull((select sum(orddet_line.total_price) from orddet_line where orddet_line.customer_uid = company.unique_id and len(isnull(orddet_line.orderid_sales,''))>0),0)>0 ");
        //        if (bPOs)
        //            xs.AddDirectWhereAnd(" isnull((select sum(orddet_line.total_cost) from orddet_line where orddet_line.vendor_uid = company.unique_id and len(isnull(orddet_line.orderid_purchase,''))>0),0)>0 ");
        //    }
        //    String strSQL = "";
        //    String strOrderNumber = pars.OrderNumber;
        //    DateTime dtOrderDate = pars.OrderDate;
        //    String strPartNumber = pars.PartNumber;
        //    if (Tools.Strings.StrExt(strOrderNumber) || Tools.Dates.DateExists(dtOrderDate) || Tools.Strings.StrExt(strPartNumber))
        //    {
        //        strSQL = " exists( select ordhed.unique_id from ordhed ";
        //        if (Tools.Strings.StrExt(strPartNumber))
        //        {
        //            strSQL += " inner join orddet on orddet.base_ordhed_uid = ordhed.unique_id and orddet.prefix + orddet.basenumberstripped like '%" + x.Filter(PartObject.StripPart(strPartNumber)) + "%'";
        //        }
        //        strSQL += " where ordhed.base_company_uid = company.unique_id ";
        //        if (Tools.Strings.StrExt(strOrderNumber))
        //            strSQL += " and ( ordernumber = '" + x.Filter(strOrderNumber) + "' or orderreference = '" + x.Filter(strOrderNumber) + "' )";
        //        if (Tools.Dates.DateExists(dtOrderDate))
        //            strSQL += " and datediff(d, orderdate, cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(dtOrderDate) + "' as datetime)) = 0";
        //        strSQL += " )";
        //        xs.AddDirectWhereAnd(strSQL);
        //    }
        //    bool addr = false;
        //    String strAddress = pars.Address;
        //    if (Tools.Strings.StrExt(strAddress))
        //    {
        //        addr = true;
        //        strSQL = " exists( select unique_id from companyaddress where companyaddress.base_company_uid = company.unique_id ";
        //        strSQL += " and ( adrcity like '" + x.Filter(strAddress) + "%'";
        //        strSQL += " or adrstate like '" + x.Filter(strAddress) + "%'";
        //        strSQL += " or adrzip like '" + x.Filter(strAddress) + "%'";
        //        strSQL += " or adrcountry like '" + x.Filter(strAddress) + "%'";
        //        strSQL += " or line1 like '%" + x.Filter(strAddress) + "%'";
        //        strSQL += " or line2 like '%" + x.Filter(strAddress) + "%'";
        //        strSQL += " or line3 like '%" + x.Filter(strAddress) + "%' )";
        //        strSQL += " )";
        //        xs.AddDirectWhereAnd(strSQL);
        //    }
        //    if (Tools.Strings.StrExt(pars.AddrLines) && !addr)
        //    {
        //        strSQL = " exists( select unique_id from companyaddress where companyaddress.base_company_uid = company.unique_id ";
        //        strSQL += " and ( line1 like '%" + x.Filter(pars.AddrLines) + "%'";
        //        strSQL += " or line2 like '%" + x.Filter(pars.AddrLines) + "%'";
        //        strSQL += " or line3 like '%" + x.Filter(pars.AddrLines) + "%' )";
        //        strSQL += " )";
        //        xs.AddDirectWhereAnd(strSQL);
        //    }
        //    if (Tools.Strings.StrExt(pars.City) && !addr)
        //    {
        //        strSQL = " exists( select unique_id from companyaddress where companyaddress.base_company_uid = company.unique_id ";
        //        strSQL += " and ( adrcity like '" + x.Filter(pars.City) + "%')";
        //        strSQL += " )";
        //        xs.AddDirectWhereAnd(strSQL);
        //    }
        //    if (Tools.Strings.StrExt(pars.State) && !addr)
        //    {
        //        strSQL = " exists( select unique_id from companyaddress where companyaddress.base_company_uid = company.unique_id ";
        //        strSQL += " and ( adrstate like '" + x.Filter(pars.State) + "%')";
        //        strSQL += " )";
        //        xs.AddDirectWhereAnd(strSQL);
        //    }
        //    if (Tools.Strings.StrExt(pars.Zip) && !addr)
        //    {
        //        strSQL = " exists( select unique_id from companyaddress where companyaddress.base_company_uid = company.unique_id ";
        //        strSQL += " and ( adrzip like '" + x.Filter(pars.Zip) + "%')";
        //        strSQL += " )";
        //        xs.AddDirectWhereAnd(strSQL);
        //    }
        //    if (Tools.Strings.StrExt(pars.Country) && !addr)
        //    {
        //        strSQL = " exists( select unique_id from companyaddress where companyaddress.base_company_uid = company.unique_id ";
        //        strSQL += " and ( adrcountry like '" + x.Filter(pars.Country) + "%')";
        //        strSQL += " )";
        //        xs.AddDirectWhereAnd(strSQL);
        //    }
        //    if (Tools.Strings.StrExt(pars.CompanyType))
        //    {
        //        switch (pars.CompanyType.ToLower().Trim())
        //        {
        //            case "dist":
        //            case "distributor":
        //            case "d":
        //                xs.AddWhere(x, "companytype", "dist");
        //                break;
        //            case "oem":
        //            case "o":
        //                xs.AddWhere(x, "companytype", "oem");
        //                break;
        //            case "non-dist":
        //                xs.AddWhere(x, "companytype", "dist", NewMethod.Enums.CompareType.NotEqual);
        //                break;
        //            case "non-oem":
        //                xs.AddWhere(x, "companytype", "oem", NewMethod.Enums.CompareType.NotEqual);
        //                break;
        //            default:
        //                String type = pars.CompanyType.ToLower().Trim();
        //                if (Tools.Strings.StrExt(type))
        //                    xs.AddWhere(x, "companytype", type, NewMethod.Enums.CompareType.Equal);
        //                break;
        //        }
        //    }

        //    if (Tools.Strings.StrExt(pars.IndustrySegment))
        //    {
        //        xs.AddDirectWhereAnd(" unique_id in ( select the_company_uid from mfg_link where manufacturer = '" + pars.IndustrySegment + "' ) ");
        //    }
        //    if (Tools.Strings.StrExt(pars.CompanySubType))
        //        xs.AddDirectWhereAnd("specialty = '" + pars.CompanySubType + "'");

        //    FilterSQL_Company(xs, pars);

        //    String inv = x.Logic.CheckAppendInvisibleCompanies(x, "", "");
        //    if (Tools.Strings.StrExt(inv))
        //        xs.AddDirectWhereAnd(inv);

        //    if (pars.ReqMin > 0)
        //    {
        //        xs.AddDirectWhereAnd("calc_reqs > " + pars.ReqMin.ToString());
        //    }
        //    if (Tools.Strings.StrExt(pars.MfgType))
        //        xs.AddDirectWhereAnd("unique_id in (select the_company_uid from mfg_link where manufacturer = '" + pars.MfgType + "' and link_type = 'MFG') ");
        //    if (Tools.Strings.StrExt(pars.ComType))
        //        xs.AddDirectWhereAnd("unique_id in (select the_company_uid from mfg_link where manufacturer = '" + pars.ComType + "' and link_type = 'COM') ");
        //    if (Tools.Strings.StrExt(pars.Rank))
        //        xs.AddDirectWhereAnd("company_criteria = '" + pars.Rank + "'");
        //    if (Tools.Strings.StrExt(pars.TimeZone))
        //        xs.AddDirectWhereAnd("timezone = '" + pars.TimeZone + "'");

        //    LimitSQLCompany(x, xs);

        //    if (Tools.Strings.StrExt(pars.GeneralTerm))
        //    {
        //        String comp = "";
        //        if (pars.GeneralTerm.Length > 3)
        //        {
        //            comp = " like '%" + x.Filter(pars.GeneralTerm) + "%'";
        //            xs.AddDirectWhereAnd(" ( companyname " + comp + " or primarycontact " + comp + " or primaryphone " + comp + " or primaryfax " + comp + " or primaryemailaddress " + comp + " ) ");
        //        }
        //        else
        //        {
        //            comp = " like '" + x.Filter(pars.GeneralTerm) + "%'";
        //            xs.AddDirectWhereAnd(" ( companyname " + comp + " ) ");
        //        }
        //    }
        //    if (Tools.Strings.StrExt(pars.Office))
        //        xs.AddDirectWhereAnd(" base_mc_user_uid in (select unique_id from n_user where main_location = '" + pars.Office + "')");

        //    ret.SQL = xs;
        //    ret.TheWhere = xs.RenderSQL();
        //    ret.TheLimit = Convert.ToInt32(xs.lngLimit);
        //    return ret;
        //}

        public virtual void FilterSQL_Company(nSQL xSQL, PeopleSearchParameters pars)
        {
            if (pars.Filters != null)
            {
                foreach (String s in pars.Filters)
                {
                    switch (s.Trim())
                    {
                        default:
                            break;
                    }
                }
            }
        }
        protected virtual void LimitSQLCompany(ContextNM x, nSQL xs)
        {

        }
        public virtual bool DealContactRequired(companycontact cont)
        {
            return false;
        }
        ///////////////////////////////////////////////////////////////
        // Contact Search Args
        public virtual ListArgs PeopleSearchContactArgsGet(ContextRz context, PeopleSearchParameters pars)
        {

            ListArgs ret = new ListArgs(context);
            ret.TheContext = context;
            ret.OptionsAllow = true;
            ret.TheClass = "companycontact";
            ret.TheTemplate = "CONTACTSEARCH";
            ret.TheTable = "companycontact";
            ret.TheCaption = "Contact Search Results";

            if (pars.OrderByDomain)
                ret.TheOrder = "email_domain";
            else
                ret.TheOrder = "companyname";

            nSQL xs = new nSQL(true);
            xs.strClass = "companycontact";
            if (Tools.Strings.StrExt(pars.AgentNamePipeDelimited))
                xs.AddDirectWhereAnd("agentname in (" + nTools.GetIn(nTools.SplitArray(pars.AgentNamePipeDelimited, "|")) + ")");
            else
            {
                if (pars.OnlyUnassigned)
                {
                    //not bad records
                    xs.AddDirectWhereAnd(" ( agentname is null or agentname in ('', 'unclaimed', 'house' ) or agentname like 'team:%' )");
                }
            }

            if (Tools.Strings.StrExt(pars.GroupName))
                xs.AddWhere(context, "group_name", "," + pars.GroupName + ",");

            bool force_fuzzy = Tools.Strings.StrExt(pars.PhoneFaxEmail + pars.ContactName);
            xs.AddWhere(context, "companyname", pars.CompanyName.Replace(" ", "%"), force_fuzzy);

            force_fuzzy = Tools.Strings.StrExt(pars.PhoneFaxEmail + pars.CompanyName);

            if (Tools.Strings.StrExt(pars.ContactName))
            {
                nSQL contactsql = new nSQL();
                contactsql.AddWhere(context, "contactname", pars.ContactName.Replace(" ", "%"), force_fuzzy);
                //contactsql.CheckAddOr();
                contactsql.AddWhere(context, "alternate_names", pars.ContactName.Replace(" ", "%"), true);
                //companycontact x;
                xs.AddNonAbsolute(contactsql);
            }


            String strCustomerStatus = pars.CustomerStatus;
            switch (strCustomerStatus.ToLower())
            {
                case "customer":
                    xs.AddDirectWhereAnd(" isnull(calc_sale_count, 0) > 0 ");
                    break;
                case "prospect":
                    xs.AddDirectWhereAnd(" ( isnull(calc_sale_count, 0) = 0 and isnull(calc_fquote_count, 0) > 0 ) ");
                    break;
                case "inactive":
                    xs.AddDirectWhereAnd(" ( isnull(calc_sale_count, 0) = 0 and isnull(calc_fquote_count, 0) = 0 ) ");
                    break;
            }

            if (pars.BadMailingAddress)
            {
                xs.AddWhere(context, "bad_data", "1", NewMethod.Enums.CompareType.Equal, FieldType.Boolean);
            }
            bool pfe = false;
            String strPhone = pars.PhoneFaxEmail;
            if (Tools.Strings.StrExt(strPhone))
                pfe = true;
            if (nTools.IsEmailAddress(strPhone))
                xs.AddDirectWhereAnd(" (primaryemailaddress = '" + context.Filter(strPhone) + "' or alternate_emails like '%<" + context.Filter(strPhone) + ">%' )");
            else
            {
                strPhone = strPhone.Replace("-", "%").Replace(" ", "%").Replace("(", "%").Replace(")", "%").Replace(".", "%");
                if (Tools.Strings.StrExt(strPhone))
                {
                    nSQL xp = new nSQL(false);
                    xp.AddWhere(context, "replace(replace(replace(replace(replace(primaryphone, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", strPhone);
                    xp.AddWhere(context, "replace(replace(replace(replace(replace(alternatephone, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", strPhone);
                    xp.AddWhere(context, "replace(replace(replace(replace(replace(primaryfax, '-',  ''), ' ', ''), '(', ''), ')', ''), '.', '')", strPhone);
                    xp.AddWhere(context, "strippedphone", strPhone);
                    xp.AddWhere(context, "primaryemailaddress", strPhone);
                    xs.AddNonAbsolute(xp);
                }
            }
            if (Tools.Strings.StrExt(pars.Phone) && !pfe)
            {
                nSQL xp = new nSQL(false);
                xp.AddWhere(context, "replace(replace(replace(replace(replace(primaryphone, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", pars.Phone.Replace("-", "%").Replace(" ", "%").Replace("(", "%").Replace(")", "%").Replace(".", "%"));
                xp.AddWhere(context, "strippedphone", pars.Phone.Replace("-", "%").Replace(" ", "%").Replace("(", "%").Replace(")", "%").Replace(".", "%"));
                xs.AddNonAbsolute(xp);
            }
            if (Tools.Strings.StrExt(pars.Fax) && !pfe)
            {
                nSQL xp = new nSQL(false);
                xp.AddWhere(context, "replace(replace(replace(replace(replace(primaryfax, '-', ''), ' ', ''), '(', ''), ')', ''), '.', '')", pars.Fax.Replace("-", "%").Replace(" ", "%").Replace("(", "%").Replace(")", "%").Replace(".", "%"));
                xs.AddNonAbsolute(xp);
            }
            if (Tools.Strings.StrExt(pars.Email) && !pfe)
                xs.AddDirectWhereAnd(" (primaryemailaddress like '" + context.Filter(pars.Email) + "%' or alternate_emails like '%<" + context.Filter(pars.Email) + ">%' )");
            String strSQL = "";
            String strOrderNumber = pars.OrderNumber;
            DateTime dtOrderDate = pars.OrderDate;
            String strPartNumber = pars.PartNumber;
            if (Tools.Strings.StrExt(strOrderNumber) || Tools.Dates.DateExists(dtOrderDate) || Tools.Strings.StrExt(strPartNumber))
            {
                strSQL = " exists( select ordhed.unique_id from ordhed ";
                if (Tools.Strings.StrExt(strPartNumber))
                {
                    strSQL += " inner join orddet on orddet.base_ordhed_uid = ordhed.unique_id and orddet.prefix + orddet.basenumberstripped like '%" + context.Filter(PartObject.StripPart(strPartNumber)) + "%'";
                }
                strSQL += " where ordhed.base_companycontact_uid = companycontact.unique_id ";
                if (Tools.Strings.StrExt(strOrderNumber))
                    strSQL += " and ( ordhed.ordernumber = '" + context.Filter(strOrderNumber) + "' or orderreference = '" + context.Filter(strOrderNumber) + "' )";  //changed from referencenumber 2012_11_15
                if (Tools.Dates.DateExists(dtOrderDate))
                    strSQL += " and datediff(d, orderdate, cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(dtOrderDate) + "' as datetime)) = 0";
                strSQL += " )";
                xs.AddDirectWhereAnd(strSQL);
            }
            bool addr = false;
            String strAddress = pars.Address;
            if (Tools.Strings.StrExt(strAddress))
            {
                addr = true;
                nSQL asql = new nSQL(false);
                asql.AddWhere(context, "line1", strAddress, NewMethod.Enums.CompareType.LikeFuzzy);
                asql.AddWhere(context, "line2", strAddress, NewMethod.Enums.CompareType.LikeFuzzy);
                asql.AddWhere(context, "line3", strAddress, NewMethod.Enums.CompareType.LikeFuzzy);
                asql.AddWhere(context, "adrcity", strAddress, NewMethod.Enums.CompareType.LikeTrailing);
                asql.AddWhere(context, "adrstate", strAddress, NewMethod.Enums.CompareType.LikeTrailing);
                asql.AddWhere(context, "adrzip", strAddress, NewMethod.Enums.CompareType.LikeTrailing);
                asql.AddWhere(context, "adrcountry", strAddress, NewMethod.Enums.CompareType.LikeTrailing);
                strSQL = " exists( select unique_id from companyaddress where companyaddress.base_companycontact_uid = companycontact.unique_id ";
                strSQL += " and ( adrcity like '" + context.Filter(strAddress) + "%'";
                strSQL += " or adrstate like '" + context.Filter(strAddress) + "%'";
                strSQL += " or adrzip like '" + context.Filter(strAddress) + "%'";
                strSQL += " or adrcountry like '" + context.Filter(strAddress) + "%'";
                strSQL += " or line1 like '%" + context.Filter(strAddress) + "%'";
                strSQL += " or line2 like '%" + context.Filter(strAddress) + "%'";
                strSQL += " or line3 like '%" + context.Filter(strAddress) + "%' )";
                strSQL += " )";
                asql.AddDirectWhereOr(strSQL);
                xs.AddNonAbsolute(asql);
            }
            if (Tools.Strings.StrExt(pars.AddrLines) && !addr)
            {
                nSQL asql = new nSQL(false);
                asql.AddWhere(context, "line1", pars.AddrLines, NewMethod.Enums.CompareType.LikeFuzzy);
                asql.AddWhere(context, "line2", pars.AddrLines, NewMethod.Enums.CompareType.LikeFuzzy);
                asql.AddWhere(context, "line3", pars.AddrLines, NewMethod.Enums.CompareType.LikeFuzzy);
                strSQL = " exists( select unique_id from companyaddress where companyaddress.base_companycontact_uid = companycontact.unique_id ";
                strSQL += " and ( line1 like '%" + context.Filter(pars.AddrLines) + "%'";
                strSQL += " or line2 like '%" + context.Filter(pars.AddrLines) + "%'";
                strSQL += " or line3 like '%" + context.Filter(pars.AddrLines) + "%' )";
                strSQL += " )";
                asql.AddDirectWhereOr(strSQL);
                xs.AddNonAbsolute(asql);
            }
            if (Tools.Strings.StrExt(pars.City) && !addr)
            {
                nSQL asql = new nSQL(false);
                asql.AddWhere(context, "adrcity", pars.City, NewMethod.Enums.CompareType.LikeTrailing);
                strSQL = " exists( select unique_id from companyaddress where companyaddress.base_companycontact_uid = companycontact.unique_id ";
                strSQL += " and ( adrcity like '" + context.Filter(pars.City) + "%')";
                strSQL += " )";
                asql.AddDirectWhereOr(strSQL);
                xs.AddNonAbsolute(asql);
            }
            if (Tools.Strings.StrExt(pars.State) && !addr)
            {
                nSQL asql = new nSQL(false);
                asql.AddWhere(context, "adrstate", pars.State, NewMethod.Enums.CompareType.LikeTrailing);
                strSQL = " exists( select unique_id from companyaddress where companyaddress.base_companycontact_uid = companycontact.unique_id ";
                strSQL += " and ( adrstate like '" + context.Filter(pars.State) + "%')";
                strSQL += " )";
                asql.AddDirectWhereOr(strSQL);
                xs.AddNonAbsolute(asql);
            }
            if (Tools.Strings.StrExt(pars.Zip) && !addr)
            {
                nSQL asql = new nSQL(false);
                asql.AddWhere(context, "adrzip", pars.Zip, NewMethod.Enums.CompareType.LikeTrailing);
                strSQL = " exists( select unique_id from companyaddress where companyaddress.base_companycontact_uid = companycontact.unique_id ";
                strSQL += " and ( adrzip like '" + context.Filter(pars.Zip) + "%')";
                strSQL += " )";
                asql.AddDirectWhereOr(strSQL);
                xs.AddNonAbsolute(asql);
            }
            if (Tools.Strings.StrExt(pars.Country) && !addr)
            {
                nSQL asql = new nSQL(false);
                asql.AddWhere(context, "adrcountry", pars.Country, NewMethod.Enums.CompareType.LikeTrailing);
                strSQL = " exists( select unique_id from companyaddress where companyaddress.base_companycontact_uid = companycontact.unique_id ";
                strSQL += " and ( adrcountry like '" + context.Filter(pars.Country) + "%')";
                strSQL += " )";
                asql.AddDirectWhereOr(strSQL);
                xs.AddNonAbsolute(asql);
            }
            nSQL xo = new nSQL(false);
            xo.AddWhere(context, "wherefound", pars.SourceName);
            xo.AddWhere(context, "source", pars.SourceName);
            xs.AddNonAbsolute(xo);
            if (Tools.Strings.StrExt(pars.CompanyType))
            {
                switch (pars.CompanyType.ToLower().Trim())
                {
                    case "dist":
                    case "distributor":
                    case "d":
                        xs.AddWhere(context, "abs_type", "dist");
                        break;
                    case "oem":
                    case "o":
                        xs.AddWhere(context, "abs_type", "oem");
                        break;
                    case "non-dist":
                        xs.AddWhere(context, "abs_type", "dist", NewMethod.Enums.CompareType.NotEqual);
                        break;
                    case "non-oem":
                        xs.AddWhere(context, "abs_type", "oem", NewMethod.Enums.CompareType.NotEqual);
                        break;
                    default:
                        xs.AddDirectWhereAnd(" base_company_uid in ( select isnull(unique_id, '') from company where companytype = '" + context.Filter(pars.CompanyType) + "' ) ");
                        break;
                }
            }


            DateTime callcutoff = pars.NotCalledSince;
            if (Tools.Dates.DateExists(callcutoff))
                xs.AddDirectWhereAnd("isnull(calc_last_phonecall, cast('01/01/1900' as datetime)) < cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(callcutoff) + "' as datetime)");

            String inv = context.Logic.CheckAppendInvisibleCompanies(context, "", "");
            if (Tools.Strings.StrExt(inv))
                xs.AddDirectWhereAnd(inv);

            FilterSQL_Contact(context, xs, pars);

            //if (xDisplay.UnlimitedResults)
            //    xs.lngLimit = -1;
            //else
            //    xs.lngLimit = GetRowLimit();

            if (Tools.Strings.StrExt(pars.GeneralTerm))
            {
                String comp = "";
                if (pars.GeneralTerm.Length > 3)
                {
                    comp = " like '%" + context.Filter(pars.GeneralTerm) + "%'";
                    xs.AddDirectWhereAnd(" ( companyname " + comp + " or contactname " + comp + " or primaryphone " + comp + " or primaryfax " + comp + " or primaryemailaddress " + comp + " ) ");
                }
                else
                {
                    comp = " like '" + context.Filter(pars.GeneralTerm) + "%'";
                    xs.AddDirectWhereAnd(" ( companyname " + comp + " or contactname " + comp + " ) ");
                }
            }
            if (Tools.Strings.StrExt(pars.Office))
                xs.AddDirectWhereAnd(" base_mc_user_uid in (select unique_id from n_user where main_location = '" + pars.Office + "')");

            LimitSQLContact(context, xs);

            ret.TheWhere = xs.RenderSQL();
            ret.TheLimit = Convert.ToInt32(xs.lngLimit);

            return ret;
        }

        public bool IsPotentialExcessPart(ContextRz xRz, company comp, orddet_quote q, out List<string> potentialParts)
        {

            potentialParts = new List<string>();


        
        
            if (string.IsNullOrEmpty(q.fullpartnumber))
                return false;
            string strPart = q.fullpartnumber.Trim().ToUpper();
            //if (strPart.Length <= 4)
            //    return false;
            //string strPartTrimmed = strPart.Substring(0, 4);
            //ArrayList pList = xRz.QtC("partrecord", "select * from partrecord where stocktype = 'excess' and fullpartnumber like '" + strPartTrimmed + "%'");

            ArrayList pList = xRz.QtC("partrecord", "select * from partrecord where stocktype = 'excess' and fullpartnumber = '" + strPart + "%'");
            if (pList == null)
                return false;
                
                foreach (partrecord p in pList)
                {
                    string foundPartTrimmed = p.fullpartnumber.Trim().ToUpper();
                    if (!potentialParts.Contains(foundPartTrimmed))
                        potentialParts.Add(foundPartTrimmed);
                }
            

            return potentialParts.Count > 0;

        }

        protected virtual void LimitSQLContact(ContextRz context, nSQL xs)
        {

        }
        public virtual void FilterSQL_Contact(ContextNM x, nSQL xSQL, PeopleSearchParameters pars)
        {
            if (pars.Filters != null)
            {
                foreach (String s in pars.Filters)
                {
                    switch (s.Trim())
                    {
                        case "Active Customers":
                            xSQL.AddWhere(x, "calc_sale_count", "0", NewMethod.Enums.CompareType.GreaterThan, FieldType.Int64);
                            break;
                        case "Non-Customers":
                            xSQL.AddWhere(x, "calc_sale_count", "0", NewMethod.Enums.CompareType.Equal, FieldType.Int64);
                            break;
                        case "Active Prospects":
                            xSQL.AddWhere(x, "calc_qquote_count", "0", NewMethod.Enums.CompareType.GreaterThan, FieldType.Int64);
                            break;
                        case "Non-Prospects":
                            xSQL.AddWhere(x, "calc_qquote_count", "0", NewMethod.Enums.CompareType.Equal, FieldType.Int64);
                            xSQL.AddWhere(x, "calc_fquote_count", "0", NewMethod.Enums.CompareType.Equal, FieldType.Int64);
                            break;
                        case "Called":
                            xSQL.AddWhere(x, "calc_phonecall_count", "0", NewMethod.Enums.CompareType.GreaterThan, FieldType.Int64);
                            break;
                        case "Not Called":
                            xSQL.AddWhere(x, "calc_phonecall_count", "0", NewMethod.Enums.CompareType.Equal, FieldType.Int64);
                            break;
                        case "Verified":
                            xSQL.AddWhere_Boolean(x, "isverified", true);
                            break;
                        case "Non-Verified":
                            xSQL.AddWhere_Boolean(x, "isverified", false);
                            break;
                        case "Assigned":
                            xSQL.AddWhere(x, "agentname", "<blank>", NewMethod.Enums.CompareType.NotEqual);
                            xSQL.AddWhere(x, "agentname", "bad record", NewMethod.Enums.CompareType.NotEqual);
                            xSQL.AddWhere(x, "agentname", "team:", NewMethod.Enums.CompareType.NotLikeTrailing);
                            xSQL.AddWhere(x, "agentname", "unassigned", NewMethod.Enums.CompareType.NotEqual);
                            break;
                        case "Non-Assigned":
                            nSQL sq = new nSQL(false);
                            sq.AddWhere(x, "agentname", "<blank>", NewMethod.Enums.CompareType.Equal);
                            sq.AddWhere(x, "agentname", "bad record", NewMethod.Enums.CompareType.Equal);
                            sq.AddWhere(x, "agentname", "unassigned", NewMethod.Enums.CompareType.Equal);
                            sq.AddWhere(x, "agentname", "team:", NewMethod.Enums.CompareType.LikeTrailing);
                            xSQL.AddNonAbsolute(sq);
                            break;
                        //case "Web Assigned":
                        //case "Non-Web Assigned":
                        case "Web Active / Non-Assigned":
                            sq = new nSQL(false);
                            sq.AddWhere(x, "agentname", "", NewMethod.Enums.CompareType.Equal);
                            //sq.AddWhere(xSys, "agentname", "bad record", NewMethod.Enums.CompareType.Equal);
                            sq.AddWhere(x, "agentname", "unassigned", NewMethod.Enums.CompareType.Equal);
                            xSQL.AddNonAbsolute(sq);
                            xSQL.AddDirectWhereAnd(" ( exists( select unique_id from hit where hit.base_companycontact_uid = companycontact.unique_id ) or exists( select unique_id from rapidquote where rapidquote.base_companycontact_uid = companycontact.unique_id ) )");
                            break;
                        case "Bad Contact Data":
                            sq = new nSQL(false);
                            sq.AddWhere_Boolean(x, "bad_data", true);
                            sq.AddWhere(x, "agentname", "bad record", NewMethod.Enums.CompareType.Equal);
                            xSQL.AddNonAbsolute(sq);
                            break;
                        case "Needs Attention":
                            xSQL.AddWhere_Boolean(x, "needsattention", true);
                            break;
                        case "Conflict":
                            xSQL.AddWhere_Boolean(x, "isconflict", true);
                            break;
                        case "Distributors":
                            xSQL.AddWhere(x, "abs_type", "dist");
                            break;
                        case "Non-Distributors":
                            xSQL.AddWhere(x, "abs_type", "dist", NewMethod.Enums.CompareType.NotEqual);
                            break;
                        case "OEMs":
                            xSQL.AddWhere(x, "abs_type", "oem");
                            break;
                        case "Non-OEMs":
                            xSQL.AddWhere(x, "abs_type", "oem", NewMethod.Enums.CompareType.NotEqual);
                            break;
                        case "Incomplete Email Addresses":
                            xSQL.AddDirectWhereAnd(" ( primaryemailaddress > '' and ( primaryemailaddress not like '%_@_%._%' or primaryemailaddress like '% %'   ) )");
                            break;
                        case "CTG123 Members":
                            xSQL.AddDirectWhereAnd(" ( isnull(source, '') like '%ctg123%' or isnull(wherefound, '') like '%ctg123%' )");
                            break;
                        case "Non-CTG123 Members":
                            xSQL.AddDirectWhereAnd(" ( isnull(source, '') not like '%ctg123%' and isnull(wherefound, '') not like '%ctg123%' )");
                            break;
                    }
                }
            }
        }
        public virtual void CompanyRestore(ContextRz x)
        {
            x.Reorg();
            //if (!x.xSys.Recall)
            //{
            //    x.TheLeader.Tell("This system isn't set up for Recall.");
            //    return;
            //}
            //ArrayList companies = frmRecallRestore_Company.AskRecallRestore_Company(x, x.xSys.xData, x.xSys.recall_connection);
            //if (companies == null)
            //    return;
            //if (companies.Count <= 0)
            //    return;
            //string insert = "";
            //foreach (company c in companies)
            //{
            //    string s = x.xSys.xData.GetScalar_String("select unique_id from company where unique_id = '" + c.unique_id + "'");
            //    if (!Tools.Strings.StrExt(s))
            //    {
            //        if (Tools.Strings.StrExt(insert))
            //            insert += ",";
            //        insert += "'" + c.unique_id + "'";
            //    }
            //    else
            //        x.TheLeader.Error("The company with UID " + c.unique_id + " already exists in the company list");
            //}
            //if (!Tools.Strings.StrExt(insert))
            //    return;
            //DataTable st = x.xSys.recall_connection.GetDataTable("select top 1 * from company");
            //SortedList props = x.xSys.GetPropsByClass("company");
            //String strSQL = "";
            //ArrayList a = new ArrayList();
            //foreach (DictionaryEntry d in props)
            //{
            //    n_prop p = (n_prop)d.Value;
            //    //only restore fields that exist in the backup
            //    if (!p.IsUniqueID)
            //    {
            //        if (nData.HasField(st, p.name))
            //        {
            //            if (!nTools.IsInArray(p.name, a))
            //            {
            //                if (Tools.Strings.StrExt(strSQL))
            //                    strSQL += ", ";
            //                strSQL += p.name;
            //                a.Add(p.Name);
            //            }
            //        }
            //    }
            //}
            //string where = x.xSys.recall_connection.database_name + ".dbo.company.unique_id in (" + insert + ") and recall_type = 3";  //the recall type wasn't there before, so it was restoring every instance of the company being changed
            //strSQL = "insert into " + x.xSys.xData.database_name + ".dbo.company(unique_id, " + strSQL + ") select top 1 unique_id, " + strSQL + " from company where " + where + " order by recall_date desc";  //added top 1, because with restoration, there can be multiple delete records
            //if (x.xSys.recall_connection.Execute(strSQL))
            //{
            //    //show the first 3
            //    int c = 0;
            //    foreach (company coriginal in companies)
            //    {
            //        company crestore = company.GetByID(x.xSys, coriginal.unique_id);
            //        if (crestore != null)
            //            x.Show(crestore);

            //        c++;
            //        if (c > 3)
            //            break;
            //    }
            //    x.TheLeader.Tell("Done.");
            //}
            //else
            //    x.TheLeader.Tell("The restore was not successful.");
        }
        public virtual void ContactRestore(ContextNM x)
        {
            x.Reorg();

            //if (!x.xSys.Recall)
            //{
            //    x.TheLeader.Tell("This system isn't set up for Recall.");
            //    return;
            //}
            //string strNumber = x.TheLeader.AskForString("Contact ID?");
            //if (!Tools.Strings.StrExt(strNumber))
            //    return;
            //string strSQL = "select unique_id from companycontact where unique_id = '" + strNumber + "'";
            //string s = x.xSys.xData.GetScalar(strSQL, "");
            //if (Tools.Strings.StrExt(s))
            //{
            //    x.TheLeader.Tell("This contact already appears to exist in the main database.");
            //    return;
            //}
            //s = x.xSys.recall_connection.GetScalar(strSQL, "");
            //if (!Tools.Strings.StrExt(s))
            //{
            //    x.TheLeader.Tell("This contact wasn't found in the Recall system.");
            //    return;
            //}
            //DataTable st = x.xSys.recall_connection.GetDataTable("select top 1 * from companycontact");
            //SortedList props = x.xSys.GetPropsByClass("companycontact");
            //strSQL = "";
            //ArrayList a = new ArrayList();
            //foreach (DictionaryEntry d in props)
            //{
            //    n_prop p = (n_prop)d.Value;
            //    //only restore fields that exist in the backup
            //    if (!p.IsUniqueID)
            //    {
            //        if (nData.HasField(st, p.name))
            //        {
            //            if (!nTools.IsInArray(p.name, a))
            //            {
            //                if (Tools.Strings.StrExt(strSQL))
            //                    strSQL += ", ";
            //                strSQL += p.name;
            //                a.Add(p.Name);
            //            }
            //        }
            //    }
            //}
            //strSQL = "insert into " + x.xSys.xData.database_name + ".dbo.companycontact(unique_id, " + strSQL + ") select top 1 unique_id, " + strSQL + " from companycontact where unique_id = '" + s + "' and recall_type = 3";
            //if (x.xSys.recall_connection.Execute(strSQL))
            //{
            //    x.xSys.ThrowByKey("companycontact:" + s);
            //    x.TheLeader.Tell("Done.");
            //}
            //else
            //    x.TheLeader.Tell("The restore was not successful.");
        }
        public void SendCompanyNeedsVettingEmailAlert(ContextRz x, company customer, ordhed o, company unVettedVendor)
        {
            List<company> unvettedVendors = new List<company>() { unVettedVendor };
            SendCompanyNeedsVettingEmailAlert(x, customer, o, unvettedVendors);
        }

        public void SendCompanyNeedsVettingEmailAlert(ContextRz x, company customer, ordhed o, List<company> unVettedVendors)
        {
            string orderType = o.ordertype;
            string body = "The following companies need to be vetted for " + orderType + "# " + o.ordernumber + "(" + customer.companyname + ") <br /><br />";
            foreach (company c in unVettedVendors)
            {
                body += "<b>" + c.companyname + "</b><br />";
            }
            string subject = "Vendor(s) need to be vetted for Quote# " + o.ordernumber;
            string to = "sm_sourcing @sensiblemicro.com";
            if (x.xUser.name == "Kevin Till")
                to = "ktill@sensiblemicro.com";
            SystemLogic.Email.SendMail(SystemLogic.Email.EmailGroupAddress.RzAlert,to , subject, body);
        }

        public virtual bool IsContactBadAccount(ContextNM x, string strContactID, ref companycontact ct)
        {
            return false;
        }
        public virtual void ActsListInstanceFindContact(ContextRz context, ActSetup mnu)
        {
            //do nothing
        }
        //public virtual ArApInfo CalculateOutstandingBalance(ContextRz context, company c)
        //{
        //    ArApInfo a = new ArApInfo();
        //    if (c == null)
        //        throw new Exception("No company");

        //    string TempTable = "temp_" + Tools.Strings.GetNewID();
        //    string strSQL = "create table " + TempTable + " (";
        //    strSQL += " companyid varchar(255), ";
        //    strSQL += " companyname varchar(255), ";
        //    strSQL += " contact varchar(255), ";
        //    strSQL += " phone varchar(255), ";
        //    strSQL += " fax varchar(255), ";
        //    strSQL += " email varchar(255), ";
        //    strSQL += " is_locked bit, ";
        //    strSQL += " is_problem bit, ";
        //    strSQL += " is_pastdue bit, ";
        //    strSQL += " total_ap float, ";
        //    strSQL += " total_ar float ";
        //    strSQL += ") ";
        //    context.Execute(strSQL);

        //    strSQL = "insert into " + TempTable + " (companyid, companyname, contact, phone, fax, email, is_locked, is_problem, is_pastdue) ";
        //    //KT 4-4-2016 - the IsClosed Where is making this query return no results.  Removing as I test this feature
        //    strSQL += " select c.unique_id, c.companyname, c.primarycontact, c.primaryphone, c.primaryfax, c.primaryemailaddress, c.is_locked, c.is_problem, c.ispastdue from company c inner join ordhed o on o.base_company_uid = c.unique_id where o.ordertype in ('invoice', 'purchase', 'rma', 'vendrma') and isnull(o.isvoid, 0) = 0 and isnull(o.ispaid, 0) = 0 and o.outstandingamount > 0 ";
        //    //strSQL += " select c.unique_id, c.companyname, c.primarycontact, c.primaryphone, c.primaryfax, c.primaryemailaddress, c.is_locked, c.is_problem, c.ispastdue from company c inner join ordhed o on o.base_company_uid = c.unique_id where o.ordertype in ('invoice', 'purchase', 'rma', 'vendrma') and isnull(o.isclosed, 0) = 0 and isnull(o.isvoid, 0) = 0 and isnull(o.ispaid, 0) = 0 and o.outstandingamount > 0 ";

        //    strSQL += " and base_company_uid = '" + c.unique_id + "' ";
        //    strSQL += " group by c.unique_id, c.companyname, c.primarycontact, c.primaryphone, c.primaryfax, c.primaryemailaddress, c.is_locked, c.is_problem, c.ispastdue order by c.companyname";
        //    context.Execute(strSQL);
        //    //KT 4-4-2016 - again, isnull(isclosed, 0) = 0 is causing to return null, removing
        //    //strSQL = "update " + TempTable + " set total_ap = (select sum(isnull(outstandingamount, 0)) from ordhed o where o.base_company_uid = " + TempTable + ".companyid and o.ordertype in ('purchase', 'rma') and isnull(o.isclosed, 0) = 0 and isnull(o.isvoid, 0) = 0 and isnull(o.ispaid, 0) = 0 and o.outstandingamount > 0)";
        //    strSQL = "update " + TempTable + " set total_ap = (select sum(isnull(outstandingamount, 0)) from ordhed o where o.base_company_uid = " + TempTable + ".companyid and o.ordertype in ('purchase', 'rma') and isnull(o.isvoid, 0) = 0 and isnull(o.ispaid, 0) = 0 and o.outstandingamount > 0)";
        //    context.Execute(strSQL);

        //    //KT 4-4-2016 - again, isnull(isclosed, 0) = 0 is causing to return null, removing
        //    //strSQL = "update " + TempTable + " set total_ar = (select sum(isnull(outstandingamount, 0)) from ordhed o where o.base_company_uid = " + TempTable + ".companyid and o.ordertype in ('invoice', 'vendrma') and isnull(o.isclosed, 0) = 0 and isnull(o.isvoid, 0) = 0 and isnull(o.ispaid, 0) = 0 and o.outstandingamount > 0)";
        //    strSQL = "update " + TempTable + " set total_ar = (select sum(isnull(outstandingamount, 0)) from ordhed o where o.base_company_uid = " + TempTable + ".companyid and o.ordertype in ('invoice', 'vendrma') and isnull(o.isvoid, 0) = 0 and isnull(o.ispaid, 0) = 0 and o.outstandingamount > 0)";
        //    context.Execute(strSQL);

        //    a.OutstandingAR = context.SelectScalarDouble("select total_ar from " + TempTable + " where companyname = '" + c.companyname + "'");
        //    a.OutstandingAP = context.SelectScalarDouble("select total_ap from " + TempTable + " where companyname = '" + c.companyname + "'");
        //    context.Execute("drop table " + TempTable);
        //    return a;
        //}
        public double CalculateOutstandingBalance_Company(ContextRz context, company c, bool showAlert = false, string messagePrefix = "")
        {
            //KT Was using a hairy calc, now just referencing the outstandingbalance of the invoice                    


            //NEed to match the parameters from RzLogic's nSQL in TheView
            nSQL ns = new nSQL();
            ns.strWhere = "ordhed_invoice.ordertype = 'Invoice' and isnull(ordhed_invoice.isvoid, 0) = '0' and ordhed_invoice.base_company_uid = '" + c.unique_id + "' and  (  ((select o.outstandingamount from ordhed o where o.unique_id = ordhed_invoice.unique_id) > 0 ) ) ";
            ns.lngLimit = 0;
            ns.SubClauses = null;
            ns.IsAbsolute = true;
            ns.strClass = "ordhed_invoice";
            ns.strOrder = "ordhed_invoice.orderdate desc";

            DataTable dt = GetInvoiceTotalsDataTable(context, ns, "outstandingamount");



            //string messageTitle = "Current Outstanding Balance: $";
            string messageTitle = "Credit Details:" + Environment.NewLine + Environment.NewLine;
            //if (c == null)
            //    throw new Exception("No company");
            double totalOutstandingIvoiced = 0;
            double totalAvailableCredit = 0;
            double currentCreditAmount = c.creditascustomer;


            //Calculate total amount from the outstanding invoices
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    totalOutstandingIvoiced += nData.NullFilter_Double(dr["invoice_total"]);
                }
            }

            //Get the totalVailablecCredit (Remaining Credit Balance)
            totalAvailableCredit = currentCreditAmount - totalOutstandingIvoiced;

            string strInvoiceList = Environment.NewLine + "---------------" + Environment.NewLine; //spacer to differentiate the line details from the other messages
            if (showAlert)
            {
                //Compose the string for the message;
                foreach (DataRow row in dt.Rows)
                {
                    double amount = Convert.ToDouble(row["invoice_total"]);
                    strInvoiceList += "Invoice: " + row["ordernumber"].ToString();
                    strInvoiceList += " ($" + Tools.Number.MoneyFormat_2_6(amount) + ")";
                    strInvoiceList += Environment.NewLine;

                }


                if (!string.IsNullOrEmpty(messagePrefix))
                    messageTitle = messagePrefix + Environment.NewLine + messageTitle;



                string strCurrentCreditAmount = "Current Customer Credit: $" + Tools.Number.MoneyFormat_2_6(currentCreditAmount) + Environment.NewLine;
                string strTotalOutstandingInvoiceAmount = "Total Outstanding Invoice: $" + Tools.Number.MoneyFormat_2_6(totalOutstandingIvoiced) + Environment.NewLine;
                string strTotalAvailableCredit = "Total Available Credit: $" + Tools.Number.MoneyFormat_2_6(totalAvailableCredit) + Environment.NewLine;


                string message = messageTitle + strCurrentCreditAmount + strTotalOutstandingInvoiceAmount + strTotalAvailableCredit + strInvoiceList;
                context.Leader.Tell(message);
            }




            //TotalIvoiced = context.SelectScalarDouble("select SUM(outstandingamount) from ordhed_invoice where base_company_uid = '" + c.unique_id + "' and date_created > '1-1-2012' and orderreference NOT LIKE 'CR%'");
            //return TotalIvoiced;
            //nSQL s = "";
            //DataTable dt = GetInvoiceTotalsDataTable(context);
            //double TotalIvoiced = 0;
            //if (dt != null)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        TotalIvoiced += nData.NullFilter_Double(dr["invoice_total"]);
            //    }
            //}



            //if (c == null)
            //    throw new Exception("No company");
            //double TotalIvoiced = 0;
            //TotalIvoiced = context.SelectScalarDouble("select SUM(Outstanding)from(select ordernumber, ordertotal, Payment, ordertotal - payment[Outstanding] from(select ordernumber, ordertotal, isnull((select SUM(transamount) from checkpayment where base_ordhed_uid = ordhed_invoice.unique_id), 0)[Payment] from ordhed_invoice where base_company_uid = '" + c.unique_id + "' and date_created > '1-1-2012' and orderreference NOT LIKE 'CR%') a )b");
            return totalOutstandingIvoiced;
        }

        public DataTable GetInvoiceTotalsDataTable(ContextRz context, nSQL s, string field)
        {
            string sql = "select ordhed_invoice." + field + " as invoice_total,ordhed_invoice.ordernumber from ordhed_invoice inner join orddet_line on ordhed_invoice.unique_id = orddet_line.orderid_invoice or ordhed_invoice.unique_id = orddet_line.legacyid_invoice where ";
            sql += s.RenderSQL();
            sql += " and isnull(orddet_line.status,'') != 'Canceled' group by ordhed_invoice.ordernumber,ordhed_invoice." + field + " ";
            DataTable dt = context.Select(sql);
            return dt;
        }

        public double GetVendorCredits(ContextRz context, company c)
        {
            return context.SelectScalarDouble("select creditamount from companycredit where is_applied != 1 and base_company_uid = '" + c.unique_id + "'");
        }





        protected virtual void ActsListInstanceUseMergedQuotes(Context context, ActSetup mnu)
        {
            mnu.Add("New Order Batch");
            mnu.Add("New Purchasing Batch");
        }
        public override void ActsListInstance(Context context, ActSetup mnu)
        {
            ContextRz xrz = (ContextRz)context;

            base.ActsListInstance(context, mnu);
            if (!mnu.Has("Assign"))
            {
                if (CanAssign(xrz, mnu))
                    mnu.Add("Assign");
            }
            if (xrz.xUser.SuperUser)
                mnu.Add("Set Company Type");
            mnu.Add("Group");
            mnu.Add("Un-Group");
            mnu.Add("View Web Page");
            mnu.Add("Send E-Mail");
            mnu.Add("New Excess");


            //mnu.Add("Set Industry Segment");
            if (xrz.Logic.UseMergedQuotes)
                ActsListInstanceUseMergedQuotes(context, mnu);
            else
            {
                mnu.Add("New Order Batch");
                mnu.Add("New Formal Quote");
            }
            if (!xrz.Logic.UseMergedQuotes)
                mnu.Add("New Req");
            mnu.Add("New Quote");
            mnu.Add("New Bid");
            if (mnu.Multiple(context) && xrz.xUser.SuperUser)
                mnu.Add("Consolidate");
            mnu.Add("Scan/View Documents");
            if (xrz.xUser.SuperUser || xrz.CheckPermit(Permissions.ThePermits.SendCompaniesToQuickBooks)) //if (!x.CheckPermit(Permissions.ThePermits.AllowDNCBids))
            {
                //mnu.Add("Add As QB Customer");
                //mnu.Add("Add As QB Vendor");
                mnu.Add("Company to QB");
            }


            if (xrz.xUser.SuperUser || xrz.CheckPermit(Permissions.ThePermits.CanManageHubspot)) //if (!x.CheckPermit(Permissions.ThePermits.AllowDNCBids))
            {
                mnu.Add("Manage Hubspot");
            }

            if (xrz.xUser.SuperUser)
                mnu.Add("Line Card");

            if (xrz.Accounts.Enabled)
            {
                if (!mnu.Multiple(context))
                {
                    company c = (company)mnu.TheItems.FirstGet(context);
                    if (c != null)
                    {
                        if (c.iscustomer || c.balance_owed_customer > 0)
                            mnu.Add("Receive Customer Payment");
                    }
                }
            }
        }

        private bool CanAssign(ContextRz xrz, ActSetup mnu)
        {
            if (xrz.xUser.SuperUser)
                return true;

            //Allow Assign if they have the explicit permission.

            if (xrz.CheckPermit(Permissions.ThePermits.AssignCompanies))
                return true;
            foreach (company c in mnu.TheItems.AllGet(xrz))
            {
                //Allow Assing if the selected companies are owned by the user, the user's team captain, or house.
                if (!(xrz.xUser.unique_id == c.base_mc_user_uid || xrz.xUser.IsTeamCaptainOf(xrz, c.base_mc_user_uid) || c.agentname == "House"))
                    return false;
            }
            return true;
        }



        public virtual void ActsListInstanceContact(Context context, ActSetup mnu)
        {
            ContextRz xrz = (ContextRz)context;
            if (xrz.Logic.UseMergedQuotes)
            {
                mnu.Add("New Order Batch");
                mnu.Add("New Purchasing Batch");
                mnu.AddSeparator();
            }
            if (mnu.Multiple(context))
            {
                mnu.Add("Consolidate");
                //mnu.Add("Consolidation Request");
                mnu.Add("Line Card Request");
                mnu.Add("Infer First Names");
                mnu.AddSeparator();
            }
            if (xrz.xUser.SuperUser)
            {
                mnu.Add("Set As Primary Contact");
                mnu.Add("Send E-Mail");
                mnu.Add("Assign");
                if (xrz.xUser.SuperUser)
                    mnu.Add("Assign - Bad Record");
                mnu.Add("Group");
                ActsListInstanceGroupExtra(xrz, mnu);
                mnu.Add("Un-Group");
                if (xrz.xUser.SuperUser)
                {
                    mnu.AddSeparator();
                    mnu.Add("Mark as DIST");
                    mnu.Add("Mark as OEM");
                }
                mnu.AddSeparator();
                mnu.Add("Release");
                mnu.Add("Link To Company");
                mnu.Add("View Company");
                mnu.Add("View Domain");
                mnu.Add("Mailing Addresses");
                mnu.Add("Hot Part");
                ActsListInstanceFindContact(xrz, mnu);
                mnu.Add("Order Batch");
                mnu.Add("Find Duplicates");
                mnu.Add("Link New Company");

                mnu.AddSeparator();

            }

        }
        public virtual void ActsListInstanceCallLog(Context context, ActSetup mnu)
        {
            //do nothing.. override
        }
        public virtual void ActInstanceCallLog(Context context, ActArgs args)
        {
            //do nothing.. override
        }
        public virtual void ActsListInstanceCompanyAddress(Context context, ActSetup mnu)
        {
            mnu.Add("Print Label");
            mnu.Add("Copy Address");
            mnu.Add("Paste Address");
        }
        public virtual void ActInstanceCompanyAddress(Context context, ActArgs args)
        {
            //do nothing.. override
        }
        public virtual void ActsListInstanceShippingAccount(Context context, ActSetup mnu)
        {

        }
        public virtual void ActInstanceShippingAccount(Context context, ActArgs args)
        {
            //do nothing.. override
        }
        public virtual void ActsListInstanceContactNote(Context context, ActSetup mnu)
        {
            //do nothing.. override
        }
        public virtual void ActInstanceContactNote(Context context, ActArgs args)
        {
            //do nothing.. override
        }
        public override void ActInstance(Context context, ActArgs args)
        {
            ContextRz xrz = (ContextRz)context;

            ArrayList objects = new ArrayList();
            foreach (IItem i in args.TheItems.AllGet(context))
            {
                objects.Add(i);
            }
            switch (args.ActionName.Trim().ToLower())
            {
                case "setcompanytype":
                    SetCompanyType((ContextRz)context, objects);
                    break;
                //KT Refactored with RzSensible
                //case "setindustrysegment":
                //    SetIndustrySegment(objects);
                //    break;
                case "setindustrysegment":
                    company.SetIndustrySegment(xrz, args.TheItems.AllGet(context));
                    args.Handled = true;
                    break;
                case "settimezone":
                    company.SetTimeZone(xrz, objects);
                    break;
                case "consolidate":
                    Consolidate(xrz, objects);
                    break;
                case "assign":
                    Assign(xrz, objects);
                    break;
                case "group":
                    Group(xrz, objects, "company");
                    break;
                case "un-group":
                    Group(xrz, objects, true, "company", "");
                    break;
                case "managehubspot":
                    ShowHubspotManagementForm((ContextRz)context, objects);
                    break;


                default:
                    base.ActInstance(context, args);
                    break;
            }
        }

        private void ShowHubspotManagementForm(ContextRz context, ArrayList objects)
        {
            company.ManageHubspotLinkage(context, objects);
        }

        //KT Refactored from RzSensible
        public bool IsCompanyFinancialsVerified(Rz5.company c, Rz5.ordhed o)
        {
            if (c == null)
                return true;
            try
            {
                if (o.terms.ToLower().StartsWith("net"))
                    return ((Rz5.company)c).has_financials;
            }
            catch { }
            return true;
        }

        public bool IsCompanyFinancialsVerified(Rz5.company c, string terms)
        {
            if (c == null)
                return true;
            try
            {
                if (terms.ToLower().StartsWith("net"))
                    return ((Rz5.company)c).has_financials;
            }
            catch { }
            return true;
        }
        //KT Refactored from RzSensible
        private void CRM_Export_Click(Context x, ActArgs args)
        {
            string SQL = "select n_user.login_name as[LoginName],companycontact.primaryemailaddress as [ContactEmail],companycontact.companyname as [CompanyName],companycontact.contactname as [ContactName],n_user.name as [UserName],n_user.email_address as [UserEmail],n_user.job_desc as [UserTitle] from companycontact inner join company on companycontact.base_company_uid = company.unique_id inner join n_user on company.base_mc_user_uid = n_user.unique_id where isnull(companycontact.donotemail, 0) = 0 and isnull(company.donotemail, 0) = 0";
            DataTable dt = x.Select(SQL);
            if (dt == null)
                return;
            if (dt.Rows.Count <= 0)
                return;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("LoginName,ContactEmail,CompanyName,ContactFirstName,ContactLastName,UserName,UserEmail,UserTitle");  //,CompanyEmail
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(dr["LoginName"].ToString() + ",");
                //sb.Append(dr["CompanyEmail"].ToString() + ",");
                sb.Append(dr["ContactEmail"].ToString() + ",");
                sb.Append(dr["CompanyName"].ToString() + ",");
                string name = Tools.People.ContactNameClean(dr["ContactName"].ToString());
                name = Tools.People.ToProperCase(name);
                string first = Tools.Strings.ParseDelimit(name, " ", 1).Trim();
                string last = Tools.Strings.ParseDelimit(name, " ", 2).Trim();
                sb.Append(first + ",");
                sb.Append(last + ",");
                sb.Append(dr["UserName"].ToString() + ",");
                sb.Append(dr["UserEmail"].ToString() + ",");
                sb.AppendLine(dr["UserTitle"].ToString());
            }
            string folder = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath() + "Junk\\");
            if (!Tools.Folder.FolderExists(folder))
                Tools.Folder.MakeFolderExist(folder);
            string file = folder + Tools.Strings.GetNewID() + ".csv";
            Tools.Files.SaveFileAsString(file, sb.ToString());
            Tools.Files.OpenFileInDefaultViewer(file);
        }

        //KT - Moved from ViewCompany.cs - Since I'll need to call this from a few places.
        public bool CheckVetted(Context x, company c)
        {
            //are they already vetted?
            //bool vetted = n.is_vetted;
            bool originalVettedValue = c.is_vetted;
            //if so, perform re-vet routine
            if (c.is_vetted == true)
            {
                //has it been more than 365 days since they were vetted?
                if ((DateTime.Now - c.vetted_date.Date).TotalDays > 365)
                {
                    //If so, is there a last purchase date?                    
                    if (c.last_purchase_date.Date != null)
                    {
                        //if so, was that less than 365 days ago?
                        if ((DateTime.Now.Date - c.last_purchase_date.Date).TotalDays > 365)
                            c.is_vetted = false;
                    }
                }
            }
            if (c.is_vetted != originalVettedValue)
                c.Update(x);


            return c.is_vetted;

        }

        public bool CheckVendor(ContextRz x, company n, bool doAlert, bool alertonly)
        {
            bool allow = true;

            if (!CheckVendorApproved(x, n))
            {
                if (doAlert)
                    x.TheLeader.Tell(n.companyname + " is not on the AVL.  Please see management for resolution.");
                allow = false;
            }

            if (!CheckVetted(x, n))
            {
                if (doAlert)
                    x.Leader.Tell("It has been more than 365 days since " + n.companyname + " was vetted for purchasing.  You can still accept bids from them, but be advised, they will need to be re-vetted before we can issue a PO to them.");
                allow = false;
            }
            if (!CheckDNCVendor(x, n))
            {
                if (doAlert)
                    x.Leader.Tell(n.companyname + " is marked Do Not Call.  Please see management for resolution if you wish to poceed with this vendor.");
                allow = false;
            }
            //3-23-18 - Removing this, adding to Bidline instead.
            //if (n.problem_vendor)
            //{
            //    if (doAlert)
            //        x.TheLeader.Tell(n.companyname + " has been marked as a problem vendor.  Please check the company notes before completing this order.");
            //    allow = false;
            //}
            //ArApInfo a = CalculateOutstandingBalance(x, n);
            //if (a.OutstandingAR > 0)
            //{
            //    x.TheLeader.Tell("Please be aware that " + n.companyname + " owes us $"+a.OutstandingAR+"");
            //    if (alertonly)
            //        return true;
            //    else
            //        return false;
            //}

            if (!allow)
                if (alertonly)
                    allow = true;
            return allow;
        }

        public bool CheckVendorApproved(ContextRz x, company c)
        {
            //KT Refactored from RzSensible 3-17-2015
            if (c == null)
                return false;
            string msg = "";
            return c.VendorApprovedCheck(x, ref msg);
        }

        public bool CheckDNCVendor(ContextRz x, company n)
        {
            if (n.companytype.Contains("DNC"))
            {
                if (!x.CheckPermit(Permissions.ThePermits.AllowDNCBids))
                {
                    x.Leader.Tell("This company appears to be labeled as DNC.  Please consider using another vendor, or see management for an override.");
                    return false;
                }
                else
                {
                    if (!x.Leader.AskYesNo(n.companyname + " is on our DNC Vendor list and cannot be used for a bid without a management override.  Would you like to override this and allow the bid to be applied?"))
                        return false;
                    else
                        return true;
                }
            }

            else
                return true;
        }



        public virtual void ActContact(Rz5.ContextRz context, Core.ActArgs args)
        {
            ContextRz xrz = (ContextRz)context;

            ArrayList objects = new ArrayList();
            foreach (IItem i in args.TheItems.AllGet(context))
            {
                objects.Add(i);
            }
            ArrayList companynames;
            switch (args.ActionName.Trim().ToLower())
            {
                case "consolidate":
                    {
                        ConsolidateContacts(context, objects);
                        break;
                    }
                case "consolidationrequest":
                    companycontact.MakeConsolidationReminder((ContextRz)args.TheContext, objects);
                    args.Handled = true;
                    break;
                case "group":
                    company.Group((ContextNM)args.TheContext, objects, "companycontact");
                    args.Handled = true;
                    break;
                case "markcompanyasoem":
                    companynames = companycontact.GetUniqueCompanyNames(objects);
                    if (companynames.Count > 0)
                        company.UpdateCompanyOEM(xrz, companynames);
                    args.Handled = true;
                    break;
                case "markcompanyasdist":
                    companynames = companycontact.GetUniqueCompanyNames(objects);
                    if (companynames.Count > 0)
                        company.UpdateCompanyDIST(xrz, companynames);
                    args.Handled = true;
                    break;
                case "un-group":
                    company.Group(xrz, objects, true, "companycontact", "");
                    args.Handled = true;
                    break;
                case "markasdist":
                    companycontact.MarkType(context, objects, Enums.ContactType.DIST);
                    args.Handled = true;
                    break;
                case "markasoem":
                    companycontact.MarkType(context, objects, Enums.ContactType.OEM);
                    args.Handled = true;
                    break;
                case "assign":
                    companycontact.Assign(xrz, objects);
                    args.Handled = true;
                    break;
                case "assign-badrecord":
                    companycontact.AssignBadRecord(context, objects, null);
                    args.Handled = true;
                    break;
                case "release":
                    companycontact.Release(context, objects, null);
                    args.Handled = true;
                    break;
                case "mailingaddresses":
                    companycontact.ShowMailingAddresses(objects);
                    args.Handled = true;
                    break;
                case "linecardrequest":
                    context.Logic.HandleLineCardRequest(objects);
                    args.Handled = true;
                    break;
                case "inferfirstnames":
                    companycontact.InferFirstNames(objects);
                    args.Handled = true;
                    break;
                default:
                    base.ActInstance(context, args);
                    return;  //2011_10_23 changed this to break  //skips args.handled
            }
            //2011_10_23 removed
            //args.Handled = true;
        }
        public void SetCompanyType(ContextNM x, ArrayList a)
        {
            if (x == null)
                return;
            ((ILeaderRz)x.TheLeader).SetCompanyType((ContextRz)x, a);
        }
        public static void Consolidate(ContextRz context, ArrayList selectedObjects)
        {
            //ALl items must be companies, or contacts
            //If at the end company or contact list.cont == count of objectlist, then all items are of same valid type for consolidate
            List<company> compList = new List<company>();
            List<companycontact> contactList = new List<companycontact>();

            foreach (object o in selectedObjects)
            {
                //True being switched to false would indicated multiple object types (i.e. 1 company 1 contact) which is not valid.                
                if (o is company)
                {
                    if (!compList.Contains((company)o))
                        compList.Add((company)o);
                }

                else if (o is companycontact)
                {
                    if (!contactList.Contains((companycontact)o))
                        contactList.Add((companycontact)o);
                }

            }
            if (compList.Count == selectedObjects.Count)
                context.Leader.ConsolidateCompanies(context, selectedObjects);
            else if (contactList.Count == selectedObjects.Count)
                context.Leader.ConsolidateContacts(context, selectedObjects);
        }
        public virtual void SetIndustrySegment(ArrayList a)
        {
            //try
            //{
            //    if (a == null)
            //        return;
            //    if (a.Count <= 0)
            //        return;
            //    company comp = (company)a[0];
            //    if (comp == null)
            //        return;
            //    comp.GetIndustrySegmentChoice(a);
            //}
            //catch { }
        }
        public void Assign(ContextNM x, ArrayList companies)
        {
            if (x == null)
                return;
            ((ILeaderRz)x.TheLeader).AssignAgentShow((ContextRz)x, companies);
        }
        public void Group(ContextNM x, nObject c)
        {
            Group(x, c, false);
        }
        public void Group(ContextNM x, nObject c, String strGroup)
        {
            Group(x, c, false, strGroup);
        }
        public void Group(ContextNM x, nObject c, bool undo)
        {
            Group(x, c, undo, "");
        }
        public void Group(ContextNM x, nObject c, bool undo, String strGroup)
        {
            ArrayList a = new ArrayList();
            a.Add(c);
            Group(x, a, undo, c.ClassId, strGroup);
        }
        public void Group(ContextNM x, ArrayList cs, String strClassName)
        {
            Group(x, cs, false, strClassName, "");
        }
        public void Group(ContextNM x, ArrayList cs, String strClassName, String strGroup)
        {
            Group(x, cs, false, strClassName, strGroup);
        }
        public void Group(ContextNM x, ArrayList cs, bool undo, String strClass, String strGroup)
        {
            if (x == null)
                return;
            ((ILeaderRz)x.TheLeader).SetCompanyGroup((ContextRz)x, cs, undo, strClass, strGroup);
        }
        public override void ActsListStatic(Context x, ActSetup acts)
        {
            ActHandle h = null;
            //if (((n_sys_Rz4)((ContextRz)x).xSys).ThePermitLogic.CheckPermit(Permissions.ThePermits.NotSearchAllCompanies, ((ContextRz)x).xUser))
            //    return;
            h = new ActHandle(new Act("People", new ActHandler(PeopleSearchShow)));
            acts.Add(h);
            h.SubActs.Add(new ActHandle(new Act("New Company", new ActHandler(CompanyNewShow))));

            ContextRz xrz = (ContextRz)x;
            xrz.Leader.AddCompanyOptions(xrz, this, h);
        }
        public void PeopleSearchShow(ContextRz x)
        {
            PeopleSearchShow(x, new ActArgs());
        }
        public void PeopleSearchShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            if (!xrz.CheckPermit("Company:Search:Search Companies"))
            {
                x.TheLeader.ShowNoRight();
                args.Result(false);
                return;
            }

            xrz.TheLeaderRz.PeopleSearchShow(xrz, args);
        }
        public void CompanyNamesReCache(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            xrz.Logic.CacheCompanies(xrz);
            args.Result(true);
        }
        public void CompanyNewShow(Context x, ActArgs args)
        {
            company c = CompanyNewShow((ContextRz)x);
            args.Result(c != null);
        }
        //public virtual company AddNewCompany(ContextRz x, String strName, String strContact, String strPhone, String strFax, String strEmail)
        //{
        //    try
        //    {
        //        strName = x.Leader.NewCompanyNameGet(x, strName);
        //        if (!Tools.Strings.StrExt(strName))
        //            return null;
        //        company xCompany = company.New(x);
        //        xCompany.companyname = strName;



        //        //xCompany.base_mc_user_uid = x.xUser.unique_id;
        //        //xCompany.agentname = x.xUser.name;
        //        xCompany.isactive = true;
        //        xCompany.primarycontact = strContact;
        //        xCompany.primaryphone = strPhone;
        //        xCompany.primaryfax = strFax;
        //        xCompany.primaryemailaddress = strEmail;

        //        //KT New companies get assigned to the user who added it.
        //        if (!Tools.Strings.StrExt(xCompany.base_mc_user_uid))
        //        {
        //            xCompany.base_mc_user_uid = x.xUser.unique_id;
        //            xCompany.agentname = x.xUser.name;
        //        }


        //        //KT Added default TBD for new companies.
        //        xCompany.termsascustomer = "TBD";
        //        xCompany.termsasvendor = "TBD";
        //        xCompany.created_by_name = x.xUser.name;
        //        xCompany.created_by_uid = x.xUser.unique_id;
        //        xCompany.creditascustomer = 500;



        //        xCompany.Insert(x);
        //        if (!Tools.Strings.StrCmp(x.xUser.name, "Tim Savoy"))
        //            CompanyNamesReCache(x, new ActArgs());
        //        return xCompany;
        //    }
        //    catch { return null; }
        //}


        //private void DoAddCompany()
        //{
        //    try
        //    {
        //        company c = company.AddNew(RzWin.Context, Company);
        //        if (c != null)
        //        {

        //            ////KT Commented out my new changes.  New Companies SHOULD be in the users name that added for 60 days.
        //            ////KT Commented out the old logic (below) and auto-assing new companies to house.
        //            //c.base_mc_user_uid = "17a7e95b7bcb47b0a2501d422f899100";
        //            //c.agentname = "House"; 


        //            //KT New companies get assigned to the user who added it.
        //            if (!Tools.Strings.StrExt(c.base_mc_user_uid))
        //            {
        //                c.base_mc_user_uid = RzWin.User.unique_id;
        //                c.agentname = RzWin.User.name;
        //            }
        //            //KT Added default TBD for new companies.
        //            c.termsascustomer = "TBD";
        //            c.termsasvendor = "TBD";
        //            c.created_by_name = RzWin.User.name;
        //            c.created_by_uid = RzWin.User.unique_id;
        //            c.creditascustomer = 500;
        //            c.Update(RzWin.Context);
        //            RzWin.Context.Show(c);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}



        public virtual company CompanyNewShow(ContextRz x)
        {
            if (!x.CheckPermitAllowMissing("Company:Add:AddCompany"))
            {
                x.TheLeader.ShowNoRight();
                return null;
            }
            return x.TheLeaderRz.CompanyNewShow(x);
        }
        public virtual companycontact AddContact(ContextRz x, company comp)
        {
            return comp.ContactsVar.RefAddNew(x);
        }
        public virtual void SearchFor(ContextRz context, company cm, NewMethod.ListArgs.IGenericNotify notify)
        {
            context.TheLeaderRz.SearchForCompany(context, cm, notify);
        }
        public virtual PeopleSearchParameters PeopleSearchParametersCreate()
        {
            return new PeopleSearchParameters();
        }
        public virtual void GetConsolidationReminderUser(ContextRz context, ref string strID, ref string strName)
        {
            context.Reorg();
            //frmChooseUser.ChooseUserName(context.xSys, ref strID, ref strName, owner, RzApp.SalesPeople, false);
        }

        public static void ConsolidateContacts(ContextRz context, ArrayList arrContacts)
        {
            //List<companycontact> contacts = new List<companycontact>();


            //Ensure more than one selected
            if (arrContacts.Count <= 1)
            {
                context.Leader.Error("Not enough contacts selected to perform a merge operation.");
                return;
            }

            //Present A List of contacts to be merged, ask user to choose the main one
            companycontact keepContact = (companycontact)context.Leader.ChooseObjectFromCollection(context, arrContacts); //This will be the mremaining contact after teh merge, all other contact info should be in here at the end/

            //Check Null
            if (keepContact == null)
            {
                context.Leader.Error("Error retrieving the selected contact to merge with.");
                return;
            }

            //User Confirm
            if (!context.Leader.AskYesNo("Are you sure you want to merge these contacts into the following contact: " + Environment.NewLine + Environment.NewLine + keepContact.contactname))
            {
                context.Leader.Tell("Contact merge canceled.");
                return;
            }
            else
            {
                //Remove the Keep Contact from the arrayList of Merged Contacts
                arrContacts.Remove(keepContact);
            }
            context.TheLeader.StartPopStatus("Beginning contact merge operation.");

            //Do the merge for each contact
            foreach (companycontact mergeContact in arrContacts)
            {
                context.TheLeader.Comment("Merging contact:  " + mergeContact.contactname);
                ConsolidateContacts(context, keepContact, mergeContact);
            }

            context.TheLeader.Comment("Successfully merged contact(s) into:  " + keepContact.contactname);
            context.TheLeader.StopPopStatus(true);
        }

        private static void ConsolidateContacts(ContextRz context, companycontact keepContact, companycontact mergeContact)
        {
            //if (Tools.Strings.HasString(contact_ids.Replace(" ", ""), "''"))
            //{
            //    context.TheLeader.Tell("Blank unique IDs cannot be consolidated.");
            //    return;
            //}
            String strSQL = "";
            context.TheLeader.Comment("Creating temp tables ...");
            strSQL = "alter table req add contactid varchar(255)";
            context.TheData.TheConnection.Execute(strSQL, true);

            strSQL = "alter table calllog add contactid varchar(255)";
            context.TheData.TheConnection.Execute(strSQL, true);

            strSQL = "alter table contactnote add contactid varchar(255)";
            context.TheData.TheConnection.Execute(strSQL, true);

            strSQL = "alter table quote add contactid varchar(255)";
            context.TheData.TheConnection.Execute(strSQL, true);

            //call logs
            context.TheLeader.Comment("Merging call logs...");
            strSQL = "update calllog set base_companycontact_uid = '" + keepContact.unique_id + "', contactname = '" + context.TheData.Filter(keepContact.contactname) + "' where contactid= '" + mergeContact.unique_id + "' or base_companycontact_uid= '" + mergeContact.unique_id + "' ";
            context.Execute(strSQL);

            //contact notes
            context.TheLeader.Comment("Merging contact notes...");
            strSQL = "update contactnote set base_companycontact_uid = '" + keepContact.unique_id + "', contactname = '" + context.TheData.Filter(keepContact.contactname) + "' where contactid= '" + mergeContact.unique_id + "' or base_companycontact_uid= '" + mergeContact.unique_id + "' ";// "' where contactid in (" + contact_ids + ") or base_companycontact_uid in (" + contact_ids + ") ";
            context.Execute(strSQL);

            //reqs
            context.TheLeader.Comment("Merging reqs...");
            strSQL = "update req set base_companycontact_uid = '" + keepContact.unique_id + "', contactname = '" + context.TheData.Filter(keepContact.contactname) + "' where contactid= '" + mergeContact.unique_id + "' or base_companycontact_uid= '" + mergeContact.unique_id + "' "; //"' where contactid in (" + contact_ids + ") or base_companycontact_uid in (" + contact_ids + ") ";
            context.Execute(strSQL);

            //quotes
            context.TheLeader.Comment("Merging quotes...");
            strSQL = "update quote set base_companycontact_uid = '" + keepContact.unique_id + "', contactname = '" + context.TheData.Filter(keepContact.contactname) + "' where contactid= '" + mergeContact.unique_id + "' or base_companycontact_uid= '" + mergeContact.unique_id + "' "; //"' where contactid in (" + contact_ids + ") or base_companycontact_uid in (" + contact_ids + ") ";
            context.Execute(strSQL);

            //orders
            context.TheLeader.Comment("Merging orders...");
            ordhed.RunSQLOnOrderTables(context, "update <order table> set base_companycontact_uid = '" + keepContact.unique_id + "', contactname = '" + context.Filter(keepContact.contactname) + "' where base_companycontact_uid = '" + mergeContact.unique_id + "' ");

            //use the earliest create date
            context.TheLeader.Comment("Merging dates...");
            strSQL = "update companycontact set date_created = (select isnull(min(date_created), getdate()) from companycontact where unique_id = '" + keepContact.unique_id + "' OR unique_id = '" + mergeContact.unique_id + "')"; //in ( " + contact_ids + ", '" + unique_id + "' ) and date_created > cast('01/02/1900' as datetime)) where unique_id = '" + unique_id + "'";
            context.Execute(strSQL);

            //set modified date
            strSQL = "update companycontact set date_modified = (select isnull(min(date_modified), getdate()) from companycontact  where unique_id = '" + keepContact.unique_id + "' OR unique_id = '" + mergeContact.unique_id + "')"; // where unique_id in ( " + contactToMergeInto.unique_id + ", '" + mergedContact.unique_id + "' ) and date_modified > cast('01/02/1900' as datetime)) where unique_id = '" + contactToMergeInto.unique_id + "'";
            context.Execute(strSQL);

            //names
            context.TheLeader.Comment("Merging contact names ...");
            ArrayList names = context.TheData.SelectScalarArray("select distinct(isnull(contactname, '')) from companycontact where unique_id = '" + mergeContact.unique_id + "'");
            foreach (String sn in names)
            {
                if (Tools.Strings.StrExt(sn))
                {
                    if (!Tools.Strings.StrCmp(sn, keepContact.contactname) && !Tools.Strings.HasString(keepContact.alternate_names, "<" + sn + ">"))
                    {
                        keepContact.alternate_names += "<" + sn + ">";
                    }
                }
            }

            //emails
            context.TheLeader.Comment("Merging emails ....");
            ArrayList emails = context.TheData.SelectScalarArray("select distinct(isnull(primaryemailaddress, '')) from companycontact where unique_id = '" + mergeContact.unique_id + "'");
            foreach (String sn in emails)
            {
                if (Tools.Strings.StrExt(sn))
                {
                    if (!Tools.Strings.StrCmp(sn, keepContact.primaryemailaddress) && !Tools.Strings.HasString(keepContact.alternate_emails, "<" + sn + ">"))
                    {
                        keepContact.alternate_emails += "<" + sn + ">";
                    }
                }
            }

            //source
            context.TheLeader.Comment("Merging sources ....");
            ArrayList sources = context.TheData.SelectScalarArray("select distinct(isnull(source, '')) from companycontact where unique_id = '" + mergeContact.unique_id + "'");
            sources.Add(keepContact.source);
            String ss = Homogenize(sources);
            if (ss != keepContact.source)
                keepContact.source = ss;

            ////group
            //ArrayList groups = context.TheData.SelectScalarArray("select isnull(group_name, '') from companycontact where unique_id = '" + keepContact.unique_id + "' or unique_id = '" + mergedContact.unique_id + "'");
            //String sg = Homogenize(groups);
            //context.Execute("update companycontact set group_name = '" + context.Filter(sg) + "' where unique_id = '" + unique_id + "'");

            //ContactNotes
            ArrayList notes = context.TheData.SelectScalarArray("select isnull(contactnotes, '') from companycontact where unique_id <> '" + keepContact.unique_id + "' and unique_id = '" + mergeContact.unique_id + "'");
            foreach (String sn in notes)
            {
                keepContact.contactnotes += "\r\n" + sn;
            }

            //marketing addresses
            context.TheLeader.Comment("Merging mailing addresses ....");
            ArrayList addresses = context.TheData.SelectScalarArray("select isnull(line1, '') + '|' + isnull(line2, '') + '|' + isnull(line3, '') + '|' + isnull(adrcity, '') + '|' + isnull(adrstate, '') + '|' + isnull(adrzip, '') + '|' + isnull(adrcountry, '') from companycontact where unique_id = '" + mergeContact.unique_id + "' group by isnull(line1, '') + '|' + isnull(line2, '') + '|' + isnull(line3, '') + '|' + isnull(adrcity, '') + '|' + isnull(adrstate, '') + '|' + isnull(adrzip, '') + '|' + isnull(adrcountry, '') ");
            foreach (String address in addresses)
            {
                if (Tools.Strings.StrExt(address.Replace("|", "")))
                {
                    if (!keepContact.AddressContains(address))
                    {
                        if (keepContact.AddressHas)
                        {
                            if (keepContact.alternate_mailing_address != "")
                                keepContact.alternate_mailing_address += "\r\n";
                            keepContact.alternate_mailing_address += address;
                        }
                        else
                        {
                            String[] ary = Tools.Strings.Split(address, "|");
                            keepContact.line1 = ary[0];
                            keepContact.line2 = ary[1];
                            keepContact.line3 = ary[2];
                            keepContact.adrcity = ary[3];
                            keepContact.adrstate = ary[4];
                            keepContact.adrzip = ary[5];
                            keepContact.adrcountry = ary[6];
                        }
                    }
                }
            }

            keepContact.contactnotes += "\r\nMerged " + DateTime.Now.ToString();
            context.Update(keepContact);

            //deletes
            context.TheLeader.Comment("Deleting " + mergeContact.contactname);
            strSQL = "delete from companycontact where unique_id =  '" + mergeContact.unique_id + "'";
            context.Execute(strSQL);
            keepContact.CloseDeletedContactScreens(context, mergeContact.unique_id);
            context.TheLeader.Comment("Completed merge operation for " + mergeContact.contactname);
        }
        public static String Homogenize(ArrayList a)
        {
            String ret = "";
            foreach (String s in a)
            {
                String[] ary = Tools.Strings.Split(s, ",");
                foreach (String l in ary)
                {
                    if (Tools.Strings.StrExt(l))
                    {
                        if (!Tools.Strings.HasString(ret, "," + l + ","))
                        {
                            if (!ret.EndsWith(","))
                                ret += ",";

                            ret += l + ",";
                        }
                    }
                }
            }
            return ret;
        }

    }



    public class ArApInfo
    {
        public double OutstandingAR = 0;
        public double OutstandingAP = 0;
    }

    public class PeopleSearchShowArgs : ActArgs
    {
        public bool UseExisting = true;
    }



}
