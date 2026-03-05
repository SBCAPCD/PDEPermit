using System;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using SbcapcdOrg.PdePermit.PdePermitComponents;
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PdePermit.Permit
{
  class PermitBL
  {

    public DbTransaction GetTransaction(string conString)
    {
      try
      {
        SbcapcdOrg.PdePermit.Permit.PermitDL getTransaction = new PermitDL();
        return getTransaction.GetTransaction(conString);
      }
      catch
      {
        return null;
      }
      finally
      {
      }
    }

    public static int GetPdeNewId(string conString)
    {
      try
      {
        return SbcapcdOrg.PdePermit.PdePermitComponents.CommonDL.GetPdeNewId(conString);
      }
      catch
      {
        return 0;
      }
      finally
      {
      }
    }

	public static string GetNovsByPermitNo(string conString, object permitNo)
	{
		try
		{
			return SbcapcdOrg.PdePermit.Permit.PermitDL.GetNovsByPermitNo(conString, permitNo);
		}
		catch (Exception ex)
		{
			SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "GetNovsByPermitNo");
			return "";
		}
	}

    public bool GetPermit(string conString, DataSet dsPermit)
    {
      try
      {
        dsPermit.Clear();
        SbcapcdOrg.PdePermit.Permit.PermitDL getPermit = new PermitDL();
        return getPermit.GetPermit(conString, dsPermit);
      }
      catch
      {
        return false;
      }
      finally
      {
      }
    }

    public string GetPermitToEdit(string conString, DataSet dsPermit, string permitNo)
    {
      try
      {
        SbcapcdOrg.PdePermit.Permit.PermitDL getPermitToEdit = new PermitDL();
        return getPermitToEdit.GetPermitToEdit(conString, dsPermit, permitNo);
      }
      catch
      {
        return "Error";
      }
      finally
      {
      }
    }

    public bool GetPermitRefresh(string conString, DataSet dsPermit, string permitNo)
    {
      try
      {
        SbcapcdOrg.PdePermit.Permit.PermitDL getPermitToEdit = new PermitDL();
        return getPermitToEdit.GetPermitRefresh(conString, dsPermit, permitNo);
      }
      catch
      {
        return false;
      }
      finally
      {
      }
    }

    public static bool SetIsPermitCheckedOutForEditFalse(string conString, string permitNo)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.SetIsPermitCheckedOutForEditFalse(conString, permitNo);
      }
      catch
      {
        return false;
      }
      finally
      {
      }
    }

    public bool GetReevalDue(string conString, DataSet dsReevalDueAdmin, int reevalAssignmentLabelId)
    {
      try
      {
        dsReevalDueAdmin.Tables["Employee"].Clear();
        dsReevalDueAdmin.Tables["PermitReevalDue"].Clear();
        SbcapcdOrg.PdePermit.Permit.PermitDL getReevalDue = new PermitDL();
        return getReevalDue.GetReevalDue(conString, dsReevalDueAdmin, reevalAssignmentLabelId);
      }
      catch
      {
        return false;
      }
      finally
      {
      }
    }

    public bool GetReevalAssignmentLabel(string conString, DataSet dsReevalDueAdmin)
    {
      try
      {
        dsReevalDueAdmin.Tables["ReevalAssignmentLabel"].Clear();
        SbcapcdOrg.PdePermit.Permit.PermitDL getReevalAssignmentLabel = new PermitDL();
        return getReevalAssignmentLabel.GetReevalAssignmentLabel(conString, dsReevalDueAdmin);


      }
      catch
      {
        return false;
      }
      finally
      {
      }
    }

    public bool SavePermit(string conString, string permitEditStatus, DataSet dsPermit, DbTransaction transaction)
    {
      try
      {
        SbcapcdOrg.PdePermit.Permit.PermitDL savePermit = new PermitDL();

        return savePermit.SavePermit(conString, permitEditStatus, dsPermit, transaction);
      }
      catch
      {
        return false;
      }
      finally
      {
      }
    }

    public static bool DeletePermit(string conString, string permitNo)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.DeletePermit(conString, permitNo);
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return false;
      }
    }

    public bool UpdatePermitStatus(string conString, string permitNo, string permitStatus, DbTransaction transaction)
    {
      try
      {
        SbcapcdOrg.PdePermit.Permit.PermitDL updatePermitStatus = new PermitDL();
        return updatePermitStatus.UpdatePermitStatus(conString, permitNo, permitStatus, transaction);
      }
      catch
      {
        return false;
      }
      finally
      {
      }
    }

    public bool SavePermitReevalDue(string conString, DataSet dsReevalDueAdmin)
    {
      try
      {
        SbcapcdOrg.PdePermit.Permit.PermitDL savePermitReevalDue = new PermitDL();
        return savePermitReevalDue.SavePermitReevalDue(conString, dsReevalDueAdmin);
      }
      catch
      {
        return false;
      }
      finally
      {
      }
    }

    public bool SavePermitSupersedeTransaction(string conString, DataSet dsPermit, string permitNo, string supersededPermitNo, bool supersededPermitIsMappingPermit)
    {
      try
      {
        SbcapcdOrg.PdePermit.Permit.PermitDL savePermitSupersedeTransaction = new PermitDL();
        return savePermitSupersedeTransaction.SavePermitSupersedeTransaction(conString, dsPermit, permitNo, supersededPermitNo, supersededPermitIsMappingPermit);
      }
      catch
      {
        return false;
      }
      finally
      {
      }
    }

    public bool GetPermitAux(string conString, DataSet dsPermitAux)
    {
      try
      {
        dsPermitAux.Clear();
        SbcapcdOrg.PdePermit.Permit.PermitDL getPermitAux = new PermitDL();
        return getPermitAux.GetPermitAux(conString, dsPermitAux);


      }
      catch
      {
        return false;
      }
      finally
      {
      }
    }

    public bool GetPdePermitSupersedeAux(string conString, DataSet dsPermitAux)
    {
      try
      {
        SbcapcdOrg.PdePermit.Permit.PermitDL getPermitSupersedeAux = new PermitDL();
        return getPermitSupersedeAux.GetPdePermitSupersedeAux(conString, dsPermitAux);
      }
      catch
      {
        return false;
      }
      finally
      {
      }
    }

    public static bool EmailRoutingSlip(string conString, string permitNo)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.EmailRoutingSlip(conString, permitNo);
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return false;
      }
      finally
      {
      }
    }

    public static bool EmailCompletenessRoutingSlip(string conString, string permitNo)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.EmailCompletenessRoutingSlip(conString, permitNo);
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);

        return false;
      }
      finally
      {
      }
    }

    public static bool AddAnnualReportTracking(string conString, string permitNo)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.AddAnnualReportTracking(conString, permitNo);
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);

        return false;
      }
      finally
      {
      }
    }

    public static string GetNewPermitNo(string conString)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.GetNewPermitNo(conString);
      }
      catch
      {
        return null;
      }
      finally
      {
      }
    }

    public static bool? GetCompletenessAssigned(string conString, string permitNo)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.GetCompletenessAssigned(conString, permitNo);
      }
      catch
      {
        return null;
      }
      finally
      {
      }
    }

    public static string GetNewPermitNumber(string conString)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.GetNewPermitNumber(conString);
      }
      catch
      {
        return null;
      }
      finally
      {
      }
    }

    public static string GetCompletenessEngineer(string conString, string permitNo)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.GetCompletenessEngineer(conString, permitNo);
      }
      catch
      {
        return null;
      }
      finally
      {
      }
    }

    public static string GetPermitBillingCompanyByPermit(string conString, string permitNo)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.GetPermitBillingCompanyByPermit(conString, permitNo);
      }
      catch
      {
        return null;
      }
      finally
      {
      }
    }

    public static string GetPermitBillingCompanyByFacility(string conString, string facilityNo)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.GetPermitBillingCompanyByFacility(conString, facilityNo);
      }
      catch
      {
        return null;
      }
      finally
      {
      }
    }

    public static string Bill(string conString, int permitFeeHistoryId, string permitNo, string projectNo, string companyNo, string invoiceAmount, string invoiceDesc, string prepaid, int permitFeeActionId, object permitFeeDate)
    {
      try
      {
        string BillingContactCompanyNo = SbcapcdOrg.PdePermit.Permit.PermitDL.GetBillingContactCompanyNo(conString, permitNo);

        if (BillingContactCompanyNo == "xxx")
        {
          MessageBox.Show("Get Billing Contact CompanyNo - not one company", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return null;
        }

        string InvoiceDate = null;
        if (prepaid == "True")
        {
          prepaid = "Y";
          InvoiceDate = String.Format("{0:dd MMM yyyy}", System.Convert.ToDateTime(permitFeeDate));
        }
        else
        {
          prepaid = "N";
          InvoiceDate = String.Format("{0:dd MMM yyyy}", System.DateTime.Today);
        }

        SbcapcdOrg.PdePermit.Permit.PermitDL billPdeApplicationFee = new PermitDL();
        string TransNo = billPdeApplicationFee.BillPdeApplicationFee(conString, permitNo, projectNo, BillingContactCompanyNo, invoiceAmount, invoiceDesc, prepaid, InvoiceDate);

        if (TransNo != null)
        {
          SbcapcdOrg.PdePermit.Permit.PermitDL updatePermitFeeHistory = new PermitDL();
          if (updatePermitFeeHistory.UpdatePermitFeeHistory(conString, permitFeeHistoryId, InvoiceDate, true, TransNo))
          {
            return TransNo;
          }
          else
          {
            return null;
          }
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);

        return null;
      }
      finally
      {
      }
    }

    public static bool GetIsMappingPermit(string conString, string permitNo)
    {
      try
      {
        return SbcapcdOrg.PdePermit.Permit.PermitDL.GetIsMappingPermit(conString, permitNo);
      }
      catch (Exception ex)
      {
        SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
        return false;
      }
      finally
      {
      }
    }



        public static bool GetFacilityPermitApplicationMapData(string conString, DataSet dsFacilityPermitsMapData)
        {
            try
            {
                dsFacilityPermitsMapData.Clear();
                return SbcapcdOrg.PdePermit.Permit.PermitDL.GetFacilityPermitApplicationMapData(conString, dsFacilityPermitsMapData);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public static bool GetFacilityFinalPermitMapData(string conString, DataSet dsFacilityPermitsMapData)
        {
            try
            {
                dsFacilityPermitsMapData.Clear();
                return SbcapcdOrg.PdePermit.Permit.PermitDL.GetFacilityFinalPermitMapData(conString, dsFacilityPermitsMapData);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }
    }
}
