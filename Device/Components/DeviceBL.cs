using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
//using SbcapcdOrg.PdePermit.PdePermitComponents;
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PdePermit.Device
{
	class DeviceBL
	{
		private static int NavigateKey = 0;
		private System.Windows.Forms.TreeView trvDeviceRef;
		private static SortedList slFillNavigate;
		private static DataTable DtDeviceList;
		private static DataTable RecursiveTable;
		private static string SortPermitsWithDevice = "PermitNumber ASC, PermitSuffix ASC";

		public bool GetFacilityDevice(string conString, DataSet dsFacilityDevice, string facilityNo)
		{
			try
			{
				dsFacilityDevice.Clear();
				SbcapcdOrg.PdePermit.Device.DeviceDL getFacilityDevice = new DeviceDL();
				//getFacilityDevice
                return getFacilityDevice.GetFacilityDevice(conString, dsFacilityDevice, facilityNo);
			}
			catch (Exception ex)
			{
				

				
				
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex);
				
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
				SbcapcdOrg.PdePermit.Device.DeviceDL getFacilityList = new DeviceDL();
                return getFacilityList.GetFacilityList(conString, dsFacilityList);
			}
			catch
			{
				MessageBox.Show("Error getting Facilities", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
			{
			}
		}


		public bool GetDeviceList(string conString, DataSet dsDeviceList)
		{
			try
			{
				dsDeviceList.Clear();
				SbcapcdOrg.PdePermit.Device.DeviceDL getDeviceList = new DeviceDL();
                getDeviceList.GetDeviceList(conString, dsDeviceList);
				DataRow NewRow = dsDeviceList.Tables[0].NewRow();
				NewRow[0] = '0';

				dsDeviceList.Tables[0].Rows.InsertAt(NewRow, 0);

				return true;
			}
			catch (Exception ex)
			{
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex);
				
				return false;
			}
			finally
			{
			}
		}

		public bool GetDeviceList(string conString, DataSet dsDeviceList, string deviceNo)
		{
			try
			{
				dsDeviceList.Clear();
				SbcapcdOrg.PdePermit.Device.DeviceDL getDeviceList = new DeviceDL();
                getDeviceList.GetDeviceList(conString, dsDeviceList, deviceNo);

				return true;
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex);
				
				return false;
			}
			finally
			{
			}
		}

		public DataSet GetPermitNo(string conString, string permitNumber, System.Windows.Forms.ComboBox cmbPermits)
		{
			string facilityNo = null;
			DataSet PermitsDS = null;
			try
			{
				SbcapcdOrg.PdePermit.Device.DeviceDL getPermitNo = new DeviceDL();
                PermitsDS = getPermitNo.GetPermitNo(conString, permitNumber);

				if (PermitsDS.Tables[0].Rows.Count > 1)
				{
					cmbPermits.DataSource = PermitsDS.Tables[0];
					cmbPermits.DisplayMember = "Permit";
					cmbPermits.ValueMember = "PermitNo";
					facilityNo = PermitsDS.Tables[0].Rows[1]["FacilityNo"].ToString();
					return PermitsDS;
				}
				else
				{
					return PermitsDS;
				}
			}
			catch (Exception ex)
			{
				string errMessage = "";
				for (Exception tempException = ex; tempException != null; tempException = tempException.InnerException)
				{
					errMessage += tempException.Message + Environment.NewLine + Environment.NewLine;
				}
				MessageBox.Show("Error GetPermitNo", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return PermitsDS;
			}
			finally
			{
			}
		}

		public static DataTable CreatedtDeviceList()
		{
			DataTable dtDeviceList = new DataTable();
			dtDeviceList.Columns.Add("NavigateKey", typeof(int));
			dtDeviceList.Columns.Add("DeviceNo", typeof(string));
			dtDeviceList.Columns.Add("PermitNoDeviceNo", typeof(string));
			dtDeviceList.Columns.Add("DeviceName", typeof(string));
			return dtDeviceList;
		}

		public static void FillDtPermitsWithDevice(object deviceNo, DataTable dtPermitsWithDevice, DataTable deviceList)
		{
			dtPermitsWithDevice.Clear();
			DataRow[] Rows = deviceList.Copy().Select("DeviceNo ='" + deviceNo.ToString() + "'", SortPermitsWithDevice);

			for (int i = 0; i < Rows.Length; i++)
				dtPermitsWithDevice.ImportRow(Rows[i]);
		}

		public void FillFlatNavigation(DataSet deviceDS, System.Windows.Forms.TreeView trvDevices, string deviceNo, SortedList slNavigate, DataTable dtDeviceList)
		{
			slNavigate.Clear();
			slFillNavigate = slNavigate;
			if (dtDeviceList != null)
			{
				dtDeviceList.Clear();
			}
			trvDevices.Nodes.Clear();
			string SortDevice = "DeviceNo ASC";
			try
			{
				DataRow[] sortedRows = deviceDS.Tables["DeviceList"].Copy().Select("DeviceNo ='" + deviceNo + "'", SortDevice);
				for (int i = 0; i < sortedRows.Length; i++)
				{
					TreeNode DeviceNode = new TreeNode();
					DeviceNode.Name = sortedRows[i]["PermitNoDeviceNo"].ToString();
					DeviceNode.Text = sortedRows[i]["DeviceName"].ToString() + " ::: " + sortedRows[i]["Permit"].ToString();
					DeviceNode.Tag = sortedRows[i]["PermitNoDeviceNo"].ToString();

					trvDevices.Nodes.Add(DeviceNode);
					slNavigate.Add(i, sortedRows[i]["PermitNoDeviceNo"].ToString());
					DataRow newRow = dtDeviceList.NewRow();
					newRow["NavigateKey"] = i;
					newRow["DeviceNo"] = sortedRows[i]["DeviceNo"].ToString();
					newRow["PermitNoDeviceNo"] = sortedRows[i]["PermitNoDeviceNo"].ToString();
					newRow["DeviceName"] = sortedRows[i]["DeviceName"].ToString() + " ::: " + sortedRows[i]["Permit"].ToString();
					dtDeviceList.Rows.Add(newRow);
				}
				//dtDeviceList.
					//           dtDeviceList..BeginInvoke(new InvokeDelegate(InvokeMethod));
					
					//public void InvokeMethod()
					
					//   myTextBox.Text = "Executed the given delegate";
					


				dtDeviceList = DtDeviceList;
			}
			catch (Exception ex)
			{
				string errMessage = "";
				for (Exception tempException = ex; tempException != null; tempException = tempException.InnerException)
				{
					errMessage += tempException.Message + Environment.NewLine + Environment.NewLine;
				}
				MessageBox.Show("Error FillFlatNavigation", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
			}
		}



		public void FillNavigation(DataSet deviceDS, System.Windows.Forms.TreeView trvDevices, string permitNo, SortedList slNavigate, DataTable dtDeviceList)
		{
			slNavigate.Clear();
			slFillNavigate = slNavigate;
			dtDeviceList.Clear();
			DtDeviceList = dtDeviceList;
			DataSet DeviceTreeDS = deviceDS.Clone();
			string SortSubDevice = "SubDeviceOf ASC, SortOrder ASC";
			DataRow[] sortedRows = deviceDS.Tables["DeviceList"].Copy().Select("PermitNo ='" + permitNo + "'", SortSubDevice);

			for (int i = 0; i < sortedRows.Length; i++)
				DeviceTreeDS.Tables["DeviceList"].ImportRow(sortedRows[i]);

			try
			{
				trvDeviceRef = trvDevices;
				DeviceTreeDS.Tables["DeviceList"].Columns.Add(new DataColumn("Depth", typeof(Int32)));
				DataRelation rel = new DataRelation("ParentChild", DeviceTreeDS.Tables["DeviceList"].Columns["DeviceNo"], DeviceTreeDS.Tables["DeviceList"].Columns["SubDeviceOf"], false);
				rel.Nested = true;
				DeviceTreeDS.Relations.Add(rel);

				// configure our global table
				RecursiveTable = DeviceTreeDS.Tables["DeviceList"].Clone();

				// pass in the top-level rows
				TreeNode startNode = new TreeNode();
				startNode = null;
				ComputeDeviceNavigationHierarchy(DeviceTreeDS.Tables["DeviceList"].Select("SubDeviceOf='0'", SortSubDevice), 0, startNode);
				dtDeviceList = DtDeviceList;
				//slNavigate = slFillNavigate;
			}
			catch (Exception ex)
			{
				string errMessage = "";
				for (Exception tempException = ex; tempException != null; tempException = tempException.InnerException)
				{
					errMessage += tempException.Message + Environment.NewLine + Environment.NewLine;
				}
				MessageBox.Show("Error getting Devices", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				if (DeviceTreeDS != null)
					DeviceTreeDS.Dispose();
			}
		}

		private void ComputeDeviceNavigationHierarchy(DataRow[] members, Int32 depth, TreeNode parentNode) //http://www.aspalliance.com/showusyourcode/CanonicalHierarchy.aspx
		{
			foreach (DataRow member in members)
			{
				int nodeIndex;
				member["Depth"] = depth;
				TreeNode DeviceNode = new TreeNode();
				DeviceNode.Name = member["PermitNoDeviceNo"].ToString();
				DeviceNode.Text = member["DeviceName"].ToString();
				DeviceNode.Tag = member["PermitNoDeviceNo"].ToString();

				if (depth == 0 || parentNode == null)
				{
					trvDeviceRef.Nodes.Add(DeviceNode);
					slFillNavigate.Add(NavigateKey, member["PermitNoDeviceNo"].ToString());
					DataRow newRow = DtDeviceList.NewRow();
					newRow["NavigateKey"] = NavigateKey;
					newRow["DeviceNo"] = member["DeviceNo"].ToString();
					newRow["PermitNoDeviceNo"] = member["PermitNoDeviceNo"].ToString();
					newRow["DeviceName"] = member["DeviceName"].ToString();
					DtDeviceList.Rows.Add(newRow);
					NavigateKey++;
				}
				else
				{
					parentNode.Nodes.Add(DeviceNode);
					slFillNavigate.Add(NavigateKey, member["PermitNoDeviceNo"].ToString());
					DataRow newRow = DtDeviceList.NewRow();
					newRow["NavigateKey"] = NavigateKey;
					newRow["DeviceNo"] = member["DeviceNo"].ToString();
					newRow["PermitNoDeviceNo"] = member["PermitNoDeviceNo"].ToString();
					newRow["DeviceName"] = member["DeviceName"].ToString();
					DtDeviceList.Rows.Add(newRow);
					NavigateKey++;
				}
				nodeIndex = DeviceNode.Index;
				ComputeDeviceNavigationHierarchy(member.GetChildRows("ParentChild"), depth + 1, DeviceNode);
			}
		}

		//private void SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(Exception ex)
		
		//  StringBuilder sb = new StringBuilder();
		//  StringWriter writer = new StringWriter(sb);

		//  AppTextExceptionFormatter formatter = new AppTextExceptionFormatter(writer, ex);

		//  // Format the exception
		//  formatter.Format();
		//  MessageBox.Show(sb.ToString(), "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		

	}
}
