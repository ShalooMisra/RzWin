using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ToolsWin
{
    delegate void ActuallyTakeHandler();
    public class Snapshots
    {
        public DateTime LastShot;
        public String SaveFolder;
        public Control TheControl;
        public Form TheForm;

        public Snapshots(String strFolder, Control c, Form f)
        {
            SaveFolder = strFolder;
            TheControl = c;
            TheForm = f;
        }

        public void Check()
        {
            TimeSpan t = DateTime.Now.Subtract(LastShot);
            if (t.TotalMinutes > 60)
            {
                Take();
                LastShot = DateTime.Now;
            }
        }

        public void Take()
        {
            try
            {
                Thread t = new Thread(new ThreadStart(TakeOnThread));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            catch { }
        }

        public void TakeOnThread()
        {
            TakeOnThreadWait(10);
        }

        public void TakeOnThreadWait(int wait)
        {
            try
            {
                Thread.Sleep(wait * 1000);
                TheControl.Invoke(new ActuallyTakeHandler(ActuallyTake));
                Thread.Sleep(3 * 1000);
            }
            catch { }
        }

        void ActuallyTake()
        {
            System.Drawing.Image i = ToolsWin.Win32API.GetControlShot(TheControl);
            String strFile = Tools.Folder.ConditionFolderName(SaveFolder) + Tools.Folder.GetNowPathPlusTime() + ".jpg";
            i.Save(strFile, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
