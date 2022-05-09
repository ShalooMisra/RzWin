using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class ordhit : ordhit_auto
    {
        public ordhed LinkedOrder;

        //Public Functions
        public void LoadLinkedOrder(ContextRz context)
        {
            LinkedOrder = null;
            if (!Tools.Strings.StrExt(the_ordhed_uid))
                return;
            LinkedOrder = ordhed.GetById(context, the_ordhed_uid);
        }
    }
}
