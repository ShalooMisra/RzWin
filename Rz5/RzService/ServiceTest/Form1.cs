using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Threading;

using Tie;
using System.Windows.Forms;

namespace ServiceTest
{
    public partial class Form1 : Form
    {
        public Eye ServerEye;

        public Form1()
        {
            InitializeComponent();
        }

        private void CompleteStart()
        {
            AddLog("");
            GetSettings();

            AddLog("Port=" + PortSetting.ToString());
            AddLog("Password=" + PasswordSetting);
            AddLog("RzServerName=" + RzServerName);
            AddLog("RzDatabaseName=" + RzDatabaseName);
            AddLog("RzRecallDatabaseName=" + RzRecallDatabaseName);
            AddLog("RzServerUserName=" + RzServerUserName);
            AddLog("RzServerPassword=" + RzServerPassword);
            AddLog("MinutesBetweenCubes=" + MinutesBetweenCubes.ToString());
            AddLog("RzDllPath=" + RzDllPath);
            AddLog("RzDllName=" + RzDllName);
            AddLog("RzDllType=" + RzDllType);

            try
            {
                ServerEye = new Eye();
                ServerEye.EyePort = PortSetting;
                ServerEye.Password = PasswordSetting;
                ServerEye.SendEncrypted = true;
                ServerEye.StartListening();
                AddLog("Listening on port " + ServerEye.EyePort.ToString() + "...");

                if (MinutesBetweenCubes > 0)
                {
                    //StartCheckingCubes();
                }
                else
                {
                    AddLog("Skipping cubes.");
                }
            }
            catch (Exception ex)
            {
                AddLog("Error in CompleteStart: " + ex.Message);
            }
        }

        int PortSetting = 2954;
        String PasswordSetting = "rec0gnin";

        String RzServerName = "caamano";
        String RzDatabaseName = "Rz3_CTG";
        String RzRecallDatabaseName = "Rz3CTG_Recall";
        String RzServerUserName = "sa";
        String RzServerPassword = "ctgsql13";
        int MinutesBetweenCubes = 240;
        String RzDllPath = "c:\\program files\\recognin technologies\\rz3\\";
        String RzDllName = "Rz3_CTG.dll";
        String RzDllType = "Rz3_CTG.nStartup_Rz3";

        void GetSettings()
        {
            AddLog("Getting settings...");
            try
            {
                String strFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim());
                if (!strFile.EndsWith("\\"))
                    strFile += "\\";
                strFile += "RzServiceSettings.xml";
                if (!File.Exists(strFile))
                {
                    AddLog("No settings found.");
                    return;
                }

                System.Xml.XmlDocument d = new System.Xml.XmlDocument();
                d.Load(strFile);
                XmlNode xNode = d.SelectSingleNode("settings/setting[1]");
                PortSetting = Tools.Xml.ReadXmlProp_Integer(xNode, "listen_port");
                PasswordSetting = Tools.Xml.ReadXmlProp(xNode, "listen_password");

                RzServerName = Tools.Xml.ReadXmlProp(xNode, "rz_server_name");
                RzDatabaseName = Tools.Xml.ReadXmlProp(xNode, "rz_database_name");
                RzRecallDatabaseName = Tools.Xml.ReadXmlProp(xNode, "rz_recall_database_name");
                RzServerUserName = Tools.Xml.ReadXmlProp(xNode, "rz_server_user_name");
                RzServerPassword = Tools.Xml.ReadXmlProp(xNode, "rz_server_password");
                MinutesBetweenCubes = Tools.Xml.ReadXmlProp_Integer(xNode, "minutes_between_cubes");
                RzDllPath = Tools.Xml.ReadXmlProp(xNode, "rz_dll_path");
                RzDllName = Tools.Xml.ReadXmlProp(xNode, "rz_dll_name");
                RzDllType = Tools.Xml.ReadXmlProp(xNode, "rz_dll_type");

                d = null;
            }
            catch (Exception ex)
            {
                AddLog("Error parsing settings: " + ex.Message);
            }

            AddLog("Settings done.");
        }

        void AddLog(String s)
        {
            MessageBox.Show(s);

            try
            {
                String strFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim());
                if (!strFile.EndsWith("\\"))
                    strFile += "\\";
                strFile += "RzServiceLog.txt";
                if (!File.Exists(strFile))
                    File.Create(strFile);

                StreamWriter f = new StreamWriter(strFile, true);
                f.WriteLine(DateTime.Now.ToString() + " : " + s);
                f.Close();
                f.Dispose();
                f = null;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CompleteStart();
        }

    }
}