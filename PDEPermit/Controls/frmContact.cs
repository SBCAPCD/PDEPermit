using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SbcapcdOrg.PdePermit.PdePermitComponents;
using SbcapcdOrg.PdePermit.Company;

namespace SbcapcdOrg.PdePermit.Forms
{
	public partial class frmContact : SbcapcdOrg.ControlLibrary.frmChildForm
	{
		SbcapcdOrg.ControlLibrary.UserRoles PdePermitUserRoles;

		public frmContact()
		{
			InitializeComponent();
            PdePermitUserRoles = new SbcapcdOrg.ControlLibrary.UserRoles(base.frmConnectionString, "PdePermit");

            this.ShowIcon = false;
            this.WindowState = FormWindowState.Normal;
		}

		private void ContactForm_Shown(object sender, EventArgs e)
		{
            //Application.DoEvents();

			this.Parent.Cursor = Cursors.WaitCursor;

			Company.SetCompanyUserRoles(PdePermitUserRoles);
			Company.LoadCompany();

			Contacts.SetContactUserRoles(PdePermitUserRoles);
			Contacts.LoadContacts();

			StationarySourceContacts.LoadStationarySourceContacts();

            //Application.DoEvents();
            //this.ShowIcon = true;
            //this.WindowState = FormWindowState.Maximized;

			this.Parent.Cursor = Cursors.Default;
            //Application.DoEvents();
		}

		private void ContactForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Contacts.ContactDataSetHasChanges)
			{
				DialogResult dialogResult = dialogResult = MessageBox.Show("Contact has changes. Do you want to save before continuing?" + Environment.NewLine + Environment.NewLine +
				"Yes - Save and Continue." + Environment.NewLine + Environment.NewLine +
				"No - Undo all changes since the last save and Continue." + Environment.NewLine + Environment.NewLine +
				"Cancel - Do not Continue.",
				"Save Contact?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (dialogResult == DialogResult.Yes)
				{
					Contacts.SaveContact();
				}
				else if (dialogResult == DialogResult.No)
				{
					Contacts.ContactsRejectChanges();
				}
				else if (dialogResult == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}
			if(Company.CompanyDataSetHasChanges)
			{
				DialogResult dialogResult = dialogResult = MessageBox.Show("Company has changes. Do you want to save before continuing?" + Environment.NewLine + Environment.NewLine +
				"Yes - Save and Continue." + Environment.NewLine + Environment.NewLine +
				"No - Undo all changes since the last save and Continue." + Environment.NewLine + Environment.NewLine +
				"Cancel - Do not Continue.",
				"Save Company?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (dialogResult == DialogResult.Yes)
				{
					Company.SaveCompany();
				}
				else if (dialogResult == DialogResult.No)
				{
					Company.ContactsRejectChanges();
				}
				else if (dialogResult == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}
		}

        private void usrAddressList_ConString(object sender)
        {
            usrAddressList.LoadAddressList();
        }
	}
}
