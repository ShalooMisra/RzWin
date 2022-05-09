using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeInterop;
using Core;
using NewMethod;
using System.Web;
using Tools;
using System.Windows.Forms;
using Tools.Database;

namespace Rz5
{
    public abstract class Report : Core.Report
    {
        public Report(Context context)
            : base(context)
        {
        }

        //public List<Report> SubReports = new List<Report>();
        //public ReportSection HeadingSection;
        //public Dictionary<String, ReportColumn> Columns;
        ////public String TotalsColumn = "";
        //public String SortColumn = "";
        //public SortDirection SortDirection = SortDirection.Ascending;

        //public Report(ContextRz context)
        //{
        //    InitColumns(context);  //has to be first because the totals use this
        //    InitTotals(); //this gets done each time the report is run, but we need to know if the report has totals sometimes before the actual line calc is done
        //}

        //public Report Clone(ContextRz context)
        //{
        //    Report ret = (Report)Activator.CreateInstance(GetType(), new Object[] { context }); //has to be a new instance to re-set the columns
        //    ApplyTo(context, ret);
        //    return ret;
        //}

        //protected virtual void ApplyTo(ContextRz context, Report r)
        //{

        //}

        //protected virtual void ColumnsClear()
        //{
        //    if (Columns != null)
        //        Columns.Clear();
        //}

        //protected abstract void InitColumns(Context context);

        //public void Calculate(ContextRz context, ReportArgs args)  //this defines the report calc structure and shouldn't be virtual
        //{
        //    BeforeCalculate(context, args);
        //    CalculateLines(context, args);
        //    AfterCalculate(context, args);
        //}

        //public virtual void BeforeCalculate(ContextRz context, ReportArgs args)
        //{

        //}

        //public virtual void CalculateLines(Context context, ReportArgs args)
        //{
        //    Caption = Title + " " + args.ToString();
        //    Lines.Clear();
        //    InitTotals();
        //    Sections.Clear();
        //}

        //public virtual void AfterCalculate(ContextRz context, ReportArgs args)
        //{
        //    CalculateAutoTotals(context);
        //}

        //void CalculateAutoTotals(ContextRz context)
        //{
        //    foreach (ReportTotal t in Totals)
        //    {
        //        if (t.Auto)
        //            CalculateAutoTotal(context, t);
        //    }
        //}

        //void CalculateAutoTotal(ContextRz context, ReportTotal t)
        //{
        //    t.Value = 0;
        //    foreach (ReportLine l in Lines)
        //    {
        //        try
        //        {
        //            t.Value += Convert.ToDouble(l.Cells[t.ValueColumn].Value);
        //        }
        //        catch { }
        //    }
        //}

        //protected virtual void InitTotals()
        //{
        //    Totals.Clear();
        //}

        //public ReportColumn ColumnAdd(String caption)
        //{
        //    return ColumnAdd(new ReportColumn(caption));
        //}

        //public ReportColumn ColumnAdd(String caption, ColumnAlignment align)
        //{
        //    return ColumnAdd(new ReportColumn(caption, align));
        //}

        //public ReportColumn ColumnAdd(String caption, ValueUse valueUse)
        //{
        //    return ColumnAdd(new ReportColumn(caption, valueUse));
        //}

        //public ReportColumn ColumnAdd(ReportColumn c)
        //{
        //    if (Columns == null)
        //        Columns = new Dictionary<string, ReportColumn>();
        //    c.Index = Columns.Count;
        //    Columns.Add(c.Name, c);
        //    return c;
        //}

        //public ReportLine LineById(String lineId)
        //{
        //    foreach (ReportLine l in Lines)
        //    {
        //        if (l.Uid == lineId)
        //            return l;
        //    }
        //    return null;
        //}

        //public void Set(ReportLine l, String column_name, Object value)
        //{
        //    Set(l, column_name, value, value.ToString());
        //}

        //public void Set(ReportLine l, String column_name, Object value, String caption)
        //{
        //    l.Set(ColumnIndex(column_name.Trim().ToLower()), value, caption);
        //}

        //public int ColumnIndex(String name)
        //{
        //    if (Columns == null)
        //        return -1;

        //    String key = name.Trim().ToLower();
        //    if (Columns.ContainsKey(key))
        //        return Columns[key].Index;
        //    else
        //        return -1;
        //}

        //public List<ReportColumn> ColumnsList
        //{
        //    get
        //    {
        //        List<ReportColumn> ret = new List<ReportColumn>();
        //        if (Columns == null)
        //            return ret;

        //        foreach (KeyValuePair<String, ReportColumn> k in Columns)
        //        {
        //            ret.Add(k.Value);
        //        }

        //        return ret;
        //    }
        //}

        //public virtual String Title
        //{
        //    get
        //    {
        //        return "Report";
        //    }
        //}

        //public virtual String Description
        //{
        //    get
        //    {
        //        return "";
        //    }
        //}

        //public virtual ReportArgs ArgsCreate(Context context)
        //{
        //    return new ReportArgs(context);
        //}

        //protected ReportTotal AutoTotal(String totalCaption, String columnCaption, ValueUse use = ValueUse.Any)
        //{
        //    ReportTotal t = new ReportTotal(totalCaption);
        //    t.ValueColumn = ColumnIndex(columnCaption);
        //    t.Auto = true;
        //    t.ValueUse = use;
        //    Totals.Add(t);
        //    return t;
        //}

        //protected ReportTotal AutoTotalInteger(String totalCaption, String columnCaption, ValueUse use = ValueUse.Any)
        //{
        //    ReportTotalInteger t = new ReportTotalInteger(totalCaption);
        //    t.ValueColumn = ColumnIndex(columnCaption);
        //    t.Auto = true;
        //    t.ValueUse = use;
        //    Totals.Add(t);
        //    return t;
        //}

        public override void ProcessCommand(Context context, String command)
        {
            ContextRz x = (ContextRz)context;
            if (command.StartsWith("partsearch:"))
            {
                x.TheLeaderRz.PartSearchShow(x, Tools.Strings.ParseDelimit(command, ":", 2));
            }
            else if (command.StartsWith("posearch:"))
            {
                x.TheLeaderRz.OrderSearchShow(x, Enums.OrderType.Purchase, Tools.Strings.ParseDelimit(command, ":", 2));
            }
        }

        //protected virtual ReportLine LineAdd()
        //{
        //    ReportLine l = new ReportLine();
        //    Lines.Add(l);
        //    return l;
        //}

        //public void SummarizeByDate(ContextRz context, ReportArgs args, String dateCriteriaUid)
        //{
        //    ReportCriteriaDateRange range = (ReportCriteriaDateRange)args.CriteriaById(dateCriteriaUid);
        //    if (range == null)
        //        throw new Exception("The criteria date range cound not be found");

        //    SummarizeByDate(context, args, range);
        //}

        //public void SummarizeByDate(ContextRz context, ReportArgs args, ReportCriteriaDateRange range)
        //{
        //    if (!Tools.Dates.DateExists(range.TheRange.StartDate))
        //        throw new Exception("Please select a start date");

        //    if (!Tools.Dates.DateExists(range.TheRange.EndDate))
        //        throw new Exception("Please select an end date");

        //    Caption = Title + " Summary By " + range.Caption + " " + args.ToString();

        //    Tools.Dates.DateRange startingRange = range.TheRange;

        //    CubeInterval interval = CubeInterval.Any;
        //    TimeSpan span = range.TheRange.EndDate.Subtract(range.TheRange.StartDate);
        //    if (span.TotalDays < 35)
        //        interval = CubeInterval.Day;
        //    else
        //    {
        //        List<string> choices = new List<string>();
        //        choices.Add("Month");
        //        if (span.TotalDays > (31 * 3))
        //            choices.Add("Quarter");
        //        if (span.TotalDays > 365)
        //            choices.Add("Year");

        //        String intervalString = "";
        //        if (choices.Count == 1)
        //            intervalString = choices[0];
        //        else
        //            intervalString = context.TheLeader.ChooseBetweenStrings("Interval", choices);

        //        switch (intervalString)
        //        {
        //            case "Month":
        //                interval = CubeInterval.Month;
        //                break;
        //            case "Quarter":
        //                interval = CubeInterval.Quarter;
        //                break;
        //            case "Year":
        //                interval = CubeInterval.Year;
        //                break;
        //            default:
        //                return;
        //        }
        //    }

        //    if (Columns != null)
        //        Columns.Clear();
        //    InitColumns(context); //needed for totals
        //    InitTotals();  //above column clear
        //    Columns.Clear();
        //    Lines.Clear();
        //    SubReports.Clear();
        //    Sections.Clear();

        //    ColumnAdd(range.Caption);
        //    foreach (ReportTotal t in Totals)
        //    {
        //        ReportColumn c = ColumnAdd(t.Caption, ColumnAlignment.Right);
        //        c.ValueUse = t.ValueUse;
        //    }
        //    Totals.Clear();

        //    DateTime start = Tools.Dates.GetStartDate(range.TheRange.StartDate, interval);
        //    DateTime end = Tools.Dates.GetEndDate(range.TheRange.EndDate, interval);
        //    while (!Tools.Dates.IsLaterDay(start, end))
        //    {
        //        ReportArgs sliceArgs = args.Clone(context);  //copy everything so that it can be stored
        //        ReportCriteriaDateRange sliceRange = (ReportCriteriaDateRange)sliceArgs.CriteriaById(range.Uid);

        //        DateTime sliceEnd = Tools.Dates.GetEndDate(start, interval);
        //        sliceRange.TheRange = new Tools.Dates.DateRange(start, sliceEnd);

        //        Report subReport = (Report)Activator.CreateInstance(GetType(), new Object[] { context });
        //        subReport.Calculate(context, sliceArgs);
        //        ReportLine l = LineAdd();

        //        l.SummaryArgs = sliceArgs;
        //        String dateCaption = "";
        //        switch (interval)
        //        {
        //            case CubeInterval.Year:
        //                dateCaption = start.Year.ToString();
        //                break;
        //            case CubeInterval.Quarter:
        //                dateCaption = "Q" + Tools.Dates.GetQuarter(start).ToString() + " " + start.Year.ToString();
        //                break;
        //            case CubeInterval.Month:
        //                dateCaption = Tools.Dates.GetMonthName(start.Month) + " " + start.Year.ToString();
        //                break;
        //            default:
        //                dateCaption = start.DayOfWeek.ToString().Substring(0, 3).ToUpper() + " " + Tools.Dates.DateFormat(start);
        //                break;
        //        }
        //        l.SetInc(dateCaption);
        //        subReport.SetTotalsInc(l);

        //        start = Tools.Dates.GetDayStart(sliceEnd.AddDays(1));   // for every interval the next day works
        //    }

        //    range.TheRange = startingRange;
        //}

        //public void SummarizeByRadio(ContextRz context, ReportArgs args, String dateCriteriaUid)
        //{
        //    ReportCriteriaRadio radio = (ReportCriteriaRadio)args.CriteriaById(dateCriteriaUid);
        //    if (radio == null)
        //        throw new Exception("The criteria cound not be found");

        //    SummarizeByRadio(context, args, radio);
        //}

        //public void SummarizeByRadio(ContextRz context, ReportArgs args, ReportCriteriaRadio radio)
        //{
        //    Caption = Title + " Summary By " + radio.Caption + " " + args.ToString();

        //    if (Columns != null)
        //        Columns.Clear();
        //    InitColumns(context); //needed for totals
        //    InitTotals();  //above column clear
        //    Columns.Clear();
        //    Lines.Clear();
        //    SubReports.Clear();
        //    Sections.Clear();

        //    String originalValue = radio.SelectedCaption;

        //    ColumnAdd(radio.Caption);
        //    foreach (ReportTotal t in Totals)
        //    {
        //        ReportColumn c = ColumnAdd(t.Caption, ColumnAlignment.Right);
        //        c.ValueUse = t.ValueUse;
        //    }
        //    Totals.Clear();

        //    foreach (String r in radio.ValueCaptions)
        //    {
        //        ReportArgs sliceArgs = args.Clone(context);  //copy everything so that it can be stored
        //        ReportCriteriaRadio slice = (ReportCriteriaRadio)sliceArgs.CriteriaById(radio.Uid);
        //        slice.SelectedCaption = r;

        //        Report subReport = (Report)Activator.CreateInstance(GetType(), new Object[] { context });
        //        subReport.Calculate(context, sliceArgs);
        //        ReportLine l = LineAdd();

        //        l.SummaryArgs = sliceArgs;
        //        l.SetInc(r);
        //        subReport.SetTotalsInc(l);
        //    }

        //    radio.SelectedCaption = originalValue;
        //}

        public void SummarizeByCompany(ContextRz context, ReportArgs args, ReportCriteriaCompany company)
        {
            Caption = Title + " Summary By " + company.Caption + " " + args.ToString();

            if (Columns != null)
                Columns.Clear();
            InitColumns(context); //needed for totals
            InitTotals();  //above column clear
            Columns.Clear();
            Lines.Clear();
            SubReports.Clear();
            Sections.Clear();

            String originalValue = company.TheID;

            ColumnAdd(company.Caption);
            foreach (ReportTotal t in Totals)
            {
                ReportColumn c = ColumnAdd(t.Caption, ColumnAlignment.Right);
                c.ValueUse = t.ValueUse;
            }
            Totals.Clear();

            foreach (String companyId in company.GetUniqueCompanyIds(context, this, args))
            {
                ReportArgs sliceArgs = args.Clone(context);  //copy everything so that it can be stored
                ReportCriteriaCompany slice = (ReportCriteriaCompany)sliceArgs.CriteriaById(company.Uid);
                slice.TheID = companyId;
                slice.TheName = Rz5.company.TranslateIDToName(context, slice.TheID);

                Report subReport = (Report)Activator.CreateInstance(GetType(), new Object[] { context });
                subReport.Calculate(context, sliceArgs);
                ReportLine l = LineAdd();

                l.SummaryArgs = sliceArgs;
                if (Tools.Strings.StrExt(slice.TheName))
                    l.SetInc(slice.TheName);
                else
                    l.SetInc("[no name]");

                subReport.SetTotalsInc(l);
            }

            company.TheID = originalValue;
            company.TheName = Rz5.company.TranslateIDToName(context, company.TheID);
        }

        //public void SummarizeByColumn(ContextRz context, ReportArgs args, int columnIndex)
        //{
        //    ReportColumn c = ColumnByIndex(columnIndex);
        //    if (c == null)
        //        throw new Exception("This column was not found");

        //    Caption = Title + " Summary By " + c.Caption + " " + args.ToString();

        //    List<ReportLine> originalLines = new List<ReportLine>(Lines);
        //    List<String> originalValues = UniqueStringsList(c.Index);

        //    Columns.Clear();
        //    InitColumns(context);
        //    InitTotals();
        //    Columns.Clear();
        //    List<ReportTotal> originalTotals = new List<ReportTotal>(Totals);

        //    foreach (ReportTotal t in Totals)
        //    {
        //        if (t is ReportTotalPercent)
        //            originalTotals.Remove(t);
        //        else if (!t.ColumnBound)
        //            originalTotals.Remove(t);
        //    }

        //    Lines.Clear();
        //    SubReports.Clear();
        //    Sections.Clear();
        //    Totals.Clear();

        //    ColumnAdd(c.Caption);
        //    ReportColumn newColumn = ColumnAdd("Count", ColumnAlignment.Right);
        //    newColumn.ValueUse = ValueUse.Count;
        //    foreach (ReportTotal t in originalTotals)
        //    {
        //        newColumn = ColumnAdd(t.Caption, ColumnAlignment.Right);
        //        newColumn.ValueUse = t.ValueUse;
        //    }

        //    foreach (String r in originalValues)
        //    {
        //        List<ReportLine> selectedLines = LinesByValue(originalLines, c.Index, r);

        //        String use = r;
        //        if (!Tools.Strings.StrExt(use))
        //            use = "[blank]";

        //        ReportLine l = LineAdd();

        //        l.SetInc(use);
        //        l.SetInc(selectedLines.Count);

        //        List<ReportTotal> sliceTotals = new List<ReportTotal>();
        //        foreach (ReportTotal t in originalTotals)
        //        {
        //            sliceTotals.Add(t.CloneZeroValue());
        //        }

        //        foreach (ReportLine sel in selectedLines)
        //        {
        //            foreach (ReportTotal t in sliceTotals)
        //            {
        //                if (t.ValueColumn < 0)
        //                    throw new Exception("Value column missing");

        //                t.Value += Convert.ToDouble(sel.Cells[t.ValueColumn].Value);
        //            }
        //        }

        //        SetTotalsInc(sliceTotals, l);
        //    }
        //}

        //public List<ReportLine> LinesByValue(int colIndex, Object value)
        //{
        //    return LinesByValue(Lines, colIndex, value);
        //}

        //public static List<ReportLine> LinesByValue(List<ReportLine> startingLines, int colIndex, Object value)
        //{
        //    String s2 = Convert.ToString(value).ToLower().Trim();

        //    List<ReportLine> ret = new List<ReportLine>();
        //    foreach (ReportLine l in startingLines)
        //    {
        //        String s1 = Convert.ToString(l.Cells[colIndex].Value).ToLower().Trim();
        //        if (s1 == s2 || (s1 == "true" && s2 == "y") || (s2 == "true" && s1 == "y") || (s1 == "[blank]" && s2 == "") || (s2 == "[blank]" && s1 == "") || (s1 == "false" && s2 == "[blank]") || (s2 == "false" && s1 == "") || (s1 == "false" && s2 == ""))
        //            ret.Add(l);
        //    }
        //    return ret;
        //}

        //ReportColumn ColumnByIndex(int colIndex)
        //{
        //    return ColumnsList[colIndex];
        //}

        //public void SetTotalsInc(ReportLine l)
        //{
        //    SetTotalsInc(Totals, l);
        //}

        //public static void SetTotalsInc(List<ReportTotal> totals, ReportLine l)
        //{
        //    foreach (ReportTotal t in totals)
        //    {
        //        if (t is ReportTotalPercent)
        //            l.SetInc(Math.Round(t.Value, 1), Math.Round(t.Value, 1).ToString() + "%");
        //        else if (t is ReportTotalInteger)
        //            l.SetInc(Convert.ToInt32(t.Value));
        //        else if (t is ReportTotalMinutes)
        //            l.SetInc(Convert.ToInt32(t.Value), Tools.Dates.FormatDHMLetter(Convert.ToInt32(t.Value)));
        //        else
        //            l.SetInc(t.Value);
        //    }
        //}

        //public bool ChartColumn(ReportColumn c)
        //{
        //    if (c.ValueUse == ValueUse.Ignore)
        //        return false;

        //    if (VarVal.UseIsNumeric(c.ValueUse))
        //        return true;

        //    if (Lines.Count == 0)
        //        return false;

        //    try
        //    {
        //        Object v = Lines[0].Cells[c.Index].Value;
        //        return v is Double || v is Int32;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public void SortByColumnIndex(int colIndex)
        //{
        //    ReportColumn col = null;
        //    int i = 0;

        //    foreach (KeyValuePair<String, ReportColumn> k in Columns)
        //    {
        //        if (i == colIndex)
        //        {
        //            col = k.Value;
        //            break;
        //        }
        //        i++;
        //    }

        //    if (col == null)
        //        return;

        //    if (Tools.Strings.StrCmp(col.Caption, SortColumn))
        //    {
        //        if (SortDirection == SortDirection.Ascending)
        //            SortDirection = SortDirection.Descending;
        //        else
        //            SortDirection = SortDirection.Ascending;
        //    }
        //    else
        //    {
        //        SortDirection = SortDirection.Ascending;
        //        SortColumn = col.Caption;
        //    }

        //    ReportLineComparison comp = new ReportLineComparison(colIndex, (SortDirection == SortDirection.Descending));
        //    Lines.Sort(comp);
        //}

        //public void InferColumnOptions(ContextRz context)
        //{
        //    foreach (ReportColumn c in ColumnsList)
        //    {
        //        if (c.ValueUse == ValueUse.Ignore)
        //            continue;

        //        if (VarVal.UseIsNumeric(c.ValueUse))
        //            continue;

        //        //if (c.Attribute != null)
        //        //{
        //        //    if( c.Attribute.TheFieldType != FieldType.String )
        //        //        continue;
        //        //}
        //        //else
        //        //{

        //        if (c.Caption.ToLower().Contains("date"))
        //            continue;

        //        if (c.Caption.Contains("#"))
        //            continue;

        //        //}

        //        if (c.Alignment == ColumnAlignment.Left)  //infer the textual fields
        //        {
        //            int uniqueValues = UniqueStringsList(c.Index).Count;
        //            int lineCount = Lines.Count;
        //            if (uniqueValues <= 1)
        //                continue;

        //            if (uniqueValues == lineCount)
        //                continue;

        //            int percent = Tools.Number.CalcPercent(lineCount, uniqueValues);
        //            if (percent < 60)
        //            {
        //                c.ColumnSummary = true;
        //                c.ColumnSummaryCount = uniqueValues;
        //            }
        //        }
        //    }
        //}

        //public List<String> UniqueStringsList(int columnIndex)
        //{
        //    List<string> ret = new List<string>();
        //    List<String> compare = new List<string>();
        //    foreach (ReportLine l in Lines)
        //    {
        //        if (l.Cells.Count >= columnIndex)
        //        {
        //            String val = l.Cells[columnIndex].Caption.Trim();
        //            if (!compare.Contains(val.ToLower()))
        //            {
        //                ret.Add(val);
        //                compare.Add(val.ToLower());
        //            }
        //        }
        //    }
        //    return ret;
        //}
    }
    //public abstract class Report : ReportSection
    //{
    //    public List<Report> SubReports = new List<Report>();
    //    public ReportSection HeadingSection;
    //    public Dictionary<String, ReportColumn> Columns;
    //    //public String TotalsColumn = "";
    //    public String SortColumn = "";
    //    public SortDirection SortDirection = SortDirection.Ascending;

    //    public Report(ContextRz context)
    //    {
    //        InitColumns(context);  //has to be first because the totals use this
    //        InitTotals(); //this gets done each time the report is run, but we need to know if the report has totals sometimes before the actual line calc is done
    //    }

    //    public Report Clone(ContextRz context)
    //    {
    //        Report ret = (Report)Activator.CreateInstance(GetType(), new Object[] { context }); //has to be a new instance to re-set the columns
    //        ApplyTo(context, ret);
    //        return ret;
    //    }

    //    protected virtual void ApplyTo(ContextRz context, Report r)
    //    {

    //    }

    //    protected virtual void ColumnsClear()
    //    {
    //        if (Columns != null)
    //            Columns.Clear();
    //    }

    //    protected abstract void InitColumns(Context context);

    //    public void Calculate(ContextRz context, ReportArgs args)  //this defines the report calc structure and shouldn't be virtual
    //    {
    //        BeforeCalculate(context, args);
    //        CalculateLines(context, args);
    //        AfterCalculate(context, args);
    //    }

    //    public virtual void BeforeCalculate(ContextRz context, ReportArgs args)
    //    {

    //    }

    //    public virtual void CalculateLines(Context context, ReportArgs args)
    //    {
    //        Caption = Title + " " + args.ToString();
    //        Lines.Clear();
    //        InitTotals();
    //        Sections.Clear();
    //    }

    //    public virtual void AfterCalculate(ContextRz context, ReportArgs args)
    //    {
    //        CalculateAutoTotals(context);
    //    }

    //    void CalculateAutoTotals(ContextRz context)
    //    {
    //        foreach (ReportTotal t in Totals)
    //        {
    //            if (t.Auto)
    //                CalculateAutoTotal(context, t);
    //        }
    //    }

    //    void CalculateAutoTotal(ContextRz context, ReportTotal t)
    //    {
    //        t.Value = 0;
    //        foreach (ReportLine l in Lines)
    //        {
    //            try
    //            {
    //                t.Value += Convert.ToDouble(l.Cells[t.ValueColumn].Value);
    //            }
    //            catch { }
    //        }
    //    }

    //    protected virtual void InitTotals()
    //    {
    //        Totals.Clear();
    //    }

    //    public ReportColumn ColumnAdd(String caption)
    //    {
    //        return ColumnAdd(new ReportColumn(caption));
    //    }

    //    public ReportColumn ColumnAdd(String caption, ColumnAlignment align)
    //    {
    //        return ColumnAdd(new ReportColumn(caption, align));
    //    }

    //    public ReportColumn ColumnAdd(String caption, ValueUse valueUse)
    //    {
    //        return ColumnAdd(new ReportColumn(caption, valueUse));
    //    }

    //    public ReportColumn ColumnAdd(ReportColumn c)
    //    {
    //        if (Columns == null)
    //            Columns = new Dictionary<string, ReportColumn>();
    //        c.Index = Columns.Count;
    //        Columns.Add(c.Name, c);
    //        return c;
    //    }

    //    public ReportLine LineById(String lineId)
    //    {
    //        foreach (ReportLine l in Lines)
    //        {
    //            if (l.Uid == lineId)
    //                return l;
    //        }
    //        return null;
    //    }

    //    public void Set(ReportLine l, String column_name, Object value)
    //    {
    //        Set(l, column_name, value, value.ToString());
    //    }

    //    public void Set(ReportLine l, String column_name, Object value, String caption)
    //    {
    //        l.Set(ColumnIndex(column_name.Trim().ToLower()), value, caption);
    //    }

    //    public int ColumnIndex(String name)
    //    {
    //        if (Columns == null)
    //            return -1;

    //        String key = name.Trim().ToLower();
    //        if (Columns.ContainsKey(key))
    //            return Columns[key].Index;
    //        else
    //            return -1;
    //    }

    //    public List<ReportColumn> ColumnsList
    //    {
    //        get
    //        {
    //            List<ReportColumn> ret = new List<ReportColumn>();
    //            if (Columns == null)
    //                return ret;

    //            foreach (KeyValuePair<String, ReportColumn> k in Columns)
    //            {
    //                ret.Add(k.Value);
    //            }

    //            return ret;
    //        }
    //    }

    //    public virtual String Title
    //    {
    //        get
    //        {
    //            return "Report";
    //        }
    //    }

    //    public virtual String Description
    //    {
    //        get
    //        {
    //            return "";
    //        }
    //    }

    //    public virtual ReportArgs ArgsCreate(Context context)
    //    {
    //        return new ReportArgs(context);
    //    }

    //    protected ReportTotal AutoTotal(String totalCaption, String columnCaption, ValueUse use = ValueUse.Any)
    //    {
    //        ReportTotal t = new ReportTotal(totalCaption);
    //        t.ValueColumn = ColumnIndex(columnCaption);
    //        t.Auto = true;
    //        t.ValueUse = use;
    //        Totals.Add(t);
    //        return t;
    //    }

    //    protected ReportTotal AutoTotalInteger(String totalCaption, String columnCaption, ValueUse use = ValueUse.Any)
    //    {
    //        ReportTotalInteger t = new ReportTotalInteger(totalCaption);
    //        t.ValueColumn = ColumnIndex(columnCaption);
    //        t.Auto = true;
    //        t.ValueUse = use;
    //        Totals.Add(t);
    //        return t;
    //    }

    //    public virtual void ProcessCommand(ContextRz context, String command)
    //    {
    //        if (command.StartsWith("partsearch:"))
    //        {
    //            context.TheLeaderRz.PartSearchShow(context, Tools.Strings.ParseDelimit(command, ":", 2));
    //        }
    //        else if (command.StartsWith("posearch:"))
    //        {
    //            context.TheLeaderRz.OrderSearchShow(context, Enums.OrderType.Purchase, Tools.Strings.ParseDelimit(command, ":", 2));
    //        }
    //    }

    //    protected virtual ReportLine LineAdd()
    //    {
    //        ReportLine l = new ReportLine();
    //        Lines.Add(l);
    //        return l;
    //    }

    //    public void SummarizeByDate(ContextRz context, ReportArgs args, String dateCriteriaUid)
    //    {
    //        ReportCriteriaDateRange range = (ReportCriteriaDateRange)args.CriteriaById(dateCriteriaUid);
    //        if (range == null)
    //            throw new Exception("The criteria date range cound not be found");

    //        SummarizeByDate(context, args, range);
    //    }

    //    public void SummarizeByDate(ContextRz context, ReportArgs args, ReportCriteriaDateRange range)
    //    {
    //        if (!Tools.Dates.DateExists(range.TheRange.StartDate))
    //            throw new Exception("Please select a start date");

    //        if (!Tools.Dates.DateExists(range.TheRange.EndDate))
    //            throw new Exception("Please select an end date");

    //        Caption = Title + " Summary By " + range.Caption + " " + args.ToString();

    //        Tools.Dates.DateRange startingRange = range.TheRange;

    //        CubeInterval interval = CubeInterval.Any;
    //        TimeSpan span = range.TheRange.EndDate.Subtract(range.TheRange.StartDate);
    //        if (span.TotalDays < 35)
    //            interval = CubeInterval.Day;
    //        else
    //        {
    //            List<string> choices = new List<string>();
    //            choices.Add("Month");
    //            if (span.TotalDays > (31 * 3))
    //                choices.Add("Quarter");
    //            if (span.TotalDays > 365)
    //                choices.Add("Year");

    //            String intervalString = "";
    //            if (choices.Count == 1)
    //                intervalString = choices[0];
    //            else
    //                intervalString = context.TheLeader.ChooseBetweenStrings("Interval", choices);

    //            switch (intervalString)
    //            {
    //                case "Month":
    //                    interval = CubeInterval.Month;
    //                    break;
    //                case "Quarter":
    //                    interval = CubeInterval.Quarter;
    //                    break;
    //                case "Year":
    //                    interval = CubeInterval.Year;
    //                    break;
    //                default:
    //                    return;
    //            }
    //        }

    //        if (Columns != null)
    //            Columns.Clear();
    //        InitColumns(context); //needed for totals
    //        InitTotals();  //above column clear
    //        Columns.Clear();
    //        Lines.Clear();
    //        SubReports.Clear();
    //        Sections.Clear();

    //        ColumnAdd(range.Caption);
    //        foreach (ReportTotal t in Totals)
    //        {
    //            ReportColumn c = ColumnAdd(t.Caption, ColumnAlignment.Right);
    //            c.ValueUse = t.ValueUse;
    //        }
    //        Totals.Clear();

    //        DateTime start = Tools.Dates.GetStartDate(range.TheRange.StartDate, interval);
    //        DateTime end = Tools.Dates.GetEndDate(range.TheRange.EndDate, interval);
    //        while (!Tools.Dates.IsLaterDay(start, end))
    //        {
    //            ReportArgs sliceArgs = args.Clone(context);  //copy everything so that it can be stored
    //            ReportCriteriaDateRange sliceRange = (ReportCriteriaDateRange)sliceArgs.CriteriaById(range.Uid);

    //            DateTime sliceEnd = Tools.Dates.GetEndDate(start, interval);
    //            sliceRange.TheRange = new Tools.Dates.DateRange(start, sliceEnd);

    //            Report subReport = (Report)Activator.CreateInstance(GetType(), new Object[] { context });
    //            subReport.Calculate(context, sliceArgs);
    //            ReportLine l = LineAdd();

    //            l.SummaryArgs = sliceArgs;
    //            String dateCaption = "";
    //            switch (interval)
    //            {
    //                case CubeInterval.Year:
    //                    dateCaption = start.Year.ToString();
    //                    break;
    //                case CubeInterval.Quarter:
    //                    dateCaption = "Q" + Tools.Dates.GetQuarter(start).ToString() + " " + start.Year.ToString();
    //                    break;
    //                case CubeInterval.Month:
    //                    dateCaption = Tools.Dates.GetMonthName(start.Month) + " " + start.Year.ToString();
    //                    break;
    //                default:
    //                    dateCaption = start.DayOfWeek.ToString().Substring(0, 3).ToUpper() + " " + Tools.Dates.DateFormat(start);
    //                    break;
    //            }
    //            l.SetInc(dateCaption);
    //            subReport.SetTotalsInc(l);

    //            start = Tools.Dates.GetDayStart(sliceEnd.AddDays(1));   // for every interval the next day works
    //        }

    //        range.TheRange = startingRange;
    //    }

    //    public void SummarizeByRadio(ContextRz context, ReportArgs args, String dateCriteriaUid)
    //    {
    //        ReportCriteriaRadio radio = (ReportCriteriaRadio)args.CriteriaById(dateCriteriaUid);
    //        if (radio == null)
    //            throw new Exception("The criteria cound not be found");

    //        SummarizeByRadio(context, args, radio);
    //    }

    //    public void SummarizeByRadio(ContextRz context, ReportArgs args, ReportCriteriaRadio radio)
    //    {
    //        Caption = Title + " Summary By " + radio.Caption + " " + args.ToString();

    //        if (Columns != null)
    //            Columns.Clear();
    //        InitColumns(context); //needed for totals
    //        InitTotals();  //above column clear
    //        Columns.Clear();
    //        Lines.Clear();
    //        SubReports.Clear();
    //        Sections.Clear();

    //        String originalValue = radio.SelectedCaption;

    //        ColumnAdd(radio.Caption);
    //        foreach (ReportTotal t in Totals)
    //        {
    //            ReportColumn c = ColumnAdd(t.Caption, ColumnAlignment.Right);
    //            c.ValueUse = t.ValueUse;
    //        }
    //        Totals.Clear();

    //        foreach (String r in radio.ValueCaptions)
    //        {
    //            ReportArgs sliceArgs = args.Clone(context);  //copy everything so that it can be stored
    //            ReportCriteriaRadio slice = (ReportCriteriaRadio)sliceArgs.CriteriaById(radio.Uid);
    //            slice.SelectedCaption = r;

    //            Report subReport = (Report)Activator.CreateInstance(GetType(), new Object[] { context });
    //            subReport.Calculate(context, sliceArgs);
    //            ReportLine l = LineAdd();

    //            l.SummaryArgs = sliceArgs;
    //            l.SetInc(r);
    //            subReport.SetTotalsInc(l);
    //        }

    //        radio.SelectedCaption = originalValue;
    //    }

    //    public void SummarizeByCompany(ContextRz context, ReportArgs args, ReportCriteriaCompany company)
    //    {
    //        Caption = Title + " Summary By " + company.Caption + " " + args.ToString();

    //        if (Columns != null)
    //            Columns.Clear();
    //        InitColumns(context); //needed for totals
    //        InitTotals();  //above column clear
    //        Columns.Clear();
    //        Lines.Clear();
    //        SubReports.Clear();
    //        Sections.Clear();

    //        String originalValue = company.TheID;

    //        ColumnAdd(company.Caption);
    //        foreach (ReportTotal t in Totals)
    //        {
    //            ReportColumn c = ColumnAdd(t.Caption, ColumnAlignment.Right);
    //            c.ValueUse = t.ValueUse;
    //        }
    //        Totals.Clear();

    //        foreach (String companyId in company.GetUniqueCompanyIds(context, this, args))
    //        {
    //            ReportArgs sliceArgs = args.Clone(context);  //copy everything so that it can be stored
    //            ReportCriteriaCompany slice = (ReportCriteriaCompany)sliceArgs.CriteriaById(company.Uid);
    //            slice.TheID = companyId;
    //            slice.TheName = Rz4.company.TranslateIDToName(context, slice.TheID);

    //            Report subReport = (Report)Activator.CreateInstance(GetType(), new Object[] { context });
    //            subReport.Calculate(context, sliceArgs);
    //            ReportLine l = LineAdd();

    //            l.SummaryArgs = sliceArgs;
    //            if (Tools.Strings.StrExt(slice.TheName))
    //                l.SetInc(slice.TheName);
    //            else
    //                l.SetInc("[no name]");

    //            subReport.SetTotalsInc(l);
    //        }

    //        company.TheID = originalValue;
    //        company.TheName = Rz4.company.TranslateIDToName(context, company.TheID);
    //    }

    //    public void SummarizeByColumn(ContextRz context, ReportArgs args, int columnIndex)
    //    {
    //        ReportColumn c = ColumnByIndex(columnIndex);
    //        if (c == null)
    //            throw new Exception("This column was not found");

    //        Caption = Title + " Summary By " + c.Caption + " " + args.ToString();

    //        List<ReportLine> originalLines = new List<ReportLine>(Lines);
    //        List<String> originalValues = UniqueStringsList(c.Index);

    //        Columns.Clear();
    //        InitColumns(context);
    //        InitTotals();
    //        Columns.Clear();
    //        List<ReportTotal> originalTotals = new List<ReportTotal>(Totals);

    //        foreach (ReportTotal t in Totals)
    //        {
    //            if (t is ReportTotalPercent)
    //                originalTotals.Remove(t);
    //            else if (!t.ColumnBound)
    //                originalTotals.Remove(t);
    //        }

    //        Lines.Clear();
    //        SubReports.Clear();
    //        Sections.Clear();
    //        Totals.Clear();

    //        ColumnAdd(c.Caption);
    //        ReportColumn newColumn = ColumnAdd("Count", ColumnAlignment.Right);
    //        newColumn.ValueUse = ValueUse.Count;
    //        foreach (ReportTotal t in originalTotals)
    //        {
    //            newColumn = ColumnAdd(t.Caption, ColumnAlignment.Right);
    //            newColumn.ValueUse = t.ValueUse;
    //        }

    //        foreach (String r in originalValues)
    //        {
    //            List<ReportLine> selectedLines = LinesByValue(originalLines, c.Index, r);

    //            String use = r;
    //            if (!Tools.Strings.StrExt(use))
    //                use = "[blank]";

    //            ReportLine l = LineAdd();

    //            l.SetInc(use);
    //            l.SetInc(selectedLines.Count);

    //            List<ReportTotal> sliceTotals = new List<ReportTotal>();
    //            foreach (ReportTotal t in originalTotals)
    //            {
    //                sliceTotals.Add(t.CloneZeroValue());
    //            }

    //            foreach (ReportLine sel in selectedLines)
    //            {
    //                foreach (ReportTotal t in sliceTotals)
    //                {
    //                    if (t.ValueColumn < 0)
    //                        throw new Exception("Value column missing");

    //                    t.Value += Convert.ToDouble(sel.Cells[t.ValueColumn].Value);
    //                }
    //            }

    //            SetTotalsInc(sliceTotals, l);
    //        }
    //    }

    //    public List<ReportLine> LinesByValue(int colIndex, Object value)
    //    {
    //        return LinesByValue(Lines, colIndex, value);
    //    }

    //    public static List<ReportLine> LinesByValue(List<ReportLine> startingLines, int colIndex, Object value)
    //    {
    //        String s2 = Convert.ToString(value).ToLower().Trim();

    //        List<ReportLine> ret = new List<ReportLine>();
    //        foreach (ReportLine l in startingLines)
    //        {
    //            String s1 = Convert.ToString(l.Cells[colIndex].Value).ToLower().Trim();
    //            if (s1 == s2 || (s1 == "true" && s2 == "y") || (s2 == "true" && s1 == "y") || (s1 == "[blank]" && s2 == "") || (s2 == "[blank]" && s1 == "") || (s1 == "false" && s2 == "[blank]") || (s2 == "false" && s1 == "") || (s1 == "false" && s2 == ""))
    //                ret.Add(l);
    //        }
    //        return ret;
    //    }

    //    ReportColumn ColumnByIndex(int colIndex)
    //    {
    //        return ColumnsList[colIndex];
    //    }

    //    public void SetTotalsInc(ReportLine l)
    //    {
    //        SetTotalsInc(Totals, l);
    //    }

    //    public static void SetTotalsInc(List<ReportTotal> totals, ReportLine l)
    //    {
    //        foreach (ReportTotal t in totals)
    //        {
    //            if (t is ReportTotalPercent)
    //                l.SetInc(Math.Round(t.Value, 1), Math.Round(t.Value, 1).ToString() + "%");
    //            else if (t is ReportTotalInteger)
    //                l.SetInc(Convert.ToInt32(t.Value));
    //            else if (t is ReportTotalMinutes)
    //                l.SetInc(Convert.ToInt32(t.Value), Tools.Dates.FormatDHMLetter(Convert.ToInt32(t.Value)));
    //            else
    //                l.SetInc(t.Value);
    //        }
    //    }

    //    public bool ChartColumn(ReportColumn c)
    //    {
    //        if (c.ValueUse == ValueUse.Ignore)
    //            return false;

    //        if (VarVal.UseIsNumeric(c.ValueUse))
    //            return true;

    //        if (Lines.Count == 0)
    //            return false;

    //        try
    //        {
    //            Object v = Lines[0].Cells[c.Index].Value;
    //            return v is Double || v is Int32;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }

    //    public void SortByColumnIndex(int colIndex)
    //    {
    //        ReportColumn col = null;
    //        int i = 0;

    //        foreach (KeyValuePair<String, ReportColumn> k in Columns)
    //        {
    //            if (i == colIndex)
    //            {
    //                col = k.Value;
    //                break;
    //            }
    //            i++;
    //        }

    //        if (col == null)
    //            return;

    //        if (Tools.Strings.StrCmp(col.Caption, SortColumn))
    //        {
    //            if (SortDirection == SortDirection.Ascending)
    //                SortDirection = SortDirection.Descending;
    //            else
    //                SortDirection = SortDirection.Ascending;
    //        }
    //        else
    //        {
    //            SortDirection = SortDirection.Ascending;
    //            SortColumn = col.Caption;
    //        }

    //        ReportLineComparison comp = new ReportLineComparison(colIndex, (SortDirection == SortDirection.Descending));
    //        Lines.Sort(comp);
    //    }

    //    public void InferColumnOptions(ContextRz context)
    //    {
    //        foreach (ReportColumn c in ColumnsList)
    //        {
    //            if (c.ValueUse == ValueUse.Ignore)
    //                continue;

    //            if (VarVal.UseIsNumeric(c.ValueUse))
    //                continue;

    //            //if (c.Attribute != null)
    //            //{
    //            //    if( c.Attribute.TheFieldType != FieldType.String )
    //            //        continue;
    //            //}
    //            //else
    //            //{

    //            if (c.Caption.ToLower().Contains("date"))
    //                continue;

    //            if (c.Caption.Contains("#"))
    //                continue;

    //            //}

    //            if (c.Alignment == ColumnAlignment.Left)  //infer the textual fields
    //            {
    //                int uniqueValues = UniqueStringsList(c.Index).Count;
    //                int lineCount = Lines.Count;
    //                if (uniqueValues <= 1)
    //                    continue;

    //                if (uniqueValues == lineCount)
    //                    continue;

    //                int percent = Tools.Number.CalcPercent(lineCount, uniqueValues);
    //                if (percent < 60)
    //                {
    //                    c.ColumnSummary = true;
    //                    c.ColumnSummaryCount = uniqueValues;
    //                }
    //            }
    //        }
    //    }

    //    public List<String> UniqueStringsList(int columnIndex)
    //    {
    //        List<string> ret = new List<string>();
    //        List<String> compare = new List<string>();
    //        foreach (ReportLine l in Lines)
    //        {
    //            if (l.Cells.Count >= columnIndex)
    //            {
    //                String val = l.Cells[columnIndex].Caption.Trim();
    //                if (!compare.Contains(val.ToLower()))
    //                {
    //                    ret.Add(val);
    //                    compare.Add(val.ToLower());
    //                }
    //            }
    //        }
    //        return ret;
    //    }
    //}
    //public class ReportLineComparison : IComparer<ReportLine>
    //{
    //    int Column;
    //    bool Desc;

    //    public ReportLineComparison(int col, bool desc)
    //    {
    //        Column = col;
    //        Desc = desc;
    //    }

    //    public int Compare(ReportLine lx, ReportLine ly)
    //    {
    //        try
    //        {
    //            IComparable ox = (IComparable)lx.Cells[Column].Value;
    //            IComparable oy = (IComparable)ly.Cells[Column].Value;

    //            int ret = ox.CompareTo(oy);

    //            if (Desc)
    //                ret *= -1;

    //            return ret;
    //        }
    //        catch { return 0; }
    //    }
    //}
    //public class ReportArgs
    //{
    //    public List<ReportCriteria> Criteria = new List<ReportCriteria>();
    //    public String ErrorMessage = "";

    //    public ReportArgs(ContextRz context)
    //    {
    //    }

    //    public virtual bool ValidCheck(ContextRz context)
    //    {
    //        return true;
    //    }

    //    public override string ToString()
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        bool first = true;
    //        foreach (ReportCriteria cr in Criteria)
    //        {
    //            if (cr.ExcludeFromCaption)
    //                continue;

    //            String c = cr.ValueCaption;
    //            if (Tools.Strings.StrExt(c) && !Tools.Strings.StrCmp(c, "all"))
    //            {
    //                if (!first)
    //                    sb.Append(" ");
    //                sb.Append(c);
    //                first = false;
    //            }
    //        }

    //        return sb.ToString();
    //    }

    //    public ReportCriteria CriteriaById(String criteriaId)
    //    {
    //        foreach (ReportCriteria c in Criteria)
    //        {
    //            if (c.Uid == criteriaId)
    //                return c;
    //        }
    //        return null;
    //    }

    //    public ReportArgs Clone(ContextRz context)
    //    {
    //        ReportArgs ret = (ReportArgs)Activator.CreateInstance(GetType(), new object[] { context });
    //        foreach (ReportCriteria c in Criteria)
    //        {
    //            ReportCriteria retc = ret.CriteriaById(c.Uid);
    //            if (retc == null)
    //                throw new Exception("Report criteria exception");

    //            c.ApplyTo(context, retc);
    //        }
    //        return ret;
    //    }

    //    public bool Matches(ReportArgs args)
    //    {
    //        foreach (ReportCriteria c in Criteria)
    //        {
    //            ReportCriteria cc = args.CriteriaById(c.Uid);
    //            if (cc == null)
    //                throw new Exception("Criteria mis-match");

    //            if (!c.Matches(cc))
    //                return false;
    //        }

    //        return true;
    //    }
    //}
    //public abstract class ReportCriteria
    //{
    //    public String Caption;
    //    public String Description = "";
    //    public bool ExcludeFromCaption = false;

    //    public ReportCriteria(String caption)
    //    {
    //        Caption = caption;
    //    }

    //    public String Uid
    //    {
    //        get
    //        {
    //            return Tools.Strings.FilterTrash(Caption).ToLower();
    //        }
    //    }

    //    public virtual String ValueCaption
    //    {
    //        get
    //        {
    //            return "Value";
    //        }
    //    }
    //    public virtual bool Exists()
    //    {
    //        return false;
    //    }
    //    public virtual void Clear()
    //    {

    //    }

    //    public abstract void ApplyTo(ContextRz context, ReportCriteria c);
    //    public abstract bool Matches(ReportCriteria c);
    //}
    //public class ReportCriteriaDateRange : ReportCriteria
    //{
    //    public Tools.Dates.DateRange TheRange = new Tools.Dates.DateRange();
    //    public bool AllowAny = true;
    //    public bool AllowPast = true;
    //    public bool AllowFuture = true;
    //    public bool IncludeDayOptions = true;
    //    public String DefaultOption = "Any Date";
    //    public bool AllowNonDefault = true;
    //    public bool AnyIsNone = false;
    //    //public bool RequireSpecificRange = false;

    //    public ReportCriteriaDateRange(String caption)
    //        : base(caption)
    //    {
    //    }

    //    public override string ValueCaption
    //    {
    //        get
    //        {
    //            if (TheRange == null)
    //                return "";
    //            //else if (TheRange.TodayIs)
    //            //    return "Today";
    //            //else if (TheRange.YesterdayIs)
    //            //    return "Yesterday";
    //            else if (TheRange.IsThisMonthSoFar)
    //                return "This Month";
    //            //else if (TheRange.LastMonthIs)
    //            //    return "Last Month";
    //            else if (TheRange.IsYearToDate)
    //                return "Year To Date " + Tools.Dates.DateFormat(TheRange.EndDate);
    //            else
    //                return TheRange.Caption;
    //        }
    //    }
    //    public override bool Exists()
    //    {
    //        if (TheRange == null)
    //            return false;
    //        return TheRange.Valid;
    //    }

    //    public override void ApplyTo(ContextRz context, ReportCriteria c)
    //    {
    //        ReportCriteriaDateRange ret = (ReportCriteriaDateRange)c;
    //        ret.TheRange = new Tools.Dates.DateRange(TheRange);
    //        ret.AllowAny = AllowAny;
    //        ret.AllowPast = AllowPast;
    //        ret.AllowFuture = AllowFuture;
    //        ret.IncludeDayOptions = IncludeDayOptions;
    //        ret.DefaultOption = DefaultOption;
    //        ret.AnyIsNone = AnyIsNone;
    //    }

    //    public override bool Matches(ReportCriteria c)
    //    {
    //        ReportCriteriaDateRange cc = (ReportCriteriaDateRange)c;
    //        if (Tools.Dates.DateExists(TheRange.StartDate))
    //        {
    //            if (!Tools.Dates.IsSameDay(TheRange.StartDate, cc.TheRange.StartDate))
    //                return false;
    //        }
    //        else
    //        {
    //            if (Tools.Dates.DateExists(cc.TheRange.StartDate))
    //                return false;
    //        }

    //        if (Tools.Dates.DateExists(TheRange.EndDate))
    //        {
    //            if (!Tools.Dates.IsSameDay(TheRange.EndDate, cc.TheRange.EndDate))
    //                return false;
    //        }
    //        else
    //        {
    //            if (Tools.Dates.DateExists(cc.TheRange.EndDate))
    //                return false;
    //        }

    //        return true;
    //    }
    //}
    //public class ReportCriteriaString : ReportCriteria
    //{
    //    public String Value = "";

    //    public ReportCriteriaString(String caption)
    //        : base(caption)
    //    {
    //    }

    //    public override string ValueCaption
    //    {
    //        get
    //        {
    //            if (Tools.Strings.StrExt(Value))
    //                return Caption + ": " + Value;
    //            else
    //                return "";
    //        }
    //    }
    //    public override bool Exists()
    //    {
    //        return Tools.Strings.StrExt(Value);
    //    }

    //    public override void ApplyTo(ContextRz context, ReportCriteria c)
    //    {
    //        ReportCriteriaString ret = (ReportCriteriaString)c;
    //        ret.Value = Value;
    //    }

    //    public override bool Matches(ReportCriteria c)
    //    {
    //        ReportCriteriaString cc = (ReportCriteriaString)c;
    //        return Tools.Strings.StrCmp(Value, cc.Value);
    //    }
    //}
    //public class ReportCriteriaBoolean : ReportCriteria
    //{
    //    public bool Value;
    //    String TrueValueCaption;
    //    String FalseValueCaption;
    //    public ReportCriteriaBoolean(String caption, String trueValueCaption, String falseValueCaption)
    //        : base(caption)
    //    {
    //        TrueValueCaption = trueValueCaption;
    //        FalseValueCaption = falseValueCaption;
    //    }

    //    public override bool Exists()
    //    {
    //        return true;
    //    }

    //    public override string ValueCaption
    //    {
    //        get
    //        {
    //            if (Value)
    //                return TrueValueCaption;
    //            else
    //                return FalseValueCaption;
    //        }
    //    }

    //    public override void ApplyTo(ContextRz context, ReportCriteria c)
    //    {
    //        ReportCriteriaBoolean ret = (ReportCriteriaBoolean)c;
    //        ret.Value = Value;
    //    }

    //    public override bool Matches(ReportCriteria c)
    //    {
    //        ReportCriteriaBoolean cc = (ReportCriteriaBoolean)c;
    //        return Value == cc.Value;
    //    }
    //}
    //public class ReportCriteriaRadio : ReportCriteria
    //{
    //    public String SelectedCaption = "";
    //    public List<String> ValueCaptions;
    //    public ReportCriteriaRadio(String caption, List<String> valueCaptions)
    //        : base(caption)
    //    {
    //        ValueCaptions = valueCaptions;
    //        if (valueCaptions.Count > 0)
    //            SelectedCaption = valueCaptions[0];
    //        else
    //            SelectedCaption = "";
    //    }

    //    public override bool Exists()
    //    {
    //        return true;
    //    }

    //    public override string ValueCaption
    //    {
    //        get
    //        {
    //            return SelectedCaption;
    //        }
    //    }

    //    public override void ApplyTo(ContextRz context, ReportCriteria c)
    //    {
    //        ReportCriteriaRadio ret = (ReportCriteriaRadio)c;
    //        ret.SelectedCaption = SelectedCaption;
    //    }

    //    public override bool Matches(ReportCriteria c)
    //    {
    //        ReportCriteriaRadio cc = (ReportCriteriaRadio)c;
    //        return Tools.Strings.StrCmp(SelectedCaption, cc.SelectedCaption);
    //    }
    //}
    //public class ReportCriteriaNameID : ReportCriteria
    //{
    //    public String TheID = "";
    //    public String TheName = "";

    //    public ReportCriteriaNameID(String caption)
    //        : base(caption)
    //    {
    //    }

    //    public override string ValueCaption
    //    {
    //        get
    //        {
    //            if (Tools.Strings.StrExt(TheName))
    //                return TheName;  //2011_09_23 took this out: Caption + "-" + 
    //            else
    //                return "";
    //        }
    //    }
    //    public override bool Exists()
    //    {
    //        if (!Tools.Strings.StrExt(TheID))
    //            return false;
    //        if (!Tools.Strings.StrExt(TheName))
    //            return false;
    //        return true;
    //    }
    //    public override void Clear()
    //    {
    //        TheID = "";
    //        TheName = "";
    //    }

    //    public override void ApplyTo(ContextRz context, ReportCriteria c)
    //    {
    //        ReportCriteriaNameID ret = (ReportCriteriaNameID)c;
    //        ret.TheID = TheID;
    //        ret.TheName = TheName;
    //    }

    //    public override bool Matches(ReportCriteria c)
    //    {
    //        ReportCriteriaNameID cc = (ReportCriteriaNameID)c;
    //        return cc.TheID == TheID && cc.TheName == TheName;

    //    }
    //}
    //public class ReportCriteriaAgent : ReportCriteria
    //{
    //    public List<String> AgentIds = new List<string>();
    //    public ReportCriteriaAgent(String caption)
    //        : base(caption)
    //    {
    //    }

    //    public override bool Exists()
    //    {
    //        return AgentIds.Count > 0;
    //    }

    //    public override string ValueCaption
    //    {
    //        get
    //        {
    //            if (AgentIds.Count == 0)
    //                return "";
    //            else
    //                return Tools.Strings.PluralizePhrase("Agent", AgentIds.Count);
    //        }
    //    }

    //    public override void ApplyTo(ContextRz context, ReportCriteria c)
    //    {
    //        ((ReportCriteriaAgent)c).AgentIds.AddRange(AgentIds);
    //    }

    //    public override bool Matches(ReportCriteria c)
    //    {
    //        ReportCriteriaAgent cc = ((ReportCriteriaAgent)c);
    //        if (cc.AgentIds.Count != AgentIds.Count)
    //            return false;

    //        foreach (String s in AgentIds)
    //        {
    //            if (!cc.AgentIds.Contains(s))
    //                return false;
    //        }

    //        return true;
    //    }
    //}
    public class ReportCriteriaCompany : ReportCriteriaNameID
    {
        public int NameColumn = -1;
        public ReportCriteriaCompany(String caption)
            : base(caption)
        {
        }

        public override void ApplyTo(Context context, ReportCriteria c)
        {
            base.ApplyTo(context, c);
            ((ReportCriteriaCompany)c).NameColumn = NameColumn;
        }

        public List<String> GetUniqueCompanyIds(ContextRz context, Report report, ReportArgs args)
        {
            Report copy = (Report)Activator.CreateInstance(report.GetType(), new Object[] { context });
            copy.Calculate(context, args);

            List<String> retNames = copy.UniqueStringsList(NameColumn);
            retNames.Sort();
            List<String> retIds = new List<string>();
            foreach (String s in retNames)
            {
                retIds.Add(company.TranslateNameToID(context, s));
            }
            return retIds;
        }
    }
    //public class ReportSection : IDisposable
    //{
    //    public Dictionary<String, ReportSection> Sections = new Dictionary<String, ReportSection>();
    //    public List<ReportLine> Lines = new List<ReportLine>();
    //    public List<ReportTotal> Totals = new List<ReportTotal>();
    //    public bool InsertSpaceBelow = true;
    //    public bool ShowColumnCaptions = false;

    //    String m_Caption = "";


    //    public ReportSection()
    //        : this("")
    //    {

    //    }

    //    public ReportSection(String caption)
    //    {
    //        m_Caption = caption;
    //    }

    //    public virtual void Dispose()
    //    {
    //        if (Totals != null)
    //        {
    //            Totals.Clear();
    //            Totals = null;
    //        }

    //        if (Sections != null)
    //            Sections.Clear();
    //    }

    //    public virtual String Caption
    //    {
    //        get
    //        {
    //            if (m_Caption != "")
    //                return m_Caption;
    //            else
    //                return "";
    //        }

    //        set
    //        {
    //            m_Caption = value;
    //        }
    //    }

    //    public List<ReportSection> SectionsList
    //    {
    //        get
    //        {
    //            List<ReportSection> ret = new List<ReportSection>();
    //            foreach (KeyValuePair<String, ReportSection> k in Sections)
    //            {
    //                ret.Add(k.Value);
    //            }

    //            return ret;
    //        }
    //    }

    //    public void Sort(ReportLineComparison comp)
    //    {
    //        Lines.Sort(comp);
    //        foreach (ReportSection s in SectionsList)
    //        {
    //            s.Sort(comp);
    //        }
    //    }

    //    public int ResultCount
    //    {
    //        get
    //        {
    //            int ret = Lines.Count;
    //            foreach (ReportSection s in SectionsList)
    //            {
    //                ret += s.Lines.Count;
    //            }
    //            return ret;
    //        }
    //    }
    //}
    //public class ReportColumn
    //{
    //    public String Name;
    //    public String Caption;
    //    public int Index = 0;
    //    public ColumnAlignment Alignment = ColumnAlignment.Left;
    //    public bool Numeric = false;
    //    public FieldType FieldType = FieldType.Unknown;
    //    public ValueUse ValueUse = ValueUse.Any;
    //    public bool ColumnSummary = false;
    //    public int ColumnSummaryCount = 0;
    //    //public CoreVarValAttribute Attribute;

    //    public ReportColumn(String captionAndName)
    //        : this(captionAndName, captionAndName, ColumnAlignment.Left)
    //    {

    //    }

    //    public ReportColumn(String captionAndName, ColumnAlignment align)
    //        : this(captionAndName, captionAndName, align)
    //    {

    //    }

    //    public ReportColumn(String name, String caption)
    //        : this(name, caption, ColumnAlignment.Left)
    //    {

    //    }

    //    public ReportColumn(String caption, ValueUse use)
    //        : this(caption, ColumnAlignment.Right)
    //    {
    //        ValueUse = use;

    //        if (VarVal.UseIsNumeric(ValueUse))
    //            Alignment = ColumnAlignment.Right;
    //        else
    //            Alignment = ColumnAlignment.Left;
    //    }

    //    //public ReportColumn(String caption, CoreVarValAttribute attribute)
    //    //    : this(caption, attribute.ValueUse)
    //    //{
    //    //    Attribute = attribute;
    //    //}

    //    public ReportColumn(String name, String caption, ColumnAlignment alignment)
    //    {
    //        Alignment = alignment;
    //        Name = name.ToLower().Trim();
    //        Caption = caption;
    //    }
    //}
    //public class ReportLine
    //{
    //    public List<ReportCell> Cells = new List<ReportCell>();
    //    public Color ForeColor = System.Drawing.Color.Black;
    //    public ReportArgs SummaryArgs = null;
    //    public String Uid = Tools.Strings.GetNewID();
    //    int NextIndex = -1;

    //    public ReportCell SetInc(String displayAndCompareValue)
    //    {
    //        NextIndex++;
    //        return Set(NextIndex, displayAndCompareValue);
    //    }

    //    public ReportCell Set(int index, String displayAndCompareValue)
    //    {
    //        return Set(index, displayAndCompareValue, displayAndCompareValue, null);
    //    }

    //    public ReportCell Set(int index, String displayAndCompareValue, ItemTag t)
    //    {
    //        return Set(index, displayAndCompareValue, displayAndCompareValue, t);
    //    }

    //    public ReportCell SetInc(Object compareValue, String displayValue)
    //    {
    //        NextIndex++;
    //        return Set(NextIndex, compareValue, displayValue);
    //    }

    //    public ReportCell SetInc(DateTime value)
    //    {
    //        return SetInc(value, Tools.Dates.DateFormat(value));
    //    }

    //    public ReportCell SetInc(int value)
    //    {
    //        return SetInc(value, Tools.Number.LongFormat(value));
    //    }

    //    public ReportCell SetInc(String displayAndCompareValue, Color color)
    //    {
    //        NextIndex++;
    //        return Set(NextIndex, displayAndCompareValue, displayAndCompareValue, color);
    //    }

    //    public ReportCell SetIncBlankZero(int value, String command = "")
    //    {
    //        String display = "";
    //        if (value != 0)
    //            display = Tools.Number.LongFormat(value);

    //        return SetInc(value, display, null, command: command);
    //    }

    //    public ReportCell SetInc(long value)
    //    {
    //        return SetInc(value, Tools.Number.LongFormat(value));
    //    }

    //    public ReportCell SetInc(Double value)
    //    {
    //        return SetInc(value, "$" + Tools.Number.MoneyFormat(value));
    //    }

    //    public ReportCell SetInc(Boolean value)
    //    {
    //        if (value)
    //            return SetInc(true, "Y");
    //        else
    //            return SetInc(false, "");
    //    }

    //    public ReportCell Set(int index, Object compareValue, String displayValue)
    //    {
    //        return Set(index, compareValue, displayValue, null);
    //    }

    //    public ReportCell Set(int index, Object compareValue, String displayValue, Color color)
    //    {
    //        return Set(index, compareValue, displayValue, null, "", color);
    //    }

    //    public ReportCell SetInc(String displayAndCompareValue, ItemTag t)
    //    {
    //        return SetInc(displayAndCompareValue, displayAndCompareValue, t);
    //    }

    //    public ReportCell SetInc(Object compareValue, String displayValue, ItemTag t, String command = "")
    //    {
    //        NextIndex++;
    //        return Set(NextIndex, compareValue, displayValue, t, command: command);
    //    }

    //    public ReportCell Set(int index, Object compareValue, String displayValue, ItemTag t, String command = "")
    //    {
    //        return Set(index, compareValue, displayValue, t, "", Color.Black, command: command);
    //    }
    //    public ReportCell Set(int index, Object compareValue, String displayValue, ItemTag t, string format, String command = "")
    //    {
    //        return Set(index, compareValue, displayValue, t, format, Color.Black, command: command);
    //    }
    //    public ReportCell Set(int index, Object compareValue, String displayValue, ItemTag t, string format, Color color, String command = "")
    //    {
    //        if (index < 0)
    //            return null;

    //        while (Cells.Count <= index)
    //        {
    //            ReportCell r = new ReportCell();
    //            Cells.Add(r);
    //        }

    //        ReportCell ret = Cells[index];

    //        ret.ItemTag = t;
    //        ret.Value = compareValue;
    //        ret.Caption = displayValue;
    //        ret.Format = format;
    //        ret.Color = color;

    //        if (Tools.Strings.StrExt(command))
    //            ret.Command = command;

    //        return ret;
    //    }
    //}
    //public class ReportCell
    //{
    //    public String Caption = "";
    //    public String Format = "";
    //    public Object Value = null;
    //    public ItemTag ItemTag;
    //    public Color Color;
    //    public String Command = "";
    //    public String Formula = "";

    //    public ReportCell()
    //    {

    //    }

    //    public ReportCell(String value)
    //    {
    //        Caption = value;
    //    }
    //}
    //public class ReportTotal
    //{
    //    public String Name;
    //    public String Caption;
    //    public Double Value = 0;
    //    public int CaptionColumn = -1;
    //    public int ValueColumn = -1;
    //    public int Overline = 0;
    //    public int Underline = 0;
    //    public bool Auto = false;
    //    public bool IncludeDecimals = true;
    //    public ValueUse ValueUse = ValueUse.Any;
    //    public bool ColumnBound = true;

    //    public ReportTotal(String caption)
    //        : this(caption.ToLower().Trim(), caption)
    //    {

    //    }

    //    public ReportTotal(String name, String caption)
    //    {
    //        Name = name.ToLower().Trim();
    //        Caption = caption;
    //    }

    //    public virtual string Render()
    //    {
    //        if (IncludeDecimals)
    //            return "$" + Tools.Number.MoneyFormat(Value);
    //        else
    //            return "$" + Tools.Number.LongFormat(Value);
    //    }

    //    public virtual Color Color
    //    {
    //        get
    //        {
    //            return Color.Black;
    //        }
    //    }

    //    public ReportTotal CloneZeroValue()
    //    {
    //        ReportTotal ret = (ReportTotal)Activator.CreateInstance(GetType(), new Object[] { Caption });
    //        ApplyTo(ret);
    //        ret.Value = 0;
    //        return ret;
    //    }

    //    protected virtual void ApplyTo(ReportTotal t)
    //    {
    //        t.Name = Name;
    //        t.Caption = Caption;
    //        t.Value = Value;
    //        t.CaptionColumn = CaptionColumn;
    //        t.ValueColumn = ValueColumn;
    //        t.Overline = Overline;
    //        t.Underline = Underline;
    //        t.Auto = Auto;
    //        t.IncludeDecimals = IncludeDecimals;
    //        t.ValueUse = ValueUse;
    //    }
    //}
    //public class ReportTotalPercent : ReportTotal
    //{
    //    public ReportTotalPercent(String caption)
    //        : base(caption)
    //    {
    //    }

    //    public override string Render()
    //    {
    //        if (IncludeDecimals)
    //            return String.Format("{0:##0.0}", Value) + "%";
    //        else
    //            return String.Format("{0:##0}", Value) + "%";
    //    }
    //}
    //public class ReportTotalInteger : ReportTotal
    //{
    //    public ReportTotalInteger(String caption)
    //        : base(caption)
    //    {
    //    }

    //    public override string Render()
    //    {
    //        return Tools.Number.LongFormat(Value);
    //    }
    //}
    //public class ReportTotalMinutes : ReportTotal
    //{
    //    public ReportTotalMinutes(String caption, int captionColumn, int valueColumn)
    //        : base(caption)
    //    {
    //        CaptionColumn = captionColumn;
    //        ValueColumn = valueColumn;
    //    }

    //    public override string Render()
    //    {
    //        return Tools.Dates.FormatDHMLetter(Convert.ToInt32(Value));
    //    }
    //}
    //public class ReportTarget
    //{
    //    protected bool InBody = false;

    //    public virtual void Render(ContextRz context, Report r)
    //    {
    //        try
    //        {
    //            RenderHeading(r);
    //            RenderBodyStart(r);
    //            RenderColumns(r);
    //            RenderSection(r, r, true);
    //            RenderBodyEnd(r);
    //            RenderFooter(r);
    //            RenderSubReports(context, r);
    //        }
    //        catch (Exception ex)
    //        {
    //            context.TheLeader.Error(ex);
    //        }
    //    }

    //    protected void RenderSection(Report r, ReportSection s, bool firstIs)
    //    {
    //        if (!firstIs && r != s && s.ShowColumnCaptions)
    //            RenderColumns(r);

    //        if (r != s && Tools.Strings.StrExt(s.Caption))
    //            RenderSectionCaption(r, s);

    //        RenderSections(r, s);
    //        RenderLines(r, s);
    //        RenderTotals(r, s);

    //        if (s.InsertSpaceBelow)
    //            AddSeparator(r);
    //    }

    //    protected virtual void RenderSectionCaption(Report r, ReportSection s)
    //    {

    //    }

    //    protected virtual void RenderHeading(Report r)
    //    {
    //        if (r.HeadingSection != null)
    //        {
    //            RenderSection(r, r.HeadingSection, true);
    //        }
    //    }


    //    protected virtual void RenderFooter(Report r)
    //    {
    //    }

    //    protected virtual void RenderSubReports(ContextRz context, Report r)
    //    {
    //        foreach (Report subReport in r.SubReports)
    //        {
    //            Render(context, subReport);
    //        }
    //    }

    //    protected virtual void RenderColumns(Report r)
    //    {
    //    }

    //    protected virtual void RenderSections(Report r, ReportSection s)
    //    {
    //        bool first = true;
    //        foreach (ReportSection rs in s.SectionsList)
    //        {
    //            RenderSection(r, rs, first);
    //            first = false;
    //        }
    //    }

    //    protected virtual void RenderLines(Report r, ReportSection s)
    //    {
    //        foreach (ReportLine l in s.Lines)
    //        {
    //            RenderLine(r, s, l);
    //        }
    //    }

    //    protected virtual void RenderTotals(Report r, ReportSection s)
    //    {
    //    }

    //    protected virtual void RenderBodyStart(Report r)
    //    {
    //        InBody = true;
    //    }

    //    protected virtual void RenderBodyEnd(Report r)
    //    {
    //        InBody = false;
    //    }

    //    protected virtual void RenderTotals(ReportSection r)
    //    {
    //    }

    //    public virtual void Comment(String comment)
    //    {
    //    }

    //    public virtual void Comment(Report r, ReportSection s, String strLine, System.Drawing.Color color, bool boolBold)
    //    {
    //        //ReportLine l= new ReportLine();
    //        //s.Lines.Add(l);
    //        //r.Set(l, "Comment"
    //    }

    //    public void AddDataTable(String strCaption, DataTable d)
    //    {
    //        AddDataTable(strCaption, d, null, null);
    //    }

    //    public virtual void AddDataTable(String strCaption, DataTable d, ArrayList aligns, ArrayList formats)
    //    {
    //    }

    //    public virtual void AddDataTable(String strCaption, List<SummaryLine> summaries, DataTable d, ArrayList aligns, ArrayList formats)
    //    {

    //    }

    //    public virtual void RenderLine(Report r, ReportSection s, ReportLine l)
    //    {

    //    }

    //    public virtual void AddSeparator(Report r)
    //    {
    //    }

    //    public virtual void AddHeading(String s)
    //    {
    //    }

    //    public virtual void AddHeading2(String s)
    //    {
    //        AddHeading(s);
    //    }

    //    public virtual void AddHeadingExtra(DataConnection d, String s)
    //    {

    //    }

    //    public virtual void Show(ContextRz context, Report r)
    //    {

    //    }

    //    public virtual void Error(String err)
    //    {

    //    }
    //}
    //public class ReportTargetHtml : ReportTarget
    //{
    //    public static List<String> SeriesColors = new List<string>() {
        
    //        "#0128b4",
    //        "#ffa401",
    //        "#01b700",
    //        "#ff2501",
    //        "#fffa00",
    //        "#7825b5",
    //        "#9ccd00",
    //        "#00b1d3",
    //        "#fece00",
    //        "#d32890",
    //        "#ff7c00",
    //        "#0079c2",
    //        "#133aac", "#95ec00", "#d2006b", "#ffae00", "#FFEF00", "#9a9898", "#dee838", "#d016b8", "#101101", "#c24ee3", "#928496", "#ff0fad", "#bcd7a4", "#11c4a0", "#f33f7e", "#151574", "#10660a", "#e0cea9", "#825b08", "#b3f9e6", "#6503b1"
    //    };

    //    public static String SeriesColor(int index)
    //    {
    //        if (index >= SeriesColors.Count)
    //            index = SeriesColors.Count - 1;  //just use the last one if there are more series for whatever reason
    //        return SeriesColors[index];
    //    }

    //    public bool UseChartColumnColors = false;
    //    StringBuilder sb = new StringBuilder();
    //    private bool SmallFont = false;
    //    private bool ShowHyperLinks = false;

    //    public void Clear()
    //    {
    //        sb = new StringBuilder();
    //    }

    //    public ReportTargetHtml(bool use_hyper_links)
    //    {
    //        ShowHyperLinks = use_hyper_links;
    //    }
    //    protected override void RenderHeading(Report r)
    //    {
    //        if (r.Columns.Count >= 10)
    //            SmallFont = true;
    //        Write("<span class=\"rz-report\" style=\"margin: 6px\"><font size=\"5\">" + r.Caption + "</font></span><br>");
    //        base.RenderHeading(r);
    //    }

    //    protected override void RenderBodyStart(Report r)
    //    {
    //        Write("<table border=\"0\" cellpadding=\"4\" cellspacing=\"0\" style=\"margin: 6px\">");
    //        base.RenderBodyStart(r);
    //    }
    //    protected override void RenderColumns(Report r)
    //    {
    //        Write("<tr>");
    //        foreach (ReportColumn c in r.ColumnsList)
    //        {
    //            RenderColumnHeader(r, c);
    //        }
    //        Write("</tr>");
    //    }

    //    protected virtual void RenderColumnHeader(Report r, ReportColumn c)
    //    {
    //        String align = "";
    //        String before = "";
    //        String after = "";

    //        RenderColumnHeaderLink(c, ref before, ref after);

    //        if (c.Alignment == ColumnAlignment.Right)
    //            align = " align=\"right\"";
    //        else if (c.Alignment == ColumnAlignment.Center)
    //            align = " align=\"center\"";

    //        Write("<th class=\"rz-report\"" + align + " bgcolor=\"cccccc\"><b>" + before + c.Caption + after + "</b></th>");
    //    }

    //    protected virtual void RenderColumnHeaderLink(ReportColumn c, ref String hyperStart, ref String hyperEnd)
    //    {
    //        if (ShowHyperLinks)
    //        {
    //            hyperStart = "<a href=\"sort.rzl?column=" + c.Index.ToString() + "\">";
    //            hyperEnd = "</a>";
    //        }
    //    }

    //    protected override void RenderBodyEnd(Report r)
    //    {
    //        Write("</table>");
    //        base.RenderBodyEnd(r);
    //    }
    //    public void Write(String html)
    //    {
    //        sb.Append(html);
    //    }
    //    public override void AddDataTable(string strCaption, DataTable d, ArrayList aligns, ArrayList formats)
    //    {
    //        base.AddDataTable(strCaption, d, aligns, formats);
    //        Write("<br><span class=\"rz-report\">" + strCaption + "</span><br>");
    //        Write(nData.ConvertDataTableToHTML(d, formats, aligns, false));
    //    }
    //    public override void AddDataTable(string strCaption, List<SummaryLine> summaries, DataTable d, ArrayList aligns, ArrayList formats)
    //    {
    //        base.AddDataTable(strCaption, summaries, d, aligns, formats);
    //        Write("<br><span class=\"rz-report\">" + strCaption + "</span><br>");

    //        Write("<table border=\"0\" cellpadding=\"2\" cellspacing=\"2\">");
    //        WriteSummaries(summaries);
    //        Write("</table>");

    //        Write(nData.ConvertDataTableToHTML(d, formats, aligns, false));
    //    }
    //    public void WriteSummaries(List<SummaryLine> summaries)
    //    {
    //        foreach (SummaryLine l in summaries)
    //        {
    //            Write("<tr><td><span class=\"rz-report\"><font color=\"444444\">" + l.Caption + "</font></span></td><td align=\"right\"><span class=\"rz-report\">" + l.Value + "</span></td></tr>");
    //        }
    //    }
    //    public override void RenderLine(Report r, ReportSection s, ReportLine l)
    //    {
    //        base.RenderLine(r, s, l);
    //        Write("<tr>");
    //        int chartColorIndex = 0;
    //        foreach (ReportColumn col in r.ColumnsList)
    //        {
    //            String val = "";
    //            String strPrefix = "";
    //            String strPostFix = "";
    //            Color color = l.ForeColor;
    //            ReportCell c = null;
    //            try
    //            {
    //                c = l.Cells[col.Index];
    //                if (c != null)
    //                {
    //                    val = c.Caption;

    //                    if (c.Color.Name != "0" && c.Color != Color.Black)
    //                    {
    //                        color = c.Color;
    //                    }

    //                }
    //            }
    //            catch { val = "&nbsp;"; }
    //            HtmlColorGet(color, ref strPrefix, ref strPostFix);
    //            string hyper_beg = "";
    //            string hyper_end = "";
    //            if (ShowHyperLinks && c != null && Tools.Strings.StrExt(val.Replace("&nbsp;", "")))
    //                RenderHyperLink(c, ref hyper_beg, ref hyper_end);
    //            //for now this is outside of the hyper links setting, since these are handled only on the portal and the actual Item links aren't
    //            if (col.Index == 0 && l.SummaryArgs != null)
    //                RenderSummaryLink(l, ref hyper_beg, ref hyper_end);
    //            String align = "";
    //            if (col.Alignment == ColumnAlignment.Right)
    //                align = " align=\"right\"";
    //            else if (col.Alignment == ColumnAlignment.Center)
    //                align = " align=\"center\"";
    //            String classInfo = "class=\"rz-report-cell";
    //            if (r.ChartColumn(col))
    //            {
    //                classInfo += " column-series-" + chartColorIndex.ToString();
    //                chartColorIndex++;
    //            }
    //            classInfo += "\"";
    //            Write("<td " + classInfo + align + "nowrap" + ">" + strPrefix + hyper_beg + val + hyper_end + strPostFix + "</td>");
    //        }
    //        Write("</tr>");
    //    }
    //    protected virtual void RenderHyperLink(ReportCell c, ref string hyper_beg, ref string hyper_end)
    //    {
    //        if (c.ItemTag != null)
    //        {
    //            if (c.ItemTag.Valid)
    //            {
    //                hyper_beg = "<a href=\"show.rzl?cid=" + c.ItemTag.ClassId + "&uid=" + c.ItemTag.Uid + "\">";
    //                hyper_end = "</a>";
    //            }
    //        }
    //        else if (c.Command != "")
    //        {
    //            hyper_beg = "<a href=\"do.rzl?cmd=" + System.Web.HttpUtility.UrlEncode(c.Command) + "\">";
    //            hyper_end = "</a>";
    //        }
    //    }
    //    protected virtual void RenderSummaryLink(ReportLine l, ref String hyperStart, ref String hyperEnd)
    //    {
    //        hyperStart = "";
    //        hyperEnd = "";
    //    }

    //    void HtmlColorGet(Color color, ref String pre, ref String post)
    //    {
    //        if (color.Name != "0" && color != Color.Black)
    //        {
    //            pre = "<font color=\"" + Tools.Html.GetHTMLColor(color.ToArgb()) + "\">";
    //            post = "</font>";
    //        }
    //        else
    //        {
    //            pre = "";
    //            post = "";
    //        }
    //    }
    //    public String GetHTMLFontColorTag(System.Drawing.Color color)
    //    {
    //        string size = " size=\"1\"";
    //        String strPrefix = "";
    //        if (color == System.Drawing.Color.Black)
    //            strPrefix = "<font color=black>"; // +(Rz3App.xLogic.IsAAT ? size : "") + ">";
    //        if (color == System.Drawing.Color.Blue)
    //            strPrefix = "<font color=blue>"; // + (Rz3App.xLogic.IsAAT ? size : "") + ">";
    //        if (color == System.Drawing.Color.Red)
    //            strPrefix = "<font color=red>"; // + (Rz3App.xLogic.IsAAT ? size : "") + ">";
    //        if (color == System.Drawing.Color.Green)
    //            strPrefix = "<font color=green>"; // + (Rz3App.xLogic.IsAAT ? size : "") + ">";
    //        return strPrefix;
    //    }
    //    public override void AddSeparator(Report r)
    //    {
    //        Write("<tr><td colspan=" + r.Columns.Count.ToString() + ">&nbsp;</td></tr>");
    //    }
    //    protected override void RenderSectionCaption(Report r, ReportSection s)
    //    {
    //        base.RenderSectionCaption(r, s);
    //        Write("<tr><td colspan=" + r.Columns.Count.ToString() + "><span class=\"rz-report\"><b>" + s.Caption + "</b>&nbsp;</span></td></tr>");
    //    }
    //    public String HtmlResult
    //    {
    //        get
    //        {
    //            StringBuilder ret = new StringBuilder();
    //            ret.Append("<html><head>");

    //            RenderStyle(ret);

    //            ret.Append("</head><body>");
    //            ret.Append(HtmlResultInner);
    //            ret.Append("</body></html>");
    //            return ret.ToString();
    //        }
    //    }

    //    public static String SmallStyle
    //    {
    //        get
    //        {
    //            StringBuilder ret = new StringBuilder();
    //            ret.Append("<STYLE TYPE=text/css>");
    //            ret.Append("<!--");
    //            ret.Append("    body {font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 10px;}");
    //            ret.Append("-->");
    //            ret.Append("</STYLE>");
    //            return ret.ToString();
    //        }
    //    }

    //    public bool PlainStyle = false;
    //    public virtual void RenderStyle(StringBuilder ret)
    //    {
    //        ret.Append("<STYLE TYPE=text/css>");
    //        ret.Append("<!--");

    //        if (!PlainStyle)
    //        {
    //            if (SmallFont)
    //                ret.Append("    th.rz-report, td.rz-report-cell {font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 10px;}");
    //            else
    //                ret.Append("    th.rz-report, td.rz-report-cell {font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 12px;}");

    //            ret.Append("    span.rz-report {font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 12px;}");

    //            if (UseChartColumnColors)
    //            {
    //                int colorNumber = 0;
    //                foreach (String s in ReportTargetHtml.SeriesColors)
    //                {
    //                    Color color = ControlPaint.Light(ControlPaint.Light(ControlPaint.Light(ControlPaint.Light(Tools.Colors.ColorFromHex(s)))));
    //                    ret.Append(".column-series-" + colorNumber.ToString() + " { background-color: " + Tools.Html.GetHTMLColor(color) + "; }");
    //                    colorNumber++;
    //                }
    //            }
    //        }

    //        ret.Append("    a:link              { color:blue; }");
    //        ret.Append("    a:visited           { color:blue; }");
    //        ret.Append("    a:hover             { color:blue; }");
    //        ret.Append("    a:active            { color:blue; }");
    //        ret.Append("-->");
    //        ret.Append("</STYLE>");
    //    }

    //    public String HtmlResultInner
    //    {
    //        get
    //        {
    //            return sb.ToString();
    //        }
    //    }
    //    public override void AddHeading(string s)
    //    {
    //        Write("<br><hr><font size=\"18pt\">" + s + "</font><br>");
    //    }
    //    public override void AddHeading2(string s)
    //    {
    //        Write("<br><br><font color=\"blue\"><h2>" + s + "</font></h2>");
    //    }
    //    public override void Comment(string comment)
    //    {
    //        Write("<br>" + comment);
    //    }
    //    protected override void RenderTotals(Report r, ReportSection section)
    //    {
    //        base.RenderTotals(section);
    //        //int col = r.ColumnIndex(r.TotalsColumn);
    //        //if (Tools.Strings.StrExt(r.TotalsColumn))
    //        //{
    //        //    foreach (ReportTotal t in section.Totals)
    //        //    {
    //        //        string line_style = "";
    //        //        if (t.Overline > 0 && t.Underline > 0)
    //        //        {
    //        //            line_style = "style=\"";
    //        //            if (t.Overline == 1)
    //        //                line_style += "border-top:2px solid black;";
    //        //            else if (t.Overline == 2)
    //        //                line_style += "border-top:6px double black;";
    //        //            if (t.Underline == 1)
    //        //                line_style += "border-bottom:2px solid black;";
    //        //            else if (t.Underline == 2)
    //        //                line_style += "border-bottom:6px double black;";
    //        //            line_style += "\"";
    //        //        }
    //        //        else
    //        //        {
    //        //            if (t.Overline == 1)
    //        //                line_style = "style=\"border-top:2px solid black;\"";
    //        //            else if (t.Overline == 2)
    //        //                line_style = "style=\"border-top:6px double black;\"";
    //        //            if (t.Underline == 1)
    //        //                line_style = "style=\"border-bottom:2px solid black;\"";
    //        //            else if (t.Underline == 2)
    //        //                line_style = "style=\"border-bottom:6px double black;\"";
    //        //        }

    //        //        String colorPre = "";
    //        //        String colorPost = "";
    //        //        HtmlColorGet(t.Color, ref colorPre, ref colorPost);
    //        //        Write("<tr><td colspan=" + (col - 1).ToString() + "><b>" + t.Caption + ":</b></td><td align=\"right\" " + line_style + "><b>" + colorPre + t.Render() + colorPost + "</b></td></tr>");
    //        //    }
    //        //}
    //        //else
    //        //{
    //        String[] cells = new String[r.Columns.Count];
    //        foreach (ReportTotal t in section.Totals)
    //        {
    //            if (t.CaptionColumn > -1)
    //                cells[t.CaptionColumn] = "<td><span class=\"rz-report\"><b>" + t.Caption + "</b></span></td>";
    //            if (t.ValueColumn > -1)
    //            {
    //                string line_style = "";
    //                if (t.Overline > 0 && t.Underline > 0)
    //                {
    //                    line_style = "style=\"";
    //                    if (t.Overline == 1)
    //                        line_style += "border-top:2px solid black;";
    //                    else if (t.Overline == 2)
    //                        line_style += "border-top:6px double black;";
    //                    if (t.Underline == 1)
    //                        line_style += "border-bottom:2px solid black;";
    //                    else if (t.Underline == 2)
    //                        line_style += "border-bottom:6px double black;";
    //                    line_style += "\"";
    //                }
    //                else
    //                {
    //                    if (t.Overline == 1)
    //                        line_style = "style=\"border-top:2px solid black;\"";
    //                    else if (t.Overline == 2)
    //                        line_style = "style=\"border-top:6px double black;\"";
    //                    if (t.Underline == 1)
    //                        line_style = "style=\"border-bottom:2px solid black;\"";
    //                    else if (t.Underline == 2)
    //                        line_style = "style=\"border-bottom:6px double black;\"";
    //                }

    //                String colorPre = "";
    //                String colorPost = "";
    //                HtmlColorGet(t.Color, ref colorPre, ref colorPost);

    //                cells[t.ValueColumn] = "<td align=\"right\" " + line_style + "><b>" + colorPre + "<span class=\"rz-report\">" + t.Render() + "</span>" + colorPost + "</b></td>";
    //            }
    //        }
    //        Write("<tr>");
    //        foreach (String cell in cells)
    //        {
    //            if (!Tools.Strings.StrExt(cell))
    //                Write("<td>&nbsp;</td>");
    //            else
    //                Write(cell);
    //        }
    //        Write("</tr>");
    //        //}
    //    }

    //    public override void Show(ContextRz context, Report r)
    //    {
    //        base.Show(context, r);
    //        context.TheLeader.ShowHtml(r.Caption, HtmlResult);
    //    }
    //    public override void Error(string err)
    //    {
    //        base.Error(err);
    //        Write("<font color=\"red\">" + err + "</font>");
    //    }
    //}
    //public class ReportTargetExcel : ReportTarget
    //{
    //    protected int xlRow;
    //    protected ExcelPackage package;
    //    protected OfficeOpenXml.ExcelWorksheet worksheet;
    //    string file = "";

    //    public ReportTargetExcel()
    //        : this("")
    //    {
    //    }
    //    public ReportTargetExcel(String fileName)
    //        : base()
    //    {
    //        file = fileName;
    //    }

    //    bool multiSheetMode = false;
    //    public void BeginFile()
    //    {
    //        if (!Tools.Strings.StrExt(file))
    //            file = Tools.Folder.ConditionFolderName(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + Tools.Strings.GetNewID() + ".xlsx";
    //        if (package == null)
    //            package = new ExcelPackage(new FileInfo(file));

    //        multiSheetMode = true;
    //    }

    //    public void BeginSheet(String sheetName)
    //    {
    //        worksheet = package.Workbook.Worksheets.Add(sheetName);
    //        xlRow = 1;
    //    }

    //    public void InitExcel()
    //    {
    //        BeginFile();
    //        BeginSheet("Sheet1");
    //    }

    //    protected override void RenderHeading(Report r)
    //    {
    //        try
    //        {
    //            if (!multiSheetMode)
    //                InitExcel();
    //            worksheet.Cells[xlRow, 1].Value = r.Caption;
    //            worksheet.Cells[xlRow, 1].Style.Font.Bold = true;
    //        }
    //        catch { }
    //        base.RenderHeading(r);
    //    }


    //    protected override void RenderColumns(Report r)
    //    {
    //        xlRow = xlRow + 1;
    //        Int32 i = 1;
    //        foreach (ReportColumn c in r.ColumnsList)
    //        {
    //            worksheet.Cells[xlRow, i].Value = c.Caption;
    //            worksheet.Cells[xlRow, i].Style.Font.Bold = true;
    //            worksheet.Cells[xlRow, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
    //            worksheet.Cells[xlRow, i].Style.Fill.BackgroundColor.SetColor(Color.Gainsboro);
    //            worksheet.Cells[xlRow, i].Style.Font.Color.SetColor(Color.Black);
    //            i++;
    //        }
    //        xlRow++;
    //    }
    //    public override void AddDataTable(string strCaption, DataTable d, ArrayList aligns, ArrayList formats)
    //    {
    //        base.AddDataTable(strCaption, d, aligns, formats);
    //        xlRow += 2;
    //        worksheet.Cells[xlRow, 1].Value = strCaption;
    //        xlRow++;
    //        if (!Tools.Data.DataTableExists(d))
    //        {
    //            worksheet.Cells[xlRow, 1].Value = "No data.";
    //            return;
    //        }
    //        int cx = 1;
    //        foreach (DataColumn c in d.Columns)
    //        {
    //            worksheet.Cells[xlRow, cx].Value = c.Caption;
    //            cx++;
    //        }
    //        xlRow++;
    //        foreach (DataRow r in d.Rows)
    //        {
    //            cx = 1;
    //            foreach (DataColumn c in d.Columns)
    //            {
    //                Object x = r[cx - 1];
    //                if (x != null)
    //                    worksheet.Cells[xlRow, cx].Value = x.ToString();
    //                cx++;
    //            }
    //            xlRow++;
    //        }
    //    }
    //    public override void Show(ContextRz context, Report r)
    //    {
    //        base.Show(context, r);
    //        ShowExcel();
    //    }
    //    public void SaveExcel()
    //    {
    //        using (var range = worksheet.Cells[1, 1, xlRow, 50])
    //        {
    //            range.Style.Font.Name = "Calibri";
    //            range.Style.Font.Size = 12;
    //            range.AutoFitColumns(25);
    //        }
    //        package.Save();
    //    }
    //    public void ShowExcel()
    //    {
    //        if (package == null)
    //            return;

    //        SaveExcel();
    //        Tools.FileSystem.Shell(file);
    //    }
    //    public void ForceCloseExcel()
    //    {
    //        try
    //        {
    //            worksheet = null;
    //            package.Dispose();
    //            package = null;
    //        }
    //        catch (Exception)
    //        {
    //        }
    //    }
    //    public override void RenderLine(Report r, ReportSection s, ReportLine l)
    //    {
    //        try
    //        {
    //            Int32 i = 1;
    //            foreach (ReportCell c in l.Cells)
    //            {
    //                if (c.Value is DateTime && !Tools.Dates.DateExists((DateTime)c.Value))
    //                {
    //                    i++;
    //                    continue;
    //                }
    //                Object val = c.Value;
    //                if (val is Boolean)
    //                {
    //                    if ((bool)val)
    //                        val = "Y";
    //                    else
    //                        val = "";
    //                }
    //                if (val is String)
    //                    val = val.ToString().Replace("&nbsp;", "");
    //                if (!Tools.Strings.StrExt(c.Formula))
    //                {
    //                    worksheet.Cells[xlRow, i].Value = val;
    //                    worksheet.Cells[xlRow, i].Style.Numberformat.Format = GetCellFormat(c.Value, c.Format);
    //                    worksheet.Cells[xlRow, i].Style.HorizontalAlignment = GetCellAlignment(c.Value);
    //                }
    //                else
    //                {
    //                    worksheet.Cells[xlRow, i].Formula = string.Format(c.Formula, xlRow.ToString());
    //                    worksheet.Cells[xlRow, i].Style.Numberformat.Format = GetCellFormat(c.Value, c.Format);
    //                    worksheet.Cells[xlRow, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
    //                }
    //                i++;
    //            }
    //            ColorExcelRow(xlRow, l.ForeColor);
    //            xlRow++;
    //        }
    //        catch { }
    //    }
    //    protected override void RenderTotals(Report r, ReportSection section)
    //    {
    //        base.RenderTotals(section);
    //        try
    //        {
    //            foreach (ReportTotal t in section.Totals)
    //            {
    //                if (t.CaptionColumn > 0)
    //                    worksheet.Cells[xlRow, t.CaptionColumn + 1].Value = t.Caption;
    //                worksheet.Cells[xlRow, t.ValueColumn + 1].Value = t.Render();
    //            }
    //        }
    //        catch { }
    //    }
    //    private string GetCellFormat(object o, string format)
    //    {
    //        try
    //        {
    //            if (Tools.Strings.StrExt(format))
    //                return format;
    //            if (o is double)
    //                return "$#,##0.00#####";
    //            else if (o is float)
    //                return "$#,##0.00#####";
    //            else if (o is Int32)
    //                return "#,##0";
    //            else if (o is Int64)
    //                return "#,##0";
    //            else if (o is DateTime)
    //                return "mm/dd/yyyy";
    //            else
    //                return "text";
    //        }
    //        catch { }
    //        return "text";
    //    }
    //    private ExcelHorizontalAlignment GetCellAlignment(object o)
    //    {
    //        try
    //        {
    //            if (o is double)
    //                return ExcelHorizontalAlignment.Right;
    //            else if (o is float)
    //                return ExcelHorizontalAlignment.Right;
    //            else if (o is Int32)
    //                return ExcelHorizontalAlignment.Right;
    //            else if (o is Int64)
    //                return ExcelHorizontalAlignment.Right;
    //            else if (o is DateTime)
    //                return ExcelHorizontalAlignment.Left;
    //            else
    //                return ExcelHorizontalAlignment.Left;
    //        }
    //        catch { }
    //        return ExcelHorizontalAlignment.Left;
    //    }
    //    private void ColorExcelRow(long lngRow, System.Drawing.Color color)
    //    {
    //        try
    //        {
    //            int introw = Convert.ToInt32(lngRow);
    //            using (var range = worksheet.Cells[introw, 1, introw, 50])
    //            {
    //                range.Style.Font.Color.SetColor(color);
    //            }
    //        }
    //        catch
    //        { }
    //    }
    //    public override void AddSeparator(Report r)
    //    {
    //        xlRow += 2;
    //    }
    //    public override void AddHeading(string s)
    //    {
    //        xlRow += 2;
    //        worksheet.Cells[xlRow, 1].Value = s;
    //    }
    //    public override void Error(string err)
    //    {
    //        base.Error(err);
    //        worksheet.Cells[xlRow, 1].Value = err;
    //        ColorExcelRow(xlRow, Color.Red);
    //        xlRow++;
    //    }

    //    protected override void RenderSubReports(ContextRz context, Report r)
    //    {
    //        //skip these for now
    //        //maybe roll a new sheet for each?
    //        //base.RenderSubReports(context, r);
    //    }
    //}
    //public class ReportTargetCsv : ReportTarget
    //{
    //    String fileName = "";
    //    StringBuilder sb;

    //    public ReportTargetCsv(String file)
    //    {
    //        fileName = file;
    //    }
    //    protected override void RenderHeading(Report r)
    //    {
    //        try
    //        {
    //            sb = new StringBuilder();
    //        }
    //        catch { }

    //        base.RenderHeading(r);
    //    }
    //    protected override void RenderColumns(Report r)
    //    {

    //    }
    //    //public override void Comment(String strLine, System.Drawing.Color color, bool boolBold)
    //    //{
    //    //    //xlSheet.SetCellValue(xlRow, ColumnComment, strLine);
    //    //    //ColorExcelRow(xlRow, color);
    //    //    //xlRow++;
    //    //}
    //    public override void AddDataTable(string strCaption, DataTable d, ArrayList aligns, ArrayList formats)
    //    {

    //    }
    //    public override void Show(ContextRz context, Report r)
    //    {
    //        base.Show(context, r);
    //        Tools.Files.SaveStringAsFile(fileName, sb.ToString());
    //        Tools.FileSystem.Shell(fileName);
    //    }
    //    public override void RenderLine(Report r, ReportSection s, ReportLine l)
    //    {
    //        try
    //        {
    //            Int32 i = 1;
    //            foreach (ReportCell c in l.Cells)
    //            {
    //                if (i > 1)
    //                    sb.Append(",");
    //                String csv = CsvFilter(c.Caption);
    //                if (Tools.Strings.StrCmp(c.Caption, "&nbsp;"))
    //                    csv = "";
    //                if (csv.Contains(","))
    //                    csv = "\"" + csv + "\"";
    //                sb.Append(csv);
    //                i++;
    //            }
    //            sb.Append("\r\n");
    //        }
    //        catch { }
    //    }
    //    private String CsvFilter(String s)
    //    {
    //        s = s.Replace("\"", "").Replace("'", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
    //        if (s.Length > 255)
    //            s = s.Substring(0, 255);
    //        return s;
    //    }

    //    protected override void RenderSubReports(ContextRz context, Report r)
    //    {
    //        //skip these for now
    //        //base.RenderSubReports(context, r);
    //    }
    //}
    //public class ReportSqlDateRange : Report
    //{
    //    String Sql;
    //    String DateField;
    //    Tools.Dates.DateRange Range;
    //    String ManualTitle;

    //    public ReportSqlDateRange(ContextRz context)
    //        : this(context, "", "", "", new Tools.Dates.DateRange())
    //    {
    //    }

    //    public ReportSqlDateRange(ContextRz context, String title, String sql, String dateField, Tools.Dates.DateRange range)
    //        : base(context)
    //    {
    //        Sql = sql;
    //        DateField = dateField;
    //        Range = range;
    //        ManualTitle = title;
    //        Columns = new Dictionary<string, ReportColumn>();
    //        InitColumns(context);  //has to be done after the sql is set
    //    }

    //    protected override void ApplyTo(ContextRz context, Report r)
    //    {
    //        base.ApplyTo(context, r);
    //        ReportSqlDateRange rr = (ReportSqlDateRange)r;
    //        rr.Sql = Sql;
    //        rr.DateField = DateField;
    //        rr.Range = Range;
    //        rr.ManualTitle = ManualTitle;
    //        rr.InitColumns(context);
    //    }

    //    public override string Title
    //    {
    //        get
    //        {
    //            return ManualTitle;
    //        }
    //    }

    //    protected override void InitColumns(Context context)
    //    {
    //        if (!Tools.Strings.StrExt(Sql))
    //            return;

    //        String sql = GenerateSql(context, (ReportSqlDateRangeArgs)ArgsCreate(context), structureOnly: true);

    //        DataTable t = null;

    //        t = context.Select(sql);

    //        foreach (DataColumn c in t.Columns)
    //        {
    //            if (c.DataType == typeof(Int32) || c.DataType == typeof(Int64) || c.DataType == typeof(Double))
    //                ColumnAdd(c.Caption, ColumnAlignment.Right);
    //            else
    //                ColumnAdd(c.Caption);
    //        }
    //    }

    //    public override ReportArgs ArgsCreate(Context context)
    //    {
    //        return new ReportSqlDateRangeArgs(context, Range);
    //    }
    //    public override void CalculateLines(Context context, ReportArgs args)
    //    {
    //        base.CalculateLines(context, args);

    //        ReportSqlDateRangeArgs argsx = (ReportSqlDateRangeArgs)args;

    //        String sql = GenerateSql(context, argsx, structureOnly: false);

    //        DataTable t = null;

    //        t = context.Select(sql);

    //        //foreach (DataColumn c in t.Columns)
    //        //{
    //        //    ColumnAdd(new ReportColumn(c.Caption));
    //        //}

    //        foreach (DataRow r in t.Rows)
    //        {
    //            int c = 0;
    //            ReportLine l = new ReportLine();
    //            foreach (DataColumn col in t.Columns)
    //            {
    //                Object x = r[c];
    //                if (x == null || x == DBNull.Value)
    //                    l.SetInc("");
    //                else
    //                {
    //                    if (x is DateTime)
    //                        l.SetInc(x, Tools.Dates.DateFormat((DateTime)x));
    //                    else if (x is Boolean)
    //                        l.SetInc(x, Tools.Strings.YesBlankFilter((Boolean)x));
    //                    else
    //                        l.SetInc(x, x.ToString());

    //                }
    //                c++;
    //            }
    //            Lines.Add(l);
    //        }
    //    }

    //    String GenerateSql(ContextRz context, ReportSqlDateRangeArgs argsx, bool structureOnly)
    //    {
    //        String sql = Sql;

    //        if (!sql.ToLower().StartsWith("select "))
    //            throw new Exception("Every sql report needs to start with SELECT");

    //        if (structureOnly)
    //        {
    //            sql = "select top 0 " + sql.Substring(7).Replace("<daterange>", " and 1 = 0 ");

    //        }
    //        else
    //        {
    //            if (argsx.Range.TheRange.Valid)
    //                sql = sql.Replace("<daterange>", " and " + argsx.Range.TheRange.GetSQL(DateField));
    //            else
    //                sql = sql.Replace("<daterange>", "");
    //        }

    //        return sql;
    //    }
    //}
    //public class ReportSqlDateRangeArgs : ReportArgs
    //{
    //    public ReportCriteriaDateRange Range;

    //    public ReportSqlDateRangeArgs(ContextRz context)
    //        : this(context, new Tools.Dates.DateRange())
    //    {

    //    }

    //    public ReportSqlDateRangeArgs(ContextRz context, Tools.Dates.DateRange initialRange)
    //        : base(context)
    //    {
    //        Range = new ReportCriteriaDateRange("Date Range");
    //        Range.TheRange = initialRange;
    //        Range.DefaultOption = "";
    //        Criteria.Add(Range);
    //    }
    //}
    //public enum SortDirection
    //{
    //    Ascending = 0,
    //    Descending = 1,
    //}
}
