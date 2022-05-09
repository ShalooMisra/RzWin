using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class frmChooseEmailTemplate : Form
    {
        public emailtemplate SelectedTemplate;
        public nObject CurrentObject;
        public frmChooseEmailTemplate()
        {
            InitializeComponent();
        }
        public string primaryemailaddress = "";

        public void CompleteLoad(nObject xObject)
        {
            CurrentObject = xObject;
            String strClassIn = "";
            String strExtra = "";
            String class_name = xObject.ClassId.ToLower();
            if (class_name.StartsWith("ordhed_"))
            {
                class_name = "ordhed";
                strExtra = xObject.ClassId.ToLower().Replace("ordhed_", "").Trim();
            }
            if (class_name.StartsWith("orddet_"))
            {
                class_name = "orddet";
                strExtra = xObject.ClassId.ToLower().Replace("orddet_", "").Trim();
            }
            switch (class_name)
            {
                case "ordhed":
                    strClassIn = "'ordhed', 'order'";
                    strExtra = " and ( isnull(ordertype, '') = '" + strExtra + "' or isnull(ordertype, '') = '')";
                    break;
                case "partrecord":
                    strClassIn = "'part', 'partrecord'";
                    strExtra = "";
                    break;
                case "offer":
                    strClassIn = "'part', 'partrecord'";
                    strExtra = "";
                    break;
                default:
                    strClassIn = "'" + xObject.ClassId + "'";
                    strExtra = "";
                    break;
            }
            lst.ShowTemplate("email-templates", "emailtemplate");
            lst.ShowData("emailtemplate", " isnull(templatename, '') > '' and class_name in (" + strClassIn + ") " + strExtra, "templatename");
            lst.DisableAutoRefresh();
            LoadAttachments();
            DoResize();
        }
        //Public Functions
        public void DoResize()
        {
            //try
            //{
            //    if (this.Width < 790)
            //        this.Width = 790;
            //    if (this.Height < 600)
            //        this.Height = 600;
            //    split.Left = 2;
            //    split.Top = 2;
            //    split.Width = this.ClientRectangle.Width - 4;
            //    cmdSelect.Top = (this.ClientRectangle.Height - cmdSelect.Height) - 2;
            //    cmdCancel.Top = cmdSelect.Top;
            //    cmdAttachments.Top = cmdSelect.Top;
            //    cmdSelect.Left = 2;
            //    cmdCancel.Left = split.Right - cmdCancel.Width;
            //    cmdAttachments.Left = cmdSelect.Right + (((cmdCancel.Left - cmdSelect.Right) - cmdAttachments.Width) / 2);
            //    split.Height = (cmdSelect.Top - split.Top) - 2;
            //}
            //catch (Exception)
            //{ }
        }
        //Private Functions
        private void PreviewThread()
        {
            wb.ReloadWB();
            wb.Add("<font face=\"Calibri\">Previewing...</font>");
            String sub = "";
            String s = SelectedTemplate.GetGeneralEmailData(RzWin.Context, CurrentObject, ref sub);
            wb.ReloadWB();
            wb.Add(s);
        }
        private void LoadAttachments()
        {
            try
            {
                lvAttachments.Items.Clear(); 
                String SQL = "select unique_id, linkname from filelink where linktype = 'emailattachment'";
                DataTable dt = RzWin.Context.Select(SQL);
                if (dt == null)
                    return;
                if (dt.Rows.Count <= 0)
                    return;
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem xLst = lvAttachments.Items.Add(dr[1].ToString());
                    xLst.Tag = dr[0].ToString();
                }
            }
            catch (Exception)
            { }
        }
        private void EditAttachments()
        {
            MessageBox.Show("reorg");
            //try
            //{
            //    frmAddAttachments xForm = new frmAddAttachments();
            //    xForm.CompleteLoad(Rz3App.xSys);
            //    xForm.ShowDialog();
            //    LoadAttachments();
            //}
            //catch (Exception)
            //{ }
        }
        private ArrayList GetSelectedAttachments()
        {
            ArrayList a = new ArrayList();
            //foreach (ListViewItem xLst in lvAttachments.CheckedItems)
            //{
            //    filelink f = filelink.GetByID(Rz3App.xSys, xLst.Tag.ToString());
            //    if (f != null)
            //    {
            //        f.LoadPictureData();
            //        a.Add(f);
            //    }
            //}
            return a;
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedTemplate = null;
            this.Hide();
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            SelectedTemplate = (emailtemplate)lst.GetSelectedObject();
            if (SelectedTemplate == null)
            {
                RzWin.Context.Error("Please select a template before continuing.");
                return;
            }
            SelectedTemplate.aAttachments = GetSelectedAttachments();
            this.Hide();
        }
        private void cmdAttachments_Click(object sender, EventArgs e)
        {
            EditAttachments();
        }
        private void cmdBlankEmail_Click(object sender, EventArgs e)
        {
            String err = "";
            //ToolsOffice.OutlookOffice.SendOutlookMessage(primaryemailaddress, "", "", false, true, "", "", false, null, "", "", "", RzWin.User.email_signature, ref err);
            //return context.TheSysRz.TheEmailLogic.SendOutlookEmail(strAddress, strHeader + strFooter, strSubject, false, true, "", AttachmentFileString, false, null, strBCC, strFromAddress, "", context.xUser.email_signature, true, ref err);

            return;
        }
        //Control Events
        private void frmChooseEmailTemplate_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lst_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
            SelectedTemplate = (emailtemplate)args.TheItems.FirstGet(RzWin.Context);
            this.Hide();
        }
        private void lst_ObjectClicked(object sender, ObjectClickArgs args)
        {
            SelectedTemplate = (emailtemplate)args.GetObject();
            //cmdSelect.Text = "Select [" + SelectedTemplate.templatename + "]";
            if (CurrentObject != null)
            {
                PreviewThread();
                //Thread t = new Thread(new ThreadStart(PreviewThread));
                //t.SetApartmentState(ApartmentState.STA);
                //t.Start();
            }
        }
    }
}