using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace UTSHelps.Server
{
	public class HelpsServerRequest : HttpRequestMessage
	{
		public string RequestTag { get; set; } = "default_request";

		public HelpsServerRequest ()
		{
			
		}

		public static HelpsServerRequest Request(string url, HttpMethod httpMethod, string tag = "default_request")
		{
			return new HelpsServerRequest () {

				Method = httpMethod,
			};
		}
	}
}

