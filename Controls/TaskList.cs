using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Win.Controls
{
    public partial class TaskList : UserControl
    {
        public event EventHandler SizeChanged;

        bool m_RemainThisSize = true;
        public bool RemainThisSize
        {
            get
            {
                return m_RemainThisSize;
            }

            set
            {
                m_RemainThisSize = value;
            }
        }
        
        public TaskList()
        {
            InitializeComponent();
        }

        public void Init(List<usernote> tasks)
        {
            fp.Controls.Clear();
            inhibit_size = true;
            foreach (usernote n in tasks)
            {
                Insert(n);
            }
            inhibit_size = false;
            SizeCalc();
            DoResize();
        }

        public void InitUn()
        {
            try
            {
                foreach (Control c in fp.Controls)
                {
                    if (c is Win.Views.ViewFolder)
                    {
                        ((Win.Views.ViewFolder)c).SizeChanged -= new EventHandler(f_SizeChanged);
                    }
                    else
                        c.Resize -= new EventHandler(t_Resize);
                }

                fp.Controls.Clear();
            }
            catch { }
        }

        public void Clear()
        {
            InitUn();
        }

        bool inhibit_size = false;
        public void Insert(usernote n)
        {
            if (n.is_folder)
            {
                Win.Views.ViewFolder f = new Views.ViewFolder();
                f.Init(n);
                fp.Controls.Add(f);
                f.SizeChanged += new EventHandler(f_SizeChanged);  
            }
            else
            {
                ViewTask t = RzWin.Leader.TaskViewCreate(n);
                t.Init(n);
                t.CompleteLoad();
                fp.Controls.Add(t);
                t.Resize += new EventHandler(t_Resize);
            }

            if (!inhibit_size)
            {
                SizeCalc();
                DoResize();
            }
        }

        void t_Resize(object sender, EventArgs e)
        {
            try
            {
                SizeCalc();
            }
            catch { }
        }

        void f_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                SizeCalc();
            }
            catch { }
        }

        void SizeCalc()
        {
            if (!this.RemainThisSize)
            {
                int width = 0;
                int height = 0;

                if (fp.Controls.Count > 0)
                {
                    foreach (Control c in fp.Controls)
                    {
                        height += c.Height;
                        if (c.Width > width)
                            width = c.Width;
                    }

                    height += 20;
                    width += 20;
                }

                this.Height = height;
                this.Width = width;

                if (SizeChanged != null)
                    SizeChanged(null, null);
            }
        }

        private void TaskList_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                foreach (Control c in fp.Controls)
                {
                    if (c is Win.Views.ViewFolder)
                    {
                        c.Width = fp.ClientRectangle.Width - 20;
                    }
                }
            }
            catch { }
        }


    }
}
