using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;
using ToolsWin;
using NewMethod;

namespace Rz5
{
    public partial class UpdateDownload : UserControl
    {
        //Private Delegates
        private delegate void ControlArgsDelegate(ControlArgs args);
        private delegate void VoidFunctionHandler();
        //Protected Variables
        protected UpdateDownloadCore TheUpdateCore = null;
        //Private Variables
        private bool ConfirmationSkipMode = true;
        private bool NewVersionAvailable = false;
        private bool NewVersionDownloaded = false;
        private bool use_alternate = false;
        private bool update_success = false;
        private bool use_beta = false;
        private bool use_test = false;
        private string Status = "";

        //Constructors
        public UpdateDownload()
        {
            InitializeComponent();
        }
        //Destructors
        ~UpdateDownload()
        {
            InitUn();
        }
        //Public Functions
        public void Init(UpdateDownloadCore c)
        {
            InitUn();
            TheUpdateCore = c;
            TheUpdateCore.GotProgress += new SetProgressDelegate(TheUpdateCore_GotProgress);
            TheUpdateCore.GotStatus += new SetStatusDelegate(TheUpdateCore_GotStatus);
            ControlArgs args = new ControlArgs();
            args.cmdChooseLocal_Visible = c.TheContext.xUser.SuperUser;
            args.cmdHere_Visible = c.TheContext.xUser.SuperUser;
            args.chkAccept_Checked = c.TheContext.xUser.SuperUser;
            AssignControlValues_1(args);
            //SetGo();
            ShowPaths();
            args.chkAccept_Checked = true;
            args.chkAccept_Visible = false;
            RT.Text = GetDisclaimer();        
            


            if (!c.CheckFileFolderCreation())
            {
                ShowWindowsPermissions();
                return;
            }
            if (bgwNewVersion.IsBusy)
                return;

            if (c.CurrentUpdateType == UpdateType.WebToServer)
            {
                NewVersionAvailable = true;
                SetGo();
            }
            else
            {
                throb.Visible = true;
                throb.BringToFront();
                throb.ShowThrobber();
                bgwNewVersion.RunWorkerAsync();
            }
        }
        public void ConfirmationSkip()
        {
            cmdGo.Enabled = true;
            ConfirmationSkipMode = true;
        }
        //Private Functions
        private void InitUn()
        {
            if (TheUpdateCore != null)
            {
                TheUpdateCore.GotProgress -= new SetProgressDelegate(TheUpdateCore_GotProgress);
                TheUpdateCore.GotStatus -= new SetStatusDelegate(TheUpdateCore_GotStatus);
                TheUpdateCore = null;
            }
        }
        private void TheUpdateCore_GotStatus(string s)
        {
            SetStatus(s);
        }
        private void TheUpdateCore_GotProgress(int i)
        {
            HandleProgress(i);
        }
        private void SetSource()
        {
            TheUpdateCore.SetSource(optAlternate.Checked);
            SetFromPath("From: " + TheUpdateCore.RemotePath);
        }
        private void ShowPaths()
        {
            if (this.InvokeRequired)
            {
                VoidFunctionHandler d = new VoidFunctionHandler(Actually_ShowPaths);
                this.Invoke(d);
            }
            else
            {
                Actually_ShowPaths();
            }
        }
        private void Actually_ShowPaths()
        {
            lbFromPath.Text = "From: " + TheUpdateCore.RemotePath;
            lblToPath.Text = "To: " + TheUpdateCore.LocalPath;
            lblMethod.Text = TheUpdateCore.CurrentUpdateType.ToString();
        }
        private string GetDisclaimer()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Rz SOFTWARE LICENSE AGREEMENT");
            sb.AppendLine("");
            sb.AppendLine("This user license agreement (the \"AGREEMENT\") is an agreement between you  (individual or single entity) and Recognin Technologies, for the Rz4 software (the  \"SOFTWARE\") that is accompanying this AGREEMENT.");
            sb.AppendLine("");
            sb.AppendLine("The SOFTWARE is the property of Recognin Technologies and is protected by copyright  laws and international copyright treaties. The SOFTWARE is not sold; it is  licensed.");
            sb.AppendLine("");
            sb.AppendLine("WARRANTY DISCLAIMER:");
            sb.AppendLine("");
            sb.AppendLine("The SOFTWARE is supplied \"AS IS\". Recognin Technologies disclaims all warranties,  expressed or implied, including, without limitation, the warranties of  merchantability and of fitness for any purpose. The user must assume the entire  risk of using the SOFTWARE. ");
            sb.AppendLine("");
            sb.AppendLine("DISCLAIMER OF DAMAGES:");
            sb.AppendLine("");
            sb.AppendLine("Recognin Technologies assumes no liability for damages, direct or consequential,  which may result from the use of the SOFTWARE, even if Recognin Technologies has  been advised of the possibility of such damages. Any liability of the seller will  be limited to refund the purchase price.");
            return sb.ToString();
        }
        private void ShowWindowsPermissions()
        {
            pControls.Enabled = false;
            wb.Visible = true;
            wb.Clear();
            wb.Navigate("http://www.recognin.com/WindowsPermissions.htm");
            wb.Left = txtStatus.Left;
            wb.Top = txtStatus.Top;
            wb.Width = txtStatus.Width;
            wb.Height = (this.ClientRectangle.Height - wb.Top) - 10;
            wb.BringToFront();
            RT.Visible = false;
        }
        private void HandleProgress(int p)
        {
            try
            {
                if (InvokeRequired)
                    Invoke(new SetProgressDelegate(ActuallyHandleProgress), new object[] { p });
                else
                    ActuallyHandleProgress(p);
            }
            catch { }
        }
        private void ActuallyHandleProgress(int p)
        {
            pb.Value = p;
        }
        private void SetStatus(String NewStatus)
        {
            if (this.InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(ActuallySetStatus);
                this.Invoke(d, new object[] { NewStatus });
            }
            else
            {
                ActuallySetStatus(NewStatus);
            }
        }
        private void ActuallySetStatus(String NewStatus)
        {
            txtStatus.Text = NewStatus + "\r\n" + txtStatus.Text;
            txtStatus.Refresh();
        }
        private void SetLocalPath()
        {
            TheUpdateCore.SetLocalPath();
            ShowPaths();
        }
        private void DoResize()
        {
            try
            {
                RT.Top = this.ClientRectangle.Height - RT.Height;
                pControls.Top = 0;
                pControls.Left = 0;
                pControls.Width = this.ClientRectangle.Width;
                pControls.Height = RT.Top - pControls.Top;
                pb.Width = pControls.ClientRectangle.Width - (pb.Left * 2);
                txtStatus.Width = pb.Width;
                txtStatus.Height = pControls.Height - txtStatus.Top;
                RT.Width = txtStatus.Width;
            }
            catch { }
        }
        private void SetGo()
        {
            cmdGo.Enabled = NewVersionAvailable || NewVersionDownloaded;
        }
        private void SetFromPath(String path)
        {
            if (this.InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(ActuallySetFromPath);
                this.Invoke(d, new object[] { path });
            }
            else
            {
                ActuallySetFromPath(path);
            }
        }
        private void ActuallySetFromPath(String path)
        {
            lbFromPath.Text = path;
        }
        private void AssignControlValues_1(ControlArgs args)
        {
            if (this.InvokeRequired)
            {
                ControlArgsDelegate d = new ControlArgsDelegate(Actually_AssignControlValues_1);
                this.Invoke(d, new object[] { args });
            }
            else
            {
                Actually_AssignControlValues_1(args);
            }
        }
        private void Actually_AssignControlValues_1(ControlArgs args)
        {
            cmdChooseLocal.Visible = args.cmdChooseLocal_Visible;
            cmdHere.Visible = args.cmdHere_Visible;
        }
        private void AssignControlValues_2(ControlArgs args)
        {
            if (this.InvokeRequired)
            {
                ControlArgsDelegate d = new ControlArgsDelegate(Actually_AssignControlValues_2);
                this.Invoke(d, new object[] { args });
            }
            else
            {
                Actually_AssignControlValues_2(args);
            }
        }
        private void Actually_AssignControlValues_2(ControlArgs args)
        {
            cmdGo.Enabled = true;
        }
        //Buttons
        private void cmdGo_Click(object sender, EventArgs e)
        {
            try
            {
                if (NewVersionDownloaded && !NewVersionAvailable)
                {
                    TheUpdateCore.OpenLatestVersion();

                    if (chkClose.Checked)
                    {
                        try
                        {
                            SetStatus("Closing Rz...");
                            RzWin.Form.CompleteClose();
                        }
                        catch { }
                        return;
                    }
                    return;
                }

                if (bgw.IsBusy)
                    return;
                throb.Visible = true;
                throb.BringToFront();
                throb.ShowThrobber();
                cmdGo.Enabled = false;
                use_alternate = optAlternate.Checked;
                use_beta = chkBeta.Checked;
                if (RzWin.Context.Data.DatabaseName == "Rz3_Test")
                    use_test = true;
                bgw.RunWorkerAsync();
            }
            catch { }
        }
        private void cmdChooseLocal_Click(object sender, EventArgs e)
        {
            String s = RzWin.Leader.AskForString("What is the remote FTP server?", "www.recognin.com", "Remote Path");
            if (!Tools.Strings.StrExt(s))
                return;
            TheUpdateCore.RemotePath = s;
            ShowPaths();
        }
        private void cmdHere_Click(object sender, EventArgs e)
        {
            SetLocalPath();
        }
        //Background Workers
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            update_success = TheUpdateCore.RunUpdate(RzWin.Context, use_alternate, use_beta, use_test);
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.Visible = false;
            throb.HideThrobber();
            cmdGo.Enabled = true;

            if (!update_success)
                return;

            if (TheUpdateCore.CurrentUpdateType == UpdateType.WebToServer)
            {
                RzWin.Leader.Comment("Updating this workstation...");
                TheUpdateCore.Init(TheUpdateCore.TheContext, UpdateType.ServerToWorkstation, TheUpdateCore.DisclaimerUrl, TheUpdateCore.FolderName, false);
                //bgw.RunWorkerAsync();
                TheUpdateCore.RunUpdate(RzWin.Context, use_alternate, use_beta, use_test);
            }

            TheUpdateCore.OpenLatestVersion();

            if (chkClose.Checked)
            {
                try
                {
                    SetStatus("Closing Rz...");
                    RzWin.Form.CompleteClose();
                }
                catch { }
                return;
            }
        }
       
        private void bgwNewVersion_DoWork(object sender, DoWorkEventArgs e)
        {
            NewVersionAvailable = TheUpdateCore.NewVersionAvailable(ref Status);
            if (!NewVersionAvailable)
            {
                
                //This appears to be the popup Mike put in to show us when no new version is available.
                //MessageBox.Show("No version: " + Status);
                //NewVersionDownloaded = TheUpdateCore.NewVersionDownloaded(ref Status);
            }
            else
                NewVersionDownloaded = false;
        }
        private void bgwNewVersion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetGo();
            lblStatus.Text = "Status: " + Status;
            if (NewVersionAvailable || NewVersionDownloaded)
                lblStatus.ForeColor = Color.ForestGreen;
            else
                lblStatus.ForeColor = Color.Firebrick;
            throb.HideThrobber();
            throb.Visible = false;
        }
        //Control Events
        private void UpdateDownload_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void chkAccept_CheckedChanged(object sender, EventArgs e)
        {
            SetGo();
        }
        private void optMain_CheckedChanged(object sender, EventArgs e)
        {
            SetSource();
        }
        //Private Classes
        private class ControlArgs
        {
            public bool cmdChooseLocal_Visible = false;
            public bool cmdHere_Visible = false;
            public bool chkAccept_Checked = false;
            public bool chkAccept_Visible = false;
            public string lblAccept_Text = "";
            public bool cmdSendToDatabase_Visible = false;
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            String file = ToolsWin.FileSystem.ChooseAFile();
            if (!File.Exists(file))
                return;

            if (Path.GetExtension(file).ToLower() != ".zip")
                return;

            String strLatest = Path.GetFileNameWithoutExtension(file);
            String strFolder = TheUpdateCore.LocalPath + RzWin.Context.xSys.InstallFolderPrefix + "_" + strLatest + "\\";
            String strLocal = file;

            String complete = "";
            TheUpdateCore.UnzipAndImport(RzWin.Context, strLocal, strFolder, ref complete, strLatest);
        }

        private void chkBeta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBeta.Checked)
                cmdGo.Enabled = true;
        }
    }
    //public enum UpdateType
    //{
    //    None = 0,
    //    WebToWorkstation = 1,
    //    WebToServer = 2,
    //    ServerToWorkstation = 3,
    //    DatabaseToWorkstation = 4,
    //}
}
