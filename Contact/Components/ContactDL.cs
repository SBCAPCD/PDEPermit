using System;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SbcapcdOrg.Contact
{
    class ContactDL
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

        public bool GetContact(string conString, DataSet dsContact)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet(CommandType.StoredProcedure, "GetContactsByEntity", dsContact, new string[] { "Contact", "Person" });

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

        public bool GetContacts(string conString, DataSet dsContacts)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet(CommandType.StoredProcedure, "GetPdeContacts3", dsContacts, new string[] { "Contact", "Person", "Address" });

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

        public bool GetPerson(string conString, DataSet dsPerson, object personNo)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet("GetPdePersonByPersonNo", dsPerson, new string[] { "Person" }, new object[] { personNo });

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

        public bool GetPerson(string conString, DataSet dsPerson)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet(CommandType.StoredProcedure, "GetPersons", dsPerson, new string[] { "Person" });

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

        public bool GetStationarySourceContacts(string conString, DataSet dsStationarySourceContacts)
        {

            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet(CommandType.StoredProcedure, "GetPdeStationarySourceContacts", dsStationarySourceContacts, new string[] { "StationarySourceContacts", "Contacts" });

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

        public bool SaveStationarySourceContacts(string conString, DataSet dsStationarySourceContacts)
        {
            if (dsStationarySourceContacts == null) { return true; }
            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                db.UpdateDataSet(dsStationarySourceContacts, "StationarySourceContacts",
                    GetDbCommand(db, "AddUpdatePdeStationarySourceContacts"),
                    GetDbCommand(db, "AddUpdatePdeStationarySourceContacts"),
                    GetDbCommand(db, "DeletePdeStationarySourceContacts"),
                    UpdateBehavior.Standard);

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

        public bool SaveContact(string conString, DataSet dsContacts)
        {
            if (dsContacts == null) { return true; }
            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                if (dsContacts.Tables.Contains("Contact"))
                {
                    db.UpdateDataSet(dsContacts, "Contact",
                        GetDbCommand(db, "AddUpdatePdeContacts"),
                        GetDbCommand(db, "AddUpdatePdeContacts"),
                        GetDbCommand(db, "DeletePdeContact"),
                        UpdateBehavior.Standard);
                }

                if (dsContacts.Tables.Contains("Person"))
                {
                    db.UpdateDataSet(dsContacts, "Person",
                        GetDbCommand(db, "AddUpdatePdePerson4"),
                        GetDbCommand(db, "AddUpdatePdePerson4"),
                        GetDbCommand(db, "DeletePdePerson"),
                        UpdateBehavior.Standard);
                }

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

        public bool SaveContact(string conString, DataSet dsContact, DbTransaction transaction)
        {
            if (dsContact == null)
            {
                transaction.Commit();
                return true;
            }

            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                if (dsContact.Tables.Contains("Contact"))
                {
                    db.UpdateDataSet(dsContact, "Contact",
                        GetDbCommand(db, "AddUpdatePdeContacts4"),
                        GetDbCommand(db, "AddUpdatePdeContacts4"),
                        GetDbCommand(db, "DeletePdeContact"),
                        transaction);
                }

                if (dsContact.Tables.Contains("Person"))
                {
                    db.UpdateDataSet(dsContact, "Person",
                        GetDbCommand(db, "AddUpdatePdePerson3"),
                        GetDbCommand(db, "AddUpdatePdePerson3"),
                        GetDbCommand(db, "DeletePdePerson"),
                        transaction);
                }

                transaction.Commit();
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

        public bool SavePerson(string conString, DataSet dsPerson, DbTransaction transaction)
        {
            if (dsPerson == null) { return true; }

            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                db.UpdateDataSet(dsPerson, "Person",
                    GetDbCommand(db, "AddUpdatePdePerson"),
                    GetDbCommand(db, "AddUpdatePdePerson"),
                    GetDbCommand(db, "DeletePdePerson"),
                    transaction);

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

        public bool SavePerson(string conString, DataSet dsPerson)
        {
            if (dsPerson == null) { return true; }

            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                db.UpdateDataSet(dsPerson, "Person",
                    GetDbCommand(db, "AddUpdatePdePerson"),
                    GetDbCommand(db, "AddUpdatePdePerson"),
                    GetDbCommand(db, "DeletePdePerson"),
                    UpdateBehavior.Standard);

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
        public bool SavePersonEditor(string conString, DataSet dsPerson, DbTransaction transaction)
        {
            if (dsPerson == null) { return true; }
            try
            {
                SqlDatabase db = new SqlDatabase(conString);

                db.UpdateDataSet(dsPerson, "Person",
                    GetDbCommand(db, "UpdatePdePerson"),
                    GetDbCommand(db, "UpdatePdePerson"),
                    GetDbCommand(db, "DeletePdePersonEditor"),
                    transaction);

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

        public bool GetContactAux(string conString, DataSet dsContactAux)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet(CommandType.StoredProcedure, "GetContactAux", dsContactAux, new string[] { "NamePrefix", "NameSuffix", "PositionTitle", "SortGroup" });

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

        public bool GetContactsAux(string conString, DataSet dsContactsAux)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.LoadDataSet(CommandType.StoredProcedure, "GetPdeContactsAux", dsContactsAux, new string[] { "Facility", "Company", "ContactType", "Employee", "ContactTypeCreate", "SortGroup" });

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

        public DataSet GetAllCCs(string conString)
        {
            DataSet AllContactsDS = null;
            SqlConnection Connection = null;

            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                AllContactsDS = db.ExecuteDataSet("GetAllCCs");

                return AllContactsDS;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "GetCCsByCompany");
                return AllContactsDS;
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                    Connection.Dispose();
                }
            }
        }

        public DataSet GetCCsByPermit(string conString, string permitNo)
        {
            DataSet ContactsByPermitDS = null;
            SqlConnection Connection = null;

            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@PermitNo", SqlDbType.NVarChar, 6);
                arParms[0].Value = permitNo;

                ContactsByPermitDS = db.ExecuteDataSet("GetCCsByPermit", arParms);
                return ContactsByPermitDS;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "GetCCsByPermit");
                return ContactsByPermitDS;
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                    Connection.Dispose();
                }
            }
        }

        public DataSet GetCCsByCompany(string conString, string companyNo)
        {
            DataSet ContactsByCompanyDS = null;
            SqlConnection Connection = null;

            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@CompanyNo", SqlDbType.NVarChar, 6);
                arParms[0].Value = companyNo;

                ContactsByCompanyDS = db.ExecuteDataSet("GetCCsByCompany", arParms);

                return ContactsByCompanyDS;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return ContactsByCompanyDS;
            }
            finally
            {
                if (Connection != null)
                {
                    Connection.Close();
                    Connection.Dispose();
                }
            }
        }

        public static string GetNewContactId(string conString)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                return db.ExecuteScalar(CommandType.StoredProcedure, "GetPdeNewContactId").ToString();
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

        public static string GetNewPersonNo(string conString)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                return db.ExecuteScalar(CommandType.StoredProcedure, "GetNewPersonNo").ToString();
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

        public static void UpdatePdeStationarySourceSingleBillingContact(string conString)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(conString);
                db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdatePdeStationarySourceSingleBillingContact");
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
            }
            finally
            {
            }
        }

        //private static void SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(Exception ex, string errorSP)
        //{
        //  StringBuilder sb = new StringBuilder();
        //  StringWriter writer = new StringWriter(sb);

        //  AppTextExceptionFormatter formatter = new AppTextExceptionFormatter(writer, ex);

        //  // Format the exception
        //  formatter.Format();
        //  MessageBox.Show(sb.ToString(), "Application Error: " + errorSP, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

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
