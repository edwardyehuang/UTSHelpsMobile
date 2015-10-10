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
		public WorkShopsController () : base(new WorkShopsPage(), new WorkShops())
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
					TextColor = App.textColor, // text was blue in Android
				};

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
	}
}

