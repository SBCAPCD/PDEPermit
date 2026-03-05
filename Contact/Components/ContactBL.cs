using System;
using System.Reflection;
using System.Data;
using System.Data.Common;

namespace SbcapcdOrg.Contact
{
    public class ContactBL
    {
        public DbTransaction GetTransaction(string conString)
        {
            try
            {
                SbcapcdOrg.Contact.ContactDL getTransaction = new ContactDL();
                return getTransaction.GetTransaction(conString);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return null;
            }
        }

        public bool GetContact(string conString, DataSet dsContact)
        {
            try
            {
                dsContact.Clear();
                SbcapcdOrg.Contact.ContactDL getContact = new ContactDL();
                return getContact.GetContact(conString, dsContact);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GetContacts(string conString, DataSet dsContacts)
        {
            try
            {
                dsContacts.Clear();
                SbcapcdOrg.Contact.ContactDL getContacts = new ContactDL();
                return getContacts.GetContacts(conString, dsContacts);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GetPerson(string conString, DataSet dsPerson, object personNo)
        {
            try
            {
                dsPerson.Clear();
                SbcapcdOrg.Contact.ContactDL getPerson = new ContactDL();
                return getPerson.GetPerson(conString, dsPerson, personNo);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GetPerson(string conString, DataSet dsPerson)
        {
            try
            {
                dsPerson.Clear();
                SbcapcdOrg.Contact.ContactDL getPerson = new ContactDL();
                return getPerson.GetPerson(conString, dsPerson);
            }
            catch(Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GetStationarySourceContacts(string conString, DataSet dsStationarySourceContacts)
        {
            try
            {
                dsStationarySourceContacts.Clear();
                SbcapcdOrg.Contact.ContactDL getStationarySourceContacts = new ContactDL();
                return getStationarySourceContacts.GetStationarySourceContacts(conString, dsStationarySourceContacts);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool SaveStationarySourceContacts(string conString, DataSet dsStationarySourceContacts)
        {
            try
            {
                SbcapcdOrg.Contact.ContactDL saveStationarySourceContacts = new ContactDL();
                return saveStationarySourceContacts.SaveStationarySourceContacts(conString, dsStationarySourceContacts);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        //public bool GetPerson(string conString, DataSet dsPerson, string entity)
        //{
        //    try
        //    {
        //        dsPerson.Clear();
        //        SbcapcdOrg.Contact.ContactDL getPerson = new ContactDL();
        //        getPerson.GetPerson(conString, dsPerson, entity);

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //    }
        //}

        public bool SaveContact(string conString, DataSet dsContacts)
        {
            try
            {
                SbcapcdOrg.Contact.ContactDL saveContact = new ContactDL();
                return saveContact.SaveContact(conString, dsContacts);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public static void UpdatePdeStationarySourceSingleBillingContact(string conString)
        {
            try
            {
                SbcapcdOrg.Contact.ContactDL.UpdatePdeStationarySourceSingleBillingContact(conString);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                
            }
        }

        public bool SavePerson(string conString, DataSet dsPerson)
        {
            try
            {
                SbcapcdOrg.Contact.ContactDL savePerson = new ContactDL();
                return savePerson.SaveContact(conString, dsPerson);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool SaveContact(string conString, DataSet dsContacts, System.Data.Common.DbTransaction transaction)
        {
            try
            {
                SbcapcdOrg.Contact.ContactDL saveContact = new ContactDL();
                return saveContact.SaveContact(conString, dsContacts, transaction);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool SavePerson(string conString, DataSet dsPerson, System.Data.Common.DbTransaction transaction)
        {
            try
            {
                SbcapcdOrg.Contact.ContactDL savePerson = new ContactDL();
                return savePerson.SavePerson(conString, dsPerson, transaction);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool SavePersonEditor(string conString, DataSet dsPerson, System.Data.Common.DbTransaction transaction)
        {
            try
            {
                SbcapcdOrg.Contact.ContactDL saveContact = new ContactDL();
                return saveContact.SavePersonEditor(conString, dsPerson, transaction);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GetContactAux(string conString, DataSet dsContactAux)
        {
            try
            {
                SbcapcdOrg.Contact.ContactDL getContactAux = new ContactDL();
                getContactAux.GetContactAux(conString, dsContactAux);

                return true;
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GetContactsAux(string conString, DataSet dsContactsAux)
        {
            try
            {

                SbcapcdOrg.Contact.ContactDL getContactsAux = new ContactDL();
                return getContactsAux.GetContactsAux(conString, dsContactsAux);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return false;
            }
        }

        //public void GetCCsByCompany(string conString, string companyNo, System.Windows.Forms.ListBox lbxContactPickList)
        //{
        //    DataSet ContactsByCompanyDS = null;

        //    try
        //    {
        //        SbcapcdOrg.Contact.ContactDL getContactsByCompany = new ContactDL();
        //        ContactsByCompanyDS = getContactsByCompany.GetCCsByCompany(conString, companyNo);
        //        lbxContactPickList.DataSource = ContactsByCompanyDS.Tables[0];
        //        lbxContactPickList.DisplayMember = "Name";
        //        lbxContactPickList.ValueMember = "ContactNo";
        //    }
        //    catch (Exception ex)
        //    {
        //        string errMessage = "";
        //        for (Exception tempException = ex; tempException != null; tempException = tempException.InnerException)
        //        {
        //            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine;
        //        }
        //        MessageBox.Show("Error getting data for GetCCsByCompany" + Environment.NewLine + Environment.NewLine + errMessage + Environment.NewLine, "GetCCsByCompany", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        if (ContactsByCompanyDS != null)
        //            ContactsByCompanyDS.Dispose();
        //    }
        //}

        //public void GetCCsByPermit(string conString, string permitNo, System.Windows.Forms.ListBox lbxContactPickList)
        //{
        //    DataSet ContactsByPermitDS = null;

        //    try
        //    {
        //        SbcapcdOrg.Contact.ContactDL getCCsByPermit = new ContactDL();
        //        ContactsByPermitDS = getCCsByPermit.GetCCsByPermit(conString, permitNo);

        //        lbxContactPickList.DataSource = ContactsByPermitDS.Tables[0];
        //        lbxContactPickList.DisplayMember = "Name";
        //        lbxContactPickList.ValueMember = "ContactNo";
        //    }
        //    catch (Exception ex)
        //    {
        //        string errMessage = "";
        //        for (Exception tempException = ex; tempException != null; tempException = tempException.InnerException)
        //        {
        //            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine;
        //        }
        //        MessageBox.Show("Error getting data for GetCCsByCompany" + Environment.NewLine + Environment.NewLine + errMessage + Environment.NewLine, "GetCCsByCompany", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        if (ContactsByPermitDS != null)
        //            ContactsByPermitDS.Dispose();
        //    }
        //}

        //public void GetAllCCs(string conString, System.Windows.Forms.ListBox lbxContactPickList)
        //{
        //    DataSet AllContactsDS = null;

        //    try
        //    {
        //        SbcapcdOrg.Contact.ContactDL getAllContacts = new ContactDL();
        //        AllContactsDS = getAllContacts.GetAllCCs(conString);

        //        lbxContactPickList.DataSource = AllContactsDS.Tables[0];
        //        lbxContactPickList.DisplayMember = "Name";
        //        lbxContactPickList.ValueMember = "ContactNo";
        //    }
        //    catch (Exception ex)
        //    {
        //        string errMessage = "";
        //        for (Exception tempException = ex; tempException != null; tempException = tempException.InnerException)
        //        {
        //            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine;
        //        }
        //        MessageBox.Show("Error getting data for GetContactsByPermit" + Environment.NewLine + Environment.NewLine + errMessage + Environment.NewLine, "GetCCsByCompany", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //    }
        //}

        public static string GetNewContactId(string conString)
        {
            try
            {
                return SbcapcdOrg.Contact.ContactDL.GetNewContactId(conString);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return null;
            }
        }

        public static string GetNewPersonNo(string conString)
        {
            try
            {
                return SbcapcdOrg.Contact.ContactDL.GetNewPersonNo(conString);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return null;
            }
        }

    }
}
