using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using NewMethod;
//using CoreWin;

namespace Rz5
{
    public class Duty_StockExport : nDuty
    {
        public Duty_StockExport()
            : base("Stock Export", "Stock Export")
        {


        }

        protected override void Run(ContextNM q)
        {
            base.Run(q);
            String strSQL = "select quantity as [Quantity], fullpartnumber as [Part], manufacturer as [MFG], datecode as [DC], 'Stock' as [Desc] from partrecord where stocktype in ('Stock', 'consign', 'consigned') and quantity > 0 and len(fullpartnumber) > 2 order by fullpartnumber";
            String strFile = "c:\\stock.csv";
            PartObject.ExportStockCsvFile(q, strSQL, strFile);
        }
    }

    public class Duty_ExcessExport : nDuty
    {
        public Duty_ExcessExport()
            : base("Excess Export", "Excess Export")
        {


        }

        protected override void Run(ContextNM q)
        {
            base.Run(q);
            String strSQL = "";
            String strFile = "";
            strSQL = "select quantity as [Quantity], fullpartnumber as [Part], manufacturer as [MFG], datecode as [DC], 'Excess' as [Desc] from partrecord where stocktype in('OEM', 'EXCESS') and quantity > 0 and len(fullpartnumber) > 2 order by fullpartnumber";
            strFile = "c:\\excess.csv";           
            PartObject.ExportStockCsvFile(q, strSQL, strFile);
        }
    }


    public class Duty_AvailExport : nDuty
    {
        public Duty_AvailExport()
            : base("Avail Export", "Avail Export")
        {


        }

        protected override void Run(ContextNM q)
        {
            base.Run(q);
            String strSQL = "select quantity as [Quantity], fullpartnumber as [Part], manufacturer as [MFG], datecode as [DC], 'Avail' as [Desc] from partrecord where stocktype in('offer') and quantity > 0 and len(fullpartnumber) > 2 order by fullpartnumber";
            String strFile = "c:\\avail.csv";
            PartObject.ExportStockCsvFile(q, strSQL, strFile);
        }
    }


}