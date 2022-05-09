using System;
using System.Collections.Generic;
using System.Text;

using Core;
using System.Collections;

namespace Rz5
{
    public partial class oem_product : oem_product_auto
    {
        //Private Variables

        //Constructors
        public oem_product()
        {

        }

        //Public Static Functions

        public static oem_product GetByName(ContextRz context, string name)
        {
            if (!Tools.Strings.StrExt(name))
                return null;
            return (oem_product)context.QtO("oem_product", "select * from oem_product where oem_product_name = '" + context.Filter(name) + "'");
        }
        public static oem_product GetByID(ContextRz context, string productID)
        {
            return (oem_product)context.QtO("oem_product", "select * from oem_product where oem_product_uid = '" + context.Filter(productID) + "'");
        }
        //Public Functions       

    }
}
