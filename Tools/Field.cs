using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tools.Database
{
    public class Field
    {
        public String Name = "";
        public FieldType Type;
        public int Length = 0;
        public bool Required = false;
        public bool Unique = false;
        public ValueUse ValueUse = ValueUse.Any;

        public Field(String name) : this(name, FieldType.String)
        {
        }

        public Field(String name, FieldType type) : this(name, type, 0)
        {

        }
        public Field(String name, FieldType type, int length)
        {
            Name = name;
            Type = type;
            Length = length;
        }
        public Field(DataColumn dc)
        {
            Name = dc.ColumnName;
            Length = dc.MaxLength;
            switch (dc.DataType.ToString())
            {
                case "System.String":
                    if (Length > -1 && Length <= 4096)
                        Type = FieldType.String;
                    else
                        Type = FieldType.Text;
                    break;
                case "System.Int16":
                case "System.Int32":
                    Type = FieldType.Int32;
                    break;
                case "System.Int64":
                    Type = FieldType.Int64;
                    break;
                case "System.DateTime":
                    Type = FieldType.DateTime;
                    break;
                case "System.Boolean":
                    Type = FieldType.Boolean;
                    break;
                case "System.Double":
                case "System.Decimal":
                    Type = FieldType.Double;
                    break;
                default:
                    Type = FieldType.String;
                    break;
            }
        }
        public Field(DataColumn dc, int length)
        {
            Name = dc.ColumnName;
            Length = length;
            switch (dc.DataType.ToString())
            {
                case "System.String":
                    if (Length > -1 && Length <= 4096)
                        Type = FieldType.String;
                    else
                        Type = FieldType.Text;
                    if (Length == 0)
                        Length = 4096;
                    break;
                case "System.Int16":
                case "System.Int32":
                    Type = FieldType.Int32;
                    break;
                case "System.Int64":
                    Type = FieldType.Int64;
                    break;
                case "System.DateTime":
                    Type = FieldType.DateTime;
                    break;
                case "System.Boolean":
                    Type = FieldType.Boolean;
                    break;
                case "System.Double":
                case "System.Decimal":
                    Type = FieldType.Double;
                    break;
                default:
                    Type = FieldType.String;
                    break;
            }
        }

        public override string ToString()
        {
            return Name + " (" + Type.ToString() + ")";
        }
    }

    public class FieldValue : Field
    {
        public Object Value;
        public FieldValue(String name, FieldType type, int length, Object val) : base(name, type, length)
        {
            Value = val;
        }
        public bool NullIs
        {
            get
            {
                return (Value == null || Value == DBNull.Value);
            }
        }
    }

    public enum ValueUse
    {
        Any,
        Ignore,  //for reporting
        Email,
        Phone,
        Url,
        List,
        PersonName,
        FirstName,
        LastName,
        IPAddress,
        Password,
        //numbers
        UnitMoney,
        TotalMoney,
        Quantity,
        Count,
        Percentage,
        DateOnly,
        TimeOnly,
        DateTime,
    }

}
