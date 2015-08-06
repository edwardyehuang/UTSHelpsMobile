using System;
using System.Net.Http;

namespace UTSHelps.Server
{
	public class HelpsServer
	{
		protected HttpClient client = new HttpClient();

		public HelpsServer (string baseAddress)
		{
			client.BaseAddress = baseAddress;
		}

		public void GetWorkShopSets()
		{

		}


	}
}

