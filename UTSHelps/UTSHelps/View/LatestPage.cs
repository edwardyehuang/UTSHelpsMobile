using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class LatestPage : ContentPage
	{
		protected TableView latestSessionsListView = new TableView();

		public LatestPage ()
		{
			Title = "Latest";
		}
	}
}

