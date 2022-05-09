// This sample demonstrates the use of the WindowsIdentity class to impersonate a user.
// IMPORTANT NOTES:
// This sample requests the user to enter a password on the console screen.
// Because the console window does not support methods allowing the password to be masked,
// it will be visible to anyone viewing the screen.
// On Windows Vista and later this sample must be run as an administrator.

using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace SensibleDAL
{


    public class windows_impersonation
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LogonUser(
        string lpszUsername,
        string lpszDomain,
        string lpszPassword,
        int dwLogonType,
        int dwLogonProvider,
        out IntPtr phToken
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);


        public static bool impersonate2()
        {
            return impersonate2("sm_operations", "ATkab;?+Mc/zro#Gilb^", "sensiblemicro.local");
        }

        private static bool impersonate2(string userName, string password, string domain)
        {           
            IntPtr token;
            LogonUser(userName, domain, password, 2, 0, out token);

            bool isAuthenticated = token != IntPtr.Zero;

            CloseHandle(token);
            return isAuthenticated;
        }

        public static IntPtr GetAuthenticationHandle(string userName, string password, string domain)
        {
            IntPtr token;
            LogonUser(userName, domain, password, 2, 0, out token);
            return token;
        }       


    }
    
}
