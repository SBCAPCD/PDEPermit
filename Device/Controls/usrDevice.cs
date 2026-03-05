using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SbcapcdOrg.PdePermit.Device
{
    public partial class usrDevice : SbcapcdOrg.ControlLibrary.usrUserControl
	{

		protected SortedList slNavigate = new SortedList();
		protected DataTable dtDeviceList;
		protected DataTable dtPermitsWithDevice;
		protected object oBusyDeviceNo;
		protected object oBusyPermitNo;
		protected string PermitNo = "00";
		private SbcapcdOrg.ControlLibrary.UserRoles PdePermitUserRoles;

		public usrDevice()
		{
			InitializeComponent();
			//InitializeDevice();
		}

		public usrDevice(SbcapcdOrg.ControlLibrary.UserRoles pdePermitUserRoles)
		{
			PdePermitUserRoles = pdePermitUserRoles;
			InitializeComponent();
			InitializeDevice();
		}

		public void InitializeDevice()
		{
			trvDevices.PathSeparator = " ::: ";
			dtPermitsWithDevice = dsDevice.DeviceList.Clone();
			bsPermitsWithDevice.DataSource = dtPermitsWithDevice;
			lbxPermitsWithDevice.DisplayMember = "Permit";
			lbxPermitsWithDevice.ValueMember = "PermitNo";
			dtDeviceList = SbcapcdOrg.PdePermit.Device.DeviceBL.CreatedtDeviceList();
			bsNavigate.DataSource = dtDeviceList;
			bsSourceFaciltiyPermit.Filter = "PermitNo = ''";
			bwLoadDevice.RunWorkerAsync();
		}

		public void LoadByDevice(string deviceNo)
		{
			SbcapcdOrg.PdePermit.Device.DeviceBL getDeviceList = new DeviceBL();
			getDeviceList.GetDeviceList(base.usrConnectionString, dsDevice, deviceNo);
		}

		public void SetPermit(string permitNo)
		{
			if (permitNo.Length > 4)
			{
				bsDeviceList.Position = 0;
				PermitNo = permitNo;
				bsSourceFaciltiyPermit.Filter = "PermitNo = '" + PermitNo + "'";
				DataRowView drv = bsSourceFaciltiyPermit.Current as DataRowView;
				if (drv != null)
				{
					tslblSourceFaciltiyPermit.Text = "Devices on " + drv["Permit"].ToString(); // + drv["StationarySourceName"].ToString() + " :: " + drv["FacilityName"].ToString() + " :: "
				}
				trvDevices.Nodes.Clear();
				slNavigate.Clear();
				FillNavigation(PermitNo);
				bsNavigate.MoveLast();
				bsNavigate.MoveFirst();
				SetPermitTimer(false, permitNo);
				trvDevices.ExpandAll();
			}
		}

		public void SetPermitTimer(bool start, string permitNo)
		{
			if (start)
			{
				tsbtnStopTimer.Visible = true;
				timer1.Start();
			}
			else if (PermitNo == permitNo)
			{
				timer1.Stop();
				tsbtnStopTimer.Visible = false;
			}
			else
			{
				tsbtnStopTimer.Visible = true;
				timer1.Start();
			}
		}

		private void bsNavigate_CurrentChanged(object sender, EventArgs e)
		{
			DataRowView drv = bsNavigate.Current as DataRowView;
			if (drv != null)
			{
				//if (!bwFillNavigation.IsBusy)
				
				GoToDevice(drv["PermitNoDeviceNo"]);
				
			}
		}

		public void GoToDevice(object permitNoDeviceNo)
		{
			TreeNode[] findNodes = trvDevices.Nodes.Find(permitNoDeviceNo.ToString(), true);
			if (findNodes.Length > 0)
			{
				bsDeviceList.Position = bsDeviceList.Find("PermitNoDeviceNo", permitNoDeviceNo);
				trvDevices.SelectedNode = findNodes[0];
				txtNodePath.Text = trvDevices.SelectedNode.FullPath;
				if (bwDevice.IsBusy)
				{
					oBusyDeviceNo = permitNoDeviceNo.ToString().Substring(permitNoDeviceNo.ToString().IndexOf('~') + 1);
				}
				else
				{
					string sss = permitNoDeviceNo.ToString().Substring(permitNoDeviceNo.ToString().IndexOf('~') + 1);
					bwDevice.RunWorkerAsync(permitNoDeviceNo.ToString().Substring(permitNoDeviceNo.ToString().IndexOf('~') + 1));
				}
			}
			else if (trvDevices.Nodes.Find(PermitNo + '~' + permitNoDeviceNo.ToString(), true).Length > 0)
			{
				string PermitNoDeviceNo = PermitNo + '~' + permitNoDeviceNo.ToString();
				findNodes = trvDevices.Nodes.Find(PermitNoDeviceNo, true);

				bsDeviceList.Position = bsDeviceList.Find("PermitNoDeviceNo", PermitNoDeviceNo);
				trvDevices.SelectedNode = findNodes[0];
				txtNodePath.Text = trvDevices.SelectedNode.FullPath;
				if (bwDevice.IsBusy)
				{
					oBusyDeviceNo = PermitNoDeviceNo.ToString().Substring(PermitNoDeviceNo.ToString().IndexOf('~') + 1);
				}
				else
				{
					string sss = permitNoDeviceNo.ToString().Substring(PermitNoDeviceNo.ToString().IndexOf('~') + 1);
					bwDevice.RunWorkerAsync(PermitNoDeviceNo.ToString().Substring(PermitNoDeviceNo.ToString().IndexOf('~') + 1));
				}
			}
			else
			{
				if (MessageBox.Show("DeviceNo " + tstxtDeviceNo.Text + " not in current list. Do you want to search all devices?", "Find Device", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{

					bsNavigate.SuspendBinding();
					SbcapcdOrg.PdePermit.Device.DeviceBL fillFlatNavigation = new DeviceBL();
					fillFlatNavigation.FillFlatNavigation(dsDevice, trvDevices, tstxtDeviceNo.Text, slNavigate, dtDeviceList); // deviceNo.ToString()
					bsNavigate.ResumeBinding();
				}
			}
		}

		public void FilterByDeviceNo(string deviceNo)
		{
			try
			{
				if (deviceNo == "000000" || deviceNo == null)
				{
					bsDeviceList.Filter = "DeviceNo = 'x'";
					if (dtDeviceList != null)
					{
						trvDevices.Nodes.Clear();
						dtDeviceList.Clear();
					}
					tstxtPermitNumber.Text = "";
					txtNodePath.Text = "";
					if (dtPermitsWithDevice != null)
					{
						dtPermitsWithDevice.Clear();
					}
				}
				else
				{
					SbcapcdOrg.PdePermit.Device.DeviceBL fillFlatNavigation = new DeviceBL();
					fillFlatNavigation.FillFlatNavigation(dsDevice, trvDevices, deviceNo, slNavigate, dtDeviceList); // deviceNo.ToString()
					bsDeviceList.Filter = "DeviceNo = '" + deviceNo + "'";
				}

			}
			catch (Exception ex)
			{
				SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);	
			}
			finally
			{
			}
		}

		#region Fill lbxPermitsWithDevice

		public virtual void FillLbxPermitsWithDevice(object deviceNo, BackgroundWorker worker, DoWorkEventArgs e)
		{
			SbcapcdOrg.PdePermit.Device.DeviceBL.FillDtPermitsWithDevice(deviceNo, dtPermitsWithDevice, dsDevice.DeviceList);
		}

		private void bwDevice_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			FillLbxPermitsWithDevice(e.Argument, worker, e);
		}

		private void bwDevice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message);
			}
			else if (e.Cancelled)
			{
			}
			else
			{
				lbxPermitsWithDevice.Refresh();
				lbxPermitsWithDevice.ClearSelected();
				lbxPermitsWithDevice.ClearSelected();
			}
		}

		#endregion

		private void trvDevices_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			int zNodeLevel = e.Node.Level + 1;
			if (!(e.X < zNodeLevel * trvDevices.Indent))
			{
				PermitNo = e.Node.Tag.ToString().Substring(0, e.Node.Tag.ToString().IndexOf('~'));
				bsNavigate.Position = bsNavigate.Find("PermitNoDeviceNo", e.Node.Name);
			}
		}

		private void tsbtnExpandTree_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = trvDevices.SelectedNode;
			trvDevices.ExpandAll();
			trvDevices.SelectedNode = selectedNode;
		}

		private void tsbtnColapseTree_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = trvDevices.SelectedNode;
			trvDevices.CollapseAll();
			trvDevices.SelectedNode = selectedNode;
		}

		private void tsBtnGoToDevice_Click(object sender, EventArgs e)
		{
			timer1.Stop();
			tsbtnStopTimer.Visible = false;
			GoToDevice(tstxtDeviceNo.Text);
		}

		#region LoadDevice

		private void LoadDevice(BackgroundWorker worker, DoWorkEventArgs e)
		{
			SbcapcdOrg.PdePermit.Device.DeviceBL getDeviceList = new DeviceBL();
            getDeviceList.GetDeviceList(base.usrConnectionString, dsDevice);
			e.Result = e.Argument;
		}

		private void bwLoadDevice_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			LoadDevice(worker, e);
		}

		private void bwLoadDevice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message);
			}
			else if (e.Cancelled)
			{
			}
			else
			{
				if (e.Result != this.oBusyDeviceNo)
				{
					bwDevice.RunWorkerAsync(oBusyDeviceNo);
				}
				else
				{
					bsDeviceList.Position = 0;
				}
			}
		}

		#endregion

		#region Fill Navigation

		protected void FillNavigation(object permitNo)
		{
			SbcapcdOrg.PdePermit.Device.DeviceBL fillNavigation = new DeviceBL();
			fillNavigation.FillNavigation(dsDevice, trvDevices, permitNo.ToString(), slNavigate, dtDeviceList);
		}

		protected void FillNavigation(object permitNo, BackgroundWorker worker, DoWorkEventArgs e)
		{
			SbcapcdOrg.PdePermit.Device.DeviceBL fillNavigation = new DeviceBL();
			fillNavigation.FillNavigation(dsDevice, trvDevices, permitNo.ToString(), slNavigate, dtDeviceList);
			e.Result = e.Argument;
		}

		private void bwFillNavigation_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			FillNavigation(PermitNo, worker, e);
		}

		private void bwFillNavigation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message);
			}
			else if (e.Cancelled)
			{
			}
			else
			{
				if (e.Result != oBusyPermitNo)
				{
					bwFillNavigation.RunWorkerAsync(oBusyPermitNo);
				}
				else
				{
					string sss = e.Result.ToString();
				}
			}
			//trvDevices.ExpandAll();
			//bsDeviceList.MoveFirst();
		}

		#endregion

		private void bsNavigate_DataSourceChanged(object sender, EventArgs e)
		{
			trvDevices.ExpandAll();
			bsDeviceList.MoveFirst();
		}

		private void lbxPermitsWithDevice_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if (lbxPermitsWithDevice.SelectedIndex > -1)
			
			//  lbxPermitsWithDevice.ClearSelected();
			
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			tslblSourceFaciltiyPermit.Visible = !tslblSourceFaciltiyPermit.Visible;
		}

		private void tsbtnGetPermits_Click(object sender, EventArgs e)
		{
			SbcapcdOrg.PdePermit.Device.DeviceBL getPermits = new DeviceBL();
            getPermits.GetPermitNo(base.usrConnectionString, tstxtPermitNumber.Text, tscmbPermitList.ComboBox);
		}

		private void tscmbPermitList_SelectedIndexChanged(object sender, EventArgs e)
		{
			timer1.Stop();
			tsbtnStopTimer.Visible = false;
			SetPermit(((DataRowView)tscmbPermitList.SelectedItem)["PermitNo"].ToString());
		}

		private void lbxPermitsWithDevice_DoubleClick(object sender, EventArgs e)
		{
			DataRowView drv = lbxPermitsWithDevice.SelectedItem as DataRowView;
			if (drv != null && drv.Row.RowState != DataRowState.Detached)
			{
				SetPermit(drv["PermitNo"].ToString());
			}
		}

		private void tsbtnStopTimer_Click(object sender, EventArgs e)
		{
			timer1.Stop();
			tsbtnStopTimer.Visible = false;
			tslblSourceFaciltiyPermit.Visible = true;
		}

	}

	//public static class ConString
	
	//  private static string connectionString = "";

	//  public static string ConnectionString
	//  {
	//    get { return connectionString; }
	//    set { connectionString = value; }
	//  }
	
}
