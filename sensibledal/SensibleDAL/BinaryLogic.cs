using System;
using System.Collections.Generic;
using System.Linq;
using SensibleDAL.ef;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using SensibleDAL.dbml;
using SimpleImpersonation;
using System.Net;
using System.Threading;
using System.Web;

namespace SensibleDAL
{
    public class BinaryLogic
    {

        public static string SaveDataBaseImageToFolder(insp_images i, out string report)
        {
            report = "";
            DateTime? fileDate = GetFileDateFromInspection(i, out report);
            //IF no valid File Date, cannot derive structure, so don't save this file.
            if (fileDate == null)
            {
                report = "No Date could be derived for " + i.insp_type + " ID: " + i.insp_id + " no path could be derived.";
                return null;
            }

            //Use the fileDate to determine folder path
            string base_path = GetFilePathFromDate(i.insp_type, fileDate);
            //If something goes wrong, do not create the path / file
            if (string.IsNullOrEmpty(base_path))
            {
                report = "No base path could be derived for " + i.insp_type + " ID: " + i.insp_id + " no path could be derived.";
                return null;
            }

            //Create the directory
            Directory.CreateDirectory(base_path);
            //Generate the file Name
            string fileName = GenerateFileNameFromInspection(i);
            //If no good filename, skip
            if (string.IsNullOrEmpty(fileName))
            {
                report = "No file name could be derived for " + i.insp_type + " ID: " + i.insp_id + " no path could be derived.";
                return null;
            }

            //Combine base path with filename
            string file_path_web = base_path += fileName;
            //IF file doesn't already exist, create it.
            if (!File.Exists(file_path_web))
            {
                FileStream fs = new FileStream(file_path_web, FileMode.OpenOrCreate);
                fs.Write(i.img_blob, 0, i.img_blob.Length);
                fs.Close();
                report = "Success: FileName: " + file_path_web + " -  " + i.insp_type + " ID: " + i.insp_id;
            }
            //Commit the path databse
            //using (sm_binary_mysql_Entities smb = new sm_binary_mysql_Entities())
            //    smb.SaveChanges();
            return file_path_web;
        }


        protected DateTime? GetFileDateFromObject(object o, out string report)
        {
            report = "";
            if (o is insp_images)
            {
                insp_images i = (insp_images)o;
                GetFileDateFromInspection(i, out report);

            }
            if (o is partpicture)
            {
                partpicture p = (partpicture)o;
                return p.date_created;
            }

            return null;

        }
        protected static DateTime? GetFileDateFromInspection(insp_images i, out string report)
        {
            report = "";

            if (i.insp_type.ToUpper() == SM_Enums.InspectionType.gcat.ToString().ToUpper())
            {
                using (SensibleDAL.dbml.gcatDataContext gd = new SensibleDAL.dbml.gcatDataContext())
                {

                    var vr = gd.ValidationReports.Where(w => w.ValidationReportID == i.insp_id).SingleOrDefault();
                    if (vr == null)
                        report += "No GCAT report found for ID: " + i.insp_id;
                    else
                        return vr.ReportDate;

                }

            }
            else if (i.insp_type.ToUpper() == SM_Enums.InspectionType.idea.ToString().ToUpper())
            {

                using (sm_portalEntities pdc = new sm_portalEntities())
                {

                    var v = pdc.insp_head.Where(w => w.insp_id == i.insp_id).SingleOrDefault();
                    if (v == null)
                        report += "No IDEA report found for ID: " + i.insp_id;
                    else
                        return v.date_created;

                }


            }
            else if (i.insp_type.ToUpper() == SM_Enums.InspectionType.noncon.ToString().ToUpper())
            {
                using (sm_nonconEntities n = new sm_nonconEntities())
                {
                    var v = n.NonCon_Head.Where(w => w.NonConID == i.insp_id).SingleOrDefault();
                    if (v == null)
                        report += "No NonCon report found for ID: " + i.insp_id;
                    else
                        return v.dateSubmitted;

                }
            }

            return null;

        }



        public static string GenerateFileNameFromInspection(insp_images i)
        {
            if (i.insp_type.ToUpper() == SM_Enums.InspectionType.idea.ToString().ToUpper())
            {
                return BuildIDEAFileNameFromInspection(i);
            }
            else if (i.insp_type.ToUpper() == SM_Enums.InspectionType.gcat.ToString().ToUpper())
            {
                return BuildGCATFileNameFromInspection(i);
            }
            return null;
        }

        public string SaveImageFileToFolder(insp_images i, byte[] fileBytes, out string report)
        {
            report = "";
            string fileName = BuildInspectionileNameFromFile(i);
            string base_path = GetFilePathFromDate(i.insp_type, DateTime.Today);
            //Create the directory
            Directory.CreateDirectory(base_path);
            string file_path_web = base_path += fileName;
            if (!File.Exists(file_path_web))
            {
                FileStream fs = new FileStream(file_path_web, FileMode.OpenOrCreate);
                //fs.Write(i.img_blob, 0, i.img_blob.Length);
                fs.Write(fileBytes, 0, fileBytes.Length);
                fs.Close();
                report = "Success: FileName: " + file_path_web + " -  " + i.insp_type + " ID: " + i.insp_id;
                //return file_path_web;
            }
            return file_path_web;
        }





        private static string BuildInspectionileNameFromFile(insp_images i)
        {

            string ret = "";
            string img_type = i.img_type;
            if (img_type == null)
                img_type = "jpg";
            ret = i.insp_type.ToUpper() + "_" + i.insp_id + "_" + i.insp_section_id + "_" + i.img_name.ToUpper();
            ret = ReplaceIncompatibleFileSystemSymbols(ret);
            return ret;
        }


        private static string BuildIDEAFileNameFromInspection(insp_images i)
        {
            string ret = "";
            string img_type = i.img_type;
            if (img_type == null)
                img_type = "jpg";
            //Ensure no "." in the type
            img_type = img_type.Replace(".", "");
            using (sm_portalEntities pdc = new sm_portalEntities())
            {
                insp_head h = pdc.insp_head.Where(w => w.insp_id == i.insp_id).FirstOrDefault();
                if (h == null)
                    return null;
                string partNumber = h.fullpartnumber ?? "";

                if (h.is_deleted ?? false)
                    partNumber = "header deleted";
                //throw new Exception("No IDEA Inspection found for ID: " + i.insp_id);
                //return h.fullpartnumber.ToUpper()+"_ID_"+i.insp_id+"SECTION_"+i.insp_section_id;
                ret = "IDEA_" + h.insp_id + "_" + i.insp_section_id + "_" + partNumber.ToUpper() + "." + img_type;

            }

            ret = ReplaceIncompatibleFileSystemSymbols(ret);
            return ret;
        }

        //public static bool SaveFilesWithAdImpersonation(string source_filepath, string destination_basePath)
        //{
        //    try
        //    {
        //        string username = @"sm_operations";
        //        string domain = @"sensiblemicro.local";
        //        //string password = @"ATkab;?+Mc/zro#Gilb^";
        //        string password = @"ATkab;?+Mc/zro#Gilb^";
        //        ad_impersonation.LogonType logonType = ad_impersonation.LogonType.NewCredentials;




        //        using (ad_impersonation.Impersonation.LogonUser(domain, username, password, logonType))
        //        {
        //            // Code to execute as the impersonated user
        //            // do whatever you want as this user.

        //            //string dest_file_name = "ad_impersonated_image.jpg";
        //            //string dest_base_path = @"\\storage\sm_storage\rz_attachments\ad_impersonation\";

        //            //create Directory
        //            DirectoryInfo dest_folder = Directory.CreateDirectory(destination_basePath);

        //            string dest_file_name = "te";
        //            string dest_file_path = destination_basePath + dest_file_name;


        //            byte[] source_fileBytes = File.ReadAllBytes(source_filepath);
        //            if (source_fileBytes.Count() <= 0)
        //                throw new Exception("Source file not found.");


        //            using (MemoryStream ms = new MemoryStream(source_fileBytes))
        //            {
        //                using (FileStream file = new FileStream(dest_file_path, FileMode.Create, System.IO.FileAccess.Write))
        //                {
        //                    byte[] bytes = new byte[ms.Length];
        //                    ms.Read(bytes, 0, (int)ms.Length);
        //                    file.Write(bytes, 0, bytes.Length);
        //                    file.Close();
        //                    file.Dispose();

        //                }
        //                ms.Close();
        //                ms.Dispose();
        //            }
        //        }

        //        return true;


        //    }
        //    catch (ImpersonationException iex)
        //    {
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}


        ////public static bool SaveFilesWithFTP_Test(StreamWriter sw)
        ////{
        ////    try
        ////    {

        ////        NetworkCredential creds = ftp.GetFtpCredentials();
        ////        SystemLogic.Logs.LogFS(sw, "Starting FTP tests...");
        ////        string dest_file_name = "ad_impersonated_image.jpg";
        ////        string guid = Guid.NewGuid().ToString();
        ////        string dest_base_path = @"\\storage.sensiblemicro.local\sm_storage\rz_test\" + guid + "\\";
        ////        string dest_UNC_path = dest_base_path + dest_file_name;

        ////        //Get sample file, confirm valid
        ////        byte[] source_fileBytes = File.ReadAllBytes(@"\\storage\sm_storage\rz_attachments\rz_company_logo.jpg");
        ////        if (source_fileBytes.Count() <= 0)
        ////        {
        ////            throw new Exception("Source file not found.");
        ////        }
        ////        //Get the FTP URI Path
        ////        string ftpUriPath = "ftp://rzdist.sensiblemicro.local/" + guid + "/";
        ////        //Delete if Existing via UNC
        ////        if (File.Exists(dest_UNC_path))
        ////        {
        ////            FTPDeleteFile(ftpUriPath);
        ////        }

        ////        //Create the destination dirctory
        ////        FTPCreateDirectory(ftpUriPath);

        ////        //Create the file
        ////        string ftpFilePath = ftpUriPath + "/" + dest_file_name;
        ////        FTPWriteFile(source_fileBytes, ftpFilePath);

        ////        //Confirm file Exists
        ////        if (!File.Exists(dest_UNC_path))
        ////            return false;
        ////        return true;

        ////    }
        ////    catch (WebException e)
        ////    {
        ////        String status = ((FtpWebResponse)e.Response).StatusDescription;
        ////        SystemLogic.Logs.LogFS(sw, status);
        ////        return false;
        ////    }



        ////}


        ////private static void FTPWriteFile(byte[] source_fileBytes, string ftpUriPath)
        ////{
        ////    WebRequest fileRequest = WebRequest.Create(ftpUriPath);
        ////    fileRequest.Credentials = ftp.GetFtpCredentials();
        ////    fileRequest.Method = WebRequestMethods.Ftp.UploadFile;
        ////    fileRequest.ContentLength = source_fileBytes.Length;

        ////    //SystemLogic.Logs.LogFS(sw, "Writing File to  Directory ...");
        ////    using (Stream requestStream = fileRequest.GetRequestStream())
        ////    {
        ////        requestStream.Write(source_fileBytes, 0, source_fileBytes.Length);
        ////    }

        ////    using (FtpWebResponse response = (FtpWebResponse)fileRequest.GetResponse())
        ////    {
        ////        //SystemLogic.Logs.LogFS(sw, $"Upload File Complete, status {response.StatusDescription}");*/

        ////    }
        ////}

        ////public static void FTPDeleteFile(string UncPath)
        ////{


        ////}

        ////public static void FTPCreateDirectory(string ftpPath)
        ////{
        ////    // Get the object used to communicate with the server.             

        ////    WebRequest dirRequest = WebRequest.Create(ftpPath);

        ////    dirRequest.Credentials = ftp.GetFtpCredentials();
        ////    dirRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
        ////    using (var response = (FtpWebResponse)dirRequest.GetResponse())
        ////    {
        ////        //SystemLogic.Logs.LogFS(sw, "Creating Directory ...");
        ////        //SystemLogic.Logs.LogFS(sw, "Result: " + response.StatusCode + " " + response.StatusDescription);
        ////    }
        ////}

        //public static bool SaveTestFilesWithAdImpersonation(StreamWriter sw)
        //{
        //    try
        //    {
        //        string username = @"sm_operations";
        //        string domain = @"sensiblemicro.local";
        //        //string password = @"ATkab;?+Mc/zro#Gilb^";
        //        string password = @"ATkab;?+Mc/zro#Gilb^";
        //        ad_impersonation.LogonType logonType = ad_impersonation.LogonType.NewCredentials;




        //        using (ad_impersonation.Impersonation.LogonUser(domain, username, password, logonType))
        //        {
        //            // Code to execute as the impersonated user
        //            // do whatever you want as this user.
        //            SystemLogic.Logs.LogFS(sw, "Starting Impersonation tests...");
        //            string dest_file_name = "ad_impersonated_image.jpg";
        //            string guid = Guid.NewGuid().ToString();
        //            string dest_base_path = @"\\storage\sm_storage\rz_attachments\ad_impersonation\tests\" + guid + "\\";
        //            string dest_file_path = dest_base_path + dest_file_name;

        //            DirectoryInfo folder = Directory.CreateDirectory(dest_base_path);


        //            byte[] source_fileBytes = File.ReadAllBytes(@"\\storage\sm_storage\rz_attachments\rz_company_logo.jpg");
        //            if (source_fileBytes.Count() <= 0)
        //            {
        //                throw new Exception("Source file not found.");
        //            }


        //            if (File.Exists(dest_file_path))
        //            {
        //                //This will ensure the impersonation works for deleted too.
        //                SystemLogic.Logs.LogFS(sw, "Deleting existing file...");
        //                File.Delete(dest_file_path);
        //            }


        //            using (MemoryStream ms = new MemoryStream(source_fileBytes))
        //            {
        //                using (FileStream file = new FileStream(dest_file_path, FileMode.Create, System.IO.FileAccess.Write))
        //                {





        //                    SystemLogic.Logs.LogFS(sw, "Writing file with impersonation...");
        //                    byte[] bytes = new byte[ms.Length];
        //                    ms.Read(bytes, 0, (int)ms.Length);
        //                    file.Write(bytes, 0, bytes.Length);
        //                    file.Close();

        //                    file.Dispose();

        //                }
        //                ms.Close();
        //                ms.Dispose();
        //            }
        //        }

        //        SystemLogic.Logs.LogFS(sw, "Impersonation test successful!");
        //        return true;


        //    }
        //    catch (Exception ex)
        //    {
        //        SystemLogic.Logs.LogFS(sw, "Error: " + ex.Message);
        //        return false;
        //    }
        //}

        private static string BuildGCATFileNameFromInspection(insp_images i)
        {
            string ret = "";
            string img_type = i.img_type;
            if (img_type == null)
                img_type = "jpg";
            //Ensure no "." in the type
            img_type = img_type.Replace(".", "");
            using (gcatDataContext gdc = new gcatDataContext())
            {
                ValidationReport v = gdc.ValidationReports.Where(w => w.ValidationReportID == i.insp_id).FirstOrDefault();
                if (v == null)
                    return null;
                string partNumber = v.MPN ?? "";

                if (v.is_deleted)
                    partNumber = "gcat deleted";
                //throw new Exception("No IDEA Inspection found for ID: " + i.insp_id);
                //return h.fullpartnumber.ToUpper()+"_ID_"+i.insp_id+"SECTION_"+i.insp_section_id;
                ret = "GCAT_" + v.ValidationReportID + "_" + i.insp_section_id + "_" + partNumber.ToUpper() + "." + img_type;

            }

            ret = ReplaceIncompatibleFileSystemSymbols(ret);
            return ret;
        }


        private static string ReplaceIncompatibleFileSystemSymbols(string ret)
        {
            //Get invalid characters from .NET
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            ret = r.Replace(ret, "_");
            return ret;
        }


        public static string GetFilePathFromDate(string type, DateTime? date)
        {
            string ret = "\\\\storage\\sm_storage\\web\\images\\inspection\\" + type.ToUpper() + "\\";
            string year = "";
            string month = "";
            string day = "";
            year = date.Value.Year.ToString();
            month = date.Value.Month.ToString();
            day = date.Value.Day.ToString();
            ret += year + "\\" + month + "\\" + day + "\\";
            return ret;
        }


        public static void CreateMissingInspectionImages(StreamWriter sw, SM_Enums.InspectionType inspType)
        {
            SystemLogic.Logs.LogFS(sw, "Creating missing " + inspType.ToString() + " images ...");
            try
            {

                //string Report = "<strong>" + inspType.ToString().ToUpper() + " Results:</strong><br />";
                long totalImagesCreated = 0;
                long count = 0;
                int index = 0;
                int take = 100;

                using (sm_binaryEntities smb = new sm_binaryEntities())
                {
                    var query = smb.insp_images.Where(w => (w.img_path_web == null || w.img_path_web == "") && w.insp_type.ToUpper() == inspType.ToString().ToUpper() && w.insp_id > 0);//.ToList() closes the reader.
                    count = query.Count();
                }
                //List<insp_images> imgList = new List<insp_images>();
                List<insp_images> databaseImagesList = new List<insp_images>();

                while (index < count)
                {
                    string result = "";
                    CreateImagesFromDataBase(inspType, index, take, out result);
                    index += take;
                    SystemLogic.Logs.LogFS(sw, result);
                }


                SystemLogic.Logs.LogFS(sw, Environment.NewLine + "Summary: " + Environment.NewLine);
                SystemLogic.Logs.LogFS(sw, "Total Images Created: " + totalImagesCreated);

                //SystemLogic.Email.SendMail("images@sensiblemicro.com", "systems@sensiblemicro.com", "Image Creation Report", Report);
                SystemLogic.Logs.LogFS(sw, "Done!!");

            }

            catch (Exception ex)
            {
                //HandleError(sw, ex.Message);
            }

        }


        private static void CreateImagesFromDataBase(SM_Enums.InspectionType inspType, int index, int take, out string report)
        {
            //Loop through the images, if no imp_path_web, create the image and set it.
            string imageDumpResult = "";
            report = "";

            List<insp_images> imageList = new List<insp_images>();
            using (sm_binaryEntities smb = new sm_binaryEntities())
            {
                imageList = smb.insp_images.Where(w => (w.img_path_web == null || w.img_path_web == "") && w.insp_type.ToUpper() == inspType.ToString().ToUpper() && w.insp_id > 0).OrderBy(o => o.unique_id).Skip(index).Take(take).ToList();//.ToList() closes the reader.

                foreach (insp_images i in imageList)
                {

                    index++;
                    //If path already exists, continue through loop.
                    if (!string.IsNullOrEmpty(i.img_path_web))
                    {
                        //Note in report
                        imageDumpResult = "Path Exists, Skipping: " + i.insp_id + " Path: " + i.img_path_web;
                        report += imageDumpResult + "<br />";
                        SystemLogic.Logs.LogEvent(SM_Enums.LogType.Information, imageDumpResult, false);
                        continue;
                    }
                    string saveReport = "";
                    //Perform the Database conversion logic
                    i.img_path_web = SaveDataBaseImageToFolder(i, out saveReport) ?? "";// Don't want to save nulls.
                    report += saveReport;
                    if (string.IsNullOrEmpty(i.img_path_web))
                    {
                        report += "Unable to save image for " + i.insp_type + " ID: " + i.insp_id + " no path could be derived.";
                        continue;
                    }

                    if (!string.IsNullOrEmpty(i.img_path_web))
                    {
                        //Create result string
                        imageDumpResult = "File successfully created from DataBase: " + i.insp_id + " Path: " + i.img_path_web;
                        //Note in the Report
                        report += imageDumpResult + "<br />";
                        //Log success event
                        SystemLogic.Logs.LogEvent(SM_Enums.LogType.Information, imageDumpResult, false);

                    }
                    //Commit the database  
                    smb.SaveChanges();
                }
            }
        }





        public static bool SaveTestFilesWithSimpleImpersonation(StreamWriter sw)
        {
            try
            {
                string username = @"sm_operations";
                string domain = @"sensiblemicro.local";
                //string password = @"ATkab;?+Mc/zro#Gilb^";
                string password = @"ATkab;?+Mc/zro#Gilb^";
                SimpleImpersonation.LogonType logonType = SimpleImpersonation.LogonType.NewCredentials;
                var credentials = new UserCredentials(domain, username, password);
                SimpleImpersonation.Impersonation.RunAsUser(credentials, logonType, () =>
                {
                    // do whatever you want as this user.


                    SystemLogic.Logs.LogFS(sw, "Starting Impersonation tests...");
                    string file_path = @"\\storage\sm_storage\rz_test\impersonated_image.jpg";
                    byte[] fileBytes = File.ReadAllBytes(@"\\storage\sm_storage\rz_test\test_image.jpg");


                    if (File.Exists(file_path))
                    {
                        //This will ensure the impersonation works for deleted too.
                        SystemLogic.Logs.LogFS(sw, "Deleting existing file...");
                        File.Delete(file_path);
                    }


                    using (MemoryStream ms = new MemoryStream(fileBytes))
                    {
                        using (FileStream file = new FileStream(file_path, FileMode.Create, System.IO.FileAccess.Write))
                        {
                            SystemLogic.Logs.LogFS(sw, "Writing file with impersonation...");
                            byte[] bytes = new byte[ms.Length];
                            ms.Read(bytes, 0, (int)ms.Length);
                            file.Write(bytes, 0, bytes.Length);
                            file.Close();

                            file.Dispose();

                        }
                        ms.Close();
                        ms.Dispose();
                    }






                });



                SystemLogic.Logs.LogFS(sw, "Impersonation test successful!");
                return true;


            }
            catch (Exception ex)
            {
                SystemLogic.Logs.LogFS(sw, "Error: " + ex.Message);
                return false;
            }
        }

        public static void LookupPartPicture(StreamWriter sw)
        {
            using (rz_attachEntities rza = new rz_attachEntities())
            {

                partpicture p = rza.partpictures.First();
                if (p == null)
                    throw new Exception("Unable to retrieve data from partpicture");
                else
                    SystemLogic.Logs.LogFS(sw, "Success: " + p.unique_id);

            }
        }

        public static void CreateTestPartPicture(StreamWriter sw)
        {
            string TESTGUId = "TESTGUID";
            using (rz_attachEntities rza = new rz_attachEntities())
            {

                partpicture p = rza.partpictures.Where(w => w.unique_id == TESTGUId).FirstOrDefault();
                if (p == null)
                {
                    p = new partpicture();
                    p.unique_id = TESTGUId;
                    p.date_created = DateTime.Now;
                    rza.partpictures.Add(p);
                }


                p.date_modified = DateTime.Now;
                p.fullpartnumber = "TESTPARTNUMBER";
                p.filetype = "Test Type";
                p.file_path = "Test Path";
                rza.SaveChanges();
            }
        }


        public static void CreateTestInspectionImage(StreamWriter sw)
        {
            //int testID = 999999;
            //using (sm_binaryEntities smb = new sm_binaryEntities())
            //{

            //    insp_images i = smb.insp_images.Where(w => w.unique_id == testID).FirstOrDefault();
            //    if (i == null)
            //    {
            //        i = new insp_images();
            //        i.unique_id = testID;
            //        i.date_created = DateTime.Now;
            //        smb.insp_images.Add(i);
            //    }

            //    i.img_name = "Test Name";
            //    i.img_blob = new byte[0];
            //    i.img_description = "Test Desc";
            //    i.date_modified = DateTime.Now;
            //    i.insp_image_id = Guid.NewGuid().ToString();
            //    i.insp_section_id = "TESTSECTION";
            //    i.img_type = "TEST TYPE";

            //    smb.SaveChanges();
            //}
        }


        public static void ExportRzAttachments(StreamWriter sw)
        {

            string fileType = ".pdf";
            SystemLogic.Logs.LogFS(sw, "Starting Export Process.  File Type: '" + fileType + "'");
            int successCount = 0;
            int totalCount = 0;
            using (rz_attachEntities rzp = new rz_attachEntities())
            {
                rzp.Database.CommandTimeout = 600;
                totalCount = rzp.partpictures.Where(w => w.file_path == null && w.filetype.ToLower() == fileType.ToLower()).Count();

            }
            SystemLogic.Logs.LogFS(sw, "Attachments to process: " + totalCount);
            int index = 0;
            int batchSize = 1000;
            SystemLogic.Logs.LogFS(sw, "Batch size: " + batchSize);
            while (successCount < totalCount)
            {

                int batchSuccessCount = 0;
                // Do it in batches of 100, else Database Timeout.
                ExportAttachmentsFromDatabase(sw, index, batchSize, fileType, out batchSuccessCount);
                index += batchSize;
                successCount += batchSuccessCount;
                SystemLogic.Logs.LogFS(sw, Environment.NewLine + "Successfully processed " + successCount + " / " + totalCount + " attachments." + Environment.NewLine);

            }

            SystemLogic.Logs.LogFS(sw, Environment.NewLine + "Summary:" + Environment.NewLine);
            SystemLogic.Logs.LogFS(sw, "Total items Detected: " + totalCount + Environment.NewLine);
            SystemLogic.Logs.LogFS(sw, "Total items Created: " + successCount + Environment.NewLine);
            SystemLogic.Logs.LogFS(sw, "Done.");

            SystemLogic.Logs.LogFS(sw, "Success!  Total Rz Attachments Exported: " + successCount.ToString() + " " + DateTime.Now);


        }







        public static string SaveDataBaseAttachmentToFolder(StreamWriter sw, partpicture p)
        {
            string fileData = "  Part ID: " + p.unique_id + Environment.NewLine;

            DateTime? fileDate = GetFileDateFromObject(p);


            //IF no valid File Date, annot derive structure, so don't save this file.
            if (fileDate == null)
                throw new Exception("Error: File name could not be derived." + fileData + Environment.NewLine);

            //Use the fileDate to determine folder path
            string base_path = GetRzAttachmentPathFromDate(fileDate);
            //If something goes wrong, do not create the path / file
            if (string.IsNullOrEmpty(base_path))
                throw new Exception("Error: Base path could not be derived." + fileData + Environment.NewLine);

            //Create the directory
            //SystemLogic.Logs.LogFS(sw, "Creating base directory.");
            Directory.CreateDirectory(base_path);

            //Generate the file Name
            //SystemLogic.Logs.LogFS(sw, "Generating file name.");
            string fileName = BuildRzAttachmentFileName(p, base_path);

            //throw Exception, must have file name.
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("No file name could be derived." + fileData + Environment.NewLine);

            //Combine base path with filename
            //SystemLogic.Logs.LogFS(sw, "Concatenating full file path.");
            string file_path = base_path += fileName;

            //Create the file
            //SystemLogic.Logs.LogFS(sw, "Writing file to disk.");
            FileStream fs = new FileStream(file_path, FileMode.OpenOrCreate);
            fs.Write(p.picturedata, 0, p.picturedata.Length);
            fs.Close();
            //Confirm Successful Write
            if (!File.Exists(file_path))
                throw new Exception("File Creation unsuccessful");
            SystemLogic.Logs.LogFS(sw, "File written successfully. " + file_path + fileData);

            return file_path;
        }

        protected static DateTime? GetFileDateFromObject(object o)
        {

            if (o is partpicture)
            {
                partpicture p = (partpicture)o;
                return p.date_created;
            }

            return null;

        }




        protected static string GetRzAttachmentPathFromDate(DateTime? date)
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


        private static string BuildRzAttachmentFileName(partpicture p, string base_path)
        {
            if (string.IsNullOrEmpty(p.unique_id))
                return null;
            if (string.IsNullOrEmpty(p.filetype))
                return null;
            if (string.IsNullOrEmpty(p.fullpartnumber) && string.IsNullOrEmpty(p.filename))//If both fileName and partnumber empty don't save
                p.filename = "Not_set";//this can have a valid blob, and other identifiers, bu no no name / filename, so we'll set that here as "Not set" so it can proceed.
            //Upper Case
            string part = (p.fullpartnumber ?? "").Trim().ToUpper(); ;
            string file = (p.filename ?? "").Trim();
            //Lower Case for ext
            string filetype = p.filetype.Trim().ToLower();
            string ret = "";
            //Append Part if Exists
            if (!string.IsNullOrEmpty(part))
                ret += "pn_" + part;
            //Append file if exists
            if (!string.IsNullOrEmpty(file))
            {    //If already text, append a _ 
                if (!string.IsNullOrEmpty(ret))
                    ret += "_";
                ret += "file_" + file;
            }

            //Filter incompatible symbols       
            ret = ReplaceIncompatibleFileSystemSymbols(ret);
            //Append Extension
            ret += filetype.ToLower();
            //Set index for file name iteration
            int fileIndex = 1;
            string fullPath = base_path + ret;
            //While there is a collission, keep iterting file path until no collission
            while (File.Exists(fullPath))
            {   //Strip the Extension
                string fExt = Path.GetExtension(ret);
                //Remove the Extension
                ret = ret.Replace(fExt, "");
                //Infer Previous Index for full Replace
                int previousIndex = 0;
                if (fileIndex > 1)
                {
                    //Making it semi-distinct, idx, to occurences of Index elsewhere in the fileName don't get replaced
                    previousIndex = fileIndex - 1;
                    //Append the Index            
                    ret = ret.Replace("_idx" + previousIndex.ToString(), "_idx" + fileIndex.ToString());
                }
                else
                    ret = ret + "_idx" + fileIndex;
                //iterate index in case of another collission
                fileIndex++;

                //Re-add the Extension
                ret = ret + fExt;
                //Update current value of fullpath
                fullPath = base_path + ret;
            }

            return ret;
        }


        private static string GetTotalTimeMessage(DateTime startTime, DateTime endTime)
        {
            TimeSpan opTime = endTime - startTime;
            string totalMinutes = opTime.TotalMinutes.ToString();
            string totalSeconds = opTime.TotalSeconds.ToString();
            string timeMsg = "Start Time: " + startTime.ToShortTimeString() + "  End Time: " + endTime.ToShortTimeString() + "  Total Minutes: " + totalMinutes.ToString();
            return timeMsg;
        }



        private static void ExportAttachmentsFromDatabase(StreamWriter sw, int index, int batchSize, string fileType, out int successCount)
        {
            //Loop through the images, if no imp_path_web, create the image and set it.

            successCount = 0;
            List<partpicture> attachmentList = new List<partpicture>();
            using (rz_attachEntities rzp = new rz_attachEntities())
            {
                ///THis is a VERY long running query, set command timeout appropriately
                int dbTimeout = 1000;
                SystemLogic.Logs.LogFS(sw, "Setting Database Command Timeout to " + dbTimeout);
                rzp.Database.CommandTimeout = dbTimeout;

                DateTime queryStart = DateTime.Now;

                SystemLogic.Logs.LogFS(sw, "Getting un-sorted attachment list for type: '" + fileType + "' ...");
                attachmentList = rzp.partpictures.Where(w => w.file_path == null && w.filetype.ToLower() == fileType.ToLower()).Take(batchSize).ToList();
                SystemLogic.Logs.LogFS(sw, "Identified " + attachmentList.Count + " attachment matches...");
                if (attachmentList.Count <= 0)
                {
                    SystemLogic.Logs.LogFS(sw, "No files of type '" + fileType + "' found in this batch.  Skipping to next batch... ");
                    return;
                }


                SystemLogic.Logs.LogFS(sw, "Query complete: " + GetTotalTimeMessage(queryStart, DateTime.Now) + "Total Count: " + attachmentList.Count);
                int fileCount = 1;
                //Loop Through each partrecord and create the file path copy.
                SystemLogic.Logs.LogFS(sw, "Looping through database atatchments. ..");
                foreach (partpicture p in attachmentList)
                {
                    try
                    {

                        if (p.filetype.ToLower() != fileType.ToLower())
                            continue;
                        SystemLogic.Logs.LogFS(sw, "Creating file " + fileCount + "...");
                        if (p.picturedata == null)
                        {
                            SystemLogic.Logs.LogFS(sw, "No picturedata detected for part: " + p.fullpartnumber + "ID: " + p.unique_id + " setting as 'No File Path'");
                            p.file_path = "No File Path";
                            rzp.SaveChanges();
                            continue;
                        }

                        //SystemLogic.Logs.LogFS(sw, "Creating file Number " + fileCount + Environment.NewLine);

                        //If path already exists, continue through loop.
                        if (!string.IsNullOrEmpty(p.file_path))
                        {
                            SystemLogic.Logs.LogFS(sw, "Path Exists, Skipping: " + p.unique_id + " Path: " + p.file_path);
                            throw new Exception("Critical: Query should be omitting empty or null file paths.  We should not have a blank file path here.");
                        }

                        //Perform the Database conversion logic
                        //SystemLogic.Logs.LogFS(sw, "Saving database attachment to folder....");
                        p.file_path = SaveDataBaseAttachmentToFolder(sw, p) ?? "";// Don't want to save nulls.
                        if (string.IsNullOrEmpty(p.file_path))
                        {
                            string errMsg = "Error: Invalid File Path.";
                            SystemLogic.Logs.LogFS(sw, errMsg);
                            throw new Exception(errMsg);
                        }

                        //SystemLogic.Logs.LogFS(sw, "Successfully created file and path: " + p.file_path);


                        //Commit the database      
                        SystemLogic.Logs.LogFS(sw, "Saving path to Database.");
                        rzp.SaveChanges();


                        successCount++;
                        //Create result string
                        string message = "Successfully created file " + fileCount + " FileName:" + p.filename + " Path: " + p.file_path + Environment.NewLine + "Total Successful: " + successCount;
                        //Log success event
                        SystemLogic.Logs.LogFS(sw, message);
                        fileCount++;
                    }
                    catch (Exception ex)
                    {
                        string errorMessage = "Part: " + p.fullpartnumber + "<br />";
                        errorMessage += "Path: " + p.file_path + "<br />";
                        errorMessage += "ID: " + p.unique_id + "<br />";
                        errorMessage += "Error: " + ex.Message + "<br />";
                        if (ex.InnerException != null)
                        {
                            errorMessage += "Inner 1: " + ex.InnerException.Message + "<br />";
                            if (ex.InnerException.InnerException != null)
                            {

                                errorMessage += "Inner 2: " + ex.InnerException.InnerException.Message + "<br />";
                            }
                        }

                        SystemLogic.Logs.LogFS(sw, errorMessage);
                        sw.Close();
                        throw new Exception(errorMessage);
                    }

                }
            }
        }




    }



    public class ftp
    {
        public static Uri GetFtpUri()
        {
            //"ftp://rzdist.sensiblemicro.local/"
            Uri ret = new Uri("ftp://rzdist.sensiblemicro.local/");
            return ret;
        }

        public static NetworkCredential GetFtpCredentials()
        {
            string ftpUser = "sm_operations";
            string ftpPass = "ATkab;?+Mc/zro#Gilb^";

            NetworkCredential ret = new NetworkCredential();
            ret.UserName = ftpUser;
            ret.Password = ftpPass;
            //ret.Domain = "sensiblemicro.local";

            return ret;
        }

        private static string GetFtpPathFromUNCPath(string UNC_path)
        {
            string ftpBaseUri = GetFtpUri().AbsoluteUri;
            // string ret = UNC_path.Replace(@"\\\\storage.sensiblemicro.local\\sm_storage\\rz_attachments", "");
            //ret = ret.Replace("\\\\", "/");
            string ret = UNC_path.Replace(@"\\storage\sm_storage\rz_attachments\", "");
            //ret = ret.Replace("\\\\", "/");
            ret = ret.Replace(@"\\", "/");
            ret = ret.Replace(@"\", "/");
            ret = ftpBaseUri + ret;
            return ret;

        }

        public static bool FTPUpload(byte[] fileBytes, string fileName, string UNC_path)
        {
            try
            {

                bool ret = false;

                // Get the object used to communicate with the server.
                string ftpBasePath = GetFtpPathFromUNCPath(UNC_path);
                //Make sure this directory exists, FTP Will not auto-create
                FTPCreateDirectory(ftpBasePath);
                //URI Encode teh fileName to handle "#" and other special characters.
                string ftpFullPath = ftpBasePath + HttpUtility.UrlEncode(fileName);
                //ftpFullPath = SanitizeSpecialCharactersForUploas(ftpFullPath);
                ////To better handle special characters, use a URI, and check for characters like "#"
                //Uri targetUri = new Uri(ftpFullPath, UriKind.Absolute);
                //if ((ftpFullPath).IndexOf("#") > -1)
                //{
                //    //if there is a "#", escape it.
                //    targetUri = new Uri(Uri.EscapeDataString(ftpFullPath));
                //}               


               
               
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFullPath);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = GetFtpCredentials();

                // Copy the contents of the file to the request stream.
                request.ContentLength = fileBytes.Length;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                }

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    ret = CheckFTPResult(response);
                }


                return ret;
            }

            catch (WebException e)
            {
                String status = ((FtpWebResponse)e.Response).StatusDescription;                
                return false;
            }
        }

        //public static string SanitizeSpecialCharactersForUpload(string ftpFullPath)
        //{
        //    string ret = ftpFullPath.Replace('#','_');


        //    return ret;
        //}

        public static byte[] FTPGet(string UNC_path)
        {
            string ftpBasePath = GetFtpUri().AbsoluteUri;
            //Need the file name so we can convert for special characters
            string fileName  = UNC_path.Substring(UNC_path.LastIndexOf('\\') + 1);
            string uncBasePath = UNC_path.Replace(fileName, "");
            string encodedFileName = Uri.EscapeUriString(fileName);
            //string encodedFileName = HttpUtility.UrlEncode(fileName);
            string convertedPath = UNC_path.Replace(@"\\storage\sm_storage\rz_attachments", "");
            convertedPath = convertedPath.Replace(fileName, encodedFileName);
            convertedPath = convertedPath.Replace(@"\", "/");            
            string url = ftpBasePath + convertedPath;
            WebClient request = new WebClient();
            ////Some characters, like "#" don't get written to the file system, therefore, scrub them
            //url = url.Replace("#","");
            request.Credentials = GetFtpCredentials();

            try
            {
                byte[] newFileData = request.DownloadData(url);
                return newFileData;
            }
            catch (WebException e)
            {
                return null;
                throw new Exception("Unable to retrieve file: "+UNC_path);
            }

        }

        //public static string FTPListDir(byte[] source_fileBytes, string fileName)
        //{

        //    string ret = "";
        //    // Get the object used to communicate with the server.
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(GetFtpUri().AbsoluteUri);
        //    request.Method = WebRequestMethods.Ftp.DownloadFile;

        //    // This example assumes the FTP site uses anonymous logon.
        //    request.Credentials = GetFtpCredentials();
        //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

        //    Stream responseStream = response.GetResponseStream();
        //    StreamReader reader = new StreamReader(responseStream);
        //    Console.WriteLine(reader.ReadToEnd());

        //    //Console.WriteLine($"Download Complete, status {response.StatusDescription}");
        //    ret = response.StatusDescription;
        //    reader.Close();
        //    response.Close();

        //    return ret;
        //}

        public static bool FTPDelete(string UNC_path)
        {

            try
            {               
                bool ret = false;
                string ftpFullPath = GetFtpPathFromUNCPath(UNC_path);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFullPath);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = GetFtpCredentials();

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {                    
                    ret = CheckFTPResult(response);
                }

                return ret;
            }

            catch (WebException e)
            {
                String status = ((FtpWebResponse)e.Response).StatusDescription;
                return false;
            }





        }

        private static bool CheckFTPResult(FtpWebResponse response)
        {

            switch (response.StatusCode)
            {
                //ClosingData	226	Specifies that the server is closing the data connection and that the requested file action was successful.
                case FtpStatusCode.PathnameCreated://Create Directory
                case FtpStatusCode.ClosingData://Upload File
                case FtpStatusCode.FileActionOK://Delete File
                    {
                        return true;
                    }
                default:
                    {
                        throw new Exception("FTP Operation Failed.");
                    }
            }
        }

        private static bool FTPCreateDirectory(string ftpPath)
        {

            try
            {
                // Get the object used to communicate with the server.             

                WebRequest dirRequest = WebRequest.Create(ftpPath);


                dirRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                dirRequest.Credentials = GetFtpCredentials();
                using (var response = (FtpWebResponse)dirRequest.GetResponse())
                {
                    if (!CheckFTPResult(response))
                        throw new Exception("Error creating FTP Directory: " + response.StatusDescription);
                }

                return true;
            }

            catch (WebException e)
            {
                //If directory Exists, return true
                String status = ((FtpWebResponse)e.Response).StatusDescription;
                if (status == "550 Directory already exists\r\n")
                    return true;
                return false;
            }

        }



    }

}
