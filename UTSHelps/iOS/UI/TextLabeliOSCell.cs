using System;

using Foundation;
using UIKit;

using Xamarin.Forms.Platform.iOS;

namespace UTSHelps.iOS
{
	public class TextLabeliOSCell : UITableViewCell
	{
		public TextLabeliOSCell (NSString cellId) : base (UITableViewCellStyle.Value1, cellId)
		{
			Accessory = UITableViewCellAccessory.DisclosureIndicator;
		}

		public void UpdateCell (string label, string text)
		{
			TextLabel.Text = label;
			DetailTextLabel.Text = text;
		}
	}
}

