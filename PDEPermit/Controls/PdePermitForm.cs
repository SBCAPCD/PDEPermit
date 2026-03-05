using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

using Microsoft.Practices.EnterpriseLibrary.Data.Sql;



using SbcapcdOrg.PdePermit.PdePermitComponents;

namespace SbcapcdOrg.PdePermit.Forms
{
	public partial class PDEPermit : SbcapcdOrg.ControlLibrary.frmChildForm
	{
		private string DeselectTab;
		private string SelectingTab;
		private string StationarySourceCurrentSSID;
		private string FacilityCurrentSSID;
		private string PermitCurrentSSID;
		private string FacilityCurrentFID;
		private string PermitCurrentFID;
		private string PermitCurrentPermitNo;
		private bool StationarySourceDataSetHasChanges;
		private bool FacilityDataSetHasChanges;
		private bool PermitDataSetHasChanges;
		private SbcapcdOrg.ControlLibrary.UserRoles PdePermitUserRoles;
		private SbcapcdOrg.PdePermit.PdePermitComponents.UserRoles PdeUserRoles = null;
        private bool FacilityLoadEnd = false;
        private bool ShowClosingNonSaveDialog { get; set; }

		public PDEPermit()
		{
			InitializeComponent();
			//PdeUserRoles = new PdePermitComponents.UserRoles(base.frmConnectionString);
			PdePermitUserRoles = new SbcapcdOrg.ControlLibrary.UserRoles(base.frmConnectionString, "PdePermit");
            Permit.OnPermitLoadEnd += new PdePermit.Permit.usrPermit.PermitLoadEndEventHandler(Permit_OnPermitLoadEnd);
            //Device.OnGoToEntity += new PdePermit.Device.usrDevice.GoToEntityEventHandler(Device_OnGoToEntity);

            this.ShowIcon = false;
            this.WindowState = FormWindowState.Normal;
            ShowClosingNonSaveDialog = true;
		}

        void Permit_OnPermitLoadEnd()
        {
            this.ShowIcon = true;
            this.WindowState = FormWindowState.Maximized;
            timer1.Stop();
            timer1.Enabled = false;
            lblUnsavedChanges.Text = "";
            tbcPdePermit.Focus();
        }

        public PDEPermit(SbcapcdOrg.ControlLibrary.UserRoles pdePermitUserRoles)
        {
            InitializeComponent();
        }

		private void PDEPermit_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            lblUnsavedChanges.Text = "Loading...";
			timer1.Start();

            grpSelectMode.Focus();

            //this.ShowIcon = true;

            //Application.DoEvents();

			SbcapcdOrg.PdePermit.Forms.PdePermitFormsBL getPdePermitFormsAux = new PdePermitFormsBL();
            getPdePermitFormsAux.GetPdePermitFormsAux(base.frmConnectionString, dsPdePermitFormsAux);

			Hashtable ApplicationParametersHT = SbcapcdOrg.PdePermit.Forms.PdePermitFormsBL.GetApplicationParameters(base.frmConnectionString, "PDEPermit");
			StationarySource.SetHashtable(ApplicationParametersHT);

            FilterCompanies();

			Facility.SetFacilityUserRoles(PdePermitUserRoles);
			//Facility.SetFacilityUserRoles(PdeUserRoles);
            Facility.LoadFacility();

			StationarySource.SetStationarySourceUserRoles(PdePermitUserRoles);
			//StationarySource.SetStationarySourceUserRoles(PdeUserRoles);
			StationarySource.LoadStationarySource();

			Permit.SetPermitUserRoles(PdePermitUserRoles);
			//Permit.SetPermitUserRoles(PdeUserRoles);
			Permit.LoadPermit();

            cmbCompanyFilter.SelectedIndex = -1;

            //this.WindowState = FormWindowState.Maximized;
            //tbcPdePermit.Focus();
		}

		private void LoadPdePermit()
		{
            lblUnsavedChanges.Text = "Loading...";
            
            Facility.SetFacilityUserRoles(PdePermitUserRoles);
            Facility.LoadFacility();

			SbcapcdOrg.PdePermit.Forms.PdePermitFormsBL getPdePermitFormsAux = new PdePermitFormsBL();
            getPdePermitFormsAux.GetPdePermitFormsAux(base.frmConnectionString, dsPdePermitFormsAux);

			Hashtable ApplicationParametersHT = SbcapcdOrg.PdePermit.Forms.PdePermitFormsBL.GetApplicationParameters(base.frmConnectionString, "PDEPermit");
			StationarySource.SetHashtable(ApplicationParametersHT);

			FilterCompanies();

			StationarySource.SetStationarySourceUserRoles(PdePermitUserRoles);
			StationarySource.LoadStationarySource();

			Permit.SetPermitUserRoles(PdePermitUserRoles);
			Permit.LoadPermit();

			tbcPdePermit.Focus();
		}

		private void PDEPermit_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.DoEvents();

			Facility.ChangeHistoryTab();

			Application.DoEvents();

			if (StationarySourceDataSetHasChanges && PdePermitUserRoles.IsAdmin)
			{
                ShowClosingNonSaveDialog = false;

				if (StationarySourceDataSetHasChanges)
				{
					DialogResult dialogResult = dialogResult = MessageBox.Show("The Stationary Source has changes. Do you want to save before continuing?" + Environment.NewLine + Environment.NewLine +
					"Yes - Save and Continue." + Environment.NewLine + Environment.NewLine +
					"No - Undo all changes since the last save and Continue." + Environment.NewLine + Environment.NewLine +
					"Cancel - Do not Continue.",
					"Save Stationary Source?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

					if (dialogResult == DialogResult.Yes)
					{
						StationarySource.SaveStationarySource(true);
					}
					else if (dialogResult == DialogResult.No)
					{
						StationarySource.StationarySourceRejectChanges(true);
					}
					else if (dialogResult == DialogResult.Cancel)
					{
						e.Cancel = true;
					}
				}
			}

			if (FacilityDataSetHasChanges && PdePermitUserRoles.IsEditor)
			{
                ShowClosingNonSaveDialog = false;

				DialogResult dialogResult = dialogResult = MessageBox.Show("The Facility has changes. Do you want to save before closing window?" + Environment.NewLine + Environment.NewLine +
						"Yes - Save and Close Window." + Environment.NewLine + Environment.NewLine +
						"No - Undo all changes since the last save and Close Window" + Environment.NewLine + Environment.NewLine +
						"Cancel - Do not Close Window",
						"Save Facility?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (dialogResult == DialogResult.Yes)
				{
					Facility.SaveFacility(true);
				}
				else if (dialogResult == DialogResult.No)
				{
					Facility.FaciltiyRejectChanges(true);
				}
				else if (dialogResult == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}

			if (PermitDataSetHasChanges && PdePermitUserRoles.IsEditor)
			{
                ShowClosingNonSaveDialog = false;

				DialogResult dialogResult = dialogResult = MessageBox.Show("The Permit has changes. Do you want to save before closing window?" + Environment.NewLine + Environment.NewLine +
				"Yes - Save and Close Window." + Environment.NewLine + Environment.NewLine +
				"No - Undo all changes since the last save and Close Window" + Environment.NewLine + Environment.NewLine +
				"Cancel - Do not Close Window",
				"Save Facility?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (dialogResult == DialogResult.Yes)
				{
					Permit.SavePermit(true);
				}
				else if (dialogResult == DialogResult.No)
				{
					Permit.PermitRejectChanges(true);
				}
				else if (dialogResult == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}

            if (ShowClosingNonSaveDialog)
            {
                DialogResult dialogResult = dialogResult = MessageBox.Show("Do you want to close PDE Permit window?", "Close PDE Permit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                
                if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }	

		}

		#region GoToEntity

        void Device_OnGoToEntity(object sender, GoToEntityEventArgs e)
        {
            tbcPdePermit.SelectedTab = tabPermit;
            Permit.GoToPermit(e.EntityNo);
        }

		private void GoToEntity(SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs e)
		{
			switch (e.EntityType)
			{
				case "Facility":
					tbcPdePermit.SelectedTab = tabFacility;
					Facility.GoToFacility(e.EntityNo);
					break;
				case "Permit":
					tbcPdePermit.SelectedTab = tabPermit;
					Permit.GoToPermit(e.EntityNo);
					break;

				default:
					break;
			}
		}

		private void Permit_OnGoToEntity(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs e)
        {
            tbcPdePermit.SelectedTab = tabDevice;
			Device.SetPermit(e.EntityNo.ToString());
		}

		private void Facility_OnGoToEntity(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs e)
		{
			GoToEntity(e);
		}

		private void StationarySource_OnGoToEntity(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.GoToEntityEventArgs e)
		{
			GoToEntity(e);
		}

		#endregion

		#region CompanyFilter

		private void chkActiveCompanies_Click(object sender, EventArgs e)
		{
			FilterCompanies();
		}

		private void FilterCompanies()
		{
			if (chkActiveCompanies.Checked)
			{
				bsCompaniesWithFacilities.Filter = "PermitStatus = 'Active'";
			}
			else
			{
				bsCompaniesWithFacilities.RemoveFilter();
			}
		}

		private void chkFilterAllByCompany_Click(object sender, EventArgs e)
		{
			FilterAllByCompany();
		}

		private void cmbCompanyFilter_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (chkFilterAllByCompany.Checked)
			{
				FilterAllByCompany();
			}
		}

		private void FilterAllByCompany()
		{
			if (!chkFilterAllByCompany.Checked || cmbCompanyFilter.SelectedItem == null)
			{
				StationarySource.SetCompanyFilter(null);
				Permit.SetCompanyFilter(null);
				Facility.SetCompanyFilter(null);
			}
			else
			{
				StationarySource.SetCompanyFilter(cmbCompanyFilter.SelectedValue.ToString());
				Permit.SetCompanyFilter(cmbCompanyFilter.SelectedValue.ToString());
				Facility.SetCompanyFilter(cmbCompanyFilter.SelectedValue.ToString());
			}
		}

		#endregion

		#region On Events

		private void Permit_OnEntityCurrentChanged(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs e)
		{
			PermitCurrentSSID = e.StationarySourceNo.ToString();
			PermitCurrentFID = e.FacilityNo.ToString();
			PermitCurrentPermitNo = e.PermitNo.ToString();
		}

		private void StationarySource_OnEntityCurrentChanged(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs e)
		{
			StationarySourceCurrentSSID = e.StationarySourceNo.ToString();
		}

		private void Facility_OnEntityCurrentChanged(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityCurrentChangedEventArgs e)
		{
			FacilityCurrentSSID = e.StationarySourceNo.ToString();
			FacilityCurrentFID = e.FacilityNo.ToString();
		}

		private void Permit_OnCopyEmissionsGrid(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.CopyEmissionsGridEventArgs e)
		{
			tbcPdePermit.SelectedTab = tabFacility;
			Facility.PastePpteToFpte(e.FacilityNo.ToString(), e.BsEmissionsGrid);
		}

		private void StationarySource_OnStationarySourceDataSetChanged(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs e)
		{
			StationarySourceDataSetHasChanges = e.DataSetHasChanges;
			SetDataSetHasChangesDisplay();
		}

		private void Facility_OnFacilityDataSetChanged(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs e)
		{
			FacilityDataSetHasChanges = e.DataSetHasChanges;
			SetDataSetHasChangesDisplay();
		}

		private void Permit_OnPermitDataSetChanged(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs e)
		{
			PermitDataSetHasChanges = e.DataSetHasChanges;
			SetDataSetHasChangesDisplay();
		}

		private void Facility_OnCopyFacilityLocation(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.CopyLocationEventArgs e)
		{
			Facility.PasteLocation(StationarySource.GetLocation(e));
		}

        //void StationarySource_OnNewStationarySourceLocationAddressEventHandler()
        //{
        //    Facility.GetNewAddresses();
        //}

		private void Facility_OnFacilityLoadEnd()
		{
            //this.WindowState = FormWindowState.Maximized;
			Device.InitializeDevice();
			Facility.LoadFacilityAux();
			tbcPdePermit.Enabled = true;
			lblUnsavedChanges.Font = new Font(lblUnsavedChanges.Font, FontStyle.Regular);
            StationarySource.CheckToxicsFilingFolder();
            FacilityLoadEnd = true;

            //this.ShowIcon = true;
		}

		private void Facility_OnNewFacility(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityHasNewItemEventArgs e) // New or changed
		{
			Permit.FacilityListChanged(e);
		}

		void StationarySource_OnNewStationarySource(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityHasNewItemEventArgs e)
		{
			Facility.StationarySourceListChanged(e);
		}

		#endregion

		#region SelectMode

		private void radSelectModeOff_Click(object sender, EventArgs e)
		{
			SetSelectMode();
		}

		private void radSelectModeActive_Click(object sender, EventArgs e)
		{
			SetSelectMode();
		}

		private void radSelectModeAll_Click(object sender, EventArgs e)
		{
			SetSelectMode();
		}

		private void SetSelectModeFilter()
		{
			if (DeselectTab == "tabStationarySource")
			{
				if (SelectingTab == "tabFacility")
				{
					Facility.FilterFacilitySelectMode("StationarySourceNo", StationarySourceCurrentSSID, grpSelectMode.Tag.ToString());
				}
				else if (SelectingTab == "tabPermit")
				{
					Permit.FilterPermitSelectMode("StationarySourceNo", StationarySourceCurrentSSID, grpSelectMode.Tag.ToString());
				}
			}
			else if (DeselectTab == "tabFacility")
			{
				if (SelectingTab == "tabStationarySource")
				{
					StationarySource.FilterStationarySourceSelectMode("StationarySourceNo", FacilityCurrentSSID, grpSelectMode.Tag.ToString());
				}
				else if (SelectingTab == "tabPermit")
				{
					Permit.FilterPermitSelectMode("FacilityNo", FacilityCurrentFID, grpSelectMode.Tag.ToString());
				}
			}
			else if (DeselectTab == "tabPermit")
			{
				if (SelectingTab == "tabStationarySource")
				{
					StationarySource.FilterStationarySourceSelectMode("StationarySourceNo", PermitCurrentSSID, grpSelectMode.Tag.ToString());
				}
				else if (SelectingTab == "tabFacility")
				{
					Facility.FilterFacilitySelectMode("FacilityNo", PermitCurrentFID, grpSelectMode.Tag.ToString());
				}
			}
		}

		private void SetSelectMode()
		{
			if (grpSelectMode.Tag.ToString() == "Off")
			{
				StationarySource.ResetFilters();
				Facility.ResetFilters();
				Permit.ResetPermitFilters();
			}
		}

		private void tbcPdePermit_Selecting(object sender, TabControlCancelEventArgs e)
		{
			SelectingTab = e.TabPage.Name;
			if (grpSelectMode.Tag.ToString() == "All" || grpSelectMode.Tag.ToString() == "Active")
			{
				SetSelectModeFilter();
			}
			if (SelectingTab == "tabDevice")
			{
				if (DeselectTab == "tabPermit")
				{
					Device.SetPermitTimer(false, PermitCurrentPermitNo);
				}
				else
				{
					Device.SetPermitTimer(true, PermitCurrentPermitNo);
				}
			}
		}

		private void tbcPdePermit_Deselecting(object sender, TabControlCancelEventArgs e)
		{
			DeselectTab = e.TabPage.Name;
			switch (DeselectTab)
			{
				case "tabPermit":
					if (PermitDataSetHasChanges && PdePermitUserRoles.IsEditor)
					{
						DialogResult dialogResult = dialogResult = MessageBox.Show("The Permit has changes. Do you want to save before closing window?" + Environment.NewLine + Environment.NewLine +
						"Yes - Save and Continue." + Environment.NewLine + Environment.NewLine +
						"No - Undo all changes since the last save and Continue." + Environment.NewLine + Environment.NewLine +
						"Cancel - Do not Continue.",
						"Save Permit?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

						if (dialogResult == DialogResult.Yes)
						{
							Permit.SavePermit(true);
						}
						else if (dialogResult == DialogResult.No)
						{
							Permit.PermitRejectChanges();
						}
						else if (dialogResult == DialogResult.Cancel)
						{
							e.Cancel = true;
						}
					}
					break;
				case "tabFacility":
					if (Facility.FacilityDataSetHasChanges && PdePermitUserRoles.IsEditor)
					{
						DialogResult dialogResult = dialogResult = MessageBox.Show("The Facility has changes. Do you want to save before continuing?" + Environment.NewLine + Environment.NewLine +
						"Yes - Save and Continue." + Environment.NewLine + Environment.NewLine +
						"No - Undo all changes since the last save and Continue." + Environment.NewLine + Environment.NewLine +
						"Cancel - Do not Continue.",
						"Save Facility?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

						if (dialogResult == DialogResult.Yes)
						{
							Facility.SaveFacility(true);
						}
						else if (dialogResult == DialogResult.No)
						{
							Facility.FaciltiyRejectChanges(true);
						}
						else if (dialogResult == DialogResult.Cancel)
						{
							e.Cancel = true;
						}
					}
					break;
				case "tabStationarySource":
					if (StationarySourceDataSetHasChanges && PdePermitUserRoles.IsAdmin)
					{
						DialogResult dialogResult = dialogResult = MessageBox.Show("The Stationary Source has changes. Do you want to save before continuing?" + Environment.NewLine + Environment.NewLine +
						"Yes - Save and Continue." + Environment.NewLine + Environment.NewLine +
						"No - Undo all changes since the last save and Continue." + Environment.NewLine + Environment.NewLine +
						"Cancel - Do not Continue.",
						"Save Stationary Source?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

						if (dialogResult == DialogResult.Yes)
						{
							StationarySource.SaveStationarySource(true);
						}
						else if (dialogResult == DialogResult.No)
						{
							StationarySource.StationarySourceRejectChanges(true);
						}
						else if (dialogResult == DialogResult.Cancel)
						{
							e.Cancel = true;
						}
					}
					break;
				default:
					break;
			}
		}

		#endregion

		private void SetDataSetHasChangesDisplay()
		{
            if (FacilityLoadEnd)
            {
                StringBuilder sb = new StringBuilder();
                if (StationarySourceDataSetHasChanges)
                {
                    sb.Append("Stationary Source has changes");
                }

                if (FacilityDataSetHasChanges)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" :: Facility has changes");
                    }
                    else
                    {
                        sb.Append("Facility has changes");
                    }
                }

                if (PermitDataSetHasChanges)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" :: Permit has changes");
                    }
                    else
                    {
                        sb.Append("Permit has changes");
                    }
                }

                lblUnsavedChanges.Text = sb.ToString();
            }
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
            lblUnsavedChanges.Text = lblUnsavedChanges.Text + ".";
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			pnlHelp.Visible = !pnlHelp.Visible;
			if (pnlHelp.Visible)
			{
				SetRowColor();
				lblGreenHighlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
			}
		}

		private void SetRowColor()
		{
			foreach (DataGridViewRow row in this.dgvDemo.Rows)
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

		private void dgvDemo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			try
			{
				if ((e.ColumnIndex == this.dgvDemo.Columns["PermitStatus"].Index) && e.Value != null)
				{
					DataGridViewCell cell = dgvDemo.Rows[e.RowIndex].Cells[e.ColumnIndex];
					DataGridViewCell StatusCell = dgvDemo.Rows[e.RowIndex].Cells[e.ColumnIndex];
					if (e.RowIndex != 0 && e.RowIndex / 3 == 0)
					{
						StatusCell.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
					}
					else if (e.Value.Equals(false))
					{
						StatusCell.Style = dgvDemo.RowsDefaultCellStyle;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.InnerException.Message.ToString());
			}
			finally
			{
			}
		}

		private void dgvDemo_Sorted(object sender, EventArgs e)
		{
			SetRowColor();
		}

		private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dgvDemo.SelectAll();
			Clipboard.SetDataObject(dgvDemo.GetClipboardContent());
			dgvDemo.ClearSelection();
		}

		private void tbcPdePermit_Selected(object sender, TabControlEventArgs e)
		{
			if (e.TabPage == tabPermit)
			{
				Permit.CheckPermitPDF();
				Permit.CheckPermitFolder();
			}
		}

        private void btnRefreshCompanies_Click(object sender, EventArgs e)
        {
            if (Facility.RefreshCompanies())
            {
                MessageBox.Show("Companies refreshed.", "Refresh Companies");
            }
            else
            {
                MessageBox.Show("Companies not refreshed.", "Refresh Companies");
            }
        }

	}
}
