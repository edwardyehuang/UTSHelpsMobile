using System;

using Xamarin.Forms;
using UTSHelps.View;

namespace UTSHelps
{
	public class App : Application
	{
		private NavigationPage mainNavigationPage;
		private Color utsColor = new Color(0, 0.6, 0.8);

		public App ()
		{
			// The root page of your application
			MainPage = mainNavigationPage = new NavigationPage(new MainFrame());

			//The code below can be improved such as using the themes
			mainNavigationPage.BarBackgroundColor = utsColor;
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

