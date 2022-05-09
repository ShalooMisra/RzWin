using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using ToolsWin;

using Core;
using CoreWin;

namespace CoreDevelopWin.Dialogs
{
    public partial class CoreDevelopForm : CoreWin.MainForm
    {
        Snapshots shots;
        public CoreDevelopForm()
        {
            InitializeComponent();
            this.Text = "CoreDevelop";
        }

        public override void Init(Context x)
        {
            base.Init(x);
            StartShots();
            HomeShow();
        }

        void HomeShow()
        {
            Screens.Home h = new Screens.Home();
            TabShow(h, "Home");
            h.Init();
        }

        public override void InitUn()
        {
            base.InitUn();
        }

        public void StartShots()
        {
            shots = new Snapshots("c:\\eternal\\code\\BabyPictures\\Iop\\", this, this);
        }
    }
}
