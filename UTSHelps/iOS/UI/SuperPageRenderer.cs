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

[assembly:ExportRenderer (typeof(NavigationPage), typeof(SuperPageRenderer))]
namespace UTSHelps.iOS
{
	public class SuperPageRenderer : NavigationRenderer
	{
		protected WeatherWebView weatherWebView;
		//protected WeatherView weatherView;

		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null || Element == null) {
				return;
			}
		}

		protected virtual void SetupBackgrondView()
		{
			//Read global setting
			string skinType = App.Setting.GetSettingValue("SkinType");

			if (skinType == null)
				return;

			if (skinType.Equals ("") || skinType.Equals ("Simple")) {

				SetupSimpleBackground ();
				return;
			}

			if (skinType.Equals ("Weather"))
				SetupWeatherBackground ();
		}

		protected virtual void SetupSimpleBackground()
		{
			if (weatherWebView != null) {
				weatherWebView.RemoveFromSuperview ();
				weatherWebView = null;
			}



		}

		protected virtual void SetupWeatherBackground()
		{
			//Read global setting
			string weatherType = App.Setting.GetSettingValue("WeatherSkinType");

			if (weatherType == null)
				weatherType = "Rain";

			if (weatherType.Equals (""))
				weatherType = "Rain";


			//Setup weather background
			if (weatherType.Equals ("Rain")) {

				if (weatherWebView != null) {
					weatherWebView.RemoveFromSuperview ();
					weatherWebView = null;
				}

				weatherWebView = new WeatherWebView ();
				weatherWebView.Frame = View.Frame;

				View.AddSubview (weatherWebView);

				View.SendSubviewToBack (weatherWebView);
			}
		}

		public override void ViewDidLoad ()
		{
			
			base.ViewDidLoad ();
			SetupBackgrondView();
		}
	}
}

