using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace SbcapcdOrg.PdePermit.PdePermitComponents
{
	public class CommonPdePermitMethods
	{
		private static StringBuilder sbPath = new StringBuilder();
		static string pattern = " *[\\~#%&*{}/:<>?|\"-]+ *";
		static string replacement = " ";
		static Regex regExReplace = new Regex(pattern);
		public static string sPermittedSources = @"\\Sbcapcd.org\shares\Groups\Permitted Sources\";

		public static string GetFacilityPath(string stationarySourceNo, string facilityNo)
		{
			try
			{
				return sPermittedSources + stationarySourceNo + @"\" + facilityNo;
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "CommonPdePermitMethods : GetFacilityPath");
				return "";
			}
		}

		public static bool CreateStandardFoldersBySsidFid(string stationarySourceNo, string facilityNo)
		{
			try
			{
				sbPath.Clear();
				sbPath.Append(sPermittedSources);

				sbPath.Append(@"\" + stationarySourceNo);

				if (!Directory.Exists(sbPath.ToString()))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString());
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Correspondence"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Correspondence");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Plans"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Plans");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Reports"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Reports");
				}

				sbPath.Append(@"\" + facilityNo);

				if (!Directory.Exists(sbPath.ToString()))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString());
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Annual Reports"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Annual Reports");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Breakdowns"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Breakdowns");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Correspondence"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Correspondence");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\CVRs"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\CVRs");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Deviations"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Deviations");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\File Archive"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\File Archive");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Inspections"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Inspections");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\NOVs"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\NOVs");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Permits"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Permits");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Plans"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Plans");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Reports"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Reports");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Source Tests"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Source Tests");
				}

				if (!Directory.Exists(sbPath.ToString() + @"\Variances"))
				{
					System.IO.Directory.CreateDirectory(sbPath.ToString() + @"\Variances");
				}

				return true;
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "CommonPdePermitMethods : CreateStandardFoldersBySsidFid");
				return false;
			}
		}


		//public static string GetFacilityPath(string conString, string stationarySourceNo, string stationarySourceName, string facilityNo, string facilityName)
		//{
		//	try
		//	{
		//		sbPath.Clear();

		//		if (CommonDL.GetUseShortPath(conString, "FacilityPath"))
		//		{
		//			return sPermittedSources + stationarySourceNo + @"\" + facilityNo;
		//		}
		//		else
		//		{
		//			sbPath.Append(sPermittedSources);
		//			sbPath.Append(stationarySourceNo + " " + stationarySourceName);

		//			if (sbPath.ToString().EndsWith("."))
		//			{
		//				sbPath.Remove(sbPath.Length - 1, 1);
		//			}

		//			sbPath.Append(@"\" + facilityNo + " " + facilityName);

		//			if (sbPath.ToString().EndsWith("."))
		//			{
		//				sbPath.Remove(sbPath.Length - 1, 1);
		//			}

		//			return regExReplace.Replace(sbPath.ToString(), replacement);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		//DisplayException.DisplayExceptionInfo(ex, "CommonComplianceMethods : GetFacilityPath");
		//		return "";
		//	}
		//}

		public static void SetHashtable(Hashtable ht, object keyHT, object valueHT)
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

		public static string IsSinglePdfFile(DragEventArgs args)
		{
			if (args.Data.GetDataPresent(DataFormats.FileDrop, true))
			{
				string[] fileNames = args.Data.GetData(DataFormats.FileDrop, true) as string[];
				if (fileNames.Length == 1)
				{
					if (File.Exists(fileNames[0]) && Path.GetExtension(fileNames[0]).ToUpper() == ".PDF")
					{
						return fileNames[0];
					}
				}
			}
			return null;
		}

		public static bool UserIsGroupMember(string group)
		{
			bool ReturnValue = false;

			//string ssss = GetGroupMembers();

			UserPrincipal currentUserPrincipal = UserPrincipal.Current;
			try
			{
				ReturnValue = currentUserPrincipal.IsMemberOf(currentUserPrincipal.Context, IdentityType.Name, group);

				//foreach (GroupPrincipal groups in currentUserPrincipal.GetGroups())
				//{
				//  sbGroups.Append(groups.ToString());
				//}

				//return sbGroups.ToString();

				//ReturnValue = currentUserPrincipal.GetGroups();
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PdePermitComponents:UserIsGroupMember");
			}

			return ReturnValue;

		}

		public static string GetGroupMembers()
		{
			//bool ReturnValue = false;

			//var domain = new PrincipalContext(ContextType.Domain);

			//if (GroupPrincipal.FindByIdentity(domain, "InspectionEditor") == null) return "false";


			UserPrincipal currentUserPrincipal = UserPrincipal.Current;
			try
			{
				StringBuilder sbGroups = new StringBuilder();
				//ReturnValue = currentUserPrincipal.IsMemberOf(currentUserPrincipal.Context, IdentityType.Name, group);

				foreach (GroupPrincipal groups in currentUserPrincipal.GetGroups())
				{
					sbGroups.Append(groups.ToString() + ", ");
				}

				return sbGroups.ToString();



				//ReturnValue = currentUserPrincipal.GetGroups();
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PdePermitComponents:UserIsGroupMember");
				return "Nothing";
			}

			//return ReturnValue;

		}

		public static string[] GetGroupMembersArray()
		{
			//bool ReturnValue = false;

			UserPrincipal currentUserPrincipal = UserPrincipal.Current;
			try
			{

				string[] sGroups = new string[50];
				//ReturnValue = currentUserPrincipal.IsMemberOf(currentUserPrincipal.Context, IdentityType.Name, group);

				int i = 0;

				foreach (GroupPrincipal groups in currentUserPrincipal.GetGroups())
				{
					sGroups[i] = groups.ToString();
					//sbGroups.Append(groups.ToString() + ", ");
					i++;
				}

				return sGroups;



				//ReturnValue = currentUserPrincipal.GetGroups();
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PdePermitComponents:UserIsGroupMember");
				return null;
			}

			//return ReturnValue;

		}

	}

	public class UserRoles
	{
		private bool isAdmin;
		private bool isEditor;
		private bool isBrowser;
		private bool isContactEd;
		private string currentUser;
		private string loginID;
		private string employeeID;
		private string employeeName;

		public UserRoles(string connectionString)
		{
			isAdmin = false;
			isEditor = false;
			isBrowser = false;
			isContactEd = false;

			SetValues(connectionString);
		}

		private void SetValues(string connectionString)
		{
			try
			{
				SqlDatabase db = new SqlDatabase(connectionString);
				DataSet UserInfo = db.ExecuteDataSet(CommandType.StoredProcedure, "GetUserInfo");

				currentUser = "";
				if (UserInfo.Tables[0].Rows.Count == 1)
				{
					loginID = UserInfo.Tables[0].Rows[0]["LoginID"].ToString();
					employeeID = UserInfo.Tables[0].Rows[0]["EmployeeNo"].ToString();
					employeeName = UserInfo.Tables[0].Rows[0]["EmployeeName"].ToString();
				}

				//isAdmin = isEditor = isBrowser = SbcapcdOrg.PdePermit.PdePermitComponents.CommonPdePermitMethods.UserIsGroupMember("db_owner");
				//isAdmin = isEditor = isBrowser = SbcapcdOrg.PdePermit.PdePermitComponents.CommonPdePermitMethods.UserIsGroupMember("dbo");
				isAdmin = isEditor = isBrowser = SbcapcdOrg.PdePermit.PdePermitComponents.CommonPdePermitMethods.UserIsGroupMember("PdePermitAdmins");
				isEditor = isBrowser = SbcapcdOrg.PdePermit.PdePermitComponents.CommonPdePermitMethods.UserIsGroupMember("PdePermitEditors");
				isBrowser = SbcapcdOrg.PdePermit.PdePermitComponents.CommonPdePermitMethods.UserIsGroupMember("PdePermitBrowsers");

				//foreach (DataRow dr in UserInfo.Tables[0].Rows)
				//{
				//	if (currentUser == "")
				//	{
				//		currentUser = dr[1].ToString();
				//	}

					
				//	//isContactEd = SbcapcdOrg.PdePermit.PdePermitComponents.CommonPdePermitMethods.UserIsGroupMember();

				//	//if (dr[0].ToString().IndexOf("db_owner") > -1)
				//	//{
				//	//	isAdmin = isEditor = isBrowser = true;
				//	//}
				//	//if (dr[0].ToString().IndexOf("Admin") > -1 && dr[0].ToString().IndexOf(application) > -1)
				//	//{
				//	//	isAdmin = isEditor = isBrowser = true;
				//	//}
				//	//if (dr[0].ToString().IndexOf("Editor") > -1 && dr[0].ToString().IndexOf(application) > -1)
				//	//{
				//	//	isEditor = isBrowser = true;
				//	//}
				//	//if (dr[0].ToString().IndexOf("Browser") > -1 && dr[0].ToString().IndexOf(application) > -1)
				//	//{
				//	//	isBrowser = true;
				//	//}
				//	//if (dr[0].ToString().IndexOf("ContactEd") > -1 && dr[0].ToString().IndexOf(application) > -1)
				//	//{
				//	//	isContactEd = true;
				//	//}
				//}
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "SetValues:UserRoles");
			}
			finally
			{
			}
		}

		[Bindable(true)]
		public string CurrentUser
		{
			get
			{
				return currentUser;
			}
			set
			{
				currentUser = CurrentUser;
			}
		}

		[Bindable(true)]
		public bool IsAdmin
		{
			get
			{
				return isAdmin;
			}
			set
			{
				isAdmin = IsAdmin;
			}
		}

		[Bindable(true)]
		public bool IsEditor
		{
			get
			{
				return isEditor;
			}
			set
			{
				isEditor = IsEditor;
			}
		}

		[Bindable(true)]
		public bool IsBrowser
		{
			get
			{
				return isBrowser;
			}
			set
			{
				isBrowser = IsBrowser;
			}
		}

		[Bindable(true)]
		public bool IsContactEd
		{
			get
			{
				return isContactEd;
			}
			set
			{
				isContactEd = IsContactEd;
			}
		}

		[Bindable(true)]
		public string LoginID
		{
			get
			{
				return loginID;
			}
			set
			{
				loginID = LoginID;
			}
		}

		[Bindable(true)]
		public string EmployeeID
		{
			get
			{
				return employeeID;
			}
			set
			{
				employeeID = EmployeeID;
			}
		}

		[Bindable(true)]
		public string EmployeeName
		{
			get
			{
				return employeeName;
			}
			set
			{
				employeeName = EmployeeName;
			}
		}

	}
}
