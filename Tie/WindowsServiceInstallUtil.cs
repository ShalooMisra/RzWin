/*
 * Written by Tung1 (nguyenthanhtungtinbk@yahoo.com)
 * Date: 20070611
 * Updated: 20070705
 * Interesting reference: http://www.codeproject.com/install/ScriptedServiceInstall.asp (Install a Service using a Script)
 * 
 * SAMPLE USAGE:
        public static void Main()
        {
            WindowsServiceInstallInfo wsInstallInfo;
            WindowsServiceInstallUtil wsInstallUtil;
            bool result;

            //
            // Install with default settings
            //
            wsInstallInfo = new WindowsServiceInstallInfo(Directory.GetCurrentDirectory(), "MyService.exe", WindowsServiceAccountType.LocalService);
            wsInstallUtil = new WindowsServiceInstallUtil(wsInstallInfo);

            //Log to see any error
            //wsInstallUtil.Install(@"C:\test.txt");
            result = wsInstallUtil.Install();
            Console.WriteLine("Installed : " + result);

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();

            //Log to see any error
            //wsInstallUtil.Uninstall(@"C:\test.txt");
            result = wsInstallUtil.Uninstall();
            Console.WriteLine("Uninstalled : " + result);

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();

            //
            // Pass new settings before installing windows service
            //
            wsInstallInfo = new WindowsServiceInstallInfo("MyService_StartWithLocalSystem", "MyService Description", Directory.GetCurrentDirectory(), "MyService.exe", WindowsServiceAccountType.LocalSystem);
            wsInstallUtil = new WindowsServiceInstallUtil(wsInstallInfo);

            //Log to see any error
            //wsInstallUtil.Install(@"C:\test.txt");
            result = wsInstallUtil.Install();
            Console.WriteLine("Installed : " + result);

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();

            //Log to see any error
            //wsInstallUtil.Uninstall(@"C:\test.txt");
            result = wsInstallUtil.Uninstall();
            Console.WriteLine("Uninstalled : " + result);

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();

            //
            // Installing windows service to start with username and password
            //
            //If install with local user:
            //wsInstallInfo = new WindowsServiceInstallInfo("MyService_StartWithUsernameAndPassword", "This service will start with username and password", Directory.GetCurrentDirectory(), "MyService.exe", WindowsServiceAccountType.User, @".\username", @"password");
            //If install with network user:
            //wsInstallInfo = new WindowsServiceInstallInfo("MyService_StartWithUsernameAndPassword", "This service will start with username and password", Directory.GetCurrentDirectory(), "MyService.exe", WindowsServiceAccountType.User, @"networkdomain\username", @"password");
            wsInstallInfo = new WindowsServiceInstallInfo("MyService_StartWithUsernameAndPassword", "This service will start with username and password", Directory.GetCurrentDirectory(), "MyService.exe", WindowsServiceAccountType.User, @".\username", @"");
            wsInstallUtil = new WindowsServiceInstallUtil(wsInstallInfo);

            //Log to see any error
            //wsInstallUtil.Install(@"C:\test.txt");
            result = wsInstallUtil.Install();
            Console.WriteLine("Installed : " + result);

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();

            //Log to see any error
            //wsInstallUtil.Uninstall(@"C:\test.txt");
            result = wsInstallUtil.Uninstall();
            Console.WriteLine("Uninstalled : " + result);

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();

            //
            // End of program
            //
            return;
        }
 */

using System;
using System.Diagnostics;
using System.IO;

namespace OthersCode
{
    /// <summary>
    /// 
    /// </summary>
    public enum WindowsServiceAccountType
    {
        /// <summary></summary>
        LocalService,
        /// <summary></summary>
        NetworkService,
        /// <summary></summary>
        LocalSystem,
        /// <summary></summary>
        User
    }

    /// <summary>
    /// 
    /// </summary>
    public class WindowsServiceInstallInfo
    {
        private string _windowsServiceName;
        private string _wsDescription;
        private string _windowsServicePath;
        private string _windowsServiceAssemblyName;
        private WindowsServiceAccountType _wsAccountType;
        private string _wsAccountUserName = "";
        private string _wsAccountPassword = "";

        /// <summary>
        /// Please pass the windows service information in
        /// </summary>
        /// <param name="windowsServicePath">Path to folder where windows service assembly stored</param>
        /// <param name="windowsServiceAssemblyName">Windows Service Assembly Name</param>
        /// <param name="wsAccountType">Windows Service Account Type (not USER type)</param>
        public WindowsServiceInstallInfo(string windowsServicePath, string windowsServiceAssemblyName, WindowsServiceAccountType wsAccountType)
            : this("", windowsServicePath, windowsServiceAssemblyName, wsAccountType) { }

        /// <summary>
        /// Please pass the windows service information in
        /// </summary>
        /// <param name="windowsServiceName">Name of windows service</param>
        /// <param name="windowsServicePath">Path to folder where windows service assembly stored</param>
        /// <param name="windowsServiceAssemblyName">Windows Service Assembly Name</param>
        /// <param name="wsAccountType">Windows Service Account Type (not USER type)</param>
        public WindowsServiceInstallInfo(string windowsServiceName, string windowsServicePath, string windowsServiceAssemblyName, WindowsServiceAccountType wsAccountType)
            : this(windowsServiceName, "", windowsServicePath, windowsServiceAssemblyName, wsAccountType) { }

        /// <summary>
        /// Please pass the windows service information in
        /// </summary>
        /// <param name="windowsServiceName">Name of windows service</param>
        /// <param name="description">Description of windows service</param>
        /// <param name="windowsServicePath">Path to folder where windows service assembly stored</param>
        /// <param name="windowsServiceAssemblyName">Windows Service Assembly Name</param>
        /// <param name="wsAccountType">Windows Service Account Type (not USER type)</param>
        public WindowsServiceInstallInfo(string windowsServiceName, string description, string windowsServicePath, string windowsServiceAssemblyName, WindowsServiceAccountType wsAccountType)
            : this(windowsServiceName, description, windowsServicePath, windowsServiceAssemblyName, wsAccountType, "", "") { }

        /// <summary>
        /// Please pass the windows service information in
        /// </summary>
        /// <param name="windowsServicePath">Path to folder where windows service assembly stored</param>
        /// <param name="windowsServiceAssemblyName">Windows Service Assembly Name</param>
        /// <param name="wsAccountType">Windows Service Account Type</param>
        /// <param name="wsAccountUserName">Username of Windows Service when Account Type is USER</param>
        /// <param name="wsAccountPassword">Password of Windows Service when Account Type is USER</param>
        public WindowsServiceInstallInfo(string windowsServicePath, string windowsServiceAssemblyName, WindowsServiceAccountType wsAccountType, string wsAccountUserName, string wsAccountPassword)
            : this("", windowsServicePath, windowsServiceAssemblyName, wsAccountType, "", "") { }

        /// <summary>
        /// Please pass the windows service information in
        /// </summary>
        /// <param name="windowsServiceName">Name of windows service</param>
        /// <param name="windowsServicePath">Path to folder where windows service assembly stored</param>
        /// <param name="windowsServiceAssemblyName">Windows Service Assembly Name</param>
        /// <param name="wsAccountType">Windows Service Account Type</param>
        /// <param name="wsAccountUserName">Username of Windows Service when Account Type is USER</param>
        /// <param name="wsAccountPassword">Password of Windows Service when Account Type is USER</param>
        public WindowsServiceInstallInfo(string windowsServiceName, string windowsServicePath, string windowsServiceAssemblyName, WindowsServiceAccountType wsAccountType, string wsAccountUserName, string wsAccountPassword)
            : this("", "", windowsServicePath, windowsServiceAssemblyName, wsAccountType, "", "") { }

        /// <summary>
        /// Please pass the windows service information in
        /// </summary>
        /// <param name="windowsServiceName">Name of windows service</param>
        /// <param name="description">Description of windows service</param>
        /// <param name="windowsServicePath">Path to folder where windows service assembly stored</param>
        /// <param name="windowsServiceAssemblyName">Windows Service Assembly Name</param>
        /// <param name="wsAccountType">Windows Service Account Type</param>
        /// <param name="wsAccountUserName">Username of Windows Service when Account Type is USER</param>
        /// <param name="wsAccountPassword">Password of Windows Service when Account Type is USER</param>
        public WindowsServiceInstallInfo(string windowsServiceName, string description, string windowsServicePath, string windowsServiceAssemblyName, WindowsServiceAccountType wsAccountType, string wsAccountUserName, string wsAccountPassword)
        {
            _windowsServiceName = windowsServiceName.Trim();
            _wsDescription = description.Trim();
            _windowsServicePath = windowsServicePath;
            _windowsServiceAssemblyName = windowsServiceAssemblyName;
            _wsAccountType = wsAccountType;
            _wsAccountUserName = wsAccountUserName;
            _wsAccountPassword = wsAccountPassword;

            if (_wsAccountType == WindowsServiceAccountType.User && _wsAccountUserName == "")
            {
                throw new Exception("Username has to be provided if AccountType to start the windows service is USER");
            }
        }

        /// <summary>
        /// Name of windows service
        /// </summary>
        public string WindowsServiceName
        {
            get { return _windowsServiceName; }
            set { _windowsServiceName = value; }
        }

        /// <summary>
        /// Description of windows service
        /// </summary>
        public string Description
        {
            get { return _wsDescription; }
            set { _wsDescription = value; }
        }

        /// <summary>
        /// Path to folder which contains windows service binary
        /// </summary>
        public string WindowsServicePath
        {
            get { return _windowsServicePath; }
        }
        /// <summary>
        /// Windows service binary file name
        /// </summary>
        public string WindowsServiceAssemblyName
        {
            get { return _windowsServiceAssemblyName; }
        }
        /// <summary>
        /// Account type to start windows service
        /// </summary>
        public WindowsServiceAccountType WsAccountType
        {
            get { return _wsAccountType; }
        }
        /// <summary>
        /// Username to start windows service (if account type is User)
        /// </summary>
        public string WsAccountUserName
        {
            get { return _wsAccountUserName; }
        }
        /// <summary>
        /// Password of username to start windows service (if account type is User)
        /// </summary>
        public string WsAccountPassword
        {
            get { return _wsAccountPassword; }
        }
    }


    /// <summary>
    /// To use this class for installing windows service, you need a project installer (which inherits from DynamicInstaller) added to your assembly
    /// </summary>
    public class WindowsServiceInstallUtil
    {
        /// <summary>
        /// Path to folder where InstallUtil (.Net SDK) stored
        /// </summary>
        public static string InstallUtilPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory(); //@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727";

        private WindowsServiceInstallInfo _wsInstallInfo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wsInstallInfo"></param>
        public WindowsServiceInstallUtil(WindowsServiceInstallInfo wsInstallInfo)
        {
            _wsInstallInfo = wsInstallInfo;
        }


        /// <summary>
        /// Run InstallUtil with specific params
        /// </summary>
        /// <param name="installUtilArguments">CommandLine params</param>
        /// <returns>Status of installation</returns>
        private bool CallInstallUtil(string installUtilArguments)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Path.Combine(InstallUtilPath, "installutil.exe");
            proc.StartInfo.Arguments = installUtilArguments;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            proc.Start();
            string outputResult = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            // check result
            if (proc.ExitCode != 0)
            {
                //Console.WriteLine("{0} : failed with code {1}", DateTime.Now, proc.ExitCode);
                //Console.WriteLine(outputResult);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Install windows service
        /// </summary>
        /// <returns></returns>
        public bool Install()
        {
            return Install("");
        }
        /// <summary>
        /// Install windows service
        /// </summary>
        /// <param name="logFilePath">Log file to store installation information</param>
        /// <returns></returns>
        public bool Install(string logFilePath)
        {
            string installUtilArguments = " /account=\"" + _wsInstallInfo.WsAccountType + "\"";
            if (_wsInstallInfo.WindowsServiceName != "")
            {
                installUtilArguments += " /name=\"" + _wsInstallInfo.WindowsServiceName + "\"";
            }
            if (_wsInstallInfo.Description != "")
            {
                installUtilArguments += " /desc=\"" + _wsInstallInfo.Description + "\"";
            }
            if (_wsInstallInfo.WsAccountType == WindowsServiceAccountType.User)
            {
                installUtilArguments += " /user=\"" + _wsInstallInfo.WsAccountUserName + "\" /password=\"" + _wsInstallInfo.WsAccountPassword + "\"";
            }
            installUtilArguments += " \"" + Path.Combine(_wsInstallInfo.WindowsServicePath, _wsInstallInfo.WindowsServiceAssemblyName) + "\"";
            if (logFilePath.Trim() != "")
            {
                installUtilArguments += " /LogFile=\"" + logFilePath + "\"";
            }

            return CallInstallUtil(installUtilArguments);
        }

        /// <summary>
        /// Uninstall windows service
        /// </summary>
        /// <returns></returns>
        public bool Uninstall()
        {
            return Uninstall("");
        }
        /// <summary>
        /// Uninstall windows service
        /// </summary>
        /// <param name="logFilePath">Log file to store installation information</param>
        /// <returns></returns>
        public bool Uninstall(string logFilePath)
        {
            string installUtilArguments = " /u ";
            if (_wsInstallInfo.WindowsServiceName != "")
            {
                installUtilArguments += " /name=\"" + _wsInstallInfo.WindowsServiceName + "\"";
            }
            installUtilArguments += " \"" + Path.Combine(_wsInstallInfo.WindowsServicePath, _wsInstallInfo.WindowsServiceAssemblyName) + "\"";
            if (logFilePath.Trim() != "")
            {
                installUtilArguments += " /LogFile=\"" + logFilePath + "\"";
            }

            return CallInstallUtil(installUtilArguments);
        }
    }
}