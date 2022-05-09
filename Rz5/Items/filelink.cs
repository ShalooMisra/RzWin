using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;

using NewMethod;
using Core;
using Tools.Database;

namespace Rz5
{
    public partial class filelink : filelink_auto
    {
        public Byte[] picturedata;

        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;
            switch (args.ActionName.ToLower())
            {
                case "importfile":
                    ImportFile(xrz);
                    break;
                case "exportfile":
                    ExportFile(xrz);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public void ImportFile(ContextRz context)
        {
            String strFile = context.Leader.ChooseAFile();
            if (!File.Exists(strFile))
            {
                context.TheLeader.Tell(strFile + " doesn't exist.");
                return;
            }

            ImportFile(context, strFile);
        }

        public void ImportFile(ContextRz context, String strFile)
        {
            nBlobHandle b = new nBlobHandle(context, "filelink", "picturedata", this.unique_id);
            b.SetFromFile(strFile);
            context.TheLeader.Comment("Done.");
        }

        public void ExportFile(ContextRz context)
        {
            context.Reorg();

            //String strFolder = nTools.ChooseAFolder(RzApp.xMainForm, "c:\\");
            //if (!Directory.Exists(strFolder))
            //    return;

            //nBlobHandle b = new nBlobHandle(xSys, "filelink", "picturedata", this.unique_id);

            //String strFile = Tools.Folder.ConditionFolderName(strFolder) + linkname + "." + filetype;
            //if( File.Exists(strFile) )
            //{
            //    context.TheLeader.Tell(strFile + " already exists.");
            //    return;
            //}

            //b.SaveAsFile(strFile);
            //nTools.ExploreFolder(strFolder);
        }

        //Public Functions
        public void SavePictureData(ContextRz context)
        {
            if (picturedata == null)
                throw new Exception("No picture data");

            if (picturedata.Length <= 0)
                throw new Exception("No picture data");

            if (!Tools.Strings.StrExt(TableName))
                TableName = "filelink";

            String SQL;
            SQL = "update " + TableName + " set picturedata = @picture where unique_id = '" + unique_id + "'";
            Int32 affect;

            SqlConnection xConnect = new SqlConnection(context.TheData.TheConnection.ConnectionString.Replace(Tools.Strings.Split(context.TheData.TheConnection.ConnectionString, ";")[0] + ";", ""));
            SqlCommand oCmd = xConnect.CreateCommand();
            oCmd.CommandTimeout = DataConnectionSqlServer.TimeOut;
            oCmd.CommandText = SQL;
            SqlParameter param = new SqlParameter("@picture", SqlDbType.VarBinary);
            param.Value = picturedata;
            oCmd.Parameters.Add(param);
            xConnect.Open();
            affect = oCmd.ExecuteNonQuery();
            oCmd.Dispose();
            oCmd = null;
            xConnect.Close();
            xConnect = null;
            if (affect != 1 )
                throw new Exception("Update did not affect 1 record");
        }
        public Boolean LoadPictureData(ContextRz context)
        {
            if (!Tools.Strings.StrExt(TableName))
                TableName = "filelink";
            String SQL = "select picturedata from " + TableName + " where unique_id = '" + unique_id + "'";
            try
            {
                SqlConnection xConnect = new SqlConnection(context.TheData.TheConnection.ConnectionString.Replace(Tools.Strings.Split(context.TheData.TheConnection.ConnectionString, ";")[0] + ";", ""));
                SqlCommand oCmd = xConnect.CreateCommand();
                oCmd.CommandTimeout = DataConnectionSqlServer.TimeOut;
                oCmd.CommandText = SQL;
                xConnect.Open();
                picturedata = (byte[])oCmd.ExecuteScalar();
                oCmd.Dispose();
                oCmd = null;
                xConnect.Close();
                xConnect = null;
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public String SaveDataAsFile()
        {
            return SaveDataAsFile("");
        }
        public String SaveDataAsFile(String file)
        {
            return SaveDataAsFile(file, false);
        }
        public String SaveDataAsFile(String file, Boolean bNoDelete)
        {
            return SaveDataAsFile(file, bNoDelete, "");
        }
        public String SaveDataAsFile(String file, Boolean bNoDelete, String folderpath)
        {
            try
            {
                String ext = "";
                if (picturedata == null)
                    return "";
                String filename = Tools.Strings.GetNewID();
                if (Tools.Strings.StrExt(file))
                    filename = file;
                String foldername = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "Junk\\";
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
                    catch (Exception) { }
                }
                nTools.MakeFolderExist(foldername);
                if (!Tools.Strings.StrExt(filetype))
                    ext = "jpg";
                else
                    ext = filetype;
                filename = foldername + filename + "." + ext;
                FileStream fs = File.Create(filename);
                if (!File.Exists(filename))
                    return "";
                if (fs == null)
                    return "";
                fs.Write(picturedata, 0, picturedata.Length);
                fs.Close();
                return filename;
            }
            catch (Exception ee)
            { return ""; }
        }
        public Boolean IsPictureFile(String filepath)
        {
            try
            {
                switch (GetFileExtention(filepath))
                {
                    case "jpg":
                    case "jpeg":
                    case "bmp":
                    case "wmf":
                    case "png":
                    case "gif":
                    case "tif":
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception)
            { return false; }
        }
        public Image GetPictureImage()
        {
            try
            {
                if (picturedata == null)
                    return null;
                if (picturedata.Length <= 0)
                    return null;
                System.IO.MemoryStream xStream = new System.IO.MemoryStream(picturedata);
                return Image.FromStream(xStream);
            }
            catch (Exception)
            { return null; }
        }
        public Boolean ShellData()
        {
            try
            {
                String filepath = SaveDataAsFile();
                if (!Tools.Strings.StrExt(filepath))
                    return false;
                if (!System.IO.File.Exists(filepath))
                    return false;
                return Tools.Files.OpenFileInDefaultViewer(filepath);
            }
            catch (Exception ee)
            { return false; }
        }
        public Boolean SetPictureDataByFile(String filepath)
        {
            try
            {
                if (!System.IO.File.Exists(filepath))
                    return false;
                byte[] image = System.IO.File.ReadAllBytes(filepath);
                if (image == null)
                    return false;
                if (image.Length <= 0)
                    return false;
                picturedata = GetJPGFromImageData(image);
                if (picturedata == null)
                    return false;
                if (picturedata.Length <= 0)
                    return false;
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public Boolean SetDocDataByFile(String filepath)
        {
            try
            {
                if (!System.IO.File.Exists(filepath))
                    return false;
                picturedata = System.IO.File.ReadAllBytes(filepath);
                if (picturedata == null)
                    return false;
                if (picturedata.Length <= 0)
                    return false;
                filetype = GetFileExtention(filepath);
                return true;
            }
            catch (Exception)
            { return false; }
        }
        //Private Functions
        private byte[] GetJPGFromImageData(byte[] image)
        {
            try
            {
                byte[] hold;
                System.IO.MemoryStream xStream = new System.IO.MemoryStream(image);
                Image xImage = Image.FromStream(xStream);
                String file = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppParentPath()) + @"Graphics\" + Tools.Strings.GetNewID() + ".jpg";
                xImage.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
                hold = System.IO.File.ReadAllBytes(file);
                System.IO.File.Delete(file);
                if (hold == null)
                    return image;
                if (hold.Length <= 0)
                    return image;
                return hold;
            }
            catch (Exception)
            { return image; }
        }
        private FileInfo GetFileInfo(String filepath)
        {
            return new FileInfo(filepath);
        }
        private String GetFileExtention(String filepath)
        {
            return GetFileInfo(filepath).Extension.Replace(".", "").ToLower(); 
        }
    }
}
