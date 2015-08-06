using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace UTSHelps.Server
{
	public class HelpsServerRequest
	{
		

		public HelpsServerRequest ()
		{
			
		}

		public static HelpsServerRequest Request(string url, string httpMethod, string tag = "default_request")
		{
			return new HelpsServerRequest ();
		}
	}
}

