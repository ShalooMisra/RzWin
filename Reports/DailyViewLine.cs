using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Reports
{
    public partial class DailyViewLine : UserControl
    {
        virtual_desk vd;

        public DailyViewLine()
        {
            InitializeComponent();
        }

        public void CompleteLoad(n_user u)
        {           
            vd = (virtual_desk)RzWin.Context.QtO("virtual_desk", "select top 1 * from virtual_desk where the_n_user_uid = '" + u.unique_id + "'");
            if( vd == null )
            {
                vd = new virtual_desk();
                vd.the_n_user_uid = u.unique_id;
            }

            //xDesk.CompleteLoad(null, vd);
        }
    }
}
