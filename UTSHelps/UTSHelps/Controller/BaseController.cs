using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UTSHelps
{
	public class BaseController
	{
		public Page View { get; set; }

		public BaseController (Page view = null)
		{
			View = view;
			RegViewEvents ();
			UpdateData ();
		}

		public virtual void RegViewEvents()
		{

		}

		public virtual void UpdateData()
		{

		}
	}
}

