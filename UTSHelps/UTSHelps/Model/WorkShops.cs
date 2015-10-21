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
	public class Workshops : HelpsBase
	{
		public List <Workshop> workshops  { get; set; } = new List<Workshop>();
		public WorkshopSet RelatedWorkshopSet { get; set; }

		public Workshops () : base()
		{
			
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			if (workshops.Count <= 0) {
				GetDataFromServer ();
			}
			else if (OnDataUpdated != null) {
				OnDataUpdated ();
			}
		}

		public override void GetDataFromServer ()
		{
			base.GetDataFromServer ();

			server.SendRequest (new HttpRequestMessage (HttpMethod.Get, 
				"api/workshop/search?workshopSetId=" + RelatedWorkshopSet.Id));
			Debug.WriteLine ("Request the workshop from workshopset ID : " + RelatedWorkshopSet.Id);
		}

		public override void DidReadResponse (string stringRead)
		{
			Debug.WriteLine (stringRead);

			try
			{
				JObject results = JObject.Parse (stringRead);

				//Get Work shop sets
				JArray sets = (JArray)results["Results"];
				workshops.Clear();

				foreach (JObject sessionObject in sets) {
				 
					Workshop workshop = JsonConvert.DeserializeObject<Workshop>(sessionObject.ToString());
					workshop.HelpsData = HelpsData;
					workshop.ReleatedSets = this;

					Booking booking = HelpsData.BookingsData.GetBooking(workshop.WorkshopId);

					if (booking == null)
					{
						workshop.BookingStatus = BookingStatuses.NotBooked;
					}
					else
					{
						workshop.BookingStatus = BookingStatuses.Booked;
						booking.ReleatedWorkshop = workshop;
					}
						
					workshops.Add(workshop);
				}

				if (OnDataUpdated != null) {
					OnDataUpdated ();
				}
			}
			catch (InvalidCastException e) {

				Debug.WriteLine ("Invaild data\n " + stringRead + "\n Error Message :" + e.Message);
			}
		}




	}
}

