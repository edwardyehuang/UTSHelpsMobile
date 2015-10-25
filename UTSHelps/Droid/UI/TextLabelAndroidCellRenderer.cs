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

			var layout1 = new LinearLayout (context);

			TextView label = new TextView (context);
			label.Text = cell.Label;
			label.SetTextColor (cell.LabelColor.ToAndroid ());
			label.TextSize = 24;

			if (cell.XAlign == Xamarin.Forms.TextAlignment.Start)
				label.Gravity = GravityFlags.Left | GravityFlags.CenterVertical;
			else if (cell.XAlign == Xamarin.Forms.TextAlignment.Center) {
				label.Gravity = GravityFlags.Center;
			}

			var layout3 = new LinearLayout (context);


			TextView DetailText = new TextView (context);
			label.Text = cell.Label;
			label.SetTextColor (cell.LabelColor.ToAndroid ());
			DetailText.Gravity = GravityFlags.Left | GravityFlags.CenterVertical;

		
			layout3.LayoutParameters = new ViewGroup.LayoutParams (ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent);

			layout3.AddView (DetailText);

			layout1.AddView (label);
			layout1.AddView (layout3);
			 
			layout1.LayoutParameters = new ViewGroup.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

			((Android.Widget.RelativeLayout)view).AddView (layout1);

		

			view.SetBackgroundColor (cell.BackgrondColor.ToAndroid ());
			

			return view;
		}
	}
}

