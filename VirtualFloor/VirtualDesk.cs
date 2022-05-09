//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;
//using System.Runtime.InteropServices;

//using NewMethod;

//namespace Rz4.VirtualFloor
//{
//    public partial class VirtualDesk : UserControl
//    {

//        ///////////////////////////////////////////////
//        //API Stuff
//        public const int WM_NCLBUTTONDOWN = 0xA1;
//        public const int HT_CAPTION = 0x2;

//        [DllImportAttribute("user32.dll")]
//        public static extern int SendMessage(IntPtr hWnd,
//                         int Msg, int wParam, int lParam);
//        [DllImportAttribute("user32.dll")]
//        public static extern bool ReleaseCapture();   
//        //////////////////////////////////////////

//        public VirtualFloor xFloor;
//        public virtual_desk xDesk;
//        //public event SoftEventHandler GotEvent;

//        public int ActivityTop = 0;

//        public VirtualDesk()
//        {
//            InitializeComponent();
//        }

//        ArrayList PaneControls = new ArrayList();
//        public void CompleteLoad(VirtualFloor f, virtual_desk d)
//        {
//            try
//            {
//                //24x45                
//                xFloor = f;
//                xDesk = d;

//                if (xDesk.Activities == null)
//                    xDesk.GatherRecentActivity(RzWin.Context);

//                int top = 45;
//                foreach (KeyValuePair<String, ActivityHandle> h in d.Activities)
//                {
//                    ActivityPane p = new ActivityPane();
//                    Controls.Add(p);
//                    p.Left = 19;
//                    p.Top = top;
//                    p.BringToFront();
//                    p.CompleteLoad(f, this, h.Value, Color.Indigo);
//                    top += p.Height;
//                    PaneControls.Add(p);
//                }

//                ShowDesk();
//                CheckSpin();
//            }
//            catch { }
//        }

//        int SpinIndex = 0;
//        public void CheckSpin()
//        {
//            try
//            {
//                int interval = 0;
//                TimeSpan t = DateTime.Now.Subtract(xDesk.LastActivity);
//                if (t.TotalMinutes < 1)
//                    interval = 20;
//                else if (t.TotalMinutes < 2)
//                    interval = 50;
//                else if (t.TotalMinutes < 4)
//                    interval = 80;

//                if (interval == 0)
//                {
//                    picSpin.Image = ilSpin.Images["desk_inactive.jpg"];
//                    picSpin.Top = 72;
//                    if (tmrSpin.Enabled)
//                        tmrSpin.Stop();
//                }
//                else
//                {
//                    picSpin.Top = 71;
//                    if (tmrSpin.Enabled)
//                    {
//                        if (tmrSpin.Interval == interval)
//                            return;

//                        tmrSpin.Stop();
//                    }
//                    tmrSpin.Interval = interval;
//                    tmrSpin.Start();
//                }
//            }
//            catch { }
//        }
        
//        public void AddActivity(user_activity a)
//        {
//            xDesk.AddActivity(a);
//            ShowDesk();
//            CheckSpin();            
//        }

//        bool NameDrawn = false;
//        public void ShowDesk()
//        {
//            //lblCaption.Text = xDesk.name;
//            //cboJobType.Text = xDesk.JobType.ToString();

//            String s = "";
//            foreach (KeyValuePair<String, ActivityHandle> kvp in xDesk.Activities)
//            {
//                ActivityHandle h = kvp.Value;
//                if (s != "")
//                    s += "\r\n";
//                s += h.Caption + ": " + nCube.DisplayFormat(h.Value, h.ValueDisplay);
//            }

//            if (!NameDrawn)
//            {
//                Graphics g = Graphics.FromImage(picDesk.Image);
//                Font xFont = new Font("Times New Romain", 12, FontStyle.Bold);
//                int width = Convert.ToInt32(g.MeasureString(xDesk.Name, xFont).Width);

//                g.DrawString(xDesk.Name, xFont, Brushes.Black, new PointF(114 - (width / 2), 119));
//                g.Dispose();
//                g = null;
//                NameDrawn = true;
//            }

//            if (!Tools.Strings.StrExt(xDesk.banner_pic))
//                xDesk.banner_pic = "banner_blue.jpg";

//            picBanner.Image = ilBanner.Images[xDesk.banner_pic];

//            lblActivity.Text = s;
//            CheckSpin();
//            ShowActivitySlices();

//            foreach (ActivityPane p in PaneControls)
//            {
//                p.ShowActivity(xFloor);
//            }
//        }

//        void ShowActivitySlices()
//        {
//            Bitmap b = new Bitmap(120, 15, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
//            Graphics g = Graphics.FromImage(b);

//            g.FillRectangle(Brushes.AntiqueWhite, new Rectangle(0, 0, b.Width, b.Height));
//            int i = 1;
//            foreach (TimeSlice t in xDesk.TimeSlices)
//            {
//                g.DrawLine(new Pen(t.Color), new Point(i, 1), new Point(i, 15));
//                i++;
//            }

//            g.Dispose();
//            g = null;
//            picSlices.Image = b;
//        }


//        private void picDrag_Click(object sender, EventArgs e)
//        {

//        }

//        private void picDrag_MouseDown(object sender, MouseEventArgs e)
//        {
//            //Enums.EdgeType nParam = GetEdgeParam(x, y);

//            //if ((Int32)nParam > 0)
//            //{
//            //    ReleaseCapture();
//            //    SendMessage(this.Handle, WM_NCLBUTTONDOWN, (Int32)nParam, 0);
//            //}
//            //else
//            //{
//                ReleaseCapture();
//                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
//            //}
//        }

//        private void VirtualDesk_MouseMove(object sender, MouseEventArgs e)
//        {
//            this.Cursor = Cursors.Default;
//        }

//        private void picDrag_MouseMove(object sender, MouseEventArgs e)
//        {
//            this.Cursor = Cursors.SizeAll;
//        }

//        private void cboJobType_Click(object sender, EventArgs e)
//        {
//            //switch (cboJobType.Text)
//            //{
//            //    case "Sales":
//            //        xDesk.JobType = JobType.Sales;
//            //        break;
//            //    case "Accounting":
//            //        xDesk.JobType = JobType.Accounting;
//            //        break;
//            //    case "Warehouse":
//            //        xDesk.JobType = JobType.Warehouse;
//            //        break;
//            //}
//        }

//        private void tmrSpin_Tick(object sender, EventArgs e)
//        {
//            String strImage = "desk_" + Tools.Strings.Right("000" + SpinIndex.ToString(), 3) + ".jpg";
//            picSpin.Image = ilSpin.Images[strImage];
//            SpinIndex++;
//            if (SpinIndex > 17)
//                SpinIndex = 0;
//        }

//        private void picBanner_Click(object sender, EventArgs e)
//        {
//            mnuBanner.Show(Cursor.Position);
//        }

//        private void mnuBanner_Opening(object sender, CancelEventArgs e)
//        {
//            if (mnuBannerColor.DropDownItems.Count == 0)
//            {
//                foreach (String s in ilBanner.Images.Keys)
//                {
//                    if (s.StartsWith("banner_"))
//                    {
//                        ToolStripItem i = mnuBannerColor.DropDownItems.Add(s);
//                        i.Tag = s;
//                        i.Click += new EventHandler(i_Click);
//                    }
//                }
//            }
//        }

//        void i_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                ToolStripItem i = (ToolStripItem)sender;
//                String s = (String)i.Tag;
//                xDesk.banner_pic = s;
//                xDesk.ISave();
//                ShowDesk();
//            }
//            catch { }
//        }

//        private void mnuRemove_Click(object sender, EventArgs e)
//        {
//            xFloor.RemoveDesk(xDesk, this);
//        }

//        private void ShowActivityReport(DateTime d)
//        {
//            Application.DoEvents();
//            Application.DoEvents();
//            Application.DoEvents();

//            Image i = ToolsWin.Win32API.GetControlShot(this);
//            ActivityReport a = new ActivityReport();
//            n_user u = (n_user)RzWin.Context.xSys.Users.GetByID(xDesk.the_n_user_uid);
//            RzWin.Form.TabShow(a, "Activity Report for " + u.Name);
//            a.CompleteLoad(u, i, d);
//        }

//        private void mnuActivityReportToday_Click(object sender, EventArgs e)
//        {
//            ShowActivityReport(DateTime.Now);
//        }

//        private void mnuActivityReportYesterday_Click(object sender, EventArgs e)
//        {
//            ShowActivityReport(DateTime.Now.Subtract(TimeSpan.FromDays(1)));
//        }

//        private void picSpin_Click(object sender, EventArgs e)
//        {

//        }
//    }
//}
