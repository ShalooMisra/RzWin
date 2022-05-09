using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tools;
using Core;
using NewMethod;

namespace Rz5
{
    public class UrlLogic
    {
        public virtual void NavigateHandle(ContextRz context, GenericEvent e)
        {
            if (Tools.Strings.HasString(e.Message, "partsearch.rzs"))
            {
                context.TheSysRz.ThePartLogic.PartSearchShow(context, new PartSearchShowArgs(Tools.Strings.ParseDelimit(e.Message, "partnumber=", 2)));
                e.Handled = true;
            }
            else if (Tools.Strings.HasString(e.Message, "viewcontact.rzs"))
            {
                e.Handled = true;
                String strID = Tools.Strings.ParseDelimit(e.Message, "uid=", 2);

                companycontact x = companycontact.GetById(context, strID);
                if (x == null)
                    return;

                context.Show(x);
            }
        }
    }
}
