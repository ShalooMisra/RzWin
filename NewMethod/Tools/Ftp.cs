//using System;
//using System.IO;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Collections;

//namespace Tools
//{
//    public delegate void FTPProgressHandler(int progress);
//    public delegate void FTPStatusHandler(String status);
//    public partial class Ftp
//    {

//        public static bool GetFileFTP(FTP ftplib, String strName, String strLocal, FTPProgressHandler progress, FTPStatusHandler status)
//        {
//            try
//            {
//                ftplib.OpenDownload(strName, strLocal);

//                if (status != null)
//                    status("Getting " + strLocal + "...");

//                int perc;
//                while (ftplib.DoDownload() > 0)
//                {
//                    perc = (int)(((ftplib.BytesTotal) * 100) / ftplib.FileSize);
//                    //SetStatus("Upload: " + Tools.Number.LongFormat(ftplib.BytesTotal / 1024) + " / " + Tools.Number.LongFormat(ftplib.FileSize / 1024) + " ( " + perc.ToString() + "% )");
//                    if (progress != null)
//                        progress(perc);

//                    System.Windows.Forms.Application.DoEvents();
//                }
//            }
//            catch (Exception ex)
//            {
//                if (status != null)
//                    status("Error: " + ex.Message);
//                return false;
//            }

//            return true;
//        }

//        public static String DownloadFTPString(String strURI, String strUserName, String strPassword)
//        {
//            String sf = Tools.FileSystem.GetAppPath() + "temp_" + Tools.Strings.GetNewID() + ".txt";
//            if (File.Exists(sf))
//                File.Delete(sf);
//            if (!GetFileFTPDotNet(strURI, sf, null, null, strUserName, strPassword, 0))
//                return "";
//            String s = Tools.Files.OpenFileAsString(sf);
//            File.Delete(sf);
//            return s;
//        }

//        public static bool GetFileFTPDotNet(String strURI, String strLocalFile, FTPProgressHandler progress, FTPStatusHandler status, String strUserName, String strPassword, long totalsize)
//        {
//            if (!strURI.StartsWith("ftp://"))
//                strURI = "ftp://" + strURI;

//            bool b = true;
//            try
//            {
//                if (status != null)
//                    status("Getting " + strLocalFile + "...");

//                FileStream outputStream = new FileStream(strLocalFile, FileMode.Create);

//                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(strURI));
//                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
//                reqFTP.UseBinary = true;
//                //reqFTP.UsePassive = false;
//                reqFTP.Credentials = new NetworkCredential(strUserName, strPassword);
//                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
//                Stream ftpStream = response.GetResponseStream();
//                long cl = response.ContentLength;
//                int bufferSize = 2048;
//                int readCount;
//                long done = 0;
//                byte[] buffer = new byte[bufferSize];

//                readCount = ftpStream.Read(buffer, 0, bufferSize);
//                while (readCount > 0)
//                {
//                    outputStream.Write(buffer, 0, readCount);
//                    readCount = ftpStream.Read(buffer, 0, bufferSize);
//                    done += readCount;

//                    if (progress != null)
//                        progress(Convert.ToInt32(Tools.Number.CalcPercent(totalsize, done)));

//                    System.Windows.Forms.Application.DoEvents();
//                }

//                if (progress != null)
//                    progress(100);

//                ftpStream.Close();
//                outputStream.Close();
//                response.Close();

//                if (!response.StatusDescription.StartsWith("226"))
//                {
//                    b = false;
//                    if (status != null)
//                        status("Transfer of " + strLocalFile + " failed: " + response.StatusDescription);
//                }
//            }
//            catch (Exception ex)
//            {
//                b = false;
//                if (status != null)
//                    status("RTE: " + ex.Message + "...");
//            }
//            return b;
        
//        }

//    }
//    public class FTP
//    {
//        //Public Variables
//        public string server;
//        public string user;
//        public string pass;
//        public int port;
//        public int timeout;
//        //Private Variables
//        private string messages; // server messages
//        private string responseStr; // server response if the user wants it.
//        private bool passive_mode;		// #######################################
//        private long bytes_total; // upload/download info if the user wants it.
//        private long file_size; // gets set when an upload or download takes place
//        private Socket main_sock;
//        private IPEndPoint main_ipEndPoint;
//        private Socket listening_sock;
//        private Socket data_sock;
//        private IPEndPoint data_ipEndPoint;
//        private FileStream file;
//        private int response;
//        private string bucket;

//        //Constructors
//        public FTP()
//        {
//            server = null;
//            user = null;
//            pass = null;
//            port = 21;
//            passive_mode = true;		// #######################################
//            main_sock = null;
//            main_ipEndPoint = null;
//            listening_sock = null;
//            data_sock = null;
//            data_ipEndPoint = null;
//            file = null;
//            bucket = "";
//            bytes_total = 0;
//            timeout = 10000;	// 10 seconds
//            messages = "";
//        }
//        public FTP(string server, string user, string pass)
//        {
//            this.server = server;
//            this.user = user;
//            this.pass = pass;
//            port = 21;
//            passive_mode = true;		// #######################################
//            main_sock = null;
//            main_ipEndPoint = null;
//            listening_sock = null;
//            data_sock = null;
//            data_ipEndPoint = null;
//            file = null;
//            bucket = "";
//            bytes_total = 0;
//            timeout = 10000;	// 10 seconds
//            messages = "";
//        }
//        public FTP(string server, int port, string user, string pass)
//        {
//            this.server = server;
//            this.user = user;
//            this.pass = pass;
//            this.port = port;
//            passive_mode = true;		// #######################################
//            main_sock = null;
//            main_ipEndPoint = null;
//            listening_sock = null;
//            data_sock = null;
//            data_ipEndPoint = null;
//            file = null;
//            bucket = "";
//            bytes_total = 0;
//            timeout = 10000;	// 10 seconds
//            messages = "";
//        }
//        //Public Functions
//        public bool IsConnected
//        {
//            get
//            {
//                if (main_sock != null)
//                    return main_sock.Connected;
//                return false;
//            }
//        }
//        public bool MessagesAvailable
//        {
//            get
//            {
//                if (messages.Length > 0)
//                    return true;
//                return false;
//            }
//        }
//        public string Messages
//        {
//            get
//            {
//                string tmp = messages;
//                messages = "";
//                return tmp;
//            }
//        }
//        public string ResponseString
//        {
//            get
//            {
//                return responseStr;
//            }
//        }
//        public long BytesTotal		// #######################################
//        {
//            get
//            {
//                return bytes_total;
//            }
//        }
//        public long FileSize		// #######################################
//        {
//            get
//            {
//                return file_size;
//            }
//        }
//        public bool PassiveMode		// #######################################
//        {
//            get
//            {
//                return passive_mode;
//            }
//            set
//            {
//                passive_mode = value;
//            }
//        }
//        public void Disconnect()
//        {
//            CloseDataSocket();

//            if (main_sock != null)
//            {
//                if (main_sock.Connected)
//                {
//                    SendCommand("QUIT");
//                    main_sock.Close();
//                }
//                main_sock = null;
//            }

//            if (file != null)
//                file.Close();

//            main_ipEndPoint = null;
//            file = null;
//        }
//        public void Connect(string server, int port, string user, string pass)
//        {
//            this.server = server;
//            this.user = user;
//            this.pass = pass;
//            this.port = port;

//            Connect();
//        }
//        public void Connect(string server, string user, string pass)
//        {
//            this.server = server;
//            this.user = user;
//            this.pass = pass;

//            Connect();
//        }
//        public void Connect()
//        {
//            if (server == null)
//                throw new Exception("No server has been set.");
//            if (user == null)
//                throw new Exception("No username has been set.");

//            if (main_sock != null)
//                if (main_sock.Connected)
//                    return;

//            main_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            main_ipEndPoint = new IPEndPoint(Dns.GetHostByName(server).AddressList[0], port);

//            try
//            {
//                main_sock.Connect(main_ipEndPoint);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }

//            ReadResponse();
//            if (response != 220)
//                Fail();

//            SendCommand("USER " + user);
//            ReadResponse();

//            switch (response)
//            {
//                case 331:
//                    if (pass == null)
//                    {
//                        Disconnect();
//                        throw new Exception("No password has been set.");
//                    }
//                    SendCommand("PASS " + pass);
//                    ReadResponse();
//                    if (response != 230)
//                        Fail();
//                    break;
//                case 230:
//                    break;
//            }

//            return;
//        }
//        public ArrayList List()
//        {
//            Byte[] bytes = new Byte[512];
//            string file_list = "";
//            long bytesgot = 0;
//            int msecs_passed = 0;
//            ArrayList list = new ArrayList();

//            Connect();
//            OpenDataSocket();
//            SendCommand("LIST");
//            ReadResponse();

//            //FILIPE MADUREIRA.
//            //Added response 125
//            switch (response)
//            {
//                case 125:
//                case 150:
//                    break;
//                default:
//                    CloseDataSocket();
//                    throw new Exception(responseStr);
//            }
//            ConnectDataSocket();		// #######################################

//            while (data_sock.Available < 1)
//            {
//                System.Threading.Thread.Sleep(50);
//                msecs_passed += 50;
//                // this code is just a fail safe option 
//                // so the code doesn't hang if there is 
//                // no data comming.
//                if (msecs_passed > (timeout / 10))
//                {
//                    //CloseDataSocket();
//                    //throw new Exception("Timed out waiting on server to respond.");

//                    //FILIPE MADUREIRA.
//                    //If there are no files to list it gives timeout.
//                    //So I wait less time and if no data is received, means that there are no files
//                    break;//Maybe there are no files
//                }
//            }

//            while (data_sock.Available > 0)
//            {
//                bytesgot = data_sock.Receive(bytes, bytes.Length, 0);
//                file_list += Encoding.ASCII.GetString(bytes, 0, (int)bytesgot);
//                System.Threading.Thread.Sleep(50); // *shrug*, sometimes there is data comming but it isn't there yet.
//            }

//            CloseDataSocket();

//            ReadResponse();
//            if (response != 226)
//                throw new Exception(responseStr);

//            foreach (string f in file_list.Split('\n'))
//            {
//                if (f.Length > 0 && !Regex.Match(f, "^total").Success)
//                    list.Add(f.Substring(0, f.Length - 1));
//            }

//            return list;
//        }
//        public ArrayList ListFiles()
//        {
//            ArrayList list = new ArrayList();

//            foreach (string f in List())
//            {
//                //FILIPE MADUREIRA
//                //In Windows servers it is identified by <DIR>
//                if ((f.Length > 0))
//                {
//                    if ((f[0] != 'd') && (f.ToUpper().IndexOf("<DIR>") < 0))
//                        list.Add(f);
//                }
//            }

//            return list;
//        }
//        public ArrayList ListDirectories()
//        {
//            ArrayList list = new ArrayList();

//            foreach (string f in List())
//            {
//                //FILIPE MADUREIRA
//                //In Windows servers it is identified by <DIR>
//                if (f.Length > 0)
//                {
//                    if ((f[0] == 'd') || (f.ToUpper().IndexOf("<DIR>") >= 0))
//                        list.Add(f);
//                }
//            }

//            return list;
//        }
//        public string GetFileDateRaw(string fileName)
//        {
//            Connect();

//            SendCommand("MDTM " + fileName);
//            ReadResponse();
//            if (response != 213)
//            {
//#if (FTP_DEBUG)
//                Console.Write("\r" + responseStr);
//#endif
//                throw new Exception(responseStr);
//            }

//            return (this.responseStr.Substring(4));
//        }
//        public DateTime GetFileDate(string fileName)
//        {
//            return ConvertFTPDateToDateTime(GetFileDateRaw(fileName));
//        }
//        public string GetWorkingDirectory()
//        {
//            //PWD - print working directory
//            Connect();
//            SendCommand("PWD");
//            ReadResponse();

//            if (response != 257)
//                throw new Exception(responseStr);

//            string pwd;
//            try
//            {
//                pwd = responseStr.Substring(responseStr.IndexOf("\"", 0) + 1);//5);
//                pwd = pwd.Substring(0, pwd.LastIndexOf("\""));
//                pwd = pwd.Replace("\"\"", "\""); // directories with quotes in the name come out as "" from the server
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Uhandled PWD response: " + ex.Message);
//            }

//            return pwd;
//        }
//        public void ChangeDir(string path)
//        {
//            Connect();
//            SendCommand("CWD " + path);
//            ReadResponse();
//            if (response != 250)
//            {
//#if (FTP_DEBUG)
//                Console.Write("\r" + responseStr);
//#endif
//                throw new Exception(responseStr);
//            }
//        }
//        public void MakeDir(string dir)
//        {
//            Connect();
//            SendCommand("MKD " + dir);
//            ReadResponse();

//            switch (response)
//            {
//                case 257:
//                case 250:
//                    break;
//                default:
//#if (FTP_DEBUG)
//                    Console.Write("\r" + responseStr);
//#endif
//                    throw new Exception(responseStr);
//            }
//        }
//        public void RemoveDir(string dir)
//        {
//            Connect();
//            SendCommand("RMD " + dir);
//            ReadResponse();
//            if (response != 250)
//            {
//#if (FTP_DEBUG)
//                Console.Write("\r" + responseStr);
//#endif
//                throw new Exception(responseStr);
//            }
//        }
//        public void RemoveFile(string filename)
//        {
//            Connect();
//            SendCommand("DELE " + filename);
//            ReadResponse();
//            if (response != 250)
//            {
//#if (FTP_DEBUG)
//                Console.Write("\r" + responseStr);
//#endif
//                throw new Exception(responseStr);
//            }
//        }
//        public void RenameFile(string oldfilename, string newfilename)		// #######################################
//        {
//            Connect();
//            SendCommand("RNFR " + oldfilename);
//            ReadResponse();
//            if (response != 350)
//            {
//#if (FTP_DEBUG)
//                Console.Write("\r" + responseStr);
//#endif
//                throw new Exception(responseStr);
//            }
//            else
//            {
//                SendCommand("RNTO " + newfilename);
//                ReadResponse();
//                if (response != 250)
//                {
//#if (FTP_DEBUG)
//                    Console.Write("\r" + responseStr);
//#endif
//                    throw new Exception(responseStr);
//                }
//            }
//        }
//        public long GetFileSize(string filename)
//        {
//            Connect();
//            SendCommand("SIZE " + filename);
//            ReadResponse();
//            if (response != 213)
//            {
//#if (FTP_DEBUG)
//                Console.Write("\r" + responseStr);
//#endif
//                throw new Exception(responseStr);
//            }

//            return Int64.Parse(responseStr.Substring(4));
//        }
//        public void OpenUpload(string filename)
//        {
//            OpenUpload(filename, filename, false);
//        }
//        public void OpenUpload(string filename, string remotefilename)
//        {
//            OpenUpload(filename, remotefilename, false);
//        }
//        public void OpenUpload(string filename, bool resume)
//        {
//            OpenUpload(filename, filename, resume);
//        }
//        public void OpenUpload(string filename, string remote_filename, bool resume)
//        {
//            Connect();
//            SetBinaryMode(true);
//            OpenDataSocket();

//            bytes_total = 0;

//            try
//            {
//                file = new FileStream(filename, FileMode.Open);
//            }
//            catch (Exception ex)
//            {
//                file = null;
//                throw new Exception(ex.Message);
//            }

//            file_size = file.Length;

//            if (resume)
//            {
//                long size = GetFileSize(remote_filename);
//                SendCommand("REST " + size);
//                ReadResponse();
//                if (response == 350)
//                    file.Seek(size, SeekOrigin.Begin);
//            }

//            SendCommand("STOR " + remote_filename);
//            ReadResponse();

//            switch (response)
//            {
//                case 125:
//                case 150:
//                    break;
//                default:
//                    file.Close();
//                    file = null;
//                    throw new Exception(responseStr);
//            }
//            ConnectDataSocket();		// #######################################	

//            return;
//        }
//        public void OpenDownload(string filename)
//        {
//            OpenDownload(filename, filename, false);
//        }
//        public void OpenDownload(string filename, bool resume)
//        {
//            OpenDownload(filename, filename, resume);
//        }
//        public void OpenDownload(string filename, string localfilename)
//        {
//            OpenDownload(filename, localfilename, false);
//        }
//        public void OpenDownload(string remote_filename, string local_filename, bool resume)
//        {
//            Connect();
//            SetBinaryMode(true);

//            bytes_total = 0;

//            try
//            {
//                file_size = GetFileSize(remote_filename);
//            }
//            catch
//            {
//                file_size = 0;
//            }

//            if (resume && File.Exists(local_filename))
//            {
//                try
//                {
//                    file = new FileStream(local_filename, FileMode.Open);
//                }
//                catch (Exception ex)
//                {
//                    file = null;
//                    throw new Exception(ex.Message);
//                }

//                SendCommand("REST " + file.Length);
//                ReadResponse();
//                if (response != 350)
//                    throw new Exception(responseStr);
//                file.Seek(file.Length, SeekOrigin.Begin);
//                bytes_total = file.Length;
//            }
//            else
//            {
//                try
//                {
//                    file = new FileStream(local_filename, FileMode.Create);
//                }
//                catch (Exception ex)
//                {
//                    file = null;
//                    throw new Exception(ex.Message);
//                }
//            }

//            OpenDataSocket();
//            SendCommand("RETR " + remote_filename);
//            ReadResponse();

//            switch (response)
//            {
//                case 125:
//                case 150:
//                    break;
//                default:
//                    file.Close();
//                    file = null;
//                    throw new Exception(responseStr);
//            }
//            ConnectDataSocket();		// #######################################	

//            return;
//        }
//        public long DoUpload()
//        {
//            Byte[] bytes = new Byte[512];
//            long bytes_got;

//            try
//            {
//                bytes_got = file.Read(bytes, 0, bytes.Length);
//                bytes_total += bytes_got;
//                data_sock.Send(bytes, (int)bytes_got, 0);

//                if (bytes_got <= 0)
//                {
//                    // the upload is complete or an error occured
//                    file.Close();
//                    file = null;

//                    CloseDataSocket();
//                    ReadResponse();
//                    switch (response)
//                    {
//                        case 226:
//                        case 250:
//                            break;
//                        default:
//                            throw new Exception(responseStr);
//                    }

//                    SetBinaryMode(false);
//                }
//            }
//            catch (Exception ex)
//            {
//                file.Close();
//                file = null;
//                CloseDataSocket();
//                ReadResponse();
//                SetBinaryMode(false);
//                throw ex;
//            }

//            return bytes_got;
//        }
//        public long DoDownload()
//        {
//            Byte[] bytes = new Byte[512];
//            long bytes_got;

//            try
//            {
//                bytes_got = data_sock.Receive(bytes, bytes.Length, 0);

//                if (bytes_got <= 0)
//                {
//                    // the download is done or an error occured
//                    CloseDataSocket();
//                    file.Close();
//                    file = null;

//                    ReadResponse();
//                    switch (response)
//                    {
//                        case 226:
//                        case 250:
//                            break;
//                        default:
//                            throw new Exception(responseStr);
//                    }

//                    SetBinaryMode(false);

//                    return bytes_got;
//                }

//                file.Write(bytes, 0, (int)bytes_got);
//                bytes_total += bytes_got;
//            }
//            catch (Exception ex)
//            {
//                CloseDataSocket();
//                file.Close();
//                file = null;
//                ReadResponse();
//                SetBinaryMode(false);
//                throw ex;
//            }

//            return bytes_got;
//        }
//        public String ParseListEntry(String s)
//        {
//            try
//            {
//                String[] ary = Tools.Strings.Split(s, " ");
//                return (ary[ary.Length - 1]);
//            }
//            catch (Exception)
//            {
//                return "";
//            }
//        }

//        public bool SendFile(String strLocal, String strName, ref String status)
//        {
//            return SendFile(strLocal, strName, ref status, null);
//        }

//        public bool SendFile(String strLocal, ref String status)
//        {
//            return SendFile(strLocal, Path.GetFileName(strLocal), ref status, null);
//        }

//        public bool SendFile(String strLocal, ref String status, FTPProgressHandler progress)
//        {
//            return SendFile(strLocal, Path.GetFileName(strLocal), ref status, progress);
//        }

//        public bool SendFile(String strLocal, String strName, ref String status, FTPProgressHandler progress)
//        {
//            try
//            {
//                OpenUpload(strLocal, strName);

//                while (DoUpload() > 0)
//                {

//                    int perc = (int)(((BytesTotal) * 100) / FileSize);
//                    if (progress != null)
//                        progress(perc);

//                    System.Windows.Forms.Application.DoEvents();
//                }
//                return true;
//            }
//            catch (Exception ex)
//            {
//                status = ex.Message;
//                return false;
//            }
//        }
//        public bool SendString(String s, String strFile, ref String status)
//        {
//            String temp = Tools.FileSystem.GetAppPath() + "temp_ftp_send.file";
//            Tools.Files.SaveFileAsString(temp, s);
//            return SendFile(temp, strFile, ref status);
//        }
//        public bool HasFile(String strFile)
//        {
//            try
//            {
//                DateTime d = GetFileDate(strFile);
//                return Tools.Dates.DateExists(d);
//            }
//            catch { return false; }
//        }
//        public bool MoveCurrentFolder(String s)
//        {
//            if (!Tools.Strings.StrExt(s))
//                return true;

//            try
//            {
//                String[] ary = Tools.Strings.Split(s, "/");
//                foreach (String l in ary)
//                {
//                    if (Tools.Strings.StrExt(l))
//                    {
//                        ChangeDir(l.Trim());
//                    }
//                }
//                return true;
//            }
//            catch (Exception ex)
//            { return false; }
//        }
//        //Private Functions
//        private void Fail()
//        {
//            Disconnect();
//            throw new Exception(responseStr);
//        }
//        private void SetBinaryMode(bool mode)
//        {
//            if (mode)
//                SendCommand("TYPE I");
//            else
//                SendCommand("TYPE A");

//            ReadResponse();
//            if (response != 200)
//                Fail();
//        }
//        private void SendCommand(string command)
//        {
//            Byte[] cmd = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());

//#if (FTP_DEBUG)
//            if (command.Length > 3 && command.Substring(0, 4) == "PASS")
//                Console.WriteLine("\rPASS xxx");
//            else
//                Console.WriteLine("\r" + command);
//#endif

//            main_sock.Send(cmd, cmd.Length, 0);
//        }
//        private void FillBucket()
//        {
//            Byte[] bytes = new Byte[512];
//            long bytesgot;
//            int msecs_passed = 0;		// #######################################

//            while (main_sock.Available < 1)
//            {
//                System.Threading.Thread.Sleep(50);
//                msecs_passed += 50;
//                // this code is just a fail safe option 
//                // so the code doesn't hang if there is 
//                // no data comming.
//                if (msecs_passed > timeout)
//                {
//                    Disconnect();
//                    throw new Exception("Timed out waiting on server to respond.");
//                }
//            }

//            while (main_sock.Available > 0)
//            {
//                bytesgot = main_sock.Receive(bytes, 512, 0);
//                bucket += Encoding.ASCII.GetString(bytes, 0, (int)bytesgot);
//                // this may not be needed, gives any more data that hasn't arrived
//                // just yet a small chance to get there.
//                System.Threading.Thread.Sleep(50);
//            }
 
//        }
//        private string GetLineFromBucket()
//        {

//            int i;
//            string buf = "";

//            if ((i = bucket.IndexOf('\n')) < 0)
//            {
//                while (i < 0)
//                {
//                    FillBucket();
//                    i = bucket.IndexOf('\n');
//                }
//            }

//            buf = bucket.Substring(0, i);
//            bucket = bucket.Substring(i + 1);

//            return buf;

//        }
//        private void ReadResponse()
//        {
//            string buf;
//            messages = "";

//            while (true)
//            {
//                //buf = GetLineFromBucket();
//                buf = GetLineFromBucket();

//#if (FTP_DEBUG)
//                Console.WriteLine(buf);
//#endif
//                // the server will respond with "000-Foo bar" on multi line responses
//                // "000 Foo bar" would be the last line it sent for that response.
//                // Better example:
//                // "000-This is a multiline response"
//                // "000-Foo bar"
//                // "000 This is the end of the response"
//                if (Regex.Match(buf, "^[0-9]+ ").Success)
//                {
//                    responseStr = buf;
//                    response = int.Parse(buf.Substring(0, 3));
//                    break;
//                }
//                else
//                    messages += Regex.Replace(buf, "^[0-9]+-", "") + "\n";
//            }
//        }
//        private void OpenDataSocket()
//        {
//            if (passive_mode)		// #######################################
//            {
//                string[] pasv;
//                string server;
//                int port;

//                Connect();
//                SendCommand("PASV");
//                ReadResponse();
//                if (response != 227)
//                    Fail();

//                try
//                {
//                    int i1, i2;

//                    i1 = responseStr.IndexOf('(') + 1;
//                    i2 = responseStr.IndexOf(')') - i1;
//                    pasv = responseStr.Substring(i1, i2).Split(',');
//                }
//                catch (Exception)
//                {
//                    Disconnect();
//                    throw new Exception("Malformed PASV response: " + responseStr);
//                }

//                if (pasv.Length < 6)
//                {
//                    Disconnect();
//                    throw new Exception("Malformed PASV response: " + responseStr);
//                }

//                server = String.Format("{0}.{1}.{2}.{3}", pasv[0], pasv[1], pasv[2], pasv[3]);
//                port = (int.Parse(pasv[4]) << 8) + int.Parse(pasv[5]);

//    #if (FTP_DEBUG)
//                        Console.WriteLine("Data socket: {0}:{1}", server, port);
//    #endif
//                        CloseDataSocket();

//    #if (FTP_DEBUG)
//                        Console.WriteLine("Creating socket...");
//    #endif
//                        data_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//    #if (FTP_DEBUG)
//                        Console.WriteLine("Resolving host");
//    #endif

//                        data_ipEndPoint = new IPEndPoint(Dns.GetHostByName(server).AddressList[0], port);


//    #if (FTP_DEBUG)
//                        Console.WriteLine("Connecting..");
//    #endif
//                        data_sock.Connect(data_ipEndPoint);

//    #if (FTP_DEBUG)
//                        Console.WriteLine("Connected.");
//    #endif

//            }
//            else		// #######################################
//            {
//                Connect();

//                try
//                {
//#if (FTP_DEBUG)
//                    Console.WriteLine("Data socket (active mode)");
//#endif
//                    CloseDataSocket();

//#if (FTP_DEBUG)
//                    Console.WriteLine("Creating listening socket...");
//#endif
//                    listening_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//#if (FTP_DEBUG)
//                    Console.WriteLine("Binding it to local address/port");
//#endif
//                    // for the PORT command we need to send our IP address; let's extract it
//                    // from the LocalEndPoint of the main socket, that's already connected
//                    string sLocAddr = main_sock.LocalEndPoint.ToString();
//                    int ix = sLocAddr.IndexOf(':');
//                    if (ix < 0)
//                    {
//                        throw new Exception("Failed to parse the local address: " + sLocAddr);
//                    }
//                    string sIPAddr = sLocAddr.Substring(0, ix);
//                    // let the system automatically assign a port number (setting port = 0)
//                    System.Net.IPEndPoint localEP = new IPEndPoint(IPAddress.Parse(sIPAddr), 0);

//                    listening_sock.Bind(localEP);
//                    sLocAddr = listening_sock.LocalEndPoint.ToString();
//                    ix = sLocAddr.IndexOf(':');
//                    if (ix < 0)
//                    {
//                        throw new Exception("Failed to parse the local address: " + sLocAddr);
//                    }
//                    int nPort = int.Parse(sLocAddr.Substring(ix + 1));
//#if (FTP_DEBUG)
//                    Console.WriteLine("Listening on {0}:{1}", sIPAddr, nPort);
//#endif
//                    // start to listen for a connection request from the host (note that
//                    // Listen is not blocking) and send the PORT command
//                    listening_sock.Listen(1);
//                    string sPortCmd = string.Format("PORT {0},{1},{2}",
//                                                    sIPAddr.Replace('.', ','),
//                                                    nPort / 256, nPort % 256);
//                    SendCommand(sPortCmd);
//                    ReadResponse();
//                    if (response != 200)
//                        Fail();
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception("Failed to connect for data transfer: " + ex.Message);
//                }
//            }
//        }
//        private void ConnectDataSocket()		// #######################################
//        {
//            if (data_sock != null)		// already connected (always so if passive mode)
//                return;

//            try
//            {
//#if (FTP_DEBUG)
//                Console.WriteLine("Accepting the data connection.");
//#endif
//                data_sock = listening_sock.Accept();	// Accept is blocking
//                listening_sock.Close();
//                listening_sock = null;

//                if (data_sock == null)
//                {
//                    throw new Exception("Winsock error: " +
//                        Convert.ToString(System.Runtime.InteropServices.Marshal.GetLastWin32Error()));
//                }
//#if (FTP_DEBUG)
//                Console.WriteLine("Connected.");
//#endif
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Failed to connect for data transfer: " + ex.Message);
//            }
//        }
//        private void CloseDataSocket()
//        {
//#if (FTP_DEBUG)
//            Console.WriteLine("Attempting to close data channel socket...");
//#endif
//            if (data_sock != null)
//            {
//                if (data_sock.Connected)
//                {
//#if (FTP_DEBUG)
//                        Console.WriteLine("Closing data channel socket!");
//#endif
//                    data_sock.Close();
//#if (FTP_DEBUG)
//                        Console.WriteLine("Data channel socket closed!");
//#endif
//                }
//                data_sock = null;
//            }

//            data_ipEndPoint = null;
//        }
//        private DateTime ConvertFTPDateToDateTime(string input)
//        {
//            if (input.Length < 14)
//                throw new ArgumentException("Input Value for ConvertFTPDateToDateTime method was too short.");

//            //YYYYMMDDhhmmss": 
//            int year = Convert.ToInt16(input.Substring(0, 4));
//            int month = Convert.ToInt16(input.Substring(4, 2));
//            int day = Convert.ToInt16(input.Substring(6, 2));
//            int hour = Convert.ToInt16(input.Substring(8, 2));
//            int min = Convert.ToInt16(input.Substring(10, 2));
//            int sec = Convert.ToInt16(input.Substring(12, 2));
            
//            return new DateTime(year, month, day, hour, min, sec);
//        }

//        public ArrayList ListFileNames()
//        {
//            ArrayList l = ListFiles();
//            ArrayList r = new ArrayList();
//            foreach (String s in l)
//            {
//                String[] ary = Tools.Strings.Split(s, " ");
//                String t = ary[ary.Length - 1];
//                r.Add(t);
//            }
//            return r;
//        }

//    }
//}
