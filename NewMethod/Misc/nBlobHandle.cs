using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Drawing;
using Tools.Database;

namespace NewMethod
{
    public class nBlobHandle
    {
        //public SysNewMethod xSys;
        public DataConnectionSqlServer xData;
        public String TableName = "";
        public String FieldName = "";
        public String UniqueID = "";
        //Properties
        private Byte[] m_Bytes = null;
        public Byte[] GetBytes()
        {
            if (m_Bytes != null)
                return m_Bytes;

            //if (xSys.DisconnectedMode)
            //    return GetBytesFromLocalFile();

            String SQL = "select " + FieldName + " from " + TableName + " where unique_id = '" + UniqueID + "'";
            Byte[] data;
            try
            {
                SqlConnection xConnect = new SqlConnection(xData.ConnectionString.Replace(Tools.Strings.Split(xData.ConnectionString, ";")[0] + ";", ""));
                SqlCommand oCmd = xConnect.CreateCommand();
                oCmd.CommandTimeout = DataConnection.TimeOut;
                oCmd.CommandText = SQL;
                xConnect.Open();
                data = (byte[])oCmd.ExecuteScalar();
                oCmd.Dispose();
                oCmd = null;
                xConnect.Close();
                xConnect = null;
                m_Bytes = data;
            }
            catch (Exception)
            {
                m_Bytes = null;
                return null;
            }
            return m_Bytes;
        }


        public nBlobHandle(String s)
        {
            SetBytesFromString(s);
        }

        public void SetBytesFromString(String s)
        {
            m_Bytes = Encoding.Unicode.GetBytes(s);
        }

        public nBlobHandle(Byte[] bytes)
        {
            m_Bytes = bytes;
        }

        public bool IsNull
        {
            get
            {
                return (m_Bytes == null);
            }
        }

        public nBlobHandle(ContextNM context, String strTable, String strField, String strID)
        {
            //if (xs == null)
            //    return;
            //xSys = xs;
            xData = (DataConnectionSqlServer)context.TheData.TheConnection;
            TableName = strTable;
            FieldName = strField;
            UniqueID = strID;
        }
        //Public Functions
        public void SetFromFile(String strFile)
        {
            if (!File.Exists(strFile))
                throw new Exception(strFile + " does not exist");

            Byte[] data = System.IO.File.ReadAllBytes(strFile);
            SetFromBytes(data);
        }
        public void SetFromString(String s)
        {
            SetFromBytes(Encoding.Unicode.GetBytes(s));
        }

        public void SetFromImage(Image i)
        {
            Bitmap b = new Bitmap(i);
            MemoryStream m = new MemoryStream();
            b.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
            SetFromBytes(m.GetBuffer());
            m.Close();
            m.Dispose();
            m = null;          
        }

        public void Update()
        {
            SetFromBytes(m_Bytes);
        }

        public void SetFromBytes(Byte[] data)
        {
            //if (xSys.DisconnectedMode)
            //    return SetFromBytesToLocalFile(data);

            String SQL;

            if (data == null)
            {
                SQL = "update " + TableName + " set " + FieldName + " = null where unique_id = '" + UniqueID + "'";
                xData.Execute(SQL);
                return;
            }
            else
                SQL = "update " + TableName + " set " + FieldName + " = @picture where unique_id = '" + UniqueID + "'";

            Int32 affect;
            SqlConnection xConnect = new SqlConnection(xData.ConnectionString.Replace(Tools.Strings.Split(xData.ConnectionString, ";")[0] + ";", ""));
            SqlCommand oCmd = xConnect.CreateCommand();
            oCmd.CommandTimeout = DataConnection.TimeOut;
            oCmd.CommandText = SQL;
            SqlParameter param = new SqlParameter("@picture", SqlDbType.VarBinary);
            param.Value = data;
            oCmd.Parameters.Add(param);
            xConnect.Open();
            affect = oCmd.ExecuteNonQuery();
            oCmd.Dispose();
            oCmd = null;
            xConnect.Close();
            xConnect = null;
            if (affect <= 0)
                throw new Exception("No records affected");
        }

        public void ShowPictureExternally()
        {
            try
            {
                String strFile = "c:\\temp_image.jpg";
                if (File.Exists(strFile))
                    File.Delete(strFile);

                SaveAsFile(strFile);
                Tools.Files.OpenFileInDefaultViewer(strFile);
            }
            catch { }
        }

        public bool SaveAsFile(String strFileName)
        {
            if (File.Exists(strFileName))
                return false;
            Byte[] b = GetBytes();
            if (b == null)
                return false;
            if (b.Length == 0)
                return false;
            File.WriteAllBytes(strFileName, b);
            b = null;
            return true;
        }
        public bool SaveAsFileString(String strFileName)
        {
            if (File.Exists(strFileName))
                return false;
            String s = GetString();
            return Tools.Files.SaveFileAsString(strFileName, s);
        }
        public bool Exists()
        {
            return GetBytes() != null;
        }

        public String GetString(int len, ref bool more)
        {
            Byte[] b = new Byte[len];
            Byte[] x = GetBytes();
            for (int i = 0; i < len; i++)
            {
                if (i >= x.Length)
                    break;
                b[i] = x[i];
            }
            more = (x.Length > len);
            return System.Text.Encoding.Unicode.GetString(b);
        }

        public String GetString()
        {
            try
            {
                return System.Text.Encoding.Unicode.GetString(GetBytes());
            }
            catch
            {
                return "";
            }
        }
        public System.Drawing.Bitmap GetJpg()
        {
            if (!Exists())
                return null;
            try
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(GetBytes()))
                {
                    Bitmap bmp = new Bitmap(ms);
                    return bmp;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void SetToNull()
        {
            SetFromBytes(null);
        }

        public System.Drawing.Image GetAsImage()
        {
            Image i = GetJpg();
            if (i == null)
                return null;

            return i;
        }

        //public bool SetFromBytesToLocalFile(Byte[] data)
        //{
        //    try
        //    {
        //        String s = GetLocalFileName();
        //        if( File.Exists(s) )
        //            File.Delete(s);

        //        if (data == null)
        //            return true;

        //        BinaryWriter w = new BinaryWriter(new FileStream(s, FileMode.Create, FileAccess.Write));
        //        w.Write(data);
        //        w.Close();
        //        w = null;
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public Byte[] GetBytesFromLocalFile()
        //{
        //    try
        //    {
        //        String s = GetLocalFileName();
        //        if( !File.Exists(s) )
        //            return null;

        //        FileInfo f = new FileInfo(s);
        //        BinaryReader r = new BinaryReader(new FileStream(s, FileMode.Open, FileAccess.Read));
        //        Byte[] b = r.ReadBytes(Convert.ToInt32(f.Length));
        //        r.Close();
        //        r = null;
        //        return b;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public String GetLocalFileName()
        //{
        //    return SysNewMethod.StaticDataPath + TableName + "__" + UniqueID + "__" + FieldName + ".blob";
        //}
    }
}
