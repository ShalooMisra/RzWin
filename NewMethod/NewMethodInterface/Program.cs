using System;
using System.Collections;
using System.Windows.Forms;
using NewMethod;

namespace NewMethodInterface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            n_data_target.dCodePath = n_sys.NewMethodRoot;

            frmNMI xForm = new frmNMI();

            //////////////////////////////////////////////////
            //init the systems

            n_sys xs = nStartup.InitSystem(true, new n_sys_NMI());
            xs.xSys = xs;


            ContextNM qnm = new ContextNM(new CoreWin.LeaderWinUser(xForm));
            qnm.xSys = xs;
            qnm.xUser = new n_user(xs);
            qnm.xUser.super_user = true;
            n_sys.ContextDefault = qnm;

            //nTools.InitDevelopmentDataConnection();
            xs.xData = new nData(new n_data_target(null));
            xs.xData.server_name = "LAPTOP07\\SQLEXPRESS";
            xs.xData.user_name = "sa";
            xs.xData.user_password = "rec0gnin";
            xs.xData.database_name = "NMI";
            xs.xData.target_type = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
            xs.xData.SetConnectionString();
            xs.InstanceSaveType = StructureType.DatabaseStructure;
            xs.UpdateDataStructure(qnm, false);

            //n_sys.ContextDefault.xSys = xs;
            //NewMethod.CadmEngine.xSys = (n_sys_NewMethod)xs;

            n_sys.xChooseIcon = new frmIconChooser();
            n_sys.xChooseIcon.CompleteLoad(xs);

            n_sys.SoftStructureForm = xForm;

            xs.xUser = new n_user(xs);
            xs.xUser.name = "Recognin Tech";
            xs.xUser.super_user = true;
            xs.xUser.template_editor = true;

            //actually show the form
            //xForm.CompleteLoad(xs);


            xForm.Init(qnm); 
            
            xForm.Text = "New Method Interface";
            SysManager sm = new SysManager();
            sm.CompleteLoad();
            CoreWin.TabPageCore t = xForm.TabShow(sm, "System Manager");
            t.Lock();
            xForm.WindowState = FormWindowState.Maximized;
            
            Application.Run(xForm);
        }

        public static n_sys ClipboardSys = null;
        public static n_sys NewMethodSys = null;
    }
}