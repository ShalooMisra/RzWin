using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using QBFC13Lib;

namespace Rz5
{
    public partial class QBPaymentChargeImport : UserControl
    {
        //Private Variables
        private ContextNM TheContext
        {
            get
            {
                return RzWin.Context;
            }
        }

        //Constructors
        public QBPaymentChargeImport()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad()
        {
            dv.CompleteLoad();
            checkpayment cp = new checkpayment();
            dv.AddCommonField("companyname", "Vendor/Customer Name", "Vendor/Customer Name", true);
            dv.AddCommonField("datecreated", "Transaction Date", "Transaction Date", true);
            dv.AddCommonField("subtotal", "Payment", "Payment");
            dv.AddCommonField("transamount", "Charge", "Charge");
            dv.AddCommonField("description", "Memo", "Memo");
            dv.AddCommonField("referencedata", "QBs Account", "QBs Account", true);
            dv.AddCommonField("transamountcurr", "Bank/CC Account", "Bank/CC Account", true);
            dv.SetClass("checkpayment");
            return true;
        }
        public void DoResize()
        {
            try
            {
                SetBorder();
                lblCaption.Left = pbLeft.Right;
                lblCaption.Top = pbTop.Bottom;
                lblCaption.Width = (pbRight.Left - lblCaption.Left);
                dv.Left = lblCaption.Left;
                dv.Top = lblCaption.Bottom;
                dv.Width = lblCaption.Width;
                dv.Height = (pbBottom.Top - dv.Top);
            }
            catch { }
        }
        //Private Functions
        QBPayChargeImportArgs TheArgs;
        private bool RunImport()
        {
            dv.SetStatus("Importing...");
            bool b = false;
            TheArgs = new QBPayChargeImportArgs("checkpayment", false);
            if (!PrepareImport(dv.CurrentTable, TheArgs))
                return false;
            if (!FilterImport(dv.CurrentTable, TheArgs))
                return false;
            b = ImportFiltered(dv.CurrentTable, TheArgs);
            dv.SetStatus("Finishing...");
            dv.CurrentTable.ConvertToText();
            dv.CurrentTable.RefreshFromDatabase(RzWin.Context);
            if (b)
            {
                TheContext.TheLeader.TellTemp("Done: " + Tools.Number.LongFormat(TheArgs.AcceptedCount) + " records were imported.");
                dv.SetStatus("Done: " + Tools.Number.LongFormat(TheArgs.AcceptedCount) + " records were imported.");
            }
            else
                dv.SetStatus("This import was not completed.");
            return b;
        }
        private void StartImport()
        {
            if (bgw.IsBusy)
            {
                RzWin.Leader.Tell("The system is still importing files. Please wait until it has finished.");
                return;
            }
            dv.SetStatus("Importing...");
            dv.ShowThrobber();
            dv.DisableAccept();
            bgw.RunWorkerAsync();
        }
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();

            }
            catch (Exception)
            { }
        }
        //Control Events
        private void QBPaymentChargeImport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void dv_Accept()
        {
            if (dv.Count <= 0)
                return;
            if (!TheContext.TheLeader.AreYouSure("import " + Tools.Number.LongFormat(dv.Count) + " items"))
                return;
            RzWin.Leader.StartPopStatus("Running...");

            StartImport();
        }
        private bool PrepareImport(nDataTable dv, QBPayChargeImportArgs args)
        {
            if (!dv.HasColumnField("companyname"))
            {
                args.AddError("No valid Vendor/Customer field selected");
                if (!args.Silent)
                    RzWin.Leader.Tell("Please choose a column for the Vendor/Customer.");
                return false;
            }
            if (!dv.HasColumnField("datecreated"))
            {
                args.AddError("No valid Transaction Date field selected");
                if (!args.Silent)
                    RzWin.Leader.Tell("Please choose a column for the Transaction Date.");
                return false;
            }
            if (!dv.HasColumnField("referencedata"))
            {
                args.AddError("No valid QBs Account field selected");
                if (!args.Silent)
                    RzWin.Leader.Tell("Please choose a column for the QBs Account.");
                return false;
            }
            if (!dv.HasColumnField("transamountcurr"))
            {
                args.AddError("No valid Bank/CC Account field selected");
                if (!args.Silent)
                    RzWin.Leader.Tell("Please choose a column for the Bank/CC Account.");
                return false;
            }
            dv.RemoveBlurb("?");
            dv.RemoveBlurb("€");
            dv.RemoveBlurb("xxx");
            dv.SetActualFieldNames(RzWin.Context);
            String s = "";
            dv.FormalizeFieldTypes(RzWin.Context);
            if (Tools.Strings.StrExt(s))
                args.AddLog(s);
            args.ImportCount = dv.Count;
            args.AcceptedCount = 0;
            args.RejectedCount = 0;
            return true;
        }
        private bool FilterImport(nDataTable dv, QBPayChargeImportArgs args)
        {
            long count = 0;
            dv.CheckCriteria(RzWin.Context, "have no Vendor/Customer", "isnull(companyname, '') = ''");
            dv.CheckCriteria(RzWin.Context, "have no Transaction Date", "isnull(datecreated, '') = ''");
            dv.CheckCriteria(RzWin.Context, "have no QBs Account", "isnull(referencedata, '') = ''");
            dv.CheckCriteria(RzWin.Context, "have no Bank/CC Account", "isnull(transamountcurr, '') = ''");

            if (!CheckQBTransactionAmounts(dv))
            {
                args.AddError("One or more transaction in this import is missing both a payment and a charge amount. Please update these amounts before importing.");
                return false;
            }
            if (!CheckQBAccounts(dv))
            {
                args.AddError("One or more QBAccount in this import does not exist in QBs. Please add the account(s) before importing.");
                return false;
            }
            if (!CheckBankCCAccounts(dv))
            {
                args.AddError("One or more Bank/CC Account in this import does not exist in QBs. Please add the account(s) before importing.");
                return false;
            }
            return true;
        }
        private bool ImportFiltered(nDataTable dv, QBPayChargeImportArgs args)
        {
            long count = 0;
            DataTable dt = dv.GetDataTable();
            foreach (DataRow dr in dt.Rows)
            {
                Enums.TransactionType t = Enums.TransactionType.Check;
                if (nData.NullFilter_Double(dr["transamount"]) > 0)
                    t = Enums.TransactionType.Check;//sending
                else
                    t = Enums.TransactionType.Payment;//receiveing
                checkpayment c = checkpayment.New(RzWin.Context);
                c.companyname = (String)nData.NullFilter_String(dr["companyname"]);
                c.description = (String)nData.NullFilter_String(dr["description"]);
                c.referencedata = (String)nData.NullFilter_String(dr["referencedata"]);
                c.transamountcurr = (String)nData.NullFilter_String(dr["transamountcurr"]);
                c.datecreated = (DateTime)nData.NullFilter_DateTime(dr["datecreated"]);
                c.transamount = (Double)nData.NullFilter_Double(dr["transamount"]);
                c.subtotal = (Double)nData.NullFilter_Double(dr["subtotal"]);
                c.TransactionType = t;
                if (RzWin.Context.TheSysRz.TheQuickBooksLogic.ImportCheckPayment(RzWin.Context, c))
                    count++;
            }
            args.AcceptedCount = count;
            return true;
        }
        private bool CheckQBTransactionAmounts(nDataTable dv)
        {
            if (dv == null)
                return false;
            DataTable dt = dv.xData.Select("select transamount, subtotal from " + dv.TableName);
            if (dt == null)
                return false;
            if (dt.Rows.Count <= 0)
                return false;
            foreach (DataRow dr in dt.Rows)
            {
                double a = nData.NullFilter_Double(dr["transamount"]);
                double b = nData.NullFilter_Double(dr["subtotal"]);
                if (a == 0 && b == 0)
                    return false;
            }
            return true;
        }
        private bool CheckQBAccounts(nDataTable dv)
        {
            if (dv == null)
                return false;
            DataTable dt = dv.xData.Select("select referencedata, transamount, subtotal from " + dv.TableName);
            if (dt == null)
                return false;
            if (dt.Rows.Count <= 0)
                return false;
            foreach (DataRow dr in dt.Rows)
            {
                ENAccountType t = ENAccountType.atIncome;
                double d = nData.NullFilter_Double(dr["transamount"]);
                if (d > 0)
                    t = ENAccountType.atExpense;
                if (!RzWin.Context.TheSysRz.TheQuickBooksLogic.AccountExist(RzWin.Context, dr["referencedata"].ToString(), t))
                    return false;
            }
            return true;
        }
        private bool CheckBankCCAccounts(nDataTable dv)
        {
            DataTable dt = dv.xData.Select("select distinct(transamountcurr) from " + dv.TableName);
            if (dt == null)
                return false;
            if (dt.Rows.Count <= 0)
                return false;
            foreach (DataRow dr in dt.Rows)
            {
                bool b = false;
                b = RzWin.Context.TheSysRz.TheQuickBooksLogic.AccountExist(RzWin.Context, dr["transamountcurr"].ToString(), ENAccountType.atBank);
                if (b)
                    return true;
                b = RzWin.Context.TheSysRz.TheQuickBooksLogic.AccountExist(RzWin.Context, dr["transamountcurr"].ToString(), ENAccountType.atCreditCard);
                if (b)
                    return true;
            }
            return false;
        }
        //Background Workers
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = RunImport();
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dv.ShowTable();
            dv.HideThrobber();
            dv.AllowAccept();
            //if( TheArgs.RejectedCount > 0 )
                TheContext.TheLeader.Tell(TheArgs.Log.ToString());

                RzWin.Leader.Comment("Done.");
            RzWin.Leader.StopPopStatus(true);
        }
        //Private Enums
        private enum QBImportType
        {
            None = 0,
            Payment = 1,
            Charge = 2,
        }
    }
    public class QBPayChargeImportArgs
    {
        public Int64 ImportCount = 0;
        public Int64 AcceptedCount = 0;
        public Int64 RejectedCount = 0;
        public StringBuilder Log = new StringBuilder();
        public String TableName = "";
        public bool Silent = true;
        public bool HadErrors = false;

        public QBPayChargeImportArgs(String strTable, bool silent)
        {
            TableName = strTable;
            Silent = silent;
        }
        public void AddLog(String s)
        {
            RzWin.Leader.Comment(s);
            Log.AppendLine(nTools.DateFormat_ShortDateTime(System.DateTime.Now) + ": " + s);
        }
        public void AddError(String s)
        {
            HadErrors = true;
            AddLog("<ERROR> " + s);
        }
    }
}
