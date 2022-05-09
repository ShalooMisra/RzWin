using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Core;

namespace CoreUI
{
    public class ScreenHandle : SpotHandle
    {
        public ManualResetEvent AsyncCheck = new ManualResetEvent(false);
        public List<String> ControlsToRemove = new List<string>();
        public String CurrentPageId = "";

        public List<String> ScriptsToRun = new List<String>();
        public List<ElementReplace> ElementsToReplace = new List<ElementReplace>();
        public String SessionId = "";
        public List<String> Definitions = new List<String>();
        public List<String> FilesToDownload = new List<String>();

        public ScreenHandle()
        {
            HideOverflow = false;
            TheScreen = this;
            WidthAbs = 100;
            HeightAbs = 100;
        }

        public void Flow()
        {
            AsyncCheck.Set();
        }

        public void FlowIfChanged()
        {
            if (ChangesToSend)
                Flow();
        }

        public virtual bool ChangesToSend
        {
            get
            {
                return Changed || ContainsChanges || ControlsToRemove.Count > 0 || ScriptsToRun.Count > 0 || ElementsToReplace.Count > 0 || FilesToDownload.Count > 0;
            }
        }

        public override void ResizeRender(StringBuilder sb)
        {
            sb.AppendLine("                    $('#" + SpotHandle.DivIdConvert(Uid) + "').css('width', $(window).width());");  // - 10
            sb.AppendLine("                    $('#" + SpotHandle.DivIdConvert(Uid) + "').css('height', $(window).height());");  // seems to bottom out just below the actual bottom, triggering the scrollbars  - 10
            //sb.AppendLine("                    $('#resizeinfo').html('window width: ' + $(window).width() + '<br>div width: ' + $('#" + SpotHandle.DivIdConvert(Uid) + "').width());");

            base.ResizeRender(sb);
        }

        //size testing
        //public override string BorderRender()
        //{
        //    return "border-style: solid; border-color: Blue; border-width: thick";
        //}
    }

    public class ElementReplace
    {
        public String Id;
        public String Content;

        public ElementReplace(String id, String content)
        {
            Id = id;
            Content = content;
        }
    }
}
