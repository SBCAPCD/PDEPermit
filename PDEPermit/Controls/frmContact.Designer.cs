namespace SbcapcdOrg.PdePermit.Forms
{
	partial class frmContact
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContact));
			this.tbcContact = new System.Windows.Forms.TabControl();
			this.tabContact = new System.Windows.Forms.TabPage();
			this.Contacts = new SbcapcdOrg.Contact.usrContacts();
			this.tabCompany = new System.Windows.Forms.TabPage();
			this.Company = new SbcapcdOrg.PdePermit.Company.usrCompany();
			this.tabAddressList = new System.Windows.Forms.TabPage();
			this.usrAddressList = new SbcapcdOrg.Address.usrAddressList();
			this.tabStationarySourceContacts = new System.Windows.Forms.TabPage();
			this.StationarySourceContacts = new SbcapcdOrg.Contact.usrStationarySourceContacts();
			this.tbcContact.SuspendLayout();
			this.tabContact.SuspendLayout();
			this.tabCompany.SuspendLayout();
			this.tabAddressList.SuspendLayout();
			this.tabStationarySourceContacts.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbcContact
			// 
			this.tbcContact.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tbcContact.Controls.Add(this.tabContact);
			this.tbcContact.Controls.Add(this.tabCompany);
			this.tbcContact.Controls.Add(this.tabAddressList);
			this.tbcContact.Controls.Add(this.tabStationarySourceContacts);
			this.tbcContact.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbcContact.Location = new System.Drawing.Point(0, 5);
			this.tbcContact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbcContact.Name = "tbcContact";
			this.tbcContact.SelectedIndex = 0;
			this.tbcContact.Size = new System.Drawing.Size(832, 549);
			this.tbcContact.TabIndex = 0;
			// 
			// tabContact
			// 
			this.tabContact.Controls.Add(this.Contacts);
			this.tabContact.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabContact.Location = new System.Drawing.Point(4, 28);
			this.tabContact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabContact.Name = "tabContact";
			this.tabContact.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabContact.Size = new System.Drawing.Size(824, 517);
			this.tabContact.TabIndex = 0;
			this.tabContact.Text = "Contact";
			this.tabContact.UseVisualStyleBackColor = true;
			// 
			// Contacts
			// 
			this.Contacts.AutoScroll = true;
			this.Contacts.AutoSize = true;
			this.Contacts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Contacts.ContactDataSetHasChanges = false;
			this.Contacts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Contacts.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Contacts.Location = new System.Drawing.Point(3, 4);
			this.Contacts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Contacts.Name = "Contacts";
			this.Contacts.Size = new System.Drawing.Size(818, 509);
			this.Contacts.TabIndex = 0;
			this.Contacts.usrConnectionString = null;
			// 
			// tabCompany
			// 
			this.tabCompany.Controls.Add(this.Company);
			this.tabCompany.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabCompany.Location = new System.Drawing.Point(4, 28);
			this.tabCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabCompany.Name = "tabCompany";
			this.tabCompany.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabCompany.Size = new System.Drawing.Size(824, 517);
			this.tabCompany.TabIndex = 1;
			this.tabCompany.Text = "Company";
			this.tabCompany.UseVisualStyleBackColor = true;
			// 
			// Company
			// 
			this.Company.AutoScroll = true;
			this.Company.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Company.CompanyDataSetHasChanges = false;
			this.Company.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Company.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Company.Location = new System.Drawing.Point(3, 4);
			this.Company.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Company.Name = "Company";
			this.Company.Size = new System.Drawing.Size(818, 509);
			this.Company.TabIndex = 0;
			this.Company.usrConnectionString = null;
			// 
			// tabAddressList
			// 
			this.tabAddressList.Controls.Add(this.usrAddressList);
			this.tabAddressList.Location = new System.Drawing.Point(4, 28);
			this.tabAddressList.Name = "tabAddressList";
			this.tabAddressList.Padding = new System.Windows.Forms.Padding(3);
			this.tabAddressList.Size = new System.Drawing.Size(824, 517);
			this.tabAddressList.TabIndex = 3;
			this.tabAddressList.Text = "Address List";
			this.tabAddressList.UseVisualStyleBackColor = true;
			// 
			// usrAddressList
			// 
			this.usrAddressList.AutoScroll = true;
			this.usrAddressList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.usrAddressList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.usrAddressList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.usrAddressList.Location = new System.Drawing.Point(3, 3);
			this.usrAddressList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.usrAddressList.Name = "usrAddressList";
			this.usrAddressList.Size = new System.Drawing.Size(818, 511);
			this.usrAddressList.TabIndex = 0;
			this.usrAddressList.usrConnectionString = null;
			this.usrAddressList.ConString += new SbcapcdOrg.ControlLibrary.usrUserControl.ConStringEventHandler(this.usrAddressList_ConString);
			// 
			// tabStationarySourceContacts
			// 
			this.tabStationarySourceContacts.Controls.Add(this.StationarySourceContacts);
			this.tabStationarySourceContacts.Location = new System.Drawing.Point(4, 28);
			this.tabStationarySourceContacts.Name = "tabStationarySourceContacts";
			this.tabStationarySourceContacts.Padding = new System.Windows.Forms.Padding(3);
			this.tabStationarySourceContacts.Size = new System.Drawing.Size(824, 517);
			this.tabStationarySourceContacts.TabIndex = 2;
			this.tabStationarySourceContacts.Text = "Stationary Source Contacts";
			this.tabStationarySourceContacts.UseVisualStyleBackColor = true;
			// 
			// StationarySourceContacts
			// 
			this.StationarySourceContacts.AutoScroll = true;
			this.StationarySourceContacts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.StationarySourceContacts.DataSetHasChanges = false;
			this.StationarySourceContacts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StationarySourceContacts.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StationarySourceContacts.Location = new System.Drawing.Point(3, 3);
			this.StationarySourceContacts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.StationarySourceContacts.Name = "StationarySourceContacts";
			this.StationarySourceContacts.Size = new System.Drawing.Size(818, 511);
			this.StationarySourceContacts.TabIndex = 0;
			this.StationarySourceContacts.usrConnectionString = null;
			// 
			// frmContact
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(832, 576);
			this.Controls.Add(this.tbcContact);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmContact";
			this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.ShowIcon = false;
			this.Text = "Contact / Company";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContactForm_FormClosing);
			this.Shown += new System.EventHandler(this.ContactForm_Shown);
			this.Controls.SetChildIndex(this.tbcContact, 0);
			this.tbcContact.ResumeLayout(false);
			this.tabContact.ResumeLayout(false);
			this.tabContact.PerformLayout();
			this.tabCompany.ResumeLayout(false);
			this.tabAddressList.ResumeLayout(false);
			this.tabStationarySourceContacts.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tbcContact;
		private System.Windows.Forms.TabPage tabContact;
		private System.Windows.Forms.TabPage tabCompany;
		private SbcapcdOrg.Contact.usrContacts Contacts;
		private SbcapcdOrg.PdePermit.Company.usrCompany Company;
		private System.Windows.Forms.TabPage tabStationarySourceContacts;
		private SbcapcdOrg.Contact.usrStationarySourceContacts StationarySourceContacts;
        private System.Windows.Forms.TabPage tabAddressList;
        private Address.usrAddressList usrAddressList;
	}
}