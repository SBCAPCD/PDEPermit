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
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PDEPermit.TransOo
{
    public class TransOoDL
    {
        public static int GetNewLetterId(string conString)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                return (int)(db.ExecuteScalar(CommandType.StoredProcedure, "GetPdeNewLetterId"));
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOoDL:GetNewLetterId");
                return -1;
            }
            finally
            {
            }
        }

        public static void GetTransOoAux(string conString, DataSet dsTransOoAux)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                db.LoadDataSet("GetPdeTransOoAux", dsTransOoAux, new string[] { "SignEmployee", "FacilityList", "StationarySourceList" });
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOoDL:GetTransOoAux");
            }
        }

        public static DataSet GetTransOoAllData(string conString, string letterNo)
        {
            DataSet dsTransOoAllData = new DataSet();
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                db.LoadDataSet("GetPdeTransOoAllData", dsTransOoAllData, new string[] { "BookmarkDataTables", "LetterType", "LetterData", "PermitActionHist", "LetterCCData", "InsertedText", "PermitData", "Contact", "Facility", "Employee", "TransOoAuthData" }, new object[] { letterNo });
                return dsTransOoAllData;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOo:GetLetterData");
                return null;
            }
        }

        public static DataSet GetTransOoAuthData(string conString, int letterNo)
        {
            DataSet dsTransOoAuth = new DataSet();
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                db.LoadDataSet("GetPdeTransOoAuthData", dsTransOoAuth, new string[] { "TransOoAuthData" }, new object[] { letterNo });
                return dsTransOoAuth;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOo:GetTransOoAuthData");
                return null;
            }
        }

        public static void GetTransOosByIndex(string conString, DataSet dsTransOoLetters, string indexNo, string transferType)
        {
            DataSet dsLetters = new DataSet();
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                db.LoadDataSet("GetPdeTransOosByIndex", dsTransOoLetters, new string[] { "Letters" }, new object[] { indexNo, transferType });
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOo:GetTransOosByIndex");
            }
        }

        public void GetTransOoByLetterNo(string conString, int letterNo, DataSet dsTransOoLetter)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                db.LoadDataSet("GetPdeTransOoByLetterNo", dsTransOoLetter, new string[] { "Letter", "LetterCc", "LetterTransOo" }, new object[] { letterNo }); // "LetterInsert",
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LettersDL:GetLetterByLetterNo");
            }
        }

        public bool SaveLetter(string conString, DataSet dsTransOoLetter)
        {
            if (dsTransOoLetter == null) { return true; }
            SqlDatabase db = new SqlDatabase(conString);
            DbConnection connection = db.CreateConnection();
            connection.Open();
            DbTransaction Transaction = connection.BeginTransaction();

            try
            {
                db.UpdateDataSet(dsTransOoLetter, "Letter",
                    GetDbCommand(db, "AddUpdatePdeLetter2"),
                    GetDbCommand(db, "AddUpdatePdeLetter2"),
                    GetDbCommand(db, "DeletePdeLetter"),
                Transaction);

                db.UpdateDataSet(dsTransOoLetter, "LetterTransOo",
                    GetDbCommand(db, "AddPdeLetterTransOo2"),
                    GetDbCommand(db, "UpdatePdeLetterTransOo"),
                    GetDbCommand(db, "DeletePdeLetterTransOo"),
                Transaction);

                db.UpdateDataSet(dsTransOoLetter, "LetterCc",
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
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOoDL:SaveLetter");
                return false;
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


		public static DataSet GetCCsByFacility(string conString, string facilityNo)
		{
			SqlDatabase db = new SqlDatabase(conString);

			try
			{
				return db.ExecuteDataSet("GetPdeCcsByFacility", new object[] { facilityNo });
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
        
        public DataSet GetApplicationParameters(string conString, string TransOoNo, string application, string TransOoTypeNo)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                return db.ExecuteDataSet("GetPsaApplicationParameters", new object[] { TransOoNo, application, TransOoTypeNo });
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "TransOoDL:GetApplicationParameters");
                return null;
            }
            finally
            {
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
