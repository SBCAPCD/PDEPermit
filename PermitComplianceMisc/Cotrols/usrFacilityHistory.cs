using System;
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
        public usrFacilityHistory()
        {
            InitializeComponent();
            PermitPdf.Image = imageList1.Images[0];
            this.tbcFacilityHistory.SelectedIndex = 0;     
        }

        public void GetFacilityHistory(object facilityNo)
        {
            SbcapcdOrg.PermitCompliance.Misc.ComplianceComponentsBL.GetFacilityHistory(base.usrConnectionString, dsFacilityHistory, facilityNo);
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

    }
}
