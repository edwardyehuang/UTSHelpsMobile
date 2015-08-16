using System;
using System.Collections;
using System.Collections.Generic;
using UTSHelps.Server;
using System.Net.Http;

namespace UTSHelps.Model
{
	public class Sessions : HelpsBase
	{
		protected List <Session> sessions = new List<Session>();

		public Sessions ()
		{
			
		}

		public override void UpdateData ()
		{
			base.UpdateData ();
		 	server.SendRequest (HelpsServerRequest.Request ("api/workshop/workshopSets", HttpMethod.Get, "WorkshopSets"));
		}

		public override void DidReceiveResponse (HelpsServerResponse response)
		{
			base.DidReceiveResponse (response);
		}
	}
}

