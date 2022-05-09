//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Threading;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.IO;
//using ICSharpCode.SharpZipLib.Zip;
//using System.Net;
//using System.Net.Sockets;

//namespace NewMethod
//{
//    public static class nError
//    {
//        public static SysNewMethod xSys;
//        public static String FTPServer = "";
//        public static String FTPUser = "";
//        public static String FTPPassword = "";
//        public static String FTPErrorFolder = "";
//        public static Int32 FTPMinutes = 1;
//        public static frmErrorHandler xForm;
//        public static String FilePath = eTools.ConditionFolderName(eTools.GetAppPath()) + "ErrLog.txt";
//        public static Boolean Initialized = false;
    
//        //Public Static Functions
//        public static void InitErrorSystem(SysNewMethod xs, String FTPServer, String FTPUser, String FTPPassword, String FTPErrorFolder, Int32 FTPMinutes)
//        {
//            nError.xSys = xs;
//            nError.FTPServer = FTPServer;
//            nError.FTPUser = FTPUser;
//            nError.FTPPassword = FTPPassword;
//            nError.FTPErrorFolder = FTPErrorFolder;
//            nError.FTPMinutes = FTPMinutes;
//            nError.xForm = new frmErrorHandler();
//            nError.xForm.notifyIcon1.Visible = false;
//            nError.xForm.Show();
//            Initialized = true;
//        }
//        public static void HandleError(Exception e)
//        {
//            try
//            {
//                if (!Initialized)
//                    return;
//                nErrorObject err = new nErrorObject();
//                err.ClassTree = e.TargetSite.ReflectedType.FullName;
//                err.Procedure = e.TargetSite.ToString();
//                err.Message = e.Message;
//                err.StringValue = e.ToString();
//                String[] ss = eTools.Split(e.StackTrace, ":");
//                if (ss.Length == 3)
//                {
//                    Int64 i = 0;
//                    Int64.TryParse(ss[2].ToLower().Replace("line", "").Trim(), out i);
//                    err.LineNumber = i;
//                    err.FileName = eTools.GetFileName(ss[1]);
//                }
//                err.HandleError();
//            }
//            catch (Exception)
//            { }
//        }
//        public static void HandleError(nErrorObject e)
//        {
//            try
//            {
//                if (!Initialized)
//                    return;
//                e.WriteErrorToFile();
//            }
//            catch (Exception)
//            { }
//        }
//        public static Boolean UploadErrorFile(String filepath)
//        {
//            try
//            {
//                eFTP ftp = new eFTP(nError.FTPServer, nError.FTPUser, nError.FTPPassword);
//                ftp.Connect();
//                if (!ftp.IsConnected)
//                    return false;
//                if (!ftp.ChangeDir(nError.FTPErrorFolder))
//                {
//                    ftp.MakeDir(nError.FTPErrorFolder);
//                    if (!ftp.ChangeDir(nError.FTPErrorFolder))
//                        return false;
//                }
//                String status = "";
//                return ftp.SendFile(filepath, nError.eTools.GetFileName(filepath), ref status);
//            }
//            catch
//            { return false; }
//        }
//        //Public Classes
//        public class eTools
//        {
//            //Public Static Functions
//            public static String[] Split(String strIn, String strSplit)
//            {
//                return strIn.Split(new String[] { strSplit }, StringSplitOptions.None);
//            }
//            public static String GetFileName(String fullpath)
//            {
//                try
//                {
//                    String[] hold = eTools.Split(fullpath, "\\");
//                    Int32 i = hold.Length - 1;
//                    return hold[i].Trim();
//                }
//                catch (Exception)
//                { return ""; }
//            }
//            public static Boolean HasString(String sIn, String sFind)
//            {
//                if (sIn == null)
//                    return false;
//                if (sFind == null)
//                    return false;
//                Int64 l = sIn.ToLower().IndexOf(sFind.ToLower());
//                return l >= 0;
//            }
//            public static String ConditionFolderName(String s)
//            {
//                if (eTools.Right(s, 1) == "\\")
//                    return s;
//                else
//                    return s + "\\";
//            }
//            public static String GetAppPath()
//            {
//                StringBuilder sb = new StringBuilder();
//                sb.Append(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim()));
//                if (Right(sb.ToString(), 1) != "\\")
//                    sb.Append("\\");
//                return sb.ToString();
//            }
//            public static String Right(String strIn, int len)
//            {
//                try
//                {
//                    return strIn.Substring(strIn.Length - len, len);
//                }
//                catch
//                { return ""; }
//            }
//            public static Boolean ZipOneFile(String strFileName, String strZipName)
//            {
//                try
//                {
//                    ZipOutputStream s = new ZipOutputStream(File.Create(strZipName));
//                    FileStream fs = File.OpenRead(strFileName);
//                    ZipEntry entry = new ZipEntry(Path.GetFileName(strFileName));
//                    entry.DateTime = DateTime.Now;
//                    entry.Size = fs.Length;
//                    s.PutNextEntry(entry);
//                    Int64 total = fs.Length;
//                    Int32 chunksize = 4096;
//                    Int64 chunks = total / chunksize;
//                    Int32 leftover = Convert.ToInt32(total % Convert.ToInt64(chunksize));
//                    for (int ch = 0; ch < chunks; ch++)
//                    {
//                        byte[] buffer = new byte[chunksize];
//                        fs.Read(buffer, 0, chunksize);
//                        s.Write(buffer, 0, buffer.Length);
//                    }
//                    if (leftover > 0)
//                    {
//                        byte[] buffer = new byte[leftover];
//                        fs.Read(buffer, 0, leftover);
//                        s.Write(buffer, 0, buffer.Length);
//                    }
//                    fs.Close();
//                    s.Finish();
//                    s.Close();
//                    s = null;
//                    return true;
//                }
//                catch (Exception)
//                {
//                    return false;
//                }
//            }
//            public static String GetNewID()
//            {
//                try
//                {
//                    System.Guid x = System.Guid.NewGuid();
//                    return x.ToString().Replace("-", "");
//                }
//                catch
//                {
//                    return DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
//                }
//            }
//            public static Boolean SaveFileAsString(String strFileName, String strData)
//            {
//                try
//                {
//                    System.IO.StreamWriter file = new System.IO.StreamWriter(strFileName, false);
//                    file.Write(strData);
//                    file.Close();
//                    return true;
//                }
//                catch
//                {
//                    return false;
//                }
//            }
//            public static String OpenFileAsString(String strFile)
//            {
//                String s;
//                try
//                {
//                    System.IO.StreamReader w = new System.IO.StreamReader(strFile);
//                    s = w.ReadToEnd();
//                    w.Close();
//                    return s;
//                }
//                catch (Exception e)
//                {
//                    return "";
//                }
//            }
//            public static Boolean StrExt(String s)
//            {
//                if (s == null)
//                    return false;
//                if (s.Trim().Length <= 0)
//                    return false;
//                return true;
//            }
//        }
//        public class nErrorObject
//        {
//            public DateTime ErrorDateTime = DateTime.Now;
//            public String Message = "";
//            public String Procedure = "";
//            public Int64 LineNumber = 0;
//            public String FileName = "";
//            public String ClassTree = "";
//            public String StringValue = "";
//            public String FullProcedure = "";
//            public String ComputerName = Environment.MachineName;
//            public String UserName = "NONE";
//            public String CompanyName = "NONE";
//            public String ApplicationName = nError.xSys.ApplicationName();

//            public nErrorObject()
//            {
//                if (nError.xSys != null)
//                {
//                    if (nError.xSys.xUser != null)
//                        UserName = nError.xSys.xUser.name;
//                    String comp = nError.xSys.GetSetting("owner_companyname");
//                    if (nError.eTools.StrExt(comp))
//                        CompanyName = comp;
//                }
//            }
//            public nErrorObject(String sMessage, String sProcedure, Int64 iLineNumber, String sFileName, String sClassTree, String sStringValue, String sFullProcedure)
//            {
//                if (nError.xSys != null)
//                {
//                    if (nError.xSys.xUser != null)
//                        UserName = nError.xSys.xUser.name;
//                    String comp = nError.xSys.GetSetting("owner_companyname");
//                    if (nError.eTools.StrExt(comp))
//                        CompanyName = comp;
//                    Message = sMessage;
//                    Procedure = sProcedure;
//                    LineNumber = iLineNumber;
//                    FileName = sFileName;
//                    ClassTree = sClassTree;
//                    StringValue = sStringValue;
//                    FullProcedure = sFullProcedure;
//                }
//            }
//            //Public Functions
//            public void HandleError()
//            {
//                if (eTools.HasString(Procedure, ".ctor"))
//                    Procedure = Procedure.Replace(".ctor", "Constructor");
//                FullProcedure = ClassTree.Replace("+", ".") + "." + Procedure;
//                WriteErrorToFile();
//            }
//            public String GetErrorLine()
//            {
//                String line = "'" + ErrorDateTime.ToString() + "'";
//                line += ",'" + FilterValueForFile(ApplicationName) + "'";
//                line += ",'" + FilterValueForFile(ComputerName) + "'";
//                line += ",'" + FilterValueForFile(CompanyName) + "'";
//                line += ",'" + FilterValueForFile(UserName) + "'";
//                line += ",'" + FilterValueForFile(Message) + "'";
//                line += ",'" + FilterValueForFile(Procedure) + "'";
//                line += ",'" + LineNumber.ToString() + "'";
//                line += ",'" + FilterValueForFile(FileName) + "'";
//                line += ",'" + FilterValueForFile(ClassTree) + "'";
//                line += ",'" + FilterValueForFile(StringValue) + "'";
//                line += ",'" + FilterValueForFile(FullProcedure) + "'";
//                return line;
//            }
//            public void WriteErrorToFile()
//            {
//                Thread t = new Thread(new ParameterizedThreadStart(WriteErrorToFileOnThread));
//                t.SetApartmentState(ApartmentState.STA);
//                t.Start(this);
//                t.Join();
//            }
//            //Private Functions
//            private void WriteErrorToFileOnThread(Object x)
//            {
//                try
//                {
//                    nErrorObject e = (nErrorObject)x;
//                    String errline = e.GetErrorLine();
//                    String fileguts = nError.eTools.OpenFileAsString(nError.FilePath);
//                    if (!nError.eTools.StrExt(fileguts))
//                        nError.eTools.SaveFileAsString(nError.FilePath, "");
//                    StringBuilder sb = new StringBuilder(nError.eTools.OpenFileAsString(nError.FilePath));
//                    sb.AppendLine(errline);
//                    nError.eTools.SaveFileAsString(nError.FilePath, sb.ToString());
//                }
//                catch
//                { }
//            }
//            private String FilterValueForFile(String value)
//            {
//                String filtered = value.Replace("\r\n", "<crlf>");
//                return filtered.Replace(",", "<comma>");
//            }
//        }
//        //Private Classes
//        private class eFTP
//        {
//            //Public Variables
//            public string server;
//            public string user;
//            public string pass;
//            public int port;
//            public int timeout;
//            //Private Variables
//            private string messages; 
//            private string responseStr; 
//            private bool passive_mode;		
//            private long bytes_total; 
//            private long file_size; 
//            private Socket main_sock;
//            private IPEndPoint main_ipEndPoint;
//            private Socket listening_sock;
//            private Socket data_sock;
//            private IPEndPoint data_ipEndPoint;
//            private FileStream file;
//            private int response;
//            private string bucket;

//            //Constructors
//            public eFTP(string server, string user, string pass)
//            {
//                this.server = server;
//                this.user = user;
//                this.pass = pass;
//                port = 21;
//                passive_mode = true;	
//                main_sock = null;
//                main_ipEndPoint = null;
//                listening_sock = null;
//                data_sock = null;
//                data_ipEndPoint = null;
//                file = null;
//                bucket = "";
//                bytes_total = 0;
//                timeout = 10000;	
//                messages = "";
//            }
//            //Public Functions
//            public void Connect()
//            {
//                if (server == null)
//                    throw new Exception("No server has been set.");
//                if (user == null)
//                    throw new Exception("No username has been set.");
//                if (main_sock != null)
//                    if (main_sock.Connected)
//                        return;
//                main_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//                main_ipEndPoint = new IPEndPoint(Dns.GetHostByName(server).AddressList[0], port);
//                try
//                {
//                    main_sock.Connect(main_ipEndPoint);
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(ex.Message);
//                }
//                ReadResponse();
//                if (response != 220)
//                    Fail();
//                SendCommand("USER " + user);
//                ReadResponse();
//                switch (response)
//                {
//                    case 331:
//                        if (pass == null)
//                        {
//                            Disconnect();
//                            throw new Exception("No password has been set.");
//                        }
//                        SendCommand("PASS " + pass);
//                        ReadResponse();
//                        if (response != 230)
//                            Fail();
//                        break;
//                    case 230:
//                        break;
//                }
//                return;
//            }
//            public void Disconnect()
//            {
//                CloseDataSocket();
//                if (main_sock != null)
//                {
//                    if (main_sock.Connected)
//                    {
//                        SendCommand("QUIT");
//                        main_sock.Close();
//                    }
//                    main_sock = null;
//                }
//                if (file != null)
//                    file.Close();
//                main_ipEndPoint = null;
//                file = null;
//            }
//            public bool IsConnected
//            {
//                get
//                {
//                    if (main_sock != null)
//                        return main_sock.Connected;
//                    return false;
//                }
//            }
//            public Boolean ChangeDir(string path)
//            {
//                Connect();
//                SendCommand("CWD " + path);
//                ReadResponse();
//                if (response != 250)
//                    return false;
//                return true;
//            }
//            public void MakeDir(string dir)
//            {
//                Connect();
//                SendCommand("MKD " + dir);
//                ReadResponse();
//                switch (response)
//                {
//                    case 257:
//                    case 250:
//                        break;
//                    default:
//                        throw new Exception(responseStr);
//                }
//            }
//            public bool SendFile(String strLocal, String strName, ref String status)
//            {
//                try
//                {
//                    OpenUpload(strLocal, strName, false);
//                    while (DoUpload() > 0)
//                    {
//                        System.Windows.Forms.Application.DoEvents();
//                    }
//                    return true;
//                }
//                catch (Exception ex)
//                {
//                    status = ex.Message;
//                    return false;
//                }
//            }
//            public void OpenUpload(string filename, string remote_filename, bool resume)
//            {
//                Connect();
//                SetBinaryMode(true);
//                OpenDataSocket();
//                bytes_total = 0;
//                try
//                {
//                    file = new FileStream(filename, FileMode.Open);
//                }
//                catch (Exception ex)
//                {
//                    file = null;
//                    throw new Exception(ex.Message);
//                }
//                file_size = file.Length;
//                if (resume)
//                {
//                    long size = GetFileSize(remote_filename);
//                    SendCommand("REST " + size);
//                    ReadResponse();
//                    if (response == 350)
//                        file.Seek(size, SeekOrigin.Begin);
//                }
//                SendCommand("STOR " + remote_filename);
//                ReadResponse();
//                switch (response)
//                {
//                    case 125:
//                    case 150:
//                        break;
//                    default:
//                        file.Close();
//                        file = null;
//                        throw new Exception(responseStr);
//                }
//                ConnectDataSocket();
//                return;
//            }
//            public long DoUpload()
//            {
//                Byte[] bytes = new Byte[512];
//                long bytes_got;
//                try
//                {
//                    bytes_got = file.Read(bytes, 0, bytes.Length);
//                    bytes_total += bytes_got;
//                    data_sock.Send(bytes, (int)bytes_got, 0);
//                    if (bytes_got <= 0)
//                    {
//                        file.Close();
//                        file = null;
//                        CloseDataSocket();
//                        ReadResponse();
//                        switch (response)
//                        {
//                            case 226:
//                            case 250:
//                                break;
//                            default:
//                                throw new Exception(responseStr);
//                        }
//                        SetBinaryMode(false);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    file.Close();
//                    file = null;
//                    CloseDataSocket();
//                    ReadResponse();
//                    SetBinaryMode(false);
//                    throw ex;
//                }
//                return bytes_got;
//            }
//            public long GetFileSize(string filename)
//            {
//                Connect();
//                SendCommand("SIZE " + filename);
//                ReadResponse();
//                if (response != 213)
//                    throw new Exception(responseStr);
//                return Int64.Parse(responseStr.Substring(4));
//            }
//            //Private Functions
//            private void ReadResponse()
//            {
//                string buf;
//                messages = "";
//                while (true)
//                {
//                    buf = GetLineFromBucket();
//                    if (Regex.Match(buf, "^[0-9]+ ").Success)
//                    {
//                        responseStr = buf;
//                        response = int.Parse(buf.Substring(0, 3));
//                        break;
//                    }
//                    else
//                        messages += Regex.Replace(buf, "^[0-9]+-", "") + "\n";
//                }
//            }
//            private void Fail()
//            {
//                Disconnect();
//                throw new Exception(responseStr);
//            }
//            private void CloseDataSocket()
//            {
//                if (data_sock != null)
//                {
//                    if (data_sock.Connected)
//                        data_sock.Close();
//                    data_sock = null;
//                }
//                data_ipEndPoint = null;
//            }
//            private string GetLineFromBucket()
//            {
//                int i;
//                string buf = "";
//                if ((i = bucket.IndexOf('\n')) < 0)
//                {
//                    while (i < 0)
//                    {
//                        FillBucket();
//                        i = bucket.IndexOf('\n');
//                    }
//                }
//                buf = bucket.Substring(0, i);
//                bucket = bucket.Substring(i + 1);
//                return buf;
//            }
//            private void FillBucket()
//            {
//                Byte[] bytes = new Byte[512];
//                long bytesgot;
//                int msecs_passed = 0;
//                while (main_sock.Available < 1)
//                {
//                    System.Threading.Thread.Sleep(50);
//                    msecs_passed += 50;
//                    if (msecs_passed > timeout)
//                    {
//                        Disconnect();
//                        throw new Exception("Timed out waiting on server to respond.");
//                    }
//                }
//                while (main_sock.Available > 0)
//                {
//                    bytesgot = main_sock.Receive(bytes, 512, 0);
//                    bucket += Encoding.ASCII.GetString(bytes, 0, (int)bytesgot);
//                    System.Threading.Thread.Sleep(50);
//                }
//            }
//            private void SendCommand(string command)
//            {
//                Byte[] cmd = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());
//                main_sock.Send(cmd, cmd.Length, 0);
//            }
//            private void SetBinaryMode(bool mode)
//            {
//                if (mode)
//                    SendCommand("TYPE I");
//                else
//                    SendCommand("TYPE A");
//                ReadResponse();
//                if (response != 200)
//                    Fail();
//            }
//            private void OpenDataSocket()
//            {
//                if (passive_mode)	
//                {
//                    string[] pasv;
//                    string server;
//                    int port;
//                    Connect();
//                    SendCommand("PASV");
//                    ReadResponse();
//                    if (response != 227)
//                        Fail();
//                    try
//                    {
//                        int i1, i2;
//                        i1 = responseStr.IndexOf('(') + 1;
//                        i2 = responseStr.IndexOf(')') - i1;
//                        pasv = responseStr.Substring(i1, i2).Split(',');
//                    }
//                    catch (Exception)
//                    {
//                        Disconnect();
//                        throw new Exception("Malformed PASV response: " + responseStr);
//                    }
//                    if (pasv.Length < 6)
//                    {
//                        Disconnect();
//                        throw new Exception("Malformed PASV response: " + responseStr);
//                    }
//                    server = String.Format("{0}.{1}.{2}.{3}", pasv[0], pasv[1], pasv[2], pasv[3]);
//                    port = (int.Parse(pasv[4]) << 8) + int.Parse(pasv[5]);
//                    try
//                    {
//                        CloseDataSocket();
//                        data_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//                        data_ipEndPoint = new IPEndPoint(Dns.GetHostByName(server).AddressList[0], port);
//                        data_sock.Connect(data_ipEndPoint);
//                    }
//                    catch (Exception ex)
//                    {
//                        throw new Exception("Failed to connect for data transfer: " + ex.Message);
//                    }
//                }
//                else		
//                {
//                    Connect();
//                    try
//                    {
//                        CloseDataSocket();
//                        listening_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//                        string sLocAddr = main_sock.LocalEndPoint.ToString();
//                        int ix = sLocAddr.IndexOf(':');
//                        if (ix < 0)
//                        {
//                            throw new Exception("Failed to parse the local address: " + sLocAddr);
//                        }
//                        string sIPAddr = sLocAddr.Substring(0, ix);
//                        System.Net.IPEndPoint localEP = new IPEndPoint(IPAddress.Parse(sIPAddr), 0);
//                        listening_sock.Bind(localEP);
//                        sLocAddr = listening_sock.LocalEndPoint.ToString();
//                        ix = sLocAddr.IndexOf(':');
//                        if (ix < 0)
//                        {
//                            throw new Exception("Failed to parse the local address: " + sLocAddr);
//                        }
//                        int nPort = int.Parse(sLocAddr.Substring(ix + 1));
//                        listening_sock.Listen(1);
//                        string sPortCmd = string.Format("PORT {0},{1},{2}", sIPAddr.Replace('.', ','), nPort / 256, nPort % 256);
//                        SendCommand(sPortCmd);
//                        ReadResponse();
//                        if (response != 200)
//                            Fail();
//                    }
//                    catch (Exception ex)
//                    {
//                        throw new Exception("Failed to connect for data transfer: " + ex.Message);
//                    }
//                }
//            }
//            private void ConnectDataSocket()
//            {
//                if (data_sock != null)		
//                    return;
//                try
//                {
//                    data_sock = listening_sock.Accept();	
//                    listening_sock.Close();
//                    listening_sock = null;
//                    if (data_sock == null)
//                    {
//                        throw new Exception("Winsock error: " +
//                            Convert.ToString(System.Runtime.InteropServices.Marshal.GetLastWin32Error()));
//                    }
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception("Failed to connect for data transfer: " + ex.Message);
//                }
//            }
//        }
//    }
//}
