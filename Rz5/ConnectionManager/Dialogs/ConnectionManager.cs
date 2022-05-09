using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

using NewMethodx;

using ConnectionManagerCore;

namespace ConnectionManager
{
    public partial class ConnectionManager : Form
    {
        //Public Static Variables
        public static string strURL
        {
            get
            {
                return FolderName + FileName;
            }
        }
        public static string FolderName = "http://www.recognin.com/InstallFiles/";
        public static string FileName = "SQLEXPR.EXE";

        //Constructors
        public ConnectionManager()
        {
            InitializeComponent();
            Tools.Style.StyleCurrent.IconFormDefault = this.Icon;
            InstallAction action = new InstallAction();
            this.panel1.Controls.Add(action);
            this.Activate();
        }
        public ConnectionManager(bool restart)
        {
            InitializeComponent();
            Tools.Style.StyleCurrent.IconFormDefault = this.Icon;
            if (restart)
            {
                ConnectionTest test = new ConnectionTest();
                test.Show();
            }
            InstallAction action = new InstallAction();
            this.panel1.Controls.Add(action);
            this.Activate();
            if (restart)
            {
                ConnectionTest test = new ConnectionTest();
                test.Show();
            }
        }
        //Control Events
        private void picLogo_DoubleClick(object sender, EventArgs e)
        {

            string file = "c:\\Trash\\RzExport.zip";
            Tools.Zip.UnZipOneFile(file, "c:\\Trash\\");

            MessageBox.Show(ToolsConnection.ConnectionFileName);
        }
    }
}
