using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SbcapcdOrg.PdePermit.PdePermitComponents;
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PdePermit.StationarySource
{
  class StationarySourceDL
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

    public bool GetStationarySource(string conString, DataSet dsStationarySource)
    {
      try
      {
        dsStationarySource.Clear();
        SqlDatabase db = new SqlDatabase(conString);
        db.LoadDataSet(CommandType.StoredProcedure, "GetPdeStationarySourceV2", dsStationarySource, new string[] { "StationarySource", "StationarySourceToxicsActionHistory", "StationarySourceHraHistory", "StationarySourceCompany" });

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

    public bool SaveStationarySource(string conString, DataSet dsStationarySource, DbTransaction transaction)
    {
      if (dsStationarySource == null)
      {
        transaction.Commit();
        return true;
      }

      try
      {
        SqlDatabase db = new SqlDatabase(conString);

        db.UpdateDataSet(dsStationarySource, "StationarySource",
          GetDbCommand(db, "AddUpdatePdeStationarySource4"),
          GetDbCommand(db, "AddUpdatePdeStationarySource4"),
          GetDbCommand(db, "DeletePdeStationarySource"),
          transaction);

        db.UpdateDataSet(dsStationarySource, "StationarySourceToxicsActionHistory",
          GetDbCommand(db, "AddUpdateStationarySourceToxicsActionHistory2"),
          GetDbCommand(db, "AddUpdateStationarySourceToxicsActionHistory2"),
          GetDbCommand(db, "DeleteStationarySourceToxicsActionHistory"),
          transaction);

        db.UpdateDataSet(dsStationarySource, "StationarySourceHraHistory",
          GetDbCommand(db, "AddUpdateStationarySourceHraHistory3"),
          GetDbCommand(db, "AddUpdateStationarySourceHraHistory3"),
          GetDbCommand(db, "DeleteStationarySourceHraHistory"),
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

    public bool SaveStationarySource(string conString, DataSet dsStationarySource)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);

        db.UpdateDataSet(dsStationarySource, "StationarySource",
          GetDbCommand(db, "AddUpdatePdeStationarySource4"),
          GetDbCommand(db, "AddUpdatePdeStationarySource4"),
          GetDbCommand(db, "DeletePdeStationarySource"),
          UpdateBehavior.Standard);

        db.UpdateDataSet(dsStationarySource, "StationarySourceToxicsActionHistory",
          GetDbCommand(db, "AddUpdateStationarySourceToxicsActionHistory"),
          GetDbCommand(db, "AddUpdateStationarySourceToxicsActionHistory"),
          GetDbCommand(db, "DeleteStationarySourceToxicsActionHistory"),
          UpdateBehavior.Standard);

        db.UpdateDataSet(dsStationarySource, "StationarySourceHraHistory",
          GetDbCommand(db, "AddUpdateStationarySourceHraHistory3"),
          GetDbCommand(db, "AddUpdateStationarySourceHraHistory3"),
          GetDbCommand(db, "DeleteStationarySourceHraHistory"),
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

    public bool SaveStationarySourceToxics(string conString, DataSet dsStationarySource, DbTransaction transaction)
    {
      if (dsStationarySource == null)
      {
        //MessageBox.Show("dsStationarySource == null");
        transaction.Commit();
        return true;
      }
      
      try
      {
        SqlDatabase db = new SqlDatabase(conString);

        db.UpdateDataSet(dsStationarySource, "StationarySource",
            GetDbCommand(db, "AddUpdatePdeStationarySourceRisk"),
            GetDbCommand(db, "AddUpdatePdeStationarySourceRisk"),
            GetDbCommand(db, "DeletePdeStationarySourceRisk"),
            transaction);

        db.UpdateDataSet(dsStationarySource, "StationarySourceToxicsActionHistory",
            GetDbCommand(db, "AddUpdateStationarySourceToxicsActionHistory2"),
            GetDbCommand(db, "AddUpdateStationarySourceToxicsActionHistory2"),
            GetDbCommand(db, "DeleteStationarySourceToxicsActionHistory2"),
            transaction);

        db.UpdateDataSet(dsStationarySource, "StationarySourceHraHistory",
            GetDbCommand(db, "AddUpdateStationarySourceHraHistory3"),
            GetDbCommand(db, "AddUpdateStationarySourceHraHistory3"),
            GetDbCommand(db, "DeleteStationarySourceHraHistory"),
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

    public bool GetStationarySourceAux(string conString, DataSet dsStationarySourceAux)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);
        db.LoadDataSet(CommandType.StoredProcedure, "GetPdeStationarySourceAuxTables", dsStationarySourceAux, new string[] { "Ab2588Category", "Cycle", "ToxicsActions", "PermitList", "FacilityList", "TwoDigitSic", "StationarySourceType" });

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

    public void GetStationarySourceEmissions(string conString, object stationarySourceNo, DataSet dsStationarySourceEmissions)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);
        DbCommand cmd = db.GetStoredProcCommand("GetRepStationarySourceEmissions");
        cmd.Parameters.Add(new SqlParameter("@StationarySourceNo", stationarySourceNo));
        db.LoadDataSet(cmd, dsStationarySourceEmissions, new string[] { "StationarySourceEmissions" });
        //db.LoadDataSet("GetRepStationarySourceEmissions", dsStationarySourceEmissions, new string[] {"dsStationarySourceEmissions"}, new SqlParameter[] { new SqlParameter("@StationarySourceNo", stationarySourceNo) });
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
      }
      finally
      {
      }
    }

    public static string GetNewStationarySourceNo(string conString)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);
        return db.ExecuteScalar(CommandType.StoredProcedure, "GetPdeNewStationarySourceNo").ToString();
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

    public static object GetNewStationarySourceHraHistoryId(string conString)
    {
      try
      {
        SqlDatabase db = new SqlDatabase(conString);
        return db.ExecuteScalar(CommandType.StoredProcedure, "GetPdeNewStationarySourceHraHistoryId");
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

    private void GetParameters(Database db, DbCommand cmd)
    {
      db.DiscoverParameters(cmd);
      foreach (System.Data.SqlClient.SqlParameter para in cmd.Parameters)
      {
        para.SourceColumn = para.ParameterName.Substring(1, para.ParameterName.Length - 1);
      }
    }

  }
}
