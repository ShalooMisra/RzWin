using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace ReportalService
{
    [RunInstaller(true)]
    public class TieServiceInstaller : Installer
    {
        /// <summary>
        /// Public Constructor for WindowsServiceInstaller.
        /// - Put all of your Initialization code here.
        /// </summary>
        public TieServiceInstaller()
        {
            //SetRegistryForDesktopInteraction();

            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            

            //# Service Account Information
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            //# Service Information
            serviceInstaller.DisplayName = "TieService";
            serviceInstaller.Description = "";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            //# This must be identical to the WindowsService.ServiceBase name
            //# set in the constructor of WindowsService.cs
            serviceInstaller.ServiceName = "TieService";

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
        }

        

        private void SetRegistryForDesktopInteraction()
        {
            //Microsoft.Win32.RegistryKey ckey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(S"SYSTEM\\CurrentControlSet\\Services\\TieService", true);
            //if(ckey != null)
            //{
            //    // Ok now lets make sure the "Type" value is there, 
            //    //and then do our bitwise operation on it.
            //    if(ckey->GetValue("Type") != 0)
            //    {
            //        Int32 v = *dynamic_cast<Int32*>(ckey->GetValue(S"Type"));
            //        v = Convert::ToInt32(v | 256);
            //        ckey->SetValue(S"Type", __box(v));
            //    }
            //}
        }
    }
}