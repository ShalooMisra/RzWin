using System;
using System.Collections;
using System.Text;
using System.IO;

using NewMethod;

namespace Rz5
{

    public class Duty_StockExportAndUpload : nDuty
    {
        public Duty_StockExportAndUpload()
            : base("Stock Export And Upload", "Stock Export And Upload")
        {

        }

        public virtual void DoStockExport(ContextRz q)
        {
            throw new NotImplementedException();
        }

        public virtual void DoStockUpload(ContextRz q)
        {
            throw new NotImplementedException();
        }

        protected override void Run(ContextNM q)
        {
            Run(q, false);
        }

        public void Run(ContextNM q, bool skipexport)
        {
            base.Run(q);

            if (!skipexport)
            {
                MakeStockCheckPart((ContextRz)q);
                DoStockExport((ContextRz)q);
            }

            DoStockUpload((ContextRz)q);
            q.TheLeader.Comment("Stock export and upload complete.");
        }

        public virtual void UploadBrokerForum(ContextRz q)
        {
            throw new Exception("UploadBrokerForum isn't overridden.");
        }

        public virtual void UploadNetcomponents(ContextRz q)
        {
            throw new Exception("UploadNetComponents isn't overridden.");
        }

        public void MakeStockCheckPart(ContextRz context)
        {
            context.Execute("delete from partrecord where fullpartnumber like 'TST24601" + context.Logic.UploadCode + "%' and quantity = 1 and location = 'RZTEST' and datecreated < cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(System.DateTime.Now.Subtract(TimeSpan.FromHours(6))) + "' as datetime)");

            partrecord xPart = partrecord.New(context);
            xPart.stocktype = "STOCK";
            xPart.fullpartnumber = "TST24601" + context.Logic.UploadCode + Tools.Strings.Right(System.DateTime.Now.Year.ToString(), 2) + Tools.Strings.Right("0" + System.DateTime.Now.Month.ToString(), 2) + Tools.Strings.Right("0" + System.DateTime.Now.Day.ToString(), 2) + Tools.Strings.Right("0" + System.DateTime.Now.Hour.ToString(), 2);
            xPart.location = "RZTEST";
            xPart.quantity = 1;
            context.Insert(xPart);

            context.Execute("delete from partrecord where fullpartnumber like 'TSU24601" + context.Logic.UploadCode + "%' and quantity = 1 and location = 'RZTEST' and datecreated < cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(System.DateTime.Now.Subtract(TimeSpan.FromHours(6))) + "' as datetime)");

            xPart = partrecord.New(context);
            xPart.stocktype = "EXCESS";
            xPart.fullpartnumber = "TSU24601" + context.Logic.UploadCode + Tools.Strings.Right(System.DateTime.Now.Year.ToString(), 2) + Tools.Strings.Right("0" + System.DateTime.Now.Month.ToString(), 2) + Tools.Strings.Right("0" + System.DateTime.Now.Day.ToString(), 2) + Tools.Strings.Right("0" + System.DateTime.Now.Hour.ToString(), 2);
            xPart.location = "RZTEST";
            xPart.quantity = 1;
            context.Insert(xPart);
        }
    }
}
