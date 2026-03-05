using SbcapcdOrg.ControlLibrary;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SbcapcdOrg.Contact
{
    public partial class usrContacts : SbcapcdOrg.ControlLibrary.usrUserControl
    {
        private SbcapcdOrg.ControlLibrary.UserRoles PdeContactUserRoles = null;
        BindingSource bsAddress;
        AutoCompleteStringCollection acscAddress;
        public bool ContactDataSetHasChanges { get; set; }

        public usrContacts()
        {
            InitializeComponent();
        }

        #region Load

        public void SetContactUserRoles(SbcapcdOrg.ControlLibrary.UserRoles pdeContactUserRoles)
        {
            PdeContactUserRoles = pdeContactUserRoles;
            if (PdeContactUserRoles != null && (PdeContactUserRoles.IsAdmin || PdeContactUserRoles.IsContactEd))
            {
                tsbtnAddNewSubscriptionContactForPerson.Enabled = true;
                tsbtnAddNewSubscriptionPersonContact.Enabled = true;
                tsbtnSaveContact.Enabled = true;
                tsbtnUndoContactChanges.Enabled = true;
            }
            tsbtnDeleteContact.Enabled = PdeContactUserRoles.IsAdmin;
            tsbtnDeletePerson.Enabled = PdeContactUserRoles.IsAdmin;
        }

        public void LoadContacts()
        {
            SbcapcdOrg.Contact.ContactBL getContactsAux = new ContactBL();
            getContactsAux.GetContactsAux(base.usrConnectionString, dsContactsAux);

            SbcapcdOrg.Contact.ContactBL getContactAux = new ContactBL();
            getContactAux.GetContactAux(base.usrConnectionString, dsContactAux);

            AutoCompleteStringCollection acscNamePrefix = new AutoCompleteStringCollection();
            foreach (DataRow row in dsContactAux.NamePrefix.Rows)
            {
                acscNamePrefix.Add(row["NamePrefix"].ToString());
            }
            cmbNamePrefix.AutoCompleteCustomSource = acscNamePrefix;

            AutoCompleteStringCollection acscNameSuffix = new AutoCompleteStringCollection();
            foreach (DataRow row in dsContactAux.NameSuffix.Rows)
            {
                acscNameSuffix.Add(row["NameSuffix"].ToString());
            }
            cmbNameSuffix.AutoCompleteCustomSource = acscNameSuffix;

            AutoCompleteStringCollection acscPositionTitle = new AutoCompleteStringCollection();
            foreach (DataRow row in dsContactAux.PositionTitle.Rows)
            {
                acscPositionTitle.Add(row["PositionTitle"].ToString());
            }
            cmbPositionTitle.AutoCompleteCustomSource = acscPositionTitle;

            AutoCompleteStringCollection acscCompany = new AutoCompleteStringCollection();
            foreach (DataRow row in dsContactsAux.Company.Rows)
            {
                acscCompany.Add(row["CompanyName"].ToString());
            }
            cmbCompany.AutoCompleteCustomSource = acscCompany;

            SbcapcdOrg.Contact.ContactBL getContacts = new ContactBL();
            getContacts.GetContacts(base.usrConnectionString, dsContacts);

            Address.LoadAddress("Contacts", "Contacts");
            Address.FillCombobox(cmbAddress);
            bsAddress = (BindingSource)cmbAddress.DataSource;

            acscAddress = new AutoCompleteStringCollection();
            Address.FillAutoCompleteAddress(acscAddress);
            cmbAddress.AutoCompleteCustomSource = acscAddress;

            //FillCombobox(cmbPersons);

            tscmbContactTypeCreate.ComboBox.DataSource = bsContactTypeCreate;
            tscmbContactTypeCreate.ComboBox.DisplayMember = "ContactTypeDescription";
            tscmbContactTypeCreate.ComboBox.ValueMember = "ContactTypeId";

            dsContacts.Person.ColumnChanged += new DataColumnChangeEventHandler(Person_ColumnChanged);
            dsContacts.Contact.ColumnChanged += new DataColumnChangeEventHandler(Contact_ColumnChanged);
        }

        void Contact_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            CheckForUnsavedChanges(e);
        }

        void Person_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            CheckForUnsavedChanges(e);
        }

        protected void CheckForUnsavedChanges(DataColumnChangeEventArgs e)
        {
            bool checkForChanges = CommonMethods.CheckForChanges(ContactDataSetHasChanges, e);
            if (ContactDataSetHasChanges != checkForChanges)
            {
                ContactDataSetHasChanges = checkForChanges;
                tslblContactHasChanges.Visible = ContactDataSetHasChanges;
            }
        }

        protected bool CheckForChanges(DataColumnChangeEventArgs e)
        {
            string ChangingColumnName = e.Column.ToString();
            if (ContactDataSetHasChanges)
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

        public void FillCombobox(System.Windows.Forms.ComboBox cmbPerson)
        {
            cmbPerson.DataSource = dsContacts.Tables["Person"].Copy();
            cmbPerson.ValueMember = "PersonNo";
            cmbPerson.DisplayMember = "Person";
        }

        #endregion

        #region Filter

        private void tstxtFilterPerson_TextChanged(object sender, EventArgs e)
        {
            FilterPerson();
        }

        private void FilterPerson()
        {
            bsPerson.Filter = "FirstName LIKE '*" + tstxtFilterPerson.Text + "*' OR LastName LIKE '*" + tstxtFilterPerson.Text + "*' OR PersonNo LIKE '*" + tstxtFilterPerson.Text + "*'";
        }

        private void tsbtnUndoContactFilter_Click(object sender, EventArgs e)
        {
            ResetFilter();
        }

        private void ResetFilter()
        {
            tstxtFilterPerson.Text = "";
            bsPerson.RemoveFilter();
        }

        #endregion

        #region Modify

        private void tsbtnAddNewSubscriptionPersonContact_Click(object sender, EventArgs e)
        {
            AddNewSubscriptionPersonContact();
        }

        private void tsbtnAddNewSubscriptionContactForPerson_Click(object sender, EventArgs e)
        {
            AddSubscriptionContactForPerson();
        }

        public void ContactsRejectChanges()
        {
            dsContacts.RejectChanges();
            bsContact.ResetBindings(false);
            bsPerson.ResetBindings(false);
            ContactDataSetHasChanges = false;
            tslblContactHasChanges.Visible = ContactDataSetHasChanges;
            SetRowColor();
        }

        private void AddSubscriptionContactForPerson()
        {
            DataRowView drv = (DataRowView)bsPerson.Current;
            if (drv != null && drv["PersonNo"] != null)
            {
                string PersonNo = drv["PersonNo"].ToString();

                DataRow drContact = dsContacts.Tables["Contact"].NewRow();
                drContact["ContactId"] = SbcapcdOrg.Contact.ContactBL.GetNewContactId(base.usrConnectionString);
                drContact["ContactTypeId"] = 25; // Subscription
                drContact["PersonNo"] = PersonNo;
                dsContacts.Tables["Contact"].Rows.Add(drContact);

                //cmbPersons.SelectedValue = PersonNo;
                cmbContactType.SelectedValue = 25;

                bsPerson.ResumeBinding();
                bsContact.ResumeBinding();
                //bsContact.Position = bsContact.Find("ContactId")
                bsContact.MoveFirst();

                bsPerson.Position = bsPerson.Find("PersonNo", PersonNo);
            }
        }

        private void AddNewSubscriptionPersonContact()
        {
            bsPerson.SuspendBinding();
            bsContact.SuspendBinding();
            ResetFilter();

            object ContactTypeId;

            ContactTypeId = tscmbContactTypeCreate.ComboBox.SelectedValue;

            string NewPersonNo = SbcapcdOrg.Contact.ContactBL.GetNewPersonNo(base.usrConnectionString);

            DataRow drContact = dsContacts.Tables["Contact"].NewRow();
            drContact["ContactId"] = SbcapcdOrg.Contact.ContactBL.GetNewContactId(base.usrConnectionString);
            drContact["ContactTypeId"] = ContactTypeId; // 
            drContact["PersonNo"] = NewPersonNo;

            if ((int)ContactTypeId == 31)
            {
                drContact["AddressNo"] = 00834;
                drContact["CompanyNo"] = 002751;
            }

            dsContacts.Tables["Contact"].Rows.Add(drContact);

            DataRow drPerson = dsContacts.Tables["Person"].NewRow();
            drPerson["PersonNo"] = NewPersonNo;
            drPerson["FirstName"] = "FirstName";
            drPerson["LastName"] = "LastName";
            drPerson["Person"] = "LastName, FirstName";
            dsContacts.Tables["Person"].Rows.Add(drPerson);

            cmbContactType.SelectedValue = ContactTypeId;

            if ((int)ContactTypeId == 31)
            {
                cmbAddress.SelectedValue = "00834";
                cmbCompany.SelectedValue = "002751";
            }

            bsPerson.ResumeBinding();
            bsContact.ResumeBinding();

            bsPerson.Position = bsPerson.Find("PersonNo", NewPersonNo);
        }

        private void tsbtnSaveContact_Click(object sender, EventArgs e)
        {
            SaveContact();
        }

        public void SaveContact()
        {
            dgvContacts.EndEdit();
            bsContact.EndEdit();
            bsPerson.EndEdit();

            bsContact.SuspendBinding();

            SbcapcdOrg.Contact.ContactBL saveContact = new ContactBL();
            DbTransaction transaction = saveContact.GetTransaction(base.usrConnectionString);

            if (saveContact.SaveContact(base.usrConnectionString, dsContacts.GetChanges(), transaction))
            {
                dsContacts.AcceptChanges();
                dgvContacts.Refresh();
                dgvPerson.Refresh();
                ContactDataSetHasChanges = false;
                tslblContactHasChanges.Visible = ContactDataSetHasChanges;
            }
            else
            {
                MessageBox.Show("Error saving.");
            }

            bsContact.ResumeBinding();
        }

        #endregion

        private void bsContact_CurrentChanged(object sender, EventArgs e)
        {
            pnlEmployee.Enabled = false;
            DataRowView drv = (DataRowView)bsContact.Current;
            if (drv != null)
            {
                Address.GoToAddress(drv["AddressNo"].ToString());
                if (drv["ContactTypeId"].ToString() == "31")
                {
                    pnlEmployee.Enabled = true;
                }
            }
            else
            {
                Address.GoToAddress("");
            }
        }

        private void cmbAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (txtFilterAddress.Text != "")
            {
                string AddressNo = cmbAddress.SelectedValue.ToString();
                txtFilterAddress.Text = "";
                bsAddress.RemoveFilter();
                cmbAddress.SelectedValue = AddressNo;
            }

            DataRowView drv = (DataRowView)bsContact.Current;
            if (drv != null)
            {
                drv["AddressNo"] = cmbAddress.SelectedValue;
                Address.GoToAddress(drv["AddressNo"].ToString());
            }
            else
            {
                Address.GoToAddress("");
            }
        }

        private void bsPerson_CurrentChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)bsPerson.Current;
            SetRowColor();
            //dgvContacts.ClearSelection();
            //dgvContacts.ClearSelection();
        }

        private void txtFilterAddress_TextChanged(object sender, EventArgs e)
        {
            bsAddress.Filter = "StreetName LIKE '*" + txtFilterAddress.Text + "*' OR AddressNumber LIKE '*" + txtFilterAddress.Text + "*' OR AddressNumber LIKE '*" + txtFilterAddress.Text + "*' OR SecondaryUnitDesignatorNumber  LIKE '*" + txtFilterAddress.Text + "*'";
        }

        private void tsbtnDeleteContact_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you want to delete the current Contact?", "Delete Contact?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                DataRowView drv = bsContact.Current as DataRowView;
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

                if (MessageBox.Show("Do you want to delete the current Contact", "Delete Contact?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataRow findRow = dsContacts.Contact.Rows.Find(DeleteContactId);
                    findRow.Delete();
                    ContactDataSetHasChanges = true;
                }
            }
        }

        private void Address_OnAddressDisplayChanged()
        {
            //string AddressNo = cmbAddress.SelectedValue.ToString();
            //Address.FillCombobox(cmbAddress);
            //Address.FillAutoCompleteAddress(acscAddress);
            //cmbAddress.AutoCompleteCustomSource = acscAddress;
            //cmbAddress.Refresh();
            //cmbAddress.SelectedValue = AddressNo;
        }

        private void tsbtnDeletePerson_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you want to delete the current Person?", "Delete Person?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                DataRowView drv = bsPerson.Current as DataRowView;
                object DeletePersonNo = null;
                if (drv != null)
                {
                    DeletePersonNo = drv["PersonNo"].ToString();
                }
                if (MessageBox.Show("Do you want to delete " + drv["FirstName"].ToString() + " " + drv["LastName"].ToString(), "Delete Person?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataRow findRow = dsContacts.Person.Rows.Find(DeletePersonNo);
                    findRow.Delete();
                    ContactDataSetHasChanges = true;
                }
            }
        }

        private void SetRowColor()
        {
            try
            {
                foreach (DataGridViewRow row in dgvContacts.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string CellName = cell.OwningColumn.Name;
                        if (CellName.IndexOf("Active") >= 0 && cell.ValueType == typeof(string) && cell.Value != null)
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

        private void dgvContacts_Sorted(object sender, EventArgs e)
        {
            SetRowColor();
            //dgvContacts.ClearSelection();
            //dgvContacts.ClearSelection();
        }

        private void dgvContacts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetRowColor();
        }

        private void dgvContacts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Email();
        }

        private void Email()
        {
            if (txtEmail.Text != String.Empty)
            {
                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem oMailItem = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                oMailItem.To = txtEmail.Text;

                oMailItem.Display(false);

                while (Marshal.ReleaseComObject(oMailItem) > 0) ;
                oMailItem = null;

                // Invoke the .NET garbage collector.
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void Address_NewAddess(object sender, Address.NewAddessEventArgs e)
        {
            Address.FillCombobox(cmbAddress);
            cmbAddress.SelectedValue = e.NewAddessNo;
            bsContact.EndEdit();
        }

        private void tsbtnUndoContactChanges_Click(object sender, EventArgs e)
        {
            RejectChangesContact();
        }

        public void RejectChangesContact()
        {
            dsContacts.RejectChanges();
            ContactDataSetHasChanges = false;
            tslblContactHasChanges.Visible = ContactDataSetHasChanges;
        }

        private void Address_AddressSaved(object sender, DataChangedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string AddressNo = cmbAddress.SelectedValue.ToString();
            Address.FillCombobox(cmbAddress);
            Address.FillAutoCompleteAddress(acscAddress);
            cmbAddress.AutoCompleteCustomSource = acscAddress;
            cmbAddress.Refresh();
            cmbAddress.SelectedValue = AddressNo;
            this.Cursor = Cursors.Default;
        }
    }

}
