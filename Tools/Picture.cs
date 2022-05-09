using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Xml;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Tools
{
    public partial class Picture
    {
        public static Image GetImage(String strFile, int width, int height)
        {
            try
            {
                if (!IsPictureFile(strFile))
                {
                    Bitmap b = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(b);
                    g.DrawString(Path.GetExtension(strFile), new Font("Times New Roman", 12), Brushes.Blue, new PointF(3, 3));
                    g.Dispose();
                    return b;
                }
                Image image = System.Drawing.Image.FromFile(strFile);
                if (image == null)
                {
                    Bitmap b = new Bitmap(width, height);
                    return b;
                }
                return GetThumbnail(image, width, height);
            }
            catch
            {
                return new Bitmap(width, height);
            }
        }

        public static Byte[] GetImageBytesFromUrl(String url)
        {
            try
            {
                Image i;
                byte[] imageBytes;
                using (var webClient = new WebClient())
                {
                    imageBytes = webClient.DownloadData(url);
                }
                return imageBytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public static Byte[] GetImageBytesFromFilePath(String filePath)
        //{
        //    try
        //    {

        //        if (string.IsNullOrEmpty(filePath))
        //            return null;
        //        return File.ReadAllBytes(filePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        /// 
        // C#
        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        //public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        //{
        //    Bitmap result = new Bitmap(width, height);
        //    using (Graphics g = Graphics.FromImage(result))
        //    {
        //        g.DrawImage(bmp, 0, 0, width, height);
        //    }

        //    return result;
        //}


        public static Image CreateImageFromUrl(string sourceUrl)
        {

            Image i;
            Byte[] imageBytes = GetImageBytesFromUrl(sourceUrl);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                i = Image.FromStream(ms);
            }
            return i;
            //Keep this inside the ms to avoid GDI+ errors
            //if (width > 0 || height > 0)
            //    b = ResizeImage(b, width, height);



        }
        //public static Image CreateImageFromFilePath(string filePath)
        //{
        //    ////string path = GetL
        //    //Image i;
        //    ////Byte[] imageBytes = GetImageBytesFromFilePath(filePath);
        //    //if (!File.Exists(filePath))
        //    //    throw new Exception("File not found: " + filePath);
        //    //i = Image.FromFile(filePath);
        //    //return i;
        //    ////Keep this inside the ms to avoid GDI+ errors
        //    ////if (width > 0 || height > 0)
        //    ////    b = ResizeImage(b, width, height);


        //    Image i = Image.FromFile(filePath);
        //    Byte[] imageBytes = File.ReadAllBytes(filePath);
        //    using (MemoryStream ms = new MemoryStream(imageBytes))
        //    {
        //        i = Image.FromStream(ms);
        //    }
        //    return i;
        //}




        public static Image GetGenericThumbnail(int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(b);
            g.DrawRectangle(new Pen(Brushes.Blue, 2.0F), new Rectangle(0, 0, width, height));
            g.Dispose();
            return b;
        }

        public static Image GetThumbnailScaleWidth(Image i, int width)
        {
            if (i.Width <= width)
                return i;

            Double factor = Convert.ToDouble(width) / Convert.ToDouble(i.Size.Width);
            int height = Convert.ToInt32(i.Size.Height * factor);
            return GetThumbnailScale(i, width, height);
        }

        public static Image GetThumbnailScaleHeight(Image i, int height)
        {
            if (i.Height <= height)
                return i;

            Double factor = Convert.ToDouble(height) / Convert.ToDouble(i.Size.Height);
            int width = Convert.ToInt32(i.Size.Width * factor);
            return GetThumbnailScale(i, width, height);
        }

        public static Image GetThumbnailScale(Image i, int width, int height)
        {
            if (i == null)
                return null;

            Bitmap result = new Bitmap(width, height);

            //use a graphics object to draw the resized image into the bitmap
            using (Graphics graphics = Graphics.FromImage(result))
            {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //draw the image into the target bitmap
                graphics.DrawImage(i, 0, 0, result.Width, result.Height);
            }

            //return the resulting bitmap
            return result;
        }


        public static Image GetThumbnail(Image i, int width, int height)
        {
            try
            {
                // create the actual thumbnail image
                Image thumbnailImage = i.GetThumbnailImage(width, height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
                return thumbnailImage;
            }
            catch { return null; }
        }
        public static bool ThumbnailCallback()
        {
            return true;
        }
        public static bool IsPictureFile(String strFile)
        {
            switch (Path.GetExtension(strFile).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                case ".bmp":
                case ".gif":
                case ".png":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Options to specify the size of icons to return.
        /// </summary>
        public enum IconSize
        {
            /// <summary>
            /// Specify large icon - 32 pixels by 32 pixels.
            /// </summary>
            Large = 0,
            /// <summary>
            /// Specify small icon - 16 pixels by 16 pixels.
            /// </summary>
            Small = 1
        }

        /// <summary>
        /// Options to specify whether folders should be in the open or closed state.
        /// </summary>
        public enum FolderType
        {
            /// <summary>
            /// Specify open folder.
            /// </summary>
            Open = 0,
            /// <summary>
            /// Specify closed folder.
            /// </summary>
            Closed = 1
        }

        /// <summary>
        /// Returns an icon for a given file - indicated by the name parameter.
        /// </summary>
        /// <param name="name">Pathname for file.</param>
        /// <param name="size">Large or small</param>
        /// <param name="linkOverlay">Whether to include the link icon</param>
        /// <returns>System.Drawing.Icon</returns>
        public static System.Drawing.Icon GetFileIcon(string name, IconSize size, bool linkOverlay)
        {
            Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
            uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;

            if (true == linkOverlay) flags += Shell32.SHGFI_LINKOVERLAY;

            /* Check the size specified for return. */
            if (IconSize.Small == size)
            {
                flags += Shell32.SHGFI_SMALLICON;
            }
            else
            {
                flags += Shell32.SHGFI_LARGEICON;
            }

            Shell32.SHGetFileInfo(name,
                Shell32.FILE_ATTRIBUTE_NORMAL,
                ref shfi,
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                flags);

            // Copy (clone) the returned icon to a new object, thus allowing us to clean-up properly
            System.Drawing.Icon icon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
            User32.DestroyIcon(shfi.hIcon);     // Cleanup
            return icon;
        }

        /// <summary>
        /// Used to access system folder icons.
        /// </summary>
        /// <param name="size">Specify large or small icons.</param>
        /// <param name="folderType">Specify open or closed FolderType.</param>
        /// <returns>System.Drawing.Icon</returns>
        public static System.Drawing.Icon GetFolderIcon(IconSize size, FolderType folderType)
        {
            // Need to add size check, although errors generated at present!
            uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;

            if (FolderType.Open == folderType)
            {
                flags += Shell32.SHGFI_OPENICON;
            }

            if (IconSize.Small == size)
            {
                flags += Shell32.SHGFI_SMALLICON;
            }
            else
            {
                flags += Shell32.SHGFI_LARGEICON;
            }

            // Get the folder icon
            Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
            Shell32.SHGetFileInfo(null,
                Shell32.FILE_ATTRIBUTE_DIRECTORY,
                ref shfi,
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                flags);

            System.Drawing.Icon.FromHandle(shfi.hIcon); // Load the icon from an HICON handle

            // Now clone the icon, so that it can be successfully stored in an ImageList
            System.Drawing.Icon icon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();

            User32.DestroyIcon(shfi.hIcon);     // Cleanup
            return icon;
        }

        public static ImageFormat GetImageFormat(string filePath)
        {
            string ext = Path.GetExtension(filePath);
            switch (ext.ToLower())
            {
                case ".jpg":
                    return ImageFormat.Jpeg;
                case ".gif":
                    return ImageFormat.Gif;
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".png":
                    return ImageFormat.Png;
                case ".exif":
                    return ImageFormat.Exif;
                case ".tiff":
                    return ImageFormat.Tiff;
                case ".Wmf":
                    return ImageFormat.Wmf;
                case ".icon":
                    return ImageFormat.Icon;
                default:
                    return ImageFormat.Jpeg;

            }
        }


        //public static void GetFilePathFromLogoUrl(string url, out string strFilePath)
        //{
        //    //Get the Path
        //    strFilePath = null;
        //    Uri uri = new Uri(url);

        //    //Get the file Name
        //    string fileName = Path.GetFileName(uri.LocalPath);
        //    //Declare the local path to save to (i.e. temp)  
        //    string savePath = Path.GetTempPath();
        //    //string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        //    //Declare the full path includign filename
        //    strFilePath = savePath + fileName;

        //}


    }


    /// <summary>
    /// Wraps necessary Shell32.dll structures and functions required to retrieve Icon Handles using SHGetFileInfo. Code
    /// courtesy of MSDN Cold Rooster Consulting case study.
    /// </summary>
    /// 

    // This code has been left largely untouched from that in the CRC example. The main changes have been moving
    // the icon reading code over to the IconReader type.
    public class Shell32
    {

        public const int MAX_PATH = 256;
        [StructLayout(LayoutKind.Sequential)]
        public struct SHITEMID
        {
            public ushort cb;
            [MarshalAs(UnmanagedType.LPArray)]
            public byte[] abID;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ITEMIDLIST
        {
            public SHITEMID mkid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BROWSEINFO
        {
            public IntPtr hwndOwner;
            public IntPtr pidlRoot;
            public IntPtr pszDisplayName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszTitle;
            public uint ulFlags;
            public IntPtr lpfn;
            public int lParam;
            public IntPtr iImage;
        }

        // Browsing for directory.
        public const uint BIF_RETURNONLYFSDIRS = 0x0001;
        public const uint BIF_DONTGOBELOWDOMAIN = 0x0002;
        public const uint BIF_STATUSTEXT = 0x0004;
        public const uint BIF_RETURNFSANCESTORS = 0x0008;
        public const uint BIF_EDITBOX = 0x0010;
        public const uint BIF_VALIDATE = 0x0020;
        public const uint BIF_NEWDIALOGSTYLE = 0x0040;
        public const uint BIF_USENEWUI = (BIF_NEWDIALOGSTYLE | BIF_EDITBOX);
        public const uint BIF_BROWSEINCLUDEURLS = 0x0080;
        public const uint BIF_BROWSEFORCOMPUTER = 0x1000;
        public const uint BIF_BROWSEFORPRINTER = 0x2000;
        public const uint BIF_BROWSEINCLUDEFILES = 0x4000;
        public const uint BIF_SHAREABLE = 0x8000;

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public const int NAMESIZE = 80;
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
            public string szTypeName;
        };

        public const uint SHGFI_ICON = 0x000000100;     // get icon
        public const uint SHGFI_DISPLAYNAME = 0x000000200;     // get display name
        public const uint SHGFI_TYPENAME = 0x000000400;     // get type name
        public const uint SHGFI_ATTRIBUTES = 0x000000800;     // get attributes
        public const uint SHGFI_ICONLOCATION = 0x000001000;     // get icon location
        public const uint SHGFI_EXETYPE = 0x000002000;     // return exe type
        public const uint SHGFI_SYSICONINDEX = 0x000004000;     // get system icon index
        public const uint SHGFI_LINKOVERLAY = 0x000008000;     // put a link overlay on icon
        public const uint SHGFI_SELECTED = 0x000010000;     // show icon in selected state
        public const uint SHGFI_ATTR_SPECIFIED = 0x000020000;     // get only specified attributes
        public const uint SHGFI_LARGEICON = 0x000000000;     // get large icon
        public const uint SHGFI_SMALLICON = 0x000000001;     // get small icon
        public const uint SHGFI_OPENICON = 0x000000002;     // get open icon
        public const uint SHGFI_SHELLICONSIZE = 0x000000004;     // get shell size icon
        public const uint SHGFI_PIDL = 0x000000008;     // pszPath is a pidl
        public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;     // use passed dwFileAttribute
        public const uint SHGFI_ADDOVERLAYS = 0x000000020;     // apply the appropriate overlays
        public const uint SHGFI_OVERLAYINDEX = 0x000000040;     // Get the index of the overlay

        public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;

        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbFileInfo,
            uint uFlags
            );
    }

    /// <summary>
    /// Wraps necessary functions imported from User32.dll. Code courtesy of MSDN Cold Rooster Consulting example.
    /// </summary>
    public class User32
    {
        /// <summary>
        /// Provides access to function required to delete handle. This method is used internally
        /// and is not required to be called separately.
        /// </summary>
        /// <param name="hIcon">Pointer to icon handle.</param>
        /// <returns>N/A</returns>
        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);
    }

    public interface IGraphics
    {
        void DrawImage(Image i, int x, int y, int width, int height);
        void DrawImageAlternateResolution(Image i, int x, int y);
        void DrawLine(Pen pn, int x, int y, int stop_x, int stop_y);
        void FillRectangle(Brush b, int x, int y, int width, int height);
        void DrawRectangle(Pen p, Rectangle r);
        void DrawString(String strText, Font xFont, Color c, Point p);
        SizeF MeasureString(String strText, Font xFont);
        bool NeedsAlternateResolutionImages { get; }
    }

    public class GraphicsWrapper : IGraphics
    {
        Graphics G;
        public GraphicsWrapper(Graphics g)
        {
            G = g;
        }

        public virtual void DrawImage(Image i, int x, int y, int width, int height) { G.DrawImage(i, x, y, width, height); }
        public virtual void DrawLine(Pen pn, int x, int y, int stop_x, int stop_y) { G.DrawLine(pn, x, y, stop_x, stop_y); }
        public virtual void FillRectangle(Brush b, int x, int y, int width, int height) { G.FillRectangle(b, x, y, width, height); }
        public virtual void DrawRectangle(Pen p, Rectangle r) { G.DrawRectangle(p, r); }
        public virtual void DrawString(String strText, Font xFont, Color c, Point p) { G.DrawString(strText, xFont, new SolidBrush(c), p); }
        public SizeF MeasureString(String strText, Font xFont) { return G.MeasureString(strText, xFont); }
        public bool NeedsAlternateResolutionImages { get { return false; } }
        public void DrawImageAlternateResolution(Image i, int x, int y) { DrawImage(i, x, y, i.Width, i.Height); }

        public void Draw(DrawItem i)
        {
            if (i is DrawItemImage)
            {
                DrawItemImage dii = (DrawItemImage)i;
                DrawImage(dii.Image, dii.X, dii.Y, dii.Width, dii.Height);
            }
            else if (i is DrawItemLine)
            {
                DrawItemLine dil = (DrawItemLine)i;
                DrawLine(dil.Pen, dil.X, dil.Y, dil.StopX, dil.StopY);
            }
            else if (i is DrawItemFillRectangle)
            {
                DrawItemFillRectangle difr = (DrawItemFillRectangle)i;
                FillRectangle(difr.B, difr.X, difr.Y, difr.Width, difr.Height);
            }
            else if (i is DrawItemRectangle)
            {
                DrawItemRectangle dir = (DrawItemRectangle)i;
                DrawRectangle(dir.Pen, dir.R);
            }
            else if (i is DrawItemString)
            {
                DrawItemString dis = (DrawItemString)i;
                DrawString(dis.Text, dis.Font, dis.Color, dis.Point);
            }
        }
    }

    public class DrawItem
    {

    }

    public class DrawItemImage : DrawItem
    {
        public Image Image;
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public DrawItemImage(Image i, int x, int y, int width, int height)
        {
            Image = i;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        ~DrawItemImage()
        {
            Image = null;
        }
    }

    public class DrawItemLine : DrawItem
    {
        public Pen Pen;
        public int X;
        public int Y;
        public int StopX;
        public int StopY;

        public DrawItemLine(Pen p, int x, int y, int stop_x, int stop_y)
        {
            Pen = p;
            X = x;
            Y = y;
            StopX = stop_x;
            StopY = stop_y;
        }
    }

    public class DrawItemFillRectangle : DrawItem
    {
        public Brush B;
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public DrawItemFillRectangle(Brush b, int x, int y, int width, int height)
        {
            B = b;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }

    public class DrawItemRectangle : DrawItem
    {
        public Pen Pen;
        public Rectangle R;

        public DrawItemRectangle(Pen p, Rectangle r)
        {
            Pen = p;
            R = r;
        }
    }

    public class DrawItemString : DrawItem
    {
        public String Text;
        public Font Font;
        public Color Color;
        public Point Point;

        public DrawItemString(String strText, Font xFont, Color c, Point p)
        {
            Text = strText;
            Font = xFont;
            Color = c;
            Point = p;
        }
    }

    public class ImageHandle
    {
        public String Name;
        public Image Image;

        public ImageHandle(String name, Image i)
        {
            Name = name;
            Image = i;
        }
    }
}
