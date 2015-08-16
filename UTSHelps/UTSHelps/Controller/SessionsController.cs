using System;
using UTSHelps.View;
using UTSHelps.Model;

namespace UTSHelps.Controller
{
	public class SessionsController : BaseController
	{
		public SessionsController () : base(new SessionsPage(), new Sessions())
		{
			
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

			Sessions session = (Sessions)Model;

			session.UpdateData ();
		}
	}
}

