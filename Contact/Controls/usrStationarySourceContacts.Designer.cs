namespace SbcapcdOrg.Contact
{
	partial class usrStationarySourceContacts
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
			System.Windows.Forms.Label billingContactIdLabel;
			System.Windows.Forms.Label correspondenceContactIdLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrStationarySourceContacts));
			this.splitContainer1 = new SbcapcdOrg.ControlLibrary.usrSplitContainer();
			this.dgvStationarySource = new System.Windows.Forms.DataGridView();
			this.stationarySourceNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.stationarySourceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.billingContactIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.correspondenceContactIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bsStationarySourceContacts = new System.Windows.Forms.BindingSource(this.components);
			this.dsStationarySourceContacts = new SbcapcdOrg.Contact.StationarySourceContactsDataSet();
			this.bnStationarySource = new System.Windows.Forms.BindingNavigator(this.components);
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnUndoStationarySourceContacts = new System.Windows.Forms.ToolStripButton();
			this.tsbtnSaveContact = new System.Windows.Forms.ToolStripButton();
			this.tstxtFilterSources = new System.Windows.Forms.ToolStripTextBox();
			this.tsbtnFilterSourceNulls = new System.Windows.Forms.ToolStripButton();
			this.tslblContactHasChanges = new System.Windows.Forms.ToolStripLabel();
			this.txtCorrespondenceContactId = new System.Windows.Forms.TextBox();
			this.txtBillingContactId = new System.Windows.Forms.TextBox();
			this.cmbCorrespondenceContactId = new System.Windows.Forms.ComboBox();
			this.bsStationarySourceCorrContacts = new System.Windows.Forms.BindingSource(this.components);
			this.cmbBillingContactId = new System.Windows.Forms.ComboBox();
			this.bsStationarySourceBillingContacts = new System.Windows.Forms.BindingSource(this.components);
			this.btnUpdateBillingContacts = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			billingContactIdLabel = new System.Windows.Forms.Label();
			correspondenceContactIdLabel = new System.Windows.Forms.Label();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStationarySource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsStationarySourceContacts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsStationarySourceContacts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bnStationarySource)).BeginInit();
			this.bnStationarySource.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsStationarySourceCorrContacts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsStationarySourceBillingContacts)).BeginInit();
			this.SuspendLayout();
			// 
			// billingContactIdLabel
			// 
			billingContactIdLabel.AutoSize = true;
			billingContactIdLabel.Location = new System.Drawing.Point(12, 66);
			billingContactIdLabel.Name = "billingContactIdLabel";
			billingContactIdLabel.Size = new System.Drawing.Size(92, 16);
			billingContactIdLabel.TabIndex = 0;
			billingContactIdLabel.Text = "Billing Contact";
			// 
			// correspondenceContactIdLabel
			// 
			correspondenceContactIdLabel.AutoSize = true;
			correspondenceContactIdLabel.Location = new System.Drawing.Point(9, 190);
			correspondenceContactIdLabel.Name = "correspondenceContactIdLabel";
			correspondenceContactIdLabel.Size = new System.Drawing.Size(151, 16);
			correspondenceContactIdLabel.TabIndex = 2;
			correspondenceContactIdLabel.Text = "Correspondence Contact";
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer1.Panel1.Controls.Add(this.dgvStationarySource);
			this.splitContainer1.Panel1.Controls.Add(this.bnStationarySource);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.AutoScroll = true;
			this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.btnUpdateBillingContacts);
			this.splitContainer1.Panel2.Controls.Add(this.txtCorrespondenceContactId);
			this.splitContainer1.Panel2.Controls.Add(this.txtBillingContactId);
			this.splitContainer1.Panel2.Controls.Add(correspondenceContactIdLabel);
			this.splitContainer1.Panel2.Controls.Add(this.cmbCorrespondenceContactId);
			this.splitContainer1.Panel2.Controls.Add(billingContactIdLabel);
			this.splitContainer1.Panel2.Controls.Add(this.cmbBillingContactId);
			this.splitContainer1.Size = new System.Drawing.Size(1000, 700);
			this.splitContainer1.SplitterDistance = 428;
			this.splitContainer1.TabIndex = 0;
			// 
			// dgvStationarySource
			// 
			this.dgvStationarySource.AllowUserToAddRows = false;
			this.dgvStationarySource.AllowUserToDeleteRows = false;
			this.dgvStationarySource.AllowUserToResizeRows = false;
			this.dgvStationarySource.AutoGenerateColumns = false;
			this.dgvStationarySource.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvStationarySource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStationarySource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stationarySourceNoDataGridViewTextBoxColumn,
            this.stationarySourceNameDataGridViewTextBoxColumn,
            this.billingContactIdDataGridViewTextBoxColumn,
            this.correspondenceContactIdDataGridViewTextBoxColumn});
			this.dgvStationarySource.DataSource = this.bsStationarySourceContacts;
			this.dgvStationarySource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvStationarySource.Location = new System.Drawing.Point(0, 25);
			this.dgvStationarySource.MultiSelect = false;
			this.dgvStationarySource.Name = "dgvStationarySource";
			this.dgvStationarySource.ReadOnly = true;
			this.dgvStationarySource.Size = new System.Drawing.Size(428, 675);
			this.dgvStationarySource.TabIndex = 1;
			// 
			// stationarySourceNoDataGridViewTextBoxColumn
			// 
			this.stationarySourceNoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.stationarySourceNoDataGridViewTextBoxColumn.DataPropertyName = "StationarySourceNo";
			this.stationarySourceNoDataGridViewTextBoxColumn.HeaderText = "SSID";
			this.stationarySourceNoDataGridViewTextBoxColumn.Name = "stationarySourceNoDataGridViewTextBoxColumn";
			this.stationarySourceNoDataGridViewTextBoxColumn.ReadOnly = true;
			this.stationarySourceNoDataGridViewTextBoxColumn.Width = 50;
			// 
			// stationarySourceNameDataGridViewTextBoxColumn
			// 
			this.stationarySourceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.stationarySourceNameDataGridViewTextBoxColumn.DataPropertyName = "StationarySourceName";
			this.stationarySourceNameDataGridViewTextBoxColumn.HeaderText = "Stationary Source";
			this.stationarySourceNameDataGridViewTextBoxColumn.Name = "stationarySourceNameDataGridViewTextBoxColumn";
			this.stationarySourceNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// billingContactIdDataGridViewTextBoxColumn
			// 
			this.billingContactIdDataGridViewTextBoxColumn.DataPropertyName = "BillingContactId";
			this.billingContactIdDataGridViewTextBoxColumn.HeaderText = "BillingContactId";
			this.billingContactIdDataGridViewTextBoxColumn.Name = "billingContactIdDataGridViewTextBoxColumn";
			this.billingContactIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.billingContactIdDataGridViewTextBoxColumn.Visible = false;
			// 
			// correspondenceContactIdDataGridViewTextBoxColumn
			// 
			this.correspondenceContactIdDataGridViewTextBoxColumn.DataPropertyName = "CorrespondenceContactId";
			this.correspondenceContactIdDataGridViewTextBoxColumn.HeaderText = "CorrespondenceContactId";
			this.correspondenceContactIdDataGridViewTextBoxColumn.Name = "correspondenceContactIdDataGridViewTextBoxColumn";
			this.correspondenceContactIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.correspondenceContactIdDataGridViewTextBoxColumn.Visible = false;
			// 
			// bsStationarySourceContacts
			// 
			this.bsStationarySourceContacts.DataMember = "StationarySourceContacts";
			this.bsStationarySourceContacts.DataSource = this.dsStationarySourceContacts;
			this.bsStationarySourceContacts.CurrentChanged += new System.EventHandler(this.bsStationarySourceContacts_CurrentChanged);
			// 
			// dsStationarySourceContacts
			// 
			this.dsStationarySourceContacts.DataSetName = "StationarySourceContactsDataSet";
			this.dsStationarySourceContacts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// bnStationarySource
			// 
			this.bnStationarySource.AddNewItem = null;
			this.bnStationarySource.BindingSource = this.bsStationarySourceContacts;
			this.bnStationarySource.CountItem = this.bindingNavigatorCountItem;
			this.bnStationarySource.DeleteItem = null;
			this.bnStationarySource.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bnStationarySource.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.bnStationarySource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.tsbtnUndoStationarySourceContacts,
            this.tsbtnSaveContact,
            this.tstxtFilterSources,
            this.tsbtnFilterSourceNulls,
            this.tslblContactHasChanges});
			this.bnStationarySource.Location = new System.Drawing.Point(0, 0);
			this.bnStationarySource.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bnStationarySource.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bnStationarySource.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bnStationarySource.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bnStationarySource.Name = "bnStationarySource";
			this.bnStationarySource.PositionItem = this.bindingNavigatorPositionItem;
			this.bnStationarySource.Size = new System.Drawing.Size(428, 25);
			this.bnStationarySource.TabIndex = 0;
			this.bnStationarySource.Text = "bindingNavigator1";
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.AutoSize = false;
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(50, 22);
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
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 22);
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
			// tsbtnUndoStationarySourceContacts
			// 
			this.tsbtnUndoStationarySourceContacts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnUndoStationarySourceContacts.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUndoStationarySourceContacts.Image")));
			this.tsbtnUndoStationarySourceContacts.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnUndoStationarySourceContacts.Name = "tsbtnUndoStationarySourceContacts";
			this.tsbtnUndoStationarySourceContacts.Size = new System.Drawing.Size(23, 22);
			this.tsbtnUndoStationarySourceContacts.Text = "toolStripButton1";
			this.tsbtnUndoStationarySourceContacts.ToolTipText = "Undo Stationary Source Contacts changes.";
			this.tsbtnUndoStationarySourceContacts.Click += new System.EventHandler(this.tsbtnUndoStationarySourceContacts_Click);
			// 
			// tsbtnSaveContact
			// 
			this.tsbtnSaveContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSaveContact.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaveContact.Image")));
			this.tsbtnSaveContact.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSaveContact.Name = "tsbtnSaveContact";
			this.tsbtnSaveContact.Size = new System.Drawing.Size(23, 22);
			this.tsbtnSaveContact.ToolTipText = "Save";
			this.tsbtnSaveContact.Click += new System.EventHandler(this.tsbtnSaveContact_Click);
			// 
			// tstxtFilterSources
			// 
			this.tstxtFilterSources.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tstxtFilterSources.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tstxtFilterSources.Name = "tstxtFilterSources";
			this.tstxtFilterSources.Size = new System.Drawing.Size(75, 25);
			this.tstxtFilterSources.ToolTipText = "Filter Stationary Sources";
			this.tstxtFilterSources.TextChanged += new System.EventHandler(this.tstxtFilterSources_TextChanged);
			// 
			// tsbtnFilterSourceNulls
			// 
			this.tsbtnFilterSourceNulls.CheckOnClick = true;
			this.tsbtnFilterSourceNulls.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnFilterSourceNulls.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFilterSourceNulls.Image")));
			this.tsbtnFilterSourceNulls.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnFilterSourceNulls.Name = "tsbtnFilterSourceNulls";
			this.tsbtnFilterSourceNulls.Size = new System.Drawing.Size(23, 22);
			this.tsbtnFilterSourceNulls.Text = "toolStripButton1";
			this.tsbtnFilterSourceNulls.ToolTipText = "Filter Source with no Billing or Correspondence contacts  (Red when filter on).";
			this.tsbtnFilterSourceNulls.Click += new System.EventHandler(this.tsbtnFilterSourceNulls_Click);
			// 
			// tslblContactHasChanges
			// 
			this.tslblContactHasChanges.ForeColor = System.Drawing.Color.Red;
			this.tslblContactHasChanges.Name = "tslblContactHasChanges";
			this.tslblContactHasChanges.Size = new System.Drawing.Size(62, 22);
			this.tslblContactHasChanges.Text = "Changes!";
			this.tslblContactHasChanges.Visible = false;
			// 
			// txtCorrespondenceContactId
			// 
			this.txtCorrespondenceContactId.BackColor = System.Drawing.SystemColors.Control;
			this.txtCorrespondenceContactId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtCorrespondenceContactId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsStationarySourceContacts, "CorrespondenceContactId", true));
			this.txtCorrespondenceContactId.ForeColor = System.Drawing.SystemColors.GrayText;
			this.txtCorrespondenceContactId.Location = new System.Drawing.Point(166, 191);
			this.txtCorrespondenceContactId.Name = "txtCorrespondenceContactId";
			this.txtCorrespondenceContactId.Size = new System.Drawing.Size(100, 15);
			this.txtCorrespondenceContactId.TabIndex = 5;
			// 
			// txtBillingContactId
			// 
			this.txtBillingContactId.BackColor = System.Drawing.SystemColors.Control;
			this.txtBillingContactId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtBillingContactId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsStationarySourceContacts, "BillingContactId", true));
			this.txtBillingContactId.ForeColor = System.Drawing.SystemColors.GrayText;
			this.txtBillingContactId.Location = new System.Drawing.Point(110, 67);
			this.txtBillingContactId.Name = "txtBillingContactId";
			this.txtBillingContactId.Size = new System.Drawing.Size(100, 15);
			this.txtBillingContactId.TabIndex = 4;
			// 
			// cmbCorrespondenceContactId
			// 
			this.cmbCorrespondenceContactId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCorrespondenceContactId.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsStationarySourceContacts, "CorrespondenceContactId", true));
			this.cmbCorrespondenceContactId.DataSource = this.bsStationarySourceCorrContacts;
			this.cmbCorrespondenceContactId.DisplayMember = "ContactDisplay";
			this.cmbCorrespondenceContactId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCorrespondenceContactId.DropDownWidth = 750;
			this.cmbCorrespondenceContactId.FormattingEnabled = true;
			this.cmbCorrespondenceContactId.Location = new System.Drawing.Point(9, 210);
			this.cmbCorrespondenceContactId.MaxDropDownItems = 16;
			this.cmbCorrespondenceContactId.Name = "cmbCorrespondenceContactId";
			this.cmbCorrespondenceContactId.Size = new System.Drawing.Size(548, 24);
			this.cmbCorrespondenceContactId.TabIndex = 3;
			this.cmbCorrespondenceContactId.ValueMember = "ContactId";
			this.cmbCorrespondenceContactId.SelectionChangeCommitted += new System.EventHandler(this.cmbCorrespondenceContactId_SelectionChangeCommitted);
			// 
			// bsStationarySourceCorrContacts
			// 
			this.bsStationarySourceCorrContacts.DataMember = "Contacts";
			this.bsStationarySourceCorrContacts.DataSource = this.dsStationarySourceContacts;
			this.bsStationarySourceCorrContacts.Filter = "ContactTypeId = 14";
			// 
			// cmbBillingContactId
			// 
			this.cmbBillingContactId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbBillingContactId.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsStationarySourceContacts, "BillingContactId", true));
			this.cmbBillingContactId.DataSource = this.bsStationarySourceBillingContacts;
			this.cmbBillingContactId.DisplayMember = "ContactDisplay";
			this.cmbBillingContactId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBillingContactId.DropDownWidth = 750;
			this.cmbBillingContactId.FormattingEnabled = true;
			this.cmbBillingContactId.Location = new System.Drawing.Point(12, 86);
			this.cmbBillingContactId.MaxDropDownItems = 16;
			this.cmbBillingContactId.Name = "cmbBillingContactId";
			this.cmbBillingContactId.Size = new System.Drawing.Size(545, 24);
			this.cmbBillingContactId.TabIndex = 1;
			this.cmbBillingContactId.ValueMember = "ContactId";
			this.cmbBillingContactId.SelectionChangeCommitted += new System.EventHandler(this.cmbBillingContactId_SelectionChangeCommitted);
			// 
			// bsStationarySourceBillingContacts
			// 
			this.bsStationarySourceBillingContacts.DataMember = "Contacts";
			this.bsStationarySourceBillingContacts.DataSource = this.dsStationarySourceContacts;
			this.bsStationarySourceBillingContacts.Filter = "ContactTypeId = 21";
			// 
			// btnUpdateBillingContacts
			// 
			this.btnUpdateBillingContacts.AutoSize = true;
			this.btnUpdateBillingContacts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnUpdateBillingContacts.FlatAppearance.BorderSize = 0;
			this.btnUpdateBillingContacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUpdateBillingContacts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnUpdateBillingContacts.ImageIndex = 0;
			this.btnUpdateBillingContacts.ImageList = this.imageList1;
			this.btnUpdateBillingContacts.Location = new System.Drawing.Point(15, 25);
			this.btnUpdateBillingContacts.Name = "btnUpdateBillingContacts";
			this.btnUpdateBillingContacts.Size = new System.Drawing.Size(79, 26);
			this.btnUpdateBillingContacts.TabIndex = 6;
			this.btnUpdateBillingContacts.Text = " Update";
			this.btnUpdateBillingContacts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnUpdateBillingContacts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnUpdateBillingContacts.UseVisualStyleBackColor = true;
			this.btnUpdateBillingContacts.Click += new System.EventHandler(this.btnUpdateBillingContacts_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			this.imageList1.Images.SetKeyName(0, "Output.bmp");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(94, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(269, 34);
			this.label1.TabIndex = 7;
			this.label1.Text = "Update missing Statinary Source contacts where there is only one billing contact." +
    "";
			// 
			// usrStationarySourceContacts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "usrStationarySourceContacts";
			this.Size = new System.Drawing.Size(1000, 700);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvStationarySource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsStationarySourceContacts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsStationarySourceContacts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bnStationarySource)).EndInit();
			this.bnStationarySource.ResumeLayout(false);
			this.bnStationarySource.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsStationarySourceCorrContacts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsStationarySourceBillingContacts)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private SbcapcdOrg.ControlLibrary.usrSplitContainer splitContainer1;
		private StationarySourceContactsDataSet dsStationarySourceContacts;
		private System.Windows.Forms.BindingNavigator bnStationarySource;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private System.Windows.Forms.DataGridView dgvStationarySource;
		private System.Windows.Forms.ToolStripButton tsbtnSaveContact;
		private System.Windows.Forms.ToolStripLabel tslblContactHasChanges;
		private System.Windows.Forms.BindingSource bsStationarySourceBillingContacts;
		private System.Windows.Forms.ComboBox cmbCorrespondenceContactId;
		private System.Windows.Forms.BindingSource bsStationarySourceContacts;
		private System.Windows.Forms.ComboBox cmbBillingContactId;
		private System.Windows.Forms.BindingSource bsStationarySourceCorrContacts;
		private System.Windows.Forms.DataGridViewTextBoxColumn stationarySourceNoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn stationarySourceNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn billingContactIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn correspondenceContactIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.ToolStripButton tsbtnUndoStationarySourceContacts;
		private System.Windows.Forms.ToolStripTextBox tstxtFilterSources;
		private System.Windows.Forms.ToolStripButton tsbtnFilterSourceNulls;
		private System.Windows.Forms.TextBox txtCorrespondenceContactId;
		private System.Windows.Forms.TextBox txtBillingContactId;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnUpdateBillingContacts;
		private System.Windows.Forms.ImageList imageList1;
	}
}
