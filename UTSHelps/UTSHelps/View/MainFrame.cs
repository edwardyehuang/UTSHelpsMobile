using System;
using UTSHelps;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class MainFrame : TabbedPage
	{
		public MainFrame ()
		{
			this.Title = "UTS Helps";	//Title of the mainframe
			#if __IOS__
			this.BackgroundColor = App.utsBackgroundColor;
			#endif
			NavigationPage.SetBackButtonTitle (this, "Back");
		}

		private ContentPage GetDefaultPage(string title, string text = "")
		{
			if (text.Equals ("")) {
				text = title + "_page";
			}

			return new ContentPage {
				Title = title,
				Content = new Label {
					Text = text,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				},
			};
		}
	}
}

