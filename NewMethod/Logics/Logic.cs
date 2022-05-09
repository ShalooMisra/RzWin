using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;

namespace NewMethod
{
    public class Logic : Core.LogicCore
    {
        public override void ActInstance(Context x, ActArgs args)
        {
            if (args.Handled)
                return;

            base.ActInstance(x, args);
            if (args.Handled)
                return;

            SysNewMethod.ActInstanceNM(x, args);
        }
        //public virtual bool DoOriginalClear_nEditMoney()
        //{
        //    return false;
        //}
        //public override void ActInstance(Context x, ActArgs args)
        //{
        //    base.ActInstance(x, args);
        //    if (args.Handled)
        //        return;

        //    if (args.TheAct == null || args.TheAct.Handler == null)
        //    {
        //        args.TheContext = x;
        //        foreach (nObject n in args.TheItems.AllGet(x))
        //        {
        //            n.HandleAction(args);
        //        }

        //        ActInstanceRecallLog(x, args);
        //    }
        //}

        //public void ActInstanceRecallLog(Context x, ActArgs args)
        //{
        //    ContextNM xnm = (ContextNM)x;
        //    if (xnm.xSys.Recall)
        //    {
        //        foreach (IItem i in args.TheItems.AllGet(x))
        //        {
        //            xnm.xSys.RecallActionLog(i, args.ActionName, xnm.xUser);
        //        }
        //    }
        //}
    }
}
