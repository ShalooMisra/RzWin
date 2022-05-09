using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;

namespace Rz5.Win.Controls
{
    public partial class ReportCriteriaControlDateRange : ReportCriteriaControl
    {
        public ReportCriteriaDateRange TheRange
        {
            get
            {
                return (ReportCriteriaDateRange)TheCriteria;
            }
        }        
        public ReportCriteriaControlDateRange()
        {
            InitializeComponent();
        }
        public override void Init(ReportCriteria c)
        {
            base.Init(c);

            ReportCriteriaDateRange cd = (ReportCriteriaDateRange)c;

            loading = true;

            if (TheRange.AllowAny)
            {
                if (cd.AnyIsNone)
                    cboDate.Items.Add("None");
                else
                    cboDate.Items.Add("Any Date");
            }

            if (TheRange.AllowPast)
            {
                if (TheRange.IncludeDayOptions)
                    cboDate.Items.Add("Yesterday");

                cboDate.Items.Add("Last Month");

                cboDate.Items.Add("Last Week");
            }

            if (TheRange.IncludeDayOptions)
                cboDate.Items.Add("Today");

            cboDate.Items.Add("This Month");
            cboDate.Items.Add("This Week");

            if (TheRange.AllowFuture)
            {
                if (TheRange.IncludeDayOptions)
                    cboDate.Items.Add("Tomorrow");

                cboDate.Items.Add("Next Month");
            }

            cboDate.Items.Add("On");

            if (TheRange.AllowBetween)
                cboDate.Items.Add("Between");

            if (TheRange.AllowBeforeAfter)
            {
                cboDate.Items.Add("Before");
                cboDate.Items.Add("After");
            }
            if (TheRange.AllowYearToDate)
                cboDate.Items.Add("Year To Date");

            if( Tools.Strings.StrExt(TheRange.DefaultOption) )
            {
                if( !cboDate.Items.Contains(TheRange.DefaultOption) )
                    cboDate.Items.Add(TheRange.DefaultOption);

                cboDate.Text = TheRange.DefaultOption;
                if (TheRange.TheRange != null)
                {
                    dtStart.Value = TheRange.TheRange.StartDate;
                    dtEnd.Value = TheRange.TheRange.EndDate;
                }
                
                RangeCalc();
            }
            else if( Tools.Dates.DateExists(TheRange.TheRange.EndDate) && !Tools.Dates.DateExists(TheRange.TheRange.StartDate) )
            {
                dtEnd.Value = TheRange.TheRange.EndDate;
                cboDate.Text = "Before";
                RangeCalc();
            }

            loading = false;
        }
        private void cboDate_SelectedValueChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            RangeCalc();
        }
        private void RangeCalc()
        {
            switch (cboDate.Text.ToLower().Trim())
            {
                case "":
                case "none":
                case "any date":
                    dtStart.Value = Tools.Dates.NullDate;
                    dtStart.Visible = false;
                    dtEnd.Value = Tools.Dates.NullDate;
                    dtEnd.Visible = false;
                    break;
                case "yesterday":
                    dtStart.Visible = true;
                    dtEnd.Visible = false;
                    dtStart.Value = DateTime.Now.Subtract(TimeSpan.FromDays(1));
                    dtEnd.Value = dtStart.Value;
                    break;
                case "today":
                    dtStart.Visible = true;
                    dtEnd.Visible = false;
                    dtStart.Value = DateTime.Now;
                    dtEnd.Value = dtStart.Value;
                    break;
                case "tomorrow":
                    dtStart.Visible = true;
                    dtEnd.Visible = false;
                    dtStart.Value = DateTime.Now.AddDays(1);
                    dtEnd.Value = dtStart.Value;
                    break;
                case "last month":
                    dtStart.Visible = true;
                    dtEnd.Visible = true;
                    dtEnd.Value = Tools.Dates.GetMonthStart(DateTime.Now).Subtract(TimeSpan.FromDays(1));
                    dtStart.Value = Tools.Dates.GetMonthStart(dtEnd.Value);                    
                    break;
                case "this month":
                    dtStart.Visible = true;
                    dtEnd.Visible = true;
                    dtStart.Value = Tools.Dates.GetMonthStart(DateTime.Now);
                    dtEnd.Value = Tools.Dates.GetMonthEnd(DateTime.Now);
                    break;
                case "this week":
                    dtStart.Visible = true;
                    dtEnd.Visible = true;
                    dtStart.Value = Tools.Dates.GetWeekStart(DateTime.Now);
                    dtEnd.Value = DateTime.Now;
                    break;
                case "last week":
                    dtStart.Visible = true;
                    dtEnd.Visible = true;
                    DateTime mondayOfLastWeek = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek - 6);
                    dtStart.Value = mondayOfLastWeek;
                    dtEnd.Value = Tools.Dates.GetWeekEnd(mondayOfLastWeek);
                    break;
                case "next month":
                    dtStart.Visible = true;
                    dtEnd.Visible = true;
                    dtStart.Value = Tools.Dates.GetMonthEnd(DateTime.Now).AddDays(1);
                    dtEnd.Value = Tools.Dates.GetMonthEnd(dtStart.Value);
                    break;
                case "on":
                    dtStart.Visible = true;
                    dtEnd.Visible = false;
                    if (!Tools.Dates.DateExists(dtStart.Value))
                        dtStart.Value = DateTime.Now;
                    dtEnd.Value = dtStart.Value;
                    break;
                case "between":
                    dtStart.Visible = true;
                    dtEnd.Visible = true;
                    if (!Tools.Dates.DateExists(dtStart.Value))
                        dtStart.Value = DateTime.Now;
                    if (!Tools.Dates.DateExists(dtEnd.Value))
                        dtEnd.Value = Tools.Dates.GetMonthEnd(DateTime.Now);
                    break;
                case "before":
                    dtStart.Visible = false;
                    dtEnd.Visible = true;
                    if (!Tools.Dates.DateExists(dtEnd.Value))
                        dtEnd.Value = DateTime.Now;
                    dtStart.Value = Tools.Dates.NullDate;
                    break;
                case "after":
                    dtStart.Visible = true;
                    dtEnd.Visible = false;
                    if (!Tools.Dates.DateExists(dtStart.Value))
                        dtStart.Value = DateTime.Now;
                    dtEnd.Value = Tools.Dates.NullDate;
                    break;
                case "month to date":
                    dtStart.Visible = true;
                    dtEnd.Visible = true;
                    dtStart.Value = Tools.Dates.GetMonthStart(DateTime.Now);
                    dtEnd.Value = DateTime.Now;
                    break;
                case "year to date":
                    dtStart.Visible = true;
                    dtEnd.Visible = true;
                    dtStart.Value = new DateTime(DateTime.Now.Year, 1, 1);
                    dtEnd.Value = DateTime.Now;
                    break;
            }
            if (TheRange.HideEndDate)
                dtEnd.Visible = false;
            RangeSet();
        }
        private bool loading = false;
        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            switch (cboDate.Text.ToLower().Trim())
            {
                case "on":
                case "today":
                case "tomorrow":
                case "yesterday":
                    dtEnd.Value = dtStart.Value;
                    break;
                case "after":
                    dtEnd.Value = Tools.Dates.NullDate;
                    break;
            }

            RangeSet();
        }
        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            switch (cboDate.Text.ToLower().Trim())
            {
                case "before":
                    dtStart.Value = Tools.Dates.NullDate;
                    break;
            }

            RangeSet();
        }
        private void RangeSet()
        {
            TheRange.TheRange.StartDate = dtStart.Value;
            TheRange.TheRange.EndDate = dtEnd.Value;
        }

    }
}
