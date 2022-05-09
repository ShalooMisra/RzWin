using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rz5;
using CoreWeb;
using System.Collections;

public class ChooseFromArray : OKCancel
{
    //Private Variables
    string Caption = "";
    Dictionary<string,string> Choices;

    //Constructors
    public ChooseFromArray(ContextRz xs, ArrayList choices, String caption)
    {
        Caption = caption;
        Choices = GetChoiceDictionary(choices);
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
        sb.AppendLine("<div id=\"height_div\" style=\"height: 140px; overflow: scroll;\">");
        sb.AppendLine("<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">");
        foreach (KeyValuePair<string, string> kvp in Choices)
        {
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"100%\"><input type=\"checkbox\" id=\"ctl_" + kvp.Key + "\" name=\"ctl_" + kvp.Key + "\" style=\"margin: 2px;\">&nbsp;" + kvp.Value + "</td>");
            sb.AppendLine("  </tr>");
        }
        sb.AppendLine("</table>");
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
        DialogResultChooseFromArrayArgs result = new DialogResultChooseFromArrayArgs();
        result.List = new ArrayList();       
        foreach (KeyValuePair<string, string> kvp in args.Vars)
        {
            if (!Tools.Strings.StrCmp(kvp.Value, "true"))
                continue;
            string v = "";
            Choices.TryGetValue(kvp.Key.Replace("ctl_", "").Trim(), out v);
            if (Tools.Strings.StrExt(v))
                result.List.Add(v);
        }
        if (result.List.Count <= 0)
            result.Success = false;
        ThreadHandle.Result = result;
        base.OK(x, args);
    }
    protected override void Cancel(Core.Context x, SpotActArgs args)
    {
        DialogResultChooseFromArrayArgs result = new DialogResultChooseFromArrayArgs();
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
    private string GetScripts()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(GetResize());
        sb.AppendLine("ResizeChooseFromArray();");
        return sb.ToString();
    }
    private String GetResize()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("function ResizeChooseFromArray() {");
        sb.AppendLine("}");
        return sb.ToString();
    }
    private void AdjustControls()
    {

    }
    private Dictionary<string, string> GetChoiceDictionary(ArrayList choices)
    {
        Dictionary<string, string> d = new Dictionary<string, string>();
        foreach (string s in choices)
        {
            d.Add(Tools.Strings.GetNewID(), s);
        }
        return d;
    }
}
public class DialogResultChooseFromArrayArgs : DialogResult
{
    public ArrayList List;
}
