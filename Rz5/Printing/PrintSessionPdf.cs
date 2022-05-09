using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading;
using System.Globalization;
using System.IO;

using Core;
using NewMethod;

namespace Rz5
{
    public class PrintSessionPdf : PrintSession
    {
        Tools.PDFWrapper pdf;
        public PrintSessionPdf(ContextRz context, printheader printHeader, nObject xObject)
            : base(context, printHeader, xObject)
        {

        }

        public override void Print()
        {
            base.Print();
            RenderPdfFile(true, "Pdf" + Tools.Dates.GetNowPathHMS());
        }

        public String Print(bool consolidateLines, String fileNameBase, String fileNameToSave = "")
        {
            base.Print();
            return RenderPdfFile(consolidateLines, fileNameBase, fileNameToSave);
        }

        private String RenderPdfFile(bool consolidateLines, String fileNameBase, String fileNameToSave = "")
        {
            base.Print();
            try
            {
                string AutosaveDirectory = Tools.Folder.ConditionFolderName(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                if (!Directory.Exists(AutosaveDirectory) || AutosaveDirectory.Length < 4)
                    AutosaveDirectory = @"c:\Bilge\";  //this happens on web servers
                string pdf_file = AutosaveDirectory + fileNameBase + ".pdf";
                if (Tools.Strings.StrExt(fileNameToSave))
                    pdf_file = fileNameToSave;
                string alt_pdf = AutosaveDirectory + Tools.Strings.GetNewID() + ".pdf";
                if (Tools.Files.FileExists(pdf_file))
                    Tools.Files.TryDeleteFile(pdf_file);
                pdf = new Tools.PDFWrapper(alt_pdf, PrintHeader.is_landscape);
                CurrentGraphics = pdf;
                ConsolidateLines = consolidateLines;
                if (PrintHeader.is_landscape)
                    PrintOnGraphics(TheContext, 1100, 850);
                else
                    PrintOnGraphics(TheContext, 850, 1100);

                pdf.CloseDoc();
                if (CurrentObject is ordhed)
                    pdf_file = GetPDFFile(TheContext, alt_pdf, pdf_file, ((ordhed)CurrentObject).OrderType);
                else
                    pdf_file = RenameFile(alt_pdf, pdf_file);
                return pdf_file;
            }
            catch (Exception ex)
            {
                TheContext.TheLeader.Error(ex);
                return "";
            }
        }

        protected override void RollNewPage(Font f)
        {
            base.RollNewPage(f);
            pdf.NewPage();
        }

        private string GetPDFFile(ContextRz context, string file, string ret_file, Enums.OrderType t)
        {
            try
            {
                //if (p == null)
                //    return RenameFile(file, ret_file);

                string id = context.SelectScalarString("select unique_id from filelink where linkname = 'pdfterms_" + t.ToString() + "' and objectclass = 'pdf' and linktype = 'pdf_terms' and objectid = '" + PrintHeader.unique_id + "'");
                if (!Tools.Strings.StrExt(id))
                    return RenameFile(file, ret_file);

                filelink f = filelink.GetById(context, id);
                if (f == null)
                    return RenameFile(file, ret_file);

                f.LoadPictureData(context);
                string file2 = f.SaveDataAsFile();
                string[] sourceFiles = Tools.Strings.Split(file + "|" + file2, "|");
                return PDFBuilder.PDFBuilder.MergeFiles(context, sourceFiles, ret_file);
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("GetPDFFile Error: " + ex.Message);
                return RenameFile(file, ret_file);
            }
        }

        private string RenameFile(string orig, string rename)
        {
            try
            {
                if (File.Exists(rename))
                    File.Delete(rename);
                File.Copy(orig, rename);
                return rename;
            }
            catch { }
            return orig;
        }

    }
}
