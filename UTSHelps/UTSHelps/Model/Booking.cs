using System;

namespace UTSHelps.Model
{
	public class Booking : HelpsBase
	{
		public string BookingId { get; set; }
		public string workshopID { get; set; }
		public string studentID { get; set; }
		public string topic { get; set; }
		public string description { get; set; }
		public string targetingGroup { get; set; }
		public string campusID { get; set; }
		public string starting { get; set; }
		public string ending { get; set; }
		public string maximum { get; set; }
		public string cutoff { get; set; }
		public string canceled { get; set; }
		public string attended { get; set; }
		public string WorkShopSetID { get; set; }
		public string type { get; set; }
		public string reminder_num { get; set; }
		public string reminder_sent { get; set; }
		public string WorkshopArchived { get; set; }
		public string BookingArchived { get; set; }

		public Booking ()
		{
		}

	
	}
}

