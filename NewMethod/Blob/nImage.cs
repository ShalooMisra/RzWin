using System;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace NewMethod
{
    public partial class nImage : nBlob 
    {
        //Constructors
        public nImage(): base()
        {
            bytes = new Byte[0];
        }
        public nImage(Byte[] b): base(b)
        {

        }
        public nImage(nImage i): base()
        {
            bytes = i.bytes;
        }
        public nImage(Image i): base()
        {
            bytes = GetPictureBytes(i);
        }
        //Public Static Functions
        public static Boolean operator ==(nImage i1, nImage i2)
        {
            if ((object)i1 == null && (object)i2 == null)
                return true;
            if ((object)i1 == null && (object)i2 != null)
                return false;
            if ((object)i1 != null && (object)i2 == null)
                return false;
            return i1.bytes == i2.bytes;
        }
        public static Boolean operator !=(nImage i1, nImage i2)
        {
            if ((object)i1 == null && (object)i2 == null)
                return false;
            if ((object)i1 == null && (object)i2 != null)
                return true;
            if ((object)i1 != null && (object)i2 == null)
                return true;
            return i1.bytes != i2.bytes;
        }
        public static implicit operator Byte[](nImage i)
        {
            return i.bytes;
        }
        public static implicit operator nImage(Byte[] b)
        {
            return new nImage(b);
        }
        public static implicit operator Image(nImage i)
        {
            if (i == null)
                return null;
            return GetPictureImage(i.bytes);
        }
        public static implicit operator nImage(Image i)
        {
            return new nImage(i);
        }
        public static Image GetPictureImage(Byte[] picturedata)
        {
            try
            {
                if (picturedata == null)
                    return null;
                if (picturedata.Length <= 0)
                    return null;
                MemoryStream xStream = new System.IO.MemoryStream(picturedata);
                return Image.FromStream(xStream);
            }
            catch (Exception)
            { return null; }
        }
        public static Byte[] GetPictureBytes(Image picture)
        {
            try
            {
                Byte[] Ret;
                MemoryStream ms = new MemoryStream();
                picture.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Ret = ms.ToArray();
                return Ret;
            }
            catch
            { return new Byte[0]; }
        }
        public static Image GetImageFromFile()
        {
            Form f = null;
            return GetImageFromFile(f);
        }
        public static Image GetImageFromFile(Form owner)
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png,*.pdf)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png;*.pdf";
                oFile.ShowDialog(owner);
                String filepath = oFile.FileName;
                if (!Tools.Strings.StrExt(filepath))
                    return null;
                if (!System.IO.File.Exists(filepath))
                    return null;
                Byte[] image = System.IO.File.ReadAllBytes(filepath);
                if (image == null)
                    return null;
                if (image.Length <= 0)
                    return null;
                Byte[] picturedata = GetJPGFromImageData(image);
                if (picturedata == null)
                    return null;
                if (picturedata.Length <= 0)
                    return null;
                return GetPictureImage(picturedata);
            }
            catch (Exception)
            { return null; }
        }
        public static Image GetImageFromFile(string filepath)
        {
            try
            {
                if (!Tools.Strings.StrExt(filepath))
                    return null;
                if (!System.IO.File.Exists(filepath))
                    return null;
                Byte[] image = System.IO.File.ReadAllBytes(filepath);
                if (image == null)
                    return null;
                if (image.Length <= 0)
                    return null;
                Byte[] picturedata = GetJPGFromImageData(image);
                if (picturedata == null)
                    return null;
                if (picturedata.Length <= 0)
                    return null;
                return GetPictureImage(picturedata);
            }
            catch (Exception)
            { return null; }
        }
        //Private Static Functions
        private static Byte[] GetJPGFromImageData(Byte[] image)
        {
            try
            {
                System.IO.MemoryStream xStream = new System.IO.MemoryStream(image);
                Image xImage = Image.FromStream(xStream);
                System.IO.MemoryStream xJPG = new System.IO.MemoryStream();
                xImage.Save(xJPG, System.Drawing.Imaging.ImageFormat.Jpeg);
                return xJPG.ToArray();
            }
            catch
            { return image; }
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
                filename += ".jpg";
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
            return "JPG Files (*.jpg,*.jpeg)|*.jpg;*.jpeg";
        }
    }
}