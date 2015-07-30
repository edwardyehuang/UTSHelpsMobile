using System;
using UTSHelps.View;
using UTSHelps.Model;

namespace UTSHelps
{
	public class MySelfController : BaseController
	{
		protected MySelf mySelf = new MySelf();

		public MySelfController () : base(new MySelfPage())
		{
			
		}

		public override void UpdateData ()
		{
			base.UpdateData ();

		}
	}
}

