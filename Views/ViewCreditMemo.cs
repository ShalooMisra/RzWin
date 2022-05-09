using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Rz5;
using Core;
using Tools;
using System.Collections;

namespace RzInterfaceWin
{
    public partial class ViewCreditMemo : ViewPlusMenu
    {
        //Public Variables
        public creditmemo_hed TheCreditMemo
        {
            get
            {
                return (creditmemo_hed)GetCurrentObject();
            }
            set
            {
                SetCurrentObject(value);
            }
        }
        //Private Variables
        private Bitmap OriginalHeader = null;
        private bool rendered = false;
        private creditmemo_det currentDetail = null;

        //Constructors
        public ViewCreditMemo()
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
            cStub.CurrentObject = TheCreditMemo;
            cStub.CompanyIDField = "base_company_uid";
            cStub.CompanyNameField = "companyname";
            cStub.ContactIDField = "base_companycontact_uid";
            cStub.ContactNameField = "contactname";
            cStub.SetCompany();
            details.Init(TheCreditMemo.DetailArgsGet(RzWin.Context));
            base.CompleteLoad();
            IsLoading = false;
            CheckAttachmentTab();
            if (xActions.IsDisabled())
            {
                xActions.Enabled = true;
                xActions.DisableExcept("|Print|Print PDF|Fax|Email|Make RMA|Links|Deal|View Order Batch|");
            }
            else
                xActions.EnableDelete = TheCreditMemo.CanBeDeletedBy(RzWin.Context);
            CompleteLoad_Dates();
            lblSaveThisOrder.BringToFront();
            lblSaveThisOrder.Visible = true;
            postButton.Visible = ShowPostButton();
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
        //Protected Functions
        protected void CompleteLoad_Dates()
        {
            nlblorderdate.SetValue(nTools.DateFormat(TheCreditMemo.orderdate));
            nlblordertime.SetValue(nTools.TimeFormat(TheCreditMemo.orderdate));
        }
        //Private Functions
        private void CompleteDispose()
        {
            try
            {
                ////custom
                //Rz5.PartPictureViewer.PictureAdded -= new Rz5.PictureAddedHandler(PartPictureViewer_PictureAdded);
                //Rz5.PartPictureViewer.PictureRemoved -= new Rz5.PictureRemovedHandler(PartPictureViewer_PictureRemoved);
                ////auto
                //this.cStub.ChangeCompany -= new Rz5.ContactEventHandler(this.cStub_ChangeCompany);
                //this.cStub.ChangeContact -= new Rz5.ContactEventHandler(this.cStub_ChangeContact);
                //this.details.AboutToAdd -= new NewMethod.AddHandler(this.details_AboutToAdd);
            }
            catch
            {
            }
        }
        private void LoadAccountCombo()
        {
            expenseAccount.ClearList();
            AccountCriteria ac = new AccountCriteria();
            ac.Types.Add(AccountType.Expense);
            ac.Types.Add(AccountType.OtherExpense);
            ac.Types.Add(AccountType.FixedAssets);
            expenseAccount.Add("");
            foreach (account a in RzWin.Accounts.GetAccounts(RzWin.Context, ac))
            {
                expenseAccount.Add(a.full_name);
            }
        }
        private void RenderHeaderBar()
        {
            if (OriginalHeader == null)
                OriginalHeader = new Bitmap(picHeader.BackgroundImage);
            Graphics g = Graphics.FromImage(OriginalHeader);
            g.DrawString("Credit Memo " + TheCreditMemo.ordernumber, new Font("Calibri", 20.0F, FontStyle.Bold), Brushes.White, new Point(8, 8));
            g.Dispose();
            g = null;
            picHeader.BackgroundImage = OriginalHeader;
        }
        private void CheckAttachmentTab()
        {
            try
            {
                Int64 i = TheCreditMemo.PictureCount(RzWin.Context);
                tabAttachments.Text = "Attachments(" + i.ToString() + ")";
            }
            catch
            {
            }
        }
        private void ChangeCompany(GenericEvent e)
        {
            e.Handled = true;
            String strID = "";
            String strName = "";
            Rz5.frmChooseCompany_Big.ChooseCompanyID(ref strID, ref strName, Rz5.Enums.CompanySelectionType.Both, "Company");
            if (strID != TheCreditMemo.base_company_uid)
            {
                TheCreditMemo.contactname = "";
                company c = company.GetById(RzWin.Context, strID);
                if (c == null)
                    return;
                if (!TheCreditMemo.CanAssignCompany(RzWin.Context, c))
                    return;
                CompleteSave();
                TheCreditMemo.AbsorbCompany(RzWin.Context, c);
                TheCreditMemo.Update(RzWin.Context);
                CompleteLoad();
                cStub.SetCompany(c.companyname, c.unique_id);
                ArrayList xs = c.VendorContactsGet(RzWin.Context);
                if (xs.Count == 1)
                {
                    companycontact cc = (companycontact)xs[0];
                    cStub.SetCompany(c.companyname, c.unique_id, cc.contactname, cc.unique_id);
                    cStub.ContactDisable();
                    TheCreditMemo.AbsorbContact(RzWin.Context, cc);
                    CompleteLoad();
                }
                else
                    cStub.ContactEnable();
            }
        }
        private void ChangeContact(GenericEvent e)
        {
            e.Handled = true;
            if (!Tools.Strings.StrExt(TheCreditMemo.base_company_uid))
                return;
            companycontact c = null;
            String strID = "";
            String strName = "";
            Rz5.frmChooseContact_Big.ChooseContactID(ref strID, ref strName, TheCreditMemo.base_company_uid, "Contact", this.ParentForm);
            if (Tools.Strings.StrExt(strID))
                c = companycontact.GetById(RzWin.Context, strID);
            if (c == null)
                return;
            if (!TheCreditMemo.CanAssignContact(RzWin.Context, c))
            {
                RzWin.Leader.Tell(c.ToString() + " cannot be assigned to this Credit Memo");
                return;
            }
            CompleteSave();
            cStub.SetCompany(TheCreditMemo.companyname, TheCreditMemo.base_company_uid, c.contactname, c.unique_id);
            TheCreditMemo.AbsorbContact(RzWin.Context, c);
            CompleteLoad();
        }
        private void DetailAdd()
        {
            CompleteSave();
            creditmemo_det d = (creditmemo_det)TheCreditMemo.GetNewDetail(RzWin.Context);
            OpenDetail(d);
        }
        private void OpenDetail(creditmemo_det d)
        {
            if (currentDetail != null)
                CloseDetail();
            currentDetail = d;
            account a = null;
            if (Tools.Strings.StrExt(currentDetail.account_full_name))
                a = account.GetByFullName(RzWin.Context, currentDetail.account_full_name);
            if (a != null)
            {
                currentDetail.account_full_name = a.full_name;
                currentDetail.account_name = a.name;
                currentDetail.account_number = a.number;
                currentDetail.account_uid = a.unique_id;
            }
            partNumber.SetValue(currentDetail.fullpartnumber);
            quantity.SetValue(currentDetail.quantity);
            unitPrice.SetValue(currentDetail.unit_price);
            expenseAccount.SetValue(currentDetail.account_full_name);
            pDetail.Visible = true;
            DoResize();
        }
        private void CloseDetail()
        {
            currentDetail.fullpartnumber = partNumber.GetValue_String();
            currentDetail.quantity = quantity.GetValue_Integer();
            currentDetail.unit_price = unitPrice.GetValue_Double();
            string acnt = expenseAccount.GetValue_String();
            account a = null;
            if (Tools.Strings.StrExt(acnt))
                a = account.GetByFullName(RzWin.Context, acnt);
            if (a != null)
            {
                currentDetail.account_full_name = a.full_name;
                currentDetail.account_uid = a.unique_id;
            }            
            currentDetail.Update(RzWin.Context);
            currentDetail = null;
            pDetail.Visible = false;
            DoResize();
            CompleteSaveAndUpdate();
            CompleteLoad();
        }
        private void ShowAttachments()
        {
            picview.DoResize();
            picview.CompleteLoad();
            picview.LoadViewBy(TheCreditMemo);
            picview.Caption = "Pictures for Credit Memo" + TheCreditMemo.ordernumber;
        }
        private bool ShowPostButton()
        {
            return TheCreditMemo.PostCreditMemoPossible(RzWin.Context);
        }
        private void ChangeDate()
        {
            if (!RzWin.Context.xUser.SuperUser)
                return;
            TheCreditMemo.DateChange(RzWin.Context);
            CompleteLoad_Dates();
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
            TheCreditMemo.Post(RzWin.Context);
            IsLoading = false;
            CompleteLoad();
        }
        //Control Events
        private void ViewCreditMemo_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void cStub_ChangeCompany(Tools.GenericEvent e)
        {
            ChangeCompany(e);
        }
        private void cStub_ChangeContact(Tools.GenericEvent e)
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
                    creditmemo_det d = (creditmemo_det)TheCreditMemo.DetailsByIdGet(RzWin.Context, id);
                    if (d != null)
                    {
                        d.linecode = i;
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
            TheCreditMemo.NumberChange(RzWin.Context);
            RenderHeaderBar();
        }
        private void details_AboutToThrow(Context x, ShowArgs args)
        {
            args.Handled = true;
            OpenDetail((creditmemo_det)args.TheItems.FirstGet(x));
        }
        private void lblChangeDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDate();
        }
    }
}
