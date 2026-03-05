using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using SbcapcdOrg.ControlLibrary;
using SbcapcdOrg.PDEPermit;


namespace SbcapcdOrg.PdePermit.Forms
{
  public partial class MdiPdePermit : SbcapcdOrg.ControlLibrary.frmMdiForm
  {
    public MenuItem menuItem;
    private string assemblyName = Assembly.GetExecutingAssembly().FullName;
    //SbcapcdOrg.ControlLibrary.UserRoles PdePermitRoles;
    //SbcapcdOrg.ControlLibrary.UserRoles PdePermitRoles = new SbcapcdOrg.ControlLibrary.UserRoles("PdePermit");
	private SbcapcdOrg.PdePermit.PdePermitComponents.UserRoles PdeUserRoles = null;
    private bool HasTypeChild = false;
    private Form FoundForm = null;

    private string pdeModule { get; set; }

        public MdiPdePermit()
    {
      InitializeComponent();
      toolsMenu.DropDownItems.Add("PDEPermit", imageList1.Images[0], new EventHandler(PDEPermit_Clicked));
      toolsMenu.DropDownItems.Add("Contact", imageList1.Images[1], new EventHandler(Contact_Clicked));
      toolsMenu.DropDownItems.Add("Transfer Owner/Operator", imageList1.Images[2], new EventHandler(TransOo_Clicked));
	  helpMenu.DropDownItems.Remove(aboutToolStripMenuItem);
	  //helpMenu.DropDownItems.RemoveAt(3);

	  helpMenu.DropDownItems.Add("About", null, new EventHandler(About_Clicked));

      tscmbConnectionString.ComboBox.BindingContext = this.BindingContext;
	  //PdePermitRoles = base.PdePermitRoles;
	//base.PdePermitRoles = PdePermitRoles = new SbcapcdOrg.PdePermit.PdePermitComponents.UserRoles(base.GetConnectionString());
	  

    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
	  PdeUserRoles = new PdePermitComponents.UserRoles(base.GetConnectionString());
    }

	protected void About_Clicked(object sender, System.EventArgs e)
	{

		SbcapcdOrg.PdePermit.Forms.usrAboutBox aboutBox = new SbcapcdOrg.PdePermit.Forms.usrAboutBox();
		aboutBox.MdiParent = this;
		aboutBox.Show();
		//aboutBox.WindowState = FormWindowState.Normal;
	}

	//protected override void aboutToolStripMenuItem_Click(object sender, EventArgs e)
	//{
	//	//SbcapcdOrg.Forms.AboutBox aboutBox = new SbcapcdOrg.Forms.AboutBox();
	//	//aboutBox.MdiParent = this;
	//	//aboutBox.Show();
	//	//aboutBox.WindowState = FormWindowState.Normal;
	//}

    protected void PDEPermit_Clicked(object sender, System.EventArgs e)
    {
      FoundForm = null;
      HasTypeChild = false;

      foreach (Form aForm in this.MdiChildren)
      {
        if (aForm.GetType() == typeof(SbcapcdOrg.PdePermit.Forms.PDEPermit))
        {
          HasTypeChild = true;
          FoundForm = aForm;
        }
      }

      if (HasTypeChild)
      {
        DialogResult result = MessageBox.Show("A PDEPermit form is already open. Do you want to open another one?", "PDEPermit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
          EditPDEPermit();
        }
        else
        {
          if (FoundForm != null)
          {
            FoundForm.Activate();
          }
        }
      }
      else
      {
        EditPDEPermit();
      }


    }

    protected void Contact_Clicked(object sender, System.EventArgs e)
    {
      FoundForm = null;
      HasTypeChild = false;

      foreach (Form aForm in this.MdiChildren)
      {
        if (aForm.GetType() == typeof(SbcapcdOrg.PdePermit.Forms.frmContact))
        {
          HasTypeChild = true;
          FoundForm = aForm;
        }
      }

      if (HasTypeChild)
      {
        DialogResult result = MessageBox.Show("A Contact form is already open. Do you want to open another one?", "Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
          EditContact();
        }
        else
        {
          if (FoundForm != null)
          {
            FoundForm.Activate();
          }
        }
      }
      else
      {
        EditContact();
      }

    }

    protected void TransOo_Clicked(object sender, System.EventArgs e)
    {
      FoundForm = null;
      HasTypeChild = false;

      foreach (Form aForm in this.MdiChildren)
      {
        if (aForm.GetType() == typeof(SbcapcdOrg.PdePermit.Forms.frmTransOo))
        {
          HasTypeChild = true;
          FoundForm = aForm;
        }
      }

      if (HasTypeChild)
      {
        DialogResult result = MessageBox.Show("A Transfer Owner/Operator form is already open. Do you want to open another one?", "Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
          EditTransOo();
        }
        else
        {
          if (FoundForm != null)
          {
            FoundForm.Activate();
          }
        }
      }
      else
      {
        EditTransOo();
      }

    }

        public void EditPDEPermit()
        {
            try
            {
                if (assemblyName.IndexOf("Test") >= 0)
                {
                    this.Cursor = Cursors.AppStarting;
                    SbcapcdOrg.PdePermit.Forms.PDEPermit doc = new PDEPermit();

                    tscmbConnectionString.SelectedIndex = 1;
                    drvConnectionString = (DataRowView)tscmbConnectionString.SelectedItem;

                    doc.SetForm(drvConnectionString, "PDE Permit Test");
                    doc.MdiParent = this;
                    doc.Show();
                    doc.ShowIcon = true;
                    doc.WindowState = FormWindowState.Maximized;
                    Application.DoEvents();
                    this.Cursor = Cursors.Default;
                }

                else
                {
                    this.Cursor = Cursors.AppStarting;

                    SbcapcdOrg.PdePermit.Forms.PDEPermit doc = new PDEPermit();
                    doc.SetForm(base.drvConnectionString, "PDE Permit");
                    doc.MdiParent = this;
                    doc.Show();
                    doc.ShowIcon = true;
                    //doc.ShowIcon = false;
                    doc.WindowState = FormWindowState.Maximized;
                    Application.DoEvents();
                    doc.ShowIcon = true;
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Permit:EditPDEPermit");
            }
        }

    public void EditContact()
    {
      try
      {
                if (assemblyName.IndexOf("Test") >= 0)
                {
                    this.Cursor = Cursors.AppStarting;
                    SbcapcdOrg.PdePermit.Forms.frmContact doc = new frmContact();

                    tscmbConnectionString.SelectedIndex = 1;
                    drvConnectionString = (DataRowView)tscmbConnectionString.SelectedItem;

                    doc.SetForm(drvConnectionString, "Contact Test");
                    doc.MdiParent = this;
                    doc.Show();
                    doc.ShowIcon = true;
                    doc.WindowState = FormWindowState.Maximized;
                    Application.DoEvents();

                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.AppStarting;

                    SbcapcdOrg.PdePermit.Forms.frmContact doc = new frmContact();
                    doc.SetForm(base.drvConnectionString, "Contact");
                    doc.MdiParent = this;
                    doc.Show();
                    doc.ShowIcon = true;
                    doc.WindowState = FormWindowState.Maximized;
                    Application.DoEvents();
                    doc.ShowIcon = true;
                    this.Cursor = Cursors.Default;
                }
            }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Permit:EditContact");
      }
    }

    public void EditTransOo()
    {
      try
      {
		  if (assemblyName.IndexOf("Test") >= 0)
		  {
			  this.Cursor = Cursors.AppStarting;
			  SbcapcdOrg.PdePermit.Forms.frmTransOo doc = new frmTransOo();

			  tscmbConnectionString.SelectedIndex = 1;
			  drvConnectionString = (DataRowView)tscmbConnectionString.SelectedItem;

			  doc.SetForm(drvConnectionString, "Transfer Owner/Operator Test");
			  doc.MdiParent = this;
			  doc.Show();
			  doc.ShowIcon = true;
			  doc.WindowState = FormWindowState.Maximized;
			  Application.DoEvents();

			  this.Cursor = Cursors.Default;
		  }
		  else
		  {
			  this.Cursor = Cursors.AppStarting;

			  SbcapcdOrg.PdePermit.Forms.frmTransOo doc = new frmTransOo();
			  doc.SetForm(base.drvConnectionString, "Transfer Owner/Operator");
			  doc.MdiParent = this;
			  doc.Show();
			  doc.ShowIcon = true;
			  doc.WindowState = FormWindowState.Maximized;
			  Application.DoEvents();
			  doc.ShowIcon = true;
			  this.Cursor = Cursors.Default;
		  }
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Permit:EditTransOo");
      }
    }

        private void SetTest()
        {
            this.tscmbConnectionString.SelectedIndex = 1;

            drvConnectionString = (DataRowView)tscmbConnectionString.SelectedItem;
        }

        private void MdiPdePermit_Shown(object sender, EventArgs e)
    {
            //EditPDEPermit();
            //EditTransOo();
            //EditContact();


            SbcapcdOrg.PdePermit.frmOpen frm = new PdePermit.frmOpen();
            DialogResult res = frm.ShowDialog();

            if (res == DialogResult.OK)
            {
                pdeModule = frm.PdeModule;

                if (frm.IsTest)
                {
                    SetTest();
                }

                switch (pdeModule)
                {
                    case "PDE":
                        EditPDEPermit(); 
                        break;
                    case "Contacts":
                        EditContact();
                        break;
                    case "Transfer":
                        EditTransOo();
                        break;
                    default:
                        break;
                }
            }
        }

    private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      string stTest = SbcapcdOrg.PdePermit.PdePermitComponents.CommonPdePermitMethods.GetGroupMembers();

      MessageBox.Show(stTest);

      //SbcapcdOrg.Forms aboutBox = new 
      //SbcapcdOrg.Forms. aboutBox = new SbcapcdOrg.Forms;
      //aboutBox.MdiParent = this;
      //aboutBox.Show();
      //aboutBox.WindowState = FormWindowState.Normal;
    }
  }
}
