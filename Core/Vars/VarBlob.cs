using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;

using Core;

namespace Core
{
    public class VarBlob : VarVal
    {
        public VarBlob(IItem parent, CoreVarAttribute attr)
            : base(parent, attr)
        {
        }

        public VarBlob(IItem parent, CoreVarAttribute attr, String val)
            : this(parent, attr)
        {
            m_Value = val;
        }

        ~VarBlob()
        {
            Thumbnail = null;
            BlobBytes = null;
        }

        public override String ValueString
        {
            get
            {
                if (Value == null)
                    return "";
                else
                    return "Binary Field";
            }
        }

        public override string ToString()
        {
            return "Binary Field";
        }

        protected override object Default
        {
            get
            {
                return null;
            }
        }

        public override object ValueFromString(string s)
        {
            return s;
        }

        protected override bool ValueAcceptable(Context x, string v, ref string message)
        {
            if (!base.ValueAcceptable(x, v, ref message))
                return false;

            if (v == null)
            {
                message = "Value cannot be null";
                return false;
            }
            return true;
        }

        public bool Initialized = false;

        public void Init(Context x)
        {
            DataSql data = (DataSql)x.TheData;
            BlobBytes = data.TheConnection.GetBlob(Parent.ClassId, TheAttributeBlob.BlobDataFieldName, "unique_id = '" + Parent.Uid + "'");

            Byte[] bytes = data.TheConnection.GetBlob(Parent.ClassId, TheAttributeBlob.BlobThumbFieldName, "unique_id = '" + Parent.Uid + "'");
            if (bytes != null && bytes.Length > 0)
            {
                MemoryStream ms = new MemoryStream(bytes);
                Thumbnail = Image.FromStream(ms);
                ms.Close();
                ms.Dispose();
            }
            else
                Thumbnail = null;

            Extension = data.TheConnection.ScalarString("select " + TheAttributeBlob.BlobExtensionFieldName + " from " + Parent.ClassId + " where " + data.UidField + " = '" + data.TheConnection.SyntaxFilter(Parent.Uid) + "'");

            Initialized = true;
        }

        public void SetFromFile(Context x, String fileName)
        {
            DataSql data = (DataSql)x.TheData;

            BlobBytes = File.ReadAllBytes(fileName);
            data.TheConnection.SetBlob(Parent.ClassId, TheAttributeBlob.BlobDataFieldName, "unique_id = '" + Parent.Uid + "'", BlobBytes);

            if (Tools.Picture.IsPictureFile(fileName))
            {
                Image i = Image.FromFile(fileName);
                Thumbnail = Tools.Picture.GetThumbnail(i, 64, 64);
                i.Dispose();
                i = null;
            }
            else
            {
                Icon icon = Tools.Picture.GetFileIcon(fileName, Tools.Picture.IconSize.Large, false);
                Thumbnail = icon.ToBitmap();
                icon.Dispose();
                icon = null;
            }

            MemoryStream ms = new MemoryStream();
            Thumbnail.Save(ms, System.Drawing.Imaging.ImageFormat.Png);  //what format would be best for this?
            data.TheConnection.SetBlob(Parent.ClassId, TheAttributeBlob.BlobThumbFieldName, "unique_id = '" + Parent.Uid + "'", ms.ToArray());
            ms.Close();
            ms.Dispose();
            ms = null;

            Extension = Path.GetExtension(fileName).ToLower();
            data.TheConnection.Execute("update " + Parent.ClassId + " set " + TheAttributeBlob.BlobExtensionFieldName + " = '" + data.TheConnection.SyntaxFilter(Extension) + "' where " + data.UidField + " = '" + data.TheConnection.SyntaxFilter(Parent.Uid) + "'");
            Initialized = true;
        }

        public String WriteFile(Context x, String folder)
        {
            if (!Initialized)
                Init(x);

            if (BlobBytes == null || BlobBytes.Length == 0)
                throw new Exception("No data");

            String fileName = Tools.Folder.ConditionFolderName(folder) + "Export" + Tools.Strings.GetNewID() + Extension;
            File.WriteAllBytes(fileName, BlobBytes);
            return fileName;
        }

        public Byte[] BlobBytes = null;

        Image m_Thumbnail = null;
        public Image Thumbnail
        {
            get
            {
                return m_Thumbnail;
            }

            set
            {
                if (m_Thumbnail != null)
                {
                    m_Thumbnail.Dispose();
                    m_Thumbnail = null;
                }

                m_Thumbnail = value;
            }
        }

        public String Extension = "";

        public CoreVarValBlobAttribute TheAttributeBlob
        {
            get
            {
                return (CoreVarValBlobAttribute)TheAttribute;
            }
        }

        protected override void FieldValuesAppend(Context x, List<Tools.Database.FieldValue> values, bool changed_only)
        {
            //base.FieldValuesAppend(x, values, changed_only);  //can't call this; blobs are excluded from normal inserts and updates
        }
    }
}
