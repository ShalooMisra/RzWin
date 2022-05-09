using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rz5
{
    public partial class frmBFEmailImport : Form
    {
        //Private Variables
        private ContextRz TheContext;
        private String CurrentSearchString
        {
            get
            {
                return NewMethod.n_set.GetSetting(RzWin.Context, "bf_email_import_search_string");
            }
            set
            {
                NewMethod.n_set.SetSetting(RzWin.Context, "bf_email_import_search_string", value);
                ctl_search_value.SetValue(value);
            }
        }

        //Constructors
        public frmBFEmailImport()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad(ContextRz x)
        {
            if (x == null)
                return false;
            TheContext = x;
            lblUP.Visible = Tools.Misc.IsDevelopmentMachine();
            ctl_search_value.SetValue(CurrentSearchString);
            wb1.Navigate("http://www.brokerforum.com");
            return true;
        }
        //Private Functions
        private void ImportEmails()
        {
            try
            {
                while (Tools.Strings.StrExt(CurrentSearchString))
                {
                    wb1.Navigate("http://www.brokerforum.com/iris-member-advanced.search-en.jsa");
                    wb1.WaitForDone();
                    wb1.SetTextBox("country", "US");
                    SetCompanySearch((mshtml.IHTMLDocument2)(wb1.GetDocument()));
                    ClickSearchButton((mshtml.IHTMLDocument2)(wb1.GetDocument()));
                    wb1.WaitForDone();
                    ProcessSearchResults();
                    SetNextSearchString();
                }
            }
            catch { }
        }
        private void ProcessSearchResults()
        {
            try
            {
                StringBuilder sTable = new StringBuilder();
                foreach (mshtml.IHTMLElement e in wb1.GetDocument().all)
                {
                    if (Tools.Strings.StrCmp(e.tagName, "a"))
                    {
                        mshtml.HTMLAnchorElement a = (mshtml.HTMLAnchorElement)e;
                        if (a.href != null)
                        {
                            if (a.href.ToLower().Contains("company.profile-view"))
                            {
                                wb2.Navigate(a.href);
                                wb2.WaitForDone();
                                ImportCompanyEmails();
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private void ImportCompanyEmails()
        {
            try
            {
                int count = 0;
                BFEmails bfe = new BFEmails();
                foreach (mshtml.IHTMLElement e in wb2.GetDocument().all)
                {
                    if (Tools.Strings.StrCmp(e.tagName, "h1"))
                    {
                        count++;
                        if (count == 3)
                        {
                            bfe.Company = e.innerText.Trim();
                            break;
                        }
                    }
                }
                foreach (mshtml.IHTMLElement e in wb2.GetDocument().all)
                {
                    if (Tools.Strings.StrCmp(e.tagName, "div"))
                    {
                        mshtml.HTMLDivElement d = (mshtml.HTMLDivElement)e;
                        if (d.innerText != null)
                        {
                            if (d.innerText.ToLower().Contains("email address:"))
                            {
                                bfe.Contact = "Main";
                                bfe.Email = Tools.Strings.ParseDelimit(Tools.Strings.ParseDelimit(d.innerHTML, "mailto:", 2).Trim(), "\"", 1).Trim();
                                bfe.Save(TheContext);
                                break;
                            }
                        }
                    }
                }
                bool next = false;
                foreach (mshtml.IHTMLElement e in wb2.GetDocument().all)
                {
                    if (Tools.Strings.StrCmp(e.tagName, "div"))
                    {
                        mshtml.HTMLDivElement d = (mshtml.HTMLDivElement)e;
                        if (d.innerText != null)
                        {
                            if (next)
                            {
                                string[] body = Tools.Strings.Split(d.innerText, "\r\n");
                                bool first = true;
                                bool gap = false;
                                BFEmails bf = new BFEmails();
                                bf.Company = bfe.Company;
                                foreach (string s in body)
                                {
                                    if (first)
                                    {
                                        bf.Contact = s.Trim(); 
                                        first = false;
                                        continue;
                                    }
                                    if (!Tools.Strings.StrExt(s))
                                        continue;
                                    if (gap)
                                    {
                                        gap = false;
                                        bf = new BFEmails();
                                        bf.Company = bfe.Company;
                                        bf.Contact = s.Trim();
                                    }
                                    if (s.Contains("@"))
                                    {
                                        bf.Email = s.Trim();
                                        bf.Save(TheContext);
                                        gap = true;
                                    }
                                }
                                break;
                            }
                            if (Tools.Strings.StrCmp(d.innerText, "Contacts"))
                                next = true;
                        }
                    }
                }
            }
            catch { }
        }
        private bool SetCompanySearch(mshtml.IHTMLDocument2 xDoc)
        {
            try
            {
                mshtml.IHTMLElement body;
                body = xDoc.body;
                mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)(body.all);
                System.Collections.IEnumerator en = col.GetEnumerator();
                mshtml.IHTMLElement ele;
                mshtml.IHTMLInputElement inp;
                bool found = false;
                bool yes;
                while (en.MoveNext())
                {
                    ele = (mshtml.IHTMLElement)(en.Current);
                    String s = ele.tagName;
                    if (String.Compare(ele.tagName.ToLower(), "input") == 0)
                    {
                        inp = (mshtml.IHTMLInputElement)(ele);
                        yes = false;
                        if (Tools.Strings.StrCmp("Q", inp.name) && (!Tools.Strings.StrCmp(inp.type, "hidden")))
                        {
                            if (!found)
                            {
                                found = true;
                                continue;
                            }
                            yes = true;
                        }
                        if (yes)
                        {
                            inp.value = CurrentSearchString;
                            return true;
                        }
                    }
                }
                Object fr = xDoc.frames;
                mshtml.IHTMLFramesCollection2 frames = (mshtml.IHTMLFramesCollection2)xDoc.frames;
                for (int j = 0; j < frames.length; j++)
                {
                    Int32 n = Convert.ToInt32(j);
                    Object oFrameIndex = (Object)(n);
                    mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex));
                    Object d = frame.document;
                    try
                    {
                        mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)(d);
                        if (SetCompanySearch(frameDoc))
                            return true;
                    }
                    catch { }
                }
            }
            catch { }
            return false;
        }
        private bool ClickSearchButton(mshtml.IHTMLDocument2 xDoc)
        {
            mshtml.IHTMLElement body = xDoc.body;
            mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)(body.all);
            System.Collections.IEnumerator en = col.GetEnumerator();
            mshtml.IHTMLElement ele;
            mshtml.IHTMLElement anc;
            mshtml.IHTMLInputElement inp;
            bool found = false;
            bool yes;
            while (en.MoveNext())
            {
                ele = (mshtml.IHTMLElement)(en.Current);
                if (String.Compare(ele.tagName.ToLower(), "input") == 0)
                {
                    anc = (mshtml.IHTMLElement)(ele);
                    yes = false;
                    inp = (mshtml.IHTMLInputElement)(anc);
                    if (Tools.Strings.StrCmp("submitButton", inp.name))
                        yes = true;
                    if (Tools.Strings.StrCmp("Find", inp.value))
                        yes = true;
                    if (yes)
                    {
                        if (!found)
                        {
                            found = true;
                            continue;
                        }
                        anc.click();
                        for (int j = 0; j < 20; j++)
                        {
                            if (wb1.WaitForDone())
                                return true;
                        }
                        return wb1.WaitForDone();
                    }
                }
            }
            mshtml.IHTMLFramesCollection2 frames = xDoc.frames;
            for (int j = 0; j < frames.length; j++)
            {
                Int32 n = Convert.ToInt32(j);
                Object oFrameIndex = (Object)n;
                mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex));
                Object d = frame.document;
                try
                {
                    mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)(d);
                    if (ClickSearchButton(frameDoc))
                        return true;
                }
                catch { }
            }
            return false;
        }
        private void SetNextSearchString()
        {
            if (!Tools.Strings.StrExt(CurrentSearchString))
            {
                CurrentSearchString = "000";
                return;
            }
            string s1 = CurrentSearchString.Substring(0, 1);
            string s2 = CurrentSearchString.Substring(1, 1);
            string s3 = CurrentSearchString.Substring(2, 1);
            bool roll = false;
            s3 = Increment(s3, ref roll);
            if (roll)
            {
                roll = false;
                s2 = Increment(s2, ref roll);
            }
            if (roll)
            {
                roll = false;
                s1 = Increment(s1, ref roll);
                if (roll)
                    CurrentSearchString = "";
            }
            CurrentSearchString = s1 + s2 + s3;
        }
        private string Increment(string s, ref bool roll)
        {
            roll = false;
            switch (s.ToLower())
            {
                case "0":
                    return "1";
                case "1":
                    return "2";
                case "2":
                    return "3";
                case "3":
                    return "4";
                case "4":
                    return "5";
                case "5":
                    return "6";
                case "6":
                    return "7";
                case "7":
                    return "8";
                case "8":
                    return "9";
                case "9":
                    return "a";
                case "a":
                    return "b";
                case "b":
                    return "c";
                case "c":
                    return "d";
                case "d":
                    return "e";
                case "e":
                    return "f";
                case "f":
                    return "g";
                case "g":
                    return "h";
                case "h":
                    return "i";
                case "i":
                    return "j";
                case "j":
                    return "k";
                case "k":
                    return "l";
                case "l":
                    return "m";
                case "m":
                    return "n";
                case "n":
                    return "o";
                case "o":
                    return "p";
                case "p":
                    return "q";
                case "q":
                    return "r";
                case "r":
                    return "s";
                case "s":
                    return "t";
                case "t":
                    return "u";
                case "u":
                    return "v";
                case "v":
                    return "w";
                case "w":
                    return "x";
                case "x":
                    return "y";
                case "y":
                    return "z";
                case "z":
                    roll = true;
                    return "0";
                default:
                    return s;
            }
        }
        //Control Events
        private void lblUP_Click(object sender, EventArgs e)
        {
            ToolsWin.Clipboard.SetClip("mildredramsey");
        }
        private void lblUP_DoubleClick(object sender, EventArgs e)
        {
            ToolsWin.Clipboard.SetClip("abarth");
        }
        //Buttons
        private void cmdImport_Click(object sender, EventArgs e)
        {
            SetNextSearchString();
            ImportEmails();
        }
        private void cmdReset_Click(object sender, EventArgs e)
        {
            CurrentSearchString = "";
            ctl_search_value.SetValue(CurrentSearchString);
        }
        //Private Classes
        private class BFEmails
        {
            public string Company = "";
            public string Contact = "";
            private string emailad = "";
            public string Email
            {
                get
                {
                    return emailad;
                }
                set
                {
                    if (!Tools.Email.IsEmailAddress(value))
                        emailad = "";
                    else
                        emailad = value;
                }
            }
            public void Save(ContextRz TheContext)
            {
                if (!Tools.Strings.StrExt(Email))
                    return;

                RzWin.Context.Execute("insert into bf_emails (email_address,companyname,contactname) values ('" + RzWin.Context.Filter(Email) + "','" + RzWin.Context.Filter(Company) + "','" + RzWin.Context.Filter(Contact) + "')");
            }
        }
    }
}
