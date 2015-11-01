using System;
using UTSHelps.View;
using UTSHelps.Model;
using Xamarin.Forms;
using UTSHelps.UI;
using System.Diagnostics;

namespace UTSHelps.Controller
{
	public class MySelfController : BaseController
	{
		protected MySelfInfoController mySelfInfo;

		public Action ShowLoginPage { get; set; }

		public MySelfController (MainData mainData) : base (new MySelfPage(), mainData.SelfData)
		{
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			MySelfPage view = (MySelfPage)View;
			MySelf model = (MySelf)Model;

			view.BuildTable (Model.HelpsData);

			view.BuildSkinTable ();


			var signOutButton = new TextLabelCell () {
				HasArrow = false,
				Label = "Sign out",
				Text = null,
				XAlign = TextAlignment.Center,
				BackgroundColor = Color.Red,
				LabelColor = Color.White
			};

			signOutButton.Tapped += (sender, e) => SignOut();

			view.SelfTable.Root.Add (new TableSection {
				signOutButton
			});

			var aboutButton = new TextLabelCell () {
				HasArrow = true,
				Label = "About",
			};

			aboutButton.Tapped += (sender, e) => View.Navigation.PushAsync (new AboutPage ());

			view.SelfTable.Root.Add (new TableSection {
				aboutButton
			});

			model.RegStudent (model.Info.StudentId, (IsSuccess) => {
			});
		}

		public override void RegViewEvents ()
		{
			base.RegViewEvents ();
		}

	
		public void ShowSelfInfoPage()
		{
			mySelfInfo = new MySelfInfoController();
		    View.Navigation.PushAsync (mySelfInfo.View);
		}

		public async void SignOut()
		{
			var answer = await View.DisplayAlert ("Sign out", "Are you sure to sign out?", "Sign out", "Cancel");

			if (answer) {

				App.Setting.RemoveSettingValue ("UserInfo");
				ShowLoginPage ();
			}
		}
	}
}

