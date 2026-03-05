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
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using SbcapcdOrg.PdePermit.PdePermitComponents;
using SbcapcdOrg.ControlLibrary;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace SbcapcdOrg.PdePermit.Facility
{
	class FacilityBL
	{
		public DbTransaction GetTransaction(string conString)
		{
			try
			{
				SbcapcdOrg.PdePermit.Facility.FacilityDL getTransaction = new FacilityDL();
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

        public bool GetFacility(string conString, DataSet dsFacility)
		{
			try
			{
				dsFacility.Clear();
				SbcapcdOrg.PdePermit.Facility.FacilityDL getFacility = new FacilityDL();
                return getFacility.GetFacility(conString, dsFacility);
			}
			catch 
			{
				return false;
			}
			finally
			{
			}
		}

		public bool GetFacilityRelated(string conString, DataSet dsFacility, string facilityNo)
		{
			try
			{
				SbcapcdOrg.PdePermit.Facility.FacilityDL getFacility = new FacilityDL();
				return getFacility.GetFacilityRelated(conString, dsFacility, facilityNo);
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}

        public bool GetNewStationarySources(string conString, DataSet dsFacilityAux)
		{
			try
			{
				SbcapcdOrg.PdePermit.Facility.FacilityDL getNewStatinarySources = new FacilityDL();
                return getNewStatinarySources.GetNewStationarySources(conString, dsFacilityAux);
			}
			catch 
			{
				return false;
			}
			finally
			{
			}
		}

        public bool SaveFacility(string conString, DataSet dsFacility, DbTransaction transaction)
		{
			try
			{
				SbcapcdOrg.PdePermit.Facility.FacilityDL saveFacility = new FacilityDL();
                return saveFacility.SaveFacility(conString, dsFacility, transaction);
			}
			catch 
			{
				return false;
			}
			finally
			{
			}
		}

        public bool EditorSaveFacility(string conString, DataSet dsFacility, DbTransaction transaction)
		{
			try
			{
				SbcapcdOrg.PdePermit.Facility.FacilityDL saveFacility = new FacilityDL();
                return saveFacility.EditorSaveFacility(conString, dsFacility, transaction);
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}

        public bool GetPrimaryFacilityAux(string conString, DataSet dsFacilityAux)
		{
			try
			{
				SbcapcdOrg.PdePermit.Facility.FacilityDL getFacilityAux = new FacilityDL();
                return getFacilityAux.GetFacilityPrimaryAux(conString, dsFacilityAux);
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}

        public static bool GetFacilityCompanies(string conString, DataSet dsFacilityAux)
        {
            try
            {
                dsFacilityAux.Tables["Companies"].Clear();
                return SbcapcdOrg.PdePermit.Facility.FacilityDL.GetFacilityCompanies(conString, dsFacilityAux);
            }
            catch
            {
                return false;
            }
        }

        public bool GetSecondaryFacilityAux(string conString, DataSet dsFacilityAux)
		{
			try
			{
				SbcapcdOrg.PdePermit.Facility.FacilityDL getFacilityAux = new FacilityDL();
                return getFacilityAux.GetFacilitySecondaryAux(conString, dsFacilityAux);
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}

		public static string GetNewFacilityNo(string conString)
		{
			try
			{
                return SbcapcdOrg.PdePermit.Facility.FacilityDL.GetNewFacilityNo(conString);
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
	}
}
