using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class CubeDateSelection : UserControl
    {
        public event CubeDateIntervalHandler SelectionChanged;
        public DateTime CurrentDate = System.DateTime.Now;

        private bool bInhibit = false;

        public CubeDateSelection()
        {
            InitializeComponent();
        }

        public void CompleteLoad(Tools.CubeInterval interval)
        {
            ShowCaption();
            SetSelectedInterval(interval);
        }

        public void SetSelectedInterval(Tools.CubeInterval interval)
        {
            bInhibit = true;

            try
            {
                switch (interval)
                {
                    case Tools.CubeInterval.Day:
                        optByDay.Checked = true;
                        break;
                    case Tools.CubeInterval.Week:
                        optByWeek.Checked = true;
                        break;
                    case Tools.CubeInterval.Month:
                        optByMonth.Checked = true;
                        break;
                    case Tools.CubeInterval.Quarter:
                        optByQuarter.Checked = true;
                        break;
                    case Tools.CubeInterval.Year:
                        optByYear.Checked = true;
                        break;
                }
            }
            catch(Exception)
            {}

            bInhibit = false;

        }

        private void ShowCaption()
        {
            lblCurrent.Text = nTools.DateFormat(nTools.GetStartDate(CurrentDate, GetSelectedInterval()));
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            //CurrentDate = nCube.GetPreviousDate(CurrentDate, GetSelectedInterval());
            //ChangeSelection();
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            //CurrentDate = nCube.GetNextDate(CurrentDate, GetSelectedInterval());
            //ChangeSelection();
        }

        private void cmdChoose_Click(object sender, EventArgs e)
        {
            CurrentDate = frmChooseDate.ChooseDate(CurrentDate, "Date", this.ParentForm);
            ChangeSelection();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            ChangeSelection();
        }

        private void ChangeSelection()
        {
            if( bInhibit )
                return;

            ShowCaption();
            if (SelectionChanged != null)
            {
                SelectionChanged(CurrentDate, GetSelectedInterval());
            }
        }

        public Tools.CubeInterval GetSelectedInterval()
        {
            if (optByDay.Checked)
                return Tools.CubeInterval.Day;
            else if (optByWeek.Checked)
                return Tools.CubeInterval.Week;
            else if (optByMonth.Checked)
                return Tools.CubeInterval.Month;
            else if (optByQuarter.Checked)
                return Tools.CubeInterval.Quarter;
            else if (optByYear.Checked)
                return Tools.CubeInterval.Year;

            return Tools.CubeInterval.Any;
        }

        private void optBy_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSelection();
        }
    }

    public delegate void CubeDateIntervalHandler(DateTime d, Tools.CubeInterval interval);
}
