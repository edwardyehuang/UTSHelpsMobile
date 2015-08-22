using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using UTSHelps.Server;
using Xamarin;
using System.Diagnostics;
using System.Threading.Tasks;

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

		public virtual async Task DidReceiveResponse (HttpResponseMessage response)
		{
			string resultStr = await response.Content.ReadAsStringAsync ();
			Debug.WriteLine (resultStr);
		}




	}
}

