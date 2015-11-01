using System;
using Xamarin.Forms;
using UTSHelps.UI;

namespace UTSHelps.View
{
	public class SearchView : ContentPage
	{

		public TableView SuggestionListView { get;} = new TableView()
		{
			VerticalOptions = LayoutOptions.Start,
			HasUnevenRows = true,
		};
		public SuperEntry SearchEntry { protected set;  get; } = new SuperEntry {
			Placeholder = "Input any keyword here",
			VerticalOptions = LayoutOptions.Start,
		};
		public Button CloseBtn { get;} = new Button
		{
			Text = "✖",
			FontSize = 45,
			TextColor = Color.White,
			HorizontalOptions = LayoutOptions.End,
		};

		public Label TitleLabel { protected set; get; } = new Label
		{
			Text = "Search",
			FontSize = 45,
			TextColor = Color.White,
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Start,

		};

		public SearchView ()
		{
			BackgroundColor = App.utsBackgroundColor;

			SearchEntry.BackgroundColor = Color.White;


			var frame = new Frame {
				HasShadow = false,
		//		OutlineColor = Color.Silver,
				Padding = 25,
				Content = new StackLayout {
					Spacing = 20,
					Children = { SearchEntry, SuggestionListView},
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
				},
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			

			Content = new StackLayout {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {new Label() {FontSize = 25, Text = " "}, CloseBtn, TitleLabel, frame, 
					new Label() {FontSize = 175, Text = " "}}
			};

			SuggestionListView.IsVisible = false;
			SearchEntry.Focus ();
		
		}
	}
}

