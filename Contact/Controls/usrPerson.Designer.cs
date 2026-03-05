namespace SbcapcdOrg.Contact
{
	partial class usrPerson
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label sortGroupLabel;
            this.lblTitleDesc = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.familyTitleLabel = new System.Windows.Forms.Label();
            this.lblPositionTitle = new System.Windows.Forms.Label();
            this.lblPhoneExt = new System.Windows.Forms.Label();
            this.lblFaxExt = new System.Windows.Forms.Label();
            this.lblAddressNo = new System.Windows.Forms.Label();
            this.companyNoLabel = new System.Windows.Forms.Label();
            this.bsPerson = new System.Windows.Forms.BindingSource(this.components);
            this.dsPerson = new SbcapcdOrg.Contact.PersonDataSet();
            this.cmbNamePrefix = new System.Windows.Forms.ComboBox();
            this.bsNamePrefix = new System.Windows.Forms.BindingSource(this.components);
            this.dsPersonContactAuxData = new SbcapcdOrg.Contact.ContactAuxDataSet();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.cmbNameSuffix = new System.Windows.Forms.ComboBox();
            this.bsNameSuffix = new System.Windows.Forms.BindingSource(this.components);
            this.cmbPositionTitle = new System.Windows.Forms.ComboBox();
            this.bsPositionTitle = new System.Windows.Forms.BindingSource(this.components);
            this.chkInterofficeMail = new System.Windows.Forms.CheckBox();
            this.mtbPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.mtbCellNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblCell = new System.Windows.Forms.Label();
            this.mtbFax = new System.Windows.Forms.MaskedTextBox();
            this.lblFaxNumber = new System.Windows.Forms.Label();
            this.txtPhoneExt = new System.Windows.Forms.TextBox();
            this.txtFaxExt = new System.Windows.Forms.TextBox();
            this.cmbAddressNo = new System.Windows.Forms.ComboBox();
            this.companyNoComboBox = new System.Windows.Forms.ComboBox();
            this.txtAddressNo = new System.Windows.Forms.TextBox();
            this.txtCompanyNo = new System.Windows.Forms.TextBox();
            this.lblContactId = new System.Windows.Forms.Label();
            this.lblPerson = new System.Windows.Forms.Label();
            this.lblPersonNo = new System.Windows.Forms.Label();
            this.btnEmail = new System.Windows.Forms.Button();
            this.bsSortGroup = new System.Windows.Forms.BindingSource(this.components);
            this.chkisCompletenessReviewEngineer = new System.Windows.Forms.CheckBox();
            this.isPermitComplianceAssigneeCheckBox = new System.Windows.Forms.CheckBox();
            this.isInspectorCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            sortGroupLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNamePrefix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPersonContactAuxData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNameSuffix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPositionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSortGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sortGroupLabel
            // 
            sortGroupLabel.AutoSize = true;
            sortGroupLabel.Location = new System.Drawing.Point(17, 165);
            sortGroupLabel.Name = "sortGroupLabel";
            sortGroupLabel.Size = new System.Drawing.Size(43, 16);
            sortGroupLabel.TabIndex = 38;
            sortGroupLabel.Text = "Group";
            // 
            // lblTitleDesc
            // 
            this.lblTitleDesc.AutoSize = true;
            this.lblTitleDesc.Location = new System.Drawing.Point(3, 3);
            this.lblTitleDesc.Name = "lblTitleDesc";
            this.lblTitleDesc.Size = new System.Drawing.Size(32, 16);
            this.lblTitleDesc.TabIndex = 1;
            this.lblTitleDesc.Text = "Title";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(65, 3);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(34, 16);
            this.firstNameLabel.TabIndex = 4;
            this.firstNameLabel.Text = "First";
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Location = new System.Drawing.Point(148, 3);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(46, 16);
            this.lblMiddleName.TabIndex = 6;
            this.lblMiddleName.Text = "Middle";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(229, 3);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(33, 16);
            this.lastNameLabel.TabIndex = 8;
            this.lastNameLabel.Text = "Last";
            // 
            // familyTitleLabel
            // 
            this.familyTitleLabel.AutoSize = true;
            this.familyTitleLabel.Location = new System.Drawing.Point(350, 3);
            this.familyTitleLabel.Name = "familyTitleLabel";
            this.familyTitleLabel.Size = new System.Drawing.Size(40, 16);
            this.familyTitleLabel.TabIndex = 10;
            this.familyTitleLabel.Text = "Suffix";
            // 
            // lblPositionTitle
            // 
            this.lblPositionTitle.AutoSize = true;
            this.lblPositionTitle.Location = new System.Drawing.Point(5, 53);
            this.lblPositionTitle.Name = "lblPositionTitle";
            this.lblPositionTitle.Size = new System.Drawing.Size(55, 16);
            this.lblPositionTitle.TabIndex = 12;
            this.lblPositionTitle.Text = "Position";
            this.lblPositionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPhoneExt
            // 
            this.lblPhoneExt.AutoSize = true;
            this.lblPhoneExt.Location = new System.Drawing.Point(171, 81);
            this.lblPhoneExt.Name = "lblPhoneExt";
            this.lblPhoneExt.Size = new System.Drawing.Size(28, 16);
            this.lblPhoneExt.TabIndex = 25;
            this.lblPhoneExt.Text = "Ext";
            // 
            // lblFaxExt
            // 
            this.lblFaxExt.AutoSize = true;
            this.lblFaxExt.Location = new System.Drawing.Point(171, 108);
            this.lblFaxExt.Name = "lblFaxExt";
            this.lblFaxExt.Size = new System.Drawing.Size(28, 16);
            this.lblFaxExt.TabIndex = 26;
            this.lblFaxExt.Text = "Ext";
            // 
            // lblAddressNo
            // 
            this.lblAddressNo.AutoSize = true;
            this.lblAddressNo.Location = new System.Drawing.Point(222, 162);
            this.lblAddressNo.Name = "lblAddressNo";
            this.lblAddressNo.Size = new System.Drawing.Size(56, 16);
            this.lblAddressNo.TabIndex = 28;
            this.lblAddressNo.Text = "Address";
            this.lblAddressNo.Visible = false;
            // 
            // companyNoLabel
            // 
            this.companyNoLabel.AutoSize = true;
            this.companyNoLabel.Location = new System.Drawing.Point(219, 162);
            this.companyNoLabel.Name = "companyNoLabel";
            this.companyNoLabel.Size = new System.Drawing.Size(63, 16);
            this.companyNoLabel.TabIndex = 30;
            this.companyNoLabel.Text = "Company";
            this.companyNoLabel.Visible = false;
            // 
            // bsPerson
            // 
            this.bsPerson.DataMember = "Person";
            this.bsPerson.DataSource = this.dsPerson;
            // 
            // dsPerson
            // 
            this.dsPerson.DataSetName = "PersonDataSet";
            this.dsPerson.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbNamePrefix
            // 
            this.cmbNamePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "NamePrefix", true));
            this.cmbNamePrefix.DataSource = this.bsNamePrefix;
            this.cmbNamePrefix.DisplayMember = "NamePrefix";
            this.cmbNamePrefix.FormattingEnabled = true;
            this.cmbNamePrefix.Location = new System.Drawing.Point(5, 21);
            this.cmbNamePrefix.Name = "cmbNamePrefix";
            this.cmbNamePrefix.Size = new System.Drawing.Size(55, 24);
            this.cmbNamePrefix.TabIndex = 0;
            this.cmbNamePrefix.ValueMember = "NamePrefix";
            // 
            // bsNamePrefix
            // 
            this.bsNamePrefix.DataMember = "NamePrefix";
            this.bsNamePrefix.DataSource = this.dsPersonContactAuxData;
            // 
            // dsPersonContactAuxData
            // 
            this.dsPersonContactAuxData.DataSetName = "ContactAuxDataSet";
            this.dsPersonContactAuxData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtFirstName
            // 
            this.txtFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "FirstName", true));
            this.txtFirstName.Location = new System.Drawing.Point(65, 22);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(75, 22);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "MiddleName", true));
            this.txtMiddleName.Location = new System.Drawing.Point(148, 22);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(75, 22);
            this.txtMiddleName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "LastName", true));
            this.txtLastName.Location = new System.Drawing.Point(229, 22);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(116, 22);
            this.txtLastName.TabIndex = 3;
            // 
            // cmbNameSuffix
            // 
            this.cmbNameSuffix.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbNameSuffix.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbNameSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "NameSuffix", true));
            this.cmbNameSuffix.DataSource = this.bsNameSuffix;
            this.cmbNameSuffix.DisplayMember = "NameSuffix";
            this.cmbNameSuffix.FormattingEnabled = true;
            this.cmbNameSuffix.Location = new System.Drawing.Point(351, 21);
            this.cmbNameSuffix.Name = "cmbNameSuffix";
            this.cmbNameSuffix.Size = new System.Drawing.Size(50, 24);
            this.cmbNameSuffix.TabIndex = 4;
            this.cmbNameSuffix.ValueMember = "NameSuffix";
            // 
            // bsNameSuffix
            // 
            this.bsNameSuffix.DataMember = "NameSuffix";
            this.bsNameSuffix.DataSource = this.dsPersonContactAuxData;
            // 
            // cmbPositionTitle
            // 
            this.cmbPositionTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbPositionTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbPositionTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "PositionTitle", true));
            this.cmbPositionTitle.DataSource = this.bsPositionTitle;
            this.cmbPositionTitle.DisplayMember = "PositionTitle";
            this.cmbPositionTitle.FormattingEnabled = true;
            this.cmbPositionTitle.Location = new System.Drawing.Point(65, 49);
            this.cmbPositionTitle.Name = "cmbPositionTitle";
            this.cmbPositionTitle.Size = new System.Drawing.Size(241, 24);
            this.cmbPositionTitle.TabIndex = 5;
            this.cmbPositionTitle.ValueMember = "PositionTitle";
            // 
            // bsPositionTitle
            // 
            this.bsPositionTitle.DataMember = "PositionTitle";
            this.bsPositionTitle.DataSource = this.dsPersonContactAuxData;
            // 
            // chkInterofficeMail
            // 
            this.chkInterofficeMail.AutoSize = true;
            this.chkInterofficeMail.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPerson, "InterofficeMail", true));
            this.chkInterofficeMail.Location = new System.Drawing.Point(284, 106);
            this.chkInterofficeMail.Margin = new System.Windows.Forms.Padding(0);
            this.chkInterofficeMail.Name = "chkInterofficeMail";
            this.chkInterofficeMail.Size = new System.Drawing.Size(82, 20);
            this.chkInterofficeMail.TabIndex = 11;
            this.chkInterofficeMail.Text = "Interoffice";
            this.chkInterofficeMail.UseVisualStyleBackColor = true;
            // 
            // mtbPhoneNumber
            // 
            this.mtbPhoneNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "PhoneNumber", true));
            this.mtbPhoneNumber.Location = new System.Drawing.Point(65, 78);
            this.mtbPhoneNumber.Mask = "(999) 000-0000";
            this.mtbPhoneNumber.Name = "mtbPhoneNumber";
            this.mtbPhoneNumber.Size = new System.Drawing.Size(100, 22);
            this.mtbPhoneNumber.TabIndex = 6;
            this.mtbPhoneNumber.Click += new System.EventHandler(this.mtbPhoneNumber_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "Email", true));
            this.txtEmail.Location = new System.Drawing.Point(65, 132);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(332, 22);
            this.txtEmail.TabIndex = 12;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(15, 81);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(45, 16);
            this.lblPhoneNumber.TabIndex = 21;
            this.lblPhoneNumber.Text = "Phone";
            this.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mtbCellNumber
            // 
            this.mtbCellNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "CellNumber", true));
            this.mtbCellNumber.Location = new System.Drawing.Point(297, 78);
            this.mtbCellNumber.Mask = "(999) 000-0000";
            this.mtbCellNumber.Name = "mtbCellNumber";
            this.mtbCellNumber.Size = new System.Drawing.Size(100, 22);
            this.mtbCellNumber.TabIndex = 8;
            this.mtbCellNumber.Click += new System.EventHandler(this.mtbCellNumber_Click);
            // 
            // lblCell
            // 
            this.lblCell.AutoSize = true;
            this.lblCell.Location = new System.Drawing.Point(266, 81);
            this.lblCell.Name = "lblCell";
            this.lblCell.Size = new System.Drawing.Size(30, 16);
            this.lblCell.TabIndex = 23;
            this.lblCell.Text = "Cell";
            // 
            // mtbFax
            // 
            this.mtbFax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "FaxNumber", true));
            this.mtbFax.Location = new System.Drawing.Point(65, 105);
            this.mtbFax.Mask = "(999) 000-0000";
            this.mtbFax.Name = "mtbFax";
            this.mtbFax.Size = new System.Drawing.Size(100, 22);
            this.mtbFax.TabIndex = 9;
            this.mtbFax.Click += new System.EventHandler(this.mtbFax_Click);
            // 
            // lblFaxNumber
            // 
            this.lblFaxNumber.AutoSize = true;
            this.lblFaxNumber.Location = new System.Drawing.Point(30, 108);
            this.lblFaxNumber.Name = "lblFaxNumber";
            this.lblFaxNumber.Size = new System.Drawing.Size(30, 16);
            this.lblFaxNumber.TabIndex = 25;
            this.lblFaxNumber.Text = "Fax";
            this.lblFaxNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhoneExt
            // 
            this.txtPhoneExt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "PhoneExt", true));
            this.txtPhoneExt.Location = new System.Drawing.Point(200, 78);
            this.txtPhoneExt.Name = "txtPhoneExt";
            this.txtPhoneExt.Size = new System.Drawing.Size(43, 22);
            this.txtPhoneExt.TabIndex = 7;
            // 
            // txtFaxExt
            // 
            this.txtFaxExt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "FaxExt", true));
            this.txtFaxExt.Location = new System.Drawing.Point(200, 105);
            this.txtFaxExt.Name = "txtFaxExt";
            this.txtFaxExt.Size = new System.Drawing.Size(43, 22);
            this.txtFaxExt.TabIndex = 10;
            // 
            // cmbAddressNo
            // 
            this.cmbAddressNo.FormattingEnabled = true;
            this.cmbAddressNo.Location = new System.Drawing.Point(222, 162);
            this.cmbAddressNo.Name = "cmbAddressNo";
            this.cmbAddressNo.Size = new System.Drawing.Size(56, 24);
            this.cmbAddressNo.TabIndex = 14;
            this.cmbAddressNo.Visible = false;
            // 
            // companyNoComboBox
            // 
            this.companyNoComboBox.FormattingEnabled = true;
            this.companyNoComboBox.Location = new System.Drawing.Point(222, 162);
            this.companyNoComboBox.Name = "companyNoComboBox";
            this.companyNoComboBox.Size = new System.Drawing.Size(56, 24);
            this.companyNoComboBox.TabIndex = 15;
            this.companyNoComboBox.Visible = false;
            // 
            // txtAddressNo
            // 
            this.txtAddressNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtAddressNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddressNo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtAddressNo.Location = new System.Drawing.Point(407, 164);
            this.txtAddressNo.Name = "txtAddressNo";
            this.txtAddressNo.Size = new System.Drawing.Size(36, 15);
            this.txtAddressNo.TabIndex = 32;
            this.txtAddressNo.TabStop = false;
            // 
            // txtCompanyNo
            // 
            this.txtCompanyNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtCompanyNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCompanyNo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtCompanyNo.Location = new System.Drawing.Point(407, 193);
            this.txtCompanyNo.Name = "txtCompanyNo";
            this.txtCompanyNo.Size = new System.Drawing.Size(36, 15);
            this.txtCompanyNo.TabIndex = 33;
            this.txtCompanyNo.TabStop = false;
            // 
            // lblContactId
            // 
            this.lblContactId.BackColor = System.Drawing.SystemColors.Control;
            this.lblContactId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "PersonNo", true));
            this.lblContactId.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblContactId.Location = new System.Drawing.Point(369, 108);
            this.lblContactId.Name = "lblContactId";
            this.lblContactId.Size = new System.Drawing.Size(10, 16);
            this.lblContactId.TabIndex = 35;
            // 
            // lblPerson
            // 
            this.lblPerson.AutoSize = true;
            this.lblPerson.Location = new System.Drawing.Point(312, 53);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(69, 16);
            this.lblPerson.TabIndex = 36;
            this.lblPerson.Text = "Person No";
            // 
            // lblPersonNo
            // 
            this.lblPersonNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "PersonNo", true));
            this.lblPersonNo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPersonNo.Location = new System.Drawing.Point(383, 49);
            this.lblPersonNo.Name = "lblPersonNo";
            this.lblPersonNo.Size = new System.Drawing.Size(56, 24);
            this.lblPersonNo.TabIndex = 37;
            this.lblPersonNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEmail
            // 
            this.btnEmail.AutoSize = true;
            this.btnEmail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmail.Location = new System.Drawing.Point(9, 130);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(51, 26);
            this.btnEmail.TabIndex = 38;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // bsSortGroup
            // 
            this.bsSortGroup.DataMember = "SortGroup";
            this.bsSortGroup.DataSource = this.dsPersonContactAuxData;
            // 
            // chkisCompletenessReviewEngineer
            // 
            this.chkisCompletenessReviewEngineer.AutoSize = true;
            this.chkisCompletenessReviewEngineer.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPerson, "IsCompletenessReviewEngineer", true));
            this.chkisCompletenessReviewEngineer.Location = new System.Drawing.Point(65, 192);
            this.chkisCompletenessReviewEngineer.Name = "chkisCompletenessReviewEngineer";
            this.chkisCompletenessReviewEngineer.Size = new System.Drawing.Size(213, 20);
            this.chkisCompletenessReviewEngineer.TabIndex = 40;
            this.chkisCompletenessReviewEngineer.Text = "Completeness Review Engineer:";
            this.chkisCompletenessReviewEngineer.UseVisualStyleBackColor = true;
            // 
            // isPermitComplianceAssigneeCheckBox
            // 
            this.isPermitComplianceAssigneeCheckBox.AutoSize = true;
            this.isPermitComplianceAssigneeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPerson, "IsPermitComplianceAssignee", true));
            this.isPermitComplianceAssigneeCheckBox.Location = new System.Drawing.Point(65, 219);
            this.isPermitComplianceAssigneeCheckBox.Name = "isPermitComplianceAssigneeCheckBox";
            this.isPermitComplianceAssigneeCheckBox.Size = new System.Drawing.Size(198, 20);
            this.isPermitComplianceAssigneeCheckBox.TabIndex = 41;
            this.isPermitComplianceAssigneeCheckBox.Text = "Permit Compliance Assignee:";
            this.isPermitComplianceAssigneeCheckBox.UseVisualStyleBackColor = true;
            // 
            // isInspectorCheckBox
            // 
            this.isInspectorCheckBox.AutoSize = true;
            this.isInspectorCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPerson, "IsInspector", true));
            this.isInspectorCheckBox.Location = new System.Drawing.Point(65, 246);
            this.isInspectorCheckBox.Name = "isInspectorCheckBox";
            this.isInspectorCheckBox.Size = new System.Drawing.Size(80, 20);
            this.isInspectorCheckBox.TabIndex = 42;
            this.isInspectorCheckBox.Text = "Inspector";
            this.isInspectorCheckBox.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(65, 272);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(366, 77);
            this.pictureBox1.TabIndex = 248;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsPerson, "SortGroup", true));
            this.comboBox1.DataSource = this.bsSortGroup;
            this.comboBox1.DisplayMember = "SortGroupName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(65, 161);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 249;
            this.comboBox1.ValueMember = "SortGroup";
            // 
            // usrPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.isInspectorCheckBox);
            this.Controls.Add(this.isPermitComplianceAssigneeCheckBox);
            this.Controls.Add(this.chkisCompletenessReviewEngineer);
            this.Controls.Add(sortGroupLabel);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.lblPersonNo);
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.lblContactId);
            this.Controls.Add(this.txtCompanyNo);
            this.Controls.Add(this.txtAddressNo);
            this.Controls.Add(this.companyNoComboBox);
            this.Controls.Add(this.cmbAddressNo);
            this.Controls.Add(this.lblFaxExt);
            this.Controls.Add(this.txtFaxExt);
            this.Controls.Add(this.lblPhoneExt);
            this.Controls.Add(this.txtPhoneExt);
            this.Controls.Add(this.mtbFax);
            this.Controls.Add(this.lblCell);
            this.Controls.Add(this.mtbCellNumber);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.mtbPhoneNumber);
            this.Controls.Add(this.chkInterofficeMail);
            this.Controls.Add(this.cmbPositionTitle);
            this.Controls.Add(this.familyTitleLabel);
            this.Controls.Add(this.cmbNameSuffix);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblMiddleName);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblTitleDesc);
            this.Controls.Add(this.companyNoLabel);
            this.Controls.Add(this.lblAddressNo);
            this.Controls.Add(this.lblFaxNumber);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblPositionTitle);
            this.Controls.Add(this.cmbNamePrefix);
            this.Name = "usrPerson";
            this.Size = new System.Drawing.Size(463, 365);
            this.Load += new System.EventHandler(this.usrPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNamePrefix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPersonContactAuxData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNameSuffix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPositionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSortGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.BindingSource bsPerson;
		protected System.Windows.Forms.ComboBox cmbNamePrefix;
		protected System.Windows.Forms.TextBox txtFirstName;
		protected System.Windows.Forms.TextBox txtMiddleName;
		protected System.Windows.Forms.TextBox txtLastName;
		protected System.Windows.Forms.ComboBox cmbNameSuffix;
		protected System.Windows.Forms.ComboBox cmbPositionTitle;
		protected System.Windows.Forms.CheckBox chkInterofficeMail;
		protected System.Windows.Forms.MaskedTextBox mtbPhoneNumber;
		protected System.Windows.Forms.TextBox txtEmail;
		protected System.Windows.Forms.BindingSource bsNamePrefix;
		protected System.Windows.Forms.BindingSource bsNameSuffix;
		protected System.Windows.Forms.BindingSource bsPositionTitle;
		protected System.Windows.Forms.Label lblPhoneNumber;
		protected System.Windows.Forms.MaskedTextBox mtbCellNumber;
		protected System.Windows.Forms.Label lblCell;
		protected System.Windows.Forms.MaskedTextBox mtbFax;
		protected System.Windows.Forms.Label lblFaxNumber;
		protected System.Windows.Forms.TextBox txtPhoneExt;
		protected System.Windows.Forms.TextBox txtFaxExt;
		protected System.Windows.Forms.TextBox txtAddressNo;
		protected System.Windows.Forms.TextBox txtCompanyNo;
		protected System.Windows.Forms.Label lblTitleDesc;
		protected System.Windows.Forms.Label firstNameLabel;
		protected System.Windows.Forms.Label lblMiddleName;
		protected System.Windows.Forms.Label lastNameLabel;
		protected System.Windows.Forms.Label familyTitleLabel;
        protected System.Windows.Forms.Label lblPositionTitle;
		protected System.Windows.Forms.Label lblPhoneExt;
		protected System.Windows.Forms.Label lblFaxExt;
		protected System.Windows.Forms.Label lblAddressNo;
		protected System.Windows.Forms.Label companyNoLabel;
		protected System.Windows.Forms.ComboBox cmbAddressNo;
		protected System.Windows.Forms.ComboBox companyNoComboBox;
		protected System.Windows.Forms.Label lblContactId;
		private SbcapcdOrg.Contact.PersonDataSet dsPerson;
		private SbcapcdOrg.Contact.ContactAuxDataSet dsPersonContactAuxData;
		protected System.Windows.Forms.Label lblPerson;
        protected System.Windows.Forms.Label lblPersonNo;
        protected System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.CheckBox chkisCompletenessReviewEngineer;
        private System.Windows.Forms.CheckBox isPermitComplianceAssigneeCheckBox;
        private System.Windows.Forms.CheckBox isInspectorCheckBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource bsSortGroup;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
