using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class Query
    {
        public virtual bool Matches(Item x)
        {
            return true;
        }

        public int Limit = 0;

        public virtual String Caption
        {
            get
            {
                return "Query";
            }
        }

        public String Uid = Tools.Strings.GetNewID();
        public QueryTable TableMain;
        public List<QueryField> Fields = new List<QueryField>();
        public List<QueryOrder> OrderBy = new List<QueryOrder>();
        public List<QueryField> GroupBy = new List<QueryField>();
        //public Query Where;
        //public String Where;
        public Expression Where;
        
        public virtual String WhereRender(Context x, IItems items, ExpressionBuilder b)
        {
            if (Where == null)
                return "";

            //if (Where == "")
            //    return "";

            Where.Render(x, items, b);
            return b.Result;

            //if (items == null)
            //    return Where;

            //String ret = Where;
            //switch (items.CountGet(x))
            //{
            //    case 0:
            //        return ret;
            //    case 1:
            //        ret = ret.Replace("<ItemId>", items.ItemIdFirstGet(x));
            //        break;
            //}
            //return ret.Replace("<ItemIds>", Tools.Data.GetIn(items.ItemIdsList(x)));
        }
    }

    public class QueryClass : Query
    {
        public String ClassId = "";

        public QueryClass(String classid)
        {
            ClassId = classid;
            TableMain = new QueryTable(classid);
        }

        public override bool Matches(Item x)
        {
            return x.ClassId == ClassId;
        }
    }

    public class QueryRef : QueryClass
    {
        public String ClassIdFrom;
        public String ClassIdTo;

        public QueryRef(String classid_from, String classid_to, Expression where) : base(classid_to)
        {
            ClassIdFrom = classid_from;
            ClassIdTo = classid_to;
            //RefName = name;
            Where = where;
        }
    }

    public class QueryItem : QueryClass
    {
        public QueryItem(IItem item) : base(item.ClassId)
        {
            Where = new ExpressionBinaryOperator(new ExpressionIdentifier("unique_id"), BinaryOperatorType.Equality, new ExpressionLiteralString(item.Uid));
        }
    }

    public class QueryStringList : Query
    {

    }

    public class QueryTable
    {
        public String Name;
        public String Alias;

        public QueryTable(String name) : this(name, name)
        {
        }

        public QueryTable(String name, String alias)
        {
            Name = name;
            Alias = alias;
        }
    }

    //public class QueryJoin
    //{
    //    public QueryTable TheTable;
    //    public Query TheOn;
    //}

    public class QueryOrder
    {
        public QueryField TheField;
        public bool Desc = false;

        public QueryOrder(QueryField field)
        {
            TheField = field;
        }
    }

    public class QueryField
    {
        public String Name;
        public String Alias;
        public String Table;

        public QueryField(String name)
            : this(name, name, "")
        {

        }

        public QueryField(String name, String alias, String table)
        {
            Name = name;
            Alias = alias;
            Table = table;
        }

        public String NameFull
        {
            get
            {
                if (Tools.Strings.StrExt(Table))
                    return Table + "." + Name;
                else
                    return Name;
            }
        }

        public String NameFullAlias
        {
            get
            {
                String ret = NameFull;
                if (Tools.Strings.StrExt(Alias))
                    ret += " as [" + Alias + "]";
                return ret;
            }
        }
    }



    //Logic

    public class ExpressionBuilder
    {
        public StringBuilder sb = new StringBuilder();
        public void Add(String s)
        {
            sb.Append(s);
        }

        public void BinaryOperatorWrite(BinaryOperatorType op)
        {
            switch (op)
            {
                case BinaryOperatorType.Equality:
                    Add(" = ");
                    break;
                case BinaryOperatorType.And:
                    Add(" and ");
                    break;
            }
        }

        public virtual void AddFormatString(String s)
        {
            Add(s);
        }

        public String Result
        {
            get
            {
                return sb.ToString();
            }
        }

        public virtual void AddFieldUid()
        {
            Add("unique_id");
        }
    }

    public class Expression
    {
        public virtual void Render(Context x, IItems items, ExpressionBuilder b)
        {
        }
    }

    public class ExpressionBinaryOperator : Expression
    {
        public Expression First;
        public BinaryOperatorType TheOperator;
        public Expression Second;

        public ExpressionBinaryOperator(Expression first, BinaryOperatorType op, Expression second)
        {
            First = first;
            TheOperator = op;
            Second = second;
        }

        public override void Render(Context x, IItems items, ExpressionBuilder b)
        {
            base.Render(x, items, b);

            switch (TheOperator)
            {
                case BinaryOperatorType.And:
                    b.Add("( ");
                    break;
            }

            First.Render(x, items, b);
            b.BinaryOperatorWrite(TheOperator);
            Second.Render(x, items, b);

            switch (TheOperator)
            {
                case BinaryOperatorType.And:
                    b.Add(" )");
                    break;
            }
        }
    }

    public class ExpressionIdentifier : Expression
    {
        public String Identifier;
        public ExpressionIdentifier(String ident)
        {
            Identifier = ident;
        }

        public override void Render(Context x, IItems items, ExpressionBuilder b)
        {
            base.Render(x, items, b);
            b.Add(Identifier);
        }
    }

    public class ExpressionIdentifierStringIsNull : ExpressionIdentifier
    {
        public ExpressionIdentifierStringIsNull(String ident) : base(ident)
        {
        }

        public override void Render(Context x, IItems items, ExpressionBuilder b)
        {
            b.Add("isnull(");
            base.Render(x, items, b);
            b.Add(", '')");
        }
    }

    public class ExpressionItemValue : Expression
    {
        public String ValueName;
        public ExpressionItemValue(String valueName)
        {
            ValueName = valueName;
        }
    }

    public class ExpressionItemRefSingleId : Expression
    {
        String VarName;
        public ExpressionItemRefSingleId(String varName)
        {
            VarName = varName;
        }

        public override void Render(Context x, IItems items, ExpressionBuilder b)
        {
            base.Render(x, items, b);
            IItem i = items.FirstGet(x);
            IVarRefSingle single = ((IVarRefSingle)i.VarGetByName(VarName));

            if (single == null)
            {
                x.TheLeader.Error("Missing var: " + VarName);
                return;
            }
            b.AddFormatString(single.ReferenceId);
        }
    }

    public class ExpressionItemUid : Expression
    {
        public override void Render(Context x, IItems items, ExpressionBuilder b)
        {
            base.Render(x, items, b);
            b.AddFormatString(items.ItemIdFirstGet(x));
        }
    }
    

    public class ExpressionLiteralString : Expression
    {
        public String LiteralValue;
        public ExpressionLiteralString(String val)
        {
            LiteralValue = val;
        }

        public override void Render(Context x, IItems items, ExpressionBuilder b)
        {
            base.Render(x, items, b);
            b.AddFormatString(LiteralValue);
        }
    }

    public class ExpressionFieldUid : Expression
    {
        public override void Render(Context x, IItems items, ExpressionBuilder b)
        {
            base.Render(x, items, b);
            b.AddFieldUid();
        }
    }

    public enum BinaryOperatorType
    {
        None,

        /// <summary>'&amp;' in C#, 'And' in VB.</summary>
        BitwiseAnd,
        /// <summary>'|' in C#, 'Or' in VB.</summary>
        BitwiseOr,
        /// <summary>'&amp;&amp;' in C#, 'AndAlso' in VB.</summary>
        And,
        /// <summary>'||' in C#, 'OrElse' in VB.</summary>
        Or,
        /// <summary>'^' in C#, 'Xor' in VB.</summary>
        ExclusiveOr,

        /// <summary>&gt;</summary>
        GreaterThan,
        /// <summary>&gt;=</summary>
        GreaterThanOrEqual,
        /// <summary>'==' in C#, '=' in VB.</summary>
        Equality,
        /// <summary>'!=' in C#, '&lt;&gt;' in VB.</summary>
        InEquality,
        /// <summary>&lt;</summary>
        LessThan,
        /// <summary>&lt;=</summary>
        LessThanOrEqual,

        /// <summary>+</summary>
        Add,
        /// <summary>-</summary>
        Subtract,
        /// <summary>*</summary>
        Multiply,
        /// <summary>/</summary>
        Divide,
        /// <summary>'%' in C#, 'Mod' in VB.</summary>
        Modulus,
        /// <summary>VB-only: \</summary>
        DivideInteger,
        /// <summary>VB-only: ^</summary>
        Power,
        /// <summary>VB-only: &amp;</summary>
        Concat,

        /// <summary>C#: &lt;&lt;</summary>
        ShiftLeft,
        /// <summary>C#: &gt;&gt;</summary>
        ShiftRight,
        /// <summary>VB-only: Is</summary>
        ReferenceEquality,
        /// <summary>VB-only: IsNot</summary>
        ReferenceInequality,

        /// <summary>VB-only: Like</summary>
        Like,
        /// <summary>C#: ??</summary>
        NullCoalescing,
    }
}
