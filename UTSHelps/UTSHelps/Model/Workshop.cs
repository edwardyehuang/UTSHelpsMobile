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
	public class Workshop : HelpsBase
	{
		[JsonProperty]
		public string WorkshopId { get; set; }
		[JsonProperty]
		public string topic { get; set; }
		[JsonProperty]
		public string description { get; set; }
		[JsonProperty]
		public string targetingGroup { get; set; }
		[JsonProperty]
		public string campus { get; set; }
		[JsonProperty]
		public string StartDate { get; set; }
		[JsonProperty]
		public string EndDate { get; set; }
		[JsonProperty]
		public string maximum { get; set; }
		[JsonProperty]
		public string WorkShopSetID { get; set; }
		[JsonProperty]
		public string cutoff { get; set; }
		[JsonProperty]
		public string type { get; set; }
		[JsonProperty]
		public string reminder_num { get; set; }
		[JsonProperty]
		public string reminder_sent { get; set; }
		[JsonProperty]
		public string DaysOfWeek { get; set; }
		[JsonProperty]
		public string BookingCount { get; set; }
		[JsonProperty]
		public string archived { get; set; }

		public BookingStatuses BookingStatus { get; set; }
		public Workshops ReleatedSets { get; set;}

		public string ErrorMessage { get; set; } = "";


		public Workshop ()
		{
			
		}


		public void Book()
		{
			BookingStatus = BookingStatuses.Booking;

			UpdateSetData ();

			if (OnDataUpdated != null) {
				
				OnDataUpdated ();
			}

			var postData = "?workshopId=" + WorkshopId +
				"&studentId=" + HelpsData.SelfData.Info.StudentId + 
				"&userId=" + HelpsData.SelfData.Info.CreatorId;

			server.SendRequest (new HttpRequestMessage (HttpMethod.Post, "api/workshop/booking/create" + postData),
				(resultsRead) => {
					try
					{
						Debug.WriteLine(resultsRead);

						JObject results = JObject.Parse (resultsRead);

						if (results["IsSuccess"].ToString().Equals("True"))
						{
							BookingStatus = BookingStatuses.Booked;
						}
						else
						{
							BookingStatus = BookingStatuses.NotBooked;
							ErrorMessage = results["DisplayMessage"].ToString();
						}

						UpdateSetData();

						if (OnDataUpdated != null) {

							OnDataUpdated ();
						}
					}
					catch (InvalidCastException e) {

						Debug.WriteLine ("Invaild data\n " + resultsRead + "\n Error Message :" + e.Message);
					}
					catch (JsonException e) {

						Debug.WriteLine ("Invaild data\n " + resultsRead + "\n Error Message :" + e.Message);
					}
					catch (NullReferenceException e) {

						Debug.WriteLine ("Invaild data\n " + resultsRead + "\n Error Message :" + e.Message);
					}
				});
		}

		public void Cancel()
		{
			BookingStatus = BookingStatuses.Canceling;

			UpdateSetData ();

			if (OnDataUpdated != null) {

				OnDataUpdated ();
			}

			var postData = "?workshopId=" + WorkshopId +
				"&studentId=" + HelpsData.SelfData.Info.StudentId + 
				"&userId=" + HelpsData.SelfData.Info.CreatorId;

			server.SendRequest (new HttpRequestMessage (HttpMethod.Post, "api/workshop/booking/cancel" + postData),
				(resultsRead) => {
					try
					{
						JObject results = JObject.Parse (resultsRead);

						if (results["IsSuccess"].ToString().Equals("True"))
						{
							BookingStatus = BookingStatuses.NotBooked;
						}
						else
						{
							BookingStatus = BookingStatuses.Booked;
						}

						UpdateSetData();

						if (OnDataUpdated != null) {

							OnDataUpdated ();
						}
					}
					catch (InvalidCastException e) {

						Debug.WriteLine ("Invaild data\n " + resultsRead + "\n Error Message :" + e.Message);
					}
					catch (JsonException e) {

						Debug.WriteLine ("Invaild data\n " + resultsRead + "\n Error Message :" + e.Message);
					}
					catch (NullReferenceException e) {

						Debug.WriteLine ("Invaild data\n " + resultsRead + "\n Error Message :" + e.Message);
					}
				});

		}

		public void AddToWaitingList()
		{
			BookingStatus = BookingStatuses.Booking;

			UpdateSetData ();

			if (OnDataUpdated != null) {

				OnDataUpdated ();
			}

			var postData = "?workshopId=" + WorkshopId +
				"&studentId=" + HelpsData.SelfData.Info.StudentId + 
				"&userId=" + HelpsData.SelfData.Info.CreatorId;

			server.SendRequest (new HttpRequestMessage (HttpMethod.Post, "api/workshop/wait/create" + postData),
				(resultsRead) => {
					try
					{
						Debug.WriteLine(resultsRead);

						JObject results = JObject.Parse (resultsRead);

						if (results["IsSuccess"].ToString().Equals("True"))
						{
							
						}
						else
						{
							ErrorMessage = results["DisplayMessage"].ToString();
						}

						UpdateSetData();

						if (OnDataUpdated != null) {

							OnDataUpdated ();
						}
					}
					catch (InvalidCastException e) {

						Debug.WriteLine ("Invaild data\n " + resultsRead + "\n Error Message :" + e.Message);
					}
					catch (JsonException e) {

						Debug.WriteLine ("Invaild data\n " + resultsRead + "\n Error Message :" + e.Message);
					}
					catch (NullReferenceException e) {

						Debug.WriteLine ("Invaild data\n " + resultsRead + "\n Error Message :" + e.Message);
					}
				});
		}

		public void UpdateSetData()
		{
			if (ReleatedSets != null) {
				if (ReleatedSets.OnDataUpdated != null) {
					ReleatedSets.OnDataUpdated (); 
				}
			}
		}

	}
}

