using System;
using System.Net.Http;
using System.Threading.Tasks;



namespace UTSHelps.Server
{
	public class HelpsServer
	{
		public string AppKey { get; set;} = "397044815";
		public string BaseAddress { get; set;}

		public HelpsClient Client { get; set; }



		public HelpsServer ()
		{
			 
		}

		public async void SendRequest(HttpRequestMessage request)
		{
			using (HttpClient client = new HttpClient ()) {

				client.BaseAddress = new Uri (BaseAddress);
				request.Headers.Add ("AppKey", AppKey);

				HttpResponseMessage httpRespose = await client.SendAsync (request);

				if (Client != null) {
					await Client.DidReceiveResponse (httpRespose);
				}
			}
		}

		


	}
}

