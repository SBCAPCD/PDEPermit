using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SbcapcdOrg.PdePermit.PdePermitComponents;
using SbcapcdOrg.ControlLibrary;

using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;

namespace SbcapcdOrg.PdePermit.StationarySource
{
	class StationarySourceBL
	{
		public DbTransaction GetTransaction(string conString)
		{
			try
			{
				SbcapcdOrg.PdePermit.StationarySource.StationarySourceDL getTransaction = new StationarySourceDL();
                return getTransaction.GetTransaction(conString);
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

        public bool GetStationarySource(string conString, DataSet dsStationarySource)
		{
			try
			{
				SbcapcdOrg.PdePermit.StationarySource.StationarySourceDL getStationarySource = new StationarySourceDL();
                return getStationarySource.GetStationarySource(conString, dsStationarySource);
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}

        public bool SaveStationarySource(string conString, DataSet dsStationarySource, DbTransaction transaction)
		{
			try
			{
				SbcapcdOrg.PdePermit.StationarySource.StationarySourceDL saveStationarySource = new StationarySourceDL();
                return saveStationarySource.SaveStationarySource(conString, dsStationarySource, transaction);
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}

        public bool SaveStationarySourceToxics(string conString, DataSet dsStationarySource, DbTransaction transaction)
        {
            try
            {
                SbcapcdOrg.PdePermit.StationarySource.StationarySourceDL saveStationarySourceToxics = new StationarySourceDL();
                return saveStationarySourceToxics.SaveStationarySourceToxics(conString, dsStationarySource, transaction);
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }

        public bool SaveStationarySource(string conString, DataSet dsStationarySource)
		{
			try
			{
				SbcapcdOrg.PdePermit.StationarySource.StationarySourceDL saveStationarySource = new StationarySourceDL();
                return saveStationarySource.SaveStationarySource(conString, dsStationarySource);
			}
			catch 
			{
				return false;
			}
			finally
			{
			}
		}

        public bool GetStationarySourceAux(string conString, DataSet dsStationarySourceAux)
		{
			try
			{
				dsStationarySourceAux.Clear();
				SbcapcdOrg.PdePermit.StationarySource.StationarySourceDL getStationarySourceAux = new StationarySourceDL();
                return getStationarySourceAux.GetStationarySourceAux(conString, dsStationarySourceAux);
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}

        public void GetStationarySourceEmissions(string conString, object stationarySourceNo, DataSet dsStationarySourceEmissions)
		{
			try
			{
				dsStationarySourceEmissions.Clear();
				SbcapcdOrg.PdePermit.StationarySource.StationarySourceDL getStationarySourceEmissions = new StationarySourceDL();
                getStationarySourceEmissions.GetStationarySourceEmissions(conString, stationarySourceNo, dsStationarySourceEmissions);
			}
			catch (Exception ex)
			{
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, ":GetStationarySourceEmissions");
			}
			finally
			{
			}
		}

		public static string GetNewStationarySourceNo(string conString)
		{
			try
			{
				return SbcapcdOrg.PdePermit.StationarySource.StationarySourceDL.GetNewStationarySourceNo(conString);
			}
			catch
			{
				return null;
			}
			finally
			{
			}
		}

        public static int GetNewStationarySourceHraHistoryId(string conString)
        {
            try
            {
                return (int)SbcapcdOrg.PdePermit.StationarySource.StationarySourceDL.GetNewStationarySourceHraHistoryId(conString);
            }
            catch (Exception ex)
            {
                SbcapcdOrg.ControlLibrary.DisplayException.DisplayExceptionInfo(ex, MethodInfo.GetCurrentMethod().ReflectedType.Name + " : " + MethodInfo.GetCurrentMethod().Name);
                return -99;
            }
            finally
            {
            }
        }
        
	}

}
