using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class export_log : export_log_auto
    {
        public override string ToString()
        {
            if (export_rows == -1)
                return nTools.DateFormat(export_date) + " [ERROR]";
            else
                return nTools.DateFormat_ShortDateTime(export_date) + " [" + Tools.Number.LongFormat(export_rows) + "]";
        }
    }
}
