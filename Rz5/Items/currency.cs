using System;
using System.Collections.Generic;
using System.Text;

using Core;
using System.Data;

namespace Rz5
{
    public partial class currency : currency_auto
    {
        public currency()
        {

        }

        public override void Updating(Context x)
        {
            base.Updating(x);
            name = name.ToUpper();
        }

        //this is what will always be used; the user enters the foreign amount and the base amount is auto calculated
        public static double CalculateExchangeFromForeign(Double foreignValue, Double rate, int decimals)
        {
            return Math.Round(foreignValue / rate, decimals);  //DecimalCount(foreignValue)
        }

        //this is only used in the interface to show the user what the exchange value would be for a given base value
        public static double CalculateExchangeFromBase(Double baseValue, Double rate, int decimals)
        {
            return Math.Round(baseValue * rate, decimals);
        }

        //this seemed like a good idea
        //static int DecimalCount(Double value)
        //{
        //    String s = value.ToString();
        //    if (!s.Contains("."))
        //        return 2;  //the default for any monetary value

        //    int ret = Tools.Strings.ParseDelimit(s, ".", 2).Length;
        //    if (ret < 2)
        //        ret = 2;

        //    return ret;
        //}

        public override void HandleAction(ActArgs args)
        {
            base.HandleAction(args);

            ContextRz xrz = (ContextRz)args.TheContext;

            switch (args.ActionName.ToLower())
            {
                case "viewratehistory":
                    ShowRateHistory(xrz);
                    break;
            }
        }

        public void ShowRateHistory(ContextRz context)
        {
            if (!context.TheData.TableExists("currency_history"))
            {
                context.Leader.Tell("This system isn't configured for historical exchange rate tracking");
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"1\" cellpadding=\"2\" cellspacing=\"2\"><tr><td>Date</td><td>Rate</td><td>Inverse</td></tr>");
            foreach (DataRow r in context.Select("select * from currency_history where name = '" + name + "' order by date_created desc").Rows)
            {
                Double rate = Tools.Data.NullFilterDouble(r["exchange_rate"]);
                sb.AppendLine("<tr><td>" + Tools.Dates.DateFormat(Tools.Data.NullFilterDate(r["date_created"])) + "</td><td>" + rate.ToString() + "</td><td>" + currency.Inverse(rate).ToString() + "</td></tr>");
            }
            sb.AppendLine("</table>");
            context.Leader.ShowHtml(context, "Rate history: " + name.ToUpper(), sb.ToString());
        }

        public static Double Inverse(Double baseRate)
        {
            return Math.Round(1.0f / baseRate, 6);
        }
    }
}
