using SensibleDAL.dbml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SensibleDAL
{

    public partial class LineData
    {
        //static RzDataContext rdc = new RzDataContext();
        public string lineID { get; set; }
        public double lineGP { get; set; }
        public string fullPartNumber { get; set; }
        public int lineQTY { get; set; }
        public string lineAgent { get; set; }
        public string lineStatus { get; set; }

        public static List<LineData> GetLineDataForAgents(List<string> agentIDs, DateTime startDate, DateTime endDate, List<string> invalidLineStatus = null)
        {
            List<LineData> ret = new List<LineData>();
            using (RzDataContext rdc = new RzDataContext())
            {

                var query = from l in rdc.orddet_lines
                            where agentIDs.Contains(l.seller_uid)
                            && l.date_created >= startDate && l.date_created <= endDate
                            select new LineData
                            {
                                lineID = l.unique_id,
                                lineGP = l.gross_profit ?? 0,
                                lineAgent = l.seller_name,
                                lineQTY = l.quantity ?? 0,
                                lineStatus = l.status
                            };
                if (query.Any())
                    if (invalidLineStatus != null)
                    {
                        query = query.Where(w => !invalidLineStatus.Contains(w.lineStatus));
                    }

                ret = query.ToList();
            }

            return ret;
        }

        public static List<string> GetInvalid_orddet_Status(bool hidecrapQuar = true, bool hideRMA = true)
        {
            List<string> ret = new List<string>();
            if (hideRMA)
            {
                ret.Add("RMA Receiving");
                ret.Add("RMA Received");
                ret.Add("Vendor RMA Packing");
                ret.Add("Vendor RMA Shipped");
            }
            if (hidecrapQuar)
            {
                ret.Add("Scrapped");
                ret.Add("Quarantined");
            }
            ret.Add("Void");
            ret.Add("Frozen");
            return ret;
        }
    }

    public class LineDeduction
    {
        static RzDataContext rdc = new RzDataContext();
        public string deductionID { get; set; }
        public string lineID { get; set; }
        public string AgentName { get; set; }
        public double DeductionAmount { get; set; }
        public string DeductionName { get; set; }


        public static List<LineDeduction> GetLineDeductionsForAgents(List<string> lineIDs)
        {
            List<LineDeduction> ret = new List<LineDeduction>();
            foreach (string s in lineIDs) // Since there can be WAY more lineIDs than the 2100 limit for linq query
            {
                profit_deduction p = rdc.profit_deductions.Where(w => w.the_orddet_line_uid == s).FirstOrDefault();
                if (p != null)
                {
                    LineDeduction ld = new LineDeduction();
                    ld.deductionID = p.unique_id;
                    ld.lineID = p.the_orddet_line_uid;
                    ld.DeductionAmount = p.amount ?? 0;
                    ld.DeductionName = p.name ?? "";
                    ret.Add(ld);
                }
            }


            //ret = (from p in rdc.profit_deductions
            //       where p.amount > 0 && p.date_created >= new DateTime(2017, 01, 01)
            //       && lineIDs.Contains(p.the_orddet_line_uid)
            //       select new LineDeduction
            //       {
            //           deductionID = p.unique_id,
            //           lineID = p.the_orddet_line_uid,
            //           DeductionAmount = p.amount ?? 0
            //       }).ToList();

            return ret;

        }
    }
}
