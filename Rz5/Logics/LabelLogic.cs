using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using NewMethod;

namespace Rz5
{
    public class LabelLogic : NewMethod.Logic
    {
        public override void ActInstance(Context x, ActArgs args)
        {
            ArrayList objects = new ArrayList();
            foreach (IItem i in args.TheItems.AllGet((ContextRz)x))
            {
                objects.Add(i);
            }
            switch (args.ActionName.Trim().ToLower())
            {
                case "exportaddresslist":
                    label_queue.ExportAddressList(objects);
                    break;
                default:
                    base.ActInstance(x, args);
                    break;
            }
        }

    }
}
