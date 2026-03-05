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


namespace SbcapcdOrg.PdePermit.Forms
{
    public partial class frmTransOo : SbcapcdOrg.ControlLibrary.frmChildForm
    {
        public frmTransOo()
        {
            InitializeComponent();
            this.ShowIcon = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void frmTransOo_Shown(object sender, EventArgs e)
        {
            this.Parent.Cursor = Cursors.Default;
        }

        private void usrTransOo_ConString(object sender)
        {
            usrTransOo.LoadTransOo();
        }
    }
}
