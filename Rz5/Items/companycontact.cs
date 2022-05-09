using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Tools;
using Core;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public partial class companycontact : companycontact_auto, IAssignedAgent
    {
        public VarRefSingle<companycontact, company> TheCompanyVar;

        public override Var VarGetByName(string name)
        {
            switch (name)
            {
                case "TheCompany":
                    return TheCompanyVar;
                default:
                    return base.VarGetByName(name);
            }
        }

        public override List<Var> VarsGetInitially()
        {
            List<Var> ret = base.VarsGetInitially();
            ret.Add(TheCompanyVar);
            return ret;
        }

        public String LinkedReminder = "";
        public String LinkedSession = "";

        //Constructor
        public companycontact()
        {
            TheCompanyVar = new VarRefSingle<companycontact, company>(this, new CoreVarRefSingleAttribute("TheCompany", "Rz4.companycontact", "Rz4.company", "Contacts", "base_company_uid"));
        }



        public static companycontact GetExample(ContextRz context)
        {
            return (companycontact)context.QtO("companycontact", "select top 1 * from companycontact where companyname > '' and contactname > '' and base_mc_user_uid > ''");
        }
        public static bool IsDistributorEmail(ContextRz context, String strAddress)
        {
            if (!nTools.IsEmailAddress(strAddress))
                return false;
            if (context.TheData.TheConnection.StatementExists("select unique_id from companycontact where abs_type = 'dist' and primaryemailaddress = '" + context.Filter(strAddress) + "'"))
                return true;
            String strDomain = nTools.ParseEmailDomain(strAddress);
            if (context.TheData.TheConnection.StatementExists("select * from domain where isnull(always_dist, 0) = 1 and domain_name = '" + context.Filter(strDomain) + "'"))
                return true;
            return false;
        }
        public static bool DoNotEmail(ContextRz context, String strAddress)
        {
            if (!nTools.IsEmailAddress(strAddress))
                return true;
            if (context.TheData.TheConnection.TableExists("unsubscribe"))
            {
                if (context.TheData.TheConnection.StatementExists("select emailaddress from unsubscribe where emailaddress = '" + context.Filter(strAddress) + "'"))
                    return true;
            }
            if (context.TheData.TheConnection.StatementExists("select unique_id from companycontact where primaryemailaddress = '" + context.Filter(strAddress) + "' and ( isnull(donotemail, 0) = 1 or isnull(bad_data, 0) = 1 or agentname = 'bad record' )"))
                return true;
            return false;
        }
        public static ArrayList GetUniqueDomains(ArrayList contacts)
        {
            ArrayList a = new ArrayList();
            foreach (companycontact c in contacts)
            {
                String d = nTools.ParseEmailDomain(c.primaryemailaddress);
                if (Tools.Strings.StrExt(d))
                {
                    if (!nTools.IsInArray(a, d))
                        a.Add(d);
                }
            }
            return a;
        }
        public static ArrayList GetUniqueCompanyNames(ArrayList contacts)
        {
            ArrayList a = new ArrayList();
            foreach (companycontact c in contacts)
            {
                String d = c.companyname;
                if (Tools.Strings.StrExt(d))
                {
                    if (!nTools.IsInArray(a, d))
                        a.Add(d);
                }
            }
            return a;
        }
        public static void Assign(ContextRz context, ArrayList contacts)
        {
            NewMethod.n_user u = context.TheLeaderRz.AskForUser(context.Logic.SalesPeople, false);
            if (u == null)
                return;
            context.TheLeader.StartPopStatus();
            context.TheLeader.Comment("Assigning...");
            foreach (companycontact c in contacts)
            {
                c.Assign(context, u.unique_id, true);
            }
            context.TheLeader.Comment("Done.");
            context.TheLeader.StopPopStatus(true);
        }

        public static void Release(ContextRz x, ArrayList contacts, System.Windows.Forms.IWin32Window owner)
        {
            List<object> objects = new List<object>();
            foreach (n_team tx in x.QtC("n_team", "select * from n_team order by name"))
            {
                objects.Add(tx);
            }

            n_team t = (n_team)x.TheLeader.ChooseFromObjects(objects);
            if (t == null)
                return;

            x.TheLeader.StartPopStatus();
            x.TheLeader.Comment("Releasing...");
            foreach (companycontact c in contacts)
            {
                c.Release(x, t);
            }
            x.TheLeader.Comment("Done.");
            x.TheLeader.StopPopStatus(true);
        }

        public static void AssignBadRecord(ContextRz x, ArrayList contacts, System.Windows.Forms.IWin32Window owner)
        {
            NewMethod.n_user u = n_user.GetByName(x, "Bad Record");
            if (u == null)
            {
                x.TheLeader.Tell("The 'Bad Record' user account could not be found.");
                return;
            }
            x.TheLeader.StartPopStatus();
            x.TheLeader.Comment("Assigning...");
            foreach (companycontact c in contacts)
            {
                c.Assign((ContextRz)x, u.unique_id, true);
            }
            x.TheLeader.Comment("Done.");
            x.TheLeader.StopPopStatus(true);
        }

        public static void MarkType(ContextNM x, ArrayList contacts, Enums.ContactType t)
        {
            MarkType(x, nTools.GetIDString(contacts), t);
        }
        public static void MarkType(ContextNM x, String strIDs, Enums.ContactType t)
        {
            x.TheLeader.Comment("Checking " + t.ToString() + "...");
            String strSQL = "select companyname, contactname, abs_type from companycontact where isnull(abs_type, '') != '' and isnull(abs_type, '') != '" + t.ToString().ToUpper() + "' and unique_id in (" + strIDs + ") order by companyname, contactname";
            DataTable d = x.Select(strSQL);
            if (Tools.Data.DataTableExists(d))
            {
                int i = 0;
                String summary = "Summary:\r\n";
                foreach (DataRow r in d.Rows)
                {
                    summary += nData.NullFilter_String(r["companyname"]) + "  " + nData.NullFilter_String(r["contactname"]) + "  " + nData.NullFilter_String(r["abs_type"]) + "\r\n";
                    if (i > 5)
                    {
                        summary += "...";
                        break;
                    }
                    i++;
                }

                if (!x.TheLeader.AreYouSure("mark these contacts as " + t.ToString().ToUpper() + " even though " + Tools.Number.LongFormat(d.Rows.Count) + " of them are already marked otherwise?"))
                    return;
            }

            x.TheLeader.Comment("Marking as " + t.ToString() + "...");
            strSQL = "update companycontact set abs_type = '" + t.ToString().ToUpper() + "' where unique_id in (" + strIDs + ")";
            long l = 0;
            x.TheData.TheConnection.Execute(strSQL, ref l);
            x.TheLeader.Comment("Marked " + Tools.Number.LongFormat(l) + " contact(s) as " + t.ToString().ToUpper());
            //x.xSys.NotifyClassChange("companycontact", false);
            x.TheLeader.Comment("Done.");
        }

        public static String GetEmailByID(ContextRz x, String strID)
        {
            return x.SelectScalarString("select primaryemailaddress from companycontact where unique_id = '" + strID + "'");
        }
        public static void FillIn(ContextRz x, nObject xObject, String strIDProp, String strNameProp, String strCompanyID)
        {
            if (!Tools.Strings.StrExt((String)xObject.IGet(strIDProp)) && Tools.Strings.StrExt((String)xObject.IGet(strNameProp)) && Tools.Strings.StrExt(strCompanyID))
                xObject.ISet(strIDProp, companycontact.TranslateNameToID(x, (String)xObject.IGet(strNameProp), strCompanyID));
            else if (!Tools.Strings.StrExt((String)xObject.IGet(strNameProp)) && Tools.Strings.StrExt((String)xObject.IGet(strIDProp)))
                xObject.ISet(strNameProp, companycontact.TranslateIDToName(x, (String)xObject.IGet(strIDProp)));
        }
        public static String TranslateIDToName(ContextRz x, String strID)
        {
            return x.SelectScalarString("select contactname from companycontact where unique_id = '" + x.Filter(strID) + "'");
        }
        public static String TranslateNameToID(ContextRz x, String strName, String strCompanyID)
        {
            if (!Tools.Strings.StrExt(strCompanyID))
                return "";
            return x.SelectScalarString("select unique_id from companycontact where base_company_uid = '" + strCompanyID + "' and contactname = '" + x.Filter(strName) + "'");
        }
        public static companycontact GetByEmailAddress(ContextRz x, String strAddress)
        {
            if (!Tools.Email.IsEmailAddress(strAddress))
                return null;
            return (companycontact)x.QtO("companycontact", "select top 1 * from companycontact where primaryemailaddress = '" + x.Filter(strAddress) + "'");
        }

        public static companycontact GetByDistilledName(ContextRz x, String strName, String id)
        {
            return (companycontact)x.QtO("companycontact", "select top 1 * from companycontact where base_company_uid = '" + id + "' and distilledcontact = '" + x.Filter(companycontact.DistillContactName(strName)) + "'");
        }

        public static companycontact GetByName(ContextRz x, String strName, String id)
        {
            return (companycontact)x.QtO("companycontact", "select top 1 * from companycontact where base_company_uid = '" + id + "' and contactname = '" + x.Filter(strName) + "'");
        }

        public static void SetContactObject(nObject xObject, companycontact value, String strCompanyIDField, String strCompanyNameField, String strContactIDField, String strContactNameField)
        {
            try
            {
                companycontact c = (companycontact)value;
                if (c == null)
                {
                    xObject.ISet(strContactIDField, "");
                    xObject.ISet(strContactNameField, "");
                }
                else
                {
                    if (Tools.Strings.StrExt((String)xObject.IGet(strCompanyIDField)) && !Tools.Strings.StrCmp((String)xObject.IGet(strCompanyIDField), value.base_company_uid))
                    {
                        throw new Exception("Plase set this item's company reference first.");
                        return;
                    }
                    xObject.ISet(strCompanyIDField, value.base_company_uid);
                    xObject.ISet(strCompanyNameField, value.companyname);
                    xObject.ISet(strContactIDField, value.unique_id);
                    xObject.ISet(strContactNameField, value.contactname);
                }
            }
            catch (Exception)
            {
            }
        }
        public static void ShowMailingAddresses(ArrayList a)
        {
            try
            {
                String s = "c:\\x" + Tools.Strings.GetNewID() + ".csv";
                System.IO.StreamWriter file = new System.IO.StreamWriter(s, false);
                foreach (companycontact c in a)
                {
                    file.WriteLine(c.GetCSVAddress());
                }
                file.Close();
                Tools.Files.OpenFileInDefaultViewer(s);
            }
            catch (Exception)
            {
            }
        }
        public static void GetRandomInfo(ContextRz context, ref String strID, ref String strName, String strCompanyID)
        {
            strID = "";
            strName = "";
            try
            {
                DataTable t = context.Select("select contactname, unique_id from companycontact where base_company_uid = '" + strCompanyID + "'");
                Int32 i = RandomProvider.Next(0, t.Rows.Count - 1);
                DataRow r = t.Rows[i];
                strID = (String)r[1];
                strName = (String)r[0];
            }
            catch (Exception)
            {
            }
        }
        public static String DistillContactName(String s)
        {
            //remove double spaces
            while (Tools.Strings.HasString(s, "  "))
                s = s.Replace("  ", " ");
            s = nTools.ChopFront(s, "mr. ");
            s = nTools.ChopFront(s, "mr ");
            s = nTools.ChopFront(s, "mrs ");
            s = nTools.ChopFront(s, "mrs. ");
            s = nTools.ChopFront(s, "mrs. ");
            s = nTools.ChopFront(s, "dr. ");
            s = nTools.ChopFront(s, "dr ");
            return s.Replace(" ", "");
        }
        public static void AddCompetition(ContextRz context, String s, ArrayList a)
        {
            foreach (companycontact c in a)
            {
                c.AddCompetition(context, s);
            }
        }

        //ViewContact Args
        public ListArgs ContactOrdersArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.AddAllow = false;
            ret.TheTable = "ordhed";
            ret.TheClass = "ordhed";
            ret.TheWhere = "base_company_uid = '" + base_company_uid + "'";
            ret.TheTemplate = "COMPANYORDERS";
            ret.TheOrder = "orderdate desc";
            ret.TheLimit = 100;
            ret.TheCaption = "Orders";
            //ret.AddAllow = true;
            //ret.AddCaptions.Add("New Quote");
            //ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=companycontact&action=newformalquote");
            //ret.AddCaptions.Add("New SalesOrder");
            //ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=companycontact&action=new_sales");
            //ret.AddCaptions.Add("New Invoice");
            //ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=companycontact&action=new_invoice");
            //ret.AddCaptions.Add("New PurchaseOrder");
            //ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=companycontact&action=new_purchase");
            return ret;
        }
        public ListArgs ContactNotesArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "contactnote";
            ret.TheClass = "contactnote";
            ret.TheWhere = " (base_companycontact_uid = '" + unique_id + "' or (base_company_uid = '" + base_company_uid + "' and isnull(contactname, '') > '' and contactname = '" + x.Filter(contactname) + "')) and ISACCOUNTING = 0";
            ret.TheTemplate = "companynotes";
            ret.TheOrder = "NOTEDATE DESC";
            ret.TheLimit = 100;
            ret.AddAllow = true;
            ret.AddCaption = "Add A New Note";
            ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=companycontact&action=newnote");
            ret.TheCaption = "Notes";
            return ret;
        }
        public ListArgs ContactReqsArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            string template = "";
            string classname = "";
            string where = "";
            string order = "";
            if (((RzLogic)x.TheLogic).UseMergedQuotes)
            {
                template = "contact-orderbatches";
                classname = "dealheader";
                where = "unique_id in (select the_dealheader_uid from dealcompany where the_companycontact_uid = '" + unique_id + "')";
                order = "date_created desc";
            }
            else
            {
                template = "contact-reqs";
                classname = "req";
                where = "base_companycontact_uid = '" + unique_id + "'";
                order = "datecreated desc";
            }
            ret.TheTable = classname;
            ret.TheClass = classname;
            ret.TheWhere = where;
            ret.TheTemplate = template;
            ret.TheOrder = order;
            ret.TheLimit = 100;

            ret.AddAllow = true;
            ret.AddCaption = "Add A New Req";
            ret.TheCaption = "Reqs";

            return ret;
        }
        public ListArgs ContactQuotesArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            string template = "";
            string classname = "";
            string where = "";
            string order = "";
            if (((RzLogic)x.TheLogic).UseMergedQuotes)
            {
                template = "COMPANYFORMALQUOTES";
                classname = "orddet_quote";
                where = "(orddet_quote.base_companycontact_uid = '" + x.Filter(unique_id) + "' or orddet_quote.base_ordhed_uid in (select unique_id from ordhed_quote where ordhed_quote.base_companycontact_uid = '" + unique_id + "')) and (isnull(orddet_quote.quantityordered,0) > 0 and isnull(orddet_quote.unitprice,0) > 0)";
                order = "orderdate desc";
            }
            else
            {
                template = "COMPANYQUOTES";
                classname = "quote";
                where = "quotetype = 'giving out' and base_companycontact_uid = '" + unique_id + "'";
                order = "quotedate desc";
            }
            ret.TheTable = classname;
            ret.TheClass = classname;
            ret.TheWhere = where;
            ret.TheTemplate = template;
            ret.TheOrder = order;
            ret.TheLimit = 100;

            ret.AddAllow = true;
            ret.AddCaption = "Add A New Quote";
            ret.TheCaption = "Quotes";

            return ret;
        }
        public ListArgs ContactBidsArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.AddAllow = false;
            string template = "";
            string classname = "";
            string where = "";
            string order = "";
            if (((RzLogic)x.TheLogic).UseMergedQuotes)
            {
                template = "COMPANYQUOTES1";
                classname = "orddet_rfq";
                where = " base_companycontact_uid = '" + unique_id + "'";
                order = "orderdate desc";
            }
            else
            {
                template = "COMPANYQUOTES";
                classname = "quote";
                where = "quotetype = 'receiving' and base_companycontact_uid = '" + unique_id + "'";
                order = "quotedate desc";
            }
            ret.TheTable = classname;
            ret.TheClass = classname;
            ret.TheWhere = where;
            ret.TheTemplate = template;
            ret.TheOrder = order;
            ret.TheLimit = 100;
            ret.TheCaption = "Bids";
            return ret;
        }
        public ListArgs ContactCallLogsArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "calllog";
            ret.TheClass = "calllog";
            ret.TheWhere = "base_companycontact_uid = '" + unique_id + "'";
            ret.TheTemplate = "calllog";
            ret.TheOrder = "DATECALL DESC";
            ret.TheLimit = 100;
            ret.AddAllow = true;
            ret.AddCaption = "Add A New Call Log";
            ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=companycontact&action=newcalllog");
            ret.TheCaption = "Call Logs";
            return ret;
        }

        //Public Virtual Functions
        public virtual String GetCSVAddress()
        {
            return "\"" + companyname.Replace("\"", "") + "\",\"" + contactname.Replace("\"", "") + "\"";
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;
            ArrayList objects = new ArrayList();
            switch (args.ActionName.ToLower().Trim())
            {
                case "reqsessions":
                    ShowReqSessionsWeb(xrz);
                    break;
                case "newquote":
                    ShowNewOrder(xrz, Enums.OrderType.Quote);
                    args.Handled = true;
                    break;
                case "newbid":
                    ShowNewOrder(xrz, Enums.OrderType.RFQ);
                    args.Handled = true;
                    break;
                case "new_purchase":
                    ShowNewOrder(xrz, Enums.OrderType.Purchase);
                    break;
                case "new_invoice":
                    ShowNewOrder(xrz, Enums.OrderType.Invoice);
                    break;
                case "new_sales":
                    ShowNewOrder(xrz, Enums.OrderType.Sales);
                    break;
                case "newformalquote":
                    ShowNewOrder(xrz, Enums.OrderType.Quote);
                    break;
                case "newcalllog":
                    ShowNewCallLog(xrz);
                    break;
                case "newnote":
                    ShowNewNote(xrz);
                    break;
                case "creditrequestform":
                    PrintCreditRequestForm(xrz);
                    break;
                case "viewhistory":
                    DoAction_ViewHistory();
                    break;
                case "viewcompany":
                    ViewCompany(xrz);
                    args.Handled = true;
                    break;
                case "assign":
                    Assign(xrz, "", false);
                    break;                
                case "assign-badrecord":
                    objects.Add(this);
                    AssignBadRecord(xrz, objects, null);
                    break;
                case "popqb":
                    throw new NotImplementedException("CompanyContact.PopQB");
                case "sende-mail":
                case "sendemail":
                    SendEmail(xrz);
                    break;
                case "linktonewcompany":
                case "linknewcompany":
                    LinkToNewCompany(xrz);
                    break;
                case "linktocompany":
                    LinkToCompany(xrz);
                    break;
                case "viewdomain":
                    ViewDomain(xrz);
                    break;
                case "group":
                    company.Group(xrz, this);
                    break;
                case "markcompanyasoem":
                    company.UpdateCompanyOEM(xrz, companyname);
                    args.Handled = true;
                    break;
                case "markcompanyasdist":
                    company.UpdateCompanyDIST(xrz, companyname);
                    args.Handled = true;
                    break;
                case "un-group":
                    company.Group(xrz, this, true);
                    break;

                case "hotpart":
                    xrz.Logic.NewHotPart(xrz, null, this, "");
                    break;
                case "neworderbatch":
                    dealheader.ShowManualDeal(xrz, this.TheCompanyVar.RefGet(args.TheContext), this);
                    args.Handled = true;
                    break;
                //case "findduplicates":
                //    FindDuplicates(xrz);
                //    break;
                case "orderbatch":
                    ShowNewOrderBatch(xrz);
                    args.Handled = true;
                    break;
                case "checkwww.dnb.com":
                    company.CheckDnB(xrz, companyname, adrstate);
                    break;
                case "setasprimarycontact":
                    company c = TheCompanyVar.RefGet(args.TheContext);
                    if (c == null)
                    {
                        args.TheContext.TheLeader.Tell(ToString() + " is not linked to a company");
                        return;
                    }
                    xrz.Execute("update companycontact set is_primary = 0 where base_company_uid = '" + this.base_company_uid + "'");
                    c.primarycontact = this.contactname;
                    c.primaryphone = this.primaryphone;
                    c.primaryfax = this.primaryfax;
                    c.primaryemailaddress = this.primaryemailaddress;
                    xrz.Update(c);
                    this.is_primary = true;
                    xrz.Update(this);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }



        public contactnote AddNewNote(ContextRz x)
        {
            contactnote c = contactnote.New(x);
            c.base_company_uid = this.base_company_uid;
            c.companyname = this.companyname;
            c.base_companycontact_uid = this.unique_id;
            c.contactname = this.contactname;
            c.agentname = x.xUser.name;
            c.base_mc_user_uid = x.xUser.unique_id;
            c.notedate = DateTime.Now;
            x.Insert(c);
            return c;
        }
        public contactnote ShowNewNote(ContextRz x)
        {
            contactnote n = AddNewNote(x);
            x.Show(n);
            return n;
        }
        public calllog AddCallLog(ContextNM x)
        {
            calllog c = calllog.New(x);
            c.base_company_uid = this.base_company_uid;
            c.callcompanyname = this.companyname;
            c.base_companycontact_uid = this.unique_id;
            c.contactname = this.contactname;
            c.agentname = x.xUser.name;
            c.base_mc_user_uid = x.xUser.unique_id;
            c.calldate = DateTime.Now.ToString();
            c.callorder = x.SelectScalarInt64("select count(*) from calllog where base_company_uid = '" + this.base_company_uid + "' and base_companycontact_uid = '" + this.unique_id + "'") + 1;
            x.Insert(c);
            return c;
        }
        public calllog ShowNewCallLog(ContextNM x)
        {
            calllog n = AddCallLog(x);
            x.Show(n);
            return n;
        }
        public void ShowReqSessionsWeb(ContextNM x)
        {
            //Core.ShowArgs a = new Core.ShowArgs(Core.ViewType.SingleItem);
            //a.AdditionalIDs = new Dictionary<string, string>();
            //a.AdditionalIDs.Add("contact_uid", unique_id);
            //x.Show(new req(x.xSys), a);
        }
        public ordhed AddOrder(ContextRz context, Enums.OrderType type)
        {
            ordhed o = ordhed.CreateNew(context, type);
            o.AbsorbCompany(context, this.TheCompanyVar.RefGet(context));
            o.AbsorbContact(context, this);
            context.Update(o);
            return o;
        }
        public ordhed ShowNewOrder(ContextRz x, Enums.OrderType type)
        {
            ordhed o = AddOrder(x, type);
            x.Show(o);
            return o;
        }

        public override string ToString()
        {
            return "[" + primaryemailaddress + "] {" + agentname + "} " + contactname + " at " + companyname;
        }

        public override void Inserting(Context x)
        {
            datecreated = DateTime.Now;
            datemodified = DateTime.Now;
            if (!Tools.Strings.StrExt(base_mc_user_uid))
                base_mc_user_uid = ((ContextRz)x).xUser.unique_id;
            base.Inserting(x);
        }
        protected virtual void BeforeUpdateCheckCompanyName(ContextRz context)
        {
            String s = company.TranslateIDToName(context, base_company_uid);
            if (Tools.Strings.StrExt(s) && !Tools.Strings.StrCmp(s, companyname))
                companyname = s;
        }

        public override void Updating(Context context)
        {
            ContextRz xrz = (ContextRz)context;

            datemodified = DateTime.Now;
            DistillEverything(xrz);
            email_domain = nTools.ParseEmailDomain(primaryemailaddress);
            email_suffix = nTools.ParseEmailSuffix(primaryemailaddress);
            NewMethod.n_user.FillIn((ContextRz)context, this, "base_mc_user_uid", "agentname");
            BeforeUpdateCheckCompanyName((ContextRz)context);
            if (xrz.Logic.UpperCaseEverything)
            {
                companyname = companyname.ToUpper();
                primaryphone = primaryphone.ToUpper();
                contactname = contactname.ToUpper();
            }

            String fn = Tools.Strings.NiceFormat(Tools.People.FirstNameParse(contactname));
            if (first_name != fn)
                first_name = fn;

            base.Updating(context);
        }
        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return ((Rz5.PermitLogic)(context.xSys).ThePermitLogic).CanBeViewedByContact((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return ((Rz5.PermitLogic)(context.xSys).ThePermitLogic).CanBeEditedByContact((ContextRz)context, this, context.xUser);
        }
        public override String GetClipHTML(ContextNM context)
        {
            String s = GetClipHeader(context);
            s += GetClipLine_Big(context, "contactname");
            s += GetClipLine(context, "companyname", "Company");
            s += GetClipLine_Phone("primaryphone", "primaryphoneextension", "Phone");
            s += GetClipLine(context, "primaryfax", "Fax");
            s += GetClipLine_Email("primaryemailaddress");
            s += context.xSys.GetHTMLList_SQL(context, "Quick Quotes", "quote", "select top 100 unique_id, quotedate, fullpartnumber, quotequantity, quoteprice from quote where quotetype = 'giving out' and base_companycontact_uid = '" + unique_id + "' order by quotedate desc");
            s += context.xSys.GetHTMLList_SQL(context, "Formal Quotes", "ordhed", "select top 100 ordhed.unique_id, ordhed.orderdate, orddet.fullpartnumber, orddet.quantityordered, orddet.unitprice from ordhed inner join orddet on orddet.base_ordhed_uid = ordhed.unique_id and ordhed.ordertype = 'quote' and ordhed.base_companycontact_uid = '" + unique_id + "' order by ordhed.orderdate desc");
            return s;
        }
        //Public Functions
        public void PrintCreditRequestForm(ContextRz context)
        {
            try
            {
                ordhed o = new ordhed();
                o.companyname = companyname;
                o.contactname = contactname;
                o.primaryphone = primaryphone;
                o.primaryfax = primaryfax;
                o.primaryemailaddress = primaryemailaddress;
                o.base_company_uid = base_company_uid;
                o.base_companycontact_uid = unique_id;
                o.base_mc_user_uid = base_mc_user_uid;
                o.agentname = agentname;
                o.OrderType = Enums.OrderType.Invoice;
                o.Print(context);
            }
            catch { }
        }
        //public company GetCompanyObject()
        //{
        //    return company.GetByID(xSys, base_company_uid);
        //}

        public contactnote GetNewNote(ContextRz x)
        {
            contactnote c = null;
            company comp = TheCompanyVar.RefGet(x);
            if (comp == null)
                comp = company.GetById(x, this.base_company_uid);
            if (comp == null)
            {
                c = contactnote.New(x);
                c.base_company_uid = this.base_company_uid;
                c.companyname = this.companyname;
                c.Insert(x);
            }
            else
                c = comp.CreateNewContactNote(x);  //this updates the company activity info
            c.base_companycontact_uid = this.unique_id;
            c.contactname = this.contactname;
            c.notedate = System.DateTime.Now;
            c.base_mc_user_uid = x.xUser.unique_id;
            c.agentname = x.xUser.name;
            c.Update(x);
            return c;
        }
        public String UserID
        {
            get
            {
                return base_mc_user_uid;
            }
            set
            {
                base_mc_user_uid = value;
            }
        }
        public String UserName
        {
            get
            {
                return agentname;
            }
            set
            {
                agentname = value;
            }
        }
        public n_user UserObjectGet(ContextRz context)
        {
            return n_user.GetById(context, base_mc_user_uid);
        }

        public void UserObjectSet(n_user value)
        {
            if (value == null)
            {
                base_mc_user_uid = "";
                agentname = "";
            }
            else
            {
                base_mc_user_uid = value.unique_id;
                agentname = value.name;
            }
        }
        public virtual bool Assign(ContextRz context, String strUserID, bool boolStatusOnly)
        {
            String strID = "";
            if ((!context.xUser.SuperUser) && Tools.Strings.StrCmp(Tools.Strings.Left(agentname, 5), "team:"))
            {
                if (!context.xUser.IsTeamMember(context, nTools.Trim(Tools.Strings.Mid(agentname, 6))))
                {
                    if (boolStatusOnly)
                        context.TheLeader.Comment(contactname + " is assigned to " + nTools.Trim(Tools.Strings.Mid(agentname, 6)) + ".");
                    else
                        context.TheLeader.Tell(contactname + " is assigned to " + nTools.Trim(Tools.Strings.Mid(agentname, 6)) + ".");
                    return false;
                }
            }
            if ((!context.xUser.SuperUser) && Tools.Strings.StrExt(base_mc_user_uid))
            {
                if (!Tools.Strings.StrCmp(context.xUser.unique_id, base_mc_user_uid))
                {
                    ArrayList colHold = context.xUser.GetCaptainUsers(context);
                    bool boolIn = false;
                    if (colHold != null)
                    {
                        foreach (NewMethod.n_user yUser in colHold)
                        {
                            if (Tools.Strings.StrCmp(yUser.unique_id, base_mc_user_uid))
                                boolIn = true;
                        }
                    }

                    if (!boolIn)
                    {
                        if (boolStatusOnly)
                            context.TheLeader.Comment("'" + contactname + "' is assigned to '" + agentname + "'; please contact an administrator to change this assignment.");
                        else
                            context.TheLeader.Tell("'" + contactname + "' is assigned to '" + agentname + "'; please contact an administrator to change this assignment.");
                        return false;
                    }
                }
            }

            if (Tools.Strings.StrExt(strUserID))
            {
                strID = strUserID;
            }
            else
            {
                NewMethod.n_user nu = context.TheLeaderRz.AskForUser(context.Logic.SalesPeople, false);
                if (nu != null)
                    strID = nu.unique_id;
            }
            if (!Tools.Strings.StrExt(strID))
                return false;

            n_user u = (n_user)context.xSys.Users.GetByID(strID);
            if (u == null)
                return false;

            if (!TryAssign(context, u))
                return false;


            //base_mc_user_uid = strID;
            //agentname = "";
            context.TheLeader.Comment("'" + contactname + "' is now assigned to " + NewMethod.n_user.TranslateIDToName(context, strID));
            context.Update(this);
            return true;
        }

        public bool Release(ContextRz context, n_team t)
        {
            if (Tools.Strings.StrCmp(Tools.Strings.Left(agentname, 5), "team:"))
            {
                context.TheLeader.Comment(ToString() + " is already released.");
                return false;
            }

            if ((!context.xUser.SuperUser) && Tools.Strings.StrExt(base_mc_user_uid))
            {
                if (!Tools.Strings.StrCmp(context.xUser.unique_id, base_mc_user_uid))
                {
                    ArrayList colHold = context.xUser.GetCaptainUsers(context);
                    bool boolIn = false;
                    foreach (NewMethod.n_user yUser in colHold)
                    {
                        if (Tools.Strings.StrCmp(yUser.unique_id, base_mc_user_uid))
                            boolIn = true;
                    }
                    if (!boolIn)
                    {
                        //if (boolStatusOnly)
                        context.TheLeader.Comment("'" + contactname + "' is assigned to '" + agentname + "'; please contact an administrator to change this assignment.");
                        //else
                        //    context.TheLeader.Tell("'" + contactname + "' is assigned to '" + agentname + "'; please contact an administrator to change this assignment.");
                        return false;
                    }
                }
            }

            base_mc_user_uid = "";
            agentname = "Team: " + t.name;
            context.TheLeader.Comment("'" + contactname + "' is now released.");
            context.Update(this);
            return true;
        }

        public void ViewCompany(ContextRz context)
        {
            company xCompany = TheCompanyVar.RefGet(context);
            if (xCompany != null)
            {
                context.Show(xCompany);
            }
            else
            {
                context.TheLeader.Tell(contactname + "'s linked company (" + companyname + ") could not be found.");
                //if ()
                //{
                //    String s = "";
                //    String strCompanyID = "";
                //    frmChooseCompany.ChooseCompanyID(ref strCompanyID, ref s, Enums.CompanySelectionType.Both, "Company", null);
                //    if (!Tools.Strings.StrExt(strCompanyID))
                //        return;
                //    company c = company.GetByID(xSys, strCompanyID);
                //    TheCompanyVar.RefSet(context, c);
                //    ISave();
                //    context.Show(c);
                //}
            }
        }
        public contactnote AddContactNote(ContextRz context, String strNote)
        {
            //contactnote xNote = new contactnote(xSys);
            //xNote.base_company_uid = base_company_uid;
            //xNote.base_companycontact_uid = unique_id;
            //xNote.notedate = DateTime.Now;
            //xNote.noteagent = Rz3App.xUser.unique_id;
            //xNote.notetext = strNote;
            //xNote.ISave();
            //return xNote;

            contactnote ret = GetNewNote(context);
            ret.notetext = strNote;
            context.Update(ret);
            return ret;
        }
        public contactnote ShowNewContactNote(ContextRz context, String strNote)
        {
            contactnote c = AddContactNote(context, strNote);
            context.Show(c);
            return c;
        }

        public ArrayList GetPossibleDuplicates(ContextRz context)
        {
            return context.QtC("companycontact", "select * from companycontact where unique_id <> '" + unique_id + "' and isnull(contactname, '') > '' and isnull(primaryemailaddress, '') <> '' and contactname = '" + context.TheData.Filter(contactname) + "' and primaryemailaddress = '" + context.TheData.Filter(primaryemailaddress) + "'");
        }

        //public void MergeWith(ContextRz context, ArrayList contacts)
        //{
        //    MergeWith(context, nTools.GetIDString(contacts));
        //}


        //public void MergeWith(ContextRz context, IItems theItems)
        //{
            


        //}
        //public void MergeWith(ContextRz context, companycontact keepContact, companycontact mergeContact)
        //{

        //    //if (Tools.Strings.HasString(contact_ids.Replace(" ", ""), "''"))
        //    //{
        //    //    context.TheLeader.Tell("Blank unique IDs cannot be consolidated.");
        //    //    return;
        //    //}
        //    String strSQL = "";
        //    context.TheLeader.Comment("Creating temp tables ...");
        //    strSQL = "alter table req add contactid varchar(255)";
        //    context.TheData.TheConnection.Execute(strSQL, true);

        //    strSQL = "alter table calllog add contactid varchar(255)";
        //    context.TheData.TheConnection.Execute(strSQL, true);

        //    strSQL = "alter table contactnote add contactid varchar(255)";
        //    context.TheData.TheConnection.Execute(strSQL, true);

        //    strSQL = "alter table quote add contactid varchar(255)";
        //    context.TheData.TheConnection.Execute(strSQL, true);

        //    //call logs
        //    context.TheLeader.Comment("Merging call logs...");
        //    strSQL = "update calllog set base_companycontact_uid = '" + keepContact.unique_id + "', contactname = '" + context.TheData.Filter(keepContact.contactname) + "' where contactid= '" + mergeContact.unique_id + "' or base_companycontact_uid= '" + mergeContact.unique_id + "' ";
        //    context.Execute(strSQL);

        //    //contact notes
        //    context.TheLeader.Comment("Merging contact notes...");
        //    strSQL = "update contactnote set base_companycontact_uid = '" + keepContact.unique_id + "', contactname = '" + context.TheData.Filter(keepContact.contactname) + "' where contactid= '" + mergeContact.unique_id + "' or base_companycontact_uid= '" + mergeContact.unique_id + "' ";// "' where contactid in (" + contact_ids + ") or base_companycontact_uid in (" + contact_ids + ") ";
        //    context.Execute(strSQL);

        //    //reqs
        //    context.TheLeader.Comment("Merging reqs...");
        //    strSQL = "update req set base_companycontact_uid = '" + keepContact.unique_id + "', contactname = '" + context.TheData.Filter(keepContact.contactname) + "' where contactid= '" + mergeContact.unique_id + "' or base_companycontact_uid= '" + mergeContact.unique_id + "' "; //"' where contactid in (" + contact_ids + ") or base_companycontact_uid in (" + contact_ids + ") ";
        //    context.Execute(strSQL);

        //    //quotes
        //    context.TheLeader.Comment("Merging quotes...");
        //    strSQL = "update quote set base_companycontact_uid = '" + keepContact.unique_id + "', contactname = '" + context.TheData.Filter(keepContact.contactname) + "' where contactid= '" + mergeContact.unique_id + "' or base_companycontact_uid= '" + mergeContact.unique_id + "' "; //"' where contactid in (" + contact_ids + ") or base_companycontact_uid in (" + contact_ids + ") ";
        //    context.Execute(strSQL);

        //    //orders
        //    context.TheLeader.Comment("Merging orders...");
        //    ordhed.RunSQLOnOrderTables(context, "update <order table> set base_companycontact_uid = '" + keepContact.unique_id + "', contactname = '" + context.Filter(keepContact.contactname) + "' where base_companycontact_uid = '" + mergeContact.unique_id + "' ");

        //    //use the earliest create date
        //    context.TheLeader.Comment("Merging dates...");
        //    strSQL = "update companycontact set date_created = (select isnull(min(date_created), getdate()) from companycontact where unique_id = '" + keepContact.unique_id + "' OR unique_id = '" + mergeContact.unique_id + "')"; //in ( " + contact_ids + ", '" + unique_id + "' ) and date_created > cast('01/02/1900' as datetime)) where unique_id = '" + unique_id + "'";
        //    context.Execute(strSQL);

        //    //set modified date
        //    strSQL = "update companycontact set date_modified = (select isnull(min(date_modified), getdate()) from companycontact  where unique_id = '" + keepContact.unique_id + "' OR unique_id = '" + mergeContact.unique_id + "')"; // where unique_id in ( " + contactToMergeInto.unique_id + ", '" + mergedContact.unique_id + "' ) and date_modified > cast('01/02/1900' as datetime)) where unique_id = '" + contactToMergeInto.unique_id + "'";
        //    context.Execute(strSQL);

        //    //names
        //    context.TheLeader.Comment("Merging contact names ...");
        //    ArrayList names = context.TheData.SelectScalarArray("select distinct(isnull(contactname, '')) from companycontact where unique_id = '" + mergeContact.unique_id + "'");
        //    foreach (String sn in names)
        //    {
        //        if (Tools.Strings.StrExt(sn))
        //        {
        //            if (!Tools.Strings.StrCmp(sn, contactname) && !Tools.Strings.HasString(alternate_names, "<" + sn + ">"))
        //            {
        //                alternate_names += "<" + sn + ">";
        //            }
        //        }
        //    }

        //    //emails
        //    context.TheLeader.Comment("Merging emails ....");
        //    ArrayList emails = context.TheData.SelectScalarArray("select distinct(isnull(primaryemailaddress, '')) from companycontact where unique_id = '" + mergeContact.unique_id + "'");
        //    foreach (String sn in emails)
        //    {
        //        if (Tools.Strings.StrExt(sn))
        //        {
        //            if (!Tools.Strings.StrCmp(sn, keepContact.primaryemailaddress) && !Tools.Strings.HasString(keepContact.alternate_emails, "<" + sn + ">"))
        //            {
        //                alternate_emails += "<" + sn + ">";
        //            }
        //        }
        //    }

        //    //source
        //    context.TheLeader.Comment("Merging sources ....");
        //    ArrayList sources = context.TheData.SelectScalarArray("select distinct(isnull(source, '')) from companycontact where unique_id = '" + mergeContact.unique_id + "'");
        //    sources.Add(this.source);
        //    String ss = Homogenize(sources);
        //    if (ss != this.source)
        //        this.source = ss;

        //    ////group
        //    //ArrayList groups = context.TheData.SelectScalarArray("select isnull(group_name, '') from companycontact where unique_id = '" + keepContact.unique_id + "' or unique_id = '" + mergedContact.unique_id + "'");
        //    //String sg = Homogenize(groups);
        //    //context.Execute("update companycontact set group_name = '" + context.Filter(sg) + "' where unique_id = '" + unique_id + "'");

        //    //ContactNotes
        //    ArrayList notes = context.TheData.SelectScalarArray("select isnull(contactnotes, '') from companycontact where unique_id <> '" + keepContact.unique_id + "' and unique_id = '" + mergeContact.unique_id + "'");
        //    foreach (String sn in notes)
        //    {
        //        contactnotes += "\r\n" + sn;
        //    }

        //    //marketing addresses
        //    context.TheLeader.Comment("Merging mailing addresses ....");
        //    ArrayList addresses = context.TheData.SelectScalarArray("select isnull(line1, '') + '|' + isnull(line2, '') + '|' + isnull(line3, '') + '|' + isnull(adrcity, '') + '|' + isnull(adrstate, '') + '|' + isnull(adrzip, '') + '|' + isnull(adrcountry, '') from companycontact where unique_id = '" + mergeContact.unique_id + "' group by isnull(line1, '') + '|' + isnull(line2, '') + '|' + isnull(line3, '') + '|' + isnull(adrcity, '') + '|' + isnull(adrstate, '') + '|' + isnull(adrzip, '') + '|' + isnull(adrcountry, '') ");
        //    foreach (String address in addresses)
        //    {
        //        if (Tools.Strings.StrExt(address.Replace("|", "")))
        //        {
        //            if (!AddressContains(address))
        //            {
        //                if (AddressHas)
        //                {
        //                    if (alternate_mailing_address != "")
        //                        alternate_mailing_address += "\r\n";
        //                    alternate_mailing_address += address;
        //                }
        //                else
        //                {
        //                    String[] ary = Tools.Strings.Split(address, "|");
        //                    line1 = ary[0];
        //                    line2 = ary[1];
        //                    line3 = ary[2];
        //                    adrcity = ary[3];
        //                    adrstate = ary[4];
        //                    adrzip = ary[5];
        //                    adrcountry = ary[6];
        //                }
        //            }
        //        }
        //    }

        //    contactnotes += "\r\nMerged " + DateTime.Now.ToString();
        //    context.Update(this);

        //    //deletes
        //    context.TheLeader.Comment("Deleting " + mergeContact.contactname);
        //    strSQL = "delete from companycontact where unique_id =  '" + mergeContact.unique_id + "'";
        //    context.Execute(strSQL);
        //    CloseDeletedContactScreens(context, mergeContact.unique_id);
        //    context.TheLeader.Comment("Completed merge operation for " + mergeContact.contactname);
        //}

        //public void MergeWith(ContextRz context, String contact_ids)
        //{
        //    if (Tools.Strings.HasString(contact_ids.Replace(" ", ""), "''"))
        //    {
        //        context.TheLeader.Tell("Blank unique IDs cannot be consolidated.");
        //        return;
        //    }
        //    String strSQL = "";

        //    strSQL = "alter table req add contactid varchar(255)";
        //    context.TheData.TheConnection.Execute(strSQL, true);

        //    strSQL = "alter table calllog add contactid varchar(255)";
        //    context.TheData.TheConnection.Execute(strSQL, true);

        //    strSQL = "alter table contactnote add contactid varchar(255)";
        //    context.TheData.TheConnection.Execute(strSQL, true);

        //    strSQL = "alter table quote add contactid varchar(255)";
        //    context.TheData.TheConnection.Execute(strSQL, true);

        //    //call logs
        //    context.TheLeader.Comment("Merging call logs...");
        //    strSQL = "update calllog set base_companycontact_uid = '" + unique_id + "', contactname = '" + context.TheData.Filter(contactname) + "' where contactid in (" + contact_ids + ") or base_companycontact_uid in (" + contact_ids + ") ";
        //    context.Execute(strSQL);

        //    //contact notes
        //    context.TheLeader.Comment("Merging contact notes...");
        //    strSQL = "update contactnote set base_companycontact_uid = '" + unique_id + "', contactname = '" + context.TheData.Filter(contactname) + "' where contactid in (" + contact_ids + ") or base_companycontact_uid in (" + contact_ids + ") ";
        //    context.Execute(strSQL);

        //    //reqs
        //    context.TheLeader.Comment("Merging reqs...");
        //    strSQL = "update req set base_companycontact_uid = '" + unique_id + "', contactname = '" + context.TheData.Filter(contactname) + "' where contactid in (" + contact_ids + ") or base_companycontact_uid in (" + contact_ids + ") ";
        //    context.Execute(strSQL);

        //    //quotes
        //    context.TheLeader.Comment("Merging quotes...");
        //    strSQL = "update quote set base_companycontact_uid = '" + unique_id + "', contactname = '" + context.TheData.Filter(contactname) + "' where contactid in (" + contact_ids + ") or base_companycontact_uid in (" + contact_ids + ") ";
        //    context.Execute(strSQL);

        //    //orders
        //    context.TheLeader.Comment("Merging orders...");
        //    ordhed.RunSQLOnOrderTables(context, "update <order table> set base_companycontact_uid = '" + unique_id + "', contactname = '" + context.Filter(contactname) + "' where base_companycontact_uid in (" + contact_ids + ") ");

        //    //use the earliest create date
        //    context.TheLeader.Comment("Merging dates...");
        //    strSQL = "update companycontact set date_created = (select isnull(min(date_created), getdate()) from companycontact where unique_id in ( " + contact_ids + ", '" + unique_id + "' ) and date_created > cast('01/02/1900' as datetime)) where unique_id = '" + unique_id + "'";
        //    context.Execute(strSQL);

        //    strSQL = "update companycontact set date_modified = (select isnull(min(date_modified), getdate()) from companycontact where unique_id in ( " + contact_ids + ", '" + unique_id + "' ) and date_modified > cast('01/02/1900' as datetime)) where unique_id = '" + unique_id + "'";
        //    context.Execute(strSQL);

        //    //names
        //    ArrayList names = context.TheData.SelectScalarArray("select distinct(isnull(contactname, '')) from companycontact where unique_id in (" + contact_ids + ")");
        //    foreach (String sn in names)
        //    {
        //        if (Tools.Strings.StrExt(sn))
        //        {
        //            if (!Tools.Strings.StrCmp(sn, contactname) && !Tools.Strings.HasString(alternate_names, "<" + sn + ">"))
        //            {
        //                alternate_names += "<" + sn + ">";
        //            }
        //        }
        //    }

        //    //emails
        //    ArrayList emails = context.TheData.SelectScalarArray("select distinct(isnull(primaryemailaddress, '')) from companycontact where unique_id in (" + contact_ids + ")");
        //    foreach (String sn in emails)
        //    {
        //        if (Tools.Strings.StrExt(sn))
        //        {
        //            if (!Tools.Strings.StrCmp(sn, primaryemailaddress) && !Tools.Strings.HasString(alternate_emails, "<" + sn + ">"))
        //            {
        //                alternate_emails += "<" + sn + ">";
        //            }
        //        }
        //    }

        //    //source
        //    ArrayList sources = context.TheData.SelectScalarArray("select distinct(isnull(source, '')) from companycontact where unique_id in (" + contact_ids + ")");
        //    sources.Add(this.source);
        //    String ss = Homogenize(sources);
        //    if (ss != this.source)
        //        this.source = ss;

        //    //group
        //    ArrayList groups = context.TheData.SelectScalarArray("select isnull(group_name, '') from companycontact where unique_id = '" + this.unique_id + "' or unique_id in (" + contact_ids + ")");
        //    String sg = Homogenize(groups);
        //    context.Execute("update companycontact set group_name = '" + context.Filter(sg) + "' where unique_id = '" + unique_id + "'");

        //    ArrayList notes = context.TheData.SelectScalarArray("select isnull(contactnotes, '') from companycontact where unique_id <> '" + this.unique_id + "' and unique_id in (" + contact_ids + ")");
        //    foreach (String sn in notes)
        //    {
        //        contactnotes += "\r\n" + sn;
        //    }

        //    //marketing addresses
        //    ArrayList addresses = context.TheData.SelectScalarArray("select isnull(line1, '') + '|' + isnull(line2, '') + '|' + isnull(line3, '') + '|' + isnull(adrcity, '') + '|' + isnull(adrstate, '') + '|' + isnull(adrzip, '') + '|' + isnull(adrcountry, '') from companycontact where unique_id in ( " + contact_ids + " ) group by isnull(line1, '') + '|' + isnull(line2, '') + '|' + isnull(line3, '') + '|' + isnull(adrcity, '') + '|' + isnull(adrstate, '') + '|' + isnull(adrzip, '') + '|' + isnull(adrcountry, '') ");
        //    foreach (String address in addresses)
        //    {
        //        if (Tools.Strings.StrExt(address.Replace("|", "")))
        //        {
        //            if (!AddressContains(address))
        //            {
        //                if (AddressHas)
        //                {
        //                    if (alternate_mailing_address != "")
        //                        alternate_mailing_address += "\r\n";
        //                    alternate_mailing_address += address;
        //                }
        //                else
        //                {
        //                    String[] ary = Tools.Strings.Split(address, "|");
        //                    line1 = ary[0];
        //                    line2 = ary[1];
        //                    line3 = ary[2];
        //                    adrcity = ary[3];
        //                    adrstate = ary[4];
        //                    adrzip = ary[5];
        //                    adrcountry = ary[6];
        //                }
        //            }
        //        }
        //    }

        //    contactnotes += "\r\nMerged " + DateTime.Now.ToString();
        //    context.Update(this);

        //    //deletes
        //    context.TheLeader.Comment("Deleting...");
        //    strSQL = "delete from companycontact where unique_id in (" + contact_ids + ")";
        //    context.Execute(strSQL);
        //    CloseDeletedContactScreens(context, contact_ids);
        //    context.TheLeader.Comment("Done.");
        //}
        public void CloseDeletedContactScreens(ContextRz context, string contact_ids)
        {
            if (!Tools.Strings.StrExt(contact_ids))
                return;
            ArrayList a = new ArrayList();
            string[] ids = Tools.Strings.Split(contact_ids, ",");
            foreach (string s in ids)
            {
                string hold = s.Replace("'", "").Trim();
                if (!Tools.Strings.StrExt(hold))
                    continue;
                a.Add(hold);
            }
            context.TheLeaderRz.CloseTabsByID(context, a);
        }
        public bool AddressHas
        {
            get
            {
                return Tools.Strings.StrExt(AddressAsOneLine.Replace("|", ""));
            }
        }

        public bool AddressContains(String address_as_one_line)
        {
            if (!Tools.Strings.StrExt(address_as_one_line.Replace("|", "")))
                return false;

            if (Tools.Strings.StrCmp(address_as_one_line, AddressAsOneLine))
                return true;

            return Tools.Strings.HasString(alternate_mailing_address, address_as_one_line);
        }

        //public String AddressLineDelimited
        //{
        //    get
        //    {
        //        return line1 + "|" + line2 + "|" + line3 + "|" + adrcity + "|" + adrstate + "|" + adrzip + "|" + adrcountry;
        //    }
        //}


        
        public bool HasValidMailingAddress()
        {
            return (nTools.Len(line1) > 0) && (nTools.Len(adrcity) > 0) && (nTools.Len(adrstate) > 0) && (nTools.Len(adrzip) > 0);
        }
        //public company CompanyObject
        //{
        //    get
        //    {
        //        return GetCompanyObject();
        //    }
        //    set
        //    {
        //        if (value == null)
        //        {
        //            base_company_uid = "";
        //            companyname = "";
        //        }
        //        else
        //        {
        //            base_company_uid = value.unique_id;
        //            companyname = value.companyname;
        //        }
        //    }
        //}
        public void AbsorbAddress(companyaddress a)
        {
            this.line1 = a.line1;
            this.line2 = a.line2;
            this.line3 = a.line3;
            this.adrcity = a.adrcity;
            this.adrstate = a.adrstate;
            this.adrzip = a.adrzip;
            this.adrcountry = a.adrcountry;
        }
        public String GetCompetition(ContextRz context)
        {
            return context.SelectScalarString("select top 1 competition from companycontact where unique_id = '" + unique_id + "'");
        }
        public void SetCompetition(ContextRz context, String s)
        {
            context.Execute("update companycontact set competition = '" + context.Filter(s) + "' where unique_id = '" + unique_id + "'");
        }

        public String AddressAsOneLine
        {
            get
            {
                return line1 + " | " + line2 + " | " + line3 + " | " + adrcity + " | " + adrstate + " | " + adrzip + " | " + adrcountry;
            }
        }

        public void AddCompetition(ContextRz context, String s)
        {
            String e = GetCompetition(context);
            if (Tools.Strings.HasString(e, "<" + s + ">"))
                return;
            e += "<" + s + ">";
            SetCompetition(context, e);
        }
        public void RemoveCompetition(ContextRz context, String s)
        {
            String e = GetCompetition(context);
            if (!Tools.Strings.HasString(e, "<" + s + ">"))
                return;
            e = e.Replace("<" + s + ">", "");
            SetCompetition(context, e);
        }
        public void PushAddress(String strLine)
        {
            if (!Tools.Strings.StrExt(line1))
                line1 = strLine;
            else if (!Tools.Strings.StrExt(line2))
                line2 = strLine;
            else if (!Tools.Strings.StrExt(line3))
                line3 = strLine;
            else if (!Tools.Strings.StrExt(adrcity))
                adrcity = strLine;
            else if (!Tools.Strings.StrExt(adrstate))
                adrstate = strLine;
            else if (!Tools.Strings.StrExt(adrzip))
                adrzip = strLine;
            else if (!Tools.Strings.StrExt(adrcountry))
                adrcountry = strLine;
        }
        public bool IsAssigned()
        {
            return (Tools.Strings.StrExt(agentname) || Tools.Strings.StrExt(base_mc_user_uid));
        }
        protected virtual string FilterMayAssignTeamName(ContextRz context, String strTeam)
        {
            return strTeam;
        }
        public virtual bool MayAssign(ContextRz x, NewMethod.n_user u, ref String reason)
        {
            //KT - Refactored from RzSensible 2-26-2015
            if (x.xUser.SuperUser)
                return true;
            reason = "this is a super-user function";
            return false;  //only super users can change

            //KT - The below was the original code
            //if (u.SuperUser || x.xUser.SuperUser)   
            //    return true;  //added 2009_11_23, why wasn't this always there?
            //if (!IsAssigned())
            //{
            //    //nothing
            //}
            //else if (Tools.Strings.HasString(agentname, ":") && !u.SuperUser)
            //{
            //    if (agentname.Trim().Trim().ToLower().StartsWith("team:"))
            //    {
            //        String strTeam = Tools.Strings.ParseDelimit(agentname, ":", 2).Trim();
            //        strTeam = FilterMayAssignTeamName(x, strTeam);
            //        if (!u.IsTeamMember(x, strTeam))
            //        {
            //            reason = "this contact is assigned to " + strTeam + ", and cannot be assigned by other agents.";
            //            return false;
            //        }
            //    }
            //}
            //else
            //{
            //    if (!x.xUser.CheckPermit(x, "System:Edit:Change Agent") && !x.xUser.CheckPermit(x, "Contact:Assign:CanAssignAllContacts", true))
            //    {
            //        switch (agentname.Trim().ToLower())
            //        {
            //            case "unclaimed":
            //            case "unassigned":
            //            case "bad record":
            //            case "none":
            //                return true;
            //        }
            //        //see if the assigned user is owned by the current one
            //        NewMethod.n_user assigned = UserObjectGet(x);
            //        if (assigned != null)
            //        {
            //            if (Tools.Strings.StrCmp(assigned.unique_id, u.unique_id))
            //                return true;
            //            if (Tools.Strings.StrCmp(assigned.unique_id, x.xUser.unique_id))
            //                return true;
            //            if (x.Logic.IsUserAssistantOf(x, assigned.unique_id))
            //                return true;
            //            bool cap = x.xUser.IsTeamCaptainOf(x, assigned.unique_id);
            //            if (!cap)
            //            {
            //                reason = "this contact does not appear to be assigned to the current user, or anyone on the current user's team.";
            //                return false;
            //            }
            //        }
            //    }
            //}
            //return true;
        }

        public virtual bool TryAssign(ContextRz x, n_user u)
        {
            String s = "";
            if (!MayAssign(x, u, ref s))
            {
                x.TheLeader.TellTemp("This contact could not be reassigned.\r\n\r\n" + s);
                return false;
            }

            //user_activity.AddActivity(x, "Contact Assignment", this.ToString() + " was assigned from '" + agentname + "' to " + u.name, this);

            UserObjectSet(u);
            return true;
        }


        public String GetFullMailingAddress()
        {
            return Tools.Strings.KillBlankLines(contactname + "\r\n" + companyname + "\r\n" + line1 + "\r\n" + line2 + "\r\n" + line3 + "\r\n" + adrcity + ", " + adrstate + "  " + adrzip + "\r\n" + adrcountry);
        }

        public String GetMailingAddressWithoutName()
        {
            return Tools.Strings.KillBlankLines(line1 + "\r\n" + line2 + "\r\n" + line3 + "\r\n" + adrcity + ", " + adrstate + "  " + adrzip + "\r\n" + adrcountry);
        }

        public String BuildAddress()
        {
            String s = line1 + "\r\n" + line2 + "\r\n" + line3 + "\r\n" + adrcity + ", " + adrstate + "  " + adrzip + "\r\n" + adrcountry;
            return Tools.Strings.KillBlankLines(s);
        }
        public bool HasValidFaxNumber()
        {
            return nTools.IsPhoneNumber(primaryfax);
        }
        public bool SuppressNotifications
        {
            get
            {
                return Tools.Strings.HasString(this.jobtype, "suppress_notify");
            }
        }
        public String GetDistilled1()
        {
            String strHold = companycontact.DistillContactName(contactname) + nTools.DistillPhoneNumber(primaryphone);

            if (strHold.Length >= 13)
                return strHold;
            else
                return "";
        }
        public String GetDistilled2()
        {
            if (!Tools.Strings.HasString(primaryemailaddress, "@"))
                return "";

            String strHold = Tools.Strings.FilterTrash(primaryemailaddress);

            strHold = companycontact.DistillContactName(contactname) + strHold;
            if (strHold.Length >= 8)
                return strHold;
            else
                return "";
        }
        public String GetDistilled3()
        {
            String strHold = Tools.Strings.FilterTrash(contactname) + Tools.Strings.FilterTrash(companyaddress.FilterAddressTrash(line1 + line2 + adrcity + adrstate + adrzip));
            if (strHold.Length >= 25)
                return strHold;
            else
                return "";
        }
        public bool AlreadyExists(ContextRz context, ref companycontact yContact)
        {
            String strSQL;

            strSQL = "select * from companycontact where ";
            strSQL = strSQL + " ( isnull(distilled1, '') > '' and distilled1 = '" + context.Filter(GetDistilled1()) + "' ) ";
            strSQL = strSQL + " or ";
            strSQL = strSQL + " ( isnull(distilled2, '') > '' and distilled2 = '" + context.Filter(GetDistilled2()) + "' ) ";
            strSQL = strSQL + " or ";
            strSQL = strSQL + " ( isnull(distilled3, '') > '' and distilled3 = '" + context.Filter(GetDistilled3()) + "' )";
            strSQL = strSQL + " or ( ";
            strSQL = strSQL + " companyname = '" + context.Filter(companyname) + "' and contactname = '" + context.Filter(contactname) + "'";
            strSQL = strSQL + " )";

            if (nTools.IsEmailAddress(primaryemailaddress))
            {
                //strSQL = strSQL + " or ( ";
                //strSQL = strSQL + " primaryemailaddress = '" + Rz3App.context.Filter(primaryemailaddress) + "' and contactname = '" + Rz3App.context.Filter(contactname) + "'";
                //strSQL = strSQL + " )";


                //changed to primary email only as of 2009_11_18
                strSQL = strSQL + " or ( ";
                strSQL = strSQL + " primaryemailaddress = '" + context.Filter(primaryemailaddress) + "'";
                strSQL = strSQL + " )";

                strSQL = strSQL + " or ( ";
                strSQL = strSQL + " alternateemail = '" + context.Filter(primaryemailaddress) + "'";
                strSQL = strSQL + " )";
            }

            yContact = (companycontact)context.QtO("companycontact", strSQL);
            return (yContact != null);
        }
        public void KillLine1()
        {
            line1 = line2;
            line2 = line3;
            line3 = "";
        }
        public void LinkToNewCompany(ContextRz context)
        {
            //company c = context.Sys.TheCompanyLogic.AddNewCompany(context, "", "", "", "", "");
            company c = company.AddNew(context, "", "", "", "", "");
            if (c == null)
                return;

            c.primarycontact = contactname;
            c.primaryphone = primaryphone;
            c.primaryfax = primaryfax;
            c.primaryemailaddress = primaryemailaddress;
            c.Update(context);

            TheCompanyVar.RefSet(context, c);
            Update(context);
            context.Show(c);
            //args.ShouldClose = true;
        }
        public void LinkToCompany(ContextRz context)
        {
            company c = context.Leader.AskForCompany(context, "");
            if (c == null)
                return;
            ArrayList a = new ArrayList();
            a.Add(c.unique_id);
            context.TheLeaderRz.CloseTabsByID(context, a);
            TheCompanyVar.RefSet(context, c);
            Update(context);
            context.Show(c);
        }
        public void DoAction_ViewHistory()
        {
            throw new NotImplementedException("CompanyContact.ViewHistory");
            //if( xForm = null )
            //{
            //     xForm= new FormBrowser
            //    xForm.Show 
            //}

            //xForm.AddLine "<h1><font color=blue>" + companyname + "::" + contactname + "</font></h1>"
            //xForm.AddLine "Assigned To: " + agentname

            //'xForm.AddLine "<br><hr><b>Calls:</b>"
            //'xForm.AddTableFromSQL "select username as [Agent], calldate as [Date], (duration / 60) as [Minutes] from phonecall where base_companycontact_uid = '" & Me.unique_id & "' order by calldate desc "

            //xForm.AddLine "<br><hr><b>Reqs:</b>"
            //xForm.AddTableFromSQL "select agentname as [Agent], fullpartnumber as [Part], datecreated as [Date] from req where base_companycontact_uid = '" + unique_id + "'  order by datecreated desc"
            //xForm.AddLine "<br><hr><b>Bids:</b>"
            //xForm.AddTableFromSQL "select agentname as [Agent], fullpartnumber as [Part], quotedate as [Date] from quote where quotetype = 'Receiving' and base_companycontact_uid = '" + unique_id + "' order by quotedate desc"
            //xForm.AddLine "<br><hr><b>Quick Quotes:</b>"
            //xForm.AddTableFromSQL "select agentname as [Agent], fullpartnumber as [Part], quotedate as [Date] from quote where quotetype = 'Giving Out' and base_companycontact_uid = '" + unique_id + "' order by quotedate desc"
            //xForm.AddLine "<br><hr><b>Formal Quotes:</b>"
            //xForm.AddTableFromSQL "select agentname as [Agent], ordernumber as [Quote Number], orderdate as [Date] from " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + " where ordertype = 'Quote' and base_companycontact_uid = '" + unique_id + "' and isnull(isvoid, 0) = 0 order by orderdate desc"
            //xForm.AddLine "<br><hr><b>Sales:</b>"
            //xForm.AddTableFromSQL "select agentname as [Agent], ordernumber as [Order Number], orderdate as [Date] from " + ordhed.MakeOrdhedName(Enums.OrderType.Sales) + " where ordertype = 'Sales' and base_companycontact_uid = '" + unique_id + "' and isnull(isvoid, 0) = 0 order by orderdate desc"
            //xForm.AddLine "<br><hr><b>Marketing History:</b>"
            //xForm.AddTableFromSQL "select entrytype as [Type], entrytext as [Description], historydate as [Date] from companyhistory where base_companycontact_uid = '" + unique_id + "' order by HISTORYDATE desc "

        }
        public void SendEmail(ContextRz context)
        {
            SendEmail(context, false);
        }
        public void SendEmail(ContextRz context, Boolean bChooseTemplate)
        {
            if (!nTools.IsEmailAddress(primaryemailaddress))
            {
                context.TheLeader.Tell("'" + primaryemailaddress + "' does not appear to be a valid e-mail address.");
                return;
            }
            if (!bChooseTemplate)
            {
                String err = "";
                //ToolsOffice.OutlookOffice.SendOutlookMessage(primaryemailaddress, "", "", false, true, "", "", false, null, "", "", "", context.xUser.email_signature, ref err);
                //context.TheSysRz.TheEmailLogic.SendOutlookEmail(primaryemailaddress, "", "", false, true, "", "", false, null, "", "", "", context.xUser.email_signature, true, ref err);

                return;
            }
            String strSubject = "";
            //frmChooseEmailTemplate xForm = new frmChooseEmailTemplate();
            //xForm.primaryemailaddress = primaryemailaddress;
            //xForm.CompleteLoad(this);
            //xForm.ShowDialog(RzApp.xMainForm);
            //emailtemplate xTemplate = xForm.SelectedTemplate;

            emailtemplate xTemplate = context.Leader.AskForEmailTemplate(this);
            if (xTemplate == null)
                return;
            String strBody = xTemplate.emailbody + xTemplate.emailfooter;
            strBody = this.AssociateWithHTML(strBody);
            strBody = context.xUser.AssociateWithHTML(strBody);
            strSubject = xTemplate.subjectstring;
            strSubject = this.AssociateWithHTML(strSubject);
            strSubject = context.xUser.AssociateWithHTML(strSubject);
            String error = "";

            //context.Leader.SendOutlookMessage(primaryemailaddress, strAll, strSubject, false, true, "", xTemplate.AttachmentFileString, false, null, "", "", "", context.xUser.email_signature, false, ref err2);
            context.TheSysRz.TheEmailLogic.SendEmail(context, new List<string>() { primaryemailaddress }, strBody, strSubject, false, true, null, null, null, true, null, null, true, ref error);

            //ToolsOffice.OutlookOffice.SendOutlookMessage(primaryemailaddress, strAll, strSubject, false, true, "", xTemplate.AttachmentFileString, false, null, "", "", "", context.xUser.email_signature, ref err2);
        }
        //Private Functions
        private void DistillEverything(ContextRz context)
        {
            distilledcontact = companycontact.DistillContactName(contactname);
            distilledphone = phonecall.GetFinalPhoneNumber(context, primaryphone);
            distilledfax = nTools.DistillPhoneNumber(primaryfax);
            strippedphone = distilledphone;
            strippedalternatephone = nTools.DistillPhoneNumber(alternatephone);
        }
        private void ViewDomain(ContextRz context)
        {
            context.Leader.BrowseUrl("http://www." + nTools.ParseEmailDomain(primaryemailaddress));
        }

        public void PushPhoneNumber(String strPhone)
        {
            String strPhoneS = nTools.StripPhoneNumber(strPhone);
            if (!Tools.Strings.StrExt(strPhoneS))
                return;

            if (strPhoneS != nTools.StripPhoneNumber(primaryphone))
            {
                if (!Tools.Strings.StrExt(primaryphone))
                    primaryphone = strPhone;
                else
                {
                    if (strPhoneS != nTools.StripPhoneNumber(alternatephone))
                    {
                        if (!Tools.Strings.StrExt(alternatephone))
                            alternatephone = strPhone;
                    }
                }
            }
        }

        public void PushEmailAddress(String strEmail)
        {
            if (!Tools.Strings.StrExt(strEmail))
                return;

            if (strEmail != primaryemailaddress)
            {
                if (!Tools.Strings.StrExt(primaryemailaddress))
                    primaryemailaddress = strEmail;
                else
                {
                    if (strEmail != alternateemail)
                    {
                        if (!Tools.Strings.StrExt(alternateemail))
                            alternateemail = strEmail;
                    }
                }
            }
        }

        public void PushFax(String strFax)
        {
            String strFaxS = nTools.StripPhoneNumber(strFax);
            if (!Tools.Strings.StrExt(strFaxS))
                return;

            if (strFaxS != nTools.StripPhoneNumber(primaryfax))
            {
                if (!Tools.Strings.StrExt(primaryfax))
                    primaryfax = strFax;
                else
                {
                    if (strFaxS != nTools.StripPhoneNumber(alternatefax))
                    {
                        if (!Tools.Strings.StrExt(alternatefax))
                            alternatefax = strFax;
                    }
                }
            }
        }

        public virtual String CustomerType
        {
            get
            {
                return "";
            }
        }

        public virtual Enums.ContactType ContactType
        {
            set
            {

            }

            get
            {
                return Enums.ContactType.Unknown;
            }
        }

        public virtual Enums.ContactFunction ContactFunction
        {
            get
            {
                try
                {
                    if (!Tools.Strings.StrExt(contact_function))
                        return Enums.ContactFunction.Any;
                    else
                        return (Enums.ContactFunction)Enum.Parse(typeof(Enums.ContactFunction), contact_function);
                }
                catch { return Enums.ContactFunction.Any; }
            }

            set
            {
                try
                {
                    if (value == Enums.ContactFunction.Any)
                        contact_function = "";
                    else
                        contact_function = value.ToString();
                }
                catch { }
            }
        }

        public void ShowNewOrderBatch(ContextRz x)
        {
            if (TheCompanyVar.RefGet(x) == null)
            {
                x.TheLeader.TellTemp("Please link this contact to a company before continuing.");
                return;
            }

            dealheader xDeal = dealheader.MakeManualDeal(x, TheCompanyVar.RefGet(x), this);
            x.Show(xDeal);
        }

        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            if (context.xUser.CheckPermit(context, "Company:Delete:Delete Contacts"))
                return true;

            return base.CanBeDeletedBy(context, args);
        }

        public static void MakeConsolidationReminder(ContextRz context, ArrayList contacts)
        {
            String strID = "";
            String strName = "";
            context.Sys.TheCompanyLogic.GetConsolidationReminderUser(context, ref strID, ref strName);
            if (!Tools.Strings.StrExt(strID))
                return;
            MakeConsolidationReminder(context, contacts, strID, strName);
        }

        public static void MakeConsolidationReminder(ContextRz context, ArrayList contacts, String strUserID, String strUserName)
        {
            focus_item f = focus_item.New(context);
            f.ItemType = FocusItemType.ContactConsolidation;
            f.the_n_user_uid = strUserID;
            f.user_name = strUserName;
            f.name = "Consolidate " + Tools.Number.LongFormat(contacts.Count) + " " + nTools.Pluralize("Contact", contacts.Count);
            foreach (companycontact x in contacts)
            {
                if (f.extra_info != "")
                    f.extra_info += "|";
                f.extra_info += x.unique_id;
                if (f.description != "")
                    f.description += ", ";
                f.description += x.contactname;
            }
            context.Insert(f);
            //if (context.xHook != null)
            //    context.xHook.SuggestFocusCheck(strUserID);
        }



        public static void InferFirstNames(ArrayList objects)
        {
            StringBuilder sb = new StringBuilder();
            foreach (companycontact c in objects)
            {
                sb.Append(c.contactname + "\t\t\t");
                sb.AppendLine(Tools.People.FirstNameParse(c.contactname));
            }
            Tools.FileSystem.PopText(sb.ToString());
        }
        //public static String InferFirstName(String s)
        //{
        //    Tools.People.FirstNameParse(s);
        //    String ret = nTools.NiceFormat(s);
        //    try
        //    {
        //        String x = nTools.Replace(s.Trim().Replace(".", " "), "  ", " ");
        //        if (nTools.StartsWith(x.ToLower(), "bad-") || x.ToLower().EndsWith("-bad"))
        //            return ret;
        //        if (Tools.Strings.HasString(x.ToLower(), "purchasing") || Tools.Strings.HasString(x.ToLower(), "manager"))
        //            return ret;
        //        while (Tools.Strings.HasString(x, "  "))
        //        {
        //            x = nTools.Replace(x.Trim(), "  ", " ");
        //        }
        //        String[] ary = Tools.Strings.Split(x, " ");
        //        if (ary.Length == 0)
        //            ret = nTools.NiceFormat(s);
        //        else if (ary.Length == 1)
        //            ret = nTools.NiceFormat(ary[0]);
        //        else if (ary.Length == 2)
        //            ret = nTools.NiceFormat(ary[0]);
        //        else if (ary.Length > 3)
        //            ret = s;
        //        switch (ary[0].ToLower())
        //        {
        //            case "mr":
        //            case "ms":
        //            case "mrs":
        //            case "col":
        //            case "lt":
        //            case "sgt":
        //            case "pvt":
        //                ret = nTools.NiceFormat(ary[1]);
        //                break;
        //            default:
        //                ret = nTools.NiceFormat(ary[0]);
        //                break;
        //        }
        //    }
        //    catch { return ret; }
        //    if (ret.Length >= 3)
        //        return ret;
        //    else
        //        return nTools.NiceFormat(s);
        //}

        public String GetPhoneCallSQL(ContextRz context, String strFields)
        {
            return GetPhoneCallSQL(context, strFields, null);
        }
        public String GetPhoneCallSQL(ContextRz context, String strFields, ArrayList userids)
        {
            String strStripPhone = nTools.StripPhoneNumber(this.primaryphone);
            if (!Tools.Strings.StrExt(strStripPhone))
                return "select top 1 " + strFields + " from phonecall where unique_id = 'not_an_id'";
            String strAltSQL = "select distinct(realphone) from alternatephone where phone = '" + strStripPhone + "'";
            String strStripAlt = nTools.StripPhoneNumber(alternatephone);
            if (Tools.Strings.StrExt(strStripAlt))
                strAltSQL += " or phone = '" + strStripAlt + "'";
            ArrayList numbers = context.SelectScalarArray(strAltSQL);
            ArrayList use = new ArrayList();
            use.Add(strStripPhone);
            if (Tools.Strings.StrExt(strStripAlt))
            {
                if (!use.Contains(strStripAlt))
                    use.Add(strStripAlt);
            }
            foreach (String p in numbers)
            {
                String s = nTools.StripPhoneNumber(p);
                if (Tools.Strings.StrExt(s))
                {
                    if (!use.Contains(s))
                        use.Add(s);
                }
            }
            if (!Tools.Strings.StrExt(strFields))
            {
                CoreClassHandle h = context.TheSys.CoreClassGet("phonecall");
                strFields = h.GetFieldList();
            }
            if (use.Count == 0)
                return "select top 1 " + strFields + " from phonecall where unique_id = 'not_an_id'";
            String ret = "select " + strFields + " from " + context.TheSysRz.ThePhoneLogic.GetPhoneCallTable() + " where strippedphone in ( " + nTools.GetIn(use) + " ) ";
            if (userids != null)
            {
                if (userids.Count > 0)
                    ret += " and base_mc_user_uid in ( " + nTools.GetIn(userids) + " ) ";
            }
            ret += " order by calldate desc";
            return ret;
        }

        //KT Refactored from RzSensible -> CompanyLogic.cs
        public static companycontact AddContact(Rz5.ContextRz x, Rz5.company comp)
        {
            Rz5.companycontact c = Rz5.companycontact.New(x);
            //c.CompanyObject = comp;
            c.companyname = comp.companyname;
            c.base_company_uid = comp.unique_id;
            c.primaryphone = comp.primaryphone;
            c.primaryfax = comp.primaryfax;
            c.primaryemailaddress = comp.primaryemailaddress;
            c.abs_type = comp.abs_type;
            c.isvendor = comp.isvendor;
            c.iscustomer = comp.iscustomer;
            Rz5.companyaddress a = comp.GetFirstAddress(x);
            if (a != null)
                c.AbsorbAddress(a);
            c.agentname = comp.agentname;
            c.base_mc_user_uid = comp.base_mc_user_uid;
            c.Insert(x);
            return c;
        }


        //public static String ParseFirstName(String s)
        //{
        //    s = s.ToLower().Replace(".", "").Replace("(ret)", "").Trim();
        //    while(s.Contains("  ") )
        //    {
        //        s = s.Replace("  ", " ");
        //    }
        //    int i = Tools.Strings.CharCount(s, ' ');
        //    switch (i)
        //    {
        //        case 1:
        //            return nTools.NiceFormat(Tools.Strings.ParseDelimit(s, " ", 1));
        //        default:
        //            switch (Tools.Strings.ParseDelimit(s, " ", 1).ToLower())
        //            {
        //                case "mr":
        //                case "mrs":
        //                case "ms":
        //                case "capt":
        //                case "dr":
        //                case "col":
        //                case "sgt":
        //                case "pvt":
        //                    return companycontact.ParseFirstName(nTools.ChopFront(s, Tools.Strings.ParseDelimit(s, " ", 1)));
        //                default:

        //                    if (s.EndsWith(" jr") || s.EndsWith(" sr"))
        //                    {
        //                        return companycontact.ParseFirstName(Tools.Strings.Left(s, s.Length - 3));
        //                    }
        //                    else
        //                    {
        //                        if (Tools.Strings.ParseDelimit(s, " ", 2).Replace(".", "").Length == 1)
        //                            return nTools.NiceFormat(Tools.Strings.ParseDelimit(s, " ", 1));
        //                        else
        //                            return nTools.NiceFormat(s);
        //                    }
        //            }
        //    }
        //}
    }
    public class ContactHandle
    {
        public String ID = "";
        public String Name = "";
        public String CompanyID = "";
        public String CompanyName = "";
        public ContactHandle(String strID, String strName, String strCompanyID, String strCompanyName)
        {
            ID = strID;
            Name = strName;
            CompanyID = strCompanyID;
            CompanyName = strCompanyName;
        }
        public ContactHandle(companycontact c)
        {
            ID = c.unique_id;
            Name = c.contactname;
            CompanyID = c.base_company_uid;
            CompanyName = c.companyname;
        }
    }
}