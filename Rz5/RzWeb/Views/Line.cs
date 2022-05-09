using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Rz5;
using Rz5.Web;

namespace Rz5.Web
{
    public class Line : _Item
    {
        public orddet_line LineItem
        {
            get
            {
                return (orddet_line)Item;
            }
        }
        public Line(ContextRz context, orddet_line line)
            : base(context, line)
        {

        }
    }
}