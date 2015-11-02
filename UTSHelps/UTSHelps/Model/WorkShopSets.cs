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
	public class WorkShopSets : HelpsBase
	{
		public List <WorkshopSet> Sets { get; set; } = new List<WorkshopSet>();
		private const string localDataKey = "WorkshopSets";

		public WorkShopSets () : base()
		{

		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			if (Sets.Count <= 0) {
				GetDataFromLocal ();
				GetDataFromServer ();
			}
			else if (OnDataUpdated != null) {
				OnDataUpdated ();
			}
		}

		public override void GetDataFromServer ()
		{
			base.GetDataFromServer ();
			server.SendRequest (new HttpRequestMessage (HttpMethod.Get, "api/workshop/workshopSets/true"));
		}

		public override void GetDataFromLocal ()
		{
			base.GetDataFromLocal ();

			string localData = App.Setting.GetSettingValue (localDataKey);

			if (localData != null) 
			{
				if (!localData.Equals ("")) 
				{
					DidReadResponse (localData);
				}
			}
		}

		public override void DidReadResponse (string stringRead)
		{
			try
			{
				JObject results = JObject.Parse (stringRead);

				//Get Work shop sets
				JArray sets = (JArray)results["Results"];
				Sets.Clear();

				foreach (JObject workShopObject in sets) {
					
					Sets.Add (new WorkshopSet {
						Id = workShopObject ["id"].ToString(),
						Name = workShopObject ["name"].ToString(),
						HelpsData = this.HelpsData,
					});
				}

				//Save data to local
				App.Setting.SetSettingValue (localDataKey,stringRead);

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

