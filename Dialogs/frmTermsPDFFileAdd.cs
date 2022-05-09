using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmTermsPDFFileAdd : Form
    {
        //Private Variables
        private ContextNM TheContext;
        private printheader TheTemplate;

        //Constructors
        public frmTermsPDFFileAdd()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(ContextNM x)
        {
            TheContext = x;
            LoadLV();
        }
        //Private Functions
        private void Clear()
        {
            txtTemplate.SetValue("");
            TheTemplate = null;
        }
        private void LoadPDFs()
        {
            if (TheTemplate == null)
                return;
            try
            {
                string type = "";
                Enums.OrderType t = Enums.OrderType.Any;
                if (optInvoice.Checked)
                    type = "invoice";
                else if (optQuote.Checked)
                    type = "quote";
                else if (optPurchase.Checked)
                    type = "purchase";
                else
                    return;
                string id = RzWin.Context.SelectScalarString("select unique_id from filelink where linkname = 'pdfterms_" + type + "' and objectclass = 'pdf' and linktype = 'pdf_terms' and objectid = '" + TheTemplate.unique_id + "'");
                txtTemplate.SetValue(id);
                if (Tools.Strings.StrExt(id))
                    cmdRemove.Visible = true;
                else
                    cmdRemove.Visible = false;
            }
            catch { }
        }
        private void LoadLV()
        {
            Clear();
            ordhed o = ordhed.New(RzWin.Context);
            if (optInvoice.Checked)
                o.OrderType = Enums.OrderType.Invoice;
            else if (optQuote.Checked)
                o.OrderType = Enums.OrderType.Quote;
            else if (optPurchase.Checked)
                o.OrderType = Enums.OrderType.Purchase;
            else
                return;
            ListArgs args = RzWin.Context.TheSysRz.TheOrderLogic.OrdHedPrintTemplateArgsGet(RzWin.Context, o, Enums.TransmitType.Print);
            lv.Init(args);
        }
        private void AddPDF(Enums.OrderType t)
        {
            if (TheTemplate == null)
                return;
            try
            {
                if (oFile.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                if (!Tools.Files.FileExists(oFile.FileName))
                    return;
                filelink f = filelink.New(RzWin.Context);
                f.filepath = oFile.FileName;
                f.filetype = "pdf";
                f.linkname = "pdfterms_" + t.ToString();
                f.linktype = "pdf_terms";
                f.objectclass = "pdf";
                f.objectid = TheTemplate.unique_id;
                Byte[] byt = nFile.GetFileFromDisk(oFile.FileName).bytes;
                f.picturedata = byt;
                f.Insert(RzWin.Context);
                f.SavePictureData(RzWin.Context);
            }
            catch { }
            LoadPDFs();
        }
        private void ViewPDF(Enums.OrderType t)
        {
            if (TheTemplate == null)
                return;
            try
            {
                string id = RzWin.Context.SelectScalarString("select unique_id from filelink where linkname = 'pdfterms_" + t.ToString() + "' and objectclass = 'pdf' and linktype = 'pdf_terms' and objectid = '" + TheTemplate.unique_id + "'");
                if (!Tools.Strings.StrExt(id))
                    return;
                filelink f = filelink.GetById(RzWin.Context, id);
                if (f == null)
                    return;
                f.LoadPictureData(RzWin.Context);
                string file = f.SaveDataAsFile();
                if (!Tools.Files.FileExists(file))
                    TheContext.TheLeader.Tell("File : " + file + " not found. Cannot view pdf.");
                string er = "";
                if (!Tools.FileSystem.Shell(file, "", false, false, ref er))
                    TheContext.TheLeader.Tell("Error showing pdf: " + er);
            }
            catch { }
        }
        private void LoadTemplate()
        {
            TheTemplate = (printheader)lv.GetSelectedObject();
            LoadPDFs();
        }
        private void RemoveSelectedPDF()
        {
            if (TheTemplate == null)
                return;
            try
            {
                string type = "";
                Enums.OrderType t = Enums.OrderType.Any;
                if (optInvoice.Checked)
                    type = "invoice";
                else if (optQuote.Checked)
                    type = "quote";
                else if (optPurchase.Checked)
                    type = "purchase";
                else
                    return;
                string id = RzWin.Context.SelectScalarString("select unique_id from filelink where linkname = 'pdfterms_" + type + "' and objectclass = 'pdf' and linktype = 'pdf_terms' and objectid = '" + TheTemplate.unique_id + "'");
                if (!Tools.Strings.StrExt(id))
                    return;
                if (!TheContext.TheLeader.AreYouSure("you want to delete this PDF?"))
                    return;
                RzWin.Context.Execute("delete from filelink where unique_id = '" + id + "'");
                LoadPDFs();
            }
            catch { }
        }
        //Control Events
        private void optQuote_CheckedChanged(object sender, EventArgs e)
        {
            LoadLV();
        }
        private void optPurchase_CheckedChanged(object sender, EventArgs e)
        {
            LoadLV();
        }
        private void optInvoice_CheckedChanged(object sender, EventArgs e)
        {
            LoadLV();
        }
        private void lv_ObjectClicked(object sender, ObjectClickArgs args)
        {
            LoadTemplate();
        }
        private void lv_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;
        }
        //Buttons
        private void cmdAddInvoice_Click(object sender, EventArgs e)
        {
            Enums.OrderType t = Enums.OrderType.Any;
            if (optInvoice.Checked)
                t = Enums.OrderType.Invoice;
            else if (optQuote.Checked)
                t = Enums.OrderType.Quote;
            else if (optPurchase.Checked)
                t = Enums.OrderType.Purchase;
            else
                return;
            AddPDF(t);
        }
        private void cmdViewInvoice_Click(object sender, EventArgs e)
        {
            Enums.OrderType t = Enums.OrderType.Any;
            if (optInvoice.Checked)
                t = Enums.OrderType.Invoice;
            else if (optQuote.Checked)
                t = Enums.OrderType.Quote;
            else if (optPurchase.Checked)
                t = Enums.OrderType.Purchase;
            else
                return;
            ViewPDF(t);
        }
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            RemoveSelectedPDF();
        }
    }
}
