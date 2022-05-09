using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class CodeBuilder
    {
        public StringBuilder sb = new StringBuilder();
        public void Append(String s)
        {
            sb.Append(s);
        }

        public void AppendLine(String s)
        {
            sb.AppendLine(s);
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
