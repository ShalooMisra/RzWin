using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class partial_contact_surfacemail : partial_contact_surfacemail_auto
    {
        public static partial_contact_surfacemail GetByIpAddress(ContextNM x, String ip)
        {
            return (partial_contact_surfacemail)x.QtO("partial_contact_surfacemail", "select * from partial_contact_surfacemail where ip_address = '" + x.Filter(ip) + "'");
        }
    }
}
