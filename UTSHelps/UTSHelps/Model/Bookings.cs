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
		public List<Booking> bookingHistories { get; set; } = new List<Booking>();

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

		public Booking GetBookingHistory(string workShopId)
		{
			foreach (Booking booking in bookingHistories) {

				if (booking.workshopID.Equals (workShopId)) {

					return booking;
				}
			}

			return null;
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			string bookingHistoriesJson = App.Setting.GetSettingValue ("BookingHistories");

			if (bookingHistoriesJson != null) {

				bookingHistories = JsonConvert.DeserializeObject<List<Booking>>(bookingHistoriesJson);
			}


			server.SendRequest (new HttpRequestMessage(HttpMethod.Get,
				"api/workshop/booking/search?studentId=" + HelpsData.SelfData.Info.StudentId));
		}

		public override void DidReadResponse (string stringRead)
		{
			try
			{
				JObject results = JObject.Parse (stringRead);

				//Get Work shop sets
				JArray sets = (JArray)results["Results"];
				bookings.Clear();

				foreach (JObject bookingObject in sets) {

					Booking booking;
					bookings.Add(booking = JsonConvert.DeserializeObject<Booking>(bookingObject.ToString()));

					if (GetBookingHistory(booking.workshopID) == null)
					{
						bookingHistories.Add(booking);
					}
				}

				App.Setting.SetSettingValue("BookingHistories", JsonConvert.SerializeObject(bookingHistories, Formatting.Indented));

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

