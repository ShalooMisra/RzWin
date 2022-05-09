using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Tie
{
    public partial class PinPermission : UserControl
    {
        public PinPermission()
        {
            InitializeComponent();
            TrySetImage();
        }

        ImageList m_ImageList;
        public ImageList ImageList
        {
            get
            {
                return m_ImageList;
            }

            set
            {
                m_ImageList = value;
            }
        }

        String m_ImageKey;
        public String ImageKey
        {
            get
            {
                return m_ImageKey;
            }

            set
            {
                m_ImageKey = value;
                TrySetImage();
            }
        }

        public void TrySetImage()
        {
            try
            {
                pic.Image = ImageList.Images[ImageKey];
            }
            catch { }
        }

        String m_Caption;
        public String Caption
        {
            get
            {
                return m_Caption;
            }

            set
            {
                m_Caption = value;
                chk.Text = m_Caption;
            }
        }

        String m_Description;
        public String Description
        {
            get
            {
                return m_Description;
            }

            set
            {
                m_Description = value;
                lbl.Text = m_Description;
            }
        }

        public bool IsChecked
        {
            get
            {
                return chk.Checked;
            }

            set
            {
                chk.Checked = value;
            }
        }

        public void Enable()
        {
            chk.Enabled = true;
        }

        public void Disable()
        {
            chk.Enabled = false;
            chk.Checked = false;
        }
    }
}
