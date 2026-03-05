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

namespace SbcapcdOrg.PDEPermit.TransOo
{
    public class TransOoBL
    {
        static object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;

        public bool SaveLetter(string conString, DataSet dsTransOoLetter)
        {
            bool TransactionOK = false;
            try
            {
                SbcapcdOrg.PDEPermit.TransOo.TransOoDL saveLetter = new TransOoDL();
                return saveLetter.SaveLetter(conString, dsTransOoLetter);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOoBL:SaveLetter");
                return TransactionOK;
            }
            finally
            {
            }
        }

        public static void GetCCsByCompany(string conString, string companyNo, System.Windows.Forms.ListBox lbxContactPickList)
        {
            try
            {
                DataSet dsContactsByCompany = SbcapcdOrg.PDEPermit.TransOo.TransOoDL.GetCCsByCompany(conString, companyNo);
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
                DataSet dsContactsByCompany = SbcapcdOrg.PDEPermit.TransOo.TransOoDL.GetCCsByPermit(conString, permitNo);
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

		public static void GetCCsByFacility(string conString, string facilityNo, System.Windows.Forms.ListBox lbxContactPickList)
		{
			try
			{
				DataSet dsContactsByCompany = SbcapcdOrg.PDEPermit.TransOo.TransOoDL.GetCCsByFacility(conString, facilityNo);
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
                DataSet dsContactsByCompany = SbcapcdOrg.PDEPermit.TransOo.TransOoDL.GetAllCCs(conString);
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

        public static int GetNewLetterId(string conString)
        {
            try
            {
                return SbcapcdOrg.PDEPermit.TransOo.TransOoDL.GetNewLetterId(conString);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersBL:GetNewLetterId");
                return -1;
            }
        }

        public void GetTransOoByLetterNo(string conString, int letterNo, DataSet dsTransOoLetter)
        {
            dsTransOoLetter.Clear();

            try
            {
                SbcapcdOrg.PDEPermit.TransOo.TransOoDL getTransOoByLetterNo = new TransOoDL();
                getTransOoByLetterNo.GetTransOoByLetterNo(conString, letterNo, dsTransOoLetter);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersBL:GetLetterByLetterNo");
            }
        }

        public static void GetTransOosByIndex(string conString, DataSet dsTransOoLetters, string indexNo, string transferType)
        {
            try
            {
                SbcapcdOrg.PDEPermit.TransOo.TransOoDL.GetTransOosByIndex(conString, dsTransOoLetters, indexNo, transferType);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOoBL:GetTransOoAux");
            }
        }

        public static void GetTransOoAux(string conString, DataSet dsTransOoAux)
        {
            dsTransOoAux.Clear();

            try
            {
                SbcapcdOrg.PDEPermit.TransOo.TransOoDL.GetTransOoAux(conString, dsTransOoAux);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOoBL:GetTransOoAux");
            }
        }

        public static void GenerateTransOoAuth(string conString, int letterNo, bool returnReceipt, bool letterHead, DataSet dsTransOoAllData)
        {
            Word.Application WordApplication = new Word.Application();
            object missingValue = Type.Missing;

            Word.Document TransOoAuthDoc = null;
            Object FileObj;
            Word.Bookmarks Bmrk;
            object oBookmark;
            object oBookmark2;
            Word.Range Rng;

            Object ReadOnly = true;
            Object AddToRecentFiles = false;
            Object NoSaveChanges = false;
            Object Visible = true;  

            Hashtable BookmarksHT = new Hashtable();
            try
            {
                MessageFilter.Register();

                if (dsTransOoAllData.Tables["TransOoAuthData"] != null)
                {
                    if (dsTransOoAllData.Tables["TransOoAuthData"].Rows.Count > 0)
                    {
                        FileObj = dsTransOoAllData.Tables["TransOoAuthData"].Rows[0]["TransOoAuth"];
                    }
                    else
                    {
                        MessageBox.Show("No TransOoAuthData found. Exiting.");
                        return;
                    }

                    string SaveFolder;

                    if (dsTransOoAllData.Tables["LetterData"].Rows[0]["SaveFolder"].ToString().EndsWith(@"\"))
                    {
                        SaveFolder = dsTransOoAllData.Tables["LetterData"].Rows[0]["SaveFolder"].ToString();
                    }
                    else
                    {
                        SaveFolder = dsTransOoAllData.Tables["LetterData"].Rows[0]["SaveFolder"].ToString() + @"\";
                    }

                    foreach (DataRow row in dsTransOoAllData.Tables["TransOoAuthData"].Rows)
                    {
                        BookmarksHT.Clear();
                        object transOoFileName = SaveFolder + ((string)(row["DocType"] + " " + row["PermitNumber"] + " " + row["PermitSuffix"] + " - TransOO Auth - " + DateTime.Now.ToShortDateString())).Replace(@"/", "-") + ".doc";

                        BookmarksHT.Add("TransOoAuthPath", transOoFileName.ToString());

                        foreach (DataColumn col in dsTransOoAllData.Tables["TransOoAuthData"].Columns)
                        {
                            BookmarksHT.Add(col.ColumnName.ToString(), row[col]);
                        }
                        try
                        {
                            TransOoAuthDoc = WordApplication.Documents.Add(ref FileObj, ref missingValue, ref missingValue, ref Visible);
                            TransOoAuthDoc.ShowRevisions = false;
                            TransOoAuthDoc.Activate();
                        }
                        catch (Exception ex)
                        {
                            SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOoBL:GenerateLetter");
                        }

                        foreach (Word.Bookmark bmrk in TransOoAuthDoc.Bookmarks)
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
                                        bmrk.Range.Text = "";
                                        break;
                                    default:
                                        bmrk.Range.Text = BookmarksHT[BookmarkName].ToString();
                                        break;
                                }
                            }
                            else if (BookmarkName == "TransOoAuth")
                            {
                                int i;
                                if (BookmarksHT["TransGDFText"].ToString() == "true")
                                {
                                    i = 4;
                                }
                                else
                                {
                                    i = 3;
                                }
                                Rng = bmrk.Range;
                                if (dsTransOoAllData.Tables["InsertedText"].Select("Bookmark = 'TransOoAuth'", "", DataViewRowState.CurrentRows).GetUpperBound(0) >= 0)
                                {
                                    foreach (DataRow rowText in dsTransOoAllData.Tables["InsertedText"].Select("Bookmark = 'TransOoAuth'", "", DataViewRowState.CurrentRows))
                                    {
                                        i++;
                                        Rng.Text = "\n(" + i + ")\t" + rowText["CustomInsertText"].ToString() + "\n";
                                        Rng.SetRange(Rng.End, Rng.End);
                                    }
                                }
                                else
                                {
                                    Rng.Text = "";
                                    Rng.SetRange(Rng.End, Rng.End);
                                }
                            }
                        }

                        try
                        {
                            WordApplication.Visible = true;

                            if (File.Exists(transOoFileName.ToString()))
                            {
                                DialogResult Answer = MessageBox.Show("Permit exists. Do you want to overwrite it?", "Permit exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (Answer == DialogResult.Yes)
                                {
                                    TransOoAuthDoc.SaveAs(ref transOoFileName
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
                                TransOoAuthDoc.SaveAs(ref transOoFileName
                                    , ref missingValue, ref missingValue, ref missingValue
                                    , ref missingValue, ref missingValue, ref missingValue
                                    , ref missingValue, ref missingValue, ref missingValue
                                    , ref missingValue, ref missingValue, ref missingValue
                                    , ref missingValue, ref missingValue, ref missingValue
                                    );
                            }

                        }
                        catch (Exception ex)
                        {
                            ((Microsoft.Office.Interop.Word._Document)TransOoAuthDoc).Close(ref saveChanges, ref missingValue, ref missingValue);
							SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOoBL:GenerateTransOoAuth");
                        }
                    }
                }
            }

            finally
            {
                MessageFilter.Revoke();
            }
        }

        public static string GenerateLetter(string conString, int letterNo, System.Windows.Forms.ProgressBar progressBar) // bool returnReceipt, bool letterHead,
        {
            progressBar.PerformStep();
            DataSet dsTransOoAllData = SbcapcdOrg.PDEPermit.TransOo.TransOoDL.GetTransOoAllData(conString, letterNo.ToString());
            progressBar.PerformStep();
            GenerateLetter(conString, letterNo, true, true, dsTransOoAllData);
            progressBar.PerformStep();
            GenerateTransOoAuth(conString, letterNo, true, true, dsTransOoAllData);
            return null;
        }

        public static string GenerateLetter(string conString, int letterNo, bool returnReceipt, bool letterHead, DataSet dsTransOoAllData)
        {
            string Message = "";
            bool ReturnReceipt = returnReceipt;
            Hashtable BookmarksHT = new Hashtable();
            int WordFileCount = 0;
            //			string BodyFileName = "";
            string SaveFileName = "";
            string TemplateFileName = "";
            string HeaderFileName = "";
            Word.Range Rng;
            DialogResult Answer;

            Word.Application WordApplication = new Word.Application();
            object missingValue = Type.Missing;

            Word.Document LetterDoc = null;
            Object HeaderFileObj = null;
            Word.Bookmarks Bmrk;
            object oBookmark;
            object oBookmark2;

            Object ReadOnly = true;
            Object AddToRecentFiles = false;
            Object NoSaveChanges = false;
            Object Visible = true;

            try
            {
                MessageFilter.Register();

                foreach (DataColumn tableCol in dsTransOoAllData.Tables["BookmarkDataTables"].Columns)
                {
                    string tableName = dsTransOoAllData.Tables["BookmarkDataTables"].Rows[0][tableCol.ColumnName.ToString()].ToString();

                    if (dsTransOoAllData.Tables[tableName] != null)
                    {
                        foreach (DataRow row in dsTransOoAllData.Tables[tableName].Rows)
                        {
                            foreach (DataColumn col in dsTransOoAllData.Tables[tableName].Columns)
                            {
                                if (!BookmarksHT.Contains(col.ColumnName.ToString()))
                                {
                                    SetHashtable(BookmarksHT, col.ColumnName.ToString(), row[col].ToString());
                                }
                            }
                        }
                    }
                }

				if (BookmarksHT.Contains("NovList") && BookmarksHT["NovList"].ToString().Length > 0)
				{
					MessageBox.Show("This facility or equipment has the following unresolved NOVs: " + BookmarksHT["NovList"].ToString()
					+ Environment.NewLine + Environment.NewLine +
					"Confirm that these outstanding NOVs are non-significant violations before continuing. See Engineering Supervisor if you have any questions."
					, "Facility has NOVs", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

                HeaderFileObj = HeaderFileName = GetHashtableValue(BookmarksHT, "HeaderFileName").ToString();
                TemplateFileName = GetHashtableValue(BookmarksHT, "TemplateFileName").ToString();

                try
                {
                    LetterDoc = WordApplication.Documents.Add(ref HeaderFileObj, ref missingValue, ref missingValue, ref Visible);
                }
                catch (Exception ex)
                {
                    SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOoBL:GenerateLetter");
                    ((Microsoft.Office.Interop.Word._Document)LetterDoc).Close(ref saveChanges, ref missingValue, ref missingValue);
                    return "";
                }
                finally
                {
                }

                if (LetterDoc == null)
                {
                    MessageBox.Show("Error creating Word Doc\t", "GenerateLetter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }

                oBookmark = "Header";
                Bmrk = LetterDoc.Bookmarks;

                try
                {
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
                    SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOoBL:GenerateLetter");
                    ((Microsoft.Office.Interop.Word._Document)LetterDoc).Close(ref saveChanges, ref missingValue, ref missingValue);
                    return "";
                }

                Object SaveFileObj = null;
                if (dsTransOoAllData.Tables["LetterData"].Rows[0]["SaveFolder"].ToString().EndsWith("\\"))
                {
                    SaveFileObj = dsTransOoAllData.Tables["LetterData"].Rows[0]["SaveFolder"].ToString() + dsTransOoAllData.Tables["LetterData"].Rows[0]["LetterName"].ToString() + ".docx";
                    SaveFileName = SaveFileObj.ToString();
                }
                else
                {
                    SaveFileObj = dsTransOoAllData.Tables["LetterData"].Rows[0]["SaveFolder"].ToString() + @"\" + dsTransOoAllData.Tables["LetterData"].Rows[0]["LetterName"].ToString() + ".docx";
                    SaveFileName = SaveFileObj.ToString();
                }
                
                LetterDoc.ShowRevisions = false;
                LetterDoc.Activate();


                oBookmark = "MailingMethod";
                Word.Bookmark bmkMailingMethod = (Word.Bookmark)LetterDoc.Bookmarks.get_Item(ref oBookmark);

                if (returnReceipt)
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

                if (letterHead)
                {
                    //string footer = bmkFooter.Range.Text;
                    //bmkFooter.Range.Text = footer;
                }
                else
                {
                    bmkLogo.Range.Text = "";
                    bmkFooter.Range.Text = "";
                }

                string SkippedBookmarks = "";
                string RemovedBookmarks = "";
                StringBuilder MissingBookmarks = new StringBuilder("");

                if (dsTransOoAllData.Tables["PermitActionHist"] != null)
                {
                    foreach (DataRow row in dsTransOoAllData.Tables["PermitActionHist"].Rows)
                    {
                        BookmarksHT.Add(row["PermitAction"].ToString(), row["PermitActionDate"].ToString());
                    }
                }

                oBookmark = "FacilityPermitsList";
                if (LetterDoc.Bookmarks.Exists("FacilityPermitsList") && (Word.Bookmark)LetterDoc.Bookmarks.get_Item(ref oBookmark) != null)
                {
                    Word.Bookmark bmkFacilityPermitsList = (Word.Bookmark)LetterDoc.Bookmarks.get_Item(ref oBookmark);
                    int i = 1;

                    Rng = bmkFacilityPermitsList.Range;

                    foreach (DataRow rowText in dsTransOoAllData.Tables["TransOoAuthData"].Select("", "FacilityNo"))
                    {
                        Rng.Text = "\n(" + i + ")\t" + rowText["FacilityDesc"].ToString() + " - FID: " + rowText["FacilityNo"].ToString() + "\n"
                            + "\n\t" + rowText["DocType"].ToString() + " " + rowText["PermitNumber"].ToString() + " " + rowText["PermitSuffix"].ToString() + "\n"
                            ;
                        Rng.SetRange(Rng.End, Rng.End);
                        i++;
                    }
                }

                oBookmark = "CC";
                if ((Word.Bookmark)LetterDoc.Bookmarks.get_Item(ref oBookmark) != null)
                {
                    Word.Bookmark bmkCC = (Word.Bookmark)LetterDoc.Bookmarks.get_Item(ref oBookmark);

                    Rng = bmkCC.Range;

                    if (dsTransOoAllData.Tables["LetterCCData"].Rows.Count > 0)
                    {
                        foreach (DataRow myRow in dsTransOoAllData.Tables["LetterCCData"].Rows)
                        {
                            Rng.Text = "\t" + myRow["ContactName"].ToString() + "\n";
                            Rng.SetRange(Rng.End, Rng.End);
                        }
                    }
                    else
                    {
                        Rng.Text = "";
                    }
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
                                if (dsTransOoAllData.Tables["InsertedText"].Select("BookmarkTypeId = 6", "", DataViewRowState.CurrentRows).GetUpperBound(0) >= 0)
                                {
                                    foreach (DataRow dr in dsTransOoAllData.Tables["InsertedText"].Select("BookmarkTypeId = 6", "", DataViewRowState.CurrentRows))
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

                                if (dsTransOoAllData.Tables["InsertedText"].Select("BookmarkTypeId = 7", "", DataViewRowState.CurrentRows).GetUpperBound(0) >= 0)
                                {
                                    int j = 0;
                                    foreach (DataRow myRow in dsTransOoAllData.Tables["InsertedText"].Select("BookmarkTypeId = 7", "", DataViewRowState.CurrentRows))
                                    {
                                        if (dsTransOoAllData.Tables["InsertedText"].Select("BookmarkTypeId = 7", "", DataViewRowState.CurrentRows).GetUpperBound(0) == j && j != 0)
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
                                if (dsTransOoAllData.Tables["InsertedText"].Select("BookmarkTypeId = 8", "", DataViewRowState.CurrentRows).Length > 0)
                                {
                                    foreach (DataRow myRow in dsTransOoAllData.Tables["InsertedText"].Select("BookmarkTypeId = 8", "", DataViewRowState.CurrentRows))
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
                                bmrk.Range.Text = "";
                                break;
                            default:
                                //							bmrk.Range.Text = BookmarksHT[BookmarkName].ToString();
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
                        //					WatermarkText = "ERROR";
                    }

                    if (Message != "")
                    {
                        //					MessageBox.Show(Message	, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Hand );
                    }
                }


                try
                {
                    WordApplication.Visible = true;

                    if (File.Exists(SaveFileObj.ToString()))
                    {
                        Answer = MessageBox.Show("Permit exists. Do you want to overwrite it?", "Permit exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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






                    //LetterDoc.SaveAs(ref SaveFileObj
                    //    , ref missingValue, ref missingValue, ref missingValue
                    //    , ref missingValue, ref missingValue, ref missingValue
                    //    , ref missingValue, ref missingValue, ref missingValue
                    //    , ref missingValue, ref missingValue, ref missingValue
                    //    , ref missingValue, ref missingValue, ref missingValue
                    //    );
                }
                catch (Exception ex)
                {
                    ((Microsoft.Office.Interop.Word._Document)LetterDoc).Close(ref saveChanges, ref missingValue, ref missingValue);
                    return "";
                }
                return Message;
            }
            finally
            {
                MessageFilter.Revoke();
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
    }
}
