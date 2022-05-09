using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;


namespace OfficeInterop
{
    public static class ResourceManagement
    {
        public static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        public static void KillExcel(ExcelApplication app)
        {
            if (app != null)
                ReleaseObject(app);
        }        
    }

}
