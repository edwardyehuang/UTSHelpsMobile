using System;
using UTSHelps.View;
using UTSHelps.Model;
using System.Diagnostics;

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

			MySelfPage view = (MySelfPage)View;
			view.BuildTable (Model.HelpsData);
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
	}
}

