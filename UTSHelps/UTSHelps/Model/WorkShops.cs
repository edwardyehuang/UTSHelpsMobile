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
	public class WorkShops : HelpsBase
	{
		public List <Workshop> Shops { get; set; } = new List<Workshop>();

		public WorkShops () : base()
		{

		}

		public override void UpdateData ()
		{
			base.UpdateData ();
			server.SendRequest (new HttpRequestMessage(HttpMethod.Get, "api/workshop/workshopSets/true"));
		}

		public override void DidReadResponse (string stringRead)
		{
			try
			{
				JObject results = JObject.Parse (stringRead);

				//Get Work shop sets
				JArray sets = (JArray)results["Results"];

				foreach (JObject workShop in sets) {

					Shops.Add (new Workshop {
						Id = workShop ["id"].ToString(),
						Name = workShop ["name"].ToString(),
					});
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

