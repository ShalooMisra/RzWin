using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class nQuery : NewMethod.nQuery
    {
        public override string ExportToHTML()
        {
            string file = base.ExportToHTML();
            RzWin.Form.BrowseWebAddress(file);
            return file;
        }
    }
}
