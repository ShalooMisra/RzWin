/*
 * HtmlToPdfBuilder.cs (for .NET 2.0)
 * ---------------------------------
 * Hugo Bonacci (webdev_hb@yahoo.com)
 * www.hugoware.net
 */

using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Collections;
using iTextSharp.text.html;
using System.Text.RegularExpressions;

using NewMethod;
using Rz5;

namespace PDFBuilder
{
    public class PDFBuilder
    {
        public static string MergeFiles(ContextRz context, string[] sourceFiles, string ret_file)
        {
            try
            {
                int f = 0;
                PdfReader reader = new PdfReader(sourceFiles[f]);
                int n = reader.NumberOfPages;
                Console.WriteLine("There are " + n + " pages in the original file.");
                Document document = new Document(reader.GetPageSizeWithRotation(1));
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(ret_file, FileMode.Create));
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;
                int rotation;
                while (f < sourceFiles.Length)
                {
                    int i = 0;
                    while (i < n)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        page = writer.GetImportedPage(reader, i);
                        rotation = reader.GetPageRotation(i);
                        if (rotation == 90 || rotation == 270)
                            cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        else
                            cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        Console.WriteLine("Processed page " + i);
                    }
                    f++;
                    if (f < sourceFiles.Length)
                    {
                        reader = new PdfReader(sourceFiles[f]);
                        n = reader.NumberOfPages;
                        Console.WriteLine("There are " + n + " pages in the original file.");
                    }
                }
                document.Close();
                return ret_file;
            }
            catch (Exception eee)
            { context.TheLeader.Tell("MergeFiles Error: " + eee.Message); }
            return "";
        }
    }

    #region HtmlToPdfBuilder Class

    /// <summary>
    /// Simplifies generating HTML into a PDF file
    /// </summary>
    public class HtmlToPdfBuilder
    {
        public static string GetPDFFromHTML(ContextRz context, string html, string name)
        {
            string file_name = Tools.Folder.ConditionFolderName(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + name + ".pdf";
            Tools.Files.TryDeleteFile(file_name);
            HtmlToPdfBuilder builder = new HtmlToPdfBuilder(iTextSharp.text.PageSize.LETTER);
            HtmlPdfPage first = builder.AddPage();
            first.AppendHtml(html);
            byte[] file = builder.RenderPdf(context);
            File.WriteAllBytes(file_name, file);
            return file_name;
        }

        #region Constants

        private const string STYLE_DEFAULT_TYPE = "style";
        private const string DOCUMENT_HTML_START = "<html><head></head><body>";
        private const string DOCUMENT_HTML_END = "</body></html>";
        private const string REGEX_GROUP_SELECTOR = "selector";
        private const string REGEX_GROUP_STYLE = "style";

        //amazing regular expression magic
        private const string REGEX_GET_STYLES = @"(?<selector>[^\{\s]+\w+(\s\[^\{\s]+)?)\s?\{(?<style>[^\}]*)\}";

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new PDF document template. Use PageSizes.{DocumentSize}
        /// </summary>
        public HtmlToPdfBuilder(Rectangle size)
        {
            this.PageSize = size;
            this._Pages = new List<HtmlPdfPage>();
            this._Styles = new StyleSheet();
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Method to override to have additional control over the document
        /// </summary>
        public event RenderEvent BeforeRender;

        /// <summary>
        /// Method to override to have additional control over the document
        /// </summary>
        public event RenderEvent AfterRender;

        #endregion

        #region Properties

        /// <summary>
        /// The page size to make this document
        /// </summary>
        public Rectangle PageSize { get; set; }

        /// <summary>
        /// Returns the page at the specified index
        /// </summary>
        public HtmlPdfPage this[int index]
        {
            get
            {
                return this._Pages[index];
            }
        }

        /// <summary>
        /// Returns a list of the pages available
        /// </summary>
        public HtmlPdfPage[] Pages
        {
            get
            {
                return this._Pages.ToArray();
            }
        }

        #endregion

        #region Members

        private List<HtmlPdfPage> _Pages;
        private StyleSheet _Styles;

        #endregion

        #region Working With The Document

        /// <summary>
        /// Appends and returns a new page for this document
        /// </summary>
        public HtmlPdfPage AddPage()
        {
            HtmlPdfPage page = new HtmlPdfPage();
            this._Pages.Add(page);
            return page;
        }

        /// <summary>
        /// Removes the page from the document
        /// </summary>
        public void RemovePage(HtmlPdfPage page)
        {
            this._Pages.Remove(page);
        }

        /// <summary>
        /// Appends a style for this sheet
        /// </summary>
        public void AddStyle(string selector, string styles)
        {
            this._Styles.LoadTagStyle(selector, HtmlToPdfBuilder.STYLE_DEFAULT_TYPE, styles);
        }

        /// <summary>
        /// Imports a stylesheet into the document
        /// </summary>
        public void ImportStylesheet(string path)
        {

            //load the file
            string content = File.ReadAllText(path);

            //use a little regular expression magic
            foreach (Match match in Regex.Matches(content, HtmlToPdfBuilder.REGEX_GET_STYLES))
            {
                string selector = match.Groups[HtmlToPdfBuilder.REGEX_GROUP_SELECTOR].Value;
                string style = match.Groups[HtmlToPdfBuilder.REGEX_GROUP_STYLE].Value;
                this.AddStyle(selector, style);
            }

        }


        #endregion

        #region Document Navigation

        /// <summary>
        /// Moves a page before another
        /// </summary>
        public void InsertBefore(HtmlPdfPage page, HtmlPdfPage before)
        {
            this._Pages.Remove(page);
            this._Pages.Insert(
                Math.Max(this._Pages.IndexOf(before), 0),
                page);
        }

        /// <summary>
        /// Moves a page after another
        /// </summary>
        public void InsertAfter(HtmlPdfPage page, HtmlPdfPage after)
        {
            this._Pages.Remove(page);
            this._Pages.Insert(
                Math.Min(this._Pages.IndexOf(after) + 1, this._Pages.Count),
                page);
        }


        #endregion

        #region Rendering The Document

        /// <summary>
        /// Renders the PDF to an array of bytes
        /// </summary>
        public byte[] RenderPdf(ContextRz context)
        {

            //Document is inbuilt class, available in iTextSharp
            MemoryStream file = new MemoryStream();
            Document document = new Document(this.PageSize);
            PdfWriter writer = PdfWriter.GetInstance(document, file);

            //allow modifications of the document
            if (this.BeforeRender is RenderEvent)
            {
                this.BeforeRender(writer, document);
            }

            //header
            //document.Add(new Header(Markup.HTML_ATTR_STYLESHEET, string.Empty));
            document.Add(new Header("", string.Empty));
            document.Open();
            try
            {
                //render each page that has been added
                foreach (HtmlPdfPage page in this._Pages)
                {
                    document.NewPage();

                    //generate this page of text
                    MemoryStream output = new MemoryStream();
                    StreamWriter html = new StreamWriter(output, Encoding.UTF8);

                    //get the page output
                    html.Write(string.Concat(HtmlToPdfBuilder.DOCUMENT_HTML_START, page._Html.ToString(), HtmlToPdfBuilder.DOCUMENT_HTML_END));
                    html.Close();
                    html.Dispose();

                    //read the created stream
                    MemoryStream generate = new MemoryStream(output.ToArray());
                    StreamReader reader = new StreamReader(generate);
                    foreach (object item in HTMLWorker.ParseToList(reader, this._Styles))
                    {
                        document.Add((IElement)item);
                    }

                    //cleanup these streams
                    html.Dispose();
                    reader.Dispose();
                    output.Dispose();
                    generate.Dispose();

                }
            }
            catch (Exception ee)
            {
                context.TheLeader.Tell("PDFBuilder Error: " + ee.Message);
            }
            //after rendering
            if (this.AfterRender is RenderEvent)
            {
                this.AfterRender(writer, document);
            }

            //return the rendered PDF
            document.Close();
            return file.ToArray();

        }

        #endregion

    }

    #endregion

    #region HtmlPdfPage Class

    /// <summary>
    /// A page to insert into a HtmlToPdfBuilder Class
    /// </summary>
    public class HtmlPdfPage
    {

        #region Constructors

        /// <summary>
        /// The default information for this page
        /// </summary>
        public HtmlPdfPage()
        {
            this._Html = new StringBuilder();
        }

        #endregion

        #region Fields

        //parts for generating the page
        internal StringBuilder _Html;

        #endregion

        #region Working With The Html

        /// <summary>
        /// Appends the formatted HTML onto a page
        /// </summary>
        public virtual void AppendHtml(string content, params object[] values)
        {
            this._Html.AppendFormat(content, values);
        }

        #endregion

    }

    #endregion

    #region Rendering Delegate

    /// <summary>
    /// Delegate for rendering events
    /// </summary>
    public delegate void RenderEvent(PdfWriter writer, Document document);

    #endregion

}
