using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;


namespace UTSHelps.Server
{
	public class HelpsServer
	{
		public string AppKey { get; set;} = "123456";
		public string BaseAddress { get; set;}

		public HelpsClient Client { get; set; }

		public delegate void ReceivedResponseEvent(string resultsRead);


		public HelpsServer ()
		{
			
		}

		public async void SendRequest(HttpRequestMessage request, ReceivedResponseEvent callback = null)
		{
			using (HttpClient client = new HttpClient ()) {

				client.BaseAddress = new Uri (BaseAddress);
				request.Headers.Add ("AppKey", AppKey);

				try
				{
					HttpResponseMessage httpRespose = await client.SendAsync (request);

					Debug.WriteLine("Respones received");

					if (callback != null)
					{
						string resultStr = await httpRespose.Content.ReadAsStringAsync ();
						callback(resultStr);
					}
					else if (Client != null) 
					{
						await Client.DidReceiveResponse (httpRespose);
					}
				}
				catch(WebException e) {
					Debug.WriteLine ("Send request failed :" + e.Message);
				}
			}
		}

		


	}
}

