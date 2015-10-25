using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using EventKit;

namespace UTSHelps.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public EKEventStore EventStore { get; set; }

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			LoadApplication (new App ());

			EventStore = new EKEventStore ();

			return base.FinishedLaunching (app, options);
		}
	}
}

