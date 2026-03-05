using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SbcapcdOrg.PdePermit
{
    public partial class frmOpen : Form
    {
        public string PdeModule { get; set; }
        public bool IsTest { get; set; } = false;

        public frmOpen()
        {
            InitializeComponent();
        }

        private void btnPdePermit_Click(object sender, EventArgs e)
        {
            PdeModule = "PDE";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnContacts_Click(object sender, EventArgs e)
        {
            PdeModule = "Contacts";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnTransferOwnerOperator_Click(object sender, EventArgs e)
        {
            PdeModule = "Transfer";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            PdeModule = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void chkOpenInTest_CheckedChanged(object sender, EventArgs e)
        {
            IsTest = chkOpenInTest.Checked;
        }
    }
}
