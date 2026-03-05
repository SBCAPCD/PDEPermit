namespace SbcapcdOrg.PdePermit.Device
{
  partial class usrDevice
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrDevice));
			this.deviceNameLabel = new System.Windows.Forms.Label();
			this.operatorIDLabel = new System.Windows.Forms.Label();
			this.makeLabel = new System.Windows.Forms.Label();
			this.manufacturerLabel = new System.Windows.Forms.Label();
			this.modelLabel = new System.Windows.Forms.Label();
			this.serialNoLabel = new System.Windows.Forms.Label();
			this.ratedHeatInputLabel = new System.Windows.Forms.Label();
			this.bSFCLabel = new System.Windows.Forms.Label();
			this.physicalSizeLabel = new System.Windows.Forms.Label();
			this.deviceSpecificTypeLabel = new System.Windows.Forms.Label();
			this.deviceTypeLabel = new System.Windows.Forms.Label();
			this.deviceDescriptionLabel = new System.Windows.Forms.Label();
			this.commentsLabel = new System.Windows.Forms.Label();
			this.locationNoteLabel = new System.Windows.Forms.Label();
			this.amendsPermitLabel = new System.Windows.Forms.Label();
			this.deviceNoLabel = new System.Windows.Forms.Label();
			this.bnDeviceList = new System.Windows.Forms.BindingNavigator(this.components);
			this.bsNavigate = new System.Windows.Forms.BindingSource(this.components);
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnExpandTree = new System.Windows.Forms.ToolStripButton();
			this.tsbtnColapseTree = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tstxtDeviceNo = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnGoToDevice = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tstxtPermitNumber = new System.Windows.Forms.ToolStripTextBox();
			this.tsbtnGetPermits = new System.Windows.Forms.ToolStripButton();
			this.tscmbPermitList = new System.Windows.Forms.ToolStripComboBox();
			this.tsbtnStopTimer = new System.Windows.Forms.ToolStripButton();
			this.tslblSourceFaciltiyPermit = new System.Windows.Forms.ToolStripLabel();
			this.deviceNameTextBox = new System.Windows.Forms.TextBox();
			this.bsDeviceList = new System.Windows.Forms.BindingSource(this.components);
			this.dsDevice = new SbcapcdOrg.PdePermit.Device.DeviceDataSet();
			this.scDevice = new SbcapcdOrg.ControlLibrary.usrSplitContainer();
			this.trvDevices = new System.Windows.Forms.TreeView();
			this.imlDeviceTree = new System.Windows.Forms.ImageList(this.components);
			this.scDevice2 = new SbcapcdOrg.ControlLibrary.usrSplitContainer();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.isNamingDeviceCheckBox = new System.Windows.Forms.CheckBox();
			this.chkIsGroup = new System.Windows.Forms.CheckBox();
			this.permitNoDeviceNoTextBox = new System.Windows.Forms.TextBox();
			this.txtDeviceNo = new System.Windows.Forms.TextBox();
			this.deviceDescriptionTextBox = new System.Windows.Forms.TextBox();
			this.txtNodePath = new System.Windows.Forms.TextBox();
			this.amendsPermitTextBox = new System.Windows.Forms.TextBox();
			this.commentsTextBox = new System.Windows.Forms.TextBox();
			this.locationNoteTextBox = new System.Windows.Forms.TextBox();
			this.deviceTypeTextBox = new System.Windows.Forms.TextBox();
			this.operatorIDTextBox = new System.Windows.Forms.TextBox();
			this.deviceSpecificTypeTextBox = new System.Windows.Forms.TextBox();
			this.makeTextBox = new System.Windows.Forms.TextBox();
			this.chkPart70Insignificant = new System.Windows.Forms.CheckBox();
			this.chkNotInService = new System.Windows.Forms.CheckBox();
			this.manufacturerTextBox = new System.Windows.Forms.TextBox();
			this.isOffpermitCheckBox = new System.Windows.Forms.CheckBox();
			this.chkExempt = new System.Windows.Forms.CheckBox();
			this.modelTextBox = new System.Windows.Forms.TextBox();
			this.physicalSizeUnitsTextBox = new System.Windows.Forms.TextBox();
			this.serialNoTextBox = new System.Windows.Forms.TextBox();
			this.physicalSizeTextBox = new System.Windows.Forms.TextBox();
			this.bSFCUnitsTextBox = new System.Windows.Forms.TextBox();
			this.ratedHeatInputTextBox = new System.Windows.Forms.TextBox();
			this.bSFCTextBox = new System.Windows.Forms.TextBox();
			this.ratedHeatInputUnitsTextBox = new System.Windows.Forms.TextBox();
			this.lblPermitsWithSelectedDevice = new System.Windows.Forms.Label();
			this.lbxPermitsWithDevice = new System.Windows.Forms.ListBox();
			this.bsPermitsWithDevice = new System.Windows.Forms.BindingSource(this.components);
			this.bsSourceFaciltiyPermit = new System.Windows.Forms.BindingSource(this.components);
			this.bwDevice = new System.ComponentModel.BackgroundWorker();
			this.bwLoadDevice = new System.ComponentModel.BackgroundWorker();
			this.bwFillNavigation = new System.ComponentModel.BackgroundWorker();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tipDevice = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.bnDeviceList)).BeginInit();
			this.bnDeviceList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsNavigate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsDeviceList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsDevice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scDevice)).BeginInit();
			this.scDevice.Panel1.SuspendLayout();
			this.scDevice.Panel2.SuspendLayout();
			this.scDevice.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scDevice2)).BeginInit();
			this.scDevice2.Panel1.SuspendLayout();
			this.scDevice2.Panel2.SuspendLayout();
			this.scDevice2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsPermitsWithDevice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsSourceFaciltiyPermit)).BeginInit();
			this.SuspendLayout();
			// 
			// deviceNameLabel
			// 
			this.deviceNameLabel.AutoSize = true;
			this.deviceNameLabel.Location = new System.Drawing.Point(8, 60);
			this.deviceNameLabel.Name = "deviceNameLabel";
			this.deviceNameLabel.Size = new System.Drawing.Size(84, 16);
			this.deviceNameLabel.TabIndex = 1;
			this.deviceNameLabel.Text = "Device Name";
			// 
			// operatorIDLabel
			// 
			this.operatorIDLabel.AutoSize = true;
			this.operatorIDLabel.Location = new System.Drawing.Point(18, 114);
			this.operatorIDLabel.Name = "operatorIDLabel";
			this.operatorIDLabel.Size = new System.Drawing.Size(74, 16);
			this.operatorIDLabel.TabIndex = 5;
			this.operatorIDLabel.Text = "Operator ID";
			// 
			// makeLabel
			// 
			this.makeLabel.AutoSize = true;
			this.makeLabel.Location = new System.Drawing.Point(52, 142);
			this.makeLabel.Name = "makeLabel";
			this.makeLabel.Size = new System.Drawing.Size(40, 16);
			this.makeLabel.TabIndex = 6;
			this.makeLabel.Text = "Make";
			// 
			// manufacturerLabel
			// 
			this.manufacturerLabel.AutoSize = true;
			this.manufacturerLabel.Location = new System.Drawing.Point(5, 170);
			this.manufacturerLabel.Name = "manufacturerLabel";
			this.manufacturerLabel.Size = new System.Drawing.Size(87, 16);
			this.manufacturerLabel.TabIndex = 7;
			this.manufacturerLabel.Text = "Manufacturer:";
			// 
			// modelLabel
			// 
			this.modelLabel.AutoSize = true;
			this.modelLabel.Location = new System.Drawing.Point(49, 198);
			this.modelLabel.Name = "modelLabel";
			this.modelLabel.Size = new System.Drawing.Size(43, 16);
			this.modelLabel.TabIndex = 9;
			this.modelLabel.Text = "Model";
			// 
			// serialNoLabel
			// 
			this.serialNoLabel.AutoSize = true;
			this.serialNoLabel.Location = new System.Drawing.Point(31, 226);
			this.serialNoLabel.Name = "serialNoLabel";
			this.serialNoLabel.Size = new System.Drawing.Size(61, 16);
			this.serialNoLabel.TabIndex = 11;
			this.serialNoLabel.Text = "Serial No";
			// 
			// ratedHeatInputLabel
			// 
			this.ratedHeatInputLabel.AutoSize = true;
			this.ratedHeatInputLabel.Location = new System.Drawing.Point(226, 114);
			this.ratedHeatInputLabel.Name = "ratedHeatInputLabel";
			this.ratedHeatInputLabel.Size = new System.Drawing.Size(105, 16);
			this.ratedHeatInputLabel.TabIndex = 13;
			this.ratedHeatInputLabel.Text = "Rated Heat Input";
			// 
			// bSFCLabel
			// 
			this.bSFCLabel.AutoSize = true;
			this.bSFCLabel.Location = new System.Drawing.Point(288, 142);
			this.bSFCLabel.Name = "bSFCLabel";
			this.bSFCLabel.Size = new System.Drawing.Size(43, 16);
			this.bSFCLabel.TabIndex = 16;
			this.bSFCLabel.Text = "BSFC";
			// 
			// physicalSizeLabel
			// 
			this.physicalSizeLabel.AutoSize = true;
			this.physicalSizeLabel.Location = new System.Drawing.Point(243, 170);
			this.physicalSizeLabel.Name = "physicalSizeLabel";
			this.physicalSizeLabel.Size = new System.Drawing.Size(88, 16);
			this.physicalSizeLabel.TabIndex = 19;
			this.physicalSizeLabel.Text = "Physical Size";
			// 
			// deviceSpecificTypeLabel
			// 
			this.deviceSpecificTypeLabel.AutoSize = true;
			this.deviceSpecificTypeLabel.Location = new System.Drawing.Point(338, 254);
			this.deviceSpecificTypeLabel.Name = "deviceSpecificTypeLabel";
			this.deviceSpecificTypeLabel.Size = new System.Drawing.Size(127, 16);
			this.deviceSpecificTypeLabel.TabIndex = 32;
			this.deviceSpecificTypeLabel.Text = "Device Specific Type";
			// 
			// deviceTypeLabel
			// 
			this.deviceTypeLabel.AutoSize = true;
			this.deviceTypeLabel.Location = new System.Drawing.Point(14, 254);
			this.deviceTypeLabel.Name = "deviceTypeLabel";
			this.deviceTypeLabel.Size = new System.Drawing.Size(77, 16);
			this.deviceTypeLabel.TabIndex = 34;
			this.deviceTypeLabel.Text = "Device Type";
			// 
			// deviceDescriptionLabel
			// 
			this.deviceDescriptionLabel.AutoSize = true;
			this.deviceDescriptionLabel.Location = new System.Drawing.Point(7, 307);
			this.deviceDescriptionLabel.Name = "deviceDescriptionLabel";
			this.deviceDescriptionLabel.Size = new System.Drawing.Size(115, 16);
			this.deviceDescriptionLabel.TabIndex = 35;
			this.deviceDescriptionLabel.Text = "Device Description";
			// 
			// commentsLabel
			// 
			this.commentsLabel.AutoSize = true;
			this.commentsLabel.Location = new System.Drawing.Point(302, 307);
			this.commentsLabel.Name = "commentsLabel";
			this.commentsLabel.Size = new System.Drawing.Size(71, 16);
			this.commentsLabel.TabIndex = 36;
			this.commentsLabel.Text = "Comments";
			// 
			// locationNoteLabel
			// 
			this.locationNoteLabel.AutoSize = true;
			this.locationNoteLabel.Location = new System.Drawing.Point(4, 284);
			this.locationNoteLabel.Name = "locationNoteLabel";
			this.locationNoteLabel.Size = new System.Drawing.Size(88, 16);
			this.locationNoteLabel.TabIndex = 37;
			this.locationNoteLabel.Text = "Location Note";
			// 
			// amendsPermitLabel
			// 
			this.amendsPermitLabel.AutoSize = true;
			this.amendsPermitLabel.Location = new System.Drawing.Point(368, 226);
			this.amendsPermitLabel.Name = "amendsPermitLabel";
			this.amendsPermitLabel.Size = new System.Drawing.Size(98, 16);
			this.amendsPermitLabel.TabIndex = 38;
			this.amendsPermitLabel.Text = "Amends Permit";
			// 
			// deviceNoLabel
			// 
			this.deviceNoLabel.AutoSize = true;
			this.deviceNoLabel.Location = new System.Drawing.Point(448, 60);
			this.deviceNoLabel.Name = "deviceNoLabel";
			this.deviceNoLabel.Size = new System.Drawing.Size(66, 16);
			this.deviceNoLabel.TabIndex = 39;
			this.deviceNoLabel.Text = "Device No";
			// 
			// bnDeviceList
			// 
			this.bnDeviceList.AddNewItem = null;
			this.bnDeviceList.BindingSource = this.bsNavigate;
			this.bnDeviceList.CountItem = this.bindingNavigatorCountItem;
			this.bnDeviceList.DeleteItem = null;
			this.bnDeviceList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bnDeviceList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.bnDeviceList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.tsbtnExpandTree,
            this.tsbtnColapseTree,
            this.toolStripSeparator1,
            this.tstxtDeviceNo,
            this.toolStripSeparator2,
            this.tsbtnGoToDevice,
            this.toolStripSeparator3,
            this.tstxtPermitNumber,
            this.tsbtnGetPermits,
            this.tscmbPermitList,
            this.tsbtnStopTimer,
            this.tslblSourceFaciltiyPermit});
			this.bnDeviceList.Location = new System.Drawing.Point(0, 0);
			this.bnDeviceList.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bnDeviceList.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bnDeviceList.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bnDeviceList.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bnDeviceList.Name = "bnDeviceList";
			this.bnDeviceList.PositionItem = this.bindingNavigatorPositionItem;
			this.bnDeviceList.Size = new System.Drawing.Size(923, 25);
			this.bnDeviceList.TabIndex = 0;
			// 
			// bsNavigate
			// 
			this.bsNavigate.DataSourceChanged += new System.EventHandler(this.bsNavigate_DataSourceChanged);
			this.bsNavigate.CurrentChanged += new System.EventHandler(this.bsNavigate_CurrentChanged);
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
			// tsbtnExpandTree
			// 
			this.tsbtnExpandTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnExpandTree.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExpandTree.Image")));
			this.tsbtnExpandTree.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnExpandTree.Name = "tsbtnExpandTree";
			this.tsbtnExpandTree.Size = new System.Drawing.Size(23, 22);
			this.tsbtnExpandTree.ToolTipText = "Expand Device Tree";
			this.tsbtnExpandTree.Click += new System.EventHandler(this.tsbtnExpandTree_Click);
			// 
			// tsbtnColapseTree
			// 
			this.tsbtnColapseTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnColapseTree.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnColapseTree.Image")));
			this.tsbtnColapseTree.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnColapseTree.Name = "tsbtnColapseTree";
			this.tsbtnColapseTree.Size = new System.Drawing.Size(23, 22);
			this.tsbtnColapseTree.ToolTipText = "Colapse Device Tree";
			this.tsbtnColapseTree.Click += new System.EventHandler(this.tsbtnColapseTree_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tstxtDeviceNo
			// 
			this.tstxtDeviceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tstxtDeviceNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tstxtDeviceNo.Name = "tstxtDeviceNo";
			this.tstxtDeviceNo.Size = new System.Drawing.Size(75, 25);
			this.tstxtDeviceNo.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tstxtDeviceNo.ToolTipText = "Enter Device No.";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnGoToDevice
			// 
			this.tsbtnGoToDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnGoToDevice.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGoToDevice.Image")));
			this.tsbtnGoToDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnGoToDevice.Name = "tsbtnGoToDevice";
			this.tsbtnGoToDevice.Size = new System.Drawing.Size(23, 22);
			this.tsbtnGoToDevice.ToolTipText = "Go To Device";
			this.tsbtnGoToDevice.Click += new System.EventHandler(this.tsBtnGoToDevice_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// tstxtPermitNumber
			// 
			this.tstxtPermitNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tstxtPermitNumber.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tstxtPermitNumber.Name = "tstxtPermitNumber";
			this.tstxtPermitNumber.Size = new System.Drawing.Size(50, 25);
			this.tstxtPermitNumber.ToolTipText = "Enter Permit Number";
			// 
			// tsbtnGetPermits
			// 
			this.tsbtnGetPermits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnGetPermits.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGetPermits.Image")));
			this.tsbtnGetPermits.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnGetPermits.Name = "tsbtnGetPermits";
			this.tsbtnGetPermits.Size = new System.Drawing.Size(23, 22);
			this.tsbtnGetPermits.ToolTipText = "Get Permits";
			this.tsbtnGetPermits.Click += new System.EventHandler(this.tsbtnGetPermits_Click);
			// 
			// tscmbPermitList
			// 
			this.tscmbPermitList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscmbPermitList.DropDownWidth = 250;
			this.tscmbPermitList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tscmbPermitList.MaxDropDownItems = 16;
			this.tscmbPermitList.Name = "tscmbPermitList";
			this.tscmbPermitList.Size = new System.Drawing.Size(150, 25);
			this.tscmbPermitList.ToolTipText = "Get Devices for selected Permit";
			this.tscmbPermitList.SelectedIndexChanged += new System.EventHandler(this.tscmbPermitList_SelectedIndexChanged);
			// 
			// tsbtnStopTimer
			// 
			this.tsbtnStopTimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnStopTimer.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStopTimer.Image")));
			this.tsbtnStopTimer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnStopTimer.Name = "tsbtnStopTimer";
			this.tsbtnStopTimer.Size = new System.Drawing.Size(23, 22);
			this.tsbtnStopTimer.ToolTipText = "Stop blinking!";
			this.tsbtnStopTimer.Click += new System.EventHandler(this.tsbtnStopTimer_Click);
			// 
			// tslblSourceFaciltiyPermit
			// 
			this.tslblSourceFaciltiyPermit.BackColor = System.Drawing.SystemColors.Info;
			this.tslblSourceFaciltiyPermit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tslblSourceFaciltiyPermit.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tslblSourceFaciltiyPermit.Name = "tslblSourceFaciltiyPermit";
			this.tslblSourceFaciltiyPermit.Size = new System.Drawing.Size(0, 22);
			// 
			// deviceNameTextBox
			// 
			this.deviceNameTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.deviceNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.deviceNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "DeviceName", true));
			this.deviceNameTextBox.Location = new System.Drawing.Point(95, 57);
			this.deviceNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.deviceNameTextBox.Name = "deviceNameTextBox";
			this.deviceNameTextBox.ReadOnly = true;
			this.deviceNameTextBox.Size = new System.Drawing.Size(347, 22);
			this.deviceNameTextBox.TabIndex = 2;
			// 
			// bsDeviceList
			// 
			this.bsDeviceList.DataMember = "DeviceList";
			this.bsDeviceList.DataSource = this.dsDevice;
			// 
			// dsDevice
			// 
			this.dsDevice.DataSetName = "DeviceDataSet";
			this.dsDevice.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// scDevice
			// 
			this.scDevice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.scDevice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scDevice.Location = new System.Drawing.Point(0, 25);
			this.scDevice.Name = "scDevice";
			// 
			// scDevice.Panel1
			// 
			this.scDevice.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.scDevice.Panel1.Controls.Add(this.trvDevices);
			this.scDevice.Panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			// 
			// scDevice.Panel2
			// 
			this.scDevice.Panel2.AutoScroll = true;
			this.scDevice.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.scDevice.Panel2.Controls.Add(this.scDevice2);
			this.scDevice.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.scDevice.Size = new System.Drawing.Size(923, 475);
			this.scDevice.SplitterDistance = 307;
			this.scDevice.SplitterWidth = 2;
			this.scDevice.TabIndex = 5;
			// 
			// trvDevices
			// 
			this.trvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trvDevices.HotTracking = true;
			this.trvDevices.ImageIndex = 18;
			this.trvDevices.ImageList = this.imlDeviceTree;
			this.trvDevices.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(36)))), ((int)(((byte)(106)))));
			this.trvDevices.Location = new System.Drawing.Point(0, 5);
			this.trvDevices.Name = "trvDevices";
			this.trvDevices.SelectedImageIndex = 17;
			this.trvDevices.Size = new System.Drawing.Size(307, 470);
			this.trvDevices.StateImageList = this.imlDeviceTree;
			this.trvDevices.TabIndex = 281;
			this.trvDevices.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvDevices_NodeMouseClick);
			// 
			// imlDeviceTree
			// 
			this.imlDeviceTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlDeviceTree.ImageStream")));
			this.imlDeviceTree.TransparentColor = System.Drawing.Color.Magenta;
			this.imlDeviceTree.Images.SetKeyName(0, "");
			this.imlDeviceTree.Images.SetKeyName(1, "");
			this.imlDeviceTree.Images.SetKeyName(2, "");
			this.imlDeviceTree.Images.SetKeyName(3, "");
			this.imlDeviceTree.Images.SetKeyName(4, "");
			this.imlDeviceTree.Images.SetKeyName(5, "");
			this.imlDeviceTree.Images.SetKeyName(6, "");
			this.imlDeviceTree.Images.SetKeyName(7, "");
			this.imlDeviceTree.Images.SetKeyName(8, "");
			this.imlDeviceTree.Images.SetKeyName(9, "");
			this.imlDeviceTree.Images.SetKeyName(10, "");
			this.imlDeviceTree.Images.SetKeyName(11, "");
			this.imlDeviceTree.Images.SetKeyName(12, "");
			this.imlDeviceTree.Images.SetKeyName(13, "");
			this.imlDeviceTree.Images.SetKeyName(14, "");
			this.imlDeviceTree.Images.SetKeyName(15, "");
			this.imlDeviceTree.Images.SetKeyName(16, "");
			this.imlDeviceTree.Images.SetKeyName(17, "VSFolder_open.bmp");
			this.imlDeviceTree.Images.SetKeyName(18, "VSFolder_closed_virtual.bmp");
			// 
			// scDevice2
			// 
			this.scDevice2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.scDevice2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scDevice2.Location = new System.Drawing.Point(0, 5);
			this.scDevice2.Name = "scDevice2";
			this.scDevice2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scDevice2.Panel1
			// 
			this.scDevice2.Panel1.AutoScroll = true;
			this.scDevice2.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.scDevice2.Panel1.Controls.Add(this.label2);
			this.scDevice2.Panel1.Controls.Add(this.label1);
			this.scDevice2.Panel1.Controls.Add(this.isNamingDeviceCheckBox);
			this.scDevice2.Panel1.Controls.Add(this.chkIsGroup);
			this.scDevice2.Panel1.Controls.Add(this.permitNoDeviceNoTextBox);
			this.scDevice2.Panel1.Controls.Add(this.txtDeviceNo);
			this.scDevice2.Panel1.Controls.Add(this.deviceDescriptionTextBox);
			this.scDevice2.Panel1.Controls.Add(this.txtNodePath);
			this.scDevice2.Panel1.Controls.Add(this.amendsPermitLabel);
			this.scDevice2.Panel1.Controls.Add(this.deviceDescriptionLabel);
			this.scDevice2.Panel1.Controls.Add(this.amendsPermitTextBox);
			this.scDevice2.Panel1.Controls.Add(this.commentsTextBox);
			this.scDevice2.Panel1.Controls.Add(this.locationNoteLabel);
			this.scDevice2.Panel1.Controls.Add(this.commentsLabel);
			this.scDevice2.Panel1.Controls.Add(this.locationNoteTextBox);
			this.scDevice2.Panel1.Controls.Add(this.deviceNameTextBox);
			this.scDevice2.Panel1.Controls.Add(this.deviceTypeLabel);
			this.scDevice2.Panel1.Controls.Add(this.deviceNameLabel);
			this.scDevice2.Panel1.Controls.Add(this.deviceTypeTextBox);
			this.scDevice2.Panel1.Controls.Add(this.operatorIDTextBox);
			this.scDevice2.Panel1.Controls.Add(this.deviceSpecificTypeLabel);
			this.scDevice2.Panel1.Controls.Add(this.operatorIDLabel);
			this.scDevice2.Panel1.Controls.Add(this.deviceSpecificTypeTextBox);
			this.scDevice2.Panel1.Controls.Add(this.makeTextBox);
			this.scDevice2.Panel1.Controls.Add(this.chkPart70Insignificant);
			this.scDevice2.Panel1.Controls.Add(this.makeLabel);
			this.scDevice2.Panel1.Controls.Add(this.chkNotInService);
			this.scDevice2.Panel1.Controls.Add(this.manufacturerTextBox);
			this.scDevice2.Panel1.Controls.Add(this.isOffpermitCheckBox);
			this.scDevice2.Panel1.Controls.Add(this.manufacturerLabel);
			this.scDevice2.Panel1.Controls.Add(this.chkExempt);
			this.scDevice2.Panel1.Controls.Add(this.modelTextBox);
			this.scDevice2.Panel1.Controls.Add(this.physicalSizeUnitsTextBox);
			this.scDevice2.Panel1.Controls.Add(this.modelLabel);
			this.scDevice2.Panel1.Controls.Add(this.physicalSizeLabel);
			this.scDevice2.Panel1.Controls.Add(this.serialNoTextBox);
			this.scDevice2.Panel1.Controls.Add(this.physicalSizeTextBox);
			this.scDevice2.Panel1.Controls.Add(this.serialNoLabel);
			this.scDevice2.Panel1.Controls.Add(this.bSFCUnitsTextBox);
			this.scDevice2.Panel1.Controls.Add(this.ratedHeatInputTextBox);
			this.scDevice2.Panel1.Controls.Add(this.bSFCLabel);
			this.scDevice2.Panel1.Controls.Add(this.ratedHeatInputLabel);
			this.scDevice2.Panel1.Controls.Add(this.bSFCTextBox);
			this.scDevice2.Panel1.Controls.Add(this.ratedHeatInputUnitsTextBox);
			this.scDevice2.Panel1.Controls.Add(this.deviceNoLabel);
			// 
			// scDevice2.Panel2
			// 
			this.scDevice2.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.scDevice2.Panel2.Controls.Add(this.lblPermitsWithSelectedDevice);
			this.scDevice2.Panel2.Controls.Add(this.lbxPermitsWithDevice);
			this.scDevice2.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.scDevice2.Size = new System.Drawing.Size(614, 470);
			this.scDevice2.SplitterDistance = 389;
			this.scDevice2.SplitterWidth = 2;
			this.scDevice2.TabIndex = 40;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label2.Location = new System.Drawing.Point(371, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 16);
			this.label2.TabIndex = 45;
			this.label2.Text = "FID";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "FacilityNo", true));
			this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label1.Location = new System.Drawing.Point(405, 87);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 16);
			this.label1.TabIndex = 44;
			this.label1.Text = "label1";
			// 
			// isNamingDeviceCheckBox
			// 
			this.isNamingDeviceCheckBox.AutoSize = true;
			this.isNamingDeviceCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsDeviceList, "IsNamingDevice", true));
			this.isNamingDeviceCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.isNamingDeviceCheckBox.Location = new System.Drawing.Point(185, 85);
			this.isNamingDeviceCheckBox.Name = "isNamingDeviceCheckBox";
			this.isNamingDeviceCheckBox.Size = new System.Drawing.Size(110, 20);
			this.isNamingDeviceCheckBox.TabIndex = 43;
			this.isNamingDeviceCheckBox.Text = "Naming Device";
			this.isNamingDeviceCheckBox.UseVisualStyleBackColor = true;
			// 
			// chkIsGroup
			// 
			this.chkIsGroup.AutoSize = true;
			this.chkIsGroup.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsDeviceList, "IsGroup", true));
			this.chkIsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkIsGroup.Location = new System.Drawing.Point(96, 85);
			this.chkIsGroup.Name = "chkIsGroup";
			this.chkIsGroup.Size = new System.Drawing.Size(59, 20);
			this.chkIsGroup.TabIndex = 42;
			this.chkIsGroup.Text = "Group";
			this.chkIsGroup.UseVisualStyleBackColor = true;
			// 
			// permitNoDeviceNoTextBox
			// 
			this.permitNoDeviceNoTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.permitNoDeviceNoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.permitNoDeviceNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "PermitNoDeviceNo", true));
			this.permitNoDeviceNoTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.permitNoDeviceNoTextBox.Location = new System.Drawing.Point(471, 88);
			this.permitNoDeviceNoTextBox.Name = "permitNoDeviceNoTextBox";
			this.permitNoDeviceNoTextBox.Size = new System.Drawing.Size(100, 15);
			this.permitNoDeviceNoTextBox.TabIndex = 41;
			// 
			// txtDeviceNo
			// 
			this.txtDeviceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDeviceNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "DeviceNo", true));
			this.txtDeviceNo.Location = new System.Drawing.Point(512, 57);
			this.txtDeviceNo.Name = "txtDeviceNo";
			this.txtDeviceNo.Size = new System.Drawing.Size(62, 22);
			this.txtDeviceNo.TabIndex = 40;
			this.txtDeviceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// deviceDescriptionTextBox
			// 
			this.deviceDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.deviceDescriptionTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.deviceDescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.deviceDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "DeviceDescription", true));
			this.deviceDescriptionTextBox.Location = new System.Drawing.Point(7, 327);
			this.deviceDescriptionTextBox.Multiline = true;
			this.deviceDescriptionTextBox.Name = "deviceDescriptionTextBox";
			this.deviceDescriptionTextBox.ReadOnly = true;
			this.deviceDescriptionTextBox.Size = new System.Drawing.Size(273, 106);
			this.deviceDescriptionTextBox.TabIndex = 36;
			// 
			// txtNodePath
			// 
			this.txtNodePath.BackColor = System.Drawing.SystemColors.Control;
			this.txtNodePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtNodePath.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtNodePath.Location = new System.Drawing.Point(0, 0);
			this.txtNodePath.Multiline = true;
			this.txtNodePath.Name = "txtNodePath";
			this.txtNodePath.ReadOnly = true;
			this.txtNodePath.Size = new System.Drawing.Size(614, 40);
			this.txtNodePath.TabIndex = 5;
			// 
			// amendsPermitTextBox
			// 
			this.amendsPermitTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.amendsPermitTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.amendsPermitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "AmendsPermit", true));
			this.amendsPermitTextBox.Location = new System.Drawing.Point(474, 223);
			this.amendsPermitTextBox.Name = "amendsPermitTextBox";
			this.amendsPermitTextBox.ReadOnly = true;
			this.amendsPermitTextBox.Size = new System.Drawing.Size(100, 22);
			this.amendsPermitTextBox.TabIndex = 39;
			// 
			// commentsTextBox
			// 
			this.commentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.commentsTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.commentsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.commentsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "Comments", true));
			this.commentsTextBox.Location = new System.Drawing.Point(302, 327);
			this.commentsTextBox.Multiline = true;
			this.commentsTextBox.Name = "commentsTextBox";
			this.commentsTextBox.ReadOnly = true;
			this.commentsTextBox.Size = new System.Drawing.Size(273, 106);
			this.commentsTextBox.TabIndex = 37;
			// 
			// locationNoteTextBox
			// 
			this.locationNoteTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.locationNoteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.locationNoteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "LocationNote", true));
			this.locationNoteTextBox.Location = new System.Drawing.Point(95, 281);
			this.locationNoteTextBox.Name = "locationNoteTextBox";
			this.locationNoteTextBox.ReadOnly = true;
			this.locationNoteTextBox.Size = new System.Drawing.Size(476, 22);
			this.locationNoteTextBox.TabIndex = 38;
			// 
			// deviceTypeTextBox
			// 
			this.deviceTypeTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.deviceTypeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.deviceTypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "DeviceType", true));
			this.deviceTypeTextBox.Location = new System.Drawing.Point(95, 251);
			this.deviceTypeTextBox.Name = "deviceTypeTextBox";
			this.deviceTypeTextBox.ReadOnly = true;
			this.deviceTypeTextBox.Size = new System.Drawing.Size(237, 22);
			this.deviceTypeTextBox.TabIndex = 35;
			// 
			// operatorIDTextBox
			// 
			this.operatorIDTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.operatorIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.operatorIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "OperatorID", true));
			this.operatorIDTextBox.Location = new System.Drawing.Point(95, 111);
			this.operatorIDTextBox.Name = "operatorIDTextBox";
			this.operatorIDTextBox.ReadOnly = true;
			this.operatorIDTextBox.Size = new System.Drawing.Size(100, 22);
			this.operatorIDTextBox.TabIndex = 6;
			// 
			// deviceSpecificTypeTextBox
			// 
			this.deviceSpecificTypeTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.deviceSpecificTypeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.deviceSpecificTypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "DeviceSpecificType", true));
			this.deviceSpecificTypeTextBox.Location = new System.Drawing.Point(474, 251);
			this.deviceSpecificTypeTextBox.Name = "deviceSpecificTypeTextBox";
			this.deviceSpecificTypeTextBox.ReadOnly = true;
			this.deviceSpecificTypeTextBox.Size = new System.Drawing.Size(100, 22);
			this.deviceSpecificTypeTextBox.TabIndex = 33;
			// 
			// makeTextBox
			// 
			this.makeTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.makeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.makeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "Make", true));
			this.makeTextBox.Location = new System.Drawing.Point(95, 139);
			this.makeTextBox.Name = "makeTextBox";
			this.makeTextBox.ReadOnly = true;
			this.makeTextBox.Size = new System.Drawing.Size(100, 22);
			this.makeTextBox.TabIndex = 7;
			// 
			// chkPart70Insignificant
			// 
			this.chkPart70Insignificant.AutoSize = true;
			this.chkPart70Insignificant.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsDeviceList, "IsPart70Insignificant", true));
			this.chkPart70Insignificant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkPart70Insignificant.Location = new System.Drawing.Point(487, 196);
			this.chkPart70Insignificant.Name = "chkPart70Insignificant";
			this.chkPart70Insignificant.Size = new System.Drawing.Size(97, 20);
			this.chkPart70Insignificant.TabIndex = 31;
			this.chkPart70Insignificant.Text = "Part70 Insig.";
			this.chkPart70Insignificant.UseVisualStyleBackColor = true;
			// 
			// chkNotInService
			// 
			this.chkNotInService.AutoSize = true;
			this.chkNotInService.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsDeviceList, "IsNotInService", true));
			this.chkNotInService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkNotInService.Location = new System.Drawing.Point(377, 196);
			this.chkNotInService.Name = "chkNotInService";
			this.chkNotInService.Size = new System.Drawing.Size(104, 20);
			this.chkNotInService.TabIndex = 29;
			this.chkNotInService.Text = "Not In Service";
			this.chkNotInService.UseVisualStyleBackColor = true;
			// 
			// manufacturerTextBox
			// 
			this.manufacturerTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.manufacturerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.manufacturerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "Manufacturer", true));
			this.manufacturerTextBox.Location = new System.Drawing.Point(95, 167);
			this.manufacturerTextBox.Name = "manufacturerTextBox";
			this.manufacturerTextBox.ReadOnly = true;
			this.manufacturerTextBox.Size = new System.Drawing.Size(100, 22);
			this.manufacturerTextBox.TabIndex = 8;
			// 
			// isOffpermitCheckBox
			// 
			this.isOffpermitCheckBox.AutoSize = true;
			this.isOffpermitCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsDeviceList, "IsOffpermit", true));
			this.isOffpermitCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.isOffpermitCheckBox.Location = new System.Drawing.Point(298, 196);
			this.isOffpermitCheckBox.Name = "isOffpermitCheckBox";
			this.isOffpermitCheckBox.Size = new System.Drawing.Size(76, 20);
			this.isOffpermitCheckBox.TabIndex = 27;
			this.isOffpermitCheckBox.Text = "Offpermit";
			this.isOffpermitCheckBox.UseVisualStyleBackColor = true;
			// 
			// chkExempt
			// 
			this.chkExempt.AutoSize = true;
			this.chkExempt.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsDeviceList, "IsExempt", true));
			this.chkExempt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkExempt.Location = new System.Drawing.Point(226, 196);
			this.chkExempt.Name = "chkExempt";
			this.chkExempt.Size = new System.Drawing.Size(69, 20);
			this.chkExempt.TabIndex = 25;
			this.chkExempt.Text = "Exempt";
			this.chkExempt.UseVisualStyleBackColor = true;
			// 
			// modelTextBox
			// 
			this.modelTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.modelTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.modelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "Model", true));
			this.modelTextBox.Location = new System.Drawing.Point(95, 195);
			this.modelTextBox.Name = "modelTextBox";
			this.modelTextBox.ReadOnly = true;
			this.modelTextBox.Size = new System.Drawing.Size(100, 22);
			this.modelTextBox.TabIndex = 10;
			// 
			// physicalSizeUnitsTextBox
			// 
			this.physicalSizeUnitsTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.physicalSizeUnitsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.physicalSizeUnitsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "PhysicalSizeUnits", true));
			this.physicalSizeUnitsTextBox.Location = new System.Drawing.Point(405, 167);
			this.physicalSizeUnitsTextBox.Name = "physicalSizeUnitsTextBox";
			this.physicalSizeUnitsTextBox.ReadOnly = true;
			this.physicalSizeUnitsTextBox.Size = new System.Drawing.Size(169, 22);
			this.physicalSizeUnitsTextBox.TabIndex = 22;
			// 
			// serialNoTextBox
			// 
			this.serialNoTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.serialNoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.serialNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "SerialNo", true));
			this.serialNoTextBox.Location = new System.Drawing.Point(95, 223);
			this.serialNoTextBox.Name = "serialNoTextBox";
			this.serialNoTextBox.ReadOnly = true;
			this.serialNoTextBox.Size = new System.Drawing.Size(100, 22);
			this.serialNoTextBox.TabIndex = 12;
			// 
			// physicalSizeTextBox
			// 
			this.physicalSizeTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.physicalSizeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.physicalSizeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "PhysicalSize", true));
			this.physicalSizeTextBox.Location = new System.Drawing.Point(332, 167);
			this.physicalSizeTextBox.Name = "physicalSizeTextBox";
			this.physicalSizeTextBox.ReadOnly = true;
			this.physicalSizeTextBox.Size = new System.Drawing.Size(63, 22);
			this.physicalSizeTextBox.TabIndex = 20;
			this.physicalSizeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// bSFCUnitsTextBox
			// 
			this.bSFCUnitsTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.bSFCUnitsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.bSFCUnitsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "BSFCUnits", true));
			this.bSFCUnitsTextBox.Location = new System.Drawing.Point(405, 139);
			this.bSFCUnitsTextBox.Name = "bSFCUnitsTextBox";
			this.bSFCUnitsTextBox.ReadOnly = true;
			this.bSFCUnitsTextBox.Size = new System.Drawing.Size(169, 22);
			this.bSFCUnitsTextBox.TabIndex = 19;
			// 
			// ratedHeatInputTextBox
			// 
			this.ratedHeatInputTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.ratedHeatInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ratedHeatInputTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "RatedHeatInput", true));
			this.ratedHeatInputTextBox.Location = new System.Drawing.Point(332, 111);
			this.ratedHeatInputTextBox.Name = "ratedHeatInputTextBox";
			this.ratedHeatInputTextBox.ReadOnly = true;
			this.ratedHeatInputTextBox.Size = new System.Drawing.Size(63, 22);
			this.ratedHeatInputTextBox.TabIndex = 14;
			this.ratedHeatInputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// bSFCTextBox
			// 
			this.bSFCTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.bSFCTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.bSFCTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "BSFC", true));
			this.bSFCTextBox.Location = new System.Drawing.Point(332, 139);
			this.bSFCTextBox.Name = "bSFCTextBox";
			this.bSFCTextBox.ReadOnly = true;
			this.bSFCTextBox.Size = new System.Drawing.Size(63, 22);
			this.bSFCTextBox.TabIndex = 17;
			this.bSFCTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ratedHeatInputUnitsTextBox
			// 
			this.ratedHeatInputUnitsTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.ratedHeatInputUnitsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ratedHeatInputUnitsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDeviceList, "RatedHeatInputUnits", true));
			this.ratedHeatInputUnitsTextBox.Location = new System.Drawing.Point(405, 111);
			this.ratedHeatInputUnitsTextBox.Name = "ratedHeatInputUnitsTextBox";
			this.ratedHeatInputUnitsTextBox.ReadOnly = true;
			this.ratedHeatInputUnitsTextBox.Size = new System.Drawing.Size(169, 22);
			this.ratedHeatInputUnitsTextBox.TabIndex = 16;
			// 
			// lblPermitsWithSelectedDevice
			// 
			this.lblPermitsWithSelectedDevice.AutoSize = true;
			this.lblPermitsWithSelectedDevice.Location = new System.Drawing.Point(6, 4);
			this.lblPermitsWithSelectedDevice.Name = "lblPermitsWithSelectedDevice";
			this.lblPermitsWithSelectedDevice.Size = new System.Drawing.Size(173, 16);
			this.lblPermitsWithSelectedDevice.TabIndex = 1;
			this.lblPermitsWithSelectedDevice.Text = "Permits with selected device";
			// 
			// lbxPermitsWithDevice
			// 
			this.lbxPermitsWithDevice.BackColor = System.Drawing.SystemColors.Control;
			this.lbxPermitsWithDevice.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbxPermitsWithDevice.DataSource = this.bsPermitsWithDevice;
			this.lbxPermitsWithDevice.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbxPermitsWithDevice.ItemHeight = 16;
			this.lbxPermitsWithDevice.Location = new System.Drawing.Point(0, 31);
			this.lbxPermitsWithDevice.MultiColumn = true;
			this.lbxPermitsWithDevice.Name = "lbxPermitsWithDevice";
			this.lbxPermitsWithDevice.Size = new System.Drawing.Size(614, 48);
			this.lbxPermitsWithDevice.Sorted = true;
			this.lbxPermitsWithDevice.TabIndex = 0;
			this.lbxPermitsWithDevice.TabStop = false;
			this.tipDevice.SetToolTip(this.lbxPermitsWithDevice, "Double click to get Devices for selected Permit");
			this.lbxPermitsWithDevice.SelectedIndexChanged += new System.EventHandler(this.lbxPermitsWithDevice_SelectedIndexChanged);
			this.lbxPermitsWithDevice.DoubleClick += new System.EventHandler(this.lbxPermitsWithDevice_DoubleClick);
			// 
			// bsSourceFaciltiyPermit
			// 
			this.bsSourceFaciltiyPermit.DataMember = "SourceFaciltiyPermit";
			this.bsSourceFaciltiyPermit.DataSource = this.dsDevice;
			// 
			// bwDevice
			// 
			this.bwDevice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDevice_DoWork);
			this.bwDevice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDevice_RunWorkerCompleted);
			// 
			// bwLoadDevice
			// 
			this.bwLoadDevice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwLoadDevice_DoWork);
			this.bwLoadDevice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwLoadDevice_RunWorkerCompleted);
			// 
			// bwFillNavigation
			// 
			this.bwFillNavigation.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFillNavigation_DoWork);
			this.bwFillNavigation.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFillNavigation_RunWorkerCompleted);
			// 
			// timer1
			// 
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// tipDevice
			// 
			this.tipDevice.AutomaticDelay = 50;
			this.tipDevice.AutoPopDelay = 0;
			this.tipDevice.InitialDelay = 50;
			this.tipDevice.IsBalloon = true;
			this.tipDevice.ReshowDelay = 10;
			this.tipDevice.ShowAlways = true;
			// 
			// usrDevice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.scDevice);
			this.Controls.Add(this.bnDeviceList);
			this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "usrDevice";
			this.Size = new System.Drawing.Size(923, 500);
			((System.ComponentModel.ISupportInitialize)(this.bnDeviceList)).EndInit();
			this.bnDeviceList.ResumeLayout(false);
			this.bnDeviceList.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsNavigate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsDeviceList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsDevice)).EndInit();
			this.scDevice.Panel1.ResumeLayout(false);
			this.scDevice.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scDevice)).EndInit();
			this.scDevice.ResumeLayout(false);
			this.scDevice2.Panel1.ResumeLayout(false);
			this.scDevice2.Panel1.PerformLayout();
			this.scDevice2.Panel2.ResumeLayout(false);
			this.scDevice2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.scDevice2)).EndInit();
			this.scDevice2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bsPermitsWithDevice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsSourceFaciltiyPermit)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	protected System.Windows.Forms.TreeView trvDevices;
	protected System.Windows.Forms.ImageList imlDeviceTree;
	protected System.Windows.Forms.ListBox lbxPermitsWithDevice;
	protected System.Windows.Forms.Timer timer1;
	protected DeviceDataSet dsDevice;
	protected System.Windows.Forms.BindingNavigator bnDeviceList;
	protected System.Windows.Forms.BindingSource bsDeviceList;
	protected System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
	protected System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
	protected System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
	protected System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
	protected System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
	protected System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
	protected System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
	protected System.Windows.Forms.TextBox deviceNameTextBox;
	protected SbcapcdOrg.ControlLibrary.usrSplitContainer scDevice;
	protected System.ComponentModel.BackgroundWorker bwDevice;
	protected System.Windows.Forms.ToolStripButton tsbtnExpandTree;
	protected System.Windows.Forms.ToolStripButton tsbtnColapseTree;
	protected System.Windows.Forms.BindingSource bsNavigate;
	protected System.Windows.Forms.TextBox txtNodePath;
	protected System.Windows.Forms.TextBox serialNoTextBox;
	protected System.Windows.Forms.TextBox modelTextBox;
	protected System.Windows.Forms.TextBox manufacturerTextBox;
	protected System.Windows.Forms.TextBox makeTextBox;
	protected System.Windows.Forms.TextBox operatorIDTextBox;
	protected System.Windows.Forms.TextBox deviceTypeTextBox;
	protected System.Windows.Forms.TextBox deviceSpecificTypeTextBox;
	protected System.Windows.Forms.CheckBox chkPart70Insignificant;
	protected System.Windows.Forms.CheckBox chkNotInService;
	protected System.Windows.Forms.CheckBox isOffpermitCheckBox;
	protected System.Windows.Forms.CheckBox chkExempt;
	protected System.Windows.Forms.TextBox physicalSizeUnitsTextBox;
	protected System.Windows.Forms.TextBox physicalSizeTextBox;
	protected System.Windows.Forms.TextBox bSFCUnitsTextBox;
	protected System.Windows.Forms.TextBox bSFCTextBox;
	protected System.Windows.Forms.TextBox ratedHeatInputUnitsTextBox;
	protected System.Windows.Forms.TextBox ratedHeatInputTextBox;
	protected System.Windows.Forms.TextBox deviceDescriptionTextBox;
	protected System.Windows.Forms.TextBox locationNoteTextBox;
	protected System.Windows.Forms.TextBox commentsTextBox;
	protected System.Windows.Forms.TextBox amendsPermitTextBox;
	protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	protected System.Windows.Forms.ToolStripTextBox tstxtDeviceNo;
	protected System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	protected System.Windows.Forms.ToolStripButton tsbtnGoToDevice;
	protected SbcapcdOrg.ControlLibrary.usrSplitContainer scDevice2;
	protected System.Windows.Forms.BindingSource bsPermitsWithDevice;
	protected System.ComponentModel.BackgroundWorker bwLoadDevice;
	protected System.ComponentModel.BackgroundWorker bwFillNavigation;
	protected System.Windows.Forms.Label lblPermitsWithSelectedDevice;
	protected System.Windows.Forms.BindingSource bsSourceFaciltiyPermit;
	protected System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	protected System.Windows.Forms.ToolStripLabel tslblSourceFaciltiyPermit;
	protected System.Windows.Forms.TextBox txtDeviceNo;
	protected System.Windows.Forms.ToolStripTextBox tstxtPermitNumber;
	protected System.Windows.Forms.ToolStripComboBox tscmbPermitList;
	protected System.Windows.Forms.ToolStripButton tsbtnGetPermits;
	protected System.Windows.Forms.TextBox permitNoDeviceNoTextBox;
	protected System.Windows.Forms.ToolTip tipDevice;
	protected System.Windows.Forms.ToolStripButton tsbtnStopTimer;
	protected System.Windows.Forms.CheckBox isNamingDeviceCheckBox;
	protected System.Windows.Forms.CheckBox chkIsGroup;
	protected System.Windows.Forms.Label deviceDescriptionLabel;
	protected System.Windows.Forms.Label deviceNameLabel;
	protected System.Windows.Forms.Label operatorIDLabel;
	protected System.Windows.Forms.Label makeLabel;
	protected System.Windows.Forms.Label manufacturerLabel;
	protected System.Windows.Forms.Label modelLabel;
	protected System.Windows.Forms.Label serialNoLabel;
	protected System.Windows.Forms.Label ratedHeatInputLabel;
	protected System.Windows.Forms.Label bSFCLabel;
	protected System.Windows.Forms.Label physicalSizeLabel;
	protected System.Windows.Forms.Label deviceSpecificTypeLabel;
	protected System.Windows.Forms.Label deviceTypeLabel;
	protected System.Windows.Forms.Label commentsLabel;
	protected System.Windows.Forms.Label locationNoteLabel;
	protected System.Windows.Forms.Label amendsPermitLabel;
	protected System.Windows.Forms.Label deviceNoLabel;
	protected System.Windows.Forms.Label label1;
	protected System.Windows.Forms.Label label2;

  }
}
