

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

//using Tie;
using NewMethod;
//using CoreWin;

namespace Rz5
{
    public class RzLinkDuty : nDuty
    {
        //Constructors
        public RzLinkDuty() : base("RzLink", "RzLink")
        {

        }
        //Public Override Functions
        protected override void Run(ContextNM context)
        {
            base.Run(context);
            string msg = "";
            ((ContextRz)context).TheSysRz.TheLinkLogic.Export((ContextRz)context, ref msg);
        }
    }
}
