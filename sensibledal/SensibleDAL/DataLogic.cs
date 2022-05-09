using SensibleDAL.dbml;


namespace SensibleDAL
{
    public class DataLogic
    {

        public static string GetRzConnectionString(bool test)
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Rz3ConnectionString"].ConnectionString;
            if (test)
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["Rz_Test"].ConnectionString;
            return connection;
        }

        public static string GetPortalConnectionString(bool test)
        {
            if (test)//Test System on IT machine
                return @"Data Source=it.sensiblemicro.local\SQLEXPRESS;Initial Catalog=SMCPortal;Integrated Security=SSPI;";
            //Live Portal
            return @"Data Source=rz.sensiblemicro.local\SQLEXPRESS;Initial Catalog=SMCPortal;Integrated Security=SSPI;";
        }

        public virtual RzDataContext rdc(bool test = false, int timeOut = 180)
        {
            RzDataContext ret = new RzDataContext();
            ret.Connection.ConnectionString = GetRzConnectionString(test);
            ret.CommandTimeout = timeOut;
            return ret;
        }


        public static string GetSystemConnectionString(string systemName)
        {
            switch (systemName)
            {
                case "Portal":
                    {
                        return GetPortalConnectionString(false);

                    }
                case "PortalTest":
                    {
                        return GetPortalConnectionString(false);

                    }
                case "Rz":
                    {
                        return GetRzConnectionString(false);
                    }
                case "RzTest":
                    {
                        return GetRzConnectionString(true);
                    }
                case "SeriLog":
                    {
                        //return @"Data Source=.\SQLEXPRESS;Initial Catalog=SeriLog;Integrated Security=SSPI;";
                        return @"Data Source=rz.sensiblemicro.local\SQLEXPRESS;Initial Catalog=SeriLog;Integrated Security=SSPI;";
                    }
            }

            return null;
        }


       


    }

   


}

