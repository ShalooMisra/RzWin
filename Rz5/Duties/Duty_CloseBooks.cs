using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewMethod;
using System.Collections;

namespace Rz5.Duties
{
    public class Duty_CloseBooks : nDuty
    {
        public Duty_CloseBooks()
            : base("CloseBooks", "CloseBooks")
        {

        }
        protected override void Run(ContextNM context)
        {
            ContextRz xrz = (ContextRz)context;
            base.Run(context);
            DateTime last = xrz.GetSettingDateTime("last_book_closing");
            if (!Tools.Dates.DateExists(last))//Never run before
                last = new DateTime(2012, 12, 31);//Start at Dec 31st 2012 (no one has this feature before then)         
            xrz.TheLeader.Comment("Last book closing date: " + last.ToShortDateString());
            SortedList dates_to_close = new SortedList();
            bool done = false;
            DateTime check = DateTime.Now;
            if (Tools.Dates.IsLaterDay(last, check))
            {
                xrz.TheLeader.Comment("Last book closing date is later than today!");
                throw new Exception("Last book closing date is later than today!");
            }
            while (!done)
            {
                DateTime dt = Tools.Dates.GetPreviousMonthEnd(check);
                if (!Tools.Dates.IsSameDay(dt, last))
                {
                    dates_to_close.Add(dt, dt);
                    check = dt;
                }
                else
                    done = true;
            }
            foreach (DictionaryEntry de in dates_to_close)
            {
                Tools.Dates.DateRange r = new Tools.Dates.DateRange(Tools.Dates.GetMonthStart((DateTime)de.Value), Tools.Dates.GetMonthEnd((DateTime)de.Value));                
                xrz.TheSysRz.TheAccountLogic.CloseTheBooks(xrz, r);
            }
        }
    }
}
