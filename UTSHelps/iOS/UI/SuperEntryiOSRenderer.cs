using System;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UTSHelps.UI;
using UTSHelps.iOS;
using UTSHelps;


using Foundation;
using UIKit;

using CoreGraphics;

[assembly: ExportRenderer(typeof(SuperEntry), typeof(SuperEntryiOSRenderer))]
namespace UTSHelps.iOS
{
	public class SuperEntryiOSRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				// do whatever you want to the UITextField here!

				Control.BorderStyle = UITextBorderStyle.None;
			}
		}
	}
}

