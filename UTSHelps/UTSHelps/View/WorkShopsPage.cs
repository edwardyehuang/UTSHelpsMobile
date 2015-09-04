using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class WorkShopsPage : ContentPage
	{
		public ListView ShopsListView { get;} = new ListView();

		public WorkShopsPage ()
		{
			Title = "WorkShop";
			Icon = "icon_sessions";
		}
	}
}

