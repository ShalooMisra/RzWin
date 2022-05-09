using System;
using System.Management;

namespace OthersCode
{
    // The WMI query for this class was created using the WMI Code Creator tool
    // that is available from
    // http://www.microsoft.com/downloads/details.aspx?FamilyID=2cc30a64-ea15-4661-8da4-55bbc145c30e&DisplayLang=en
    public class SQLServerTools
    {
        public static bool IsExpressInstalled()
        {
            const string edition = "Express Edition";
            const string instance = "MSSQL$SQLEXPRESS";
            const int spLevel = 1;

            bool fCheckEdition = false;
            bool fCheckSpLevel = false;

            try
            {
                // Run a WQL query to return information about SKUNAME and SPLEVEL about installed instances
                // of the SQL Engine.
                ManagementObjectSearcher getSqlExpress =
                    new ManagementObjectSearcher("root\\Microsoft\\SqlServer\\ComputerManagement",
                    "select * from SqlServiceAdvancedProperty where SQLServiceType = 1 and ServiceName = '"
                    + instance + "' and (PropertyName = 'SKUNAME' or PropertyName = 'SPLEVEL')");

                // If nothing is returned, SQL Express isn't installed.
                if (getSqlExpress.Get().Count == 0)
                {
                    return false;
                }

                // If something is returned, verify it is the correct edition and SP level.
                foreach (ManagementObject sqlEngine in getSqlExpress.Get())
                {
                    if (sqlEngine["ServiceName"].ToString().Equals(instance))
                    {
                        switch (sqlEngine["PropertyName"].ToString())
                        {
                            case "SKUNAME":
                                // Check if this is Express Edition or Express Edition with Advanced Services
                                fCheckEdition = sqlEngine["PropertyStrValue"].ToString().Contains(edition);
                                break;

                            case "SPLEVEL":
                                // Check if the instance matches the specified level
                                fCheckSpLevel = int.Parse(sqlEngine["PropertyNumValue"].ToString()) >= spLevel;
                                //fCheckSpLevel = sqlEngine["PropertyNumValue"].ToString().Contains(spLevel);
                                break;
                        }
                    }
                }

                if (fCheckEdition & fCheckSpLevel)
                {

                    return true;
                }
                return false;
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Error: " + e.ErrorCode + ", " + e.Message);
                return false;
            }
        }
         
        // Are we checking twice to see if SQL Express is installed?  I.e., SQLExpressInstall.IsExpressInstalled()
        public static bool Is2K5Installed()
        {
            //const string edition = "Express Edition";
            //const string instance = "MSSQL$SQLEXPRESS";
            //const int spLevel = 1;

           // bool fCheckEdition = false;
            //bool fCheckSpLevel = false;

            try
            {
                // Run a WQL query to return information about SKUNAME and SPLEVEL about installed instances
                // of the SQL Engine.
                //ManagementObjectSearcher getSqlExpress =
                //    new ManagementObjectSearcher("root\\Microsoft\\SqlServer\\ComputerManagement",
                //    "select * from SqlServiceAdvancedProperty where SQLServiceType = 1 and ServiceName = '"
                //    + instance + "' and (PropertyName = 'SKUNAME' or PropertyName = 'SPLEVEL')");

                ManagementObjectSearcher getSqlExpress =
                                    new ManagementObjectSearcher("root\\Microsoft\\SqlServer\\ComputerManagement",
                                    "select * from SqlServiceAdvancedProperty where SQLServiceType = 1 and (PropertyName = 'SKUNAME' or PropertyName = 'SPLEVEL')");

                if (getSqlExpress.Get().Count == 0)
                {
                    return false;
                }

                return true;
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Error: " + e.ErrorCode + ", " + e.Message);
                return false;
            }
        }
    }
}