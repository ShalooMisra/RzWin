using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;
using Tools.Database;
using Core;

namespace Rz5
{
    public partial class blast_adrhed : blast_adrhed_auto
    {
        public static DataConnectionSqlServer DetailConnection(ContextRz context)
        {
            return context.Logic.MarketingConnection;
        }

        public void CalculateCounts(ContextRz context)
        {
            total_count = DetailConnection(context).GetScalar_Long("select count(*) from " + DetailTable);
            sent_count = DetailConnection(context).GetScalar_Long("select count(*) from " + DetailTable + " where isnull(was_sent, 0) = 1");
        }

        public String DetailTable
        {
            get
            {
                return "blast_adrdet_" + unique_id;
            }
        }

        List<String> alreadyAdded = null;
        public bool AddressAlreadyExists(ContextRz x, String address)
        {
            if (alreadyAdded == null)
            {
                alreadyAdded = new List<string>();
                ArrayList a = DetailConnection(x).GetScalarArray("select email_adr from " + DetailTable);
                foreach (String s in a)
                {
                    String ss = s.Trim().ToLower();
                    if (!alreadyAdded.Contains(ss))
                        alreadyAdded.Add(ss);
                }
            }

            return alreadyAdded.Contains(address.Trim().ToLower());
        }

        public blast_adrdet AddAddress(ContextRz x, String strAddress, String company_id, String contactname)
        {
            if (AddressAlreadyExists(x, strAddress))
                return null;

            alreadyAdded.Add(strAddress.Trim().ToLower());

            blast_adrdet a = blast_adrdet.New(x);
            a.the_blast_adrhed_uid = this.unique_id;
            a.list_name = this.list_name;
            a.email_adr = strAddress;
            a.domain_name = nTools.ParseEmailDomain(strAddress);
            a.the_company_uid = company_id;
            a.contact_name = contactname;
            //a.contact_first_name = companycontact.ParseFirstName(contactname);  //done in beforesafe
            a.InsertTo(x, DetailConnection(x), DetailTable);
            return a;
        }

        public void MakeDetailTableExist(ContextRz context)
        {
            DataSql.StructureCheckClass(context, DetailConnection(context), context.TheSys.CoreClassGet("blast_adrdet"), DetailTable);
            //xSys.MakeClassDataStructure(c, DetailConnection, false, );
        }

        public blast_adrdet GetAddressByAddress(ContextRz context, String strAddress)
        {
            return GetAddressBySQL(context, "select * from " + DetailTable + " where email_adr = '" + context.Filter(strAddress) + "'");
        }

        public blast_adrdet GetAddressByID(ContextRz context, String strID)
        {
            return GetAddressBySQL(context, "select * from " + DetailTable + " where unique_id = '" + context.Filter(strID) + "'");
        }

        public blast_adrdet GetAddressBySQL(ContextRz context, String strSQL)
        {
            DataTable d = DetailConnection(context).Select(strSQL);
            if (!Tools.Data.DataTableExists(d))
                return null;

            blast_adrdet r = blast_adrdet.New(context);
            r.AbsorbRow(context, d.Rows[0]);
            return r;
        }

        public void AddAddressesFromSQL(ContextRz context, String strSQL)
        {
            try
            {
                String strInsert = "insert into " + DetailTable + " (email_adr) " + strSQL;
                DetailConnection(context).Execute(strInsert);

                CleanTheDetails(context);
            }
            catch { }
        }

        public void CleanTheDetails(ContextRz context)
        {
            DetailConnection(context).Execute("update " + DetailTable + " set email_adr = LTRIM(RTRIM(email_adr))");
            DetailConnection(context).Execute("delete from " + DetailTable + " where isnull(email_adr, '') not like '%_@%_%._%'");
            DetailConnection(context).Execute("delete from " + DetailTable + " where isnull(email_adr, '') like '.%'");

            //domains
            DetailConnection(context).Execute("delete x from " + DetailTable + " x inner join domain d on d.domain_name = x.domain_name where isnull(d.always_exclude, 0) = 1 or ( isnull(d.always_dist, 0) = 0 and isnull(d.always_market, 0) = 0 )");

            //unsubscribes
            if (DetailConnection(context).TableExists("unsubscribe"))
            {
                DetailConnection(context).Execute("delete x from " + DetailTable + " x inner join unsubscribe d on isnull(d.emailaddress, '') = isnull(x.email_adr, '')");
            }

            //do not emails / bad records
            DetailConnection(context).Execute("delete x from " + DetailTable + " x inner join companycontact d on isnull(d.primaryemailaddress, '') = isnull(x.email_adr, '') where isnull(d.donotemail, 0) = 1 or isnull(d.donotpromote, 0) = 1 or d.agentname = 'bad record'");

            DetailConnection(context).Execute("update " + DetailTable + " set unique_id = cast(newid() as varchar(50)) where isnull(unique_id, '') = ''");
            DetailConnection(context).SplitEmailDomain(DetailTable, "email_adr", "domain_name");
        }

        public void ClearByAlpha(ContextRz context, String strBar)
        {
            DetailConnection(context).Execute("delete from " + DetailTable + " where isnull(email_adr, '') < '" + context.Filter(strBar) + "%'");
        }

        public virtual void AbsorbContactInfo(ContextRz context)
        {
            context.Logic.MarketingConnection.MakeFieldExist(DetailTable, "the_companycontact_uid", 1, 255);
            context.Logic.MarketingConnection.MakeFieldExist(DetailTable, "the_company_uid", 1, 255);
            String strSQL = "update x set ";
            strSQL += "    x.the_companycontact_uid = c.unique_id, ";
            strSQL += "    x.company_name = c.companyname, ";
            strSQL += "    x.contact_name = c.contactname, ";
            strSQL += "    x.agent_name = c.agentname ";
            strSQL += "    from " + DetailTable + " x join companycontact c on c.primaryemailaddress = x.email_adr";
            context.Logic.MarketingConnection.Execute(strSQL);
            strSQL = "update x set ";
            strSQL += "    x.the_company_uid = c.unique_id, ";
            strSQL += "    x.company_name = c.companyname, ";
            strSQL += "    x.contact_name = c.primarycontact, ";
            strSQL += "    x.agent_name = c.agentname ";
            strSQL += "    from " + DetailTable + " x join company c on c.primaryemailaddress = x.email_adr";
            strSQL += "    where isnull(x.company_name, '') = '' and isnull(x.contact_name, '') = '' ";
            context.Logic.MarketingConnection.Execute(strSQL);
            strSQL = "update x set ";
            strSQL += "    x.agent_email = u.email_address ";
            strSQL += "    from " + DetailTable + " x join n_user u on u.name = x.agent_name";
            context.Logic.MarketingConnection.Execute(strSQL);
            context.TheSysRz.TheEmailLogic.AddContactInfoExtra(context, DetailTable);
            if (!context.Logic.MarketingConnection.FieldExists(DetailTable, "contact_first_name"))
                context.Logic.MarketingConnection.MakeFieldExist(DetailTable, "contact_first_name", (Int32)FieldType.String, 255);
            DataTable d = context.Logic.MarketingConnection.Select("select unique_id, contact_name from " + DetailTable);
            foreach (DataRow r in d.Rows)
            {
                context.Logic.MarketingConnection.Execute("update " + DetailTable + " set contact_first_name = '" + context.Logic.MarketingConnection.SyntaxFilter(Tools.People.FirstNameParse(nData.NullFilter(r["contact_name"]))) + "' where unique_id = '" + nData.NullFilter(r["unique_id"]) + "'");
            }
        }

        public void FindAgent(ContextRz context)
        {
            context.Logic.MarketingConnection.MakeFieldExist(DetailTable, "the_companycontact_uid", 1, 255);
            context.Logic.MarketingConnection.MakeFieldExist(DetailTable, "the_company_uid", 1, 255);

            String strSQL = "update x set ";
            strSQL += "    x.agent_name = c.agentname ";
            strSQL += "    from " + DetailTable + " x join companycontact c on c.primaryemailaddress = x.email_adr where isnull(c.agentname, '') not like '%recognin%'";

            context.Logic.MarketingConnection.Execute(strSQL);

            strSQL = "update x set ";
            strSQL += "    x.agent_email = u.email_address ";
            strSQL += "    from " + DetailTable + " x join n_user u on u.name = x.agent_name where isnull(x.agent_name, '') not like '%recognin%'";

            context.Logic.MarketingConnection.Execute(strSQL);

            context.TheSysRz.TheEmailLogic.AddContactInfoExtra(context, DetailTable, true);
        }

        public void SetAgent(ContextRz context, NewMethod.n_user u)
        {
            context.Logic.MarketingConnection.Execute("update " + DetailTable + " set agent_name = '" + context.Filter(u.name) + "', agent_email = '" + context.Filter(u.email_address) + "'");
            context.TheSysRz.TheEmailLogic.AddAgentInfoExtra(context, DetailTable);
        }

        public void SetReplyTo(ContextRz context, String reply)
        {
            context.Logic.MarketingConnection.Execute("update " + DetailTable + " set reply_to_address = '" + context.Filter(reply) + "'");
        }

        public void SetFromAddress(ContextRz context, String from)
        {
            context.Logic.MarketingConnection.Execute("update " + DetailTable + " set agent_email = '" + context.Filter(from) + "'");
        }

        public void MarkUnsent(ContextRz context)
        {
            context.Logic.MarketingConnection.Execute("update " + DetailTable + " set was_sent = 0");
        }

        public void AbsorbWebsiteInfo(ContextRz context)
        {
            //check the website member update
            context.Logic.CheckWebMemberCache(context);

            //get the web login       --d.website_login

            String strSQL = "update x set x.website_login = y.username, x.website_password = y.password from " + DetailTable + " x join logins y on y.email = x.email_adr";
            context.Logic.MarketingConnection.Execute(strSQL);
        }
    }
}
