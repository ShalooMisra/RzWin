using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using NewMethod;

namespace Rz5
{
    public partial class portal_searched_part : portal_searched_part_auto
    {
       
        //[CoreVarRefSingle("AppliedToOrder", "Rz5.companycredit", "Rz5.ordhed", "CompanyCredits", "applied_to_order_uid")]
        [CoreVarRefMany("CompanyVar", "Rz5.portal_searched_part", "Rz5.Company", "PortalSearchedParts", "company_uid")]       


        //VarRefSingle<companycredit, ordhed> AppliedToOrderVar;
        VarRefMany<portal_searched_part, company> CompanyVar;

        //Constructor
        public portal_searched_part()
        {
            //AppliedToOrderVar = new VarRefSingle<companycredit, ordhed>(this, new CoreVarRefSingleAttribute("AppliedToOrder", "Rz5.companycredit", "Rz5.ordhed", "CompanyCredits", "applied_to_order_uid"));
            CompanyVar = new VarRefMany<portal_searched_part, company>(this, new CoreVarRefManyAttribute("company", "Rz5.portal_searched_part", "Rz5.company", "PortalSearchedParts", "company_uid"));
        }      

        public override Var VarGetByName(string name)
        {
            switch (name)
            {
                //case "appliedtoorder":
                //    return AppliedToOrderVar;
                case "company":
                    return CompanyVar;
                default:
                    return base.VarGetByName(name);
            }
        }
    }
}
