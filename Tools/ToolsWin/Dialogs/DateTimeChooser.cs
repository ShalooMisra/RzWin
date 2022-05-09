using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ToolsWin.Dialogs
{
    public partial class DateTimeChooser : ToolsWin.Dialogs.OKCancel
    {
        //Public Variables
        public DateTime DateSelected = DateTime.Now;
        public  static string Caption = "";

        //Constructors
        public DateTimeChooser()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static DateTime Choose(DateTime start, String caption)
        {
            return Choose(start, caption, false);  //2011_10_18 not the original default, but i can't think of where the time is even used
        }
        public static DateTime Choose(DateTime start, String caption, bool includeTime)
        {
            DateTimeChooser c = new DateTimeChooser();
            c.Text = caption;
            if (Tools.Dates.DateExists(start))
                c.StartSet(start);
            else
                c.StartSet(DateTime.Now);
            if (!includeTime)
                c.HideTime();
            c.ShowDialog();
            DateTime ret = c.DateSelected;
            try
            {
                c.Close();
                c.Dispose();
                c = null;
            }
            catch { }
            return ret;
        }

        public static DateTime Choose(String caption, DateTime start,  Dictionary<string, string> properties)
        {

            //Properties can contain line fields, etc. For distinguishing / Identification
            DateTimeChooser c = new DateTimeChooser();
            c.HideTime();
            Caption = caption;
            c.Text = Caption;            
            c.GetLineProperties(properties);

            if (Tools.Dates.DateExists(start))
                c.StartSet(start);
            else
                c.StartSet(DateTime.Now);

            c.ShowDialog();
            DateTime ret = c.DateSelected;
            try
            {
                c.Close();
                c.Dispose();
                c = null;
            }
            catch { }
            return ret;
        }


        //Public Override Functions
        public override void OK()
        {
            if (DateSelected == null)
                return;
            try
            {
                DateSelected = DateTime.Parse(DateSelected.Month.ToString() + "/" + DateSelected.Day.ToString() + "/" + DateSelected.Year.ToString() + " " + txtTime.Text);
            }
            catch
            {
                //DateSelected = e.Start;
            }
            base.OK();
        }
        public override void Cancel()
        {
            DateSelected = new DateTime(1900, 1, 1);
            base.Cancel();
        }
        public override void DoResize()
        {
            base.DoResize();

            int pnlDeatilsHeight = pnlLineDetails.Visible == true ? pnlLineDetails.Height : 0;
            int calendarHeight = (cal != null ? cal.Height : 0) + 30;
            int pOptionsHeight = pOptions.Height;
            int calTop = (pnlLineDetails.Visible == true ? pnlLineDetails.Bottom : lblTitle.Bottom) + 5;
            int pOptionsTop = (cal != null ? cal.Bottom : 0);

            
            cal.Left = 0;
            cal.Top = calTop;
            pOptions.Top = pOptionsTop;
            this.Width = cal.Width + (this.Width - this.ClientRectangle.Width);
            //this.Height = cal.Height + (this.Height - this.ClientRectangle.Height) + pOptions.Height + lblTitle.Height +20;
            this.Height = (this.Height - this.ClientRectangle.Height) + pOptionsHeight + calendarHeight + pnlDeatilsHeight;
            




            //try
            //{
            //    cal.Font = new Font("Microsoft Sans Serif", (float)14.25);
            //    cal.Top = 6;
            //    cal.Left = 24;
            //}
            //catch { }
        }
        //Public Functions
        public void StartSet(DateTime start)
        {
            DateSelected = start;
            cal.SetDate(start);
            txtTime.Text = start.Hour.ToString() + ":" + start.Minute.ToString();
        }
        public void HideTime()
        {
            pTime.Visible = false;
        }
        //Control Events
        private void cal_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateSelected = e.Start;
        }

        private void DateTimeChooser_Activated(object sender, EventArgs e)
        {
            DoResize();
        }

        //Private Functions
        private void GetLineProperties(Dictionary<string, string> properties)
        {
            lblTitle.Text = Caption;
            string partnumber = "";
            properties.TryGetValue("fullpartnumber", out partnumber);
            string linecode = "";
            properties.TryGetValue("linecode_sales", out linecode);
            string qty = "";
            properties.TryGetValue("quantity", out qty);

            if (!string.IsNullOrEmpty(partnumber))
            {
                pnlLineDetails.Visible = true;
                lblPartValue.Text = partnumber;
                lblLineCodeValue.Text = linecode ?? "";
                lblQtyValue.Text = qty ?? "";
            }
            else
            {
                pnlLineDetails.Visible = false;
            }            
        }
    }
}
