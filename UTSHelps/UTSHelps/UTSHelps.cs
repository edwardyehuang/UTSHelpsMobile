using System;

using Xamarin.Forms;
using UTSHelps.View;
using UTSHelps.Controller;
using UTSHelps.DependencyServices;

namespace UTSHelps
{
	public class App : Application
	{
		private NavigationPage mainNavigationPage;
		private MainFrameController mainFrame = new MainFrameController ();
		public static Color utsBackgroundColor = new Color(0, 0.6, 0.8);
		public static Color utsButtonColor = new Color(0, 0.745, 1);
		public static Color textColor = new Color(0.2, 0.2, 0.2);

		public static ISetting Setting {
			get {
				return DependencyService.Get<ISetting> ();
			}
		}

		public App ()
		{
			// The root page of your application
			MainPage = mainNavigationPage = new NavigationPage(mainFrame.View);
			NavigationPage.SetBackButtonTitle (mainNavigationPage, "Back");

			//The code below can be improved such as using the themes
			mainNavigationPage.BarBackgroundColor = utsBackgroundColor;
			mainNavigationPage.BarTextColor = Color.White;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

