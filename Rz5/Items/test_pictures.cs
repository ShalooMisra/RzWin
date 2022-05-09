using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class test_pictures : test_pictures_auto
    {
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                case "print":
                    Print((ContextRz)args.TheContext);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public void Print(ContextRz context)
        {
            context.Reorg();
            //String folder = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            //String g1 = folder + unique_id + "_g1.jpg";
            //String g2 = folder + unique_id + "_g2.jpg";
            //String g3 = folder + unique_id + "_g3.jpg";
            //String g4 = folder + unique_id + "_g4.jpg";
            //String htm = folder + unique_id + ".htm";

            //nBlobHandle h = new nBlobHandle(xSys, "test_pictures", "pic_1", this.unique_id);
            //if (File.Exists(g1))
            //    File.Delete(g1);
            //h.SaveAsFile(g1);

            //h = new nBlobHandle(xSys, "test_pictures", "pic_2", this.unique_id);
            //if (File.Exists(g2))
            //    File.Delete(g2);
            //h.SaveAsFile(g2);

            //h = new nBlobHandle(xSys, "test_pictures", "pic_3", this.unique_id);
            //if (File.Exists(g3))
            //    File.Delete(g3);
            //h.SaveAsFile(g3);

            //h = new nBlobHandle(xSys, "test_pictures", "pic_4", this.unique_id);
            //if (File.Exists(g4))
            //    File.Delete(g4);
            //h.SaveAsFile(g4);

            //StringBuilder ht = new StringBuilder();
            //ht.Append("<table border=\"0\"><tr><td colspan=\"2\">" + caption_1 + "</td></tr><tr><td>");

            //String size = " Height=\"387px\" Width=\"468px\" ";

            //if (File.Exists(g1))
            //    ht.Append("<img " + size + " src=\"file://" + g1 + "\">");

            //ht.Append("</td><td>");

            //if (File.Exists(g2))
            //    ht.Append("<img " + size + " src=\"file://" + g2 + "\">");

            //ht.Append("</td></tr><tr><td colspan=\"2\">" + caption_2 + "</td></tr><td>");

            //if (File.Exists(g3))
            //    ht.Append("<img " + size + " src=\"file://" + g3 + "\">");

            //ht.Append("</td><td>");

            //if (File.Exists(g4))
            //    ht.Append("<img " + size + " src=\"file://" + g4 + "\">");

            //ht.Append("</td></tr></table>");
            //Tools.Files.SaveFileAsString(htm, ht.ToString());
            //RzApp.xMainForm.BrowseWebAddress("file://" + htm);

        }
        

        public override string ToString()
        {
            return "Test Pictures";
        }
    }
}
