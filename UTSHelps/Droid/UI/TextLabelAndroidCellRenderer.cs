using System;
using System.Collections.Generic;
using System.Linq;

using Android.Widget;
using Android.App;
using Android.Views;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using UTSHelps.UI;
using UTSHelps.Droid;

[assembly: ExportRenderer (typeof(TextLabelCell), typeof(TextLabelAndroidCellRenderer))]
namespace UTSHelps.Droid
{
	public class TextLabelAndroidCellRenderer : ViewCellRenderer
	{
		protected override Android.Views.View GetCellCore (Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
		{
			var cell = (TextLabelCell)item;

			var view = convertView;

			if (view == null) {
				
				view = new Android.Widget.RelativeLayout (context);
			}

			TextView label = new TextView (context);
			label.Text = cell.Label;
			label.SetTextColor (cell.LabelColor.ToAndroid ());

			if (cell.XAlign == Xamarin.Forms.TextAlignment.Start)
				label.Gravity = GravityFlags.Left | GravityFlags.CenterVertical;
			else if (cell.XAlign == Xamarin.Forms.TextAlignment.Center) {
				label.Gravity = GravityFlags.Center;
			}

			TextView DetailText = new TextView (context);
			label.Text = cell.Label;
			label.SetTextColor (cell.LabelColor.ToAndroid ());
			DetailText.Gravity = GravityFlags.Right | GravityFlags.CenterVertical;

			((Android.Widget.RelativeLayout)view).AddView (label);
			((Android.Widget.RelativeLayout)view).AddView (DetailText);

			view.SetBackgroundColor (cell.BackgrondColor.ToAndroid ());
			

			return view;
		}
	}
}

