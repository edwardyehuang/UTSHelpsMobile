using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class SessionsPage : ContentPage
	{
		public TableView SessionsListView { get;} = new TableView();

		public SessionsPage ()
		{
			Title = "Session";
			Icon = "icon_sessions";

			Content = SessionsListView;
		}
	}
}

