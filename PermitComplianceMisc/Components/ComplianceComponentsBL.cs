using System;
using System.IO;
using System.Globalization;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PermitCompliance.Misc
{
    public class ComplianceComponentsBL
    {
        public static void GetFacilityHistory(string conString, DataSet dsFacilityHistory, object facilityNo)
        {
            dsFacilityHistory.Clear();

            try
            {
                SbcapcdOrg.PermitCompliance.Misc.ComplianceComponentsDL.GetFacilityHistory(conString, dsFacilityHistory, facilityNo);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "PermitComplianceBL:GetFacilityHistory");
            }
        }

    }
}
