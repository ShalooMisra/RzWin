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
    public class BudgetArgsGet : OKCancel
    {
        //Private Variables
        private LabelControl lblTop;
        private LabelControl lblTop2;
        private Int32Control intYear;
        private RadioButtonControl optScratch;
        private LabelControl lblScratch;
        private LabelControl lblScratch2;
        private LabelControl lblPrevious;
        private LabelControl lblPrevious2;

        //Constructors
        public BudgetArgsGet(ContextRz xs)
        {
            lblTop = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblTop", "", "Create a New Budget")));
            lblTop2 = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblTop2", "", "Begin by specifying the year for the new budget.")));
            intYear = (Int32Control)SpotAdd(ControlAdd(new Int32Control("intYear", "", DateTime.Now.Year + 1)));
            optScratch = (RadioButtonControl)SpotAdd(ControlAdd(new RadioButtonControl("ctl_optScratch", "", "scratch", GetRadioConfig(), RadioAlign.Vertical)));
            lblScratch = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblScratch", "", "This option lets you manually enter amounts for each account")));
            lblScratch2 = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblScratch2", "", "that you want to track.")));
            lblPrevious = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblPrevious", "", "This option automatically enters the monthly totals from last year")));
            lblPrevious2 = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblPrevious2", "", "for each account in this budget.")));
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
            sb.AppendLine("<div id=\"height_div\" style=\"height: 140px;\">");
            lblTop.Render(x, sb, screenHandle, viewHandle, session, page);
            lblTop2.Render(x, sb, screenHandle, viewHandle, session, page);
            intYear.Render(x, sb, screenHandle, viewHandle, session, page);
            optScratch.Render(x, sb, screenHandle, viewHandle, session, page);
            lblScratch.Render(x, sb, screenHandle, viewHandle, session, page);
            lblScratch2.Render(x, sb, screenHandle, viewHandle, session, page);
            lblPrevious.Render(x, sb, screenHandle, viewHandle, session, page);
            lblPrevious2.Render(x, sb, screenHandle, viewHandle, session, page);
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
            DialogResultBudgetArgs result = new DialogResultBudgetArgs();
            NewBudgetArgs a = new NewBudgetArgs();
            string s = "";
            args.Vars.TryGetValue("ctl_intyear", out s);
            int y = 0;
            try { y = Convert.ToInt32(s); }
            catch { }
            if (y <= 1999 && y >= 3001)
            {
                x.TheLeader.Tell("You have entered an invalid date.");
                result.Success = false;
            }
            a.Year = y;
            a.Name = "RZ" + y.ToString();
            s = "";
            args.Vars.TryGetValue("ctl_optscratch", out s);
            if (!Tools.Strings.StrCmp(s, "scratch"))
                a.FromScratch = false;
            else
                a.FromScratch = true;
            result.Budget = budget.CreateNewBudget((ContextRz)x, a);
            if (result.Budget == null)
                result.Success = false;
            ThreadHandle.Result = result;
            base.OK(x, args);
        }
        protected override void Cancel(Core.Context x, SpotActArgs args)
        {
            DialogResultBudgetArgs result = new DialogResultBudgetArgs();
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
                return 260;
            }
        }
        //Private Functions
        private RadioControlConfig GetRadioConfig()
        {
            RadioControlConfig r = new RadioControlConfig();
            RadioControlConfig rr = new RadioControlConfig();
            rr.Caption = "Create budget from scratch.";
            rr.Value = "scratch";
            rr.Bold = true;
            rr.ExtraStyle = " margin-bottom: 35px;";
            r.AllOptions.Add(rr);
            rr = new RadioControlConfig();
            rr.Caption = "Create budget from previous year's actual data.";
            rr.Value = "prev";
            rr.Bold = true;
            r.AllOptions.Add(rr);
            return r;
        }
        private string GetScripts()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetResize());
            sb.AppendLine("ResizeBudget();");
            return sb.ToString();
        }
        private String GetResize()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function ResizeBudget() {");
            sb.AppendLine(lblTop.Select + ".css('top', 5);");
            sb.AppendLine(lblTop.Select + ".css('left', 5);");
            sb.AppendLine(lblTop2.Select + ".css('left', 5);");
            sb.AppendLine(lblTop2.PlaceBelow(lblTop));
            sb.AppendLine(intYear.PlaceBelow(lblTop2));
            sb.AppendLine(intYear.Select + ".css('left', 140);");           
            sb.AppendLine(optScratch.PlaceBelow(intYear));
            sb.AppendLine(lblScratch.Select + ".css('top', 100);");             
            sb.AppendLine(lblScratch2.Select + ".css('top', 115);");
            sb.AppendLine(lblPrevious.Select + ".css('top', 155);");
            sb.AppendLine(lblPrevious2.Select + ".css('top', 170);");
            sb.AppendLine(lblScratch.Select + ".css('left', 5);");
            sb.AppendLine(lblScratch2.Select + ".css('left', 5);");
            sb.AppendLine(lblPrevious.Select + ".css('left', 5);");
            sb.AppendLine(lblPrevious2.Select + ".css('left', 5);");
            sb.AppendLine("}");
            return sb.ToString();      
        }
        private void AdjustControls()
        {
            lblTop.TextFontSize = FontSize.Large;
            lblTop.TextBold = true;
            lblTop2.TextFontSize = FontSize.Small;
            intYear.TextFontSize = FontSize.Small;
            intYear.UseNameInID = true;
            optScratch.UseNameInID = true;
            lblScratch.TextFontSize = FontSize.Small;
            lblPrevious.TextFontSize = FontSize.Small;
            lblScratch2.TextFontSize = FontSize.Small;
            lblPrevious2.TextFontSize = FontSize.Small;
            intYear.FixedWidth = 50;
        }
    }
    public class DialogResultBudgetArgs : DialogResult
    {        
        public budget Budget;        
    }

    public class BudgetPercentArgsGet : OKCancel
    {
        //Private Variables
        RadioButtonControl optIncrease;
        DoubleControl dblPercent;

        //Constructors
        public BudgetPercentArgsGet(ContextRz xs)
        {
            optIncrease = (RadioButtonControl)SpotAdd(ControlAdd(new RadioButtonControl("ctl_optIncrease", "", "increase", GetRadioConfig(), RadioAlign.Vertical)));
            dblPercent = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("dblPercent", "", 0)));
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
            sb.AppendLine("<div id=\"height_div\" style=\"height: 10px;\">");
            optIncrease.Render(x, sb, screenHandle, viewHandle, session, page);
            dblPercent.Render(x, sb, screenHandle, viewHandle, session, page);
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
            DialogResultBudgetPercentArgs result = new DialogResultBudgetPercentArgs();
            string s = "";
            args.Vars.TryGetValue("ctl_optincrease", out s);
            result.Decrease = Tools.Strings.StrCmp("true", s);
            s = "";
            args.Vars.TryGetValue("ctl_dblpercent", out s);
            double d = 0;
            try
            {
                d = Convert.ToDouble(s);
            }
            catch { }
            result.Percent = d;
            if (result.Percent <= 0)
                result.Success = false;
            ThreadHandle.Result = result;
            base.OK(x, args);
        }
        protected override void Cancel(Core.Context x, SpotActArgs args)
        {
            DialogResultBudgetPercentArgs result = new DialogResultBudgetPercentArgs();
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
                return 150;
            }
        }
        //Private Functions
        private string GetScripts()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetResize());
            sb.AppendLine("ResizeBudget();");
            return sb.ToString();
        }
        private String GetResize()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function ResizeBudget() {");
            sb.AppendLine(optIncrease.Select + ".css('top', 5);");
            sb.AppendLine(optIncrease.Select + ".css('left', 5);");
            sb.AppendLine(dblPercent.Select + ".css('top', 10);");
            sb.AppendLine(dblPercent.PlaceRight(optIncrease, false, 20));
            sb.AppendLine("}");
            return sb.ToString();
        }
        private void AdjustControls()
        {
            dblPercent.FixedWidth = 50;
            dblPercent.UseNameInID = true;
        }
        private RadioControlConfig GetRadioConfig()
        {
            RadioControlConfig r = new RadioControlConfig();
            RadioControlConfig rr = new RadioControlConfig();
            rr.Caption = "Increase each monthly amount in this row by this percentage";
            rr.Value = "increase";
            rr.FontSize = FontSize.Small;
            r.AllOptions.Add(rr);
            rr = new RadioControlConfig();
            rr.Caption = "Decrease each monthly amount in this row by this percentage";
            rr.Value = "decrease";
            rr.FontSize = FontSize.Small;
            r.AllOptions.Add(rr);
            return r;
        }
    }
    public class DialogResultBudgetPercentArgs : DialogResult
    {
        public double Percent = 0;
        public bool Decrease = false;
    }

    //public class NewBudgetArgsGet : OKCancel
    //{
    //    //Private Variables
    //    RadioButtonControl optIncrease;

    //    //Constructors
    //    public NewBudgetArgsGet(ContextRz xs)
    //    {
    //        optIncrease = (RadioButtonControl)SpotAdd(ControlAdd(new RadioButtonControl("ctl_optIncrease", "", "increase", GetRadioConfig(), RadioAlign.Vertical)));
    //        AdjustControls();
    //    }
    //    //Public Override Functions
    //    public override void Act(Core.Context x, SpotActArgs args)
    //    {
    //        base.Act(x, args);
    //        ContextRz xrz = (ContextRz)x;
    //        switch (args.ActionId)
    //        {
    //            default:
    //                break;
    //        }
    //    }
    //    public override void RenderBody(Core.Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
    //    {
    //        base.RenderBody(x, sb, screenHandle, viewHandle, session, page);
    //        sb.AppendLine("<div id=\"height_div\" style=\"height: 10px;\">");
    //        optIncrease.Render(x, sb, screenHandle, viewHandle, session, page);
    //        sb.AppendLine("</div>");
    //    }
    //    public override string AfterHtml
    //    {
    //        get
    //        {
    //            String ret = base.AfterHtml;
    //            ret += "<script type=\"text/javascript\">" + GetScripts() + "</script>";
    //            return ret;
    //        }
    //    }
    //    //Protected Override Functions
    //    protected override void OK(Core.Context x, SpotActArgs args)
    //    {
    //        ContextRz xs = (ContextRz)x;
    //        DialogResultNewBudgetArgs result = new DialogResultNewBudgetArgs();
    //        string s = "";
    //        args.Vars.TryGetValue("ctl_optincrease", out s);
            
            
    //        result.Args = new NewBudgetArgs();


    //        result.Success = false;
    //        ThreadHandle.Result = result;
    //        base.OK(x, args);
    //    }
    //    protected override void Cancel(Core.Context x, SpotActArgs args)
    //    {
    //        DialogResultNewBudgetArgs result = new DialogResultNewBudgetArgs();
    //        result.Success = false;
    //        ThreadHandle.Result = result;
    //        base.Cancel(x, args);
    //    }
    //    protected override int DialogWidth
    //    {
    //        get
    //        {
    //            return 520;
    //        }
    //    }
    //    protected override int DialogHeight
    //    {
    //        get
    //        {
    //            return 150;
    //        }
    //    }
    //    //Private Functions
    //    private string GetScripts()
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.AppendLine(GetResize());
    //        sb.AppendLine("ResizeBudget();");
    //        return sb.ToString();
    //    }
    //    private String GetResize()
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.AppendLine("function ResizeBudget() {");
    //        sb.AppendLine(optIncrease.Select + ".css('top', 5);");
    //        sb.AppendLine(optIncrease.Select + ".css('left', 5);");
    //        sb.AppendLine("}");
    //        return sb.ToString();
    //    }
    //    private void AdjustControls()
    //    {

    //    }
    //    private RadioControlConfig GetRadioConfig()
    //    {
    //        RadioControlConfig r = new RadioControlConfig();
    //        RadioControlConfig rr = new RadioControlConfig();
    //        rr.Caption = "Create budget from scratch.";
    //        rr.Value = "scratch";
    //        rr.FontSize = FontSize.Small;
    //        r.AllOptions.Add(rr);
    //        rr = new RadioControlConfig();
    //        rr.Caption = "Decrease each monthly amount in this row by this percentage";
    //        rr.Value = "decrease";
    //        rr.FontSize = FontSize.Small;
    //        r.AllOptions.Add(rr);
    //        return r;
    //    }
    //}
    //public class DialogResultNewBudgetArgs : DialogResult
    //{
    //    public NewBudgetArgs Args;
    //}
}