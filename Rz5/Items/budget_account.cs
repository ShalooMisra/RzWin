using System;
using System.Collections.Generic;
using System.Text;

using Core;

namespace Rz5
{
    public partial class budget_account : budget_account_auto
    {
        //Constructors
        public budget_account()
        {

        }
        //Public Override Functions
        public override void Updating(Context x)
        {
            base.Updating(x);
            annual_total = jan + feb + march + april + may + june + july + august + sept + oct + nov + december;
        }
        //Public Functions
        public void ClearBudget(ContextRz x)
        {
            if (!Tools.Strings.StrExt(unique_id))
                return;
            jan = 0;
            feb = 0;
            march = 0;
            april = 0;
            may = 0;
            june = 0;
            july = 0;
            august = 0;
            sept = 0;
            oct = 0;
            nov = 0;
            december = 0;
            Update(x);
        }
        public void ApplyValue(ContextRz x, double d)
        {
            if (!Tools.Strings.StrExt(unique_id))
                return;
            jan = d;
            feb = d;
            march = d;
            april = d;
            may = d;
            june = d;
            july = d;
            august = d;
            sept = d;
            oct = d;
            nov = d;
            december = d;
            Update(x);
        }
        public void ApplyPercent(ContextRz x, double d, double perc, bool decrease = false)
        {
            if (!Tools.Strings.StrExt(unique_id))
                return;
            if (decrease)
                d = d * -1;
            double v = (d * (perc / 100)) + d;
            jan = v;
            feb = v;
            march = v;
            april = v;
            may = v;
            june = v;
            july = v;
            august = v;
            sept = v;
            oct = v;
            nov = v;
            december = v;
            Update(x);
        }

    }
}
