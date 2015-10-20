using System;
using UTSHelps.View;
using UTSHelps.Model;
using Xamarin.Forms;
using System.Collections;
using System.Diagnostics;

namespace UTSHelps.Controller
{
	public class WorkshopController : BaseController
	{
		public WorkshopController (Workshop session) : base(new WorkshopPage(), session)
		{
			
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

			page.Title = session.topic;

			page.TopicLabel.Text = "Topic : " + session.topic;
			page.DescriptionLabel.Text = "Description : " + session.description;

			if (session.BookingStatus == BookingStatuses.Booked)
				page.BookButton.Text = "Cancel";
			else if (session.BookingStatus == BookingStatuses.Canceling)
				page.BookButton.Text = "Canceling...";
			else if (session.BookingStatus == BookingStatuses.NotBooked)
				page.BookButton.Text = "Book";
			else if (session.BookingStatus == BookingStatuses.Booking)
				page.BookButton.Text = "Booking...";
			
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

