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
				view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.cell, null);
			}
				
			TextView label =  (Android.Widget.TextView)view.FindViewById (Resource.Id.textLabel);
			label.Text = cell.Label;

			label.SetTextColor (cell.LabelColor.ToAndroid ());

			if (cell.XAlign == Xamarin.Forms.TextAlignment.Center) {
				label.Gravity = GravityFlags.Center;
			}

			// Detail on the right
			TextView DetailText = (Android.Widget.TextView) view.FindViewById (Resource.Id.detailTextLabel);

			if (cell.Text != null)
				DetailText.Text = cell.Text;
			else
				DetailText.Visibility = Android.Views.ViewStates.Invisible;

			view.SetBackgroundColor (cell.BackgroundColor.ToAndroid ());

			return view;
		}
	}
}

