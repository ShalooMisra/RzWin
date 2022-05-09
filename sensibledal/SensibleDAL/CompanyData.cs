
using SensibleDAL.dbml;
using System.Collections.Generic;
using System.Linq;


namespace SensibleDAL
{
    
    class CompanyData
    {
        RzDataContext rdc = new RzDataContext();
        public company GetCompanyByID(string s)
        {
            return rdc.companies.Where(w => w.unique_id == s).FirstOrDefault();
        }
        
    }  
}
