﻿using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class WorkshopPage : ContentPage
	{
		public Label ErrorMessageLabel { protected set; get; } = new Label
		{
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Center,
			IsVisible = false,
		};

		public TableView ShopInfoListView { get;} = new TableView
		{
			Intent = TableIntent.Menu,
		};

		public Label TopicLabel { protected set; get; } = new Label
		{
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Center,
		};

		public Label DescriptionLabel { protected set; get; } = new Label
		{
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Center,
			LineBreakMode = LineBreakMode.WordWrap,
		};
			
		public Label DetailInformationLabel { protected set; get; } = new Label
		{
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Center,
		};


		public Button BookButton { protected set; get;} = new Button
		{
			Text = "Book",
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.Center,
		};

		public Button AddToWaitingListButton  { protected set; get;} = new Button
		{
			Text = "Add to waiting list",
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.Center,
			IsVisible = false,
		};

		public Button AddToReminderButton { protected set; get;} = new Button
		{
			Text = "Add to reminder",
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.Center,
		};


		public WorkshopPage ()
		{
			BookButton.BackgroundColor = App.utsBackgroundColor;
			BookButton.TextColor = Color.White;

			AddToReminderButton.BackgroundColor = App.utsBackgroundColor;
			AddToReminderButton.TextColor = Color.White;

			AddToWaitingListButton.BackgroundColor = App.utsBackgroundColor;
			AddToWaitingListButton.TextColor = Color.White;

			ErrorMessageLabel.BackgroundColor = Color.Red;
			ErrorMessageLabel.TextColor = Color.White;
			ErrorMessageLabel.IsVisible = false;

			Content = new StackLayout {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = 
				{ 
					ErrorMessageLabel,
					ShopInfoListView,
					BookButton, 
					AddToWaitingListButton,
					AddToReminderButton,

				}
			};
		}

	
	}
}

