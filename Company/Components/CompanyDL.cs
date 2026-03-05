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

namespace SbcapcdOrg.PdePermit.Company
{
	class CompanyDL
	{

        public bool GetCompany(string conString, DataSet dsCompany)
		{
			try
			{
				SqlDatabase db = new SqlDatabase(conString);
				db.LoadDataSet(CommandType.StoredProcedure, "GetPdeCompany", dsCompany, new string[] { "Company" });

				return true;
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

				if (rethrow)
				{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Company:GetPdeCompany");
				}
				return false;
			}
			finally
			{
			}
		}

        public bool SaveCompany(string conString, DataSet dsCompany)
		{
			try
			{
				SqlDatabase db = new SqlDatabase(conString);

				db.UpdateDataSet(dsCompany, "Company",
					GetDbCommand(db, "AddUpdatePdeCompany"),
					GetDbCommand(db, "AddUpdatePdeCompany"),
					GetDbCommand(db, "DeletePdeCompany"),
					UpdateBehavior.Standard);

				return true;
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

				if (rethrow)
				{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Company:SaveCompany");
				}
				return false;
			}
			finally
			{
			}
		}

		public static string GetNewCompanyNo(string conString)
		{
			try
			{
				SqlDatabase db = new SqlDatabase(conString);
				return db.ExecuteScalar(CommandType.StoredProcedure, "GetNewCompanyNo").ToString();
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

				if (rethrow)
				{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Company:GetNewCompanyNo");
				}
				return null;
			}
			finally
			{
			}
		}

        public bool GetCompanyAux(string conString, DataSet dsCompanyAux)
		{
			try
			{
				SqlDatabase db = new SqlDatabase(conString);
				db.LoadDataSet(CommandType.StoredProcedure, "GetPdeCompanyAux", dsCompanyAux, new string[] { "Contact", "Facility" });

				return true;
			}
			catch (Exception ex)
			{
				bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

				if (rethrow)
				{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Company:GetCompanyAux");
				}
				return false;
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
