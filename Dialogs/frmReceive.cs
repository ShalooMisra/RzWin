using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;

using Tools;
using NewMethod;
using Core;

namespace Rz5
{
    public partial class frmReceive : Form
    {
        //public static String GetReceiveQuantityString(ContextRzCommon q, partrecord p, ordhed o, orddet d, long qDefault, IWin32Window owner)
        //{
        //    frmReceive xForm = new frmReceive();
        //    xForm.CurrentPart = p;
        //    xForm.CurrentOrder = o;
        //    xForm.CurrentDetail = d;

        //    xForm.CompleteLoad(q);
        //    xForm.SetQuantity(qDefault);

        //    xForm.ShowDialog(owner);
        //    String ret = xForm.EnteredQuantity;
        //    try
        //    {
        //        xForm.Close();
        //    }
        //    catch
        //    {
        //    }
        //    try
        //    {
        //        xForm.Dispose();
        //        xForm = null;
        //    }
        //    catch
        //    {
        //    }
        //    return ret;
        //}

        public partrecord CurrentPart;
        public orddet CurrentDetail;
        public ordhed CurrentOrder;
        public String EnteredQuantity;
        ArrayList NewPicFiles = new ArrayList();
        ArrayList WatchThreads = new ArrayList();
        protected view_qualitycontrol inspectionview;

        public frmReceive()
        {
            InitializeComponent();
        }
        void CompleteDispose()
        {

            try
            {
                pStandard.Controls.Remove(inspectionview);
                inspectionview.Dispose();
                inspectionview = null;
            }
            catch { }


            try
            {

                this.cmdOK.Click -= new System.EventHandler(this.cmdOK_Click);
                this.cmdCancel.Click -= new System.EventHandler(this.cmdCancel_Click);
                this.lvPics.DoubleClick -= new System.EventHandler(this.lvPics_DoubleClick);
                this.cmdAdd.Click -= new System.EventHandler(this.cmdAdd_Click);
                this.lvNew.Click -= new System.EventHandler(this.lvNew_Click);
                this.fsw.Changed -= new System.IO.FileSystemEventHandler(this.fsw_Changed);
                this.fsw2.Changed -= new System.IO.FileSystemEventHandler(this.fsw2_Changed);
                this.lblLoadPics.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLoadPics_LinkClicked);
                this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.frmReceive_FormClosing);

                lvPics.Items.Clear();
                il.Images.Clear();
                il.Dispose();
            }
            catch { }
        }
        public void SetQuantity(long q)
        {
            ctlQuantity.SetValue(q);
        }
        public void CompleteLoad(ContextRz q)
        {
            /*

            if (inspectionview == null)
            {
                inspectionview = (view_qualitycontrol)Rz3App.xSys.GetView("qualitycontrol", "");
                pStandard.Controls.Add(inspectionview);
                inspectionview.Init();
                this.Width = inspectionview.Width + pRight.Width + 10;
            }

            lblSerialNumbers.Visible = Rz3App.xLogic.IsPhoenix;

            inspectionview.SetCurrentObject(CurrentPart.QCObject);
            inspectionview.CurrentDetail = CurrentDetail;
            inspectionview.CurrentPart = CurrentPart;
            inspectionview.CurrentOrder = CurrentOrder;
            inspectionview.CompleteLoad();
            String strDetail;
            //show the summaries
            //po
            strDetail = CurrentOrder.ToString() + "\r\nAgent: " + CurrentOrder.agentname;
            lblPODetail.Text = strDetail;
            //line item
            strDetail = "Part: " + CurrentDetail.fullpartnumber + "\r\nAlternate: " + CurrentDetail.alternatepart + "\r\nOrdered: " + Tools.Number.LongFormat(CurrentDetail.quantityordered) + "    Already filled: " + Tools.Number.LongFormat(CurrentDetail.quantityfilled);
            lblDetailDetail.Text = strDetail;
            //part
            strDetail = "Part: " + CurrentPart.fullpartnumber + "\r\nAlternate: " + CurrentPart.alternatepart + "\r\nCurrent QTY: " + Tools.Number.LongFormat(CurrentPart.quantity) + "\r\nType: " + CurrentPart.stocktype;
            lblInventoryDetail.Text = strDetail;
            //sale
            ordhed sale = CurrentOrder.GetLinkedSalesOrder();
            if(sale == null)
            {
                gbSale.Text = "<Stock Purchase>";
                gbSale.Enabled = false;
                lblSaleDetail.Text = "Stock Purchase";
            }
            else
            {
                strDetail = sale.ToString() + "\r\nAgent: " + sale.agentname;
                lblSaleDetail.Text = strDetail;
            }
            //show the pics and docs
            //LoadPics();

            String strDrive = Path.GetPathRoot(Tools.FileSystem.GetAppPath()).ToLower();
            switch (strDrive)
            {
                case "a:\\":
                case "b:\\":
                case "c:\\":
                case "d:\\":
                case "e:\\":
                case "f:\\":
                case "g:\\":
                case "h:\\":
                case "i:\\":
                case "j:\\":
                case "k:\\":
                case "l:\\":
                case "m:\\":
                case "n:\\":
                case "o:\\":
                case "p:\\":
                case "q:\\":
                case "r:\\":
                case "s:\\":
                case "t:\\":
                case "u:\\":
                case "v:\\":
                case "w:\\":
                case "x:\\":
                case "y:\\":
                case "z:\\":
                    try
                    {
                        fsw.Path = strDrive;
                        fsw.IncludeSubdirectories = true;
                        fsw.EnableRaisingEvents = true;
                    }
                    catch { }

                    String s = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (!s.ToLower().StartsWith(strDrive))
                    {
                        //start watching the mydocs folder and subfolders
                        WatchAdditionalFolder(s);
                    }
                    break;
            }

            ctlQuantity.Focus();
            pStandard.BringToFront();
            DoResize();
             * 
             * */
        }
        private void WatchAdditionalFolder(String strFolder)
        {
            Thread t = new Thread(new ParameterizedThreadStart(WatchFolderOnThread));
            t.SetApartmentState(ApartmentState.STA);
            WatchThreads.Add(t);
            t.Start((Object)strFolder);
        }
        void WatchFolderOnThread(Object x)
        {
            try
            {
                String strFolder = Tools.Folder.ConditionFolderName((String)x);
                ArrayList last = new ArrayList();
                ScanFolder(strFolder, last, null);
                while (true)
                {
                    Thread.Sleep(3000);
                    ArrayList a = new ArrayList();
                    ScanFolder(strFolder, last, a);
                    foreach (String s in a)
                    {
                        CheckFile(s);
                    }
                }
            }
            catch { }
        }
        private void ScanFolder(String strFolder, ArrayList last, ArrayList compare)
        {
            String[] s = Directory.GetFiles(strFolder);
            foreach (String strFile in s)
            {
                if (!last.Contains(strFile))
                {
                    last.Add(strFile);
                    if (compare != null)
                        compare.Add(strFile);
                }
            }
            String[] dirs = Directory.GetDirectories(strFolder);
            foreach (String d in dirs)
            {
                ScanFolder(Tools.Folder.ConditionFolderName(d), last, compare);
            }
        }
        private void LoadPics()
        {
            lvPics.Items.Clear();
            lvPics.BeginUpdate();
            try
            {
                il.Images.Clear();
                ArrayList pics = DataSql.QtC(RzWin.Context, "partpicture", "select * from partpicture where the_orddet_uid = '" + CurrentDetail.unique_id + "'", RzWin.Logic.PictureData);  //this didn't have the picturedata option before
                foreach (partpicture p in pics)
                {
                    AddPartPicture(p);
                }
            }
            catch
            {
            }
            lvPics.EndUpdate();
        }
        //private Boolean CheckNascoScreen()
        //{
        //    return inspectionview.CheckNascoCompleted();
        //}
        private void AddPartPicture(partpicture p)
        {
            ListViewItem i = lvPics.Items.Add(p.description);
            Image m = p.GetImage(RzWin.Context, 32, 32);
            if (m == null)
            {
                m = nTools.GetGenericThumbnail(32, 32);
            }
            il.Images.Add(p.unique_id, m);
            i.ImageKey = p.unique_id;
            i.Tag = p;
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            EnteredQuantity = "";
            this.Hide();
        }
        protected virtual void cmdOK_Click(object sender, EventArgs e)
        {    //KT Refactored from RzSensibleWin 12-5-2018
            StringBuilder sb = new StringBuilder();
            bool b = this.inspectionview.AllQuestionsAnswered(sb);  // MandatoryValuesFilled(this);
            if (!b)  //&& !Rz3App.xUser.IsDeveloper()
            {
                RzWin.Context.Leader.Tell("Please complete the questionnaire by selecting 'Y', 'N' or 'NA' on:\r\n\r\n" + sb.ToString());
                return;
            }
            //End Refactor

            if (ctlQuantity.GetValue_Long() == 0)
            {
                RzWin.Leader.Tell("Please enter a quantity to receive before continuing.");
                return;
            }
            //if(Rz3App.xLogic.IsNasco && !CheckNascoScreen())
            //{
            //    RzWin.Leader.Tell("You need to completely fill out this screen before continuing.");
            //    return;
            //}
            EnteredQuantity = ctlQuantity.GetValue_Long().ToString();
            inspectionview.CompleteSave();
            this.Hide();
        }
        private void fsw_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            CheckFile(e.FullPath);
        }
        private void fsw2_Changed(object sender, FileSystemEventArgs e)
        {
            CheckFile(e.FullPath);
        }
        private void CheckFile(String strFile)
        {
            if (InvokeRequired)
                Invoke(new CheckFileHandler(ActuallyCheckFile), new object[] { strFile });
            else
                ActuallyCheckFile(strFile);
        }
        delegate void CheckFileHandler(String strFile);
        private void ActuallyCheckFile(String strFile)
        {
            String ext = Path.GetExtension(strFile);
            switch (ext.ToLower())
            {
                case ".jpg":
                case ".bmp":
                case ".gif":
                case ".mpg":
                case ".pdf":
                    CheckGrabFile(strFile);
                    break;
            }
        }
        private void CheckGrabFile(String strFile)
        {
            lock (NewPicFiles.SyncRoot)
            {
                if (NewPicFiles.Contains(strFile))
                    return;
                NewPicFiles.Add(strFile);
                ListViewItem i = lvNew.Items.Add(Path.GetFileName(strFile));
                i.SubItems.Add(Path.GetDirectoryName(strFile));
                i.Tag = strFile;
                ShowThumbnail(strFile);
            }
        }
        private void ShowThumbnail(String strFile)
        {
            Image i = nTools.GetImage(strFile, pbNew.Width, pbNew.Height);
            pbNew.Image = i;
        }
        private void AddSelected()
        {
            try
            {
                String s = GetSelectedNewFileName();
                if (!File.Exists(s))
                    return;
                partpicture p = partpicture.New(RzWin.Context);
                p.the_orddet_uid = CurrentDetail.unique_id;
                p.the_partrecord_uid = CurrentPart.unique_id;
                p.the_qualitycontrol_uid = CurrentPart.QCObjectGet(RzWin.Context).unique_id;
                p.fullpartnumber = CurrentDetail.fullpartnumber;
                p.description = RzWin.Leader.AskForString("Description", Path.GetFileName(s), "Description");
                if (!Tools.Strings.StrExt(p.description))
                    p.description = Path.GetFileName(s);
                p.InsertTo(RzWin.Context, RzWin.Logic.PictureData);
                p.SetPictureDataByFile(RzWin.Context, s);
                p.SavePictureData(RzWin.Context);
                AddPartPicture(p);
            }
            catch { }
        }
        private void lvNew_Click(object sender, EventArgs e)
        {
            String s = GetSelectedNewFileName();
            if (!File.Exists(s))
                return;
            ShowThumbnail(s);
        }
        private String GetSelectedNewFileName()
        {
            try
            {
                return (String)lvNew.SelectedItems[0].Tag;
            }
            catch
            {
                return "";
            }
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddSelected();
        }
        private void lvPics_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                partpicture p = (partpicture)lvPics.SelectedItems[0].Tag;
                Form f = new Form();
                f.WindowState = FormWindowState.Maximized;
                PictureBox b = new PictureBox();
                f.Controls.Add(b);
                b.Dock = DockStyle.Fill;
                b.Image = p.GetImage(RzWin.Context, b.Width, b.Height);
                f.ShowDialog(this);
            }
            catch
            {
            }
        }
        private void frmReceive_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(Rz3App.xLogic.IsNasco)
            //{
            //    if(!CheckNascoScreen())
            //    {
            //        RzWin.Leader.Tell("You need to completely fill out this screen before continuing.");
            //        e.Cancel = true;
            //        return;
            //    }
            //}
        }
        private void lblLoadPics_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadPics();
        }
        private void ctlQuantity_DataChanged(GenericEvent e)
        {
            //if (Rz3App.xLogic.IsMerit)
            //{
            //    vf.SetField("txtQuantity", ctlQuantity.GetValue_Long().ToString());
            //}
        }
        private void lblOld_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        //private void lblSerialNumbers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    Rz3App.xLogic.ShowSerialNumbers(CurrentPart, CurrentDetail, this);

        //}
        private void frmReceive_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        void DoResize()
        {
            try
            {
                pStandard.Left = 0;
                pStandard.Width = this.ClientRectangle.Width;
                pStandard.Height = this.ClientRectangle.Height - pStandard.Top;

                pRight.Left = pStandard.ClientRectangle.Width - pRight.Width;
                pRight.Top = 0;
                pRight.Height = pStandard.ClientRectangle.Height;

                inspectionview.Left = 0;
                inspectionview.Top = 0;
                inspectionview.Width = pStandard.ClientRectangle.Width - pRight.Width;
                inspectionview.Height = pStandard.ClientRectangle.Height;
            }
            catch { }
        }
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            BrowseForPictureFile();
        }
        private void BrowseForPictureFile()
        {
            try
            {
                OpenFileDialog of = new OpenFileDialog();
                of.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
                of.ShowDialog(this);
                string file = of.FileName;
                if (!Tools.Strings.StrExt(file))
                    return;
                if (!Tools.Files.FileExists(file))
                    return;
                CheckFile(file);
                SelectBrowseFile(file);
                AddSelected();
            }
            catch { }
        }
        private void SelectBrowseFile(string file)
        {
            lvNew.SelectedItems.Clear();
            foreach (ListViewItem i in lvNew.Items)
            {
                if (Tools.Strings.StrCmp(i.Tag.ToString(), file))
                {
                    i.Selected = true;
                    return;
                }
            }
        }
    }
}