using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Reporting.WinForms;
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PdePermit.StationarySource
{
	public partial class usrStationarySource : SbcapcdOrg.ControlLibrary.usrUserControl
	{
		#region Variables

		Regex rxNumber = new Regex("[0-9]");
		Regex rxLetter = new Regex("[a-zA-Z]");
		Regex rxSpace = new Regex(" ");
		Regex rxInvalid = new Regex("[#%*[']");
		object StationarySourceNo = null;
		object PreviousStationarySourceNo = null;
		object PreSortStationarySourceNo = null;
		private string CompanyNo = null;
		private object oNull = null;
		public bool StationarySourceDataSetHasChanges = false;
		public bool HasNewSources = false;
		private SbcapcdOrg.ControlLibrary.UserRoles PdePermitUserRoles = null;
		private SbcapcdOrg.PdePermit.PdePermitComponents.UserRoles PdeUserRoles = null;
		private SbcapcdOrg.ControlLibrary.usrRadioButton radio;
		//private SbcapcdOrg.ControlLibrary.usrGroupBox group;
		private string sss = "";
		Hashtable ApplicationParametersHT;
		private string Entity = null;
		private object EntityNo = "00000";
		private bool IsSelectMode = false;
		private bool InCurrentChangedDialog = false;
		private bool CurrentChangedCancelled = false;
		private bool StationarySourceLoadEnd = false;
		int StationarySourcePos = 0;
		int PreviousStationarySourcePos = 0;
		private string StationarySourceFilter = "";
		private bool HasNewLocationAddress = false;
		//int iiibsStationarySourceCompany;
		private int FilterTicks = 0;

		public bool LoadEnded { get; set; }


		#endregion

		public usrStationarySource()
		{
			InitializeComponent();
			dsStationarySource.StationarySource.ColumnChanged += new DataColumnChangeEventHandler(StationarySource_ColumnChanged);
			dsStationarySource.StationarySourceHraHistory.ColumnChanged += new DataColumnChangeEventHandler(StationarySourceHraHistory_ColumnChanged);
			dsStationarySource.StationarySourceToxicsActionHistory.ColumnChanged += new DataColumnChangeEventHandler(StationarySourceToxicsActionHistory_ColumnChanged);


			//reportViewer1.LocalReport.ReportPath = 

			LoadEnded = false;
		}

		#region LoadStationarySource

		public void SetStationarySourceUserRoles(SbcapcdOrg.ControlLibrary.UserRoles pdePermitUserRoles)
		{
			PdePermitUserRoles = pdePermitUserRoles;

			if (PdePermitUserRoles != null)
			{
				tsbtnNewStationarySource.Enabled = PdePermitUserRoles.IsAdmin;
				tsbtnSaveStationarySource.Enabled = PdePermitUserRoles.IsAdmin;
				tsbtnDeleteStationarySource.Enabled = PdePermitUserRoles.IsAdmin;
				//tsbtnUndo.Enabled = PdePermitUserRoles.IsAdmin; PdePermitEditors

				//if (SbcapcdOrg.PdePermit.PdePermitComponents.CommonPdePermitMethods.UserIsGroupMember("PdePermitEditors"))
				//if (SbcapcdOrg.PdePermit.PdePermitComponents.CommonPdePermitMethods.UserIsGroupMember("PdePermitEditors") || PdePermitUserRoles.IsEditor)
				if (PdePermitUserRoles.IsEditor)
				{
					btnDeleteHealthRiskAssessmentHistory.Enabled = true;
					btnDeleteToxicsActionHistory.Enabled = true;
					dgvStationarySourceHraHistory.AllowUserToAddRows = true;
					dgvStationarySourceHraHistory.AllowUserToDeleteRows = true;
				}
				else
				{
					btnDeleteHealthRiskAssessmentHistory.Enabled = false;
					btnDeleteToxicsActionHistory.Enabled = false;
					dgvStationarySourceHraHistory.AllowUserToAddRows = false;
					dgvStationarySourceHraHistory.AllowUserToDeleteRows = false;
				}

				StationarySourceLocation.SetLocationUserRoles(PdeUserRoles);
			}
		}

		public void SetStationarySourceUserRoles(SbcapcdOrg.PdePermit.PdePermitComponents.UserRoles pdeUserRoles)
		{
			//PdeUserRoles = pdeUserRoles;

			//if (PdeUserRoles != null)
			//{
			//	tsbtnNewStationarySource.Enabled = PdeUserRoles.IsAdmin;
			//	tsbtnSaveStationarySource.Enabled = PdeUserRoles.IsAdmin;
			//	tsbtnDeleteStationarySource.Enabled = PdeUserRoles.IsAdmin;
			//	//tsbtnUndo.Enabled = PdePermitUserRoles.IsAdmin; PdePermitEditors

			//	//if (SbcapcdOrg.PdePermit.PdePermitComponents.CommonPdePermitMethods.UserIsGroupMember("PdePermitEditors"))
			//	//if (SbcapcdOrg.PdePermit.PdePermitComponents.CommonPdePermitMethods.UserIsGroupMember("PdePermitEditors") || PdePermitUserRoles.IsEditor)
			//	if (PdeUserRoles.IsEditor)
			//	{
			//		btnDeleteHealthRiskAssessmentHistory.Enabled = true;
			//		btnDeleteToxicsActionHistory.Enabled = true;
			//		dgvStationarySourceHraHistory.AllowUserToAddRows = true;
			//		dgvStationarySourceHraHistory.AllowUserToDeleteRows = true;
			//	}
			//	else
			//	{
			//		btnDeleteHealthRiskAssessmentHistory.Enabled = false;
			//		btnDeleteToxicsActionHistory.Enabled = false;
			//		dgvStationarySourceHraHistory.AllowUserToAddRows = false;
			//		dgvStationarySourceHraHistory.AllowUserToDeleteRows = false;
			//	}

			//	StationarySourceLocation.SetLocationUserRoles(PdeUserRoles);
			//}
		}

		public void LoadStationarySource()
		{
			try
			{
				bsStationarySource.SuspendBinding();
				StationarySourceLocation.LocationType = "SSource";

				SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL getStationarySourceAux = new StationarySourceBL();
				getStationarySourceAux.GetStationarySourceAux(base.usrConnectionString, dsStationarySourceAux);

				SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL getStationarySource = new StationarySourceBL();
				getStationarySource.GetStationarySource(base.usrConnectionString, dsStationarySource);

				StationarySourceLocation.LoadLocation();

				DataTable StationarySourceTypeCopy = dsStationarySourceAux.StationarySourceType.Copy();
				DataRow dr = StationarySourceTypeCopy.NewRow();
				dr["StationarySourceTypeId"] = 999;
				dr["StationarySourceType"] = " All Source Types";
				StationarySourceTypeCopy.Rows.Add(dr);
				tscmbSourceType.ComboBox.DataSource = StationarySourceTypeCopy;
				tscmbSourceType.ComboBox.DisplayMember = "StationarySourceType";
				tscmbSourceType.ComboBox.ValueMember = "StationarySourceTypeId";

				cmbTwoDigitSic.DataSource = dsStationarySourceAux.TwoDigitSic;
				cmbSSActiveFilter.SelectedItem = "Active";
				bsStationarySource.ResumeBinding();
				bsStationarySource.Position = 0;
				FilterSource();
				lbxFacilitiesList.ClearSelected();
				lbxPermitList.ClearSelected();

				SetAb2588CategoryText();
				StationarySourceDataSetHasChanges = false;
				StationarySourceLoadEnd = true;
				StationarySourceLocation.LoadEnded = true;
				bsStationarySource.MoveNext();
				bsStationarySource.MoveFirst();
				CheckToxicsFilingFolder();
				//MessageBox.Show("Source load ended");
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "LoadStationarySource");
			}
			finally
			{
				StationarySourceDataSetHasChanges = false;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
				OnStationarySourceDataSetChanged(this, args);
			}
		}

		private void LoadStationarySource(BackgroundWorker worker, DoWorkEventArgs e)
		{
			worker.ReportProgress(0, "Loading...");
			StationarySourceLocation.LocationType = "SSource";
			StationarySourceLocation.LoadLocation();

			worker.ReportProgress(20, "Loading...");

			SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL getStationarySourceAux = new StationarySourceBL();
			getStationarySourceAux.GetStationarySourceAux(base.usrConnectionString, dsStationarySourceAux);

			worker.ReportProgress(60, "Loading...");

			SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL getStationarySource = new StationarySourceBL();
			getStationarySource.GetStationarySource(base.usrConnectionString, dsStationarySource);

			worker.ReportProgress(80, "Loading...");

		}

		private void bwLoadStationarySource_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			LoadStationarySource(worker, e);
		}

		private void bwLoadStationarySource_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message);
			}
			else if (e.Cancelled)
			{
			}
			else
			{
				bsStationarySourceType.Sort = "StationarySourceType";
				bsTwoDigitSic.Sort = "TwoDigitSicName";

				DataTable StationarySourceTypeCopy = dsStationarySourceAux.StationarySourceType.Copy();
				DataRow dr = StationarySourceTypeCopy.NewRow();
				dr["StationarySourceTypeId"] = 999;
				dr["StationarySourceType"] = " All Source Types";
				StationarySourceTypeCopy.Rows.Add(dr);
				tscmbSourceType.ComboBox.DataSource = StationarySourceTypeCopy;
				tscmbSourceType.ComboBox.DisplayMember = "StationarySourceType";
				tscmbSourceType.ComboBox.ValueMember = "StationarySourceTypeId";
				tscmbSourceType.SelectedIndex = 0;
				bsStationarySource.Position = 0;
				FilterSource();
				CheckToxicsFilingFolder();
				StationarySourceLoadEnd = true;
				StationarySourceLocation.LoadEnded = true;
				MessageBox.Show("Source load ended");
			}
		}

		#endregion

		#region Has Changes

		private void StationarySource_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			PreviousStationarySourcePos = bsStationarySource.Position;
			CheckForUnsavedChanges(e);
		}

		void StationarySourceToxicsActionHistory_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			CheckForUnsavedChanges(e);
		}

		void StationarySourceHraHistory_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			CheckForUnsavedChanges(e);
		}

		protected void CheckForUnsavedChanges(DataColumnChangeEventArgs e)
		{
			//if (StationarySourceLoadEnd)
			//{
			//	if (PdeUserRoles.IsAdmin || PdeUserRoles.IsEditor)
			//	{
			//		bool checkForChanges = CommonMethods.CheckForChanges(StationarySourceDataSetHasChanges, e);
			//		if (StationarySourceDataSetHasChanges != checkForChanges)
			//		{
			//			StationarySourceDataSetHasChanges = checkForChanges;
			//			SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
			//			OnStationarySourceDataSetChanged(this, args);
			//		}
			//	}
			//}

			if (StationarySourceLoadEnd)
			{
				if (PdePermitUserRoles.IsAdmin || PdePermitUserRoles.IsEditor)
				{
					bool checkForChanges = CommonMethods.CheckForChanges(StationarySourceDataSetHasChanges, e);
					if (StationarySourceDataSetHasChanges != checkForChanges)
					{
						StationarySourceDataSetHasChanges = checkForChanges;
						SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
						OnStationarySourceDataSetChanged(this, args);
					}
				}
			}
		}

		protected bool CheckForChanges(DataColumnChangeEventArgs e)
		{
			string ChangingColumnName = e.Column.ToString();
			if (HasNewSources || StationarySourceLocation.LocationDataSetHasChanges || StationarySourceDataSetHasChanges)
			{
				return true;
			}
			else if (!e.Row.HasVersion(DataRowVersion.Original))
			{
				return true;
			}
			else if (e.ProposedValue == null && e.Row[ChangingColumnName] != System.DBNull.Value)
			{
				return true;
			}
			else if (e.ProposedValue != null && e.ProposedValue != System.DBNull.Value && e.Row[ChangingColumnName] == System.DBNull.Value)
			{
				return true;
			}
			else if (e.ProposedValue != null && e.Row[ChangingColumnName] != System.DBNull.Value)
			{
				if (e.ProposedValue.ToString() != e.Row[ChangingColumnName, DataRowVersion.Original].ToString())
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}


		public delegate void StationarySourceDataSetChangedEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs e);


		public event StationarySourceDataSetChangedEventHandler OnStationarySourceDataSetChanged;

		private void StationarySourceLocation_OnLocatioDataSetChanged()
		{
			StationarySourceDataSetHasChanges = true;
			SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
			OnStationarySourceDataSetChanged(this, args);
		}

		#endregion

		#region Filter

		private void tstxtStationarySourceFilter_TextChanged(object sender, EventArgs e)
		{
			if (!IsSelectMode)
			{
				SSourceFilterTimer.Stop();
				FilterTicks = 0;
				SSourceFilterTimer.Start();
			}
			else if (IsSelectMode && tstxtStationarySourceFilter.Text != "")
			{
				SSourceFilterTimer.Stop();
				FilterTicks = 0;
				SSourceFilterTimer.Start();
			}
		}

		private void SSourceFilterTimer_Tick(object sender, EventArgs e)
		{
			FilterTicks++;
			if (FilterTicks > 3)
			{
				SSourceFilterTimer.Stop();
				FilterTicks = 0;
				this.Parent.Cursor = Cursors.WaitCursor;
				FilterSource();
				this.Parent.Cursor = Cursors.Default;
			}
		}

		public void FilterStationarySourceSelectMode(string entity, object entityNo, string activeAll)
		{
			Entity = entity;
			EntityNo = entityNo;
			IsSelectMode = true;
			PreviousStationarySourceNo = StationarySourceNo;
			bsStationarySource.SuspendBinding();
			CompanyNo = null;
			tscmbSourceType.SelectedIndex = 0;
			tstxtStationarySourceFilter.Clear();
			cmbSSActiveFilter.SelectedItem = activeAll;

			if (entityNo != null)
			{
				if (activeAll == "All")
				{
					bsStationarySource.Filter = entity + " = '" + entityNo.ToString() + "'";
				}
				else
				{
					bsStationarySource.Filter = entity + " = '" + entityNo.ToString() + "' AND PermitStatus = '" + activeAll + "'";
				}
			}

			bsStationarySource.ResumeBinding();
			SetRowColor();
			GoToStationarySourceAfterFilter(PreviousStationarySourceNo);
		}

		public void FilterStationarySourceSelectMode(string activeAll)
		{
			PreviousStationarySourceNo = StationarySourceNo;
			bsStationarySource.SuspendBinding();
			CompanyNo = null;
			tscmbSourceType.SelectedIndex = 0;
			tstxtStationarySourceFilter.Clear();
			cmbSSActiveFilter.SelectedItem = activeAll;

			if (EntityNo != null)
			{
				if (activeAll == "All")
				{
					bsStationarySource.Filter = Entity + " = '" + EntityNo.ToString() + "'";
				}
				else
				{
					bsStationarySource.Filter = Entity + " = '" + EntityNo.ToString() + "' AND PermitStatus = '" + activeAll + "'";
				}
			}

			bsStationarySource.ResumeBinding();
			SetRowColor();
			GoToStationarySourceAfterFilter(PreviousStationarySourceNo);
		}

		private void FilterLists()
		{
			if (bsStationarySource.Current != null)
			{
				DataRowView drvSS = bsStationarySource.Current as DataRowView;
				if (drvSS != null)
				{

					if (cmbSSActiveFilter.SelectedItem != null && cmbSSActiveFilter.SelectedItem.ToString() == "Active")
					{
						bsFacilityList.Filter = "StationarySourceNo = '" + drvSS["StationarySourceNo"].ToString() + "' AND PermitStatus = 'Active'";
					}
					else
					{
						bsFacilityList.Filter = "StationarySourceNo = '" + drvSS["StationarySourceNo"].ToString() + "'";
					}






					if (cmbSSActiveFilter.SelectedItem != null && cmbSSActiveFilter.SelectedItem.ToString() == "Active")
					{
						bsPermitList.Filter = "StationarySourceNo = '" + drvSS["StationarySourceNo"].ToString() + "' AND PermitStatus = 'Active'";
						bsHraPermitList.Filter = "StationarySourceNo = '" + drvSS["StationarySourceNo"].ToString() + "' OR StationarySourceNo = '0'";
					}
					else
					{
						bsPermitList.Filter = "StationarySourceNo = '" + drvSS["StationarySourceNo"].ToString() + "'";
						bsHraPermitList.Filter = "StationarySourceNo = '" + drvSS["StationarySourceNo"].ToString() + "' OR StationarySourceNo = '0'";
					}

					lbxFacilitiesList.ClearSelected();
					lbxPermitList.ClearSelected();
				}
				else
				{
					bsPermitList.Filter = "StationarySourceNo = 'None'";
					bsHraPermitList.Filter = "StationarySourceNo = 'None'";
					bsFacilityList.Filter = "StationarySourceNo = 'None'";
				}
			}
		}

		private void tscmbSourceType_SelectedIndexChanged(object sender, EventArgs e)
		{
			FilterSource();
		}

		public void ResetFilters()
		{
			PreviousStationarySourceNo = StationarySourceNo;
			Entity = null;
			EntityNo = "00000";
			IsSelectMode = false;
			CompanyNo = null;
			tscmbSourceType.SelectedIndex = 0;
			tstxtStationarySourceFilter.Clear();
			cmbSSActiveFilter.SelectedItem = "Active";
			InCurrentChangedDialog = true;
			FilterSource();
			InCurrentChangedDialog = true;
			GoToStationarySourceAfterFilter(PreviousStationarySourceNo);
		}

		private void tsbtnDefaultFilters_Click(object sender, EventArgs e)
		{
			ResetFilters();
		}

		public void SetCompanyFilter(string companyNo)
		{
			CompanyNo = companyNo;
			FilterSource();
		}

		private void FilterSource()
		{
			InCurrentChangedDialog = true;
			PreSortStationarySourceNo = StationarySourceNo;
			bsStationarySource.SuspendBinding();
			if (rxInvalid.IsMatch(tstxtStationarySourceFilter.Text))
			{
				MessageBox.Show("Some characters in the search text are special and will not be used in the search.", "Special characteres #%*[']", MessageBoxButtons.OK);
			}

			StationarySourceFilter = rxInvalid.Replace(tstxtStationarySourceFilter.Text, "");
			//PreviousStationarySourceNo = StationarySourceNo;
			if (bsStationarySource.Position > -1)
			{
				DataRowView drvSS = bsStationarySource.Current as DataRowView;
				if (drvSS != null)
				{
					StationarySourceNo = drvSS["StationarySourceNo"];
				}
			}
			if (CompanyNo != null)
			{
				#region Company Filter

				//bsStationarySource.DataSource = bsStationarySourceWCompanyFilter;
				//iiibsStationarySourceCompany = bsStationarySourceCompany.Find("CompanyNo", CompanyNo); 
				//bsStationarySourceCompany.Position = bsStationarySourceCompany.Find("CompanyNo", CompanyNo);
				bsStationarySourceCompany.Filter = "CompanyNo = '" + CompanyNo + "'";

				StringBuilder sb = new StringBuilder();
				int i = 0;
				DataRowView drv;
				bsStationarySourceCompany.MoveFirst();
				while (i < bsStationarySourceCompany.Count)
				{
					drv = (DataRowView)bsStationarySourceCompany.Current;
					sb.Append("'" + drv["StationarySourceNo"].ToString() + "',");
					bsStationarySourceCompany.MoveNext();
					i++;
				}

				string ByCompanyFilter;

				if (sb.ToString() != "")
				{
					ByCompanyFilter = "StationarySourceNo IN (" + sb.ToString() + ") AND ";
				}
				else
				{
					ByCompanyFilter = "StationarySourceNo = 'xxxx' AND ";
				}

				if (tscmbSourceType.SelectedItem != null && (int)((DataRowView)tscmbSourceType.SelectedItem)["StationarySourceTypeId"] != 999)
				{
					#region SS Filter

					int SSTypeId = (int)((DataRowView)tscmbSourceType.SelectedItem)["StationarySourceTypeId"];

					if (cmbSSActiveFilter.SelectedItem != null && cmbSSActiveFilter.SelectedItem.ToString() == "Active")
					{
						if (rxNumber.IsMatch(StationarySourceFilter) && !(rxLetter.IsMatch(StationarySourceFilter) || rxSpace.IsMatch(StationarySourceFilter)))
						{
							bsStationarySource.Filter = ByCompanyFilter + "SourceTypeId = " + SSTypeId + " AND StationarySourceNo LIKE '*" + StationarySourceFilter + "*' AND PermitStatus = '" + cmbSSActiveFilter.SelectedItem.ToString() + "'";
						}
						else
						{
							bsStationarySource.Filter = ByCompanyFilter + "SourceTypeId = " + SSTypeId + " AND StationarySourceName LIKE '*" + StationarySourceFilter + "*' AND PermitStatus = '" + cmbSSActiveFilter.SelectedItem.ToString() + "'";
						}
					}
					else
					{
						if (rxNumber.IsMatch(StationarySourceFilter) && !(rxLetter.IsMatch(StationarySourceFilter) || rxSpace.IsMatch(StationarySourceFilter)))
						{
							bsStationarySource.Filter = ByCompanyFilter + "SourceTypeId = " + SSTypeId + " AND StationarySourceNo LIKE '*" + StationarySourceFilter + "*'";
						}
						else
						{
							bsStationarySource.Filter = ByCompanyFilter + "SourceTypeId = " + SSTypeId + " AND StationarySourceName LIKE '*" + StationarySourceFilter + "*'";
						}
					}
					#endregion
				}
				else
				{
					#region No SS Type Filter

					if (cmbSSActiveFilter.SelectedItem != null && cmbSSActiveFilter.SelectedItem.ToString() == "Active")
					{
						if (rxNumber.IsMatch(StationarySourceFilter) && !(rxLetter.IsMatch(StationarySourceFilter) || rxSpace.IsMatch(StationarySourceFilter)))
						{
							bsStationarySource.Filter = ByCompanyFilter + "StationarySourceNo LIKE '*" + StationarySourceFilter + "*' AND PermitStatus = '" + cmbSSActiveFilter.SelectedItem.ToString() + "'";
						}
						else
						{
							bsStationarySource.Filter = ByCompanyFilter + "StationarySourceName LIKE '*" + StationarySourceFilter + "*' AND PermitStatus = '" + cmbSSActiveFilter.SelectedItem.ToString() + "'";
						}
					}
					else
					{
						if (rxNumber.IsMatch(StationarySourceFilter) && !(rxLetter.IsMatch(StationarySourceFilter) || rxSpace.IsMatch(StationarySourceFilter)))
						{
							bsStationarySource.Filter = ByCompanyFilter + "StationarySourceNo LIKE '*" + StationarySourceFilter + "*'";
						}
						else
						{
							bsStationarySource.Filter = ByCompanyFilter + "StationarySourceName LIKE '*" + StationarySourceFilter + "*'";
						}
					}
					#endregion
				}
				#endregion
			}
			else
			{
				#region No Company Filter

				bsStationarySource.DataSource = bsStationarySourceWOCompanyFilter;


				if (tscmbSourceType.SelectedItem != null && (int)((DataRowView)tscmbSourceType.SelectedItem)["StationarySourceTypeId"] != 999)
				{
					#region SS Filter

					int SSTypeId = (int)((DataRowView)tscmbSourceType.SelectedItem)["StationarySourceTypeId"];

					if (cmbSSActiveFilter.SelectedItem != null && cmbSSActiveFilter.SelectedItem.ToString() == "Active")
					{
						if (rxNumber.IsMatch(StationarySourceFilter) && !(rxLetter.IsMatch(StationarySourceFilter) || rxSpace.IsMatch(StationarySourceFilter)))
						{
							bsStationarySource.Filter = "SourceTypeId = " + SSTypeId + " AND StationarySourceNo LIKE '*" + StationarySourceFilter + "*' AND PermitStatus = '" + cmbSSActiveFilter.SelectedItem.ToString() + "'";
						}
						else
						{
							bsStationarySource.Filter = "SourceTypeId = " + SSTypeId + " AND StationarySourceName LIKE '*" + StationarySourceFilter + "*' AND PermitStatus = '" + cmbSSActiveFilter.SelectedItem.ToString() + "'";
						}
					}
					else
					{
						if (rxNumber.IsMatch(StationarySourceFilter) && !(rxLetter.IsMatch(StationarySourceFilter) || rxSpace.IsMatch(StationarySourceFilter)))
						{
							bsStationarySource.Filter = "SourceTypeId = " + SSTypeId + " AND StationarySourceNo LIKE '*" + StationarySourceFilter + "*'";
						}
						else
						{
							bsStationarySource.Filter = "SourceTypeId = " + SSTypeId + " AND StationarySourceName LIKE '*" + StationarySourceFilter + "*'";
						}
					}
					#endregion
				}
				else
				{
					#region No SS Type Filter

					if (cmbSSActiveFilter.SelectedItem != null && cmbSSActiveFilter.SelectedItem.ToString() == "Active")
					{
						if (StationarySourceFilter.Length > 0 && rxNumber.IsMatch(StationarySourceFilter) && !(rxLetter.IsMatch(StationarySourceFilter) || rxSpace.IsMatch(StationarySourceFilter)))
						{
							bsStationarySource.Filter = "StationarySourceNo LIKE '*" + StationarySourceFilter + "*' AND PermitStatus = '" + cmbSSActiveFilter.SelectedItem.ToString() + "'";
						}
						else if (StationarySourceFilter.Length > 0)
						{
							bsStationarySource.Filter = "StationarySourceName LIKE '*" + StationarySourceFilter + "*' AND PermitStatus = '" + cmbSSActiveFilter.SelectedItem.ToString() + "'";
						}
						else
						{
							bsStationarySource.Filter = "PermitStatus = '" + cmbSSActiveFilter.SelectedItem.ToString() + "'";
						}
					}
					else
					{
						if (StationarySourceFilter.Length > 0 && rxNumber.IsMatch(StationarySourceFilter) && !(rxLetter.IsMatch(StationarySourceFilter) || rxSpace.IsMatch(StationarySourceFilter)))
						{
							bsStationarySource.Filter = "StationarySourceNo LIKE '*" + StationarySourceFilter + "*'";
						}
						else if (StationarySourceFilter.Length > 0)
						{
							bsStationarySource.Filter = "StationarySourceName LIKE '*" + StationarySourceFilter + "*'";
						}
						else
						{
							bsStationarySource.RemoveFilter();
						}
					}
					#endregion
				}
				#endregion
			}

			dgvStationarySource.Refresh();
			SetRowColor();
			InCurrentChangedDialog = true;
			bsStationarySource.ResumeBinding();
			InCurrentChangedDialog = true;
			FilterLists();
			InCurrentChangedDialog = true;
			GoToStationarySourceAfterFilter(PreSortStationarySourceNo);
		}

		private void cmbSSActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (IsSelectMode)
			{
				FilterStationarySourceSelectMode(cmbSSActiveFilter.SelectedItem.ToString());
			}
			else
			{
				FilterSource();
			}
		}

		#endregion

		#region Events/Delegates

		public delegate void EntityCurrentChangedEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs e);

		public event EntityCurrentChangedEventHandler OnEntityCurrentChanged;

		private void btnSaveStationarySource_Click(object sender, EventArgs e)
		{
			this.ParentForm.Cursor = Cursors.WaitCursor;
			SaveStationarySource(true);
			this.ParentForm.Cursor = Cursors.Default;
		}

		private void tbcStationarySource_Selected(object sender, TabControlEventArgs e)
		{
			if (e.TabPage == tabStationarySourceEmissions && StationarySourceNo != null)
			{
				GetStationarySourceEmissions(StationarySourceNo);
			}
			//else if (e.TabPage == tabAirToxics)
			//{
			//    CheckToxicsFilingFolder();
			//}
		}

		private void btnUndo_Click(object sender, EventArgs e)
		{
			StationarySourceRejectChanges();
		}

		public delegate void NewStationarySourceEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityHasNewItemEventArgs e);

		public event NewStationarySourceEventHandler OnNewStationarySource;

		//public delegate void NewStationarySourceLocationAddressEventHandler();

		//public event NewStationarySourceLocationAddressEventHandler OnNewStationarySourceLocationAddressEventHandler;

		private void tsbNewStationarySource_Click(object sender, EventArgs e)
		{
			NewStationarySource();
		}

		private void dgvStationarySourceHraHistory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			if (!(MessageBox.Show("Do you want to Delete the current Health Risk Assessment History?", "Delete Health Risk Assessment History?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				e.Cancel = true;
			}
		}

		private void dgvToxicsActionHistory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			if (!(MessageBox.Show("Do you want to Delete the current Toxics Action History?", "Delete Health Risk Assessment History?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				e.Cancel = true;
			}
		}

		private void lnkDocumentationFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (ApplicationParametersHT.Contains("SourceToxicsHelpFolder"))
			{
				System.Diagnostics.Process.Start(ApplicationParametersHT["SourceToxicsHelpFolder"].ToString());
			}
		}

		private void dgvStationarySource_Sorted(object sender, EventArgs e)
		{
			GoToStationarySourceAfterFilter(PreviousStationarySourceNo);
		}

		private void dgvStationarySource_MouseDown(object sender, MouseEventArgs e)
		{

			DataRowView drv = bsStationarySource.Current as DataRowView;
			if (drv != null)
			{
				PreviousStationarySourceNo = drv["StationarySourceNo"];
			}
		}

		private void chkIsQuadrennialUpdateSource_Click(object sender, EventArgs e)
		{
			cmbQuadrennialUpdateCycle.Enabled = chkIsQuadrennialUpdateSource.Checked;
		}

		private void btnOpenDocumentationFolder_Click(object sender, EventArgs e)
		{
			if (ApplicationParametersHT.Contains("SourceToxicsHelpFolder"))
			{
				System.Diagnostics.Process.Start(ApplicationParametersHT["SourceToxicsHelpFolder"].ToString());
			}
		}


		#endregion

		#region Navigation

		private void bsStationarySource_PositionChanged(object sender, EventArgs e)
		{
			StationarySourcePos = bsStationarySource.Position;
			int i = PreviousStationarySourcePos;
		}

		private void bsStationarySource_CurrentChanged(object sender, EventArgs e)
		{
			DataRowView drv = bsStationarySource.Current as DataRowView;
			if (drv != null)
			{
				PreviousStationarySourceNo = StationarySourceNo;
				StationarySourceNo = drv["StationarySourceNo"];

				bsStationarySourceHraHistory.Filter = "StationarySourceNo = '" + drv["StationarySourceNo"].ToString() + "'";
				bsStationarySourceToxicsActionHistory.Filter = "StationarySourceNo = '" + drv["StationarySourceNo"].ToString() + "'";
				//bsRiskFacility.Filter = "StationarySourceNo = '" + drv["StationarySourceNo"].ToString() + "' OR StationarySourceNo = '0'";

				FilterLists();
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs argsEntityCurrentChanged = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs("StationarySource", oNull, oNull, drv["StationarySourceNo"]);
				if (OnEntityCurrentChanged != null)
				{
					OnEntityCurrentChanged(this, argsEntityCurrentChanged);
				}
				StationarySourceLocation.GoToLocation(drv["LocationNo"].ToString());

				string sss = drv["Ab2588Category"].ToString();
				grpEPASourceSize.SetGroup(drv["EpaStationarySourceSize"].ToString());
				grpSourceSize.SetGroup(drv["StationarySourceSize"].ToString());
				grpFillingLocation.SetGroup(drv["FillingLocation"].ToString());
				cmbQuadrennialUpdateCycle.Enabled = (bool)drv["IsQuadrennialUpdateSource"];

				grpAb2588Category.SetGroup(drv["Ab2588Category"].ToString());
				grpAb2588SubCore.SetGroup(drv["Ab2588SubCategory1"].ToString());
				grpAb2588SubExempt.SetGroup(drv["Ab2588SubCategory1"].ToString());
				grpSignificantRiskSource.SetGroup(drv["Ab2588SubCategory2"].ToString());
				grpTrackingFacility.SetGroup(drv["Ab2588SubCategory2"].ToString());
				grpRiskOf10ToLess.SetGroup(drv["Ab2588SubCategory3"].ToString());
				SetAb2588GroupDisplay();

				grpAb2588FeeCategory.SetGroup(drv["Ab2588FeeCategory"].ToString());
				grpAb2588FeeCategory2.SetGroup(drv["Ab2588FeeCategory2"].ToString());
				grpAb2588FeeSubCategory.SetGroup(drv["Ab2588FeeSubCategory"].ToString());

				if (tbcStationarySource.SelectedTab == tabStationarySourceEmissions && StationarySourceNo != null)
				{
					GetStationarySourceEmissions(StationarySourceNo);
				}

				if ((bool)drv["IsPte25"])
				{
					scStationarySource2.Panel1.BackColor = System.Drawing.Color.DarkTurquoise;
					chkIsPTE25.BackColor = System.Drawing.Color.Pink;
				}
				else
				{
					scStationarySource2.Panel1.BackColor = System.Drawing.SystemColors.Control;
					chkIsPTE25.BackColor = System.Drawing.SystemColors.Control;
				}

				if (StationarySourceDataSetHasChanges && !InCurrentChangedDialog && (PdePermitUserRoles.IsAdmin || PdePermitUserRoles.IsEditor))
				{
					if (CurrentChangedCancelled)
					{
						CurrentChangedCancelled = false;
					}
					else
					{
						InCurrentChangedDialog = true;
						this.Parent.Enabled = false;
						DialogResult dialogResult = MessageBox.Show("The Stationary Source has changes. Do you want to save before continuing?" + Environment.NewLine + Environment.NewLine +
						  "Yes - Save and Continue." + Environment.NewLine + Environment.NewLine +
						  "No - Undo all changes since the last save and Continue.",
							//+ Environment.NewLine + Environment.NewLine +
							//"Cancel - Do not Continue.",
						  "Save Stationary Source?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

						if (dialogResult == DialogResult.Yes)
						{
							SaveStationarySource();
							StationarySourceDataSetHasChanges = false;
							this.Parent.Enabled = true;
						}
						else if (dialogResult == DialogResult.No)
						{
							StationarySourceRejectChanges();
							this.Parent.Enabled = true;
						}
						//else if (dialogResult == DialogResult.Cancel)
						//{
						//  bsStationarySource.SuspendBinding();
						//  CurrentChangedCancelled = true;
						//  this.Parent.Enabled = true;
						//  GoToStationarySourceAfterFilter(PreviousStationarySourceNo);
						//  bsStationarySource.ResumeBinding();
						//}
						InCurrentChangedDialog = false;
					}
				}
			}
			//bsRiskFacility.ResetBindings(false);
			CheckToxicsFilingFolder();
		}

		public void GoToSource(object stationarySourceNo)
		{
			if (stationarySourceNo != null)
			{
				if (bsStationarySource.Find("StationarySourceNo", stationarySourceNo) >= 0)
				{
					bsStationarySource.Position = bsStationarySource.Find("StationarySourceNo", stationarySourceNo);
				}
				else
				{
					MessageBox.Show("Stationary Source not found! The permit may exist but the filter settings may prevent finding it.", "Go To Stationary Source", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		public void GoToStationarySourceAfterFilter(object stationarySourceNo)
		{
			if (stationarySourceNo != null)
			{
				if (bsStationarySource.Find("StationarySourceNo", stationarySourceNo) >= 0)
				{
					bsStationarySource.Position = bsStationarySource.Find("StationarySourceNo", stationarySourceNo);
					//InCurrentChangedDialog = false;
				}
				else if (StationarySourceDataSetHasChanges)
				{
					//SaveStationarySource(false);
				}
			}
		}

		public delegate void GoToEntityEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs e);

		public event GoToEntityEventHandler OnGoToEntity;

		private void GoToFacility()
		{
			DataRowView drv = lbxFacilitiesList.SelectedItem as DataRowView;
			if (drv != null)
			{
				//object FacilityNo = drv["FacilityNo"];
				SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs("Facility", drv["FacilityNo"]);
				OnGoToEntity(this, args);
			}
		}

		private void lbxFacilitiesList_DoubleClick(object sender, EventArgs e)
		{
			GoToFacility();
		}

		private void lbxPermitList_DoubleClick(object sender, EventArgs e)
		{
			GoToPermit();
		}

		private void GoToPermit()
		{
			DataRowView drv = lbxPermitList.SelectedItem as DataRowView;
			if (drv != null)
			{
				SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs("Permit", drv["PermitNo"]);
				OnGoToEntity(this, args);
			}
		}

		#endregion

		#region Set

		public void CheckToxicsFilingFolder()
		{
			if (lnkToxicsFilingFolder.Tag == null || lnkToxicsFilingFolder.Tag.ToString() == string.Empty || !Directory.Exists(lnkToxicsFilingFolder.Tag.ToString()))
			{
				lnkToxicsFilingFolder.LinkVisited = false;
			}
			else
			{
				lnkToxicsFilingFolder.LinkVisited = true;
			}
		}

		private void SetAb2588CategoryText()
		{
			foreach (System.Windows.Forms.Control control in this.tabAB2588Categories.Controls)
			{
				if (control.GetType().ToString() == "SbcapcdOrg.ControlLibrary.usrGroupBox")
				{
					//group = (SbcapcdOrg.ControlLibrary.usrGroupBox)control;

					foreach (System.Windows.Forms.Control control2 in control.Controls)
					{
						if (control2.GetType().ToString() == "SbcapcdOrg.ControlLibrary.usrRadioButton")
						{
							radio = (SbcapcdOrg.ControlLibrary.usrRadioButton)control2;
							try
							{
								DataRow dr = dsStationarySourceAux.Ab2588Category.Rows.Find(radio.Tag);
								if (dr != null)
								{
									radio.Text = dr["AB2588CategoryDesc"].ToString();
									sss = sss + radio.Tag.ToString() + " ~ ";
								}
							}
							catch (Exception ex)
							{
								SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "SetAb2588CategoryText");
							}
							finally
							{
							}
						}
					}
				}
			}
		}

		private void SetAb2588GroupDisplay()
		{
			//bsStationarySource.EndEdit();
			grpAb2588SubCore.Visible = radCore.Checked;
			grpAb2588SubExempt.Visible = radExempt.Checked;
			grpSignificantRiskSource.Visible = radSignificantRiskSource.Checked;
			grpTrackingFacility.Visible = radTrackingFacility.Checked;
			grpIndustrywide.Visible = radIndustrywide.Checked;
			grpRiskOf10ToLess.Visible = radRiskOf10ToLess.Checked;
		}

		private void SetRowColor()
		{
			foreach (DataGridViewRow row in this.dgvStationarySource.Rows)
			{
				foreach (DataGridViewCell cell in row.Cells)
				{
					string CellName = cell.OwningColumn.Name;
					if (CellName.IndexOf("PermitStatus") > 0 && cell.ValueType == typeof(string) && cell.Value != null)
					{
						if ((string)cell.Value == "All")
						{
							row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
						}
					}
				}
			}
		}

		private void toggleVertHorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lbxPermitList.MultiColumn = !lbxPermitList.MultiColumn;
		}

		#region Ab2588RadClick

		private void radUndesignated_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void radCore_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void radExempt_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void radMediumOrUpdate_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void radIndustrywide_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void radSignificantRiskSource_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void radTrackingFacility_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void usrRiskOf10ToLess_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void usrRiskOf50ToLess_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void RiskOf100ToLess_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void radPrioritizationScore1_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void radHRACancerRisk1_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void radPrimaryActivity_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void rad50GtCancerRiskGtEq10_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
			bsStationarySource.EndEdit();
		}

		private void radHiGt1_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
			bsStationarySource.EndEdit();
		}

		private void radRiskOf10ToLess_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void radRiskOf50ToLess_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		private void radRiskOf100ToLess_Click(object sender, EventArgs e)
		{
			SetAb2588GroupDisplay();
		}

		#endregion

		public void SetHashtable(Hashtable applicationParametersHT)
		{
			ApplicationParametersHT = applicationParametersHT;
			//fbToxicSSFilePath.CurrentLocation = ApplicationParametersHT["ToxicSSCurrentLocation"].ToString();
			if (ApplicationParametersHT.Contains("SourceToxicsHelpFolder"))
			{
				lnkDocumentationFolder.LinkVisited = true;
			}
		}

		#endregion

		#region Modify

		public void SaveStationarySource(bool inCurrentChangedDialog)
		{
			InCurrentChangedDialog = inCurrentChangedDialog;
			SaveStationarySource();
			InCurrentChangedDialog = false;
		}

		public void StationarySourceRejectChanges(bool inCurrentChangedDialog)
		{
			InCurrentChangedDialog = inCurrentChangedDialog;
			StationarySourceRejectChanges();
			InCurrentChangedDialog = false;
		}

		public void StationarySourceRejectChanges()
		{
			PreviousStationarySourceNo = StationarySourceNo;
			StationarySourceLocation.LocationRejectChanges();
			dsStationarySource.RejectChanges();
			bsStationarySource.ResetBindings(false);
			bsStationarySourceHraHistory.ResetBindings(false);
			bsStationarySourceToxicsActionHistory.ResetBindings(false);
			bsStationarySourceWCompanyFilter.ResetBindings(false);
			bsStationarySourceWOCompanyFilter.ResetBindings(false);
			DataRowView drv = bsStationarySource.Current as DataRowView;
			if (drv != null)
			{
				grpEPASourceSize.SetGroup(drv["EpaStationarySourceSize"].ToString());
				grpSourceSize.SetGroup(drv["StationarySourceSize"].ToString());
				grpFillingLocation.SetGroup(drv["FillingLocation"].ToString());
				cmbQuadrennialUpdateCycle.Enabled = (bool)drv["IsQuadrennialUpdateSource"];

				grpAb2588Category.SetGroup(drv["Ab2588Category"].ToString());
				grpAb2588SubCore.SetGroup(drv["Ab2588SubCategory1"].ToString());
				grpAb2588SubExempt.SetGroup(drv["Ab2588SubCategory1"].ToString());
				grpSignificantRiskSource.SetGroup(drv["Ab2588SubCategory2"].ToString());
				grpTrackingFacility.SetGroup(drv["Ab2588SubCategory2"].ToString());
				grpRiskOf10ToLess.SetGroup(drv["Ab2588SubCategory3"].ToString());
				SetAb2588GroupDisplay();

				grpAb2588FeeCategory.SetGroup(drv["Ab2588FeeCategory"].ToString());
				grpAb2588FeeCategory2.SetGroup(drv["Ab2588FeeCategory2"].ToString());
				grpAb2588FeeSubCategory.SetGroup(drv["Ab2588FeeSubCategory"].ToString());
			}

			StationarySourceDataSetHasChanges = false;
			SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
			OnStationarySourceDataSetChanged(this, args);
			GoToStationarySourceAfterFilter(PreviousStationarySourceNo);
			InCurrentChangedDialog = false;
			SetRowColor();
		}

		public void SaveStationarySource()
		{
			if (PdePermitUserRoles.IsAdmin)
			{
				dgvStationarySourceHraHistory.EndEdit();
				bsStationarySourceHraHistory.EndEdit();
				dgvToxicsActionHistory.EndEdit();
				bsStationarySourceToxicsActionHistory.EndEdit();
				bsStationarySource.EndEdit();

				SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL saveStationarySource = new StationarySourceBL();
				DbTransaction transaction = saveStationarySource.GetTransaction(base.usrConnectionString);

				DataTable dtStationarySourceChanges = dsStationarySource.StationarySource.GetChanges();

				if (StationarySourceLocation.SaveLocation(PdePermitUserRoles.IsAdmin, transaction))
				{
					if (saveStationarySource.SaveStationarySource(base.usrConnectionString, dsStationarySource.GetChanges(), transaction))
					{
						dsStationarySource.AcceptChanges();
						StationarySourceLocation.LocationAcceptChanges();
						if (dtStationarySourceChanges != null)
						{
							SbcapcdOrg.PdePermit.PdePermitComponents.EntityHasNewItemEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityHasNewItemEventArgs(dtStationarySourceChanges);
							OnNewStationarySource(this, args);
						}
						HasNewSources = false;
						StationarySourceDataSetHasChanges = false;
						SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args2 = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
						OnStationarySourceDataSetChanged(this, args2);
					}
					else
					{
						MessageBox.Show("Error saving.");
					}
				}
				else
				{
					MessageBox.Show("Error saving.");
				}
			}
			else
			{
				MessageBox.Show("You do not have the rights to save.");
			}
		}

		public void SaveStationarySourceToxics()
		{
			if (PdePermitUserRoles.IsEditor && !PdePermitUserRoles.IsAdmin)
			{
				dgvStationarySourceHraHistory.EndEdit();
				bsStationarySourceHraHistory.EndEdit();
				dgvToxicsActionHistory.EndEdit();
				bsStationarySourceToxicsActionHistory.EndEdit();
				bsStationarySource.EndEdit();
				//dsStationarySource.StationarySource.RejectChanges();

				SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL saveStationarySourceToxics = new StationarySourceBL();
				DbTransaction transaction = saveStationarySourceToxics.GetTransaction(base.usrConnectionString);

				if (saveStationarySourceToxics.SaveStationarySourceToxics(base.usrConnectionString, dsStationarySource.GetChanges(), transaction))
				{
					dsStationarySource.AcceptChanges();
					HasNewSources = false;
					StationarySourceDataSetHasChanges = false;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args2 = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
					OnStationarySourceDataSetChanged(this, args2);
				}
				else
				{
					MessageBox.Show("Error saving.");
				}
			}
			else
			{
				MessageBox.Show("You should not, or do not have the rights to, save from here.");
			}
		}

		private void NewStationarySource()
		{
			InCurrentChangedDialog = true;
			bsStationarySource.SuspendBinding();
			InCurrentChangedDialog = true;
			bsStationarySource.RemoveFilter();
			string NewStationarySourceNo = SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL.GetNewStationarySourceNo(base.usrConnectionString);
			string LocationNo = StationarySourceLocation.NewLocation("Stationary Source", NewStationarySourceNo);

			DataRow dr = dsStationarySource.Tables["StationarySource"].NewRow();
			dr["StationarySourceNo"] = NewStationarySourceNo;
			dr["StationarySourceName"] = "New Stationary Source " + NewStationarySourceNo;
			dr["StationarySourceSize"] = "M";
			dr["EpaStationarySourceSize"] = "MI";
			dr["IsTitleV"] = false;
			dr["IsPte25"] = false;
			dr["FillingLocation"] = "NC";
			dr["LocationNo"] = LocationNo;
			dsStationarySource.Tables["StationarySource"].Rows.Add(dr);
			InCurrentChangedDialog = true;
			bsStationarySource.ResumeBinding();
			HasNewSources = true;
			StationarySourceDataSetHasChanges = true;
			SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
			OnStationarySourceDataSetChanged(this, args);
			InCurrentChangedDialog = true;
			ResetFilters();
			InCurrentChangedDialog = true;
			GoToStationarySourceAfterFilter(dr["StationarySourceNo"]);
			InCurrentChangedDialog = false;
		}

		public void PasteLocation(SbcapcdOrg.PdePermit.PdePermitComponents.CopyLocationEventArgs e)
		{
			GoToStationarySourceAfterFilter(e.StationarySourceNo);
			InCurrentChangedDialog = false;
			tbcStationarySource.SelectedTab = tabStationarySourceLocation;
			string NewLocationNo = StationarySourceLocation.PasteLocation(e);
			DataRowView drv = bsStationarySource.Current as DataRowView;
			if (drv != null)
			{
				drv["LocationNo"] = NewLocationNo;
			}
		}

		private void tsbtnDeleteStationarySource_Click(object sender, EventArgs e)
		{
			DataRowView drv = bsStationarySource.Current as DataRowView;
			object DeleteStationarySourceNo = null;
			if (drv != null)
			{
				DeleteStationarySourceNo = drv["StationarySourceNo"].ToString();
			}
			if (MessageBox.Show("Do you want to delete this Stationary Source " + DeleteStationarySourceNo.ToString() + " ?", "Delete Stationary Source?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (MessageBox.Show("Really? You want to delete Stationary Source " + DeleteStationarySourceNo.ToString() + " ?", "Delete Stationary Source? Really?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (MessageBox.Show("You must be serious! One more click and this Stationary Source is history!", "Delete Stationary Source??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						DataRow findRow = dsStationarySource.StationarySource.Rows.Find(DeleteStationarySourceNo);
						findRow.Delete();
						StationarySourceDataSetHasChanges = true;
						SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
						OnStationarySourceDataSetChanged(this, args);
					}
				}
			}
		}

		private void btnDeleteHealthRiskAssessmentHistory_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to Delete the current Health Risk Assessment History?", "Delete Health Risk Assessment History?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				bsStationarySourceHraHistory.RemoveCurrent();
				StationarySourceDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
				OnStationarySourceDataSetChanged(this, args);
			}
		}

		private void btnDeleteToxicsActionHistory_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to Delete the current Toxics Action History?", "Delete Health Risk Assessment History?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				bsStationarySourceToxicsActionHistory.RemoveCurrent();
				StationarySourceDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
				OnStationarySourceDataSetChanged(this, args);
			}
		}

		#endregion

		#region Copy

		private void tsmiCopySelectedToClipboard_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(this.dgvStationarySource.GetClipboardContent());
		}


		private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dgvStationarySource.SelectAll();
			Clipboard.SetDataObject(this.dgvStationarySource.GetClipboardContent());
			dgvStationarySource.ClearSelection();
		}

		#endregion

		public DataRow GetLocation(SbcapcdOrg.PdePermit.PdePermitComponents.CopyLocationEventArgs e)
		{
			try
			{
				DataRow dr = dsStationarySource.StationarySource.Rows.Find(e.StationarySourceNo);
				return StationarySourceLocation.GetLocationDataRowView(dr["LocationNo"]);
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "usrStationarySource:GetLocation");
				return null;
			}
		}

		private void GetStationarySourceEmissions(object stationarySourceNo)
		{
			try
			{
				this.Parent.Cursor = Cursors.WaitCursor;

				Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
				rvStationarySourceEmissions.ServerReport.ReportPath = "/Engineering/Permitting/PDE Stationary Source Emissions";
				rvStationarySourceEmissions.ServerReport.ReportServerUrl = new Uri("http://productionreports/ReportServer");
				rvStationarySourceEmissions.ServerReport.SetParameters(new ReportParameter("StationarySourceNo", stationarySourceNo.ToString()));
				rvStationarySourceEmissions.ShowParameterPrompts = false;
				rvStationarySourceEmissions.RefreshReport();

				////rvStationarySourceEmissions.Clear();
				//SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL getStationarySourceEmissions = new StationarySourceBL();
				//getStationarySourceEmissions.GetStationarySourceEmissions(base.usrConnectionString, StationarySourceNo, StationarySourceEmissionsDataSet);
				//StationarySourceEmissionsBindingSource.DataSource = StationarySourceEmissionsDataSet;
				//reportDataSource.Name = "StationarySourceEmissionsDataSet_StationarySourceEmissions";
				//reportDataSource.Value = this.StationarySourceEmissionsBindingSource;
				////rvStationarySourceEmissions1.ServerReport.GetDataSources(.DataSources.Add(reportDataSource);
				//rvStationarySourceEmissions1.RefreshReport();
				this.Parent.Cursor = Cursors.Default;




				//Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
				//rvStationarySourceEmissions1.LocalReport.DataSources.Clear();
				////rvStationarySourceEmissions.Clear();
				//SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL getStationarySourceEmissions = new StationarySourceBL();
				//getStationarySourceEmissions.GetStationarySourceEmissions(base.usrConnectionString, StationarySourceNo, StationarySourceEmissionsDataSet);
				//StationarySourceEmissionsBindingSource.DataSource = StationarySourceEmissionsDataSet;
				//reportDataSource.Name = "StationarySourceEmissionsDataSet_StationarySourceEmissions";
				//reportDataSource.Value = this.StationarySourceEmissionsBindingSource;
				//rvStationarySourceEmissions1.LocalReport.DataSources.Add(reportDataSource);
				//rvStationarySourceEmissions1.RefreshReport();
				//this.Parent.Cursor = Cursors.Default;

				//this.Parent.Cursor = Cursors.WaitCursor;
				//Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
				//reportViewer1.LocalReport.DataSources.Clear();
				////rvStationarySourceEmissions.Clear();
				//SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL getStationarySourceEmissions = new StationarySourceBL();
				//getStationarySourceEmissions.GetStationarySourceEmissions(base.usrConnectionString, StationarySourceNo, StationarySourceEmissionsDataSet);
				//StationarySourceEmissionsBindingSource.DataSource = StationarySourceEmissionsDataSet;
				//reportDataSource.Name = "StationarySourceEmissionsDataSet_StationarySourceEmissions";
				//reportDataSource.Value = this.StationarySourceEmissionsBindingSource;
				//reportViewer1.LocalReport.DataSources.Add(reportDataSource);
				//reportViewer1.RefreshReport();
				//this.Parent.Cursor = Cursors.Default;
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "usrStationarySource:GetLocation");

			}
		}

		private void lnkToxicsFilingFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Cursor = Cursors.AppStarting;
			if (lnkToxicsFilingFolder.Tag != null && lnkToxicsFilingFolder.Tag.ToString() != string.Empty && Directory.Exists(lnkToxicsFilingFolder.Tag.ToString()))
			{
				System.Diagnostics.Process.Start(lnkToxicsFilingFolder.Tag.ToString());
			}
			else
			{

			}
			this.Cursor = Cursors.Default;
		}

		private void btnToxicsFilingFolder_Click(object sender, EventArgs e)
		{
			if (fbdToxicsFilingFolder.ShowDialog() == DialogResult.OK)
			{
				if (lnkToxicsFilingFolder.Tag.ToString() != fbdToxicsFilingFolder.SelectedPath.ToString())
				{
					lnkToxicsFilingFolder.Tag = fbdToxicsFilingFolder.SelectedPath;
					StationarySourceDataSetHasChanges = true;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
					OnStationarySourceDataSetChanged(this, args);
					CheckToxicsFilingFolder();
				}
			}
		}

		private void dgvStationarySourceHraHistory_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
		{
			if (e.ColumnIndex == 4 && e.Value != null && e.Value.ToString().IndexOf(@"/") < 0)
			{
				e.Value = DateTime.Parse(e.Value.ToString().Insert(4, "/").Insert(2, "/"));
				e.ParsingApplied = true;
			}
		}

		private void dgvToxicsActionHistory_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
		{
			if (e.ColumnIndex == 0 && e.Value != null && e.Value.ToString().IndexOf(@"/") < 0)
			{
				e.Value = DateTime.Parse(e.Value.ToString().Insert(4, "/").Insert(2, "/"));
				e.ParsingApplied = true;
			}
		}

		private void StationarySourceLocation_OnNewLocationAddress()
		{
			HasNewLocationAddress = true;
		}

		private void cmbTwoDigitSic_SelectionChangeCommitted(object sender, EventArgs e)
		{
			//bsStationarySource.EndEdit();
			lblTwoDigSic.Text = cmbTwoDigitSic.SelectedValue.ToString();
		}

		private void dgvStationarySource_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				InCurrentChangedDialog = true;
			}
		}

		private void tsbtnSaveStationarySource_EnabledChanged(object sender, EventArgs e)
		{
			btnSaveToxics.Enabled = !tsbtnSaveStationarySource.Enabled;
			btnUndoToxicChanges.Enabled = !tsbtnSaveStationarySource.Enabled;
		}

		private void btnSaveToxics_Click(object sender, EventArgs e)
		{
			SaveStationarySourceToxics();
		}

		private void btnUndoToxicChanges_Click(object sender, EventArgs e)
		{
			StationarySourceRejectChanges();
		}

		private void dgvStationarySourceHraHistory_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells["dgvStationarySourceNo"].Value = StationarySourceNo.ToString();
			e.Row.Cells["StationarySourceHraId"].Value = SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL.GetNewStationarySourceHraHistoryId(base.usrConnectionString);

			//DataGridViewRow r = e.Row;

			//foreach (DataGridViewCell c in e.Row.Cells)
			//{
			//    if (c.Value != null)
			//    {
			//        string s = c.Value.ToString();
			//    }
			//    int j = 1;
			//}
		}

		private void tsmiPasteToxicsFolder_Click(object sender, EventArgs e)
		{
			if (Clipboard.ContainsText() && Directory.Exists(Clipboard.GetText()))
			{

				lnkToxicsFilingFolder.Tag = Clipboard.GetText();
				MessageBox.Show("Toxics Folder Added", "Toxics Folder Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
				StationarySourceDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
				OnStationarySourceDataSetChanged(this, args);
				CheckToxicsFilingFolder();
			}
			else
			{
				MessageBox.Show("Invalid Permit Folder", "Invalid path", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void tsmiClearToxicsFolder_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show("Are you sure you want to clear the Toxics Folder link?", "Delete Toxics Folder Path?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				lnkToxicsFilingFolder.Tag = null;
				MessageBox.Show("Toxics Folder Deleted", "Toxics Folder Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
				StationarySourceDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(StationarySourceDataSetHasChanges);
				OnStationarySourceDataSetChanged(this, args);
				CheckToxicsFilingFolder();
			}
		}

		private void dgvToxicsActionHistory_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells["dgvActionStationarySourceNo"].Value = StationarySourceNo.ToString();
			e.Row.Cells["StationarySourceToxicsActionHistoryId"].Value = SbcapcdOrg.PdePermit.StationarySource.StationarySourceBL.GetNewStationarySourceHraHistoryId(base.usrConnectionString);
		}

	}

  //public static class ConString
  //{
  //  private static string connectionString = "";

  //  public static string ConnectionString
  //  {
  //    get { return connectionString; }
  //    set { connectionString = value; }
  //  }
  //}
}
