using System;
using System.Collections.Generic;
using System.Text;

using Core;

namespace CoreDevelop
{
    public class ContextDevelop : Context
    {
        public override Context Create()
        {
            return new ContextDevelop();
        }

        public DeltaDevelop TheDeltaDevelop
        {
            get
            {
                return (DeltaDevelop)TheDelta;
            }
        }

        public virtual String ClassChoose(ContextDevelop context, BoxSys sys, BoxClass from)
        {
            if (context == null)
                return "";
            return context.TheLeader.AskForString("Class Name");
        }
    }
}
