using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class WorkshopsPage : ContentPage
	{
		public TableView WorkshopsListView { get;} = new TableView();

		public WorkshopsPage ()
		{
			Title = "Loading";
			Icon = "icon_sessions";

			WorkshopsListView.Intent = TableIntent.Menu;
			Content = WorkshopsListView;

			BackgroundColor =  new Color (1, 1, 1, 0.2);
			WorkshopsListView.BackgroundColor = new Color (0, 0, 0, 0);
		}
	}
}

