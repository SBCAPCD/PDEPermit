using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace SbcapcdOrg.PdePermit.PdePermitComponents
{
	public class GoToEntityEventArgs : EventArgs
	{
		public string EntityType;
		public object EntityNo;

		public GoToEntityEventArgs(string entityType, object entityNo)
		{
			EntityType = entityType;
			EntityNo = entityNo;
		}
	}

	public class EntityCurrentChangedEventArgs : EventArgs
	{
		public string Entity;
		public object PermitNo;
		public object FacilityNo;
		public object StationarySourceNo;

		public EntityCurrentChangedEventArgs(string entity, object permitNo, object facilityNo, object stationarySourceNo)
		{
			Entity = entity;
			PermitNo = permitNo;
			FacilityNo = facilityNo;
			StationarySourceNo = stationarySourceNo;
		}
	}

	public class EntityDataSetHasChangesEventArgs : EventArgs
	{
		public bool DataSetHasChanges;
		public EntityDataSetHasChangesEventArgs(bool dataSetHasChanges)
		{
			DataSetHasChanges = dataSetHasChanges;
		}
	}

	public class EntityHasNewItemEventArgs : EventArgs
	{
		public DataTable EntityDataTable;
		public EntityHasNewItemEventArgs(DataTable entityDataTable)
		{
			EntityDataTable = entityDataTable;
		}
	}

	public class CopyEmissionsGridEventArgs : EventArgs
	{
		public object FacilityNo;
		public System.Windows.Forms.BindingSource BsEmissionsGrid;

		public CopyEmissionsGridEventArgs(object facilityNo, System.Windows.Forms.BindingSource bsEmissionsGrid)
		{
			FacilityNo = facilityNo;
			BsEmissionsGrid = bsEmissionsGrid;
		}
	}

	public class CopyLocationEventArgs : EventArgs
	{
		public object StationarySourceNo;
		public System.Windows.Forms.BindingSource BsLocationCopy;

		public CopyLocationEventArgs(object stationarySourceNo, System.Windows.Forms.BindingSource bsLocationCopy)
		{
			StationarySourceNo = stationarySourceNo;
			BsLocationCopy = bsLocationCopy;
		}
	}
}
