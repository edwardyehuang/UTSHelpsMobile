using System;
using Xamarin.Forms;

namespace UTSHelps.View
{
	public class MySelfPage : ContentPage
	{
		public TableView SelfTable { protected set; get;}
		public TableSection BasicInfoSection { protected set; get;}

		public ImageCell AvatarCell { protected set; get;} = new ImageCell
		{
			Text = "Default User",
			ImageSource = "icon_self",
			Detail = "Default user info",
			TextColor = App.textColor, // text was blue in Android

		};

		public MySelfPage ()
		{
			Title = "MySelf";
			Icon = "icon_self";
			NavigationPage.SetBackButtonTitle (this, "Back");

			BasicInfoSection = new TableSection {
				AvatarCell,
			};

			Content = SelfTable = new TableView {
				Intent = TableIntent.Form,
				Root = new TableRoot {
					BasicInfoSection
				}
			};
		}


	}
}

