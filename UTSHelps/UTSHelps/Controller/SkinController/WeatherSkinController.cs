using System;
using Xamarin.Forms;
using UTSHelps.UI;

namespace UTSHelps.Controller
{
	public class WeatherSkinController : BaseController
	{
		protected TableView weatherSkinTable = new TableView();
		protected TableSection section = new TableSection ();

		public WeatherSkinController () : base (new ContentPage())
		{
			View.Title = "Weather";
			NavigationPage.SetBackButtonTitle (App.MainNavigationPage, "Back");

			weatherSkinTable.Intent = TableIntent.Menu;
			weatherSkinTable.Root = new TableRoot ();

			AddSkinButton ("UTS Blue", new Color (0, 0.6, 0.8), Color.White);
			AddSkinButton ("Helps Red", new Color (0.91, 0, 0.027), Color.White);
			AddSkinButton ("Edward's purple", new Color (0.58, 0.129, 0.57), Color.White);
			AddSkinButton ("John's Chocolate", new Color (0435, 0.305, 0.215), Color.White);

			weatherSkinTable.Root.Add (section);
			((ContentPage)View).Content = weatherSkinTable;
		}

		public void AddSkinButton (string name, Color color, Color textColor)
		{
			var cell = new TextLabelCell (){ Label = name, LabelColor = Color.White, BackgroundColor = color };

			cell.HasArrow = false;
			cell.Tapped += (sender, e) => App.MainNavigationPage.BarBackgroundColor = color;
			cell.XAlign = TextAlignment.Center;

			App.MainNavigationPage.BarTextColor = textColor;
			App.MainNavigationPage.BackgroundColor = color;

			section.Add (cell);
		}



	}
}

