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
using Tools.Database;

namespace Rz5
{
    public partial class printheader : printheader_auto 
    {
        //Public Variables
        public ArrayList AllDetails(ContextRz context)
        {
            if (m_AllDetails == null)
                GatherDetails(context);
            return m_AllDetails;
        }

        public void AllDetails(ArrayList value)
        {
            m_AllDetails = value;
        }

        public printdetail DetailAdd(ContextRz context, String type)
        {
            printdetail yDetail = printdetail.New(context);
            yDetail.base_printheader_uid = unique_id;
            yDetail.detailtype = type;
            yDetail.detailname = GetNewDetailName(type);
            yDetail.startx = 2500;
            yDetail.stopx = 3000;
            yDetail.starty = 100;
            yDetail.stopy = 300;
            yDetail.Insert(context);
            AllDetails(context).Add(yDetail);
            return yDetail;
        }

        private String GetNewDetailName(String type)
        {
            return type.ToUpper();
            //Int32 i;
            //i = RzWin.Context.SelectScalarInt32("select count(*) from printdetail where detailtype = '" + type + "' and base_printheader_uid = '" + xHeader.unique_id + "'");
            //i++;
            //return type.ToUpper() + i.ToString();
        }

        public n_template CurrentTemplate;

        //Private Variables
        protected ArrayList m_AllDetails;

        //Public Override Functions
        public override string ToString()
        {
            return printname;
        }
        public override void HandleAction(ActArgs args)
        {
            ContextRz context = (ContextRz)args.TheContext;

            switch (args.ActionName.ToLower().Trim())
            {
                case "duplicate":
                    Duplicate(context);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }
        //Public Functions
        public printdetail GetDetailByPct(ContextRz context, int w, int h)
        {
            foreach (printdetail d in AllDetails(context))
            {
                if (d.HitTest(w, h))
                    return d;
            }

            return null;
        }
        public ArrayList GetDetailsByPct(ContextRz context, int w, int h)
        {
            ArrayList a = new ArrayList();
            foreach (printdetail d in AllDetails(context))
            {
                if (d.HitTest(w, h))
                    a.Add(d);
            }
            return a;
        }
        public List<printdetail> GetDetailsByBox(ContextRz context, int w, int h, int w2, int h2)
        {
            List<printdetail> a = new List<printdetail>();
            foreach (printdetail d in AllDetails(context))
            {
                if (d.BoxTest(w, h, w2, h2))
                    a.Add(d);
            }
            return a;
        }

        public printdetail GetDetailById(ContextRz context, String id)
        {
            foreach (printdetail d in AllDetails(context))
            {
                if (d.unique_id == id)
                    return d;
            }
            return null;
        }

        //public int PaperWidth
        //{
        //    get
        //    {
        //        if (new_format)
        //        {
        //            switch (paper_size.ToLower())
        //            {
        //                case "":
        //                case "letter":
        //                case "legal":
        //                    return 850;
        //                default:
        //                    return 850;
        //            }
        //        }
        //        else
        //        {
        //            return 850;
        //        }
        //    }
        //}
        //public void PrintObjectAsync(ContextRz context, nObject o, String PrinterName, bool bw)
        //{
        //    PrintObjectAsync(context, o, PrinterName, 1, bw, true);
        //}
        //public void PrintObjectAsync(ContextRz context, nObject o, String PrinterName, int copies, bool bw, bool consolidate_lines)
        //{
        //    Thread t = new Thread(new ParameterizedThreadStart(PrintObjectByArgs));
        //    t.SetApartmentState(ApartmentState.STA);
        //    OrderPrintArgs args = new OrderPrintArgs(context, o, PrinterName, copies, bw);
        //    args.ConsolidateLines = consolidate_lines;
        //    t.Start(args);
        //}

        //public void PrintObject(ContextRz context, nObject o)
        //{
        //    PrintObject(context, o, "");
        //}
        //public void PrintObject(ContextRz context, nObject o, String PrinterName)
        //{
        //    PrintObject(context, o, PrinterName, 1);
        //}
        //public void PrintObject(ContextRz context, nObject o, String PrinterName, int copies)
        //{
        //    PrintObject(context, o, PrinterName, copies, false, true);
        //}

        //public virtual void PrintObject(ContextRz context, nObject o, String PrinterName, int copies, bool black_and_white, bool consolidate_lines)
        //{

        //}



        public void GatherDetails(ContextRz context)
        {
            m_AllDetails = context.QtC("printdetail", "select * from printdetail where base_printheader_uid = '" + this.unique_id + "'");
        }


        public printdetail GetDetailByName(ContextRz context, String strName)
        {
            foreach (printdetail d in AllDetails(context))
            {
                if (Tools.Strings.StrCmp(d.detailname, strName))
                    return d;
            }
            return null;
        }

        public static printheader GetByName(ContextRz context, String name)
        {
            return printheader.QtO(context, "select * from printheader where printname = '" + context.Filter(name) + "'");
        }

        //private void PrintDetailHeaderBox(Tools.IGraphics g, ArrayList colColumns, int lngx, int lngy, int lngHeight, int lngWidth, Color line_color)
        //{
        //    Pen p = new Pen(line_color, 1);
        //    Rectangle r = new Rectangle(Convert.ToInt32(lngx), Convert.ToInt32(lngy), Convert.ToInt32(lngWidth), Convert.ToInt32(lngHeight));
        //    g.DrawRectangle(p, r);

        //    int lngCount = 1;
        //    int lngCurrentx = lngx;

        //    foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
        //    {
        //        n_column xColumn = (n_column)d.Value;
        //        xColumn.ActualWidth = xColumn.GetActualWidth(lngWidth);
        //        printdetail xTitle = new printdetail(null);

        //        if (lngCount < colColumns.Count)
        //        {
        //            g.DrawLine(p, lngCurrentx + xColumn.ActualWidth, lngy, lngCurrentx + xColumn.ActualWidth, lngy + lngHeight);
        //        }

        //        lngCount++;
        //        lngCurrentx += xColumn.ActualWidth;
        //    }
        //}

        public Font GetHeaderFont()
        {
            Font xFont;

            if (Tools.Strings.StrExt(colhedfont) && colhedfontsize >= 8)
                return new Font(colhedfont, colhedfontsize);
            else if (Tools.Strings.StrExt(colhedfont))
                xFont = new Font(colhedfont, 10);
            else if (colhedfontsize >= 8)
                xFont = new Font("Times New Roman", colhedfontsize);
            else
                xFont = new Font("Times New Roman", 10);

            return xFont;

        }



        public String GetTemplateName()
        {
            return unique_id;
        }

        public void Duplicate(ContextRz context)
        {
            String strName = context.TheLeader.AskForString("Please enter the new template name:", "New Template 1", "New Template Name");
            if (!Tools.Strings.StrExt(strName))
                return;

            String strType = context.TheLeader.AskForString("What type of order is this template for?", this.ordertype, "Order Type");
            if (!Tools.Strings.StrExt(strType))
                return;

            Enums.OrderType t = RzLogic.ConvertOrderType(strType);
            if (t == Enums.OrderType.Any)
            {
                context.TheLeader.Tell("Please enter a valid order type ('sales', 'purchase', etc.)");
                return;
            }

            printheader p = (printheader)this.CloneValues(context);
            p.printname = strName;
            p.printtag = strName;
            p.ordertype = strType;
            context.Insert(p);
            this.GatherDetails(context);
            foreach (printdetail d in AllDetails(context))
            {
                printdetail d2 = (printdetail)d.CloneValues(context);
                d2.base_printheader_uid = p.unique_id;
                context.Insert(d2);
            }

            n_template tem = n_template.GetByName(context, this.GetTemplateName());
            if (tem != null)
            {
                tem.Duplicate(context, p.GetTemplateName());
            }
            context.TheLeader.TellTemp("Done.");
        }
       
        //Private Static Functions
        private static void ScanExcelHorizontal(ContextNM context, nDataTable dt, nObject x)
        {
            CoreClassHandle h = context.TheSys.CoreClassGet(x.ClassId);
            foreach (nDataColumn c in dt.Columns)
            {
                try
                {
                    String strProp = dt.GetRowValue(0, c.order);
                    if (Tools.Strings.StrExt(strProp))
                    {
                        String strVal = dt.GetRowValue(1, c.order);
                        if (Tools.Strings.StrExt(strVal))
                        {
                            CoreVarValAttribute pr = h.VarValGet(strProp.ToLower());
                            if (pr != null)
                            {
                                x.ISet_String(pr.Name, strVal, pr.TheFieldType);
                            }
                        }
                    }
                }
                catch (Exception)
                { }
            }
        }
        private static ArrayList ScanExcelVertical(ContextNM context, nDataTable dt, String strClass, Boolean exclude_system_columns)
        {
            CoreClassHandle cl = context.TheSys.CoreClassGet(strClass);
            DataTable d = dt.GetDataTable(exclude_system_columns);
            ArrayList a = new ArrayList();

            int ci = 0;
            foreach (DataColumn col in d.Columns)
            {
                if (ci > 0)
                {
                    nObject x = (nObject)context.Item(strClass);
                    int ri = 0;
                    foreach (DataRow r in d.Rows)
                    {
                        if (ri > 1)
                        {
                            try
                            {
                                String strProp = nData.NullFilter_String(r[0]);
                                if (Tools.Strings.StrExt(strProp))
                                {
                                    String strVal = nData.NullFilter_String(r[ci]);
                                    if (Tools.Strings.StrExt(strVal))
                                    {
                                        CoreVarValAttribute pr = cl.VarValGet(strProp.ToLower());
                                        if (pr != null)
                                        {
                                            x.ISet_String(pr.Name, strVal, pr.TheFieldType);
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            { }
                        }
                        ri++;
                    }
                    a.Add(x);
                }
                ci++;
            }
            return a;
        }
        //Private Functions

        public static printheader ImportFromExcel(ContextNM x, System.Windows.Forms.IWin32Window owner)
        {
            x.Reorg();
            return null;
            //String s = ToolsWin.FileSystem.ChooseAFile(owner);
            //if (!Tools.Strings.StrExt(s))
            //    return null;

            //if (!System.IO.File.Exists(s))
            //    return null;

            //return ImportFromExcel(x, s);
        }

        public static printheader ImportFromExcel(ContextNM x, String strFile)
        {
            printheader p = printheader.New(x);
            CoreClassHandle cl = x.TheSys.CoreClassGet("printheader");

            nDataTable dt = new nDataTable((DataConnectionSqlServer)x.TheData.TheConnection);
            dt.AbsorbExcelFile(x, strFile, "Sheet1", true);

            ScanExcelHorizontal(x, dt, p);
            p.unique_id = "";
            x.Insert(p);

            //get the details
            ArrayList a = ScanExcelVertical(x, dt, "printdetail", false);
            foreach (printdetail det in a)
            {
                det.unique_id = "";
                det.base_printheader_uid = p.unique_id;
                x.Insert(det);
            }

            //////////////////////////////////////////////////////////
            ////get the template
            dt = new nDataTable((DataConnectionSqlServer)x.TheData.TheConnection);
            dt.AbsorbExcelFile(x, strFile, "Sheet2", true);

            n_template tem = n_template.New(x);
            ScanExcelHorizontal(x, dt, tem);
            tem.unique_id = "";
            //tem.the_n_class_uid = x.xSys.GetClassID("orddet");
            tem.template_name = p.unique_id;
            x.Insert(tem);

            ////get the template details
            a = ScanExcelVertical(x, dt, "n_column", true);
            foreach (n_column col in a)
            {
                col.unique_id = "";
                col.the_n_template_uid = tem.unique_id;
                x.Insert(col);
            }
            return p;
        }
    }

    public class OrderPrintArgs
    {
        //Public Variables
        public ContextNM TheContext;
        public nObject xObject;
        public String strPrinter;
        public int intCopies = 1;
        public bool BlackAndWhite = false;
        public bool ConsolidateLines = false;
       
        //Public Functions
        public OrderPrintArgs(ContextRz context, ordhed o) : this(context, o, "", 1, false)
        {
        }
        public OrderPrintArgs(ContextRz context, nObject o, String p, int copies, bool bw)
        {
            TheContext = context;
            xObject = o;
            strPrinter = p;
            BlackAndWhite = bw;
            if (copies > 0)
                intCopies = copies;
        }
    }
    class BandMember
    {
        //Public Variables
        public String Caption;
        public String Value;
        public Double Width;
        public Double WidthPercent;
        public bool TrailingLine = true;
    }

    public abstract class LineHandle
    {
        //Public Variables
        public bool PrintedIs = false;
        public abstract Object Value(String key);
        public List<String> BelowLineInfo = new List<String>();
        public virtual bool BelowLineInfoHas
        {
            get
            {
                foreach (String b in BelowLineInfo)
                {
                    if (Tools.Strings.StrExt(b))
                        return true;
                }

                return false;
            }
        }

        public abstract String Description{ get; }
    }

    public class LineHandleObject : LineHandle
    {
        public nObject TheObject;
        public String DescriptionReplacement = "";

        //Constructors
        public LineHandleObject(ContextRz context, nObject x)
        {
            TheObject = x;
            BelowLineInfo.Add(Tools.Data.NullFilterString(TheObject.IGet("description")));

            //BelowLineInfo.Add(Tools.Data.NullFilterString(TheObject.IGet("printcomment_invoice")));
            //BelowLineInfo.Add(Tools.Data.NullFilterString(TheObject.IGet("printcomment_purchase")));

            //2012_06_22 omg i can't imagine what i was thinking here.  i think it was a hack for packing slips
            //BelowLineInfo.Add(Tools.Data.NullFilterString(TheObject.IGet("internalcomment")));
        }

        public override object Value(string key)
        {
            return TheObject.IGet(key);
        }

        public override string Description
        {
            get
            {
                if (Tools.Strings.StrExt(DescriptionReplacement))
                    return DescriptionReplacement;
                else
                    return Tools.Data.NullFilterString(TheObject.IGet("description"));
            }
        }
    }
    public interface IPrintable
    {
        List<Object> PrintLines(ContextRz context, String id);
    }
}
