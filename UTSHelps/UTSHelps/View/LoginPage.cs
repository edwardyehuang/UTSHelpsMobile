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
			Placeholder = "Student Number",
			//Text = "12345678",
			//TextColor = Color.White,
		};
		public Entry PasswordEntry { protected set; get; } = new Entry {
			Placeholder = "Password",
			IsPassword = true,
			//Text = "test123",
			//TextColor = Color.White,
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
			
		public Label TitleLabel { protected set; get; } = new Label
		{
			Text = "UTS:Helps",
			FontSize = 45,
			TextColor = Color.White,
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,

		};

		public Frame LoginFrame { protected set; get; }

		protected Grid mainGrid = new Grid {
			VerticalOptions = LayoutOptions.FillAndExpand,
			HorizontalOptions = LayoutOptions.FillAndExpand,
			RowDefinitions = { 
				new RowDefinition {
					Height = new GridLength (7, GridUnitType.Star),
				}, 
				new RowDefinition {
					Height = new GridLength (5, GridUnitType.Star),
				}
			},
		};


		public LoginPage ()
		{
			BackgroundColor = App.utsBackgroundColor;
			var signButtons = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = {SignInButton, OfflineButton},
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			LoginFrame = new Frame {
				HasShadow = false,
				//OutlineColor = Color.Silver,
				Padding = 25,
				BackgroundColor = App.utsBackgroundColor,
				Content = new StackLayout {
					Spacing = 20,
					Children = { TitleLabel, UsernameEntry, PasswordEntry, signButtons },
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
				},
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				//Opacity = 0.75,
			};

			/*
			mainGrid.Children.Add (new WebView{
				Source = new HtmlWebViewSource
				{
					Html = @"<iframe width=""100%"" height=""100%"" src=""https://www.youtube.com/embed/oxKkJfNSq9Y?autoplay=1"" frameborder=""0"" allowfullscreen></iframe>",
				},

				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			}, 0, 1, 0, 2);*/

			mainGrid.Children.Add (new ContentView {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			}, 0, 1, 0, 2);

			mainGrid.Children.Add (LoginFrame
			, 0, 1, 0, 2);

			Content = mainGrid;

		
			UsernameEntry.Focused += (object sender, FocusEventArgs e) => MoveFrameUp();
			PasswordEntry.Focused += (object sender, FocusEventArgs e) => MoveFrameUp();
			UsernameEntry.Unfocused += (object sender, FocusEventArgs e) => MoveFrameDown();
			PasswordEntry.Unfocused += (object sender, FocusEventArgs e) => MoveFrameDown();

		}

		protected void MoveFrameUp ()
		{
			Grid.SetRowSpan (LoginFrame, 1);
		
		}

		protected void MoveFrameDown ()
		{
			Grid.SetRowSpan (LoginFrame, 2);

		}

	}
}

