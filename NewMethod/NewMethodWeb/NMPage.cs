using System;
using System.Collections.Generic;
using System.Web;

using CoreWeb;
using NewMethod;

namespace NewMethodWeb
{
    public class NMPage : CorePage
    {
        public ContextNM TheContextNM
        {
            get
            {
                return (ContextNM)TheContext;
            }
        }
    }
}