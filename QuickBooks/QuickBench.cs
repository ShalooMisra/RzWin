using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using CoreWin;

namespace Rz5
{
    public partial class QuickBench : UserControl, ICompleteLoad  //, IStatusView
    {
        public QuickBench()
        {
            InitializeComponent();
        }

        public virtual void CompleteLoad()
        {
            ctl_version_name.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.VersionName(RzWin.Context));
            numMajor.Value = RzWin.Context.TheSysRz.TheQuickBooksLogic.qbXMLMajorVer(RzWin.Context);
            numMinor.Value = RzWin.Context.TheSysRz.TheQuickBooksLogic.qbXMLMinorVer(RzWin.Context);

            ctl_expense.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.ExpenseAccount(RzWin.Context, null));
            ctl_income.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.IncomeAccount(RzWin.Context, null));
            ctl_asset.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.AssetAccount(RzWin.Context));
            ctl_cogs.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.COGSAccount(RzWin.Context, null));
            ctl_deposit.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.DepositAccount(RzWin.Context));

            ctl_expense_number.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.ExpenseAccountNumber(RzWin.Context));
            ctl_income_number.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.IncomeAccountNumber(RzWin.Context));
            ctl_asset_number.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.AssetAccountNumber(RzWin.Context));
            ctl_cogs_number.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.COGSAccountNumber(RzWin.Context));
            ctl_deposit_number.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.DepositAccountNumber(RzWin.Context));

            LoadList(lvGeneral, RzWin.Context.TheSysRz.TheQuickBooksLogic.GeneralOption(RzWin.Context));
            LoadList(lvInvoice, RzWin.Context.TheSysRz.TheQuickBooksLogic.InvoiceOption(RzWin.Context));
            LoadList(lvPO, RzWin.Context.TheSysRz.TheQuickBooksLogic.POOption(RzWin.Context));

            ctlOutgoingShipping.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.OutgoingShipping(RzWin.Context));
            ctlIncomingShippingItem.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.IncomingShipping(RzWin.Context));
            ctlHandlingItem.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.HandlingItem(RzWin.Context));
            ctlVendorSuffix.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.VendorSuffix(RzWin.Context));
            ctlItemSuffix.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.ItemSuffix(RzWin.Context));
            ctlInvoiceTemplateName.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.InvoiceTemplateName(RzWin.Context));
        }

        void LoadList(ListView v, String s)
        {
            foreach (ListViewItem i in v.Items)
            {
                i.Checked = Tools.Strings.HasString(s, i.Text.Replace(" ", ""));
            }
        }


        private void cmdConnect_Click(object sender, EventArgs e)
        {
            if (RzWin.Context.TheSysRz.TheQuickBooksLogic.Connect(RzWin.Context))
            {
                AddStatus("The connection to QuickBooks was successfully established.");
                RzWin.Context.TheSysRz.TheQuickBooksLogic.Disconnect();
            }
            else
            {
                AddStatus("The connection attempt failed.  Please ensure that the QuickBooks SDK is installed, and that the company file you intent to use is open in QuickBooks on this workstation.");
            }
        }

        private void QuickBench_Load(object sender, EventArgs e)
        {
            //////nStatus.RegisterStatusView(this);
        }

        public void SetStatusByIndex(Object sender, StatusArgs args)
        {
            AddStatus(args.status);
        }

        private void AddStatus(String s)
        {
            this.Invoke(new SetStatusDelegate(ActuallyAddStatus), new Object[] { s });
        }

        private void ActuallyAddStatus(String s)
        {
            txtStatus.Text = s + "\r\n" + txtStatus.Text;
        }

        public void SetProgressByIndex(Object sender, ProgressArgs args) { }
        public void SetActivityByIndex(Object sender, ActivityArgs args) { }
        public void AddLine() { }
        public void RemoveLine() { }
        public virtual void CompleteSave()
        {
            AddStatus("Saving...");
            RzWin.Context.TheSysRz.TheQuickBooksLogic.ExpenseAccountSet(RzWin.Context, (String)ctl_expense.GetValue());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.IncomeAccountSet(RzWin.Context, (String)ctl_income.GetValue());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.AssetAccountSet(RzWin.Context, (String)ctl_asset.GetValue());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.COGSAccountSet(RzWin.Context, (String)ctl_cogs.GetValue());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.DepositAccountSet(RzWin.Context, (String)ctl_deposit.GetValue());

            RzWin.Context.TheSysRz.TheQuickBooksLogic.ExpenseAccountNumberSet(RzWin.Context, (String)ctl_expense_number.GetValue());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.IncomeAccountNumberSet(RzWin.Context, (String)ctl_income_number.GetValue());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.AssetAccountNumberSet(RzWin.Context, (String)ctl_asset_number.GetValue());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.COGSAccountNumberSet(RzWin.Context, (String)ctl_cogs_number.GetValue());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.DepositAccountNumberSet(RzWin.Context, (String)ctl_deposit_number.GetValue());

            RzWin.Context.TheSysRz.TheQuickBooksLogic.VersionNameSet(RzWin.Context, ctl_version_name.GetValue_String());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.qbXMLMajorVerSet(RzWin.Context, Convert.ToInt16(numMajor.Value));
            RzWin.Context.TheSysRz.TheQuickBooksLogic.qbXMLMinorVerSet(RzWin.Context, Convert.ToInt16(numMinor.Value));

            RzWin.Context.TheSysRz.TheQuickBooksLogic.GeneralOptionSet(RzWin.Context, SaveList(lvGeneral));
            RzWin.Context.TheSysRz.TheQuickBooksLogic.InvoiceOptionSet(RzWin.Context, SaveList(lvInvoice));
            RzWin.Context.TheSysRz.TheQuickBooksLogic.POOptionSet(RzWin.Context, SaveList(lvPO));

            RzWin.Context.TheSysRz.TheQuickBooksLogic.OutgoingShippingSet(RzWin.Context, ctlOutgoingShipping.GetValue_String());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.IncomingShippingSet(RzWin.Context, ctlIncomingShippingItem.GetValue_String());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.HandlingItemSet(RzWin.Context, ctlHandlingItem.GetValue_String());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.VendorSuffixSet(RzWin.Context, ctlVendorSuffix.GetValue_String());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.ItemSuffixSet(RzWin.Context, ctlItemSuffix.GetValue_String());
            RzWin.Context.TheSysRz.TheQuickBooksLogic.InvoiceTemplateNameSet(RzWin.Context, ctlInvoiceTemplateName.GetValue_String());



            AddStatus("Saved.");
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            CompleteSave();
        }

        String SaveList(ListView lv)
        {
            String s = "";
            foreach (ListViewItem i in lv.CheckedItems)
            {
                if (Tools.Strings.StrExt(s))
                    s += ",";
                s += i.Text.Replace(" ", "");
            }
            return s;
        }

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            AddStatus("Creating accounts...");
            RzWin.Context.TheSysRz.TheQuickBooksLogic.CreateAccounts(RzWin.Context);
            AddStatus("Done.");
        }

        private void cmdVersionInfo_Click(object sender, EventArgs e)
        {
            numMajor.Enabled = true;
            numMinor.Enabled = true;

            Double d = 0;
            AddStatus(RzWin.Context.TheSysRz.TheQuickBooksLogic.GetVersionInfo(RzWin.Context, ref d));

            String s = d.ToString();
            Decimal major = Convert.ToDecimal(Tools.Strings.ParseDelimit(s, ".", 1));
            Decimal minor = 0;
            
            if( Tools.Strings.HasString(s, ".") )
                minor = Convert.ToDecimal(Tools.Strings.ParseDelimit(s, ".", 2));

            numMajor.Value = major;
            numMinor.Value = minor;
        }

        private void QuickBench_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                txtStatus.Left = 0;
                txtStatus.Width = this.ClientRectangle.Width;
                txtStatus.Height = this.ClientRectangle.Height - txtStatus.Top;
            }
            catch { }
        }

        private void llSalesReps_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowSalesRepsPanel();
        }

        private void ShowSalesRepsPanel()
        {
            frmQuickbooksSalesRepsTests f = new frmQuickbooksSalesRepsTests();
            f.Show();
        }
    }
}
