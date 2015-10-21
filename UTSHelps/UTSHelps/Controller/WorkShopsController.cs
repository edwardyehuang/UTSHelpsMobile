using System;
using UTSHelps.View;
using UTSHelps.Model;
using Xamarin.Forms;
using System.Collections;
using System.Diagnostics;

namespace UTSHelps.Controller
{
	public class WorkshopsController : BaseController
	{
		public WorkshopsController (Workshops sessions) : base(new WorkshopsPage(), sessions)
		{
			
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			Workshops sessions = (Workshops)Model;

			sessions.UpdateData ();
		}

		public override void UpdateView ()
		{
			base.UpdateView ();

			Workshops sessions = (Workshops)Model;
			WorkshopsPage page = (WorkshopsPage)View;

			page.Title = sessions.RelatedWorkshopSet.Name;

			TableSection section = new TableSection ();

			foreach (Workshop session in sessions.workshops) {

				TextCell cell = new TextCell {
					Text = session.WorkshopId + " " + session.topic,
					TextColor = App.textColor, 
				};

				var cellAction = new MenuItem ();

				if (session.BookingStatus == BookingStatuses.Booked) {

					cellAction.Text = "Cancel";
					cellAction.IsDestructive = false;
					cellAction.Clicked += (sender, e) => CancelWorkShop (session);

				} else if (session.BookingStatus == BookingStatuses.NotBooked) {

					cellAction.Text = "Book";
					cellAction.IsDestructive = false;
					cellAction.Clicked += (sender, e) => BookWorkShop (session);
				} else if (session.BookingStatus == BookingStatuses.Booking) {

					cellAction.Text = "Booking";
					cellAction.IsDestructive = false;
				} else {

					cellAction.Text = "Canceling";
					cellAction.IsDestructive = false;
				}

				cell.ContextActions.Add (cellAction);

				cell.Tapped += (object sender, EventArgs e) => ShowSelectedWorkshop (session);
				section.Add (cell);
			}

			(page.SessionsListView.Root = new TableRoot ()).Add (section);
		}

		public void ShowSelectedWorkshop(Workshop workshop)
		{
			//View.Navigation.PushAsync(new SessionsController(workShop.WorkShopSessions).View);
			View.Navigation.PushAsync(new WorkshopController(workshop).View);
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

