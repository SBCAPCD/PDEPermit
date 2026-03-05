using System;
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
using SbcapcdOrg.ControlLibrary;

namespace SbcapcdOrg.PermitCompliance.Misc
{
    public class ComplianceComponentsDL
    {
        public static void GetFacilityHistory(string conString, DataSet dsFacilityHistory, object facilityNo)
        {
            SqlDatabase db = new SqlDatabase(conString);
            dsFacilityHistory.EnforceConstraints = false;

            try
            {
                db.LoadDataSet("GetCplFacilityHistory", dsFacilityHistory, new string[] { "Breakdowns", "NOVs", "Inspections", "Variances", "Permits"}, new object[] { facilityNo });
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, "GetFacilityHistory:PermitComplianceDL");
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
