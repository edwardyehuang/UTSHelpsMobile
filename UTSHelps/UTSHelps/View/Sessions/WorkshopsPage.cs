using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class WorkshopsPage : ContentPage
	{
		public TableView SessionsListView { get;} = new TableView();

		public WorkshopsPage ()
		{
			Title = "Loading";
			Icon = "icon_sessions";

			Content = SessionsListView;
		}
	}
}

