namespace SbcapcdOrg.PdePermit.Company
{
	partial class usrCompany
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
			System.Windows.Forms.Label companyNameLabel;
			System.Windows.Forms.Label webSiteLabel;
			System.Windows.Forms.Label dbaLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrCompany));
			this.bnCompany = new System.Windows.Forms.BindingNavigator(this.components);
			this.bsCompany = new System.Windows.Forms.BindingSource(this.components);
			this.dsCompany = new SbcapcdOrg.PdePermit.Company.CompanyDataSet();
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnNewCompany = new System.Windows.Forms.ToolStripButton();
			this.tsbtnSaveCompany = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnUndoCompany = new System.Windows.Forms.ToolStripButton();
			this.tstxtFilterCompany = new System.Windows.Forms.ToolStripTextBox();
			this.cmbCompanyActiveFilter = new System.Windows.Forms.ToolStripComboBox();
			this.tsbtnResetCompanyFilter = new System.Windows.Forms.ToolStripButton();
			this.tsbtnDeleteCompany = new System.Windows.Forms.ToolStripButton();
			this.tslblCompanyHasChanges = new System.Windows.Forms.ToolStripLabel();
			this.splitContainer1 = new SbcapcdOrg.ControlLibrary.usrSplitContainer();
			this.dgvCompany = new System.Windows.Forms.DataGridView();
			this.companyNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.companyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.splitContainer2 = new SbcapcdOrg.ControlLibrary.usrSplitContainer();
			this.companyNameTextBox = new System.Windows.Forms.TextBox();
			this.dbaTextBox = new System.Windows.Forms.TextBox();
			this.webSiteTextBox = new System.Windows.Forms.TextBox();
			this.splitContainer3 = new SbcapcdOrg.ControlLibrary.usrSplitContainer();
			this.dgvFacility = new System.Windows.Forms.DataGridView();
			this.facilityNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.facilityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.companyNoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bsFacility = new System.Windows.Forms.BindingSource(this.components);
			this.dsCompanyAux = new SbcapcdOrg.PdePermit.Company.CompanyAuxDataSet();
			this.dgvContact = new System.Windows.Forms.DataGridView();
			this.PersonNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ContactTypeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.streetAddressCompleteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contactIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.companyNoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bsContact = new System.Windows.Forms.BindingSource(this.components);
			this.companyNoTextBox = new System.Windows.Forms.TextBox();
			companyNameLabel = new System.Windows.Forms.Label();
			webSiteLabel = new System.Windows.Forms.Label();
			dbaLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.bnCompany)).BeginInit();
			this.bnCompany.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsCompany)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCompany)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvFacility)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsFacility)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCompanyAux)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvContact)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsContact)).BeginInit();
			this.SuspendLayout();
			// 
			// companyNameLabel
			// 
			companyNameLabel.AutoSize = true;
			companyNameLabel.Location = new System.Drawing.Point(1, 11);
			companyNameLabel.Name = "companyNameLabel";
			companyNameLabel.Size = new System.Drawing.Size(101, 16);
			companyNameLabel.TabIndex = 2;
			companyNameLabel.Text = "Company Name";
			// 
			// webSiteLabel
			// 
			webSiteLabel.AutoSize = true;
			webSiteLabel.Location = new System.Drawing.Point(40, 39);
			webSiteLabel.Name = "webSiteLabel";
			webSiteLabel.Size = new System.Drawing.Size(62, 16);
			webSiteLabel.TabIndex = 4;
			webSiteLabel.Text = "Web Site";
			// 
			// dbaLabel
			// 
			dbaLabel.AutoSize = true;
			dbaLabel.Location = new System.Drawing.Point(67, 67);
			dbaLabel.Name = "dbaLabel";
			dbaLabel.Size = new System.Drawing.Size(35, 16);
			dbaLabel.TabIndex = 6;
			dbaLabel.Text = "DBA";
			// 
			// bnCompany
			// 
			this.bnCompany.AddNewItem = null;
			this.bnCompany.BindingSource = this.bsCompany;
			this.bnCompany.CountItem = this.bindingNavigatorCountItem;
			this.bnCompany.DeleteItem = null;
			this.bnCompany.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bnCompany.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.bnCompany.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.tsbtnNewCompany,
            this.tsbtnSaveCompany,
            this.tsbtnUndoCompany,
            this.toolStripSeparator1,
            this.tstxtFilterCompany,
            this.cmbCompanyActiveFilter,
            this.tsbtnResetCompanyFilter,
            this.tsbtnDeleteCompany,
            this.tslblCompanyHasChanges});
			this.bnCompany.Location = new System.Drawing.Point(0, 0);
			this.bnCompany.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bnCompany.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bnCompany.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bnCompany.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bnCompany.Name = "bnCompany";
			this.bnCompany.PositionItem = this.bindingNavigatorPositionItem;
			this.bnCompany.Size = new System.Drawing.Size(874, 25);
			this.bnCompany.TabIndex = 0;
			this.bnCompany.Text = "bindingNavigator1";
			// 
			// bsCompany
			// 
			this.bsCompany.DataMember = "Company";
			this.bsCompany.DataSource = this.dsCompany;
			this.bsCompany.Sort = "CompanyName";
			this.bsCompany.CurrentChanged += new System.EventHandler(this.bsCompany_CurrentChanged);
			// 
			// dsCompany
			// 
			this.dsCompany.DataSetName = "CompanyDataSet";
			this.dsCompany.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
			// bindingNavigatorSeparator
			// 
			this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
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
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
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
			// tsbtnNewCompany
			// 
			this.tsbtnNewCompany.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnNewCompany.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNewCompany.Image")));
			this.tsbtnNewCompany.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnNewCompany.Name = "tsbtnNewCompany";
			this.tsbtnNewCompany.Size = new System.Drawing.Size(23, 22);
			this.tsbtnNewCompany.ToolTipText = "New Company";
			this.tsbtnNewCompany.Click += new System.EventHandler(this.tsbtnNewCompany_Click);
			// 
			// tsbtnSaveCompany
			// 
			this.tsbtnSaveCompany.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSaveCompany.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaveCompany.Image")));
			this.tsbtnSaveCompany.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSaveCompany.Name = "tsbtnSaveCompany";
			this.tsbtnSaveCompany.Size = new System.Drawing.Size(23, 22);
			this.tsbtnSaveCompany.ToolTipText = "Save Company";
			this.tsbtnSaveCompany.Click += new System.EventHandler(this.tsbtnSaveComnpany_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnUndoCompany
			// 
			this.tsbtnUndoCompany.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnUndoCompany.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUndoCompany.Image")));
			this.tsbtnUndoCompany.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnUndoCompany.Name = "tsbtnUndoCompany";
			this.tsbtnUndoCompany.Size = new System.Drawing.Size(23, 22);
			this.tsbtnUndoCompany.Click += new System.EventHandler(this.tsbtnUndoCompany_Click);
			// 
			// tstxtFilterCompany
			// 
			this.tstxtFilterCompany.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tstxtFilterCompany.Name = "tstxtFilterCompany";
			this.tstxtFilterCompany.Size = new System.Drawing.Size(98, 25);
			this.tstxtFilterCompany.TextChanged += new System.EventHandler(this.tstxtFilterCompany_TextChanged);
			// 
			// cmbCompanyActiveFilter
			// 
			this.cmbCompanyActiveFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCompanyActiveFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCompanyActiveFilter.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbCompanyActiveFilter.Items.AddRange(new object[] {
            "All",
            "Active"});
			this.cmbCompanyActiveFilter.Name = "cmbCompanyActiveFilter";
			this.cmbCompanyActiveFilter.Size = new System.Drawing.Size(98, 25);
			this.cmbCompanyActiveFilter.ToolTipText = "Filter by Active or All";
			this.cmbCompanyActiveFilter.Visible = false;
			this.cmbCompanyActiveFilter.Click += new System.EventHandler(this.cmbCompanyActiveFilter_Click);
			// 
			// tsbtnResetCompanyFilter
			// 
			this.tsbtnResetCompanyFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnResetCompanyFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnResetCompanyFilter.Image")));
			this.tsbtnResetCompanyFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnResetCompanyFilter.Name = "tsbtnResetCompanyFilter";
			this.tsbtnResetCompanyFilter.Size = new System.Drawing.Size(23, 22);
			this.tsbtnResetCompanyFilter.ToolTipText = "Reset Company Filter";
			this.tsbtnResetCompanyFilter.Click += new System.EventHandler(this.tsbtnResetCompanyFilter_Click);
			// 
			// tsbtnDeleteCompany
			// 
			this.tsbtnDeleteCompany.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnDeleteCompany.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnDeleteCompany.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDeleteCompany.Image")));
			this.tsbtnDeleteCompany.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDeleteCompany.Name = "tsbtnDeleteCompany";
			this.tsbtnDeleteCompany.Size = new System.Drawing.Size(23, 22);
			this.tsbtnDeleteCompany.ToolTipText = "Delete Company";
			this.tsbtnDeleteCompany.Click += new System.EventHandler(this.tsbtnDeleteCompany_Click);
			// 
			// tslblCompanyHasChanges
			// 
			this.tslblCompanyHasChanges.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tslblCompanyHasChanges.ForeColor = System.Drawing.Color.Red;
			this.tslblCompanyHasChanges.Name = "tslblCompanyHasChanges";
			this.tslblCompanyHasChanges.Size = new System.Drawing.Size(141, 22);
			this.tslblCompanyHasChanges.Text = "Company has changes";
			this.tslblCompanyHasChanges.Visible = false;
			// 
			// splitContainer1
			// 
			
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			
			this.splitContainer1.Panel1.Controls.Add(this.dgvCompany);
			// 
			// splitContainer1.Panel2
			// 
			
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel2.Controls.Add(this.companyNoTextBox);
			this.splitContainer1.Size = new System.Drawing.Size(874, 521);
			this.splitContainer1.SplitterDistance = 421;
			this.splitContainer1.SplitterWidth = 2;
			this.splitContainer1.TabIndex = 1;
			// 
			// dgvCompany
			// 
			this.dgvCompany.AllowUserToAddRows = false;
			this.dgvCompany.AllowUserToDeleteRows = false;
			this.dgvCompany.AutoGenerateColumns = false;
			this.dgvCompany.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvCompany.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dgvCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCompany.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.companyNoDataGridViewTextBoxColumn,
            this.companyNameDataGridViewTextBoxColumn});
			this.dgvCompany.DataSource = this.bsCompany;
			this.dgvCompany.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCompany.Location = new System.Drawing.Point(0, 0);
			this.dgvCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dgvCompany.MultiSelect = false;
			this.dgvCompany.Name = "dgvCompany";
			this.dgvCompany.ReadOnly = true;
			this.dgvCompany.RowHeadersVisible = false;
			this.dgvCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCompany.ShowEditingIcon = false;
			this.dgvCompany.Size = new System.Drawing.Size(421, 521);
			this.dgvCompany.TabIndex = 0;
			// 
			// companyNoDataGridViewTextBoxColumn
			// 
			this.companyNoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.companyNoDataGridViewTextBoxColumn.DataPropertyName = "CompanyNo";
			this.companyNoDataGridViewTextBoxColumn.HeaderText = "Company No";
			this.companyNoDataGridViewTextBoxColumn.Name = "companyNoDataGridViewTextBoxColumn";
			this.companyNoDataGridViewTextBoxColumn.ReadOnly = true;
			this.companyNoDataGridViewTextBoxColumn.Width = 108;
			// 
			// companyNameDataGridViewTextBoxColumn
			// 
			this.companyNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.companyNameDataGridViewTextBoxColumn.DataPropertyName = "CompanyName";
			this.companyNameDataGridViewTextBoxColumn.HeaderText = "CompanyName";
			this.companyNameDataGridViewTextBoxColumn.Name = "companyNameDataGridViewTextBoxColumn";
			this.companyNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// splitContainer2
			// 
			
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer2.Panel1.Controls.Add(this.companyNameTextBox);
			this.splitContainer2.Panel1.Controls.Add(this.dbaTextBox);
			this.splitContainer2.Panel1.Controls.Add(companyNameLabel);
			this.splitContainer2.Panel1.Controls.Add(this.webSiteTextBox);
			this.splitContainer2.Panel1.Controls.Add(webSiteLabel);
			this.splitContainer2.Panel1.Controls.Add(dbaLabel);
			// 
			// splitContainer2.Panel2
			// 
			
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
			this.splitContainer2.Size = new System.Drawing.Size(451, 521);
			this.splitContainer2.SplitterDistance = 89;
			this.splitContainer2.SplitterWidth = 2;
			this.splitContainer2.TabIndex = 8;
			// 
			// companyNameTextBox
			// 
			this.companyNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompany, "CompanyName", true));
			this.companyNameTextBox.Location = new System.Drawing.Point(103, 8);
			this.companyNameTextBox.Name = "companyNameTextBox";
			this.companyNameTextBox.Size = new System.Drawing.Size(331, 22);
			this.companyNameTextBox.TabIndex = 3;
			// 
			// dbaTextBox
			// 
			this.dbaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompany, "Dba", true));
			this.dbaTextBox.Location = new System.Drawing.Point(103, 64);
			this.dbaTextBox.Name = "dbaTextBox";
			this.dbaTextBox.Size = new System.Drawing.Size(331, 22);
			this.dbaTextBox.TabIndex = 7;
			// 
			// webSiteTextBox
			// 
			this.webSiteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompany, "WebSite", true));
			this.webSiteTextBox.Location = new System.Drawing.Point(103, 36);
			this.webSiteTextBox.Name = "webSiteTextBox";
			this.webSiteTextBox.Size = new System.Drawing.Size(331, 22);
			this.webSiteTextBox.TabIndex = 5;
			// 
			// splitContainer3
			// 
			
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer3.Panel1.Controls.Add(this.dgvFacility);
			// 
			// splitContainer3.Panel2
			// 
			
			this.splitContainer3.Panel2.Controls.Add(this.dgvContact);
			this.splitContainer3.Size = new System.Drawing.Size(451, 430);
			this.splitContainer3.SplitterDistance = 149;
			this.splitContainer3.SplitterWidth = 2;
			this.splitContainer3.TabIndex = 0;
			// 
			// dgvFacility
			// 
			this.dgvFacility.AllowUserToAddRows = false;
			this.dgvFacility.AllowUserToDeleteRows = false;
			this.dgvFacility.AllowUserToResizeRows = false;
			this.dgvFacility.AutoGenerateColumns = false;
			this.dgvFacility.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvFacility.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFacility.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.facilityNoDataGridViewTextBoxColumn,
            this.facilityNameDataGridViewTextBoxColumn,
            this.companyNoDataGridViewTextBoxColumn1});
			this.dgvFacility.DataSource = this.bsFacility;
			this.dgvFacility.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvFacility.Location = new System.Drawing.Point(0, 0);
			this.dgvFacility.MultiSelect = false;
			this.dgvFacility.Name = "dgvFacility";
			this.dgvFacility.ReadOnly = true;
			this.dgvFacility.RowHeadersVisible = false;
			this.dgvFacility.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvFacility.Size = new System.Drawing.Size(451, 149);
			this.dgvFacility.TabIndex = 0;
			// 
			// facilityNoDataGridViewTextBoxColumn
			// 
			this.facilityNoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.facilityNoDataGridViewTextBoxColumn.DataPropertyName = "FacilityNo";
			this.facilityNoDataGridViewTextBoxColumn.HeaderText = "Facility No";
			this.facilityNoDataGridViewTextBoxColumn.Name = "facilityNoDataGridViewTextBoxColumn";
			this.facilityNoDataGridViewTextBoxColumn.ReadOnly = true;
			this.facilityNoDataGridViewTextBoxColumn.Width = 95;
			// 
			// facilityNameDataGridViewTextBoxColumn
			// 
			this.facilityNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.facilityNameDataGridViewTextBoxColumn.DataPropertyName = "FacilityName";
			this.facilityNameDataGridViewTextBoxColumn.HeaderText = "Facility Name";
			this.facilityNameDataGridViewTextBoxColumn.Name = "facilityNameDataGridViewTextBoxColumn";
			this.facilityNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// companyNoDataGridViewTextBoxColumn1
			// 
			this.companyNoDataGridViewTextBoxColumn1.DataPropertyName = "CompanyNo";
			this.companyNoDataGridViewTextBoxColumn1.HeaderText = "CompanyNo";
			this.companyNoDataGridViewTextBoxColumn1.Name = "companyNoDataGridViewTextBoxColumn1";
			this.companyNoDataGridViewTextBoxColumn1.ReadOnly = true;
			this.companyNoDataGridViewTextBoxColumn1.Visible = false;
			// 
			// bsFacility
			// 
			this.bsFacility.DataMember = "Facility";
			this.bsFacility.DataSource = this.dsCompanyAux;
			// 
			// dsCompanyAux
			// 
			this.dsCompanyAux.DataSetName = "CompanyAuxDataSet";
			this.dsCompanyAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// dgvContact
			// 
			this.dgvContact.AllowUserToAddRows = false;
			this.dgvContact.AllowUserToDeleteRows = false;
			this.dgvContact.AllowUserToOrderColumns = true;
			this.dgvContact.AllowUserToResizeRows = false;
			this.dgvContact.AutoGenerateColumns = false;
			this.dgvContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvContact.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonNo,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.ContactTypeDescription,
            this.streetAddressCompleteDataGridViewTextBoxColumn,
            this.contactIdDataGridViewTextBoxColumn,
            this.companyNoDataGridViewTextBoxColumn2});
			this.dgvContact.DataSource = this.bsContact;
			this.dgvContact.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvContact.Location = new System.Drawing.Point(0, 0);
			this.dgvContact.MultiSelect = false;
			this.dgvContact.Name = "dgvContact";
			this.dgvContact.ReadOnly = true;
			this.dgvContact.RowHeadersVisible = false;
			this.dgvContact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvContact.Size = new System.Drawing.Size(451, 279);
			this.dgvContact.TabIndex = 0;
			// 
			// PersonNo
			// 
			this.PersonNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.PersonNo.DataPropertyName = "PersonNo";
			this.PersonNo.HeaderText = "Person No";
			this.PersonNo.Name = "PersonNo";
			this.PersonNo.ReadOnly = true;
			this.PersonNo.Width = 60;
			// 
			// firstNameDataGridViewTextBoxColumn
			// 
			this.firstNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
			this.firstNameDataGridViewTextBoxColumn.HeaderText = "First Name";
			this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
			this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.firstNameDataGridViewTextBoxColumn.Width = 97;
			// 
			// lastNameDataGridViewTextBoxColumn
			// 
			this.lastNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
			this.lastNameDataGridViewTextBoxColumn.HeaderText = "Last Name";
			this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
			this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.lastNameDataGridViewTextBoxColumn.Width = 96;
			// 
			// ContactTypeDescription
			// 
			this.ContactTypeDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ContactTypeDescription.DataPropertyName = "ContactTypeDescription";
			this.ContactTypeDescription.HeaderText = "Contact Type";
			this.ContactTypeDescription.Name = "ContactTypeDescription";
			this.ContactTypeDescription.ReadOnly = true;
			this.ContactTypeDescription.Width = 101;
			// 
			// streetAddressCompleteDataGridViewTextBoxColumn
			// 
			this.streetAddressCompleteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.streetAddressCompleteDataGridViewTextBoxColumn.DataPropertyName = "StreetAddressComplete";
			this.streetAddressCompleteDataGridViewTextBoxColumn.HeaderText = "Address";
			this.streetAddressCompleteDataGridViewTextBoxColumn.Name = "streetAddressCompleteDataGridViewTextBoxColumn";
			this.streetAddressCompleteDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// contactIdDataGridViewTextBoxColumn
			// 
			this.contactIdDataGridViewTextBoxColumn.DataPropertyName = "ContactId";
			this.contactIdDataGridViewTextBoxColumn.HeaderText = "ContactId";
			this.contactIdDataGridViewTextBoxColumn.Name = "contactIdDataGridViewTextBoxColumn";
			this.contactIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.contactIdDataGridViewTextBoxColumn.Visible = false;
			// 
			// companyNoDataGridViewTextBoxColumn2
			// 
			this.companyNoDataGridViewTextBoxColumn2.DataPropertyName = "CompanyNo";
			this.companyNoDataGridViewTextBoxColumn2.HeaderText = "CompanyNo";
			this.companyNoDataGridViewTextBoxColumn2.Name = "companyNoDataGridViewTextBoxColumn2";
			this.companyNoDataGridViewTextBoxColumn2.ReadOnly = true;
			this.companyNoDataGridViewTextBoxColumn2.Visible = false;
			// 
			// bsContact
			// 
			this.bsContact.DataMember = "Contact";
			this.bsContact.DataSource = this.dsCompanyAux;
			// 
			// companyNoTextBox
			// 
			this.companyNoTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.companyNoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.companyNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompany, "CompanyNo", true));
			this.companyNoTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.companyNoTextBox.Location = new System.Drawing.Point(113, 9);
			this.companyNoTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.companyNoTextBox.Name = "companyNoTextBox";
			this.companyNoTextBox.Size = new System.Drawing.Size(67, 15);
			this.companyNoTextBox.TabIndex = 1;
			// 
			// usrCompany
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.bnCompany);
			this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "usrCompany";
			this.Size = new System.Drawing.Size(874, 546);
			((System.ComponentModel.ISupportInitialize)(this.bnCompany)).EndInit();
			this.bnCompany.ResumeLayout(false);
			this.bnCompany.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsCompany)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCompany)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).EndInit();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvFacility)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsFacility)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCompanyAux)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvContact)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsContact)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CompanyDataSet dsCompany;
		private System.Windows.Forms.BindingSource bsCompany;
		private System.Windows.Forms.BindingNavigator bnCompany;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private SbcapcdOrg.ControlLibrary.usrSplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvCompany;
		private System.Windows.Forms.TextBox companyNoTextBox;
		private System.Windows.Forms.TextBox dbaTextBox;
		private System.Windows.Forms.TextBox webSiteTextBox;
		private System.Windows.Forms.TextBox companyNameTextBox;
		private System.Windows.Forms.ToolStripTextBox tstxtFilterCompany;
		private System.Windows.Forms.ToolStripButton tsbtnSaveCompany;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnUndoCompany;
		private System.Windows.Forms.ToolStripButton tsbtnResetCompanyFilter;
		private System.Windows.Forms.ToolStripButton tsbtnNewCompany;
		protected System.Windows.Forms.ToolStripComboBox cmbCompanyActiveFilter;
		private CompanyAuxDataSet dsCompanyAux;
		private System.Windows.Forms.BindingSource bsFacility;
		private SbcapcdOrg.ControlLibrary.usrSplitContainer splitContainer2;
		private SbcapcdOrg.ControlLibrary.usrSplitContainer splitContainer3;
		private System.Windows.Forms.DataGridView dgvFacility;
		private System.Windows.Forms.BindingSource bsContact;
		private System.Windows.Forms.DataGridView dgvContact;
		private System.Windows.Forms.ToolStripButton tsbtnDeleteCompany;
		private System.Windows.Forms.DataGridViewTextBoxColumn PersonNo;
		private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ContactTypeDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn streetAddressCompleteDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn contactIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn companyNoDataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn facilityNoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn facilityNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn companyNoDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn companyNoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn companyNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.ToolStripLabel tslblCompanyHasChanges;
	}
}
