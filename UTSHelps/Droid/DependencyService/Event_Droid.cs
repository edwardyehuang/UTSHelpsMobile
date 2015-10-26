using System;
using System.Linq;
using System.Collections.Generic;

using UTSHelps.DependencyServices;
using UTSHelps.Droid;
using System.Diagnostics;

using Android.Content;
using Android.App;
using Java.Util;

using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof (Event_Droid))]
namespace UTSHelps.Droid
{
	public class Event_Droid : IEvent
	{
		public Event_Droid ()
		{
		}

		public void AddEvent(string name, DateTime startTime, DateTime endTime)
		{
			Intent intent = new Intent(Intent.ActionInsert); 
			intent.SetData(Android.Provider.CalendarContract.Events.ContentUri);

			// Add Event Details
			intent.PutExtra(Android.Provider.CalendarContract.ExtraEventBeginTime, DateTimeJavaDate(startTime));
			intent.PutExtra(Android.Provider.CalendarContract.ExtraEventEndTime, DateTimeJavaDate(endTime));
			intent.PutExtra(Android.Provider.CalendarContract.EventsColumns.AllDay, false);
//			intent.PutExtra(Android.Provider.CalendarContract.EventsColumns.EventLocation, ""); TODO: event location
			intent.PutExtra(Android.Provider.CalendarContract.EventsColumns.Description, "UTS:HELPS Workshop");
			intent.PutExtra(Android.Provider.CalendarContract.EventsColumns.Title, name);
		
			// open "Add to calendar" screen
			Forms.Context.StartActivity(intent);

//			TODO: add event directly
//			https://github.com/xamarin/monodroid-samples/blob/master/CalendarDemo/EventListActivity.cs
//			
//			ContentValues eventValues = new ContentValues ();
//			eventValues.Put (CalendarContract.Events.InterfaceConsts.CalendarId, ?? ?);
//			eventValues.Put (CalendarContract.Events.InterfaceConsts.Title, "Test Event");
//			eventValues.Put (CalendarContract.Events.InterfaceConsts.Description, "This is an event created from Mono for Android");
//			eventValues.Put (CalendarContract.Events.InterfaceConsts.Dtstart, GetDateTimeMS (2011, 12, 15, 10, 0));
//			eventValues.Put (CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMS (2011, 12, 15, 11, 0));
//
//			eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
//			eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");
//
//			var uri = ContentResolver.Insert (CalendarContract.Events.ContentUri, eventValues);
//			Console.WriteLine ("Uri for new event: {0}", uri);
		}

		public static long DateTimeJavaDate(DateTime date)
		{
			Calendar c = Calendar.GetInstance (Java.Util.TimeZone.Default);

			c.Set (CalendarField.Year, date.Year);
			c.Set (CalendarField.Month, date.Month - 1);
			c.Set (CalendarField.DayOfMonth, date.Day);

			c.Set (CalendarField.HourOfDay, date.Hour);
			c.Set (CalendarField.Minute, date.Minute);

			return c.TimeInMillis;
		}
	}
}

