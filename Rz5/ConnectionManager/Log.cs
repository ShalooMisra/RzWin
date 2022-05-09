using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ConnectionManager
{
    static class Log
    {
        
        public static void Write(List<string> strings, bool isNewLog)
        {
            FileMode mode = FileMode.OpenOrCreate;
            if (isNewLog)
                mode = FileMode.CreateNew;
            {
                using (Stream s = new FileStream("C:\\Users\\Eric\\Desktop\\log.txt", mode, FileAccess.Write))
                using (TextWriter writer = new StreamWriter(s,Encoding.UTF8))
                {
                    //Stream f = new Stream(, FileMode.Create);
                    foreach (string str in strings)
                        writer.WriteLine(DateTime.Today.ToString() + " " + DateTime.Now.ToString() + "\t" + str);
                }
            }
        }

    }
}
