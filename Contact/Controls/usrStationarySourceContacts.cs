using SbcapcdOrg.ControlLibrary;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SbcapcdOrg.Contact
{
    public partial class usrStationarySourceContacts : SbcapcdOrg.ControlLibrary.usrUserControl
    {
        public bool DataSetHasChanges { get; set; }

        public usrStationarySourceContacts()
        {
            InitializeComponent();
            bnStationarySource.Renderer = new MyRenderer();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                var btn = e.Item as ToolStripButton;
                if (btn != null && btn.CheckOnClick && btn.Checked)
                {
                    Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(Brushes.Tomato, bounds);
                }
                else base.OnRenderButtonBackground(e);
            }
        }

        public void LoadStationarySourceContacts()
        {
            SbcapcdOrg.Contact.ContactBL getStationarySourceContacts = new ContactBL();
            getStationarySourceContacts.GetStationarySourceContacts(base.usrConnectionString, dsStationarySourceContacts);

            dsStationarySourceContacts.StationarySourceContacts.ColumnChanged += new DataColumnChangeEventHandler(StationarySourceContacts_ColumnChanged);

        }

        void StationarySourceContacts_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            CheckForUnsavedChanges(e);
        }

        protected void CheckForUnsavedChanges(DataColumnChangeEventArgs e)
        {
            bool checkForChanges = CommonMethods.CheckForChanges(DataSetHasChanges, e);
            if (DataSetHasChanges != checkForChanges)
            {
                DataSetHasChanges = checkForChanges;
                tslblContactHasChanges.Visible = DataSetHasChanges;
            }
        }

        private void bsStationarySourceContacts_CurrentChanged(object sender, EventArgs e)
        {
            DataRowView drv = bsStationarySourceContacts.Current as DataRowView;
            if (drv != null)
            {
                bsStationarySourceBillingContacts.Filter = "ContactTypeId = 21 AND (StationarySourceNo = '" + drv["StationarySourceNo"].ToString() + "' OR StationarySourceNo = '0')";
                bsStationarySourceCorrContacts.Filter = "ContactTypeId = 14 AND (StationarySourceNo = '" + drv["StationarySourceNo"].ToString() + "' OR StationarySourceNo = '0')";

                cmbBillingContactId.SelectedValue = drv["BillingContactId"];
                cmbCorrespondenceContactId.SelectedValue = drv["CorrespondenceContactId"]; ;
            }
        }

        private void tsbtnSaveContact_Click(object sender, EventArgs e)
        {
            //bsStationarySourceContacts.MoveNext();
            bsStationarySourceContacts.EndEdit();
            SbcapcdOrg.Contact.ContactBL saveStationarySourceContacts = new ContactBL();

            if (saveStationarySourceContacts.SaveStationarySourceContacts(base.usrConnectionString, dsStationarySourceContacts.GetChanges()))
            {
                dsStationarySourceContacts.AcceptChanges();
                DataSetHasChanges = false;
                tslblContactHasChanges.Visible = DataSetHasChanges;
                //return true;
            }
            else
            {
                MessageBox.Show("Error Saving.");
                //return false;
            }
        }

        private void cmbBillingContactId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow drv = dsStationarySourceContacts.StationarySourceContacts.Rows.Find(((DataRowView)bsStationarySourceCorrContacts.Current)["StationarySourceNo"].ToString());
            if (drv != null && cmbBillingContactId.SelectedIndex > -1)
            {
                drv["BillingContactId"] = cmbBillingContactId.SelectedValue;
            }
        }

        private void cmbCorrespondenceContactId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow drv = dsStationarySourceContacts.StationarySourceContacts.Rows.Find(((DataRowView)bsStationarySourceCorrContacts.Current)["StationarySourceNo"].ToString());
            if (drv != null && cmbCorrespondenceContactId.SelectedIndex > -1)
            {
                drv["CorrespondenceContactId"] = cmbCorrespondenceContactId.SelectedValue;
            }
        }

        private void tsbtnUndoStationarySourceContacts_Click(object sender, EventArgs e)
        {
            dsStationarySourceContacts.RejectChanges();
            DataSetHasChanges = false;
            tslblContactHasChanges.Visible = DataSetHasChanges;
        }

        private void tstxtFilterSources_TextChanged(object sender, EventArgs e)
        {
            FilterSource();
        }

        private void FilterSource()
        {

            if (tstxtFilterSources.Text.Length < 1 && !tsbtnFilterSourceNulls.Checked)
            {
                bsStationarySourceContacts.RemoveFilter();
            }
            else if (tstxtFilterSources.Text.Length < 1 && tsbtnFilterSourceNulls.Checked)
            {
                bsStationarySourceContacts.Filter = "(BillingContactId Is Null OR CorrespondenceContactId Is Null)";
            }
            else if (tstxtFilterSources.Text.Length > 0 && tsbtnFilterSourceNulls.Checked)
            {
                bsStationarySourceContacts.Filter = "(BillingContactId Is Null OR CorrespondenceContactId Is Null) AND (StationarySourceNo LIKE '*" + tstxtFilterSources.Text + "*' OR StationarySourceName LIKE '*" + tstxtFilterSources.Text + "*')";
            }
            else
            {
                bsStationarySourceContacts.Filter = "(StationarySourceNo LIKE '*" + tstxtFilterSources.Text + "*' OR StationarySourceName LIKE '*" + tstxtFilterSources.Text + "*')";
            }
        }

        private void tsbtnFilterSourceNulls_Click(object sender, EventArgs e)
        {
            FilterSource();
        }

        private void btnUpdateBillingContacts_Click(object sender, EventArgs e)
        {
            this.Parent.Cursor = Cursors.WaitCursor;
            SbcapcdOrg.Contact.ContactBL.UpdatePdeStationarySourceSingleBillingContact(base.usrConnectionString);
            SbcapcdOrg.Contact.ContactBL getStationarySourceContacts = new ContactBL();
            getStationarySourceContacts.GetStationarySourceContacts(base.usrConnectionString, dsStationarySourceContacts);
            this.Parent.Cursor = Cursors.Default;
        }
    }
}
