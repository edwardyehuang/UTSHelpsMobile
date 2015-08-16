using System;
using System.Net.Http;
using UTSHelps.Server;
using Xamarin;
using System.Diagnostics;

namespace UTSHelps.Model
{
	public class HelpsBase : HelpsClient
	{
		public delegate void VoidDelegate();
		public VoidDelegate OnDataUpdated {get; set;}

		protected HelpsServer server = new HelpsServer
		{
			AppKey = "397044815",
			BaseAddress = "http://utshelp.cloudapp.net",
		};

		public HelpsBase ()
		{
			server.Client = this;
		}

		public virtual void UpdateData()
		{
			Debug.WriteLine ("Start update data");
		}

		public virtual void DidReceiveResponse (HelpsServerResponse response)
		{
			Debug.WriteLine (response.Content.ToString ());
		}


	}
}

