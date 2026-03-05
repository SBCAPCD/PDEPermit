using SbcapcdOrg.ControlLibrary;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SbcapcdOrg.PdePermit.PdePermitComponents;

namespace SbcapcdOrg.Contact
{
    public partial class usrPerson : SbcapcdOrg.ControlLibrary.usrUserControl
    {        
        private bool HasNewPerson = false;

        private bool personDataSetHasChanges = false;
        public bool PersonDataSetHasChanges
        {
            get { return personDataSetHasChanges; }
            set { personDataSetHasChanges = value; }
        }

        public usrPerson()
        {
            InitializeComponent();
            dsPerson.Person.ColumnChanged += new DataColumnChangeEventHandler(Person_ColumnChanged);
        }

        public string NewPerson()
        {
            string NewPersonNo = SbcapcdOrg.Contact.ContactBL.GetNewPersonNo(base.usrConnectionString);

            DataRow drPerson = dsPerson.Tables["Person"].NewRow();
            drPerson["PersonNo"] = NewPersonNo;
            drPerson["FirstName"] = "FirstName";
            drPerson["LastName"] = "LastName";
            drPerson["Person"] = "LastName, FirstName" + " : " + NewPersonNo;
            drPerson["IsCompletenessReviewEngineer"] = false;
            drPerson["IsPermitComplianceAssignee"] = false;
            drPerson["IsInspector"] = false;
            dsPerson.Tables["Person"].Rows.Add(drPerson);

            GoToPerson(NewPersonNo);
            return NewPersonNo;
        }

        public void GetPerson(string personNo)
        {
            SbcapcdOrg.Contact.ContactBL getPerson = new ContactBL();
           getPerson.GetPerson(base.usrConnectionString, dsPerson, personNo);
            GoToPerson(personNo);
        }

        public void GoToPerson(string personNo)
        {
            bsPerson.EndEdit();
            bsPerson.Filter = "PersonNo = '" + personNo + "'";
        }

        public void SetFormFixedSingle()
        {
            foreach (Control cntl in this.Controls)
            {
                if (cntl.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    ((System.Windows.Forms.TextBox)cntl).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                }
                else if (cntl.GetType().ToString() == "System.Windows.Forms.MaskedTextBox")
                {
                    ((System.Windows.Forms.MaskedTextBox)cntl).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                }
                else if (cntl.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {
                    System.Windows.Forms.CheckBox chk = (System.Windows.Forms.CheckBox)cntl;
                    chk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                }
                else if (cntl.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    System.Windows.Forms.ComboBox cmb = (System.Windows.Forms.ComboBox)cntl;
                    cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                }
            }
        }

        private void usrPerson_Load(object sender, EventArgs e)
        {
            //LoadPerson();
        }

        public bool SavePerson()
        {
            bsPerson.EndEdit();
            SbcapcdOrg.Contact.ContactBL savePerson = new ContactBL();
            if (savePerson.SavePerson(base.usrConnectionString, dsPerson.GetChanges()))
            {
                dsPerson.AcceptChanges();
                PersonDataSetHasChanges = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PersonEndEdit()
        {
            bsPerson.EndEdit();
        }

        public bool SavePerson(bool isAdmin, System.Data.Common.DbTransaction transaction)
        {
            bsPerson.EndEdit();
            SbcapcdOrg.Contact.ContactBL savePerson = new ContactBL();

            if (isAdmin)
            {
                if (savePerson.SavePerson(base.usrConnectionString, dsPerson.GetChanges(), transaction))
                {
                    if (dsPerson.GetChanges() != null)
                    {
                        foreach (DataRow dr in dsPerson.GetChanges().Tables[0].Rows)
                        {
                            DataRow FoundRow = dsPerson.Person.Rows.Find(dr["PersonNo"]);
                            if (FoundRow != null)
                            {
                                FoundRow["Person"] = FoundRow["LastName"].ToString() + ", " + FoundRow["FirstName"].ToString() + " : " + FoundRow["PersonNo"].ToString();
                            }
                        }
                    }
                    dsPerson.AcceptChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (savePerson.SavePersonEditor(base.usrConnectionString, dsPerson.GetChanges(), transaction))
                {
                    dsPerson.AcceptChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void PersonAcceptChanges()
        {
            dsPerson.AcceptChanges();
            PersonDataSetHasChanges = false;
        }

        public void PersonRejectChanges()
        {
            dsPerson.RejectChanges();
            bsPerson.ResetBindings(false);
            PersonDataSetHasChanges = false;
        }

        void Person_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName != "Person")
            {
                CheckForUnsavedChanges(e);
            }
        }

        protected void CheckForUnsavedChanges(DataColumnChangeEventArgs e)
        {
            bool checkForChanges = CommonMethods.CheckForChanges(PersonDataSetHasChanges, e);
            if (PersonDataSetHasChanges != checkForChanges)
            {
                PersonDataSetHasChanges = checkForChanges;
                SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs args = new SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs(PersonDataSetHasChanges);
                OnPersonDataSetChanged(this, args);
            }
        }

        public delegate void PersonDataSetChangedEventHandler(object sender, SbcapcdOrg.PdePermit.PdePermitComponents.EntityDataSetHasChangesEventArgs e);

        public event PersonDataSetChangedEventHandler OnPersonDataSetChanged;

        protected bool CheckForChanges(DataColumnChangeEventArgs e)
        {
            string ChangingColumnName = e.Column.ToString();
            if (HasNewPerson)
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

        public void LoadPerson(string entity)
        {
            SbcapcdOrg.Contact.ContactBL getContactAux = new ContactBL();
            getContactAux.GetContactAux(base.usrConnectionString, dsPersonContactAuxData);

            AutoCompleteStringCollection acscNamePrefix = new AutoCompleteStringCollection();
            foreach (DataRow row in dsPersonContactAuxData.NamePrefix.Rows)
            {
                acscNamePrefix.Add(row["NamePrefix"].ToString());
            }
            cmbNamePrefix.AutoCompleteCustomSource = acscNamePrefix;

            AutoCompleteStringCollection acscNameSuffix = new AutoCompleteStringCollection();
            foreach (DataRow row in dsPersonContactAuxData.NameSuffix.Rows)
            {
                acscNameSuffix.Add(row["NameSuffix"].ToString());
            }
            cmbNameSuffix.AutoCompleteCustomSource = acscNameSuffix;

            AutoCompleteStringCollection acscPositionTitle = new AutoCompleteStringCollection();
            foreach (DataRow row in dsPersonContactAuxData.PositionTitle.Rows)
            {
                acscPositionTitle.Add(row["PositionTitle"].ToString());
            }
            cmbPositionTitle.AutoCompleteCustomSource = acscPositionTitle;

            SbcapcdOrg.Contact.ContactBL getPerson = new ContactBL();
            getPerson.GetPerson(base.usrConnectionString, dsPerson);
        }

        public void LoadPersonAux()
        {
            SbcapcdOrg.Contact.ContactBL getContactAux = new ContactBL();
            getContactAux.GetContactAux(base.usrConnectionString, dsPersonContactAuxData);

            AutoCompleteStringCollection acscNamePrefix = new AutoCompleteStringCollection();
            foreach (DataRow row in dsPersonContactAuxData.NamePrefix.Rows)
            {
                acscNamePrefix.Add(row["NamePrefix"].ToString());
            }
            cmbNamePrefix.AutoCompleteCustomSource = acscNamePrefix;

            AutoCompleteStringCollection acscNameSuffix = new AutoCompleteStringCollection();
            foreach (DataRow row in dsPersonContactAuxData.NameSuffix.Rows)
            {
                acscNameSuffix.Add(row["NameSuffix"].ToString());
            }
            cmbNameSuffix.AutoCompleteCustomSource = acscNameSuffix;

            AutoCompleteStringCollection acscPositionTitle = new AutoCompleteStringCollection();
            foreach (DataRow row in dsPersonContactAuxData.PositionTitle.Rows)
            {
                acscPositionTitle.Add(row["PositionTitle"].ToString());
            }
            cmbPositionTitle.AutoCompleteCustomSource = acscPositionTitle;
        }

        public void FillCombobox(System.Windows.Forms.ComboBox cmbPerson)
        {
            cmbPerson.DataSource = dsPerson.Tables["Person"].Copy();
            cmbPerson.ValueMember = "PersonNo";
            cmbPerson.DisplayMember = "Person";
        }

        public void FillCombobox(System.Windows.Forms.DataGridViewComboBoxColumn cmbPerson)
        {
            cmbPerson.DataSource = dsPerson.Tables["Person"].Copy();
            cmbPerson.ValueMember = "PersonNo";
            cmbPerson.DisplayMember = "Person";
        }

        public void FillAutoCompletePerson(AutoCompleteStringCollection acscPerson)
        {
            foreach (DataRow row in dsPerson.Person.Rows)
            {
                acscPerson.Add(row["Person"].ToString());
            }
        }

        private void bsPerson_CurrentChanged(object sender, EventArgs e)
        {
            bsPerson.EndEdit();

            pictureBox1.Image = null;

            byte[] imgdata = (byte[])((DataRowView)bsPerson.Current)["SignatureImage"];

            if (imgdata.Length > 0)
            {
                ImageConverter imageConverter = new ImageConverter();
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = (Bitmap)imageConverter.ConvertFrom(imgdata);
            }
        }

        #region Set

        private void mtbPhoneNumber_Click(object sender, EventArgs e)
        {
            mtbPhoneNumber.SelectionLength = 0;
            mtbPhoneNumber.SelectionStart = 0;
        }

        private void mtbCellNumber_Click(object sender, EventArgs e)
        {
            mtbCellNumber.SelectionLength = 0;
            mtbCellNumber.SelectionStart = 0;
        }

        private void mtbFax_Click(object sender, EventArgs e)
        {
            mtbFax.SelectionLength = 0;
            mtbFax.SelectionStart = 0;
        }

        #endregion

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
            else
            {
                MessageBox.Show("No email address.");
            }
        }
    }

}
