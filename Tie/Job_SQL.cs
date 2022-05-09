using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Threading;
using System.Data;

using NewMethodx;

namespace Tie
{

    public delegate void GotDataTableHandler(String strSQLID, DataTable d);
    public delegate void ConnectionStateChangeHandler();
    public delegate void GotDataTableFileHandler(String strSQLID, String strFile, long size, long rows);
    public delegate void SQLCommandFinishHandler(String strSQLID, bool passed, long row_count, long elapsed_seconds, String resultmessage);

    public class Job_SQL : TieJob
    {
        public event GotDataTableHandler GotDataTable;
        public event ConnectionStateChangeHandler ConnectionStateChanged;
        public event GotDataTableFileHandler GotDataTableFile;
        public event SQLCommandFinishHandler SQLCommandFinished;

        public bool CanConnect = false;

        TieMessage OriginalMessage;
        TieMessage ReturnMessage;

        //public n_data_target TheTarget;
        //public DataConnectionSqlServer xData;
        public Tools.Database.DataConnection xData;

        ArrayList AsyncThreads = new ArrayList();

        public Job_SQL(TieEnd e)
            : base(e)
        {
            Name = "SQL";
        }

        public override void Do()
        {
            try
            {
                BeforeDo();
                SendOpenRequest();

            }
            catch (Exception)
            { }
        }

        public void SendOpenRequest()
        {
            OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "open_sql_request", TargetSession);
            OriginalMessage.ContentString = GetTargetXml();
            AddLog("Sending sql request...");

            if (!Send(OriginalMessage))
            {
                ;
            }
        }

        public void FireConnectionStateChangeEvent()
        {
            if (ConnectionStateChanged != null)
                ConnectionStateChanged();
        }

        private String GetTargetXml()
        {
            StringBuilder sb = new StringBuilder();
            if (xData != null)
            {
                sb.Append(Tools.Xml.BuildXmlProp("server_name", xData.TheKey.ServerName) + "\n");
                sb.Append(Tools.Xml.BuildXmlProp("target_type", (int)xData.GetServerType()) + "\n");
                sb.Append(Tools.Xml.BuildXmlProp("user_name", xData.TheKey.UserName) + "\n");
                sb.Append(Tools.Xml.BuildXmlProp("user_password", xData.TheKey.UserPassword) + "\n");
                sb.Append(Tools.Xml.BuildXmlProp("database_name", xData.TheKey.DatabaseName) + "\n");
                sb.Append(Tools.Xml.BuildXmlProp("absolute_connection_string", xData.ConnectionString) + "\n");
            }
            return sb.ToString();
        }

        private void ReadTargetXml(TieMessage m)
        {
            //xData.target_type = Tools.Xml.ReadXmlProp_Integer(m.ContentNode, "target_type");
            xData = Tools.Database.DataConnection.Create((Tools.Database.ServerType)Tools.Xml.ReadXmlProp_Integer(m.ContentNode, "target_type"));
            Tools.Database.Key key = new Tools.Database.Key();
            key.ServerName = Tools.Xml.ReadXmlProp(m.ContentNode, "server_name");
            key.UserName = Tools.Xml.ReadXmlProp(m.ContentNode, "user_name");
            key.UserPassword = Tools.Xml.ReadXmlProp(m.ContentNode, "user_password");
            key.DatabaseName = Tools.Xml.ReadXmlProp(m.ContentNode, "database_name");
            xData.Init(key);
            xData.ConnectionString = Tools.Xml.ReadXmlProp(m.ContentNode, "absolute_connection_string");
        }

        public override void GotMessage(TieMessage m)
        {
            try
            {
                TieMessage reply;
                switch (m.FunctionName)
                {
                    case "open_sql_request":
                        ReturnMessage = m;
                        AddLog("Received sql request...");
                        ReadTargetXml(m);
                        reply = GetReply(m);
                        try 
                        { 
                            xData.ConnectPossible();
                            reply.FunctionName = "connection_ready";
                        }
                        catch (Exception e)
                        {
                            reply.FunctionName = "connection_failed";
                            reply.ContentString = Tools.Xml.BuildXmlProp("connection_string", xData.ConnectionString) + Tools.Xml.BuildXmlProp("error_message", e.Message);
                        }
                        Send(reply);
                        break;
                    case "connection_ready":
                        CanConnect = true;
                        FireConnectionStateChangeEvent();
                        AddPositive("Connection made");
                        break;
                    case "connection_failed":
                        CanConnect = false;
                        FireConnectionStateChangeEvent();
                        String strError = Tools.Xml.ReadXmlProp(m.ContentNode, "error_message");
                        AddNegative("Connection failed: " + strError);
                        ResultStatus = strError;
                        break;
                    case "command_result":
                    case "query_result":
                        FireGotMessageEvent(m);
                        break;
                    case "sql_command_request":
                    case "sql_query_request":
                        HandleCommandAsync(m);
                        break;
                    case "data_table_result":
                        GotDataTableResult(m, false);
                        break;
                    case "data_table_file_result":
                        GotDataTableResult(m, true);
                        break;
                    case "async_sql_start":
                        AddInfo("Starting SQL command...");
                        break;
                    case "async_sql_end":
                        String strID = Tools.Xml.ReadXmlProp(m.ContentNode, "sql_id");
                        bool success = Tools.Xml.ReadXmlProp_Boolean(m.ContentNode, "success");
                        long l = Tools.Xml.ReadXmlProp_Long(m.ContentNode, "affected");
                        long secs = Tools.Xml.ReadXmlProp_Long(m.ContentNode, "elapsed_seconds");
                        String result = Tools.Xml.ReadXmlProp(m.ContentNode, "result_message");
                        if (success)
                        {
                            
                            AddPositive("SQL command complete in " + Tools.Dates.FormatHMS(secs) + " : " + Tools.Number.LongFormat(l) + " affected");
                        }
                        else
                            AddNegative("SQL command failed: " + Tools.Xml.ReadXmlProp(m.ContentNode, "result_message"));

                        if (SQLCommandFinished != null)
                            SQLCommandFinished(strID, success, l, secs, result);

                        break;
                    default:
                        base.GotMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                AddLog("SQL Error: " + ex.Message);
            }
        }

        private void HandleCommandAsync(TieMessage m)
        {
            Thread t = new Thread(new ParameterizedThreadStart(HandleCommandOnThread));
            t.SetApartmentState(ApartmentState.STA);

            lock (AsyncThreads.SyncRoot)
            {
                AsyncThreads.Add(t);
            }

            t.Start(m);
        }

        private void HandleCommandOnThread(Object x)
        {
            TieMessage m = (TieMessage)x;
            TieMessage reply = GetReply(m);
            String strSQLID = Tools.Xml.ReadXmlProp(m.ContentNode, "sql_id");
            reply.FunctionName = "async_sql_start";
            reply.ContentString = Tools.Xml.BuildXmlProp("sql_id", strSQLID);
            if (!Send(reply))
            {
                AddNegative("Start sql notification failed.");
                return;
            }
            String result = "";
            long affected = 0;
            bool success = false;
            String strSQL = Tools.Xml.ReadXmlProp(m.ContentNode, "sql");
            DataTable d = null;
            DateTime start = DateTime.Now;
            switch (m.FunctionName)
            {
                case "sql_command_request":
                    try 
                    {
                        xData.Execute(strSQL, ref affected);
                        success = true;
                    }
                    catch (Exception e) { result = e.Message; }
                    break;
                case "sql_query_request":
                    try { d = xData.Select(strSQL); }
                    catch (Exception e) { result = e.Message; }
                    success = (d != null);
                    break;
            }
            TimeSpan t = DateTime.Now.Subtract(start);
            reply = GetReply(m);
            reply.FunctionName = "async_sql_end";
            StringBuilder sb = new StringBuilder();
            sb.Append(Tools.Xml.BuildXmlProp("sql_id", strSQLID) + "\n");
            sb.Append(Tools.Xml.BuildXmlProp("success", success) + "\n");
            sb.Append(Tools.Xml.BuildXmlProp("result_message", result) + "\n");
            sb.Append(Tools.Xml.BuildXmlProp("affected", affected) + "\n");
            sb.Append(Tools.Xml.BuildXmlProp("elapsed_seconds", Convert.ToInt32(t.TotalSeconds)) + "\n");
            reply.ContentString = sb.ToString();
            Send(reply);
            if (m.FunctionName == "sql_query_request" && success)
            {
                //what to do with it?
                String strHandlingInstructions = Tools.Xml.ReadXmlProp(m.ContentNode, "handling_instructions");
                switch (strHandlingInstructions)
                {
                    case "":
                    case "return":  //just send it back
                        ReturnDataTable(m, d, strSQLID);
                        break;
                    case "export_to_csv":
                        String strFile = TranslateFileName(Tools.Xml.ReadXmlProp(m.ContentNode, "file_name"));
                        bool ExportSuccess = false;
                        String ExportStatus = "";
                        if (File.Exists(strFile))
                            ExportStatus = "File " + strFile + " already exists";
                        else
                        {
                            try 
                            {
                                xData.ExportCSV(d, strFile, ref affected);
                                ExportSuccess = true;
                            }
                            catch { }
                        }
                        if (ExportSuccess)
                        {
                            reply = GetReply(m);
                            reply.FunctionName = "sql_export_complete";
                            reply.ContentString = Tools.Xml.BuildXmlProp("sql_id", strSQLID) + Tools.Xml.BuildXmlProp("row_count", affected) + Tools.Xml.BuildXmlProp("file_name", strFile);
                            Send(reply);
                        }
                        else
                        {
                            reply = GetReply(m);
                            reply.FunctionName = "sql_export_error";
                            reply.ContentString = Tools.Xml.BuildXmlProp("sql_id", strSQLID);
                            Send(reply);
                        }
                        break;
                }
            }
        }

        public void ReturnDataTable(TieMessage m, DataTable d, String strSQLID)
        {
            //why not just write the whole thing out to a file, regardless of the size or composition, then decide from there how to send it back based on the file size?
            //if its small, just base64 encode the whole thing and cram it into the contents
            //if its bigger, then just return the file name, etc.
            //how does the Xml writing handle binary fields?
            d.DataSet.Tables.Remove(d);
            DataSet s = new DataSet();
            s.Tables.Add(d);
            String strFile = TieEnd.LocalTempFolder + "data_table_" + strSQLID + ".xml";
            s.WriteXml(strFile);

            TieMessage reply = GetReply(m);

            FileInfo f = new FileInfo(strFile);
            if (f.Length < (1024 * 4))
            {
                reply.FunctionName = "data_table_result";
                String str = Tools.Files.OpenFileAsString(strFile);
                reply.ContentString = Tools.Xml.BuildXmlProp("sql_id", strSQLID) + "<result_data>" + Convert.ToBase64String(Encoding.Unicode.GetBytes(str)) + "</result_data>";
            }
            else
            {
                reply.FunctionName = "data_table_file_result";
                reply.ContentString = Tools.Xml.BuildXmlProp("sql_id", strSQLID) + Tools.Xml.BuildXmlProp("file_size", f.Length) + Tools.Xml.BuildXmlProp("row_count", d.Rows.Count) + Tools.Xml.BuildXmlProp("file_name", strFile);
            }
            if (Send(reply))
                AddPositive("Sent data table result");
            else
                AddPositive("Data table result send failed");
        }

        public bool CanSerializeDataTable(DataTable d, StringBuilder sb)
        {
            //DataSet d;
            //d.ReadXml(

            //if (d.Rows * d.Columns > 100)

                
            //    return false;

            ////assume its simple and start building it.

            //foreach (DataColumn c in d.Columns)
            //{
            //    sb.Append(Tools.Xml.BuildXmlProp("column", c.Caption) + "\n");
            //}

            //foreach (DataRow r in d.Rows)
            //{
            //    sb.Append("<row>\n");


            //    sb.Append("<row>\n");

            //}

            return false;
        }

        public void RequestCommand(String strSQLID, String strSQL)
        {
            TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "sql_command_request", TargetSession);
            reply.ContentString = Tools.Xml.BuildXmlProp("sql_id", strSQLID) + Tools.Xml.BuildXmlProp("sql", strSQL);

            Send(reply);
        }

        public void RequestQuery(String strSQLID, String strSQL)
        {
            TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "sql_query_request", TargetSession);
            reply.ContentString = Tools.Xml.BuildXmlProp("sql_id", strSQLID) + Tools.Xml.BuildXmlProp("sql", strSQL);
            Send(reply);
        }

        public void GotDataTableResult(TieMessage m, bool as_file)
        {
            try
            {

                String strSQLID = Tools.Xml.ReadXmlProp(m.ContentNode, "sql_id");
                AddPositive("Got data table result [" + strSQLID + "]");

                if (as_file)
                {
                    String strFile = Tools.Xml.ReadXmlProp(m.ContentNode, "file_name");
                    long size = Tools.Xml.ReadXmlProp_Long(m.ContentNode, "file_size");
                    long rows = Tools.Xml.ReadXmlProp_Long(m.ContentNode, "row_count");


                    if(GotDataTableFile != null)
                        GotDataTableFile(strSQLID, strFile, size, rows);

                }
                else
                {
                    String s = Encoding.Unicode.GetString(Convert.FromBase64String(Tools.Xml.ReadXmlProp(m.ContentNode, "result_data")));
                    String strFile = TieEnd.LocalTempFolder + "data_result_" + strSQLID + ".xml";
                    Tools.Files.SaveFileAsString(strFile, s);

                    DataSet d = new DataSet();
                    d.ReadXml(strFile);

                    DataTable dt = d.Tables[0];
                    if (GotDataTable != null)
                        GotDataTable(strSQLID, dt);
                }

            }
            catch(Exception ex)
            {
                AddNegative("Error parsing data table result: " + ex.Message);
            }
        }
    }
}
