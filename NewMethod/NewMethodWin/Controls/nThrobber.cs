using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.IO;

namespace NewMethod
{
    public partial class nThrobber : UserControl
    {
        public nThrobber()
        {
            InitializeComponent();
        }

        public void ShowThrobber()
        {
            try
            {
                pbThrob.Visible = true;
                if (pbThrob.Image == null)
                {
                    Assembly _assembly;
                    Stream _imageStream;
                    _assembly = Assembly.GetExecutingAssembly();
                    _imageStream = _assembly.GetManifestResourceStream("NewMethodWin.Graphics.Throbber.gif");
                    pbThrob.Image = new Bitmap(_imageStream);
                }
            }
            catch (Exception)
            { }
        }

        public void HideThrobber()
        {
            if (pbThrob.Image != null)
            {
                pbThrob.Image.Dispose();
                pbThrob.Image = null;
                pbThrob.Visible = false;
            }
        }

        private bool m_UseParentBackColor = false;
        public bool UseParentBackColor
        {
            get
            {
                return m_UseParentBackColor;
            }
            set
            {
                m_UseParentBackColor = value;

                if (m_UseParentBackColor)
                {
                    GrabParentBackColor();
                }
            }
        }

        public void GrabParentBackColor()
        {
            try
            {
                this.BackColor = this.Parent.BackColor;
                pbThrob.BackColor = this.Parent.BackColor;
            }
            catch (Exception ex)
            { }
        }
    }
}
