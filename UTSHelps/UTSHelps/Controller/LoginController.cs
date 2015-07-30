using System;
using Xamarin.Forms;
using UTSHelps.View;

namespace UTSHelps.Controller
{
	public class LoginController : BaseController
	{
		public LoginController () : base(new LoginPage())
		{
			
		}

		public void OnClickedOfflineButton()
		{
			View.Navigation.PopModalAsync (true);
		}

		public override void RegViewEvents ()
		{
			base.RegViewEvents ();
			((LoginPage)View).OfflineButton.Clicked += (object sender, EventArgs e) => OnClickedOfflineButton ();
		}
	}
}

