using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace OthersCode
{

    // Read an entire standard DBF file into a DataTable
    public class ParseDBF
    {
        // This is the file header for a DBF. We do this special layout with everything
        // packed so we can read straight from disk into the structure to populate it
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        private struct DBFHeader
        {
            public byte version;
            public byte updateYear;
            public byte updateMonth;
            public byte updateDay;
            public Int32 numRecords;
            public Int16 headerLen;
            public Int16 recordLen;
            public Int16 reserved1;
            public byte incompleteTrans;
            public byte encryptionFlag;
            public Int32 reserved2;
            public Int64 reserved3;
            public byte MDX;
            public byte language;
            public Int16 reserved4;
        }

        // This is the field descriptor structure. There will be one of these for each column in the table.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        private struct FieldDescriptor
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
            public string fieldName;
            public char fieldType;
            public Int32 address;
            public byte fieldLen;
            public byte count;
            public Int16 reserved1;
            public byte workArea;
            public Int16 reserved2;
            public byte flag;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] reserved3;
            public byte indexFlag;
        }

        // Read an entire standard DBF file into a DataTable

        public static DataTable ReadDBF(string dbfFile)
        {
            return ReadDBF(dbfFile, false);
        }

        public static DataTable ReadDBF(string dbfFile, bool as_text)
        {
            DataTable dt = new DataTable();
            BinaryReader recReader;
            string number;
            string year;
            string month;
            string day;
            DataRow row;

            // If there isn't even a file, just return an empty DataTable
            if ((false == File.Exists(dbfFile)))
            {
                return dt;
            }

            BinaryReader br = null;
            try
            {
                // Read the header into a buffer
                br = new BinaryReader(File.OpenRead(dbfFile));

                byte[] buffer = br.ReadBytes(Marshal.SizeOf(typeof(DBFHeader)));

                //check for other versions
                Byte versionbyte = buffer[0];
                Byte maskbyte = (byte)3;
                int result = versionbyte & maskbyte;

                switch (result)
                {
                    case 1:
                        br.Close();
                        br = null;
                        return ReadDBFI(dbfFile, as_text);
                    case 2:
                        br.Close();
                        return null;
                }

                // Marshall the header into a DBFHeader structure
                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                DBFHeader header = (DBFHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(DBFHeader));
                handle.Free();

                // Read in all the field descriptors. Per the spec, 13 (0D) marks the end of the field descriptors
                ArrayList fields = new ArrayList();
                while ((13 != br.PeekChar()))
                {
                    buffer = br.ReadBytes(Marshal.SizeOf(typeof(FieldDescriptor)));
                    handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                    fields.Add((FieldDescriptor)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(FieldDescriptor)));
                    handle.Free();

                    //mis-formatted files add up here
                    if (fields.Count > 8000)
                    {
                        if (null != br)
                        {
                            br.Close();
                        }

                        return dt;
                    }
                }

                // Read in the first row of records, we need this to help determine column types below
                ((FileStream)br.BaseStream).Seek(header.headerLen + 1, SeekOrigin.Begin);
                buffer = br.ReadBytes(header.recordLen);
                recReader = new BinaryReader(new MemoryStream(buffer));

                // Create the columns in our new DataTable
                DataColumn col = null;
                foreach (FieldDescriptor field in fields)
                {
                    number = Encoding.ASCII.GetString(recReader.ReadBytes(field.fieldLen));
                    if (as_text)
                    {
                        col = new DataColumn(field.fieldName, typeof(string));
                    }
                    else
                    {
                        switch (field.fieldType)
                        {
                            case 'N':
                                if (number.IndexOf(".") > -1)
                                {
                                    col = new DataColumn(field.fieldName, typeof(decimal));
                                }
                                else
                                {
                                    col = new DataColumn(field.fieldName, typeof(int));
                                }
                                break;
                            case 'C':
                                col = new DataColumn(field.fieldName, typeof(string));
                                break;
                            case 'D':
                                col = new DataColumn(field.fieldName, typeof(DateTime));
                                break;
                            case 'L':
                                col = new DataColumn(field.fieldName, typeof(bool));
                                break;
                            case 'F':
                                col = new DataColumn(field.fieldName, typeof(Double));
                                break;
                        }
                    }
                    dt.Columns.Add(col);
                }

                // Skip past the end of the header. 
                ((FileStream)br.BaseStream).Seek(header.headerLen, SeekOrigin.Begin);

                // Read in all the records
                for (int counter = 0; counter <= header.numRecords - 1; counter++)
                {
                    // First we'll read the entire record into a buffer and then read each field from the buffer
                    // This helps account for any extra space at the end of each record and probably performs better
                    buffer = br.ReadBytes(header.recordLen);
                    recReader = new BinaryReader(new MemoryStream(buffer));

                    // All dbf field records begin with a deleted flag field. Deleted - 0x2A (asterisk) else 0x20 (space)
                    if (recReader.ReadChar() == '*')
                    {
                        continue;
                    }

                    // Loop through each field in a record
                    row = dt.NewRow();
                    foreach (FieldDescriptor field in fields)
                    {
                        switch (field.fieldType)
                        {
                            case 'N':  // Number
                                // If you port this to .NET 2.0, use the Decimal.TryParse method
                                number = Encoding.ASCII.GetString(recReader.ReadBytes(field.fieldLen));

                                if (as_text)
                                {
                                    row[field.fieldName] = number;
                                }
                                else
                                {

                                    if (IsNumber(number))
                                    {
                                        if (number.IndexOf(".") > -1)
                                        {
                                            row[field.fieldName] = decimal.Parse(number);
                                        }
                                        else
                                        {
                                            row[field.fieldName] = int.Parse(number);
                                        }
                                    }
                                    else
                                    {
                                        row[field.fieldName] = 0;
                                    }
                                }

                                break;

                            case 'C': // String
                                row[field.fieldName] = Encoding.ASCII.GetString(recReader.ReadBytes(field.fieldLen));
                                break;

                            case 'D': // Date (YYYYMMDD)

                                year = Encoding.ASCII.GetString(recReader.ReadBytes(4));
                                month = Encoding.ASCII.GetString(recReader.ReadBytes(2));
                                day = Encoding.ASCII.GetString(recReader.ReadBytes(2));

                                if (as_text)
                                {
                                    row[field.fieldName] = month + "/" + day + "/" + year;
                                }
                                else
                                {

                                    row[field.fieldName] = System.DBNull.Value;
                                    try
                                    {
                                        if (IsNumber(year) && IsNumber(month) && IsNumber(day))
                                        {
                                            if ((Int32.Parse(year) > 1900))
                                            {
                                                row[field.fieldName] = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
                                            }
                                        }
                                    }
                                    catch
                                    { }
                                }

                                break;

                            case 'L': // Boolean (Y/N)
                                if ('Y' == recReader.ReadByte())
                                {
                                    if( as_text )
                                        row[field.fieldName] = "1";
                                    else
                                        row[field.fieldName] = true;
                                }
                                else
                                {
                                    if (as_text)
                                        row[field.fieldName] = "0";
                                    else
                                        row[field.fieldName] = false;
                                }

                                break;

                            case 'F':
                                number = Encoding.ASCII.GetString(recReader.ReadBytes(field.fieldLen));
                                if (as_text)
                                {
                                    row[field.fieldName] = number;
                                }
                                else
                                {
                                    if (IsNumber(number))
                                    {
                                        row[field.fieldName] = double.Parse(number);
                                    }
                                }
                                break;
                        }
                    }

                    recReader.Close();
                    dt.Rows.Add(row);
                }
            }

            catch
            {
                throw;
            }
            finally
            {
                if (null != br)
                {
                    br.Close();
                }
            }

            return dt;
        }

        public static DataTable ReadDBFI(string dbfFile, bool as_text)
        {
            DataTable dt = new DataTable();
            BinaryReader recReader;
            string number;
            string year;
            string month;
            string day;
            DataRow row;

            int RecordLength = 0;

            // If there isn't even a file, just return an empty DataTable
            if ((false == File.Exists(dbfFile)))
            {
                return dt;
            }

            BinaryReader br = null;
            try
            {
                // Read the header into a buffer
                br = new BinaryReader(File.OpenRead(dbfFile));
                byte[] buffer = br.ReadBytes(34);

                //RecordLength = (int)buffer[3];

                // Read in all the field descriptors. Per the spec, 13 (0D) marks the end of the field descriptors
                ArrayList fields = new ArrayList();
                while ((13 != br.PeekChar()))
                {
                    buffer = br.ReadBytes(Marshal.SizeOf(typeof(FieldDescriptor)));
                    GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                    fields.Add((FieldDescriptor)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(FieldDescriptor)));
                    handle.Free();

                    //mis-formatted files add up here
                    if (fields.Count > 8000)
                    {
                        if (null != br)
                        {
                            br.Close();
                        }

                        return dt;
                    }
                }

                // Read in the first row of records, we need this to help determine column types below
                //((FileStream)br.BaseStream).Seek(header.headerLen + 1, SeekOrigin.Begin);
                //buffer = br.ReadBytes(header.recordLen);
                //recReader = new BinaryReader(new MemoryStream(buffer));

                Byte xb = br.ReadByte();  //pass the 0D

                // Create the columns in our new DataTable
                DataColumn col = null;
                
                foreach (FieldDescriptor field in fields)
                {
                    //number = Encoding.ASCII.GetString(br.ReadBytes(field.fieldLen));
                    if (as_text)
                    {
                        col = new DataColumn(field.fieldName, typeof(string));
                    }
                    else
                    {
                        switch (field.fieldType)
                        {
                            case 'N':
                                //if (number.IndexOf(".") > -1)
                                //{
                                    col = new DataColumn(field.fieldName, typeof(decimal));
                                //}
                                //else
                                //{
                                //    col = new DataColumn(field.fieldName, typeof(int));
                                //}
                                break;
                            case 'C':
                                col = new DataColumn(field.fieldName, typeof(string));
                                break;
                            case 'D':
                                col = new DataColumn(field.fieldName, typeof(DateTime));
                                break;
                            case 'L':
                                col = new DataColumn(field.fieldName, typeof(bool));
                                break;
                            case 'F':
                                col = new DataColumn(field.fieldName, typeof(Double));
                                break;
                        }
                    }
                    dt.Columns.Add(col);
                    RecordLength += field.fieldLen;
                }

                // Skip past the end of the header. 
                //((FileStream)br.BaseStream).Seek(header.headerLen, SeekOrigin.Begin);

                RecordLength += 1;

                // Read in all the records
                //for (int counter = 0; counter <= header.numRecords - 1; counter++)
                while (26 != br.PeekChar() && -1 != br.PeekChar())
                {
                    // First we'll read the entire record into a buffer and then read each field from the buffer
                    // This helps account for any extra space at the end of each record and probably performs better
                    buffer = br.ReadBytes(RecordLength);
                    recReader = new BinaryReader(new MemoryStream(buffer));

                    // All dbf field records begin with a deleted flag field. Deleted - 0x2A (asterisk) else 0x20 (space)
                    if (recReader.ReadChar() == '*')
                    {
                        continue;
                    }

                    // Loop through each field in a record
                    row = dt.NewRow();
                    foreach (FieldDescriptor field in fields)
                    {
                        switch (field.fieldType)
                        {
                            case 'N':  // Number
                                // If you port this to .NET 2.0, use the Decimal.TryParse method
                                number = Encoding.ASCII.GetString(recReader.ReadBytes(field.fieldLen)).Replace('\0', ' ');

                                if (number.IndexOf("..") > -1)  //this is a total hack because of the weird double decimal dots on some files
                                {
                                    if (recReader.PeekChar() == -1)  //the bad decimal is the last field
                                        number += br.ReadChar().ToString();
                                    else
                                    {
                                        number += recReader.ReadChar().ToString().Replace('\0', ' ');
                                        switch ((int)br.PeekChar())  //this is messed up; sometimes the .. needs to be compensated for in the main stream, sometimes not
                                        {
                                            case -1:
                                            case ' ':
                                                break;
                                            default:
                                                Byte xd = br.ReadByte();  //skip
                                                break;
                                        }
                                    }
                                    number = number.Replace("..", ".");
                                }

                                if (as_text)
                                {
                                    row[field.fieldName] = number;
                                }
                                else
                                {

                                    if (IsNumber(number))
                                    {
                                        if (number.IndexOf(".") > -1)
                                        {
                                            row[field.fieldName] = decimal.Parse(number);
                                        }
                                        else
                                        {
                                            row[field.fieldName] = int.Parse(number);
                                        }
                                    }
                                    else
                                    {
                                        row[field.fieldName] = 0;
                                    }
                                }

                                break;

                            case 'C': // String
                                row[field.fieldName] = Encoding.ASCII.GetString(recReader.ReadBytes(field.fieldLen)).Replace('\0', ' ').Trim();
                                break;

                            case 'D': // Date (YYYYMMDD)

                                year = Encoding.ASCII.GetString(recReader.ReadBytes(4)).Replace('\0', ' ');
                                month = Encoding.ASCII.GetString(recReader.ReadBytes(2)).Replace('\0', ' ');
                                day = Encoding.ASCII.GetString(recReader.ReadBytes(2)).Replace('\0', ' ');

                                if (as_text)
                                {
                                    row[field.fieldName] = month + "/" + day + "/" + year;
                                }
                                else
                                {

                                    row[field.fieldName] = System.DBNull.Value;
                                    try
                                    {
                                        if (IsNumber(year) && IsNumber(month) && IsNumber(day))
                                        {
                                            if ((Int32.Parse(year) > 1900))
                                            {
                                                row[field.fieldName] = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
                                            }
                                        }
                                    }
                                    catch
                                    { }
                                }

                                break;

                            case 'L': // Boolean (Y/N)
                                if ('Y' == recReader.ReadByte())
                                {
                                    if (as_text)
                                        row[field.fieldName] = "1";
                                    else
                                        row[field.fieldName] = true;
                                }
                                else
                                {
                                    if (as_text)
                                        row[field.fieldName] = "0";
                                    else
                                        row[field.fieldName] = false;
                                }

                                break;

                            case 'F':
                                number = Encoding.ASCII.GetString(recReader.ReadBytes(field.fieldLen)).Replace('\0', ' ');

                                //same as above
                                if (number.IndexOf("..") > -1)  //this is a total hack because of the weird double decimal dots on some files
                                {
                                    if (recReader.PeekChar() == -1)  //the bad decimal is the last field
                                        number += br.ReadChar().ToString().Replace('\0', ' ');
                                    else
                                    {
                                        number += recReader.ReadChar().ToString().Replace('\0', ' ');
                                        br.ReadByte();  //skip
                                    }
                                    number = number.Replace("..", ".");
                                }


                                if (as_text)
                                {
                                    row[field.fieldName] = number;
                                }
                                else
                                {
                                    if (IsNumber(number))
                                    {
                                        row[field.fieldName] = double.Parse(number);
                                    }
                                }
                                break;
                        }
                    }

                    recReader.Close();
                    dt.Rows.Add(row);

                    if (dt.Rows.Count == 26720)
                    {
                        int tp = 0;
                    }
                }
            }

            catch
            {
                throw;
            }
            finally
            {
                if (null != br)
                {
                    br.Close();
                }
            }

            return dt;
        }


        /// <summary>
        /// Simple function to test is a string can be parsed. There may be a better way, but this works
        /// If you port this to .NET 2.0, use the new TryParse methods instead of this
        /// </summary>
        /// <param name="number">string to test for parsing</param>
        /// <returns>true if string can be parsed</returns>
        public static bool IsNumber(string numberString)
        {
            char[] numbers = numberString.ToCharArray();

            foreach (char number in numbers)
            {
                if ((number < 48 || number > 57) && number != 46 && number != 32)
                {
                    return false;
                }
            }

            return true;
        }
    }
}