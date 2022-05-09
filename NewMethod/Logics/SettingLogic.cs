using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace NewMethod
{
    public class SettingLogic : Core.Logic
    {
        public SettingLogic()
        {
            ActsInstance.Add(new Act("Set", Set));
            ActsInstance.Add(new Act("Clear", Set));
        }

        public virtual void Set(Context x, ActArgs args)
        {
            String last = ((n_set)args.TheItems.AllGet(x)[0]).setting_value;

            String v = x.TheLeader.AskForString("New Value", last, true);
            if (!Tools.Strings.StrExt(v))
                return;

            foreach (n_set s in args.TheItems.AllGet(x))
            {
                s.Set((ContextNM)x, v);
            }
        }

        public virtual void Clear(Context x, ActArgs args)
        {
            foreach (n_set s in args.TheItems.AllGet(x))
            {
                s.Clear((ContextNM)x);
            }
        }

        //public override void HandleAction(ActArgs args)
        //{
        //    switch (args.ActionName.ToLower())
        //    {
        //        case "copytouser":
        //            n_user u = n_user.Choose(xSys, xSys.xMainForm, true);
        //            if (u == null)
        //                return;
        //            n_set.Do_CopyToUser((ContextNM)args.TheContext, this, u);
        //            context.TheLeader.Tell("Done.");
        //            break;
        //        case "clear":
        //            setting_value = "";
        //            ISave();
        //            break;
        //        case "set":
        //            String s = args.TheContext.TheLeader.AskForString("New value?");
        //            if (!Tools.Strings.StrExt(s))
        //                return;
        //            setting_value = s;
        //            ISave();
        //            break;
        //        default:
        //            base.HandleAction(args);
        //            break;
        //    }
        //}

    }
}
