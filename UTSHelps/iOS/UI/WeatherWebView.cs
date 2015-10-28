using System;
using SpriteKit;

using UIKit;
using Foundation;

using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace UTSHelps.iOS
{
	public class WeatherWebView : UIWebView
	{
		public WeatherWebView() : base()
		{
			try
			{
				string fileName = "Content/rainyday/demo1.html"; // remember case-sensitive
				string localHtmlUrl = Path.Combine (NSBundle.MainBundle.BundlePath, fileName);
				LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));

				ScalesPageToFit = true;
			}
			catch (NullReferenceException) {

			}
		}
	}
}

