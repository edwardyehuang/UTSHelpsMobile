using System;
using System.Collections.Generic;
using System.Linq;

using Android.Widget;
using Android.App;

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
				// no view to re-use, create new
				view = (context as Activity).LayoutInflater.Inflate (Resource.Layout.TextLabelDroidCell, null);
			}

		//	view.FindViewById<TextView> (Resource
			

			return base.GetCellCore (item, convertView, parent, context);
		}
	}
}

