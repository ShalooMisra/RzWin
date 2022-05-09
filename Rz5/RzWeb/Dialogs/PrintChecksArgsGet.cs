using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreWeb;
using Rz5;
using System.Collections;
using System.Text;
using System.Drawing;

namespace RzWeb
{
    public class PrintChecksArgsGet : OKCancel
    {
        //Private Variables

        //Constructors
        public PrintChecksArgsGet(ContextRz xs)
        {
            AdjustControls();
        }
        //Public Override Functions
        public override void Act(Core.Context x, SpotActArgs args)
        {
            base.Act(x, args);
            ContextRz xrz = (ContextRz)x;
            switch (args.ActionId)
            {
                default:
                    break;
            }
        }
        public override void RenderBody(Core.Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderBody(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div style=\"height: 115px;\">");
            sb.AppendLine("Gutz");            
            sb.AppendLine("</div>");            
        }
        public override string AfterHtml
        {
            get
            {
                String ret = base.AfterHtml;
                ret += "<script type=\"text/javascript\">" + GetScripts() + "</script>";
                return ret;
            }
        }
        //Protected Override Functions
        protected override void OK(Core.Context x, SpotActArgs args)
        {
            ContextRz xs = (ContextRz)x;
            DialogResultPrintChecksArgs result = new DialogResultPrintChecksArgs();           
            ThreadHandle.Result = result;
            base.OK(x, args);
        }
        protected override void Cancel(Core.Context x, SpotActArgs args)
        {
            DialogResultPrintChecksArgs result = new DialogResultPrintChecksArgs();
            result.Success = false;
            ThreadHandle.Result = result;
            base.Cancel(x, args);
        }
        protected override int DialogWidth
        {
            get
            {
                return 520;
            }
        }
        protected override int DialogHeight
        {
            get
            {
                return 240;
            }
        }
        //Private Functions
        private string GetScripts()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetResize());
            sb.AppendLine("ResizePrintChecks();");
            return sb.ToString();
        }
        private String GetResize()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function ResizePrintChecks() {");
            sb.AppendLine("}");
            return sb.ToString();
        }
        private void AdjustControls()
        {

        }
    }
    public class DialogResultPrintChecksArgs : DialogResult
    {        
        
    }
}