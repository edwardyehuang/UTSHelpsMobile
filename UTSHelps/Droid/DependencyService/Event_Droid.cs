using System;
using System.Linq;
using System.Collections.Generic;

using UTSHelps.DependencyServices;
using UTSHelps.Droid;
using System.Diagnostics;

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

		}
	}
}

