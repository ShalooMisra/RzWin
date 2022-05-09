using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

using NewMethodx;

namespace TieService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            if (Tools.Strings.HasString(System.Environment.CommandLine, "-do_nothing"))
            {
                return;
            }

            //if( nTools.HasString(System.Environment.CommandLine, "-install") )
            //{
            //    AppDomain dom = AppDomain.CreateDomain("execDom");
            //    StringBuilder s = nTools.GetAppPath();
            //    StringBuilder* sb = new StringBuilder(path->Substring(0, path->LastIndexOf(S"\\")));
            //    sb->Append(S"\\InstallUtil.exe");
            //    dom->ExecuteAssembly(sb->ToString(), 0, args);
            //}

            // More than one user Service may run within the same process. To add
            // another service to this process, change the following line to
            // create a second service object. For example,
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new ServiceBase[] { new TieService() };

            ServiceBase.Run(ServicesToRun);
        }
    }
}