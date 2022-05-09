using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmQC : Form
    {
        //Private Delegates
        private delegate void CheckFileHandler(String strFile);
        //Protected Variables
        protected ContextRz TheContext;
        protected orddet_line TheDetail;
        protected pack ThePack;
        protected ArrayList NewPicFiles = new ArrayList();
        protected view_qualitycontrol qc;
        protected String OrderNumber = "";

        //Constructors
        public frmQC()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad(ContextRz x, pack thePack, orddet_line det, string order_number)
        {
            return CompleteLoad(x, thePack, det, order_number, null);
        }
        public bool CompleteLoad(ContextRz x, pack thePack, orddet_line det, string order_number, qualitycontrol q)
        {
            if (x == null)
                return false;
            TheContext = x;
            if (thePack == null)
                return false;
            ThePack = thePack;
            if (det == null)
                return false;
            TheDetail = det;
            if (q == null)
                q = GetNewInspection();
            if (!SetUpQCView(q))
                return false;
            OrderNumber = order_number;
            LoadPics();
            return true;
        }
        public void CompleteDispose()
        {
            if (qc == null)
                return;
            qc.SaveCompleted -= new EventHandler(qc_SaveCompleted);
        }
        //Private Functions
        protected virtual bool SetUpQCView(qualitycontrol q)
        {
            if (q == null)
                return false;
            qc = RzWin.Leader.GetQCView(RzWin.Context);
            qc.SaveCompleted += new EventHandler(qc_SaveCompleted);
            this.Controls.Add(qc);
            qc.Top = 0;
            qc.Left = 0;
            qc.Dock = DockStyle.Fill;
            qc.CurrentDetail = TheDetail;
            qc.SetCurrentObject(q);
            qc.CompleteLoad();
            return true;
        }
        private qualitycontrol GetNewInspection()
        {
            qualitycontrol q = RzWin.Context.Sys.TheOrderLogic.GetNewInspection(TheContext);
            q.the_n_user_uid = TheContext.xUser.unique_id;
            q.agentname = TheContext.xUser.name;
            q.fullpartnumber = TheDetail.fullpartnumber;
            q.manufacturer = TheDetail.manufacturer;
            q.the_orddet_uid = TheDetail.unique_id;
            q.the_companycontact_uid = ThePack.unique_id;
            q.quantityreceived = ThePack.quantity;
            q.condition = ThePack.condition;
            q.packaging = ThePack.packaging;
            q.datecode = ThePack.datecode;
            q.processor_name = RzWin.Context.xUser.name;
            q.the_n_user_uid = RzWin.Context.xUser.unique_id;
            if (!Tools.Strings.StrExt(q.unique_id))
                q.Insert(RzWin.Context);
            else
                q.Update(RzWin.Context);
            return q;
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
        private void CheckFile(String strFile)
        {
            if (InvokeRequired)
                Invoke(new CheckFileHandler(ActuallyCheckFile), new object[] { strFile });
            else
                ActuallyCheckFile(strFile);
        }
        private void AddSelected()
        {
            try
            {
                String s = GetSelectedNewFileName();
                if (!Tools.Files.FileExists(s))
                    return;
                partpicture p = partpicture.New(RzWin.Context);
                p.the_orddet_uid = TheDetail.unique_id;
                p.the_qualitycontrol_uid = ThePack.unique_id;
                p.fullpartnumber = TheDetail.fullpartnumber;
                p.description = TheContext.TheLeader.AskForString("Description", System.IO.Path.GetFileName(s), false);
                if (!Tools.Strings.StrExt(p.description))
                    p.description = System.IO.Path.GetFileName(s);
                p.order_caption = OrderNumber;
                p.InsertTo(RzWin.Context, RzWin.Logic.PictureData);
                p.SetPictureDataByFile(RzWin.Context, s);
                p.SavePictureData(TheContext);
                AddPartPicture(p);
            }
            catch { }
        }
        private void ActuallyCheckFile(String strFile)
        {
            String ext = System.IO.Path.GetExtension(strFile);
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
                ListViewItem i = lvNew.Items.Add(System.IO.Path.GetFileName(strFile));
                i.SubItems.Add(System.IO.Path.GetDirectoryName(strFile));
                i.Tag = strFile;
                ShowThumbnail(strFile);
            }
        }
        private void ShowThumbnail(String strFile)
        {
            Image i = nTools.GetImage(strFile, pbNew.Width, pbNew.Height);
            pbNew.Image = i;
        }
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
        protected void LoadPics()
        {
            lvPics.Items.Clear();
            lvPics.BeginUpdate();
            try
            {
                il.Images.Clear();
                ArrayList pics = TheContext.QtC("partpicture", "select * from partpicture where the_orddet_uid = '" + TheDetail.unique_id + "' and the_qualitycontrol_uid = '" + ThePack.unique_id + "'");
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
        private void DeleteSelectedPictures()
        {
            if (lvPics.SelectedItems == null)
                return;
            if (!RzWin.Context.TheLeader.AreYouSure("you want to delete " + Tools.Strings.PluralizePhrase("picture", Convert.ToDouble(lvPics.SelectedItems.Count))))
                return;
            foreach (ListViewItem xLst in lvPics.SelectedItems)
            {
                partpicture p = (partpicture)xLst.Tag;
                if (p == null)
                    continue;
                p.Delete(RzWin.Context);
            }
            LoadPics();
        }
        //Buttons
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddSelected();
        }
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            BrowseForPictureFile();
        }
        //Control Events
        private void qc_SaveCompleted(object sender, EventArgs e)
        {
            Close();
        }
        private void lblLoadPics_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadPics();
        }
        private void fsw_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            CheckFile(e.FullPath);
        }
        private void fsw2_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            CheckFile(e.FullPath);
        }
        //Menus
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedPictures();
        }
    }
}
