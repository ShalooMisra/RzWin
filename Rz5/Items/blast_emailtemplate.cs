using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class blast_emailtemplate : blast_emailtemplate_auto
    {
        public static blast_emailtemplate GetByName(ContextRz context, String strTemplateName)
        {
            return (blast_emailtemplate)context.QtO("blast_emailtemplate", "select * from blast_emailtemplate where template_name = '" + context.TheData.Filter(strTemplateName) + "'");           
        }
    }
}
