using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;
using CoreDevelop;

namespace CoreDevelopWin
{
    public class ContextDevelop : CoreDevelop.ContextDevelop
    {
        public override String ClassChoose(CoreDevelop.ContextDevelop context, BoxSys sys, BoxClass from)
        {
            if (context == null)
                return "";
            return ClassChooser.ChooseAClassName(context, sys, from, "Choose the class to relate to.");
        }
    }
}
