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
	public class Sessions : HelpsBase
	{
		protected List <Session> sessions = new List<Session>();
		public Workshop RelatedWorkshop { get; set; }

		public Sessions () : base()
		{
			
		}

		public override void UpdateData ()
		{
			base.UpdateData ();
			server.SendRequest (new HttpRequestMessage(HttpMethod.Get, 
				"api/workshop/search?workshopSetId=" + RelatedWorkshop.Id));
		}

		public override void DidReadResponse (string stringRead)
		{
			Debug.WriteLine (stringRead);

			try
			{
				JObject results = JObject.Parse (stringRead);

				/*//Get Work shop sets
				JArray sets = (JArray)results["Results"];
				sessions.Clear();

				foreach (JObject workShop in sets) {

					sessions.Add (new Session {
						Id = workShop ["id"].ToString(),
						Name = workShop ["name"].ToString(),
					});
				}

				if (OnDataUpdated != null) {
					OnDataUpdated ();
				}*/
			}
			catch (InvalidCastException e) {

				Debug.WriteLine ("Invaild data\n " + stringRead + "\n Error Message :" + e.Message);
			}
		}


	}
}

