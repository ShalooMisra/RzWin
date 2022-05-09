using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;


namespace Rz5
{
    public partial class PickReceiveItem : UserControl, IProcessControl 
    {
        SysRz5 xSys
        {
            get
            {
                return RzWin.Context.Sys;
            }
        }
        orddet xDetail;
        qualitycontrol xQC;
        private Int32 iMinHeight = 48;
        private Int32 iMinWidth = 775;
        private Boolean bSelected = true;
        private Boolean bCheckEnabled = true;
        ArrayList aPictures = new ArrayList();

        public PickReceiveItem()
        {
            InitializeComponent();
        }
        public void CompleteLoad(nObject n)
        {
            //if (xs == null)
            //    return;
            //xSys = xs;
            if (n == null)
            {
                xDetail = orddet.New(RzWin.Context);
                return;
            }
            else
            {
                string type = n.ClassId;
                if (n.ClassId.ToLower().StartsWith("orddet"))
                    type = "orddet";
                switch (type)
                {
                    case "orddet":
                        xDetail = (orddet)n;
                        IsSelected = true;
                        break;
                    case "qualitycontrol":
                        xQC = (qualitycontrol)n;
                        xDetail = xQC.GetOrderDetailObject(RzWin.Context);
                        IsCheckEnabled = false;
                        bSelected = false;
                        break;
                }
            }
            DoResize();
            if (xQC == null)
                AssembleQCObject();
            LoadQCObject();
        }
        public Boolean CompleteSave()
        {
            return true;
        }
        public Int32 MinHeight
        {
            get
            {
                return iMinHeight;
            }
            set
            {
                iMinHeight = value;
                DoResize();
            }
        }
        public Int32 MinWidth
        {
            get
            {
                return iMinWidth;
            }
            set
            {
                iMinWidth = value;
                DoResize();
            }
        }
        public Boolean IsSelected
        {
            get
            {
                return bSelected;
            }
            set
            {
                bSelected = value;
                chkReceive.Checked = bSelected;
            }
        }
        public Boolean IsCheckEnabled
        {
            get
            {
                return bCheckEnabled;
            }
            set
            {
                bCheckEnabled = value;
                picDone.BringToFront();
                if (bCheckEnabled)
                    picDone.Visible = false; 
                else
                    picDone.Visible = true;
            }
        }
        //Public Functions
        public void DoResize()
        {
            try
            {
                if (this.Width < iMinWidth)
                    this.Width = iMinWidth;
                if (this.Height < iMinHeight)
                    this.Height = iMinHeight;
                picN.Top = 3;
                picY.Top = 3;
                picN.Left = this.Width - (picN.Width + 5);
                picY.Left = picN.Left;
                chkReceive.Left = 5;
                chkReceive.Top = 5;
                lblCount.Top = this.Height - (lblCount.Height + 5);
                lblCount.Left = 0;
                lblItem.Top = 5;
                lblItem.Left = lblCount.Right + 2;
                lblComments.Top = lblItem.Bottom + 7;
                lblComments.Left = lblItem.Left;
                txtItem.Top = 3;
                txtItem.Left = lblItem.Right;
                txtComments.Top = lblComments.Top - 2;
                txtComments.Left = txtItem.Left;
                txtComments.BringToFront();
                txtQty.BringToFront();
                lblMFG.Top = lblQty.Top;
                lblMFG.Left = (this.Width / 2);
                txtMFG.Top = txtItem.Top;
                txtMFG.Left = lblMFG.Right - 2;
                txtMFG.BringToFront();
                cboPkg.Top = 2;
                cboPkg.Left = picN.Left - (cboPkg.Width + 2);
                lblPkg.Top = lblQty.Top;
                lblPkg.Left = cboPkg.Left - (lblPkg.Width + 2);
                cboCond.Top = cboPkg.Top;
                cboCond.Left = lblPkg.Left - (cboCond.Width + 2);
                lblCond.Top = lblQty.Top;
                lblCond.Left = cboCond.Left - (lblCond.Width + 2);
                Int32 i = lblCond.Left - txtMFG.Left;
                i = (i - 30) / 2;
                txtMFG.Width = i;
                lblDC.Top = lblQty.Top;
                lblDC.Left = txtMFG.Right;
                txtDC.Top = txtItem.Top;
                txtDC.Left = lblDC.Right;
                txtDC.Width = i;
                i = lblMFG.Left - txtItem.Left;
                i = (i - 30) / 2;
                txtItem.Width = i;
                lblQty.Top = lblItem.Top;
                lblQty.Left = txtItem.Right;
                txtQty.Top = txtItem.Top;
                txtQty.Left = lblQty.Right;
                txtQty.Width = i - chkTotalQty.Width;                
                chkTotalQty.Top = txtQty.Top + 4;
                chkTotalQty.Left = txtQty.Right + 1;
                txtComments.Width = this.Width - (txtComments.Left + 5); ;
                txtComments.Height = this.Height - (txtComments.Top + 5);
                if (txtComments.Height < 34)
                    txtComments.ScrollBars = ScrollBars.None;
                else
                    txtComments.ScrollBars = ScrollBars.Vertical;
                ctl_initials.Top = lblComments.Bottom;
                ctl_initials.Left = lblComments.Left;
                SetBorder();
            }
            catch (Exception)
            { }
        }
        public void SetCount(Int32 iIn)
        {
            lblCount.Text = iIn.ToString();
        }
        public void SetFocus()
        {
            txtItem.Focus();
        }
        public Int32 GetTop()
        {
            return this.Top;
        }
        public void SetTop(Int32 top)
        {
            this.Top = top;
        }
        public Int32 GetLeft()
        {
            return this.Left;
        }
        public void SetLeft(Int32 top)
        {
            this.Left = top;
        }
        public Int32 GetMinHeight()
        {
            return iMinHeight;
        }
        public Int32 GetMinWidth()
        {
            return iMinWidth;
        }
        public void SetQtyFocus()
        {
            return;
        }
        public nObject GetMainObject()
        {
            AssembleQCObject();
            return xQC;
        }
        public void UpdatePictureCollection(String ID)
        {
            if (!Tools.Strings.StrExt(ID))
                return;
            foreach (partpicture p in aPictures)
            {
                p.the_qualitycontrol_uid = ID;
                p.Update(RzWin.Context);
            }
        }
        public Boolean HasPictures()
        {
            if (aPictures.Count > 0)
                return true;
            if (!Tools.Strings.StrExt(xQC.unique_id))
                return false;
            String ID = RzWin.Context.SelectScalarString("select top 1 unique_id from partpicture where the_qualitycontrol_uid = '" + xQC.unique_id + "'");
            if (!Tools.Strings.StrExt(ID))
                return false;
            return true;
        }
        public void OpenPictureViewer()
        {
            RzWin.Context.TheLeader.Error("reorg");

            /*

            frmPartPictureViewer xPart = new frmPartPictureViewer();
            PartPictureViewer p = new PartPictureViewer();
            p.ShowPartNumberLink = true;
            p.DisablePartLink = true;
            p.ShowPartSearch = false;
            p.ShowZoomButton = true;
            p.ShowFullScreenButton = false;
            if (Tools.Strings.StrExt(xQC.unique_id))
            {
                p.Caption = "Pictures for QC Item# " + xQC.fullpartnumber;
                xPart.CompleteLoad(p);
                xPart.LoadFormBy(xQC);
            }
            else
            {
                p.Caption = "Pictures for Order# " + xDetail.ordernumber + " : " + xDetail.fullpartnumber;
                xPart.CompleteLoad(p);
                xPart.LoadFormBy(xDetail, "select * from partpicture where the_orddet_uid = '" + xDetail.unique_id + "' and the_qualitycontrol_uid = ''");
            }
            xPart.ShowDialog();
            aPictures = xPart.GetPictureCollection();
            SetPicturePic();

            */
        }        
        //Private Functions
        private void AssembleQCObject()
        {
            MessageBox.Show("reorg");

            /*

            try
            {
                if (xQC == null)
                {
                    xQC = new qualitycontrol(xSys);
                    xQC.fullpartnumber = xDetail.fullpartnumber;
                    xQC.quantityreceived = xDetail.quantityordered - xDetail.quantityfilled;
                    xQC.quantitybackordered = xQC.quantityreceived;
                    xQC.manufacturer = xDetail.manufacturer;
                    xQC.datecode = xDetail.datecode;
                    xQC.condition = xDetail.condition;
                    xQC.internalcomment = xDetail.internalcomment;
                    xQC.packaging = xDetail.packaging;
                }
                else
                {
                    xQC.fullpartnumber = txtItem.Text;
                    xQC.quantityreceived = ConvertTextToInt64(txtQty.Text);
                    xQC.quantitybackordered = xDetail.quantityordered - xQC.quantityreceived;
                    xQC.manufacturer = txtMFG.Text;
                    xQC.datecode = txtDC.Text;
                    xQC.condition = cboCond.Text;
                    xQC.internalcomment = txtComments.Text;
                    xQC.packaging = cboPkg.Text;
                    xQC.GrabFormValues(this);
                }
                xQC.IsFullyReceived = chkTotalQty.Checked;
                PartObject.ParsePartNumber(xQC);
                xQC.the_company_uid = xDetail.GetCompanyID();
                xQC.the_companycontact_uid = xDetail.GetOrderObject().base_companycontact_uid;
                if( xDetail.LinkedPart != null )
                    xQC.the_partrecord_uid = xDetail.LinkedPart.unique_id;
                xQC.the_orddet_uid = xDetail.unique_id;
                SetCompanyInfo();
            }
            catch (Exception)
            { }
             * 
             * */
        }
        private Int64 ConvertTextToInt64(String sIn)
        {
            try
            {
                return Int64.Parse(sIn);
            }
            catch (Exception)
            { return 0; }
        }
        private void LoadQCObject()
        {
            txtItem.Text = xQC.fullpartnumber;
            txtQty.Text = xQC.quantityreceived.ToString();
            txtMFG.Text = xQC.manufacturer;
            txtDC.Text = xQC.datecode;
            cboPkg.Text = xQC.packaging;
            cboCond.Text = xQC.condition;
            txtComments.Text = xQC.internalcomment;
            NMWin.GrabFormValues(this, xQC);
            SetPicturePic();
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
        private void SetPicturePic()
        {
            picN.BringToFront();
            if (HasPictures())
                picY.BringToFront();
        }
        private void SetCompanyInfo()
        {
            companycontact cc = companycontact.GetById(RzWin.Context, xQC.the_companycontact_uid);
            if (cc != null)
            {
                xQC.companyname = cc.companyname;
                xQC.contactname = cc.contactname;
                return;
            }
            company c = company.GetById(RzWin.Context, xQC.the_company_uid);
            if (c != null)
                xQC.companyname = c.companyname;
        }
        //Control Events
        private void PickReceiveItem_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lblItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.Show(xDetail); 
        }
        private void picN_DoubleClick(object sender, EventArgs e)
        {
            OpenPictureViewer();
        }
        private void picY_DoubleClick(object sender, EventArgs e)
        {
            OpenPictureViewer();
        }
        private void chkReceive_CheckedChanged(object sender, EventArgs e)
        {
            IsSelected = chkReceive.Checked;
        }
    }
}
