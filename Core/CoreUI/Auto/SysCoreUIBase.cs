using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace CoreUI
{
    [CoreSys("CoreUI")]
    public partial class SysCoreUIBase : Sys
    {
        protected override void AssemblyList(List<Assembly> ret)
        {
            ret.Add(Assembly.GetExecutingAssembly());
            base.AssemblyList(ret);
        }
    }
}
