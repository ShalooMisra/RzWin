using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class PrintedForms : UserControl, ICompleteLoad
    {
        public SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.xSys;
            }
        }

        public DesignOptions frmControls;
        public frmPrintedFormsPreview frmPreview;

        public PrintedForms()
        {
            InitializeComponent();
        }
        public void CompleteLoad()
        {
            LV.ShowTemplate("all_printheaders", "printheader");
            LV.ShowData("printheader", "", "printtag");
            DoResize();
        }
        public void DoResize()
        {
            gbCommands.Top = this.Height - (gbCommands.Height + 3);
            gbCommands.Width = this.Width - (gbCommands.Left * 2);
            LV.Top = 0;
            LV.Left = 0;
            LV.Width = this.Width;
            LV.Height = gbCommands.Top;
            Int32 margin = 5;
            cmdNew.Left = margin;
            Int32 width = (gbCommands.Width - (margin * 5)) / 4;
            cmdNew.Width = width;
            cmdExport.Width = width;
            cmdDelete.Width = width;
            cmdImport.Width = width;
            cmdDelete.Left = cmdNew.Right + margin;
            cmdImport.Left = cmdDelete.Right + margin;
            cmdExport.Left = cmdImport.Right + margin; 
        }
        //Public Functions
        public void ThrowTemplateDesigner(String ID)
        {
            try
            {
                printheader p = printheader.GetById(RzWin.Context, ID);
                if (p == null)
                {
                    RzWin.Leader.Tell("This order template could not be found.");
                    return;
                }
                //if (frmControls == null)
                //    ShowDesignerControls();
                //frmControls.ShowDesignerTab(p);

                frmPrintedFormsPreview pfp = new frmPrintedFormsPreview();
                pfp.WindowState = FormWindowState.Maximized;
                pfp.Show();
                pfp.Init(p);

            }
            catch (Exception)
            { }
        }
        public void CloseDesigners()
        {
            //if (frmControls != null)
            //    frmControls.Close();
            if (frmPreview != null)
                frmPreview.Close();
            frmControls = null;
            frmPreview = null;
        }
        //Private Functions
        private void ShowDesignerControls()
        {
            //frmControls = new frmPrintedFormsDesigner();
            //frmControls.CompleteLoad(xSys, this);
            ////frmControls.TopMost = true;  //this made designing really hard, especially editing columns
            //frmControls.FormBorderStyle = FormBorderStyle.FixedSingle;
            //frmControls.MaximizeBox = false;
            ////frmControls.ShowInTaskbar = false; 
            //frmControls.Top = Screen.PrimaryScreen.WorkingArea.Height - frmControls.Height;
            //frmControls.Left = 0;
            //frmControls.Show();



        }
        private void CreateNewTemplate()
        {
            String template = RzWin.Leader.AskForString("Please enter a name for the new template.", "", "New Template Name");
            if (!Tools.Strings.StrExt(template))
                return;
            printheader p = printheader.New(RzWin.Context);
            p.printname = template;
            p.Insert(RzWin.Context);
        }
        private void DeleteSelectedTemplates()
        {
            if (!RzWin.Leader.AskYesNo("You are about to delete all selected templates. Ok to continue?"))
                return;
            ArrayList a = LV.GetSelectedObjects();
            foreach (printheader p in a)
            {
                String id = p.unique_id;
                p.Delete(RzWin.Context);
                String SQL = "delete from printdetail where base_printheader_uid = '" + id + "'";
                RzWin.Context.Execute(SQL);
            }
        }
        private void ImportTemplateFromFile()
        {
            try
            {
                oFile.Multiselect = true;
                DialogResult dr = oFile.ShowDialog();
                if (dr.Equals(DialogResult.Cancel))
                    return;
                String[] filenames = oFile.FileNames;

                if (filenames == null)
                    return;

                if (filenames.Length == 0)
                    return;

                foreach (String filename in filenames)
                {
                    if (!System.IO.File.Exists(filename))
                    {
                        RzWin.Leader.Tell("The file " + filename + " does not appear to exist. Please recheck the file name and try asgain.");
                        return;
                    }
                    String template = RzWin.Leader.AskForString("Please enter a name for this template import.", Path.GetFileNameWithoutExtension(filename) , "New Template Name");
                    if (!Tools.Strings.StrExt(template))
                        return;
                    String[] file = Tools.Strings.Split(Tools.Files.OpenFileAsString(filename), "|~|");
                    printheader pheader = null;
                    n_template xt = null;
                    foreach (String str in file)
                    {
                        if (str.Trim().ToLower().StartsWith("header"))
                        {
                            pheader = GetHeader(str);
                            if (pheader == null)
                            {
                                RzWin.Leader.Tell("There was an error locating the header record. Please try a different export.");
                                return;
                            }
                            pheader.printname = template;
                            pheader.Insert(RzWin.Context);

                            xt = n_template.New(RzWin.Context);
                            xt.template_name = pheader.GetTemplateName();
                            xt.Insert(RzWin.Context);

                            continue;
                        }
                        if (pheader == null)
                        {
                            RzWin.Leader.Tell("There was an error locating the header record. Please try a different export.");
                            return;
                        }

                        if (str.Trim().ToLower().StartsWith("detail"))
                        {
                            printdetail d = printdetail.New(RzWin.Context);
                            String[] peices = Tools.Strings.Split(str, "\t");
                            try { d.startx = Convert.ToInt32(peices[1].Trim()); }
                            catch { d.startx = 0; }
                            try { d.starty = Convert.ToInt32(peices[2].Trim()); }
                            catch { d.starty = 0; }
                            try { d.stopx = Convert.ToInt32(peices[3].Trim()); }
                            catch { d.stopx = 0; }
                            try { d.stopy = Convert.ToInt32(peices[4].Trim()); }
                            catch { d.stopy = 0; }
                            try { d.fontname = peices[5].Trim(); }
                            catch { d.fontname = ""; }
                            try { d.textstring = peices[6].Trim(); }
                            catch { d.textstring = ""; }
                            try { d.filename = peices[7].Trim(); }
                            catch { d.filename = ""; }
                            try { d.centerx1 = Convert.ToInt32(peices[8].Trim()); }
                            catch { d.centerx1 = 0; }
                            try { d.centerx2 = Convert.ToInt32(peices[9].Trim()); }
                            catch { d.centerx2 = 0; }
                            try { d.fontbold = Convert.ToBoolean(peices[10].Trim()); }
                            catch { d.fontbold = false; }
                            try { d.fontitalic = Convert.ToInt32(peices[11].Trim()); }
                            catch { d.fontitalic = 0; }
                            try { d.fontcolor = Convert.ToInt64(peices[12].Trim()); }
                            catch { d.fontcolor = 0; }
                            try { d.detailtype = peices[13].Trim(); }
                            catch { d.detailtype = ""; }
                            try { d.drawwidth = Convert.ToInt32(peices[14].Trim()); }
                            catch { d.drawwidth = 0; }
                            try { d.detailname = peices[15].Trim(); }
                            catch { d.detailname = ""; }
                            try { d.fontsize = Convert.ToInt32(peices[16].Trim()); }
                            catch { d.fontsize = 10; }
                            try { d.style_info = peices[17].Trim(); }
                            catch { d.style_info = ""; }
                            d.base_printheader_uid = pheader.unique_id;
                            d.Insert(RzWin.Context);
                        }
                        else if (str.Trim().ToLower().StartsWith("column"))
                        {
                            n_column c = n_column.New(RzWin.Context);

                            //n_column c = (n_column)de.Value;
                            //sb.Append("COLUMN\t");
                            //sb.Append(c.name + "\t");
                            //sb.Append(c.field_name + "\t");
                            //sb.Append(c.column_alignment.ToString() + "\t");
                            //sb.Append(c.column_caption + "\t");
                            //sb.Append(c.column_format + "\t");
                            //sb.Append(c.column_order.ToString() + "\t");
                            //sb.Append(c.column_width.ToString() + "\t");
                            //sb.Append(c.data_type.ToString() + "\t|~|");

                            String[] peices = Tools.Strings.Split(str, "\t");

                            try { c.name = peices[1].Trim(); }
                            catch { c.name = ""; }
                            try { c.field_name = peices[2].Trim(); }
                            catch { c.field_name = ""; }
                            try { c.column_alignment = Convert.ToInt32(peices[3].Trim()); }
                            catch { c.column_alignment = 0; }
                            try { c.column_caption = peices[4].Trim(); }
                            catch { c.column_caption = ""; }
                            try { c.column_format = peices[5].Trim(); }
                            catch { c.column_format = ""; }
                            try { c.column_order = Convert.ToInt32(peices[6].Trim()); }
                            catch { c.column_order = 0; }
                            try { c.column_width = Convert.ToInt32(peices[7].Trim()); }
                            catch { c.column_width = 0; }
                            try { c.data_type = Convert.ToInt32(peices[8].Trim()); }
                            catch { c.data_type = 0; }

                            c.the_n_template_uid = xt.unique_id;
                            c.Insert(RzWin.Context);

                        }
                    }
                }
            }
            catch
            { }
        }

        private void ExportTemplateToFile()
        {
            String folder = ToolsWin.FileSystem.ChooseAFolder();
            if (!Directory.Exists(folder))
                return;

            RzWin.Leader.StartPopStatus("Exporting ...");
            foreach (printheader h in LV.GetSelectedObjects())
            {
                ExportTemplateToFile(h, Tools.Folder.ConditionFolderName(folder));
            }
            RzWin.Leader.Comment("Done.");
            RzWin.Leader.StopPopStatus(true);
        }

        private void ExportTemplateToFile(printheader header, String folder)
        {
            try
            {
                if (header == null)
                    return;
                StringBuilder sb = new StringBuilder();
                sb.Append("HEADER\t");
                sb.Append(header.printname + "\t");
                sb.Append(header.printtag + "\t");
                sb.Append(header.printdescription + "\t");
                sb.Append(header.ordertype + "\t");
                sb.Append(header.printername + "\t");
                sb.Append(header.copycount.ToString() + "\t");
                sb.Append(header.colhedfont + "\t");
                sb.Append(header.colhedfontsize.ToString() + "\t");
                sb.Append(header.colhedfontbold.ToString() + "\t");
                sb.Append(header.colhedfontitalic.ToString() + "\t");
                sb.Append(header.printpoinfo.ToString() + "\t");
                sb.Append(header.riderdata + "\t");
                sb.Append(header.is_landscape.ToString() + "\t");
                sb.Append(header.base_mc_user_uid + "\t");
                sb.Append(header.width_index.ToString() + "\t");
                sb.Append(header.height_index.ToString() + "\t");
                sb.Append(header.new_format.ToString() + "\t");
                sb.Append(header.paper_size + "\t");
                sb.Append(header.scale_multiplier.ToString() + "\t|~|");
                ArrayList a = RzWin.Context.QtC("printdetail", "select * from printdetail where base_printheader_uid = '" + header.unique_id + "'");
                foreach (printdetail d in a)
                {
                    sb.Append("DETAIL\t");
                    sb.Append(d.startx.ToString() + "\t");
                    sb.Append(d.starty.ToString() + "\t");
                    sb.Append(d.stopx.ToString() + "\t");
                    sb.Append(d.stopy.ToString() + "\t");
                    sb.Append(d.fontname + "\t");
                    sb.Append(d.textstring + "\t");
                    sb.Append(d.filename + "\t");
                    sb.Append(d.centerx1.ToString() + "\t");
                    sb.Append(d.centerx2.ToString() + "\t");
                    sb.Append(d.fontbold.ToString() + "\t");
                    sb.Append(d.fontitalic.ToString() + "\t");
                    sb.Append(d.fontcolor.ToString() + "\t");
                    sb.Append(d.detailtype + "\t");
                    sb.Append(d.drawwidth.ToString() + "\t");
                    sb.Append(d.detailname + "\t");
                    sb.Append(d.fontsize.ToString() + "\t");
                    sb.Append(d.style_info + "\t|~|");
                }

                //the template
                n_template template = n_template.GetByName(RzWin.Context, header.GetTemplateName());
                if (template != null)
                {
                    template.GatherColumns(RzWin.Context);
                    foreach (DictionaryEntry de in template.AllColumns)
                    {
                        n_column c = (n_column)de.Value;
                        sb.Append("COLUMN\t");
                        sb.Append(c.name + "\t");
                        sb.Append(c.field_name + "\t");
                        sb.Append(c.column_alignment.ToString() + "\t");
                        sb.Append(c.column_caption + "\t");
                        sb.Append(c.column_format + "\t");
                        sb.Append(c.column_order.ToString() + "\t");
                        sb.Append(c.column_width.ToString() + "\t");
                        sb.Append(c.data_type.ToString() + "\t|~|");
                    }
                }

                String fname = folder + header.printname + ".txt";

                if (Tools.Files.SaveFileAsString(fname, sb.ToString()))
                {
                    RzWin.Leader.Comment(fname + " was created.");

                }
                else
                    RzWin.Leader.Tell(fname + " failed to be created.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Tell("The file failed to be created.\r\n" + ee.Message);
            }
        }
        private printheader GetHeader(String header)
        {
            try
            {
                printheader p = printheader.New(RzWin.Context);
                String[] peices = Tools.Strings.Split(header, "\t");
                try { p.printname = peices[1].Trim(); }
                catch { p.printname = ""; }
                try { p.printtag = peices[2].Trim(); }
                catch { p.printtag = ""; }
                try { p.printdescription = peices[3].Trim(); }
                catch { p.printdescription = ""; }
                try { p.ordertype = peices[4].Trim(); }
                catch { p.ordertype = ""; }
                try { p.printername = peices[5].Trim(); }
                catch { p.printername = ""; }
                try { p.copycount = Convert.ToInt32(peices[6].Trim()); }
                catch { p.copycount = 1; }
                try { p.colhedfont = peices[7].Trim(); }
                catch { p.colhedfont = ""; }
                try { p.colhedfontsize = Convert.ToInt32(peices[8].Trim()); }
                catch { p.colhedfontsize = 12; }
                try { p.colhedfontbold = Convert.ToBoolean(peices[9].Trim()); }
                catch { p.colhedfontbold = false; }
                try { p.colhedfontitalic = Convert.ToBoolean(peices[10].Trim()); }
                catch { p.colhedfontitalic = false; }
                try { p.printpoinfo = Convert.ToBoolean(peices[11].Trim()); }
                catch { p.printpoinfo = false; }
                try { p.riderdata = peices[12].Trim(); }
                catch { p.riderdata = ""; }
                try { p.is_landscape = Convert.ToBoolean(peices[13].Trim()); }
                catch { p.is_landscape = false; }
                try { p.base_mc_user_uid = peices[14].Trim(); }
                catch { p.base_mc_user_uid = ""; }
                try { p.width_index = Convert.ToInt32(peices[15].Trim()); }
                catch { p.width_index = 0; }
                try { p.height_index = Convert.ToInt32(peices[16].Trim()); }
                catch { p.height_index = 0; }
                try { p.new_format = Convert.ToBoolean(peices[17].Trim()); }
                catch { p.new_format = false; }
                try { p.paper_size = peices[18].Trim(); }
                catch { p.paper_size = ""; }
                return p;
            }
            catch (Exception)
            { return null; }
        }
        //Buttons
        private void cmdNew_Click(object sender, EventArgs e)
        {
            CreateNewTemplate();
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedTemplates();
        }
        private void cmdImport_Click(object sender, EventArgs e)
        {
            ImportTemplateFromFile();
        }
        private void cmdExport_Click(object sender, EventArgs e)
        {
            ExportTemplateToFile();
        }
        //Control Events
        private void PrintedForms_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void LV_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
            ThrowTemplateDesigner(args.TheItems.ItemIdFirstGet(RzWin.Context));
        }
    }
}
