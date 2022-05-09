using System;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace NewMethod
{
    public partial class nIcon : nBlob
    {
        //Constructors
        public nIcon(): base()
        {
            bytes = new Byte[0];
        }
        public nIcon(Byte[] b): base(b)
        {

        }
        public nIcon(nIcon i): base()
        {
            bytes = i.bytes;
        }
        //Public Static Functions
        public static Boolean operator ==(nIcon i1, nIcon i2)
        {
            if ((object)i1 == null && (object)i2 == null)
                return true;
            if ((object)i1 == null && (object)i2 != null)
                return false;
            if ((object)i1 != null && (object)i2 == null)
                return false;
            return i1.bytes == i2.bytes;
        }
        public static Boolean operator !=(nIcon i1, nIcon i2)
        {
            if ((object)i1 == null && (object)i2 == null)
                return false;
            if ((object)i1 == null && (object)i2 != null)
                return true;
            if ((object)i1 != null && (object)i2 == null)
                return true;
            return i1.bytes != i2.bytes;
        }
        public static implicit operator Byte[](nIcon i)
        {
            return i.bytes;
        }
        public static implicit operator nIcon(Byte[] b)
        {
            return new nIcon(b);
        }
        public static implicit operator Icon(nIcon i)
        {
            if (i == null)
                return null;
            return GetIconFromImageData(i.bytes);
        }
        public static nIcon GetIconFromFile()
        {
            return GetIconFromFile(null);
        }
        public static nIcon GetIconFromFile(Form owner)
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Icon Files (*.ico)|*.ico|Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png,*.pdf)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png;*.pdf";
                oFile.ShowDialog(owner);
                String filepath = oFile.FileName;
                if (!Tools.Strings.StrExt(filepath))
                    return null;
                if (!System.IO.File.Exists(filepath))
                    return null;
                return new nIcon(System.IO.File.ReadAllBytes(filepath));
            }
            catch (Exception)
            { return null; }
        }
        //Private Static Functions
        private static Icon GetIconFromImageData(Byte[] image)
        {
            try
            {
                Bitmap bmp = new Bitmap(Image.FromStream(new System.IO.MemoryStream(image), true, true));
                IntPtr Hicon = bmp.GetHicon();
                return Icon.FromHandle(Hicon);
            }
            catch
            { return null; }
        }
        //Public Override Functions
        public override Boolean Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override Int32 GetHashCode()
        {
            return base.GetHashCode();
        }
        public override String ToString()
        {
            return base.ToString();
        }
        public override String SaveAsFile(ContextNM context, String file, Boolean bNoDelete, String folderpath, Boolean bShowSaveAs)
        {
            try
            {
                if (bytes == null)
                    return "";
                String filename = GetSaveFilePath(file, bNoDelete, folderpath, bShowSaveAs);
                if (!Tools.Strings.StrExt(filename))
                    return "";
                filename += ".ico";
                FileStream fs = File.Create(filename);
                if (!File.Exists(filename))
                    return "";
                if (fs == null)
                    return "";
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                if (bShowSaveAs)
                    context.TheLeader.Tell("Saved");;
                return filename;
            }
            catch { return ""; }
        }
        public override String GetFileSaveFilter()
        {
            return "ICO Files (*.ico)|*.ico";
        }
    }
}
