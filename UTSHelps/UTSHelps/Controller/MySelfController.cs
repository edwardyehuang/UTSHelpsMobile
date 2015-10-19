using System;
using UTSHelps.View;
using UTSHelps.Model;

namespace UTSHelps.Controller
{
	public class MySelfController : BaseController
	{
		protected MySelfInfoController mySelfInfo;

		public MySelfController (MainData mainData) : base (new MySelfPage(), mainData.SelfData)
		{
			
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			var mySelf = (MySelf)Model;

		}

		public override void RegViewEvents ()
		{
			base.RegViewEvents ();

			((MySelfPage)View).AvatarCell.Tapped += (object sender, EventArgs e) => ShowSelfInfoPage ();
		}

		public void ShowSelfInfoPage()
		{
			mySelfInfo = new MySelfInfoController();
		    View.Navigation.PushAsync (mySelfInfo.View);
		}
	}
}

