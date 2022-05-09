using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;

using Core;
using NewMethod;
using System.IO;

namespace Rz5
{
    public class PanelLogic : NewMethod.Logic
    {
        public override void ActsListStatic(Context x, ActSetup acts)
        {
            ContextRz xrz = (ContextRz)x;

            ActHandle h = new ActHandle(new Act("Panel", new ActHandler(PanelShow)));
            acts.Add(h);

            xrz.Leader.AddPanelOptions(xrz, this, h);

            ActHandle users = new ActHandle(new Act("User Accounts", new ActHandler(UserAccountsShow)));
            //ActHandle h = acts.Find("Panel");
            if (((ContextRz)x).xUserRz.SuperUser)
                h.SubActs.Add(new ActHandle(new Act("User Information Changes", new ActHandler(i_Click))));
            if (((ContextRz)x).xUserRz.IsDeveloper())
                h.SubActs.Add(new ActHandle(new Act("Inspection Report Test", new ActHandler(InspectionReportTest_Click))));
        }


        private void i_Click(Context x, ActArgs args)
        {
            ((ILeaderRz)x.Leader).ShowUserInfoChanges();
        }
        private void InspectionReportTest_Click(Context x, ActArgs args)
        {
            String file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + "SensibleTest.pdf";
            try
            {
                if (File.Exists(file))
                    File.Delete(file);
            }
            catch { file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + Tools.Strings.GetNewID() + "_SensibleTest.pdf"; };

            String face = "Arial";
            float size = 12.0f;
            int left = 50;

            Tools.PDFWrapper pdf = new Tools.PDFWrapper(file, false);

            //using (Image i = Image.FromFile())
            //{
            //i.Save(@"c:\bilge\Sensible.jpg");
            pdf.DrawImage(Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + "Sensible.jpg", 25, 10);
            //}

            Font font = new Font(face, 22.0f, FontStyle.Bold);
            pdf.DrawString("Inspection Report", font, Color.Black, new Point(300, 100));


            Point p = new Point(left, 190);
            font = new Font(face, size);

            pdf.DrawLineHoriz(Pens.Gray, ref p);
            pdf.DrawCaptionValueReturn(ref p, "Customer Name:", "Brooks Automation", font);
            pdf.DrawCaptionValueReturn(ref p, "Customer PO:", "BROOKSPO", font);
            pdf.DrawCaptionValueReturn(ref p, "Sales Order#:", "0117856", font);
            pdf.DrawCaptionValueReturn(ref p, "Inspection Date:", "05/20/2011", font);
            pdf.DrawCaptionValueReturn(ref p, "Inspector Initials:", "SJM", font);

            p.Y += 5;

            pdf.DrawLineHoriz(Pens.Gray, ref p);
            pdf.DrawStringReturn(ref p, "Product Description", new Font(font, FontStyle.Underline));
            pdf.DrawCaptionValueReturn(ref p, "Part#:", "TMS320PBKAMNFGIAB", font);
            pdf.DrawCaptionValueReturn(ref p, "MFG:", "TEXAS INSTRUMENTS", font);
            pdf.DrawCaptionValueReturn(ref p, "QTY:", "4800", font);

            p.Y += 5;

            pdf.DrawLineHoriz(Pens.Gray, ref p);
            pdf.DrawStringReturn(ref p, "Receiving Info:", new Font(font, FontStyle.Underline));
            pdf.DrawCaptionValueReturn(ref p, "Condition:", "Static Bag, tubes slightly bent, but no indication of part damage as result", font);
            pdf.DrawCaptionValueReturn(ref p, "Packaging:", "MFG Tubes", font);
            pdf.DrawCaptionValueReturn(ref p, "Qty per PKG Unit:", "48 Tubes @ 100pcs /tube", font);

            pdf.DrawCaptionValueReturn(ref p, "Date Code:", "0910", font);
            pdf.DrawCaptionValueReturn(ref p, "COO:", "Thailand", font);
            pdf.DrawCaptionValueReturn(ref p, "RoHS?:", "N", font);
            pdf.DrawCaptionValueReturn(ref p, "PIN1 Orientation:", "Matches MFG specification", font);
            pdf.DrawCaptionValueReturn(ref p, "Part Marking Authenticity:", "Pass", font);
            pdf.DrawCaptionValueReturn(ref p, "Evidence of secondary coating:", "No", font);
            pdf.DrawCaptionValueReturn(ref p, "Evidence of scratches / sanding:", "No", font);
            pdf.DrawCaptionValueReturn(ref p, "Evidence of Solder / Oxidation damage?", "No", font);
            pdf.DrawCaptionValueReturn(ref p, "Other  inconsistencies?", "No", font);

            p.Y += 5;

            pdf.DrawLineHoriz(Pens.Gray, ref p);
            pdf.DrawStringReturn(ref p, "Images:", new Font(font, FontStyle.Underline));

            p.X = left;
            p.Y += 10;
            pdf.DrawImageWithCaption(font, Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + "Sensible1.jpg", "Part markings consistent with MFG spec", p);

            p.X = 400;
            pdf.DrawImageWithCaption(font, Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + "Sensible2.jpg", "No visible smearing from Acetone test", p);

            p.X = left;
            p.Y += 150;
            pdf.DrawImageWithCaption(font, Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + "Sensible3.jpg", "Pin1 Orientation consistent with MFG Spec", p);

            pdf.CloseDoc();

            Tools.FileSystem.Shell(file);
        }

        public void UserAccountsShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.UserAccountsShow((ContextRz)x);
            args.Result(true);
        }

        public void PanelShow(Context x, ActArgs args)
        {
            args.Result(PanelShow((ContextRz)x));
        }

        public void UpdateCheck(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.UpdateCheck((ContextRz)x);
            args.Result(true);
        }
        //public void LiveSupportRequest(Context x)
        //{
        //    LiveSupportRequest(x, new ActArgs());
        //}
        public void ScanBrokerForumBids(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.ScanBrokerForumBids((ContextRz)x);
        }
        public void ScanBrokerForumRFQs(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.ScanBrokerForumRFQs((ContextRz)x);
        }
        //public void LiveSupportRequest(Context x, ActArgs args)
        //{
        //    ((ContextRz)x).TheLeaderRz.LiveSupportRequest((ContextRz)x);
        //    args.Result(true);
        //}
        public void DatabaseManagerShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.DatabaseManagerShow((ContextRz)x);
            args.Result(true);
        }
        public void QuickBooksSettingsShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.QuickBooksSettingsShow((ContextRz)x);
            args.Result(true);
        }
        public void PhoneMonitorShow(Context x)
        {
            PhoneMonitorShow(x, new ActArgs());
        }
        public void PhoneMonitorShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.PhoneMonitorShow((ContextRz)x);
            args.Result(true);
        }
        public void DutyMonitorShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.DutyMonitorShow((ContextRz)x);
            args.Result(true);
        }
        public void TestOptionsShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.TestOptionsShow((ContextRz)x);
            args.Result(true);
        }
        public void CreditCardNumbersShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.CreditCardNumbersShow((ContextRz)x);
            args.Result(true);
        }
        public void ConvertToRz4Show(Context x, ActArgs args)
        {
            x.TheLeader.Reorg();
            //((LeaderWinUserRz)x.TheLeader).TheRzForm.TabShow(new Win.Screens.ConvertToRz4(), "Convert To Rz4");
        }

        public void ConvertToRz4NowTo2009(Context x, ActArgs args)
        {
            ImportRz3 i = new ImportRz3();
            i.ImportNowTo2009((ContextRz)x);
            x.TheLeader.Tell("Done");
            args.Result(true);
        }
        public void ConvertToRz42009To2005(Context x, ActArgs args)
        {
            ImportRz3 i = new ImportRz3();
            i.Import2009To2005((ContextRz)x);
            x.TheLeader.Tell("Done");
            args.Result(true);
        }
        public void ConvertToRz4Finish(Context x, ActArgs args)
        {
            ImportRz3 i = new ImportRz3();
            i.ImportFinish((ContextRz)x);
            x.TheLeader.Tell("Done");
            args.Result(true);
        }

        public void ConvertToRz4Prep(Context x, ActArgs args)
        {
            ImportRz3 i = new ImportRz3();
            i.ImportPrep((ContextRz)x);
            x.TheLeader.Tell("Done");
            args.Result(true);
        }
        public void ResSaveAllOrderInstances(Context x)
        {
            ImportRz3 i = new ImportRz3();
            i.ResSaveAllOrderInstances((ContextRz)x);
            x.TheLeader.Tell("Done");
        }
        public virtual bool PanelShow(ContextRz x)
        {
            if (!x.CheckPermit(NewMethod.Permissions.ThePermits.ViewPanel))
            {
                x.TheLeader.ShowNoRight();
                return false; ;
            }

            ((ILeaderRz)x.TheLeader).UserPanelShow((ContextRz)x);
            return true;
        }
        public void RestoreOrder(Context x, ActArgs args)
        {
            //why was this passed to the leader, which passes it right back to the logic?
            //((ILeaderRz)x.TheLeader).RestoreOrder((ContextRz)x);    
            ordhed.Restore((ContextRz)x);
        }
        public void RestoreOrderLine(Context x, ActArgs args)
        {
            //((ILeaderRz)x.TheLeader).RestoreOrderLine((ContextRz)x);
            orddet.Restore((ContextRz)x);
        }
        public void RestoreCompany(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).RestoreCompany((ContextRz)x);
        }
        public void RestoreContact(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).RestoreContact((ContextRz)x);
        }
        public void RestoreItem(Context x, ActArgs args)
        {
            x.Reorg();

            //String classId = x.TheLeader.AskForString("Class");
            //if (!Tools.Strings.StrExt(classId))
            //    return;

            //String uniqueId = x.TheLeader.AskForString("UID");
            //if (!Tools.Strings.StrExt(uniqueId))
            //    return;

            //ContextRz contextrz = (ContextRz)x;

            //if (!contextrz.xSys.Recall)
            //{
            //    x.TheLeader.Tell("This system isn't set up for Recall.");
            //    return;
            //}

            //string strSQL = "select unique_id from " + classId + " where unique_id = '" + uniqueId + "'";
            //string s = contextrz.xSys.xData.GetScalar(strSQL, "");
            //if (Tools.Strings.StrExt(s))
            //{
            //    x.TheLeader.Tell("This item already appears to exist in the main database.");
            //    return;
            //}
            //s = contextrz.xSys.recall_connection.GetScalar(strSQL, "");
            //if (!Tools.Strings.StrExt(s))
            //{
            //    x.TheLeader.Tell("This contact wasn't found in the Recall system.");
            //    return;
            //}

            //DataTable st = contextrz.xSys.recall_connection.GetDataTable("select top 1 * from " + classId);
            //SortedList props = contextrz.xSys.GetPropsByClass(classId);
            //strSQL = "";
            //ArrayList a = new ArrayList();
            //foreach (DictionaryEntry d in props)
            //{
            //    n_prop p = (n_prop)d.Value;
            //    //only restore fields that exist in the backup
            //    if (!p.IsUniqueID)
            //    {
            //        if (nData.HasField(st, p.name))
            //        {
            //            if (!nTools.IsInArray(p.name, a))
            //            {
            //                if (Tools.Strings.StrExt(strSQL))
            //                    strSQL += ", ";
            //                strSQL += p.name;
            //                a.Add(p.Name);
            //            }
            //        }
            //    }
            //}

            //strSQL = "insert into " + contextrz.xSys.xData.database_name + ".dbo." + classId + "(unique_id, " + strSQL + ") select top 1 unique_id, " + strSQL + " from " + classId + " where unique_id = '" + s + "' and recall_type = 3";
            //if (contextrz.xSys.recall_connection.Execute(strSQL))
            //{
            //    contextrz.Show(new ItemTag(classId, uniqueId));
            //    contextrz.TheLeader.Tell("Done.");
            //}
            //else
            //{
            //    contextrz.TheLeader.Tell("The restore was not successful.");
            //}
        }
        //public void ShowHelpPDF(ContextRz x)
        //{
        //    x.TheLeaderRz.ShowHelp(x);
        //}
        //public virtual StockValueReport GetStockValueReport()
        //{
        //    return new StockValueReport();
        //}
        public virtual void ShowStockValueReport(ContextRz x)
        {                        
            ((ILeaderRz)x.Leader).ReportShow(x, new StockValueReport(x), true);
        }
        public virtual void TakeScreenShot(Context x, ActArgs args)
        {
            try
            {
                int screenWidth = Screen.GetBounds(new Point(0, 0)).Width;
                int screenHeight = Screen.GetBounds(new Point(0, 0)).Height;
                Bitmap bmpScreenShot = new Bitmap(screenWidth, screenHeight);
                Graphics gfx = Graphics.FromImage((Image)bmpScreenShot);
                gfx.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));
                string folder = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "Junk\\");
                nTools.MakeFolderExist(folder);
                string file = folder + Tools.Strings.GetNewID() + ".jpg";
                bmpScreenShot.Save(file, ImageFormat.Jpeg);
                if (!Tools.Files.FileExists(file))
                {
                    x.TheLeader.Tell("This screenshot failed to save. Please try again.");
                    return;
                }
                Tools.FileSystem.Shell("mspaint.exe", file);
            }
            catch (Exception ee)
            {
                x.TheLeader.Tell("There was an error creating this screenshot: " + ee.Message);
            }
        }


        public void QuoteToSaleRatio(Context x)
        {
            Rz5.Reports.QuoteToSale r = new Rz5.Reports.QuoteToSale((ContextRz)x);
            ((ContextRz)x).TheLeaderRz.ReportShow((ContextRz)x, r, true);
        }

    }
}
