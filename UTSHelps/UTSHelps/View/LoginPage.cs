using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using UTSHelps;

namespace UTSHelps.View
{
	public class LoginPage : ContentPage
	{
		public Entry UsernameEntry { protected set;  get; } = new Entry {
			Placeholder = "Student Number"
		};
		public Entry PasswordEntry { protected set; get; } = new Entry {
			Placeholder = "Password",
			IsPassword = true
		};
		public Button SignInButton { protected set; get; } = new Button
		{
			Text = "Sign in",
			BackgroundColor = App.utsButtonColor,
			TextColor = Color.White,
			Font = Font.SystemFontOfSize(NamedSize.Medium),
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.FillAndExpand,
		};
		public Button OfflineButton { protected set; get; } = new Button
		{
			Text = "Offline",
			BackgroundColor = App.utsButtonColor,
			TextColor = Color.White,
			Font = Font.SystemFontOfSize(NamedSize.Medium),
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.FillAndExpand,
		};

		protected Label titleLabel = new Label
		{
			Text = "UTS:Helps",
			FontSize = 55,
			TextColor = Color.White,
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,

		};

		public LoginPage ()
		{
			BackgroundColor = App.utsBackgroundColor;
			var signButtons = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = {SignInButton, OfflineButton},
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};


			Content = new StackLayout {
				Spacing = 20,
				Children = { titleLabel, UsernameEntry, PasswordEntry, signButtons },
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
		}
	}
}

