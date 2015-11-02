using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using UTSHelps.Model;

namespace UTSHelps.Controller
{
	public class BaseController
	{
		public Page View { get; set; }
		public HelpsBase Model { get; set; }

		public BaseController (Page view, HelpsBase model = null)
		{
			View = view;
			Model = model;
			RegViewEvents ();
			RegModalEvents ();
			UpdateData ();

		}

		public virtual void RegViewEvents()
		{
			try
			{
				View.Appearing += (object sender, EventArgs e) => UpdateData ();
			}
			catch(NullReferenceException) {
				
			}
		}

		public virtual void RegModalEvents()
		{
			if (Model == null)
				return;

			Model.OnDataUpdated = UpdateView;
		}

		public virtual void UpdateData()
		{


		}

		public virtual void UpdateView()
		{

		}

		public virtual void OnPressedSearch()
		{
			View.Navigation.PushModalAsync ((new SearchController (Model.HelpsData){parentView = View}).View);
		}
	}
}

