namespace SbcapcdOrg.Contact
{
	partial class usrContacts
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
			System.Windows.Forms.Label entityNoLabel;
			System.Windows.Forms.Label contactTypeIdLabel;
			System.Windows.Forms.Label addressNoLabel;
			System.Windows.Forms.Label companyNoLabel;
			System.Windows.Forms.Label contactDescLabel;
			System.Windows.Forms.Label employeeNoLabel;
			System.Windows.Forms.Label sortGroupLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrContacts));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.bnPerson = new System.Windows.Forms.BindingNavigator();
			this.bsPerson = new System.Windows.Forms.BindingSource();
			this.dsContacts = new SbcapcdOrg.Contact.ContactsDataSet();
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tscmbContactTypeCreate = new System.Windows.Forms.ToolStripComboBox();
			this.tsbtnAddNewSubscriptionPersonContact = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tstxtFilterPerson = new System.Windows.Forms.ToolStripTextBox();
			this.tsbtnUndoContactFilter = new System.Windows.Forms.ToolStripButton();
			this.tsbtnDeletePerson = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.dgvPerson = new System.Windows.Forms.DataGridView();
			this.personNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.scContracts = new SbcapcdOrg.ControlLibrary.usrSplitContainer();
			this.splitContainer1 = new SbcapcdOrg.ControlLibrary.usrSplitContainer();
			this.dgvContacts = new System.Windows.Forms.DataGridView();
			this.PrimaryContact = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CcContact = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.bsContactType = new System.Windows.Forms.BindingSource();
			this.dsContactsAux = new SbcapcdOrg.Contact.ContactsAuxDataSet();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.bsFacility = new System.Windows.Forms.BindingSource();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.bsCompanyDgvContacts = new System.Windows.Forms.BindingSource();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bsContact = new System.Windows.Forms.BindingSource();
			this.bnContact = new System.Windows.Forms.BindingNavigator();
			this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAddNewSubscriptionContactForPerson = new System.Windows.Forms.ToolStripButton();
			this.tsbtnUndoContactChanges = new System.Windows.Forms.ToolStripButton();
			this.tsbtnSaveContact = new System.Windows.Forms.ToolStripButton();
			this.tsbtnDeleteContact = new System.Windows.Forms.ToolStripButton();
			this.tslblContactHasChanges = new System.Windows.Forms.ToolStripLabel();
			this.lblContactId2 = new System.Windows.Forms.Label();
			this.txtFilterAddress = new System.Windows.Forms.TextBox();
			this.lblPersonNo = new System.Windows.Forms.Label();
			this.cmbContactType = new System.Windows.Forms.ComboBox();
			this.cmbCompany = new System.Windows.Forms.ComboBox();
			this.bsCompany = new System.Windows.Forms.BindingSource();
			this.cmbAddress = new System.Windows.Forms.ComboBox();
			this.lblContactId = new System.Windows.Forms.Label();
			this.tbcPersonAddress = new System.Windows.Forms.TabControl();
			this.tabPerson = new System.Windows.Forms.TabPage();
			this.pnlPerson = new System.Windows.Forms.Panel();
			this.btnEmail = new System.Windows.Forms.Button();
			this.pnlEmployee = new System.Windows.Forms.Panel();
			this.sortGroupComboBox = new System.Windows.Forms.ComboBox();
			this.bsSortGroup = new System.Windows.Forms.BindingSource();
			this.cmbEmployee = new System.Windows.Forms.ComboBox();
			this.bsEmployee = new System.Windows.Forms.BindingSource();
			this.chkIsCompletenessReviewEngineer = new System.Windows.Forms.CheckBox();
			this.cmbNamePrefix = new System.Windows.Forms.ComboBox();
			this.bsNamePrefix = new System.Windows.Forms.BindingSource();
			this.dsContactAux = new SbcapcdOrg.Contact.ContactAuxDataSet();
			this.lblPositionTitle = new System.Windows.Forms.Label();
			this.lblPhoneNumber = new System.Windows.Forms.Label();
			this.lblFaxNumber = new System.Windows.Forms.Label();
			this.txtPersonNo = new System.Windows.Forms.TextBox();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.txtMiddleName = new System.Windows.Forms.TextBox();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.cmbNameSuffix = new System.Windows.Forms.ComboBox();
			this.bsNameSuffix = new System.Windows.Forms.BindingSource();
			this.cmbPositionTitle = new System.Windows.Forms.ComboBox();
			this.bsPositionTitle = new System.Windows.Forms.BindingSource();
			this.familyTitleLabel = new System.Windows.Forms.Label();
			this.chkInterofficeMail = new System.Windows.Forms.CheckBox();
			this.lastNameLabel = new System.Windows.Forms.Label();
			this.mtbPhoneNumber = new System.Windows.Forms.MaskedTextBox();
			this.lblMiddleName = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.firstNameLabel = new System.Windows.Forms.Label();
			this.mtbCellNumber = new System.Windows.Forms.MaskedTextBox();
			this.lblTitleDesc = new System.Windows.Forms.Label();
			this.lblCell = new System.Windows.Forms.Label();
			this.mtbFax = new System.Windows.Forms.MaskedTextBox();
			this.lblFaxExt = new System.Windows.Forms.Label();
			this.txtPhoneExt = new System.Windows.Forms.TextBox();
			this.txtFaxExt = new System.Windows.Forms.TextBox();
			this.lblPhoneExt = new System.Windows.Forms.Label();
			this.tabAddress = new System.Windows.Forms.TabPage();
			this.pnlAddress = new System.Windows.Forms.Panel();
			this.Address = new SbcapcdOrg.Address.usrAddress();
			this.cmbEntity = new System.Windows.Forms.ComboBox();
			this.contactDescTextBox = new System.Windows.Forms.TextBox();
			this.txtAddressNo = new System.Windows.Forms.TextBox();
			this.imageList1 = new System.Windows.Forms.ImageList();
			this.bsUspsSecondaryUnitDesignator = new System.Windows.Forms.BindingSource();
			this.bsUspsStatePossession = new System.Windows.Forms.BindingSource();
			this.bsUspsStreetSuffix = new System.Windows.Forms.BindingSource();
			this.bsSbcCities = new System.Windows.Forms.BindingSource();
			this.toolTip1 = new System.Windows.Forms.ToolTip();
			this.personDataSet = new SbcapcdOrg.Contact.PersonDataSet();
			this.personBindingSource = new System.Windows.Forms.BindingSource();
			this.bsContactTypeCreate = new System.Windows.Forms.BindingSource();
			entityNoLabel = new System.Windows.Forms.Label();
			contactTypeIdLabel = new System.Windows.Forms.Label();
			addressNoLabel = new System.Windows.Forms.Label();
			companyNoLabel = new System.Windows.Forms.Label();
			contactDescLabel = new System.Windows.Forms.Label();
			employeeNoLabel = new System.Windows.Forms.Label();
			sortGroupLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.bnPerson)).BeginInit();
			this.bnPerson.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsPerson)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsContacts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scContracts)).BeginInit();
			this.scContracts.Panel1.SuspendLayout();
			this.scContracts.Panel2.SuspendLayout();
			this.scContracts.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsContactType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsContactsAux)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsFacility)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsCompanyDgvContacts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsContact)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bnContact)).BeginInit();
			this.bnContact.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsCompany)).BeginInit();
			this.tbcPersonAddress.SuspendLayout();
			this.tabPerson.SuspendLayout();
			this.pnlPerson.SuspendLayout();
			this.pnlEmployee.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsSortGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsEmployee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsNamePrefix)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsContactAux)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsNameSuffix)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsPositionTitle)).BeginInit();
			this.tabAddress.SuspendLayout();
			this.pnlAddress.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsUspsSecondaryUnitDesignator)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsUspsStatePossession)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsUspsStreetSuffix)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsSbcCities)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsContactTypeCreate)).BeginInit();
			this.SuspendLayout();
			// 
			// entityNoLabel
			// 
			entityNoLabel.AutoSize = true;
			entityNoLabel.Location = new System.Drawing.Point(310, 39);
			entityNoLabel.Name = "entityNoLabel";
			entityNoLabel.Size = new System.Drawing.Size(42, 16);
			entityNoLabel.TabIndex = 84;
			entityNoLabel.Text = "Entity";
			entityNoLabel.Visible = false;
			// 
			// contactTypeIdLabel
			// 
			contactTypeIdLabel.AutoSize = true;
			contactTypeIdLabel.Location = new System.Drawing.Point(30, 8);
			contactTypeIdLabel.Name = "contactTypeIdLabel";
			contactTypeIdLabel.Size = new System.Drawing.Size(35, 16);
			contactTypeIdLabel.TabIndex = 85;
			contactTypeIdLabel.Text = "Type";
			contactTypeIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// addressNoLabel
			// 
			addressNoLabel.AutoSize = true;
			addressNoLabel.Location = new System.Drawing.Point(10, 71);
			addressNoLabel.Name = "addressNoLabel";
			addressNoLabel.Size = new System.Drawing.Size(56, 16);
			addressNoLabel.TabIndex = 86;
			addressNoLabel.Text = "Address";
			addressNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// companyNoLabel
			// 
			companyNoLabel.AutoSize = true;
			companyNoLabel.Location = new System.Drawing.Point(3, 39);
			companyNoLabel.Name = "companyNoLabel";
			companyNoLabel.Size = new System.Drawing.Size(63, 16);
			companyNoLabel.TabIndex = 87;
			companyNoLabel.Text = "Company";
			companyNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// contactDescLabel
			// 
			contactDescLabel.AutoSize = true;
			contactDescLabel.Location = new System.Drawing.Point(266, 8);
			contactDescLabel.Name = "contactDescLabel";
			contactDescLabel.Size = new System.Drawing.Size(38, 16);
			contactDescLabel.TabIndex = 88;
			contactDescLabel.Text = "Desc";
			// 
			// employeeNoLabel
			// 
			employeeNoLabel.AutoSize = true;
			employeeNoLabel.Location = new System.Drawing.Point(8, 9);
			employeeNoLabel.Name = "employeeNoLabel";
			employeeNoLabel.Size = new System.Drawing.Size(66, 16);
			employeeNoLabel.TabIndex = 62;
			employeeNoLabel.Text = "Employee";
			// 
			// sortGroupLabel
			// 
			sortGroupLabel.AutoSize = true;
			sortGroupLabel.Location = new System.Drawing.Point(236, 39);
			sortGroupLabel.Name = "sortGroupLabel";
			sortGroupLabel.Size = new System.Drawing.Size(75, 16);
			sortGroupLabel.TabIndex = 64;
			sortGroupLabel.Text = "Sort Group:";
			// 
			// bnPerson
			// 
			this.bnPerson.AddNewItem = null;
			this.bnPerson.BindingSource = this.bsPerson;
			this.bnPerson.CountItem = this.bindingNavigatorCountItem;
			this.bnPerson.DeleteItem = null;
			this.bnPerson.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bnPerson.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.bnPerson.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.tscmbContactTypeCreate,
            this.tsbtnAddNewSubscriptionPersonContact,
            this.toolStripSeparator1,
            this.tstxtFilterPerson,
            this.tsbtnUndoContactFilter,
            this.tsbtnDeletePerson,
            this.toolStripSeparator2});
			this.bnPerson.Location = new System.Drawing.Point(0, 0);
			this.bnPerson.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bnPerson.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bnPerson.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bnPerson.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bnPerson.Name = "bnPerson";
			this.bnPerson.PositionItem = this.bindingNavigatorPositionItem;
			this.bnPerson.Size = new System.Drawing.Size(950, 25);
			this.bnPerson.TabIndex = 0;
			this.bnPerson.Text = "bindingNavigator1";
			// 
			// bsPerson
			// 
			this.bsPerson.DataMember = "Person";
			this.bsPerson.DataSource = this.dsContacts;
			this.bsPerson.Sort = "LastName";
			this.bsPerson.CurrentChanged += new System.EventHandler(this.bsPerson_CurrentChanged);
			// 
			// dsContacts
			// 
			this.dsContacts.DataSetName = "ContactsDataSet";
			this.dsContacts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.AutoSize = false;
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(65, 22);
			this.bindingNavigatorCountItem.Text = "of {0}";
			this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
			// 
			// bindingNavigatorMoveFirstItem
			// 
			this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
			this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
			this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveFirstItem.Text = "Move first";
			// 
			// bindingNavigatorMovePreviousItem
			// 
			this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
			this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
			this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMovePreviousItem.Text = "Move previous";
			// 
			// bindingNavigatorPositionItem
			// 
			this.bindingNavigatorPositionItem.AccessibleName = "Position";
			this.bindingNavigatorPositionItem.AutoSize = false;
			this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(58, 22);
			this.bindingNavigatorPositionItem.Text = "0";
			this.bindingNavigatorPositionItem.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.bindingNavigatorPositionItem.ToolTipText = "Current position";
			// 
			// bindingNavigatorMoveNextItem
			// 
			this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
			this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
			this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveNextItem.Text = "Move next";
			// 
			// bindingNavigatorMoveLastItem
			// 
			this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
			this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
			this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveLastItem.Text = "Move last";
			// 
			// bindingNavigatorSeparator2
			// 
			this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
			this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tscmbContactTypeCreate
			// 
			this.tscmbContactTypeCreate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscmbContactTypeCreate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tscmbContactTypeCreate.Name = "tscmbContactTypeCreate";
			this.tscmbContactTypeCreate.Size = new System.Drawing.Size(121, 25);
			// 
			// tsbtnAddNewSubscriptionPersonContact
			// 
			this.tsbtnAddNewSubscriptionPersonContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnAddNewSubscriptionPersonContact.Enabled = false;
			this.tsbtnAddNewSubscriptionPersonContact.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddNewSubscriptionPersonContact.Image")));
			this.tsbtnAddNewSubscriptionPersonContact.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddNewSubscriptionPersonContact.Name = "tsbtnAddNewSubscriptionPersonContact";
			this.tsbtnAddNewSubscriptionPersonContact.Size = new System.Drawing.Size(23, 22);
			this.tsbtnAddNewSubscriptionPersonContact.Text = "toolStripButton2";
			this.tsbtnAddNewSubscriptionPersonContact.ToolTipText = "Add New Person and Contact of the selected type";
			this.tsbtnAddNewSubscriptionPersonContact.Click += new System.EventHandler(this.tsbtnAddNewSubscriptionPersonContact_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tstxtFilterPerson
			// 
			this.tstxtFilterPerson.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tstxtFilterPerson.Name = "tstxtFilterPerson";
			this.tstxtFilterPerson.Size = new System.Drawing.Size(116, 25);
			this.tstxtFilterPerson.ToolTipText = "Filter Contacts";
			this.tstxtFilterPerson.TextChanged += new System.EventHandler(this.tstxtFilterPerson_TextChanged);
			// 
			// tsbtnUndoContactFilter
			// 
			this.tsbtnUndoContactFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnUndoContactFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUndoContactFilter.Image")));
			this.tsbtnUndoContactFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnUndoContactFilter.Name = "tsbtnUndoContactFilter";
			this.tsbtnUndoContactFilter.Size = new System.Drawing.Size(23, 22);
			this.tsbtnUndoContactFilter.Click += new System.EventHandler(this.tsbtnUndoContactFilter_Click);
			// 
			// tsbtnDeletePerson
			// 
			this.tsbtnDeletePerson.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnDeletePerson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnDeletePerson.Enabled = false;
			this.tsbtnDeletePerson.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDeletePerson.Image")));
			this.tsbtnDeletePerson.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDeletePerson.Name = "tsbtnDeletePerson";
			this.tsbtnDeletePerson.Size = new System.Drawing.Size(23, 22);
			this.tsbtnDeletePerson.ToolTipText = "Delete Person";
			this.tsbtnDeletePerson.Click += new System.EventHandler(this.tsbtnDeletePerson_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// dgvPerson
			// 
			this.dgvPerson.AutoGenerateColumns = false;
			this.dgvPerson.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personNoDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn});
			this.dgvPerson.DataSource = this.bsPerson;
			this.dgvPerson.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvPerson.Location = new System.Drawing.Point(0, 0);
			this.dgvPerson.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dgvPerson.Name = "dgvPerson";
			this.dgvPerson.RowHeadersVisible = false;
			this.dgvPerson.RowHeadersWidth = 25;
			this.dgvPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvPerson.Size = new System.Drawing.Size(300, 659);
			this.dgvPerson.TabIndex = 1;
			this.dgvPerson.TabStop = false;
			// 
			// personNoDataGridViewTextBoxColumn
			// 
			this.personNoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.personNoDataGridViewTextBoxColumn.DataPropertyName = "PersonNo";
			this.personNoDataGridViewTextBoxColumn.HeaderText = "Person No";
			this.personNoDataGridViewTextBoxColumn.Name = "personNoDataGridViewTextBoxColumn";
			this.personNoDataGridViewTextBoxColumn.ReadOnly = true;
			this.personNoDataGridViewTextBoxColumn.Width = 65;
			// 
			// firstNameDataGridViewTextBoxColumn
			// 
			this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
			this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
			this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
			this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// lastNameDataGridViewTextBoxColumn
			// 
			this.lastNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
			this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
			this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
			this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// scContracts
			// 
			this.scContracts.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.scContracts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scContracts.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.scContracts.Location = new System.Drawing.Point(0, 25);
			this.scContracts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.scContracts.Name = "scContracts";
			// 
			// scContracts.Panel1
			// 
			this.scContracts.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.scContracts.Panel1.Controls.Add(this.dgvPerson);
			// 
			// scContracts.Panel2
			// 
			this.scContracts.Panel2.AutoScroll = true;
			this.scContracts.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.scContracts.Panel2.Controls.Add(this.splitContainer1);
			this.scContracts.Size = new System.Drawing.Size(950, 659);
			this.scContracts.SplitterDistance = 300;
			this.scContracts.SplitterWidth = 2;
			this.scContracts.TabIndex = 2;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer1.Panel1.Controls.Add(this.dgvContacts);
			this.splitContainer1.Panel1.Controls.Add(this.bnContact);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.AutoScroll = true;
			this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer1.Panel2.Controls.Add(this.lblContactId2);
			this.splitContainer1.Panel2.Controls.Add(this.txtFilterAddress);
			this.splitContainer1.Panel2.Controls.Add(this.lblPersonNo);
			this.splitContainer1.Panel2.Controls.Add(this.cmbContactType);
			this.splitContainer1.Panel2.Controls.Add(this.cmbCompany);
			this.splitContainer1.Panel2.Controls.Add(this.cmbAddress);
			this.splitContainer1.Panel2.Controls.Add(entityNoLabel);
			this.splitContainer1.Panel2.Controls.Add(this.lblContactId);
			this.splitContainer1.Panel2.Controls.Add(this.tbcPersonAddress);
			this.splitContainer1.Panel2.Controls.Add(this.cmbEntity);
			this.splitContainer1.Panel2.Controls.Add(this.contactDescTextBox);
			this.splitContainer1.Panel2.Controls.Add(this.txtAddressNo);
			this.splitContainer1.Panel2.Controls.Add(contactDescLabel);
			this.splitContainer1.Panel2.Controls.Add(contactTypeIdLabel);
			this.splitContainer1.Panel2.Controls.Add(companyNoLabel);
			this.splitContainer1.Panel2.Controls.Add(addressNoLabel);
			this.splitContainer1.Size = new System.Drawing.Size(648, 659);
			this.splitContainer1.SplitterDistance = 237;
			this.splitContainer1.SplitterWidth = 2;
			this.splitContainer1.TabIndex = 98;
			// 
			// dgvContacts
			// 
			this.dgvContacts.AllowUserToAddRows = false;
			this.dgvContacts.AllowUserToDeleteRows = false;
			this.dgvContacts.AllowUserToOrderColumns = true;
			this.dgvContacts.AllowUserToResizeRows = false;
			this.dgvContacts.AutoGenerateColumns = false;
			this.dgvContacts.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvContacts.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvContacts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvContacts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrimaryContact,
            this.CcContact,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.Active});
			this.dgvContacts.DataSource = this.bsContact;
			this.dgvContacts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvContacts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvContacts.Location = new System.Drawing.Point(0, 25);
			this.dgvContacts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dgvContacts.MultiSelect = false;
			this.dgvContacts.Name = "dgvContacts";
			this.dgvContacts.RowHeadersWidth = 25;
			this.dgvContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvContacts.ShowEditingIcon = false;
			this.dgvContacts.Size = new System.Drawing.Size(648, 212);
			this.dgvContacts.TabIndex = 62;
			this.dgvContacts.TabStop = false;
			this.dgvContacts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvContacts_DataBindingComplete);
			this.dgvContacts.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvContacts_DataError);
			this.dgvContacts.Sorted += new System.EventHandler(this.dgvContacts_Sorted);
			// 
			// PrimaryContact
			// 
			this.PrimaryContact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.PrimaryContact.DataPropertyName = "PrimaryContact";
			this.PrimaryContact.HeaderText = "PC";
			this.PrimaryContact.Name = "PrimaryContact";
			this.PrimaryContact.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.PrimaryContact.Width = 50;
			// 
			// CcContact
			// 
			this.CcContact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.CcContact.DataPropertyName = "CcContact";
			this.CcContact.HeaderText = "CC";
			this.CcContact.Name = "CcContact";
			this.CcContact.Width = 50;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.AutoComplete = false;
			this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn4.DataPropertyName = "ContactTypeId";
			this.dataGridViewTextBoxColumn4.DataSource = this.bsContactType;
			dataGridViewCellStyle1.NullValue = "-";
			this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewTextBoxColumn4.DisplayMember = "ContactTypeDescription";
			this.dataGridViewTextBoxColumn4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
			this.dataGridViewTextBoxColumn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.dataGridViewTextBoxColumn4.HeaderText = "Type";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn4.ValueMember = "ContactTypeId";
			this.dataGridViewTextBoxColumn4.Width = 75;
			// 
			// bsContactType
			// 
			this.bsContactType.DataMember = "ContactType";
			this.bsContactType.DataSource = this.dsContactsAux;
			// 
			// dsContactsAux
			// 
			this.dsContactsAux.DataSetName = "ContactsAuxDataSet";
			this.dsContactsAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "EntityNo";
			this.dataGridViewTextBoxColumn3.DataSource = this.bsFacility;
			dataGridViewCellStyle2.NullValue = "-";
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewTextBoxColumn3.DisplayMember = "FacilityName";
			this.dataGridViewTextBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
			this.dataGridViewTextBoxColumn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.dataGridViewTextBoxColumn3.HeaderText = "Entity";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn3.ValueMember = "FacilityNo";
			this.dataGridViewTextBoxColumn3.Width = 250;
			// 
			// bsFacility
			// 
			this.bsFacility.DataMember = "Facility";
			this.bsFacility.DataSource = this.dsContactsAux;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn7.DataPropertyName = "CompanyNo";
			this.dataGridViewTextBoxColumn7.DataSource = this.bsCompanyDgvContacts;
			dataGridViewCellStyle3.NullValue = "-";
			this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewTextBoxColumn7.DisplayMember = "CompanyName";
			this.dataGridViewTextBoxColumn7.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
			this.dataGridViewTextBoxColumn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.dataGridViewTextBoxColumn7.HeaderText = "Company";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn7.ValueMember = "CompanyNo";
			// 
			// bsCompanyDgvContacts
			// 
			this.bsCompanyDgvContacts.DataMember = "Company";
			this.bsCompanyDgvContacts.DataSource = this.dsContactsAux;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "ContactDesc";
			this.dataGridViewTextBoxColumn8.HeaderText = "Desc";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.Width = 63;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "AddressNo";
			this.dataGridViewTextBoxColumn6.HeaderText = "Address";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.Visible = false;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "EntityId";
			this.dataGridViewTextBoxColumn2.HeaderText = "EntityId";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Visible = false;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "ContactId";
			this.dataGridViewTextBoxColumn1.HeaderText = "ContactId";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Visible = false;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn5.DataPropertyName = "PersonNo";
			this.dataGridViewTextBoxColumn5.DataSource = this.bsPerson;
			dataGridViewCellStyle4.NullValue = "-";
			this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewTextBoxColumn5.DisplayMember = "LastName";
			this.dataGridViewTextBoxColumn5.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
			this.dataGridViewTextBoxColumn5.HeaderText = "PersonNo";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn5.ValueMember = "PersonNo";
			this.dataGridViewTextBoxColumn5.Visible = false;
			// 
			// Active
			// 
			this.Active.DataPropertyName = "Active";
			this.Active.HeaderText = "Active";
			this.Active.Name = "Active";
			this.Active.Visible = false;
			// 
			// bsContact
			// 
			this.bsContact.DataMember = "Persons_Contacts";
			this.bsContact.DataSource = this.bsPerson;
			this.bsContact.Sort = "ContactTypeAbbrev";
			this.bsContact.CurrentChanged += new System.EventHandler(this.bsContact_CurrentChanged);
			// 
			// bnContact
			// 
			this.bnContact.AddNewItem = null;
			this.bnContact.BindingSource = this.bsContact;
			this.bnContact.CountItem = this.bindingNavigatorCountItem1;
			this.bnContact.DeleteItem = null;
			this.bnContact.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bnContact.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.bnContact.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.tsbtnAddNewSubscriptionContactForPerson,
            this.tsbtnUndoContactChanges,
            this.tsbtnSaveContact,
            this.tsbtnDeleteContact,
            this.tslblContactHasChanges});
			this.bnContact.Location = new System.Drawing.Point(0, 0);
			this.bnContact.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
			this.bnContact.MoveLastItem = this.bindingNavigatorMoveLastItem1;
			this.bnContact.MoveNextItem = this.bindingNavigatorMoveNextItem1;
			this.bnContact.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
			this.bnContact.Name = "bnContact";
			this.bnContact.PositionItem = this.bindingNavigatorPositionItem1;
			this.bnContact.Size = new System.Drawing.Size(648, 25);
			this.bnContact.TabIndex = 84;
			this.bnContact.Text = "bindingNavigator1";
			// 
			// bindingNavigatorCountItem1
			// 
			this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
			this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(37, 22);
			this.bindingNavigatorCountItem1.Text = "of {0}";
			this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
			// 
			// bindingNavigatorMoveFirstItem1
			// 
			this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
			this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
			this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveFirstItem1.Text = "Move first";
			// 
			// bindingNavigatorMovePreviousItem1
			// 
			this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
			this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
			this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
			// 
			// bindingNavigatorSeparator3
			// 
			this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
			this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorPositionItem1
			// 
			this.bindingNavigatorPositionItem1.AccessibleName = "Position";
			this.bindingNavigatorPositionItem1.AutoSize = false;
			this.bindingNavigatorPositionItem1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
			this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(25, 22);
			this.bindingNavigatorPositionItem1.Text = "0";
			this.bindingNavigatorPositionItem1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
			// 
			// bindingNavigatorSeparator4
			// 
			this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
			this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorMoveNextItem1
			// 
			this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
			this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
			this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveNextItem1.Text = "Move next";
			// 
			// bindingNavigatorMoveLastItem1
			// 
			this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
			this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
			this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveLastItem1.Text = "Move last";
			// 
			// bindingNavigatorSeparator5
			// 
			this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
			this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnAddNewSubscriptionContactForPerson
			// 
			this.tsbtnAddNewSubscriptionContactForPerson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnAddNewSubscriptionContactForPerson.Enabled = false;
			this.tsbtnAddNewSubscriptionContactForPerson.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddNewSubscriptionContactForPerson.Image")));
			this.tsbtnAddNewSubscriptionContactForPerson.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddNewSubscriptionContactForPerson.Name = "tsbtnAddNewSubscriptionContactForPerson";
			this.tsbtnAddNewSubscriptionContactForPerson.Size = new System.Drawing.Size(23, 22);
			this.tsbtnAddNewSubscriptionContactForPerson.ToolTipText = "Add New Subscription Contact for Person";
			this.tsbtnAddNewSubscriptionContactForPerson.Click += new System.EventHandler(this.tsbtnAddNewSubscriptionContactForPerson_Click);
			// 
			// tsbtnUndoContactChanges
			// 
			this.tsbtnUndoContactChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnUndoContactChanges.Enabled = false;
			this.tsbtnUndoContactChanges.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUndoContactChanges.Image")));
			this.tsbtnUndoContactChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnUndoContactChanges.Name = "tsbtnUndoContactChanges";
			this.tsbtnUndoContactChanges.Size = new System.Drawing.Size(23, 22);
			this.tsbtnUndoContactChanges.Text = "toolStripButton1";
			this.tsbtnUndoContactChanges.Click += new System.EventHandler(this.tsbtnUndoContactChanges_Click);
			// 
			// tsbtnSaveContact
			// 
			this.tsbtnSaveContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSaveContact.Enabled = false;
			this.tsbtnSaveContact.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaveContact.Image")));
			this.tsbtnSaveContact.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSaveContact.Name = "tsbtnSaveContact";
			this.tsbtnSaveContact.Size = new System.Drawing.Size(23, 22);
			this.tsbtnSaveContact.ToolTipText = "Save";
			this.tsbtnSaveContact.Click += new System.EventHandler(this.tsbtnSaveContact_Click);
			// 
			// tsbtnDeleteContact
			// 
			this.tsbtnDeleteContact.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnDeleteContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnDeleteContact.Enabled = false;
			this.tsbtnDeleteContact.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDeleteContact.Image")));
			this.tsbtnDeleteContact.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDeleteContact.Name = "tsbtnDeleteContact";
			this.tsbtnDeleteContact.Size = new System.Drawing.Size(23, 22);
			this.tsbtnDeleteContact.ToolTipText = "Delete Contact";
			this.tsbtnDeleteContact.Click += new System.EventHandler(this.tsbtnDeleteContact_Click);
			// 
			// tslblContactHasChanges
			// 
			this.tslblContactHasChanges.ForeColor = System.Drawing.Color.Red;
			this.tslblContactHasChanges.Name = "tslblContactHasChanges";
			this.tslblContactHasChanges.Size = new System.Drawing.Size(131, 22);
			this.tslblContactHasChanges.Text = "Contact has changes";
			this.tslblContactHasChanges.Visible = false;
			// 
			// lblContactId2
			// 
			this.lblContactId2.AutoSize = true;
			this.lblContactId2.ForeColor = System.Drawing.SystemColors.GrayText;
			this.lblContactId2.Location = new System.Drawing.Point(449, 8);
			this.lblContactId2.Name = "lblContactId2";
			this.lblContactId2.Size = new System.Drawing.Size(69, 16);
			this.lblContactId2.TabIndex = 99;
			this.lblContactId2.Text = "Contact ID";
			// 
			// txtFilterAddress
			// 
			this.txtFilterAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFilterAddress.Location = new System.Drawing.Point(313, 67);
			this.txtFilterAddress.Name = "txtFilterAddress";
			this.txtFilterAddress.Size = new System.Drawing.Size(100, 22);
			this.txtFilterAddress.TabIndex = 94;
			this.txtFilterAddress.TabStop = false;
			this.toolTip1.SetToolTip(this.txtFilterAddress, "Filter Address");
			this.txtFilterAddress.TextChanged += new System.EventHandler(this.txtFilterAddress_TextChanged);
			// 
			// lblPersonNo
			// 
			this.lblPersonNo.AutoSize = true;
			this.lblPersonNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "PersonNo", true));
			this.lblPersonNo.Location = new System.Drawing.Point(316, 68);
			this.lblPersonNo.Name = "lblPersonNo";
			this.lblPersonNo.Size = new System.Drawing.Size(0, 16);
			this.lblPersonNo.TabIndex = 98;
			this.toolTip1.SetToolTip(this.lblPersonNo, "PersonNo");
			// 
			// cmbContactType
			// 
			this.cmbContactType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsContact, "ContactTypeId", true));
			this.cmbContactType.DataSource = this.bsContactType;
			this.cmbContactType.DisplayMember = "ContactTypeDescription";
			this.cmbContactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbContactType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbContactType.FormattingEnabled = true;
			this.cmbContactType.Location = new System.Drawing.Point(65, 4);
			this.cmbContactType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cmbContactType.Name = "cmbContactType";
			this.cmbContactType.Size = new System.Drawing.Size(156, 24);
			this.cmbContactType.TabIndex = 0;
			this.cmbContactType.ValueMember = "ContactTypeId";
			// 
			// cmbCompany
			// 
			this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cmbCompany.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsContact, "CompanyNo", true));
			this.cmbCompany.DataSource = this.bsCompany;
			this.cmbCompany.DisplayMember = "CompanyName";
			this.cmbCompany.FormattingEnabled = true;
			this.cmbCompany.Location = new System.Drawing.Point(65, 35);
			this.cmbCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cmbCompany.Name = "cmbCompany";
			this.cmbCompany.Size = new System.Drawing.Size(235, 24);
			this.cmbCompany.TabIndex = 1;
			this.cmbCompany.ValueMember = "CompanyNo";
			// 
			// bsCompany
			// 
			this.bsCompany.DataMember = "Company";
			this.bsCompany.DataSource = this.dsContactsAux;
			this.bsCompany.Sort = "CompanyName";
			// 
			// cmbAddress
			// 
			this.cmbAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.cmbAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cmbAddress.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsContact, "AddressNo", true));
			this.cmbAddress.DisplayMember = "AddressNo";
			this.cmbAddress.FormattingEnabled = true;
			this.cmbAddress.Location = new System.Drawing.Point(65, 66);
			this.cmbAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cmbAddress.Name = "cmbAddress";
			this.cmbAddress.Size = new System.Drawing.Size(235, 24);
			this.cmbAddress.TabIndex = 2;
			this.cmbAddress.ValueMember = "AddressNo";
			this.cmbAddress.SelectionChangeCommitted += new System.EventHandler(this.cmbAddress_SelectionChangeCommitted);
			// 
			// lblContactId
			// 
			this.lblContactId.AutoSize = true;
			this.lblContactId.BackColor = System.Drawing.SystemColors.Control;
			this.lblContactId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContact, "ContactId", true));
			this.lblContactId.ForeColor = System.Drawing.SystemColors.GrayText;
			this.lblContactId.Location = new System.Drawing.Point(522, 8);
			this.lblContactId.Name = "lblContactId";
			this.lblContactId.Size = new System.Drawing.Size(0, 16);
			this.lblContactId.TabIndex = 57;
			this.toolTip1.SetToolTip(this.lblContactId, "Contact ID");
			// 
			// tbcPersonAddress
			// 
			this.tbcPersonAddress.Appearance = System.Windows.Forms.TabAppearance.Buttons;
			this.tbcPersonAddress.Controls.Add(this.tabPerson);
			this.tbcPersonAddress.Controls.Add(this.tabAddress);
			this.tbcPersonAddress.Location = new System.Drawing.Point(9, 97);
			this.tbcPersonAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbcPersonAddress.Name = "tbcPersonAddress";
			this.tbcPersonAddress.SelectedIndex = 0;
			this.tbcPersonAddress.Size = new System.Drawing.Size(509, 319);
			this.tbcPersonAddress.TabIndex = 92;
			// 
			// tabPerson
			// 
			this.tabPerson.AutoScroll = true;
			this.tabPerson.Controls.Add(this.pnlPerson);
			this.tabPerson.Location = new System.Drawing.Point(4, 28);
			this.tabPerson.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPerson.Name = "tabPerson";
			this.tabPerson.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPerson.Size = new System.Drawing.Size(501, 287);
			this.tabPerson.TabIndex = 0;
			this.tabPerson.Text = "Person";
			this.tabPerson.UseVisualStyleBackColor = true;
			// 
			// pnlPerson
			// 
			this.pnlPerson.AutoScroll = true;
			this.pnlPerson.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnlPerson.Controls.Add(this.btnEmail);
			this.pnlPerson.Controls.Add(this.pnlEmployee);
			this.pnlPerson.Controls.Add(this.cmbNamePrefix);
			this.pnlPerson.Controls.Add(this.lblPositionTitle);
			this.pnlPerson.Controls.Add(this.lblPhoneNumber);
			this.pnlPerson.Controls.Add(this.lblFaxNumber);
			this.pnlPerson.Controls.Add(this.txtPersonNo);
			this.pnlPerson.Controls.Add(this.txtFirstName);
			this.pnlPerson.Controls.Add(this.txtMiddleName);
			this.pnlPerson.Controls.Add(this.txtLastName);
			this.pnlPerson.Controls.Add(this.cmbNameSuffix);
			this.pnlPerson.Controls.Add(this.cmbPositionTitle);
			this.pnlPerson.Controls.Add(this.familyTitleLabel);
			this.pnlPerson.Controls.Add(this.chkInterofficeMail);
			this.pnlPerson.Controls.Add(this.lastNameLabel);
			this.pnlPerson.Controls.Add(this.mtbPhoneNumber);
			this.pnlPerson.Controls.Add(this.lblMiddleName);
			this.pnlPerson.Controls.Add(this.txtEmail);
			this.pnlPerson.Controls.Add(this.firstNameLabel);
			this.pnlPerson.Controls.Add(this.mtbCellNumber);
			this.pnlPerson.Controls.Add(this.lblTitleDesc);
			this.pnlPerson.Controls.Add(this.lblCell);
			this.pnlPerson.Controls.Add(this.mtbFax);
			this.pnlPerson.Controls.Add(this.lblFaxExt);
			this.pnlPerson.Controls.Add(this.txtPhoneExt);
			this.pnlPerson.Controls.Add(this.txtFaxExt);
			this.pnlPerson.Controls.Add(this.lblPhoneExt);
			this.pnlPerson.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPerson.Location = new System.Drawing.Point(3, 4);
			this.pnlPerson.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlPerson.Name = "pnlPerson";
			this.pnlPerson.Size = new System.Drawing.Size(495, 279);
			this.pnlPerson.TabIndex = 0;
			// 
			// btnEmail
			// 
			this.btnEmail.AutoSize = true;
			this.btnEmail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnEmail.Location = new System.Drawing.Point(24, 141);
			this.btnEmail.Name = "btnEmail";
			this.btnEmail.Size = new System.Drawing.Size(51, 26);
			this.btnEmail.TabIndex = 66;
			this.btnEmail.Text = "Email";
			this.btnEmail.UseVisualStyleBackColor = true;
			this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
			// 
			// pnlEmployee
			// 
			this.pnlEmployee.Controls.Add(sortGroupLabel);
			this.pnlEmployee.Controls.Add(this.sortGroupComboBox);
			this.pnlEmployee.Controls.Add(this.cmbEmployee);
			this.pnlEmployee.Controls.Add(this.chkIsCompletenessReviewEngineer);
			this.pnlEmployee.Controls.Add(employeeNoLabel);
			this.pnlEmployee.Location = new System.Drawing.Point(2, 170);
			this.pnlEmployee.Name = "pnlEmployee";
			this.pnlEmployee.Size = new System.Drawing.Size(464, 95);
			this.pnlEmployee.TabIndex = 65;
			// 
			// sortGroupComboBox
			// 
			this.sortGroupComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsPerson, "SortGroup", true));
			this.sortGroupComboBox.DataSource = this.bsSortGroup;
			this.sortGroupComboBox.DisplayMember = "SortGroupName";
			this.sortGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sortGroupComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sortGroupComboBox.FormattingEnabled = true;
			this.sortGroupComboBox.Location = new System.Drawing.Point(317, 35);
			this.sortGroupComboBox.Name = "sortGroupComboBox";
			this.sortGroupComboBox.Size = new System.Drawing.Size(121, 24);
			this.sortGroupComboBox.TabIndex = 65;
			this.sortGroupComboBox.ValueMember = "SortGroup";
			// 
			// bsSortGroup
			// 
			this.bsSortGroup.DataMember = "SortGroup";
			this.bsSortGroup.DataSource = this.dsContactsAux;
			// 
			// cmbEmployee
			// 
			this.cmbEmployee.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsPerson, "EmployeeNo", true));
			this.cmbEmployee.DataSource = this.bsEmployee;
			this.cmbEmployee.DisplayMember = "Employee";
			this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbEmployee.FormattingEnabled = true;
			this.cmbEmployee.Location = new System.Drawing.Point(78, 5);
			this.cmbEmployee.Name = "cmbEmployee";
			this.cmbEmployee.Size = new System.Drawing.Size(209, 24);
			this.cmbEmployee.TabIndex = 63;
			this.cmbEmployee.ValueMember = "EmployeeNo";
			// 
			// bsEmployee
			// 
			this.bsEmployee.DataMember = "Employee";
			this.bsEmployee.DataSource = this.dsContactsAux;
			// 
			// chkIsCompletenessReviewEngineer
			// 
			this.chkIsCompletenessReviewEngineer.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPerson, "IsCompletenessReviewEngineer", true));
			this.chkIsCompletenessReviewEngineer.Location = new System.Drawing.Point(8, 38);
			this.chkIsCompletenessReviewEngineer.Name = "chkIsCompletenessReviewEngineer";
			this.chkIsCompletenessReviewEngineer.Size = new System.Drawing.Size(221, 19);
			this.chkIsCompletenessReviewEngineer.TabIndex = 64;
			this.chkIsCompletenessReviewEngineer.Text = "Completeness Review Engineer";
			this.chkIsCompletenessReviewEngineer.UseVisualStyleBackColor = true;
			// 
			// cmbNamePrefix
			// 
			this.cmbNamePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "NamePrefix", true));
			this.cmbNamePrefix.DataSource = this.bsNamePrefix;
			this.cmbNamePrefix.DisplayMember = "NamePrefix";
			this.cmbNamePrefix.FormattingEnabled = true;
			this.cmbNamePrefix.Location = new System.Drawing.Point(39, 24);
			this.cmbNamePrefix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cmbNamePrefix.Name = "cmbNamePrefix";
			this.cmbNamePrefix.Size = new System.Drawing.Size(56, 24);
			this.cmbNamePrefix.TabIndex = 0;
			this.cmbNamePrefix.ValueMember = "NamePrefix";
			// 
			// bsNamePrefix
			// 
			this.bsNamePrefix.DataMember = "NamePrefix";
			this.bsNamePrefix.DataSource = this.dsContactAux;
			// 
			// dsContactAux
			// 
			this.dsContactAux.DataSetName = "ContactAuxDataSet";
			this.dsContactAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// lblPositionTitle
			// 
			this.lblPositionTitle.AutoSize = true;
			this.lblPositionTitle.Location = new System.Drawing.Point(20, 58);
			this.lblPositionTitle.Name = "lblPositionTitle";
			this.lblPositionTitle.Size = new System.Drawing.Size(55, 16);
			this.lblPositionTitle.TabIndex = 49;
			this.lblPositionTitle.Text = "Position";
			this.lblPositionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPhoneNumber
			// 
			this.lblPhoneNumber.AutoSize = true;
			this.lblPhoneNumber.Location = new System.Drawing.Point(30, 88);
			this.lblPhoneNumber.Name = "lblPhoneNumber";
			this.lblPhoneNumber.Size = new System.Drawing.Size(45, 16);
			this.lblPhoneNumber.TabIndex = 52;
			this.lblPhoneNumber.Text = "Phone";
			this.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblFaxNumber
			// 
			this.lblFaxNumber.AutoSize = true;
			this.lblFaxNumber.Location = new System.Drawing.Point(45, 117);
			this.lblFaxNumber.Name = "lblFaxNumber";
			this.lblFaxNumber.Size = new System.Drawing.Size(30, 16);
			this.lblFaxNumber.TabIndex = 55;
			this.lblFaxNumber.Text = "Fax";
			this.lblFaxNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPersonNo
			// 
			this.txtPersonNo.BackColor = System.Drawing.SystemColors.Control;
			this.txtPersonNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPersonNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "PersonNo", true));
			this.txtPersonNo.ForeColor = System.Drawing.SystemColors.GrayText;
			this.txtPersonNo.Location = new System.Drawing.Point(431, 55);
			this.txtPersonNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.txtPersonNo.Name = "txtPersonNo";
			this.txtPersonNo.Size = new System.Drawing.Size(42, 15);
			this.txtPersonNo.TabIndex = 38;
			this.txtPersonNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtFirstName
			// 
			this.txtFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "FirstName", true));
			this.txtFirstName.Location = new System.Drawing.Point(103, 25);
			this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(82, 22);
			this.txtFirstName.TabIndex = 1;
			// 
			// txtMiddleName
			// 
			this.txtMiddleName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "MiddleName", true));
			this.txtMiddleName.Location = new System.Drawing.Point(193, 25);
			this.txtMiddleName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtMiddleName.Name = "txtMiddleName";
			this.txtMiddleName.Size = new System.Drawing.Size(82, 22);
			this.txtMiddleName.TabIndex = 2;
			// 
			// txtLastName
			// 
			this.txtLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "LastName", true));
			this.txtLastName.Location = new System.Drawing.Point(283, 25);
			this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(126, 22);
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
			this.cmbNameSuffix.Location = new System.Drawing.Point(417, 24);
			this.cmbNameSuffix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cmbNameSuffix.Name = "cmbNameSuffix";
			this.cmbNameSuffix.Size = new System.Drawing.Size(50, 24);
			this.cmbNameSuffix.TabIndex = 4;
			this.cmbNameSuffix.ValueMember = "NameSuffix";
			// 
			// bsNameSuffix
			// 
			this.bsNameSuffix.DataMember = "NameSuffix";
			this.bsNameSuffix.DataSource = this.dsContactAux;
			// 
			// cmbPositionTitle
			// 
			this.cmbPositionTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.cmbPositionTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cmbPositionTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "PositionTitle", true));
			this.cmbPositionTitle.DataSource = this.bsPositionTitle;
			this.cmbPositionTitle.DisplayMember = "PositionTitle";
			this.cmbPositionTitle.FormattingEnabled = true;
			this.cmbPositionTitle.Location = new System.Drawing.Point(79, 54);
			this.cmbPositionTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cmbPositionTitle.Name = "cmbPositionTitle";
			this.cmbPositionTitle.Size = new System.Drawing.Size(280, 24);
			this.cmbPositionTitle.TabIndex = 5;
			this.cmbPositionTitle.ValueMember = "PositionTitle";
			// 
			// bsPositionTitle
			// 
			this.bsPositionTitle.DataMember = "PositionTitle";
			this.bsPositionTitle.DataSource = this.dsContactAux;
			// 
			// familyTitleLabel
			// 
			this.familyTitleLabel.AutoSize = true;
			this.familyTitleLabel.Location = new System.Drawing.Point(412, 5);
			this.familyTitleLabel.Name = "familyTitleLabel";
			this.familyTitleLabel.Size = new System.Drawing.Size(40, 16);
			this.familyTitleLabel.TabIndex = 62;
			this.familyTitleLabel.Text = "Suffix";
			// 
			// chkInterofficeMail
			// 
			this.chkInterofficeMail.AutoSize = true;
			this.chkInterofficeMail.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPerson, "InterofficeMail", true));
			this.chkInterofficeMail.Location = new System.Drawing.Point(337, 115);
			this.chkInterofficeMail.Margin = new System.Windows.Forms.Padding(0);
			this.chkInterofficeMail.Name = "chkInterofficeMail";
			this.chkInterofficeMail.Size = new System.Drawing.Size(82, 20);
			this.chkInterofficeMail.TabIndex = 11;
			this.chkInterofficeMail.Text = "Interoffice";
			this.chkInterofficeMail.UseVisualStyleBackColor = true;
			// 
			// lastNameLabel
			// 
			this.lastNameLabel.AutoSize = true;
			this.lastNameLabel.Location = new System.Drawing.Point(283, 5);
			this.lastNameLabel.Name = "lastNameLabel";
			this.lastNameLabel.Size = new System.Drawing.Size(33, 16);
			this.lastNameLabel.TabIndex = 61;
			this.lastNameLabel.Text = "Last";
			// 
			// mtbPhoneNumber
			// 
			this.mtbPhoneNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "PhoneNumber", true));
			this.mtbPhoneNumber.Location = new System.Drawing.Point(79, 85);
			this.mtbPhoneNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.mtbPhoneNumber.Mask = "(999) 000-0000";
			this.mtbPhoneNumber.Name = "mtbPhoneNumber";
			this.mtbPhoneNumber.Size = new System.Drawing.Size(116, 22);
			this.mtbPhoneNumber.TabIndex = 6;
			// 
			// lblMiddleName
			// 
			this.lblMiddleName.AutoSize = true;
			this.lblMiddleName.Location = new System.Drawing.Point(193, 5);
			this.lblMiddleName.Name = "lblMiddleName";
			this.lblMiddleName.Size = new System.Drawing.Size(46, 16);
			this.lblMiddleName.TabIndex = 60;
			this.lblMiddleName.Text = "Middle";
			// 
			// txtEmail
			// 
			this.txtEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "Email", true));
			this.txtEmail.Location = new System.Drawing.Point(79, 143);
			this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(387, 22);
			this.txtEmail.TabIndex = 12;
			// 
			// firstNameLabel
			// 
			this.firstNameLabel.AutoSize = true;
			this.firstNameLabel.Location = new System.Drawing.Point(103, 5);
			this.firstNameLabel.Name = "firstNameLabel";
			this.firstNameLabel.Size = new System.Drawing.Size(34, 16);
			this.firstNameLabel.TabIndex = 59;
			this.firstNameLabel.Text = "First";
			// 
			// mtbCellNumber
			// 
			this.mtbCellNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "CellNumber", true));
			this.mtbCellNumber.Location = new System.Drawing.Point(352, 85);
			this.mtbCellNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.mtbCellNumber.Mask = "(999) 000-0000";
			this.mtbCellNumber.Name = "mtbCellNumber";
			this.mtbCellNumber.Size = new System.Drawing.Size(116, 22);
			this.mtbCellNumber.TabIndex = 8;
			// 
			// lblTitleDesc
			// 
			this.lblTitleDesc.AutoSize = true;
			this.lblTitleDesc.Location = new System.Drawing.Point(39, 5);
			this.lblTitleDesc.Name = "lblTitleDesc";
			this.lblTitleDesc.Size = new System.Drawing.Size(32, 16);
			this.lblTitleDesc.TabIndex = 58;
			this.lblTitleDesc.Text = "Title";
			// 
			// lblCell
			// 
			this.lblCell.AutoSize = true;
			this.lblCell.Location = new System.Drawing.Point(316, 88);
			this.lblCell.Name = "lblCell";
			this.lblCell.Size = new System.Drawing.Size(30, 16);
			this.lblCell.TabIndex = 53;
			this.lblCell.Text = "Cell";
			// 
			// mtbFax
			// 
			this.mtbFax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "FaxNumber", true));
			this.mtbFax.Location = new System.Drawing.Point(79, 114);
			this.mtbFax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.mtbFax.Mask = "(999) 000-0000";
			this.mtbFax.Name = "mtbFax";
			this.mtbFax.Size = new System.Drawing.Size(116, 22);
			this.mtbFax.TabIndex = 9;
			// 
			// lblFaxExt
			// 
			this.lblFaxExt.AutoSize = true;
			this.lblFaxExt.Location = new System.Drawing.Point(205, 117);
			this.lblFaxExt.Name = "lblFaxExt";
			this.lblFaxExt.Size = new System.Drawing.Size(28, 16);
			this.lblFaxExt.TabIndex = 10;
			this.lblFaxExt.Text = "Ext";
			// 
			// txtPhoneExt
			// 
			this.txtPhoneExt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "PhoneExt", true));
			this.txtPhoneExt.Location = new System.Drawing.Point(239, 85);
			this.txtPhoneExt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtPhoneExt.Name = "txtPhoneExt";
			this.txtPhoneExt.Size = new System.Drawing.Size(49, 22);
			this.txtPhoneExt.TabIndex = 44;
			// 
			// txtFaxExt
			// 
			this.txtFaxExt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPerson, "FaxExt", true));
			this.txtFaxExt.Location = new System.Drawing.Point(239, 114);
			this.txtFaxExt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtFaxExt.Name = "txtFaxExt";
			this.txtFaxExt.Size = new System.Drawing.Size(49, 22);
			this.txtFaxExt.TabIndex = 47;
			// 
			// lblPhoneExt
			// 
			this.lblPhoneExt.AutoSize = true;
			this.lblPhoneExt.Location = new System.Drawing.Point(205, 88);
			this.lblPhoneExt.Name = "lblPhoneExt";
			this.lblPhoneExt.Size = new System.Drawing.Size(28, 16);
			this.lblPhoneExt.TabIndex = 7;
			this.lblPhoneExt.Text = "Ext";
			// 
			// tabAddress
			// 
			this.tabAddress.Controls.Add(this.pnlAddress);
			this.tabAddress.Location = new System.Drawing.Point(4, 28);
			this.tabAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabAddress.Name = "tabAddress";
			this.tabAddress.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabAddress.Size = new System.Drawing.Size(501, 246);
			this.tabAddress.TabIndex = 1;
			this.tabAddress.Text = "Address";
			this.tabAddress.UseVisualStyleBackColor = true;
			// 
			// pnlAddress
			// 
			this.pnlAddress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnlAddress.Controls.Add(this.Address);
			this.pnlAddress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlAddress.ForeColor = System.Drawing.SystemColors.WindowText;
			this.pnlAddress.Location = new System.Drawing.Point(3, 4);
			this.pnlAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlAddress.Name = "pnlAddress";
			this.pnlAddress.Size = new System.Drawing.Size(495, 238);
			this.pnlAddress.TabIndex = 2;
			// 
			// Address
			// 
			this.Address.AddressDataHasChanges = false;
			this.Address.AutoScroll = true;
			this.Address.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Address.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Address.drvCurrentAddress = null;
			this.Address.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Address.Location = new System.Drawing.Point(0, 0);
			this.Address.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Address.Name = "Address";
			this.Address.Size = new System.Drawing.Size(495, 238);
			this.Address.TabIndex = 0;
			this.Address.usrConnectionString = null;
			this.Address.AddressSaved += new SbcapcdOrg.Address.usrAddress.AddressSavedEventHandler(this.Address_AddressSaved);
			this.Address.NewAddess += new SbcapcdOrg.Address.usrAddress.NewAddessEventHandler(this.Address_NewAddess);
			this.Address.OnAddressDisplayChanged += new SbcapcdOrg.Address.usrAddress.AddressDisplayChangedEventHandler(this.Address_OnAddressDisplayChanged);
			// 
			// cmbEntity
			// 
			this.cmbEntity.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsContact, "EntityNo", true));
			this.cmbEntity.DataSource = this.bsFacility;
			this.cmbEntity.DisplayMember = "FacilityName";
			this.cmbEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			this.cmbEntity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbEntity.FormattingEnabled = true;
			this.cmbEntity.Location = new System.Drawing.Point(358, 35);
			this.cmbEntity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cmbEntity.Name = "cmbEntity";
			this.cmbEntity.Size = new System.Drawing.Size(215, 24);
			this.cmbEntity.TabIndex = 91;
			this.cmbEntity.TabStop = false;
			this.cmbEntity.ValueMember = "FacilityNo";
			this.cmbEntity.Visible = false;
			// 
			// contactDescTextBox
			// 
			this.contactDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContact, "ContactDesc", true));
			this.contactDescTextBox.Location = new System.Drawing.Point(313, 5);
			this.contactDescTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.contactDescTextBox.Name = "contactDescTextBox";
			this.contactDescTextBox.Size = new System.Drawing.Size(95, 22);
			this.contactDescTextBox.TabIndex = 3;
			// 
			// txtAddressNo
			// 
			this.txtAddressNo.BackColor = System.Drawing.SystemColors.Control;
			this.txtAddressNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAddressNo.ForeColor = System.Drawing.SystemColors.GrayText;
			this.txtAddressNo.Location = new System.Drawing.Point(474, 249);
			this.txtAddressNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.txtAddressNo.Name = "txtAddressNo";
			this.txtAddressNo.ReadOnly = true;
			this.txtAddressNo.Size = new System.Drawing.Size(54, 15);
			this.txtAddressNo.TabIndex = 66;
			this.txtAddressNo.TabStop = false;
			this.txtAddressNo.Visible = false;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			this.imageList1.Images.SetKeyName(0, "Paste.bmp");
			this.imageList1.Images.SetKeyName(1, "Copy.bmp");
			this.imageList1.Images.SetKeyName(2, "Stop.bmp");
			this.imageList1.Images.SetKeyName(3, "Comment.bmp");
			this.imageList1.Images.SetKeyName(4, "AddNewItem.bmp");
			this.imageList1.Images.SetKeyName(5, "AddressViewer_24.bmp");
			// 
			// personDataSet
			// 
			this.personDataSet.DataSetName = "PersonDataSet";
			this.personDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// personBindingSource
			// 
			this.personBindingSource.DataMember = "Person";
			this.personBindingSource.DataSource = this.personDataSet;
			// 
			// bsContactTypeCreate
			// 
			this.bsContactTypeCreate.DataMember = "ContactTypeCreate";
			this.bsContactTypeCreate.DataSource = this.dsContactsAux;
			// 
			// usrContacts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.scContracts);
			this.Controls.Add(this.bnPerson);
			this.Name = "usrContacts";
			this.Size = new System.Drawing.Size(950, 684);
			((System.ComponentModel.ISupportInitialize)(this.bnPerson)).EndInit();
			this.bnPerson.ResumeLayout(false);
			this.bnPerson.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsPerson)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsContacts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).EndInit();
			this.scContracts.Panel1.ResumeLayout(false);
			this.scContracts.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scContracts)).EndInit();
			this.scContracts.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsContactType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsContactsAux)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsFacility)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsCompanyDgvContacts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsContact)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bnContact)).EndInit();
			this.bnContact.ResumeLayout(false);
			this.bnContact.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsCompany)).EndInit();
			this.tbcPersonAddress.ResumeLayout(false);
			this.tabPerson.ResumeLayout(false);
			this.pnlPerson.ResumeLayout(false);
			this.pnlPerson.PerformLayout();
			this.pnlEmployee.ResumeLayout(false);
			this.pnlEmployee.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsSortGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsEmployee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsNamePrefix)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsContactAux)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsNameSuffix)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsPositionTitle)).EndInit();
			this.tabAddress.ResumeLayout(false);
			this.pnlAddress.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bsUspsSecondaryUnitDesignator)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsUspsStatePossession)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsUspsStreetSuffix)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsSbcCities)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsContactTypeCreate)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.BindingSource bsContact;
		private System.Windows.Forms.BindingSource bsPerson;
		protected System.Windows.Forms.BindingNavigator bnPerson;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private System.Windows.Forms.DataGridView dgvPerson;
		private SbcapcdOrg.ControlLibrary.usrSplitContainer scContracts;
		private ContactAuxDataSet dsContactAux;
		protected System.Windows.Forms.Label lblContactId;
		protected System.Windows.Forms.Label lblFaxExt;
		protected System.Windows.Forms.TextBox txtFaxExt;
		protected System.Windows.Forms.Label lblPhoneExt;
		protected System.Windows.Forms.TextBox txtPhoneExt;
		protected System.Windows.Forms.MaskedTextBox mtbFax;
		protected System.Windows.Forms.Label lblCell;
		protected System.Windows.Forms.MaskedTextBox mtbCellNumber;
		protected System.Windows.Forms.TextBox txtEmail;
		protected System.Windows.Forms.MaskedTextBox mtbPhoneNumber;
		protected System.Windows.Forms.CheckBox chkInterofficeMail;
		protected System.Windows.Forms.ComboBox cmbPositionTitle;
		protected System.Windows.Forms.ComboBox cmbNameSuffix;
		protected System.Windows.Forms.TextBox txtLastName;
		protected System.Windows.Forms.TextBox txtMiddleName;
		protected System.Windows.Forms.TextBox txtFirstName;
		protected System.Windows.Forms.TextBox txtPersonNo;
		protected System.Windows.Forms.Label lblFaxNumber;
        protected System.Windows.Forms.Label lblPhoneNumber;
		protected System.Windows.Forms.Label lblPositionTitle;
		protected System.Windows.Forms.ComboBox cmbNamePrefix;
		protected System.Windows.Forms.Label familyTitleLabel;
		protected System.Windows.Forms.Label lastNameLabel;
		protected System.Windows.Forms.Label lblMiddleName;
		protected System.Windows.Forms.Label firstNameLabel;
		protected System.Windows.Forms.Label lblTitleDesc;
		private ContactsDataSet dsContacts;
		protected System.Windows.Forms.TextBox txtAddressNo;
		private System.Windows.Forms.ToolStripTextBox tstxtFilterPerson;
		private System.Windows.Forms.TextBox contactDescTextBox;
		private System.Windows.Forms.ComboBox cmbCompany;
		private System.Windows.Forms.ComboBox cmbAddress;
		private System.Windows.Forms.BindingNavigator bnContact;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
		protected System.Windows.Forms.BindingSource bsUspsSecondaryUnitDesignator;
		protected System.Windows.Forms.BindingSource bsUspsStatePossession;
		protected System.Windows.Forms.BindingSource bsUspsStreetSuffix;
		protected System.Windows.Forms.BindingSource bsSbcCities;
		private System.Windows.Forms.Panel pnlAddress;
		private ContactsAuxDataSet dsContactsAux;
		private System.Windows.Forms.BindingSource bsCompany;
		private System.Windows.Forms.ComboBox cmbContactType;
		private System.Windows.Forms.BindingSource bsContactType;
		private System.Windows.Forms.ComboBox cmbEntity;
		private System.Windows.Forms.BindingSource bsFacility;
		private System.Windows.Forms.TabControl tbcPersonAddress;
		private System.Windows.Forms.TabPage tabPerson;
		private System.Windows.Forms.TabPage tabAddress;
        private System.Windows.Forms.Panel pnlPerson;
        private System.Windows.Forms.TextBox txtFilterAddress;
        private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.BindingSource bsCompanyDgvContacts;
		protected System.Windows.Forms.DataGridView dgvContacts;
		private System.Windows.Forms.ToolStripButton tsbtnAddNewSubscriptionContactForPerson;
		private SbcapcdOrg.ControlLibrary.usrSplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripButton tsbtnSaveContact;
		private SbcapcdOrg.Address.usrAddress Address;
		private System.Windows.Forms.BindingSource bsNamePrefix;
		private System.Windows.Forms.BindingSource bsNameSuffix;
		private System.Windows.Forms.BindingSource bsPositionTitle;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lblPersonNo;
		private System.Windows.Forms.ToolStripButton tsbtnDeleteContact;
		private System.Windows.Forms.ToolStripButton tsbtnUndoContactFilter;
		private System.Windows.Forms.DataGridViewTextBoxColumn personNoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.Label lblContactId2;
		private System.Windows.Forms.ToolStripButton tsbtnDeletePerson;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel tslblContactHasChanges;
		private System.Windows.Forms.ToolStripButton tsbtnAddNewSubscriptionPersonContact;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ComboBox cmbEmployee;
		private PersonDataSet personDataSet;
		private System.Windows.Forms.BindingSource personBindingSource;
		private System.Windows.Forms.BindingSource bsEmployee;
		private System.Windows.Forms.ToolStripComboBox tscmbContactTypeCreate;
		private System.Windows.Forms.BindingSource bsContactTypeCreate;
        private System.Windows.Forms.CheckBox chkIsCompletenessReviewEngineer;
        private System.Windows.Forms.Panel pnlEmployee;
        private System.Windows.Forms.ComboBox sortGroupComboBox;
        private System.Windows.Forms.BindingSource bsSortGroup;
        protected System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.ToolStripButton tsbtnUndoContactChanges;
		private System.Windows.Forms.DataGridViewCheckBoxColumn PrimaryContact;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CcContact;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Active;
	}
}
