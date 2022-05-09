using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using NewMethod;

namespace Rz5
{
    public partial class companycredit : companycredit_auto
    {


        [CoreVarRefSingle("OrdhedVar", "Rz5.companycredit", "Rz5.ordhed", "CompanyCredits", "base_ordhed_uid")]
        [CoreVarRefSingle("CompanyVar", "Rz5.companycredit", "Rz5.company", "CompanyCredits", "base_company_uid")]

        VarRefSingle<companycredit, ordhed> OrdhedVar;
        VarRefSingle<companycredit, company> CompanyVar;

        //Constructor
        public companycredit()
        {
            OrdhedVar = new VarRefSingle<companycredit, ordhed>(this, new CoreVarRefSingleAttribute("Ordhed", "Rz5.companycredit", "Rz5.ordhed", "CompanyCredits", "base_ordhed_uid"));
            CompanyVar = new VarRefSingle<companycredit, company>(this, new CoreVarRefSingleAttribute("Company", "Rz5.companycredit", "Rz5.company", "CompanyCredits", "base_company_uid"));
        }

        public string GetCreditType(ordhed o)
        {
            switch (o.ordertype.ToLower())
            {
                case "purchase":
                case "service":
                    return "vendor_credit";
                case "rma":
                case "invoice":
                    return "customer_credit";
            }
            return null;
        }


        public override Var VarGetByName(string name)
        {
            switch (name)
            {
                case "ordhed":
                    return OrdhedVar;
                case "company":
                    return CompanyVar;
                default:
                    return base.VarGetByName(name);
            }
        }
    }
}
