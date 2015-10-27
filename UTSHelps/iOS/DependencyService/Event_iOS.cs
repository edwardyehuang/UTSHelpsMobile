using System;
using System.Linq;
using System.Collections.Generic;
using UIKit;
using Foundation;
using EventKit;
using UTSHelps.DependencyServices;
using UTSHelps.iOS;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[assembly: Xamarin.Forms.Dependency (typeof (Event_iOS))]
namespace UTSHelps.iOS
{
	public class Event_iOS : UIViewController, IEvent
	{
		protected CreateEventEditViewDelegate eventControllerDelegate;

		public Event_iOS ()
		{
		}

		public void AddEvent(string name, DateTime startTime, DateTime endTime)
		{
			RequestAccess (EKEntityType.Event, () => LaunchCreateNewEvent (name, startTime, endTime));
		}

		protected void RequestAccess (EKEntityType type, Action completion)
		{
			EKEventStore eventStore = ((AppDelegate)UIApplication.SharedApplication.Delegate).EventStore;

			eventStore.RequestAccess (type,
				(bool granted, NSError e) => {

					InvokeOnMainThread(()=>{
						if (granted)
							completion.Invoke ();
						else
							new UIAlertView ("Access Denied", "User Denied Access to Calendars/Reminders", null, "ok", null).Show ();});
				});
		}

		protected void LaunchCreateNewEvent (string name, DateTime startTime, DateTime endTime)
		{
			// create a new EKEventEditViewController. This controller is built in an allows
			// the user to create a new, or edit an existing event.

			EventKitUI.EKEventEditViewController eventController =
				new EventKitUI.EKEventEditViewController ();

			// set the controller's event store - it needs to know where/how to save the event
			eventController.EventStore = ((AppDelegate)UIApplication.SharedApplication.Delegate).EventStore;

			// wire up a delegate to handle events from the controller
			eventControllerDelegate = new CreateEventEditViewDelegate (eventController);
			eventController.EditViewDelegate = eventControllerDelegate;

			eventController.Event.Title = name;
			eventController.Event.StartDate = DateTimeToNSDate (startTime);
			eventController.Event.EndDate = DateTimeToNSDate (endTime);

			// show the event controller

			UIViewController topVc = UIApplication.SharedApplication.KeyWindow.RootViewController;

			topVc.PresentViewController (eventController, true, null);

			

			/*
			EKEventStore store = ((AppDelegate)UIApplication.SharedApplication.Delegate).EventStore;

			EKEvent newEvent = EKEvent.FromStore (store);
		
			newEvent.Title = name;
			newEvent.StartDate = DateTimeToNSDate (startTime);
			newEvent.EndDate = DateTimeToNSDate (endTime);



			newEvent.Calendar = store.DefaultCalendarForNewEvents;


			NSError err;
			bool isSuceess = store.SaveEvent(newEvent, EKSpan.ThisEvent, out err);

			if (isSuceess) {

				new UIAlertView ("Add suceess", "Suceess add event to your reminder", null, "ok", null).Show ();


			} else {

				new UIAlertView ("Add fail", "Fail add event to your reminder", null, "ok", null).Show ();
				Debug.WriteLine (err.ToString ());
			}
			*/
		}

		protected class CreateEventEditViewDelegate : EventKitUI.EKEventEditViewDelegate
		{
			// we need to keep a reference to the controller so we can dismiss it
			protected EventKitUI.EKEventEditViewController eventController;

			public CreateEventEditViewDelegate (EventKitUI.EKEventEditViewController eventController)
			{
				// save our controller reference
				this.eventController = eventController;
			}

			// completed is called when a user eith
			public override void Completed (EventKitUI.EKEventEditViewController controller, EventKitUI.EKEventEditViewAction action)
			{
				eventController.DismissViewController (true, null);

				// action tells you what the user did in the dialog, so you can optionally
				// do things based on what their action was. additionally, you can get the
				// Event from the controller.Event property, so for instance, you could
				// modify the event and then resave if you'd like.
				switch (action) {

				case EventKitUI.EKEventEditViewAction.Canceled:
					break;
				case EventKitUI.EKEventEditViewAction.Deleted:
					break;
				case EventKitUI.EKEventEditViewAction.Saved:
					// if you wanted to modify the event you could do so here, and then
					// save:
					//App.Current.EventStore.SaveEvent ( controller.Event, )
					break;
				}
			}
		}

		public static NSDate DateTimeToNSDate(DateTime date)
		{
			DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
				new DateTime(2001, 1, 1, 0, 0, 0) );
			return NSDate.FromTimeIntervalSinceReferenceDate(
				(date - reference).TotalSeconds);
		}

	}
}

