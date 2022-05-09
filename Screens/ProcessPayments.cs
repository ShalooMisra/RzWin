using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;

namespace RzInterfaceWin.Screens
{
    public partial class ProcessPayments : UserControl
    {
        public ProcessPayments()
        {
            InitializeComponent();
        }

        PaymentBatch Batch;

        public void Init(PaymentType type, company company)
        {
            //paymentMethod.LoadList();
            accountSelection.Init("Account", new AccountCriteria(AccountType.Bank));
            pVendor.Visible = type == PaymentType.Vendor;
            pMethod.Visible = type == PaymentType.Vendor;
            accountSelection.Visible = type == PaymentType.Vendor;
            Batch = new PaymentBatch(RzWin.Context, type, company);
            Display();

            //temp
            lvCreditMemo.Visible = false;
            //temp
        }

        void Display()
        {
            totalBalanceLabel.Text = Batch.BalanceCaption;
            appliedLabel.Text = Batch.AppliedCaption;
            openLabel.Text = Batch.OpenCaption;

            cStub.Caption = Batch.BatchType.ToString();
            if (Batch.Company == null)
                cStub.DoClearCompany();
            else
                cStub.SetCompanyInfo(Batch.Company.unique_id, Batch.Company.companyname);

            LoadPaymentBatchLV();
            lvCreditMemo.Enabled = Batch.DetailTotal > 0;

            String inst = "";
            if (Batch.Valid(ref inst))
            {
                Warning("");
                saveButton.Enabled = true;
            }
            else
            {
                Warning(inst);
                saveButton.Enabled = false;
            }
        }

        void LoadPaymentBatchLV()
        {
            lv.Items.Clear();
            foreach (PaymentBatchDetail d in Batch.Details)
            {
                ListViewItem i = null;
                i = lv.Items.Add(Tools.Dates.DateFormat(d.Order.orderdate));
                i.SubItems.Add(d.Order.ordernumber);
                i.SubItems.Add((d.Order.orderreference + "  " + d.Order.terms).Trim());
                i.SubItems.Add(Tools.Number.MoneyFormat(d.Order.ordertotal));
                i.SubItems.Add(Tools.Number.MoneyFormat(d.Order.outstandingamount));
                i.SubItems.Add("");
                i.Tag = d;
                RefreshLine(i, d);
            }
        }

        bool Loading = false;

        void LoadCreditMemoLV()
        {
            lvCreditMemo.Items.Clear();
            lvCreditMemo.SuspendLayout();
            Loading = true;
            try
            {
                DataTable dt = RzWin.Context.Select("select d.unique_id from creditmemo_det d inner join creditmemo_hed h on h.unique_id = d.the_creditmemo_hed_uid where isnull(d.is_paid,0) = 0 and isnull(h.posted_credit,0) = 1 and h.base_company_uid = '" + Batch.Company.unique_id + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    creditmemo_det c = creditmemo_det.GetById(RzWin.Context, Tools.Data.NullFilterString(dr["unique_id"]));
                    if (c == null)
                        continue;
                    ListViewItem xLst = lvCreditMemo.Items.Add(Tools.Dates.DateFormat(c.orderdate));
                    xLst.SubItems.Add(c.ordernumber);
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(c.Balance));
                    xLst.Tag = c;
                }
            }
            catch { }
            Loading = false;
            lvCreditMemo.ResumeLayout();
        }
        
        void RefreshLine(ListViewItem i, PaymentBatchDetail d)
        {
            if (d.Amount > 0)
                i.SubItems[5].Text = Tools.Number.MoneyFormat(d.Amount);
            else
                i.SubItems[5].Text = "";
        }

        private void cStub_ClearCompany(Tools.GenericEvent e)
        {            
            Batch.SetCompany(RzWin.Context, null);
            paymentAmount.SetValue(0);
            //paymentMethod.SetValue("");
            optManualCheck.Checked = true;
            Display();
            LoadCreditMemoLV();
        }

        private void cStub_ChangeCompany(Tools.GenericEvent e)
        {
            e.Handled = true;
            company c = RzWin.Leader.ChooseCompany(RzWin.Context);
            if (c == null)
                return;
            Batch.SetCompany(RzWin.Context, c);
            Display();
            LoadCreditMemoLV();
        }

        private void ProcessPayments_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                top.Left = 0;
                top.Top = 0;
                top.Width = this.ClientRectangle.Width;

                lv.Left = 0;
                lv.Top = top.Bottom;
                lv.Width = this.ClientRectangle.Width;
                lv.Height = this.ClientRectangle.Height - lv.Top;
            }
            catch { }
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem i = lv.SelectedItems[0];
                PaymentBatchDetail d = (PaymentBatchDetail)i.Tag;
                d.ChangeAmount(RzWin.Context);
                Display();                
            }
            catch { }
        }

        private void openThisOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ((PaymentBatchDetail)lv.SelectedItems[0].Tag).ShowOrder(RzWin.Context);
            }
            catch { }
        }

        void Warning(String warning)
        {
            warningLabel.Text = warning;
            warningLabel.Visible = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Batch.Memo = memo.GetValue_String();
                if (optManualCheck.Checked)
                    Batch.Method = "Manual Check";
                else if (optPrintCheck.Checked)
                    Batch.Method = "Print Check";
                Batch.Post(RzWin.Context);
                if (Batch.Method == "Print Check" && Batch.BatchType== PaymentType.Vendor )
                {
                    List<payment_out> l = new List<payment_out>();
                    if (Tools.Strings.StrExt(Batch.PayID))
                        l.Add(payment_out.GetById(RzWin.Context, Batch.PayID));
                    RzWin.Context.TheLeaderRz.ShowPrintCheck(RzWin.Context, l, Batch.Account);
                }
                Batch = new PaymentBatch(RzWin.Context, Batch.BatchType, null);
                paymentAmount.SetValue(0);
                paymentAmount.ClearInfo();
                optManualCheck.Checked = true;
                memo.SetValue("");
                memo.ClearInfo();
                Display();
                LoadCreditMemoLV();
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("Posting failed: " + ex.Message);
            }
        }

        private void paymentAmount_DataChanged(Tools.GenericEvent e)
        {
            UpdatePaymentAmount();
        }

        private void UpdatePaymentAmount()
        {
            Batch.Amount = paymentAmount.GetValue_Double() + Batch.CreditTotal;
            Display();
        }

        private void mnu_Opening(object sender, CancelEventArgs e)
        {
            if (((PaymentBatchDetail)lv.SelectedItems[0].Tag).Order == null)
            {
                e.Cancel = true;
                return;
            }
        }

        private void newBillButton_Click(object sender, EventArgs e)
        {
            RzWin.Sys.TheOrderLogic.ShowNewBill(RzWin.Context, Batch.Company);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (Batch.Company != null)
                Batch.SetCompany(RzWin.Context, Batch.Company);
            
            Display();
        }

        private void accountSelection_AccountSelected(account newAccount, ref bool cancel)
        {
            Batch.Account = newAccount;
            Display();
        }

        private void mnuOpenCreditMemo_Click(object sender, EventArgs e)
        {
            try
            {
                creditmemo_hed c = creditmemo_hed.GetById(RzWin.Context, ((creditmemo_det)lvCreditMemo.SelectedItems[0].Tag).the_creditmemo_hed_uid);
                RzWin.Context.Show(c);
            }
            catch { }
        }

        private void lvCreditMemo_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (Loading)
                return;
            creditmemo_det c = (creditmemo_det)e.Item.Tag;
            if (c == null)
                return;
            if (e.Item.Checked)
                Batch.Credits.Add(c);
            else
                Batch.Credits.Remove(c);
            UpdatePaymentAmount();
        }
    }
}
