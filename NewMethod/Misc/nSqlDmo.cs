//using System;
//using System.Collections;
//using System.Text;
//using System.IO;
//using SQLDMO;
//using DTS;
//using DTSCustTasks;

//namespace NewMethod
//{
//    public static class nSqlDmo
//    {
//        public static bool RunDTSExport(String strFile, String strTableName, String strSQL, ArrayList colColumns, String strServer, String strUserName, String strPassword, String strDatabaseName, ref long lngRecords)
//        {
//            try
//            {
//                String strFields;
//                int intFields;
//                String strTextMask;
//                String strBlobMask;

//                strFields = "";
//                strTextMask = "";
//                strBlobMask = "";
//                intFields = 0;
//                foreach (ExportColumn xColumn in colColumns)
//                {
//                    intFields++;
//                    if (Tools.Strings.StrExt(strFields))
//                        strFields += ",";

//                    strFields += xColumn.ColumnName;
//                    strTextMask += "1";
//                    strBlobMask += "0";
//                }

//                if (File.Exists(strFile))
//                    File.Delete(strFile);

//                RunDTSFromCollection(strSQL, strFields, intFields, strTextMask, strBlobMask, strFile, strServer, strUserName, strPassword, strDatabaseName, colColumns, ref lngRecords);
//                return File.Exists(strFile);
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }

//        public static bool RunDTSFromCollection(String strSQL, String strFields, int intFields, String strTextMask, String strBlobMask, String strFile, String strServer, String strUserName, String strPassword, String strDatabase, ArrayList colColumns, ref long lngRecords)
//        {
//            try
//            {
//                DTS.Package2 goPackage = (DTS.Package2)new DTS.Package2Class();
//                goPackage.Name = "NewMethod Export";
//                goPackage.Description = "Export";
//                goPackage.WriteCompletionStatusToNTEventLog = false;
//                goPackage.FailOnError = false;
//                goPackage.PackagePriorityClass = DTSPackagePriorityClass.DTSPriorityClass_Normal;
//                goPackage.MaxConcurrentSteps = 4;
//                goPackage.LineageOptions = 0;
//                goPackage.UseTransaction = true;
//                goPackage.TransactionIsolationLevel = DTSIsolationLevel.DTSIsoLevel_Isolated;
//                goPackage.AutoCommitTransaction = true;
//                goPackage.RepositoryMetadataOptions = 0;
//                goPackage.UseOLEDBServiceComponents = true;
//                goPackage.LogToSQLServer = false;
//                goPackage.LogServerFlags = 0;
//                goPackage.FailPackageOnLogFailure = false;
//                goPackage.ExplicitGlobalVariables = false;
//                goPackage.PackageType = 0;
//                //dts.oledbproperty oConnProperty;

//                //---------------------------------------------------------------------------
//                // create package connection information
//                //---------------------------------------------------------------------------
//                //------------- a new connection defined below.
//                //For security purposes, the password is never scripted

//                DTS.Connection oConnection = goPackage.Connections.New("SQLOLEDB");
//                oConnection.ConnectionProperties.Item("Persist Security Info").Value = true;
//                oConnection.ConnectionProperties.Item("User ID").Value = strUserName;
//                oConnection.ConnectionProperties.Item("Initial Catalog").Value = strDatabase;
//                oConnection.ConnectionProperties.Item("Data Source").Value = strServer;
//                oConnection.ConnectionProperties.Item("Application Name").Value = "DTS  Import/Export Wizard";
//                oConnection.Name = "Connection 1";
//                oConnection.ID = 1;
//                oConnection.Reusable = true;
//                oConnection.ConnectImmediate = false;
//                oConnection.DataSource = strServer;
//                oConnection.ConnectionTimeout = 60;
//                oConnection.Catalog = strDatabase;
//                oConnection.UseTrustedConnection = false;
//                oConnection.UseDSL = false;

//                //If you have a password for this connection, please uncomment and add your password below.
//                oConnection.Password = strPassword;
//                goPackage.Connections.Add(oConnection);
//                oConnection = null;

//                //------------- a new connection defined below.
//                //For security purposes, the password is never scripted

//                oConnection = goPackage.Connections.New("DTSFlatFile");
//                oConnection.ConnectionProperties.Item("Data Source").Value = strFile;
//                oConnection.ConnectionProperties.Item("Mode").Value = 3;
//                oConnection.ConnectionProperties.Item("Row Delimiter").Value = "\r\n";
//                oConnection.ConnectionProperties.Item("File Format").Value = 1;
//                oConnection.ConnectionProperties.Item("Column Delimiter").Value = ",";
//                oConnection.ConnectionProperties.Item("Text Qualifier").Value = "\"";
//                oConnection.ConnectionProperties.Item("File Type").Value = 1;
//                oConnection.ConnectionProperties.Item("Skip Rows").Value = 0;
//                oConnection.ConnectionProperties.Item("First Row Column Name").Value = false;
//                oConnection.ConnectionProperties.Item("Column Names").Value = strFields;
//                oConnection.ConnectionProperties.Item("Number of Column").Value = intFields;
//                oConnection.ConnectionProperties.Item("Text Qualifier Col Mask: 0=no, 1=yes, e.g. 0101").Value = strTextMask;
//                oConnection.ConnectionProperties.Item("Blob Col Mask: 0=no, 1=yes, e.g. 0101").Value = strBlobMask;
//                oConnection.Name = "Connection 2";
//                oConnection.ID = 2;
//                oConnection.Reusable = true;
//                oConnection.ConnectImmediate = false;
//                oConnection.DataSource = strFile;
//                oConnection.ConnectionTimeout = 60;
//                oConnection.UseTrustedConnection = false;
//                oConnection.UseDSL = false;
//                goPackage.Connections.Add(oConnection);
//                oConnection = null;

//                //---------------------------------------------------------------------------
//                // create package steps information
//                //---------------------------------------------------------------------------
//                //------------- a new step defined below

//                DTS.Step oStep = goPackage.Steps.New();
//                oStep.Name = "Copy Data from Results to " + strFile + " Step";
//                oStep.Description = "Copy Data from Results to " + strFile + " Step";
//                //oStep.ExecutionStatus = DTSStepExecStatus.DTSStepExecStat_InProgress;
//                oStep.TaskName = "Copied data in table " + strFile + " ";
//                oStep.CommitSuccess = false;
//                oStep.RollbackFailure = false;
//                oStep.ScriptLanguage = "VBScript";
//                oStep.AddGlobalVariables = true;
//                oStep.RelativePriority = DTSStepRelativePriority.DTSStepRelativePriority_Normal;
//                oStep.CloseConnection = false;
//                oStep.ExecuteInMainThread = false;
//                oStep.IsPackageDSORowset = false;
//                oStep.JoinTransactionIfPresent = false;
//                oStep.DisableStep = false;
//                //oStep.FailPackageOnError = false;
//                goPackage.Steps.Add((DTS.Step)oStep);
//                oStep = null;

//                DTS.Task oTask = goPackage.Tasks.New("DTSDataPumpTask");
//                DTS.DataPumpTask2 oCustomTask1 = (DTS.DataPumpTask2)oTask.CustomTask;
//                oCustomTask1.Name = "Copied data in table " + strFile + " ";
//                oCustomTask1.Description = "Copied data in table " + strFile + " ";
//                oCustomTask1.SourceConnectionID = 1;
//                oCustomTask1.SourceSQLStatement = strSQL;
//                oCustomTask1.DestinationConnectionID = 2;
//                oCustomTask1.DestinationObjectName = strFile;
//                oCustomTask1.ProgressRowCount = 1000;
//                oCustomTask1.MaximumErrorCount = 0;
//                oCustomTask1.FetchBufferSize = 1;
//                oCustomTask1.UseFastLoad = true;
//                oCustomTask1.InsertCommitSize = 0;
//                oCustomTask1.ExceptionFileColumnDelimiter = "|";
//                oCustomTask1.ExceptionFileRowDelimiter = "\r\n";
//                oCustomTask1.AllowIdentityInserts = false;
//                oCustomTask1.FirstRow = 0;
//                oCustomTask1.LastRow = 0;
//                oCustomTask1.FastLoadOptions = DTSFastLoadOptions.DTSFastLoad_Default;
//                oCustomTask1.ExceptionFileOptions = DTSExceptionFileOptions.DTSExcepFile_Ansi;
//                oCustomTask1.DataPumpOptions = 0;

//                DTS.Transformation2 oTransformation = (DTS.Transformation2)oCustomTask1.Transformations.New("DTS.DataPumpTransformCopy");
//                oTransformation.Name = "DirectCopyXform";
//                oTransformation.TransformFlags = 63;
//                oTransformation.ForceSourceBlobsBuffered = 0;
//                oTransformation.ForceBlobsInMemory = false;
//                oTransformation.InMemoryBlobSize = 1048576;
//                oTransformation.TransformPhases = 4;

//                DTS.Column oColumn;
//                int intCount = 1;
//                foreach (ExportColumn xColumn in colColumns)
//                {
//                    //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//                    //Source

//                    oColumn = oTransformation.SourceColumns.New(xColumn.ColumnName, intCount);
//                    oColumn.Name = xColumn.ColumnName;
//                    oColumn.Ordinal = intCount;
//                    oColumn.Precision = 0;
//                    oColumn.NumericScale = 0;
//                    oColumn.Nullable = true;
//                    oColumn.Flags = 120;
//                    oColumn.Size = 255;
//                    oColumn.DataType = 129;
//                    oTransformation.SourceColumns.Add(oColumn);
//                    oColumn = null;

//                    //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//                    //Destination

//                    oColumn = oTransformation.DestinationColumns.New(xColumn.ColumnName, intCount);
//                    oColumn.Name = xColumn.ColumnName;
//                    oColumn.Ordinal = intCount;
//                    oColumn.Precision = 0;
//                    oColumn.NumericScale = 0;
//                    oColumn.Nullable = true;
//                    oColumn.Flags = 120;
//                    oColumn.Size = 255;
//                    oColumn.DataType = 129;
//                    oTransformation.DestinationColumns.Add(oColumn);
//                    oColumn = null;
//                    intCount++;
//                }

//                oCustomTask1.Transformations.Add(oTransformation);
                
//                goPackage.Tasks.Add(oTask);

//                //goPackage.SaveToSQLServer "(local)", "sa", ""
//                goPackage.Execute();
//                lngRecords = Convert.ToInt64(oCustomTask1.RowsComplete);

//                oTransformation = null;
//                oCustomTask1 = null;
//                oTask = null;           
//                goPackage.UnInitialize();
//                goPackage = null;

//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }

//        //public void RunDTS(String strFields, int intFields, String strTextMask, String strBlobMask, String strFile, String strServer, String strUserName, String strPassword, String strDatabase, ArrayList colProperties, Object strClass)
//        //{
//        //    if( File.FileExists(strFile) )
//        //        File.Delete(strFile);

//        //    goPackage = goPackageOld
//        //    goPackage.Name = "MetaCode Export"
//        //    goPackage.Description = "Export"
//        //    goPackage.WriteCompletionStatusToNTEventLog = false
//        //    goPackage.FailOnError = false
//        //    goPackage.PackagePriorityClass = 2
//        //    goPackage.MaxConcurrentSteps = 4
//        //    goPackage.LineageOptions = 0
//        //    goPackage.UseTransaction = true
//        //    goPackage.TransactionIsolationLevel = 4096
//        //    goPackage.AutoCommitTransaction = true
//        //    goPackage.RepositoryMetadataOptions = 0
//        //    goPackage.UseOLEDBServiceComponents = true
//        //    goPackage.LogToSQLServer = false
//        //    goPackage.LogServerFlags = 0
//        //    goPackage.FailPackageOnLogFailure = false
//        //    goPackage.ExplicitGlobalVariables = false
//        //    goPackage.PackageType = 0
//        //    dts.oledbproperty oConnProperty;

//        //    //---------------------------------------------------------------------------
//        //    // create package connection information
//        //    //---------------------------------------------------------------------------

//        //    dts.connection2 oConnection;

//        //    //------------- a new connection defined below.
//        //    //For security purposes, the password is never scripted

//        //    oConnection= goPackage.Connections.New("SQLOLEDB")
//        //    oConnection.ConnectionProperties("Persist Security Info") = true
//        //    oConnection.ConnectionProperties("User ID") = strUserName
//        //    oConnection.ConnectionProperties("Initial Catalog") = strDatabase
//        //    oConnection.ConnectionProperties("Data Source") = strServer
//        //    oConnection.ConnectionProperties("Application Name") = "DTS  Import/Export Wizard"
//        //    oConnection.Name = "Connection 1"
//        //    oConnection.ID = 1
//        //    oConnection.Reusable = true
//        //    oConnection.ConnectImmediate = false
//        //    oConnection.DataSource = strServer
//        //    oConnection.ConnectionTimeout = 60
//        //    oConnection.Catalog = strDatabase
//        //    oConnection.UseTrustedConnection = false
//        //    oConnection.UseDSL = false

//        //    //If you have a password for this connection, please uncomment and add your password below.
//        //    oConnection.Password = strPassword
//        //    goPackage.Connections.Add oConnection
//        //     oConnection= null

//        //    //------------- a new connection defined below.
//        //    //For security purposes, the password is never scripted

//        //     oConnection= goPackage.Connections.New("DTSFlatFile")
//        //    oConnection.ConnectionProperties("Data Source") = strFile
//        //    oConnection.ConnectionProperties("Mode") = 3
//        //    oConnection.ConnectionProperties("Row Delimiter") = "|" + vbCrLf + "|"
//        //    oConnection.ConnectionProperties("File Format") = 1
//        //    oConnection.ConnectionProperties("Column Delimiter") = vbTab
//        //    oConnection.ConnectionProperties("File Type") = 1
//        //    oConnection.ConnectionProperties("Skip Rows") = 0
//        //    oConnection.ConnectionProperties("First Row Column Name") = false
//        //    oConnection.ConnectionProperties("Column Names") = strFields
//        //    oConnection.ConnectionProperties("Number of Column") = intFields
//        //    oConnection.ConnectionProperties("Text Qualifier Col Mask: 0=no, 1=yes, e.g. 0101") = strTextMask
//        //    oConnection.ConnectionProperties("Blob Col Mask: 0=no, 1=yes, e.g. 0101") = strBlobMask
//        //    oConnection.Name = "Connection 2"
//        //    oConnection.ID = 2
//        //    oConnection.Reusable = true
//        //    oConnection.ConnectImmediate = false
//        //    oConnection.DataSource = strFile
//        //    oConnection.ConnectionTimeout = 60
//        //    oConnection.UseTrustedConnection = false
//        //    oConnection.UseDSL = false

//        //    //If you have a password for this connection, please uncomment and add your password below.
//        //    //oConnection.Password = "<put the password here>"

//        //    goPackage.Connections.Add oConnection
//        //     oConnection= null

//        //    //---------------------------------------------------------------------------
//        //    // create package steps information
//        //    //---------------------------------------------------------------------------

//        //    dts.step2 oStep;
//        //    dts.precedenceconstraint oPrecConstraint;

//        //    //------------- a new step defined below
//        //     oStep= goPackage.Steps.New
//        //    oStep.Name = "Copy Data from Results to " + strFile + " Step"
//        //    oStep.Description = "Copy Data from Results to " + strFile + " Step"
//        //    oStep.ExecutionStatus = 1
//        //    oStep.TaskName = "Copied data in table " + strFile + " "
//        //    oStep.CommitSuccess = false
//        //    oStep.RollbackFailure = false
//        //    oStep.ScriptLanguage = "VBScript"
//        //    oStep.AddGlobalVariables = true
//        //    oStep.RelativePriority = 3
//        //    oStep.CloseConnection = false
//        //    oStep.ExecuteInMainThread = false
//        //    oStep.IsPackageDSORowset = false
//        //    oStep.JoinTransactionIfPresent = false
//        //    oStep.DisableStep = false
//        //    oStep.FailPackageOnError = false
//        //    goPackage.Steps.Add oStep
//        //     oStep= null

//        //    //---------------------------------------------------------------------------
//        //    // create package tasks information
//        //    //---------------------------------------------------------------------------

//        //    //------------- call Task_Sub1 for task Copied data in table c:\objects_1.dat (Copied data in table c:\objects_1.dat)
//        //    Task_Sub1(goPackage, strClass, strFile, strFields, colProperties)

//        //    //---------------------------------------------------------------------------
//        //    // Save or execute package
//        //    //---------------------------------------------------------------------------

//        //    //goPackage.SaveToSQLServer "(local)", "sa", ""
//        //    goPackage.Execute 
//        //    goPackage.UnInitialize 

//        //    //to save a package instead of executing it, comment out the executing package line above and uncomment the saving package line
//        //     goPackage= null
//        //     goPackageOld= null
//        //}


//        ////------------- define Task_Sub1 for task Copied data in table c:\objects_1.dat (Copied data in table c:\objects_1.dat)
//        //private void Task_Sub1(object goPackage, Object strClass, String strFile, String strFields, ArrayList colProperties)
//        //{
//        //    dts.task oTask;
//        //    dts.lookup oLookup;
//        //    dts.datapumptask2 oCustomTask1;

//        //     oTask= goPackage.Tasks.New("DTSDataPumpTask")
//        //     oCustomTask1= oTask.CustomTask
//        //    oCustomTask1.Name = "Copied data in table " + strFile + " "
//        //    oCustomTask1.Description = "Copied data in table " + strFile + " "
//        //    oCustomTask1.SourceConnectionID = 1
//        //    oCustomTask1.SourceSQLStatement = "select " + Replace(strFields, ",", ", ") + " from " + strClass
//        //    oCustomTask1.DestinationConnectionID = 2
//        //    oCustomTask1.DestinationObjectName = strFile
//        //    oCustomTask1.ProgressRowCount = 1000
//        //    oCustomTask1.MaximumErrorCount = 0
//        //    oCustomTask1.FetchBufferSize = 1
//        //    oCustomTask1.UseFastLoad = true
//        //    oCustomTask1.InsertCommitSize = 0
//        //    oCustomTask1.ExceptionFileColumnDelimiter = "|"
//        //    oCustomTask1.ExceptionFileRowDelimiter = vbCrLf
//        //    oCustomTask1.AllowIdentityInserts = false
//        //    oCustomTask1.FirstRow = 0
//        //    oCustomTask1.LastRow = 0
//        //    oCustomTask1.FastLoadOptions = 2
//        //    oCustomTask1.ExceptionFileOptions = 1
//        //    oCustomTask1.DataPumpOptions = 0
//        //    oCustomTask1_Trans_Sub1(oCustomTask1, colProperties)
//        //    goPackage.Tasks.Add oTask
//        //     oCustomTask1= null
//        //     oTask= null
//        //}

//        //private void oCustomTask1_Trans_Sub1(object oCustomTask1, ArrayList colProperties)
//        //{
//        //    mcproperty xProp;
//        //    int intCount;
//        //    dts.transformation2 oTransformation;
//        //    dts.properties oTransProps;
//        //    dts.column oColumn;

//        //     oTransformation= oCustomTask1.Transformations.New("DTS.DataPumpTransformCopy")
//        //    oTransformation.Name = "DirectCopyXform"
//        //    oTransformation.TransformFlags = 63
//        //    oTransformation.ForceSourceBlobsBuffered = 0
//        //    oTransformation.ForceBlobsInMemory = false
//        //    oTransformation.InMemoryBlobSize = 1048576
//        //    oTransformation.TransformPhases = 4
//        //    intCount = 1
//        //    For Each xProp In colProperties

//        //    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//        //    'Source

//        //         oColumn= oTransformation.SourceColumns.New(xProp.PropertyName, intCount)
//        //        oColumn.Name = xProp.PropertyName
//        //        oColumn.Ordinal = intCount
//        //        oColumn.Precision = 0
//        //        oColumn.NumericScale = 0
//        //        oColumn.Nullable = true
//        //        switch( xProp.PropertyType )
//        //    {
//        //            break;
//        //    case tString, tList:
//        //                oColumn.flags = 104
//        //                oColumn.Size = xProp.PropertyLength
//        //                oColumn.DataType = 129
//        //            break;
//        //    case tInteger, tLong:
//        //                oColumn.flags = 120
//        //                oColumn.Size = 0
//        //                oColumn.DataType = 3
//        //            break;
//        //    case tFloat:
//        //                oColumn.flags = 120
//        //                oColumn.Size = 0
//        //                oColumn.DataType = 5
//        //            break;
//        //    case tBoolean:
//        //                oColumn.flags = 120
//        //                oColumn.Size = 0
//        //                oColumn.DataType = 11
//        //            break;
//        //    case tDate:
//        //                oColumn.flags = 120
//        //                oColumn.Size = 0
//        //                oColumn.DataType = 135
//        //            break;
//        //    case tMemo:
//        //                oColumn.flags = 232
//        //                oColumn.Size = 0
//        //                oColumn.DataType = 129
//        //            default:
//        //                MsgBox "unsupported data type"
//        //        }

//        //        oTransformation.SourceColumns.Add oColumn
//        //         oColumn= null

//        //    //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//        //    //Destination

//        //         oColumn= oTransformation.DestinationColumns.New(xProp.PropertyName, intCount)
//        //        oColumn.Name = xProp.PropertyName
//        //        oColumn.Ordinal = intCount
//        //        oColumn.Precision = 0
//        //        oColumn.NumericScale = 0
//        //        oColumn.Nullable = true
//        //        switch( xProp.PropertyType )
//        //    {
//        //            break;
//        //    case tString, tList:
//        //                oColumn.flags = 104
//        //                oColumn.Size = xProp.PropertyLength
//        //                oColumn.DataType = 129
//        //            break;
//        //    case tInteger, tLong:
//        //                oColumn.flags = 120
//        //                oColumn.Size = 12
//        //                oColumn.DataType = 129
//        //            break;
//        //    case tFloat:
//        //                oColumn.flags = 120
//        //                oColumn.Size = 12
//        //                oColumn.DataType = 129
//        //            break;
//        //    case tBoolean:
//        //                oColumn.flags = 120
//        //                oColumn.Size = 12
//        //                oColumn.DataType = 129
//        //            break;
//        //    case tDate:
//        //                oColumn.flags = 120
//        //                oColumn.Size = 25
//        //                oColumn.DataType = 129
//        //            break;
//        //    case tMemo:
//        //                oColumn.flags = 232
//        //                oColumn.Size = 2147483647
//        //                oColumn.DataType = 129
//        //            default:
//        //                MsgBox "unsupported data type"
//        //        }

//        //        oTransformation.DestinationColumns.Add oColumn
//        //         oColumn= null
//        //        intCount = intCount + 1
//        //    }

//        //     oTransProps= null
//        //    oCustomTask1.Transformations.Add oTransformation
//        //     oTransformation= null
//        //}




//        //public static bool DTSExportClass(nData UseData, String strClass, String strFile)
//        //{
//        //    String strFields;
//        //    int intFields;
//        //    String strTextMask;
//        //    String strBlobMask;
//        //    mcproperty xProp;

//        //    strFields = ""
//        //    strTextMask = ""
//        //    strBlobMask = ""
//        //    intFields = 0
//        //    For Each xProp In xApp.TemplateObjects(strClass).AllProperties
//        //        intFields = intFields + 1
//        //        if( Tools.Strings.StrExt(strFields) )
//        //    {
//        //    strFields = strFields + ","
//        //    }
//        //        strFields = strFields + xProp.PropertyName
//        //        switch( xProp.PropertyType )
//        //    {
//        //            break;
//        //    case tString:
//        //                strTextMask = strTextMask + "1"
//        //                strBlobMask = strBlobMask + "0"
//        //            break;
//        //    case tMemo:
//        //                strTextMask = strTextMask + "1"
//        //                strBlobMask = strBlobMask + "1"
//        //            break;
//        //    case tDocument, tPicture, tObject:
//        //                strTextMask = strTextMask + "0"
//        //                strBlobMask = strBlobMask + "1"
//        //            default:
//        //                strTextMask = strTextMask + "0"
//        //                strBlobMask = strBlobMask + "0"
//        //        }

//        //    }

//        //    RunDTS(strFields, intFields, strTextMask, strBlobMask, strFile, UseData.xServerData.ServerName, UseData.xServerData.username, UseData.xServerData.Password, UseData.xServerData.DatabaseName, xApp.TemplateObjects(strClass).AllProperties, strClass)
//        //}

//        //public void DTSExportIndexes(String strClass, String strFile, mcconnection UseData)
//        //{
//        //    ArrayList colProperties;
//        //    mcproperty xProp;

//        //    xProp.PropertyName = "unique_id"
//        //    xProp.PropertyType = tString
//        //    xProp.PropertyLength = 50
//        //    colProperties.Add xProp
//        //    RunDTS("unique_id", 1, "1", "0", strFile, UseData.xServerData.ServerName, UseData.xServerData.username, UseData.xServerData.Password, UseData.xServerData.DatabaseName, colProperties, strClass)
//        //}

//        public static bool DTSMoveTable(ContextNM context, String strSourceServer, String strSourceDatabase, String strSourcePassword, String strDestServer, String strDestDatabase, String strDestPassword, String strTable)
//        {
//            context.TheLeader.Comment("Moving table via DTS(source=" + strSourceServer + " dest=" + strDestServer + " database=" + strDestDatabase + " table=" + strTable + ")");
//            DTS.Package2 goPackage = (DTS.Package2)new DTS.Package2Class();
//            goPackage.Name = "TableMove";
//            goPackage.Description = "DTS package description";
//            goPackage.WriteCompletionStatusToNTEventLog = false;
//            goPackage.FailOnError = false;
//            goPackage.PackagePriorityClass = DTSPackagePriorityClass.DTSPriorityClass_High;
//            goPackage.MaxConcurrentSteps = 4;
//            goPackage.LineageOptions = 0;
//            goPackage.UseTransaction = true;
//            goPackage.TransactionIsolationLevel = DTSIsolationLevel.DTSIsoLevel_Isolated;
//            goPackage.AutoCommitTransaction = true;
//            goPackage.RepositoryMetadataOptions = 0;
//            goPackage.UseOLEDBServiceComponents = true;
//            goPackage.LogToSQLServer = false;
//            goPackage.LogServerFlags = 0;
//            goPackage.FailPackageOnLogFailure = false;
//            goPackage.ExplicitGlobalVariables = false;
//            goPackage.PackageType = 0;

//            DTS.Step oStep = goPackage.Steps.New();

//            oStep.Name = "Copy SQL Server Objects";
//            oStep.Description = "Copy SQL Server Objects";
//            //oStep.ExecutionStatus  = DTSStepExecStatus.
//            oStep.TaskName = "Copy SQL Server Objects";
//            oStep.CommitSuccess = false;
//            oStep.RollbackFailure = false;
//            oStep.ScriptLanguage = "VBScript";
//            oStep.AddGlobalVariables = true;
//            oStep.RelativePriority = DTSStepRelativePriority.DTSStepRelativePriority_AboveNormal;
//            oStep.CloseConnection = false;
//            oStep.ExecuteInMainThread = false;
//            oStep.IsPackageDSORowset = false;
//            oStep.JoinTransactionIfPresent = false;
//            oStep.DisableStep = false;
//            goPackage.Steps.Add(oStep);
//            oStep = null;

//            DTS.Task oTask = goPackage.Tasks.New("DTSTransferObjectsTask");

//            DTS.TransferObjectsTask2 oCustomTask1 = (DTS.TransferObjectsTask2)oTask.CustomTask;
//            oCustomTask1.Name = "Copy SQL Server Objects";
//            oCustomTask1.Description = "Copy SQL Server Objects";
//            oCustomTask1.SourceServer = strSourceServer;
//            oCustomTask1.SourceLogin = "sa";
//            oCustomTask1.SourcePassword = strSourcePassword;
//            oCustomTask1.SourceUseTrustedConnection = false;
//            oCustomTask1.SourceDatabase = strSourceDatabase;
//            oCustomTask1.DestinationServer = strDestServer;
//            oCustomTask1.DestinationLogin = "sa";
//            oCustomTask1.DestinationPassword = strDestPassword;
//            oCustomTask1.DestinationUseTrustedConnection = false;
//            oCustomTask1.DestinationDatabase = strDestDatabase;
//            oCustomTask1.ScriptFileDirectory = "C:\\Program Files\\Microsoft SQL Server\\80\\Tools";
//            oCustomTask1.CopyAllObjects = false;
//            oCustomTask1.IncludeDependencies = true;
//            oCustomTask1.IncludeLogins = false;
//            oCustomTask1.IncludeUsers = true;
//            oCustomTask1.DropDestinationObjectsFirst = true;
//            oCustomTask1.CopySchema = true;
//            oCustomTask1.CopyData = DTSTransfer_CopyDataOption.DTSTransfer_ReplaceData;
//            oCustomTask1.ScriptOption = DTSTransfer_ScriptOption.DTSTransfer_Script_Default;
//            //oCustomTask1.ScriptOptionEx = DTSTransfer_ScriptOptionEx.
//            oCustomTask1.SourceTranslateChar = true;
//            oCustomTask1.DestTranslateChar = true;
//            oCustomTask1.DestUseTransaction = false;
//            oCustomTask1.UseCollation = false;
//            oCustomTask1.AddObjectForTransfer(strTable, "dbo", DTSSQLObjectType.DTSSQLObj_UserTable);
//            goPackage.Tasks.Add(oTask);

//            goPackage.Execute();
//            goPackage.UnInitialize();


//            oCustomTask1 = null;
//            oTask = null;
//            goPackage = null;
//            return true;
//        }
//    }

//    public class ExportColumn
//    {
//        public String ColumnName = "";
//        public ExportColumn(String s)
//        {
//            ColumnName = s;
//        }
//    }



//}
