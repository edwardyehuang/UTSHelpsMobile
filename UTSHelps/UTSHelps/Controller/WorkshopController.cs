using System;
using UTSHelps.View;
using UTSHelps.Model;
using Xamarin.Forms;
using System.Collections;
using System.Diagnostics;
using System.Text;
using UTSHelps.UI;
using UTSHelps.DependencyServices;

namespace UTSHelps.Controller
{
	public class WorkshopController : BaseController
	{
		protected TableSection section = new TableSection ();
		protected TableSection buttonSection = new TableSection ();

		public WorkshopController (Workshop session) : base(new WorkshopPage(), session)
		{
			session.ErrorMessage = "";
		}

		public override void RegViewEvents ()
		{
			base.RegViewEvents ();

			Workshop session = (Workshop)Model;
			WorkshopPage page = (WorkshopPage)View;

			page.BookButton.Tapped += (object sender, EventArgs e) => 
			{
				if (session.BookingStatus == BookingStatuses.Booked)
				{
					CancelWorkShop(session);
				}
				else if (session.BookingStatus == BookingStatuses.NotBooked)
				{
					BookWorkShop(session);
				}
			};

			page.AddToWaitingListButton.Tapped += (sender, e) => WaitingWorkShop(session);

			page.AddToReminderButton.Tapped += (sender, e) => {
				try
				{
					DependencyService.Get<IEvent>().AddEvent(session.topic, session.GetStartDate(), session.GetEndDate());
				}
				catch (Exception exception)
				{
					throw exception;
				}
			};
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			Workshop session = (Workshop)Model;
			WorkshopPage page = (WorkshopPage)View;

			section = new TableSection ();

			page.Title = session.topic;

			AddInformation ("Topic", session.topic);
			AddInformation ("ID", session.WorkshopId);
			AddInformation ("Description", session.description, () => PopTextPage("Description", session.description));
			AddInformation ("Start Date", session.StartDate.Replace("T", " "));
			AddInformation ("End Data", session.EndDate.Replace("T", " "));
			AddInformation ("Cut off", session.cutoff);
			AddInformation ("Booking Count", session.BookingCount);

			string daysOfWeekShort = session.DaysOfWeek;
			if (daysOfWeekShort != null) {
				
				daysOfWeekShort = daysOfWeekShort.Replace ("1", "Mon");
				daysOfWeekShort = daysOfWeekShort.Replace ("2", "Tue");
				daysOfWeekShort = daysOfWeekShort.Replace ("3", "Wed");
				daysOfWeekShort = daysOfWeekShort.Replace ("4", "Thur");
				daysOfWeekShort = daysOfWeekShort.Replace ("5", "Fri");
				daysOfWeekShort = daysOfWeekShort.Replace ("6", "Sat");
				daysOfWeekShort = daysOfWeekShort.Replace ("7", "Sun");
				daysOfWeekShort = daysOfWeekShort.Replace ("0", "Sun");

				string daysOfWeekFull = session.DaysOfWeek;
				daysOfWeekFull = daysOfWeekFull.Replace ("1", "Monday");
				daysOfWeekFull = daysOfWeekFull.Replace ("2", "Tuesday");
				daysOfWeekFull = daysOfWeekFull.Replace ("3", "Wednesday");
				daysOfWeekFull = daysOfWeekFull.Replace ("4", "Thursday");
				daysOfWeekFull = daysOfWeekFull.Replace ("5", "Friday");
				daysOfWeekFull = daysOfWeekFull.Replace ("6", "Saturday");
				daysOfWeekFull = daysOfWeekFull.Replace ("7", "Sunday");
				daysOfWeekFull = daysOfWeekFull.Replace ("0", "Sunday");

				string[] weeks = daysOfWeekFull.Split (',');
			
				if (weeks.Length < 2) {

					AddInformation ("Days of week", daysOfWeekFull);
				}
				else 
				{
					AddInformation ("Days of week", daysOfWeekShort, () => PopTablePage ("Description", weeks));
				}
			}

			if (session.BookingStatus == BookingStatuses.Booked) {
				page.BookButton.Label = "Cancel";
				page.BookButton.BackgroundColor = Color.Red;
			} else if (session.BookingStatus == BookingStatuses.Canceling)
				page.BookButton.Label = "Canceling...";
			else if (session.BookingStatus == BookingStatuses.NotBooked) {
				page.BookButton.Label = "Book";
				page.BookButton.BackgroundColor = Color.Green;
			}
			else if (session.BookingStatus == BookingStatuses.Booking)
				page.BookButton.Label = "Booking...";

			page.AddToReminderButton.IsVisible = (session.BookingStatus == BookingStatuses.Booked);

			if (session.cutoff != null && session.BookingCount != null) {

				int bookingCount, cutoff;

				if (int.TryParse (session.BookingCount, out bookingCount) && int.TryParse (session.cutoff, out cutoff)) {

					int diff = bookingCount - cutoff;

					if (diff > 0) {
						AddInformation ("Student in waiting", diff.ToString ());
						page.BookButton.IsVisible = false;
						page.AddToWaitingListButton.IsVisible = true;
					} else {
						page.BookButton.IsVisible = true;
						page.AddToWaitingListButton.IsVisible = false;
					}
				}
			} else {

				page.BookButton.IsVisible = true;
				page.AddToWaitingListButton.IsVisible = false;
			}

			if (page.ErrorMessageLabel.IsVisible = !session.ErrorMessage.Equals ("")) {

				page.ErrorMessageLabel.Text = session.ErrorMessage;
				page.AddToWaitingListButton.IsVisible = true;
			}

			(page.ShopInfoListView.Root = new TableRoot ()).Add (section);

			buttonSection = new TableSection ();

			if (page.BookButton.IsVisible)
				buttonSection.Add (page.BookButton);
			if (page.AddToWaitingListButton.IsVisible)
				buttonSection.Add (page.AddToWaitingListButton);
			if (page.AddToReminderButton.IsVisible)
				buttonSection.Add (page.AddToReminderButton);
			
			page.ShopInfoListView.Root.Add (buttonSection);
		}

		public void AddInformation (string label, string text, Action action = null)
		{
			if (text == null)
				return;

			if (text.Equals (""))
				return;

			TextLabelCell cell = new TextLabelCell();
			cell.Label = label;
			cell.Text = text;

			if (cell.HasArrow = action != null) {

				cell.Tapped += (sender, e) => action();
			}

			section.Add(cell);
		}

		public void PopTextPage(string title, string text)
		{
			var page = new ContentPage {
				Title = title,
				Content = new Label {
					Text = text,
				}
			};

			View.Navigation.PushAsync (page);
		}

		public void PopTablePage (string title, string []texts)
		{
			TableView table = new TableView {
				Root = new TableRoot (),
				BackgroundColor = new Color(1, 1, 1, 0),
			};

			TableSection section = new TableSection ();

			foreach (string text in texts) {

				section.Add (new TextLabelCell {
					Label = text
				});
			}

			table.Root.Add (section);
				

			var page = new ContentPage {
				Title = title,
				Content = table,
				BackgroundColor = new Color(1, 1, 1, 0.2)
			};

			View.Navigation.PushAsync (page);
		}


		public override void UpdateView ()
		{
			base.UpdateView ();

			UpdateData ();
		}

		public void BookWorkShop(Workshop shop)
		{
			Debug.WriteLine ("Request to book workshop : ID = " + shop.WorkshopId);	
			shop.Book ();
		}

		public void CancelWorkShop(Workshop shop)
		{
			Debug.WriteLine ("Request to cancel workshop : ID = " + shop.WorkshopId);	
			shop.Cancel ();
		}

		public void WaitingWorkShop(Workshop shop)
		{
			Debug.WriteLine ("Request to waiting workshop : ID = " + shop.WorkshopId);	
			shop.AddToWaitingList ();
		}
		
	}
}

