using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class manufacturer : manufacturer_auto
    {
        public static manufacturer GetByName(ContextNM x, String name)
        {
            return (manufacturer)x.QtO("manufacturer", "select * from manufacturer where manufacturer_name = '" + x.TheData.Filter(name) + "'");
        }
    }
}
