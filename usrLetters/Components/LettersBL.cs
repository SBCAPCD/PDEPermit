using System;
using System.IO;
using System.Globalization;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PDEPermit.Letters
{
    public class LettersBL
    {
        private static int LetterNo;
        private static DataSet dsLetterDocumentData = new DataSet();
        private static System.Windows.Forms.ProgressBar LetterProgressBar;
        static object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;

        public static void GetLettersByPermit(string conString, string permitNo, DataSet dsLetters)
        {
            dsLetters.Clear();
            try
            {
                 SbcapcdOrg.PDEPermit.Letters.LettersDL.GetLettersByPermit(conString, permitNo, dsLetters);

            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Letters:GetLetters:GetPdeLetters");
            }
        }

        public static void GetLettersAux(string conString, DataSet dsLettersAux)
        {
            dsLettersAux.Clear();

            try
            {
                SbcapcdOrg.PDEPermit.Letters.LettersDL.GetLettersAux(conString, dsLettersAux);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Letters:GetLetters:GetPdeLetters");
            }
        }

        public void GetLetterByLetterNo(string conString, int letterNo, DataSet dsLetter)
        {
            dsLetter.Clear();

            try
            {
                SbcapcdOrg.PDEPermit.Letters.LettersDL getLetterByLetterNo = new LettersDL();
                getLetterByLetterNo.GetLetterByLetterNo(conString, letterNo, dsLetter);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersBL:GetLetterByLetterNo");
            }
        }
        
        private static void GetLetterData(string conString, int letterNo)
        {
            SbcapcdOrg.PDEPermit.Letters.LettersDL.GetLetterData(conString, letterNo);
        }

        public bool SaveLetter(string conString, DataSet dsLetter)
        {
            bool TransactionOK = false;
            try
            {
                SbcapcdOrg.PDEPermit.Letters.LettersDL saveLetter = new LettersDL();
                return saveLetter.SaveLetter(conString, dsLetter);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersBL:SaveLetter");
                return TransactionOK;
            }
            finally
            {
            }
        }

        public static int GetNewLetterId(string conString)
        {
            try
            {
                return SbcapcdOrg.PDEPermit.Letters.LettersDL.GetNewLetterId(conString);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersBL:GetNewLetterId");
                return -1;
            }
        }

        public static void GetCCsByCompany(string conString, string companyNo, System.Windows.Forms.ListBox lbxContactPickList)
        {
            try
            {
                DataSet dsContactsByCompany = SbcapcdOrg.PDEPermit.Letters.LettersDL.GetCCsByCompany(conString, companyNo);
                lbxContactPickList.DataSource = dsContactsByCompany.Tables[0];
                lbxContactPickList.DisplayMember = "Name";
                lbxContactPickList.ValueMember = "ContactName";
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "OfficeDocuments:GetProjectsByPermit");
            }
            finally
            {
            }
        }

        public static void GetCCsByPermit(string conString, string permitNo, System.Windows.Forms.ListBox lbxContactPickList)
        {
            try
            {
                DataSet dsContactsByCompany = SbcapcdOrg.PDEPermit.Letters.LettersDL.GetCCsByPermit(conString, permitNo);
                lbxContactPickList.DataSource = dsContactsByCompany.Tables[0];
                lbxContactPickList.DisplayMember = "Name";
                lbxContactPickList.ValueMember = "ContactName";
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "OfficeDocuments:GetProjectsByPermit");
            }
            finally
            {
            }
        }

        public static void GetAllCCs(string conString, System.Windows.Forms.ListBox lbxContactPickList)
        {
            try
            {
                DataSet dsContactsByCompany = SbcapcdOrg.PDEPermit.Letters.LettersDL.GetAllCCs(conString);
                lbxContactPickList.DataSource = dsContactsByCompany.Tables[0];
                lbxContactPickList.DisplayMember = "Name";
                lbxContactPickList.ValueMember = "ContactName";
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "OfficeDocuments:GetProjectsByPermit");
            }
            finally
            {
            }
        }

        #region Word

        public static string GenerateLetter(string conString, int letterNo, System.Windows.Forms.ProgressBar progressBar)
        {
            DialogResult Answer;
            object missingValue = Type.Missing;
            Word.Document LetterDoc = null;
            Object HeaderFileObj;
            Word.Bookmarks Bmrk;
            object oBookmark;
            object oBookmark2;

            Object ReadOnly = true;
            Object AddToRecentFiles = false;
            Object NoSaveChanges = false;
            Object Visible = true;
            LetterProgressBar = progressBar;
            LetterProgressBar.PerformStep();
            string Message = "";
            LetterNo = letterNo;
            //int WordFileCount = 0;
            string SaveFileName = "";
            string TemplateFileName = "";
            string HeaderFileName = "";
            Word.Range Rng;
            DataSet dsLetterDocumentData = new DataSet();
            Hashtable BookmarksHT = new Hashtable();

            ///////////////////////
            // RETRIEVE THE DATA //
            ///////////////////////

            try
            {
                dsLetterDocumentData.Clear();
                dsLetterDocumentData = SbcapcdOrg.PDEPermit.Letters.LettersDL.GetLetterData(conString, letterNo);

                foreach (DataColumn tableCol in dsLetterDocumentData.Tables["BookmarkDataTables"].Columns)
                {
                    string tableName = dsLetterDocumentData.Tables["BookmarkDataTables"].Rows[0][tableCol.ColumnName.ToString()].ToString();

                    if (dsLetterDocumentData.Tables[tableName] != null)
                    {
                        foreach (DataRow row in dsLetterDocumentData.Tables[tableName].Rows)
                        {
                            foreach (DataColumn col in dsLetterDocumentData.Tables[tableName].Columns)
                            {
                                if (!BookmarksHT.Contains(col.ColumnName.ToString()))
                                {
                                    SetHashtable(BookmarksHT, col.ColumnName.ToString(), row[col].ToString());
                                }
                            }
                        }
                    }
                }

				if (	BookmarksHT.Contains("LetterTypeId") &&
						(BookmarksHT["LetterTypeId"].ToString() == "17"
						|| BookmarksHT["LetterTypeId"].ToString() == "16")
					)
				{
					if (BookmarksHT.Contains("NovList") && BookmarksHT["NovList"].ToString().Length > 0)
					{
						MessageBox.Show("This facility or equipment has the following unresolved NOVs: " + BookmarksHT["NovList"].ToString()
						+ Environment.NewLine + Environment.NewLine +
						"Confirm that these outstanding NOVs are non-significant violations before continuing. See Engineering Supervisor if you have any questions."
						, "Facility has NOVs", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

                LetterProgressBar.PerformStep();

                HeaderFileName = GetHashtableValue(BookmarksHT, "HeaderFileName").ToString();
                TemplateFileName = GetHashtableValue(BookmarksHT, "TemplateFileName").ToString();

                //foreach (DataRow row in dsLetterDocumentData.Tables["LetterTemplateFiles"].Rows)
                //{
                //    switch (row["FileType"].ToString())
                //    {
                //        case "Header":
                //            HeaderFileName = row["FileName"].ToString();
                //            break;
                //        case "Template":
                //            TemplateFileName = row["FileName"].ToString();
                //            break;
                //        default:
                //            break;
                //    }
                //}

                //////////////////////////////////
                // START DOCUMENT CONCATENATION //
                //////////////////////////////////


                Word.Application WordApplication = new Word.Application();


                WordApplication.Visible = true;

                HeaderFileObj = HeaderFileName;

                if (LetterProgressBar != null)
                {
                    LetterProgressBar.PerformStep();
                }

                try
                {
                    LetterDoc = WordApplication.Documents.Add(ref HeaderFileObj, ref missingValue, ref missingValue, ref Visible);
                    LetterDoc.ShowRevisions = false;
                    LetterDoc.Activate();
                    LetterDoc.ActiveWindow.Visible = true;

                    oBookmark = "Header";
                    Bmrk = LetterDoc.Bookmarks;

                    oBookmark = "LetterTemplate";
                    Word.Bookmark bmkLetterTemplate = (Word.Bookmark)LetterDoc.Bookmarks.get_Item(ref oBookmark);

                    if (bmkLetterTemplate != null)
                    {
                        Rng = bmkLetterTemplate.Range;
                        Rng.Text = "";
                        Rng.InsertFile(TemplateFileName, ref missingValue, ref missingValue, ref missingValue, ref missingValue);
                    }
                }
                catch (Exception ex)
                {
                    SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersBL:Error creating Word Doc");
                    ((Microsoft.Office.Interop.Word._Document)LetterDoc).Close(ref saveChanges, ref missingValue, ref missingValue);
                }

                Object SaveFileObj = null;

                if ((GetHashtableValue(BookmarksHT, "TemplateFileName").ToString()).EndsWith("\\"))
                {
                    SaveFileObj = (GetHashtableValue(BookmarksHT, "SaveFolder").ToString()) + (GetHashtableValue(BookmarksHT, "LetterName").ToString());
                    SaveFileName = SaveFileObj.ToString();
                }
                else
                {
                    SaveFileObj = (GetHashtableValue(BookmarksHT, "SaveFolder").ToString()) + @"\" + (GetHashtableValue(BookmarksHT, "LetterName").ToString());
                    //SaveFileObj = dsLetterDocumentData.Tables["LetterData"].Rows[0]["SaveFolder"].ToString() + @"\" + dsLetterDocumentData.Tables["LetterData"].Rows[0]["LetterName"].ToString();
                    SaveFileName = SaveFileObj.ToString();
                }

                if (LetterProgressBar != null)
                {
                    LetterProgressBar.PerformStep();
                }

                if (File.Exists(SaveFileName))
                {
                    Answer = MessageBox.Show("Letter exists. Do you want to overwrite it?", "Letter exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Answer == DialogResult.Yes)
                    {
                        LetterDoc.SaveAs(ref SaveFileObj
                            , ref missingValue, ref missingValue, ref missingValue
                            , ref missingValue, ref missingValue, ref missingValue
                            , ref missingValue, ref missingValue, ref missingValue
                            , ref missingValue, ref missingValue, ref missingValue
                            , ref missingValue, ref missingValue, ref missingValue
                            );
                    }
                }
                else
                {
                    LetterDoc.SaveAs(ref SaveFileObj
                        , ref missingValue, ref missingValue, ref missingValue
                        , ref missingValue, ref missingValue, ref missingValue
                        , ref missingValue, ref missingValue, ref missingValue
                        , ref missingValue, ref missingValue, ref missingValue
                        , ref missingValue, ref missingValue, ref missingValue
                        );
                }

                //////////////////////////////
                // DO BOOKMARK SUBSTITUTION //
                //////////////////////////////

                oBookmark = "MailingMethod";
                Word.Bookmark bmkMailingMethod = (Word.Bookmark)LetterDoc.Bookmarks.get_Item(ref oBookmark);

                if ((GetHashtableValue(BookmarksHT, "ReturnReceipt").ToString() == "True"))
                {
                    bmkMailingMethod.Range.Text = "\vCertified Mail\vReturn Receipt Requested";
                }
                else
                {
                    bmkMailingMethod.Range.Text = "";
                }

                oBookmark = "Logo";
                Word.Bookmark bmkLogo = (Word.Bookmark)LetterDoc.Bookmarks.get_Item(ref oBookmark);

                oBookmark2 = "Footer";
                Word.Bookmark bmkFooter = (Word.Bookmark)LetterDoc.Bookmarks.get_Item(ref oBookmark2);

                //if (!letterHead)
                //{
                //    bmkLogo.Range.Text = "";
                //    bmkFooter.Range.Text = "";
                //}

                string SkippedBookmarks = "";
                string RemovedBookmarks = "";
                StringBuilder MissingBookmarks = new StringBuilder("");

                if (dsLetterDocumentData.Tables["PermitActionHist"] != null)
                {
                    foreach (DataRow row in dsLetterDocumentData.Tables["PermitActionHist"].Rows)
                    {
                        BookmarksHT.Add(row["PermitAction"].ToString(), row["PermitActionDate"].ToString());
                    }
                }

                if (LetterProgressBar != null)
                {
                    LetterProgressBar.PerformStep();
                }

                oBookmark = "CC";
                if ((Word.Bookmark)LetterDoc.Bookmarks.get_Item(ref oBookmark) != null)
                {
                    Word.Bookmark bmkCC = (Word.Bookmark)LetterDoc.Bookmarks.get_Item(ref oBookmark);

                    Rng = bmkCC.Range;

                    if (dsLetterDocumentData.Tables["LetterCcData"].Rows.Count > 0)
                    {
                        foreach (DataRow myRow in dsLetterDocumentData.Tables["LetterCcData"].Rows)
                        {
                            Rng.Text = "\t" + myRow["CompleteName"].ToString() + "\n";
                            Rng.SetRange(Rng.End, Rng.End);
                        }
                    }
                    else
                    {
                        Rng.Text = "";
                    }
                }

                if (LetterProgressBar != null)
                {
                    LetterProgressBar.PerformStep();
                }

                foreach (Word.Bookmark bmrk in LetterDoc.Bookmarks)
                {
                    string BookmarkName;
                    if (bmrk.Name.ToString().IndexOf("_") > 0)
                    {
                        BookmarkName = bmrk.Name.Substring(0, bmrk.Name.ToString().IndexOf("_"));
                    }
                    else
                    {
                        BookmarkName = bmrk.Name.ToString();
                    }

                    if (BookmarksHT.Contains(BookmarkName))
                    {
                        switch (BookmarksHT[BookmarkName].ToString())
                        {
                            case "true":
                                break;
                            case "false":
                            case "False":
                                bmrk.Range.Text = "";
                                break;
                            default:
                                bmrk.Range.Text = BookmarksHT[BookmarkName].ToString().Replace("~", "\n\t").Replace("^", "\n");
                                break;
                        }
                    }
                    else
                    {
                        switch (bmrk.Name.ToString())
                        {
                            case "DESCRIPTION":
                                Rng = bmrk.Range;
                                if (dsLetterDocumentData.Tables["InsertedText"].Select("BookmarkTypeId = 6", "", DataViewRowState.CurrentRows).GetUpperBound(0) >= 0)
                                {
                                    foreach (DataRow dr in dsLetterDocumentData.Tables["InsertedText"].Select("BookmarkTypeId = 6", "", DataViewRowState.CurrentRows))
                                    {
                                        Rng.Text = dr["TextInsert"].ToString();
                                        Rng.SetRange(Rng.End, Rng.End);
                                    }
                                }
                                else
                                {
                                    Rng.Text = "";
                                    Rng.SetRange(Rng.End, Rng.End);
                                }
                                break;
                            case "OPTIONALTEXT":
                                Rng = bmrk.Range;
                                Rng.Text = "\n";
                                Rng.SetRange(Rng.End, Rng.End);

                                if (dsLetterDocumentData.Tables["InsertedText"].Select("BookmarkTypeId = 7", "", DataViewRowState.CurrentRows).GetUpperBound(0) >= 0)
                                {
                                    int j = 0;
                                    foreach (DataRow myRow in dsLetterDocumentData.Tables["InsertedText"].Select("BookmarkTypeId = 7", "", DataViewRowState.CurrentRows))
                                    {
                                        if (dsLetterDocumentData.Tables["InsertedText"].Select("BookmarkTypeId = 7", "", DataViewRowState.CurrentRows).GetUpperBound(0) == j && j != 0)
                                        {
                                            Rng.Text = "\n" + myRow["TextInsert"].ToString() + "\n";
                                            Rng.SetRange(Rng.End, Rng.End);
                                        }
                                        else if (j == 0)
                                        {
                                            Rng.Text = "\n" + myRow["TextInsert"].ToString() + "\n";
                                            Rng.SetRange(Rng.End, Rng.End);
                                        }
                                        else
                                        {
                                            Rng.Text = "\n" + myRow["TextInsert"].ToString() + "\n";
                                            Rng.SetRange(Rng.End, Rng.End);
                                        }
                                        j++;
                                    }
                                }
                                else
                                {
                                    Rng.Text = "";
                                    Rng.SetRange(Rng.End, Rng.End);
                                }
                                break;
                            case "INCOMPLETENESSITEMS":
                                Rng = bmrk.Range;
                                int i = 0;
                                if (dsLetterDocumentData.Tables["InsertedText"].Select("BookmarkTypeId = 8", "", DataViewRowState.CurrentRows).Length > 0)
                                {
                                    foreach (DataRow myRow in dsLetterDocumentData.Tables["InsertedText"].Select("BookmarkTypeId = 8", "", DataViewRowState.CurrentRows))
                                    {
                                        i++;
                                        Rng.Text = i.ToString() + "\t" + myRow["TextInsert"].ToString() + "\n\n";
                                        Rng.SetRange(Rng.End, Rng.End);
                                    }
                                }
                                else
                                {
                                    Rng.Text = "";
                                    Rng.SetRange(Rng.End, Rng.End);
                                }
                                break;
                            case "":
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (LetterProgressBar != null)
                {
                    LetterProgressBar.PerformStep();
                }

                foreach (Word.Bookmark bmrk in LetterDoc.Bookmarks)
                {
                    string BookmarkName;
                    if (bmrk.Name.ToString().IndexOf("_") > 0)
                    {
                        BookmarkName = bmrk.Name.Substring(0, bmrk.Name.ToString().IndexOf("_"));
                    }
                    else
                    {
                        BookmarkName = bmrk.Name.ToString();
                    }
                    if (BookmarksHT.Contains(BookmarkName))
                    {
                        switch (BookmarksHT[BookmarkName].ToString())
                        {
                            case "true":
                                break;
                            case "false":
                            case "False":
                                bmrk.Range.Text = "";
                                break;
                            default:
                                break;
                        }

                    }
                }

                if (LetterDoc.Bookmarks.Count > 0)
                {
                    foreach (Word.Bookmark bmrk in LetterDoc.Bookmarks)
                    {
                        if (!(bmrk.Name.ToString() == "Footer") && !(bmrk.Name.ToString() == "Logo") && !(bmrk.Name.IndexOf("Text") > 0))//|| bmrk.Name.ToString()== "StatSourceInsert" || bmrk.Name.ToString()== "FacilityInsert"))
                        {
                            MissingBookmarks.Append(bmrk.Name.ToString() + "\n");
                        }
                    }
                }

                if (MissingBookmarks + SkippedBookmarks + RemovedBookmarks != "")
                {

                    if (MissingBookmarks.Length > 0)
                    {
                        Message = "Missing data for bookmarks: \n\n" + MissingBookmarks.ToString();
                    }

                    if (Message != "")
                    {
                        //					MessageBox.Show(Message	, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Hand );
                    }
                }

                LetterDoc.SaveAs(ref SaveFileObj
        , ref missingValue, ref missingValue, ref missingValue
        , ref missingValue, ref missingValue, ref missingValue
        , ref missingValue, ref missingValue, ref missingValue
        , ref missingValue, ref missingValue, ref missingValue
        , ref missingValue, ref missingValue, ref missingValue
        );

                return Message;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersBL:GenerateLetter");
                return "Error";
            }
        }

        //public void GenerateTransOOAuth(int letterNo, bool returnReceipt, bool letterHead)
        //{
        //    Word.Application WordApplication = new Word.Application();
        //    object missingValue = Type.Missing;

        //    Word.Document TransOOAuthDoc = null;
        //    Object FileObj;
        //    Word.Bookmarks Bmrk;
        //    object oBookmark;
        //    object oBookmark2;
        //    Word.Range Rng;

        //    Object ReadOnly = true;
        //    Object AddToRecentFiles = false;
        //    Object NoSaveChanges = false;
        //    Object Visible = true;

        //    //			FileObj = @"\\sbcapcd.org\shares\IDS APPS\PSA\Templates\Letter\TransOOAuth(ver1.0).doc";
        //    DataSet TransOOAuthDS = null;
        //    TransOOAuthDS = GetTransOOAuthData(letterNo);


        //    GenerateLetter(letterNo, returnReceipt, letterHead, TransOOAuthDS);


        //    Hashtable BookmarksHT = new Hashtable();

        //    if (TransOOAuthDS.Tables["TransOOAuthData"] != null)
        //    {
        //        FileObj = TransOOAuthDS.Tables["TransOOAuthData"].Rows[0]["TransOOAuth"];

        //        string SaveFolder;

        //        if (TransOOAuthDS.Tables["LetterData"].Rows[0]["SaveFolder"].ToString().EndsWith(@"\"))
        //        {
        //            SaveFolder = TransOOAuthDS.Tables["LetterData"].Rows[0]["SaveFolder"].ToString();
        //        }
        //        else
        //        {
        //            SaveFolder = TransOOAuthDS.Tables["LetterData"].Rows[0]["SaveFolder"].ToString() + @"\";
        //        }



        //        foreach (DataRow row in TransOOAuthDS.Tables["TransOOAuthData"].Rows)
        //        {
        //            BookmarksHT.Clear();
        //            object transOOFileName = SaveFolder + ((string)(row["DocType"] + " " + row["PermitNumber"] + " " + row["PermitSuffix"] + " - TransOO Auth - " + DateTime.Now.ToShortDateString())).Replace(@"/", "-");

        //            BookmarksHT.Add("TransOOAuthPath", transOOFileName.ToString());

        //            foreach (DataColumn col in TransOOAuthDS.Tables["TransOOAuthData"].Columns)
        //            {
        //                BookmarksHT.Add(col.ColumnName.ToString(), row[col]);
        //            }
        //            try
        //            {
        //                TransOOAuthDoc = WordApplication.Documents.Add(ref FileObj, ref missingValue, ref missingValue, ref Visible);
        //                TransOOAuthDoc.ShowRevisions = false;
        //                TransOOAuthDoc.Activate();
        //                WordApplication.Visible = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                string errMessage = "";
        //                for (Exception tempException = ex; tempException != null; tempException = tempException.InnerException)
        //                {
        //                    errMessage += tempException.Message + Environment.NewLine + Environment.NewLine;
        //                }
        //            }

        //            foreach (Word.Bookmark bmrk in TransOOAuthDoc.Bookmarks)
        //            {
        //                string BookmarkName;
        //                if (bmrk.Name.ToString().IndexOf("_") > 0)
        //                {
        //                    BookmarkName = bmrk.Name.Substring(0, bmrk.Name.ToString().IndexOf("_"));
        //                }
        //                else
        //                {
        //                    BookmarkName = bmrk.Name.ToString();
        //                }
        //                if (BookmarksHT.Contains(BookmarkName))
        //                {
        //                    switch (BookmarksHT[BookmarkName].ToString())
        //                    {
        //                        case "true":
        //                            break;
        //                        case "false":
        //                            bmrk.Range.Text = "";
        //                            break;
        //                        default:
        //                            bmrk.Range.Text = BookmarksHT[BookmarkName].ToString();
        //                            break;
        //                    }
        //                }
        //                else if (BookmarkName == "TRANSOOAUTH")
        //                {
        //                    int i;
        //                    if (BookmarksHT["TransGDFText"].ToString() == "true")
        //                    {
        //                        i = 4;
        //                    }
        //                    else
        //                    {
        //                        i = 3;
        //                    }
        //                    Rng = bmrk.Range;
        //                    if (TransOOAuthDS.Tables["InsertedText"].Select("Bookmark = 'TRANSOOAUTH'", "", DataViewRowState.CurrentRows).GetUpperBound(0) >= 0)
        //                    {
        //                        foreach (DataRow rowText in TransOOAuthDS.Tables["InsertedText"].Select("Bookmark = 'TRANSOOAUTH'", "", DataViewRowState.CurrentRows))
        //                        {
        //                            i++;
        //                            Rng.Text = "\n(" + i + ")\t" + rowText["TextInsert"].ToString() + "\n";
        //                            Rng.SetRange(Rng.End, Rng.End);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        Rng.Text = "";
        //                        Rng.SetRange(Rng.End, Rng.End);
        //                    }
        //                }
        //            }
        //            TransOOAuthDoc.SaveAs(ref transOOFileName
        //                , ref missingValue, ref missingValue, ref missingValue
        //                , ref missingValue, ref missingValue, ref missingValue
        //                , ref missingValue, ref missingValue, ref missingValue
        //                , ref missingValue, ref missingValue, ref missingValue
        //                , ref missingValue, ref missingValue, ref missingValue
        //                );
        //        }
        //    }
        //}

        private Boolean ExecuteReplace(Word.Find find)
        {
            return ExecuteReplace(find, Word.WdReplace.wdReplaceAll);
        }

        private static object GetHashtableValue(Hashtable ht, string keyHT)
        {
            if (ht.Contains(keyHT))
            {
                return ht[keyHT];
            }
            else
            {
                return null;
            }
        }


        private static void SetHashtable(Hashtable ht, string keyHT, string valueHT)
        {
            if (ht.Contains(keyHT))
            {
                ht[keyHT] = valueHT;
            }
            else
            {
                ht.Add(keyHT, valueHT);
            }
        }

        private Boolean ExecuteReplace(Word.Find find, Object replaceOption)
        {
            // Simple wrapper around Find.Execute:
            Object findText = Type.Missing;
            Object matchCase = Type.Missing;
            Object matchWholeWord = Type.Missing;
            Object matchWildcards = Type.Missing;
            Object matchSoundsLike = Type.Missing;
            Object matchAllWordForms = Type.Missing;
            Object forward = Type.Missing;
            Object wrap = Type.Missing;
            Object format = Type.Missing;
            Object replaceWith = Type.Missing;
            Object replace = replaceOption;
            Object matchKashida = Type.Missing;
            Object matchDiacritics = Type.Missing;
            Object matchAlefHamza = Type.Missing;
            Object matchControl = Type.Missing;

            return find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildcards, ref matchSoundsLike, ref matchAllWordForms,
                ref forward, ref wrap, ref format, ref replaceWith, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza,
                ref matchControl);
        }

        private void GetLetterTemplateDS(int templateNo)
        {
            //			SBCAPCD.Org.EmployeeComponent.EmployeeBL GetDataSet;
            //			GetDataSet = new SBCAPCD.Org.EmployeeComponent.EmployeeBL();
            //			SqlParameter [] ArParms = new SqlParameter[1];
            //			ArParms[0] = new SqlParameter("@LetterTemplateNo", SqlDbType.Int, 4 ); 
            //			ArParms[0].Value = templateNo;
            //			dsLetterDocumentData = (GetDataSet.GetDataSet(dsLetterDocumentData,"LetterTemplate",ArParms,"","","",null) as SBCAPCD.Org.LetterComponent.LettersDataDS);
        }


        #endregion
    }
}
