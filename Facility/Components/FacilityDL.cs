using System;
using System.Reflection;
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

using SbcapcdOrg.PdePermit.PdePermitComponents;
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PdePermit.Facility
{
  class FacilityDL
  {
    public DbTransaction GetTransaction(string conString)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);

        DbConnection connection = db.CreateConnection();
        connection.Open();
        DbTransaction Transaction = connection.BeginTransaction();
        return Transaction;
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return null;
      }
      finally
      {
      }
    }

    public bool GetFacility(string conString, DataSet dsFacility)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);
		db.LoadDataSet(CommandType.StoredProcedure, "GetPdeFacility5", dsFacility, new string[] { "Facility" });// "FacilityEmissions" , });, "FacilityCompanyHistory", "FacilityStationarySourceHistory", "FacilityContacts", "FacilityEmissions", "EmissionsLastModified" 

        return true;
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return false;
      }
      finally
      {
      }
    }

	public bool GetFacilityRelated(string conString, DataSet dsFacility, string facilityNo)
	{
		try
		{
			dsFacility.Tables["FacilityCompanyHistory"].Clear();
			dsFacility.Tables["FacilityStationarySourceHistory"].Clear();
			dsFacility.Tables["FacilityContacts"].Clear();
			dsFacility.Tables["FacilityEmissions"].Clear();
			dsFacility.Tables["EmissionsLastModified"].Clear();
			dsFacility.Tables["FacilityGhgHistory"].Clear();

			SqlDatabase db = new SqlDatabase(conString);
			db.LoadDataSet("GetPdeFacilityRelated", dsFacility, new string[] { "FacilityCompanyHistory", "FacilityStationarySourceHistory", "FacilityContacts", "FacilityEmissions", "EmissionsLastModified", "FacilityGhgHistory" }, new object[] { facilityNo });// "FacilityEmissions" , });, "FacilityCompanyHistory", "FacilityStationarySourceHistory", "FacilityContacts", "FacilityEmissions", "EmissionsLastModified" 

			return true;
		}
		catch (Exception ex)
		{
			SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			return false;
		}
		finally
		{
		}
	}

    public bool GetNewStationarySources(string conString, DataSet dsFacilityAux)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);
        db.LoadDataSet(CommandType.StoredProcedure, "[GetPdeStationarySourceList]", dsFacilityAux, new string[] { "StationarySourceList" });

        return true;
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return false;
      }
      finally
      {
      }
    }

    public bool SaveFacility(string conString, DataSet dsFacility, DbTransaction transaction)
    {
      if (dsFacility == null)
      {
        transaction.Commit();
        return true;
      }

      try
      {
        SqlDatabase db = new SqlDatabase(conString);

        db.UpdateDataSet(dsFacility, "Facility",
			GetDbCommand(db, "AddUpdatePdeFacility9"),
			GetDbCommand(db, "AddUpdatePdeFacility9"),
			GetDbCommand(db, "DeletePdeFacility"),
			transaction);

        db.UpdateDataSet(dsFacility, "FacilityContacts",
          GetDbCommand(db, "AddUpdatePdeContacts4"),
          GetDbCommand(db, "AddUpdatePdeContacts4"),
          GetDbCommand(db, "DeleteContacts"),
          transaction);

        db.UpdateDataSet(dsFacility, "FacilityCompanyHistory",
          GetDbCommand(db, "AddUpdatePdeFacilityCompanyHistoryV2"),
          GetDbCommand(db, "AddUpdatePdeFacilityCompanyHistoryV2"),
          GetDbCommand(db, "DeletePdeFacilityCompanyHistoryV2"),
          transaction);

        db.UpdateDataSet(dsFacility, "FacilityStationarySourceHistory",
          GetDbCommand(db, "AddUpdatePdeFacilityStationarySourceHistoryV2"),
          GetDbCommand(db, "AddUpdatePdeFacilityStationarySourceHistoryV2"),
          GetDbCommand(db, "DeletePdeFacilityStationarySourceHistoryV2"),
          transaction);

        db.UpdateDataSet(dsFacility, "FacilityEmissions",
          GetDbCommand(db, "AddUpdatePdeFacilityEmissions"),
          GetDbCommand(db, "AddUpdatePdeFacilityEmissions"),
          GetDbCommand(db, "DeletePdeFacilityEmissions"),
          transaction);

		db.UpdateDataSet(dsFacility, "FacilityGhgHistory",
		   GetDbCommand(db, "AddUpdatePdeFacilityGhgHistory"),
		   GetDbCommand(db, "AddUpdatePdeFacilityGhgHistory"),
		   GetDbCommand(db, "DeletePdeFacilityGhgHistory"),
		   transaction);

        transaction.Commit();
        return true;
      }
      catch (Exception ex)
      {
        transaction.Rollback();
		SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "FacilityDL:SaveFacility");
        return false;
      }
      finally
      {
      }
    }

    public bool EditorContactEdSaveFacility(string conString, DataSet dsFacility, DbTransaction transaction)
    {
      if (dsFacility == null)
      {
        transaction.Commit();
        return true;
      }

      try
      {
        SqlDatabase db = new SqlDatabase(conString);

        db.UpdateDataSet(dsFacility, "FacilityContacts",
          GetDbCommand(db, "AddUpdatePdeContacts"),
          GetDbCommand(db, "AddUpdatePdeContacts"),
          GetDbCommand(db, "DeleteContacts"),
          transaction);

        db.UpdateDataSet(dsFacility, "FacilityEmissions",
          GetDbCommand(db, "AddUpdatePdeFacilityEmissions"),
          GetDbCommand(db, "AddUpdatePdeFacilityEmissions"),
          GetDbCommand(db, "DeletePdeFacilityEmissions"),
		  transaction);

		db.UpdateDataSet(dsFacility, "FacilityGhgHistory",
		   GetDbCommand(db, "AddUpdatePdeFacilityGhgHistory"),
		   GetDbCommand(db, "AddUpdatePdeFacilityGhgHistory"),
		   GetDbCommand(db, "DeletePdeFacilityGhgHistory"),
		   transaction);

        transaction.Commit();
        return true;
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return false;
      }
      finally
      {
      }
    }

    public bool ContactEdSaveFacility(string conString, DataSet dsFacility, DbTransaction transaction)
    {
      if (dsFacility == null)
      {
        transaction.Commit();
        return true;
      }
      try
      {
        SqlDatabase db = new SqlDatabase(conString);

        db.UpdateDataSet(dsFacility, "FacilityContacts",
          GetDbCommand(db, "AddUpdatePdeContacts"),
          GetDbCommand(db, "AddUpdatePdeContacts"),
          GetDbCommand(db, "DeleteContacts"),
          transaction);

        transaction.Commit();
        return true;
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return false;
      }
      finally
      {
      }
    }

    public bool EditorSaveFacility(string conString, DataSet dsFacility, DbTransaction transaction)
    {
      if (dsFacility == null)
      {
        transaction.Commit();
        return true;
      }

      if (!dsFacility.Tables.Contains("FacilityEmissions"))
      {
        return true;
      }

      try
      {
        SqlDatabase db = new SqlDatabase(conString);

        db.UpdateDataSet(dsFacility, "FacilityEmissions",
          GetDbCommand(db, "AddUpdatePdeFacilityEmissions"),
          GetDbCommand(db, "AddUpdatePdeFacilityEmissions"),
          GetDbCommand(db, "DeletePdeFacilityEmissions"),
		  transaction);

		db.UpdateDataSet(dsFacility, "FacilityGhgHistory",
		   GetDbCommand(db, "AddUpdatePdeFacilityGhgHistory"),
		   GetDbCommand(db, "AddUpdatePdeFacilityGhgHistory"),
		   GetDbCommand(db, "DeletePdeFacilityGhgHistory"),
		   transaction);

        transaction.Commit();
        return true;
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return false;
      }
      finally
      {
      }
    }

    public bool EditorSaveFacility(string conString, DataSet dsFacility)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);

        db.UpdateDataSet(dsFacility, "FacilityEmissions",
          GetDbCommand(db, "AddUpdatePdeFacilityEmissions"),
          GetDbCommand(db, "AddUpdatePdeFacilityEmissions"),
          GetDbCommand(db, "DeletePdeFacilityEmissions"),
          UpdateBehavior.Standard);

		db.UpdateDataSet(dsFacility, "FacilityGhgHistory",
		   GetDbCommand(db, "AddUpdatePdeFacilityGhgHistory"),
		   GetDbCommand(db, "AddUpdatePdeFacilityGhgHistory"),
		   GetDbCommand(db, "DeletePdeFacilityGhgHistory"),
		   UpdateBehavior.Standard);

        return true;
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return false;
      }
      finally
      {
      }
    }

    //public bool GetFacilityAux(DataSet dsFacilityAux)
    //{
    //    try
    //    {
    //        SqlDatabase db = new SqlDatabase(conString);
    //        db.LoadDataSet(CommandType.StoredProcedure, "GetPdeFacilityAuxTablesV2", dsFacilityAux, new string[] { "NewFacilityEmissions", "AddressSearchString", "VarianceHistory", "BreakdownHistory", "PermitList", "StationarySourceList", "StationarySourceType", "FourDigitSic", "NovHistory", "ContactType", "InspectionHistory", "PermitHistory" });

    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

    //        if (rethrow)
    //        {
    //            SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Facility:GetFacilityAux");
    //        }
    //        return false;
    //    }
    //    finally
    //    {
    //    }
    //}

    public static bool GetFacilityCompanies(string conString, DataSet dsFacilityAux)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);

        db.LoadDataSet(CommandType.StoredProcedure, "GetPdeFacilityCompanies", dsFacilityAux, new string[] { "Companies" });

        return true;
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Facility:GetFacilityAux");
        return false;
      }
    }

    public bool GetFacilityPrimaryAux(string conString, DataSet dsFacilityAux)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);
        db.LoadDataSet(CommandType.StoredProcedure, "GetPdeFacilityPrimaryAux2", dsFacilityAux, new string[] { "PermitList", "StationarySourceList", "FacilityType", "FourDigitSic", "Companies", "ContactType" });

        return true;
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return false;
      }
      finally
      {
      }
    }

    public bool GetFacilitySecondaryAux(string conString, DataSet dsFacilityAux)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);
        db.LoadDataSet(CommandType.StoredProcedure, "GetPdeFacilitySecondaryAux4", dsFacilityAux, new string[] { "NewFacilityEmissions", "AddressSearchString" }); // , "VarianceHistory", "BreakdownHistory", "NovHistory", "InspectionHistory", "PermitHistory" 

        return true;
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return false;
      }
      finally
      {
      }
    }

    public static string GetNewFacilityNo(string conString)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);
        return db.ExecuteScalar(CommandType.StoredProcedure, "GetPdeNewFacilityNo").ToString();
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
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
