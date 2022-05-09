using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;


namespace Rz5
{
    public partial class frmPartPictureViewer : Form
    {
        //public static void ShowPartPicture(n_sys xs, partpicture p, IWin32Window owner)
        //{
        //    frmPartPictureViewer fPart = new frmPartPictureViewer();
        //    fPart.WindowState = FormWindowState.Maximized;
        //    fPart.CompleteLoad(xs, null);
        //    fPart.ShowDialog(owner);  
        //}

        //n_sys xSys;
        ArrayList aPictures;
        private Boolean bShowPartNumberLink = false;
        private Boolean bDisablePartLink = false;
        PartPictureViewer xPPV;
        public frmPartPictureViewer()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            CompleteLoad(null);
        }
        public void CompleteLoad(PartPictureViewer pv)
        {
            aPictures = new ArrayList();
            if (pv != null)
                xPPV = pv;
            else
                xPPV = new PartPictureViewer();
            xPPV.CompleteLoad();
            this.Controls.Clear();
            this.Controls.Add(xPPV);
            if (Tools.Strings.StrExt(xPPV.Caption))
                this.Text = xPPV.Caption;
            DoResize();
        }
        public Boolean ShowPartNumberLink
        {
            get
            {
                return bShowPartNumberLink;
            }
            set
            {
                bShowPartNumberLink = value;
                xPPV.ShowPartNumberLink = bShowPartNumberLink; 
                DoResize();
            }
        }
        public Boolean DisablePartLink
        {
            get
            {
                return bDisablePartLink;
            }
            set
            {
                bDisablePartLink = value;
                xPPV.DisablePartLink = bDisablePartLink;
                DoResize();
            }
        }
        //Public Functions
        public void LoadFormBy(nObject n)
        {
            xPPV.LoadViewBy(n, "");
        }
        public void LoadFormBy(nObject n, String SQL)
        {
            xPPV.LoadViewBy(n, SQL);
        }

        public void LoadViewByExactPic(partpicture p)
        {
            xPPV.LoadViewByExactPic(p);
        }

        public void DoResize()
        {
            try
            {
                if (this.ClientRectangle.Width < 360)
                    this.Width = 368;
                if (this.ClientRectangle.Height < 215)
                    this.Height = 249;
                if (xPPV != null)
                {
                    xPPV.Top = 0;
                    xPPV.Left = 0;
                    xPPV.Width = this.ClientRectangle.Width;
                    xPPV.Height = this.ClientRectangle.Height;
                    xPPV.DoResize();
                }
            }
            catch (Exception)
            { }
        }
        public ArrayList GetPictureCollection()
        {
            return xPPV.GetPictureCollection();
        }
        //Control Events
        private void frmPartPictureViewer_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}