using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace SbcapcdOrg.PermitCompliance.Misc
{
    public enum UserControlContext { Facility, Umpermitted, Assignment, Asbestos, Review, MutualSettlement, Complaint, ComplaintReview };


    public class CommonComplianceMethods
	{
		public static string IsSinglePdfFile(DragEventArgs args)
		{
			if (args.Data.GetDataPresent(DataFormats.FileDrop, true))
			{
				string[] fileNames = args.Data.GetData(DataFormats.FileDrop, true) as string[];
				if (fileNames.Length == 1)
				{
					if (File.Exists(fileNames[0]) && Path.GetExtension(fileNames[0]).ToUpper() == ".PDF")
					{
						return fileNames[0];
					}
				}
			}
			return null;
		}

        public static void SetHashtable(Hashtable ht, object keyHT, object valueHT)
        {
            if (ht.Contains(keyHT))
            {
                ht[keyHT] = valueHT;
            }
            else
            {
                ht.Add(keyHT, valueHT);
            }
        }
    }

	public class PermitComplianceItem
	{
		public string StationarySourceNo { get; set; }
		public string StationarySourceName { get; set; }
		public string FacilityNo { get; set; }
		public string FacilityName { get; set; }
		public string ItemType { get; set; }
		public object ItemTypeId { get; set; }
		public object ItemId { get; set; }
		public DataRow drItem { get; set; }

		public PermitComplianceItem(
			string StationarySourceNo,
			string StationarySourceName,
			string FacilityNo,
			string FacilityName,
			string ItemType,
			object ItemTypeId,
			object ItemId,
			DataRow drItem
			)
		{
			this.StationarySourceNo = StationarySourceNo;
			this.StationarySourceName = StationarySourceName;
			this.FacilityNo = FacilityNo;
			this.FacilityName = FacilityName;
			this.ItemType = ItemType;
			this.ItemTypeId = ItemTypeId;			
			this.ItemId = ItemId;
			this.drItem = drItem;
		}
    }

    public class AsbestosAddedEventArgs : EventArgs
    {
        public object AsbestosId;
        public object AsbestosNo;
        public object FacilityName;
        public object FacilityAddress;
        //public object FirstLastName;
        //public object PostmarkedDate;

        public AsbestosAddedEventArgs(object asbestosId, object asbestosNo, object facilityName, object facilityAddress) //, object firstLastName, object postmarkedDate
        {
            AsbestosNo = asbestosNo;
            AsbestosId = asbestosId;
            FacilityName = facilityName;
            FacilityAddress = facilityAddress;
            //FirstLastName = firstLastName;
            //PostmarkedDate = postmarkedDate;
        }
    }

    public class ComplaintAddedEventArgs : EventArgs
    {
        public object ComplaintId;
        public object ComplaintNumber;
        public object ComplaintYear;
        public object Complainant;
        public object ComplaintReceivedDate;

        public ComplaintAddedEventArgs(object complaintId, object complaintNumber, object complaintYear, object complainant, object complaintReceivedDate) //, object firstLastName, object postmarkedDate
        {
            ComplaintId = complaintId;
            ComplaintNumber = complaintNumber;
            ComplaintYear = complaintYear;
            Complainant = complainant;
            ComplaintReceivedDate = complaintReceivedDate;
        }
    }

    public class ResetDisplayEventArgs : EventArgs
	{
		public string ItemType;
		public object ItemId;

		public ResetDisplayEventArgs(string itemType, object itemId)
		{
			ItemType = itemType;
			ItemId = itemId;
		}
	}

	public class ResetNodeDisplayEventArgs : EventArgs
	{
		public string Status;
		public object ItemId;

		public ResetNodeDisplayEventArgs(string status, object itemId)
		{
			Status = status;
			ItemId = itemId;
		}
    }

    public class DeleteItemEventArgs : EventArgs
    {
        public object ItemId;

        public DeleteItemEventArgs(object itemId)
        {
            ItemId = itemId;
        }
    }

    public class DeleteNodeEventArgs : EventArgs
	{
		public object ItemId;

		public DeleteNodeEventArgs(object itemId)
		{
			ItemId = itemId;
		}
	}

	public class ResetStationarySourceArgs : EventArgs
	{
		public PermitComplianceItem ResetComplianceItem;

		public ResetStationarySourceArgs(PermitComplianceItem resetComplianceItem)
		{
			ResetComplianceItem = resetComplianceItem;
		}
	}

	public class CopyCommentEventArgs : EventArgs
	{
		public string Topic;
		public object Comment;
		public int PermitComplianceLetterCommentId;

		public CopyCommentEventArgs(string topic, object comment, int permitComplianceLetterCommentId)
		{
			Topic = topic;
			Comment = comment;
			PermitComplianceLetterCommentId = permitComplianceLetterCommentId;
		}
	}
}
