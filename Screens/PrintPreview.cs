using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Threading;
using System.IO;
using Core;
using NewMethod;
using System.Collections.Generic;
using System.Linq;

namespace Rz5
{
    public partial class PrintPreview : UserControl
    {
        //Public Variables
        public TransmitParameters CurrentParameters;
        //Protected Variables
        protected ArrayList CurrentObjects = new ArrayList();
        //protected System.Drawing.Image CurrentPreviewImage;
        //Private Variables
        private bool bDone = false;
        private String printer_name = "";
        private String abs_printer_name = "";
        private String PrinterName
        {
            get
            {
                if (Tools.Strings.StrExt(abs_printer_name) && PrintSessionPrinter.PrinterExists(abs_printer_name))
                    return abs_printer_name;

                if (CurrentParameters.PrintTemplate != null)
                {
                    if (Tools.Strings.StrExt(CurrentParameters.PrintTemplate.printername) && PrintSessionPrinter.PrinterExists(CurrentParameters.PrintTemplate.printername))
                        printer_name = CurrentParameters.PrintTemplate.printername;
                    else
                        printer_name = PrintSessionPrinter.GetCurrentPrinter();
                }
                else
                    printer_name = PrintSessionPrinter.GetCurrentPrinter();
                return printer_name;
            }
            set
            {
                printer_name = value;
                if (CurrentParameters.PrintTemplate != null)
                    CurrentParameters.PrintTemplate.printername = value;
            }
        }
        private int PreviewImageHeight = 0;
        private int PreviewImageWidth = 0;
        private PrintSessionImages PreviewSession;
        private DateTime PreviewStarted;
        private bool Printing = false;

        //Constructors
        public PrintPreview()
        {
            InitializeComponent();
            try
            {
                picPrint.BackgroundImage = il.Images["Print"];
                picFax.BackgroundImage = il.Images["Fax"];
                picEmail.BackgroundImage = il.Images["Email"];
                picPDF.BackgroundImage = il.Images["PDF"];
            }
            catch { }
        }

        protected nObject CurrentObject
        {
            get
            {
                if (CurrentObjects.Count == 0)
                    return null;
                else
                    return (nObject)CurrentObjects[0];
            }
        }

        public virtual void CompleteLoad(ArrayList os, TransmitParameters p)
        {



            chkIncludePDF.Checked = false;
            cmdEdit.Visible = RzWin.User.IsDeveloper();
            if (os != null)
                CurrentObjects = os;

            if (p != null)
                CurrentParameters = p;
            string ord_type = "";
            ordhed ord = null;
            try
            {
                ord = (ordhed)CurrentObjects[0];
                ord_type = ord.ordertype;

            }
            catch { }

            int noPrintCount = ord.DetailsList(RzWin.Context).Count(cc => cc.noPrint == true);

            if (noPrintCount > 0)
                if (!RzWin.Context.Leader.AskYesNo("Heads up, some lines have been excluded from printing, would you like to proceed?  If not, press No, and use the 'Print Toggle' feature."))
                    return;


            if (!Tools.Strings.HasString(ord_type, "sales"))
            {
                chkConsolidateLines.Checked = true;
                CurrentParameters.ConsolidateLines = true;
            }
            else
            {
                chkConsolidateLines.Checked = false;
                CurrentParameters.ConsolidateLines = false;
            }

            //Sinec Disty sales does rapid quoting, it's useful to 
            if (ord_type == Enums.OrderType.Quote.ToString())
            {
                if (RzWin.Context.xUserRz.Teams.AllByName.ContainsKey("distributor sales"))
                {
                    ctl_cc_agent.Checked = true;
                    if (CurrentParameters.CCLines != RzWin.Context.xUser.email_address)
                        CurrentParameters.CCLines = RzWin.Context.xUser.email_address;
                }
            }



            String strTemplate = "";
            String strClass = "";
            String strWhere = "";
            String strOrder = "";

            SetStatus("");

            //LoadFlash();
            pCopies.Visible = false;

            chkDisablePreview.Checked = RzWin.User.GetSetting_Boolean(RzWin.Context, "disable_preview");

            if (CurrentParameters.type == Enums.TransmitType.Email)
            {
                cmdGo.Text = "Email";
                cmdGo.ImageKey = "Email";

                inhibit = true;
                optEmail.Checked = true;
                inhibit = false;

                strTemplate = "EMAILTEMPLATE";
                strClass = "emailtemplate";

                if (CurrentObject is ordhed)
                {
                    strWhere = "isnull(templatename, '') > '' and class_name in ('order', 'ordhed') and ( isnull(ordertype, '') = '" + ((ordhed)CurrentObject).ordertype + "' or isnull(ordertype, '') = '')";

                    if (((ordhed)CurrentObject).OrderType == Enums.OrderType.Sales)
                        strWhere += " and templatename not like '%internal%' ";
                }
                else
                {
                    strWhere = "isnull(templatename, '') > '' and class_name in ('" + CurrentObject.ClassId + "')";
                }


                strOrder = "TEMPLATENAME";
                wb.Visible = true;
                tsPreview.Visible = false;
            }
            else
            {
                wb.Visible = false;
                tsPreview.Visible = true;

                if (CurrentParameters.type == Enums.TransmitType.Fax)
                {
                    cmdGo.Text = "Fax";
                    cmdGo.ImageKey = "Fax";
                    inhibit = true;
                    optFax.Checked = true;
                    inhibit = false;

                }
                else if (CurrentParameters.type == Enums.TransmitType.PDF)
                {
                    cmdGo.Text = ".PDF";
                    cmdGo.ImageKey = "PDF";

                    inhibit = true;
                    optPDF.Checked = true;
                    inhibit = false;

                }
                else
                {
                    cmdGo.Text = "Print";
                    cmdGo.ImageKey = "Print";

                    inhibit = true;
                    optPrint.Checked = true;
                    inhibit = false;

                    pCopies.Visible = true;

                    if (CurrentObject is ordhed)
                    {
                        switch (((ordhed)CurrentObject).OrderType)
                        {
                            case Enums.OrderType.Quote:
                                txtCopies.Text = "1";
                                break;
                            case Enums.OrderType.Sales:
                                txtCopies.Text = "1";
                                break;
                            case Enums.OrderType.Purchase:
                                txtCopies.Text = "1";
                                break;
                            default:
                                txtCopies.Text = "2";
                                break;
                        }
                    }
                    else
                    {
                        txtCopies.Text = "1";
                    }
                }
                ListArgs args = RzWin.Context.TheSysRz.TheOrderLogic.OrdHedPrintTemplateArgsGet(RzWin.Context, CurrentObject, CurrentParameters.type);
                strTemplate = args.TheTemplate;
                strClass = args.TheClass;
                strWhere = args.TheWhere;
                strOrder = args.TheOrder;
            }

            lv.AsyncMode = false;
            lv.ShowTemplate(strTemplate, strClass, RzWin.User.TemplateEditor);
            lv.ShowData(strClass, strWhere, strOrder);
            //
            string templateID = RzWin.Context.TheSysRz.TheEmailLogic.GetDefaultEmailTemplate(RzWin.Context, CurrentObject);
            if (string.IsNullOrEmpty(templateID))
                lv.SelectFirst();
            else
                lv.HighlightByID(templateID);
            lv.DoResize();

            if (CurrentParameters.type == Enums.TransmitType.Email)
            {
                CurrentParameters.EmailTemplate = (emailtemplate)lv.GetSelectedObject();
                ShowEmailPreview();
                lblPrinterInfo.Visible = false;
                gbSize.Visible = false;
            }
            else
            {
                CurrentParameters.PrintTemplate = (printheader)lv.GetSelectedObject();

                lblPrinterInfo.Visible = true;
                if (!Tools.Strings.StrExt(PrinterName))
                {
                    if (CurrentParameters.PrintTemplate != null)
                    {
                        if (Tools.Strings.StrExt(CurrentParameters.PrintTemplate.printername) && PrintSessionPrinter.PrinterExists(CurrentParameters.PrintTemplate.printername))
                            PrinterName = CurrentParameters.PrintTemplate.printername;
                        else
                            PrinterName = PrintSessionPrinter.GetCurrentPrinter();
                    }
                    else
                    {
                        PrinterName = PrintSessionPrinter.GetCurrentPrinter();
                    }
                }

                try
                {
                    if (CurrentParameters.type == Enums.TransmitType.Email)
                    {
                        CurrentParameters.EmailTemplate = (emailtemplate)lv.GetFirstObject();
                    }
                    else
                    {
                        CurrentParameters.PrintTemplate = (printheader)lv.GetFirstObject();
                    }
                    ShowPreview();
                }
                catch (Exception)
                { }
            }
            //if (Rz3App.xLogic.IsAAT)
            //    lv.GetListViewControl().CheckBoxes = true;            
            chkIncludePDF.Visible = optEmail.Checked && RzWin.Context.xUser.IsDeveloper();

        }

        private void ShowPreview()
        {
            if (chkDisablePreview.Checked)
                return;
            CurrentParameters.ConsolidateLines = chkConsolidateLines.Checked;
            if (CurrentParameters.type == Enums.TransmitType.Email)
                ShowEmailPreview();
            else
                ShowPrintPreview();
        }

        private void SetStatus(String NewStatus)
        {
            try
            {
                lblStatus.Text = NewStatus;
                lblStatus.Refresh();
            }
            catch (Exception)
            { }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            CompleteLoad(null, null);
        }

        bool previewing = false;
        public void ShowPrintPreview()
        {
            if (previewing)
                return;

            try
            {
                if (CurrentParameters.PrintTemplate.scale_multiplier > 0)
                    numx.Value = Convert.ToDecimal(CurrentParameters.PrintTemplate.scale_multiplier);
                else
                    numx.Value = 1;

                if (chkDisablePreview.Checked)
                    return;

                PreviewStarted = System.DateTime.Now;
                previewing = true;

                try
                {
                    cmdEdit.Visible = false;
                    if (CurrentParameters.PrintTemplate == null)
                        return;

                    MakePrintVisible();


                    SetStatus("Previewing...");
                    cmdEdit.Visible = RzWin.User.IsDeveloper();
                    cmdEdit.Text = "Edit " + CurrentParameters.PrintTemplate.ToString();
                    cmdEdit.Tag = CurrentParameters.PrintTemplate;

                    PrintDocument printDoc = new PrintDocument();
                    printDoc.PrinterSettings.PrinterName = PrinterName;

                    FirstPage.Init(PrinterName, CurrentParameters.PrintTemplate.is_landscape);

                    PreviewImageWidth = FirstPage.GetPG().ClientRectangle.Width;
                    PreviewImageHeight = FirstPage.GetPG().ClientRectangle.Height;

                    lblPrinterInfo.Text = printDoc.PrinterSettings.PrinterName + "\r\nHeight = " + printDoc.DefaultPageSettings.PaperSize.Height.ToString() + "\r\nWidth = " + printDoc.DefaultPageSettings.PaperSize.Width.ToString();

                    gbSize.Visible = true;

                    ArrayList d = new ArrayList();
                    foreach (TabPage p in tsPreview.TabPages)
                    {
                        if (!Tools.Strings.StrCmp(p.Name, "Page1"))
                            d.Add(p);
                    }

                    foreach (TabPage p in d)
                    {
                        tsPreview.TabPages.Remove(p);
                    }

                    DoResize();

                    Thread t = new Thread(new ThreadStart(ShowPrintPreviewThread));
                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();

                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    previewing = false;
                }
            }
            catch { previewing = false; }
        }

        private void MakePrintVisible()
        {
            wb.Visible = false;
            tsPreview.Visible = true;
            //panel.Visible = true;
            //pg.Visible = true;
            //hs.Visible = true;
            //vs.Visible = true;
        }

        private void MakeEmailVisible()
        {
            if (CurrentParameters.EmailTemplate.is_text)
            {
                wb.Visible = false;
                RT.Visible = true;
            }
            else
            {
                wb.Visible = true;
                RT.Visible = false;
            }
            tsPreview.Visible = false;
        }

        private void ShowPrintPreviewThread()
        {
            try
            {
                PreviewSession = new PrintSessionImages(RzWin.Context, CurrentParameters.PrintTemplate, CurrentObject, PreviewImageWidth, PreviewImageHeight);
                PreviewSession.ConsolidateLines = CurrentParameters.ConsolidateLines;
                PreviewSession.Print();

                //Rectangle r = new Rectangle(0, 0, FirstPage.GetPG().Width - 4, FirstPage.GetPG().Height - 4);
                //g.DrawRectangle(new Pen(System.Drawing.Brushes.Blue, 3), r);

                //CurrentParameters.PrintTemplate.CurrentObject = CurrentObject;
                //CurrentParameters.PrintTemplate.ConsolidateLines = 
                //CurrentParameters.PrintTemplate.PrintOnGraphics(RzWin.Context, new Tools.GraphicsWrapper(g), );
                //PreviewImages.Add(CurrentPreviewImage);

                //while (CurrentParameters.PrintTemplate.HasMorePages)
                //{
                //    CurrentPreviewImage = new Bitmap(PreviewImageWidth, PreviewImageHeight);
                //    g = Graphics.FromImage(CurrentPreviewImage);
                //    r = new Rectangle(0, 0, FirstPage.GetPG().Width - 4, FirstPage.GetPG().Height - 4);
                //    g.DrawRectangle(new Pen(System.Drawing.Brushes.Blue, 3), r);
                //    CurrentParameters.PrintTemplate.PrintOnGraphics(RzWin.Context, new Tools.GraphicsWrapper(g), CurrentPreviewImage.Width, CurrentPreviewImage.Height);
                //    PreviewImages.Add(CurrentPreviewImage);
                //}

                PreviewFinished f = new PreviewFinished(FinishPreview);
                this.Invoke(f);
            }
            catch (Exception)
            { }
        }

        protected virtual void FinishPreview()
        {
            try
            {
                int i = 0;
                foreach (Bitmap b in PreviewSession.Images)
                {
                    PrintPreviewPage p = null;
                    if (i == 0)
                        p = FirstPage;
                    else
                        p = AddPreviewPage(i + 1);

                    p.SetBitmap(b);

                    i++;
                }

                TimeSpan t = System.DateTime.Now.Subtract(PreviewStarted);
                SetStatus("Preview complete in " + Math.Round(t.TotalSeconds, 2).ToString() + " seconds(s)");
            }
            catch (Exception)
            { }
            previewing = false;
            bDone = true;
        }
        private string GetAttachmentPDF(bool ask_form)
        {
            try
            {
                ordhed o = (ordhed)CurrentObject;
                printheader p = CurrentParameters.PrintTemplate;
                if (ask_form)
                {
                    p = Rz5.frmChoosePrintedForm.ChoosePrintedForm(RzWin.Context, o, CurrentParameters);
                    if (p == null)
                        return "";
                    CurrentParameters.PrintTemplate = p;
                }

                bDone = false;
                string autoSaveFileName = Tools.Strings.FilterTrash(Tools.Strings.ParseDelimit(o.companyname, "[", 1)) + "_" + o.OrderType.ToString() + "_" + o.ordernumber;

                PrintSessionPdf pdf = new PrintSessionPdf(RzWin.Context, p, CurrentObject);
                return pdf.Print(chkConsolidateLines.Checked, autoSaveFileName);
            }
            catch { }
            return "";
        }

        public PrintPreviewPage AddPreviewPage(int page)
        {
            TabPage t = new TabPage();
            t.Text = "Page " + page.ToString();
            tsPreview.TabPages.Add(t);
            DoResize();
            PrintPreviewPage p = new PrintPreviewPage();
            t.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            DoResize();
            if (CurrentParameters.PrintTemplate == null)
                p.Init(PrinterName, false);
            else
                p.Init(PrinterName, CurrentParameters.PrintTemplate.is_landscape);
            return p;
        }

        public void SelectTemplateByID(String strID)
        {
            lv.HighlightByID(strID);
        }

        public virtual void DoAction_Print(ContextRz context)
        {
            foreach (Object x in CurrentObjects)
            {
                if (x is ordhed)
                {
                    if (CurrentParameters.PrintTemplate != null)
                    {
                        if (!((ordhed)x).PrePrintConfirmation(context, CurrentParameters.PrintTemplate.Name))
                            return;
                    }
                    else if (CurrentParameters.EmailTemplate != null)
                    {
                        if (!((ordhed)x).PrePrintConfirmation(context, CurrentParameters.EmailTemplate.Name))
                            return;
                    }
                }
            }

            try
            {
                if (Printing)
                    return;
                if (CurrentParameters.type == Rz5.Enums.TransmitType.Email)
                {
                    CurrentParameters.Attachment = "";
                    if (chkIncludePDF.Checked)
                        CurrentParameters.Attachment = GetAttachmentPDF(true);
                }
                if (CurrentParameters.type == Rz5.Enums.TransmitType.PDF)
                {
                    string file = GetAttachmentPDF(false);
                    if (File.Exists(file))
                    {
                        Tools.FileSystem.Shell(file);
                        return;
                    }
                }
                if (CurrentParameters.type == Enums.TransmitType.Email)
                {
                    CurrentParameters.EmailTemplate = (emailtemplate)lv.GetSelectedObject();
                    if (CurrentParameters.EmailTemplate == null)
                        return;
                }
                else
                {
                    CurrentParameters.PrintTemplate = (printheader)lv.GetSelectedObject();
                    if (CurrentParameters.PrintTemplate == null)
                        return;
                    if (CurrentParameters.type == Enums.TransmitType.Print)
                    {
                        CurrentParameters.PrinterName = PrinterName;
                        String s = txtCopies.Text;
                        if (Tools.Number.IsNumeric(s))
                            CurrentParameters.CopyCount = Int32.Parse(s);
                        else
                            CurrentParameters.CopyCount = 1;
                    }
                }
                Printing = true;
                try
                {
                    if (CurrentObject is ordhed)
                    {
                        foreach (ordhed o in CurrentObjects)
                        {
                            CurrentParameters.ForceSynchronous = (CurrentObjects.Count > 0);
                            if (o.TempCopyCount > 0)
                                CurrentParameters.CopyCount = o.TempCopyCount;

                            o.Transmit(RzWin.Context, CurrentParameters);
                        }
                    }
                    else
                    {
                        switch (CurrentParameters.type)
                        {
                            case Enums.TransmitType.PDF:
                                PrintSessionPdf pdf = new PrintSessionPdf(RzWin.Context, CurrentParameters.PrintTemplate, CurrentObject);
                                pdf.Print();
                                break;
                            default:
                                PrintSessionPrinter print = new PrintSessionPrinter(RzWin.Context, CurrentParameters.PrintTemplate, CurrentObject);
                                print.Print();
                                break;
                        }
                    }
                }
                catch { }
                Printing = false;
                try
                {
                    ordhed xOrder = (ordhed)CurrentObjects[0];
                    if (xOrder.OrderType == Enums.OrderType.Quote)
                    {
                        String strAction = "quote";
                        if (CurrentParameters.type == Enums.TransmitType.Email)
                            strAction += "|email";
                        RzWin.Logic.UpdateContactStats(context, RzWin.User, xOrder.companyname, xOrder.contactname, xOrder.primaryphone, xOrder.primaryemailaddress, xOrder.GetStrippedPartsIn(RzWin.Context), strAction);
                    }
                }
                catch { }
            }
            catch { }
        }

        private void HandleCommand(String strCommand)
        {
            PrinterName = "";
            CurrentParameters.ConsolidateLines = chkConsolidateLines.Checked;
            //CurrentParameters.ccAgent = ctl_cc_agent.Checked;
            if (ctl_cc_agent.Checked)
                if (!CurrentParameters.CCLines.Contains(RzWin.Context.xUserRz.email_address))
                    CurrentParameters.CCLines += RzWin.Context.xUserRz.email_address;
            switch (strCommand.ToLower().Trim())
            {
                case "switch":

                    if (CurrentParameters.type == Enums.TransmitType.Print || CurrentParameters.type == Enums.TransmitType.Any)
                        CurrentParameters.type = Enums.TransmitType.Fax;

                    else if (CurrentParameters.type == Enums.TransmitType.Fax)
                        CurrentParameters.type = Enums.TransmitType.Email;

                    else if (CurrentParameters.type == Enums.TransmitType.Email)
                        CurrentParameters.type = Enums.TransmitType.PDF;

                    else if (CurrentParameters.type == Enums.TransmitType.PDF)
                        CurrentParameters.type = Enums.TransmitType.Print;

                    Refresh();

                    break;

                case "print":
                    DoAction_Print(RzWin.Context);
                    break;
                case "cancel":
                    CurrentParameters.type = Enums.TransmitType.Any;
                    CurrentParameters.Cancelled = true;
                    RzWin.Form.TabTopClose();
                    break;
                case "preview":
                    if (CurrentParameters.type == Enums.TransmitType.Email)
                    {
                        emailtemplate xEmail = (emailtemplate)lv.GetSelectedObject();
                        if (xEmail == null)
                            return;

                        CurrentParameters.EmailTemplate = xEmail;
                        ShowEmailPreview();
                    }
                    else
                    {
                        if (previewing)
                            return;

                        CurrentParameters.PrintTemplate = (printheader)lv.GetSelectedObject();
                        if (CurrentParameters.PrintTemplate == null)
                            return;
                        if (CurrentParameters.PrintTemplate.copycount > 0)
                            txtCopies.Text = CurrentParameters.PrintTemplate.copycount.ToString();
                        ShowPrintPreview();
                    }
                    break;
            }
        }

        private void lv_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
            HandleCommand("Print");
        }

        private void xFlash_ButtonClick(object sender, FlashClickArgs args)
        {
            HandleCommand(args.strButton);
        }

        public void ShowEmailPreview()
        {
            if (chkDisablePreview.Checked)
                return;

            if (!(CurrentObject is ordhed))
                return;

            cmdEdit.Visible = false;
            if (CurrentParameters.EmailTemplate == null)
                return;

            MakeEmailVisible();

            cmdEdit.Visible = RzWin.User.IsDeveloper();
            cmdEdit.Text = "Edit " + CurrentParameters.EmailTemplate.ToString();
            cmdEdit.Tag = CurrentParameters.EmailTemplate;

            wb.ReloadWB();
            wb.Refresh();
            //if (ctl_cc_agent.Checked)
            //    CurrentParameters.CCLines += RzWin.Context.xUser.email_address;

            String s = CurrentParameters.EmailTemplate.SendOrderEmail(RzWin.Context, (ordhed)CurrentObject, true, "", false, false, false, "", "", "", "", CurrentParameters.CCLines, chkConsolidateLines.Checked);
            if (CurrentParameters.EmailTemplate.is_text)
                RT.Text = s;
            else
                wb.Add(s);
        }


        private void lv_ObjectClicked(object sender, ObjectClickArgs args)
        {
            HandleCommand("preview");
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (cmdEdit.Tag == null)
                return;

            nObject x = (nObject)cmdEdit.Tag;
            RzWin.Context.Show(x);
        }

        private void lblPrinterInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePrinter();
        }

        private void ChangePrinter()
        {
            String s = PrintSessionPrinter.ChoosePrinter(this.ParentForm);
            if (PrintSessionPrinter.PrinterExists(s))
            {
                abs_printer_name = s;
                PrinterName = s;
                ShowPrintPreview();
            }
        }

        private delegate void PreviewFinished();

        private void PrintPreview_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public void DoResize()
        {
            try
            {
                wb.Width = this.ClientRectangle.Width - wb.Left;
                wb.Height = this.ClientRectangle.Height - wb.Top;
                RT.Width = wb.Width;
                RT.Height = wb.Height;
                RT.Top = wb.Top;
                RT.Left = wb.Left;
                tsPreview.Top = 0;
                tsPreview.Width = this.ClientRectangle.Width - tsPreview.Left;
                tsPreview.Height = this.ClientRectangle.Height;
            }
            catch (Exception)
            {

            }

        }

        private void chkDisablePreview_CheckedChanged(object sender, EventArgs e)
        {
            RzWin.User.SetSetting_Boolean(RzWin.Context, "disable_preview", chkDisablePreview.Checked);
            if (!chkDisablePreview.Checked)
                ShowPreview();
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            //PrintPreviewDialog dialog = new PrintPreviewDialog();
            //printheader p = (printheader)lv.GetSelectedObject();
            //PrintHeaderDocument d = new PrintHeaderDocument(RzWin.Context, p, CurrentObject);
            //dialog.Document = d;
            //dialog.Width = 800;
            //dialog.Height = 600;

            //// show the dialog...
            //dialog.ShowDialog();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            if (CurrentParameters.PrintTemplate != null)
            {
                CurrentParameters.PrintTemplate.scale_multiplier = Convert.ToDouble(numx.Value);
                CurrentParameters.PrintTemplate.Update(RzWin.Context);
            }
        }

        bool inhibit = false;
        private void opt_CheckedChanged(object sender, EventArgs e)
        {
            if (inhibit)
                return;

            if (optPrint.Checked)
                CurrentParameters.type = Enums.TransmitType.Print;
            else if (optFax.Checked)
                CurrentParameters.type = Enums.TransmitType.Fax;
            else if (optEmail.Checked)
                CurrentParameters.type = Enums.TransmitType.Email;
            else if (optPDF.Checked)
                CurrentParameters.type = Enums.TransmitType.PDF;
            chkIncludePDF.Visible = optEmail.Checked && RzWin.Context.xUser.IsDeveloper();
            Refresh();
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            HandleCommand("Print");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            RzWin.Form.TabTopClose();
        }

        public void GoDisable()
        {
            cmdGo.Enabled = false;
        }



    }
}
