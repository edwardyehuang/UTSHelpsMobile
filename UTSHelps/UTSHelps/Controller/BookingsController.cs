using System;
using UTSHelps.View;
using UTSHelps.Model;
using UTSHelps.UI;
using Xamarin.Forms;
using System.Diagnostics;
using ZXing;
using ZXing.Mobile;

namespace UTSHelps.Controller
{
	public class BookingsController : BaseController
	{
		public BookingsController (MainData mainData) : base(new BookingsPage(), mainData.BookingsData)
		{
			View.ToolbarItems.Add(new ToolbarItem ("History", "icon_latest.png", ViewBookingHistories));
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
					TextColor = Color.White
				};

				cell.Tapped += (object sender, EventArgs e) => ShowSelectedWorkshop (booking);
				section.Add (cell);
			}

			page.RecordAttendanceButton.Tapped += (sender, e) => ScanQRCode();

			(page.BookingsListView.Root = new TableRoot ()).Add (new TableSection {page.RecordAttendanceButton});
			page.BookingsListView.Root.Add (section);
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

		public async void ScanQRCode()
		{
			var scanner = new ZXing.Mobile.MobileBarcodeScanner ();

			var result = await scanner.Scan();

			if (result != null) {
				Debug.WriteLine ("Scanned barcode: " + result.Text);
			
				RecordAttandance (result.Text);
			}

		}

		public void ViewBookingHistories ()
		{
			var table = new TableView ();
			var mainSection = new TableSection ();

			foreach (Booking booking in ((Bookings)Model).bookingHistories) {

				mainSection.Add (new TextCell{ Text = booking.topic});
			}

			(table.Root = new TableRoot ()).Add (mainSection);

			View.Navigation.PushAsync (new ContentPage {
				Title = "Booking History",
				Content = table
			});
		}

		public void RecordAttandance(string requestPart)
		{
			try
			{
				string[] parts = requestPart.Split ('&');

				string workShopId = (parts[0].Split('='))[1];

				Model.HelpsData.SelfData.RecordAttendance(requestPart, (callback) => {

					if (!callback)
					{
						View.DisplayAlert("Fail", "Record attandance failed", "okay");
						return;
					}

					var model = (Bookings)Model;

					Booking booking =  model.GetBooking(workShopId);

					if (booking != null)
					{
						if (booking.ReleatedWorkshop == null) {

							AddNewReleatedWorkshop (booking);
						}

						booking.ReleatedWorkshop.BookingStatus = BookingStatuses.Attended;
						View.DisplayAlert("Success", "Record attandance success", "okay");
					}
					else
					{
						View.DisplayAlert("Unkown", "Record attandance success but cannot find booking", "okay");
					}
				});
			}
			catch (NullReferenceException e) {

				Debug.WriteLine ("Invaild request part : " + e.Message);
			}
			catch (IndexOutOfRangeException e) {

				Debug.WriteLine ("Invaild request part : " + e.Message);
			}
		}
	}
}

