using System;
using UTSHelps.View;
using UTSHelps.Model;
using Xamarin.Forms;

namespace UTSHelps.Controller
{
	public class BookingsController : BaseController
	{
		public BookingsController (MainData mainData) : base(new BookingsPage(), mainData.BookingsData)
		{
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			Bookings bookings = (Bookings)Model;

			bookings.UpdateData ();
		}

		public override void UpdateView ()
		{
			base.UpdateView ();

			Bookings bookings = (Bookings)Model;
			BookingsPage page = (BookingsPage)View;

			TableSection section = new TableSection ();

			foreach (Booking booking in bookings.bookings) {

				TextCell cell = new TextCell {
					Text = booking.workshopID + " " + booking.topic,
				};

				//cell.Tapped += (object sender, EventArgs e) => ShowSectionsInSessions (session);
				section.Add (cell);
			}

			(page.BookingsListView.Root = new TableRoot ()).Add (section);
		}
	}
}

