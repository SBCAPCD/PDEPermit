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
using SbcapcdOrg.ControlLibrary;
//using SbcapcdOrg.PdePermit.PdePermitComponents;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;


namespace SbcapcdOrg.PdePermit.Device
{
	class DeviceDL
	{

		private static string GetConnection()
		{
			//string ss = DBConnection.GetSQLConnectString(ConString.ConnectionString);
			//return ss;
			return null;
		}

		public bool GetDeviceList(string conString, DataSet dsDeviceList)
		{
			try
			{
                SqlDatabase db = new SqlDatabase(conString);
				db.LoadDataSet(CommandType.StoredProcedure, "GetPdeDeviceList2", dsDeviceList, new string[] { "SourceFaciltiyPermit", "DeviceList" }); // "SourceFaciltiyPermit", 

				return true;
			}
			catch (Exception ex)
			{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Device:GetDeviceList");
                    return false;
			}
			finally
			{
			}
		}

		public bool GetDeviceList(string conString, DataSet dsDeviceList, object deviceNo)
		{
			try
			{
                SqlDatabase db = new SqlDatabase(conString);
				db.LoadDataSet("GetPdeDeviceListByDevice", dsDeviceList, new string[] { "DeviceList" }, new object[] { deviceNo }); // "SourceFaciltiyPermit", 

				return true;
			}
			catch (Exception ex)
			{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Device:GetDeviceList");
				return false;
			}
			finally
			{
			}
		}

		public DataSet GetPermitNo(string conString, string permitNumber)
		{
			DataSet PermitsDS = null;
			SqlDatabase db = new SqlDatabase(conString);

			try
			{
				string docType = null;
				string permitSuffix = null;

				//SqlParameter[] arParms = new SqlParameter[3];

				//// @DocType Input Parameter
				//arParms[0] = new SqlParameter("@DocType", SqlDbType.NVarChar, 12);
				//arParms[0].Value = docType;

				//// @PermitNumber Input Parameter 
				//arParms[1] = new SqlParameter("@PermitNumber", SqlDbType.NVarChar, 5);
				//arParms[1].Value = permitNumber;

				//// @PermitSuffix Input Parameter 
				//arParms[2] = new SqlParameter("@PermitSuffix", SqlDbType.NVarChar, 2);
				//arParms[2].Value = permitSuffix;

				PermitsDS = db.ExecuteDataSet("GetPermitNo", new object[3]{docType, permitNumber, permitSuffix});

				//SqlHelper.ExecuteDataset(connection, , );
				PermitsDS.Tables[0].TableName = "Permit";
				DataColumn[] keys = new DataColumn[1];

				keys[0] = PermitsDS.Tables["Permit"].Columns["PermitNo"];

				PermitsDS.Tables["Permit"].PrimaryKey = keys;

				return PermitsDS;
			}
			catch (Exception ex)
			{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Device:GetPermitNo");
				return null;
			}
			finally
			{
			}
		}

		public bool GetFacilityDevice(string conString, DataSet dsFacilityDevice, string facilityNo)
		{
			dsFacilityDevice.Clear();
            SqlDatabase db = new SqlDatabase(conString);

			try
			{
				DbCommand dbCommand = db.GetStoredProcCommand("GetPdeFacilityDevice", facilityNo);
				db.LoadDataSet(dbCommand, dsFacilityDevice, new string[] { "Device" });

				return true;
			}
			catch (Exception ex)
			{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Device:GetFacilityDevice");
				return false;
			}
			finally
			{
			}
		}

		public bool GetFacilityList(string conString, DataSet dsFacilityList)
		{
			try
			{
                SqlDatabase db = new SqlDatabase(conString);
				db.LoadDataSet(CommandType.StoredProcedure, "GetFacilitiesWithDevices3", dsFacilityList, new string[] { "FacilityList" });

				return true;
			}
			catch (Exception ex)
			{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Device:GetFacilityList");
				return false;
			}
			finally
			{
			}
		}


	}
}
