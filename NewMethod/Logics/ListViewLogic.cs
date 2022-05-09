using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace NewMethod
{
    public class ListViewLogic
    {
        public virtual ActArgs GetRunActionKeyActArgs(ContextNM x, string key)   //, InList lv  need something else here; the nList is desktop-specific
        {
            ActArgs args = new ActArgs(key);
            args.TheContext = x;  //temporary
            return args;
        }
        
        //public virtual string GetCurrencySymbol()
        //{
        //    return SysNewMethod.ContextDefault.TheSys.CurrencySymbol;
        //}
    }
}
