using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Tools;
using Core;
using NewMethod;
using Enums = Rz5.Enums;
using shippingaccount = Rz5.shippingaccount;
using ordhed = Rz5.ordhed;
using companyaddress = Rz5.companyaddress;
using companycontact = Rz5.companycontact;
using usernote = Rz5.usernote;
using orddet = Rz5.orddet;

namespace Rz5
{
    public partial class ViewBill : ViewPlusMenu
    {
        //Public Variables
        public ordhed_purchase TheBill
        {
            get
            {
                return (ordhed_purchase)GetCurrentObject();
            }
            set
            {
                SetCurrentObject(value);
            }
        }
        //Private Variables
        private Bitmap OriginalHeader = null;
        private bool rendered = false;
        private orddet_line currentDetail = null;

        //Constructors
        public ViewBill()
        {
            InitializeComponent();
            Rz5.PartPictureViewer.PictureAdded += new Rz5.PictureAddedHandler(PartPictureViewer_PictureAdded);
            Rz5.PartPictureViewer.PictureRemoved += new Rz5.PictureRemovedHandler(PartPictureViewer_PictureRemoved);
            picHeader.BackColor = Color.White;
        }
        //Public Override Functions
        public override void Init(Item item)
        {
            base.Init(item);
            LoadAccountCombo();
            LoadCreditCardCombo();
        }
        public override void CompleteLoad()
        {
            IsLoading = true;
            try
            {
                if (!rendered)
                {
                    RenderHeaderBar();
                    rendered = true;
                }
            }
            catch { }
            picComplete.BringToFront();
            cStub.CurrentObject = TheBill;
            cStub.CompanyIDField = "base_company_uid";
            cStub.CompanyNameField = "companyname";
            cStub.ContactIDField = "base_companycontact_uid";
            cStub.ContactNameField = "contactname";
            cStub.SetCompany();
            details.CurrentVar = TheBill.Details;
            details.Init(TheBill.DetailArgsGet(RzWin.Context));
            if (TheBill.is_credit)
                optCredit.Checked = true;
            else
                optBill.Checked = true;
            base.CompleteLoad();
            IsLoading = false;
            CheckAttachmentTab();
            if (xActions.IsDisabled())
            {
                xActions.Enabled = true;
                xActions.DisableExcept("|Print|Print PDF|Fax|Email|Make RMA|Links|Deal|View Order Batch|");
            }
            else
            {
                xActions.EnableDelete = TheBill.CanBeDeletedBy(RzWin.Context);
            }
            CompleteLoad_Dates();
            lblSaveThisOrder.BringToFront();
            lblSaveThisOrder.Visible = true;
            if (TheBill.is_credit_card)
            {
                creditcardAccount.Visible = true;
                optBill.Visible = false;
                optCredit.Visible = false;
                pCCOptions.Visible = true;
                if (Tools.Strings.StrExt(TheBill.cc_account_uid))
                {
                    account cc = account.GetById(RzWin.Context, TheBill.cc_account_uid);
                    if (cc != null)
                        creditcardAccount.SetValue(cc.full_name);
                }
            }
            else
            {
                creditcardAccount.Visible = false;
                optBill.Visible = true;
                optCredit.Visible = true;
            }
            postButton.Visible = ShowPostButton();
        }
        public override void CompleteSave()
        {
            if (optCredit.Checked)
                TheBill.is_credit = true;
            else
                TheBill.is_credit = false;
            if (TheBill.is_credit_card)
            {
                string name = creditcardAccount.GetValue_String();
                if (Tools.Strings.StrExt(name))
                {
                    account cc = account.GetByFullName(RzWin.Context, account.GetAccountFullNameStripBullet(name));
                    if (cc != null)
                    {
                        TheBill.cc_account_full_name = cc.full_name;
                        TheBill.cc_account_name = cc.name;
                        TheBill.cc_account_number = cc.number;
                        TheBill.cc_account_uid = cc.unique_id;
                    }
                }
            }
            base.CompleteSave();
            TheBill.Update(RzWin.Context);
        }
        //Protected Override Functions
        protected override void InitUn()
        {
            base.InitUn();
            try
            {
                OriginalHeader.Dispose();
                OriginalHeader = null;
            }
            catch { }
        }
        protected override void DoResize()
        {
            try
            {
                base.DoResize();

                tsDetails.Left = ts.Left;
                tsDetails.Top = ts.Bottom + 3;

                tsDetails.Width = AreaAvailable.Width - tsDetails.Left;

                if (currentDetail == null)
                {
                    tsDetails.Height = (this.ClientRectangle.Height - tsDetails.Top) - 5;
                }
                else
                {
                    tsDetails.Height = (this.ClientRectangle.Height - tsDetails.Top) - (pDetail.Height + 5);
                    pDetail.Left = 0;
                    pDetail.Width = tsDetails.Width;
                    pDetail.Top = tsDetails.Bottom;
                }

                details.Left = 0;
                details.Width = tabLines.ClientRectangle.Width;
                details.Top = 0;
                details.Height = tabLines.ClientRectangle.Height;

                lblSaveThisOrder.Left = details.Left + (details.Width / 2) - (lblSaveThisOrder.Width / 2);
                lblSaveThisOrder.Top = details.Top + details.BottomBarTop;
            }
            catch (Exception)
            {
            }
        }
        //Protected Virtual Functions
        protected virtual void CompleteLoad_Dates()
        {
            nlblorderdate.SetValue(nTools.DateFormat(TheBill.orderdate));
            nlblordertime.SetValue(nTools.TimeFormat(TheBill.orderdate));
        }
        protected virtual void ChangeCompany(GenericEvent e)
        {
            e.Handled = true;
            String strID = "";
            String strName = "";
            Rz5.frmChooseCompany_Big.ChooseCompanyID(ref strID, ref strName, Enums.CompanySelectionType.Both, "Company");
            if (strID != TheBill.base_company_uid)
            {
                TheBill.contactname = "";
                company c = company.GetById(RzWin.Context, strID);
                if (c == null)
                    return;
                if (!TheBill.CanAssignCompany(RzWin.Context, c))
                    return;
                CompleteSave();
                TheBill.AbsorbCompany(RzWin.Context, c);
                TheBill.Update(RzWin.Context);
                CompleteLoad();

                cStub.SetCompany(c.companyname, c.unique_id);

                ArrayList xs = c.VendorContactsGet(RzWin.Context);
                if (xs.Count == 1)
                {
                    companycontact cc = (companycontact)xs[0];
                    cStub.SetCompany(c.companyname, c.unique_id, cc.contactname, cc.unique_id);
                    cStub.ContactDisable();
                    TheBill.AbsorbContact(RzWin.Context, cc);
                    CompleteLoad();
                }
                else
                    cStub.ContactEnable();
            }
        }
        protected virtual void ChangeContact(GenericEvent e)
        {
            e.Handled = true;
            if (!Tools.Strings.StrExt(TheBill.base_company_uid))
                return;
            ArrayList xs = null;
            companycontact c = null;
            if (TheBill.OrderType == Enums.OrderType.Purchase)
            {
                company comp = (company)TheBill.CompanyVar.RefGet(RzWin.Context);
                if (comp != null)
                    xs = comp.VendorContactsGet(RzWin.Context);
            }
            String strID = "";
            String strName = "";
            bool choose = false;
            if (xs == null)
                choose = true;
            else
            {
                if (xs.Count == 0)
                    choose = true;
            }
            if (choose)
            {
                Rz5.frmChooseContact_Big.ChooseContactID(ref strID, ref strName, TheBill.base_company_uid, "Contact", this.ParentForm);
                if (Tools.Strings.StrExt(strID))
                    c = companycontact.GetById(RzWin.Context, strID);
            }
            else
            {
                companycontact xc = Rz5.frmChooseContact_Big.Choose(xs, "Choose A Vendor Contact");
                if (xc == null)
                    return;
                c = xc;
            }
            if (c == null)
                return;
            //check everything
            if (!TheBill.CanAssignContact(RzWin.Context, c))
            {
                RzWin.Leader.Tell(c.ToString() + " cannot be assigned to this " + Rz5.RzLogic.GetFriendlyOrderType(TheBill.OrderType));
                return;
            }
            CompleteSave();
            cStub.SetCompany(TheBill.companyname, TheBill.base_company_uid, c.contactname, c.unique_id);
            TheBill.AbsorbContact(RzWin.Context, c);
            CompleteLoad();
        }
        protected virtual void DetailAdd()
        {
            CompleteSave();
            orddet_line l = (orddet_line)TheBill.GetNewDetail(RzWin.Context);
            OpenDetail(l);
        }
        //Protected Functions
        protected void HeaderSet(String name)
        {
            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file =
                thisExe.GetManifestResourceStream("Rz4." + name);
            picHeader.Image = Image.FromStream(file);
        }
        //Private Functions
        private void RenderHeaderBar()
        {
            if (OriginalHeader == null)
                OriginalHeader = new Bitmap(picHeader.BackgroundImage);

            //CurrentHeader = new Bitmap(OriginalHeader, new Size(OriginalHeader.Width, OriginalHeader.Height));

            Graphics g = Graphics.FromImage(OriginalHeader);
            g.DrawString(TheBill.FriendlyOrderType + " " + TheBill.ordernumber, new Font("Calibri", 20.0F, FontStyle.Bold), Brushes.White, new Point(8, 8));
            g.Dispose();
            g = null;

            picHeader.BackgroundImage = OriginalHeader;
        }
        private void WriteStatus(String status)
        {
            try
            {
                Bitmap m = null;

                switch (status.ToLower().Trim())
                {
                    case "complete":
                        m = new Bitmap(picComplete.BackgroundImage);
                        break;
                    case "hold":
                        m = new Bitmap(picHold.BackgroundImage);
                        break;
                    case "open":
                        m = new Bitmap(picOpen.BackgroundImage);
                        break;
                    case "void":
                        m = new Bitmap(picVoid.BackgroundImage);
                        break;
                    default:
                        return;
                }
                
                
                Bitmap use = new Bitmap(OriginalHeader);
                Graphics g = Graphics.FromImage(use);
                g.DrawImage(m, new Point(use.Width - (m.Width + 8), 3));
                g.Dispose();
                g = null;
                picHeader.BackgroundImage = use;
            }
            catch { }
        }
        private void CompleteDispose()
        {
            try
            {
                //custom
                Rz5.PartPictureViewer.PictureAdded -= new Rz5.PictureAddedHandler(PartPictureViewer_PictureAdded);
                Rz5.PartPictureViewer.PictureRemoved -= new Rz5.PictureRemovedHandler(PartPictureViewer_PictureRemoved);
                //auto
                this.cStub.ChangeCompany -= new Rz5.ContactEventHandler(this.cStub_ChangeCompany);
                this.cStub.ChangeContact -= new Rz5.ContactEventHandler(this.cStub_ChangeContact);
                this.details.AboutToAdd -= new NewMethod.AddHandler(this.details_AboutToAdd);
            }
            catch
            {
            }
        }
        private void CheckAttachmentTab()
        {
            try
            {
                //Int64 i = RzWin.Context.SelectScalarInt64("select count(*) from partpicture where the_orddet_uid in (select unique_id from " + ordhed.MakeOrddetName(CurrentOrder.OrderType) + " where base_ordhed_uid = '" + CurrentOrder.unique_id + "')");
                Int64 i = TheBill.PictureCount(RzWin.Context);
                tabAttachments.Text = "Attachments(" + i.ToString() + ")";
            }
            catch
            {
            }
        }
        private void LoadAccountCombo()
        {
            expenseAccount.ClearList();
            if (TheBill.is_credit)
            {
                expenseAccount.Add("Accounts Payable");
                return;
            }
            AccountCriteria ac = new AccountCriteria();
            ac.Types.Add(AccountType.Expense);
            ac.Types.Add(AccountType.OtherExpense);
            ac.Types.Add(AccountType.FixedAssets);
            if (TheBill.is_credit_card)
            {
                ac = new AccountCriteria();
                if (optInv.Checked)
                {
                    ac.Types.Add(AccountType.FixedAssets);
                    ac.Types.Add(AccountType.OtherAssets);
                    ac.Types.Add(AccountType.OtherCurrentAssets);
                }
                else if (optService.Checked)
                {
                    ac.Types.Add(AccountType.Expense);
                    ac.Types.Add(AccountType.OtherExpense);
                }
            }
            expenseAccount.Add("");
            foreach(account a in RzWin.Accounts.GetAccounts(RzWin.Context, ac))
            {
                if (Tools.Strings.StrCmp("Reconciliation Discrepancies", a.full_name))
                    continue;
                expenseAccount.Add(a.full_name);
            }
        }
        private void LoadCreditCardCombo()
        {
            creditcardAccount.ClearList();
            creditcardAccount.Add("");
            foreach (account a in RzWin.Accounts.GetAccounts(RzWin.Context, new AccountCriteria(AccountType.CreditCard)))
            {
                creditcardAccount.Add(a.full_name);
            }
        }
        private void ShowAttachments()
        {
            picview.DoResize();
            picview.CompleteLoad();
            picview.LoadViewBy(TheBill);
            picview.Caption = "Pictures for " + TheBill.ToString();
        }      
        private void BlockAllChanges()
        {
            try
            {
                details.AllowAdd = false;
                foreach (TabPage tp in ts.TabPages)
                {
                    foreach (Control c in tp.Controls)
                    {
                        c.Enabled = false;
                    }
                }
            }
            catch { }
        }
        private void CloseDetail()
        {
            currentDetail.fullpartnumber = partNumber.GetValue_String();
            currentDetail.quantity = quantity.GetValue_Integer();
            currentDetail.unit_cost = unitCost.GetValue_Double();
            string acnt = expenseAccount.GetValue_String();
            account a = null;
            if (Tools.Strings.StrExt(acnt))
                a = account.GetByFullName(RzWin.Context, acnt);
            if (a != null)
            {
                currentDetail.purchase_expense_account_name = a.full_name;
                currentDetail.purchase_expense_account_uid = a.unique_id;
            }
            if (TheBill.is_credit_card)
                currentDetail.cc_charge_type = GetCCChargeType();
            currentDetail.LineType = LineType.Service;
            currentDetail.Update(RzWin.Context);
            currentDetail = null;
            pDetail.Visible = false;
            DoResize();
            CompleteSaveAndUpdate();
            CompleteLoad();
        }
        private void OpenDetail(orddet_line d)
        {
            if (currentDetail != null)
                CloseDetail();
            currentDetail = d;
            account a = null;
            if (Tools.Strings.StrExt(currentDetail.purchase_expense_account_name))
                a = account.GetByFullName(RzWin.Context, currentDetail.purchase_expense_account_name);
            if (a != null)
            {
                currentDetail.purchase_expense_account_name = a.name;
                currentDetail.purchase_expense_account_uid = a.unique_id;
            }
            partNumber.SetValue(currentDetail.fullpartnumber);
            quantity.SetValue(currentDetail.quantity);
            unitCost.SetValue(currentDetail.unit_cost);
            expenseAccount.SetValue(currentDetail.purchase_expense_account_name);
            if (TheBill.is_credit_card)
                SetCCChargeType(currentDetail.cc_charge_type);
            pDetail.Visible = true;
            DoResize();
        }
        private bool ShowPostButton()
        {
            if (TheBill.is_credit_card)
            {
                if (!Tools.Strings.StrExt(creditcardAccount.GetValue_String()))
                    return false;
            }
            return TheBill.PostBillPossible(RzWin.Context);
        }
        private string GetCCChargeType()
        {
            if (optInv.Checked)
                return "Inventory";
            else if (optService.Checked)
                return "Service";
            else if (optMisc.Checked)
                return "Misc";
            else
                return "";
        }
        private void SetCCChargeType(string type)
        {
            switch (type.ToLower())
            {
                case "inventory":
                    optInv.Checked = true;
                    break;
                case "service":
                    optService.Checked = true;
                    break;
                case "misc":
                    optMisc.Checked = true;
                    break;
            }
        }
        //Buttons
        private void saveDetailButton_Click(object sender, EventArgs e)
        {
            CloseDetail();
        }
        private void postButton_Click(object sender, EventArgs e)
        {
            CompleteSave();
            IsLoading = true;
            if (TheBill.is_credit)
            {
                List<orddet_line> list = TheBill.ListOpenFilledLines(RzWin.Context, CloseType.Receive);
                foreach (orddet_line l in list)
                {
                    l.PutAwayMark(RzWin.Context);
                }
                TheBill.AfterClose(RzWin.Context, list, CloseType.Receive);
            }
            else
                TheBill.PutAway(RzWin.Context);
            IsLoading = false;
            CompleteLoad();
        }
        //Control Events
        private void cStub_ChangeCompany(GenericEvent e)
        {
            ChangeCompany(e);
        }
        private void cStub_ChangeContact(GenericEvent e)
        {
            ChangeContact(e);
        }
        private void details_AboutToAdd(object sender, AddArgs args)
        {
            DetailAdd();
            args.Handled = true;
        }       
        private void lblSaveThisOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("permanently save this line order"))
                return;
            ArrayList ids = details.GetAllIDs();
            int i = 1;
            foreach (String id in ids)
            {
                try
                {
                    orddet_line d = (orddet_line)TheBill.Details.ByIdGet(RzWin.Context, id);
                    if (d != null)
                    {
                        d.LineCodeSet(TheBill.OrderType, i);
                        d.Update(RzWin.Context);
                    }
                }
                catch { }
                i++;
            }
            RzWin.Leader.Tell("Done.");
        }       
        private void tsDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsDetails.SelectedTab == tabAttachments)
                ShowAttachments();
        }
        private void PartPictureViewer_PictureAdded()
        {
            CheckAttachmentTab();
        }
        private void PartPictureViewer_PictureRemoved()
        {
            CheckAttachmentTab();
        }
        private void picHeader_DoubleClick(object sender, EventArgs e)
        {
            CompleteSave();
            TheBill.NumberChange(RzWin.Context);
            RenderHeaderBar();
        }
        private void details_AboutToThrow(Context x, ShowArgs args)
        {
            args.Handled = true;
            OpenDetail((orddet_line)args.TheItems.FirstGet(x));
        }
        private void optCredit_CheckedChanged(object sender, EventArgs e)
        {
            TheBill.is_credit = optCredit.Checked;
            TheBill.Update(RzWin.Context, false);
            LoadAccountCombo();
        }
        private void creditcardAccount_DataChanged(GenericEvent e)
        {
            CompleteSave();
            postButton.Visible = ShowPostButton();            
        }
        private void optInv_CheckedChanged(object sender, EventArgs e)
        {
            LoadAccountCombo();
        }
        private void optService_CheckedChanged(object sender, EventArgs e)
        {
            LoadAccountCombo();
        }
        private void optMisc_CheckedChanged(object sender, EventArgs e)
        {
            LoadAccountCombo();
        }
    }
}