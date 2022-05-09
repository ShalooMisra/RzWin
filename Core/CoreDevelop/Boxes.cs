using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

using Core;

namespace CoreDevelop
{
    public class Box
    {
        public virtual String Name
        {
            get
            {
                return TheAttribute.Name;
            }
        }

        public CoreAttribute TheAttribute;

        public Box(CoreAttribute attr)
        {
            TheAttribute = attr;
        }
    }

    //public class BoxMember : Box
    //{
    //    public CoreMemberAttribute TheMemberAttribute
    //    {
    //        get
    //        {
    //            return (CoreMemberAttribute)TheAttribute;
    //        }
    //    }

    //    public BoxMember(CoreMemberAttribute attr) : base(attr)
    //    {
    //    }

        //public static BoxMember Create(CoreMemberAttribute attr)
        //{
        //    if (attr is CoreVarAttribute)
        //        return new BoxVar((CoreVarAttribute)attr);
        //    else
        //        return new BoxAct((CoreActAttribute)attr);
        //}
    //}

    public class BoxVar : Box
    {
        public BoxVar(CoreVarAttribute attr)
            : base(attr)
        {
        }

        public CoreVarAttribute TheVarAttribute
        {
            get
            {
                return (CoreVarAttribute)TheAttribute;
            }
        }
    }

    //public class BoxAct : BoxMember
    //{
    //    public BoxAct(CoreActAttribute attr)
    //        : base(attr)
    //    {
    //    }
    //}
}
