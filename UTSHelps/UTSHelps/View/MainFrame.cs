using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class MainFrame : TabbedPage
	{
		public MainFrame ()
		{
			this.Title = "UTS Helps";	//Title of the mainframe
			BuildChildViews ();
		}

		protected void BuildChildViews()
		{
			this.Children.Add (new LatestPage ());
			this.Children.Add (GetDefaultPage ("Sessions"));
			this.Children.Add (GetDefaultPage ("Booking"));
			this.Children.Add (GetDefaultPage ("MySelf"));
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

