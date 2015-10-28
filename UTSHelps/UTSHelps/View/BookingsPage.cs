using System;
using Xamarin.Forms;
using UTSHelps.UI;

namespace UTSHelps.View
{
	public class BookingsPage : ContentPage
	{
		public TableView BookingsListView { get;} = new TableView
		{
			Intent = TableIntent.Data,
		};

		public TextLabelCell RecordAttendanceButton { get; } = new TextLabelCell
		{
			Label = "Record attendance",
			XAlign = TextAlignment.Center,
			IsVisible = true,
			BackgroundColor = Color.Green,
			LabelColor = Color.White,
		};

		public BookingsPage ()
		{
			Title = "Booking";
			Icon = "icon_booking";

			BackgroundColor = new Color (1, 1, 1, 0);
			BookingsListView.BackgroundColor = new Color (1, 1, 1, 0);

			Content = BookingsListView;
		}


	}
}

