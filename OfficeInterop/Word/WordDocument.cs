using System;
using System.Collections.Generic;
using System.Text;

//using Word = Microsoft.Office.Interop.Word;

namespace OfficeInterop
{
    public class WordDocument
    {
        private Word.Document doc;

        //Public Static Variables
        public static String ErrorMsg = "";

        public WordDocument(Word.Document xd)
        {
            doc = xd;
        }

        public Boolean ReplaceText(String find, String replace, Int32 replace_times)
        {
            ErrorMsg = "";
            try
            {
                Object findText;
                Object replaceText;
                Object replaceTimes;
                Object t = true;
                Object f = false;
                Object wrap = Word.WdFindWrap.wdFindContinue;
                Object missing = System.Reflection.Missing.Value;
                findText = (Object)find;
                replaceText = (Object)replace;
                if (replace_times <= 0)
                    replaceTimes = missing;
                else
                    replaceTimes = (Object)replace_times;
                //To ensure that unwanted formats aren't included as criteria
                //doc.Content.Find.ClearFormatting();
                doc.Content.Find.Text = find;
                doc.Content.Find.Replacement.Text = replace;
                doc.Content.Find.MatchCase = false;
                doc.Content.Find.Execute(ref findText, ref f, ref missing, ref missing, ref missing, ref missing, ref t, ref wrap, ref missing, ref replaceText, ref missing, ref missing, ref missing, ref missing, ref missing);
                return true;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
                return false;
            }
        }

        public bool ReplacePicture(String new_pic)
        {
            object missing = System.Reflection.Missing.Value;
            ErrorMsg = "";
            try
            {
                List<Word.Range> ranges = new List<Word.Range>();
                foreach (Word.InlineShape s in doc.InlineShapes)
                {
                    if (s.Type == Word.WdInlineShapeType.wdInlineShapePicture)
                    {
                        ranges.Add(s.Range);
                        s.Delete();
                    }
                }
                foreach (Word.Range r in ranges)
                {
                    r.InlineShapes.AddPicture(new_pic, ref missing, ref missing, ref missing);
                }
                return true;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
                return false;
            }
        }

        public Boolean SaveAs(String saveasfile)
        {
            ErrorMsg = "";
            try
            {
                Object filename = (Object)saveasfile;
                Object t = true;
                Object f = false;
                Object wrap = Word.WdFindWrap.wdFindContinue;
                Object missing = System.Reflection.Missing.Value;
                doc.SaveAs(ref filename, ref  missing, ref  missing, ref  missing, ref  f, ref missing, ref  missing, ref  missing, ref  missing, ref  missing, ref  missing);
                return true;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
                return false;
            }
        }

        public Boolean Close()
        {
            ErrorMsg = "";
            try
            {
                Object t = true;
                Object f = false;
                Object wrap = Word.WdFindWrap.wdFindContinue;
                Object missing = System.Reflection.Missing.Value;
                doc.Close(ref f, ref missing, ref missing);
                return true;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
                return false;
            }
        }

        public void Activate()
        {
            doc.Activate();
        }

        public String ContentText
        {
            get
            {
                return doc.Content.Text;
            }
        }

        public static Object WdFindWrapwdFindContinue
        {
            get
            {
                return Word.WdFindWrap.wdFindContinue;
            }
        }

        public String ContentFindText
        {
            set
            {
                doc.Content.Find.Text = value;
            }
        }

        public String ContentFindReplacementText
        {
            set
            {
                doc.Content.Find.Replacement.Text = value;
            }
        }

        public bool ContentFindMatchCase
        {
            set
            {
                doc.Content.Find.MatchCase = value;
            }
        }

        public void ContentFindExecute(String findText, Object replaceText)
        {
            Object t = true;
            Object f = false;
            Object missing = System.Reflection.Missing.Value;
            Object ft = (Object)findText;
            Object wrap = WordDocument.WdFindWrapwdFindContinue;
            doc.Content.Find.Execute(ref ft, ref f, ref missing, ref missing, ref missing, ref missing, ref t, ref wrap, ref missing, ref replaceText, ref missing, ref missing, ref missing, ref missing, ref missing);
        }
    }
}
