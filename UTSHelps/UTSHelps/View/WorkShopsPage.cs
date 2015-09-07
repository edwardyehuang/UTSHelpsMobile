using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class WorkShopsPage : ContentPage
	{
		public TableView ShopsListView { get;} = new TableView();

		public WorkShopsPage ()
		{
			Title = "WorkShop";
			Icon = "icon_sessions";

			Content = ShopsListView;
		}
	}
}

