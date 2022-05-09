using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Xml;

using Core;
using Tools.Database;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class nObject : ItemClassic
    {

        public bool FieldChanged(String prop)
        {
            return VarGetByName(prop).Changed;
        }
        //public nObject(ItemArgs args)
        //    : base(args)
        //{
        //}

        //public nObject(SysNewMethod xs)
        //    : base(new ItemArgs(SysNewMethod.ContextDefault))
        //{
        //}

        //public SysNewMethod xSys
        //{
        //    get
        //    {
        //        return SysNewMethod.ContextDefault.xSys;
        //    }
        //}

        public String unique_id
        {
            get
            {
                return Uid;
            }

            set
            {
                Uid = value;
            }
        }

        public void GridFill(Context x, Core.Display.IGridTarget target, Core.Display.GridColumnSource columnSource)
        {
        }

        //Public Static Functions
        public static void ImportFromDataTable(ContextNM x, nDataTable dt, CoreClassHandle c)
        {
            //has to assume that xSys.xData = dt.xData
            String strFields = "";
            String strValues = "";

            String strUniqueIDField = "unique_id";

            foreach (nDataColumn col in dt.Columns)
            {
                if (col.p != null)
                {
                    if (Tools.Strings.StrExt(col.p.Name))
                    {
                        switch (col.p.Name)
                        {
                            case "unique_id":
                                strUniqueIDField = col.unique_id;
                                break;
                            default:

                                strFields += ", " + col.p.Name;
                                strValues += ", " + col.unique_id;

                                //formalize fields

                                if (col.p.TheFieldType != FieldType.String)
                                    dt.FormalizeFieldType(x, col.unique_id, col.p.TheFieldType);

                                break;
                        }
                    }
                }
            }

            dt.AddField("date_created", "datetime", "getdate()");
            dt.AddField("date_modified", "datetime", "getdate()");

            String strSQL = "insert into " + c.Name + " (unique_id, date_created, date_modified " + strFields + " ) select " + strUniqueIDField + ", date_created, date_modified " + strValues + " from " + dt.TableName + " order by unique_order";
            x.Execute(strSQL);
        }




        //public virtual bool BeforeSave(ContextNM context, ChangeArgs args)
        //{
        //    if (InsertedIs)
        //        throw new Exception("Insert error: " + unique_id);

        //    unique_id = Tools.Strings.GetNewID();
        //    return BeforeSaveWithoutId(context, args);
        //}

        //bool BeforeSaveWithoutId(ContextNM context, ChangeArgs args)
        //{
        //    if (xSys.xData == null)
        //        date_created = DateTime.Now;
        //    else
        //        date_created = xSys.xData.GetServerNow();
        //    date_modified = date_created;
        //    return BeforeUpdate(context, args);
        //}

        //public bool InsertedIs
        //{
        //    get
        //    {
        //        return (unique_id != "");
        //    }
        //}

        //public virtual void AfterSave(ContextNM x, bool inhibitNotify)
        //{
        //    if (!inhibitNotify)
        //        x.xSys.InstanceCountChanged(this.ClassId);
        //}
        //public bool BeforeUpdate(ContextNM context)
        //{
        //    return BeforeUpdate(context, new ChangeArgs());
        //}
        //public virtual bool BeforeUpdate(ContextNM context, ChangeArgs args)        
        //{

        //    return true;
        //}
        //public virtual void AfterUpdate(ContextNM context, bool inhibitNotify)
        //{
        //    if (!inhibitNotify)
        //        context.xSys.InstanceDataChanged(this.ClassId);
        //}
        //public virtual bool ICreate(n_sys s, String strIn)
        //{
        //    if (!Tools.Strings.StrExt(strIn))
        //    {
        //        //return CreateBlank(s);
        //        return false;
        //    }
        //    else
        //    {
        //        if (strIn.Trim().ToLower().StartsWith("select "))
        //        {
        //            return CreateFromSQL(s, strIn);
        //        }
        //        else
        //        {
        //            return CreateFromID(s, strIn);
        //        }
        //    }
        //}
        //public virtual bool CreateBlank(n_sys s)
        //{
        //    xSys = s;
        //    AllVars = new SortedList();
        //    nVar v;
        //    n_prop p;
        //    SortedList l = xSys.CoalescePropsByClass(this.ClassName);
        //    if (l == null)
        //        return true;
        //    foreach (DictionaryEntry d in l)
        //    {
        //        p = (n_prop)d.Value;
        //        switch (p.name.ToLower())
        //        {
        //            case "date_modified":
        //            case "date_created":
        //            case "unique_id":
        //            case "grid_color":
        //            case "icon_index":
        //                break;
        //            default:
        //                v = new nVar(p);
        //                AllVars.Add(v.variable_name, v);
        //                break;
        //        }
        //    }
        //    return true;
        //}
        //public virtual bool Show()
        //{
        //    //frmViewer v = new frmViewer();
        //    //v.Show();
        //    //v.CompleteLoad(xSys, this);
        //    return true;
        //}
        //public virtual bool ICreate(n_sys s, DataRow iRow)
        //{
        //    xSys = s;
        //    try
        //    {
        //        unique_id = (String)nData.NullFilter_String(iRow["unique_id"]);
        //        date_created = (DateTime)nData.NullFilter_DateTime(iRow["date_created"]);
        //        date_modified = (DateTime)nData.NullFilter_DateTime(iRow["date_modified"]);
        //        grid_color = (Int32)iRow["grid_color"];
        //        icon_index = (Int32)iRow["icon_index"];
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    SetClean();
        //    return true;
        //}
        //public virtual String BuildSaveSQL(ContextNM x)
        //{
        //    return BuildSaveSQL(x, false, NewMethod.Enums.RecallType.None, ClassName);
        //}
        //public virtual String BuildSaveSQL(ContextNM x, bool recall, Enums.RecallType t)
        //{
        //    return BuildSaveSQL(x, recall, t, ClassName);
        //}
        //public virtual String BuildSaveSQL(ContextNM x, String strTable)
        //{
        //    return BuildSaveSQL(x, false, NewMethod.Enums.RecallType.None, strTable);
        //}
        //public virtual String BuildSaveSQL(ContextNM x, bool recall, Enums.RecallType t, String strTable)
        //{
        //    nSQL xSQL = new nSQL();
        //    GetSaveSQL(xSQL);
        //    //add the grid color and icon index
        //    xSQL.InsertFields += ", grid_color, icon_index, date_created, date_modified";
        //    xSQL.InsertValues += ", " + grid_color.ToString() + ", " + icon_index.ToString() + ", '" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(date_created) + "', '" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(date_modified) + "'";
        //    if (recall)
        //    {
        //        xSQL.InsertFields += ", recall_date, recall_user_uid, recall_user_name, recall_machine_name, recall_type, recall_uid, recall_version";
        //        //xSQL.InsertValues += ", getdate(), '" + xSys.recall_user_uid + "', '" + nData.SyntaxFilterGeneral(xSys.recall_user_name) + "', '" + nData.SyntaxFilterGeneral(xSys.recall_machine_name) + "', " + ((int)t).ToString() + ", cast(newid() as varchar(50)), '" + n_sys.version_string + "' ";
        //        xSQL.InsertValues += ", getdate(), '" + x.xUser.unique_id + "', '" + nData.SyntaxFilterGeneral(x.xUser.name) + "', '" + nData.SyntaxFilterGeneral(xSys.recall_machine_name) + "', " + ((int)t).ToString() + ", cast(newid() as varchar(50)), '" + n_sys.version_string + "' ";
        //    }
        //    String table_name = strTable;
        //    if (Tools.Strings.StrExt(TableName))
        //        table_name = TableName;
        //    return "insert into " + table_name + " (unique_id " + xSQL.InsertFields + " ) values ('" + unique_id + "' " + xSQL.InsertValues + ")";
        //}
        //public void ISave()
        //{
        //    ISave(SysNewMethod.ContextDefault);
        //}
        //public void ISave(ContextNM context)
        //{
        //    ISave(context, new ChangeArgs(ChangeType.Add));
        //}

        //public virtual void ISave(ContextNM context, ChangeArgs args)
        //{
        //    if (Tools.Strings.StrExt(unique_id))
        //    {
        //        args.TheType = ChangeType.Update;
        //        IUpdate(context, args);
        //        return;
        //    }

        //    BeforeSave(context, args);
        //    ISaveExecute(context, args);
        //}

        ////this is separate so that DataSqlRz can call it after beforesave has already been called previously
        //public void ISaveExecute(ContextNM context, ChangeArgs args)
        //{
        //    context.Execute(BuildSaveSQL(context));

        //    //recall
        //    if (xSys.Recall)
        //        NoticeChanges(context, Enums.RecallType.Insert);
        //    SetClean();
        //    AfterSave(context, args.InhibitNotify);
        //}
        //public void IUpdate()
        //{
        //    IUpdate(SysNewMethod.ContextDefault);
        //}
        //public void IUpdate(ContextNM context)
        //{
        //    IUpdate(context, new ChangeArgs(ChangeType.Update));
        //}
        //public virtual void IUpdate(ContextNM context, ChangeArgs args)
        //{
        //    BeforeUpdate(context, args);
        //    IUpdateExecute(context, args);
        //}

        //public void IUpdateExecute(ContextNM context, ChangeArgs args)
        //{            
        //    if (!IsClean())
        //    {
        //        if (xSys.xData == null)
        //            date_modified = DateTime.Now;
        //        else
        //            date_modified = xSys.xData.GetServerNow();

        //        String s = BuildUpdateSQL();

        //        context.Execute(s);

        //        //recall
        //        if (xSys.Recall)
        //            NoticeChanges(context, Enums.RecallType.Update);
        //        SetClean();
        //        AfterUpdate(context, args.InhibitNotify);
        //    }
        //}

        //public virtual void GetSaveSQL(nSQL xSQL)
        //{
        //    //if (AllVars != null)
        //    //    GetSoftSaveSQL(xSQL);
        //}
        //public virtual void GetSoftSaveSQL(nSQL xSQL)
        //{
        //    StringBuilder sbFields = new StringBuilder();
        //    StringBuilder sbValues = new StringBuilder();
        //    n_prop p;
        //    SortedList props = xSys.CoalescePropsByClass(this.ClassName);
        //    foreach (DictionaryEntry d in props)
        //    {
        //        p = (n_prop)d.Value;
        //        if (!p.IsFramework)
        //        {
        //            sbFields.Append(", " + p.name);
        //        }
        //    }
        //    foreach (DictionaryEntry d in props)
        //    {
        //        p = (n_prop)d.Value;
        //        if (!p.IsFramework)
        //        {
        //            sbValues.Append(", ");
        //            try
        //            {
        //                switch (p.property_type)
        //                {
        //                    case (Int32)FieldType.Int32:
        //                        sbValues.Append(this.IGet(p.name).ToString());
        //                        break;
        //                    case (Int32)FieldType.Int64:
        //                        sbValues.Append(this.IGet(p.name).ToString());
        //                        break;
        //                    case (Int32)FieldType.Double:
        //                        sbValues.Append(this.IGet(p.name).ToString());
        //                        break;
        //                    case (Int32)FieldType.DateTime:
        //                        DateTime td = (DateTime)this.IGet(p.name);
        //                        if (!Tools.Dates.DateExists(td))
        //                        {
        //                            switch (p.name.ToLower())
        //                            {
        //                                case "date_created":
        //                                    this.ISet("date_created", xSys.xData.GetServerNow());
        //                                    break;
        //                                case "date_modified":
        //                                    this.ISet("date_modified", xSys.xData.GetServerNow());
        //                                    break;
        //                                default:
        //                                    this.ISet(p.name, Tools.Dates.GetNullDate());
        //                                    break;
        //                            }
        //                        }
        //                        sbValues.Append("'" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings((DateTime)this.IGet(p.name)) + "'");
        //                        break;
        //                    case (Int32)FieldType.Boolean:
        //                        sbValues.Append(nData.BoolFilter(Convert.ToBoolean(this.IGet(p.name))));
        //                        break;
        //                    default:
        //                        sbValues.Append("'" + xSys.xData.SyntaxFilter((String)this.IGet(p.name)) + "'");
        //                        break;
        //                }
        //            }
        //            catch (Exception)
        //            {
        //            }
        //        }
        //    }
        //    xSQL.InsertFields = sbFields.ToString();
        //    xSQL.InsertValues = sbValues.ToString();
        //}
        public virtual void GetUpdateSQL(nSQL xSQL)
        {
            //if (AllVars != null)
            //    GetSoftUpdateSQL(xSQL);
        }
        //public virtual void GetSoftUpdateSQL(nSQL xSQL)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    n_prop p;
        //    int i = 0;
        //    foreach (DictionaryEntry d in xSys.CoalescePropsByClass(this.ClassName))
        //    {
        //        try
        //        {
        //            p = (n_prop)d.Value;
        //            if (!p.IsFramework)
        //            {
        //                if (this.FieldChanged(p.name))
        //                {
        //                    if (i > 0)
        //                        sb.Append(", ");
        //                    sb.Append(p.name + " = ");
        //                    switch (p.property_type)
        //                    {
        //                        case (Int32)FieldType.Int32:
        //                            sb.Append(this.IGet(p.name).ToString());
        //                            break;
        //                        case (Int32)FieldType.Int64:
        //                            sb.Append(this.IGet(p.name).ToString());
        //                            break;
        //                        case (Int32)FieldType.Double:
        //                            sb.Append(this.IGet(p.name).ToString());
        //                            break;
        //                        case (Int32)NewMethod.Enums.FieldType.Text:
        //                            sb.Append("'" + xSys.xData.SyntaxFilter((String)this.IGet(p.name)) + "'");
        //                            break;
        //                        case (Int32)FieldType.DateTime:
        //                            DateTime td = (DateTime)this.IGet(p.name);
        //                            if (!Tools.Dates.DateExists(td))
        //                            {
        //                                switch (p.name.ToLower())
        //                                {
        //                                    case "date_created":
        //                                        this.ISet("date_created", xSys.xData.GetServerNow());
        //                                        break;
        //                                    case "date_modified":
        //                                        this.ISet("date_modified", xSys.xData.GetServerNow());
        //                                        break;
        //                                    default:
        //                                        this.ISet(p.name, Tools.Dates.NullDate);
        //                                        break;
        //                                }
        //                            }
        //                            sb.Append("'" + this.IGet(p.name).ToString() + "'");
        //                            break;
        //                        case (Int32)FieldType.Boolean:
        //                            sb.Append(nData.BoolFilter((Boolean)this.IGet(p.name)));
        //                            break;
        //                        default:
        //                            sb.Append("'" + xSys.xData.SyntaxFilter((String)this.IGet(p.name)) + "'");
        //                            break;
        //                    }
        //                    i++;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            int x = 0;
        //        }
        //    }
        //    xSQL.UpdateString = sb.ToString();
        //}
        //public virtual void IDelete()
        //{
        //    IDelete(SysNewMethod.ContextDefault);
        //}
        //public virtual void IDelete(ContextNM context)
        //{
        //    IDelete(context, false);
        //}
        //public virtual void IDelete(ContextNM context, bool bInhibitNotify)
        //{
        //    if (!CanDelete(context))
        //        throw new Exception("Delete is not permitted at this point");

        //    context.Execute(DeleteSql(context));

        //    if (xSys.Recall)
        //        NoticeChanges(context, Enums.RecallType.Delete);

        //    isdel = true;

        //    //if (!bInhibitNotify)
        //    //    xSys.NotifyClassChange(this.ClassName, true);
        //}

        //public virtual int GetGridColor()
        //{
        //    return grid_color;
        //}
        //public virtual String BuildUpdateSQL()
        //{
        //    nSQL xSQL = new nSQL();
        //    GetUpdateSQL(xSQL);
        //    if (Tools.Strings.StrExt(xSQL.UpdateString))
        //        xSQL.UpdateString += ", ";
        //    xSQL.UpdateString += "grid_color = " + grid_color.ToString() + ", icon_index = " + icon_index.ToString() + ", date_modified = '" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(date_modified) + "'";
        //    String table_name = ClassName;
        //    if (Tools.Strings.StrExt(TableName))
        //        table_name = TableName;
        //    return "update " + table_name + " set " + xSQL.UpdateString + " where unique_id = '" + unique_id + "'";
        //}
        //public virtual void SetChanged(bool changed)
        //{
        //    b_date_created = changed;
        //    b_date_modified = changed;
        //    b_grid_color = changed;
        //    b_icon_index = changed;
        //    //if (AllVars == null)
        //    //    return;
        //    //nVar v;
        //    //foreach (DictionaryEntry d in AllVars)
        //    //{
        //    //    v = (nVar)d.Value;
        //    //    v.b = changed;
        //    //}
        //}

        //public virtual bool IsClean()
        //{
        //    if (b_grid_color)
        //        return false;
        //    if (b_icon_index)
        //        return false;
        //    return true;
        //}
        //public virtual bool FieldChanged(string strField)
        //{
        //    switch (strField.ToLower())
        //    {
        //        case "date_created":
        //            return b_date_created;
        //        case "date_modified":
        //            return b_date_modified;
        //        case "grid_color":
        //            return b_grid_color;
        //        case "icon_index":
        //            return b_icon_index;
        //        default:
        //            break;
        //    }
        //    return false;
        //}
        //public void ISave_PreserveID(ContextNM context)
        //{
        //    ISave_PreserveID(context, new ChangeArgs());
        //}
        //public virtual void ISave_PreserveID(ContextNM context, ChangeArgs args)
        //{
        //    if (!Tools.Strings.StrExt(unique_id))
        //    {
        //        this.ISave();
        //        return;
        //    }

        //    BeforeSaveWithoutId(context, args);

        //    String s = this.BuildSaveSQL(context);
        //    bool b = false;
        //    if (args.Silent)
        //        b = xSys.xData.Execute(s, false, true);
        //    else
        //        context.Execute(s);
        //}
        //public virtual bool ISave_ToAlternateData(ContextNM x, nData d)
        //{
        //    return ISave_ToAlternateData(x, d, ClassName, false);
        //}
        //public virtual bool ISave_ToAlternateData(ContextNM x, nData d, String strTable)
        //{
        //    return ISave_ToAlternateData(x, d, strTable, false);
        //}
        //public virtual bool ISave_ToAlternateData(ContextNM x, nData d, String strTable, bool preserve_id)
        //{
        //    if (!preserve_id)
        //        unique_id = Tools.Strings.GetNewID();
        //    BeforeSaveWithoutId(SysNewMethod.ContextDefault, new ChangeArgs());
        //    String s = this.BuildSaveSQL(x, strTable);
        //    return d.Execute(s);
        //}
        //public virtual bool IUpdate_ToAlternateData(nData d)
        //{
        //    return IUpdate_ToAlternateData(d, ClassName);
        //}
        //public virtual bool IUpdate_ToAlternateData(nData d, String strTable)
        //{
        //    BeforeUpdate(SysNewMethod.ContextDefault, new ChangeArgs());
        //    date_modified = System.DateTime.Now;
        //    String s = this.BuildUpdateSQL();
        //    if (!Tools.Strings.StrCmp(strTable, ClassName))
        //        s = nTools.Replace(s, "update " + ClassName + " ", "update " + strTable + " ");
        //    return d.Execute(s);
        //}
        public virtual void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                case "":
                    return;
                case "note":
                    SendNote((ContextNM)args.TheContext);
                    args.Handled = true;
                    break;
                case "viewchangehistory":
                    ViewChangeHistory((ContextNM)args.TheContext);
                    args.Handled = true;
                    break;
                default:
                    return;
            }

        }
        public virtual String AssociateWithHTML(String strText)
        {
            return AssociateWithHTML(strText, "");
        }
        public virtual String AssociateWithHTML(String strText, String strPrefix)
        {
            String strOut;
            String strValue;
            String strData;
            if (!Tools.Strings.StrExt(strPrefix))
            {
                strPrefix = ClassId;
            }
            strOut = strText;

            strOut = nTools.StrReplace(strOut, "<Now>", nTools.DateFormat(System.DateTime.Now));

            foreach (VarVal p in VarValsGet())
            {
                try
                {
                    switch (p.TheValAttribute.TheFieldType)
                    {
                        case FieldType.Double:
                            strValue = nTools.MoneyFormat_2_6((Double)IGet(p.Name));
                            break;
                        case FieldType.DateTime:
                            strValue = nTools.DateFormat((DateTime)IGet(p.Name));
                            break;
                        case FieldType.Boolean:
                            strValue = Tools.Strings.YesBlankFilter((Boolean)IGet(p.Name));
                            if (strValue == "")
                                strValue = "&nbsp;";
                            break;
                        default:
                            strValue = Convert.ToString(IGet(p.Name));
                            if (!Tools.Strings.HasString(strValue, "<br>"))
                                strValue = nTools.StrReplace(strValue, "\r\n", "<br>");

                            if (Tools.Strings.StrCmp(p.Name, "companyname"))
                            {
                                strValue = Tools.Strings.ParseDelimit(strValue, "[", 1).Trim();
                            }
                            break;
                    }
                    strOut = nTools.StrReplace(strOut, "<" + strPrefix + "." + p.Name + ">", strValue);
                    strOut = nTools.StrReplace(strOut, "&lt;" + strPrefix + "." + p.Name + "&gt;", strValue);
                    strOut = nTools.StrReplace(strOut, "<" + p.Name + ">", strValue);

                    //added 2010_12_18 so the preview with the tags shows the tags
                    strOut = nTools.StrReplace(strOut, "[" + strPrefix + "." + p.Name + "]", strValue);
                    strOut = nTools.StrReplace(strOut, "[" + p.Name + "]", strValue);

                    if (strPrefix.ToLower().StartsWith("ordhed_"))
                    {
                        strOut = nTools.StrReplace(strOut, "<ordhed." + p.Name + ">", strValue);
                        strOut = nTools.StrReplace(strOut, "&lt;ordhed." + p.Name + "&gt;", strValue);
                    }
                    if (strPrefix.ToLower().StartsWith("orddet_"))
                    {
                        strOut = nTools.StrReplace(strOut, "<orddet." + p.Name + ">", strValue);
                        strOut = nTools.StrReplace(strOut, "&lt;orddet." + p.Name + "&gt;", strValue);
                    }
                }
                catch (Exception ex)
                {
                    String err = ex.Message;
                }
            }
            return strOut;
        }
        //public virtual void Note()
        //{
        //    throw new NotImplementedException("notes system");
        //}
        //public virtual void ISave_Async()
        //{
        //    Thread t = new Thread(new ThreadStart(ISave_Async_Thread));
        //    t.ApartmentState = ApartmentState.STA;
        //    t.IsBackground = true;
        //    t.Start();
        //}
        //public virtual int CalcColor()
        //{
        //    return grid_color;
        //}

        public virtual bool CanBeViewedBy(ContextNM context)
        {
            return CanBeViewedBy(context, new ShowArgs());
        }

        public virtual bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return true;
        }

        //KT Allow Company Owners to view past orders that aren't in their name
        public virtual bool CanBeViewedBy(ContextNM context, ShowArgs args, string CompanyOwnerUID)
        {
            return true;
        }

        public virtual bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return true;
        }

        //wtf was this?
        //public virtual void ShowCompanyDetails()
        //{

        //}
        //Protected Virtual Functions
        //protected virtual bool CreateFromSQL(n_sys s, String strIn)
        //{
        //    xSys = s;
        //    DataTable t = xSys.xData.Select(strIn);
        //    if (t == null)
        //        return false;
        //    return ICreate(s, t.Rows[0]);
        //}
        //protected virtual bool CreateFromID(n_sys s, String strIn)
        //{
        //    xSys = s;
        //    return CreateFromSQL(s, "select * from " + this.ClassName + " where unique_id = '" + strIn + "'");
        //}
        //Public Override Functions
        //public override bool ISet(String strProperty, Object value)
        //{
        //    switch (strProperty.ToLower())
        //    {
        //        case "unique_id":
        //            unique_id = (String)value;
        //            return true;
        //        case "date_created":
        //            date_created = (DateTime)value;
        //            return true;
        //        case "date_modified":
        //            date_modified = (DateTime)value;
        //            return true;
        //        case "icon_index":
        //            icon_index = (Int32)value;
        //            return true;
        //        case "grid_color":
        //            grid_color = (Int32)value;
        //            return true;
        //    }
        //    //if (AllVars == null)
        //        return true;
        //    //return base.ISet(strProperty, value);
        //}
        //public override Object IGet(String strProperty)
        //{
        //    switch (strProperty.ToLower())
        //    {
        //        case "unique_id":
        //            return unique_id;
        //        case "date_created":
        //            return date_created;
        //        case "date_modified":
        //            return date_modified;
        //        case "icon_index":
        //            return icon_index;
        //        case "grid_color":
        //            return grid_color;
        //    }
        //    return base.IGet(strProperty);
        //}
        //Public Functions
        public void NoticeChanges(ContextNM x, Enums.RecallType t)
        {
            String userId = "none";
            String userName = "none";
            if (x.xUser != null)
            {
                userId = x.xUser.Uid;
                userName = x.xUser.name;
            }
            String extraFields = ", recall_date, recall_user_uid, recall_user_name, recall_machine_name, recall_type, recall_uid, recall_version";
            String extraValues = ", getdate(), '" + userId + "', '" + nData.SyntaxFilterGeneral(userName) + "', '" + nData.SyntaxFilterGeneral(x.xSys.RecallMachineName) + "', " + ((int)t).ToString() + ", cast(newid() as varchar(50)), '" + SysNewMethod.version_string + "' ";
            String sql = x.TheData.InsertOneSql(x, this, this.ClassId, extraFields, extraValues);
            x.xSys.RecallConnection.ExecuteAsync(sql, "Historical Change Tracking on " + ClassId, x.xSys.RecallWarnings);
        }
        //public void SetGridColor(int c)
        //{
        //    this.grid_color = c;
        //    xSys.xData.Execute("update " + this.ClassName + " set grid_color = " + Convert.ToString(c) + " where unique_id = '" + this.unique_id + "'");
        //}
        //public void SetIconIndex(int c)
        //{
        //    this.icon_index = c;
        //    xSys.xData.Execute("update " + this.ClassName + " set icon_index = " + Convert.ToString(c) + " where unique_id = '" + this.unique_id + "'");
        //}
        public virtual nObject CloneValues(Context x)
        {
            nObject n = (nObject)x.Item(ClassId);  // xSys.MakeObject(this.ClassName);
            foreach (Var v in VarsGet())  // DictionaryEntry d in xSys.CoalescePropsByClass(this.ClassName))
            {
                n.ISet(v.TheAttribute.Name, this.IGet(v.TheAttribute.Name));
            }
            return n;
        }
        //public nObject CloneWithNewID()
        //{
        //    nObject o = this.Clone();
        //    o.unique_id = "";
        //    return o;
        //}
        public void HandleAction(ContextNM x, String strAction)
        {
            ActArgs args = new ActArgs(strAction);
            args.TheContext = x;
            HandleAction(args);
        }
        //public n_log AddLog(ContextNM x)
        //{
        //    return x.xSys.AddLog(x, this);
        //}
        //public virtual n_log AddLog(ContextNM x, String strText)
        //{
        //    return AddLog(x, strText, false);
        //}
        //public n_log AddLog(ContextNM x, String strText, bool manual)
        //{
        //    n_user u = x.xUser;
        //    if (u == null)
        //        return null;
        //    return AddLog(x, u.unique_id, u.name, strText, manual);
        //}
        //public n_log AddLog(ContextNM x, n_user u, String strText, bool manual)
        //{
        //    return AddLog(x, u.unique_id, u.name, strText, manual);
        //}
        //public n_log AddLog(ContextNM x, String strUserID, String strUserName, String strText, bool manual)
        //{
        //    n_log l = new n_log(xSys);
        //    l.the_n_user_uid = strUserID;
        //    l.user_name = strUserName;
        //    l.machine_name = Environment.MachineName;
        //    l.log_text = strText;
        //    l.object_class = this.ClassName;
        //    l.object_id = this.unique_id;
        //    l.manually_entered = manual;
        //    l.ISave();
        //    return l;
        //}
        //public void ViewLogs(ContextNM x)
        //{
        //    x.xSys.ViewLogs(x, this);
        //}
        public bool ViewChangeHistory(ContextNM x)
        {
            return x.xSys.ViewChangeHistory(x, this);
        }
        public void SendNote(ContextNM context)
        {
            context.xSys.SendNote(context, this);
        }
        public String KeyID
        {
            get
            {
                return ClassId + ":" + unique_id;
            }
        }
        public String GetProblemFields(ContextNM context)
        {
            StringBuilder sb = new StringBuilder();

            CoreClassHandle c = context.TheSys.CoreClassGet(ClassId);
            foreach (CoreVarAttribute p in c.VarsGet())
            {
                this.Changed = false;
                this.ISet(p.Name, this.IGet(p.Name));
                //ChangeArgs args = new ChangeArgs(ChangeType.Update);
                //args.InhibitNotify = true;
                //args.SuppressErrorMessage = true;
                try
                {
                    context.Update(this);
                }
                catch
                {
                    sb.AppendLine(p.Name);
                }
            }
            return sb.ToString();
        }
        //public void SetColor_Conditional()
        //{
        //    int c = CalcColor();
        //    if (grid_color != c)
        //        grid_color = c;
        //}
        //public String GetLogWhere()
        //{
        //    return "object_class = '" + xSys.xData.SyntaxFilter(this.ClassName) + "' and object_id = '" + xSys.xData.SyntaxFilter(this.unique_id) + "'";
        //}
        //public CoreClassHandle GetClass()
        //{
        //    return SysNewMethod.ContextDefault.TheSys.CoreClassGet(ClassId);  // xSys.GetClassByName(ClassName);
        //}
        ////Private Functions
        //private void ISave_Async_Thread()
        //{
        //    ISave();
        //}
        //protected virtual void TellUserTemp(string s, ContextNM x)
        //{
        //    if (x != null)
        //        x.TheLeader.TellTemp(s);
        //}

        public virtual bool CanBeDeletedBy(ContextNM context)
        {
            return CanBeDeletedBy(context, new ShowArgs(ClassId));
        }

        public virtual bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return context.xUser.SuperUser;
        }

        //public n_front GetFront(String strName)
        //{
        //    n_front xf = (n_front)xSys.QtO("n_front", "select * from n_front where link_info = '" + KeyID + "'");
        //    if (xf == null)
        //    {
        //        n_front fo = (n_front)xSys.QtO("n_front", "select * from n_front where name = '" + xSys.xData.SyntaxFilter(strName) + "' and link_info not like '%:%'");
        //        if (fo == null)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            xf = fo.GetInstanceFront(this);
        //        }
        //    }
        //    return xf;
        //}

        public virtual bool Validate(ref String err)
        {
            return true;
        }

        //public virtual bool DeletePossible(ContextNM context, ref String error)
        //{
        //    return true;
        //}

        public virtual void PathStatusUpdate(String caption)
        {

        }

        public virtual String PathDescriptionGet(ContextNM x)
        {
            return "";
        }

        //IItem stuff

        public String Caption
        {
            get
            {
                return ToString();
            }
        }

        //public List<String> ClassIdsList(Context x)
        //{
        //    List<String> ret = new List<string>();
        //    ret.Add(ClassId);
        //    return ret;
        //}

        public void Clear(Context x)
        {

        }

        public void Add(Context x, IItems items)
        {
            throw new NotImplementedException();
        }

        public int CountGet(Context x)
        {
            return 1;
        }

        public IItem FirstGet(Context x)
        {
            return this;
        }

        public List<IItem> AllGet(Context x)
        {
            List<IItem> ret = new List<IItem>();
            ret.Add(this);
            return ret;
        }

        //public bool AbsorbRow(Context x, DataRow r)
        //{
        //    return ICreate(((ContextNM)x).xSys, r);
        //}

        //public virtual Var VarGetByName(String name)
        //{
        //    base.VarGet
        //    return null;
        //}

        //public void ValuesChangedSet(Context x, bool value)
        //{
        //    SetChanged(value);
        //}

        //public void ValuesChangedSetDirect(bool value)
        //{
        //    SetChanged(value);
        //}    




        public bool Compare(ContextNM context, nObject x, ref String result)
        {
            StringBuilder sb = new StringBuilder();
            CoreClassHandle c = context.TheSys.CoreClassGet(ClassId);   // context.xSys.GetClassByName(ClassName);
            if (c == null)
            {
                result = "Class " + ClassId + " not found";
                return false;
            }

            bool b = true;

            //kt 4-25-18Remove vars from PArticular classes : Examples, since we may be setting ShipVia and shippingaccoung via a modal, it won't match what was intially created, and this is expected.


            foreach (CoreVarValAttribute p in c.VarsGet())
            {
                Object v = IGet(p.Name);
                Object vv = x.IGet(p.Name);
                if (!SkipNoMatchVar(c, p))//Some user-provided values will never match the original (by design).  Skip these.
                {


                    if (v == null || v == DBNull.Value)
                    {
                        if (vv == null || vv == DBNull.Value)
                        {
                            //ok
                        }
                        else
                        {
                            sb.AppendLine("Mismatch: " + p.Name + " : Original=null, Match=" + vv.ToString());
                            b = false;
                        }
                    }
                    else
                    {
                        if (vv == null || vv == DBNull.Value)
                        {
                            sb.AppendLine("Mismatch: " + p.Name + " : Original=" + v.ToString() + ", Match=null");
                            b = false;
                        }
                        else
                        {
                            if (v.ToString() == vv.ToString())
                            {

                            }
                            else
                            {
                                sb.AppendLine("Mismatch: " + p.Name + " : Original=" + v.ToString() + ", Match=" + vv.ToString());
                                b = false;
                            }
                        }
                    }
                }
            }
            result = sb.ToString();
            return b;
        }

        private bool SkipNoMatchVar(CoreClassHandle c, CoreVarValAttribute p)
        {//Some user-provided values will never match the original (by design).  Skip these.
            List<string> skipped;
            switch (c.Name)
            {
                case "ordhed_purchase":
                    {
                        skipped = new List<string>() { "shipvia", "shippingaccount" };

                        if (skipped.Contains(p.Name.ToLower()))
                        {
                            return true;
                        }
                        break;
                    }
            }
            return false;
        }

        public override void Inserted(Context x)
        {
            base.Inserted(x);

            if (((ContextNM)x).xSys.Recall)
                NoticeChanges((ContextNM)x, Enums.RecallType.Insert);
        }

        public override void Updated(Context x)
        {
            base.Updated(x);

            if (((ContextNM)x).xSys.Recall)
                NoticeChanges((ContextNM)x, Enums.RecallType.Update);
        }

        public override void Deleted(Context x)
        {
            //this needs to happen before the refs get removed or else
            //after the restore there is no company or agent links.
            //if (((ContextNM)x).xSys.Recall)
            //    NoticeChanges((ContextNM)x, Enums.RecallType.Delete);   //does delete change the item id to something invalid?          
        }

        //List<IWatcher> m_Watchers;
        //public List<IWatcher> WatchersList
        //{
        //    get
        //    {
        //        if (m_Watchers == null)
        //            return new List<IWatcher>();
        //        else
        //            return new List<IWatcher>(m_Watchers);
        //    }
        //}

        //public void WatcherAdd(IWatcher w)
        //{
        //    if (w == null)
        //        return;

        //    if (m_Watchers == null)
        //        m_Watchers = new List<IWatcher>();

        //    if (m_Watchers.Contains(w))
        //        throw new Exception("Duplicate watcher");

        //    m_Watchers.Add(w);
        //}

        //public void WatcherRemove(IWatcher w)
        //{
        //    if (m_Watchers == null)  //maybe raise an error, since this shouldn't happen?
        //    {
        //        //m_Watchers = new List<IWatcher>();
        //    }
        //    else
        //        m_Watchers.Remove(w);
        //}

        public override void Deleting(Context x)
        {
            //this needs to happen before the refs get removed or else
            //after the restore there is no company or agent links.
            if (((ContextNM)x).xSys.Recall)
                NoticeChanges((ContextNM)x, Enums.RecallType.Delete);
            foreach (IVarRef r in VarRefsList)
            {
                try
                {
                    if (r != null)
                        r.RefsRemoveAll(x);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //public virtual List<IVarRef> VarRefsList
        //{
        //    get
        //    {
        //        return new List<IVarRef>();
        //    }
        //}

        public override bool DeletePossible(Context x)
        {
            ContextNM context = (ContextNM)x;
            if (context.xUser.IsDeveloper())
                return true;

            try
            {
                string permit = "";
                if (Tools.Strings.StrCmp(ClassId, "company"))
                    permit = Permissions.ThePermits.DeleteAllCompanies;
                else if (Tools.Strings.StrCmp(ClassId, "companycontact"))
                    permit = Permissions.ThePermits.DeleteAllContacts;
                else if (Tools.Strings.StrCmp(ClassId, "partrecord"))
                    permit = Permissions.ThePermits.DeleteInventoryLineItems;
                else if (Tools.Strings.StrCmp(ClassId, "orddet_line"))
                    permit = Permissions.ThePermits.DeleteLineItems;
                else if (ClassId.ToLower().StartsWith("ordhed"))
                {
                    switch (ClassId.ToLower())
                    {
                        case "ordhed_quote":
                            permit = Permissions.ThePermits.DeleteAllFormalQuotes;
                            break;
                        case "ordhed_sales":
                            permit = Permissions.ThePermits.DeleteAllSalesOrders;
                            break;
                        case "ordhed_invoice":
                            permit = Permissions.ThePermits.DeleteAllInvoices;
                            break;
                        case "ordhed_purchase":
                            permit = Permissions.ThePermits.DeleteAllPurchaseOrders;
                            break;
                        case "ordhed_rma":
                            permit = Permissions.ThePermits.DeleteAllRMAs;
                            break;
                        case "ordhed_vendrma":
                            permit = Permissions.ThePermits.DeleteAllVRMAs;
                            break;
                        case "ordhed_service":
                            permit = Permissions.ThePermits.DeleteAllServiceOrders;
                            break;
                        
                    }
                }
                else
                {
                    //2012_10_23 added this so that every class has an automatic permission
                    switch (ClassId.ToLower())
                    {
                        case "orddet_quote":
                            permit = "";
                            break;
                        case "companyaddress":
                        case "shippingaccount":
                            permit = Permissions.ThePermits.EditAllCompanies;
                            break;
                        default:
                            permit = "delete_all_" + ClassId;
                            break;
                    }
                }

                //2012_10_23 switched to true to block everything except specific delete permissions
                if (Tools.Strings.StrExt(permit) && !context.xUser.CheckPermit(context, permit, true))
                {
                    //this will report even when opening an item, the delete should just not appear and there should be no need to tell the user                    
                    //context.TheLeader.TellTemp("You do not have permission to delete this information from the system.");
                    return false;
                }
                else
                    return true;
            }
            catch { }
            return false;
        }

        //public String InsertSql(Context x) { return BuildSaveSQL((ContextNM)x); }
        //public String UpdateSql(Context x) { return BuildUpdateSQL(); }
        //public String DeleteSql(Context x)
        //{
        //    String tablename = this.ClassName;
        //    if (Tools.Strings.StrExt(TableName))
        //        tablename = TableName;

        //    return "delete from " + tablename + " where unique_id = '" + this.unique_id + "'";
        //}

        //public void Invalidate(Context x)
        //{
        //    x.TheLeader.ViewsClose(this);
        //    unique_id = "invalid_" + Tools.Strings.GetNewID();
        //}


        ///////////////////////////////////////////
        public virtual String GetClipHeader(ContextNM x)
        {
            String s = "<hr>";
            s += "  <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
            s += "    <tr>";
            s += "      <td width=\"50%\">";
            s += "<font face=\"Arial\" size=\"4\">" + Name + "</font></td>";
            s += "    <td align=\"right\" width=\"50%\">";
            s += "<font size=\"4\" face=\"Arial\" color=\"#C0C0C0\">" + FilterCaptionName(x) + "</font>";
            s += "    </td>";
            s += "  </tr>";
            s += "  </table>";
            s += "<hr>";
            return s;
        }
        private string FilterCaptionName(ContextNM x)
        {
            switch (ClassId.Trim().ToLower())
            {
                case "partpicture":
                    return "Picture";
                case "dealheader":
                    return "Order Batch";
                case "checkpayment":
                    return "Check/Payment";
                case "contactnote":
                    return "Contact Note";
                case "usernote":
                    return "User Note";
                case "calllog":
                    return "Call Log";
                case "orddet_quote":
                    return "Quote Line";
                case "orddet_rfq":
                    return "Bid Line";
                case "n_user":
                    return "User";
                case "partrecord":
                    return "Inventory";
                case "companycontact":
                    return "Contact";
                case "ordhed":
                    return "Order";
                case "orddet":
                case "orddet_line":
                    return "Order Line";
                case "ordhed_invoice":
                    return "Invoice";
                case "ordhed_quote":
                    return "Quote";
                case "ordhed_purchase":
                    return "Purchase Order";
                case "ordhed_rfq":
                    return "RFQ";
                case "ordhed_sales":
                    return "Sales Order";
                case "ordhed_rma":
                    return "RMA";
                case "ordhed_vendrma":
                    return "Vendor RMA";
                case "ordhed_service":
                    return "Service Order";
                case "phonecall":
                    return "Phone Call";
                default:
                    return x.TheSys.CoreClassGet(ClassId).TheAttribute.Caption;
            }
        }

        public String Name
        {
            get
            {
                return ToString();
            }
        }

        public object LinksToVar { get; set; }

        public virtual String GetClipLine_Big(ContextNM context, String strProp)
        {
            return "<b>" + GetClipLine(context, strProp) + "</b>";
        }
        public virtual String GetClipLine(ContextNM context, String strProp)
        {
            return GetClipLine(context, strProp, "");
        }
        public virtual String GetClipLine_Email(String strProp)
        {
            try
            {
                String s = (String)IGet(strProp);
                if (Tools.Strings.StrExt(s))
                    return "Email:&nbsp;<a href=\"mailto:" + s + "\"><font face=\"Arial\" size=\"2\">" + s + "</font></a><br>";
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        public virtual String GetClipLine_URL(String strProp)
        {
            try
            {
                String s = (String)IGet(strProp);
                if (Tools.Strings.StrExt(s))
                    return "Website:&nbsp;<a href=\"" + s + "\" target=\"_new\"><font face=\"Arial\" size=\"2\">" + s + "</font></a><br>";
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        public virtual String GetClipLine(ContextNM context, String strProp, String strTag)
        {
            Object o = IGet(strProp);
            if (o == null)
                return "";
            String s = o.ToString();
            if (!Tools.Strings.StrExt(s))
                return "";
            CoreClassHandle c = context.TheSys.CoreClassGet(ClassId);  // xSys.GetClassByName(ClassName);
            if (c == null)
                return "";
            CoreVarAttribute p = c.VarGet(strProp);
            if (p == null)
                return "";
            if (!Tools.Strings.StrExt(strTag))
            {
                if (Tools.Strings.StrExt(p.Caption))
                    strTag = p.Caption;
                else
                    strTag = nTools.NiceFormat(p.Name);
            }
            return strTag + ":&nbsp;" + s + "<br>";
        }
        public virtual String GetClipLine_Phone(String strProp, String strExtProp, String strTag)
        {
            Object o = IGet(strProp);
            if (o == null)
                return "";
            String s = o.ToString();
            if (!Tools.Strings.StrExt(s))
                return "";
            Object e = IGet(strExtProp);
            String strExt = "";
            if (e != null)
                strExt = e.ToString();
            if (Tools.Strings.StrExt(strExt))
                return "Phone:&nbsp;" + s + "&nbsp;x" + strExt + "<br>";
            else
                return "Phone:&nbsp;" + s + "<br>";
        }
        public virtual String GetClipHTML(ContextNM x)
        {
            String s = GetClipHeader(x);
            //just return a formatted generic header
            CoreClassHandle c = x.TheSys.CoreClassGet(ClassId);  // xSys.GetClassByName(ClassName);
            if (c == null)
                return "";
            int i = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(GetClipHeader(x));
            sb.Append("<br><table border=\"0\" cellpading=\"1\" cellspacing=\"1\">");
            foreach (CoreVarValAttribute p in c.VarValsGet())
            {
                Object o = IGet(p.Name);
                if (o != null)
                    sb.Append("<tr><td>" + p.Caption + "</td><td>" + o.ToString() + "</td></tr>");
                i++;
                if (i > 10)
                    break;
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        public virtual bool ISet_Conditional(String strProperty, Object value)
        {
            try
            {
                String s1 = value.ToString();
                String s2 = IGet(strProperty).ToString();
                if (s1 == s2)
                    return true;
                return ISet(strProperty, value);
            }
            catch (Exception ex)
            {
                //string error = ex.Message;
                return false;
            }
        }
        public virtual bool ISet(String strProperty, Object value)
        {
            ValSet(strProperty, value);
            return true;
        }

        public virtual Object IGet(String strProperty)
        {
            if (strProperty == "unique_id")  //just for nm backward compatibility
                return Uid;
            else
                return ValGet(strProperty);
        }

        public List<CoreVarValAttribute> GetProps(ContextNM context)
        {
            return context.TheSys.CoreClassGet(ClassId).VarValsGet();
        }

        public virtual bool ISet_String(ContextNM context, String strProp, String strValue)
        {
            //throw new NotImplementedException("nObject.ISet_String without explicit type");
            //return false;

            foreach (CoreVarValAttribute p in GetProps(context))
            {
                if (Tools.Strings.StrCmp(p.Name, strProp))
                {
                    return ISet_String(strProp, strValue, p.TheFieldType);
                }
            }

            return false;
        }
        public virtual bool ISet_String(String strProp, String strValue, FieldType type)
        {
            try
            {
                switch (type)
                {
                    case FieldType.String:
                    case FieldType.Text:
                        ISet(strProp, strValue);
                        break;
                    case FieldType.DateTime:  // (Int32)FieldType.DateTime:
                        if (!Tools.Strings.StrExt(strValue))
                            ISet(strProp, Tools.Dates.NullDate);
                        else
                            ISet(strProp, DateTime.Parse(strValue));
                        break;
                    case FieldType.Int32:  // (Int32)FieldType.Int32:
                        ISet(strProp, Int32.Parse(strValue.Trim()));
                        break;
                    case FieldType.Int64:  // (Int32)FieldType.Int64:
                        ISet(strProp, Int64.Parse(strValue.Trim()));
                        break;
                    case FieldType.Double:  // (Int32)FieldType.Double:
                        ISet(strProp, Double.Parse(strValue.Trim()));
                        break;
                    case FieldType.Boolean:  // (Int32)FieldType.Boolean:
                        if (strValue == "on")
                            ISet(strProp, true);
                        else
                            ISet(strProp, Boolean.Parse(strValue));
                        break;
                }
            }
            catch (Exception)
            {
            }
            return true;
        }

        public virtual String GetExtraClassInfo()
        {
            return "";
        }
    }
}