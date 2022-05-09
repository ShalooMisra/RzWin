using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Resources;

namespace NewMethod
{
    public partial class AsyncWait : UserControl
    {
        public bool WasCancelled = false;
        public AsyncWait()
        {
            InitializeComponent();
            ShowThrobber();
        }

        private void ShowThrobber()
        {
            try
            {
                if (pbThrob.Image == null)
                {
                    Assembly _assembly;
                    Stream _imageStream;
                    _assembly = Assembly.GetExecutingAssembly();
                    _imageStream = _assembly.GetManifestResourceStream("NewMethod.throbber.gif");
                    pbThrob.Image = new Bitmap(_imageStream);
                }
            }
            catch (Exception)
            { }
        }

        public void SetDuration(int seconds)
        {
            //the host calls this itself, so it needs to be sure to check the cancel
            //flag before ever again calling SetDuration
            WasCancelled = false;
            lblDuration.Text = Tools.Dates.FormatHMS(seconds);
        }

        public void SetCaption(String s)
        {
            try
            {
                lblCaption.Text = s;
            }
            catch (Exception)
            { }
        }

        public void SetStatus(String s)
        {
            try
            {
                if( lblDuration.InvokeRequired )
                {
                    SetStatusDelegate d = new SetStatusDelegate(SetStatusHandler);
                    lblDuration.Invoke(d, new object[] {s});
                }
                else
                {
                    SetStatusHandler(s);
                }                
            }
            catch (Exception)
            { }
        }

        private void SetStatusHandler(String s)
        {
            lblDuration.Text = s;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            WasCancelled = true;
            lblDuration.Text = "Cancelling...";
        }

        public bool CanCancel
        {
            get
            {
                return cmdCancel.Visible;
            }

            set
            {
                cmdCancel.Visible = value;
            }
        }

    }
}
