﻿using System;
using System.Linq;
using System.Collections.Generic;
using UIKit;
using Foundation;
using EventKit;
using UTSHelps.DependencyServices;
using UTSHelps.iOS;
using System.Diagnostics;

[assembly: Xamarin.Forms.Dependency (typeof (Setting_iOS))]
namespace UTSHelps.iOS
{
	public class Setting_iOS : ISetting
	{
		public Setting_iOS ()
		{
		}

		public string GetSettingValue (string key)
		{
			NSUserDefaults userDefaults = NSUserDefaults.StandardUserDefaults;
			return userDefaults.StringForKey (key);
		}

		public void SetSettingValue (string key, string value)
		{
			NSUserDefaults userDefaults = NSUserDefaults.StandardUserDefaults;
			userDefaults.SetString (value, key);
			userDefaults.Synchronize ();
		}

		public void RemoveSettingValue (string key)
		{
			NSUserDefaults userDefaults = NSUserDefaults.StandardUserDefaults;
			userDefaults.RemoveObject (key);
			userDefaults.Synchronize ();
		}
	}
}

