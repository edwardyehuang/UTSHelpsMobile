using System;
using UTSHelps.Model;
using UTSHelps.UI;
using Xamarin.Forms;
using System.Collections;
using System.Diagnostics;

namespace UTSHelps.Controller
{
	public class UICustomController : BaseController
	{
		public TableView SkinTable { get; set; } = new TableView();

		public UICustomController () : base(new ContentPage())
		{
			NavigationPage.SetBackButtonTitle (App.MainNavigationPage, "Back");

			View.Title = "Change Skin";

			SkinTable.Intent = TableIntent.Menu;
			SkinTable.Root = new TableRoot ();

			BuildSkinList ();

			((ContentPage)View).Content = SkinTable;
		}

		public void BuildSkinList()
		{
			TableSection section = new TableSection ();

			Action <string, Action> AddSkinCell = (string text, Action func) => {

				TextLabelCell cell = new TextLabelCell();
				cell.Label = text;
				cell.XAlign = TextAlignment.Start;
				cell.HasArrow = true;

				cell.Tapped += (sender, e) => func();

				section.Add(cell);
			};

			AddSkinCell ("Simple", () => View.Navigation.PushAsync((new SimpleSkinController()).View));
			//AddSkinCell ("Weather Skin", WeatherSkinSetting ());


			SkinTable.Root.Add (section);
		}

		public void SimpleSkinSetting()
		{

		}

		public void WeatherSkinSetting()
		{

		}
	}
}

