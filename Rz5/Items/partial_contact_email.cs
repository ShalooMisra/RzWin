using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class partial_contact_email : partial_contact_email_auto
    {
        public static void Clean(ContextNM context)
        {
            context.TheLeader.Comment("Cleaning existing...");
            String strSQL = "delete x from partial_contact_email x inner join companycontact c on isnull(c.primaryemailaddress, '') = x.primaryemailaddress";

            context.Execute(strSQL);

            //context.TheLeader.Comment(Tools.Number.LongFormat(l) + " existing addresses removed.");

            context.TheLeader.Comment("Cleaning distributors...");
            strSQL = "delete x from partial_contact_email x inner join domain c on isnull(c.domain_name, '') = x.email_domain where ( isnull(c.always_dist, 0) = 1 or isnull(c.always_exclude, 0) = 1 )";
            context.Execute(strSQL);

            //context.TheLeader.Comment(Tools.Number.LongFormat(l) + " dist addresses removed.");

            context.TheLeader.Done();
        }

    }
}
