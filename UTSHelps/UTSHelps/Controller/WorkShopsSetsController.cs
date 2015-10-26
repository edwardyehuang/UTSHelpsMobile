using System;
using UTSHelps.View;
using UTSHelps.Model;
using Xamarin.Forms;
using System.Collections;
using System.Diagnostics;

namespace UTSHelps.Controller
{
	public class WorkShopsSetsController : BaseController
	{
		public WorkShopsSetsController (MainData mainData) : base(new WorkShopSetsPage(), mainData.WorkShopsData)
		{
			View.ToolbarItems.Add(new ToolbarItem ("Search", "ic_search.png", OnPressedSearch));
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			WorkShopSets shops = (WorkShopSets)Model;

			shops.UpdateData ();
		}

		public override void UpdateView ()
		{
			base.UpdateView ();

			WorkShopSets shops = (WorkShopSets)Model;
			WorkShopSetsPage page = (WorkShopSetsPage)View;

			TableSection section = new TableSection ();

			foreach (WorkshopSet shop in shops.Sets) {

				TextCell cell = new TextCell {
					Text = shop.Name,
					Detail = shop.Archived,
					TextColor = App.textColor, 
				};

				cell.Tapped += (sender, e) => ShowSectionsInWorkshopSet (shop);
				section.Add (cell);
			}

			(page.ShopSetsListView.Root = new TableRoot ()).Add (section);
		}

		public void ShowSectionsInWorkshopSet(WorkshopSet workShop)
		{
			if (workShop.SetWorkshops == null) {
				workShop.SetWorkshops = new Workshops () {
					RelatedWorkshopSet = workShop,
					HelpsData = workShop.HelpsData,
				};
			}

			View.Navigation.PushAsync(new WorkshopsController(workShop.SetWorkshops).View);
		}
	}
}

