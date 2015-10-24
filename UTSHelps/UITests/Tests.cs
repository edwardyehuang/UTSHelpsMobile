using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UTSHelps.UITests
{
	[TestFixture (Platform.Android)] 
	[TestFixture (Platform.iOS)] // 'Connect Hardware Keyboard' should be unchecked!
	public class Tests
	{
		IApp app;
		Platform platform;

		string testLogin = "12345678";
		string testPass  = "test123";

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
			AppResult[] results = app.WaitForElement (c => c.Marked ("UTS:Helps"));

			// Login
			if (platform == Platform.iOS) {
				app.EnterText (c => c.Marked ("Student Number"), testLogin);
				app.EnterText (c => c.Marked ("Password"),	testPass);
			} else {
				app.EnterText (c => c.TextField ().Index (0), testLogin);
				app.EnterText (c => c.TextField ().Index (1), testPass);
			}

			app.Tap (c => c.Marked("Sign in"));

			// Main screen
			app.WaitForElement (c => c.Marked ("WorkShop"));

			app.Tap (c => c.Marked("WorkShop"));

			// Workshops sets
			app.WaitForElement (c => c.Marked ("4 Writing Skills"));

			app.Tap (c => c.Marked("4 Writing Skills"));

			// Workshops
			app.WaitForElement (c => c.Marked ("19 Writing in academic style"));

			app.Tap (c => c.Marked("19 Writing in academic style"));

			// Worksjop page
			app.WaitForElement (c => c.Marked ("Topic : Writing in academic style"));

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
			app.WaitForElement (c => c.Marked ("19 Writing in academic style"));

			// Open the booking
			app.Tap (c => c.Marked("19 Writing in academic style"));

			app.Tap (c => c.Marked("Cancel"));

			app.Back ();
		}
	}
}

