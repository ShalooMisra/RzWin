using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;

namespace NewMethod
{
    public partial class n_permit : n_permit_auto
    {
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
