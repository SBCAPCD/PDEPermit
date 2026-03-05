using System;
using System.IO;
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
using Microsoft.VisualBasic.PowerPacks;

namespace SbcapcdOrg.PDEPermit.Letters
{
    public partial class usrLetters : SbcapcdOrg.ControlLibrary.usrUserControl
    {
        public bool LettersTabSelected { get; set; }
        public int LetterNo { get; set; }
        private DataRowView drvLetter { get; set; }
        private DataRepeaterItem driClickedItem { get; set; }
        private Microsoft.VisualBasic.PowerPacks.DataRepeaterItem driCurrent { get; set; }


        string grpO = "";
        string radI = "";

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

        SbcapcdOrg.ControlLibrary.usrRadioButton radio;

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

                if (LettersTabSelected)
                {
                    SetPermit();
                }
            }
        }

        public usrLetters()
        {
            InitializeComponent();
            tscmbSelectLetter.ComboBox.SelectionChangeCommitted += new EventHandler(ComboBox_SelectionChangeCommitted);
            bsLetterInsertDescription.Filter = "BookmarkTypeId = 6";
            bsLetterInsert.Filter = "BookmarkTypeId <> 6";

            dsLetter.Letter.ColumnChanged += new DataColumnChangeEventHandler(Letter_ColumnChanged);
            dsLetter.LetterInsert.ColumnChanged += new DataColumnChangeEventHandler(LetterInsert_ColumnChanged);
            dsLetter.LetterCc.ColumnChanged += new DataColumnChangeEventHandler(LetterCc_ColumnChanged);
            
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
            drvLetter = (DataRowView)bsLetter.Current;
            if (drvLetter != null)
            {
                //SbcapcdOrg.ControlLibrary.CommonMethods.SetGroups(this.Controls, drv);
                //SetDisplay();
            }
        }

        private void SetDisplay()
        {
        }

        void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LetterNo = (int)tscmbSelectLetter.ComboBox.SelectedValue;
            GetLetterByLetterNo();
            ResetSorOrder();
            SaveLetter();
            LetterDataHasChanges = false;
        }

        public void LoadLetters()
        {
            SbcapcdOrg.PDEPermit.Letters.LettersBL.GetLettersAux(base.usrConnectionString, dsLettersAux);
        }

        public void SetPermit()
        {
            dsLetters.Clear();
            dsLetter.Clear();
            //bsLetter.ResetBindings(false);
            //bsLetterInsertDescription.ResetBindings(false);
            SbcapcdOrg.PDEPermit.Letters.LettersBL.GetLettersByPermit(base.usrConnectionString, drvPermit["PermitNo"].ToString(), dsLetters);

            if (dsLetters.Tables.Count > 0)
            {
                tscmbSelectLetter.ComboBox.DataSource = dsLetters.Tables["Letters"];
                tscmbSelectLetter.ComboBox.DisplayMember = "LetterName";
                tscmbSelectLetter.ComboBox.ValueMember = "LetterNo";
            }

            usrPermitContactsV1.GetFaciltyContacts(drvPermit["FacilityNo"].ToString());
            bsLetterTypeDocTypeTemplate.Filter = "DocType = '" + drvPermit["DocumentType"].ToString() + "' OR  DocType = 'All'";
            tscmbSelectLetter.Focus();
            LetterDataHasChanges = false;
        }

        public void SetFolderBrowser()
        {
            txtFolder.Text = drvPermit["PermitFolderPath"].ToString();
        }

        private void ResetSorOrder()
        {
            int j = 0;
            foreach (DataRow dr in dsLetter.Tables["LetterInsert"].Select("BookmarkTypeId <> 6", "SortOrder"))
            {
                dr["SortOrder"] = j;
                j += 3;
            }

            bsLetterInsert.Sort = "SortOrder";
            bsLetterInsert.ResetBindings(false);
        }

        private void usrPermitContacts_OnContactChanged(object source, PdePermit.ContactComponents.usrPermitContacts.ContactChangedEventArgs e)
        {

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
            dsLetter.Clear();
            SbcapcdOrg.PDEPermit.Letters.LettersBL getLetterByLetterNo = new LettersBL();
            getLetterByLetterNo.GetLetterByLetterNo(base.usrConnectionString, LetterNo, dsLetter);
            bsLetterInsertDescription.Filter = "BookmarkTypeId = 6";
            bsLetterInsert.Filter = "BookmarkTypeId <> 6";
            tbcLetters.Enabled = true;
            drvLetter = (DataRowView)bsLetter.Current;

            if (drvLetter != null && drvLetter["ContactId"] != DBNull.Value && drvLetter["ContactId"] != null)
            {
                usrPermitContactsV1.ContactId = (int)drvLetter["ContactId"];
            }

            LetterDataHasChanges = false;

            if (bsLetterInsertDescription.Count == 0)
            {
                DataRow drLetterInsert = dsLetter.Tables["LetterInsert"].NewRow();
                int LetterInsertId = SbcapcdOrg.PDEPermit.Letters.LettersBL.GetNewLetterId(base.usrConnectionString);

                drLetterInsert["LetterInsertId"] = LetterInsertId;
                drLetterInsert["LetterNo"] = LetterNo;
                drLetterInsert["BookmarkTypeId"] = 6;
                drLetterInsert["SortOrder"] = 0;
                drLetterInsert["TextInsert"] = "Add Description";

                dsLetter.Tables["LetterInsert"].Rows.Add(drLetterInsert);
                bsLetterInsertDescription.ResetBindings(false);
            }

            if (dsLetter.Tables["Letter"].Rows.Count > 0)
            {
                object oSaveFolder = dsLetter.Tables["Letter"].Rows[0]["SaveFolder"];

                if (oSaveFolder == null || oSaveFolder == DBNull.Value || oSaveFolder.ToString() == String.Empty)
                {
                    SetFolderBrowser();
                }
            }
        }

        private void tsbtnExample_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\Sbcapcd.org\shares\IDS APPS\PSA\Templates\Letter\HelpExamples\ATC_INC(ver2.2)-Example.doc");
        }

        private void btnNextInsertionPoint_Click(object sender, EventArgs e)
        {
            bsLetterInsert.MoveNext();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            GenerateLetter();
        }

        private void GenerateLetter()
        {
            SaveLetter();

            if (!Directory.Exists(txtFolder.Text))
            {
                MessageBox.Show("The folder path is not valid.");
                return;
            }
            
            progressBar.Value = 0;
            progressBar.Visible = true;
            progressBar.PerformStep();
            lblWarning.Text = SbcapcdOrg.PDEPermit.Letters.LettersBL.GenerateLetter(base.usrConnectionString, LetterNo, progressBar);

            progressBar.Visible = false;
        }

        private void usrLetters_Enter(object sender, EventArgs e)
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
            dsLetter.Clear();

            tbcLetters.SelectedTab = tabLetterInfo;

            DataRow drLetter = dsLetter.Tables["Letter"].NewRow();
            DataRow drLetters = dsLetters.Tables["Letters"].NewRow();

            LetterNo = SbcapcdOrg.PDEPermit.Letters.LettersBL.GetNewLetterId(base.usrConnectionString);

            drLetter["LetterNo"] = drLetters["LetterNo"] = LetterNo;
            drLetter["PermitNo"] = drvPermit["PermitNo"];
            drLetter["SaveFolder"] = drvPermit["PermitFolderPath"];
            drLetter["LetterTypeId"] = 0;
            drLetter["LetterDate"] = System.DateTime.Today;
            drLetter["LetterName"] = drLetters["LetterName"] = GetLetterName(true);
            drLetter["SignEmployeeNo"] = 0;

            dsLetter.Tables["Letter"].Rows.Add(drLetter);
            dsLetters.Tables["Letters"].Rows.Add(drLetters);

            AddLetterInsert(6, 1);

            usrPermitContactsV1.ContactId = 0;

            bsLetters.ResetBindings(false);
            tscmbSelectLetter.ComboBox.SelectedValue = LetterNo;
            bsLetter.ResetBindings(false);

            tbcLetters.Enabled = true;
            //bsLetterInsertDescription.Filter = "BookmarkTypeId = 6";
            //bsLetterInsert.Filter = "BookmarkTypeId <> 6";

        }

        private void AddLetterInsert(int bookmarkTypeId, int sortOrder)
        {
            DataRow drLetterInsert = dsLetter.Tables["LetterInsert"].NewRow();
            int LetterInsertId = SbcapcdOrg.PDEPermit.Letters.LettersBL.GetNewLetterId(base.usrConnectionString);

            drLetterInsert["LetterInsertId"] = LetterInsertId;
            drLetterInsert["LetterNo"] = LetterNo;
            drLetterInsert["BookmarkTypeId"] = bookmarkTypeId;
            drLetterInsert["SortOrder"] = sortOrder;
            drLetterInsert["TextInsert"] = "Add Text";

            dsLetter.Tables["LetterInsert"].Rows.Add(drLetterInsert);

            bsLetterInsert.Sort = "SortOrder";
            bsLetterInsert.ResetBindings(false);
            //bsLetterInsertDescription.Filter = "BookmarkTypeId = 6";
            //bsLetterInsert.Filter = "BookmarkTypeId <> 6";
        }

        private void tsbtnSaveLetter_Click(object sender, EventArgs e)
        {
            SaveLetter();
        }

        private void SaveLetter()
        {
            drptrLetterInfo.SelectNextControl(driCurrent, true, true, false, true);
            if (drvLetter != null)
            {
                drvLetter.EndEdit();
            }
            bsLetter.EndEdit();
            bsLetterInsertDescription.EndEdit();
            dgvLetterCCs.EndEdit();
            bsLetterCc.EndEdit();

            bsLetterInsert.EndEdit();
            SbcapcdOrg.PDEPermit.Letters.LettersBL saveLetter = new LettersBL();
            if (saveLetter.SaveLetter(base.usrConnectionString, dsLetter.GetChanges()))
            {
                dsLetter.AcceptChanges();
                LetterDataHasChanges = false;
            }
        }

        private void btnAddDescription_Click(object sender, EventArgs e)
        {
            AddLetterInsert(6, 1);
        }

        private void btnAddOptionalText_Click(object sender, EventArgs e)
        {
            AddLetterInsert(7, 10);
        }

        private void btnAddIncompletenessItem_Click(object sender, EventArgs e)
        {
            AddLetterInsert(8, 20);
        }

        private void NewFromLetter()
        {
            try
            {
                if (drvLetter != null)
                {
                    DataRowView drvLetterType = cmbLetterTypeTemplateNo.SelectedItem as DataRowView;

                    DataRow drNewLetter = dsLetter.Tables["Letter"].NewRow();

                    DataRow drLetters = dsLetters.Tables["Letters"].NewRow();

                    LetterNo = SbcapcdOrg.PDEPermit.Letters.LettersBL.GetNewLetterId(base.usrConnectionString);

                    drNewLetter["LetterNo"] = drLetters["LetterNo"] = LetterNo;
                    drNewLetter["PermitNo"] = drvLetter["PermitNo"];
                    drNewLetter["SaveFolder"] = drvLetter["SaveFolder"];
                    drNewLetter["LetterTypeId"] = drvLetter["LetterTypeId"];
                    drNewLetter["ContactId"] = drvLetter["ContactId"];
                    drNewLetter["LetterDate"] = System.DateTime.Today;
                    drNewLetter["LetterName"] = drLetters["LetterName"] = drvPermit["Permit"].ToString() + " - " + drvLetterType["LetterTypeName"].ToString() + " - " + DateTime.Today.ToShortDateString().Replace("/", "-");
                    drNewLetter["PrintDateOnLetter"] = drvLetter["PrintDateOnLetter"];
                    drNewLetter["IncludeLetterhead"] = drvLetter["IncludeLetterhead"];
                    drNewLetter["ReturnReceipt"] = drvLetter["ReturnReceipt"];
                    drNewLetter["HeaderType"] = drvLetter["HeaderType"];
                    drvLetter["SignEmployeeNo"] = drvLetter["SignEmployeeNo"];

                    drvLetter.EndEdit();

                    dsLetter.Tables["Letter"].Rows.Clear();

                    dsLetter.Tables["Letter"].Rows.Add(drNewLetter);
                    dsLetters.Tables["Letters"].Rows.Add(drLetters);

                    if (dsLetter.Tables["LetterInsert"].Rows.Count > 0)
                    {
                        int[] letterInsertId = new int[dsLetter.Tables["LetterInsert"].Rows.Count];

                        DataRow[] drNewLetterInsertCollection = new DataRow[dsLetter.Tables["LetterInsert"].Rows.Count];

                        int i = 0;

                        foreach (DataRow dr in dsLetter.Tables["LetterInsert"].Rows)
                        {
                            DataRow drNewLetterInsert = dsLetter.Tables["LetterInsert"].NewRow();
                            drNewLetterInsert["LetterInsertId"] = SbcapcdOrg.PDEPermit.Letters.LettersBL.GetNewLetterId(base.usrConnectionString);
                            drNewLetterInsert["LetterNo"] = LetterNo;
                            drNewLetterInsert["BookmarkTypeId"] = dr["BookmarkTypeId"];
                            drNewLetterInsert["SortOrder"] = dr["SortOrder"];
                            drNewLetterInsert["TextInsert"] = dr["TextInsert"];

                            drNewLetterInsertCollection[i] = drNewLetterInsert;
                            letterInsertId[i] = (int)dr["LetterInsertId"];
                            i++;
                        }

                        foreach (DataRow dr in drNewLetterInsertCollection)
                        {
                            dsLetter.Tables["LetterInsert"].Rows.Add(dr);
                        }

                        foreach (int j in letterInsertId)
                        {
                            dsLetter.Tables["LetterInsert"].Rows.Remove(dsLetter.Tables["LetterInsert"].Rows.Find(j));
                        }
                    }

                    if (dsLetter.Tables["LetterCc"].Rows.Count > 0)
                    {
                        int[] contactId = new int[dsLetter.Tables["LetterCc"].Rows.Count];

                        DataRow[] drNewLetterCcCollection = new DataRow[dsLetter.Tables["LetterCc"].Rows.Count];

                        int k = 0;

                        foreach (DataRow dr in dsLetter.Tables["LetterCc"].Rows)
                        {
                            DataRow drNewLetterCc = dsLetter.Tables["LetterCc"].NewRow();
                            drNewLetterCc["LetterNo"] = LetterNo;
                            drNewLetterCc["ContactId"] = dr["ContactId"];
                            drNewLetterCc["SortOrder"] = dr["SortOrder"];
                            drNewLetterCc["IsCoverLetterOnly"] = dr["IsCoverLetterOnly"];
                            drNewLetterCc["ContactName"] = dr["ContactName"];

                            drNewLetterCcCollection[k] = drNewLetterCc;
                            contactId[k] = (int)dr["ContactId"];
                            k++;
                        }

                        foreach (int l in contactId)
                        {
                            dsLetter.Tables["LetterCc"].Rows.Remove(dsLetter.Tables["LetterCc"].Rows.Find(l));
                        }

                        foreach (DataRow dr in drNewLetterCcCollection)
                        {
                            dsLetter.Tables["LetterCc"].Rows.Add(dr);
                        }
                    }

                    bsLetters.ResetBindings(false);
                    tscmbSelectLetter.ComboBox.SelectedValue = LetterNo;
                    bsLetter.ResetBindings(false);
                    SaveLetter();
                    tbcLetters.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Letter not selected.");
                }
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "usrLetters : NewFromLetter");
            }
        }
        
        #endregion

        private string GetLetterName(bool IsIntitailName)
        {
            try
            {
                if (IsIntitailName)
                {
                    return drvPermit["Permit"].ToString().Replace("/", "-") + " - " + " Letter " + " - " + DateTime.Today.ToShortDateString().Replace("/", "-");
                }
                else
                {
                    DataRowView drv = cmbLetterTypeTemplateNo.SelectedItem as DataRowView;
                    return drvPermit["Permit"].ToString().Replace("/", "-") + " - " + drv["LetterTypeName"].ToString().Replace("/", "-") + " - " + ((DateTime)drvLetter["LetterDate"]).ToShortDateString().Replace("/", "-");
                }
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "usrLetters:GetLetterName");
                return null;
            }
        }

        private void tsbtnNewFromLetter_Click(object sender, EventArgs e)
        {
            NewFromLetter();
        }

        private void tsbtnUndoChanges_Click(object sender, EventArgs e)
        {
            dsLetter.RejectChanges();
            dsLetters.RejectChanges();
            LetterDataHasChanges = false;
        }

        private void usrPermitContactsV1_OnContactChanged(object source, PdePermit.ContactComponents.usrPermitContactsV.ContactChangedEventArgs e)
        {
            if (drvLetter != null)
            {
                drvLetter["ContactId"] = e.ContactId;
            }
        }

        private void cmbLetterTypeTemplateNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
			cmbLetterTypeTemplateNo.DataBindings[0].WriteValue();
            DataRowView drvLetters = tscmbSelectLetter.ComboBox.SelectedItem as DataRowView;
            drvLetter["LetterName"] = drvLetters["LetterName"] = GetLetterName(false);
            bsLetters.ResetBindings(false);
            tscmbSelectLetter.ComboBox.Refresh();
            
        }

        private void drptrLetterInfo_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            SetGroup((ControlLibrary.usrGroupBox)e.DataRepeaterItem.Controls["grpBookmarkTypeId"]);
        }

        public void SetGroup(ControlLibrary.usrGroupBox grp)
        {
            try
            {
                foreach (System.Windows.Forms.Control control in grp.Controls)
                {
                    if (control.GetType().ToString() == "SbcapcdOrg.ControlLibrary.usrRadioButton")
                    {
                        radio = (SbcapcdOrg.ControlLibrary.usrRadioButton)control;

                        grpO = grp.Tag.ToString();

                        if (radio.Tag != null && radio.Tag.ToString() != String.Empty)
                        {
                            radI = radio.Tag.ToString();
                            if (grp.Tag.ToString() == radio.Tag.ToString())
                            {
                                radio.Checked = true;
                                this.Tag = radio.Tag.ToString();
                            }
                            else
                            {
                                radio.Checked = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Set Groups: grpBookmarkTypeId");
            }
            finally
            {
            }
        }

        private void rad_Click(object sender, EventArgs e)
        {
            SbcapcdOrg.ControlLibrary.usrRadioButton rad = (SbcapcdOrg.ControlLibrary.usrRadioButton)sender;

            SbcapcdOrg.ControlLibrary.usrGroupBox groupBox = (SbcapcdOrg.ControlLibrary.usrGroupBox)rad.Parent;

            DataRepeaterItem driGroup = (DataRepeaterItem)groupBox.Parent;

            driGroup.Controls["grpBookmarkTypeId"].Tag = rad.Tag;
        }

        private void grpBookmarkTypeId_OnGroupBoxClick(object sender, EventArgs e)
        {
            SbcapcdOrg.ControlLibrary.usrGroupBox groupBox = (SbcapcdOrg.ControlLibrary.usrGroupBox)sender;
            DataRepeaterItem driGroup = (DataRepeaterItem)groupBox.Parent;
        }

        #region DragDrop

        private void drptrLetterInfo_ItemTemplate_MouseDown(object sender, MouseEventArgs e)
        {
            driClickedItem = (DataRepeaterItem)sender;

            object o = new object();
            o = driClickedItem;

            driClickedItem.DoDragDrop(o, DragDropEffects.Link);
        }

        private void drptrLetterInfo_ItemTemplate_DragDrop(object sender, DragEventArgs e)
        {
            Microsoft.VisualBasic.PowerPacks.DataRepeaterItem driClickedItem = (DataRepeaterItem)e.Data.GetData("Microsoft.VisualBasic.PowerPacks.DataRepeaterItem");

            Microsoft.VisualBasic.PowerPacks.DataRepeaterItem driDragDrop = (DataRepeaterItem)sender;

            DataRowView drvClickedItem = (DataRowView)bsLetterInsert[driClickedItem.ItemIndex];

            DataRowView drvDragDrop = (DataRowView)bsLetterInsert[driDragDrop.ItemIndex];

            //int i = (int)drvClickedItem["SortOrder"];
            //int ii = (int)drvDragDrop["SortOrder"];

            int iNewSort = (int)drvDragDrop["SortOrder"] - 1;

            drvClickedItem["SortOrder"] = (int)drvDragDrop["SortOrder"] - 1;
            drvClickedItem.EndEdit();
            bsLetterInsert.EndEdit();
            ResetSorOrder();

            //for (int i = 0; i < drptrLetterInfo.ItemCount; i++)
            //{
            //    drptrLetterInfo.CurrentItemIndex = 0;
            //    drptrLetterInfo.CurrentItem.Invalidate();
            //}

            //drptrLetterInfo.BeginResetItemTemplate();
            //drptrLetterInfo.Refresh();
            //drptrLetterInfo.EndResetItemTemplate();
            
            System.Windows.Forms.BindingSource bsss = (BindingSource)drptrLetterInfo.DataSource;
            drptrLetterInfo.DataSource = null;
            drptrLetterInfo.DataSource = bsss;

            //drptrLetterInfo.Invalidate();
            //drptrLetterInfo.Update();
            //drptrLetterInfo.Refresh();
        }

        private void drptrLetterInfo_ItemTemplate_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }
        
        #endregion

        private void btnAddStandardItem_Click(object sender, EventArgs e)
        {
            DataRow drLetterInsert = dsLetter.Tables["LetterInsert"].NewRow();
            int LetterInsertId = SbcapcdOrg.PDEPermit.Letters.LettersBL.GetNewLetterId(base.usrConnectionString);

            DataRowView drvInsert = (DataRowView)cmbStandardInsert.SelectedItem;

            drLetterInsert["LetterInsertId"] = LetterInsertId;
            drLetterInsert["LetterNo"] = LetterNo;
            drLetterInsert["BookmarkTypeId"] = drvInsert["BookmarkTypeId"];
            drLetterInsert["SortOrder"] = 99;
            drLetterInsert["TextInsert"] = drvInsert["StandardInsertText"];

            dsLetter.Tables["LetterInsert"].Rows.Add(drLetterInsert);

            bsLetterInsert.Sort = "SortOrder";
            bsLetterInsert.ResetBindings(false);

            drptrLetterInfo.ScrollItemIntoView((int)(bsLetterInsert.Find("LetterInsertId", LetterInsertId)));
        }
        
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            DataRepeaterItem driDelete = (DataRepeaterItem)btn.Parent;
            DataRowView drv = (DataRowView)bsLetterInsert[driDelete.ItemIndex];
            drv.Row.Delete();
            LetterDataHasChanges = true;

            System.Windows.Forms.BindingSource bsss = (BindingSource)drptrLetterInfo.DataSource;
            drptrLetterInfo.DataSource = null;
            drptrLetterInfo.DataSource = bsss;
        }

        private void drptrLetterInfo_CurrentItemIndexChanged(object sender, EventArgs e)
        {
            driCurrent = drptrLetterInfo.CurrentItem;
        }
        
        #region CCs

        private void radAPCD_Click(object sender, System.EventArgs e)
        {
            SbcapcdOrg.PDEPermit.Letters.LettersBL.GetCCsByCompany(base.usrConnectionString, "002751", lbxContactPickList);
            lbxContactPickList.ClearSelected();
            lbxContactPickList.ClearSelected();
            SetCcsRadio();
        }

        private void radPermit_Click(object sender, System.EventArgs e)
        {
            if (drvPermit["PermitNo"] != null)
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

            SbcapcdOrg.PDEPermit.Letters.LettersBL.GetCCsByCompany(base.usrConnectionString, cmbCompany.SelectedValue.ToString(), lbxContactPickList);
            lbxContactPickList.ClearSelected();
            lbxContactPickList.ClearSelected();
        }

        private void GetCCsByPermit()
        {
            SbcapcdOrg.PDEPermit.Letters.LettersBL.GetCCsByPermit(base.usrConnectionString, drvPermit["PermitNo"].ToString(), lbxContactPickList);
            lbxContactPickList.ClearSelected();
            lbxContactPickList.ClearSelected();
        }

        private void radAllContacts_Click(object sender, System.EventArgs e)
        {
            SbcapcdOrg.PDEPermit.Letters.LettersBL.GetAllCCs(base.usrConnectionString, lbxContactPickList);
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

                if (dsLetter.Tables["LetterCc"].Select("ContactName = '" + drv["ContactName"].ToString() + "'").Length == 0)
                {
                    addRow = dsLetter.Tables["LetterCc"].NewRow();
                    addRow["LetterNo"] = LetterNo;
                    addRow["ContactId"] = drv["ContactId"].ToString(); ;
                    addRow["IsCoverLetterOnly"] = false;
                    addRow["ContactName"] = drv["ContactName"].ToString();
                    dsLetter.Tables["LetterCc"].Rows.Add(addRow);

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

        private void radFilterIncompletenessItem_Click(object sender, EventArgs e)
        {
            FilterStandardItems(radFilterIncompletenessItem.Tag);
        }

        private void radFilterOptionalText_Click(object sender, EventArgs e)
        {
            FilterStandardItems(radFilterOptionalText.Tag);
        }

        private void FilterStandardItems(object BookmarkTypeId)
        {
            bsStandardInsert.Filter = "BookmarkTypeId = " + BookmarkTypeId.ToString();
        }

        private void tsbtnDeleteLetter_Click(object sender, EventArgs e)
        {
            bsLetter.RemoveCurrent();
            bsLetterInsertDescription.Filter = "BookmarkTypeId = 99";
            bsLetterInsert.Filter = "BookmarkTypeId  = 99";
            LetterDataHasChanges = true;

            bsLetters.RemoveAt(bsLetters.Find("LetterNo", LetterNo));
            bsLetters.ResetBindings(false);
            tscmbSelectLetter.SelectedIndex = 0;
        }

        //private void grpOptionalText_CheckedChanged(object sender, EventArgs e)
        //{
        //    //label2.Text = grpOptionalText.Checked.ToString();
            
        //    int i = 1;
        //}

        private void radIncompletenessItems_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = radIncompletenessItems.Checked.ToString();

            int i = 1;
        }

        private void radOptionalText_CheckedChanged(object sender, EventArgs e)
        {
            int i = 1;
        }
    }
}
