using System;
using UTSHelps.View;
using UTSHelps.Model;

namespace UTSHelps.Controller
{
	public class MySelfController : BaseController
	{
		protected MySelf mySelf = new MySelf();
		protected MySelfInfoController mySelfInfo;

		public MySelfController () : base (new MySelfPage())
		{
		
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			// fill profile page
//			((MySelfPage)View).nameEntry.Text = mySelf.Name;
		}

		public override void RegViewEvents ()
		{
			base.RegViewEvents ();

//			((MySelfPage)View).AvatarCell.Tapped += (object sender, EventArgs e) => ShowSelfInfoPage ();
		}

		public void ShowSelfInfoPage()
		{
			mySelfInfo = new MySelfInfoController();
		    View.Navigation.PushAsync (mySelfInfo.View);
		}
	}
}

