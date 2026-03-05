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


namespace SbcapcdOrg.PdePermit.Forms
{
	class PdePermitFormsBL
	{

        public bool GetPdePermitFormsAux(string conString, DataSet dsPdePermitFormsAux)
		{
			try
			{
				dsPdePermitFormsAux.Clear();
				SbcapcdOrg.PdePermit.Forms.PdePermitDL getPdePermitFormsAux = new PdePermitDL();
                getPdePermitFormsAux.GetPdePermitFormsAux(conString, dsPdePermitFormsAux);

				return true;
			}
			catch (Exception ex)
			{
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PdePermitFormsBL:GetPdePermitFormsAux");
				return false;
			}
			finally
			{
			}
		}

        public static Hashtable GetApplicationParameters(string conString, string application)
		{
			DataSet ApplicationParametersDS = null;
			try
			{
                ApplicationParametersDS = SbcapcdOrg.PdePermit.Forms.PdePermitDL.GetApplicationParameters(conString, application);
				Hashtable ApplicationParametersHT = new Hashtable();

				foreach (DataRow row in ApplicationParametersDS.Tables[0].Rows)
				{
					ApplicationParametersHT.Add(row["Parameter"], row["ParameterValue"]);
				}

				return ApplicationParametersHT;
			}
			catch (Exception ex)
			{
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PdePermitFormsBL:GetApplicationParameters");
				return null;
			}
			finally
			{
				if (ApplicationParametersDS != null)
				{
					ApplicationParametersDS.Dispose();
				}
			}
		}


        public bool GetConnectionStrings(string conString, DataSet dsConnectionStrings)
		{
			try
			{
				SbcapcdOrg.PdePermit.Forms.PdePermitDL getConnectionStrings = new PdePermitDL();
				return getConnectionStrings.GetConnectionStrings(conString, dsConnectionStrings);
			}
			catch (Exception ex)
			{
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PdePermitFormsBL:GetConnectionStrings");
				return false;
			}
			finally
			{
			}
		}
	}
}
