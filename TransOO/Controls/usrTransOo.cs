using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SbcapcdOrg.ControlLibrary;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace SbcapcdOrg.PDEPermit.TransOo
{
    public partial class usrTransOo : SbcapcdOrg.ControlLibrary.usrUserControl
    {
        public string TransferIndex { get; set; }
        public int LetterNo { get; set; }
        public string TransferType { get; set; }
        private DataRowView drvLetter { get; set; }
        public bool IsGetTransOoLetter { get; set; }
        public bool ContactsReady { get; set; }

        private bool letterDataHasChanges;
        public bool LetterDataHasChanges 
        {
            get
            {
                return letterDataHasChanges;
            }
            set
            {
                letterDataHasChanges = value;
                SetSaveColor();
            }
        }

        //SbcapcdOrg.ControlLibrary.usrRadioButton radio;

        private DataRowView permitDataRowView;

        public DataRowView drvPermit
        {
            get
            {
                return permitDataRowView;
            }
            set
            {
                permitDataRowView = value;

                //if (TransOoTabSelected)
                //{
                //    SetPermit();
                //}
            }
        }

        public usrTransOo()
        {
            InitializeComponent();
            tscmbSelectLetter.ComboBox.SelectionChangeCommitted += new EventHandler(ComboBox_SelectionChangeCommitted);


            //tbcTransOo.TabPages.Remove(tabLetterInfo);
            //bsLetterInsertDescription.Filter = "BookmarkTypeId = 9";
            //bsLetterInsert.Filter = "BookmarkTypeId <> 6";
            //dsLetter.Letter.ColumnChanged += new DataColumnChangeEventHandler(Letter_ColumnChanged);
            //dsLetter.LetterInsert.ColumnChanged += new DataColumnChangeEventHandler(LetterInsert_ColumnChanged);
            //dsLetter.LetterCc.ColumnChanged += new DataColumnChangeEventHandler(LetterCc_ColumnChanged);
        }

        private void SetSaveColor()
        {
            if (LetterDataHasChanges)
            {
                tsbtnSaveLetter.BackColor = Color.Red;
            }
            else
            {
                tsbtnSaveLetter.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        #region ColumnChanged

        void LetterCc_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            bool checkForChanges = CommonMethods.CheckForChanges(LetterDataHasChanges, e);
            if (checkForChanges != LetterDataHasChanges)
            {
                LetterDataHasChanges = checkForChanges;
            }
        }

        void LetterInsert_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            bool checkForChanges = CommonMethods.CheckForChanges(LetterDataHasChanges, e);
            if (checkForChanges != LetterDataHasChanges)
            {
                LetterDataHasChanges = checkForChanges;
            }
        }

        void Letter_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            bool checkForChanges = CommonMethods.CheckForChanges(LetterDataHasChanges, e);
            if (checkForChanges != LetterDataHasChanges)
            {
                LetterDataHasChanges = checkForChanges;
                //CheckDataChanges();
            }
        } 



        #endregion

        private void bsLetter_CurrentChanged(object sender, EventArgs e)
        {
            //drvLetter = (DataRowView)bsLetter.Current;
            //if (drvLetter != null)
            //{
            //    //SbcapcdOrg.ControlLibrary.CommonMethods.SetGroups(this.Controls, drv);
            //    //SetDisplay();
            //}
        }
        
        void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LetterNo = (int)tscmbSelectLetter.ComboBox.SelectedValue;
            GetLetterByLetterNo();
            //ResetSorOrder();
            //SaveLetter();
            LetterDataHasChanges = false;
        }

        public void LoadTransOo()
        {
            SbcapcdOrg.PDEPermit.TransOo.TransOoBL.GetTransOoAux(base.usrConnectionString, dsTransOoAux);
            SetTransferBy();
        }

        public void SetFolderBrowser()
        {
            txtFolder.Text = drvPermit["PermitFolderPath"].ToString();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Multiselect = false;
            dialog.InitialDirectory = txtFolder.Text;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtFolder.Text = dialog.FileName;
                LetterDataHasChanges = true;
                txtFolder.DataBindings[0].WriteValue();
            }
        }

        private void GetLetterByLetterNo()
        {
            //dsLetter.Clear();
            //SbcapcdOrg.PDEPermit.TransOo.TransOoBL getLetterByLetterNo = new TransOoBL();
            //getLetterByLetterNo.GetLetterByLetterNo(base.usrConnectionString, LetterNo, dsLetter);
            //bsLetterInsertDescription.Filter = "BookmarkTypeId = 6";
            //bsLetterInsert.Filter = "BookmarkTypeId <> 6";
            //tbcTransOo.Enabled = true;
            //drvLetter = (DataRowView)bsLetter.Current;

            //if (drvLetter != null && drvLetter["ContactId"] != DBNull.Value && drvLetter["ContactId"] != null)
            //{
            //    usrPermitContactsV1.ContactId = (int)drvLetter["ContactId"];
            //}

            //LetterDataHasChanges = false;

            //if (bsLetterInsertDescription.Count == 0)
            //{
            //    DataRow drLetterInsert = dsLetter.Tables["LetterInsert"].NewRow();
            //    int LetterInsertId = SbcapcdOrg.PDEPermit.TransOo.TransOoBL.GetNewLetterId(base.usrConnectionString);

            //    drLetterInsert["LetterInsertId"] = LetterInsertId;
            //    drLetterInsert["LetterNo"] = LetterNo;
            //    drLetterInsert["BookmarkTypeId"] = 6;
            //    drLetterInsert["SortOrder"] = 0;
            //    drLetterInsert["TextInsert"] = "Add Description";

            //    dsLetter.Tables["LetterInsert"].Rows.Add(drLetterInsert);
            //    bsLetterInsertDescription.ResetBindings(false);
            //}

            //if (dsLetter.Tables["Letter"].Rows.Count > 0)
            //{
            //    object oSaveFolder = dsLetter.Tables["Letter"].Rows[0]["SaveFolder"];

            //    if (oSaveFolder == null || oSaveFolder == DBNull.Value || oSaveFolder.ToString() == String.Empty)
            //    {
            //        SetFolderBrowser();
            //    }
            //}
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            SaveLetter();
            progressBar.Value = 0;
            progressBar.Visible = true;
            progressBar.PerformStep();
            int i = (int)tscmbSelectLetter.ComboBox.SelectedValue;
            //int i = 7135;
            lblWarning.Text = SbcapcdOrg.PDEPermit.TransOo.TransOoBL.GenerateLetter(base.usrConnectionString, i, progressBar);

            progressBar.Visible = false;
        }

        private void usrTransOo_Enter(object sender, EventArgs e)
        {
            tscmbSelectLetter.Focus();
        }

        #region Modify

        private void tsbtnAddLetter_Click(object sender, EventArgs e)
        {
            AddLetter();
        }

        private void AddLetter()
        {
            dsTransOoLetter.Clear();

            //tbcTransOo.SelectedTab = tabLetterInfo;

            DataRow drLetter = dsTransOoLetter.Tables["Letter"].NewRow();
            DataRow drLetters = dsTransOoLetters.Tables["Letters"].NewRow();
            DataRow drTransOo = dsTransOoLetter.Tables["LetterTransOo"].NewRow();

            LetterNo = SbcapcdOrg.PDEPermit.TransOo.TransOoBL.GetNewLetterId(base.usrConnectionString);

            drLetter["LetterNo"] = drTransOo["LetterNo"] = drLetters["LetterNo"] = LetterNo;
            if (drvPermit != null)
            {
                drLetter["PermitNo"] = drvPermit["PermitNo"];
                drLetter["SaveFolder"] = drvPermit["PermitFolderPath"];
            }
            drLetter["LetterDate"] = System.DateTime.Today;
            drLetter["LetterName"] = drLetters["LetterName"] = GetLetterName(true);
            drLetter["SignEmployeeNo"] = 0;
			drLetter["TransSuffix"] = "  ";


            switch (TransferType)
            {
                case "Permit":
                    drTransOo["TransferType"] = "Permit";
                    drTransOo["TransferIndex"] = TransferIndex;
                    usrPermitContactsV1.GetFaciltyContacts(drvPermit["FacilityNo"].ToString());
                    drLetter["LetterTypeId"] = 10;
                    break;
                case "Facility":
                    drTransOo["TransferType"] = "Facility";
                    drTransOo["TransferIndex"] = TransferIndex;
                    usrPermitContactsV1.GetFaciltyContacts(TransferIndex);
                    drLetter["LetterTypeId"] = 11;
                    break;
                case "StatSource":
                    drTransOo["TransferType"] = "StatSource";
                    drTransOo["TransferIndex"] = TransferIndex;
                    usrPermitContactsV1.GetFaciltyContacts(TransferIndex, true);
                    drLetter["LetterTypeId"] = 12;
                    break;
                default:
                    MessageBox.Show("TransOO error");
                    return;
            }

            dsTransOoLetter.Tables["Letter"].Rows.Add(drLetter);
            dsTransOoLetter.Tables["LetterTransOo"].Rows.Add(drTransOo);
            dsTransOoLetters.Tables["Letters"].Rows.Add(drLetters);

            bsLetter.Position = bsLetter.Find("LetterNo", LetterNo);
            drvLetter = (DataRowView)bsLetter.Current;

            tscmbSelectLetter.ComboBox.SelectedValue = LetterNo;
            usrPermitContactsV1.ContactId = 0;

            bsTransOo.ResetBindings(false);
            tscmbSelectLetter.ComboBox.SelectedValue = LetterNo;
            bsLetter.ResetBindings(false);

        }

        private void tsbtnSaveLetter_Click(object sender, EventArgs e)
        {
            SaveLetter();
        }

        private void SaveLetter()
        {
            if (drvLetter != null)
            {
                drvLetter.EndEdit();
            }
            bsLetter.EndEdit();
            dgvLetterCCs.EndEdit();
            bsLetterCc.EndEdit();
            
            SbcapcdOrg.PDEPermit.TransOo.TransOoBL saveLetter = new TransOoBL();
            if (saveLetter.SaveLetter(base.usrConnectionString, dsTransOoLetter.GetChanges()))
            {
                dsTransOoLetter.AcceptChanges();
                LetterDataHasChanges = false;
            }
        }
      
        #endregion

        private string GetLetterName(bool IsIntitailName)
        {
            try
            {
                if (IsIntitailName)
                {
                    switch (TransferType)
                    {
                        case "Permit":
                            return drvPermit["Permit"].ToString().Replace("/", "-") + " - " + "Trans OO" + " - " + DateTime.Today.ToShortDateString().Replace("/", "-");
                        case "Facility":
                            return "FID " + TransferIndex + " - " + "Trans OO" + " - " + DateTime.Today.ToShortDateString().Replace("/", "-");
                        case "StatSource":
                            return "SSID " + TransferIndex + " - " + "Trans OO" + " - " + DateTime.Today.ToShortDateString().Replace("/", "-");
                        default:
                            MessageBox.Show("TransOO error");
                            return null;
                    }
                    
                }
                else
                {
                    //DataRowView drv = cmbLetterTypeTemplateNo.SelectedItem as DataRowView;
                    //return drvPermit["Permit"].ToString().Replace("/", "-") + " - " + drv["LetterTypeName"].ToString() + " - " + ((DateTime)drvLetter["LetterDate"]).ToShortDateString().Replace("/", "-");
                    return null;
                }
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "usrTransOo:GetLetterName");
                return null;
            }
        }
        
        private void tsbtnUndoChanges_Click(object sender, EventArgs e)
        {
            //dsLetter.RejectChanges();
            //dsTransOo.RejectChanges();
            //LetterDataHasChanges = false;
        }
                
        #region CCs

        private void radAPCD_Click(object sender, System.EventArgs e)
        {
            SbcapcdOrg.PDEPermit.TransOo.TransOoBL.GetCCsByCompany(base.usrConnectionString, "002751", lbxContactPickList);
            lbxContactPickList.ClearSelected();
            lbxContactPickList.ClearSelected();
            SetCcsRadio();
        }

        private void radPermit_Click(object sender, System.EventArgs e)
        {
			if ((drvPermit != null && drvPermit["PermitNo"] != null) || (radTransByFacility.Checked && cmbFacility.SelectedValue != null))
            {
                GetCCsByPermit();
            }
            SetCcsRadio();
        }

        private void cmbCompany_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            radPermit.Checked = false;
            radPermit.BackColor = System.Drawing.SystemColors.Control;
            radAPCD.Checked = false;
            radAPCD.BackColor = System.Drawing.SystemColors.Control;
            radAllContacts.Checked = false;
            radAllContacts.BackColor = System.Drawing.SystemColors.Control;

            SbcapcdOrg.PDEPermit.TransOo.TransOoBL.GetCCsByCompany(base.usrConnectionString, cmbCompany.SelectedValue.ToString(), lbxContactPickList);
            lbxContactPickList.ClearSelected();
            lbxContactPickList.ClearSelected();
        }

        private void GetCCsByPermit()
        {

			if (radTransByPermit.Checked)
			{
				SbcapcdOrg.PDEPermit.TransOo.TransOoBL.GetCCsByPermit(base.usrConnectionString, drvPermit["PermitNo"].ToString(), lbxContactPickList);
				lbxContactPickList.ClearSelected();
				lbxContactPickList.ClearSelected();
			}
			else if (radTransByFacility.Checked && cmbFacility.SelectedValue != null)
			{
				SbcapcdOrg.PDEPermit.TransOo.TransOoBL.GetCCsByFacility(base.usrConnectionString, cmbFacility.SelectedValue.ToString(), lbxContactPickList);
				lbxContactPickList.ClearSelected();
				lbxContactPickList.ClearSelected();
			}
			else
			{
				MessageBox.Show("Bad permit or Facility");
			}
        }

        private void radAllContacts_Click(object sender, System.EventArgs e)
        {
            SbcapcdOrg.PDEPermit.TransOo.TransOoBL.GetAllCCs(base.usrConnectionString, lbxContactPickList);
            lbxContactPickList.ClearSelected();
            lbxContactPickList.ClearSelected();
            SetCcsRadio();
        }

        private void btnAddToCCs_Click(object sender, System.EventArgs e)
        {
            AddToCCs();
        }

        private void SetCcsRadio()
        {
            radPermit.BackColor = System.Drawing.SystemColors.Control;
            radAPCD.BackColor = System.Drawing.SystemColors.Control;
            radAllContacts.BackColor = System.Drawing.SystemColors.Control;

            if (radPermit.Checked)
            {
                radPermit.BackColor = System.Drawing.SystemColors.ControlDark;
            }

            if (radAPCD.Checked)
            {
                radAPCD.BackColor = System.Drawing.SystemColors.ControlDark;
            }

            if (radAllContacts.Checked)
            {
                radAllContacts.BackColor = System.Drawing.SystemColors.ControlDark;
            }
        }

        protected void AddToCCs()
        {
            DataRow addRow;
            DataRowView drv = null;

            for (int i = 0; i <= lbxContactPickList.SelectedItems.Count - 1; i++)
            {
                drv = lbxContactPickList.SelectedItems[i] as DataRowView;

                if (dsTransOoLetter.Tables["LetterCc"].Select("ContactName = '" + drv["ContactName"].ToString() + "'").Length == 0)
                {
                    addRow = dsTransOoLetter.Tables["LetterCc"].NewRow();
                    addRow["LetterNo"] = LetterNo;
                    addRow["ContactId"] = drv["ContactId"].ToString(); ;
                    addRow["IsCoverLetterOnly"] = false;
                    addRow["ContactName"] = drv["ContactName"].ToString();
                    dsTransOoLetter.Tables["LetterCc"].Rows.Add(addRow);

                    LetterDataHasChanges = true;
                }
            }
        }

        private void lbxContactPickList_DoubleClick(object sender, EventArgs e)
        {
            AddToCCs();
        }

        private void btnDeleteCC_Click(object sender, System.EventArgs e)
        {
            bsLetterCc.RemoveCurrent();
            LetterDataHasChanges = true;
        }

        #endregion
              
        private void tsbtnDeleteLetter_Click(object sender, EventArgs e)
        {
            LetterDataHasChanges = true;

            bsTransOo.RemoveAt(bsTransOo.Find("LetterNo", LetterNo));
            bsTransOo.ResetBindings(false);
            tscmbSelectLetter.SelectedIndex = 0;
        }

        private void radTransBy_Click(object sender, EventArgs e)
        {
            SetTransferBy();
        }

        private void SetTransferBy()
        {
            dsTransOoLetter.Clear();
            dsTransOoLetters.Clear();

            if (ContactsReady)
            {
                usrPermitContactsV1.GetFaciltyContacts("00");
            }

            pnlFacility.Visible = false;
            pnlStaSource.Visible = false;
            usrGetPermits.Visible = false;
			pnlTransferSuffix.Visible = false;

            if (radTransByPermit.Checked)
            {
                usrGetPermits.Visible = true;
                TransferType = "Permit";
				pnlTransferSuffix.Visible = true;
            }

            if (radTransByFacility.Checked)
            {
                pnlFacility.Visible = true;
                TransferType = "Facility";
            }

            if (radTransByStationarySource.Checked)
            {
                pnlStaSource.Visible = true;
                TransferType = "StatSource";
            }

        }

        private void txtFacilityFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFacilityFilter.Text.Length > 0)
            {
                bsFacilityList.Filter = "FacilityName LIKE '*" + txtFacilityFilter.Text + "*'";
            }
            else
            {
                bsFacilityList.RemoveFilter();
            }

            bsFacilityList.ResetBindings(false);
        }

        private void txtFilterStatSource_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterStatSource.Text.Length > 0)
            {
                bsStationarySourceList.Filter = "StationarySourceName LIKE '*" + txtFilterStatSource.Text + "*'";
            }
            else
            {
                bsStationarySourceList.RemoveFilter();
            }

            bsStationarySourceList.ResetBindings(false);
        }

        private void cmbFacility_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TransferIndex = cmbFacility.SelectedValue.ToString();
            GetTransOosByIndex();
        }

        private void cmbStatSource_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TransferIndex = cmbStatSource.SelectedValue.ToString();
            GetTransOosByIndex();
        }

        private void usrGetPermits_OnPermitNoChanged(object source, Permit.PermitComponents.PsaEventArgs.PermitNoChangedEventArgs e)
        {
            drvPermit = e.drvPermit;
            TransferIndex = e.drvPermit["PermitNo"].ToString();
            GetTransOosByIndex();
        }

        private void GetTransOosByIndex()
        {
            dsTransOoLetter.Clear();
            dsTransOoLetters.Clear();

            SbcapcdOrg.PDEPermit.TransOo.TransOoBL.GetTransOosByIndex(base.usrConnectionString, dsTransOoLetters, TransferIndex, TransferType);
            tscmbSelectLetter.ComboBox.DataSource = bsLetters;
            tscmbSelectLetter.ComboBox.DisplayMember = "LetterName";
            tscmbSelectLetter.ComboBox.ValueMember = "LetterNo";
            bsLetters.ResetBindings(false);
        }

        private void tscmbSelectLetter_DropDownClosed(object sender, EventArgs e)
        {
            GetTransOoLetter();
        }

        private void GetTransOoLetter()
        {
            dsTransOoLetter.Clear();
            SbcapcdOrg.PDEPermit.TransOo.TransOoBL getTransOoByLetterNo = new TransOoBL();
            getTransOoByLetterNo.GetTransOoByLetterNo(base.usrConnectionString, LetterNo, dsTransOoLetter);

            drvLetter = (DataRowView)bsLetter.Current;

            IsGetTransOoLetter = true;
            if (drvLetter != null)
            {
                usrPermitContactsV1.GetFaciltyContacts(drvLetter["FacilityNo"].ToString());
            }
            IsGetTransOoLetter = false;

            if (drvLetter != null && drvLetter["ContactId"] != DBNull.Value && drvLetter["ContactId"] != null)
            {
                usrPermitContactsV1.ContactId = (int)drvLetter["ContactId"];
            }

            LetterDataHasChanges = false;

        }

        private void usrPermitContactsV1_OnContactChanged(object source, SbcapcdOrg.PdePermit.ContactComponents.usrPermitContactsV.ContactChangedEventArgs e)
        {
            if (drvLetter != null && !IsGetTransOoLetter)
            {
                drvLetter["ContactId"] = e.ContactId;
                drvLetter.EndEdit();
            }
        }

        private void usrPermitContactsV1_ConString(object sender)
        {
            ContactsReady = true;
        }

		private void cmbTransferSuffix_DropDownClosed(object sender, EventArgs e)
		{

		}
    }
}
