using System;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace NewMethod
{
    public partial class nBlob
    {
        //Public Variables
        public Byte[] bytes = new Byte[0];

        //Constructors
        public nBlob()
        {
            bytes = new Byte[0];
        }
        public nBlob(Byte[] b)
        {
            bytes = b;
        }
        //Public Virtual Functions
        public virtual String SaveAsFile(ContextNM context, String file, Boolean bNoDelete, String folderpath, Boolean bShowSaveAs)
        {
            return "";
        }
        public virtual Byte[] GetBytes()
        {
            return bytes;
        }
        public virtual String GetFileSaveFilter()
        {
            return "";
        }
        //Public Functions
        public String ShowSaveAs(ContextNM context)
        {
            return SaveAsFile(context, true);
        }
        public String SaveAsFile(ContextNM context)
        {
            return SaveAsFile(context, "");
        }
        public String SaveAsFile(ContextNM context, Boolean bShowSaveAs)
        {
            return SaveAsFile(context, "", false, "", bShowSaveAs);
        }
        public String SaveAsFile(ContextNM context, String file)
        {
            return SaveAsFile(context, file, false);
        }
        public String SaveAsFile(ContextNM context, String file, Boolean bNoDelete)
        {
            return SaveAsFile(context, nTools.GetFileNameNoExtention(file), bNoDelete, nTools.GetFolderName(file), false);
        }
        public String GetSaveFilePath(String file, Boolean bNoDelete, String folderpath, Boolean bSaveAs)
        {
            try
            {
                if (bytes == null)
                    return "";
                if (bSaveAs)
                    return GetSaveAsFilePath();
                String filename = Tools.Strings.GetNewID();
                if (Tools.Strings.StrExt(file))
                    filename = file;
                String foldername = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath() + "Junk\\");
                if (Tools.Strings.StrExt(folderpath))
                {
                    foldername = folderpath;
                    bNoDelete = true;
                }
                if (!Tools.Strings.StrExt(foldername))
                    return "";
                nTools.MakeFolderExist(foldername);
                if (!bNoDelete)
                {
                    try { Directory.Delete(foldername, true); }
                    catch { }
                }
                nTools.MakeFolderExist(foldername);
                return foldername + filename;
            }
            catch { return ""; }
        }
        public void ShellData(ContextNM context)
        {
            String filepath = SaveAsFile(context);
            if (!Tools.Strings.StrExt(filepath))
                throw new Exception("Blank file name");

            if (!System.IO.File.Exists(filepath))
                throw new Exception("File not created");

            context.TheLeader.FileShow(filepath);
        }
        //Private Functions
        private String GetSaveAsFilePath()
        {
            try
            {
                SaveFileDialog sFile = new SaveFileDialog();
                sFile.Filter = GetFileSaveFilter();
                sFile.ShowDialog();
                String folder = nTools.GetFolderName(sFile.FileName);
                String file = nTools.GetFileNameNoExtention(sFile.FileName);
                return Tools.Folder.ConditionFolderName(folder) + file;
            }
            catch { return ""; }
        }
    }
}
