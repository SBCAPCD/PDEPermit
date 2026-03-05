using System;
using System.Reflection;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SbcapcdOrg.ControlLibrary;
using SbcapcdOrg.PdePermit.Permit;
using System.Data.Common;
using System.Data.SqlClient;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

using SbcapcdOrg.PdePermit.PdePermitComponents;

using Microsoft.WindowsAPICodePack.Dialogs;

namespace SbcapcdOrg.PdePermit.Permit
{
	public partial class usrPermit : SbcapcdOrg.ControlLibrary.usrUserControl
	{
		#region Variables

		Regex rxNumber = new Regex("[0-9]");
		Regex rxLetter = new Regex("[a-zA-Z]");
		Regex rxInvalid = new Regex("[#%*[']");
		private string CompanyNo = null;
		private DataTable dtPermitList;
		private bool PermitDataSetHasChanges = false;
		private bool reevalDueDataSetHasChanges = false;
		private bool HasNewPermit = false;
		object PermitNo = "0";
		object PreSortPermitNo = null;
		private SbcapcdOrg.ControlLibrary.UserRoles PdePermitUserRoles = null;
		private SbcapcdOrg.PdePermit.PdePermitComponents.UserRoles PdeUserRoles = null;
		private string Entity = null;
		private object EntityNo = "00000";
		private bool IsSelectMode = false;
		private bool PermitLoadEnd = false;
		private bool InCurrentChangedDialog = false;
		//private string PermitFilter = "";
		private string PermitFilterText = "";
		private string CopyProjectsFromPermitNo = null;
		private int FilterTicks = 0;
		private int NewPermitActionHistoryId;
		private bool comboPermitDataSetHasChanges;
		private StringBuilder sbFilterReevalsDue = new StringBuilder();
		private bool? CompletenessAssigned;
		private string NewCompletenessEmployeeNo;
		private string NewIssuanceEmployeeNo;
		private string PermitEditStatus = "NonEditMode";
		private string EditModePermitNo;
		private Hashtable htSupersede = new Hashtable();
		private bool SettingEditMode = false;
		private Bitmap bmpOneByOne = new Bitmap(1, 1);
		private StringBuilder sbPermitFilter = new StringBuilder();
		private string NewFacilityNo = null;
		private bool SupersededPermitIsMappingPermit;

		private string SelectedPermitStatus { get; set; }
		private DataRowView drvPermit { get; set; }

		public bool ReevalDueDataSetHasChanges
		{
			get
			{
				return reevalDueDataSetHasChanges;
			}
			set
			{
				reevalDueDataSetHasChanges = value;
				SetSaveColor();
			}
		}


		#endregion

		private class TomatoRenderer : ToolStripProfessionalRenderer
		{
			protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
			{
				var btn = e.Item as ToolStripButton;
				if (btn != null && btn.CheckOnClick && btn.Checked && (btn.Name == "tsbtnSavePermit" || btn.Name == "tsbtnUndoPermit"))
				{
					Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
					e.Graphics.FillRectangle(Brushes.Tomato, bounds);
				}
				else if (btn != null && btn.CheckOnClick && !btn.Checked && (btn.Name == "tsbtnEditPermit"))
				{
					Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
					e.Graphics.FillRectangle(Brushes.Tomato, bounds);
				}
				else base.OnRenderButtonBackground(e);
			}
		}

		public usrPermit()
		{
			InitializeComponent();
			bsPermitActionHistory.Sort = "PermitActionDate DESC";
			bnPermitReevalDue.Visible = true;
			bnPermitReevalDue.Renderer = new MyRenderer();
			bnPermit.Renderer = new TomatoRenderer();

			DeleteFee.Image = imageList1.Images[21];
			DeleteProject.Image = imageList1.Images[21];
		}

		#region LoadPermit

		public void SetPermitUserRoles(SbcapcdOrg.ControlLibrary.UserRoles pdePermitUserRoles)
		{
			PdePermitUserRoles = pdePermitUserRoles;
			if (PdePermitUserRoles != null)
			{
				btnEmailCompletenessRoutingSlip.Enabled = PdePermitUserRoles.IsEditor;
				//btnAddAnRepPermit.Visible = PdePermitUserRoles.IsAdmin;
				tsbtnNewFromPermit.Enabled = PdePermitUserRoles.IsAdmin;
				btnNewPermitNumber.Enabled = PdePermitUserRoles.IsAdmin;
				btnEmailRoutingSlip.Enabled = PdePermitUserRoles.IsEditor;
				tsbtnNewPermit.Enabled = PdePermitUserRoles.IsAdmin;
				tsbtnSavePermit.Enabled = PdePermitUserRoles.IsEditor;
				btnEditPermit.Enabled = PdePermitUserRoles.IsEditor;
				btnDeletePermitAction.Enabled = PdePermitUserRoles.IsEditor;
				btnUpdatePermitStatus.Enabled = PdePermitUserRoles.IsEditor;
				btnDeleteSupersededPermit.Enabled = PdePermitUserRoles.IsEditor;
				dgvPermitActionHistory.AllowUserToDeleteRows = PdePermitUserRoles.IsEditor;
				dgvPermitFeeHistory.AllowUserToDeleteRows = PdePermitUserRoles.IsEditor;
				dgvPermitProject.AllowUserToDeleteRows = PdePermitUserRoles.IsEditor;
				dgvPermitSupersede.AllowUserToDeleteRows = PdePermitUserRoles.IsEditor;
				btnClearAllEmissions.Enabled = PdePermitUserRoles.IsEditor;

				if (!PdePermitUserRoles.IsAdmin)
				{
					tbcPermit.TabPages.Remove(tabReevalsDue);
				}
			}
		}

		public void SetPermitUserRoles(SbcapcdOrg.PdePermit.PdePermitComponents.UserRoles pdeUserRoles)
		{
			//PdeUserRoles = pdeUserRoles;

			//if (PdeUserRoles != null)
			//{
			//	btnEmailCompletenessRoutingSlip.Enabled = PdeUserRoles.IsEditor;
			//	btnAddAnRepPermit.Visible = PdeUserRoles.IsAdmin;
			//	tsbtnNewFromPermit.Enabled = PdeUserRoles.IsAdmin;
			//	btnNewPermitNumber.Enabled = PdeUserRoles.IsAdmin;
			//	btnEmailRoutingSlip.Enabled = PdeUserRoles.IsEditor;
			//	tsbtnNewPermit.Enabled = PdeUserRoles.IsAdmin;
			//	tsbtnSavePermit.Enabled = PdeUserRoles.IsEditor;
			//	btnEditPermit.Enabled = PdeUserRoles.IsEditor;
			//	btnDeletePermitAction.Enabled = PdeUserRoles.IsEditor;
			//	btnUpdatePermitStatus.Enabled = PdeUserRoles.IsEditor;
			//	btnDeleteSupersededPermit.Enabled = PdeUserRoles.IsEditor;
			//	dgvPermitActionHistory.AllowUserToDeleteRows = PdeUserRoles.IsEditor;
			//	dgvPermitFeeHistory.AllowUserToDeleteRows = PdeUserRoles.IsEditor;
			//	dgvPermitProject.AllowUserToDeleteRows = PdeUserRoles.IsEditor;
			//	dgvPermitSupersede.AllowUserToDeleteRows = PdeUserRoles.IsEditor;
			//	btnClearAllEmissions.Enabled = PdeUserRoles.IsEditor;

			//	if (!PdeUserRoles.IsAdmin)
			//	{
			//		tbcPermit.TabPages.Remove(tabReevalsDue);
			//	}
			//}
		}

		private void usrPermit_Load(object sender, EventArgs e)
		{

		}

		public void LoadPermit()
		{
			SbcapcdOrg.ControlLibrary.CutCopyPasteContextMenuMaker ccpMenuMakerPD = new CutCopyPasteContextMenuMaker(aytPermitDesc, true);
			aytPermitDesc.ContextMenuStripDefault = ccpMenuMakerPD.GetMenu();

			CutCopyPasteContextMenuMaker ccpMenuMakerAM = new CutCopyPasteContextMenuMaker(aytPermitNotes, true);
			aytPermitNotes.ContextMenuStripDefault = ccpMenuMakerAM.GetMenu();

			tbcPermit.Enabled = false;
			this.Enabled = false;
			this.Cursor = Cursors.AppStarting;
			bwLoadPermit.RunWorkerAsync();
		}

		private void LoadPermit(BackgroundWorker worker, DoWorkEventArgs e)
		{
			//PermitLocation.SetConnectionString(ConString.ConnectionString);
			//PermitLocation.LocationType = "Permit";
			//PermitLocation.GetLocations();

			SbcapcdOrg.PdePermit.Permit.PermitBL getPermitAux = new PermitBL();
			getPermitAux.GetPermitAux(base.usrConnectionString, dsPermitAux);

			SbcapcdOrg.PdePermit.Permit.PermitBL getPermit = new PermitBL();
			getPermit.GetPermit(base.usrConnectionString, dsPermit);
		}

		private void bwLoadPermit_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			LoadPermit(worker, e);
		}

		private void bwLoadPermit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
				try
				{
					tscmbPermitStatus.SelectedItem = "Active";
					tscmbDocType.ComboBox.DataSource = dsPermitAux.DocumentType;
					tscmbDocType.ComboBox.DisplayMember = "DocumentType";
					tscmbDocType.SelectedItem = "All";
					DataTable dtPermitTypeCopy = dsPermitAux.PermitType.Copy();
					DataRow dr = dtPermitTypeCopy.NewRow();
					dr["PermitTypeId"] = 999;
					dr["PermitType"] = " All Permit Types";
					dtPermitTypeCopy.Rows.Add(dr);
					tscmbPermitType.ComboBox.DataSource = dtPermitTypeCopy;
					tscmbPermitType.ComboBox.DisplayMember = "PermitType";
					tscmbPermitType.ComboBox.ValueMember = "PermitTypeId";

					dtPermitList = dsPermit.Permit.Copy();
					bsPermitList.DataSource = dtPermitList;
					bsPermitList.Sort = "Permit";
					bsPermitList.Filter = "PermitStatus = 'Active'";
					supersededPermitNoDataGridViewTextBoxColumn.DataSource = bsPermitList;
					supersededPermitNoDataGridViewTextBoxColumn.DisplayMember = "Permit";
					supersededPermitNoDataGridViewTextBoxColumn.ValueMember = "PermitNo";


					dsPermit.Permit.ColumnChanged += new DataColumnChangeEventHandler(Permit_ColumnChanged);
					dsPermit.PermitActionHistory.ColumnChanged += new DataColumnChangeEventHandler(PermitActionHistory_ColumnChanged);
					dsPermit.PermitFeeHistory.ColumnChanged += new DataColumnChangeEventHandler(PermitFeeHistory_ColumnChanged);
					dsPermit.PermitProject.ColumnChanged += new DataColumnChangeEventHandler(PermitProject_ColumnChanged);
					dsPermit.PermitSupersede.ColumnChanged += new DataColumnChangeEventHandler(PermitSupersede_ColumnChanged);
					dsPermit.PermitEmissions.ColumnChanged += new DataColumnChangeEventHandler(PermitEmissions_ColumnChanged);
					dsReevalDueAdmin.PermitReevalDue.ColumnChanged += new DataColumnChangeEventHandler(PermitReevalDue_ColumnChanged);

					bsPermitEngineer.Sort = "SortGroup, EngineerName";
					bsCompletenessEngineer.Sort = "SortGroup, EngineerName";
					bsPermitEngineerReevals.Sort = "SortGroup, LoginId";

					tscmbPermitType.SelectedIndex = 0;
					FilterPermit();
					bsPermit.Position = 0;
					tbcPermit.Enabled = true;
					this.Cursor = Cursors.Default;
					tscmbPermitType.Size = new System.Drawing.Size(250, 24);
					this.Enabled = true;
					PermitLoadEnd = true;
					ResetReevalDueDefaultFilters();
					bsPermitList.ResetItem(0);
					DataRowView drv = bsPermit.Current as DataRowView;
					if (drv != null && PermitLoadEnd)
					{
						PermitNo = drv["PermitNo"];
						SetIsConfidential((bool)drv["IsConfidential"]);
						usrLetters.drvPermit = drv;
					}

					//MessageBox.Show("Permit load ended");
				}
				catch (Exception ex)
				{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
				}
				finally
				{
					OnPermitLoadEnd();
				}
			}
		}

		public delegate void PermitLoadEndEventHandler();

		public event PermitLoadEndEventHandler OnPermitLoadEnd;

		#endregion

		#region CheckForChanges

		void PermitReevalDue_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			CheckForUnsavedChangesReevalDue(e);
		}

		void PermitEmissions_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			CheckForUnsavedChanges(e);
		}

		void PermitSupersede_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			//CheckForUnsavedChanges(e);
		}

		void PermitProject_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			CheckForUnsavedChanges(e);
		}

		void PermitFeeHistory_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			CheckForUnsavedChanges(e);
		}

		void PermitActionHistory_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			CheckForUnsavedChanges(e);
		}

		void Permit_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			if (CheckForUnsavedChanges(e) && PermitEditStatus != "EditMode" && PermitEditStatus != "New" && !InCurrentChangedDialog)
			{
				MessageBox.Show("Not in edit mode. Permit tab changes will not be saved.", "Not Checked Out", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		protected bool CheckForUnsavedChanges(DataColumnChangeEventArgs e)
		{
			//bool checkForChanges = false;
			//if (PdeUserRoles.IsEditor)
			//{
			//  checkForChanges = CommonMethods.CheckForChanges(PermitDataSetHasChanges, e);
			//  if (PermitDataSetHasChanges != checkForChanges)
			//  {
			//	PermitDataSetHasChanges = checkForChanges;
			//	SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
			//	OnPermitDataSetChanged(this, args);
			//  }
			//}

			bool checkForChanges = false;
			if (PdePermitUserRoles.IsEditor)
			{
				checkForChanges = CommonMethods.CheckForChanges(PermitDataSetHasChanges, e);
				if (PermitDataSetHasChanges != checkForChanges)
				{
					PermitDataSetHasChanges = checkForChanges;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
					OnPermitDataSetChanged(this, args);
				}
			}

			return checkForChanges;
		}

		protected void CheckForUnsavedChangesReevalDue(DataColumnChangeEventArgs e)
		{
			//  if (PdeUserRoles.IsEditor)
			//{
			//  bool checkForChanges = CommonMethods.CheckForChanges(ReevalDueDataSetHasChanges, e);
			//  if (ReevalDueDataSetHasChanges != checkForChanges)
			//  {
			//	ReevalDueDataSetHasChanges = checkForChanges;
			//	tslblReevalPermitAdded.Visible = ReevalDueDataSetHasChanges;
			//  }
			//}

			if (PdePermitUserRoles.IsEditor)
			{
				bool checkForChanges = CommonMethods.CheckForChanges(ReevalDueDataSetHasChanges, e);
				if (ReevalDueDataSetHasChanges != checkForChanges)
				{
					ReevalDueDataSetHasChanges = checkForChanges;
					tslblReevalPermitAdded.Visible = ReevalDueDataSetHasChanges;
				}
			}
		}

		public delegate void PermitDataSetChangedEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs e);

		public event PermitDataSetChangedEventHandler OnPermitDataSetChanged;

		protected bool CheckForChanges(DataColumnChangeEventArgs e)
		{
			string ChangingColumnName = e.Column.ToString();
			if (HasNewPermit || PermitLocation.LocationDataSetHasChanges || PermitDataSetHasChanges)
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
			else if (e.ProposedValue != null && e.Row[ChangingColumnName] == System.DBNull.Value)
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

		#endregion

		#region Filter

		private void BuildFilterPermits(string filter)
		{
			if (sbPermitFilter.Length == 0)
			{
				sbPermitFilter.Append(filter);
			}
			else
			{
				sbPermitFilter.Append(" AND " + filter);
			}
		}

		private void FilterPermit()
		{
			sbPermitFilter.Clear();

			InCurrentChangedDialog = true;
			PreSortPermitNo = PermitNo;
			DataRowView drv = tscmbDocType.SelectedItem as DataRowView;
			if (drv == null) { return; }
			string DocType = drv[0].ToString();
			string PermitStatus = tscmbPermitStatus.SelectedItem.ToString();

			PermitFilterText = rxInvalid.Replace(tstxtPermitFilter.Text, "");

			if (rxInvalid.IsMatch(tstxtPermitFilter.Text))
			{
				MessageBox.Show("Some characters in the search text are special and will not be used in the search.", "Special characteres #%*[']", MessageBoxButtons.OK);
			}

			if (CompanyNo != null)
			{
				BuildFilterPermits("CompanyNo = '" + CompanyNo + "'");
			}

			if (DocType != "All Doc Types")
			{
				BuildFilterPermits("DocumentType = '" + DocType + "'");
			}

			if (PermitStatus != "All")
			{
				BuildFilterPermits("PermitStatus = '" + PermitStatus + "'");
			}

			int PermitTypeId = 999;

			if (tscmbPermitType.SelectedItem != null)
			{
				PermitTypeId = (int)((DataRowView)tscmbPermitType.SelectedItem)["PermitTypeId"];
			}

			if (PermitTypeId != 999)
			{
				BuildFilterPermits("PermitTypeId = " + PermitTypeId);
			}

			if (PermitFilterText.Length > 0)
			{
				BuildFilterPermits("(PermitNumber LIKE '*" + PermitFilterText
					+ "*' OR PermitDesc LIKE '*" + PermitFilterText
					+ "*' OR PermitNotes LIKE '*" + PermitFilterText + "*')");
			}

			if (sbPermitFilter.Length > 0)
			{
				bsPermit.Filter = sbPermitFilter.ToString();
			}
			else
			{
				bsPermit.RemoveFilter();
			}

			GoToPermitAfterFilter(PreSortPermitNo);
			SetRowColor();

			CheckPermitPDF();
			CheckPermitFolder();
		}

		public void SetCompanyFilter(string companyNo)
		{
			CompanyNo = companyNo;
			FilterPermit();
		}

		public void FilterPermitSelectMode(string entity, object entityNo, string activeAll)
		{
			Entity = entity;
			EntityNo = entityNo;
			IsSelectMode = true;

			CompanyNo = null;
			tscmbDocType.SelectedIndex = 0;
			tstxtPermitFilter.Clear();
			tscmbPermitStatus.SelectedItem = activeAll;
			tscmbPermitType.SelectedIndex = 0;

			if (entityNo != null)
			{
				if (activeAll == "All")
				{
					bsPermit.Filter = entity + " = '" + entityNo.ToString() + "'";
				}
				else
				{
					bsPermit.Filter = "PermitStatus = '" + activeAll + "' AND " + entity + " = '" + entityNo.ToString() + "'";
				}
			}
			SetRowColor();
		}

		public void FilterPermitSelectMode(string activeAll)
		{
			//sbPermitFilter.Clear();


			CompanyNo = null;
			tscmbDocType.SelectedIndex = 0;
			tstxtPermitFilter.Clear();
			tscmbPermitStatus.SelectedItem = activeAll;
			tscmbPermitType.SelectedIndex = 0;

			//PermitFilterText = rxInvalid.Replace(tstxtPermitFilter.Text, "");

			//if (rxInvalid.IsMatch(tstxtPermitFilter.Text))
			//{
			//    MessageBox.Show("Some characters in the search text are special and will not be used in the search.", "Special characteres #%*[']", MessageBoxButtons.OK);
			//}

			//if (EntityNo != null)
			//{
			//    BuildFilterPermits(Entity + " = '" + EntityNo.ToString() + "'");
			//}

			//if (PermitFilterText.Length > 0)
			//{
			//    BuildFilterPermits("(PermitNumber LIKE '*" + PermitFilterText
			//        + "*' OR PermitDesc LIKE '*" + PermitFilterText
			//        + "*' OR PermitNotes LIKE '*" + PermitFilterText + "*')");
			//}

			//if (activeAll != "All")
			//{
			//    BuildFilterPermits("PermitStatus = '" + SelectedPermitStatus + "'");
			//}

			//if (sbPermitFilter.Length > 0)
			//{
			//    bsPermit.Filter = sbPermitFilter.ToString();
			//}

			//string sss = "PermitStatus = '" + activeAll + "' AND " + Entity + " = '" + EntityNo.ToString() + "'";

			if (EntityNo != null)
			{
				if (activeAll == "All")
				{
					bsPermit.Filter = Entity + " = '" + EntityNo.ToString() + "'";
				}
				else
				{
					bsPermit.Filter = "PermitStatus = '" + activeAll + "' AND " + Entity + " = '" + EntityNo.ToString() + "'";
				}
			}


			SetRowColor();
		}

		public void ResetPermitFilters()
		{
			if (PermitEditStatus != "New")
			{
				PreSortPermitNo = PermitNo;
			}
			bsPermit.SuspendBinding();
			Entity = null;
			EntityNo = "00000";
			IsSelectMode = false;
			CompanyNo = null;
			tscmbDocType.SelectedIndex = 0;
			tstxtPermitFilter.Clear();
			tscmbPermitStatus.SelectedItem = "Active";
			tscmbPermitType.SelectedIndex = 0;
			FilterPermit();
			bsPermit.ResumeBinding();
			SetRowColor();
			GoToPermit(PreSortPermitNo);
		}

		public void ResetPermitFiltersAll()
		{
			//InCurrentChangedDialog = true;
			if (PermitEditStatus != "New")
			{
				PreSortPermitNo = PermitNo;
			}
			bsPermit.SuspendBinding();
			Entity = null;
			EntityNo = "00000";
			IsSelectMode = false;
			CompanyNo = null;
			tscmbDocType.SelectedIndex = 0;
			tstxtPermitFilter.Clear();
			tscmbPermitStatus.SelectedItem = "All";
			tscmbPermitType.SelectedIndex = 0;
			FilterPermit();
			bsPermit.ResumeBinding();
			SetRowColor();
			GoToPermit(PreSortPermitNo);
			//InCurrentChangedDialog = false;
		}

		private void tstxtPermitFilter_TextChanged(object sender, EventArgs e)
		{
			if (!IsSelectMode)
			{
				PermitFilterTimer.Stop();
				FilterTicks = 0;
				PermitFilterTimer.Start();
			}
			else if (IsSelectMode && tstxtPermitFilter.Text != "")
			{
				PermitFilterTimer.Stop();
				FilterTicks = 0;
				PermitFilterTimer.Start();
			}
		}

		private void PermitFilterTimer_Tick(object sender, EventArgs e)
		{
			FilterTicks++;
			if (FilterTicks > 3)
			{
				PermitFilterTimer.Stop();
				FilterTicks = 0;
				this.Parent.Cursor = Cursors.WaitCursor;

				//if (!IsSelectMode)
				//{
				FilterPermit();
				//}
				//else if (IsSelectMode)
				//{
				//    FilterPermitSelectMode(SelectedPermitStatus);
				//}

				//FilterPermit();




				this.Parent.Cursor = Cursors.Default;
			}
		}

		#region Events

		private void tsBtnResetPermitFilters_Click(object sender, EventArgs e)
		{
			ResetPermitFilters();
		}

		private void tscmbDocType_SelectedIndexChanged(object sender, EventArgs e)
		{
			FilterPermit();
		}

		private void tscmbPermitStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedPermitStatus = tscmbPermitStatus.SelectedItem.ToString();

			if (IsSelectMode)
			{
				FilterPermitSelectMode(SelectedPermitStatus);
			}
			else
			{
				FilterPermit();
			}
		}

		private void tscmbPermitType_SelectedIndexChanged(object sender, EventArgs e)
		{
			FilterPermit();
		}

		#endregion

		#endregion

		#region Delegates

		public delegate void GoToEntityEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs e);

		public event GoToEntityEventHandler OnGoToEntity;

		public delegate void EntityCurrentChangedEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs e);

		public event EntityCurrentChangedEventHandler OnEntityCurrentChanged;

		public delegate void NewPermitEventHandler();

		//public event NewPermitEventHandler OnNewPermit;

		public delegate void CopyEmissionsGridEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.CopyEmissionsGridEventArgs e);

		public event CopyEmissionsGridEventHandler OnCopyEmissionsGrid;

		#endregion

		#region Modify

		private void tsbtnDeletePermit_Click(object sender, EventArgs e)
		{
			DeletePermit();
		}

		private void DeletePermit()
		{
			int CurrentCount = 0;

			if (PdePermitUserRoles.IsAdmin)
			//if (PdeUserRoles.IsAdmin)
			{
				DataRowView drv = bsPermit.Current as DataRowView;
				if (drv != null && MessageBox.Show("Delete Permit", "Delete Permit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (drv != null && MessageBox.Show("Are you sure you want to delete a Permit? This can not be undone!", "Delete Permit??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						if (SbcapcdOrg.PdePermit.Permit.PermitBL.DeletePermit(base.usrConnectionString, PermitNo.ToString()))
						{
							CurrentCount = bsPermit.Count;

							InCurrentChangedDialog = true;

							PermitNo = null;

							bsPermit.RemoveCurrent();
							bsPermit.EndEdit();
							dsPermit.AcceptChanges();
							bsPermit.ResetBindings(false);
						}

						PermitDataSetHasChanges = false;
						SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
						OnPermitDataSetChanged(this, args);

						PermitEditStatus = "NonEditMode";
						SetEditModeDisplay();

						InCurrentChangedDialog = false;
					}
				}
			}
			else
			{
				MessageBox.Show("Deleting a permit is an Admin function.");
			}
		}

		private void btnSavePermit_Click(object sender, EventArgs e)
		{
			this.ParentForm.Cursor = Cursors.WaitCursor;
			SavePermit(true);
			this.ParentForm.Cursor = Cursors.Default;
		}

		public bool SavePermit(bool inCurrentChangedDialog)
		{
			InCurrentChangedDialog = inCurrentChangedDialog;
			bool rtn = SavePermit();
			InCurrentChangedDialog = false;
			return rtn;
		}

		public void PermitRejectChanges(bool inCurrentChangedDialog)
		{
			InCurrentChangedDialog = inCurrentChangedDialog;
			PermitRejectChanges();
			InCurrentChangedDialog = false;
		}

		public bool SavePermit()
		{
			try
			{
				dgvPermitActionHistory.EndEdit();
				bsPermitActionHistory.EndEdit();

				if (CheckPermitStatusChange() && PermitEditStatus == "NonEditMode")
				{
					MessageBox.Show("The current permit status will change. Edit mode will be used to save the permit", "Edit mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
					SettingEditMode = true;
					InCurrentChangedDialog = true;
					ResetPermitFiltersAll();
					SetEditMode();

					SettingEditMode = false;
				}

				SbcapcdOrg.PdePermit.Permit.PermitBL savePermit = new PermitBL();
				DbTransaction transaction = savePermit.GetTransaction(base.usrConnectionString);
				bool RetrievePermitSupersede = false;

				dgvPermitActionHistory.EndEdit();
				bsPermitActionHistory.EndEdit();
				dgvPermitEmissions.EndEdit();
				bsPermitEmissions.EndEdit();
				dgvPermitFeeHistory.EndEdit();
				bsPermitFeeHistory.EndEdit();
				dgvPermitProject.EndEdit();
				bsPermitProject.EndEdit();
				dgvPermitSupersede.EndEdit();
				bsPermitSupersede.EndEdit();
				dgvPermitException.EndEdit();
				bsPermitException.EndEdit();
				bsPermit.EndEdit();
				SetPermitStatus();

				if (dsPermit.GetChanges() != null)
				{
					if (dsPermit.GetChanges().Tables.Contains("PermitSupersede"))
					{
						if (dsPermit.GetChanges().Tables["PermitSupersede"].Rows.Count > 0)
						{
							RetrievePermitSupersede = true;
						}
					}
				}

				if (PermitLocation.SaveLocation(PdePermitUserRoles.IsEditor, transaction))
				//if (PermitLocation.SaveLocation(PdeUserRoles.IsEditor, transaction))
				{
					if (PermitEditStatus != "EditMode" && PermitEditStatus != "New")
					{
						dsPermit.Permit.RejectChanges();
					}

					if (htSupersede.Count > 0)
					{
						SupersededPermitIsMappingPermit = false;

						foreach (DictionaryEntry de in htSupersede)
						{
							if (!savePermit.UpdatePermitStatus(base.usrConnectionString, de.Key.ToString(), de.Value.ToString(), transaction))
							{
								MessageBox.Show("Error saving.");
								transaction.Rollback();
								return false;
							}
							else
							{
								//var IsMappingPermit = from DataRow drpermit in dsPermit.Permit
								//                      where drpermit["PermitNo"] == de.Key.ToString() && (bool)drpermit["IsMappingPermit"] == true
								//                      select drpermit;

								//if (IsMappingPermit.Count() > 0)
								//{
								//  SupersededPermitIsMappingPermit = true;
								//}
							}
						}
					}

					//if (SupersededPermitIsMappingPermit)
					//{
					//    DataRowView drv = (DataRowView)bsPermit.Current;
					//    drv["IsMappingPermit"] = SupersededPermitIsMappingPermit;
					//    drv.EndEdit();
					//}

					if (savePermit.SavePermit(base.usrConnectionString, PermitEditStatus, dsPermit.GetChanges(), transaction))
					{
						PermitLocation.LocationAcceptChanges();

						//foreach (DictionaryEntry de in htSupersede)
						//{
						//  RefreshPermit(de.Key.ToString());
						//}
						//htSupersede.Clear();

						dsPermit.AcceptChanges();
						HasNewPermit = false;
						PermitDataSetHasChanges = false;
						SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
						OnPermitDataSetChanged(this, args);
						PermitEditStatus = "NonEditMode";
						SetEditModeDisplay();

						RunBwSavePermitPdfDocuments();
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

				//if (RetrievePermitSupersede)
				//{
				//  SbcapcdOrg.PdePermit.Permit.PermitBL getPermitSupersedeAux = new PermitBL();
				//  getPermitSupersedeAux.GetPdePermitSupersedeAux(base.usrConnectionString, dsPermitAux);
				//}
				bsPermit.ResetBindings(false);
				bsPermitActionHistory.ResetBindings(false);
				SetRowColor();
				return true;
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
				return false;
			}
		}

		private void tsbNewPermit_Click(object sender, EventArgs e)
		{
			PreSortPermitNo = PermitNo;
			PermitEditStatus = "New";
			InCurrentChangedDialog = true;
			ResetPermitFilters();
			string NewPermitNo = SbcapcdOrg.PdePermit.Permit.PermitBL.GetNewPermitNo(base.usrConnectionString);
			EditModePermitNo = NewPermitNo;

			DataRow dr = dsPermit.Tables["Permit"].NewRow();
			dr["PermitNo"] = PermitNo = NewPermitNo;
			dr["PermitNumber"] = "New";
			dr["PermitStatus"] = "Active";
			dr["PermitNotes"] = " ";
			dr["PermitDesc"] = " ";
			dsPermit.Tables["Permit"].Rows.Add(dr);

			DataRow dr2 = dsPermit.Tables["PermitEmissions"].NewRow();
			dr2["PermitNo"] = NewPermitNo;
			dr2["EmissionsUnits"] = "lb/day";
			dr2["EmissionsType"] = "PPTE";
			dsPermit.Tables["PermitEmissions"].Rows.Add(dr2);

			DataRow dr3 = dsPermit.Tables["PermitEmissions"].NewRow();
			dr3["PermitNo"] = NewPermitNo;
			dr3["EmissionsUnits"] = "lb/hr";
			dr3["EmissionsType"] = "PPTE";
			dsPermit.Tables["PermitEmissions"].Rows.Add(dr3);

			DataRow dr5 = dsPermit.Tables["PermitEmissions"].NewRow();
			dr5["PermitNo"] = NewPermitNo;
			dr5["EmissionsUnits"] = "TPQ";
			dr5["EmissionsType"] = "PPTE";
			dsPermit.Tables["PermitEmissions"].Rows.Add(dr5);

			DataRow dr4 = dsPermit.Tables["PermitEmissions"].NewRow();
			dr4["PermitNo"] = NewPermitNo;
			dr4["EmissionsUnits"] = "TPY";
			dr4["EmissionsType"] = "PPTE";
			dsPermit.Tables["PermitEmissions"].Rows.Add(dr4);

			HasNewPermit = true;
			PermitDataSetHasChanges = true;
			SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
			OnPermitDataSetChanged(this, args);
			InCurrentChangedDialog = true;
			bsPermit.Filter = "PermitStatus = 'Active'";
			InCurrentChangedDialog = true;
			GoToPermit(dr["PermitNo"]);
			SetEditModeDisplay();
			InCurrentChangedDialog = false;
		}

		private void tsbtnSavePermitReevalDue_Click(object sender, EventArgs e)
		{
			SavePermitReevalDue();
		}

		private void SavePermitReevalDue()
		{
			dgvReevalDueAdmin.EndEdit();
			bsPermitReevalDue.EndEdit();
			SbcapcdOrg.PdePermit.Permit.PermitBL savePermitReevalDue = new PermitBL();
			if (savePermitReevalDue.SavePermitReevalDue(base.usrConnectionString, dsReevalDueAdmin.GetChanges()))
			{
				dsReevalDueAdmin.AcceptChanges();
				ReevalDueDataSetHasChanges = false;
				tslblReevalPermitAdded.Visible = ReevalDueDataSetHasChanges;
			}
			SetRowColorPermitReevalDue();
		}

		private void tsbtnSavePermitAndReevalDue_Click(object sender, EventArgs e)
		{
			if (PermitDataSetHasChanges)
			{
				SavePermitReevalDue();
				SavePermit();
				DataRowView drv = (DataRowView)bsPermit.Current;
				if (SbcapcdOrg.PdePermit.Permit.PermitBL.EmailRoutingSlip(base.usrConnectionString, drv["PermitNo"].ToString()))
				{
					MessageBox.Show("Routing Slip Sent");
				}
			}
			else
			{
				MessageBox.Show("Permit data does not have changes. To save only Reeval Due changes use the other save button.", "Data not saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void tsbtnUndoReevalDueChanges_Click(object sender, EventArgs e)
		{
			dsReevalDueAdmin.RejectChanges();
			SetRowColorPermitReevalDue();
			ReevalDueDataSetHasChanges = false;
			tslblReevalPermitAdded.Visible = ReevalDueDataSetHasChanges;
		}

		private void tsbNewFromPermit_Click(object sender, EventArgs e)
		{
			NewFromPermit();
		}

		private void NewFromPermit()
		{
			PreSortPermitNo = PermitNo;
			PermitEditStatus = "New";
			InCurrentChangedDialog = true;
			DataRowView drv = (DataRowView)bsPermit.Current;
			bsPermit.SuspendBinding();
			bsPermit.RemoveFilter();
			tscmbPermitStatus.SelectedItem = "All";

			DataRow dr = dsPermit.Tables["Permit"].NewRow();
			string NewPermitNo = SbcapcdOrg.PdePermit.Permit.PermitBL.GetNewPermitNo(base.usrConnectionString);
			EditModePermitNo = NewPermitNo;
			dr["PermitNo"] = NewPermitNo;

			dr["DocumentType"] = drv["DocumentType"];
			dr["PermitNumber"] = drv["PermitNumber"];
			dr["PermitSuffix"] = drv["PermitSuffix"];
			dr["FacilityNo"] = drv["FacilityNo"];
			dr["PermitDesc"] = drv["PermitDesc"].ToString();
			dr["IsReimbursable"] = drv["IsReimbursable"];
			dr["EmployeeIdNo"] = drv["EmployeeIdNo"];
			dr["IsPermitPriority"] = drv["IsPermitPriority"];
			dr["RequiresAnnualReport"] = drv["RequiresAnnualReport"];
			dr["PermitStatus"] = "Active";
			dr["PermitTypeId"] = drv["PermitTypeId"];
			dr["LocationNo"] = drv["LocationNo"];
			dr["LeadAgencyNo"] = drv["LeadAgencyNo"];
			dr["CompanyNo"] = drv["CompanyNo"];
			dr["StationarySourceNo"] = drv["StationarySourceNo"];
			dr["Permit"] = drv["Permit"];
			dr["IsMappingPermit"] = drv["IsMappingPermit"];
			dr["ReportingType"] = drv["ReportingType"];

			dsPermit.Tables["Permit"].Rows.Add(dr);

			DataRow drPermitActionHistory = dsPermit.Tables["PermitActionHistory"].NewRow();
			drPermitActionHistory["PermitActionHistoryId"] = SbcapcdOrg.PdePermit.Permit.PermitBL.GetPdeNewId(base.usrConnectionString);
			drPermitActionHistory["PermitNo"] = NewPermitNo;
			if (drv["DocumentType"].ToString() == "Reeval")
			{
				drPermitActionHistory["PermitActionId"] = 10;
			}
			else
			{
				drPermitActionHistory["PermitActionId"] = 1;
			}
			drPermitActionHistory["PermitActionDate"] = System.DateTime.Today;
			drPermitActionHistory["EmployeeIdNo"] = PdePermitUserRoles.EmployeeID;
			drPermitActionHistory["LoginID"] = PdePermitUserRoles.LoginID;

			//drPermitActionHistory["EmployeeIdNo"] = PdeUserRoles.EmployeeID;
			//drPermitActionHistory["LoginID"] = PdeUserRoles.LoginID;
			dsPermit.Tables["PermitActionHistory"].Rows.Add(drPermitActionHistory);

			string SelectFilter = "PermitNo = '" + drv["PermitNo"].ToString() + "'";
			DataRow drPermitEmissions;
			foreach (DataRow dr2 in dsPermit.PermitEmissions.Select(SelectFilter))
			{
				drPermitEmissions = dsPermit.Tables["PermitEmissions"].NewRow();
				drPermitEmissions["PermitNo"] = NewPermitNo;
				drPermitEmissions["EmissionsUnits"] = dr2["EmissionsUnits"];
				drPermitEmissions["EmissionsType"] = dr2["EmissionsType"];
				drPermitEmissions["NOx"] = dr2["NOx"];
				drPermitEmissions["ROC"] = dr2["ROC"];
				drPermitEmissions["CO"] = dr2["CO"];
				drPermitEmissions["SOx"] = dr2["SOx"];
				drPermitEmissions["PM"] = dr2["PM"];
				drPermitEmissions["PM10"] = dr2["PM10"];
				dsPermit.Tables["PermitEmissions"].Rows.Add(drPermitEmissions);
			}

			DataRow drPermitProject;
			foreach (DataRow dr2 in dsPermit.PermitProject.Select(SelectFilter))
			{
				drPermitProject = dsPermit.Tables["PermitProject"].NewRow();
				drPermitProject["PermitProjectId"] = SbcapcdOrg.PdePermit.Permit.PermitBL.GetPdeNewId(base.usrConnectionString);
				drPermitProject["PermitNo"] = NewPermitNo;
				drPermitProject["ProjectNo"] = dr2["ProjectNo"];
				drPermitProject["IsInvoiceProject"] = dr2["IsInvoiceProject"];
				dsPermit.Tables["PermitProject"].Rows.Add(drPermitProject);
			}
			InCurrentChangedDialog = true;
			bsPermit.ResumeBinding();
			//ResetPermitFilters();
			InCurrentChangedDialog = true;
			GoToPermit(dr["PermitNo"]);
			SetEditModeDisplay();
			InCurrentChangedDialog = false;
		}

		private void tsbtnUndoPermit_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = dialogResult = MessageBox.Show("This will undo all changes since the last save! Do you want to continue?"
				//  + Environment.NewLine + Environment.NewLine +
				//"OK" + Environment.NewLine + Environment.NewLine +
				//"Cancel"
			, "Undo Permit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			if (dialogResult == DialogResult.OK)
			{
				InCurrentChangedDialog = true;
				PermitRejectChanges();
				this.Parent.Enabled = true;
			}
			else if (dialogResult == DialogResult.Cancel)
			{
				this.Parent.Enabled = true;
			}
			InCurrentChangedDialog = false;
		}

		private void btnAddPermitLocation_Click(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)bsPermit.Current;
			drv["LocationNo"] = PermitLocation.NewLocation("Permit", drv["Permit"].ToString());
			PermitLocation.Visible = PermitLocation.GoToLocation(drv["LocationNo"].ToString());
			if (PermitLocation.Visible && drv["FacilityNo"].ToString() == "00201")
			{
				PermitLocation.SetVafbVisibility(true);
			}
			else
			{
				PermitLocation.SetVafbVisibility(false);
			}
		}

		public void PermitRejectChanges()
		{
			if (PermitEditStatus != "New")
			{
				PreSortPermitNo = PermitNo;
			}
			bool HadNewPermit = HasNewPermit;
			PermitLocation.LocationRejectChanges();
			dsPermit.RejectChanges();
			bsPermit.ResetBindings(false);
			bsPermitActionHistory.ResetBindings(false);
			bsPermitEmissions.ResetBindings(false);
			bsPermitException.ResetBindings(false);
			bsPermitFeeHistory.ResetBindings(false);
			bsPermitProject.ResetBindings(false);
			bsPermitSupersede.ResetBindings(false);
			bsSupersedingPermits.ResetBindings(false);

			PermitDataSetHasChanges = false;
			HasNewPermit = false;

			if (!SbcapcdOrg.PdePermit.Permit.PermitBL.SetIsPermitCheckedOutForEditFalse(base.usrConnectionString, EditModePermitNo))
			{
				MessageBox.Show("Edit Mode Error", "Edit Mode Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				PermitEditStatus = "NonEditMode";
				SetEditModeDisplay();
			}

			SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
			OnPermitDataSetChanged(this, args);
			if (!HadNewPermit && PreSortPermitNo.ToString().Length > 4)
			{
				GoToPermit(PreSortPermitNo);
			}
			SetRowColor();
		}

		private void dgvPermitActionHistory_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells["PermitActionHistoryId"].Value = NewPermitActionHistoryId = SbcapcdOrg.PdePermit.Permit.PermitBL.GetPdeNewId(base.usrConnectionString);
			e.Row.Cells["permitNoDataGridViewTextBoxColumn"].Value = PermitNo;
			e.Row.Cells["EmployeeIdNo"].Value = PdePermitUserRoles.EmployeeID;
			e.Row.Cells["LoginID"].Value = PdePermitUserRoles.LoginID;


			//e.Row.Cells["EmployeeIdNo"].Value = PdeUserRoles.EmployeeID;
			//e.Row.Cells["LoginID"].Value = PdeUserRoles.LoginID;

			e.Row.Cells["Date"].Value = System.DateTime.Today.ToShortDateString();
		}

		private void btnNewPermitNumber_Click(object sender, EventArgs e)
		{
			txtPermitNumber.Text = SbcapcdOrg.PdePermit.Permit.PermitBL.GetNewPermitNumber(base.usrConnectionString);
		}

		private void dgvPermitFeeHistory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			if (!(MessageBox.Show("Do you want to Delete this fee action?", "Delete this fee action?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				e.Cancel = true;
			}
		}

		private void dgvPermitProject_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			if (!(MessageBox.Show("Do you want to Delete this Project?", "Delete this Project?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				e.Cancel = true;
			}
		}

		private void dgvPermitException_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			if (!(MessageBox.Show("Do you want to delete this Exception?", "Delete this Exception?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				e.Cancel = true;
			}
		}

		private void btnDeletePermitAction_Click(object sender, EventArgs e)
		{
			if ((MessageBox.Show("Do you want to Delete the current action?", "Delete this action?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				DataRowView drvDeletePermitAction = (DataRowView)bsPermitActionHistory.Current;
				if (drvDeletePermitAction != null)
				{
					bsPermitActionHistory.RemoveCurrent();
					//DataRow findRow = dsPermit.PermitActionHistory.Rows.Find(new object[3] { drvDeletePermitAction["PermitNo"], drvDeletePermitAction["PermitActionId"], drvDeletePermitAction["PermitActionDate"] });
					//findRow.Delete();
					PermitDataSetHasChanges = true;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
					OnPermitDataSetChanged(this, args);
				}
			}
		}

		private void btnDeletePermitFee_Click(object sender, EventArgs e)
		{
			if ((MessageBox.Show("Do you want to Delete the current fee action?", "Delete this fee action?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				DataRowView drvPermitFeeHistory = (DataRowView)bsPermitFeeHistory.Current;
				if (drvPermitFeeHistory != null)
				{
					//if ((bool)drvPermitFeeHistory["InvoiceSent"])
					//{
					//    MessageBox.Show("The Invoice has been sent to Billing. It can not be deleted.", "Invoice Sent", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					//}
					//else
					//{
					bsPermitFeeHistory.RemoveCurrent();
					//DataRow findRow = dsPermit.PermitActionHistory.Rows.Find(new object[2] { drvPermitFeeHistory["PermitNo"], drvPermitFeeHistory["PermitFeeActionId"] });
					//findRow.Delete();
					PermitDataSetHasChanges = true;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
					OnPermitDataSetChanged(this, args);
					//}
				}
			}
		}

		private void btnDeleteProject_Click(object sender, EventArgs e)
		{
			if ((MessageBox.Show("Do you want to Delete the current Project?", "Delete this Project?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				bsPermitProject.RemoveCurrent();
				PermitDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
				OnPermitDataSetChanged(this, args);
			}
		}

		private void dgvPermitActionHistory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			if (!(MessageBox.Show("Do you want to Delete this action?", "Delete this action?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				e.Cancel = true;
			}
		}

		private void btnClearAllEmissions_Click(object sender, EventArgs e)
		{

			foreach (DataRow dr in dsPermit.PermitEmissions.Select("PermitNo = '" + PermitNo.ToString() + "'"))
			{
				for (int i = 3; i < 10; i++)
				{
					if (dr[i].ToString() != String.Empty)
					{
						dr[i] = DBNull.Value;
					}
				}
			}
		}

		private void btnUpdatePermitStatus_Click(object sender, EventArgs e)
		{

			if (CheckPermitStatusChange() && PermitEditStatus == "NonEditMode")
			{
				if (DialogResult.Yes == MessageBox.Show("The current permit status will change. You must be in edit mode to save the permit. Do you want to go into edit mode?", "Edit mode?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
				{
					ResetPermitFiltersAll();
					SetEditMode();
				}
			}
		}

		#endregion

		#region Navigation

		private void bsPermit_CurrentChanged(object sender, EventArgs e)
		{
			try
			{
				DataRowView drv = drvPermit = bsPermit.Current as DataRowView;

				if (drv != null && PermitLoadEnd)
				{
					PermitNo = drv["PermitNo"];
					usrLetters.drvPermit = drv;
					bsPermitList.Filter = "StationarySourceNo = '" + drv["StationarySourceNo"].ToString() + "' OR PermitNumber ='" + drv["PermitNumber"].ToString() + "'";
					bsSupersedingPermits.Filter = "SupersededPermitNo = '" + drv["PermitNo"].ToString() + "'";
					dgvSupersedingPermits.ClearSelection();
					dgvSupersedingPermits.ClearSelection();

					grpReportingType.SetGroup(drv["ReportingType"].ToString());

					SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs argsEntityCurrentChanged = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs("Permit", drv["PermitNo"], drv["FacilityNo"], drv["StationarySourceNo"]);
					if (OnEntityCurrentChanged != null)
					{
						OnEntityCurrentChanged(this, argsEntityCurrentChanged);
					}

					SetIsConfidential((bool)drv["IsConfidential"]);

					chkSchoolNoticeRequired.ForeColor = System.Drawing.Color.MediumBlue;
					if (drv["HighlightSchoolNoticeRequired"] != DBNull.Value && (bool)drv["HighlightSchoolNoticeRequired"])
					{
						chkSchoolNoticeRequired.ForeColor = System.Drawing.Color.Red;
					}

					PermitLocation.Visible = PermitLocation.GoToLocation(drv["LocationNo"].ToString());
					if (drv["FacilityNo"].ToString() == "00201")
					{
						PermitLocation.SetVafbVisibility(true);
						//cmbVafbContactFacility.Enabled = true;
					}
					else
					{
						PermitLocation.SetVafbVisibility(false);
						//cmbVafbContactFacility.Enabled = false;
					}

					if (PermitDataSetHasChanges && !InCurrentChangedDialog && PdePermitUserRoles.IsEditor)
					//if (PermitDataSetHasChanges && !InCurrentChangedDialog && PdeUserRoles.IsEditor)
					{
						InCurrentChangedDialog = true;

						DialogResult dialogResult = dialogResult = MessageBox.Show("The Permit has changes. Do you want to save before continuing?" + Environment.NewLine + Environment.NewLine +
						"Yes - Save and Continue." + Environment.NewLine + Environment.NewLine +
						"No - Undo all changes since the last save and Continue",
						"Save Permit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

						if (dialogResult == DialogResult.Yes)
						{
							SavePermit();
							this.Parent.Enabled = true;
						}
						else if (dialogResult == DialogResult.No)
						{
							PermitRejectChanges();
							this.Parent.Enabled = true;
						}
						InCurrentChangedDialog = false;
					}

					if (drv["IsPte25"] != DBNull.Value && drv["IsPte25"] != null && (bool)drv["IsPte25"])
					{
						scPermit2.Panel1.BackColor = System.Drawing.Color.DarkTurquoise;
					}
					else
					{
						scPermit2.Panel1.BackColor = System.Drawing.SystemColors.Control;
					}
				}

				CheckPermitPDF();
				CheckPermitFolder();
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "bsPermit_CurrentChanged");
			}
		}

		public void GoToPermit(object permitNo)
		{
			this.Cursor = Cursors.WaitCursor;
			Application.DoEvents();

			if (permitNo != null && PermitLoadEnd)
			{
				if (bsPermit.Find("PermitNo", permitNo) >= 0)
				{
					bsPermit.Position = bsPermit.Find("PermitNo", permitNo);
				}
				else
				{
					ResetPermitFiltersAll();
					bsPermit.Position = bsPermit.Find("PermitNo", permitNo);

					//MessageBox.Show("Permit not found! The permit may exist but the filter settings may prevent finding it.", "Go To Permit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			this.Cursor = Cursors.Default;
		}

		public void GoToPermitAfterFilter(object permitNo)
		{
			if (permitNo != null && PermitLoadEnd)
			{
				if (bsPermit.Find("PermitNo", permitNo) >= 0 && bsPermit.Find("PermitNo", permitNo) < (bsPermit.Count + 1))
				{
					//InCurrentChangedDialog = true;
					bsPermit.Position = bsPermit.Find("PermitNo", permitNo);
					if (!SettingEditMode)
					{
						//InCurrentChangedDialog = false;
					}
				}
				else if (PermitDataSetHasChanges)
				{
					SavePermit(false);
				}
				else
				{
					bsPermit.Position = 0;
					if (!SettingEditMode)
					{
						InCurrentChangedDialog = false;
					}
				}
			}
		}

		private void dgvPermit_MouseDown(object sender, MouseEventArgs e)
		{
			DataRowView drv = bsPermit.Current as DataRowView;
			if (drv != null)
			{
				PreSortPermitNo = drv["PermitNo"];
			}
		}

		private void dgvPermit_Sorted(object sender, EventArgs e)
		{
			GoToPermitAfterFilter(PreSortPermitNo);
			SetRowColor();
		}

		private void bsPermitException_CurrentChanged(object sender, EventArgs e)
		{
			//DataRowView drv = bsPermitException.Current as DataRowView;
			//if (drv != null)
			//{
			//  btnPermitException.ImageIndex = 2;
			//}
			//else
			//{
			//  btnPermitException.ImageIndex = 1;
			//}
		}

		#endregion

		#region Display

		public void FacilityListChanged(SbcapcdOrg.PdePermit.PdePermitComponents.EntityHasNewItemEventArgs e)
		{
			foreach (DataRow dr in e.EntityDataTable.Select("", "", DataViewRowState.CurrentRows))
			{
				DataRow foundRow = dsPermitAux.FacilityList.Rows.Find(dr["FacilityNo"]);
				if (foundRow == null)
				{
					DataRow newRow = dsPermitAux.FacilityList.NewRow();
					newRow["FacilityNo"] = dr["FacilityNo"];
					newRow["FacilityName"] = dr["FacilityName"].ToString() + " - " + dr["FacilityNo"].ToString();
					newRow["StationarySourceNo"] = dr["StationarySourceNo"];
					newRow["PermitStatus"] = dr["PermitStatus"];
					dsPermitAux.FacilityList.Rows.Add(newRow);
				}
				else
				{
					foundRow["FacilityName"] = dr["FacilityName"];
					foundRow["StationarySourceNo"] = dr["StationarySourceNo"];
					foundRow["PermitStatus"] = dr["PermitStatus"];
				}
				bsFacilityList.ResetBindings(false);
			}
		}

		public void CheckPermitPDF()
		{
			lnkPermitPDF.Enabled = true;
			lnkPermitPDF.BackColor = SystemColors.Control;

			lnkPermitApplicationPDF.Enabled = true;
			lnkPermitApplicationPDF.BackColor = SystemColors.Control;

			if (lnkPermitPDF.Tag == DBNull.Value || lnkPermitPDF.Tag == null || lnkPermitPDF.Tag.ToString() == string.Empty)
			{
				lnkPermitPDF.LinkVisited = false;
			}
			else if (!File.Exists(lnkPermitPDF.Tag.ToString()))
			{
				lnkPermitPDF.LinkVisited = false;
				//lnkPermitPDF.Enabled = false;
				lnkPermitPDF.BackColor = Color.Red;
			}
			else
			{
				lnkPermitPDF.LinkVisited = true;
			}

			if (lnkPermitApplicationPDF.Tag == DBNull.Value || lnkPermitApplicationPDF.Tag == null || lnkPermitApplicationPDF.Tag.ToString() == string.Empty)
			{
				lnkPermitApplicationPDF.LinkVisited = false;
			}
			else if (!File.Exists(lnkPermitApplicationPDF.Tag.ToString()))
			{
				lnkPermitApplicationPDF.LinkVisited = false;
				//lnkPermitApplicationPDF.Enabled = false;
				lnkPermitApplicationPDF.BackColor = Color.Red;
			}
			else
			{
				lnkPermitApplicationPDF.LinkVisited = true;
			}
		}

		public void CheckPermitFolder()
		{
			lnkPermitFolder.Enabled = true;
			lnkPermitFolder.BackColor = SystemColors.Control;

			if (lnkPermitFolder.Tag == null || lnkPermitFolder.Tag.ToString() == string.Empty)
			{
				lnkPermitFolder.LinkVisited = false;
			}
			else if (!Directory.Exists(lnkPermitFolder.Tag.ToString()))
			{
				lnkPermitFolder.Enabled = false;
				lnkPermitFolder.BackColor = Color.Red;
			}
			else
			{
				lnkPermitFolder.LinkVisited = true;
			}
		}

		private void chkIsConfidential_Click(object sender, EventArgs e)
		{
			SetIsConfidential(chkIsConfidential.Checked);
		}

		private void tsbtnShowDevices_Click(object sender, EventArgs e)
		{
			DataRowView drv = bsPermit.Current as DataRowView;
			if (drv != null)
			{
				SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs("Permit", drv["PermitNo"]);

				if (OnGoToEntity != null)
				{
					OnGoToEntity(this, args);
				}
			}
		}

		private void SetIsConfidential(bool isConfidential)
		{
			if (isConfidential)
			{
				pnlConfidential.BackColor = System.Drawing.Color.Red;
			}
			else
			{
				pnlConfidential.BackColor = System.Drawing.SystemColors.Control;
			}
		}

		private void SetRowColor()
		{
			try
			{
				foreach (DataGridViewRow row in this.dgvPermit.Rows)
				{
					foreach (DataGridViewCell cell in row.Cells)
					{
						string CellName = cell.OwningColumn.Name;
						if (CellName.IndexOf("PermitStatus") >= 0 && cell.ValueType == typeof(string) && cell.Value != null)
						{
							if ((string)cell.Value != "Active")
							{
								row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		private void SetEditModeDisplay()
		{
			if (PermitEditStatus == "EditMode" || PermitEditStatus == "New")
			{


				tsbtnUndoPermit.CheckOnClick = true;
				tsbtnSavePermit.CheckOnClick = true;
				tsbtnUndoPermit.Checked = true;
				tsbtnSavePermit.Checked = true;
				btnRefreshPermit.Enabled = false;
				//tsbtnEditPermit.Checked = true;
				btnEditPermit.Enabled = false;
				//lblEditWarning.Visible = false;
				pnlPermitDisable.Enabled = true;

				//if (PdeUserRoles.IsAdmin)
				if (PdePermitUserRoles.IsAdmin)
				{
					tsbtnDeletePermit.Enabled = true;
				}
				else
				{
					tsbtnDeletePermit.Enabled = false;
				}
				//if ((bool)drvPermit["IsPte25"])
				//{
				//	scPermit2.Panel1.BackColor = System.Drawing.Color.DarkTurquoise;
				//}
				//else
				//{
				//	scPermit2.Panel1.BackColor = System.Drawing.SystemColors.Control;
				//}
			}
			else
			{
				tsbtnUndoPermit.CheckOnClick = false;
				tsbtnSavePermit.CheckOnClick = false;
				tsbtnUndoPermit.Checked = false;
				tsbtnSavePermit.Checked = false;
				btnRefreshPermit.Enabled = true;
				//tsbtnEditPermit.Checked = false;
				//btnEditPermit.Enabled = true;

				//btnEditPermit.Enabled = PdeUserRoles.IsEditor;
				btnEditPermit.Enabled = PdePermitUserRoles.IsEditor;
				lblEditWarning.Enabled = true;
				lblEditWarning.Visible = true;
				pnlPermitDisable.Enabled = false;
				tsbtnDeletePermit.Enabled = false;
			}
		}

		private void SetSaveColor()
		{
			if (ReevalDueDataSetHasChanges)
			{
				tsbtnSavePermitReevalDue.BackColor = Color.Tomato;
			}
			else
			{
				tsbtnSavePermitReevalDue.BackColor = System.Drawing.SystemColors.Control;
			}
		}

		#endregion

		#region Copy

		private void tsmiCopySelectedToClipboard_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(dgvPermit.GetClipboardContent());
		}

		private void tsmiCopyPermitEmissions_Click(object sender, EventArgs e)
		{
			dgvPermitEmissions.SelectAll();
			Clipboard.SetDataObject(dgvPermitEmissions.GetClipboardContent());
			dgvPermitEmissions.ClearSelection();
		}

		private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dgvPermit.SelectAll();
			Clipboard.SetDataObject(dgvPermit.GetClipboardContent());
			dgvPermit.ClearSelection();
		}

		private void btnPasteToFPTE_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.BindingSource bsPermitPPTE = new System.Windows.Forms.BindingSource();
			bsPermitPPTE = dgvPermitEmissions.DataSource as System.Windows.Forms.BindingSource;

			string FacilityNo = null;
			DataRowView drv = bsPermit.Current as DataRowView;
			if (drv != null)
			{
				FacilityNo = drv["FacilityNo"].ToString();
			}

			SbcapcdOrg.PdePermit.PdePermitComponents.CopyEmissionsGridEventArgs argsCopyEmissionsGrid = new SbcapcdOrg.PdePermit.PdePermitComponents.CopyEmissionsGridEventArgs(FacilityNo, bsPermitPPTE);
			if (OnCopyEmissionsGrid != null)
			{
				OnCopyEmissionsGrid(this, argsCopyEmissionsGrid);
			}
		}

		#endregion

		#region Email

		private void btnEmailRoutingSlip_Click(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)bsPermit.Current;
			drv["RoutingSlipSentDate"] = System.DateTime.Today;
			SavePermit();
			if (SbcapcdOrg.PdePermit.Permit.PermitBL.EmailRoutingSlip(base.usrConnectionString, drv["PermitNo"].ToString()))
			{
				MessageBox.Show("Email sent", "Email");
				drv["RoutingSlipSentDate"] = System.DateTime.Today;
				bsPermit.ResetBindings(false);
			}
		}

		private void btnEmailCompletenessRoutingSlip_Click(object sender, EventArgs e)
		{
			EmailCompletenessRoutingSlip();
		}

		private void EmailCompletenessRoutingSlip()
		{
			DataRowView drv = (DataRowView)bsPermit.Current;
			drv["RoutingSlipCompletenessSentDate"] = System.DateTime.Today;
			SavePermit();
			if (SbcapcdOrg.PdePermit.Permit.PermitBL.EmailCompletenessRoutingSlip(base.usrConnectionString, drv["PermitNo"].ToString()))
			{
				MessageBox.Show("Email sent", "Email");
				bsPermit.ResetBindings(false);
			}
			else
			{

			}
		}

		#endregion

		private void dgvPermit_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			try
			{
				if ((e.ColumnIndex == this.dgvPermit.Columns["HasPSAPermit"].Index) && e.Value != null)
				{
					DataGridViewCell cell = dgvPermit.Rows[e.RowIndex].Cells[e.ColumnIndex];
					DataGridViewCell StatusCell = dgvPermit.Rows[e.RowIndex].Cells[e.ColumnIndex - 1];
					if (e.Value.Equals(true))
					{
						StatusCell.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
					}
					else if (e.Value.Equals(false))
					{
						StatusCell.Style = dgvPermit.RowsDefaultCellStyle;
					}
				}
				e.FormattingApplied = true;
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
				e.FormattingApplied = false;
			}
			finally
			{
			}
		}

		#region PermitFeeHistory

		private void dgvPermitFeeHistory_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex < 0 || e.ColumnIndex != 5 || e.RowIndex >= (dgvPermitFeeHistory.Rows.Count))
					return;

				if (!(MessageBox.Show("Do you want to delete this fee action?", "Delete this fee action?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
				{
					return;
				}

				dgvPermitFeeHistory.Rows.RemoveAt(e.RowIndex);

				PermitDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
				OnPermitDataSetChanged(this, args);
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}

		private void dgvPermitFeeHistory_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == 1 && e.Value != null && e.Value.ToString().IndexOf(@"/") < 0)
				{
					e.Value = DateTime.Parse(e.Value.ToString().Insert(4, "/").Insert(2, "/"));
					e.ParsingApplied = true;
				}
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);

			}
		}

		#endregion

		private void PermitLocation_OnLocatioDataSetChanged()
		{
			PermitDataSetHasChanges = true;
			SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
			OnPermitDataSetChanged(this, args);
		}

		#region Supersede

		private void dgvPermitSupersede_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				dgvPermitSupersede.EndEdit();
				bsPermitSupersede.EndEdit();
				PermitSupersede(e);
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "usrPermit:dgvPermitSupersede_CellContentClick");
			}
		}

		private void PermitSupersede(DataGridViewCellEventArgs e)
		{
			DateTime SupersededDate = System.DateTime.Today;
			DateTime FinalIssuedDate = System.DateTime.Today;

			if (PermitDataSetHasChanges)
			{
				MessageBox.Show("Save permit changes before superseding.");
				return;
			}

			if (MessageBox.Show("Do you want to Supersede this permit? The changes will immediately be saved and con not be undone.", "Supersede?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				string FindFinalIssuedFilter = "PermitNo = '" + ((DataRowView)bsPermit.Current)["PermitNo"].ToString() + "' AND PermitActionId = 11";

				if (dsPermit.Tables["PermitActionHistory"].Select(FindFinalIssuedFilter).GetLength(0) == 0)
				{
					MessageBox.Show("The current permit does not have a Final Issued Date. This is required before superseding the permit.", "Supersede Permit", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}
				else if (dsPermit.Tables["PermitActionHistory"].Select(FindFinalIssuedFilter).GetLength(0) == 1)
				{
					DataRow[] drvPermitActionHistory = dsPermit.Tables["PermitActionHistory"].Select(FindFinalIssuedFilter);
					FinalIssuedDate = (DateTime)drvPermitActionHistory[0]["PermitActionDate"];
				}

				object SupersededPermitNo = dgvPermitSupersede.Rows[e.RowIndex].Cells[0].Value;
				string SelectFilter = "PermitNo = '" + SupersededPermitNo.ToString() + "' AND PermitActionId = 12";

				if (dsPermit.Tables["PermitActionHistory"].Select(SelectFilter).GetLength(0) > 0)
				{
					MessageBox.Show("This permit has already been superseded.", "Supersede Permit", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
				else
				{
					InCurrentChangedDialog = true;

					//htSupersede.Add(SupersededPermitNo, "Superseded");

					DataRow NewRow = dsPermit.Tables["PermitActionHistory"].NewRow();
					NewRow["PermitActionHistoryId"] = SbcapcdOrg.PdePermit.Permit.PermitBL.GetPdeNewId(base.usrConnectionString);
					NewRow["PermitNo"] = SupersededPermitNo;
					NewRow["PermitActionId"] = 12;
					NewRow["PermitActionDate"] = FinalIssuedDate;

					//NewRow["LoginID"] = PdeUserRoles.LoginID;
					//NewRow["EmployeeIdNo"] = PdeUserRoles.EmployeeID;

					NewRow["LoginID"] = PdePermitUserRoles.LoginID;
					NewRow["EmployeeIdNo"] = PdePermitUserRoles.EmployeeID;
					dsPermit.Tables["PermitActionHistory"].Rows.Add(NewRow);


					if (!SavePermitSupersedeTransaction(SupersededPermitNo.ToString()))
					{
						InCurrentChangedDialog = false;
						return;
					}

					DataRow drSupersededPermit = dsPermit.Permit.Rows.Find(SupersededPermitNo);

					if (drSupersededPermit != null)
					{
						drSupersededPermit["PermitStatus"] = "Superseded";
						drSupersededPermit.EndEdit();
					}

					//dgvPermitSupersede.Rows[e.RowIndex].Cells["SupersededDate"].Value = SupersededIssued.ToShortDateString();

					DataRow drSupersedingPermits = dsPermitAux.Tables["SupersedingPermits"].NewRow();
					drSupersedingPermits["SupersededPermitNo"] = SupersededPermitNo;
					drSupersedingPermits["PermitNo"] = "";
					drSupersedingPermits["FinalIssuedDate"] = FinalIssuedDate;
					drSupersedingPermits["Permit"] = drvPermit["Permit"].ToString();
					dsPermitAux.Tables["SupersedingPermits"].Rows.Add(drSupersedingPermits);


					if (sbPermitFilter.Length > 0)
					{
						bsPermit.Filter = sbPermitFilter.ToString();
					}
					else
					{
						bsPermit.RemoveFilter();
					}

					bsSupersedingPermits.ResetBindings(false);
					bsPermit.ResetBindings(false);
					PermitDataSetHasChanges = false;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
					OnPermitDataSetChanged(this, args);
					InCurrentChangedDialog = false;
				}
			}
		}

		private bool SavePermitSupersedeTransaction(string supersededPermitNo)
		{
			dgvSupersedingPermits.EndEdit();
			dgvPermitSupersede.EndEdit();
			bsPermitSupersede.EndEdit();

			var IsMappingPermit = from DataRow drpermit in dsPermit.Permit
								  where (drpermit["PermitNo"].ToString() == supersededPermitNo.ToString()) && (bool)drpermit["IsMappingPermit"] == true
								  select drpermit;

			if (IsMappingPermit.Count() > 0)
			{
				SupersededPermitIsMappingPermit = true;
			}

			SbcapcdOrg.PdePermit.Permit.PermitBL savePermitSupersedeTransaction = new PermitBL();
			if (savePermitSupersedeTransaction.SavePermitSupersedeTransaction(base.usrConnectionString, dsPermit.GetChanges(), PermitNo.ToString(), supersededPermitNo, SupersededPermitIsMappingPermit))
			{
				dsPermit.Tables["PermitActionHistory"].AcceptChanges();
				dsPermit.Tables["PermitSupersede"].AcceptChanges();

				bsSupersedingPermits.ResetBindings(false);
				return true;
			}
			else
			{
				MessageBox.Show("Save failed");
				return false;
			}
		}

		private void dgvPermitSupersede_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			if (!(MessageBox.Show("Do you want to Delete this Permit from the superseded list?", "Delete Permit from the superseded list?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				e.Cancel = true;
			}
			else
			{
				MessageBox.Show("You are deleting a Permit from the superseded list. Check the status of the Permit that has been deleted form the list - the status or actions may need to be updated.", "Supersede Permit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnDeleteSupersededPermit_Click(object sender, EventArgs e)
		{
			if ((MessageBox.Show("Do you want to Delete this Superseded Permit?", "Delete this Superseded Permit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				bsPermitSupersede.RemoveCurrent();
				PermitDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
				OnPermitDataSetChanged(this, args);
				MessageBox.Show("You deleted a Permit from the superseded list. Check the status of the Permit that has been deleted from the list - the status or actions may need to be updated. You can use the green 'Update permit Status' button on the 'Actions / Exceptions' tab.", "Supersede Permit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnUndoSupersede_Click(object sender, EventArgs e)
		{
			dsPermit.Tables["PermitSupersede"].RejectChanges();
		}

		#endregion

		#region PDF Links

		private void lnkPermitPDF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			if (lnkPermitPDF.Tag != null && lnkPermitPDF.Tag.ToString() != string.Empty && File.Exists(lnkPermitPDF.Tag.ToString()))
			{
				System.Diagnostics.Process.Start(lnkPermitPDF.Tag.ToString());
			}
			else
			{

			}
			this.Cursor = Cursors.Default;
		}

		private void lnkPermitFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			if (lnkPermitFolder.Tag != null && lnkPermitFolder.Tag.ToString() != string.Empty && Directory.Exists(lnkPermitFolder.Tag.ToString()))
			{
				System.Diagnostics.Process.Start(lnkPermitFolder.Tag.ToString());
			}
			else
			{

			}
			this.Cursor = Cursors.Default;
		}

		private void tsmiClearPermitFolder_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show("Are you sure you want to clear the Permit Folder link?", "Delete Permit Folder Path?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				lnkPermitFolder.Tag = null;
				MessageBox.Show("Permit Folder Deleted", "Permit Folder Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
				PermitDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
				OnPermitDataSetChanged(this, args);
				CheckPermitFolder();
			}
		}

		private void tsmiPastePermitFolder_Click(object sender, EventArgs e)
		{
			if (Clipboard.ContainsText() && Directory.Exists(Clipboard.GetText()))
			{
				lnkPermitFolder.Tag = Clipboard.GetText();
				MessageBox.Show("Permit Folder Added", "Permit Folder Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
				PermitDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
				OnPermitDataSetChanged(this, args);
				CheckPermitFolder();
			}
			else
			{
				MessageBox.Show("Invalid Permit Folder", "Invalid path", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnPermitPDF_Click(object sender, EventArgs e)
		{
			obdPermitPDF.Filter = "pdf files (*.pdf)|*.pdf";
			if (obdPermitPDF.ShowDialog() == DialogResult.OK)
			{
				lnkPermitPDF.Tag = obdPermitPDF.FileName;
				CheckPermitPDF();
			}
		}

		private void btnPermitFolder_Click(object sender, EventArgs e)
		{
			try
			{
				CommonOpenFileDialog dialog = new CommonOpenFileDialog();

				dialog.IsFolderPicker = true;
				dialog.EnsureFileExists = true;
				dialog.EnsureValidNames = true;
				dialog.Multiselect = false;
				dialog.ShowPlacesList = true;

				if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
				{
					lnkPermitFolder.Tag = dialog.FileName;
					PermitDataSetHasChanges = true;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
					OnPermitDataSetChanged(this, args);
					CheckPermitFolder();
				}
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Permit:PermitCommentsPath");
			}

			//if (fbdPermitFolder.ShowDialog() == DialogResult.OK)
			//{
			//    lnkPermitFolder.Tag = fbdPermitFolder.SelectedPath;
			//    PermitDataSetHasChanges = true;
			//    SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
			//    OnPermitDataSetChanged(this, args);
			//    CheckPermitFolder();
			//}
		}

		private void tsmiClearPermitApplicationPDF_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show("Are you sure you want to clear the Application PDF link?", "Delete Application PDF Path?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				lnkPermitApplicationPDF.Tag = null;
				MessageBox.Show("Application PDF Path Deleted", "Application PDF Path Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
				PermitDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
				OnPermitDataSetChanged(this, args);
				CheckPermitPDF();
			}
		}

		private void lnkPermitApplicationPDF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			if (lnkPermitApplicationPDF.Tag != null && lnkPermitApplicationPDF.Tag.ToString() != string.Empty && File.Exists(lnkPermitApplicationPDF.Tag.ToString()))
			{
				System.Diagnostics.Process.Start(lnkPermitApplicationPDF.Tag.ToString());
			}
			else
			{

			}
			this.Cursor = Cursors.Default;
		}

		private void btnPermitApplicationPDF_Click(object sender, EventArgs e)
		{
			ofdApplicationPDF.Filter = "pdf files (*.pdf)|*.pdf";
			if (ofdApplicationPDF.ShowDialog() == DialogResult.OK)
			{
				lnkPermitApplicationPDF.Tag = ofdApplicationPDF.FileName;
				CheckPermitPDF();
			}
		}

		#endregion

		private void dgvPermitEmissions_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			//int i = 4;
		}

		private void dgvPermit_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}

		private void btnCopyProjects_Click(object sender, EventArgs e)
		{
			CopyProjectsFromPermitNo = PermitNo.ToString();
		}

		private void btnPasteProjects_Click(object sender, EventArgs e)
		{
			PasteProjects();
		}

		private void PasteProjects()
		{
			if (CopyProjectsFromPermitNo == null)
			{
				MessageBox.Show("No From permit has been selected", "Copy Projects From Permit", MessageBoxButtons.OK);
			}
			else
			{
				string SelectFilter = "PermitNo = '" + CopyProjectsFromPermitNo + "'";

				foreach (DataRow dr in dsPermit.PermitProject.Select(SelectFilter))
				{
					string strSelect = "PermitNo ='" + PermitNo.ToString() + "' AND ProjectNo = '" + dr["ProjectNo"].ToString() + "'";
					if (dsPermit.PermitProject.Select(strSelect).Length == 0)
					{
						DataRow drNewPermitProject = dsPermit.PermitProject.NewRow();
						drNewPermitProject["PermitProjectId"] = SbcapcdOrg.PdePermit.Permit.PermitBL.GetPdeNewId(base.usrConnectionString);
						drNewPermitProject["PermitNo"] = PermitNo;
						drNewPermitProject["ProjectNo"] = dr["ProjectNo"];
						dsPermit.PermitProject.Rows.Add(drNewPermitProject);
					}
				}
				bsPermitProject.ResetBindings(false);
			}
		}

		private bool SetPermitStatus()
		{
			int iChangesToStatus = 0;
			DataRowView drv = (DataRowView)bsPermit.Current;
			string CurrentPermitStatus = drv["PermitStatus"].ToString();
			string NewPermitStatus = "";
			foreach (DataRow dr in dsPermit.PermitActionHistory.Select("PermitNo = '" + PermitNo + "'"))
			{
				switch ((int)dr["PermitActionId"])
				{
					case 1: // Active
						//iChangesToStatus++;
						break;
					case 2: // Withdrawn
						iChangesToStatus++;
						NewPermitStatus = "Withdrawn";
						break;
					case 9: //9	Cancelled
						iChangesToStatus++;
						NewPermitStatus = "Cancelled";
						break;
					case 12: // 12	Superseded
						iChangesToStatus++;
						NewPermitStatus = "Superseded";
						break;
					case 29: // 29	Active
						iChangesToStatus++;
						NewPermitStatus = "Active";
						break;
					case 40: // 40	Suspended
						iChangesToStatus++;
						NewPermitStatus = "Suspended";
						break;
					case 41: // 41	Denied
						iChangesToStatus++;
						NewPermitStatus = "Denied";
						break;
					default:
						break;
				}
			}


			if (drv != null && iChangesToStatus == 1 && NewPermitStatus != "Active")
			{
				drv["PermitStatus"] = NewPermitStatus;
				drv.EndEdit();
			}
			else if (iChangesToStatus > 1)
			{
				MessageBox.Show("Permit Status is not valid. More than one inactive action.", "Permit Status Change", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (iChangesToStatus == 0 && CurrentPermitStatus != "Active")
			{
				drv["PermitStatus"] = "Active";
				MessageBox.Show("Permit Status changed to Active.", "Permit Status Change", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				drv.EndEdit();
				return false;
			}


			return true;
		}

		private void dgvPermitActionHistory_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
		{
			if (e.ColumnIndex == 1 && e.Value != null && e.Value.ToString().IndexOf(@"/") < 0)
			{
				e.Value = DateTime.Parse(e.Value.ToString().Insert(4, "/").Insert(2, "/"));
				e.ParsingApplied = true;
			}
		}

		private void dgvPermit_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				InCurrentChangedDialog = true;
			}
		}

		private void tsmiClearFinalPermitPdf_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show("Are you sure you want to clear the final Permit PDF link?", "Delete Permit PDF Path?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				lnkPermitPDF.Tag = null;
				MessageBox.Show("Permit PDF Path Deleted", "Permit PDF Path Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
				PermitDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
				OnPermitDataSetChanged(this, args);
				CheckPermitPDF();
			}
		}

		private void dgvPermitFeeHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(e.Exception);
		}

		private void dgvPermitFeeHistory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			//if (e.ColumnIndex == 0 && e.RowIndex > -1)
			//{
			//    int i = (int)dgvPermitFeeHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
			//    foreach (DataGridViewRow dgrv in dgvPermitFeeHistory.Rows)
			//    {
			//        object o = dgrv.Cells[0].Value;
			//        if (dgrv.Cells[0].RowIndex != e.RowIndex && o != null && (int)o == i)
			//        {
			//            MessageBox.Show("Error: Duplicate Permit Fee Action.", "Permit Fee Action", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			//        }
			//    }
			//}
		}

		private void dgvPermitProject_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells["PermitProjectId"].Value = SbcapcdOrg.PdePermit.PdePermitComponents.CommonDL.GetPdeNewId(base.usrConnectionString);
		}

		private void dgvPermitFeeHistory_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells["PermitFeeHistoryId"].Value = SbcapcdOrg.PdePermit.PdePermitComponents.CommonDL.GetPdeNewId(base.usrConnectionString);
			e.Row.Cells["PaymentCompany"].Value = SbcapcdOrg.PdePermit.Permit.PermitBL.GetPermitBillingCompanyByFacility(base.usrConnectionString, NewFacilityNo);
		}

		private void txtPermitNumber_Leave(object sender, EventArgs e)
		{
			if (txtPermitNumber.Text.Length != 5)
			{
				MessageBox.Show("The Permit Number must be five characters.", "Permit Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void tbcPermit_Selected(object sender, TabControlEventArgs e)
		{
			usrLetters.LettersTabSelected = false;

			if (e.TabPage == tabReevalsDue)
			{
				if (dsReevalDueAdmin.ReevalAssignmentLabel.Count == 0)
				{
					SbcapcdOrg.PdePermit.Permit.PermitBL getReevalAssignmentLabel = new PermitBL();
					getReevalAssignmentLabel.GetReevalAssignmentLabel(base.usrConnectionString, dsReevalDueAdmin);

					tscmbReevalAssignmentLabel.ComboBox.DataSource = bsReevalAssignmentLabel;
					tscmbReevalAssignmentLabel.ComboBox.DisplayMember = "ReevalAssignmentLabelName";
					tscmbReevalAssignmentLabel.ComboBox.ValueMember = "ReevalAssignmentLabeId";
					tscmbReevalAssignmentLabel.SelectedIndex = -1;

					//SbcapcdOrg.PdePermit.Permit.PermitBL getReevalDueAdmin = new PermitBL();
					//getReevalDueAdmin.GetReevalDue(dsReevalDueAdmin);
					//bsPermitReevalDue.Sort = "PermitActionDate, SSID, FID";
					//SetRowColorPermitReevalDue();
				}

				//bsPermit.SuspendBinding();
				//Entity = null;
				//EntityNo = "00000";
				//IsSelectMode = false;
				//CompanyNo = null;
				//tscmbDocType.SelectedIndex = 0;
				//tstxtPermitFilter.Clear();
				//tscmbPermitStatus.SelectedItem = "Active";
				//tscmbPermitType.SelectedIndex = 0;
				//FilterPermit();
				//bsPermit.ResumeBinding();
				//bsPermit.ResetBindings(false);
				//bsPermit.MoveFirst();
				//SetRowColor();
			}
			else if (e.TabPage == tabLetters)
			{
				usrLetters.LettersTabSelected = true;
				usrLetters.SetPermit();
				usrLetters.Focus();
			}
		}

		private void dgvPermitActionHistory_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			comboPermitDataSetHasChanges = PermitDataSetHasChanges;
			if (dgvPermitActionHistory.CurrentCell.ColumnIndex == 0 && dgvPermitActionHistory.CurrentCell.RowIndex > -1)
			{
				ComboBox combo = e.Control as ComboBox;
				if (combo != null)
				{
					// Remove an existing event-handler, if present, to avoid adding multiple handlers when the editing control is reused.
					combo.SelectedIndexChanged -= new EventHandler(comboBoxPermitAction_SelectedIndexChanged);

					// Add the event handler. 
					combo.SelectedIndexChanged += new EventHandler(comboBoxPermitAction_SelectedIndexChanged);
				}
			}
		}

		private void comboBoxPermitAction_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (((ComboBox)sender).SelectedIndex > -1)
			{
				string selectedValue = ((ComboBox)sender).SelectedValue.ToString();
				if (selectedValue == "32")
				{
					if (dgvPermitActionHistory.CurrentRow.IsNewRow)
					{
						dgvPermitActionHistory.EndEdit();
						bsPermitActionHistory.EndEdit();
						dsPermit.PermitActionHistory.FindByPermitActionHistoryId(NewPermitActionHistoryId).Delete();
						bsPermitActionHistory.ResetBindings(false);
						MessageBox.Show("Annual Report Received is no longer entered here.", "Permit Fee Action", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						if (comboPermitDataSetHasChanges != PermitDataSetHasChanges)
						{
							PermitDataSetHasChanges = comboPermitDataSetHasChanges;
							SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
							OnPermitDataSetChanged(this, args);
						}
					}
					else
					{
						DataRow dr = dgvPermitActionHistory.CurrentRow.DataBoundItem as DataRow;
						if (dr != null)
						{
							dr.RejectChanges();
							MessageBox.Show("Annual Report Received is no longer entered here.", "Permit Fee Action", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						}
					}
				}

				if (selectedValue == "27")
				{
					if (dgvPermitActionHistory.CurrentRow.IsNewRow)
					{
						dgvPermitActionHistory.EndEdit();
						bsPermitActionHistory.EndEdit();
						dsPermit.PermitActionHistory.FindByPermitActionHistoryId(NewPermitActionHistoryId).Delete();
						bsPermitActionHistory.ResetBindings(false);
						MessageBox.Show("Expired action is no longer used. Use the Cancellation Final action.", "Permit Action", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						if (comboPermitDataSetHasChanges != PermitDataSetHasChanges)
						{
							PermitDataSetHasChanges = comboPermitDataSetHasChanges;
							SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
							OnPermitDataSetChanged(this, args);
						}
					}
					else
					{
						DataRow dr = dgvPermitActionHistory.CurrentRow.DataBoundItem as DataRow;
						if (dr != null)
						{
							dr.RejectChanges();
							MessageBox.Show("Expired action is no longer used. Use the Cancellation Final action.", "Permit Action", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						}
					}
				}

				if (selectedValue == "12")
				{
					if (dgvPermitActionHistory.CurrentRow.IsNewRow)
					{
						dgvPermitActionHistory.EndEdit();
						bsPermitActionHistory.EndEdit();
						dsPermit.PermitActionHistory.FindByPermitActionHistoryId(NewPermitActionHistoryId).Delete();
						bsPermitActionHistory.ResetBindings(false);
						MessageBox.Show("Do not Superseded a permit with this action. Use the Supersede tab for the permit that is superseding this permit.", "Permit Action", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						if (comboPermitDataSetHasChanges != PermitDataSetHasChanges)
						{
							PermitDataSetHasChanges = comboPermitDataSetHasChanges;
							SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
							OnPermitDataSetChanged(this, args);
						}
					}
					else
					{
						DataRow dr = dgvPermitActionHistory.CurrentRow.DataBoundItem as DataRow;
						if (dr != null)
						{
							dr.RejectChanges();
							MessageBox.Show("Do not Superseded a permit with this action. Use the Supersede tab for the permit that is superseding this permit.", "Permit Action", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						}
					}
				}

				if (selectedValue == "9") // Cancellation Final
				{
					string NovList = SbcapcdOrg.PdePermit.Permit.PermitBL.GetNovsByPermitNo(base.usrConnectionString, PermitNo);

					if (NovList.Length > 0)
					{
						MessageBox.Show("This facility or equipment has the following unresolved NOVs: " + NovList
						+ Environment.NewLine + Environment.NewLine +
						"Confirm that these outstanding NOVs are non-significant violations before continuing. See Engineering Supervisor if you have any questions."
						, "Facility has NOVs", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

			}
		}

		private void bsPermitFeeHistory_CurrentChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)bsPermitFeeHistory.Current;
		}

		private void btnAddAnRepPermit_Click(object sender, EventArgs e)
		{
			AddAnRepPermit();
		}

		private void AddAnRepPermit()
		{
			if (SbcapcdOrg.PdePermit.Permit.PermitBL.AddAnnualReportTracking(base.usrConnectionString, PermitNo.ToString()))
			{
				MessageBox.Show("Permit added to Annual Reports Tracking", "Annual Reports Tracking", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Error! Permit not added to Annual Reports Tracking", "Annual Reports Tracking", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgvPermitActionHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			//int i = 2;
		}

		private void dgvPermitProject_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			//int i = 2;
		}

		private void dgvPermitSupersede_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			//int i = 2;
		}

		private void dgvSupersedingPermits_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			//int i = 2;
		}

		#region ReevalsDue

		private void SetRowColorPermitReevalDue()
		{
			try
			{
				foreach (DataGridViewRow row in this.dgvReevalDueAdmin.Rows)
				{
					foreach (DataGridViewCell cell in row.Cells)
					{
						string CellName = cell.OwningColumn.Name;
						if (CellName.IndexOf("HasPdePermit") >= 0 && cell.ValueType == typeof(bool) && cell.Value != null)
						{
							if ((bool)cell.Value)
							{
								row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
							}
							else
							{
								row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		private void tsmiFilterByHasPermit_Click(object sender, EventArgs e)
		{
			FilterReevalsDue();
		}

		private void tsbtnSortByDateSsid_Click(object sender, EventArgs e)
		{
			bsPermitReevalDue.Sort = "ReevalDueDate, SSID, FID";
			SetRowColorPermitReevalDue();
		}

		private void BuildFilterReevalsDue(string filter)
		{
			if (sbFilterReevalsDue.Length == 0)
			{
				sbFilterReevalsDue.Append(filter);
			}
			else
			{
				sbFilterReevalsDue.Append(" AND " + filter);
			}
		}

		private void FilterReevalsDue()
		{
			sbFilterReevalsDue.Remove(0, sbFilterReevalsDue.Length);

			if (tsmiFilterByHasPermit.Checked && tsmiShowReevalNotNeeded.Checked)
			{
				bsPermitReevalDue.RemoveFilter();
			}
			else if (tsmiShowReevalNotNeeded.Checked && !tsmiFilterByHasPermit.Checked)
			{
				BuildFilterReevalsDue("(ReevalNotNeeded = True AND HasPdePermit = False) OR (ReevalNotNeeded = False AND HasPdePermit = False)");
			}
			else if (!tsmiShowReevalNotNeeded.Checked && tsmiFilterByHasPermit.Checked)
			{
				BuildFilterReevalsDue("(ReevalNotNeeded = False AND HasPdePermit = False) OR (ReevalNotNeeded = False AND HasPdePermit = True)");
			}
			else if (!tsmiShowReevalNotNeeded.Checked && !tsmiFilterByHasPermit.Checked)
			{
				BuildFilterReevalsDue("(ReevalNotNeeded = False AND HasPdePermit = False)");
				//SetRowColorPermitReevalDue();
				//return;
			}
			else
			{
				BuildFilterReevalsDue("(ReevalNotNeeded = False AND HasPdePermit = False)");
				//SetRowColorPermitReevalDue();
				//return;
			}

			bsPermitReevalDue.Filter = sbFilterReevalsDue.ToString();
			SetRowColorPermitReevalDue();
		}

		private void tscmbReevalAssignmentLabel_DropDownClosed(object sender, EventArgs e)
		{
			GetReevalDue();
		}

		private void GetReevalDue()
		{
			this.Cursor = Cursors.WaitCursor;
			SbcapcdOrg.PdePermit.Permit.PermitBL getReevalDueAdmin = new PermitBL();
			if (tscmbReevalAssignmentLabel.ComboBox.SelectedIndex > -1)
			{
				getReevalDueAdmin.GetReevalDue(base.usrConnectionString, dsReevalDueAdmin, (int)tscmbReevalAssignmentLabel.ComboBox.SelectedValue);
			}
			else
			{
				this.Cursor = Cursors.Default;
				return;
			}

			bsPermitReevalDue.ResetBindings(false);
			bsPermitReevalDue.Sort = "ReevalDueDate, SSID, FID";
			SetRowColorPermitReevalDue();

			bsPermit.SuspendBinding();
			Entity = null;
			EntityNo = "00000";
			IsSelectMode = false;
			CompanyNo = null;
			tscmbDocType.SelectedIndex = 0;
			tstxtPermitFilter.Clear();
			tscmbPermitStatus.SelectedItem = "Active";
			tscmbPermitType.SelectedIndex = 0;
			FilterPermit();
			bsPermit.ResumeBinding();
			bsPermit.ResetBindings(false);
			bsPermit.MoveFirst();
			SetRowColor();
			this.Cursor = Cursors.Default;
			FilterReevalsDue();
			this.Cursor = Cursors.Default;
		}

		private void tsbtnReevalNotNeeded_Click(object sender, EventArgs e)
		{
			ResetPermitFilters();



			DataRowView drv = bsPermitReevalDue.Current as DataRowView;
			if (drv != null)
			{
				drv["ReevalNotNeeded"] = !(bool)drv["ReevalNotNeeded"];
			}
			dgvReevalDueAdmin.EndEdit();
			bsPermitReevalDue.EndEdit();
			dgvReevalDueAdmin.Refresh();
			FilterReevalsDue();
		}

		private void tsmiShowReevalNotNeeded_Click(object sender, EventArgs e)
		{
			FilterReevalsDue();
		}

		private void tsbtnResetReevalDueFilters_Click(object sender, EventArgs e)
		{
			ResetReevalDueDefaultFilters();
		}

		private void ResetReevalDueDefaultFilters()
		{
			//bsPermitReevalDue.Filter = "ReevalNotNeeded = False AND HasPdePermit = False";
			tsmiFilterByHasPermit.Checked = true;
			tsmiShowReevalNotNeeded.Checked = false;
			FilterReevalsDue();
		}

		private void bsPermitReevalDue_CurrentChanged(object sender, EventArgs e)
		{
			GoToReevalFromPermit();
		}

		private class MyRenderer : ToolStripProfessionalRenderer
		{
			protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
			{
				var btn = e.Item as ToolStripButton;
				if (btn != null && btn.CheckOnClick && btn.Checked && btn.Name == "tsbtnGoToReevalFromPermit")
				{
					Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
					e.Graphics.FillRectangle(Brushes.Tomato, bounds);
				}
				else base.OnRenderButtonBackground(e);
			}
		}

		private void GoToReevalFromPermit()
		{
			DataRowView drv = (DataRowView)bsPermitReevalDue.Current;
			if (drv != null && tsbtnGoToReevalFromPermit.Checked)
			{
				GoToPermit(drv["PermitNo"]);
			}
		}

		private void tsbtnGoToReevalFromPermit_Click(object sender, EventArgs e)
		{
			GoToReevalFromPermit();
		}

		private void tsbtnNewReevalPermit_Click(object sender, EventArgs e)
		{
			CreateNewReevalPermits();
		}

		private void CreateNewReevalPermits()
		{
			InCurrentChangedDialog = true;
			PermitEditStatus = "New";
			this.Parent.Cursor = Cursors.WaitCursor;

			ResetPermitFilters();

			foreach (DataGridViewRow dgrv in dgvReevalDueAdmin.SelectedRows)
			{
				DataRowView drv = (DataRowView)dgrv.DataBoundItem;
				if (drv != null)
				{
					if (!(bool)drv["HasPdePermit"])
					{
						string NewPermitNo = SbcapcdOrg.PdePermit.Permit.PermitBL.GetNewPermitNo(base.usrConnectionString);
						drv["NewPermitNo"] = NewPermitNo;
						drv["HasPdePermit"] = true;
						NewReevalPermit(drv["PermitNo"].ToString(), NewPermitNo, drv["NewDocumentType"].ToString(), drv["NewPermitNumber"].ToString(), drv["NewPermitSuffix"].ToString(), drv["EngineerEmployeeID"].ToString(), (bool)drv["IsDirectFinalPermit"], (bool)drv["IsStampedIssuance"]);

						SavePermit();
						if (!SbcapcdOrg.PdePermit.Permit.PermitBL.EmailRoutingSlip(base.usrConnectionString, NewPermitNo))
						{
							MessageBox.Show("Routing Slip Not Sent");
						}
					}
					else
					{
						MessageBox.Show("This Reeval already has a permit.", "New Reeval Permit not created.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}

			SavePermitReevalDue();
			bsPermit.ResumeBinding();
			InCurrentChangedDialog = false;
			ReevalDueDataSetHasChanges = false;
			tslblReevalPermitAdded.Visible = ReevalDueDataSetHasChanges;
			SetRowColorPermitReevalDue();
			this.Parent.Cursor = Cursors.Default;
		}

		private void NewReevalPermit(string permitNo, string newPermitNo, string newDocumentType, string newPermitNumber, string newPermitSuffix, string employeeIdNo, bool isDirectFinalPermit, bool isStampedIssuance)
		{
			this.Parent.Cursor = Cursors.WaitCursor;
			try
			{
				InCurrentChangedDialog = true;
				DataRow drv = dsPermit.Permit.FindByPermitNo(permitNo);
				bsPermit.SuspendBinding();

				DataRow dr = dsPermit.Tables["Permit"].NewRow();
				dr["PermitNo"] = newPermitNo;
				dr["DocumentType"] = newDocumentType;
				dr["PermitNumber"] = newPermitNumber;
				dr["PermitSuffix"] = newPermitSuffix;
				dr["IsDirectFinalPermit"] = isDirectFinalPermit;
				dr["IsStampedIssuance"] = isStampedIssuance;
				dr["FacilityNo"] = drv["FacilityNo"];
				//dr["PermitDesc"] = "New From Permit:" + Environment.NewLine + Environment.NewLine + drv["PermitDesc"].ToString();
				dr["PermitDesc"] = drv["PermitDesc"].ToString();
				dr["IsReimbursable"] = drv["IsReimbursable"];
				dr["EmployeeIdNo"] = employeeIdNo;
				dr["IsPermitPriority"] = drv["IsPermitPriority"];
				dr["PermitStatus"] = "Active";
				dr["PermitTypeId"] = drv["PermitTypeId"];
				dr["LocationNo"] = drv["LocationNo"];
				dr["LeadAgencyNo"] = drv["LeadAgencyNo"];
				dr["CompanyNo"] = drv["CompanyNo"];
				dr["StationarySourceNo"] = drv["StationarySourceNo"];
				dr["Permit"] = drv["Permit"];
				dr["RequiresAnnualReport"] = drv["RequiresAnnualReport"];
				dr["RoutingSlipSentDate"] = System.DateTime.Today;
				dr["IsConsolidatedPermit"] = drv["IsConsolidatedPermit"];
				dr["IsConfidential"] = drv["IsConfidential"];
				dr["AtVariousLocations"] = drv["AtVariousLocations"];
				dr["IsFastTrack"] = drv["IsFastTrack"];
				dr["IncrementConsumed"] = drv["IncrementConsumed"];
				dr["HasHealthRiskAssessment"] = drv["HasHealthRiskAssessment"];
				dr["HasAqia"] = drv["HasAqia"];
				dr["HasBact"] = drv["HasBact"];
				dr["HasMonitoring"] = drv["HasMonitoring"];
				dr["HasSourceTest"] = drv["HasSourceTest"];
				dr["IsMajorModification"] = drv["IsMajorModification"];
				dr["HasNeiDDecrease"] = drv["HasNeiDDecrease"];
				dr["IsPrimaryReevalPermit"] = drv["IsPrimaryReevalPermit"];
				dr["IsMappingPermit"] = drv["IsMappingPermit"]; 
				dr["ReportingType"] = drv["ReportingType"];

				dsPermit.Tables["Permit"].Rows.Add(dr);

				DataRow drPermitActionHistory = dsPermit.Tables["PermitActionHistory"].NewRow();
				drPermitActionHistory["PermitActionHistoryId"] = SbcapcdOrg.PdePermit.Permit.PermitBL.GetPdeNewId(base.usrConnectionString);
				drPermitActionHistory["PermitNo"] = newPermitNo;
				drPermitActionHistory["PermitActionId"] = 10;
				drPermitActionHistory["PermitActionDate"] = System.DateTime.Today;
				drPermitActionHistory["EmployeeIdNo"] = employeeIdNo;
				DataRow drLoginID = dsReevalDueAdmin.Employee.FindByEmployeeID(employeeIdNo);
				drPermitActionHistory["LoginID"] = drLoginID["LoginID"];
				dsPermit.Tables["PermitActionHistory"].Rows.Add(drPermitActionHistory);

				string SelectFilter = "PermitNo = '" + drv["PermitNo"].ToString() + "'";
				DataRow drPermitEmissions;
				foreach (DataRow dr2 in dsPermit.PermitEmissions.Select(SelectFilter))
				{
					drPermitEmissions = dsPermit.Tables["PermitEmissions"].NewRow();
					drPermitEmissions["PermitNo"] = newPermitNo;
					drPermitEmissions["EmissionsUnits"] = dr2["EmissionsUnits"];
					drPermitEmissions["EmissionsType"] = dr2["EmissionsType"];
					drPermitEmissions["NOx"] = dr2["NOx"];
					drPermitEmissions["ROC"] = dr2["ROC"];
					drPermitEmissions["CO"] = dr2["CO"];
					drPermitEmissions["SOx"] = dr2["SOx"];
					drPermitEmissions["PM"] = dr2["PM"];
					drPermitEmissions["PM10"] = dr2["PM10"];
					dsPermit.Tables["PermitEmissions"].Rows.Add(drPermitEmissions);
				}

				DataRow drPermitProject;
				foreach (DataRow dr2 in dsPermit.PermitProject.Select(SelectFilter))
				{
					drPermitProject = dsPermit.Tables["PermitProject"].NewRow();
					drPermitProject["PermitProjectId"] = SbcapcdOrg.PdePermit.Permit.PermitBL.GetPdeNewId(base.usrConnectionString);
					drPermitProject["PermitNo"] = newPermitNo;
					drPermitProject["ProjectNo"] = dr2["ProjectNo"];
					drPermitProject["IsInvoiceProject"] = dr2["IsInvoiceProject"];
					dsPermit.Tables["PermitProject"].Rows.Add(drPermitProject);
				}
				//InCurrentChangedDialog = true;
				////HasNewPermit = true;
				//bsPermit.ResumeBinding();
				//InCurrentChangedDialog = true;
				//GoToPermit(dr["PermitNo"]);
				//InCurrentChangedDialog = false;
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
			finally
			{
				//this.Parent.Cursor = Cursors.Default;
			}
		}

		#endregion

		private void dgvReevalDueAdmin_Sorted(object sender, EventArgs e)
		{
			SetRowColorPermitReevalDue();
		}

		private void btnAssignCompletenessEngineer_Click(object sender, EventArgs e)
		{
			IsCompletenessAssigned();
			//AssignCompletenessEngineer();
		}

		private void IsCompletenessAssigned()
		{
			DataRowView drv = (DataRowView)bsPermit.Current;
			if (drv != null)
			{

				if (drv["DocumentType"].ToString() == "Reeval" || drv["DocumentType"].ToString() == "PT-70 R")
				{
					MessageBox.Show("The assign button does not work for the permit document type associated with this permit. No assignment has been made. Please assign the completeness review engineer manually.", "No assignment.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				CompletenessAssigned = SbcapcdOrg.PdePermit.Permit.PermitBL.GetCompletenessAssigned(base.usrConnectionString, drv["PermitNo"].ToString());
				if (CompletenessAssigned == true)
				{
					if (MessageBox.Show("The Completeness Engineer is currently assigned. Do you want to override the current assignment?", "Override assignment?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						AssignCompletenessEngineer(drv);
					}
					else
					{
						return;
					}
				}
				else if (CompletenessAssigned == false)
				{
					AssignCompletenessEngineer(drv);
				}
				else
				{
					AssignCompletenessEngineer(drv);
				}
			}
		}

		private void AssignCompletenessEngineer(DataRowView drv)
		{
			NewCompletenessEmployeeNo = SbcapcdOrg.PdePermit.Permit.PermitBL.GetCompletenessEngineer(base.usrConnectionString, drv["PermitNo"].ToString());

			if (NewCompletenessEmployeeNo != null)
			{
				bool AlsoAssignIssuanceEmployee = false;

				if (drv["DocumentType"].ToString() == "DOI" || drv["DocumentType"].ToString() == "ERC Cert" || drv["DocumentType"].ToString() == "Reg" || drv["DocumentType"].ToString() == "Trn O/O")
				{
					AlsoAssignIssuanceEmployee = true;
				}
				else if (drv["PermitTypeId"].ToString() == "5" || drv["PermitTypeId"].ToString() == "8" || drv["PermitTypeId"].ToString() == "17" || drv["PermitTypeId"].ToString() == "25" || drv["PermitTypeId"].ToString() == "31")
				{
					AlsoAssignIssuanceEmployee = true;
				}
				else
				{
					DataRow findRow = dsPermitAux.FacilityList.Rows.Find(drv["FacilityNo"]);
					if (findRow["StationarySourceNo"].ToString() == "01735")
					{
						AlsoAssignIssuanceEmployee = true;
					}
				}

				if (AlsoAssignIssuanceEmployee && drv["PermitTypeId"].ToString() == "31")
				{
					NewIssuanceEmployeeNo = dsPermitAux.Tables["LandfillIssuanceEngineer"].Rows[0][0].ToString();
				}
				else
				{
					NewIssuanceEmployeeNo = NewCompletenessEmployeeNo;
				}

				object CompletenessEmployee = (dsPermitAux.PermitEngineer.Rows.Find(NewCompletenessEmployeeNo))["EngineerName"];
				object IssuanceEmployee = (dsPermitAux.PermitEngineer.Rows.Find(NewIssuanceEmployeeNo))["EngineerName"];

				if (CompletenessEmployee != null)
				{
					if (AlsoAssignIssuanceEmployee && MessageBox.Show("Do you want to assign " + CompletenessEmployee.ToString() + " as the Completeness Review Engineer and " + IssuanceEmployee.ToString() + " as the Permit Issuance Engineer? This will also automatically save changes, then email the Completeness Routing Slip and the Permit Issuance Routing Slip.", "Assign Completeness Review Engineer?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					{
						return;
					}
					else if (MessageBox.Show("Do you want to assign " + CompletenessEmployee.ToString() + " as the Completeness Review Engineer? This will also automatically save changes, then email the Completeness Routing Slip.", "Assign Completeness Review Engineer?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					{
						return;
					}

					drv["CompletenessEmployeeNo"] = NewCompletenessEmployeeNo;
					drv["RoutingSlipCompletenessSentDate"] = System.DateTime.Today;

					if (AlsoAssignIssuanceEmployee)
					{
						drv["EmployeeIdNo"] = NewCompletenessEmployeeNo;
						drv["RoutingSlipSentDate"] = System.DateTime.Today;
					}

					if (SavePermit(true))
					{
						bsPermit.ResetBindings(false);
						if (SbcapcdOrg.PdePermit.Permit.PermitBL.EmailCompletenessRoutingSlip(base.usrConnectionString, drv["PermitNo"].ToString()))
						{
							MessageBox.Show("Completeness review routing slip sent.", "Email");
							if (AlsoAssignIssuanceEmployee)
							{
								if (SbcapcdOrg.PdePermit.Permit.PermitBL.EmailRoutingSlip(base.usrConnectionString, drv["PermitNo"].ToString()))
								{
									MessageBox.Show("Permit issuance routing slip sent.", "Email");
								}
							}
						}
					}
					else
					{
						MessageBox.Show("Save error, email not sent", "Email");
					}

				}
				else
				{
					return;
				}
			}
		}

		private void chkPermitProcessDelay_Click(object sender, EventArgs e)
		{
			if (chkPermitProcessDelay.Checked)
			{
				MessageBox.Show("Enter the reason for the Permit Process Delay in the permit notes field.", "Permit Process Delay", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void lnkPermitApplicationPDF_DragDrop(object sender, DragEventArgs e)
		{
			if (PermitEditStatus != "EditMode")
			{
				MessageBox.Show("Not in edit mode. No link created.", "Not in edit mode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (CommonPdePermitMethods.IsSinglePdfFile(e) != null)
				{
					lnkPermitApplicationPDF.Tag = CommonPdePermitMethods.IsSinglePdfFile(e);
					PermitDataSetHasChanges = true;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
					OnPermitDataSetChanged(this, args);
					CheckPermitPDF();
				}
			}
		}

		private void lnkPermitApplicationPDF_DragOver(object sender, DragEventArgs e)
		{
			if (CommonPdePermitMethods.IsSinglePdfFile(e) != null && PermitEditStatus == "EditMode")
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void lnkPermitPDF_DragDrop(object sender, DragEventArgs e)
		{
			if (PermitEditStatus != "EditMode")
			{
				MessageBox.Show("Not in edit mode. No link created.", "Not in edit mode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (CommonPdePermitMethods.IsSinglePdfFile(e) != null)
				{
					lnkPermitPDF.Tag = CommonPdePermitMethods.IsSinglePdfFile(e);
					PermitDataSetHasChanges = true;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
					OnPermitDataSetChanged(this, args);
					CheckPermitPDF();
				}
			}
		}

		private void lnkPermitPDF_DragOver(object sender, DragEventArgs e)
		{
			if (CommonPdePermitMethods.IsSinglePdfFile(e) != null && PermitEditStatus == "EditMode")
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void usrPermit_VisibleChanged(object sender, EventArgs e)
		{
			CheckPermitPDF();
			CheckPermitFolder();
		}

		private void tsbtnEditPermit_Click(object sender, EventArgs e)
		{
			SetEditMode();
		}

		private void SetEditMode()
		{
			SbcapcdOrg.PdePermit.Permit.PermitBL getPermitToEdit = new PermitBL();
			PermitEditStatus = getPermitToEdit.GetPermitToEdit(base.usrConnectionString, dsPermit, PermitNo.ToString());

			if (PermitEditStatus == "NonEditMode")
			{
				MessageBox.Show("This permit is already checked out.", "Checked Out", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (PermitEditStatus == "EditMode")
			{
				PermitDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
				OnPermitDataSetChanged(this, args);
				EditModePermitNo = PermitNo.ToString();
			}
			else if (PermitEditStatus == "Error")
			{
				MessageBox.Show("Edit Mode Error", "Edit Mode Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show("Unknown Error", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			bsPermit.ResetCurrentItem();
			SetEditModeDisplay();
		}

		private void pnlPermitDisable_EnabledChanged(object sender, EventArgs e)
		{
			btnPermitApplicationPDF.Enabled = pnlPermitDisable.Enabled;
			btnPermitFolder.Enabled = pnlPermitDisable.Enabled;
			btnPermitPDF.Enabled = pnlPermitDisable.Enabled;
		}

		private void btnEditPermit_Click(object sender, EventArgs e)
		{
			SetEditMode();
		}

		private void btnRefreshPermit_Click(object sender, EventArgs e)
		{
			RefreshPermit(PermitNo.ToString());
			dsPermit.AcceptChanges();
			PermitDataSetHasChanges = false;
			SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
			OnPermitDataSetChanged(this, args);
			PermitEditStatus = "NonEditMode";
			SetEditModeDisplay();
		}

		private void RefreshPermit(string permitNo)
		{
			SbcapcdOrg.PdePermit.Permit.PermitBL getPermitToEdit = new PermitBL();
			getPermitToEdit.GetPermitRefresh(base.usrConnectionString, dsPermit, permitNo);
		}

		private void btnShowHideDescription_Click(object sender, EventArgs e)
		{
			aytPermitDesc.BringToFront();

			System.Windows.Forms.Label lblCompletenessReviewEngineerFound = (Label)this.scPermit2.Panel1.Controls.Find("lblCompletenessReviewEngineer", true).FirstOrDefault();
			System.Windows.Forms.Label lblEngineerFound = (Label)this.scPermit2.Panel1.Controls.Find("lblEngineer", true).FirstOrDefault(); 
			

			if (aytPermitDesc.Location == new System.Drawing.Point(95, 230))
			{
				aytPermitDesc.Location = new System.Drawing.Point(95, 90);
				aytPermitDesc.Size = new System.Drawing.Size(496, 450);
				//string ssss = this.lblCompletenessReviewEngineer.Text;
				lblCompletenessReviewEngineerFound.SendToBack();
				lblEngineerFound.SendToBack();
			}
			else
			{
				aytPermitDesc.Location = new System.Drawing.Point(95, 230);
				aytPermitDesc.Size = new System.Drawing.Size(496, 65);
				lblCompletenessReviewEngineerFound.BringToFront();
				lblEngineerFound.BringToFront();
			}
		}

		private void btnExpandContractNotes_Click(object sender, EventArgs e)
		{
			aytPermitNotes.BringToFront();
			System.Windows.Forms.Label lblCompletenessReviewEngineerFound = (Label)this.scPermit2.Panel1.Controls.Find("lblCompletenessReviewEngineer", true).FirstOrDefault();
			System.Windows.Forms.Label lblEngineerFound = (Label)this.scPermit2.Panel1.Controls.Find("lblEngineer", true).FirstOrDefault(); 

			if (aytPermitNotes.Location == new System.Drawing.Point(95, 300))
			{
				aytPermitNotes.Location = new System.Drawing.Point(95, 90);
				aytPermitNotes.Size = new System.Drawing.Size(496, 450);
				lblCompletenessReviewEngineerFound.SendToBack();
				lblEngineerFound.SendToBack();
			}
			else
			{
				aytPermitNotes.Location = new System.Drawing.Point(95, 300);
				aytPermitNotes.Size = new System.Drawing.Size(496, 55);
				lblCompletenessReviewEngineerFound.BringToFront();
				lblEngineerFound.BringToFront();
			}
		}

		private void usrPermit_Enter(object sender, EventArgs e)
		{
			//SbcapcdOrg.ControlLibrary.ConString.ConnectionString = base.co;
			//ConString.ConnectionString = 
			//base.ConnectionString = this.ConnectionString;
		}

		private bool CheckPermitStatusChange()
		{
			int iChangesToStatus = 0;
			DataRowView drv = (DataRowView)bsPermit.Current;
			if (drv == null)
			{
				return false;
			}
			string CurrentPermitStatus = drv["PermitStatus"].ToString();
			string NewPermitStatus = "";
			foreach (DataRow dr in dsPermit.PermitActionHistory.Select("PermitNo = '" + PermitNo + "'"))
			{
				switch ((int)dr["PermitActionId"])
				{
					case 1: // Active
						//iChangesToStatus++;
						break;
					case 2: // Withdrawn
						iChangesToStatus++;
						NewPermitStatus = "Withdrawn";
						break;
					case 9: //9	Cancelled
						iChangesToStatus++;
						NewPermitStatus = "Cancelled";
						break;
					case 12: // 12	Superseded
						iChangesToStatus++;
						NewPermitStatus = "Superseded";
						break;
					case 29: // 29	Active
						iChangesToStatus++;
						NewPermitStatus = "Active";
						break;
					case 40: // 40	Suspended
						iChangesToStatus++;
						NewPermitStatus = "Suspended";
						break;
					case 41: // 41	Denied
						iChangesToStatus++;
						NewPermitStatus = "Denied";
						break;
					default:
						break;
				}
			}

			if (drv != null && iChangesToStatus == 1 && NewPermitStatus != "Active" && PermitEditStatus != "EditMode" && PermitEditStatus != "New")
			{
				return true;
			}
			else if (iChangesToStatus == 0 && CurrentPermitStatus != "Active" && PermitEditStatus != "EditMode" && PermitEditStatus != "New")
			{
				return true;
			}

			if (drv != null && iChangesToStatus == 1 && NewPermitStatus != "Active")
			{
				return true;
			}
			else if (iChangesToStatus > 1)
			{
				return false;
			}
			else if (iChangesToStatus == 0 && CurrentPermitStatus != "Active")
			{
				return false;
			}

			return false;
		}

		private void bsPermitActionHistory_ListChanged(object sender, ListChangedEventArgs e)
		{
			//if (CheckPermitStatusChange())
			//{
			//    MessageBox.Show("Permit status will change.");
			//}
		}

		private void dgvPermitFeeHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex > -1 && dgvPermitFeeHistory.Rows[e.RowIndex].IsNewRow && e.Value == null)
			{
				dgvPermitFeeHistory.Rows[e.RowIndex].Cells["DeleteFee"].Value = bmpOneByOne;
			}
			else if (!dgvPermitFeeHistory.Rows[e.RowIndex].IsNewRow && e.Value.GetType() == typeof(System.Drawing.Bitmap) && ((System.Drawing.Bitmap)e.Value).Size.Height == 1)
			{
				dgvPermitFeeHistory.Rows[e.RowIndex].Cells["DeleteFee"].Value = imageList1.Images[21];
			}
		}

		private void dgvPermitProject_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex < 0 || e.ColumnIndex != 3 || e.RowIndex >= (dgvPermitProject.Rows.Count))
					return;

				if (!(MessageBox.Show("Do you want to delete this project?", "Delete this project?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
				{
					return;
				}

				dgvPermitProject.Rows.RemoveAt(e.RowIndex);

				PermitDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PermitDataSetHasChanges);
				OnPermitDataSetChanged(this, args);
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}

		private void dgvPermitProject_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex > -1 && dgvPermitProject.Rows[e.RowIndex].IsNewRow && e.Value == null)
			{
				dgvPermitProject.Rows[e.RowIndex].Cells["DeleteProject"].Value = bmpOneByOne;
			}
			else if (!dgvPermitProject.Rows[e.RowIndex].IsNewRow && e.Value.GetType() == typeof(System.Drawing.Bitmap) && ((System.Drawing.Bitmap)e.Value).Size.Height == 1)
			{
				dgvPermitProject.Rows[e.RowIndex].Cells["DeleteProject"].Value = imageList1.Images[21];
			}
		}

		private void usrLetters_ConString(object sender)
		{
			usrLetters.LoadLetters();
		}

		private void cmbFacilityList_SelectionChangeCommitted(object sender, EventArgs e)
		{
			NewFacilityNo = cmbFacilityList.SelectedValue.ToString();
		}

		private void tabSupersedes_Click(object sender, EventArgs e)
		{

		}

		private void dgvReevalDueAdmin_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			int i = 1;
		}

		private void bsLeadAgency_CurrentChanged(object sender, EventArgs e)
		{

		}

		private void llOpenFacilityFolder_Click(object sender, EventArgs e)
		{
			try
			{
				string sFacilityPath = CommonPdePermitMethods.GetFacilityPath(drvPermit["StationarySourceNo"].ToString(), drvPermit["FacilityNo"].ToString() );

				//if (!String.IsNullOrWhiteSpace(CommonPdePermitMethods.GetFacilityPath(drvFacility["FacilityNo"].ToString(), drvFacility["StationarySourceNo"].ToString())))
				//{
				//	System.Diagnostics.Process.Start(CommonPdePermitMethods.GetFacilityPath(drvFacility["FacilityNo"].ToString(), drvFacility["StationarySourceNo"].ToString()));
				//}

				if (!String.IsNullOrWhiteSpace(sFacilityPath) && Directory.Exists(sFacilityPath))
				{
					System.Diagnostics.Process.Start(sFacilityPath);
				}
				else
				{
					MessageBox.Show("Facility folder not found: " + sFacilityPath, "Facility folder not found.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}


		#region Update PDFs

		public void RunBwSavePermitPdfDocuments()
		{
			if (!bwUpdatePdfs.IsBusy)
			{
				bwUpdatePdfs.RunWorkerAsync();
			}			
		}

		public void SavePdfPermitDocuments()
        {
            try
            {
				SbcapcdOrg.PdePermit.Permit.PermitBL.GetFacilityPermitApplicationMapData(base.usrConnectionString, dsFacilityPermitMapData);

                foreach (DataRow drMapData in dsFacilityPermitMapData.FacilityPermitMapData.Rows)
                {
                    if (File.Exists(drMapData["ApplicationPath"].ToString()))
                    {
                        SbcapcdOrg.PdfOperations.PdfData.PdfDataBL.SavePdfDocument(usrConnectionString, DBNull.Value, drMapData["PermitNo"].ToString(), 2, Path.GetFileName(drMapData["ApplicationPath"].ToString()), File.ReadAllBytes(drMapData["ApplicationPath"].ToString()));
                    }
                }

				SbcapcdOrg.PdePermit.Permit.PermitBL.GetFacilityFinalPermitMapData(base.usrConnectionString, dsFacilityPermitMapData);

                foreach (DataRow drMapData in dsFacilityPermitMapData.FacilityPermitMapData.Rows)
                {
                    if (File.Exists(drMapData["FinalPermitPath"].ToString()))
                    {
                        SbcapcdOrg.PdfOperations.PdfData.PdfDataBL.SavePdfDocument(usrConnectionString, DBNull.Value, drMapData["PermitNo"].ToString(), 1, Path.GetFileName(drMapData["FinalPermitPath"].ToString()), File.ReadAllBytes(drMapData["FinalPermitPath"].ToString()));
                    }
                }

            }
            catch (System.Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
            }
        }

        private void bwUpdatePdfs_DoWork(object sender, DoWorkEventArgs e)
        {
			SavePdfPermitDocuments();
		}

        private void bwUpdatePdfs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message);
			}
			else if (e.Cancelled)
			{
				// Next, handle the case where the user canceled 
				// the operation.
				// Note that due to a race condition in 
				// the DoWork event handler, the Cancelled
				// flag may not have been set, even though
				// CancelAsync was called.
				//resultLabel.Text = "Canceled";
			}
			else
			{
				// Finally, handle the case where the operation 
				// succeeded.
				//resultLabel.Text = e.Result.ToString();
				//MessageBox.Show("Run Worker Completed");
			}
		}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
				RunBwSavePermitPdfDocuments();
		}

        #endregion



        //private void OpenFacilityPath(bool createPath)
        //{
        //	if (CommonPdePermitMethods.GetFacilityPath(true) != "")
        //	{
        //		System.Diagnostics.Process.Start(GetCreateFacilityPath(true));
        //	}
        //	else
        //	{
        //		MessageBox.Show("No Facility selected.");
        //	}
        //}

    }
}
