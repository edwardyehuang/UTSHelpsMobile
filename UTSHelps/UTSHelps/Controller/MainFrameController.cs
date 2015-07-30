using System;
using Xamarin.Forms;
using UTSHelps.View;

namespace UTSHelps.Controller
{
	public class MainFrameController : BaseController
	{
		protected LatestController latestCtrl = new LatestController ();
		protected SessionsController sessionsCtrl = new SessionsController();
		protected BookingController bookingCtrl = new BookingController();
		protected MySelfController mySelfCtrl = new MySelfController();

		public MainFrameController ()
		{
			View = new MainFrame ();
			BuildChildViews ();
		}

		protected void BuildChildViews()
		{
			TabbedPage tab = (TabbedPage)View;
			tab.Children.Add (latestCtrl.View);
			tab.Children.Add (sessionsCtrl.View);
			tab.Children.Add (bookingCtrl.View);
			tab.Children.Add (mySelfCtrl.View);
		}
	}
}

