using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Data.Sql;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml.Linq;
using SbcapcdOrg.ControlLibrary;
//using SbcapcdOrg.PdePermit.PdePermitComponents;

namespace SbcapcdOrg.PdePermit.Company
{
    public partial class usrCompany : SbcapcdOrg.ControlLibrary.usrUserControl
	{

		Regex rxNumber = new Regex("[0-9]");
		Regex rxLetter = new Regex("[a-zA-Z]");
		Regex rxSpace = new Regex(" ");
		private SbcapcdOrg.ControlLibrary.UserRoles PdePermitUserRoles = null;

		public usrCompany()
		{
			InitializeComponent();
		}

		public bool CompanyDataSetHasChanges { get; set; }

		public void SetCompanyUserRoles(SbcapcdOrg.ControlLibrary.UserRoles pdePermitUserRoles)
		{
			PdePermitUserRoles = pdePermitUserRoles;
			if (PdePermitUserRoles != null && (PdePermitUserRoles.IsAdmin || PdePermitUserRoles.IsContactEd))
			{
				tsbtnNewCompany.Enabled = true;
				tsbtnSaveCompany.Enabled = true;
				tsbtnUndoCompany.Enabled = true;
			}
			tsbtnDeleteCompany.Enabled = PdePermitUserRoles.IsAdmin;
			tsbtnNewCompany.Enabled = PdePermitUserRoles.IsAdmin;
			tsbtnSaveCompany.Enabled = PdePermitUserRoles.IsAdmin;
		}

		public void LoadCompany()
		{
			SbcapcdOrg.PdePermit.Company.CompanyBL getCompany = new CompanyBL();
            getCompany.GetCompany(base.usrConnectionString, dsCompany);

			SbcapcdOrg.PdePermit.Company.CompanyBL getCompanyAux = new CompanyBL();
            getCompanyAux.GetCompanyAux(base.usrConnectionString, dsCompanyAux);

			dsCompany.Company.ColumnChanged += new DataColumnChangeEventHandler(Company_ColumnChanged);
		}

		void Company_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			CheckForUnsavedChanges(e);
		}

		protected void CheckForUnsavedChanges(DataColumnChangeEventArgs e)
		{
			bool checkForChanges = CommonMethods.CheckForChanges(CompanyDataSetHasChanges, e);
			if (CompanyDataSetHasChanges != checkForChanges)
			{
				CompanyDataSetHasChanges = checkForChanges;
				tslblCompanyHasChanges.Visible = CompanyDataSetHasChanges;
			}
		}

		protected bool CheckForChanges(DataColumnChangeEventArgs e)
		{
			string ChangingColumnName = e.Column.ToString();
			if (CompanyDataSetHasChanges)
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

		private void tstxtFilterCompany_TextChanged(object sender, EventArgs e)
		{
			FilterCompany();
		}

		private void FilterCompany()
		{
			if (tstxtFilterCompany.Text == "")
			{
				bsCompany.RemoveFilter();
			}
			else if (rxNumber.IsMatch(tstxtFilterCompany.Text) && !(rxLetter.IsMatch(tstxtFilterCompany.Text) || rxSpace.IsMatch(tstxtFilterCompany.Text)))
			{
				bsCompany.Filter = "CompanyNo LIKE '*" + tstxtFilterCompany + "*'";
			}
			else
			{
				bsCompany.Filter = "CompanyName LIKE '*" + tstxtFilterCompany + "*' OR Dba LIKE '*" + tstxtFilterCompany + "*'";
			}
		}

		private void tsbtnUndoCompany_Click(object sender, EventArgs e)
		{
			bsCompany.CancelEdit();
		}

		private void tsbtnResetCompanyFilter_Click(object sender, EventArgs e)
		{
			tstxtFilterCompany.Clear();
			bsCompany.RemoveFilter();
		}

		private void tsbtnSaveComnpany_Click(object sender, EventArgs e)
		{
			SaveCompany();
		}

		public void ContactsRejectChanges()
		{
			dsCompany.RejectChanges();
			bsCompany.ResetBindings(false);
			CompanyDataSetHasChanges = false;
			tslblCompanyHasChanges.Visible = CompanyDataSetHasChanges;
		}

		public void SaveCompany()
		{
			try
			{
				bsCompany.EndEdit();

				SbcapcdOrg.PdePermit.Company.CompanyBL saveCompany = new CompanyBL();

                if (saveCompany.SaveCompany(base.usrConnectionString, dsCompany.GetChanges()))
				{
					dsCompany.AcceptChanges();
					CompanyDataSetHasChanges = false;
					tslblCompanyHasChanges.Visible = CompanyDataSetHasChanges;
				}
			}
			catch (Exception ex)
			{
				//bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

				//if (rethrow)
				//{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "");
				//dsCompany.Company
				//}
			}

		}

		private void tsbtnNewCompany_Click(object sender, EventArgs e)
		{
			NewCompany();
		}

		public void NewCompany()
		{
			bsCompany.SuspendBinding();
			bsCompany.RemoveFilter();

            string NewCompanyNo = SbcapcdOrg.PdePermit.Company.CompanyBL.GetNewCompanyNo(base.usrConnectionString);

			DataRow dr = dsCompany.Tables["Company"].NewRow();
			dr["CompanyNo"] = NewCompanyNo;
			dr["CompanyName"] = "New Company " + NewCompanyNo;
			dsCompany.Tables["Company"].Rows.Add(dr);
			bsCompany.ResumeBinding();
			//HasNewCompany = true;
			//CompanyDataSetHasChanges = true;
			//SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(CompanyDataSetHasChanges);
			//OnCompanyDataSetChanged(this, args);
			//ResetFilters();

			GoToCompany(NewCompanyNo);
		}

		public void GoToCompany(object companyNo)
		{
			bsCompany.Position = bsCompany.Find("CompanyNo", companyNo);
		}

		private void cmbCompanyActiveFilter_Click(object sender, EventArgs e)
		{
			FilterCompany();
		}

		private void bsCompany_CurrentChanged(object sender, EventArgs e)
		{
			DataRowView drv = bsCompany.Current as DataRowView;
			if (drv != null)
			{
				bsContact.Filter = "CompanyNo = '" + drv["CompanyNo"].ToString() + "'";
				bsFacility.Filter = "CompanyNo = '" + drv["CompanyNo"].ToString() + "'";
			}
			dgvContact.ClearSelection();
			dgvContact.ClearSelection();
			dgvFacility.ClearSelection();
			dgvFacility.ClearSelection();
		}

		private void tsbtnDeleteCompany_Click(object sender, EventArgs e)
		{
			if ((MessageBox.Show("Do you want to delete the current Company?", "Delete Company?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				DataRowView drv = bsCompany.Current as DataRowView;
				object DeleteCompanyNo = null;
				if (drv != null)
				{
					DeleteCompanyNo = drv["CompanyNo"].ToString();
				}
				if (MessageBox.Show("Are you sure you want to delete  " + drv["CompanyName"].ToString() + "?", "Delete Company?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					DataRow findRow = dsCompany.Company.Rows.Find(DeleteCompanyNo);
					findRow.Delete();
					//FacilityDataSetHasChanges = true;
					//SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(FacilityDataSetHasChanges);
					//OnFacilityDataSetChanged(this, args);
				}
			}
		}

		//private static void SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(Exception ex)
		//{
		//  StringBuilder sb = new StringBuilder();
		//  StringWriter writer = new StringWriter(sb);

		//  AppTextExceptionFormatter formatter = new AppTextExceptionFormatter(writer, ex);

		//  // Format the exception
		//  formatter.Format();
		//  MessageBox.Show(sb.ToString(), "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//}
	}
}
