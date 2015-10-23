using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UTSHelps.UI;
using UTSHelps.iOS;

[assembly: ExportRenderer (typeof(TextLabelCell), typeof(TextLabeliOSCellRenderer))]
namespace UTSHelps.iOS
{
	public class TextLabeliOSCellRenderer : ViewCellRenderer
	{
		static NSString rid = new NSString("TextLabelCell");

		public TextLabeliOSCellRenderer ()
		{
			 
		}

		public override UITableViewCell GetCell (Xamarin.Forms.Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var cell = (TextLabelCell)item;

			TextLabeliOSCell nativeCell = reusableCell as TextLabeliOSCell;

			if (nativeCell == null)
				nativeCell = new TextLabeliOSCell (rid);

			nativeCell.UpdateCell (cell.Label, cell.Text);
			nativeCell.Accessory = cell.HasArrow ? UITableViewCellAccessory.DisclosureIndicator : UITableViewCellAccessory.None;


			return nativeCell;
		}
	}
}

