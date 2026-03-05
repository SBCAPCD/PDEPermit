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
using SbcapcdOrg.ControlLibrary;
using SbcapcdOrg.PdePermit.PdePermitComponents;

namespace SbcapcdOrg.PdePermit.Forms
{
	class PdePermitDL
	{

        public bool GetPdePermitFormsAux(string conString, DataSet dsPdePermitFormsAux)
		{
			try
			{
				SqlDatabase db = new SqlDatabase(conString);
				db.LoadDataSet(CommandType.StoredProcedure, "[GetPdePermitFormsAux]", dsPdePermitFormsAux, new string[] { "CompaniesWithFacilities" });

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

        public static DataSet GetApplicationParameters(string conString, string application)
		{
			try
			{
				SqlDatabase db = new SqlDatabase(conString);
				DataSet ApplicationParametersDS = db.ExecuteDataSet("GetApplicationParameters", new object[1] { application });

				return ApplicationParametersDS;
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

        public bool GetConnectionStrings(string conString, DataSet dsConnectionStrings)
		{
			try
			{
				bool ConnectionFailed = false;
                SqlDatabase db = null;

				try
				{
                    db = new SqlDatabase(conString);
					DbConnection connection = db.CreateConnection();
					connection.Open();
				}
				catch 
				{
					ConnectionFailed = true;
				}

				if (ConnectionFailed)
				{
					try
					{
                        db = new SqlDatabase("PSATestConnectionString");
						DbConnection connection = db.CreateConnection();
						connection.Open();
					}
					catch (Exception ex)
					{
						ConnectionFailed = true;
						bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

						if (rethrow)
						{
							SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Permit:GetPermit");
						}
						return false;
					}
				}

				//SqlDatabase db = new SqlDatabase(conString);
				db.LoadDataSet(CommandType.StoredProcedure, "GetConnectionStrings", dsConnectionStrings, new string[] { "ConnectionStrings" });

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

	}
}
