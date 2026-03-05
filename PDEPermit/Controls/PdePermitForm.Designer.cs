namespace SbcapcdOrg.PdePermit.Forms
{
  partial class PDEPermit
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

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDEPermit));
			this.chkActiveCompanies = new System.Windows.Forms.CheckBox();
			this.chkFilterAllByCompany = new System.Windows.Forms.CheckBox();
			this.cmbCompanyFilter = new System.Windows.Forms.ComboBox();
			this.bsCompaniesWithFacilities = new System.Windows.Forms.BindingSource(this.components);
			this.dsPdePermitFormsAux = new SbcapcdOrg.PdePermit.Forms.PdePermitAuxDataSet();
			this.tbcPdePermit = new System.Windows.Forms.TabControl();
			this.tabStationarySource = new System.Windows.Forms.TabPage();
			this.StationarySource = new SbcapcdOrg.PdePermit.StationarySource.usrStationarySource();
			this.tabFacility = new System.Windows.Forms.TabPage();
			this.Facility = new SbcapcdOrg.PdePermit.Facility.usrFacility();
			this.tabPermit = new System.Windows.Forms.TabPage();
			this.Permit = new SbcapcdOrg.PdePermit.Permit.usrPermit();
			this.tabDevice = new System.Windows.Forms.TabPage();
			this.Device = new SbcapcdOrg.PdePermit.Device.usrDevice();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnHelp = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnRefreshCompanies = new System.Windows.Forms.Button();
			this.lblUnsavedChanges = new System.Windows.Forms.Label();
			this.grpSelectMode = new SbcapcdOrg.ControlLibrary.usrGroupBox();
			this.radSelectModeAll = new SbcapcdOrg.ControlLibrary.usrRadioButton();
			this.radSelectModeActive = new SbcapcdOrg.ControlLibrary.usrRadioButton();
			this.radSelectModeOff = new SbcapcdOrg.ControlLibrary.usrRadioButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pnlHelp = new System.Windows.Forms.Panel();
			this.splitContainer1 = new SbcapcdOrg.ControlLibrary.usrSplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblColumns = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblYellowHighligh = new System.Windows.Forms.Label();
			this.lblGreenHighlight = new System.Windows.Forms.Label();
			this.lblColumnHeader = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.dgvDemo = new System.Windows.Forms.DataGridView();
			this.companyNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.companyDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PermitStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmsDemo = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bsDemo = new System.Windows.Forms.BindingSource(this.components);
			this.splitContainer2 = new SbcapcdOrg.ControlLibrary.usrSplitContainer();
			this.label4 = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblcontrolColor = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.bsCompaniesWithFacilities)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPdePermitFormsAux)).BeginInit();
			this.tbcPdePermit.SuspendLayout();
			this.tabStationarySource.SuspendLayout();
			this.tabFacility.SuspendLayout();
			this.tabPermit.SuspendLayout();
			this.tabDevice.SuspendLayout();
			this.grpSelectMode.SuspendLayout();
			this.pnlHelp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDemo)).BeginInit();
			this.cmsDemo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsDemo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkActiveCompanies
			// 
			this.chkActiveCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkActiveCompanies.AutoSize = true;
			this.chkActiveCompanies.Checked = true;
			this.chkActiveCompanies.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkActiveCompanies.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkActiveCompanies.ForeColor = System.Drawing.SystemColors.GrayText;
			this.chkActiveCompanies.Location = new System.Drawing.Point(873, 27);
			this.chkActiveCompanies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.chkActiveCompanies.Name = "chkActiveCompanies";
			this.chkActiveCompanies.Size = new System.Drawing.Size(113, 18);
			this.chkActiveCompanies.TabIndex = 2;
			this.chkActiveCompanies.Text = "Active Companies";
			this.toolTip1.SetToolTip(this.chkActiveCompanies, "List only active Companies.");
			this.chkActiveCompanies.UseVisualStyleBackColor = true;
			this.chkActiveCompanies.Click += new System.EventHandler(this.chkActiveCompanies_Click);
			// 
			// chkFilterAllByCompany
			// 
			this.chkFilterAllByCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkFilterAllByCompany.AutoSize = true;
			this.chkFilterAllByCompany.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkFilterAllByCompany.Location = new System.Drawing.Point(750, 27);
			this.chkFilterAllByCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.chkFilterAllByCompany.Name = "chkFilterAllByCompany";
			this.chkFilterAllByCompany.Size = new System.Drawing.Size(113, 18);
			this.chkFilterAllByCompany.TabIndex = 1;
			this.chkFilterAllByCompany.Text = "Filter By Company";
			this.toolTip1.SetToolTip(this.chkFilterAllByCompany, "Filters Source, Facility and Permit by the selected Company");
			this.chkFilterAllByCompany.UseVisualStyleBackColor = true;
			this.chkFilterAllByCompany.Click += new System.EventHandler(this.chkFilterAllByCompany_Click);
			// 
			// cmbCompanyFilter
			// 
			this.cmbCompanyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCompanyFilter.BackColor = System.Drawing.SystemColors.Control;
			this.cmbCompanyFilter.DataSource = this.bsCompaniesWithFacilities;
			this.cmbCompanyFilter.DisplayMember = "CompanyDesc";
			this.cmbCompanyFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCompanyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCompanyFilter.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbCompanyFilter.FormattingEnabled = true;
			this.cmbCompanyFilter.Location = new System.Drawing.Point(749, 3);
			this.cmbCompanyFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cmbCompanyFilter.MaxDropDownItems = 16;
			this.cmbCompanyFilter.Name = "cmbCompanyFilter";
			this.cmbCompanyFilter.Size = new System.Drawing.Size(266, 22);
			this.cmbCompanyFilter.TabIndex = 0;
			this.toolTip1.SetToolTip(this.cmbCompanyFilter, "Select Company to filter by.");
			this.cmbCompanyFilter.ValueMember = "CompanyNo";
			this.cmbCompanyFilter.SelectionChangeCommitted += new System.EventHandler(this.cmbCompanyFilter_SelectionChangeCommitted);
			// 
			// bsCompaniesWithFacilities
			// 
			this.bsCompaniesWithFacilities.DataMember = "CompaniesWithFacilities";
			this.bsCompaniesWithFacilities.DataSource = this.dsPdePermitFormsAux;
			// 
			// dsPdePermitFormsAux
			// 
			this.dsPdePermitFormsAux.DataSetName = "PdePermitAuxDataSet";
			this.dsPdePermitFormsAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// tbcPdePermit
			// 
			this.tbcPdePermit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbcPdePermit.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tbcPdePermit.Controls.Add(this.tabStationarySource);
			this.tbcPdePermit.Controls.Add(this.tabFacility);
			this.tbcPdePermit.Controls.Add(this.tabPermit);
			this.tbcPdePermit.Controls.Add(this.tabDevice);
			this.tbcPdePermit.Enabled = false;
			this.tbcPdePermit.HotTrack = true;
			this.tbcPdePermit.Location = new System.Drawing.Point(0, 24);
			this.tbcPdePermit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbcPdePermit.Name = "tbcPdePermit";
			this.tbcPdePermit.SelectedIndex = 0;
			this.tbcPdePermit.Size = new System.Drawing.Size(1023, 725);
			this.tbcPdePermit.TabIndex = 0;
			this.tbcPdePermit.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbcPdePermit_Selecting);
			this.tbcPdePermit.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcPdePermit_Selected);
			this.tbcPdePermit.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbcPdePermit_Deselecting);
			// 
			// tabStationarySource
			// 
			this.tabStationarySource.Controls.Add(this.StationarySource);
			this.tabStationarySource.Location = new System.Drawing.Point(4, 28);
			this.tabStationarySource.Name = "tabStationarySource";
			this.tabStationarySource.Padding = new System.Windows.Forms.Padding(3);
			this.tabStationarySource.Size = new System.Drawing.Size(1015, 620);
			this.tabStationarySource.TabIndex = 4;
			this.tabStationarySource.Text = "Stationary Source";
			this.tabStationarySource.UseVisualStyleBackColor = true;
			// 
			// StationarySource
			// 
			this.StationarySource.AutoScroll = true;
			this.StationarySource.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.StationarySource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StationarySource.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StationarySource.LoadEnded = false;
			this.StationarySource.Location = new System.Drawing.Point(3, 3);
			this.StationarySource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.StationarySource.Name = "StationarySource";
			this.StationarySource.Size = new System.Drawing.Size(1009, 614);
			this.StationarySource.TabIndex = 0;
			this.StationarySource.usrConnectionString = null;
			this.StationarySource.OnStationarySourceDataSetChanged += new SbcapcdOrg.PdePermit.StationarySource.usrStationarySource.StationarySourceDataSetChangedEventHandler(this.StationarySource_OnStationarySourceDataSetChanged);
			this.StationarySource.OnEntityCurrentChanged += new SbcapcdOrg.PdePermit.StationarySource.usrStationarySource.EntityCurrentChangedEventHandler(this.StationarySource_OnEntityCurrentChanged);
			this.StationarySource.OnNewStationarySource += new SbcapcdOrg.PdePermit.StationarySource.usrStationarySource.NewStationarySourceEventHandler(this.StationarySource_OnNewStationarySource);
			this.StationarySource.OnGoToEntity += new SbcapcdOrg.PdePermit.StationarySource.usrStationarySource.GoToEntityEventHandler(this.StationarySource_OnGoToEntity);
			// 
			// tabFacility
			// 
			this.tabFacility.Controls.Add(this.Facility);
			this.tabFacility.Location = new System.Drawing.Point(4, 28);
			this.tabFacility.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabFacility.Name = "tabFacility";
			this.tabFacility.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabFacility.Size = new System.Drawing.Size(1015, 620);
			this.tabFacility.TabIndex = 1;
			this.tabFacility.Text = "Facility";
			this.tabFacility.UseVisualStyleBackColor = true;
			// 
			// Facility
			// 
			this.Facility.AutoScroll = true;
			this.Facility.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Facility.Cursor = System.Windows.Forms.Cursors.Default;
			this.Facility.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Facility.FacilityDataSetHasChanges = false;
			this.Facility.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Facility.Location = new System.Drawing.Point(3, 4);
			this.Facility.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Facility.Name = "Facility";
			this.Facility.Size = new System.Drawing.Size(1009, 612);
			this.Facility.TabIndex = 0;
			this.Facility.usrConnectionString = null;
			this.Facility.OnFacilityDataSetChanged += new SbcapcdOrg.PdePermit.Facility.usrFacility.FacilityDataSetChangedEventHandler(this.Facility_OnFacilityDataSetChanged);
			this.Facility.OnEntityCurrentChanged += new SbcapcdOrg.PdePermit.Facility.usrFacility.EntityCurrentChangedEventHandler(this.Facility_OnEntityCurrentChanged);
			this.Facility.OnGoToEntity += new SbcapcdOrg.PdePermit.Facility.usrFacility.GoToEntityEventHandler(this.Facility_OnGoToEntity);
			this.Facility.OnNewFacility += new SbcapcdOrg.PdePermit.Facility.usrFacility.NewFacilityEventHandler(this.Facility_OnNewFacility);
			this.Facility.OnFacilityLoadEnd += new SbcapcdOrg.PdePermit.Facility.usrFacility.FacilityLoadEndEventHandler(this.Facility_OnFacilityLoadEnd);
			this.Facility.OnCopyFacilityLocation += new SbcapcdOrg.PdePermit.Facility.usrFacility.CopyFacilityLocationEventHandler(this.Facility_OnCopyFacilityLocation);
			// 
			// tabPermit
			// 
			this.tabPermit.Controls.Add(this.Permit);
			this.tabPermit.Location = new System.Drawing.Point(4, 28);
			this.tabPermit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPermit.Name = "tabPermit";
			this.tabPermit.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPermit.Size = new System.Drawing.Size(1015, 620);
			this.tabPermit.TabIndex = 2;
			this.tabPermit.Text = "Permit";
			this.tabPermit.UseVisualStyleBackColor = true;
			// 
			// Permit
			// 
			this.Permit.AutoScroll = true;
			this.Permit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Permit.Cursor = System.Windows.Forms.Cursors.Default;
			this.Permit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Permit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Permit.Location = new System.Drawing.Point(3, 4);
			this.Permit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Permit.Name = "Permit";
			this.Permit.ReevalDueDataSetHasChanges = false;
			this.Permit.Size = new System.Drawing.Size(1009, 612);
			this.Permit.TabIndex = 0;
			this.Permit.usrConnectionString = null;
			this.Permit.OnPermitDataSetChanged += new SbcapcdOrg.PdePermit.Permit.usrPermit.PermitDataSetChangedEventHandler(this.Permit_OnPermitDataSetChanged);
			this.Permit.OnGoToEntity += new SbcapcdOrg.PdePermit.Permit.usrPermit.GoToEntityEventHandler(this.Permit_OnGoToEntity);
			this.Permit.OnEntityCurrentChanged += new SbcapcdOrg.PdePermit.Permit.usrPermit.EntityCurrentChangedEventHandler(this.Permit_OnEntityCurrentChanged);
			this.Permit.OnCopyEmissionsGrid += new SbcapcdOrg.PdePermit.Permit.usrPermit.CopyEmissionsGridEventHandler(this.Permit_OnCopyEmissionsGrid);
			// 
			// tabDevice
			// 
			this.tabDevice.Controls.Add(this.Device);
			this.tabDevice.Location = new System.Drawing.Point(4, 28);
			this.tabDevice.Name = "tabDevice";
			this.tabDevice.Padding = new System.Windows.Forms.Padding(3);
			this.tabDevice.Size = new System.Drawing.Size(1015, 620);
			this.tabDevice.TabIndex = 3;
			this.tabDevice.Text = "Device";
			this.tabDevice.UseVisualStyleBackColor = true;
			// 
			// Device
			// 
			this.Device.AutoScroll = true;
			this.Device.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Device.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Device.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Device.Location = new System.Drawing.Point(3, 3);
			this.Device.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Device.Name = "Device";
			this.Device.Size = new System.Drawing.Size(1009, 614);
			this.Device.TabIndex = 0;
			this.Device.usrConnectionString = null;
			// 
			// toolTip1
			// 
			this.toolTip1.IsBalloon = true;
			// 
			// btnHelp
			// 
			this.btnHelp.AutoSize = true;
			this.btnHelp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnHelp.FlatAppearance.BorderSize = 0;
			this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHelp.ImageIndex = 2;
			this.btnHelp.ImageList = this.imageList1;
			this.btnHelp.Location = new System.Drawing.Point(599, 18);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(22, 22);
			this.btnHelp.TabIndex = 11;
			this.toolTip1.SetToolTip(this.btnHelp, "Show/Hide Quick Help and Legend for PDEPermit");
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			this.imageList1.Images.SetKeyName(0, "SaveAll.bmp");
			this.imageList1.Images.SetKeyName(1, "SaveAllHS.bmp");
			this.imageList1.Images.SetKeyName(2, "Help.bmp");
			this.imageList1.Images.SetKeyName(3, "Edit_Undo.bmp");
			this.imageList1.Images.SetKeyName(4, "Repeat.bmp");
			this.imageList1.Images.SetKeyName(5, "Refresh.bmp");
			// 
			// btnRefreshCompanies
			// 
			this.btnRefreshCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefreshCompanies.AutoSize = true;
			this.btnRefreshCompanies.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnRefreshCompanies.FlatAppearance.BorderSize = 0;
			this.btnRefreshCompanies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefreshCompanies.ImageKey = "Refresh.bmp";
			this.btnRefreshCompanies.ImageList = this.imageList1;
			this.btnRefreshCompanies.Location = new System.Drawing.Point(996, 24);
			this.btnRefreshCompanies.Name = "btnRefreshCompanies";
			this.btnRefreshCompanies.Size = new System.Drawing.Size(22, 22);
			this.btnRefreshCompanies.TabIndex = 12;
			this.toolTip1.SetToolTip(this.btnRefreshCompanies, "Refresh Companies for Facility tab");
			this.btnRefreshCompanies.UseVisualStyleBackColor = true;
			this.btnRefreshCompanies.Click += new System.EventHandler(this.btnRefreshCompanies_Click);
			// 
			// lblUnsavedChanges
			// 
			this.lblUnsavedChanges.AutoSize = true;
			this.lblUnsavedChanges.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUnsavedChanges.ForeColor = System.Drawing.Color.Red;
			this.lblUnsavedChanges.Location = new System.Drawing.Point(5, 4);
			this.lblUnsavedChanges.Name = "lblUnsavedChanges";
			this.lblUnsavedChanges.Size = new System.Drawing.Size(84, 16);
			this.lblUnsavedChanges.TabIndex = 4;
			this.lblUnsavedChanges.Text = "\"Loading...\"";
			this.lblUnsavedChanges.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpSelectMode
			// 
			this.grpSelectMode.Controls.Add(this.radSelectModeAll);
			this.grpSelectMode.Controls.Add(this.radSelectModeActive);
			this.grpSelectMode.Controls.Add(this.radSelectModeOff);
			this.grpSelectMode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpSelectMode.Location = new System.Drawing.Point(350, 6);
			this.grpSelectMode.Name = "grpSelectMode";
			this.grpSelectMode.RaiseOnGroupBoxClick = true;
			this.grpSelectMode.Size = new System.Drawing.Size(238, 41);
			this.grpSelectMode.TabIndex = 9;
			this.grpSelectMode.TabStop = false;
			this.grpSelectMode.Tag = "Off";
			this.grpSelectMode.Text = "Select Mode";
			// 
			// radSelectModeAll
			// 
			this.radSelectModeAll.AutoSize = true;
			this.radSelectModeAll.Location = new System.Drawing.Point(130, 16);
			this.radSelectModeAll.Name = "radSelectModeAll";
			this.radSelectModeAll.Size = new System.Drawing.Size(105, 18);
			this.radSelectModeAll.TabIndex = 2;
			this.radSelectModeAll.Tag = "All";
			this.radSelectModeAll.Text = "Active + Inactive";
			this.radSelectModeAll.UseVisualStyleBackColor = true;
			this.radSelectModeAll.Click += new System.EventHandler(this.radSelectModeAll_Click);
			// 
			// radSelectModeActive
			// 
			this.radSelectModeActive.AutoSize = true;
			this.radSelectModeActive.Location = new System.Drawing.Point(48, 16);
			this.radSelectModeActive.Name = "radSelectModeActive";
			this.radSelectModeActive.Size = new System.Drawing.Size(81, 18);
			this.radSelectModeActive.TabIndex = 1;
			this.radSelectModeActive.Tag = "Active";
			this.radSelectModeActive.Text = "Active Only";
			this.radSelectModeActive.UseVisualStyleBackColor = true;
			this.radSelectModeActive.Click += new System.EventHandler(this.radSelectModeActive_Click);
			// 
			// radSelectModeOff
			// 
			this.radSelectModeOff.AutoSize = true;
			this.radSelectModeOff.Checked = true;
			this.radSelectModeOff.Location = new System.Drawing.Point(6, 16);
			this.radSelectModeOff.Name = "radSelectModeOff";
			this.radSelectModeOff.Size = new System.Drawing.Size(41, 18);
			this.radSelectModeOff.TabIndex = 0;
			this.radSelectModeOff.TabStop = true;
			this.radSelectModeOff.Tag = "Off";
			this.radSelectModeOff.Text = "Off";
			this.radSelectModeOff.UseVisualStyleBackColor = true;
			this.radSelectModeOff.Click += new System.EventHandler(this.radSelectModeOff_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// pnlHelp
			// 
			this.pnlHelp.Controls.Add(this.splitContainer1);
			this.pnlHelp.Location = new System.Drawing.Point(4, 50);
			this.pnlHelp.Name = "pnlHelp";
			this.pnlHelp.Size = new System.Drawing.Size(1019, 612);
			this.pnlHelp.TabIndex = 10;
			this.pnlHelp.Visible = false;
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
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			this.splitContainer1.Panel1.Controls.Add(this.dgvDemo);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(1019, 612);
			this.splitContainer1.SplitterDistance = 725;
			this.splitContainer1.SplitterWidth = 6;
			this.splitContainer1.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.lblColumns, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.lblYellowHighligh, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblGreenHighlight, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblColumnHeader, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(464, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.88889F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(261, 612);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// lblColumns
			// 
			this.lblColumns.AutoSize = true;
			this.lblColumns.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tableLayoutPanel1.SetColumnSpan(this.lblColumns, 2);
			this.lblColumns.Location = new System.Drawing.Point(8, 59);
			this.lblColumns.Name = "lblColumns";
			this.lblColumns.Size = new System.Drawing.Size(243, 160);
			this.lblColumns.TabIndex = 4;
			this.lblColumns.Text = resources.GetString("lblColumns.Text");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
			this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label2.Location = new System.Drawing.Point(8, 543);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(245, 64);
			this.label2.TabIndex = 1;
			this.label2.Text = "* You can press the Esc key to undo the creation of a new list item in the last r" +
    "ow of a table. If there is no * on the last row, a new row can not be added.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lblYellowHighligh
			// 
			this.lblYellowHighligh.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.lblYellowHighligh.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblYellowHighligh.Location = new System.Drawing.Point(8, 289);
			this.lblYellowHighligh.Name = "lblYellowHighligh";
			this.lblYellowHighligh.Size = new System.Drawing.Size(119, 109);
			this.lblYellowHighligh.TabIndex = 2;
			this.lblYellowHighligh.Text = "A yellow highlight means the stationary source, facility, or permit is inactive.\r" +
    "\n\r\n";
			this.lblYellowHighligh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblGreenHighlight
			// 
			this.lblGreenHighlight.BackColor = System.Drawing.Color.Honeydew;
			this.lblGreenHighlight.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblGreenHighlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblGreenHighlight.Location = new System.Drawing.Point(133, 289);
			this.lblGreenHighlight.Name = "lblGreenHighlight";
			this.lblGreenHighlight.Size = new System.Drawing.Size(120, 109);
			this.lblGreenHighlight.TabIndex = 3;
			this.lblGreenHighlight.Text = "A green highlight (Permit tab only) means the permit has been created in PSA Perm" +
    "it.";
			this.lblGreenHighlight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblColumnHeader
			// 
			this.lblColumnHeader.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.lblColumnHeader, 2);
			this.lblColumnHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblColumnHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblColumnHeader.ForeColor = System.Drawing.Color.Navy;
			this.lblColumnHeader.Location = new System.Drawing.Point(8, 5);
			this.lblColumnHeader.Name = "lblColumnHeader";
			this.lblColumnHeader.Size = new System.Drawing.Size(245, 19);
			this.lblColumnHeader.TabIndex = 5;
			this.lblColumnHeader.Text = "Data table explanation";
			this.lblColumnHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tableLayoutPanel1.SetColumnSpan(this.label7, 2);
			this.label7.Location = new System.Drawing.Point(8, 423);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(242, 80);
			this.label7.TabIndex = 5;
			this.label7.Text = "IF you right click on a table you may have the option \"CopyToClipboard\". This wil" +
    "l copy the the current content of the table, which can then be pasted into Word," +
    " Excel, etc.";
			// 
			// dgvDemo
			// 
			this.dgvDemo.AllowUserToOrderColumns = true;
			this.dgvDemo.AllowUserToResizeRows = false;
			this.dgvDemo.AutoGenerateColumns = false;
			this.dgvDemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvDemo.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dgvDemo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDemo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.companyNoDataGridViewTextBoxColumn,
            this.companyDescDataGridViewTextBoxColumn,
            this.PermitStatus});
			this.dgvDemo.ContextMenuStrip = this.cmsDemo;
			this.dgvDemo.DataSource = this.bsDemo;
			this.dgvDemo.Dock = System.Windows.Forms.DockStyle.Left;
			this.dgvDemo.Location = new System.Drawing.Point(0, 0);
			this.dgvDemo.Name = "dgvDemo";
			this.dgvDemo.Size = new System.Drawing.Size(404, 612);
			this.dgvDemo.TabIndex = 0;
			this.dgvDemo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDemo_CellFormatting);
			this.dgvDemo.Sorted += new System.EventHandler(this.dgvDemo_Sorted);
			// 
			// companyNoDataGridViewTextBoxColumn
			// 
			this.companyNoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.companyNoDataGridViewTextBoxColumn.DataPropertyName = "CompanyNo";
			this.companyNoDataGridViewTextBoxColumn.HeaderText = "CompanyNo";
			this.companyNoDataGridViewTextBoxColumn.Name = "companyNoDataGridViewTextBoxColumn";
			this.companyNoDataGridViewTextBoxColumn.Width = 104;
			// 
			// companyDescDataGridViewTextBoxColumn
			// 
			this.companyDescDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.companyDescDataGridViewTextBoxColumn.DataPropertyName = "CompanyDesc";
			this.companyDescDataGridViewTextBoxColumn.HeaderText = "Example (Company)";
			this.companyDescDataGridViewTextBoxColumn.Name = "companyDescDataGridViewTextBoxColumn";
			this.companyDescDataGridViewTextBoxColumn.Width = 188;
			// 
			// PermitStatus
			// 
			this.PermitStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.PermitStatus.DataPropertyName = "PermitStatus";
			this.PermitStatus.HeaderText = "Status";
			this.PermitStatus.Name = "PermitStatus";
			this.PermitStatus.ReadOnly = true;
			this.PermitStatus.Width = 71;
			// 
			// cmsDemo
			// 
			this.cmsDemo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem});
			this.cmsDemo.Name = "cmsDemo";
			this.cmsDemo.Size = new System.Drawing.Size(169, 26);
			// 
			// copyToClipboardToolStripMenuItem
			// 
			this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
			this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.copyToClipboardToolStripMenuItem.Text = "CopyToClipboard";
			this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
			// 
			// bsDemo
			// 
			this.bsDemo.DataMember = "CompaniesWithFacilities";
			this.bsDemo.DataSource = this.dsPdePermitFormsAux;
			this.bsDemo.Filter = "CompanyNo < \'000125\'";
			this.bsDemo.Sort = "CompanyDesc";
			// 
			// splitContainer2
			// 
			this.splitContainer2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.label4);
			this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
			this.splitContainer2.Panel1.Controls.Add(this.panel1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.label1);
			this.splitContainer2.Size = new System.Drawing.Size(288, 612);
			this.splitContainer2.SplitterDistance = 428;
			this.splitContainer2.SplitterWidth = 6;
			this.splitContainer2.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 147);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(200, 80);
			this.label4.TabIndex = 8;
			this.label4.Text = "** after a permit and facility listing on stationary source and facility tabs mea" +
    "ns those items are inactive.";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.94296F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.05704F));
			this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 10);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 90);
			this.tableLayoutPanel2.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(32, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(209, 90);
			this.label3.TabIndex = 0;
			this.label3.Text = " This button will undo all changes made since the last save. It is for all data e" +
    "ntered on all sub-tabs tab of the Stationary Source, Facility and Permit tabs.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.AutoSize = true;
			this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.ImageIndex = 3;
			this.button1.ImageList = this.imageList1;
			this.button1.Location = new System.Drawing.Point(3, 3);
			this.button1.Name = "button1";
			this.button1.Padding = new System.Windows.Forms.Padding(10);
			this.button1.Size = new System.Drawing.Size(23, 42);
			this.button1.TabIndex = 4;
			this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblcontrolColor);
			this.panel1.Location = new System.Drawing.Point(30, 260);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 100);
			this.panel1.TabIndex = 6;
			// 
			// lblcontrolColor
			// 
			this.lblcontrolColor.BackColor = System.Drawing.SystemColors.Control;
			this.lblcontrolColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblcontrolColor.ForeColor = System.Drawing.Color.MediumBlue;
			this.lblcontrolColor.Location = new System.Drawing.Point(0, 0);
			this.lblcontrolColor.Margin = new System.Windows.Forms.Padding(3);
			this.lblcontrolColor.Name = "lblcontrolColor";
			this.lblcontrolColor.Padding = new System.Windows.Forms.Padding(5);
			this.lblcontrolColor.Size = new System.Drawing.Size(200, 100);
			this.lblcontrolColor.TabIndex = 5;
			this.lblcontrolColor.Text = "A control with this color label has data that can be edited by PDEPermit editors." +
    "  All other data can only be edited by PDEPermit administrators.";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(288, 69);
			this.label1.TabIndex = 0;
			this.label1.Text = "A light strip (like these above and left) show a divider between two resizable pa" +
    "nels.\r\nThe ones here are wider than those in the tabs. Click and drag to resize." +
    "";
			// 
			// PDEPermit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(1024, 725);
			this.Controls.Add(this.btnRefreshCompanies);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.pnlHelp);
			this.Controls.Add(this.grpSelectMode);
			this.Controls.Add(this.lblUnsavedChanges);
			this.Controls.Add(this.chkActiveCompanies);
			this.Controls.Add(this.chkFilterAllByCompany);
			this.Controls.Add(this.cmbCompanyFilter);
			this.Controls.Add(this.tbcPdePermit);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PDEPermit";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "  PDE Permit";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PDEPermit_FormClosing);
			this.Shown += new System.EventHandler(this.PDEPermit_Shown);
			this.Controls.SetChildIndex(this.tbcPdePermit, 0);
			this.Controls.SetChildIndex(this.cmbCompanyFilter, 0);
			this.Controls.SetChildIndex(this.chkFilterAllByCompany, 0);
			this.Controls.SetChildIndex(this.chkActiveCompanies, 0);
			this.Controls.SetChildIndex(this.lblUnsavedChanges, 0);
			this.Controls.SetChildIndex(this.grpSelectMode, 0);
			this.Controls.SetChildIndex(this.pnlHelp, 0);
			this.Controls.SetChildIndex(this.btnHelp, 0);
			this.Controls.SetChildIndex(this.btnRefreshCompanies, 0);
			((System.ComponentModel.ISupportInitialize)(this.bsCompaniesWithFacilities)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPdePermitFormsAux)).EndInit();
			this.tbcPdePermit.ResumeLayout(false);
			this.tabStationarySource.ResumeLayout(false);
			this.tabFacility.ResumeLayout(false);
			this.tabPermit.ResumeLayout(false);
			this.tabDevice.ResumeLayout(false);
			this.grpSelectMode.ResumeLayout(false);
			this.grpSelectMode.PerformLayout();
			this.pnlHelp.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDemo)).EndInit();
			this.cmsDemo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bsDemo)).EndInit();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

	}


	#endregion

	private System.Windows.Forms.TabControl tbcPdePermit;
	private System.Windows.Forms.TabPage tabFacility;
	private System.Windows.Forms.TabPage tabPermit;
	private System.Windows.Forms.BindingSource bsCompaniesWithFacilities;
	private System.Windows.Forms.ComboBox cmbCompanyFilter;
	private System.Windows.Forms.CheckBox chkActiveCompanies;
	private System.Windows.Forms.CheckBox chkFilterAllByCompany;
	private System.Windows.Forms.TabPage tabDevice;
    private System.Windows.Forms.ToolTip toolTip1;
	private System.Windows.Forms.Label lblUnsavedChanges;
	private System.Windows.Forms.TabPage tabStationarySource;
	private System.Windows.Forms.ImageList imageList1;
	private SbcapcdOrg.PdePermit.Forms.PdePermitAuxDataSet dsPdePermitFormsAux;
	private SbcapcdOrg.PdePermit.StationarySource.usrStationarySource StationarySource;
	private SbcapcdOrg.PdePermit.Permit.usrPermit Permit;
	private SbcapcdOrg.PdePermit.Facility.usrFacility Facility;
    private SbcapcdOrg.PdePermit.Device.usrDevice Device;
	private SbcapcdOrg.ControlLibrary.usrGroupBox grpSelectMode;
	private SbcapcdOrg.ControlLibrary.usrRadioButton radSelectModeAll;
	private SbcapcdOrg.ControlLibrary.usrRadioButton radSelectModeActive;
	private SbcapcdOrg.ControlLibrary.usrRadioButton radSelectModeOff;
	private System.Windows.Forms.Timer timer1;
	private System.Windows.Forms.Panel pnlHelp;
	private System.Windows.Forms.Button btnHelp;
	private System.Windows.Forms.DataGridView dgvDemo;
	private SbcapcdOrg.ControlLibrary.usrSplitContainer splitContainer1;
	private System.Windows.Forms.Label label1;
	private SbcapcdOrg.ControlLibrary.usrSplitContainer splitContainer2;
	private System.Windows.Forms.BindingSource bsDemo;
	private System.Windows.Forms.Label lblYellowHighligh;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label lblGreenHighlight;
	private System.Windows.Forms.Label lblColumns;
	private System.Windows.Forms.ContextMenuStrip cmsDemo;
	private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
	private System.Windows.Forms.Label label7;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.Label lblcontrolColor;
	private System.Windows.Forms.DataGridViewTextBoxColumn companyNoDataGridViewTextBoxColumn;
	private System.Windows.Forms.DataGridViewTextBoxColumn companyDescDataGridViewTextBoxColumn;
	private System.Windows.Forms.DataGridViewTextBoxColumn PermitStatus;
	private System.Windows.Forms.Panel panel1;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	private System.Windows.Forms.Label lblColumnHeader;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnRefreshCompanies;

  }
}

