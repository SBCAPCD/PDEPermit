using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PermitCompliance.Misc
{
    public partial class usrFacilityHistory : SbcapcdOrg.ControlLibrary.usrUserControl
    {
		private string[] formats = new[] { "MM/dd/yyyy", "MM-dd-yyyy" };
		private DateTime fromDateValue;

        public usrFacilityHistory()
        {
            InitializeComponent();
            PermitPdf.Image = imageList1.Images[0];
			InspectionPdf.Image = imageList1.Images[0];
			InspectionFolder.Image = imageList1.Images[0];
			CvrPdf.Image = imageList1.Images[0];

            this.tbcFacilityHistory.SelectedIndex = 0;

			typeof(DataGridView).InvokeMember(
			   "DoubleBuffered",
			   System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
			   null,
			   dgvCvrs,
			   new object[] { true });
        }

        public void GetFacilityHistory(object facilityNo)
        {
			dsFacilityHistory.Clear();
			SbcapcdOrg.PdePermit.PdePermitComponents.CommonDL.GetFacilityHistory(base.usrConnectionString, dsFacilityHistory, facilityNo);
        }

        void SetActiveTab()
        {
            //if (this.isInDesignMode() == false && IsDisposed == false)
            //    historyTabControl.SelectedIndex = (int)DefaultHistoryTab;
        }
   
        void ShowInspection(string currentInspectionNo)
        {
            //open compliance and show inspection
            try
            {
               
            }
            catch (Exception ex)
            {

                //this.Error(ex);
            }
        }

        private void dgvPermits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0)
                {
                    return;
                }
                else if (dgvPermits.Columns[e.ColumnIndex].Name == "PermitPdf"
                    && e.RowIndex < (dgvPermits.Rows.Count))
                {
                    this.Cursor = Cursors.WaitCursor;
                    string sFinalPermitPath = dgvPermits.Rows[e.RowIndex].Cells["FinalPermitPath"].Value.ToString();

                    if (File.Exists(sFinalPermitPath))
                    {
                        System.Diagnostics.Process.Start(sFinalPermitPath);
                    }
                    else
                    {
                        MessageBox.Show("File not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayException.DisplayExceptionInfo(ex, "usrFacilityHistory : dgvPermits_CellClick");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

		private void dgvInspection_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex < 0)
				{
					return;
				}
				else if (dgvInspection.Columns[e.ColumnIndex].Name == "InspectionFolder" && e.RowIndex < (dgvInspection.Rows.Count))
				{
					this.Cursor = Cursors.WaitCursor;

					string sInspectionFolderPath = dgvInspection.Rows[e.RowIndex].Cells["InspectionReportFolder"].Value.ToString();

					if (Directory.Exists(sInspectionFolderPath))
					{
						System.Diagnostics.Process.Start(sInspectionFolderPath);
					}
					else
					{
						MessageBox.Show("No folder found");
					}
				}
				else if (dgvInspection.Columns[e.ColumnIndex].Name == "InspectionPdf" && e.RowIndex < (dgvInspection.Rows.Count))
				{
					this.Cursor = Cursors.WaitCursor;

					string sInspectionReportPath = dgvInspection.Rows[e.RowIndex].Cells["InspectionReportPath"].Value.ToString();

					if (File.Exists(sInspectionReportPath))
					{
						System.Diagnostics.Process.Start(sInspectionReportPath);
					}
					else
					{
						MessageBox.Show("No report found");
					}
				}
			}
			catch (Exception ex)
			{
				DisplayException.DisplayExceptionInfo(ex, "usrFacilityHistory : dgvInspection_CellClick");
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		//private void dgvInspection_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		//{
			//try
			//{
			//	if ((bool)dgvInspection.Rows[e.RowIndex].Cells["InspectionReportExists"].Value)
			//	{
			//		dgvInspection.Rows[e.RowIndex].Cells["InspectionPdf"].Value = imageList1.Images[0];
			//	}
			//	else
			//	{
			//		//dgvInspection.Rows[e.RowIndex].Cells["InspectionPdf"].Value = imageList1.Images[1];
			//	}
			//}
			//catch (Exception ex)
			//{
			//	DisplayException.DisplayExceptionInfo(ex, "usrFacilityHistory : dgvInspection_CellClick");
			//}
		//}

		private void dgvCvrs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if ((bool)dgvCvrs.Rows[e.RowIndex].Cells["CvrDocumentPathExists"].Value)
				dgvCvrs.Rows[e.RowIndex].Cells["CvrPdf"].Value = imageList1.Images[0];
			else
				dgvCvrs.Rows[e.RowIndex].Cells["CvrPdf"].Value = imageList1.Images[1];
		}

		private void dgvCvrs_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex != 1)
				{
					return;
				}
				else if (dgvCvrs.Columns[e.ColumnIndex].Name == "CvrPdf"
					&& e.RowIndex < (dgvCvrs.Rows.Count)
					&& (bool)dgvCvrs.Rows[e.RowIndex].Cells["CvrDocumentPathExists"].Value
					)
				{
					this.Cursor = Cursors.WaitCursor;
					string sCvrPath = dgvCvrs.Rows[e.RowIndex].Cells["CvrDocumentPath"].Value.ToString();

					if (File.Exists(sCvrPath))
					{
						System.Diagnostics.Process.Start(sCvrPath);
					}
				}
				//else
				//{
				//	MessageBox.Show("File not found.");
				//}
			}
			catch (Exception ex)
			{
				DisplayException.DisplayExceptionInfo(ex, "usrFacilityHistory : dgvCvrs_CellClick");
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void dgvCvrs_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			try
			{
				
			}
			catch (Exception ex)
			{
				//DisplayException.DisplayExceptionInfo(ex, "usrFacilityHistory : dgvCvrs_DataError");
			}
		}

		private void dgvInspection_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			try
			{

			}
			catch (Exception ex)
			{
				//DisplayException.DisplayExceptionInfo(ex, "usrFacilityHistory : dgvCvrs_DataError");
			}
		}

		private void novsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			try
			{

			}
			catch (Exception ex)
			{
				//DisplayException.DisplayExceptionInfo(ex, "usrFacilityHistory : dgvCvrs_DataError");
			}
		}

		private void dgvPermits_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			try
			{

			}
			catch (Exception ex)
			{
				//DisplayException.DisplayExceptionInfo(ex, "usrFacilityHistory : dgvCvrs_DataError");
			}
		}

		private void varianceDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			try
			{

			}
			catch (Exception ex)
			{
				//DisplayException.DisplayExceptionInfo(ex, "usrFacilityHistory : dgvCvrs_DataError");
			}
		}

		private void dgvBreakdowns_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			try
			{

			}
			catch (Exception ex)
			{
				//DisplayException.DisplayExceptionInfo(ex, "usrFacilityHistory : dgvCvrs_DataError");
			}
		}
	}
}
