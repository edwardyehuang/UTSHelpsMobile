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
	public class Bookings : HelpsBase
	{
		public List<Booking> bookings { get; set; } = new List<Booking>();

		public Bookings ()
		{
		}

		public bool IsWorkshopInBooking(string workshopId)
		{
			return GetBooking (workshopId) != null;
		}

		public Booking GetBooking(string workShopId)
		{
			foreach (Booking booking in bookings) {

				if (booking.workshopID.Equals (workShopId)) {

					return booking;
				}
			}

			return null;
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			server.SendRequest (new HttpRequestMessage(HttpMethod.Get,
				"api/workshop/booking/search?active=true&studentId=" + HelpsData.SelfData.Info.StudentId));
		}

		public override void DidReadResponse (string stringRead)
		{
			try
			{
				JObject results = JObject.Parse (stringRead);

				//Get Work shop sets
				JArray sets = (JArray)results["Results"];
				bookings.Clear();

				foreach (JObject booking in sets) {

					bookings.Add(JsonConvert.DeserializeObject<Booking>(booking.ToString()));
				}

				if (OnDataUpdated != null) {
					OnDataUpdated ();
				}
			}
			catch (InvalidCastException e) {

				Debug.WriteLine ("Invaild data\n " + stringRead + "\n Error Message :" + e.Message);
			}
			catch (JsonException e) {

				Debug.WriteLine ("Invaild data\n " + stringRead + "\n Error Message :" + e.Message);
			}
		}

	}
}

