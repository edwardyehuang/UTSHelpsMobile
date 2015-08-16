using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;


namespace UTSHelps.Server
{
	public class HelpsServerResponse : HttpResponseMessage
	{
		public string RequestTag { get; set; } = "default_request";

		public HelpsServerResponse ()
		{
			
		}


	}
}

