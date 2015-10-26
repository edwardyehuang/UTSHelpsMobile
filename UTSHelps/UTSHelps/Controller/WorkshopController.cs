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
			AddInformation ("Description", session.description, () => PopTextPage("Description", session.description));
			AddInformation ("Start Date", session.StartDate.Replace("T", " "));
			AddInformation ("End Data", session.EndDate.Replace("T", " "));
			AddInformation ("Cut off", session.cutoff);
			AddInformation ("Booking Count", session.BookingCount);
			AddInformation ("Reminder number", session.reminder_num);
			AddInformation ("Reminder sent", session.reminder_sent);
			AddInformation ("Days of week", session.DaysOfWeek);

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

/*			#else
			TextCell cell = new TextCell();
			cell.Text = label + " : " + text;
			section.Add(cell);
			#endif*/
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

