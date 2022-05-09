using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Linq;

using Core;
using NewMethod;


namespace Rz5
{
    public partial class phonecall : phonecall_auto
    {
        //Public Static Functions
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;
            switch (args.ActionName.ToLower())
            {
                case "applyextrastuff":
                    xrz.TheLeader.StartPopStatus("Applying call info...");
                    ApplyExtraCallStuff(xrz, true);
                    xrz.TheLeader.StopPopStatus(true);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override void Updating(Context x)
        {
            ContextRz xrz = (ContextRz)x;
            strippedphone = GetFinalPhoneNumber(xrz, phonenumber);
            base.Updating(x);
        }
        public override string ToString()
        {
            switch (direction.ToLower().Trim())
            {
                case "in":
                    return "Call from " + phonenumber + " on " + nTools.DateFormat_ShortDateTime(calldate) + " to " + username + " for " + Tools.Dates.FormatHMS(duration);
                default:
                    return "Call to " + phonenumber + " on " + nTools.DateFormat_ShortDateTime(calldate) + " by " + username + " for " + Tools.Dates.FormatHMS(duration);
            }
        }
        //Public Functions
        public bool GrabAlternates()
        {
            return true;

            //no longer doing this; it just goes by the alternatephone table matching now
            //if( phonenumber.Length < 7 )
            //    return true;

            //String strLook = nTools.FilterPhoneNumber(phonenumber);

            //ArrayList a = context.SelectScalarArray("select phone from alternatephone where realphone = '" + strLook + "'");
            //ArrayList b = context.SelectScalarArray("select realphone from alternatephone where phone = '" + strLook + "'");
            //ArrayList c = context.SelectScalarArray("select strippedphone from companycontact where strippedalternatephone = '" + strLook + "'");
            //ArrayList d = context.SelectScalarArray("select strippedalternatephone from companycontact where strippedphone = '" + strLook + "'");

            //ArrayList all = nTools.GetUniqueStrings(a, b);
            //all = nTools.GetUniqueStrings(all, c);
            //all = nTools.GetUniqueStrings(all, d);

            //if (all.Count > 4)
            //    return false;

            //foreach (String s in all)
            //{
            //    PushAlternate(s);
            //}

            //return true;
        }

        public ArrayList GetStrippedNumbers()
        {
            ArrayList a = new ArrayList();

            if (Tools.Strings.StrExt(strippedphone))
                a.Add(strippedphone);

            //String s = nTools.StripPhoneNumber(alternate_1);
            //if( Tools.Strings.StrExt(s) )
            //    a.Add(s);

            //s = nTools.StripPhoneNumber(alternate_2);
            //if (Tools.Strings.StrExt(s))
            //    a.Add(s);

            //s = nTools.StripPhoneNumber(alternate_3);
            //if (Tools.Strings.StrExt(s))
            //    a.Add(s);

            //s = nTools.StripPhoneNumber(alternate_4);
            //if (Tools.Strings.StrExt(s))
            //    a.Add(s);

            return a;
        }

        public bool PushAlternate(String s)
        {
            return true;

            //if (!Tools.Strings.StrExt(s))
            //    return false;

            //if (!Tools.Strings.StrExt(alternate_1))
            //{
            //    alternate_1 = s;
            //    return true;
            //}

            //if (!Tools.Strings.StrExt(alternate_2))
            //{
            //    alternate_2 = s;
            //    return true;
            //}

            //if (!Tools.Strings.StrExt(alternate_3))
            //{
            //    alternate_3 = s;
            //    return true;
            //}

            //if (!Tools.Strings.StrExt(alternate_4))
            //{
            //    alternate_4 = s;
            //    return true;
            //}

            //if (!Tools.Strings.StrExt(alternate_5))
            //{
            //    alternate_5 = s;
            //    return true;
            //}

            //return false;
        }

        public String GetDescription()
        {
            String ret = "";

            if (Tools.Strings.StrCmp(direction, "in"))
                ret = "Call from ";
            else
                ret = "Call to ";

            ret += phonenumber;

            if (Tools.Strings.StrExt(contact) && Tools.Strings.StrExt(company))
            {
                ret += " " + contact + " at " + company;
            }
            else if (Tools.Strings.StrExt(contact))
            {
                ret += " " + contact;
            }
            else if (Tools.Strings.StrExt(company))
            {
                ret += " " + company;
            }

            ret += " for " + Tools.Dates.FormatHMS(duration);

            return ret;
        }

        //public static void InspectPhoneNumber(String strPhone)
        //{
        //    PhoneNumbers p = new PhoneNumbers();
        //    Rz3App.xMainForm.TabShow(p, "Phone Numbers");
        //    p.StartSearch(strPhone);
        //}

        public static String GetFinalPhoneNumber(ContextRz context, String s)
        {
            s = nTools.StripPhoneNumber(s);
            if (s.Length == 7)
                s = context.Logic.LocalAreaCode + s;

            //if (Rz3App.xLogic.IsCTG)
            //{
            //    String r = Rz3App.xSys.xData.GetScalar_String("select max(realphone) from alternatephone where phone = '" + s + "'");
            //    if (Tools.Strings.StrExt(r))
            //        return r;
            //    else
            //        return s;
            //}
            //else
            return s;
        }

        public static void AddAlternatePhone(ContextRz x, String real, String alternate, String desc)
        {
            AddAlternatePhone(x, real, alternate, desc, true);
        }

        public static void AddAlternatePhone(ContextRz context, String real, String alternate, String desc, bool extra)
        {
            String r = nTools.StripPhoneNumber(real);
            String a = nTools.StripPhoneNumber(alternate);

            if (r == a)
            {
                context.TheLeader.Comment("Numbers are the same");
                return;
            }

            if (!Tools.Strings.StrExt(r))
            {
                context.TheLeader.Comment("Blank real");
                return;
            }

            if (r.Length < 8)
            {
                context.TheLeader.Comment("Short real");
                return;
            }

            if (!Tools.Strings.StrExt(a))
            {
                context.TheLeader.Comment("Blank alternate");
                return;
            }

            if (a.Length < 8)
            {
                context.TheLeader.Comment("Short alternate");
                return;
            }

            if (context.StatementExists("select * from alternatephone where phone = '" + r + "' and realphone = '" + a + "'"))
            {
                context.TheLeader.Comment("The reverse already exists; cancelling.");
                return;
            }

            //see if the main number we're trying to add is already an alternate
            String m = context.SelectScalarString("select realphone from alternatephone where phone = '" + r + "'");
            if (Tools.Strings.StrExt(m))
            {
                context.TheLeader.Comment(r + " is already an alternate for " + m + " adding " + a + " -> " + m);
                AddAlternatePhone(context, m, a, desc + " calc", false);  //don't keep trying if this doesn't work
            }
            else
            {
                context.TheLeader.Comment("Adding " + a + " -> " + real);
                context.Execute("insert into alternatephone(unique_id, phone, description, realphone) values ('" + Tools.Strings.GetNewID() + "', '" + a + "', '" + context.Filter(desc + " " + DateTime.Now.ToString()) + "', '" + r + "')");
            }
        }
        public void ApplyExtraCallStuff(ContextRz context)
        {
            ApplyExtraCallStuff(context, false);
        }
        public void ApplyExtraCallStuff(ContextRz context, bool skip_activity)
        {
            NewMethod.n_user the_user = null;
            ArrayList a = context.QtC("n_user", "select * from n_user where  isnull(is_inactive, 0) = 0 and phone_ext = '" + callextension + "'");
            foreach (NewMethod.n_user u in a)
            {
                String server = u.GetSetting(context, "phone_server_name");
                if (!Tools.Strings.StrExt(server) || Tools.Strings.StrCmp(server, Environment.MachineName))
                {
                    the_user = u;
                }
            }

            if (the_user == null)
            {
                context.TheLeader.Comment("No linked user was found.");
                return;
            }

            ApplyExtraCallStuff(context, the_user, skip_activity);
        }

        //ArrayList a = Rz3App.xSys.QtC("n_user", "select * from n_user where isnull(is_inactive, 0) = 0 and isnull(phone_ext, '') > ''");
        //foreach(n_user u in a)
        //{
        //    String ss = u.GetSetting("phone_server_name");
        //    if (Tools.Strings.StrExt(ss))
        //    {
        //        if (!Tools.Strings.StrCmp(ss, Environment.MachineName))
        //            continue;
        //    }

        public void ApplyExtraCallStuff(ContextRz context, NewMethod.n_user u)
        {
            ApplyExtraCallStuff(context, u, false);
        }

        public void ApplyExtraCallStuff(ContextRz context, NewMethod.n_user u, bool skip_activity)
        {
            ContextRz xrz = (ContextRz)context;

            if (u != null)
                u.SetActivity(context);
            if (strippedphone.Length < 5)
            {
                context.TheLeader.Comment("no stripped numbers");
                stats_message = "no stripped numbers";
                context.Update(this);
                return;
            }
            //ok, this has to take the user into account
            String strUserWhere = ((SysRz5)context.xSys).ThePhoneLogic.GetExtraCallUserWhere(context, u);
            String contactwhere = " strippedphone = '" + strippedphone + "' or alternatephone_stripped like '%<" + strippedphone + ">%'";
            String strSQL = "select * from companycontact where " + contactwhere + strUserWhere;
            bool for_the_agent = true;
            context.TheLeader.Comment("Using SQL: " + strSQL);
            ArrayList Contacts = context.QtC("companycontact", strSQL);
            if (Contacts.Count == 0)
            {
                for_the_agent = false;
                strSQL = "select * from companycontact where " + contactwhere;
                context.TheLeader.Comment("Using 2nd SQL: " + strSQL);
                Contacts = context.QtC("companycontact", strSQL);
            }
            context.TheLeader.Comment("Contact count= " + Contacts.Count.ToString());
            if (Contacts.Count == 0)
            {
                stats_count = 0;
                stats_message = "No Contacts for " + strippedphone;
                context.TheLeader.Comment("No Contacts for " + strippedphone);
                is_customer = false;
                is_prospect = false;
                context.Update(this);
            }
            else if (!skip_activity)
            {
                //this needs to look at the contacts instead of going back to the database
                is_customer = (context.SelectScalarInt32("select count(*) from companycontact where unique_id in (" + nTools.GetIn_nObjects(Contacts) + ") and isnull(calc_sale_count, 0) > 0") > 0);
                is_prospect = (context.SelectScalarInt32("select count(*) from companycontact where unique_id in (" + nTools.GetIn_nObjects(Contacts) + ") and isnull(calc_fquote_count, 0) > 0") > 0);
                is_agent_customer = (context.SelectScalarInt32("select count(*) from companycontact where unique_id in (" + nTools.GetIn_nObjects(Contacts) + ") and isnull(calc_sale_count, 0) > 0 and base_mc_user_uid = '" + u.unique_id + "'") > 0);
                is_agent_prospect = (context.SelectScalarInt32("select count(*) from companycontact where unique_id in (" + nTools.GetIn_nObjects(Contacts) + ") and isnull(calc_fquote_count, 0) > 0 and base_mc_user_uid = '" + u.unique_id + "'") > 0);
                if (Contacts.Count < 4)
                {
                    ArrayList companynames = new ArrayList();
                    ArrayList contactnames = new ArrayList();
                    ArrayList companytypes = new ArrayList();
                    foreach (companycontact ct in Contacts)
                    {
                        if (ct != null)
                        {
                            ((SysRz5)context.xSys).ThePhoneLogic.SetFromCallList(context, u, ct, this);
                            if (Tools.Strings.StrExt(ct.companyname) && !companynames.Contains(ct.companyname.ToLower()))
                            {
                                companynames.Add(ct.companyname.ToLower());
                                if (Tools.Strings.StrExt(company))
                                    company += ", ";
                                company += ct.companyname;
                            }
                            if (Tools.Strings.StrExt(ct.contactname) && !companynames.Contains(ct.contactname.ToLower()))
                            {
                                contactnames.Add(ct.contactname.ToLower());
                                if (Tools.Strings.StrExt(contact))
                                    contact += ", ";
                                contact += ct.contactname;
                            }
                            String strType = nData.NullFilter_String(ct.IGet("abs_type"));
                            if (Tools.Strings.StrExt(strType) && !companytypes.Contains(strType.ToLower()))
                            {
                                companytypes.Add(strType.ToLower());
                                if (Tools.Strings.StrExt(abs_type))
                                    abs_type += ", ";
                                abs_type += strType.ToUpper();
                            }
                        }
                    }
                }
                else
                {
                    try
                    {
                        companycontact ct = (companycontact)Contacts[0];
                        company = "[M: " + Tools.Number.LongFormat(Contacts.Count) + "] " + ct.companyname;
                        contact = ct.contactname;
                        abs_type = nData.NullFilter_String(ct.IGet("abs_type"));
                    }
                    catch { }
                }
            }
            if (nTools.StripPhoneNumber(phonenumber).Length == 9)  //stripping the phone number chops internationals to 9 digits because of all their wacko prefixes
                is_international = true;
            //if( !skip_activity )
            //    user_activity.AddActivity((ContextRz)context, u.unique_id, "PhoneCall", GetDescription(), "phonecall", duration, (nObject)null);
            if (((SysRz5)context.xSys).ThePhoneLogic.ApplyExtraCallExit())
                return;
            email = GetBestEmail(Contacts);
            email_domain = nTools.ParseEmailDomain(email);
            email_suffix = nTools.ParseEmailSuffix(email);
            ////////////////////////////////////////////////////////
            //contacts for email matching
            strSQL = "select * from companycontact where " + contactwhere;
            context.TheLeader.Comment("for email: " + strSQL);
            ArrayList ContactsForEmail = context.QtC("companycontact", strSQL);
            ArrayList domains = new ArrayList();
            ArrayList suffixes = new ArrayList();
            foreach (companycontact c in ContactsForEmail)
            {
                if (nTools.IsEmailAddress(c.primaryemailaddress))
                {
                    String strDomain = nTools.ParseEmailDomain(c.primaryemailaddress);
                    if (!domains.Contains(strDomain))
                        domains.Add(strDomain);
                    String strSuffix = nTools.ParseEmailSuffix(c.primaryemailaddress);
                    if (!suffixes.Contains(strSuffix))
                        suffixes.Add(strSuffix);
                }
            }
            if (domains.Count > 0 && suffixes.Count > 0)
                is_priority_defense = context.StatementExists("select unique_id from domain where ( domain_name in( " + nTools.GetIn(domains) + " ) or domain_name in ( " + nTools.GetIn(suffixes) + " ) ) and isnull(is_priority_defense, 0) = 1");
            else
                is_priority_defense = false;
            if (!for_the_agent)
                this.alternate_1 = "x";
            long l = 0;
            String msg = "";
            if (Contacts.Count > 0)
            {
                strSQL = "update companycontact set calc_last_phonecall = getdate(), calc_phonecall_count = (isnull(calc_phonecall_count, 0) + 1) where unique_id in (" + nTools.GetIn_nObjects(Contacts) + ")";
                stats_message = strSQL;
                context.Execute(strSQL);
            }
            strSQL = "update ordhed_quote set calc_last_call = getdate() where strippedphone = '" + strippedphone + "' " + strUserWhere;
            if (Contacts.Count > 0)
                strSQL = "update ordhed_quote set calc_last_call = getdate() where ( strippedphone = '" + strippedphone + "' or base_companycontact_uid in (" + nTools.GetIn_nObjects(Contacts) + ") ) " + strUserWhere;
            stats_message += "\r\n\r\n" + strSQL;
            context.Execute(strSQL);

            xrz.Sys.ThePhoneLogic.ApplyExtraCallStuff(context, this, strippedphone, strUserWhere);          
            context.Update(this);
        }

        

        //just update the company and contact
        public void ApplyExtraCallStuffCompanyContact(ContextRz context)
        {
            try
            {
                String strIn = "";
                foreach (String s in GetStrippedNumbers())
                {
                    if (s.Length > 7)
                    {
                        if (Tools.Strings.StrExt(strIn))
                            strIn += ", ";
                        strIn += "'" + s + "'";
                    }
                }
                if (!Tools.Strings.StrExt(strIn))
                {
                    context.TheLeader.Comment("no stripped numbers");
                    stats_message = "no stripped numbers";
                    context.Update(this);
                    return;
                }
                String strSQL = "update companycontact set lastcalldate = getdate() where ( primaryphone in (" + strIn + ") or strippedphone in (" + strIn + ") ) ";
                context.Execute(strSQL);
                strSQL = "update company set last_call_date = getdate() where ( primaryphone in (" + strIn + ") or strippedphone in (" + strIn + ") ) ";
                context.Execute(strSQL);
                companycontact contact = (companycontact)context.QtO("companycontact", "select top 1 * from companycontact where ( primaryphone in (" + strIn + ") or strippedphone in (" + strIn + ") ) ");
                if (contact != null)
                {
                    this.companyname = contact.companyname;
                    this.company = contact.companyname;
                    this.contact = contact.contactname;

                    this.base_company_uid = contact.base_company_uid;
                }
                else
                {
                    company c = (company)context.QtO("company", "select top 1 * from company where ( primaryphone in (" + strIn + ") or strippedphone in (" + strIn + ") ) ");
                    if (c != null)
                    {
                        this.companyname = c.companyname;
                        this.company = c.companyname;
                        this.contact = c.primarycontact;

                        this.base_company_uid = c.unique_id;
                    }
                }
                context.Update(this);
            }
            catch (Exception callex)
            {
                context.TheLeader.Comment("ApplyExtraCallStuffCompanyContact error: " + callex.Message);
            }
        }


        String GetBestEmail(ArrayList contacts)
        {
            String ret = "";
            foreach (companycontact c in contacts)
            {
                if (nTools.IsEmailAddress(c.primaryemailaddress))
                    ret = c.primaryemailaddress;
            }
            return ret;
        }

        public static DataTable GetAlternates(ContextRz context, String strOriginal)
        {
            String strResult = phonecall.GetFinalPhoneNumber(context, strOriginal);
            return context.Select("select unique_id, realphone as [Main Number], phone as [Alternate Number], description as [Description] from alternatephone where phone in ('" + context.Filter(strOriginal) + "', '" + strResult + "') or realphone in ('" + context.Filter(strOriginal) + "', '" + strResult + "') order by realphone");
        }

        public static String GetNextAlternateConflict(ContextNM x)
        {
            return x.SelectScalarString("select top 1 a.realphone from alternatephone a inner join alternatephone b on a.realphone = b.phone order by a.realphone");
        }

        public static bool FixConflict(ContextRz context, String original)
        {
            if (original == null)
                return false;

            if (original.Length < 8)
                return false;

            //'original' is a realphone that is also an alternate somewhere in the table.

            //first, find the alternates that point to original as a real phone
            ArrayList a = context.SelectScalarArray("select phone from alternatephone where realphone = '" + original + "' order by phone");

            //then, find the real phone that original points to as an alternate
            String final = context.SelectScalarString("select max(realphone) from alternatephone where phone = '" + original + "'");

            if (a.Count == 0 || !Tools.Strings.StrExt(final))
            {
                context.TheLeader.Comment("Skipping " + original);
                return false;
            }

            context.TheLeader.Comment("Resolving " + a.Count.ToString() + " alternates to " + final + " for " + original);

            //erase the line where the original is the real phone
            context.Execute("delete from alternatephone where realphone = '" + original + "'");

            //take the first set, and make sure they point to the second number
            foreach (String s in a)
            {
                AddAlternatePhone(context, final, s, "Resolution " + nTools.DateFormat(DateTime.Now));
            }

            return true;
        }
    }

    public class PhoneReportArgs
    {
        public ArrayList UserIDs;
        public String ExtraSQL = "";
        public bool Descending;
        public bool OnlyCustomers;
        public bool OnlyProspects;
        public String Caption;
        public bool OnlyIn = false;
        public bool OnlyOut = false;
        public bool OnlyInfo = false;
        public bool OnlyOEM = false;
        public bool OnlyDist = false;

        public PhoneReportArgs(ArrayList ids, String extrasql, bool desc, bool only_customers, bool only_prospects, String caption, bool only_in, bool only_out, bool only_info, bool only_oem, bool only_dist)
        {
            UserIDs = ids;
            ExtraSQL = extrasql;
            Descending = desc;
            OnlyCustomers = only_customers;
            OnlyProspects = only_prospects;
            Caption = caption;
            OnlyIn = only_in;
            OnlyOut = only_out;
            OnlyInfo = only_info;
            OnlyOEM = only_oem;
            OnlyDist = only_dist;
        }
    }
    namespace Enums
    {
        public enum ReportSpan
        {
            Day = 1,
            Week = 2,
            Month = 3,
            Quarter = 4,
            Custom = 5,
        }
    }
}
