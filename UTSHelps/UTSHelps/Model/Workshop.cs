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
	public class Workshop : HelpsBase
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Archived { get; set; }
		public Sessions WorkShopSessions { get; set; }
		public BookingStatuses BookingStatus { get; set; }

		public Workshop () : base()
		{
			
		}

		public void Book()
		{
			BookingStatus = BookingStatuses.Booking;

			if (HelpsData.WorkShopsData.OnDataUpdated != null) 
			{
				HelpsData.WorkShopsData.OnDataUpdated (); 
			}

			var postData = "?workshopId=" + Id +
				"&studentId=" + HelpsData.SelfData.Info.StudentId + 
				"&userId=" + HelpsData.SelfData.Info.CreatorId;

			server.SendRequest (new HttpRequestMessage (HttpMethod.Post, "api/workshop/booking/create" + postData));
		}

		public void Cancel()
		{

		}

		public override void DidReadResponse (string stringRead)
		{
			base.DidReadResponse (stringRead);

			try
			{
				JObject results = JObject.Parse (stringRead);

				if (results["IsSuccess"].ToString().Equals("true"))
				{
					
					BookingStatus = BookingStatus == BookingStatuses.Booking ? 
						BookingStatuses.Booked : BookingStatuses.NotBooked;
				}
				else
				{
					BookingStatus = BookingStatus == BookingStatuses.Booking ? 
						BookingStatuses.NotBooked : BookingStatuses.Booked;
				}

				if (HelpsData.WorkShopsData.OnDataUpdated != null) 
				{
					HelpsData.WorkShopsData.OnDataUpdated ();
				}

			}
			catch (InvalidCastException e) {

				Debug.WriteLine ("Invaild data\n " + stringRead + "\n Error Message :" + e.Message);
			}
			catch (JsonException e) {

				Debug.WriteLine ("Invaild data\n " + stringRead + "\n Error Message :" + e.Message);
			}
			catch (NullReferenceException e) {

				Debug.WriteLine ("Invaild data\n " + stringRead + "\n Error Message :" + e.Message);
			}
		}
			
	}
}

