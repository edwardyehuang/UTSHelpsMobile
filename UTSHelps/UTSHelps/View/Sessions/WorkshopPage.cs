using System;
using Xamarin.Forms;
using UTSHelps.UI;

namespace UTSHelps.View
{
	public class WorkshopPage : ContentPage
	{
		public Label ErrorMessageLabel { protected set; get; } = new Label
		{
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.Center,
			IsVisible = true,
		};

		public TableView ShopInfoListView { get;} = new TableView
		{
			Intent = TableIntent.Menu,
		};

		public TextLabelCell BookButton { protected set; get;} = new TextLabelCell
		{
			Label = "Book",
			XAlign = TextAlignment.Center,
		};

		public TextLabelCell AddToWaitingListButton  { protected set; get;} = new TextLabelCell
		{
			Label = "Add to waiting list",
			XAlign = TextAlignment.Center,
			IsVisible = true,
		};

		public TextLabelCell AddToReminderButton { protected set; get;} = new TextLabelCell
		{
			Label = "Add to reminder",
			XAlign = TextAlignment.Center,
			IsVisible = true,
		};


		public WorkshopPage ()
		{
			NavigationPage.SetBackButtonTitle (App.MainNavigationPage, "Back");

			BookButton.BackgroundColor = Color.Green;
			BookButton.LabelColor = Color.White;


			AddToReminderButton.BackgroundColor = App.utsBackgroundColor;
			AddToReminderButton.LabelColor = Color.White;
			AddToReminderButton.IsVisible = false;

			AddToWaitingListButton.BackgroundColor = App.utsBackgroundColor;
			AddToWaitingListButton.LabelColor = Color.White;

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
				}
			};
		}

	
	}
}

