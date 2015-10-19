using System;
using UTSHelps.View;
using UTSHelps.Model;
using Xamarin.Forms;
using System.Collections;
using System.Diagnostics;

namespace UTSHelps.Controller
{
	public class WorkShopsController : BaseController
	{
		public WorkShopsController (MainData mainData) : base(new WorkShopsPage(), mainData.WorkShopsData)
		{

		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			WorkShops shops = (WorkShops)Model;

			shops.UpdateData ();
		}

		public override void UpdateView ()
		{
			base.UpdateView ();

			WorkShops shops = (WorkShops)Model;
			WorkShopsPage page = (WorkShopsPage)View;

			TableSection section = new TableSection ();

			foreach (Workshop shop in shops.Shops) {

				TextCell cell = new TextCell {
					Text = shop.Id + " " + shop.Name,
					Detail = shop.Archived,

				};

				var cellAction = new MenuItem ();

				if (shop.BookingStatus == BookingStatuses.Booked) {

					cellAction.Text = "Cancel";
					cellAction.IsDestructive = false;
					cellAction.Clicked += (sender, e) => CancelWorkShop (shop);

				} else if (shop.BookingStatus == BookingStatuses.NotBooked) {

					cellAction.Text = "Book";
					cellAction.IsDestructive = false;
					cellAction.Clicked += (sender, e) => BookWorkShop (shop);
				} else if (shop.BookingStatus == BookingStatuses.Booking) {

					cellAction.Text = "Booking";
					cellAction.IsDestructive = false;
				} else {

					cellAction.Text = "Canceling";
					cellAction.IsDestructive = false;
				}

				cell.ContextActions.Add (cellAction);

				cell.Tapped += (object sender, EventArgs e) => ShowSectionsInWorkshop (shop);
				section.Add (cell);
			}

			(page.ShopsListView.Root = new TableRoot ()).Add (section);
		}

		public void ShowSectionsInWorkshop(Workshop workShop)
		{
			if (workShop.WorkShopSessions == null) {
				workShop.WorkShopSessions = new Sessions () {
					RelatedWorkshop = workShop,
				};
			}

			View.Navigation.PushAsync(new SessionsController(workShop.WorkShopSessions).View);
		}

		public void BookWorkShop(Workshop shop)
		{
			Debug.WriteLine ("Request to book workshop : ID = " + shop.Id);	
			shop.Book ();
		}

		public  void CancelWorkShop(Workshop shop)
		{
			Debug.WriteLine ("Request to cancel workshop : ID = " + shop.Id);	
			shop.Cancel ();
		}


	}
}

