//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;

//using NewMethod;

//namespace Rz4.VirtualFloor
//{
//    public partial class ActivityLine : UserControl
//    {
//        public ActivityLine()
//        {
//            InitializeComponent();
//        }

//        public DateTime StartTime;
//        public VirtualDesk xDesk;
//        public void CompleteLoad(user_activity a)
//        {
//            try
//            {
//                lblCaption.Text = a.description;
//                StartTime = DateTime.Now;
//                ArrayList ary = nTools.SplitArray(a.link_list, "\r\n");
//                Graphics g = Graphics.FromHwnd(this.Handle);
//                this.Width = Convert.ToInt32(g.MeasureString(a.description, lblCaption.Font).Width) + lblCaption.Left + 10;
//                g.Dispose();
//                g = null;
//                lblCaption.Width = this.Width;
//                Image i = null;
//                try
//                {
//                    if( il.Images.ContainsKey(a.activity_type) )
//                        i = il.Images[a.activity_type];
//                }
//                catch { }
//                if (ary.Count == 0 && i == null)
//                {
//                    this.Height = lblCaption.Bottom;
//                }
//                else
//                {
//                    pic.Image = i;
//                    this.Height = lblCaption.Bottom + lblCaption.Height;

//                    if (ary.Count == 0)
//                    {
//                        lblCaption.Top = (this.ClientRectangle.Height / 2) - (lblCaption.Height / 2);
//                    }
//                    else
//                    {
//                        int left = 40;
//                        foreach (String s in ary)
//                        {
//                            LinkLabel l = new LinkLabel();
//                            l.AutoSize = true;
//                            l.Text = Tools.Strings.ParseDelimit(s, ":", 3);
//                            l.Tag = Tools.Strings.ParseDelimit(s, ":", 1) + ":" + Tools.Strings.ParseDelimit(s, ":", 2);
//                            Controls.Add(l);
//                            l.Left = left;
//                            l.Top = lblCaption.Bottom;
//                            left += l.Width + 5;
//                            l.Click += new EventHandler(l_Click);
//                        }
//                    }
//                }
//            }
//            catch { }
//        }
//        void l_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                LinkLabel l = (LinkLabel)sender;
//                String s = (String)l.Tag;
//                RzWin.Context.xSys.ThrowByKey(s);
//            }
//            catch { }
//        }
//    }
//}
