using System;
using System.Linq;
using Rz5;
using SensibleDAL.dbml;

namespace SensibleDAL
{
    internal class AfiliateLogic
    {
        internal static void GetAffiliateFromContact(string contactID, out string affiliate_id, out string affiliate_name)
        {
            affiliate_id = null;
            affiliate_name = null;
            dbml.companycontact cont = null;
            using (RzDataContext z = new RzDataContext())
                cont = z.companycontacts.Where(w => w.unique_id == contactID).FirstOrDefault();
            if (cont == null)
                return;   

            affiliate_id = cont.affiliate_id;
            affiliate_name = cont.affiliate_name;

            
        }

    }
}