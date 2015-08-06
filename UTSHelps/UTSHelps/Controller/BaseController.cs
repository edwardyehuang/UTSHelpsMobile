using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UTSHelps
{
	public class BaseController
	{
		public Page View { get; set; }

		public BaseController (Page view)
		{
			View = view;
			RegViewEvents ();
			UpdateData ();
		}

		public virtual void RegViewEvents()
		{
			View.Appearing += (object sender, EventArgs e) => UpdateData ();
		}

		public virtual void UpdateData()
		{


		}
	}
}

