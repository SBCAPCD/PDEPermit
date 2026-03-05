using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using SbcapcdOrg.ControlLibrary;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace SbcapcdOrg.PdePermit.Company
{
	class CompanyBL
	{
        public bool GetCompany(string conString, DataSet dsCompany)
		{
			try
			{
				dsCompany.Clear();
				SbcapcdOrg.PdePermit.Company.CompanyDL getCompany = new CompanyDL();
                getCompany.GetCompany(conString, dsCompany);

				return true;
			}
			catch (Exception ex)
			{
				//bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

				//if (rethrow)
				//{
				//  SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "");
				//}
				return false;
			}
			finally
			{
			}
		}

		public static string GetNewCompanyNo(string conString)
		{
			try
			{
                return SbcapcdOrg.PdePermit.Company.CompanyDL.GetNewCompanyNo(conString);
			}
			catch (Exception ex)
			{
				//bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

				//if (rethrow)
				//{
				//  SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "");
				//}
				return null;
			}
			finally
			{
			}
		}

        public bool SaveCompany(string conString, DataSet dsCompany)
		{
			try
			{
				SbcapcdOrg.PdePermit.Company.CompanyDL saveCompany = new CompanyDL();
                saveCompany.SaveCompany(conString, dsCompany);

				return true;
			}
			catch (Exception ex)
			{
				//bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

				//if (rethrow)
				//{
				//  SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "");
				//}
				return false;
			}
			finally
			{
			}
		}


        public bool GetCompanyAux(string conString, DataSet dsCompanyAux)
		{
			try
			{
				SbcapcdOrg.PdePermit.Company.CompanyDL getCompanyAux = new CompanyDL();
                getCompanyAux.GetCompanyAux(conString, dsCompanyAux);

				return true;
			}
			catch (Exception ex)
			{
				//bool rethrow = ExceptionPolicy.HandleException(ex, "Data Access Policy");

				//if (rethrow)
				//{
				//  SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "");
				//}
				return false;
			}
			finally
			{
			}
		}
	}
}
