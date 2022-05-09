using System;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace NewMethod
{
    public partial class nFile : nBlob
    {
        //Public Variables
        public String extention = "";

        //Constructors
        public nFile(): base()
        {
            extention = "";
        }
        //Public Static Functions
        public static nFile GetFileFromDisk()
        {
            return GetFileFromDisk("");
        }
        public static nFile GetFileFromDisk(Boolean bAsk, Form owner)
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "All Files (*.*)|*.*";
                oFile.ShowDialog(owner);
                String filepath = oFile.FileName;
                if (!Tools.Strings.StrExt(filepath))
                    return null;
                if (!System.IO.File.Exists(filepath))
                    return null;
                String ext = nTools.GetFileExtention(filepath);
                if (!Tools.Strings.StrExt(ext))
                    return null;
                Byte[] b = System.IO.File.ReadAllBytes(filepath);
                if (b == null)
                    return null;
                nFile f = new nFile();
                f.bytes = b;
                f.extention = ext;
                return f;
            }
            catch (Exception)
            { return null; }
        }
        public static nFile GetFileFromDisk(String filepath)
        {
            try
            {
                if (!Tools.Strings.StrExt(filepath))
                    return GetFileFromDisk(true, null);
                if (!System.IO.File.Exists(filepath))
                    return null;
                String ext = nTools.GetFileExtention(filepath);
                if (!Tools.Strings.StrExt(ext))
                    return null;
                Byte[] b = System.IO.File.ReadAllBytes(filepath);
                if (b == null)
                    return null;
                nFile f = new nFile();
                f.bytes = b;
                f.extention = ext;
                return f;
            }
            catch (Exception)
            { return null; }
        }
        public static nFile GetFileFromDatabase(Byte[] b)
        {
            try
            {
                if (b == null)
                    return null;
                nFile f = new nFile();
                Int64 size = (Int64)b[0];
                if (size > 5)
                    return null;
                if (size <= 0)
                    return null;
                String ext = "";
                Int32 n = 1;
                for (Int64 i = 1; i <= size; i++)
                {
                    ext += NumberToLetter((Int64)b[i]);
                    n++;
                }
                Int32 len = b.Length - n;
                f.bytes = new Byte[len];
                Int32 l = 0;
                for (Int32 i = n; i <= b.Length - 1; i++)
                {
                    f.bytes[l] = b[i];
                    l++;
                }
                f.extention = ext;
                return f;
            }
            catch
            { return null; }
        }
        //Private Static Functions
        private static Byte[] AddByteExtention(Byte[] b, String ext)
        {
            try
            {
                Int64 x = 0;
                Int32 length = ext.Length;
                Byte[] e = new Byte[length + 1];
                e[x] = (Byte)length;
                x++;
                foreach (Char c in ext.ToCharArray())
                {
                    Int64 i = LetterToNumber(c.ToString());
                    e[x] = (Byte)i;
                    x++;
                }
                Byte[] by = new Byte[b.Length + e.Length];
                length=0;
                foreach (Byte bb in e)
                {
                    by[length] = bb;
                    length++;
                }
                foreach (Byte bb in b)
                {
                    by[length] = bb;
                    length++;
                }
                return by;
            }
            catch 
            { return b; }
        }
        private static String NumberToLetter(Int64 i)
        {
            switch (i)
            {
                case 1:
                    return "a";
                case 2:
                    return "b";
                case 3:
                    return "c";
                case 4:
                    return "d";
                case 5:
                    return "e";
                case 6:
                    return "f";
                case 7:
                    return "g";
                case 8:
                    return "h";
                case 9:
                    return "i";
                case 10:
                    return "j";
                case 11:
                    return "k";
                case 12:
                    return "l";
                case 13:
                    return "m";
                case 14:
                    return "n";
                case 15:
                    return "o";
                case 16:
                    return "p";
                case 17:
                    return "q";
                case 18:
                    return "r";
                case 19:
                    return "s";
                case 20:
                    return "t";
                case 21:
                    return "u";
                case 22:
                    return "v";
                case 23:
                    return "w";
                case 24:
                    return "x";
                case 25:
                    return "y";
                case 26:
                    return "z";
                default:
                    return "";
            }
        }
        private static Int64 LetterToNumber(String l)
        {
            switch (l.ToLower())
            {
                case "a":
                    return 1;
                case "b":
                    return 2;
                case "c":
                    return 3;
                case "d":
                    return 4;
                case "e":
                    return 5;
                case "f":
                    return 6;
                case "g":
                    return 7;
                case "h":
                    return 8;
                case "i":
                    return 9;
                case "j":
                    return 10;
                case "k":
                    return 11;
                case "l":
                    return 12;
                case "m":
                    return 13;
                case "n":
                    return 14;
                case "o":
                    return 15;
                case "p":
                    return 16;
                case "q":
                    return 17;
                case "r":
                    return 18;
                case "s":
                    return 19;
                case "t":
                    return 20;
                case "u":
                    return 21;
                case "v":
                    return 22;
                case "w":
                    return 23;
                case "x":
                    return 24;
                case "y":
                    return 25;
                case "z":
                    return 26;
                default:
                    return 1;
            }
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
                filename += "." + extention;
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
        public override Byte[] GetBytes()
        {
            return AddByteExtention(bytes, extention);
        }
        public override String GetFileSaveFilter()
        {
            return extention.ToUpper() + " Files (*." + extention.ToLower() + ")|*." + extention.ToLower();
        }
    }
}
