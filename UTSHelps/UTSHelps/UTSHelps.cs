﻿using System;

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

