using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SbcapcdOrg.ControlLibrary;


namespace SbcapcdOrg.PDEPermit.Letters

{
    public class LettersDL
    {

        public static void GetLettersAux(string conString, DataSet dsLettersAux)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                db.LoadDataSet("GetPdeLettersAux", dsLettersAux, new string[] { "Company", "SignEmployee", "LetterTypeDocTypeTemplate", "StandardInsert" });
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Letters:GetLetters:GetPdeLetters");
            }
        }

        public static void GetLettersByPermit(string conString, string permitNo, DataSet dsLetters)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                db.LoadDataSet("GetPdeLettersByPermit", dsLetters, new string[] {"Letters"}, new object[] { permitNo });
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersDL:GetLettersByPermit");
            }
        }

        public void GetLetterByLetterNo(string conString, int letterNo, DataSet dsLetter)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                db.LoadDataSet("GetPdeLetterByLetterNo", dsLetter, new string[] { "Letter", "LetterInsert", "LetterCc" }, new object[] { letterNo });
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersDL:GetLetterByLetterNo");
            }
        }

        public bool SaveLetter(string conString, DataSet dsLetter)
        {
            if (dsLetter == null) { return true; }
            SqlDatabase db = new SqlDatabase(conString);
            DbConnection connection = db.CreateConnection();
            connection.Open();
            DbTransaction Transaction = connection.BeginTransaction();

            try
            {
                db.UpdateDataSet(dsLetter, "Letter",
                    GetDbCommand(db, "AddUpdatePdeLetter"),
                    GetDbCommand(db, "AddUpdatePdeLetter"),
                    GetDbCommand(db, "DeletePdeLetter"),
                Transaction);

                db.UpdateDataSet(dsLetter, "LetterInsert",
                    GetDbCommand(db, "AddUpdatePdeLetterInsert"),
                    GetDbCommand(db, "AddUpdatePdeLetterInsert"),
                    GetDbCommand(db, "DeletePdeLetterInsert"),
                Transaction);

                db.UpdateDataSet(dsLetter, "LetterCc",
                    GetDbCommand(db, "AddUpdatePdeLetterCc"),
                    GetDbCommand(db, "AddUpdatePdeLetterCc"),
                    GetDbCommand(db, "DeletePdeLetterCc"),
                Transaction);

                Transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Letters:GetLetters:GetPdeLetters");
                return false;
            }
            finally
            {
            }
        }

        public DataSet GetApplicationParameters(string conString, string LettersNo, string application, string LettersTypeNo)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                return db.ExecuteDataSet("GetPsaApplicationParameters", new object[] { LettersNo, application, LettersTypeNo });
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Letters:GetLetters:GetPdeLetters");
                return null;
            }
            finally
            {
            }
        }

        public static DataSet GetLetterData(string conString, int letterNo)
        {
            SqlDatabase db = new SqlDatabase(conString);
            DataSet dsLetterDocumentData = new DataSet();

            try
            {
                db.LoadDataSet("GetPdeLetterData", dsLetterDocumentData, new string[] { "BookmarkDataTables", "LetterType", "LetterData", "PermitActionHist", "LetterCcData", "InsertedText", "PermitData", "Contact", "Facility", "Employee" }, new object[] { letterNo }); // , "LetterTables", "Employee", "LetterData", "LetterTemplateFiles", "InsertedText", "LetterCCData", "Contact", "Permit", "Facility", "PermitActionHist"
                return dsLetterDocumentData;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersDL:GetLetterData");
                return null;
            }
        }

        public static int GetNewLetterId(string conString)
        {
            SqlDatabase db = new SqlDatabase(conString);
            //DbConnection connection = db.CreateConnection();
            //connection.Open();

            try
            {
                return (int)(db.ExecuteScalar(CommandType.StoredProcedure, "GetPdeNewLetterId"));
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersDL:GetNewLetterId");
                return -1;
            }
            finally
            {
            }
        }

        public static DataSet GetCCsByCompany(string conString, string companyNo)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                return db.ExecuteDataSet("GetPdeCcsByCompany", new object[] { companyNo });
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersDL:GetCCsByCompany");
                return null;
            }
        }

        public static DataSet GetCCsByPermit(string conString, string permitNo)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                return db.ExecuteDataSet("GetPdeCcsByPermit", new object[] { permitNo });
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersDL:GetCCsByPermit");
                return null;
            }
        }

        public static DataSet GetAllCCs(string conString)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                return db.ExecuteDataSet("GetPdeAllCcs");
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersDL:GetAllCCs");
                return null;
            }
        }
        
        private DbCommand GetDbCommand(Database db, string cmdSP)
        {
            DbCommand cmd = db.GetStoredProcCommand(cmdSP);
            db.DiscoverParameters(cmd);
            foreach (System.Data.SqlClient.SqlParameter para in cmd.Parameters)
            {
                para.SourceColumn = para.ParameterName.Substring(1, para.ParameterName.Length - 1);
            }

            return cmd;
        }
    }
}
