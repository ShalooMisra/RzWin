using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Rz5;
using Core;

namespace Rz5.Reports
{
    public class SupplierEvaluation : Report
    {
        public SupplierEvaluation(ContextRz context)
            : base(context)
        {

        }

        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Vendor"));
            ColumnAdd(new ReportColumn("PO #"));
            ColumnAdd(new ReportColumn("Expected Date"));
            ColumnAdd(new ReportColumn("Receive Date"));
            ColumnAdd(new ReportColumn("Status"));
            ColumnAdd(new ReportColumn("Part"));
            ColumnAdd(new ReportColumn("Quantity", ColumnAlignment.Right));
        }

        ReportTotalPercent OnTime;
        protected override void InitTotals()
        {
            base.InitTotals();
            OnTime = new ReportTotalPercent("On Time");
            Totals.Add(OnTime);

            OnTime.CaptionColumn = ColumnIndex("Receive Date");
            OnTime.ValueColumn = ColumnIndex("Status");
        }

        public override void CalculateLines(Context context, ReportArgs args)
        {
            base.CalculateLines(context, args);

            SupplierEvaluationArgs argsx = (SupplierEvaluationArgs)args;

            //orddet_line ll;
            //ll.receive_date_due
            //    ;
            //ll.receive_date_actual
            //    ;

            String sql = "select * from orddet_line where isnull(ordernumber_purchase, '') > '' and was_received = 1 and isnull(receive_date_due, '1/1/1900') > '1/2/1900' and status not in ('Void') ";

            //and isnull(receive_date_actual, '1/1/1900') > '1/2/1900'

            if (argsx.ExpectedDate.TheRange.Valid)
                sql += " and " + argsx.ExpectedDate.TheRange.GetSQL("receive_date_due");

            if (Tools.Strings.StrExt(argsx.Vendor.TheID))
                sql += " and vendor_uid = '" + context.Filter(argsx.Vendor.TheID) + "'";

            sql += " order by receive_date_due";

            int totalCount = 0;
            int onTimeCount = 0;


            foreach (orddet_line l in context.QtC("orddet_line", sql))
            {
                bool onTime = false;
                bool scheduled = false;

                if (!Tools.Dates.DateExists(l.receive_date_actual) && !Tools.Dates.IsEarlierDay(l.receive_date_due, DateTime.Now))
                    scheduled = true;
                else if (!Tools.Dates.IsLaterDay(l.receive_date_actual, l.receive_date_due)) ;
                onTime = true;

                ReportLine rl = new ReportLine();
                rl.SetInc(l.vendor_name, new Core.ItemTag("company", l.vendor_uid));
                rl.SetInc(l.ordernumber_purchase, new Core.ItemTag("ordhed_purchase", l.orderid_purchase));
                rl.SetInc(l.receive_date_due);
                rl.SetInc(l.receive_date_actual);

                if (scheduled)
                {
                    rl.ForeColor = Color.DarkGray;
                    rl.SetInc("SCHEDULED");
                }
                if (onTime)
                {
                    rl.ForeColor = Color.Green;
                    rl.SetInc("ON TIME");
                }
                else
                {
                    rl.ForeColor = Color.Red;
                    rl.SetInc("LATE");
                }

                rl.SetInc(l.fullpartnumber);
                rl.SetInc(l.quantity);

                Lines.Add(rl);

                totalCount++;
                if (onTime)
                    onTimeCount++;
            }

            //ColumnAdd(new ReportColumn("PO #"));
            //ColumnAdd(new ReportColumn("Expected Date"));
            //ColumnAdd(new ReportColumn("Receive Date"));
            //ColumnAdd(new ReportColumn("Status"));
            //ColumnAdd(new ReportColumn("Part"));
            //ColumnAdd(new ReportColumn("Quantity", ColumnAlignment.Right));

            OnTime.Caption = Tools.Number.LongFormat(onTimeCount) + " On Time | " + Tools.Number.LongFormat(totalCount) + " Total";
            OnTime.Value = Tools.Number.CalcPercent(totalCount, onTimeCount);
        }

        public override ReportArgs ArgsCreate(Context context)
        {
            return new SupplierEvaluationArgs((ContextRz)context);
        }

        public override string Title
        {
            get
            {
                return "Supplier Evaluation";
            }
        }

        public override string Description
        {
            get
            {
                return "Compares the vendor promised delivery dates with the actual receive dates.";
            }
        }
    }

    public class SupplierEvaluationArgs : ReportArgs
    {
        public ReportCriteriaDateRange ExpectedDate;
        public ReportCriteriaCompany Vendor;

        public SupplierEvaluationArgs(ContextRz context)
            : base(context)
        {
            ExpectedDate = new ReportCriteriaDateRange("Expected Date");
            ExpectedDate.DefaultOption = "Month To Date";
            ExpectedDate.TheRange = Tools.Dates.DateRange.MonthToDate;
            Criteria.Add(ExpectedDate);

            Vendor = new ReportCriteriaCompany("Vendor");
            Vendor.NameColumn = 0;
            Criteria.Add(Vendor);
        }
    }
}
