using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data;
using Rz5.Enums;
using Tools.Database;

namespace Rz5.Reports
{
    public class ArApAging : Rz5.Report
    {
        //Private Variables
        private bool Ap = false;
        private Dictionary<String, List<DataRow>> TempList;

        //Constructors
        public ArApAging(ContextRz context, bool ap = false)
            : base(context)
        {
            Ap = ap;
        }
        //Public Override Functions
        public override void CalculateLines(Context context, ReportArgs args)
        {
            base.CalculateLines(context, args);
            ContextRz xr = (ContextRz)context;
            TempList = new Dictionary<string, List<DataRow>>();
            if (Ap)
            {
                GatherRows(xr, OrderType.Purchase);
                GatherRows(xr, OrderType.RMA);
            }
            else
            {
                GatherRows(xr, OrderType.Invoice);
                GatherRows(xr, OrderType.VendRMA);
            }
            List<String> companyNames = new List<string>();
            foreach (KeyValuePair<String, List<DataRow>> k in TempList)
            {
                String companyName = Tools.Data.NullFilterString(k.Value[0]["companyname"]).ToLower();
                if (!companyNames.Contains(companyName))
                    companyNames.Add(companyName);
            }
            foreach (String c in companyNames)
            {
                AddCompanyLine(xr, c);
            }
        }
        public override string Title
        {
            get
            {
                string type = "Receivable";
                if (Ap)
                    type = "Payable";
                return "Accounts " + type + " Aging";
            }
        }
        //Protected Override Functions
        protected override void InitColumns(Core.Context context)
        {
            if (Ap)
                ColumnAdd("Vendor");
            else
                ColumnAdd("Customer");
            ColumnAdd("Current", ValueUse.TotalMoney);
            ColumnAdd("1 - 30", ValueUse.TotalMoney);
            ColumnAdd("31 - 60", ValueUse.TotalMoney);
            ColumnAdd("61 - 90", ValueUse.TotalMoney);
            ColumnAdd("90 - 120", ValueUse.TotalMoney);
            ColumnAdd("> 120", ValueUse.TotalMoney);
            ColumnAdd("Total", ValueUse.TotalMoney);
        }
        protected override void InitTotals()
        {
            base.InitTotals();
            AutoTotal("Current");
            AutoTotal("1 - 30");
            AutoTotal("31 - 60");
            AutoTotal("61 - 90");
            AutoTotal("90 - 120");
            AutoTotal("> 120");
            AutoTotal("Total");
        }
        //Private Functions
        private void GatherRows(ContextRz context, OrderType type)
        {
            string date = "ship_date_actual";
            if (Ap)
                date = "receive_date_actual";
            DataTable d = context.Select("select base_company_uid, companyname, " + date + ", outstandingamount, days_to_pay from ordhed_" + type.ToString().ToLower() + " where isnull(isvoid, 0) = 0 and isnull(ispaid, 0) = 0 and outstandingamount > 0 and isnull(isclosed, 0) = 1 order by companyname");
            foreach (DataRow r in d.Rows)
            {
                String companyId = Tools.Data.NullFilterString(r["companyname"]);
                List<DataRow> tempRows = null;
                if (!TempList.ContainsKey(companyId))
                {
                    tempRows = new List<DataRow>();
                    TempList.Add(companyId, tempRows);
                }
                else
                    tempRows = TempList[companyId];
                tempRows.Add(r);
            }
        }
        private void AddCompanyLine(ContextRz context, String companyName)
        {
            foreach (KeyValuePair<String, List<DataRow>> k in TempList)
            {
                String groupCompany = Tools.Data.NullFilterString(k.Value[0]["companyname"]);
                String compID = Tools.Data.NullFilterString(k.Value[0]["base_company_uid"]);
                if (!Tools.Strings.StrCmp(groupCompany, companyName))
                    continue;
                Double currentAmount = 0;
                Double oneToThirty = 0;
                Double thirtyOneToSixty = 0;
                Double sixtyOneToNinety = 0;
                Double ninetyOneToOneTwenty = 0;
                Double greaterThanOneTwenty = 0;
                Double total = 0;
                string dt = "ship_date_actual";
                if (Ap)
                    dt = "receive_date_actual";
                foreach (DataRow r in k.Value)
                {
                    DateTime date = Tools.Data.NullFilterDate(r[dt]);
                    int daysToPay = Tools.Data.NullFilterInt(r["days_to_pay"]);
                    TimeSpan lateSpan = DateTime.Now.Subtract(date.Add(TimeSpan.FromDays(daysToPay)));
                    Double amount = Tools.Data.NullFilterDouble(r["outstandingamount"]);
                    if (lateSpan.TotalDays <= 0)
                        currentAmount += amount;
                    else if (lateSpan.TotalDays < 31)
                        oneToThirty += amount;
                    else if (lateSpan.TotalDays < 61)
                        thirtyOneToSixty += amount;
                    else if (lateSpan.TotalDays < 91)
                        sixtyOneToNinety += amount;
                    else if (lateSpan.TotalDays < 121)
                        ninetyOneToOneTwenty += amount;
                    else
                        greaterThanOneTwenty += amount;
                    total += amount;
                }
                ReportLine l = LineAdd();
                l.SetInc(groupCompany, new ItemTag("company", compID));
                l.SetIncBlankZero(currentAmount);
                l.SetIncBlankZero(oneToThirty);
                l.SetIncBlankZero(thirtyOneToSixty);
                l.SetIncBlankZero(sixtyOneToNinety);
                l.SetIncBlankZero(ninetyOneToOneTwenty);
                l.SetIncBlankZero(greaterThanOneTwenty);
                l.SetInc(total);
            }
        }
    }
}
