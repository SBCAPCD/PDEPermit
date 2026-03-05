namespace SbcapcdOrg.PDEPermit.TransOo
{
    partial class usrTransOo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrTransOo));
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.tbcTransOoDocuments = new System.Windows.Forms.TabControl();
			this.tabDocuments = new System.Windows.Forms.TabPage();
			this.pnlTransferSuffix = new System.Windows.Forms.Panel();
			this.cmbTransferSuffix = new System.Windows.Forms.ComboBox();
			this.bsLetter = new System.Windows.Forms.BindingSource(this.components);
			this.dsTransOoLetter = new SbcapcdOrg.PDEPermit.TransOo.DataSets.TransOoLetterDataSet();
			this.label1 = new System.Windows.Forms.Label();
			this.letterNoTextBox = new System.Windows.Forms.TextBox();
			this.usrPermitContactsV1 = new SbcapcdOrg.PdePermit.ContactComponents.usrPermitContactsV();
			this.btnFolder = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbSignEmployeeNo = new System.Windows.Forms.ComboBox();
			this.bsSignEmployee = new System.Windows.Forms.BindingSource(this.components);
			this.dsTransOoAux = new SbcapcdOrg.PDEPermit.TransOo.DataSets.TransOoAuxDataSet();
			this.lblLetterName = new System.Windows.Forms.Label();
			this.txtLetterName = new System.Windows.Forms.TextBox();
			this.dtpLetterDate = new System.Windows.Forms.DateTimePicker();
			this.chkPrintDate = new System.Windows.Forms.CheckBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.lblWarning = new System.Windows.Forms.Label();
			this.cbxLetterHead = new System.Windows.Forms.CheckBox();
			this.cbxReturnReceipt = new System.Windows.Forms.CheckBox();
			this.btnWord = new System.Windows.Forms.Button();
			this.tabSelectCc = new System.Windows.Forms.TabPage();
			this.lbxContactPickList = new System.Windows.Forms.ListBox();
			this.bsCcs = new System.Windows.Forms.BindingSource(this.components);
			this.btnDeleteCC = new System.Windows.Forms.Button();
			this.grpCompany = new System.Windows.Forms.GroupBox();
			this.radAllContacts = new System.Windows.Forms.RadioButton();
			this.radAPCD = new System.Windows.Forms.RadioButton();
			this.radPermit = new System.Windows.Forms.RadioButton();
			this.lblCompany = new System.Windows.Forms.Label();
			this.lblAll = new System.Windows.Forms.Label();
			this.lblPermitButton = new System.Windows.Forms.Label();
			this.lblAPCD = new System.Windows.Forms.Label();
			this.cmbCompany = new System.Windows.Forms.ComboBox();
			this.bsCompany = new System.Windows.Forms.BindingSource(this.components);
			this.btnAddToCCs = new System.Windows.Forms.Button();
			this.lblAdditionalLetterCCList = new System.Windows.Forms.Label();
			this.dgvLetterCCs = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IsCoverLetterOnly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.bsLetterCc = new System.Windows.Forms.BindingSource(this.components);
			this.btnDeleteItem = new System.Windows.Forms.Button();
			this.grpBookmarkTypeId = new SbcapcdOrg.ControlLibrary.usrGroupBox();
			this.radIncompletenessItems = new SbcapcdOrg.ControlLibrary.usrRadioButton();
			this.radOptionalText = new SbcapcdOrg.ControlLibrary.usrRadioButton();
			this.textInsertTextBox = new System.Windows.Forms.TextBox();
			this.bnTransOo = new System.Windows.Forms.BindingNavigator(this.components);
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tscmbSelectLetter = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAddLetter = new System.Windows.Forms.ToolStripButton();
			this.tsbtnNewFromLetter = new System.Windows.Forms.ToolStripButton();
			this.tsbtnUndoChanges = new System.Windows.Forms.ToolStripButton();
			this.tsbtnSaveLetter = new System.Windows.Forms.ToolStripButton();
			this.tsbtnDeleteLetter = new System.Windows.Forms.ToolStripButton();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.bsTransOo = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radTransByPermit = new System.Windows.Forms.RadioButton();
			this.radTransByFacility = new System.Windows.Forms.RadioButton();
			this.radTransByStationarySource = new System.Windows.Forms.RadioButton();
			this.usrSplitContainer2 = new SbcapcdOrg.ControlLibrary.usrSplitContainer();
			this.pnlFacility = new System.Windows.Forms.Panel();
			this.txtFacilityFilter = new System.Windows.Forms.TextBox();
			this.cmbFacility = new System.Windows.Forms.ComboBox();
			this.bsFacilityList = new System.Windows.Forms.BindingSource(this.components);
			this.pnlStaSource = new System.Windows.Forms.Panel();
			this.txtFilterStatSource = new System.Windows.Forms.TextBox();
			this.cmbStatSource = new System.Windows.Forms.ComboBox();
			this.bsStationarySourceList = new System.Windows.Forms.BindingSource(this.components);
			this.usrGetPermits = new SbcapcdOrg.Permit.PermitComponents.usrGetPermits();
			this.bsLetterInsertDescription = new System.Windows.Forms.BindingSource(this.components);
			this.bsLetterInsert = new System.Windows.Forms.BindingSource(this.components);
			this.dsTransOoLetters = new SbcapcdOrg.PDEPermit.TransOo.DataSets.TransOoLettersDataSet();
			this.bsLetters = new System.Windows.Forms.BindingSource(this.components);
			this.tbcTransOoDocuments.SuspendLayout();
			this.tabDocuments.SuspendLayout();
			this.pnlTransferSuffix.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsLetter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTransOoLetter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsSignEmployee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTransOoAux)).BeginInit();
			this.tabSelectCc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsCcs)).BeginInit();
			this.grpCompany.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsCompany)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvLetterCCs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLetterCc)).BeginInit();
			this.grpBookmarkTypeId.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnTransOo)).BeginInit();
			this.bnTransOo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsTransOo)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.usrSplitContainer2)).BeginInit();
			this.usrSplitContainer2.Panel1.SuspendLayout();
			this.usrSplitContainer2.Panel2.SuspendLayout();
			this.usrSplitContainer2.SuspendLayout();
			this.pnlFacility.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsFacilityList)).BeginInit();
			this.pnlStaSource.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsStationarySourceList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLetterInsertDescription)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLetterInsert)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTransOoLetters)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLetters)).BeginInit();
			this.SuspendLayout();
			// 
			// imageList2
			// 
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
			this.imageList2.Images.SetKeyName(0, "GoToPrevious.bmp");
			this.imageList2.Images.SetKeyName(1, "RadialChart.bmp");
			this.imageList2.Images.SetKeyName(2, "ClosedTreeNode.bmp");
			this.imageList2.Images.SetKeyName(3, "Save.bmp");
			this.imageList2.Images.SetKeyName(4, "AddTable.bmp");
			this.imageList2.Images.SetKeyName(5, "Edit_Undo.bmp");
			this.imageList2.Images.SetKeyName(6, "BuilderDialog_add.bmp");
			this.imageList2.Images.SetKeyName(7, "BuilderDialog_remove.bmp");
			this.imageList2.Images.SetKeyName(8, "Control_ViewXAML.bmp");
			this.imageList2.Images.SetKeyName(9, "AddNewItem_6273_24.bmp");
			this.imageList2.Images.SetKeyName(10, "Control_OpenFileDialog.bmp");
			this.imageList2.Images.SetKeyName(11, "word_2003_icon_small.bmp");
			this.imageList2.Images.SetKeyName(12, "Filter2.bmp");
			this.imageList2.Images.SetKeyName(13, "none.bmp");
			this.imageList2.Images.SetKeyName(14, "AddProperty_5538_24.bmp");
			this.imageList2.Images.SetKeyName(15, "Paste.bmp");
			this.imageList2.Images.SetKeyName(16, "GoToNext.bmp");
			this.imageList2.Images.SetKeyName(17, "GoToPrevious.bmp");
			this.imageList2.Images.SetKeyName(18, "AddExistingItem_6269_24.bmp");
			this.imageList2.Images.SetKeyName(19, "BuilderDialog_add.bmp");
			this.imageList2.Images.SetKeyName(20, "BuilderDialog_AddAll.bmp");
			this.imageList2.Images.SetKeyName(21, "BuilderDialog_remove.bmp");
			this.imageList2.Images.SetKeyName(22, "BuilderDialog_RemoveAll.bmp");
			this.imageList2.Images.SetKeyName(23, "DoubleLeftArrow.bmp");
			this.imageList2.Images.SetKeyName(24, "DoubleRightArrow.bmp");
			this.imageList2.Images.SetKeyName(25, "FullScreen.bmp");
			this.imageList2.Images.SetKeyName(26, "Help.bmp");
			this.imageList2.Images.SetKeyName(27, "AddNewItem.bmp");
			this.imageList2.Images.SetKeyName(28, "DeleteTable.bmp");
			this.imageList2.Images.SetKeyName(29, "delete.bmp");
			this.imageList2.Images.SetKeyName(30, "GoToPreviousMessage.bmp");
			this.imageList2.Images.SetKeyName(31, "SortDown.bmp");
			// 
			// tbcTransOoDocuments
			// 
			this.tbcTransOoDocuments.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tbcTransOoDocuments.Controls.Add(this.tabDocuments);
			this.tbcTransOoDocuments.Controls.Add(this.tabSelectCc);
			this.tbcTransOoDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbcTransOoDocuments.Location = new System.Drawing.Point(0, 29);
			this.tbcTransOoDocuments.Name = "tbcTransOoDocuments";
			this.tbcTransOoDocuments.SelectedIndex = 0;
			this.tbcTransOoDocuments.Size = new System.Drawing.Size(855, 548);
			this.tbcTransOoDocuments.TabIndex = 176;
			// 
			// tabDocuments
			// 
			this.tabDocuments.BackColor = System.Drawing.SystemColors.Control;
			this.tabDocuments.Controls.Add(this.pnlTransferSuffix);
			this.tabDocuments.Controls.Add(this.letterNoTextBox);
			this.tabDocuments.Controls.Add(this.usrPermitContactsV1);
			this.tabDocuments.Controls.Add(this.btnFolder);
			this.tabDocuments.Controls.Add(this.txtFolder);
			this.tabDocuments.Controls.Add(this.label8);
			this.tabDocuments.Controls.Add(this.cmbSignEmployeeNo);
			this.tabDocuments.Controls.Add(this.lblLetterName);
			this.tabDocuments.Controls.Add(this.txtLetterName);
			this.tabDocuments.Controls.Add(this.dtpLetterDate);
			this.tabDocuments.Controls.Add(this.chkPrintDate);
			this.tabDocuments.Controls.Add(this.progressBar);
			this.tabDocuments.Controls.Add(this.lblWarning);
			this.tabDocuments.Controls.Add(this.cbxLetterHead);
			this.tabDocuments.Controls.Add(this.cbxReturnReceipt);
			this.tabDocuments.Controls.Add(this.btnWord);
			this.tabDocuments.Location = new System.Drawing.Point(4, 28);
			this.tabDocuments.Name = "tabDocuments";
			this.tabDocuments.Padding = new System.Windows.Forms.Padding(3);
			this.tabDocuments.Size = new System.Drawing.Size(847, 516);
			this.tabDocuments.TabIndex = 0;
			this.tabDocuments.Text = "Letter";
			// 
			// pnlTransferSuffix
			// 
			this.pnlTransferSuffix.Controls.Add(this.cmbTransferSuffix);
			this.pnlTransferSuffix.Controls.Add(this.label1);
			this.pnlTransferSuffix.Location = new System.Drawing.Point(7, 278);
			this.pnlTransferSuffix.Name = "pnlTransferSuffix";
			this.pnlTransferSuffix.Size = new System.Drawing.Size(173, 32);
			this.pnlTransferSuffix.TabIndex = 239;
			// 
			// cmbTransferSuffix
			// 
			this.cmbTransferSuffix.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bsLetter, "TransSuffix", true));
			this.cmbTransferSuffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTransferSuffix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbTransferSuffix.FormattingEnabled = true;
			this.cmbTransferSuffix.Items.AddRange(new object[] {
            "  ",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "09",
            "10"});
			this.cmbTransferSuffix.Location = new System.Drawing.Point(97, 2);
			this.cmbTransferSuffix.Name = "cmbTransferSuffix";
			this.cmbTransferSuffix.Size = new System.Drawing.Size(63, 24);
			this.cmbTransferSuffix.TabIndex = 237;
			this.cmbTransferSuffix.DropDownClosed += new System.EventHandler(this.cmbTransferSuffix_DropDownClosed);
			// 
			// bsLetter
			// 
			this.bsLetter.DataMember = "Letter";
			this.bsLetter.DataSource = this.dsTransOoLetter;
			// 
			// dsTransOoLetter
			// 
			this.dsTransOoLetter.DataSetName = "TransOoLetterDataSet";
			this.dsTransOoLetter.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 16);
			this.label1.TabIndex = 238;
			this.label1.Text = "Transfer Suffix";
			// 
			// letterNoTextBox
			// 
			this.letterNoTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.letterNoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.letterNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLetter, "LetterNo", true));
			this.letterNoTextBox.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.letterNoTextBox.Location = new System.Drawing.Point(535, 10);
			this.letterNoTextBox.Name = "letterNoTextBox";
			this.letterNoTextBox.Size = new System.Drawing.Size(100, 15);
			this.letterNoTextBox.TabIndex = 236;
			// 
			// usrPermitContactsV1
			// 
			this.usrPermitContactsV1.AutoScroll = true;
			this.usrPermitContactsV1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.usrPermitContactsV1.ContactId = 0;
			this.usrPermitContactsV1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.usrPermitContactsV1.Location = new System.Drawing.Point(50, 146);
			this.usrPermitContactsV1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.usrPermitContactsV1.Name = "usrPermitContactsV1";
			this.usrPermitContactsV1.Size = new System.Drawing.Size(411, 119);
			this.usrPermitContactsV1.TabIndex = 235;
			this.usrPermitContactsV1.usrConnectionString = null;
			this.usrPermitContactsV1.OnContactChanged += new SbcapcdOrg.PdePermit.ContactComponents.usrPermitContactsV.ContactChangedEventHandler(this.usrPermitContactsV1_OnContactChanged);
			this.usrPermitContactsV1.ConString += new SbcapcdOrg.ControlLibrary.usrUserControl.ConStringEventHandler(this.usrPermitContactsV1_ConString);
			// 
			// btnFolder
			// 
			this.btnFolder.AutoSize = true;
			this.btnFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnFolder.FlatAppearance.BorderSize = 0;
			this.btnFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFolder.ImageKey = "Control_FolderBrowserDialog.bmp";
			this.btnFolder.ImageList = this.imageList1;
			this.btnFolder.Location = new System.Drawing.Point(72, 316);
			this.btnFolder.Name = "btnFolder";
			this.btnFolder.Size = new System.Drawing.Size(22, 22);
			this.btnFolder.TabIndex = 233;
			this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			this.imageList1.Images.SetKeyName(0, "OpenFolder.bmp");
			this.imageList1.Images.SetKeyName(1, "Control_FolderBrowserDialog.bmp");
			// 
			// txtFolder
			// 
			this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLetter, "SaveFolder", true));
			this.txtFolder.Location = new System.Drawing.Point(102, 318);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.Size = new System.Drawing.Size(731, 22);
			this.txtFolder.TabIndex = 231;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(30, 42);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(68, 16);
			this.label8.TabIndex = 229;
			this.label8.Text = "Signed By";
			// 
			// cmbSignEmployeeNo
			// 
			this.cmbSignEmployeeNo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsLetter, "SignEmployeeNo", true));
			this.cmbSignEmployeeNo.DataSource = this.bsSignEmployee;
			this.cmbSignEmployeeNo.DisplayMember = "SignEmployee";
			this.cmbSignEmployeeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSignEmployeeNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbSignEmployeeNo.Location = new System.Drawing.Point(102, 38);
			this.cmbSignEmployeeNo.Name = "cmbSignEmployeeNo";
			this.cmbSignEmployeeNo.Size = new System.Drawing.Size(263, 24);
			this.cmbSignEmployeeNo.TabIndex = 228;
			this.cmbSignEmployeeNo.ValueMember = "EmployeeNo";
			// 
			// bsSignEmployee
			// 
			this.bsSignEmployee.DataMember = "SignEmployee";
			this.bsSignEmployee.DataSource = this.dsTransOoAux;
			// 
			// dsTransOoAux
			// 
			this.dsTransOoAux.DataSetName = "TransOoAuxDataSet";
			this.dsTransOoAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// lblLetterName
			// 
			this.lblLetterName.AutoSize = true;
			this.lblLetterName.Location = new System.Drawing.Point(57, 7);
			this.lblLetterName.Name = "lblLetterName";
			this.lblLetterName.Size = new System.Drawing.Size(41, 16);
			this.lblLetterName.TabIndex = 226;
			this.lblLetterName.Text = "Letter";
			this.lblLetterName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtLetterName
			// 
			this.txtLetterName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txtLetterName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLetter, "LetterName", true));
			this.txtLetterName.Location = new System.Drawing.Point(102, 6);
			this.txtLetterName.Name = "txtLetterName";
			this.txtLetterName.Size = new System.Drawing.Size(453, 22);
			this.txtLetterName.TabIndex = 227;
			// 
			// dtpLetterDate
			// 
			this.dtpLetterDate.Location = new System.Drawing.Point(237, 103);
			this.dtpLetterDate.Name = "dtpLetterDate";
			this.dtpLetterDate.Size = new System.Drawing.Size(224, 22);
			this.dtpLetterDate.TabIndex = 224;
			this.dtpLetterDate.Value = new System.DateTime(2004, 12, 31, 0, 0, 0, 0);
			// 
			// chkPrintDate
			// 
			this.chkPrintDate.AutoSize = true;
			this.chkPrintDate.Location = new System.Drawing.Point(102, 104);
			this.chkPrintDate.Name = "chkPrintDate";
			this.chkPrintDate.Size = new System.Drawing.Size(140, 20);
			this.chkPrintDate.TabIndex = 223;
			this.chkPrintDate.Text = "Print Date on Letter";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(102, 361);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(190, 23);
			this.progressBar.TabIndex = 22;
			this.progressBar.Visible = false;
			// 
			// lblWarning
			// 
			this.lblWarning.Location = new System.Drawing.Point(305, 361);
			this.lblWarning.Name = "lblWarning";
			this.lblWarning.Size = new System.Drawing.Size(172, 68);
			this.lblWarning.TabIndex = 21;
			// 
			// cbxLetterHead
			// 
			this.cbxLetterHead.AutoSize = true;
			this.cbxLetterHead.Checked = true;
			this.cbxLetterHead.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbxLetterHead.Location = new System.Drawing.Point(217, 74);
			this.cbxLetterHead.Name = "cbxLetterHead";
			this.cbxLetterHead.Size = new System.Drawing.Size(214, 20);
			this.cbxLetterHead.TabIndex = 20;
			this.cbxLetterHead.Text = "Print Letter Head on Plain Paper";
			// 
			// cbxReturnReceipt
			// 
			this.cbxReturnReceipt.AutoSize = true;
			this.cbxReturnReceipt.Location = new System.Drawing.Point(102, 74);
			this.cbxReturnReceipt.Name = "cbxReturnReceipt";
			this.cbxReturnReceipt.Size = new System.Drawing.Size(113, 20);
			this.cbxReturnReceipt.TabIndex = 19;
			this.cbxReturnReceipt.Text = "Return Receipt";
			// 
			// btnWord
			// 
			this.btnWord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnWord.Image = ((System.Drawing.Image)(resources.GetObject("btnWord.Image")));
			this.btnWord.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.btnWord.Location = new System.Drawing.Point(54, 352);
			this.btnWord.Name = "btnWord";
			this.btnWord.Size = new System.Drawing.Size(40, 40);
			this.btnWord.TabIndex = 18;
			this.btnWord.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
			// 
			// tabSelectCc
			// 
			this.tabSelectCc.BackColor = System.Drawing.SystemColors.Control;
			this.tabSelectCc.Controls.Add(this.lbxContactPickList);
			this.tabSelectCc.Controls.Add(this.btnDeleteCC);
			this.tabSelectCc.Controls.Add(this.grpCompany);
			this.tabSelectCc.Controls.Add(this.btnAddToCCs);
			this.tabSelectCc.Controls.Add(this.lblAdditionalLetterCCList);
			this.tabSelectCc.Controls.Add(this.dgvLetterCCs);
			this.tabSelectCc.Location = new System.Drawing.Point(4, 28);
			this.tabSelectCc.Name = "tabSelectCc";
			this.tabSelectCc.Padding = new System.Windows.Forms.Padding(3);
			this.tabSelectCc.Size = new System.Drawing.Size(847, 516);
			this.tabSelectCc.TabIndex = 1;
			this.tabSelectCc.Text = "Select CC\'s";
			// 
			// lbxContactPickList
			// 
			this.lbxContactPickList.DataSource = this.bsCcs;
			this.lbxContactPickList.DisplayMember = "ContactName";
			this.lbxContactPickList.FormattingEnabled = true;
			this.lbxContactPickList.ItemHeight = 16;
			this.lbxContactPickList.Location = new System.Drawing.Point(7, 89);
			this.lbxContactPickList.Name = "lbxContactPickList";
			this.lbxContactPickList.Size = new System.Drawing.Size(205, 164);
			this.lbxContactPickList.TabIndex = 173;
			this.lbxContactPickList.ValueMember = "ContactId";
			// 
			// bsCcs
			// 
			this.bsCcs.DataMember = "Ccs";
			this.bsCcs.DataSource = this.dsTransOoAux;
			// 
			// btnDeleteCC
			// 
			this.btnDeleteCC.AutoSize = true;
			this.btnDeleteCC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnDeleteCC.FlatAppearance.BorderSize = 0;
			this.btnDeleteCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDeleteCC.ImageKey = "GoToPrevious.bmp";
			this.btnDeleteCC.ImageList = this.imageList2;
			this.btnDeleteCC.Location = new System.Drawing.Point(215, 120);
			this.btnDeleteCC.Name = "btnDeleteCC";
			this.btnDeleteCC.Size = new System.Drawing.Size(22, 22);
			this.btnDeleteCC.TabIndex = 175;
			this.btnDeleteCC.UseVisualStyleBackColor = true;
			this.btnDeleteCC.Click += new System.EventHandler(this.btnDeleteCC_Click);
			// 
			// grpCompany
			// 
			this.grpCompany.Controls.Add(this.radAllContacts);
			this.grpCompany.Controls.Add(this.radAPCD);
			this.grpCompany.Controls.Add(this.radPermit);
			this.grpCompany.Controls.Add(this.lblCompany);
			this.grpCompany.Controls.Add(this.lblAll);
			this.grpCompany.Controls.Add(this.lblPermitButton);
			this.grpCompany.Controls.Add(this.lblAPCD);
			this.grpCompany.Controls.Add(this.cmbCompany);
			this.grpCompany.Location = new System.Drawing.Point(4, 10);
			this.grpCompany.Name = "grpCompany";
			this.grpCompany.Size = new System.Drawing.Size(594, 49);
			this.grpCompany.TabIndex = 166;
			this.grpCompany.TabStop = false;
			this.grpCompany.Text = "Get Contacts By";
			// 
			// radAllContacts
			// 
			this.radAllContacts.Appearance = System.Windows.Forms.Appearance.Button;
			this.radAllContacts.FlatAppearance.BorderSize = 0;
			this.radAllContacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radAllContacts.ImageIndex = 25;
			this.radAllContacts.ImageList = this.imageList2;
			this.radAllContacts.Location = new System.Drawing.Point(219, 19);
			this.radAllContacts.Name = "radAllContacts";
			this.radAllContacts.Size = new System.Drawing.Size(24, 24);
			this.radAllContacts.TabIndex = 164;
			this.radAllContacts.Click += new System.EventHandler(this.radAllContacts_Click);
			// 
			// radAPCD
			// 
			this.radAPCD.Appearance = System.Windows.Forms.Appearance.Button;
			this.radAPCD.FlatAppearance.BorderSize = 0;
			this.radAPCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radAPCD.ImageIndex = 25;
			this.radAPCD.ImageList = this.imageList2;
			this.radAPCD.Location = new System.Drawing.Point(148, 19);
			this.radAPCD.Name = "radAPCD";
			this.radAPCD.Size = new System.Drawing.Size(24, 24);
			this.radAPCD.TabIndex = 163;
			this.radAPCD.Click += new System.EventHandler(this.radAPCD_Click);
			// 
			// radPermit
			// 
			this.radPermit.Appearance = System.Windows.Forms.Appearance.Button;
			this.radPermit.BackColor = System.Drawing.SystemColors.Control;
			this.radPermit.FlatAppearance.BorderSize = 0;
			this.radPermit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radPermit.ImageIndex = 25;
			this.radPermit.ImageList = this.imageList2;
			this.radPermit.Location = new System.Drawing.Point(4, 19);
			this.radPermit.Name = "radPermit";
			this.radPermit.Size = new System.Drawing.Size(24, 24);
			this.radPermit.TabIndex = 162;
			this.radPermit.UseVisualStyleBackColor = false;
			this.radPermit.Click += new System.EventHandler(this.radPermit_Click);
			// 
			// lblCompany
			// 
			this.lblCompany.AutoSize = true;
			this.lblCompany.Location = new System.Drawing.Point(271, 23);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.Size = new System.Drawing.Size(63, 16);
			this.lblCompany.TabIndex = 161;
			this.lblCompany.Text = "Company";
			this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblAll
			// 
			this.lblAll.AutoSize = true;
			this.lblAll.Location = new System.Drawing.Point(243, 23);
			this.lblAll.Name = "lblAll";
			this.lblAll.Size = new System.Drawing.Size(23, 16);
			this.lblAll.TabIndex = 153;
			this.lblAll.Text = "All";
			this.lblAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPermitButton
			// 
			this.lblPermitButton.AutoSize = true;
			this.lblPermitButton.Location = new System.Drawing.Point(28, 23);
			this.lblPermitButton.Name = "lblPermitButton";
			this.lblPermitButton.Size = new System.Drawing.Size(100, 16);
			this.lblPermitButton.TabIndex = 151;
			this.lblPermitButton.Text = "Permit / Facility";
			this.lblPermitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAPCD
			// 
			this.lblAPCD.AutoSize = true;
			this.lblAPCD.Location = new System.Drawing.Point(172, 23);
			this.lblAPCD.Name = "lblAPCD";
			this.lblAPCD.Size = new System.Drawing.Size(44, 16);
			this.lblAPCD.TabIndex = 150;
			this.lblAPCD.Text = "APCD";
			this.lblAPCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbCompany
			// 
			this.cmbCompany.DataSource = this.bsCompany;
			this.cmbCompany.DisplayMember = "CompanyName";
			this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCompany.Location = new System.Drawing.Point(331, 19);
			this.cmbCompany.MaxDropDownItems = 16;
			this.cmbCompany.Name = "cmbCompany";
			this.cmbCompany.Size = new System.Drawing.Size(266, 24);
			this.cmbCompany.TabIndex = 160;
			this.cmbCompany.ValueMember = "CompanyNo";
			this.cmbCompany.SelectionChangeCommitted += new System.EventHandler(this.cmbCompany_SelectionChangeCommitted);
			// 
			// bsCompany
			// 
			this.bsCompany.DataMember = "Company";
			// 
			// btnAddToCCs
			// 
			this.btnAddToCCs.AutoSize = true;
			this.btnAddToCCs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAddToCCs.FlatAppearance.BorderSize = 0;
			this.btnAddToCCs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddToCCs.ImageKey = "GoToNext.bmp";
			this.btnAddToCCs.ImageList = this.imageList2;
			this.btnAddToCCs.Location = new System.Drawing.Point(215, 89);
			this.btnAddToCCs.Name = "btnAddToCCs";
			this.btnAddToCCs.Size = new System.Drawing.Size(22, 22);
			this.btnAddToCCs.TabIndex = 174;
			this.btnAddToCCs.UseVisualStyleBackColor = true;
			this.btnAddToCCs.Click += new System.EventHandler(this.btnAddToCCs_Click);
			// 
			// lblAdditionalLetterCCList
			// 
			this.lblAdditionalLetterCCList.Location = new System.Drawing.Point(245, 67);
			this.lblAdditionalLetterCCList.Name = "lblAdditionalLetterCCList";
			this.lblAdditionalLetterCCList.Size = new System.Drawing.Size(184, 16);
			this.lblAdditionalLetterCCList.TabIndex = 167;
			this.lblAdditionalLetterCCList.Text = "Additional Letter CC List:";
			// 
			// dgvLetterCCs
			// 
			this.dgvLetterCCs.AllowUserToAddRows = false;
			this.dgvLetterCCs.AllowUserToDeleteRows = false;
			this.dgvLetterCCs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvLetterCCs.AutoGenerateColumns = false;
			this.dgvLetterCCs.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvLetterCCs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvLetterCCs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.IsCoverLetterOnly});
			this.dgvLetterCCs.DataSource = this.bsLetterCc;
			this.dgvLetterCCs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvLetterCCs.Location = new System.Drawing.Point(240, 89);
			this.dgvLetterCCs.MultiSelect = false;
			this.dgvLetterCCs.Name = "dgvLetterCCs";
			this.dgvLetterCCs.RowHeadersVisible = false;
			this.dgvLetterCCs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvLetterCCs.Size = new System.Drawing.Size(591, 164);
			this.dgvLetterCCs.TabIndex = 172;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "ContactName";
			this.dataGridViewTextBoxColumn1.HeaderText = "ContactName";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// IsCoverLetterOnly
			// 
			this.IsCoverLetterOnly.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.IsCoverLetterOnly.DataPropertyName = "IsCoverLetterOnly";
			this.IsCoverLetterOnly.HeaderText = "Cover Letter Only";
			this.IsCoverLetterOnly.Name = "IsCoverLetterOnly";
			// 
			// bsLetterCc
			// 
			this.bsLetterCc.DataMember = "LetterCc";
			this.bsLetterCc.DataSource = this.dsTransOoLetter;
			// 
			// btnDeleteItem
			// 
			this.btnDeleteItem.AutoSize = true;
			this.btnDeleteItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnDeleteItem.FlatAppearance.BorderSize = 0;
			this.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDeleteItem.ImageIndex = 29;
			this.btnDeleteItem.ImageList = this.imageList2;
			this.btnDeleteItem.Location = new System.Drawing.Point(335, 0);
			this.btnDeleteItem.Name = "btnDeleteItem";
			this.btnDeleteItem.Size = new System.Drawing.Size(22, 22);
			this.btnDeleteItem.TabIndex = 236;
			this.btnDeleteItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDeleteItem.UseVisualStyleBackColor = true;
			// 
			// grpBookmarkTypeId
			// 
			this.grpBookmarkTypeId.Controls.Add(this.radIncompletenessItems);
			this.grpBookmarkTypeId.Controls.Add(this.radOptionalText);
			this.grpBookmarkTypeId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpBookmarkTypeId.Location = new System.Drawing.Point(337, 44);
			this.grpBookmarkTypeId.Name = "grpBookmarkTypeId";
			this.grpBookmarkTypeId.RaiseOnGroupBoxClick = true;
			this.grpBookmarkTypeId.Size = new System.Drawing.Size(154, 61);
			this.grpBookmarkTypeId.TabIndex = 5;
			this.grpBookmarkTypeId.TabStop = false;
			// 
			// radIncompletenessItems
			// 
			this.radIncompletenessItems.AutoSize = true;
			this.radIncompletenessItems.Location = new System.Drawing.Point(7, 33);
			this.radIncompletenessItems.Name = "radIncompletenessItems";
			this.radIncompletenessItems.Size = new System.Drawing.Size(146, 20);
			this.radIncompletenessItems.TabIndex = 2;
			this.radIncompletenessItems.TabStop = true;
			this.radIncompletenessItems.Tag = "8";
			this.radIncompletenessItems.Text = "Incompleteness Item";
			this.radIncompletenessItems.UseVisualStyleBackColor = true;
			// 
			// radOptionalText
			// 
			this.radOptionalText.AutoSize = true;
			this.radOptionalText.Location = new System.Drawing.Point(7, 12);
			this.radOptionalText.Name = "radOptionalText";
			this.radOptionalText.Size = new System.Drawing.Size(102, 20);
			this.radOptionalText.TabIndex = 1;
			this.radOptionalText.TabStop = true;
			this.radOptionalText.Tag = "7";
			this.radOptionalText.Text = "Optional Text";
			this.radOptionalText.UseVisualStyleBackColor = true;
			// 
			// textInsertTextBox
			// 
			this.textInsertTextBox.Location = new System.Drawing.Point(3, 0);
			this.textInsertTextBox.Multiline = true;
			this.textInsertTextBox.Name = "textInsertTextBox";
			this.textInsertTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.textInsertTextBox.Size = new System.Drawing.Size(329, 120);
			this.textInsertTextBox.TabIndex = 1;
			// 
			// bnTransOo
			// 
			this.bnTransOo.AddNewItem = null;
			this.bnTransOo.CountItem = null;
			this.bnTransOo.DeleteItem = null;
			this.bnTransOo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bnTransOo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.bnTransOo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscmbSelectLetter,
            this.toolStripSeparator1,
            this.tsbtnAddLetter,
            this.tsbtnNewFromLetter,
            this.tsbtnUndoChanges,
            this.tsbtnSaveLetter,
            this.tsbtnDeleteLetter});
			this.bnTransOo.Location = new System.Drawing.Point(0, 0);
			this.bnTransOo.MoveFirstItem = null;
			this.bnTransOo.MoveLastItem = null;
			this.bnTransOo.MoveNextItem = null;
			this.bnTransOo.MovePreviousItem = null;
			this.bnTransOo.Name = "bnTransOo";
			this.bnTransOo.Padding = new System.Windows.Forms.Padding(0, 0, 1, 5);
			this.bnTransOo.PositionItem = null;
			this.bnTransOo.Size = new System.Drawing.Size(855, 29);
			this.bnTransOo.TabIndex = 1;
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(36, 21);
			this.toolStripLabel1.Text = "       ";
			// 
			// tscmbSelectLetter
			// 
			this.tscmbSelectLetter.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tscmbSelectLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscmbSelectLetter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.tscmbSelectLetter.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tscmbSelectLetter.Name = "tscmbSelectLetter";
			this.tscmbSelectLetter.Size = new System.Drawing.Size(400, 24);
			this.tscmbSelectLetter.DropDownClosed += new System.EventHandler(this.tscmbSelectLetter_DropDownClosed);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
			// 
			// tsbtnAddLetter
			// 
			this.tsbtnAddLetter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnAddLetter.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddLetter.Image")));
			this.tsbtnAddLetter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddLetter.Name = "tsbtnAddLetter";
			this.tsbtnAddLetter.Size = new System.Drawing.Size(23, 21);
			this.tsbtnAddLetter.Text = "toolStripButton1";
			this.tsbtnAddLetter.ToolTipText = "Add Letter";
			this.tsbtnAddLetter.Click += new System.EventHandler(this.tsbtnAddLetter_Click);
			// 
			// tsbtnNewFromLetter
			// 
			this.tsbtnNewFromLetter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnNewFromLetter.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNewFromLetter.Image")));
			this.tsbtnNewFromLetter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnNewFromLetter.Name = "tsbtnNewFromLetter";
			this.tsbtnNewFromLetter.Size = new System.Drawing.Size(23, 21);
			this.tsbtnNewFromLetter.Text = "toolStripButton1";
			this.tsbtnNewFromLetter.Visible = false;
			// 
			// tsbtnUndoChanges
			// 
			this.tsbtnUndoChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnUndoChanges.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUndoChanges.Image")));
			this.tsbtnUndoChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnUndoChanges.Name = "tsbtnUndoChanges";
			this.tsbtnUndoChanges.Size = new System.Drawing.Size(23, 21);
			this.tsbtnUndoChanges.ToolTipText = "Undo Changes";
			this.tsbtnUndoChanges.Visible = false;
			this.tsbtnUndoChanges.Click += new System.EventHandler(this.tsbtnUndoChanges_Click);
			// 
			// tsbtnSaveLetter
			// 
			this.tsbtnSaveLetter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSaveLetter.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaveLetter.Image")));
			this.tsbtnSaveLetter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSaveLetter.Name = "tsbtnSaveLetter";
			this.tsbtnSaveLetter.Size = new System.Drawing.Size(23, 21);
			this.tsbtnSaveLetter.Text = "toolStripButton2";
			this.tsbtnSaveLetter.ToolTipText = "Save Letter";
			this.tsbtnSaveLetter.Click += new System.EventHandler(this.tsbtnSaveLetter_Click);
			// 
			// tsbtnDeleteLetter
			// 
			this.tsbtnDeleteLetter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnDeleteLetter.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDeleteLetter.Image")));
			this.tsbtnDeleteLetter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDeleteLetter.Name = "tsbtnDeleteLetter";
			this.tsbtnDeleteLetter.Size = new System.Drawing.Size(23, 21);
			this.tsbtnDeleteLetter.Text = "toolStripButton1";
			this.tsbtnDeleteLetter.Click += new System.EventHandler(this.tsbtnDeleteLetter_Click);
			// 
			// bsTransOo
			// 
			this.bsTransOo.DataMember = "TransOo";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radTransByPermit);
			this.groupBox2.Controls.Add(this.radTransByFacility);
			this.groupBox2.Controls.Add(this.radTransByStationarySource);
			this.groupBox2.Location = new System.Drawing.Point(3, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(308, 46);
			this.groupBox2.TabIndex = 173;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Transfer O/O By";
			// 
			// radTransByPermit
			// 
			this.radTransByPermit.AutoSize = true;
			this.radTransByPermit.Checked = true;
			this.radTransByPermit.Location = new System.Drawing.Point(8, 18);
			this.radTransByPermit.Name = "radTransByPermit";
			this.radTransByPermit.Size = new System.Drawing.Size(64, 20);
			this.radTransByPermit.TabIndex = 2;
			this.radTransByPermit.TabStop = true;
			this.radTransByPermit.Text = "Permit";
			this.radTransByPermit.Click += new System.EventHandler(this.radTransBy_Click);
			// 
			// radTransByFacility
			// 
			this.radTransByFacility.AutoSize = true;
			this.radTransByFacility.Location = new System.Drawing.Point(84, 18);
			this.radTransByFacility.Name = "radTransByFacility";
			this.radTransByFacility.Size = new System.Drawing.Size(68, 20);
			this.radTransByFacility.TabIndex = 1;
			this.radTransByFacility.Text = "Facility";
			this.radTransByFacility.Click += new System.EventHandler(this.radTransBy_Click);
			// 
			// radTransByStationarySource
			// 
			this.radTransByStationarySource.AutoSize = true;
			this.radTransByStationarySource.Location = new System.Drawing.Point(162, 18);
			this.radTransByStationarySource.Name = "radTransByStationarySource";
			this.radTransByStationarySource.Size = new System.Drawing.Size(130, 20);
			this.radTransByStationarySource.TabIndex = 0;
			this.radTransByStationarySource.Text = "Stationary Source";
			this.radTransByStationarySource.Click += new System.EventHandler(this.radTransBy_Click);
			// 
			// usrSplitContainer2
			// 
			this.usrSplitContainer2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.usrSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.usrSplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.usrSplitContainer2.Location = new System.Drawing.Point(0, 5);
			this.usrSplitContainer2.Name = "usrSplitContainer2";
			this.usrSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// usrSplitContainer2.Panel1
			// 
			this.usrSplitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.usrSplitContainer2.Panel1.Controls.Add(this.groupBox2);
			this.usrSplitContainer2.Panel1.Controls.Add(this.pnlFacility);
			this.usrSplitContainer2.Panel1.Controls.Add(this.pnlStaSource);
			this.usrSplitContainer2.Panel1.Controls.Add(this.usrGetPermits);
			// 
			// usrSplitContainer2.Panel2
			// 
			this.usrSplitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.usrSplitContainer2.Panel2.Controls.Add(this.tbcTransOoDocuments);
			this.usrSplitContainer2.Panel2.Controls.Add(this.bnTransOo);
			this.usrSplitContainer2.Size = new System.Drawing.Size(855, 633);
			this.usrSplitContainer2.SplitterDistance = 52;
			this.usrSplitContainer2.TabIndex = 174;
			// 
			// pnlFacility
			// 
			this.pnlFacility.AutoSize = true;
			this.pnlFacility.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnlFacility.Controls.Add(this.txtFacilityFilter);
			this.pnlFacility.Controls.Add(this.cmbFacility);
			this.pnlFacility.Location = new System.Drawing.Point(329, 12);
			this.pnlFacility.Name = "pnlFacility";
			this.pnlFacility.Size = new System.Drawing.Size(439, 32);
			this.pnlFacility.TabIndex = 175;
			this.pnlFacility.Visible = false;
			// 
			// txtFacilityFilter
			// 
			this.txtFacilityFilter.Location = new System.Drawing.Point(4, 5);
			this.txtFacilityFilter.Name = "txtFacilityFilter";
			this.txtFacilityFilter.Size = new System.Drawing.Size(75, 22);
			this.txtFacilityFilter.TabIndex = 1;
			this.txtFacilityFilter.TextChanged += new System.EventHandler(this.txtFacilityFilter_TextChanged);
			// 
			// cmbFacility
			// 
			this.cmbFacility.DataSource = this.bsFacilityList;
			this.cmbFacility.DisplayMember = "FacilityName";
			this.cmbFacility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFacility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbFacility.FormattingEnabled = true;
			this.cmbFacility.Location = new System.Drawing.Point(86, 5);
			this.cmbFacility.Name = "cmbFacility";
			this.cmbFacility.Size = new System.Drawing.Size(350, 24);
			this.cmbFacility.TabIndex = 0;
			this.cmbFacility.ValueMember = "FacilityNo";
			this.cmbFacility.SelectionChangeCommitted += new System.EventHandler(this.cmbFacility_SelectionChangeCommitted);
			// 
			// bsFacilityList
			// 
			this.bsFacilityList.DataMember = "FacilityList";
			this.bsFacilityList.DataSource = this.dsTransOoAux;
			// 
			// pnlStaSource
			// 
			this.pnlStaSource.AutoSize = true;
			this.pnlStaSource.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnlStaSource.Controls.Add(this.txtFilterStatSource);
			this.pnlStaSource.Controls.Add(this.cmbStatSource);
			this.pnlStaSource.Location = new System.Drawing.Point(329, 13);
			this.pnlStaSource.Name = "pnlStaSource";
			this.pnlStaSource.Size = new System.Drawing.Size(438, 32);
			this.pnlStaSource.TabIndex = 174;
			this.pnlStaSource.Visible = false;
			// 
			// txtFilterStatSource
			// 
			this.txtFilterStatSource.Location = new System.Drawing.Point(4, 5);
			this.txtFilterStatSource.Name = "txtFilterStatSource";
			this.txtFilterStatSource.Size = new System.Drawing.Size(75, 22);
			this.txtFilterStatSource.TabIndex = 1;
			this.txtFilterStatSource.TextChanged += new System.EventHandler(this.txtFilterStatSource_TextChanged);
			// 
			// cmbStatSource
			// 
			this.cmbStatSource.DataSource = this.bsStationarySourceList;
			this.cmbStatSource.DisplayMember = "StationarySourceName";
			this.cmbStatSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbStatSource.FormattingEnabled = true;
			this.cmbStatSource.Location = new System.Drawing.Point(85, 5);
			this.cmbStatSource.Name = "cmbStatSource";
			this.cmbStatSource.Size = new System.Drawing.Size(350, 24);
			this.cmbStatSource.TabIndex = 0;
			this.cmbStatSource.ValueMember = "StationarySourceNo";
			this.cmbStatSource.SelectionChangeCommitted += new System.EventHandler(this.cmbStatSource_SelectionChangeCommitted);
			// 
			// bsStationarySourceList
			// 
			this.bsStationarySourceList.DataMember = "StationarySourceList";
			this.bsStationarySourceList.DataSource = this.dsTransOoAux;
			// 
			// usrGetPermits
			// 
			this.usrGetPermits.AutoScroll = true;
			this.usrGetPermits.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.usrGetPermits.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.usrGetPermits.Location = new System.Drawing.Point(340, 14);
			this.usrGetPermits.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.usrGetPermits.Name = "usrGetPermits";
			this.usrGetPermits.Size = new System.Drawing.Size(361, 28);
			this.usrGetPermits.TabIndex = 0;
			this.usrGetPermits.usrConnectionString = null;
			this.usrGetPermits.Visible = false;
			this.usrGetPermits.OnPermitNoChanged += new SbcapcdOrg.Permit.PermitComponents.usrGetPermits.PermitNoChangedEventHandler(this.usrGetPermits_OnPermitNoChanged);
			// 
			// bsLetterInsertDescription
			// 
			this.bsLetterInsertDescription.DataMember = "LetterInsert";
			this.bsLetterInsertDescription.DataSource = this.dsTransOoLetter;
			// 
			// bsLetterInsert
			// 
			this.bsLetterInsert.DataMember = "LetterInsert";
			this.bsLetterInsert.DataSource = this.dsTransOoLetter;
			// 
			// dsTransOoLetters
			// 
			this.dsTransOoLetters.DataSetName = "TransOoLettersDataSet";
			this.dsTransOoLetters.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// bsLetters
			// 
			this.bsLetters.DataMember = "Letters";
			this.bsLetters.DataSource = this.dsTransOoLetters;
			// 
			// usrTransOo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.usrSplitContainer2);
			this.Name = "usrTransOo";
			this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.Size = new System.Drawing.Size(855, 638);
			this.Enter += new System.EventHandler(this.usrTransOo_Enter);
			this.tbcTransOoDocuments.ResumeLayout(false);
			this.tabDocuments.ResumeLayout(false);
			this.tabDocuments.PerformLayout();
			this.pnlTransferSuffix.ResumeLayout(false);
			this.pnlTransferSuffix.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsLetter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTransOoLetter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsSignEmployee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTransOoAux)).EndInit();
			this.tabSelectCc.ResumeLayout(false);
			this.tabSelectCc.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsCcs)).EndInit();
			this.grpCompany.ResumeLayout(false);
			this.grpCompany.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsCompany)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvLetterCCs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLetterCc)).EndInit();
			this.grpBookmarkTypeId.ResumeLayout(false);
			this.grpBookmarkTypeId.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnTransOo)).EndInit();
			this.bnTransOo.ResumeLayout(false);
			this.bnTransOo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsTransOo)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.usrSplitContainer2.Panel1.ResumeLayout(false);
			this.usrSplitContainer2.Panel1.PerformLayout();
			this.usrSplitContainer2.Panel2.ResumeLayout(false);
			this.usrSplitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.usrSplitContainer2)).EndInit();
			this.usrSplitContainer2.ResumeLayout(false);
			this.pnlFacility.ResumeLayout(false);
			this.pnlFacility.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsFacilityList)).EndInit();
			this.pnlStaSource.ResumeLayout(false);
			this.pnlStaSource.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsStationarySourceList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLetterInsertDescription)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLetterInsert)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTransOoLetters)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsLetters)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnTransOo;
        private System.Windows.Forms.ToolStripButton tsbtnAddLetter;
        private System.Windows.Forms.ToolStripButton tsbtnSaveLetter;
        private System.Windows.Forms.ToolStripComboBox tscmbSelectLetter;
        private System.Windows.Forms.Button btnDeleteCC;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnAddToCCs;
        private System.Windows.Forms.ListBox lbxContactPickList;
        private System.Windows.Forms.DataGridView dgvLetterCCs;
        private System.Windows.Forms.Label lblAdditionalLetterCCList;
        private System.Windows.Forms.GroupBox grpCompany;
        private System.Windows.Forms.RadioButton radAllContacts;
        private System.Windows.Forms.RadioButton radAPCD;
        private System.Windows.Forms.RadioButton radPermit;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblAll;
        private System.Windows.Forms.Label lblPermitButton;
        private System.Windows.Forms.Label lblAPCD;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.BindingSource bsSignEmployee;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnNewFromLetter;
        private System.Windows.Forms.ToolStripButton tsbtnUndoChanges;
        private System.Windows.Forms.TabControl tbcTransOoDocuments;
        private System.Windows.Forms.TabPage tabDocuments;
        protected System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSignEmployeeNo;
        private System.Windows.Forms.Label lblLetterName;
        private System.Windows.Forms.TextBox txtLetterName;
        private System.Windows.Forms.DateTimePicker dtpLetterDate;
        private System.Windows.Forms.CheckBox chkPrintDate;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.CheckBox cbxLetterHead;
        private System.Windows.Forms.CheckBox cbxReturnReceipt;
        private System.Windows.Forms.Button btnWord;
        private System.Windows.Forms.TabPage tabSelectCc;
        private System.Windows.Forms.TextBox textInsertTextBox;
        private ControlLibrary.usrGroupBox grpBookmarkTypeId;
        private ControlLibrary.usrRadioButton radIncompletenessItems;
        private ControlLibrary.usrRadioButton radOptionalText;
        private System.Windows.Forms.BindingSource bsTransOo;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.BindingSource bsLetterCc;
        private System.Windows.Forms.BindingSource bsCcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsCompany;
        private System.Windows.Forms.ToolStripButton tsbtnDeleteLetter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radTransByPermit;
        private System.Windows.Forms.RadioButton radTransByFacility;
        private System.Windows.Forms.RadioButton radTransByStationarySource;
        private ControlLibrary.usrSplitContainer usrSplitContainer2;
        private Permit.PermitComponents.usrGetPermits usrGetPermits;
        private DataSets.TransOoAuxDataSet dsTransOoAux;
        private System.Windows.Forms.BindingSource bsFacilityList;
        private System.Windows.Forms.BindingSource bsStationarySourceList;
        private System.Windows.Forms.Panel pnlFacility;
        private System.Windows.Forms.TextBox txtFacilityFilter;
        private System.Windows.Forms.ComboBox cmbFacility;
        private System.Windows.Forms.Panel pnlStaSource;
        private System.Windows.Forms.TextBox txtFilterStatSource;
        private System.Windows.Forms.ComboBox cmbStatSource;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private DataSets.TransOoLetterDataSet dsTransOoLetter;
        private System.Windows.Forms.BindingSource bsLetter;
        private System.Windows.Forms.BindingSource bsLetterInsertDescription;
        private System.Windows.Forms.BindingSource bsLetterInsert;
        private PdePermit.ContactComponents.usrPermitContactsV usrPermitContactsV1;
        private System.Windows.Forms.TextBox letterNoTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCoverLetterOnly;
        private DataSets.TransOoLettersDataSet dsTransOoLetters;
        private System.Windows.Forms.BindingSource bsLetters;
		private System.Windows.Forms.ComboBox cmbTransferSuffix;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlTransferSuffix;


    }
}
