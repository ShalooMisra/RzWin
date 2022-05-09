using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class multisearch_siteorder : multisearch_siteorder_auto
    {
        public static multisearch_siteorder GetByName(ContextRz x, String strName)
        {
            if (!Tools.Strings.StrExt(strName))
                return null;
            return (multisearch_siteorder)x.TheData.QtO(x, "multisearch_siteorder", "select * from multisearch_siteorder where website = '" + strName + "'");
        }
    }
}
