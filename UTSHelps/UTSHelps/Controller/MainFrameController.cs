using System;
using System.Collections;
using System.Collections.Generic;
using UTSHelps.Server;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

			loginCtrl.SuccessSignInEvent = (string userName) => mainData.SelfData.RegStudent (userName, IsSuccess => {
				if (IsSuccess)
				{
					BuildChildViews ();
					bLogged = true;
				}
				else {
					loginCtrl.ReSignin ();
					ShowLoginPage ();
				}
			});

			string userInfo = App.Setting.GetSettingValue ("UserInfo");

			if (userInfo != null) {

				mainData.SelfData.Info = JsonConvert.DeserializeObject<SelfInfo> (userInfo);
				bLogged = true;
			}

			if (!bLogged) {
				ShowLoginPage ();
			} else {
				BuildChildViews ();
			}

		}

		protected void ShowLoginPage()
		{
			TabbedPage tab = (TabbedPage)View;
			tab.Children.Clear ();

			View.Navigation.PushModalAsync(loginCtrl.View, false);
		}

		protected void BuildChildViews()
		{
			TabbedPage tab = (TabbedPage)View;
//			tab.Children.Add ((new LatestController ()).View);
			tab.Children.Add ((new WorkShopsSetsController(mainData)).View);
			tab.Children.Add ((new BookingsController(mainData)).View);
			tab.Children.Add ((new MySelfController(mainData){
				
				ShowLoginPage = () => ShowLoginPage()
			}).View);
		}
	}
}

