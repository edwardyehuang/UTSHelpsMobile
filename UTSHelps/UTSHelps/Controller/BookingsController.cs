using System;
using UTSHelps.View;
using UTSHelps.Model;
using Xamarin.Forms;
using System.Diagnostics;

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
					TextColor = App.textColor, 
				};

				cell.Tapped += (object sender, EventArgs e) => ShowSelectedWorkshop (booking);
				section.Add (cell);
			}

			(page.BookingsListView.Root = new TableRoot ()).Add (section);
		}

		public void ShowSelectedWorkshop(Booking booking)
		{
			booking.HelpsData = Model.HelpsData;

			if (booking.ReleatedWorkshop == null) {

				AddNewReleatedWorkshop (booking);
			}
				
			View.Navigation.PushAsync(new WorkshopController(booking.ReleatedWorkshop).View);
		}

		public void AddNewReleatedWorkshop(Booking booking)
		{
			booking.ReleatedWorkshop = booking.ToWorkShop ();
		}
	}
}

