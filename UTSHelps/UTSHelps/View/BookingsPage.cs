using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class BookingsPage : ContentPage
	{
		public TableView BookingsListView { get;} = new TableView();

		public BookingsPage ()
		{
			Title = "Booking";
			Icon = "icon_booking";

			Content = BookingsListView;
		}


	}
}

