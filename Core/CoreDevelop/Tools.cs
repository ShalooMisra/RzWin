using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tools.Database;

namespace CoreDevelop
{
    public class ClassExpandArgs
    {
        public String Name;
        public String Caption;
        public FieldType Type;
        public bool List = false;
        public String ListClass = "";
        public bool NewClass = false;

        public ClassExpandArgs(String name, String caption, FieldType type) : this(name, caption, type, false)
        {

        }
        public ClassExpandArgs(String name, String caption, FieldType type, bool list)
        {
            Name = name;
            Caption = caption;
            Type = type;
            List = list;
        }
    }
}
