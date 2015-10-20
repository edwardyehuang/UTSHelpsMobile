using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class WorkshopPage : ContentPage
	{
		public Label TopicLabel { protected set; get; } = new Label
		{
			Text = "Topic",
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Center,
		};

		public Label DescriptionLabel { protected set; get; } = new Label
		{
			Text = "Description",
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Center,
			LineBreakMode = LineBreakMode.WordWrap,
		};

		public Button BookButton { protected set; get;} = new Button
		{
			Text = "Book",
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.Center,
		};


		public WorkshopPage ()
		{
			BookButton.BackgroundColor = App.utsBackgroundColor;
			BookButton.TextColor = Color.White;

			Content = new StackLayout {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { TopicLabel, DescriptionLabel, BookButton }
			};
		}
	}
}

