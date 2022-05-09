using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using NewMethod;
using Core;
using Tools.Database;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
namespace Rz5
{
    public partial class partpicture : partpicture_auto, IPartObject
    {
        public Byte[] picturedata;

        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower().Trim())
            {
                case "view":
                    OpenFile((ContextRz)args.TheContext);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override void Inserting(Context x)
        {
            PartObject.ParsePartNumber(this);
            grid_color = GridColorCalc(x);
            base.Inserting(x);
        }

        public override void Updating(Context x)
        {
            PartObject.ParsePartNumber(this);
            grid_color = GridColorCalc(x);
            base.Updating(x);
        }
        //Public Functions
        public ordhed GetOrderObject()
        {
            //return ordhed.GetByID(xSys, GetOrderDetailObject().base_ordhed_uid);
            return null;
        }
        public orddet GetOrderDetailObject(ContextRz x)
        {
            return orddet.GetById(x, the_orddet_uid);
        }
        public company GetCompanyObject(ContextRz x)
        {
            return company.GetById(x, the_company_uid);
        }
        public companycontact GetCompanyContactObject(ContextRz x)
        {
            return companycontact.GetById(x, the_companycontact_uid);
        }
        public partrecord GetPartRecordObject(ContextRz x)
        {
            return partrecord.GetById(x, the_partrecord_uid);
        }
        public qualitycontrol GetQualityControlObject(ContextRz x)
        {
            return qualitycontrol.GetById(x, the_qualitycontrol_uid);
        }
        public String alternatepart
        {
            get { return ""; }
            set { }
        }
        public String alternatepartstripped
        {
            get { return ""; }
            set { }
        }
        public void SizeCheck(ContextRz context)
        {
            if (picturedata == null)
                return;

            if (image_height == 0 || image_width == 0)
            {
                Image i = GetPictureImage(context);
                if (i != null)
                {
                    image_height = i.Height;
                    image_width = i.Width;
                    UpdateTo(context, context.Logic.PictureData);
                }
            }
        }
        //public Boolean LoadPictureData(ContextRz context)
        //{
        //    //string SQL = "select picturedata from partpicture where unique_id = '" + unique_id + "'";
        //    string SQL = "select picturedata from partpicture where unique_id = '" + unique_id + "' AND picturedata IS NOT NULL";
        //    //KT - Here is the UNION ALL query to let me query all my picture databases
        //    //String SQL = "SELECT picturedata from Rz3_Pictures.dbo.partpicture WHERE unique_id ='"+unique_id+"' UNION ALL SELECT picturedata from Rz3_Pictures2.dbo.partpicture WHERE unique_id = '"+unique_id+"'";

        //    try
        //    {
        //        //string MySqlConnStr = context.Logic.PictureData.ConnectionString.Replace(Tools.Strings.Split(context.Logic.PictureData.ConnectionString, ";")[0] + ";", "");
        //        //string MySqlConnStrRep = MySqlConnStr.Replace("Port=3306;Option=131072;", "");
        //        string MySqlConnStr = context.Logic.PictureData.ConnectionString;

        //        MySqlConnection xConnect = new MySqlConnection(MySqlConnStr);
        //        MySqlCommand oCmd = xConnect.CreateCommand();


        //        oCmd.CommandTimeout = DataConnectionSqlServer.TimeOut;
        //        oCmd.CommandText = SQL;
        //        xConnect.Open();
        //        picturedata = (byte[])oCmd.ExecuteScalar();
        //        oCmd.Dispose();
        //        oCmd = null;
        //        xConnect.Close();
        //        xConnect = null;
        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        context.Leader.Tell(ex.Message);
        //        return false;
        //    }
        //}


        string username = "sm_operations";
        string domain = "sensiblemicro.local";
        //string password = @"ATkab;?+Mc/zro#Gilb^";
        string password = @"ATkab;?+Mc/zro#Gilb^";

        //ad_impersonation.LogonType.Network = fail
        //ad_impersonation.LogonType.NewCredential = fail
        //ad_impersonation.LogonType.Batch = fail
        //ad_impersonation.LogonType.NetworkCleartext = fail
        //ad_impersonation.LogonType.Batch = fail
        //ad_impersonation.LogonType.Batch = 
        //ad_impersonation.LogonType.Batch = 
        //ad_impersonation.LogonType logonType = ad_impersonation.LogonType.NewCredentials;





        public Boolean LoadPictureData(ContextRz x)
        {

            try
            {
                string UNC_File_path = this.file_path;
                if (string.IsNullOrEmpty(UNC_File_path))
                    throw new Exception("File path empty.  Cannot Load Picturedata.");
                bool success = true;


                picturedata = SensibleDAL.ftp.FTPGet(UNC_File_path);
                if (picturedata == null || picturedata.Length <= 0)
                {

                    x.Error("Unable to load picture data from attachment source.");
                    return  false;
                }

                //if (!File.Exists(UNC_File_path))
                if(picturedata == null)
                {
                    //throw new Exception("No file found at filepath: " + filepath);
                    if (x.Leader.AskYesNo("No file was found at filepath: " + UNC_File_path + " it may have been deleted and needs to be re-uploaded.  Do you want to remove this erroneous link first?  *hint* you probably do :)"))
                    {
                        
                        //xPartPic.picturedata = null;
                        this.DeletePicture(x);
                        return false;
                    }
                    else

                        throw new Exception("No file found at filepath: " + UNC_File_path);
                    //return false;
                }


              


                GC.Collect();
                GC.WaitForPendingFinalizers();
                return success;

            }
            catch (Exception ex)
            {
                x.Leader.Tell(ex.Message);
                return false;
            }
        }

        public Boolean SavePictureData(ContextRz context)
        {
            //#1
            string st = context.Logic.PictureData.GetType().ToString().ToLower();

            if (st == "tools.database.dataconnectionsqlmy")
            {


                string Conn = context.Logic.PictureData.ConnectionStringGet(true);
                //context.Logic.PictureData.ConnectionStringGet(true);
                //string ConnRep = Conn.Replace("Option=131072;", "");
                MySqlConnection xConnect = new MySqlConnection(Conn);
                return SavePictureDataMy(context, xConnect);

            }
            else
            {
                SqlConnection xConnect = new SqlConnection(context.Logic.PictureData.ConnectionString.Replace(Tools.Strings.Split(context.Logic.PictureData.ConnectionString, ";")[0] + ";", ""));
                return SavePictureDataSql(context, xConnect);
            }
        }
        public bool SavePictureDataSql(ContextRz context, SqlConnection xConnect)
        {
            //#2
            if (picturedata == null)
                return false;
            if (picturedata.Length <= 0)
                return false;

            String SQL;
            //SQL = "update partpicture set picturedata = @picture where unique_id = '" + unique_id + "'";
            SQL = "update partpicture set file_path = @file_path where unique_id = '" + unique_id + "'";
            Int32 affect;
            try
            {
                SqlCommand oCmd = xConnect.CreateCommand();
                oCmd.CommandTimeout = DataConnectionSqlServer.TimeOut;
                oCmd.CommandText = SQL;
                SqlParameter param = new SqlParameter("@file_path", SqlDbType.NVarChar);
                param.Value = file_path;
                oCmd.Parameters.Add(param);
                xConnect.Open();
                affect = oCmd.ExecuteNonQuery();
                oCmd.Dispose();
                oCmd = null;
                xConnect.Close();
                xConnect = null;
                //KT - Removing Thumbnail Save until I can work that out.
                if (affect > 0)
                {

                    if (IsPictureFile)
                        ThumbnailDataSave(context);
                    else
                    {

                    }
                    return true;
                }
                else
                    return false;
                //return true;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("Error saving attachment info: " + ex.Message);
                return false;
            }
        }
        //KT 4-19-2016
        public bool SavePictureDataMy(ContextRz context, MySqlConnection xConnect)
        {
            //#3
            //if (picturedata == null)
            //    return false;
            //if (picturedata.Length <= 0)
            //    return false;
            if (string.IsNullOrEmpty(file_path))
                return false;


            String SQL;
            //SQL = "update partpicture set picturedata = @picture where unique_id = '" + unique_id + "'";
            SQL = "update partpicture set file_path = @file_path where unique_id = '" + unique_id + "'";
            MySqlCommand oCmd = null;
            Int32 affect;
            try
            {
                oCmd = xConnect.CreateCommand();
                oCmd.CommandTimeout = DataConnectionSqlServer.TimeOut;
                oCmd.CommandText = SQL;
                //MySqlParameter param = new MySqlParameter("@picture", MySqlDbType.Blob);
                MySqlParameter param = new MySqlParameter("@file_path", MySqlDbType.String);
                param.Value = file_path;
                oCmd.Parameters.Add(param);
                xConnect.Open();
                affect = oCmd.ExecuteNonQuery();
                oCmd.Dispose();
                oCmd = null;
                xConnect.Close();
                xConnect = null;
                //KT - Removing Thumbnail Save until I can work that out.
                if (affect > 0)
                {

                    if (IsPictureFile)
                        ThumbnailDataSaveMy(context);
                    else
                    {

                    }
                    return true;
                }
                else
                    return false;
                //return true;
            }
            catch (Exception ex)
            {
                oCmd.Dispose();
                oCmd = null;
                xConnect.Close();
                xConnect = null;
                context.TheLeader.Error("Error saving attachment info: " + ex.Message);
                return false;
            }
        }
        public Boolean ThumbnailDataSave(ContextRz context)
        {
            Image full = GetPictureImage(context);
            if (full == null)
                return false;

            Image thumb = nTools.GetThumbnail(full, 32, 32);
            if (thumb == null)
                return false;

            MemoryStream ms = new MemoryStream();
            thumb.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Byte[] thumbnaildata = ms.ToArray();

            try
            {
                ms.Dispose();
                ms = null;
            }
            catch { }

            String SQL;
            SQL = "update partpicture set thumbnail_thirty_two_square = @thumbNail where unique_id = '" + unique_id + "'";
            Int32 affect;
            try
            {
                SqlConnection xConnect = new SqlConnection(context.Logic.PictureData.ConnectionString.Replace(Tools.Strings.Split(context.Logic.PictureData.ConnectionString, ";")[0] + ";", ""));
                SqlCommand oCmd = xConnect.CreateCommand();
                oCmd.CommandTimeout = DataConnectionSqlServer.TimeOut;
                oCmd.CommandText = SQL;
                SqlParameter param = new SqlParameter("@thumbNail", SqlDbType.VarBinary);
                param.Value = thumbnaildata;
                oCmd.Parameters.Add(param);
                xConnect.Open();
                affect = oCmd.ExecuteNonQuery();
                oCmd.Dispose();
                oCmd = null;
                xConnect.Close();
                xConnect = null;
                if (affect > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("Error saving thumbnail info: " + ex.Message);
                return false;
            }
        }

        public Boolean ThumbnailDataSaveMy(ContextRz context)
        {
            Image full = GetPictureImage(context);
            if (full == null)
                return false;

            Image thumb = nTools.GetThumbnail(full, 32, 32);
            if (thumb == null)
                return false;

            MemoryStream ms = new MemoryStream();
            thumb.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Byte[] thumbnaildata = ms.ToArray();

            try
            {
                ms.Dispose();
                ms = null;
            }
            catch { }

            String SQL;
            SQL = "update partpicture set thumbnail_thirty_two_square = @thumbNail where unique_id = '" + unique_id + "'";
            Int32 affect;
            try
            {
                string Conn = context.Logic.PictureData.ConnectionStringGet(true);
                MySqlConnection xConnect = new MySqlConnection(Conn);
                MySqlCommand oCmd = xConnect.CreateCommand();
                oCmd.CommandTimeout = DataConnectionSqlServer.TimeOut;
                oCmd.CommandText = SQL;
                MySqlParameter param = new MySqlParameter("@thumbNail", MySqlDbType.Blob);
                param.Value = thumbnaildata;
                oCmd.Parameters.Add(param);
                xConnect.Open();
                affect = oCmd.ExecuteNonQuery();
                oCmd.Dispose();
                oCmd = null;
                xConnect.Close();
                xConnect = null;
                if (affect > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("Error saving thumbnail info: " + ex.Message);
                return false;
            }
        }
        public Image GetPictureImageFromPath(ContextRz context, int width, int height)
        {
            ExtensionCheckUpdate(context);
            Image i = nTools.GetImage(file_path, width, height);

            if (i == null)
                return i;

            try
            {
                //scale it
                if (i.Height > height)
                    i = Tools.Picture.GetThumbnailScaleHeight(i, height);

                if (i.Width > width)
                    i = Tools.Picture.GetThumbnailScaleWidth(i, width);

                Image ret = new Bitmap(width, height);

                Graphics g = Graphics.FromImage(ret);
                g.Clear(Color.White);
                g.DrawImage(i, new Point((width / 2) - (i.Width / 2), (height / 2) - (i.Height / 2)));

                try
                {
                    g.Dispose();
                    g = null;
                }
                catch { }

                return ret;
            }
            catch { return i; };
        }
        public Image GetPictureImage(ContextRz context, int width, int height)
        {
            Image i = GetPictureImage(context);
            if (i == null)
                return i;

            try
            {
                //scale it
                if (i.Height > height)
                    i = Tools.Picture.GetThumbnailScaleHeight(i, height);

                if (i.Width > width)
                    i = Tools.Picture.GetThumbnailScaleWidth(i, width);

                Image ret = new Bitmap(width, height);

                Graphics g = Graphics.FromImage(ret);
                g.Clear(Color.White);
                g.DrawImage(i, new Point((width / 2) - (i.Width / 2), (height / 2) - (i.Height / 2)));

                try
                {
                    g.Dispose();
                    g = null;
                }
                catch { }

                return ret;
            }
            catch { return i; };
        }
        public Image GetPictureImage(ContextRz context)
        {
            try
            {

                ExtensionCheckUpdate(context);

                if (IsPictureFile)
                {
                    //if (picturedata == null)
                    //    return null;
                    //if (picturedata.Length <= 0)
                    //    return null;
                    if (string.IsNullOrEmpty(file_path))
                        return null;
                    if (!File.Exists(file_path))
                        return null;
                    //System.IO.MemoryStream xStream = new System.IO.MemoryStream(picturedata);
                    return Image.FromFile(file_path);
                }
                else
                {
                    return nTools.GetImage(this.filename + this.filetype, 100, 100);
                }
            }
            catch (Exception)
            { return null; }
        }

        //public Image GetPictureImageFromPath(ContextRz context)
        //{
        //    try
        //    {

        //        ExtensionCheckUpdate(context);
        //        return nTools.GetImage(file_path, 100, 100);
        //        //if (IsPictureFile)
        //        //{

        //        //    if (string.IsNullOrEmpty(file_path))
        //        //        return null;
        //        //    if (!File.Exists(file_path))
        //        //        throw new Exception("File not found at path location.");
        //        //    //System.IO.MemoryStream xStream = new System.IO.MemoryStream(picturedata);
        //        //    return Image.FromFile(file_path);
        //        //}
        //        //else
        //        //{
        //        //    return nTools.GetImage(this.filename + this.filetype, 100, 100);
        //        //}
        //    }
        //    catch (Exception)
        //    { return null; }
        //}
        public bool IsPictureFile
        {
            get
            {
                return IsPictureFileExtension(filetype);
            }
        }
        public static Boolean IsPictureFileName(String filepath)
        {
            return IsPictureFileExtension(GetFileExtention(filepath));
        }
        public static bool IsPictureFileExtension(String ext)
        {
            try
            {
                switch (ext.Replace(".", "").ToLower())
                {
                    case "jpg":
                    case "jpeg":
                    case "bmp":
                    case "wmf":
                    case "png":
                    case "gif":
                    case "tif":
                    case "tiff":
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception)
            { return false; }
        }
        public bool IsPDF
        {
            get
            {
                return this.filename.EndsWith("-pdf");
            }
        }
        public bool IsWord
        {
            get
            {
                return this.filename.EndsWith("-doc");
            }
        }
        //public void SaveAndOpen(ContextRz context)
        //{
        //    try
        //    {
        //        if (picturedata == null)
        //            LoadPictureData(context);

        //        if (picturedata == null)
        //            return;

        //        String strFile = Tools.Folder.ConditionFolderName(System.Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)) + "RzTemp" + this.unique_id;

        //        ExtensionCheckUpdate(context);

        //        strFile += this.filetype;

        //        if (File.Exists(strFile))
        //            File.Delete(strFile);

        //        File.WriteAllBytes(strFile, picturedata);

        //        Tools.FileSystem.Shell(strFile);
        //    }
        //    catch { }

        //    //this didn't seem to work
        //    //Tools.Files.OpenFileInDefaultViewer(strFile);
        //}

        public void OpenFile(ContextRz context)
        {
            try
            {
                if (string.IsNullOrEmpty(file_path))
                    return;

                Tools.Files.OpenFileInDefaultViewer(file_path);
            }
            catch { }

            //this didn't seem to work
            //Tools.Files.OpenFileInDefaultViewer(strFile);
        }
        public void ExtensionCheckUpdate(ContextRz context)
        {
            if (!Tools.Strings.StrExt(filetype))
            {
                if (IsPDF)
                {
                    filename = filename.Replace("-pdf", "");
                    filetype = ".pdf";
                }
                else if (IsWord)
                {
                    filename = filename.Replace("-doc", "");
                    filetype = ".doc";
                }
                else
                {
                    filetype = ".jpg";
                }

                //can't be IUpdate; it isn't always saved here
                //IUpdate();

                //can't be save, because it may not be ready to be saved
                //and before, it wasn't saving to the right data
                //ISave();

                if (Tools.Strings.StrExt(unique_id))
                    UpdateTo(context, context.Logic.PictureData);
            }
        }
        public Image GetImage(ContextRz context, int width, int height)
        {
            LoadPictureData(context);
            Image i = GetPictureImage(context);
            return nTools.GetThumbnail(i, width, height);
        }
        public Image Thumbnail32SquareMakeExist(ContextRz context)
        {
            Image i = Thumbnail32SquareImageGet(context);
            if (i != null)
                return i;

            return GetImage(context, 32, 32);
        }
        public Image Thumbnail32SquareImageGet(ContextRz context)
        {
            String SQL = "select thumbnail_thirty_two_square from partpicture where unique_id = '" + unique_id + "'";
            //KT - Here is the UNION ALL query to let me query all my picture databases
            //String SQL = "SELECT thumbnail_thirty_two_square from Rz3_Pictures.dbo.partpicture WHERE unique_id ='" + unique_id + "'2b8b6c6ee71c4c2fa6e9c19904024d0c' UNION ALL SELECT picturedata from Rz3_Pictures2.dbo.partpicture WHERE unique_id = '" + unique_id + "'";
            try
            {
                SqlConnection xConnect = new SqlConnection(context.Logic.PictureData.ConnectionString.Replace(Tools.Strings.Split(context.Logic.PictureData.ConnectionString, ";")[0] + ";", ""));
                SqlCommand oCmd = xConnect.CreateCommand();
                oCmd.CommandTimeout = DataConnectionSqlServer.TimeOut;
                oCmd.CommandText = SQL;
                xConnect.Open();
                byte[] thumbnaildata = (byte[])oCmd.ExecuteScalar();
                oCmd.Dispose();
                oCmd = null;
                xConnect.Close();
                xConnect = null;

                if (thumbnaildata == null)
                    return null;

                if (thumbnaildata.Length == 0)
                    return null;

                System.IO.MemoryStream xStream = new System.IO.MemoryStream(thumbnaildata);
                Image ret = Image.FromStream(xStream);

                try
                {
                    xStream.Dispose();
                }
                catch { }

                return ret;
            }
            catch (Exception)
            { return null; }
        }
        public Boolean ShellData(ContextRz context)
        {
            try
            {
                String filepath = SaveDataAsFile(context);
                if (!Tools.Strings.StrExt(filepath))
                    return false;
                if (!System.IO.File.Exists(filepath))
                    return false;
                return Tools.Files.OpenFileInDefaultViewer(filepath);
            }
            catch (Exception ee)
            { return false; }
        }
        public String SaveDataToTempFile(ContextRz context)
        {
            String folder = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + @"RzTempPictures\";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            String f = Tools.Strings.FilterTrash(ToString());
            if (!Tools.Strings.StrExt(f))
                f = "RzPicture" + unique_id;

            String file = folder + f + ".jpg";


            try
            {
                if (File.Exists(file))
                    File.Delete(file);
            }
            catch { }

            SaveDataAsFile(context, file);
            return file;
        }
        public String SaveDataAsFile(ContextRz context)
        {
            return SaveDataAsFile(context, "");
        }
        public String SaveDataAsFile(ContextRz context, String file)
        {
            return SaveDataAsFile(context, file, false);
        }
        public String SaveDataAsFile(ContextRz context, String file, Boolean bNoDelete)
        {
            try
            {
                if (picturedata == null)
                    return "";

                if (!Tools.Strings.StrExt(file))
                {
                    context.Error("Please choose a file name");
                    return "";
                }

                if (File.Exists(file))
                {
                    if (!context.TheLeader.AreYouSure("overwrite the existing copy of " + file))
                        return "";
                }

                FileStream fs = File.Create(file);

                if (!File.Exists(file))
                    return "";
                if (fs == null)
                    return "";
                fs.Write(picturedata, 0, picturedata.Length);
                fs.Close();
                fs.Dispose();
                fs = null;
                return file;
            }
            catch
            { return ""; }
        }
        public void SaveDataAsJpg(ContextRz context, string file, int width, int height)
        {
            try
            {
                Image i = GetImage(context, width, height);
                i.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
                i.Dispose();
                i = null;
            }
            catch { }
        }
        //public Boolean SetPictureDataByFile(ContextRz context, String filepath)
        //{
        //    return SetPictureDataByFile(context, filepath);
        //}
        protected virtual bool RescaleImageRequired()
        {   //for phoenixwarehouse only (so far)
            return true;
        }
        public Boolean SetPictureDataByFile(ContextRz x, String filepath)
        {

            try
            {


                if (!System.IO.File.Exists(filepath))
                    return false;

                Image img = Image.FromFile(filepath);
                if (img == null)
                    return false;

                //so this assumes that if its set by image that its already reasonably scaled



                if (RescaleImageRequired() && img.Size.Width > 810)
                {
                    img = Tools.Picture.GetThumbnailScaleWidth(img, 800);
                }

                filetype = "." + GetFileExtention(filepath).ToLower();
                //Name the File 'pn_XXX_file_XXX'
                filename = BuildAttachmentFileName(filepath);
                //Save the byte[] to Rz Attachment Path
                //string base_path = GetRzAttachmentPathFromDate(DateTime.Now);
                string unc_path = GetUNCPathFromDate(DateTime.Now);
                if (string.IsNullOrEmpty(unc_path))
                    return false;

                if (string.IsNullOrEmpty(filename))
                    return false;

                //Update File Name if it was iterated
                if (File.Exists(unc_path + filename))
                {
                    filename = IterateFullPathName(unc_path, filename);
                    //this.Update(x);
                }

                file_path = unc_path + filename;
                byte[] fileBytes = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));
                if (fileBytes.Length <= 0 || fileBytes == null)
                    throw new Exception("Failed to convert System.Drawing.Image to Byte[]");

                //Wite to local folder 
                //if (!SensibleDAL.BinaryLogic.SaveFilesWithFTP(filename, fileBytes))
                //if (!SensibleDAL.BinaryLogic.SaveFilesWithFTP(filename, fileBytes))
                //    throw new Exception("Failed to write to network path: " + file_path);
                //if (!SensibleDAL.ftp.AsynchronousFtpUpLoader.FTPUpload(filename, fileBytes))
                //    throw new Exception("Failed to write to network path: " + file_path);

                

                if (!SensibleDAL.ftp.FTPUpload(fileBytes, filename, unc_path))
                    throw new Exception("Error uploading Rz Attachment via FTP");


                image_height = img.Size.Height;
                image_width = img.Size.Width;
                return true;
            }


            catch (Exception ex)
            {
                x.Error(ex.Message);
                return false;
            }

        }

        private static string IterateFullPathName(string uncBasePAth, string originFileName)
        {
            int i = 1;
            string separator = "_";
            string baseFileName = Path.GetFileNameWithoutExtension(originFileName);
            string ext = Path.GetExtension(originFileName);
            string newFileName = baseFileName + separator + i + ext;
            while (File.Exists(uncBasePAth + newFileName))
            {
                i++;
                newFileName = baseFileName + separator + i + ext;
            }
            return newFileName;
        }


        public bool SetPictureDataByImage(ContextRz context, Image img, string filePath)
        {
            try
            {

                //We will convert the image to this Byte[] using MemoryStream
                byte[] imagebytes = File.ReadAllBytes(filePath);

                //Get the image format to support more than just JPG
                //ImageFormat imgFormat = Tools.Picture.GetImageFormat(filePath);

                if (imagebytes == null)
                    return false;
                if (imagebytes.Length <= 0)
                    return false;


                SetPictureDataByFile(context, filePath);



                image_height = img.Size.Height;
                image_width = img.Size.Width;


                return true;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("Error setting picture info: " + ex.Message);
                return false;
            }
        }
        private string BuildAttachmentFileName(string filepath)
        {
            string ret = "";
            if (Tools.Strings.StrExt(fullpartnumber))
            {
                if (!string.IsNullOrEmpty(filename))
                    ret += "_";
                ret += "pn_" + fullpartnumber + "_";
            }
            ret += "file_" + System.IO.Path.GetFileName(filepath);// + "."+filetype;
            ret = ReplaceIncompatibleFileSystemSymbols(ret);            
            return ret;
        }
        private static string ReplaceIncompatibleFileSystemSymbols(string ret)
        {
            //Get invalid characters from .NET
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            ret = r.Replace(ret, "_");
            ret = ret.Replace(" ", "_");
            ret = ret.Replace("#", "_");
            return ret;
        }

        protected static string GetUNCPathFromDate(DateTime? date)
        {
            string ret = "\\\\storage\\sm_storage\\rz_attachments\\";
            string year = "";
            string month = "";
            string day = "";
            year = date.Value.Year.ToString();
            month = date.Value.Month.ToString();
            day = date.Value.Day.ToString();
            ret += year + "\\" + month + "\\" + day + "\\";
            return ret;
        }

        //protected static string GetFTPPathFromDate(DateTime? date)
        //{
        //    string ret = "";
        //    string year = "";
        //    string month = "";
        //    string day = "";
        //    year = date.Value.Year.ToString();
        //    month = date.Value.Month.ToString();
        //    day = date.Value.Day.ToString();
        //    ret += year + "/" + month + "/" + day + "/";
        //    return ret;
        //}


        public Boolean SetDocDataByFile(ContextRz x, String filepath)
        {
           
            try
            {
               
                if (!System.IO.File.Exists(filepath))
                    return false;
                //KT Removing picturedata
                byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
                if (fileBytes == null)
                    return false;
                if (fileBytes.Length <= 0)
                    return false;
                //Get File Extension
                filetype = GetFileExtention(filepath);

                //Build attachment File Name
                filename = BuildAttachmentFileName(filepath);

                //Build base path
                //string base_path = GetRzAttachmentPathFromDate(DateTime.Now);
                string unc_path = GetUNCPathFromDate(DateTime.Now);
                //string base_path = "\\\\storage\\sm_storage\\rz_test\\";
                //Confirm valid base path
                if (string.IsNullOrEmpty(unc_path))
                    return false;

                //Create directory
                //Directory.CreateDirectory(unc_path);

                //Ensure file Name
                if (string.IsNullOrEmpty(filename))
                    return false;

                //Update File Name if it was iterated
                if (File.Exists(unc_path + filename))
                {
                    filename = IterateFullPathName(unc_path, filename);
                    //this.Update(x);
                }


                //Set the value for the save Path.
                file_path = unc_path + filename;

                ////Wite to local folder
                //if (!WriteToSMBFolder(file_path, fileBytes))
                //    throw new Exception("Failed to write to network path: " + file_path);
                ////File.WriteAllBytes(file_path, fileBytes);

                //if (!File.Exists(file_path))
                //    throw new Exception("Failed to save image to path: " + base_path);

                //Wire to FTP folder
                return SensibleDAL.ftp.FTPUpload(fileBytes, filename, unc_path);
            }

            catch (Exception ex)
            {

                x.Error(ex.Message);
                return false;

            }
        }

        //private bool WriteToSMBFolder(string file_path, byte[] fileBytes)
        //{
        //    try
        //    {

        //        using (ad_impersonation.Impersonation.LogonUser(domain, username, password, logonType))
        //        {

        //            using (MemoryStream ms = new MemoryStream(fileBytes))
        //            {
        //                using (FileStream fs = new FileStream(file_path, FileMode.Create, System.IO.FileAccess.Write))
        //                {
        //                    BinaryWriter writer = new BinaryWriter(fs);
        //                    writer.Write(fileBytes);
        //                    writer.Flush();

        //                }
        //                ms.Close();
        //                ms.Dispose();
        //            }

        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        NMWin.ContextDefault.Error(ex.Message);
        //        return false;
        //    }


        //    return true;
        //}

        //private UserCredentials GetNetworkCredentials()
        //{
        //    string username = @"sm_operations";
        //    string domain = @"sensiblemicro.local";
        //    //string password = @"ATkab;?+Mc/zro#Gilb^";
        //    string password = @"ATkab;?+Mc/zro#Gilb^";
        //    //LogonType logonType = LogonType.NewCredentials;
        //    return new UserCredentials(domain, username, password);
        //}

        public void DeletePicture(ContextRz x)
        {
            //Get the File path
            string file_path = this.file_path;
            //Delete the file via FTP
            //Need the GC stuff below to allow images to be released before deletion.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            SensibleDAL.ftp.FTPDelete(file_path);
            //Delete the database record.
            x.Logic.PictureData.Execute("delete from partpicture where unique_id = '" + this.unique_id + "'");
        }

        //Private Functions
        private byte[] GetJPGFromImageData(byte[] image)
        {
            try
            {
                byte[] hold;
                System.IO.MemoryStream xStream = new System.IO.MemoryStream(image);
                Image xImage = Image.FromStream(xStream);
                String file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "RzTemp_" + Tools.Strings.GetNewID() + ".jpg";
                xImage.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);

                this.image_height = xImage.Height;
                this.image_width = xImage.Width;

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


        private byte[] GetGenericImageFromImageData(byte[] image, ImageFormat imgFormat, string filePath)
        {
            try
            {


                byte[] hold;
                System.IO.MemoryStream xStream = new System.IO.MemoryStream(image);
                Image xImage = Image.FromStream(xStream);
                string ext = GetFileExtention(filePath);

                string path = Path.GetTempPath();
                string file = Tools.Folder.ConditionFolderName(path + "\\RzTemp_" + Tools.Strings.GetNewID() + "." + ext);

                xImage.Save(file, imgFormat);

                this.image_height = xImage.Height;
                this.image_width = xImage.Width;

                hold = File.ReadAllBytes(file);
                //Delete the file when done
                File.Delete(file);
                if (hold == null)
                    return image;
                if (hold.Length <= 0)
                    return image;
                return hold;
            }
            catch (Exception)
            { return image; }
        }

        //are these two necessary?
        private static FileInfo GetFileInfo(String filepath)
        {
            return new FileInfo(filepath);
        }
        private static String GetFileExtention(String filepath)
        {
            return GetFileInfo(filepath).Extension.Replace(".", "").ToLower();
        }
        public override string ToString()
        {
            return this.description;
        }
        //public override string GetOneLineDescription()
        //{
        //    String s = "";

        //    if (Tools.Strings.StrExt(fullpartnumber))
        //    {
        //        if (Tools.Strings.StrExt(s))
        //            s += " : ";

        //        s += this.fullpartnumber;
        //    }

        //    if (Tools.Strings.StrExt(description))
        //    {
        //        if (Tools.Strings.StrExt(s))
        //            s += " : ";

        //        s += this.description;
        //    }

        //    return s;
        //}

        public void DeleteFromData(DataConnectionSqlServer d)
        {
            d.Execute("delete from partpicture where unique_id = '" + unique_id + "'");
        }

        public void Print(ContextRz context)
        {
            String file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "RzTmpPrint_" + unique_id + this.filetype;
            if (File.Exists(file))
                File.Delete(file);

            this.LoadPictureData(context);
            this.SaveDataAsFile(context, file);
            if (File.Exists(file))
            {
                Process printJob = new Process();
                printJob.StartInfo.FileName = file;
                printJob.StartInfo.UseShellExecute = true;
                printJob.StartInfo.Verb = "print";
                printJob.Start();
                printJob.WaitForExit(5000);
            }
        }

        public static partpicture GetById(ContextRz context, String id, DataConnection data)
        {
            return (partpicture)DataSql.GetById(context, "partpicture", id, context.TheData, data, "");
        }
    }
}
