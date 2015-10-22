using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class WorkShopSetsPage : ContentPage
	{
		public TableView ShopSetsListView { get;} = new TableView();


		public WorkShopSetsPage ()
		{
			Title = "WorkShop";
			Icon = "icon_sessions";

			ShopSetsListView.Intent = TableIntent.Menu;
			Content = ShopSetsListView;


		}
	}
}

