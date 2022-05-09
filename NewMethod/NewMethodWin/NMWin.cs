using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using CoreWin;
using NewMethod.Win;
using Tools.Database;
using Tools;
using System.Reflection;

namespace NewMethod
{
    public static class NMWin
    {
        public static ContextNM ContextDefault;

        public static LeaderWinUserNM Leader
        {
            get
            {
                return (LeaderWinUserNM)ContextDefault.TheLeader;
            }
        }

        public static MainForm MainForm
        {
            get
            {
                return Leader.TheMainForm;
            }
        }

        public static DataConnectionSqlServer Data
        {
            get
            {
                return (DataConnectionSqlServer)ContextDefault.TheData.TheConnection;
            }
        }

        public static n_user User
        {
            get
            {
                return ContextDefault.xUser;
            }
        }

        public static SysNewMethod Sys
        {
            get
            {
                return ContextDefault.Sys;
            }
        }

        public static bool LoadFormValues(Control c, nObject x)
        {
            return LoadFormValues(c, x, null);
        }

        public static bool LoadFormValues(Control c, nObject x, List<System.Windows.Forms.Control> ignore)
        {
            ArrayList ChangedProps = new ArrayList();
            return LoadFormValues(c, x, ChangedProps, ignore);
        }
        
        public static bool LoadFormValues(Control c, nObject xObject, ArrayList ChangedProps, List<System.Windows.Forms.Control> ignore)
        {
            nEdit ctl;
            nEdit_List l;
            foreach (System.Windows.Forms.Control x in c.Controls)
            {
                if (ignore != null)
                {
                    if (ignore.Contains(x))
                        continue;
                }

                if (x.Name.ToLower().StartsWith("ctl_"))
                {
                    if (Tools.Strings.StrCmp(x.Name, "ctl_templatename"))
                    {
                        int zx = 0;
                    }
                    try
                    {
                        ctl = (nEdit)x;
                        if (ChangedProps != null)
                            ChangedProps.Add(ctl.Name.Substring(4));
                        switch (ctl.GetControlType().ToLower())
                        {
                            case "list":
                                l = (nEdit_List)ctl;
                                if (Tools.Strings.StrExt(l.ListName))
                                {
                                    l.LoadList();
                                }
                                ctl.SetValue(xObject.IGet(ctl.Name.Substring(4)));
                                break;
                            case "modified":
                                nEdit_Modified modi = (nEdit_Modified)ctl;
                                modi.SetObject(xObject);
                                break;
                            case "money":
                                ctl.SetValue(xObject.IGet(ctl.Name.Substring(4)));
                                //try
                                //{
                                //    nEdit_Money m = (nEdit_Money)ctl;
                                //    if (m.ShowCurrency)
                                //        m.SetCurrency((String)IGet(ctl.Name.Substring(4) + "curr"));
                                //}
                                //catch (Exception)
                                //{
                                //}
                                break;
                            default:
                                ctl.SetValue(xObject.IGet(ctl.Name.Substring(4)));
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                    }
                }
                else
                {
                    String tn = x.GetType().ToString().ToLower();
                    if (tn.EndsWith(".view_qualitycontrol") || tn.EndsWith(".bidline") || tn.EndsWith(".reqline") || tn.EndsWith(".serviceline"))
                    {
                        //skip
                    }
                    else
                        LoadFormValues(x, xObject, ChangedProps, ignore);
                }
            }
            return true;
        }

        public static bool GrabFormValues(Control c, nObject xObject)
        {
            return GrabFormValues(c, xObject, null);
        }

        public static bool GrabFormValues(Control c, nObject xObject, List<Control> ignore)
        {
            nEdit ctl;
            foreach (System.Windows.Forms.Control x in c.Controls)
            {
                if (ignore != null)
                {
                    if (ignore.Contains(x))
                        continue;
                }

                if (x.Name == "pContent")  //ctl_marking_quantity
                {
                    ;
                }

                if (x.Name.ToLower().StartsWith("ctl_"))
                {
                    try
                    {
                        ctl = (nEdit)x;
                        switch (ctl.GetControlType().ToLower())
                        {
                            case "modified":
                                break;
                            case "money":
                                xObject.ISet_Conditional(ctl.Name.Substring(4), ctl.GetValue());
                                //try
                                //{
                                //    nEdit_Money m = (nEdit_Money)ctl;
                                //    if (m.ShowCurrency)
                                //        ISet_Conditional(ctl.Name.Substring(4) + "curr", m.GetCurrency());
                                //}
                                //catch (Exception)
                                //{
                                //}
                                break;
                            default:
                                xObject.ISet_Conditional(ctl.Name.Substring(4), ctl.GetValue());
                                break;
                        }
                    }
                    catch (Exception)
                    {                     
                    }
                }
                else
                {
                    String tn = x.GetType().ToString().ToLower();
                    if (tn.EndsWith(".view_qualitycontrol") || tn.EndsWith(".bidline") || tn.EndsWith(".reqline") || tn.EndsWith(".serviceline"))
                    {
                        //skip
                    }
                    else
                        GrabFormValues(x, xObject, ignore);
                }
            }
            return true;
        }
    }
}
