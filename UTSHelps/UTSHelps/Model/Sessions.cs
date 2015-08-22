using System;
using System.Collections;
using System.Collections.Generic;
using UTSHelps.Server;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace UTSHelps.Model
{
	public class Sessions : HelpsBase
	{
		protected List <Session> sessions = new List<Session>();

		public Sessions () : base()
		{
			
		}

		public override void UpdateData ()
		{
			base.UpdateData ();
			server.SendRequest (new HttpRequestMessage(HttpMethod.Get, "api/workshop/workshopSets/true"));
		}

		public override async Task DidReceiveResponse (HttpResponseMessage response)
		{
			string resultStr = await response.Content.ReadAsStringAsync ();
			Debug.WriteLine (resultStr);

			JsonReader reader = new JsonTextReader (new StringReader (resultStr));
			while (reader.Read())
			{
				if (reader.Value != null)
					Debug.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
				else
					Debug.WriteLine("Token: {0}", reader.TokenType);
				}
		}
	}
}

