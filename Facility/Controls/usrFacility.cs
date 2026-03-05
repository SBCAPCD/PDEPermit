using System;
using System.Reflection;
using System.Globalization;
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
using System.Collections;
using System.IO;

using SbcapcdOrg.ControlLibrary;
using SbcapcdOrg.PdePermit.PdePermitComponents;
//using SbcapcdOrg.Facility.FacilityComponents;
//using SbcapcdOrg.AnnualReportTracking.Tracking;

namespace SbcapcdOrg.PdePermit.Facility
{
    public partial class usrFacility : SbcapcdOrg.ControlLibrary.usrUserControl
	{
		#region Variables

		Regex rxNumber = new Regex("[0-9]");
		Regex rxLetter = new Regex("[a-zA-Z]");
		Regex rxSpace = new Regex(" ");
		Regex rxInvalid = new Regex("[#%*[']");
		private string CompanyNo = null;
		private object oNull = null;
		private bool facilityDataSetHasChanges = false;
		private bool HasNewFacility = false;
		object PreSaveFacilityNo;
		object PreSortFacilityNo;
		private string CurrentFacilityNo;
		private string PreviousFacilityNo;
		private string CopyFromFacilityNo;
		private string CopyFromEmissionsType;
		private SbcapcdOrg.ControlLibrary.UserRoles PdePermitUserRoles = null;
		private SbcapcdOrg.PdePermit.PdePermitComponents.UserRoles PdeUserRoles = null;
		private string Entity = null;
		private object EntityNo = "00000";
		private bool IsSelectMode = false;
		private bool InCurrentChangedDialog = false;
		private string InCurrentChangedFacilityNo;
		private string FacilityFilter = "";
		private AutoCompleteStringCollection acscAddress = new AutoCompleteStringCollection();
		private AutoCompleteStringCollection acscPerson = new AutoCompleteStringCollection();
		private AutoCompleteStringCollection acscCompany = new AutoCompleteStringCollection();
		private AutoCompleteStringCollection acscStationarySource = new AutoCompleteStringCollection();
		DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
        //private bool HasNewLocationAddress = false;
		private bool HasNewContactAddress = false;
		private int FilterTicks = 0;
		private bool InFacilitySave = false;
		private bool InItemAdded = false;
		private int iNewIndex;
        public SbcapcdOrg.ControlLibrary.UserRoles AnRepUserRoles;
        //public SbcapcdOrg.ControlLibrary.UserRoles AnRepUserRoles = new SbcapcdOrg.ControlLibrary.UserRoles("Annual Reports Tracking");
        private bool FacilityLoadEnded = false;

		private DataRowView drvFacility;


		#endregion

		public usrFacility()
		{
			InitializeComponent();
			txtFilterAddress.Text = "";
			txtFilterAddress.TextChanged += new System.EventHandler(this.txtFilterAddress_TextChanged);
			lblIsSsContact.DataBindings.Add("Visible", bsFacilityContacts, "IsSsContact");

			dsFacility.FacilityGhgHistory.ColumnChanged += FacilityGhgHistory_ColumnChanged;

			dgvFacility.DataError += DgvFacility_DataError;
            dgvFacilityContacts.DataError += DgvFacilityContacts_DataError;
			dgvFacilityCompanyHistory.DataError += DgvFacilityCompanyHistory_DataError;
            dgvFacilityStationarySourceHistory.DataError += DgvFacilityStationarySourceHistory_DataError;
			dgvFacilityEmissions.DataError += DgvFacilityEmissions_DataError;
            dgvFPTE.DataError += DgvFPTE_DataError;
			dgvFNEI90.DataError += DgvFNEI90_DataError;
		}


		public bool FacilityDataSetHasChanges
		{
			get { return facilityDataSetHasChanges; }
			set { facilityDataSetHasChanges = value; }
		}

		#region LoadFacility

		public void SetFacilityUserRoles(SbcapcdOrg.ControlLibrary.UserRoles pdePermitUserRoles)
		{
			PdePermitUserRoles = pdePermitUserRoles;
			if (PdePermitUserRoles != null)
			{
				if (PdePermitUserRoles.IsAdmin)
				{
					tsbtnDeleteFacility.Enabled = PdePermitUserRoles.IsAdmin;
					tsbtnNewFacility.Enabled = PdePermitUserRoles.IsAdmin;
					tsbtnDeleteContact.Enabled = PdePermitUserRoles.IsAdmin;
					tsbtnAddNewContact.Enabled = PdePermitUserRoles.IsAdmin;
					tsbtnNewFromContact.Enabled = PdePermitUserRoles.IsAdmin;
					btnNewPerson.Enabled = PdePermitUserRoles.IsAdmin;
					btnNewAddress.Enabled = PdePermitUserRoles.IsAdmin;
					dgvFacilityCompanyHistory.AllowUserToAddRows = PdePermitUserRoles.IsAdmin;
					dgvFacilityCompanyHistory.AllowUserToDeleteRows = PdePermitUserRoles.IsAdmin;
					btnDeleteCompanyHistory.Enabled = PdePermitUserRoles.IsAdmin;
				}

				if (PdePermitUserRoles.IsContactEd)
				{
					tsbtnAddNewContact.Enabled = PdePermitUserRoles.IsContactEd;
					tsbtnNewFromContact.Enabled = PdePermitUserRoles.IsContactEd;
					btnNewPerson.Enabled = PdePermitUserRoles.IsContactEd;
					btnNewAddress.Enabled = PdePermitUserRoles.IsContactEd;
					tsbtnSaveFacility.Enabled = PdePermitUserRoles.IsContactEd;
					tsbtnUndoFacility.Enabled = PdePermitUserRoles.IsContactEd;
				}

				if (PdePermitUserRoles.IsEditor)
				{
					tsbtnSaveFacility.Enabled = PdePermitUserRoles.IsEditor;
					tsbtnUndoFacility.Enabled = PdePermitUserRoles.IsEditor;
				}

				FacilityLocation.SetLocationUserRoles(PdeUserRoles);
			}
		}

		public void SetFacilityUserRoles(SbcapcdOrg.PdePermit.PdePermitComponents.UserRoles pdeUserRoles)
		{
            PdeUserRoles = pdeUserRoles;

            if (PdeUserRoles != null)
            {
                if (PdeUserRoles.IsAdmin)
                {
                    tsbtnDeleteFacility.Enabled = PdeUserRoles.IsAdmin;
                    tsbtnNewFacility.Enabled = PdeUserRoles.IsAdmin;
                    tsbtnDeleteContact.Enabled = PdeUserRoles.IsAdmin;
                    tsbtnAddNewContact.Enabled = PdeUserRoles.IsAdmin;
                    tsbtnNewFromContact.Enabled = PdeUserRoles.IsAdmin;
                    btnNewPerson.Enabled = PdeUserRoles.IsAdmin;
                    btnNewAddress.Enabled = PdeUserRoles.IsAdmin;
                    dgvFacilityCompanyHistory.AllowUserToAddRows = PdeUserRoles.IsAdmin;
                    dgvFacilityCompanyHistory.AllowUserToDeleteRows = PdeUserRoles.IsAdmin;
                    btnDeleteCompanyHistory.Enabled = PdeUserRoles.IsAdmin;
                }

                //if (PdeUserRoles.IsContactEd)
                //{
                //	tsbtnAddNewContact.Enabled = PdeUserRoles.IsContactEd;
                //	tsbtnNewFromContact.Enabled = PdeUserRoles.IsContactEd;
                //	btnNewPerson.Enabled = PdeUserRoles.IsContactEd;
                //	btnNewAddress.Enabled = PdeUserRoles.IsContactEd;
                //	tsbtnSaveFacility.Enabled = PdeUserRoles.IsContactEd;
                //	tsbtnUndoFacility.Enabled = PdeUserRoles.IsContactEd;
                //}

                if (PdeUserRoles.IsEditor)
                {
                    tsbtnSaveFacility.Enabled = PdeUserRoles.IsEditor;
                    tsbtnUndoFacility.Enabled = PdeUserRoles.IsEditor;
                }

                FacilityLocation.SetLocationUserRoles(PdeUserRoles);
            }
        }

		public void LoadFacility()
		{
			bsFacility.SuspendBinding();
			bsFacilityContacts.SuspendBinding();
			cmbFacilityActiveFilter.SelectedItem = "Active";
			bwLoadFacility.RunWorkerAsync();
		}

		public void LoadFacilityAux()
		{
			bwLoadFacilityAux.RunWorkerAsync();
		}

		private void LoadFacility(BackgroundWorker worker, DoWorkEventArgs e)
		{
			SbcapcdOrg.PdePermit.Facility.FacilityBL getFacilityAux = new FacilityBL();
            getFacilityAux.GetPrimaryFacilityAux(base.usrConnectionString, dsFacilityAux);

            PersonFacContact.usrConnectionString = base.usrConnectionString;

            FacilityLocation.LocationType = "Facility";
            FacilityLocation.LoadLocation(); //!!!!!!!!!!
            
			AddressFacCon.LoadAddress("Facility", "Facility");
			AddressFacCon.FillCombobox(cmbAddress);
			AddressFacCon.FillCombobox(DataGridViewComboBoxColumnAddress);
			
			AddressFacCon.SetFormFixedSingle();

			bsAddressComboBox = (BindingSource)cmbAddress.DataSource;
			bsAddressDgvComboBox = (BindingSource)cmbAddress.DataSource;

            DataGridViewComboBoxColumnAddress.DataSource = (BindingSource)cmbAddress.DataSource;
            DataGridViewComboBoxColumnAddress.DisplayMember = "StreetAddressComplete";
            DataGridViewComboBoxColumnAddress.ValueMember = "AddressNo";

            SbcapcdOrg.PdePermit.Facility.FacilityBL getFacility = new FacilityBL();
            getFacility.GetFacility(base.usrConnectionString, dsFacility);

			pnlEmissionsComment.Location = new System.Drawing.Point(0, 25);

			AddressFacCon.FillAutoCompleteAddress(acscAddress);
			PersonFacContact.FillAutoCompletePerson(acscPerson);

			foreach (DataRow row in dsFacilityAux.Companies.Rows)
			{
				acscCompany.Add(row["CompanyDesc"].ToString());
			}

			foreach (DataRow row in dsFacilityAux.StationarySourceList.Rows)
			{
				acscStationarySource.Add(row["StationarySourceName"].ToString());
			}
		}

        public bool RefreshCompanies()
        {
            try
            {

                if (facilityDataSetHasChanges)
                {
                    MessageBox.Show("Save before refreshing companies!");
                    return false;
                }
                DataRowView drv = (DataRowView)bsFacilityContacts.Current;

                if (drv != null)
                {
                    object CompanyNo = drv["CompanyNo"];
                }
                else
                {
                    CompanyNo = null;
                }

                SbcapcdOrg.PdePermit.Facility.FacilityBL.GetFacilityCompanies(base.usrConnectionString, dsFacilityAux);

                cmbCompany.DataSource = dsFacilityAux.Tables["Companies"].Copy();
                cmbCompany.DisplayMember = "CompanyDesc";
                cmbCompany.ValueMember = "CompanyNo";

                foreach (DataRow row in dsFacilityAux.Companies.Rows)
                {
                    acscCompany.Add(row["CompanyDesc"].ToString());
                }

                if (CompanyNo != null)
                {
                    cmbCompany.SelectedValue = CompanyNo;
                }

                FaciltiyRejectChanges();
                return true;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Facility:RefreshCompanies");
                return false;
            }
        }

		private void LoadFacilityAux(BackgroundWorker worker, DoWorkEventArgs e)
		{
			SbcapcdOrg.PdePermit.Facility.FacilityBL getFacilityAux = new FacilityBL();
            getFacilityAux.GetSecondaryFacilityAux(base.usrConnectionString, dsFacilityAux);
		}

		private void bwLoadFacilityAux_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			LoadFacilityAux(worker, e);
		}

		private void bwLoadFacilityAux_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    //tbcFacilityHistory.Enabled = true;
				}
				catch (Exception ex)
				{
                    SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
				}
				finally
				{
				}
			}
		}

		private void bwLoadFacility_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			LoadFacility(worker, e);
		}

		private void bwLoadFacility_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
					cmbAddress.AutoCompleteCustomSource = acscAddress;
					cmbPerson.AutoCompleteCustomSource = acscPerson;
					cmbCompany.AutoCompleteCustomSource = acscCompany;

					this.PersonFacContact.OnPersonDataSetChanged += new SbcapcdOrg.Contact.usrPerson.PersonDataSetChangedEventHandler(this.PersonFacContact_OnPersonDataSetChanged);
                    FacilityLocation.LoadEnded = true;
					bsFacility.ResumeBinding();
					bsFacilityContacts.ResumeBinding();
					cmbCompany.DataSource = dsFacilityAux.Tables["Companies"].Copy();
					cmbCompany.DisplayMember = "CompanyDesc";
					cmbCompany.ValueMember = "CompanyNo";
					DataRowView drv = bsFacility.Current as DataRowView;
					if (drv != null)
					{
						SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs argsEntityCurrentChanged = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs("Facility", oNull, drv["FacilityNo"], drv["StationarySourceNo"]);
						if (OnEntityCurrentChanged != null)
						{
							OnEntityCurrentChanged(this, argsEntityCurrentChanged);
						}
					}
					dsFacility.Facility.ColumnChanged += new DataColumnChangeEventHandler(Facility_ColumnChanged);
					dsFacility.FacilityCompanyHistory.ColumnChanged += new DataColumnChangeEventHandler(FacilityCompanyHistory_ColumnChanged);
					dsFacility.FacilityStationarySourceHistory.ColumnChanged += new DataColumnChangeEventHandler(FacilityStationarySourceHistory_ColumnChanged);
					dsFacility.FacilityEmissions.ColumnChanged += new DataColumnChangeEventHandler(FacilityEmissions_ColumnChanged);
					dsFacility.FacilityContacts.ColumnChanged += new DataColumnChangeEventHandler(FacilityContacts_ColumnChanged);

					DataTable dtFacilityType = dsFacilityAux.FacilityType;
					DataRow dr = dtFacilityType.NewRow();
					dr["FacilityTypeId"] = 99;
                    dr["FacilityType"] = " All Facility Types";
					dtFacilityType.Rows.Add(dr);
					tscmbFacilityType.ComboBox.DataSource = dtFacilityType;
					tscmbFacilityType.ComboBox.DisplayMember = "FacilityType";
					tscmbFacilityType.ComboBox.ValueMember = "FacilityTypeId";
					tscmbFacilityType.SelectedIndex = 0;
					cmbEmissionsType.SelectedIndex = 0;
					bsFacilityEmissions.Filter = "EmissionsType = '" + cmbEmissionsType.SelectedItem.ToString() + "'";
					ResetFilters();
					bsFacility.ResetItem(0);
					dgvFacility.Refresh();

                    //usrAnnualReportTracking.LoadAnnualReportTrackingAux();
                    //usrAnnualReportTracking.SetAnRepYearsCmb(cmbAnRepYear);
                    //cmbAnRepYear.SelectedValue = usrAnnualReportTracking.CurrentAnRepYear;
                    //usrAnnualReportTracking.LoadAnnualReportTracking(usrAnnualReportTracking.CurrentAnRepYear);
                    //usrAnnualReportTracking.LoadAnnualReportTracking("0000");


					bsFacility.MoveFirst();

                    //AnRepUserRoles = new SbcapcdOrg.ControlLibrary.UserRoles(base.usrConnectionString, "Annual Reports Tracking");
                    //AnnualReportsTracking.AnRepUserRoles = AnRepUserRoles;
                    //AnnualReportsTracking.SetAnnualReportsTrackingNoFac();
                    //AnnualReportsTracking.FacilityCurrentChanged(CurrentFacilityNo);
					this.Cursor = Cursors.Default;
                    //MessageBox.Show("Facility load ended");
                }
                catch (Exception ex)
                {
                    SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "bwLoadFacility_RunWorkerCompleted");
                }
				finally
				{
                    facilityDataSetHasChanges = false;
                    SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
                    OnFacilityDataSetChanged(this, args);
                    FacilityLoadEnded = true;
					OnFacilityLoadEnd();
				}

			}
		}

		#endregion

		#region DataSet Changes

		void FacilityContacts_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			if (PdePermitUserRoles.IsAdmin)
				//if (PdeUserRoles.IsAdmin)
			{
				CheckForUnsavedChanges(e);
			}
		}

		void FacilityEmissions_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			//if (PdeUserRoles.IsEditor)
			if (PdePermitUserRoles.IsEditor)
			{
				CheckForUnsavedChanges(e);
			}
		}

		void FacilityStationarySourceHistory_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			if (PdePermitUserRoles.IsAdmin)
				//if (PdeUserRoles.IsAdmin)
			{
				CheckForUnsavedChanges(e);
			}
		}

		void FacilityCompanyHistory_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			if (PdePermitUserRoles.IsAdmin)
				//if (PdeUserRoles.IsAdmin)
			{
				CheckForUnsavedChanges(e);
			}
		}

		void Facility_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			if (!bsFacility.IsBindingSuspended && PdePermitUserRoles.IsAdmin)
				//if (!bsFacility.IsBindingSuspended && PdeUserRoles.IsAdmin)
			{
				CheckForUnsavedChanges(e);
			}
		}

		void FacilityGhgHistory_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			CheckForUnsavedChanges(e);
		}

		protected void CheckForUnsavedChanges(DataColumnChangeEventArgs e)
		{
			if (PdePermitUserRoles.IsEditor)
				//if (PdeUserRoles.IsEditor)
			{
				bool checkForChanges = CommonMethods.CheckForChanges(FacilityDataSetHasChanges, e);
				if (FacilityDataSetHasChanges != checkForChanges)
				{
					FacilityDataSetHasChanges = checkForChanges;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
					OnFacilityDataSetChanged(this, args);
				}
			}
		}

		protected bool CheckForChanges(DataColumnChangeEventArgs e)
		{
			string ChangingColumnName = e.Column.ToString();

			if (FacilityDataSetHasChanges || PersonFacContact.PersonDataSetHasChanges || FacilityLocation.LocationDataSetHasChanges)
			{
				return true;
			}
			else if (HasNewFacility)
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

		private void FacilityLocation_OnLocatioDataSetChanged()
		{
			FacilityDataSetHasChanges = true;
			SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
			OnFacilityDataSetChanged(this, args);
		}

        //private void AddressFacCon_OnAddressDataSetChanged(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs e)
        //{
        //    if (e.DataSetHasChanges)
        //    {
        //        HasNewContactAddress = true;
        //        FacilityDataSetHasChanges = true;
        //        SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
        //        OnFacilityDataSetChanged(this, args);
        //    }
        //}

		private void PersonFacContact_OnPersonDataSetChanged(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs e)
		{
			if (e.DataSetHasChanges)
			{
				FacilityDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
				OnFacilityDataSetChanged(this, args);
			}
		}

		public void FaciltiyRejectChanges(bool inCurrentChangedDialog)
		{
			InCurrentChangedDialog = inCurrentChangedDialog;
			FaciltiyRejectChanges();
			InCurrentChangedDialog = false;
		}

		public void FaciltiyRejectChanges()
		{
			PreSaveFacilityNo = CurrentFacilityNo;
			this.Cursor = Cursors.WaitCursor;
			FacilityDataSetHasChanges = false;
			//bsFacility.SuspendBinding();
			PersonFacContact.PersonRejectChanges();
            //AddressFacCon.AddressRejectChanges();
			FacilityLocation.LocationRejectChanges();
			dsFacility.RejectChanges();
			bsFacility.ResetBindings(false);
			bsFacilityContacts.ResetBindings(false);
			bsFacilityEmissions.ResetBindings(false);
			bsFacilityStationarySourceHistory.ResetBindings(false);
			bsFacilityCompanyHistory.ResetBindings(false);
			bsFNEI90.ResetBindings(false);
			bsFPTE.ResetBindings(false);
			bsFPTEDateLastModified.ResetBindings(false);
			FacilityDataSetHasChanges = false;
			SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
			OnFacilityDataSetChanged(this, args);
			//bsFacility.ResumeBinding();
			SetRowColor();
			this.Cursor = Cursors.Default;
			GoToFacilityAfterFilter(PreSaveFacilityNo);
		}

		#endregion

		#region Filters

		private void FilterCompliance()
		{
            //bsInspectionHistory.Filter = "FacilityNo = '" + CurrentFacilityNo + "'";
            //bsPermitHistory.Filter = "FacilityNo = '" + CurrentFacilityNo + "'";
            //bsBreakdownHistory.Filter = "FacilityNo = '" + CurrentFacilityNo + "'";
            //bsVarianceHistory.Filter = "FacilityNo = '" + CurrentFacilityNo + "'";
            //FilterNovs();
		}

		private void FilterNovs()
		{
			DataRowView drv = bsFacility.Current as DataRowView;
			if (drv != null)
			{
                //if (radFacilityNovFilter.Checked)
                //{
                //    bsNovHistory.Filter = "FacilityNo = '" + drv["FacilityNo"].ToString() + "'";
                //}
                //else if (radCompanyNovFilter.Checked)
                //{
                //    bsNovHistory.Filter = "CompanyNo = '" + drv["CompanyNo"].ToString() + "'"; // CompanyName
                //}
			}
		}

		public void ResetFilters()
		{
			PreSortFacilityNo = CurrentFacilityNo;
			InCurrentChangedDialog = true;
			Entity = null;
			EntityNo = "00000";
			IsSelectMode = false;
			CompanyNo = null;
			this.tscmbFacilityType.SelectedIndex = 0;
			this.tstbFacilityFilter.Clear();
			this.cmbFacilityActiveFilter.SelectedItem = "Active";
			tstxtAddressSearchString.Text = "";
			FilterFacility();
			GoToFacilityAfterFilter(PreSortFacilityNo);
		}

		public void SetCompanyFilter(string companyNo)
		{
			CompanyNo = companyNo;
			FilterFacility();
		}

		private void FilterFacility()
		{
            try
            {
                this.Cursor = Cursors.WaitCursor;
                InCurrentChangedDialog = true;
                PreSortFacilityNo = CurrentFacilityNo;
                if (rxInvalid.IsMatch(tstbFacilityFilter.Text))
                {
                    MessageBox.Show("Some characters in the search text are special and will not be used in the search.", "Special characteres #%*[']", MessageBoxButtons.OK);
                }

                FacilityFilter = rxInvalid.Replace(tstbFacilityFilter.Text, "");

                if (CompanyNo != null)
                {
                    #region Company Filter

                    if (tscmbFacilityType.SelectedItem != null && (int)((DataRowView)tscmbFacilityType.SelectedItem)["FacilityTypeId"] != 99)
                    {
                        #region SS Filter

                        int FacilityTypeId = (int)((DataRowView)tscmbFacilityType.SelectedItem)["FacilityTypeId"];

                        if (cmbFacilityActiveFilter.SelectedItem != null && cmbFacilityActiveFilter.SelectedItem.ToString() == "Active")
                        {
                            if (rxNumber.IsMatch(FacilityFilter) && !(rxLetter.IsMatch(FacilityFilter) || rxSpace.IsMatch(FacilityFilter)))
                            {
                                bsFacility.Filter = "CompanyNo = '" + CompanyNo + "' AND FacilityTypeId = " + FacilityTypeId + " AND FacilityNo LIKE '*" + FacilityFilter + "*' AND PermitStatus = '" + cmbFacilityActiveFilter.SelectedItem.ToString() + "'";
                            }
                            else
                            {
                                bsFacility.Filter = "CompanyNo = '" + CompanyNo + "' AND FacilityTypeId = " + FacilityTypeId + " AND FacilityName LIKE '*" + FacilityFilter.Trim() + "*' AND PermitStatus = '" + cmbFacilityActiveFilter.SelectedItem.ToString() + "'";
                            }
                        }
                        else
                        {
                            if (rxNumber.IsMatch(FacilityFilter) && !(rxLetter.IsMatch(FacilityFilter) || rxSpace.IsMatch(FacilityFilter)))
                            {
                                bsFacility.Filter = "CompanyNo = '" + CompanyNo + "' AND FacilityTypeId = " + FacilityTypeId + " AND FacilityNo LIKE '*" + FacilityFilter + "*'";
                            }
                            else
                            {
                                bsFacility.Filter = "CompanyNo = '" + CompanyNo + "' AND FacilityTypeId = " + FacilityTypeId + " AND FacilityName LIKE '*" + FacilityFilter.Trim() + "*'";
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region No SS Filter
                        if (cmbFacilityActiveFilter.SelectedItem != null && cmbFacilityActiveFilter.SelectedItem.ToString() == "Active")
                        {
                            if (rxNumber.IsMatch(FacilityFilter) && !(rxLetter.IsMatch(FacilityFilter) || rxSpace.IsMatch(FacilityFilter)))
                            {
                                bsFacility.Filter = "CompanyNo = '" + CompanyNo + "' AND FacilityNo LIKE '*" + FacilityFilter + "*' AND PermitStatus = '" + cmbFacilityActiveFilter.SelectedItem.ToString() + "'";
                            }
                            else
                            {
                                bsFacility.Filter = "CompanyNo = '" + CompanyNo + "' AND FacilityName LIKE '*" + FacilityFilter.Trim() + "*' AND PermitStatus = '" + cmbFacilityActiveFilter.SelectedItem.ToString() + "'";
                            }
                        }
                        else
                        {
                            if (rxNumber.IsMatch(FacilityFilter) && !(rxLetter.IsMatch(FacilityFilter) || rxSpace.IsMatch(FacilityFilter)))
                            {
                                bsFacility.Filter = "CompanyNo = '" + CompanyNo + "' AND FacilityNo LIKE '*" + FacilityFilter + "*'";
                            }
                            else
                            {
                                bsFacility.Filter = "CompanyNo = '" + CompanyNo + "' AND FacilityName LIKE '*" + FacilityFilter.Trim() + "*'";
                            }
                        }
                        #endregion
                    }

                    #endregion
                }
                else
                {
                    #region No Company Filter

                    if (tscmbFacilityType.SelectedItem != null && (int)((DataRowView)tscmbFacilityType.SelectedItem)["FacilityTypeId"] != 99)
                    {
                        #region SS Filter

                        int FacilityTypeId = (int)((DataRowView)tscmbFacilityType.SelectedItem)["FacilityTypeId"];

                        if (cmbFacilityActiveFilter.SelectedItem != null && cmbFacilityActiveFilter.SelectedItem.ToString() == "Active")
                        {
                            if (rxNumber.IsMatch(FacilityFilter) && !(rxLetter.IsMatch(FacilityFilter) || rxSpace.IsMatch(FacilityFilter)))
                            {
                                bsFacility.Filter = "FacilityTypeId = " + FacilityTypeId + " AND FacilityNo LIKE '*" + FacilityFilter + "*' AND PermitStatus = '" + cmbFacilityActiveFilter.SelectedItem.ToString() + "'";
                            }
                            else
                            {
                                bsFacility.Filter = "FacilityTypeId = " + FacilityTypeId + " AND FacilityName LIKE '*" + FacilityFilter.Trim() + "*' AND PermitStatus = '" + cmbFacilityActiveFilter.SelectedItem.ToString() + "'";
                            }
                        }
                        else
                        {
                            if (rxNumber.IsMatch(FacilityFilter) && !(rxLetter.IsMatch(FacilityFilter) || rxSpace.IsMatch(FacilityFilter)))
                            {
                                bsFacility.Filter = "FacilityTypeId = " + FacilityTypeId + " AND FacilityNo LIKE '*" + FacilityFilter + "*'";
                            }
                            else
                            {
                                bsFacility.Filter = "FacilityTypeId = " + FacilityTypeId + " AND FacilityName LIKE '*" + FacilityFilter.Trim() + "*'";
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region No SS Filter
                        if (cmbFacilityActiveFilter.SelectedItem != null && cmbFacilityActiveFilter.SelectedItem.ToString() == "Active")
                        {
                            if (rxNumber.IsMatch(FacilityFilter) && !(rxLetter.IsMatch(FacilityFilter) || rxSpace.IsMatch(FacilityFilter)))
                            {
                                bsFacility.Filter = "FacilityNo LIKE '*" + FacilityFilter + "*' AND PermitStatus = '" + cmbFacilityActiveFilter.SelectedItem.ToString() + "'";
                            }
                            else if (FacilityFilter.Length > 0)
                            {
                                bsFacility.Filter = "FacilityName LIKE '*" + FacilityFilter.Trim() + "*' AND PermitStatus = '" + cmbFacilityActiveFilter.SelectedItem.ToString() + "'";
                            }
                            else
                            {
                                bsFacility.Filter = "PermitStatus = '" + cmbFacilityActiveFilter.SelectedItem.ToString() + "'";
                            }
                        }
                        else
                        {
                            if (rxNumber.IsMatch(FacilityFilter) && !(rxLetter.IsMatch(FacilityFilter) || rxSpace.IsMatch(FacilityFilter)))
                            {
                                bsFacility.Filter = "FacilityNo LIKE '*" + FacilityFilter + "*'";
                            }
                            else
                            {
                                bsFacility.Filter = "FacilityName LIKE '*" + FacilityFilter.Trim() + "*'";
                            }
                        }
                        #endregion
                    }

                    #endregion
                }

                GoToFacilityAfterFilter(PreSortFacilityNo);

                SetRowColor();
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}

		public void FilterFacilitySelectMode(string entity, object entityNo, string activeAll)
		{
			Entity = entity;
			EntityNo = entityNo;
			IsSelectMode = true;

			CompanyNo = null;
			tscmbFacilityType.SelectedIndex = 0;
			tstbFacilityFilter.Clear();
			cmbFacilityActiveFilter.SelectedItem = activeAll;

			if (entityNo != null)
			{
				if (activeAll == "All")
				{
					bsFacility.Filter = entity + " = '" + entityNo.ToString() + "'";
				}
				else
				{
					bsFacility.Filter = entity + " = '" + entityNo.ToString() + "' AND PermitStatus = '" + activeAll + "'";
				}
			}

			SetRowColor();
		}

		public void FilterFacilitySelectMode(string activeAll)
		{
			CompanyNo = null;
			tscmbFacilityType.SelectedIndex = 0;
			tstbFacilityFilter.Clear();
			cmbFacilityActiveFilter.SelectedItem = activeAll;

			if (Entity != null)
			{
				if (activeAll == "All")
				{
					bsFacility.Filter = Entity + " = '" + EntityNo.ToString() + "'";
				}
				else
				{
					bsFacility.Filter = Entity + " = '" + EntityNo.ToString() + "' AND PermitStatus = '" + activeAll + "'";
				}
			}
			SetRowColor();
		}

		private void cmbFacilityActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (IsSelectMode)
			{
				FilterFacilitySelectMode(cmbFacilityActiveFilter.SelectedItem.ToString());
			}
			else
			{
				FilterFacility();
			}
		}

		private void FilterList()
		{
			DataRowView drvFac = bsFacility.Current as DataRowView;

			try
			{
				if (drvFac != null && cmbFacilityActiveFilter.SelectedIndex > -1)
				{
					if (this.cmbFacilityActiveFilter.SelectedItem != null && cmbFacilityActiveFilter.SelectedItem.ToString() == "Active")
					{
						bsPermitList.Filter = "FacilityNo = '" + drvFac["FacilityNo"].ToString() + "' AND PermitStatus = 'Active'";
					}
					else
					{
						bsPermitList.Filter = "FacilityNo = '" + drvFac["FacilityNo"].ToString() + "'";
					}
					lbxPermitList.ClearSelected();
				}
				else
				{
					bsPermitList.Filter = "FacilityNo = 'None'";
				}
			}
			catch
			{
			}
			finally
			{

			}
		}

		private void tstxtAddressSearchString_TextChanged(object sender, EventArgs e)
		{
			FilterByAddress();
		}

		public void FilterByAddress()
		{
			if (tstxtAddressSearchString.Text != "")
			{
				bsAddressSearchString.Filter = "AddressSearchString LIKE '*" + tstxtAddressSearchString.Text + "*'";

				StringBuilder sb = new StringBuilder();
				int i = 0;
				DataRowView drv;
				bsAddressSearchString.MoveFirst();
				while (i < bsAddressSearchString.Count)
				{
					drv = (DataRowView)bsAddressSearchString.Current;
					sb.Append("'" + drv["AddressNo"].ToString() + "',");
					bsAddressSearchString.MoveNext();
					i++;
				}

				string sss = sb.ToString();
				if (sb.ToString() != "")
				{
					bsFacility.Filter = "AddressNo IN (" + sb.ToString() + ")";
				}
				else
				{
					bsFacility.Filter = "AddressNo = 'xxxx'";
				}
				SetRowColor();
			}
		}

		public void StopFilterByAddress()
		{
			tstxtAddressSearchString.Text = "";
			FilterFacility();
		}

		private void cmbEmissionsType_SelectedIndexChanged(object sender, EventArgs e)
		{
			bsFacilityEmissions.Filter = "EmissionsType = '" + cmbEmissionsType.SelectedItem.ToString() + "'";
			bsDateLastModified.Filter = "EmissionsType = '" + cmbEmissionsType.SelectedItem.ToString() + "'";

			switch (cmbEmissionsType.SelectedItem.ToString())
			{
				case "FNEI90D":
					//emissionsUnitsDataGridViewTextBoxColumn.HeaderText = "FNEID";
					break;
				case "FNEI90P2":
					//emissionsUnitsDataGridViewTextBoxColumn.HeaderText = "FNEIP2";
					break;
				default:
					//emissionsUnitsDataGridViewTextBoxColumn.HeaderText = cmbEmissionsType.SelectedItem.ToString();
					break;
			}

		}

		private void radCompanyNovFilter_Click(object sender, EventArgs e)
		{
			FilterNovs();
		}

		private void txtFilterAddress_TextChanged(object sender, EventArgs e)
		{
			if (!IsSelectMode)
			{
				FilterAddressTimer.Stop();
				FilterTicks = 0;
				FilterAddressTimer.Start();
			}
		}

		private void FilterAddressTimer_Tick(object sender, EventArgs e)
		{
			FilterTicks++;
			if (FilterTicks > 3)
			{
				FilterAddressTimer.Stop();
				FilterTicks = 0;
				this.Parent.Cursor = Cursors.WaitCursor;
				bsAddressComboBox.Filter = "StreetName LIKE '*" + txtFilterAddress.Text + "*' OR AddressNumber LIKE '*" + txtFilterAddress.Text + "*' OR AddressNumber LIKE '*" + txtFilterAddress.Text + "*' OR SecondaryUnitDesignatorNumber  LIKE '*" + txtFilterAddress.Text + "*'";
				this.Parent.Cursor = Cursors.Default;
			}
		}

		private void tstbFacilityFilter_TextChanged(object sender, EventArgs e)
		{
			if (!IsSelectMode)
			{
				FilterTimer.Stop();
				FilterTicks = 0;
				FilterTimer.Start();
			}
			else if (IsSelectMode && tstbFacilityFilter.Text != "")
			{
				FilterTimer.Stop();
				FilterTicks = 0;
				FilterTimer.Start();
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			FilterTicks++;
			if (FilterTicks > 3)
			{
				FilterTimer.Stop();
				FilterTicks = 0;
				this.Parent.Cursor = Cursors.WaitCursor;
				FilterFacility();
				this.Parent.Cursor = Cursors.Default;
			}
		}

		private void tsbtnStopFilterByAddress_Click(object sender, EventArgs e)
		{
			StopFilterByAddress();
		}

		private void radFacilityNovFilter_Click(object sender, EventArgs e)
		{
			FilterNovs();
		}

		private void tscmbSourceType_SelectedIndexChanged(object sender, EventArgs e)
		{
			FilterFacility();
		}

		private void tsBtnResetFilters_Click(object sender, EventArgs e)
		{
			ResetFilters();
		}

		#endregion

		#region Delegates & Events

		private void DgvFPTE_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			ShowDataError(sender, e);
		}

		private void DgvFNEI90_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			ShowDataError(sender, e);
		}

		private void DgvFacilityContacts_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			ShowDataError(sender, e);
		}

		private void DgvFacilityStationarySourceHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			ShowDataError(sender, e);
		}

		private void DgvFacilityCompanyHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			ShowDataError(sender, e);
		}

		private void DgvFacility_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			ShowDataError(sender, e);
		}

		private void DgvFacilityEmissions_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			ShowDataError(sender, e);
		}

		private void ShowDataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			try
			{
				// Get the error that occurred
				Exception error = e.Exception;

				// Get the DataGridView control
				DataGridView grid = sender as DataGridView;

				// Get the column name where the error occurred
				string columnName = grid.Columns[e.ColumnIndex].HeaderText;

				// Display error message with column information
				MessageBox.Show($"An error occurred in column '{columnName}': {error.Message}",
								"Data Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);

				// Optionally, you can also show row information
				// string rowInfo = grid.Rows[e.RowIndex].HeaderCell.Value?.ToString() ?? e.RowIndex.ToString();

				// Mark the error as handled to prevent default error dialog
				e.ThrowException = false;
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}

		}

        
		public delegate void FacilityDataSetChangedEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs e);

		public event FacilityDataSetChangedEventHandler OnFacilityDataSetChanged;

		public delegate void EntityCurrentChangedEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs e);

		public event EntityCurrentChangedEventHandler OnEntityCurrentChanged;

		public delegate void GoToEntityEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs e);

		public event GoToEntityEventHandler OnGoToEntity;

		public delegate void NewFacilityEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityHasNewItemEventArgs e);

		public event NewFacilityEventHandler OnNewFacility;

		public delegate void FacilityLoadEndEventHandler();

		public event FacilityLoadEndEventHandler OnFacilityLoadEnd;

		#endregion

		#region Navigation

		public void GoToFacility(object facilityNo)
		{
			if (facilityNo != null)
			{
				if (bsFacility.Find("FacilityNo", facilityNo) >= 0)
				{
					bsFacility.Position = bsFacility.Find("FacilityNo", facilityNo);
				}
				else if (cmbFacilityActiveFilter.SelectedItem.ToString() == "Active")
				{
					ResetFilters();
					cmbFacilityActiveFilter.SelectedItem = "All";

					if (bsFacility.Find("FacilityNo", facilityNo) >= 0)
					{
						bsFacility.Position = bsFacility.Find("FacilityNo", facilityNo);
					}
					else
					{
						MessageBox.Show("Facility not found! The permit may exist but the filter settings may prevent finding it.", "Go To Facility", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}

				}
				else
				{
					MessageBox.Show("Facility not found! The permit may exist but the filter settings may prevent finding it.", "Go To Facility", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		public void GoToFacilityAfterFilter(object facilityNo)
    {
      if (facilityNo != null && FacilityLoadEnded)
      {
        if (bsFacility.Find("FacilityNo", facilityNo) >= 0)
        {
          bsFacility.Position = bsFacility.Find("FacilityNo", facilityNo);
          InCurrentChangedDialog = false;
        }
        else if (FacilityDataSetHasChanges)
        {
          SaveFacility(false);
        }
      }
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

		private void bsFacility_CurrentChanged(object sender, EventArgs e)
		{
            try
            {
				DataRowView drv = drvFacility = bsFacility.Current as DataRowView;
				txtFilterAddress.Text = "";
				bsAddressComboBox.RemoveFilter();

			if (drv != null)
			{
				try
				{
					SbcapcdOrg.PdePermit.Facility.FacilityBL getFacility = new FacilityBL();
					getFacility.GetFacilityRelated(base.usrConnectionString, dsFacility, drv["FacilityNo"].ToString());

					SetGhgHistoryTreeView();
					if (trvGhgHistory.Nodes.Count > 0)
					{
						trvGhgHistory.SelectedNode = trvGhgHistory.Nodes[0];
						bsFacilityGhgHistory.Filter = "FacilityYear = '" + trvGhgHistory.Nodes[0].Name + "'";
					}
					
					string sss = drv["IsPte25"].ToString();

					if (drv["IsPte25"] != DBNull.Value)
					{
						if ((bool)drv["IsPte25"])
						{
							scFacility2.Panel1.BackColor = System.Drawing.Color.DarkTurquoise;
						}
						else
						{
							scFacility2.Panel1.BackColor = System.Drawing.SystemColors.Control;
						}
					}

					if (drv["HasConfidentialInformation"] != DBNull.Value)
					{
						if ((bool)drv["HasConfidentialInformation"])
						{
							chkHasConfidentialInformation.BackColor = Color.Red;
						}
						else
						{
							chkHasConfidentialInformation.BackColor = scFacility2.Panel1.BackColor;
						}
					}
				}
				catch (Exception ex)
				{
					SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
				}

                CurrentFacilityNo = drv["FacilityNo"].ToString();

                    usrFacilityHistory.GetFacilityHistory(CurrentFacilityNo);

                    //usrFacilityHistory.SetSelectedFacility(CurrentFacilityNo, base.usrConnectionString);// = base.usrConnectionString;


                    //facilityHistory1.SelectedFacilityNo = CurrentFacilityNo;

                    //           if (tbcFacility.SelectedTab == tabAnRepTracking)
                    //           {
                    ////usrAnnualReportTrackingDisplay.SetFilterByFacility(CurrentFacilityNo);
                    //           }

                    FilterList();
                
                if (tbcFacility.SelectedTab == tabEmissions)
                {
                    if (cmbEmissionsType.SelectedItem != null)
                    {
                        bsFacilityEmissions.Filter = "EmissionsType = '" + cmbEmissionsType.SelectedItem.ToString() + "'";
                    }
                }

				if (CurrentFacilityNo == "00201")
				{
					FacilityLocation.SetVafbVisibility(true);
				}
				else
				{
					FacilityLocation.SetVafbVisibility(false);
				}

				if (drv["EmissionsComment"] == null || drv["EmissionsComment"].ToString() == "")
				{
					btnEmissionsComment.BackColor = SystemColors.Control;
				}
				else
				{
					btnEmissionsComment.BackColor = Color.Orange;
				}

				grpFillingLocation.SetGroup(drv["FillingLocation"].ToString());
				grpReportingType.SetGroup(drv["ReportingType"].ToString());
                //string sss = drv["LocationNo"].ToString();
				FacilityLocation.GoToLocation(drv["LocationNo"].ToString());
				FilterCompliance();

				SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs argsEntityCurrentChanged = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs("Facility", oNull, drv["FacilityNo"], drv["StationarySourceNo"]);

				if (OnEntityCurrentChanged != null)
				{
					OnEntityCurrentChanged(this, argsEntityCurrentChanged);
				}

				if (FacilityDataSetHasChanges && PreviousFacilityNo != CurrentFacilityNo && !InCurrentChangedDialog && PdePermitUserRoles.IsEditor)
					//if (FacilityDataSetHasChanges && PreviousFacilityNo != CurrentFacilityNo && !InCurrentChangedDialog && PdeUserRoles.IsEditor)
				{
					InCurrentChangedFacilityNo = CurrentFacilityNo;
					InCurrentChangedDialog = true;

					DialogResult dialogResult = dialogResult = MessageBox.Show("The Facility has changes. Do you want to save before continuing?" + Environment.NewLine + Environment.NewLine +
					"Yes - Save and Continue." + Environment.NewLine + Environment.NewLine +
					"No - Undo all changes since the last save and Continue",
					"Save Facility?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (dialogResult == DialogResult.Yes)
					{
						SaveFacility();
					}
					else if (dialogResult == DialogResult.No)
					{
						FaciltiyRejectChanges();
					}
					InCurrentChangedDialog = false;
				}
				PreviousFacilityNo = CurrentFacilityNo;
			}
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
            }
		}

		private void SetGhgHistoryTreeView()
		{
			trvGhgHistory.Nodes.Clear();

			foreach (DataRow drGhgYear in dsFacility.Tables["FacilityGhgHistory"].Rows)
			{
				TreeNode FacilityGhgHistoryNode = new TreeNode();
				FacilityGhgHistoryNode.Name = drGhgYear["FacilityYear"].ToString();
				FacilityGhgHistoryNode.Text = drGhgYear["FacilityYear"].ToString();
				FacilityGhgHistoryNode.Tag = drGhgYear;

				trvGhgHistory.Nodes.Add(FacilityGhgHistoryNode);
			}


			trvGhgHistory.ExpandAll();
		}

		private void lbxPermitList_DoubleClick(object sender, EventArgs e)
		{
			GoToPermit();
		}

		private void bsFacilityContacts_CurrentChanged(object sender, EventArgs e)
		{
			if (!InItemAdded)
			{
				DataRowView drv = (DataRowView)bsFacilityContacts.Current;
				if (drv != null && !InFacilitySave)
				{
					scFacility3.Panel2.Enabled = true;
					PersonFacContact.GoToPerson(drv["PersonNo"].ToString());
					AddressFacCon.GoToAddress(drv["AddressNo"].ToString());
				}
				else if (!InFacilitySave)
				{
					scFacility3.Panel2.Enabled = false;
					PersonFacContact.GoToPerson("");
					AddressFacCon.GoToAddress("");
				}
			}
		}

		private void dgvFacility_MouseDown(object sender, MouseEventArgs e)
		{
			DataRowView drv = bsFacility.Current as DataRowView;
			if (drv != null)
			{
				PreSortFacilityNo = drv["FacilityNo"];
			}
		}

		private void dgvFacility_Sorted(object sender, EventArgs e)
		{
			GoToFacilityAfterFilter(PreSortFacilityNo);
		}

		private void bsFacilityContacts_ListChanged(object sender, ListChangedEventArgs e)
		{


			if (e.ListChangedType == ListChangedType.ItemAdded)
			{
				try
				{
					InItemAdded = true;

					iNewIndex = e.NewIndex;
					bsFacilityContacts.Position = iNewIndex;

					DataRowView drv = (DataRowView)bsFacilityContacts[iNewIndex];
					if (drv != null)
					{
						object oNewIndex = drv["ContactId"];
						PersonFacContact.GoToPerson(drv["PersonNo"].ToString());
						AddressFacCon.GoToAddress("");
						//AddressFacCon.GoToAddress(drv["AddressNo"].ToString());
						//bsFacilityContacts.Position = bsFacilityContacts.Find("ContactId", oNewIndex);
					}
					else
					{
						PersonFacContact.GoToPerson("");
						AddressFacCon.GoToAddress("");
					}
				}
				catch (Exception ex)
				{
                    SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
				}
				finally
				{
					//bsFacilityContacts.Position = iNewIndex;
					InItemAdded = false;
					bsFacilityContacts.ResetBindings(false);
					dgvFacilityContacts.Refresh();
					bsFacilityContacts.MoveLast();
				}
			}
		}

		#endregion

		#region Display

		private void bsNovHistory_ListChanged(object sender, ListChangedEventArgs e)
		{
            //NovCount();
		}

		private void NovCount()
		{
            //lblNovCount.Text = "NOV Count: " + bsNovHistory.Count.ToString();
		}

		private void cmbContactType_SelectedIndexChanged(object sender, EventArgs e)
		{
            try
            {
                bsFacilityContacts.EndEdit();
                bsFacilityContacts.ResetBindings(false);
            }
            catch (Exception ex)
            {
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}

		private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
		{
            try
            {
                bsFacilityContacts.EndEdit();
                bsFacilityContacts.ResetBindings(false);
            }
            catch (Exception ex)
            {
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}

		private void cmbPerson_SelectedIndexChanged(object sender, EventArgs e)
		{
            try
            {
                bsFacilityContacts.EndEdit();
                bsFacilityContacts.ResetBindings(false);
            }
            catch (Exception ex)
            {
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}

		private void cmbAddress_SelectedIndexChanged(object sender, EventArgs e)
		{
            try
            {
                bsFacilityContacts.EndEdit();
                bsFacilityContacts.ResetBindings(false);
            }
            catch (Exception ex)
            {
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}

		private void dgvFacility_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				InCurrentChangedDialog = true;
			}
		}

		private void GetNewAddressFacCon()
		{
            //AddressFacCon.GetAddresses("Facility", "Facility");
			AddressFacCon.FillCombobox(cmbAddress);
			AddressFacCon.FillAutoCompleteAddress(acscAddress);
		}

		public void GetNewAddresses()
		{
            //GetNewAddressFacCon();
            //FacilityLocation.GetNewAddress();
		}

		public void StationarySourceListChanged(SbcapcdOrg.PdePermit.PdePermitComponents.EntityHasNewItemEventArgs e)
		{
			foreach (DataRow dr in e.EntityDataTable.Select("", "", DataViewRowState.CurrentRows))
			{
				DataRow foundRow = dsFacilityAux.StationarySourceList.Rows.Find(dr["StationarySourceNo"]);
				if (foundRow == null)
				{
					DataRow newRow = dsFacilityAux.StationarySourceList.NewRow();
					newRow["StationarySourceNo"] = dr["StationarySourceNo"];
					newRow["StationarySourceName"] = dr["StationarySourceName"];
					dsFacilityAux.StationarySourceList.Rows.Add(newRow);
				}
				else
				{
					foundRow["StationarySourceName"] = dr["StationarySourceName"];
				}
				bsStationarySourceList.ResetBindings(false);
			}
		}

		private void dgvFacilityCompanyHistory_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			try
			{
				System.Windows.Forms.ComboBox cmb;
				if (e.Control.GetType() == typeof(System.Windows.Forms.DataGridViewComboBoxEditingControl))
				{
					cmb = (ComboBox)e.Control;
					cmb.DropDownStyle = ComboBoxStyle.DropDown;
					cmb.AutoCompleteMode = AutoCompleteMode.Append;
					cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
					cmb.AutoCompleteCustomSource = acscCompany;
				}
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}

		private void dgvFacilityStationarySourceHistory_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			System.Windows.Forms.ComboBox cmb;
			if (e.Control.GetType() == typeof(System.Windows.Forms.DataGridViewComboBoxEditingControl))
			{
				cmb = (ComboBox)e.Control;
				cmb.DropDownStyle = ComboBoxStyle.DropDown;
				cmb.AutoCompleteMode = AutoCompleteMode.Append;
				cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
				cmb.AutoCompleteCustomSource = acscStationarySource;
			}
		}

		private void dgvFacilityStationarySourceHistory_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
		{
			if (e.ColumnIndex == 0 && e.Value != null && e.Value.ToString().IndexOf(@"/") < 0)
			{
				e.Value = DateTime.Parse(e.Value.ToString().Insert(4, "/").Insert(2, "/"));
				e.ParsingApplied = true;
			}
		}

		private void dgvFacilityCompanyHistory_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
		{
			if (e.ColumnIndex == 0 && e.Value != null && e.Value.ToString().IndexOf(@"/") < 0)
			{
				e.Value = DateTime.Parse(e.Value.ToString().Insert(4, "/").Insert(2, "/"));
				e.ParsingApplied = true;
			}
		}

		private void btnEmissionsComment_Click(object sender, EventArgs e)
		{
			pnlEmissionsComment.Visible = !pnlEmissionsComment.Visible;
			if (!pnlEmissionsComment.Visible)
			{
				if (txtEmissionsComment.Text == null || txtEmissionsComment.Text == "")
				{
					btnEmissionsComment.BackColor = SystemColors.Control;
				}
				else
				{
					btnEmissionsComment.BackColor = Color.Orange;
				}
			}
		}

		private void SetRowColor()
		{
			foreach (DataGridViewRow row in this.dgvFacility.Rows)
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

		public void GetNewStationarySources()
		{
			SbcapcdOrg.PdePermit.Facility.FacilityBL getNewStationarySources = new FacilityBL();
            getNewStationarySources.GetNewStationarySources(base.usrConnectionString, dsFacilityAux);
			bsStationarySourceList.ResetBindings(false);
		}

		#endregion

		#region Modify

		private void btnClearAllEmissions_Click(object sender, EventArgs e)
		{
			foreach (DataRow dr in dsFacility.FacilityEmissions.Select("FacilityNo = '" + CurrentFacilityNo + "'"))
			{
				for (int i = 4; i < 11; i++)
				{
					if (dr[i].ToString() != String.Empty)
					{
						dr[i] = DBNull.Value;
					}
				}
			}
		}

		private void dgvFacilityStationarySourceHistory_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells["FacilityStationarySourceHistoryId"].Value = SbcapcdOrg.PdePermit.Facility.FacilityBL.GetPdeNewId(base.usrConnectionString);
			e.Row.Cells["facilityNoDataGridViewTextBoxColumn2"].Value = CurrentFacilityNo;
			e.Row.Cells["FacilityStationarySourceHistoryDate"].Value = System.DateTime.Today.ToShortDateString();
			e.Row.Cells["FacilityStationarySourceHistoryDate"].Value = System.DateTime.Today.ToShortDateString();
			dgvFacilityStationarySourceHistory.EndEdit();
		}

		private void dgvFacilityCompanyHistory_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells["FacilityCompanyHistoryId"].Value = SbcapcdOrg.PdePermit.Facility.FacilityBL.GetPdeNewId(base.usrConnectionString);
			e.Row.Cells["facilityCompanyHistoryDateDataGridViewTextBoxColumn"].Value = System.DateTime.Today.ToShortDateString();
			e.Row.Cells["facilityCompanyHistoryDateDataGridViewTextBoxColumn"].Value = System.DateTime.Today.ToShortDateString();
		}

		private void tsbtnUndoFacility_Click(object sender, EventArgs e)
		{
			FaciltiyRejectChanges();
		}

		private void btDeleteFacility_Click(object sender, EventArgs e)
		{
			DataRowView drv = bsFacility.Current as DataRowView;
			object DeleteFacilityNo = null;
			if (drv != null)
			{
				DeleteFacilityNo = drv["FacilityNo"].ToString();
			}
			if (MessageBox.Show("Do you want to delete this Facility " + DeleteFacilityNo.ToString() + " ?", "Delete Facility?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (MessageBox.Show("Really? You want to delete Facility " + DeleteFacilityNo.ToString() + " ?", "Delete Facility? Really?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (MessageBox.Show("You must be serious! One more click and this Facility is history!", "Delete Facility??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						DataRow findRow = dsFacility.Facility.Rows.Find(DeleteFacilityNo);
						findRow.Delete();
						FacilityDataSetHasChanges = true;
						SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
						OnFacilityDataSetChanged(this, args);
					}
				}
			}
		}

		private void btnSaveFacility_Click(object sender, EventArgs e)
		{
			this.ParentForm.Cursor = Cursors.WaitCursor;
			dgvFPTE.Focus();
			SaveFacility();
			this.ParentForm.Cursor = Cursors.Default;
		}

		public void SaveFacility(bool inCurrentChangedDialog)
		{
			InCurrentChangedDialog = inCurrentChangedDialog;
			SaveFacility();
			InCurrentChangedDialog = false;
		}

		public void SaveFacility()
		{
			try
			{
				InFacilitySave = true;

				foreach (DataRow dr in dsFacility.Tables["FacilityContacts"].Select("EntityNo ='" + CurrentFacilityNo + "'"))
				{
                    if (dr["ContactTypeId"].ToString() == "0" || dr["PersonNo"].ToString() == "00000" || dr["AddressNo"].ToString() == "00" || dr["AddressNo"].ToString() == "0" ||  dr["ContactTypeId"].ToString() == String.Empty || dr["PersonNo"].ToString() == String.Empty || dr["AddressNo"].ToString() == String.Empty || dr["ContactTypeId"].ToString() == null || dr["PersonNo"].ToString() == null || dr["AddressNo"].ToString() == null )
					{
						tbcFacility.SelectedTab = tabContacts;
                        //DialogResult dialogResult = dialogResult = 
                        MessageBox.Show("Contact Type, Person or Address is missing from a Facility Contact" + Environment.NewLine + Environment.NewLine +
						"Fix the Contact before saving.", "Facility Contact!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        //if (dialogResult == DialogResult.Yes)
                        //{
                        //}
                        //else if (dialogResult == DialogResult.No)
                        //{
							InFacilitySave = false;
							return;
                        //}
					}

                    if ( dr["CompanyNo"].ToString() == "000000" || dr["CompanyNo"].ToString() == String.Empty || dr["CompanyNo"].ToString() == null)
                    {
                        tbcFacility.SelectedTab = tabContacts;
                        DialogResult dialogResult = dialogResult = MessageBox.Show("Company is missing from a Facility Contact" + Environment.NewLine + Environment.NewLine +
                        "Do you want to continue with the save?", "Facility Contact!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes)
                        {
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            InFacilitySave = false;
                            return;
                        }
                    }
				}

				Parent.Cursor = Cursors.WaitCursor;
				PreSaveFacilityNo = CurrentFacilityNo;
				PersonFacContact.PersonEndEdit();
				bool ResetPerson = PersonFacContact.PersonDataSetHasChanges;
				SbcapcdOrg.PdePermit.Facility.FacilityBL saveFacility = new FacilityBL();
				DbTransaction transaction = saveFacility.GetTransaction(base.usrConnectionString);

				#region IsAdmin
				if (PdePermitUserRoles.IsAdmin)
					//if (PdeUserRoles.IsAdmin)
				{
					dgvFPTE.EndEdit();
					bsFPTE.EndEdit();
					dgvFNEI90.EndEdit();
					bsFNEI90.EndEdit();
					dgvFacilityEmissions.EndEdit();
					bsFacilityEmissions.EndEdit();
					dgvFacilityStationarySourceHistory.EndEdit();
					dgvFacilityCompanyHistory.EndEdit();
					bsFacilityStationarySourceHistory.EndEdit();
					bsFacilityCompanyHistory.EndEdit();
					dgvFacilityContacts.EndEdit();
					bsFacilityContacts.EndEdit();
					bsFacility.EndEdit();
					bsFacilityGhgHistory.EndEdit();

					DataTable dtFacilityChanges = dsFacility.Facility.GetChanges();
					bool HasEmissionsChanges;

					//if (FacilityLocation.SaveLocation(PdeUserRoles.IsAdmin, transaction))
					//{
					//	if (PersonFacContact.SavePerson(PdeUserRoles.IsAdmin, transaction))
					//	{
					if (FacilityLocation.SaveLocation(PdePermitUserRoles.IsAdmin, transaction))
					{
						if (PersonFacContact.SavePerson(PdePermitUserRoles.IsAdmin, transaction))
						{
                            //if (AddressFacCon.SaveAddress(transaction))
                            //{
								if (dsFacility.GetChanges() != null && dsFacility.GetChanges().Tables.Contains("FacilityEmissions"))
								{
									HasEmissionsChanges = true;
								}
								else
								{
									HasEmissionsChanges = false;
								}

                                if (saveFacility.SaveFacility(base.usrConnectionString, dsFacility.GetChanges(), transaction))
								{
									if (HasEmissionsChanges)
									{
										lblFPTEDateLastModified.Text = System.DateTime.Today.ToShortDateString();
									}
									dsFacility.AcceptChanges();
                                    //AddressFacCon.AddressAcceptChanges();
									PersonFacContact.PersonAcceptChanges();
									FacilityLocation.LocationAcceptChanges();
									if (dtFacilityChanges != null)
									{
										SbcapcdOrg.PdePermit.PdePermitComponents.EntityHasNewItemEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityHasNewItemEventArgs(dtFacilityChanges);
										OnNewFacility(this, args);
									}
									HasNewFacility = false;
									FacilityDataSetHasChanges = false;
									SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args2 = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
									OnFacilityDataSetChanged(this, args2);
								}
								else
								{
									MessageBox.Show("Error saving.");
								}
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Error saving.");
                            //}
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

					if (ResetPerson)
					{
						string PersonNo = cmbPerson.SelectedValue.ToString();
						bsFacilityContacts.SuspendBinding();
						PersonFacContact.FillAutoCompletePerson(acscPerson);
						PersonFacContact.FillCombobox(cmbPerson);
						PersonFacContact.FillCombobox(DataGridViewComboBoxColumnPerson);
						cmbPerson.Refresh();
						bsFacilityContacts.ResumeBinding();
						//cmbPerson.SelectedValue = PersonNo;
					}
					Parent.Cursor = Cursors.Default;
				}
				#endregion

				#region IsEditorIsContactEd

				else if (PdePermitUserRoles.IsEditor && PdePermitUserRoles.IsContactEd && !PdePermitUserRoles.IsAdmin)
					//else if (PdeUserRoles.IsEditor && PdeUserRoles.IsContactEd && !PdeUserRoles.IsAdmin)
				{
					dgvFPTE.EndEdit();
					bsFPTE.EndEdit();
					dgvFNEI90.EndEdit();
					bsFNEI90.EndEdit();
					dgvFacilityContacts.EndEdit();
					bsFacilityContacts.EndEdit();
					dgvFacilityEmissions.EndEdit();
					bsFacilityEmissions.EndEdit();

					if (FacilityLocation.SaveLocation(PdePermitUserRoles.IsAdmin, transaction))
					{
						if (PersonFacContact.SavePerson(PdePermitUserRoles.IsContactEd, transaction))
						{
					//		if (FacilityLocation.SaveLocation(PdeUserRoles.IsAdmin, transaction))
					//{
					//	if (PersonFacContact.SavePerson(PdeUserRoles.IsContactEd, transaction))
					//	{
							dsFacility.Facility.RejectChanges();
							dsFacility.FacilityStationarySourceHistory.RejectChanges();
							dsFacility.FacilityCompanyHistory.RejectChanges();

                            if (saveFacility.EditorSaveFacility(base.usrConnectionString, dsFacility.GetChanges(), transaction))
							{
								FacilityLocation.LocationAcceptChanges();
								PersonFacContact.PersonAcceptChanges();
								dsFacility.FacilityEmissions.AcceptChanges();
								HasNewFacility = false;
								FacilityDataSetHasChanges = false;
								SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
								OnFacilityDataSetChanged(this, args);
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
						MessageBox.Show("Error saving.");
					}

				}

				#endregion

				#region IsEditor

					//else if (PdeUserRoles.IsEditor && !PdeUserRoles.IsAdmin)
				else if (PdePermitUserRoles.IsEditor && !PdePermitUserRoles.IsAdmin)
				{

					dgvFPTE.EndEdit();
					bsFPTE.EndEdit();
					dgvFNEI90.EndEdit();
					bsFNEI90.EndEdit();
					dgvFacilityEmissions.EndEdit();
					bsFacilityEmissions.EndEdit();
					bsFacilityGhgHistory.EndEdit();

					//if (FacilityLocation.SaveLocation(PdeUserRoles.IsAdmin, transaction))
					//{
					//	if (PersonFacContact.SavePerson(PdeUserRoles.IsAdmin, transaction))
					//	{
					if (FacilityLocation.SaveLocation(PdePermitUserRoles.IsAdmin, transaction))
					{
						if (PersonFacContact.SavePerson(PdePermitUserRoles.IsAdmin, transaction))
						{
							dsFacility.Facility.RejectChanges();
							dsFacility.FacilityContacts.RejectChanges();
							dsFacility.FacilityStationarySourceHistory.RejectChanges();
							dsFacility.FacilityCompanyHistory.RejectChanges();

                            if (saveFacility.EditorSaveFacility(base.usrConnectionString, dsFacility.GetChanges(), transaction))
							{
								FacilityLocation.LocationAcceptChanges();
								PersonFacContact.PersonAcceptChanges();
								dsFacility.FacilityEmissions.AcceptChanges();
								HasNewFacility = false;
								FacilityDataSetHasChanges = false;
								SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
								OnFacilityDataSetChanged(this, args);
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
						MessageBox.Show("Error saving.");
					}

				}

				#endregion

				#region IsContactEd
				#endregion

                //if (HasNewLocationAddress)
                //{
                //    GetNewAddressFacCon();
                //    HasNewLocationAddress = false;
                //}

                //if (HasNewContactAddress)
                //{
                //    FacilityLocation.GetNewAddress();
                //    HasNewContactAddress = false;
                //}



				if (InCurrentChangedDialog)
				{
					GoToFacilityAfterFilter(PreSaveFacilityNo);
				}
				else
				{
					GoToFacilityAfterFilter(InCurrentChangedFacilityNo);
				}
			}

			finally
			{
				InFacilitySave = false;
			}
		}

		private void tsbNewFacility_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			NewFacility();
			this.Cursor = Cursors.Default;
		}

		private void NewFacility()
		{
			InCurrentChangedDialog = true;
			bsFacility.SuspendBinding();
			bsFacility.RemoveFilter();

			string NewFacilityNo = SbcapcdOrg.PdePermit.Facility.FacilityBL.GetNewFacilityNo(base.usrConnectionString);
			string LocationNo = FacilityLocation.NewLocation("Facility", NewFacilityNo);


			DataTable NewFacilityEmissions = dsFacilityAux.NewFacilityEmissions.Copy();
			foreach (DataRow drNewFacilityEmissions in NewFacilityEmissions.Rows)
			{
				drNewFacilityEmissions["FacilityNo"] = NewFacilityNo;
			}

			dsFacility.FacilityEmissions.Merge(NewFacilityEmissions);

			DataRow dr = dsFacility.Tables["Facility"].NewRow();
			dr["FacilityNo"] = NewFacilityNo;
			dr["FacilityName"] = "New Facility " + NewFacilityNo;
			dr["LocationNo"] = LocationNo;
			dsFacility.Tables["Facility"].Rows.Add(dr);
			bsFacility.ResumeBinding();
			HasNewFacility = true;
			FacilityDataSetHasChanges = true;
			SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
			OnFacilityDataSetChanged(this, args);
			InCurrentChangedDialog = true;
			ResetFilters();
			InCurrentChangedDialog = true;
			GoToFacilityAfterFilter(NewFacilityNo);
			InCurrentChangedDialog = false;
		}

		private void tsbtnAddNewContact_Click(object sender, EventArgs e)
		{
			DataRow dr = dsFacility.Tables["FacilityContacts"].NewRow();
            dr["ContactId"] = SbcapcdOrg.Contact.ContactBL.GetNewContactId(base.usrConnectionString);
			dr["EntityNo"] = CurrentFacilityNo;
			dr["ContactTypeId"] = 0;
			dr["ContactTypeAbbrev"] = 99;
			dr["AddressNo"] = "00";
			dr["PersonNo"] = "00000";
			dr["CompanyNo"] = "000000";
			dsFacility.Tables["FacilityContacts"].Rows.Add(dr);
		}

		private void tsbtnNewFromContact_Click(object sender, EventArgs e)
		{
			DataRowView drv = bsFacilityContacts.Current as DataRowView;
			if (drv != null)
			{
				DataRow dr = dsFacility.Tables["FacilityContacts"].NewRow();
                dr["ContactId"] = SbcapcdOrg.Contact.ContactBL.GetNewContactId(base.usrConnectionString);
				dr["EntityNo"] = CurrentFacilityNo;
				dr["ContactTypeId"] = 0;
				dr["ContactTypeAbbrev"] = drv["ContactTypeAbbrev"];
				dr["AddressNo"] = drv["AddressNo"];
				dr["PersonNo"] = drv["PersonNo"];
				dr["CompanyNo"] = drv["CompanyNo"];
				dsFacility.Tables["FacilityContacts"].Rows.Add(dr);
			}
		}

		private void btnNewAddress_Click(object sender, EventArgs e)
		{
            //string NewAddressNo = AddressFacCon.NewAddress();
            //AddressFacCon.FillCombobox(cmbAddress);
            //AddressFacCon.FillCombobox(DataGridViewComboBoxColumnAddress);
            //cmbAddress.SelectedValue = NewAddressNo;
            //DataRowView drvFacilityContacts = (DataRowView)bsFacilityContacts.Current;
            //drvFacilityContacts["AddressNo"] = NewAddressNo;
            //dgvFacilityContacts.Refresh();
		}

        private void AddressFacCon_NewAddess(object sender, Address.NewAddessEventArgs e)
        {
            AddressFacCon.FillCombobox(cmbAddress);
            cmbAddress.SelectedValue = e.NewAddessNo;
            DataRowView drvFacilityContacts = (DataRowView)bsFacilityContacts.Current;
            drvFacilityContacts["AddressNo"] = e.NewAddessNo;
            bsFacilityContacts.EndEdit();
            //dgvFacilityContacts.Refresh();
        }

		private void AddressFacCon_OnAddressDisplayChanged()
		{
            //string AddressNo = cmbAddress.SelectedValue.ToString();
            //AddressFacCon.FillCombobox(cmbAddress);
            //cmbAddress.Refresh();
            //AddressFacCon.FillCombobox(DataGridViewComboBoxColumnAddress);
            //dgvFacilityContacts.Refresh();
            //cmbAddress.SelectedValue = AddressNo;
		}

		private void btnNewPerson_Click(object sender, EventArgs e)
		{
			string NewPersonNo = PersonFacContact.NewPerson();
			PersonFacContact.FillCombobox(cmbPerson);
			PersonFacContact.FillCombobox(DataGridViewComboBoxColumnPerson);
			cmbPerson.SelectedValue = NewPersonNo;
			DataRowView drvFacilityContacts = (DataRowView)bsFacilityContacts.Current;
			drvFacilityContacts["PersonNo"] = NewPersonNo;
			dgvFacilityContacts.Refresh();
		}

		private void cmbAddress_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (txtFilterAddress.Text != "")
			{
				string AddressNo = cmbAddress.SelectedValue.ToString();
				cmbAddress.Enabled = false;
				txtFilterAddress.Text = "";
				bsAddressComboBox.RemoveFilter();
				cmbAddress.Enabled = true;
				cmbAddress.SelectedValue = AddressNo;
			}
			AddressFacCon.GoToAddress(cmbAddress.SelectedValue.ToString());
		}

		private void cmbPerson_SelectionChangeCommitted(object sender, EventArgs e)
		{
			PersonFacContact.GoToPerson(cmbPerson.SelectedValue.ToString());
		}

		private void dgvFacilityCompanyHistory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvFacilityCompanyHistory.CurrentRow != null)
			{
				DataRowView drvCurrentRow = (DataRowView)bsFacilityCompanyHistory.Current;
				DateTime dateResult;
				if (drvCurrentRow["CompanyNo"] != null && drvCurrentRow["CompanyNo"] != System.DBNull.Value && drvCurrentRow["FacilityCompanyHistoryDate"] != null && DateTime.TryParse(drvCurrentRow["FacilityCompanyHistoryDate"].ToString(), out dateResult))
				{
					drvCurrentRow.EndEdit();
					dgvFacilityCompanyHistory.EndEdit();
					bsFacilityCompanyHistory.EndEdit();
					DateTime dt = DateTime.Today.AddDays(-9125);
					object CompanyNo = null;
					foreach (DataRowView drv in bsFacilityCompanyHistory)
					{
						if ((DateTime)drv["FacilityCompanyHistoryDate"] > dt)
						{
							dt = (DateTime)drv["FacilityCompanyHistoryDate"];
							CompanyNo = drv["CompanyNo"];
						}
					}

					bsFacility.Position = bsFacility.Find("FacilityNo", CurrentFacilityNo);
					DataRowView drv2 = (DataRowView)bsFacility.Current;
					drv2["CompanyNo"] = CompanyNo;
					//DataRow dr = dsFacilityAux.Companies.Rows.Find(drv2["CompanyNo"]);
					DataRow[] foundRows = dsFacilityAux.Companies.Select("CompanyNo = '" + CompanyNo.ToString() + "'");

					if (foundRows.Length == 1)
					{
						drv2["CompanyName"] = foundRows[0]["CompanyDesc"];
					}
					else
					{
						drv2["CompanyName"] = "";
					}

					bsFacility.EndEdit();
					FacilityDataSetHasChanges = true;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
					OnFacilityDataSetChanged(this, args);
				}
			}
		}

		private void dgvFacilityStationarySourceHistory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvFacilityStationarySourceHistory.CurrentRow != null)
			{
				DataRowView drvCurrentRow = (DataRowView)bsFacilityStationarySourceHistory.Current;
				DateTime dateResult;
				if (drvCurrentRow["StationarySourceNo"] != null && drvCurrentRow["StationarySourceNo"] != System.DBNull.Value && drvCurrentRow["FacilityStationarySourceHistoryDate"] != null && DateTime.TryParse(drvCurrentRow["FacilityStationarySourceHistoryDate"].ToString(), out dateResult))
				{
					drvCurrentRow.EndEdit();
					dgvFacilityStationarySourceHistory.EndEdit();
					bsFacilityStationarySourceHistory.EndEdit();
					DateTime dt = DateTime.Today.AddDays(-9125);
					object StationarySourceNo = null;
					foreach (DataRowView drv in bsFacilityStationarySourceHistory)
					{
						if ((DateTime)drv["FacilityStationarySourceHistoryDate"] > dt)
						{
							dt = (DateTime)drv["FacilityStationarySourceHistoryDate"];
							StationarySourceNo = drv["StationarySourceNo"];
						}
					}
					bsFacility.Position = bsFacility.Find("FacilityNo", CurrentFacilityNo);
					DataRowView drv2 = (DataRowView)bsFacility.Current;
					drv2["StationarySourceNo"] = StationarySourceNo;
					DataRow dr = dsFacilityAux.StationarySourceList.Rows.Find(drv2["StationarySourceNo"]);
					drv2["StationarySourceName"] = dr["StationarySourceName"];
					bsFacility.EndEdit();
					FacilityDataSetHasChanges = true;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
					OnFacilityDataSetChanged(this, args);
				}
			}
		}

		private void dgvFacilityCompanyHistory_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
		{
			FacilityCompanyHistoryRowDeleted();
		}

		private void FacilityCompanyHistoryRowDeleted()
		{
			if (bsFacilityCompanyHistory.Count > 0)
			{
				//DateTime dt = DateTime.Today.AddDays(-9125);
				DateTime dt = Convert.ToDateTime ("01/01/1950");
				object CompanyNo = null;
				foreach (DataRowView drv in bsFacilityCompanyHistory)
				{
					if ((DateTime)drv["FacilityCompanyHistoryDate"] > dt)
					{
						dt = (DateTime)drv["FacilityCompanyHistoryDate"];
						CompanyNo = drv["CompanyNo"];
					}
				}

				bsFacility.Position = bsFacility.Find("FacilityNo", CurrentFacilityNo);
				DataRowView drv2 = (DataRowView)bsFacility.Current;
				drv2["CompanyNo"] = CompanyNo;
				//DataRow dr = dsFacilityAux.Companies.Rows.Find(drv2["CompanyNo"]);
				//drv2["CompanyName"] = dr["CompanyDesc"];
				bsFacility.EndEdit();
				FacilityDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
				OnFacilityDataSetChanged(this, args);
			}
			else
			{
				bsFacility.Position = bsFacility.Find("FacilityNo", CurrentFacilityNo);
				DataRowView drv2 = (DataRowView)bsFacility.Current;
				drv2["CompanyNo"] = DBNull.Value;
				drv2["CompanyName"] = DBNull.Value;
				bsFacility.EndEdit();
				FacilityDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
				OnFacilityDataSetChanged(this, args);
			}
		}

		private void dgvFacilityStationarySourceHistory_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
		{
			FacilityStationarySourceHistoryRowDeleted();
		}

		private void FacilityStationarySourceHistoryRowDeleted()
		{
			if (bsFacilityStationarySourceHistory.Count > 0)
			{
				DateTime dt = Convert.ToDateTime("01/01/1950");
				object StationarySourceNo = null;
				foreach (DataRowView drv in bsFacilityStationarySourceHistory)
				{
					if ((DateTime)drv["FacilityStationarySourceHistoryDate"] > dt)
					{
						dt = (DateTime)drv["FacilityStationarySourceHistoryDate"];
						StationarySourceNo = drv["StationarySourceNo"];
					}
				}
				bsFacility.Position = bsFacility.Find("FacilityNo", CurrentFacilityNo);
				DataRowView drv2 = (DataRowView)bsFacility.Current;
				drv2["StationarySourceNo"] = StationarySourceNo;
				DataRow dr = dsFacilityAux.StationarySourceList.Rows.Find(drv2["StationarySourceNo"]);
				drv2["StationarySourceName"] = dr["StationarySourceName"];
				bsFacility.EndEdit();
				FacilityDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
				OnFacilityDataSetChanged(this, args);
			}
			else
			{
				bsFacility.Position = bsFacility.Find("FacilityNo", CurrentFacilityNo);
				DataRowView drv2 = (DataRowView)bsFacility.Current;
				drv2["StationarySourceNo"] = DBNull.Value;
				drv2["StationarySourceName"] = DBNull.Value;
				bsFacility.EndEdit();
				FacilityDataSetHasChanges = true;
				SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
				OnFacilityDataSetChanged(this, args);
			}
		}

		private void tsbtnDeleteContact_Click(object sender, EventArgs e)
		{
			if ((MessageBox.Show("Do you want to delete the current Facility Contact?", "Delete Facility Contact?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				DataRowView drv = bsFacilityContacts.Current as DataRowView;
				object DeleteContactId = null;
				if (drv != null)
				{
					DeleteContactId = drv["ContactId"].ToString();
				}
				else
				{
					MessageBox.Show("No Contact.", "Delete Contact?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (MessageBox.Show("Do you want to delete the current Facility Contact", "Delete Facility Contact?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					DataRow findRow = dsFacility.FacilityContacts.Rows.Find(DeleteContactId);
					findRow.Delete();
					FacilityDataSetHasChanges = true;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
					OnFacilityDataSetChanged(this, args);
				}
			}
		}

		private void btnDeleteStationarySourceHistory_Click(object sender, EventArgs e)
		{
			if ((MessageBox.Show("Do you want to delete the current Stationary Source History?", "Delete Stationary Source History?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{

				DataRowView drv = bsFacilityStationarySourceHistory.Current as DataRowView;
				if (drv == null)
				{
					MessageBox.Show("No Stationary Source History.", "Delete Stationary Source History?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (MessageBox.Show("Are you sure you want to delete the current Stationary Source History", "Delete Stationary Source History?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					this.Parent.Cursor = Cursors.WaitCursor;
					bsFacilityStationarySourceHistory.RemoveCurrent();
					bsFacilityStationarySourceHistory.EndEdit();
					FacilityStationarySourceHistoryRowDeleted();
					FacilityDataSetHasChanges = true;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
					OnFacilityDataSetChanged(this, args);
					this.Parent.Cursor = Cursors.Default;
				}
			}
		}

		private void btnDeleteCompanyHistory_Click(object sender, EventArgs e)
		{
			if ((MessageBox.Show("Do you want to delete the current Company History?", "Delete Company History?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{

				DataRowView drv = bsFacilityCompanyHistory.Current as DataRowView;
				if (drv == null)
				{
					MessageBox.Show("No Company History?.", "Delete Company History?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (MessageBox.Show("Are you sure you want to delete the current Company History", "Delete Company History?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					this.Parent.Cursor = Cursors.WaitCursor;
					bsFacilityCompanyHistory.RemoveCurrent();
					bsFacilityCompanyHistory.EndEdit();
					FacilityCompanyHistoryRowDeleted();
					FacilityDataSetHasChanges = true;
					SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
					OnFacilityDataSetChanged(this, args);
					this.Parent.Cursor = Cursors.Default;
				}
			}
		}

		#endregion

		#region CopyPaste

		public void PastePpteToFpte(string facilityNo, BindingSource bsPpte)
		{
			int i = 0;
			DataRowView drv = null;

			object[] find = new object[3];
			find[0] = facilityNo;
			find[1] = "FPTE";

			bsPpte.MoveFirst();
			while (i < bsPpte.Count)
			{
				drv = (DataRowView)bsPpte.Current;

				find[2] = drv["EmissionsUnits"];
				DataRow foundRow = dsFacility.FacilityEmissions.Rows.Find(find);

				if (foundRow != null)
				{
					foundRow["NOx"] = drv["NOx"];
					foundRow["ROC"] = drv["ROC"];
					foundRow["CO"] = drv["CO"];
					foundRow["SOx"] = drv["SOx"];
					foundRow["PM"] = drv["PM"];
					foundRow["PM10"] = drv["PM10"];
					foundRow["PM25"] = drv["PM25"];
				}

				bsPpte.MoveNext();
				i++;
			}
			tbcFacility.SelectedTab = tabEmissions;
			GoToFacilityAfterFilter(facilityNo);
		}

		private void btnCopyFPTE_Click(object sender, EventArgs e)
		{
			CopyFromFacilityNo = CurrentFacilityNo;
			CopyFromEmissionsType = "FPTE";
		}

		private void btnCopyFNEI90_Click(object sender, EventArgs e)
		{
			CopyFromFacilityNo = CurrentFacilityNo;
			CopyFromEmissionsType = "FNEI90";
		}

		private void btnCopyFacilityEmissions_Click(object sender, EventArgs e)
		{
			CopyFromFacilityNo = CurrentFacilityNo;
			CopyFromEmissionsType = cmbEmissionsType.SelectedItem.ToString();
		}

		private void btnPasteToFPTE_Click(object sender, EventArgs e)
		{
			PasteEmissionsGrid("FPTE");
		}

		private void btnPasteToFNEI90_Click(object sender, EventArgs e)
		{
			PasteEmissionsGrid("FNEI90");
		}

		private void btnPasteFacilityEmissions_Click(object sender, EventArgs e)
		{
			PasteEmissionsGrid(cmbEmissionsType.SelectedItem.ToString());
		}

		private void PasteEmissionsGrid(string toEmissionsType)
		{
			object[] find = new object[3];
			string SelectFilter = "FacilityNo = '" + CopyFromFacilityNo + "' AND EmissionsType = '" + CopyFromEmissionsType + "'";
			find[0] = CurrentFacilityNo;
			find[1] = toEmissionsType;

			foreach (DataRow dr in dsFacility.FacilityEmissions.Select(SelectFilter))
			{
				find[2] = dr["EmissionsUnits"];
				DataRow foundRow = dsFacility.FacilityEmissions.Rows.Find(find);
				if (foundRow != null)
				{
					foundRow["NOx"] = dr["NOx"];
					foundRow["ROC"] = dr["ROC"];
					foundRow["CO"] = dr["CO"];
					foundRow["SOx"] = dr["SOx"];
					foundRow["PM"] = dr["PM"];
					foundRow["PM10"] = dr["PM10"];
					foundRow["PM25"] = dr["PM25"];
				}
			}
		}

		private void CopyDataGridViewToClipBoard(System.Windows.Forms.DataGridView dgv)
		{
			dgv.SelectAll();
			Clipboard.SetDataObject(dgv.GetClipboardContent());
			dgv.ClearSelection();
		}

		private void tsmiCopySelectedToClipboard_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(dgvFacility.GetClipboardContent());
		}

		private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyDataGridViewToClipBoard(dgvFacility);
		}

		private void tsmiCopyFpteToClipboard_Click(object sender, EventArgs e)
		{
			dgvFPTE.SelectAll();
			Clipboard.SetDataObject(dgvFPTE.GetClipboardContent());
			dgvFPTE.ClearSelection();

			//IDataObject iData = Clipboard.GetDataObject();
			//string[] ss = iData.SetData(.GetFormats();

			//string sss = ss[0];
		}

		private void tsmiCopyFnei90ToClipboard_Click(object sender, EventArgs e)
		{
			dgvFNEI90.SelectAll();
			Clipboard.SetDataObject(dgvFNEI90.GetClipboardContent());
			dgvFNEI90.ClearSelection();
		}

		private void tsmiCopyFacilityEmissionsToClipboard_Click(object sender, EventArgs e)
		{
			dgvFacilityEmissions.SelectAll();
			Clipboard.SetDataObject(dgvFacilityEmissions.GetClipboardContent());
			dgvFacilityEmissions.ClearSelection();
		}

		private void copyToClipBoardToolStripMenuItem1_Click(object sender, EventArgs e)
		{
            //CopyDataGridViewToClipBoard(dgvNovHistory);
		}

		private void copyToClipBoardToolStripMenuItem2_Click(object sender, EventArgs e)
		{
            //CopyDataGridViewToClipBoard(dgvInspectionHistory);
		}

		private void copyToClipBoardToolStripMenuItem3_Click(object sender, EventArgs e)
		{
            //CopyDataGridViewToClipBoard(dgvPermitHistory);
		}

		private void copyToClipBoardToolStripMenuItem4_Click(object sender, EventArgs e)
		{
            //CopyDataGridViewToClipBoard(dgvBreakdownHistory);
		}

		private void copyToClipBoardToolStripMenuItem5_Click(object sender, EventArgs e)
		{
            //CopyDataGridViewToClipBoard(dgvVarianceHistory);
		}

		public delegate void CopyFacilityLocationEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.CopyLocationEventArgs e);

		public event CopyFacilityLocationEventHandler OnCopyFacilityLocation;

		private void btnCopyFacLocToSSourceLoc_Click(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)bsFacility.Current;
			if (drv["StationarySourceNo"] != null || drv["StationarySourceNo"].ToString() != string.Empty)
			{
				System.Windows.Forms.BindingSource bsFacilityLocation = new System.Windows.Forms.BindingSource();

				SbcapcdOrg.PdePermit.PdePermitComponents.CopyLocationEventArgs argsCopyFacilityLocation = new SbcapcdOrg.PdePermit.PdePermitComponents.CopyLocationEventArgs(drv["StationarySourceNo"], FacilityLocation.GetLocationBS());
				if (OnCopyFacilityLocation != null)
				{
					OnCopyFacilityLocation(this, argsCopyFacilityLocation);
				}
			}
			else
			{
				MessageBox.Show("Copy Location Failed! StationarySourceNo is not valid.", "Copy Location Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void PasteLocation(DataRow dr)
		{
			string NewLocationNo = FacilityLocation.PasteLocation(dr);
			DataRowView drv = bsFacility.Current as DataRowView;
			if (drv != null)
			{
				drv["LocationNo"] = NewLocationNo;
			}
		}

		#endregion

		private void tbcFacility_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			
			
			
			
			
			
			
			int I = 3;
			//if (tbcFacility.SelectedTab == tabAnRepTracking)
			//{
			//	this.Cursor = Cursors.WaitCursor;
			//	//usrAnnualReportTrackingDisplay.SetFilterByFacility(CurrentFacilityNo);
			//	this.Cursor = Cursors.Default;
			//}			
		}

		public void ChangeHistoryTab()
		{
			if (tbcFacility.SelectedTab == tabComplianceHistory)
			{
				tbcFacility.SelectedTab = tabFacility;
			}	
		}

		private void dgvFacilityContacts_SelectionChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)bsFacilityContacts.Current;
		}

        private void btnPasteFromWord_Click(object sender, EventArgs e)
        {

        }

        private void dgvNovHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (IsANonHeaderLinkCell(e, dgvNovHistory))
            //{
            //    OpenNovPdfLink(e);
            //}
            //else 
            //{
            //    //PopulateSales(e);
            //}

        }

        private void OpenNovPdfLink(DataGridViewCellEventArgs e)
        {
            //object linkValue = dgvNovHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
         
            //if (linkValue is DBNull) { return; }

            //if (linkValue.ToString() != null && linkValue.ToString() != string.Empty && File.Exists(linkValue.ToString()))
            //{
            //    System.Diagnostics.Process.Start(linkValue.ToString());
            //}
            //else
            //{

            //}
        }

        private bool IsANonHeaderLinkCell(DataGridViewCellEventArgs cellEvent, DataGridView dgv)
        {
            if (dgv.Columns[cellEvent.ColumnIndex] is
                DataGridViewLinkColumn &&
                cellEvent.RowIndex != -1)
            { return true; }
            else { return false; }
        }

        private void dgvInspectionHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (IsANonHeaderLinkCell(e, dgvInspectionHistory))
            //{
            //    OpenInspectionPdfLink(e);
            //}
            //else
            //{
            //    //PopulateSales(e);
            //}
        }

        private void OpenInspectionPdfLink(DataGridViewCellEventArgs e)
        {
            //object linkValue = dgvInspectionHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            //if (linkValue is DBNull) { return; }

            //if (linkValue.ToString() != null && linkValue.ToString() != string.Empty && File.Exists(linkValue.ToString()))
            //{
            //    System.Diagnostics.Process.Start(linkValue.ToString());
            //}
            //else
            //{

            //}
        }

        private void PersonFacContact_ConString(object sender)
        {
            PersonFacContact.LoadPerson("Facility");
            PersonFacContact.FillCombobox(cmbPerson);
            PersonFacContact.FillCombobox(DataGridViewComboBoxColumnPerson);
            PersonFacContact.SetFormFixedSingle();
        }

        private void AnnualReportsTracking_ConString(object sender)
        {
			//usrAnnualReportTrackingDisplay.LoadAnnualReportTracking();
        }

        private void cmbAnRepYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //usrAnnualReportTracking.LoadAnnualReportTracking(cmbAnRepYear.SelectedValue.ToString());
            //usrAnnualReportTracking.SetFilterByFacility(CurrentFacilityNo);
        }

        private void AddressFacCon_AddressSaved(object sender, DataChangedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string AddressNo = cmbAddress.SelectedValue.ToString();
            AddressFacCon.FillCombobox(cmbAddress);
            AddressFacCon.FillAutoCompleteAddress(acscAddress);
            cmbAddress.AutoCompleteCustomSource = acscAddress;
            cmbAddress.Refresh();
            cmbAddress.SelectedValue = AddressNo;
            this.Cursor = Cursors.Default;
        }

        private void btnPasteSourceLocation_Click(object sender, EventArgs e)
        {
            

            DataRowView drv = (DataRowView)bsFacility.Current;
            if (drv["StationarySourceNo"] != null || drv["StationarySourceNo"].ToString() != string.Empty)
            {
                System.Windows.Forms.BindingSource bsFacilityLocation = new System.Windows.Forms.BindingSource();

                SbcapcdOrg.PdePermit.PdePermitComponents.CopyLocationEventArgs argsCopyFacilityLocation = new SbcapcdOrg.PdePermit.PdePermitComponents.CopyLocationEventArgs(drv["StationarySourceNo"], FacilityLocation.GetLocationBS());
                if (OnCopyFacilityLocation != null)
                {
                    OnCopyFacilityLocation(this, argsCopyFacilityLocation);
                }
            }
            else
            {
                MessageBox.Show("Copy Location Failed! StationarySourceNo is not valid.", "Copy Location Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void trvGhgHistory_AfterSelect(object sender, TreeViewEventArgs e)
		{
			bsFacilityGhgHistory.Filter = "FacilityYear = '" + e.Node.Name + "'";
		}

		private void llFacility_Click(object sender, EventArgs e)
		{
			try
			{
				string sGetFacilityPath = CommonPdePermitMethods.GetFacilityPath(drvFacility["StationarySourceNo"].ToString(), drvFacility["FacilityNo"].ToString());

				//if (!String.IsNullOrWhiteSpace(CommonPdePermitMethods.GetFacilityPath(drvFacility["FacilityNo"].ToString(), drvFacility["StationarySourceNo"].ToString())))
				//{
				//	System.Diagnostics.Process.Start(CommonPdePermitMethods.GetFacilityPath(drvFacility["FacilityNo"].ToString(), drvFacility["StationarySourceNo"].ToString()));
				//}

				if (!String.IsNullOrWhiteSpace(sGetFacilityPath) && Directory.Exists(sGetFacilityPath))
				{
					System.Diagnostics.Process.Start(sGetFacilityPath);
				}
				else
				{
					MessageBox.Show("Facility folder not found: " + sGetFacilityPath, "Facility folder not found.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}

		private void btnCreateStandardFailityFolders_Click(object sender, EventArgs e)
		{
			if(Directory.Exists(CommonPdePermitMethods.GetFacilityPath(drvFacility["StationarySourceNo"].ToString(), drvFacility["FacilityNo"].ToString())))
			{
				MessageBox.Show("Facility folder already exist.");
				return;
			}

			if(drvFacility != null && CommonPdePermitMethods.CreateStandardFoldersBySsidFid(drvFacility["StationarySourceNo"].ToString(), drvFacility["FacilityNo"].ToString()))
			{
				MessageBox.Show("New standard folders created.");
			}
			else
			{
				MessageBox.Show("Error creating folders.");
			}
		}

        private void dgvFacilityContacts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
			try
			{
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}

        private void dgvFacilityContacts_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
			try
			{
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}

        private void dgvFacilityContacts_EditModeChanged(object sender, EventArgs e)
        {
			try
			{
			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
			}
		}

        private void dgvFacilityContacts_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
			int I = 3;
		}

        private void tbcFacility_TabIndexChanged(object sender, EventArgs e)
        {
			int I = 3;
		}

        private void bsFacilityContacts_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
			int i = 5;
        }
    }
}
