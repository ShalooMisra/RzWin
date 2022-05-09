using System;
using System.Collections.Generic;
using System.Text;

using Core;

namespace CoreDevelop
{
    public class Dock
    {
        public Dictionary<String, BoxSys> Boxes = new Dictionary<String, BoxSys>();

        public BoxSys Load(Context x, SystemTag t)
        {
            BoxSys ret = new BoxSys(x, t);

            //need a better way to see if the init failed
            if (ret.TheAttribute == null)
                return null;

            Boxes.Add(ret.Name, ret);
            return ret;
        }
    }
}
