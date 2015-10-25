using System;
using UTSHelps.DependencyServices;
using UTSHelps.Droid;

using Android.Preferences;
using Android.Content;

using Xamarin.Forms;
 

[assembly: Xamarin.Forms.Dependency (typeof (Setting_Droid))]
namespace UTSHelps.Droid
{
	public class Setting_Droid : ISetting
	{
		public Setting_Droid ()
		{
		}

		public string GetSettingValue (string key)
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences (Forms.Context);
			string result = prefs.GetString (key, "");

			return result.Equals("") ? null : result;
		}

		public void SetSettingValue (string key, string value)
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences (Forms.Context);
			ISharedPreferencesEditor editor = prefs.Edit();

			editor.PutString (key, value);
			editor.Apply ();
		}

		public void RemoveSettingValue (string key)
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences (Forms.Context);
			ISharedPreferencesEditor editor = prefs.Edit();

			editor.Remove (key);
			editor.Apply ();
		}
	}
}

