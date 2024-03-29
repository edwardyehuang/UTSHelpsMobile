﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using CoreGraphics;
using CoreAnimation;

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

			if (nativeCell == null) {

				var style = cell.Text == null ?
					UITableViewCellStyle.Default : (cell.Text.Equals("") ? 
						UITableViewCellStyle.Default : UITableViewCellStyle.Value1);
				
				nativeCell = new TextLabeliOSCell (rid, style);
			}

			nativeCell.TextLabel.Text = cell.Label;

			if (cell.Text != null && nativeCell.DetailTextLabel != null) {
				nativeCell.DetailTextLabel.Text = cell.Text;
				nativeCell.DetailTextLabel.TextColor = new UIColor (0, 0, 0, 0.65f);

			} 

			nativeCell.Accessory = cell.HasArrow ? UITableViewCellAccessory.DisclosureIndicator : UITableViewCellAccessory.None;

			if (cell.XAlign == TextAlignment.Start)
				nativeCell.TextLabel.TextAlignment = UITextAlignment.Left;
			else if (cell.XAlign == TextAlignment.Center)
				nativeCell.TextLabel.TextAlignment = UITextAlignment.Center;
			else
				nativeCell.TextLabel.TextAlignment = UITextAlignment.Right;

			nativeCell.BackgroundColor = cell.BackgroundColor.ToUIColor ();
			nativeCell.TextLabel.TextColor = cell.LabelColor.ToUIColor ();
			

			//Add shadow
			if (cell.HasLabelShadow) {
				nativeCell.TextLabel.Layer.ShadowColor = nativeCell.TextLabel.TextColor.CGColor;
				nativeCell.TextLabel.Layer.ShadowOffset = new CGSize (0, 0);
				nativeCell.TextLabel.Layer.ShadowRadius = 5;
				nativeCell.TextLabel.Layer.ShadowOpacity = 0.5f;

				//nativeCell.TextLabel.Layer.ShadowPath = UIBezierPath.FromRect (nativeCell.Bounds).CGPath;
			}

			return nativeCell;
		}
	}
}

