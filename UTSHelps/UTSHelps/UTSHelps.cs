using System;

using Xamarin.Forms;
using UTSHelps.View;
using UTSHelps.Controller;
using UTSHelps.DependencyServices;


namespace UTSHelps
{
	public class App : Application
	{
		public static NavigationPage MainNavigationPage {get ;set;}
		private MainFrameController mainFrame = new MainFrameController ();
		public static Color utsBackgroundColor = new Color(0, 0.6, 0.8);
		public static Color utsButtonColor = new Color(0, 0.745, 1);
		public static Color textColor = new Color (0.2, 0.2, 0.2);


		public static ISetting Setting {
			get {
				return DependencyService.Get<ISetting> ();
			}
		}

		public App ()
		{
			// The root page of your application
			MainPage = MainNavigationPage = new NavigationPage(mainFrame.View);
			NavigationPage.SetBackButtonTitle (MainNavigationPage, "Back");

			//The code below can be improved such as using the themes
			MainNavigationPage.BarBackgroundColor = utsBackgroundColor;
			MainNavigationPage.BarTextColor = Color.White;

			//Read Theme
			MainNavigationPage.BackgroundColor = new Color(1, 1, 1, 1);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts

			ApplyNavBarColor (App.Setting.GetSettingValue ("NavBarColor"));

		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		public static void ApplyNavBarColor(string colorName)
		{
			if (colorName == null)
				return;

			if (colorName.Equals (""))
				return;


			if (colorName.Equals ("UTS Blue"))
				ApplyNavBarColor (new Color (0, 0.6, 0.8), Color.White);
			else if (colorName.Equals("Helps Red"))
				ApplyNavBarColor (new Color (0.91, 0, 0.027), Color.White);
			else if (colorName.Equals("Edward's purple"))
				ApplyNavBarColor (new Color (0.58, 0.129, 0.57, 1), Color.White);
			else if (colorName.Equals("John's love"))
				ApplyNavBarColor (new Color (0.435, 0.305, 0.215), Color.White);

		}

		public static void ApplyNavBarColor(Color color, Color textColor)
		{
			App.MainNavigationPage.BarTextColor = textColor;
			App.MainNavigationPage.BarBackgroundColor = color;
		}

		public static Color GetContentPageBackgroundColor()
		{
			string name = App.Setting.GetSettingValue ("pageBackground");

			if (name == null) {

				return new Color (0.85, 0.85, 0.85, 1);
			} else if (!name.Equals ("Simple") && !name.Equals ("")) {
				return new Color (1, 1, 1, 0.2);
			}


			return new Color (0.85, 0.85, 0.85, 1);
		}
			
			

	}
}


