using System;
using UTSHelps.View;
using UTSHelps.Model;
using Xamarin.Forms;
using System.Collections;
using System.Diagnostics;
using System.Text;
using UTSHelps.UI;

namespace UTSHelps.Controller
{
	public class WorkshopController : BaseController
	{
		protected TableSection section = new TableSection ();

		public WorkshopController (Workshop session) : base(new WorkshopPage(), session)
		{
			session.ErrorMessage = "";
		}

		public override void RegViewEvents ()
		{
			base.RegViewEvents ();

			Workshop session = (Workshop)Model;
			WorkshopPage page = (WorkshopPage)View;

			page.BookButton.Clicked += (object sender, EventArgs e) => 
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
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			Workshop session = (Workshop)Model;
			WorkshopPage page = (WorkshopPage)View;

			section = new TableSection ();

			page.Title = session.topic;

			AddInformation ("Topic", session.topic);
			AddInformation ("Description", session.description);
			AddInformation ("Start Date", session.StartDate.Replace("T", " "));
			AddInformation ("End Data", session.EndDate.Replace("T", " "));
			AddInformation ("Cut off", session.cutoff);
			AddInformation ("Booking Count", session.BookingCount);
			AddInformation ("Reminder number", session.reminder_num);
			AddInformation ("Reminder sent", session.reminder_sent);
			AddInformation ("Days of week", session.DaysOfWeek);

			(page.ShopInfoListView.Root = new TableRoot ()).Add (section);


			if (session.BookingStatus == BookingStatuses.Booked)
				page.BookButton.Text = "Cancel";
			else if (session.BookingStatus == BookingStatuses.Canceling)
				page.BookButton.Text = "Canceling...";
			else if (session.BookingStatus == BookingStatuses.NotBooked)
				page.BookButton.Text = "Book";
			else if (session.BookingStatus == BookingStatuses.Booking)
				page.BookButton.Text = "Booking...";

			page.AddToReminderButton.IsVisible = session.BookingStatus == BookingStatuses.Booked;
			page.AddToReminderButton.IsVisible = session.BookingStatus == BookingStatuses.Booked;

			if (page.ErrorMessageLabel.IsVisible = !session.ErrorMessage.Equals ("")) {

				page.ErrorMessageLabel.Text = session.ErrorMessage;
				page.AddToWaitingListButton.IsVisible = true;
			}


			
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
			cell.HasArrow = action != null;
			section.Add(cell);

/*			#else
			TextCell cell = new TextCell();
			cell.Text = label + " : " + text;
			section.Add(cell);
			#endif*/
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

		public  void CancelWorkShop(Workshop shop)
		{
			Debug.WriteLine ("Request to cancel workshop : ID = " + shop.WorkshopId);	
			shop.Cancel ();
		}
	}
}

