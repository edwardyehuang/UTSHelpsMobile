using System;
using Xamarin.Forms;
using UTSHelps.UI;

namespace UTSHelps.Controller
{
	public class SimpleSkinController : BaseController
	{
		protected TableView simpleSkinTable = new TableView();
		protected TableSection section = new TableSection ();

		public SimpleSkinController () : base (new ContentPage())
		{
			View.Title = "Simple";
			NavigationPage.SetBackButtonTitle (App.MainNavigationPage, "Back");

			simpleSkinTable.Intent = TableIntent.Menu;
			simpleSkinTable.Root = new TableRoot ();

			AddSkinButton ("UTS Blue", new Color (0, 0.6, 0.8), Color.White);
			AddSkinButton ("Helps Red", new Color (0.91, 0, 0.027), Color.White);
			AddSkinButton ("Edward's purple", new Color (0.58, 0.129, 0.57, 1), Color.White);
			AddSkinButton ("John's love", new Color (0.435, 0.305, 0.215), Color.White);

			simpleSkinTable.Root.Add (section);
			((ContentPage)View).Content = simpleSkinTable;

			View.Appearing += (sender, e) =>  View.BackgroundColor = App.GetContentPageBackgroundColor ();
		}

		public void AddSkinButton (string name, Color color, Color textColor)
		{
			var cell = new TextLabelCell (){ Label = name, LabelColor = Color.White, BackgroundColor = color };

			cell.HasArrow = false;
			cell.Tapped += (sender, e) => {

				App.ApplyNavBarColor(name);
				App.Setting.SetSettingValue ("NavBarColor", name);
			};
			cell.XAlign = TextAlignment.Center;



			section.Add (cell);
		}

		public void ApplyColor(string name)
		{
			

		}



	}
}

