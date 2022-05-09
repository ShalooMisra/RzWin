using System;
using System.Collections.Generic;
using System.Text;

using Core;

namespace CoreDevelop
{
    public class DeltaDevelop : Delta
    {
        public DeltaDevelop(Context x)
            : base(x)
        {
        }

        public virtual void WriteSystem(BoxSys s)
        {
            s.Write();
        }

        public virtual void WriteClass(BoxClass c)
        {
            c.Write();
        }
    }

    public class DeltaDevelopCache : DeltaDevelop
    {
        public DeltaDevelopCache(Context x)
            : base(x)
        {
        }

        public List<BoxSys> SystemsToWrite = new List<BoxSys>();
        public List<BoxClass> ClassesToWrite = new List<BoxClass>();

        public override void WriteSystem(BoxSys s)
        {
            SystemsToWrite.Add(s);
        }

        public override void WriteClass(BoxClass c)
        {
            ClassesToWrite.Add(c);
        }

        public void Flush()
        {
            foreach (BoxSys s in SystemsToWrite)
            {
                s.Write();
            }

            foreach (BoxClass c in ClassesToWrite)
            {
                c.Write();
            }
        }
    }
}
