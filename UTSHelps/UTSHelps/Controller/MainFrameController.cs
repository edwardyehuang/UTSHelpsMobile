using System;
using Xamarin.Forms;
using UTSHelps.View;
using UTSHelps.Model;

namespace UTSHelps.Controller
{
	public class MainFrameController : BaseController
	{
		protected MainData mainData = new MainData();

		protected LoginController loginCtrl = new LoginController();

		private bool bLogged = false;

		public MainFrameController () : base(new MainFrame())
		{

			loginCtrl.SuccessSignInEvent = (string userName) => {

				mainData.SelfData.RegStudent(userName);
				//mainData.SelfData.Info.CreatorId = mainData.SelfData.Info.StudentId = userName;
				BuildChildViews ();
			};

			if (!bLogged) {
				ShowLoginPage ();
			}
		}

		protected void ShowLoginPage()
		{
			View.Navigation.PushModalAsync(loginCtrl.View, false);
		}

		protected void BuildChildViews()
		{
			TabbedPage tab = (TabbedPage)View;
			tab.Children.Add ((new LatestController ()).View);
			tab.Children.Add ((new WorkShopsController(mainData)).View);
			tab.Children.Add ((new BookingController(mainData)).View);
			tab.Children.Add ((new MySelfController(mainData)).View);
		}
	}
}

