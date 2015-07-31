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
		};

		public MySelfPage ()
		{
			Title = "MySelf";
			Icon = "icon_self";

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

