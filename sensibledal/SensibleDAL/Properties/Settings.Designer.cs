﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SensibleDAL.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=rz.sensiblemicro.local\\SQLEXPRESS;Initial Catalog=ComponentIQ;Integra" +
            "ted Security=SSPI;")]
        public string ComponentIQConnectionString {
            get {
                return ((string)(this["ComponentIQConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=rz.sensiblemicro.local\\sqlexpress;Initial Catalog=Rz3;Persist Securit" +
            "y Info=True;User ID=RzSqlAccessAccount;Password=COWfogRS%F0c6pdyQzhKbsfg#sdfgdsf" +
            "gsdg@")]
        public string Rz3ConnectionString {
            get {
                return ((string)(this["Rz3ConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=rz.sensiblemicro.local\\SQLEXPRESS;Initial Catalog=SeriLog;Integrated " +
            "Security=True")]
        public string SeriLogConnectionString {
            get {
                return ((string)(this["SeriLogConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=rz.sensiblemicro.local\\SQLEXPRESS;Initial Catalog=SeriLog;Integrated " +
            "Security=True")]
        public string SeriLogConnectionString1 {
            get {
                return ((string)(this["SeriLogConnectionString1"]));
            }
        }
    }
}
