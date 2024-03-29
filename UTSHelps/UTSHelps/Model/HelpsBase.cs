﻿using System;
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
		public MainData HelpsData { get; set; }

		protected HelpsServer server = new HelpsServer
		{
			AppKey = "123456",
			//BaseAddress = "http://grp15sdp.danward.me:8080/",
			BaseAddress = "http://grp15sdp.cloudapp.net/"
		};

		public HelpsBase ()
		{
			server.Client = this;
		}

		public virtual void UpdateData()
		{
			Debug.WriteLine ("Start update data");
		}

		public virtual void GetDataFromLocal()
		{
			Debug.WriteLine ("Get data from local");
		}

		public virtual void SetDataToLocal()
		{
			Debug.WriteLine ("Set data to local");
		}

		public virtual void GetDataFromServer()
		{
			Debug.WriteLine ("Get data from server");
		}

		public virtual async Task DidReceiveResponse (HttpResponseMessage response)
		{
			string resultStr = await response.Content.ReadAsStringAsync ();
		    DidReadResponse (resultStr);
		}

		public virtual void DidReadResponse (string stringRead)
		{
		     Debug.WriteLine (stringRead);
		}
	}
}

