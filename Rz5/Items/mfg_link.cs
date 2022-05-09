using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class mfg_link : mfg_link_auto
    {
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public static mfg_link GetByIDs(ContextNM x, String manufacturer_id, String company_id)
        {
            return (mfg_link)x.QtO("mfg_link", "select * from mfg_link where the_manufacturer_uid = '" + manufacturer_id + "' and the_company_uid = '" + company_id + "'");
        }
    }
}
