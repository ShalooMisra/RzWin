using System;
using System.Collections.Generic;
using System.Web;

using Tools;
using Core;
using CoreWeb;
using NewMethod;

namespace NewMethodWeb
{
    public class PageSearch : NMPage
    {
        protected override bool ContextInit(bool redirect)
        {
            if( !base.ContextInit(redirect) )
                return false;

            //if (Page.IsPostBack)
            //    ListArgsInit();
            //else
            //    TheListArgs = null;

            return true;
        }

        public ListArgs TheListArgs = null;
        public virtual void ListArgsInit()
        {
        }

        public String SearchTerm = "";

        public virtual String ResultRender()
        {
            if (TheListArgs == null)
                return "";

            int count = 0;
            NewMethodWeb.WebTableHighFive hf = new WebTableHighFive();
            return hf.ListRender((ContextNM)TheContext, Session, TheListArgs, this, ref count);
        }
    }
}