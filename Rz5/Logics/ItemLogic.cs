using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewMethod;

namespace Rz5
{
    public class ItemLogic : NewMethod.ItemLogic
    {
        public override bool ColorPossible(string classId)
        {
            switch (classId)
            {
                case "orddet_line":
                case "partrecord":
                    return false;
                default:

                    if (classId.StartsWith("ordhed_"))
                        return false;

                    return base.ColorPossible(classId);
            }
        }

        public override bool OpenPossible(Core.Context x, Core.ActSetup set)
        {
            foreach (nObject n in set.TheItems.AllGet(x))
            {
                if (!n.CanBeViewedBy((ContextNM)x))
                    return false;
            }

            return base.OpenPossible(x, set);
        }
    }
}
