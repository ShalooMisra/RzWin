using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;
using Core.Display;
using NewMethod;
using System.Collections.Generic;

namespace Rz5
{
    public partial class view_partrecord : ViewPlusMenu
    {
        public partrecord CurrentPart;
        public consignment_code CurrentConsingmentCode;

        //KT Hold Current Product Type
        public partrecord_ssd TheSSD;
        public string TheProductType;
        private string TheProductTypeTable;

        private bool ConfirmationsLoaded = false;
        bool bLoading = false;
        protected view_qualitycontrol InspectionView = null;
        public view_partrecord()
        {
            InitializeComponent();
        }

        public override void Init(Item item)
        {
            base.Init(item);
            //KT Refactored from RzSensible
            Control[] controls = this.tpExtra.Controls.Find("ctl_Country", true);
            if (controls.Length > 0)
            {
                this.tpExtra.Controls.Remove(controls[0]);
                this.tpGeneral.Controls.Add(controls[0]);
                controls[0].Location = new Point() { X = 10, Y = 461 };
                controls[0].Text = "Country of Origin";
                controls[0].Show();
            }
            ctl_alternatepart.SendToBack();
            ctl_rohs_info2.LoadList(true);
            ctl_rohs_info.Name = "junkname";
            ctl_rohs_info.Visible = false;
            ctl_rohs_info2.Name = "ctl_rohs_info";
            //ts.TabPages.Remove(tabImport);



            //END - KT Refactored from RzSensible
            if (InspectionView == null)
            {
                InspectionView = (view_qualitycontrol)RzWin.Context.TheLeader.ViewCreate(RzWin.Context, new ShowArgs("qualitycontrol"));
                tabInspection.Controls.Add(InspectionView);
                InspectionView.Dock = DockStyle.Fill;
            }
            ctl_rohs_info.LoadList("rohs_info");
        }

        protected override void InitUn()
        {
            InitUnInspectionView();
            base.InitUn();
        }

        void InitUnInspectionView()
        {
            if (InspectionView != null)
            {
                try
                {
                    tabInspection.Controls.Remove(InspectionView);
                    InspectionView.Dispose();
                    InspectionView = null;
                }
                catch { }
            }
        }

        //Public Virtual Functions
        public virtual void AddStockConfirmation()
        {
            throw new NotImplementedException("AddStockConfirmation");
        }
        public virtual void PrintConfirmationLabel()
        {
        }
        //Public Override Functions
        public override void CompleteLoad()
        {
            bLoading = true;
            base.CompleteLoad();
            CurrentPart = (partrecord)GetCurrentObject();
            //cStub
            cStub.CurrentObject = CurrentPart;
            cStub.CompanyIDField = "base_company_uid";
            cStub.CompanyNameField = "companyname";
            cStub.ContactIDField = "base_companycontact_uid";
            cStub.ContactNameField = "companycontactname";
            cStub.CurrentSelectionType = Enums.CompanySelectionType.Vendor;
            cStub.CurrentSelectionCaption = "Vendor Selection...";
            cStub.CurrentContactSelectionCaption = "Vendor Contact Selection...";
            cStub.Visible = true;
            cStub.SetCompany();
            buyer.CurrentObject = CurrentPart;
            buyer.CurrentIDField = "buyerid";
            buyer.CurrentNameField = "buyername";
            buyer.SetUserName();
            ctl_stocktype.Text = nTools.NiceFormat(CurrentPart.stocktype);
            ctl_do_not_export.Enabled = RzWin.User.SuperUser;
            bLoading = false;
            cmdSaveAndNew.Visible = (CurrentPart.StockType == Enums.StockType.Excess);
            DoCofCCount();
            ShowCofCs();
            //ShowMasterTabPage();
            if (!RzWin.Context.CheckPermit("Inventory:Edit:Can Edit Part Quantity"))
                ctl_quantity.Enabled = false;
            if (xActions.IsDisabled())
            {
                xActions.Enabled = true;
                xActions.DisableExcept("");
            }

            gbImport.Enabled = (RzWin.Context.xUserRz.HasPermit(Permissions.ThePermits.EditInventoryLineItems));

            //KT Refactored from RzSensible
            buyer.Caption = "Agent Name";
            if (CurrentPart.StockType == Rz5.Enums.StockType.Consign)
                LoadConsignmentInfo();
            else
                gbConsign.Enabled = false;

            //END - KT Refactored from RzSensible


            RzWin.Sys.ThePartLogic.LoadManufacturerDropDown(RzWin.Context, ctl_manufacturer);
            ctl_manufacturer.SetValue(CurrentPart.manufacturer);
            //KT ProductType Stuff
            GetProductType();
            ShowProductyTypeDetails();
            LoadSMV();
        }


        private void LoadSMV()
        {

            ctl_smv.SetValue(CurrentPart.suggested_market_value);
            if (CurrentPart.suggested_market_value_date == Convert.ToDateTime("1/1/1900 12:00:00 AM"))
                lblSMVDate.Text = "";
            else
                lblSMVDate.Text = CurrentPart.suggested_market_value_date.ToString("MM/dd/yyyy");
        }

        //KT - Refactored from Rz5




        public override void CompleteSave()
        {
            base.CompleteSave();
            if (!Tools.Strings.StrExt(ctl_fullpartnumber.GetValue_String()))
            {
                if (!RzWin.Leader.AreYouSure("save this item with a blank part number"))
                    ctl_fullpartnumber.SetValue(CurrentPart.fullpartnumber);
            }
            if (ts.SelectedTab == tabInspection)
            {
                InspectionView.CompleteSave();
            }
            //KT Check Product Type DDL, if present, save ProductType info
            if (ctl_ProductType.GetValue() != null)
                SaveProductType();
            SaveConsignment();
            SaveSMV();

            
            //Update the prefix and basenumber stripped on save in case these are missing.  They are critical for part searches in Rz and Portal.
            string prefix = "";
            string baseNumber = "";
            PartObject.ParsePartNumber(CurrentPart.fullpartnumber, ref prefix, ref baseNumber);
            prefix = PartObject.StripPart(prefix);
            baseNumber = PartObject.StripPart(baseNumber);
            CurrentPart.prefix = prefix;
            CurrentPart.basenumberstripped = baseNumber;
            //Save MFG if OTHER, and ask user to confirm if adding to list.
            //CurrentPart.manufacturer = RzWin.Context.TheSysRz.ThePartLogic.GetManufacturerMatchString(RzWin.Context,CurrentPart.fullpartnumber.Trim().ToUpper());

            CurrentPart.Update(RzWin.Context);

        }



        private void SaveSMV()
        {
            double smv = Convert.ToDouble(ctl_smv.GetValue());
            if (CurrentPart.suggested_market_value != smv)
            {
                CurrentPart.suggested_market_value = smv;
                CurrentPart.suggested_market_value_date = DateTime.Now;

            }


        }

        protected override void DoResize()
        {
            base.DoResize();

            if (ts != null)
            {
                ts.Width = this.ClientRectangle.Width - (xActions.Width + ts.Left);
                ts.Height = this.ClientRectangle.Height - ts.Top;
            }

            try
            {
                PPV.Top = 0;
                PPV.Left = 0;
                PPV.Width = pagePictures.ClientRectangle.Width;
                PPV.Height = pagePictures.ClientRectangle.Height;
                PPV.DoResize();
                //ctl_internalcomment.Height = this.ClientRectangle.Height - ctl_internalcomment.Top;
            }
            catch (Exception ex)
            { }
        }
        public override void HandleAction(object sender, ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                case "":
                    return;
                    break;
                default:
                    base.HandleAction(sender, args);
                    return;
                    break;
            }
        }
        public override void SetCustomState(String strState)
        {
            if (Tools.Strings.HasString(strState, "disable_quantity"))
                ctl_quantity.Enabled = false;

            if (Tools.Strings.HasString(strState, "disable_price"))
                ctl_price.Enabled = false;

            if (Tools.Strings.HasString(strState, "disable_cost"))
                ctl_cost.Enabled = false;
        }
        public override void FinishedAction(ActArgs args)
        {
            if (Tools.Strings.StrCmp(args.ActionName, "plccenterupdate"))
                CompleteLoad();
        }
        //Public Functions
        public partrecord GetCurrentObject()
        {
            return (partrecord)base.GetCurrentObject();
        }

        //Private Functions
        private void ShowInspection()
        {
            if (InspectionView.CurrentInspection == null)
            {
                InspectionView.SetCurrentObject(CurrentPart.QCObjectGet(RzWin.Context));
                InspectionView.CurrentPart = CurrentPart;
                InspectionView.CompleteLoad();
            }
        }
        private void ShowPartPictures()
        {
            PPV.CompleteLoad(false);
            PPV.LoadViewBy(CurrentPart);
            PPV.Caption = "Attachments for " + CurrentPart.ToString();
        }
        private void ShowCofCs()
        {
            lvCofC.ShowTemplate("filelink_cofc_view", "filelink", RzWin.User.TemplateEditor);
            lvCofC.ShowData("filelink", "linkname = 'Certificate of Conformance' and objectclass = 'partrecord' and objectid = '" + CurrentPart.unique_id + "'", "date_created", 200);
        }
        private void DoCofCCount()
        {
            try
            {
                long l = RzWin.Context.SelectScalarInt64("select count(*) from filelink where linkname = 'Certificate of Conformance' and objectclass = 'partrecord' and objectid = '" + CurrentPart.unique_id + "'");
                if (l <= 0)
                    return;
                String t = "C of Cs (" + l.ToString() + ")";
                tabCofC.Text = t;
            }
            catch { }
        }


        //Buttons
        private void cmdPrintLabel_Click(object sender, EventArgs e)
        {
            PrintConfirmationLabel();
        }
        //private void cmdSaveAndNew_Click(object sender, EventArgs e)
        //{
        //    CompleteSave();
        //    CurrentPart.ISave();
        //    partrecord n = (partrecord)CurrentPart.xSys.MakeObject("partrecord");
        //    n.base_company_uid = CurrentPart.base_company_uid;
        //    n.companyname = CurrentPart.companyname;
        //    n.StockType = CurrentPart.StockType;
        //    n.ISave();
        //    SetCurrentObject(n);
        //    CurrentPart = n;
        //    CompleteLoad();
        //}
        //Control Events


        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabChanged();
        }

        protected virtual void TabChanged()
        {
            if (ts.SelectedTab == pagePictures)
            {
                DoResize();
                ShowPartPictures();
            }
            else if (ts.SelectedTab == tabInspection)
            {
                DoResize();
                ShowInspection();
            }
        }
        private void ctl_country_Load(object sender, EventArgs e)
        {

        }
        private void ctl_stocktype_DoubleClick(object sender, EventArgs e)
        {                               //Phonenix does not use the view_partrecord anymore
            if (!RzWin.User.SuperUser)// || (Rz3App.xLogic.IsPhoenix && Tools.Strings.StrCmp(Rz3App.xUser.name, "Art Trejo")))
                return;

            ArrayList a = new ArrayList();
            a.Add("Stock");
            a.Add("Excess");
            a.Add("Consign");
            a.Add("Buy");

            //String s = frmChooseCh frmChooseMultipleChoices.ChooseFromArray(a, "Type", null);
            String s = RzWin.Leader.AskForString("Enter 'Stock', 'Excess', 'Consign', or 'Buy'", "Stock", "Inventory Type");
            switch (s.Trim().ToLower())
            {
                case "stock":
                    break;
                case "consign":
                    break;
                case "excess":
                    break;
                case "buy":
                    break;
                default:
                    return;
            }

            CurrentPart.stocktype = s;
            ctl_stocktype.Text = CurrentPart.StockType.ToString();
        }
        private void ctl_mfg_certifications_CheckChanged(object sender)
        {
            //if (bLoading)
            //    return;
            //if (Rz3App.xLogic.IsCTG)
            //{
            //    if ((Boolean)ctl_mfg_certifications.GetValue())
            //    {
            //        if (!Tools.Strings.StrExt(ctl_datecode.GetValue_String()) || !Tools.Strings.StrExt(ctl_manufacturer.GetValue_String()))
            //        {
            //            RzWin.Leader.Tell("Please enter a date code and manufacturer for this line before marking them as having certifications.");
            //            ctl_mfg_certifications.SetValue(false);
            //            return;
            //        }
            //    }
            //}
        }
        private void ctl_quantityallocated_Load(object sender, EventArgs e)
        {

        }
        private void lvCofC_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
        }
        private void lvCofC_ObjectClicked(object sender, ObjectClickArgs args)
        {
        }
        private void cmdChangeLocation_Click(object sender, EventArgs e)
        {
            try
            {
                String strLocation = "";
                String strBox = "";
                frmLocation.GetLocationAndBox(CurrentPart, ref strLocation, ref strBox, this.ParentForm);
                if (Tools.Strings.StrExt(strLocation))
                {
                    if (Tools.Strings.StrExt(CurrentPart.location) && !Tools.Strings.StrCmp(strLocation, CurrentPart.location))
                        CurrentPart.location += " : " + strLocation;
                    else
                        CurrentPart.location = strLocation;
                    if (Tools.Strings.StrExt(CurrentPart.boxnum) && !Tools.Strings.StrCmp(strBox, CurrentPart.boxnum))
                        CurrentPart.boxnum += " : " + strBox;
                    else
                        CurrentPart.boxnum = strBox;
                }
                CurrentPart.Update(RzWin.Context);
                CompleteLoad();
            }
            catch { }
        }

        private void lstConfirmations_Load(object sender, EventArgs e)
        {

        }
        //KT Master Part Tab
        protected void ShowMasterTabPage()
        {
            if (CurrentPart.stocktype == "Master")
            {
                ts.TabPages.Remove(tpGeneral);
            }
            else
            {
                ts.TabPages.Remove(tpMaster);
            }
        }

        // KT Prduct Type Stuff
        protected void GetProductType()
        {
            if (Tools.Strings.StrExt(CurrentPart.productType))
            {
                TheProductType = CurrentPart.productType.ToLower();
                LoadProductTypeDetail(TheProductType);
            }
            else
            {
                TheProductType = ctl_ProductType.GetValue_String().ToLower();
            }


        }

        protected void LoadProductTypeDetail(string ProductType)
        {
            switch (TheProductType)
            {
                case "ssd":
                    //TheProductTypeTable = typeof(partrecord_ssd);
                    TheProductTypeTable = "partrecord_ssd";
                    break;
                case "display":
                    TheProductTypeTable = "partrecord_display";
                    break;
            }

            string ProductTypeUID = RzWin.Context.SelectScalarString("select unique_id from " + TheProductTypeTable + " where partrecord_uid ='" + CurrentPart.unique_id + "'");
            if (Tools.Strings.StrExt(ProductTypeUID))
            {
                switch (CurrentPart.productType.ToLower())
                {
                    case "ssd":
                        {

                            TheSSD = (partrecord_ssd)RzWin.Context.GetById("partrecord_ssd", ProductTypeUID);
                            gb_SSD.Text = "SSD Detials:";
                            ctl_ProductType.SetValue(TheProductType);
                            ctl_capacity.SetValue(TheSSD.capacity);
                            ctl_ssd_interface.SetValue(TheSSD.ssd_interface);
                            ctl_formfactor.SetValue(TheSSD.formfactor);
                            ctl_maxtemp.SetValue(TheSSD.maxtemp);
                        }
                        break;
                    default:
                        break;
                }

            }
        }

        //KT Routine to set the product type
        protected void SaveProductType()
        {
            switch (ctl_ProductType.GetValue_String().ToLower())
            {
                case "ssd":
                    //SaveSSDDetail();
                    {
                        TheProductType = "ssd";
                    }

                    break;
                default:
                    break;
            }
            SaveProductTypeDetail(TheProductType);

        }

        protected void SaveSSDDetail()
        {
            //Save Partrecord_ssd
            string partrecord_ssd_uid = RzWin.Context.SelectScalarString("select unique_id from partrecord_ssd where partrecord_uid ='" + CurrentPart.unique_id + "'");
            if (!Tools.Strings.StrExt(partrecord_ssd_uid))
                TheSSD = new partrecord_ssd();
            else
                TheSSD = (partrecord_ssd)RzWin.Context.GetById("partrecord_ssd", partrecord_ssd_uid);

            //Gather Values
            TheSSD.partrecord_uid = CurrentPart.unique_id;
            TheSSD.capacity = ctl_capacity.GetValue_String();
            TheSSD.ssd_interface = ctl_ssd_interface.GetValue_String();
            TheSSD.formfactor = ctl_formfactor.GetValue_String();
            TheSSD.maxtemp = ctl_maxtemp.GetValue_String();

            //Save SSD details
            if (Tools.Strings.StrExt(partrecord_ssd_uid))
                TheSSD.Update(RzWin.Context);
            else
                TheSSD.Insert(RzWin.Context);

            //Save main partrecord ProductType
            CurrentPart.productType = "ssd";
            CurrentPart.Update(RzWin.Context);
        }

        protected void SaveProductTypeDetail(string productType)
        {
            switch (TheProductType.ToLower())
            {
                case "ssd":
                    {
                        //Save Partrecord_ssd
                        string partrecord_ssd_uid = RzWin.Context.SelectScalarString("select unique_id from partrecord_ssd where partrecord_uid ='" + CurrentPart.unique_id + "'");
                        if (!Tools.Strings.StrExt(partrecord_ssd_uid))
                            TheSSD = new partrecord_ssd();
                        else
                            TheSSD = (partrecord_ssd)RzWin.Context.GetById("partrecord_ssd", partrecord_ssd_uid);

                        //Gather Values
                        TheSSD.partrecord_uid = CurrentPart.unique_id;
                        TheSSD.capacity = ctl_capacity.GetValue_String();
                        TheSSD.ssd_interface = ctl_ssd_interface.GetValue_String();
                        TheSSD.formfactor = ctl_formfactor.GetValue_String();
                        TheSSD.maxtemp = ctl_maxtemp.GetValue_String();

                        //Save SSD details
                        if (Tools.Strings.StrExt(partrecord_ssd_uid))
                            TheSSD.Update(RzWin.Context);
                        else
                            TheSSD.Insert(RzWin.Context);

                        //Save main partrecord ProductType
                        CurrentPart.productType = "ssd";
                        CurrentPart.Update(RzWin.Context);
                    }

                    break;
                default:
                    break;
            }



            ////Save Partrecord_ssd
            //string partrecord_ssd_uid = RzWin.Context.SelectScalarString("select unique_id from partrecord_ssd where partrecord_uid ='" + CurrentPart.unique_id + "'");
            //if (!Tools.Strings.StrExt(partrecord_ssd_uid))
            //    TheSSD = new partrecord_ssd();
            //else
            //    TheSSD = (partrecord_ssd)RzWin.Context.GetById("partrecord_ssd", partrecord_ssd_uid);

            ////Gather Values
            //TheSSD.partrecord_uid = CurrentPart.unique_id;
            //TheSSD.capacity = ctl_capacity.GetValue_String();
            //TheSSD.ssd_interface = ctl_ssd_interface.GetValue_String();
            //TheSSD.formfactor = ctl_formfactor.GetValue_String();
            //TheSSD.maxtemp = ctl_maxtemp.GetValue_String();

            ////Save SSD details
            //if (Tools.Strings.StrExt(partrecord_ssd_uid))
            //    TheSSD.Update(RzWin.Context);
            //else
            //    TheSSD.Insert(RzWin.Context);

            ////Save main partrecord ProductType
            //CurrentPart.productType = "ssd";
            //CurrentPart.Update(RzWin.Context);
        }


        protected void ShowProductyTypeDetails()
        {
            TheProductType = ctl_ProductType.GetValue_String().ToLower();
            Control CurrentGB = null;
            switch (TheProductType)
            {
                case "ssd":
                    CurrentGB = gb_SSD;
                    //gb_SSD.Visible = true;
                    break;

            }

            if (CurrentGB != null)
                CurrentGB.Visible = true;

        }



        private void LoadConsignmentInfo()
        {
            try
            {

                lblConsignCode.Text = "NONE";
                lblConsignPerc.Text = "NONE";
                CurrentConsingmentCode = consignment_code.GetByName(RzWin.Context, CurrentPart.consignment_code);
                LoadConsignmentDropDown();
                if (RzWin.Context.CheckPermit(Permissions.ThePermits.CanManageConsignment))
                    gbConsign.Enabled = true;

                lblImportName.Text = CurrentPart.importid;
                if (CurrentPart == null)
                    return;
                if (!Tools.Strings.StrExt(CurrentPart.consignment_code))
                    return;
                if (!Tools.Strings.StrExt(CurrentPart.base_company_uid))
                    return;


                //Rz5.consignment_code code = (Rz5.consignment_code)RzWin.Context.QtO("consignment_code", "select * from consignment_code where code_name = '" + RzWin.Context.Filter(CurrentPart.consignment_code) + "' and vendor_uid = '" + CurrentPart.base_company_uid + "'");
                if (CurrentConsingmentCode != null)
                {
                    lblConsignCode.Text = CurrentConsingmentCode.code_name;
                    lblConsignPerc.Text = CurrentConsingmentCode.payout_percent.ToString() + "%";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private void LoadConsignmentDropDown()
        {
            if (!string.IsNullOrEmpty(CurrentPart.CompanyID))
            {
                if (!string.IsNullOrEmpty(CurrentPart.consignment_code))
                    CurrentConsingmentCode = consignment_code.GetByName(RzWin.Context, CurrentPart.consignment_code);
                ctl_consigncodes.ClearList();
                List<string> CodesList = RzWin.Context.SelectScalarList("select code_name from consignment_code where vendor_uid = '" + CurrentPart.CompanyID + "'");
                ctl_consigncodes.LoadListString(CodesList);
                ctl_consigncodes.SetValue(CurrentConsingmentCode.code_name);
            }
        }

        private void SaveConsignment()
        {
            //throw new NotImplementedException();
            if (RzWin.Context.CheckPermit(Permissions.ThePermits.CanManageConsignment))
            {
                if (CurrentPart == null)
                    return;
                string oldCode = CurrentPart.consignment_code;
                string newCode = ctl_consigncodes.GetValue_String();
                if (oldCode != newCode)
                {
                    if (RzWin.Context.Leader.AreYouSure(" you want to change the consignment code for this part from [" + CurrentPart.consignment_code + "] to [" + ctl_consigncodes.GetValue_String() + "]?"))
                    {
                        CurrentPart.consignment_code = newCode;

                    }
                }
            }

        }


        private void ctl_ProductType_SelectionChanged(Tools.GenericEvent e)
        {
            ShowProductyTypeDetails();
        }

        private void ctl_consigncodes_SelectionChanged(Tools.GenericEvent e)
        {
            SetConsigmentInfo();
        }

        private void SetConsigmentInfo()
        {
            consignment_code newCode = consignment_code.GetById(RzWin.Context, ctl_consigncodes.GetValue_String());
            //importid - no can be multiple, would have to ask user to accociate
            //consignment_code
            //stocktype
            if (CurrentPart != null)
            {
                try
                {
                    CurrentPart.consignment_code = newCode.Name;
                    CurrentPart.Update(RzWin.Context);
                    LoadConsignmentInfo();
                }
                catch (Exception ex)
                {

                }


            }


        }

        private void llChangeImportID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> importIdsForVendor = RzWin.Context.SelectScalarList("select distinct importid from partrecord where base_company_uid = '" + CurrentPart.base_company_uid + "'");
            if (importIdsForVendor == null || importIdsForVendor.Count <= 0)
            {
                RzWin.Leader.Error("No other import IDs found for " + CurrentPart.vendorname);
                return;
            }

            string newImportId = RzWin.Context.Leader.ChooseOneChoice(RzWin.Context, importIdsForVendor, "Choose:");
            if (string.IsNullOrEmpty(newImportId))
            {
                RzWin.Leader.Error("Please choose a valid ImportID.");
                return;
            }

            CurrentPart.importid = newImportId;
            CurrentPart.Update(RzWin.Context);
        }
    }
}
