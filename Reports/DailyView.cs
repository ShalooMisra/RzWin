using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Reports
{
    public partial class DailyView : UserControl, ICompleteLoad
    {
        public SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.xSys;
            }
        }

        public DailyView()
        {
            InitializeComponent();
        }

        ArrayList LineControls = new ArrayList();
        public void CompleteLoad()
        {
            DateTime d = DateTime.Now;

            //Anyone with phone time for the day
            ArrayList ids = RzWin.Context.SelectScalarArray("select distinct base_mc_user_uid, username from phonecall where datediff(d, calldate, cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(d) + "' as datetime)) = 0 order by username");
            if (ids.Count == 0)
            {
                return;
            }

            foreach (String s in ids)
            {
                n_user u = (n_user)xSys.Users.GetByID(s);
                if (u != null)
                {
                    LoadOneLine(u);
                }
            }
        }

        void LoadOneLine(n_user u)
        {
            DailyViewLine l = new DailyViewLine();
            LineControls.Add(l);
            fp.Controls.Add(l);
            l.CompleteLoad(u);
        }
    }
}
