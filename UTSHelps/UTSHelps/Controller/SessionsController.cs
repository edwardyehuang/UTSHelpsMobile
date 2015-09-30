using System;
using UTSHelps.View;
using UTSHelps.Model;
using Xamarin.Forms;
using System.Collections;

namespace UTSHelps.Controller
{
	public class SessionsController : BaseController
	{
		public SessionsController (Sessions sessions) : base(new SessionsPage(), sessions)
		{
			
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			Sessions sessions = (Sessions)Model;

			sessions.UpdateData ();
		}
	}
}

