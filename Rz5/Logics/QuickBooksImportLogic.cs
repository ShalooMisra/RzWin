using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QBFC13Lib;
using Core;
using NewMethod;
using System.Collections;

namespace Rz5
{
    public partial class QuickBooksImportLogic
    {
        //Public Static Functions
        public static void ImportFromQuickBooks(ContextRz x)
        {
            QuickBooksImportLogic l = x.TheSysRz.TheQuickBooksLogic.GetQBImportLogic();
            int past_year_count = x.TheLeader.AskForInt32("Enter the number of past years to import. (Automatically imports this year and X number of years before that.)", 1, "Past Years");
            //l.ImportAccountsQuickBooksTest(x, past_year_count);
            l.ImportAccountsQuickBooks(x);
            //l.ImportUnPaidBillsQuickBooks(x);             
        }

        private static IResponse GetResponse(ContextRz x, IMsgSetRequest requestSet)
        {
            if (!x.TheSysRz.TheQuickBooksLogic.Connect(x))
                return null;
            IMsgSetResponse responseSet = x.TheSysRz.TheQuickBooksLogic.sessionManager.DoRequests(requestSet);
            x.TheSysRz.TheQuickBooksLogic.Disconnect();
            return responseSet.ResponseList.GetAt(0);
        }


        private IItemInventoryRet GetInvItem(ContextRz x, string id)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IItemInventoryQuery inv = requestSet.AppendItemInventoryQueryRq();
            inv.ORListQueryWithOwnerIDAndClass.ListIDList.Add(id);
            IItemInventoryRetList ItemList = (IItemInventoryRetList)GetResponse(x, requestSet).Detail;
            if (ItemList != null)
                return ItemList.GetAt(0);
            return null;
        }
        private IItemNonInventoryRet GetNonInvItem(ContextRz x, string id)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IItemNonInventoryQuery inv = requestSet.AppendItemNonInventoryQueryRq();
            inv.ORListQueryWithOwnerIDAndClass.ListIDList.Add(id);
            IItemNonInventoryRetList ItemList = (IItemNonInventoryRetList)GetResponse(x, requestSet).Detail;
            if (ItemList != null)
                return ItemList.GetAt(0);
            return null;
        }
        private IItemOtherChargeRet GetOtherChargeItem(ContextRz x, string id)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IItemOtherChargeQuery inv = requestSet.AppendItemOtherChargeQueryRq();
            inv.ORListQueryWithOwnerIDAndClass.ListIDList.Add(id);
            IItemOtherChargeRetList ItemList = (IItemOtherChargeRetList)GetResponse(x, requestSet).Detail;
            if (ItemList != null)
                return ItemList.GetAt(0);
            return null;
        }
        private IItemServiceRet GetServiceItem(ContextRz x, string id)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IItemServiceQuery inv = requestSet.AppendItemServiceQueryRq();
            inv.ORListQueryWithOwnerIDAndClass.ListIDList.Add(id);
            IItemServiceRetList ItemList = (IItemServiceRetList)GetResponse(x, requestSet).Detail;
            if (ItemList != null)
                return ItemList.GetAt(0);
            return null;
        }
        private IItemSalesTaxRet GetSalesTaxItem(ContextRz x, string id)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IItemSalesTaxQuery inv = requestSet.AppendItemSalesTaxQueryRq();
            inv.ORListQueryWithOwnerIDAndClass.ListIDList.Add(id);
            IItemSalesTaxRetList ItemList = (IItemSalesTaxRetList)GetResponse(x, requestSet).Detail;
            if (ItemList != null)
                return ItemList.GetAt(0);
            return null;
        }
        private IItemSubtotalRet GetSubtotalItem(ContextRz x, string id)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IItemSubtotalQuery inv = requestSet.AppendItemSubtotalQueryRq();
            inv.ORListQuery.ListIDList.Add(id);
            IItemSubtotalRetList ItemList = (IItemSubtotalRetList)GetResponse(x, requestSet).Detail;
            if (ItemList != null)
                return ItemList.GetAt(0);
            return null;
        }
        private IItemFixedAssetRet GetFixedAssetItem(ContextRz x, string id)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IItemFixedAssetQuery inv = requestSet.AppendItemFixedAssetQueryRq();
            inv.ORListQueryWithOwnerIDAndClass.ListIDList.Add(id);
            IItemFixedAssetRetList ItemList = (IItemFixedAssetRetList)GetResponse(x, requestSet).Detail;
            if (ItemList != null)
                return ItemList.GetAt(0);
            return null;
        }
        private IItemInventoryAssemblyRet GetInventoryAssemblyItem(ContextRz x, string id)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IItemInventoryAssemblyQuery inv = requestSet.AppendItemInventoryAssemblyQueryRq();
            inv.ORListQueryWithOwnerIDAndClass.ListIDList.Add(id);
            IItemInventoryAssemblyRetList ItemList = (IItemInventoryAssemblyRetList)GetResponse(x, requestSet).Detail;
            if (ItemList != null)
                return ItemList.GetAt(0);
            return null;
        }
        private IItemGroupRet GetGroupItem(ContextRz x, string id)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IItemGroupQuery inv = requestSet.AppendItemGroupQueryRq();
            inv.ORListQuery.ListIDList.Add(id);
            IItemGroupRetList ItemList = (IItemGroupRetList)GetResponse(x, requestSet).Detail;
            if (ItemList != null)
                return ItemList.GetAt(0);
            return null;
        }
        private DateTime GetNextMillisecond(SortedDictionary<DateTime, Transaction> a, DateTime d)
        {
            int ms = 1;
            DateTime dd = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second, ms);
            while (a.ContainsKey(dd))
            {
                ms += 1;
                dd = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second, ms);
            }
            return dd;
        }
        private void ImportAccountsQuickBooksTest(ContextRz x, int past_year_count = 1)
        {
            x.TheLeader.Comment("Importing QB Accounts");
            if (x == null)
                return;
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IAccountQuery q = requestSet.AppendAccountQueryRq();
            q.ORAccountListQuery.AccountListFilter.ActiveStatus.SetValue(ENActiveStatus.asAll);
            IAccountRetList AccountList = (IAccountRetList)GetResponse(x, requestSet).Detail;
            IAccountRet AccountRet = AccountList.GetAt(0);
            x.TheSysRz.TheQuickBooksLogic.Disconnect();
            for (int i = 0; i < AccountList.Count; i++)
            {
                IAccountRet acnt = AccountList.GetAt(i);
                ENAccountType t = acnt.AccountType.GetValue();
                if (t == ENAccountType.atNonPosting)
                    continue;
                String fullname = acnt.FullName.GetValue().ToString();
                String name = acnt.Name.GetValue().ToString();
                AccountType type = GetRzAccountType(t);
                int numb = 0;
                if (acnt.AccountNumber != null)
                {
                    if (!acnt.AccountNumber.IsEmpty())
                    {
                        string n = acnt.AccountNumber.GetValue().ToString();
                        if (Tools.Strings.StrExt(n))
                        {
                            if (Tools.Number.IsNumeric(n))
                                numb = Convert.ToInt32(n);
                        }
                    }
                }
                double bal = 0;
                if (acnt.Balance != null)
                    bal = acnt.Balance.GetValue();
                string descr = "";
                if (acnt.Desc != null)
                {
                    if (!acnt.Desc.IsEmpty())
                        descr = acnt.Desc.GetValue();
                }
                account a = account.GetByFullName(x, fullname);
                if (a == null)
                {
                    a = new account();
                    a.name = name;
                    a.full_name = fullname;
                    a.number = CheckAccountNumber(x, numb);
                    a.Type = type;
                    a.Category = account.InferCategory(a.Type);
                    a.description = descr;
                    string parent_name = GetParentAccountName(fullname, name);
                    if (Tools.Strings.StrExt(parent_name))
                    {
                        account aa = account.GetByFullName(x, parent_name);
                        if (aa != null)
                            a.SetParent(aa);
                    }
                    a.Insert(x);
                }
                if (acnt.IsActive != null)
                {
                    if (!acnt.IsActive.IsEmpty())
                    {
                        if (!acnt.IsActive.GetValue())
                            a.is_hidden = true;
                    }
                }
                a.Update(x);
                x.TheLeader.Comment("Imported: " + a.ToString());
            }
            x.TheLeader.Comment("Journal Entries...");
            ImportJournalEntries(x, past_year_count);
        }
        private void ImportJournalEntries(ContextRz x, int past_year_count)
        {
            if (x == null)
                return;
            Tools.Dates.DateRange r = new Tools.Dates.DateRange();
            for (int year = DateTime.Now.Year - past_year_count; year <= DateTime.Now.Year; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    r.StartDate = new DateTime(year, month, 1);
                    r.EndDate = Tools.Dates.GetMonthEnd(r.StartDate);
                    ProcessTransactions(x, GetTransactions(x, r));
                }
            }
        }
        private SortedDictionary<DateTime, SortedDictionary<DateTime, Transaction>> GetTransactions(ContextRz x, Tools.Dates.DateRange r)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            ITransactionQuery trans = requestSet.AppendTransactionQueryRq();
            trans.ORTransactionQuery.TransactionFilter.TransactionDateRangeFilter.ORTransactionDateRangeFilter.TxnDateRange.FromTxnDate.SetValue(r.StartDate);
            trans.ORTransactionQuery.TransactionFilter.TransactionDateRangeFilter.ORTransactionDateRangeFilter.TxnDateRange.ToTxnDate.SetValue(r.EndDate);
            ITransactionRetList TransactionList = (ITransactionRetList)GetResponse(x, requestSet).Detail;
            SortedDictionary<DateTime, SortedDictionary<DateTime, Transaction>> transactions = new SortedDictionary<DateTime, SortedDictionary<DateTime, Transaction>>();
            if (TransactionList != null)
            {
                for (int i = 0; i < TransactionList.Count; i++)
                {
                    ITransactionRet tr = TransactionList.GetAt(i);
                    DateTime date = new DateTime(tr.TxnDate.GetValue().Year, tr.TxnDate.GetValue().Month, tr.TxnDate.GetValue().Day);
                    DateTime created = tr.TimeCreated.GetValue();
                    Transaction t = new Transaction(tr, date);
                    SortedDictionary<DateTime, Transaction> a = null;
                    transactions.TryGetValue(date, out a);
                    if (a == null)
                    {
                        a = new SortedDictionary<DateTime, Transaction>();
                        transactions.Add(date, a);
                    }
                    t.TxnDate = GetNextMillisecond(a, t.TxnDate);
                    a.Add(t.TxnDate, t);
                }
            }
            return transactions;
        }
        private void ProcessTransactions(ContextRz x, SortedDictionary<DateTime, SortedDictionary<DateTime, Transaction>> transactions)
        {
            if (transactions == null)
                return;
            if (transactions.Count <= 0)
                return;
            foreach (KeyValuePair<DateTime, SortedDictionary<DateTime, Transaction>> kvp in transactions)
            {
                int count = 0;
                foreach (KeyValuePair<DateTime, Transaction> sd in kvp.Value)
                {
                    Transaction t = sd.Value;
                    count += 1;
                    x.TheLeader.Comment("Importing Transactions " + kvp.Key.ToShortDateString() + " " + count.ToString() + " of " + kvp.Value.Count.ToString());
                    switch (t.TxnType)
                    {
                        case ENTxnType.ttDeposit:
                            try { ImportDepositEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttInvoice:
                            try { ImportInvoiceEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttBill:
                            try { ImportBillEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttReceivePayment:
                            try { ImportReceivePaymentEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttBillPaymentCheck:
                            try { ImportBillPaymentCheckEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttJournalEntry:
                            try { ImportJournalEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttCheck:
                            try { ImportCheckEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttCreditCardCharge:
                            try { ImportCreditCardChargeEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttCreditMemo:
                            try { ImportCreditMemoEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttTransfer:
                            try { ImportTransferEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttSalesTaxPaymentCheck:
                            try { ImportSalesTaxPaymentCheckEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttInventoryAdjustment:
                            try { ImportInventoryAdjustmentEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttVendorCredit:
                            try { ImportVendorCreditEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttBillPaymentCreditCard:
                            try { ImportBillPaymentCreditCardEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttCreditCardCredit:
                            try { ImportCreditCardCreditEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttARRefundCreditCard:
                            try { ImportARRefundCreditCardEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttSalesReceipt:
                            try { ImportSalesReceiptEntry(x, t); }
                            catch { }
                            break;
                        case ENTxnType.ttEstimate://Doesn't seem to matter
                        case ENTxnType.ttPurchaseOrder://Doesn't seem to matter
                        case ENTxnType.ttSalesOrder://Doesn't seem to matter
                            break;
                        default:
                            x.TheLeader.Tell("ENTxnType not found: " + t.TxnType.ToString());
                            break;
                    }
                }
            }
        }
        //Actual Transaction Imports
        private void ImportCreditCardChargeEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            ICreditCardChargeQuery rec = requestSet.AppendCreditCardChargeQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORTxnQuery.TxnIDList.Add(trans.TxnId);
            ICreditCardChargeRetList CreditCardChargeList = (ICreditCardChargeRetList)GetResponse(x, requestSet).Detail;
            if (CreditCardChargeList != null)
            {
                for (int i = 0; i < CreditCardChargeList.Count; i++)
                {
                    ICreditCardChargeRet c = CreditCardChargeList.GetAt(i);                    
                    string memo = "";
                    if (c.Memo != null)
                        memo = c.Memo.GetValue();
                    DateTime t_date = trans.TxnDate;
                    Double ms = 1;
                    JournalEntry je = new JournalEntry(memo);
                    double cc_amnt = 0;
                    if (c.Amount != null)
                        cc_amnt = Math.Round(c.Amount.GetValue(), 2);
                    if (cc_amnt == 0)
                        continue;
                    account cc_a = null;
                    cc_a = account.GetByFullName(x, c.AccountRef.FullName.GetValue());
                    if (cc_a == null)
                        continue;
                    je.Add(x, cc_a, 0, cc_amnt);
                    account a = null;
                    double amnt = 0;
                    if (c.ExpenseLineRetList != null)
                    {
                        for (int ii = 0; ii < c.ExpenseLineRetList.Count; ii++)
                        {
                            IExpenseLineRet ex = c.ExpenseLineRetList.GetAt(ii);
                            amnt = 0;
                            if (ex.Amount != null)
                                amnt = Math.Round(ex.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            if (ex.AccountRef == null)
                                continue;
                            a = account.GetByFullName(x, ex.AccountRef.FullName.GetValue());
                            je.Add(x, a, amnt, 0);
                        }
                    }
                    if (c.ORItemLineRetList != null)
                    {
                        for (int ii = 0; ii < c.ORItemLineRetList.Count; ii++)
                        {
                            IORItemLineRet ex = c.ORItemLineRetList.GetAt(ii);
                            amnt = 0;
                            if (ex.ItemLineRet.Amount != null)
                                amnt = Math.Round(ex.ItemLineRet.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            double qty = 1;
                            if (ex.ItemLineRet.Quantity != null)
                                qty = ex.ItemLineRet.Quantity.GetValue();
                            bool found_item = false;
                            IItemInventoryRet inv_item = GetInvItem(x, ex.ItemLineRet.ItemRef.ListID.GetValue());
                            if (inv_item != null)
                            {
                                found_item = true;       
                                double cost_total = Math.Round(inv_item.PurchaseCost.GetValue(), 2) * qty;
                                if (cost_total == 0)
                                    cost_total = Math.Round(inv_item.AverageCost.GetValue(), 2) * qty;
                                JournalEntry jei = new JournalEntry(memo);
                                a = account.GetByFullName(x, inv_item.COGSAccountRef.FullName.GetValue());
                                jei.Add(x, a, cost_total, 0);
                                a = account.GetByFullName(x, inv_item.AssetAccountRef.FullName.GetValue());
                                jei.Add(x, a, 0, cost_total);
                                t_date = t_date.AddMilliseconds(ms);
                                if (jei.Balances)
                                    jei.Post(x, t_date);
                                else
                                    x.TheLeader.Tell("Balance Error");
                                a = account.GetByFullName(x, inv_item.IncomeAccountRef.FullName.GetValue());
                            }
                            IItemNonInventoryRet non_item = GetNonInvItem(x, ex.ItemLineRet.ItemRef.ListID.GetValue());
                            if (non_item != null)
                            {
                                found_item = true;
                                if (non_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                else if (non_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                            }
                            IItemServiceRet service_item = GetServiceItem(x, ex.ItemLineRet.ItemRef.ListID.GetValue());
                            if (service_item != null)
                            {
                                found_item = true;
                                if (service_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                else if (service_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                            }
                            IItemFixedAssetRet fixedasset_item = GetFixedAssetItem(x, ex.ItemLineRet.ItemRef.ListID.GetValue());
                            if (fixedasset_item != null)
                            {
                                found_item = true;
                                a = account.GetByFullName(x, fixedasset_item.AssetAccountRef.FullName.GetValue());
                            }
                            if (!found_item)
                            {
                                x.TheLeader.Tell("Could not find item: " + ex.ItemLineRet.ItemRef.FullName.GetValue());
                                return;
                            }
                            je.Add(x, a, amnt, 0);
                        }
                    }
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Error Posting.");
                }
            }
        }
        private void ImportSalesTaxPaymentCheckEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            ISalesTaxPaymentCheckQuery rec = requestSet.AppendSalesTaxPaymentCheckQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORSalesTaxPaymentCheckQuery.TxnIDList.Add(trans.TxnId);
            ISalesTaxPaymentCheckRetList SalesTaxPaymentCheckList = (ISalesTaxPaymentCheckRetList)GetResponse(x, requestSet).Detail;
            if (SalesTaxPaymentCheckList != null)
            {
                for (int i = 0; i < SalesTaxPaymentCheckList.Count; i++)
                {
                    ISalesTaxPaymentCheckRet e = SalesTaxPaymentCheckList.GetAt(i);
                    string memo = "";
                    if (e.Memo != null)
                        memo = e.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double main_amnt = 0;
                    if (e.Amount != null)
                        main_amnt = Math.Round(e.Amount.GetValue(), 2);
                    if (main_amnt == 0)
                        continue;
                    account main_a = null;
                    main_a = account.GetByFullName(x, e.BankAccountRef.FullName.GetValue());
                    if (main_a == null)
                        continue;
                    je.Add(x, main_a, 0, main_amnt);
                    account a = null;
                    double amnt = 0;
                    if (e.SalesTaxPaymentCheckLineRetList != null)
                    {
                        for (int ii = 0; ii < e.SalesTaxPaymentCheckLineRetList.Count; ii++)
                        {
                            ISalesTaxPaymentCheckLineRet cm = e.SalesTaxPaymentCheckLineRetList.GetAt(ii);
                            amnt = 0;
                            if (cm.Amount != null)
                                amnt = Math.Round(cm.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            a = account.GetByFullName(x, "Sales Tax Payable");
                            je.Add(x, a, amnt, 0);
                        }
                        if (je.Balances)
                            je.Post(x, trans.TxnDate);
                        else
                            x.TheLeader.Tell("Error Posting.");
                    }
                }
            }
        }
        private void ImportTransferEntry(ContextRz x, Transaction trans)
        {
            string memo = "";
            account parent = null;
            double amnt = 0;
            string main_acnt = "";
            string ref_numb = "";
            DateTime date = Tools.Dates.GetBlankDate();
            if (trans.Trans.Memo != null)
                memo = trans.Trans.Memo.GetValue();
            if (trans.Trans.Amount != null)
                amnt = Math.Round(trans.Trans.Amount.GetValue(), 2);
            if (trans.Trans.AccountRef != null)
                main_acnt = trans.Trans.AccountRef.FullName.GetValue();
            if (trans.Trans.RefNumber != null)
                ref_numb = trans.Trans.RefNumber.GetValue();
            if (trans.Trans.TxnDate != null)
                date = trans.Trans.TxnDate.GetValue();
            account child = x.TheLeaderRz.ShowQBAccountImportAssist(main_acnt, ref_numb, amnt, date);
            if (child == null)
            {
                x.TheLeader.Tell("Child account was null.");
                return;
            }
            JournalEntry je = new JournalEntry(memo);
            parent = account.GetByFullName(x, trans.Trans.AccountRef.FullName.GetValue());
            je.Add(x, parent, 0, amnt * -1);
            je.Add(x, child, amnt * -1, 0);
            if (je.Balances)
                je.Post(x, date);
            else
                x.TheLeader.Tell("Post Error");
        }
        private void ImportCreditMemoEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            ICreditMemoQuery rec = requestSet.AppendCreditMemoQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORTxnQuery.TxnIDList.Add(trans.TxnId);
            ICreditMemoRetList CreditMemoList = (ICreditMemoRetList)GetResponse(x, requestSet).Detail;
            if (CreditMemoList != null)
            {
                for (int i = 0; i < CreditMemoList.Count; i++)
                {
                    ICreditMemoRet c = CreditMemoList.GetAt(i);
                    string memo = "";
                    if (c.Memo != null)
                        memo = c.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double main_amnt = 0;
                    if (c.TotalAmount != null)
                        main_amnt = Math.Round(c.TotalAmount.GetValue(), 2);
                    if (main_amnt == 0)
                        continue;
                    account main_a = null;
                    main_a = account.GetByFullName(x, c.ARAccountRef.FullName.GetValue());
                    if (main_a == null)
                        continue;
                    je.Add(x, main_a, 0, main_amnt);
                    account a = null;
                    double amnt = 0;
                    DateTime t_date = trans.TxnDate;
                    Double ms = 1;
                    if (c.ORCreditMemoLineRetList != null)
                    {
                        for (int ii = 0; ii < c.ORCreditMemoLineRetList.Count; ii++)
                        {
                            IORCreditMemoLineRet cm = c.ORCreditMemoLineRetList.GetAt(ii);
                            amnt = 0;
                            if (cm.CreditMemoLineRet.Amount != null)
                                amnt = Math.Round(cm.CreditMemoLineRet.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            double qty = 1;
                            if (cm.CreditMemoLineRet.Quantity != null)
                                qty = cm.CreditMemoLineRet.Quantity.GetValue();
                            bool found_item = false;
                            IItemInventoryRet inv_item = GetInvItem(x, cm.CreditMemoLineRet.ItemRef.ListID.GetValue());
                            if (inv_item != null)
                            {
                                found_item = true;
                                double cost_total = Math.Round(inv_item.PurchaseCost.GetValue(), 2) * qty;
                                if (cost_total == 0)
                                    cost_total = Math.Round(inv_item.AverageCost.GetValue(), 2) * qty;
                                JournalEntry jem = new JournalEntry(memo);
                                a = account.GetByFullName(x, inv_item.COGSAccountRef.FullName.GetValue());
                                jem.Add(x, a, cost_total, 0);
                                a = account.GetByFullName(x, inv_item.AssetAccountRef.FullName.GetValue());
                                jem.Add(x, a, 0, cost_total);
                                t_date = t_date.AddMilliseconds(ms);
                                if (jem.Balances)
                                    jem.Post(x, t_date);
                                else
                                    x.TheLeader.Tell("Balance Error");
                                a = account.GetByFullName(x, inv_item.IncomeAccountRef.FullName.GetValue());
                            }
                            IItemNonInventoryRet non_item = GetNonInvItem(x, cm.CreditMemoLineRet.ItemRef.ListID.GetValue());
                            if (non_item != null)
                            {
                                found_item = true;
                                if (non_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                else if (non_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                            }
                            IItemOtherChargeRet other_item = GetOtherChargeItem(x, cm.CreditMemoLineRet.ItemRef.ListID.GetValue());
                            if (other_item != null)
                            {
                                found_item = true;
                                if (other_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                else if (other_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                            }
                            IItemServiceRet service_item = GetServiceItem(x, cm.CreditMemoLineRet.ItemRef.ListID.GetValue());
                            if (service_item != null)
                            {
                                found_item = true;
                                if (service_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                else if (service_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                            }
                            if (!found_item)
                            {
                                x.TheLeader.Tell("Could not find item: " + cm.CreditMemoLineRet.ItemRef.FullName.GetValue());
                                return;
                            }
                            je.Add(x, a, amnt, 0);
                        }
                    }
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Error Posting.");
                }
            }
        }
        private void ImportCheckEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            ICheckQuery rec = requestSet.AppendCheckQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORTxnQuery.TxnIDList.Add(trans.TxnId);
            ICheckRetList CheckList = (ICheckRetList)GetResponse(x, requestSet).Detail;
            if (CheckList != null)
            {
                for (int i = 0; i < CheckList.Count; i++)
                {
                    ICheckRet b = CheckList.GetAt(i);
                    string memo = "";
                    if (b.Memo != null)
                        memo = b.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double main_amnt = 0;
                    if (b.Amount != null)
                        main_amnt = Math.Round(b.Amount.GetValue(), 2);
                    if (main_amnt == 0)
                        continue;
                    account main_a = null;
                    main_a = account.GetByFullName(x, b.AccountRef.FullName.GetValue());
                    if (main_a == null)
                        continue;
                    je.Add(x, main_a, 0, main_amnt);
                    account a = null;
                    double amnt = 0;
                    if (b.ExpenseLineRetList != null)
                    {
                        for (int ii = 0; ii < b.ExpenseLineRetList.Count; ii++)
                        {
                            IExpenseLineRet ex = b.ExpenseLineRetList.GetAt(ii);
                            amnt = 0;
                            if (ex.Amount != null)
                                amnt = Math.Round(ex.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            a = account.GetByFullName(x, ex.AccountRef.FullName.GetValue());
                            je.Add(x, a, amnt, 0);
                        }
                    }
                    if (b.ORItemLineRetList != null)
                    {
                        for (int ii = 0; ii < b.ORItemLineRetList.Count; ii++)
                        {
                            IORItemLineRet ex = b.ORItemLineRetList.GetAt(ii);
                            amnt = 0;
                            if (ex.ItemLineRet.Amount != null)
                                amnt = Math.Round(ex.ItemLineRet.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            bool found_item = false;
                            IItemInventoryRet inv_item = GetInvItem(x, ex.ItemLineRet.ItemRef.ListID.GetValue());
                            if (inv_item != null)
                            {
                                found_item = true;
                                a = account.GetByFullName(x, "");
                            }
                            IItemNonInventoryRet non_item = GetNonInvItem(x, ex.ItemLineRet.ItemRef.ListID.GetValue());
                            if (non_item != null)
                            {
                                found_item = true;
                                if (non_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                else if (non_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                            }
                            IItemFixedAssetRet fixedasset_item = GetFixedAssetItem(x, ex.ItemLineRet.ItemRef.ListID.GetValue());
                            if (fixedasset_item != null)
                            {
                                found_item = true;
                                a = account.GetByFullName(x, fixedasset_item.AssetAccountRef.FullName.GetValue());
                            }
                            IItemServiceRet service_item = GetServiceItem(x, ex.ItemLineRet.ItemRef.ListID.GetValue());
                            if (service_item != null)
                            {
                                found_item = true;
                                if (service_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                else if (service_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                            }
                            IItemOtherChargeRet other_item = GetOtherChargeItem(x, ex.ItemLineRet.ItemRef.ListID.GetValue());
                            if (other_item != null)
                            {
                                found_item = true;
                                if (other_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                else if (other_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                            }
                            if (!found_item)
                            {
                                x.TheLeader.Tell("Could not find item: " + ex.ItemLineRet.ItemRef.FullName.GetValue());
                                return;
                            }
                            je.Add(x, a, amnt, 0);
                        }
                    }
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Error Posting.");
                }
            }
        }
        private void ImportJournalEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IJournalEntryQuery rec = requestSet.AppendJournalEntryQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORTxnQuery.TxnIDList.Add(trans.TxnId);
            IJournalEntryRetList JournalEntryList = (IJournalEntryRetList)GetResponse(x, requestSet).Detail;
            if (JournalEntryList != null)
            {
                for (int i = 0; i < JournalEntryList.Count; i++)
                {
                    IJournalEntryRet b = JournalEntryList.GetAt(i);
                    string memo = "";
                    account a = null;
                    double amnt = 0;
                    if (b.Memo != null)
                        memo = b.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    if (b.ORJournalLineList != null)
                    {
                        for (int ii = 0; ii < b.ORJournalLineList.Count; ii++)
                        {                            
                            IORJournalLine j = b.ORJournalLineList.GetAt(ii);
                            if (j.JournalCreditLine != null)
                            {
                                amnt = 0;
                                if (j.JournalCreditLine.Amount != null)
                                    amnt = Math.Round(j.JournalCreditLine.Amount.GetValue(), 2);
                                if (amnt == 0)
                                    continue;
                                a = account.GetByFullName(x, j.JournalCreditLine.AccountRef.FullName.GetValue());
                                je.Add(x, a, 0, amnt);
                            }
                            if (j.JournalDebitLine != null)
                            {
                                amnt = 0;
                                if (j.JournalDebitLine.Amount != null)
                                    amnt = Math.Round(j.JournalDebitLine.Amount.GetValue(), 2);
                                if (amnt == 0)
                                    continue;
                                a = account.GetByFullName(x, j.JournalDebitLine.AccountRef.FullName.GetValue());
                                je.Add(x, a, amnt, 0);
                            }
                        }
                        if (je.Balances)
                            je.Post(x, trans.TxnDate);
                        else
                            x.TheLeader.Tell("Error Posting.");
                    }
                }
            }
        }
        private void ImportBillPaymentCheckEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IBillPaymentCheckQuery rec = requestSet.AppendBillPaymentCheckQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORTxnQuery.TxnIDList.Add(trans.TxnId);
            IBillPaymentCheckRetList BillList = (IBillPaymentCheckRetList)GetResponse(x, requestSet).Detail;
            if (BillList != null)
            {
                for (int i = 0; i < BillList.Count; i++)
                {
                    IBillPaymentCheckRet b = BillList.GetAt(i);
                    string memo = "";
                    account a = null;
                    if (b.Memo != null)
                        memo = b.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double amnt = 0;
                    if (b.Amount != null)
                        amnt = Math.Round(b.Amount.GetValue(), 2);
                    if (amnt == 0)
                        continue;
                    a = account.GetByFullName(x, b.BankAccountRef.FullName.GetValue());
                    je.Add(x, a, 0, amnt);
                    a = account.GetByFullName(x, b.APAccountRef.FullName.GetValue());
                    je.Add(x, a, amnt, 0);
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Error Posting.");
                }
            }
        }
        private void ImportReceivePaymentEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IReceivePaymentQuery rec = requestSet.AppendReceivePaymentQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORTxnQuery.TxnIDList.Add(trans.TxnId);
            IReceivePaymentRetList PayList = (IReceivePaymentRetList)GetResponse(x, requestSet).Detail;
            if (PayList != null)
            {
                for (int i = 0; i < PayList.Count; i++)
                {
                    IReceivePaymentRet r = PayList.GetAt(i);
                    account a = null;
                    string memo = "";                    
                    if (r.Memo != null)
                        memo = r.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double amnt = 0;
                    if (r.TotalAmount != null)
                        amnt = Math.Round(r.TotalAmount.GetValue(), 2);
                    if (amnt == 0)
                        continue;
                    a = account.GetByFullName(x, r.DepositToAccountRef.FullName.GetValue());
                    je.Add(x, a, amnt, 0);
                    a = account.GetByFullName(x, r.ARAccountRef.FullName.GetValue());
                    je.Add(x, a, 0, amnt);
                    je.Description = memo;
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Error Posting.");
                }
            }
        }
        private void ImportBillEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IBillQuery bill = requestSet.AppendBillQueryRq();
            bill.IncludeLineItems.SetValue(true);
            bill.IncludeLinkedTxns.SetValue(true);
            bill.ORBillQuery.TxnIDList.Add(trans.TxnId);
            IBillRetList BillList = (IBillRetList)GetResponse(x, requestSet).Detail;
            if (BillList != null)
            {
                for (int i = 0; i < BillList.Count; i++)
                {
                    IBillRet d = BillList.GetAt(i);
                    string memo = "";
                    if (d.Memo != null)
                        memo = d.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double main_amnt = 0;
                    if (d.AmountDue != null)
                        main_amnt = Math.Round(d.AmountDue.GetValue(), 2);
                    if (main_amnt == 0)
                        continue;
                    account main_a = null;
                    main_a = account.GetByFullName(x, d.APAccountRef.FullName.GetValue());
                    if (main_a == null)
                        continue;
                    je.Add(x, main_a, 0, main_amnt);
                    account a = null;
                    double amnt = 0;
                    double ms = 1;
                    DateTime t_date = trans.TxnDate;
                    if (d.ORItemLineRetList != null)
                    {
                        for (int ii = 0; ii < d.ORItemLineRetList.Count; ii++)
                        {
                            IORItemLineRet il = d.ORItemLineRetList.GetAt(ii);
                            double qty = 1;
                            amnt = 0;
                            if (il.ItemLineRet.Quantity != null)
                                qty = il.ItemLineRet.Quantity.GetValue();
                            if (il.ItemLineRet.Amount != null)
                                amnt = Math.Round(il.ItemLineRet.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            bool found_item = false;
                            IItemInventoryRet inv_item = GetInvItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (inv_item != null)
                            {
                                found_item = true;
                                double cost_total = Math.Round(inv_item.PurchaseCost.GetValue(), 2) * qty;
                                if (cost_total == 0)
                                    cost_total = Math.Round(inv_item.AverageCost.GetValue(), 2) * qty;
                                JournalEntry jem = new JournalEntry(memo);
                                a = account.GetByFullName(x, inv_item.COGSAccountRef.FullName.GetValue());
                                jem.Add(x, a, cost_total, 0);
                                a = account.GetByFullName(x, inv_item.AssetAccountRef.FullName.GetValue());
                                jem.Add(x, a, 0, cost_total);
                                t_date = t_date.AddMilliseconds(ms);
                                if (jem.Balances)
                                    jem.Post(x, t_date);
                                else
                                    x.TheLeader.Tell("Balance Error");
                                a = account.GetByFullName(x, inv_item.IncomeAccountRef.FullName.GetValue());
                            }
                            IItemNonInventoryRet non_item = GetNonInvItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (non_item != null)
                            {
                                found_item = true;
                                if (non_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                else if (non_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                            }
                            IItemServiceRet service_item = GetServiceItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (service_item != null)
                            {
                                found_item = true;
                                if (service_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                else if (service_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                            }
                            IItemOtherChargeRet other_item = GetOtherChargeItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (other_item != null)
                            {
                                found_item = true;
                                if (other_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                else if (other_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                            }
                            IItemFixedAssetRet fixed_item = GetFixedAssetItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (fixed_item != null)
                            {
                                found_item = true;
                                a = account.GetByFullName(x, fixed_item.AssetAccountRef.FullName.GetValue());
                            }
                            if (!found_item)
                            {
                                x.TheLeader.Tell("Could not find item: " + il.ItemLineRet.ItemRef.FullName.GetValue());
                                return;
                            }
                            je.Add(x, a, amnt, 0);
                        }
                    }
                    if (d.ExpenseLineRetList != null)
                    {
                        for (int ii = 0; ii < d.ExpenseLineRetList.Count; ii++)
                        {
                            amnt = 0;
                            IExpenseLineRet e = d.ExpenseLineRetList.GetAt(ii);
                            if (e.Amount == null)
                                continue;                           
                            amnt = Math.Round(e.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            a = account.GetByFullName(x, e.AccountRef.FullName.GetValue());
                            je.Add(x, a, amnt, 0);
                        }
                    }
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Balance Error");
                }
            }
        }
        private void ImportDepositEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IDepositQuery dep = requestSet.AppendDepositQueryRq();
            dep.IncludeLineItems.SetValue(true);
            dep.ORDepositQuery.TxnIDList.Add(trans.TxnId);
            IDepositRetList DepositList = (IDepositRetList)GetResponse(x, requestSet).Detail;
            if (DepositList != null)
            {
                for (int i = 0; i < DepositList.Count; i++)
                {
                    IDepositRet d = DepositList.GetAt(i);                    
                    string memo = "";
                    if (d.Memo != null)
                        memo = d.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double main_amnt = 0;
                    if (d.DepositTotal != null)
                        main_amnt = Math.Round(d.DepositTotal.GetValue(), 2);
                    if (main_amnt == 0)
                        continue;
                    account main_a = null;
                    main_a = account.GetByFullName(x, d.DepositToAccountRef.FullName.GetValue());
                    if (main_a == null)
                        continue;
                    je.Add(x, main_a, main_amnt, 0);
                    account a = null;
                    double amnt = 0;
                    if (d.DepositLineRetList != null)
                    {
                        for (int ii = 0; ii < d.DepositLineRetList.Count; ii++)
                        {
                            amnt = 0;
                            IDepositLineRet dl = d.DepositLineRetList.GetAt(ii);
                            if (dl.Amount != null)
                                amnt = Math.Round(dl.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            a = account.GetByFullName(x, dl.AccountRef.FullName.GetValue());
                            je.Add(x, a, 0, amnt);
                        }
                    }
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Error Posting.");
                }
            }
        }
        private void ImportInvoiceEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IInvoiceQuery inv = requestSet.AppendInvoiceQueryRq();
            inv.IncludeLineItems.SetValue(true);
            inv.IncludeLinkedTxns.SetValue(true);
            inv.ORInvoiceQuery.TxnIDList.Add(trans.TxnId);
            IInvoiceRetList InvoiceList = (IInvoiceRetList)GetResponse(x, requestSet).Detail;
            if (InvoiceList != null)
            {
                for (int i = 0; i < InvoiceList.Count; i++)
                {
                    IInvoiceRet d = InvoiceList.GetAt(i);                    
                    string memo = "";                                        
                    if (d.Memo != null)
                        memo = d.Memo.GetValue();
                    account main_a = null;
                    if (d.ARAccountRef != null)
                        main_a = account.GetByFullName(x, d.ARAccountRef.FullName.GetValue());
                    if (main_a == null)
                        continue;
                    double main_amnt = 0;
                    if (d.Subtotal != null)
                        main_amnt = Math.Round(d.Subtotal.GetValue(), 2);
                    if (main_amnt == 0)
                        continue;
                    DateTime t_date = trans.TxnDate;
                    JournalEntry jem = new JournalEntry(memo);
                    jem.Add(x, main_a, main_amnt, 0);
                    double ms = 1;
                    if (d.ORInvoiceLineRetList != null)
                    {
                        for (int ii = 0; ii < d.ORInvoiceLineRetList.Count; ii++)
                        {
                            if (d.RefNumber != null)
                                memo = d.RefNumber.GetValue();
                            account a = null;
                            IORInvoiceLineRet il = d.ORInvoiceLineRetList.GetAt(ii);
                            double qty = 1;
                            double amnt = 0;
                            string item_id = "";
                            string item_name = "";
                            if (il.InvoiceLineRet != null)
                            {
                                amnt = 0;
                                if (il.InvoiceLineRet.Quantity != null)
                                    qty = Math.Round(il.InvoiceLineRet.Quantity.GetValue(), 2);
                                if (il.InvoiceLineRet.Amount != null)
                                    amnt = Math.Round(il.InvoiceLineRet.Amount.GetValue(), 2);
                                if (il.InvoiceLineRet.ItemRef != null)
                                {
                                    item_id = il.InvoiceLineRet.ItemRef.ListID.GetValue();
                                    item_name = il.InvoiceLineRet.ItemRef.FullName.GetValue();
                                }
                            }
                            else if (il.InvoiceLineGroupRet != null)
                            {
                                amnt = 0;
                                if (il.InvoiceLineGroupRet.Quantity != null)
                                    qty = Math.Round(il.InvoiceLineGroupRet.Quantity.GetValue(), 2);
                                if (il.InvoiceLineGroupRet.TotalAmount != null)
                                    amnt = Math.Round(il.InvoiceLineGroupRet.TotalAmount.GetValue(), 2);
                                if (il.InvoiceLineGroupRet.ItemGroupRef != null)
                                {
                                    item_id = il.InvoiceLineGroupRet.ItemGroupRef.ListID.GetValue();
                                    item_name = il.InvoiceLineGroupRet.ItemGroupRef.FullName.GetValue();
                                }
                            }
                            else
                                continue;
                            if (!Tools.Strings.StrExt(item_id))
                                continue;
                            bool found_item = false;
                            IItemInventoryRet inv_item = GetInvItem(x, item_id);
                            if (inv_item != null)
                            {
                                found_item = true;
                                double cost_total = Math.Round(inv_item.PurchaseCost.GetValue(), 2) * qty;
                                if (cost_total == 0)
                                    cost_total = Math.Round(inv_item.AverageCost.GetValue(), 2) * qty;
                                JournalEntry je = new JournalEntry(memo);
                                a = account.GetByFullName(x, inv_item.COGSAccountRef.FullName.GetValue());
                                je.Add(x, a, cost_total, 0);
                                a = account.GetByFullName(x, inv_item.AssetAccountRef.FullName.GetValue());
                                je.Add(x, a, 0, cost_total);
                                t_date = t_date.AddMilliseconds(ms);
                                if (je.Balances)
                                    je.Post(x, t_date);
                                else
                                    x.TheLeader.Tell("Balance Error");
                                a = account.GetByFullName(x, inv_item.IncomeAccountRef.FullName.GetValue());
                                jem.Add(x, a, 0, amnt);
                            }
                            IItemNonInventoryRet non_item = GetNonInvItem(x, item_id);
                            if (non_item != null)
                            {
                                found_item = true;
                                if (non_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.GetValue());
                                else if (non_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                jem.Add(x, a, 0, amnt);
                            }
                            IItemOtherChargeRet other_item = GetOtherChargeItem(x, item_id);
                            if (other_item != null)
                            {
                                found_item = true;
                                if (other_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.GetValue());
                                else if (other_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                jem.Add(x, a, 0, amnt);
                            }
                            IItemServiceRet service_item = GetServiceItem(x, item_id);
                            if (service_item != null)
                            {
                                found_item = true;
                                if (service_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.GetValue());
                                else if (service_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                jem.Add(x, a, 0, amnt);
                            }
                            IItemGroupRet group_item = GetGroupItem(x, item_id);
                            if (group_item != null)
                            {
                                found_item = true;
                                if (group_item.ItemGroupLineList != null)
                                {
                                    for (int ig = 0; ig < group_item.ItemGroupLineList.Count; ig++)
                                    {
                                        IItemGroupLine gl = group_item.ItemGroupLineList.GetAt(ig);
                                        IItemInventoryRet inv_item_g = GetInvItem(x, gl.ItemRef.ListID.GetValue());
                                        if (inv_item_g != null)
                                        {
                                            double cost_total = Math.Round(inv_item_g.PurchaseCost.GetValue(), 2) * qty;
                                            if (cost_total == 0)
                                                cost_total = Math.Round(inv_item_g.AverageCost.GetValue(), 2) * qty;
                                            JournalEntry je = new JournalEntry(memo);
                                            a = account.GetByFullName(x, inv_item_g.COGSAccountRef.FullName.GetValue());
                                            je.Add(x, a, cost_total, 0);
                                            a = account.GetByFullName(x, inv_item_g.AssetAccountRef.FullName.GetValue());
                                            je.Add(x, a, 0, cost_total);
                                            t_date = t_date.AddMilliseconds(ms);
                                            if (je.Balances)
                                                je.Post(x, t_date);
                                            else
                                                x.TheLeader.Tell("Balance Error");
                                            a = account.GetByFullName(x, inv_item_g.IncomeAccountRef.FullName.GetValue());
                                            amnt = Math.Round(inv_item_g.SalesPrice.GetValue(), 2) * qty;
                                            jem.Add(x, a, 0, amnt);
                                        }
                                        else
                                        {
                                            x.TheLeader.Tell("Inv item null for group");
                                            continue;
                                        }
                                    }
                                }
                                else
                                    continue;
                            }
                            IItemSubtotalRet subtotal_item = GetSubtotalItem(x, item_id);
                            if (subtotal_item != null)//Subtotal item not included in post.
                                continue;
                            if (!found_item)
                            {
                                x.TheLeader.Tell("Could not find item: " + item_name);
                                return;
                            }
                        }
                    }
                    if (jem.Balances)
                        jem.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Balance Error");
                }
            }
        }
        private void ImportInventoryAdjustmentEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IInventoryAdjustmentQuery rec = requestSet.AppendInventoryAdjustmentQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORInventoryAdjustmentQuery.TxnIDList.Add(trans.TxnId);
            IInventoryAdjustmentRetList InventoryAdjustmentList = (IInventoryAdjustmentRetList)GetResponse(x, requestSet).Detail;
            if (InventoryAdjustmentList != null)
            {
                for (int i = 0; i < InventoryAdjustmentList.Count; i++)
                {
                    IInventoryAdjustmentRet e = InventoryAdjustmentList.GetAt(i);                    
                    account a = null;
                    string memo = "";
                    if (e.Memo != null)
                        memo = e.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double total_amnt = 0;
                    if (e.InventoryAdjustmentLineRetList != null)
                    {
                        for (int ii = 0; ii < e.InventoryAdjustmentLineRetList.Count; ii++)
                        {
                            IInventoryAdjustmentLineRet cm = e.InventoryAdjustmentLineRetList.GetAt(ii);
                            if (cm.ValueDifference == null)
                                continue;
                            double amnt = Math.Round(cm.ValueDifference.GetValue(), 2);
                            total_amnt += amnt;
                            bool neg = false;
                            if (amnt < 0)
                            {
                                neg = true;
                                amnt = amnt * -1;
                            }
                            bool found_item = false;
                            IItemInventoryRet inv_item = GetInvItem(x, cm.ItemRef.ListID.GetValue());
                            if (inv_item != null)
                            {
                                found_item = true;
                                a = account.GetByFullName(x, inv_item.AssetAccountRef.FullName.GetValue());
                                if (neg)
                                    je.Add(x, a, 0, amnt);
                                else
                                    je.Add(x, a, amnt, 0);
                            }
                            IItemNonInventoryRet non_item = GetNonInvItem(x, cm.ItemRef.ListID.GetValue());
                            if (non_item != null)
                            {
                                found_item = true;
                            }
                            IItemOtherChargeRet other_item = GetOtherChargeItem(x, cm.ItemRef.ListID.GetValue());
                            if (other_item != null)
                            {
                                found_item = true;
                            }
                            IItemServiceRet service_item = GetServiceItem(x, cm.ItemRef.ListID.GetValue());
                            if (service_item != null)
                            {
                                found_item = true;
                            }
                            IItemInventoryAssemblyRet invass_item = GetInventoryAssemblyItem(x, cm.ItemRef.ListID.GetValue());
                            if (invass_item != null)
                            {
                                found_item = true;
                                a = account.GetByFullName(x, invass_item.AssetAccountRef.FullName.GetValue());
                                if (neg)
                                    je.Add(x, a, 0, amnt);
                                else
                                    je.Add(x, a, amnt, 0);
                            }
                            if (!found_item)
                            {
                                x.TheLeader.Tell("Could not find item: " + cm.ItemRef.FullName.GetValue());
                                return;
                            }
                        }
                        a = account.GetByFullName(x, e.AccountRef.FullName.GetValue());
                        if (total_amnt < 0)
                            je.Add(x, a, total_amnt * -1, 0);
                        else
                            je.Add(x, a, 0, total_amnt);
                        if (je.Balances)
                            je.Post(x, trans.TxnDate);
                        else
                            x.TheLeader.Tell("Balance Error");
                    }
                }
            }
        }
        private void ImportVendorCreditEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IVendorCreditQuery rec = requestSet.AppendVendorCreditQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORTxnQuery.TxnIDList.Add(trans.TxnId);
            IVendorCreditRetList VendorCreditList = (IVendorCreditRetList)GetResponse(x, requestSet).Detail;
            if (VendorCreditList != null)
            {
                for (int i = 0; i < VendorCreditList.Count; i++)
                {
                    IVendorCreditRet e = VendorCreditList.GetAt(i);
                    string memo = "";
                    if (e.Memo != null)
                        memo = e.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double main_amnt = 0;
                    if (e.CreditAmount != null)
                        main_amnt = Math.Round(e.CreditAmount.GetValue(), 2);
                    if (main_amnt == 0)
                        continue;
                    account main_a = null;
                    main_a = account.GetByFullName(x, e.APAccountRef.FullName.GetValue());
                    if (main_a == null)
                        continue;
                    je.Add(x, main_a, 0, main_amnt);
                    account a = null;
                    double amnt = 0;
                    if (e.ORItemLineRetList != null)
                    {
                        for (int ii = 0; ii < e.ORItemLineRetList.Count; ii++)
                        {
                            IORItemLineRet il = e.ORItemLineRetList.GetAt(ii);
                            double qty = 1;
                            if (il.ItemLineRet.Quantity != null)
                                qty = il.ItemLineRet.Quantity.GetValue();
                            amnt = 0;
                            if (il.ItemLineRet.Amount != null)
                                amnt = Math.Round(il.ItemLineRet.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            bool found_item = false;
                            IItemInventoryRet inv_item = GetInvItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (inv_item != null)
                            {
                                found_item = true;
                                a = account.GetByFullName(x, inv_item.AssetAccountRef.FullName.GetValue());
                            }
                            IItemNonInventoryRet non_item = GetNonInvItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (non_item != null)
                            {
                                found_item = true;
                                if (non_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                else if (non_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                            }
                            IItemServiceRet service_item = GetServiceItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (service_item != null)
                            {
                                found_item = true;
                                if (service_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                else if (service_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                            }
                            IItemOtherChargeRet other_item = GetOtherChargeItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (other_item != null)
                            {
                                found_item = true;
                                if (other_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                else if (other_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                            }
                            IItemFixedAssetRet fixed_item = GetFixedAssetItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (fixed_item != null)
                            {
                                found_item = true;
                                a = account.GetByFullName(x, fixed_item.AssetAccountRef.FullName.GetValue());
                            }
                            if (!found_item)
                            {
                                x.TheLeader.Tell("Could not find item: " + il.ItemLineRet.ItemRef.FullName.GetValue());
                                return;
                            }
                            je.Add(x, a, amnt, 0);
                        }
                    }
                    if (e.ExpenseLineRetList != null)
                    {
                        for (int ii = 0; ii < e.ExpenseLineRetList.Count; ii++)
                        {
                            IExpenseLineRet er = e.ExpenseLineRetList.GetAt(ii);
                            if (er.Amount == null)
                                continue;
                            amnt = Math.Round(er.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            a = account.GetByFullName(x, er.AccountRef.FullName.GetValue());
                            je.Add(x, a, amnt, 0);
                        }                        
                    }
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Balance Error");
                }
            }
        }
        private void ImportBillPaymentCreditCardEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IBillPaymentCreditCardQuery rec = requestSet.AppendBillPaymentCreditCardQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORTxnQuery.TxnIDList.Add(trans.TxnId);
            IBillPaymentCreditCardRetList BillPaymentCreditCardList = (IBillPaymentCreditCardRetList)GetResponse(x, requestSet).Detail;
            if (BillPaymentCreditCardList != null)
            {
                for (int i = 0; i < BillPaymentCreditCardList.Count; i++)
                {
                    IBillPaymentCreditCardRet e = BillPaymentCreditCardList.GetAt(i);
                    string memo = "";
                    if (e.Memo != null)
                        memo = e.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double amnt = 0;
                    if (e.Amount != null)
                        amnt = Math.Round(e.Amount.GetValue(), 2);
                    if (amnt == 0)
                        continue;
                    account a = null;
                    a = account.GetByFullName(x, e.APAccountRef.FullName.GetValue());
                    je.Add(x, a, 0, amnt);
                    a = account.GetByFullName(x, e.CreditCardAccountRef.FullName.GetValue());
                    je.Add(x, a, amnt, 0);
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Error Posting.");
                }
            }
        }
        private void ImportCreditCardCreditEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            ICreditCardCreditQuery rec = requestSet.AppendCreditCardCreditQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORTxnQuery.TxnIDList.Add(trans.TxnId);
            ICreditCardCreditRetList CreditCardCreditList = (ICreditCardCreditRetList)GetResponse(x, requestSet).Detail;
            if (CreditCardCreditList != null)
            {
                for (int i = 0; i < CreditCardCreditList.Count; i++)
                {
                    ICreditCardCreditRet e = CreditCardCreditList.GetAt(i);
                    string memo = "";
                    if (e.Memo != null)
                        memo = e.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double main_amnt = 0;
                    if (e.Amount != null)
                        main_amnt = Math.Round(e.Amount.GetValue(), 2);
                    if (main_amnt == 0)
                        continue;
                    account main_a = null;
                    main_a = account.GetByFullName(x, e.AccountRef.FullName.GetValue());
                    if (main_a == null)
                        continue;
                    je.Add(x, main_a, main_amnt, 0);
                    account a = null;
                    double amnt = 0;
                    if (e.ORItemLineRetList != null)
                    {
                        for (int ii = 0; ii < e.ORItemLineRetList.Count; ii++)
                        {
                            IORItemLineRet il = e.ORItemLineRetList.GetAt(ii);
                            double qty = 1;
                            if (il.ItemLineRet.Quantity != null)
                                qty = il.ItemLineRet.Quantity.GetValue();
                            amnt = 0;
                            if (il.ItemLineRet.Amount != null)
                                amnt = Math.Round(il.ItemLineRet.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            bool found_item = false;
                            IItemInventoryRet inv_item = GetInvItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (inv_item != null)
                            {
                                found_item = true;
                                a = account.GetByFullName(x, inv_item.AssetAccountRef.FullName.GetValue());
                            }
                            IItemNonInventoryRet non_item = GetNonInvItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (non_item != null)
                            {
                                found_item = true;
                                if (non_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                else if (non_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                            }
                            IItemServiceRet service_item = GetServiceItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (service_item != null)
                            {
                                found_item = true;
                                if (service_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                else if (service_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                            }
                            IItemOtherChargeRet other_item = GetOtherChargeItem(x, il.ItemLineRet.ItemRef.ListID.GetValue());
                            if (other_item != null)
                            {
                                found_item = true;
                                if (other_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                else if (other_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                            }
                            if (!found_item)
                            {
                                x.TheLeader.Tell("Could not find item: " + il.ItemLineRet.ItemRef.FullName.GetValue());
                                return;
                            }
                            je.Add(x, a, 0, amnt);
                        }
                    }
                    if (e.ExpenseLineRetList != null)
                    {
                        for (int ii = 0; ii < e.ExpenseLineRetList.Count; ii++)
                        {
                            IExpenseLineRet er = e.ExpenseLineRetList.GetAt(ii);
                            if (er.Amount == null)
                                continue;
                            amnt = Math.Round(er.Amount.GetValue(), 2);
                            if (amnt == 0)
                                continue;
                            a = account.GetByFullName(x, er.AccountRef.FullName.GetValue());
                            je.Add(x, a, 0, amnt);
                        }
                    }
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Balance Error");
                }
            }
        }
        private void ImportARRefundCreditCardEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IARRefundCreditCardQuery rec = requestSet.AppendARRefundCreditCardQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORARRefundCreditCardQuery.TxnIDList.Add(trans.TxnId);
            IARRefundCreditCardRetList ARRefundCreditCardList = (IARRefundCreditCardRetList)GetResponse(x, requestSet).Detail;
            if (ARRefundCreditCardList != null)
            {
                for (int i = 0; i < ARRefundCreditCardList.Count; i++)
                {
                    IARRefundCreditCardRet e = ARRefundCreditCardList.GetAt(i);
                    string memo = "";
                    if (e.Memo != null)
                        memo = e.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double main_amnt = 0;
                    if (e.TotalAmount != null)
                        main_amnt = Math.Round(e.TotalAmount.GetValue(), 2);
                    if (main_amnt == 0)
                        continue;
                    account main_a = null;
                    main_a = account.GetByFullName(x, e.ARAccountRef.FullName.GetValue());
                    if (main_a == null)
                        continue;
                    je.Add(x, main_a, main_amnt, 0);
                    account a = account.GetByFullName(x, e.RefundFromAccountRef.FullName.GetValue());
                    je.Add(x, a, 0, main_amnt);
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Balance Error");
                }
            }
        }
        private void ImportSalesReceiptEntry(ContextRz x, Transaction trans)
        {
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            ISalesReceiptQuery rec = requestSet.AppendSalesReceiptQueryRq();
            rec.IncludeLineItems.SetValue(true);
            rec.ORTxnQuery.TxnIDList.Add(trans.TxnId);
            ISalesReceiptRetList SalesReceiptList = (ISalesReceiptRetList)GetResponse(x, requestSet).Detail;
            if (SalesReceiptList != null)
            {
                for (int i = 0; i < SalesReceiptList.Count; i++)
                {
                    ISalesReceiptRet e = SalesReceiptList.GetAt(i);
                    string memo = "";
                    if (e.Memo != null)
                        memo = e.Memo.GetValue();
                    JournalEntry je = new JournalEntry(memo);
                    double main_amnt = 0;
                    if (e.TotalAmount != null)
                        main_amnt = Math.Round(e.TotalAmount.GetValue(), 2);
                    if (main_amnt == 0)
                        continue;
                    account main_a = null;
                    main_a = account.GetByFullName(x, e.DepositToAccountRef.FullName.GetValue());
                    if (main_a == null)
                        continue;
                    je.Add(x, main_a, main_amnt, 0);
                    account a = null;
                    double amnt = 0;
                    if (e.ORSalesReceiptLineRetList != null)
                    {
                        for (int ii = 0; ii < e.ORSalesReceiptLineRetList.Count; ii++)
                        {
                            IORSalesReceiptLineRet r = e.ORSalesReceiptLineRetList.GetAt(ii);
                            amnt = 0;
                            if (r.SalesReceiptLineRet.Amount != null)
                                amnt = r.SalesReceiptLineRet.Amount.GetValue();
                            if (amnt == 0)
                                continue;
                            double qty = 1;
                            if (r.SalesReceiptLineRet.Quantity != null)
                                qty = r.SalesReceiptLineRet.Quantity.GetValue();
                            bool found_item = false;
                            string item_id = r.SalesReceiptLineRet.ItemRef.ListID.GetValue();
                            string item_name = r.SalesReceiptLineRet.ItemRef.FullName.GetValue();
                            IItemInventoryRet inv_item = GetInvItem(x, item_id);
                            if (inv_item != null)
                            {
                                found_item = true;
                                a = account.GetByFullName(x, inv_item.AssetAccountRef.FullName.GetValue());
                            }
                            IItemNonInventoryRet non_item = GetNonInvItem(x, item_id);
                            if (non_item != null)
                            {
                                found_item = true;
                                if (non_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                else if (non_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, non_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                            }
                            IItemServiceRet service_item = GetServiceItem(x, item_id);
                            if (service_item != null)
                            {
                                found_item = true;
                                if (service_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                                else if (service_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, service_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                            }
                            IItemOtherChargeRet other_item = GetOtherChargeItem(x, item_id);
                            if (other_item != null)
                            {
                                found_item = true;
                                if (other_item.ORSalesPurchase.SalesAndPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                else if (other_item.ORSalesPurchase.SalesOrPurchase != null)
                                    a = account.GetByFullName(x, other_item.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                            }
                            if (!found_item)
                            {
                                x.TheLeader.Tell("Could not find item: " + item_name);
                                return;
                            }
                            je.Add(x, a, 0, amnt);                            
                        }
                    }
                    if (je.Balances)
                        je.Post(x, trans.TxnDate);
                    else
                        x.TheLeader.Tell("Balance Error");
                }
            }
        }

        public static void GetTransferCount(ContextRz x)
        {
            if (x == null)
                return;
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            ITransactionQuery trans = requestSet.AppendTransactionQueryRq();
            trans.ORTransactionQuery.TransactionFilter.TransactionTypeFilter.TxnTypeFilterList.Add(ENTxnTypeFilter.ttfTransfer);
            ITransactionRetList TransactionList = (ITransactionRetList)GetResponse(x, requestSet).Detail;
            SortedDictionary<DateTime, ArrayList> transactions = new SortedDictionary<DateTime, ArrayList>();
            if (TransactionList != null)
                x.TheLeader.Tell("Transfer Count: " + TransactionList.Count.ToString());
        }
        private class Transaction
        {
            public DateTime TxnDate;
            public String TxnId = "";
            public ENTxnType TxnType;
            public ITransactionRet Trans;

            public Transaction(ITransactionRet t, DateTime d)
            {
                Trans = t;
                DateTime x = t.TimeCreated.GetValue();
                TxnDate = new DateTime(d.Year, d.Month, d.Day, x.Hour, x.Minute, x.Second);
                TxnType = t.TxnType.GetValue();
                TxnId = Trans.TxnID.GetValue();
            }
        }


        public virtual void ImportAccountsQuickBooks(ContextRz x)
        {
            x.TheLeader.Comment("Importing QB Accounts");
            if (x == null)
                return;
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;    
            IAccountQuery q = requestSet.AppendAccountQueryRq();
            q.ORAccountListQuery.AccountListFilter.ActiveStatus.SetValue(ENActiveStatus.asAll);
            if (!x.TheSysRz.TheQuickBooksLogic.Connect(x))
                return;
            IMsgSetResponse responseSet = x.TheSysRz.TheQuickBooksLogic.sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            IAccountRetList AccountList = (IAccountRetList)response.Detail;
            IAccountRet AccountRet = AccountList.GetAt(0);
            x.TheSysRz.TheQuickBooksLogic.Disconnect();
            for (int i = 0; i < AccountList.Count; i++)
            {
                IAccountRet acnt = AccountList.GetAt(i);
                ENAccountType t = acnt.AccountType.GetValue();
                if (t == ENAccountType.atNonPosting)
                    continue;
                String fullname = acnt.FullName.GetValue().ToString();
                String name = acnt.Name.GetValue().ToString();
                AccountType type = GetRzAccountType(t);
                int numb = 0;
                if (acnt.AccountNumber != null)
                {
                    if (!acnt.AccountNumber.IsEmpty())
                    {
                        string n = acnt.AccountNumber.GetValue().ToString();
                        if (Tools.Strings.StrExt(n))
                        {
                            if (Tools.Number.IsNumeric(n))
                                numb = Convert.ToInt32(n);
                        }
                    }
                }
                double bal = 0;
                if (acnt.Balance != null)
                    bal = acnt.Balance.GetValue();
                string descr = "";
                if (acnt.Desc != null)
                {
                    if (!acnt.Desc.IsEmpty())
                        descr = acnt.Desc.GetValue();
                }
                account a = account.GetByFullName(x, fullname);
                if (a == null)
                {
                    a = new account();
                    a.name = name;
                    a.full_name = fullname;
                    a.number = CheckAccountNumber(x, numb);
                    a.Type = type;
                    a.Category = account.InferCategory(a.Type);
                    a.description = descr;
                    string parent_name = GetParentAccountName(fullname, name);
                    if (Tools.Strings.StrExt(parent_name))
                    {
                        account aa = account.GetByFullName(x, parent_name);
                        if (aa != null)
                            a.SetParent(aa);
                    }
                    a.Insert(x);
                }
                if (acnt.IsActive != null)
                {
                    if (!acnt.IsActive.IsEmpty())
                    {
                        if (!acnt.IsActive.GetValue())
                            a.is_hidden = true;
                    }
                }
                a.balance = bal;
                a.Update(x);
                x.TheLeader.Comment("Imported: " + a.ToString());
                CreateBeginningJournalEntry(x, a);
            }
        }
        public virtual void ImportUnPaidBillsQuickBooks(ContextRz x)
        {
            x.TheLeader.Comment("Importing UnPaid Bills");
            if (x == null)
                return;
            IMsgSetRequest requestSet = x.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(x, x.TheSysRz.TheQuickBooksLogic.sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IBillQuery bq = requestSet.AppendBillQueryRq();
            bq.IncludeLineItems.SetValue(true);
            if (!x.TheSysRz.TheQuickBooksLogic.Connect(x))
                return;
            IMsgSetResponse responseSet = x.TheSysRz.TheQuickBooksLogic.sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            x.TheSysRz.TheQuickBooksLogic.Disconnect();
            IBillRetList BillList = (IBillRetList)response.Detail;
            for (int i = 0; i < BillList.Count; i++)
            {
                IBillRet bill = BillList.GetAt(i);
                if (bill.IsPaid != null)
                {
                    if (bill.IsPaid.GetValue())
                        continue;
                }
                string vend = "";
                if (bill.VendorRef != null)
                {
                    if (!bill.VendorRef.FullName.IsEmpty())
                        vend = bill.VendorRef.FullName.GetValue();
                }
                string notes = "";
                if (bill.Memo != null)
                {
                    if (!bill.Memo.IsEmpty())
                        notes = bill.Memo.GetValue();
                }
                DateTime orderdate = Tools.Dates.GetBlankDate();
                if (bill.TxnDate != null)
                {
                    if (!bill.TxnDate.IsEmpty())
                        orderdate = bill.TxnDate.GetValue();
                }
                string reference = "";
                if (bill.RefNumber != null)
                {
                    if (!bill.RefNumber.IsEmpty())
                        reference = bill.RefNumber.GetValue();
                }
                ordhed_purchase p = new ordhed_purchase();
                p.is_bill = true;
                p.internalcomment = notes;
                p.orderdate = orderdate;
                p.orderreference = reference;
                p.lead_source = "Import From QBs";
                p.Insert(x);
                company v = GetVendorCompany(x, vend);
                p.CompanyVar.RefSet(x, v);
                if (bill.ExpenseLineRetList != null)
                {
                    for (Int32 ii = 0; ii <= bill.ExpenseLineRetList.Count - 1; ii++)
                    {
                        IExpenseLineRet e = (IExpenseLineRet)bill.ExpenseLineRetList.GetAt(ii);
                        if (e == null)
                            continue;
                        string item = e.AccountRef.FullName.GetValue();
                        double amnt = 0;
                        if (e.Amount != null)
                            amnt = e.Amount.GetValue();                      
                        orddet_line l = (orddet_line)p.GetNewDetail(x);
                        l.LineType = LineType.Service;
                        l.fullpartnumber = item;
                        l.quantity = 1;
                        l.unit_cost = amnt;
                        l.Status = Enums.OrderLineStatus.Received;
                        l.was_received = true;
                        account a = account.GetByFullName(x, item);
                        if (a == null)
                            a = account.GetByFullName(x, "Services");
                        if (a == null)
                            throw new Exception("Account for item '" + item + "' could not be located.");
                        l.purchase_expense_account_name = a.name;
                        l.purchase_expense_account_uid = a.unique_id;
                        l.Update(x);
                    }
                }
                if (bill.ORItemLineRetList != null)
                {
                    for (Int32 ii = 0; ii <= bill.ORItemLineRetList.Count - 1; ii++)
                    {
                        IORItemLineRet y = (IORItemLineRet)bill.ORItemLineRetList.GetAt(ii);
                        if (y == null)
                            continue;
                        string item = y.ItemLineRet.ItemRef.FullName.GetValue();
                        if (x.TheSysRz.TheQuickBooksLogic.InvPartExists(x, item, false))
                        {
                            //Item is an inv-item so therefore already on a PO in Rz
                            continue;
                        }
                        double qty = 0;
                        if (y.ItemLineRet.Quantity != null)
                            qty = y.ItemLineRet.Quantity.GetValue();
                        double cost = 0;
                        if (y.ItemLineRet != null)
                            cost = y.ItemLineRet.Cost.GetValue();                       
                        orddet_line l = (orddet_line)p.GetNewDetail(x);
                        l.LineType = LineType.Service;
                        l.fullpartnumber = item;
                        l.quantity = Convert.ToInt32(qty);
                        l.unit_cost = cost;
                        l.Status = Enums.OrderLineStatus.Received;
                        l.was_received = true;
                        account a = x.TheSysRz.TheQuickBooksLogic.GetItemAccount(x, item, QuickBooksLogic.QBItemAccountCategory.Expense);
                        if (a == null)
                            a = account.GetByFullName(x, "Supplies");
                        if (a == null)
                            throw new Exception("Account for item '" + item + "' could not be located.");
                        l.purchase_expense_account_name = a.name;
                        l.purchase_expense_account_uid = a.unique_id;
                        l.Update(x);
                    }
                }
                if (p.Details.RefsCount(x) <= 0)
                {
                    p.Delete(x);
                    continue;
                }
                p.Update(x);
                p.CloseAndPayNoTrans(x);
                x.TheLeader.Comment("Imported Bill: " + p.ToString());
            }
        }
        //Private Functions
        private void CreateBeginningJournalEntry(ContextRz x, account a)
        {
            if (x == null)
                return;
            if (a == null)
                return;
            if (a.balance == 0)
                return;
            double debit = 0;
            double credit = 0;
            switch (a.Category)
            {
                case AccountCategory.Asset://Asset accounts - debit
                case AccountCategory.Expense://Expense accounts - debit
                    if (a.balance < 0)
                        credit = a.balance * -1;
                    else
                        debit = a.balance;
                    break;
                case AccountCategory.Equity://Owner's equity - credit
                case AccountCategory.Income://Revenue/Income accounts - credit
                case AccountCategory.Liability://Liability accounts - credit
                    if (a.balance < 0)
                        debit = a.balance * -1;
                    else
                        credit = a.balance;
                    break;
                default:
                    throw new Exception("Beginning Journal Entry cannot be created on an 'Other' category account.");
            }
            journal j = journal.CreateNoInsert(x, a, debit, credit);
            j.balance = a.balance;
            j.description = "Starting Balance From QBs";
            j.Insert(x);
            //Create a deposit for this account for starting balance
            deposit d = new deposit();
            d.account_name = a.full_name;
            d.account_uid = a.unique_id;
            d.balance = a.balance;
            d.description = "Starting Balance From QBs";
            d.total_amount = a.balance;
            d.Insert(x);
        }
        private AccountType GetRzAccountType(ENAccountType t)
        {
            switch (t)
            {
                case ENAccountType.atAccountsPayable:
                    return AccountType.AccountsPayable;
                case ENAccountType.atAccountsReceivable:
                    return AccountType.AccountsReceivable;
                case ENAccountType.atBank:
                    return AccountType.Bank;
                case ENAccountType.atCostOfGoodsSold:
                    return AccountType.CostOfGoodsSold;
                case ENAccountType.atCreditCard:
                    return AccountType.CreditCard;
                case ENAccountType.atEquity:
                    return AccountType.Equity;
                case ENAccountType.atExpense:
                    return AccountType.Expense;
                case ENAccountType.atFixedAsset:
                    return AccountType.FixedAssets;
                case ENAccountType.atIncome:
                    return AccountType.Income;
                case ENAccountType.atLongTermLiability:
                    return AccountType.LongTermLiabilities;
                case ENAccountType.atOtherAsset:
                    return AccountType.OtherAssets;
                case ENAccountType.atOtherCurrentAsset:
                    return AccountType.OtherCurrentAssets;
                case ENAccountType.atOtherCurrentLiability:
                    return AccountType.OtherCurrentLiabilities;
                case ENAccountType.atOtherExpense:
                    return AccountType.OtherExpense;
                case ENAccountType.atOtherIncome:
                    return AccountType.OtherIncome;
                //case ENAccountType.atNonPosting:
                //    return AccountType.Null;
                default:                   
                    return AccountType.Null;
            }
        }
        private String GetParentAccountName(String fullname, String name)
        {
            if (!fullname.Contains(":"))
                return "";
            string[] str = Tools.Strings.Split(fullname, ":");
            string h = "";
            for (int i = 0; i <= str.Length - 2; i++)
            {
                if (Tools.Strings.StrExt(h))
                    h += ":";
                h += str[i];
            }
            return h;
        }
        private company GetVendorCompany(ContextRz x, string vend)
        {
            company c = (company)x.QtO("company", "select * from company where qb_name_v = '" + x.Filter(vend) + "'");
            if (c == null)
                c = company.GetByDistilledName(x, company.DistillCompanyName(vend));
            if (c == null)
            {
                c = new company();                
                c.companyname = vend;
                c.qb_name_v = vend;
                c.Insert(x);
            }
            return c;
        }
        private int CheckAccountNumber(ContextRz x, int numb)
        {
            if (numb == 0)
                return 0;
            string s = x.SelectScalarString("select unique_id from account where number = " + numb.ToString());
            if (!Tools.Strings.StrExt(s))
                return numb;
            numb += 1;
            return CheckAccountNumber(x, numb);
        }
    }
}
