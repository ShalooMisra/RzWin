using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace CoreDevelop
{
    public class SysCoreDevelop : Sys
    {
        public override Assembly AssemblyGetHere()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
