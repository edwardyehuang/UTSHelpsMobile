using System;
using Xamarin.Forms;
using UTSHelps.UI;

namespace UTSHelps.View
{
	public class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			Content = new TableView {
				Root = new TableRoot {
					new TableSection {
						new TextLabelCell {
							Label = "UTS : Helps",
						}
					},
					new TableSection {
						new TextLabelCell {
							Label = "Copyright © Group 15 2015",
						}
					}
				},
				BackgroundColor = new Color (1, 1, 1, 0),
				Intent = TableIntent.Menu

			};

			BackgroundColor = new Color (1, 1, 1, 0.2);

		}
	}
}

