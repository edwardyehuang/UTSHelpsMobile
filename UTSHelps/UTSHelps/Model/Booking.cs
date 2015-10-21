using System;
using System.Collections;
using System.Collections.Generic;
using UTSHelps.Server;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UTSHelps.Model
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Booking : HelpsBase
	{
		[JsonProperty]
		public string BookingId { get; set; }
		[JsonProperty]
		public string workshopID { get; set; }
		[JsonProperty]
		public string studentID { get; set; }
		[JsonProperty]
		public string topic { get; set; }
		[JsonProperty]
		public string description { get; set; }
		[JsonProperty]
		public string targetingGroup { get; set; }
		[JsonProperty]
		public string campusID { get; set; }
		[JsonProperty]
		public string starting { get; set; }
		[JsonProperty]
		public string ending { get; set; }
		[JsonProperty]
		public string maximum { get; set; }
		[JsonProperty]
		public string cutoff { get; set; }
		[JsonProperty]
		public string canceled { get; set; }
		[JsonProperty]
		public string attended { get; set; }
		[JsonProperty]
		public string WorkShopSetID { get; set; }
		[JsonProperty]
		public string type { get; set; }
		[JsonProperty]
		public string reminder_num { get; set; }
		[JsonProperty]
		public string reminder_sent { get; set; }
		[JsonProperty]
		public string WorkshopArchived { get; set; }
		[JsonProperty]
		public string BookingArchived { get; set; }

		public Workshop ReleatedWorkshop { get ; set; } 

		public Booking ()
		{
		}

		public Workshop ToWorkShop()
		{
			Workshop w = new Workshop ();

			w.WorkshopId = workshopID;
			w.topic = topic;
			w.description = description;
			w.targetingGroup = targetingGroup;
			w.campus = campusID;
			w.StartDate = starting;
			w.EndDate = ending;
			w.maximum = maximum;
			w.WorkShopSetID = WorkShopSetID;
			w.cutoff = cutoff;
			w.type = type;
			w.reminder_num = reminder_num;
			w.reminder_sent = reminder_sent;
			w.BookingStatus = BookingStatuses.Booked;

			w.HelpsData = HelpsData;

			return w;
		}

	
	}
}

