using System;
using Xamarin.Forms;
using UTSHelps.UI;

namespace UTSHelps.Controller
{
	public class BackgroundSkinController : BaseController
	{
		protected TableView backgroundSkinTable = new TableView();
		protected TableSection section = new TableSection ();

		public BackgroundSkinController () : base (new ContentPage())
		{
			View.Title = "Weather";
			NavigationPage.SetBackButtonTitle (App.MainNavigationPage, "Back");

			backgroundSkinTable.Intent = TableIntent.Menu;
			backgroundSkinTable.Root = new TableRoot ();
			backgroundSkinTable.BackgroundColor = new Color (1, 1, 1, 0);

			AddSkinButton ("Simple");
			AddSkinButton ("Building11");

			backgroundSkinTable.Root.Add (section);
			((ContentPage)View).Content = backgroundSkinTable;

			View.BackgroundColor = App.GetContentPageBackgroundColor ();

			View.Appearing += (sender, e) =>  View.BackgroundColor = App.GetContentPageBackgroundColor ();
		}

		public void AddSkinButton (string name)
		{
			var cell = new TextLabelCell (){ Label = name };

			cell.HasArrow = false;
			cell.Tapped += (sender, e) => {

				App.Setting.SetSettingValue ("pageBackground", name);
				View.BackgroundColor = App.GetContentPageBackgroundColor();
			};
			cell.XAlign = TextAlignment.Center;


			section.Add (cell);
		}



	}
}

