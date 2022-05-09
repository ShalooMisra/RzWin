using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using NewMethod;


namespace Rz5
{
    public delegate void PreviewClickHandler(int width_pct, int height_pct);
    public partial class frmPrintedFormsPreview : Form
    {
        //Public Events
        public event PreviewClickHandler PreviewClick;
        public event PreviewBoxHandler PreviewBox;
        //Public Variables
        public printheader xHeader;
        public Boolean bPictureLoaded = false;
        //Private Variables
        //private n_sys xSys;
        private nObject xObject;
        public PrintSessionImages PreviewSession;
        public int PreviewImageHeight = 0;
        public int PreviewImageWidth = 0;
        private Dictionary<string, printheader> dDesigners;
        private Object xFromObject;
        private Boolean bClosing = false;
        private Boolean bSettingActive = false;
        //Private Delegates
        private delegate void FinishPreviewHandler();

        //Constructors
        public frmPrintedFormsPreview()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(Object parent)
        {
            xFromObject = parent;
            if (xFromObject == null)
                xFromObject = designer;
            dDesigners = new Dictionary<string, printheader>();
            DoResize();
        }
        public void Init(printheader print_header)
        {
            xFromObject = designer;
            dDesigners = new Dictionary<string, printheader>();

            designer.PreviewFormSet(this);
            designer.CompleteLoad(this);
            designer.SetDesignerControlObject(print_header);
            RefreshDesigner(false);

            DoResize();
        }
        public void DoResize()
        {
            //this.WindowState = FormWindowState.Maximized;
            ts.Top = 0;
            ts.Left = 0;
            ts.Width = this.ClientRectangle.Width;
            ts.Height = 25;
            Preview.Top = ts.Bottom;
            Preview.Left = 0;
            Preview.Width = this.ClientRectangle.Width;
            Preview.Height = this.ClientRectangle.Height - (ts.Height + designer.Height);
            Preview.DoAltResize();
            cmdClose.Top = ts.Bottom;
            cmdClose.Left = Preview.Right - (cmdClose.Width + 16);
            cmdPrint.Top = cmdClose.Top;
            cmdPrint.Left = cmdClose.Left - (cmdPrint.Width - 1);
            cmdRefresh.Top = cmdClose.Top;
            cmdRefresh.Left = cmdPrint.Left - (cmdRefresh.Width - 1);
            designer.Left = 0;
            designer.Top = this.ClientRectangle.Height - designer.Height;
        }
        public void ShowDesignerTab(printheader header)
        {
            ShowDesignerTab(header, null);
        }
        public void ShowDesignerTab(printheader header, nObject x)
        {
            try
            {
                if (header != null)
                {
                    if (!dDesigners.ContainsKey(header.unique_id))
                        dDesigners.Add(header.unique_id, header);
                    xHeader = header;
                }
                if (xHeader == null)
                    return;
                bSettingActive = true;
                SetActiveTab();
                bSettingActive = false;
                if (xObject == null)
                {
                    if (x == null)
                        SampleSet();
                    else
                        xObject = x;
                }
                SetPreview(xHeader, xObject);
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell(ex.Message);
            }
        }
        public void PrintPreview()
        {
            if (xHeader != null)
            {
                SampleSet();
                PrintSessionPrinter print = new PrintSessionPrinter(RzWin.Context, xHeader, xObject);
                print.Print(xHeader.printername, 1, false, true);
            }
        }
        public void CloseDesigner(printheader header)
        {
            if (header == null)
                return;
            try
            {
                dDesigners.Remove(header.unique_id);
                if (ts.TabPages.Count <= 1)
                {
                    SendCloseDesigners();
                    return;
                }
                ts.TabPages.RemoveAt(ts.TabPages.IndexOfKey(header.unique_id));
                ts.SelectedTab = ts.TabPages[0];
            }
            catch
            { }
        }
        public void RefreshDesigner(Boolean bUpdateControls)
        {
            if (!bSettingActive)
            {
                String id = ts.SelectedTab.Tag.ToString();
                printheader p = printheader.GetById(RzWin.Context, id);
                if (p != null)
                {
                    if (bUpdateControls)
                        UpdateControlPanel(p);
                    ShowDesignerTab(p);
                }
            }
        }
        public void RefreshDesigner(printheader p, Boolean bUpdateControls)
        {
            if (!bSettingActive)
            {
                if (p != null)
                {
                    if (bUpdateControls)
                        UpdateControlPanel(p);
                    ShowDesignerTab(p);
                }
            }
        }
        //Private Functions
        private void RefreshView()
        {
            try
            {
                if (bg.IsBusy)
                    return;
                PreviewImageWidth = Preview.GetPG().ClientRectangle.Width;
                PreviewImageHeight = Preview.GetPG().ClientRectangle.Height;
                bg.RunWorkerAsync();
            }
            catch (Exception)
            { }
        }
        private ordhed SampleOrder()
        {
            String type;
            if (xHeader == null)
                type = "invoice";
            else
                type = xHeader.ordertype;

            if (!Tools.Strings.StrExt(type))
                type = "invoice";

            ordhed order = (ordhed)RzWin.Context.QtO("ordhed_" + type, "select top 1 * from ordhed_" + type + " order by orderdate desc");
            if (order == null)
            {
                order = ordhed.New(RzWin.Context);
                order.OrderType = Enums.OrderType.Sales;
            }
            return order;
        }
        private void SetPreview(printheader header, nObject x)
        {
            xHeader = header;
            xObject = x;
            if (xHeader == null)
                return;
            try
            {
                //if (Tools.Strings.StrExt(header.printername) && Tools.OperatingSystem.PrinterIsValid(header.printername))
                //    Preview.Init(header.printername, header.is_landscape);
                //else
                Preview.Init(PrintSessionPrinter.GetCurrentPrinter(), header.is_landscape);
                RefreshView();
            }
            catch (Exception)
            { }
        }
        private Boolean SetActiveTab()
        {
            try
            {
                Boolean bSet = false;
                if (xHeader != null)
                {
                    if (!ts.TabPages.ContainsKey(xHeader.unique_id))
                    {
                        ts.TabPages.Add(xHeader.unique_id, xHeader.Name.Replace("Print Template", "").Trim());
                        ts.TabPages[ts.TabPages.IndexOfKey(xHeader.unique_id)].Tag = xHeader.unique_id;
                    }
                    ts.SelectedIndex = ts.TabPages.IndexOfKey(xHeader.unique_id);
                    bSet = true;
                }
                return bSet;
            }
            catch (Exception)
            { return false; }
        }
        private void UpdateControlPanel(printheader p)
        {
            try
            {
                switch (xFromObject.GetType().ToString())
                {
                    case "PrintedForms":
                        bClosing = true;
                        ((PrintedForms)xFromObject).frmControls.SetDesignerControlObject(p);
                        break;
                }
            }
            catch (Exception)
            { }
        }
        private void SendCloseDesigners()
        {
            try
            {
                switch (xFromObject.GetType().ToString())
                {
                    case "PrintedForms":
                        bClosing = true;
                        ((PrintedForms)xFromObject).CloseDesigners();
                        break;
                }
            }
            catch (Exception)
            { }
        }
        private void SampleSet()
        {
            if (Tools.Strings.StrExt(xHeader.class_name))
            {
                xObject = (nObject)RzWin.Context.QtO(xHeader.class_name, "select top 1 * from " + xHeader.class_name);
            }
            else
            {
                xObject = SampleOrder();
            }
        }
        private void FinishPreview()
        {
            try
            {
                Preview.DoAltResize();
                Preview.SetBitmap(PreviewSession.Images[0]);
                bPictureLoaded = true;
            }
            catch { }
        }
        //Buttons
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshDesigner(false);
        }
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            PrintPreview();
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (xHeader != null)
                CloseDesigner(xHeader);
        }
        //Control Events
        private void frmPrintedFormsPreview_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void frmPrintedFormsPreview_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDesigner(true);
        }
        //Background Workers
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bPictureLoaded = false;
                if (PreviewSession != null)
                {
                    PreviewSession.Dispose();
                    PreviewSession = null;
                }
                PreviewSession = new PrintSessionImages(RzWin.Context, xHeader, xObject, PreviewImageWidth, PreviewImageHeight);
                PreviewSession.Print();
            }
            catch
            { }
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.Invoke(new FinishPreviewHandler(FinishPreview));
            }
            catch { }
        }
        //Events Handlers       
        private void Preview_PreviewClick(int width_pct, int height_pct)
        {
            if (PreviewClick != null)
                PreviewClick(width_pct, height_pct);
        }
        private void Preview_PreviewBox(int x_pct, int y_pct, int x2_pct, int y2_pct)
        {
            if (PreviewBox != null)
                PreviewBox(x_pct, y_pct, x2_pct, y2_pct);
        }

        private void designer_Load(object sender, EventArgs e)
        {

        }
    }
}