using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Drawing.Imaging;


namespace NewMethod
{
    public partial class SysNewMethod
    {
        public bool TriedAccessingResources = false;
        public bool ResourcesAvailable = false;
        private Assembly ResourceAssembly = null;

        //Public Functions
        public Image GetResourceImage_Trans(String strImageKey)
        {
            Image i = GetResourceImage(strImageKey);
            if (i == null)
                return null;

            //Create a Bitmap based on the previously modified photograph Bitmap
            Bitmap bmWatermark = new Bitmap(i.Width, i.Height);
            bmWatermark.SetResolution(i.HorizontalResolution, i.VerticalResolution);
            //Load this Bitmap into a new Graphic Object
            Graphics grWatermark = Graphics.FromImage(bmWatermark);

            //To achieve a transulcent watermark we will apply (2) color 
            //manipulations by defineing a ImageAttributes object and 
            //seting (2) of its properties.
            ImageAttributes imageAttributes = new ImageAttributes();

            //The first step in manipulating the watermark image is to replace 
            //the background color with one that is trasparent (Alpha=0, R=0, G=0, B=0)
            //to do this we will use a Colormap and use this to define a RemapTable
            ColorMap colorMap = new ColorMap();

            //My watermark was defined with a background of 100% Green this will
            //be the color we search for and replace with transparency
            colorMap.OldColor = Color.Magenta;
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);

            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            grWatermark.DrawImage(i,
                new Rectangle(0, 0, i.Width, i.Height),  //Set the detination Position
                0,                  // x-coordinate of the portion of the source image to draw. 
                0,                  // y-coordinate of the portion of the source image to draw. 
                i.Width,            // Watermark Width
                i.Height,		    // Watermark Height
                GraphicsUnit.Pixel, // Unit of measurment
                imageAttributes);   //ImageAttributes Object

            return bmWatermark;
        }
        public Image GetResourceImage(String strImageKey)
        {
            if (!TriedAccessingResources)
                AccessResources();

            //if (!ResourcesAvailable)
            //{
            //    foreach (n_sys xs in ParentSystems.All)
            //    {
            //        Image ret = xs.GetResourceImage(strImageKey);
            //        if (ret != null)
            //            return ret;
            //    }
            //}

            if (ResourceAssembly != null)
            {
                if (Tools.Strings.StrExt(strImageKey))
                {
                    Stream s = ResourceAssembly.GetManifestResourceStream(this.Name + "_Resources." + strImageKey);

                    if (s == null)
                        return null;

                    Image i = Image.FromStream(s);
                    return i;
                }
                else
                    return null;
            }
            else
            {
                return null;
            }
        }
        public String[] GetResourceList()
        {
            if (!TriedAccessingResources)
                AccessResources();

            if (ResourceAssembly != null)
            {
                return ResourceAssembly.GetManifestResourceNames();
            }
            else
            {
                return null;
            }
        }
        public bool AccessResources()
        {
            TriedAccessingResources = true;
            String strFile = ResourceFileName;
            if( !File.Exists(strFile) )
                return false;

            try
            {
                ResourceAssembly = Assembly.LoadFile(strFile);
                ResourcesAvailable = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public String ResourceFileName
        {
            get
            {
                String strFolder = "";
                String strFile = "";

                if (Tools.Misc.IsDevelopmentMachine())
                {
                    strFolder = "c:\\eternal\\code\\" + this.Name + "_resources\\bin\\debug\\";
                    strFile = this.Name + "_resources.dll";
                }
                else
                {
                    strFolder = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath());
                    strFile = this.Name + "_resources.dll";
                }

                return strFolder + nTools.GetHighestFileName(strFolder, strFile);
            }
        }

       
        //public String GetIconKeyByClass(String strClass)
        //{
        //    n_class c = GetClassByName(strClass);
        //    if (c == null)
        //        return "";

        //    return c.icon_key;
        //}
    }
}