using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;
using Rz5;

namespace Rz5
{
    public partial class company_terms_conditions : company_terms_conditions_auto
    {
        public static company_terms_conditions GetByCompanyID(ContextNM x, string s)
        {
            company_terms_conditions ret = null;
            string sql = "select * from company_terms_conditions where company_uid = '" + s + "'";
            ret = (company_terms_conditions)x.QtO("company_terms_conditions", sql);
            return ret;
        }

    }
}
