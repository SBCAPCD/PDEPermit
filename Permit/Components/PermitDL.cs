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
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;


using SbcapcdOrg.PdePermit.PdePermitComponents;
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PdePermit.Permit
{
    class PermitDL
    {
        public DbTransaction GetTransaction(string conString)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                DbConnection connection = db.CreateConnection();
                connection.Open();
                DbTransaction Transaction = connection.BeginTransaction();
                return Transaction;
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

        public bool GetPermit(string conString, DataSet dsPermit)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                db.LoadDataSet(CommandType.StoredProcedure, "GetPdePermit11", dsPermit, new string[] { "Permit", "PermitActionHistory", "PermitFeeHistory", "PermitEmissions", "PermitProject", "PermitSupersede", "PermitException" });

                return true;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public string GetPermitToEdit(string conString, DataSet dsPermit, string permitNo)
        {
            bool IsCheckedOutForEdit;
            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                IsCheckedOutForEdit = (bool)db.ExecuteScalar("GetPdeIsPermitCheckedOutForEdit", new object[] { permitNo });

                if (IsCheckedOutForEdit)
                {
                    return "NonEditMode";
                }
                else
                {
                    db.LoadDataSet("GetPdePermitToEdit", dsPermit, new string[] { "Permit" }, new object[] { permitNo });
                    return "EditMode";
                }

            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
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
                SqlDatabase db = new SqlDatabase(conString);

                db.LoadDataSet("GetPdePermitRefresh", dsPermit, new string[] { "Permit" }, new object[] { permitNo });
                return true;
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

        public static bool GetIsMappingPermit(string conString, string permitNo)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                DataSet MappingPermit = (db.ExecuteDataSet("GetPdeIsMappingPermit2", new object[] { permitNo })); ;
                return System.Convert.ToBoolean(MappingPermit);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "GetIsMappingPermit");
                return false;
            }
            finally
            {
            }
        }

        public static string GetNovsByPermitNo(string conString, object permitNo)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                return db.ExecuteScalar("GetNovsByPermitNo", new object[] { permitNo }).ToString();
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "GetNovsByPermitNo");
                return "";
            }
        }

        public static bool SetIsPermitCheckedOutForEditFalse(string conString, string permitNo)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.ExecuteNonQuery("UpdatePdeSetIsPermitCheckedOutForEditFalse", new object[] { permitNo }).ToString();
                return true;
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

        public bool SavePermit(string conString, string permitEditStatus, DataSet dsPermit, DbTransaction transaction)
        {
            if (dsPermit == null)
            {
                transaction.Commit();
                return true;
            }
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                if (permitEditStatus == "EditMode" || permitEditStatus == "New")
                {
                    db.UpdateDataSet(dsPermit, "Permit",
                      GetDbCommand(db, "AddUpdatePdePermit15"),
                      GetDbCommand(db, "AddUpdatePdePermit15"),
                      GetDbCommand(db, "DeletePdePermit"),
                      transaction);
                }

                db.UpdateDataSet(dsPermit, "PermitActionHistory",
                  GetDbCommand(db, "AddUpdatePdePermitActionHistoryV2"),
                  GetDbCommand(db, "AddUpdatePdePermitActionHistoryV2"),
                  GetDbCommand(db, "DeletePdePermitActionHistoryV2"),
                  transaction);

                db.UpdateDataSet(dsPermit, "PermitFeeHistory",
                  GetDbCommand(db, "AddUpdatePdePermitFeeHistory3"),
                  GetDbCommand(db, "AddUpdatePdePermitFeeHistory3"),
                  GetDbCommand(db, "DeletePdePermitFeeHistoryV2"),
                  transaction);

                db.UpdateDataSet(dsPermit, "PermitEmissions",
                  GetDbCommand(db, "AddUpdatePdePermitEmissions"),
                  GetDbCommand(db, "AddUpdatePdePermitEmissions"),
                  GetDbCommand(db, "DeletePdePermitEmissions"),
                  transaction);

                db.UpdateDataSet(dsPermit, "PermitProject",
                  GetDbCommand(db, "AddUpdatePdePermitProjectV2"),
                  GetDbCommand(db, "AddUpdatePdePermitProjectV2"),
                  GetDbCommand(db, "DeletePdePermitProjectV2"),
                  transaction);

                db.UpdateDataSet(dsPermit, "PermitSupersede",
                  GetDbCommand(db, "AddUpdatePdePermitSupersede"),
                  GetDbCommand(db, "AddUpdatePdePermitSupersede"),
                  GetDbCommand(db, "DeletePdePermitSupersede"),
                  transaction);

                db.UpdateDataSet(dsPermit, "PermitException",
                  GetDbCommand(db, "AddUpdatePdePermitException"),
                  GetDbCommand(db, "AddUpdatePdePermitException"),
                  GetDbCommand(db, "DeletePdePermitException"),
                  transaction);

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
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
                SqlDatabase db = new SqlDatabase(conString);
                db.ExecuteNonQuery("DeletePdePermit", new object[] { permitNo });
                return true;
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

        //public bool SavePermitEditor(DataSet dsPermit, DbTransaction transaction)
        //{
        //  if (dsPermit == null)
        //  {
        //    transaction.Commit();
        //    return true;
        //  }
        //  SqlDatabase db = new SqlDatabase(conString);

        //  try
        //  {
        //    db.UpdateDataSet(dsPermit, "Permit",
        //      GetDbCommand(db, "AddUpdatePdePermit8"),
        //      GetDbCommand(db, "AddUpdatePdePermit8"),
        //      GetDbCommand(db, "DeletePdePermitEditor"),
        //      transaction);

        //    db.UpdateDataSet(dsPermit, "PermitActionHistory",
        //      GetDbCommand(db, "AddUpdatePdePermitActionHistoryV2"),
        //      GetDbCommand(db, "AddUpdatePdePermitActionHistoryV2"),
        //      GetDbCommand(db, "DeletePdePermitActionHistoryV2"),
        //      transaction);

        //    db.UpdateDataSet(dsPermit, "PermitFeeHistory",
        //      GetDbCommand(db, "AddUpdatePdePermitFeeHistoryV2"),
        //      GetDbCommand(db, "AddUpdatePdePermitFeeHistoryV2"),
        //      GetDbCommand(db, "DeletePdePermitFeeHistoryV2"),
        //      transaction);

        //    db.UpdateDataSet(dsPermit, "PermitEmissions",
        //      GetDbCommand(db, "AddUpdatePdePermitEmissions"),
        //      GetDbCommand(db, "AddUpdatePdePermitEmissions"),
        //      GetDbCommand(db, "DeletePdePermitEmissions"),
        //      transaction);

        //    db.UpdateDataSet(dsPermit, "PermitProject",
        //      GetDbCommand(db, "AddUpdatePdePermitProjectV2"),
        //      GetDbCommand(db, "AddUpdatePdePermitProjectV2"),
        //      GetDbCommand(db, "DeletePdePermitProjectV2"),
        //      transaction);

        //    db.UpdateDataSet(dsPermit, "PermitSupersede",
        //      GetDbCommand(db, "AddUpdatePdePermitSupersede"),
        //      GetDbCommand(db, "AddUpdatePdePermitSupersede"),
        //      GetDbCommand(db, "DeletePdePermitSupersede"),
        //      transaction);

        //    db.UpdateDataSet(dsPermit, "PermitException",
        //      GetDbCommand(db, "AddUpdatePdePermitException"),
        //      GetDbCommand(db, "AddUpdatePdePermitException"),
        //      GetDbCommand(db, "DeletePdePermitException"),
        //      transaction);

        //    transaction.Commit();
        //    return true;
        //  }
        //  catch (Exception ex)
        //  {
        //    transaction.Rollback();
        //    bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

        //    if (rethrow)
        //    {
        //      SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Permit:SavePermitEditor");
        //    }
        //    return false;
        //  }
        //  finally
        //  {
        //  }
        //}

        public bool UpdatePermitStatus(string conString, string permitNo, string permitStatus, DbTransaction transaction)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                db.ExecuteNonQuery(transaction, "UpdatePdePermitStatus", new object[] { permitNo, permitStatus });

                return true;
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

        public bool SavePermitReevalDue(string conString, DataSet dsReevalDueAdmin)
        {
            if (dsReevalDueAdmin == null) { return true; }
            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                db.UpdateDataSet(dsReevalDueAdmin, "PermitReevalDue",
                  GetDbCommand(db, "AddUpdatePdePermitReevalDue4"),
                  GetDbCommand(db, "AddUpdatePdePermitReevalDue4"),
                  GetDbCommand(db, "DeletePdePermitReevalDue"),
                  UpdateBehavior.Standard);

                return true;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PermitDL:SavePermitReevalDue");
                return false;
            }
            finally
            {
            }
        }

        public bool SavePermitSupersedeTransaction(string conString, DataSet dsPermit, string permitNo, string supersededPermitNo, bool supersededPermitIsMappingPermit)
        {
            if (dsPermit == null) { return true; }

            SqlDatabase db = new SqlDatabase(conString);

            DbConnection connection = db.CreateConnection();
            connection.Open();
            DbTransaction Transaction = connection.BeginTransaction();

            try
            {
                db.UpdateDataSet(dsPermit, "PermitSupersede",
                  GetDbCommand(db, "AddUpdatePdePermitSupersede"),
                  GetDbCommand(db, "AddUpdatePdePermitSupersede"),
                  GetDbCommand(db, "DeletePdePermitSupersede"),
                  Transaction);

                db.UpdateDataSet(dsPermit, "PermitActionHistory",
                  GetDbCommand(db, "AddUpdatePdePermitActionHistoryV2"),
                  GetDbCommand(db, "AddUpdatePdePermitActionHistoryV2"),
                  GetDbCommand(db, "DeletePdePermitActionHistoryV2"),
                  Transaction);

                db.ExecuteNonQuery(Transaction, "UpdatePdePermitStatus", new object[] { supersededPermitNo, "Superseded" });

                if (supersededPermitIsMappingPermit)
                {
                    db.ExecuteNonQuery(Transaction, "UpdatePdeMappingPermitToTrue", new object[] { "permitNo" });
                }

                Transaction.Commit();

                //SqlDatabase db2 = new SqlDatabase(conString);
                //db2.LoadDataSet("GetPdePermitSupersedeRefresh", dsPermit, new string[] { "Permit" }, new object[] { supersededPermitNo });

                return true;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PermitDL:SavePermitSupersedeTransaction");
                return false;
            }
            finally
            {
            }
        }

        public bool UpdatePermitFeeHistory(string conString, int permitFeeHistoryId, string permitFeeDate, bool invoiceSent, string transactionNo)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.ExecuteNonQuery("UpdatePdePermitFeeHistoryV2", new object[] { permitFeeHistoryId, permitFeeDate, invoiceSent, transactionNo });
                return true;
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

        public bool GetPdePermitSupersedeAux(string conString, DataSet dsPermitAux)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet(CommandType.StoredProcedure, "GetPdePermitSupersedeAux", dsPermitAux, new string[] { "SupersedingPermits" });

                return true;
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

        public bool GetPermitAux(string conString, DataSet dsPermitAux)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet(CommandType.StoredProcedure, "GetPdePermitAuxTables4", dsPermitAux, new string[] { "PermitSupervisor", "PermitExceptionType", "SupersedingPermits", "FacilityList", "PermitAction", "LeadAgency", "Project", "PermitFeeAction", "PermitType", "DocumentType", "PermitEngineer", "VafbContactFacility", "LandfillIssuanceEngineer" });

                return true;
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

        public bool GetReevalDue(string conString, DataSet dsReevalDueAdmin)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet(CommandType.StoredProcedure, "GetPdePermitReevalDue4", dsReevalDueAdmin, new string[] { "Employee", "PermitReevalDue" });

                return true;
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

        public bool GetReevalAssignmentLabel(string conString, DataSet dsReevalDueAdmin)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet(CommandType.StoredProcedure, "GetPdeReevalAssignmentLabel", dsReevalDueAdmin, new string[] { "ReevalAssignmentLabel" });

                return true;
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

        public bool GetReevalDue(string conString, DataSet dsReevalDueAdmin, int reevalAssignmentLabelId)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet("GetPdePermitReevalDue4", dsReevalDueAdmin, new string[] { "Employee", "PermitReevalDue" }, new object[] { reevalAssignmentLabelId });

                return true;
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
                SqlDatabase db = new SqlDatabase(conString);
                return db.ExecuteScalar(CommandType.StoredProcedure, "GetPdeNewPermitNo").ToString();
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

        public static string GetBillingContactCompanyNo(string conString, string permitNo)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                return db.ExecuteScalar("GetBillingContactCompanyNo", new object[] { permitNo }).ToString();
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "Permit:GetBillingContactCompanyNo");

                return null;
            }
        }

        public static string GetPermitBillingCompanyByPermit(string conString, string permitNo)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                object o = db.ExecuteScalar("GetPdePermitBillingCompanyByPermit", new object[] { permitNo });

                if (o != null)
                {
                    return o.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PermitDL:GetBillingContactCompanyNo");
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
                SqlDatabase db = new SqlDatabase(conString);

                DataSet dsBillingCompany = db.ExecuteDataSet("GetPdePermitBillingCompanyByFacility", new object[] { facilityNo });

                if (dsBillingCompany.Tables[0].Rows.Count > 0)
                {
                    return dsBillingCompany.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PermitDL:GetPermitBillingCompanyByFacility");
                return null;
            }
            finally
            {
            }
        }

        public static bool AddAnnualReportTracking(string conString, string permitNo)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.ExecuteScalar("AddPdeCmpAnnualReportTracking", new object[] { permitNo });
                return true;
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

        public string BillPdeApplicationFee(string conString, string permitNo, string projectNo, string companyNo, string invoiceAmount, string invoiceDesc, string prepaid, string invoiceDate)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                return db.ExecuteScalar("BillPdeApplicationFee", new object[] { invoiceDesc, companyNo, permitNo, projectNo, invoiceDate, prepaid, invoiceAmount }).ToString();
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

        public static string GetNewPermitNumber(string conString)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                return db.ExecuteScalar(CommandType.StoredProcedure, "GetPdeNewPermitNumber").ToString();
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

        public static string GetCompletenessEngineer(string conString, string permitNo)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                return db.ExecuteScalar("GetPdeCompletenessEmgineer", new object[] { permitNo }).ToString();
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

        public static bool EmailRoutingSlip(string conString, string permitNo)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.ExecuteNonQuery("SendRoutingSlip", new object[] { permitNo });
                return true;
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
                SqlDatabase db = new SqlDatabase(conString);
                db.ExecuteNonQuery("SendCompletenessRoutingSlip", new object[] { permitNo });
                return true;
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

        public static bool? GetCompletenessAssigned(string conString, string permitNo)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                return (bool)db.ExecuteScalar("GetPdeCompletenessAssigned", new object[] { permitNo });
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



        public static bool GetFacilityFinalPermitMapData(string conString, DataSet dsFacilityPermitsMapData)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                db.LoadDataSet("GetPdeFacilityFinalPermitMapData", dsFacilityPermitsMapData, new string[] { "FacilityPermitMapData" });
                return true;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public static bool GetFacilityPermitApplicationMapData(string conString, DataSet dsFacilityPermitsMapData)
        {
            SqlDatabase db = new SqlDatabase(conString);

            try
            {
                db.LoadDataSet("GetPdeFacilityPermitApplicationMapData", dsFacilityPermitsMapData, new string[] { "FacilityPermitMapData" });
                return true;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }


        private DbCommand GetDbCommand(Database db, string cmdSP)
        {
            DbCommand cmd = db.GetStoredProcCommand(cmdSP);
            db.DiscoverParameters(cmd);
            foreach (System.Data.SqlClient.SqlParameter para in cmd.Parameters)
            {
                para.SourceColumn = para.ParameterName.Substring(1, para.ParameterName.Length - 1);
            }
            return cmd;
        }

    }
}
