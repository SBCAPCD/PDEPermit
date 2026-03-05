using System;
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
using SbcapcdOrg.PdePermit.PdePermitComponents;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PdePermit.PdePermitComponents
{
	public class CommonDL
	{
		public static bool GetUseShortPath(string conString, object application)
		{
			try
			{
				Hashtable htApplicationParameter = new Hashtable();

				DataSet dsApplicationParameters = GetApplicationParameters(conString, application);

				foreach (DataRow drApplicationParameter in dsApplicationParameters.Tables[0].Rows)
				{
					CommonPdePermitMethods.SetHashtable(htApplicationParameter, drApplicationParameter["Parameter"], drApplicationParameter["ParameterValue"]);
				}

				if (htApplicationParameter.ContainsKey("UseShortPath"))
				{
					return System.Convert.ToBoolean(htApplicationParameter["UseShortPath"]);
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PermitComplianceBL:GetFacilityHistory");
				return false;
			}
		}

		public static DataSet GetApplicationParameters(string conString, object application)
		{
			SqlDatabase db = new SqlDatabase(conString);

			try
			{
				return db.ExecuteDataSet("GetApplicationParameters", new object[] { application });
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

		public static void GetFacilityHistory(string conString, DataSet dsFacilityHistory, object facilityNo)
		{
			SqlDatabase db = new SqlDatabase(conString);
			dsFacilityHistory.EnforceConstraints = false;

			try
			{
				db.LoadDataSet("GetCplFacilityHistory2", dsFacilityHistory, new string[] { "Breakdowns", "NOVs", "Inspections", "Variances", "Permits", "CVRs" }, new object[] { facilityNo });
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "GetFacilityHistory:PermitComplianceDL");
			}
		}

        public static string GetNewKeyByEntity(string conString, string entity)
		{
			try
			{
				SqlDatabase db = new SqlDatabase(conString);
				return db.ExecuteScalar(CommandType.StoredProcedure, "GetNewPersonNo").ToString();
			}
			catch (Exception ex)
			{
				if (ex != null)
				{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PdePermitComponents:GetNewKeyByEntity");
				}
				return null;
			}
			finally
			{
			}
		}

		public static int GetPdeNewId(string conString)
		{
			try
			{
				SqlDatabase db = new SqlDatabase(conString);
				object i = db.ExecuteScalar(CommandType.StoredProcedure, "GetPdeNewId");
				return (int)i;
			}
			catch (Exception ex)
			{
				if (ex != null)
				{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PdePermitComponents:GetPdeNewId");
				}
				return 0;
			}
			finally
			{
			}
		}

	}
}
