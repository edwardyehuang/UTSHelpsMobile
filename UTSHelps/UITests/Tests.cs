using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

/// <summary>
/// UI tests
/// 
/// Requirements:
/// - NUnit 2.6.4
/// - Xamarin UITest 1.2.0
/// - 'Connect Hardware Keyboard' should be unchecked
/// 
/// Note: execution can be delayed for up to 20 seconds for some reason
/// </summary>

namespace UTSHelps.UITests
{
	[TestFixture (Platform.Android)] 
	[TestFixture (Platform.iOS)] // 
	public class Tests
	{
		IApp app;
		Platform platform;

		string LOGIN = "12345678";
		string PASSWORD  = "test123";

		string WORKSHOP = "19 Writing in academic style";
		string SET = "4 Writing Skills";

		public Tests (Platform platform)
		{
			this.platform = platform;
		}
			
		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform);
		}
			
		[Test]
		/// <summary>
		/// Performs login and books a session. Checks that session is booked.
		/// </summary>
		public void BookSession ()
		{
			app.WaitForElement (c => c.Marked ("UTS:Helps"));

			// Login
			if (platform == Platform.iOS) {
				app.EnterText (c => c.Marked ("Student Number"), LOGIN);
				app.EnterText (c => c.Marked ("Password"),	PASSWORD);
			} else {
				app.EnterText (c => c.TextField ().Index (0), LOGIN);
				app.EnterText (c => c.TextField ().Index (1), PASSWORD);
			}

			app.Tap (c => c.Marked("Sign in"));

			// Main screen
			app.WaitForElement (c => c.Marked ("WorkShop"));

			app.Tap (c => c.Marked("WorkShop"));

			// Workshops sets
			app.WaitForElement (c => c.Marked (SET));

			app.Tap (c => c.Marked(SET));

			// Workshops
			app.WaitForElement (c => c.Marked (WORKSHOP));

			app.Tap (c => c.Marked(WORKSHOP));

			// Worksjop page
			app.WaitForElement (c => c.Marked ("Topic"));

			// try to book
			try {
				app.Tap (c => c.Marked("Book"));
			} catch (Exception ex) {  }
				
			// return to main page
			app.Back ();
			app.Back ();

			// Bookings
			app.Tap (c => c.Marked("Booking"));

			// See if booking is there
			app.WaitForElement (c => c.Marked (WORKSHOP));

			// Open the booking
			app.Tap (c => c.Marked(WORKSHOP));

			// Cancell booking
			app.Tap (c => c.Marked("Cancel"));

			app.Back ();

			app.WaitForElement (c => c.Marked ("Booking"));

			// Booking should absent
			app.WaitForNoElement (c => c.Marked (WORKSHOP));

		}
	}
}

